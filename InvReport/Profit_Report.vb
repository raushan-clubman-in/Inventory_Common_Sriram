Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports.Engine
Public Class Profit_Reports
    Dim gconnection As New GlobalClass
    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub CmdPrint_Click(sender As Object, e As EventArgs) Handles CmdPrint.Click
        Dim r As New Profit_Report
        Dim rViewer As New Viewer
        Dim d1 As String = DateTimePicker1.Value.ToString("dd/MMM/yyyy")
        Dim d2 As String = DateTimePicker2.Value.ToString("dd/MMM/yyyy")
        gconnection.Getconnection()
        gconnection.ExcuteStoreProcedure("Exec Proc_Profit_Report '" + d1 + "','" + d2 + "'")
        Dim sql1 As String = "select * from Profit_Report"
        gconnection.getDataSet(sql1, "Profit_Report")
        If gdataset.Tables("Profit_Report").Rows.Count > 0 Then
            rViewer.ssql = sql1
            rViewer.Report = r
            rViewer.TableName = "Profit_Report"
            'COMPANY NAME
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text17")
            textobj1.Text = MyCompanyName
            'ADDRESS
            Dim textobj5 As TextObject
            textobj5 = r.ReportDefinition.ReportObjects("Text15")
            textobj5.Text = UCase(Address1)
            Dim textobj6 As TextObject
            textobj6 = r.ReportDefinition.ReportObjects("Text16")
            textobj6.Text = UCase(Address2)
            Dim TXTOBJ3 As TextObject
            TXTOBJ3 = r.ReportDefinition.ReportObjects("Text18")
            TXTOBJ3.Text = Format(DateTimePicker1.Value, "dd/MM/yyyy") & "  To " & " " & Format(DateTimePicker2.Value, "dd/MM/yyyy") & ""
            rViewer.Show()

        Else
            MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
        End If
    End Sub
End Class