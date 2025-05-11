Public Class Inv_StoreCategoryLink
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Dim boolchk As Boolean
    Dim strSQL As String
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(text_storecode.Text) = "" Then
            MessageBox.Show(" Store Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            text_storecode.Focus()
            Exit Sub
        End If
        If Len(text_storecode.Text) < 3 And gShortname <> "CSC" Then
            MessageBox.Show(" Store Code Length should be three char", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            text_storecode.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(text_storedesc.Text) = "" Then
            MessageBox.Show(" Store Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            text_storedesc.Focus()
            Exit Sub
        End If
        ''''*********** Check For P.K. ********************************
        'sqlstring = "select storecode from storemaster where storecode='" & text_storecode.Text & "'"
        'gconnection.getDataSet(sqlstring, "storemaster")
        'If gdataset.Tables("storemaster").Rows.Count > 0 Then
        '    MessageBox.Show("Sorry ! Storecode already Exists")
        '    text_storecode.Text = ""
        '    text_storecode.Focus()
        '    Exit Sub
        'End If
        sqlstring = "select distinct costcentercode from ACCOUNTSCOSTCENTERMASTER where costcentercode='" & text_storecode.Text & "'"
        gconnection.getDataSet(sqlstring, "storemaster")
        If gdataset.Tables("storemaster").Rows.Count > 0 Then
            MessageBox.Show("Sorry ! Cost Center already Exists")
            text_storecode.Text = ""
            text_storecode.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub cmdStoreCode_Click(sender As Object, e As EventArgs) Handles cmdStoreCode.Click
        gSQLString = "SELECT ISNULL(STORECODE,'') AS STORECODE,ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER"


        M_WhereCondition = " where isnull(freeze,'N')<>'Y'"
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            text_storecode.Text = Trim(vform.keyfield & "")
            text_storedesc.Text = Trim(vform.keyfield1 & "")
            Call txt_StoreCode_Validated(txt_StoreCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub



    Private Sub txt_StoreCode_Validated(sender As Object, e As EventArgs) Handles txt_StoreCode.Validated
        If Trim(text_storecode.Text) <> "" Then
            sqlstring = "SELECT ISNULL(STORECODE,'') AS STORECODE,ISNULL(STOREDESC,'') AS STOREDESC,ISNULL(STORESTATUS,'') AS STORESTATUS,"
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & " ISNULL(SHELFREQ,'') AS SHELFREQ,"
            End If
            If gShortname = "FNCC" Then
                sqlstring = sqlstring & " ISNULL(SessionReq,'') AS SessionReq,"
            End If
            sqlstring = sqlstring & "  ISNULL(FREEZE,'') AS FREEZE,VOIDDATE,Buffet,Banquet FROM StoreMaster WHERE storecode='" & Trim(text_storecode.Text) & "'"
            gconnection.getDataSet(sqlstring, "StoreMaster")
            If gdataset.Tables("StoreMaster").Rows.Count > 0 Then
                text_storecode.Text = Trim(gdataset.Tables("StoreMaster").Rows(0).Item("STORECODE"))
                text_storedesc.Text = Trim(gdataset.Tables("StoreMaster").Rows(0).Item("STOREDESC"))
                If gdataset.Tables("StoreMaster").Rows(0).Item("FREEZE") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("StoreMaster").Rows(0).Item("VOIDDATE")), "dd/MMM/yyyy")
                    ' JH
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_Add.Enabled = False
                    'Me.Cmd_Freeze.Enabled = True
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Trim(gdataset.Tables("StoreMaster").Rows(0).Item("STORESTATUS")) = "M" Then
                    Opt_Mainstore.Checked = True
                Else
                    Opt_Substore.Checked = True
                End If
                If GSHELVING = "Y" Then
                    If Trim(gdataset.Tables("StoreMaster").Rows(0).Item("SHELFREQ")) = "YES" Then
                        Rdb_ShelfYes.Checked = True
                    Else
                        Rdb_ShelfNo.Checked = True
                    End If
                End If

                If Trim(gdataset.Tables("StoreMaster").Rows(0).Item("Buffet")) = "YES" Then
                    rdb_buffet_Y.Checked = True
                Else
                    rdb_buffet_N.Checked = True
                End If
                If Trim(gdataset.Tables("StoreMaster").Rows(0).Item("Banquet")) = "YES" Then
                    rdb_banquet_Y.Checked = True
                Else
                    rdb_banquet_N.Checked = True
                End If

                If gShortname = "FNCC" Then
                    If Trim(gdataset.Tables("StoreMaster").Rows(0).Item("SessionReq")) = "YES" Then
                        RDB_SESSIONY.Checked = True
                    Else
                        Rdb_ShelfNo.Checked = True
                    End If
                End If
                Me.Cmd_Add.Text = "Update[F7]"
                txt_StoreCode.ReadOnly = True
                txt_StoreDesc.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add[F7]"
                txt_StoreCode.ReadOnly = False
                txt_StoreDesc.Focus()
            End If
        End If
        Dim sql As String = "select categorycode,categorydesc,'1' as check1,isnull(storedesc,'') as  storedesc from Invstore_CategoryMaster where storecode='" + txt_StoreCode.Text + "'"
        sql = sql + " union all select categorycode,categorydesc,'0' as check1,'' as  storedesc from inventorycategorymaster where categorycode not in (select categorycode from Invstore_CategoryMaster where storecode='" + text_storecode.Text + "')"
        gconnection.getDataSet(sql, "Inv_VendorMaster")

        If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then
            ' AxfpSpread1.ClearRange(1, 1, -1, -1, True)

            AxfpSpread1.MaxRows = gdataset.Tables("Inv_VendorMaster").Rows.Count
            If text_storedesc.Text = "" Then
                text_storedesc.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(0).Item("storedesc"))
            End If
            'txt_StoreDesc.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(0).Item("storedesc"))
            For i As Integer = 0 To gdataset.Tables("Inv_VendorMaster").Rows.Count - 1

                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("categorycode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("categorydesc")
                    .Row = i + 1

                    .Col = 3
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("check1")
                    If (gdataset.Tables("Inv_VendorMaster").Rows(i).Item("check1") = "1") Then
                        If txt_StoreDesc.Text = "" Then
                            txt_StoreDesc.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(i).Item("storedesc"))
                        End If


                    End If
                    ' Cmd_Add.Text = "Update[F7]"
                End With
            Next
        End If
        If GSHELVING = "Y" Then
            If Rdb_ShelfYes.Checked = True Then
                Dim j As Integer
                If Trim(text_storecode.Text) <> "" Then
                    sqlstring = "SELECT StoreMaster.STORECODE,StoreMaster.STOREDESC,inventoryshelfmaster.SHELFCODE,inventoryshelfmaster.SHELFDESC FROM StoreMaster"
                    sqlstring = sqlstring & " inner join inventoryshelfmaster on StoreMaster. STORECODE=inventoryshelfmaster.storecode  WHERE inventoryshelfmaster.storecode='" & Trim(text_storecode.Text) & "'"
                    gconnection.getDataSet(sqlstring, "inventoryshelfmaster")
                    If gdataset.Tables("inventoryshelfmaster").Rows.Count > 0 Then
                        With shelf_grid
                            For i As Integer = 1 To gdataset.Tables("inventoryshelfmaster").Rows.Count
                                .SetText(1, i, Trim(gdataset.Tables("inventoryshelfmaster").Rows(j).Item("SHELFCODE")) & "")
                                .SetText(2, i, Trim(gdataset.Tables("inventoryshelfmaster").Rows(j).Item("SHELFDESC")) & "")
                                j = j + 1
                            Next
                        End With
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        If e.keyCode = Keys.F8 Then
            Dim search As New frmSearch
            search.farPoint = AxfpSpread1
            search.Text = "Category Search"
            search.ShowDialog(Me)
            Exit Sub
        End If

    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
        txt_StoreCode.Text = ""
        txt_StoreDesc.Text = ""
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add[F7]"
        '  text_storecode.Focus()
        Cmd_Freeze.Enabled = True
        text_storecode.Enabled = True
        text_storecode.ReadOnly = False
        text_storecode.ReadOnly = False
        Opt_Substore.Checked = True
        Rdb_ShelfNo.Checked = True
        rdb_banquet_N.Checked = True
        rdb_buffet_N.Checked = True
        Me.text_storecode.Text = ""
        Me.text_storedesc.Text = ""
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True
        Dim SQL As String
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        shelf_grid.ClearRange(1, 1, -1, -1, True)
        SQL = " SELECT distinct categorycode,categorydesc FROM INVENTORYCATEGORYMASTER WHERE ISNULL(freeze,'')<>'y'"
        gconnection.getDataSet(SQL, "INV_INVENTORYITEMMASTER")
        If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorycode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorydesc")
                    .Row = i + 1
                End With
            Next
        End If
        text_storecode.Focus()
        TabControl2.SelectedIndex = 0
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        If Cmd_Add.Text = "Add[F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            addoperation(sender, e)
        Else
            Call checkValidation()
            If boolchk = False Then Exit Sub
            updateoperation(sender, e)
        End If
        'clearoperation()
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation()
        If boolchk = False Then Exit Sub
        voidoperation(sender, e)
        clearoperation()
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub clearoperation()
        txt_StoreCode.Text = ""
        txt_StoreDesc.Text = ""
        Cmd_Add.Text = "Add[F7]"
        ' Dim SQL As String
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        Dim sql As String = "select categorycode,categorydesc,'1' as check1 from Invstore_CategoryMaster where storecode='" + txt_StoreCode.Text + "'"
        sql = sql + " union all select categorycode,categorydesc,'0' as check1 from INVENTORYCATEGORYMASTER where categorycode not in (select categorycode from Invstore_CategoryMaster where storecode='" + txt_StoreCode.Text + "')"

        ' SQL = " SELECT distinct ITEMCODE,ITEMNAME,'0' as check1  FROM INV_INVENTORYITEMMASTER WHERE ISNULL(VOID,'')<>'y'"
        gconnection.getDataSet(SQL, "INV_INVENTORYITEMMASTER")
        If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorycode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorydesc")
                    .Row = i + 1
                    .Col = 3
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("check1")
                End With
            Next
        End If
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add[F7]"
        Cmd_Freeze.Enabled = True
        text_storecode.Enabled = True
        text_storecode.ReadOnly = False
        text_storedesc.ReadOnly = False
        Opt_Substore.Checked = True
        Me.text_storecode.Text = ""
        Me.text_storedesc.Text = ""
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True
        text_storecode.Focus()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
    End Sub



    Private Sub addoperation(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Insert(0) As String
        Dim strSQL As String
        Dim boolchk As Boolean
        Insert(0) = Nothing

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            With AxfpSpread1
                .Col = 3
                .Row = i
                If Val(Trim(.Text)) > 0 Then
                    Dim sqlstring As String = "Insert into Invstore_CategoryMaster(storecode,storedesc,categorycode,categorydesc,adduser,adddate,freeze)"
                    sqlstring = sqlstring + " values( '" + txt_StoreCode.Text + "','" + txt_StoreDesc.Text + "',"
                    AxfpSpread1.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "','" + gUsername + "', getdate() ,'N')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
            End With
        Next

        If GSHELVING = "Y" Then
            If Rdb_ShelfYes.Checked = True Then
                For i As Integer = 1 To shelf_grid.DataRowCnt
                    With shelf_grid
                        .Col = 2
                        .Row = i
                        If Trim(.Text) <> "" Then
                            strSQL = " INSERT INTO InventoryShelfMaster (Shelfcode,ShelfDesc,Storecode,Storedesc,Freeze,Adduser,Adddate)"
                            strSQL = strSQL & " VALUES ("
                            .Col = 1
                            strSQL = strSQL & "'" & Trim(.Text) & "',"
                            .Col = 2
                            strSQL = strSQL & "'" & Trim(.Text) & "',"
                            strSQL = strSQL & "'" & Trim(text_storecode.Text) & "','" & Trim(text_storedesc.Text) & "',"
                            strSQL = strSQL & " 'N','" & Trim(gUsername) & "','" & Format(Now, "dd/MMM/yyyy") & "')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = strSQL
                        End If
                    End With
                Next i
            End If
        End If
        gconnection.MoreTrans(Insert)
        If Cmd_Add.Text = "Add[F7]" Then

            strSQL = " INSERT INTO StoreMaster (Storecode,Storedesc,"
            If GSHELVING = "Y" Then
                strSQL = strSQL & "ShelfReq,"
            End If
            If gShortname = "FNCC" Then
                strSQL = strSQL & "SessionReq,"
            End If
            strSQL = strSQL & " StoreStatus,Buffet,Banquet,Freeze, Adduser, Adddate)"

            strSQL = strSQL & " VALUES ( '" & Trim(text_storecode.Text) & "','" & Replace(Trim(text_storedesc.Text), "'", "") & "',"
            If GSHELVING = "Y" Then
                strSQL = strSQL & " '" & IIf(Rdb_ShelfYes.Checked = True, "YES", "NO") & "',"
            End If
            If gShortname = "FNCC" Then
                strSQL = strSQL & " '" & IIf(RDB_SESSIONY.Checked = True, "YES", "NO") & "',"
            End If
            strSQL = strSQL & " '" & IIf(Opt_Mainstore.Checked = True, "M", "S") & "',"
            strSQL = strSQL & " '" & IIf(rdb_buffet_Y.Checked = True, "YES", "NO") & "',"
            strSQL = strSQL & " '" & IIf(rdb_banquet_Y.Checked = True, "YES", "NO") & "',"

            strSQL = strSQL & " 'N','" & Trim(gUsername) & "',getDate())"
            gconnection.dataOperation(1, strSQL, "StoreMaster")
            Call Cmd_Clear_Click(sender, e)
        End If
    End Sub

    Private Sub updateoperation(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Insert(0) As String
        If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
            If Me.lbl_Freeze.Visible = True Then
                MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                boolchk = False
            End If
        End If
        If boolchk = False Then Exit Sub
        Dim sql As String = "insert into Invstore_CategoryMaster_log select categorycode,categorydesc,storecode,adduser,adddate,Freeze,storedesc,updateuser,updatedate from Invstore_CategoryMaster where storecode='" + txt_StoreCode.Text + "'"
        '  ReDim Preserve Insert(Insert.Length)
        Insert(0) = sql
        sql = " delete from Invstore_CategoryMaster where storecode='" + txt_StoreCode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        ' ADDED BY SRI FOR SHELVING
        If GSHELVING = "Y" Then
            If Rdb_ShelfYes.Checked = True Then
                Dim sql1 As String
                sql1 = " delete from inventoryshelfmaster where storecode='" + text_storecode.Text + "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sql1
            End If
        End If
        ' END
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            With AxfpSpread1
                .Row = i
                .Col = 3
                If Val(Trim(.Text)) > 0 Then
                    Dim sqlstring As String = "Insert into Invstore_CategoryMaster(storecode,storedesc,categorycode,categorydesc,adduser,adddate,freeze)"
                    sqlstring = sqlstring + " values( '" + txt_StoreCode.Text + "','" + txt_StoreDesc.Text + "',"
                    AxfpSpread1.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "','" + gUsername + "', getdate() ,'N')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                End If
            End With
        Next
        If GSHELVING = "Y" Then
            If Rdb_ShelfYes.Checked = True Then
                For i As Integer = 1 To shelf_grid.DataRowCnt
                    With shelf_grid
                        .Col = 2
                        .Row = i
                        If Trim(.Text) <> "" Then
                            strSQL = " INSERT INTO InventoryShelfMaster (Shelfcode,ShelfDesc,Storecode,Storedesc,Freeze,Adduser,Adddate)"
                            strSQL = strSQL & " VALUES ("
                            .Col = 1
                            strSQL = strSQL & "'" & Trim(.Text) & "',"
                            .Col = 2
                            strSQL = strSQL & "'" & Trim(.Text) & "',"
                            strSQL = strSQL & "'" & Trim(text_storecode.Text) & "','" & Trim(text_storedesc.Text) & "',"
                            strSQL = strSQL & " 'N','" & Trim(gUsername) & "','" & Format(Now, "dd/MMM/yyyy") & "')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = strSQL
                        End If
                    End With
                Next i
            End If
        End If
        gconnection.MoreTrans(Insert)
        If Cmd_Add.Text = "Update[F7]" Then
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                End If
            End If
            If boolchk = False Then Exit Sub
            strSQL = "UPDATE  StoreMaster "
            strSQL = strSQL & " SET Storedesc='" & Replace(Trim(text_storedesc.Text), "'", "") & "',StoreStatus = '" & IIf(Opt_Mainstore.Checked = True, "M", "S") & "',"
            If GSHELVING = "Y" Then
                strSQL = strSQL & "ShelfReq= '" & IIf(Rdb_ShelfYes.Checked = True, "YES", "NO") & "',"
            End If
            If gShortname = "FNCC" Then
                strSQL = strSQL & "SessionReq= '" & IIf(RDB_SESSIONY.Checked = True, "YES", "NO") & "',"
            End If
            strSQL = strSQL & "Buffet= '" & IIf(rdb_buffet_Y.Checked = True, "YES", "NO") & "',"
            strSQL = strSQL & "Banquet= '" & IIf(rdb_banquet_Y.Checked = True, "YES", "NO") & "',"
            strSQL = strSQL & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME=getDate(),Freeze='N'"
            strSQL = strSQL & " WHERE Storecode = '" & Trim(text_storecode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "StoreMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add[F7]"

        End If

    End Sub

    Private Sub voidoperation(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Insert(0) As String

        sqlstring = "select isnull(storecode,'') as storecode from closingqty where storecode='" & Trim(txt_StoreCode.Text) & "'"
        gconnection.getDataSet(sqlstring, "inv1")
        If gdataset.Tables("inv1").Rows.Count > 0 Then
            MessageBox.Show(" Store Code already used in transaction u can't be update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_StoreCode.Focus()
            Exit Sub
        End If


        Dim sql As String = "insert into Invstore_CategoryMaster_log(storecode,storedesc,categorycode,categorydesc,UPDATEuser,UPDATEdate,freeze) select storecode,storedesc,categorycode,categorydesc,adduser,adddate,freeze from Invstore_categoryMaster where storecode='" + text_storecode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        sql = " delete from Invstore_CategoryMaster where storecode='" + text_storecode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        gconnection.MoreTrans(Insert)
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
            sqlstring = "UPDATE  StoreMaster "
            sqlstring = sqlstring & " SET Freeze= 'Y',voiduser='" & gUsername & " ', voiddate=getDate()"
            sqlstring = sqlstring & " WHERE Storecode = '" & Trim(text_storecode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "StoreMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add[F7]"
        Else
            sqlstring = "UPDATE  StoreMaster "
            sqlstring = sqlstring & " SET Freeze= 'N',Adduser='" & gUsername & " ', Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " WHERE Storecode = '" & Trim(text_storecode.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "StoreMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add[F7]"
        End If

    End Sub
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 734
        K = 1024
        Me.ResizeRedraw = True

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        If U = 800 Then
            T = T - 50
        End If
        If U = 1280 Then
            T = T - 50
        End If
        If U = 1360 Then
            T = T - 75
        End If
        If U = 1366 Then
            T = T - 75
        End If
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Width = U
        Me.Height = T


        With Me
            For i_i = 0 To .Controls.Count - 1
                ' MsgBox(Controls(i_i).Name)
                If TypeOf .Controls(i_i) Is Form Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0
                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If
                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is Panel Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is GroupBox Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "GroupBox3" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If

                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is Label Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                End If
            Next i_i
        End With
    End Sub

    Private Sub Inv_StoreCategoryLink_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
            Call Cmd_Freeze_Click(Cmd_Freeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F4 Then
            Call cmdStoreCode_Click(cmdStoreCode, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub

    Private Sub Inv_StoreCategoryLink_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gUserCategory <> "S" Then
            Call GetRights()
        End If


        ' Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        If GSHELVING <> "Y" Then
            GroupBox5.Visible = False
        End If

        If gShortname = "FNCC" Then
            GroupBox6.Visible = True
        End If
        Call Cmd_Clear_Click(sender, e)
    End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "Store Category Tagging"

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
        '  Me.Cmd_Freeze.Enabled = False
        'Me.Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    'Me.Cmd_View.Enabled = True
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
                    'Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    ' Me.cmd_auth.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub txt_StoreCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_StoreCode.KeyDown
        If txt_StoreCode.Text <> "" Then
            Call txt_StoreCode_Validated(txt_StoreCode, e)
        Else
            If e.KeyCode = Keys.Enter Then
                cmdStoreCode_Click(sender, e)
            End If

        End If

    End Sub
    Private Sub help_storecode_Click(sender As Object, e As EventArgs) Handles help_storecode.Click
        gSQLString = "SELECT ISNULL(STORECODE,'') AS STORECODE,ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER"
        If Opt_Mainstore.Checked = True Then
            M_WhereCondition = " where storestatus='M'"
        ElseIf Opt_Substore.Checked = True Then
            M_WhereCondition = " where storestatus='S'"
        Else
            M_WhereCondition = " "
        End If

        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            text_storecode.Text = Trim(vform.keyfield & "")
            text_storedesc.Text = Trim(vform.keyfield1 & "")
            Call txt_StoreCode_Validated(txt_StoreCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub text_storecode_KeyDown(sender As Object, e As KeyEventArgs) Handles text_storecode.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    If cmdStoreCode.Enabled = True Then
        '        If text_storecode.Text = "" Then
        '            search = Trim(text_storecode.Text)
        '            Call cmdStoreCode_Click(cmdStoreCode, e)
        '        End If

        '    End If
        'End If
    End Sub

    Private Sub Opt_Mainstore_KeyDown(sender As Object, e As KeyEventArgs) Handles Opt_Mainstore.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmd_Add.Focus()
        End If
    End Sub

    Private Sub text_storedesc_KeyDown(sender As Object, e As KeyEventArgs) Handles text_storedesc.KeyDown


        If e.KeyCode = Keys.Enter Then
            Opt_Mainstore.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cat_master As New Category_Master

        cat_master.Show()
    End Sub


    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl2.Click
        txt_StoreCode.Text = text_storecode.Text
        txt_StoreDesc.Text = text_storedesc.Text
        text_storecode.Focus()
        Call checkValidation()
        If boolchk = False Then
            TabControl2.SelectedIndex = 0
            Exit Sub
        End If
        Dim sql As String = "select categorycode,categorydesc,'1' as check1,isnull(storedesc,'') as  storedesc from Invstore_CategoryMaster where storecode='" + txt_StoreCode.Text + "'"
        sql = sql + " union all select categorycode,categorydesc,'0' as check1,'' as  storedesc from inventorycategorymaster where ISNULL(FREEZE,'')<>'Y' AND  categorycode not in (select categorycode from Invstore_CategoryMaster where storecode='" + txt_StoreCode.Text + "')"
        gconnection.getDataSet(sql, "Inv_VendorMaster")

        If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then
            AxfpSpread1.ClearRange(1, 1, -1, -1, True)
            If txt_StoreDesc.Text = "" Then
                txt_StoreDesc.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(0).Item("storedesc"))
            End If
            'txt_StoreDesc.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(0).Item("storedesc"))
            For i As Integer = 0 To gdataset.Tables("Inv_VendorMaster").Rows.Count - 1

                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("categorycode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("categorydesc")
                    .Row = i + 1

                    .Col = 3
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("check1")
                    If (gdataset.Tables("Inv_VendorMaster").Rows(i).Item("check1") = "1") Then
                        If txt_StoreDesc.Text = "" Then
                            txt_StoreDesc.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(i).Item("storedesc"))
                        End If
                    End If
                End With
            Next
        End If

    End Sub

    Private Sub lbl_Freeze_Click(sender As Object, e As EventArgs) Handles lbl_Freeze.Click

    End Sub

    Private Sub text_storecode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles text_storecode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(text_storecode.Text) = "" Then
                Call help_storecode_Click(sender, e)
            Else
                Call txt_StoreCode_Validated(txt_StoreCode, e)
            End If
        End If
    End Sub

    Private Sub text_storedesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles text_storedesc.KeyPress
        getAlphanumeric(e)
    End Sub

    Private Sub Rdb_ShelfYes_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_ShelfYes.CheckedChanged
        shelf_grid.Visible = True
    End Sub

    Private Sub Rdb_ShelfNo_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_ShelfNo.CheckedChanged
        shelf_grid.Visible = False
    End Sub

    Private Sub shelf_grid_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles shelf_grid.KeyDownEvent
        Dim itc As String
        Dim cct As Integer
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        If e.keyCode = Keys.Enter Then
            For j = 1 To shelf_grid.DataRowCnt + 1
                'Dim ITC
                shelf_grid.Col = 1
                shelf_grid.Row = j
                itc = shelf_grid.Text
                For k = 1 To shelf_grid.DataRowCnt + 1
                    shelf_grid.Col = 1
                    shelf_grid.Row = k
                    If UCase(Trim(shelf_grid.Text)) = UCase(itc) Then
                        cct = cct + 1
                    End If
                Next
                If cct > 1 Then
                    MsgBox("Duplicate Shelf Code Entry")
                    shelf_grid.ClearRange(1, shelf_grid.ActiveRow, 7, shelf_grid.ActiveRow, True)
                    shelf_grid.Col = 1
                    ' ssgrid.Focus()
                    shelf_grid.SetActiveCell(1, shelf_grid.ActiveRow)
                    Exit Sub
                End If
                cct = 0
            Next
        End If


        If e.keyCode = Keys.F3 Then
            shelf_grid.Col = shelf_grid.ActiveCol
            shelf_grid.Row = i
            shelf_grid.Row = shelf_grid.ActiveRow
            shelf_grid.ClearRange(1, shelf_grid.ActiveRow, 2, shelf_grid.ActiveRow, True)
            shelf_grid.DeleteRows(shelf_grid.ActiveRow, 1)
        End If

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub
End Class