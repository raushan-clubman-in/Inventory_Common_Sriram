Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class InvCon_Issue
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
        sqlstring = "SELECT DISTINCT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME FROM INV_InventoryItemMaster  ORDER BY ITEMCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                    CheckedListBox3.Items.Add(Trim(CStr(.Item("ITEMCODE"))) & "-->" & Trim(CStr(.Item("ITEMNAME"))))
                End With
            Next
        End If
    End Sub
    'Private Sub FillGroupdetails()
    '    Dim i As Integer
    '    Dim sqlstring As String
    '    CheckedListBox2.Items.Clear()
    '    sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER  where CATEGORYCODE in (select CATEGORYCODE from INV_INVENTORYITEMMASTER) ORDER BY CATEGORYCODE "
    '    gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
    '    If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
    '        For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
    '            With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
    '                CheckedListBox2.Items.Add(Trim(CStr(.Item("CATEGORYCODE"))))
    '            End With
    '        Next
    '    End If
    'End Sub


    Private Sub FillStore()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT  ISNULL(STOREdesc,'') AS STOREdesc FROM STOREMASTER WHERE isnull(storestatus,'') <> 'M' and isnull(freeze,'') <> 'Y' ORDER BY STOREdesc ASC"
        gconnection.getDataSet(Sqlstring, "STOREMASTER")
        CheckedListBox1.Items.Clear()
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                CheckedListBox1.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STOREdesc"))
            Next i
        End If
    End Sub
    Private Sub fILLGroups()
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT  distinct (ISNULL(I.groupcode,'') )AS groupcode,ISNULL(g.groupdesc,'') AS groupdesc FROM INV_INVENTORYITEMMASTER AS I  inner join inventorygroupmaster g on i.groupcode=g.Groupcode "
        '' sqlstring = sqlstring & ""

        'sqlstring = sqlstring & ssql & " ORDER BY i.groupcode "
        gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
        If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
            Chklist_Groupdesc.Items.Clear()
            For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                    Chklist_Groupdesc.Items.Add(Trim(.Item("groupcode") & "-->" & .Item("groupdesc")))
                End With
            Next i
        End If
    End Sub
    Private Sub FillmAINStore()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT  ISNULL(STOREdesc,'') AS STOREdesc FROM STOREMASTER WHERE isnull(storestatus,'') = 'M' and isnull(freeze,'') <> 'Y' ORDER BY STOREdesc ASC"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        CheckedListBox2.Items.Clear()
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                CheckedListBox2.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STOREdesc"))
            Next i
        End If
    End Sub

    Private Sub InvStockSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' FillItemdetails()
        FillStore()
        FillmAINStore()
        fILLGroups()
        '  FillGroupdetails()

        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
            dtpfromdate.Value = Format(CDate("01/Jan/2016"), "dd/MMM/yyyy")

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
        GmoduleName = "Stock Summary"
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
        CheckBox2.Checked = False
        ChkSupplier.Checked = False
        'ChkCategory.Checked = False
        Chk_SelectAllGroup.Checked = False
        txt_mainstore.Text = ""
        txt_mainstorecode.Text = ""
        dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        For i = 0 To CheckedListBox3.Items.Count - 1
            CheckedListBox3.SetItemChecked(i, False)
        Next
        For i = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(i, False)
        Next
        For i = 0 To CheckedListBox2.Items.Count - 1
            CheckedListBox2.SetItemChecked(i, False)
        Next
        'For i = 0 To CheckedListBox2.Items.Count - 1
        '    CheckedListBox2.SetItemChecked(i, False)
        'Next
        For i = 0 To Chklist_Groupdesc.Items.Count - 1
            Chklist_Groupdesc.SetItemChecked(i, False)
        Next
        CheckedListBox3.Items.Clear()
        fILLGroups()
        'CheckedListBox3.Items.Clear()
    End Sub

    Private Sub ChkCategory_CheckedChanged(sender As Object, e As EventArgs)
        Dim i As Integer = 0

        'If (ChkCategory.Checked = True) Then
        '    For i = 0 To CheckedListBox2.Items.Count - 1
        '        CheckedListBox2.SetItemChecked(i, True)
        '    Next

        'Else
        '    For i = 0 To CheckedListBox2.Items.Count - 1
        '        CheckedListBox2.SetItemChecked(i, False)
        '    Next

        'End If
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
    Private Sub CheckedListBox2_Click(sender As Object, e As EventArgs)
        'Dim i, J As Integer
        'Dim sqlstring, ssql As String
        'ssql = ""
        'sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        'sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' and I.CATEGORY IN ("

        'For J = 0 To CheckedListBox2.CheckedItems.Count - 1
        '    If J = CheckedListBox2.CheckedItems.Count - 1 Then
        '        ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "' "
        '    Else
        '        ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
        '    End If
        'Next
        'If CheckedListBox2.CheckedItems.Count > 0 Then
        '    sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
        '    gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
        '    If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
        '        CheckedListBox3.Items.Clear()
        '        For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
        '            With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
        '                CheckedListBox3.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
        '            End With
        '        Next i
        '    End If
        'End If
        CheckedListBox2_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Dim i, J As Integer
        'Dim sqlstring, ssql As String
        'ssql = ""
        'sqlstring = "SELECT  distinct (ISNULL(I.groupcode,'') )AS groupcode,ISNULL(g.groupdesc,'') AS groupdesc FROM INV_INVENTORYITEMMASTER AS I  inner join inventorygroupmaster g on i.groupcode=g.Groupcode "
        'sqlstring = sqlstring & " WHERE  I.CATEGORY IN ("

        ''For J = 0 To CheckedListBox2.CheckedItems.Count - 1
        ''    If J = CheckedListBox2.CheckedItems.Count - 1 Then
        ''        ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "'"
        ''    Else
        ''        ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
        ''    End If
        ''Next
        ''If CheckedListBox2.CheckedItems.Count > 0 Then
        'sqlstring = sqlstring & ssql & ") ORDER BY groupcode "
        'gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
        'If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
        '    Chklist_Groupdesc.Items.Clear()
        '    For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
        '        With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
        '            Chklist_Groupdesc.Items.Add(Trim(.Item("groupcode") & "-->" & .Item("groupdesc")))
        '        End With
        '    Next i
        'End If
        ''Else
        'Chklist_Groupdesc.Items.Clear()

        'End If

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
            Dim sqlstring, CATEGORY(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New CrystocksummaryGroup
            Dim rViewer As New Viewer
            ' gconnection.valuation()

            If txt_mainstorecode.Text <> "" Then

            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            '          'update ratelist set weightedrate=closingvalue/closingstock ,  lastweightedrate=  case when openningvalue=0 then     
            'batchrate    Else  openningvalue/openningstock      End 
            ' from ratelist r inner join CLOSINGQTY on r.grnno=CLOSINGQTY.trnno where
            '          trndate = r.grndate And CLOSINGQTY.storecode = r.storecode And CLOSINGQTY.itemcode = r.Itemcode




            sqlstring = " delete from stocksummary"
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY) "
            sqlstring = sqlstring & " select itemcode,ITEMNAME,'" + txt_mainstorecode.Text + "',STOCKUOM ,'0','0','0' "
            sqlstring = sqlstring & " from INV_InventoryItemMaster where  "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  ITEMCODE IN ("
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
            gconnection.dataOperation(6, sqlstring, "stocksummary")

            sqlstring = " update stocksummary set uom=O.uom,opstk=O.openningqty,OPENNINGQTY=O.openningqty"
            ' sqlstring = sqlstring & " select O.itemcode,I.ITEMNAME,storecode, "
            sqlstring = sqlstring & " from inv_InventoryOpenningstock O inner join stocksummary on O.ITEMCODE=stocksummary.ITEMCODE  where O.storecode ='" + txt_mainstorecode.Text + "' "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND stocksummary.ITEMCODE  IN ("
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

            'sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"

            'gconnection.ExcuteStoreProcedure(sqlstring)

            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                    sqlstring = " exec CP_stocksummary  '01/01/2016', '01/01/2016','" + Format(DTPaSondATE.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
                Else
                    sqlstring = " exec CP_stocksummary  '01/01/2016', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
                End If

                'sqlstring = " exec CP_stocksummary  '01/01/2016', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy ") + "','" + txt_mainstorecode.Text + "'"
            Else
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                    sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "','" + Format(DTPaSondATE.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
                Else
                    sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
                End If

            End If
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " update stocksummary set stocksummary.groupcode=i.groupcode, stocksummary.groupdesc=g.Groupdesc  from INV_InventoryItemMaster I  inner join stocksummary on i.ITEMCODE=stocksummary.ITEMCODE  inner join inventorygroupmaster g on i.groupcode=g.Groupcode"
            gconnection.dataOperation(6, sqlstring, "ratelist")

            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or UCase(gShortname) = "HSR" Then
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    'sqlstring = "update stocksummary set opstk=cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/100),Openningqty=cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100),"
                    'sqlstring = sqlstring & "Issqty=cast(Issqty as Int)+(((ABS(Issqty)-cast(Issqty as Int))*t.CONVVALUE)/100),"
                    sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/100) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                    sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                    ' sqlstring = sqlstring & "DMGQTY=cast(DMGQTY as Int)+(((ABS(DMGQTY)-cast(DMGQTY as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                    ' sqlstring = sqlstring & "closingqty=cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "closingqty=case when closingqty>0  then cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "ADJQTY=cast(ADJQTY as Int)+(((ABS(ADJQTY)-cast(ADJQTY as Int))*t.CONVVALUE)/100)"
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM and S.CATEGORYCODE NOT IN ('PRO')"

                Else
                    sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/100) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                    'sqlstring = "update stocksummary set opstk=cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/100),Openningqty=cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100),"
                    'sqlstring = sqlstring & "Issqty=cast(Issqty as Int)+(((ABS(Issqty)-cast(Issqty as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                    '- sqlstring = sqlstring & "DMGQTY=cast(DMGQTY as Int)+(((ABS(DMGQTY)-cast(DMGQTY as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                    '  sqlstring = sqlstring & "closingqty=cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "closingqty=case when closingqty>0  then cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "ADJQTY=cast(ADJQTY as Int)+(((ABS(ADJQTY)-cast(ADJQTY as Int))*t.CONVVALUE)/100)"
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM"

                End If

                gconnection.dataOperation(6, sqlstring, )

            Else

            End If


            'gconnection.dataOperation(6, "exec cp_stockissue", )
            If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype='issue' and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                    gconnection.dataOperation(6, sqlstring, )
                Else
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype='issue' and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                    gconnection.dataOperation(6, sqlstring, )
                    '   gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 and isnull(T.void,'N')<>'Y' AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN CAST(CONVERT(VARCHAR(11),'01/Apr/2016' ,106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )

                End If

            Else
                'If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                'gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from TEMPSTOCKISSUEDETAIL t where t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)", )

                'Else
                sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype='issue' and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                gconnection.dataOperation(6, sqlstring, )
                ' gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 and isnull(T.void,'N')<>'Y' AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN CAST(CONVERT(VARCHAR(11),'" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "',106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )
                'End If

            End If

            gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )

            '' If UCase(gShortname) = "HSR" Then
            sqlstring = "update stocksummary set     issqty=issqty*-1,dmgqty=dmgqty*-1,saleqty=saleqty*-1 "
            gconnection.dataOperation(6, sqlstring, )

            ''  End If

            If chksummary.Checked = True Then
                sqlstring = " select * from stocksummary where (openningqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') "
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    sqlstring = sqlstring & " order by itemname"
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
            Else
                sqlstring = " select * from stocksummary where ( issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0')"
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    sqlstring = sqlstring & " order by itemname"
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
            End If

            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "stocksummary")
            If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "Stocksummary"
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
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text13")
                textobj2.Text = Trim(txt_mainstore.Text)
                Dim textobj22 As TextObject
                textobj22 = r.ReportDefinition.ReportObjects("Text11")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                    TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                    Dim textobj29 As TextObject
                    textobj29 = r.ReportDefinition.ReportObjects("Text10")
                    textobj29.Text = "DATE :"

                Else
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
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
            Dim sqlstring, CATEGORY(), ITEMNAME(), STORECODE(), subStore, D_Month, D_MonthArray(), U_MONTH, store, items, Mstore, d_store, d_Mstore, MSTORECODE() As String
            Dim i, z As Integer


            If CheckedListBox2.CheckedItems.Count <> 0 Then
                Mstore = "("
                d_Mstore = ""
                For i = 0 To CheckedListBox2.CheckedItems.Count - 1
                    ''     MSTORECODE = Split(CheckedListBox2.Items(i), "-")
                    Mstore = Mstore & " '" & Trim(CheckedListBox2.CheckedItems(i).ToString()) & "', "
                    d_Mstore = d_Mstore & " " & Trim(CheckedListBox2.CheckedItems(i).ToString()) & ", "
                Next
                Mstore = Mid(Mstore, 1, Len(Mstore) - 2)
                d_Mstore = Mid(d_Mstore, 1, Len(d_Mstore) - 2)
                Mstore = Mstore & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If CheckedListBox1.CheckedItems.Count <> 0 Then
                store = "("
                d_store = ""
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                    store = store & " '" & Trim(STORECODE(0)) & "', "
                    d_store = d_store & " " & Trim(STORECODE(0)) & ","
                Next
                store = Mid(store, 1, Len(store) - 2)
                d_store = Mid(d_store, 1, Len(d_store) - 1)
                store = store & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If CheckedListBox3.CheckedItems.Count <> 0 Then
                items = "("

                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-")
                    items = items & " '" & Trim(ITEMNAME(0)) & "', "

                Next
                items = Mid(items, 1, Len(items) - 2)

                items = items & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If



            sqlstring = " DECLARE @StartDate  DATETIME= '" + Format(dtpfromdate.Value, "yyyyMMdd") + "' , @EndDate    DATETIME = '" + Format(dtptodate.Value, "yyyyMMdd") + "'; "
            sqlstring = sqlstring & " SELECT DATENAME(MONTH, DATEADD(MONTH, A.MonthId - 1, @StartDate)) Name, (A.MonthId + 1) as MonthId  FROM(   SELECT 1 AS MonthId      UNION      SELECT 2      UNION      SELECT 3      UNION      SELECT 4      UNION      SELECT 5      UNION      SELECT 6  "
            sqlstring = sqlstring & " UNION     SELECT 7      UNION      SELECT 8      UNION      SELECT 9      UNION      SELECT 10      UNION      SELECT 11      UNION      SELECT 12 ) AS A  WHERE  A.MonthId <= DATEDIFF(MONTH, @StartDate, @EndDate) + 1;"
            gconnection.getDataSet(sqlstring, "SELECTED_MONTH")
            If gdataset.Tables("SELECTED_MONTH").Rows.Count > 0 Then
                D_Month = ""
                U_MONTH = "("
                For z = 0 To gdataset.Tables("SELECTED_MONTH").Rows.Count - 1
                    D_Month = D_Month + Trim(gdataset.Tables("SELECTED_MONTH").Rows(z).Item("name")) + ","
                    U_MONTH = U_MONTH + "'" + Trim(gdataset.Tables("SELECTED_MONTH").Rows(z).Item("name")) + "',"
                Next
                D_Month = Mid(D_Month, 1, Len(D_Month) - 1)
                U_MONTH = Mid(U_MONTH, 1, Len(U_MONTH) - 1)
                U_MONTH = U_MONTH & ")"
            End If

            sqlstring = "IF  EXISTS( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SELECTED_MONTH_DATA') Begin  drop table SELECTED_MONTH_DATA End"
            gconnection.ExcuteStoreProcedure(sqlstring)

            
            sqlstring = " CREATE TABLE SELECTED_MONTH_DATA  "

            sqlstring = sqlstring & " ( ITEMCODE varchar(20),ITEMNAME varchar(100) ,UOM varchar(10),Groupdesc varchar(50),"
            D_MonthArray = Split(D_Month, ",")
            For i = 0 To D_MonthArray.Length - 1
                sqlstring = sqlstring & " curQty" + D_MonthArray(i) + Date.Now.Year.ToString() + " numeric(18, 2),curAmt" + D_MonthArray(i) + Date.Now.Year.ToString() + " numeric(18, 2),preQty" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + " numeric(18, 2),preAmt" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + " numeric(18, 2), "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
            gconnection.dataOperation(6, sqlstring, "SELECTED_MONTH_DATA")

            sqlstring = " insert into SELECTED_MONTH_DATA (ITEMCODE,ITEMNAME,UOM,Groupdesc)  select ITEMCODE,ITEMNAME,UOM,Groupdesc from  VW_YEARLY_CONS_ISSUE_RPT_MONTHLY"
            sqlstring = sqlstring & " where month in " + U_MONTH + " "
            sqlstring = sqlstring & "and storelocationname in " + Mstore + ""
            sqlstring = sqlstring & "and opstorelocationname in " + store + " and itemcode in  " + items + " GROUP BY ITEMCODE,ITEMNAME,UOM,Groupdesc"

            gconnection.ExcuteStoreProcedure(sqlstring)

            D_MonthArray = Split(D_Month, ",")
            For i = 0 To D_MonthArray.Length - 1


                sqlstring = "IF  EXISTS( SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DT') Begin  drop table DT End"
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = "  select sum(cqty) as cqty ,sum(camount)  as camount,suM(pqty) as pqty,sum(pamout) as pamout,ITEMCODE into DT from VW_YEARLY_CONS_ISSUE_RPT_MONTHLY where ITEMCODE in " + items + " and month ='" + D_MonthArray(i) + "' AND storelocationname IN " + Mstore + " AND  opstorelocationname IN " + store + " GROUP BY ITEMCODE"
                'sqlstring = sqlstring & " curQty" + D_MonthArray(i) + Date.Now.Year.ToString() + " numeric(18, 2),curAmt" + D_MonthArray(i) + Date.Now.Year.ToString() + " numeric(18, 2),preQty" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + " numeric(18, 2),preAmt" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + " numeric(18, 2), "
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = " update SELECTED_MONTH_DATA set curQty" + D_MonthArray(i) + Date.Now.Year.ToString() + "=cqty,curAmt" + D_MonthArray(i) + Date.Now.Year.ToString() + "=camount,preQty" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + "=pqty,preAmt" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + "=pamout  from dt WHERE SELECTED_MONTH_DATA.ITEMCODE=dt.itemcode "
                'sqlstring = sqlstring & " curQty" + D_MonthArray(i) + Date.Now.Year.ToString() + " numeric(18, 2),curAmt" + D_MonthArray(i) + Date.Now.Year.ToString() + " numeric(18, 2),preQty" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + " numeric(18, 2),preAmt" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + " numeric(18, 2), "
                gconnection.ExcuteStoreProcedure(sqlstring)
                sqlstring = " update SELECTED_MONTH_DATA set curQty" + D_MonthArray(i) + Date.Now.Year.ToString() + "=0 where curQty" + D_MonthArray(i) + Date.Now.Year.ToString() + " is null "
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = " update SELECTED_MONTH_DATA set curAmt" + D_MonthArray(i) + Date.Now.Year.ToString() + "=0 where curAmt" + D_MonthArray(i) + Date.Now.Year.ToString() + " is null "
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = " update SELECTED_MONTH_DATA set preQty" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + "=0 where preQty" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + " is null "
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = " update SELECTED_MONTH_DATA set preAmt" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + "=0 where preAmt" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + " is null "
                gconnection.ExcuteStoreProcedure(sqlstring)
            Next


            Me.Cursor = Cursors.WaitCursor


            sqlstring = " select itemcode ,itemname,uom,"
            For i = 0 To D_MonthArray.Length - 1
                sqlstring = sqlstring & "" + "curQty" + D_MonthArray(i) + Date.Now.Year.ToString() + " as QTY,curAmt" + D_MonthArray(i) + Date.Now.Year.ToString() + " AS AMT,preQty" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + " AS QTY,preAmt" + D_MonthArray(i) + (Date.Now.Year - 1).ToString() + " AS AMT,"
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 1)
            sqlstring = sqlstring & " FROM SELECTED_MONTH_DATA "

            gconnection.getDataSet(sqlstring, "SELECTED_MONTH_DATA")
            If gdataset.Tables("SELECTED_MONTH_DATA").Rows.Count > 0 Then

                Dim exp As New exportexcel
                exp.Show()
                Call exp.export_Con_Issue(sqlstring, "Yearly Consolidated Issue Report Monthly" & Format(dtpfromdate.Value, "MMM-yyyy") & " TO " & Format(dtptodate.Value, "MMM-yyyy"), Format(dtpfromdate.Value, "MMM-yyyy") & " TO " & Format(dtptodate.Value, "MMM-yyyy"), d_Mstore, d_store, D_Month)

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
            ElseIf e.KeyCode = Keys.F3 Then
                Dim search As New frmListSearch
                search.listbox = Chklist_Groupdesc
                search.Text = "Group Search"
                search.ShowDialog(Me)
            ElseIf e.KeyCode = Keys.F2 Then
                Dim search As New frmListSearch
                search.listbox = CheckedListBox1
                search.Text = "Sub Store Search"
                search.ShowDialog(Me)
            ElseIf e.KeyCode = Keys.F4 Then
                Dim search As New frmListSearch
                search.listbox = CheckedListBox2
                search.Text = "Main Store Search"
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

    Private Sub CheckedListBox2_KeyDown(sender As Object, e As KeyEventArgs)
        'If e.KeyCode = Keys.F2 Then
        '    Dim search As New frmListSearch
        '      search.listbox = CheckedListBox2
        '    search.Text = "Category Search"
        '    search.ShowDialog(Me)
        'End If
    End Sub

    Private Sub Chk_SelectAllGroup_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_SelectAllGroup.CheckedChanged
        Dim i As Integer = 0

        If (Chk_SelectAllGroup.Checked = True) Then
            For i = 0 To Chklist_Groupdesc.Items.Count - 1
                Chklist_Groupdesc.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To Chklist_Groupdesc.Items.Count - 1
                Chklist_Groupdesc.SetItemChecked(i, False)
            Next

        End If
        Chklist_Groupdesc_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox3.SelectedIndexChanged

    End Sub

    Private Sub Chklist_Groupdesc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Chklist_Groupdesc.SelectedIndexChanged

        Dim i, J As Integer
        Dim sqlstring, ssql, groupcode() As String
        ssql = ""
        'sqlstring = "SELECT  distinct (ISNULL(I.groupcode,'') )AS groupcode,ISNULL(g.groupdesc,'') AS groupdesc FROM INV_INVENTORYITEMMASTER AS I  inner join inventorygroupmaster g on i.groupcode=g.Groupcode "
        'sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' "

        ''For J = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        ''    If J = Chklist_Groupdesc.CheckedItems.Count - 1 Then
        ''        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "'"
        ''    Else
        ''        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "', "
        ''    End If
        ''Next

        'If CheckedListBox2.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & "  and I.category IN ("
        '    For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        '        groupcode = Split(Chklist_Groupdesc.CheckedItems(i), "-->")
        '        sqlstring = sqlstring & " '" & Trim(groupcode(0)) & "', "
        '    Next


        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If

        'If Chklist_Groupdesc.CheckedItems.Count > 0 Then
        '    sqlstring = sqlstring & ssql & " ORDER BY groupcode "
        '    gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
        '    If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
        '        Chklist_Groupdesc.Items.Clear()
        '        For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
        '            With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
        '                Chklist_Groupdesc.Items.Add(Trim(.Item("groupcode") & "-->" & .Item("groupdesc")))
        '            End With
        '        Next i
        '    End If
        'Else
        '    Chklist_Groupdesc.Items.Clear()

        'End If


        'Dim i, J As Integer
        'Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' "

        'For J = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        '    If J = Chklist_Groupdesc.CheckedItems.Count - 1 Then
        '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "' "
        '    Else
        '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "', "
        '    End If
        'Next


        If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "  and I.GROUPCODE IN ("
            For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                groupcode = Split(Chklist_Groupdesc.CheckedItems(i), "-->")
                sqlstring = sqlstring & " '" & Trim(groupcode(0)) & "', "
            Next


            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        If Chklist_Groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & " ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                CheckedListBox3.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        CheckedListBox3.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        Else
            CheckedListBox3.Items.Clear()

        End If

    End Sub

    Private Sub Chklist_Groupdesc_KeyDown(sender As Object, e As KeyEventArgs) Handles Chklist_Groupdesc.KeyDown
        If e.KeyCode = Keys.F3 Then
            Dim search As New frmListSearch
            search.listbox = Chklist_Groupdesc
            search.Text = "Group Search"
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

    Private Sub ChkSupplier_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSupplier.CheckedChanged
        Dim i As Integer = 0
        If (ChkSupplier.Checked = True) Then
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, False)
            Next

        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim i As Integer = 0
        If (CheckBox2.Checked = True) Then
            For i = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, False)
            Next

        End If

    End Sub
End Class