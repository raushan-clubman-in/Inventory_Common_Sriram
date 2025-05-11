Public Class FrmClosingDate
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Dim lastBdate, newBdate As Date
    Private Sub BTNUpdate_Click(sender As Object, e As EventArgs) Handles BTNUpdate.Click
        newBdate = DateTimePicker1.Value
        If DateDiff(DateInterval.Day, DateTimePicker1.Value, DateValue(Now)) < 0 Then
            MessageBox.Show("To Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            Exit Sub
        Else

            sqlstring = "select bdate from Businessdate"
            gconnection.getDataSet(sqlstring, "Businessdate")
            If (gdataset.Tables("Businessdate").Rows.Count > 0) Then
                lastBdate = CDate(gdataset.Tables("Businessdate").Rows(0).Item("bdate"))
            Else
                lastBdate = gFinancialyearStart
            End If

            If DateDiff(DateInterval.Day, lastBdate, newBdate) < 0 Then
                MessageBox.Show("Date cannot be less than Last Business Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                If MsgBox("DO U Want to Update Business Date......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
                    Me.Cursor = Cursors.WaitCursor
                    sqlstring = "delete from  Businessdate"
                    gconnection.dataOperation(6, sqlstring, )
                    sqlstring = "insert into   Businessdate (bdate,updateuser,updatetime) values ('" & Format(newBdate, "dd/MMM/yyyy") & "','" & gUsername & "',getDate())"
                    gconnection.dataOperation(6, sqlstring, )
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("Update Cancelled......", MsgBoxStyle.OkOnly, "Business Date")
                End If
            End If
        End If
    End Sub

    Private Sub BTNClose_Click(sender As Object, e As EventArgs) Handles BTNClose.Click
        Me.Close()
    End Sub

    Private Sub FrmClosingDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sqlstring = "select bdate from Businessdate"
        gconnection.getDataSet(sqlstring, "Businessdate")
        If (gdataset.Tables("Businessdate").Rows.Count > 0) Then
            lastBdate = CDate(gdataset.Tables("Businessdate").Rows(0).Item("bdate"))
        Else
            lastBdate = gFinancialyearStart
        End If
        DateTimePicker1.Value = lastBdate
    End Sub
End Class