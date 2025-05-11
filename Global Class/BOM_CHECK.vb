Public Class BOM_CHECK

    Private Sub CMD_eXIT_Click(sender As Object, e As EventArgs) Handles CMD_eXIT.Click
        Me.Close()
    End Sub
    Public Sub LOADGRID(ByVal DC As DataTable)

        DTGRDHDR.DataSource = DC
    End Sub

    Private Sub BOM_CHECK_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class