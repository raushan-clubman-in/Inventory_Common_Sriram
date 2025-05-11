Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class InvStockSummaryGroupCosting
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
    Private Sub FillGroupdetails()
        Dim i As Integer
        Dim sqlstring As String
        CheckedListBox2.Items.Clear()
        sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER  where CATEGORYCODE in (select distinct i.category from INV_INVENTORYITEMMASTER  I INNER JOIN STD_COSTINGDEL C ON C.itemcode=I.itemcode ) ORDER BY CATEGORYCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    CheckedListBox2.Items.Add(Trim(CStr(.Item("CATEGORYCODE"))))
                    End With
            Next
            End If
    End Sub




    Private Sub InvStockSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.DoubleBuffered = True
        'Resize_Form()
        'If UCase(gShortname) = "MLA" Then
        '    CBQTY.Visible = True
        'End If
        ' FillItemdetails()
        FillGroupdetails()
        If UCase(gShortname) = "BBSR" Or UCase(gShortname) = "CFC" Then
            CkExices.Visible = True
        Else
            CkExices.Visible = False
        End If
        If UCase(gShortname) = "HG" Or UCase(gShortname) = "BGC" Then
            CHK_SUM.Visible = True
        Else
            CHK_SUM.Visible = False
        End If
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
        If UCase(gShortname) = "MLRF" Or UCase(gShortname) = "DC" Then
            ChBZero.Visible = True
        Else
            ChBZero.Visible = False
        End If
        If UCase(gShortname) = "HGA" Then
            chksummary.Visible = False
            ChBZero.Visible = True
            CHKEXPORT.Visible = True

        End If
        If UCase(gShortname) = "TNCA" Then
            ChK_WITHOUTVALUE.Visible = True
        End If
        If gShortname = "MRC" Then
            CkExices.Visible = True
            CHK_EXCISE_SUMM.Visible = True
        End If

        If gShortname = "MGC" Then
            chk_overall.Visible = True
        Else
            chk_overall.Visible = False
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
        ChkCategory.Checked = False
        Chk_SelectAllGroup.Checked = False
        txt_mainstore.Text = ""
        txt_mainstorecode.Text = ""
        If UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/jan/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If

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
        ' gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
        gSQLString = "select DISTINCT ISNULL(I.KITCHENCODE,'') AS storecode,ISNULL(i.KITCHENDESC,'') AS storedesc from STD_KITCHENMASTER i INNER JOIN posmaster C ON C.poscode=I.POSDESC  "
        ' M_WhereCondition = " where freeze <> 'Y' "
        Dim vform As New ListOperattion1

        vform.Field = "KITCHENDESC,KITCHENCODE"
        vform.vFormatstring = "             STORE CODE                   |                   STORE DESCRIPTION                             "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_mainstorecode.Text = Trim(vform.keyfield & "")
            txt_mainstore.Text = Trim(vform.keyfield1 & "")
            Chklist_Groupdesc.Items.Clear()
            CheckedListBox3.Items.Clear()

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
        sqlstring = sqlstring & " WHERE  I.CATEGORY IN ("

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

    Private Sub ExicesReport_bbsr()
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME(), ExicesUOM As String
            Dim i As Integer
            Dim CL
            If gShortname = "MRC" Then
                CL = New CryExicesReportMRC
            Else
                CL = New CryExicesReport
            End If

            Dim rViewer As New Viewer
            ' gconnection.valuation()

            If txt_mainstorecode.Text <> "" Then

            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor


            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_InventoryItemMaster' AND  COLUMN_NAME = 'selectYN') Begin alter table INV_InventoryItemMaster add  selectYN varchar(1) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "SELECT EXCISEREPORTUOM FROM INV_LINKSETUP"
            gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
            If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
                ExicesUOM = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("EXCISEREPORTUOM"))
                If ExicesUOM = "" Then
                    MessageBox.Show("Exices Report UOM not given in setup ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Else

            End If

            sqlstring = "update INV_InventoryItemMaster set selectYN= 'N' "
            gconnection.dataOperation(6, sqlstring, "AddC")


            sqlstring = " update INV_InventoryItemMaster set selectYN= 'Y' "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " where ITEMCODE  IN ("
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


            sqlstring = "select distinct stockuom from INV_InventoryItemMaster where   selectYN='Y'  and stockuom+'" & ExicesUOM & "' not in ( select BASEUOM+transUOM from INVENTORY_TRANSCONVERSION where ISNULL(freeze,'')<>'Y') "
            gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
            If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
                Dim stockuom As String = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("stockuom"))

                If MsgBox("DO U Want to Make Conversion factor between " & ExicesUOM & " and " & stockuom & " ! ", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, gCompanyname) = MsgBoxResult.Ok Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim uomr As New FrmUOMRelation
                    uomr.baseuom = stockuom
                    uomr.transuom = ExicesUOM
                    uomr.ShowDialog()
                    Me.Cursor = Cursors.Default
                    Exit Sub

                Else
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If



            sqlstring = " exec iNV_EXICES  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = " select * from stocksummary "
            sqlstring = sqlstring & " order by itemname,DAYdATE "

            gconnection.getDataSet(sqlstring, "stocksummary")
            If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = CL
                rViewer.TableName = "Stocksummary"

                Dim textobj1 As TextObject
                textobj1 = CL.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName

                Dim textobj5 As TextObject
                textobj5 = CL.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = CL.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                Dim textobj2 As TextObject
                textobj2 = CL.ReportDefinition.ReportObjects("Text13")
                textobj2.Text = Trim(txt_mainstore.Text)
                Dim textobj22 As TextObject
                textobj22 = CL.ReportDefinition.ReportObjects("Text11")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = CL.ReportDefinition.ReportObjects("Text17")
                ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                    TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                    Dim textobj29 As TextObject
                    textobj29 = CL.ReportDefinition.ReportObjects("Text10")
                    textobj29.Text = "DATE :"

                Else
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                End If

                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ExicesReport_cfc()
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME(), ExicesUOM As String
            Dim i As Integer

            Dim CL As New CryExicesReportCFC
            Dim rViewer As New Viewer
            ' gconnection.valuation()

            If txt_mainstorecode.Text <> "" Then

            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor


            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_InventoryItemMaster' AND  COLUMN_NAME = 'selectYN') Begin alter table INV_InventoryItemMaster add  selectYN varchar(1) End"
            gconnection.dataOperation(6, sqlstring, "AddC")

            sqlstring = "SELECT EXCISEREPORTUOM FROM INV_LINKSETUP"
            gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
            If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
                ExicesUOM = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("EXCISEREPORTUOM"))
                If ExicesUOM = "" Then
                    MessageBox.Show("Exices Report UOM not given in setup ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Else

            End If

            sqlstring = "update INV_InventoryItemMaster set selectYN= 'N' "
            gconnection.dataOperation(6, sqlstring, "AddC")


            sqlstring = " update INV_InventoryItemMaster set selectYN= 'Y' "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " where ITEMCODE  IN ("
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


            sqlstring = "select distinct stockuom from INV_InventoryItemMaster where   selectYN='Y'  and stockuom+'" & ExicesUOM & "' not in ( select BASEUOM+transUOM from INVENTORY_TRANSCONVERSION where ISNULL(freeze,'')<>'Y') "
            gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
            If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
                Dim stockuom As String = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("stockuom"))

                If MsgBox("DO U Want to Make Conversion factor between " & ExicesUOM & " and " & stockuom & " ! ", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, gCompanyname) = MsgBoxResult.Ok Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim uomr As New FrmUOMRelation
                    uomr.baseuom = stockuom
                    uomr.transuom = ExicesUOM
                    uomr.ShowDialog()
                    Me.Cursor = Cursors.Default
                    Exit Sub

                Else
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If



            sqlstring = " exec iNV_EXICES  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = " select * from stocksummary "
            sqlstring = sqlstring & " order by itemname,DAYdATE "

            gconnection.getDataSet(sqlstring, "stocksummary")
            If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = CL
                rViewer.TableName = "Stocksummary"

                Dim textobj1 As TextObject
                textobj1 = CL.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName

                Dim textobj5 As TextObject
                textobj5 = CL.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = CL.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                Dim textobj2 As TextObject
                textobj2 = CL.ReportDefinition.ReportObjects("Text13")
                textobj2.Text = Trim(txt_mainstore.Text)
                Dim textobj22 As TextObject
                textobj22 = CL.ReportDefinition.ReportObjects("Text11")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = CL.ReportDefinition.ReportObjects("Text17")
                ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                    TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                    Dim textobj29 As TextObject
                    textobj29 = CL.ReportDefinition.ReportObjects("Text10")
                    textobj29.Text = "DATE :"

                Else
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                End If

                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ExicessummReport()
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME(), ExicesUOM As String
            Dim i As Integer
            Dim CL = New CryExicessummary
            Dim rViewer As New Viewer
            ' gconnection.valuation()
            If txt_mainstorecode.Text <> "" Then
            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'INV_InventoryItemMaster' AND  COLUMN_NAME = 'selectYN') Begin alter table INV_InventoryItemMaster add  selectYN varchar(1) End"
            gconnection.dataOperation(6, sqlstring, "AddC")
            sqlstring = "SELECT EXCISEREPORTUOM FROM INV_LINKSETUP"
            gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
            If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
                ExicesUOM = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("EXCISEREPORTUOM"))
                If ExicesUOM = "" Then
                    MessageBox.Show("Exices Report UOM not given in setup ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Else

            End If

            sqlstring = "update INV_InventoryItemMaster set selectYN= 'N' "
            gconnection.dataOperation(6, sqlstring, "AddC")


            sqlstring = " update INV_InventoryItemMaster set selectYN= 'Y' "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " where ITEMCODE  IN ("
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


            sqlstring = "select distinct stockuom from INV_InventoryItemMaster where   selectYN='Y'  and stockuom+'" & ExicesUOM & "' not in ( select BASEUOM+transUOM from INVENTORY_TRANSCONVERSION where ISNULL(freeze,'')<>'Y') "
            gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
            If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
                Dim stockuom As String = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("stockuom"))

                If MsgBox("DO U Want to Make Conversion factor between " & ExicesUOM & " and " & stockuom & " ! ", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, gCompanyname) = MsgBoxResult.Ok Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim uomr As New FrmUOMRelation
                    uomr.baseuom = stockuom
                    uomr.transuom = ExicesUOM
                    uomr.ShowDialog()
                    Me.Cursor = Cursors.Default
                    Exit Sub

                Else
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If



            sqlstring = " exec iNV_EXICES  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "select sum(opvalue)AS opvalue ,sum (receiveAmt) AS receiveAmt,sum(totamt)AS totamt,sum(issuevalue)AS issuevalue,sum(clvalue)AS clvalue,groupdesc,DAYdATE,groupcode from stocksummary group by groupdesc,DAYdATE,groupcode"
            sqlstring = sqlstring & " order by groupdesc,DAYdATE "

            gconnection.getDataSet(sqlstring, "stocksummary")
            If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = CL
                rViewer.TableName = "Stocksummary"

                Dim textobj1 As TextObject
                textobj1 = CL.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName

                Dim textobj5 As TextObject
                textobj5 = CL.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = CL.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                Dim textobj2 As TextObject
                textobj2 = CL.ReportDefinition.ReportObjects("Text13")
                textobj2.Text = Trim(txt_mainstore.Text)
                Dim textobj22 As TextObject
                textobj22 = CL.ReportDefinition.ReportObjects("Text11")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = CL.ReportDefinition.ReportObjects("Text17")
                ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                    TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                    Dim textobj29 As TextObject
                    textobj29 = CL.ReportDefinition.ReportObjects("Text10")
                    textobj29.Text = "DATE :"

                Else
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                End If

                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        If gShortname = "HGA" Then
            sqlstring = "exec  passinvntoryunmatchedentries"
            gconnection.ExcuteStoreProcedure(sqlstring)
        End If
        If CkExices.Checked = True And gShortname = "CFC" Then
            Call ExicesReport_cfc()
        ElseIf CkExices.Checked = True Then
            Call ExicesReport_bbsr()
        ElseIf CHK_EXCISE_SUMM.Checked = True Then
            Call ExicessummReport()
        ElseIf ChK_WITHOUTVALUE.Checked = True Then
            Call VIEWSTOCKSUMMARY_WITHOUTVALUE()
        ElseIf Chk_Ledger.Checked = True Then
            Call ViewStockLedger()
        Else
            VIEWSTOCKSUMMARY()
        End If


    End Sub
    Private Sub ViewStockLedger()
        Dim itemcode() As String
        Dim i As Integer
        Dim rViewer As New Viewer
        Dim r
         r = New CrystockledgerreportnEW4aLL
        Dim r1 As New CrystockledgerreportNew
        Dim sqlstring1 As String
        Dim bdate As String
        bdate = gconnection.getvalue("  SELECT Convert(varchar(11), bdate, 106) As bdate FROM Businessdate")
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub

        If txt_mainstorecode.Text <> "" Then

        Else
            MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ' Call MU()



        ' gconnection.valuation()
        Dim sql As String = " if exists(select * from sysobjects where name='tempclosingqty') begin DROP TABLE tempclosingqty end"
        gconnection.dataOperation(6, sql, "tempclosingqty")

        sql = "UPDATE CLOSINGQTY SET  RATE = isnull( (SELECT TOP 1 isnull(RATE,0) FROM CLOSINGQTY B WHERE  B.ttype IN ('RECEIEVE','OPENNING','GRN')  AND CLOSINGQTY.storecode=B.STORECODE AND CLOSINGQTY.itemcode=B.itemcode AND CLOSINGQTY.AUTOID>B.Autoid ORDER BY B.Autoid DESC    ) ,0) WHERE  CLOSINGQTY.TTYPE IN ('KOT') and CLOSINGQTY.storecode ='" + txt_mainstorecode.Text + "' and cast(trndate as date)>'" & bdate & "'  "
        gconnection.dataOperation(6, sql, "tempclosingqty")

        sql = "UPDATE CLOSINGQTY SET  closingvalue = closingstock*isnull(rate,0),openningvalue=isnull(rate,0)*openningstock  WHERE  CLOSINGQTY.TTYPE IN ('KOT') and CLOSINGQTY.storecode ='" + txt_mainstorecode.Text + "' and cast(trndate as date)>'" & bdate & "'  "
        gconnection.dataOperation(6, sql, "tempclosingqty")


        sql = "SELECT * FROM STOREMASTER WHERE STORECODE='" & txt_mainstorecode.Text & "' AND STORESTATUS='S' "
        gconnection.getDataSet(sql, "STOREMASTER")
        If (gdataset.Tables("STOREMASTER").Rows.Count > 0) Then

            sql = "UPDATE CLOSINGQTY SET  RATE = isnull((SELECT TOP 1 isnull(RATE,0) FROM CLOSINGQTY B WHERE  B.ttype IN ('RECEIEVE','OPENNING','GRN')  AND CLOSINGQTY.storecode=B.STORECODE AND CLOSINGQTY.itemcode=B.itemcode AND CLOSINGQTY.AUTOID>B.Autoid ORDER BY B.Autoid DESC    ),0)  WHERE  CLOSINGQTY.TTYPE  NOT IN ('RECEIEVE','OPENNING','GRN')  and CLOSINGQTY.storecode ='" + txt_mainstorecode.Text + "' and cast(trndate as date)>'" & bdate & "'  "
            gconnection.dataOperation(6, sql, "tempclosingqty")

            sql = "UPDATE CLOSINGQTY SET  closingvalue = closingstock*isnull(RATE,0),openningvalue=isnull(RATE,0)*openningstock  WHERE  CLOSINGQTY.TTYPE NOT IN  ('RECEIEVE','OPENNING','GRN')   and CLOSINGQTY.storecode ='" + txt_mainstorecode.Text + "' and cast(trndate as date)>'" & bdate & "'  "
            gconnection.dataOperation(6, sql, "tempclosingqty")
        Else

        End If

        'gconnection.valuation()
        '   Dim sqlstring As String = "SELECT Trnno,itemcode,UoM,storecode,Trndate,openningstock,openningvalue,qty,closingstock,batchno,TTYPE into tempclosingqty FROM closingqty where storecode='" + txt_mainstorecode.Text + "' "
        'Dim todate As Date
        'If gShortname = "MBC" Then
        '    Dim sqlst As String = "SelecT tOp 1 fYear  from inv_InventoryOpenningstock "
        '    gconnection.getDataSet(sqlst, "fYearS")
        '    If gdataset.Tables("fYearS").Rows.Count > 0 Then
        '        TODATE = gdataset.Tables("fYearS").Rows(0).Item("fYear")
        '    End If
        'End If


        If gShortname = "MBC" Then

            sqlstring = " SELECT Trnno,A.itemcode,B.ITEMNAME,B.GROUPCODE,UoM,A.storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,a.batchno,TTYPE,trns_seq,priority,RATE into tempclosingqty FROM  closingqty A INNER JOIN INV_INVENTORYITEMMASTER B ON A.itemcode=B.itemcode WHERE a.STORECODE='" + txt_mainstorecode.Text + "' And Trndate >='23 sep 2022'"
        Else
            sqlstring = " SELECT Trnno,A.itemcode,B.ITEMNAME,B.GROUPCODE,UoM,A.storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,a.batchno,TTYPE,trns_seq,priority,RATE into tempclosingqty FROM  closingqty A INNER JOIN INV_INVENTORYITEMMASTER B ON A.itemcode=B.itemcode WHERE a.STORECODE='" + txt_mainstorecode.Text + "'"

        End If


        If CheckedListBox3.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND A.ITEMCODE IN ("
            For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                itemcode = Split(CheckedListBox3.CheckedItems(i), "-->")
                sqlstring = sqlstring & "'" & itemcode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        Else
            MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        sqlstring = sqlstring & " and  CAST(CONVERT(VARCHAR(11),trndate,106) AS DATETIME) BETWEEN "
        sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & "   ORDER BY A.ITEMCODE,STORECODE,trndate,trns_seq,priority "


        gconnection.dataOperation(6, sqlstring, "stockledger")

        If gShortname = "MBC" Then
            Dim sqlng As String = " insert into tempclosingqty Select Trnno,A.itemcode,B.ITEMNAME,B.GROUPCODE,UoM,A.storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,a.batchno,TTYPE,trns_seq,priority,RATE  FROM  closingqty A INNER JOIN INV_INVENTORYITEMMASTER B On A.itemcode=B.itemcode WHERE a.STORECODE='" + txt_mainstorecode.Text + "' and ttype='openning'"
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlng = sqlng & " AND A.ITEMCODE IN ("
                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    itemcode = Split(CheckedListBox3.CheckedItems(i), "-->")
                    sqlng = sqlng & "'" & itemcode(0) & "', "
                Next
                sqlng = Mid(sqlng, 1, Len(sqlng) - 2)
                sqlng = sqlng & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            gconnection.dataOperation(6, sqlng, "stockledgr")

        End If


        sqlstring1 = " ALTER TABLE tempclosingqty ADD  opqty NUMERIC(15,3) ,opval NUMERIC(15,2) ,purqty NUMERIC(15,3), purval NUMERIC(15,2), issqty NUMERIC(15,3), "
        sqlstring1 = sqlstring1 & " issval NUMERIC(15,2) ,adjqty NUMERIC(15,3) ,adjval NUMERIC(15,2) ,damqty NUMERIC(15,3) ,damval NUMERIC(15,2) ,SALEQTY NUMERIC(15,3) ,SALEVAL NUMERIC(15,2),OPSTORELOCATIONNAME VARCHAR(50)"

        gconnection.dataOperation(6, sqlstring1, )


        '        update tempclosingqty set opqty=qty,opval=rate*qty where ttype='OPENNING'
        'update tempclosingqty set purqty=qty,purval=rate*qty where ttype IN ('GRN','RECEIEVE')
        'update tempclosingqty set issqty=(qty)*-1,issval=rate*(qty*-1) where ttype='ISSUE'
        'update tempclosingqty set adjqty=qty,adjval=rate*qty where ttype='ADJUSTMENT'
        'update tempclosingqty set damqty=(qty)*-1,damval=rate*(qty*-1) where ttype='DAMAGE'
        'update tempclosingqty set SALEQTY=qty*-1,SALEVAL=rate*(qty*-1) where ttype='KOT'
        sqlstring1 = "update tempclosingqty set opqty=qty,opval=rate*qty where ttype='OPENNING'"
        gconnection.dataOperation(6, sqlstring1, )
        ' sqlstring1 = "update tempclosingqty set purqty=qty,purval=rate*qty where ttype IN ('GRN','RECEIEVE') "
        sqlstring1 = "update tempclosingqty set purqty=tempclosingqty.qty,purval=V.RATE*tempclosingqty.qty  from INV_WEIGHTED_VIEW1 v where tempclosingqty.trnno=v.docdetails AND tempclosingqty.ITEMCODE=V.ITEMCODE AND ttype IN ('GRN','RECEIEVE','ISSUE GRN')"
        gconnection.dataOperation(6, sqlstring1, )
        sqlstring1 = "update tempclosingqty set issqty=(qty)*-1,issval=rate*(qty*-1) where ttype in('ISSUE','TRANSFER')"
        gconnection.dataOperation(6, sqlstring1, )
        sqlstring1 = "update tempclosingqty set adjqty=qty,adjval=rate*qty where ttype='ADJUSTMENT'"
        gconnection.dataOperation(6, sqlstring1, )
        sqlstring1 = "update tempclosingqty set adjqty=qty*-1,adjval=rate*(qty*-1) where ttype IN('CONSUME')"
        gconnection.dataOperation(6, sqlstring1, )
        sqlstring1 = "update tempclosingqty set damqty=(qty)*-1,damval=rate*(qty*-1) where ttype in('DAMAGE','PRN')"
        gconnection.dataOperation(6, sqlstring1, )
        'sqlstring1 = "update tempclosingqty set SALEQTY=qty*-1,SALEVAL=rate*(qty*-1) where ttype='KOT'"
        'gconnection.dataOperation(6, sqlstring1, )

        sqlstring = "SELECT top 1 isnull(production,'Y')as production  from std_mastersetup "
        gconnection.getDataSet(sqlstring, "std_mastersetup")
        Dim production As String
        production = Trim(gdataset.Tables("std_mastersetup").Rows(0).Item("production"))
        If production <> "Y" Then
            sqlstring1 = "update tempclosingqty set SALEQTY=total_sell.TOTQTY*-1,SALEVAL=rate*(total_sell.TOTQTY*-1) from total_sell where total_sell.itemcode=tempclosingqty.itemcode AND total_sell.KITCHENCODe = '" & txt_mainstore.Text & "'  AND  cast(total_sell.KOTDATE as date)   between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
            gconnection.dataOperation(6, sqlstring1, )
        Else
            sqlstring1 = "update tempclosingqty set SALEQTY=total_sell.TOTQTY*-1,SALEVAL=rate*(total_sell.TOTQTY*-1) from total_sell_Production where total_sell.itemcode=tempclosingqty.itemcode AND total_sell.KITCHENCODe = '" & txt_mainstore.Text & "'  AND  cast(total_sell.KOTDATE as date)   between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
            gconnection.dataOperation(6, sqlstring1, )
        End If

        
        sqlstring1 = "update tempclosingqty set OPSTORELOCATIONNAME= S.OPSTORELOCATIONNAME FROM STOCKISSUEDETAIL S WHERE TTYPE='ISSUE' AND TEMPCLOSINGQTY.TRNNO=S.DOCNO"
        gconnection.dataOperation(6, sqlstring1, )
        sqlstring1 = "update tempclosingqty set openningstock=OPQTY  where ttype='OPENNING'"
        gconnection.dataOperation(6, sqlstring1, )

        sqlstring = "SELECT * FROM STOREMASTER WHERE STORECODE='" & txt_mainstorecode.Text & "' AND STORESTATUS='S' "
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        If (gdataset.Tables("STOREMASTER").Rows.Count > 0) Then


            sqlstring1 = "update tempclosingqty set issqty=qty*-1,issval=rate*(qty*-1) where ttype='KOT'"
            gconnection.dataOperation(6, sqlstring1, )
            Dim textobj66 As TextObject
            textobj66 = r.ReportDefinition.ReportObjects("Text1")
            textobj66.Text = "SALES"
        Else
            Dim textobj66 As TextObject
            textobj66 = r.ReportDefinition.ReportObjects("Text1")
            textobj66.Text = "ISSUE"
        End If
        If Mid(UCase(gShortname), 1, 4) = "MLRF" Then
            sqlstring = " select DISTINCT * from tempclosingqty  ORDER BY ITEMCODE,STORECODE,trndate,trns_seq,priority "
        Else

            sqlstring = "select DISTINCT * from tempclosingqty   ORDER BY ITEMCODE,STORECODE,trndate,trns_seq,priority "
        End If
        gconnection.getDataSet(sqlstring, "tempclosingqty")
        If (gdataset.Tables("tempclosingqty").Rows.Count > 0) Then


            If UCase(gShortname) = "BRC" Then

                sqlstring1 = "ALTER TABLE tempclosingqty ADD  ReceiptQty  numeric(18,3),IssueQty  numeric(18,3)"
                gconnection.dataOperation(6, sqlstring1, )


                sqlstring1 = "update tempclosingqty set ReceiptQty=qty where qty>0"
                gconnection.dataOperation(6, sqlstring1, )
                sqlstring1 = "update tempclosingqty set IssueQty=qty*-1 where qty<0"
                gconnection.dataOperation(6, sqlstring1, )



                rViewer.ssql = sqlstring
                rViewer.Report = r1
                rViewer.TableName = "stockledger"

                Dim textobj1 As TextObject
                textobj1 = r1.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName



                Dim textobj5 As TextObject
                textobj5 = r1.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = r1.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                Dim textobj2 As TextObject
                textobj2 = r1.ReportDefinition.ReportObjects("Text13")
                textobj2.Text = Trim(txt_mainstore.Text)
                Dim textobj22 As TextObject
                textobj22 = r1.ReportDefinition.ReportObjects("Text11")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text17")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""


                rViewer.Show()
                Me.Cursor = Cursors.Default

            ElseIf UCase(gShortname) = "CFC" Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "stockledger"

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName

                Dim textobj5 As TextObject
                textobj5 = r.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1) + "," + UCase(Address2)
                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(gState) + "," + UCase(gPincode)
                Dim textobj35 As TextObject
                textobj35 = r.ReportDefinition.ReportObjects("Text35")
                textobj35.Text = UCase(gPhone1) + "," + UCase(gPhone2)
                Dim textobj36 As TextObject
                textobj36 = r.ReportDefinition.ReportObjects("Text36")
                textobj36.Text = "GSTIN NO : " & UCase(gGSTINNO)
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text13")
                textobj2.Text = Trim(txt_mainstore.Text)
                Dim textobj22 As TextObject
                textobj22 = r.ReportDefinition.ReportObjects("Text11")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""


                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else

                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "stockledger"

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
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""


                rViewer.Show()
                Me.Cursor = Cursors.Default

            End If

        Else

            MessageBox.Show("Records not found...", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

        End If
    End Sub

    Private Sub VIEWSTOCKSUMMARY()
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME() As String
            Dim i As Integer
            Dim R1 As New RPT_STOCKSUMMARYGRPWISE
            Dim r
            Dim D As New CrystocksummaryGroup2D
            Dim m As New CrystocksummaryGroupLIQ
            Dim CL
            Dim rViewer As New Viewer
            ' gconnection.valuation()
            If Mid(UCase(gShortname), 1, 4) = "MLRF" Then
                r = New CrystocksummaryGroup_MLRF
            ElseIf UCase(gShortname) = "BGC" Then
                r = New CrystocksummaryGroup_BGC
            ElseIf UCase(gShortname) = "CFC" Then
                r = New CrystocksummaryGroup_CFC
            ElseIf Mid(UCase(gShortname), 1, 3) = "RSP" Then
                r = New CrystocksummaryGroup_RSPM
            ElseIf Mid(UCase(gShortname), 1, 3) = "FMC" Then
                r = New CrystocksummaryGroup_FMC
            ElseIf Mid(UCase(gShortname), 1, 3) = "RCL" Then
                r = New CrystocksummaryGroup_RCL
            ElseIf Mid(UCase(gShortname), 1, 3) = "CPC" Then
                r = New CrystocksummaryGroup_CPC
            ElseIf Mid(UCase(gShortname), 1, 3) = "KGA" Then
                r = New CrystocksummaryGroup_KGA
            ElseIf Mid(UCase(gShortname), 1, 3) = "HGA" Then
                r = New CrystocksummaryGroup_HGA
            Else
                r = New CrystocksummaryGroup
            End If


            If txt_mainstorecode.Text <> "" Then

            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Dim bdate As String
            bdate = gconnection.getvalue("  SELECT Convert(varchar(11), bdate, 106) As bdate FROM Businessdate")

            '          'update ratelist set weightedrate=closingvalue/closingstock ,  lastweightedrate=  case when openningvalue=0 then     
            'batchrate    Else  openningvalue/openningstock      End 
            ' from ratelist r inner join CLOSINGQTY on r.grnno=CLOSINGQTY.trnno where
            '          trndate = r.grndate And CLOSINGQTY.storecode = r.storecode And CLOSINGQTY.itemcode = r.Itemcode


            sqlstring = "if exists(select * from sysobjects where name='TempRate') begin DROP TABLE TempRate end"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = " select * into TempRate from CLOSINGQTY"
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")


            sqlstring = " CREATE NONCLUSTERED INDEX [NonClusteredIndex-20210406-184557] ON [dbo].[TempRate](	[Autoid] ASC,[itemcode] ASC,[storecode] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] "
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")

            sqlstring = "UPDATE CLOSINGQTY SET  RATE = (SELECT TOP 1 RATE FROM TempRate B WHERE  B.ttype IN ('RECEIEVE','OPENNING','GRN')  AND CLOSINGQTY.storecode=B.STORECODE AND CLOSINGQTY.itemcode=B.itemcode AND CLOSINGQTY.AUTOID>B.Autoid ORDER BY B.Autoid DESC    )  WHERE  CLOSINGQTY.TTYPE IN ('KOT')  and closingqty.storecode='" + txt_mainstorecode.Text + "' and cast(trndate as date)>'" & bdate & "'"
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")


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
            'sqlstring = sqlstring & " AND ISNULL(O.void,'') <>'Y' "

            gconnection.dataOperation(6, sqlstring, "stocksummary")

            'sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"

            'gconnection.ExcuteStoreProcedure(sqlstring)



            sqlstring = "if exists(select * from sysobjects where name='tempstocktable') begin DROP TABLE tempstocktable end"
            gconnection.ExcuteStoreProcedure(sqlstring)

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
                ElseIf chk_overall.Checked = True Then
                    sqlstring = " exec CP_stocksummary_MGC  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
                Else

                    sqlstring = " exec CP_stocksummary_FOR_COSTING  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
                End If

            End If
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " update stocksummary set stocksummary.groupcode=i.groupcode, stocksummary.groupdesc=g.Groupdesc  from INV_InventoryItemMaster I  inner join stocksummary on i.ITEMCODE=stocksummary.ITEMCODE  inner join inventorygroupmaster g on i.groupcode=g.Groupcode"
            gconnection.dataOperation(6, sqlstring, "ratelist")

            If UCase(gShortname) = "TNCA" Or UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or UCase(gShortname) = "HSR" Or UCase(gShortname) = "CCL" Or UCase(gShortname) = "ALUMNI" Or UCase(gShortname) = "MGC" Or UCase(gShortname) = "MYLC" Or UCase(gShortname) = "GNC" Or Mid(UCase(gShortname), 1, 4) = "MLRF" Or Mid(UCase(gShortname), 1, 3) = "HGA" Or UCase(gShortname) = "VFNCC" Or UCase(gShortname) = "JSCA" Then
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/100) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                    'sqlstring = sqlstring & "Issqty=cast(Issqty as Int)+(((ABS(Issqty)-cast(Issqty as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                    ' sqlstring = sqlstring & "DMGQTY=cast(DMGQTY as Int)+(((ABS(DMGQTY)-cast(DMGQTY as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "closingqty=  case when closingqty>0  then cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then cast(ADJQTY as Int)+(((ABS(ADJQTY)-cast(ADJQTY as Int))/t.CONVVALUE)) else CAST(ADJQTY AS INT)-(((ABS(ADJQTY))+CAST(ADJQTY AS INT))/t.CONVVALUE) end "
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM and S.CATEGORYCODE NOT IN ('PRO') AND  U.storecode='" & txt_mainstorecode.Text & "'"

                Else
                    sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/100) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                    ' sqlstring = sqlstring & "Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "receiveqty=  case when receiveqty>0  then cast(receiveqty as Int)+(((ABS(receiveqty)-cast(receiveqty as Int))*t.CONVVALUE)/100) else CAST(receiveqty AS INT)-(((ABS(receiveqty))+CAST(receiveqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                    '- sqlstring = sqlstring & "DMGQTY=cast(DMGQTY as Int)+(((ABS(DMGQTY)-cast(DMGQTY as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "closingqty=  case when closingqty>0  then cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then cast(ADJQTY as Int)+(((ABS(ADJQTY)-cast(ADJQTY as Int))/t.CONVVALUE)) else CAST(ADJQTY AS INT)-(((ABS(ADJQTY))+CAST(ADJQTY AS INT))/t.CONVVALUE) end "
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM AND  U.storecode='" & txt_mainstorecode.Text & "'"

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
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                    gconnection.dataOperation(6, sqlstring, )
                    '   gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 and isnull(T.void,'N')<>'Y' AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN CAST(CONVERT(VARCHAR(11),'01/Apr/2016' ,106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )

                End If

            Else
                'If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                'gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from TEMPSTOCKISSUEDETAIL t where t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)", )

                'Else
                sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                gconnection.dataOperation(6, sqlstring, )
                ' gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 and isnull(T.void,'N')<>'Y' AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN CAST(CONVERT(VARCHAR(11),'" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "',106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )
                'End If

            End If

            gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )

            sqlstring = "update stocksummary set     issqty=issqty*-1,dmgqty=dmgqty*-1,saleqty=saleqty*-1 "
            gconnection.dataOperation(6, sqlstring, )


            'sqlstring = "update stocksummary set     clvalue=(isnull(OPVALUE,0)+isnull(receiveAmt,0)+isnull(adjval,0))-isnull(issuevalue,0)  "
            'gconnection.dataOperation(6, sqlstring, )

            'sqlstring = "update stocksummary set     CLrate=clvalue/closingqty  where closingqty<>0 "
            'gconnection.dataOperation(6, sqlstring, )

            If CHK_WITHOUT_ZERO.Checked = True Then
                sqlstring = " select * from stocksummary where  closingqty<>'0' "


            ElseIf chksummary.Checked = True Then

                sqlstring = " select * from stocksummary where (openningqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') "
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 4) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname"
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
            ElseIf ChBZero.Checked = True Then

                sqlstring = " select * from stocksummary "
                If UCase(gShortname) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname "
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If


            Else
                If UCase(gShortname) = "MLRF" Then
                    sqlstring = "select * from stocksummary"
                ElseIf UCase(gShortname) = "SKYYE" Then
                    sqlstring = " select * from stocksummary where  closingqty<>'0' "
                Else
                    sqlstring = " select * from stocksummary where ( issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0'or closingqty<>'0')"

                End If
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 4) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname"
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
            End If

            Me.Cursor = Cursors.WaitCursor
            If CHK_SUM.Checked = True Then
                '   sqlstring = "SELECT GROUPDESC,SUM(CLVALUE) AS CLVALUE FROM STOCKSUMMARY where GROUP BY GROUPDESC"
                If chksummary.Checked = True Then
                    sqlstring = " select GROUPDESC,SUM(CLVALUE) AS CLVALUE from stocksummary where (openningqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') GROUP BY GROUPDESC "
                Else
                    sqlstring = " select GROUPDESC,SUM(CLVALUE) AS CLVALUE from stocksummary where ( issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0')  GROUP BY GROUPDESC "
                End If


                gconnection.getDataSet(sqlstring, "stocksummary")
                If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = R1
                    rViewer.TableName = "Stocksummary"
                    'Dim picture1 As PictureObject
                    'picture1 = r.ReportDefinition.ReportObjects("picture1")
                    'If (gShortname = "KOLKATA") Then
                    '    picture1.ObjectFormat.EnableSuppress = False
                    'Else
                    '    picture1.ObjectFormat.EnableSuppress = True

                    'End If
                    Dim textobj1 As TextObject
                    textobj1 = R1.ReportDefinition.ReportObjects("Text1")
                    textobj1.Text = MyCompanyName

                    Dim textobj5 As TextObject
                    textobj5 = R1.ReportDefinition.ReportObjects("Text2")
                    textobj5.Text = UCase(Address1)
                    Dim textobj6 As TextObject
                    textobj6 = R1.ReportDefinition.ReportObjects("Text3")
                    textobj6.Text = UCase(Address2)

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                    Exit Sub


                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                Exit Sub
            End If
            If Mid(UCase(gShortname), 1, 4) = "MLRF" Then
                CL = New CrystocksummaryCL_MLRF
            ElseIf UCase(gShortname) = "BGC" Then
                CL = New CrystocksummaryCL_BGC
            ElseIf UCase(gShortname) = "MLA" Then
                CL = New CrystocksummaryCL_MLA
            ElseIf UCase(gShortname) = "CFC" Then
                CL = New CrystocksummaryCL_CFC
            Else
                CL = New CrystocksummaryCL
            End If
            If ClosingOnly.Checked = True Then
                gconnection.getDataSet(sqlstring, "stocksummary")
                If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = CL
                    rViewer.TableName = "Stocksummary"
                    'Dim picture1 As PictureObject
                    'picture1 = r.ReportDefinition.ReportObjects("picture1")
                    'If (gShortname = "KOLKATA") Then
                    '    picture1.ObjectFormat.EnableSuppress = False
                    'Else
                    '    picture1.ObjectFormat.EnableSuppress = True

                    'End If
                    If UCase(gShortname) = "CFC" Then
                        Dim textobj1 As TextObject
                        textobj1 = CL.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = CL.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1) + "," + UCase(Address2)
                        Dim textobj6 As TextObject
                        textobj6 = CL.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gState) + "," + UCase(gPincode)
                        Dim textobj4 As TextObject
                        textobj4 = CL.ReportDefinition.ReportObjects("Text4")
                        textobj4.Text = UCase(gPhone1) + "," + UCase(gPhone2)
                        Dim textobj50 As TextObject
                        textobj50 = CL.ReportDefinition.ReportObjects("Text50")
                        textobj50.Text = "GSTIN NO : " & UCase(gGSTINNO)

                        Dim textobj2 As TextObject
                        textobj2 = CL.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = CL.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = CL.ReportDefinition.ReportObjects("Text17")
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = CL.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If
                        'If UCase(gShortname) = "MLRF" Then
                        '    Dim TXTOBJ32 As TextObject
                        '    TXTOBJ32 = CL.ReportDefinition.ReportObjects("Text32")
                        '    TXTOBJ32.Text = "                          Prepared By:                                                                                               Approved By:            "
                        'End If
                        'If UCase(gShortname) = "TMA" Then
                        '    Dim TXTOBJ32 As TextObject
                        '    TXTOBJ32 = CL.ReportDefinition.ReportObjects("Text3")
                        '    TXTOBJ32.Text = "            Store Keeper:                                                                                               Manager:            "
                        'End If
                    Else
                        Dim textobj1 As TextObject
                        textobj1 = CL.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = CL.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1)
                        Dim textobj6 As TextObject
                        textobj6 = CL.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(Address2)
                        Dim textobj2 As TextObject
                        textobj2 = CL.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = CL.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = CL.ReportDefinition.ReportObjects("Text17")
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = CL.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If
                        If UCase(gShortname) = "MLRF" Then
                            Dim TXTOBJ32 As TextObject
                            TXTOBJ32 = CL.ReportDefinition.ReportObjects("Text32")
                            TXTOBJ32.Text = "                          Prepared By:                                                                                               Approved By:            "
                        End If
                        If UCase(gShortname) = "TMA" Then
                            Dim TXTOBJ32 As TextObject
                            TXTOBJ32 = CL.ReportDefinition.ReportObjects("Text3")
                            TXTOBJ32.Text = "            Store Keeper:                                                                                               Manager:            "
                        End If
                    End If


                    rViewer.Show()
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If

            Else
                gconnection.getDataSet(sqlstring, "stocksummary")
                If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                    If (txt_mainstorecode.Text = "PBB" Or txt_mainstorecode.Text = "TER" Or txt_mainstorecode.Text = "SNB" Or txt_mainstorecode.Text = "MNS" Or txt_mainstorecode.Text = "BAR" Or txt_mainstorecode.Text = "SPBAR" Or txt_mainstorecode.Text = "BLS") And (UCase(gShortname) = "HSR" Or UCase(gShortname) = "CCL") Then
                        rViewer.ssql = sqlstring
                        rViewer.Report = m
                        rViewer.TableName = "Stocksummary"
                        'Dim picture1 As PictureObject
                        'picture1 = r.ReportDefinition.ReportObjects("picture1")
                        'If (gShortname = "KOLKATA") Then
                        '    picture1.ObjectFormat.EnableSuppress = False
                        'Else
                        '    picture1.ObjectFormat.EnableSuppress = True

                        'End If
                        Dim textobj1 As TextObject
                        textobj1 = m.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = m.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1)
                        Dim textobj6 As TextObject
                        textobj6 = m.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(Address2)
                        Dim textobj2 As TextObject
                        textobj2 = m.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = m.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = m.ReportDefinition.ReportObjects("Text17")
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = m.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If

                        rViewer.Show()
                        Me.Cursor = Cursors.Default
                    ElseIf Mid(UCase(Trim(gCompanyname)), 1, 3) = "ALU" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "TNC" Then

                        rViewer.ssql = sqlstring
                        rViewer.Report = D
                        rViewer.TableName = "Stocksummary"
                        'Dim picture1 As PictureObject
                        'picture1 = r.ReportDefinition.ReportObjects("picture1")
                        'If (gShortname = "KOLKATA") Then
                        '    picture1.ObjectFormat.EnableSuppress = False
                        'Else
                        '    picture1.ObjectFormat.EnableSuppress = True

                        'End If
                        Dim textobj1 As TextObject
                        textobj1 = D.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = D.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1)
                        Dim textobj6 As TextObject
                        textobj6 = D.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(Address2)
                        Dim textobj2 As TextObject
                        textobj2 = D.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = D.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = D.ReportDefinition.ReportObjects("Text17")
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = D.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If

                        rViewer.Show()
                        Me.Cursor = Cursors.Default
                    Else

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
                        If UCase(gShortname) = "CFC" Then
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text12")
                            textobj1.Text = MyCompanyName

                            Dim textobj5 As TextObject
                            textobj5 = r.ReportDefinition.ReportObjects("Text15")
                            textobj5.Text = UCase(Address1) + "," + UCase(Address2)
                            Dim textobj6 As TextObject
                            textobj6 = r.ReportDefinition.ReportObjects("Text16")
                            textobj6.Text = UCase(gState) + "," + UCase(gPincode)
                            Dim textobj33 As TextObject
                            textobj33 = r.ReportDefinition.ReportObjects("Text33")
                            textobj33.Text = UCase(gPhone1) + "," + UCase(gPhone2)
                            Dim textobj34 As TextObject
                            textobj34 = r.ReportDefinition.ReportObjects("Text34")
                            textobj33.Text = "GSTIN NO : " & UCase(gGSTINNO)
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

                            'If UCase(gShortname) = "MLRF" Then
                            '    Dim TXTOBJ32 As TextObject
                            '    TXTOBJ32 = r.ReportDefinition.ReportObjects("Text32")
                            '    TXTOBJ32.Text = "                                       Prepared By:                                                                                                                                                                                                                            Approved By:            "
                            'End If
                            'If UCase(gShortname) = "TMA" Then
                            '    Dim TXTOBJ32 As TextObject
                            '    TXTOBJ32 = r.ReportDefinition.ReportObjects("Text32")
                            '    TXTOBJ32.Text = " Store Keeper:                                                                                                                                                                                                   Manager:"
                            'End If

                        Else
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

                            If UCase(gShortname) = "MLRF" Then
                                Dim TXTOBJ32 As TextObject
                                TXTOBJ32 = r.ReportDefinition.ReportObjects("Text32")
                                TXTOBJ32.Text = "                                       Prepared By:                                                                                                                                                                                                                            Approved By:            "
                            End If
                            If UCase(gShortname) = "TMA" Then
                                Dim TXTOBJ32 As TextObject
                                TXTOBJ32 = r.ReportDefinition.ReportObjects("Text32")
                                TXTOBJ32.Text = " Store Keeper:                                                                                                                                                                                                   Manager:"
                            End If

                        End If

                        rViewer.Show()
                        Me.Cursor = Cursors.Default

                    End If

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
            End If





        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub VIEWSTOCKSUMMARY_WITHOUTVALUE()
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New CrystocksummaryGroup_WOVALUE
            Dim rViewer As New Viewer
            If txt_mainstorecode.Text <> "" Then
            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim bdate As String
            bdate = gconnection.getvalue("  SELECT Convert(varchar(11), bdate, 106) As bdate FROM Businessdate")

            sqlstring = "if exists(select * from sysobjects where name='TempRate') begin DROP TABLE TempRate end"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " select * into TempRate from CLOSINGQTY"
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")
            sqlstring = "UPDATE CLOSINGQTY SET  RATE = (SELECT TOP 1 RATE FROM TempRate B WHERE  B.ttype IN ('RECEIEVE','OPENNING','GRN')  AND CLOSINGQTY.storecode=B.STORECODE AND CLOSINGQTY.itemcode=B.itemcode AND CLOSINGQTY.AUTOID>B.Autoid ORDER BY B.Autoid DESC    )  WHERE  CLOSINGQTY.TTYPE IN ('KOT')  and closingqty.storecode='" + txt_mainstorecode.Text + "' and cast(trndate as date)>'" & bdate & "' "
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")
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
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "','" + Format(DTPaSondATE.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
            Else
                sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
            End If
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " update stocksummary set stocksummary.groupcode=i.groupcode, stocksummary.groupdesc=g.Groupdesc  from INV_InventoryItemMaster I  inner join stocksummary on i.ITEMCODE=stocksummary.ITEMCODE  inner join inventorygroupmaster g on i.groupcode=g.Groupcode"
            gconnection.dataOperation(6, sqlstring, "ratelist")
            If UCase(gShortname) = "TNCA" Or UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or UCase(gShortname) = "HSR" Or UCase(gShortname) = "CCL" Or UCase(gShortname) = "ALUMNI" Or UCase(gShortname) = "MGC" Or UCase(gShortname) = "MYLC" Or UCase(gShortname) = "GNC" Or Mid(UCase(gShortname), 1, 4) = "MLRF" Or Mid(UCase(gShortname), 1, 3) = "HGA" Then
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/100) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                    'sqlstring = sqlstring & "Issqty=cast(Issqty as Int)+(((ABS(Issqty)-cast(Issqty as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                    ' sqlstring = sqlstring & "DMGQTY=cast(DMGQTY as Int)+(((ABS(DMGQTY)-cast(DMGQTY as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "closingqty=  case when closingqty>0  then cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then cast(ADJQTY as Int)+(((ABS(ADJQTY)-cast(ADJQTY as Int))/t.CONVVALUE)) else CAST(ADJQTY AS INT)-(((ABS(ADJQTY))+CAST(ADJQTY AS INT))/t.CONVVALUE) end "
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM and S.CATEGORYCODE NOT IN ('PRO') AND  U.storecode='" & txt_mainstorecode.Text & "'"

                Else
                    sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/100) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                    sqlstring = sqlstring & "receiveqty=  case when receiveqty>0  then cast(receiveqty as Int)+(((ABS(receiveqty)-cast(receiveqty as Int))*t.CONVVALUE)/100) else CAST(receiveqty AS INT)-(((ABS(receiveqty))+CAST(receiveqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "closingqty=  case when closingqty>0  then cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then cast(ADJQTY as Int)+(((ABS(ADJQTY)-cast(ADJQTY as Int))/t.CONVVALUE)) else CAST(ADJQTY AS INT)-(((ABS(ADJQTY))+CAST(ADJQTY AS INT))/t.CONVVALUE) end "
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM AND  U.storecode='" & txt_mainstorecode.Text & "'"
                End If
                gconnection.dataOperation(6, sqlstring, )
            End If
            sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
            gconnection.dataOperation(6, sqlstring, )
            gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )
            sqlstring = "update stocksummary set     issqty=issqty*-1,dmgqty=dmgqty*-1,saleqty=saleqty*-1 "
            gconnection.dataOperation(6, sqlstring, )
            If ChK_WITHOUTVALUE.Checked = True Then
                sqlstring = " select * from stocksummary where (openningqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') "
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 4) = "MLRF" Then
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
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                rViewer.Show()
                Me.Cursor = Cursors.Default
            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default
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
            'sqlstring = sqlstring & " AND ISNULL(O.void,'') <>'Y' "
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"

            gconnection.ExcuteStoreProcedure(sqlstring)
            If UCase(gShortname) = "HGA" Then
                sqlstring = "select ITEMCODE,ITEMNAME ,UOM,isnull(OPSTK,0) as opstk,isnull(opweightedrate,0) AS OPRATE,isnull(opvalue,0) AS OPVALUE,isnull(abs(issqty),0) AS ISSUE_QTY,isnull(dmgqty,0) AS DMG_QTY,isnull(adjqty,0) AS ADJ_QTY,isnull(abs(saleqty),0) AS SALE_QTY,isnull(receiveqty,0) AS REC_QTY,isnull(closingqty,0) AS CLOSING_QTY,isnull(clweightedrate,0) AS CLOSING_RATE,isnull(clvalue,0) AS CLOSING_VALUE from stocksummary WHERE (closingqty<>'0')  order by itemcode"
            Else
                sqlstring = "select ITEMCODE,ITEMNAME ,UOM,isnull(OPSTK,0) as opstk,isnull(opweightedrate,0) AS OPRATE,isnull(opvalue,0) AS OPVALUE,isnull(abs(issqty),0) AS ISSUE_QTY,isnull(dmgqty,0) AS DMG_QTY,isnull(adjqty,0) AS ADJ_QTY,isnull(abs(saleqty),0) AS SALE_QTY,isnull(receiveqty,0) AS REC_QTY,isnull(closingqty,0) AS CLOSING_QTY,isnull(clweightedrate,0) AS CLOSING_RATE,isnull(clvalue,0) AS CLOSING_VALUE from stocksummary where (issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') order by itemcode"
            End If

            'sqlstring = " select ITEMCODE,ITEMNAME ,UOM,isnull(OPSTK,0) as opstk,isnull(opweightedrate,0) AS OPRATE,isnull(opvalue,0) AS OPVALUE,isnull(abs(issqty),0) AS ISSUE_QTY,isnull(dmgqty,0) AS DMG_QTY,isnull(adjqty,0) AS ADJ_QTY,isnull(abs(saleqty),0) AS SALE_QTY,isnull(receiveqty,0) AS REC_QTY,isnull(closingqty,0) AS CLOSING_QTY,isnull(clweightedrate,0) AS CLOSING_RATE,isnull(clvalue,0) AS CLOSING_VALUE from stocksummary where (issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') order by itemcode"
            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "stocksummary")
            If gdataset.Tables("stocksummary").Rows.Count > 0 Then

                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "StockSummary " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

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
        'sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        'sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' "

        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I  inner join  closingqty o on o.itemcode=i.itemcode inner join STD_COSTINGDEL f on f.itemcode=o.itemcode and o.storecode='" & txt_mainstorecode.Text & "'"
        sqlstring = sqlstring & " WHERE isnull(I.VOID,'') <> 'Y' "

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

    Private Sub CkExices_CheckedChanged(sender As Object, e As EventArgs) Handles CkExices.CheckedChanged

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles ChK_WITHOUTVALUE.CheckedChanged

    End Sub

    Private Sub CheckedListBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CheckedListBox2.KeyPress
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT  distinct (ISNULL(I.groupcode,'') )AS groupcode,ISNULL(g.groupdesc,'') AS groupdesc FROM INV_INVENTORYITEMMASTER AS I  inner join inventorygroupmaster g on i.groupcode=g.Groupcode "
        sqlstring = sqlstring & " WHERE  I.CATEGORY IN ("

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

    Private Sub Chklist_Groupdesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Chklist_Groupdesc.KeyPress
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

End Class