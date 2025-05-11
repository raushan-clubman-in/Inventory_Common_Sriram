Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmStockLedger
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Public pagesize As Integer

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
        sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER  where CATEGORYCODE in (select CATEGORYCODE from INV_INVENTORYITEMMASTER) ORDER BY CATEGORYCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    CheckedListBox2.Items.Add(Trim(CStr(.Item("CATEGORYCODE"))))
                End With
            Next
        End If
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        ChkItemCode.Checked = False
        ChkCategory.Checked = False
        txt_mainstore.Text = ""
        txt_mainstorecode.Text = ""
    End Sub

    Private Sub FrmStockLedger_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub FrmStockLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillItemdetails()
        FillGroupdetails()
        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
            dtpfromdate.Value = Format(CDate("01/Jan/2016"), "dd/MMM/yyyy")
        ElseIf UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/01/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        ' dtpfromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
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
        GmoduleName = "Stock Ledger"
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
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' and I.CATEGORY IN ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
            End If
        Next
        If CheckedListBox2.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                CheckedListBox3.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
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
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' and I.CATEGORY IN ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
            End If
        Next
        If CheckedListBox2.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
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

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()

    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Dim itemcode() As String
        Dim i As Integer
        Dim rViewer As New Viewer

        Dim r
        If Mid(UCase(gShortname), 1, 4) = "MLRF" Then
            r = New CrystockledgerreportnEW4aLL_MLRF
        ElseIf Mid(UCase(gShortname), 1, 3) = "BGC" Then
            r = New CrystockledgerreportnEW4aLL_BGC
        ElseIf UCase(gShortname) = "CFC" Then
            r = New CrystockledgerreportnEW4aLL_CFC
        ElseIf UCase(gShortname) = "CPC" Then
            r = New CrystockledgerreportnEW4aLL__CPC
        ElseIf UCase(gShortname) = "RGC" Then
            r = New CrystockledgerreportnEW4aLL_RGC
        Else
            r = New CrystockledgerreportnEW4aLL
        End If


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
        sqlstring1 = "update tempclosingqty set SALEQTY=qty*-1,SALEVAL=rate*(qty*-1) where ttype='KOT'"
        gconnection.dataOperation(6, sqlstring1, )
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

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Cmd_View_Click(sender, e)
    End Sub

    Public Sub MU()
        Dim cuDate, nDate, TRNSDATE As DateTime
        Dim cuDate1, nDate1 As String
        Dim Tdate() As String
        Dim Nexttrns_seq, sqlstring As String
        Dim seq As Integer = 0
        Dim INSERT(0) As String
        Dim trns_seq, TRNSDATE1 As String
        Dim I, J, K As Integer
        Dim ttype() As String
        Dim ic(), ic2(), ic3(), ic1 As String
        'mydt.ToString("dd MMM yy tt")
        Try

            INSERT(0) = sqlstring
            sqlstring = "select * from TrnsView where   storecode='" + txt_mainstorecode.Text + "'  "

            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND ITEMCODE IN ("
                For I = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ic = Split(CheckedListBox3.CheckedItems(I), "-->")
                    sqlstring = sqlstring & "'" & ic(0) & "', "
                    ic1 = ic1 & "'" & ic(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                ic1 = Mid(ic1, 1, Len(ic1) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            sqlstring = sqlstring & " and ( right(left(convert(varchar, cast(docdate  as date), 112),8),6)<>LEFT(trns_seq,6) or trns_seq in (select trns_seq from TrnsView  where ttype not in ('ISSUE', 'RECEIEVE','TRANSFER_FROM','TRANSFER_TO')   group by trns_seq having count(trns_seq)>1)) "

            'sqlstring = sqlstring & "  group by trns_seq having count(trns_seq)>1))"
            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                sqlstring = sqlstring & " and docdate>='2016-01-01 00:00:00.000'"
            End If
            sqlstring = sqlstring & " order by CAST(CONVERT(VARCHAR(11),docdate ,106) AS DATETIME),priority"

            gconnection.getDataSet(sqlstring, "TrnsView")
            If (gdataset.Tables("TrnsView").Rows.Count > 0) Then
                For I = 0 To gdataset.Tables("TrnsView").Rows.Count - 1

                    Try



                        sqlstring = "select MAX(TRNS_SEQ) AS TRNS_SEQ from TrnsView where   CONVERT(VARCHAR(11), docdate, 106)= '" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd MMM yyyy") & "'"
                        gconnection.getDataSet(sqlstring, "TRNS_SEQ")

                        If (gdataset.Tables("TRNS_SEQ").Rows.Count > 0) Then
                            cuDate = Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy")
                            cuDate1 = cuDate.ToString("dd/MM/yy")
                            Nexttrns_seq = Val(gdataset.Tables("TRNS_SEQ").Rows(0).Item("TRNS_SEQ"))
                            If Nexttrns_seq = 0 Or Mid(Nexttrns_seq, 1, 6) <> Val(cuDate.ToString("yyMMdd")) Then

                                sqlstring = "select isnull(MAX(TRNS_SEQ),0) AS TRNS_SEQ from TrnsView where   LEFT(trns_seq,6)= '" & Val(cuDate.ToString("yyMMdd")) & "'"
                                gconnection.getDataSet(sqlstring, "TRNS")
                                If (gdataset.Tables("TRNS").Rows.Count > 0) Then
                                    Nexttrns_seq = Val(gdataset.Tables("TRNS").Rows(0).Item("TRNS_SEQ"))
                                    'Nexttrns_seq = Nexttrns_seq + 1
                                    If Nexttrns_seq = 0 Then
                                        Tdate = Split(Trim(cuDate1), "/")
                                        Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
                                        Nexttrns_seq = Nexttrns_seq & Format(1, "00000")
                                    Else
                                        Nexttrns_seq = Nexttrns_seq + 1
                                    End If
                                Else
                                    Tdate = Split(Trim(cuDate1), "/")
                                    Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
                                    Nexttrns_seq = Nexttrns_seq & Format(1, "00000")
                                End If


                            Else
                                Nexttrns_seq = Nexttrns_seq + 1
                            End If
                        Else
                            TRNSDATE = Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy")
                            TRNSDATE1 = TRNSDATE.ToString("dd/MM/yy")
                            Tdate = Split(Trim(TRNSDATE1), "/")
                            Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
                            Nexttrns_seq = Nexttrns_seq & Format(1, "00000")
                        End If

                        ttype = Split(Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")), "/")

                        If ttype(0) = "Openning" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "Openning" Then
                            sqlstring = "update inv_InventoryOpenningstock set trns_seq=" & Val(Nexttrns_seq) & " where storecode='" & gdataset.Tables("TrnsView").Rows(I).Item("storecode") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and 'Openning'='" & gdataset.Tables("TrnsView").Rows(I).Item("ttype") & "'"
                            gconnection.dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "GRN" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "GRN" Then
                            sqlstring = "update Grn_details set trns_seq=" & Val(Nexttrns_seq) & " where grndetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and grndate='" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "'"
                            gconnection.dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "PRN" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "PRN" Then
                            sqlstring = "update Prn_details set trns_seq=" & Val(Nexttrns_seq) & " where Prndetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and Prndate='" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "'"
                            gconnection.dataOperation(6, sqlstring, )
                        ElseIf ttype(0) = "ISSUE" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "ISSUE" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "RECEIEVE" Then

                            If Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "ISSUE" Then

                                sqlstring = "update STOCKISSUEdetail set trns_seq=" & Val(Nexttrns_seq) & " where STORELOCATIONCODE='" + Trim(gdataset.Tables("TrnsView").Rows(I).Item("STORECODE")) + "' AND  docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND    itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            Else
                                sqlstring = "update STOCKISSUEdetail set trns_seq=" & Val(Nexttrns_seq) & " where OPSTORELOCATIONCODE='" + Trim(gdataset.Tables("TrnsView").Rows(I).Item("STORECODE")) + "' AND  docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND    itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            End If

                            'sqlstring = "update STOCKISSUEdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            gconnection.dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "ADJ" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "ADJUSTMENT1" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "ADJUSTMENT" Then
                            sqlstring = "update STOCKADJUSTDETAILs set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            gconnection.dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "CON" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "CONSUME" Then
                            sqlstring = "update stockConsumption_1 set trns_seq=" & Val(Nexttrns_seq) & " where docNO='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            gconnection.dataOperation(6, sqlstring, )

                            sqlstring = "update StockConsumption_detail set trns_seq=" & Val(Nexttrns_seq) & " where docNO='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            gconnection.dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "DMG" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "DAMAGE" Then

                            sqlstring = "update STOCKDMGdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            gconnection.dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "RET" Or ttype(0) = "TRF" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "TRANSFER_TO" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "TRANSFER_FROM" Then

                            sqlstring = "update STOCKTRANSFERdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            gconnection.dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "KOT" Or ttype(0) = "DBAR" Or ttype(0) = "KBAR" Or ttype(0) = "BARD" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "KOT" Then
                            sqlstring = "update SUBSTORECONSUMPTIONDETAIL set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "'  and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"

                            gconnection.dataOperation(6, sqlstring, )
                        End If
                    Catch ex As Exception
                        Continue For
                    End Try
                Next
            End If



            Dim closingstock, closingvalue, openningstock, openningvalue, qty, rate, WRATE, TRNrate, TRNqty, TRNvalue As Double

            Dim storecode, Storestatus, trntype, itemcode, uom, trnno, sql1 As String
            Dim TrnDATE As DateTime
            Dim RateFleg As String = "P"
            Dim priority As Integer
            Dim STOCKUOM As String
            Dim CONVVALUE As Double
            Dim precise As Double

            Dim fLAG As Boolean

            sqlstring = "select * from TrnsView where storecode='" + txt_mainstorecode.Text + "' "

            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                sqlstring = sqlstring & " and docdate>='2016-01-01 00:00:00.000'"
            End If
            If CheckedListBox3.CheckedItems.Count <> 0 Then

                sqlstring = sqlstring & " AND ITEMCODE IN (" + ic1 + ")"
                'For I = 0 To CheckedListBox3.CheckedItems.Count - 1
                '    ic2 = Split(CheckedListBox3.CheckedItems(I), "-->")
                '    sqlstring = sqlstring & "'" & ic2(0) & "', "
                'Next
                'sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                'sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & "  order by storecode,itemcode,CAST(CONVERT(VARCHAR(11),docdate ,106) AS DATETIME),priority,TRNS_SEQ"
            gconnection.getDataSet(sqlstring, "TrnsView")
            If (gdataset.Tables("TrnsView").Rows.Count > 0) Then

                sqlstring = "delete from closingqty where storecode='" + txt_mainstorecode.Text + "'  "

                If CheckedListBox3.CheckedItems.Count <> 0 Then

                    sqlstring = sqlstring & " AND ITEMCODE IN (" + ic1 + ")"
                    'For I = 0 To CheckedListBox3.CheckedItems.Count - 1
                    '    ic3 = Split(CheckedListBox3.CheckedItems(I), "-->")
                    '    sqlstring = sqlstring & "'" & ic3(0) & "', "
                    'Next
                    'sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    'sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                gconnection.dataOperation(6, sqlstring, )


                For I = 0 To gdataset.Tables("TrnsView").Rows.Count - 1

                    Try

                        STOCKUOM = 0
                        CONVVALUE = 1
                        closingstock = 0
                        closingvalue = 0
                        openningstock = 0
                        openningvalue = 0
                        qty = 0
                        rate = 0
                        trntype = ""

                        itemcode = Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode"))
                        'If I <> 508 Then
                        '    '  Continue For
                        'Else
                        '    MsgBox("")

                        'End If

                        itemcode = Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode"))
                        uom = Trim(gdataset.Tables("TrnsView").Rows(I).Item("uom"))
                        trnno = Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails"))
                        storecode = Trim(gdataset.Tables("TrnsView").Rows(I).Item("storecode"))
                        TrnDATE = CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate"))
                        trntype = Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype"))
                        trns_seq = Val(gdataset.Tables("TrnsView").Rows(I).Item("trns_seq"))
                        priority = Val(gdataset.Tables("TrnsView").Rows(I).Item("priority"))


                        sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
                        STOCKUOM = gconnection.getvalue(sqlstring)
                        If STOCKUOM = "" Then
                            Continue For
                        End If
                        sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
                        gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                            precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                        Else
                            MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            GmoduleName = "Uom Convertion Entry"
                            Dim uomr As New FrmUOMRelation
                            'uomr.MdiParent = Me
                            uomr.baseuom = STOCKUOM
                            uomr.transuom = uom
                            uomr.ShowDialog()
                            sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
                            STOCKUOM = gconnection.getvalue(sqlstring)
                            sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
                            gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then

                                sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
                                STOCKUOM = gconnection.getvalue(sqlstring)
                                sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
                                gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                End If


                            Else

                                Exit Sub
                            End If

                        End If

                        If Trim(trntype.ToUpper()) <> "OPENNING" Then
                            sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and trns_seq<" & Val(trns_seq) & "  order by trns_seq desc"
                            gconnection.getDataSet(sqlstring, "closingqty")

                            If (gdataset.Tables("closingqty").Rows.Count > 0) Then

                                openningstock = Val(gdataset.Tables("closingqty").Rows(0).Item("closingstock"))
                                openningvalue = Val(gdataset.Tables("closingqty").Rows(0).Item("closingvalue"))

                                qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("QTY"))

                                qty = qty / CONVVALUE

                                If Trim(trntype.ToUpper()) = "GRN" Then

                                    sql1 = " select rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
                                    sql1 = sql1 & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" & itemcode & "'  "
                                    gconnection.getDataSet(sql1, "RATEFLAG")
                                    If (gdataset.Tables("RATEFLAG").Rows.Count > 0) Then
                                        RateFleg = gdataset.Tables("RATEFLAG").Rows(0).Item("RATEFLAG")
                                    Else
                                        MsgBox("Fill RATEFLAG detail of itemcode= " & itemcode & "  in ItemMaster")
                                        Continue For
                                    End If
                                    sqlstring = "SELECT amount,qty,ISNULL(RET_qty,0) AS RET_qty,ISNULL(RET_qty,0) AS RET_qty FROM Grn_details WHERE grndetails='" & trnno & "' and itemcode='" & itemcode & "'"
                                    gconnection.getDataSet(sqlstring, "Grn_details")

                                    If (gdataset.Tables("Grn_details").Rows.Count > 0) Then



                                        TRNvalue = Val(gdataset.Tables("Grn_details").Rows(0).Item("amount"))
                                        TRNqty = Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) '') ''- Val(gdataset.Tables("Grn_details").Rows(0).Item("rET_qty")))
                                    End If

                                    If Trim(RateFleg.ToUpper()) = "W" Then

                                        rate = (openningvalue + TRNvalue) / (openningstock + TRNqty)
                                    Else
                                        rate = TRNvalue / TRNqty
                                    End If

                                ElseIf Trim(trntype.ToUpper()) = "RECEIEVE" Then

                                    rate = Val(gdataset.Tables("TrnsView").Rows(I).Item("RATE"))
                                Else


                                    If openningvalue = 0 And openningstock = 0 Then
                                        rate = 1
                                    Else
                                        rate = openningvalue / openningstock
                                    End If

                                End If


                                If Trim(trntype.ToUpper()) = "ISSUE" Or Trim(trntype.ToUpper()) = "KOT" Or Trim(trntype.ToUpper()) = "CONSUME" Or Trim(trntype.ToUpper()) = "DAMAGE" Or Trim(trntype.ToUpper()) = "PRN" Or Trim(trntype.ToUpper()) = "TRANSFER_FROM" Then
                                    qty = qty * -1
                                End If

                                closingstock = openningstock + qty
                                closingvalue = closingstock * rate

                            Else

                                openningstock = 0
                                openningvalue = 0

                                qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("QTY"))
                                rate = Val(gdataset.Tables("TrnsView").Rows(I).Item("RATE"))

                                If Trim(trntype.ToUpper()) = "ISSUE" Or Trim(trntype.ToUpper()) = "KOT" Or Trim(trntype.ToUpper()) = "CONSUME" Or Trim(trntype.ToUpper()) = "DAMAGE" Or Trim(trntype.ToUpper()) = "PRN" Or Trim(trntype.ToUpper()) = "TRANSFER_FROM" Then
                                    qty = qty * -1
                                End If
                                closingstock = qty
                                closingvalue = qty * rate
                            End If
                        Else
                            qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("QTY"))
                            rate = Val(gdataset.Tables("TrnsView").Rows(I).Item("RATE"))
                            closingstock = qty
                            closingvalue = qty * rate
                        End If


                        If Trim(trntype.ToUpper()) = "ADJUSTMENT1" Then
                            trntype = "ADJUSTMENT"
                        End If
                        If Trim(trntype.ToUpper()) = "TRANSFER_FROM" Then
                            trntype = "TRANSFER"
                        End If
                        If Trim(trntype.ToUpper()) = "TRANSFER_TO" Then
                            trntype = "RECEIEVE"
                        End If
                        If Double.IsNaN(rate) Or Double.IsNaN(closingvalue) Then
                            Continue For
                        End If

                        sql1 = " SELECT TRNS_SEQ FROM CLOSINGQTY WHERE TRNS_SEQ=" + trns_seq + ""
                        gconnection.getDataSet(sql1, "A")

                        If (gdataset.Tables("A").Rows.Count > 0) Then

                            fLAG = True
                        Else
                            fLAG = False
                        End If

                        sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,ttype,batchyn,batchno,TRNS_SEQ,priority)"
                        sqlstring = sqlstring & " values ('" & trnno & "',"
                        sqlstring = sqlstring & " '" & itemcode & "',"
                        sqlstring = sqlstring & " '" & STOCKUOM & "',"
                        sqlstring = sqlstring & "'" & storecode & "',"
                        sqlstring = sqlstring & "'" & Format(CDate(TrnDATE), "dd/MMM/yyyy") & "',"
                        sqlstring = sqlstring & " " & openningstock & ","
                        sqlstring = sqlstring & "" & openningvalue & ","
                        sqlstring = sqlstring & "" & qty & ","
                        sqlstring = sqlstring & "" & closingstock & ","
                        sqlstring = sqlstring & "" & closingvalue & ","
                        sqlstring = sqlstring & "'" & trntype & "','','',"
                        If trntype = "RECEIEVE" Or Trim(trntype.ToUpper()) = "TRANSFER_TO" Or fLAG = True Then
                            sqlstring = sqlstring & "DBO.INV_GETSEQNO('" + Format(CDate(TrnDATE), "dd/MMM/yyyy") + "'),"
                            fLAG = False
                        Else
                            sqlstring = sqlstring & "'" & trns_seq & "',"
                            fLAG = False
                        End If
                        'sqlstring = sqlstring & "'" & trns_seq & "',"
                        sqlstring = sqlstring & "" & priority & ")"

                        gconnection.dataOperation(6, sqlstring, )
                    Catch ex As Exception
                        Continue For
                    End Try
                Next


            End If

            gconnection.dataOperation(6, "update closingqty set openningstock=isnull((select sum(qty) from closingqty a where a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ group by a.storecode,a.itemcode),0) ", )
            gconnection.dataOperation(6, "update closingqty set closingstock=openningstock+qty", )

            sqlstring = "update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end ,  lastweightedrate=  case when openningvalue=0 then batchrate    Else  openningvalue/openningstock      End  from ratelist r inner join CLOSINGQTY on r.grnno=CLOSINGQTY.trnno where trndate = r.grndate And CLOSINGQTY.storecode = r.storecode And CLOSINGQTY.itemcode = r.Itemcode and CLOSINGQTY.openningstock<>0 "
            gconnection.dataOperation(6, sqlstring, )
        Catch ex As Exception


            MsgBox(ex.ToString())
            Exit Sub
        End Try
    End Sub

    Private Sub ButExport_Click(sender As Object, e As EventArgs) Handles ButExport.Click
        Dim itemcode(), sqlstring1 As String
        Dim i As Integer
        'gconnection.valuation()

        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub

        If txt_mainstorecode.Text <> "" Then

        Else
            MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ' Call MU()

        ' gconnection.valuation()
        Dim sql As String = "drop table tempclosingqty"
        gconnection.dataOperation(6, sql, "tempclosingqty")
        'gconnection.valuation()
        '   Dim sqlstring As String = "SELECT Trnno,itemcode,UoM,storecode,Trndate,openningstock,openningvalue,qty,closingstock,batchno,TTYPE into tempclosingqty FROM closingqty where storecode='" + txt_mainstorecode.Text + "' "
        Dim sqlstring As String = " SELECT Trnno,A.itemcode,B.ITEMNAME,B.GROUPCODE,UoM,A.storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchno,TTYPE,trns_seq,priority,RATE into tempclosingqty FROM  closingqty A INNER JOIN INV_INVENTORYITEMMASTER B ON A.itemcode=B.itemcode WHERE a.STORECODE='" + txt_mainstorecode.Text + "'"

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


        sqlstring1 = " ALTER TABLE tempclosingqty ADD  opqty NUMERIC(15,3) ,opval NUMERIC(15,2) ,purqty NUMERIC(15,3), purval NUMERIC(15,2), issqty NUMERIC(15,3), "
        sqlstring1 = sqlstring1 & " issval NUMERIC(15,2) ,adjqty NUMERIC(15,3) ,adjval NUMERIC(15,2) ,damqty NUMERIC(15,3) ,damval NUMERIC(15,2) ,SALEQTY NUMERIC(15,3) ,SALEVAL NUMERIC(15,2)"

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
        sqlstring1 = "update tempclosingqty set purqty=tempclosingqty.qty,purval=V.RATE*tempclosingqty.qty  from INV_WEIGHTED_VIEW2 v where tempclosingqty.trnno=v.docdetails AND tempclosingqty.ITEMCODE=V.ITEMCODE AND ttype IN ('GRN','RECEIEVE')"
        gconnection.dataOperation(6, sqlstring1, )
        sqlstring1 = "update tempclosingqty set issqty=(qty)*-1,issval=rate*(qty*-1) where ttype='ISSUE'"
        gconnection.dataOperation(6, sqlstring1, )
        sqlstring1 = "update tempclosingqty set adjqty=qty,adjval=rate*qty where ttype='ADJUSTMENT'"
        gconnection.dataOperation(6, sqlstring1, )
        sqlstring1 = "update tempclosingqty set adjqty=qty,adjval=rate*(qty*-1) where ttype='CONSUME'"
        gconnection.dataOperation(6, sqlstring1, )
        sqlstring1 = "update tempclosingqty set damqty=(qty)*-1,damval=rate*(qty*-1) where ttype='DAMAGE'"
        gconnection.dataOperation(6, sqlstring1, )
        sqlstring1 = "update tempclosingqty set SALEQTY=qty*-1,SALEVAL=rate*(qty*-1) where ttype='KOT'"
        gconnection.dataOperation(6, sqlstring1, )

        sqlstring = "select  TRNNO,ITEMCODE,ITEMNAME,UOM,STORECODE,cast(TRNDATE as varchar(12)) as TRNDATE,OPENNINGSTOCK,OPENNINGVALUE,QTY,ISNULL(RATE,0) AS RATE,CLOSINGSTOCK,CLOSINGVALUE,TTYPE from tempclosingqty   ORDER BY ITEMCODE,STORECODE,trndate,trns_seq,priority"

        gconnection.getDataSet(sqlstring, "tempclosingqty")

        If (gdataset.Tables("tempclosingqty").Rows.Count > 0) Then
            Dim exp As New exportexcel
            exp.Show()
            Call exp.export(sqlstring, "Stock Ledger " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

        Else

            MessageBox.Show("No Record Found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

        End If

    End Sub
   
    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub CheckedListBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox3.KeyDown
        'If e.KeyCode = Keys.F1 Then
        '    Dim Advsearch As New frmListSearch
        '    Advsearch.listbox = CheckedListBox3
        '    Advsearch.Text = "Item Search"
        '    Advsearch.ShowDialog(Me)
        'End If
    End Sub

    Private Sub CheckedListBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox2.KeyDown
        'If e.KeyCode = Keys.F2 Then
        '    Dim search As New frmListSearch
        '    search.listbox = CheckedListBox2
        '    search.Text = "Category Search"
        '    search.ShowDialog(Me)
        'End If
    End Sub

    Private Sub CheckedListBox2_Leave(sender As Object, e As EventArgs) Handles CheckedListBox2.Leave
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' and I.CATEGORY IN ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
            End If
        Next
        If CheckedListBox2.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
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

    Private Sub CheckedListBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CheckedListBox2.KeyPress

        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' and I.CATEGORY IN ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
            End If
        Next
        If CheckedListBox2.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
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