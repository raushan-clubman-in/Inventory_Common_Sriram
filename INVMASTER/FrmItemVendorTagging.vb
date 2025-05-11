Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions

Public Class FrmItemVendorTagging
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Dim vconn As New GlobalClass
    Private Sub GetLastNo()
        Dim SQLSTRING As String
        Dim DR As DataRow
        SQLSTRING = "SELECT Isnull(Max(SLCODE),0)as SLCODE FROM accountssubledgermaster where accode='" + Txt_GLAcCode.Text + "'"
        gconnection.getDataSet(SQLSTRING, "membermaster")
        If gdataset.Tables("membermaster").Rows.Count > 0 Then
            Me.Lbl_Last.Text = "Last No IS : " & " " & gdataset.Tables("membermaster").Rows(0).Item(0)
        Else
            Me.Lbl_Last.Text = "Last No" & " " & 0
        End If

    End Sub
    Private Function Mevalidate() As Boolean
        Dim strMessage As String = ""
        'Dim regex As Regex = New Regex("([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\." +
        '                               ")|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})",
        '                               RegexOptions.IgnoreCase _
        '                               Or RegexOptions.CultureInvariant _
        '                               Or RegexOptions.IgnorePatternWhitespace _
        '                               Or RegexOptions.Compiled
        '                               )
        'Dim IsMatch As Boolean = regex.IsMatch(txt_email.Text)
        'If IsMatch Then
        '    If txt_email.Text.Equals(regex.Match(txt_email.Text).ToString) Then
        '        strMessage = "Valid email address"
        '    Else
        '        strMessage = "There's an email address in there somewhere.  But not exactly"
        '    End If
        'Else
        '    strMessage = "Sorry.  Invalid email address format."
        'End If
        'MessageBox.Show(strMessage)
        'Mevalidate = True
        'If gShortname = "CCFC" Then
        If Trim(Txt_GLAcCode.Text) = "" Then
            Mevalidate = False
            MsgBox("accode cannot be blank", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Txt_GLAcCode.Focus()
            Exit Function
        End If
        If Cmd_Add.Text = "Add[F7]" Then
            sqlstring = "select * from accountssubledgermaster where SLNAME='" & Trim(Txt_SLName.Text) & "' and isnull(freezeflag,'N')<>'Y'"
            gconnection.getDataSet(sqlstring, "inv1")
            If gdataset.Tables("inv1").Rows.Count > 0 Then
                MessageBox.Show(" Supplier name already used .", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_SLName.Text = ""
                Txt_SLName.Focus()
                Exit Function
            End If
        End If
        If Trim(Txt_SLcode.Text) = "" Then
            Mevalidate = False
            MsgBox("Sl Code cannot be blank", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Txt_SLcode.Focus()
            Exit Function
        End If
        If Trim(Txt_SLName.Text) = "" Then
            Mevalidate = False
            MsgBox("Sl Name cannot be blank", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Txt_SLName.Focus()
            Exit Function
        End If
        If UCase(Me.Txt_GLAcCode.Text) = gDebitors Then
            Mevalidate = False
            MsgBox("Sundry Debtors Can Not Be Added Through Sub Ledger,Pls Make Through MemberMaster", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
            Exit Function
        End If
        If Trim(txt_email.Text) <> "" Then
            getEmail(txt_email)
            If boolexp1 = False Then
                Mevalidate = False
                Exit Function
            End If
        End If
        Mevalidate = True
    End Function
    Private Sub Cmd_SLCodeHelp_Click(sender As Object, e As EventArgs) Handles Comd_SLCodeHelp.Click
        Dim vform As New ListOperattion1
        Dim sqlstring As String
        gSQLString = "SELECT distinct slcode,Slname FROM accountssubledgermaster "

        sqlstring = "  Select isnull(MSupplier,'N') as MSupplier  from inv_linksetup"
        gconnection.getDataSet(sqlstring, "inv_linksetup")

        If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
            If (gdataset.Tables("inv_linksetup").Rows(0).Item("MSupplier").ToString() = "Y") Then
                M_WhereCondition = "  Where sltype='SUPPLIER' and isnull(freezeflag,'N')<>'Y'"
            Else
                M_WhereCondition = " Where accode='" + gCreditors + "' and isnull(freezeflag,'N')<>'Y'"
            End If
        End If

        'M_WhereCondition = " Where Accode='" & Trim(Me.Txt_GLAcCode.Text) & "'"

        vform.Field = "slcode,slname"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.vFormatstring = "  SUB LEDGER CODE       |SUB LEDGER NAME                    |"
        vform.vCaption = "SUB LEDGER MASTER HELP"
        vform.KeyPos = 0
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_SLcode.Text = Trim(vform.keyfield & "")

            Txt_SLName.Text = Trim(vform.keyfield1 & "")
            Txt_SLCode_Validated(sender, e)
        Else
            Me.Text_SLCode.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 780
        K = 1044
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

    Private Sub FrmItemVendorTagging_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F6) Then
            clearoperation()
        ElseIf (e.KeyCode = Keys.F7) And Cmd_Add.Visible = True Then
            Cmd_Add_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F10) And Cmd_Freeze.Visible = True Then
            Cmd_Freeze_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F11) Then
            Cmd_Exit_Click(sender, e)
        End If
    End Sub

    Private Sub FrmItemVendorTagging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Cmb_SLType.SelectedIndex = 0
        GroupBox1.Controls.Add(AxfpSpread3)
        AxfpSpread3.Location = New Point(10, 10)
        '  AxfpSpread3.Width = GroupBox1.Width - 10
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        clearoperation()
        sqlstring = "  Select isnull(MSupplier,'N') as MSupplier from inv_linksetup"
        gconnection.getDataSet(sqlstring, "inv_linksetup")

        If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
            If (gdataset.Tables("inv_linksetup").Rows(0).Item("MSupplier").ToString() = "Y") Then
                Txt_GLAcCode.Text = ""
                Txt_GLAcDesc.Text = ""
                Txt_GLAcCode.ReadOnly = False
                Txt_GLAcDesc.ReadOnly = False
                Cmd_GLAcCodeHelp.Enabled = True
            Else
                Txt_GLAcCode.Text = "SCRS"
                Txt_GLAcDesc.Text = "SUNDRY CREDITORS"
                Txt_GLAcCode.ReadOnly = True
                Txt_GLAcDesc.ReadOnly = True
                Cmd_GLAcCodeHelp.Enabled = False
            End If
        End If
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        Txt_SLcode.Focus()



    End Sub


    Private Sub GetRights()
        Dim i, x As Integer
        'Dim vmain, vsmod, vssmod As Long
        Dim SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Item Vendor Tagging"
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        'Me.Cmd_View.Enabled = False
        'Me.Cmd_Print.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    'Me.Cmd_View.Enabled = True
                    'Me.Cmd_Print.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    'Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    'Me.Cmd_Print.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub clearoperation()
        Text_SLCode.Text = ""
        Text_SLName.Text = ""
        Cmd_Add.Text = "Add[F7]"

        dtp_effectdate.Value = Date.Now
        ToDate.Value = Date.Now
        dtp_effectdate.Enabled = True
        ' Dim SQL As String
        'AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        '   Dim sql As String '= "select itemcode,itemname,'1' as check1,contractyn,rate,uom from Invitem_VendorMaster where vendorcode='" + Txt_SLCode.Text + "'"
        Dim sql As String = " select itemcode,itemname,'0' as check1,'0' as contractyn,'0' as rate  from INV_INVENTORYITEMMASTER  where isnull(void,'')<>'Y' "

        ' SQL = " SELECT distinct ITEMCODE,ITEMNAME,'0' as check1  FROM INV_INVENTORYITEMMASTER WHERE ISNULL(VOID,'')<>'y'"
        gconnection.getDataSet(sql, "INV_INVENTORYITEMMASTER")
        If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
                With AxfpSpread3
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("ITEMCODE")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("ITEMNAME")
                    .Row = i + 1
                    .Col = 3
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("check1")
                    .Row = i + 1
                    .Col = 4
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("contractyn")

                    .Row = i + 1
                    .Col = 5
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("rate")
                    '.Row = i + 1
                    '.Col = 6
                    'sql = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("itemcode")) + "'"

                    'gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                    'For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                    '    AxfpSpread3.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    '    AxfpSpread3.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    'Next Z

                    '  .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("uom")
                End With
            Next
        End If
        sql = " SELECT distinct categorycode,categorydesc FROM INVENTORYCATEGORYMASTER WHERE ISNULL(freeze,'')<>'y'  "
        gconnection.getDataSet(sql, "INV_INVENTORYITEMMASTER")
        If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
                With AxfpSpread2
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorycode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorydesc")
                    .Row = i + 1
                End With
            Next
        End If
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
        Text_SLCode.Text = ""
        Text_SLName.Text = ""
        Cmd_Add.Text = "Add[F7]"
        dtp_effectdate.Value = Date.Now
        dtp_effectdate.Enabled = True
        ToDate.Value = Date.Now
        Dim SQL As String
        AxfpSpread3.ClearRange(1, 1, -1, -1, True)
        SQL = " SELECT distinct ITEMCODE,ITEMNAME,isnull(stockuom,'') as stockuom FROM INV_INVENTORYITEMMASTER WHERE ISNULL(VOID,'')<>'y'"
        '  SQL = SQL & " and category in ( select Categorycode from INVENTORYCATEGORYMASTER )"
        gconnection.getDataSet(SQL, "INV_INVENTORYITEMMASTER")
        If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
                With AxfpSpread3
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("ITEMCODE")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("ITEMNAME")

                    .Row = i + 1

                End With
            Next
        End If
        sqlstring = "  Select isnull(MSupplier,'N') as MSupplier from inv_linksetup"
        gconnection.getDataSet(sqlstring, "inv_linksetup")

        If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
            If (gdataset.Tables("inv_linksetup").Rows(0).Item("MSupplier").ToString() = "Y") Then
                Txt_GLAcCode.Text = ""
                Txt_GLAcDesc.Text = ""
                Txt_GLAcCode.ReadOnly = False
                Txt_GLAcDesc.ReadOnly = False
                Cmd_GLAcCodeHelp.Enabled = True
            Else
                Txt_GLAcCode.Text = "SCRS"
                Txt_GLAcDesc.Text = "SUNDRY CREDITORS"
                Txt_GLAcCode.ReadOnly = True
                Txt_GLAcDesc.ReadOnly = True
                Cmd_GLAcCodeHelp.Enabled = False
            End If
        End If
        Call GetLastNo()
        'Cmb_SLType.SelectedIndex = 0
        Txt_SLcode.Text = ""
        TxtGSTINNO.Text = ""
        Txt_SLName.Text = ""
        Txt_VATNo.Text = ""
        Txt_CSTNo.Text = ""
        Txt_TINNo.Text = ""
        Txt_GRNNo.Text = ""
        Txt_PANNo.Text = ""
        txt_email.Text = ""
        Txt_CreditPeriod.Text = 0
        Txt_ContactPerson.Text = ""
        Txt_Address1.Text = ""
        Txt_Address2.Text = ""
        Txt_Address3.Text = ""
        txt_City.Text = ""
        Txt_State.Text = ""
        Txt_Pin.Text = ""
        Txt_PhoneNo.Text = ""
        Txt_CellNo.Text = ""
        Rdo_TDSNo.Checked = True
        Txt_TDSPercentage.Text = ""
        Rdo_WorksContractNo.Checked = True
        Txt_WorksContractPercentage.Text = ""
        Rdo_PurchaseTaxNo.Checked = True
        Txt_PurchaseTaxPercentage.Text = ""
        Rdo_ESINo.Checked = True
        Txt_EsiPercentage.Text = ""
        Rdo_PFNo.Checked = True
        Txt_PfPercentage.Text = ""
        Lbl_Freeze.Visible = False
        'Txt_GLAcCode.Enabled = True
        Me.Text_SLCode.Enabled = True
        'Txt_GLAcCode.Focus()
        Me.Cmb_SLType.Enabled = True
        Me.Cmd_Add.Text = "Add[F7]"
        Me.Cmd_Freeze.Enabled = False
        Me.Cmd_Add.Enabled = True
        ' Cmb_SLType.Focus()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
        txt_scode.Text = ""
        txt_sname.Text = ""
        AxfpSpread2.ClearRange(1, 1, -1, -1, True)
        SQL = " SELECT distinct categorycode,categorydesc FROM INVENTORYCATEGORYMASTER WHERE ISNULL(freeze,'')<>'y'  "
        gconnection.getDataSet(SQL, "INV_INVENTORYITEMMASTER")
        If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
                With AxfpSpread2
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorycode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorydesc")
                    .Row = i + 1
                End With
            Next
        End If
        Txt_SLcode.Focus()
        TabControl1.SelectedIndex = 0
    End Sub


    Private Sub addoperation(sender As Object, e As EventArgs)
        Dim sqlstring As String
        Dim Insert(0) As String
        Insert(0) = Nothing
        For i As Integer = 1 To AxfpSpread3.DataRowCnt
            With AxfpSpread3
                .Row = i
                .Col = 3
                If Val(Trim(AxfpSpread3.Text)) > 0 Then
                    sqlstring = "Insert into Invitem_VendorMaster(vendorcode,VENDORNAME,itemcode,itemname,contractyn,rate,uom,adduser,adddate,freeze,fromDate,todate)"
                    sqlstring = sqlstring + " values( '" + Text_SLCode.Text + "','" + Text_SLName.Text + "',"
                    AxfpSpread3.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread3.Text + "',"
                    AxfpSpread3.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread3.Text + "',"
                    AxfpSpread3.Col = 4
                    sqlstring = sqlstring + " '" + AxfpSpread3.Text + "',"

                    AxfpSpread3.Col = 5
                    sqlstring = sqlstring + "   '" + AxfpSpread3.Text + "',"
                    AxfpSpread3.Col = 6
                    If AxfpSpread3.Text = "" Then
                        AxfpSpread3.Col = 1
                        MessageBox.Show("Plz select UOM for Itemcode : " + AxfpSpread3.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                    sqlstring = sqlstring + "   '" + AxfpSpread3.Text + "',"

                    sqlstring = sqlstring + " '" + gUsername + "', getdate() ,'N','" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "','" & Format(CDate(ToDate.Value), "yyyy/MM/dd") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                End If
            End With
        Next
        Dim tdsflag, workscontractflag, purchaseflag, esiflag, pfflag As String
        Dim tdssection, workscontractsection, purchasesection, esisection, pfsection As String
        Dim tdspercentage, workscontractpercentage, purchasepercentage, esipercentage, pfpercentage As Double
        Dim opdebits, opcredits As Double
        Dim cldebits, clcredits As Double
        If Rdo_TDSYes.Checked = True Then
            If Trim(Cbo_TDSSection.Text) <> "" Then
                tdsflag = "Y"
                tdssection = Trim(Cbo_TDSSection.Text)
                tdspercentage = Trim(Txt_TDSPercentage.Text)
            End If
        Else
            tdsflag = "N"
            tdssection = ""
            tdspercentage = 0
        End If
        If Rdo_WorksContractYes.Checked = True Then
            If Trim(Cbo_WorksContractSection.Text) <> "" Then
                workscontractflag = "Y"
                workscontractsection = Trim(Cbo_WorksContractSection.Text)
                workscontractpercentage = Trim(Txt_WorksContractPercentage.Text)
            End If
        Else
            workscontractflag = "N"
            workscontractsection = ""
            workscontractpercentage = 0
        End If
        If Rdo_PurchaseTaxYes.Checked = True Then
            If Trim(Cbo_PurchaseTaxSection.Text) <> "" Then
                purchaseflag = "Y"
                purchasesection = Trim(Cbo_PurchaseTaxSection.Text)
                purchasepercentage = Trim(Txt_PurchaseTaxPercentage.Text)
            End If
        Else
            purchaseflag = "N"
            purchasesection = ""
            purchasepercentage = 0
        End If
        If Rdo_ESIYes.Checked = True Then
            If Trim(Cbo_EsiSection.Text) <> "" Then
                esiflag = "Y"
                esisection = Trim(Cbo_EsiSection.Text)
                esipercentage = Trim(Txt_EsiPercentage.Text)
            End If
        Else
            esiflag = "N"
            esisection = ""
            esipercentage = 0
        End If
        If Rdo_PFYes.Checked = True Then
            If Trim(Cbo_PfSection.Text) <> "" Then
                pfflag = "Y"
                pfsection = Trim(Cbo_PfSection.Text)
                pfpercentage = Trim(Txt_PfPercentage.Text)
            End If
        Else
            pfflag = "N"
            pfsection = ""
            pfpercentage = 0
        End If

        Insert(0) = Nothing

        If Cmd_Add.Text = "Add[F7]" Then
            sqlstring = "INSERT INTO accountssubledgermaster(accode, acdesc, sltype, slcode,slname,Sldesc,contactperson, address1, address2, address3, city, state, pin, phoneno, cellno,emailid, vatno,cstno,tinno,grnno,panno, "
            sqlstring = sqlstring & " creditperiod, opdebits, opcredits, cldebits, clcredits, tdsflag, tdssection,tdspercentage, workscontractflag,workscontractsection, workscontractpercentage,purchaseflag, purchasesection,purchasepercentage,esiflag, esisection, esipercentage,pfflag, pfsection,pfpercentage,"
            sqlstring = sqlstring & " adduserid, adddatetime, updateuserid, updatedatetime, "
            sqlstring = sqlstring & " freezeflag, "
            sqlstring = sqlstring & " freezeuserid, freezedatetime ,GSTINNO) "
            sqlstring = sqlstring & " values ('" & Trim(Txt_GLAcCode.Text) & "' , '" & Trim(Txt_GLAcDesc.Text) & "' , '" & Trim(Cmb_SLType.Text) & "' , '"
            sqlstring = sqlstring & Trim(Txt_SLcode.Text) & "' , '" & Trim(Txt_SLName.Text) & "' , '" & Trim(Txt_SLName.Text) & "' , '" & Trim(Txt_ContactPerson.Text) & "' , '"
            sqlstring = sqlstring & Trim(Txt_Address1.Text) & "' , '" & Trim(Txt_Address2.Text) & "' , '" & Trim(Txt_Address3.Text) & "' , '"
            sqlstring = sqlstring & Trim(txt_City.Text) & "' , '" & Trim(Txt_State.Text) & "' , " & Val(Txt_Pin.Text) & ", "

            sqlstring = sqlstring & Val(Txt_PhoneNo.Text) & "," & Val(Txt_CellNo.Text) & ", '" & Trim(txt_email.Text) & "' , '" & Trim(Txt_VATNo.Text) & "' , '"
            sqlstring = sqlstring & Trim(Txt_CSTNo.Text) & "' , '" & Trim(Txt_TINNo.Text) & "' , '" & Trim(Txt_GRNNo.Text) & "' , '"
            sqlstring = sqlstring & Trim(Txt_PANNo.Text) & "' ,"
            sqlstring = sqlstring & Trim(Txt_CreditPeriod.Text) & " , "

            sqlstring = sqlstring & opdebits & " , " & opcredits & " , " & cldebits & " , " & clcredits & " , '"

            sqlstring = sqlstring & tdsflag & "' , '" & tdssection & "' , " & tdspercentage & " , '"
            sqlstring = sqlstring & workscontractflag & "' , '" & workscontractsection & "' ," & workscontractpercentage & ", '"
            sqlstring = sqlstring & purchaseflag & "' , '" & purchasesection & "' ," & purchasepercentage & ", '"
            sqlstring = sqlstring & esiflag & "' , '" & esisection & "' ," & esipercentage & ", '"
            sqlstring = sqlstring & pfflag & "' , '" & pfsection & "' ," & pfpercentage & ", '"
            sqlstring = sqlstring & gUsername & "' , '" & Format(DateValue(Now), "dd/MMM/yyyy") & "' , '' , '', "
            sqlstring = sqlstring & "'N' , '' , '','" & Trim(TxtGSTINNO.Text) & "' )"
            ' vconn.dataOperation(1, sqlstring)
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
        End If
        Insert(0) = Nothing
        For i As Integer = 1 To AxfpSpread2.DataRowCnt
            With AxfpSpread2
                .Col = 3
                .Row = i
                If Val(Trim(.Text)) > 0 Then
                    sqlstring = "Insert into Invvendor_CategoryMaster(vendorcode,VENDORNAME,categorycode,categorydesc,adduser,adddate,freeze)"
                    sqlstring = sqlstring + " values( '" + txt_scode.Text + "','" + txt_sname.Text + "',"
                    AxfpSpread2.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread2.Text + "',"
                    AxfpSpread2.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread2.Text + "','" + gUsername + "', getdate() ,'N')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                End If
            End With
        Next
        gconnection.MoreTrans(Insert)
        Call Cmd_Clear_Click(sender, e)
    End Sub

    Private Sub updateoperation(sender As Object, e As EventArgs)
        Dim Insert(0) As String
        Dim boolchk As Boolean
        Dim tdsflag, workscontractflag, purchaseflag, esiflag, pfflag As String
        Dim tdssection, workscontractsection, purchasesection, esisection, pfsection As String
        Dim tdspercentage, workscontractpercentage, purchasepercentage, esipercentage, pfpercentage As Double
        Dim opdebits, opcredits As Double
        Dim cldebits, clcredits As Double
        If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
            If Me.Lbl_Freeze.Visible = True Then
                MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                boolchk = False
            End If
            boolchk = True
        End If
        If boolchk = False Then Exit Sub

        If Rdo_TDSYes.Checked = True Then
            If Trim(Cbo_TDSSection.Text) <> "" Then
                tdsflag = "Y"
                tdssection = Trim(Cbo_TDSSection.Text)
                tdspercentage = Trim(Txt_TDSPercentage.Text)
            End If
        Else
            tdsflag = "N"
            tdssection = ""
            tdspercentage = 0
        End If
        If Rdo_WorksContractYes.Checked = True Then
            If Trim(Cbo_WorksContractSection.Text) <> "" Then
                workscontractflag = "Y"
                workscontractsection = Trim(Cbo_WorksContractSection.Text)
                workscontractpercentage = Trim(Txt_WorksContractPercentage.Text)
            End If
        Else
            workscontractflag = "N"
            workscontractsection = ""
            workscontractpercentage = 0
        End If
        If Rdo_PurchaseTaxYes.Checked = True Then
            If Trim(Cbo_PurchaseTaxSection.Text) <> "" Then
                purchaseflag = "Y"
                purchasesection = Trim(Cbo_PurchaseTaxSection.Text)
                purchasepercentage = Trim(Txt_PurchaseTaxPercentage.Text)
            End If
        Else
            purchaseflag = "N"
            purchasesection = ""
            purchasepercentage = 0
        End If
        If Rdo_ESIYes.Checked = True Then
            If Trim(Cbo_EsiSection.Text) <> "" Then
                esiflag = "Y"
                esisection = Trim(Cbo_EsiSection.Text)
                esipercentage = Trim(Txt_EsiPercentage.Text)
            End If
        Else
            esiflag = "N"
            esisection = ""
            esipercentage = 0
        End If
        If Rdo_PFYes.Checked = True Then
            If Trim(Cbo_PfSection.Text) <> "" Then
                pfflag = "Y"
                pfsection = Trim(Cbo_PfSection.Text)
                pfpercentage = Trim(Txt_PfPercentage.Text)
            End If
        Else
            pfflag = "N"
            pfsection = ""
            pfpercentage = 0
        End If

        Dim sql As String = "insert into Invitem_VendorMaster_log select * from Invitem_VendorMaster where vendorcode='" + Text_SLCode.Text + "' AND cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE"
        '  ReDim Preserve Insert(Insert.Length)
        Insert(0) = sql
        sql = " delete from Invitem_VendorMaster where vendorcode='" + Text_SLCode.Text + "'  AND cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql

        For i As Integer = 1 To AxfpSpread3.DataRowCnt
            With AxfpSpread3
                .Row = i
                .Col = 3
                If Val(Trim(.Text)) > 0 Then
                    Dim sqlstring As String = "Insert into Invitem_VendorMaster(vendorcode,VENDORNAME,itemcode,itemname,contractyn,rate,uom,adduser,adddate,freeze,fromDate,todate)"
                    sqlstring = sqlstring + " values( '" + Text_SLCode.Text + "','" + Text_SLName.Text + "',"
                    AxfpSpread3.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread3.Text + "',"
                    AxfpSpread3.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread3.Text + "',"
                    AxfpSpread3.Col = 4
                    sqlstring = sqlstring + " '" + AxfpSpread3.Text + "',"

                    AxfpSpread3.Col = 5
                    sqlstring = sqlstring + "   '" + AxfpSpread3.Text + "',"

                    AxfpSpread3.Col = 6
                    If AxfpSpread3.Text = "" Then
                        AxfpSpread3.Col = 1
                        MessageBox.Show("Plz select UOM for Itemcode : " + AxfpSpread3.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If

                    sqlstring = sqlstring + "   '" + AxfpSpread3.Text + "',"

                    sqlstring = sqlstring + " '" + gUsername + "', getdate() ,'N','" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "','" & Format(CDate(ToDate.Value), "yyyy/MM/dd") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                End If
            End With
        Next
        '   gconnection.MoreTrans(Insert)
        ' clearoperation()
        sqlstring = "update accountssubledgermaster set "
        sqlstring = sqlstring & " slname='" & Trim(Txt_SLName.Text) & "',sldesc='" & Trim(Txt_SLName.Text) & "',"
        sqlstring = sqlstring & " vatno= '" & Trim(Txt_VATNo.Text) & "', cstno='" & Trim(Txt_CSTNo.Text) & "', emailid='" & Trim(txt_email.Text) & "', tinno='" & Trim(Txt_TINNo.Text) & "',"
        sqlstring = sqlstring & " grnno= '" & Trim(Txt_GRNNo.Text) & "', panno='" & Trim(Txt_PANNo.Text) & "',"
        sqlstring = sqlstring & " creditperiod= '" & Trim(Txt_CreditPeriod.Text) & "',"
        'Sriram
        ' sqlstring = sqlstring & "opdebits = " & opdebits & ", opcredits= " & opcredits & ","

        sqlstring = sqlstring & " contactperson= '" & Trim(Txt_ContactPerson.Text) & "', address1='" & Trim(Txt_Address1.Text) & "', address2='" & Trim(Txt_Address2.Text) & "',"
        sqlstring = sqlstring & " address3= '" & Trim(Txt_Address3.Text) & "', city='" & Trim(txt_City.Text) & "', state='" & Trim(Txt_State.Text) & "',"
        sqlstring = sqlstring & " pin= " & Val(Txt_Pin.Text) & ", phoneno=" & Val(Txt_PhoneNo.Text) & ", cellno=" & Val(Txt_CellNo.Text) & ","

        sqlstring = sqlstring & "tdsflag = '" & tdsflag & "', tdssection = '" & tdssection & "', tdspercentage = " & tdspercentage & ","
        sqlstring = sqlstring & "workscontractflag = '" & workscontractflag & "', workscontractsection = '" & workscontractsection & "', workscontractpercentage = " & workscontractpercentage & ","
        sqlstring = sqlstring & "purchaseflag = '" & purchaseflag & "', purchasesection = '" & purchasesection & "', purchasepercentage = " & purchasepercentage & ","
        sqlstring = sqlstring & "esiflag = '" & esiflag & "', esisection = '" & esisection & "', esipercentage = " & esipercentage & ","
        sqlstring = sqlstring & "pfflag = '" & pfflag & "', pfsection = '" & pfsection & "', pfpercentage = " & pfpercentage & ","

        sqlstring = sqlstring & "adduserid ='',adddatetime ='', updateuserid ='" & gUsername & "', updatedatetime = '" & Format(DateValue(Now), "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & ", freezeflag = 'N', freezeuserid = '', freezedatetime = '', accode='" & Trim(Txt_GLAcCode.Text) & "', acdesc='" & Trim(Txt_GLAcDesc.Text) & "',GSTINNO='" & Trim(TxtGSTINNO.Text) & "' "
        sqlstring = sqlstring & " where  Slcode='" & Trim(Txt_SLcode.Text) & "' and accode='" & Trim(Txt_GLAcCode.Text) & "'"
        ' vconn.dataOperation(2, sqlstring)
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sqlstring
        Txt_GLAcCode.Enabled = True
        Txt_GLAcCode.Focus()
        sql = "insert into Invvendor_CategoryMaster_log(vendorcode,VENDORNAME,categorycode,categorydesc,UPDATEuser,UPDATEdate,freeze) select vendorcode,VENDORNAME,categorycode,categorydesc,adduser,adddate,freeze from Invvendor_CategoryMaster where vendorcode='" + txt_scode.Text + "'"

        '  ReDim Preserve Insert(Insert.Length)
        Insert(0) = sql
        sql = " delete from Invvendor_CategoryMaster where vendorcode='" + txt_scode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql

        For i As Integer = 1 To AxfpSpread2.DataRowCnt
            With AxfpSpread2
                .Row = i
                .Col = 3
                If Val(Trim(.Text)) > 0 Then
                    Dim sqlstring As String = "Insert into Invvendor_CategoryMaster(vendorcode,VENDORNAME,categorycode,categorydesc,adduser,adddate,freeze)"
                    sqlstring = sqlstring + " values( '" + txt_scode.Text + "','" + txt_sname.Text + "',"
                    AxfpSpread2.Col = 1
                    sqlstring = sqlstring + " '" + AxfpSpread2.Text + "',"
                    AxfpSpread2.Col = 2
                    sqlstring = sqlstring + "   '" + AxfpSpread2.Text + "','" + gUsername + "', getdate() ,'N')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If
            End With
        Next
        gconnection.MoreTrans(Insert)
        Call Cmd_Clear_Click(sender, e)

    End Sub

    Private Sub voidoperation()
        Dim Insert(0) As String

        Dim sql As String = "insert into InvITEM_VendorMaster_log(vendorcode,VENDORNAME,itemcode,itemname,UPDATEuser,UPDATEdate,freeze,fromdate,todate) select vendorcode,VENDORNAME,itemcode,itemname,adduser,adddate,freeze,fromdate,todate from InvITEM_VendorMaster where vendorcode='" + Text_SLCode.Text + "'  AND cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        sql = " delete from InvITEM_VendorMaster where vendorcode='" + Text_SLCode.Text + "'  AND cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        gconnection.MoreTrans(Insert)
        Dim status As Integer
        Dim sqlstring As String
        If Cmd_Freeze.Text = "Void[F10]" Then
            If UCase(Me.Txt_GLAcCode.Text) = gDebitors Then
                MsgBox("Sundry Debtors Can Not Be Added Through Sub Ledger", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            status = MsgBox("ARE U SURE U WANT TO FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If status = 1 Then
                sqlstring = "update accountssubledgermaster set freezeflag = 'Y',FreezeUserId='" & gUsername & "',FreezeDateTime='" & Format(DateValue(Now), "dd/MMM/yyyy") & "' where accode = '" & Trim(Txt_GLAcCode.Text) & "' And Slcode='" & Trim(Me.Txt_SLcode.Text) & "'"
                vconn.dataOperation(2, sqlstring)
                Lbl_Freeze.Text = "RECORD FREEZED"
                Lbl_Freeze.Visible = True
                Cmd_Freeze.Text = "&Unfreeze[F8]"
                Cmd_Add.Enabled = False
            Else
                Exit Sub
            End If
        Else
            status = MsgBox("ARE U SURE U WANT TO UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If status = 1 Then
                sqlstring = "update accountssubledgermaster set freezeflag = 'N',FreezeUserId='',FreezeDateTime='' where accode = '" & Trim(Txt_GLAcCode.Text) & "' And Slcode='" & Trim(Me.Txt_SLcode.Text) & "'"
                vconn.dataOperation(2, sqlstring)
                Lbl_Freeze.Text = "RECORD UNFREEZED"
                Lbl_Freeze.Visible = False
                Cmd_Freeze.Text = "Void[F10]"
            Else
                Exit Sub
            End If
        End If
        sql = "insert into Invvendor_CategoryMaster_log(vendorcode,VENDORNAME,categorycode,categorydesc,UPDATEuser,UPDATEdate,freeze) select vendorcode,VENDORNAME,categorycode,categorydesc,adduser,adddate,freeze from Invvendor_CategoryMaster where vendorcode='" + txt_scode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        sql = " delete from Invvendor_CategoryMaster where vendorcode='" + txt_scode.Text + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        gconnection.MoreTrans(Insert)
    End Sub
    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        If Cmd_Add.Text = "Add[F7]" Then
            Call Mevalidate() '''--->Check Validation
            If Mevalidate() = False Then Exit Sub
            addoperation(sender, e)
        Else
            Call Mevalidate() '''--->Check Validation
            If Mevalidate() = False Then Exit Sub
            updateoperation(sender, e)

        End If
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Call Mevalidate() '''--->Check Validation
        If Mevalidate() = False Then Exit Sub
        voidoperation()
        Cmd_Clear_Click(sender, e)
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Txt_SLCode_Validated(sender As Object, e As EventArgs) Handles Text_SLCode.Validated
        Dim sqlstring As String
        sqlstring = "select isnull(accode,'') as accode,isnull(acdesc,'') as acdesc,isnull(slname,'') as slname,isnull(vatno,'') as vatno,isnull(cstno,'') as cstno,isnull(emailid,'') as emailid,isnull(tinno,'') as tinno,isnull(grnno,'') as grnno,isnull(panno,'') as panno,isnull(creditperiod,0) as creditperiod,isnull(opdebits,0) as opdebits,isnull(opcredits,0) as opcredits,isnull(cldebits,0) as cldebits,isnull(clcredits,0) as clcredits,isnull(Sltype,'') as Sltype,isnull(contactperson,'') as contactperson,isnull(address1,'') as address1,isnull(address2,'') as address2,isnull(address3,'') as address3,isnull(city,'') as city,isnull(state,'') as state,isnull(pin,'') as pin,isnull(phoneno,'') as phoneno,isnull(cellno,'') as cellno,isnull(tdsflag,'') as tdsflag,isnull(tdssection,'') as tdssection,isnull(tdspercentage,0) as tdspercentage,isnull(workscontractflag,'') as workscontractflag,isnull(workscontractsection,'') as workscontractsection,isnull(workscontractpercentage,0) as workscontractpercentage,isnull(purchaseflag,'') as purchaseflag,isnull(purchasesection,'') as purchasesection,isnull(purchasepercentage,0) as purchasepercentage,isnull(esiflag,'') as esiflag,isnull(esisection,'') as esisection,isnull(esipercentage,0) as esipercentage,isnull(pfflag,'') as pfflag,isnull(pfsection,'') as pfsection,isnull(pfpercentage,0) as pfpercentage,isnull(freezeflag,'') as freezeflag"
        '        sqlstring = sqlstring & " from accountssubledgermaster where slcode = '" & Trim(Txt_SLCode.Text) & "' and accode = '" & Trim(Txt_GLAcCode.Text) & "'"
        sqlstring = sqlstring & " ,isnull(GSTINNO,'') as GSTINNO from accountssubledgermaster where slcode = '" & Trim(Txt_SLcode.Text) & "' and sltype = '" & Trim(Cmb_SLType.Text) & "'  order by roll "
        vconn.getDataSet(sqlstring, "accountssubledgermaster")
        If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
            Txt_GLAcCode.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("accode")))
            'lbl_ac.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("accode")))
            Txt_GLAcDesc.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("acdesc")))

            Txt_SLName.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname")))
            txt_email.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("emailid")))
            Txt_VATNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("vatno")))
            Txt_CSTNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("cstno")))
            Txt_TINNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("tinno")))
            Txt_GRNNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("grnno")))
            Txt_PANNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("panno")))
            Txt_CreditPeriod.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("creditperiod")))

            'If gdataset.Tables("accountssubledgermaster").Rows(0).Item("opdebits") <> 0 Then
            '    Txt_OpeningBalance.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("opdebits")
            '    Rdo_OpeningBalanceDebit.Checked = True
            'Else
            '    Txt_OpeningBalance.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("opcredits")
            '    Rdo_OpeningBalanceCredit.Checked = True
            'End If

            'If gdataset.Tables("accountssubledgermaster").Rows(0).Item("cldebits") & "" <> 0 Then
            '    Txt_BalanceAsOn.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("cldebits") & ""
            '    Rdo_BalanceAsOnDebit.Checked = True
            'Else
            '    Txt_BalanceAsOn.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("clcredits") & ""
            '    Rdo_BalanceAsOnCredit.Checked = True
            'End If
            Me.Cmb_SLType.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("Sltype")))
            Txt_ContactPerson.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("contactperson")))
            Txt_Address1.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("address1")))
            Txt_Address2.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("address2")))
            Txt_Address3.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("address3")))
            txt_City.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("city")))
            Txt_State.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("state")))
            Txt_Pin.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("pin")))
            Txt_PhoneNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("phoneno")))
            Txt_CellNo.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("cellno")))
            TxtGSTINNO.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("GSTINNO")))

            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("tdsflag") = "Y" Then
                Rdo_TDSYes.Checked = True
                Cbo_TDSSection.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("tdssection")))
                Txt_TDSPercentage.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("tdspercentage")))
            Else
                Rdo_TDSNo.Checked = True
            End If


            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("workscontractflag") = "Y" Then
                Rdo_WorksContractYes.Checked = True
                Cbo_WorksContractSection.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("workscontractsection")))
                Txt_WorksContractPercentage.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("workscontractpercentage")))
            Else
                Rdo_WorksContractNo.Checked = True
            End If


            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("purchaseflag") = "Y" Then
                Rdo_PurchaseTaxYes.Checked = True
                Cbo_PurchaseTaxSection.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("purchasesection")))
                Txt_PurchaseTaxPercentage.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("purchasepercentage")))
            Else
                Rdo_PurchaseTaxNo.Checked = True
            End If


            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("esiflag") = "Y" Then
                Rdo_ESIYes.Checked = True
                Cbo_EsiSection.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("esisection")))
                Txt_EsiPercentage.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("esipercentage")))
            Else
                Rdo_ESINo.Checked = True
            End If

            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("pfflag") = "Y" Then
                Rdo_PFYes.Checked = True
                Cbo_PfSection.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("pfsection")))
                Txt_PfPercentage.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("pfpercentage")))
            Else
                Rdo_PFNo.Checked = True
            End If

            If gdataset.Tables("accountssubledgermaster").Rows(0).Item("freezeflag") = "Y" Then
                Lbl_Freeze.Visible = True
                Cmd_Freeze.Text = "Void[F10]"
                Me.Cmd_Add.Enabled = False
                Me.Cmd_Freeze.Enabled = True
            Else
                Lbl_Freeze.Visible = False
                Cmd_Freeze.Text = "Void[F10]"
                Me.Cmd_Add.Enabled = True
                Me.Cmd_Freeze.Enabled = True
            End If
            Txt_GLAcCode.Enabled = False
            ' Txt_SLcode.Enabled = False
            '   Cmb_SLType.Focus()
            If UCase(Me.Txt_GLAcCode.Text) = gDebitors Then
                Me.Cmd_Add.Enabled = False
                Me.Cmd_Freeze.Enabled = False
            End If
            Cmd_Add.Text = "Update[F7]"
        Else
            '  Me.Txt_SLName.Focus()
        End If
        Dim sql As String
        If UCase(gShortname) = "RSAOI" Then
            sql = "select itemcode,itemname,'1' as check1,ISNULL(contractyn,0) AS contractyn,ISNULL(rate,0) AS RATE,ISNULL(upper(uom),'') AS UOM ,isnull(VENDORNAME,'') as VENDORNAME,isnull(fromDate,'01/Jan/" + gFinancalyearStart + "') as fromDate,isnull(todate,'31/Dec/" + gFinancialyearEnd + "') as toDate from Invitem_VendorMaster where vendorcode='" + Txt_SLcode.Text + "' and isnull(freeze,'')<>'Y'"
            sql = sql + " union all select itemcode,itemname,'0' as check1,'0' as contractyn,'0' rate,isnull(upper(stockuom),'') as uom, '' as VENDORNAME, '01/Jan/" + gFinancalyearStart + "' as fromDate,'31/Dec/" + gFinancialyearEnd + "' as toDate     from INV_INVENTORYITEMMASTER  where itemcode not in (select itemcode from Invitem_VendorMaster where vendorcode='" + Txt_SLcode.Text + "') AND  category IN  (select DISTINCT  categorycode from Invvendor_CategoryMaster WHERE ISNULL(Freeze,'N')<>'Y' AND  vendorcode='" + Txt_SLcode.Text + "')" 'order by itemcode"
        Else
            sql = "select itemcode,itemname,'1' as check1,ISNULL(contractyn,0) AS contractyn,ISNULL(rate,0) AS RATE,ISNULL(upper(uom),'') AS UOM ,isnull(VENDORNAME,'') as VENDORNAME,isnull(fromDate,'01/apr/" + gFinancalyearStart + "') as fromDate,isnull(todate,'31/mar/" + gFinancialyearEnd + "') as toDate from Invitem_VendorMaster where vendorcode='" + Txt_SLcode.Text + "' and isnull(freeze,'')<>'Y'"
            sql = sql + " union all select itemcode,itemname,'0' as check1,'0' as contractyn,'0' rate,isnull(upper(stockuom),'') as uom, '' as VENDORNAME, '01/apr/" + gFinancalyearStart + "' as fromDate,'31/mar/" + gFinancialyearEnd + "' as toDate     from INV_INVENTORYITEMMASTER  where itemcode not in (select itemcode from Invitem_VendorMaster where vendorcode='" + Txt_SLcode.Text + "') AND  category IN  (select DISTINCT  categorycode from Invvendor_CategoryMaster WHERE ISNULL(Freeze,'N')<>'Y' AND  vendorcode='" + Txt_SLcode.Text + "')" 'order by itemcode"
        End If

        ' SQL = " SELECT distinct ITEMCODE,ITEMNAME,'0' as check1  FROM INV_INVENTORYITEMMASTER WHERE ISNULL(VOID,'')<>'y'"
        gconnection.getDataSet(sql, "INV_INVENTORYITEMMASTER")
        If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then

            AxfpSpread3.MaxRows = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count


            '  AxfpSpread3.ClearRange(1, 1, -1, -1, True)

            sql = "  SELECT distinct slcode,Slname FROM accountssubledgermaster where slcode='" + Txt_SLcode.Text + "' and sltype='SUPPLIER'"

            gconnection.getDataSet(sql, "inv_linksetup")

            dtp_effectdate.Value = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(0).Item("fromDate")
            '  dtp_effectdate.Enabled = False
            ToDate.Value = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(0).Item("todate")
            If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
                Txt_SLName.Text = gdataset.Tables("inv_linksetup").Rows(0).Item("Slname")
            End If

            For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
                With AxfpSpread3
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("ITEMCODE")
                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("ITEMNAME")
                    .Row = i + 1
                    .Col = 3
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("check1")
                    If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("check1") = "1") Then
                        Txt_SLName.Text = Trim(gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("VENDORNAME"))
                        Cmd_Add.Text = "Update[F7]"
                    End If
                    .Row = i + 1
                    .Col = 4
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("contractyn")
                    .Row = i + 1
                    .Col = 5
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("rate")
                    .Row = i + 1
                    '.Col = 6
                    'sql = "select distinct upper(tranuom) as tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("itemcode")) + "'"
                    'gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                    'AxfpSpread3.TypeComboBoxClear(6, i + 1)
                    'For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                    '    AxfpSpread3.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom").ToUpper())
                    '    AxfpSpread3.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom")).ToUpper()
                    'Next Z
                    .Col = 6
                    .TypeComboBoxString = Trim(gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("uom").ToUpper())
                    .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("uom").ToUpper()
                End With
            Next
        End If
        sql = "select distinct categorycode,categorydesc,'1' as check1,isnull(VENDORNAME,'') as VENDORNAME  from Invvendor_CategoryMaster where vendorcode='" + Txt_SLcode.Text + "'"
        sql = sql + " union all select categorycode,categorydesc,'0' as check1,'' as VENDORNAME from inventorycategorymaster where categorycode not in (select categorycode from Invvendor_CategoryMaster where vendorcode='" + Txt_SLcode.Text + "')"
        gconnection.getDataSet(sql, "Inv_VendorMaster")

        If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then

            AxfpSpread2.MaxRows = gdataset.Tables("Inv_VendorMaster").Rows.Count
            'AxfpSpread1.ClearRange(1, 1, -1, -1, True)
            Txt_SLName.Text = Trim(gdataset.Tables("Inv_VendorMaster").Rows(0).Item("VENDORNAME"))
            sql = "  SELECT distinct slcode,Slname FROM accountssubledgermaster where slcode='" + Txt_SLcode.Text + "' and  SLTYPE='SUPPLIER' "
            gconnection.getDataSet(sql, "inv_linksetup")

            If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
                Txt_SLName.Text = gdataset.Tables("inv_linksetup").Rows(0).Item("Slname")
            End If

            For i As Integer = 0 To gdataset.Tables("Inv_VendorMaster").Rows.Count - 1

                With AxfpSpread2
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("categorycode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("categorydesc")
                    .Row = i + 1

                    .Col = 3
                    .Text = gdataset.Tables("Inv_VendorMaster").Rows(i).Item("check1")
                    If (gdataset.Tables("Inv_VendorMaster").Rows(i).Item("check1") = "1") Then
                        Cmd_Add.Text = "Update[F7]"
                    End If

                End With
            Next
        End If



    End Sub

    Private Sub AxfpSpread3_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread3.KeyDownEvent
        If e.keyCode = Keys.F1 Then
            Dim search As New frmSearch
            search.farPoint = AxfpSpread3
            search.Text = "Item Search"
            search.ShowDialog(Me)
            Exit Sub
        End If
        If e.keyCode = Keys.Enter Then
            AxfpSpread3.Row = AxfpSpread3.ActiveRow
            If AxfpSpread3.ActiveCol = 5 Then
                AxfpSpread3.Col = 5
                If (Val(AxfpSpread3.Text) <> 0) Then
                    AxfpSpread3.SetActiveCell(6, AxfpSpread3.ActiveRow)
                Else
                    AxfpSpread3.SetActiveCell(5, AxfpSpread3.ActiveRow)
                End If
            ElseIf AxfpSpread3.ActiveCol = 4 Then
                AxfpSpread3.Col = 4
                If Val(AxfpSpread3.Text) = 1 Then
                    AxfpSpread3.SetActiveCell(5, AxfpSpread3.ActiveRow)
                Else
                    AxfpSpread3.SetActiveCell(3, AxfpSpread3.ActiveRow + 1)
                End If
            ElseIf AxfpSpread3.ActiveCol = 6 Then
                AxfpSpread3.Col = 6
                If AxfpSpread3.Text = "" Then
                    AxfpSpread3.SetActiveCell(6, AxfpSpread3.ActiveRow)
                Else
                    AxfpSpread3.SetActiveCell(3, AxfpSpread3.ActiveRow + 1)
                End If
            ElseIf AxfpSpread3.ActiveCol = 3 Then
                AxfpSpread3.Col = 3
                If Val(AxfpSpread3.Text) = 1 Then
                    AxfpSpread3.SetActiveCell(4, AxfpSpread3.ActiveRow)
                Else
                    AxfpSpread3.SetActiveCell(3, AxfpSpread3.ActiveRow + 1)
                End If
            End If
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub AxfpSpread3_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread3.LeaveCell

        If AxfpSpread3.ActiveCol = 4 Then

            If AxfpSpread3.Text <> "" Then
                If AxfpSpread3.Text = 1 Then
                    AxfpSpread3.SetActiveCell(5, AxfpSpread3.ActiveRow)

                End If
            End If


        End If
    End Sub

    Private Sub Txt_SLCode_KeyDown(sender As Object, e As KeyEventArgs) Handles Text_SLCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Text_SLCode.Text <> "" Then
                Txt_SLCode_Validated(sender, e)
            Else
                'Call Cmd_SLCodeHelp()
                Call Cmd_SLCodeHelp_Click(Text_SLCode, e)
            End If
        End If
    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        'Dim rViewer As New Viewer
        'Dim sqlstring, SSQL As String
        'Dim r As New Rpt_VendorItemTagging
        'If Text_SLCode.Text = "" Then
        '    sqlstring = "SELECT * FROM Invitem_VendorMaster WHERE ISNULL(FREEZE,'n')<>'Y'  ORDER BY AUTOID "
        'Else
        '    sqlstring = "SELECT * FROM Invitem_VendorMaster WHERE vendorcode='" & Text_SLCode.Text & "' AND ISNULL(FREEZE,'n')<>'Y'  AND cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE ORDER BY AUTOID "
        'End If

        'gconnection.getDataSet(sqlstring, "Inv_Product_Conversion")
        'If gdataset.Tables("Inv_Product_Conversion").Rows.Count > 0 Then

        '    rViewer.ssql = sqlstring
        '    rViewer.Report = r
        '    rViewer.TableName = "Inv_Product_Conversion"
        '    Dim textobj1 As TextObject
        '    textobj1 = r.ReportDefinition.ReportObjects("Text13")
        '    textobj1.Text = MyCompanyName
        '    Dim textobj2 As TextObject
        '    textobj2 = r.ReportDefinition.ReportObjects("Text21")
        '    textobj2.Text = gUsername
        '    rViewer.Show()

        'Else
        '    MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        'End If
        'Dim FRM As New ReportDesigner
        'If Text_SLCode.Text.Length > 0 Then
        '    tables = " FROM accountssubledgermaster WHERE slcode ='" & Text_SLCode.Text & "' AND ACCODE='" + Txt_GLAcCode.Text + "'"
        'Else
        '    tables = "FROM accountssubledgermaster WHERE ACCODE='" + Txt_GLAcCode.Text + "'"
        'End If
        'Gheader = "SUBLEDGER DETAILS"
        'FRM.DataGridView1.ColumnCount = 2
        'FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        'FRM.DataGridView1.Columns(0).Width = 300
        'FRM.DataGridView1.Columns(1).Name = "SIZE"
        'FRM.DataGridView1.Columns(1).Width = 100

        'Dim ROW As String() = New String() {"accode", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"acdesc", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"slcode", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"sldesc", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"sldesc", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"Freezeflag", "4"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"adduserid", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"adddatetime", "11"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"updateuserid", "20"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"updatedatetime", "11"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'Dim CHK As New DataGridViewCheckBoxColumn()
        'FRM.DataGridView1.Columns.Insert(0, CHK)
        'CHK.HeaderText = "CHECK"
        'CHK.Name = "CHK"
        'FRM.ShowDialog(Me)
        Dim str As String
        Dim Viewer As New Viewer
        Dim r As New Rpt_AccountsSubLedgerMaster

        str = "SELECT * FROM VW_VENDORDETAILS   order by sldesc  "
        If chk_excel.Checked = True Then
            Dim exp As New exportexcel
            exp.Show()
            Call exp.export(str, "VENDOR MASTER ", "")
        Else
            Viewer.ssql = str
            Viewer.Report = r
            Viewer.TableName = "ACCOUNTSSUBLEDGERMASTER"

            Dim TXTOBJ11 As TextObject
            TXTOBJ11 = r.ReportDefinition.ReportObjects("TEXT11")
            TXTOBJ11.Text = gCompanyname

            Dim TXTOBJ16 As TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("TEXT16")
            TXTOBJ16.Text = "User Name : " & gUsername

            'Dim TXTOBJ14 As TextObject
            'TXTOBJ14 = r.ReportDefinition.ReportObjects("TEXT14")
            'TXTOBJ14.Text = "Accounting Period : " & Format(gFinancialyearStart, "dd-MM-yyyy") & " - " & Format(gFinancialyearEnding, "dd-MM-yyyy")
            'Dim t1 As TextObject
            't1 = r.ReportDefinition.ReportObjects("Text17")
            't1.Text = gCompanyAddress(0)
            'Dim t2 As TextObject
            't2 = r.ReportDefinition.ReportObjects("Text18")
            't2.Text = gCompanyAddress(1)
            Viewer.Show()
        End If


    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub dtp_effectdate_Validated(sender As Object, e As EventArgs) Handles dtp_effectdate.Validated
        Dim sql As String = "select * from Invitem_VendorMaster where vendorcode='" + Text_SLCode.Text + "' and isnull(freeze,'')<>'Y' AND cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE"
        gconnection.getDataSet(sql, "Invitem_VendorMaster")
        If gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0 Then
            dtp_effectdate.Value = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("fromDate")

            ToDate.Value = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("todate")
            Cmd_Add.Text = "UPDATE[F7]"
            If UCase(gShortname) = "RSAOI" Then
                sql = "select itemcode,itemname,'1' as check1,ISNULL(contractyn,0) AS contractyn,ISNULL(rate,0) AS RATE,ISNULL(uom,'') AS UOM ,isnull(VENDORNAME,'') as VENDORNAME,isnull(fromDate,'01/Jan/" + gFinancalyearStart + "') as fromDate,isnull(todate,'31/Dec/" + gFinancialyearEnd + "') as toDate from Invitem_VendorMaster where vendorcode='" + Text_SLCode.Text + "' and isnull(freeze,'')<>'Y'  and cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date) between fromdate and todate"
                sql = sql + " union all select itemcode,itemname,'0' as check1,'0' as contractyn,'0' rate,isnull(stockuom,'') as uom, '' as VENDORNAME, '01/apr/" + gFinancalyearStart + "' as fromDate,'31/mar/" + gFinancialyearEnd + "' as toDate     from INV_INVENTORYITEMMASTER where itemcode not in (select itemcode from Invitem_VendorMaster where vendorcode='" + Text_SLCode.Text + "'  and cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date) between fromdate and todate) " 'order by itemcode"

            Else
                sql = "select itemcode,itemname,'1' as check1,ISNULL(contractyn,0) AS contractyn,ISNULL(rate,0) AS RATE,ISNULL(uom,'') AS UOM ,isnull(VENDORNAME,'') as VENDORNAME,isnull(fromDate,'01/apr/" + gFinancalyearStart + "') as fromDate,isnull(todate,'31/mar/" + gFinancialyearEnd + "') as toDate from Invitem_VendorMaster where vendorcode='" + Text_SLCode.Text + "' and isnull(freeze,'')<>'Y'  and cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date) between fromdate and todate"
                sql = sql + " union all select itemcode,itemname,'0' as check1,'0' as contractyn,'0' rate,isnull(stockuom,'') as uom, '' as VENDORNAME, '01/apr/" + gFinancalyearStart + "' as fromDate,'31/mar/" + gFinancialyearEnd + "' as toDate     from INV_INVENTORYITEMMASTER where itemcode not in (select itemcode from Invitem_VendorMaster where vendorcode='" + Text_SLCode.Text + "'  and cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date) between fromdate and todate) " 'order by itemcode"

            End If

            ' SQL = " SELECT distinct ITEMCODE,ITEMNAME,'0' as check1  FROM INV_INVENTORYITEMMASTER WHERE ISNULL(VOID,'')<>'y'"
            gconnection.getDataSet(sql, "INV_INVENTORYITEMMASTER")
            If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then

                sql = "  SELECT distinct slcode,Slname FROM accountssubledgermaster where slcode='" + Text_SLCode.Text + "' and sltype='SUPPLIER'"

                gconnection.getDataSet(sql, "inv_linksetup")

                dtp_effectdate.Value = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(0).Item("fromDate")
                '  dtp_effectdate.Enabled = False
                ToDate.Value = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(0).Item("todate")
                If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
                    Text_SLName.Text = gdataset.Tables("inv_linksetup").Rows(0).Item("Slname")
                End If

                For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
                    With AxfpSpread3


                        .Row = i + 1
                        .Col = 1
                        .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("ITEMCODE")

                        .Row = i + 1
                        .Col = 2
                        .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("ITEMNAME")
                        .Row = i + 1
                        .Col = 3
                        .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("check1")
                        If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("check1") = "1") Then
                            Text_SLName.Text = Trim(gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("VENDORNAME"))
                            Cmd_Add.Text = "UPDATE[F7]"
                        End If
                        .Row = i + 1
                        .Col = 4
                        .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("contractyn")
                        .Row = i + 1
                        .Col = 5
                        .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("rate")
                        .Row = i + 1
                        .Col = 6
                        sql = "select distinct tranuom as tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("itemcode")) + "'"

                        gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                        AxfpSpread3.TypeComboBoxClear(6, i + 1)
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread3.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread3.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                        Next Z

                        .Col = 6
                        .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("uom")


                    End With
                Next
            End If
        Else
            Cmd_Add.Text = "Add[F7]"
            ToDate.Value = "31/mar/" + gFinancialyearEnd
        End If
    End Sub

    Private Sub ToDate_Validated(sender As Object, e As EventArgs) Handles ToDate.Validated

        If Cmd_Add.Text.ToUpper() = "UPDATE[F7]" Then
            If ToDate.Value < Date.Today Then
                MessageBox.Show("To Date not be less than ToDay", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ToDate.Value = Date.Today
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Cmd_SLCodeHelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT distinct slcode,Slname FROM accountssubledgermaster "
        'M_WhereCondition = " Where Accode='" & Trim(Me.Txt_GLAcCode.Text) & "'"
        M_WhereCondition = " Where sltype='" & Trim(Me.Cmb_SLType.Text) & "'"
        vform.Field = "slcode,slname"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.vFormatstring = "  SUB LEDGER CODE       |SUB LEDGER NAME                                            |"
        vform.vCaption = "SUB LEDGER MASTER HELP"
        vform.KeyPos = 0
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_SLcode.Text = Trim(vform.keyfield & "")
            Call Txt_SLCode_Validated(sender, e)
            ' Txt_SLName.Focus()
        Else
            ' Me.Txt_SLcode.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Txt_GLAcCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_GLAcCode.Validated
        Dim sqlstring As String
        sqlstring = "select * from accountsglaccountmaster where accode = '" & Trim(Txt_GLAcCode.Text) & "' and subledgerflag = 'Y' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
        vconn.getDataSet(sqlstring, "accountsglaccountmaster")
        If gdataset.Tables("accountsglaccountmaster").Rows.Count > 0 Then
            Txt_GLAcDesc.Text = Trim(UCase(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("acdesc")))
        Else
            Me.Txt_GLAcCode.Text = ""
        End If
        If UCase(Me.Txt_GLAcCode.Text) = gCreditors Then
            Me.Cmb_SLType.Text = "SUPPLIER"
            Me.Cmb_SLType.Enabled = False
            Me.Txt_SLcode.Focus()
        Else
            Cmb_SLType.Focus()
        End If
    End Sub
    Private Sub Cmd_GLAcCodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GLAcCodeHelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT accode,acdesc FROM accountsglaccountmaster"
        M_WhereCondition = " where subledgerflag= 'Y' AND ISNULL(FREEZEFLAG,'N') <> 'Y' "
        vform.Field = "accode,acdesc"
        vform.vFormatstring = "  GENERAL LEDGER CODE  | GENERAL LEDGER DESCRIPTION                                        "
        vform.vCaption = "GENERAL LEDGER MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_GLAcCode.Text = Trim(vform.keyfield & "")
            Txt_GLAcDesc.Text = Trim(vform.keyfield1 & "")
            Cmb_SLType.Focus()
            If UCase(Me.Txt_GLAcCode.Text) = gCreditors Then
                Me.Cmb_SLType.Text = "SUPPLIER"
                Me.Cmb_SLType.Enabled = False
            End If
        Else
            Me.Txt_GLAcCode.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Txt_GLAcCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_GLAcCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If (Trim(Txt_GLAcCode.Text)) <> "" Then
                Txt_GLAcCode_Validated(Txt_GLAcCode, e)
            Else
                Call Me.Cmd_GLAcCodeHelp_Click(sender, e)
            End If
            Cmb_SLType.Focus()
        End If
    End Sub
    Private Sub Txt_VATNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_VATNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_CSTNo.Focus()
        End If
    End Sub

    Private Sub Txt_CSTNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CSTNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_TINNo.Focus()
        End If
    End Sub

    Private Sub Txt_TINNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_TINNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_GRNNo.Focus()
        End If
        'getAlphanumeric(e)
        'If Asc(e.KeyChar) = 13 Then
        '    'Rdo_TDSYes.Focus()
        '    CmdAdd.Focus()
        'End If
    End Sub

    Private Sub Txt_GRNNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_GRNNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_PANNo.Focus()
        End If
    End Sub

    Private Sub Txt_PANNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PANNo.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'Txt_CreditPeriod.Focus()
            Txt_ContactPerson.Focus()
        End If
    End Sub
    Private Sub Txt_ContactPerson_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ContactPerson.KeyPress
        getCharater(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_Address1.Focus()
        End If
    End Sub

    Private Sub Txt_Address1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Address1.KeyPress
        'getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_Address2.Focus()
        End If
    End Sub

    Private Sub Txt_Address2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Address2.KeyPress
        'getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_Address3.Focus()
        End If
    End Sub

    Private Sub Txt_Address3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Address3.KeyPress
        'getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            txt_City.Focus()
        End If
    End Sub

    Private Sub Txt_City_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_State.Focus()
        End If
    End Sub

    Private Sub Txt_State_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_State.KeyPress
        getCharater(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_Pin.Focus()
        End If
    End Sub

    Private Sub Txt_Pin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Pin.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_PhoneNo.Focus()
        End If
    End Sub

    Private Sub Txt_PhoneNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PhoneNo.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_CellNo.Focus()
        End If
    End Sub

    Private Sub Txt_CellNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CellNo.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'Rdo_TDSYes.Focus()
            txt_email.Focus()
        End If
    End Sub

    Private Sub Rdo_TDSYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_TDSYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            CBO_TDSECTION.Focus()
        End If
    End Sub

    Private Sub Rdo_TDSNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_TDSNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Rdo_WorksContractNo.Focus()
        End If
    End Sub
    Private Sub Rdo_TDSNo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_TDSNo.CheckedChanged
        Cbo_TDSSection.Visible = False
        Txt_TDSPercentage.Visible = False
        Lbl_tdsp.Visible = False
        lbl_TDSSection.Visible = False
        CBO_TDSECTION.Visible = False
        lbl_TdSection.Visible = False
    End Sub

    Private Sub Rdo_TDSYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_TDSYes.CheckedChanged
        CBO_TDSECTION.Visible = True
        lbl_TdSection.Visible = True
        Cbo_TDSSection.Visible = True
        Txt_TDSPercentage.Visible = True
        Lbl_tdsp.Visible = True
        lbl_TDSSection.Visible = True
        Cbo_TDSSection.Focus()
        If Cbo_TDSSection.Items.Count > 0 Then
            Cbo_TDSSection.SelectedIndex = -1
        End If
    End Sub
    Private Sub FillTdsCode()
        Dim ssql As String
        ssql = "Select TdsCode,Percentage from  accountstdsmaster"
        vconn.getDataSet(ssql, "TDS")
        Dim i As Integer
        If gdataset.Tables("TDS").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("TDS").Rows.Count - 1
                Me.Cbo_TDSSection.Items.Add(gdataset.Tables("TDS").Rows(i).Item("TdsCode"))
            Next i
        End If
    End Sub
    Private Sub FillWorksCode()
        Dim ssql As String
        ssql = "select WorksContractCode,percentage from  accountsworkscontractmaster"
        vconn.getDataSet(ssql, "WORKS")
        Dim i As Integer
        If gdataset.Tables("WORKS").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("WORKS").Rows.Count - 1
                Me.Cbo_WorksContractSection.Items.Add(gdataset.Tables("WORKS").Rows(i).Item("WorksContractCode"))
            Next i
        End If
    End Sub
    Private Sub FillEsiCode()
        Dim ssql As String
        ssql = "select EsiCode,SectionPercentage from  AccountsEsiMAster"
        vconn.getDataSet(ssql, "ESI")
        Dim i As Integer
        If gdataset.Tables("ESI").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("ESI").Rows.Count - 1
                Me.Cbo_EsiSection.Items.Add(gdataset.Tables("ESI").Rows(i).Item("EsiCode"))
            Next i
        End If
    End Sub
    Private Sub FillPfCode()
        Dim ssql As String
        ssql = "select PfCode,PfPercentage from  accountspfmaster"
        vconn.getDataSet(ssql, "PF")
        Dim i As Integer
        If gdataset.Tables("PF").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("WCM").Rows.Count - 1
                Me.Cbo_EsiSection.Items.Add(gdataset.Tables("PF").Rows(i).Item("PfCode"))
            Next i
        End If
    End Sub
    Private Sub FillPurchaseCode()
        Dim ssql As String
        ssql = "select Purchasecode,percentage from  accountspurchasetaxmaster"
        vconn.getDataSet(ssql, "PUR")
        Dim i As Integer
        If gdataset.Tables("PUR").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("PUR").Rows.Count - 1
                Me.Cbo_EsiSection.Items.Add(gdataset.Tables("PUR").Rows(i).Item("Purchasecode"))
            Next i
        End If
    End Sub
    Private Sub Cbo_TDSSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_TDSSection.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim i As Integer
            Dim ssql As String
            ssql = "Select SectionType from  accountstdsmaster where tdscode = '" & Trim(Cbo_TDSSection.Text & "") & "'"
            vconn.getDataSet(ssql, "TDSection")
            Me.CBO_TDSECTION.Items.Clear()
            If gdataset.Tables("TDSection").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("TDSection").Rows.Count - 1
                    Me.CBO_TDSECTION.Items.Add(gdataset.Tables("TDSection").Rows(i).Item("SectionType"))
                Next i
            End If
            CBO_TDSECTION.Focus()
        End If
    End Sub

    Private Sub Txt_TDSPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_TDSPercentage.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_WorksContractYes.Focus()
        End If
    End Sub

    Private Sub Rdo_WorksContractYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_WorksContractYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cbo_WorksContractSection.Focus()
        End If
    End Sub

    Private Sub Rdo_WorksContractNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_WorksContractNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Rdo_PurchaseTaxNo.Focus()
        End If
    End Sub
    Private Sub Rdo_WorksContractYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_WorksContractYes.CheckedChanged
        Cbo_WorksContractSection.Visible = True
        Txt_WorksContractPercentage.Visible = True
        Lbl_WorksContractp.Visible = True
        Lbl_WorksContractSection.Visible = True
        If Cbo_WorksContractSection.Items.Count > 0 Then
            Cbo_WorksContractSection.SelectedIndex = -1
        End If
    End Sub

    Private Sub Rdo_WorksContractNo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_WorksContractNo.CheckedChanged
        Cbo_WorksContractSection.Visible = False
        Txt_WorksContractPercentage.Visible = False
        Lbl_WorksContractp.Visible = False
        Lbl_WorksContractSection.Visible = False
    End Sub
    Private Sub Cbo_WorksContractSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_WorksContractSection.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_WorksContractPercentage.Focus()
        End If
    End Sub
    Private Sub Txt_WorksContractPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_WorksContractPercentage.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_PurchaseTaxYes.Focus()
        End If
    End Sub

    Private Sub Rdo_PurchaseTaxYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_PurchaseTaxYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cbo_PurchaseTaxSection.Focus()
        End If
    End Sub

    Private Sub Rdo_PurchaseTaxNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_PurchaseTaxNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Rdo_ESINo.Focus()
        End If
    End Sub

    Private Sub Rdo_PurchaseTaxNo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_PurchaseTaxNo.CheckedChanged
        Cbo_PurchaseTaxSection.Visible = False
        Txt_PurchaseTaxPercentage.Visible = False
        Lbl_PurchaseTaxp.Visible = False
        Lbl_PurchaseTaxSection.Visible = False
    End Sub

    Private Sub Rdo_PurchaseTaxYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_PurchaseTaxYes.CheckedChanged
        Cbo_PurchaseTaxSection.Visible = True
        Txt_PurchaseTaxPercentage.Visible = True
        Lbl_PurchaseTaxp.Visible = True
        Lbl_PurchaseTaxSection.Visible = True
        If Cbo_PurchaseTaxSection.Items.Count > 0 Then
            Cbo_PurchaseTaxSection.SelectedIndex = -1
        End If
    End Sub

    Private Sub Cbo_PurchaseTaxSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_PurchaseTaxSection.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_PurchaseTaxPercentage.Focus()
        End If
    End Sub

    Private Sub Txt_PurchaseTaxPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PurchaseTaxPercentage.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_ESIYes.Focus()
        End If
    End Sub

    Private Sub Rdo_ESIYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_ESIYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cbo_EsiSection.Focus()
        End If
    End Sub

    Private Sub Rdo_ESINo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_ESINo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Rdo_PFNo.Focus()
        End If
    End Sub

    Private Sub Rdo_ESIYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_ESIYes.CheckedChanged
        Cbo_EsiSection.Visible = True
        Txt_EsiPercentage.Visible = True
        Lbl_esip.Visible = True
        Lbl_EsiSection.Visible = True
        If Me.Cbo_EsiSection.Items.Count > 0 Then
            Cbo_EsiSection.SelectedIndex = -1
        End If
    End Sub

    Private Sub Rdo_ESINo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_ESINo.CheckedChanged
        Cbo_EsiSection.Visible = False
        Txt_EsiPercentage.Visible = False
        Lbl_esip.Visible = False
        Lbl_EsiSection.Visible = False
    End Sub
    Private Sub Cbo_EsiSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_EsiSection.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_EsiPercentage.Focus()
        End If
    End Sub
    Private Sub Txt_EsiPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_EsiPercentage.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_PFYes.Focus()
        End If
    End Sub

    Private Sub Rdo_PFYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_PFYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cbo_PfSection.Focus()
        End If
    End Sub

    Private Sub Rdo_PFNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_PFNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'Refer Mk Kannan
            'Modified as on 19 Jul 07
            'Begin
            'Rdo_TaxNo.Focus()
            'End
        End If
    End Sub
    Private Sub Rdo_PFYes_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_PFYes.CheckedChanged
        Cbo_PfSection.Visible = True
        Txt_PfPercentage.Visible = True
        Lbl_Pfp.Visible = True
        Lbl_PfSection.Visible = True
        If Me.Cbo_PfSection.Items.Count > 0 Then
            Cbo_PfSection.SelectedIndex = -1
        End If
    End Sub

    Private Sub Rdo_PFNo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_PFNo.CheckedChanged
        Cbo_PfSection.Visible = False
        Txt_PfPercentage.Visible = False
        Lbl_Pfp.Visible = False
        Lbl_PfSection.Visible = False
    End Sub

    Private Sub Cbo_PfSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbo_PfSection.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_PfPercentage.Focus()
        End If
    End Sub
    Private Sub Txt_PfPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PfPercentage.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'Refer Mk Kannan
            'Modified as on 19 Jul 07
            'Begin
            'Rdo_TaxNo.Focus()
            Cmd_Add.Focus()
            'End
        End If
    End Sub

    Private Sub Rdo_TaxYes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            'Refer Mk Kannan
            'Modified as on 19 Jul 07
            'Begin
            'Cbo_TaxSection.Focus()
            'End
        End If
    End Sub

    Private Sub Rdo_TaxNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add.Focus()
        End If
    End Sub

    Private Sub Rdo_TaxYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Refer Mk Kannan
        'Modified as on 19 Jul 07
        'Begin
        'Cbo_TaxSection.Visible = True
        'Txt_TaxPercentage.Visible = True
        'Lbl_Taxp.Visible = True
        'Lbl_TaxSection.Visible = True
        'Cbo_TaxSection.SelectedIndex = 0
        'End
    End Sub

    Private Sub Rdo_TaxNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Refer Mk Kannan
        'Modified as on 19 Jul 07
        'Begin
        'Cbo_TaxSection.Visible = False
        'Txt_TaxPercentage.Visible = False
        'Lbl_Taxp.Visible = False
        'Lbl_TaxSection.Visible = False
        'End
    End Sub

    Private Sub Cbo_TaxSection_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            'Refer Mk Kannan
            'Modified as on 19 Jul 07
            'Begin
            'Txt_TaxPercentage.Focus()
            'End
        End If
    End Sub

    Private Sub Txt_TaxPercentage_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add.Focus()
        End If
    End Sub


    Private Sub Cmb_SLType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmb_SLType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_SLcode.Focus()
        End If
    End Sub
    Private Sub Txt_SLCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_SLcode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Me.Txt_SLcode.Text) = "" Then
                ' Txt_SLCode_Validated(sender, e)
                Call Cmd_SLCodeHelp_Click(sender, e)
            Else
                Txt_SLCode_Validated(sender, e)
            End If
        End If
    End Sub

    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        Text_SLCode.Text = Txt_SLcode.Text
        Text_SLName.Text = Txt_SLName.Text
        txt_scode.Text = Txt_SLcode.Text
        txt_sname.Text = Txt_SLName.Text
        Call Mevalidate() '''--->Check Validation
        If Mevalidate() = False Then
            TabControl1.SelectedIndex = 0
            Exit Sub
        End If
        'AxfpSpread3.ClearRange(1, 1, -1, -1, True)

        'Dim sql As String = " select itemcode,itemname,'0' as check1,'0' as contractyn,'0' as rate  from INV_INVENTORYITEMMASTER where isnull(void,'')<>'Y' "
        '' SQL = " SELECT distinct ITEMCODE,ITEMNAME,'0' as check1  FROM INV_INVENTORYITEMMASTER WHERE ISNULL(VOID,'')<>'y'"
        'gconnection.getDataSet(sql, "INV_INVENTORYITEMMASTER")
        'If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then
        '    For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
        '        With AxfpSpread3
        '            .Row = i + 1
        '            .Col = 1
        '            .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("ITEMCODE")
        '            .Row = i + 1
        '            .Col = 2
        '            .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("ITEMNAME")
        '            .Row = i + 1
        '            .Col = 3
        '            .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("check1")
        '            .Row = i + 1
        '            .Col = 4
        '            .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("contractyn")
        '            .Row = i + 1
        '            .Col = 5
        '            .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("rate")
        '            .Row = i + 1
        '            .Col = 6
        '            sql = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("itemcode")) + "'"
        '            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
        '            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
        '                AxfpSpread3.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
        '                AxfpSpread3.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
        '            Next Z

        '            '  .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("uom")
        '        End With
        '    Next
        'End If
        'If Cmd_Add.Text = "Update[F7]" Then
        '    Call Txt_SLCode_Validated(sender, e)
        'End If
        'AxfpSpread2.ClearRange(1, 1, -1, -1, True)
        'sql = " SELECT distinct categorycode,categorydesc FROM INVENTORYCATEGORYMASTER WHERE ISNULL(freeze,'')<>'y'  "
        'gconnection.getDataSet(sql, "INV_INVENTORYITEMMASTER")
        'If (gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count > 0) Then
        '    For i As Integer = 0 To gdataset.Tables("INV_INVENTORYITEMMASTER").Rows.Count - 1
        '        With AxfpSpread2
        '            .Row = i + 1
        '            .Col = 1
        '            .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorycode")
        '            .Row = i + 1
        '            .Col = 2
        '            .Text = gdataset.Tables("INV_INVENTORYITEMMASTER").Rows(i).Item("categorydesc")
        '            .Row = i + 1
        '        End With
        '    Next
        'End If
        'If Cmd_Add.Text = "Update[F7]" Then
        '    Call Txt_SLCode_Validated(sender, e)
        'End If
        'sqlstring = "  Select isnull(MSupplier,'N') as MSupplier from inv_linksetup"
        'gconnection.getDataSet(sqlstring, "inv_linksetup")
        'If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
        '    If (gdataset.Tables("inv_linksetup").Rows(0).Item("MSupplier").ToString() = "Y") Then
        '        Txt_GLAcCode.Text = ""
        '        Txt_GLAcDesc.Text = ""
        '        Txt_GLAcCode.ReadOnly = False
        '        Txt_GLAcDesc.ReadOnly = False
        '        Cmd_GLAcCodeHelp.Enabled = True
        '    Else
        '        Txt_GLAcCode.Text = "SCRS"
        '        Txt_GLAcDesc.Text = "SUNDRY CREDITORS"
        '        Txt_GLAcCode.ReadOnly = True
        '        Txt_GLAcDesc.ReadOnly = True
        '        Cmd_GLAcCodeHelp.Enabled = False
        '    End If
        'End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim vform As New ListOperattion1
        Dim sqlstring As String
        gSQLString = "SELECT distinct slcode,Slname FROM accountssubledgermaster "
        '        M_WhereCondition = " Where Accode='" & Trim(Me.Txt_GLAcCode.Text) & "'"
        sqlstring = "  Select isnull(MSupplier,'N') as MSupplier  from inv_linksetup"
        gconnection.getDataSet(sqlstring, "inv_linksetup")

        If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
            If (gdataset.Tables("inv_linksetup").Rows(0).Item("MSupplier").ToString() = "Y") Then
                M_WhereCondition = " WHERE SLTYPE='SUPPLIER'  "
            Else
                M_WhereCondition = " Where accode='" + gCreditors + "' AND SLTYPE='SUPPLIER' "
            End If
        End If
        '        M_WhereCondition = " Where accode='" + gCreditors + "'"
        vform.Field = "slcode,slname"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.vFormatstring = "  SUB LEDGER CODE       |SUB LEDGER NAME                    |"
        vform.vCaption = "SUB LEDGER MASTER HELP"
        vform.KeyPos = 0
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_scode.Text = Trim(vform.keyfield & "")

            txt_sname.Text = Trim(vform.keyfield1 & "")
            Txt_SLCode_Validated(sender, e)
        Else
            Me.txt_scode.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_scode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_scode.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (Txt_SLcode.Text <> "") Then
                Txt_SLCode_Validated(sender, e)
            Else
                Cmd_SLCodeHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cat_master As New Category_Master
        cat_master.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim cat_master As New Frm_InventoryItemmastervb
        cat_master.Show()
    End Sub

    Private Sub TxtGSTINNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtGSTINNO.KeyPress
        getAlphanumeric(e)
    End Sub

    Private Sub txt_City_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txt_City.KeyPress
        getCharater(e)
    End Sub
    Private Sub txt_email_LostFocus(sender As Object, e As EventArgs) Handles txt_email.LostFocus
        getEmail(txt_email)
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub
End Class