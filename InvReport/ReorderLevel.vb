
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class ReorderLevel
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
                        If Controls(i_i).Name = "GroupBox1" Then
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
        sqlstring = "SELECT ISNULL(Groupcode,'') +' -> '+ ISNULL(Groupdesc,'') AS Groupdesc FROM InventoryGroupMaster  where Groupcode in (select groupcode from INV_INVENTORYITEMMASTER) ORDER BY Groupcode "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    CheckedListBox2.Items.Add(Trim(CStr(.Item("Groupdesc"))))
                End With
            Next
        End If
    End Sub
    Private Sub FillStore()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT ISNULL(STOREcode,'') + '- '+ ISNULL(STOREdesc,'') AS STOREdesc FROM STOREMASTER WHERE  isnull(freeze,'') <> 'Y' ORDER BY STOREdesc ASC"
        gconnection.getDataSet(Sqlstring, "STOREMASTER")
        CheckedListBox1.Items.Clear()
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                CheckedListBox1.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STOREdesc"))
            Next i
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


    Private Sub CheckedListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql, GROUPCODE() As String

        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' and I.GROUPCODE IN ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then

                GROUPCODE = Split(CheckedListBox2.CheckedItems(J), "->")

                ssql = ssql & " '" & Trim(GROUPCODE(0)) & "' "
            Else
                GROUPCODE = Split(CheckedListBox2.CheckedItems(J), "->")
                ssql = ssql & " '" & Trim(GROUPCODE(0)) & "', "
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

    Private Sub cmd_storecode_Click(sender As Object, e As EventArgs) Handles cmd_storecode.Click


        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
        M_WhereCondition = " where freeze <> 'Y'  AND STORESTATUS='M'"
        Dim vform As New ListOperattion1

        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "             STORE CODE                   |                   STORE DESCRIPTION                             "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        M_ORDERBY = ""
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Mainstorecode.Text = Trim(vform.keyfield & "")
            txt_Mainstore.Text = Trim(vform.keyfield1 & "")
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
                sqlstring = "SELECT * FROM storemaster WHERE storecode='" & Trim(txt_mainstorecode.Text) & "' AND STORESTATUS='M'"
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

    Private Sub InvIssueRegister_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F6) Then
            clearoperation()
        ElseIf (e.KeyCode = Keys.F9) Then
            Cmd_View_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F10) Then
            Cmd_Print_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F11) Then
            Cmd_Exit_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F12) Then
            ButExport_Click(sender, e)
        End If

    End Sub


    Private Sub InvIssueRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillStore()
        ' FillItemdetails()
        FillGroupdetails()
        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
            dtpfromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")

        ElseIf UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/01/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If

        Call CreateView()



        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub

    Private Sub CreateView()
        Dim Str As String

        Str = "Select * from sysobjects where name='Vw_Inv_clSTK' and xtype='V'"
        gconnection.getDataSet(Str, "VW_INV_IDENTBILL")
        If gdataset.Tables("VW_INV_IDENTBILL").Rows.Count > 0 Then

        Else
            Str = "CREATE view Vw_Inv_clSTK as  select * from closingqty where Autoid in (select max(Autoid) from closingqty group by itemcode,storecode)  "
            gconnection.dataOperation1(6, Str, "VW_INV_IDENTBILL")

        End If

        Str = "Select * from sysobjects where name='vw_INV_REORDER_LEVEL' and xtype='V'"
        gconnection.getDataSet(Str, "vw_INV_REORDER_LEVEL")
        If gdataset.Tables("vw_INV_REORDER_LEVEL").Rows.Count > 0 Then

        Else
            Str = " CREATE VIEW vw_INV_REORDER_LEVEL AS SELECT DISTINCT I.ITEMCODE,M.ITEMNAME,C.UOM,I.STORECODE,S.STOREDESC,REORDER,CLOSINGSTOCK,M.GROUPCODE,G.GROUPDESC FROM  INV_INVENTORYOPENNINGSTOCK I INNER JOIN Vw_Inv_clSTK C ON I.ITEMCODE=C.ITEMCODE AND I.STORECODE=C.STORECODE INNER JOIN INV_INVENTORYITEMMASTER M ON M.ITEMCODE=I.ITEMCODE INNER JOIN INVENTORYGROUPMASTER G ON G.GROUPCODE=M.GROUPCODE INNER JOIN STOREMASTER S ON S.STORECODE=I.STORECODE WHERE ISNULL(REORDER,0)<>0  AND C.CLOSINGSTOCK<=REORDER AND ISNULL(G.FREEZE,'')<>'Y' AND ISNULL(M.VOID,'')<>'Y' "
            gconnection.dataOperation1(6, Str, "vw_INV_REORDER_LEVEL")

        End If

        Str = "Select * from sysobjects where name='vw_INV_MINMAX' and xtype='V'"
        gconnection.getDataSet(Str, "vw_INV_MINMAX")
        If gdataset.Tables("vw_INV_MINMAX").Rows.Count > 0 Then

        Else
            Str = "  CREATE VIEW vw_INV_MINMAX AS SELECT DISTINCT I.ITEMCODE,M.ITEMNAME,I.UOM,I.STORECODE,S.STOREDESC,MINQTY,MAXQTY,M.GROUPCODE,G.GROUPDESC FROM  INV_INVENTORYOPENNINGSTOCK I INNER JOIN INV_INVENTORYITEMMASTER M ON M.ITEMCODE=I.ITEMCODE INNER JOIN INVENTORYGROUPMASTER G ON G.GROUPCODE=M.GROUPCODE INNER JOIN STOREMASTER S ON S.STORECODE=I.STORECODE WHERE  ISNULL(MAXQTY,0)<>0  AND ISNULL(G.FREEZE,'')<>'Y' AND ISNULL(M.VOID,'')<>'Y' "
            Str = "  union all"
            Str = "  SELECT DISTINCT I.ITEMCODE,M.ITEMNAME,I.UOM,I.STORECODE,S.STOREDESC,MINQTY,MAXQTY,M.GROUPCODE,G.GROUPDESC FROM  INV_INVENTORYOPENNINGSTOCK I INNER JOIN INV_INVENTORYITEMMASTER M ON M.ITEMCODE=I.ITEMCODE INNER JOIN INVENTORYGROUPMASTER G ON G.GROUPCODE=M.GROUPCODE INNER JOIN STOREMASTER S ON S.STORECODE=I.STORECODE WHERE  ISNULL(minqty,0)<>0  AND ISNULL(G.FREEZE,'')<>'Y' AND ISNULL(M.VOID,'')<>'Y'  "
            gconnection.dataOperation1(6, Str, "vw_INV_MINMAX")

        End If


    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Reorder Level Report"
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

    Sub clearoperation()
        ChkSupplier.Checked = False
        ChkItemCode.Checked = False
        ChkCategory.Checked = False
        txt_mainstore.Text = ""
        txt_mainstorecode.Text = ""
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()

    End Sub

    Private Sub VIEWISSUEREGISTERsUMMARY()
        Try

            Dim sqlstring, ITEMcode(), STORECODE(), Category(), sql As String
            Dim i As Integer
            Dim r As New CryIssueReportSummary
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor
            sqlstring = "exec cp_stockissue"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " SELECT * FROM TEMPSTOCKISSUEDETAIL "
            If CheckedListBox1.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE  isnull(VOID,'N')<> 'Y' and opstorelocationCODE IN ("
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                    sqlstring = sqlstring & " '" & Trim(STORECODE(0)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND ITEMCODE IN ("
                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMcode = Split(CheckedListBox3.CheckedItems(i), "-->")
                    sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),DOCDATE ,106) AS DATETIME) BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
            sqlstring = sqlstring & " AND STORELOCATIONCODE = '" & Trim(txt_mainstorecode.Text) & "' "
            'If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
            sqlstring = sqlstring & " order by itemname"
            'Else

            ' End If
            gconnection.getDataSet(sqlstring, "TEMPSTOCKISSUEDETAIL")
            If gdataset.Tables("TEMPSTOCKISSUEDETAIL").Rows.Count > 0 Then

                For i = 0 To CheckedListBox2.CheckedItems.Count - 1
                    ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                    sql = sql & " " & Trim(CheckedListBox2.CheckedItems(i)) & ", "
                Next
                sql = Mid(sql, 1, Len(sql) - 2)

                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "TEMPSTOCKISSUEDETAIL"
                'COMPANY NAME
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                'ADDRESS
                Dim textobj5 As TextObject
                textobj5 = r.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                'STORE
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text13")
                textobj2.Text = Trim(txt_mainstore.Text)
                'PERIOD
                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                'financial
                Dim TXTOBJ63 As TextObject

                TXTOBJ63 = r.ReportDefinition.ReportObjects("Text10")
                TXTOBJ63.Text = gFinancalyearStart + " to " + gFinancialyearEnd


                Dim TXTOBJ22 As TextObject

                TXTOBJ22 = r.ReportDefinition.ReportObjects("Text22")
                TXTOBJ22.Text = sql

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
    Private Sub VIEWEXPIRY()
        Try

            Dim sqlstring, ITEMcode(), STORECODE() As String
            Dim i As Integer
            Dim r As New CryExpiryReport
            Dim rViewer As New Viewer



            sqlstring = " SELECT * FROM VIEW_EXPIRYREPORT "
            gconnection.getDataSet(sqlstring, "VIEW_EXPIRYREPORT")
            If gdataset.Tables("VIEW_EXPIRYREPORT").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VIEW_EXPIRYREPORT"
                'COMPANY NAME
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                'ADDRESS
                Dim textobj5 As TextObject
                textobj5 = r.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                'STORE
                'Dim textobj2 As TextObject
                'textobj2 = r.ReportDefinition.ReportObjects("Text13")
                'textobj2.Text = Trim(txt_mainstore.Text)
                'PERIOD
                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                'financial
                Dim TXTOBJ63 As TextObject

                TXTOBJ63 = r.ReportDefinition.ReportObjects("Text10")
                TXTOBJ63.Text = gFinancalyearStart + " to " + gFinancialyearEnd

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
    Private Sub VIEWMINMAX()
        Try

            Dim sqlstring, ITEMcode(), STORECODE() As String
            Dim i As Integer
            Dim r As New CryMinMaxReport
            Dim rViewer As New Viewer



            sqlstring = " SELECT * FROM vw_INV_MINMAX "
            If CheckedListBox1.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE STORECODE IN ("
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                    sqlstring = sqlstring & " '" & Trim(STORECODE(0)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND ITEMCODE IN ("
                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMcode = Split(CheckedListBox3.CheckedItems(i), "-->")
                    sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            gconnection.getDataSet(sqlstring, "vw_INV_MINMAX")
            If gdataset.Tables("vw_INV_MINMAX").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "vw_INV_MINMAX"
                'COMPANY NAME
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                'ADDRESS
                Dim textobj5 As TextObject
                textobj5 = r.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                'STORE
                'Dim textobj2 As TextObject
                'textobj2 = r.ReportDefinition.ReportObjects("Text13")
                'textobj2.Text = Trim(txt_mainstore.Text)
                'PERIOD
                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                'financial
                Dim TXTOBJ63 As TextObject

                TXTOBJ63 = r.ReportDefinition.ReportObjects("Text10")
                TXTOBJ63.Text = gFinancalyearStart + " to " + gFinancialyearEnd

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

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click


        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        If CHK_MINMAXQTY.Checked = True Then
            VIEWMINMAX()
        ElseIf Chk_expiryReport.Checked = True Then
            VIEWEXPIRY()
        Else
            VIEWISSUEREGISTER()
        End If




    End Sub

    Private Sub Excel_export()

        Try
            Dim sqlstring, ITEMcode(), STORECODE() As String
            Dim i As Integer
            'Dim r As New CryIssueReport
            'Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor
            ' exec cp_INV_STOREWISEISSUE 'MNS', '05/Apr/2017','30/Apr/2017  23:59:59','01/Apr/2017'

            sqlstring = " exec cp_INV_STOREWISEISSUE '" + txt_mainstorecode.Text + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy  23:59:59") + "', '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "'"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "  select * from ISSUESUMMARY "

            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " where ITEMCODE IN ("
                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMcode = Split(CheckedListBox3.CheckedItems(i), "-->")
                    sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " order by itemcode"

            gconnection.getDataSet(sqlstring, "ISSUEREGISTER")
            If gdataset.Tables("ISSUEREGISTER").Rows.Count > 0 Then

                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "Stock Issue " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If


            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub
    Private Sub VIEWISSUEREGISTER()
        Try

            Dim sqlstring, ITEMcode(), STORECODE() As String
            Dim i As Integer
            Dim r As New CryREorderReport
            Dim rViewer As New Viewer


            
            sqlstring = " SELECT * FROM vw_INV_REORDER_LEVEL "
            If CheckedListBox1.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE STORECODE IN ("
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                    sqlstring = sqlstring & " '" & Trim(STORECODE(0)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND ITEMCODE IN ("
                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMcode = Split(CheckedListBox3.CheckedItems(i), "-->")
                    sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
           
            gconnection.getDataSet(sqlstring, "vw_INV_REORDER_LEVEL")
            If gdataset.Tables("vw_INV_REORDER_LEVEL").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "vw_INV_REORDER_LEVEL"
                'COMPANY NAME
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                'ADDRESS
                Dim textobj5 As TextObject
                textobj5 = r.ReportDefinition.ReportObjects("Text15")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text16")
                textobj6.Text = UCase(Address2)
                'STORE
                'Dim textobj2 As TextObject
                'textobj2 = r.ReportDefinition.ReportObjects("Text13")
                'textobj2.Text = Trim(txt_mainstore.Text)
                'PERIOD
                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                'financial
                Dim TXTOBJ63 As TextObject

                TXTOBJ63 = r.ReportDefinition.ReportObjects("Text10")
                TXTOBJ63.Text = gFinancalyearStart + " to " + gFinancialyearEnd

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
    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        VIEWISSUEREGISTER()

        'Else
        '    MessageBox.Show("Select Purchase Summary or Detail Option", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub

        'End If

    End Sub


    Private Sub ButExport_Click(sender As Object, e As EventArgs) Handles ButExport.Click
        Try
            Dim sqlstring, ITEMcode(), STORECODE() As String
            Dim i As Integer
            'Dim r As New CryIssueReport
            'Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor
            sqlstring = "exec cp_stockissue"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " SELECT Docdetails,	Docdate,	IndentNo,	storelocationcode,	storelocationname,	opstorelocationname,	opstorelocationcode,	Itemcode,	Itemname,	UoM,	ind_qty,	qty,	BATCHNO,	rate,	AMOUNT FROM TEMPSTOCKISSUEDETAIL "
            If CheckedListBox1.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE opstorelocationCODE IN ("
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                    sqlstring = sqlstring & " '" & Trim(STORECODE(0)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND ITEMCODE IN ("
                For i = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMcode = Split(CheckedListBox3.CheckedItems(i), "-->")
                    sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND DOCDATE BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
            sqlstring = sqlstring & " AND STORELOCATIONCODE = '" & Trim(txt_mainstorecode.Text) & "' "
            gconnection.getDataSet(sqlstring, "ISSUEREGISTER")
            If gdataset.Tables("ISSUEREGISTER").Rows.Count > 0 Then

                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "Stock Issue " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If


            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class