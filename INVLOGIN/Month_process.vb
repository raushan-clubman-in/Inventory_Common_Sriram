Public Class Month_process

    Dim vSeqno As Double
    Dim sqlstring As String
    Dim boolchk As Boolean
    Dim gconnection As New GlobalClass
    Dim PACKINGPERCENT As Double
    Dim vconn As New GlobalClass

    Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click

        Me.Close()

    End Sub

    Private Sub Dtp_CloseDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtp_CloseDate.ValueChanged

    End Sub

    Private Sub MONTHCLOSE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CMD_PROCESS.Visible = False

    End Sub

    Private Function checkvalidation()
        Dim mindate As Date = gconnection.getvalue(" SELECT DATEADD(DAY, 1, EOMONTH(getdate(), 0)) ")
        If (Dtp_CloseDate.Value >= mindate) Then
            MessageBox.Show("Please select proper month")
            Dtp_CloseDate.Value = gconnection.getvalue(" SELECT getdate() ")
            Return True
        End If
        Return False
    End Function
    Private Sub cmd_check_Click(sender As Object, e As EventArgs) Handles cmd_check.Click
        If (checkvalidation()) Then
            Exit Sub
        End If
        Dim accountprocess As Boolean = True
        If gAcPostingWise = "ITEM" Then
            sqlstring = "   SELECT   ITEMCODE, ITEMNAME FROM ACCOUNTSTAGGINGFORITEM where ACCOUNTCODE=''"
        ElseIf gAcPostingWise = "CATEGORY" Then
            sqlstring = "   SELECT   CATEGORYCODE, CATEGORYDESC FROM ACCOUNTSTAGGINGFORCATEGORY where ACCOUNTCODE=''"
        Else
            sqlstring = "   SELECT   CODE, DESCRIPTION FROM AccountstaggingNEW where ACCOUNTCODE=''"
        End If
        gconnection.getDataSet(sqlstring, "ACCOUNTSTAGGING")
        If gdataset.Tables("ACCOUNTSTAGGING").Rows.Count > 0 Then
            accountprocess = False
            CMD_PROCESS.Visible = False
            Me.DataGridView1.Visible = True
            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.DataSource = gdataset.Tables("ACCOUNTSTAGGING")
            lbl_display.Text = "Accounts Tagging "
            lbl_display.Visible = True
            MessageBox.Show("Accounts tagging is missing,kindly update")
            Me.DataGridView1.DataSource = Nothing
            lbl_display.Visible = False
            lbl_display.Text = ""
            Exit Sub
        End If




        sqlstring = "SELECT VOUCHERNO,VOUCHERTYPE,ACCAMOUNT,INVAMOUNT FROM UnMatchedVoucher  WHERE VOUCHERTYPE NOT IN('ISSUE')"
        gconnection.getDataSet(sqlstring, "CHECK")
        If gdataset.Tables("CHECK").Rows.Count > 0 Then
            accountprocess = False
            CMD_PROCESS.Visible = False
            Me.DataGridView1.Visible = True
            Me.DataGridView1.DataSource = Nothing
            Me.DataGridView1.DataSource = gdataset.Tables("CHECK")
            lbl_display.Text = "Accounts Posting "
            lbl_display.Visible = True
            MessageBox.Show("Accounts not posted,kindly check")
            Me.DataGridView1.DataSource = Nothing
            lbl_display.Visible = False
            lbl_display.Text = ""
            Exit Sub
        End If

        ''sqlstring = " SELECT DOCNO,SUM(ISNULL(AMOUNT,0)) AS BillAmt,J.VoucherNo,J.AccAmt FROM GmsAccPost D,
        'sqlstring = " SELECT DOCNO,SUM(ISNULL(AMOUNT,0)) AS BillAmt,J.VoucherNo,J.AccAmt FROM GmsAccPost D,(SELECT VoucherNo,SUM(AMOUNT) AS AccAmt FROM Journalentry WHERE ISNULL(VOID,'') <> 'Y' AND DESCRIPTION LIKE 'POSTING FROM GOLF%' AND CreditDebit = 'DEBIT' GROUP BY VoucherNo) J WHERE D.DOCNO = J.VoucherNo AND  month(docdate) = '" & Format(CDate(Dtp_CloseDate.Value), "MM") & "' and year(docdate) = '" & Format(CDate(Dtp_CloseDate.Value), "yyyy") & "'GROUP BY DOCNO,J.VoucherNo,J.ACCAMT HAVING (SUM(ISNULL(AMOUNT,0))) <> J.AccAmt"
        'gconnection.getDataSet(sqlstring, "posbill")
        'If gdataset.Tables("posbill").Rows.Count > 0 Then
        '    accountprocess = False
        '    CMD_PROCESS.Visible = False
        '    Me.DataGridView1.Visible = True
        '    Me.DataGridView1.DataSource = Nothing
        '    Me.DataGridView1.DataSource = gdataset.Tables("posbill")
        '    lbl_display.Text = "Accounts amount mismatch "
        '    lbl_display.Visible = True
        '    MessageBox.Show("Accounts amount mismatch,kindly check")
        '    Me.DataGridView1.DataSource = Nothing
        '    lbl_display.Visible = False
        '    lbl_display.Text = ""
        '    Exit Sub
        'End If
        If (accountprocess) Then
            MessageBox.Show("You can go for month process")
            CMD_PROCESS.Visible = True
        End If
    End Sub

    Private Sub CMD_PROCESS_Click(sender As Object, e As EventArgs) Handles CMD_PROCESS.Click
        Dim Insert(0) As String
        sqlstring = "select * from Monthendsetupmaster where modulename='INVENTORY' AND  month(monthenddate) = '" & Format(CDate(Dtp_CloseDate.Value), "MM") & "'"
        gconnection.getDataSet(sqlstring, "MONTHCLOSE")
        If gdataset.Tables("MONTHCLOSE").Rows.Count = 0 Then
            Dim SQL As String
            SQL = "INSERT INTO Monthendsetupmaster(MODULENAME,MONTHENDDATE,ADDUSER,ADDDATETIME) select 'INVENTORY',EOMONTH('" & Format(CDate(Dtp_CloseDate.Value), "dd/MMM/yyyy") & "'),'" & gUsername & "' ,GETDATE()"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = SQL
            gconnection.MoreTrans(Insert)
        Else
            lbl_monthproc.Visible = True
            lbl_monthproc.Text = "Month Process is already done for the month " & Format(CDate(Dtp_CloseDate.Value), "MMMM") & ""
            CMD_PROCESS.Visible = False
        End If

    End Sub

End Class