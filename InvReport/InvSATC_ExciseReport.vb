Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class InvSATC_ExciseReport
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
        Chklist_Groupdesc.Items.Clear()
        sqlstring = "SELECT  distinct (ISNULL(I.subGroupcode,'') )AS subGroupcode,ISNULL(g.Subgroupdesc,'') AS Subgroupdesc  FROM INV_INVENTORYITEMMASTER AS I  inner join InventorySubGroupMaster g on i.subGroupcode=g.Subgroupcode WHERE G.Groupcode='ALB' AND isnull(Freeze,'') <> 'Y' ORDER BY Subgroupcode "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count > 0 Then
            Chklist_Groupdesc.Items.Clear()
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    Chklist_Groupdesc.Items.Add(Trim(.Item("subGroupcode") & "-->" & .Item("Subgroupdesc")))
                End With
            Next i
        End If
    End Sub




    Private Sub InvStockSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' FillItemdetails()
        FillGroupdetails()

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
        GmoduleName = "Excise Report"
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
        Chk_SelectAllGroup.Checked = False
        txt_mainstore.Text = ""
        txt_mainstorecode.Text = ""
        dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        For i = 0 To CheckedListBox3.Items.Count - 1
            CheckedListBox3.SetItemChecked(i, False)
        Next
        For i = 0 To CheckedListBox2.Items.Count - 1
            CheckedListBox2.SetItemChecked(i, False)
        Next
        For i = 0 To Chklist_Groupdesc.Items.Count - 1
            Chklist_Groupdesc.SetItemChecked(i, False)
        Next
        Chklist_Groupdesc.Items.Clear()
        CheckedListBox3.Items.Clear()
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

    Private Sub CheckedListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT  distinct (ISNULL(I.groupcode,'') )AS groupcode,ISNULL(g.groupdesc,'') AS groupdesc FROM INV_INVENTORYITEMMASTER AS I  inner join inventorygroupmaster g on i.groupcode=g.Groupcode "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' and I.CATEGORY IN ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "'"
            Else
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
            End If
        Next
        If CheckedListBox2.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY groupcode "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                Chklist_Groupdesc.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        Chklist_Groupdesc.Items.Add(Trim(.Item("groupcode") & "-->" & .Item("groupdesc")))
                    End With
                Next i
            End If
        Else
            Chklist_Groupdesc.Items.Clear()

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
        Dim sqlstring, SQL1, ITEMNAME() As String
        Dim toMonth, FromMonth, addr As String

        Dim i As Integer

        Dim rViewer As New Viewer

        Me.Cursor = Cursors.WaitCursor


        sqlstring = " delete from consolidatestocksummary"
        gconnection.dataOperation(6, sqlstring, "stocksummary")
        sqlstring = " insert into consolidatestocksummary(itemcode,ITEMNAME) "
        sqlstring = sqlstring & " select I.itemcode,I.ITEMNAME "
        sqlstring = sqlstring & " from  INV_InventoryItemMaster I  where ISNULL(I.void,'') <>'Y' "
        If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND I.subgroupcode IN ("
            For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                ITEMNAME = Split(Chklist_Groupdesc.CheckedItems(i), "-->")
                sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        Else
            MessageBox.Show("Select the Group(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        gconnection.dataOperation(6, sqlstring, "stocksummary")


        Dim FINYEARSTRT As Date
        If CDate(gFinancialyearStart).Year <= 2015 Then
            FINYEARSTRT = CDate("01/JAN/2016")
        Else
            FINYEARSTRT = CDate(gFinancialyearStart)

        End If

        sqlstring = " exec Cp_KBA_eXISE  '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "'"
        gconnection.ExcuteStoreProcedure(sqlstring)

        SQL1 = "UPDATE Inv_ExiseRpt SET priority=0"
        gconnection.ExcuteStoreProcedure(SQL1)
        SQL1 = "UPDATE Inv_ExiseRpt SET priority=1 WHERE groupdesc='TOTAL'"
        gconnection.ExcuteStoreProcedure(SQL1)


        sqlstring = " select * from Inv_ExiseRpt order by PRIORITY ,groupdesc"
        Me.Cursor = Cursors.WaitCursor



        If gShortname = "SATC" Then

            Dim r As New Crys_ExciseReport_SATC

            gconnection.getDataSet(sqlstring, "Inv_ExiseRpt")
            If gdataset.Tables("Inv_ExiseRpt").Rows.Count > 1 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "Inv_ExiseRpt"

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                addr = ""
                Dim textobj3 As TextObject
                textobj3 = r.ReportDefinition.ReportObjects("Text15")
                If Address1 <> "" Then
                    addr = addr & Address1
                End If

                If Address2 <> "" Then
                    addr = addr & ", " & Address2
                End If

                If gCity <> "" Then
                    addr = addr & ", " & gCity
                End If

                If gPincode <> "" Then
                    addr = addr & " - " & gPincode
                End If

                textobj3.Text = addr

                Dim textobj13 As TextObject
                textobj13 = r.ReportDefinition.ReportObjects("Text1")
                textobj13.Text = gPhone1

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text11")
                textobj2.Text = gPhone2

                Dim textobj4 As TextObject
                textobj4 = r.ReportDefinition.ReportObjects("Text13")
                textobj4.Text = gFax

                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text14")
                textobj6.Text = gEMail
                rViewer.Show()
                Me.Cursor = Cursors.Default
            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                Me.Cursor = Cursors.Default
            End If


        Else
            Dim r As New Crys_KBA_ExciseReport

            gconnection.getDataSet(sqlstring, "Inv_ExiseRpt")
            If gdataset.Tables("Inv_ExiseRpt").Rows.Count > 1 Then

                FromMonth = Mid(gconnection.getMonthName(Format(dtpfromdate.Value, "MM")), 1, 3)
                toMonth = Mid(gconnection.getMonthName(Format(dtptodate.Value, "MM")), 1, 3)
                If FromMonth = toMonth Then
                    FromMonth = FromMonth + " - " + Format(dtpfromdate.Value, "yyyy")
                Else
                    FromMonth = FromMonth + "  to  " + toMonth + "- " + Format(dtpfromdate.Value, "yyyy")
                End If
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "Inv_ExiseRpt"

                'Dim dt As New DataTable
                'Dim ds As New DataSet
                'dt = gconnection.GetValues(sqlstring)
                'dt.TableName = "stocksummary"
                'ds.Tables.Add(dt)

                'dt = gconnection.GetValues("SELECT PAYMENTMODE,SUM(AMOUNT) AS AMOUNT, SUM(TXAMT) AS TXAMT,SUM(STXAMT) AS STXAMT, SUM(TOTAMT) AS TOTAMT  FROM STKSUMMARY WHERE ISNULL(ISSQTY,0)>0 GROUP BY PAYMENTMODE")
                'dt.TableName = "STKSUMMARY"
                'ds.Tables.Add(dt)

                'dt = gconnection.GetValues("select * from INV_STKSALEDET")
                'dt.TableName = "INV_STKSALEDET"
                'ds.Tables.Add(dt)


                'rViewer.ssql = sqlstring
                'rViewer.Report = r
                'rViewer.TableName = "Stocksummary"

                SQL1 = "select sales from Inv_ExiseRpt where  groupdesc='TOTAL'"
                gconnection.getDataSet(SQL1, "Inv_ExiseRptTOTAL")
                If (gdataset.Tables("Inv_ExiseRptTOTAL").Rows.Count > 0) Then
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text19")
                    textobj1.Text = Format(gdataset.Tables("Inv_ExiseRptTOTAL").Rows(0).Item("sales"), "0.00")
                End If

                SQL1 = "select sales from Inv_ExiseRpt where  groupdesc='Beer'"
                gconnection.getDataSet(SQL1, "Inv_ExiseRptBeer")
                If (gdataset.Tables("Inv_ExiseRptBeer").Rows.Count > 0) Then
                    Dim textobj5 As TextObject
                    textobj5 = r.ReportDefinition.ReportObjects("Text20")
                    textobj5.Text = Format(gdataset.Tables("Inv_ExiseRptBeer").Rows(0).Item("sales"), "0.00")

                End If


                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text21")
                textobj6.Text = UCase(FromMonth)
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text22")
                textobj2.Text = Trim(gCompanyname)
                'Dim textobj22 As TextObject
                'textobj22 = r.ReportDefinition.ReportObjects("Text11")
                'textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                'Dim TXTOBJ3 As TextObject
                'TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                'TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

                'rViewer.GetDetails1(ds, r)

                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If

        End If


        Try




            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub ButExport_Click(sender As Object, e As EventArgs) Handles ButExport.Click
        Try
            Dim sqlstring, ITEMNAME() As String
            Dim i As Integer
            Dim r As New Crys_KBA_ExciseReport
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor

            sqlstring = " delete from consolidatestocksummary"
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            sqlstring = " insert into consolidatestocksummary(itemcode,ITEMNAME) "
            sqlstring = sqlstring & " select I.itemcode,I.ITEMNAME "
            sqlstring = sqlstring & " from  INV_InventoryItemMaster I  where ISNULL(I.void,'') <>'Y' "
            If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND I.groupcode IN ("
                For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                    ITEMNAME = Split(Chklist_Groupdesc.CheckedItems(i), "-->")
                    sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Group(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            gconnection.dataOperation(6, sqlstring, "stocksummary")


            Dim FINYEARSTRT As Date
            If CDate(gFinancialyearStart).Year <= 2015 Then
                FINYEARSTRT = CDate("01/JAN/2016")
            Else
                FINYEARSTRT = CDate(gFinancialyearStart)

            End If

            sqlstring = " exec Cp_KBA_eXISE  '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "'"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " select * from Inv_ExiseRpt "
            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "Inv_ExiseRpt")
            If gdataset.Tables("Inv_ExiseRpt").Rows.Count > 0 Then

                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "Inv_ExiseRpt"

                'Dim dt As New DataTable
                'Dim ds As New DataSet
                'dt = gconnection.GetValues(sqlstring)
                'dt.TableName = "stocksummary"
                'ds.Tables.Add(dt)

                'dt = gconnection.GetValues("SELECT PAYMENTMODE,SUM(AMOUNT) AS AMOUNT, SUM(TXAMT) AS TXAMT,SUM(STXAMT) AS STXAMT, SUM(TOTAMT) AS TOTAMT  FROM STKSUMMARY WHERE ISNULL(ISSQTY,0)>0 GROUP BY PAYMENTMODE")
                'dt.TableName = "STKSUMMARY"
                'ds.Tables.Add(dt)

                'dt = gconnection.GetValues("select * from INV_STKSALEDET")
                'dt.TableName = "INV_STKSALEDET"
                'ds.Tables.Add(dt)


                'rViewer.ssql = sqlstring
                'rViewer.Report = r
                'rViewer.TableName = "Stocksummary"

                'Dim textobj1 As TextObject
                'textobj1 = r.ReportDefinition.ReportObjects("Text12")
                'textobj1.Text = MyCompanyName

                'Dim textobj5 As TextObject
                'textobj5 = r.ReportDefinition.ReportObjects("Text15")
                'textobj5.Text = UCase(Address1)
                'Dim textobj6 As TextObject
                'textobj6 = r.ReportDefinition.ReportObjects("Text16")
                'textobj6.Text = UCase(Address2)
                ''Dim textobj2 As TextObject
                ''textobj2 = r.ReportDefinition.ReportObjects("Text13")
                ''textobj2.Text = Trim(txt_mainstore.Text)
                'Dim textobj22 As TextObject
                'textobj22 = r.ReportDefinition.ReportObjects("Text11")
                'textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                'Dim TXTOBJ3 As TextObject
                'TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                'TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

                'rViewer.GetDetails1(ds, r)

                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default

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
                search.Text = "Category Search"
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
            sqlstring = sqlstring & "  and I.subGROUPCODE IN ("
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
            search.Text = "Sub Group Search"
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

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class