
Imports CrystalDecisions.CrystalReports.Engine
Public Class Frm_InventoryItemmastervb
    Dim sqlstring As String
    Dim boolchk, flag As Boolean
    Dim gconnection As New GlobalClass
    Public ItemcodeM As String
    Dim CW As Integer = Me.Width ' Current Width
    Dim CH As Integer = Me.Height ' Current Height
    Dim IW As Integer = Me.Width ' Initial Width
    Dim IH As Integer = Me.Height ' Initial Height
    Dim workingRectangle As System.Drawing.Rectangle =
        Screen.PrimaryScreen.WorkingArea
    Private Sub clearoperation()

        TxtProfitPer.Text = ""
        CB_ComYesNo.Text = "NO"
        TxtSPLCESS.Text = ""
        Txt_companycode.Text = ""
        TXT_COMPANYDESC.Text = ""
        Me.labfreeze.Text = ""
        txt_ItemCode.ReadOnly = False
        txt_ItemCode.Text = ""
        txt_ItemName.Text = ""
        txt_GroupCode.Text = ""
        txt_GroupDesc.Text = ""
        txt_SubGroupCode.Text = ""
        txt_SubGroupDesc.Text = ""
        txt_SubSubGroupCode.Text = ""
        txt_SubSubGroupDesc.Text = ""
        TXT_CATEGORY.Text = ""
        Txt_Categorycode.Text = ""
        TXT_HSNNO.Text = ""
        txtstock.Text = ""
        Cmbstockcategory.SelectedIndex = -1
        CMB_SALEITEM.SelectedIndex = -1
        ''Added by Sri for Expiry
        Cmb_BatchNo.SelectedIndex = -1
        Cmb_Expiry.SelectedIndex = -1
        CMB_Shelving.SelectedIndex = -1
        ''
        txt_salerate.Text = "0.00"
        txt_Purchaserate.Text = "0.00"
        TXT_MRPRATE.Text = "0.00"
        CB_ComYesNo.SelectedIndex = -1
        Cbo_ABC_category.SelectedIndex = -1
        CBO_TAXREBATE.SelectedIndex = -1
        CmbBatch.SelectedIndex = -1
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        AxfpSpread2.ClearRange(1, 1, -1, -1, True)
        Cmd_Add.Text = "Add [F7]"
        Cmd_Freeze.Text = "Void[F8]"
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True
        If UCase(gShortname) = "CCL" Or UCase(gShortname) = "SATC" Then
            CBO_TAXREBATE.SelectedItem = "YES"
            CBO_TAXREBATE.Enabled = False
        End If
        CBO_TAXREBATE.SelectedItem = "YES"


        If Mid(UCase(gShortname), 1, 3) = "NIZ" Then
            CBO_TAXREBATE.SelectedItem = "NO"
            CBO_TAXREBATE.Enabled = False
        End If
        FillUomMaster()
        txtstock.Text = ""
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
        If gShortname = "HGA" Then
            txt_GroupCode.ReadOnly = False
            txt_SubGroupCode.ReadOnly = False
            txt_SubSubGroupCode.ReadOnly = False
            txt_SubSubGroupCode.ReadOnly = False
            Txt_Categorycode.ReadOnly = False

            cmd_GroupCode.Enabled = True
            cmd_SubGroupCode.Enabled = True
            cmd_SubSubGroupCode.Enabled = True
            BttnCategory_Help.Enabled = True
            Me.txt_ItemCode.Focus()
        End If

        Txt_Rate.Enabled = True
        Txt_Rate.ReadOnly = False
        Me.txt_ItemCode.Focus()
        TabControl1.SelectedIndex = 0


    End Sub
    Private Sub addoperation()
        Dim insert(0), SQL As String
        Dim splcess As Double
        Dim ABCcategory, Taxrebate, batchprocess, SALEITEM, batchno, expirydate, shelving As String
        If Trim(Cbo_ABC_category.Text) = "" Then
            ABCcategory = "A"
        Else
            ABCcategory = Cbo_ABC_category.Text
        End If
        If Trim(CBO_TAXREBATE.Text) = "" Then
            Taxrebate = "NO"
        Else
            Taxrebate = CBO_TAXREBATE.Text
        End If
        If Trim(CmbBatch.Text) = "" Then
            batchprocess = "NO"
        Else
            batchprocess = CmbBatch.Text
        End If
        If Trim(CMB_SALEITEM.Text) = "" Then
            SALEITEM = "NO"
        Else
            SALEITEM = CMB_SALEITEM.Text
        End If
        If Trim(TxtSPLCESS.Text) = "" Then
            splcess = 0
        Else
            splcess = Format(Val(TxtSPLCESS.Text), "0.00")
        End If
        ''Added by Sri for Expiry
        If Trim(Cmb_BatchNo.Text) = "" Then
            batchno = "NO"
        Else
            batchno = Cmb_BatchNo.Text
        End If
        If Trim(Cmb_Expiry.Text) = "" Then
            expirydate = "NO"
        Else
            expirydate = Cmb_Expiry.Text
        End If
        If Trim(CMB_Shelving.Text) = "" Then
            shelving = "NO"
        Else
            shelving = CMB_Shelving.Text
        End If
        ''
        If Cmd_Add.Text = "Add [F7]" Then
            SQL = "Insert into INV_InventoryItemMaster(Itemcode,Itemname,Groupcode,subGroupcode,subsubgroupcode,Category,AbcCategory,TaxRebate,batchprocess,void,PROFITPER,adddate,adduser,STOCKUOM,stockcategory,COMPANYREQ,COMPANYcode,COMPANYDESC,SPLCESS,SALEITEM,PRATE,"
            If UCase(gShortname) = "KGA" Or UCase(gShortname) = "DC" Or UCase(gShortname) = "CSC" Then
                SQL = SQL & "SALERATE,PURCHASERATE,"
            End If

            If UCase(gShortname) = "KSCA" Then
                SQL = SQL & "MRPRATE,"
            End If

            ''Added by Sri 
            If GBATCHNO = "Y" Then
                SQL = SQL & "Batchno,ExpiryDate,"
            End If
            If GSHELVING = "Y" Then
                SQL = SQL & "Shelving,"
            End If
            SQL = SQL & "HSNNO)"
            ''
            SQL = SQL & " values ('" + txt_ItemCode.Text + "','" + txt_ItemName.Text + "','" + txt_GroupCode.Text + "','" + txt_SubGroupCode.Text + "',"
            SQL = SQL & " '" + txt_SubSubGroupCode.Text + "','" + Txt_Categorycode.Text + "','" + ABCcategory + "','" + Taxrebate + "','" + batchprocess + "','N','" + Format(Val(TxtProfitPer.Text), "0.00") + "',getdate(),'" + gUsername + "','" + txtstock.Text + "','" + Cmbstockcategory.Text + "','" & CB_ComYesNo.Text & "','" & Txt_companycode.Text & "','" & TXT_COMPANYDESC.Text & "'," & splcess & ",'" & SALEITEM & "'," & Val(Txt_Rate.Text) & ","
            If UCase(gShortname) = "KGA" Or UCase(gShortname) = "DC" Or UCase(gShortname) = "CSC" Then
                SQL = SQL & " '" & txt_salerate.Text & "','" & txt_Purchaserate.Text & "',"
            End If
            If UCase(gShortname) = "KSCA" Then
                SQL = SQL & " '" & TXT_MRPRATE.Text & "',"
            End If
            '' Sri
            If GBATCHNO = "Y" Then
                SQL = SQL & "'" & batchno & "','" & expirydate & "', "
            End If
            If GSHELVING = "Y" Then
                SQL = SQL & "'" & shelving & "',"
            End If
            SQL = SQL & "'" & TXT_HSNNO.Text & "')"
            ''
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = SQL
            'Dim Seq As Double = gconnection.getInvSeq(Format(CDate(gFinancialyearStart), "dd/MMM/yyyy"))
            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                SQL = "select * from inv_InventoryOpenningstock where itemcode='" + txt_ItemCode.Text + "' and storecode='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                    SQL = "update inv_InventoryOpenningstock set "
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 2
                    SQL = SQL & "  UOM='" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 3
                    SQL = SQL & "  Minqty='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 4
                    SQL = SQL & "  MaxQty='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 5
                    SQL = SQL & "  Reorder='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 6
                    SQL = SQL & "  OpenningQty='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 7
                    SQL = SQL & "  OpenningValue='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 8
                    SQL = SQL & "  void='" + AxfpSpread1.Text + "', updateuser='" + gUsername + "' ,updatedate=getdate() "
                    AxfpSpread1.Col = 1
                    SQL = SQL & " where itemcode='" + txt_ItemCode.Text + "' and storecode='" + AxfpSpread1.Text + "'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = SQL
                Else
                    SQL = "Insert into inv_InventoryOpenningstock (itemcode,storecode,uom,minqty,maxqty,reorder,openningqty,openningvalue,void,closingqty,closingvalue,adduser,adddate,fyear)"
                    SQL = SQL & " values ('" + txt_ItemCode.Text + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 1
                    SQL = SQL & "  '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 2
                    SQL = SQL & "  '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 3
                    SQL = SQL & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 4
                    SQL = SQL & "  '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 5
                    SQL = SQL & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 6
                    SQL = SQL & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 7
                    SQL = SQL & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 8
                    SQL = SQL & "  '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 6
                    SQL = SQL & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 7
                    SQL = SQL & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    SQL = SQL & " '" + gUsername + "' ,getdate(),'" & Format(CDate(gFinancialyearStart), "dd/MMM/yyyy") & "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = SQL
                End If
            Next
            Dim O As Integer
            Dim TYPE() As String
            If chklst_Uom.CheckedItems.Count > 0 Then
                For O = 0 To chklst_Uom.CheckedItems.Count - 1
                    TYPE = Split(chklst_Uom.CheckedItems(O), "-->")
                    sqlstring = "INSERT INTO INVITEM_TRANSUOM_LINK(Itemcode,Tranuom,stockuom,Adduser,AdddateTIME)"
                    sqlstring = sqlstring & " VALUES('" & Trim(txt_ItemCode.Text) & "' ,"
                    sqlstring = sqlstring & " " & "'" & TYPE(0) & "',"
                    sqlstring = sqlstring & " '" & Trim(txtstock.Text) & " ',"

                    sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                Next
            End If
            For i As Integer = 1 To AxfpSpread2.DataRowCnt
                AxfpSpread2.Row = i
                AxfpSpread2.Col = 1
                SQL = "select * from inv_Inventoryuomstorelink where itemcode='" + txt_ItemCode.Text + "' and storecode='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(SQL, "inv_Inventoryuomstorelink")
                If (gdataset.Tables("inv_Inventoryuomstorelink").Rows.Count > 0) Then
                    SQL = "update inv_Inventoryuomstorelink set "
                    AxfpSpread2.Row = i
                    AxfpSpread2.Col = 2
                    SQL = SQL & "  reportUOM='" + AxfpSpread2.Text + "',"
                    AxfpSpread2.Row = i
                    AxfpSpread2.Col = 3
                    SQL = SQL & "  reportdecimaluom='" + AxfpSpread2.Text + "',"
                    AxfpSpread2.Row = i
                    AxfpSpread2.Col = 8
                    SQL = SQL & "  void='" + AxfpSpread2.Text + "', updateuser='" + gUsername + "' ,updatedate=getdate()"
                    AxfpSpread2.Col = 1
                    SQL = SQL & " where itemcode='" + txt_ItemCode.Text + "' and storecode='" + AxfpSpread2.Text + "'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = SQL
                Else
                    SQL = "Insert into inv_Inventoryuomstorelink (itemcode,storecode,reportUOM,reportdecimaluom,void,adduser,adddate)"
                    SQL = SQL & " values ('" + txt_ItemCode.Text + "',"
                    AxfpSpread2.Row = i
                    AxfpSpread2.Col = 1
                    SQL = SQL & "  '" + AxfpSpread2.Text + "',"
                    AxfpSpread2.Row = i
                    AxfpSpread2.Col = 2
                    SQL = SQL & "  '" + AxfpSpread2.Text + "',"
                    AxfpSpread2.Row = i
                    AxfpSpread2.Col = 3
                    SQL = SQL & " '" + AxfpSpread2.Text + "',"
                    AxfpSpread2.Row = i
                    AxfpSpread2.Col = 4
                    SQL = SQL & " '" + AxfpSpread2.Text + "',"
                    SQL = SQL & "   '" + gUsername + "' ,getdate())"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = SQL
                End If
            Next
            gconnection.MoreTrans(insert)
            ' clearoperation()
        End If
        'SQL = ""
        'TabControl1.SelectedIndex = 1
        'gconnection.MoreTrans(insert)
    End Sub

    Private Sub updateoperation()

        Dim insert(0) As String

        Dim splcess As Double

        Dim ABCcategory, Taxrebate, batchprocess, batchno, expirydate, Shelving As String
        If Trim(Cbo_ABC_category.Text) = "" Then
            ABCcategory = "A"
        Else
            ABCcategory = Cbo_ABC_category.Text
        End If
        If Trim(CBO_TAXREBATE.Text) = "" Then
            Taxrebate = "NO"
        Else
            Taxrebate = CBO_TAXREBATE.Text
        End If
        If Trim(CmbBatch.Text) = "" Then
            batchprocess = "NO"
        Else
            batchprocess = CmbBatch.Text
        End If

        If Trim(TxtSPLCESS.Text) = "" Then
            splcess = 0
        Else
            splcess = Format(Val(TxtSPLCESS.Text), "0.00")
        End If

        ''Added by Sri for Expiry
        If Trim(Cmb_BatchNo.Text) = "" Then
            batchno = "NO"
        Else
            batchno = Cmb_BatchNo.Text
        End If
        If Trim(Cmb_Expiry.Text) = "" Then
            expirydate = "NO"
        Else
            expirydate = Cmb_Expiry.Text
        End If
        If Trim(CMB_Shelving.Text) = "" Then
            Shelving = "NO"
        Else
            Shelving = CMB_Shelving.Text
        End If
        ''

        If Cmd_Add.Text = "Update[F7]" Then

            Dim strSQL = "   SELECT * FROM SYSOBJECTS WHERE name='inv_InventoryOpenningstock_LOG'"
            gconnection.getDataSet(strSQL, "SYSOBJECTS")
            If gdataset.Tables("SYSOBJECTS").Rows.Count = 0 Then
                sqlstring = "CREATE TABLE inv_InventoryOpenningstock_LOG([LogId] [int] IDENTITY(1,1) NOT NULL,[Autoid] [int] NOT NULL,[itemcode] [varchar](30) NULL,[storecode] [varchar](30) NULL,[uom] [varchar](30) NULL,[minqty] [numeric](18, 2) NULL,[maxqty] [numeric](18, 2) NULL,[reorder] [numeric](18, 2) NULL,[openningqty ] [numeric](18, 2) NULL,[openningvalue] [numeric](18, 2) NULL,[closingqty ] [numeric](18, 2) NULL,[closingvalue] [numeric](18, 2) NULL,[void] [varchar](1) NULL,[AddDate] [datetime] NULL,[addUSER] [varchar](50) NULL,[UPDATEUSER] [varchar](15) NULL,[UPDATEdate] [datetime] NULL,[voiduser] [varchar](50) NULL,[voiddate] [datetime] NULL)"
                gconnection.dataOperation(6, sqlstring, )
            End If

            sqlstring = "insert into inv_InventoryOpenningstock_LOG(Autoid,itemcode,storecode,uom,minqty,maxqty,reorder,openningqty,openningvalue,void,closingqty,closingvalue,adduser,adddate) select  Autoid,itemcode,storecode,uom,minqty,maxqty,reorder,openningqty,openningvalue,void,closingqty,closingvalue,adduser,adddate from inv_InventoryOpenningstock where itemcode='" + txt_ItemCode.Text + "'"
            gconnection.dataOperation(6, sqlstring, )

            sqlstring = " delete from INV_InventoryItemMaster where itemcode='" + txt_ItemCode.Text + "' "

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            Dim sql As String = "Insert into INV_InventoryItemMaster(Itemcode,Itemname,Groupcode,subGroupcode,subsubgroupcode,Category,AbcCategory,TaxRebate,batchprocess,void,PROFITPER,UPDATEdate,UPDATEUSER,STOCKUOM,stockcategory,COMPANYREQ,COMPANYcode,COMPANYDESC,splcess,PRATE,"
            If UCase(gShortname) = "KGA" Or UCase(gShortname) = "DC" Or UCase(gShortname) = "CSC" Then
                sql = sql & "SALERATE,PURCHASERATE,"
            End If

            If UCase(gShortname) = "KSCA" Then
                sql = sql & "MRPRATE,"
            End If

            ''Added by Sri 
            If GBATCHNO = "Y" Then
                sql = sql & "Batchno,ExpiryDate,"
            End If
            If GSHELVING = "Y" Then
                sql = sql & "Shelving,"
            End If
            sql = sql & "HSNNO)"
            ''



            sql = sql & " values ('" + txt_ItemCode.Text + "','" + txt_ItemName.Text + "','" + txt_GroupCode.Text + "','" + txt_SubGroupCode.Text + "',"
            sql = sql & " '" + txt_SubSubGroupCode.Text + "','" + Txt_Categorycode.Text + "','" + ABCcategory + "','" + Taxrebate + "','" + batchprocess + "','N','" + Format(Val(TxtProfitPer.Text), "0.00") + "',getdate(),'" + gUsername + "','" + txtstock.Text + "','" + Cmbstockcategory.Text + "','" & CB_ComYesNo.Text & "','" & Txt_companycode.Text & "','" & TXT_COMPANYDESC.Text & "'," & splcess & "," & Val(Txt_Rate.Text) & ","
            If UCase(gShortname) = "KGA" Or UCase(gShortname) = "DC" Or UCase(gShortname) = "CSC" Then
                sql = sql & " '" & txt_salerate.Text & "','" & txt_Purchaserate.Text & "',"
            End If
            If UCase(gShortname) = "KSCA" Then
                sql = sql & "'" & TXT_MRPRATE.Text & "',"
            End If
            '' Sri
            If GBATCHNO = "Y" Then
                sql = sql & "'" & batchno & "','" & expirydate & "',"
            End If
            If GSHELVING = "Y" Then
                sql = sql & "'" & Shelving & "',"
            End If
            sql = sql & "'" & TXT_HSNNO.Text & "')"
            ''



            'Dim sql As String = "Update INV_InventoryItemMaster set Itemname='" + txt_ItemName.Text + "',GROUPCODE='" + txt_GroupCode.Text + "',PROFITPER='" + Format(Val(TxtProfitPer.Text), "0.000") + "',"
            'sql = sql & " subgroupcode='" + txt_SubGroupCode.Text + "',subsubgroupcode='" + txt_SubSubGroupCode.Text + "',Category='" + Txt_Categorycode.Text + "',"
            'sql = sql & " AbcCategory='" + ABCcategory + "',Taxrebate='" + Taxrebate + "',void='N',updatedate=getdate(),updateuser='" + gUsername + "',STOCKUOM='" + txtstock.Text + "',stockcategory='" + Cmbstockcategory.Text + "' where itemcode='" + txt_ItemCode.Text + "'"

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sql
            'Dim Seq As Double = gconnection.getInvSeq(Format(CDate(gFinancialyearStart), "dd/MMM/yyyy"))
            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                sql = "select * from inv_InventoryOpenningstock where itemcode='" + txt_ItemCode.Text + "' and storecode='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(sql, "inv_InventoryOpenningstock")
                If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                    sql = "update inv_InventoryOpenningstock set "
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 2
                    sql = sql & "  UOM='" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 3
                    sql = sql & "  Minqty='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 4
                    sql = sql & "  MaxQty='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 5
                    sql = sql & "  Reorder='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 6
                    sql = sql & "  OpenningQty='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    sql = sql & "  closingQty='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 7
                    sql = sql & "  OpenningValue='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    sql = sql & "  closingValue='" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 8
                    sql = sql & "  void='" + AxfpSpread1.Text + "', updateuser='" + gUsername + "' ,updatedate=getdate()"
                    AxfpSpread1.Col = 1
                    sql = sql & " where itemcode='" + txt_ItemCode.Text + "' and storecode='" + AxfpSpread1.Text + "'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sql

                    'AxfpSpread1.Col = 1
                    'Dim storecode As String = AxfpSpread1.Text
                    'AxfpSpread1.Col = 6
                    'Dim qty As Double = Val(AxfpSpread1.Text)
                    'AxfpSpread1.Col = 7
                    'Dim CLOSINGVALUE As Double = Val(AxfpSpread1.Text)
                    'Dim qty1 As Double
                    'Dim batchyn As String
                    'Dim SQL1 As String = "select qty,batchyn from closingqty where  itemcode='" + txt_ItemCode.Text + "' and storecode='" + storecode + "' "
                    'SQL1 = SQL1 & " and Trnno='Openning' "
                    'gconnection.getDataSet(SQL1, "closingqty")
                    'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    '    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                    '    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                    'End If
                    'SQL1 = "update closingqty set qty='" + Format(Val(qty), "0.000") + "' ,closingstock=" + Format(Val(qty), "0.000") + ""
                    'SQL1 = SQL1 & ",closingvalue=" + Format(Val(CLOSINGVALUE), "0.000") + ""
                    'SQL1 = SQL1 & "  where trnno='Openning' and storecode='" + storecode + "' and itemcode='" + txt_ItemCode.Text + "' "
                    'If (batchyn = "Y") Then
                    '    SQL1 = SQL1 & "  and  batchno='Openning'"
                    'End If
                    'ReDim Preserve insert(insert.Length)
                    'insert(insert.Length - 1) = SQL1

                    ''SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(qty - qty1), "0.000") + " ,openningstock=openningstock+" + Format(Val(qty - qty1), "0.000") + ",closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock)) "
                    ' ''openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
                    ''SQL1 = SQL1 & "  where trndate>'" & Format(CDate(gFinancialyearStart), "dd/MMM/yyyy") & "' and itemcode='" + txt_ItemCode.Text + "' and storecode='" + storecode + "' and closingstock<> 0"
                    ''If (batchyn = "Y") Then
                    ''    SQL1 = SQL1 & "  and  batchno='Openning'"
                    ''End If
                    'ReDim Preserve insert(insert.Length)
                    'insert(insert.Length - 1) = SQL1


                Else
                    sql = "Insert into inv_InventoryOpenningstock (itemcode,storecode,uom,minqty,maxqty,reorder,openningqty,openningvalue,void,closingqty,closingvalue,adduser,adddate,FYEAR)"
                    sql = sql & " values ('" + txt_ItemCode.Text + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 1
                    sql = sql & "  '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 2
                    sql = sql & "  '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 3
                    sql = sql & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 4
                    sql = sql & "  '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 5
                    sql = sql & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 6
                    sql = sql & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 7
                    sql = sql & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 8
                    sql = sql & "  '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 6
                    sql = sql & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 7
                    sql = sql & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                    sql = sql & " '" + gUsername + "' ,getdate(),'" & Format(CDate(gFinancialyearStart), "dd/MMM/yyyy") & "' )"

                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sql
                    'sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno)"
                    'sqlstring = sqlstring & " values ('Openning',"
                    '' AxfpSpread1.Col = 1
                    'sqlstring = sqlstring & "'" + txt_ItemCode.Text + "',"
                    'AxfpSpread1.Col = 2
                    'sqlstring = sqlstring & "'" + AxfpSpread1.Text + "', "
                    'AxfpSpread1.Col = 1
                    'sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',"
                    'sqlstring = sqlstring & " '" + Format(CDate(gFinancialyearStart), "dd/MMM/yyyy") + "',"
                    'AxfpSpread1.Col = 6

                    'sqlstring = sqlstring & " " & Format(Val(0), "0.000") & ","
                    'AxfpSpread1.Col = 7

                    'sqlstring = sqlstring & "'" + Format(Val(0), "0.00") + "' ,"
                    'AxfpSpread1.Col = 6
                    'sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    'AxfpSpread1.Col = 6

                    'sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    'AxfpSpread1.Col = 7

                    'sqlstring = sqlstring & "'" + Format(Val(AxfpSpread1.Text), "0.00") + "' ,"

                    'If (batchprocess = "YES") Then
                    '    sqlstring = sqlstring & " 'Y',"
                    'Else
                    '    sqlstring = sqlstring & " 'N',"

                    'End If

                    'sqlstring = sqlstring & "  'Openning', "
                    'sqlstring = sqlstring & "  'Openning')"
                    'ReDim Preserve insert(insert.Length)
                    'insert(insert.Length - 1) = sqlstring

                    'AxfpSpread1.Col = 1
                    'sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',"

                    'sqlstring = "update CLOSINGQTY set TRNS_SEQ=g.TRNS_SEQ from CLOSINGQTY c inner join inv_InventoryOpenningstock g on c.storecode='" & AxfpSpread1.Text & "' where c.Itemcode='" + txt_ItemCode.Text + "' and G.Itemcode='" + txt_ItemCode.Text + "'"
                    'ReDim Preserve insert(insert.Length)

                    'insert(insert.Length - 1) = sqlstring

                End If

            Next


            sqlstring = " delete from inv_InventoryOpenningstock "
            sqlstring = sqlstring & " WHERE itemcode='" + txt_ItemCode.Text + "' and  storecode not IN ("
            For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
                AxfpSpread1.Row = i + 1
                AxfpSpread1.Col = 1
                Dim storecode As String = AxfpSpread1.Text
                If storecode <> "" Then
                    sqlstring = sqlstring & " '" & Trim(storecode) & "', "
                End If
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"

            If AxfpSpread1.DataRowCnt <> 0 Then
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
            End If




            strSQL = "Delete from  inv_Inventoryuomstorelink  where  Itemcode= '" & Trim(txt_ItemCode.Text) & "'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = strSQL

            For i As Integer = 1 To AxfpSpread2.DataRowCnt
                AxfpSpread2.Row = i
                AxfpSpread2.Col = 1
                'sql = "select * from inv_Inventoryuomstorelink where itemcode='" + txt_ItemCode.Text + "' and storecode='" + AxfpSpread2.Text + "'"
                'gconnection.getDataSet(sql, "inv_InventoryOpenningstock")
                'If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                '    AxfpSpread2.Row = i
                '    sql = "update inv_Inventoryuomstorelink set "
                '    AxfpSpread2.Col = 2
                '    sql = sql & "  reportUOM='" + AxfpSpread2.Text + "',"
                '    AxfpSpread2.Row = i
                '    AxfpSpread2.Col = 3
                '    sql = sql & "  reportdecimaluom='" + AxfpSpread2.Text + "',"
                '    AxfpSpread2.Row = i
                '    AxfpSpread2.Col = 4
                '    sql = sql & "  void='" + AxfpSpread2.Text + "', updateuser='" + gUsername + "' ,updatedate=getdate()"
                '    AxfpSpread2.Col = 1
                '    sql = sql & " where itemcode='" + txt_ItemCode.Text + "' and storecode='" + AxfpSpread2.Text + "'"
                '    ReDim Preserve insert(insert.Length)
                '    insert(insert.Length - 1) = sql

                'Else
                sql = "Insert into inv_Inventoryuomstorelink (itemcode,storecode,reportUOM,reportdecimaluom,void,adduser,adddate)"
                sql = sql & " values ('" + txt_ItemCode.Text + "' ,"
                AxfpSpread2.Row = i
                AxfpSpread2.Col = 1
                sql = sql & "  '" + AxfpSpread2.Text + "',"
                AxfpSpread2.Row = i
                AxfpSpread2.Col = 2
                sql = sql & "  '" + AxfpSpread2.Text + "',"
                AxfpSpread2.Row = i
                AxfpSpread2.Col = 3
                sql = sql & " '" + AxfpSpread2.Text + "',"
                AxfpSpread2.Row = i
                AxfpSpread2.Col = 4
                sql = sql & " '" + AxfpSpread2.Text + "',"
                sql = sql & "   '" + gUsername + "' ,getdate())"

                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sql


                ' End If

            Next

            Dim sqlopt As String = "select * from INVITEM_TRANSUOM_LINK where  Itemcode= '" & Trim(txt_ItemCode.Text) & "'"
            gconnection.getDataSet(sqlopt, "INVITEM_TRANSUOM_LINK")
            If (gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count > 0) Then
                strSQL = "Delete from  INVITEM_TRANSUOM_LINK  where  Itemcode= '" & Trim(txt_ItemCode.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = strSQL
            End If
            Dim O As Integer
            Dim TYPE() As String
            If chklst_Uom.CheckedItems.Count > 0 Then
                For O = 0 To chklst_Uom.CheckedItems.Count - 1
                    TYPE = Split(chklst_Uom.CheckedItems(O), "-->")
                    strSQL = "INSERT INTO INVITEM_TRANSUOM_LINK(Itemcode,Tranuom,stockuom,Adduser,AdddateTIME)"
                    strSQL = strSQL & " VALUES('" & Trim(txt_ItemCode.Text) & "',"
                    strSQL = strSQL & " " & "'" & TYPE(0) & "',"
                    strSQL = strSQL & " '" & Trim(txtstock.Text) & " ',"
                    strSQL = strSQL & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = strSQL
                Next
            End If

            strSQL = "Delete from  InvCompany_ItemMaster  where  Itemcode= '" & Trim(txt_ItemCode.Text) & "' and fromTag='IM'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = strSQL

            strSQL = "Insert into InvCompany_ItemMaster(companycode,companydesc,itemcode,itemname,adduser,adddate,freeze,fromTag) values ('" & Txt_companycode.Text & "','" & TXT_COMPANYDESC.Text & "', '" & Trim(txt_ItemCode.Text) & "', '" & Trim(txt_ItemName.Text) & "','" & gUsername & "',getDate(),'N','IM')"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = strSQL
            gconnection.MoreTrans(insert)
            'TabControl1.SelectedIndex = 1
            'gconnection.MoreTrans(insert)
        End If

    End Sub

    Private Sub voidoperation()
        Dim insert(0) As String
        Dim sql As String
        Dim gvoid As String = "Y"
        If Cmd_Freeze.Text = "Void[F8]" Then
            gvoid = "Y"
            If MsgBox("Are you Sure to Void the Record....", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                Exit Sub
            End If
        ElseIf Cmd_Freeze.Text = "UnVoid[F8]" Then
            gvoid = "N"
            If MsgBox("Are you Sure to UnVoid the Record....", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        sql = "Update INV_InventoryItemMaster set Void='" + gvoid + "',"
        sql = sql & " voiddate=getdate(),voiduser='" + gUsername + "' where itemcode='" + txt_ItemCode.Text + "'"
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sql

        sql = "update inv_Inventoryuomstorelink set "

        sql = sql & "  void='" + gvoid + "', voiduser='" + gUsername + "' ,voiddate=getdate()"

        sql = sql & " where itemcode='" + txt_ItemCode.Text + "'"
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sql
        sql = "update inv_InventoryOpenningstock set "

        sql = sql & "  void='" + gvoid + "', voiduser='" + gUsername + "' ,voiddate=getdate()"

        sql = sql & " where itemcode='" + txt_ItemCode.Text + "'"

        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sql

        gconnection.MoreTrans(insert)
        clearoperation()
    End Sub


    'Private Sub Resize_Form()
    '    Dim cControl As Control
    '    Dim i_i As Integer
    '    Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
    '    'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
    '    '    Exit Sub
    '    'End If
    '    J = 768
    '    K = 1024
    '    Me.ResizeRedraw = True

    '    T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
    '    U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
    '    If U = 800 Then
    '        T = T - 50
    '    End If
    '    If U = 1280 Then
    '        T = T - 50
    '    End If
    '    If U = 1360 Then
    '        T = T - 75
    '    End If
    '    If U = 1366 Then
    '        T = T - 75
    '    End If
    '    Me.Location = Screen.PrimaryScreen.WorkingArea.Location
    '    Me.StartPosition = FormStartPosition.CenterScreen
    '    Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    '    Me.Width = U
    '    Me.Height = T


    '    With Me
    '        For i_i = 0 To .Controls.Count - 1
    '            ' MsgBox(Controls(i_i).Name)
    '            If TypeOf .Controls(i_i) Is Form Then


    '                If .Controls(i_i).Location.X = 0 Then
    '                    L = 0
    '                Else
    '                    L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
    '                End If
    '                If .Controls(i_i).Location.Y = 0 Then
    '                    L = 0
    '                Else
    '                    M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
    '                End If
    '                .Controls(i_i).Left = L
    '                .Controls(i_i).Top = M
    '                If .Controls(i_i).Size.Width = 0 Then
    '                    n = 0
    '                Else
    '                    n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
    '                End If
    '                If .Controls(i_i).Size.Height = 0 Then
    '                    o = 0
    '                Else
    '                    o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
    '                End If

    '                .Controls(i_i).Width = n
    '                .Controls(i_i).Height = o
    '            ElseIf TypeOf .Controls(i_i) Is Panel Then


    '                If .Controls(i_i).Location.X = 0 Then
    '                    L = 0
    '                Else
    '                    If Controls(i_i).Name = "Panel" Then
    '                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

    '                        If U = 800 Then
    '                            L = L + 50
    '                        End If
    '                        If U = 1280 Then
    '                            L = L + 50
    '                        End If
    '                        If U = 1360 Then
    '                            L = L + 75
    '                        End If
    '                        If U = 1366 Then
    '                            L = L + 75
    '                        End If
    '                    Else
    '                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

    '                        ' L = L - 5
    '                    End If
    '                End If
    '                If .Controls(i_i).Location.Y = 0 Then
    '                    L = 0

    '                Else
    '                    M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
    '                End If

    '                .Controls(i_i).Left = L
    '                .Controls(i_i).Top = M
    '                If .Controls(i_i).Size.Width = 0 Then
    '                    n = 0
    '                Else
    '                    n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
    '                End If
    '                If .Controls(i_i).Size.Height = 0 Then
    '                    o = 0
    '                Else
    '                    o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
    '                End If

    '                .Controls(i_i).Width = n
    '                .Controls(i_i).Height = o

    '                For Each cControl In .Controls(i_i).Controls

    '                    If cControl.Location.X = 0 Then
    '                        R = 0
    '                    Else
    '                        R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
    '                    End If
    '                    If cControl.Location.Y = 0 Then
    '                        S = 0
    '                    Else
    '                        S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
    '                    End If

    '                    cControl.Left = R
    '                    cControl.Top = S


    '                    If cControl.Size.Width = 0 Then
    '                        P = 0
    '                    Else
    '                        P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
    '                    End If

    '                    If cControl.Size.Height = 0 Then
    '                        Q = 0
    '                    Else
    '                        Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
    '                    End If

    '                    cControl.Width = P
    '                    cControl.Height = Q
    '                Next
    '            ElseIf TypeOf .Controls(i_i) Is GroupBox Then


    '                If .Controls(i_i).Location.X = 0 Then
    '                    L = 0
    '                Else
    '                    If Controls(i_i).Name = "GroupBox1" Then
    '                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

    '                        If U = 800 Then
    '                            L = L + 50
    '                        End If
    '                        If U = 1280 Then
    '                            L = L + 50
    '                        End If
    '                        If U = 1360 Then
    '                            L = L + 75
    '                        End If
    '                        If U = 1366 Then
    '                            L = L + 75
    '                        End If
    '                    Else
    '                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

    '                        ' L = L - 5
    '                    End If
    '                End If

    '                If .Controls(i_i).Location.Y = 0 Then
    '                    L = 0

    '                Else
    '                    M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
    '                End If

    '                .Controls(i_i).Left = L
    '                .Controls(i_i).Top = M
    '                If .Controls(i_i).Size.Width = 0 Then
    '                    n = 0
    '                Else
    '                    n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
    '                End If
    '                If .Controls(i_i).Size.Height = 0 Then
    '                    o = 0
    '                Else
    '                    o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
    '                End If

    '                .Controls(i_i).Width = n
    '                .Controls(i_i).Height = o

    '                For Each cControl In .Controls(i_i).Controls

    '                    If cControl.Location.X = 0 Then
    '                        R = 0
    '                    Else
    '                        R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
    '                    End If
    '                    If cControl.Location.Y = 0 Then
    '                        S = 0
    '                    Else
    '                        S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
    '                    End If

    '                    cControl.Left = R
    '                    cControl.Top = S


    '                    If cControl.Size.Width = 0 Then
    '                        P = 0
    '                    Else
    '                        P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
    '                    End If

    '                    If cControl.Size.Height = 0 Then
    '                        Q = 0
    '                    Else
    '                        Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
    '                    End If

    '                    cControl.Width = P
    '                    cControl.Height = Q
    '                Next
    '            ElseIf TypeOf .Controls(i_i) Is Label Then
    '                If .Controls(i_i).Location.X = 0 Then
    '                    L = 0
    '                Else
    '                    L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
    '                End If
    '                If .Controls(i_i).Location.Y = 0 Then
    '                    L = 0

    '                Else
    '                    M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
    '                End If

    '                .Controls(i_i).Left = L
    '                .Controls(i_i).Top = M
    '                If .Controls(i_i).Size.Width = 0 Then
    '                    n = 0
    '                Else
    '                    n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
    '                End If
    '                If .Controls(i_i).Size.Height = 0 Then
    '                    o = 0
    '                Else
    '                    o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
    '                End If

    '                .Controls(i_i).Width = n
    '                .Controls(i_i).Height = o
    '            End If
    '        Next i_i
    '    End With
    'End Sub

    'Private Sub Raju_Resize(ByVal sender As Object, _
    '      ByVal e As System.EventArgs) Handles Me.Resize

    '    Dim RW As Double = (Me.Width - CW) / CW ' Ratio change of width
    '    Dim RH As Double = (Me.Height - CH) / CH ' Ratio change of height
    '    For Each Ctrl As Control In Controls
    '        Ctrl.Width += CInt(Ctrl.Width * RW)
    '        Ctrl.Height += CInt(Ctrl.Height * RH)
    '        Ctrl.Left += CInt(Ctrl.Left * RW)
    '        Ctrl.Top += CInt(Ctrl.Top * RH)
    '    Next
    '    CW = Me.Width
    '    CH = Me.Height

    'End Sub

    Private Sub FillUomMaster()
        Dim i As Integer
        Dim sqlstring As String
        chklst_Uom.Items.Clear()
        sqlstring = "SELECT ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM UOMMASTER WHERE ISNULL(FREEZE,'')<>'Y' ORDER BY UOMDESC"
        gconnection.getDataSet(sqlstring, "UOMMASTER")
        If gdataset.Tables("UOMMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("UOMMASTER").Rows.Count - 1
                With gdataset.Tables("UOMMASTER").Rows(i)
                    chklst_Uom.Items.Add(Trim(CStr(.Item("UOMCODE")) & "-->" & .Item("UOMDESC")))
                End With
            Next
        End If
    End Sub

    Private Sub Frm_InventoryItemmastervb_Activated(sender As Object, e As EventArgs) Handles Me.Activated
      
    End Sub

    Private Sub Frm_InventoryItemmastervb_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            clearoperation()
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
            voidoperation()
            Exit Sub
        End If
        If e.KeyCode = Keys.F4 Then
            Call Cmd_ItemCode_Click(Cmd_ItemCode, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
            ' addoperation()
            Call Cmd_Add_Click(Cmd_ItemCode, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 And Cmd_View.Visible = True Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F1 And cmd_rpt.Visible = True Then
            Call cmd_rpt_Click(cmd_rpt, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Me.Close()
            Exit Sub
        End If

    End Sub

    Private Sub Frm_InventoryItemmastervb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        Me.Visible = False

        Me.DoubleBuffered = True

        If UCase(gShortname) = "UC" Then
            TXT_RATE.Visible = True
            TXT_RATE.ReadOnly = False
            Label13.Visible = True
        Else
            Txt_Rate.Visible = False

            Label13.Visible = False
        End If

        ' ADDED BY SRI FOR EXPIRY DATE AND BATCH NO
        ''''''Starts

        Dim BATCHNO, EXPIRY, shelving As String
        Dim sql As String = "Select ISNULL(BatchnoReq,'N')AS BatchnoReq,ISNULL(ExpiryReq,'N')AS ExpiryReq,ISNULL(ShelvingReq,'N')AS ShelvingReq   FROM INV_LINKSETUP "
        gconnection.getDataSet(sql, "INV_LINKSETUP")
        BATCHNO = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("BatchnoReq")
        EXPIRY = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("ExpiryReq")
        shelving = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("ShelvingReq")
        If BATCHNO = "Y" Then
            Label14.Visible = True
            Cmb_BatchNo.Visible = True
        End If
        If EXPIRY = "Y" Then
            Label16.Visible = True
            Cmb_Expiry.Visible = True
        End If
        If shelving = "Y" Then
            Label18.Visible = True
            CMB_Shelving.Visible = True
        End If
        ''''''''Ends


        GroupBox2.Controls.Add(AxfpSpread2)
        AxfpSpread2.Location = New Point(10, 10)
        FormBorderStyle = Windows.Forms.FormBorderStyle.None
        GroupBox3.Controls.Add(AxfpSpread1)
        AxfpSpread1.Location = New Point(10, 10)
        Dim t1, u1 As Integer
        t1 = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        u1 = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        If UCase(gShortname) = "TMA" Then

            txt_GroupCode.Location = New Point(119, 12)
            txt_ItemCode.Location = New Point(119, 39)
            txt_GroupDesc.Location = New Point(239, 14)
            cmd_GroupCode.Location = New Point(216, 12)
            Cmd_ItemCode.Location = New Point(216, 36)
            Label7.Location = New Point(239, 39)
            lbl_GroupCode.Location = New Point(1, 18)
            lbl_ItemCode.Location = New Point(1, 43)
        End If

        If UCase(gShortname) = "CCL" Or UCase(gShortname) = "SATC" Then
            CBO_TAXREBATE.SelectedItem = "YES"
            CBO_TAXREBATE.Enabled = False
        End If
        CBO_TAXREBATE.SelectedItem = "YES"


        If Mid(UCase(gShortname), 1, 3) = "NIZ" Then
            CBO_TAXREBATE.SelectedItem = "NO"
            CBO_TAXREBATE.Enabled = False
        End If

        'AxfpSpread1.Width = GroupBox3.Width - 10
        FillUomMaster()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        'txt_ItemCode.Focus()
        If UCase(gShortname) = "TMA" Then
            'Call GetLastNo()
            LBL_LAST.Visible = True
        End If
        '' Added by SRI For Sale Rate & Purchase Rate
        If UCase(gShortname) = "KGA" Or UCase(gShortname) = "DC" Then
            Label19.Visible = True
            Label20.Visible = True
            txt_Purchaserate.Visible = True
            txt_salerate.Visible = True
            txt_Purchaserate.Text = "0.00"
            txt_salerate.Text = "0.00"
        End If

        If UCase(gShortname) = "KSCA" Then
            Label21.Visible = True
            TXT_MRPRATE.Visible = True
            TXT_MRPRATE.Text = "0.00"
        End If
        ''
        If Not String.IsNullOrEmpty(ItemcodeM) Then
            txt_ItemCode.Text = ItemcodeM
            Call txt_ItemCode_Validated(sender, e)
        End If
        Me.Visible = True
        txt_ItemCode.Focus()
        If UCase(gShortname) = "CSC" Then
            Label19.Visible = True
            Label20.Visible = True
            txt_Purchaserate.Visible = True
            txt_salerate.Visible = True
            txt_Purchaserate.Text = "0.00"
            txt_salerate.Text = "0.00"
        End If


        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub
    Private Sub GetLastNo()
        Dim SQLSTRING As String
        Dim DR As DataRow
        SQLSTRING = "SELECT ISNULL(max(cast(ITEMCODE as INT)),0) as ITEMCODE FROM INV_INVENTORYITEMMASTER where ISNUMERIC(ITEMCODE)=1 AND  ITEMCODE like '%[0-9]%' AND GROUPCODE='" & Trim(txt_GroupCode.Text) & "'"
        gconnection.getDataSet(SQLSTRING, "INV_INVENTORYITEMMASTER")
        If gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0 Then
            Me.LBL_LAST.Text = "Last No IS : " & " " & gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(0).Item(0)
            txt_ItemCode.Text = Val(gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(0).Item(0)) + 1

        Else
            Me.LBL_LAST.Text = "Last No" & " " & 0

        End If

    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "ITEM Master"

        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Me.Cmd_View.Enabled = False
        Me.cmd_auth.Enabled = False
        Me.cmd_rpt.Enabled = False
        Me.cmd_export.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Me.cmd_auth.Enabled = True
                    Me.cmd_rpt.Enabled = True
                    Me.cmd_export.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                    Me.cmd_rpt.Enabled = True
                    Me.cmd_export.Enabled = True
                End If
                If Right(x) = "U" Then
                    Me.cmd_auth.Enabled = True
                End If
            Next
        End If
    End Sub


    Private Sub Cmd_ItemCode_Click(sender As Object, e As EventArgs)

        If Cmd_ItemCode.Text = "" Then
            If UCase(gShortname) = "TMA" Then
                If txt_GroupCode.Text = "" Then
                    gSQLString = "SELECT DISTINCT(itemcode),itemname  FROM INV_InventoryItemMaster"
                Else
                    gSQLString = "SELECT DISTINCT(itemcode),itemname  FROM INV_InventoryItemMaster "
                End If
            Else
                gSQLString = "SELECT DISTINCT(itemcode),itemname  FROM INV_InventoryItemMaster"

            End If
            If UCase(gShortname) = "TMA" Then
                M_WhereCondition = "WHERE GROUPCODE='" & Trim(txt_GroupCode.Text) & "'"
            Else
                M_WhereCondition = ""
            End If


            Dim vform As New ListOperattion1
            vform.Field = "ITEMNAME,ITEMCODE"
            vform.vFormatstring = "          ITEM CODE              |                        ITEM DESCRIPTION                   "
            vform.vCaption = "INVENTORY ITEM MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_ItemCode.Text = Trim(vform.keyfield & "")
                Call txt_ItemCode_Validated(txt_ItemCode, e)
            End If
            vform.Close()
            vform = Nothing
        End If

    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()

    End Sub
    Private Sub bindstoreuomlink()
        Dim sql As String = "select itemcode,storecode,reportUOM,reportdecimaluom,void from inv_Inventoryuomstorelink where itemcode='" + txt_ItemCode.Text + "' and isnull(void,'')<>'Y'"
        gconnection.getDataSet(sql, "inv_Inventoryuomstorelink")
        For i As Integer = 1 To gdataset.Tables("inv_Inventoryuomstorelink").Rows.Count
            AxfpSpread2.Row = i
            AxfpSpread2.Col = 1
            AxfpSpread2.Text = gdataset.Tables("inv_Inventoryuomstorelink").Rows(i - 1).Item("storecode")
            AxfpSpread2.Row = i
            AxfpSpread2.Col = 2
            AxfpSpread2.Text = gdataset.Tables("inv_Inventoryuomstorelink").Rows(i - 1).Item("reportUOM")
            AxfpSpread2.Row = i
            AxfpSpread2.Col = 3
            AxfpSpread2.Text = gdataset.Tables("inv_Inventoryuomstorelink").Rows(i - 1).Item("reportdecimaluom")
            AxfpSpread2.Row = i
            AxfpSpread2.Col = 4
            AxfpSpread2.Text = gdataset.Tables("inv_Inventoryuomstorelink").Rows(i - 1).Item("void")

        Next

    End Sub



    Private Sub bindopeningstock()
        Dim sql As String = "select itemcode,storecode,uom,minqty,maxqty,reorder,ISNULL(openningqty,0) AS openningqty,ISNULL(openningvalue,0) AS openningvalue,void,ISNULL(closingqty,0)AS closingqty,ISNULL(closingvalue,0 )AS closingvalue  from inv_InventoryOpenningstock where itemcode='" + txt_ItemCode.Text + "'"
        gconnection.getDataSet(sql, "inv_InventoryOpenningstock")
        For i As Integer = 1 To gdataset.Tables("inv_InventoryOpenningstock").Rows.Count
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            AxfpSpread1.Text = gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("storecode")
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 2
            AxfpSpread1.Text = gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("uom")
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 3
            AxfpSpread1.Text = gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("minqty")
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 4
            AxfpSpread1.Text = gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("maxqty")
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 5
            AxfpSpread1.Text = gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("reorder")
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 6
            AxfpSpread1.Text = gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("openningqty")
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 7
            AxfpSpread1.Text = gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("openningvalue")

            AxfpSpread1.Row = i
            AxfpSpread1.Col = 8
            AxfpSpread1.Text = gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("void")

            sql = " select ISNULL(closingstock,0 ) AS closingstock, ISNULL(closingvalue,0) AS closingvalue from closingqty where trns_seq=( select max(trns_seq) from closingqty where  itemcode='" + txt_ItemCode.Text + "' AND STORECODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("storecode")) + "' ) "
            gconnection.getDataSet(sql, "closingvalue")

            If (gdataset.Tables("closingvalue").Rows.Count > 0) Then
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 9
                AxfpSpread1.Text = gdataset.Tables("closingvalue").Rows(0).Item("closingstock")
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 10
                AxfpSpread1.Text = gdataset.Tables("closingvalue").Rows(0).Item("closingvalue")

            Else
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 9
                AxfpSpread1.Text = gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("closingqty")
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 10
                AxfpSpread1.Text = gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("closingvalue")

            End If


            sql = "select * from closingqty where  itemcode='" + txt_ItemCode.Text + "' AND STORECODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(i - 1).Item("storecode")) + "' and ttype<>'OPENNING' "
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                For J As Integer = 1 To 10
                    If gShortname <> "UC" Then
                        If J = 3 Or J = 4 Or J = 5 Or J = 7 Then
                            AxfpSpread1.Col = J
                            AxfpSpread1.Row = i


                            'AxfpSpread1.Lock = False
                        Else
                            AxfpSpread1.Col = J
                            AxfpSpread1.Row = i
                            AxfpSpread1.Lock = True
                        End If
                    End If


                Next


            Else
                For J As Integer = 1 To 10
                    AxfpSpread1.Col = J
                    AxfpSpread1.Row = i
                    AxfpSpread1.Lock = False
                Next
            End If

        Next

    End Sub
    Private Sub bindopeningstockRSI()
        Dim sql As String = "select itemcode,storecode,uom,minqty,maxqty,reorder,ISNULL(openningqty,0) AS openningqty,ISNULL(openningvalue,0) AS openningvalue,void,ISNULL(closingqty,0)AS closingqty,ISNULL(closingvalue,0 )AS closingvalue  from inv_InventoryOpenningstock where itemcode='" + txt_ItemCode.Text + "'"
        gconnection.getDataSet(sql, "inv_InventoryOpenningstock")
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            For J As Integer = 1 To 10
                AxfpSpread1.Col = J
                AxfpSpread1.Row = i
                AxfpSpread1.Lock = True
            Next
        Next
    End Sub
    Private Sub txt_ItemCode_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Tab) Then
            If (txt_ItemCode.Text <> "") Then
                txt_ItemCode_Validated(sender, e)
            Else
                Cmd_ItemCode_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub txt_ItemCode_Validated(sender As Object, e As EventArgs)
        Try
            If Trim(txt_ItemCode.Text) <> "" Then
                Dim sql As String = "  select DISTINCT ISNULL(I.itemcode,'') AS itemcode ,ISNULL(I.itemname,'') AS ITEMNAME,ISNULL(I.groupcode,'') AS groupcode, ISNULL(I.category,'') AS category,ISNULL(I.subGroupcode,'') AS subGroupcode, "
                sql = sql & "   ISNULL(I.subsubgroupcode,'') AS subsubgroupcode, ISNULL(I.category,'') AS category, ISNULL(I.abccategory,'') AS abccategory,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
                sql = sql & "       ISNULL(I.TaxRebate,'') AS TaxRebate, ISNULL(I.batchprocess,'') AS batchprocess, ISNULL(I.Profitper,0) AS Profitper, ISNULL(I.void,'') AS VOID, I.AddDate, I.addUSER, I.UPDATEUSER, I.UPDATEdate,"
                If GBATCHNO = "Y" Then
                    sql = sql & "isnull(I.Batchno,'') as Batchno,isnull(I.ExpiryDate,'') as ExpiryDate,"
                End If
                If GSHELVING = "Y" Then
                    sql = sql & "isnull(I.shelving,'') as shelving, "
                End If
                If UCase(gShortname) = "KGA" Or UCase(gShortname) = "DC" Or UCase(gShortname) = "CSC" Then
                    sql = sql & "ISNULL(I.SALERATE,0) AS SALERATE,ISNULL(I.PURCHASERATE,0) AS PURCHASERATE ,"
                End If
                If UCase(gShortname) = "KSCA" Then
                    sql = sql & "ISNULL(I.MRPRATE,0) AS MRPRATE,"
                End If

                sql = sql & " I.voiduser,I.voiddate,ISNULL(g.Groupdesc,'') AS Groupdesc ,ISNULL(s.Subgroupdesc,'') AS Subgroupdesc,ISNULL(p.subsubgroupdesc,'') AS subsubgroupdesc,ISNULL(c.CATEGORYDESC,'') AS CATEGORYDESC,isnull(I.stockcategory,'') as stockcategory,ISNULL(COMPANYREQ ,'NO') AS COMPANYREQ ,ISNULL(COMPANYcode ,'') AS COMPANYcode ,ISNULL(COMPANYDESC ,'') AS COMPANYDESC,ISNULL(SPLCESS,0 ) AS SPLCESS,ISNULL(HSNNO,'') AS HSNNO,ISNULL(SALEITEM,'NO') AS SALEITEM,ISNULL(PRATE,0) AS PRATE from INV_InventoryItemMaster I inner join "
                sql = sql & "    INVENTORYCATEGORYMASTER C on I.category=c.CATEGORYCODE "
                sql = sql & "    LEFT OUTER join InventoryGroupMaster g  on i.groupcode=g.Groupcode"
                sql = sql & "    LEFT OUTER join InventorySubGroupMaster s on i.subGroupcode=s.Subgroupcode"
                sql = sql & "    LEFT OUTER join InventorySubSubGroupMaster p on i.subsubgroupcode=p.subsubgroupcode where   Itemcode='" + Trim(txt_ItemCode.Text) + "'"
                'Dim sql As String = "SELECT Itemcode,Itemname,Groupcode,groupname,subGroupcode,subgroupname,subsubgroupcode,subsubgroupname,Category,categorydesc,AbcCategory,TaxRebate,batchprocess "
                'sql = sql & "   FROM INV_InventoryItemMaster where  Itemcode='" + Trim(txt_ItemCode.Text) + "'"
                gconnection.getDataSet(sql, "INV_InventoryItemMaster")
                If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then

                    txt_ItemCode.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("Itemcode")
                    txt_ItemCode.ReadOnly = True

                    txt_ItemName.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("Itemname")
                    txt_GroupCode.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("Groupcode")
                    txt_GroupDesc.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("Groupdesc")
                    txt_SubGroupCode.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("subGroupcode")
                    txt_SubGroupDesc.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("Subgroupdesc")
                    txt_SubSubGroupCode.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("subsubgroupcode")
                    txt_SubSubGroupDesc.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("subsubgroupdesc")
                    TXT_CATEGORY.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("categorydesc")
                    Txt_Categorycode.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("category")
                    Cbo_ABC_category.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("AbcCategory")
                    CBO_TAXREBATE.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("TaxRebate")
                    CmbBatch.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess")
                    If UCase(gShortname) = "KGA" Or UCase(gShortname) = "DC" Or UCase(gShortname) = "CSC" Then
                        txt_salerate.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("SALERATE")
                        txt_Purchaserate.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("PURCHASERATE")
                    End If
                    If UCase(gShortname) = "KSCA" Then
                        TXT_MRPRATE.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("MRPRATE")
                    End If
                    If GBATCHNO = "Y" Then
                        Cmb_BatchNo.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("Batchno")
                        Cmb_Expiry.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("ExpiryDate")
                    End If
                    If GSHELVING = "Y" Then
                        CMB_Shelving.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("shelving")
                    End If
                    TxtProfitPer.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("Profitper")
                    TxtSPLCESS.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("SPLCESS")
                    TXT_HSNNO.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("HSNNO")
                    txtstock.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("STOCKUOM").ToString()
                    Cmbstockcategory.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("STOCKcategory").ToString()
                    CMB_SALEITEM.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("SALEITEM").ToString()

                    CB_ComYesNo.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("COMPANYREQ").ToString()
                    Txt_companycode.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("COMPANYcode").ToString()
                    TXT_COMPANYDESC.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("COMPANYDESC").ToString()
                    Txt_Rate.Text = gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("PRATE")
                    If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("void") = "Y") Then
                        Me.labfreeze.Visible = True
                        Me.labfreeze.Text = "Record Freezed  On : " & Format(CDate(gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("voiddate")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Text = "UnVoid[F8]"
                        Cmd_Freeze.Enabled = True
                        Me.Cmd_Add.Enabled = False
                    Else
                        Me.labfreeze.Visible = False
                        Me.labfreeze.Text = ""
                        Me.Cmd_Freeze.Text = "Void[F8]"
                        Cmd_Freeze.Enabled = True
                        Me.Cmd_Add.Enabled = True

                    End If

                    If Mid(UCase(gShortname), 1, 3) = "HGA" Then
                        txt_GroupCode.ReadOnly = True
                        txt_SubGroupCode.ReadOnly = True
                        txt_SubSubGroupCode.ReadOnly = True
                        txt_SubSubGroupCode.ReadOnly = True
                        Txt_Categorycode.ReadOnly = True

                        cmd_GroupCode.Enabled = False
                        cmd_SubGroupCode.Enabled = False
                        cmd_SubSubGroupCode.Enabled = False
                        BttnCategory_Help.Enabled = False
                    End If

                    Me.Cmd_Add.Text = "Update[F7]"

                    Dim ITEMCODE As String
                    Dim I, J As Integer
                    sqlstring = "SELECT ISNULL(Tranuom,'') AS Tranuom FROM INVITEM_TRANSUOM_LINK WHERE Itemcode ='" & Trim(txt_ItemCode.Text) & "'"
                    gconnection.getDataSet(sqlstring, "UOMMASTER")
                    Dim TYPE() As String
                    If gdataset.Tables("UOMMASTER").Rows.Count > 0 Then
                        For I = 0 To gdataset.Tables("UOMMASTER").Rows.Count - 1
                            ITEMCODE = Trim(gdataset.Tables("UOMMASTER").Rows(I).Item("Tranuom"))
                            For J = 0 To chklst_Uom.Items.Count - 1
                                TYPE = Split(chklst_Uom.Items(J), "-->")
                                If TYPE(0) = ITEMCODE Then
                                    chklst_Uom.SetItemChecked(J, True)
                                End If
                            Next J
                        Next I
                    End If
                Else
                    Me.labfreeze.Visible = False
                    Me.labfreeze.Text = "Record Freezed  On "
                    Me.Cmd_Add.Text = "Add [F7]"
                    txt_ItemCode.ReadOnly = False
                    txt_ItemName.Focus()
                End If
                bindopeningstock()
                bindstoreuomlink()
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
            ElseIf UCase(gShortname) = "TMA" Then
                txt_GroupCode.Text = ""
                txt_GroupCode.Focus()
            Else

                txt_ItemCode.Text = ""
                txt_ItemCode.Focus()
            End If

            'If gShortname = "RSAOI" Then
            '    bindopeningstockRSI()
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmd_GroupCode_Click(sender As Object, e As EventArgs)
        gSQLString = "SELECT Groupcode,Groupdesc FROM inventorygroupmaster"
        M_WhereCondition = " WHERE freeze='N' "
        Dim vform As New ListOperattion1
        vform.Field = "GROUPDESC,GROUPCODE"
        vform.vFormatstring = "         GROUP CODE              |                  GROUP DESCRIPTION                                                                                              "
        vform.vCaption = "GROUP MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_GroupCode.Text = Trim(vform.keyfield & "")
            Call txt_GroupCode_Validated(txt_GroupCode, e)
            If UCase(gShortname) = "TMA" Then
                Call GetLastNo()
                'txt_ItemCode.Focus()
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_GroupCode_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Tab) Then
            If (txt_GroupCode.Text = "") Then
                cmd_GroupCode_Click(sender, e)
            Else
                txt_GroupCode_Validated(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_GroupCode_Validated(sender As Object, e As EventArgs)
        If Trim(txt_GroupCode.Text) <> "" Then
            sqlstring = "SELECT * FROM inventorygroupmaster WHERE Groupcode='" & Trim(txt_GroupCode.Text) & "' AND freeze='N'"
            gconnection.getDataSet(sqlstring, "inventorygroupmaster")
            If gdataset.Tables("inventorygroupmaster").Rows.Count > 0 Then
                txt_GroupCode.Text = Trim(gdataset.Tables("inventorygroupmaster").Rows(0).Item("Groupcode"))
                txt_GroupDesc.Text = Trim(gdataset.Tables("inventorygroupmaster").Rows(0).Item("Groupdesc"))
                txt_SubGroupCode.Focus()
                txt_GroupDesc.ReadOnly = True
            Else
                txt_GroupCode.Text = ""
                txt_GroupDesc.ReadOnly = False
                txt_GroupCode.Focus()
            End If
        Else
            txt_GroupCode.Text = ""
            'txt_GroupCode.Focus()
        End If
    End Sub

    Private Sub cmd_SubGroupCode_Click(sender As Object, e As EventArgs)
        gSQLString = "SELECT ISNULL(SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(SUBGROUPDESC,'') AS SUBGROUPDESC FROM INVENTORYSUBGROUPMASTER"
        M_WhereCondition = " WHERE GROUPCODE='" & Trim(txt_GroupCode.Text) & "'  AND ISNULL(FREEZE,'') <> 'Y' "
        Dim vform As New ListOperattion1
        vform.Field = "SUBGROUPDESC,SUBGROUPCODE"
        vform.vFormatstring = "        SUB GROUP CODE              |            SUB GROUP DESCRIPTION                                                                                       "
        vform.vCaption = "SUBGROUP MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_SubGroupCode.Text = Trim(vform.keyfield & "")
            Call txt_SubGroupCode_Validated(txt_SubGroupCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub



    Private Sub txt_SubGroupCode_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Or (e.KeyCode = Keys.Tab) Then
            If (txt_SubGroupCode.Text = "") Then
                cmd_SubGroupCode_Click(sender, e)
            Else
                txt_SubGroupCode_Validated(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_SubGroupCode_Validated(sender As Object, e As EventArgs)
        If Trim(txt_SubGroupCode.Text) <> "" Then
            sqlstring = "SELECT isnull(categorycode,'') as categorycode,isnull(categorydesc,'') as categorydesc,isnull(groupcode,'') as groupcode,isnull(groupdesc,'') as groupdesc,isnull(Subgroupcode,'') as Subgroupcode,isnull(Subgroupdesc,'') as Subgroupdesc,isnull(SUBSubgroupcode,'') as SUBSubgroupcode,isnull(SUBSubgroupdesc,'') as SUBSubgroupdesc FROM catDetails WHERE Groupcode='" & Trim(txt_GroupCode.Text) & "' AND SUBGROUPCODE = '" & Trim(txt_SubGroupCode.Text) & "' "
            gconnection.getDataSet(sqlstring, "catDetails")
            If gdataset.Tables("catDetails").Rows.Count > 0 Then
                Txt_Categorycode.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("categorycode"))
                TXT_CATEGORY.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("categorydesc"))
                txt_GroupCode.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("groupcode"))
                txt_GroupDesc.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("groupdesc"))
                txt_SubGroupCode.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("Subgroupcode"))
                txt_SubGroupDesc.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("Subgroupdesc"))
                txt_SubSubGroupCode.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("SUBSubgroupcode"))
                txt_SubSubGroupDesc.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("SUBSubgroupdesc"))
                cmd_SubSubGroupCode.Focus()
                txt_SubGroupDesc.ReadOnly = True
            Else
                txt_SubGroupCode.Text = ""
                txt_SubGroupCode.Focus()
            End If
        Else
            txt_SubGroupCode.Text = ""
            'txt_SubGroupCode.Focus()
        End If
    End Sub


    Private Sub cmd_SubSubGroupCode_Click(sender As Object, e As EventArgs)

        gSQLString = "SELECT ISNULL(SUBSUBGROUPCODE,'') AS SUBSUBGROUPCODE,ISNULL(SUBSUBGROUPDESC,'') AS SUBSUBGROUPDESC FROM INVENTORYSUBSUBGROUPMASTER"
        'M_WhereCondition = " WHERE SUBGROUPCODE='" & Trim(txt_SubGroupCode.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' "
        M_WhereCondition = " WHERE  ISNULL(FREEZE,'') <> 'Y' "
        Dim vform As New ListOperattion1
        vform.Field = "SUBSUBGROUPCODE,SUBSUBGROUPDESC"
        vform.vFormatstring = "         SUB SUB GROUP CODE     |               SUB SUB GROUP DESCRIPTION                                                                          "
        vform.vCaption = "SUBSUBGROUP MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_SubSubGroupCode.Text = Trim(vform.keyfield & "")
            Call txt_SubSubGroupCode_Validated(txt_SubSubGroupCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_SubSubGroupCode_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            If (txt_SubSubGroupCode.Text = "") Then
                cmd_SubSubGroupCode_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_SubSubGroupCode_Validated(sender As Object, e As EventArgs)
        If Trim(txt_SubSubGroupCode.Text) <> "" Then
            'sqlstring = "SELECT * FROM inventorySUBsubgroupmaster WHERE Groupcode='" & Trim(txt_GroupCode.Text) & "' AND SUBGROUPCODE = '" & Trim(txt_SubSubGroupCode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
            sqlstring = "SELECT * FROM catDetails WHERE SUBSUBGROUPCODE = '" & Trim(txt_SubSubGroupCode.Text) & "' "
            gconnection.getDataSet(sqlstring, "catDetails")
            If gdataset.Tables("catDetails").Rows.Count > 0 Then
                Txt_Categorycode.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("categorycode"))
                TXT_CATEGORY.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("categorydesc"))
                txt_GroupCode.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("groupcode"))
                txt_GroupDesc.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("groupdesc"))
                txt_SubGroupCode.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("Subgroupcode"))
                txt_SubGroupDesc.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("Subgroupdesc"))
                txt_SubSubGroupCode.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("SUBSubgroupcode"))
                txt_SubSubGroupDesc.Text = Trim(gdataset.Tables("catDetails").Rows(0).Item("SUBSubgroupdesc"))
                txt_SubSubGroupDesc.ReadOnly = True
                Cbo_ABC_category.Focus()

            Else
                txt_SubSubGroupCode.Text = ""
                txt_SubSubGroupDesc.ReadOnly = False
                txt_SubSubGroupCode.Focus()
            End If
        Else
            txt_SubSubGroupCode.Text = ""
            Txt_Categorycode.Focus()

        End If
    End Sub

    Private Sub BttnCategory_Help_Click(sender As Object, e As EventArgs)
        gSQLString = "SELECT DISTINCT CATEGORYCODE,categorydesc FROM INVENTORYCATEGORYMASTER "
        M_WhereCondition = " where isnull(freeze,'N')='N'"
        Dim vform As New ListOperattion1
        vform.Field = "CATEGORYCODE"
        vform.vFormatstring = "CATEGORYCODE                                                      "
        vform.vCaption = "INVENTORY CATEGORY MASTER HELP"
        vform.KeyPos = 0
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_Categorycode.Text = Trim(vform.keyfield & "")
            Call Txt_Categorycode_Validated(Txt_Categorycode, e)
        End If
        vform.Close()
        vform = Nothing

    End Sub

    Private Sub Txt_Categorycode_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            If (Txt_Categorycode.Text <> "") Then
                Txt_Categorycode_Validated(sender, e)
            Else
                BttnCategory_Help_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Txt_Categorycode_Validated(sender As Object, e As EventArgs)
        If Trim(Txt_Categorycode.Text) <> "" Then
            'sqlstring = "SELECT * FROM inventorySUBsubgroupmaster WHERE Groupcode='" & Trim(txt_GroupCode.Text) & "' AND SUBGROUPCODE = '" & Trim(txt_SubSubGroupCode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
            sqlstring = "SELECT categorycode,categorydesc FROM INVENTORYCATEGORYMASTER WHERE categorycode = '" & Trim(Txt_Categorycode.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "inventorysubgroupmaster")
            If gdataset.Tables("inventorysubgroupmaster").Rows.Count > 0 Then
                Txt_Categorycode.Text = Trim(gdataset.Tables("inventorysubgroupmaster").Rows(0).Item("categorycode"))
                TXT_CATEGORY.Text = Trim(gdataset.Tables("inventorysubgroupmaster").Rows(0).Item("categorydesc"))
                Cbo_ABC_category.Focus()
                TXT_CATEGORY.ReadOnly = True
            Else
                Txt_Categorycode.Text = ""
                TXT_CATEGORY.ReadOnly = False
                Txt_Categorycode.Focus()
            End If
        Else
            Txt_Categorycode.Text = ""
            Cbo_ABC_category.Focus()
        End If
    End Sub




    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Dim FRM As New ReportDesigner
        If txt_ItemCode.Text.Length > 0 Then
            tables = " FROM INV_InventoryItemMaster WHERE itemcode ='" & txt_ItemCode.Text & "' "
        Else
            tables = "FROM INV_InventoryItemMaster "
        End If
        Gheader = "STOREMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"itemcode", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"itemname", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"groupcode", "9"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"groupname", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"subgroupcode", "12"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"subgroupname", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"subsubgroupcode", "12 "}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"subsubgroupname", "6 "}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Category", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"categorydesc", "8"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"AbcCategory", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"TaxRebate", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"batchprocess", "7"}
        FRM.DataGridView1.Rows.Add(ROW)

        ROW = New String() {"void", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adduser", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adddate", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEdate", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub cmd_rpt_Click(sender As Object, e As EventArgs) Handles cmd_rpt.Click
        Dim rViewer As New Viewer
        Dim sqlstring, SSQL As String
        Dim r As New Rpt_ItemMaster


        sqlstring = "SELECT *,RATE AS PURCHASERATE,ISNULL(TAXCODE,'') AS SUBGROUPNAME FROM INV_InventoryItemMaster  I INNER JOIN closingqty V ON I.itemcode=V.itemcode"
        sqlstring = sqlstring & "  LEFT OUTER JOIN Itemtaxtagging T ON T.ItemCode=I.itemcode  where CAST(Trndate AS DATE)<= cast(convert(varchar(11),GETDATE(),106)as datetime) and I.Itemcode=V.itemcode "

        sqlstring = sqlstring & "  AND TRNS_SEQ = (select max(trns_seq) From closingqty d where V.itemcode=d.itemcode AND ttype IN ('GRN','OPENNING') and CAST(Trndate AS dATE)"
        sqlstring = sqlstring & "  <= cast(convert(varchar(11),GETDATE(),106)as datetime) )"
        gconnection.getDataSet(sqlstring, "inventoryitem1")
        If gdataset.Tables("inventoryitem1").Rows.Count > 0 Then

            rViewer.ssql = sqlstring
            rViewer.Report = r
            rViewer.TableName = "INV_InventoryItemMaster"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text13")
            textobj1.Text = MyCompanyName
            Dim textobj2 As TextObject
            textobj2 = r.ReportDefinition.ReportObjects("Text21")
            textobj2.Text = gUsername
            rViewer.Show()

        Else
            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        End If
    End Sub

    Private Sub cmd_export_Click(sender As Object, e As EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "INV_InventoryItemMaster"
        sqlstring = "select * from INV_InventoryItemMaster"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub cmd_auth_Click(sender As Object, e As EventArgs) Handles cmd_auth.Click
        Authocheck("INVENTORY", "Frm_InventoryItemmastervb", gUsername, "Inventoryitemmaster", "itemcode", Me)

    End Sub
    Public Sub checkValidation()
        boolchk = False
        If Trim(txt_ItemCode.Text) = "" Then
            MessageBox.Show(" Item Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_ItemCode.Focus()
            Exit Sub
        ElseIf txt_ItemCode.TextLength > 10 Then
            MessageBox.Show(" Item Code Length should be max Upto 10 digit ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_ItemCode.Focus()
            Exit Sub

        End If
        '''********** Check  ItemName Can't be blank *********************'''
        If Trim(txt_ItemName.Text) = "" Then
            MessageBox.Show(" Item Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_ItemName.Focus()
            Exit Sub
        End If

        If labfreeze.Visible = True And Cmd_Freeze.Text = "Void[F8]" Then
            MessageBox.Show("   Item Already void u can't update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Call clearoperation()
            Exit Sub
        End If

        If Trim(TXT_CATEGORY.Text) = "" Then
            MessageBox.Show(" Category can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_CATEGORY.Focus()
            Exit Sub
        End If
        '''********** Check  GroupCode Can't be blank *********************''
        If Trim(txt_GroupCode.Text) = "" Then
            MessageBox.Show(" Group Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_GroupCode.Focus()
            Exit Sub
        End If
        '''********** Check  GroupDesc Can't be blank *********************'''
        If Trim(txt_GroupDesc.Text) = "" Then
            MessageBox.Show(" Group Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_GroupDesc.Focus()
            Exit Sub
        End If
        '''********** Check  SubGroupCode Can't be blank *********************'''
        If Trim(txt_SubGroupCode.Text) = "" Then
            MessageBox.Show(" SubGroup Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
        End If
        If Trim(txt_SubGroupDesc.Text) = "" Then
            MessageBox.Show(" SubGroup Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_SubGroupDesc.Focus()
            Exit Sub
        End If

        sqlstring = "SELECT * FROM CATDETAILS WHERE CATEGORYCODE='" & Txt_Categorycode.Text & "' AND GROUPCODE='" & txt_GroupCode.Text & "' AND SUBGROUPCODE='" & txt_SubGroupCode.Text & "' "
        gconnection.getDataSet(sqlstring, "CATDETAILS")
        If gdataset.Tables("CATDETAILS").Rows.Count > 0 Then

        Else
            MessageBox.Show(" Category, Groupcode and SubGroupcode not Matching Select Again...  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            txt_SubGroupCode.Focus()
            Exit Sub
        End If


        If Trim(txtstock.Text) = "" Then
            MessageBox.Show(" Stock UOM can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtstock.Focus()
            Exit Sub
        End If

        If CB_ComYesNo.Text = "YES" Then
            If Txt_companycode.Text = "" Then
                MessageBox.Show(" Company code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_companycode.Focus()
                Exit Sub
            End If

        End If
        If CMB_SALEITEM.Text = "YES" Then
            If Cmd_Add.Text = "Add [F7]" Then
                sqlstring = "SELECT * FROM ITEMMASTER WHERE ITEMCODE='" & txt_ItemCode.Text & "' AND ISNULL(Freeze,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "ITEMMASTER")
                If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                    MessageBox.Show(" Item code already existed in POS Item master.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_ItemCode.Focus()
                    Exit Sub

                End If
            End If
           
        End If

        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = i + 1
            AxfpSpread1.Col = 1
            Dim storecode As String = AxfpSpread1.Text
            If storecode = "" Then
                MessageBox.Show("Storecode can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            AxfpSpread1.Col = 2
            Dim UOM As String = AxfpSpread1.Text
            If UOM = "" Then
                MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Next
        For i As Integer = 0 To AxfpSpread2.DataRowCnt - 1
            AxfpSpread2.Row = i + 1
            AxfpSpread2.Col = 1
            Dim storecode As String = AxfpSpread2.Text
            If storecode = "" Then
                MessageBox.Show("Storecode can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            AxfpSpread2.Col = 2
            Dim UOM As String = AxfpSpread2.Text
            If UOM = "" Then
                MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        Next
        'For i As Integer = 0 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Col = 1
        '    Dim storecode As String = AxfpSpread1.Text
        '    AxfpSpread1.Col = 6
        '    Dim qty As String = Val(AxfpSpread1.Text)
        '    Dim qty1 As Double
        '    Dim batchyn As String
        '    Dim sql As String = "select qty,batchyn from closingqty where  itemcode='" + txt_ItemCode.Text + "' and storecode='" + storecode + "' "
        '    sql = sql & " and Trnno='Openning' "
        '    gconnection.getDataSet(sql, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '    End If
        '    sql = "select closingstock +" + Format(Val(qty - qty1), "0.00") + " from closingqty "
        '    sql = sql & "    where trndate>='" & Format(CDate(gFinancialyearStart), "dd/MMM/yyyy") & "' "
        '    sql = sql & "and closingstock +" + Format(Val(qty - qty1), "0.00") + " <0 "
        '    If batchyn = "Y" Then
        '        sql = sql & " and batchno='Openning'"
        '    End If
        '    gconnection.getDataSet(sql, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        MessageBox.Show("Updation create" + txt_ItemCode.Text + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        Exit Sub
        '    End If


        'Next

        boolchk = True
    End Sub
    Public Sub checkValidation1()
        boolchk = False
        Dim sql As String
        Dim chk As Boolean = False
        Dim storecode As String
        Dim Clqty As Double
       
        For J As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = J + 1
            AxfpSpread1.Col = 1
            storecode = AxfpSpread1.Text
            AxfpSpread1.Col = 6

            Dim qty As String = Val(AxfpSpread1.Text)

            sql = "select * from closingqty where  itemcode='" + txt_ItemCode.Text + "' and storecode='" + storecode + "' and Trnno<>'Openning' and qty<>0 ORDER BY TRNS_SEQ DESC"
            'sql = sql & " and Trnno<>'Openning' "
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then

                Clqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")

                If qty > Clqty Then
                    MessageBox.Show("Updation create   " + txt_ItemCode.Text + " Stock  Negative in " + storecode + " ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                Else
                    ' MessageBox.Show("Transaction has been started u Cann't be update in store " + storecode + " ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    'boolchk = False
                    ' Exit Sub
                End If
            Else


            End If


        Next
        boolchk = True
    End Sub


    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click


        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            'Call checkvalidate()
            'If flag = False Then Exit Sub
            addoperation()
            Dim ITEMCODE As String
            Dim I As Integer
            Dim items As String
            items = "'" + txt_ItemCode.Text + "'"

            Dim dtitem As New DataTable
            dtitem.Columns.Add("itemcode")
            dtitem.TableName = "TpItems"
            dtitem.Rows.Add(txt_ItemCode.Text)
            'For I = 1 To AxfpSpread1.DataRowCnt
            '    AxfpSpread1.Row = I
            '    AxfpSpread1.Col = 1
            '    ITEMCODE = Trim(AxfpSpread1.Text)
            '    items = items & "'" & Trim(ITEMCODE) & "',"
            'Next
            'items = Mid(items, 1, Len(items) - 1)
            Call Randomize()
            vOutfile = Mid("WE" & (Rnd() * 800000000), 1, 10)
            vOutfile = Replace(vOutfile, ".", "")
            vOutfile = Replace(vOutfile, "+", "")
            Dim strrate As String
            Dim loccode As String = "M"
            'sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_Storecode.Text) & "'"
            'gconnection.getDataSet(sqlstring, "loccode")
            'If gdataset.Tables("loccode").Rows.Count > 0 Then
            '    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
            'Else
            '    loccode = "M"
            'End If
            If Mid(UCase(gShortname), 1, 5) = "RSAOI" Or Mid(UCase(gShortname), 1, 3) = "RSI" Then
                strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), items, dtitem, "", "Q", vOutfile, loccode)

            Else
                strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), items, dtitem, "", "Q", vOutfile, loccode)
                sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                gconnection.ExcuteStoreProcedure(sqlstring)
            End If

            '' Added by SRI Item will create in POS if Saleitem is Yes
            If UCase(gShortname) = "KGA" Or UCase(gShortname) = "DC" Then
                If CMB_SALEITEM.Text = "YES" Then
                    sqlstring = " exec iNV_POSITEM_INSERT '" + txt_ItemCode.Text + "'"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If
            End If

            sqlstring = " exec proc_closingqtyone 'itemmaster_add' "
            gconnection.ExcuteStoreProcedure(sqlstring)

            ''

            'Dim sqls As String
            'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
            'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
            'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
            'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
            ''gconnection.ExcuteStoreProcedure(SQLS)
            'gconnection.ExcuteStoreProcedure(sqls)


            clearoperation()
            Else
                Call checkValidation()
            '  Call checkValidation1() '''--->Check Validation
            If boolchk = False Then Exit Sub
            updateoperation()
            Dim ITEMCODE As String
            Dim I As Integer
            Dim items As String
            items = "'" + txt_ItemCode.Text + "'"
            Dim dtitem As New DataTable
            dtitem.Columns.Add("itemcode")
            dtitem.TableName = "TpItems"
            dtitem.Rows.Add(txt_ItemCode.Text)
            'For I = 1 To AxfpSpread1.DataRowCnt
            '    AxfpSpread1.Row = I
            '    AxfpSpread1.Col = 1
            '    ITEMCODE = Trim(AxfpSpread1.Text)
            '    items = items & "'" & Trim(ITEMCODE) & "',"
            'Next
            'items = Mid(items, 1, Len(items) - 1)
            Call Randomize()
            vOutfile = Mid("WE" & (Rnd() * 800000000), 1, 10)
            vOutfile = Replace(vOutfile, ".", "")
            vOutfile = Replace(vOutfile, "+", "")
            Dim strrate As String
            Dim loccode As String = "M"
            'sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_Storecode.Text) & "'"
            'gconnection.getDataSet(sqlstring, "loccode")
            'If gdataset.Tables("loccode").Rows.Count > 0 Then
            '    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
            'Else
            '    loccode = "M"
            'End If
            strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), items, dtitem, "", "Q", vOutfile, loccode)

            sqlstring = " exec proc_closingqtyone 'itemmaster_update' "
            gconnection.ExcuteStoreProcedure(sqlstring)

            'Dim sqls As String
            'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
            'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
            'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
            'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
            ''gconnection.ExcuteStoreProcedure(SQLS)
            'gconnection.ExcuteStoreProcedure(sqls)
            sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
            gconnection.ExcuteStoreProcedure(sqlstring)
            clearoperation()
        End If
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation()
        If boolchk = False Then Exit Sub
       
            voidoperation()
            Dim ITEMCODE As String
            Dim I As Integer
            Dim items As String
            items = "'" + txt_ItemCode.Text + "'"

            Dim dtitem As New DataTable
            dtitem.Columns.Add("itemcode")
            dtitem.TableName = "TpItems"
            dtitem.Rows.Add(txt_ItemCode.Text)

            'For I = 1 To AxfpSpread1.DataRowCnt
            '    AxfpSpread1.Row = I
            '    AxfpSpread1.Col = 1
            '    ITEMCODE = Trim(AxfpSpread1.Text)
            '    items = items & "'" & Trim(ITEMCODE) & "',"
            'Next
            'items = Mid(items, 1, Len(items) - 1)
            Call Randomize()
            vOutfile = Mid("WE" & (Rnd() * 800000000), 1, 10)
            vOutfile = Replace(vOutfile, ".", "")
            vOutfile = Replace(vOutfile, "+", "")
            Dim strrate As String
            Dim loccode As String = "M"
        'sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_Storecode.Text) & "'"
        'gconnection.getDataSet(sqlstring, "loccode")
        'If gdataset.Tables("loccode").Rows.Count > 0 Then
        '    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
        'Else
        '    loccode = "M"
        'End If
        strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), items, dtitem, "", "Q", vOutfile, loccode)
        sqlstring = " exec proc_closingqtyone 'ITEMMASTER_VOID' "
        gconnection.ExcuteStoreProcedure(sqlstring)
        'Dim sqls As String
        'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
        'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
        'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
        'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
        ''gconnection.ExcuteStoreProcedure(SQLS)
        'gconnection.ExcuteStoreProcedure(sqls)
        sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
            gconnection.ExcuteStoreProcedure(sqlstring)
        clearoperation()


    End Sub


    Private Function uombind() As String
        Dim vform As New ListOperattion1
        Dim K As Integer
        Dim SqlQuery As String

        gSQLString = "SELECT uomcode,uomdesc from uommaster I"
        If Trim(search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " WHERE ISNULL(I.FREEZE,'') <> 'Y' "
        End If
        vform.Field = " I.uomcode, I.uomdesc"
        vform.vFor