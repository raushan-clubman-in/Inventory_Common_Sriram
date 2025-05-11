Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_PRNNew
    Dim gconnection As New GlobalClass
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
    Dim VATFLAG As Boolean = True
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
    Private Sub yearselection()
        Dim I As Integer
        Dim index As Integer
        Try
            CMB_YEAR.Items.Clear()
            Dim sql As String = "select isnull(DATAFILE,'')as DATAFILE from PRN_YEARSELECTION"
            gconnection.getDataSet(sql, "YEARSELECTION")
            If (gdataset.Tables("YEARSELECTION").Rows.Count > 0) Then
                For I = 0 To gdataset.Tables("YEARSELECTION").Rows.Count - 1
                    CMB_YEAR.Items.Add(gdataset.Tables("YEARSELECTION").Rows(I).Item("DATAFILE"))
                Next
                index = CMB_YEAR.FindString(DefaultGRN)
                CMB_YEAR.SelectedIndex = index
            End If
        Catch ex As Exception
        End Try
    End Sub

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
            Dim sqlstring, financalyear As String
            Dim month As String
            Dim CATLEN As Integer
            Dim category As String
            Dim S As String
            month = UCase(Format(Now, "MMM"))
            gcommand = New SqlCommand
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
            sqlstring = "SELECT MAX(Cast(SUBSTRING(PRNNO,1,6) As Numeric)) FROM PRN_HEADER WHERE SUBSTRING(PRNDETAILS,5," & CATLEN & ")='" & category & "'  AND ISNULL(GRNTYPE,'')='PRN'"
            '        sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    Txt_PRNNo.Text = "PRN/" & category & "/" & "0001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    Txt_PRNNo.Text = "PRN/" & category & "/" & Format(gdreader(0) + 1, "0000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                Txt_PRNNo.Text = "PRN/" & category & "/0001/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
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

    Private Sub Frm_PRNNew_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
           
            ElseIf e.KeyCode = Keys.R Then
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Frm_PRNNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (gpocode = "Y") Then
            grp_Grngroup1.Visible = True
        Else
            grp_Grngroup1.Visible = False
        End If
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        'Me.DoubleBuffered = True
        'Resize_Form()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        FillGRNTYPE()
        bindcategory()
        autogenerate()
        'Added by Sri for Last Year GRN has to shown in Purchase return

        yearselection()

        'end 
        sqlstring = "Select getdate()"
        gdate = gconnection.getvalue(sqlstring)

        If Trim(UCase(gShortname)) = "CGC" Then
            lock_Frqty()
        End If

        CMB_YEAR.SelectedIndex = 1


        LBL_SPONSOR.Hide()
        TXT_Sponsor.Hide()
        cmd_SPONhelp.Hide()
        Txt_PONo.Enabled = False
        TXT_Sponsor.Enabled = False
        If gShortname = "CCL" Then
            dtp_Prndate.Enabled = True
        Else
            dtp_Prndate.Enabled = False
        End If
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

                M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "')  and  slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
            Else

                M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "') "
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

        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
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
                    sql = "SELECT TOP 1   batchrate as rate  FROM ratelist WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' ORDER BY grndate DESC"
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
                sql = "select TAXCODE, taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + Trim(vform.keyfield) + "'"
                gconnection.getDataSet(sql, "Itemtaxtagging")
                If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                    AxfpSpread1.Col = 10
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                    AxfpSpread1.Col = 11
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                    'AxfpSpread1.Col = 12
                    'AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    'AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("GLACCOUNTIN")
                Else
                    MessageBox.Show("Create TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

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
                    sql = "SELECT TOP 1   batchrate as rate  FROM ratelist WHERE itemcode='" + Trim(vform.keyfield) + "' AND storecode='" + txt_Storecode.Text + "'  ORDER BY grndate DESC"
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
                sql = "select TAXCODE, taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + Trim(vform.keyfield) + "'"
                gconnection.getDataSet(sql, "Itemtaxtagging")
                If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                    AxfpSpread1.Col = 10
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                    AxfpSpread1.Col = 11
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                Else
                    MessageBox.Show("Create TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                End If
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            End If
        End If

    End Sub


    Private Function validateonupdate() As Boolean
        Dim flag As Boolean

        Dim checkBdate As Boolean
        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"), txt_Storecode.Text)
        'Else
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"))
        'End If
        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"), txt_Storecode.Text)
        If checkBdate = True And RESU1 = False Then
            MsgBox("Business date closed..")
            flag = True
            Return flag
        End If

        'If checkBdate = True And RESU1 = True Then
        '    MsgBox("Business date closed , Due to Adjustement Entry")
        '    flag = True
        '    Return flag
        'End If

        If DateDiff(DateInterval.Day, (CDate(dtp_Prndate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("PRN Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
        'If (gdirissue = "Y") Then
        '    nonstockable.Columns.Clear()
        '    Dim dc As New DataColumn("ItemCode", GetType(String))

        '    ' dc.ColumnName = "ItemCode"

        '    nonstockable.Columns.Add(dc)
        '    Dim dc1 As New DataColumn("ItemName", GetType(String))
        '    nonstockable.Columns.Add(dc1)

        '    Dim dc2 As New DataColumn("UOM", GetType(String))
        '    nonstockable.Columns.Add(dc2)
        '    Dim dc3 As New DataColumn("Quantity", GetType(Double))
        '    nonstockable.Columns.Add(dc3)
        '    'Dim dc4 As New DataColumn("Rate", GetType(Double))
        '    'nonstockable.Columns.Add(dc4)

        '    Dim dc5 As New DataColumn("StoreCode", GetType(String))

        '    nonstockable.Columns.Add(dc5)

        'End If

        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = i + 1
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 4
            Dim qty As Double = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 17
            Dim fQqty As Double = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 3
            Dim uom As String = AxfpSpread1.Text
            AxfpSpread1.Col = 18
            Dim fQuom As String = AxfpSpread1.Text

            Dim qty1 As Double
            Dim batchyn As String
            Dim SQLSTring As String
            Dim stockuom As String
            Dim convvalue As Double
            SQLSTring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
            stockuom = gconnection.getvalue(SQLSTring)

            SQLSTring = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + stockuom + "' and transuom='" + uom + "'"
            gconnection.getDataSet(SQLSTring, "INVENTORY_TRANSCONVERSION")
            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
            Else
                MessageBox.Show("Generate relation between " + stockuom + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Exit Function
            End If
            qty = qty / convvalue

            SQLSTring = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + stockuom + "' and transuom='" + fQuom + "'"
            gconnection.getDataSet(SQLSTring, "INVENTORY_TRANSCONVERSION")
            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
            Else
                MessageBox.Show("Generate relation between " + stockuom + " and " + fQuom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Exit Function
            End If
            fQqty = fQqty / convvalue
            qty = qty + fQqty
            Dim sql As String = "select qty,isnull(batchyn,'') as batchyn from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'  "
            sql = sql & " and Trnno='" + Txt_PRNNo.Text + "' "
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
            End If
            sql = "select closingstock +" + Format(Val(qty - qty1), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(qty - qty1), "0.000") + "<0 AND itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'"
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + txt_Grnno.Text + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Updation create" + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
                    AxfpSpread1.Col = 4

                    drow.Item("quantity") = Val(AxfpSpread1.Text)

                    drow.Item("StoreCode") = ""
                    nonstockable.Rows.Add(drow)

                End If

            End If
            If (Format(CDate(gdate), "yyyy/MM/dd") > Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd")) Then
                Dim count As Double = 0
                sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'  order by trndate"

                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
                    count = count + Val(qty - qty1)
                    For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
                        count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
                        If count < 0 Then
                            MessageBox.Show("Update create  " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag
                        End If
                    Next
                End If

            End If

        Next


        'If (gdirissue = "Y") Then
        '    If (nonstockable.Rows.Count > 0) Then
        '        MessageBox.Show("Item is Issued You Cant Update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        '        Cmd_Add.Enabled = False
        '        flag = True
        '        Return flag
        '        'Dim frm1 As New FrmDirectIssueing

        '        'frm1.ShowDialog(Me)
        '        'If (frm1.flg = True) Then

        '        'Else
        '        '    flag = True
        '        '    Return flag
        '        'End If

        '    End If


        'End If
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
        Return False
    End Function

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
                If gShortname <> "CCL" Then
                    MsgBox("Create TaxCode For item" + AxfpSpread1.Text, MsgBoxStyle.Critical, "TaxCode")
                    Return True
                End If
              
            End If
        Next
        Return False
    End Function

    Private Function validateoninsert() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"), txt_Storecode.Text)
        'Else
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"))
        'End If
        Dim bdate1 As String
        Dim sql1 As String

        sql1 = "select convert(varchar(11),bdate,106) as bdate1 from Businessdate"
        gconnection.getDataSet(sql1, "Businessdate")

        If (gdataset.Tables("Businessdate").Rows.Count > 0) Then
            bdate1 = "Your current Business date is " & gdataset.Tables("Businessdate").Rows(0).Item("bdate1").ToString
        End If


        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"), txt_Storecode.Text)
        If checkBdate = True And RESU1 = False Then
            MsgBox(bdate1)
            flag = True
            Return flag
        End If

        'If checkBdate = True And RESU1 = True Then
        '    MsgBox("Business date closed , Due to Adjustement Entry")
        '    flag = True
        '    Return flag
        'End If
        If txt_Grnno.Text = "" Then
            MessageBox.Show("Please Fill GrnNo ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag
        End If
        If gShortname <> "CCL" Then
            If DateDiff(DateInterval.Day, (CDate(dtp_Prndate.Value)), DateValue(Now)) < 0 Then
                MessageBox.Show("PRN Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If
        End If

        If (CDate(dtp_Prndate.Value)) < (CDate(dtp_Grndate.Value)) Then
            MessageBox.Show("PRN Date Should be greater than GRN Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
        'If Trim(CmbGrnType.SelectedItem) = "PO" Then
        '    If Txt_PONo.Text = "" And Txt_PONo.Visible = True Then
        '        MessageBox.Show("Please Fill POno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        Txt_PONo.BackColor = Color.Red
        '        Txt_PONo.Focus()

        '        flag = True
        '        Return flag
        '    Else
        '        Txt_PONo.BackColor = Color.White

        '    End If
        'End If

        If txt_Suppliercode.Text = "" Then
            MessageBox.Show("Please Fill Vendor Code ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_Suppliercode.BackColor = Color.Red
            txt_Suppliercode.Focus()

            flag = True
            Return flag
        Else
            txt_Suppliercode.BackColor = Color.White

        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 4
            Dim qty As String = Val(AxfpSpread1.Text)
            Dim qty1 As Double
            Dim batchyn As String
            Dim sql As String = "select qty,batchyn from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
            sql = sql & " and Trnno='" + txt_Grnno.Text + "' "
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
            End If
            sql = "select closingstock -" + Format(Val(qty), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
            sql = sql & " and closingstock -" + Format(Val(qty), "0.000") + "<0 "
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + txt_Grnno.Text + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Deletion create  " + itemcode + "  Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If


            sql = "Select isnull(qty,0) as qty,isnull(ret_qty,0) as ret_qty  from Grn_details where grndetails='" + txt_Grnno.Text + "' and itemcode='" + itemcode + "'"
            gconnection.getDataSet(sql, "grndetails")
            If (gdataset.Tables("grndetails").Rows.Count > 0) Then
                ' Dim qtyrange As Double = Val(gdataset.Tables("grndetails").Rows(0).Item("qtyrange"))
                qty = Val(gdataset.Tables("grndetails").Rows(0).Item("qty"))
                Dim ret_qty As Double = Val(gdataset.Tables("grndetails").Rows(0).Item("ret_qty"))
                AxfpSpread1.Col = 4
                If (qty - ret_qty) < Val(AxfpSpread1.Text) Then
                    MessageBox.Show("Quantity Cannot be Greater than GRN Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    flag = True
                    Return flag
                Else

                End If
            End If


            AxfpSpread1.Col = 3
            Dim uom As String = AxfpSpread1.Text
            Dim uom1 As String
            Dim closingqty As Double
            gconnection.closingStock(Format(dtp_Prndate.Value, "dd/MMM/yyyy"), itemcode, Trim(txt_Storecode.Text), "")


            Dim precise As Double
            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                Dim convvalue As Double
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                Else
                    MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag

                End If
                closingqty = closingqty * convvalue
                qty = qty / convvalue
                If closingqty <= 0 Then
                    MessageBox.Show("Stock is not available....:-" & itemcode)
                    flag = True
                    Return flag
                End If
            Else
                MessageBox.Show("Stock Is Not Available:- " & itemcode)
                flag = True
                Return flag
            End If

            'If (qty > closingqty) Then
            '    MessageBox.Show("Return Quantity Cannot be Greater than Closing Quantity (" + closingqty.ToString() + ")")
            '    flag = True
            '    Return flag

            'End If

            'If (Format(CDate(gdate), "yyyy/MM/dd") > Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd")) Then
            '    Dim count As Double = 0
            '    sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'  order by trndate,priority"

            '    gconnection.getDataSet(sql, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
            '        count = count - qty1
            '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
            '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
            '            If count < 0 Then
            '                MessageBox.Show("Deletion create  " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        Next
            '    End If

            'End If

        Next
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)
            flag = True
            Return flag
        End If
        If check_taxcode() = True Then

            flag = True
            Return flag


        End If
        Return False
    End Function

    Private Function validateonvoid() As Boolean

        Dim flag As Boolean
        Dim checkBdate As Boolean
        If Mid(UCase(gShortname), 1, 3) = "CCL" Then
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"), txt_Storecode.Text)
        Else
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"))
        End If
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
        'If Trim(CmbGrnType.SelectedItem) = "PO" Then
        '    If Txt_PONo.Text = "" And Txt_PONo.Visible = True Then
        '        MessageBox.Show("Please Fill POno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        Txt_PONo.BackColor = Color.Red
        '        Txt_PONo.Focus()

        '        flag = True
        '        Return flag
        '    Else
        '        Txt_PONo.BackColor = Color.White

        '    End If
        'End If

        If txt_Suppliercode.Text = "" Then
            MessageBox.Show("Please Fill Vendor Code ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_Suppliercode.BackColor = Color.Red
            txt_Suppliercode.Focus()

            flag = True
            Return flag
        Else
            txt_Suppliercode.BackColor = Color.White

        End If
        'For i As Integer = 0 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Col = 1
        '    Dim itemcode As String = AxfpSpread1.Text
        '    AxfpSpread1.Col = 4
        '    Dim qty As String = Val(AxfpSpread1.Text)
        '    Dim qty1 As Double
        '    Dim batchyn As String
        '    Dim sql As String = "select qty,batchyn from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
        '    sql = sql & " and Trnno='" + txt_Grnno.Text + "' "
        '    gconnection.getDataSet(sql, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '    End If
        '    sql = "select closingstock -" + Format(Val(qty), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
        '    sql = sql & " and closingstock -" + Format(Val(qty), "0.000") + "<0 "
        '    If batchyn = "Y" Then
        '        sql = sql & " and batchno='" + txt_Grnno.Text + "'"
        '    End If
        '    gconnection.getDataSet(sql, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        MessageBox.Show("Deletion create  " + itemcode + "  Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        flag = True
        '        Return flag
        '    End If

        '    If (Format(CDate(gdate), "yyyy/MM/dd") > Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd")) Then
        '        Dim count As Double = 0
        '        sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'  order by trndate"

        '        gconnection.getDataSet(sql, "closingqty")
        '        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '            count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
        '            count = count - qty1
        '            For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
        '                count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
        '                If count < 0 Then
        '                    MessageBox.Show("Deletion create  " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '                    flag = True
        '                    Return flag
        '                End If
        '            Next
        '        End If

        '    End If

        'Next
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)
            flag = True
            Return flag
        End If
        If check_taxcode() = True Then

            flag = True
            Return flag


        End If
        Return False
    End Function


    'Private Sub CALCULATE()
    '    Dim overalldisc, othercharge, extra, grossamt As Double
    '    Dim totqty, totamt, taxamt, discamt, freeqty, totfreeqty As Double
    '    Dim itemqty, itemrate, itemamount, itemtax, itemdisc, discperc, taxperc, itemtot, amtwithoutdisc, overdiscextra, overotherextra As Double

    '    calcbool = True
    '    If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Or AxfpSpread1.ActiveCol = 7 Or AxfpSpread1.ActiveCol = 8 Or AxfpSpread1.ActiveCol = 10 Or AxfpSpread1.ActiveCol = 17 Then

    '        For i As Integer = 1 To AxfpSpread1.DataRowCnt
    '            AxfpSpread1.Row = i
    '            AxfpSpread1.Col = 4
    '            itemqty = Val(AxfpSpread1.Text)
    '            AxfpSpread1.Row = i
    '            AxfpSpread1.Col = 5
    '            itemrate = Val(AxfpSpread1.Text)
    '            If (itemrate = 0) Then
    '                freeqty = itemqty
    '            Else
    '                freeqty = 0
    '            End If
    '            AxfpSpread1.Row = i
    '            AxfpSpread1.Col = 6
    '            itemamount = itemqty * itemrate
    '            AxfpSpread1.Text = itemamount
    '            AxfpSpread1.Row = i
    '            AxfpSpread1.Col = 7
    '            discperc = Val(AxfpSpread1.Text)
    '            If AxfpSpread1.Text <> "0.00" Then
    '                itemdisc = (itemamount * discperc) / 100
    '                AxfpSpread1.Col = 8
    '                AxfpSpread1.Text = itemdisc
    '            Else
    '                AxfpSpread1.Col = 8
    '                AxfpSpread1.Row = i

    '                'taxperc = Val(AxfpSpread1.Text)
    '                If AxfpSpread1.Text = "0.00" Then
    '                    itemdisc = (itemamount * discperc) / 100
    '                    AxfpSpread1.Text = itemdisc
    '                Else

    '                    itemdisc = Val(AxfpSpread1.Text)
    '                End If

    '            End If

    '            AxfpSpread1.Col = 9
    '            amtwithoutdisc = itemamount - itemdisc
    '            AxfpSpread1.Text = amtwithoutdisc


    '            AxfpSpread1.Col = 11
    '            taxperc = Val(AxfpSpread1.Text)



    '            AxfpSpread1.Col = 12
    '            itemtax = (amtwithoutdisc * taxperc) / 100
    '            AxfpSpread1.Text = itemtax
    '            AxfpSpread1.Col = 13

    '            itemtot = itemamount + itemtax - itemdisc
    '            AxfpSpread1.Text = itemtot
    '            totqty = totqty + itemqty
    '            totfreeqty = totfreeqty + freeqty
    '            totamt = totamt + itemamount
    '            taxamt = taxamt + itemtax
    '            discamt = discamt + itemdisc
    '            grossamt = grossamt + itemtot
    '        Next

    '        txt_totdisc.Text = discamt
    '        txt_totaltax.Text = Math.Round(taxamt, 2)
    '        txt_total.Text = totamt


    '        overalldisc = Convert.ToDouble(Format(Val(TXT_OVERALLdiscount.Text), 0.0))
    '        othercharge = Convert.ToDouble(Format(Val(txt_Surchargeamt.Text), 0.0))
    '        ' 
    '        If (gpocode = "Y" And totpoqty <> 0) Then
    '            extra = (otherchargepo - overalldiscountpo) / (totpoqty)

    '        Else
    '            extra = (othercharge - overalldisc) / (totqty - totfreeqty)
    '        End If
    '        For i As Integer = 1 To AxfpSpread1.DataRowCnt
    '            AxfpSpread1.Row = i
    '            AxfpSpread1.Col = 4
    '            itemqty = Val(AxfpSpread1.Text)
    '            AxfpSpread1.Row = i
    '            AxfpSpread1.Col = 5
    '            itemrate = Val(AxfpSpread1.Text)
    '            If (itemrate = 0) Then
    '                AxfpSpread1.Row = i
    '                AxfpSpread1.Col = 15
    '                AxfpSpread1.Text = 0
    '            Else
    '                AxfpSpread1.Row = i
    '                AxfpSpread1.Col = 15
    '                AxfpSpread1.Text = extra * itemqty
    '                If (gpocode = "Y" And totpoqty <> 0) Then
    '                    overdiscextra = overdiscextra + (overalldiscountpo / totpoqty) * itemqty
    '                    overotherextra = overotherextra + (otherchargepo / totpoqty) * itemqty
    '                End If

    '            End If
    '        Next
    '        If (gpocode = "Y") Then
    '            txt_Surchargeamt.Text = Format(Val(overotherextra), "0.000")
    '            TXT_OVERALLdiscount.Text = Format(Val(overdiscextra) + Val(TXT_OVERALLdiscount.Text), "0.000")

    '        End If
    '        '  txt_Billamount.Text = Format(Val(txt_total.Text) - Val(overalldisc) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")

    '        txt_Billamount.Text = Format(Val(txt_total.Text) - Val(TXT_OVERALLdiscount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")
    '    End If
    '    calcbool = False
    'End Sub

    Private Sub CALCULATE()
        Dim ITEMCODE, UOM As String
        Dim overalldisc, othercharge, extra, grossamt As Double
        Dim totqty, totamt, taxamt, discamt, freeqty, totfreeqty, SPLCESS, ISPLCESS, TOSPLCESS As Double
        Dim itemqty, itemrate, itemamount, itemtax, itemdisc, discperc, taxperc, itemtot, amtwithoutdisc, overdiscextra, overotherextra As Double
        calcbool = True
        If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Or AxfpSpread1.ActiveCol = 7 Or AxfpSpread1.ActiveCol = 8 Or AxfpSpread1.ActiveCol = 10 Or AxfpSpread1.ActiveCol = 17 Or AxfpSpread1.ActiveCol = 19 Then
            For i As Integer = 1 To AxfpSpread1.DataRowCnt

                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                ITEMCODE = Trim(AxfpSpread1.Text)

                AxfpSpread1.Col = 3
                UOM = Trim(AxfpSpread1.Text)

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

                If ITEMCODE <> "" And UOM <> "" Then

                    If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                        SPLCESS = GetSPLCESS(ITEMCODE, Trim(UOM))
                        ISPLCESS = (SPLCESS * itemqty)
                        AxfpSpread1.Col = 19
                        AxfpSpread1.Text = ISPLCESS
                    Else
                        'SPLCESS = GetSPLCESS(ITEMCODE, Trim(UOM))
                        'TOSPLCESS = (SPLCESS * itemqty)
                        AxfpSpread1.Col = 19
                        'AxfpSpread1.Text = TOSPLCESS
                        ISPLCESS = Val(AxfpSpread1.Text)
                    End If
                Else
                    AxfpSpread1.Col = 19
                    ISPLCESS = Format(AxfpSpread1.Text, "0.000")

                End If


                AxfpSpread1.Col = 9
                amtwithoutdisc = itemamount - itemdisc
                AxfpSpread1.Text = amtwithoutdisc


                AxfpSpread1.Col = 11
                taxperc = Val(AxfpSpread1.Text)



                AxfpSpread1.Col = 12
                itemtax = (amtwithoutdisc * taxperc) / 100
                AxfpSpread1.Text = itemtax
                AxfpSpread1.Col = 13


                TOSPLCESS = TOSPLCESS + ISPLCESS
                itemamount = itemamount + (ISPLCESS)
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
            ' 
            If (gpocode = "Y" And totpoqty <> 0) Then
                extra = (otherchargepo - overalldiscountpo) / (totpoqty)

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
                    End If

                End If
            Next
            If (gpocode = "Y") Then
                txt_Surchargeamt.Text = Format(Val(overotherextra), "0.000")
                ' TXT_OVERALLdiscount.Text = Format(Val(overdiscextra) + Val(TXT_OVERALLdiscount.Text), "0.000")

                TXT_OVERALLdiscount.Text = Format(Val(TXT_OVERALLdiscount.Text), "0.000")
            End If
            Txt_SPLCESS.Text = Format(Val(TOSPLCESS), "0.000")
            '  txt_Billamount.Text = Format(Val(txt_total.Text) - Val(overalldisc) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")

            txt_Billamount.Text = Format(Val(txt_total.Text) - Val(TXT_OVERALLdiscount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")
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
        If CmbGrnType.SelectedItem = "SPONSOR" Then
            CmbGrnType.Text = "PO"
        End If
        Label4.Show()
        Txt_PONo.Show()
        cmd_PONOhelp.Show()
        CMB_CATEGORY.Enabled = True
        autogenerate()
        dtp_Grndate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        dtp_Prndate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Grnno.Text = ""
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
        nonstockable.Columns.Clear()
        CMB_YEAR.SelectedIndex = 1

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

        autogenerate()
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
    End Sub
    Private Sub addoperation()
        Dim INSERT(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim uom As String
        Dim fquom As String
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        Dim weightedrate As Decimal
        Dim lastweightedrate As Double
        Dim STOCKUOM As String
        Dim CONVVALUE As Double
        Dim FQCONVVALUE As Double
        Dim precise As Double
        Dim fqprecise As Double
        GRNno = Split(Trim(Txt_PRNNo.Text), "/")
        CATCODE = Split(CMB_CATEGORY.Text, "--->")
        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            Call autogenerate()
        End If

        sqlstring = "INSERT INTO Prn_header(category,prnno,Prndetails,Prndate,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
        ' sqlstring = sqlstring & ",Typecode,Typedesc,Excisepassno,Excisedate,Stockindate,Trucknumber,Creditdays,Glaccountcode,Glaccountname,Slcode,Slname,Costcentercode,Costcentername,"
        sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,TOTSPLCESS)"

        If Trim(CmbGrnType.SelectedItem) = "PO" Then

            If UCase(gpocode) <> "Y" Then
                versionno = Trim(txt_Grnno.Text + "-0")
                potype = Trim("")
            End If

            sqlstring = sqlstring & " VALUES ('" & Trim(CATCODE(0)) & "','" & CStr(GRNno(2)) & "',"
            sqlstring = sqlstring & " '" & Trim(CStr(Txt_PRNNo.Text)) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Grnno.Text)) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
            '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
            '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
            ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
            sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.000") & "," & Format(Val(txt_totaltax.Text), "0.000") & "," & Format(Val(txt_Surchargeamt.Text), "0.000") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.000") & "," & Format(Val(txt_totdisc.Text), "0.000") & ","
            sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.000") & ","
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',getDate(),"
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
            sqlstring = sqlstring & "  'PRN','" + versionno + "'," & Format(Val(Txt_SPLCESS.Text), "0.000") & ")"
        Else

            sqlstring = sqlstring & " VALUES ('" & Trim(CATCODE(0)) & "','" & CStr(GRNno(2)) & "',"
            sqlstring = sqlstring & " '" & Trim(CStr(Txt_PRNNo.Text)) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Grnno.Text)) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(TXT_Sponsor.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
            '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
            '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
            ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
            sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.000") & "," & Format(Val(txt_totaltax.Text), "0.000") & "," & Format(Val(txt_Surchargeamt.Text), "0.000") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.000") & "," & Format(Val(txt_totdisc.Text), "0.000") & ","
            sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.000") & ","
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',getDate(),"
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
            sqlstring = sqlstring & "  'PRN',''," & Format(Val(Txt_SPLCESS.Text), "0.000") & ")"

        End If

        INSERT(0) = sqlstring
        ' Dim Seq As Double = gconnection.getInvSeq(Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy"))
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            Dim fqqty As Double
            Dim qty1 As Double
            If Trim(CmbGrnType.SelectedItem) = "PO" Then
                sqlstring = "INSERT INTO Prn_details(Prnno,prndetails,Prndate,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
                sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,Discount,amountafterdiscount,taxcode,TaxPer,taxamount,amount,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FqUom,SPLCESS)"
                sqlstring = sqlstring & " VALUES('" & CStr(GRNno(2)) & "','" & Trim(Txt_PRNNo.Text) & "','" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
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
                sqlstring = sqlstring & "'" & Trim(gUsername) & "',getDate(),"
                sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
                sqlstring = sqlstring & "'PRN','" + versionno + "',"

                AxfpSpread1.Col = 17
                fqqty = Format(Val(AxfpSpread1.Text), "0.000")
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                AxfpSpread1.Col = 18
                fquom = AxfpSpread1.Text
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 19
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ")"
            Else
                sqlstring = "INSERT INTO prn_details(prnno,prndetails,Prndate,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
                sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,Discount,amountafterdiscount,taxcode,TaxPer,taxamount,amount,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FREEQTY,FqUom,SPLCESS)"
                'sqlstring = sqlstring & " VALUES('" & CStr(GRNno(2)) & "','" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " VALUES('" & CStr(GRNno(2)) & "','" & Trim(Txt_PRNNo.Text) & "','" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
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
                sqlstring = sqlstring & "'" & Trim(gUsername) & "',getDate(),"
                sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
                sqlstring = sqlstring & "'PRN','',"

                AxfpSpread1.Col = 17
                fqqty = Format(Val(AxfpSpread1.Text), "0.000")
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                AxfpSpread1.Col = 18
                fquom = AxfpSpread1.Text
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 19
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ")"
            End If
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            'updation in po_itemdetails

            AxfpSpread1.Col = 1
            itemcode1 = AxfpSpread1.Text
            sqlstring = "select isnull(RET_QTY,0) as RET_QTY ,isnull(QTY,0) as QTY from grn_details  where grndetails='" + txt_Grnno.Text + "' and"
            sqlstring = sqlstring & " itemcode='" + AxfpSpread1.Text + "'"
            gconnection.getDataSet(sqlstring, "grn_details")
            If (gdataset.Tables("grn_details").Rows.Count > 0) Then
                Dim RET_QTY As Double = Val(gdataset.Tables("grn_details").Rows(0).Item("RET_QTY"))
                Dim grnQTY As Double = Val(gdataset.Tables("grn_details").Rows(0).Item("QTY"))
                ' Dim qtyrange As Double = Val(gdataset.Tables("grn_details").Rows(0).Item("qtyrange"))
                AxfpSpread1.Col = 4
                qty1 = Format(Val(AxfpSpread1.Text), "0.000")
                If (RET_QTY + qty1 <= grnQTY) Then
                    AxfpSpread1.Col = 1
                    sqlstring = "update grn_details set RET_QTY=" + Format(Val(RET_QTY + qty1), "0.000") + " where  itemcode='" + AxfpSpread1.Text + "' and grndetails='" + txt_Grnno.Text + "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
                    sqlstring = "update GRN_HEADER set RET_STATUS='Y' where  grndetails='" + txt_Grnno.Text + "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
                Else
                    MessageBox.Show("Quantity Can't be greater than GRN Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If


            End If

            'sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode1 + "'"
            'STOCKUOM = gconnection.getvalue(sqlstring)
            'sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
            'gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
            'If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
            '    CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
            '    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
            'Else
            '    MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    Exit Sub
            'End If
            ''=====Adding Free Qty for CCL ==========
            'If Trim(UCase(gShortname)) = "CCL" Then
            '    sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + fquom + "'"
            '    gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
            '    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
            '        FQCONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
            '        fqprecise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
            '        fqqty = (fqqty / FQCONVVALUE) + (fqqty * fqprecise)
            '        qty1 = qty1 + fqqty
            '    Else
            '        MessageBox.Show("Generate relation between " + uom + " and " + fquom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '        Exit Sub
            '    End If
            'Else

            'End If
            ''==========================================
            'Try

            '    Dim cmd As New SqlCommand("INV_SPWeightedRateCalculation", gconnection.Myconn)

            '    'Dim param As New SqlParameter
            '    'param.ParameterName = "@tpitemcode"
            '    'param.Value = itemcode1
            '    'cmd.Parameters.Add(param)
            '    cmd.CommandType = CommandType.StoredProcedure
            '    cmd.Parameters.Add("@ttodate", SqlDbType.DateTime).Value = Format(dtp_Grndate.Value.ToString("dd/MMM/yyyy"))
            '    cmd.Parameters.Add("@tpitemcode", SqlDbType.VarChar, 50).Value = itemcode1
            '    cmd.Parameters.Add("@tstorecode", SqlDbType.VarChar, 50).Value = txt_Storecode.Text
            '    cmd.Parameters.Add("@tuom", SqlDbType.VarChar, 50).Value = uom
            '    cmd.Parameters.Add("@currentgrnqty", SqlDbType.Float).Value = qty1
            '    cmd.Parameters.Add("@currentPurchaseRate", SqlDbType.Float).Value = (totalamount + totalothchg) / qty1
            '    cmd.Parameters.Add("@WeightedRate", SqlDbType.Float)
            '    cmd.Parameters.Add("@lastweightedrate", SqlDbType.Float)
            '    cmd.Parameters("@WeightedRate").Direction = ParameterDirection.Output

            '    cmd.Parameters("@lastweightedrate").Direction = ParameterDirection.Output
            '    gconnection.Myconn.Open()
            '    cmd.ExecuteReader()
            '    weightedrate = cmd.Parameters("@WeightedRate").Value
            '    lastweightedrate = cmd.Parameters("@lastWeightedRate").Value

            '    gconnection.Myconn.Close()
            'Catch ex As Exception
            '    MsgBox("Press OK for continule")
            '    gconnection.Myconn.Close()
            '    lastweightedrate = 0
            '    weightedrate = (totalamount + totalothchg) / qty1
            'End Try

            ''itemcode1 = AxfpSpread1.Text
            'sqlstring = "insert into ratelist(grnno,batchno,itemcode,uom,batchrate,grndate,weightedrate,lastweightedrate,storecode,adddate,adduser)"
            'sqlstring = sqlstring & " values ('" + txt_Grnno.Text + "',"
            'AxfpSpread1.Col = 14
            'sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            'AxfpSpread1.Col = 1
            'sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            'AxfpSpread1.Col = 3
            'sqlstring = sqlstring & "'" + AxfpSpread1.Text + "', "
            'AxfpSpread1.Col = 5
            'sqlstring = sqlstring & "'" + Format(Val((totalamount + totalothchg) / qty1), "0.000") + "' ,"
            'sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
            'sqlstring = sqlstring & "" & Format(Val(weightedrate), "0.000") & " , "
            'sqlstring = sqlstring & "" & Format(Val(lastweightedrate), "0.000") & " , "
            'sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',getDate(),'" & Trim(gUsername) & "')"
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = sqlstring
            'AxfpSpread1.Col = 1
            'sqlstring = " Select batchprocess from inv_inventoryitemmaster where itemcode='" + AxfpSpread1.Text + "' "
            'gconnection.getDataSet(sqlstring, "inv_inventoryitemmaster")
            'If (gdataset.Tables("inv_inventoryitemmaster").Rows.Count > 0) Then
            '    If (gdataset.Tables("inv_inventoryitemmaster").Rows(0).Item("batchprocess")) = "YES" Then
            '        '    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,TRNS_SEQ)"
            '    sqlstring = sqlstring & " values ('" + txt_Grnno.Text + "',"
            '    AxfpSpread1.Col = 1
            '    sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"


            '    AxfpSpread1.Col = 3
            '    sqlstring = sqlstring & "'" + STOCKUOM + "', "
            '    sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',"
            '    sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
            '    AxfpSpread1.Col = 4

            '    sqlstring = sqlstring & " " & Format(Val(0), "0.000") & ","

            '    sqlstring = sqlstring & "'" + Format(Val((totalamount + totalothchg) / qty1), "0.000") + "' ,"

            '    'AxfpSpread1.Col = 17
            '    'Dim fqty2 As Double
            '    'fqty2 = Val(AxfpSpread1.Text)
            '    AxfpSpread1.Col = 4
            '    'qty1 = Val(AxfpSpread1.Text) + fqty2

            '    sqlstring = sqlstring & " " & Format((qty1 / CONVVALUE) + (precise * qty1), "0.000") & ","
            '    sqlstring = sqlstring & " " & Format((qty1 / CONVVALUE) + (precise * qty1), "0.000") & ","

            '    sqlstring = sqlstring & "'" + Format(Val((totalamount + totalothchg)), "0.000") + "' ,"


            '    sqlstring = sqlstring & " 'Y',"
            '    sqlstring = sqlstring & "  'GRN', "
            '    AxfpSpread1.Col = 14
            '    sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'))"
            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring
            'Else
            Dim closingqty As Double
            Dim closingvalue As Double


            'sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue from closingqty where itemcode='" + itemcode1 + "' AND  storecode='" + txt_Storecode.Text + "'and trndate<='" + Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
            ' gconnection.getDataSet(sqlstring, "closingqty")'

            'gconnection.closingStock(Format(dtp_Prndate.Value, "dd/MMM/yyyy"), itemcode1, Trim(txt_Storecode.Text), "")
            'If (gdataset.Tables("closingstock").Rows.Count > 0) Then

            '    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
            '    closingvalue = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
            'End If
            'sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,TRNS_SEQ,rate)"
            'sqlstring = sqlstring & " values ('" + Txt_PRNNo.Text + "',"
            'AxfpSpread1.Col = 1
            'sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            'AxfpSpread1.Col = 3
            'sqlstring = sqlstring & "'" + uom + "', "
            'sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',"
            'sqlstring = sqlstring & " '" + Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") + "',"


            'sqlstring = sqlstring & " " & Format(Val(closingqty), "0.000") & ","

            'sqlstring = sqlstring & "'" + Format(Val(closingvalue), "0.000") + "' ,"
            'AxfpSpread1.Col = 4
            'sqlstring = sqlstring & " -" & Format(qty1, "0.000") & ","
            'sqlstring = sqlstring & " " & Format(closingqty - (qty1), "0.000") & ","

            'sqlstring = sqlstring & "'" + Format(Val(closingvalue - (totalamount + totalothchg)), "0.000") + "' ,"


            'sqlstring = sqlstring & " 'N',"
            'sqlstring = sqlstring & "  'PRN', "
            'AxfpSpread1.Col = 14
            'sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "')," & (totalamount + totalothchg) / qty1 & ")"
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = sqlstring



            ''Dim qty1 As Double
            ''Dim itemcode As String
            'Dim seq As Double


            'sqlstring = "update CLOSINGQTY set TRNS_SEQ=g.TRNS_SEQ from CLOSINGQTY c inner join Prn_details g on trnno='" + Txt_PRNNo.Text + "' where c.Itemcode='" + itemcode1 + "' and  c.Trndate= G.Prndate"
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = sqlstring
            'gconnection.MoreTrans(INSERT)
            'ReDim INSERT(0)
            'sqlstring = "Select getdate()"
            'gdate = gconnection.getvalue(sqlstring)
            'If (Format(CDate(gdate), "yyyy/MM/dd") > Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd")) Then
            '    Dim batchyn As String
            '    Dim AUTOID As Integer = 0
            '    'Dim closingqty As Double

            '    Dim Rate As Double
            '    sqlstring = "    update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end  ,"
            '    sqlstring = sqlstring & "  lastweightedrate="
            '    sqlstring = sqlstring & "  case when openningvalue=0 then"
            '    sqlstring = sqlstring & "      batchrate "
            '    sqlstring = sqlstring & "   Else"
            '    sqlstring = sqlstring & "  openningvalue/openningstock "
            '    sqlstring = sqlstring & "     End"
            '    sqlstring = sqlstring & "  from ratelist inner join CLOSINGQTY on ratelist.grnno=CLOSINGQTY.trnno where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
            '    sqlstring = sqlstring & "   and CLOSINGQTY.storecode='" + txt_Storecode.Text + "' and CLOSINGQTY.itemcode='" + itemcode1 + "'"

            '    gconnection.dataOperation(6, sqlstring, )
            'sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  itemcode='" + itemcode1 + "' "
            'sqlstring = sqlstring & " and Trnno='" + Txt_PRNNo.Text + "' "
            'gconnection.getDataSet(sqlstring, "closingqty")
            'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '    seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
            'End If
            '    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid from closingqty where itemcode='" + itemcode1 + "' and storecode='" + txt_Storecode.Text + "'and trndate<='" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "' order by trns_seq desc"
            '    gconnection.getDataSet(sqlstring, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '        AUTOID = Val(gdataset.Tables("closingqty").Rows(0).Item("AUTOID"))
            '        closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
            '        closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
            '    End If
            '    Dim sql1 As String = " select rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
            '    sql1 = sql1 & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" & itemcode1 & "' "
            '    gconnection.getDataSet(sql1, "ratelist2")
            '    If (gdataset.Tables("ratelist2").Rows.Count > 0) Then
            '        If (gdataset.Tables("ratelist2").Rows(0).Item("rateflag") = "W") Then
            '            Rate = weightedrate
            '        Else
            '            Rate = Val((totalamount + totalothchg) / qty1)
            '        End If
            '    End If

            'sqlstring = "update closingqty set openningstock= openningstock -" + Format(Val(qty1), "0.000") + " ,"
            ''    sqlstring = sqlstring & "  openningvalue="
            ''    sqlstring = sqlstring & "  CASE WHEN openningstock=0"
            ''    sqlstring = sqlstring & "  THEN"
            ''    sqlstring = sqlstring & "   '" + Format(Val((totalamount + totalothchg)), "0.000") + "' "
            ''    sqlstring = sqlstring & "    Else"

            ''    sqlstring = sqlstring & "  openningstock*" + Format(Val(Rate), "0.000") + ""
            ''    sqlstring = sqlstring & "    End,"
            'sqlstring = sqlstring & " closingstock= closingstock -" + Format(Val(qty1), "0.000") + " "
            ''    sqlstring = sqlstring & "  closingvalue="
            ''    sqlstring = sqlstring & "  CASE WHEN closingstock=0"
            ''    sqlstring = sqlstring & "  THEN "
            ''    sqlstring = sqlstring & "  0 "
            ''    sqlstring = sqlstring & "  Else"
            ''    sqlstring = sqlstring & "     closingstock *" + Format(Val(Rate), "0.000") + ""
            ''    sqlstring = sqlstring & "       End"

            'sqlstring = sqlstring & "  where trndate>'" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "'"
            'sqlstring = sqlstring & "   and trns_seq>" & seq.ToString() & " and itemcode='" + itemcode1 + "' and storecode='" + txt_Storecode.Text + "'"

            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = sqlstring
            ' gconnection.dataOperation(6, sqlstring, )

            '    sqlstring = "UPDATE closingqty SET  closingvalue=closingstock*(" + Format(Val(Rate), "0.000") + "),openningvalue=openningstock *" + Format(Val((Rate)), "0.000") + ""
            '    sqlstring = sqlstring & "  where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
            '    sqlstring = sqlstring & "   and trns_seq>" & seq.ToString() & " and itemcode='" + itemcode1 + "'"


            '    'If (batchyn = "Y") Then
            '    '    sqlstring = sqlstring & "  and  batchno='" + txt_Grnno.Text + "'"
            '    'End If
            '    gconnection.dataOperation(6, sqlstring, )






        Next



      


        If check = True Then
            gconnection.MoreTrans(INSERT)

            'If (GACCPOST.ToUpper() = "Y") Then
            '    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            '    gconnection.dataOperation(6, sqlstring, )
            '    Call accountPost()

            'End If

            'Dim seq As Double
            'For k As Integer = 1 To AxfpSpread1.DataRowCnt

            '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  itemcode='" + itemcode1 + "' "
            '    sqlstring = sqlstring & " and Trnno='" + Txt_PRNNo.Text + "'"
            '    gconnection.getDataSet(sqlstring, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '        seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
            '    End If


            '    AxfpSpread1.Col = 1
            '    gconnection.CalStockValue(txt_Storecode.Text, AxfpSpread1.Text, seq)



            'Next
        Else
            check = True
            Exit Sub
        End If
        'If (gdirissue = "Y") Then

        '    'Addissueoperation()

        'End If
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

    End Sub

    Private Sub accountPost()

        Dim sqlstring As String
        Dim INSERT(0) As String
        ''========================= POSTING FOR SPONSOR CREDIT===========================================
        'If Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then
        '    sqlstring = "Select * from SponsorAccountstagging where code='" & TXT_Sponsor.Text & "' AND  isnull(VOID,'')<>'Y'"
        '    gconnection.getDataSet(sqlstring, "CODE")
        '    If (gdataset.Tables("CODE").Rows.Count > 0) Then
        '        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
        '        acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
        '        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
        '        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
        '        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
        '        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

        '        If accode = "" Then

        '            MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING...")
        '            check = False
        '            Exit Sub

        '        End If
        '        If accode <> "" And costcode = "" Then

        '            MessageBox.Show("NO COST CENTRE CODE FOR SPON. POSTING...")
        '            check = False
        '            Exit Sub

        '        End If

        '        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
        '        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Prndate.Value, "dd/MMM/yyyy") & "', "
        '        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'PRN', '" & accode & "',"
        '        sqlstring = sqlstring & "'" & acdesc & "',"
        '        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
        '        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
        '        'sqlstring = sqlstring & "'CREDIT',"
        '        sqlstring = sqlstring & "'DEBIT',"
        '        amt = Format(Val(txt_Billamount.Text), "0.000")
        '        decription = "Purchase Return bill no " + txt_Supplierinvno.Text + " date " + dtp_Prndate.Text + ""
        '        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

        '        slcode = txt_Storecode.Text
        '        sqlstring = sqlstring & "'N')"
        '        ReDim Preserve INSERT(INSERT.Length)
        '        INSERT(INSERT.Length - 1) = sqlstring
        '    Else
        '        MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING. : '" & TXT_Sponsor.Text & "'")
        '        check = False
        '        Exit Sub
        '    End If




        '    sqlstring = "Select * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
        '    gconnection.getDataSet(sqlstring, "CODE")
        '    If (gdataset.Tables("CODE").Rows.Count > 0) Then
        '        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
        '        acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
        '        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
        '        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
        '        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
        '        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
        '        If accode = "" Then

        '            MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
        '            check = False
        '            Exit Sub


        '        End If
        '        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
        '        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Prndate.Value, "dd/MMM/yyyy") & "', "
        '        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'PRN', '" & accode & "',"
        '        sqlstring = sqlstring & "'" & acdesc & "',"
        '        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
        '        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
        '        'sqlstring = sqlstring & "'DEBIT',"
        '        sqlstring = sqlstring & "'CREDIT',"
        '        amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
        '        decription = "Purchase Return bill no " + txt_Supplierinvno.Text + " date " + dtp_Prndate.Text + ""
        '        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

        '        'slcode = txt_Storecode.Text
        '        sqlstring = sqlstring & "'N')"
        '        ReDim Preserve INSERT(INSERT.Length)
        '        INSERT(INSERT.Length - 1) = sqlstring
        '        If Val(txt_totaltax.Text) <> 0 Then
        '            sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
        '            gconnection.getDataSet(sqlstring, "CODE")
        '            If (gdataset.Tables("CODE").Rows.Count > 0) Then
        '                accode = gdataset.Tables("CODE").Rows(0).Item("TAXGLCODE")
        '                acdesc = gdataset.Tables("CODE").Rows(0).Item("TAXGLDESC")
        '                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
        '                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
        '                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
        '                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
        '                If accode = "" Then
        '                    MessageBox.Show("NO GL FOUND FOR TAX POSTING")
        '                    check = False
        '                    Exit Sub
        '                End If

        '                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
        '                sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Prndate.Value, "dd/MMM/yyyy") & "', "
        '                sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'PRN', '" & accode & "',"
        '                sqlstring = sqlstring & "'" & acdesc & "',"
        '                sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
        '                sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
        '                'sqlstring = sqlstring & "'DEBIT',"
        '                sqlstring = sqlstring & "'CREDIT',"
        '                amt = Format(Val(txt_totaltax.Text), "0.000")
        '                decription = "Purchase Return bill no " + txt_Supplierinvno.Text + " date " + dtp_Prndate.Text + ""
        '                sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

        '                slcode = txt_Storecode.Text
        '                sqlstring = sqlstring & "'N')"
        '                ReDim Preserve INSERT(INSERT.Length)
        '                INSERT(INSERT.Length - 1) = sqlstring
        '            Else
        '                MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
        '                check = False
        '                Exit Sub
        '            End If
        '        End If

        '    Else
        '        MessageBox.Show("CREATE SLCODE FOR SUPPLIER IN ACCOUNTSSUBLEDGERMASTER...")
        '        check = False
        '        Exit Sub
        '    End If
        'Else
        '    '====================== POSTING FOR SUPPLIER (CREDIT)==========================
        '    sqlstring = "select slcode, sldesc,ACCODE,ACDESC from accountssubledgermaster  WHERE "
        '    sqlstring = sqlstring & "SLCODE='" & txt_Suppliercode.Text & "' AND SLNAME='" & txt_Suppliername.Text & "' AND  isnull(freezeflag,'')<>'Y'  and accode in( select ScrsCode from ACCOUNTSSETUP)"
        '    gconnection.getDataSet(sqlstring, "SLCODE1")

        '    If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
        '        accode = gdataset.Tables("SLCODE1").Rows(0).Item("ACCODE")
        '        slcode = gdataset.Tables("SLCODE1").Rows(0).Item("SLCODE")
        '        sldesc = gdataset.Tables("SLCODE1").Rows(0).Item("SLDESC")
        '        acdesc = gdataset.Tables("SLCODE1").Rows(0).Item("ACDESC")
        '    Else
        '        MessageBox.Show("CREATE SLCODE FOR SUPPLIER IN ACCOUNTSSUBLEDGERMASTER...")
        '        check = False
        '        Exit Sub
        '    End If
        '    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID)"
        '    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Prndate.Value, "dd/MMM/yyyy") & "', "
        '    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'PRN', '" & accode & "',"
        '    sqlstring = sqlstring & "'" & acdesc & "',"
        '    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
        '    ' sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
        '    'sqlstring = sqlstring & "'CREDIT',"
        '    sqlstring = sqlstring & "'DEBIT',"
        '    amt = Format(Val(txt_Billamount.Text), "0.000")
        '    decription = "Purchase Return bill no " + txt_Supplierinvno.Text + " date " + dtp_Prndate.Text + ""
        '    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

        '    slcode = txt_Storecode.Text
        '    sqlstring = sqlstring & "'N')"
        '    ReDim Preserve INSERT(INSERT.Length)
        '    INSERT(INSERT.Length - 1) = sqlstring



        '    sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
        '    gconnection.getDataSet(sqlstring, "CODE")
        '    If (gdataset.Tables("CODE").Rows.Count > 0) Then
        '        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
        '        acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
        '        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
        '        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
        '        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
        '        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
        '        If accode = "" Then
        '            MessageBox.Show("NO GL FOUND FOR STOCK POSTING")
        '            check = False
        '            Exit Sub
        '        End If
        '        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
        '        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Prndate.Value, "dd/MMM/yyyy") & "', "
        '        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'PRN', '" & accode & "',"
        '        sqlstring = sqlstring & "'" & acdesc & "',"
        '        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
        '        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
        '        ' sqlstring = sqlstring & "'DEBIT',"
        '        sqlstring = sqlstring & "'CREDIT',"
        '        amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
        '        decription = "Purchase Return bill no " + txt_Supplierinvno.Text + " date " + dtp_Prndate.Text + ""
        '        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

        '        'slcode = txt_Storecode.Text
        '        sqlstring = sqlstring & "'N')"
        '        ReDim Preserve INSERT(INSERT.Length)
        '        INSERT(INSERT.Length - 1) = sqlstring
        '        If Val(txt_totaltax.Text) <> 0 Then
        '            sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
        '            gconnection.getDataSet(sqlstring, "CODE")
        '            If (gdataset.Tables("CODE").Rows.Count > 0) Then
        '                accode = gdataset.Tables("CODE").Rows(0).Item("TAXGLCODE")
        '                acdesc = gdataset.Tables("CODE").Rows(0).Item("TAXGLDESC")
        '                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
        '                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
        '                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
        '                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
        '                If accode = "" Then
        '                    MessageBox.Show("NO GL FOUND FOR TAX POSTING")
        '                    check = False
        '                    Exit Sub
        '                End If

        '                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
        '                sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Prndate.Value, "dd/MMM/yyyy") & "', "
        '                sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'PRN', '" & accode & "',"
        '                sqlstring = sqlstring & "'" & acdesc & "',"
        '                sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
        '                sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
        '                'sqlstring = sqlstring & "'DEBIT',"
        '                sqlstring = sqlstring & "'CREDIT',"
        '                amt = Format(Val(txt_totaltax.Text), "0.000")
        '                decription = "Purchase Return bill no " + txt_Supplierinvno.Text + " date " + dtp_Prndate.Text + ""
        '                sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

        '                slcode = txt_Storecode.Text
        '                sqlstring = sqlstring & "'N')"
        '                ReDim Preserve INSERT(INSERT.Length)
        '                INSERT(INSERT.Length - 1) = sqlstring
        '            Else
        '                MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
        '                check = False
        '                Exit Sub
        '            End If
        '        End If

        '    End If

        'End If

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
                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                        sqlstring = sqlstring & "'" & acdesc & "',"
                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        ' sqlstring = sqlstring & "'CREDIT',"
                        sqlstring = sqlstring & "'DEBIT',"
                        'amt = Format(Val(txt_Billamount.Text), "0.000")
                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = sqlstring
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
                            ' sqlstring = sqlstring & "'DEBIT',"
                            sqlstring = sqlstring & "'CREDIT',"
                            amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                            sqlstring = sqlstring & "'" & amount & "','" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = sqlstring
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
                    ' sqlstring = sqlstring & "'DEBIT',"
                    sqlstring = sqlstring & "'CREDIT',"
                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    'slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
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
                    ' sqlstring = sqlstring & "'DEBIT',"
                    sqlstring = sqlstring & "'CREDIT',"
                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    'slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
                Else
                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                    check = False
                    Exit Sub
                End If




            End If

            'sqlstring = "Select * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
            'gconnection.getDataSet(sqlstring, "CODE")
            ''If (gdataset.Tables("CODE").Rows.Count > 0) Then
            'accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
            'acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
            'slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
            'sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
            'costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
            'costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
            'If accode = "" Then

            '    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
            '    check = False
            '    Exit Sub


            'End If
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

                'If UCase(gShortname) = "BRC" Then
                '    Dim amount, POSTAMT As Double
                '    For k As Integer = 1 To AxfpSpread1.DataRowCnt
                '        AxfpSpread1.Row = k

                '        AxfpSpread1.Col = 9
                '        amount = Val(AxfpSpread1.Text)

                '        AxfpSpread1.Col = 10
                '        If Trim(AxfpSpread1.Text) <> "" Then
                '            sqlstring = "Select  * from invtaxgroupmasterdetail where taxgroupcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'"
                '            gconnection.getDataSet(sqlstring, "invtaxgroupmasterdetail")
                '            If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then



                '                For Z As Integer = 0 To gdataset.Tables("invtaxgroupmasterdetail").Rows.Count - 1
                '                    POSTAMT = (amount * Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAXPER"))) / 100

                '                    sqlstring = "select * from TaxAccountstagging where TaxCode='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "' AND ISNULL(VOID,'N')<>'Y'"
                '                    gconnection.getDataSet(sqlstring, "TaxAccountstagging")



                '                    If (gdataset.Tables("TaxAccountstagging").Rows.Count > 0) Then

                '                        accode = gdataset.Tables("TaxAccountstagging").Rows(0).Item("GLACCOUNTCODE")
                '                        acdesc = gdataset.Tables("TaxAccountstagging").Rows(0).Item("GLACCOUNTDESC")
                '                        slcode = gdataset.Tables("TaxAccountstagging").Rows(0).Item("slcode")
                '                        sldesc = gdataset.Tables("TaxAccountstagging").Rows(0).Item("sldesc")
                '                        costcode = ""
                '                        costdesc = ""
                '                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                '                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                '                        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                '                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                '                        sqlstring = sqlstring & "'" & acdesc & "',"
                '                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                '                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                '                        sqlstring = sqlstring & "'DEBIT',"
                '                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                '                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                '                        sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                '                        slcode = txt_Storecode.Text
                '                        sqlstring = sqlstring & "'N')"
                '                        ReDim Preserve INSERT(INSERT.Length)
                '                        INSERT(INSERT.Length - 1) = sqlstring


                '                    Else
                '                        MessageBox.Show("NO GL A/C FOUND FOR " + Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("taxcode")) + " TAXCODE")
                '                        check = False
                '                        Exit Sub
                '                    End If
                '                Next Z
                '            Else
                '                MessageBox.Show("TAX GROUP NOT FOUND")
                '                check = False
                '                Exit Sub
                '            End If
                '        End If



                '    Next
                'Else


                'sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                'gconnection.getDataSet(sqlstring, "CODE")
                'If (gdataset.Tables("CODE").Rows.Count > 0) Then
                '    accode = gdataset.Tables("CODE").Rows(0).Item("TAXGLCODE")
                '    acdesc = gdataset.Tables("CODE").Rows(0).Item("TAXGLDESC")
                '    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                '    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                '    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                '    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                '    If accode = "" Then
                '        MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                '        check = False
                '        Exit Sub
                '    End If

                '    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                '    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                '    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                '    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                '    sqlstring = sqlstring & "'" & acdesc & "',"
                '    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                '    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                '    sqlstring = sqlstring & "'DEBIT',"
                '    amt = Format(Val(txt_totaltax.Text), "0.000")
                '    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                '    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                '    slcode = txt_Storecode.Text
                '    sqlstring = sqlstring & "'N')"
                '    ReDim Preserve INSERT(INSERT.Length)
                '    INSERT(INSERT.Length - 1) = sqlstring
                'Else
                '    MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                '    check = False
                '    Exit Sub
                'End If

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
                                        ' sqlstring = sqlstring & "'DEBIT',"
                                        sqlstring = sqlstring & "'CREDIT',"
                                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                        sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                        slcode = txt_Storecode.Text
                                        sqlstring = sqlstring & "'N')"
                                        ReDim Preserve INSERT(INSERT.Length)
                                        INSERT(INSERT.Length - 1) = sqlstring
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
                                    ' sqlstring = sqlstring & "'DEBIT',"
                                    sqlstring = sqlstring & "'CREDIT',"
                                    'amt = Format(Val(txt_totaltax.Text), "0.000")
                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                    sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                    slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N')"
                                    ReDim Preserve INSERT(INSERT.Length)
                                    INSERT(INSERT.Length - 1) = sqlstring

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
                                sqlstring = "Select  * from invtaxgroupmasterdetail where taxgroupcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'  "
                                gconnection.getDataSet(sqlstring, "invtaxgroupmasterdetail")
                                If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then



                                    For Z As Integer = 0 To gdataset.Tables("invtaxgroupmasterdetail").Rows.Count - 1
                                        POSTAMT = (amount * Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAXPER"))) / 100

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
                                            ' sqlstring = sqlstring & "'DEBIT',"
                                            sqlstring = sqlstring & "'CREDIT',"
                                            'amt = Format(Val(txt_totaltax.Text), "0.000")
                                            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                            sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                            slcode = txt_Storecode.Text
                                            sqlstring = sqlstring & "'N')"
                                            ReDim Preserve INSERT(INSERT.Length)
                                            INSERT(INSERT.Length - 1) = sqlstring


                                        Else
                                            MessageBox.Show("NO GL A/C FOUND FOR " + Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("taxcode")) + " TAXCODE")
                                            check = False
                                            Exit Sub
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
            ' sqlstring = sqlstring & "'CREDIT',"
            sqlstring = sqlstring & "'DEBIT',"
            amt = Format(Val(txt_Billamount.Text), "0.000")
            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
            sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

            slcode = txt_Storecode.Text
            sqlstring = sqlstring & "'N')"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
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
                            ' sqlstring = sqlstring & "'DEBIT',"
                            sqlstring = sqlstring & "'CREDIT',"
                            amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                            sqlstring = sqlstring & "'" & amount & "','" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = sqlstring
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
                    'sqlstring = sqlstring & "'DEBIT',"
                    sqlstring = sqlstring & "'CREDIT',"
                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    'slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
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
                    'sqlstring = sqlstring & "'DEBIT',"
                    sqlstring = sqlstring & "'CREDIT',"
                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    'slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
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
                                        ' sqlstring = sqlstring & "'DEBIT',"
                                        sqlstring = sqlstring & "'CREDIT',"
                                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                        sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                        slcode = txt_Storecode.Text
                                        sqlstring = sqlstring & "'N')"
                                        ReDim Preserve INSERT(INSERT.Length)
                                        INSERT(INSERT.Length - 1) = sqlstring
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
                                    '  sqlstring = sqlstring & "'DEBIT',"
                                    sqlstring = sqlstring & "'CREDIT',"
                                    'amt = Format(Val(txt_totaltax.Text), "0.000")
                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                    sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                    slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N')"
                                    ReDim Preserve INSERT(INSERT.Length)
                                    INSERT(INSERT.Length - 1) = sqlstring

                                End If
                            End If
                        Else
                            amount = 0
                            POSTAMT = 0
                            AxfpSpread1.Col = 9
                            amount = Val(AxfpSpread1.Text)

                            AxfpSpread1.Col = 10
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "Select  * from invtaxgroupmasterdetail where taxgroupcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'"
                                gconnection.getDataSet(sqlstring, "invtaxgroupmasterdetail")
                                If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then



                                    For Z As Integer = 0 To gdataset.Tables("invtaxgroupmasterdetail").Rows.Count - 1
                                        POSTAMT = (amount * Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAXPER"))) / 100

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
                                            ' sqlstring = sqlstring & "'DEBIT',"
                                            sqlstring = sqlstring & "'CREDIT',"
                                            'amt = Format(Val(txt_totaltax.Text), "0.000")
                                            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                            sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                            slcode = txt_Storecode.Text
                                            sqlstring = sqlstring & "'N')"
                                            ReDim Preserve INSERT(INSERT.Length)
                                            INSERT(INSERT.Length - 1) = sqlstring


                                        Else
                                            MessageBox.Show("NO GL A/C FOUND FOR " + Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) + " TAXCODE")
                                            check = False
                                            Exit Sub
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









        gconnection.MoreTrans1(INSERT)
    End Sub
    Private Sub autogenerateissue()
        Try
            Dim sqlstring, financalyear As String
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            Dim docno As String
            sqlstring = "SELECT MAX(SUBSTRING(docno,1,5)) FROM stockissueheader WHERE doctype='ISSUE'"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            docno = "ISSUE"
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
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    '    Private Sub Addissueoperation()
    '        Dim docno1() As String
    '        Dim docno2() As String
    '        Dim insert(0) As String
    '        Dim sqlstring As String
    '        Dim itemcode As String
    '        Dim financalyear As String
    '        Dim docno As String
    '        docno = "ISSUE"
    '        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)

    '        Dim i As Integer
    '        If Cmd_Add.Text = "Add [F7]" Then
    '            autogenerateissue()
    '            sqlstring = " Select distinct(directissueing.storecode) as storecode,storedesc  from directissueing inner join storemaster "
    '            sqlstring = sqlstring & "   on storemaster.Storecode=directissueing.storecode"
    '            gconnection.getDataSet(sqlstring, "directissueing")
    '            If (gdataset.Tables("directissueing").Rows.Count > 0) Then
    '                docno1 = Split(Trim(issuedocno), "/")
    '                For m As Integer = 0 To gdataset.Tables("directissueing").Rows.Count - 1

    '                    issuedocno = docno & "/" & Format(Val(docno1(1)) + m, "00000") & "/" & financalyear
    '                    docno2 = Split(Trim(issuedocno), "/")
    '                    sqlstring = "INSERT INTO STOCKISSUEHEADER(Docno,Docdetails,Doctype,Docdate,IndentNo,Storelocationcode,Storelocationname, "
    '                    sqlstring = sqlstring & " Opstorelocationcode, Opstorelocationname, Remarks,Void,VoidReason,Adduser,Adddate,Updateuser,Updatetime)"
    '                    sqlstring = sqlstring & " VALUES ('" & CStr(docno2(1)) & "','" & Trim(issuedocno) & "','ISSUE',"
    '                    'sqlstring = sqlstring & " VALUES ('" & Trim(txt_Docno.Text) & "','" & Trim(txt_Docno.Text) & "','" & Trim(docno) & "',"
    '                    sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd-MMM-yyyy") & "','',"
    '                    sqlstring = sqlstring & " '" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "','" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storecode")) & "', "
    '                    sqlstring = sqlstring & "  '" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storedesc")) & "' ,"
    '                    sqlstring = sqlstring & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,'N','" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "',"
    '                    sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "',"
    '                    sqlstring = sqlstring & " '','" & Format(Now, "dd-MMM-yyyy") & "'"
    '                    sqlstring = sqlstring & " )"

    '                    ReDim Preserve insert(insert.Length)
    '                    insert(insert.Length - 1) = sqlstring


    '                    sqlstring = " select itemcode,itemname,uom,quantity,Storecode from  directissueing "
    '                    sqlstring = sqlstring & "   where storecode='" + gdataset.Tables("directissueing").Rows(m).Item("Storecode") + "'"
    '                    gconnection.getDataSet(sqlstring, "StoreMaster")
    '                    If (gdataset.Tables("StoreMaster").Rows.Count > 0) Then
    '                        Dim rate As Double
    '                        '  issuedocno = docno & "/00001/" & financalyear


    '                        For l As Integer = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
    '                            Dim sql As String = "select weightedrate,batchrate  from ratelist where Itemcode='" + gdataset.Tables("StoreMaster").Rows(l).Item("itemcode") + "' and grnno='" + txt_Grnno.Text + "'"
    '                            gconnection.getDataSet(sql, "ratelist")
    '                            If (gdataset.Tables("ratelist").Rows.Count > 0) Then
    '                                Dim sql1 As String = " select rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
    '                                sql1 = sql1 & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" + gdataset.Tables("StoreMaster").Rows(l).Item("itemcode") + "' "
    '                                gconnection.getDataSet(sql1, "ratelist2")
    '                                If (gdataset.Tables("ratelist2").Rows.Count > 0) Then
    '                                    If (gdataset.Tables("ratelist2").Rows(0).Item("rateflag") = "W") Then
    '                                        rate = Format(Val(gdataset.Tables("ratelist").Rows(0).Item("weightedrate")), "0.000")

    '                                    ElseIf (gdataset.Tables("ratelist2").Rows(0).Item("rateflag") = "P") Then
    '                                        rate = Format(Val(gdataset.Tables("ratelist").Rows(0).Item("batchrate")), "0.000")

    '                                    Else
    '                                        AxfpSpread1.Col = 5
    '                                        rate = Val(AxfpSpread1.Text)
    '                                    End If
    '                                End If
    '                            Else
    '                                AxfpSpread1.Col = 4
    '                                Dim q As Double = Val(AxfpSpread1.Text)
    '                                AxfpSpread1.Col = 9
    '                                rate = Val(AxfpSpread1.Text) / q
    '                            End If

    '                            sqlstring = "INSERT INTO STOCKISSUEDETAIL(Docno,Docdetails,Docdate,IndentNo,Storelocationcode,Storelocationname,"
    '                            sqlstring = sqlstring & " Opstorelocationcode,Opstorelocationname,Itemcode,Itemname,Uom,IND_QTY,Qty,batchno,rate,amount,"
    '                            sqlstring = sqlstring & " Void,Adduser,adddatetime,Updateuser,Updatetime,TRNS_SEQ)"
    '                            sqlstring = sqlstring & " VALUES ('" & Trim(issuedocno) & "','" & Trim(issuedocno) & "',"
    '                            sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd-MMM-yyyy") & "',"
    '                            sqlstring = sqlstring & " '',"
    '                            sqlstring = sqlstring & " '" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "', "
    '                            sqlstring = sqlstring & " '" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storecode")) & "','" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storedesc")) & "',"
    '                            'AxfpSpread1.Row = i
    '                            'AxfpSpread1.Col = 1
    '                            itemcode = gdataset.Tables("StoreMaster").Rows(l).Item("itemcode")
    '                            sqlstring = sqlstring & "'" & Trim(itemcode) & "',"
    '                            sqlstring = sqlstring & "'" & Trim(gdataset.Tables("StoreMaster").Rows(l).Item("itemname")) & "',"
    '                            sqlstring = sqlstring & "'" & Trim(gdataset.Tables("StoreMaster").Rows(l).Item("uom")) & "',"
    '                            sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","

    '                            Dim qty As Double = Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))
    '                            sqlstring = sqlstring & "" & Format(Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")), "0.000") & ","


    '                            sqlstring = sqlstring & "'" & txt_Grnno.Text & "',"
    '                            sqlstring = sqlstring & "'" + Format(Val(rate), "0.000") + "',"
    '                            sqlstring = sqlstring & "'" + Format(Val(rate * Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))), "0.000") + "',"
    '                            sqlstring = sqlstring & "'N',"
    '                            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "',"
    '                            sqlstring = sqlstring & " ' ','" & Format(Now, "dd-MMM-yyyy") & "',"
    ')"
    '                            ReDim Preserve insert(insert.Length)
    '                            insert(insert.Length - 1) = sqlstring
    '                            Dim closingqty As Double
    '                            Dim closingvalue As Double
    '                            Dim closingqty1 As Double
    '                            Dim closingvalue1 As Double
    '                            Dim UOM As String
    '                            Dim uom1 As String
    '                            Dim convvalue As Double
    '                            Dim precise As Double
    '                            sqlstring = " Select batchprocess from inv_inventoryitemmaster where itemcode='" + itemcode + "' "
    '                            gconnection.getDataSet(sqlstring, "inv_inventoryitemmaster")
    '                            If (gdataset.Tables("inv_inventoryitemmaster").Rows.Count > 0) Then
    '                                If (gdataset.Tables("inv_inventoryitemmaster").Rows(0).Item("batchprocess")) = "YES" Then
    '                                    Dim batchno As String
    '                                    batchno = txt_Grnno.Text
    '                                    UOM = gdataset.Tables("StoreMaster").Rows(l).Item("uom")
    '                                    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'   and batchno='" + batchno + "' and trndate<'" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
    '                                    gconnection.getDataSet(sqlstring, "closingqty")
    '                                    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
    '                                        uom1 = gdataset.Tables("closingqty").Rows(0).Item("uom")
    '                                        Dim sql2 As String = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
    '                                        gconnection.getDataSet(sql2, "INVENTORY_TRANSCONVERSION")
    '                                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
    '                                            convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
    '                                            precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))
    '                                        Else
    '                                            MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + UOM, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

    '                                        End If

    '                                        closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
    '                                        closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
    '                                    Else
    '                                        closingqty = 0
    '                                        convvalue = 1
    '                                    End If
    '                                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock ,closingvalue,batchyn,ttype,batchno,TRNS_SEQ)"
    '                                    sqlstring = sqlstring & " values ('" + issuedocno + "',"
    '                                    AxfpSpread1.Col = 1
    '                                    sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
    '                                    AxfpSpread1.Col = 3
    '                                    sqlstring = sqlstring & "'" + uom1 + "', "
    '                                    sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',"
    '                                    sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
    '                                    AxfpSpread1.Col = 5

    '                                    sqlstring = sqlstring & " " & Format(Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")), "0.000") & ","

    '                                    sqlstring = sqlstring & "'" + Format(Val(rate * Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))), "0.000") + "' ,"
    '                                    AxfpSpread1.Col = 5
    '                                    sqlstring = sqlstring & " " & Format((Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) / convvalue) + (precise * Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))) * -1, "0.000") & ","
    '                                    sqlstring = sqlstring & " " & Format(Val(0), "0.000") & ","

    '                                    sqlstring = sqlstring & "'" + Format(Val(0), "0.000") + "' ,"


    '                                    sqlstring = sqlstring & " 'Y',"

    '                                    sqlstring = sqlstring & "  'ISSUE', "



    '                                    sqlstring = sqlstring & "  '" + txt_Grnno.Text + "'," & Seq.ToString() & ")"
    '                                    ReDim Preserve insert(insert.Length)
    '                                    insert(insert.Length - 1) = sqlstring
    '                                    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS  closingstock,closingvalue,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + gdataset.Tables("directissueing").Rows(m).Item("storecode") + "'   and batchno='" + batchno + "' and trndate<='" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
    '                                    gconnection.getDataSet(sqlstring, "closingqty")
    '                                    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
    '                                        uom1 = gdataset.Tables("closingqty").Rows(0).Item("uom")
    '                                        Dim sql2 As String = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
    '                                        gconnection.getDataSet(sql2, "INVENTORY_TRANSCONVERSION")
    '                                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
    '                                            convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
    '                                            precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))
    '                                        Else
    '                                            MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + UOM, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

    '                                        End If

    '                                        closingqty1 = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
    '                                        closingvalue1 = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
    '                                    Else
    '                                        convvalue = 1
    '                                        closingqty1 = 0
    '                                        closingvalue1 = 0
    '                                    End If
    '                                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,TRNS_SEQ)"
    '                                    sqlstring = sqlstring & " values ('" + issuedocno + "',"
    '                                    sqlstring = sqlstring & "'" + itemcode + "',"
    '                                    sqlstring = sqlstring & "'" + uom1 + "', "
    '                                    sqlstring = sqlstring & "  '" + gdataset.Tables("directissueing").Rows(m).Item("storecode") + "',"
    '                                    sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
    '                                    AxfpSpread1.Col = 5

    '                                    sqlstring = sqlstring & " " & Format(Val(closingqty1), "0.000") & ","

    '                                    sqlstring = sqlstring & "'" + Format(Val(closingvalue1), "0.000") + "' ,"
    '                                    AxfpSpread1.Col = 5
    '                                    sqlstring = sqlstring & " " & Format(((Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) / convvalue) + (Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) * precise)) * 1, "0.000") & ","
    '                                    sqlstring = sqlstring & " " & Format(Val(closingqty1) + ((Val((gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) / convvalue) + (Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) * precise)) * 1), "0.000") & ","

    '                                    sqlstring = sqlstring & "'" + Format(Format(closingvalue + Val(rate * Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))), "0.000"), "0.000") + "' ,"


    '                                    sqlstring = sqlstring & " 'Y',"
    '                                    sqlstring = sqlstring & "  'RECEIEVE', "
    '                                    AxfpSpread1.Col = 6
    '                                    sqlstring = sqlstring & "  '" + txt_Grnno.Text + "'," & Seq.ToString() & ")"
    '                                    ReDim Preserve insert(insert.Length)
    '                                    insert(insert.Length - 1) = sqlstring



    '                                Else

    '                                    UOM = gdataset.Tables("StoreMaster").Rows(l).Item("uom")
    '                                    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock, closingvalue,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'and trndate<='" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
    '                                    gconnection.getDataSet(sqlstring, "closingqty")
    '                                    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
    '                                        uom1 = gdataset.Tables("closingqty").Rows(0).Item("uom")
    '                                        Dim sql2 As String = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
    '                                        gconnection.getDataSet(sql2, "INVENTORY_TRANSCONVERSION")
    '                                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
    '                                            convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
    '                                            precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))
    '                                        Else

    '                                            MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + UOM, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '                                            convvalue = 1
    '                                            precise = 0

    '                                        End If

    '                                        closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
    '                                        closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
    '                                    Else
    '                                        sqlstring = "select stockuom from  INV_InventoryItemMaster where itemcode='" + itemcode + "' "
    '                                        gconnection.getDataSet(sqlstring, "closingqty")
    '                                        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
    '                                            uom1 = gdataset.Tables("closingqty").Rows(0).Item("stockuom")

    '                                            Dim sql2 As String = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
    '                                            gconnection.getDataSet(sql2, "INVENTORY_TRANSCONVERSION")
    '                                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
    '                                                convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
    '                                                precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))
    '                                            Else

    '                                                MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + UOM, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)


    '                                            End If

    '                                            closingqty = 0
    '                                            closingvalue = 0
    '                                        End If

    '                                    End If
    '                                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,TRNS_SEQ)"
    '                                    sqlstring = sqlstring & " values ('" + issuedocno + "',"
    '                                    AxfpSpread1.Col = 1
    '                                    sqlstring = sqlstring & "'" + gdataset.Tables("StoreMaster").Rows(l).Item("ITEMCODE") + "',"
    '                                    AxfpSpread1.Col = 3
    '                                    sqlstring = sqlstring & "'" + uom1 + "', "
    '                                    sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',"
    '                                    sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"


    '                                    sqlstring = sqlstring & " " & Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) & ","

    '                                    sqlstring = sqlstring & "'" + Format(Val(rate * Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))), "0.000") + "' ,"
    '                                    AxfpSpread1.Col = 5
    '                                    sqlstring = sqlstring & " " & Format(((Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) / convvalue) + Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) * precise) * -1, "0.000") & ","
    '                                    sqlstring = sqlstring & " " & Format(Val(0), "0.000") & ","

    '                                    sqlstring = sqlstring & "'" + Format(Format(Val(0), "0.000"), "0.000") + "' ,"


    '                                    sqlstring = sqlstring & " 'N',"
    '                                    'If (costcenterflag = True) Then
    '                                    '    sqlstring = sqlstring & "  'Consume', "

    '                                    'Else
    '                                    sqlstring = sqlstring & "  'ISSUE', "

    '                                    '  End If
    '                                    AxfpSpread1.Col = 6
    '                                    sqlstring = sqlstring & "  '" + txt_Grnno.Text + "'," & Seq.ToString() & ")"
    '                                    ReDim Preserve insert(insert.Length)
    '                                    insert(insert.Length - 1) = sqlstring
    '                                    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS  closingstock,closingvalue,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + gdataset.Tables("directissueing").Rows(m).Item("storecode") + "'    and trndate<='" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
    '                                    gconnection.getDataSet(sqlstring, "closingqty")
    '                                    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
    '                                        uom1 = gdataset.Tables("closingqty").Rows(0).Item("uom")
    '                                        Dim sql1 As String = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
    '                                        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
    '                                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
    '                                            convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
    '                                            precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))
    '                                        Else
    '                                            MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + UOM, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

    '                                        End If

    '                                        closingqty1 = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
    '                                        closingvalue1 = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
    '                                    Else
    '                                        convvalue = 1
    '                                        closingqty1 = 0
    '                                        closingvalue1 = 0
    '                                    End If
    '                                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,TRNS_SEQ)"
    '                                    sqlstring = sqlstring & " values ('" + issuedocno + "',"
    '                                    AxfpSpread1.Col = 1
    '                                    sqlstring = sqlstring & "'" + itemcode + "',"
    '                                    AxfpSpread1.Col = 3
    '                                    sqlstring = sqlstring & "'" + uom1 + "', "
    '                                    sqlstring = sqlstring & "  '" + gdataset.Tables("directissueing").Rows(m).Item("storecode") + "',"
    '                                    sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
    '                                    AxfpSpread1.Col = 5

    '                                    sqlstring = sqlstring & " " & Format(Val(closingqty1), "0.000") & ","

    '                                    sqlstring = sqlstring & "'" + Format(Val(closingvalue1), "0.000") + "' ,"
    '                                    AxfpSpread1.Col = 5
    '                                    sqlstring = sqlstring & " " & Format(((Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) / convvalue) + (Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) * precise)) * 1, "0.000") & ","
    '                                    sqlstring = sqlstring & " " & Format(Val(closingqty1) + ((Val((gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) / convvalue) + (Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity")) * precise)) * 1), "0.000") & ","

    '                                    sqlstring = sqlstring & "'" + Format(closingvalue1 + Val(rate * Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))), "0.000") + "' ,"


    '                                    sqlstring = sqlstring & " 'N',"
    '                                    sqlstring = sqlstring & "  'RECEIEVE', "
    '                                    AxfpSpread1.Col = 6
    '                                    sqlstring = sqlstring & "  '" + txt_Grnno.Text + "'," & Seq.ToString() & ")"
    '                                    ReDim Preserve insert(insert.Length)
    '                                    insert(insert.Length - 1) = sqlstring
    '                                End If

    '                            End If


    '                            If (GACCPOST.ToUpper() = "Y") Then


    '                                Dim TOTALISSUEQTY As Decimal
    '                                sqlstring = " select sum(Quantity) AS Quantity FROM directissueing "
    '                                gconnection.getDataSet(sqlstring, "TOTALISSUEQTY")
    '                                If (gdataset.Tables("TOTALISSUEQTY").Rows.Count > 0) Then
    '                                    TOTALISSUEQTY = gdataset.Tables("TOTALISSUEQTY").Rows(0).Item("Quantity")
    '                                End If



    '                                sqlstring = "Select  * from AccountstaggingNEW where code='" & Trim(gdataset.Tables("directissueing").Rows(m).Item("storecode")) & "' AND ISNULL(VOID,'')<>'Y'"
    '                                gconnection.getDataSet(sqlstring, "CODE")
    '                                If (gdataset.Tables("CODE").Rows.Count > 0) Then
    '                                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
    '                                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
    '                                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
    '                                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
    '                                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
    '                                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
    '                                    If accode = "" Then

    '                                        MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
    '                                        check = False
    '                                        Exit Sub


    '                                    End If
    '                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
    '                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
    '                                    sqlstring = sqlstring & " VALUES('" & Trim(issuedocno) & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
    '                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
    '                                    sqlstring = sqlstring & "'" & acdesc & "',"
    '                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
    '                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
    '                                    sqlstring = sqlstring & "'DEBIT',"


    '                                    'Dim qty As Double = Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))
    '                                    If Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then
    '                                        'amt = Format((Val((txt_Billamount.Text)) / TOTALISSUEQTY) * qty, "0.000")
    '                                        amt = Format(rate * qty, "0.000")
    '                                    Else
    '                                        'amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text)) / TOTALISSUEQTY) * qty, "0.000")
    '                                        amt = Format(rate * qty, "0.000")
    '                                    End If

    '                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
    '                                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

    '                                    'slcode = txt_Storecode.Text
    '                                    sqlstring = sqlstring & "'N')"
    '                                    ReDim Preserve insert(insert.Length)
    '                                    insert(insert.Length - 1) = sqlstring
    '                                Else
    '                                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...:-'" & txt_Storecode.Text & "'")
    '                                    Exit Sub
    '                                End If


    '                                sqlstring = "Select  * from AccountstaggingNew where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
    '                                gconnection.getDataSet(sqlstring, "CODE")
    '                                If (gdataset.Tables("CODE").Rows.Count > 0) Then
    '                                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
    '                                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
    '                                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
    '                                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
    '                                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
    '                                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
    '                                    If accode = "" Then

    '                                        MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
    '                                        check = False
    '                                        Exit Sub


    '                                    End If
    '                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
    '                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
    '                                    sqlstring = sqlstring & " VALUES('" & Trim(issuedocno) & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
    '                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
    '                                    sqlstring = sqlstring & "'" & acdesc & "',"
    '                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
    '                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
    '                                    sqlstring = sqlstring & "'CREDIT',"

    '                                    If Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then
    '                                        ' amt = Format(Val((txt_Billamount.Text)), "0.000")
    '                                        amt = Format(rate * qty, "0.000")
    '                                    Else
    '                                        amt = Format(rate * qty, "0.000")
    '                                        ' amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text))), "0.000")
    '                                    End If
    '                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
    '                                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

    '                                    'slcode = txt_Storecode.Text
    '                                    sqlstring = sqlstring & "'N')"
    '                                    ReDim Preserve insert(insert.Length)
    '                                    insert(insert.Length - 1) = sqlstring
    '                                Else
    '                                    MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR StoreCode:-'" & txt_Storecode.Text & "'")
    '                                    Exit Sub
    '                                End If



    '                            End If
    '                        Next


    '                    End If




    '                Next


    '            End If

    '            sqlstring = "delete from directissueing"
    '            ReDim Preserve insert(insert.Length)
    '            insert(insert.Length - 1) = sqlstring




    '            gconnection.MoreTrans1(insert)
    '        End If


    '    End Sub

    Private Sub voidoperation()
        Dim INSERT(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim lastweightedrate As Double
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        GRNno = Split(Trim(txt_Grnno.Text), "/")
        Dim seq As Double




        sqlstring = "Update  prn_header set "
        sqlstring = sqlstring & " Void='Y',voiduser='" & Trim(gUsername) & "',"
        sqlstring = sqlstring & " voiddate=getDate()"
        sqlstring = sqlstring & "  where prndetails='" + Trim(CStr(Txt_PRNNo.Text)) + "'"
        INSERT(0) = sqlstring
        sqlstring = "Update  prn_details set  voidITEM='Y' where prndetails='" + Trim(Txt_PRNNo.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring
        If (GACCPOST.ToUpper() = "Y") Then

            sqlstring = "update  JOURNALENTRY set void='Y'   where VoucherNo='" + Trim(txt_Grnno.Text) + "' and voucherType='PRN' and voucherdate='" + Format(dtp_Prndate.Value, "dd/MMM/yyyy") + "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

        End If

        'If Trim(CmbGrnType.SelectedItem) = "PO" Then
        '    sqlstring = "Update po_itemdetails set receivedqty=receivedqty-qty,QTYstatus='' from PO_ITEMDETAILS inner join Grn_details"
        '    sqlstring = sqlstring & "    on PO_ITEMDETAILS.ITEMCODE=Grn_details.Itemcode and PO_ITEMDETAILS.pono=Grn_details.pono and PO_ITEMDETAILS.versionno=Grn_details.versionno "
        '    sqlstring = sqlstring & " where Grn_details.pono='" + Txt_PONo.Text + "' and Grn_details.versionno='" + versionno + "'"
        '    ReDim Preserve INSERT(INSERT.Length)
        '    INSERT(INSERT.Length - 1) = sqlstring

        '    sqlstring = "update po_hdr set postatus='RELEASED' where pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
        '    ReDim Preserve INSERT(INSERT.Length)
        '    INSERT(INSERT.Length - 1) = sqlstring

        'End If
        'sqlstring = "update ratelist  set void='Y' where   grnno='" + Trim(txt_Grnno.Text) + "'"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring


        'sqlstring = "select * from ratelist where grndate>='" + Format(dtp_Grndate.Value, "dd/MMM/yyyy") + "' and storecode='" + txt_Storecode.Text + "' order by grndate desc "
        'gconnection.getDataSet(sqlstring, "ratelist")
        'If (gdataset.Tables("ratelist").Rows.Count > 0) Then
        '    For M As Integer = 0 To gdataset.Tables("ratelist").Rows.Count - 1
        '        lastweightedrate = gdataset.Tables("ratelist").Rows(M).Item("weightedrate")
        '        If (M + 1 < gdataset.Tables("ratelist").Rows.Count - 1) Then
        '            sqlstring = "update   ratelist set weightedrate=(closingqty.openningstock+qty)/(closingqty.openningstock*" + lastweightedrate.ToString() + ")+(qty*batchrate) , lastweightedrate='" + lastweightedrate.ToString() + "' from ratelist inner join closingqty"
        '            sqlstring = sqlstring & " on ratelist.Itemcode=closingqty.itemcode and ratelist.grnno=closingqty.Trnno and ratelist.storecode=closingqty.storecode and grnno='" + gdataset.Tables("ratelist").Rows(M + 1).Item("grnno") + "'"
        '            ReDim Preserve INSERT(INSERT.Length)
        '            INSERT(INSERT.Length - 1) = sqlstring

        '        Else
        '            Exit For
        '        End If
        '    Next
        'End If

        'gconnection.MoreTrans1(INSERT)
        'ReDim INSERT(0)
        For i As Integer = 1 To AxfpSpread1.DataRowCnt

            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 4
            Dim qty As Double = Val(AxfpSpread1.Text)
            Dim batchyn As String

            Dim SQL1 As String = "select qty,batchyn,trns_seq from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
            SQL1 = SQL1 & " and Trnno='" + Txt_PRNNo.Text + "' "
            gconnection.getDataSet(SQL1, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                seq = gdataset.Tables("closingqty").Rows(0).Item("trns_seq")
            End If





            'SQL1 = "update closingqty set closingstock= closingstock " + Format(Val(qty), "0.000") + ",closingvalue=openningvalue,qty=0"
            '' ,closingvalue=closingvalue+(" + Format(Val(qty), "0.000") + "*(closingvalue/closingqty))"
            'SQL1 = SQL1 & "  where TRNS_SEQ=" & seq & " and trnno='" + Txt_PRNNo.Text + "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
            ''If (batchyn = "Y") Then
            ''    SQL1 = SQL1 & "  and  batchno='" + txt_Grnno.Text + "'"
            ''End If
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = SQL1

            'If (Format(CDate(gdate), "yyyy/MM/dd") > Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd")) Then
            '    'Dim batchyn As String
            '    Dim AUTOID As Integer = 0
            '    Dim closingqty As Double
            '    Dim closingvalue As Double
            '    Dim OLDQTY As Double
            '    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid,QTY from closingqty where itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'and trndate<='" + Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
            '    gconnection.getDataSet(sqlstring, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '        AUTOID = Val(gdataset.Tables("closingqty").Rows(0).Item("AUTOID"))
            '        closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
            '        closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
            '        'OLDQTY = Val(closingvalue / closingqty)
            '    End If


            '    sqlstring = "UPDATE closingqty SET openningstock=openningstock-(" + Format(Val(qty), "0.000") + "), closingstock= closingstock -" + Format(Val(qty), "0.000") + " "
            '    'sqlstring = sqlstring & ",closingvalue=openningvalue-(" + Format(Val(qty * OLDQTY), "0.000") + "),openningvalue=openningvalue -" + Format(Val((qty * OLDQTY)), "0.000") + ""
            '    'sqlstring = sqlstring & "  where trndate>'" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "'"
            '    sqlstring = sqlstring & "   and trns_seq>" & seq.ToString() & " and itemcode='" + itemcode + "'"
            '    'sqlstring = sqlstring & "   and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "'"

            '    '  sqlstring = sqlstring & " AND AUTOID >'" + AUTOID.ToString() + "'  "
            '    'If (batchyn = "Y") Then
            '    '    sqlstring = sqlstring & "  and  batchno='" + txt_Grnno.Text + "'"
            '    'End If
            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring


            '    '  gconnection.CalStockValue(txt_Storecode.Text, itemcode, seq)

            '    'sqlstring = "    update ratelist set weightedrate=closingvalue/closingstock ,"
            '    'sqlstring = sqlstring & "  lastweightedrate="
            '    'sqlstring = sqlstring & "  case when openningvalue=0 then"
            '    'sqlstring = sqlstring & "      batchrate "
            '    'sqlstring = sqlstring & "   Else"
            '    'sqlstring = sqlstring & "  openningvalue/openningstock "
            '    'sqlstring = sqlstring & "     End"
            '    'sqlstring = sqlstring & "  from ratelist inner join CLOSINGQTY on ratelist.grnno=CLOSINGQTY.trnno and CLOSINGQTY.closingstock<>0 where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
            '    'sqlstring = sqlstring & "   and CLOSINGQTY.storecode='" + txt_Storecode.Text + "' and CLOSINGQTY.itemcode='" + itemcode + "'"
            '    'ReDim Preserve INSERT(INSERT.Length)
            '    'INSERT(INSERT.Length - 1) = sqlstring

            'End If

            sqlstring = "update grn_details set RET_QTY=RET_QTY+" + Format(Val(qty), "0.000") + " where  itemcode='" + itemcode + "' and grndetails='" + txt_Grnno.Text + "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
            sqlstring = "update GRN_HEADER set RET_STATUS= CASE  WHEN (RET_QTY)=0 THEN 'Y' ELSE 'N' END from GRN_HEADER inner join grn_details on GRN_HEADER.grndetails=grn_details.grndetails AND GRN_HEADER.grndetails='" + txt_Grnno.Text + "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

        Next

        'SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(qty), "0.000") + " ,openningstock=openningstock+" + Format(Val(qty), "0.000") + ""
        '',closingvalue=closingvalue+("(-qty) + "*(closingvalue/closingqty)),openningvalue=openningvalue+("(-qty) + "*(openningvalue/openningstock))"
        'SQL1 = SQL1 & "  where trndate>='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' "
        'If (batchyn = "Y") Then
        '    SQL1 = SQL1 & "  and  batchno='" + txt_Grnno.Text + "'"
        'End If
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = SQL1

        '

        gconnection.MoreTrans(INSERT)

        'For k As Integer = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = k
        '    AxfpSpread1.Col = 1
        '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + txt_Storecode.Text + "' "
        '    sqlstring = sqlstring & " and Trnno='" + Txt_PRNNo.Text + "' and itemcode='" & AxfpSpread1.Text & "' "
        '    gconnection.getDataSet(sqlstring, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        '    End If

        '    gconnection.CalStockValue(txt_Storecode.Text, AxfpSpread1.Text, seq)
        'Next

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
        INSERT(0) = sqlstring
        sqlstring = "delete from   Grn_details  where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ' sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring
        If (GACCPOST.ToUpper() = "Y") Then
            '    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring
            sqlstring = "delete from  JOURNALENTRY where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ' sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            gconnection.dataOperation(6, sqlstring, )

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
        sqlstring = "delete from  ratelist where   grnno='" + Trim(txt_Grnno.Text) + "'"
        ' sqlstring = "update ratelist  set void='Y' where   grnno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "delete from  closingqty where   trnno='" + Trim(txt_Grnno.Text) + "'"
        '' sqlstring = "update ratelist  set void='Y' where   grnno='" + Trim(txt_Grnno.Text) + "'"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring

        For i As Integer = 1 To AxfpSpread1.DataRowCnt

            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 4
            Dim qty As Double = Val(AxfpSpread1.Text)
            Dim batchyn As String
            Dim seq As Double
            Dim SQL1 As String = "select qty,batchyn,trns_seq from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
            SQL1 = SQL1 & " and Trnno='" + txt_Grnno.Text + "' "
            gconnection.getDataSet(SQL1, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                seq = gdataset.Tables("closingqty").Rows(0).Item("trns_seq")
            End If
            'SQL1 = "update closingqty set closingstock= closingstock -" + Format(Val(qty), "0.000") + ",closingvalue=openningvalue,qty=0"
            '' ,closingvalue=closingvalue+(" + Format(Val(qty), "0.000") + "*(closingvalue/closingqty))"
            'SQL1 = SQL1 & "  where trndate='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Grnno.Text + "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
            'If (batchyn = "Y") Then
            '    SQL1 = SQL1 & "  and  batchno='" + txt_Grnno.Text + "'"
            'End If
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = SQL1



            'If (Format(CDate(gdate), "yyyy/MM/dd") > Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd")) Then
            '    'Dim batchyn As String
            '    Dim AUTOID As Integer = 0
            '    Dim closingqty As Double
            '    Dim closingvalue As Double
            '    Dim OLDQTY As Double
            '    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid,QTY from closingqty where itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'and trndate<='" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
            '    gconnection.getDataSet(sqlstring, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '        AUTOID = Val(gdataset.Tables("closingqty").Rows(0).Item("AUTOID"))
            '        closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
            '        closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
            '        OLDQTY = Val(closingvalue / closingqty)
            '    End If


            '    sqlstring = "UPDATE closingqty SET openningstock=openningstock-(" + Format(Val(qty), "0.000") + "), closingstock= closingstock -" + Format(Val(qty), "0.000") + " "
            '    sqlstring = sqlstring & ",closingvalue=openningvalue-(" + Format(Val(totalamount + totalothchg), "0.000") + "),openningvalue=openningvalue -" + Format(Val((totalamount + totalothchg)), "0.000") + ""
            '    sqlstring = sqlstring & "  where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
            '    sqlstring = sqlstring & "   and trns_seq>" & seq.ToString() & " and itemcode='" + itemcode + "'"
            '    'sqlstring = sqlstring & "   and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "'"

            '    '  sqlstring = sqlstring & " AND AUTOID >'" + AUTOID.ToString() + "'  "
            '    'If (batchyn = "Y") Then
            '    '    sqlstring = sqlstring & "  and  batchno='" + txt_Grnno.Text + "'"
            '    'End If
            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring



            '    'sqlstring = "    update ratelist set weightedrate=closingvalue/closingstock ,"
            '    'sqlstring = sqlstring & "  lastweightedrate="
            '    'sqlstring = sqlstring & "  case when openningvalue=0 then"
            '    'sqlstring = sqlstring & "      batchrate "
            '    'sqlstring = sqlstring & "   Else"
            '    'sqlstring = sqlstring & "  openningvalue/openningstock "
            '    'sqlstring = sqlstring & "     End"
            '    'sqlstring = sqlstring & "  from ratelist inner join CLOSINGQTY on ratelist.grnno=CLOSINGQTY.trnno where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
            '    'sqlstring = sqlstring & "   and CLOSINGQTY.storecode='" + txt_Storecode.Text + "' and CLOSINGQTY.itemcode='" + itemcode1 + "'"
            '    'ReDim Preserve INSERT(INSERT.Length)
            '    'INSERT(INSERT.Length - 1) = sqlstring

            'End If

        Next

        'SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(qty), "0.000") + " ,openningstock=openningstock+" + Format(Val(qty), "0.000") + ""
        '',closingvalue=closingvalue+("(-qty) + "*(closingvalue/closingqty)),openningvalue=openningvalue+("(-qty) + "*(openningvalue/openningstock))"
        'SQL1 = SQL1 & "  where trndate>='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' "
        'If (batchyn = "Y") Then
        '    SQL1 = SQL1 & "  and  batchno='" + txt_Grnno.Text + "'"
        'End If
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = SQL1

        'sqlstring = "select * from ratelist where grndate>='" + Format(dtp_Grndate.Value, "dd/MMM/yyyy") + "' and storecode='" + txt_Storecode.Text + "'  order by grndate desc "
        'gconnection.getDataSet(sqlstring, "ratelist")
        'If (gdataset.Tables("ratelist").Rows.Count > 0) Then
        '    For i As Integer = 0 To gdataset.Tables("ratelist").Rows.Count - 1
        '        lastweightedrate = gdataset.Tables("ratelist").Rows(i).Item("weightedrate")
        '        If (i + 1 < gdataset.Tables("ratelist").Rows.Count - 1) Then
        '            sqlstring = "update   ratelist set weightedrate=(closingqty.openningstock+qty)/(closingqty.openningstock*" + lastweightedrate.ToString() + ")+(qty*batchrate) , lastweightedrate='" + lastweightedrate.ToString() + "' from ratelist inner join closingqty"
        '            sqlstring = sqlstring & " on ratelist.Itemcode=closingqty.itemcode and ratelist.grnno=closingqty.Trnno and ratelist.storecode=closingqty.storecode and grnno='" + gdataset.Tables("ratelist").Rows(i + 1).Item("grnno") + "'"
        '            ReDim Preserve INSERT(INSERT.Length)
        '            INSERT(INSERT.Length - 1) = sqlstring

        '        Else
        '            Exit For
        '        End If
        '    Next
        'End If

        gconnection.MoreTrans1(INSERT)

    End Sub
    Private Sub UpdateOperation()
        Dim INSERT(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim uom As String
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        Dim weightedrate As Decimal
        Dim lastweightedrate As Decimal
        Dim INSERT1(0) As String
        Dim INSERT2(0) As String
        Dim stockuom As String
        Dim convvalue As Double
        Dim precise As Double
        Dim FQCONVVALUE As Double

        Dim fqprecise As Double

        Dim fqqty As Double
        Dim fquom As String
        sqlstring = "select * from Prn_details WHERE Prndetails='" + Trim(CStr(Txt_PRNNo.Text)) + "' and cast(convert(varchar(11),Prndate,106)as datetime)='" & Format(Me.dtp_Prndate.Value, "dd/MMM/yyyy") & "'"
        gconnection.getDataSet(sqlstring, "backdate")
        If gdataset.Tables("backdate").Rows.Count > 0 Then


            GRNno = Split(Trim(Txt_PRNNo.Text), "/")
            CATCODE = Split(CMB_CATEGORY.Text, "--->")

            sqlstring = "INSERT INTO PRN_HEADERLOG(category,Prnno,Prndetails,Prndate,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
            sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,TOTCESSAMT,TOTSPLCESS)"
            sqlstring = sqlstring & " SELECT category,Prnno,Prndetails,Prndate,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
            sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,TOTCESSAMT,TOTSPLCESS"
            sqlstring = sqlstring & " FROM PRN_HEADER WHERE Prndetails='" + Trim(CStr(Txt_PRNNo.Text)) + "'"
            INSERT1(0) = sqlstring
            sqlstring = " DELETE FROM PRN_HEADER WHERE Prndetails='" + Trim(CStr(Txt_PRNNo.Text)) + "'"
            ReDim Preserve INSERT1(INSERT1.Length)
            INSERT1(INSERT1.Length - 1) = sqlstring
            sqlstring = "iNSERT INTO PRN_DETAILSLOG(Prnno,Prndetails,Prndate,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
            sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FQUOM,oldqty,trns_seq,VENDOR_TYPE,TAX_TYPE,ITEM_TYPE,LoadingChg,SPONSORCODE,COMPANYcode,CESSAMT)"
            sqlstring = sqlstring & " SELECT Prnno,Prndetails,Prndate,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
            sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FQUOM,oldqty,trns_seq,VENDOR_TYPE,TAX_TYPE,ITEM_TYPE,LoadingChg,SPONSORCODE,COMPANYcode,CESSAMT"
            sqlstring = sqlstring & "  FROM Prn_details where Prndetails='" + Trim(Txt_PRNNo.Text) + "'"
            ReDim Preserve INSERT1(INSERT1.Length)
            INSERT1(INSERT1.Length - 1) = sqlstring
            'sqlstring = " DELETE FROM RATELIST WHERE grnno='" + Trim(CStr(txt_Grnno.Text)) + "'"
            'ReDim Preserve INSERT1(INSERT1.Length)
            'INSERT1(INSERT1.Length - 1) = sqlstring
            sqlstring = "INSERT INTO Prn_header(category,Prnno,Prndetails,Prndate,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
            ' sqlstring = sqlstring & ",Typecode,Typedesc,Excisepassno,Excisedate,Stockindate,Trucknumber,Creditdays,Glaccountcode,Glaccountname,Slcode,Slname,Costcentercode,Costcentername,"
            sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,TOTSPLCESS)"
            sqlstring = sqlstring & " VALUES ('" & Trim(CATCODE(0)) & "','" & CStr(GRNno(2)) & "','" & Trim(CStr(Txt_PRNNo.Text)) & "','" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "','" & Trim(CStr(txt_Grnno.Text)) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
            If Trim(CmbGrnType.SelectedItem) = "PO" Then
                sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
            Else
                sqlstring = sqlstring & " '" & Trim(TXT_Sponsor.Text) & "',"
            End If

            sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
            '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
            '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
            ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
            sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.000") & "," & Format(Val(txt_totaltax.Text), "0.000") & "," & Format(Val(txt_Surchargeamt.Text), "0.000") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.000") & "," & Format(Val(txt_totdisc.Text), "0.000") & ","
            sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.000") & ","
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',getDate(),"
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
            sqlstring = sqlstring & "  'PRN','" + versionno + "'," & Format(Val(Txt_SPLCESS.Text), "0.000") & ")"
            ReDim Preserve INSERT1(INSERT1.Length)
            INSERT1(INSERT1.Length - 1) = sqlstring

            'sqlstring = "Update  Grn_header set "
            'sqlstring = sqlstring & " category ='" & Trim(CMB_CATEGORY.Text) & "',"
            'sqlstring = sqlstring & " Grndate= '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
            'sqlstring = sqlstring & "POno= '" & Trim(Txt_PONo.Text) & "',"
            'sqlstring = sqlstring & "Supplierinvno= '" & Trim(CStr(txt_Supplierinvno.Text)) & "',Supplierdate='" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
            'sqlstring = sqlstring & "Suppliercode= '" & Trim(CStr(txt_Suppliercode.Text)) & "',Suppliername='" & Trim(CStr(txt_Suppliername.Text)) & "',"
            ''" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
            ''  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
            '' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
            'sqlstring = sqlstring & "Totalamount= " & Format(Val(txt_total.Text), "0.000") & ",VATamount=" & Format(Val(txt_totaltax.Text), "0.000") & ",Surchargeamt=" & Format(Val(txt_Surchargeamt.Text), "0.000") & ",OverallDiscount=" & Format(Val(TXT_OVERALLdiscount.Text), "0.000") & ",Discount=" & Format(Val(txt_totdisc.Text), "0.000") & ","
            'sqlstring = sqlstring & " Billamount=" & Format(Val(txt_Billamount.Text), "0.000") & ","
            'sqlstring = sqlstring & "Remarks= '" & Trim(CStr(txt_Remarks.Text)) & "',Void='N',updateuser='" & Trim(gUsername) & "',updatedate=getDate(),"
            'sqlstring = sqlstring & " storecode='" & Trim(CStr(txt_Storecode.Text)) & "',STOREDESC='" & Trim(CStr(txt_StoreDesc.Text)) & "',"
            'sqlstring = sqlstring & " Grntype= 'GRN' where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
            'INSERT(0) = sqlstring
            sqlstring = "Delete from Prn_details where Prndetails='" + Trim(Txt_PRNNo.Text) + "'"
            ReDim Preserve INSERT1(INSERT1.Length)
            INSERT1(INSERT1.Length - 1) = sqlstring

            'If Trim(CmbGrnType.SelectedItem) = "PO" Then


            '    sqlstring = "Update po_itemdetails set receivedqty=receivedqty-qty,qtystatus='' from PO_ITEMDETAILS inner join Grn_details"
            '    sqlstring = sqlstring & "    on PO_ITEMDETAILS.ITEMCODE=Grn_details.Itemcode and PO_ITEMDETAILS.pono=Grn_details.pono and PO_ITEMDETAILS.versionno=Grn_details.versionno  "
            '    sqlstring = sqlstring & " where Grn_details.pono='" + Txt_PONo.Text + "' and grn_details.versionno='" + versionno + "' "
            '    gconnection.dataOperation(6, sqlstring)
            '    sqlstring = "update po_hdr set postatus='RELEASED' where pono='" + Txt_PONo.Text + "'"
            '    gconnection.dataOperation(6, sqlstring)
            '    'gconnection.MoreTrans1(INSERT1)

            'End If
            'gconnection.MoreTrans1(INSERT1)
            Dim sql1 As String
            Dim SEQ1 As Double
            Dim seq As Double

            For i As Integer = 1 To AxfpSpread1.DataRowCnt



                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1


                sqlstring = "INSERT INTO Prn_details(Prnno,prndetails,Prndate,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
                sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,Discount,amountafterdiscount,taxcode,TaxPer,taxamount,amount,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FqUom,oldqty,SPLCESS)"
                sqlstring = sqlstring & " VALUES('" & CStr(GRNno(2)) & "','" & Trim(Txt_PRNNo.Text) & "','" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
                If Trim(CmbGrnType.SelectedItem) = "PO" Then
                    sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
                Else
                    sqlstring = sqlstring & " '" & Trim(TXT_Sponsor.Text) & "',"
                End If


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
                Dim qty1 As Double = Format(Val(AxfpSpread1.Text), "0.000")
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
                sqlstring = sqlstring & " '" & Format(Val(AxfpSpread1.Text), "0.000") & "',"
                totalothchg = Val(AxfpSpread1.Text)

                AxfpSpread1.Col = 16
                sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

                sqlstring = sqlstring & "'" & Trim(CATCODE(0)) & "',"
                sqlstring = sqlstring & "'" & Trim(gUsername) & "',getDate(),"
                sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"

                If Trim(CmbGrnType.SelectedItem) = "PO" Then
                    sqlstring = sqlstring & "'PRN','" + versionno + "',"
                Else
                    sqlstring = sqlstring & "'PRN', '',"
                End If


                AxfpSpread1.Col = 17
                fqqty = Format(Val(AxfpSpread1.Text), "0.000")
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                AxfpSpread1.Col = 18
                fquom = AxfpSpread1.Text
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                sql1 = "select qty,ISNULL(batchyn,'N') AS batchyn,AUTOID from closingqty where  itemcode='" + itemcode1 + "' and storecode='" + txt_Storecode.Text + "' "
                sql1 = sql1 & " and Trnno='" + Txt_PRNNo.Text + "' "
                gconnection.getDataSet(sql1, "closingqty")
                Dim oldQty As Double
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    oldQty = gdataset.Tables("closingqty").Rows(0).Item("qty")
                End If

                'sql1 = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + txt_Storecode.Text + "' "
                'sql1 = sql1 & " and Trnno='" + Txt_PRNNo.Text + "' AND ITEMCODE='" & itemcode1 & "'"
                'gconnection.getDataSet(sql1, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '    SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
                'End If

                sqlstring = sqlstring & " '" & Format(Val(oldQty), "0.000") & "',"
                AxfpSpread1.Col = 19
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ")"

                ReDim Preserve INSERT1(INSERT1.Length)
                INSERT1(INSERT1.Length - 1) = sqlstring

                AxfpSpread1.Col = 1


                sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode1 + "'"
                stockuom = gconnection.getvalue(sqlstring)
                sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + stockuom + "' and transuom='" + uom + "'"
                gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                Else
                    MessageBox.Show("Generate relation between " + stockuom + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
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
                        Exit Sub
                    End If
                Else

                End If





                'Dim cmd As New SqlCommand("INV_SPWeightedRateCalculation", gconnection.Myconn)
                'cmd.CommandType = CommandType.StoredProcedure
                'cmd.Parameters.Add("@ttodate", SqlDbType.DateTime).Value = Format(dtp_Grndate.Value.ToString("dd/MMM/yyyy"))
                'cmd.Parameters.Add("@tpitemcode", SqlDbType.VarChar, 50).Value = itemcode1
                'cmd.Parameters.Add("@tstorecode", SqlDbType.VarChar, 50).Value = txt_Storecode.Text
                'cmd.Parameters.Add("@tuom", SqlDbType.VarChar, 50).Value = uom
                'cmd.Parameters.Add("@currentgrnqty", SqlDbType.Float).Value = qty1
                'cmd.Parameters.Add("@currentPurchaseRate", SqlDbType.Float).Value = (totalamount + totalothchg) / qty1
                'cmd.Parameters.Add("@WeightedRate", SqlDbType.Float)
                'cmd.Parameters.Add("@lastWeightedRate", SqlDbType.Float)
                'cmd.Parameters("@lastWeightedRate").Direction = ParameterDirection.Output

                'cmd.Parameters("@WeightedRate").Direction = ParameterDirection.Output

                'gconnection.Myconn.Open()
                'cmd.ExecuteReader()
                'weightedrate = cmd.Parameters("@WeightedRate").Value
                'lastweightedrate = cmd.Parameters("@lastWeightedRate").Value
                'gconnection.Myconn.Close()

                'itemcode1 = AxfpSpread1.Text
                'sqlstring = "insert into ratelist(grnno,batchno,itemcode,uom,batchrate,grndate,weightedrate,lastweightedrate,storecode,adddate,adduser)"
                'sqlstring = sqlstring & " values ('" + txt_Grnno.Text + "',"
                'AxfpSpread1.Col = 14
                'sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
                'AxfpSpread1.Col = 1
                'sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
                'AxfpSpread1.Col = 3
                'sqlstring = sqlstring & "'" + uom + "', "
                'AxfpSpread1.Col = 5
                'sqlstring = sqlstring & "'" + Format(Val((totalamount + totalothchg) / qty1), "0.000") + "' ,"
                'sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
                'sqlstring = sqlstring & "" & Format(Val(weightedrate), "0.000") & " , "
                'sqlstring = sqlstring & "" & Format(Val(lastweightedrate), "0.000") & " , "

                'sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',getDate(),'" & Trim(gUsername) & "')"
                'ReDim Preserve INSERT1(INSERT1.Length)
                'INSERT1(INSERT1.Length - 1) = sqlstring

                AxfpSpread1.Col = 1
                Dim itemcode As String = AxfpSpread1.Text
                AxfpSpread1.Col = 4
                Dim qty As Double = Format((qty1 / convvalue) + (qty1 * precise), "0.000")
                Dim batchyn As String
                Dim AUTOID As Integer = 0

                'sql1 = "select qty,ISNULL(batchyn,'N') AS batchyn,AUTOID,trns_seq from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
                'sql1 = sql1 & " and Trnno='" + Txt_PRNNo.Text + "' "
                'gconnection.getDataSet(sql1, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                '    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                '    AUTOID = Val(gdataset.Tables("closingqty").Rows(0).Item("AUTOID"))
                '    seq = Val(gdataset.Tables("closingqty").Rows(0).Item("trns_seq"))
                'End If
                'sql1 = "update closingqty set closingstock= closingstock +" + Format(Val((qty1 * -1) + (qty * -1)), "0.000") + " ,closingvalue=openningvalue-(" + Format(Val(totalamount + totalothchg), "0.000") + ")"
                'sql1 = sql1 & ",QTY=- " + qty.ToString() + " where trndate='" & Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy") & "'"
                'sql1 = sql1 & "  and trnno='" + Txt_PRNNo.Text + "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "'"
                'sql1 = sql1 & " AND AUTOID ='" + AUTOID.ToString() + "' "
                ''If (batchyn = "Y") Then
                ''    sql1 = sql1 & "  and  batchno='" + txt_Grnno.Text + "'"
                ''End If
                'ReDim Preserve INSERT1(INSERT1.Length)
                'INSERT1(INSERT1.Length - 1) = sql1


                sqlstring = "update grn_details set RET_QTY=RET_QTY+" + Format(Val((qty1 * -1) + (qty * -1)), "0.000") + " where  itemcode='" + itemcode + "' and grndetails='" + txt_Grnno.Text + "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring




                'sqlstring = "Select getdate()"
                'gdate = gconnection.getvalue(sqlstring)

                'If (Format(CDate(gdate), "yyyy/MM/dd") > Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd")) Then
                '    'Dim batchyn As String
                '    'Dim AUTOID As Integer = 0
                '    Dim closingqty As Double
                '    Dim closingvalue As Double
                '    Dim Rate As Double
                '    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid,QTY from closingqty where itemcode='" + itemcode1 + "' and storecode='" + txt_Storecode.Text + "'and trndate<='" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
                '    gconnection.getDataSet(sqlstring, "closingqty")
                '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '        AUTOID = Val(gdataset.Tables("closingqty").Rows(0).Item("AUTOID"))
                '        closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
                '        closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")

                '    End If
                '    Dim sql As String = " select rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
                '    sql = sql & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" & itemcode1 & "' "
                '    gconnection.getDataSet(sql, "ratelist2")
                '    If (gdataset.Tables("ratelist2").Rows.Count > 0) Then
                '        If (gdataset.Tables("ratelist2").Rows(0).Item("rateflag") = "W") Then
                '            'Rate = weightedrate
                '            Rate = Val((totalamount + totalothchg) / qty)
                '        Else
                '            Rate = Val((totalamount + totalothchg) / qty)
                '        End If
                '    End If

                '    sqlstring = "UPDATE closingqty SET openningstock=openningstock+(" + Format(Val((qty1 * -1) + (qty * -1)), "0.000") + "), closingstock= closingstock +" + Format(Val((qty1 * -1) + (qty * -1)), "0.000") + " "
                '    'sqlstring = sqlstring & ",closingvalue=closingstock*(" + Format(Val(Rate), "0.000") + "),openningvalue=openningstock *" + Format(Val((Rate)), "0.000") + ""
                '    'Sqlstring = sqlstring & "  where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
                '    sqlstring = sqlstring & "   where trns_seq>" & seq.ToString() & " and itemcode='" + itemcode1 + "'"

                '    sqlstring = sqlstring & "   and storecode='" + txt_Storecode.Text + "'"

                '    ReDim Preserve INSERT(INSERT.Length)
                '    INSERT(INSERT.Length - 1) = sqlstring

                '    sqlstring = "UPDATE closingqty SET  closingvalue=closingstock*(" + Format(Val(Rate), "0.000") + "),openningvalue=openningstock *" + Format(Val((Rate)), "0.000") + ""
                '    'sqlstring = sqlstring & "  where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
                '    sqlstring = sqlstring & "   where trns_seq>" & seq.ToString() & " and itemcode='" + itemcode1 + "'"


                '    ReDim Preserve INSERT(INSERT.Length)
                '    INSERT(INSERT.Length - 1) = sqlstring


                '    sqlstring = "    update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end ,"
                '    sqlstring = sqlstring & "  lastweightedrate="
                '    sqlstring = sqlstring & "  case when openningvalue=0 then"
                '    sqlstring = sqlstring & "      batchrate "
                '    sqlstring = sqlstring & "   Else"
                '    sqlstring = sqlstring & "  openningvalue/openningstock "
                '    sqlstring = sqlstring & "     End"
                '    sqlstring = sqlstring & "  from ratelist inner join CLOSINGQTY on ratelist.grnno=CLOSINGQTY.trnno where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
                '    sqlstring = sqlstring & "   and CLOSINGQTY.storecode='" + txt_Storecode.Text + "' and CLOSINGQTY.itemcode='" + itemcode1 + "'"
                '    ReDim Preserve INSERT(INSERT.Length)
                '    INSERT(INSERT.Length - 1) = sqlstring

                'End If



            Next


            If (GACCPOST.ToUpper() = "Y") Then
                sqlstring = "update  JOURNALENTRY set void='Y'   where VoucherNo='" + Trim(txt_Grnno.Text) + "' and voucherType='PRN' and voucherdate='" + Format(dtp_Prndate.Value, "dd/MMM/yyyy") + "'"
                gconnection.dataOperation(6, sqlstring, )
                'accountPost()
            End If
            If check = True Then

                gconnection.MoreTrans1(INSERT1)
                gconnection.MoreTrans(INSERT2)
                gconnection.MoreTrans1(INSERT)


                'For k As Integer = 1 To AxfpSpread1.DataRowCnt
                '    AxfpSpread1.Row = k
                '    AxfpSpread1.Col = 1
                '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + txt_Storecode.Text + "' "
                '    sqlstring = sqlstring & " and Trnno='" + Txt_PRNNo.Text + "' and itemcode='" & AxfpSpread1.Text & "' "
                '    gconnection.getDataSet(sqlstring, "closingqty")
                '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '        seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
                '    End If

                '    gconnection.CalStockValue(txt_Storecode.Text, AxfpSpread1.Text, seq)
                'Next

            Else
                check = True
                Exit Sub
            End If

            'If Trim(CmbGrnType.SelectedItem) = "PO" Then
            '    Dim SQL As String = "select count(*) as a from  po_itemdetails where ISNULL(qtystatus,'') <> 'RECEIVED' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            '    gconnection.getDataSet(SQL, "po_itemdetails")
            '    If gdataset.Tables("po_itemdetails").Rows.Count > 0 Then
            '        If Val(gdataset.Tables("po_itemdetails").Rows(0).Item("a").ToString()) > 0 Then
            '        Else
            '            sqlstring = "update po_hdr set postatus='CLOSED' where   pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            '            gconnection.dataOperation(6, sqlstring, )
            '        End If
            '    End If
            'End If

            'If (GACCPOST.ToUpper() = "Y") Then
            '    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            '    gconnection.dataOperation(6, sqlstring, )
            '    accountPost()
            'End If
        Else
            voidoperationupdate()
            addoperation()
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
        Dim message, title, defaultValue As String
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


                    SQL = " select I.itemcode,Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode "
                    If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then

                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "' and I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and itemcode not in (select itemcode from trnsView where storecode<>'" + txt_Storecode.Text + "' and ttype='GRN'))"

                    Else

                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "' and I.itemcode IN (select itemcode from trnsView where storecode<>'" + txt_Storecode.Text + "' and ttype='GRN') "

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
                                AxfpSpread1.Lock = True
                            End If
                            If CATCODE(0) = "LIQ" Then
                                SQL = "SELECT TOP 1   batchrate as rate  FROM ratelist  WHERE ITEMCODE='" + Trim(AxfpSpread1.Text) + "' AND storecode='" + txt_Storecode.Text + "' ORDER BY grndate DESC"
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
                            SQL = "select TAXCODE, taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                            gconnection.getDataSet(SQL, "Itemtaxtagging")
                            If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                                AxfpSpread1.Col = 10
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                                AxfpSpread1.Col = 11
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                            Else
                                MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

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


                    SQL = " select I.itemcode,Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  "
                    If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then

                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(itemname,'')='" + Trim(AxfpSpread1.Text) + "' and I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')"

                    Else
                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(itemname,'')='" + Trim(AxfpSpread1.Text) + "'"

                    End If
                    AxfpSpread1.Col = 2
                    SQL = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and Itemname='" + Trim(AxfpSpread1.Text) + "' and isnull(contractyn,0)='1'"
                    gconnection.getDataSet(SQL, "Invitem_VendorMaster")
                    If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                        AxfpSpread1.Col = 3
                        AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("rate")
                        AxfpSpread1.Lock = True
                    End If
                    If CATCODE(0) = "LIQ" Then
                        SQL = "SELECT TOP 1   batchrate as rate  FROM ratelist WHERE Itemname='" + Trim(AxfpSpread1.Text) + "' AND storecode='" + txt_Storecode.Text + "'  ORDER BY grndate DESC"
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
                            AxfpSpread1.Lock = True
                        End If
                    End If


                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then

                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            AxfpSpread1.SetText(18, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
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
                            SQL = "select TAXCODE, taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                            gconnection.getDataSet(SQL, "Itemtaxtagging")
                            If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                                AxfpSpread1.Col = 10
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                                AxfpSpread1.Col = 11
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                            Else
                                MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            End If
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(2, AxfpSpread1.ActiveRow)
                        End If
                    End If
                End If
                'QTY
            ElseIf AxfpSpread1.ActiveCol = 4 Then
                AxfpSpread1.Col = 4
                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.Col = 1
                    SQL = "Select isnull(qty,0) as qty,isnull(ret_qty,0) as ret_qty  from Grn_details where grndetails='" + txt_Grnno.Text + "' and itemcode='" + AxfpSpread1.Text + "'"
                    gconnection.getDataSet(SQL, "grndetails")
                    If (gdataset.Tables("grndetails").Rows.Count > 0) Then
                        ' Dim qtyrange As Double = Val(gdataset.Tables("grndetails").Rows(0).Item("qtyrange"))
                        Dim qty As Double = Val(gdataset.Tables("grndetails").Rows(0).Item("qty"))
                        Dim ret_qty As Double = Val(gdataset.Tables("grndetails").Rows(0).Item("ret_qty"))
                        AxfpSpread1.Lock = False
                        AxfpSpread1.Col = 4

                        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                            If (qty - ret_qty) < Val(AxfpSpread1.Text) Then
                                MessageBox.Show("Quantity Cannot be Greater than GRN Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                                AxfpSpread1.Text = Val(qty - ret_qty)
                            Else
                                CALCULATE()

                                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                            End If
                        Else
                            If (qty) < Val(AxfpSpread1.Text) Then
                                MessageBox.Show("Quantity Cannot be Greater than GRN Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                                AxfpSpread1.Text = Val(qty - ret_qty)
                            Else
                                CALCULATE()

                                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                            End If
                        End If







                        'If (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "FIXED RATE FIXED QUANTITY" Or gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "OPEN RATE FIXED QUANTITY") Then

                        '    AxfpSpread1.Col = 4
                        '    Dim quant As Double = Val(AxfpSpread1.Text)
                        '    If ((qty + qtyrange) - receivedqty < quant) Then
                        '        MessageBox.Show("Quantity Cannot be Greater than PO Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        '        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        '        AxfpSpread1.Text = Val(qty)
                        '    Else
                        '        CALCULATE()

                        '        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                        '    End If
                        'ElseIf (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "RATE IN RANGE QUANTITY IN RANGE") Then
                        '    AxfpSpread1.Col = 4
                        '    Dim quant As Double = Val(AxfpSpread1.Text)
                        '    If ((qty + qtyrange) - receivedqty < quant) Then
                        '        MessageBox.Show("Quantity Cannot be Greater than PO Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        '        AxfpSpread1.Text = ""
                        '        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        '    Else
                        '        CALCULATE()

                        '        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                        '    End If


                        'Else

                        '    CALCULATE()

                        '    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                        'End If
                    Else
                        CALCULATE()

                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                    End If
                End If
                'RATE
            ElseIf AxfpSpread1.ActiveCol = 5 Then
                AxfpSpread1.Col = 5
                If Trim(AxfpSpread1.Text) = "" Then
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
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)

                End If
            ElseIf AxfpSpread1.ActiveCol = 8 Then
                AxfpSpread1.Col = 8
                If Trim(AxfpSpread1.Text) = "0.00" Or Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                Else
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)

                End If

            ElseIf AxfpSpread1.ActiveCol = 10 Then
                AxfpSpread1.Col = 10

                If Trim(AxfpSpread1.Text) = "" Then
                    bindtaxcode()
                    AxfpSpread1.Col = 17
                    If AxfpSpread1.Lock = True Then
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    Else

                        AxfpSpread1.SetActiveCell(17, i)
                    End If
                    ' AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)

                    ' AxfpSpread1.SetActiveCell(1, i + 1)
                Else
                    SQL = "select taxper from invtaxgroupmaster where taxgroupcode='" + AxfpSpread1.Text + "' "
                    Dim taxper As Double = gconnection.getvalue(SQL)

                    AxfpSpread1.Col = 11
                    AxfpSpread1.SetText(11, i, Val(taxper))
                    CALCULATE()
                    AxfpSpread1.Col = 17
                    If AxfpSpread1.Lock = True Then
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    Else

                        AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                    End If
                    'AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                    ' AxfpSpread1.SetActiveCell(1, i + 1)

                End If
            ElseIf AxfpSpread1.ActiveCol = 17 Then
                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetText(17, i, "0.00")

                    AxfpSpread1.SetActiveCell(1, i + 1)
                Else
                    AxfpSpread1.SetActiveCell(18, AxfpSpread1.ActiveRow)
                    'AxfpSpread1.SetActiveCell(1, i + 1)

                End If
            ElseIf AxfpSpread1.ActiveCol = 18 Then

                AxfpSpread1.SetActiveCell(1, i + 1)



            End If



        ElseIf e.keyCode = Keys.F1 Then
            txt_Remarks.Focus()
        ElseIf e.keyCode = Keys.F3 Then
            If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                CALCULATE()
            End If

        End If


    End Sub
    Private Sub bindtaxcode()
        Dim vform As New ListOperattion1

        gSQLString = "select taxgroupcode,taxper from  invtaxgroupmaster  "

        M_WhereCondition = " where isnull(void,'')<>'Y'"
        vform.Field = " Taxgroupcode "
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
            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)

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

                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) <> "" Then

                    If j = 4 Or j = 5 Then
                    Else
                        AxfpSpread1.Col = j
                        AxfpSpread1.Lock = True

                    End If
                Else
                    AxfpSpread1.Col = j
                    AxfpSpread1.Lock = True
                End If



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
            Dim voidStatus, YEARSEL As String
            YEARSEL = CMB_YEAR.Text

            CATCODE = Split(CMB_CATEGORY.Text, "--->")
            '  CATCODE = Split(Trim(Mid(CMB_CATEGORY.Text, 1, 3)), "--->")
            If Trim(UCase(gShortname)) = "CGC" Then
                voidStatus = " and void ='N'"
            Else
                voidStatus = ""
            End If
            voidStatus = " and void ='N'"
            'If Trim(UCase(gShortname)) = "SATC" Then
            '    gSQLString = "SELECT Grndetails,Grndate,SUPPLIERNAME FROM Grn_header"
            '    M_WhereCondition = " Where Isnull(GRNTYPE,'')='GRN' " & voidStatus & "  AND ISNULL(GRNDETAILS,'') LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%' and grndetails in (select distinct grndetails from  Grn_details where qty>isnull(RET_QTY,0)) UNION ALL "
            '    gSQLString = gSQLString & M_WhereCondition & " SELECT Grndetails,Grndate,SUPPLIERNAME FROM acc1920..Grn_header"
            '    M_WhereCondition = " Where Isnull(GRNTYPE,'')='GRN' " & voidStatus & "  AND ISNULL(GRNDETAILS,'') LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%' and grndetails in (select distinct grndetails from  acc1920..Grn_details where qty>isnull(RET_QTY,0)) "
            'Else
            gSQLString = "SELECT Grndetails,Grndate,SUPPLIERNAME FROM " & YEARSEL & "..Grn_header"
                M_WhereCondition = " Where Isnull(GRNTYPE,'')='GRN' " & voidStatus & "  AND ISNULL(GRNDETAILS,'') LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%' and grndetails in (select distinct grndetails from " & YEARSEL & ".. Grn_details where qty>isnull(RET_QTY,0))"
                M_ORDERBY = "  order by  Grndate  desc ,Autoid desc"

            '  End If
            'Else
            '    gSQLString = "SELECT Grndetails,Grndate,SUPPLIERNAME FROM Grn_header"
            '    M_WhereCondition = " Where Isnull(GRNTYPE,'')='GRN' " & voidStatus & "  AND ISNULL(GRNDETAILS,'') LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%' and grndetails in (select distinct grndetails from  Grn_details where qty>isnull(RET_QTY,0))"
            '    M_ORDERBY = "  order by  Grndate  desc ,Autoid desc"
            'End If
            Dim vform As New List_Operation
            vform.Field = "GRNDETAILS,GRNDATE,SUPPLIERNAME"
            vform.vFormatstring1 = "       GRN NO                     |         GRN DATE                     |     SUPPLIERNAME                           "
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
                    strsql = strsql & " DiscAmt,VatAmt,a.taxcode  FROM PO_ITEMDETAILS A"
                    strsql = strsql & " WHERE  A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "'  and  ITEMCODE not in(select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "') GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                    strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                    strsql = strsql & ",DiscAmt,VatAmt,A.quantity  "
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
                    strsql = strsql & "DiscAmt,VatAmt,a.taxcode  FROM PO_ITEMDETAILS A inner JOIN GRN_DETAILS B "
                    strsql = strsql & "ON A.pono =B.POno and a.versionno=b.versionno "
                    strsql = strsql & "WHERE a.itemcode not in (select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "') and  A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "' GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                    strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                    strsql = strsql & ",DiscAmt,VatAmt,A.quantity  "
                    strsql = strsql & " ORDER BY A.AUTOID "
                Else


                    strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity  AS quantity,"
                    strsql = strsql & " A.rate,A.discper, a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                    '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                    strsql = strsql & " DiscAmt,VatAmt,a.taxcode  FROM PO_ITEMDETAILS A"
                    strsql = strsql & " WHERE  A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "'  and  ITEMCODE not in(select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "') GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                    strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                    strsql = strsql & ",DiscAmt,VatAmt,A.quantity  "
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
                        strsql = strsql & " FROM Grn_details WHERE itemcode='" + tcode + "' and pono='" & Trim(Txt_PONo.Text) & "' "
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
            'Call autogenerate()
            If validateoninsert() = False Then
                addoperation()
                Call UpdateGST("PRN", Trim(Txt_PRNNo.Text), Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy"))
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
                vOutfile = Mid("WEi" & (Rnd() * 800000000), 1, 10)
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
                strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Prndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, Txt_PRNNo.Text, "PRN")
                sqlstring = " exec proc_closingqtyone 'PRN_ADD' "
                gconnection.ExcuteStoreProcedure(sqlstring)
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)
                sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                gconnection.ExcuteStoreProcedure(sqlstring)

                clearoperation()


            End If

        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
            If validateonupdate() = False Then
                UpdateOperation()

                Call UpdateGST("PRN", Trim(Txt_PRNNo.Text), Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy"))

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
                vOutfile = Mid("WEI" & (Rnd() * 800000000), 1, 10)
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
                strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Prndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, Txt_PRNNo.Text, "PRN")
                sqlstring = " exec proc_closingqtyone 'PRN_UPDATE' "
                gconnection.ExcuteStoreProcedure(sqlstring)
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)
                sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                gconnection.ExcuteStoreProcedure(sqlstring)



                clearoperation()

            End If
        End If

    End Sub

    Private Sub txt_Grnno_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Grnno.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If txt_Grnno.Text = "" Then
                cmd_Grnnohelp_Click(sender, e)
            Else
                Call txt_Grnno_Validated(txt_Grnno.Text, e)
            End If

        End If
    End Sub

    Private Sub txt_Grnno_Validated(sender As Object, e As EventArgs) Handles txt_Grnno.Validated
        Dim I, J, K As Integer
        Dim vString, sqlstring, YEARSELECTION As String
        Dim GRNDATE As Date
        Dim vTypeseqno, Clsquantity As Double
        Dim vGroupseqno As Double
        Dim dt As New DataTable
        YEARSELECTION = CMB_YEAR.Text
        If Trim(txt_Grnno.Text) <> "" Then
            Try
                'If Trim(UCase(gShortname)) = "SATC" Then
                '    sqlstring = "SELECT  ISNULL(GRNNO,'') AS GRNNO,ISNULL(GRNDETAILS,'') AS GRNDETAILS,ISNULL(PONO,'') AS PONO,GRNDATE,ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,"
                '    sqlstring = sqlstring & " SUPPLIERDATE,ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE,ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,ISNULL(CATEGORY,'') CATEGORY, "
                '    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,ISNULL(REMARKS,'') AS REMARKS,"
                '    sqlstring = sqlstring & " ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,ISNULL(voiddate,'') AS voiddate,"
                '    sqlstring = sqlstring & " ISNULL(STORECODE,'') STORECODE , ISNULL(STOREDESC,'MAINSTORE') STOREDESC, ISNULL(OVERALLDISCOUNT,0) OVERALLDISCOUNT FROM acc1920..GRN_HEADER"
                '    sqlstring = sqlstring & " WHERE ( Grndetails='" & Trim(txt_Grnno.Text) & "') "
                '    sqlstring = sqlstring & " and   isnull(GrnType,'')='GRN' union all"
                '    sqlstring = sqlstring & " SELECT  ISNULL(GRNNO,'') AS GRNNO,ISNULL(GRNDETAILS,'') AS GRNDETAILS,ISNULL(PONO,'') AS PONO,GRNDATE,ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,"
                '    sqlstring = sqlstring & " SUPPLIERDATE,ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE,ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,ISNULL(CATEGORY,'') CATEGORY, "
                '    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,ISNULL(REMARKS,'') AS REMARKS,"
                '    sqlstring = sqlstring & " ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,ISNULL(voiddate,'') AS voiddate,"
                '    sqlstring = sqlstring & " ISNULL(STORECODE,'') STORECODE , ISNULL(STOREDESC,'MAINSTORE') STOREDESC, ISNULL(OVERALLDISCOUNT,0) OVERALLDISCOUNT FROM GRN_HEADER"
                '    sqlstring = sqlstring & " WHERE ( Grndetails='" & Trim(txt_Grnno.Text) & "') "
                '    sqlstring = sqlstring & " and   isnull(GrnType,'')='GRN'"
                'Else
                sqlstring = "SELECT  ISNULL(GRNNO,'') AS GRNNO,ISNULL(GRNDETAILS,'') AS GRNDETAILS,ISNULL(PONO,'') AS PONO,GRNDATE,ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,"
                    sqlstring = sqlstring & " SUPPLIERDATE,ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE,ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,ISNULL(CATEGORY,'') CATEGORY, "
                    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,ISNULL(REMARKS,'') AS REMARKS,"
                    sqlstring = sqlstring & " ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,ISNULL(voiddate,'') AS voiddate,"
                    sqlstring = sqlstring & " ISNULL(STORECODE,'') STORECODE , ISNULL(STOREDESC,'MAINSTORE') STOREDESC, ISNULL(OVERALLDISCOUNT,0) OVERALLDISCOUNT FROM " & YEARSELECTION & ".. GRN_HEADER"
                    sqlstring = sqlstring & " WHERE ( Grndetails='" & Trim(txt_Grnno.Text) & "') "
                    sqlstring = sqlstring & " and   isnull(GrnType,'')='GRN'"

                '    End If
                'Else
                '    sqlstring = "SELECT  ISNULL(GRNNO,'') AS GRNNO,ISNULL(GRNDETAILS,'') AS GRNDETAILS,ISNULL(PONO,'') AS PONO,GRNDATE,ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,"
                '    sqlstring = sqlstring & " SUPPLIERDATE,ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE,ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,ISNULL(CATEGORY,'') CATEGORY, "
                '    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,ISNULL(REMARKS,'') AS REMARKS,"
                '    sqlstring = sqlstring & " ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,ISNULL(voiddate,'') AS voiddate,"
                '    sqlstring = sqlstring & " ISNULL(STORECODE,'') STORECODE , ISNULL(STOREDESC,'MAINSTORE') STOREDESC, ISNULL(OVERALLDISCOUNT,0) OVERALLDISCOUNT FROM GRN_HEADER"
                '    sqlstring = sqlstring & " WHERE ( Grndetails='" & Trim(txt_Grnno.Text) & "') "
                '    sqlstring = sqlstring & " and   isnull(GrnType,'')='GRN'"
                'End If
                gconnection.getDataSet(sqlstring, "GRNHEADER")
                '''************************************************* SELECT record from Grn_header *********************************************''''                
                If gdataset.Tables("GRNHEADER").Rows.Count > 0 Then
                    'Call GridUnLock()
                    ' Cmd_Add.Text = "Update[F7]"
                    Me.txt_Grnno.ReadOnly = True
                    If gvendorlink = "Y" Then
                        txt_Suppliercode.Enabled = False
                        cmd_Suppliercodehelp.Enabled = False
                    End If
                    Dim SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "'"
                    gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                    If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                        CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                        CMB_CATEGORY.Enabled = False
                    End If


                    Dim index As Integer
                    index = CMB_CATEGORY.FindString(Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC")))
                    CMB_CATEGORY.SelectedIndex = index

                    'CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY"))
                    Txt_PONo.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO"))
                    Dim grnTYPE() As String = Split(Txt_PONo.Text, "/")
                    If grnTYPE(0) = "CCL" Then
                        Txt_PONo.Show()
                        Label4.Show()
                        cmd_PONOhelp.Show()
                        CmbGrnType.Text = "PO"
                    Else
                        CmbGrnType.Text = "SPONSOR"
                        LBL_SPONSOR.Show()
                        TXT_Sponsor.Show()
                        cmd_SPONhelp.Show()
                        TXT_Sponsor.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO"))
                    End If
                    txt_Grnno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDETAILS"))



                    dtp_Grndate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDATE")), "dd/MMM/yyyy")
                    dtp_Grndate.Enabled = False
                    txt_Supplierinvno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERINVNO"))
                    dtp_Supplierinvdate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERDATE")), "dd/MMM/yyyy")
                    txt_Suppliercode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERCODE"))
                    txt_Suppliername.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERNAME"))
                    txt_Storecode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("STORECODE"))
                    txt_StoreDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("STOREDESC"))
                    TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("OVERALLdiscount")), "0.000")
                    txt_Surchargeamt.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("SURCHARGEAMT")), "0.000")
                    txt_Billamount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("BILLAMOUNT")), "0.000")
                    txt_Remarks.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("REMARKS"))
                    'If Trim(UCase(gShortname)) = "SATC" Then
                    '    sqlstring = " select isnull(sum(qty),0)as purqty, isnull(sum(ret_qty),0)as retqty from acc1920..Grn_details where grndetails='" + txt_Grnno.Text + "' union all "
                    '    sqlstring = sqlstring & " select isnull(sum(qty),0)as purqty, isnull(sum(ret_qty),0)as retqty from Grn_details where grndetails='" + txt_Grnno.Text + "'"
                    'Else
                    sqlstring = " select sum(qty)as purqty,sum(isnull(ret_qty,0))as retqty from " & YEARSELECTION & "..Grn_details where grndetails='" + txt_Grnno.Text + "' "
                    '  End If
                    'Else
                    '        sqlstring = " select sum(qty)as purqty,sum(isnull(ret_qty,0))as retqty from Grn_details where grndetails='" + txt_Grnno.Text + "' "
                    '    End If
                    gconnection.getDataSet(sqlstring, "qty")
                    Dim retqty, purqty As Double
                    If gdataset.Tables("qty").Rows.Count > 0 Then
                        retqty = Val(gdataset.Tables("qty").Rows(0).Item("retqty"))
                        purqty = Val(gdataset.Tables("qty").Rows(0).Item("purqty"))
                        If retqty >= purqty Then
                            Cmd_Add.Enabled = False
                            Cmd_Freeze.Enabled = False
                            Me.lbl_Freeze.Text = "Record Return  "
                        End If
                    End If

                    If Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("VOID")) = "Y" Then
                        Cmd_Add.Enabled = False
                        Cmd_Freeze.Enabled = False
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("voiddate")), "dd/MMM/yyyy")
                    End If
                    '''************************************************* SELECT record from Grn_details *********************************************''''                
                    Dim vtmpitemcode, strsql As String
                    'If Trim(UCase(gShortname)) = "SATC" Then
                    '    sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,isnull(baseamount,0) as baseamount,isnull(discper,0) as discper,isnull(taxcode,'') as taxcode,isnull(batchno,'') as batchno,"
                    '    sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(TAXPER,0) AS TAXPER,ISNULL(TAXAMOUNT,0) AS TAXAMOUNT,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,ISNULL(AMOUNTAFTERDISCOUNT,0) AS AMOUNTAFTERDISCOUNT,"
                    '    sqlstring = sqlstring & " ISNULL(VOIDITEM,'') AS VOIDITEM , isnull(OTHCHARGE,0) AS OTHCHARGE,isnull(freeqty,0) AS freeqty,ISNULL(FQUOM,'') AS FQUOM,isnull(ret_qty,0) as ret_qty,ISNULL(SPLCESS,0) AS SPLCESS  FROM acc1920..GRN_DETAILS WHERE  GRNDETAILS ='" & Trim(txt_Grnno.Text) & "' union all"
                    '    sqlstring = sqlstring & " SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,isnull(baseamount,0) as baseamount,isnull(discper,0) as discper,isnull(taxcode,'') as taxcode,isnull(batchno,'') as batchno,"
                    '    sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(TAXPER,0) AS TAXPER,ISNULL(TAXAMOUNT,0) AS TAXAMOUNT,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,ISNULL(AMOUNTAFTERDISCOUNT,0) AS AMOUNTAFTERDISCOUNT,"
                    '    sqlstring = sqlstring & " ISNULL(VOIDITEM,'') AS VOIDITEM , isnull(OTHCHARGE,0) AS OTHCHARGE,isnull(freeqty,0) AS freeqty,ISNULL(FQUOM,'') AS FQUOM,isnull(ret_qty,0) as ret_qty,ISNULL(SPLCESS,0) AS SPLCESS  FROM GRN_DETAILS WHERE  GRNDETAILS ='" & Trim(txt_Grnno.Text) & "'"
                    '  Else
                    sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,isnull(baseamount,0) as baseamount,isnull(discper,0) as discper,isnull(taxcode,'') as taxcode,isnull(batchno,'') as batchno,"
                        sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(TAXPER,0) AS TAXPER,ISNULL(TAXAMOUNT,0) AS TAXAMOUNT,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,ISNULL(AMOUNTAFTERDISCOUNT,0) AS AMOUNTAFTERDISCOUNT,"
                        sqlstring = sqlstring & " ISNULL(VOIDITEM,'') AS VOIDITEM , isnull(OTHCHARGE,0) AS OTHCHARGE,isnull(freeqty,0) AS freeqty,ISNULL(FQUOM,'') AS FQUOM,isnull(ret_qty,0) as ret_qty,ISNULL(SPLCESS,0) AS SPLCESS  FROM  " & YEARSELECTION & "..GRN_DETAILS WHERE  GRNDETAILS ='" & Trim(txt_Grnno.Text) & "'"
                        sqlstring = sqlstring & " ORDER BY AUTOID "
                    ' End If
                    'Else
                    '        sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,isnull(baseamount,0) as baseamount,isnull(discper,0) as discper,isnull(taxcode,'') as taxcode,isnull(batchno,'') as batchno,"
                    '        sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(TAXPER,0) AS TAXPER,ISNULL(TAXAMOUNT,0) AS TAXAMOUNT,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,ISNULL(AMOUNTAFTERDISCOUNT,0) AS AMOUNTAFTERDISCOUNT,"
                    '        sqlstring = sqlstring & " ISNULL(VOIDITEM,'') AS VOIDITEM , isnull(OTHCHARGE,0) AS OTHCHARGE,isnull(freeqty,0) AS freeqty,ISNULL(FQUOM,'') AS FQUOM,isnull(ret_qty,0) as ret_qty,ISNULL(SPLCESS,0) AS SPLCESS  FROM GRN_DETAILS WHERE  GRNDETAILS ='" & Trim(txt_Grnno.Text) & "'"
                    '        sqlstring = sqlstring & " ORDER BY AUTOID "
                    '    End If

                    gconnection.getDataSet(sqlstring, "GRNDETAILS")
                    If gdataset.Tables("GRNDETAILS").Rows.Count > 0 Then
                        For I = 1 To gdataset.Tables("GRNDETAILS").Rows.Count
                            AxfpSpread1.SetText(1, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE")))
                            vtmpitemcode = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMNAME")))

                            AxfpSpread1.SetText(3, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM")))

                            Dim sql1 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("GRNDETAILS").Rows(J).Item("itemcode") + "'"
                            AxfpSpread1.Col = 3
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

                            'AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))

                            'AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                            AxfpSpread1.SetText(3, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM")))

                            '   AxfpSpread1.Text = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))

                            AxfpSpread1.SetText(4, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("QTY")) - Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("ret_QTY")))

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
                            AxfpSpread1.SetText(19, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("SPLCESS")), "0.000"))

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

                    SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "'"
                    gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                    If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                        CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                        CMB_CATEGORY.Enabled = False
                    End If

                    'TotalCount = gdataset.Tables("GRNDETAILS").Rows.Count
                    CALCULATE()
                    Txt_PONo.ReadOnly = True
                    txt_Storecode.ReadOnly = True
                    txt_Suppliercode.ReadOnly = True
                    Cmd_Storecode.Enabled = False
                    cmd_Suppliercodehelp.Enabled = False
                    txt_Supplierinvno.ReadOnly = True
                    dtp_Supplierinvdate.Enabled = False
                    If gShortname = "CCL" Then
                        AxfpSpread1.SetActiveCell(1, 1)
                        AxfpSpread1.Focus()
                    Else
                        AxfpSpread1.SetActiveCell(4, 1)
                        AxfpSpread1.Focus()
                    End If
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    ' Cmd_Add.Text = "Update[F7]"

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
        If calcbool = False Then
            CALCULATE()
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


        Dim TaType = TaxType("PRN", Trim(Txt_PRNNo.Text), Format(CDate(dtp_Prndate.Value), "dd/MMM/yyyy"))


        If TaType = "GST" Or TaType = "IGST" Or TaType = "TAXL" Then

            If TaType = "IGST" Then
                Try
                    ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL As String
                    Dim r As New Rpt_PrnBillIGST
                    sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(PRNDETAILS,'') AS pRNDETAILS,CAST(pRNDATE AS DATE),  ISNULL(GRNDETAILS,'') AS GRNDETAILS,CAST(GRNDATE AS DATE), ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                    sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                    sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                    sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt ,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE  "
                    sqlstring = sqlstring & " FROM VW_INV_PRNBILL "
                    sqlstring = sqlstring & " WHERE pRNDETAILS = '" & Trim(Txt_PRNNo.Text) & "'"
                    'If rdo_code.Checked = True Then
                    '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                    'ElseIf rdo_name.Checked = True Then
                    '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                    'Else
                    sqlstring = sqlstring & " ORDER BY AUTOID ,pRNDETAILS,pRNDATE "
                    'End If
                    gconnection.getDataSet(sqlstring, "VW_INV_PRNBILL")
                    If gdataset.Tables("VW_INV_PRNBILL").Rows.Count > 0 Then
                        'If chk_excel.Checked = True Then
                        '    Dim exp As New exportexcel
                        '    exp.Show()
                        '    Call exp.export(sqlstring, "GRN CUM PURCHASE BILL ", "")
                        'Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "VW_INV_pRNBILL"
                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text13")
                        textobj1.Text = MyCompanyName
                        Dim textobj14 As TextObject
                        textobj14 = r.ReportDefinition.ReportObjects("Text32")
                        textobj14.Text = UCase(Address1)
                        Dim textobj16 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text33")
                        textobj1.Text = UCase(Address2)
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
            ElseIf TaType = "TAXL" Then
                Try
                    ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL As String
                    Dim r As New Rpt_PrnBill
                    sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(PRNDETAILS,'') AS pRNDETAILS,CAST(pRNDATE AS DATE),  ISNULL(GRNDETAILS,'') AS GRNDETAILS,CAST(GRNDATE AS DATE), ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                    sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                    sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                    sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt ,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE  "
                    sqlstring = sqlstring & " FROM VW_INV_PRNBILL "
                    sqlstring = sqlstring & " WHERE pRNDETAILS = '" & Trim(Txt_PRNNo.Text) & "'"
                    'If rdo_code.Checked = True Then
                    '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                    'ElseIf rdo_name.Checked = True Then
                    '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                    'Else
                    sqlstring = sqlstring & " ORDER BY AUTOID ,pRNDETAILS,pRNDATE "
                    'End If
                    gconnection.getDataSet(sqlstring, "VW_INV_PRNBILL")
                    If gdataset.Tables("VW_INV_PRNBILL").Rows.Count > 0 Then
                        'If chk_excel.Checked = True Then
                        '    Dim exp As New exportexcel
                        '    exp.Show()
                        '    Call exp.export(sqlstring, "GRN CUM PURCHASE BILL ", "")
                        'Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "VW_INV_pRNBILL"
                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text13")
                        textobj1.Text = MyCompanyName
                        Dim textobj14 As TextObject
                        textobj14 = r.ReportDefinition.ReportObjects("Text32")
                        textobj14.Text = UCase(Address1)
                        Dim textobj16 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text33")
                        textobj1.Text = UCase(Address2)
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
            Else
                Try
                    ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL As String
                    Dim r As New Rpt_PrnBill
                    sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(PRNDETAILS,'') AS pRNDETAILS,CAST(pRNDATE AS DATE),  ISNULL(GRNDETAILS,'') AS GRNDETAILS,CAST(GRNDATE AS DATE), ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                    sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                    sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                    sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt ,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE  "
                    sqlstring = sqlstring & " FROM VW_INV_PRNBILL "
                    sqlstring = sqlstring & " WHERE pRNDETAILS = '" & Trim(Txt_PRNNo.Text) & "'"
                    'If rdo_code.Checked = True Then
                    '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                    'ElseIf rdo_name.Checked = True Then
                    '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                    'Else
                    sqlstring = sqlstring & " ORDER BY AUTOID ,pRNDETAILS,pRNDATE "
                    'End If
                    gconnection.getDataSet(sqlstring, "VW_INV_PRNBILL")
                    If gdataset.Tables("VW_INV_PRNBILL").Rows.Count > 0 Then
                        'If chk_excel.Checked = True Then
                        '    Dim exp As New exportexcel
                        '    exp.Show()
                        '    Call exp.export(sqlstring, "GRN CUM PURCHASE BILL ", "")
                        'Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "VW_INV_pRNBILL"
                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text13")
                        textobj1.Text = MyCompanyName
                        Dim textobj14 As TextObject
                        textobj14 = r.ReportDefinition.ReportObjects("Text32")
                        textobj14.Text = UCase(Address1)
                        Dim textobj16 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text33")
                        textobj1.Text = UCase(Address2)
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
            End If
            
        Else
            Try
                ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
                Dim rViewer As New Viewer
                Dim sqlstring, SSQL As String
                Dim r As New Rpt_PrnBill
                sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(PRNDETAILS,'') AS pRNDETAILS,CAST(pRNDATE AS DATE)AS pRNDATE ,  ISNULL(GRNDETAILS,'') AS GRNDETAILS,CAST(GRNDATE AS DATE) AS GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE  "
                sqlstring = sqlstring & " FROM VW_INV_PRNBILL "
                sqlstring = sqlstring & " WHERE pRNDETAILS = '" & Trim(Txt_PRNNo.Text) & "'"
                'If rdo_code.Checked = True Then
                '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                'ElseIf rdo_name.Checked = True Then
                '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                'Else
                sqlstring = sqlstring & " ORDER BY AUTOID ,pRNDETAILS,pRNDATE "
                'End If
                gconnection.getDataSet(sqlstring, "VW_INV_PRNBILL")
                If gdataset.Tables("VW_INV_PRNBILL").Rows.Count > 0 Then
                    'If chk_excel.Checked = True Then
                    '    Dim exp As New exportexcel
                    '    exp.Show()
                    '    Call exp.export(sqlstring, "GRN CUM PURCHASE BILL ", "")
                    'Else
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "VW_INV_pRNBILL"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text13")
                    textobj1.Text = MyCompanyName
                    Dim textobj14 As TextObject
                    textobj14 = r.ReportDefinition.ReportObjects("Text32")
                    textobj14.Text = UCase(Address1)
                    Dim textobj16 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text33")
                    textobj1.Text = UCase(Address2)
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
        End If

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cmd_View_Click(sender, e)
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub lbl_Freeze_Click(sender As Object, e As EventArgs) Handles lbl_Freeze.Click

    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        If MessageBox.Show("Do You Want void it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then
            Exit Sub
        End If

        If validateonvoid() = False Then
            voidoperation()


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
            strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Prndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode)
            sqlstring = " exec proc_closingqtyone 'PRN_VOID' "
            gconnection.ExcuteStoreProcedure(sqlstring)
            'Dim sqls As String
            'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
            'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
            'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
            'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
            ''gconnection.ExcuteStoreProcedure(SQLS)
            'gconnection.ExcuteStoreProcedure(sqls)
            sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
            gconnection.ExcuteStoreProcedure(sqlstring)



            clearoperation()


        End If
    End Sub

    Private Sub CMB_CATEGORY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_CATEGORY.SelectedIndexChanged
        autogenerate()
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
            LBL_SPONSOR.Show()
            TXT_Sponsor.Show()
            cmd_SPONhelp.Show()
        Else

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





    Private Sub TXT_Sponsor_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_Sponsor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TXT_Sponsor.Text <> "" Then
                Call txt_GroupCode_Validated(TXT_Sponsor, e)
            Else
                Call cmd_SPONhelp_Click(TXT_Sponsor.Text, e)
            End If
        End If
    End Sub


    Private Sub cmd_Prnnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Prnnohelp.Click

        Try
            Dim voidStatus As String
            Dim vform As New List_Operation

            CATCODE = Split(CMB_CATEGORY.Text, "--->")
            '  CATCODE = Split(Trim(Mid(CMB_CATEGORY.Text, 1, 3)), "--->")
            'If Trim(UCase(gShortname)) = "CGC" Then
            '    voidStatus = " and void ='N'"
            'Else
            '    voidStatus = ""
            'End If

            gSQLString = "SELECT Prndetails,Prndate,GRNDETAILS FROM Prn_header"
            ' M_WhereCondition = " Where Isnull(RNTYPE,'')='GRN' " & voidStatus & "  AND ISNULL(GRNDETAILS,'') LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%'"
            M_WhereCondition = " "
            M_ORDERBY = "  order by Prndate desc "

            vform.Field = "PRNDETAILS,PRNDATE,GRNDETAILS"
            vform.vFormatstring1 = "       PRN NO                     |         PRN DATE                    |         GRN DETAILS              "
            vform.vCaption = " PURCHASE RETURN BILL HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_PRNNo.Text = Trim(vform.keyfield & "")

                Call Txt_PRNNo_Validated(Txt_PRNNo.Text, e)

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

    Private Sub Txt_PRNNo_Validated(sender As Object, e As EventArgs) Handles Txt_PRNNo.Validated
        Dim I, J, K As Integer
        Dim vString, sqlstring As String
        Dim GRNDATE As Date
        Dim vTypeseqno, Clsquantity As Double
        Dim vGroupseqno As Double
        Dim dt As New DataTable
        If Trim(Txt_PRNNo.Text) <> "" Then
            Try
                sqlstring = "SELECT  ISNULL(PRNNO,'') AS PRNNO,ISNULL(PRNDETAILS,'') AS PRNDETAILS,PRNDATE,ISNULL(GRNDETAILS,'') AS GRNDETAILS,ISNULL(PONO,'') AS PONO,GRNDATE,ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,"
                sqlstring = sqlstring & " SUPPLIERDATE,ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE,ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,ISNULL(CATEGORY,'') CATEGORY, "
                sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,ISNULL(REMARKS,'') AS REMARKS,"
                sqlstring = sqlstring & " ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,ISNULL(voiddate,'') AS voiddate,"
                sqlstring = sqlstring & " ISNULL(STORECODE,'') STORECODE , ISNULL(STOREDESC,'MAINSTORE') STOREDESC, ISNULL(OVERALLDISCOUNT,0) OVERALLDISCOUNT,ISNULL(TotGSTAmt,0) AS TotGSTAmt,ISNULL(TotSGSTAmt,0) AS TotSGSTAmt,ISNULL(TotCGSTAmt,0) AS TotCGSTAmt,ISNULL(TotIGSTAmt,0) AS TotIGSTAmt,ISNULL(TOTSPLCESS,0) AS TOTSPLCESS FROM PRN_HEADER"
                sqlstring = sqlstring & " WHERE ( Prndetails='" & Trim(Txt_PRNNo.Text) & "') "
                sqlstring = sqlstring & " and   isnull(GrnType,'')='PRN'"
                gconnection.getDataSet(sqlstring, "PRN_HEADER")
                '''************************************************* SELECT record from Grn_header *********************************************''''                
                If gdataset.Tables("PRN_HEADER").Rows.Count > 0 Then

                    If Val(Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("TotGSTAmt"))) = Val(Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("TotSGSTAmt"))) + Val(Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("TotCGSTAmt"))) + Val(Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("TotIGSTAmt"))) Then
                        VATFLAG = False
                    Else
                        VATFLAG = True
                    End If

                    'Call GridUnLock()
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Grnno.ReadOnly = True
                    If gvendorlink = "Y" Then
                        txt_Suppliercode.Enabled = False
                        cmd_Suppliercodehelp.Enabled = False
                    End If
                    Dim SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("CATEGORY")) + "'"
                    gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                    If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                        CMB_CATEGORY.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("CATEGORY")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                    End If
                    'CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY"))
                    ' Txt_PONo.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO"))
                    'SQL = " SELECT * FROM INV_SPONSORMASTER where ISNULL(Freeze,'N')<>'Y' and  SPONSORCODE='" + Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("PONO")) + "'"
                    'gconnection.getDataSet(SQL, "INV_SPONSORMASTER")
                    'If (gdataset.Tables("INV_SPONSORMASTER").Rows.Count > 0) Then
                    '    CmbGrnType.Text = "SPONSOR"
                    '    LBL_SPONSOR.Show()
                    '    TXT_Sponsor.Show()
                    '    cmd_SPONhelp.Show()
                    '    TXT_Sponsor.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("PONO"))
                    'Else
                    '    Txt_PONo.Show()
                    '    Label4.Show()
                    '    cmd_PONOhelp.Show()
                    '    CmbGrnType.Text = "PO"
                    'End If


                    Txt_PONo.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("PONO"))

                    txt_Grnno.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("GRNDETAILS"))
                    txt_Grnno.Enabled = False
                    Txt_PRNNo.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("PRNDETAILS"))

                    dtp_Prndate.Value = Format(CDate(gdataset.Tables("PRN_HEADER").Rows(0).Item("PRNDATE")), "dd/MMM/yyyy")
                    dtp_Grndate.Value = Format(CDate(gdataset.Tables("PRN_HEADER").Rows(0).Item("GRNDATE")), "dd/MMM/yyyy")
                    'dtp_Grndate.Enabled = False
                    txt_Supplierinvno.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("SUPPLIERINVNO"))
                    dtp_Supplierinvdate.Value = Format(CDate(gdataset.Tables("PRN_HEADER").Rows(0).Item("SUPPLIERDATE")), "dd/MMM/yyyy")
                    txt_Suppliercode.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("SUPPLIERCODE"))
                    txt_Suppliername.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("SUPPLIERNAME"))
                    txt_Storecode.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("STORECODE"))
                    txt_StoreDesc.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("STOREDESC"))
                    TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("PRN_HEADER").Rows(0).Item("OVERALLdiscount")), "0.000")
                    txt_Surchargeamt.Text = Format(Val(gdataset.Tables("PRN_HEADER").Rows(0).Item("SURCHARGEAMT")), "0.000")
                    txt_Billamount.Text = Format(Val(gdataset.Tables("PRN_HEADER").Rows(0).Item("BILLAMOUNT")), "0.000")
                    Txt_SPLCESS.Text = Format(Val(gdataset.Tables("PRN_HEADER").Rows(0).Item("TOTSPLCESS")), "0.000")
                    txt_Remarks.Text = Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("REMARKS"))
                    If Trim(gdataset.Tables("PRN_HEADER").Rows(0).Item("VOID")) = "Y" Then
                        Cmd_Add.Enabled = False
                        Cmd_Freeze.Enabled = False
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("PRN_HEADER").Rows(0).Item("voiddate")), "dd/MMM/yyyy")
                        Me.lbl_Freeze.Visible = True



                    End If
                    '''************************************************* SELECT Record from Grn_details *********************************************''''                
                    Dim vtmpitemcode, strsql As String
                    sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,isnull(baseamount,0) as baseamount,isnull(discper,0) as discper,isnull(taxcode,'') as taxcode,isnull(batchno,'') as batchno,"
                    sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(TAXPER,0) AS TAXPER,ISNULL(TAXAMOUNT,0) AS TAXAMOUNT,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,ISNULL(AMOUNTAFTERDISCOUNT,0) AS AMOUNTAFTERDISCOUNT,"
                    sqlstring = sqlstring & " ISNULL(VOIDITEM,'') AS VOIDITEM , isnull(OTHCHARGE,0) AS OTHCHARGE,isnull(freeqty,0) AS freeqty,ISNULL(FQUOM,'') AS FQUOM,ISNULL(SPLCESS,0) AS SPLCESS FROM PRN_DETAILS WHERE  PRNDETAILS ='" & Trim(Txt_PRNNo.Text) & "'"
                    sqlstring = sqlstring & " ORDER BY AUTOID "
                    gconnection.getDataSet(sqlstring, "PRN_DETAILS")
                    AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                    If gdataset.Tables("PRN_DETAILS").Rows.Count > 0 Then
                        For I = 1 To gdataset.Tables("PRN_DETAILS").Rows.Count
                            AxfpSpread1.SetText(1, I, Trim(gdataset.Tables("PRN_DETAILS").Rows(J).Item("ITEMCODE")))
                            vtmpitemcode = Trim(gdataset.Tables("PRN_DETAILS").Rows(J).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, I, Trim(gdataset.Tables("PRN_DETAILS").Rows(J).Item("ITEMNAME")))
                            AxfpSpread1.Col = 3
                            Dim sql1 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("PRN_DETAILS").Rows(J).Item("itemcode") + "'"

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
                            AxfpSpread1.SetText(3, I, Trim(gdataset.Tables("PRN_DETAILS").Rows(J).Item("UOM")))

                            '  AxfpSpread1.Text = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                            AxfpSpread1.SetText(4, I, Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("QTY")))
                            AxfpSpread1.SetText(5, I, Format(Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("RATE")), "0.000"))
                            AxfpSpread1.SetText(6, I, Format(Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("baseamount")), "0.000"))
                            '            ssgrid.SetText(7, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("PROFITPER")), "0.000"))
                            AxfpSpread1.SetText(7, I, Format(Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("discper")), "0.000"))
                            AxfpSpread1.SetText(8, I, Format(Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("discount")), "0.000"))
                            AxfpSpread1.SetText(9, I, Format(Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("amountafterdiscount")), "0.000"))

                            AxfpSpread1.SetText(11, I, Format(Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("taxper")), "0.000"))
                            AxfpSpread1.SetText(12, I, Format(Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("taxamount")), "0.000"))
                            AxfpSpread1.SetText(13, I, Format(Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("amount")), "0.000"))
                            AxfpSpread1.SetText(10, I, gdataset.Tables("PRN_DETAILS").Rows(J).Item("taxcode"))
                            AxfpSpread1.SetText(14, I, gdataset.Tables("PRN_DETAILS").Rows(J).Item("batchno"))
                            AxfpSpread1.SetText(15, I, Format(Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("othcharge")), "0.000"))
                            AxfpSpread1.SetText(16, I, gdataset.Tables("PRN_DETAILS").Rows(J).Item("voiditem"))
                            AxfpSpread1.SetText(17, I, Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("FREEQTY")))
                            AxfpSpread1.SetText(18, I, gdataset.Tables("PRN_DETAILS").Rows(J).Item("FQUOM"))
                            AxfpSpread1.SetText(19, I, Format(Val(gdataset.Tables("PRN_DETAILS").Rows(J).Item("SPLCESS")), "0.000"))
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

                    'TotalCount = gdataset.Tables("GRNDETAILS").Rows.Count
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(1, 1)
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Cmd_Add.Text = "Update[F7]"

                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid GRN No : txt_Grnno_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub AxfpSpread1_LeaveCell(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread1.LeaveCell
        Dim i As Integer
        Dim SQL As String
        i = AxfpSpread1.ActiveRow
        'ITEMCODE
        AxfpSpread1.Row = i
        If AxfpSpread1.ActiveCol = 4 Then


            AxfpSpread1.Col = 4
            If Trim(AxfpSpread1.Text) = "" Then
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            Else
                AxfpSpread1.Col = 1
                SQL = "Select isnull(qty,0) as qty,isnull(ret_qty,0) as ret_qty  from Grn_details where grndetails='" + txt_Grnno.Text + "' and itemcode='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(SQL, "grndetails")
                If (gdataset.Tables("grndetails").Rows.Count > 0) Then
                    ' Dim qtyrange As Double = Val(gdataset.Tables("grndetails").Rows(0).Item("qtyrange"))
                    Dim qty As Double = Val(gdataset.Tables("grndetails").Rows(0).Item("qty"))
                    Dim ret_qty As Double = Val(gdataset.Tables("grndetails").Rows(0).Item("ret_qty"))
                    AxfpSpread1.Col = 4
                    If (qty - ret_qty) < Val(AxfpSpread1.Text) Then
                        MessageBox.Show("Quantity Cannot be Greater than GRN Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        AxfpSpread1.Text = Val(qty - ret_qty)
                        CALCULATE()
                    Else
                        CALCULATE()

                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    End If
                Else
                    CALCULATE()

                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                End If
            End If
        End If
    End Sub
End Class