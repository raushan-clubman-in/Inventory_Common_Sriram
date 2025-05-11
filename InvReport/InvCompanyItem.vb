Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class InvCompanyItem
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 768
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

    Private Sub FillItemdetails()
        Dim i As Integer
        Dim sqlstring As String
        CheckedListBox3.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME FROM INV_InventoryItemMaster where isnull(VOID,'') <> 'Y' ORDER BY ITEMCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                    CheckedListBox3.Items.Add(Trim(CStr(.Item("ITEMCODE"))) & "-->" & Trim(CStr(.Item("ITEMNAME"))))
                End With
            Next
        End If
    End Sub
    Private Sub FillGroupdetails()
        Dim i As Integer
        Dim sqlstring As String
        CheckedListBox2.Items.Clear()
        sqlstring = "SELECT ISNULL(COMPANYCODE,'') AS COMPANYCODE,ISNULL(COMPANYDESC,'') AS COMPANYDESC FROM INV_COMPANYMASTER  where COMPANYCODE in (select COMPANYCODE from InvCompany_ItemMaster) AND ISNULL(FREEZE,'N')='N' ORDER BY COMPANYCODE "
        gconnection.getDataSet(sqlstring, "INV_COMPANYMASTER")
        If gdataset.Tables("INV_COMPANYMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INV_COMPANYMASTER").Rows.Count - 1
                With gdataset.Tables("INV_COMPANYMASTER").Rows(i)
                    CheckedListBox2.Items.Add(Trim(CStr(.Item("COMPANYCODE"))))
                End With
            Next
        End If
    End Sub




    Private Sub InvStockSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'FillItemdetails()
        FillGroupdetails()

        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
            dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")

        ElseIf UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/Jan/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Company Wise Item Offtake Report"
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_View.Enabled = False
        Me.Cmd_Print.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_View.Enabled = True
                    Me.Cmd_Print.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.Cmd_Print.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Dim i As Integer
        ChkItemCode.Checked = False
        ChkCategory.Checked = False
        txt_mainstore.Text = ""
        txt_mainstorecode.Text = ""
        FillGroupdetails()
        dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        For I = 0 To CheckedListBox3.Items.Count - 1
            CheckedListBox3.SetItemChecked(i, False)
        Next
        For i = 0 To CheckedListBox2.Items.Count - 1
            CheckedListBox2.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub ChkCategory_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCategory.CheckedChanged
        Dim i As Integer = 0

        If (ChkCategory.Checked = True) Then
            For i = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, False)
            Next

        End If
        CheckedListBox2_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub ChkItemCode_CheckedChanged(sender As Object, e As EventArgs) Handles ChkItemCode.CheckedChanged
        Dim i As Integer = 0
        If (ChkItemCode.Checked = True) Then
            For i = 0 To CheckedListBox3.Items.Count - 1
                CheckedListBox3.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CheckedListBox3.Items.Count - 1
                CheckedListBox3.SetItemChecked(i, False)
            Next

        End If

    End Sub
    Private Sub cmd_storecode_Click(sender As Object, e As EventArgs) Handles cmd_storecode.Click
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
        M_WhereCondition = " where freeze <> 'Y' "
        Dim vform As New ListOperattion1

        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "             STORE CODE                   |                   STORE DESCRIPTION                             "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_mainstorecode.Text = Trim(vform.keyfield & "")
            txt_mainstore.Text = Trim(vform.keyfield1 & "")
            dtpfromdate.Focus()
        End If
        vform.Close()
        vform = Nothing

    End Sub

    Private Sub txt_mainstorecode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_mainstorecode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_storecode_Click(cmd_storecode, e)
        End If

    End Sub

    Private Sub txt_mainstorecode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_mainstorecode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_mainstorecode.Text) = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
            Else
                Call txt_mainstorecode_Validated(sender, e)
                dtpfromdate.Focus()
            End If
        End If

    End Sub

    Private Sub txt_mainstorecode_Validated(sender As Object, e As EventArgs) Handles txt_mainstorecode.Validated
        Try
            If Trim(txt_mainstorecode.Text) <> "" Then
                sqlstring = "SELECT * FROM storemaster WHERE storecode='" & Trim(txt_mainstorecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "storemaster")
                If gdataset.Tables("storemaster").Rows.Count > 0 Then
                    txt_mainstorecode.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                    txt_mainstore.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                    dtpfromdate.Focus()
                End If
            End If
        Catch
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub CheckedListBox2_Click(sender As Object, e As EventArgs) Handles CheckedListBox2.Click
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM InvCompany_ItemMaster AS I "
        sqlstring = sqlstring & " WHERE isnull(Freeze,'') <> 'Y' and I.COMPANYCODE IN ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
            End If
        Next
        If CheckedListBox2.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "InvCompany_ItemMaster")
            If gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0 Then
                CheckedListBox3.Items.Clear()
                For i = 0 To gdataset.Tables("InvCompany_ItemMaster").Rows.Count - 1
                    With gdataset.Tables("InvCompany_ItemMaster").Rows(i)
                        CheckedListBox3.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        End If

    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM InvCompany_ItemMaster AS I "
        sqlstring = sqlstring & " WHERE isnull(Freeze,'') <> 'Y' and I.COMPANYCODE IN ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
            End If
        Next
        If CheckedListBox2.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "InvCompany_ItemMaster")
            If gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0 Then
                CheckedListBox3.Items.Clear()
                For i = 0 To gdataset.Tables("InvCompany_ItemMaster").Rows.Count - 1
                    With gdataset.Tables("InvCompany_ItemMaster").Rows(i)
                        CheckedListBox3.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        Else
            CheckedListBox3.Items.Clear()

        End If

    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        VIEWSTOCKSUMMARY()
    End Sub


    Private Sub VIEWSTOCKSUMMARY()
        Try
            Dim sqlstring, CATEGORY, ITEMNAME(), items As String
            Dim i As Integer
            Dim r As New CryCompanyWiseItem
            Dim rViewer As New Viewer
            ' gconnection.valuation()
            Me.Cursor = Cursors.WaitCursor


            If CheckedListBox2.CheckedItems.Count <> 0 Then
                For i = 0 To CheckedListBox2.CheckedItems.Count - 1
                    ' SUPPLIERNAME = Split(CheckedListBox2.CheckedItems(i), "-->")
                    CATEGORY = CATEGORY & " '" & CheckedListBox2.CheckedItems(i) & "', "
                Next
                CATEGORY = Mid(CATEGORY, 1, Len(CATEGORY) - 2)
                ' sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Company Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If CheckedListBox3.CheckedItems.Count <> 0 Then
                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                    items = items & " '" & Trim(ITEMNAME(0)) & "', "
                Next
                items = Mid(items, 1, Len(items) - 2)
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            sqlstring = " if exists(select * from sysobjects where name='INV_COMPANYWISEITEM') begin DROP TABLE INV_COMPANYWISEITEM end   "
            gconnection.dataOperation(6, sqlstring, "ratelist")


            sqlstring = "SELECT CI.ITEMCODE,CI.Itemname,I.stockuom AS UOM, CI.COMPANYCODE,CI.COMPANYDESC,0 AS PURCHASE,SUM(ISNULL(CI.TARGET,0)) AS TARGET,SUM(ISNULL(CI.TARGETVALUE,0)) AS TARGETVALUE,"
            sqlstring = sqlstring & " 0 AS SALES , 0 various ,0 AS BALAENCE,0 as PurValue,0 as value,0 as BALvalue INTO  INV_COMPANYWISEITEM FROM InvCompany_ItemMaster CI INNER JOIN INV_InventoryItemMaster I ON CI.Itemcode=I.itemcode "
            sqlstring = sqlstring & " WHERE  ISNULL(CI.Freeze,'')<>'Y' AND  CI.ITEMCODE IN (" & items & ") AND  CI.COMPANYCODE IN (" & CATEGORY & ") GROUP BY CI.ITEMCODE,CI.Itemname,CI.COMPANYCODE,CI.COMPANYDESC,I.stockuom  "
            gconnection.dataOperation(6, sqlstring, "ratelist")


            sqlstring = "UPDATE INV_COMPANYWISEITEM SET PURCHASE= ISNULL((select SUM(QTY) from GRN_DETAILS G WHERE INV_COMPANYWISEITEM.Itemcode=G.Itemcode AND INV_COMPANYWISEITEM.companycode=G.companycode "
            sqlstring = sqlstring & " AND  ISNULL(G.Voiditem,'')<>'Y' AND AMOUNT>0 AND CAST(GRNDATE AS DATE) BETWEEN  '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0),PurValue=ISNULL((select SUM(AMOUNT) from GRN_DETAILS G WHERE INV_COMPANYWISEITEM.Itemcode=G.Itemcode AND INV_COMPANYWISEITEM.companycode=G.companycode "
            sqlstring = sqlstring & " AND  ISNULL(G.Voiditem,'')<>'Y' AND AMOUNT>0 AND CAST(GRNDATE AS DATE) BETWEEN  '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
            gconnection.dataOperation(6, sqlstring, "ratelist")

            'sqlstring = "  UPDATE INV_COMPANYWISEITEM SET SALES= ISNULL(( SELECT SUM((B.gqty*k.QTY)) GQTY  FROM Kot_Det K INNER JOIN bom_det B ON "
            'sqlstring = sqlstring & " K.ITEMCODE=B.Itemcode AND K.UOM=B.ItemUOM INNER JOIN KOT_HDR H ON K.KOTDETAILS=H.KOTDETAILS 	WHERE ISNULL(K.KOTSTATUS,'')<>'Y' and ISNULL(K.BILLDETAILS,'')<>''  AND ISNULL(K.DELFLAG,'')<>'Y' AND INV_COMPANYWISEITEM.Itemcode=K.ITEMCODE AND cast(K.KOTDATE as date) BETWEEN  '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' 	GROUP BY B.gitemcode,B.GUOM ),0)  "
            'gconnection.dataOperation(6, sqlstring, "ratelist")
            sqlstring = " UPDATE INV_COMPANYWISEITEM SET TARGETVALUE=isnull((select sum(TARGETVALUE) from InvCompany_ItemMaster i where INV_COMPANYWISEITEM.ITEMCODE=i.Itemcode and INV_COMPANYWISEITEM.COMPANYCODE=i.companycode) ,0)  "
            gconnection.dataOperation(6, sqlstring, "ratelist")


            sqlstring = " UPDATE INV_COMPANYWISEITEM SET value=TARGETVALUE/TARGET WHERE TARGET<>0 "
            gconnection.dataOperation(6, sqlstring, "ratelist")

            sqlstring = " UPDATE INV_COMPANYWISEITEM SET BALvalue=TARGETVALUE-PURvALUE "
            gconnection.dataOperation(6, sqlstring, "ratelist")

            sqlstring = " UPDATE INV_COMPANYWISEITEM SET various=TARGET-PURCHASE "
            gconnection.dataOperation(6, sqlstring, "ratelist")

            sqlstring = " UPDATE INV_COMPANYWISEITEM SET BALAENCE=PURCHASE-SALES "
            gconnection.dataOperation(6, sqlstring, "ratelist")

            sqlstring = " UPDATE INV_COMPANYWISEITEM SET BALAENCE=0 where BALAENCE<0 "
            gconnection.dataOperation(6, sqlstring, "ratelist")

            sqlstring = " UPDATE INV_COMPANYWISEITEM SET various=0 where various<0 "
            gconnection.dataOperation(6, sqlstring, "ratelist")

            If chkWithOffTake.Checked = True And ChkSales.Checked = True And chkTarget.Checked = True Then
                sqlstring = " select itemcode,itemname,uom,companycode,companydesc,target,purchase,sales,various,BALAENCE from INV_COMPANYWISEITEM "
                sqlstring = " select * from INV_COMPANYWISEITEM "
            ElseIf chkWithOffTake.Checked = False And ChkSales.Checked = True And chkTarget.Checked = True Then
                sqlstring = " select itemcode,itemname,uom,companycode,companydesc,target,purchase,sales,BALAENCE from INV_COMPANYWISEITEM "
            ElseIf chkWithOffTake.Checked = False And ChkSales.Checked = False And chkTarget.Checked = False Then
                sqlstring = " select itemcode,itemname,uom,companycode,companydesc,purchase,BALAENCE from INV_COMPANYWISEITEM "
            ElseIf chkWithOffTake.Checked = True And ChkSales.Checked = False And chkTarget.Checked = False Then
                sqlstring = " select itemcode,itemname,uom,companycode,companydesc,purchase,BALAENCE,various from INV_COMPANYWISEITEM "
            ElseIf chkWithOffTake.Checked = True And ChkSales.Checked = True And chkTarget.Checked = False Then
                sqlstring = " select itemcode,itemname,uom,companycode,companydesc,purchase,sales,BALAENCE,various from INV_COMPANYWISEITEM "
            ElseIf chkWithOffTake.Checked = False And ChkSales.Checked = True And chkTarget.Checked = False Then
                sqlstring = " select itemcode,itemname,uom,companycode,companydesc,purchase,sales,BALAENCE from INV_COMPANYWISEITEM "

            Else
                sqlstring = " select * from INV_COMPANYWISEITEM "
            End If


            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "INV_COMPANYWISEITEM")
            If gdataset.Tables("INV_COMPANYWISEITEM").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "INV_COMPANYWISEITEM"
                'Dim picture1 As PictureObject
                'picture1 = r.ReportDefinition.ReportObjects("picture1")
                'If (gShortname = "KOLKATA") Then
                '    picture1.ObjectFormat.EnableSuppress = False
                'Else
                '    picture1.ObjectFormat.EnableSuppress = True

                'End If
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName

                Dim textobj5 As TextObject
                textobj5 = r.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(gCompanyAddress(0))
                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(gCompanyAddress(1))
                'Dim textobj2 As TextObject
                'textobj2 = r.ReportDefinition.ReportObjects("Text13")
                'textobj2.Text = Trim(txt_mainstore.Text)
                Dim textobj22 As TextObject
                textobj22 = r.ReportDefinition.ReportObjects("Text11")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                If chkWithOffTake.Checked = False Then
                    Dim textobj61 As TextObject
                    textobj61 = r.ReportDefinition.ReportObjects("Text6")
                    textobj61.Text = ""

                End If
                If chkTarget.Checked = False Then
                    Dim textobj61 As TextObject
                    textobj61 = r.ReportDefinition.ReportObjects("Text3")
                    textobj61.Text = ""
                End If

                If ChkSales.Checked = False Then
                    Dim textobj61 As TextObject
                    textobj61 = r.ReportDefinition.ReportObjects("Text5")
                    textobj61.Text = ""
                End If



                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If
            Me.Cursor = Cursors.Default


        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub


    Private Sub ButExport_Click(sender As Object, e As EventArgs) Handles ButExport.Click
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New Crystocksummary
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor
            gconnection.valuation()
            sqlstring = " delete from stocksummary"
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,uom,opstk) "
            sqlstring = sqlstring & " select O.itemcode,I.ITEMNAME,storecode, "
            sqlstring = sqlstring & " O.uom,O.openningqty from inv_InventoryOpenningstock O INNER JOIN INV_InventoryItemMaster I ON I.ITEMCODE=O.ITEMCODE where storecode ='" + txt_mainstorecode.Text + "' "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND O.ITEMCODE IN ("
                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                    sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND ISNULL(O.void,'') <>'Y' "
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"

            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " select ITEMCODE,ITEMNAME ,UOM,OPSTK,opweightedrate AS OPRATE,opvalue AS OPVALUE,issqty AS ISSUE_QTY,dmgqty AS DMG_QTY,adjqty AS ADJ_QTY,saleqty AS SALE_QTY,receiveqty AS REC_QTY,closingqty AS CLOSING_QTY,clweightedrate AS CLOSING_RATE,clvalue AS CLOSING_VALUE from stocksummary where (issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') order by itemcode"
            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "stocksummary")
            If gdataset.Tables("stocksummary").Rows.Count > 0 Then

                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "Stock Consumption " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If
            Me.Cursor = Cursors.Default


        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        VIEWSTOCKSUMMARY()
    End Sub

    Private Sub InvStockSummary_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F10 Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F12 Then
                Call ButExport_Click(sender, e)
                Exit Sub

            ElseIf e.KeyCode = Keys.F9 Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.Escape Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub

            ElseIf e.KeyCode = Keys.F2 Then
                Dim search As New frmListSearch
                search.listbox = CheckedListBox2
                search.Text = "Company Search"
                search.ShowDialog(Me)

            ElseIf e.KeyCode = Keys.F1 Then
                Dim Advsearch As New frmListSearch
                Advsearch.listbox = CheckedListBox3
                Advsearch.Text = "Item Search"
                Advsearch.ShowDialog(Me)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Stock Summary " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub CheckedListBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox3.KeyDown

        If e.KeyCode = Keys.F1 Then
            Dim Advsearch As New frmListSearch
            Advsearch.listbox = CheckedListBox3
            Advsearch.Text = "Item Search"
            Advsearch.ShowDialog(Me)
        End If
    End Sub

    Private Sub CheckedListBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox2.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim search As New frmListSearch
            search.listbox = CheckedListBox2
            search.Text = "Category Search"
            search.ShowDialog(Me)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            GroupBox4.Visible = True
        Else
            GroupBox4.Visible = False
        End If
    End Sub
End Class