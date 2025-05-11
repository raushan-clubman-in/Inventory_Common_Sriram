Imports System.Data.SqlClient
Public Class DayCloseForm
    Dim sqlstring As String
    Dim Strsql1, Sql As String
    Dim chkbool As Boolean
    Dim gconnection As New GlobalClass
    Dim BussinessType As String
    Private Sub DayCloseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cmd_MonthClose.Visible = False
        Dtp_FromDate.Value = Now.Date()
        Lbl_Info.Text = ""
        Cmd_MonthClose.Visible = False

        sqlstring = "Select * from sysobjects where name='dayendmodulesetup' and xtype='U'"
        gconnection.getDataSet(sqlstring, "dayendmodulesetup")
        If gdataset.Tables("dayendmodulesetup").Rows.Count > 0 Then
        Else
            sqlstring = "CREATE TABLE [dbo].[dayendmodulesetup](	[sino] [int] NULL,	[modulename] [varchar](50) NULL,	[closetype] [varchar](20) NULL,	[adduser] [varchar](20) NULL,	[adddatetime] [datetime] NULL) ON [PRIMARY]"
        End If
        gconnection.getDataSet(sqlstring, "dayendmodulesetup")

        sqlstring = "Select * from sysobjects where name='DAYENDSETUPMASTER' and xtype='U'"
        gconnection.getDataSet(sqlstring, "DAYENDSETUPMASTER")
        If gdataset.Tables("DAYENDSETUPMASTER").Rows.Count > 0 Then
        Else
            sqlstring = "CREATE TABLE [dbo].[DAYENDSETUPMASTER]([MODULENAME] [varchar](50) NULL,[BUSINESSDATE] [datetime] NULL,	[ADDUSERID] [varchar](20) NULL,	[ADDDATETIME] [datetime] NULL) ON [PRIMARY]"
        End If
        gconnection.getDataSet(sqlstring, "DAYENDSETUPMASTER")

        sqlstring = "  Select * from dayendmodulesetup where modulename='INVENTORY'"
        gconnection.getDataSet(sqlstring, "billdate1")
        If gdataset.Tables("billdate1").Rows.Count > 0 Then
            If UCase(gdataset.Tables("billdate1").Rows(0).Item("closetype")) = "MONTHLY" Then
                BussinessType = UCase(gdataset.Tables("billdate1").Rows(0).Item("closetype"))
                Dtp_FromDate.CustomFormat = "MMMMM"
                ''SQL = " select (SELECT CAST(CONVERT(VARCHAR(11),EOMONTH(ISNULL(DATEADD(day,1,MAX(BUSINESSDATE)),GETDATE())),106)AS DATETIME) FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') as billdate "
                Sql = " Select Case when (select count(*)FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY')>0 then (select DateAdd(d, -Day(DateAdd(m, 1, DateAdd(Month, 2, MAX(BUSINESSDATE)))), DateAdd(Month, 2, MAX(BUSINESSDATE)))FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') else (select case when (SELECT DATEADD(MONTH, DATEDIFF(MONTH, -1, CAST(CONVERT(VARCHAR(11),(ISNULL(DATEADD(day,1,MAX(BUSINESSDATE)),GETDATE())),106)AS DATETIME))-1, -1) FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY')>cast(convert(varchar(11),getdate(),106)as datetime) then  (select dateadd(d,-day(dateadd(m,0,dateadd(month,1,getdate()))),dateadd(month,0,getdate()))FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') else (SELECT DATEADD(MONTH, DATEDIFF(MONTH, -1, CAST(CONVERT(VARCHAR(11),(ISNULL(DATEADD(day,1,MAX(BUSINESSDATE)),GETDATE())),106)AS DATETIME))-1, -1) FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') end ) end  as billdate"
                gconnection.getDataSet(Sql, "billdate")
                If gdataset.Tables("billdate").Rows.Count > 0 Then
                    Me.Dtp_FromDate.Value = gdataset.Tables("billdate").Rows(0).Item(0)
                End If
            Else
                BussinessType = UCase(gdataset.Tables("billdate1").Rows(0).Item("closetype"))
                Dtp_FromDate.CustomFormat = "dd/MMM/yyyy"
                Sql = " select (SELECT CAST(CONVERT(VARCHAR(11),ISNULL(DATEADD(DAY,1,MAX(BUSINESSDATE)),GETDATE()),106)AS DATETIME) FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') as billdate "
                gconnection.getDataSet(Sql, "billdate")
                If gdataset.Tables("billdate").Rows.Count > 0 Then
                    If gUserCategory <> "S" Then
                        Me.Dtp_FromDate.MinDate = gdataset.Tables("billdate").Rows(0).Item(0)
                    Else
                        Me.Dtp_FromDate.MinDate = gFinancialyearStart
                    End If
                    Me.Dtp_FromDate.Value = gdataset.Tables("billdate").Rows(0).Item(0)
                End If
                End If
        Else
            MsgBox(" Dayend Module Setup is not done please do the setup")
            Exit Sub
        End If

        Dim objfrmMANUALUPDATION As New frmMANUALUPDATION
        objfrmMANUALUPDATION.Show()

    End Sub
    Private Sub Cmd_Process_Click(sender As Object, e As EventArgs) Handles Cmd_Process.Click
        Dim CloseDate As Date
        Try

            sqlstring = "Select * from sysobjects where name='cp_inv_consumtpion' and type='P'"
            gconnection.getDataSet(sqlstring, "vw_inv_autoconsumption_items")
            If gdataset.Tables("vw_inv_autoconsumption_items").Rows.Count > 0 Then
                sqlstring = "exec cp_inv_consumtpion '" + Format(Dtp_FromDate.Value, "dd MMM yyyy") + "','" + Format(Dtp_FromDate.Value, "dd MMMyyyy") + "'"
                gconnection.getDataSet(sqlstring, "CloseCheck")
            End If


            sqlstring = "select * from DAYENDSETUPMASTER where MONTH(BUSINESSDATE) = " & Month(Dtp_FromDate.Value) & " AND YEAR(BUSINESSDATE) = " & Year(Dtp_FromDate.Value) & " AND MODULENAME = 'INVENTORY' "
            gconnection.getDataSet(sqlstring, "CloseCheck")

            If BussinessType = "MONTHLY" Then
                CloseDate = New DateTime(Dtp_FromDate.Value.Year, Dtp_FromDate.Value.Month, 1).AddMonths(1).AddDays(-1)
                sqlstring = "select * from DAYENDSETUPMASTER where MONTH(BUSINESSDATE) = " & Month(Dtp_FromDate.Value) & " AND YEAR(BUSINESSDATE) = " & Year(Dtp_FromDate.Value) & " AND MODULENAME = 'INVENTORY' "
                gconnection.getDataSet(sqlstring, "CloseCheck")
                If gdataset.Tables("CloseCheck").Rows.Count > 0 Then
                    MessageBox.Show(MonthName(Month(CloseDate)) & " Month Already Closed, you Can't Processed Again")
                    Lbl_Info.Text = MonthName(Month(CloseDate)) & " Month Already Closed, you Can't Processed Again"
                    Cmd_MonthClose.Visible = False
                    Exit Sub
                End If
            ElseIf BussinessType = "DAILY" Then
                CloseDate = Format(Dtp_FromDate.Value, "dd-MMM-yyyy")
                sqlstring = "select * from DAYENDSETUPMASTER where CAST(CONVERT(VARCHAR(11),BUSINESSDATE,106) AS DATETIME) = '" & Format(CloseDate, "dd-MMM-yyyy") & "' AND MODULENAME = 'INVENTORY' "
                gconnection.getDataSet(sqlstring, "CloseCheck")
                If gdataset.Tables("CloseCheck").Rows.Count > 0 Then
                    MessageBox.Show("Selected Date Already Closed, you Can't Processed Again")
                    Lbl_Info.Text = "Selected Date Already Closed, you Can't Processed Again"
                    Cmd_MonthClose.Visible = False
                    Exit Sub
                End If
            Else
                MessageBox.Show("Setup Not Done,Please Set Process Type MOnthly or Daily")
                Exit Sub
            End If

            Dim MODULETYPE As String

            MODULETYPE = "Inventory"

            If BussinessType = "DAILY" Then

                If MODULETYPE = "Accounts" Then
                    sqlstring = "SELECT ItemCode,ItemDesc FROM ITEMMASTER WHERE ITEMCODE IN (SELECT DISTINCT ITEMCODE FROM KOT_DET WHERE CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND ISNULL(KOTSTATUS,'') <> 'Y' "
                    sqlstring = sqlstring & " AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> '') AND ISNULL(salesacctin,'') = '' "
                    gconnection.getDataSet(sqlstring, "AccBlank")
                    If gdataset.Tables("AccBlank").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("AccBlank")
                        Lbl_Info.Text = "Sales Account Not Found for this Items"
                        Cmd_MonthClose.Visible = False
                        Exit Sub
                    End If
                End If

                If MODULETYPE = "Accounts" Then

                    sqlstring = "SELECT DISTINCT ItemCode,ItemDesc,SalesAcctin FROM ITEMMASTER WHERE ITEMCODE IN (SELECT DISTINCT ITEMCODE FROM KOT_DET WHERE CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND ISNULL(KOTSTATUS,'') <> 'Y'  "
                    sqlstring = sqlstring & " AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> '') AND ISNULL(salesacctin,'') <> '' AND ISNULL(salesacctin,'') NOT IN (SELECT accode FROM ACCOUNTSGLACCOUNTMASTER WHERE ISNULL(FREEZEFLAG,'') <> 'Y') "
                    gconnection.getDataSet(sqlstring, "AccWrong")
                    If gdataset.Tables("AccWrong").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("AccWrong")
                        Lbl_Info.Text = "Wrong Sales Account Tag for this Items"
                        Cmd_MonthClose.Visible = False
                        Exit Sub
                    End If
                End If

                If MODULETYPE = "Accounts" Then

                    sqlstring = "SELECT * FROM PAYMENTMODEMASTER WHERE PaymentCode IN (SELECT Distinct PAYMENTMODE FROM KOT_DET WHERE CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y'  "
                    sqlstring = sqlstring & " AND ISNULL(BILLDETAILS,'') <> '') AND ISNULL(AccountIn,'') = '' AND iSNULL(Subpaystatus,'') <> 'YES' "
                    gconnection.getDataSet(sqlstring, "AccWrong")
                    If gdataset.Tables("AccWrong").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("AccWrong")
                        Lbl_Info.Text = "Account Not Found for this PayMode"
                        Cmd_MonthClose.Visible = False
                        Exit Sub
                    End If
                End If

                If MODULETYPE = "Accounts" Then

                    sqlstring = "SELECT DISTINCT BILLDETAILS,KOTDATE AS BILLDATE,MCODE,PAYMENTMODE FROM KOT_DET WHERE CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') <> '' "
                    sqlstring = sqlstring & " AND billdetails NOT IN (SELECT DISTINCT VoucherNo FROM Journalentry WHERE VoucherType <> 'SALECONSUMPTION' AND ISNULL(VOID,'') <> 'Y' AND CAST(CONVERT(VARCHAR(11),VoucherDate,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND DESCRIPTION LIKE 'POSTING FROM POS%') "
                    gconnection.getDataSet(sqlstring, "NotPosted")
                    If gdataset.Tables("NotPosted").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("NotPosted")
                        Lbl_Info.Text = "Listed Bill are Not Found in Accounts"
                        Cmd_MonthClose.Visible = False
                        Exit Sub
                    End If
                End If

                If MODULETYPE = "Accounts" Then

                    sqlstring = "SELECT Salesacctin AS PosSalesAccount,SUM(ISNULL(AMOUNT,0)) AS POSCREDIT,J.AccountCode AS AccAccountCode,ACCCREDIT FROM KOT_DET D,ItemMaster I, "
                    sqlstring = sqlstring & " (SELECT AccountCode,SUM(AMOUNT) AS ACCCREDIT FROM journalentry WHERE CAST(CONVERT(VARCHAR(11),VoucherDate,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND VoucherType <> 'SALECONSUMPTION' and ISNULL(VOID,'') <> 'Y' "
                    ''sqlstring = sqlstring & " AND DESCRIPTION LIKE 'POSTING FROM POS%' AND CreditDebit = 'CREDIT' GROUP BY AccountCode) J WHERE D.ITEMCODE = i.ItemCode AND I.Salesacctin = J.AccountCode AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND ISNULL(BILLDETAILS,'') <> '' AND PAYMENTMODE <> 'ROOM'  "
                    sqlstring = sqlstring & " AND DESCRIPTION LIKE 'POSTING FROM POS%' AND CreditDebit = 'CREDIT' GROUP BY AccountCode) J WHERE D.ITEMCODE = i.ItemCode AND I.Salesacctin = J.AccountCode AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND ISNULL(BILLDETAILS,'') <> '' "
                    sqlstring = sqlstring & " AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(D.DELFLAG,'') <> 'Y' GROUP BY Salesacctin,J.AccountCode,ACCCREDIT HAVING SUM(ISNULL(AMOUNT,0)) <> ACCCREDIT "
                    gconnection.getDataSet(sqlstring, "ItemAccUnMatch")
                    If gdataset.Tables("ItemAccUnMatch").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("ItemAccUnMatch")
                        Lbl_Info.Text = "Listed Item Revenue Account Vs Account Revenue Amount Not Matched"
                        Cmd_MonthClose.Visible = False
                        Exit Sub
                    End If
                End If

                If MODULETYPE = "Accounts" Then
                    sqlstring = " SELECT Voucherno,SUM(AMOUNT) AS ACCDEBIT,ACCCREDIT FROM journalentry JD,(SELECT Voucherno AS AVoucherno,SUM(AMOUNT) AS ACCCREDIT FROM journalentry WHERE CAST(CONVERT(VARCHAR(11),VoucherDate,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' "
                    sqlstring = sqlstring & " AND VoucherType <> 'SALECONSUMPTION' and ISNULL(VOID,'') <> 'Y' AND DESCRIPTION LIKE 'POSTING FROM POS%' AND CreditDebit = 'CREDIT' GROUP BY Voucherno) JC "
                    sqlstring = sqlstring & " WHERE JD.VoucherNo = JC.AVoucherno AND CAST(CONVERT(VARCHAR(11),VoucherDate,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND VoucherType <> 'SALECONSUMPTION' and ISNULL(VOID,'') <> 'Y' "
                    sqlstring = sqlstring & " AND DESCRIPTION LIKE 'POSTING FROM POS%' AND CreditDebit = 'DEBIT' GROUP BY Voucherno,ACCCREDIT HAVING SUM(AMOUNT) <> ACCCREDIT "
                    gconnection.getDataSet(sqlstring, "AccDCNotMat")
                    If gdataset.Tables("AccDCNotMat").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("AccDCNotMat")
                        Lbl_Info.Text = "Listed Posted Voucher Amount Not Matched"
                        Cmd_MonthClose.Visible = False
                        Exit Sub
                    End If
                End If

                If MODULETYPE = "Accounts" Then
                    sqlstring = "SELECT VoucherNo,VoucherDate,AccountCode,AccountcodeDesc,SLCode,SLDesc,CreditDebit,Amount FROM Journalentry WHERE ISNULL(VOID,'') <> 'Y' AND CAST(CONVERT(VARCHAR(11),VoucherDate,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "'  "
                    sqlstring = sqlstring & " AND DESCRIPTION LIKE 'POSTING FROM POS%' AND VoucherType <> 'SALECONSUMPTION' AND VoucherNo IN (SELECT BILLDETAILS FROM BILL_HDR WHERE ISNULL(DELFLAG,'') = 'Y') "
                    gconnection.getDataSet(sqlstring, "DelPosted")
                    If gdataset.Tables("DelPosted").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("DelPosted")
                        Lbl_Info.Text = "Listed Deleted Bill are Found in Accounts"
                        Cmd_MonthClose.Visible = False
                        Exit Sub
                    End If
                End If

                'sqlstring = " SELECT KOTDETAILS,GITEMCODE,STORECODE,gUOM,SUM(TOTSALEQTY) AS SALQTY,SUM(INVQTY) AS INVQTY FROM ( "
                'sqlstring = sqlstring & " SELECT KOTDETAILS,gitemcode,L.STORECODE,GUOM,QTY * gqty AS TOTSALEQTY,0 AS INVQTY FROM KOT_DET D,BOM_DET B ,POSITEMSTORELINK L "
                'sqlstring = sqlstring & " WHERE D.ITEMCODE = B.ITEMCODE AND D.UOM = B.ItemUOM AND D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND ISNULL(BILLDETAILS,'') <> '' "
                'sqlstring = sqlstring & " AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' UNION ALL SELECT Trnno,itemcode,STORECODE,uom,0,QTY FROM CLOSINGQTY WHERE CAST(CONVERT(VARCHAR(11),TRNDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND TTYPE = 'KOT'  "
                'sqlstring = sqlstring & " ) AS T GROUP BY STORECODE,gitemcode,KOTDETAILS,gUOM HAVING SUM(TOTSALEQTY) + SUM(INVQTY) <> 0 "

                If MODULETYPE = "Inventory" Then
                    sqlstring = "SELECT KOTDETAILS,KOTDATE,MCODE,PAYMENTMODE FROM KOT_DET WHERE CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') = '' "
                    gconnection.getDataSet(sqlstring, "PKOT")
                    If gdataset.Tables("PKOT").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("PKOT")
                        Lbl_Info.Text = "List of Pending KOT.."
                        Cmd_MonthClose.Visible = False
                        'If gUserCategory <> "S" Then
                        '    Exit Sub
                        'End If
                        Exit Sub
                    End If
                End If

                If MODULETYPE = "Inventory" Then
                    sqlstring = "select itemcode,itemdesc,BaseUOM from itemmaster where StkCtl='Yes' and itemcode not in (select itemcode from BOM_DET where isnull(endingdate,'')='') and isnull(freeze,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "StkCtl")
                    If gdataset.Tables("StkCtl").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("StkCtl")
                        Lbl_Info.Text = "List of StkCtrl items without BOM.."
                        Cmd_MonthClose.Visible = False
                        'If gUserCategory <> "S" Then
                        '    Exit Sub
                        'End If
                        Exit Sub
                    End If
                    '
                End If


                If MODULETYPE = "Inventory" Then
                    sqlstring = "  SELECT KOTDETAILS,GITEMCODE,STORECODE,gUOM,SUM(TOTSALEQTY) AS SALQTY,SUM(INVQTY) AS INVQTY FROM (  SELECT KOTDETAILS,gitemcode,case when len(ISNULL((select top 1 L.STORECODE from POSITEMSTORELINK L where  D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE and ISNULL(L.STORECODE,'')<>'' ),poscode))>1 then ISNULL((select top 1 L.STORECODE from POSITEMSTORELINK L where  D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE and ISNULL(L.STORECODE,'')<>'' ),poscode) else POSCODE end  as STORECODE ,GUOM,QTY * gqty AS TOTSALEQTY,0 AS INVQTY FROM KOT_DET D,BOM_DET B  "
                    sqlstring = sqlstring & " WHERE D.ITEMCODE = B.ITEMCODE AND D.UOM = B.ItemUOM AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' and isnull(b.void,'')<>'Y'  and d.ITEMCODE not in ('P03') AND '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' BETWEEN b.Startdate and isnull(b.endingdate,convert(varchar(11),getdate(),106)) "
                    sqlstring = sqlstring & " And ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' "
                    sqlstring = sqlstring & " UNION ALL  SELECT Trnno,itemcode,STORECODE,uom,0,QTY FROM CLOSINGQTY WHERE CAST(CONVERT(VARCHAR(11),TRNDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND TTYPE = 'KOT' and ITEMCODE not in ('P03')  "
                    sqlstring = sqlstring & " ) AS T GROUP BY STORECODE,gitemcode,KOTDETAILS,gUOM HAVING CAST(round(SUM(TOTSALEQTY),3) + round(SUM(INVQTY),3) AS NUMERIC(18,3)) <> 0  "
                    gconnection.getDataSet(sqlstring, "ClsQtyUnM")
                    If gdataset.Tables("ClsQtyUnM").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("ClsQtyUnM")
                        Lbl_Info.Text = "List of Kot Item Qty vs closing Qty mismatch"
                        Cmd_MonthClose.Visible = False
                        'If gUserCategory <> "S" Then
                        '    Exit Sub
                        'End If
                        Exit Sub
                    End If
                End If

                'sqlstring = " SELECT KOTDETAILS,GITEMCODE,STORECODE,gUOM,SUM(TOTSALEQTY) AS SALQTY,SUM(INVQTY) AS INVQTY FROM ( "
                'sqlstring = sqlstring & " SELECT KOTDETAILS,gitemcode,L.STORECODE,GUOM,QTY * gqty AS TOTSALEQTY,0 AS INVQTY FROM KOT_DET D,BOM_DET B ,POSITEMSTORELINK L "
                'sqlstring = sqlstring & " WHERE D.ITEMCODE = B.ITEMCODE AND D.UOM = B.ItemUOM AND D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND ISNULL(BILLDETAILS,'') <> '' "
                'sqlstring = sqlstring & " AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' UNION ALL SELECT Docdetails,itemcode,Storelocationcode,uom,0,QTY FROM SUBSTORECONSUMPTIONDETAIL WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' and ISNULL(void,'') <> 'Y'  "
                'sqlstring = sqlstring & " ) AS T GROUP BY STORECODE,gitemcode,KOTDETAILS,gUOM HAVING SUM(TOTSALEQTY) - SUM(INVQTY) <> 0 "


                If MODULETYPE = "Inventory" Then
                    sqlstring = "  SELECT KOTDETAILS,GITEMCODE,STORECODE,gUOM,SUM(TOTSALEQTY) AS SALQTY,SUM(INVQTY) AS INVQTY FROM (  SELECT KOTDETAILS,gitemcode,case when len(ISNULL((select top 1 L.STORECODE from POSITEMSTORELINK L where  D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE and ISNULL(L.STORECODE,'')<>'' ),poscode))>1 then ISNULL((select top 1 L.STORECODE from POSITEMSTORELINK L where  D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE and ISNULL(L.STORECODE,'')<>'' ),poscode) else POSCODE end  as STORECODE ,GUOM,QTY * gqty AS TOTSALEQTY,0 AS INVQTY FROM KOT_DET D,BOM_DET B  "
                    sqlstring = sqlstring & "  WHERE D.ITEMCODE = B.ITEMCODE AND D.UOM = B.ItemUOM AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' and isnull(b.void,'')<>'Y' and d.ITEMCODE not in ('P03') AND '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' BETWEEN b.Startdate and isnull(b.endingdate,convert(varchar(11),getdate(),106)) "
                    sqlstring = sqlstring & "  AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y'  "
                    sqlstring = sqlstring & "  UNION ALL SELECT Docdetails,itemcode,Storelocationcode,uom,0,QTY FROM SUBSTORECONSUMPTIONDETAIL WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' and ISNULL(void,'') <> 'Y' and ITEMCODE not in ('P03') AND ITEMCODE IN (SELECT GITEMCODE FROM BOM_DET where isnull(endingdate,'')='') "
                    sqlstring = sqlstring & "   ) AS T GROUP BY STORECODE,gitemcode,KOTDETAILS,gUOM HAVING CAST(round(SUM(TOTSALEQTY),3) - round(SUM(INVQTY),3) AS NUMERIC(18,3)) <> 0  "
                    gconnection.getDataSet(sqlstring, "SubStoreQtyUnM")
                    If gdataset.Tables("SubStoreQtyUnM").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("SubStoreQtyUnM")
                        Lbl_Info.Text = "List of Kot Item Qty vs SubStoreConsumption Qty mismatch"
                        Cmd_MonthClose.Visible = False
                        'If gUserCategory <> "S" Then
                        '    Exit Sub
                        'End If
                        Exit Sub
                    End If
                End If

                If MODULETYPE = "Inventory" Then
                    sqlstring = "SELECT   c.itemcode, isnull( m.itemname,''),C.storecode,isnull(m.STOCKUOM,''),CAST(c.closingstock AS VARCHAR (10)),Cast(trndate as VARCHAR(20)) AS INV from closingqty c inner join INV_InventoryItemMaster m ON c.itemcode=M.itemcode where TRNS_SEQ in( select  max(TRNS_SEQ) from closingqty group by storecode,itemcode) and closingstock<0 ORDER BY STORECODE"
                    gconnection.getDataSet(sqlstring, "SubStoreQtyUnM")
                    If gdataset.Tables("SubStoreQtyUnM").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("SubStoreQtyUnM")
                        Lbl_Info.Text = "List of neagtive stockitem"
                        Cmd_MonthClose.Visible = False
                        'If gUserCategory <> "S" Then
                        '    Exit Sub
                        'End If
                        Exit Sub
                    End If
                End If

                Cmd_MonthClose.Visible = True

            Else

                If MODULETYPE = "Inventory" Then
                    sqlstring = "SELECT KOTDETAILS,KOTDATE,MCODE,PAYMENTMODE FROM KOT_DET WHERE month(CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME)) = '" & Month(Dtp_FromDate.Value) & "' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' AND ISNULL(BILLDETAILS,'') = '' "
                    gconnection.getDataSet(sqlstring, "PKOT")
                    If gdataset.Tables("PKOT").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("PKOT")
                        Lbl_Info.Text = "List of Pending KOT.."
                        Cmd_MonthClose.Visible = False
                        'If gUserCategory <> "S" Then
                        '    Exit Sub
                        'End If
                        Exit Sub
                    End If
                End If

                If MODULETYPE = "Inventory" Then
                    sqlstring = "select itemcode,itemdesc,BaseUOM from itemmaster where StkCtl='Yes' and itemcode not in (select itemcode from BOM_DET where isnull(endingdate,'')='') and isnull(freeze,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "StkCtl")
                    If gdataset.Tables("StkCtl").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("StkCtl")
                        Lbl_Info.Text = "List of StkCtrl items without BOM.."
                        Cmd_MonthClose.Visible = False
                        'If gUserCategory <> "S" Then
                        '    Exit Sub
                        'End If
                        Exit Sub
                    End If
                    '
                End If


                If MODULETYPE = "Inventory" Then
                    sqlstring = "  SELECT KOTDETAILS,GITEMCODE,STORECODE,gUOM,SUM(TOTSALEQTY) AS SALQTY,SUM(INVQTY) AS INVQTY FROM (  SELECT KOTDETAILS,gitemcode,case when len(ISNULL((select top 1 L.STORECODE from POSITEMSTORELINK L where  D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE and ISNULL(L.STORECODE,'')<>'' ),poscode))>1 then ISNULL((select top 1 L.STORECODE from POSITEMSTORELINK L where  D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE and ISNULL(L.STORECODE,'')<>'' ),poscode) else POSCODE end  as STORECODE ,GUOM,QTY * gqty AS TOTSALEQTY,0 AS INVQTY FROM KOT_DET D,BOM_DET B  "
                    sqlstring = sqlstring & " WHERE D.ITEMCODE = B.ITEMCODE AND D.UOM = B.ItemUOM AND month(CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME)) = '" & Month(Dtp_FromDate.Value) & "' and isnull(b.void,'')<>'Y'  and d.ITEMCODE not in ('P03') AND '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' BETWEEN b.Startdate and isnull(b.endingdate,convert(varchar(11),getdate(),106)) "
                    sqlstring = sqlstring & " AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y'  "
                    sqlstring = sqlstring & " UNION ALL  SELECT Trnno,itemcode,STORECODE,uom,0,QTY FROM CLOSINGQTY WHERE month(CAST(CONVERT(VARCHAR(11),TRNDATE,106) AS DATETIME)) = '" & Month(Dtp_FromDate.Value) & "' AND TTYPE = 'KOT' and ITEMCODE not in ('P03') "
                    sqlstring = sqlstring & " ) AS T GROUP BY STORECODE,gitemcode,KOTDETAILS,gUOM HAVING CAST(round(SUM(TOTSALEQTY),3) + round(SUM(INVQTY),3) AS NUMERIC(18,3)) <> 0  "
                    gconnection.getDataSet(sqlstring, "ClsQtyUnM")
                    If gdataset.Tables("ClsQtyUnM").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("ClsQtyUnM")
                        Lbl_Info.Text = "List of Kot Item Qty vs closing Qty mismatch"
                        Cmd_MonthClose.Visible = False
                        'If gUserCategory <> "S" Then
                        '    Exit Sub
                        'End If
                        Exit Sub
                    End If
                End If

                'sqlstring = " SELECT KOTDETAILS,GITEMCODE,STORECODE,gUOM,SUM(TOTSALEQTY) AS SALQTY,SUM(INVQTY) AS INVQTY FROM ( "
                'sqlstring = sqlstring & " SELECT KOTDETAILS,gitemcode,L.STORECODE,GUOM,QTY * gqty AS TOTSALEQTY,0 AS INVQTY FROM KOT_DET D,BOM_DET B ,POSITEMSTORELINK L "
                'sqlstring = sqlstring & " WHERE D.ITEMCODE = B.ITEMCODE AND D.UOM = B.ItemUOM AND D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND ISNULL(BILLDETAILS,'') <> '' "
                'sqlstring = sqlstring & " AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' UNION ALL SELECT Docdetails,itemcode,Storelocationcode,uom,0,QTY FROM SUBSTORECONSUMPTIONDETAIL WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' and ISNULL(void,'') <> 'Y'  "
                'sqlstring = sqlstring & " ) AS T GROUP BY STORECODE,gitemcode,KOTDETAILS,gUOM HAVING SUM(TOTSALEQTY) - SUM(INVQTY) <> 0 "


                If MODULETYPE = "Inventory" Then
                    sqlstring = "  SELECT KOTDETAILS,GITEMCODE,STORECODE,gUOM,SUM(TOTSALEQTY) AS SALQTY,SUM(INVQTY) AS INVQTY FROM (  SELECT KOTDETAILS,gitemcode,case when len(ISNULL((select top 1 L.STORECODE from POSITEMSTORELINK L where  D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE and ISNULL(L.STORECODE,'')<>'' ),poscode))>1 then ISNULL((select top 1 L.STORECODE from POSITEMSTORELINK L where  D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE and ISNULL(L.STORECODE,'')<>'' ),poscode) else POSCODE end  as STORECODE ,GUOM,QTY * gqty AS TOTSALEQTY,0 AS INVQTY FROM KOT_DET D,BOM_DET B  "
                    sqlstring = sqlstring & "  WHERE D.ITEMCODE = B.ITEMCODE AND D.UOM = B.ItemUOM AND month(CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME)) = '" & Month(Dtp_FromDate.Value) & "' and isnull(b.void,'')<>'Y' and d.ITEMCODE not in ('P03') AND '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' BETWEEN b.Startdate and isnull(b.endingdate,convert(varchar(11),getdate(),106)) "
                    sqlstring = sqlstring & "  AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y'  "
                    sqlstring = sqlstring & "  UNION ALL SELECT Docdetails,itemcode,Storelocationcode,uom,0,QTY FROM SUBSTORECONSUMPTIONDETAIL WHERE month(CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME)) = '" & Month(Dtp_FromDate.Value) & "' and ISNULL(void,'') <> 'Y' and ITEMCODE not in ('P03') AND ITEMCODE IN (SELECT GITEMCODE FROM BOM_DET where isnull(endingdate,'')='') "
                    sqlstring = sqlstring & "   ) AS T GROUP BY STORECODE,gitemcode,KOTDETAILS,gUOM HAVING CAST(round(SUM(TOTSALEQTY),3) - round(SUM(INVQTY),3) AS NUMERIC(18,3)) <> 0  "
                    gconnection.getDataSet(sqlstring, "SubStoreQtyUnM")
                    If gdataset.Tables("SubStoreQtyUnM").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("SubStoreQtyUnM")
                        Lbl_Info.Text = "List of Kot Item Qty vs SubStoreConsumption Qty mismatch"
                        Cmd_MonthClose.Visible = False
                        'If gUserCategory <> "S" Then
                        '    Exit Sub
                        'End If
                        Exit Sub
                    End If
                End If

                If MODULETYPE = "Inventory" Then
                    sqlstring = "SELECT   c.itemcode, isnull( m.itemname,''),C.storecode,isnull(m.STOCKUOM,''),CAST(c.closingstock AS VARCHAR (10)),Cast(trndate as VARCHAR(20)) AS INV from closingqty c inner join INV_InventoryItemMaster m ON c.itemcode=M.itemcode where TRNS_SEQ in( select  max(TRNS_SEQ) from closingqty group by storecode,itemcode) and closingstock<0 AND month(CAST(CONVERT(VARCHAR(11),trndate,106) AS DATETIME)) = '" & Month(Dtp_FromDate.Value) & "'  ORDER BY STORECODE"
                    gconnection.getDataSet(sqlstring, "SubStoreQtyUnM")
                    If gdataset.Tables("SubStoreQtyUnM").Rows.Count > 0 Then
                        DataGridView1.DataSource = gdataset.Tables("SubStoreQtyUnM")
                        Lbl_Info.Text = "List of neagtive stockitem"
                        Cmd_MonthClose.Visible = False
                        'If gUserCategory <> "S" Then
                        '    Exit Sub
                        'End If
                        Exit Sub
                    End If
                End If

                Cmd_MonthClose.Visible = True



            End If




        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Dtp_FromDate_ValueChanged(sender As Object, e As EventArgs) Handles Dtp_FromDate.ValueChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
    Private Sub manualupdate()

        Dim sql As String
        Dim strrate As String
        Dim loccode As String = "M"
        Dim J As Integer

        '  sql = "SELECT itemcode from vw_inv_inventoryitemmaster_manualupdate order by itemcode"

        sql = "  SELECT distinct GITEMCODE as itemcode FROM (  SELECT KOTDETAILS,gitemcode,case when len(ISNULL((select top 1 L.STORECODE from POSITEMSTORELINK L where  D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE and ISNULL(L.STORECODE,'')<>'' ),poscode))>1 then ISNULL((select top 1 L.STORECODE from POSITEMSTORELINK L where  D.POSCODE = L.POS AND D.ITEMCODE = L.ITEMCODE and ISNULL(L.STORECODE,'')<>'' ),poscode) else POSCODE end  as STORECODE ,GUOM,QTY * gqty AS TOTSALEQTY,0 AS INVQTY FROM KOT_DET D,BOM_DET B  "
        sql = sql & " WHERE D.ITEMCODE = B.ITEMCODE AND D.UOM = B.ItemUOM AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' and isnull(b.void,'')<>'Y'  and d.ITEMCODE not in ('P03') AND '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' BETWEEN b.Startdate and isnull(b.endingdate,convert(varchar(11),getdate(),106)) "
        sql = sql & " And ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' "
        sql = sql & " UNION ALL  SELECT Trnno,itemcode,STORECODE,uom,0,QTY FROM CLOSINGQTY WHERE CAST(CONVERT(VARCHAR(11),TRNDATE,106) AS DATETIME) = '" & Format(Dtp_FromDate.Value, "dd-MMM-yyyy") & "' AND TTYPE = 'KOT' "
        sql = sql & " ) AS T GROUP BY STORECODE,gitemcode,KOTDETAILS,gUOM HAVING CAST(round(SUM(TOTSALEQTY),3) + round(SUM(INVQTY),3) AS NUMERIC(18,3)) <> 0  "

        gconnection.getDataSet(sql, "inv_inventoryitemmaster")
        If (gdataset.Tables("inv_inventoryitemmaster").Rows.Count > 0) Then

            'ProgressBar1.Maximum = gdataset.Tables("inv_inventoryitemmaster").Rows.Count + 1
            'Timer1.Enabled = True

            For J = 0 To gdataset.Tables("inv_inventoryitemmaster").Rows.Count - 1

                Call Randomize()
                vOutfile = Mid("WE" & (Rnd() * 800000000), 1, 10)
                vOutfile = Replace(vOutfile, ".", "")
                vOutfile = Replace(vOutfile, "+", "")

                Dim stockitemname As String
                stockitemname = Trim(gdataset.Tables("inv_inventoryitemmaster").Rows(J).Item("itemcode"))

                '                MsgBox(stockitemname)

                Dim items As String
                items = "'" + stockitemname + "'"
                Dim dtitem As New DataTable
                dtitem.Columns.Add("itemcode")

                dtitem.TableName = "TpItems"
                dtitem.Rows.Add(stockitemname)

                If Mid(UCase(gShortname), 1, 5) = "RSAOI" Or Mid(UCase(gShortname), 1, 3) = "RSI" Then
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), items, dtitem, "", "Q", vOutfile, loccode)

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), items, dtitem, "", "Q", vOutfile, loccode)
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If

                ' ProgressBar1.Value = ProgressBar1.Value + 1
            Next J
            'Timer1.Enabled = False
            'ProgressBar1.Value = 1

        End If


    End Sub

    Private Sub Btn_Rectify_Click(sender As Object, e As EventArgs) Handles Btn_Rectify.Click
        If MsgBox("Are you Sure to manual update for all items...", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            manualupdate()
            MsgBox("Stock Manual Updation Completed....")
        End If

    End Sub

    Private Sub Cmd_MonthClose_Click(sender As Object, e As EventArgs) Handles Cmd_MonthClose.Click
        Dim CloseDate As Date
        Dim sql(0) As String
        Try
            If BussinessType = "MONTHLY" Then
                CloseDate = New DateTime(Dtp_FromDate.Value.Year, Dtp_FromDate.Value.Month, 1).AddMonths(1).AddDays(-1)
                sqlstring = "select * from DAYENDSETUPMASTER where MONTH(BUSINESSDATE) = " & Month(Dtp_FromDate.Value) & " AND YEAR(BUSINESSDATE) = " & Year(Dtp_FromDate.Value) & " AND MODULENAME = 'INVENTORY' "
                gconnection.getDataSet(sqlstring, "CloseCheck")
                If gdataset.Tables("CloseCheck").Rows.Count > 0 Then
                    MessageBox.Show(MonthName(Month(CloseDate)) & " Month Already Closed, you Can't Processed Again")
                    Lbl_Info.Text = MonthName(Month(CloseDate)) & " Month Already Closed, you Can't Processed Again"
                    Cmd_MonthClose.Visible = False
                    Exit Sub
                End If
            ElseIf BussinessType = "DAILY" Then
                CloseDate = Format(Dtp_FromDate.Value, "dd-MMM-yyyy")
                sqlstring = "select * from DAYENDSETUPMASTER where CAST(CONVERT(VARCHAR(11),BUSINESSDATE,106) AS DATETIME) = '" & Format(CloseDate, "dd-MMM-yyyy") & "' AND MODULENAME = 'INVENTORY' "
                gconnection.getDataSet(sqlstring, "CloseCheck")
                If gdataset.Tables("CloseCheck").Rows.Count > 0 Then
                    MessageBox.Show("Selected Date Already Closed, you Can't Processed Again")
                    Lbl_Info.Text = "Selected Date Already Closed, you Can't Processed Again"
                    Cmd_MonthClose.Visible = False
                    Exit Sub
                End If
            Else
                MessageBox.Show("Setup Not Done,Please Set Process Type MOnthly or Daily")
                Exit Sub
            End If

            sql(0) = Nothing

            sqlstring = "Insert Into DAYENDSETUPMASTER(MODULENAME,BUSINESSDATE,ADDUSERID,ADDDATETIME) Values ("
            sqlstring = sqlstring & "  'INVENTORY','" & Format(CloseDate, "dd-MMM-yyyy") & "','" & gUsername & "',GetDate()) "
            ReDim Preserve sql(sql.Length)
            sql(sql.Length - 1) = sqlstring
            sqlstring = "select bdate from Businessdate"
            gconnection.getDataSet(sqlstring, "Businessdate")
            If gdataset.Tables("Businessdate").Rows.Count = 0 Then

                sqlstring = "insert into Businessdate values('" & gFinancialyearStart & "','" & gUsername & "',GetDate()) "

                gconnection.getDataSet(sqlstring, "insertBusinessdate")

            End If

            sqlstring = "Update Businessdate Set bdate = '" & Format(CloseDate, "dd-MMM-yyyy") & "',updateuser='" & gUsername & "',updatetime=getdate()"
            ReDim Preserve sql(sql.Length)
            sql(sql.Length - 1) = sqlstring
            gconnection.MoreTrans1(sql)
            MessageBox.Show("Selected Date Close Successfully")
            DataGridView1.DataSource = Nothing
            Lbl_Info.Text = ""
            Cmd_MonthClose.Visible = False
        Catch ex As Exception
            MessageBox.Show("PLEASE PRESS ENTER AGAIN" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub
End Class