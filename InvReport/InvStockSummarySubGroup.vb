Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class InvStockSummarySubGroup
    Dim gconnection As New GlobalClass
    Dim sqlstring, SQL As String
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
        sqlstring = "SELECT DISTINCT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME FROM INV_InventoryItemMaster WHERE ISNULL(VOID,'')<>'Y' ORDER BY ITEMCODE "
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
        sqlstring = "SELECT ISNULL(Groupcode,'') AS Groupcode,ISNULL(Groupdesc,'') AS Groupdesc FROM InventoryGroupMaster  where Groupcode in (select Groupcode from INV_INVENTORYITEMMASTER) ORDER BY CATEGORYCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    Chklist_Groupdesc.Items.Add(Trim(CStr(.Item("Groupcode"))) & "-->" & Trim(CStr(.Item("Groupdesc"))))
                End With
            Next
        End If
    End Sub
    Private Sub FillCategorydetails()
        Dim i As Integer
        Dim sqlstring As String
        CHKLIST_CATEGORY.Items.Clear()
        sqlstring = "SELECT ISNULL(categorycode,'') AS categorycode,ISNULL(categorydesc,'') AS categorydesc FROM inventorycategorymaster  where categorycode in (select category from INV_INVENTORYITEMMASTER) and isnull(freeze,'') <> 'Y'  ORDER BY CATEGORYCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYcategoryMASTER")
        If gdataset.Tables("INVENTORYcategoryMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYcategoryMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYcategoryMASTER").Rows(i)
                    CHKLIST_CATEGORY.Items.Add(Trim(CStr(.Item("categorycode"))) & "-->" & Trim(CStr(.Item("categorydesc"))))
                End With
            Next
        End If
    End Sub
    Private Function FillGroupdetailsKGA(ByVal STORECODE As String)
        Dim i As Integer
        Dim sqlstring As String
        Chklist_Groupdesc.Items.Clear()
        sqlstring = "select   storecode,S.groupcode,GROUPDESC from inv_InventoryOpenningstock i inner join INV_InventoryItemMaster s  on i.itemcode=s.itemcode INNER JOIN InventoryGroupMaster G ON S.GROUPCODE=G.GROUPCODE  WHERE STORECODE='" & STORECODE & "'  group by storecode,S.groupcode,GROUPDESC "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    Chklist_Groupdesc.Items.Add(Trim(CStr(.Item("Groupcode"))) & "-->" & Trim(CStr(.Item("Groupdesc"))))
                End With
            Next
        End If
    End Function




    Private Sub InvStockSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        FillCategorydetails()
        ' FillItemdetails()
        'FillGroupdetails()
        FillStore()

        If UCase(gShortname) = "BBSR" Then
            CkExices.Visible = False
        Else
            CkExices.Visible = False
        End If
        If GBATCHNO = "Y" Then
            Chk_BatchWise.Visible = True
        Else
            Chk_BatchWise.Visible = False
        End If

        If UCase(gShortname) = "BGC" Then
            CHK_SUM.Visible = True
        Else
            CHK_SUM.Visible = False
        End If

        If UCase(gShortname) = "NIZAM" Or UCase(gShortname) = "KBA" Then
            Ck_Rec_Iss.Visible = True
            Ck_Rec_Iss.Checked = True
        Else
            Ck_Rec_Iss.Visible = False
        End If
        ' Commented by SRI On 05.09.2020 Because this Option is Necessary for All
        'If UCase(gShortname) = "KBA" Or UCase(gShortname) = "BGC" Or UCase(gShortname) = "RSP" Then
        '    chksummary.Visible = True
        '    chksummary.Checked = True
        'Else
        '    chksummary.Visible = False
        'End If
        If UCase(gShortname) = "DC" Or UCase(gShortname) = "MLRF" Or UCase(gShortname) = "RSP" Or UCase(gShortname) = "BGC" Then
            ChBZero.Visible = True
        Else
            ChBZero.Visible = False
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

        SQL = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'stocksummary' AND  COLUMN_NAME = 'Subgroupcode') Begin alter table stocksummary add  Subgroupcode VARCHAR(20) End"
        gconnection.dataOperation(6, SQL, "AddC")

        SQL = "IF NOT EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'stocksummary' AND  COLUMN_NAME = 'Subgroupdesc') Begin alter table stocksummary add  Subgroupdesc VARCHAR(100) End"
        gconnection.dataOperation(6, SQL, "AddC")

        If UCase(gShortname) = "KSCA" Then
            chksummary.Checked = False
            CKboxWOV.Checked = False
            CHK_ONLYSALE.Visible = True
            CHK_ONLYSALE.Checked = True
            GroupBox5.Visible = True
        End If


        'chksummary.Checked = False
        'CheckBox2.Checked = False
        'CHK_ONLYSALE.Visible = True
        'CHK_ONLYSALE.Checked = True
        GroupBox6.Visible = True


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
        CheckBox2.Checked = False

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
        For i = 0 To CHKLIST_CATEGORY.Items.Count - 1
            CHKLIST_CATEGORY.SetItemChecked(i, False)
        Next
        Chklist_Groupdesc.Items.Clear()
        CheckedListBox3.Items.Clear()
        CheckedListBox2.Items.Clear()

        'CHKLIST_CATEGORY.Items.Clear()
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
            ' Call FillGroupdetailsKGA(txt_mainstorecode.Text)
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
                    Call FillGroupdetailsKGA(txt_mainstorecode.Text)
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
        Dim sqlstring, ssql, groupcode() As String
        ssql = ""
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I  inner join inv_inventoryopenningstock o on o.itemcode=i.itemcode  and o.storecode='" & txt_mainstorecode.Text & "'"
        sqlstring = sqlstring & " WHERE isnull(I.VOID,'') <> 'Y' "

        'For J = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        '    If J = Chklist_Groupdesc.CheckedItems.Count - 1 Then
        '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "' "
        '    Else
        '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "', "
        '    End If
        'Next

     


        If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "  and i.GROUPCODE IN ("
            For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                groupcode = Split(Chklist_Groupdesc.CheckedItems(i), "-->")
                sqlstring = sqlstring & " '" & Trim(groupcode(0)) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        'If CheckedListBox2.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & "  and I.Subgroupcode IN ("
        '    For i = 0 To CheckedListBox2.CheckedItems.Count - 1
        '        groupcode = Split(CheckedListBox2.CheckedItems(i), "-->")
        '        sqlstring = sqlstring & " '" & Trim(groupcode(0)) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'End If

        If Chklist_Groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & " ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INV_INVENTORYITEMMASTER")
            If gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0 Then
                CheckedListBox3.Items.Clear()
                For i = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
                    With gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i)
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
    Private Sub batchwise_report()
        Try
            Dim sqlstring, ExicesUOM, CATEGORY(), ITEMNAME() As String
            Dim i As Integer
            Dim R2 As New RPT_STOCKSUMMARYSGRPWISE
            Dim r As New CrystocksummarySubGroup_KBA
            Dim rViewer As New Viewer
            If txt_mainstorecode.Text <> "" Then
            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim bdate As String
            bdate = gconnection.getvalue("  SELECT Convert(varchar(11), bdate, 106) As bdate FROM Businessdate")
            Me.Cursor = Cursors.WaitCursor
            sqlstring = "if exists(select * from sysobjects where name='TempRate') begin DROP TABLE TempRate end"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " select * into TempRate from CLOSINGQTY"
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")
            sqlstring = "UPDATE CLOSINGQTY SET  RATE = (SELECT TOP 1 RATE FROM TempRate B WHERE  B.ttype IN ('RECEIEVE','OPENNING','GRN')  AND CLOSINGQTY.storecode=B.STORECODE AND CLOSINGQTY.itemcode=B.itemcode AND CLOSINGQTY.AUTOID>B.Autoid ORDER BY B.Autoid DESC    )  WHERE  CLOSINGQTY.TTYPE IN ('KOT')  and closingqty.storecode='" + txt_mainstorecode.Text + "' and cast(trndate as date)>'" & bdate & "' "
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")
            sqlstring = " delete from stocksummary"
            gconnection.dataOperation(6, sqlstring, "stocksummary")

            '' Added by Sri for Batch Wise Report
            If GBATCHNO = "Y" Then
                sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY) "
                sqlstring = sqlstring & " select i.itemcode,i.ITEMNAME,'" + txt_mainstorecode.Text + "',STOCKUOM ,'0','0','0' "
                sqlstring = sqlstring & " from INV_InventoryItemMaster i where  "
                If CheckedListBox3.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & "  i.ITEMCODE IN ("
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
            Else
                sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY) "
                sqlstring = sqlstring & " Select itemcode,ITEMNAME,'" + txt_mainstorecode.Text + "',STOCKUOM ,'0','0','0' "
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

            End If
            ''End
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            sqlstring = " update stocksummary set uom=O.uom,opstk=O.openningqty,OPENNINGQTY=O.openningqty"
            ' sqlstring = sqlstring & " select O.itemcode,I.ITEMNAME,storecode, "
            sqlstring = sqlstring & " from inv_InventoryOpenningstock O inner join stocksummary on O.ITEMCODE=stocksummary.ITEMCODE  where O.storecode ='" + txt_mainstorecode.Text + "' "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  AND stocksummary.ITEMCODE  IN ("
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
                sqlstring = " exec CP_stocksummary_NEWBATCH  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "','" + Format(DTPaSondATE.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
            Else
                sqlstring = " exec CP_stocksummary_NEWBATCH  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "'"
            End If
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " update stocksummary set stocksummary.groupcode=i.groupcode, stocksummary.groupdesc=g.Groupdesc  from INV_InventoryItemMaster I  inner join stocksummary on i.ITEMCODE=stocksummary.ITEMCODE  inner join inventorygroupmaster g on i.groupcode=g.Groupcode"
            gconnection.dataOperation(6, sqlstring, "ratelist")
            SQL = "if exists(select * from sysobjects where name='Items') begin DROP TABLE Items end"
            gconnection.dataOperation(6, SQL, )

                SQL = " select i.itemcode,i.storecode, i.reportUOM,i.reportdecimaluom,s.uom ,cast(null as numeric(18,6)) as  Conv1 ,cast(null as numeric(18,6)) as Conv2 into Items  from stocksummary s inner join inv_Inventoryuomstorelink i on s.itemcode=i.itemcode and s.storecode=i.storecode "
                gconnection.dataOperation(6, SQL, )

                SQL = " update Items set Conv1= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportUOM=TRANSUOM "
                gconnection.dataOperation(6, SQL, )

                SQL = " update Items set Conv2= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportdecimaluom=TRANSUOM "
                gconnection.dataOperation(6, SQL, )
                sqlstring = " select reportUOM,uom from Items where Conv1 is null "
                gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
            'If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
            '    Dim stockuom As String = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("uom"))
            '    ExicesUOM = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("reportUOM"))
            '    If MsgBox("DO U Want to Make Conversion factor between " & ExicesUOM & " and " & stockuom & " ! ", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, gCompanyname) = MsgBoxResult.Ok Then
            '        Me.Cursor = Cursors.WaitCursor

            '        Dim uomr As New FrmUOMRelation
            '        uomr.baseuom = stockuom
            '        uomr.transuom = ExicesUOM
            '        uomr.ShowDialog()
            '        Me.Cursor = Cursors.Default
            '        Exit Sub

            '    Else
            '        Me.Cursor = Cursors.Default
            '        Exit Sub
            '    End If
            'End If
            sqlstring = " select reportdecimaluom,uom from Items where Conv2 is null "
                gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
            'If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
            '    Dim stockuom As String = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("uom"))
            '    ExicesUOM = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("reportdecimaluom"))
            '    If MsgBox("DO U Want to Make Conversion factor between " & ExicesUOM & " and " & stockuom & " ! ", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, gCompanyname) = MsgBoxResult.Ok Then
            '        Me.Cursor = Cursors.WaitCursor

            '        Dim uomr As New FrmUOMRelation
            '        uomr.baseuom = stockuom
            '        uomr.transuom = ExicesUOM
            '        uomr.ShowDialog()
            '        Me.Cursor = Cursors.Default
            '        Exit Sub

            '    Else
            '        Me.Cursor = Cursors.Default
            '        Exit Sub
            '    End If
            'End If
            sqlstring = " select reportUOM,reportdecimaluom from Items where reportUOM+reportdecimaluom NOT IN  ( select BASEUOM+transUOM from INVENTORY_TRANSCONVERSION where ISNULL(freeze,'')<>'Y') "
                gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
            'If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
            '    Dim stockuom As String = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("reportUOM"))
            '    ExicesUOM = Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("reportdecimaluom"))
            '    If MsgBox("DO U Want to Make Conversion factor between " & ExicesUOM & " and " & stockuom & " ! ", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, gCompanyname) = MsgBoxResult.Ok Then
            '        Me.Cursor = Cursors.WaitCursor
            '        Dim uomr As New FrmUOMRelation
            '        uomr.baseuom = stockuom
            '        uomr.transuom = ExicesUOM
            '        uomr.ShowDialog()
            '        Me.Cursor = Cursors.Default
            '        Exit Sub
            '    Else
            '        Me.Cursor = Cursors.Default
            '        Exit Sub
            '    End If
            'End If
            SQL = " update stocksummary set uom=reportUOM, oprate = oprate/Conv1,clrate = clrate/Conv1 ,opstk= opstk*CONV1  ,Openningqty= Openningqty*Conv1 ,receiveqty=receiveqty* CONV1 ,Issqty=Issqty * CONV1,SALEQTY=SALEQTY*Conv1,DMGQTY=DMGQTY*Conv1,closingqty=closingqty*Conv1,ADJQTY=ADJQTY*Conv1 from stocksummary s inner join Items u on s.Itemcode=u.itemcode and  s.Uom=u.uom "
                gconnection.dataOperation(6, SQL, )
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('issue','issue from') and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                    gconnection.dataOperation(6, sqlstring, )
                Else
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*(rate/CONVVALUE))/ (sum(qty)) from closingqty inner join INVENTORY_TRANSCONVERSION  t on closingqty.Uom=t.BASEUOM and stocksummary.uom=TRANSUOM where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                gconnection.dataOperation(6, sqlstring, )
            End If
            'gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )

            'sqlstring = "update stocksummary set     issqty=issqty*-1,dmgqty=dmgqty*-1,saleqty=saleqty*-1 "
            'gconnection.dataOperation(6, sqlstring, )

            sqlstring = "UPDATE stocksummary SET Subgroupcode = G.Subgroupcode ,Subgroupdesc=G.Subgroupdesc FROM stocksummary S , INV_INVENTORYITEMMASTER I , InventorySubGroupMaster G WHERE S.itemcode=I.itemcode AND I.subGroupcode=G.Subgroupcode "
            gconnection.dataOperation(6, sqlstring, )

            sqlstring = " select * from stocksummary where ( OPENNINGQTY<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0')"
            sqlstring = sqlstring & " order by itemcode,batchno "
            gconnection.getDataSet(sqlstring, "stocksummary")

            Me.Cursor = Cursors.WaitCursor
            Dim r1
            r1 = New CrystocksummaryBatchwise
            If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r1
                rViewer.TableName = "Stocksummary"
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
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                    TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")
                    Dim textobj29 As TextObject
                    textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                    textobj29.Text = "DATE :"
                Else
                    TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                End If
                rViewer.Show()
                Me.Cursor = Cursors.Default
            Else
                Me.Cursor = Cursors.Default
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ExicesReport_bbsr()
        Try
            Dim sqlstring, CATEGORY(), ITEMNAME(), ExicesUOM As String
            Dim i As Integer

            Dim CL As New CryExicesReport
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


            sqlstring = "select distinct stockuom from INV_InventoryItemMaster where   selectYN='Y' and isnull(void,'')<>'Y' and stockuom+'" & ExicesUOM & "' not in ( select BASEUOM+transUOM from INVENTORY_TRANSCONVERSION where ISNULL(freeze,'')<>'Y') "
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
    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub

        If gShortname = "HGA" Then
            sqlstring = "exec  passinvntoryunmatchedentries"
            gconnection.ExcuteStoreProcedure(sqlstring)
        End If

        If CkExices.Checked = True Then
            Call ExicesReport_bbsr()
        ElseIf Chk_BatchWise.Checked = True Then
            Call batchwise_report()
        ElseIf gShortname = "NIZAM" Then
            VIEWSTOCKSUMMARY_NIZ()

        ElseIf CKboxWOV.Checked = True And gShortname = "KSCA" Then
            VIEWSTOCKSUMMARY_KSCA()
        ElseIf CHK_ONLYSALE.Checked = True And gShortname = "KSCA" Then
            VIEWSTOCKSUMMARY_KSCA_ONLYSALE()
        Else
            VIEWSTOCKSUMMARY()
        End If


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
    Private Sub VIEWSTOCKSUMMARY_KSCA()
        Try
            Dim sqlstring, ExicesUOM, CATEGORY(), ITEMNAME(), storecode() As String
            Dim i, s As Integer
            Dim rViewer As New Viewer
            If txt_mainstorecode.Text <> "" Then
            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            sqlstring = "if exists(select * from sysobjects where name='TempRate') begin DROP TABLE TempRate end"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " select * into TempRate from CLOSINGQTY"
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")
            sqlstring = " delete from stocksummary"
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            If CheckedListBox1.CheckedItems.Count <> 0 Then
                For s = 0 To CheckedListBox1.CheckedItems.Count - 1
                    storecode = Split(CheckedListBox1.CheckedItems(s), "-")
                    sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY) "
                    sqlstring = sqlstring & " select itemcode,ITEMNAME,'" & Trim(storecode(0)) & "',STOCKUOM ,'0','0','0' "
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
                    sqlstring = sqlstring & " from inv_InventoryOpenningstock O inner join stocksummary on O.ITEMCODE=stocksummary.ITEMCODE   where o.storecode=stocksummary.storecode "
                    If CheckedListBox3.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND stocksummary.ITEMCODE  IN ("
                        For o As Integer = 0 To CheckedListBox3.CheckedItems.Count - 1
                            ITEMNAME = Split(CheckedListBox3.CheckedItems(o), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    gconnection.dataOperation(6, sqlstring, "stocksummary")
                    sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" & Trim(storecode(0)) & "'"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                    sqlstring = " update stocksummary set stocksummary.groupcode=i.groupcode, stocksummary.groupdesc=g.Groupdesc  from INV_InventoryItemMaster I  inner join stocksummary on i.ITEMCODE=stocksummary.ITEMCODE  inner join inventorygroupmaster g on i.groupcode=g.Groupcode"
                    gconnection.dataOperation(6, sqlstring, "ratelist")
                    SQL = "if exists(select * from sysobjects where name='Items') begin DROP TABLE Items end"
                    gconnection.dataOperation(6, SQL, )
                    SQL = " select i.itemcode,i.storecode, i.reportUOM,i.reportdecimaluom,s.uom ,cast(null as numeric(18,6)) as  Conv1 ,cast(null as numeric(18,6)) as Conv2 into Items  from stocksummary s inner join inv_Inventoryuomstorelink i on s.itemcode=i.itemcode and s.storecode=i.storecode "
                    gconnection.dataOperation(6, SQL, )


                    SQL = " update Items set Conv1= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportUOM=TRANSUOM "
                        gconnection.dataOperation(6, SQL, )



                    SQL = " update Items set Conv2= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportdecimaluom=TRANSUOM "
                    gconnection.dataOperation(6, SQL, )

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

                    SQL = " update stocksummary set uom=reportUOM, oprate = oprate/Conv1,clrate = clrate/Conv1 ,opstk= opstk*CONV1  ,Openningqty= Openningqty*Conv1 ,receiveqty=receiveqty* CONV1 ,Issqty=Issqty * CONV1,SALEQTY=SALEQTY*Conv1,DMGQTY=DMGQTY*Conv1,closingqty=closingqty*Conv1,ADJQTY=ADJQTY*Conv1 from stocksummary s inner join Items u on s.Itemcode=u.itemcode and  s.Uom=u.uom and s.storecode ='" & Trim(storecode(0)) & "'  "
                        gconnection.dataOperation(6, SQL, )

                    If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                        sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & Trim(storecode(0)) & "' and ttype in('issue','issue from') and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                        gconnection.dataOperation(6, sqlstring, )
                    Else
                        sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*(rate/CONVVALUE))/ (sum(qty)) from closingqty inner join INVENTORY_TRANSCONVERSION  t on closingqty.Uom=t.BASEUOM and stocksummary.uom=TRANSUOM where itemcode=stocksummary.itemcode and storecode='" & Trim(storecode(0)) & "' and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                        gconnection.dataOperation(6, sqlstring, )
                    End If
                    gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )
                    sqlstring = "update stocksummary set     issqty=issqty*-1,dmgqty=dmgqty*-1,saleqty=saleqty*-1 where storecode ='" & Trim(storecode(0)) & "'"
                    gconnection.dataOperation(6, sqlstring, )
                    sqlstring = "UPDATE stocksummary SET Subgroupcode = G.Subgroupcode ,Subgroupdesc=G.Subgroupdesc FROM stocksummary S , INV_INVENTORYITEMMASTER I , InventorySubGroupMaster G WHERE S.itemcode=I.itemcode AND I.subGroupcode=G.Subgroupcode "
                    gconnection.dataOperation(6, sqlstring, )

                    'sqlstring = " select * from stocksummary where (opstk<>0 or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0')"
                    'sqlstring = sqlstring & " order by itemcode "

                    sqlstring = " SELECT ISNULL(SUM(OPENNINGQTY),0) AS OPENNINGQTY,ISNULL(SUM(ISSQTY),0) AS ISSQTY,ISNULL(SUM(SALEQTY),0)AS SALEQTY,ISNULL(SUM(RECEIVEQTY),0)AS RECEIVEQTY,ISNULL(SUM(CLOSINGQTY),0) AS CLOSINGQTY,ISNULL(SUM(DMGQTY),0)AS DMGQTY,ISNULL(SUM(ADJQTY),0)AS ADJQTY,ISNULL(CLRATE,0) AS CLRATE,ITEMCODE,ITEMNAME,UOM,Subgroupdesc FROM STOCKSUMMARY where (opstk<>0 or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') "
                    sqlstring = sqlstring & " GROUP BY ITEMCODE,ITEMNAME,UOM,Subgroupdesc,clrate "
                    sqlstring = sqlstring & " order by itemcode "
                    gconnection.getDataSet(sqlstring, "stocksummary")
                    Me.Cursor = Cursors.WaitCursor
                Next
            Else
                MessageBox.Show("Select the Store Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If CKboxWOV.Checked = True Then
                Dim r1 = New CrystocksummaryStockOnly_KSCA
                If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r1
                    rViewer.TableName = "Stocksummary"
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
                    If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                        TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")
                        Dim textobj29 As TextObject
                        textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                        textobj29.Text = "DATE :"
                    Else
                        TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                    End If
                    Dim TXTOBJ99 As TextObject
                    TXTOBJ99 = r1.ReportDefinition.ReportObjects("Text22")
                    TXTOBJ99.Text = Format(dtpfromdate.Value, "dd/MM/yyyy")

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
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
    Private Sub VIEWSTOCKSUMMARY_KSCA_ONLYSALE()
        Try
            Dim sqlstring, ExicesUOM, CATEGORY(), ITEMNAME(), storecode() As String
            Dim i, s As Integer
            Dim rViewer As New Viewer
            If txt_mainstorecode.Text <> "" Then
            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            sqlstring = "if exists(select * from sysobjects where name='TempRate') begin DROP TABLE TempRate end"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " select * into TempRate from CLOSINGQTY"
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")
            sqlstring = " delete from stocksummary"
            gconnection.dataOperation(6, sqlstring, "stocksummary")
            If CheckedListBox1.CheckedItems.Count <> 0 Then
                For s = 0 To CheckedListBox1.CheckedItems.Count - 1
                    storecode = Split(CheckedListBox1.CheckedItems(s), "-")
                    sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY) "
                    sqlstring = sqlstring & " select itemcode,ITEMNAME,'" & Trim(storecode(0)) & "',STOCKUOM ,'0','0','0' "
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
                    sqlstring = sqlstring & " from inv_InventoryOpenningstock O inner join stocksummary on O.ITEMCODE=stocksummary.ITEMCODE   where o.storecode=stocksummary.storecode "
                    If CheckedListBox3.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND stocksummary.ITEMCODE  IN ("
                        For o As Integer = 0 To CheckedListBox3.CheckedItems.Count - 1
                            ITEMNAME = Split(CheckedListBox3.CheckedItems(o), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    gconnection.dataOperation(6, sqlstring, "stocksummary")
                    sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" & Trim(storecode(0)) & "'"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                    sqlstring = " update stocksummary set stocksummary.groupcode=i.groupcode, stocksummary.groupdesc=g.Groupdesc  from INV_InventoryItemMaster I  inner join stocksummary on i.ITEMCODE=stocksummary.ITEMCODE  inner join inventorygroupmaster g on i.groupcode=g.Groupcode"
                    gconnection.dataOperation(6, sqlstring, "ratelist")
                    SQL = "if exists(select * from sysobjects where name='Items') begin DROP TABLE Items end"
                    gconnection.dataOperation(6, SQL, )
                    SQL = " select i.itemcode,i.storecode, i.reportUOM,i.reportdecimaluom,s.uom ,cast(null as numeric(18,6)) as  Conv1 ,cast(null as numeric(18,6)) as Conv2 into Items  from stocksummary s inner join inv_Inventoryuomstorelink i on s.itemcode=i.itemcode and s.storecode=i.storecode "
                    gconnection.dataOperation(6, SQL, )

                    SQL = " update Items set Conv1= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportUOM=TRANSUOM "
                    gconnection.dataOperation(6, SQL, )

                    SQL = " update Items set Conv2= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportdecimaluom=TRANSUOM "
                    gconnection.dataOperation(6, SQL, )

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
                    SQL = " update stocksummary set uom=reportUOM, oprate = oprate/Conv1,clrate = clrate/Conv1 ,opstk= opstk*CONV1  ,Openningqty= Openningqty*Conv1 ,receiveqty=receiveqty* CONV1 ,Issqty=Issqty * CONV1,SALEQTY=SALEQTY*Conv1,DMGQTY=DMGQTY*Conv1,closingqty=closingqty*Conv1,ADJQTY=ADJQTY*Conv1 from stocksummary s inner join Items u on s.Itemcode=u.itemcode and  s.Uom=u.uom and s.storecode ='" & Trim(storecode(0)) & "'  "
                    gconnection.dataOperation(6, SQL, )
                    If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                        sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & Trim(storecode(0)) & "' and ttype in('issue','issue from') and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                        gconnection.dataOperation(6, sqlstring, )
                    Else
                        sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*(rate/CONVVALUE))/ (sum(qty)) from closingqty inner join INVENTORY_TRANSCONVERSION  t on closingqty.Uom=t.BASEUOM and stocksummary.uom=TRANSUOM where itemcode=stocksummary.itemcode and storecode='" & Trim(storecode(0)) & "' and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                        gconnection.dataOperation(6, sqlstring, )
                    End If
                    gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )
                    sqlstring = "update stocksummary set     issqty=issqty*-1,dmgqty=dmgqty*-1,saleqty=saleqty*-1 where storecode ='" & Trim(storecode(0)) & "'"
                    gconnection.dataOperation(6, sqlstring, )
                    sqlstring = "UPDATE stocksummary SET Subgroupcode = G.Subgroupcode ,Subgroupdesc=G.Subgroupdesc FROM stocksummary S , INV_INVENTORYITEMMASTER I , InventorySubGroupMaster G WHERE S.itemcode=I.itemcode AND I.subGroupcode=G.Subgroupcode "
                    gconnection.dataOperation(6, sqlstring, )

                    'sqlstring = " select * from stocksummary where (opstk<>0 or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0')"
                    'sqlstring = sqlstring & " order by itemcode "

                    sqlstring = " SELECT ISNULL(SUM(OPENNINGQTY),0) AS OPENNINGQTY,ISNULL(SUM(ISSQTY),0) AS ISSQTY,ISNULL(SUM(SALEQTY),0)AS SALEQTY,ISNULL(SUM(RECEIVEQTY),0)AS RECEIVEQTY,ISNULL(SUM(CLOSINGQTY),0) AS CLOSINGQTY,ISNULL(SUM(DMGQTY),0)AS DMGQTY,ISNULL(SUM(ADJQTY),0)AS ADJQTY,ISNULL(CLRATE,0) AS CLRATE,ITEMCODE,ITEMNAME,UOM,Subgroupdesc FROM STOCKSUMMARY where (opstk<>0 or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0')  AND SALEQTY<>'0' "
                    sqlstring = sqlstring & " GROUP BY ITEMCODE,ITEMNAME,UOM,Subgroupdesc,CLRATE "
                    sqlstring = sqlstring & " order by itemcode "
                    gconnection.getDataSet(sqlstring, "stocksummary")
                    Me.Cursor = Cursors.WaitCursor
                Next
            Else
                MessageBox.Show("Select the Store Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If CHK_ONLYSALE.Checked = True Then
                Dim r1 = New CrystocksummaryStockOnly_KSCA
                If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r1
                    rViewer.TableName = "Stocksummary"
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
                    If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                        TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")
                        Dim textobj29 As TextObject
                        textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                        textobj29.Text = "DATE :"
                    Else
                        TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                    End If
                    Dim TXTOBJ99 As TextObject
                    TXTOBJ99 = r1.ReportDefinition.ReportObjects("Text22")
                    TXTOBJ99.Text = Format(dtpfromdate.Value, "dd/MM/yyyy")

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
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
    Private Sub VIEWSTOCKSUMMARY()
        Try
            Dim sqlstring, ExicesUOM, CATEGORY(), ITEMNAME() As String
            Dim i As Integer
            Dim R2 As New RPT_STOCKSUMMARYSGRPWISE
            Dim r As New CrystocksummarySubGroup_KBA
            'Dim D As New CrystocksummaryGroup2D
            'Dim m As New CrystocksummaryGroupLIQ
            'Dim CL As New CrystocksummaryCL
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


            sqlstring = "if exists(select * from sysobjects where name='TempRate') begin DROP TABLE TempRate end"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = " select * into TempRate from CLOSINGQTY"
            gconnection.dataOperation(6, sqlstring, "tempclosingqty")

            'sqlstring = "UPDATE CLOSINGQTY SET  RATE = (SELECT TOP 1 RATE FROM TempRate B WHERE  B.ttype IN ('RECEIEVE','OPENNING','GRN')  AND CLOSINGQTY.storecode=B.STORECODE AND CLOSINGQTY.itemcode=B.itemcode AND CLOSINGQTY.AUTOID>B.Autoid ORDER BY B.Autoid DESC    )  WHERE  CLOSINGQTY.TTYPE IN ('KOT')  and closingqty.storecode='" + txt_mainstorecode.Text + "' "
            'gconnection.dataOperation(6, sqlstring, "tempclosingqty")

            'sqlstring = "UPDATE TempRate SET  RATE = (SELECT TOP 1 RATE FROM TempRate B WHERE  B.ttype IN ('RECEIEVE','OPENNING','GRN')  AND TempRate.storecode=B.STORECODE AND TempRate.itemcode=B.itemcode AND CLOSINGQTY.AUTOID>B.Autoid ORDER BY B.Autoid DESC    )  WHERE  CLOSINGQTY.TTYPE IN ('KOT')  and closingqty.storecode='" + txt_mainstorecode.Text + "' "
            'gconnection.dataOperation(6, sqlstring, "tempclosingqty")
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



            'sqlstring = " delete from stocksummary"
            'gconnection.dataOperation(6, sqlstring, "stocksummary")
            sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY,username,MachineName) "
            sqlstring = sqlstring & " select itemcode,ITEMNAME,'" + txt_mainstorecode.Text + "',STOCKUOM ,'0','0','0','" & Trim(gUsername) & "','" & machinename & "'"
            sqlstring = sqlstring & " from INV_InventoryItemMaster where "


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




            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                    sqlstring = " exec CP_stocksummary  '01/01/2016', '01/01/2016','" + Format(DTPaSondATE.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "','" & Trim(gUsername) & "','" & machinename & "'"
                Else
                    sqlstring = " exec CP_stocksummary  '01/01/2016', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "','" & Trim(gUsername) & "','" & machinename & "'"
                End If

                'sqlstring = " exec CP_stocksummary  '01/01/2016', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy ") + "','" + txt_mainstorecode.Text + "'"
            Else
                If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                    sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "','" + Format(DTPaSondATE.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "','" & Trim(gUsername) & "','" & machinename & "'"
                Else
                    sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy") + "','" + txt_mainstorecode.Text + "','" & Trim(gUsername) & "','" & machinename & "'"
                End If

            End If
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " update stocksummary set stocksummary.groupcode=i.groupcode, stocksummary.groupdesc=g.Groupdesc  from INV_InventoryItemMaster I  inner join stocksummary on i.ITEMCODE=stocksummary.ITEMCODE  inner join inventorygroupmaster g on i.groupcode=g.Groupcode"
            gconnection.dataOperation(6, sqlstring, "ratelist")

            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or UCase(gShortname) = "HSR" Or UCase(gShortname) = "CCL" Or UCase(gShortname) = "ALUMNI" Or UCase(gShortname) = "MYLC" Or UCase(gShortname) = "GNC" Or UCase(gShortname) = "MLRF" Or UCase(gShortname) = "SKYYE" Or UCase(gShortname) = "VFNCC" Or UCase(gShortname) = "JSCA" Or UCase(gShortname) = "TNBSA" Or gShortname = "CFC" Or UCase(gShortname) = "HBC" Then


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

                ElseIf UCase(gShortname) = "SKYYE" Or gShortname = "CFC" Or UCase(gShortname) = "HBC" Then

                    sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/1000) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE) end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/1000) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE) end,"
                    'sqlstring = sqlstring & "Issqty=cast(Issqty as Int)+(((ABS(Issqty)-cast(Issqty as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/1000,"
                    sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/1000,"
                    ' sqlstring = sqlstring & "DMGQTY=cast(DMGQTY as Int)+(((ABS(DMGQTY)-cast(DMGQTY as Int))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/1000,"
                    sqlstring = sqlstring & "closingqty=  case when closingqty>0  then cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/1000) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE) end ,"
                    sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then cast(ADJQTY as Int)+(((ABS(ADJQTY)-cast(ADJQTY as Int))/t.CONVVALUE)) else CAST(ADJQTY AS INT)-(((ABS(ADJQTY))+CAST(ADJQTY AS INT))/t.CONVVALUE) end "
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM  AND  U.storecode='" & txt_mainstorecode.Text & "'and username='" & Trim(gUsername) & "' and machinename='" & machinename & "'  "



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
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM AND  U.storecode='" & txt_mainstorecode.Text & "'and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "

                End If

                gconnection.dataOperation(6, sqlstring, )





            Else

                SQL = "if exists(select * from sysobjects where name='Items') begin DROP TABLE Items end"
                gconnection.dataOperation(6, SQL, )

                SQL = " select i.itemcode,i.storecode, i.reportUOM,i.reportdecimaluom,s.uom ,cast(null as numeric(18,6)) as  Conv1 ,cast(null as numeric(18,6)) as Conv2 into Items  from stocksummary s inner join inv_Inventoryuomstorelink i on s.itemcode=i.itemcode and s.storecode=i.storecode"
                gconnection.dataOperation(6, SQL, )

                If gShortname = "SKYYE" Or gShortname = "CCC" Or gShortname = "CFC" Or UCase(gShortname) = "HBC" Then
                    SQL = " update Items set Conv1= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.reportUOM=baseuom and s.Uom=t.transuom "
                    gconnection.dataOperation(6, SQL, )
                Else
                    SQL = " update Items set Conv1= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportUOM=TRANSUOM "
                    gconnection.dataOperation(6, SQL, )
                End If


                SQL = " update Items set Conv2= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportdecimaluom=TRANSUOM "
                gconnection.dataOperation(6, SQL, )

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


                If gShortname = "SKYYE" Or gShortname = "CCC" Or gShortname = "CFC" Or UCase(gShortname) = "HBC" Then
                    SQL = " update stocksummary set uom=reportUOM, oprate = oprate*Conv1,clrate = clrate*Conv1 ,opstk= opstk/CONV1  ,Openningqty= Openningqty/Conv1 ,receiveqty=receiveqty/CONV1 ,Issqty=Issqty /CONV1,SALEQTY=SALEQTY/Conv1,DMGQTY=DMGQTY/Conv1,closingqty=closingqty/Conv1,ADJQTY=ADJQTY/Conv1 from stocksummary s inner join Items u on s.Itemcode=u.itemcode and  s.Uom=u.uom  and username= '" & Trim(gUsername) & "' and machinename='" & machinename & "' "
                    gconnection.dataOperation(6, SQL, )
                Else
                    SQL = " update stocksummary set uom=reportUOM, oprate = oprate/Conv2,clrate = clrate/Conv2 ,opstk= opstk*Conv2  ,Openningqty= Openningqty*Conv2 ,receiveqty=receiveqty* Conv2 ,Issqty=Issqty * Conv2,SALEQTY=SALEQTY*Conv2,DMGQTY=DMGQTY*Conv2,closingqty=closingqty*Conv2,ADJQTY=ADJQTY*Conv2 from stocksummary s inner join Items u on s.Itemcode=u.itemcode and  s.Uom=u.uom and s.storecode=u.storecode and username= '" & Trim(gUsername) & "' and machinename='" & machinename & "'  "
                    gconnection.dataOperation(6, SQL, )
                End If


                'sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as Int)+(((ABS(opstk)-cast(opstk as Int))*t.CONVVALUE)/100) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as Int)+(((ABS(Openningqty)-cast(Openningqty as Int))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                'sqlstring = sqlstring & "receiveqty=  case when receiveqty>0  then cast(receiveqty as Int)+(((ABS(receiveqty)-cast(receiveqty as Int))*t.CONVVALUE)/100) else CAST(receiveqty AS INT)-(((ABS(receiveqty))+CAST(receiveqty AS INT))*t.CONVVALUE)/100 end ,"
                'sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                'sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                'sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                'sqlstring = sqlstring & "closingqty=case when closingqty>0  then cast(closingqty as Int)+(((ABS(closingqty)-cast(closingqty as Int))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                'sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then cast(ADJQTY as Int)+(((ABS(ADJQTY)-cast(ADJQTY as Int))/t.CONVVALUE)) else CAST(ADJQTY AS INT)-(((ABS(ADJQTY))+CAST(ADJQTY AS INT))/t.CONVVALUE) end "
                'sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM"

                'gconnection.dataOperation(6, sqlstring, )

            End If


            'gconnection.dataOperation(6, "exec cp_stockissue", )
            If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "'and username='" & Trim(gUsername) & "' and machinename='" & machinename & "'  and ttype='issue' and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                    gconnection.dataOperation(6, sqlstring, )
                Else
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' and ttype in('issue','issue from') and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                    gconnection.dataOperation(6, sqlstring, )
                    '   gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 and isnull(T.void,'N')<>'Y' AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN CAST(CONVERT(VARCHAR(11),'01/Apr/2016' ,106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )

                End If

                'ElseIf UCase(gShortname) = "DC" Then
                '    sqlstring = "update stocksummary set RCVRATE=isnull((select SUM(qty*(rate/CONVVALUE))/ (sum(qty)) from closingqty inner join INVENTORY_TRANSCONVERSION  t on closingqty.Uom=t.BASEUOM and stocksummary.uom=TRANSUOM where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('GRN','RECEIEVE') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                '    gconnection.dataOperation(6, sqlstring, )

                '    sqlstring = "update stocksummary set SALERATE=isnull((select SUM(qty*(rate/CONVVALUE))/ (sum(qty)) from closingqty inner join INVENTORY_TRANSCONVERSION  t on closingqty.Uom=t.BASEUOM and stocksummary.uom=TRANSUOM where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('KOT','CONSUME') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                '    gconnection.dataOperation(6, sqlstring, )

                'If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                'gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from TEMPSTOCKISSUEDETAIL t where t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)", )

            Else
                sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*(rate/CONVVALUE))/ (sum(qty)) from closingqty inner join INVENTORY_TRANSCONVERSION  t on closingqty.Uom=t.BASEUOM and stocksummary.uom=TRANSUOM where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                gconnection.dataOperation(6, sqlstring, )
                ' gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 and isnull(T.void,'N')<>'Y' AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN CAST(CONVERT(VARCHAR(11),'" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "',106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )
                'End If

            End If
            If Mid(UCase(gShortname), 1, 2) = "DC" Then
                gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*clrate", )
            Else

                gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )
            End If


            sqlstring = "update stocksummary set     issqty=issqty*-1,dmgqty=dmgqty*-1,saleqty=saleqty*-1 "
            gconnection.dataOperation(6, sqlstring, )


            sqlstring = "UPDATE stocksummary SET Subgroupcode = G.Subgroupcode ,Subgroupdesc=G.Subgroupdesc FROM stocksummary S , INV_INVENTORYITEMMASTER I , InventorySubGroupMaster G WHERE S.itemcode=I.itemcode AND I.subGroupcode=G.Subgroupcode and i.groupcode=g.groupcode "
            gconnection.dataOperation(6, sqlstring, )


            'sqlstring = "update stocksummary set itemname=itemname + ' -'+ 'STKCTL(' + (SELECT isnull(STKCTL,'')as stkctl )+')' from ItemMaster R ,STOCKSUMMARY S WHERE R.ITEMCODE=S.itemcode and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "
            'gconnection.dataOperation(6, sqlstring, )


            'sqlstring = "update stocksummary set     CLrate=clvalue/closingqty  where closingqty<>0 "
            'gconnection.dataOperation(6, sqlstring, )

            If CHK_WITHOUT_ZERO.Checked = True Then
                sqlstring = " select * from stocksummary where  closingqty<>'0' and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "
                gconnection.getDataSet(sqlstring, "stocksummary")
            ElseIf chksummary.Checked = True Then
                sqlstring = " select * from stocksummary where (openningqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') and username='" & Trim(gUsername) & "' and machinename='" & machinename & "'  "
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 4) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname"
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
                gconnection.getDataSet(sqlstring, "stocksummary")
            ElseIf ChBZero.Checked = True Then
                sqlstring = " select * from stocksummary WHERE username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "
                If UCase(gShortname) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname "
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
                gconnection.getDataSet(sqlstring, "stocksummary")




            Else

                If Mid(UCase(gShortname), 1, 2) = "DC" Or Mid(UCase(gShortname), 1, 4) = "MLRF" Then
                    sqlstring = " select * from stocksummary where (opstk<>0 or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "
                Else
                    sqlstring = " select * from stocksummary where (opstk<>0 or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' "
                End If

                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 4) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname"
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
                gconnection.getDataSet(sqlstring, "stocksummary")
            End If


            Me.Cursor = Cursors.WaitCursor
            If CHK_SUM.Checked = True Then
                '   sqlstring = "SELECT GROUPDESC,SUM(CLVALUE) AS CLVALUE FROM STOCKSUMMARY where GROUP BY GROUPDESC"
                If chksummary.Checked = True Then
                    sqlstring = " select SUBGROUPDESC,SUM(CLVALUE) AS CLVALUE from stocksummary where (openningqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') and username='" & Trim(gUsername) & "' and machinename='" & machinename & "'  GROUP BY SUBGROUPDESC "
                Else
                    sqlstring = " select SUBGROUPDESC,SUM(CLVALUE) AS CLVALUE from stocksummary where ( issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') and username='" & Trim(gUsername) & "' and machinename='" & machinename & "' GROUP BY SUBGROUPDESC "
                End If
                gconnection.getDataSet(sqlstring, "stocksummary")
                If gdataset.Tables("stocksummary").Rows.Count > 0 Then
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
                    textobj1 = R2.ReportDefinition.ReportObjects("Text1")
                    textobj1.Text = MyCompanyName

                    Dim textobj5 As TextObject
                    textobj5 = R2.ReportDefinition.ReportObjects("Text2")
                    textobj5.Text = UCase(Address1)
                    Dim textobj6 As TextObject
                    textobj6 = R2.ReportDefinition.ReportObjects("Text3")
                    textobj6.Text = UCase(Address2)


                    Dim bdate As Date
                    sqlstring = "select bdate from Businessdate "
                    gconnection.getDataSet(sqlstring, "INDENTHDR")
                    If gdataset.Tables("INDENTHDR").Rows.Count > 0 Then
                        bdate = Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("bdate")), "dd-MMM-yyyy")
                    End If
                    sqlstring = "update stocksummary set PROMOTIONALST='" & bdate & "'   "
                    gconnection.dataOperation(6, sqlstring, )

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                    Exit Sub


                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                Exit Sub
            End If

            'gconnection.getDataSet(sqlstring, "stocksummary")

            If Ck_Rec_Iss.Checked = True Then
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


                    Dim bdate As Date
                    sqlstring = "select bdate from Businessdate "
                    gconnection.getDataSet(sqlstring, "INDENTHDR")
                    If gdataset.Tables("INDENTHDR").Rows.Count > 0 Then
                        bdate = Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("bdate")), "dd-MMM-yyyy")
                    End If
                    sqlstring = "update stocksummary set PROMOTIONALST='" & bdate & "'   "
                    gconnection.dataOperation(6, sqlstring, )

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)


                End If
            ElseIf CKboxWOV.Checked = True Then
                Dim r1
                If UCase(gShortname) = "MLRF" Then
                    r1 = New CrystocksummaryStockOnly_MLRF
                ElseIf UCase(gShortname) = "BGC" Then
                    r1 = New CrystocksummaryStockOnly_BGC
                ElseIf UCase(gShortname) = "CFC" Then
                    r1 = New CrystocksummaryStockOnly_CFC
                ElseIf UCase(gShortname) = "FMC" Then
                    r1 = New CrystocksummaryStockOnly_FMC
                Else
                    r1 = New CrystocksummaryStockOnly
                End If
                If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r1
                    rViewer.TableName = "Stocksummary"

                    If UCase(gShortname) = "CFC" Then
                        'Dim picture1 As PictureObject
                        'picture1 = r.ReportDefinition.ReportObjects("picture1")
                        'If (gShortname = "CFC") Then
                        '    picture1.ObjectFormat.EnableSuppress = False
                        'Else
                        '    picture1.ObjectFormat.EnableSuppress = True

                        'End If

                        Dim textobj1 As TextObject
                        textobj1 = r1.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = r1.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1) + "," + UCase(Address2)
                        Dim textobj6 As TextObject
                        textobj6 = r1.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gState) + "," + UCase(gPincode)
                        Dim textobj20 As TextObject
                        textobj20 = r1.ReportDefinition.ReportObjects("Text20")
                        textobj20.Text = UCase(gPhone1) + "," + UCase(gPhone2)
                        Dim textobj21 As TextObject
                        textobj21 = r1.ReportDefinition.ReportObjects("Text21")
                        textobj21.Text = "GSTIN NO : " & UCase(gGSTINNO)
                        Dim textobj2 As TextObject
                        textobj2 = r1.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = r1.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text17")
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If

                        'If UCase(gShortname) = "MLRF" Then
                        '    Dim textobj19 As TextObject
                        '    textobj19 = r1.ReportDefinition.ReportObjects("Text19")
                        '    textobj19.Text = "      Prepared By:                                                                                                                                                                                  Approved By:       "
                        'End If
                        'If UCase(gShortname) = "TMA" Then
                        '    Dim textobj19 As TextObject
                        '    textobj19 = r1.ReportDefinition.ReportObjects("Text19")
                        '    textobj19.Text = "      Store Keeper:                                                                                                                                                                                  Manager:       "
                        'End If
                    Else
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
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If

                        If UCase(gShortname) = "MLRF" Then
                            Dim textobj19 As TextObject
                            textobj19 = r1.ReportDefinition.ReportObjects("Text19")
                            textobj19.Text = "      Prepared By:                                                                                                                                                                                  Approved By:       "
                        End If
                        If UCase(gShortname) = "TMA" Then
                            Dim textobj19 As TextObject
                            textobj19 = r1.ReportDefinition.ReportObjects("Text19")
                            textobj19.Text = "      Store Keeper:                                                                                                                                                                                  Manager:       "
                        End If

                        Dim bdate As Date
                        sqlstring = "select bdate from Businessdate "
                        gconnection.getDataSet(sqlstring, "INDENTHDR")
                        If gdataset.Tables("INDENTHDR").Rows.Count > 0 Then
                            bdate = Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("bdate")), "dd-MMM-yyyy")
                        End If
                        sqlstring = "update stocksummary set PROMOTIONALST='" & bdate & "'   "
                        gconnection.dataOperation(6, sqlstring, )

                    End If

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)


                End If



            Else
                Dim r1
                If Mid(UCase(gShortname), 1, 4) = "MLRF" Then
                    r1 = New CrystocksummaryRec_IssMLRF

                ElseIf UCase(gShortname) = "BGC" Then
                    r1 = New CrystocksummaryRec_IssBGC

                ElseIf UCase(gShortname) = "DC" Then
                    r1 = New CrystocksummaryRec_IssDC
                ElseIf UCase(gShortname) = "CFC" Then
                    r1 = New CrystocksummaryRec_IssCFC
                ElseIf UCase(gShortname) = "FMC" Then
                    r1 = New CrystocksummaryRec_Iss_FMC
                ElseIf UCase(gShortname) = "CPC" Then
                    r1 = New CrystocksummaryRec_Iss_CPC
                ElseIf UCase(gShortname) = "KGA" Then
                    r1 = New CrystocksummaryRec_Iss_KGA

                Else
                    r1 = New CrystocksummaryRec_Iss
                End If

                If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r1
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
                        textobj1 = r1.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = r1.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1) + "," + UCase(Address2)
                        Dim textobj6 As TextObject
                        textobj6 = r1.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gState) + "," + UCase(gPincode)
                        Dim textobj35 As TextObject
                        textobj35 = r1.ReportDefinition.ReportObjects("Text35")
                        textobj35.Text = UCase(gPhone1) + "," + UCase(gPhone2)
                        Dim textobj36 As TextObject
                        textobj36 = r1.ReportDefinition.ReportObjects("Text36")
                        textobj36.Text = "GSTIN NO : " & UCase(gGSTINNO)
                        Dim textobj2 As TextObject
                        textobj2 = r1.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = r1.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text17")
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If


                        'If UCase(gShortname) = "MLRF" Then
                        '    Dim textobj34 As TextObject
                        '    textobj34 = r1.ReportDefinition.ReportObjects("Text34")
                        '    textobj34.Text = "       Prepared By:                                                                                                                                                                                                      Approved By:            "
                        'End If
                        'If UCase(gShortname) = "TMA" Then
                        '    Dim textobj34 As TextObject
                        '    textobj34 = r1.ReportDefinition.ReportObjects("Text34")
                        '    textobj34.Text = "       Store Keeper:                                                                                                                                                                                                      Manager:            "
                        'End If
                    Else
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
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If


                        If UCase(gShortname) = "MLRF" Then
                            Dim textobj34 As TextObject
                            textobj34 = r1.ReportDefinition.ReportObjects("Text34")
                            textobj34.Text = "       Prepared By:                                                                                                                                                                                                      Approved By:            "
                        End If
                        If UCase(gShortname) = "TMA" Then
                            Dim textobj34 As TextObject
                            textobj34 = r1.ReportDefinition.ReportObjects("Text34")
                            textobj34.Text = "       Store Keeper:                                                                                                                                                                                                      Manager:            "
                        End If

                        If gShortname = "KGA" Then

                            Dim textobj7 As TextObject
                            textobj7 = r1.ReportDefinition.ReportObjects("Text36")
                            textobj7.Text = Trim(gUsername)

                            Dim textobj8 As TextObject
                            textobj8 = r1.ReportDefinition.ReportObjects("Text37")
                            textobj8.Text = machinename

                        End If


                        Dim bdate As Date
                        sqlstring = "select bdate from Businessdate "
                        gconnection.getDataSet(sqlstring, "INDENTHDR")
                        If gdataset.Tables("INDENTHDR").Rows.Count > 0 Then
                            bdate = Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("bdate")), "dd-MMM-yyyy")
                        End If
                        sqlstring = "update stocksummary set PROMOTIONALST='" & bdate & "'   "
                        gconnection.dataOperation(6, sqlstring, )


                    End If

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
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


    Private Sub VIEWSTOCKSUMMARY_NIZ()
        Try
            Dim sqlstring, ExicesUOM, CATEGORY(), ITEMNAME() As String
            Dim i As Integer
            Dim R2 As New RPT_STOCKSUMMARYSGRPWISE
            Dim r As New CrystocksummarySubGroup_KBA
            'Dim D As New CrystocksummaryGroup2D
            'Dim m As New CrystocksummaryGroupLIQ
            'Dim CL As New CrystocksummaryCL
            Dim rViewer As New Viewer
            ' gconnection.valuation()

            If txt_mainstorecode.Text <> "" Then

            Else
                MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Dim bdate As String
            bdate = gconnection.getvalue("  SELECT Convert(varchar(11), bdate, 106) As bdate FROM Businessdate")

            Me.Cursor = Cursors.WaitCursor

            '          'update ratelist set weightedrate=closingvalue/closingstock ,  lastweightedrate=  case when openningvalue=0 then     
            'batchrate    Else  openningvalue/openningstock      End 
            ' from ratelist r inner join CLOSINGQTY on r.grnno=CLOSINGQTY.trnno where
            '          trndate = r.grndate And CLOSINGQTY.storecode = r.storecode And CLOSINGQTY.itemcode = r.Itemcode


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

            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or UCase(gShortname) = "HSR" Or UCase(gShortname) = "CCL" Or UCase(gShortname) = "ALUMNI" Or UCase(gShortname) = "MYLC" Or UCase(gShortname) = "GNC" Or UCase(gShortname) = "MLRF" Then


                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as double)+(((ABS(opstk)-cast(opstk as double))*t.CONVVALUE)/100) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as double)+(((ABS(Openningqty)-cast(Openningqty as double))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                    'sqlstring = sqlstring & "Issqty=cast(Issqty as double)+(((ABS(Issqty)-cast(Issqty as double))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                    ' sqlstring = sqlstring & "DMGQTY=cast(DMGQTY as double)+(((ABS(DMGQTY)-cast(DMGQTY as double))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "closingqty=  case when closingqty>0  then cast(closingqty as double)+(((ABS(closingqty)-cast(closingqty as double))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then cast(ADJQTY as double)+(((ABS(ADJQTY)-cast(ADJQTY as double))/t.CONVVALUE)) else CAST(ADJQTY AS INT)-(((ABS(ADJQTY))+CAST(ADJQTY AS INT))/t.CONVVALUE) end "
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM and S.CATEGORYCODE NOT IN ('PRO') AND  U.storecode='" & txt_mainstorecode.Text & "'"

                Else
                    sqlstring = "update stocksummary set opstk=  case when opstk>0  then cast(opstk as double)+(((ABS(opstk)-cast(opstk as double))*t.CONVVALUE)/100) else CAST(opstk AS INT)-(((ABS(opstk))+CAST(opstk AS INT))*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then cast(Openningqty as double)+(((ABS(Openningqty)-cast(Openningqty as double))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end,"
                    ' sqlstring = sqlstring & "Openningqty=  case when Openningqty>0  then cast(Openningqty as double)+(((ABS(Openningqty)-cast(Openningqty as double))*t.CONVVALUE)/100) else CAST(Openningqty AS INT)-(((ABS(Openningqty))+CAST(Openningqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "receiveqty=  case when receiveqty>0  then cast(receiveqty as double)+(((ABS(receiveqty)-cast(receiveqty as double))*t.CONVVALUE)/100) else CAST(receiveqty AS INT)-(((ABS(receiveqty))+CAST(receiveqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "Issqty=CAST(Issqty AS INT)-(((ABS(Issqty))+CAST(Issqty AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "SALEQTY=CAST(SALEQTY AS INT)-(((ABS(SALEQTY))+CAST(SALEQTY AS INT))*t.CONVVALUE)/100,"
                    '- sqlstring = sqlstring & "DMGQTY=cast(DMGQTY as double)+(((ABS(DMGQTY)-cast(DMGQTY as double))*t.CONVVALUE)/100),"
                    sqlstring = sqlstring & "DMGQTY=CAST(DMGQTY AS INT)-(((ABS(DMGQTY))+CAST(DMGQTY AS INT))*t.CONVVALUE)/100,"
                    sqlstring = sqlstring & "closingqty=  case when closingqty>0  then cast(closingqty as double)+(((ABS(closingqty)-cast(closingqty as double))*t.CONVVALUE)/100) else CAST(closingqty AS INT)-(((ABS(closingqty))+CAST(closingqty AS INT))*t.CONVVALUE)/100 end ,"
                    sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then cast(ADJQTY as double)+(((ABS(ADJQTY)-cast(ADJQTY as double))/t.CONVVALUE)) else CAST(ADJQTY AS INT)-(((ABS(ADJQTY))+CAST(ADJQTY AS INT))/t.CONVVALUE) end "
                    sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM AND  U.storecode='" & txt_mainstorecode.Text & "'"

                End If

                gconnection.dataOperation(6, sqlstring, )





            Else

                SQL = "if exists(select * from sysobjects where name='Items') begin DROP TABLE Items end"
                gconnection.dataOperation(6, SQL, )

                SQL = " select i.itemcode,i.storecode, i.reportUOM,i.reportdecimaluom,s.uom ,cast(null as numeric(18,6)) as  Conv1 ,cast(null as numeric(18,6)) as Conv2 into Items  from stocksummary s inner join inv_Inventoryuomstorelink i on s.itemcode=i.itemcode and s.storecode=i.storecode "
                gconnection.dataOperation(6, SQL, )

                SQL = " update Items set Conv1= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportUOM=TRANSUOM "
                gconnection.dataOperation(6, SQL, )

                SQL = " update Items set Conv2= CONVVALUE from Items s inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and s.reportdecimaluom=TRANSUOM "
                gconnection.dataOperation(6, SQL, )

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
                SQL = " update stocksummary set uom=reportUOM, oprate = oprate/Conv1,clrate = clrate/Conv1 ,opstk= opstk*CONV1  ,Openningqty= Openningqty*Conv1 ,receiveqty=receiveqty* CONV1 ,Issqty=Issqty * CONV1,SALEQTY=SALEQTY*Conv1,DMGQTY=DMGQTY*Conv1,closingqty=closingqty*Conv1,ADJQTY=ADJQTY*Conv1 from stocksummary s inner join Items u on s.Itemcode=u.itemcode and  s.Uom=u.uom "
                gconnection.dataOperation(6, SQL, )

                sqlstring = "update stocksummary set opstk=  case when opstk>0  then  opstk  +(((ABS(opstk)-(opstk ))*t.CONVVALUE)/100) else opstk -(((ABS(opstk))+opstk )*t.CONVVALUE)/100 end ,Openningqty=  case when Openningqty>0  then (Openningqty )+(((ABS(Openningqty)-(Openningqty ))*t.CONVVALUE)/100) else (Openningqty)-(((ABS(Openningqty))+(Openningqty ))*t.CONVVALUE)/100 end,"
                sqlstring = sqlstring & "receiveqty=  case when receiveqty>0  then (receiveqty )+(((ABS(receiveqty)-(receiveqty ))*t.CONVVALUE)/100) else (receiveqty )-(((ABS(receiveqty))+(receiveqty))*t.CONVVALUE)/100 end ,"
                sqlstring = sqlstring & "Issqty=(Issqty)-(((ABS(Issqty))+(Issqty ))*t.CONVVALUE)/100,"
                sqlstring = sqlstring & "SALEQTY=(SALEQTY )-(((ABS(SALEQTY))+(SALEQTY ))*t.CONVVALUE)/100,"
                sqlstring = sqlstring & "DMGQTY=(DMGQTY )-(((ABS(DMGQTY))+(DMGQTY ))*t.CONVVALUE)/100,"
                sqlstring = sqlstring & "closingqty=case when closingqty>0  then (closingqty )+(((ABS(closingqty)-(closingqty ))*t.CONVVALUE)/100) else (closingqty )-(((ABS(closingqty))+(closingqty ))*t.CONVVALUE)/100 end ,"
                sqlstring = sqlstring & "ADJQTY=  case when ADJQTY>0  then (ADJQTY )+(((ABS(ADJQTY)-(ADJQTY ))/t.CONVVALUE)) else (ADJQTY)-(((ABS(ADJQTY))+(ADJQTY ))/t.CONVVALUE) end "
                sqlstring = sqlstring & "from stocksummary s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM"

                gconnection.dataOperation(6, sqlstring, )

            End If


            'gconnection.dataOperation(6, "exec cp_stockissue", )
            If CheckBox1.Checked = True And GroupBox4.Visible = True Then
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype IN ('issue','TRANSFER') and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                    gconnection.dataOperation(6, sqlstring, )
                Else
                    sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*rate)/ (sum(qty)) from closingqty where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '01/Apr/" & gFinancalyearStart & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"
                    gconnection.dataOperation(6, sqlstring, )
                    '   gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 and isnull(T.void,'N')<>'Y' AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN CAST(CONVERT(VARCHAR(11),'01/Apr/2016' ,106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )

                End If

                'ElseIf UCase(gShortname) = "DC" Then
                '    sqlstring = "update stocksummary set RCVRATE=isnull((select SUM(qty*(rate/CONVVALUE))/ (sum(qty)) from closingqty inner join INVENTORY_TRANSCONVERSION  t on closingqty.Uom=t.BASEUOM and stocksummary.uom=TRANSUOM where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('GRN','RECEIEVE') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                '    gconnection.dataOperation(6, sqlstring, )

                '    sqlstring = "update stocksummary set SALERATE=isnull((select SUM(qty*(rate/CONVVALUE))/ (sum(qty)) from closingqty inner join INVENTORY_TRANSCONVERSION  t on closingqty.Uom=t.BASEUOM and stocksummary.uom=TRANSUOM where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('KOT','CONSUME') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                '    gconnection.dataOperation(6, sqlstring, )

                'If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                'gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from TEMPSTOCKISSUEDETAIL t where t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)", )

            Else
                sqlstring = "update stocksummary set issuerate=isnull((select SUM(qty*(rate/CONVVALUE))/ (sum(qty)) from closingqty inner join INVENTORY_TRANSCONVERSION  t on closingqty.Uom=t.BASEUOM and stocksummary.uom=TRANSUOM where itemcode=stocksummary.itemcode and storecode='" & txt_mainstorecode.Text & "' and ttype in('issue','issue from','TRANSFER') and cast(trndate as date) between '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'),0)"

                gconnection.dataOperation(6, sqlstring, )
                ' gconnection.dataOperation(6, "update stocksummary set issuerate=isnull((select sum(amount)/sum(qty) from STOCKISSUEDETAIL t where T.QTY>0 and isnull(T.void,'N')<>'Y' AND t.Itemcode=stocksummary.itemcode and CAST(CONVERT(VARCHAR(11),t.DOCDATE ,106) AS DATETIME) BETWEEN CAST(CONVERT(VARCHAR(11),'" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "',106) AS DATETIME) AND CAST(CONVERT(VARCHAR(11),'" & Format(dtptodate.Value, "dd/MMM/yyyy") & "' ,106) AS DATETIME)),0)", )
                'End If

            End If
            If Mid(UCase(gShortname), 1, 2) = "DC" Then
                gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*clrate", )
            Else

                gconnection.dataOperation(6, "update stocksummary set issuevalue=(issqty*-1)*issuerate", )
            End If


            sqlstring = "update stocksummary set     issqty=issqty*-1,dmgqty=dmgqty*-1,saleqty=saleqty*-1 "
            gconnection.dataOperation(6, sqlstring, )


            sqlstring = "UPDATE stocksummary SET Subgroupcode = G.Subgroupcode ,Subgroupdesc=G.Subgroupdesc FROM stocksummary S , INV_INVENTORYITEMMASTER I , InventorySubGroupMaster G WHERE S.itemcode=I.itemcode AND I.subGroupcode=G.Subgroupcode "
            gconnection.dataOperation(6, sqlstring, )


            'sqlstring = "update stocksummary set     CLrate=clvalue/closingqty  where closingqty<>0 "
            'gconnection.dataOperation(6, sqlstring, )

            If chksummary.Checked = True Then
                sqlstring = " select * from stocksummary where (openningqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') "
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 4) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname"
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
                gconnection.getDataSet(sqlstring, "stocksummary")
            ElseIf ChBZero.Checked = True Then
                sqlstring = " select * from stocksummary "
                If UCase(gShortname) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname "
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
                gconnection.getDataSet(sqlstring, "stocksummary")
            Else

                If Mid(UCase(gShortname), 1, 2) = "DC" Or Mid(UCase(gShortname), 1, 4) = "MLRF" Then
                    sqlstring = " select * from stocksummary where (opstk<>0 or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0')"
                Else
                    sqlstring = " select * from stocksummary where ( issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0')"
                End If

                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 4) = "MLRF" Then
                    sqlstring = sqlstring & " order by itemname"
                Else
                    sqlstring = sqlstring & " order by itemcode "
                End If
                gconnection.getDataSet(sqlstring, "stocksummary")
            End If


            Me.Cursor = Cursors.WaitCursor
            If CHK_SUM.Checked = True Then
                '   sqlstring = "SELECT GROUPDESC,SUM(CLVALUE) AS CLVALUE FROM STOCKSUMMARY where GROUP BY GROUPDESC"
                If chksummary.Checked = True Then
                    sqlstring = " select SUBGROUPDESC,SUM(CLVALUE) AS CLVALUE from stocksummary where (openningqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') GROUP BY SUBGROUPDESC "
                Else
                    sqlstring = " select SUBGROUPDESC,SUM(CLVALUE) AS CLVALUE from stocksummary where ( issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0')  GROUP BY SUBGROUPDESC "
                End If
                gconnection.getDataSet(sqlstring, "stocksummary")
                If gdataset.Tables("stocksummary").Rows.Count > 0 Then
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
                    textobj1 = R2.ReportDefinition.ReportObjects("Text1")
                    textobj1.Text = MyCompanyName

                    Dim textobj5 As TextObject
                    textobj5 = R2.ReportDefinition.ReportObjects("Text2")
                    textobj5.Text = UCase(Address1)
                    Dim textobj6 As TextObject
                    textobj6 = R2.ReportDefinition.ReportObjects("Text3")
                    textobj6.Text = UCase(Address2)

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                    Exit Sub


                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                Exit Sub
            End If

            'gconnection.getDataSet(sqlstring, "stocksummary")

            If Ck_Rec_Iss.Checked = True Then
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
                    Me.Cursor = Cursors.Default
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)


                End If
            ElseIf CKboxWOV.Checked = True Then
                Dim r1
                If UCase(gShortname) = "MLRF" Then
                    r1 = New CrystocksummaryStockOnly_MLRF
                ElseIf UCase(gShortname) = "BGC" Then
                    r1 = New CrystocksummaryStockOnly_BGC
                ElseIf UCase(gShortname) = "CFC" Then
                    r1 = New CrystocksummaryStockOnly_CFC
                Else
                    r1 = New CrystocksummaryStockOnly
                End If
                If gdataset.Tables("stocksummary").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r1
                    rViewer.TableName = "Stocksummary"

                    If UCase(gShortname) = "CFC" Then
                        'Dim picture1 As PictureObject
                        'picture1 = r.ReportDefinition.ReportObjects("picture1")
                        'If (gShortname = "CFC") Then
                        '    picture1.ObjectFormat.EnableSuppress = False
                        'Else
                        '    picture1.ObjectFormat.EnableSuppress = True

                        'End If

                        Dim textobj1 As TextObject
                        textobj1 = r1.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = r1.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1) + "," + UCase(Address2)
                        Dim textobj6 As TextObject
                        textobj6 = r1.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gState) + "," + UCase(gPincode)
                        Dim textobj20 As TextObject
                        textobj20 = r1.ReportDefinition.ReportObjects("Text20")
                        textobj20.Text = UCase(gPhone1) + "," + UCase(gPhone2)
                        Dim textobj21 As TextObject
                        textobj21 = r1.ReportDefinition.ReportObjects("Text21")
                        textobj21.Text = "GSTIN NO : " & UCase(gGSTINNO)
                        Dim textobj2 As TextObject
                        textobj2 = r1.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = r1.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text17")
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If

                        'If UCase(gShortname) = "MLRF" Then
                        '    Dim textobj19 As TextObject
                        '    textobj19 = r1.ReportDefinition.ReportObjects("Text19")
                        '    textobj19.Text = "      Prepared By:                                                                                                                                                                                  Approved By:       "
                        'End If
                        'If UCase(gShortname) = "TMA" Then
                        '    Dim textobj19 As TextObject
                        '    textobj19 = r1.ReportDefinition.ReportObjects("Text19")
                        '    textobj19.Text = "      Store Keeper:                                                                                                                                                                                  Manager:       "
                        'End If
                    Else
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
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If

                        If UCase(gShortname) = "MLRF" Then
                            Dim textobj19 As TextObject
                            textobj19 = r1.ReportDefinition.ReportObjects("Text19")
                            textobj19.Text = "      Prepared By:                                                                                                                                                                                  Approved By:       "
                        End If
                        If UCase(gShortname) = "TMA" Then
                            Dim textobj19 As TextObject
                            textobj19 = r1.ReportDefinition.ReportObjects("Text19")
                            textobj19.Text = "      Store Keeper:                                                                                                                                                                                  Manager:       "
                        End If
                    End If

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)


                End If



            Else
                Dim r1
                If Mid(UCase(gShortname), 1, 4) = "MLRF" Then
                    r1 = New CrystocksummaryRec_IssMLRF

                ElseIf UCase(gShortname) = "BGC" Then
                    r1 = New CrystocksummaryRec_IssBGC

                ElseIf UCase(gShortname) = "DC" Then
                    r1 = New CrystocksummaryRec_IssDC
                ElseIf UCase(gShortname) = "CFC" Then
                    r1 = New CrystocksummaryRec_IssCFC
                Else
                    r1 = New CrystocksummaryRec_Iss
                End If

                If gdataset.Tables("stocksummary").Rows.Count > 1 Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r1
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
                        textobj1 = r1.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = r1.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(Address1) + "," + UCase(Address2)
                        Dim textobj6 As TextObject
                        textobj6 = r1.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gState) + "," + UCase(gPincode)
                        Dim textobj35 As TextObject
                        textobj35 = r1.ReportDefinition.ReportObjects("Text35")
                        textobj35.Text = UCase(gPhone1) + "," + UCase(gPhone2)
                        Dim textobj36 As TextObject
                        textobj36 = r1.ReportDefinition.ReportObjects("Text36")
                        textobj36.Text = "GSTIN NO : " & UCase(gGSTINNO)
                        Dim textobj2 As TextObject
                        textobj2 = r1.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_mainstore.Text)
                        Dim textobj22 As TextObject
                        textobj22 = r1.ReportDefinition.ReportObjects("Text11")
                        textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r1.ReportDefinition.ReportObjects("Text17")
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If


                        'If UCase(gShortname) = "MLRF" Then
                        '    Dim textobj34 As TextObject
                        '    textobj34 = r1.ReportDefinition.ReportObjects("Text34")
                        '    textobj34.Text = "       Prepared By:                                                                                                                                                                                                      Approved By:            "
                        'End If
                        'If UCase(gShortname) = "TMA" Then
                        '    Dim textobj34 As TextObject
                        '    textobj34 = r1.ReportDefinition.ReportObjects("Text34")
                        '    textobj34.Text = "       Store Keeper:                                                                                                                                                                                                      Manager:            "
                        'End If
                    Else
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
                        ' TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        If CheckBox1.Checked = True And GroupBox4.Visible = True Then

                            TXTOBJ3.Text = Format(DTPaSondATE.Value, "dd/MM/yyyy")

                            Dim textobj29 As TextObject
                            textobj29 = r1.ReportDefinition.ReportObjects("Text10")
                            textobj29.Text = "DATE :"

                        Else
                            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
                        End If


                        If UCase(gShortname) = "MLRF" Then
                            Dim textobj34 As TextObject
                            textobj34 = r1.ReportDefinition.ReportObjects("Text34")
                            textobj34.Text = "       Prepared By:                                                                                                                                                                                                      Approved By:            "
                        End If
                        If UCase(gShortname) = "TMA" Then
                            Dim textobj34 As TextObject
                            textobj34 = r1.ReportDefinition.ReportObjects("Text34")
                            textobj34.Text = "       Store Keeper:                                                                                                                                                                                                      Manager:            "
                        End If

                    End If

                    rViewer.Show()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
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
            sqlstring = " select ITEMCODE,ITEMNAME ,UOM,OPSTK,opweightedrate AS OPRATE,opvalue AS OPVALUE,abs(issqty) AS ISSUE_QTY,dmgqty AS DMG_QTY,adjqty AS ADJ_QTY,abs(saleqty) AS SALE_QTY,receiveqty AS REC_QTY,closingqty AS CLOSING_QTY,clweightedrate AS CLOSING_RATE,clvalue AS CLOSING_VALUE from stocksummary where (openningqty<>'0' or issqty<>'0' or dmgqty<>'0' or adjqty<>'0' or saleqty<>'0' or receiveqty<>'0') AND username='" & Trim(gUsername) & "' and machinename='" & machinename & "' order by itemcode"
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

        ssql = ""
        sqlstring = " SELECT DISTINCT ISNULL(Subgroupcode,'') AS Subgroupcode,ISNULL(Subgroupdesc,'') AS Subgroupdesc FROM InventorySubGroupMaster  "
        sqlstring = sqlstring & " WHERE isnull(Freeze,'') <> 'Y' "

        'For J = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        '    If J = Chklist_Groupdesc.CheckedItems.Count - 1 Then
        '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "' "
        '    Else
        '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "', "
        '    End If
        'Next


        If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "  and GROUPCODE IN ("
            For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                groupcode = Split(Chklist_Groupdesc.CheckedItems(i), "-->")
                sqlstring = sqlstring & " '" & Trim(groupcode(0)) & "', "
            Next


            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        If Chklist_Groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & " ORDER BY Subgroupcode "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                CheckedListBox2.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        CheckedListBox2.Items.Add(Trim(.Item("Subgroupcode") & "-->" & .Item("Subgroupdesc")))
                    End With
                Next i
            End If
        Else
            CheckedListBox2.Items.Clear()

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

    Private Sub txt_mainstorecode_TextChanged(sender As Object, e As EventArgs) Handles txt_mainstorecode.TextChanged

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

    Private Sub chksummary_CheckedChanged(sender As Object, e As EventArgs) Handles chksummary.CheckedChanged
        If gShortname = "KSCA" Then
            GroupBox5.Visible = False
        End If
    End Sub

    Private Sub CKboxWOV_CheckedChanged(sender As Object, e As EventArgs) Handles CKboxWOV.CheckedChanged
        If gShortname = "KSCA" Then
            GroupBox5.Visible = True
        End If
    End Sub

    Private Sub Chklist_Groupdesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Chklist_Groupdesc.KeyPress
        Dim i, J As Integer
        Dim sqlstring, ssql, groupcode() As String
        ssql = ""

        ssql = ""
        sqlstring = " SELECT DISTINCT ISNULL(Subgroupcode,'') AS Subgroupcode,ISNULL(Subgroupdesc,'') AS Subgroupdesc FROM InventorySubGroupMaster  "
        sqlstring = sqlstring & " WHERE isnull(Freeze,'') <> 'Y' "

        'For J = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        '    If J = Chklist_Groupdesc.CheckedItems.Count - 1 Then
        '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "' "
        '    Else
        '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "', "
        '    End If
        'Next


        If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "  and GROUPCODE IN ("
            For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                groupcode = Split(Chklist_Groupdesc.CheckedItems(i), "-->")
                sqlstring = sqlstring & " '" & Trim(groupcode(0)) & "', "
            Next


            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        If Chklist_Groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & " ORDER BY Subgroupcode "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                CheckedListBox2.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        CheckedListBox2.Items.Add(Trim(.Item("Subgroupcode") & "-->" & .Item("Subgroupdesc")))
                    End With
                Next i
            End If
        Else
            CheckedListBox2.Items.Clear()

        End If

    End Sub

    Private Sub CheckedListBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CheckedListBox2.KeyPress
        Dim i, J As Integer
        Dim sqlstring, ssql, groupcode() As String
        ssql = ""
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I  inner join inv_inventoryopenningstock o on o.itemcode=i.itemcode  and o.storecode='" & txt_mainstorecode.Text & "'"
        sqlstring = sqlstring & " WHERE isnull(I.VOID,'') <> 'Y' "

        'For J = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        '    If J = Chklist_Groupdesc.CheckedItems.Count - 1 Then
        '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "' "
        '    Else
        '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "', "
        '    End If
        'Next

        If CheckedListBox2.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "  and I.Subgroupcode IN ("
            For i = 0 To CheckedListBox2.CheckedItems.Count - 1
                groupcode = Split(CheckedListBox2.CheckedItems(i), "-->")
                sqlstring = sqlstring & " '" & Trim(groupcode(0)) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        If CheckedListBox2.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & " ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INV_INVENTORYITEMMASTER")
            If gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0 Then
                CheckedListBox3.Items.Clear()
                For i = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
                    With gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i)
                        CheckedListBox3.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        Else
            CheckedListBox3.Items.Clear()

        End If

    End Sub

    Private Sub Chklist_Groupdesc_Click(sender As Object, e As EventArgs) Handles Chklist_Groupdesc.Click
        Chklist_Groupdesc_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            GroupBox4.Visible = True
        Else
            GroupBox4.Visible = False
        End If
    End Sub

    Private Sub CHKLIST_CATEGORY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CHKLIST_CATEGORY.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql, CATEGORYCODE() As String
        ssql = ""

        ssql = ""
        sqlstring = " SELECT DISTINCT ISNULL(Groupcode,'') AS Groupcode,ISNULL(Groupdesc,'') AS Groupdesc FROM InventoryGroupMaster  "
        sqlstring = sqlstring & " WHERE isnull(Freeze,'') <> 'Y' "

        'For J = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
            '    If J = Chklist_Groupdesc.CheckedItems.Count - 1 Then
            '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "' "
            '    Else
            '        ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "', "
            '    End If
            'Next


        If CHKLIST_CATEGORY.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "  and CATEGORYCODE  IN ("
            For i = 0 To CHKLIST_CATEGORY.CheckedItems.Count - 1
                CATEGORYCODE = Split(CHKLIST_CATEGORY.CheckedItems(i), "-->")
                sqlstring = sqlstring & " '" & Trim(CATEGORYCODE(0)) & "', "
            Next


            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        If CHKLIST_CATEGORY.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & " ORDER BY groupcode "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                Chklist_Groupdesc.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        Chklist_Groupdesc.Items.Add(Trim(.Item("Groupcode") & "-->" & .Item("Groupdesc")))
                    End With
                Next i
            End If
        Else
            Chklist_Groupdesc.Items.Clear()

        End If




    End Sub

    Private Sub CHKLIST_CATEGORY_MouseMove(sender As Object, e As MouseEventArgs) Handles CHKLIST_CATEGORY.MouseMove
        ' Call CHKLIST_CATEGORY_SelectedIndexChanged(sender, e)

    End Sub

    Private Sub Chklist_Groupdesc_MouseMove(sender As Object, e As MouseEventArgs) Handles Chklist_Groupdesc.MouseMove
        '   Call Chklist_Groupdesc_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim i As Integer = 0

        If (CheckBox2.Checked = True) Then
            For i = 0 To CHKLIST_CATEGORY.Items.Count - 1
                CHKLIST_CATEGORY.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CHKLIST_CATEGORY.Items.Count - 1
                CHKLIST_CATEGORY.SetItemChecked(i, False)
            Next

        End If
        CHKLIST_CATEGORY_SelectedIndexChanged(sender, e)

    End Sub
End Class