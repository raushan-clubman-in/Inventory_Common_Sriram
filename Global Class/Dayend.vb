Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Public Class Dayend
    Dim VCONN As New GlobalClass
    Dim gconnection As New GlobalClass
    Dim SQL, sqlstring As String

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles IN_DAYEND.Click
        'SQL = " Exec [tp_subscriptionviewdoj] '" & Format(Dtp_billdate.Value, "dd-MMM-yyyy") & "','YEARLY','" & Format(CDate(gFinancalyearStarting), "dd-MMM-yyyy") & "','" & Format(CDate(gfinnyrend), "dd-MMM-yyyy") & "'"
        'VCONN.ExcuteStoreProcedure(SQL)
        Try
            sqlstring = " IF NOT EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME ='INVENTORYDAILYCOLLECTION')   BEGIN  CREATE TABLE [dbo].[INVENTORYDAILYCOLLECTION](	[MODULE] [varchar](11) NOT NULL,	[voucherno] [nvarchar](255) NULL,	[voucherdate] [datetime] NULL,	[vouchertype] [nvarchar](255) NULL,	[vouchercategory] [nvarchar](255) NULL,	[Accountcode] [nvarchar](255) NULL,	[ACCOUNTCODEDESC] [nvarchar](255) NULL,	[slcode] [nvarchar](255) NULL,	[SLDESC] [nvarchar](255) NULL,	[Creditdebit] [nvarchar](255) NULL,	[amount] [decimal](38, 2) NULL,	[description] [nvarchar](255) NULL,	[void] [nvarchar](255) NULL,	[adduserid] [nvarchar](255) NULL,	[Adddatetime] [datetime] NULL,	[CASHBANK] [nvarchar](255) NULL,	[PARTYNAME] [nvarchar](255) NULL,	[PARTY_NAME] [nvarchar](500) NULL,	[OPPACCOUNTCODE] [nvarchar](255) NULL,	[OPPSLCODE] [nvarchar](255) NULL,	[slcode1] [nvarchar](255) NULL,	[sldesc1] [nvarchar](255) NULL,	[debitslcode] [varchar](50) NOT NULL,	[POSTEDTOPMS] [varchar](1) NOT NULL,	[accpost] [varchar](1) NOT NULL) END "
            VCONN.dataOperation(6, sqlstring)
        Catch ex As Exception
        End Try
        Try
            sqlstring = " IF NOT EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME ='INVENTORYDAILYCOLLECTION_Log')   BEGIN   CREATE TABLE [dbo].[INVENTORYDAILYCOLLECTION_Log](	[MODULE] [varchar](11) NOT NULL,	[voucherno] [nvarchar](255) NULL,	[voucherdate] [datetime] NULL,	[vouchertype] [nvarchar](255) NULL,	[vouchercategory] [nvarchar](255) NULL,	[Accountcode] [nvarchar](255) NULL,	[ACCOUNTCODEDESC] [nvarchar](255) NULL,	[slcode] [nvarchar](255) NULL,	[SLDESC] [nvarchar](255) NULL,	[Creditdebit] [nvarchar](255) NULL,	[amount] [decimal](38, 2) NULL,	[description] [nvarchar](255) NULL,	[void] [nvarchar](255) NULL,	[adduserid] [nvarchar](255) NULL,	[Adddatetime] [datetime] NULL,	[CASHBANK] [nvarchar](255) NULL,	[PARTYNAME] [nvarchar](255) NULL,	[PARTY_NAME] [nvarchar](500) NULL,	[OPPACCOUNTCODE] [nvarchar](255) NULL,	[OPPSLCODE] [nvarchar](255) NULL,	[slcode1] [nvarchar](255) NULL,	[sldesc1] [nvarchar](255) NULL,	[debitslcode] [varchar](50) NOT NULL,	[POSTEDTOPMS] [varchar](1) NOT NULL,	[accpost] [varchar](1) NOT NULL) END "
            VCONN.dataOperation(6, sqlstring)
        Catch ex As Exception
        End Try
       

        SQL = "EXEC DAYENDINVENTORY '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "','" & gUsername & "'"
        VCONN.ExcuteStoreProcedure(SQL)
        SQL = "  SELECT MODULE,Accountcode,ACCOUNTCODEDESC AS REVENUEHEAD,CREDITDEBIT,SUM(AMOUNT) AS AMOUNT,voucherdate FROM INVENTORYDAILYCOLLECTION  WHERE CAST(CONVERT(VARCHAR(11),VOUCHERDATE,106)AS DATETIME)='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "'    GROUP BY MODULE,Accountcode,ACCOUNTCODEDESC,CREDITDEBIT,voucherdate  "
        VCONN.getDataSet(SQL, "MEMBERDAILYCOLLECTION")
        If gdataset.Tables("MEMBERDAILYCOLLECTION").Rows.Count > 0 Then
            DTPROCESSFINISH.Visible = True
            DTPROCESSFINISH.DataSource = Nothing
            DTPROCESSFINISH.DataSource = gdataset.Tables("MEMBERDAILYCOLLECTION")
            Button2.Visible = True
            Me.Button3.Visible = True
        End If
        DTPROCESSFINISH.Visible = True
        Button2.Visible = True
        Me.Button3.Visible = True
        chk_accode.Visible = True
        CheckBox2.Visible = True
        Dim i As Integer
        SQL = "  SELECT distinct Accountcode,ACCOUNTCODEDESC AS REVENUEHEAD FROM INVENTORYDAILYCOLLECTION  WHERE CAST(CONVERT(VARCHAR(11),VOUCHERDATE,106)AS DATETIME)='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "'    "
        VCONN.getDataSet(SQL, "achead")
        Me.chk_accode.Items.Clear()
        If gdataset.Tables("achead").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("achead").Rows.Count - 1
                Me.chk_accode.Items.Add(gdataset.Tables("achead").Rows(i).Item("REVENUEHEAD") & "-->>" & gdataset.Tables("achead").Rows(i).Item("ACCOUNTCODE"))
            Next

        End If
        Me.IN_DAYEND.Enabled = False

        MsgBox("process over")
    End Sub

    Private Sub Dayend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdrndoff.Visible = False
        Button2.Visible = False
        Me.Button3.Visible = False
        'End If
        chk_accode.Visible = False
        CheckBox2.Visible = False
        Try
            sqlstring = " IF NOT EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME ='dayendmodulesetup')   BEGIN create table dayendmodulesetup(sino integer,modulename varchar(50),closetype varchar(20),adduser varchar(20),adddatetime datetime)	END "
            VCONN.dataOperation(6, sqlstring)
        Catch ex As Exception

        End Try
        SQL = " SELECT *  FROM dayendmodulesetup "
        VCONN.getDataSet(SQL, "UNALLOCATED")
        If gdataset.Tables("UNALLOCATED").Rows.Count > 0 Then
        Else
            sqlstring = "insert into dayendmodulesetup(sino,modulename,closetype,adduser,adddatetime)values(1,'SMART CARD','MONTHLY','ADMIN',getdate())"
            VCONN.dataOperation(6, sqlstring)
            'sqlstring = "insert into dayendmodulesetup(sino,modulename,closetype,adduser,adddatetime)values(1,'LIBRARY','MONTHLY','ADMIN',getdate())"
            'VCONN.dataOperation(6, sqlstring)
            sqlstring = "insert into dayendmodulesetup(sino,modulename,closetype,adduser,adddatetime)values(2,'POS','MONTHLY','ADMIN',getdate())"
            VCONN.dataOperation(6, sqlstring)
            sqlstring = "insert into dayendmodulesetup(sino,modulename,closetype,adduser,adddatetime)values(3,'GOLF','MONTHLY','ADMIN',getdate())"
            VCONN.dataOperation(6, sqlstring)
            sqlstring = "insert into dayendmodulesetup(sino,modulename,closetype,adduser,adddatetime)values(4,'GUESTENTRY','MONTHLY','ADMIN',getdate())"
            VCONN.dataOperation(6, sqlstring)
            sqlstring = "insert into dayendmodulesetup(sino,modulename,closetype,adduser,adddatetime)values(5,'INVENTORY','MONTHLY','ADMIN',getdate())"
            VCONN.dataOperation(6, sqlstring)
            sqlstring = "insert into dayendmodulesetup(sino,modulename,closetype,adduser,adddatetime)values(6,'MEMBER','MONTHLY','ADMIN',getdate())"
            VCONN.dataOperation(6, sqlstring)
            sqlstring = "insert into dayendmodulesetup(sino,modulename,closetype,adduser,adddatetime)values(9,'ACCOUNTS','MONTHLY','ADMIN',getdate())"
            VCONN.dataOperation(6, sqlstring)
        End If
        Try
            sqlstring = " IF NOT EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME ='DAYENDSETUPMASTER')   BEGIN CREATE TABLE DAYENDSETUPMASTER (MODULENAME varchar(50),BUSINESSDATE datetime,ADDUSERID varchar(20),ADDDATETIME datetime)	END "
            VCONN.dataOperation(6, sqlstring)
        Catch ex As Exception

        End Try

        Try
            sqlstring = " IF NOT EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME ='DAYENDSETUPMASTER_LOG')   BEGIN CREATE TABLE DAYENDSETUPMASTER_LOG (MODULENAME varchar(50),BUSINESSDATE datetime,ADDUSERID varchar(20),ADDDATETIME datetime)	END "
            VCONN.dataOperation(6, sqlstring)
        Catch ex As Exception

        End Try

        sqlstring = "  Select * from dayendmodulesetup where modulename='INVENTORY'"
        VCONN.getDataSet(SQL, "billdate1")
        If gdataset.Tables("billdate1").Rows.Count > 0 Then
            If UCase(gdataset.Tables("billdate1").Rows(0).Item("closetype")) = "MONTHLY" Then
                SQL = "Select Case when (select count(*)FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY')>0 then    (select DATEADD(month, ((YEAR(dateadd(month,1,max(BUSINESSDATE))) - 1900) * 12) + MONTH(dateadd(month,1,max(BUSINESSDATE))), -1)FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') else (select case when (SELECT DATEADD(month, ((YEAR(dateadd(month,1,max(BUSINESSDATE))) - 1900) * 12) + MONTH(dateadd(month,1,max(BUSINESSDATE))), -1) FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY')>cast(convert(varchar(11),getdate(),106)as datetime) then  (select DATEADD(month, ((YEAR(dateadd(month,1,max(BUSINESSDATE))) - 1900) * 12) + MONTH(dateadd(month,1,max(BUSINESSDATE))), -1)FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') else (SELECT DATEADD(MONTH, DATEDIFF(MONTH, -1, CAST(CONVERT(VARCHAR(11),(ISNULL(DATEADD(day,1,MAX(BUSINESSDATE)),GETDATE())),106)AS DATETIME))-1, -1) FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') end ) end  as billdate"
                ''  SQL = "  Select Case when (select count(*)FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY')>0 then (select DateAdd(d, -Day(DateAdd(m, 1, DateAdd(Month, 2, MAX(BUSINESSDATE)))), DateAdd(Month, 2, MAX(BUSINESSDATE)))FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') else (select case when (select dateadd(d,-day(dateadd(m,1,dateadd(month,1,getdate()))),dateadd(month,1,getdate()))FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY')>cast(convert(varchar(11),getdate(),106)as datetime) then  (select dateadd(d,-day(dateadd(m,0,dateadd(month,1,getdate()))),dateadd(month,0,getdate()))FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') else (select dateadd(d,-day(dateadd(m,1,dateadd(month,1,getdate()))),dateadd(month,1,getdate()))FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') end ) end  as billdate "
                VCONN.getDataSet(SQL, "billdate")
                'SQL = " select (SELECT DATEADD(MONTH, DATEDIFF(MONTH, -1, CAST(CONVERT(VARCHAR(11),(ISNULL(DATEADD(day,1,MAX(BUSINESSDATE)),GETDATE())),106)AS DATETIME))-1, -1) FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') as billdate "
                'VCONN.getDataSet(SQL, "billdate")
                If gdataset.Tables("billdate").Rows.Count > 0 Then
                    Me.Dtp_billdate.Value = gdataset.Tables("billdate").Rows(0).Item(0)
                End If
            Else
                SQL = " select (SELECT CAST(CONVERT(VARCHAR(11),ISNULL(DATEADD(DAY,1,MAX(BUSINESSDATE)),GETDATE()),106)AS DATETIME) FROM DAYENDSETUPMASTER WHERE MODULENAME='INVENTORY') as billdate "
                VCONN.getDataSet(SQL, "billdate")
                If gdataset.Tables("billdate").Rows.Count > 0 Then
                    Me.Dtp_billdate.Value = gdataset.Tables("billdate").Rows(0).Item(0)
                End If
            End If
           
        Else
            MsgBox(" Dayend Module Setup is not done please do the setup")
            Exit Sub
        End If

        Me.DoubleBuffered = True
        Me.IN_DAYEND.Visible = False
        DTPROCESSFINISH.Visible = False

        Dim sqll As String
        sqll = "update ACCOUNTSTAGGINGFORITEM set ADJGLCODE=isnull(CONGLCODE,'') where isnull(ADJGLCODE,'')=''"
        VCONN.getDataSet(sqll, "ACCOUNTSTAGGING")

        sqll = "update ACCOUNTSTAGGINGFORITEM set DAMGLCODE=isnull(CONGLCODE,'') where isnull(DAMGLCODE,'')=''"
        VCONN.getDataSet(sqll, "ACCOUNTSTAGGING")


        If gAcPostingWise = "ITEM" Then
            sqlstring = "   SELECT   ITEMCODE, ITEMNAME FROM ACCOUNTSTAGGINGFORITEM where isnull(ACCOUNTCODE,'') not in(select accode from accountsglaccountmaster where isnull(freezeflag,'')<>'Y' and isnull(accode,'')<>'')"
            sqlstring = sqlstring & " union all   SELECT   ITEMCODE, ITEMNAME FROM ACCOUNTSTAGGINGFORITEM where isnull(CONGLCODE,'') not in(select accode from accountsglaccountmaster where isnull(freezeflag,'')<>'Y' and isnull(accode,'')<>'')"
            sqlstring = sqlstring & " union all   SELECT   ITEMCODE, ITEMNAME FROM ACCOUNTSTAGGINGFORITEM where isnull(ADJGLCODE,'') not in(select accode from accountsglaccountmaster where isnull(freezeflag,'')<>'Y' and isnull(accode,'')<>'')"
            sqlstring = sqlstring & " union all   SELECT   ITEMCODE, ITEMNAME FROM ACCOUNTSTAGGINGFORITEM where isnull(DAMGLCODE,'') not in(select accode from accountsglaccountmaster where isnull(freezeflag,'')<>'Y' and isnull(accode,'')<>'')"

        ElseIf gAcPostingWise = "CATEGORY" Then
            sqlstring = "   SELECT   CATEGORYCODE, CATEGORYDESC FROM ACCOUNTSTAGGINGFORCATEGORY where isnull(ACCOUNTCODE,'') not in(select accode from accountsglaccountmaster where isnull(freezeflag,'')<>'Y' and isnull(accode,'')<>'')and   tablename<>'INVENTORYITEMMASTER'"
            sqlstring = sqlstring & " union all   SELECT   CATEGORYCODE, CATEGORYDESC FROM ACCOUNTSTAGGINGFORCATEGORY where isnull(CONGLCODE,'') not in(select accode from accountsglaccountmaster where isnull(freezeflag,'')<>'Y' and isnull(accode,'')<>'')and   tablename<>'INVENTORYITEMMASTER'"
            sqlstring = sqlstring & " union all   SELECT   CATEGORYCODE, CATEGORYDESC FROM ACCOUNTSTAGGINGFORCATEGORY where isnull(ADJGLCODE,'') not in(select accode from accountsglaccountmaster where isnull(freezeflag,'')<>'Y' and isnull(accode,'')<>'')and   tablename<>'INVENTORYITEMMASTER'"
            sqlstring = sqlstring & " union all   SELECT   CATEGORYCODE, CATEGORYDESC FROM ACCOUNTSTAGGINGFORCATEGORY where isnull(DAMGLCODE,'') not in(select accode from accountsglaccountmaster where isnull(freezeflag,'')<>'Y' and isnull(accode,'')<>'')and   tablename<>'INVENTORYITEMMASTER'"
        Else
            sqlstring = "   SELECT   CODE, DESCRIPTION FROM AccountstaggingNEW where ACCOUNTCODE=''"
        End If
        VCONN.getDataSet(sqlstring, "ACCOUNTSTAGGING")
        If gdataset.Tables("ACCOUNTSTAGGING").Rows.Count > 0 Then
            MsgBox("SOME ACCOUNT TAGGING IS  MISSING")
            DTGRD.DataSource = Nothing
            DTGRD.DataSource = gdataset.Tables("ACCOUNTSTAGGING")
            Exit Sub
        End If
        Call STOCKVALUEUPDATE()
        sqlstring = "SELECT VOUCHERNO,VOUCHERTYPE,ACCAMOUNT,INVAMOUNT FROM UnMatchedVoucher  WHERE VOUCHERTYPE NOT IN('ISSUE') and VOUCHERNO not in(select trnno from closingqty  where trndate<=(select bdate from businessdate)) and voucherno<>'RET/000001/21-21'"
        VCONN.getDataSet(sqlstring, "CHECK")
        If gdataset.Tables("CHECK").Rows.Count > 0 Then
            MsgBox("SOME VOUCHERS VALUE AND ACCOUNTS VALUE NOT TALLYING")
            DTGRD.DataSource = Nothing
            DTGRD.DataSource = gdataset.Tables("CHECK")
            Exit Sub
        End If

        Dim CATEGORY(), ITEMNAME() As String
        Dim i As Integer

        sqlstring = " update storemaster set OPT='N' "
        VCONN.dataOperation(6, sqlstring, "storemaster")

        sqlstring = " DELETE  FROM  STORE  "
        VCONN.dataOperation(6, sqlstring, "STORE")


       
            sqlstring = " INSERT INTO STORE SELECT storecode from storemaster"
        VCONN.dataOperation(6, sqlstring, "STORE")

         
        sqlstring = " update storemaster set OPT='Y' "
        VCONN.dataOperation(6, sqlstring, "storemaster")


        sqlstring = " delete from consolidatestocksummary"
        VCONN.dataOperation(6, sqlstring, "stocksummary")
        sqlstring = " insert into consolidatestocksummary(itemcode,ITEMNAME) "
        sqlstring = sqlstring & " select I.itemcode,I.ITEMNAME "
        sqlstring = sqlstring & " from  INV_InventoryItemMaster I  "

        VCONN.dataOperation(6, sqlstring, "stocksummary")


        Dim FINYEARSTRT As Date
       
        FINYEARSTRT = CDate(gFinancialyearStart)



        sqlstring = " exec Cp_ConsolidatedStockSaleNew  '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "', '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "','" + Format(Dtp_billdate.Value, "dd/MMM/yyyy") + "'"
        If UCase(gShortname) = "BGC" Or UCase(gShortname) = "MLA" Then
            sqlstring = " exec Cp_Consolidate  '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "', '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "','" + Format(Dtp_billdate.Value, "dd/MMM/yyyy") + "'"
        End If
        VCONN.ExcuteStoreProcedure(sqlstring)

        ' sqlstring = " select (select top 1 categorydesc from ACCOUNTSTAGGINGFORCATEGORY b where a.CATEGORYCODE=b.CategoryCode) as category, (select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER' ) account,sum(clvalue) invvalue , (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')  accountsvalue ,sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where   a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "') as diff from stocksummary a   group by categorycode having sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where   a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')<>0"
        sqlstring = " select acdesc,account,sum(clvalue)invvalue, (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')  accountsvalue,sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "') as diff  from(select (select acdesc from accountsglaccountmaster where accode =(select top 1 accountcode from AccountstaggingForItem b where a.itemcode=b.ItemCode and   tablename<>'INVENTORYITEMMASTER' ) )acdesc, (select top 1 accountcode from AccountstaggingForItem b where a.itemcode=b.ItemCode and   tablename<>'INVENTORYITEMMASTER' ) account,clvalue from stocksummary a)t where account not in('0005690','0005612','0006123') group by acdesc,account having sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')<>0"
        VCONN.getDataSet(sqlstring, "SUBSCRIPTION")
        If gdataset.Tables("SUBSCRIPTION").Rows.Count > 0 Then
            MsgBox("STOCK ACCOUNT VS INVENTORY NOT TALLYING")
            DTGRD.DataSource = Nothing
            DTGRD.DataSource = gdataset.Tables("SUBSCRIPTION")
            cmdrndoff.Visible = True
            Exit Sub
        End If

        'If UCase(gShortname) = "SATC" Or UCase(gShortname) = "KEA" Then

        '    sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) --AND  ( closingqty<>'0')"

        'Else
        '    'If UCase(gShortname) = "BGC" Then
        '    '    sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY ,NEWUOM=UOM"

        '    '    gconnection.ExcuteStoreProcedure(sqlstring)
        '    '    sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY*25,NEWUOM='PEG' WHERE UOM='BOTTLE' AND ITEMCODE NOT IN (SELECT ITEMCODE FROM INV_InventoryItemMaster WHERE SUBGROUPCODE IN('51','174','75','70','OTHI','SAS','MW','SJ','74','SDR'))"
        '    '    gconnection.ExcuteStoreProcedure(sqlstring)

        '    '    sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY*0.08,NEWUOM='BOTTLE' WHERE UOM='PEG' AND  ITEMCODE NOT IN (SELECT ITEMCODE FROM INV_InventoryItemMaster WHERE SUBGROUPCODE IN('51','174','75','70','OTHI','SAS','MW','SJ','74','SDR'))"
        '    '    gconnection.ExcuteStoreProcedure(sqlstring)

        '    '    'sqlstring = "SELECT * FROM INV_INVENTORYITEMMASTER I INNER JOIN STOCKSUMMARY S ON I.ITEMCODE=S.ITEMCODE WHERE I.SUBGROUPCODE='51'"
        '    '    'gconnection.ExcuteStoreProcedure(sqlstring)
        '    'End If
        '    sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) AND  (opqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0'  or receiveqty<>'0' or saleqty<>'0')"

        'End If


        SQL = "select voucherno,isnull(sum(case when creditdebit='DEBIT' then amount else  0 end),0) as DRAMT,isnull(sum(case when creditdebit='CREDIT' then amount else  0 end),0) as CRAMT from journalentry where isnull(void,'')<>'Y' and VOUCHERNO  in(select trnno from closingqty) and    cast(convert(varchar(11),voucherdate,106)as datetime)<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "' group by voucherno having isnull(sum(case when creditdebit='DEBIT' then amount else  0 end),0) <>isnull(sum(case when creditdebit='CREDIT' then amount else  0 end),0) "
        'Select SUBSCODE,SUBSDESC,ISNULL(SUBSACCTIN,'') AS SUBSACCTIN FROM SUBSCRIPTIONMAST WHERE ISNULL(SUBSACCTIN,'') NOT IN(SELECT ACCODE FROM ACCOUNTSGLACCOUNTMASTER WHERE ISNULL(FREEZEFLAG,'')<>'Y')"
        VCONN.getDataSet(SQL, "SUBSCRIPTION")
        If gdataset.Tables("SUBSCRIPTION").Rows.Count > 0 Then
            MsgBox("SOME VOUCHERS CREDIT DEBIT NOT TALLYING")
            DTGRD.DataSource = Nothing
            DTGRD.DataSource = gdataset.Tables("SUBSCRIPTION")
            Exit Sub
        End If
        SQL = " select voucherno,accountcode,accountcodedesc from journalentry where isnull(void,'')<>'Y' and VOUCHERNO  in(select trnno from closingqty) and    cast(convert(varchar(11),voucherdate,106)as datetime)<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "' and isnull(accountcode,'') not in(select isnull(accode,'')  from accountsglaccountmaster )"
        VCONN.getDataSet(SQL, "SUBSCRIPTION")
        If gdataset.Tables("SUBSCRIPTION").Rows.Count > 0 Then
            MsgBox("SOME ACCOUNTCODE ARE NOT CORRECT")
            DTGRD.DataSource = Nothing
            DTGRD.DataSource = gdataset.Tables("SUBSCRIPTION")
            Exit Sub
        End If
        SQL = "select voucherno,accountcode,accountcodedesc,slcode,sldesc from journalentry a where isnull(void,'')<>'Y' and VOUCHERNO  in(select trnno from closingqty) and    cast(convert(varchar(11),voucherdate,106)as datetime)<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "'  and isnull(accountcode,'')+isnull(slcode,'') not in(select isnull(accode,'')+isnull(slcode,'')  from accountssubledgermaster b  )  and isnull(accountcode,'') in(select distinct isnull(accode,'')  from accountssubledgermaster b where isnull(accode,'')<>''  )"
        VCONN.getDataSet(SQL, "SUBSCRIPTION")
        If gdataset.Tables("SUBSCRIPTION").Rows.Count > 0 Then
            MsgBox("SOME SUBLEDGER ARE NOT CORRECT")
            DTGRD.DataSource = Nothing
            DTGRD.DataSource = gdataset.Tables("SUBSCRIPTION")
            Exit Sub
        End If
        'SQL = "  select voucherno,accountcode,accountcodedesc,slcode,sldesc,creditdebit,amount,PROFITCENTERCODE,PROFITCENTERDESC from journalentry a where isnull(void,'')<>'Y' and VOUCHERNO  in(select trnno from closingqty) and    cast(convert(varchar(11),voucherdate,106)as datetime)<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "'  and isnull(PROFITCENTERCODE,'') not in(select isnull(PROFITCENTERCODE,'')  from accountsprofitcentermaster b  )"
        'VCONN.getDataSet(SQL, "SUBSCRIPTION")
        'If gdataset.Tables("SUBSCRIPTION").Rows.Count > 0 Then
        '    MsgBox("SOME PROFITCENTERCODE ARE  EMPTY")
        '    DTGRD.DataSource = Nothing
        '    DTGRD.DataSource = gdataset.Tables("SUBSCRIPTION")
        '    Exit Sub
        'End If
        'SQL = " SELECT VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,ACCOUNTCODE,ACCOUNTCODEDESC,COSTCENTERCODE AS COSTCENTER,CREDITDEBIT,AMOUNT,DESCRIPTION  FROM JOURNALENTRY WHERE ISNULL(VOID,'')<>'Y' and VOUCHERNO  in(select trnno from closingqty) and    cast(convert(varchar(11),voucherdate,106)as datetime)<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "' and ISNULL(AUTHORISED,'')<>'Y' "
        'VCONN.getDataSet(SQL, "UNALLOCATED")
        'If gdataset.Tables("UNALLOCATED").Rows.Count > 0 Then
        '    MsgBox("SOME VOUCHERS ARE NOT AUTHORISED")
        '    Me.DTGRD.DataSource = Nothing
        '    Me.DTGRD.DataSource = gdataset.Tables("UNALLOCATED")
        '    Exit Sub
        'End If
        'SQL = " SELECT VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,ACCOUNTCODE,ACCOUNTCODEDESC,COSTCENTERCODE AS COSTCENTER,CREDITDEBIT,AMOUNT,DESCRIPTION  FROM JOURNALENTRY WHERE ISNULL(VOID,'')<>'Y' and    cast(convert(varchar(11),voucherdate,106)as datetime)<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "' AND ACCOUNTCODE IN(SELECT ACCODE FROM ACCOUNTSGLACCOUNTMASTER WHERE GROUPNAME IN(SELECT GROUPDESC FROM ACCOUNTSGROUPMASTER WHERE  ISNULL(FREEZEFLAG,'')<>'Y' AND CATEGORY ='INCOME/EXPENDITURE') )AND ISNULL(COSTCENTERCODE,'') NOT IN(SELECT COSTCENTERCODE FROM ACCOUNTSCOSTCENTERMASTER WHERE ISNULL(FREEZEFLAG,'')<>'Y' AND ISNULL(AUTHORISED,'')='Y' AND ISNULL(COSTCENTERCODE,'')<>'')"
        'VCONN.getDataSet(SQL, "UNALLOCATED")
        'If gdataset.Tables("UNALLOCATED").Rows.Count > 0 Then
        '    MsgBox("SOME COSTCENTER ARE  EMPTY")
        '    Me.DTGRD.DataSource = Nothing
        '    Me.DTGRD.DataSource = gdataset.Tables("UNALLOCATED")
        '    Exit Sub
        'End If
        'Dim i As Integer

        SQL = " SELECT *  FROM dayendmodulesetup where sino<(select sino from dayendmodulesetup where modulename='INVENTORY') order by sino "
        VCONN.getDataSet(SQL, "UNALLOCATED")
        If gdataset.Tables("UNALLOCATED").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("UNALLOCATED").Rows.Count - 1
                sqlstring = "  select * from  DAYENDSETUPMASTER where modulename in('" & Trim(gdataset.Tables("UNALLOCATED").Rows(i).Item("modulename")) & "') and   cast(convert(varchar(11),BUSINESSDATE,106)as datetime)= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "'"
                VCONN.getDataSet(sqlstring, "RENTmem")
                If gdataset.Tables("RENTmem").Rows.Count > 0 Then
                Else
                    MsgBox(Trim(gdataset.Tables("UNALLOCATED").Rows(i).Item("modulename")) & " DAY END NOT DONE PLEASE CHECK ", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Next
        End If


        'sqlstring = "  select * from DAYENDSETUPMASTER where modulename in('BANQUET') and   cast(convert(varchar(11),BUSINESSDATE,106)as datetime)= '" & Format(BUSSINESSDATE, "dd/MMM/yyyy") & "'"
        'VCONN.getDataSet(sqlstring, "RENTmem")
        'If gdataset.Tables("RENTmem").Rows.Count > 0 Then
        'Else
        '    MsgBox("BANQUET DAY END NOT DONE PLEASE CHECK ", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If
        'sqlstring = "  select * from DAYENDSETUPMASTER where modulename in('POS') and   cast(convert(varchar(11),BUSINESSDATE,106)as datetime)= '" & Format(BUSSINESSDATE, "dd/MMM/yyyy") & "'"
        'VCONN.getDataSet(sqlstring, "RENTmem")
        'If gdataset.Tables("RENTmem").Rows.Count > 0 Then
        'Else
        '    MsgBox("POS DAY END NOT DONE PLEASE CHECK ", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If
        'SQL = "Select EVENTCODE,EVENTNAME,ISNULL(ACCODE,'') AS ACHEAD FROM ev_events_hdr WHERE ISNULL(ACCODE,'') NOT IN(SELECT ACCODE FROM ACCOUNTSGLACCOUNTMASTER WHERE ISNULL(FREEZEFLAG,'')<>'Y')"
        'VCONN.getDataSet(SQL, "SUBSCRIPTION")
        'If gdataset.Tables("SUBSCRIPTION").Rows.Count > 0 Then
        '    MsgBox("SOME EVENT   NOT MAPPED WITH GL")
        '    DTGRD.DataSource = Nothing
        '    DTGRD.DataSource = gdataset.Tables("SUBSCRIPTION")
        '    Exit Sub
        'End If
        'SQL = "Select EVENTCODE,PREFIX,ISNULL(ACCODE,'') AS ACHEAD FROM EV_TABLE_MASTER WHERE ISNULL(ACCODE,'') NOT IN(SELECT ACCODE FROM ACCOUNTSGLACCOUNTMASTER WHERE ISNULL(FREEZEFLAG,'')<>'Y')"
        'VCONN.getDataSet(SQL, "SUBSCRIPTION")
        'If gdataset.Tables("SUBSCRIPTION").Rows.Count > 0 Then
        '    MsgBox("SOME EVENT   NOT MAPPED WITH GL")
        '    DTGRD.DataSource = Nothing
        '    DTGRD.DataSource = gdataset.Tables("SUBSCRIPTION")
        '    Exit Sub
        'End If
        'SQL = " Select CHARGECODE,CHARGEDESC,ISNULL(GLACCODE,'') AS ACHEAD FROM CHARGEMASTER WHERE ISNULL(GLACCODE,'') NOT IN(SELECT ACCODE FROM ACCOUNTSGLACCOUNTMASTER WHERE ISNULL(FREEZEFLAG,'')<>'Y')"
        'VCONN.getDataSet(SQL, "SUBSCRIPTION")
        'If gdataset.Tables("SUBSCRIPTION").Rows.Count > 0 Then
        '    MsgBox("SOME CHARGE CODES   NOT MAPPED WITH GL")
        '    DTGRD.DataSource = Nothing
        '    DTGRD.DataSource = gdataset.Tables("SUBSCRIPTION")
        '    Exit Sub
        'End If


        Me.IN_DAYEND.Visible = True
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub STOCKVALUEUPDATE()
        Try

            If Mid(UCase(gShortname), 1, 3) = "MGC" Then
                Call CALC_WEIGHTED()
            ElseIf Mid(UCase(gShortname), 1, 3) = "SAT" Then
                Call CALC_WEIGHTED()

            ElseIf Mid(UCase(gShortname), 1, 5) = "RSAOI" Or Mid(UCase(gShortname), 1, 3) = "RSI" Then
                Call CALC_WEIGHTEDRSI()
            Else
                Call CALC_WEIGHTED()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CALC_WEIGHTEDRSI()

        Dim SQLS, sqlstring, itemc, DocNO As String
        Dim Insert(0) As String
        Dim i, J As Integer
        Array.Clear(Insert, 0, Insert.Length)
        Try
            sqlstring = "DROP TABLE INV_WEIGHTED_TAB3"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SQLS = "SELECT * INTO INV_WEIGHTED_TAB3 FROM INV_WEIGHTED_VIEW1 WHERE 1<0 "
            gconnection.ExcuteStoreProcedure(SQLS)

            Dim bdate As String
            'If gdataset.Tables("Businessdate").Rows.Count > 0 Then
            '    bdate = Format(CDate(gdataset.Tables("Businessdate").Rows(0).Item("bdate")), "dd-MMM-yyyy")
            'End If


            bdate = gconnection.getvalue("  SELECT Convert(varchar(11), bdate, 106) As bdate FROM Businessdate")


            sqlstring = "ALTER TABLE INV_WEIGHTED_TAB3 ADD ROWID INTEGER IDENTITY(1,1)"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "ALTER TABLE INV_WEIGHTED_TAB3 DROP COLUMN  ADDDATE "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160302-151006] ON [dbo].[INV_WEIGHTED_TAB3](	[ITEMCODE] ASC,	[storecode] ASC,            [ROWID] Asc)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SQLS = " INSERT INTO INV_WEIGHTED_TAB3 (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE,UOM, QTY,  RATE,  AMOUNT, CLSSTOCK, TYPE, STORECODE,LOCATION, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY,RATEFLAG ) "

            SQLS = SQLS & "SELECT DOCDETAILS,UPPER(ITEMCODE) AS ITEMCODE, ITEMNAME, DOCDATE AS DOCDATE,UOM, ISNULL(QTY,0)AS QTY,ISNULL(RATE,0)AS RATE,ISNULL(AMOUNT,0) AMOUNT, CLSSTOCK, TYPE,UPPER(STORECODE)AS STORECODE,LOCATION, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY,ISNULL(RATEFLAG,'P')AS RATEFLAG  FROM INV_WEIGHTED_VIEW1 "

            SQLS = SQLS & " WHERE   LOCATION='M' "

            SQLS = SQLS & " ORDER BY STORECODE, ITEMCODE,"

            SQLS = SQLS & " CAST(DOCDATE AS DATE),PRIORITY,ADDDATE"

            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "ALTER TABLE INV_WEIGHTED_TAB3 ADD WEIGHTED_RATE NUMERIC(18,2)"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE =0"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET CLSSTOCK=(SELECT SUM(QTY) FROM INV_WEIGHTED_TAB3 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.storecode=INV_WEIGHTED_TAB3.storecode AND A.LOCATION=INV_WEIGHTED_TAB3.LOCATION AND STORECODE IN (SELECT STORECODE FROM STOREMASTER WHERE ISNULL(STORESTATUS,'')='M') AND A.ROWID<=INV_WEIGHTED_TAB3.ROWID )"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET LASTSTOCK=(SELECT ISNULL(SUM(QTY),0) FROM INV_WEIGHTED_TAB3 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.LOCATION=INV_WEIGHTED_TAB3.LOCATION AND A.storecode=INV_WEIGHTED_TAB3.storecode AND STORECODE IN (SELECT STORECODE FROM STOREMASTER WHERE ISNULL(STORESTATUS,'')='M') AND A.ROWID<INV_WEIGHTED_TAB3.ROWID )"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE  INV_WEIGHTED_TAB3 SET LASTRATE=RATE WHERE TYPE IN ('OPENING','GRN','ISSUE GRN') AND ISNULL(LASTRATE,0)=0"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET LASTRATE=ISNULL((SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM INV_WEIGHTED_TAB3 A "
            SQLS = SQLS & " WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND A.TYPE IN ('OPENING','GRN','ISSUE GRN') ORDER BY A.ROWID DESC),0) "
            SQLS = SQLS & " WHERE TYPE not IN ('OPENING','GRN','ISSUE GRN')"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE  INV_WEIGHTED_TAB3 SET LASTRATE=RATE WHERE TYPE IN ('OPENING','ISSUE GRN') AND ISNULL(LASTRATE,0)=0"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE = RATE WHERE TYPE IN ('OPENING','GRN','ISSUE GRN')"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE = RATE WHERE TYPE IN ('ADJUSTMENT') and qty>0"
            gconnection.ExcuteStoreProcedure(SQLS)
            If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                SQLS = " exec matchpendingallinv"
                gconnection.ExcuteStoreProcedure(SQLS)


                SQLS = " update INV_WEIGHTED_TAB3 set WEIGHTED_RATE= isnull((select (sum(a.AdjustedAmount*a.WEIGHTED_RATE)/sum(a.AdjustedAmount) ) from invfinalmatching a where a.voucherno=INV_WEIGHTED_TAB3.ROWID),0) where WEIGHTED_RATE=0"
                gconnection.ExcuteStoreProcedure(SQLS)
            End If

            sqlstring = "SELECT * FROM INV_WEIGHTED_TAB3 where qty<>0 ORDER BY ROWID"
            Dim SqlConnection As New SqlConnection
            SqlConnection.ConnectionString = gconnection.Getconnection()
            SqlConnection.Open()
            Dim DS As New DataSet
            Dim DA As New SqlDataAdapter(sqlstring, SqlConnection)

            Dim DT As New DataTable
            DA.Fill(DT)
            DT.TableName = "INV_WEIGHTED_TAB2"
            If DS.Tables.Contains("INV_WEIGHTED_TAB2") = True Then
                DS.Tables.Remove("INV_WEIGHTED_TAB2")
            End If
            DS.Tables.Add(DT)

            SqlConnection.Close()


            DS.Tables("INV_WEIGHTED_TAB2").Columns.Remove("TOSTORECODE")
            DS.Tables("INV_WEIGHTED_TAB2").Columns.Remove("LOCATION")

            SQLS = " IF   EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW') Begin drop table  INV_WEIGHTED_final_tabNEW  End "
            gconnection.ExcuteStoreProcedure(SQLS)

            If UCase(gShortname) = "JIC" Then
                SQLS = "IF not  EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW') Begin CREATE TABLE [dbo].[INV_WEIGHTED_final_tabNEW](	[DOCDETAILS] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[ITEMCODE] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[ITEMNAME] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[DOCDATE] [datetime] NULL,	[UOM] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[QTY] [numeric](18, 6) NULL,	[RATE] [numeric](18, 6) NULL,	[AMOUNT] [numeric](18, 6) NULL,	[CLSSTOCK] [numeric](18, 3) NULL,	[TYPE] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[STORECODE] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[CATEGORY] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[RATEFLAG] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[LASTSTOCK] [numeric](18, 6) NULL,	[LASTRATE] [numeric](18, 6) NULL,	[priority] [int] NULL,	[rowid] [int] NULL,	[WEIGHTED_RATE] [numeric](18, 6) NULL)     End"
                gconnection.dataOperation(6, SQLS, "AddC")

                SQLS = "CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160302-15100__06] ON INV_WEIGHTED_FINAL_TABNEW (	[ITEMCODE] ASC,DOCDETAILS )"
                gconnection.dataOperation(6, SQLS, "AddC")
            Else
                SQLS = "IF not  EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW') Begin CREATE TABLE [dbo].[INV_WEIGHTED_final_tabNEW](	[DOCDETAILS] [varchar](50) NULL,	[ITEMCODE] [varchar](50) NULL,	[ITEMNAME] [varchar](200) NULL,	[DOCDATE] [datetime] NULL,	[UOM] [varchar](20) NULL,	[QTY] [numeric](18, 6) NULL,	[RATE] [numeric](18, 6) NULL,	[AMOUNT] [numeric](18, 6) NULL,	[CLSSTOCK] [numeric](18, 6) NULL,	[TYPE] [varchar](50) NULL,	[STORECODE] [varchar](50) NULL,	[CATEGORY] [varchar](30) NULL,	[RATEFLAG] [varchar](10) NULL,	[LASTSTOCK] [numeric](18, 6) NULL,	[LASTRATE] [numeric](18, 6) NULL,	[priority] [int] NULL,	[rowid] [int] NULL,	[WEIGHTED_RATE] [numeric](18, 6) NULL)    End"
                gconnection.dataOperation(6, SQLS, "AddC")

                SQLS = "CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160302-15100__06] ON INV_WEIGHTED_FINAL_TABNEW (	[ITEMCODE] ASC,DOCDETAILS )"
                gconnection.dataOperation(6, SQLS, "AddC")
            End If
            Dim gc1 As New GlobalClass

            gc1.FillTableFromDataSet(DS.Tables("INV_WEIGHTED_TAB2"), "dbo.INV_WEIGHTED_final_tabNEW")


            SQLS = "Update INV_WEIGHTED_final_tabNEW Set WEIGHTED_RATE = ISnull((Select Top 1 Rate From stockissuedetail B  Where B.Itemcode = INV_WEIGHTED_final_tabNEW.ITEMCODE And     B.Opstorelocationcode = INV_WEIGHTED_final_tabNEW.STORECODE And B.Docdate<INV_WEIGHTED_final_tabNEW.DOCDATE    Order By Docdate Desc),0) where isnull(WEIGHTED_RATE,0) < 0    "
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " Update INV_WEIGHTED_final_tabNEW Set WEIGHTED_RATE = isnull((Select Top 1 Rate From INV_WEIGHTED_final_tabNEW B     Where B.Itemcode = INV_WEIGHTED_final_tabNEW.ITEMCODE  And B.Docdate<=INV_WEIGHTED_final_tabNEW.DOCDATE and rate>0    Order By Docdate Desc),0) where isnull(WEIGHTED_RATE,0) < 0 "
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW' AND  COLUMN_NAME = 'LPRate') Begin alter table INV_WEIGHTED_final_tabNEW add LPRate numeric (18,6) End"
            gconnection.dataOperation(6, SQLS, "AddC")

            SQLS = "update INV_WEIGHTED_final_tabNEW set LPRate = ((LASTRATE*LASTSTOCK) - (WEIGHTED_RATE*CLSSTOCK) )/ abs( QTY) where TYPE in ('CONSUME','ISSUE from','DAMAGE') and QTY<>0 "
            gconnection.ExcuteStoreProcedure(SQLS)


            SQLS = "update INV_WEIGHTED_final_tabNEW set LPRate =WEIGHTED_RATE , WEIGHTED_RATE = LPRate where TYPE in ('CONSUME','ISSUE from','DAMAGE') and RATEFLAG='P' "
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = " update STOCKISSUEDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKISSUEDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKISSUEDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKISSUEDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKISSUEDETAIL.Docdetails And A.ITEMCODE = STOCKISSUEDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='ISSUE FROM' "
            gconnection.ExcuteStoreProcedure(SQLS)



            ''---------------------------------------------------------------------------------------------------
            SQLS = " update STOCKDMGDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKDMGDETAIL.dmgqty*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKDMGDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKDMGDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKDMGDETAIL.Docdetails And A.ITEMCODE = STOCKDMGDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='DAMAGE' "
            gconnection.ExcuteStoreProcedure(SQLS)


            SQLS = " update STOCKTRANSFERDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKTRANSFERDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKTRANSFERDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKTRANSFERDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKTRANSFERDETAIL.Docdetails And A.ITEMCODE = STOCKTRANSFERDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='TRANSFER' "
            gconnection.ExcuteStoreProcedure(SQLS)


            SQLS = " update STOCKADJUSTDETAILS set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKADJUSTDETAILS.AdjustedStock*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKADJUSTDETAILS ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKADJUSTDETAILS.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKADJUSTDETAILS.Docdetails And A.ITEMCODE = STOCKADJUSTDETAILS.Itemcode"
            SQLS = SQLS & " AND A.TYPE='ADJUSTMENT' "
            gconnection.ExcuteStoreProcedure(SQLS)


            SQLS = " update SUBSTORECONSUMPTIONDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= SUBSTORECONSUMPTIONDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from SUBSTORECONSUMPTIONDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = SUBSTORECONSUMPTIONDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = SUBSTORECONSUMPTIONDETAIL.Docdetails And A.ITEMCODE = SUBSTORECONSUMPTIONDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='CONSUMPTION' "
            ' gconnection.ExcuteStoreProcedure(SQLS)


            SQLS = " update stockConsumption_1 set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= stockConsumption_1.consumption*(A.WEIGHTED_RATE*c.CONVVALUE) "
            SQLS = SQLS & " from stockConsumption_1 ,INVENTORY_TRANSCONVERSION C ,"
            SQLS = SQLS & " INV_WEIGHTED_final_tabNEW A WHERE C.BASEUOM = stockConsumption_1.uom And  C.TRANSUOM = a.uom And A.DOCDETAILS = "
            SQLS = SQLS & " stockConsumption_1.docno And A.ITEMCODE = stockConsumption_1.Itemcode AND A.TYPE='CONSUME' "

            gconnection.ExcuteStoreProcedure(SQLS)

            ''---------------------------------------------------------------------------------------------------


            'SQLS = " TRUNCATE TABLE CLOSINGQTY "
            'gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "delete from CLOSINGQTY where cast(trndate as date)>'" & bdate & "' "
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "update INV_WEIGHTED_final_tabNEW set LPRate =WEIGHTED_RATE , WEIGHTED_RATE = LPRate where TYPE in ('CONSUME','ISSUE from','DAMAGE') and RATEFLAG='P' "
            gconnection.ExcuteStoreProcedure(SQLS)



            SQLS = " INSERT INTO CLOSINGQTY(Trnno,Itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,priority,rate)"
            SQLS = SQLS & "SELECT DOCDETAILS AS Trnno,Itemcode,uom,storecode,DOCDATE Trndate,LASTSTOCK openningstock,ISNULL(LASTSTOCK,0)*ISNULL(LASTRATE,0) openningvalue,qty,ISNULL(CLSSTOCK,0) closingstock,"
            SQLS = SQLS & " ISNULL(CLSSTOCK,0)*WEIGHTED_RATE closingvalue,'N'batchyn,TYPE ttype,''batchno,priority,WEIGHTED_rate FROM INV_WEIGHTED_final_tabNEW where cast(docdate as date)>'" & bdate & "' ORDER BY ROWID "
            gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = " SELECT MAX(ROWID)+1 AS ROWID FROM INV_WEIGHTED_final_tabNEW"
            Dim LASTNO As Integer = gconnection.getvalue("SELECT (isnull(MAX(ROWID),0))+1  AS ROWID FROM INV_WEIGHTED_final_tabNEW")
            ' Next
            sqlstring = "DROP TABLE INV_WEIGHTED_TAB3"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SQLS = "SELECT * INTO INV_WEIGHTED_TAB3 FROM INV_WEIGHTED_VIEW1 WHERE 1<0 "
            gconnection.ExcuteStoreProcedure(SQLS)

            sqlstring = "ALTER TABLE INV_WEIGHTED_TAB3 ADD ROWID INTEGER IDENTITY(" & LASTNO & ",1)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "ALTER TABLE INV_WEIGHTED_TAB3 DROP COLUMN  ADDDATE "
            gconnection.ExcuteStoreProcedure(sqlstring)


            SQLS = " INSERT INTO INV_WEIGHTED_TAB3 (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE,UOM, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE,LOCATION, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY,RATEFLAG ) "

            SQLS = SQLS & "SELECT DOCDETAILS,UPPER(ITEMCODE) AS ITEMCODE, ITEMNAME, DOCDATE AS DOCDATE,UOM,ISNULL( QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(AMOUNT,0) AS AMOUNT, CLSSTOCK, TYPE,UPPER(STORECODE) AS STORECODE,LOCATION, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY,ISNULL(RATEFLAG,'P')AS RATEFLAG  FROM INV_WEIGHTED_VIEW1 "
            'If i = 0 Then
            SQLS = SQLS & " WHERE LOCATION='S'  "
            'Else
            '    SQLS = SQLS & " WHERE LOCATION='SAILING'"
            'End If
            SQLS = SQLS & " ORDER BY STORECODE, ITEMCODE,"

            SQLS = SQLS & " CAST(DOCDATE AS DATE), PRIORITY,ADDDATE"

            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "ALTER TABLE INV_WEIGHTED_TAB3 ADD WEIGHTED_RATE NUMERIC(18,6)"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE =0"
            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = " CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160302-151006] ON [dbo].[INV_WEIGHTED_TAB3](	[ITEMCODE] ASC,	[storecode] ASC,            [ROWID] Asc)"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "select  storecode from INV_WEIGHTED_TAB3 group by storecode"
            gconnection.getDataSet(sqlstring, "T_INV_WEIGHTED_TAB3")
            If gdataset.Tables("T_INV_WEIGHTED_TAB3").Rows.Count > 0 Then

                Dim STRITEMCODE As String

                For i = 1 To gdataset.Tables("T_INV_WEIGHTED_TAB3").Rows.Count

                    STRITEMCODE = Trim(gdataset.Tables("T_INV_WEIGHTED_TAB3").Rows(i - 1).Item("STORECODE"))

                    SQLS = " UPDATE INV_WEIGHTED_TAB3 SET CLSSTOCK=(SELECT SUM(QTY) FROM INV_WEIGHTED_TAB3 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.LOCATION=INV_WEIGHTED_TAB3.LOCATION AND A.storecode=INV_WEIGHTED_TAB3.storecode AND STORECODE IN ('" + STRITEMCODE + "') AND A.ROWID<=INV_WEIGHTED_TAB3.ROWID ) WHERE  STORECODE IN ( '" + STRITEMCODE + "')"
                    gconnection.ExcuteStoreProcedure(SQLS)

                    SQLS = " UPDATE INV_WEIGHTED_TAB3 SET LASTSTOCK=(SELECT ISNULL(SUM(QTY),0) FROM INV_WEIGHTED_TAB3 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.LOCATION=INV_WEIGHTED_TAB3.LOCATION AND A.storecode=INV_WEIGHTED_TAB3.storecode AND STORECODE IN ('" + STRITEMCODE + "') AND A.ROWID<INV_WEIGHTED_TAB3.ROWID ) WHERE STORECODE IN ('" + STRITEMCODE + "') "
                    gconnection.ExcuteStoreProcedure(SQLS)

                    SQLS = " UPDATE INV_WEIGHTED_TAB3 SET LASTRATE=(SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM INV_WEIGHTED_TAB3 A "
                    SQLS = SQLS & " WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND A.TYPE IN ('ISSUE TO','ISSUE GRN','OPENING','TRANSFER TO') ORDER BY A.ROWID DESC) "
                    SQLS = SQLS & " WHERE TYPE IN ('ISSUE TO','ISSUE GRN','TRANSFER','TRANSFER TO','CONSUME','ADJUSTMENT','DAMAGE','CONSUMPTION') AND STORECODE IN ('" + STRITEMCODE + "')"
                    gconnection.ExcuteStoreProcedure(SQLS)

                    SQLS = " UPDATE INV_WEIGHTED_TAB3 SET RATE=ISNULL((SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM INV_WEIGHTED_TAB3 A "
                    SQLS = SQLS & " WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND A.TYPE IN ('ISSUE TO','ISSUE GRN','OPENING','TRANSFER TO') ORDER BY A.ROWID DESC),0) "
                    SQLS = SQLS & " WHERE TYPE IN ('CONSUME','CONSUMPTION','TRANSFER','ADJUSTMENT') AND STORECODE IN ('" + STRITEMCODE + "')"
                    gconnection.ExcuteStoreProcedure(SQLS)
                Next
            End If
            SQLS = " UPDATE  INV_WEIGHTED_TAB3 SET LASTRATE=ISNULL(RATE,0) WHERE TYPE IN ('ISSUE TO','ISSUE GRN','OPENING','TRANSFER TO') AND ISNULL(LASTRATE,0)=0"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE = 0 "
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE = ISNULL(RATE,0) WHERE TYPE='OPENING'"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " update INV_WEIGHTED_TAB3 set  WEIGHTED_RATE = ISNULL(b.rate,0) from INV_WEIGHTED_TAB3 a,closingqty b where a.type='ISSUE TO' and b.ttype='ISSUE from' and a.itemcode=b.itemcode and a.docdetails=b.Trnno"
            gconnection.ExcuteStoreProcedure(SQLS)
            If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                SQLS = " exec matchpendingallinv"
                gconnection.ExcuteStoreProcedure(SQLS)
                SQLS = " update INV_WEIGHTED_TAB3 set WEIGHTED_RATE= isnull((select (sum(a.AdjustedAmount*a.WEIGHTED_RATE)/sum(a.AdjustedAmount) ) from invfinalmatching a where a.voucherno=INV_WEIGHTED_TAB3.ROWID),0) where WEIGHTED_RATE=0"
                gconnection.ExcuteStoreProcedure(SQLS)
            End If

            sqlstring = "SELECT * FROM INV_WEIGHTED_TAB3 ORDER BY ROWID"
            'Dim SqlConnection As New SqlConnection
            SqlConnection.ConnectionString = gconnection.Getconnection()
            SqlConnection.Open()
            Dim DS1 As New DataSet
            Dim DA1 As New SqlDataAdapter(sqlstring, SqlConnection)

            Dim DT1 As New DataTable
            DA1.Fill(DT1)
            DT1.TableName = "INV_WEIGHTED_TAB2"
            If DS1.Tables.Contains("INV_WEIGHTED_TAB2") = True Then
                DS1.Tables.Remove("INV_WEIGHTED_TAB2")
            End If
            DS1.Tables.Add(DT1)

            SqlConnection.Close()

            DS1.Tables("INV_WEIGHTED_TAB2").Columns.Remove("TOSTORECODE")
            DS1.Tables("INV_WEIGHTED_TAB2").Columns.Remove("LOCATION")
            DS1.Tables("INV_WEIGHTED_TAB2").Columns.Remove("amount")

            SQLS = "IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW' AND  COLUMN_NAME = 'LPRate') Begin alter table INV_WEIGHTED_final_tabNEW drop column  LPRate End"
            gconnection.dataOperation(6, SQLS, "AddC")

            SQLS = "IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW' AND  COLUMN_NAME = 'amount') Begin alter table INV_WEIGHTED_final_tabNEW drop column  amount End"
            gconnection.dataOperation(6, SQLS, "AddC")


            SQLS = " truncate table INV_WEIGHTED_final_tabNEW      "
            gconnection.ExcuteStoreProcedure(SQLS)

            Dim gc As New GlobalClass

            gc.FillTableFromDataSet(DS1.Tables("INV_WEIGHTED_TAB2"), "dbo.INV_WEIGHTED_final_tabNEW")

            SQLS = "Update INV_WEIGHTED_final_tabNEW Set WEIGHTED_RATE = ISnull((Select Top 1 Rate From stockissuedetail B  Where B.Itemcode = INV_WEIGHTED_final_tabNEW.ITEMCODE And     B.Opstorelocationcode = INV_WEIGHTED_final_tabNEW.STORECODE And B.Docdate<INV_WEIGHTED_final_tabNEW.DOCDATE    Order By Docdate Desc),0) where isnull(WEIGHTED_RATE,0) < 0    "
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " Update INV_WEIGHTED_final_tabNEW Set WEIGHTED_RATE = isnull((Select Top 1 Rate From INV_WEIGHTED_final_tabNEW B     Where B.Itemcode = INV_WEIGHTED_final_tabNEW.ITEMCODE  And B.Docdate<=INV_WEIGHTED_final_tabNEW.DOCDATE and rate>0    Order By Docdate Desc),0) where isnull(WEIGHTED_RATE,0) < 0 "
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "update INV_WEIGHTED_final_tabNEW set LASTRATE= n.lastrate , WEIGHTED_RATE=n.WEIGHTED_RATE from  INV_WEIGHTED_final_tabNEW , INV_WEIGHTED_TAB3 n where n.ITEMCODE= INV_WEIGHTED_final_tabNEW.ITEMCODE and n.storecode=INV_WEIGHTED_final_tabNEW.STORECODE and n.DOCDETAILS=INV_WEIGHTED_final_tabNEW.DOCDETAILS and INV_WEIGHTED_final_tabNEW.itemcode+INV_WEIGHTED_final_tabNEW.STORECODE in  (select distinct ITEMCODE+storecode from INV_WEIGHTED_TAB3 where CLSSTOCK<0 )"
            gconnection.ExcuteStoreProcedure(SQLS)


            SQLS = " update STOCKDMGDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKDMGDETAIL.dmgqty*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKDMGDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKDMGDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKDMGDETAIL.Docdetails And A.ITEMCODE = STOCKDMGDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='DAMAGE' "
            gconnection.ExcuteStoreProcedure(SQLS)


            SQLS = " update STOCKTRANSFERDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKTRANSFERDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKTRANSFERDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKTRANSFERDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKTRANSFERDETAIL.Docdetails And A.ITEMCODE = STOCKTRANSFERDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='TRANSFER' "
            gconnection.ExcuteStoreProcedure(SQLS)


            SQLS = " update STOCKADJUSTDETAILS set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKADJUSTDETAILS.AdjustedStock*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKADJUSTDETAILS ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKADJUSTDETAILS.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKADJUSTDETAILS.Docdetails And A.ITEMCODE = STOCKADJUSTDETAILS.Itemcode"
            SQLS = SQLS & " AND A.TYPE='ADJUSTMENT' "
            gconnection.ExcuteStoreProcedure(SQLS)

            If gShortname <> "FNCC" Then
                SQLS = " update SUBSTORECONSUMPTIONDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= SUBSTORECONSUMPTIONDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from SUBSTORECONSUMPTIONDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
                SQLS = SQLS & " WHERE C.BASEUOM = SUBSTORECONSUMPTIONDETAIL.uom And"
                SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = SUBSTORECONSUMPTIONDETAIL.Docdetails And A.ITEMCODE = SUBSTORECONSUMPTIONDETAIL.Itemcode"
                SQLS = SQLS & " AND A.TYPE='CONSUMPTION' "
                gconnection.ExcuteStoreProcedure(SQLS)
            End If







            SQLS = " update stockConsumption_1 set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= stockConsumption_1.consumption*(A.WEIGHTED_RATE*c.CONVVALUE) "
            SQLS = SQLS & " from stockConsumption_1 ,INVENTORY_TRANSCONVERSION C ,"
            SQLS = SQLS & " INV_WEIGHTED_final_tabNEW A WHERE C.BASEUOM = stockConsumption_1.uom And  C.TRANSUOM = a.uom And A.DOCDETAILS = "
            SQLS = SQLS & " stockConsumption_1.docno And A.ITEMCODE = stockConsumption_1.Itemcode AND A.TYPE='CONSUME' "

            gconnection.ExcuteStoreProcedure(SQLS)


            sqlstring = "delete from INV_WEIGHTED_final_tabNEW where CATEGORY='' "
            gconnection.ExcuteStoreProcedure(sqlstring)



            SQLS = " INSERT INTO CLOSINGQTY(Trnno,Itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,priority,rate)"
            SQLS = SQLS & "SELECT DOCDETAILS AS Trnno,Itemcode,uom,storecode,DOCDATE Trndate,LASTSTOCK openningstock,ISNULL(LASTSTOCK,0)*ISNULL(LASTRATE,0) openningvalue,qty,ISNULL(CLSSTOCK,0) closingstock,"
            SQLS = SQLS & " ISNULL(CLSSTOCK,0)*WEIGHTED_RATE closingvalue,'N'batchyn,TYPE ttype,''batchno,priority,WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW where cast(docdate as date)>'" & bdate & "' ORDER BY ROWID "
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "update CLOSINGQTY set ttype='RECEIEVE' where ttype='TRANSFER TO'"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = "update CLOSINGQTY set ttype='OPENNING',trnno='OPENING' where ttype='OPENING'"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = "update CLOSINGQTY set ttype='RECEIEVE' where ttypE IN ('ISSUE TO','ISSUE GRN')"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = "update CLOSINGQTY set ttype='ISSUE' where ttype='ISSUE from'"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = "update CLOSINGQTY set ttype='KOT' where ttype='CONSUMPTION'"
            gconnection.ExcuteStoreProcedure(SQLS)

            If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                Dim fromdate, todate As String
                fromdate = gconnection.getvalue("  SELECT convert(varchar(11),dateadd(day,1,CLOSEDATE),106) as fromdate FROM ACCTCLOSE")
                todate = Format(DateTime.Now(), "dd-MMM-yyyy")
                SQLS = "  exec PROC_JOURNAL_POSPOSTconsumption '" & fromdate & "','" & todate & "'"
                gconnection.ExcuteStoreProcedure(SQLS)
            End If

            Call MGC_P()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Public Function CALC_WEIGHTED()
        Dim SQLS, sqlstring, itemc, DocNO As String
        Dim Insert(0) As String
        Dim i, J As Integer
        Array.Clear(Insert, 0, Insert.Length)
        Try
            'Dim CNT As Integer
            'CNT = 2
            'For J = 0 To CNT - 1

            'sqlstring = " insert into inv_InventoryOpenningstock( itemcode,    storecode,    uom,    minqty,    maxqty,    reorder,    openningqty ,    openningvalue,    closingqty ,    closingvalue,    void,"
            'sqlstring = sqlstring & " AddDate,    addUSER,    UPDATEUSER,    UPDATEdate,    voiduser,    voiddate,    TRNS_SEQ,    fyear)"
            'sqlstring = sqlstring & " select itemcode,storecode,uom,0,0,0,0,0,0,0,'N',getdate(),'ADMIN','ADMIN',"
            'sqlstring = sqlstring & " GETDATE(),'','',0,'01/apr/2016' from  closingqty  where   itemcode+storecode NOT IN (SELECT itemcode+storecode FROM inv_InventoryOpenningstock WHERE ISNULL(void,'')<>'Y')"
            'gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_TAB3') Begin SELECT * INTO INV_WEIGHTED_TAB3 FROM INV_WEIGHTED_VIEW1 WHERE 1<0  End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'closingqty_one') Begin SELECT * INTO closingqty_one FROM closingqty  End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "DROP TABLE closingqty_one"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SQLS = "SELECT * INTO closingqty_one FROM closingqty "
            gconnection.ExcuteStoreProcedure(SQLS)



            sqlstring = "DROP TABLE INV_WEIGHTED_TAB3"
            gconnection.ExcuteStoreProcedure(sqlstring)

            'sqlstring = "Select  Convert(varchar(11), bdate, 106) As fromdate FROM Businessdate "
            'gconnection.getDataSet(sqlstring, "Businessdate")
            Dim bdate As String
            'If gdataset.Tables("Businessdate").Rows.Count > 0 Then
            '    bdate = Format(CDate(gdataset.Tables("Businessdate").Rows(0).Item("bdate")), "dd-MMM-yyyy")
            'End If


            bdate = gconnection.getvalue("  SELECT Convert(varchar(11), bdate, 106) As bdate FROM Businessdate")




            SQLS = "SELECT * INTO INV_WEIGHTED_TAB3 FROM INV_WEIGHTED_VIEW1 WHERE 1<0 "
            gconnection.ExcuteStoreProcedure(SQLS)

            sqlstring = "ALTER TABLE INV_WEIGHTED_TAB3 ADD ROWID INTEGER IDENTITY(1,1)"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "ALTER TABLE INV_WEIGHTED_TAB3 DROP COLUMN  ADDDATE "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160302-151006] ON [dbo].[INV_WEIGHTED_TAB3](	[ITEMCODE] ASC,	[storecode] ASC,            [ROWID] Asc)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SQLS = " INSERT INTO INV_WEIGHTED_TAB3 (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE,UOM, QTY,  RATE,  AMOUNT, CLSSTOCK, TYPE, STORECODE,LOCATION, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY,RATEFLAG ) "

            SQLS = SQLS & "SELECT DOCDETAILS,UPPER(ITEMCODE) AS ITEMCODE, ITEMNAME, DOCDATE AS DOCDATE,UOM, ISNULL(QTY,0)AS QTY,ISNULL(RATE,0)AS RATE,ISNULL(AMOUNT,0) AMOUNT, CLSSTOCK, TYPE,UPPER(STORECODE)AS STORECODE,LOCATION, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY,ISNULL(RATEFLAG,'P')AS RATEFLAG  FROM INV_WEIGHTED_VIEW1  "
            'If i = 0 Then
            SQLS = SQLS & " WHERE   LOCATION='M'  "
            'Else
            '    SQLS = SQLS & " WHERE LOCATION='SAILING'"
            'End If
            SQLS = SQLS & " ORDER BY STORECODE, ITEMCODE,"

            SQLS = SQLS & " CAST(DOCDATE AS DATE),PRIORITY,ADDDATE"

            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "ALTER TABLE INV_WEIGHTED_TAB3 ADD WEIGHTED_RATE NUMERIC(18,6)"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE =0"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET CLSSTOCK=(SELECT SUM(QTY) FROM INV_WEIGHTED_TAB3 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.storecode=INV_WEIGHTED_TAB3.storecode AND A.LOCATION=INV_WEIGHTED_TAB3.LOCATION AND STORECODE IN (SELECT STORECODE FROM STOREMASTER WHERE ISNULL(STORESTATUS,'')='M') AND A.ROWID<=INV_WEIGHTED_TAB3.ROWID )"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET LASTSTOCK=(SELECT ISNULL(SUM(QTY),0) FROM INV_WEIGHTED_TAB3 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.LOCATION=INV_WEIGHTED_TAB3.LOCATION AND A.storecode=INV_WEIGHTED_TAB3.storecode AND STORECODE IN (SELECT STORECODE FROM STOREMASTER WHERE ISNULL(STORESTATUS,'')='M') AND A.ROWID<INV_WEIGHTED_TAB3.ROWID )"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE  INV_WEIGHTED_TAB3 SET LASTRATE=RATE WHERE TYPE IN ('OPENING','GRN','ISSUE GRN') AND ISNULL(LASTRATE,0)=0"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET LASTRATE=(SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM INV_WEIGHTED_TAB3 A "
            SQLS = SQLS & " WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND A.TYPE IN ('OPENING','GRN','ISSUE GRN') ORDER BY A.ROWID DESC) "
            SQLS = SQLS & " WHERE TYPE IN ('OPENING','GRN','ISSUE GRN')"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE  INV_WEIGHTED_TAB3 SET LASTRATE=RATE WHERE TYPE IN ('OPENING','ISSUE GRN') AND ISNULL(LASTRATE,0)=0"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE = RATE WHERE TYPE='OPENING'"
            gconnection.ExcuteStoreProcedure(SQLS)

            'sqlstring = "SELECT * FROM INV_WEIGHTED_TAB2 WHERE STORECODE='MNS' ORDER BY ROWID"
            sqlstring = "SELECT * FROM INV_WEIGHTED_TAB3 ORDER BY ROWID"
            Dim SqlConnection As New SqlConnection
            SqlConnection.ConnectionString = gconnection.Getconnection()
            SqlConnection.Open()
            Dim DS As New DataSet
            Dim DA As New SqlDataAdapter(sqlstring, SqlConnection)

            Dim DT As New DataTable
            DA.Fill(DT)
            DT.TableName = "INV_WEIGHTED_TAB2"
            If DS.Tables.Contains("INV_WEIGHTED_TAB2") = True Then
                DS.Tables.Remove("INV_WEIGHTED_TAB2")
            End If
            DS.Tables.Add(DT)

            SqlConnection.Close()

            If DS.Tables("INV_WEIGHTED_TAB2").Rows.Count > 0 Then
                Dim ITEMCODE, location, RATEFLAG As String
                Dim RATE, LPRATE As Double
                Dim QTY As Double
                location = DS.Tables("INV_WEIGHTED_TAB2").Rows(0).Item("location")
                ITEMCODE = DS.Tables("INV_WEIGHTED_TAB2").Rows(0).Item("ITEMCODE")
                RATEFLAG = DS.Tables("INV_WEIGHTED_TAB2").Rows(0).Item("RATEFLAG")

                For i = 0 To DS.Tables("INV_WEIGHTED_TAB2").Rows.Count - 1
                    RATEFLAG = UCase(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATEFLAG"))
                    DocNO = UCase(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE"))

                    If DocNO = "0139" Then
                        gState = gState
                    End If

                    If RATEFLAG = "W" Then

                        If i = 34 Then
                            gState = gState
                        End If
                        ' For i = 0 To DS.Tables("INV_WEIGHTED_TAB2").Rows.Count - 1
                        If location <> DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("location") Then
                            QTY = 0
                            RATE = 0
                            location = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("location")
                            If ITEMCODE <> DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE") Then
                                QTY = 0
                                RATE = 0
                                ITEMCODE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE")

                                QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then
                                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = ((DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                End If
                            Else
                                QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then
                                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = ((DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                        '  DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                End If
                            End If
                        Else
                            QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                            If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                            ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then
                                If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = ((DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                Else
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = 0
                                End If
                            Else
                                DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                            End If
                        End If
                    Else
                        If location <> DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("location") Then
                            QTY = 0
                            RATE = 0
                            LPRATE = 0
                            location = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("location")
                            If ITEMCODE <> DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE") Then
                                QTY = 0
                                RATE = 0
                                LPRATE = 0
                                ITEMCODE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE")

                                QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then
                                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ADJUSTMENT" Then
                                        RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")
                                    End If
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE


                                End If
                            Else
                                QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then
                                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                        '  DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ADJUSTMENT" Then
                                        RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")
                                    End If
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE


                                End If
                            End If
                        Else
                            QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                            If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")
                                LPRATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                            ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then
                                If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") < 0 Then
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        If gShortname = "CPC" Or gShortname = "RCL" Or gShortname = "HGA" Then
                                            RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        Else
                                            RATE = ((DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                        End If
                                        ' 

                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                        LPRATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                    End If
                                ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                Else
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = 0
                                End If
                            ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "CONSUME" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE from" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "DAMAGE" Then
                                DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                RATE = LPRATE
                                DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                            Else
                                DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE

                                DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                            End If
                        End If
                    End If
                Next

            End If

            DS.Tables("INV_WEIGHTED_TAB2").Columns.Remove("TOSTORECODE")
            DS.Tables("INV_WEIGHTED_TAB2").Columns.Remove("LOCATION")
            'DS.Tables("INV_WEIGHTED_TAB2").Columns.Remove("RATEFLAG")


            'gconnection.openConnection()
            'gcommand = New SqlCommand("Update_RateNEW", gconnection.Myconn)
            'gcommand.CommandTimeout = 1000000000
            'gcommand.CommandType = CommandType.StoredProcedure
            'gcommand.Parameters.AddWithValue("@INV_WEIGHTED_TAB2", DS.Tables("INV_WEIGHTED_TAB2"))
            'gcommand.ExecuteNonQuery()
            'gconnection.closeConnection()


            SQLS = " IF   EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW') Begin drop table  INV_WEIGHTED_final_tabNEW  End "
            gconnection.ExcuteStoreProcedure(SQLS)
            '  dIM  CL AS New   

            If UCase(gShortname) = "JIC" Then
                SQLS = "IF not  EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW') Begin CREATE TABLE [dbo].[INV_WEIGHTED_final_tabNEW](	[DOCDETAILS] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[ITEMCODE] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[ITEMNAME] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[DOCDATE] [datetime] NULL,	[UOM] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[QTY] [numeric](18, 6) NULL,	[RATE] [numeric](18, 6) NULL,	[AMOUNT] [numeric](18, 6) NULL,	[CLSSTOCK] [numeric](18, 3) NULL,	[TYPE] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[STORECODE] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[CATEGORY] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[RATEFLAG] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,	[LASTSTOCK] [numeric](18, 6) NULL,	[LASTRATE] [numeric](18, 6) NULL,	[priority] [int] NULL,	[rowid] [int] NULL,	[WEIGHTED_RATE] [numeric](18, 6) NULL)     End"
                gconnection.dataOperation(6, SQLS, "AddC")

                SQLS = "CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160302-15100__06] ON INV_WEIGHTED_FINAL_TABNEW (	[ITEMCODE] ASC,DOCDETAILS )"
                gconnection.dataOperation(6, SQLS, "AddC")
            Else
                SQLS = "IF not  EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW') Begin CREATE TABLE [dbo].[INV_WEIGHTED_final_tabNEW](	[DOCDETAILS] [varchar](50) NULL,	[ITEMCODE] [varchar](50) NULL,	[ITEMNAME] [varchar](200) NULL,	[DOCDATE] [datetime] NULL,	[UOM] [varchar](20) NULL,	[QTY] [numeric](18, 6) NULL,	[RATE] [numeric](18, 6) NULL,	[AMOUNT] [numeric](18, 6) NULL,	[CLSSTOCK] [numeric](18, 6) NULL,	[TYPE] [varchar](50) NULL,	[STORECODE] [varchar](50) NULL,	[CATEGORY] [varchar](30) NULL,	[RATEFLAG] [varchar](10) NULL,	[LASTSTOCK] [numeric](18, 6) NULL,	[LASTRATE] [numeric](18, 6) NULL,	[priority] [int] NULL,	[rowid] [int] NULL,	[WEIGHTED_RATE] [numeric](18, 6) NULL)    End"
                gconnection.dataOperation(6, SQLS, "AddC")

                SQLS = "CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160302-15100__06] ON INV_WEIGHTED_FINAL_TABNEW (	[ITEMCODE] ASC,DOCDETAILS )"
                gconnection.dataOperation(6, SQLS, "AddC")
            End If
            Dim gc1 As New GlobalClass

            gc1.FillTableFromDataSet(DS.Tables("INV_WEIGHTED_TAB2"), "dbo.INV_WEIGHTED_final_tabNEW")




            'SQLS = "UPDATE INV_WEIGHTED_TAB2 SET WEIGHTED_RATE=A.WEIGHTED_RATE  FROM  INV_WEIGHTED_TAB3 A WHERE A.ROWID=INV_WEIGHTED_TAB2.ROWID"
            'gconnection.ExcuteStoreProcedure(SQLS)

            ''*********UPDATION IN THE FINAL TABLE FOR THE REPORT ***********************
            'SQLS = "DELETE FROM INV_WEIGHTED_FINAL_TAB  "
            ''****** select the itemcode from the grid ************
            'itemc = ""

            'gconnection.ExcuteStoreProcedure(SQLS)
            'SQLS = "INSERT INTO INV_WEIGHTED_FINAL_TAB (DOCDETAILS,ITEMCODE,ITEMNAME,DOCDATE,QTY,RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,"
            'SQLS = SQLS & " LASTSTOCK,LASTRATE,WEIGHTED_RATE)  "
            'SQLS = SQLS & " SELECT DOCDETAILS,ITEMCODE,ITEMNAME,DOCDATE,QTY,RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,"
            'SQLS = SQLS & " LASTSTOCK,LASTRATE,WEIGHTED_RATE FROM INV_WEIGHTED_TAB2"
            'gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "Update INV_WEIGHTED_final_tabNEW Set WEIGHTED_RATE = ISnull((Select Top 1 Rate From stockissuedetail B  Where B.Itemcode = INV_WEIGHTED_final_tabNEW.ITEMCODE And     B.Opstorelocationcode = INV_WEIGHTED_final_tabNEW.STORECODE And B.Docdate<INV_WEIGHTED_final_tabNEW.DOCDATE    Order By Docdate Desc),0) where isnull(WEIGHTED_RATE,0) < 0    "
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " Update INV_WEIGHTED_final_tabNEW Set WEIGHTED_RATE = isnull((Select Top 1 Rate From INV_WEIGHTED_final_tabNEW B     Where B.Itemcode = INV_WEIGHTED_final_tabNEW.ITEMCODE  And B.Docdate<=INV_WEIGHTED_final_tabNEW.DOCDATE and rate>0    Order By Docdate Desc),0) where isnull(WEIGHTED_RATE,0) < 0 "
            gconnection.ExcuteStoreProcedure(SQLS)
            '**********updation of purchase rate in inventory itemmaster **********"
            'SQLS = "update inventoryitemmaster set purchaserate=a.weighted_rate, salerate=a.weighted_rate FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE  A.ITEMCODE=inventoryitemmaster.Itemcode and TYPE in ('GRN') AND DOCDETAILS IN (SELECT MAX(DOCDETAILS) FROM INV_WEIGHTED_final_tabNEW "
            'SQLS = SQLS & " WHERE TYPE IN ('GRN') ) "
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "update inventoryitemmaster set purchaserate='0.001', salerate='0.001' FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE  A.ITEMCODE=inventoryitemmaster.Itemcode and TYPE in ('GRN') AND DOCDETAILS IN "
            'SQLS = SQLS & " (SELECT MAX(DOCDETAILS) FROM INV_WEIGHTED_final_tabNEW "
            'SQLS = SQLS & " WHERE TYPE IN ('GRN') ) And A.WEIGHTED_RATE<=0"
            'gconnection.ExcuteStoreProcedure(SQLS)


            ''***** UPDATION OF THE TRANSACTION AFTER CALCULATING WEIGHTED RATE **********************
            'SQLS = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE FROM' "
            'gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW' AND  COLUMN_NAME = 'LPRate') Begin alter table INV_WEIGHTED_final_tabNEW add LPRate numeric (18,6) End"
            gconnection.dataOperation(6, SQLS, "AddC")

            SQLS = "update INV_WEIGHTED_final_tabNEW set LPRate = ((LASTRATE*LASTSTOCK) - (WEIGHTED_RATE*CLSSTOCK) )/ abs( QTY) where TYPE in ('CONSUME','ISSUE from','DAMAGE') and QTY<>0 "
            gconnection.ExcuteStoreProcedure(SQLS)


            SQLS = "update INV_WEIGHTED_final_tabNEW set LPRate =WEIGHTED_RATE , WEIGHTED_RATE = LPRate where TYPE in ('CONSUME','ISSUE from','DAMAGE') and RATEFLAG='P' "
            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table STOCKISSUEDETAIL disable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SQLS = " update STOCKISSUEDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKISSUEDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKISSUEDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKISSUEDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKISSUEDETAIL.Docdetails And A.ITEMCODE = STOCKISSUEDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='ISSUE FROM' "
            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table STOCKISSUEDETAIL ENABLE trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)


            'SQLS = "UPDATE STOCKDMGDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKDMGDETAIL.dmgqty*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKDMGDETAIL.Docdetails AND A.ITEMCODE=STOCKDMGDETAIL.Itemcode AND A.TYPE='DAMAGE' "
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "UPDATE STOCKTRANSFERDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKTRANSFERDETAIL.QTY*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKTRANSFERDETAIL.Docdetails AND STOCKTRANSFERDETAIL.TOSTORECODE=A.STORECODE AND A.ITEMCODE=STOCKTRANSFERDETAIL.Itemcode AND A.TYPE='TRANSFER' "
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "UPDATE STOCKADJUSTDETAILS SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKADJUSTDETAILS.AdjustedStock*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKADJUSTDETAILS.Docdetails AND A.ITEMCODE=STOCKADJUSTDETAILS.Itemcode AND A.TYPE='ADJUSTMENT' "
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "UPDATE SUBSTORECONSUMPTIONDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= SUBSTORECONSUMPTIONDETAIL.QTY*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=SUBSTORECONSUMPTIONDETAIL.Docdetails AND A.ITEMCODE=SUBSTORECONSUMPTIONDETAIL.Itemcode AND A.TYPE='CONSUMPTION' "
            'gconnection.ExcuteStoreProcedure(SQLS)


            ''---------------------------------------------------------------------------------------------------
            sqlstring = "alter table STOCKDMGDETAIL disable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SQLS = " update STOCKDMGDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKDMGDETAIL.dmgqty*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKDMGDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKDMGDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKDMGDETAIL.Docdetails And A.ITEMCODE = STOCKDMGDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='DAMAGE' "
            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table STOCKDMGDETAIL enable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "alter table STOCKTRANSFERDETAIL disable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)

            SQLS = " update STOCKTRANSFERDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKTRANSFERDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKTRANSFERDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKTRANSFERDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKTRANSFERDETAIL.Docdetails And A.ITEMCODE = STOCKTRANSFERDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='TRANSFER' "
            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table STOCKTRANSFERDETAIL ENABLE trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)


            sqlstring = "alter table STOCKADJUSTDETAILS disable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)


            SQLS = " update STOCKADJUSTDETAILS set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKADJUSTDETAILS.AdjustedStock*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKADJUSTDETAILS ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKADJUSTDETAILS.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKADJUSTDETAILS.Docdetails And A.ITEMCODE = STOCKADJUSTDETAILS.Itemcode"
            SQLS = SQLS & " AND A.TYPE='ADJUSTMENT' "
            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table STOCKADJUSTDETAILS ENABLE trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "alter table SUBSTORECONSUMPTIONDETAIL disable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)


            SQLS = " update SUBSTORECONSUMPTIONDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= SUBSTORECONSUMPTIONDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from SUBSTORECONSUMPTIONDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = SUBSTORECONSUMPTIONDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = SUBSTORECONSUMPTIONDETAIL.Docdetails And A.ITEMCODE = SUBSTORECONSUMPTIONDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='CONSUMPTION' "
            ' gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table SUBSTORECONSUMPTIONDETAIL ENABLE trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)


            sqlstring = "alter table stockConsumption_1 disable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)


            SQLS = " update stockConsumption_1 set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= stockConsumption_1.consumption*(A.WEIGHTED_RATE*c.CONVVALUE) "
            SQLS = SQLS & " from stockConsumption_1 ,INVENTORY_TRANSCONVERSION C ,"
            SQLS = SQLS & " INV_WEIGHTED_final_tabNEW A WHERE C.BASEUOM = stockConsumption_1.uom And  C.TRANSUOM = a.uom And A.DOCDETAILS = "
            SQLS = SQLS & " stockConsumption_1.docno And A.ITEMCODE = stockConsumption_1.Itemcode AND A.TYPE='CONSUME' "

            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table stockConsumption_1 ENABLE trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)

            ''---------------------------------------------------------------------------------------------------


            'SQLS = "UPDATE stockConsumption_1 SET Rate=A.WEIGHTED_RATE , AMOUNT= ISNULL(stockConsumption_1.consumption,0)*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=stockConsumption_1.DOCNO AND A.ITEMCODE=stockConsumption_1.Itemcode AND A.TYPE='CONSUME' "
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "update inventory_indentdet set rate =a.rate, AMOUNT= inventory_indentdet.QTY*A.rate FROM indentweightedrateupdate A "
            'SQLS = SQLS & "WHERE A.indentno = inventory_indentdet.INDENT_NO And A.ITEMCODE = inventory_indentdet.Itemcode"
            'gconnection.ExcuteStoreProcedure(SQLS)
            'For z = 1 To ssgrid.DataRowCnt
            '    ssgrid.Col = 1
            '    ssgrid.Row = z
            '    itemc = ssgrid.Text
            '    sqlstring = "Update Inventoryitemmaster set PurchaseRate=(select Round(SUM(Amount)/sum(qty),2) from INV_WEIGHTED_VIEW2 where ITEMCODE='" & itemc & "')where ITEMCODE='" & itemc & "'"
            '    gconnection.ExcuteStoreProcedure(sqlstring)
            '    sqlstring = "Update Inventoryitemmaster set SaleRate=PurchaseRate where ITEMCODE='" & itemc & "'"
            '    gconnection.ExcuteStoreProcedure(sqlstring)
            'Next
            'sqlstring = " select '' as  DOCDETAILS,	ITEMCODE,ITEMCODE as	ITEMname,Trndate as	docdate,	UOM,	closingstock as qty	,RATE,QTY	*RATE as 	AMOUNT,	0 as clsstock,	'OPENING' as type	,storecode,storecode as 	tostorecode, case when  (select storestatus from storemaster s where closingqty.storecode=s.Storecode)='M' then 'M' else 'S' end as location,'' as	CATEGORY,'' as	RATEFLAG,0 as 	LASTSTOCK,rate as 	LASTRATE,0 as 	PRIORITY,trndate as ADDDATE  from closingqty where TRNS_SEQ in( select  max(TRNS_SEQ) from closingqty where cast(trndate as Date)< ( select cast( bdate as Date) from Businessdate) group by itemcode,storecode)"
            'gconnection.getDataSet(sqlstring, "inv_linksetup")

            'If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
            '    SQLS = " DELETE FROM CLOSINGQTY WHERE cast(trndate as Date)> (select cast( bdate as Date) from Businessdate)"
            '    gconnection.ExcuteStoreProcedure(SQLS)
            'Else
            '    SQLS = " TRUNCATE TABLE CLOSINGQTY "
            '    gconnection.ExcuteStoreProcedure(SQLS)

            'End If

            'sqlstring = "delete from INV_WEIGHTED_final_tabNEW where CATEGORY='' "
            'gconnection.ExcuteStoreProcedure(sqlstring)


            'SQLS = " IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'CLOSINGQTY_temp') Begin drop table  CLOSINGQTY_temp  End "
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = " TRUNCATE TABLE CLOSINGQTY "
            'gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "delete from CLOSINGQTY where cast(trndate as date)>'" & bdate & "' "
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "update INV_WEIGHTED_final_tabNEW set LPRate =WEIGHTED_RATE , WEIGHTED_RATE = LPRate where TYPE in ('CONSUME','ISSUE from','DAMAGE') and RATEFLAG='P' "
            gconnection.ExcuteStoreProcedure(SQLS)



            SQLS = " INSERT INTO CLOSINGQTY(Trnno,Itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,priority,rate)"
            SQLS = SQLS & "SELECT DOCDETAILS AS Trnno,Itemcode,uom,storecode,DOCDATE Trndate,LASTSTOCK openningstock,ISNULL(LASTSTOCK,0)*ISNULL(LASTRATE,0) openningvalue,qty,ISNULL(CLSSTOCK,0) closingstock,"
            SQLS = SQLS & " ISNULL(CLSSTOCK,0)*WEIGHTED_RATE closingvalue,'N'batchyn,TYPE ttype,''batchno,priority,WEIGHTED_rate FROM INV_WEIGHTED_final_tabNEW  where cast(docdate as date)>'" & bdate & "' ORDER BY ROWID "
            gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = " SELECT MAX(ROWID)+1 AS ROWID FROM INV_WEIGHTED_final_tabNEW"
            Dim LASTNO As Integer = gconnection.getvalue("SELECT (isnull(MAX(ROWID),0))+1  AS ROWID FROM INV_WEIGHTED_final_tabNEW")
            ' Next
            sqlstring = "DROP TABLE INV_WEIGHTED_TAB3"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SQLS = "SELECT * INTO INV_WEIGHTED_TAB3 FROM INV_WEIGHTED_VIEW1 WHERE 1<0 "
            gconnection.ExcuteStoreProcedure(SQLS)

            sqlstring = "ALTER TABLE INV_WEIGHTED_TAB3 ADD ROWID INTEGER IDENTITY(" & LASTNO & ",1)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "ALTER TABLE INV_WEIGHTED_TAB3 DROP COLUMN  ADDDATE "
            gconnection.ExcuteStoreProcedure(sqlstring)


            SQLS = " INSERT INTO INV_WEIGHTED_TAB3 (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE,UOM, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE,LOCATION, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY,RATEFLAG ) "

            SQLS = SQLS & "SELECT DOCDETAILS,UPPER(ITEMCODE) AS ITEMCODE, ITEMNAME, DOCDATE AS DOCDATE,UOM,ISNULL( QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(AMOUNT,0) AS AMOUNT, CLSSTOCK, TYPE,UPPER(STORECODE) AS STORECODE,LOCATION, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY,ISNULL(RATEFLAG,'P')AS RATEFLAG  FROM INV_WEIGHTED_VIEW1 "
            'If i = 0 Then
            SQLS = SQLS & " WHERE LOCATION='S'"
            'Else
            '    SQLS = SQLS & " WHERE LOCATION='SAILING'"
            'End If
            SQLS = SQLS & " ORDER BY STORECODE, ITEMCODE,"

            SQLS = SQLS & " CAST(DOCDATE AS DATE), PRIORITY,ADDDATE"

            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "ALTER TABLE INV_WEIGHTED_TAB3 ADD WEIGHTED_RATE NUMERIC(18,6)"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE =0"
            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = " CREATE NONCLUSTERED INDEX [NonClusteredIndex-20160302-151006] ON [dbo].[INV_WEIGHTED_TAB3](	[ITEMCODE] ASC,	[storecode] ASC,            [ROWID] Asc)"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "select  storecode from INV_WEIGHTED_TAB3 group by storecode"
            gconnection.getDataSet(sqlstring, "T_INV_WEIGHTED_TAB3")
            If gdataset.Tables("T_INV_WEIGHTED_TAB3").Rows.Count > 0 Then

                Dim STRITEMCODE As String

                For i = 1 To gdataset.Tables("T_INV_WEIGHTED_TAB3").Rows.Count

                    STRITEMCODE = Trim(gdataset.Tables("T_INV_WEIGHTED_TAB3").Rows(i - 1).Item("STORECODE"))

                    SQLS = " UPDATE INV_WEIGHTED_TAB3 SET CLSSTOCK=(SELECT SUM(QTY) FROM INV_WEIGHTED_TAB3 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.LOCATION=INV_WEIGHTED_TAB3.LOCATION AND A.storecode=INV_WEIGHTED_TAB3.storecode AND STORECODE IN ('" + STRITEMCODE + "') AND A.ROWID<=INV_WEIGHTED_TAB3.ROWID ) WHERE  STORECODE IN ( '" + STRITEMCODE + "')"
                    gconnection.ExcuteStoreProcedure(SQLS)

                    SQLS = " UPDATE INV_WEIGHTED_TAB3 SET LASTSTOCK=(SELECT ISNULL(SUM(QTY),0) FROM INV_WEIGHTED_TAB3 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.LOCATION=INV_WEIGHTED_TAB3.LOCATION AND A.storecode=INV_WEIGHTED_TAB3.storecode AND STORECODE IN ('" + STRITEMCODE + "') AND A.ROWID<INV_WEIGHTED_TAB3.ROWID ) WHERE STORECODE IN ('" + STRITEMCODE + "') "
                    gconnection.ExcuteStoreProcedure(SQLS)

                    SQLS = " UPDATE INV_WEIGHTED_TAB3 SET LASTRATE=(SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM INV_WEIGHTED_TAB3 A "
                    SQLS = SQLS & " WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND A.TYPE IN ('ISSUE TO','ISSUE GRN','OPENING','TRANSFER TO') ORDER BY A.ROWID DESC) "
                    SQLS = SQLS & " WHERE TYPE IN ('ISSUE TO','ISSUE GRN','TRANSFER','TRANSFER TO','CONSUME','ADJUSTMENT','DAMAGE','CONSUMPTION') AND STORECODE IN ('" + STRITEMCODE + "')"
                    gconnection.ExcuteStoreProcedure(SQLS)

                    SQLS = " UPDATE INV_WEIGHTED_TAB3 SET RATE=ISNULL((SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM INV_WEIGHTED_TAB3 A "
                    SQLS = SQLS & " WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND A.TYPE IN ('ISSUE TO','ISSUE GRN','OPENING','TRANSFER TO') ORDER BY A.ROWID DESC),0) "
                    SQLS = SQLS & " WHERE TYPE IN ('CONSUME','CONSUMPTION','TRANSFER','ADJUSTMENT') AND STORECODE IN ('" + STRITEMCODE + "')"
                    gconnection.ExcuteStoreProcedure(SQLS)
                    'Try

                    'Catch ex As Exception

                    'End Try
                    'Dim valid As Integer
                    'valid = 0
                    'Do Until valid = 1
                    '    SQLS = "  Select distinct docdate from INV_WEIGHTED_TAB3 where TYPE IN ('CONSUME','TRANSFER') AND STORECODE IN ('" + STRITEMCODE + "')and isnull(qty,0)<>0 and ( abs( CAST(WEIGHTED_RATE AS NUMERIC(18,5))- CAST(isnull((SELECT (SUM(isnull(RATE,0)*isnull(qty,0)))/(sum(isnull(qty,0))) FROM INV_WEIGHTED_TAB3 A   WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE and A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND STORECODE IN ('" + STRITEMCODE + "') 	  and isnull(qty,0)<>0 having sum(isnull(qty,0))<>0),0) AS NUMERIC(18,5)))>.00001 or ( abs(CAST( rate AS NUMERIC(18,5))- CAST(isnull((SELECT (SUM(isnull(RATE,0)*isnull(qty,0)))/(sum(isnull(qty,0))) FROM INV_WEIGHTED_TAB3 A   WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE and	 A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND STORECODE IN ('" + STRITEMCODE + "') 	and isnull(qty,0)<>0 having sum(isnull(qty,0))<>0) ,0) AS numeric(18,5))))>.00001) and itemcode in (select itemcode from  INV_WEIGHTED_TAB3 where CLSSTOCK>=0 AND STORECODE IN ('" + STRITEMCODE + "') ) order by docdate "
                    '    gconnection.getDataSet(SQLS, "ttttval1")
                    '    If gdataset.Tables("ttttval1").Rows.Count > 0 Then
                    '        For J = 0 To gdataset.Tables("ttttval1").Rows.Count - 1
                    '            SQLS = "  UPDATE INV_WEIGHTED_TAB3 SET rate=cast(isnull((SELECT SUM(isnull(RATE,0)*isnull(qty,0))/sum(isnull(qty,0)) FROM INV_WEIGHTED_TAB3 A "
                    '            SQLS = SQLS & "  WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE   AND A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND STORECODE IN ('" + STRITEMCODE + "') and isnull(qty,0)<>0  having sum(isnull(qty,0))<>0 ),rate) as numeric(18,5)) ,WEIGHTED_RATE= cast( isnull((SELECT SUM(isnull(RATE,0)*isnull(qty,0))/sum(isnull(qty,0)) FROM INV_WEIGHTED_TAB3 A "
                    '            SQLS = SQLS & "  WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE   AND A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND STORECODE IN ('" + STRITEMCODE + "') and isnull(qty,0)<>0  having sum(isnull(qty,0))<>0 ),rate) as numeric(18,5)) "
                    '            SQLS = SQLS & " WHERE TYPE IN ('CONSUME','CONSUMPTION','TRANSFER') AND STORECODE IN ('" + STRITEMCODE + "')and isnull(qty,0)<>0 and ABS(cast( WEIGHTED_RATE as numeric(18,5))- cast( isnull( (SELECT (SUM(isnull(RATE,0)*isnull(qty,0)))/(sum(isnull(qty,0))) FROM INV_WEIGHTED_TAB3 A   WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE and A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND STORECODE IN ('" + STRITEMCODE + "') 	  and isnull(qty,0)<>0  having sum(isnull(qty,0))<>0),rate) as numeric(18,5)))>.00001 or ABS(cast(rate as numeric(18,5))- cast( isnull( (SELECT (SUM(isnull(RATE,0)*isnull(qty,0)))/(sum(isnull(qty,0))) FROM INV_WEIGHTED_TAB3 A   WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE and A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND STORECODE IN ('" + STRITEMCODE + "') 	  and isnull(qty,0)<>0 having sum(isnull(qty,0))<>0 ) ,rate) as numeric(18,5)))>.00001  and cast(convert(varchar(11),docdate,106)as datetime)='" & Format(gdataset.Tables("ttttval1").Rows(J).Item("docdate"), "dd-MMM-yyyy") & "' and itemcode in (select itemcode from  INV_WEIGHTED_TAB3 where CLSSTOCK>=0 AND STORECODE IN ('" + STRITEMCODE + "')) "
                    '            gconnection4BGP.ExcuteStoreProcedure(SQLS)
                    '        Next
                    '    End If

                    '    SQLS = "select * from INV_WEIGHTED_TAB3 where TYPE IN ('CONSUME','TRANSFER') AND STORECODE IN ('" + STRITEMCODE + "') and isnull(qty,0)<>0  and abs(CAST(rate AS NUMERIC(18,5))- CAST( (SELECT (SUM(isnull(RATE,0)*isnull(qty,0)))/(sum(isnull(qty,0))) FROM INV_WEIGHTED_TAB3 A   WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE and	 A.storecode=INV_WEIGHTED_TAB3.storecode AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND STORECODE IN ('" + STRITEMCODE + "') and itemcode in (select itemcode from  INV_WEIGHTED_TAB3 where CLSSTOCK>=0 AND STORECODE IN ('" + STRITEMCODE + "')) and isnull(qty,0)<>0 having sum(isnull(qty,0))<>0	) AS numeric(18,5)))>.00001"
                    '    gconnection.getDataSet(SQLS, "ttttval")
                    '    If gdataset.Tables("ttttval").Rows.Count > 0 Then
                    '        valid = 0
                    '    Else
                    '        valid = 1
                    '    End If
                    'Loop



                Next
            End If




            SQLS = " UPDATE  INV_WEIGHTED_TAB3 SET LASTRATE=ISNULL(RATE,0) WHERE TYPE IN ('ISSUE TO','ISSUE GRN','OPENING','TRANSFER TO') AND ISNULL(LASTRATE,0)=0"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE = ISNULL(RATE,0) WHERE TYPE='OPENING'"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE = ISNULL(RATE,0) WHERE TYPE IN('CONSUME','CONSUMPTION','ADJUSTMENT','ISSUE TO','TRANSFER') AND ISNULL(WEIGHTED_RATE,0)=0 "
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = " UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE = ISNULL(lastrate,0) , rate =ISNULL(lastrate,0) WHERE TYPE IN('TRANSFER TO') AND ISNULL(WEIGHTED_RATE,0)=0 and lastrate<>0 "
            gconnection.ExcuteStoreProcedure(SQLS)
            'sqlstring = "SELECT * FROM INV_WEIGHTED_TAB2 WHERE STORECODE='MNS' ORDER BY ROWID"
            sqlstring = "SELECT * FROM INV_WEIGHTED_TAB3 ORDER BY ROWID"
            'Dim SqlConnection As New SqlConnection
            SqlConnection.ConnectionString = gconnection.Getconnection()
            SqlConnection.Open()
            Dim DS1 As New DataSet
            Dim DA1 As New SqlDataAdapter(sqlstring, SqlConnection)

            Dim DT1 As New DataTable
            DA1.Fill(DT1)
            DT1.TableName = "INV_WEIGHTED_TAB2"
            If DS1.Tables.Contains("INV_WEIGHTED_TAB2") = True Then
                DS1.Tables.Remove("INV_WEIGHTED_TAB2")
            End If
            DS1.Tables.Add(DT1)

            SqlConnection.Close()

            If DS1.Tables("INV_WEIGHTED_TAB2").Rows.Count > 0 Then
                Dim ITEMCODE, LOCATION, RATEFLAG As String
                Dim RATE, LPRATE As Double
                Dim QTY As Double
                LOCATION = DS1.Tables("INV_WEIGHTED_TAB2").Rows(0).Item("STORECODE")
                ITEMCODE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(0).Item("ITEMCODE")
                RATEFLAG = DS1.Tables("INV_WEIGHTED_TAB2").Rows(0).Item("RATEFLAG")
                For i = 0 To DS1.Tables("INV_WEIGHTED_TAB2").Rows.Count - 1
                    RATEFLAG = UCase(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATEFLAG"))
                    DocNO = UCase(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE"))
                    If DocNO = "504" Then
                        gState = gState
                    End If
                    If RATEFLAG = "W" Then


                        If LOCATION <> DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("STORECODE") Then
                            LOCATION = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("STORECODE")
                            QTY = 0
                            RATE = 0
                            ITEMCODE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("STORECODE")

                            If ITEMCODE <> DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE") Then
                                QTY = 0
                                RATE = 0
                                ITEMCODE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE")

                                QTY = QTY + DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = Format(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"), "0.000")

                                ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "ISSUE TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") > 0 Then
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        'RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then

                                            RATE = Format((((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE)) + ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("amount") / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty")) * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty"))) / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"), "0.000")
                                        Else
                                            RATE = Format(((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK")), "0.000")
                                        End If
                                        ' RATE = ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                    ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    ' DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    ' DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE TO" Then
                                        If i <> 0 Then
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")
                                        Else
                                            'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE")
                                            'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                            RATE = Format(((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK")), "0.000")
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                        End If
                                    Else
                                        If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "CONSUME1" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "TRANSFER1" Then

                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")

                                        Else
                                            If i <> 0 Then
                                                DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")
                                                DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                            Else
                                                'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE")
                                                DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                            End If
                                        End If

                                    End If



                                End If
                            Else
                                QTY = QTY + DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = Format(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"), "0.000")

                                ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "ISSUE TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") > 0 Then
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        'RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then

                                            RATE = Format((((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE)) + ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("amount") / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty")) * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty"))) / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"), "0.000")
                                        Else
                                            RATE = Format(((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK")), "0.000")
                                        End If
                                        ' RATE = ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                    ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "CONSUME1" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "TRANSFER1" Then

                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")

                                    Else
                                        If i <> 0 Then
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                        Else
                                            'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE")
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                        End If
                                    End If


                                End If
                            End If
                        Else

                            'LOCATION = DS1.Tables("INV_WEIGHTED_TAB2").Rows(0).Item("STORECODE")
                            'QTY = 0
                            'RATE = 0
                            'ITEMCODE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("STORECODE")

                            If ITEMCODE <> DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE") Then
                                QTY = 0
                                RATE = 0
                                ITEMCODE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE")

                                QTY = QTY + DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "ISSUE TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") > 0 Then
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        'RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then

                                            RATE = Format((((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE)) + ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("amount") / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty")) * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty"))) / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"), "0.000")
                                        Else
                                            RATE = Format(((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK")), "0.000")
                                        End If
                                        ' RATE = ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                    ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    ' DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    ' DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE TO" Then
                                        If i <> 0 Then
                                            ' DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                        Else
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE")
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")
                                        End If
                                    Else
                                        If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "CONSUME1" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "TRANSFER1" Then

                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")

                                        Else
                                            If i <> 0 Then
                                                DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")
                                                DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                            Else
                                                'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE")
                                                DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                            End If
                                        End If

                                    End If



                                End If
                                '''  -----------------------------------------------------------------------------
                            Else

                                QTY = QTY + DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")


                                If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "ISSUE TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") > 0 Then
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        'RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then

                                            RATE = Format((((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE)) + ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("amount") / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty")) * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty"))) / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"), "0.000")
                                        Else
                                            RATE = Format(((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK")), "0.000")
                                        End If
                                        ' RATE = ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                    ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                Else

                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "CONSUME1" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "TRANSFER1" Then

                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")

                                    Else
                                        If i <> 0 Then
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                        Else
                                            'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE")
                                            DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                        End If
                                    End If

                                    'If i <> 0 Then
                                    '    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("WEIGHTED_RATE")
                                    'Else
                                    '    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE")
                                    'End If

                                    '' DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")


                                End If
                            End If

                        End If
                    Else
                        If LOCATION <> DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("STORECODE") Then
                            LOCATION = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("STORECODE")
                            QTY = 0
                            RATE = 0
                            ITEMCODE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("STORECODE")

                            If ITEMCODE <> DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE") Then
                                QTY = 0
                                RATE = 0
                                ITEMCODE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE")

                                QTY = QTY + DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE


                                End If
                            Else
                                QTY = QTY + DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE


                                End If
                            End If
                        Else
                            If ITEMCODE <> DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE") Then
                                QTY = 0
                                RATE = 0
                                ITEMCODE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE")

                                QTY = QTY + DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "TRANSFER TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") > 0 Then
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        'RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then
                                            ''sudarshan
                                            If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("amount") <> 0 Then
                                                If gShortname = "CPC" Or gShortname = "RCL" Then
                                                    RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                                Else

                                                    RATE = Format((((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE)) + ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("amount") / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty")) * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty"))) / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"), "0.000")
                                                End If


                                            Else
                                                If gShortname = "CPC" Or gShortname = "RCL" Then
                                                    RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                                Else
                                                    RATE = Format((((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE)) + ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")) * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty"))) / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"), "0.000")
                                                End If
                                            End If

                                        Else
                                            If gShortname = "CPC" Or gShortname = "RCL" Then
                                                RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                            Else
                                                RATE = Format(((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK")), "0.000")
                                            End If

                                        End If
                                        ' RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        ' RATE = Format(((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK")), "0.00000")
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                        LPRATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))

                                    ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "CONSUME" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE from" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "DAMAGE" Then
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = LPRATE
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                Else
                                    If i <> 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("RATE")
                                    Else
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")
                                    End If

                                    ' DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                End If
                            Else

                                QTY = QTY + DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "TRANSFER TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE TO" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                    If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") > 0 Then
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        'RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        'DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE").ToString().ToUpper() = "TRANSFER TO" Then
                                            ''sudarshan
                                            If DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("amount") <> 0 Then
                                                If gShortname = "CPC" Or gShortname = "RCL" Then
                                                    RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                                Else

                                                    RATE = Format((((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE)) + ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("amount") / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty")) * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty"))) / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"), "0.000")
                                                End If


                                            Else
                                                If gShortname = "CPC" Or gShortname = "RCL" Then
                                                    RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                                Else
                                                    RATE = Format((((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE)) + ((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")) * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("qty"))) / DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"), "0.000")
                                                End If
                                            End If

                                        Else
                                            If gShortname = "CPC" Or gShortname = "RCL" Then
                                                RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                            Else
                                                RATE = Format(((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK")), "0.000")
                                            End If

                                        End If
                                        ' RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        ' RATE = Format(((DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK")), "0.00000")
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                        LPRATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))

                                    ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                        RATE = Math.Abs(DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                ElseIf DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "CONSUME" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE from" Or DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "DAMAGE" Then
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    RATE = LPRATE
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                Else
                                    If i <> 0 Then
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i - 1).Item("RATE")
                                    Else
                                        DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")
                                    End If

                                    ' DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE") = RATE
                                    DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = DS1.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("lastRATE")
                                End If
                            End If

                        End If
                    End If
                Next

            End If



            DS1.Tables("INV_WEIGHTED_TAB2").Columns.Remove("TOSTORECODE")
            DS1.Tables("INV_WEIGHTED_TAB2").Columns.Remove("LOCATION")
            'DS1.Tables("INV_WEIGHTED_TAB2").Columns.Remove("lastrate")
            DS1.Tables("INV_WEIGHTED_TAB2").Columns.Remove("amount")


            'gconnection.openConnection()
            'gcommand = New SqlCommand("Update_RateNEW", gconnection.Myconn)
            'gcommand.CommandTimeout = 1000000000
            'gcommand.CommandType = CommandType.StoredProcedure
            'gcommand.Parameters.AddWithValue("@INV_WEIGHTED_TAB2", DS1.Tables("INV_WEIGHTED_TAB2"))
            'gcommand.ExecuteNonQuery()
            'gconnection.closeConnection()

            SQLS = "IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW' AND  COLUMN_NAME = 'LPRate') Begin alter table INV_WEIGHTED_final_tabNEW drop column  LPRate End"
            gconnection.dataOperation(6, SQLS, "AddC")

            SQLS = "IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_WEIGHTED_final_tabNEW' AND  COLUMN_NAME = 'amount') Begin alter table INV_WEIGHTED_final_tabNEW drop column  amount End"
            gconnection.dataOperation(6, SQLS, "AddC")


            SQLS = " truncate table INV_WEIGHTED_final_tabNEW      "
            gconnection.ExcuteStoreProcedure(SQLS)
            '  dIM  CL AS New   

            Dim gc As New GlobalClass

            gc.FillTableFromDataSet(DS1.Tables("INV_WEIGHTED_TAB2"), "dbo.INV_WEIGHTED_final_tabNEW")

            SQLS = "Update INV_WEIGHTED_final_tabNEW Set WEIGHTED_RATE = ISnull((Select Top 1 Rate From stockissuedetail B  Where B.Itemcode = INV_WEIGHTED_final_tabNEW.ITEMCODE And     B.Opstorelocationcode = INV_WEIGHTED_final_tabNEW.STORECODE And B.Docdate<INV_WEIGHTED_final_tabNEW.DOCDATE    Order By Docdate Desc),0) where isnull(WEIGHTED_RATE,0) < 0    "
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " Update INV_WEIGHTED_final_tabNEW Set WEIGHTED_RATE = isnull((Select Top 1 Rate From INV_WEIGHTED_final_tabNEW B     Where B.Itemcode = INV_WEIGHTED_final_tabNEW.ITEMCODE  And B.Docdate<=INV_WEIGHTED_final_tabNEW.DOCDATE and rate>0    Order By Docdate Desc),0) where isnull(WEIGHTED_RATE,0) < 0 "
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "update INV_WEIGHTED_final_tabNEW set LASTRATE= n.lastrate , WEIGHTED_RATE=n.WEIGHTED_RATE from  INV_WEIGHTED_final_tabNEW , INV_WEIGHTED_TAB3 n where n.ITEMCODE= INV_WEIGHTED_final_tabNEW.ITEMCODE and n.storecode=INV_WEIGHTED_final_tabNEW.STORECODE and n.DOCDETAILS=INV_WEIGHTED_final_tabNEW.DOCDETAILS and INV_WEIGHTED_final_tabNEW.itemcode+INV_WEIGHTED_final_tabNEW.STORECODE in  (select distinct ITEMCODE+storecode from INV_WEIGHTED_TAB3 where CLSSTOCK<0 )"
            gconnection.ExcuteStoreProcedure(SQLS)




            ''***** UPDATION OF THE TRANSACTION AFTER CALCULATING WEIGHTED RATE **********************
            'SQLS = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
            'gconnection.ExcuteStoreProcedure(SQLS)



            'SQLS = "UPDATE STOCKDMGDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKDMGDETAIL.dmgqty*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKDMGDETAIL.Docdetails AND A.ITEMCODE=STOCKDMGDETAIL.Itemcode AND A.TYPE='DAMAGE' "
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "UPDATE STOCKTRANSFERDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKTRANSFERDETAIL.QTY*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKTRANSFERDETAIL.Docdetails AND A.ITEMCODE=STOCKTRANSFERDETAIL.Itemcode AND STOCKTRANSFERDETAIL.TOSTORECODE=A.STORECODE AND A.TYPE='TRANSFER' "
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "UPDATE STOCKADJUSTDETAILS SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKADJUSTDETAILS.AdjustedStock*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKADJUSTDETAILS.Docdetails AND A.ITEMCODE=STOCKADJUSTDETAILS.Itemcode AND A.TYPE='ADJUSTMENT' "
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "UPDATE SUBSTORECONSUMPTIONDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= SUBSTORECONSUMPTIONDETAIL.QTY*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=SUBSTORECONSUMPTIONDETAIL.Docdetails AND A.ITEMCODE=SUBSTORECONSUMPTIONDETAIL.Itemcode AND A.TYPE='CONSUMPTION' "
            'gconnection.ExcuteStoreProcedure(SQLS)

            ''------------------------------------------------------------------------------------------------------------------


            'SQLS = " update STOCKISSUEDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKISSUEDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKISSUEDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            'SQLS = SQLS & " WHERE C.BASEUOM = STOCKISSUEDETAIL.uom And"
            'SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKISSUEDETAIL.Docdetails And A.ITEMCODE = STOCKISSUEDETAIL.Itemcode"
            'SQLS = SQLS & " AND A.TYPE='ISSUE TO' "
            'gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table STOCKDMGDETAIL disable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)

            SQLS = " update STOCKDMGDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKDMGDETAIL.dmgqty*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKDMGDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKDMGDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKDMGDETAIL.Docdetails And A.ITEMCODE = STOCKDMGDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='DAMAGE' "
            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table STOCKDMGDETAIL ENABLE trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "alter table STOCKTRANSFERDETAIL disable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)

            SQLS = " update STOCKTRANSFERDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKTRANSFERDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKTRANSFERDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKTRANSFERDETAIL.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKTRANSFERDETAIL.Docdetails And A.ITEMCODE = STOCKTRANSFERDETAIL.Itemcode"
            SQLS = SQLS & " AND A.TYPE='TRANSFER' "
            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table STOCKTRANSFERDETAIL ENABLE trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "alter table STOCKADJUSTDETAILS disable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)


            SQLS = " update STOCKADJUSTDETAILS set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= STOCKADJUSTDETAILS.AdjustedStock*(A.WEIGHTED_RATE*c.CONVVALUE) from STOCKADJUSTDETAILS ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
            SQLS = SQLS & " WHERE C.BASEUOM = STOCKADJUSTDETAILS.uom And"
            SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = STOCKADJUSTDETAILS.Docdetails And A.ITEMCODE = STOCKADJUSTDETAILS.Itemcode"
            SQLS = SQLS & " AND A.TYPE='ADJUSTMENT' "
            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table STOCKADJUSTDETAILS ENABLE trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)

            If gShortname <> "FNCC" Then
                sqlstring = "alter table SUBSTORECONSUMPTIONDETAIL disable trigger all"
                gconnection.ExcuteStoreProcedure(sqlstring)
                SQLS = " update SUBSTORECONSUMPTIONDETAIL set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= SUBSTORECONSUMPTIONDETAIL.QTY*(A.WEIGHTED_RATE*c.CONVVALUE) from SUBSTORECONSUMPTIONDETAIL ,INVENTORY_TRANSCONVERSION C , INV_WEIGHTED_final_tabNEW A"
                SQLS = SQLS & " WHERE C.BASEUOM = SUBSTORECONSUMPTIONDETAIL.uom And"
                SQLS = SQLS & "  C.TRANSUOM = a.uom And A.DOCDETAILS = SUBSTORECONSUMPTIONDETAIL.Docdetails And A.ITEMCODE = SUBSTORECONSUMPTIONDETAIL.Itemcode"
                SQLS = SQLS & " AND A.TYPE='CONSUMPTION' "
                gconnection.ExcuteStoreProcedure(SQLS)
                sqlstring = "alter table SUBSTORECONSUMPTIONDETAIL ENABLE trigger all"
                gconnection.ExcuteStoreProcedure(sqlstring)
            End If




            sqlstring = "alter table stockConsumption_1 disable trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)


            SQLS = " update stockConsumption_1 set rate=A.WEIGHTED_RATE*c.CONVVALUE,AMOUNT= stockConsumption_1.consumption*(A.WEIGHTED_RATE*c.CONVVALUE) "
            SQLS = SQLS & " from stockConsumption_1 ,INVENTORY_TRANSCONVERSION C ,"
            SQLS = SQLS & " INV_WEIGHTED_final_tabNEW A WHERE C.BASEUOM = stockConsumption_1.uom And  C.TRANSUOM = a.uom And A.DOCDETAILS = "
            SQLS = SQLS & " stockConsumption_1.docno And A.ITEMCODE = stockConsumption_1.Itemcode AND A.TYPE='CONSUME' "

            gconnection.ExcuteStoreProcedure(SQLS)
            sqlstring = "alter table stockConsumption_1 ENABLE trigger all"
            gconnection.ExcuteStoreProcedure(sqlstring)

            ''------------------------------------------------------------------------------------------------------------------

            'SQLS = "UPDATE stockConsumption_1 SET Rate=A.WEIGHTED_RATE , AMOUNT= ISNULL(stockConsumption_1.consumption,0)*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=stockConsumption_1.DOCNO AND A.ITEMCODE=stockConsumption_1.Itemcode AND A.TYPE='CONSUME' "
            'gconnection.ExcuteStoreProcedure(SQLS)

            sqlstring = "delete from INV_WEIGHTED_final_tabNEW where CATEGORY='' "
            gconnection.ExcuteStoreProcedure(sqlstring)



            SQLS = " INSERT INTO CLOSINGQTY(Trnno,Itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,priority,rate)"
            SQLS = SQLS & "SELECT DOCDETAILS AS Trnno,Itemcode,uom,storecode,DOCDATE Trndate,LASTSTOCK openningstock,ISNULL(LASTSTOCK,0)*ISNULL(LASTRATE,0) openningvalue,qty,ISNULL(CLSSTOCK,0) closingstock,"
            SQLS = SQLS & " ISNULL(CLSSTOCK,0)*WEIGHTED_RATE closingvalue,'N'batchyn,TYPE ttype,''batchno,priority,WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW where cast(docdate as date)>'" & bdate & "' ORDER BY ROWID "
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "update CLOSINGQTY set ttype='RECEIEVE' where ttype='TRANSFER TO'"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = "update CLOSINGQTY set ttype='OPENNING',trnno='OPENING' where ttype='OPENING'"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = "update CLOSINGQTY set ttype='RECEIEVE' where ttypE IN ('ISSUE TO','ISSUE GRN')"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = "update CLOSINGQTY set ttype='ISSUE' where ttype='ISSUE from'"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = "update CLOSINGQTY set ttype='KOT' where ttype='CONSUMPTION'"
            gconnection.ExcuteStoreProcedure(SQLS)
            'Added on 17.08.2021 by sriram via sandeep for open facility item 
            SQLS = "DELETE FROM CLOSINGQTY WHERE ITEMCODE='OPT' AND ttype<>'OPENNING'"
            gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "update ratelist set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ  from ratelist r inner join CLOSINGQTY on r.grnno=CLOSINGQTY.trnno where trndate = r.grndate And CLOSINGQTY.storecode = r.storecode And CLOSINGQTY.itemcode = r.Itemcode "
            'gconnection.ExcuteStoreProcedure(SQLS)
            'SQLS = "update ratelist set weightedrate=RATE,  lastweightedrate= RATE  from ratelist r inner join CLOSINGQTY on r.grnno=CLOSINGQTY.trnno where trndate = r.grndate And CLOSINGQTY.storecode = r.storecode And CLOSINGQTY.itemcode = r.Itemcode  "
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "Update journalentry Set Amount=U.Amount From UpdateWeightedRateToJournal U Where U.DocDetails = journalentry.VoucherNo  And U.Vouchertype=journalentry.VoucherType and U.Vouchertype IN ('ISSUE','STOCK TRANSFER','DAMAGE','CONSUMPTION')"
            'gconnection.ExcuteStoreProcedure(SQLS)
            'If (GACCPOST.ToUpper() = "Y") Then

            'Dim thr As New Thread(Sub() NewAccountPosting())
            '    thr.Start()

            'End If
            Call MGC_P()
            'If (GBATCHNO.ToUpper() = "Y") Then
            '    Dim thr As New Thread(Sub() BatchnoPosting())
            '    thr.Start()
            '    'Else
            '    '    Dim thr As New Thread(Sub() BatchnoPosting(DOCDETAILS, TYPE))
            '    '    thr.Start()
            'End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
      
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sqlstring1, mthyar, STR_TYPE1 As String
        Dim STR_TYPE(0) As String
        Dim Viewer As New Viewer
        Dim txtobj1 As TextObject
        Dim txtobj2 As TextObject
        Dim txtobj3 As TextObject
        Dim txtobj4 As TextObject
        Dim txtobj5 As TextObject
        Dim i As Integer
        If chk_accode.CheckedItems.Count > 0 Then
            For I = 0 To chk_accode.CheckedItems.Count - 1
                STR_TYPE = Split(chk_accode.CheckedItems(I), "-->>")
                STR_TYPE1 = STR_TYPE1 & " '" & Trim(STR_TYPE(1)) & "', "
            Next
            STR_TYPE1 = Mid(STR_TYPE1, 1, Len(STR_TYPE1) - 2)
            'STR_TYPE = STR_TYPE & ")"
        Else
            MsgBox("Please Select The Account Head.... ", vbInformation)
            ' MeValidate = False
            Exit Sub
        End If
        Dim r As New Cry_nightaudit
        sqlstring1 = " select voucherno,voucherdate,vouchertype,accountcode,accountcodedesc,slcode,sldesc,case when creditdebit='CREDIT' then amount*-1 else amount end as amount,description,slcode1,sldesc1 from INVENTORYDAILYCOLLECTION where amount<>0  "
        sqlstring1 = sqlstring1 & " and accountcode IN(" & STR_TYPE1 & ") "
        VCONN.getDataSet(sqlstring1, "night")
        If gdataset.Tables("night").Rows.Count > 0 Then
            mthyar = "COLLECTION SUMMARY FOR  :"
            mthyar = mthyar & Format(gdataset.Tables("night").Rows(0).Item("voucherdate"), "dd-MMM-yyyy")

        End If
       
        'r.ReportDefinition.Sections(
        ' R.ReportDefinition.Sections["sectionnameOrIndex"].SectionFormat.EnableSuppress = true;
        txtobj1 = r.ReportDefinition.ReportObjects("Text16")
        txtobj1.Text = mthyar
        txtobj1 = r.ReportDefinition.ReportObjects("Text10")
        txtobj1.Text = UCase(gcompanyname)
        txtobj1 = r.ReportDefinition.ReportObjects("Text2")
        txtobj1.Text = UCase(gCompanyAddress(0))
        txtobj1 = r.ReportDefinition.ReportObjects("Text11")
        txtobj1.Text = UCase(gCompanyAddress(1))
        txtobj1 = r.ReportDefinition.ReportObjects("Text12")
        txtobj1.Text = UCase(gCompanyAddress(2))
        txtobj1 = r.ReportDefinition.ReportObjects("Text15")
        txtobj1.Text = UCase(gCompanyAddress(3))
        'txtobj1 = r.ReportDefinition.ReportObjects("Text16")
        'txtobj1.Text = UCase(gCompanyAddress(4))
        'txtobj1 = r.ReportDefinition.ReportObjects("Text22")
        'txtobj1.Text = UCase(gCompanyAddress(5))



        txtobj1 = r.ReportDefinition.ReportObjects("Text27")
        txtobj1.Text = UCase(gUsername)

        txtobj1 = r.ReportDefinition.ReportObjects("Text17")
        txtobj1.Text = UCase(gFinancalyearStart)
        txtobj1 = r.ReportDefinition.ReportObjects("Text19")
        txtobj1.Text = UCase(gFinancialyearEnd)
        Dim dt As New DataTable
        Dim ds As New DataSet
        dt = VCONN.GetValues(sqlstring1)
        dt.TableName = "MEMBERDAILYCOLLECTION"
        ds.Tables.Add(dt)

       


        Call Viewer.GetDetails1(ds, r)

        ''''Call Viewer.GetDetails1(sqlstring, "VIEW_SUBS_SUMMARY", r)
        Viewer.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SQL = "  Select  VOUCHERTYPE,VOUCHERNO,SUM(ISNULL(Case When CREDITDEBIT='DEBIT' THEN AMOUNT ELSE 0 END,0)) AS DRAMT,SUM(ISNULL(CASE WHEN CREDITDEBIT='CREDIT' THEN AMOUNT ELSE 0 END,0)) AS CRAMT FROM  INVENTORYDAILYCOLLECTION GROUP   BY VOUCHERTYPE,VOUCHERNO HAVING SUM(ISNULL(CASE WHEN CREDITDEBIT='DEBIT' THEN AMOUNT ELSE 0 END,0))<>SUM(ISNULL(CASE WHEN CREDITDEBIT='CREDIT' THEN AMOUNT ELSE 0 END,0)) "
        VCONN.getDataSet(SQL, "mismatch")
        If gdataset.Tables("mismatch").Rows.Count > 0 Then
            MsgBox("credit debit not tallying please check")
            Exit Sub
        End If
        SQL = "EXEC DAYENDINVENTORYfinal '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "','" & gUsername & "'"
        VCONN.ExcuteStoreProcedure(SQL)
        MsgBox("NIGHT AUDIT COMPLETED")
        Me.Button1.Enabled = True
        Me.Button3.Visible = False
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim Iteration As Integer
        If CheckBox2.Checked = True Then
            Try
                For Iteration = 0 To (chk_accode.Items.Count - 1)
                    chk_accode.SetSelected(Iteration, True)
                    chk_accode.SetItemChecked(Iteration, True)
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                For Iteration = 0 To (chk_accode.Items.Count - 1)
                    chk_accode.SetItemChecked(Iteration, False)
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmdrndoff_Click(sender As Object, e As EventArgs) Handles cmdrndoff.Click
        Dim i As Integer
        ' sqlstring = " select (select top 1 categorydesc from ACCOUNTSTAGGINGFORCATEGORY b where a.CATEGORYCODE=b.CategoryCode) as category, (select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER' ) account,sum(clvalue) invvalue , (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')  accountsvalue ,sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where   a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "') as diff from stocksummary a   group by categorycode having sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where   a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')<>0"
        sqlstring = " select acdesc,account,sum(clvalue)invvalue, (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')  accountsvalue,sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "') as diff  from(select (select acdesc from accountsglaccountmaster where accode =(select top 1 accountcode from AccountstaggingForItem b where a.itemcode=b.ItemCode and   tablename<>'INVENTORYITEMMASTER' ) )acdesc, (select top 1 accountcode from AccountstaggingForItem b where a.itemcode=b.ItemCode and   tablename<>'INVENTORYITEMMASTER' ) account,clvalue from stocksummary a)t where account not in('0005690','0005612','0006123') group by acdesc,account having sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')<>0"
        VCONN.getDataSet(sqlstring, "SUBSCRIPTION")
        If gdataset.Tables("SUBSCRIPTION").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("SUBSCRIPTION").Rows.Count - 1
                If Math.Abs(Val(gdataset.Tables("SUBSCRIPTION").Rows(i).item("diff"))) > 10 Then
                    MsgBox("difference is greater than Rs.10 cannot pass the entry")

                End If
            Next

            If gShortname = "SATC" Then
                sqlstring = "  INSERT INTO JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,AccountCodeDesc,SLCODE,SlDesc,costcentercode,costcenterdesc,Amount,CreditDebit,AddUserId,BatchNo,Description,AUTHORISED,MCA,PROFITCENTERCODE,PROFITCENTERDESC)	 select 'SALCONSUMPTION' VoucherType,'SALCONSUMPTION'VoucherCategory,'SALE'+replace(cast( '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "' as varchar(11)),'','-') VoucherNo, '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "'VoucherDate ,'0002440','GOODS AND STORES','0005976','STOCK  OF  STORES','BAR','BAR' ,abs(sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "') ),case when (sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "') )>0 then 'CREDIT' else 'DEBIT' end,'',0,'ROUND OFF STOCK','Y','M','','' from(select (select acdesc from accountsglaccountmaster where accode =(select top 1 accountcode from AccountstaggingForItem b where a.itemcode=b.ItemCode and   tablename<>'INVENTORYITEMMASTER' ) )acdesc, (select top 1 accountcode from AccountstaggingForItem b where a.itemcode=b.ItemCode and   tablename<>'INVENTORYITEMMASTER' ) account,clvalue from stocksummary a)t where account not in('0005690','0005612','0006123') group by acdesc,account having sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')<>0             union all   select 'SALCONSUMPTION' VoucherType,'SALCONSUMPTION'VoucherCategory,'SALE'+replace(cast( '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "' as varchar(11)),'','-') VoucherNo, '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "'VoucherDate ,account,acdesc,'','','','' ,abs(sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "') ),case when (sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "') )>0 then 'DEBIT' else 'CREDIT' end,'',0,'ROUND OFF STOCK','Y','M','','' from(select (select acdesc from accountsglaccountmaster where accode =(select top 1 accountcode from AccountstaggingForItem b where a.itemcode=b.ItemCode and   tablename<>'INVENTORYITEMMASTER' ) )acdesc, (select top 1 accountcode from AccountstaggingForItem b where a.itemcode=b.ItemCode and   tablename<>'INVENTORYITEMMASTER' ) account,clvalue from stocksummary a)t where account not in('0005690','0005612','0006123') group by acdesc,account having sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=account and voucherdate<= '" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')<>0"
            Else
                sqlstring = "INSERT INTO JOURNALENTRY(VoucherType,VoucherCategory,VoucherNo,VoucherDate,Accountcode,SLCODE,SlDesc,costcentercode,costcenterdesc,Amount,CreditDebit,AccountCodeDesc,AddUserId,BatchNo,Description,AUTHORISED,MCA,PROFITCENTERCODE,PROFITCENTERDESC)	SELECT 'SALCONSUMPTION' VoucherType,'SALCONSUMPTION'VoucherCategory,'SALE'+replace(cast('" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "' as varchar(11)),'','-') VoucherNo,'" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "'VoucherDate,(select c.conglcode from  AccountstaggingForCategory C where a.CATEGORYCODE=C.CategoryCode  and ISNULL(c.colname,'')='CATEGORYCODE') ,'','',isnull((select CONCCCODE from  AccountstaggingForCategory C where a.CATEGORYCODE=C.CategoryCode  and ISNULL(c.colname,'')='CATEGORYCODE'),''),isnull((select CONCCDESC from  AccountstaggingForCategory C where a.CATEGORYCODE=C.CategoryCode  and ISNULL(c.colname,'')='CATEGORYCODE'),''),	abs(sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where   a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')), case when (sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where   a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "'))>0 then 'credit' else 'DEBIT' end,d.ACDESC,'',0,'POSTING FROM POS - ' ,'Y','M','RSAOI','RSAOI MAIN ACCOUNT' FROM stocksummary a  INNER JOIN ACCOUNTSGLACCOUNTMASTER d ON (select c.conglcode from  AccountstaggingForCategory C where a.CATEGORYCODE=C.CategoryCode  and ISNULL(c.colname,'')='CATEGORYCODE')=d.ACCODE 	group by categorycode,d.acdesc having sum(clvalue)- (select sum(debits)-sum(credits) from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where   a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')<>0            union all		SELECT 'SALCONSUMPTION' VoucherType,'SALCONSUMPTION'VoucherCategory,'SALE'+replace(cast('" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "' as varchar(11)),'','-')VoucherNo,'" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "' VoucherDate,(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER' ) accountcode,'','','','',abs(sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where   a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')),case when (sum(clvalue)- (select sum(debits)-sum(credits)  from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where   a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "'))>0 then   'DEBIT' else 'credit' end,d.ACDESC,'',0,'POSTING FROM POS - ','Y','M','RSAOI','RSAOI MAIN ACCOUNT' FROM stocksummary a  INNER JOIN ACCOUNTSGLACCOUNTMASTER d ON (select c.accountcode from  AccountstaggingForCategory C where a.CATEGORYCODE=C.CategoryCode  and ISNULL(c.colname,'')='CATEGORYCODE')=d.ACCODE 	group by categorycode,d.acdesc having sum(clvalue)- (select sum(debits)-sum(credits) from vw_Balancesheet_Period where accode=(select top 1 accountcode from ACCOUNTSTAGGINGFORCATEGORY b where   a.CATEGORYCODE=b.CategoryCode and   tablename<>'INVENTORYITEMMASTER')and voucherdate<='" & Format(Dtp_billdate.Value, "dd/MMM/yyyy") & "')<>0"

            End If
              VCONN.ExcuteStoreProcedure(sqlstring)
        End If


    End Sub
End Class