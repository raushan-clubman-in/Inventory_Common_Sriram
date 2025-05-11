Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine


Public Class FrmConsolidate
    Dim gconnection As New GlobalClass
    Dim sqlstring, sql, ExicesUOM As String
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
        'sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER  where CATEGORYCODE in (select CATEGORYCODE from INV_INVENTORYITEMMASTER) ORDER BY CATEGORYCODE "
        'gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        'If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
        '    For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
        '        With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
        '            CheckedListBox2.Items.Add(Trim(CStr(.Item("CATEGORYCODE"))))
        '        End With
        '    Next
        'End If
        If CHK_ACCOUNT.Checked = True Then

            If gAcPostingWise = "CATEGORY" Then
                sqlstring = " select  DISTINCT ISNULL(accountcode,'') AS Groupcode,ISNULL(accountDESC,'') AS Groupdesc from AccountstaggingForCategory WHERE accountcode<>''"
                gconnection.getDataSet(sqlstring, "ACOUNT")
            ElseIf gAcPostingWise = "STORE" Then
                sqlstring = " select  DISTINCT ISNULL(accountcode,'') AS Groupcode,ISNULL(accountDESC,'') AS Groupdesc from AccountstaggingNEW WHERE accountcode<>''"
                gconnection.getDataSet(sqlstring, "ACOUNT")
            Else
                sqlstring = " select  DISTINCT ISNULL(accountcode,'') AS Groupcode,ISNULL(accountDESC,'') AS Groupdesc from AccountstaggingForItem WHERE accountcode<>''"
                gconnection.getDataSet(sqlstring, "ACOUNT")
            End If

            If gdataset.Tables("ACOUNT").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("ACOUNT").Rows.Count - 1
                    With gdataset.Tables("ACOUNT").Rows(i)
                        CheckedListBox2.Items.Add(Trim(CStr(.Item("Groupcode"))) + "-->" + Trim(CStr(.Item("Groupdesc"))))
                    End With
                Next
            End If

        Else


            If UCase(gShortname) = "SATC" Then
                sqlstring = "SELECT ISNULL(Groupcode,'') AS Groupcode,ISNULL(Groupdesc,'') AS Groupdesc FROM InventoryGroupMaster WHERE ISNULL(Freeze,'N')<>'Y'  AND GROUPCODE IN (SELECT Groupcode FROM INV_InventoryItemMaster)"
            ElseIf UCase(gShortname) = "RCL" Then
                sqlstring = "SELECT ISNULL(Groupcode,'') AS Groupcode,ISNULL(Groupdesc,'') AS Groupdesc FROM InventoryGroupMaster WHERE ISNULL(Freeze,'N')<>'Y'  AND GROUPCODE IN (SELECT Groupcode FROM INV_InventoryItemMaster)"
            ElseIf UCase(gShortname) = "SATC" Then
                sqlstring = "SELECT ISNULL(Groupcode,'') AS Groupcode,ISNULL(Groupdesc,'') AS Groupdesc FROM InventoryGroupMaster WHERE ISNULL(Freeze,'N')<>'Y' AND CATEGORYCODE IN ('BAR','CRK') AND GROUPCODE IN (SELECT Groupcode FROM INV_InventoryItemMaster)"

            Else
                sqlstring = "SELECT ISNULL(Groupcode,'') AS Groupcode,ISNULL(Groupdesc,'') AS Groupdesc FROM InventoryGroupMaster WHERE ISNULL(Freeze,'N')<>'Y'  AND GROUPCODE IN (SELECT Groupcode FROM INV_InventoryItemMaster)"
            End If
            gconnection.getDataSet(sqlstring, "InventoryGroupMaster")
            If gdataset.Tables("InventoryGroupMaster").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("InventoryGroupMaster").Rows.Count - 1
                    With gdataset.Tables("InventoryGroupMaster").Rows(i)
                        CheckedListBox2.Items.Add(Trim(CStr(.Item("Groupcode"))) + "-->" + Trim(CStr(.Item("Groupdesc"))))
                    End With
                Next
            End If

        End If




    End Sub

    Private Sub FrmConsolidate_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F10 Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F12 Then
                Call Button1_Click(sender, e)
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
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub FrmConsolidate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillStore()

        FillItemdetails()
        FillGroupdetails()
        If UCase(gShortname) = "HSR" Then
            Cmd_Print.Visible = False
        End If


        If UCase(gShortname) = "HGA" Or UCase(gShortname) = "SATC" Or UCase(gShortname) = "JSCA" Then
            CHK_ACCOUNT.Visible = True
            CHK_ACCOUNT.Checked = True
        End If

        If UCase(gcompname) = "JSCA" Then
            CHK_ACCOUNT.Visible = True
            CHK_ACCOUNT.Checked = True
        End If

        If UCase(gShortname) = "DC" Then
            reportdecimal.Visible = True
            reportdecimal.Checked = True
        End If

        If UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/01/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        If gUserCategory <> "S" Then
            Call GetRights()

        End If
    End Sub
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        ChkItemCode.Checked = False
        ChkCategory.Checked = False
        FillStore()
        FillItemdetails()
        FillGroupdetails()
        dtpfromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        If gUserCategory <> "S" Then
            'Call GetRights()
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
    Private Sub CheckedListBox2_Click(sender As Object, e As EventArgs) Handles CheckedListBox2.Click
        Dim i, J As Integer
        Dim sqlstring, ssql, groupcode() As String
        ssql = ""
        If CHK_ACCOUNT.Checked = True Then
            sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM AccountstaggingForItem AS I "
            sqlstring = sqlstring & " WHERE  I.accountcode IN ("

            For J = 0 To CheckedListBox2.CheckedItems.Count - 1
                If J = CheckedListBox2.CheckedItems.Count - 1 Then
                    groupcode = Split(CheckedListBox2.CheckedItems(J), "-->")
                    ssql = ssql & " '" & groupcode(0) & "' "
                Else
                    groupcode = Split(CheckedListBox2.CheckedItems(J), "-->")
                    ssql = ssql & " '" & groupcode(0) & "', "
                End If
            Next
        Else
            sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
            sqlstring = sqlstring & " WHERE  I.GROUPCODE IN ("

            For J = 0 To CheckedListBox2.CheckedItems.Count - 1
                If J = CheckedListBox2.CheckedItems.Count - 1 Then
                    groupcode = Split(CheckedListBox2.CheckedItems(J), "-->")
                    ssql = ssql & " '" & groupcode(0) & "' "
                Else
                    groupcode = Split(CheckedListBox2.CheckedItems(J), "-->")
                    ssql = ssql & " '" & groupcode(0) & "', "
                End If
            Next
        End If


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
        Dim sqlstring, ssql, groupcode() As String
        ssql = ""

        If CHK_ACCOUNT.Checked = True Then

            If gAcPostingWise = "CATEGORY" Then
                sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
                sqlstring = sqlstring & " WHERE category in (select  ISNULL(categorycode,'') from AccountstaggingForCategory WHERE accountcode<>'' and accountcode IN ("

            ElseIf gAcPostingWise = "STORE" Then
                sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM AccountstaggingForItem AS I "
                sqlstring = sqlstring & " WHERE  I.accountcode IN ("
            Else
                sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM AccountstaggingForItem AS I "
                sqlstring = sqlstring & " WHERE  I.accountcode IN ("
            End If


            For J = 0 To CheckedListBox2.CheckedItems.Count - 1
                If J = CheckedListBox2.CheckedItems.Count - 1 Then
                    groupcode = Split(CheckedListBox2.CheckedItems(J), "-->")
                    ssql = ssql & " '" & groupcode(0) & "' "
                Else
                    groupcode = Split(CheckedListBox2.CheckedItems(J), "-->")
                    ssql = ssql & " '" & groupcode(0) & "', "
                End If
            Next
            If gAcPostingWise = "CATEGORY" Then
                sqlstring = sqlstring & ssql & ")) ORDER BY ITEMCODE "
            Else
                sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
            End If
        Else
            sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
            sqlstring = sqlstring & " WHERE  I.GROUPCODE IN ("
            For J = 0 To CheckedListBox2.CheckedItems.Count - 1
                If J = CheckedListBox2.CheckedItems.Count - 1 Then
                    groupcode = Split(CheckedListBox2.CheckedItems(J), "-->")
                    ssql = ssql & " '" & groupcode(0) & "' "
                Else
                    groupcode = Split(CheckedListBox2.CheckedItems(J), "-->")
                    ssql = ssql & " '" & groupcode(0) & "', "
                End If
            Next
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
        End If

        If CheckedListBox2.CheckedItems.Count > 0 Then
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


    Private Sub VIEWSTOCKSUMMARY()
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME(), STOREDESC() As String
            Dim i As Integer
            Dim r As New Cryconsolidate_ALL
            Dim r1 As New Cryconsolidate_BGC_CONSOLIDATED
            Dim SATC As New CryconsolidateSATC
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor

            sqlstring = " delete from consolidatestocksummary"
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            sqlstring = " insert into consolidatestocksummary(itemcode,ITEMNAME) "
            sqlstring = sqlstring & " select I.itemcode,I.ITEMNAME "
            sqlstring = sqlstring & " from  INV_InventoryItemMaster I  where  "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  I.ITEMCODE IN ("
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


            Dim FINYEARSTRT As Date
            If CDate(gFinancialyearStart).Year <= 2018 Then
                FINYEARSTRT = CDate("01/APR/2018")
            Else
                FINYEARSTRT = CDate(gFinancialyearStart)

            End If



            sqlstring = " exec Cp_ConsolidatedStockSaleNew  '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "'"
            If UCase(gShortname) = "BGC" Or UCase(gShortname) = "MLA" Then
                sqlstring = " exec Cp_Consolidate  '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "'"
            End If
            gconnection.ExcuteStoreProcedure(sqlstring)

            If UCase(gShortname) = "SATC" Or UCase(gShortname) = "KEA" Or UCase(gShortname) = "JSCA" Then

                sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) --AND  ( closingqty<>'0')"

            ElseIf reportdecimal.Checked = True Then
                'sqlstring = "update stocksummary set opstk=  case when OPQTY>0  then cast(OPQTY as Int)+(((ABS(OPQTY)-cast(OPQTY as Int))*t.CONVVALUE)/100) else CAST(OPQTY AS INT)-(((ABS(OPQTY))+CAST(OPQTY AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                '' sqlstring = sqlstring & "Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end ,"
                'sqlstring = sqlstring & "receiveqty=  case when receiveqty>0  then cast(receiveqty as Int)+(((ABS(receiveqty)-cast(receiveqty as Int))*t.CONVVALUE)/100) else CAST(receiveqty AS INT)-(((ABS(receiveqty))+CAST(receiveqty AS INT))*t.CONVVALUE)/100 end ,"
                'sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                'sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                ''- sqlstring = sqlstring & "DMGQTY=cast(DMGQTY as Int)+(((ABS(DMGQTY)-cast(DMGQTY as Int))*t.CONVVALUE)/100),"
                'sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                'sqlstring = sqlstring & "closingqty=  case when closingqty>0  then cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                'sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then cast(ADJQTY as Int)+(((ABS(ADJQTY)-cast(ADJQTY as Int))/t.CONVVALUE)) else CAST(ADJQTY AS INT)-(((ABS(ADJQTY))+CAST(ADJQTY AS INT))/t.CONVVALUE) end "
                'sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM"
                'gconnection.dataOperation(6, sqlstring, )

                sql = "if exists(select * from sysobjects where name='Items') begin DROP TABLE Items end"
                gconnection.dataOperation(6, sql, )

                sql = " select i.itemcode,i.storecode, i.reportUOM,i.reportdecimaluom,s.uom ,cast(null as numeric(18,6)) as  Conv1 ,cast(null as numeric(18,6)) as Conv2 into Items  from stocksummary s inner join inv_Inventoryuomstorelink i on s.itemcode=i.itemcode --and s.storecode=i.storecode "
                gconnection.dataOperation(6, sql, )

                If gShortname = "SKYYE" Then
                    sql = " update Items set Conv1= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.reportUOM=baseuom and s.Uom=t.transuom  "
                    gconnection.dataOperation(6, sql, )
                Else
                    sql = " update Items set Conv1= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportUOM=TRANSUOM "
                    gconnection.dataOperation(6, sql, )
                End If


                sql = " update Items set Conv2= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportdecimaluom=TRANSUOM "
                gconnection.dataOperation(6, sql, )

                sqlstring = " select reportUOM,uom from Items where Conv1 is null "
                gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
                If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
                    Dim stockuom As String = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("uom"))
                    ExicesUOM = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("reportUOM"))
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
                sqlstring = " select reportdecimaluom,uom from Items where Conv2 is null "
                gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
                If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
                    Dim stockuom As String = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("uom"))
                    ExicesUOM = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("reportdecimaluom"))
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
                sqlstring = " select reportUOM,reportdecimaluom from Items where reportUOM+reportdecimaluom NOT IN  ( select BASEUOM+transUOM from INVENTORY_TRANSCONVERSION where ISNULL(freeze,'')<>'Y') "
                gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
                If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
                    Dim stockuom As String = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("reportUOM"))
                    ExicesUOM = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("reportdecimaluom"))
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


                If gShortname = "SKYYE" Then
                    sql = " update stocksummary set uom=reportUOM, oprate = oprate*Conv1,clrate = clrate*Conv1 ,opstk= opstk/CONV1  ,Openningqty= Openningqty/Conv1 ,receiveqty=receiveqty/CONV1 ,Issqty=Issqty /CONV1,SALEQTY=SALEQTY/Conv1,DMGQTY=DMGQTY/Conv1,closingqty=closingqty/Conv1,ADJQTY=ADJQTY/Conv1 from stocksummary s inner join Items u on s.Itemcode=u.itemcode and  s.Uom=u.uom   "
                    gconnection.dataOperation(6, sql, )
                Else
                    sql = " update stocksummary set uom=reportUOM, oprate = oprate/Conv1,clrate = clrate/Conv1 ,OPQTY= OPQTY*CONV1  ,Openningqty= Openningqty*Conv1 ,receiveqty=receiveqty* CONV1 ,Issqty=Issqty * CONV1,SALEQTY=SALEQTY*Conv1,DMGQTY=DMGQTY*Conv1,closingqty=closingqty*Conv1,ADJQTY=ADJQTY*Conv1 from stocksummary s inner join Items u on s.Itemcode=u.itemcode and  s.Uom=u.uom   "
                    gconnection.dataOperation(6, sql, )
                End If
                sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) AND  (opqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0'  or receiveqty<>'0' or saleqty<>'0')"


            ElseIf chk_without_zero.Checked = True Then

                sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) AND  ( closingqty<>'0')"

            Else
                'If UCase(gShortname) = "BGC" Then
                '    sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY ,NEWUOM=UOM"

                '    gconnection.ExcuteStoreProcedure(sqlstring)
                '    sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY*25,NEWUOM='PEG' WHERE UOM='BOTTLE' AND ITEMCODE NOT IN (SELECT ITEMCODE FROM INV_InventoryItemMaster WHERE SUBGROUPCODE IN('51','174','75','70','OTHI','SAS','MW','SJ','74','SDR'))"
                '    gconnection.ExcuteStoreProcedure(sqlstring)

                '    sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY*0.08,NEWUOM='BOTTLE' WHERE UOM='PEG' AND  ITEMCODE NOT IN (SELECT ITEMCODE FROM INV_InventoryItemMaster WHERE SUBGROUPCODE IN('51','174','75','70','OTHI','SAS','MW','SJ','74','SDR'))"
                '    gconnection.ExcuteStoreProcedure(sqlstring)

                '    'sqlstring = "SELECT * FROM INV_INVENTORYITEMMASTER I INNER JOIN STOCKSUMMARY S ON I.ITEMCODE=S.ITEMCODE WHERE I.SUBGROUPCODE='51'"
                '    'gconnection.ExcuteStoreProcedure(sqlstring)
                'End If
                sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) AND  (opqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0'  or receiveqty<>'0' or saleqty<>'0')"

            End If

            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "stocksummary")

            If UCase(gShortname) = "SATC" Or UCase(gShortname) = "HGA" Or UCase(gShortname) = "JSCA" Then

                If gdataset.Tables("stocksummary").Rows.Count > 0 Then

                    Dim dt As New DataTable
                    Dim ds As New DataSet
                    dt = gconnection.GetValues(sqlstring)
                    dt.TableName = "stocksummary"
                    ds.Tables.Add(dt)

                    dt = gconnection.GetValues("SELECT PAYMENTMODE,SUM(AMOUNT) AS AMOUNT, SUM(TXAMT) AS TXAMT,SUM(STXAMT) AS STXAMT, SUM(TOTAMT) AS TOTAMT  FROM STKSUMMARY WHERE ISNULL(ISSQTY,0)>0 GROUP BY PAYMENTMODE")
                    dt.TableName = "STKSUMMARY"
                    ds.Tables.Add(dt)

                    dt = gconnection.GetValues("select * from INV_STKSALEDET")
                    dt.TableName = "INV_STKSALEDET"
                    ds.Tables.Add(dt)


                    'rViewer.ssql = sqlstring
                    'rViewer.Report = r
                    'rViewer.TableName = "Stocksummary"

                    Dim textobj1 As TextObject
                    textobj1 = SATC.ReportDefinition.ReportObjects("Text12")
                    textobj1.Text = MyCompanyName

                    Dim textobj5 As TextObject
                    textobj5 = SATC.ReportDefinition.ReportObjects("Text15")
                    textobj5.Text = UCase(Address1)
                    Dim textobj6 As TextObject
                    textobj6 = SATC.ReportDefinition.ReportObjects("Text16")
                    textobj6.Text = UCase(Address2) & " , " & UCase(gCity) & " , " & UCase(gState) & " - " & UCase(gPincode)
                    'Dim textobj2 As TextObject
                    'textobj2 = r.ReportDefinition.ReportObjects("Text13")
                    'textobj2.Text = Trim(txt_mainstore.Text)
                    Dim textobj22 As TextObject
                    textobj22 = SATC.ReportDefinition.ReportObjects("Text11")
                    textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = SATC.ReportDefinition.ReportObjects("Text17")
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

                    rViewer.GetDetails1(ds, SATC)

                    Dim II As Integer
                    Dim Sql As String = "SELECT ISNULL(Storedesc,'') AS STOREDESC FROM StoreMaster WHERE isnull(OPT,'')='Y' "
                    'End If
                    gconnection.getDataSet(Sql, "StoreMaster")
                    If gdataset.Tables("StoreMaster").Rows.Count > 0 Then
                        Sql = ""
                        For II = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
                            ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                            Sql = Sql & " " & Trim(gdataset.Tables("StoreMaster").Rows(II).Item("Storedesc")) & " ,"
                        Next
                    End If

                    Sql = Mid(Sql, 1, Len(Sql) - 2)

                    Dim Text8 As TextObject
                    Text8 = SATC.ReportDefinition.ReportObjects("Text8")
                    Text8.Text = Sql

                    rViewer.Show()
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
            Else
                If gdataset.Tables("stocksummary").Rows.Count > 0 Then

                    Dim dt As New DataTable
                    Dim ds As New DataSet
                    dt = gconnection.GetValues(sqlstring)
                    dt.TableName = "stocksummary"
                    ds.Tables.Add(dt)

                    dt = gconnection.GetValues("SELECT PAYMENTMODE,SUM(AMOUNT) AS AMOUNT, SUM(TXAMT) AS TXAMT,SUM(STXAMT) AS STXAMT, SUM(TOTAMT) AS TOTAMT  FROM STKSUMMARY WHERE ISNULL(ISSQTY,0)>0 GROUP BY PAYMENTMODE")
                    dt.TableName = "STKSUMMARY"
                    ds.Tables.Add(dt)

                    dt = gconnection.GetValues("select * from INV_STKSALEDET")
                    dt.TableName = "INV_STKSALEDET"
                    ds.Tables.Add(dt)

                    If gShortname = "BGC" Or gShortname = "DC" Or gShortname = "MLA" Then


                        Dim textobj1 As TextObject
                        textobj1 = r1.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = r1.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1)
                        Dim textobj6 As TextObject
                        textobj6 = r1.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(Address2) & " , " & UCase(gCity) & " , " & UCase(gState) & " - " & UCase(gPincode)
                        'Dim textobj2 As TextObject
                        'textobj2 = r.ReportDefinition.ReportObjects("Text13")
                        'textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = r1.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

                        rViewer.GetDetails1(ds, r1)


                        Dim II As Integer
                        Dim Sql As String = "SELECT ISNULL(Storedesc,'') AS STOREDESC FROM StoreMaster WHERE  isnull(OPT,'')='Y'"
                        'End If
                        gconnection.getDataSet(Sql, "StoreMaster")
                        If gdataset.Tables("StoreMaster").Rows.Count > 0 Then
                            Sql = ""
                            For II = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
                                ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                                Sql = Sql & " " & Trim(gdataset.Tables("StoreMaster").Rows(II).Item("Storedesc")) & " ,"
                            Next
                        End If

                        Sql = Mid(Sql, 1, Len(Sql) - 2)

                        Dim Text8 As TextObject
                        Text8 = r1.ReportDefinition.ReportObjects("Text8")
                        Text8.Text = Sql



                        rViewer.Show()
                        Me.Cursor = Cursors.Default



                    Else


                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = r.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1)
                        Dim textobj6 As TextObject
                        textobj6 = r.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(Address2) & " , " & UCase(gCity) & " , " & UCase(gState) & " - " & UCase(gPincode)
                        'Dim textobj2 As TextObject
                        'textobj2 = r.ReportDefinition.ReportObjects("Text13")
                        'textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = r.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

                        rViewer.GetDetails1(ds, r)


                        Dim II As Integer
                        Dim Sql As String = "SELECT ISNULL(Storedesc,'') AS STOREDESC FROM StoreMaster WHERE  isnull(OPT,'')='Y'"
                        'End If
                        gconnection.getDataSet(Sql, "StoreMaster")
                        If gdataset.Tables("StoreMaster").Rows.Count > 0 Then
                            Sql = ""
                            For II = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
                                ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                                Sql = Sql & " " & Trim(gdataset.Tables("StoreMaster").Rows(II).Item("Storedesc")) & " ,"
                            Next
                        End If

                        Sql = Mid(Sql, 1, Len(Sql) - 2)

                        Dim Text8 As TextObject
                        Text8 = r.ReportDefinition.ReportObjects("Text8")
                        Text8.Text = Sql



                        rViewer.Show()
                        Me.Cursor = Cursors.Default


                    End If

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
            End If



            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillStore()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT ISNULL(STOREcode,'') + '- '+ ISNULL(STOREdesc,'') AS STOREdesc FROM STOREMASTER WHERE isnull(freeze,'') <> 'Y' ORDER BY STOREdesc ASC"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        CheckedListBox1.Items.Clear()
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                CheckedListBox1.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STOREdesc"))
            Next i
        End If
    End Sub
    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click

        Dim sqlstring, CATEGORY(), ITEMNAME() As String
        Dim i As Integer

        If CheckedListBox1.CheckedItems.Count <> 0 Then
            sqlstring = " update storemaster set OPT='N' "
            gconnection.dataOperation(6, sqlstring, "storemaster")


            sqlstring = " DELETE  FROM  STORE  "
            gconnection.dataOperation(6, sqlstring, "STORE")


            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                ITEMNAME = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = " INSERT INTO STORE SELECT '" & Trim(ITEMNAME(0)) & "'"
                gconnection.dataOperation(6, sqlstring, "STORE")

                sqlstring = " update storemaster set OPT='Y' where storecode='" & Trim(ITEMNAME(0)) & "'"
                gconnection.dataOperation(6, sqlstring, "storemaster")
            Next
        Else
            sqlstring = " update storemaster set OPT='Y' "
            gconnection.dataOperation(6, sqlstring, "storemaster")
        End If
        If gShortname = "HGA" Then
            sqlstring = "exec  passinvntoryunmatchedentries"
            gconnection.ExcuteStoreProcedure(sqlstring)
        End If

        sqlstring = "select distinct storecode from storemaster where isnull(OPT,'')='Y'"
        gconnection.getDataSet(sqlstring, "USER")
        If gdataset.Tables("USER").Rows.Count = 1 Then
            If ClosingOnly.Checked = True Then
                Call viewclosingonly()
            Else
                VIEWSTOCKSUMMARY_4OneTypeOfStore()
            End If
        ElseIf ClosingOnly.Checked = True Then
            Call viewclosingonly()
        Else
            VIEWSTOCKSUMMARY()
        End If
    End Sub
    Private Sub viewclosingonly()
        Dim rViewer As New Viewer
        Dim CL
        CL = New CryConsolidateCL
        If gShortname = "CATHOLIC" Or gShortname = "CATH" Then
            CL = New CryConsolidateCL_CATHOLIC
        End If
        If gShortname = "NIZAM" Then
            CL = New CryConsolidateCL_NIZAM
        End If
        Dim sqlstring, CATEGORY(), ITEMNAME(), STOREDESC() As String
        Dim i As Integer
        Me.Cursor = Cursors.WaitCursor
        sqlstring = " delete from consolidatestocksummary"
        gconnection.dataOperation(6, sqlstring, "stocksummary")
        sqlstring = " insert into consolidatestocksummary(itemcode,ITEMNAME) "
        sqlstring = sqlstring & " select I.itemcode,I.ITEMNAME "
        sqlstring = sqlstring & " from  INV_InventoryItemMaster I  where  "
        If CheckedListBox3.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "  I.ITEMCODE IN ("
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
        Dim FINYEARSTRT As Date
        If CDate(gFinancialyearStart).Year <= 2018 Then
            FINYEARSTRT = CDate("01/APR/2018")
        Else
            FINYEARSTRT = CDate(gFinancialyearStart)
        End If
        sqlstring = " exec Cp_ConsolidatedStockSaleNew  '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "'"
        If UCase(gShortname) = "BGC" Or UCase(gShortname) = "MLA" Then
            sqlstring = " exec Cp_Consolidate  '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "'"
        End If
        gconnection.ExcuteStoreProcedure(sqlstring)
        If UCase(gShortname) = "SATC" Or UCase(gShortname) = "KEA" Then
            sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) --AND  ( closingqty<>'0')"

        ElseIf chk_without_zero.Checked = True Then
            sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) AND  (closingqty<>'0')"

        ElseIf gShortname = "CATHOLIC" Or gShortname = "CATH" Then
            sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) AND  (opqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0'  or receiveqty<>'0' or saleqty<>'0') and storecode='bar'"
        Else
            'If UCase(gShortname) = "BGC" Then
            '    sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY ,NEWUOM=UOM"

            '    gconnection.ExcuteStoreProcedure(sqlstring)
            '    sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY*25,NEWUOM='PEG' WHERE UOM='BOTTLE' AND ITEMCODE NOT IN (SELECT ITEMCODE FROM INV_InventoryItemMaster WHERE SUBGROUPCODE IN('51','174','75','70','OTHI','SAS','MW','SJ','74','SDR'))"
            '    gconnection.ExcuteStoreProcedure(sqlstring)

            '    sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY*0.08,NEWUOM='BOTTLE' WHERE UOM='PEG' AND  ITEMCODE NOT IN (SELECT ITEMCODE FROM INV_InventoryItemMaster WHERE SUBGROUPCODE IN('51','174','75','70','OTHI','SAS','MW','SJ','74','SDR'))"
            '    gconnection.ExcuteStoreProcedure(sqlstring)

            '    'sqlstring = "SELECT * FROM INV_INVENTORYITEMMASTER I INNER JOIN STOCKSUMMARY S ON I.ITEMCODE=S.ITEMCODE WHERE I.SUBGROUPCODE='51'"
            '    'gconnection.ExcuteStoreProcedure(sqlstring)
            'End If
            sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) AND  (opqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0'  or receiveqty<>'0' or saleqty<>'0')"
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
                Dim textobj1 As TextObject
                textobj1 = CL.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                Dim textobj5 As TextObject
                textobj5 = CL.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = CL.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                Dim textobj22 As TextObject
                textobj22 = CL.ReportDefinition.ReportObjects("Text11")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = CL.ReportDefinition.ReportObjects("Text17")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
            End If
            rViewer.Show()
            Me.Cursor = Cursors.Default
        Else
            MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
        End If
    End Sub
    Private Sub VIEWSTOCKSUMMARY_4OneTypeOfStore()
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME() As String
            Dim i As Integer


            Dim rViewer As New Viewer
            Dim r As New Cryconsolidate
            Dim R2 As New Cryconsolidate_BGC
            Dim m As New CrystocksummaryLIQ
            Dim d As New Crystocksummary2D

            Dim store As String

            'Me.Cursor = Cursors.WaitCursor

            'sqlstring = " delete from consolidatestocksummary"
            'gconnection.dataOperation(6, sqlstring, "stocksummary")
            'sqlstring = " insert into consolidatestocksummary(itemcode,ITEMNAME) "
            'sqlstring = sqlstring & " select I.itemcode,I.ITEMNAME "
            'sqlstring = sqlstring & " from  INV_InventoryItemMaster I  where ISNULL(I.void,'') <>'Y' "
            'If CheckedListBox3.CheckedItems.Count <> 0 Then
            '    sqlstring = sqlstring & " AND I.ITEMCODE IN ("
            '    For i = 0 To CheckedListBox3.CheckedItems.Count - 1
            '        ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
            '        sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
            '    Next
            '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            '    sqlstring = sqlstring & ")"
            'Else
            '    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If

            'gconnection.dataOperation(6, sqlstring, "stocksummary")

            'Dim FINYEARSTRT As Date
            'If CDate(gFinancialyearStart).Year <= 2018 Then
            '    FINYEARSTRT = CDate("01/APR/2018")
            'Else
            '    FINYEARSTRT = CDate(gFinancialyearStart)

            'End If

            'sqlstring = " exec Cp_ConsolidatedStockSaleNew  '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "'"
            'If UCase(gShortname) = "BGC" Or UCase(gShortname) = "MLA" Then
            '    sqlstring = " exec Cp_Consolidate '" + Format(FINYEARSTRT, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "'"
            'End If
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'If UCase(gShortname) = "SATC" Or UCase(gShortname) = "KEA" Then

            '    sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) --AND  ( closingqty<>'0')"

            'Else

            '    'sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY ,NEWUOM=UOM"

            '    'gconnection.ExcuteStoreProcedure(sqlstring)
            '    'sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY*25,NEWUOM='PEG' WHERE UOM='BOTTLE' AND ITEMCODE NOT IN (SELECT ITEMCODE FROM INV_INVENTORYITEMMASTER WHERE SUBGROUPCODE IN('51','174','75','70','OTHI','SAS','MW','SJ','74','SDR'))"
            '    'gconnection.ExcuteStoreProcedure(sqlstring)

            '    'sqlstring = "UPDATE stocksummary SET NEWCLSQTY=CLOSINGQTY*0.08,NEWUOM='BOTTLE' WHERE UOM='PEG' AND ITEMCODE NOT IN (SELECT ITEMCODE FROM INV_INVENTORYITEMMASTER WHERE SUBGROUPCODE IN('51','174','75','70','OTHI','SAS','MW','SJ','74','SDR'))"
            '    'gconnection.ExcuteStoreProcedure(sqlstring)

            '    sqlstring = " select * from stocksummary where itemcode in (select itemcode from consolidatestocksummary) AND  ( issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or Issqty<>'0' or receiveqty<>'0')"

            'End If

            'Me.Cursor = Cursors.WaitCursor
            'gconnection.getDataSet(sqlstring, "stocksummary")


            ''MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)


            'If gdataset.Tables("stocksummary").Rows.Count > 0 Then

            '    Dim dt As New DataTable
            '    Dim ds As New DataSet
            '    dt = gconnection.GetValues(sqlstring)
            '    dt.TableName = "stocksummary"
            '    ds.Tables.Add(dt)

            '    dt = gconnection.GetValues("SELECT PAYMENTMODE,SUM(AMOUNT) AS AMOUNT, SUM(TXAMT) AS TXAMT,SUM(STXAMT) AS STXAMT, SUM(TOTAMT) AS TOTAMT  FROM STKSUMMARY WHERE ISNULL(ISSQTY,0)>0 GROUP BY PAYMENTMODE")
            '    dt.TableName = "STKSUMMARY"
            '    ds.Tables.Add(dt)

            '    dt = gconnection.GetValues("select * from INV_STKSALEDET")
            '    dt.TableName = "INV_STKSALEDET"
            '    ds.Tables.Add(dt)



            '    If gShortname = "BGC" Then


            '        Dim textobj1 As TextObject
            '        textobj1 = R2.ReportDefinition.ReportObjects("Text12")
            '        textobj1.Text = MyCompanyName

            '        Dim textobj5 As TextObject
            '        textobj5 = R2.ReportDefinition.ReportObjects("Text15")
            '        textobj5.Text = UCase(Address1)
            '        Dim textobj6 As TextObject
            '        textobj6 = R2.ReportDefinition.ReportObjects("Text16")
            '        textobj6.Text = UCase(Address2) & " , " & UCase(gCity) & " , " & UCase(gState) & " - " & UCase(gPincode)
            '        'Dim textobj2 As TextObject
            '        'textobj2 = r.ReportDefinition.ReportObjects("Text13")
            '        'textobj2.Text = Trim(txt_mainstore.Text)
            '        Dim textobj22 As TextObject
            '        textobj22 = R2.ReportDefinition.ReportObjects("Text11")
            '        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

            '        Dim TXTOBJ3 As TextObject
            '        TXTOBJ3 = R2.ReportDefinition.ReportObjects("Text17")
            '        TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

            '        rViewer.GetDetails1(ds, R2)


            '        Dim II As Integer
            '        Dim Sql As String = "SELECT ISNULL(Storedesc,'') AS STOREDESC FROM StoreMaster WHERE  isnull(OPT,'')='Y'"
            '        'End If
            '        gconnection.getDataSet(Sql, "StoreMaster")
            '        If gdataset.Tables("StoreMaster").Rows.Count > 0 Then
            '            Sql = ""
            '            For II = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
            '                ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
            '                Sql = Sql & " " & Trim(gdataset.Tables("StoreMaster").Rows(II).Item("Storedesc")) & " ,"
            '            Next
            '        End If

            '        Sql = Mid(Sql, 1, Len(Sql) - 2)

            '        Dim Text8 As TextObject
            '        Text8 = R2.ReportDefinition.ReportObjects("Text8")
            '        Text8.Text = Sql



            '        rViewer.Show()
            '        Me.Cursor = Cursors.Default

            '    End If
            'End If



            Me.Cursor = Cursors.WaitCursor

            Dim bdate As String
            bdate = gconnection.getvalue("  SELECT Convert(varchar(11), bdate, 106) As bdate FROM Businessdate")

            sqlstring = "if exists(select * from sysobjects where name='TempRate') begin DROP TABLE TempRate end"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = " select * into TempRate from CLOSINGQTY"
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")

            sqlstring = "UPDATE CLOSINGQTY SET  RATE = ISNULL((SELECT TOP 1 RATE FROM TempRate B WHERE  B.ttype IN ('RECEIEVE','OPENNING','GRN')  AND CLOSINGQTY.storecode=B.STORECODE AND CLOSINGQTY.itemcode=B.itemcode AND CLOSINGQTY.AUTOID>B.Autoid ORDER BY B.Autoid DESC    ) ,0) WHERE  CLOSINGQTY.TTYPE IN ('KOT')  and closingqty.storecode in (select storecode from storemaster where isnull(OPT,'')='Y') and cast(trndate as date)>'" & bdate & "' "
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")

            sqlstring = " delete from stocksummary"
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY) "
            sqlstring = sqlstring & " select itemcode,ITEMNAME,storecode ,STOCKUOM ,'0','0','0' "
            sqlstring = sqlstring & " from INV_InventoryItemMaster  , storemaster  "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " where  isnull(OPT,'')='Y' and ITEMCODE IN ("
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
            sqlstring = sqlstring & " from inv_InventoryOpenningstock O inner join stocksummary on O.ITEMCODE=stocksummary.ITEMCODE  where O.storecode =stocksummary.storecode "
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


            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                ITEMNAME = Split(CheckedListBox1.CheckedItems(i), "- ")

            Next


            Dim machinename As String
            machinename = Environment.MachineName

            sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy  23:59:59") + "', '" & Trim(ITEMNAME(0)) + "','" & Trim(gUsername) & "','" & machinename & "'"
            gconnection.ExcuteStoreProcedure(sqlstring)


            sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode in (select distinct storecode from storemaster where isnull(OPT,'')='Y' ) and ttype IN('issue','ISSUE FROM') and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

            gconnection.dataOperation(6, sqlstring, )
            gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )



            sqlstring = "update stocksummary set     issqty=issqty*-1,dmgqty=dmgqty*-1,saleqty=saleqty*-1 "
            gconnection.dataOperation(6, sqlstring, )


            sqlstring = " select * from stocksummary where (openningqty<>'0'or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0')"

            Me.Cursor = Cursors.WaitCursor
            gconnection.getDataSet(sqlstring, "stocksummary")

            If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                If UCase(gShortname) = "BGC" Then

                    rViewer.ssql = sqlstring
                    rViewer.Report = R2
                    rViewer.TableName = "Stocksummary"
                    'Dim picture1 As PictureObject
                    'picture1 = r.ReportDefinition.ReportObjects("picture1")
                    'If (gShortname = "KOLKATA") Then
                    '    picture1.ObjectFormat.EnableSuppress = False
                    'Else
                    '    picture1.ObjectFormat.EnableSuppress = True

                    'End If
                    Dim textobj1 As TextObject
                    textobj1 = R2.ReportDefinition.ReportObjects("Text12")
                    textobj1.Text = MyCompanyName

                    Dim textobj5 As TextObject
                    textobj5 = R2.ReportDefinition.ReportObjects("Text15")
                    textobj5.Text = UCase(Address1)
                    Dim textobj6 As TextObject
                    textobj6 = R2.ReportDefinition.ReportObjects("Text16")
                    textobj6.Text = UCase(Address2)



                    Dim II As Integer
                    Dim Sql As String = "SELECT ISNULL(Storedesc,'') AS STOREDESC FROM StoreMaster WHERE isnull(OPT,'')='Y'  "
                    'End If
                    gconnection.getDataSet(Sql, "StoreMaster")
                    If gdataset.Tables("StoreMaster").Rows.Count > 0 Then
                        Sql = ""
                        For II = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
                            ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                            Sql = Sql & " " & Trim(gdataset.Tables("StoreMaster").Rows(II).Item("Storedesc")) & " ,"
                        Next
                    End If

                    Sql = Mid(Sql, 1, Len(Sql) - 2)

                    Dim textobj2 As TextObject
                    textobj2 = R2.ReportDefinition.ReportObjects("Text8")
                    textobj2.Text = Trim(Sql)

                    Dim textobj22 As TextObject
                    textobj22 = R2.ReportDefinition.ReportObjects("Text11")
                    textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = R2.ReportDefinition.ReportObjects("Text17")

                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " - " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""


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
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text12")
                    textobj1.Text = MyCompanyName

                    Dim textobj5 As TextObject
                    textobj5 = r.ReportDefinition.ReportObjects("Text15")
                    textobj5.Text = UCase(Address1)
                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text16")
                    textobj6.Text = UCase(Address2)



                    Dim II As Integer
                    Dim Sql As String = "SELECT ISNULL(Storedesc,'') AS STOREDESC FROM StoreMaster WHERE isnull(OPT,'')='Y'  "
                    'End If
                    gconnection.getDataSet(Sql, "StoreMaster")
                    If gdataset.Tables("StoreMaster").Rows.Count > 0 Then
                        Sql = ""
                        For II = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
                            ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                            Sql = Sql & " " & Trim(gdataset.Tables("StoreMaster").Rows(II).Item("Storedesc")) & " ,"
                        Next
                    End If

                    Sql = Mid(Sql, 1, Len(Sql) - 2)

                    Dim textobj2 As TextObject
                    textobj2 = r.ReportDefinition.ReportObjects("Text8")
                    textobj2.Text = Trim(Sql)

                    Dim textobj22 As TextObject
                    textobj22 = r.ReportDefinition.ReportObjects("Text11")
                    textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")

                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " - " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""


                End If



                rViewer.Show()
                Me.Cursor = Cursors.Default
            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            Me.Cursor = Cursors.Default
        End Try


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New Cryconsolidate
            Dim rViewer As New Viewer

            '   Me.Cursor = Cursors.WaitCursor

            sqlstring = " delete from consolidatestocksummary"
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            sqlstring = " insert into consolidatestocksummary(itemcode,ITEMNAME) "
            sqlstring = sqlstring & " select I.itemcode,I.ITEMNAME "
            sqlstring = sqlstring & " from  INV_InventoryItemMaster I  where  "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  I.ITEMCODE IN ("
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

            sqlstring = " exec CP_stockconsolidatesummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "'"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " select * from consolidatestocksummary "
            gconnection.getDataSet(sqlstring, "consolidatestocksummary")
            If (gdataset.Tables("consolidatestocksummary").Rows.Count > 0) Then
                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "CONSOLIDATE SUMMARY " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")



            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Issue Register"
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_View.Enabled = True
        Me.Cmd_Print.Enabled = True
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

    Private Sub CheckedListBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox2.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim search As New frmListSearch
            search.listbox = CheckedListBox2
            search.Text = "Category Search"
            search.ShowDialog(Me)
        End If

    End Sub

    Private Sub CheckedListBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox3.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim Advsearch As New frmListSearch
            Advsearch.listbox = CheckedListBox3
            Advsearch.Text = "Item Search"
            Advsearch.ShowDialog(Me)
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
        CheckedListBox1_SelectedIndexChanged(sender, e)
    End Sub




    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CHK_ACCOUNT_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_ACCOUNT.CheckedChanged
        FillGroupdetails()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class