Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardCommon.ViewerData
Imports DevExpress.DashboardWin
Imports DevExpress.DashboardWin.Native
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraCharts
Imports DevExpress.XtraReports.UI
Imports Newtonsoft.Json
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace PieTotalExtension
	Public Class PieTotalModule
		Private Const customPropertyName As String = "PieTotalSettings"
		Private Const barButtonShowCaption As String = "Show Total"
		Private Const barButtonSettingsCaption As String = "Total Settings"
		Private Const ribonPageGroupName As String = "Custom Properties"
		Private dashboardControl As IDashboardControl
		Private ReadOnly Property dashboardDesigner() As DashboardDesigner
			Get
				Return TryCast(dashboardControl, DashboardDesigner)
			End Get
		End Property
		Private showTotalBarItem As BarCheckItem
		Private totalSettingsBarItem As BarButtonItem

		#Region "Assigning Logic"
		Public Sub Attach(ByVal dashboardControl As IDashboardControl)
			Detach()
			Me.dashboardControl = dashboardControl
			Me.dashboardControl.CalculateHiddenTotals = True
			AddHandler Me.dashboardControl.DashboardItemControlUpdated, AddressOf DashboardItemControlUpdated
			AddHandler Me.dashboardControl.DashboardItemControlCreated, AddressOf DashboardItemControlCreated
			AddHandler Me.dashboardControl.CustomExport, AddressOf CustomExport

			If dashboardDesigner IsNot Nothing Then
				AddButtonToRibbon()
				AddHandler dashboardDesigner.DashboardItemSelected, AddressOf DashboardDesigner_DashboardItemSelected
			End If
		End Sub
		Public Sub Detach()
			If dashboardControl Is Nothing Then
				Return
			End If
			If dashboardDesigner IsNot Nothing Then
				RemoveButtonFromRibbon()
			End If
			RemoveHandler Me.dashboardControl.DashboardItemControlUpdated, AddressOf DashboardItemControlUpdated
			RemoveHandler Me.dashboardControl.DashboardItemControlCreated, AddressOf DashboardItemControlCreated
			RemoveHandler Me.dashboardControl.CustomExport, AddressOf CustomExport
			If dashboardDesigner IsNot Nothing Then
				RemoveButtonFromRibbon()
				RemoveHandler dashboardDesigner.DashboardItemSelected, AddressOf DashboardDesigner_DashboardItemSelected
			End If
			dashboardControl = Nothing
		End Sub
		#End Region

		#Region "Common Logic"
		Private Sub CustomExport(ByVal sender As Object, ByVal e As CustomExportEventArgs)
			For Each printControl In e.GetPrintableControls()
				If TypeOf printControl.Value Is XRChart Then
					Dim pieItemName = printControl.Key
					Dim dashboardControl As IDashboardControl = DirectCast(sender, IDashboardControl)
					Dim pieDashboardItem As PieDashboardItem = TryCast(dashboardControl.Dashboard.Items(pieItemName), PieDashboardItem)
					If pieDashboardItem Is Nothing Then
						Return
					End If
					Dim pieChart As XRChart = TryCast(printControl.Value, XRChart)
					If pieChart Is Nothing OrElse pieChart.Diagram Is Nothing Then
						Return
					End If
					pieChart.Diagram.Tag = pieItemName
					AddHandler pieChart.CustomizePieTotalLabel, Sub(s, args)
						Dim componentName As String = (TryCast(s, XRChart)).Diagram.Tag.ToString()
						Dim data As MultiDimensionalData = e.GetItemData(componentName)
						CustomizePieTotalLabel(componentName, data, args)
					End Sub
					For Each series As Series In pieChart.Series
						TryCast(series.View, PieSeriesView).TotalLabel.Visible = True
					Next series
				End If
			Next printControl
		End Sub
		Private Sub DashboardItemControlCreated(ByVal sender As Object, ByVal e As DashboardItemControlEventArgs)
			If e.ChartControl IsNot Nothing Then
				Dim pieItem As PieDashboardItem = TryCast(dashboardControl.Dashboard.Items(e.DashboardItemName), PieDashboardItem)
				If pieItem Is Nothing Then
					Return
				End If
				AddHandler e.ChartControl.CustomizePieTotalLabel, Sub(s, args)
					Dim componentName As String = (TryCast(s, ChartControl)).Diagram.Tag.ToString()
					Dim data As MultiDimensionalData = dashboardControl.GetItemData(componentName)
					CustomizePieTotalLabel(componentName, data, args)
				End Sub
			End If
		End Sub
		Private Sub DashboardItemControlUpdated(ByVal sender As Object, ByVal e As DashboardItemControlEventArgs)
			If e.ChartControl IsNot Nothing Then
				Dim pieItem As PieDashboardItem = TryCast(dashboardControl.Dashboard.Items(e.DashboardItemName), PieDashboardItem)
				If pieItem Is Nothing OrElse e.ChartControl.Diagram Is Nothing Then
					Return
				End If
				e.ChartControl.Diagram.Tag = e.DashboardItemName
				Dim settings As PieTotalSettings = PieTotalSettings.FromJson(pieItem.CustomProperties.GetValue(customPropertyName))
				If settings.Enabled Then
					For Each series As Series In e.ChartControl.Series
						TryCast(series.View, PieSeriesView).TotalLabel.Visible = True
					Next series
				End If
			End If
		End Sub
		Private Sub CustomizePieTotalLabel(ByVal componentName As String, ByVal data As MultiDimensionalData, ByVal e As CustomizePieTotalLabelEventArgs)
			Dim settings As PieTotalSettings = PieTotalSettings.FromJson(dashboardControl.Dashboard.Items(componentName).CustomProperties(customPropertyName))
			Dim resultText As String = String.Empty
			If Not String.IsNullOrEmpty(settings.Prefix) Then
				resultText &= settings.Prefix & Environment.NewLine
			End If



			Dim measure As MeasureDescriptor = data.GetMeasures().First()
			If Not String.IsNullOrEmpty(settings.MeasureId) OrElse data.GetMeasures().Where(Function(m) m.ID = settings.MeasureId).Any() Then
				measure = data.GetMeasures().FirstOrDefault(Function(m) m.ID = settings.MeasureId)
			End If
			If measure IsNot Nothing Then
				Dim axisPoint As AxisPoint = TryCast(e.Series.Tag, AxisPoint)
				resultText &= data.GetSlice(axisPoint).GetValue(measure).DisplayText
			End If
			If Not String.IsNullOrEmpty(settings.Postfix) Then
				resultText &= Environment.NewLine & settings.Postfix
			End If
			e.Text = resultText
		End Sub
		Private Function EnsureInstancePoint(ByVal data As MultiDimensionalData, ByVal axisPoint As AxisPoint) As AxisPoint
			Dim axisDimensions As IEnumerable(Of DimensionDescriptor) = data.GetDimensions(axisPoint.AxisName)
			Dim instanceDimension As DimensionDescriptor = axisDimensions.FirstOrDefault(Function([dim]) [dim].ID = axisPoint.Dimension.ID)
			Dim points As IEnumerable(Of AxisPoint) = data.GetAxisPointsByDimension(instanceDimension)
			Return points.Single(Function(p) p.Equals(axisPoint))
		End Function
		#End Region

		#Region "Designer Logic"
		Private Sub DashboardDesigner_DashboardItemSelected(ByVal sender As Object, ByVal e As DashboardItemSelectedEventArgs)
			UpdateTotalSettingsBarItem()
		End Sub
		Private Sub UpdateTotalSettingsBarItem()
			If TypeOf dashboardDesigner.SelectedDashboardItem Is PieDashboardItem Then
				Dim settings As PieTotalSettings = PieTotalSettings.FromJson(dashboardDesigner.SelectedDashboardItem.CustomProperties(customPropertyName))
				totalSettingsBarItem.Enabled = settings.Enabled
			End If

		End Sub
		Private Function CreateShowTotalBarItem() As BarCheckItem
			Dim barItem As New BarCheckItem()
			barItem.Caption = barButtonShowCaption
			barItem.ImageOptions.SvgImage = My.Resources.EnablePieTotals
			barItem.RibbonStyle = RibbonItemStyles.All
			AddHandler barItem.ItemClick, AddressOf OnShowTotalsClick
			Return barItem
		End Function
		Private Sub OnShowTotalsClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			Dim dashboardItem As DashboardItem = dashboardDesigner.SelectedDashboardItem
			Dim settings As PieTotalSettings = PieTotalSettings.FromJson(dashboardItem.CustomProperties.GetValue(customPropertyName))
			settings.Enabled = Not settings.Enabled
			Dim status As String = If(settings.Enabled = True, "enabled", "disabled")
			Dim historyItem As New CustomPropertyHistoryItem(dashboardItem, customPropertyName, settings.ToJson(), $"Totals for {dashboardItem.ComponentName} is {status}")
			dashboardDesigner.AddToHistory(historyItem)
			UpdateTotalSettingsBarItem()
		End Sub
		Private Function CreateSettingsBarItem() As BarButtonItem
			Dim barItem As New BarButtonItem()
			barItem.Caption = barButtonSettingsCaption
			barItem.ImageOptions.SvgImage = My.Resources.CustomizePieTotals

			AddHandler barItem.ItemClick, AddressOf OnSettingsClick
			barItem.RibbonStyle = RibbonItemStyles.All
			Return barItem
		End Function
		Private Sub AddButtonToRibbon()
			Dim ribbon As RibbonControl = dashboardDesigner.Ribbon
			Dim page As RibbonPage = ribbon.GetDashboardRibbonPage(DashboardBarItemCategory.PiesTools, DashboardRibbonPage.Design)
			Dim group As RibbonPageGroup = page.GetGroupByName(ribonPageGroupName)
			If group Is Nothing Then
				group = New RibbonPageGroup(ribonPageGroupName) With {.Name = ribonPageGroupName}
				page.Groups.Add(group)
			End If
			showTotalBarItem = CreateShowTotalBarItem()
			totalSettingsBarItem = CreateSettingsBarItem()

			group.ItemLinks.Add(showTotalBarItem)
			group.ItemLinks.Add(totalSettingsBarItem)
		End Sub
		Private Sub RemoveButtonFromRibbon()
			Dim ribbon As RibbonControl = dashboardDesigner.Ribbon
			Dim page As RibbonPage = ribbon.GetDashboardRibbonPage(DashboardBarItemCategory.PiesTools, DashboardRibbonPage.Design)
			Dim group As RibbonPageGroup = page.GetGroupByName(ribonPageGroupName)
			page.Groups.Remove(group)
		End Sub
		Private Sub OnSettingsClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			Dim dashboardItem As PieDashboardItem = TryCast(dashboardDesigner.SelectedDashboardItem, PieDashboardItem)

			Using dialog As New PieTotalSettingsDialog(dashboardItem.CustomProperties(customPropertyName), dashboardItem.GetMeasures())
				If dialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					Dim settings As PieTotalSettings = dialog.Settings
					Dim historyItem As New CustomPropertyHistoryItem(dashboardItem, customPropertyName, settings.ToJson(), $"Total settings for {dashboardItem.ComponentName} has been changed")
					dashboardDesigner.AddToHistory(historyItem)
					UpdateTotalSettingsBarItem()
				End If
			End Using
		End Sub

		#End Region
	End Class
End Namespace
