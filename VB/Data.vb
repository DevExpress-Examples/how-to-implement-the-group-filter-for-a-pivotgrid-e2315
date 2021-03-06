﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Globalization
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid

Namespace HierarchicalFilters
	Partial Public Class Form1
		Inherits Form
		Private Function GetTimeTableView() As DataView
			Dim years() As Integer = { 2009, 2010 }

			Dim table As New DataTable()
			table.Columns.Add("Name", GetType(String))
			table.Columns.Add("Price", GetType(Integer))
			table.Columns.Add("Year", GetType(Integer))
			table.Columns.Add("Month", GetType(Integer))
			table.Columns.Add("Day", GetType(Integer))
			For month As Integer = 1 To 12
				For day As Integer = 1 To 30
					table.Rows.Add("Name 1", month, 2009, month, day)
					table.Rows.Add("Name 2", 2 * month, 2009, month, day)
					table.Rows.Add("Name 1", month + 10, 2010, month, day)
					table.Rows.Add("Name 2", 2 * month + 10, 2010, month, day)
				Next day
			Next month
			Return table.DefaultView
		End Function
		Private Sub pivotGridControl1_FieldValueDisplayText(ByVal sender As Object, ByVal e As PivotFieldDisplayTextEventArgs) Handles pivotGridControl1.FieldValueDisplayText
			If Object.ReferenceEquals(e.Field, fieldMonth) Then
				e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt(Fix(e.Value)))
			End If
		End Sub
	End Class
End Namespace