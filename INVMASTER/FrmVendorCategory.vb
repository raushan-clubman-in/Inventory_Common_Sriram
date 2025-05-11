Public Class FrmVendorCategory
    Dim gconnection As New GlobalClass
    Dim boolchk As Boolean
    Dim strsql, sqlstring As String
    Dim RATEFLAG As String

    Private Sub updatecheckeduser()
        Dim insert(0) As String
        Dim sql As String = "Update Categoryuserdetail set void='Y',Updatedate=GETDATE(),Updateuser='" + Trim(gUsername) + "'"
        sql = sql & " where categorycode='" & Trim(txt_CATEGORYCode.Text) & "' "
        gconnection.dataOperation(6, sql, "Categoryuserdetail")
    End Sub
    Public Sub checkValidation()
        boolchk = False

      

        '''********** Check  CATEGORY Code Can't be blank *********************'''
        If Trim(txt_CATEGORYCode.Text) = "" Then
            MessageBox.Show(" Category Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CATEGORYCode.Focus()
            Exit Sub
        End If
        '''********** Check  CATEGORY desc Can't be blank *********************'''
        If Trim(txt_CATEGORYDesc.Text) = "" Then
            MessageBox.Show(" Category Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CATEGORYDesc.Focus()
            Exit Sub
        End If
        '''********* RATE TYPE CHECK **********************
        If RDO_PURCHASE.Checked = True Then
            boolchk = True
            Exit Sub
        ElseIf RDO_WEIGHTED.Checked = True Then
            boolchk = True
            Exit Sub
        Else
            MessageBox.Show(" Rate Type can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub insertcheckeduser()
        Dim insert(0) As String
        Dim insert1(0) As String
        For i As Integer = 0 To UserCheckList.CheckedItems.Count - 1
            Dim sql As String = "Insert into Categoryuserdetail(categorycode,Usercode,void,adddate,adduser)"
            sql = sql & " values('" & Trim(txt_CATEGORYCode.Text) & "','" & UserCheckList.CheckedItems(i) & "','N',GETDATE(),'" + Trim(gUsername) + "') "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sql
        Next
        gconnection.MoreTrans2(insert)

        'If gconnection.MoreTrans2(insert) Then
        '    For i As Integer = 0 To UserCheckList.CheckedItems.Count - 1
        '        Dim sql As String = "Insert into Categoryuserdetail_log(categorycode,Usercode,void,adddate,adduser)"
        '        sql = sql & " values('" & Trim(txt_CATEGORYCode.Text) & "','" & UserCheckList.CheckedItems(i) & "','N',GETDATE(),'" + Trim(gUsername) + "') "
        '        ReDim Preserve insert1(insert1.Length)
        '        insert1(insert1.Length - 1) = sql
        '    Next
        '    gconnection.MoreTrans2(insert1)
        'End If
    End Sub
    Private Sub Cmd_SLCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_SLCodeHelp.Click
        gSQLString = "SELECT distinct ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER"
        M_WhereCondition = ""
        Dim vform As New ListOperattion1
        vform.Field = "CATEGORYDESC,CATEGORYCODE"
        vform.vFormatstring = "         CATEGORY CODE              |                  CATEGORY DESCRIPTION                                                                                                   "
        vform.vCaption = "CATEGORY MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_CATEGORYCode.Text = Trim(vform.keyfield & "")
            Call Txt_SLCode_Validated(sender, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 780
        K = 1044
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
                        If Controls(i_i).Name = "GroupBox2" Then
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
                        ElseIf Controls(i_i).Name = "grp_orderby" Then
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
                        ElseIf Controls(i_i).Name = "GroupBox4" Then
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

    Private Sub FrmVendorCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F6) Then
            clearoperation()
        ElseIf (e.KeyCode = Keys.F7) And Cmd_Add.Visible = True Then
            Cmd_Add_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F8) And Cmd_Freeze.Visible = True Then
            Cmd_Freeze_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F11) Then
            Cmd_Exit_Click(sender, e)
        End If
    End Sub
    Private Sub clearoperation()
        Txt_SLCode.Text = ""
        Txt_SLName.Text = ""
        Cmd_Add.Text = "Add[F7]"

        Dim SQL As String
        SQL = " delete from Invvendor_CategoryMaster where isnull(vendorcode,'')=''"
        gconnection.dataOperation1(1, SQL, "")
        'AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        'SQL = "select categorycode,categorydesc,'1' as check1 from Invvendor_CategoryMaster where vendorcode='" + Txt_SLCode.Text + "'"
        'sql = sql + " union all select categorycode,categorydesc,'0' as check1 from INVENTORYCATEGORYMASTER where categorycode not in (select categorycode from Invvendor_CategoryMaster where vendorcode='" + Txt_SLCode.Text + "')"

        '' SQL = " SELECT distinct ITEMCODE,ITEMNAME,'0' as check1  FROM INV_INVENTORYITEMMASTER WHERE ISNULL(VOID,'')<>'y'"
        'gconnection.getDataSet(SQL, "INV_INVENTORYITEMMASTER")
        'If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then
        '    For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
        '        With AxfpSpread1
        '            .Row = i + 1
        '            .Col = 1
        '            .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorycode")

        '            .Row = i + 1
        '            .Col = 2
        '            .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorydesc")
        '            .Row = i + 1
        '            .Col = 3
        '            .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("check1")



        '        End With
        '    Next
        'End If

        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        SQL = " SELECT distinct slcode,Slname FROM accountssubledgermaster WHERE ISNULL(FREEZEFLAG,'')<>'Y' AND accode='" + gCreditors + "' AND SLTYPE='SUPPLIER' "
        gconnection.getDataSet(SQL, "accountssubledgermaster")
        If (gdataset.Tables("accountssubledgermaster").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("accountssubledgermaster").Rows.Count - 1
                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("accountssubledgermaster").Rows(i).Item("slcode")
                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("accountssubledgermaster").Rows(i).Item("Slname")
                    .Row = i + 1
                End With
            Next
        End If
        AxfpSpread2.ClearRange(1, 1, -1, -1, True)
        SQL = " SELECT distinct STORECODE,storedesc FROM STOREMASTER WHERE ISNULL(freeze,'')<>'y'"
        gconnection.getDataSet(SQL, "STOREMASTER")
        If (gdataset.Tables("STOREMASTER").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                With AxfpSpread2
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("STOREMASTER").Rows(i).Item("STORECODE")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("STOREMASTER").Rows(i).Item("storedesc")
                    .Row = i + 1
                End With
            Next
        End If
    End Sub
    Private Sub FrmVendorCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        clearoperation()
        bindchecklist()
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        txt_CATEGORYCode.Focus()
    End Sub
    Private Sub bindchecklist()
        UserCheckList.Items.Clear()
        '  Dim sqlstring = "SELECT DISTINCT USERNAME,CATEGORY FROM UserAdmin where Maingroup='Inventory'"
        Dim sqlstring = "  SELECT DISTINCT USERNAME,CATEGORY FROM UserAdmin where Maingroup='Inventory'"
        sqlstring = sqlstring & "    union "
        sqlstring = sqlstring & "  SELECT DISTINCT USERNAME,CATEGORY FROM UserAdmin where category='S'"
        ''sqlstring = sqlstring & "    union "
        '' sqlstring = sqlstring & "  SELECT DISTINCT USERNAME,CATEGORY FROM MASTER..UserAdmin where category='S'"

        gconnection.getDataSet(sqlstring, "UserAdmin")
        If (gdataset.Tables("UserAdmin").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("UserAdmin").Rows.Count - 1
                UserCheckList.Items.Add(gdataset.Tables("UserAdmin").Rows(i).Item("USERNAME"))

            Next
        End If

    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
        Txt_SLCode.Text = ""
        Txt_SLName.Text = ""
        Dim SQL As String
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        SQL = " SELECT distinct slcode,Slname FROM accountssubledgermaster WHERE ISNULL(FREEZEFLAG,'')<>'Y' AND accode='" + gCreditors + "' AND SLTYPE='SUPPLIER' "
        gconnection.getDataSet(SQL, "accountssubledgermaster")
        If (gdataset.Tables("accountssubledgermaster").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("accountssubledgermaster").Rows.Count - 1
                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("accountssubledgermaster").Rows(i).Item("slcode")
                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("accountssubledgermaster").Rows(i).Item("Slname")
                    .Row = i + 1
                End With
            Next
        End If
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add[F7]"
        Cmd_Freeze.Enabled = True
        txt_CATEGORYCode.Enabled = True
        txt_CATEGORYCode.ReadOnly = False
        txt_CATEGORYDesc.ReadOnly = False
        'TXT_CATFLAG.Text = ""
        txt_CATEGORYCode.Text = ""
        txt_CATEGORYDesc.Text = ""
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True
        txt_CATEGORYCode.Focus()
        UserCheckList.Items.Clear()
        bindchecklist()
        'TXT_USERNAME.Text = ""
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        RDO_PURCHASE.Checked = False
        RDO_WEIGHTED.Checked = False
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
        Cmd_Freeze.Enabled = True
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True
        AxfpSpread2.ClearRange(1, 1, -1, -1, True)
        SQL = " SELECT distinct STORECODE,storedesc FROM STOREMASTER WHERE ISNULL(freeze,'')<>'y'"
        gconnection.getDataSet(SQL, "STOREMASTER")
        If (gdataset.Tables("STOREMASTER").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                With AxfpSpread2
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("STOREMASTER").Rows(i).Item("STORECODE")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("STOREMASTER").Rows(i).Item("storedesc")
                    .Row = i + 1
                End With
            Next
        End If
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub GetRights()
        Dim i, x As Integer
        'Dim vmain, vsmod, vssmod As Long
        Dim SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "Vendor Category Tagging"

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
                    '  Me.Cmd_Freeze.Enabled = True
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
    Private Sub addoperation(sender As Object, e As EventArgs)
        Dim Insert(0), INSERT1(0) As String
        Dim boolchk As Boolean
        Insert(0) = Nothing
        INSERT1(0) = Nothing
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            With AxfpSpread1
                .Row = i
                .Col = 3
                If Val(Trim(.Text)) > 0 Then
                    Dim sqlstring As String = "Insert into Invvendor_CategoryMaster(categorycode,categorydesc,VENDORCODE,VENDORNAME,adduser,adddate,freeze)"
                    sqlstring = sqlstring + " values( '" + Txt_SLCode.Text + "','" + Txt_SLName.Text + "',"
                    AxfpSpread1.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "','" + gUsername + "', getdate() ,'N')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
            End With
        Next
        If (gconnection.MoreTrans(Insert)) Then
            '---------------------------LOG START-----------------------------------
            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                With AxfpSpread1
                    .Row = i
                    .Col = 3
                    If Val(Trim(.Text)) > 0 Then
                        Dim sqlstring As String = "Insert into Invvendor_CategoryMaster_LOG(categorycode,categorydesc,VENDORCODE,VENDORNAME,adduser,adddate,freeze)"
                        sqlstring = sqlstring + " values( '" + Txt_SLCode.Text + "','" + Txt_SLName.Text + "',"
                        AxfpSpread1.Col = 1
                        sqlstring = sqlstring + " '" + AxfpSpread1.Text + "',"
                        AxfpSpread1.Col = 2
                        sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "','" + gUsername + "', getdate() ,'N')"
                        ReDim Preserve INSERT1(INSERT1.Length)
                        INSERT1(INSERT1.Length - 1) = sqlstring
                    End If
                End With
            Next
            gconnection.MoreTrans_log(INSERT1)
            '---------------------------LOG END-----------------------------------
        End If
        Dim strSQL As String
        Insert(0) = Nothing
        INSERT1(0) = Nothing
        For i As Integer = 1 To AxfpSpread2.DataRowCnt
            With AxfpSpread2
                .Col = 3
                .Row = i
                If Val(Trim(.Text)) > 0 Then
                    Dim sqlstring As String = "Insert into Invstore_CategoryMaster(categorycode,categorydesc,storecode,storedesc,adduser,adddate,freeze)"
                    sqlstring = sqlstring + " values( '" + txt_StoreCode.Text + "','" + txt_StoreDesc.Text + "',"
                    AxfpSpread2.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread2.Text + "',"
                    AxfpSpread2.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread2.Text + "','" + gUsername + "', getdate() ,'N')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
            End With
        Next
        If gconnection.MoreTrans(Insert) Then
            '---------------------------LOG START-----------------------------------
            For i As Integer = 1 To AxfpSpread2.DataRowCnt
                With AxfpSpread2
                    .Col = 3
                    .Row = i
                    If Val(Trim(.Text)) > 0 Then
                        Dim sqlstring As String = "Insert into Invstore_CategoryMaster_LOG(categorycode,categorydesc,storecode,storedesc,adduser,adddate,freeze)"
                        sqlstring = sqlstring + " values( '" + txt_StoreCode.Text + "','" + txt_StoreDesc.Text + "',"
                        AxfpSpread2.Col = 1
                        sqlstring = sqlstring + " '" + AxfpSpread2.Text + "',"
                        AxfpSpread2.Col = 2
                        sqlstring = sqlstring + "   '" + AxfpSpread2.Text + "','" + gUsername + "', getdate() ,'N')"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End If
                End With
            Next
            gconnection.MoreTrans_log(INSERT1)
            '---------------------------LOG ENDS-----------------------------------
        End If
        If Cmd_Add.Text = "Add[F7]" Then

            strSQL = " INSERT INTO inventorycategorymaster (categorycode,categorydesc,Freeze,Adduser,Adddate,RATEflag)"
            strSQL = strSQL & " VALUES ( '" & Trim(txt_CATEGORYCode.Text) & "','" & Replace(Trim(txt_CATEGORYDesc.Text), "'", "") & "',"
            strSQL = strSQL & "'N',"
            strSQL = strSQL & " '" & Trim(gUsername) & "',GETDATE(),"
            If RDO_WEIGHTED.Checked = True Then
                strSQL = strSQL & "'W')"
            ElseIf RDO_PURCHASE.Checked = True Then
                strSQL = strSQL & "'P')"
            End If

            'strSQL = strSQL & "'" & Trim(TXT_CATFLAG.Text) & "')"
            If (gconnection.dataOperation(1, strSQL, "inventorycategorymaster")) Then
                '---------------------------LOG STARTS-----------------------------------
                strSQL = " INSERT INTO inventorycategorymaster_log (categorycode,categorydesc,Freeze,Adduser,Adddate,RATEflag)"
                strSQL = strSQL & " VALUES ( '" & Trim(txt_CATEGORYCode.Text) & "','" & Replace(Trim(txt_CATEGORYDesc.Text), "'", "") & "',"
                strSQL = strSQL & "'N',"
                strSQL = strSQL & " '" & Trim(gUsername) & "',GETDATE(),"
                If RDO_WEIGHTED.Checked = True Then
                    strSQL = strSQL & "'W')"
                ElseIf RDO_PURCHASE.Checked = True Then
                    strSQL = strSQL & "'P')"
                End If
                gconnection.dataOperation2(1, strSQL, "inventorycategorymaster_log")
                '---------------------------LOG ENDS-----------------------------------
            End If
            insertcheckeduser()
            Me.Cmd_Clear_Click(sender, e)
        End If
    End Sub

    Private Sub updateoperation(sender As Object, e As EventArgs)
        Dim Insert(0) As String
        Call checkValidation() '''--->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
            If Me.lbl_Freeze.Visible = True Then
                MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                boolchk = False
            End If
        End If
        If boolchk = False Then Exit Sub

        Dim sql As String = "insert into Invvendor_CategoryMaster_log(vendorcode,VENDORNAME,categorycode,categorydesc,UPDATEuser,UPDATEdate,freeze) select vendorcode,VENDORNAME,categorycode,categorydesc,adduser,adddate,freeze from Invvendor_CategoryMaster where categorycode='" + Txt_SLCode.Text + "'"

        '  ReDim Preserve Insert(Insert.Length)
        Insert(0) = sql
        sql = " delete from Invvendor_CategoryMaster where categorycode='" + Txt_SLCode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            With AxfpSpread1
                .Row = i
                .Col = 3
                If Val(Trim(.Text)) > 0 Then
                    Dim sqlstring As String = "Insert into Invvendor_CategoryMaster(categorycode,categorydesc,VENDORCODE,VENDORNAME,adduser,adddate,freeze)"
                    sqlstring = sqlstring + " values( '" + Txt_SLCode.Text + "','" + Txt_SLName.Text + "',"
                    AxfpSpread1.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "','" + gUsername + "', getdate() ,'N')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                End If
            End With
        Next
        gconnection.MoreTrans(Insert)
        sql = "insert into Invstore_CategoryMaster_log select categorycode,categorydesc,storecode,adduser,adddate,Freeze,storedesc,updateuser,updatedate from Invstore_CategoryMaster where categorycode='" + txt_StoreCode.Text + "'"
        '  ReDim Preserve Insert(Insert.Length)
        Insert(0) = sql
        sql = " delete from Invstore_CategoryMaster where categorycode='" + txt_StoreCode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql

        For i As Integer = 1 To AxfpSpread2.DataRowCnt
            With AxfpSpread2
                .Row = i
                .Col = 3
                If Val(Trim(.Text)) > 0 Then
                    Dim sqlstring As String = "Insert into Invstore_CategoryMaster(categorycode,categorydesc,STORECODE,STOREDESC,adduser,adddate,freeze)"
                    sqlstring = sqlstring + " values( '" + txt_StoreCode.Text + "','" + txt_StoreDesc.Text + "',"
                    AxfpSpread2.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread2.Text + "',"
                    AxfpSpread2.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread2.Text + "','" + gUsername + "', getdate() ,'N')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                End If
            End With
        Next
        gconnection.MoreTrans(Insert)
        If Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                End If
            End If
            If boolchk = False Then Exit Sub
            If (RATEFLAG = "W" And RDO_PURCHASE.Checked = True) Or (RATEFLAG = "P" And RDO_WEIGHTED.Checked = True) Then

                If MsgBox(" U have change RATEFLAG  do U want  Manual Update for this category ......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
                    Me.Cursor = Cursors.WaitCursor
                    gconnection.valuation()
                    Me.Cursor = Cursors.Default
                Else
                    ' MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
                    Exit Sub
                End If

            End If
            If boolchk = False Then Exit Sub
            strSQL = "UPDATE  inventorycategorymaster "
            strSQL = strSQL & " SET categorydesc='" & Replace(Trim(txt_CATEGORYDesc.Text), "'", "") & "',"
            strSQL = strSQL & " updateUSER='" & Trim(gUsername) & "',UPDATEDATE=GETDATE(),Freeze='N',"
            If RDO_WEIGHTED.Checked = True Then
                strSQL = strSQL & " RATEFLAG='W' "
            ElseIf RDO_PURCHASE.Checked = True Then
                strSQL = strSQL & " RATEFLAG='P' "
            End If
            'strSQL = strSQL & " categoryflag='" & Replace(Trim(TXT_CATFLAG.Text), "'", "") & "'"
            strSQL = strSQL & " WHERE CATEGORYCODE = '" & Trim(txt_CATEGORYCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "inventorycategorymaster")
            updatecheckeduser()
            insertcheckeduser()
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add[F7]"
        End If
    End Sub
    Private Sub voidoperation(sender As Object, e As EventArgs)
        Dim Insert(0) As String
        Call checkValidation() '''--->Check Validation
        If boolchk = False Then Exit Sub

        Dim sqlq As String = "select isnull(CATEGORYCODE,'') from INVENTORYCATEGORYMASTER where CATEGORYCODE in(select isnull(CATEGORYCODE,'') from INV_InventoryItemMaster where isnull(void,'')<>'Y')  and isnull(CATEGORYCODE,'')='" + txt_CATEGORYCode.Text + "'"
        gconnection.getDataSet(sqlq, "inventorygroupmaster")
        If gdataset.Tables("inventorygroupmaster").Rows.Count > 0 Then
            MessageBox.Show(" Can't Void the Records Because Transaction is Available on this Category ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CATEGORYCode.Focus()
            Exit Sub
        End If

        Dim sql As String = "insert into Invvendor_CategoryMaster_log(vendorcode,VENDORNAME,categorycode,categorydesc,UPDATEuser,UPDATEdate,freeze) select vendorcode,VENDORNAME,categorycode,categorydesc,adduser,adddate,freeze from Invvendor_CategoryMaster where categorycode='" + Txt_SLCode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        sql = " delete from Invvendor_CategoryMaster where categorycode='" + Txt_SLCode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        gconnection.MoreTrans(Insert)
        sql = "insert into Invstore_CategoryMaster_log(storecode,storedesc,categorycode,categorydesc,UPDATEuser,UPDATEdate,freeze) select storecode,storedesc,categorycode,categorydesc,adduser,adddate,freeze from Invstore_categoryMaster where categorycode='" + txt_StoreCode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        sql = " delete from Invstore_CategoryMaster where categorycode='" + txt_StoreCode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        gconnection.MoreTrans(Insert)
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
            sqlstring = "UPDATE  inventorycategorymaster "
            sqlstring = sqlstring & " SET Freeze= 'Y',voiduser='" & gUsername & " ', voiddate=GETDATE() "
            sqlstring = sqlstring & " WHERE CATEGORYCODE = '" & Trim(txt_CATEGORYCode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "inventorycategorymaster")
            updatecheckeduser()
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add[F7]"
        Else
            sqlstring = "UPDATE  inventorycategorymaster "
            sqlstring = sqlstring & " SET Freeze= 'N',voiduser='" & gUsername & " ', voiddate=GETDATE() "
            sqlstring = sqlstring & " WHERE CATEGORYCODE = '" & Trim(txt_CATEGORYCode.Text) & "'"
            gconnection.dataOperation(6, sqlstring, "inventorycategorymaster")
            updatecheckeduser()
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add[F7]"
        End If
    End Sub
    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        If Cmd_Add.Text = "Add[F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            addoperation(sender, e)
        Else
            updateoperation(sender, e)
        End If
        ' clearoperation()
    End Sub
    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        voidoperation(sender, e)
        clearoperation()
    End Sub
    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub Txt_SLCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_SLCode.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (Txt_SLCode.Text <> "") Then
                Call txt_CATEGORYCode_Validated(Txt_SLCode, e)
            Else
                Cmd_SLCodeHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Txt_SLCode_Validated(sender As Object, e As EventArgs) Handles Txt_SLCode.Validated
        Dim sql As String = "select distinct VENDORcode,vendorname,'1' as check1 from Invvendor_CategoryMaster where categorycode='" + txt_CATEGORYCode.Text + "'"
        sql = sql + " union all select slcode,slname,'0' as check1 from accountssubledgermaster  where sltype='supplier' and slcode not in (select vendorcode from Invvendor_CategoryMaster where categorycode='" + txt_CATEGORYCode.Text + "')"
        gconnection.getDataSet(sql, "Inv_VendorMaster")


        If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then
            AxfpSpread1.MaxRows = gdataset.Tables("Inv_VendorMaster").Rows.Count
            '   AxfpSpread1.ClearRange(1, 1, -1, -1, True)
            'Txt_SLName.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(0).Item("VENDORNAME"))
            'sql = "  SELECT distinct slcode,Slname FROM accountssubledgermaster where slcode='" + Txt_SLCode.Text + "' and  SLTYPE='SUPPLIER' "
            'gconnection.getDataSet(sql, "inv_linksetup")

            'If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
            '    Txt_SLName.Text = gdataset.Tables("inv_linksetup").Rows(0).Item("Slname")
            'End If
            For i As Integer = 0 To gdataset.Tables("Inv_VendorMaster").Rows.Count - 1
                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("VENDORcode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("vendorname")
                    .Row = i + 1

                    .Col = 3
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("check1")
                    'If (gdataset.Tables("Inv_VendorMaster").Rows(i).Item("check1") = "1") Then
                    '    Cmd_Add.Text = "Update[F7]"
                    'End If
                End With
            Next
        End If
    End Sub
    Private Sub cmdStoreCode_Click(sender As Object, e As EventArgs) Handles cmdStoreCode.Click
        gSQLString = "SELECT distinct ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER"
        M_WhereCondition = ""
        Dim vform As New ListOperattion1
        vform.Field = "CATEGORYDESC,CATEGORYCODE"
        vform.vFormatstring = "         CATEGORY CODE              |                  CATEGORY DESCRIPTION                                                                                                   "
        vform.vCaption = "CATEGORY MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_CATEGORYCode.Text = Trim(vform.keyfield & "")
            Call txt_CATEGORYCode_Validated(txt_CATEGORYCode, e)
            Call Txt_SLCode_Validated(sender, e)
            Call txt_StoreCode_Validated(sender, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_CATEGORYCode_Validated(sender As Object, e As EventArgs) Handles txt_CATEGORYCode.Validated
        Dim rate As String
        If Trim(txt_CATEGORYCode.Text) <> "" Then
            sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC,ISNULL(FREEZE,'') AS FREEZE,ADDDATE, ISNULL(RATEFLAG,'') AS RATEFLAG,voiddate FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" & Trim(txt_CATEGORYCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "INVENTORYCATEGORYMASTER")
            If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0 Then
                txt_CATEGORYCode.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYCODE"))
                txt_CATEGORYDesc.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                'TXT_CATFLAG.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYFLAG"))
                rate = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("rateflag"))
                If rate = "W" Then
                    RDO_WEIGHTED.Checked = True
                    RATEFLAG = "W"
                ElseIf rate = "P" Then
                    RDO_PURCHASE.Checked = True
                    RATEFLAG = "P"
                End If

                'TXT_USERNAME.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("USERNAME"))
                If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("FREEZE") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("VOIDDATE")), "dd/MMM/yyyy")
                    ' JH
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_Add.Enabled = False
                    Me.Cmd_Freeze.Enabled = True
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                End If
                UserCheckList.Items.Clear()
                bindchecklist()
                sqlstring = "select Usercode from Categoryuserdetail where CATEGORYCODE='" & Trim(txt_CATEGORYCode.Text) & "' and isnull(void,'')='N'"
                gconnection.getDataSet(sqlstring, "Categoryuserdetail")
                Dim TYPE As String
                Dim Usercode As String
                If (gdataset.Tables("Categoryuserdetail").Rows.Count > 0) Then
                    For k As Integer = 0 To gdataset.Tables("Categoryuserdetail").Rows.Count - 1
                        Usercode = Trim(gdataset.Tables("Categoryuserdetail").Rows(k).Item("Usercode"))
                        For m As Integer = 0 To UserCheckList.Items.Count - 1
                            TYPE = UserCheckList.Items(m)
                            If TYPE = Usercode Then
                                UserCheckList.SetItemChecked(m, True)
                            End If
                        Next m
                    Next k
                End If

                'If Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("STORESTATUS")) = "M" Then
                '    Opt_Mainstore.Checked = True
                'Else
                '    Opt_Substore.Checked = True
                'End If
                Me.Cmd_Add.Text = "Update[F7]"
                txt_CATEGORYCode.ReadOnly = True
                txt_CATEGORYDesc.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add[F7]"
                txt_CATEGORYCode.ReadOnly = False
                txt_CATEGORYDesc.Focus()
            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Else
            txt_CATEGORYCode.Text = ""
            txt_CATEGORYDesc.Focus()
        End If
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub txt_CATEGORYCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_CATEGORYCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdStoreCode.Enabled = True Then
                search = Trim(txt_CATEGORYCode.Text)
                Call txt_CATEGORYCode_Validated(sender, e)
            End If
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        Call checkValidation() '''--->Check Validation
        If boolchk = False Then Exit Sub
        TabPage1.Show()
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objStoreMaster As New Store_Master
        'objStoreMaster.MdiParent = Me
        objStoreMaster.Show()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim objSubledgermaster As New SUBLEDGERMASTER
        objSubledgermaster.Show()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim objStoreMaster As New Store_Master
        objStoreMaster.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        gSQLString = "SELECT distinct ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER"
        M_WhereCondition = ""
        Dim vform As New ListOperattion1
        vform.Field = "CATEGORYDESC,CATEGORYCODE"
        vform.vFormatstring = "         CATEGORY CODE              |                  CATEGORY DESCRIPTION                                                                                                   "
        vform.vCaption = "CATEGORY MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_CATEGORYCode.Text = Trim(vform.keyfield & "")
            Call txt_StoreCode_Validated(sender, e)
        End If
        vform.Close()
        vform = Nothing

    End Sub
    Private Sub txt_StoreCode_Validated(sender As Object, e As EventArgs) Handles txt_StoreCode.Validated
        Dim sql As String = "select storecode,storedesc,'1' as check1 from Invstore_CategoryMaster where categorycode='" + txt_CATEGORYCode.Text + "'"
        sql = sql + " union all select storecode,storedesc,'0' as check1  from StoreMaster where storecode not in (select storecode from Invstore_CategoryMaster where categorycode='" + txt_CATEGORYCode.Text + "')"
        gconnection.getDataSet(sql, "Inv_VendorMaster")
        If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then
            AxfpSpread2.MaxRows = gdataset.Tables("Inv_VendorMaster").Rows.Count
            'AxfpSpread2.ClearRange(1, 1, -1, -1, True)
            'If txt_StoreDesc.Text = "" Then
            '    txt_StoreDesc.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(0).Item("storedesc"))
            'End If
            'txt_StoreDesc.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(0).Item("storedesc"))
            For i As Integer = 0 To gdataset.Tables("Inv_VendorMaster").Rows.Count - 1


                With AxfpSpread2
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("storecode")
                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("storedesc")
                    .Row = i + 1
                    .Col = 3
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("check1")
                    'If (gdataset.Tables("Inv_VendorMaster").Rows(i).Item("check1") = "1") Then
                    '    Cmd_Add.Text = "Update[F7]"
                    'End If
                End With
            Next
        End If
    End Sub

    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        If e.keyCode = Keys.F1 Then
            Dim search As New frmSearch
            search.farPoint = AxfpSpread1
            search.Text = "Category Search"
            search.ShowDialog(Me)
            Exit Sub
        End If
    End Sub

    Private Sub TabPage5_Click(sender As Object, e As EventArgs) Handles TabPage5.Click
        Call checkValidation() '''--->Check Validation
        If boolchk = False Then Exit Sub
        TabPage1.Show()
    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        Txt_SLCode.Text = txt_CATEGORYCode.Text
        Txt_SLName.Text = txt_CATEGORYDesc.Text
        txt_StoreCode.Text = txt_CATEGORYCode.Text
        txt_StoreDesc.Text = txt_CATEGORYDesc.Text
        Call checkValidation() '''--->Check Validation
        If boolchk = False Then
            TabControl1.SelectedIndex = 0
            Exit Sub
        End If
        'Dim SQL As String
        'AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        'SQL = " SELECT distinct slcode,Slname FROM accountssubledgermaster WHERE ISNULL(FREEZEFLAG,'')<>'Y' AND accode='" + gCreditors + "' AND SLTYPE='SUPPLIER' "
        'gconnection.getDataSet(SQL, "accountssubledgermaster")
        'If (gdataset.Tables("accountssubledgermaster").Rows.Count > 0) Then
        '    For i As Integer = 0 To gdataset.Tables("accountssubledgermaster").Rows.Count - 1
        '        With AxfpSpread1
        '            .Row = i + 1
        '            .Col = 1
        '            .Text = gdataset.Tables("accountssubledgermaster").Rows(i).Item("slcode")
        '            .Row = i + 1
        '            .Col = 2
        '            .Text = gdataset.Tables("accountssubledgermaster").Rows(i).Item("Slname")
        '            .Row = i + 1
        '        End With
        '    Next
        'End If
        'AxfpSpread2.ClearRange(1, 1, -1, -1, True)
        'SQL = " SELECT distinct STORECODE,storedesc FROM STOREMASTER WHERE ISNULL(freeze,'')<>'y'"
        'gconnection.getDataSet(SQL, "STOREMASTER")
        'If (gdataset.Tables("STOREMASTER").Rows.Count > 0) Then
        '    For i As Integer = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
        '        With AxfpSpread2
        '            .Row = i + 1
        '            .Col = 1
        '            .Text = gdataset.Tables("STOREMASTER").Rows(i).Item("STORECODE")

        '            .Row = i + 1
        '            .Col = 2
        '            .Text = gdataset.Tables("STOREMASTER").Rows(i).Item("storedesc")
        '            .Row = i + 1
        '        End With
        '    Next
        'End If
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub txt_CATEGORYCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_CATEGORYCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_CATEGORYCode.Text) = "" Then
                Call cmdStoreCode_Click(sender, e)
            Else
                Call txt_CATEGORYCode_Validated(txt_CATEGORYCode, e)
                Call Txt_SLCode_Validated(sender, e)
                Call txt_StoreCode_Validated(sender, e)
            End If
        End If
    End Sub

    Private Sub txt_CATEGORYDesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_CATEGORYDesc.KeyPress
        getAlphanumeric(e)
    End Sub

    Private Sub txt_StoreCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_StoreCode.KeyDown
        If txt_StoreCode.Text <> "" Then
            Call txt_CATEGORYCode_Validated(txt_StoreCode, e)
        Else
            If e.KeyCode = Keys.Enter Then
                cmdStoreCode_Click(sender, e)
            End If

        End If

    End Sub
End Class