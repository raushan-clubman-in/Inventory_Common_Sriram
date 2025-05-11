
Public Class UnMatchedVoucherPosting

    Dim gconnection As New GlobalClass
    Public ITEM, VENDOR, sqll, Str As String


    Private Sub CMD_eXIT_Click(sender As Object, e As EventArgs) Handles CMD_eXIT.Click
        Me.Close()
    End Sub
    Public Sub LOADGRID(ByVal DC As DataTable)

        ' DTGRDHDR.DataSource = DC
    End Sub





    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GRN_RATE_CHECK_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try

            If e.KeyCode = Keys.F11 Then
                Call CMD_eXIT_Click(CMD_eXIT, e)
                Exit Sub

            ElseIf e.KeyCode = Keys.Escape Then
                Call CMD_eXIT_Click(CMD_eXIT, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F10 Then
                GBAlert.Visible = False
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Sub FILLVType()


        Str = "Select * from sysobjects where name='UnMatchedVoucher' and xtype='V'"
        gconnection.getDataSet(Str, "INV_TMPVW1")
        If gdataset.Tables("INV_TMPVW1").Rows.Count > 0 Then

        Else
            Str = "CREATE  VIEW [dbo].[UnMatchedVoucher] AS  SELECT voucherno,VOUCHERTYPE,SUM(CREDIT) AS ACCAMOUNT,SUM(DEBIT) AS INVAMOUNT FROM   "

            Str = Str & "(select sum(amount) as CREDIT ,0 AS DEBIT, voucherno,VOUCHERTYPE from journalentry   WHERE  CREDITDEBIT='DEBIT' AND  "
            Str = Str & " VoucherType IN ('ISSUE','DAMAGE','STOCK TRANSFER','CONSUMPTION','ADJUSTMENT','GRN') AND ISNULL(Void,'')<>'Y' group by voucherno,CREDITDEBIT,VOUCHERTYPE  "
            Str = Str & "  UNION ALL "
            Str = Str & " select 0 as CREDIT ,sum(amount) AS DEBIT, Docdetails as  voucherno,'ISSUE' as VOUCHERTYPE from STOCKISSUEDETAIL   WHERE   ISNULL(Void,'')<>'Y' group by Docdetails "
            Str = Str & "  UNION ALL "
            Str = Str & " select 0 as CREDIT ,sum(BILLAMOUNT) AS DEBIT, Grndetails as  voucherno,'GRN' as VOUCHERTYPE from GRN_HEADER   WHERE   ISNULL(Void,'')<>'Y' group by Grndetails "
            Str = Str & "  UNION ALL "
            Str = Str & " select 0 as CREDIT ,sum(amount) AS DEBIT, Docdetails as  voucherno,'DAMAGE' as VOUCHERTYPE from STOCKDMGDETAIL   WHERE   ISNULL(Void,'')<>'Y' group by Docdetails  "
            Str = Str & "  UNION ALL "
            Str = Str & " select 0 as CREDIT ,sum(amount) AS DEBIT, Docdetails as  voucherno,'STOCK TRANSFER' as VOUCHERTYPE from STOCKTRANSFERDETAIL   WHERE   ISNULL(Void,'')<>'Y' group by Docdetails  "
            Str = Str & "  UNION ALL "
            Str = Str & " select 0 as CREDIT ,sum(amount) AS DEBIT, docno as  voucherno,'CONSUMPTION' as VOUCHERTYPE from stockConsumption_1   WHERE   ISNULL(Void,'')<>'Y' group by docno "
            Str = Str & "  UNION ALL "
            Str = Str & " select 0 as CREDIT ,sum(amount) AS DEBIT, Docdetails as  voucherno,'ADJUSTMENT' as VOUCHERTYPE from STOCKADJUSTDETAILS   WHERE   ISNULL(Void,'')<>'Y' group by Docdetails HAVING SUM(Amount)>0 "
            Str = Str & "  UNION ALL "
            Str = Str & " select 0 as CREDIT ,sum(amount)*-1 AS DEBIT, Docdetails as  voucherno,'ADJUSTMENT' as VOUCHERTYPE from STOCKADJUSTDETAILS   WHERE   ISNULL(Void,'')<>'Y' group by Docdetails HAVING SUM(Amount)<0 "
            Str = Str & " ) T group by voucherno,VOUCHERTYPE HAVING ABS( SUM(CAST(CREDIT AS NUMERIC(18,2)) )-SUM(CAST(DEBIT AS NUMERIC(18,2))))>1 "

            gconnection.dataOperation1(6, Str, "INVENTORY_TRANSCONVERSION")


           

        End If

        ComboBox1.Items.Clear()
        Dim SQLSTRING As String
        SQLSTRING = "alter table GRN_HEADER disable trigger all"
        gconnection.ExcuteStoreProcedure(SQLSTRING)

        SQLSTRING = " UPDATE GRN_HEADER SET Billamount=Billamount+ISNULL(RoundupAmt,0),postingAmt=Billamount+ISNULL(RoundupAmt,0)  FROM GRN_HEADER  WHERE  ISNULL(Totalamount,0)+ISNULL(VATamount,0)+ISNULL(RoundupAmt,0) + ISNULL(Surchargeamt,0)+ISNULL(OverallDiscount,0)<>BILLAMOUNT AND ISNULL(Totalamount,0)+ISNULL(VATamount,0)+ISNULL(RoundupAmt,0) + ISNULL(Surchargeamt,0)+ISNULL(OverallDiscount,0)-BILLAMOUNT=ISNULL(RoundupAmt,0)"
        gconnection.ExcuteStoreProcedure(SQLSTRING)

        gconnection.dataOperation1(6, "update GRN_HEADER set Billamount= postingAmt where Grndetails in (select VoucherNo from UnMatchedVoucher where vouchertype='GRN')  and isnull(postingAmt,0)<>0 ", "INVENTORY_TRANSCONVERSION")

        SQLSTRING = "alter table GRN_HEADER ENABLE trigger all"
        gconnection.ExcuteStoreProcedure(SQLSTRING)

        Dim I As Integer
        Dim sql As String = "  SELECT  '' AS  VOUCHERTYPE UNION ALL SELECT DISTINCT VOUCHERTYPE FROM UnMatchedVoucher"
        gconnection.getDataSet(sql, "UnMatchedVoucher")
        If (gdataset.Tables("UnMatchedVoucher").Rows.Count > 0) Then
            For I = 0 To gdataset.Tables("UnMatchedVoucher").Rows.Count - 1
                ComboBox1.Items.Add(gdataset.Tables("UnMatchedVoucher").Rows(I).Item("VOUCHERTYPE"))
            Next
            'index = CMB_CATEGORY.FindString(DefaultGRN)
            'CMB_CATEGORY.SelectedIndex = index
        End If

        GBAlert.Visible = False
    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click

        Str = " SELECT *,CASE WHEN ACCAMOUNT= 0 THEN 'NOT POSTED IN ACCOUNTS ' ELSE CASE WHEN INVAMOUNT= 0 AND ACCAMOUNT>0 THEN 'TRANSACTION NOT AVAILABLE IN INEVNTORY ' ELSE CASE WHEN ABS(ACCAMOUNT-INVAMOUNT)>1 THEN 'BILL AMOUNT NOT MATCHING ' ELSE '' END  END  END AS DISCRIPTION  FROM UnMatchedVoucher  "
        If ComboBox1.SelectedItem <> "" Then

            Str = Str & " WHERE VOUCHERTYPE IN ('" & Trim(ComboBox1.SelectedItem.ToString()) & "')"

        Else
            MessageBox.Show("Select the Voucher type ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        gconnection.getDataSet(Str, "UnMatchedVoucher")
        If gdataset.Tables("UnMatchedVoucher").Rows.Count > 0 Then
            DTGRDHDR.DataSource = gdataset.Tables("UnMatchedVoucher")
            DTGRDHDR.Columns.Item(0).Width = 200
            DTGRDHDR.Columns.Item(4).Width = 200

            'Dim CHECKCOL As New DataGridViewButtonColumn
            'CHECKCOL.HeaderText = "POST"
            'DTGRDHDR.Columns.Add(CHECKCOL)
        Else
            DTGRDHDR.DataSource = Nothing

        End If


    End Sub

    Private Sub DTGRDHDR_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DTGRDHDR.CellDoubleClick
        Dim i As Integer = e.RowIndex
        Dim VOUCHERNO, VOUCHERTYPE As String
        VOUCHERNO = ""
        VOUCHERTYPE = ""
        If Not String.IsNullOrEmpty(DTGRDHDR.Rows(i).Cells(0).Value) And e.RowIndex >= 0 Then
            VOUCHERNO = DTGRDHDR.Rows(e.RowIndex).Cells(0).Value.ToString()
            VOUCHERTYPE = DTGRDHDR.Rows(e.RowIndex).Cells(1).Value.ToString()
            '    Me.Close()
        End If

        If VOUCHERNO <> "" And VOUCHERTYPE <> "" Then
            NewAccountPosting(VOUCHERNO, VOUCHERTYPE)
        End If

        Str = " SELECT VOUCHERNO,	VOUCHERDATE	, DESCRIPTION, AMOUNT,VOUCHERTYPE,		CREDITDEBIT	,ACCOUNTCODE	,SLCODE,	COSTCENTERCODE FROM INV_JV3 "
        gconnection.getDataSet(Str, "INV_JV3")
        If gdataset.Tables("INV_JV3").Rows.Count > 0 Then

            GBAlert.Visible = True
            DGV_UPPOSTED.DataSource = gdataset.Tables("INV_JV3")
            DGV_UPPOSTED.Columns.Item(0).Width = 200
            DGV_UPPOSTED.Columns.Item(2).Width = 250

        Else
            GBAlert.Visible = False
            MessageBox.Show("Voucher Posting Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Cmd_View_Click(Cmd_View, e)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GBAlert.Visible = False
    End Sub

    Private Sub UnMatchedVoucherPosting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call FILLVType()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class