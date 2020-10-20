Imports DevExpress.DashboardCommon
Imports DevExpress.DashboardWin
Imports DevExpress.XtraCharts
Imports DevExpress.XtraReports.UI
Imports PieTotalExtension
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DesignerSample
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
			dashboardDesigner1.CreateRibbon()
			Dim extension As New PieTotalModule()
			extension.Attach(dashboardDesigner1)
			dashboardDesigner1.LoadDashboard("..\..\Data\dashboard.xml")

		End Sub
	End Class
End Namespace
