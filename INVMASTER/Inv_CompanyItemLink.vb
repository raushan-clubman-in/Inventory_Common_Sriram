Public Class Inv_CompanyItemLink
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Dim boolchk As Boolean
    Private Sub cmdStoreCode_Click(sender As Object, e As EventArgs) Handles cmdStoreCode.Click
        gSQLString = "SELECT ISNULL(COMPANYCODE,'') AS COMPANYCODE,ISNULL(COMPANYDESC,'') AS COMPANYDESC FROM INV_COMPANYMASTER"


        M_WhereCondition = " "
        Dim vform As New ListOperattion1
        vform.Field = "COMPANYCODE,COMPANYDESC"
        vform.vFormatstring = "         COMPANY CODE              |                  COMPANY DESCRIPTION                                                                                                   "
        vform.vCaption = "COMPANY MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_StoreCode.Text = Trim(vform.keyfield & "")
            txt_StoreDesc.Text = Trim(vform.keyfield1 & "")
            Call txt_StoreCode_Validated(txt_StoreCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_StoreCode_Validated(sender As Object, e As EventArgs) Handles txt_StoreCode.Validated
        Dim sql As String = "select itemcode,itemname,'1' as check1,isnull(COMPANYCODE,'') as  COMPANYCODE,isnull(COMPANYDESC,'') as  COMPANYDESC,ISNULL(TARGET,0) AS TARGET ,ISNULL(TARGETVALUE,0) AS TARGETVALUE  from InvCompany_ItemMaster where companycode='" + txt_StoreCode.Text + "'"
        sql = sql + " union all select itemcode,itemname,'0' as check1,'' as  COMPANYCODE,'' as COMPANYDESC,0 AS TARGET,0 AS TARGETVALUE from INV_InventoryItemMaster where itemcode not in (select itemcode from InvCompany_ItemMaster where companycode='" + txt_StoreCode.Text + "') and isnull(void,'N')='N'"
        gconnection.getDataSet(sql, "InvCompany_ItemMaster")
        If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then
            AxfpSpread1.ClearRange(1, 1, -1, -1, True)
            If txt_StoreDesc.Text = "" Then
                txt_StoreDesc.Text = Trim(gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYDESC"))
            End If
            'txt_StoreDesc.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(0).Item("storedesc"))
            For i As Integer = 0 To gdataset.Tables("InvCompany_ItemMaster").Rows.Count - 1
                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("InvCompany_ItemMaster").Rows(i).Item("itemcode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("InvCompany_ItemMaster").Rows(i).Item("itemname")
                    .Row = i + 1
                    .Col = 4
                    .Text = gdataset.Tables("InvCompany_ItemMaster").Rows(i).Item("TARGET")
                    .Col = 5
                    .Text = gdataset.Tables("InvCompany_ItemMaster").Rows(i).Item("TARGETVALUE")
                    .Col = 3
                    .Text = gdataset.Tables("InvCompany_ItemMaster").Rows(i).Item("check1")
                    If (gdataset.Tables("InvCompany_ItemMaster").Rows(i).Item("check1") = "1") Then
                        If txt_StoreDesc.Text = "" Then
                            txt_StoreDesc.Text = Trim(gdataset.Tables("InvCompany_ItemMaster").Rows(i).Item("COMPANYDESC"))
                        End If

                        Cmd_Add.Text = "UPDATE[F7]"
                    End If

                End With
            Next
        End If
    End Sub

    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        If e.keyCode = Keys.F8 Then
            Dim search As New frmSearch
            search.farPoint = AxfpSpread1
            search.Text = "Item Search"
            search.ShowDialog(Me)
            Exit Sub
        ElseIf e.keyCode = Keys.Enter Then
            ' i = AxfpSpread1.ActiveRow
            '   = i
            If AxfpSpread1.ActiveCol = 3 Then
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            ElseIf AxfpSpread1.ActiveCol = 1 Then
                AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow)
            ElseIf AxfpSpread1.ActiveCol = 4 Then
                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

            ElseIf AxfpSpread1.ActiveCol = 5 Then
                AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow + 1)
            End If


        End If

    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
        txt_StoreCode.Text = ""
        txt_StoreDesc.Text = ""
        Dim SQL As String
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        SQL = " SELECT distinct itemcode,itemname FROM INV_InventoryItemMaster WHERE ISNULL(void,'')<>'y'"
        gconnection.getDataSet(SQL, "INV_InventoryItemMaster")
        If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("INV_InventoryItemMaster").Rows.Count - 1
                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("INV_InventoryItemMaster").Rows(i).Item("itemcode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("INV_InventoryItemMaster").Rows(i).Item("itemname")
                    .Row = i + 1




                End With
            Next
        End If
    End Sub
    Private Sub Validation()
        boolchk = False
        Dim qty, value As Double
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            With AxfpSpread1
                .Col = 3
                .Row = i
                If Val(Trim(.Text)) > 0 Then
                    .Col = 4
                    .Row = i
                    qty = (.Text)
                    .Col = 5
                    .Row = i
                    value = (.Text)
                    If qty > value Then
                        MessageBox.Show(" Target Value can't be less than Target qty.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
            End With
        Next

        boolchk = True
    End Sub
    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        If Cmd_Add.Text = "Add[F7]" Then
            ' If boolchk = False Then Exit Sub
            addoperation()
        Else
            'If boolchk = False Then Exit Sub
            updateoperation()

        End If
        clearoperation()
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        voidoperation()
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
        Dim sql As String = "select itemcode,ITEMNAME,'1' as check1,TARGET,TARGETvalue from InvCompany_ItemMaster where companycode='" + txt_StoreCode.Text + "'"
        sql = sql + " union all select itemcode,ITEMNAME,'0' as check1,0 AS TARGET,0 as TARGETvalue from INV_InventoryItemMaster where itemcode not in (select itemcode from InvCompany_ItemMaster where companycode='" + txt_StoreCode.Text + "')"

        ' SQL = " SELECT distinct ITEMCODE,ITEMNAME,'0' as check1  FROM INV_INVENTORYITEMMASTER WHERE ISNULL(VOID,'')<>'y'"
        gconnection.getDataSet(sql, "INV_InventoryItemMaster")
        If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("INV_InventoryItemMaster").Rows.Count - 1
                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("INV_InventoryItemMaster").Rows(i).Item("itemcode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("INV_InventoryItemMaster").Rows(i).Item("itemname")
                    .Row = i + 1
                    .Col = 3
                    .Text = gdataset.Tables("INV_InventoryItemMaster").Rows(i).Item("check1")
                    .Col = 4
                    .Text = gdataset.Tables("INV_InventoryItemMaster").Rows(i).Item("TARGET")
                    .Col = 5
                    .Text = gdataset.Tables("INV_InventoryItemMaster").Rows(i).Item("TARGETvalue")

                End With
            Next
        End If
    End Sub



    Private Sub addoperation()
        Dim Insert(0) As String
        Insert(0) = Nothing
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            With AxfpSpread1
                .Col = 3
                .Row = i
                If Val(Trim(.Text)) > 0 Then
                    Dim sqlstring As String = "Insert into InvCompany_ItemMaster(companycode,companydesc,itemcode,itemname,TARGET,targetvalue,adduser,adddate,freeze,FROMTAG)"
                    sqlstring = sqlstring + " values( '" + txt_StoreCode.Text + "','" + txt_StoreDesc.Text + "',"
                    AxfpSpread1.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 4
                    sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 5
                    sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "','" + gUsername + "', getdate() ,'N','TM')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                End If
            End With
        Next
        gconnection.MoreTrans(Insert)

    End Sub

    Private Sub updateoperation()
        Dim Insert(0) As String


        Dim sql As String = "insert into InvCompany_ItemMaster_log ( itemcode,itemname,companycode,adduser,adddate,Freeze,companydesc,updateuser,updatedate,TARGET ) select itemcode,itemname,companycode,adduser,adddate,Freeze,companydesc,updateuser,updatedate,TARGET from InvCompany_ItemMaster where companycode='" + txt_StoreCode.Text + "'"
        '  ReDim Preserve Insert(Insert.Length)
        Insert(0) = sql
        sql = " delete from InvCompany_ItemMaster where companycode='" + txt_StoreCode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            With AxfpSpread1
                .Row = i
                .Col = 3
                If Val(Trim(.Text)) > 0 Then
                    Dim sqlstring As String = "Insert into InvCompany_ItemMaster(companycode,companydesc,itemcode,itemname,TARGET,TARGETVALUE,adduser,adddate,freeze,FROMTAG)"
                    sqlstring = sqlstring + " values( '" + txt_StoreCode.Text + "','" + txt_StoreDesc.Text + "',"
                    AxfpSpread1.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 4
                    sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 5
                    sqlstring = sqlstring + "   '" + AxfpSpread1.Text + "','" + gUsername + "', getdate() ,'N','TM')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                End If
            End With
        Next
        gconnection.MoreTrans(Insert)

    End Sub

    Private Sub voidoperation()
        Dim Insert(0) As String

        Dim sql As String = "insert into InvCompany_ItemMaster_log(itemcode,itemname,companycode,adduser,adddate,Freeze,TARGET,companydesc,updateuser,updatedate,FROMTAG) select itemcode,itemname,companycode,adduser,adddate,Freeze,TARGET,companydesc,updateuser,updatedate,FROMTAG from InvCompany_ItemMaster where companycode='" + txt_StoreCode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        sql = " delete from InvCompany_ItemMaster where companycode='" + txt_StoreCode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        gconnection.MoreTrans(Insert)

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

    Private Sub Inv_CompanyItemLink_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
        'Call Resize_Form()
        'Me.DoubleBuffered = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        ' Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "Company Item Tagging"

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
            cmdStoreCode_Click(sender, e)
        End If

    End Sub
End Class