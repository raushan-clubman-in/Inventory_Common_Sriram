Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.CrystalReports.Engine


Public Class SaleReport

    Dim gconnection As New GlobalClass

 
    Private Sub CmdPrint_Click(sender As Object, e As EventArgs) Handles CmdPrint.Click
        Dim frm As New barreport
        Dim rpt As New BarDailySale
        Dim ds As New BarSale
        Dim d1 As String = DateTimePicker1.Value.ToString("dd/MMM/yyyy")
        Dim d2 As String = DateTimePicker2.Value.ToString("dd/MMM/yyyy")
        ' Dim sql As String = "Exec SALEREPORTDAILY '" + Convert.ToDateTime(d1) + "','" + Convert.ToDateTime(d2) + "'"
        '  Dim sql As String = "select * from SALEREPORTDAILY '" + Convert.ToDateTime(d1) + "','" + Convert.ToDateTime(d2) + "')"
        gconnection.Getconnection()
        gconnection.ExcuteStoreProcedure("EXEC GROUPWISESALE '" + d1 + "','" + d2 + "','Y'")
        gconnection.ExcuteStoreProcedure("Exec SALEREPORTDAILY '" + d1 + "','" + d2 + "'")
        'raju
        'gconnection.ExcuteStoreProcedure("EXEC GROUPWISESALE '" + Convert.ToDateTime(d1) + "','" + Convert.ToDateTime(d2) + "','Y'")
        'gconnection.ExcuteStoreProcedure("Exec SALEREPORTDAILY '" + Convert.ToDateTime(d1) + "','" + Convert.ToDateTime(d2) + "'")
        'raju
        ' gconnection.getDataSet(sql, "SALEREPORTDAILY")
        Dim sql1 As String = "select * from SaleBar()"
        gconnection.getDataSet(sql1, "SaleBar")
        Dim txtobj3 As TextObject
        Dim txtobj As TextObject
        Dim txtobj12 As TextObject
        txtobj3 = rpt.ReportDefinition.ReportObjects("Text1")

        txtobj = rpt.ReportDefinition.ReportObjects("Text31")
        txtobj.Text = " From " & Format(DateTimePicker1.Value, "dd/MM/yyyy") & ""

        txtobj12 = rpt.ReportDefinition.ReportObjects("Text33")
        txtobj.Text = " To " & Format(DateTimePicker2.Value, "dd/MM/yyyy") & ""

        txtobj3.Text = UCase(gCompanyname)
        txtobj.Text = d1
        txtobj12.Text = d2
        ds.Tables("SaleBar").Merge(gdataset.Tables("SaleBar"), True, MissingSchemaAction.Ignore)
        rpt.SetDataSource(ds)
        frm.CrystalReportViewer1.ReportSource = rpt
        frm.Show()










    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub

End Class