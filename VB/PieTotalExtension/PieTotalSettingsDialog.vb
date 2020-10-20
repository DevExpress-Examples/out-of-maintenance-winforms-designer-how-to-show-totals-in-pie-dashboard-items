Imports DevExpress.DashboardCommon
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraVerticalGrid
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace PieTotalExtension
	Partial Public Class PieTotalSettingsDialog
		Inherits Form

		Private _settings As PieTotalSettings
		Private _measures As List(Of Measure)
		Public ReadOnly Property Settings() As PieTotalSettings
			Get
				Return _settings
			End Get
		End Property

		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub New(ByVal settings As PieTotalSettings, ByVal measures As List(Of Measure))
			InitializeComponent()
			_settings = settings
			_measures = measures
			SetupEditors(measures)
		End Sub

		Public Sub New(ByVal settings As String, ByVal measures As List(Of Measure))
			InitializeComponent()
			_settings = PieTotalSettings.FromJson(settings)
			_measures = measures
			SetupEditors(measures)

		End Sub

		Private Sub SetupEditors(ByVal measures As List(Of Measure))
			lookUpEdit1.Properties.DisplayMember = "DisplayText"
			lookUpEdit1.Properties.ValueMember = "UniqueId"
			lookUpEdit1.Properties.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayText"))
			lookUpEdit1.Properties.DataSource = measures.Select(Function(m) New With {
				Key .UniqueId = m.UniqueId,
				Key .DisplayText = m.ToString()
			})
			If String.IsNullOrEmpty(Settings.MeasureId) OrElse Not measures.Where(Function(m) m.UniqueId = Settings.MeasureId).Any() Then
				lookUpEdit1.EditValue = measures.FirstOrDefault().UniqueId
			Else
				lookUpEdit1.EditValue = Settings.MeasureId
			End If
			textEdit1.Text = Settings.Prefix
			textEdit2.Text = Settings.Postfix
			UpdatePreview()
		End Sub

		Private Sub textEdit1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textEdit1.EditValueChanged
			Settings.Prefix = textEdit1.Text
			UpdatePreview()
		End Sub

		Private Sub textEdit2_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textEdit2.EditValueChanged
			Settings.Postfix = textEdit2.Text
			UpdatePreview()
		End Sub

		Private Sub UpdatePreview()
			Dim selectedMeasure As String = _measures.Where(Function(m) m.UniqueId = lookUpEdit1.EditValue.ToString()).FirstOrDefault().ToString()
			memoEdit1.Lines = New String() { Settings.Prefix, selectedMeasure, Settings.Postfix }
		End Sub

		Private Sub lookUpEdit1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lookUpEdit1.EditValueChanged
			Settings.MeasureId = lookUpEdit1.EditValue.ToString()
			UpdatePreview()
		End Sub
	End Class
End Namespace
