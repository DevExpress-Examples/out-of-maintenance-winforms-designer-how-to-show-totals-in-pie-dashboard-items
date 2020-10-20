Imports Newtonsoft.Json
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace PieTotalExtension
	Public Class PieTotalSettings
		Public Property Enabled() As Boolean
		Public Property Prefix() As String
		Public Property Postfix() As String
		Public Property MeasureId() As String

		Public Sub New()
			Enabled = False
			Prefix = "Total"
		End Sub

		Public Shared Function FromJson(ByVal json As String) As PieTotalSettings
			If String.IsNullOrEmpty(json) Then
				Return New PieTotalSettings()
			End If
			Return TryCast(JsonConvert.DeserializeObject(Of PieTotalSettings)(json), PieTotalSettings)
		End Function

		Public Function ToJson() As String
			Return JsonConvert.SerializeObject(Me)
		End Function

	End Class

End Namespace
