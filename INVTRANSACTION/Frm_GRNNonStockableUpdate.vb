Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_GRNNonStockableUpdate
    Dim gconnection As New GlobalClass
    Dim GrnQuery(0) As String
    Dim sql As String
    Dim GRNno(), versionno, CATCODE() As String
    Dim accode, acdesc, taxcode As String
    Dim overalldiscountpo, otherchargepo, totpoqty As Double
    Dim potype, sqlstring As String
    Dim issuedocno As String
    Dim gdate As DateTime
    Dim amt As Double
    Dim slcode, sldesc, costcode, costdesc, decription As String
    Dim calcbool As Boolean
    Dim check As Boolean = True
    ' Set grntype defaultly 
    Private Sub FillGRNTYPE()
        Dim Sqlstring As String
        Sqlstring = "SELECT ISNULL(GRNTYPE,'') AS GRNTYPE FROM INV_linkSETUP"
        gconnection.getDataSet(Sqlstring, "INVSETUP")
        If gdataset.Tables("INVSETUP").Rows.Count > 0 Then
            DefaultGRN = Trim(gdataset.Tables("INVSETUP").Rows(0).Item("GRNTYPE"))
        Else
            DefaultGRN = "NA"
        End If
    End Sub
    'bind categorycode in dropdown
    Private Sub bindcategory()
        Dim I As Integer
        Dim index As Integer
        Try


            CMB_CATEGORY.Items.Clear()
            Dim sql As String = "Select categorycode,CATEGORYDESC FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE IN (SELECT CATEGORYCODE  from Categoryuserdetail where usercode='" & gUsername & "' and isnull(void,'')<>'Y')"
            gconnection.getDataSet(sql, "Categoryuserdetail")
            If (gdataset.Tables("Categoryuserdetail").Rows.Count > 0) Then
                For I = 0 To gdataset.Tables("Categoryuserdetail").Rows.Count - 1
                    CMB_CATEGORY.Items.Add(gdataset.Tables("Categoryuserdetail").Rows(I).Item("categorycode") + "--->" + gdataset.Tables("Categoryuserdetail").Rows(I).Item("CATEGORYDESC"))

                Next
                index = CMB_CATEGORY.FindString(DefaultGRN)
                CMB_CATEGORY.SelectedIndex = index
            End If

        Catch ex As Exception

        End Try

    End Sub
    'generate Grnno automatically
    Private Sub autogenerate()
        Try
            If txt_Storecode.Text <> "" Then
                Dim sqlstring, financalyear As String
                Dim month As String
                Dim CATLEN As Integer
                Dim category, storecode As String
                Dim S As String
                month = UCase(Format(Now, "MMM"))
                gcommand = New SqlCommand
                storecode = Mid(txt_Storecode.Text, 1, 3)
                financalyear = Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialyearEnd, 3, 2)
                CATCODE = Split(CMB_CATEGORY.Text, "--->")
                sqlstring = "SELECT ISNULL(CATEGORY,'') AS CATEGORY FROM INV_InventoryItemMaster WHERE ISNULL(CATEGORY,'')='" & Trim(CATCODE(0) & "") & "' GROUP BY CATEGORY"
                gconnection.getDataSet(sqlstring, "CATEGORY")
                If gdataset.Tables("CATEGORY").Rows.Count > 0 Then
                    category = Mid(Trim(gdataset.Tables("CATEGORY").Rows(0).Item("CATEGORY") & ""), 1, 3)
                    CATLEN = Len(Trim(category))
                Else
                    CATLEN = 3
                    category = month
                End If

                ' sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER WHERE SUBSTRING(GRNDETAILS,5," & CATLEN & ")='" & category & "' AND ISNULL(GRNTYPE,'')='GRN'"

                sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER WHERE SUBSTRING(GRNDETAILS,9," & CATLEN & ")='" & category & "' AND SUBSTRING(GRNDETAILS,5,3)='" & storecode & "'  AND ISNULL(GRNTYPE,'')='GRN'"
                '        sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER"
                gconnection.openConnection()
                gcommand.CommandText = sqlstring
                gcommand.CommandType = CommandType.Text
                gcommand.Connection = gconnection.Myconn
                gdreader = gcommand.ExecuteReader

                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        txt_Grnno.Text = "GRN/" & storecode & "/" & category & "/" & "0001/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        txt_Grnno.Text = "GRN/" & storecode & "/" & category & "/" & Format(gdreader(0) + 1, "0000") & "/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    txt_Grnno.Text = "GRN/" & storecode & "/" & category & "/0001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            End If




        Catch ex As Exception
            MessageBox.Show("Plz Check Error : autogenerate" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

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
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
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

    Private Sub Frm_GRN_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F2 Then
                txt_Grnno.Text = ""
                txt_Grnno.Focus()
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 And Cmd_View.Visible = True Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.Escape Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.U Then
                'If MsgBox("DO U Want to Manual Update Stock......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
                '    Me.Cursor = Cursors.WaitCursor
                '    gconnection.ManualUpdate()
                '    Me.Cursor = Cursors.Default
                'Else
                '    MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
                'End If
            ElseIf e.KeyCode = Keys.R Then
                'If MsgBox("DO U Want to Manual Update Rate......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
                '    Me.Cursor = Cursors.WaitCursor
                '    gconnection.valuation()
                '    Me.Cursor = Cursors.Default
                'Else
                '    MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
                'End If

            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Frm_GRN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (gpocode = "Y") Then
            grp_Grngroup1.Visible = True
        Else
            grp_Grngroup1.Visible = False
            CmbGrnType.Text = "DIRECT GRN"
        End If
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        'Me.DoubleBuffered = True
        ' Resize_Form()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        FillGRNTYPE()
        bindcategory()
        '   autogenerate()
        sqlstring = "Select getdate()"
        gdate = gconnection.getvalue(sqlstring)

        If Trim(UCase(gShortname)) = "CGC" Then
            lock_Frqty()
        End If

        LBL_SPONSOR.Hide()
        TXT_Sponsor.Hide()
        cmd_SPONhelp.Hide()

        For RW As Integer = 1 To 100
            AxfpSpread1.Col = 19
            AxfpSpread1.ColHidden = True
        Next

    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "GRN Cum Purchase Bill"

        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Me.Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    ' Me.cmd_auth.Enabled = True
                End If
            Next
        End If
    End Sub



    Private Sub cmd_Suppliercodehelp_Click(sender As Object, e As EventArgs) Handles cmd_Suppliercodehelp.Click
        Try
            Dim sqlstring As String
            CATCODE = Split(CMB_CATEGORY.Text, "--->")
            sqlstring = " select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "'"
            gconnection.getDataSet(sqlstring, "Invvendor_CategoryMaster")
            gSQLString = "SELECT SLCODE,SLNAME FROM accountssubledgermaster "

            If (gdataset.Tables("Invvendor_CategoryMaster").Rows.Count > 0) Then

                M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "') AND ISNULL(freezeflag,'N')<>'Y' and  slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
            Else
                ' M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "')  and  slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
                M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "') AND ISNULL(freezeflag,'N')<>'Y' "
            End If
            M_ORDERBY = ""
            Dim vform As New ListOperattion1
            vform.Field = "SLNAME,SLCODE"
            vform.vFormatstring = "       SLCODE                    |                      SLNAME                                                                                                          "
            vform.vCaption = "SUB LEDGER MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Suppliercode.Text = Trim(vform.keyfield & "")
                Call txt_Suppliercode_Validated(txt_Suppliercode, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_Suppliercodehelp_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Suppliercode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Suppliercode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txt_Suppliercode.Text <> "" Then
                txt_Suppliercode_Validated(sender, e)
            Else
                cmd_Suppliercodehelp_Click(sender, e)
            End If




        End If
    End Sub

    Private Sub txt_Suppliercode_Validated(sender As Object, e As EventArgs) Handles txt_Suppliercode.Validated
        Dim sqlstring As String
        Try
            CATCODE = Split(CMB_CATEGORY.Text, "--->")

            sqlstring = " select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "'"
            gconnection.getDataSet(sqlstring, "Invvendor_CategoryMaster")

            If Trim(txt_Suppliercode.Text) <> "" Then
                sqlstring = "SELECT SLCODE,SLNAME,isnull(creditperiod,0) as creditperiod FROM accountssubledgermaster "
                If (gdataset.Tables("Invvendor_CategoryMaster").Rows.Count > 0) Then
                    sqlstring = sqlstring & " WHERE ACCODE IN ("
                    sqlstring = sqlstring & "'" & Trim(gCreditors) & "') AND SLCODE='" & Trim(txt_Suppliercode.Text) & "' and   slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"

                Else
                    sqlstring = sqlstring & " WHERE ACCODE IN ("
                    sqlstring = sqlstring & "'" & Trim(gCreditors) & "') AND SLCODE='" & Trim(txt_Suppliercode.Text) & "'"
                    ' sqlstring = sqlstring & "'" & Trim(gCreditors) & "') AND SLCODE='" & Trim(txt_Suppliercode.Text) & "' and   slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
                End If
                gconnection.getDataSet(sqlstring, "accountssubledgermaster")
                If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
                    txt_Suppliername.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("SLNAME"))
                    txt_Suppliercode.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("SLCODE"))
                    txt_Suppliername.ReadOnly = True
                    If gvendorlink = "Y" Then
                        txt_Suppliercode.Enabled = False
                        cmd_Suppliercodehelp.Enabled = False
                    End If

                    txt_Supplierinvno.Focus()


                Else
                    txt_Suppliercode.Text = ""
                    txt_Suppliercode.Text = ""
                    txt_Suppliername.ReadOnly = False
                    txt_Suppliercode.Focus()
                End If
            Else
                txt_Suppliercode.Text = ""
                txt_Suppliername.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Suppliercode_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Cmd_Storecode_Click(sender As Object, e As EventArgs) Handles Cmd_Storecode.Click
        Dim sqlstring As String
        CATCODE = Split(CMB_CATEGORY.Text, "--->")
        sqlstring = "Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "'"
        gconnection.getDataSet(sqlstring, "Invstore_CategoryMaster")

        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
        If (gdataset.Tables("Invstore_CategoryMaster").Rows.Count > 0) Then
            M_WhereCondition = " where freeze <> 'Y' and storestatus='M'  and  storecode in ( Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"

        Else
            M_WhereCondition = " where freeze <> 'Y' and storestatus='M' "

        End If
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Storecode.Text = Trim(vform.keyfield & "")
            txt_StoreDesc.Text = Trim(vform.keyfield1 & "")
            'Txt_GLAcIn.Focus()
            AxfpSpread1.Focus()
            AxfpSpread1.SetActiveCell(1, 1)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub binditemcode()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim myValue As Object
        message = "Enter Batch No"
        title = "Batch No"
        defaultValue = txt_Grnno.Text

        CATCODE = Split(CMB_CATEGORY.Text, "--->")

        sql = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "'"
        gconnection.getDataSet(sql, "Invitem_VendorMaster")

        gSQLString = "select DISTINCT I.itemcode,M.Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "

        If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
            M_WhereCondition = "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'  AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' )"


        Else

            M_WhereCondition = " where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'"

        End If
        vform.Field = " I.itemcode, M.Itemname,uom"
        vform.vFormatstring = "    itemcode    |        Itemname             |   UOM      |  batchprocess  "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_Duplicate(vform.keyfield) = False) Then

                AxfpSpread1.Col = 1
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.Col = 2
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield1)
                AxfpSpread1.Col = 3
                AxfpSpread1.Row = AxfpSpread1.ActiveRow

                Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Col = 18
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Col = 3
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Next Z
                ''''''''''''''''''''''''''''''''

                sql = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and ITEMCODE='" + vform.keyfield + "' and isnull(contractyn,0)='1'"
                gconnection.getDataSet(sql, "Invitem_VendorMaster")
                If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                    AxfpSpread1.Col = 3
                    AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("rate")
                    If AxfpSpread1.Text = "0.00" Then
                        AxfpSpread1.Lock = False
                    Else
                        AxfpSpread1.Lock = True
                    End If

                End If
                If CATCODE(0) = "LIQ" Then
                    sql = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY TRNS_SEQ  DESC"
                    gconnection.getDataSet(sql, "RATE")
                    If (gdataset.Tables("RATE").Rows.Count > 0) Then

                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") '/ Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                        AxfpSpread1.Lock = False
                    Else
                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        'AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") '/ Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                        AxfpSpread1.Lock = False
                    End If
                End If
                ''''''''''''''''''''''''''''''''
                If Trim(vform.keyfield3) = "YES" Then
                    myValue = InputBox(message, title, defaultValue)
                    If myValue = "" Then myValue = defaultValue
                    AxfpSpread1.Col = 14
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = myValue

                Else
                    AxfpSpread1.Col = 14
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = defaultValue
                End If
                If UCase(gShortname) <> "CCL" Then
                    sql = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + Trim(vform.keyfield) + "'"
                    sql = sql & " AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                    gconnection.getDataSet(sql, "Itemtaxtagging")
                    If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                        AxfpSpread1.Col = 10
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                        AxfpSpread1.Col = 11
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxper")
                        'AxfpSpread1.Col = 12
                        'AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        'AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("GLACCOUNTIN")
                    Else
                        MessageBox.Show("Create TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    End If
                End If
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            End If
        End If
    End Sub
    Private Sub binditemname()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim myValue As Object
        CATCODE = Split(CMB_CATEGORY.Text, "--->")
        message = "Enter Batch No"
        title = "Batch No"
        defaultValue = txt_Grnno.Text
        sql = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "'"
        gconnection.getDataSet(sql, "Invitem_VendorMaster")

        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
            M_WhereCondition = "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'  AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')"


        Else

            M_WhereCondition = " where M.Category='" + CATCODE(0) + "' and isnull(M.void)='N' and isnull(I.storecode)='" + txt_Storecode.Text + "'"
        End If
        vform.Field = " I.itemcode, I.Itemname,I.Uom,batchprocess"
        vform.vFormatstring = "    itemcode    |     Itemname                       |       UOM     |"
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos1 = 2
        vform.KeyPos1 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_Duplicate(vform.keyfield) = False) Then

                AxfpSpread1.Col = 1
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.Col = 2
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield1)
                AxfpSpread1.Col = 3
                AxfpSpread1.Row = AxfpSpread1.ActiveRow

                Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                Next Z

                If Trim(vform.keyfield3) = "YES" Then
                    myValue = InputBox(message, title, defaultValue)
                    If myValue = "" Then myValue = defaultValue
                    AxfpSpread1.Col = 14
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = myValue

                Else
                    AxfpSpread1.Col = 14
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = defaultValue
                End If

                sql = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and itemcode='" + Trim(vform.keyfield) + "' and isnull(contractyn,0)='1'"
                gconnection.getDataSet(sql, "Invitem_VendorMaster")
                If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                    AxfpSpread1.Col = 3
                    AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("rate")
                    AxfpSpread1.Lock = True
                End If
                If CATCODE(0) = "LIQ" Then
                    sql = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE itemcode='" + Trim(vform.keyfield) + "' AND storecode='" + txt_Storecode.Text + "'  and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and   cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY TRNS_SEQ  DESC"
                    gconnection.getDataSet(sql, "RATE")
                    If (gdataset.Tables("RATE").Rows.Count > 0) Then

                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                        AxfpSpread1.Lock = False
                    Else
                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                        AxfpSpread1.Lock = True
                    End If
                End If
                If UCase(gShortname) <> "CCL" Then
                    sql = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + Trim(vform.keyfield) + "'"
                    sql = sql & " AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                    gconnection.getDataSet(sql, "Itemtaxtagging")
                    If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                        AxfpSpread1.Col = 10
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                        AxfpSpread1.Col = 11
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxper")
                    Else
                        MessageBox.Show("Create TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    End If
                End If
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            End If
        End If

    End Sub


    Private Function validateonupdate() As Boolean
        Dim flag As Boolean

        Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"))
        If checkBdate = True And RESU1 = False Then
            MsgBox("Business date closed..")
            flag = True
            Return flag
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
            flag = True
            Return flag
        End If
        If DateDiff(DateInterval.Day, (CDate(dtp_Grndate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("To Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If txt_Grnno.Text = "" Then
            MessageBox.Show("Please Fill GrnNo ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag
        End If
        If CMB_CATEGORY.Text = "" Then
            MessageBox.Show("Please Select Category ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag
        End If

        If txt_Storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_Storecode.BackColor = Color.Red
            txt_Storecode.Focus()
            flag = True
            Return flag
        Else
            txt_Storecode.BackColor = Color.White

        End If
        If Txt_PONo.Text = "" And Txt_PONo.Visible = True Then
            MessageBox.Show("Please Fill POno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_PONo.BackColor = Color.Red
            Txt_PONo.Focus()

            flag = True
            Return flag
        Else
            Txt_PONo.BackColor = Color.White

        End If
        If txt_Suppliercode.Text = "" Then
            MessageBox.Show("Please Fill Vendor Code ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_Suppliercode.BackColor = Color.Red
            txt_Suppliercode.Focus()

            flag = True
            Return flag
        Else
            txt_Suppliercode.BackColor = Color.White

        End If
        If txt_Supplierinvno.Text <> "" And txt_Supplierinvno.Text <> "NA" Then
            ''sql = "select * from grn_header where isnull(void,'N')<>'Y' and Supplierinvno='" & txt_Supplierinvno.Text & "'"
            'gconnection.getDataSet(sql, "GH")
            'If (gdataset.Tables("GH").Rows.Count > 0) Then
            '    MessageBox.Show(" Supplier inv. no. already Process in GRN NO. :" & gdataset.Tables("GH").Rows(0).Item("GRNDETAILS"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    flag = True
            '    Return flag
            'End If

        End If

      
        If (gdirissue = "Y") Then
            nonstockable.Columns.Clear()
            Dim dc As New DataColumn("ItemCode", GetType(String))

            ' dc.ColumnName = "ItemCode"

            nonstockable.Columns.Add(dc)
            Dim dc1 As New DataColumn("ItemName", GetType(String))
            nonstockable.Columns.Add(dc1)

            Dim dc2 As New DataColumn("UOM", GetType(String))
            nonstockable.Columns.Add(dc2)
            Dim dc3 As New DataColumn("Quantity", GetType(Double))
            nonstockable.Columns.Add(dc3)

            Dim dc5 As New DataColumn("StoreCode", GetType(String))

            nonstockable.Columns.Add(dc5)
            Dim dc6 As New DataColumn("TotalQuantity", GetType(Double))
            nonstockable.Columns.Add(dc6)
            nonstockable.Rows.Clear()
        End If
        If (gdirissue = "Y") Then
            For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
               
                AxfpSpread1.Row = i + 1

        
                    AxfpSpread1.Col = 1
                sql = "sELECT * FROM INV_INVENTORYITEMMASTeR WHERE ITEMCODE='" + AxfpSpread1.Text + "' AND stockcategory='NONSTOCKABLE' and '" & Trim(Me.txt_Grnno.Text) & "'+itemcode in (select a.grndetails+a.itemcode from pur_nonstockable a where a.grndetails+a.itemcode not in(select batchno+b.itemcode from iss_nonstockable b) ) "
                    gconnection.getDataSet(sql, "INV_INVENTORYITEMMASTR")
                    If (gdataset.Tables("INV_INVENTORYITEMMASTR").Rows.Count > 0) Then
                        Dim drow As DataRow
                        drow = nonstockable.NewRow
                        drow.Item("Itemcode") = AxfpSpread1.Text
                        AxfpSpread1.Col = 2
                        drow.Item("ItemName") = AxfpSpread1.Text
                        AxfpSpread1.Col = 3

                        drow.Item("Uom") = AxfpSpread1.Text


                        AxfpSpread1.Col = 17
                        Dim qty2 As Double
                        qty2 = Val(AxfpSpread1.Text)
                        AxfpSpread1.Col = 4
                        drow.Item("quantity") = Val(AxfpSpread1.Text) + qty2
                        drow.Item("StoreCode") = ""
                        AxfpSpread1.Col = 4

                        drow.Item("TotalQuantity") = Val(AxfpSpread1.Text) + qty2
                        nonstockable.Rows.Add(drow)

                    End If


            Next
        End If
        'If (gdirissue = "Y") Then
        '    'If (nonstockable.Rows.Count > 0) Then
        '    '    MessageBox.Show("Item is Issued You Cant Update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        '    '    Cmd_Add.Enabled = False

        '    '    If UCase(gShortname) = "CCL" Then
        '    '        If MsgBox("DO U Want Account Reposting......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
        '    '            Call ReaccountPost()
        '    '            clearoperation()
        '    '        End If
        '    '    End If

        '    '    flag = True
        '    '    Return flag

        '    'End If
        'End If


        'For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
        '    AxfpSpread1.Row = i + 1
        '    AxfpSpread1.Col = 1
        '    Dim itemcode As String = AxfpSpread1.Text
        '    AxfpSpread1.Col = 4
        '    Dim qty As Double = Val(AxfpSpread1.Text)
        '    AxfpSpread1.Col = 17
        '    Dim fQqty As Double = Val(AxfpSpread1.Text)
        '    AxfpSpread1.Col = 3
        '    Dim uom As String = AxfpSpread1.Text
        '    AxfpSpread1.Col = 18
        '    Dim fQuom As String = AxfpSpread1.Text

        '    Dim qty1 As Double
        '    Dim batchyn As String
        '    Dim SQLSTring As String
        '    Dim stockuom As String
        '    Dim convvalue As Double


        '    AxfpSpread1.Col = 3

        '    If (AxfpSpread1.Text = "") Then
        '        MessageBox.Show("UOM Cannot be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        AxfpSpread1.Text = ""
        '        AxfpSpread1.SetActiveCell(3, i)

        '        flag = True
        '        Return flag

        '    End If

        '    AxfpSpread1.Col = 4
        '    Dim grnqty As Double = Val(AxfpSpread1.Text)
        '    If (grnqty <= 0) Then
        '        MessageBox.Show("Quantity Cannot be Zero", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        AxfpSpread1.Text = ""
        '        AxfpSpread1.SetActiveCell(4, i)

        '        flag = True
        '        Return flag

        '    End If
        '    AxfpSpread1.Col = 5
        '    Dim grnrate As Double = Val(AxfpSpread1.Text)
        '    If (grnrate <= 0) Then
        '        MessageBox.Show("Rate Cannot be Zero", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        AxfpSpread1.Text = ""
        '        AxfpSpread1.SetActiveCell(5, i)

        '        flag = True
        '        Return flag

        '    End If

        '    AxfpSpread1.Col = 7
        '    Dim grndis As Double = Val(AxfpSpread1.Text)
        '    If (grndis > 100) Then
        '        MessageBox.Show("Discount Cannot be Greater than 100%", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        AxfpSpread1.Text = ""
        '        AxfpSpread1.SetActiveCell(7, i)
        '        flag = True
        '        Return flag

        '    End If


        '    AxfpSpread1.Col = 6
        '    Dim grndisAmt As Double = Val(AxfpSpread1.Text)
        '    AxfpSpread1.Col = 8
        '    If (grndisAmt < Val(AxfpSpread1.Text)) Then
        '        MessageBox.Show("Discount Cannot be Greater than Amt.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        AxfpSpread1.Text = ""
        '        AxfpSpread1.SetActiveCell(8, i)
        '        flag = True
        '        Return flag

        '    End If

        '    SQLSTring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
        '    stockuom = gconnection.getvalue(SQLSTring)

        '    SQLSTring = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + stockuom + "' and transuom='" + uom + "'"
        '    gconnection.getDataSet(SQLSTring, "INVENTORY_TRANSCONVERSION")
        '    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
        '        convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
        '    Else
        '        MessageBox.Show("Generate relation between " + stockuom + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        flag = True
        '        Exit Function
        '    End If
        '    qty = qty / convvalue

        '    SQLSTring = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + stockuom + "' and transuom='" + fQuom + "'"
        '    gconnection.getDataSet(SQLSTring, "INVENTORY_TRANSCONVERSION")
        '    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
        '        convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
        '    Else
        '        MessageBox.Show("Generate relation between " + stockuom + " and " + fQuom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        flag = True
        '        Exit Function
        '    End If
        '    fQqty = fQqty / convvalue
        '    qty = qty + fQqty
        '    Dim sql As String = "select qty,isnull(batchyn,'N') as batchyn from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'  "
        '    sql = sql & " and Trnno='" + txt_Grnno.Text + "' "
        '    gconnection.getDataSet(sql, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '    End If
        '    sql = "select closingstock +" + Format(Val(qty - qty1), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' "
        '    sql = sql & "and closingstock +" + Format(Val(qty - qty1), "0.000") + "<0 AND itemcode='" + itemcode + "'  and storecode='" + txt_Storecode.Text + "' "
        '    If batchyn = "Y" Then
        '        sql = sql & " and batchno='" + txt_Grnno.Text + "'"
        '    End If
        '    gconnection.getDataSet(sql, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        MessageBox.Show("Updation create   " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        flag = True
        '        Return flag
        '    End If

        '    If (Format(CDate(gdate), "yyyy/MM/dd") > Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd")) Then
        '        Dim count As Double = 0
        '        sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'  order by trns_seq"

        '        gconnection.getDataSet(sql, "closingqty")
        '        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '            count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
        '            count = count + Val(qty - qty1)
        '            For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
        '                count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
        '                If count < 0 Then
        '                    MessageBox.Show("Update create  " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '                    flag = True
        '                    Return flag
        '                End If
        '            Next
        '        End If

        '    End If

        '    If CmbGrnType.Text = "DIRECT GRN" Then
        '        sql = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + itemcode + "'"
        '        gconnection.getDataSet(sql, "ITEM")
        '        If (gdataset.Tables("ITEM").Rows.Count > 0) Then
        '            If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then
        '                AxfpSpread1.Col = 20
        '                sql = " select * from InvCompany_ItemMaster where COMPANYCODE='" + AxfpSpread1.Text + "' AND ITEMCODE='" + itemcode + "' "
        '                gconnection.getDataSet(sql, "InvCompany_ItemMaster")
        '                If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then

        '                Else
        '                    MessageBox.Show("Select Company Code .", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '                    AxfpSpread1.Text = ""
        '                    AxfpSpread1.SetActiveCell(20, i)
        '                    flag = True
        '                    Return flag
        '                End If
        '            End If
        '        End If
        '    End If

        'Next



        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)
            flag = True
            Return flag
        End If

        If (GACCPOST.ToUpper() = "Y") Then
            If gAcPostingWise = "ITEM" Then
                For k As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = k
                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                        gconnection.getDataSet(sqlstring, "CODE")
                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")

                            If accode = "" Then

                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                flag = True
                                Return flag

                            End If
                        Else
                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                            flag = True
                            Return flag
                        End If
                    End If

                Next


            ElseIf gAcPostingWise = "CATEGORY" Then
                sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORYCODE " + Trim(CATCODE(0)) + "")
                        flag = True
                        Return flag

                    End If
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                    flag = True
                    Return flag
                End If
            Else
                sqlstring = "Select * from AccountstaggingnEW where CODE='" & Trim(txt_Storecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE  " + Trim(txt_Storecode.Text) + "")
                        flag = True
                        Return flag

                    End If
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE " + Trim(txt_Storecode.Text) + "")
                    flag = True
                    Return flag
                End If

            End If
            If CmbGrnType.Text = "SPONSOR" Then


                For j As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = j
                    AxfpSpread1.Col = 1
                    If AxfpSpread1.Text <> "" Then
                        AxfpSpread1.Col = 19
                        Dim sqlstring As String = "SELECT * FROM SponsorAccountstagging WHERE code='" & Trim(AxfpSpread1.Text) & "' AND  ISNULL(VOID,'N') <> 'Y'"
                        gconnection.getDataSet(sqlstring, "CODE")
                        If gdataset.Tables("CODE").Rows.Count > 0 Then

                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                            If accode = "" Then

                                MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING...")
                                flag = True
                                Return flag

                            End If
                            If accode <> "" And costcode = "" Then

                                MessageBox.Show("NO COST CENTRE CODE FOR SPON. POSTING...")
                                flag = True
                                Return flag

                            End If

                        Else
                            MessageBox.Show("Please Fill Sponsor ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag
                        End If
                    End If

                Next
            End If
        End If

        If (gdirissue = "Y") Then
            If (nonstockable.Rows.Count > 0) Then
                Dim frm1 As New FrmDirectIssueing
                frm1.ShowDialog(Me)
                If (frm1.flg = True) Then

                    Dim itmcode, itmcodeprev, vvl As String
                    Dim itemtot, itemtotprev As Double
                    Dim j As Integer
                    For j = 0 To nonstockable.Rows.Count - 1
                        itmcode = Nothing
                        itemtot = Nothing
                        itmcode = nonstockable.Rows(j).Item("itemcode")
                        itemtot = nonstockable.Rows(j).Item("totalquantity")

                        itemtotprev = 0
                        For i As Integer = 1 To AxfpSpread1.DataRowCnt
                            itmcodeprev = Nothing
                            AxfpSpread1.GetText(1, i, itmcodeprev)
                            If UCase(itmcodeprev) = UCase(itmcode) Then
                                vvl = Nothing
                                AxfpSpread1.GetText(4, i, vvl)
                                itemtotprev = itemtotprev + Val(vvl)
                            End If

                        Next
                        If Val(itemtotprev) <> Val(itemtot) Then
                            MsgBox("GRN qty and issue qty is not same for" & itmcode)
                            flag = True
                            Return flag
                        End If
                    Next
                Else
                    MessageBox.Show("Issue All Nonstockable Items", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag
                End If
            End If
        End If

        Return False
    End Function


    Private Sub ReaccountPost()
        Dim rate, amt, qty As Double
        Dim rateflag, itemcode, insert(0) As String

        ReDim Preserve GrnQuery(0)


        If (GACCPOST.ToUpper() = "Y") Then

            sqlstring = "Select  * from STOCKISSUEDETAIL where batchno='" + txt_Grnno.Text + "'"
            gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
            If (gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0) Then

                sqlstring = "delete  from JOURNALENTRY where VoucherNo in (select Docdetails from STOCKISSUEDETAIL where batchno='" + Trim(txt_Grnno.Text) + "') and Vouchertype='ISSUE'"
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

                For b As Integer = 0 To gdataset.Tables("STOCKISSUEDETAIL").Rows.Count - 1

                    Dim sql As String = "select weightedrate,batchrate  from ratelist where Itemcode='" + gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("itemcode") + "' and grnno='" + txt_Grnno.Text + "'"
                    gconnection.getDataSet(sql, "ratelist")

                    Dim sql1 As String = " select isnull(rateflag,'P') as rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
                    sql1 = sql1 & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" + gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("itemcode") + "' "
                    gconnection.getDataSet(sql1, "ratelist2")
                    If (gdataset.Tables("ratelist2").Rows.Count > 0) Then
                        If (gdataset.Tables("ratelist2").Rows(0).Item("rateflag") = "W") Then
                            rate = Format(Val(gdataset.Tables("ratelist").Rows(0).Item("weightedrate")), "0.000")

                        ElseIf (gdataset.Tables("ratelist2").Rows(0).Item("rateflag") = "P") Then
                            rate = Format(Val(gdataset.Tables("ratelist").Rows(0).Item("batchrate")), "0.000")

                        Else
                            AxfpSpread1.Col = 5
                            rate = Val(AxfpSpread1.Text)
                        End If

                    End If

                    qty = Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("qty"))
                    amt = rate * qty
                    issuedocno = gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("docdetails")
                    sqlstring = "Select  * from AccountstaggingNEW where code='" & Trim(gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("opstorelocationcode")) & "' AND ISNULL(VOID,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                        acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                        If accode = "" Then

                            MessageBox.Show("NO GL FOUND FOR STOCK POSTING...:-" & Trim(gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("opstorelocationcode")))
                            check = False
                            Exit Sub


                        End If

                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        sqlstring = sqlstring & " VALUES('" & Trim(issuedocno) & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'ISSUE', '" & accode & "',"
                        sqlstring = sqlstring & "'" & acdesc & "',"
                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        sqlstring = sqlstring & "'DEBIT',"


                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N')"
                        ReDim Preserve GrnQuery(GrnQuery.Length)
                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                    Else
                        MessageBox.Show("NO GL FOUND FOR STOCK POSTING...:-'" & Trim(gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("opstorelocationcode")) & "'")
                        Exit Sub
                    End If


                    sqlstring = "Select  * from AccountstaggingNew where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                        acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                        If accode = "" Then

                            MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                            check = False
                            Exit Sub


                        End If
                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        sqlstring = sqlstring & " VALUES('" & Trim(issuedocno) & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'ISSUE', '" & accode & "',"
                        sqlstring = sqlstring & "'" & acdesc & "',"
                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        sqlstring = sqlstring & "'CREDIT',"



                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N')"
                        ReDim Preserve GrnQuery(GrnQuery.Length)
                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                    Else
                        MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR StoreCode:-'" & txt_Storecode.Text & "'")
                        Exit Sub
                    End If
                Next
                gconnection.MoreTrans(GrnQuery)
            End If






        End If


    End Sub
    'Private Sub updateissueoperation()
    '    ' Dim docno1() As String
    '    Dim insert(0) As String
    '    Dim sqlstring As String
    '    Dim itemcode As String
    '    Dim i As Integer
    '    If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
    '        docno1 = Split(Trim(txt_Docno.Text), "/")
    '        sqlstring = "UPDATE STOCKISSUEHEADER SET Docdate='" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "', "
    '        sqlstring = sqlstring & " Storelocationcode='" & Trim(TXT_FROMSTORECODE.Text) & "',"
    '        sqlstring = sqlstring & " Storelocationname='" & Trim(txt_FromStorename.Text) & "',"
    '        sqlstring = sqlstring & " Opstorelocationcode='" & Trim(txt_Storecode.Text) & "',"
    '        sqlstring = sqlstring & " Opstorelocationname='" & Trim(txt_StoreDesc.Text) & "', "
    '        sqlstring = sqlstring & " Totalamt=" & Format(Val(txt_Totalamount.Text), "0.000") & ","
    '        sqlstring = sqlstring & " Remarks='" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,Void='N',"
    '        sqlstring = sqlstring & " VoidReason = '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "',Updateuser='" & Trim(gUsername) & "',"
    '        sqlstring = sqlstring & " Updatetime='" & Format(Now, "dd-MMM-yyyy") & "'"
    '        sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
    '        sqlstring = sqlstring & " AND INDENTNO = '" & Trim(Txt_IndentNo.Text) & "'"
    '        ReDim Preserve insert(insert.Length)
    '        insert(insert.Length - 1) = sqlstring

    '        '''********************************************************* DELETE FROM stockissuedetail *****************************************************'''
    '        sqlstring = "DELETE FROM STOCKISSUEDETAIL WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
    '        sqlstring = sqlstring & " AND INDENTNO = '" & Trim(Txt_IndentNo.Text) & "'"
    '        ReDim Preserve insert(insert.Length)
    '        insert(insert.Length - 1) = sqlstring
    '        For i = 1 To AxfpSpread1.DataRowCnt

    '            AxfpSpread1.Row = i
    '            sqlstring = "INSERT INTO STOCKISSUEDETAIL(Docno,Docdetails,Docdate,IndentNo,IndentDate,Storelocationcode,Storelocationname,"
    '            sqlstring = sqlstring & " Opstorelocationcode,Opstorelocationname,Itemcode,Itemname,Uom,IND_QTY,Qty,batchno,rate,amount,"
    '            sqlstring = sqlstring & " Void,Adduser,adddatetime,Updateuser,Updatetime)"
    '            sqlstring = sqlstring & " VALUES ('" & Trim(txt_Docno.Text) & "','" & Trim(txt_Docno.Text) & "',"
    '            sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
    '            sqlstring = sqlstring & " '" & Trim(Txt_IndentNo.Text) & "','" & Format(CDate(dtp_IndentDate.Value), "dd-MMM-yyyy") & "',"
    '            sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
    '            sqlstring = sqlstring & " '" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
    '            AxfpSpread1.Row = i

    '            AxfpSpread1.Col = 1
    '            itemcode = Trim(AxfpSpread1.Text)
    '            sqlstring = sqlstring & "'" & Trim(itemcode) & "',"
    '            AxfpSpread1.Col = 2
    '            sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
    '            AxfpSpread1.Col = 3
    '            sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
    '            AxfpSpread1.Col = 4
    '            sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","
    '            AxfpSpread1.Row = i

    '            AxfpSpread1.Col = 5
    '            Dim qty As Double = Val(AxfpSpread1.Text)
    '            sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","
    '            AxfpSpread1.Row = i

    '            AxfpSpread1.Col = 6
    '            sqlstring = sqlstring & "'" & AxfpSpread1.Text & "',"
    '            AxfpSpread1.Row = i

    '            AxfpSpread1.Col = 7
    '            Dim rate As Double = Val(AxfpSpread1.Text)
    '            sqlstring = sqlstring & "'" & Format(Val(rate), "0.000") & "',"
    '            sqlstring = sqlstring & "" & Format(qty * rate, "0.000") & ","

    '            sqlstring = sqlstring & "'N',"
    '            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "',"
    '            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
    '            ReDim Preserve insert(insert.Length)
    '            insert(insert.Length - 1) = sqlstring
    '            Dim qty1 As Double
    '            Dim batchyn As String
    '            Dim uom As String
    '            Dim uom1 As String
    '            Dim convvalue As Double
    '            Dim precise As Double
    '            Dim batchno As String
    '            Dim sql1 As String
    '            AxfpSpread1.Col = 3
    '            uom1 = AxfpSpread1.Text
    '            AxfpSpread1.Col = 6
    '            batchno = AxfpSpread1.Text
    '            If (costcenterflag = False) Then

    '                sql1 = "select qty,batchyn,uom,batchno from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
    '                sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
    '                If (batchno <> "") Then
    '                    sql1 = sql1 & " and  batchno='" + batchno + "' "
    '                End If

    '                gconnection.getDataSet(sql1, "closingqty")
    '                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
    '                    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
    '                    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
    '                    '                    batchno = gdataset.Tables("closingqty").Rows(0).Item("batchno")
    '                    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
    '                    Dim sql As String = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
    '                    gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
    '                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
    '                        convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
    '                        precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))

    '                    End If

    '                Else
    '                    qty1 = 0
    '                    convvalue = 1
    '                End If
    '                sql1 = "update closingqty set closingstock= closingstock +" + Format(Val((qty * (1 / convvalue)) + (qty * precise) - (qty1)), "0.000") + ",qty=" + Format((Val(qty / convvalue) + (qty * precise)), "0.000") + " "
    '                sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
    '                If (batchyn = "Y") Then
    '                    sql1 = sql1 & "  and  batchno='" + batchno + "'"
    '                End If
    '                ReDim Preserve insert(insert.Length)
    '                insert(insert.Length - 1) = sql1

    '                sql1 = "update closingqty set closingstock= closingstock +" + Format(Val((qty * (1 / convvalue) + (qty * precise)) - (qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val((qty * (1 / convvalue) + (qty * precise)) - (qty1)), "0.000") + ""
    '                ',closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
    '                ',openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
    '                sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
    '                If (batchyn = "Y") Then
    '                    sql1 = sql1 & "  and  batchno='" + txt_Docno.Text + "'"
    '                End If
    '                ReDim Preserve insert(insert.Length)
    '                insert(insert.Length - 1) = sql1
    '            End If

    '            sql1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
    '            sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
    '            If (batchno <> "") Then
    '                sql1 = sql1 & " and  batchno='" + batchno + "' "
    '            End If

    '            gconnection.getDataSet(sql1, "closingqty")
    '            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
    '                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
    '                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
    '                uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
    '                Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
    '                convvalue = gconnection.getvalue(sql)
    '            Else
    '                qty1 = 0
    '                convvalue = 1
    '            End If
    '            sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) - ((qty / convvalue) + (qty * precise))), "0.000") + ",qty=-" + Format(Val((qty / convvalue) + (qty * precise)), "0.000") + ""
    '            sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
    '            If (batchyn = "Y") Then
    '                sql1 = sql1 & "  and  batchno='" + batchno + "'"
    '            End If
    '            ReDim Preserve insert(insert.Length)
    '            insert(insert.Length - 1) = sql1

    '            sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) - ((qty / convvalue) + (qty * precise))), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1) - ((qty / convvalue) + (qty * precise))), "0.000") + ""
    '            ',closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
    '            ',openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
    '            sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
    '            If (batchyn = "Y") Then
    '                sql1 = sql1 & "  and  batchno='" + txt_Docno.Text + "'"
    '            End If
    '            ReDim Preserve insert(insert.Length)
    '            insert(insert.Length - 1) = sql1
    '        Next i
    '        'sql = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
    '        'sql = sql & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
    '        'sql = sql & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
    '        'sql = sql & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
    '        'sql = sql & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
    '        'sql = sql & " from inv_Inventoryuomstorelink a inner join closingqty b"
    '        'sql = sql & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
    '        'ReDim Preserve insert(insert.Length)
    '        'insert(insert.Length - 1) = sql

    '        gconnection.MoreTrans(insert)
    '    End If
    'End Sub

    Private Function check_Duplicate(ByVal Itemcode As String) As Boolean
        Dim i As Integer

        AxfpSpread1.Col = 1
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            If i <> AxfpSpread1.ActiveRow Then
                If Trim(AxfpSpread1.Text) = Trim(Itemcode) Then
                    MsgBox("Item Already exists", MsgBoxStyle.Critical, "Duplicate")
                    Return True
                End If
            End If
        Next
        Return False
    End Function
    Private Function check_taxcode() As Boolean
        Dim i As Integer
        Dim sqlstring As String
        AxfpSpread1.Col = 1
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            sqlstring = "Select taxcode from Itemtaxtagging where itemcode='" + AxfpSpread1.Text + "' "
            gconnection.getDataSet(sqlstring, "Itemtaxtagging")
            If (gdataset.Tables("Itemtaxtagging").Rows.Count = 0) Then
                MsgBox("Create TaxCode For item" + AxfpSpread1.Text, MsgBoxStyle.Critical, "TaxCode")
                Return True
            End If
        Next
        Return False
    End Function

    Private Function validateoninsert() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"))
        If checkBdate = True And RESU1 = False Then
            MsgBox("Business date closed..")
            flag = True
            Return flag
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
            flag = True
            Return flag
        End If

        If DateDiff(DateInterval.Day, (CDate(dtp_Grndate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("To Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        'If txt_Grnno.Text = "" Then
        '    MessageBox.Show("Please Fill GrnNo ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        '    flag = True
        '    Return flag
        'End If
        If txt_Storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_Storecode.BackColor = Color.Red
            txt_Storecode.Focus()

            flag = True
            Return flag
        Else
            txt_Storecode.BackColor = Color.White
        End If
        If Trim(CmbGrnType.SelectedItem) = "PO" Then
            If Txt_PONo.Text = "" And Txt_PONo.Visible = True Then
                MessageBox.Show("Please Fill POno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Txt_PONo.BackColor = Color.Red
                Txt_PONo.Focus()

                flag = True
                Return flag
            Else
                Txt_PONo.BackColor = Color.White

            End If
        ElseIf Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then

            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                If AxfpSpread1.Text <> "" Then
                    AxfpSpread1.Col = 19
                    Dim sqlstring As String = "SELECT isnull(SPONSORcode,'') as SPONSORcode,isnull(SPONSORdesc,'') as SPONSORdesc,isnull(freeze,'') as freeze,isnull(adddate,'') as adddate FROM inv_SPONSORmaster WHERE SPONSORcode='" & Trim(AxfpSpread1.Text) & "' AND  ISNULL(freeze,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "inv_SPONSORmaster")
                    If gdataset.Tables("inv_SPONSORmaster").Rows.Count > 0 Then


                    Else
                        MessageBox.Show("Please Fill Sponsor ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If

            Next


            'If TXT_Sponsor.Text = "" And TXT_Sponsor.Visible = True Then
            '    MessageBox.Show("Please Fill Sponsor ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Txt_PONo.BackColor = Color.Red
            '    Txt_PONo.Focus()

            '    flag = True
            '    Return flag
            'Else
            '    TXT_Sponsor.BackColor = Color.White
            'End If
        End If
        If txt_Suppliercode.Text = "" Then
            MessageBox.Show("Please Fill Vendor Code ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_Suppliercode.BackColor = Color.Red
            txt_Suppliercode.Focus()
            flag = True
            Return flag
        Else
            txt_Suppliercode.BackColor = Color.White
        End If

        If txt_Supplierinvno.Text <> "" And txt_Supplierinvno.Text <> "NA" Then
            sql = "select * from grn_header where isnull(void,'N')<>'Y' and Supplierinvno='" & txt_Supplierinvno.Text & "'"
            gconnection.getDataSet(sql, "GH")
            If (gdataset.Tables("GH").Rows.Count > 0) Then
                MessageBox.Show(" Supplier inv. no. already Process in GRN NO. :" & gdataset.Tables("GH").Rows(0).Item("GRNDETAILS"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If

        End If

        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If

        If (gdirissue = "Y") Then
            nonstockable.Columns.Clear()
            Dim dc As New DataColumn("ItemCode", GetType(String))

            ' dc.ColumnName = "ItemCode"

            nonstockable.Columns.Add(dc)
            Dim dc1 As New DataColumn("ItemName", GetType(String))
            nonstockable.Columns.Add(dc1)

            Dim dc2 As New DataColumn("UOM", GetType(String))
            nonstockable.Columns.Add(dc2)
            Dim dc3 As New DataColumn("Quantity", GetType(Double))
            nonstockable.Columns.Add(dc3)

            Dim dc5 As New DataColumn("StoreCode", GetType(String))

            nonstockable.Columns.Add(dc5)
            Dim dc6 As New DataColumn("TotalQuantity", GetType(Double))
            nonstockable.Columns.Add(dc6)
            nonstockable.Rows.Clear()
        End If

        For j As Integer = 1 To AxfpSpread1.DataRowCnt
            Dim ITEM As String
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 1
            ITEM = AxfpSpread1.Text
            If Trim(CmbGrnType.SelectedItem) = "PO" Then
                sql = "Select isnull(quantity,0) as quantity,isnull(receivedqty,0) as receivedqty,isnull(qtyrange,'') as qtyrange,isnull(potype,'') as potype  from po_itemdetails inner join po_hdr on po_hdr.pono=po_itemdetails.pono and po_hdr.versionno=po_itemdetails.versionno where po_hdr.pono='" + Txt_PONo.Text + "' and po_hdr.versionno='" + versionno + "'and itemcode='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(sql, "po_itemdetails")
                If (gdataset.Tables("po_itemdetails").Rows.Count > 0) Then
                    Dim qtyrange As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("qtyrange"))
                    Dim qty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("quantity"))
                    Dim receivedqty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("receivedqty"))
                    If (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "FIXED RATE FIXED QUANTITY" Or gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "OPEN RATE FIXED QUANTITY") Then

                        AxfpSpread1.Col = 4
                        Dim quant As Double = Val(AxfpSpread1.Text)
                        If ((qty + qtyrange) - receivedqty < quant) Then
                            MessageBox.Show("Quantity Cannot be Greater than PO Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            AxfpSpread1.Text = ""
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                            flag = True
                            Return flag
                        End If
                    ElseIf (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "RATE IN RANGE QUANTITY IN RANGE") Then
                        AxfpSpread1.Col = 4
                        Dim quant As Double = Val(AxfpSpread1.Text)
                        If ((qty + qtyrange) - receivedqty < quant) Then
                            MessageBox.Show("Quantity Cannot be Greater than PO Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            AxfpSpread1.Text = ""
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                            flag = True
                            Return flag
                        End If
                    End If
                End If
            End If


            AxfpSpread1.Col = 4
            Dim grnqty As Double = Val(AxfpSpread1.Text)
            If (grnqty <= 0) Then
                MessageBox.Show("Quantity Cannot be Zero", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(4, j)

                flag = True
                Return flag

            End If
            AxfpSpread1.Col = 3

            If (AxfpSpread1.Text = "") Then
                MessageBox.Show("UOM Cannot be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(3, j)

                flag = True
                Return flag

            End If
            AxfpSpread1.Col = 5
            Dim grnrate As Double = Val(AxfpSpread1.Text)
            If (grnrate <= 0) Then
                MessageBox.Show("Rate Cannot be Zero", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(5, j)

                flag = True
                Return flag

            End If
            AxfpSpread1.Col = 7
            Dim grndis As Double = Val(AxfpSpread1.Text)
            If (grndis > 100) Then
                MessageBox.Show("Discount Cannot be Greater than 100%", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(7, j)
                flag = True
                Return flag

            End If


            AxfpSpread1.Col = 6
            Dim grndisAmt As Double = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 8
            If (grndisAmt < Val(AxfpSpread1.Text)) Then
                MessageBox.Show("Discount Cannot be Greater than Amt.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(8, j)
                flag = True
                Return flag

            End If

            If (gdirissue = "Y") Then

                AxfpSpread1.Col = 1
                sql = "sELECT * FROM INV_INVENTORYITEMMASTeR WHERE ITEMCODE='" + AxfpSpread1.Text + "' AND stockcategory='NONSTOCKABLE' "
                gconnection.getDataSet(sql, "INV_INVENTORYITEMMASTR")
                If (gdataset.Tables("INV_INVENTORYITEMMASTR").Rows.Count > 0) Then
                    Dim drow As DataRow
                    drow = nonstockable.NewRow
                    drow.Item("Itemcode") = AxfpSpread1.Text
                    AxfpSpread1.Col = 2
                    drow.Item("ItemName") = AxfpSpread1.Text
                    AxfpSpread1.Col = 3

                    drow.Item("Uom") = AxfpSpread1.Text


                    AxfpSpread1.Col = 17
                    Dim qty2 As Double
                    qty2 = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 4
                    drow.Item("quantity") = Val(AxfpSpread1.Text) + qty2
                    drow.Item("StoreCode") = ""
                    AxfpSpread1.Col = 4

                    drow.Item("TotalQuantity") = Val(AxfpSpread1.Text) + qty2
                    nonstockable.Rows.Add(drow)

                End If

            End If
            If CmbGrnType.Text = "DIRECT GRN" Then
                sql = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + ITEM + "'"
                gconnection.getDataSet(sql, "ITEM")
                If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                    If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then
                        AxfpSpread1.Col = 20
                        sql = " select * from InvCompany_ItemMaster where COMPANYCODE='" + AxfpSpread1.Text + "' AND ITEMCODE='" + ITEM + "' "
                        gconnection.getDataSet(sql, "InvCompany_ItemMaster")
                        If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then

                        Else
                            MessageBox.Show("Select Company Code .", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            AxfpSpread1.Text = ""
                            AxfpSpread1.SetActiveCell(20, j)
                            flag = True
                            Return flag
                        End If
                    End If
                End If
            End If


        Next

        If (gdirissue = "Y") Then
            If (nonstockable.Rows.Count > 0) Then
                Dim frm1 As New FrmDirectIssueing
                frm1.ShowDialog(Me)
                If (frm1.flg = True) Then

                Else
                    flag = True
                    Return flag
                End If
            End If
        End If

        If (GACCPOST.ToUpper() = "Y") Then
            If gAcPostingWise = "ITEM" Then
                For k As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = k
                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                        gconnection.getDataSet(sqlstring, "CODE")
                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")

                            If accode = "" Then

                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                flag = True
                                Return flag

                            End If
                        Else
                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                            flag = True
                            Return flag
                        End If
                    End If

                Next


            ElseIf gAcPostingWise = "CATEGORY" Then
                sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORYCODE " + Trim(CATCODE(0)) + "")
                        flag = True
                        Return flag


                    End If
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                    flag = True
                    Return flag

                End If
            Else
                sqlstring = "Select * from AccountstaggingnEW where  CODE='" & Trim(txt_Storecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE  " + Trim(txt_Storecode.Text) + "")
                        flag = True
                        Return flag


                    End If
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE " + Trim(txt_Storecode.Text) + "")
                    flag = True
                    Return flag
                End If

            End If
            If Val(txt_totaltax.Text) <> 0 Then
                Dim amount, POSTAMT As Double
                Dim TAXyN As String

                '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER ==========================

                For k As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = k

                    AxfpSpread1.Col = 10
                    TAXyN = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 1


                    If Trim(AxfpSpread1.Text) <> "" And TAXyN <> "" Then
                        If TAXyN = "NONE" Then
                            AxfpSpread1.Col = 12
                            POSTAMT = Val(AxfpSpread1.Text)
                            AxfpSpread1.Col = 1
                            sqlstring = "Select  isnull(taxrebate,'NO') AS taxrebate from INV_InventoryItemMaster where itemcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'"
                            gconnection.getDataSet(sqlstring, "INV_InventoryItemMaster")
                            If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                                If gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("taxrebate") = "YES" Then

                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS YES ==========================
                                    sqlstring = "Select * from accountstaxmaster where TAXCODE='" + TAXyN + "'"
                                    gconnection.getDataSet(sqlstring, "CODE")

                                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                        accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                        acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                                        If accode = "" Then

                                            MessageBox.Show("NO INPUTTAX A/C FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                            flag = True
                                            Return flag

                                        End If


                                    Else
                                        MessageBox.Show("NO INPUTTAX A/C FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                        flag = True
                                        Return flag

                                    End If
                                Else
                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS NO ==========================

                                    accode = ""
                                    acdesc = ""
                                    slcode = ""
                                    sldesc = ""
                                    costcode = ""
                                    costdesc = ""

                                    If gAcPostingWise = "ITEM" Then
                                        AxfpSpread1.Col = 1
                                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                            If accode = "" Then

                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(AxfpSpread1.Text) + "")
                                                flag = True
                                                Return flag

                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                            check = False
                                            Exit Function
                                        End If
                                    ElseIf gAcPostingWise = "CATEGORY" Then
                                        sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")

                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                                flag = True
                                                Return flag

                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                            check = False
                                            Exit Function

                                        End If
                                    Else
                                        sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountDESC")

                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                                                flag = True
                                                Return flag

                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                                            flag = True
                                            Return flag

                                        End If
                                    End If



                                End If
                            End If
                        Else
                            amount = 0
                            POSTAMT = 0

                            'For k1 As Integer = 1 To AxfpSpread1.DataRowCnt
                            '    AxfpSpread1.Row = k1

                            'AxfpSpread1.Col = 9
                            'amount = Val(AxfpSpread1.Text)

                            AxfpSpread1.Col = 10
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "Select  * from invtaxgroupmasterdetail where taxgroupcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'  "
                                gconnection.getDataSet(sqlstring, "invtaxgroupmasterdetail")
                                If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then

                                    For Z As Integer = 0 To gdataset.Tables("invtaxgroupmasterdetail").Rows.Count - 1
                                        'POSTAMT = (amount * Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAXPER"))) / 100

                                        If UCase(gShortname) <> "CCL" Then
                                            sqlstring = "select * from TaxAccountstagging where TaxCode='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "' AND ISNULL(VOID,'N')<>'Y'"
                                            gconnection.getDataSet(sqlstring, "TaxAccountstagging")

                                            If (gdataset.Tables("TaxAccountstagging").Rows.Count > 0) Then

                                            Else
                                                MessageBox.Show("NO GL A/C FOUND FOR '" + Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("taxgroupcode")) + "' TAXGROUPCODE")
                                                flag = True
                                                Return flag

                                            End If
                                        Else
                                            sqlstring = "Select * from accountstaxmaster where TAXCODE='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "'"
                                            gconnection.getDataSet(sqlstring, "CODE")

                                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                                accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                                acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")


                                                If accode = "" Then

                                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                    flag = True
                                                    Return flag
                                                End If


                                            Else
                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                flag = True
                                                Return flag
                                            End If
                                        End If

                                    Next Z
                                Else
                                    MessageBox.Show("TAX GROUP NOT FOUND : " + Trim(AxfpSpread1.Text) + "")
                                    flag = True
                                    Return flag

                                End If
                            End If



                            '  Next
                        End If

                    End If




                Next
                If CmbGrnType.Text = "SPONSOR" Then


                    For j As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = j
                        AxfpSpread1.Col = 1
                        If AxfpSpread1.Text <> "" Then
                            AxfpSpread1.Col = 19
                            Dim sqlstring As String = "SELECT * FROM SponsorAccountstagging WHERE code='" & Trim(AxfpSpread1.Text) & "' AND  ISNULL(VOID,'N') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If gdataset.Tables("CODE").Rows.Count > 0 Then

                                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                                If accode = "" Then

                                    MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING...")
                                    flag = True
                                    Return flag

                                End If
                                If accode <> "" And costcode = "" Then

                                    MessageBox.Show("NO COST CENTRE CODE FOR SPON. POSTING...")
                                    flag = True
                                    Return flag

                                End If

                            Else
                                MessageBox.Show("Please Fill Sponsor ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                flag = True
                                Return flag
                            End If
                        End If

                    Next
                End If
            End If

        End If

        'If check_taxcode() = True Then

        '    flag = True
        '    Return flag


        'End If
        Return False
    End Function

    Private Function validateonvoid() As Boolean

        Dim flag As Boolean
        Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"))
        If checkBdate = True And RESU1 = False Then
            MsgBox("Business date closed..")
            flag = True
            Return flag
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
            flag = True
            Return flag
        End If
        If txt_Grnno.Text = "" Then
            MessageBox.Show("Please Fill GrnNo ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag
        End If
        If CMB_CATEGORY.Text = "" Then
            MessageBox.Show("Please Select Category ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag
        End If

        If txt_Storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_Storecode.BackColor = Color.Red
            txt_Storecode.Focus()
            flag = True
            Return flag
        Else
            txt_Storecode.BackColor = Color.White

        End If
        If Trim(CmbGrnType.SelectedItem) = "PO" Then
            If Txt_PONo.Text = "" And Txt_PONo.Visible = True Then
                MessageBox.Show("Please Fill POno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Txt_PONo.BackColor = Color.Red
                Txt_PONo.Focus()

                flag = True
                Return flag
            Else
                Txt_PONo.BackColor = Color.White

            End If
        End If

        If txt_Suppliercode.Text = "" Then
            MessageBox.Show("Please Fill Vendor Code ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_Suppliercode.BackColor = Color.Red
            txt_Suppliercode.Focus()

            flag = True
            Return flag
        Else
            txt_Suppliercode.BackColor = Color.White

        End If

        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)
            flag = True
            Return flag
        End If



        'If check_taxcode() = True Then

        '    flag = True
        '    Return flag


        'End If




        'For i As Integer = 0 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Col = 1
        '    Dim itemcode As String = AxfpSpread1.Text
        '    AxfpSpread1.Col = 4
        '    Dim qty As String = Val(AxfpSpread1.Text)
        '    Dim qty1, trns_seq As Double
        '    Dim batchyn As String
        Dim sql As String
        '= "select qty,batchyn,isnull(trns_seq,0) as trns_seq from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
        '            sql = sql & " and Trnno='" + txt_Grnno.Text + "' "
        '            gconnection.getDataSet(sql, "closingqty")
        '            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '                trns_seq = gdataset.Tables("closingqty").Rows(0).Item("trns_seq")
        '            End If
        '            sql = "select closingstock -" + Format(Val(qty), "0.000") + " from closingqty where trns_seq>='" & trns_seq & "' and itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
        '            sql = sql & " and closingstock -" + Format(Val(qty), "0.000") + "<0 "
        '            If batchyn = "Y" Then
        '                sql = sql & " and batchno='" + txt_Grnno.Text + "'"
        '            End If
        '            gconnection.getDataSet(sql, "closingqty")
        '            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '                MessageBox.Show("Deletion create  " + itemcode + "  Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '                flag = True
        '                Return flag
        '            End If


        sql = "select G.grndetails,G.grndate,G.ITEMCODE,G.uom,(CASE WHEN ISNULL(C.CONVVALUE,0)=0 THEN (isnull(G.qty,0)) ELSE Cast((isnull(G.qty,0))/C.CONVVALUE as numeric(18,3)) END)  AS QTY,STOCKCATEGORY,ISNULL(S.Docdetails,'') AS Docdetails,(CASE WHEN ISNULL(C.CONVVALUE,0)=0 THEN (isnull(S.qty,0)) ELSE Cast((isnull(S.qty,0))/C.CONVVALUE as numeric(18,3)) END)  AS ISSUEQTY,ISNULL(G.storecode,'') AS storecode,ISNULL(S.opstorelocationcode,'') AS opstorelocationcode   from GRN_DETAILS  G "
        sql = sql & "INNER join INV_InventoryItemMaster I on G.Itemcode=I.ITEMCODE LEFT OUTER JOIN INVENTORY_TRANSCONVERSION C ON C.BASEUOM=I.STOCKUOM AND C.TRANSUOM=G.uom LEFT OUTER JOIN STOCKISSUEDETAIL S ON G.GRNDETAILS=S.BATCHNO AND G.Itemcode=S.Itemcode WHERE G.grndetails='" + txt_Grnno.Text + "'"
        gconnection.getDataSet(sql, "sTOCK")
        If (gdataset.Tables("sTOCK").Rows.Count > 0) Then
            Dim ITEMCODE, STORECODE, TRNNO As String
            Dim CQTY, ISSUEQTY As Double
            Dim CH As Boolean
            For J As Integer = 0 To gdataset.Tables("sTOCK").Rows.Count - 1
                ITEMCODE = gdataset.Tables("sTOCK").Rows(J).Item("ITEMCODE")
                If (gdirissue = "Y") And UCase(gdataset.Tables("sTOCK").Rows(J).Item("STOCKCATEGORY")) = "NONSTOCKABLE" Then
                    STORECODE = gdataset.Tables("sTOCK").Rows(J).Item("opstorelocationcode")
                    TRNNO = gdataset.Tables("sTOCK").Rows(J).Item("Docdetails")
                    CQTY = Val(gdataset.Tables("sTOCK").Rows(J).Item("ISSUEQTY"))
                Else
                    STORECODE = gdataset.Tables("sTOCK").Rows(J).Item("STORECODE")
                    TRNNO = gdataset.Tables("sTOCK").Rows(J).Item("grndetails")
                    CQTY = Val(gdataset.Tables("sTOCK").Rows(J).Item("QTY"))
                End If


                CH = CHECKNATIVESTOCK(ITEMCODE, STORECODE, TRNNO, CQTY)


                If CH = False Then
                    flag = True
                    Return flag
                    Exit Function

                End If

            Next
        End If






        Return False
    End Function


    Private Sub CALCULATE()
        Dim overalldisc, othercharge, extra, grossamt As Double
        Dim totqty, totamt, taxamt, discamt, freeqty, totfreeqty As Double
        Dim itemqty, itemrate, itemamount, itemtax, itemdisc, discperc, taxperc, itemtot, amtwithoutdisc, overdiscextra, overotherextra As Double
        calcbool = True
        If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Or AxfpSpread1.ActiveCol = 7 Or AxfpSpread1.ActiveCol = 8 Or AxfpSpread1.ActiveCol = 10 Or AxfpSpread1.ActiveCol = 12 Or AxfpSpread1.ActiveCol = 17 Then
            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 4
                itemqty = Val(AxfpSpread1.Text)
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 5
                itemrate = Val(AxfpSpread1.Text)
                If (itemrate = 0) Then
                    freeqty = itemqty
                Else
                    freeqty = 0
                End If
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 6
                itemamount = Nothing
                itemamount = itemqty * itemrate
                If Val(AxfpSpread1.Text) <> Val(itemamount) Then
                    AxfpSpread1.Text = Format(itemamount, "0.00")
                End If

                AxfpSpread1.Row = i
                AxfpSpread1.Col = 7
                discperc = Val(AxfpSpread1.Text)
                If AxfpSpread1.Text = "0.00" Or AxfpSpread1.Text = "" Then

                    AxfpSpread1.Col = 8
                    AxfpSpread1.Row = i

                    'taxperc = Val(AxfpSpread1.Text)
                    If AxfpSpread1.Text = "0.00" Then
                        itemdisc = (itemamount * discperc) / 100
                        AxfpSpread1.Text = itemdisc
                    Else

                        itemdisc = Val(AxfpSpread1.Text)
                    End If



                Else
                    itemdisc = (itemamount * discperc) / 100
                    AxfpSpread1.Col = 8
                    AxfpSpread1.Text = itemdisc
                    AxfpSpread1.Col = 9
                    amtwithoutdisc = itemamount - itemdisc
                    AxfpSpread1.Text = amtwithoutdisc
                End If

                AxfpSpread1.Col = 9
                amtwithoutdisc = itemamount - itemdisc
                AxfpSpread1.Text = amtwithoutdisc


                AxfpSpread1.Col = 11
                taxperc = Val(AxfpSpread1.Text)



                AxfpSpread1.Col = 10
                ' itemtax = Math.Round((amtwithoutdisc * taxperc) / 100)
                If AxfpSpread1.Text = "NONE" Then
                    itemtax = Math.Round((amtwithoutdisc * taxperc) / 100, 2)
                Else
                    itemtax = (amtwithoutdisc * taxperc) / 100
                End If
                AxfpSpread1.Col = 12
                AxfpSpread1.Text = itemtax
                AxfpSpread1.Col = 13

                itemtot = itemamount + itemtax - itemdisc
                AxfpSpread1.Text = itemtot
                totqty = totqty + itemqty
                totfreeqty = totfreeqty + freeqty
                totamt = totamt + itemamount
                taxamt = taxamt + itemtax
                discamt = discamt + itemdisc
                grossamt = grossamt + itemtot
            Next

            txt_totdisc.Text = discamt
            txt_totaltax.Text = Math.Round(taxamt, 2)
            txt_total.Text = totamt


            overalldisc = Convert.ToDouble(Format(Val(TXT_OVERALLdiscount.Text), 0.0))
            othercharge = Convert.ToDouble(Format(Val(txt_Surchargeamt.Text), 0.0))
            otherchargepo = othercharge
            If (gpocode = "Y" And totpoqty <> 0) Then
                extra = (othercharge - overalldiscountpo) / (totpoqty)
                ' extra = (otherchargepo - overalldiscountpo) / (totpoqty)
            Else
                extra = (othercharge - overalldisc) / (totqty - totfreeqty)
            End If
            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 4
                itemqty = Val(AxfpSpread1.Text)
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 5
                itemrate = Val(AxfpSpread1.Text)
                If (itemrate = 0) Then
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 15
                    AxfpSpread1.Text = 0
                Else
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 15
                    AxfpSpread1.Text = extra * itemqty
                    If (gpocode = "Y" And totpoqty <> 0) Then
                        overdiscextra = overdiscextra + (overalldiscountpo / totpoqty) * itemqty
                        overotherextra = overotherextra + (otherchargepo / totpoqty) * itemqty
                    Else
                        overotherextra = othercharge
                    End If

                End If
            Next
            If (gpocode = "Y") Then
                txt_Surchargeamt.Text = Format(Val(overotherextra), "0.000")
                ' TXT_OVERALLdiscount.Text = Format(Val(overdiscextra) + Val(TXT_OVERALLdiscount.Text), "0.000")

                TXT_OVERALLdiscount.Text = Format(Val(TXT_OVERALLdiscount.Text), "0.000")
            End If
            '  txt_Billamount.Text = Format(Val(txt_total.Text) - Val(overalldisc) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")
            If UCase(gShortname) = "BRC" Then
                Dim bILLAMT, DisAmt, dif As Double

                txt_Billamount.Text = Format(Val(txt_total.Text) - Val(TXT_OVERALLdiscount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")
                bILLAMT = Val(txt_Billamount.Text)
                txt_Billamount.Text = Math.Round(Val(txt_Billamount.Text), 0)
                If bILLAMT < Val(txt_Billamount.Text) Then
                    dif = Val(txt_Billamount.Text) - bILLAMT
                    TXT_OVERALLdiscount.Text = Format(Val(TXT_OVERALLdiscount.Text) + dif, "0.000")
                Else
                    dif = bILLAMT - Val(txt_Billamount.Text)
                    txt_Surchargeamt.Text = Format(Val(txt_Surchargeamt.Text) + dif, "0.000")
                End If

            Else
                txt_Billamount.Text = Format(Val(txt_total.Text) - Val(TXT_OVERALLdiscount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")
            End If

        End If
        calcbool = False
    End Sub
    Private Sub Calculateontext()
        Dim overalldisc, othercharge, extra, grossamt As Double
        Dim totqty, totamt, taxamt, discamt, freeqty, totfreeqty As Double
        Dim itemqty, itemrate, itemamount, itemtax, itemdisc, discperc, taxperc, itemtot, amtwithoutdisc, overdiscextra, overotherextra As Double

        If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Or AxfpSpread1.ActiveCol = 7 Or AxfpSpread1.ActiveCol = 8 Then

            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 4
                itemqty = Val(AxfpSpread1.Text)
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 5
                itemrate = Val(AxfpSpread1.Text)
                If (itemrate = 0) Then
                    freeqty = itemqty
                Else
                    freeqty = 0
                End If
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 6
                itemamount = itemqty * itemrate
                AxfpSpread1.Text = itemamount
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 7
                discperc = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 8
                AxfpSpread1.Row = i
                'taxperc = Val(AxfpSpread1.Text)
                itemdisc = (itemamount * discperc) / 100
                AxfpSpread1.Text = itemdisc
                AxfpSpread1.Col = 9
                amtwithoutdisc = itemamount - itemdisc
                AxfpSpread1.Text = amtwithoutdisc


                AxfpSpread1.Col = 11
                taxperc = AxfpSpread1.Text



                AxfpSpread1.Col = 12
                itemtax = (amtwithoutdisc * taxperc) / 100
                AxfpSpread1.Text = itemtax
                AxfpSpread1.Col = 13

                itemtot = itemamount + itemtax - itemdisc
                AxfpSpread1.Text = itemtot
                totqty = totqty + itemqty
                totfreeqty = totfreeqty + freeqty
                totamt = totamt + itemamount
                taxamt = taxamt + itemtax
                discamt = discamt + itemdisc
                grossamt = grossamt + itemtot
            Next

            txt_totdisc.Text = discamt
            txt_totaltax.Text = Math.Round(taxamt, 2)
            txt_total.Text = totamt


            overalldisc = Convert.ToDouble(Format(Val(TXT_OVERALLdiscount.Text), 0.0))
            othercharge = Convert.ToDouble(Format(Val(txt_Surchargeamt.Text), 0.0))


            extra = (othercharge - overalldisc) / (totqty - totfreeqty)

            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 4
                itemqty = Val(AxfpSpread1.Text)
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 5
                itemrate = Val(AxfpSpread1.Text)
                If (itemrate = 0) Then
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 15
                    AxfpSpread1.Text = 0
                Else
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 15
                    AxfpSpread1.Text = extra * itemqty

                    overdiscextra = overdiscextra + (overalldisc / totqty) * itemqty
                    overotherextra = overotherextra + (othercharge / totqty) * itemqty
                End If


            Next
            If (gpocode = "Y") Then
                txt_Surchargeamt.Text = Format(Val(overotherextra), "0.000")
                TXT_OVERALLdiscount.Text = Format(Val(overdiscextra), "0.000")

            End If
            '  txt_Billamount.Text = Format(Val(txt_total.Text) - Val(overalldisc) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")

            txt_Billamount.Text = Format(Val(txt_total.Text) - Val(TXT_OVERALLdiscount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")

        End If
    End Sub
    Private Sub clearoperation()
        Txt_PONo.Text = ""
        TXT_Sponsor.Text = ""
        LBL_SPONSOR.Hide()
        TXT_Sponsor.Hide()
        cmd_SPONhelp.Hide()
        lbl_Freeze.Text = ""
        txt_Grnno.Text = ""
        If CmbGrnType.Text <> "PO" Then
            CmbGrnType.Text = "PO"
        End If
        CmbGrnType.Enabled = True
        CMB_CATEGORY.Enabled = True

        Label4.Show()
        Txt_PONo.Show()
        cmd_PONOhelp.Show()

        'autogenerate()
        dtp_Grndate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Suppliercode.Text = ""
        txt_Suppliername.Text = ""
        txt_Supplierinvno.Text = ""
        dtp_Supplierinvdate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Storecode.Text = ""
        txt_StoreDesc.Text = ""
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        txt_total.Text = ""
        txt_totaltax.Text = ""
        txt_totdisc.Text = ""
        TXT_OVERALLdiscount.Text = ""
        txt_Surchargeamt.Text = ""
        txt_Billamount.Text = ""
        txt_Remarks.Text = ""
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        Cmd_Add.Enabled = True
        Cmd_Freeze.Enabled = True
        GridUnLock()
        nonstockable.Rows.Clear()

        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True

        nonstockable.Columns.Clear()
        For k As Integer = 0 To 10
            For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                AxfpSpread1.TypeComboBoxClear(3, k)
                AxfpSpread1.TypeComboBoxClear(18, k)
            Next
        Next
    End Sub
    Private Sub clearoperation1()
        Txt_PONo.Text = ""
        TXT_Sponsor.Text = ""
        'LBL_SPONSOR.Hide()
        'TXT_Sponsor.Hide()
        'cmd_SPONhelp.Hide()
        'CmbGrnType.SelectedItem = "PO"
        'Label4.Show()
        'Txt_PONo.Show()
        'cmd_PONOhelp.Show()

        '  autogenerate()
        dtp_Grndate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Suppliercode.Text = ""
        txt_Suppliername.Text = ""
        txt_Supplierinvno.Text = ""
        dtp_Supplierinvdate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Storecode.Text = ""
        txt_StoreDesc.Text = ""
        'AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        txt_total.Text = ""
        txt_totaltax.Text = ""
        txt_totdisc.Text = ""
        TXT_OVERALLdiscount.Text = ""
        txt_Surchargeamt.Text = ""
        txt_Billamount.Text = ""
        txt_Remarks.Text = ""
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        Cmd_Add.Enabled = True
        ' GridUnLock()
        nonstockable.Rows.Clear()

        nonstockable.Columns.Clear()
        If AxfpSpread1.IsHandleCreated = True Then

            AxfpSpread1.Row = 1
            AxfpSpread1.Col = 19
            If AxfpSpread1.ColHidden = False Then
                For RW As Integer = 1 To 100

                    AxfpSpread1.Col = 19
                    AxfpSpread1.ColHidden = True
                Next
            End If
        End If

    End Sub

    Private Function addoperation()

        Dim sqlstring As String
        Dim itemcode1 As String
        Dim uom As String
        Dim fquom As String
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        Dim weightedrate As Double
        Dim lastweightedrate As Double
        Dim STOCKUOM As String
        Dim CONVVALUE As Double
        Dim FQCONVVALUE As Double
        Dim precise As Double
        Dim fqprecise As Double
        Try


            If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                Call autogenerate()
            End If
            GRNno = Split(Trim(txt_Grnno.Text), "/")
            CATCODE = Split(CMB_CATEGORY.Text, "--->")


            sqlstring = "INSERT INTO Grn_header(category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
            ' sqlstring = sqlstring & ",Typecode,Typedesc,Excisepassno,Excisedate,Stockindate,Trucknumber,Creditdays,Glaccountcode,Glaccountname,Slcode,Slname,Costcentercode,Costcentername,"
            sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,GRN_TYPE1)"

            If Trim(CmbGrnType.SelectedItem) = "PO" And grp_Grngroup1.Visible = True Then

                If UCase(gpocode) <> "Y" Then
                    versionno = Trim(txt_Grnno.Text + "-0")
                    potype = Trim("")
                End If

                sqlstring = sqlstring & " VALUES ('" & Trim(CATCODE(0)) & "','" & CStr(GRNno(3)) & "','" & Trim(CStr(txt_Grnno.Text)) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
                '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
                '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
                ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
                sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.000") & "," & Format(Val(txt_totaltax.Text), "0.000") & "," & Format(Val(txt_Surchargeamt.Text), "0.000") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.000") & "," & Format(Val(txt_totdisc.Text), "0.000") & ","
                sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.000") & ","
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',GETDATE(),"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
                sqlstring = sqlstring & "  'GRN','" + versionno + "','" + CmbGrnType.Text + "')"
            Else

                sqlstring = sqlstring & " VALUES ('" & Trim(CATCODE(0)) & "','" & CStr(GRNno(3)) & "','" & Trim(CStr(txt_Grnno.Text)) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_Sponsor.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
                '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
                '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
                ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
                sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.000") & "," & Format(Val(txt_totaltax.Text), "0.000") & "," & Format(Val(txt_Surchargeamt.Text), "0.000") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.000") & "," & Format(Val(txt_totdisc.Text), "0.000") & ","
                sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.000") & ","
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',GETDATE(),"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
                sqlstring = sqlstring & "  'GRN','','" + CmbGrnType.Text + "')"

            End If

            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            ' Dim Seq As Double = gconnection.getInvSeq(Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy"))
            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                Dim fqqty As Double
                Dim qty1 As Double
                If Trim(CmbGrnType.SelectedItem) = "PO" Then
                    sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
                    sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,Discount,amountafterdiscount,taxcode,TaxPer,taxamount,amount,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FqUom,SPONSORCODE)"
                    sqlstring = sqlstring & " VALUES('" & CStr(GRNno(3)) & "','" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
                    sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
                    sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
                    AxfpSpread1.Col = 1
                    itemcode1 = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 3
                    uom = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 4
                    qty1 = Format(Val(AxfpSpread1.Text), "0.000")
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 5
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 6
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 7
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 8
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 9
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 10
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

                    AxfpSpread1.Col = 11
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 12
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 13
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    totalamount = Val(AxfpSpread1.Text)
                    ' sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                    AxfpSpread1.Col = 14
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                    AxfpSpread1.Col = 15
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    totalothchg = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 16
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

                    sqlstring = sqlstring & "'" & Trim(CATCODE(0)) & "',"
                    sqlstring = sqlstring & "'" & Trim(gUsername) & "',GETDATE(),"
                    sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
                    sqlstring = sqlstring & "'GRN','" + versionno + "',"

                    AxfpSpread1.Col = 17
                    fqqty = Format(Val(AxfpSpread1.Text), "0.000")
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 18
                    fquom = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 19

                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "')"
                Else
                    sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
                    sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,Discount,amountafterdiscount,taxcode,TaxPer,taxamount,amount,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FREEQTY,FqUom,SPONSORCODE,companycode)"
                    sqlstring = sqlstring & " VALUES('" & CStr(GRNno(3)) & "','" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"

                    sqlstring = sqlstring & " '" & Trim(TXT_Sponsor.Text) & " ',"
                    sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
                    AxfpSpread1.Col = 1
                    itemcode1 = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 3
                    uom = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 4
                    qty1 = Format(Val(AxfpSpread1.Text), "0.000")
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 5
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 6
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 7
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 8
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 9
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 10
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

                    AxfpSpread1.Col = 11
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 12
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 13
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    totalamount = Val(AxfpSpread1.Text)
                    ' sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                    AxfpSpread1.Col = 14
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                    AxfpSpread1.Col = 15
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    totalothchg = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 16
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

                    sqlstring = sqlstring & "'" & Trim(CATCODE(0)) & "',"
                    sqlstring = sqlstring & "'" & Trim(gUsername) & "',GETDATE(),"
                    sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
                    sqlstring = sqlstring & "'GRN','',"

                    AxfpSpread1.Col = 17
                    fqqty = Format(Val(AxfpSpread1.Text), "0.000")
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 18
                    fquom = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 19

                    sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 20

                    sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "')"
                End If
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring



                sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode1 + "'"
                STOCKUOM = gconnection.getvalue(sqlstring)
                sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
                gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                Else
                    MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
                '=====Adding Free Qty for CCL ==========
                If Trim(UCase(gShortname)) = "CCL" Then
                    sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + fquom + "'"
                    gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        FQCONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                        fqprecise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                        fqqty = (fqqty / FQCONVVALUE) + (fqqty * fqprecise)
                        qty1 = qty1 + fqqty
                    Else
                        MessageBox.Show("Generate relation between " + uom + " and " + fquom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Function
                    End If
                Else

                End If

                sqlstring = "insert into ratelist(grnno,batchno,itemcode,uom,batchrate,grndate,weightedrate,lastweightedrate,storecode,adddate,adduser)"
                sqlstring = sqlstring & " values ('" + txt_Grnno.Text + "',"
                AxfpSpread1.Col = 14
                sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
                AxfpSpread1.Col = 1
                sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
                AxfpSpread1.Col = 3
                sqlstring = sqlstring & "'" + AxfpSpread1.Text + "', "
                AxfpSpread1.Col = 5
                sqlstring = sqlstring & "'" + Format(Val((totalamount + totalothchg) / qty1), "0.000") + "' ,"
                sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
                sqlstring = sqlstring & "0 , "
                sqlstring = sqlstring & "0 , "
                sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',GETDATE(),'" & Trim(gUsername) & "')"
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

            Next

            If (GACCPOST.ToUpper() = "Y") Then
                Call accountPost()
                If check = False Then
                    Exit Function
                End If
            End If

            If (gdirissue = "Y") Then
                If nonstockable.Rows.Count > 0 Then
                    Call Addissueoperation()
                End If

            End If

            'If Trim(CmbGrnType.SelectedItem) = "PO" And Trim(UCase(gShortname)) = "CCL" Then
            '    Dim SQL As String = "select count(*) as a from  po_itemdetails where ISNULL(qtystatus,'') <> 'RECEIVED' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            '    gconnection.getDataSet(SQL, "po_itemdetails")
            '    If gdataset.Tables("po_itemdetails").Rows.Count > 0 Then
            '        If Val(gdataset.Tables("po_itemdetails").Rows(0).Item("a").ToString()) > 0 Then

            '        Else
            '            sqlstring = "update po_hdr set postatus='CLOSED' where   pono='" + Txt_PONo.Text + "' AND POTYPE NOT IN ('FIXED RATE OPEN QUANTITY' ,'OPEN RATE OPEN QUANTITY') AND VERSIONNO='" + versionno + "'"
            '            gconnection.dataOperation(6, sqlstring, )
            '        End If
            '    End If
            'End If

        Catch ex As Exception
            Throw
        End Try

    End Function




    Private Sub accountPost()

        Dim sqlstring As String
        check = False
        ' Dim INSERT(0) As String
        '========================= POSTING FOR SPONSOR CREDIT===========================================

        If Trim(CmbGrnType.SelectedItem) = "SPONSOR" And CmbGrnType.Visible = True Then

            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                If AxfpSpread1.Text <> "" Then
                    AxfpSpread1.Col = 19
                    sqlstring = "Select * from SponsorAccountstagging where code='" & AxfpSpread1.Text & "' AND  isnull(VOID,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                        acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                        If accode = "" Then

                            MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING...")
                            check = False
                            Exit Sub

                        End If
                        If accode <> "" And costcode = "" Then

                            MessageBox.Show("NO COST CENTRE CODE FOR SPON. POSTING...")
                            check = False
                            Exit Sub

                        End If
                        AxfpSpread1.Col = 13

                        amt = Val(AxfpSpread1.Text)
                        If amt > 0 Then


                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                            sqlstring = sqlstring & "'" & acdesc & "',"
                            sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                            sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'CREDIT',"
                            'amt = Format(Val(txt_Billamount.Text), "0.000")
                            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                            sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                            slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N')"
                            ReDim Preserve GrnQuery(GrnQuery.Length)
                            GrnQuery(GrnQuery.Length - 1) = sqlstring
                        End If
                    Else
                        MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING. : '" & TXT_Sponsor.Text & "'")
                        check = False
                        Exit Sub
                    End If
                End If

            Next


            If gAcPostingWise = "ITEM" Then

                Dim amount, POSTAMT As Double
                For k As Integer = 1 To AxfpSpread1.DataRowCnt

                    AxfpSpread1.Row = k
                    AxfpSpread1.Col = 9
                    amount = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                        gconnection.getDataSet(sqlstring, "CODE")
                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                            If accode = "" Then

                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                check = False
                                Exit Sub


                            End If
                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                            sqlstring = sqlstring & "'" & acdesc & "',"
                            sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                            sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'DEBIT',"

                            amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                            sqlstring = sqlstring & "'" & amount & "','" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N')"
                            ReDim Preserve GrnQuery(GrnQuery.Length)
                            GrnQuery(GrnQuery.Length - 1) = sqlstring
                        Else
                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                            check = False
                            Exit Sub

                        End If
                    End If

                Next

            ElseIf gAcPostingWise = "CATEGORY" Then
                sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                        check = False
                        Exit Sub


                    End If
                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                    sqlstring = sqlstring & "'" & acdesc & "',"
                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                    sqlstring = sqlstring & "'DEBIT',"

                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    'slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N')"
                    ReDim Preserve GrnQuery(GrnQuery.Length)
                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                    check = False
                    Exit Sub

                End If

            Else
                sqlstring = "Select * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                        check = False
                        Exit Sub


                    End If


                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    If amt > 0 Then


                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                        sqlstring = sqlstring & "'" & acdesc & "',"
                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        sqlstring = sqlstring & "'DEBIT',"


                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N')"
                        ReDim Preserve GrnQuery(GrnQuery.Length)
                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                    End If
                Else
                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                    check = False
                    Exit Sub
                End If




            End If


            If Val(txt_totaltax.Text) <> 0 Then


                Dim amount, POSTAMT As Double
                Dim TAXyN As String

                '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER ==========================





                For k As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = k

                    AxfpSpread1.Col = 10
                    TAXyN = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 1


                    If Trim(AxfpSpread1.Text) <> "" And TAXyN <> "" Then
                        If TAXyN = "NONE" Then
                            AxfpSpread1.Col = 12
                            POSTAMT = Val(AxfpSpread1.Text)
                            AxfpSpread1.Col = 1
                            sqlstring = "Select  isnull(taxrebate,'NO') AS taxrebate from INV_InventoryItemMaster where itemcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'"
                            gconnection.getDataSet(sqlstring, "INV_InventoryItemMaster")
                            If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                                If gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("taxrebate") = "YES" Then

                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS YES ==========================
                                    sqlstring = "Select * from accountstaxmaster where TAXCODE='" + TAXyN + "'"
                                    gconnection.getDataSet(sqlstring, "CODE")

                                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                        accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                        acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                                        'slcode = gdataset.Tables("CODE").Rows(0).Item("subledgercode")
                                        'sldesc = gdataset.Tables("CODE").Rows(0).Item("subledgerdesc")
                                        'costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                        'costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                        slcode = "" : sldesc = "" : costcode = "" : costdesc = ""
                                        If accode = "" Then

                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                            check = False
                                            Exit Sub
                                        End If

                                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                        sqlstring = sqlstring & "'" & acdesc & "',"
                                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                        sqlstring = sqlstring & "'DEBIT',"
                                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                        sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                        slcode = txt_Storecode.Text
                                        sqlstring = sqlstring & "'N')"
                                        ReDim Preserve GrnQuery(GrnQuery.Length)
                                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                                    Else
                                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                        check = False
                                        Exit Sub
                                    End If
                                Else
                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS NO ==========================

                                    accode = ""
                                    acdesc = ""
                                    slcode = ""
                                    sldesc = ""
                                    costcode = ""
                                    costdesc = ""

                                    If gAcPostingWise = "ITEM" Then
                                        AxfpSpread1.Col = 1
                                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then

                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(AxfpSpread1.Text) + "")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                            check = False
                                            Exit Sub
                                        End If
                                    ElseIf gAcPostingWise = "CATEGORY" Then
                                        sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                            check = False
                                            Exit Sub

                                        End If
                                    Else
                                        sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountDESC")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                                            check = False
                                            Exit Sub
                                        End If
                                    End If
                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'DEBIT',"
                                    'amt = Format(Val(txt_totaltax.Text), "0.000")
                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                    sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                    slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N')"
                                    ReDim Preserve GrnQuery(GrnQuery.Length)
                                    GrnQuery(GrnQuery.Length - 1) = sqlstring

                                End If
                            End If
                        Else
                            amount = 0
                            POSTAMT = 0

                            'For k1 As Integer = 1 To AxfpSpread1.DataRowCnt
                            '    AxfpSpread1.Row = k1

                            AxfpSpread1.Col = 9
                            amount = Val(AxfpSpread1.Text)

                            AxfpSpread1.Col = 10
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "Select  tax,taxper from invtaxgroupmasterdetail where taxgroupcode='" & Trim(AxfpSpread1.Text) & "'   AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)  AND ISNULL(VOID,'N')<>'Y'  "
                                gconnection.getDataSet(sqlstring, "invtaxgroupmasterdetail")
                                If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then



                                    For Z As Integer = 0 To gdataset.Tables("invtaxgroupmasterdetail").Rows.Count - 1

                                        POSTAMT = (amount * Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAXPER"))) / 100
                                        If POSTAMT > 0 Then
                                            If UCase(gShortname) <> "CCL" Then
                                                sqlstring = "select * from TaxAccountstagging where TaxCode='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "' AND ISNULL(VOID,'N')<>'Y'"
                                                gconnection.getDataSet(sqlstring, "TaxAccountstagging")
                                                If (gdataset.Tables("TaxAccountstagging").Rows.Count > 0) Then

                                                    accode = gdataset.Tables("TaxAccountstagging").Rows(0).Item("GLACCOUNTCODE")
                                                    acdesc = gdataset.Tables("TaxAccountstagging").Rows(0).Item("GLACCOUNTDESC")
                                                    slcode = gdataset.Tables("TaxAccountstagging").Rows(0).Item("slcode")
                                                    sldesc = gdataset.Tables("TaxAccountstagging").Rows(0).Item("sldesc")
                                                    costcode = ""
                                                    costdesc = ""
                                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                                    sqlstring = sqlstring & "'DEBIT',"
                                                    'amt = Format(Val(txt_totaltax.Text), "0.000")
                                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                                    sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                                    slcode = txt_Storecode.Text
                                                    sqlstring = sqlstring & "'N')"
                                                    ReDim Preserve GrnQuery(GrnQuery.Length)
                                                    GrnQuery(GrnQuery.Length - 1) = sqlstring


                                                Else
                                                    MessageBox.Show("NO GL A/C FOUND FOR " + Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("taxcode")) + " TAXCODE")
                                                    check = False
                                                    Exit Sub
                                                End If
                                            Else

                                                sqlstring = "Select * from accountstaxmaster where TAXCODE='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "'"
                                                gconnection.getDataSet(sqlstring, "CODE")

                                                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                                    accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                                    acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                                                    'slcode = gdataset.Tables("CODE").Rows(0).Item("subledgercode")
                                                    'sldesc = gdataset.Tables("CODE").Rows(0).Item("subledgerdesc")
                                                    'costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                                    'costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                                    slcode = "" : sldesc = "" : costcode = "" : costdesc = ""
                                                    If accode = "" Then

                                                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                        check = False
                                                        Exit Sub
                                                    End If

                                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                                    sqlstring = sqlstring & "'DEBIT',"
                                                    'amt = Format(Val(txt_totaltax.Text), "0.000")
                                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                                    sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                                    slcode = txt_Storecode.Text
                                                    sqlstring = sqlstring & "'N')"
                                                    ReDim Preserve GrnQuery(GrnQuery.Length)
                                                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                                                Else
                                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                    check = False
                                                    Exit Sub
                                                End If
                                            End If
                                        End If


                                    Next Z
                                Else
                                    MessageBox.Show("TAX GROUP NOT FOUND")
                                    check = False
                                    Exit Sub
                                End If
                            End If



                            '  Next
                        End If

                    End If




                Next
                'End If

            End If



            '====================== POSTING FOR PO PART==========================
        Else
            '====================== POSTING FOR SUPPLIER (CREDIT)==========================
            sqlstring = "select slcode, sldesc,ACCODE,ACDESC from accountssubledgermaster  WHERE "
            sqlstring = sqlstring & "SLCODE='" & txt_Suppliercode.Text & "' AND  isnull(freezeflag,'')<>'Y'  and accode in( select ScrsCode from ACCOUNTSSETUP)"
            gconnection.getDataSet(sqlstring, "SLCODE1")

            If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                accode = gdataset.Tables("SLCODE1").Rows(0).Item("ACCODE")
                slcode = gdataset.Tables("SLCODE1").Rows(0).Item("SLCODE")
                sldesc = gdataset.Tables("SLCODE1").Rows(0).Item("SLDESC")
                acdesc = gdataset.Tables("SLCODE1").Rows(0).Item("ACDESC")
            Else
                MessageBox.Show("CREATE SLCODE FOR SUPPLIER IN ACCOUNTSSUBLEDGERMASTER...")
                check = False
                Exit Sub
            End If
            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID)"
            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
            sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
            sqlstring = sqlstring & "'" & acdesc & "',"
            sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
            ' sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
            sqlstring = sqlstring & "'CREDIT',"
            amt = Format(Val(txt_Billamount.Text), "0.000")
            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
            sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

            slcode = txt_Storecode.Text
            sqlstring = sqlstring & "'N')"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring
            '====================== POSTING FOR PO PART  DEBIT SIDE ==========================
            If gAcPostingWise = "ITEM" Then

                Dim amount, POSTAMT As Double
                For k As Integer = 1 To AxfpSpread1.DataRowCnt

                    AxfpSpread1.Row = k

                    AxfpSpread1.Col = 9
                    amount = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                        gconnection.getDataSet(sqlstring, "CODE")
                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                            If accode = "" Then

                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(AxfpSpread1.Text) + "")
                                check = False
                                Exit Sub


                            End If
                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                            sqlstring = sqlstring & "'" & acdesc & "',"
                            sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                            sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'DEBIT',"

                            amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                            sqlstring = sqlstring & "'" & amount & "','" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N')"
                            ReDim Preserve GrnQuery(GrnQuery.Length)
                            GrnQuery(GrnQuery.Length - 1) = sqlstring
                        Else
                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                            check = False
                            Exit Sub

                        End If
                    End If

                Next




            ElseIf gAcPostingWise = "CATEGORY" Then
                sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                        check = False
                        Exit Sub


                    End If
                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                    sqlstring = sqlstring & "'" & acdesc & "',"
                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                    sqlstring = sqlstring & "'DEBIT',"

                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    'slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N')"
                    ReDim Preserve GrnQuery(GrnQuery.Length)
                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                    check = False
                    Exit Sub

                End If

            Else
                sqlstring = "Select * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                        check = False
                        Exit Sub


                    End If
                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                    sqlstring = sqlstring & "'" & acdesc & "',"
                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                    sqlstring = sqlstring & "'DEBIT',"

                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    'slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N')"
                    ReDim Preserve GrnQuery(GrnQuery.Length)
                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                Else
                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                    check = False
                    Exit Sub
                End If




            End If




            '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) ==========================


            If Val(txt_totaltax.Text) <> 0 Then


                Dim amount, POSTAMT As Double
                Dim TAXyN As String

                '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER ==========================





                For k As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = k

                    AxfpSpread1.Col = 10
                    TAXyN = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 1


                    If Trim(AxfpSpread1.Text) <> "" And TAXyN <> "" Then
                        If TAXyN = "NONE" Then
                            AxfpSpread1.Col = 12
                            POSTAMT = Val(AxfpSpread1.Text)
                            AxfpSpread1.Col = 1
                            sqlstring = "Select  isnull(taxrebate,'NO') AS taxrebate from INV_InventoryItemMaster where ITEMcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'"
                            gconnection.getDataSet(sqlstring, "INV_InventoryItemMaster")
                            If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                                If gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("taxrebate") = "YES" Then

                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS YES ==========================
                                    sqlstring = "Select * from accountstaxmaster where TAXCODE='" + TAXyN + "'"
                                    gconnection.getDataSet(sqlstring, "CODE")

                                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                        accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                        acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                                        'slcode = gdataset.Tables("CODE").Rows(0).Item("subledgercode")
                                        'sldesc = gdataset.Tables("CODE").Rows(0).Item("subledgerdesc")
                                        'costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                        'costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                        slcode = ""
                                        sldesc = ""
                                        costcode = ""
                                        costdesc = ""
                                        If accode = "" Then

                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                            check = False
                                            Exit Sub
                                        End If

                                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                        sqlstring = sqlstring & "'" & acdesc & "',"
                                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                        sqlstring = sqlstring & "'DEBIT',"
                                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                        sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                        slcode = txt_Storecode.Text
                                        sqlstring = sqlstring & "'N')"
                                        ReDim Preserve GrnQuery(GrnQuery.Length)
                                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                                    Else
                                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                        check = False
                                        Exit Sub
                                    End If
                                Else
                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS NO ==========================

                                    accode = ""
                                    acdesc = ""
                                    slcode = ""
                                    sldesc = ""
                                    costcode = ""
                                    costdesc = ""

                                    If gAcPostingWise = "ITEM" Then
                                        AxfpSpread1.Col = 1
                                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then

                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(AxfpSpread1.Text) + "")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                            check = False
                                            Exit Sub
                                        End If
                                    ElseIf gAcPostingWise = "CATEGORY" Then
                                        sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                            check = False
                                            Exit Sub

                                        End If
                                    Else
                                        sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("AccountDESC")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                                            check = False
                                            Exit Sub
                                        End If
                                    End If
                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'DEBIT',"
                                    'amt = Format(Val(txt_totaltax.Text), "0.000")
                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                    sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                    slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N')"
                                    ReDim Preserve GrnQuery(GrnQuery.Length)
                                    GrnQuery(GrnQuery.Length - 1) = sqlstring

                                End If
                            End If
                        Else
                            amount = 0
                            POSTAMT = 0
                            AxfpSpread1.Col = 9
                            amount = Val(AxfpSpread1.Text)

                            AxfpSpread1.Col = 10
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "Select  tax,taxper from invtaxgroupmasterdetail where taxgroupcode='" & Trim(AxfpSpread1.Text) & "'   AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)  AND ISNULL(VOID,'N')<>'Y'  "
                                gconnection.getDataSet(sqlstring, "invtaxgroupmasterdetail")
                                If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then

                                    For Z As Integer = 0 To gdataset.Tables("invtaxgroupmasterdetail").Rows.Count - 1
                                        POSTAMT = (amount * Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAXPER"))) / 100


                                        If UCase(gShortname) <> "CCL" Then

                                            sqlstring = "select * from TaxAccountstagging where TaxCode='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "' AND ISNULL(VOID,'N')<>'Y'"
                                            gconnection.getDataSet(sqlstring, "TaxAccountstagging")

                                            If (gdataset.Tables("TaxAccountstagging").Rows.Count > 0) Then

                                                accode = gdataset.Tables("TaxAccountstagging").Rows(0).Item("GLACCOUNTCODE")
                                                acdesc = gdataset.Tables("TaxAccountstagging").Rows(0).Item("GLACCOUNTDESC")
                                                slcode = gdataset.Tables("TaxAccountstagging").Rows(0).Item("slcode")
                                                sldesc = gdataset.Tables("TaxAccountstagging").Rows(0).Item("sldesc")
                                                costcode = ""
                                                costdesc = ""
                                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                                sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                                sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                                sqlstring = sqlstring & "'" & acdesc & "',"
                                                sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                                sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                                sqlstring = sqlstring & "'DEBIT',"
                                                'amt = Format(Val(txt_totaltax.Text), "0.000")
                                                decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                                sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                                slcode = txt_Storecode.Text
                                                sqlstring = sqlstring & "'N')"
                                                ReDim Preserve GrnQuery(GrnQuery.Length)
                                                GrnQuery(GrnQuery.Length - 1) = sqlstring

                                            Else
                                                MessageBox.Show("NO GL A/C FOUND FOR " + Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) + " TAXCODE")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            sqlstring = "Select * from accountstaxmaster where TAXCODE='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "'"
                                            gconnection.getDataSet(sqlstring, "CODE")

                                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                                accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                                acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                                                'slcode = gdataset.Tables("CODE").Rows(0).Item("subledgercode")
                                                'sldesc = gdataset.Tables("CODE").Rows(0).Item("subledgerdesc")
                                                'costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                                'costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                                slcode = "" : sldesc = "" : costcode = "" : costdesc = ""
                                                If accode = "" Then

                                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                    check = False
                                                    Exit Sub
                                                End If

                                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                                sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                                sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                                sqlstring = sqlstring & "'" & acdesc & "',"
                                                sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                                sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                                sqlstring = sqlstring & "'DEBIT',"
                                                'amt = Format(Val(txt_totaltax.Text), "0.000")
                                                decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                                sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                                slcode = txt_Storecode.Text
                                                sqlstring = sqlstring & "'N')"
                                                ReDim Preserve GrnQuery(GrnQuery.Length)
                                                GrnQuery(GrnQuery.Length - 1) = sqlstring
                                            Else
                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                check = False
                                                Exit Sub
                                            End If
                                        End If


                                    Next Z
                                Else
                                    MessageBox.Show("TAX GROUP NOT FOUND")
                                    check = False
                                    Exit Sub
                                End If
                            End If
                        End If

                    End If
                Next
                'End If
            End If
        End If

        check = True
        'gconnection.MoreTrans1(INSERT)
    End Sub



    Private Function accountPostingValidation() As Boolean
        Dim flag As Boolean
        Dim sqlstring As String
        Dim INSERT(0) As String



        '========================= POSTING FOR SPONSOR CREDIT===========================================

        If Trim(CmbGrnType.SelectedItem) = "SPONSOR" And CmbGrnType.Visible = True Then
            sqlstring = "Select * from SponsorAccountstagging where code='" & TXT_Sponsor.Text & "' AND  isnull(VOID,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "CODE")
            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                If accode = "" Then

                    MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING...")
                    check = False
                    Exit Function

                End If
                If accode <> "" And costcode = "" Then

                    MessageBox.Show("NO COST CENTRE CODE FOR SPON. POSTING...")
                    check = False
                    Exit Function

                End If

                'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                'sqlstring = sqlstring & "'" & acdesc & "',"
                'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                'sqlstring = sqlstring & "'CREDIT',"
                'amt = Format(Val(txt_Billamount.Text), "0.000")
                'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                'slcode = txt_Storecode.Text
                'sqlstring = sqlstring & "'N')"
                'ReDim Preserve INSERT(INSERT.Length)
                'INSERT(INSERT.Length - 1) = sqlstring
            Else
                MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING. : '" & TXT_Sponsor.Text & "'")
                check = False
                Exit Function
            End If




            sqlstring = "Select * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "CODE")
            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                If accode = "" Then

                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                    check = False
                    Exit Function


                End If
                'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                'sqlstring = sqlstring & "'" & acdesc & "',"
                'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                'sqlstring = sqlstring & "'DEBIT',"

                'amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                ''slcode = txt_Storecode.Text
                'sqlstring = sqlstring & "'N')"
                'ReDim Preserve INSERT(INSERT.Length)
                'INSERT(INSERT.Length - 1) = sqlstring
                If Val(txt_totaltax.Text) <> 0 Then
                    sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("TAXGLCODE")
                        acdesc = gdataset.Tables("CODE").Rows(0).Item("TAXGLDESC")
                        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                        If accode = "" Then
                            MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                            check = False
                            Exit Function
                        End If

                        'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                        'sqlstring = sqlstring & "'" & acdesc & "',"
                        'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        'sqlstring = sqlstring & "'DEBIT',"
                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                        'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        'sqlstring = sqlstring & "'N')"
                        'ReDim Preserve INSERT(INSERT.Length)
                        'INSERT(INSERT.Length - 1) = sqlstring
                    Else
                        MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                        check = False
                        Exit Function
                    End If
                End If

            Else
                MessageBox.Show("CREATE SLCODE FOR STORE IN ACCOUNTSSUBLEDGERMASTER...")
                check = False
                Exit Function
            End If
        Else
            '====================== POSTING FOR SUPPLIER (CREDIT)==========================
            sqlstring = "select slcode, sldesc,ACCODE,ACDESC from accountssubledgermaster  WHERE "
            sqlstring = sqlstring & "SLCODE='" & txt_Suppliercode.Text & "' AND  isnull(freezeflag,'')<>'Y'  and accode in( select ScrsCode from ACCOUNTSSETUP)"
            gconnection.getDataSet(sqlstring, "SLCODE1")

            If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                accode = gdataset.Tables("SLCODE1").Rows(0).Item("ACCODE")
                slcode = gdataset.Tables("SLCODE1").Rows(0).Item("SLCODE")
                sldesc = gdataset.Tables("SLCODE1").Rows(0).Item("SLDESC")
                acdesc = gdataset.Tables("SLCODE1").Rows(0).Item("ACDESC")
            Else
                MessageBox.Show("CREATE SLCODE FOR SUPPLIER IN ACCOUNTSSUBLEDGERMASTER...")
                check = False
                Exit Function
            End If
            'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID)"
            'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
            'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
            'sqlstring = sqlstring & "'" & acdesc & "',"
            'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
            '' sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
            'sqlstring = sqlstring & "'CREDIT',"
            'amt = Format(Val(txt_Billamount.Text), "0.000")
            'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
            'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

            'slcode = txt_Storecode.Text
            'sqlstring = sqlstring & "'N')"
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = sqlstring



            sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "CODE")
            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                If accode = "" Then
                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING")
                    check = False
                    Exit Function
                End If
                'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                'sqlstring = sqlstring & "'" & acdesc & "',"
                'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                'sqlstring = sqlstring & "'DEBIT',"

                'amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                ''slcode = txt_Storecode.Text
                'sqlstring = sqlstring & "'N')"
                'ReDim Preserve INSERT(INSERT.Length)
                'INSERT(INSERT.Length - 1) = sqlstring
                If Val(txt_totaltax.Text) <> 0 Then
                    sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("TAXGLCODE")
                        acdesc = gdataset.Tables("CODE").Rows(0).Item("TAXGLDESC")
                        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                        If accode = "" Then
                            MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                            check = False
                            Exit Function
                        End If

                        'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                        'sqlstring = sqlstring & "'" & acdesc & "',"
                        'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        'sqlstring = sqlstring & "'DEBIT',"
                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                        'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        'sqlstring = sqlstring & "'N')"
                        'ReDim Preserve INSERT(INSERT.Length)
                        'INSERT(INSERT.Length - 1) = sqlstring
                    Else
                        MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                        check = False
                        Exit Function
                    End If
                End If

            End If

        End If






        gconnection.MoreTrans1(INSERT)
    End Function
    Private Sub autogenerateissue()
        Try
            If txt_Storecode.Text <> "" Then
                Dim sqlstring, financalyear As String
                gcommand = New SqlCommand
                financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
                Dim docno As String
                docno = Mid(txt_Storecode.Text, 1, 3)
                'sqlstring = "SELECT MAX(SUBSTRING(docno,1,5)) FROM stockissueheader WHERE doctype='ISSUE'"
                sqlstring = "SELECT MAX(SUBSTRING(docno,1,5)) FROM stockissueheader WHERE SUBSTRING(docDETAILS,1,3)='" & docno & "'"
                gconnection.openConnection()
                gcommand.CommandText = sqlstring
                gcommand.CommandType = CommandType.Text
                gcommand.Connection = gconnection.Myconn
                gdreader = gcommand.ExecuteReader
                ' docno = "ISSUE"

                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        issuedocno = docno & "/00001/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        issuedocno = docno & "/" & Format(gdreader(0) + 1, "00000") & "/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    issuedocno = docno & "/00001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Addissueoperation()
        Dim docno1() As String
        Dim docno2() As String
        'Dim insert(0) As String
        Dim sqlstring As String
        Dim itemcode As String
        Dim financalyear As String
        Dim docno As String
        docno = Mid(txt_Storecode.Text, 1, 3)
        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
        check = False

        Dim i As Integer
        If Mid(Cmd_Add.Text, 1, 1) = "U" Then
            autogenerateissue()
            sqlstring = " Select distinct(E.storecode) as storecode,storedesc  from " + TABNAME + " E inner join storemaster "
            sqlstring = sqlstring & "   on storemaster.Storecode=E.storecode"
            gconnection.getDataSet(sqlstring, "directissueing")
            If (gdataset.Tables("directissueing").Rows.Count > 0) Then
                docno1 = Split(Trim(issuedocno), "/")
                For m As Integer = 0 To gdataset.Tables("directissueing").Rows.Count - 1

                    issuedocno = docno & "/" & Format(Val(docno1(1)) + m, "00000") & "/" & financalyear
                    docno2 = Split(Trim(issuedocno), "/")
                    sqlstring = "INSERT INTO STOCKISSUEHEADER(Docno,Docdetails,Doctype,Docdate,IndentNo,Storelocationcode,Storelocationname, "
                    sqlstring = sqlstring & " Opstorelocationcode, Opstorelocationname, Remarks,Void,VoidReason,Adduser,Adddate,Updateuser,Updatetime)"
                    sqlstring = sqlstring & " VALUES ('" & CStr(docno2(1)) & "','" & Trim(issuedocno) & "','ISSUE',"
                    'sqlstring = sqlstring & " VALUES ('" & Trim(txt_Docno.Text) & "','" & Trim(txt_Docno.Text) & "','" & Trim(docno) & "',"
                    sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd-MMM-yyyy") & "','',"
                    sqlstring = sqlstring & " '" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "','" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storecode")) & "', "
                    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storedesc")) & "' ,"
                    sqlstring = sqlstring & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,'N','" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "',"
                    sqlstring = sqlstring & " '" & Trim(gUsername) & "',GETDATE(),"
                    sqlstring = sqlstring & " '',GETDATE()"
                    sqlstring = sqlstring & " )"

                    ReDim Preserve GrnQuery(GrnQuery.Length)
                    GrnQuery(GrnQuery.Length - 1) = sqlstring


                    sqlstring = " select itemcode,itemname,uom,sum(quantity) as quantity,Storecode from  " + TABNAME + " "
                    sqlstring = sqlstring & "   where storecode='" + gdataset.Tables("directissueing").Rows(m).Item("Storecode") + "' group by itemcode,itemname,uom,Storecode  "
                    gconnection.getDataSet(sqlstring, "StoreMaster")
                    If (gdataset.Tables("StoreMaster").Rows.Count > 0) Then
                        Dim rate As Double
                        '  issuedocno = docno & "/00001/" & financalyear
                        'Dim Seq As Double = gconnection.getInvSeq()
                        For l As Integer = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
                            Dim sql As String = "select * from closingqty where Itemcode='" + gdataset.Tables("StoreMaster").Rows(l).Item("itemcode") + "' and trnno='" + txt_Grnno.Text + "'"
                            gconnection.getDataSet(sql, "closingqty")
                            If (gdataset.Tables("closingqty").Rows.Count > 0) Then

                                rate = Format(Val(gdataset.Tables("closingqty").Rows(0).Item("rate")), "0.000")

                               
                            Else
                                AxfpSpread1.Col = 4
                                Dim q As Double = Val(AxfpSpread1.Text)
                                AxfpSpread1.Col = 9
                                rate = Val(AxfpSpread1.Text) / q
                            End If

                            sqlstring = "INSERT INTO STOCKISSUEDETAIL(Docno,Docdetails,Docdate,IndentNo,Storelocationcode,Storelocationname,"
                            sqlstring = sqlstring & " Opstorelocationcode,Opstorelocationname,Itemcode,Itemname,Uom,IND_QTY,Qty,batchno,rate,amount,"
                            sqlstring = sqlstring & " Void,Adduser,adddatetime,Updateuser,Updatetime)"
                            sqlstring = sqlstring & " VALUES ('" & Trim(issuedocno) & "','" & Trim(issuedocno) & "',"
                            sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd-MMM-yyyy") & "',"
                            sqlstring = sqlstring & " '',"
                            sqlstring = sqlstring & " '" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "', "
                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storecode")) & "','" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storedesc")) & "',"
                            'AxfpSpread1.Row = i
                            'AxfpSpread1.Col = 1
                            itemcode = gdataset.Tables("StoreMaster").Rows(l).Item("itemcode")
                            sqlstring = sqlstring & "'" & Trim(itemcode) & "',"
                            sqlstring = sqlstring & "'" & Trim(gdataset.Tables("StoreMaster").Rows(l).Item("itemname")) & "',"
                            sqlstring = sqlstring & "'" & Trim(gdataset.Tables("StoreMaster").Rows(l).Item("uom")) & "',"
                            sqlstring = sqlstring & "" & Format(Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")), "0.000") & ","

                            Dim qty As Double = Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))
                            sqlstring = sqlstring & "" & Format(Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")), "0.000") & ","


                            sqlstring = sqlstring & "'" & txt_Grnno.Text & "',"
                            sqlstring = sqlstring & "'" + Format(Val(rate), "0.000") + "',"
                            sqlstring = sqlstring & "'" + Format(Val(rate * Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))), "0.000") + "',"
                            sqlstring = sqlstring & "'N',"
                            sqlstring = sqlstring & " '" & Trim(gUsername) & "',GETDATE(),"
                            sqlstring = sqlstring & " ' ',GETDATE())"
                            ReDim Preserve GrnQuery(GrnQuery.Length)
                            GrnQuery(GrnQuery.Length - 1) = sqlstring





                            If (GACCPOST.ToUpper() = "Y") Then


                                Dim TOTALISSUEQTY As Decimal
                                sqlstring = " select sum(Quantity) AS Quantity FROM " + TABNAME + " "
                                gconnection.getDataSet(sqlstring, "TOTALISSUEQTY")
                                If (gdataset.Tables("TOTALISSUEQTY").Rows.Count > 0) Then
                                    TOTALISSUEQTY = gdataset.Tables("TOTALISSUEQTY").Rows(0).Item("Quantity")
                                End If



                                sqlstring = "Select  * from AccountstaggingNEW where code='" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storecode")) & "' AND ISNULL(VOID,'')<>'Y'"
                                gconnection.getDataSet(sqlstring, "CODE")
                                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                    If accode = "" Then

                                        MessageBox.Show("NO GL FOUND FOR '" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storecode")) & "'  STOCK  POSTING...")
                                        check = False
                                        Exit Sub


                                    End If
                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                    sqlstring = sqlstring & " VALUES('" & Trim(issuedocno) & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'ISSUE', '" & accode & "',"
                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'DEBIT',"


                                    'Dim qty As Double = Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))
                                    If Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then
                                        'amt = Format((Val((txt_Billamount.Text)) / TOTALISSUEQTY) * qty, "0.000")
                                        amt = Format(rate * qty, "0.000")
                                    Else
                                        'amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text)) / TOTALISSUEQTY) * qty, "0.000")
                                        amt = Format(rate * qty, "0.000")
                                    End If

                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N')"
                                    ReDim Preserve GrnQuery(GrnQuery.Length)
                                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                                Else
                                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...:-'" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storecode")) & "'")
                                    Exit Sub
                                End If


                                sqlstring = "Select  * from AccountstaggingNew where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                                gconnection.getDataSet(sqlstring, "CODE")
                                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                    If accode = "" Then

                                        MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                                        check = False
                                        Exit Sub


                                    End If
                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                    sqlstring = sqlstring & " VALUES('" & Trim(issuedocno) & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'ISSUE', '" & accode & "',"
                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'CREDIT',"

                                    If Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then
                                        ' amt = Format(Val((txt_Billamount.Text)), "0.000")
                                        amt = Format(rate * qty, "0.000")
                                    Else
                                        amt = Format(rate * qty, "0.000")
                                        ' amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text))), "0.000")
                                    End If
                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N')"
                                    ReDim Preserve GrnQuery(GrnQuery.Length)
                                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                                Else
                                    MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR StoreCode:-'" & txt_Storecode.Text & "'")
                                    Exit Sub
                                End If



                            End If
                        Next


                    End If




                Next


            End If
            sqlstring = "if exists(select * from sysobjects where name='" & TABNAME & "') begin DROP TABLE " & TABNAME & " end"
            gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "delete from directissueing"
            'ReDim Preserve GrnQuery(GrnQuery.Length)
            'GrnQuery(GrnQuery.Length - 1) = sqlstring
            ' gconnection.MoreTrans1(GrnQuery)
        End If
        check = True

    End Sub

    Private Sub voidoperation()
        Dim INSERT(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim lastweightedrate As Double
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        GRNno = Split(Trim(txt_Grnno.Text), "/")
        Dim seq As Double




        sqlstring = "Update  Grn_header set "
        sqlstring = sqlstring & " Void='Y',voiduser='" & Trim(gUsername) & "',"
        sqlstring = sqlstring & " voiddate=GETDATE()"
        sqlstring = sqlstring & "  where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        INSERT(0) = sqlstring

        sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring

        sqlstring = "Update  stockissuedetail set  void='Y' where batchno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring

        sqlstring = "Update  STOCKISSUEHEADER set  void='Y' where Docdetails in (select Docdetails from stockissuedetail  where batchno='" + Trim(txt_Grnno.Text) + "' )"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring


        If (GACCPOST.ToUpper() = "Y") Then

            sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
            sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo IN (SELECT DOCDETAILS FROM STOCKISSUEDETAIL WHERE BATCHNO='" + Trim(txt_Grnno.Text) + "') AND VOUCHERTYPE='ISSUE'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

        End If

        If Trim(CmbGrnType.SelectedItem) = "PO" Then
            sqlstring = "Update po_itemdetails set receivedqty=receivedqty-qty,QTYstatus='' from PO_ITEMDETAILS inner join Grn_details"
            sqlstring = sqlstring & "    on PO_ITEMDETAILS.ITEMCODE=Grn_details.Itemcode and PO_ITEMDETAILS.pono=Grn_details.pono and PO_ITEMDETAILS.versionno=Grn_details.versionno "
            sqlstring = sqlstring & " where Grn_details.pono='" + Txt_PONo.Text + "' and Grn_details.versionno='" + versionno + "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            sqlstring = "update po_hdr set postatus='RELEASED' where pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

        End If
        sqlstring = "update ratelist  set void='Y' where   grnno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring

        gconnection.MoreTrans(INSERT)




    End Sub


    Private Sub cancelAdd()
        Dim GrnQuery(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim lastweightedrate As Double
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        GRNno = Split(Trim(txt_Grnno.Text), "/")

        sqlstring = " delete from Grn_header where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"

        'sqlstring = "Update  Grn_header set "
        'sqlstring = sqlstring & " void='Y'"
        'sqlstring = sqlstring & "  where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   Grn_details  where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ' sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   closingqty  where trnno='" + Trim(txt_Grnno.Text) + "'"
        ' sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        If (GACCPOST.ToUpper() = "Y") Then
            '    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring
            sqlstring = "delete from  JOURNALENTRY where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ' sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

        End If

        sqlstring = "delete from  ratelist where   grnno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        gconnection.MoreTrans1(GrnQuery)

    End Sub
    Private Sub cancelUpdate()
        Dim GrnQuery(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim lastweightedrate As Double
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        GRNno = Split(Trim(txt_Grnno.Text), "/")

        sqlstring = " delete from Grn_header where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   Grn_details  where Grndetails='" + Trim(txt_Grnno.Text) + "'"


        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   closingqty  where trnno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring

        If (GACCPOST.ToUpper() = "Y") Then
            sqlstring = "delete from  JOURNALENTRY where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

        End If

        sqlstring = "delete from  ratelist where   grnno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        gconnection.MoreTrans1(GrnQuery)

        sqlstring = "INSERT INTO GRN_HEADER(category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
        sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno)"
        sqlstring = sqlstring & " SELECT category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
        sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno"
        sqlstring = sqlstring & " FROM GRN_HEADERlog WHERE Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring

        sqlstring = "iNSERT INTO GRN_DETAILS(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
        sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FQUOM,oldqty,trns_seq)"
        sqlstring = sqlstring & " SELECT Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
        sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FQUOM,oldqty,trns_seq"
        sqlstring = sqlstring & "  FROM Grn_detailslog where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring

    End Sub



    Private Sub voidoperationupdate()
        Dim INSERT(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim lastweightedrate As Double
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        GRNno = Split(Trim(txt_Grnno.Text), "/")

        sqlstring = " delete from Grn_header where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"

        'sqlstring = "Update  Grn_header set "
        'sqlstring = sqlstring & " void='Y'"
        'sqlstring = sqlstring & "  where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   Grn_details  where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ' sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   closingqty  where trnno='" + Trim(txt_Grnno.Text) + "'"
        ' sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        If (GACCPOST.ToUpper() = "Y") Then
            '    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring
            sqlstring = "delete from  JOURNALENTRY where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ' sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

        End If

        If Trim(CmbGrnType.SelectedItem) = "PO" Then
            sqlstring = "Update po_itemdetails set receivedqty=receivedqty-qty,QTYstatus='' from PO_ITEMDETAILS inner join Grn_details"
            sqlstring = sqlstring & "    on PO_ITEMDETAILS.ITEMCODE=Grn_details.Itemcode and PO_ITEMDETAILS.pono=Grn_details.pono and PO_ITEMDETAILS.versionno=Grn_details.versionno "
            sqlstring = sqlstring & " where Grn_details.pono='" + Txt_PONo.Text + "' and Grn_details.versionno='" + versionno + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring
            sqlstring = "update po_hdr set postatus='RELEASED' where pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring
        End If
        sqlstring = "delete from  ratelist where   grnno='" + Trim(txt_Grnno.Text) + "'"

        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring

        'gconnection.MoreTrans1(INSERT)
    End Sub

    Private Sub UpdateOperation()
        If nonstockable.Rows.Count > 0 Then
            Call Addissueoperation()
        End If

    End Sub

    Private Sub AxfpSpread1_ComboSelChange(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_ComboSelChangeEvent) Handles AxfpSpread1.ComboSelChange
        Dim i As Integer = AxfpSpread1.ActiveRow

        If AxfpSpread1.ActiveCol = 3 Then
            If Trim(AxfpSpread1.Text) <> "" Then

                Dim uomstr As String
                AxfpSpread1.GetText(3, i, uomstr)
                AxfpSpread1.SetText(18, i, uomstr)

            End If
        End If



    End Sub
    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String
        Dim message, title, defaultValue, Ic As String
        Dim myValue As Object

        message = "Enter Batch No"
        title = "Batch No"

        defaultValue = txt_Grnno.Text

        If e.keyCode = Keys.Enter Then
            i = AxfpSpread1.ActiveRow
            'ITEMCODE
            AxfpSpread1.Row = i

            If AxfpSpread1.ActiveCol = 1 And AxfpSpread1.Lock = False Then
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemcode()
                Else
                    CATCODE = Split(CMB_CATEGORY.Text, "--->")

                    SQL = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "'"
                    gconnection.getDataSet(SQL, "Invitem_VendorMaster")


                    SQL = " select I.itemcode,Itemname,uom,batchprocess from  CLOSINGQTY  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode "
                    If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then

                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "' and I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')" ' and itemcode not in (select itemcode from trnsView where storecode<>'" + txt_Storecode.Text + "' and ttype='GRN'))"

                    Else

                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'" ' and I.itemcode IN (select itemcode from trnsView where storecode<>'" + txt_Storecode.Text + "' and ttype='GRN') "

                    End If

                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then

                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))

                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            Dim sql1 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))

                                AxfpSpread1.Col = 18
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Col = 3
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            Next Z
                            AxfpSpread1.Col = 1
                            SQL = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and ITEMCODE='" + Trim(AxfpSpread1.Text) + "' and isnull(contractyn,0)='1'"
                            gconnection.getDataSet(SQL, "Invitem_VendorMaster")
                            If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                                AxfpSpread1.Col = 3
                                AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                                AxfpSpread1.Col = 5
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("rate")
                                If AxfpSpread1.Text = "0.00" Then
                                    AxfpSpread1.Lock = False
                                Else
                                    AxfpSpread1.Lock = True
                                End If
                            End If
                            If CATCODE(0) = "LIQ" Then
                                SQL = "SELECT TOP 1   rate as rate  FROM LiqRate  WHERE ITEMCODE='" + Trim(AxfpSpread1.Text) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and   cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY TRNS_SEQ  DESC"
                                gconnection.getDataSet(SQL, "RATE")
                                If (gdataset.Tables("RATE").Rows.Count > 0) Then

                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    AxfpSpread1.Lock = False
                                Else
                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    'AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    AxfpSpread1.Lock = False
                                End If
                            End If
                            '    AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES" Then
                                myValue = InputBox(message, title, defaultValue)
                                If myValue = "" Then myValue = defaultValue
                                AxfpSpread1.Col = 14
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = myValue

                            Else
                                AxfpSpread1.Col = 14
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = defaultValue
                            End If

                            If UCase(gShortname) <> "CCL" Then
                                SQL = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                                SQL = SQL & " AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                                gconnection.getDataSet(SQL, "Itemtaxtagging")

                                'SQL = "select TAXCODE, taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                                'gconnection.getDataSet(SQL, "Itemtaxtagging")
                                If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                                    AxfpSpread1.Col = 10
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                                    AxfpSpread1.Col = 11
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxper")
                                Else
                                    MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                End If
                            End If

                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                        End If
                    End If
                End If
                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 2 And AxfpSpread1.Lock = False Then
                AxfpSpread1.Col = 2
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemname()
                Else
                    CATCODE = Split(CMB_CATEGORY.Text, "--->")

                    SQL = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "'"
                    gconnection.getDataSet(SQL, "Invitem_VendorMaster")


                    SQL = " select I.itemcode,Itemname,uom,batchprocess from  CLOSINGQTY  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  "
                    If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then

                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(itemname,'')='" + Trim(AxfpSpread1.Text) + "' and I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')"

                    Else
                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(itemname,'')='" + Trim(AxfpSpread1.Text) + "'"

                    End If

                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then

                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))

                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            Dim sql1 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))

                                AxfpSpread1.Col = 18
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Col = 3
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            Next Z
                            AxfpSpread1.Col = 1
                            SQL = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and ITEMCODE='" + Trim(AxfpSpread1.Text) + "' and isnull(contractyn,0)='1'"
                            gconnection.getDataSet(SQL, "Invitem_VendorMaster")
                            If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                                AxfpSpread1.Col = 3
                                AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                                AxfpSpread1.Col = 5
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("rate")
                                If AxfpSpread1.Text = "0.00" Then
                                    AxfpSpread1.Lock = False
                                Else
                                    AxfpSpread1.Lock = True
                                End If
                            End If
                            If CATCODE(0) = "LIQ" Then
                                SQL = "SELECT TOP 1   rate as rate  FROM LiqRate  WHERE ITEMCODE='" + Trim(AxfpSpread1.Text) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and   cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY TRNS_SEQ  DESC"
                                gconnection.getDataSet(SQL, "RATE")
                                If (gdataset.Tables("RATE").Rows.Count > 0) Then

                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    AxfpSpread1.Lock = False
                                Else
                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    'AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    AxfpSpread1.Lock = False
                                End If
                            End If
                            '    AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES" Then
                                myValue = InputBox(message, title, defaultValue)
                                If myValue = "" Then myValue = defaultValue
                                AxfpSpread1.Col = 14
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = myValue

                            Else
                                AxfpSpread1.Col = 14
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = defaultValue
                            End If

                            If UCase(gShortname) <> "CCL" Then



                                SQL = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                                SQL = SQL & " AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                                gconnection.getDataSet(SQL, "Itemtaxtagging")
                                If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                                    AxfpSpread1.Col = 10
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                                    AxfpSpread1.Col = 11
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxper")
                                Else
                                    MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                End If
                            End If
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                        End If
                    End If
                End If
                'QTY


            ElseIf AxfpSpread1.ActiveCol = 4 Then
                AxfpSpread1.Col = 4
                If Trim(AxfpSpread1.Text) = "0.000" Or Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)

                Else
                    AxfpSpread1.Col = 1
                    SQL = "Select isnull(quantity,0) as quantity,isnull(receivedqty,0) as receivedqty,isnull(qtyrange,'') as qtyrange,isnull(potype,'') as potype  from po_itemdetails inner join po_hdr on po_hdr.pono=po_itemdetails.pono and po_hdr.versionno=po_itemdetails.versionno where po_hdr.pono='" + Txt_PONo.Text + "' and po_hdr.versionno='" + versionno + "'and itemcode='" + AxfpSpread1.Text + "'"
                    gconnection.getDataSet(SQL, "po_itemdetails")
                    If (gdataset.Tables("po_itemdetails").Rows.Count > 0) Then
                        Dim qtyrange As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("qtyrange"))
                        Dim qty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("quantity"))
                        Dim receivedqty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("receivedqty"))
                        If (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "FIXED RATE FIXED QUANTITY" Or gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "OPEN RATE FIXED QUANTITY") Then

                            AxfpSpread1.Col = 4
                            Dim quant As Double = Val(AxfpSpread1.Text)
                            If ((qty + qtyrange) - receivedqty < quant) Then
                                MessageBox.Show("Quantity Cannot be Greater than PO Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                                AxfpSpread1.Text = Val(qty)
                            Else
                                CALCULATE()

                                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                            End If
                        ElseIf (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "RATE IN RANGE QUANTITY IN RANGE") Then
                            AxfpSpread1.Col = 4
                            Dim quant As Double = Val(AxfpSpread1.Text)
                            If ((qty + qtyrange) - receivedqty < quant) Then
                                MessageBox.Show("Quantity Cannot be Greater than PO Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                AxfpSpread1.Text = ""
                                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                            Else
                                CALCULATE()

                                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                            End If


                        Else

                            CALCULATE()

                            AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                        End If
                    Else
                        CALCULATE()

                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                    End If
                End If
                'RATE
            ElseIf AxfpSpread1.ActiveCol = 5 Then
                AxfpSpread1.Col = 5
                If Trim(AxfpSpread1.Text) = "0.00" Or Trim(AxfpSpread1.Text) = "" Or Val(AxfpSpread1.Text) <= 0 Then
                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.Col = 1
                    SQL = "Select isnull(rate,0) as rate,isnull(raterange,'') as raterange ,POTYPE from po_itemdetails INNER JOIN PO_HDR ON PO_HDR.pono=po_itemdetails.PONO AND "
                    SQL = SQL & " PO_HDR.VERSIONNO=PO_ITEMDETAILS.VERSIONNO where PO_HDR.pono='" + Txt_PONo.Text + "' and po_itemdetails.itemcode='" + AxfpSpread1.Text + "' AND po_itemdetails.VERSIONNO='" + versionno + "'"
                    gconnection.getDataSet(SQL, "po_itemdetails")
                    If (gdataset.Tables("po_itemdetails").Rows.Count > 0) Then
                        Dim rate As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("rate"))
                        Dim raterange As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("raterange"))
                        AxfpSpread1.Col = 5
                        Dim rt As Double = Val(AxfpSpread1.Text)
                        If (gdataset.Tables("po_itemdetails").Rows(0).Item("POTYPE") = "RATE IN RANGE QUANTITY IN RANGE") Then

                            If ((rate - raterange) <= rt And (rate + raterange) >= rt) Then
                                CALCULATE()

                                AxfpSpread1.SetActiveCell(7, AxfpSpread1.ActiveRow)

                            Else
                                MessageBox.Show("Rate Should be in range :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                            End If
                        Else
                            CALCULATE()

                            AxfpSpread1.SetActiveCell(7, AxfpSpread1.ActiveRow)
                        End If

                    Else
                        CALCULATE()

                        AxfpSpread1.SetActiveCell(7, AxfpSpread1.ActiveRow)

                    End If
                End If
                'DISC%
                'ElseIf AxfpSpread1.ActiveCol = 7 And AxfpSpread1.Lock = False Then

            ElseIf AxfpSpread1.ActiveCol = 7 Then
                AxfpSpread1.Col = 7
                If Trim(AxfpSpread1.Text) = "0.00" Or Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(8, AxfpSpread1.ActiveRow)
                Else
                    If Val(AxfpSpread1.Text) <= 100 Then
                        CALCULATE()
                        AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.Text = ""
                        AxfpSpread1.SetActiveCell(7, AxfpSpread1.ActiveRow)
                    End If


                End If
            ElseIf AxfpSpread1.ActiveCol = 8 Then
                AxfpSpread1.Col = 8
                If Trim(AxfpSpread1.Text) = "0.00" Or Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.Col = 6
                    Dim a As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 8
                    If a >= Val(AxfpSpread1.Text) Then
                        CALCULATE()
                        AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.Text = ""
                        AxfpSpread1.SetActiveCell(8, AxfpSpread1.ActiveRow)
                    End If


                End If



            ElseIf AxfpSpread1.ActiveCol = 10 Then
                AxfpSpread1.Col = 10

                If Trim(AxfpSpread1.Text) = "" Then
                    bindtaxcode()
                    AxfpSpread1.Col = 17
                    If AxfpSpread1.Lock = True Then
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    Else
                        AxfpSpread1.Col = 10
                        AxfpSpread1.Row = i
                        If Mid(Trim(AxfpSpread1.Text), 1, 2) = "NO" Then
                            AxfpSpread1.SetActiveCell(12, i)
                        Else
                            AxfpSpread1.SetActiveCell(17, i)
                        End If

                    End If
                    ' AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)

                    ' AxfpSpread1.SetActiveCell(1, i + 1)

                Else
                    SQL = "select taxper from invtaxgroupmaster where taxgroupcode='" + AxfpSpread1.Text + "' "
                    Dim taxper As Double = gconnection.getvalue(SQL)

                    AxfpSpread1.Col = 11
                    AxfpSpread1.SetText(11, i, Val(taxper))
                    CALCULATE()
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 10

                    If Mid(Trim(AxfpSpread1.Text), 1, 2) = "NO" Then
                        AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.Col = 17
                        If AxfpSpread1.Lock = True Then
                            ' AxfpSpread1.SetActiveCell(1, i + 1)
                        Else
                            'AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                        End If
                    End If


                End If

                If CmbGrnType.Text = "DIRECT GRN" Then
                    AxfpSpread1.Col = 1
                    SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                    gconnection.getDataSet(SQL, "ITEM")
                    If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                        If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then

                            SQL = " select * from InvCompany_ItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                            gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                            If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then
                                If Val(gdataset.Tables("InvCompany_ItemMaster").Rows.Count) = 1 Then
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(1, i + 1)
                                Else
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(20, i)
                                End If
                            Else
                                AxfpSpread1.Col = 20
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(20, i)
                            End If
                        Else
                            AxfpSpread1.Col = 17
                            If AxfpSpread1.Lock = True Then
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.Col = 10

                                If Mid(Trim(AxfpSpread1.Text), 1, 2) = "NO" Then
                                    AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                                Else
                                    AxfpSpread1.Col = 17
                                    If AxfpSpread1.Lock = True Then
                                        AxfpSpread1.SetActiveCell(1, i + 1)
                                    Else
                                        AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                                    End If
                                End If
                                'AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                            End If
                        End If
                    Else
                        AxfpSpread1.Col = 17
                        If AxfpSpread1.Lock = True Then
                            AxfpSpread1.SetActiveCell(1, i + 1)
                        Else

                            AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                        End If
                    End If
                Else
                    AxfpSpread1.Col = 10

                    If Mid(Trim(AxfpSpread1.Text), 1, 2) = "NO" Then
                        AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.Col = 17
                        If AxfpSpread1.Lock = True Then
                            AxfpSpread1.SetActiveCell(1, i + 1)
                        Else
                            AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                        End If
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 12 Then

                Dim BA, TP, TA As Double
                AxfpSpread1.Col = 9
                BA = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 12
                TA = Val(AxfpSpread1.Text)
                ' TP = Math.Round((TA * 100) / BA)
                If TA = 0 Then
                    AxfpSpread1.SetText(11, i, "0.00")
                    AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                Else
                    TP = (TA * 100) / BA
                    AxfpSpread1.Col = 11
                    AxfpSpread1.SetText(11, i, TP)

                    'AxfpSpread1.SetActiveCell(1, i + 1)
                    CALCULATE()
                    AxfpSpread1.Col = 17
                    If Trim(AxfpSpread1.Text) = "" Then
                        AxfpSpread1.SetText(17, i, "0.00")

                        AxfpSpread1.SetActiveCell(1, i + 1)
                    Else
                        AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                        'AxfpSpread1.SetActiveCell(1, i + 1)

                    End If
                End If

                If CmbGrnType.Text = "DIRECT GRN" Then

                    AxfpSpread1.Col = 1
                    SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                    gconnection.getDataSet(SQL, "ITEM")
                    If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                        If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then

                            SQL = " select * from InvCompany_ItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                            gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                            If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then
                                If Val(gdataset.Tables("InvCompany_ItemMaster").Rows.Count) = 1 Then
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(1, i + 1)
                                Else
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(20, i)
                                End If
                            Else
                                AxfpSpread1.Col = 20
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(20, i)
                            End If
                        Else
                            AxfpSpread1.Col = 17
                            If Trim(AxfpSpread1.Text) = "" Then
                                AxfpSpread1.SetText(17, i, "0.00")
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                            End If
                        End If
                    Else
                        AxfpSpread1.Col = 17
                        If Trim(AxfpSpread1.Text) = "" Then
                            AxfpSpread1.SetText(17, i, "0.00")
                            AxfpSpread1.SetActiveCell(1, i + 1)
                        Else
                            AxfpSpread1.SetActiveCell(18, AxfpSpread1.ActiveRow)
                        End If
                    End If
                Else
                    AxfpSpread1.Col = 17
                    If Trim(AxfpSpread1.Text) = "" Then
                        AxfpSpread1.SetText(17, i, "0.00")
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    Else
                        AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 17 Then
                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetText(17, i, "0.00")
                    If CmbGrnType.Text = "SPONSOR" Then
                        AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    End If
                Else
                    AxfpSpread1.SetActiveCell(18, AxfpSpread1.ActiveRow)
                End If

                If CmbGrnType.Text = "DIRECT GRN" Then

                    AxfpSpread1.Col = 1
                    SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                    gconnection.getDataSet(SQL, "ITEM")
                    If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                        If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then

                            SQL = " select * from InvCompany_ItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                            gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                            If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then
                                If Val(gdataset.Tables("InvCompany_ItemMaster").Rows.Count) = 1 Then
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(1, i + 1)
                                Else
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(20, i)
                                End If
                            Else
                                AxfpSpread1.Col = 20
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(20, i)
                            End If
                        Else
                            If CmbGrnType.Text = "SPONSOR" Then
                                AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                            Else
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            End If
                        End If
                    Else
                        If CmbGrnType.Text = "SPONSOR" Then
                            AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(1, i + 1)
                        End If
                    End If
                Else
                    If CmbGrnType.Text = "SPONSOR" Then
                        AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 18 Then
                If CmbGrnType.Text = "SPONSOR" Then
                    AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                Else

                    AxfpSpread1.SetActiveCell(1, i + 1)

                End If
            ElseIf AxfpSpread1.ActiveCol = 19 Then
                If CmbGrnType.Text = "SPONSOR" Then
                    AxfpSpread1.Col = 19
                    If Trim(AxfpSpread1.Text) = "" Then
                        ' cmd_SPONhelp()
                        gSQLString = "SELECT ISNULL(SPONSORCODE,'') AS SPONSORCODE,ISNULL(SPONSORDESC,'') AS SPONSORDESC FROM INV_SPONSORMASTER"
                        M_WhereCondition = " where ISNULL(freeze,'N') <> 'Y'"
                        Dim vform As New ListOperattion1

                        vform.Field = "SPONSORDESC,SPONSORCODE"
                        vform.vFormatstring = "         SPONSOR CODE              |                  SPONSOR DESCRIPTION                                                                                              "
                        vform.vCaption = "SPONSOR MASTER HELP"
                        vform.KeyPos = 0
                        vform.KeyPos1 = 1
                        vform.ShowDialog(Me)
                        If Trim(vform.keyfield & "") <> "" Then

                            'AxfpSpread1.Text = Trim(vform.keyfield & "")
                            AxfpSpread1.SetText(19, i, Trim(vform.keyfield & ""))
                        End If
                        vform.Close()
                        vform = Nothing
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    Else
                        If Trim(AxfpSpread1.Text) <> "" Then
                            Dim sqlstring As String = "SELECT isnull(SPONSORcode,'') as SPONSORcode,isnull(SPONSORdesc,'') as SPONSORdesc,isnull(freeze,'') as freeze,isnull(adddate,'') as adddate FROM inv_SPONSORmaster WHERE SPONSORcode='" & Trim(AxfpSpread1.Text) & "' AND  ISNULL(freeze,'N') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "inv_SPONSORmaster")
                            If gdataset.Tables("inv_SPONSORmaster").Rows.Count > 0 Then
                                AxfpSpread1.Text = Trim(gdataset.Tables("inv_SPONSORmaster").Rows(0).Item("SPONSORcode"))
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                            End If

                        Else
                            AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)

                        End If
                    End If

                Else

                    AxfpSpread1.SetActiveCell(1, i + 1)

                End If


            ElseIf AxfpSpread1.ActiveCol = 20 Then
                AxfpSpread1.Col = 1
                SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(SQL, "ITEM")
                If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                    If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then
                        AxfpSpread1.Col = 17
                        If Trim(AxfpSpread1.Text) = "" Then
                            Dim vform As New ListOperattion1
                            gSQLString = "select distinct COMPANYCODE,COMPANYDESC from InvCompany_ItemMaster   "
                            AxfpSpread1.Col = 1
                            M_WhereCondition = " where ITEMCODE='" + AxfpSpread1.Text + "' and  isnull(freeze,'')<>'Y'"
                            vform.Field = " COMPANYCODE,COMPANYDESC "
                            vform.vFormatstring = "    COMPANY CODE    |      COMPANY DESC.        "
                            vform.vCaption = "COMPANY MASTER HELP"
                            vform.KeyPos = 0
                            vform.KeyPos1 = 1
                            vform.ShowDialog(Me)
                            If Trim(vform.keyfield & "") <> "" Then
                                AxfpSpread1.Col = 20
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = Trim(vform.keyfield)
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            End If
                        Else
                            Dim ITEM As String
                            AxfpSpread1.Col = 1
                            ITEM = AxfpSpread1.Text
                            AxfpSpread1.Col = 20
                            SQL = " select * from InvCompany_ItemMaster where COMPANYCODE='" + AxfpSpread1.Text + "' AND ITEMCODE='" + ITEM + "' "
                            gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                            If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then


                                AxfpSpread1.Col = 20
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.Col = 20
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = ""
                                AxfpSpread1.SetActiveCell(20, i)
                            End If

                        End If
                    End If
                End If
            Else
                If Mid(UCase(Cmd_Add.Text), 1, 1) = "A" And CmbGrnType.Enabled = True Then
                    GridUnLock()
                Else
                    Grid_lock()
                End If

            End If



        ElseIf e.keyCode = Keys.F1 Then
            txt_Remarks.Focus()
        ElseIf e.keyCode = Keys.F3 Then
            If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then


                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                CALCULATE()
            Else
                i = AxfpSpread1.ActiveRow
                'ITEMCODE
                AxfpSpread1.Row = i
                If AxfpSpread1.Lock = True Then
                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) = "" Then
                        AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                        CALCULATE()
                    End If
                End If
            End If

        End If


    End Sub
    Private Sub bindtaxcode()
        Dim vform As New ListOperattion1


        gSQLString = "select i.taxgroupcode,sum(t.taxper) as Taxper,t.Effectfrom from  invtaxgroupmaster I INNER JOIN invtaxgroupmasterdetail T ON I.taxgroupcode=T.taxgroupcode  "

        M_WhereCondition = "  where isnull(i.void,'')<>'Y'  AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(t.Effectfrom AS DATE) AND  CAST(ISNULL(t.effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) "
        M_Groupby = " GROUP BY i.taxgroupcode,t.Effectfrom "
        vform.Field = " i.Taxgroupcode "
        vform.vFormatstring = "    Taxgroupcode    |      Taxper        "
        vform.vCaption = "Tax MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1


        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then


            AxfpSpread1.Col = 10
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield)
            AxfpSpread1.Col = 11
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield1)
            CALCULATE()
            If Mid(vform.keyfield, 1, 2) = "NO" Then
                AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
            Else
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
            End If

        End If

    End Sub
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub cmd_export_Click(sender As Object, e As EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VW_INV_GRNBILL"
        sqlstring = "select * from VW_INV_GRNBILL  WHERE GRNDETAILS LIKE 'GRN%'"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub

    End Sub

    Private Sub btn_auth_Click(sender As Object, e As EventArgs) Handles btn_auth.Click
        Authocheck("INVENTORY", "GRN Cum Purchase Bill", gUsername, "GRN_DETAILS", "GRNDETAILS", Me)

    End Sub
    Private Sub GridUnLock()
        Try
            Dim i, j As Integer
            For i = 1 To 100
                For j = 1 To 11
                    AxfpSpread1.Col = j
                    AxfpSpread1.Row = i
                    AxfpSpread1.Lock = False
                Next j
            Next i
        Catch ex As Exception
            MessageBox.Show("Plz Check Error :  GridUnLock" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Function Grid_lock()
        Dim i, j As Integer
        For i = 1 To 100
            AxfpSpread1.Row = i
            For j = 1 To AxfpSpread1.MaxCols
                'If j = 4 Or j = 5 Or j = 7 Or j = 8 Or j = 12 Or j = 17 Or j = 18 Then

                'Else
                AxfpSpread1.Col = j
                AxfpSpread1.Lock = True


                ' End If
            Next
        Next
    End Function

    Private Function lock_Frqty()
        Dim i, j As Integer
        For i = 1 To 100
            AxfpSpread1.Row = i
            For j = 1 To AxfpSpread1.MaxCols
                If j = 17 Or j = 18 Then
                    AxfpSpread1.Col = j
                    AxfpSpread1.Lock = True

                End If
            Next
        Next
    End Function

    Private Sub cmd_PONOhelp_Click(sender As Object, e As EventArgs) Handles cmd_PONOhelp.Click
        Dim CATEGORY As String

        CATCODE = Split(CMB_CATEGORY.Text, "--->")

        CATEGORY = Mid(CStr(CMB_CATEGORY.Text), 1, 3)



        clearoperation()


        gSQLString = "SELECT distinct ISNULL(pono,'') AS PONO,ISNULL(podate,'')AS PODATE,ISNULL(podepartment,'') AS PODEPARTMENT FROM ViewPendingPO "
        ' M_WhereCondition = " WHERE FREEZE <> 'Y' AND '" & Trim(CATEGORY) & "' = substring(pono,5,3) and postatus ='RELEASED' AND (GETDATE() BETWEEN POVALIDFROM AND POVALIDUPTO ) "
        'M_WhereCondition = " WHERE FREEZE <> 'Y' AND  postatus ='RELEASED' AND (GETDATE() BETWEEN POVALIDFROM AND POVALIDUPTO and PONO NOT IN (SELECT PONO FROM GRN_HEADER) ) "
        'M_WhereCondition = " WHERE FREEZE <> 'Y' AND  postatus ='RELEASED' AND (GETDATE() BETWEEN POVALIDFROM AND POVALIDUPTO and PONO  IN (SELECT a.PONO from PO_ITEMDETAILS a, Grn_details b where a.pono=b.pono and a.ITEMCODE<>b.Itemcode) ) "
        M_ORDERBY = " order by PONO DESC"
        M_WhereCondition = ""
        Dim vform As New List_Operation
        vform.Field = "PONO,PODATE,PODEPARTMENT"
        vform.vFormatstring1 = "         PONO                        |        PODATE             |        PODEPARTMENT                                   "
        vform.vCaption = "PURCHASE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)

        If Trim(vform.keyfield & "") <> "" Then
            Txt_PONo.Text = Trim(vform.keyfield & "")
            Call Txt_PONo_Validated(Txt_PONo.Text, e)
            Call Grid_lock()



            Call CALCULATE()
            'End IfS
        End If
        vform.Close()
        vform = Nothing
        M_ORDERBY = ""
        'txt_PONo.Focus()
        Cmd_Freeze.Enabled = True

    End Sub

    Private Sub cmd_Grnnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Grnnohelp.Click

        Try
            Dim voidStatus As String



            CATCODE = Split(CMB_CATEGORY.Text, "--->")
            '  CATCODE = Split(Trim(Mid(CMB_CATEGORY.Text, 1, 3)), "--->")
            If Trim(UCase(gShortname)) = "CGC" Then
                voidStatus = " and void ='N'"
            Else
                voidStatus = ""
            End If

            'gSQLString = "SELECT Grndetails,Grndate,SUPPLIERNAME FROM Grn_header"

            'M_WhereCondition = " Where Isnull(GRNTYPE,'')='GRN' " & voidStatus & "  AND ISNULL(GRNDETAILS,'') LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%' "
            'If grp_Grngroup1.Visible = True Then
            '    M_WhereCondition = M_WhereCondition & "AND GRN_TYPE1='" + CmbGrnType.Text + "' and grndetails in (select grndetails from pur_nonstockable a where a.grndetails+a.itemcode not in(select batchno+b.itemcode from iss_nonstockable b) )"
            'End If
            'M_ORDERBY = "  order by Grndate desc "


            gSQLString = "SELECT distinct  Grndetails,Grndate,SUPPLIERNAME from pur_nonstockable  "

            M_WhereCondition = " Where   grndetails+itemcode not in(select batchno+b.itemcode from iss_nonstockable b)"
            If grp_Grngroup1.Visible = True Then
                '' M_WhereCondition = M_WhereCondition & "AND GRN_TYPE1='" + CmbGrnType.Text + "' and grndetails in (select grndetails from pur_nonstockable a where a.grndetails+a.itemcode not in(select batchno+b.itemcode from iss_nonstockable b) )"
            End If
            M_ORDERBY = "  order by Grndate desc "


            Dim vform As New List_Operation
            vform.Field = "GRNDETAILS,GRNDATE,SUPPLIERNAME"
            vform.vFormatstring1 = "       GRN NO                     |              GRN DATE             |                     SUPPLIERNAME                   "
            vform.vCaption = "GRN CUM PURCHASE BILL HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Grnno.Text = Trim(vform.keyfield & "")
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Call txt_Grnno_Validated(txt_Grnno.Text, e)
                Call Grid_lock()
            End If
            vform.Close()
            M_ORDERBY = ""
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_Grnnohelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_PONo_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_PONo.KeyDown

    End Sub

    Private Sub Txt_PONo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_PONo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Txt_PONo.Text = "" Then
                Call cmd_PONOhelp_Click(Txt_PONo, e)
            Else
                Call Txt_PONo_Validated(Txt_PONo, e)
                Call CALCULATE()
            End If
        End If
    End Sub

    Private Sub Txt_PONo_Validated(sender As Object, e As EventArgs) Handles Txt_PONo.Validated
        Dim strsql As String
        Dim totAmt, Discnt, itemRate, itemQty, tempDisc As Double
        Dim sqlstring, financalyear As String
        Dim voucherno As String
        Dim CreditDebit As String
        Dim i, j As Integer
        Dim amount As Double
        Dim accounthead, slhead, costhead As String
        Dim doctype As String
        PoNumber = Nothing
        Me.AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        If Trim(Me.Txt_PONo.Text) <> "" Then
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            If Val(Me.Txt_PONo.Text) > 0 Then
                Me.Txt_PONo.Text = doctype & "/" & Format(Val(Me.Txt_PONo.Text), "000000") & "/" & financalyear
            End If
            PoNumber = Trim(Me.Txt_PONo.Text)
        End If


        If Trim(Txt_PONo.Text) <> "" Then
            Dim x As Integer
            For x = 1 To 100
                AxfpSpread1.ClearRange(18, x, -1, -1, True)
            Next

            strsql = "SELECT * FROM PO_HDR WHERE pono='" & Trim(Txt_PONo.Text) & "'"
            strsql = strsql & " AND FREEZE <> 'Y'  and isnull(postatus,'')='RELEASED' and (getdate() between povalidfrom and povalidupto) and PONO IN (SELECT PONO FROM ViewPendingPO)"
            gconnection.getDataSet(strsql, "PO_HDR")
            If gdataset.Tables("PO_HDR").Rows.Count > 0 Then
                overalldiscountpo = 0
                CmbGrnType.Enabled = False

                Txt_PONo.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PONO"))
                txt_Remarks.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POremarks"))
                'Cbo_PODate.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODATE"))
                '  CMB_CATEGORY.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DOCTYPE"))
                Dim SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("doctype")) + "'"
                gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                    CMB_CATEGORY.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYCODE")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                End If

                versionno = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno"))
                potype = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("potype"))
                strsql = " SELECT * FROM STOREMASTER WHERE STOREcode = '" & Trim(gdataset.Tables("PO_HDR").Rows(0).Item("STORECODE")) & "'"
                gconnection.getDataSet(strsql, "STORECOD")
                If gdataset.Tables("storecod").Rows.Count > 0 Then
                    txt_Storecode.Text = Trim(gdataset.Tables("storecod").Rows(0).Item("storecode"))
                    txt_StoreDesc.Text = Trim(gdataset.Tables("storecod").Rows(0).Item("storedesc"))
                End If
                txt_Supplierinvno.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POquotno"))
                txt_Suppliercode.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("povendorcode"))
                '   Dim TOTDISC As Double = Val(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount"))
                '  Dim OVDISC As Double = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC"))
                txt_totdisc.Text = Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount")), "0.000")
                overalldiscountpo = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC"))

                TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC")), "0.000")
                TXT_OVERALLdiscount.Text = Val(overalldiscountpo)
                '     txt_totdisc.Text = Format(Val(TOTDISC).ToString(), "0.000")
                txt_totaltax.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pototaltax"))
                totpoqty = Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("totqty")))
                strsql = "SELECT ISNULL(VENDORCODE,0) AS VENDORCODE, ISNULL(VENDORNAME,'') AS VENDORNAME FROM PO_VIEW_VENDORMASTER WHERE VENDORCODE = '" & Trim(txt_Suppliercode.Text) & "' "
                gconnection.getDataSet(strsql, "accountssubledgermaster")
                txt_Suppliername.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("vendorname"))
                Txt_PONo.ReadOnly = True
                If gdataset.Tables("PO_HDR").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("PO_HDR").Rows(0).Item("AddDatetime")), "dd/MMM/yyyy")
                    Me.Cmd_Freeze.Text = "UnVoid[F8]"
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                End If
                'Me.Cmd_Add.Text = "Update[F7]"

                '----------------------ITEMDETAILS RETRIEVE----------------------------
                'strsql = "       SELECT A.autoid,A.pono,A.itemcode,A.uom,A.quantity-ISNULL(SUM(ISNULL(B.QTY,0)),0) AS quantity,"
                'strsql = strsql & "requireddate,A.rate,A.discount, vat,total,itemrec_tilldate,value_tilldate,A.amount,"
                'strsql = strsql & "DiscAmt,VatAmt  FROM PO_ITEMDETAILS A  LEFT OUTER  JOIN GRN_DETAILS B "
                'strsql = strsql & "ON A.pono =B.POno AND A.itemcode =B.Itemcode AND A.uom =B.UOM  "
                'strsql = strsql & "WHERE A.pono='" & Trim(Txt_PONo.Text) & "' GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,"
                'strsql = strsql & "requireddate,A.rate,A.discount, vat,total,itemrec_tilldate,value_tilldate,A.amount,"
                'strsql = strsql & "DiscAmt,VatAmt,A.quantity HAVING "
                'strsql = strsql & "A.quantity-ISNULL(SUM(ISNULL(B.QTY,0)),0)>0 ORDER BY A.AUTOID "
                If (potype = "FIXED RATE OPEN QUANTITY" Or potype = "OPEN RATE OPEN QUANTITY") Then
                    strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity  AS quantity,"
                    strsql = strsql & " A.rate,A.discper, a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                    '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                    strsql = strsql & " DiscAmt,VatAmt,a.taxcode ,ISNULL(A.COMPANYCODE,'') AS COMPANYCODE  FROM PO_ITEMDETAILS A"
                    strsql = strsql & " WHERE  A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "'  and  ITEMCODE not in(select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')='N') GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                    strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                    strsql = strsql & ",DiscAmt,VatAmt,A.quantity,A.COMPANYCODE  "
                    strsql = strsql & " ORDER BY A.AUTOID "

                ElseIf (potype = "RATE IN RANGE QUANTITY IN RANGE") Then

                    'strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity-ISNULL(SUM(ISNULL(B.QTY,0)),0) AS quantity,"
                    'strsql = strsql & "A.rate,A.discper, a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                    ''  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                    'strsql = strsql & "DiscAmt,VatAmt,a.taxcode  FROM PO_ITEMDETAILS A  LEFT OUTER  JOIN GRN_DETAILS B "
                    'strsql = strsql & "ON A.pono =B.POno AND A.itemcode =B.Itemcode AND A.uom =B.UOM  and a.versionno=b.versionno "
                    'strsql = strsql & "WHERE A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "' GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                    'strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                    'strsql = strsql & ",DiscAmt,VatAmt,A.quantity,A.QTYRANGE HAVING "
                    'strsql = strsql & "(A.quantity+A.QTYRANGE)-ISNULL(SUM(ISNULL(B.QTY,0)),0)>0 ORDER BY A.AUTOID "

                    strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity AS quantity,"
                    strsql = strsql & "A.rate,A.discper, a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                    '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                    strsql = strsql & "DiscAmt,VatAmt,a.taxcode ,ISNULL(A.COMPANYCODE,'') AS COMPANYCODE  FROM PO_ITEMDETAILS A inner JOIN GRN_DETAILS B "
                    strsql = strsql & "ON A.pono =B.POno and a.versionno=b.versionno "
                    strsql = strsql & "WHERE a.itemcode not in (select ITEMCODE from Grn_details where A.quantity<qty  and isnull(voiditem,'N')='N'  and pono='" & Trim(Txt_PONo.Text) & "') and  A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "' GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                    strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                    strsql = strsql & ",DiscAmt,VatAmt,A.quantity,A.COMPANYCODE    "
                    strsql = strsql & " ORDER BY A.AUTOID "
                Else


                    strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity  AS quantity,"
                    strsql = strsql & " A.rate,A.discper, a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                    '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                    strsql = strsql & " DiscAmt,VatAmt,a.taxcode ,ISNULL(A.COMPANYCODE,'') AS COMPANYCODE FROM PO_ITEMDETAILS A"
                    strsql = strsql & " WHERE  A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "'  and  ITEMCODE not in(select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')='N') GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                    strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                    strsql = strsql & ",DiscAmt,VatAmt,A.quantity ,A.COMPANYCODE  "
                    strsql = strsql & " ORDER BY A.AUTOID "
                End If
                gconnection.getDataSet(strsql, "PO_ITEMDETAILS")



                If gdataset.Tables("PO_ITEMDETAILS").Rows.Count > 0 Then




                    Dim count, temp, tcode As String
                    For i = 0 To gdataset.Tables("PO_ITEMDETAILS").Rows.Count - 1
                        Dim message, title, defaultValue As String
                        Dim myValue As Object
                        message = "Enter Batch No"
                        title = "Batch No"
                        defaultValue = txt_Grnno.Text
                        Dim GRNQTY As Double = 0

                        tcode = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode")


                        strsql = "SELECT isnull(SUM(QTY),0) AS QTY"
                        strsql = strsql & " FROM Grn_details WHERE itemcode='" + tcode + "' and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')<>'Y'"
                        gconnection.getDataSet(strsql, "Grn_details")
                        If gdataset.Tables("Grn_details").Rows.Count > 0 Then
                            GRNQTY = Trim(gdataset.Tables("Grn_details").Rows(0).Item("QTY"))
                        End If

                        'LIN
                        'strsql = "SELECT * FROM inventoryitemmaster "
                        'strsql = strsql & "WHERE itemcode='" & Trim(tcode) & "' "
                        'gconnection.getDataSet(strsql, "inventoryitemmaster")
                        count = gdataset.Tables("PO_ITEMDETAILS").Rows.Count
                        With AxfpSpread1
                            .Row = i + 1
                            .Col = 1
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode")
                            sqlstring = "select batchprocess from   INV_InventoryItemMaster where itemcode='" + gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode") + "'"
                            gconnection.getDataSet(sqlstring, "inv_InventoryOpenningstock")
                            If gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0 Then
                                If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES" Then
                                    myValue = InputBox(message, title, defaultValue)
                                    If myValue = "" Then myValue = defaultValue
                                    AxfpSpread1.Col = 14

                                    AxfpSpread1.Text = myValue

                                Else
                                    AxfpSpread1.Col = 14

                                    AxfpSpread1.Text = defaultValue
                                End If
                            End If
                            .Col = 2
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemname")

                            .Col = 3
                            Dim sql222 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode") + "'"


                            gconnection.getDataSet(sql222, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                AxfpSpread1.Row = i + 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))

                                .Col = 18

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                .Col = 3


                            Next Z






                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("uom")
                            .Col = 4
                            'If ((Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "FIXED RATE FIXED QUANTITY") Or (Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "OPEN RATE FIXED QUANTITY")) Then
                            '    AxfpSpread1.Lock = True
                            'Else
                            '    AxfpSpread1.Lock = False
                            'End If


                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("quantity") - GRNQTY

                            .Col = 5
                            If ((Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "FIXED RATE FIXED QUANTITY") Or (Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "FIXED RATE OPEN QUANTITY")) Then
                                AxfpSpread1.Lock = True
                            Else
                                AxfpSpread1.Lock = False
                            End If
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("rate"), "0.000"))
                            .Col = 6
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("baseamount"), "0.000"))

                            .Col = 7
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("discper"), "0.000"))


                            .Col = 8
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("DiscAmt"), "0.000"))
                            .Col = 9
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("amountafterdiscount"), "0.000"))
                            .Col = 10
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("taxcode")

                            .Col = 11
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("taxper"), "0.000"))

                            .Col = 12
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("VatAmt"), "0.000"))
                            .Col = 13
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("totalamount"), "0.000"))
                            .Col = 15
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("othchg"), "0.000"))
                            .Col = 20
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("COMPANYCODE")
                            '  .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("raterange")

                            '  .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("qtyrange")

                        End With
                    Next
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    CALCULATE()
                    '    txt_totdisc.Text = Format(Val(Discnt), "0.000") ' + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount"))), "0.000")

                    '   TXT_OVERALLdiscount.Text = Format(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTOTALDISCOUNT"))), "0.000")
                    totAmt = Format(Val(txt_total.Text) - Val(txt_totdisc.Text) - Val(TXT_OVERALLdiscount.Text), "0.000")
                    ' txt_total.Text = Format(Val(totAmt), "0.000")
                    Dim OTHER_taxes As Double
                    OTHER_taxes = 0
                    'ed = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POED"))
                    'cst = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POCST"))
                    'MODVAT = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POMODVAT"))
                    'ptax = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POPTAX"))
                    'octra = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOCTRA"))
                    'ins = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POINSURANCE"))
                    'lst = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POLST"))
                    'OTHER_taxes = OTHER_taxes + Math.Round(Val(ed) * totAmt / 100, 2)
                    'OTHER_taxes = OTHER_taxes + Math.Round(Val(cst) * totAmt / 100, 2)
                    'OTHER_taxes = OTHER_taxes + Math.Round(Val(MODVAT) * totAmt / 100, 2)
                    'OTHER_taxes = OTHER_taxes + Math.Round(Val(ptax) * totAmt / 100, 2)
                    'OTHER_taxes = OTHER_taxes + Math.Round(Val(octra) * totAmt / 100, 2)
                    'OTHER_taxes = OTHER_taxes + Math.Round(Val(ins) * totAmt / 100, 2)
                    'OTHER_taxes = OTHER_taxes + Math.Round(Val(lst) * totAmt / 100, 2)
                    'otherchargepo = Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTRANSPORT"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POCF"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODELIVERYAMT"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgplus"))) - Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgmin"))) + Val(OTHER_taxes)
                    otherchargepo = Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTRANSPORT"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POCF"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgplus"))) - Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgmin"))) + Val(OTHER_taxes)

                    txt_Surchargeamt.Text = Format(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTRANSPORT"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POCF"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgplus"))) - Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgmin"))) + Val(OTHER_taxes), "0.000")
                    txt_Billamount.Text = Format((Val(txt_total.Text) + Val(txt_totaltax.Text)) - Val(txt_totdisc.Text) - Val(gdataset.Tables("PO_HDR").Rows(0).Item("POoveralldisc")) + Val(txt_Surchargeamt.Text), "0.000")
                    TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC")), "0.000")
                    Discnt = 0 : totAmt = 0
                Else
                    MsgBox("PO CLOSED")
                End If

            End If
        Else


            txt_Grnno.Focus()
        End If

    End Sub

    Private Sub txt_Storecode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Storecode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txt_Storecode.Text <> "" Then
                txt_Storecode_Validated(sender, e)
            Else
                Cmd_Storecode_Click(sender, e)
            End If

        End If
    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click




        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then

            '            'Call autogenerate()
            '            Array.Clear(GrnQuery, 0, GrnQuery.Length)
            '            If validateoninsert() = False Then
            '                addoperation()
            '                If check = False Then
            '                    Exit Sub
            '                End If

            '                If GrnQuery.Length > 0 Then

            '                    If (gconnection.MoreTrans2(GrnQuery)) Then

            '                        Dim ITEMCODE As String
            '                        Dim I As Integer
            '                        Dim items As String
            '                        items = ""
            '                        For I = 1 To AxfpSpread1.DataRowCnt
            '                            AxfpSpread1.Row = I
            '                            AxfpSpread1.Col = 1
            '                            ITEMCODE = Trim(AxfpSpread1.Text)
            '                            items = items & "'" & Trim(ITEMCODE) & "',"
            '                        Next

            '                        items = Mid(items, 1, Len(items) - 1)
            '                        Call Randomize()
            '                        vOutfile = Mid("WE" & (Rnd() * 800000000), 1, 10)
            '                        vOutfile = Replace(vOutfile, ".", "")
            '                        vOutfile = Replace(vOutfile, "+", "")
            '                        Dim strrate As String
            '                        Dim loccode As String
            '                        sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_Storecode.Text) & "'"
            '                        gconnection.getDataSet(sqlstring, "loccode")
            '                        If gdataset.Tables("loccode").Rows.Count > 0 Then
            '                            loccode = gdataset.Tables("loccode").Rows(0).Item("location")
            '                        Else
            '                            loccode = "M"
            '                        End If
            '                        Try
            '                            strrate = CALC_WEIGHTED(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, Trim(txt_Storecode.Text), "Q", vOutfile, loccode)
            '                        Catch ex As Exception
            '                            MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                            Call cancelAdd()
            '                            Exit Sub
            '                        End Try
            '                        sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
            '                        gconnection.ExcuteStoreProcedure(sqlstring)

            '                        '==============================================
            '                        Array.Clear(GrnQuery, 0, GrnQuery.Length)
            '                        '=============================================
            '                        For I = 1 To AxfpSpread1.DataRowCnt
            '                            AxfpSpread1.Row = I
            '                            AxfpSpread1.Col = 1
            '                            Dim fqqty As Double
            '                            Dim qty1 As Double
            '                            Dim itemcode1 As String
            '                            AxfpSpread1.Col = 1
            '                            itemcode1 = AxfpSpread1.Text

            '                            AxfpSpread1.Col = 4
            '                            qty1 = Format(Val(AxfpSpread1.Text), "0.000")
            '                            'updation in po_itemdetails
            '                            If Trim(CmbGrnType.SelectedItem) = "PO" And grp_Grngroup1.Visible = True Then
            '                                AxfpSpread1.Col = 1
            '                                itemcode1 = AxfpSpread1.Text
            '                                sqlstring = "select isnull(receivedqty,0) as receivedqty ,isnull(qtystatus,'') as qtystatus,isnull(qtyrange,'') as qtyrange,isnull(quantity,0) as quantity,isnull(potype,'') as potype from  po_itemdetails inner join po_hdr on po_hdr.pono=po_itemdetails.pono and po_hdr.versionno=po_itemdetails.versionno where isnull(qtystatus,'') <> 'RECEIVED' and po_itemdetails.pono='" + Txt_PONo.Text + "' and"
            '                                sqlstring = sqlstring & " itemcode='" + AxfpSpread1.Text + "' and po_itemdetails.versionno='" + versionno + "'"
            '                                gconnection.getDataSet(sqlstring, "po_itemdetails")
            '                                If (gdataset.Tables("po_itemdetails").Rows.Count > 0) Then
            '                                    Dim receivedqty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("receivedqty"))
            '                                    Dim quantity As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("quantity"))
            '                                    Dim qtyrange As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("qtyrange"))
            '                                    AxfpSpread1.Col = 4
            '                                    qty1 = Format(Val(AxfpSpread1.Text), "0.000")
            '                                    If ((gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "FIXED RATE FIXED QUANTITY") Or (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "OPEN RATE FIXED QUANTITY")) Then
            '                                        If (qty1 < receivedqty + quantity) Then
            '                                            AxfpSpread1.Col = 1
            '                                            sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            '                                        Else
            '                                            AxfpSpread1.Col = 1

            '                                            sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + ",qtystatus='RECEIVED' where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

            '                                        End If
            '                                    ElseIf (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "RATE IN RANGE QUANTITY IN RANGE") Then
            '                                        If ((quantity - qtyrange) < (receivedqty + qty1) Or (receivedqty + qty1) > (quantity + qtyrange)) Then
            '                                            If (MessageBox.Show("Do You want to Close PO for:" + itemcode1, "Purchase Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
            '                                                GoTo l
            '                                            End If

            '                                            AxfpSpread1.Col = 1
            '                                            sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            '                                        ElseIf (qty1 < receivedqty + quantity) Then
            '                                            AxfpSpread1.Col = 1
            '                                            sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

            '                                        ElseIf (quantity + qtyrange = receivedqty + qty1) Or (receivedqty + qty1 = quantity - qtyrange) Then
            '                                            AxfpSpread1.Col = 1
            'l:
            '                                            sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + ",qtystatus='RECEIVED' where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            '                                        Else
            '                                            MessageBox.Show("Quantity Can't be greater than PO Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            '                                        End If
            '                                    Else
            '                                        AxfpSpread1.Col = 1
            '                                        sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

            '                                    End If
            '                                    ReDim Preserve GrnQuery(GrnQuery.Length)
            '                                    GrnQuery(GrnQuery.Length - 1) = sqlstring
            '                                End If
            '                            End If
            '                            'END PO 
            '                        Next

            '                        If (gconnection.MoreTrans2(GrnQuery)) Then
            '                            If Trim(CmbGrnType.SelectedItem) = "PO" And grp_Grngroup1.Visible = True And Trim(UCase(gShortname)) = "CCL" Then
            '                                Dim SQL As String = "select count(*) as a from  po_itemdetails where ISNULL(qtystatus,'') <> 'RECEIVED' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            '                                gconnection.getDataSet(SQL, "po_itemdetails")
            '                                If gdataset.Tables("po_itemdetails").Rows.Count > 0 Then
            '                                    If Val(gdataset.Tables("po_itemdetails").Rows(0).Item("a").ToString()) > 0 Then

            '                                    Else
            '                                        sqlstring = "update po_hdr set postatus='CLOSED' where   pono='" + Txt_PONo.Text + "' AND POTYPE NOT IN ('FIXED RATE OPEN QUANTITY' ,'OPEN RATE OPEN QUANTITY') AND VERSIONNO='" + versionno + "'"
            '                                        gconnection.dataOperation(6, sqlstring, )
            '                                    End If
            '                                End If
            '                            End If
            '                        End If
            '                        MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '                        '==============================================
            '                        clearoperation()
            '                    Else
            '                        'MsgBox("Transaction failed , Plz try again.. ")
            '                        MessageBox.Show("Transaction  failed , Plz try again..", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '                    End If
            '                End If
            '            End If

        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then

            If validateonupdate() = False Then
                '==============================================
                Array.Clear(GrnQuery, 0, GrnQuery.Length)
                '=============================================

                UpdateOperation()
                If check = False Then
                    Exit Sub
                End If

                If GrnQuery.Length > 0 Then
                    If (gconnection.MoreTrans2(GrnQuery)) Then
                        Dim ITEMCODE As String
                        Dim I As Integer
                        Dim items As String
                        items = ""
                        Dim dtitem As New DataTable
                        dtitem.Columns.Add("itemcode")
                        dtitem.TableName = "TpItems"

                        For I = 1 To AxfpSpread1.DataRowCnt
                            AxfpSpread1.Row = I
                            AxfpSpread1.Col = 1
                            ITEMCODE = Trim(AxfpSpread1.Text)
                            items = items & "'" & Trim(ITEMCODE) & "',"
                            dtitem.Rows.Add(ITEMCODE)
                        Next
                        items = Mid(items, 1, Len(items) - 1)
                        Call Randomize()
                        vOutfile = Mid("WE" & (Rnd() * 800000000), 1, 10)
                        vOutfile = Replace(vOutfile, ".", "")
                        vOutfile = Replace(vOutfile, "+", "")

                        Dim strrate As String
                        Dim loccode As String
                        sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_Storecode.Text) & "'"
                        gconnection.getDataSet(sqlstring, "loccode")
                        If gdataset.Tables("loccode").Rows.Count > 0 Then
                            loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                        Else
                            loccode = "M"
                        End If
                        Try
                            strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode)
                        Catch ex As Exception
                            MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            strrate = CALC_WEIGHTED(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, Trim(txt_Storecode.Text), "Q", vOutfile, loccode)
                        End Try
                        sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                        gconnection.ExcuteStoreProcedure(sqlstring)

                        MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call clearoperation()
                    End If
                End If
            End If

        End If

    End Sub

    Private Sub txt_Grnno_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Grnno.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            dtp_Grndate.Focus()
        End If
    End Sub

    Private Sub txt_Grnno_Validated(sender As Object, e As EventArgs) Handles txt_Grnno.Validated
        Dim I, J, K As Integer
        Dim vString, sqlstring As String
        Dim GRNDATE As Date
        Dim vTypeseqno, Clsquantity As Double
        Dim vGroupseqno As Double
        Dim dt As New DataTable
        If Trim(txt_Grnno.Text) <> "" Then
            Try
                sqlstring = "SELECT  ISNULL(GRNNO,'') AS GRNNO,ISNULL(GRNDETAILS,'') AS GRNDETAILS,ISNULL(PONO,'') AS PONO,GRNDATE,ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,"
                sqlstring = sqlstring & " SUPPLIERDATE,ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE,ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,ISNULL(CATEGORY,'') CATEGORY, "
                sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,ISNULL(REMARKS,'') AS REMARKS,"
                sqlstring = sqlstring & " ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,ISNULL(voiddate,'') AS voiddate,"
                sqlstring = sqlstring & " ISNULL(STORECODE,'') STORECODE , ISNULL(STOREDESC,'MAINSTORE') STOREDESC, ISNULL(OVERALLDISCOUNT,0) OVERALLDISCOUNT,isnull(RET_STATUS,'N') as RET_STATUS,isnull(GRN_TYPE1,'Direct GRN') as GRN_TYPE1  FROM GRN_HEADER"
                sqlstring = sqlstring & " WHERE ( Grndetails='" & Trim(txt_Grnno.Text) & "') "
                sqlstring = sqlstring & " and   isnull(GrnType,'')='GRN'"
                gconnection.getDataSet(sqlstring, "GRNHEADER")
                '''************************************************* SELECT record from Grn_header *********************************************''''                
                If gdataset.Tables("GRNHEADER").Rows.Count > 0 Then
                    'Call GridUnLock()
                    clearoperation()
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Grnno.ReadOnly = True
                    If gvendorlink = "Y" Then
                        txt_Suppliercode.Enabled = False
                        cmd_Suppliercodehelp.Enabled = False
                    End If
                    CmbGrnType.Enabled = False
                    CMB_CATEGORY.Enabled = False

                    Dim SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "'"
                    gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                    If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                        CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                    End If
                    'CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY"))
                    Txt_PONo.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO"))
                    Dim grnTYPE() As String = Split(Txt_PONo.Text, "/")

                    'SQL = " SELECT * FROM INV_SPONSORMASTER where ISNULL(Freeze,'N')<>'Y' and  SPONSORCODE='" + Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO")) + "'"
                    'gconnection.getDataSet(SQL, "INV_SPONSORMASTER")
                    CmbGrnType.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("grn_type1"))
                    If CmbGrnType.Text = "SPONSOR" Then
                        'CmbGrnType.Text = "SPONSOR"
                        'LBL_SPONSOR.Show()
                        'TXT_Sponsor.Show()
                        'cmd_SPONhelp.Show()
                        'TXT_Sponsor.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO"))
                    ElseIf CmbGrnType.Text = "DIRECT GRN" Then
                        ' CmbGrnType.Text = "DIRCET GRN"
                        LBL_SPONSOR.Hide()
                        TXT_Sponsor.Hide()
                        cmd_SPONhelp.Hide()
                        Txt_PONo.Hide()
                        Label4.Hide()
                        cmd_PONOhelp.Hide()
                    Else

                        Txt_PONo.Show()
                        Label4.Show()
                        cmd_PONOhelp.Show()
                        CmbGrnType.Text = "PO"
                    End If

                    txt_Grnno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDETAILS"))



                    dtp_Grndate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDATE")), "dd/MMM/yyyy")
                    'dtp_Grndate.Enabled = False
                    txt_Supplierinvno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERINVNO"))
                    dtp_Supplierinvdate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERDATE")), "dd/MMM/yyyy")
                    txt_Suppliercode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERCODE"))
                    txt_Suppliername.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERNAME"))
                    txt_Storecode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("STORECODE"))
                    txt_StoreDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("STOREDESC"))


                    If Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("VOID")) = "Y" Then
                        Cmd_Add.Enabled = False
                        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or UCase(gShortname) = "HSR" Then
                            Cmd_Freeze.Enabled = False
                            Cmd_Add.Enabled = False
                            Me.lbl_Freeze.Visible = True
                            Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("voiddate")), "dd/MMM/yyyy")
                        Else
                            Cmd_Freeze.Enabled = False
                            Me.lbl_Freeze.Visible = True
                            Me.lbl_Freeze.Visible = True
                            Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("voiddate")), "dd/MMM/yyyy")
                        End If

                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Freeze.Enabled = False


                    ElseIf Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("RET_STATUS")) = "Y" Then
                        Cmd_Freeze.Enabled = False
                        Cmd_Add.Enabled = False
                        sqlstring = "select * from pRN_HEADER where grndetails='" + txt_Grnno.Text + "'"
                        gconnection.getDataSet(sqlstring, "pRN_HEADER")
                        If gdataset.Tables("pRN_HEADER").Rows.Count > 0 Then
                            Me.lbl_Freeze.Text = " GRN is Return on " & Format(CDate(gdataset.Tables("pRN_HEADER").Rows(0).Item("prndate")), "dd/MMM/yyyy")
                            Me.lbl_Freeze.Visible = True
                        End If
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.Cmd_Add.Enabled = True
                        Me.Cmd_Freeze.Enabled = True

                    End If
                    '''************************************************* SELECT record from Grn_details *********************************************''''                
                    Dim vtmpitemcode, strsql As String
                    sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,isnull(baseamount,0) as baseamount,isnull(discper,0) as discper,isnull(taxcode,'') as taxcode,isnull(batchno,'') as batchno,"
                    sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(TAXPER,0) AS TAXPER,ISNULL(TAXAMOUNT,0) AS TAXAMOUNT,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,ISNULL(AMOUNTAFTERDISCOUNT,0) AS AMOUNTAFTERDISCOUNT,"
                    sqlstring = sqlstring & " ISNULL(VOIDITEM,'') AS VOIDITEM , isnull(OTHCHARGE,0) AS OTHCHARGE,isnull(freeqty,0) AS freeqty,ISNULL(FQUOM,'') AS FQUOM,ISNULL(SPONSORCODE,'') AS SPONSORCODE,ISNULL(COMPANYCODE,'') AS COMPANYCODE  FROM GRN_DETAILS WHERE  GRNDETAILS ='" & Trim(txt_Grnno.Text) & "' and itemcode in (select Itemcode from pur_nonstockable a where a.grndetails+a.itemcode not in(select batchno+b.itemcode from iss_nonstockable b) and a.grndetails='" & Trim(txt_Grnno.Text) & "')"
                    sqlstring = sqlstring & " ORDER BY AUTOID "
                    gconnection.getDataSet(sqlstring, "GRNDETAILS")

                    AxfpSpread1.ClearRange(1, 1, -1, -1, True)

                    If gdataset.Tables("GRNDETAILS").Rows.Count > 0 Then
                        For I = 1 To gdataset.Tables("GRNDETAILS").Rows.Count
                            AxfpSpread1.SetText(1, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE")))
                            vtmpitemcode = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMNAME")))
                            AxfpSpread1.Col = 3
                            Dim sql1 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("GRNDETAILS").Rows(J).Item("itemcode") + "'"

                            gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                AxfpSpread1.Row = I
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Col = 18
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Col = 3
                            Next Z

                            ' AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))

                            '    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                            AxfpSpread1.SetText(3, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM")))

                            '  AxfpSpread1.Text = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                            AxfpSpread1.SetText(4, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("qty")), "0.000"))
                            AxfpSpread1.SetText(5, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("RATE")), "0.000"))
                            AxfpSpread1.SetText(6, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("baseamount")), "0.000"))
                            '            ssgrid.SetText(7, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("PROFITPER")), "0.000"))
                            AxfpSpread1.SetText(7, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("discper")), "0.000"))
                            AxfpSpread1.SetText(8, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("discount")), "0.000"))
                            AxfpSpread1.SetText(9, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("amountafterdiscount")), "0.000"))

                            AxfpSpread1.SetText(11, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("taxper")), "0.000"))
                            AxfpSpread1.SetText(12, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("taxamount")), "0.000"))
                            AxfpSpread1.SetText(13, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("amount")), "0.000"))
                            AxfpSpread1.SetText(10, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("taxcode"))
                            AxfpSpread1.SetText(14, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("batchno"))
                            AxfpSpread1.SetText(15, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("othcharge")), "0.000"))
                            AxfpSpread1.SetText(16, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("voiditem"))
                            AxfpSpread1.SetText(17, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("FREEQTY")))
                            AxfpSpread1.SetText(18, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("FQUOM"))
                            AxfpSpread1.SetText(19, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("SPONSORCODE"))
                            AxfpSpread1.SetText(20, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("COMPANYCODE"))
                            '           ssgrid.SetText(11, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("SALERATE")), "0.000"))
                            '          ssgrid.SetText(12, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("DBLAMOUNT")), "0.000"))
                            '         ssgrid.SetText(13, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("DBLUOM")))
                            'ssgrid.SetText(14, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("HIGHRATIO")), "0.000"))
                            'AxfpSpread1.SetText(11, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("VOIDITEM")))
                            'AxfpSpread1.SetText(10, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("othcharge")))
                            '        ssgrid.SetText(19, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("FREEQTY")))
                            GRNDATE = Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy")
                            'It's getting so late so commanded

                            '  Clsquantity = ClosingQuantity_Date(vtmpitemcode, Trim(txt_Storecode.Text), Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM")), GRNDATE)
                            ' Clsquantity = ClosingQuantity(vtmpitemcode, GetMainStore())
                            'ssgrid.SetText(17, I, Clsquantity)
                            '  CMB_CATEGORY.Text = gdataset.Tables("GRNDETAILS").Rows(J).Item("CATEGORY")
                            J = J + 1
                        Next
                    End If

                    txt_Billamount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("BILLAMOUNT")), "0.000")
                    TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("OVERALLdiscount")), "0.000")
                    txt_Surchargeamt.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("SURCHARGEAMT")), "0.000")
                    txt_Remarks.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("REMARKS"))

                    'TotalCount = gdataset.Tables("GRNDETAILS").Rows.Count
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(1, 1)
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Cmd_Add.Text = "Update[F7]"
                    SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "'"
                    gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                    If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                        CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid GRN No : txt_Grnno_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub txt_totdisc_TextChanged(sender As Object, e As EventArgs) Handles txt_totdisc.TextChanged
        If calcbool = False Then
            CALCULATE()
        End If
    End Sub

    Private Sub txt_totaltax_TextChanged(sender As Object, e As EventArgs) Handles txt_totaltax.TextChanged
        If calcbool = False Then
            CALCULATE()
        End If

    End Sub

    Private Sub TXT_OVERALLdiscount_TextChanged(sender As Object, e As EventArgs) Handles TXT_OVERALLdiscount.TextChanged

        If Val(TXT_OVERALLdiscount.Text) > Val(txt_Billamount.Text) Then
            TXT_OVERALLdiscount.Text = ""
        Else

            If calcbool = False Then
                CALCULATE()
            End If
        End If


    End Sub

    Private Sub txt_Surchargeamt_TextChanged(sender As Object, e As EventArgs) Handles txt_Surchargeamt.TextChanged
        If calcbool = False Then
            CALCULATE()
        End If
    End Sub

    Private Sub CMB_CATEGORY_KeyDown(sender As Object, e As KeyEventArgs) Handles CMB_CATEGORY.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_Grnno.Focus()
        End If
    End Sub

    Private Sub dtp_Grndate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_Grndate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_Suppliercode.Focus()
        End If
    End Sub

    Private Sub txt_Suppliername_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Suppliername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_Supplierinvno.Focus()
        End If
    End Sub


    Private Sub txt_Supplierinvno_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Supplierinvno.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_Storecode.Focus()
        End If
    End Sub

    Private Sub dtp_Supplierinvdate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_Supplierinvdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            AxfpSpread1.Focus()
        End If
    End Sub


    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Try
            ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL As String
            Dim r As New Rpt_GrnBill
            sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
            sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
            sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
            sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE  "
            sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
            sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "'"
            'If rdo_code.Checked = True Then
            '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
            'ElseIf rdo_name.Checked = True Then
            '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
            'Else
            sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "
            'End If
            gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
            If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then
                'If chk_excel.Checked = True Then
                '    Dim exp As New exportexcel
                '    exp.Show()
                '    Call exp.export(sqlstring, "GRN CUM PURCHASE BILL ", "")
                'Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_INV_GRNBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName
                Dim textobj14 As TextObject
                textobj14 = r.ReportDefinition.ReportObjects("Text32")
                textobj14.Text = UCase(gCompanyAddress(0))
                Dim textobj16 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text33")
                textobj1.Text = UCase(gCompanyAddress(1))
                Dim textobj18 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text35")
                textobj1.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text30")
                textobj2.Text = gUsername
                '   If MyCompanyName = "THE BENGAL CLUB" Then
                Dim textobj3 As TextObject
                textobj3 = r.ReportDefinition.ReportObjects("Text28")
                textobj3.Text = ""
                ' End If
                rViewer.Show()
                'End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If

            '''Else
            '''    gPrint = False
            '''    Call printoperation()
            '''End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        'If validateonvoid() = False Then
        '    voidoperation()
        '    Dim ITEMCODE As String
        '    Dim I As Integer
        '    Dim items As String
        '    items = ""
        '    For I = 1 To AxfpSpread1.DataRowCnt
        '        AxfpSpread1.Row = I
        '        AxfpSpread1.Col = 1
        '        ITEMCODE = Trim(AxfpSpread1.Text)
        '        items = items & "'" & Trim(ITEMCODE) & "',"
        '    Next
        '    items = Mid(items, 1, Len(items) - 1)
        '    Call Randomize()
        '    vOutfile = Mid("WE" & (Rnd() * 800000000), 1, 10)
        '    vOutfile = Replace(vOutfile, ".", "")
        '    Dim strrate As String
        '    Dim loccode As String
        '    sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_Storecode.Text) & "'"
        '    gconnection.getDataSet(sqlstring, "loccode")
        '    If gdataset.Tables("loccode").Rows.Count > 0 Then
        '        loccode = gdataset.Tables("loccode").Rows(0).Item("location")
        '    Else
        '        loccode = "M"
        '    End If
        '    strrate = CALC_WEIGHTED(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, Trim(txt_Storecode.Text), "Q", vOutfile, loccode)
        '    'Dim sqls As String
        '    'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
        '    'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
        '    'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
        '    'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
        '    ''gconnection.ExcuteStoreProcedure(SQLS)
        '    'gconnection.ExcuteStoreProcedure(sqls)
        '    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
        '    gconnection.ExcuteStoreProcedure(sqlstring)
        '    clearoperation()


        'End If
    End Sub

    Private Sub CMB_CATEGORY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_CATEGORY.SelectedIndexChanged
        'autogenerate()
    End Sub

    Private Sub txt_Storecode_Validated(sender As Object, e As EventArgs) Handles txt_Storecode.Validated
        Dim sqlstring As String
        Try
            CATCODE = Split(CMB_CATEGORY.Text, "--->")
            sqlstring = "Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "'"
            gconnection.getDataSet(sqlstring, "Invstore_CategoryMaster")

            If Trim(txt_Storecode.Text) <> "" Then
                sqlstring = "SELECT storecode,storedesc FROM STOREMASTER "
                If (gdataset.Tables("Invstore_CategoryMaster").Rows.Count > 0) Then
                    sqlstring = sqlstring & " WHERE freeze <> 'Y' and storestatus='M' AND STORECODE='" + txt_Storecode.Text + "' and  storecode in ( Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"

                Else

                    sqlstring = sqlstring & " WHERE freeze <> 'Y' and storestatus='M' AND STORECODE='" + txt_Storecode.Text + "'"
                End If

                gconnection.getDataSet(sqlstring, "STOREMASTER")
                If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                    txt_Storecode.Text = Trim(gdataset.Tables("STOREMASTER").Rows(0).Item("storecode"))
                    txt_StoreDesc.Text = Trim(gdataset.Tables("STOREMASTER").Rows(0).Item("storedesc"))
                    txt_StoreDesc.ReadOnly = True
                    dtp_Supplierinvdate.Focus()


                Else
                    txt_Storecode.Text = ""
                    txt_StoreDesc.Text = ""
                    txt_StoreDesc.ReadOnly = False
                    txt_Storecode.Focus()
                End If
            Else
                txt_Storecode.Text = ""
                txt_StoreDesc.Text = ""
                txt_Storecode.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Suppliercode_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub



    'Private Sub CmbGrnType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbGrnType.SelectedIndexChanged
    '    If CmbGrnType.SelectedItem = "SPONSOR" Then

    '        clearoperation()
    '        Label4.Hide()
    '        Txt_PONo.Hide()
    '        cmd_PONOhelp.Hide()

    '        bindcategory()
    '    Else
    '        Label4.Show()
    '        Txt_PONo.Show()
    '        cmd_PONOhelp.Show()

    '    End If
    'End Sub

    Private Sub CmbGrnType_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbGrnType.SelectedValueChanged
        If CmbGrnType.SelectedItem = "SPONSOR" Then

            clearoperation1()
            Label4.Hide()
            Txt_PONo.Hide()
            cmd_PONOhelp.Hide()
            GridUnLock()
            bindcategory()

            ' If gAcPostingWise <> "STORE" Then
            For RW As Integer = 1 To 100
                AxfpSpread1.Col = 19
                AxfpSpread1.ColHidden = False
            Next

            'End If
            'LBL_SPONSOR.Show()
            'TXT_Sponsor.Show()
            'cmd_SPONhelp.Show()
        ElseIf CmbGrnType.SelectedItem = "DIRECT GRN" Then
            For RW As Integer = 1 To 100
                AxfpSpread1.Col = 19
                AxfpSpread1.ColHidden = True
            Next

            clearoperation1()
            LBL_SPONSOR.Hide()
            TXT_Sponsor.Hide()
            cmd_SPONhelp.Hide()
            Label4.Hide()
            Txt_PONo.Hide()
            cmd_PONOhelp.Hide()
        Else
            'AxfpSpread1.Row = 1
            'AxfpSpread1.Col = 19
            'If AxfpSpread1.ColHidden = False Then
            '    For RW As Integer = 1 To 100

            '        AxfpSpread1.Col = 19
            '        AxfpSpread1.ColHidden = True
            '    Next
            'End If
            clearoperation1()
            LBL_SPONSOR.Hide()
            TXT_Sponsor.Hide()
            cmd_SPONhelp.Hide()

            Label4.Show()
            Txt_PONo.Show()
            cmd_PONOhelp.Show()
        End If
    End Sub

    Private Sub AxfpSpread1_Advance(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread1.Advance

    End Sub


    Private Sub cmd_SPONhelp_Click(sender As Object, e As EventArgs) Handles cmd_SPONhelp.Click

        gSQLString = "SELECT ISNULL(SPONSORCODE,'') AS SPONSORCODE,ISNULL(SPONSORDESC,'') AS SPONSORDESC FROM INV_SPONSORMASTER"
        M_WhereCondition = ""
        Dim vform As New ListOperattion1

        vform.Field = "SPONSORDESC,SPONSORCODE"
        vform.vFormatstring = "         SPONSOR CODE              |                  SPONSOR DESCRIPTION                                                                                              "
        vform.vCaption = "SPONSOR MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_Sponsor.Text = Trim(vform.keyfield & "")
            Call txt_GroupCode_Validated(TXT_Sponsor, e)
        End If
        vform.Close()
        vform = Nothing

    End Sub
    Private Sub txt_GroupCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_Sponsor.Validated
        If Trim(TXT_Sponsor.Text) <> "" Then
            Dim sqlstring As String = "SELECT isnull(SPONSORcode,'') as SPONSORcode,isnull(SPONSORdesc,'') as SPONSORdesc,isnull(freeze,'') as freeze,isnull(adddate,'') as adddate FROM inv_SPONSORmaster WHERE SPONSORcode='" & Trim(TXT_Sponsor.Text) & "'"
            gconnection.getDataSet(sqlstring, "inv_SPONSORmaster")
            If gdataset.Tables("inv_SPONSORmaster").Rows.Count > 0 Then
                TXT_Sponsor.Text = Trim(gdataset.Tables("inv_SPONSORmaster").Rows(0).Item("SPONSORcode"))
                CMB_CATEGORY.Focus()
                'txt_SponDesc.Text = Trim(gdataset.Tables("inv_SPONSORmaster").Rows(0).Item("SPONSORdesc"))
                'txt_SponDesc.Focus()
                'txt_SponCode.ReadOnly = True
                'If gdataset.Tables("inv_SPONSORmaster").Rows(0).Item("Freeze") = "Y" Then
                '    Me.lbl_Freeze.Visible = True
                '    Me.lbl_Freeze.Text = ""
                '    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("inv_SPONSORmaster").Rows(0).Item("AddDate")), "dd/MMM/yyyy")
                '    Me.Cmd_Freeze.Text = "UnVoid[F8]"
                '    Me.Cmd_Freeze.Enabled = True
                'Else
                '    Me.lbl_Freeze.Visible = False
                '    Me.lbl_Freeze.Text = "Record Freezed  On "
                '    Me.Cmd_Freeze.Text = "Void[F8]"
                'End If
                'Me.Cmd_Add.Text = "Update[F7]"
            Else
                'Me.lbl_Freeze.Visible = False
                'Me.lbl_Freeze.Text = "Record Freezed  On "
                'Me.Cmd_Add.Text = "Add [F7]"
                'txt_SponCode.ReadOnly = False
                'txt_SponDesc.Focus()
            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Else
            TXT_Sponsor.Text = ""
            TXT_Sponsor.Focus()
        End If
    End Sub


    Private Sub Cmd_Add_Validated(sender As Object, e As EventArgs) Handles Cmd_Add.Validated

    End Sub

    Private Sub TXT_Sponsor_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_Sponsor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TXT_Sponsor.Text <> "" Then
                Call txt_GroupCode_Validated(TXT_Sponsor, e)
            Else
                Call cmd_SPONhelp_Click(TXT_Sponsor.Text, e)
            End If
        End If
    End Sub



    Private Sub TXT_OVERALLdiscount_Validated(sender As Object, e As EventArgs) Handles TXT_OVERALLdiscount.Validated
        If Val(TXT_OVERALLdiscount.Text) > Val(txt_Billamount.Text) Then

        End If
    End Sub
End Class