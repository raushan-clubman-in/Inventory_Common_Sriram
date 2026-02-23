Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class InvStockSummary
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

   


    Private Sub InvStockSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillItemdetails()
        FillGroupdetails()

        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
            dtpfromdate.Value = Format(CDate("01/Jan/2016"), "dd/MMM/yyyy")
        ElseIf UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/Jan/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        chksummary.Checked = True
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
        ChkCategory.Checked = False
        txt_mainstore.Text = ""
        txt_mainstorecode.Text = ""
        If UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/jan/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        '  dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
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
        sqlstring = sqlstring & " WHERE I.CATEGORY IN ("

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
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        VIEWSTOCKSUMMARY()
    End Sub


    Private Sub VIEWSTOCKSUMMARY()
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME() As String
            Dim i As Integer
            

            Dim rViewer As New Viewer
            Dim r
            Dim m As New CrystocksummaryLIQ
            Dim d As New Crystocksummary2D
            If UCase(gShortname) = "MLRF" Then
                r = New Crystocksummary_MLRF
            ElseIf UCase(gShortname) = "BGC" Then
                r = New Crystocksummary_BGC
            ElseIf UCase(gShortname) = "CFC" Then
                r = New Crystocksummary_CFC
            ElseIf UCase(gShortname) = "FMC" Then
                r = New Crystocksummary_FMC
            ElseIf UCase(gShortname) = "RCL" Then
                r = New Crystocksummary_RCL
            ElseIf UCase(gShortname) = "CPC" Then
                r = New Crystocksummary_CPC
            ElseIf UCase(gShortname) = "KGA" Then
                r = New Crystocksummary_KGA
            ElseIf UCase(gShortname) = "KBA" Then
                r = New Crystocksummary_KBA
            ElseIf UCase(gShortname) = "RSIHYD" Then
                r = New Crystocksummary_RSIHYD
            Else
                r = New Crystocksummary
            End If

            If txt_mainstorecode.Text <> "" Then

            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim bdate As String
            bdate = gconnection.getvalue("  SELECT Convert(varchar(11), bdate, 106) As bdate FROM Businessdate")

            ' gconnection.valuation()
            Me.Cursor = Cursors.WaitCursor
            If gShortname = "HGA" Then
                sqlstring = "exec  passinvntoryunmatchedentries"
                gconnection.ExcuteStoreProcedure(sqlstring)
            End If


            sqlstring = "if exists(select * from sysobjects where name='TempRate') begin DROP TABLE TempRate end "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = " select * into TempRate from CLOSINGQTY"
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")

            If Mid(UCase(gShortname), 1, 4) <> "MLRF" Or gShortname <> "CATH" Then

                sqlstring = "UPDATE CLOSINGQTY SET  RATE = ISNULL((SELECT TOP 1 RATE FROM TempRate B WHERE  B.ttype IN ('RECEIEVE','OPENNING','GRN')  AND CLOSINGQTY.storecode=B.STORECODE AND CLOSINGQTY.itemcode=B.itemcode AND CLOSINGQTY.AUTOID>B.Autoid ORDER BY B.Autoid DESC    ) ,0) WHERE  CLOSINGQTY.TTYPE IN ('KOT')  and closingqty.storecode='" + txt_mainstorecode.Text + "' and cast(trndate as date)>'" & bdate & "' "
                gconnection.dataOperation(6, sqlstring, "tempclosingqty")

            End If


            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'stocksummary' AND  COLUMN_NAME = 'username') Begin alter table stocksummary add  username varchar(100) End"
            gconnection.dataOperation(6, sqlstring, "username")

            sqlstring = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'stocksummary' AND  COLUMN_NAME = 'MachineName') Begin alter table stocksummary add  MachineName varchar(100) End"
            gconnection.dataOperation(6, sqlstring, "username")

            Dim machinename As String
            machinename = Environment.MachineName
            '  sqlstring = " delete from stocksummary "
            'Added By Sriram 
            sqlstring = " delete from stocksummary where username= '" & Trim(gUsername) & "' and machinename='" & machinename & "'"
            gconnection.dataOperation(6, sqlstring, "stocksummary")



            'sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY) "
            'sqlstring = sqlstring & " select itemcode,ITEMNAME,'" + txt_mainstorecode.Text + "',STOCKUOM ,'0','0','0' "

            sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY,username,MachineName) "
            sqlstring = sqlstring & " select itemcode,ITEMNAME,'" + txt_mainstorecode.Text + "',STOCKUOM ,'0','0','0','" & Trim(gUsername) & "','" & machinename & "'"
            sqlstring = sqlstring & " from INV_InventoryItemMaster    "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " where ITEMCODE IN ("
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


            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 4) = "MLRF" Then
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                    sqlstring = " exec CP_stocksummary  '01/01/2016', '01/01/2016','" + Format(DTPaSondATE.Value, "dd/MMM/yyyy  23:59:59") + "','" + txt_mainstorecode.Text + "','" & Trim(gUsername) & "','" & machinename & "'"
                Else
                    sqlstring = " exec CP_stocksummary  '01/01/2016', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy  23:59:59") + "','" + txt_mainstorecode.Text + "','" & Trim(gUsername) & "','" & machinename & "'"
                End If

                'sqlstring = " exec CP_stocksummary  '01/01/2016', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy ") + "','" + txt_mainstorecode.Text + "'"
            Else

                If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                    sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "','" + Format(DTPaSondATE.Value, "dd/MMM/yyyy  23:59:59") + "','" + txt_mainstorecode.Text + "','" & Trim(gUsername) & "','" & machinename & "'"
                Else
                    sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy  23:59:59") + "','" + txt_mainstorecode.Text + "','" & Trim(gUsername) & "','" & machinename & "'"
                End If

            End If


            gconnection.ExcuteStoreProcedure(sqlstring)

            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or UCase(gShortname) = "HSR" Or UCase(gShortname) = "CCL" Or UCase(gShortname) = "ALUMNI" Or UCase(gShortname) = "MGC" Or UCase(gShortname) = "MYLC" Or UCase(gShortname) = "GNC" Or UCase(gShortname) = "CCC" Then
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/100) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                    'sqlstring = sqlstring & "Issqty=cast(Issqty as Int)+(((ABS(Issqty)-cast(Issqty as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                    ' sqlstring = sqlstring & "DMGQTY=cast(DMGQTY as Int)+(((ABS(DMGQTY)-cast(DMGQTY as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "closingqty=  case when closingqty>0  then cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then cast(ADJQTY as Int)+(((ABS(ADJQTY)-cast(ADJQTY as Int))/t.CONVVALUE)) else CAST(ADJQTY AS INT)-(((ABS(ADJQTY))+CAST(ADJQTY AS INT))/t.CONVVALUE) end "
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM and S.CATEGORYCODE NOT IN ('PRO') AND  U.storecode='" & txt_mainstorecode.Text & "' and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "

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
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM AND  U.storecode='" & txt_mainstorecode.Text & "' and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "

                End If

                gconnection.dataOperation(6, sqlstring, )

            Else

            End If

            ' gconnection.dataOperation(6, "exec cp_stockissue", )
            If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' and ttype='issue' and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                    ' gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 and isnull(T.void,'N')<>'Y' AND  t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN  CAST(CONVERT(VARCHAR(11),'01/Jan/2016' ,106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )
                    gconnection.dataOperation(6, sqlstring, )

                Else
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                    gconnection.dataOperation(6, sqlstring, )
                    ' gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 AND isnull(T.void,'N')<>'Y' AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN  CAST(CONVERT(VARCHAR(11),'01/Apr/2016' ,106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )
                End If
            Else
                'If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                '    gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)", )
                'Else
                sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and username='" & Trim(gUsername) & "' and machinename='" & machinename & "'  and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                ' gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 AND  isnull(T.void,'N')<>'Y' AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN CAST(CONVERT(VARCHAR(11),'" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )
                gconnection.dataOperation(6, sqlstring, )
                'End If
            End If

            ' gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )
            gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )



            sqlstring = "update stocksummary set     issqty=issqty*-1,dmgqty=dmgqty*-1,saleqty=saleqty*-1 "
            gconnection.dataOperation(6, sqlstring, )

            'sqlstring = "update stocksummary set itemname=itemname + ' -'+ 'STKCTL(' + (SELECT isnull(STKCTL,'')as stkctl )+')' from ItemMaster R ,STOCKSUMMARY S WHERE R.ITEMCODE=S.itemcode and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "
            'gconnection.dataOperation(6, sqlstring, )


            'sqlstring = "update stocksummary set     clvalue=(isnull(OPVALUE,0)+isnull(receiveAmt,0)+isnull(adjval,0))-isnull(issuevalue,0)  "
            'gconnection.dataOperation(6, sqlstring, )

            'sqlstring = "update stocksummary set     CLrate=clvalue/closingqty  where closingqty<>0 "
            'gconnection.dataOperation(6, sqlstring, )

            If chk_without_zero.Checked = True Then

                sqlstring = " select * from stocksummary where  closingqty<>'0' AND username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "




            ElseIf chksummary.Checked = True Then
                sqlstring = " select * from stocksummary where (openningqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 4) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname"
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
            ElseIf ChBZero.Checked = True Then

                sqlstring = " select * from stocksummary where username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "
                If UCase(gShortname) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname "
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
            Else

                sqlstring = " select * from stocksummary where ( issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') and  username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gCompanyname)), 1, 4) = "MLRF" Then
                        sqlstring = sqlstring & " order by itemname"
                    Else
                        sqlstring = sqlstring & " order by itemcode "
                    End If
            End If

            Me.Cursor = Cursors.WaitCursor
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
                ElseIf Mid(UCase(Trim(gCompanyname)), 1, 3) = "ALU" Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = d
                    rViewer.TableName = "Stocksummary"
                    'Dim picture1 As PictureObject
                    'picture1 = r.ReportDefinition.ReportObjects("picture1")
                    'If (gShortname = "KOLKATA") Then
                    '    picture1.ObjectFormat.EnableSuppress = False
                    'Else
                    '    picture1.ObjectFormat.EnableSuppress = True

                    'End If
                    Dim textobj1 As TextObject
                    textobj1 = d.ReportDefinition.ReportObjects("Text12")
                    textobj1.Text = MyCompanyName

                    Dim textobj5 As TextObject
                    textobj5 = d.ReportDefinition.ReportObjects("Text15")
                    textobj5.Text = UCase(Address1)
                    Dim textobj6 As TextObject
                    textobj6 = d.ReportDefinition.ReportObjects("Text16")
                    textobj6.Text = UCase(Address2)
                    Dim textobj2 As TextObject
                    textobj2 = d.ReportDefinition.ReportObjects("Text13")
                    textobj2.Text = Trim(txt_mainstore.Text)
                    Dim textobj22 As TextObject
                    textobj22 = d.ReportDefinition.ReportObjects("Text11")
                    textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = d.ReportDefinition.ReportObjects("Text17")
                    If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                        TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                        Dim textobj29 As TextObject
                        textobj29 = d.ReportDefinition.ReportObjects("Text10")
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
                        Dim textobj32 As TextObject
                        textobj32 = r.ReportDefinition.ReportObjects("Text32")
                        textobj32.Text = UCase(gPhone1) + "," + UCase(gPhone2)
                        Dim textobj33 As TextObject
                        textobj33 = r.ReportDefinition.ReportObjects("Text33")
                        textobj32.Text = "GSTIN NO :" & UCase(gGSTINNO)

                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = r.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = r.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If
                        'If UCase(gShortname) = "TMA" Then
                        '    Dim textobj31 As TextObject
                        '    textobj31 = r.reportdefinition.reportobjects("text31")
                        '    textobj31.Text = "     Store Keeper:                                                                                                                                                                                                                                   Manager:"
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
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = r.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If
                        If UCase(gShortname) = "TMA" Then
                            Dim textobj31 As TextObject
                            textobj31 = r.reportdefinition.reportobjects("text31")
                            textobj31.Text = "     Store Keeper:                                                                                                                                                                                                                                   Manager:"
                        End If

                        If gShortname = "KGA" Then

                            Dim textobj7 As TextObject
                            textobj7 = r.ReportDefinition.ReportObjects("Text33")
                            textobj7.Text = Trim(gUsername)

                            Dim textobj8 As TextObject
                            textobj8 = r.ReportDefinition.ReportObjects("Text34")
                            textobj8.Text = machinename

                        End If
                     
                        'Dim bdate As String
                        'sqlstring = "select bdate from Businessdate "
                        'gconnection.getDataSet(sqlstring, "INDENTHDR")
                        'If gdataset.Tables("INDENTHDR").Rows.Count > 0 Then
                        '    bdate = Format(gdataset.Tables("INDENTHDR").Rows(0).Item("bdate"), "dd/MM/yyyy")
                        'End If
                        sqlstring = "update stocksummary set PROMOTIONALST='" & bdate & "' "
                        gconnection.dataOperation(6, sqlstring, )



                    End If
                    

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                End If


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
            Dim machinename As String
            machinename = Environment.MachineName
            '  sqlstring = " delete from stocksummary "
            'Added By Sriram 
            If CHK_DisplayColumn.Checked = False Then

                sqlstring = " delete from stocksummary where username= '" & Trim(gUsername) & "' and machinename='" & machinename & "'"
                gconnection.dataOperation(6, sqlstring, "stocksummary")

                'sqlstring = " delete from stocksummary"
                'gconnection.dataOperation(6, sqlstring, "stocksummary")
                sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,uom,opstk,username,MachineName) "
                sqlstring = sqlstring & " select O.itemcode,I.ITEMNAME,storecode, "
                sqlstring = sqlstring & " O.uom,O.openningqty,'" & Trim(gUsername) & "','" & machinename & "' from inv_InventoryOpenningstock O INNER JOIN INV_InventoryItemMaster I ON I.ITEMCODE=O.ITEMCODE where storecode ='" + txt_mainstorecode.Text + "' "
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
                sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "','" & Trim(gUsername) & "','" & machinename & "'"

                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = " select ITEMCODE,ITEMNAME ,UOM,OPSTK,opweightedrate AS OPRATE,opvalue AS OPVALUE,abs(issqty) AS ISSUE_QTY,dmgqty AS DMG_QTY,adjqty AS ADJ_QTY,abs(saleqty) AS SALE_QTY,receiveqty AS REC_QTY,closingqty AS CLOSING_QTY,clweightedrate AS CLOSING_RATE,clvalue AS CLOSING_VALUE from stocksummary where (issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') AND username='" & Trim(gUsername) & "' and machinename='" & machinename & "' order by itemcode"

            End If
            If CHK_DisplayColumn.Checked = True Then

                sqlstring = " delete from stocksummary where username= '" & Trim(gUsername) & "' and machinename='" & machinename & "'"
                gconnection.dataOperation(6, sqlstring, "stocksummary")

                'sqlstring = " delete from stocksummary"
                'gconnection.dataOperation(6, sqlstring, "stocksummary")
                sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,uom,opstk,username,MachineName) "
                sqlstring = sqlstring & " select O.itemcode,I.ITEMNAME,storecode, "
                sqlstring = sqlstring & " O.uom,O.openningqty,'" & Trim(gUsername) & "','" & machinename & "' from inv_InventoryOpenningstock O INNER JOIN INV_InventoryItemMaster I ON I.ITEMCODE=O.ITEMCODE where storecode ='" + txt_mainstorecode.Text + "' "
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

                sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "','" & Trim(gUsername) & "','" & machinename & "'"

                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = "select * from view_stocksummary where username='" & Trim(gUsername) & "' and machinename='" & machinename & "' order by itemcode"
            End If

            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "stocksummary")
            If gdataset.Tables("stocksummary").Rows.Count > 0 Then

                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "Stock Summary " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            GroupBox4.Visible = True
        Else
            GroupBox4.Visible = False
        End If
    End Sub

    Private Sub CheckedListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox3.SelectedIndexChanged

    End Sub

    Private Sub CheckedListBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CheckedListBox2.KeyPress
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE I.CATEGORY IN ("

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