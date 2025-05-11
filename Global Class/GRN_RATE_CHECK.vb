
Public Class GRN_RATE_CHECK

    Dim gconnection As New GlobalClass
    Public ITEM, VENDOR, sqll As String


    Private Sub CMD_eXIT_Click(sender As Object, e As EventArgs) Handles CMD_eXIT.Click
        Me.Close()
    End Sub
    Public Sub LOADGRID(ByVal DC As DataTable)

        ' DTGRDHDR.DataSource = DC
    End Sub

   

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Call FILL_GRID()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Call FILL_GRID()
    End Sub

    Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
        Call FILL_GRID()
    End Sub

    Private Sub TextBox2_Validated(sender As Object, e As EventArgs) Handles TextBox2.Validated
        Call FILL_GRID()
    End Sub

    Public Sub FILL_GRID()
        Dim DC As DataTable
        ITEM = TextBox1.Text
        VENDOR = TextBox2.Text
        sqll = "select distinct  Itemcode,Itemname,uom,grndate,Suppliercode+'-->'+Suppliername AS Supplier,isnull( rate,0)rate,isnull(taxper,0)taxper,taxamount,amountafterdiscount,grndetails from grn_details where  ISNULL(Voiditem,'')<>'Y' "

        If ITEM <> "" Then
            sqll = sqll & " AND  Itemcode+Itemname LIKE '%" & ITEM & "%' "
        End If
        If VENDOR <> "" Then
            sqll = sqll & " AND  suppliercode+Suppliername LIKE '%" & VENDOR & "%' "
        End If
        sqll = sqll & "  order by grndate desc"
        gconnection.getDataSet(sqll, "grn_details")
        If gdataset.Tables("grn_details").Rows.Count > 0 Then

            DTGRDHDR.DataSource = gdataset.Tables("grn_details")
        
            DTGRDHDR.Columns.Item(1).Width = 200
            DTGRDHDR.Columns.Item(4).Width = 200

        End If

    End Sub


    Private Sub GRN_RATE_CHECK_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
          
            If e.KeyCode = Keys.F11 Then
                Call CMD_eXIT_Click(CMD_eXIT, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.Escape Then
                Call CMD_eXIT_Click(CMD_eXIT, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub GRN_RATE_CHECK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub
End Class