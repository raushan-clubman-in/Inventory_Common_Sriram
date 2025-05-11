Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_GRNTAMIL
    Dim gconnection As New GlobalClass
    Dim sql As String
    Dim GRNno(), versionno, CATCODE() As String
    Dim GrnQuery(0) As String
    Dim accode, acdesc, taxcode As String
    Dim overalldiscountpo, otherchargepo, totpoqty As Double
    Dim slcode, sldesc, costcode, costdesc, decription As String
    Dim potype, sqlstring As String
    Dim issuedocno As String
    Dim gdate As DateTime
    Dim amt As Double
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
            sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER WHERE SUBSTRING(GRNDETAILS,5," & CATLEN & ")='" & category & "'  AND ISNULL(GRNTYPE,'')='GRN'"
            '        sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    txt_Grnno.Text = "GRN/" & category & "/" & "0001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    txt_Grnno.Text = "GRN/" & category & "/" & Format(gdreader(0) + 1, "0000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txt_Grnno.Text = "GRN/" & category & "/0001/" & financalyear
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

    Private Sub Frm_GRN_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F2 Then
                txt_Grnno.Text = ""
                txt_Grnno.Focus()
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 Then
                Call Cmd_Add_Click(Cmd_Add, e)
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

    Private Sub Frm_GRN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'sqlstring = "  Select isnull(MSupplier,'N') as MSupplier  from inv_linksetup"
        'gconnection.getDataSet(sqlstring, "inv_linksetup")

        'If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
        '    If (gdataset.Tables("inv_linksetup").Rows(0).Item("MSupplier").ToString() = "Y") Then
        '        GSUPPLIER = "Y"
        '    Else
        '        GSUPPLIER = "N"
        '    End If
        'End If
        ' GroupBox10.Controls.Add(AxfpSpread1)
        If (gpocode = "Y") Then
            grp_Grngroup1.Visible = True
        Else
            grp_Grngroup1.Visible = False
        End If
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
        'Me.DoubleBuffered = True
        ' Resize_Form()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        FillGRNTYPE()
        bindcategory()
        autogenerate()
        sqlstring = "Select getdate()"
        gdate = gconnection.getvalue(sqlstring)
        If GEXPIRY = "Y" Then
            AxfpSpread1.Col = 24
            AxfpSpread1.ColHidden = False
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

                M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "')  and  slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' ) AND ISNULL(FREEZEFLAG,'')<>'Y'"
            Else

                M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "')  AND AND ISNULL(FREEZEFLAG,'')<>'Y'"
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
        If Guseraccess = "C" Then
            sqlstring = "Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "'"
            gconnection.getDataSet(sqlstring, "Invstore_CategoryMaster")

            gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
            If (gdataset.Tables("Invstore_CategoryMaster").Rows.Count > 0) Then
                M_WhereCondition = " where freeze <> 'Y' and storestatus='M'  and  storecode in ( Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"

            Else
                M_WhereCondition = " where freeze <> 'Y' and storestatus='M' "

            End If

        Else
            gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
            M_WhereCondition = " where ISNULL(freeze,'N') <> 'Y' and storestatus='M'  and  storecode in ( Select storecode from  Storeuserdetail where USERCODE='" + Trim(gUsername) + "' and isnull(void,'N')<>'Y' )"

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
    Private Function check_tAXtYPE(ByVal TAXGROUP As String) As Boolean
        Dim i As Integer
        Dim VAT, GST, OTHER As Boolean
        AxfpSpread1.Col = 10
        AxfpSpread1.Text = TAXGROUP
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i


            SQL = "SELECT * FROM vW_iNV_TAX_TYPE  where taxgroupcode='" & AxfpSpread1.Text & "'"
            gconnection.getDataSet(SQL, "vW_iNV_TAX_TYPE")
            If gdataset.Tables("vW_iNV_TAX_TYPE").Rows.Count > 0 Then
                For Z As Integer = 0 To gdataset.Tables("vW_iNV_TAX_TYPE").Rows.Count - 1
                    If Trim(gdataset.Tables("vW_iNV_TAX_TYPE").Rows(Z).Item("TYPE")) = "GST" Then
                        GST = True
                    ElseIf Trim(gdataset.Tables("vW_iNV_TAX_TYPE").Rows(Z).Item("TYPE")) = "VAT" Then
                        VAT = True
                    Else
                        OTHER = True
                    End If
                Next

            End If

            If GST = True And VAT = True Then
                MsgBox("Tax type should be same type. Plz check tax group  ", MsgBoxStyle.Critical, "Mismatch")
                AxfpSpread1.Text = ""
                AxfpSpread1.Col = 11
                AxfpSpread1.Text = ""
                CALCULATE()
                Return True
            End If


        Next
        Return False
    End Function
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
            M_WhereCondition = "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'  AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')"


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
                '' If CATCODE(0) = "LIQ" Or CATCODE(0) = "BAR" Then
                sql = "SELECT TOP 1   RATE as rate,UOM  FROM LiqRate WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' ORDER BY AUTOID DESC"
                gconnection.getDataSet(sql, "RATE")
                If (gdataset.Tables("RATE").Rows.Count > 0) Then
                    AxfpSpread1.Col = 3
                    AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("uom")

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



                '' End If
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
TTT:            sql = "select TAXCODE, taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + Trim(vform.keyfield) + "'"
                gconnection.getDataSet(sql, "Itemtaxtagging")
                If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                    If (check_tAXtYPE(gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxcode"))) = False Then
                        If check_VendorType(txt_Suppliercode.Text) Then
                            AxfpSpread1.Col = 10
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = ""

                            AxfpSpread1.Col = 11
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = "0"
                        Else
                            AxfpSpread1.Col = 10
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                            AxfpSpread1.Col = 11
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                        End If
                  
                    End If
                 
                    'AxfpSpread1.Col = 12
                    'AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    'AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("GLACCOUNTIN")
                Else

                    'If (gState = "TAMILNADU" And CATCODE(0) = "BAR") Then
                    'Else
                    If (MessageBox.Show("Do You Want to Create No TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Col = 1
                        Dim sst As String = "select count(*) from Itemtaxtagging where itemcode='" + AxfpSpread1.Text + "' "
                        If gconnection.getvalue(sst) = 0 Then
                            sql = "Insert into Itemtaxtagging(itemCode,Itemname,Taxcode,Taxdesc,taxperc,GLACCOUNTIN,void) values( "
                            sql = sql & " '" + AxfpSpread1.Text + "',"

                            AxfpSpread1.Col = 2
                            sql = sql & " '" + AxfpSpread1.Text.Replace("'", " ") + "',"



                            sql = sql & " 'NTAX',"


                            sql = sql & " 'NO TAX',"


                            sql = sql & " '0',"


                            sql = sql & " 'NTAX',"


                            sql = sql & " 'N')"
                            gconnection.dataOperation(6, sql, "Itemtaxtagging")
                        Else
                            sql = "Update Itemtaxtagging set "
                            '(Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,void,tablename,colname) values( "
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Col = 1

                            sql = sql & "itemCode= '" + AxfpSpread1.Text + "',"

                            AxfpSpread1.Col = 2
                            sql = sql & "Itemname= '" + AxfpSpread1.Text.Replace("'", " ") + "',"


                            AxfpSpread1.Col = 3
                            sql = sql & "Taxcode= 'NTAX',"

                            AxfpSpread1.Col = 4
                            sql = sql & "Taxdesc= 'NO TAX',"

                            AxfpSpread1.Col = 5
                            sql = sql & "taxperc= '0',"

                            AxfpSpread1.Col = 6
                            sql = sql & "GLACCOUNTIN= 'NTAX'"
                            ' Sql = Sql & " 'N'"
                            sql = sql & " where "

                            AxfpSpread1.Col = 1

                            sql = sql & "  ItemCode='" + AxfpSpread1.Text + "'"
                            gconnection.dataOperation(6, sql, "Itemtaxtagging")
                            GoTo TTT
                        End If

                    Else
                        MessageBox.Show("Create  TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If

                    'End If

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
        vform.vFormatstring = "    itemcode    |     Itemname              |       UOM     |"
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

                sql = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and ITEMCODE='" + Trim(vform.keyfield) + "' and isnull(contractyn,0)='1'"
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

                sql = "SELECT TOP 1   RATE as rate  FROM LiqRate WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' ORDER BY AUTOID DESC"
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
sss:            sql = "select TAXCODE, taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + Trim(vform.keyfield) + "'"
                gconnection.getDataSet(sql, "Itemtaxtagging")
                If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                    If (check_tAXtYPE(gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxcode"))) = False Then
                        AxfpSpread1.Col = 10
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                        AxfpSpread1.Col = 11
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                    End If

                Else
                    If (MessageBox.Show("Do You Want to Create No TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Col = 1
                        Dim sst As String = "select count(*) from Itemtaxtagging where itemcode='" + AxfpSpread1.Text + "' "
                        If gconnection.getvalue(sst) = 0 Then
                            sql = "Insert into Itemtaxtagging(itemCode,Itemname,Taxcode,Taxdesc,taxperc,GLACCOUNTIN,void) values( "
                            sql = sql & " '" + AxfpSpread1.Text + "',"

                            AxfpSpread1.Col = 2
                            sql = sql & " '" + AxfpSpread1.Text.Replace("'", " ") + "',"



                            sql = sql & " 'NTAX',"


                            sql = sql & " 'NO TAX',"


                            sql = sql & " '0',"


                            sql = sql & " 'NTAX',"


                            sql = sql & " 'N')"
                            gconnection.dataOperation(6, sql, "Itemtaxtagging")
                        Else
                            sql = "Update Itemtaxtagging set "
                            '(Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,void,tablename,colname) values( "
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Col = 1

                            sql = sql & "itemCode= '" + AxfpSpread1.Text + "',"

                            AxfpSpread1.Col = 2
                            sql = sql & "Itemname= '" + AxfpSpread1.Text.Replace("'", " ") + "',"


                            AxfpSpread1.Col = 3
                            sql = sql & "Taxcode= 'NTAX',"

                            AxfpSpread1.Col = 4
                            sql = sql & "Taxdesc= 'NO TAX',"

                            AxfpSpread1.Col = 5
                            sql = sql & "taxperc= '0',"

                            AxfpSpread1.Col = 6
                            sql = sql & "GLACCOUNTIN= 'NTAX'"
                            ' Sql = Sql & " 'N'"
                            sql = sql & " where "

                            AxfpSpread1.Col = 1

                            sql = sql & "  ItemCode='" + AxfpSpread1.Text + "'"
                            gconnection.dataOperation(6, sql, "Itemtaxtagging")
                            GoTo sss
                        End If

                    Else
                        MessageBox.Show("Create  TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If


                End If
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            End If
            End If

    End Sub


    Private Function validateonupdate() As Boolean
        Dim flag As Boolean

        Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"))
        If checkBdate = True Then
            MsgBox("Business date closed..")
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

        If Txt_Storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Storecode.BackColor = Color.Red
            Txt_Storecode.Focus()
            flag = True
            Return flag
        Else
            Txt_Storecode.BackColor = Color.White

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
            'Dim dc4 As New DataColumn("Rate", GetType(Double))
            'nonstockable.Columns.Add(dc4)

            Dim dc5 As New DataColumn("StoreCode", GetType(String))

            nonstockable.Columns.Add(dc5)

        End If
        If (gdirissue = "Y") Then
            For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
                AxfpSpread1.Row = i + 1

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
            Next
        End If
        If (gdirissue = "Y") Then
            If (nonstockable.Rows.Count > 0) Then
                MessageBox.Show("Item is Issued You Cant Update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Cmd_Add.Enabled = False
                flag = True
                Return flag
            End If
        End If

        Dim ComVen As Boolean = check_VendorType(txt_Suppliercode.Text)

        For i As Integer = 0 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 4
            Dim qty As Double = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 3
            Dim uom As String = AxfpSpread1.Text

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
            Dim sql As String = "select qty,batchyn from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'  "
            sql = sql & " and Trnno='" + txt_Grnno.Text + "' "
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
            End If
            sql = "select closingstock +" + Format(Val(qty - qty1), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(qty - qty1), "0.000") + "<0 and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + txt_Grnno.Text + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Updation create " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If

            If ComVen Then
                AxfpSpread1.Col = 11
                Dim taxper As Double = Val(AxfpSpread1.Text)
                'AxfpSpread1.Col = 8
                If (taxper > 0) Then
                    MessageBox.Show("No tax applicable for composite vendor", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag

                End If
            End If


        Next
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
        If txt_Supplierinvno.Text <> "" Then
            Dim sqlstring As String = "Select * from grn_header where Supplierinvno='" + txt_Supplierinvno.Text + "' and Suppliercode='" + txt_Suppliercode.Text + "'"
            gconnection.getDataSet(sqlstring, "grn_header")
            If (gdataset.Tables("grn_header").Rows.Count > 0) Then
                MessageBox.Show("Invoice No Already Exist", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag

            End If
        End If



        If txt_Grnno.Text = "" Then
            MessageBox.Show("Please Fill GrnNo ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

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

        Dim ComVen As Boolean = check_VendorType(txt_Suppliercode.Text)

        For j As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 1
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
                Call CALCULATE()
                flag = True
                Return flag

            End If

            If ComVen Then
                AxfpSpread1.Col = 11
                Dim taxper As Double = Val(AxfpSpread1.Text)
                'AxfpSpread1.Col = 8
                If (taxper > 0) Then
                    MessageBox.Show("No tax applicable for composite vendor", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag

                End If
            End If

            AxfpSpread1.Col = 6
            Dim grndisAmt As Double = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 8
            If (grndisAmt < Val(AxfpSpread1.Text)) Then
                MessageBox.Show("Discount Cannot be Greater than Amt.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(8, j)
                Call CALCULATE()
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
        Next


        If (GACCPOST.ToUpper() = "Y") Then
            For k As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = k
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) <> "" Then
                    sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")

                        If accode = "" Then

                            ' MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + +"")
                            MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR THIS ITEM:-'" & Trim(AxfpSpread1.Text) & "'")
                            flag = True
                            Return flag

                        End If
                    Else
                        MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR THIS ITEM:-'" & Trim(AxfpSpread1.Text) & "'")
                        flag = True
                        Return flag
                    End If
                End If

            Next
        End If


        If GEXPIRY = "Y" Then
            Dim ITEMCODE As String
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                ITEMCODE = AxfpSpread1.Text
                AxfpSpread1.Col = 24
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(EXPIRYDATE,'') AS EXPIRYDATE FROM INV_InventoryItemMaster WHERE ITEMCODE='" & ITEMCODE & "' AND  ISNULL(VOID,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "EXPIRYREQ")
                    Dim EXPIRY_REQ As String
                    EXPIRY_REQ = Trim(gdataset.Tables("EXPIRYREQ").Rows(0).Item("EXPIRYDATE"))
                    If gdataset.Tables("EXPIRYREQ").Rows.Count > 0 Then
                        If EXPIRY_REQ = "YES" Then
                            MessageBox.Show("Please Enter Expiry Date ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag
                        End If
                    End If
                End If
            Next
        End If
       

        

        If (gdirissue = "Y") Then
            If (nonstockable.Rows.Count > 0) Then
                Dim frm1 As New FrmDirectIssueing
                frm1.ShowDialog(Me)
                If (frm1.flg = True) Then

                    Dim itmcode, itmcodeprev, vvl, fvvl As String
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
                                fvvl = Nothing
                                AxfpSpread1.GetText(4, i, vvl)
                                AxfpSpread1.GetText(17, i, fvvl)
                                vvl = vvl + Val(fvvl)
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

    Private Function validateonvoid() As Boolean
        Dim flag As Boolean

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

        For i As Integer = 0 To AxfpSpread1.DataRowCnt
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
            sql = "select closingstock -" + Format(Val(qty), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
            sql = sql & " and closingstock -" + Format(Val(qty), "0.000") + "<0 "
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + txt_Grnno.Text + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Deletion create" + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If


        Next
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)
            flag = True
            Return flag
        End If

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


        If check_taxcode() = True Then

            flag = True
            Return flag


        End If
        Return False
    End Function


    Private Sub CALCULATE()
        Dim ITEMCODE, UOM As String

        Dim overalldisc, othercharge, extra, grossamt, loadingchr As Double
        Dim totqty, totamt, taxamt, discamt, freeqty, totfreeqty, margin, tax2, tax2amt, ittcsper, ittcsamt, totitemtcsamt, SPLCESS, TOSPLCESS As Double
        Dim itemqty, itemrate, itemamount, itemtax, itemdisc, discperc, taxperc, itemtot, amtwithoutdisc, overdiscextra, overotherextra As Double


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
            taxperc = Val(AxfpSpread1.Text)


            If ITEMCODE <> "" And UOM <> "" Then

                If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                    SPLCESS = GetSPLCESS(ITEMCODE, Trim(UOM))
                    TOSPLCESS = (SPLCESS * itemqty)
                    AxfpSpread1.Col = 22
                    AxfpSpread1.Text = TOSPLCESS
                Else
                    'SPLCESS = GetSPLCESS(ITEMCODE, Trim(UOM))
                    'TOSPLCESS = (SPLCESS * itemqty)
                    AxfpSpread1.Col = 22
                    'AxfpSpread1.Text = TOSPLCESS
                    TOSPLCESS = Val(AxfpSpread1.Text)
                End If
            Else
                AxfpSpread1.Col = 22
                SPLCESS = Format(AxfpSpread1.Text, "0.00")
            End If


            AxfpSpread1.Col = 12
            itemtax = (amtwithoutdisc * taxperc) / 100
            AxfpSpread1.Text = itemtax
            AxfpSpread1.Col = 17
            margin = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 18
            tax2 = Val(AxfpSpread1.Text)
            If (margin = 0) Then
                tax2amt = (tax2 * amtwithoutdisc) / 100
            Else
                tax2amt = (tax2 * margin) / 100
            End If

            AxfpSpread1.Col = 19
            tax2amt = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 20
            ittcsper = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 21

            itemamount = itemamount + (TOSPLCESS)

            ittcsamt = ((itemamount + itemtax + tax2amt - itemdisc) * ittcsper) / 100
            AxfpSpread1.Col = 13
            '''''''''''''''''''''''''''
            ' itemtot = itemamount + itemtax + tax2amt + ittcsamt - itemdisc
            tax2amt = 0
            itemtot = itemamount + itemtax - itemdisc

            '''''''''''''''''''''''''''

            AxfpSpread1.Text = itemtot
            totqty = totqty + itemqty
            totfreeqty = totfreeqty + freeqty
            totamt = totamt + itemamount
            taxamt = taxamt + itemtax + tax2amt
            discamt = discamt + itemdisc
            grossamt = grossamt + itemtot
            ' totitemtcsamt = ittcsamt + totitemtcsamt
            AxfpSpread1.Col = 23
            loadingchr = loadingchr + Val(AxfpSpread1.Text)
        Next

        Dim totitemtcsamt1 As Decimal
        totitemtcsamt1 = (totitemtcsamt / 10)
        Dim totitemtcsamt2 As Integer
        totitemtcsamt2 = totitemtcsamt - (Math.Floor(totitemtcsamt1) * 10)
        If (totitemtcsamt > 10) Then
            If (totitemtcsamt2 > 5) Then
                totitemtcsamt = totitemtcsamt + (10 - totitemtcsamt2)
            Else
                totitemtcsamt = totitemtcsamt ''- totitemtcsamt2
            End If
        Else
            If (totitemtcsamt > 1) Then
                totitemtcsamt = 10
            End If

        End If
        '''''''''''''''''''''''''''
        totitemtcsamt = 0
        '''''''''''''''''''''''''''
        totitemtcsamt = Math.Round(totitemtcsamt, 2)
        txt_totdisc.Text = discamt
        txt_totaltax.Text = Math.Round(taxamt, 2)
        txt_total.Text = totamt
        If (totitemtcsamt <> 0) Then
            Label7.Text = "IT-TCS @ " + ittcsper.ToString() + " % On Invoice Amount :" + totitemtcsamt.ToString()
            Label7.Visible = True
        Else
            Label7.Text = ""
            Label7.Visible = False
        End If

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
            txt_Surchargeamt.Text = Format(Val(overotherextra), "0.00")
            TXT_OVERALLdiscount.Text = Format(Val(overdiscextra), "0.00")

        End If
        '  txt_Billamount.Text = Format(Val(txt_total.Text) - Val(overalldisc) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.00")
        txtLoadingChrg.Text = Format(Val(loadingchr), "0.00")
        txt_Billamount.Text = Format(Val(txt_total.Text) - Val(TXT_OVERALLdiscount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text) + totitemtcsamt, "0.00")

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
                txt_Surchargeamt.Text = Format(Val(overotherextra), "0.00")
                TXT_OVERALLdiscount.Text = Format(Val(overdiscextra), "0.00")

            End If
            '  txt_Billamount.Text = Format(Val(txt_total.Text) - Val(overalldisc) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.00")

            txt_Billamount.Text = Format(Val(txt_total.Text) - Val(TXT_OVERALLdiscount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.00")

        End If
    End Sub
    Private Sub clearoperation()
        Txt_PONo.Text = ""
        autogenerate()
        dtp_Grndate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Suppliercode.Text = ""
        txt_Suppliername.Text = ""
        directgrn.Checked = False
        Label8.Text = ""
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
        Me.lbl_Freeze.Text = ""
        Cmd_Add.Enabled = True
        Me.lbl_Freeze.Visible = False
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        nonstockable.Columns.Clear()
        For k As Integer = 0 To 10
            For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                AxfpSpread1.TypeComboBoxClear(3, k)

            Next
        Next

        GridUnLock()
    End Sub
    Private Sub addoperation()
        Dim INSERT(0) As String

        Dim sqlstring As String
        Dim itemcode1 As String
        Dim uom As String
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        Dim weightedrate As Decimal
        Dim lastweightedrate As Double
        Dim STOCKUOM As String
        Dim CONVVALUE As Double
        Dim seq As Double
        Dim precise As Double
        GRNno = Split(Trim(txt_Grnno.Text), "/")
        CATCODE = Split(CMB_CATEGORY.Text, "--->")
        Call autogenerate()

        sqlstring = "INSERT INTO Grn_header(category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
        ' sqlstring = sqlstring & ",Typecode,Typedesc,Excisepassno,Excisedate,Stockindate,Trucknumber,Creditdays,Glaccountcode,Glaccountname,Slcode,Slname,Costcentercode,Costcentername,"
        sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,LoadingCharge)"
        sqlstring = sqlstring & " VALUES ('" & Trim(CATCODE(0)) & "','" & CStr(GRNno(2)) & "','" & Trim(CStr(txt_Grnno.Text)) & "',"
        sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
        sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
        '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
        '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
        ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
        sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.00") & "," & Format(Val(txt_totaltax.Text), "0.00") & "," & Format(Val(txt_Surchargeamt.Text), "0.00") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.00") & "," & Format(Val(txt_totdisc.Text), "0.00") & ","
        sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.00") & ","
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',getDate(),"
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
        sqlstring = sqlstring & "  'GRN','" + versionno + "'," & Format(Val(txtLoadingChrg.Text), "0.00") & ")"

        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
            If GEXPIRY = "Y" Then
                sqlstring = sqlstring & "ExpiryDate,"
            End If
            sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,Discount,amountafterdiscount,taxcode,TaxPer,taxamount,amount,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,margin,tax2,tax2amt,ittcs,ittcsamt,SPLCESS,LoadingChg)"
            sqlstring = sqlstring & " VALUES('" & CStr(GRNno(2)) & "','" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
            AxfpSpread1.Col = 1
            itemcode1 = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            If GEXPIRY = "Y" Then
                AxfpSpread1.Col = 24
                If AxfpSpread1.Text = "" Then
                    sqlstring = sqlstring & " '01/01/1900',"
                Else
                    sqlstring = sqlstring & " '" & Format(CDate(AxfpSpread1.Text), "dd/MMM/yyyy") & "',"
                End If
            End If
            AxfpSpread1.Col = 3
            uom = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            Dim qty1 As Double = Format(Val(AxfpSpread1.Text), "0.000")
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 5
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 6
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","

            AxfpSpread1.Col = 7
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

            AxfpSpread1.Col = 8
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 9
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 10
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

            AxfpSpread1.Col = 11
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 12
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","

            AxfpSpread1.Col = 13
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            totalamount = Val(AxfpSpread1.Text)
            ' sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
            AxfpSpread1.Col = 14
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 15
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            totalothchg = Val(AxfpSpread1.Text)

            AxfpSpread1.Col = 16
            sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

            sqlstring = sqlstring & "'" & Trim(CATCODE(0)) & "',"
            sqlstring = sqlstring & "'" & Trim(gUsername) & "',getDate(),"
            sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
            sqlstring = sqlstring & "'GRN','" + versionno + "',"
            AxfpSpread1.Col = 17
            sqlstring = sqlstring & "'" & Val(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 18
            sqlstring = sqlstring & "'" & Val(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 19
            sqlstring = sqlstring & "'" & Val(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 20
            sqlstring = sqlstring & "'" & Val(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 21
            sqlstring = sqlstring & "'" & Val(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 22
            sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 23
            sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.00") & ")"

            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            'updation in po_itemdetails
            AxfpSpread1.Col = 1
            itemcode1 = AxfpSpread1.Text
            sqlstring = "select isnull(receivedqty,0) as receivedqty ,isnull(qtystatus,'') as qtystatus,isnull(qtyrange,'') as qtyrange,isnull(quantity,0) as quantity,isnull(potype,'') as potype from  po_itemdetails inner join po_hdr on po_hdr.pono=po_itemdetails.pono and po_hdr.versionno=po_itemdetails.versionno where isnull(qtystatus,'') <> 'RECEIVED' and po_itemdetails.pono='" + Txt_PONo.Text + "' and"
            sqlstring = sqlstring & " itemcode='" + AxfpSpread1.Text + "' and po_itemdetails.versionno='" + versionno + "'"
            gconnection.getDataSet(sqlstring, "po_itemdetails")
            If (gdataset.Tables("po_itemdetails").Rows.Count > 0) Then
                Dim receivedqty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("receivedqty"))
                Dim quantity As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("quantity"))
                Dim qtyrange As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("qtyrange"))
                AxfpSpread1.Col = 4
                qty1 = Format(Val(AxfpSpread1.Text), "0.000")
                If ((gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "FIXED RATE FIXED QUANTITY") Or (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "OPEN RATE FIXED QUANTITY")) Then
                    If (qty1 < receivedqty + quantity) Then
                        AxfpSpread1.Col = 1
                        sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.00") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

                    Else
                        AxfpSpread1.Col = 1

                        sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.00") + ",qtystatus='RECEIVED' where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

                    End If
                ElseIf (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "RATE IN RANGE QUANTITY IN RANGE") Then
                    If ((quantity - qtyrange) < (receivedqty + qty1) Or (receivedqty + qty1) > (quantity + qtyrange)) Then
                        If (MessageBox.Show("Do You want to Close PO for:" + itemcode1, "Purchase Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
                            GoTo l
                        End If

                        AxfpSpread1.Col = 1
                        sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.00") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                    ElseIf (qty1 < receivedqty + quantity) Then
                        AxfpSpread1.Col = 1
                        sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.00") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

                    ElseIf (quantity + qtyrange = receivedqty + qty1) Or (receivedqty + qty1 = quantity - qtyrange) Then
                        AxfpSpread1.Col = 1
l:
                        sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.00") + ",qtystatus='RECEIVED' where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                    Else
                        MessageBox.Show("Quantity Can't be greater than PO Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    End If
                Else
                    AxfpSpread1.Col = 1
                    sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.00") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

                End If
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring
            End If


            sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode1 + "'"
            STOCKUOM = gconnection.getvalue(sqlstring)
            sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
            gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
            Else
                MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            Try

                Dim cmd As New SqlCommand("INV_SPWeightedRateCalculation", gconnection.Myconn)

                'Dim param As New SqlParameter
                'param.ParameterName = "@tpitemcode"
                'param.Value = itemcode1
                'cmd.Parameters.Add(param)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@ttodate", SqlDbType.DateTime).Value = Format(dtp_Grndate.Value.ToString("dd/MMM/yyyy"))
                cmd.Parameters.Add("@tpitemcode", SqlDbType.VarChar, 50).Value = itemcode1
                cmd.Parameters.Add("@tstorecode", SqlDbType.VarChar, 50).Value = txt_Storecode.Text
                cmd.Parameters.Add("@tuom", SqlDbType.VarChar, 50).Value = uom
                cmd.Parameters.Add("@currentgrnqty", SqlDbType.Float).Value = qty1
                cmd.Parameters.Add("@currentPurchaseRate", SqlDbType.Float).Value = (totalamount + totalothchg) / qty1
                cmd.Parameters.Add("@WeightedRate", SqlDbType.Float)
                cmd.Parameters.Add("@lastweightedrate", SqlDbType.Float)
                cmd.Parameters("@WeightedRate").Direction = ParameterDirection.Output

                cmd.Parameters("@lastweightedrate").Direction = ParameterDirection.Output
                gconnection.Myconn.Open()
                cmd.ExecuteReader()
                weightedrate = cmd.Parameters("@WeightedRate").Value
                lastweightedrate = cmd.Parameters("@lastWeightedRate").Value

                gconnection.Myconn.Close()
            Catch ex As Exception
                gconnection.Myconn.Close()

            End Try

            itemcode1 = AxfpSpread1.Text
            sqlstring = "insert into ratelist(grnno,batchno,itemcode,uom,batchrate,grndate,weightedrate,lastweightedrate,storecode,adddate,adduser)"
            sqlstring = sqlstring & " values ('" + txt_Grnno.Text + "',"
            AxfpSpread1.Col = 14
            sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            AxfpSpread1.Col = 1
            sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & "'" + AxfpSpread1.Text + "', "
            AxfpSpread1.Col = 5
            sqlstring = sqlstring & "'" + Format(Val((totalamount + totalothchg) / qty1), "0.00") + "' ,"
            sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
            sqlstring = sqlstring & "" & Format(Val(weightedrate), "0.000") & " , "
            sqlstring = sqlstring & "" & Format(Val(lastweightedrate), "0.000") & " , "
            sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',getDate(),'" & Trim(gUsername) & "')"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring



       

            'AxfpSpread1.Col = 1

            'sqlstring = " Select ISNULL(batchprocess,'NO') AS batchprocess from inv_inventoryitemmaster where itemcode='" + AxfpSpread1.Text + "' "
            'gconnection.getDataSet(sqlstring, "inv_inventoryitemmaster")
            ''If (gdataset.Tables("inv_inventoryitemmaster").Rows.Count > 0) Then
            'If (gdataset.Tables("inv_inventoryitemmaster").Rows(0).Item("batchprocess")) = "YES" Then
            '    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,TRNS_SEQ)"
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
            '    Dim closingqty As Double
            '    Dim closingvalue As Double


            '    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue from closingqty where itemcode='" + itemcode1 + "' AND  storecode='" + txt_Storecode.Text + "'and trndate<='" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
            '    gconnection.getDataSet(sqlstring, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

            '        closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
            '        closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
            '    End If
            '    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,TRNS_SEQ)"
            '    sqlstring = sqlstring & " values ('" + txt_Grnno.Text + "',"
            '    AxfpSpread1.Col = 1
            '    sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            '    AxfpSpread1.Col = 3
            '    sqlstring = sqlstring & "'" + STOCKUOM + "', "
            '    sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',"
            '    sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"


            '    sqlstring = sqlstring & " " & Format(Val(closingqty), "0.000") & ","

            '    sqlstring = sqlstring & "'" + Format(Val(closingvalue), "0.000") + "' ,"
            '    AxfpSpread1.Col = 4
            '    sqlstring = sqlstring & " " & Format((qty1 / CONVVALUE) + (qty1 * precise), "0.000") & ","
            '    sqlstring = sqlstring & " " & Format((qty1 / CONVVALUE) + (qty1 * precise) + closingqty, "0.000") & ","

            '    sqlstring = sqlstring & "'" + Format(Val((totalamount + totalothchg)) + closingvalue, "0.000") + "' ,"


            '    sqlstring = sqlstring & " 'N',"
            '    sqlstring = sqlstring & "  'GRN', "
            '    AxfpSpread1.Col = 14
            '    sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'))"
            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring



            'Dim qty1 As Double
            'Dim itemcode As String
            'Dim seq As Double


            'sqlstring = "update CLOSINGQTY set TRNS_SEQ=g.TRNS_SEQ from CLOSINGQTY c inner join Grn_details g on trnno='" + txt_Grnno.Text + "' where c.Itemcode='" + itemcode1 + "' and  c.Trndate= G.grndate"
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = sqlstring
            'gconnection.MoreTrans1(INSERT)
            'ReDim INSERT(0)
            'sqlstring = "Select getdate()"
            'gdate = gconnection.getvalue(sqlstring)
            'If (Format(CDate(gdate), "yyyy/MM/dd") > Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd")) Then
            '    Dim batchyn As String
            '    Dim AUTOID As Integer = 0
            '    'Dim closingqty As Double
            '    ' Dim seq As Double
            '    Dim Rate As Double
            '    'sqlstring = "    update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end  ,"
            '    'sqlstring = sqlstring & "  lastweightedrate="
            '    'sqlstring = sqlstring & "  case when openningvalue=0 then"
            '    'sqlstring = sqlstring & "      batchrate "
            '    'sqlstring = sqlstring & "   Else"
            '    'sqlstring = sqlstring & "  openningvalue/openningstock "
            '    'sqlstring = sqlstring & "     End"
            '    'sqlstring = sqlstring & "  from ratelist inner join CLOSINGQTY on ratelist.grnno=CLOSINGQTY.trnno where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
            '    'sqlstring = sqlstring & "   and CLOSINGQTY.storecode='" + txt_Storecode.Text + "' and CLOSINGQTY.itemcode='" + itemcode1 + "'"

            '    'gconnection.dataOperation(6, sqlstring, )
            '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  itemcode='" + itemcode1 + "' "
            '    sqlstring = sqlstring & " and Trnno='" + txt_Grnno.Text + "' "
            '    gconnection.getDataSet(sqlstring, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '        seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
            '    End If
            '    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid from closingqty where itemcode='" + itemcode1 + "' and storecode='" + txt_Storecode.Text + "'and cast(convert(varchar(11),trndate,106)as datetime)<='" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "' order by trns_seq desc"
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

            '    sqlstring = "update closingqty set openningstock= openningstock +" + Format(Val(qty1), "0.000") + " ,"
            '    sqlstring = sqlstring & "  openningvalue="
            '    sqlstring = sqlstring & "  CASE WHEN openningstock=0"
            '    sqlstring = sqlstring & "  THEN"
            '    sqlstring = sqlstring & "   '" + Format(Val((totalamount + totalothchg)), "0.000") + "' "
            '    sqlstring = sqlstring & "    Else"

            '    sqlstring = sqlstring & "  openningstock*" + Format(Val(Rate), "0.000") + ""
            '    sqlstring = sqlstring & "    End"
            '    sqlstring = sqlstring & " ,closingstock= closingstock +" + Format(Val(qty1), "0.000") + " ,"
            '    sqlstring = sqlstring & "  closingvalue="
            '    sqlstring = sqlstring & "  CASE WHEN closingstock=0"
            '    sqlstring = sqlstring & "  THEN "
            '    sqlstring = sqlstring & "  0 "
            '    sqlstring = sqlstring & "  Else"
            '    sqlstring = sqlstring & "     closingstock *" + Format(Val(Rate), "0.000") + ""
            '    sqlstring = sqlstring & "       End"

            '    sqlstring = sqlstring & "  where cast(convert(varchar(11),trndate,106)as datetime)>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
            '    sqlstring = sqlstring & "   and itemcode='" + itemcode1 + "'"


            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring

            '    sqlstring = "UPDATE closingqty SET  closingvalue=closingstock*(" + Format(Val(Rate), "0.000") + "),openningvalue=openningstock *" + Format(Val((Rate)), "0.000") + ""
            '    sqlstring = sqlstring & "  where cast(convert(varchar(11),trndate,106)as datetime)>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
            '    sqlstring = sqlstring & "  and itemcode='" + itemcode1 + "'"


            '    'If (batchyn = "Y") Then
            '    '    sqlstring = sqlstring & "  and  batchno='" + txt_Grnno.Text + "'"
            '    'End If
            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring






            'End If

            ''  End If
            'End If






        Next

        sqlstring = "UPDATE GRN_HEADER SET TOTALQTY =( SELECT SUM(QTY) FROM Grn_details WHERE GRN_HEADER.Grndetails=Grn_details.Grndetails) WHERE Grndetails='" & txt_Grnno.Text & "' "
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring


        'sqlstring = "UPDATE GRN_DETAILS SET LoadingChg= ISNULL((LoadingCharge*qty)/TOTALQTY,0) FROM GRN_DETAILS D  INNER JOIN GRN_HEADER H ON D.Grndetails=H.Grndetails  WHERE  D.Grndetails='" & txt_Grnno.Text & "' AND  ISNULL(LoadingCharge,0)<>0 "
        'ReDim Preserve GrnQuery(GrnQuery.Length)
        'GrnQuery(GrnQuery.Length - 1) = sqlstring
        'If (GACCPOST.ToUpper() = "Y") And gAcTaggingType = "ITEM" Then
        '    For k As Integer = 1 To AxfpSpread1.DataRowCnt
        '        AxfpSpread1.Row = k
        '        AxfpSpread1.Col = 1
        '        itemcode1 = AxfpSpread1.Text
        '        sqlstring = "Select Accountcode,accountdesc from AccountstaggingForItem where itemcode='" & itemcode1 & "'"
        '        gconnection.getDataSet(sqlstring, "CODE")
        '        If (gdataset.Tables("CODE").Rows.Count > 0) Then
        '            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
        '            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
        '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '            sqlstring = sqlstring & " AccountcodeDesc, CreditDebit, Amount, VOID, SLCODE)"
        '            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
        '            sqlstring = sqlstring & "'STOCK-PURCHASE', 'STOCK-PURCHASE', '" & accode & "',"
        '            sqlstring = sqlstring & "'" & acdesc & "', 'DEBIT',"
        '            AxfpSpread1.Row = k
        '            AxfpSpread1.Col = 6
        '            amt = Format(Val(AxfpSpread1.Text), "0.00")
        '            sqlstring = sqlstring & "'" & amt & "','N',"
        '            AxfpSpread1.Row = k
        '            AxfpSpread1.Col = 1
        '            slcode = AxfpSpread1.Text
        '            sqlstring = sqlstring & "'" & slcode & "')"
        '            ReDim Preserve GrnQuery(GrnQuery.Length)
        '            GrnQuery(GrnQuery.Length - 1) = sqlstring
        '        Else
        '            MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR THIS ITEM:-'" & itemcode1 & "'")
        '        End If
        '        AxfpSpread1.Row = k
        '        AxfpSpread1.Col = 1

        '        sqlstring = "Select glaccountin,itemCode from Itemtaxtagging where itemcode='" + AxfpSpread1.Text + "' AND GLACCOUNTIN<>'NTAX'"
        '        gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
        '        If (gdataset.Tables("INV_LINKSETUP").Rows.Count > 0) Then
        '            taxcode = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("glaccountin")

        '            sqlstring = "SELECT ACCODE,acdesc FROM accountsglaccountmaster WHERE  accode='" + taxcode + "' and isnull(freezeflag,'')<>'Y'"
        '            gconnection.getDataSet(sqlstring, "TAB1")
        '            If gdataset.Tables("TAB1").Rows.Count > 0 Then
        '                taxcode = gdataset.Tables("TAB1").Rows(0).Item("ACCODE")
        '                acdesc = gdataset.Tables("TAB1").Rows(0).Item("acdesc")
        '                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '                sqlstring = sqlstring & " AccountcodeDesc, CreditDebit, Amount, VOID, SLCODE)"
        '                sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "', "
        '                sqlstring = sqlstring & "'STOCK-TAX', 'STOCK-TAX', '" & taxcode & "',"
        '                sqlstring = sqlstring & "'" & acdesc & "', 'DEBIT',"
        '                amt = 0.0
        '                AxfpSpread1.Row = k
        '                AxfpSpread1.Col = 12
        '                amt = Format(Val(AxfpSpread1.Text), "0.00")
        '                sqlstring = sqlstring & "'" & amt & "','N',"
        '                slcode = ""
        '                AxfpSpread1.Row = k
        '                AxfpSpread1.Col = 1
        '                slcode = AxfpSpread1.Text
        '                sqlstring = sqlstring & "'" & slcode & "')"
        '                ReDim Preserve GrnQuery(GrnQuery.Length)
        '                GrnQuery(GrnQuery.Length - 1) = sqlstring
        '            End If
        '        End If

        '    Next

        '    Dim DISCaccountcode As String
        '    Dim OTHACCOUNTCODE As String
        '    sqlstring = "Select DISCaccountcode,OTHACCOUNTCODE from INV_LINKSETUP "
        '    gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
        '    If (gdataset.Tables("INV_LINKSETUP").Rows.Count > 0) Then
        '        DISCaccountcode = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("DISCaccountcode")
        '        OTHACCOUNTCODE = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("OTHACCOUNTCODE")
        '    Else
        '        MessageBox.Show("CREATE ACCOUNTCODE FOR DISCOUNT AND OTHERCHARGES IN INVENTORY SETUP")
        '        Exit Sub

        '    End If
        '    amt = 0.0
        '    'ssgrid.Row = i
        '    'ssgrid.Col = 8
        '    amt = Convert.ToDouble(Format(Val(TXT_OVERALLdiscount.Text), "0.00")) + Convert.ToDouble(Format(Val(txt_totdisc.Text), "0.00"))
        '    If amt > 0 Then
        '        sqlstring = "SELECT ACCODE,acdesc FROM accountsglaccountmaster WHERE  accode='" + DISCaccountcode + "' and isnull(freezeflag,'')<>'Y'"
        '        gconnection.getDataSet(sqlstring, "TAB1")
        '        If gdataset.Tables("TAB1").Rows.Count > 0 Then
        '            accode = gdataset.Tables("TAB1").Rows(0).Item("ACCODE")
        '            acdesc = gdataset.Tables("TAB1").Rows(0).Item("acdesc")
        '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '            sqlstring = sqlstring & " AccountcodeDesc, CreditDebit, Amount, VOID)"
        '            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "', "
        '            sqlstring = sqlstring & "'STOCK-DISC', 'STOCK-DISC', '" & accode & "',"
        '            sqlstring = sqlstring & "'" & acdesc & "', 'CREDIT',"

        '            sqlstring = sqlstring & "'" & amt & "','N')"
        '            'SLCODE = ""
        '            'ssgrid.Row = i
        '            'ssgrid.Col = 1
        '            'SLCODE = ssgrid.Text
        '            'sqlstring = sqlstring & "'" & SLCODE & "')"
        '            ReDim Preserve GrnQuery(GrnQuery.Length)
        '            GrnQuery(GrnQuery.Length - 1) = sqlstring
        '        End If
        '    End If
        '    amt = Convert.ToDouble(Format(Val(txt_Surchargeamt.Text), "0.00"))
        '    If amt > 0 Then


        '        sqlstring = "SELECT ACCODE,acdesc FROM accountsglaccountmaster WHERE  accode='" + OTHACCOUNTCODE + "' and isnull(freezeflag,'')<>'Y'"
        '        gconnection.getDataSet(sqlstring, "TAB1")
        '        If gdataset.Tables("TAB1").Rows.Count > 0 Then
        '            accode = gdataset.Tables("TAB1").Rows(0).Item("ACCODE")
        '            acdesc = gdataset.Tables("TAB1").Rows(0).Item("acdesc")
        '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '            sqlstring = sqlstring & " AccountcodeDesc, CreditDebit, Amount, VOID)"
        '            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "', "
        '            sqlstring = sqlstring & "'STOCK-OTHERCHARGE', 'STOCK-OTHERCHARGE', '" & accode & "',"
        '            sqlstring = sqlstring & "'" & acdesc & "', 'DEBIT',"


        '            sqlstring = sqlstring & "'" & amt & "','N')"
        '            'SLCODE = ""
        '            'ssgrid.Row = i
        '            'ssgrid.Col = 1
        '            'SLCODE = ssgrid.Text
        '            'sqlstring = sqlstring & "'" & SLCODE & "')"
        '            ReDim Preserve GrnQuery(GrnQuery.Length)
        '            GrnQuery(GrnQuery.Length - 1) = sqlstring
        '        End If
        '    End If
        '    Dim slcode1 As String
        '    Dim sldesc1 As String
        '    Dim ACCODE1 As String
        '    Dim ACDESC1 As String
        '    sqlstring = "select slcode, sldesc,ACCODE from accountssubledgermaster  WHERE "
        '    '           ' accode='" & gCreditors & "' AND "
        '    sqlstring = sqlstring & "SLCODE='" & txt_Suppliercode.Text & "' AND SLNAME='" & txt_Suppliername.Text & "'"
        '    gconnection.getDataSet(sqlstring, "SLCODE1")
        '    If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
        '        ACCODE1 = gdataset.Tables("SLCODE1").Rows(0).Item("ACCODE")
        '        slcode1 = gdataset.Tables("SLCODE1").Rows(0).Item("SLCODE")
        '        sldesc1 = gdataset.Tables("SLCODE1").Rows(0).Item("SLDESC")
        '    Else
        '        MessageBox.Show("CREATE SLCODE FOR SUPPLIER IN ACCOUNTSSUBLEDGERMASTER...")
        '        Exit Sub
        '    End If
        '    '***********JOURNALENTRY POSTING FOR CREDIT VALUE(SUPPLIER CODE)*****************
        '    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, "
        '    sqlstring = sqlstring & " AccountCode, AccountcodeDesc, CreditDebit, Amount, VOID, SLCODE, SLDESC)"
        '    sqlstring = sqlstring & "VALUES('" & txt_Grnno.Text & "','" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "',"
        '    sqlstring = sqlstring & "'STOCK-PURCHASE','STOCK-PURCHASE','" & ACCODE1 & "','" & ACDESC1 & "',"
        '    sqlstring = sqlstring & "'CREDIT','" & txt_Billamount.Text & "','N','" & slcode1 & "','" & sldesc1 & "')"
        '    ReDim Preserve GrnQuery(GrnQuery.Length)
        '    GrnQuery(GrnQuery.Length - 1) = sqlstring


        'End If


        If (gdirissue = "Y") Then
            If nonstockable.Rows.Count > 0 Then
                Call Addissueoperation()
            End If

        End If

        gconnection.MoreTrans(GrnQuery)

        'For k As Integer = 1 To AxfpSpread1.DataRowCnt

        '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  itemcode='" + itemcode1 + "' "
        '    sqlstring = sqlstring & " and Trnno='" + txt_Grnno.Text + "'"
        '    gconnection.getDataSet(sqlstring, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        '        AxfpSpread1.Col = 1
        '        gconnection.CalStockValue(txt_Storecode.Text, AxfpSpread1.Text, seq)
        '    End If
        'Next

        Dim SQL As String = "select count(*) as a from  po_itemdetails where ISNULL(qtystatus,'') <> 'RECEIVED' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
        gconnection.getDataSet(SQL, "po_itemdetails")
        If gdataset.Tables("po_itemdetails").Rows.Count > 0 Then
            If Val(gdataset.Tables("po_itemdetails").Rows(0).Item("a").ToString()) > 0 Then
            Else
                sqlstring = "update po_hdr set postatus='CLOSED' where   pono='" + Txt_PONo.Text + "' AND POTYPE NOT IN ('FIXED RATE OPEN QUANTITY' ,'OPEN RATE OPEN QUANTITY') AND VERSIONNO='" + versionno + "'"
                gconnection.dataOperation(6, sqlstring, )
            End If
        End If

    End Sub

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
        If Cmd_Add.Text = "Add [F7]" Then
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
                    sqlstring = sqlstring & "   where storecode='" + gdataset.Tables("directissueing").Rows(m).Item("Storecode") + "' group by itemcode,itemname,uom,Storecode"
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





                            If (GACCPOST.ToUpper() = "Y") And gAcPostingWise = "STORE" Then


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
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                                    sqlstring = sqlstring & " VALUES('" & Trim(issuedocno) & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'ISSUE', '" & accode & "',"
                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'DEBIT',"


                                    'Dim qty As Double = Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))
                                    'If Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then
                                    '    'amt = Format((Val((txt_Billamount.Text)) / TOTALISSUEQTY) * qty, "0.000")
                                    '    amt = Format(rate * qty, "0.000")
                                    'Else
                                    'amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text)) / TOTALISSUEQTY) * qty, "0.000")
                                    amt = Format(rate * qty, "0.000")
                                    ' End If

                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N','" + gUsername + "')"
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
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                                    sqlstring = sqlstring & " VALUES('" & Trim(issuedocno) & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'ISSUE', '" & accode & "',"
                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'CREDIT',"

                                    'If Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then
                                    '    ' amt = Format(Val((txt_Billamount.Text)), "0.000")
                                    '    amt = Format(rate * qty, "0.000")
                                    'Else
                                    amt = Format(rate * qty, "0.000")
                                    ' amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text))), "0.000")
                                    ' End If
                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N','" + gUsername + "')"
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
        sqlstring = sqlstring & " void='Y'"
        sqlstring = sqlstring & "  where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        INSERT(0) = sqlstring
        sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring

        If (GACCPOST.ToUpper() = "Y") Then
            sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
        End If
        sqlstring = "Update po_itemdetails set receivedqty=receivedqty-qty,QTYstatus='' from PO_ITEMDETAILS inner join Grn_details"
        sqlstring = sqlstring & "    on PO_ITEMDETAILS.ITEMCODE=Grn_details.Itemcode and PO_ITEMDETAILS.pono=Grn_details.pono and PO_ITEMDETAILS.versionno=Grn_details.versionno "
        sqlstring = sqlstring & " where Grn_details.pono='" + Txt_PONo.Text + "' and Grn_details.versionno='" + versionno + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring

        sqlstring = "update po_hdr set postatus='RELEASED' where pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring
        sqlstring = "update ratelist  set void='Y' where   grnno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring
        'AxfpSpread1.Col = 1
        'Dim itemcode As String = AxfpSpread1.Text
        'AxfpSpread1.Col = 4
        'Dim qty As Double = Val(AxfpSpread1.Text)
        'Dim batchyn As String
        'Dim SQL1 As String = "select qty,batchyn from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
        'SQL1 = SQL1 & " and Trnno='" + txt_Grnno.Text + "' "
        'gconnection.getDataSet(SQL1, "closingqty")
        'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '    qty = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        'End If
        'SQL1 = "update closingqty set closingstock= closingstock -" + Format(Val(qty), "0.000") + ""
        '' ,closingvalue=closingvalue+(" + Format(Val(qty), "0.000") + "*(closingvalue/closingqty))"
        'SQL1 = SQL1 & "  where trndate='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Grnno.Text + "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
        'If (batchyn = "Y") Then
        '    SQL1 = SQL1 & "  and  batchno='" + txt_Grnno.Text + "'"
        'End If
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = SQL1

        'SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(qty), "0.000") + " ,openningstock=openningstock+" + Format(Val(qty), "0.000") + ""
        '',closingvalue=closingvalue+("(-qty) + "*(closingvalue/closingqty)),openningvalue=openningvalue+("(-qty) + "*(openningvalue/openningstock))"
        'SQL1 = SQL1 & "  where cast(convert(varchar(11),trndate,106)as datetime)>='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' "
        'If (batchyn = "Y") Then
        '    SQL1 = SQL1 & "  and  batchno='" + txt_Grnno.Text + "'"
        'End If
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = SQL1
        'sqlstring = "select * from ratelist where cast(convert(varchar(11),grndate,106)as datetime)>='" + Format(dtp_Grndate.Value, "dd/MMM/yyyy") + "'  order by grndate desc "
        'gconnection.getDataSet(sqlstring, "ratelist")
        'If (gdataset.Tables("ratelist").Rows.Count > 0) Then
        '    For i As Integer = 0 To gdataset.Tables("ratelist").Rows.Count - 1
        '        lastweightedrate = gdataset.Tables("ratelist").Rows(i).Item("weightedrate")
        '        If (i + 1 < gdataset.Tables("ratelist").Rows.Count - 1) Then
        '            sqlstring = "update   ratelist set weightedrate=(openingstock+qty)/(openingstock*" + lastweightedrate + ")+(qty*batchrate) and lastweightedrate='" + lastweightedrate + "' from ratelist inner join closingqty"
        '            sqlstring = sqlstring & " on ratelist.Itemcode=closingqty.itemcode and ratelist.grnno=closingqty.Trnno and ratelist.storecode=closingqty.storecode and grnno='" + gdataset.Tables("ratelist").Rows(i + 1).Item("grnno") + "'"
        '            ReDim Preserve INSERT(INSERT.Length)
        '            INSERT(INSERT.Length - 1) = sqlstring

        '        Else
        '            Exit For
        '        End If
        '    Next
        'End If

        'gconnection.MoreTrans1(INSERT)
        'ReDim INSERT(0)
        'For i As Integer = 1 To AxfpSpread1.DataRowCnt

        '    AxfpSpread1.Row = i
        '    AxfpSpread1.Col = 1
        '    itemcode = AxfpSpread1.Text
        '    AxfpSpread1.Col = 4
        '    qty = Val(AxfpSpread1.Text)
        '    batchyn = "N"

        '    SQL1 = "select qty,batchyn,trns_seq from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
        '    SQL1 = SQL1 & " and Trnno='" + txt_Grnno.Text + "' "
        '    gconnection.getDataSet(SQL1, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '        seq = gdataset.Tables("closingqty").Rows(0).Item("trns_seq")
        '    End If





        '    SQL1 = "update closingqty set closingstock= closingstock -" + Format(Val(qty), "0.000") + ",closingvalue=openningvalue,qty=0"
        '    ' ,closingvalue=closingvalue+(" + Format(Val(qty), "0.000") + "*(closingvalue/closingqty))"
        '    SQL1 = SQL1 & "  where trndate='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Grnno.Text + "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
        '    'If (batchyn = "Y") Then
        '    '    SQL1 = SQL1 & "  and  batchno='" + txt_Grnno.Text + "'"
        '    'End If
        '    ReDim Preserve INSERT(INSERT.Length)
        '    INSERT(INSERT.Length - 1) = SQL1

        '    If (Format(CDate(gdate), "yyyy/MM/dd") > Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd")) Then
        '        'Dim batchyn As String
        '        Dim AUTOID As Integer = 0
        '        Dim closingqty As Double
        '        Dim closingvalue As Double
        '        Dim OLDQTY As Double
        '        sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid,QTY from closingqty where itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'and trndate<='" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
        '        gconnection.getDataSet(sqlstring, "closingqty")
        '        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '            AUTOID = Val(gdataset.Tables("closingqty").Rows(0).Item("AUTOID"))
        '            closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
        '            closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
        '            OLDQTY = Val(closingvalue / closingqty)
        '        End If


        '        sqlstring = "UPDATE closingqty SET openningstock=openningstock-(" + Format(Val(qty), "0.000") + "), closingstock= closingstock -" + Format(Val(qty), "0.000") + " "
        '        sqlstring = sqlstring & ",closingvalue=openningvalue-(" + Format(Val(qty * OLDQTY), "0.000") + "),openningvalue=openningvalue -" + Format(Val((qty * OLDQTY)), "0.000") + ""
        '        sqlstring = sqlstring & "  where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
        '        sqlstring = sqlstring & "   and trns_seq>" & seq.ToString() & " and itemcode='" + itemcode + "'"
        '        'sqlstring = sqlstring & "   and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "'"

        '        '  sqlstring = sqlstring & " AND AUTOID >'" + AUTOID.ToString() + "'  "
        '        'If (batchyn = "Y") Then
        '        '    sqlstring = sqlstring & "  and  batchno='" + txt_Grnno.Text + "'"
        '        'End If
        '        ReDim Preserve INSERT(INSERT.Length)
        '        INSERT(INSERT.Length - 1) = sqlstring


        '        '  gconnection.CalStockValue(txt_Storecode.Text, itemcode, seq)

        '        sqlstring = "    update ratelist set weightedrate=closingvalue/closingstock ,"
        '        sqlstring = sqlstring & "  lastweightedrate="
        '        sqlstring = sqlstring & "  case when openningvalue=0 then"
        '        sqlstring = sqlstring & "      batchrate "
        '        sqlstring = sqlstring & "   Else"
        '        sqlstring = sqlstring & "  openningvalue/openningstock "
        '        sqlstring = sqlstring & "     End"
        '        sqlstring = sqlstring & "  from ratelist inner join CLOSINGQTY on ratelist.grnno=CLOSINGQTY.trnno and CLOSINGQTY.closingstock<>0 where trndate>'" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "'"
        '        sqlstring = sqlstring & "   and CLOSINGQTY.storecode='" + txt_Storecode.Text + "' and CLOSINGQTY.itemcode='" + itemcode + "'"
        '        ReDim Preserve INSERT(INSERT.Length)
        '        INSERT(INSERT.Length - 1) = sqlstring

        '    End If

        'Next

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
        '    sqlstring = sqlstring & " and Trnno='" + txt_Grnno.Text + "' and itemcode='" & AxfpSpread1.Text & "' "
        '    gconnection.getDataSet(sqlstring, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        '        gconnection.CalStockValue(txt_Storecode.Text, AxfpSpread1.Text, seq)
        '    End If
        'Next

    End Sub
    Private Sub expirycheck()
        Dim expiry As Date
        Dim j As Integer
        If GEXPIRY = "Y" Then
            Dim ITEMCODE As String
            j = AxfpSpread1.ActiveRow
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 1
            ITEMCODE = AxfpSpread1.Text
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 24
            expiry = AxfpSpread1.Text
            Dim sqlstring As String = "SELECT ISNULL(EXPIRYDATE,'') AS EXPIRYDATE FROM INV_InventoryItemMaster WHERE ITEMCODE='" & ITEMCODE & "' AND  ISNULL(VOID,'N') <> 'Y'"
            gconnection.getDataSet(sqlstring, "BATCHREQ")
            If gdataset.Tables("BATCHREQ").Rows.Count > 0 Then
                If expiry <= Today.Date Then
                    MessageBox.Show("Expiry date is less than today's date  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If
        End If
    End Sub
    Private Sub UpdateOperation()
        Dim INSERT(0) As String
        Dim sqlstring, SEQ1 As String
        Dim itemcode1 As String
        Dim uom As String
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        Dim weightedrate As Double
        Dim lastweightedrate As Double
        Dim INSERT1(0) As String
        Dim INSERT2(0) As String
        Dim stockuom As String
        Dim convvalue As Double
        Dim precise As Double
        GRNno = Split(Trim(txt_Grnno.Text), "/")
        CATCODE = Split(CMB_CATEGORY.Text, "--->")

        sqlstring = "INSERT INTO GRN_HEADERLOG(category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
        sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno)"
        sqlstring = sqlstring & " SELECT category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
        sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno"
        sqlstring = sqlstring & " FROM GRN_HEADER WHERE Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        INSERT1(0) = sqlstring
        sqlstring = " DELETE FROM GRN_HEADER WHERE Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        ReDim Preserve INSERT1(INSERT1.Length)
        INSERT1(INSERT1.Length - 1) = sqlstring
        sqlstring = "iNSERT INTO GRN_DETAILSLOG(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
        sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,SPLCESS)"
        sqlstring = sqlstring & " SELECT Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
        sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,SPLCESS"
        sqlstring = sqlstring & "  FROM Grn_details where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT1(INSERT1.Length)
        INSERT1(INSERT1.Length - 1) = sqlstring
        sqlstring = " DELETE FROM RATELIST WHERE grnno='" + Trim(CStr(txt_Grnno.Text)) + "'"
        ReDim Preserve INSERT1(INSERT1.Length)
        INSERT1(INSERT1.Length - 1) = sqlstring
        sqlstring = "INSERT INTO Grn_header(category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
        ' sqlstring = sqlstring & ",Typecode,Typedesc,Excisepassno,Excisedate,Stockindate,Trucknumber,Creditdays,Glaccountcode,Glaccountname,Slcode,Slname,Costcentercode,Costcentername,"
        sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,LoadingCharge)"
        sqlstring = sqlstring & " VALUES ('" & Trim(CATCODE(0)) & "','" & CStr(GRNno(2)) & "','" & Trim(CStr(txt_Grnno.Text)) & "',"
        sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
        sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
        '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
        '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
        ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
        sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.00") & "," & Format(Val(txt_totaltax.Text), "0.00") & "," & Format(Val(txt_Surchargeamt.Text), "0.00") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.00") & "," & Format(Val(txt_totdisc.Text), "0.00") & ","
        sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.00") & ","
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',getDate(),"
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
        sqlstring = sqlstring & "  'GRN','" + versionno + "'," & Format(Val(txtLoadingChrg.Text), "0.00") & ")"

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
        'sqlstring = sqlstring & "Totalamount= " & Format(Val(txt_total.Text), "0.00") & ",VATamount=" & Format(Val(txt_totaltax.Text), "0.00") & ",Surchargeamt=" & Format(Val(txt_Surchargeamt.Text), "0.00") & ",OverallDiscount=" & Format(Val(TXT_OVERALLdiscount.Text), "0.00") & ",Discount=" & Format(Val(txt_totdisc.Text), "0.00") & ","
        'sqlstring = sqlstring & " Billamount=" & Format(Val(txt_Billamount.Text), "0.00") & ","
        'sqlstring = sqlstring & "Remarks= '" & Trim(CStr(txt_Remarks.Text)) & "',Void='N',updateuser='" & Trim(gUsername) & "',updatedate=getDate(),"
        'sqlstring = sqlstring & " storecode='" & Trim(CStr(txt_Storecode.Text)) & "',STOREDESC='" & Trim(CStr(txt_StoreDesc.Text)) & "',"
        'sqlstring = sqlstring & " Grntype= 'GRN' where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        'INSERT(0) = sqlstring
        sqlstring = "Delete from Grn_details where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT1(INSERT1.Length)
        INSERT1(INSERT1.Length - 1) = sqlstring

        sqlstring = "Update po_itemdetails set receivedqty=receivedqty-qty,qtystatus='' from PO_ITEMDETAILS inner join Grn_details"
        sqlstring = sqlstring & "    on PO_ITEMDETAILS.ITEMCODE=Grn_details.Itemcode and PO_ITEMDETAILS.pono=Grn_details.pono and PO_ITEMDETAILS.versionno=Grn_details.versionno  "
        sqlstring = sqlstring & " where Grn_details.pono='" + Txt_PONo.Text + "' and grn_details.versionno='" + versionno + "' "
        gconnection.dataOperation(6, sqlstring)
        sqlstring = "update po_hdr set postatus='RELEASED' where pono='" + Txt_PONo.Text + "'"
        gconnection.dataOperation(6, sqlstring)
        gconnection.MoreTrans1(INSERT1)

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
            If GEXPIRY = "Y" Then
                sqlstring = sqlstring & "ExpiryDate,"
            End If
            sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,Discount,amountafterdiscount,taxcode,TaxPer,taxamount,amount,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,margin,tax2,tax2amt,ittcs,ittcsamt,oldqty,SPLCESS,LoadingChg)"
            sqlstring = sqlstring & " VALUES('" & CStr(GRNno(2)) & "','" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
            AxfpSpread1.Col = 1
            itemcode1 = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            If GEXPIRY = "Y" Then
                AxfpSpread1.Col = 24
                If AxfpSpread1.Text = "" Then
                    sqlstring = sqlstring & " '01/01/1900',"
                Else
                    sqlstring = sqlstring & " '" & Format(CDate(AxfpSpread1.Text), "dd/MMM/yyyy") & "',"
                End If
            End If
            AxfpSpread1.Col = 3
            uom = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            Dim qty1 As Double = Format(Val(AxfpSpread1.Text), "0.000")
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 5
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 6
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","

            AxfpSpread1.Col = 7
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

            AxfpSpread1.Col = 8
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 9
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 10
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

            AxfpSpread1.Col = 11
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 12
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","

            AxfpSpread1.Col = 13
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            totalamount = Val(AxfpSpread1.Text)
            ' sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
            AxfpSpread1.Col = 14
            sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
            AxfpSpread1.Col = 15
            sqlstring = sqlstring & " '" & Format(Val(AxfpSpread1.Text), "0.00") & "',"
            totalothchg = Val(AxfpSpread1.Text)

            AxfpSpread1.Col = 16
            sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

            sqlstring = sqlstring & "'" & Trim(CATCODE(0)) & "',"
            sqlstring = sqlstring & "'" & Trim(gUsername) & "',getDate(),"
            sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
            sqlstring = sqlstring & "'GRN','" + versionno + "',"
            AxfpSpread1.Col = 17
            sqlstring = sqlstring & "'" & Val(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 18
            sqlstring = sqlstring & "'" & Val(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 19
            sqlstring = sqlstring & "'" & Val(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 20
            sqlstring = sqlstring & "'" & Val(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 21
            sqlstring = sqlstring & "'" & Val(AxfpSpread1.Text) & "',"

            Dim oldQty As Double
            Dim SQL1 As String
            sql1 = "select qty,batchyn,AUTOID from closingqty where  itemcode='" + itemcode1 + "' and storecode='" + txt_Storecode.Text + "' "
            sql1 = sql1 & " and Trnno='" + txt_Grnno.Text + "' "
            gconnection.getDataSet(sql1, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                oldQty = gdataset.Tables("closingqty").Rows(0).Item("qty")
            Else
                oldQty = 0
            End If

            'SQL1 = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + txt_Storecode.Text + "' "
            'SQL1 = SQL1 & " and Trnno='" + txt_Grnno.Text + "' AND ITEMCODE='" & itemcode1 & "'"
            'gconnection.getDataSet(SQL1, "closingqty")
            'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '    SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
            'End If
            AxfpSpread1.Col = 19
            sqlstring = sqlstring & " '" & Format(Val(oldQty), "0.000") & "',"
            AxfpSpread1.Col = 22
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 23
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ")"


            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
            AxfpSpread1.Col = 1
            sqlstring = "select isnull(receivedqty,0) as receivedqty ,isnull(qtystatus,'') as qtystatus,isnull(quantity,0) as quantity from  po_itemdetails where isnull(qtystatus,'') <> 'RECEIVED' and pono='" + Txt_PONo.Text + "' and"
            sqlstring = sqlstring & " itemcode='" + AxfpSpread1.Text + "' and versionno='" + versionno + "'"
            gconnection.getDataSet(sqlstring, "po_itemdetails")
            If (gdataset.Tables("po_itemdetails").Rows.Count > 0) Then
                Dim receivedqty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("receivedqty"))
                Dim quantity As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("quantity"))

                AxfpSpread1.Col = 4
                qty1 = Format(Val(AxfpSpread1.Text), "0.000")
                If (quantity > receivedqty + qty1) Then

                    AxfpSpread1.Col = 1
                    sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.00") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                ElseIf (quantity = receivedqty + qty1) Then
                    AxfpSpread1.Col = 1
                    sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.00") + ",qtystatus='RECEIVED' where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                Else
                    MessageBox.Show("Quantity Can't be greater than PO Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
            sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode1 + "'"
            stockuom = gconnection.getvalue(sqlstring)
            sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + stockuom + "' and transuom='" + uom + "'"
            gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
            Else
                MessageBox.Show("Generate relation between " + stockuom + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

            Dim cmd As New SqlCommand("INV_SPWeightedRateCalculation", gconnection.Myconn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@ttodate", SqlDbType.DateTime).Value = Format(dtp_Grndate.Value.ToString("dd/MMM/yyyy"))
            cmd.Parameters.Add("@tpitemcode", SqlDbType.VarChar, 50).Value = itemcode1
            cmd.Parameters.Add("@tstorecode", SqlDbType.VarChar, 50).Value = txt_Storecode.Text
            cmd.Parameters.Add("@tuom", SqlDbType.VarChar, 50).Value = uom
            cmd.Parameters.Add("@currentgrnqty", SqlDbType.Float).Value = qty1
            cmd.Parameters.Add("@currentPurchaseRate", SqlDbType.Float).Value = (totalamount + totalothchg) / qty1
            cmd.Parameters.Add("@WeightedRate", SqlDbType.Float)
            cmd.Parameters.Add("@lastWeightedRate", SqlDbType.Float)
            cmd.Parameters("@lastWeightedRate").Direction = ParameterDirection.Output

            cmd.Parameters("@WeightedRate").Direction = ParameterDirection.Output

            gconnection.Myconn.Open()
            cmd.ExecuteReader()
            weightedrate = cmd.Parameters("@WeightedRate").Value
            lastweightedrate = cmd.Parameters("@lastWeightedRate").Value
            gconnection.Myconn.Close()

            itemcode1 = AxfpSpread1.Text
            sqlstring = "insert into ratelist(grnno,batchno,itemcode,uom,batchrate,grndate,weightedrate,lastweightedrate,storecode,adddate,adduser)"
            sqlstring = sqlstring & " values ('" + txt_Grnno.Text + "',"
            AxfpSpread1.Col = 14
            sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            AxfpSpread1.Col = 1
            sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & "'" + uom + "', "
            AxfpSpread1.Col = 5
            sqlstring = sqlstring & "'" + Format(Val((totalamount + totalothchg) / qty1), "0.00") + "' ,"
            sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
            sqlstring = sqlstring & "" & Format(Val(weightedrate), "0.000") & " , "
            sqlstring = sqlstring & "" & Format(Val(lastweightedrate), "0.000") & " , "

            sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',getDate(),'" & Trim(gUsername) & "')"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            'AxfpSpread1.Col = 1
            'Dim itemcode As String = AxfpSpread1.Text
            'AxfpSpread1.Col = 4
            'Dim qty As Double = Format(Val((Val(AxfpSpread1.Text) / convvalue)) + (Val(AxfpSpread1.Text) * precise), "0.000")
            'Dim batchyn As String
            'SQL1 = "select qty,batchyn from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
            'SQL1 = SQL1 & " and Trnno='" + txt_Grnno.Text + "' "
            'gconnection.getDataSet(SQL1, "closingqty")
            'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
            '    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
            'End If
            'SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(qty - qty1), "0.000") + " ,closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
            'SQL1 = SQL1 & "  where trndate='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Grnno.Text + "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
            'If (batchyn = "Y") Then
            '    SQL1 = SQL1 & "  and  batchno='" + txt_Grnno.Text + "'"
            'End If
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = SQL1

            'SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(qty - qty1), "0.000") + " ,openningstock=openningstock+" + Format(Val(qty - qty1), "0.000") + ""
            '',closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
            '',openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
            'SQL1 = SQL1 & "  where trndate>='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
            'If (batchyn = "Y") Then
            '    SQL1 = SQL1 & "  and  batchno='" + txt_Grnno.Text + "'"
            'End If
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = SQL1





        Next

        sqlstring = "UPDATE GRN_HEADER SET TOTALQTY =( SELECT SUM(QTY) FROM Grn_details WHERE GRN_HEADER.Grndetails=Grn_details.Grndetails) WHERE Grndetails='" & txt_Grnno.Text & "' "
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring


        'sqlstring = "UPDATE GRN_DETAILS SET LoadingChg= ISNULL((LoadingCharge*qty)/TOTALQTY,0) FROM GRN_DETAILS D  INNER JOIN GRN_HEADER H ON D.Grndetails=H.Grndetails  WHERE  D.Grndetails='" & txt_Grnno.Text & "' AND  ISNULL(LoadingCharge,0)<>0 "
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'If (GACCPOST.ToUpper() = "Y") And gAcPostingWise = "ITEM" Then
        '    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
        '    ReDim Preserve INSERT(INSERT.Length)
        '    INSERT(INSERT.Length - 1) = sqlstring

        '    For k As Integer = 1 To AxfpSpread1.DataRowCnt
        '        AxfpSpread1.Row = k
        '        AxfpSpread1.Col = 1
        '        itemcode1 = AxfpSpread1.Text
        '        sqlstring = "Select Accountcode,accountdesc from AccountstaggingForItem where ITEMcode='" & itemcode1 & "'"
        '        gconnection.getDataSet(sqlstring, "CODE")
        '        If (gdataset.Tables("CODE").Rows.Count > 0) Then
        '            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
        '            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
        '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '            sqlstring = sqlstring & " AccountcodeDesc, CreditDebit, Amount, VOID, SLCODE)"
        '            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
        '            sqlstring = sqlstring & "'STOCK-PURCHASE', 'STOCK-PURCHASE', '" & accode & "',"
        '            sqlstring = sqlstring & "'" & acdesc & "', 'DEBIT',"
        '            AxfpSpread1.Row = k
        '            AxfpSpread1.Col = 6
        '            amt = AxfpSpread1.Text
        '            sqlstring = sqlstring & "'" & amt & "','N',"
        '            AxfpSpread1.Row = k
        '            AxfpSpread1.Col = 1
        '            slcode = AxfpSpread1.Text
        '            sqlstring = sqlstring & "'" & slcode & "')"
        '            ReDim Preserve INSERT(INSERT.Length)
        '            INSERT(INSERT.Length - 1) = sqlstring
        '        Else
        '            MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR THIS ITEM:-'" & itemcode1 & "'")
        '        End If
        '        AxfpSpread1.Row = k
        '        AxfpSpread1.Col = 1

        '        sqlstring = "Select glaccountin,itemCode from Itemtaxtagging where itemcode='" + AxfpSpread1.Text + "' AND GLACCOUNTIN<>'NTAX'"
        '        gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
        '        If (gdataset.Tables("INV_LINKSETUP").Rows.Count > 0) Then
        '            taxcode = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("glaccountin")

        '            sqlstring = "SELECT ACCODE,acdesc FROM accountsglaccountmaster WHERE  accode='" + taxcode + "' and isnull(freezeflag,'')<>'Y'"
        '            gconnection.getDataSet(sqlstring, "TAB1")
        '            If gdataset.Tables("TAB1").Rows.Count > 0 Then
        '                taxcode = gdataset.Tables("TAB1").Rows(0).Item("ACCODE")
        '                acdesc = gdataset.Tables("TAB1").Rows(0).Item("acdesc")
        '                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '                sqlstring = sqlstring & " AccountcodeDesc, CreditDebit, Amount, VOID, SLCODE)"
        '                sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "', "
        '                sqlstring = sqlstring & "'STOCK-TAX', 'STOCK-TAX', '" & taxcode & "',"
        '                sqlstring = sqlstring & "'" & acdesc & "', 'DEBIT',"
        '                amt = 0.0
        '                AxfpSpread1.Row = k
        '                AxfpSpread1.Col = 10
        '                amt = AxfpSpread1.Text
        '                sqlstring = sqlstring & "'" & amt & "','N',"
        '                slcode = ""
        '                AxfpSpread1.Row = k
        '                AxfpSpread1.Col = 1
        '                slcode = AxfpSpread1.Text
        '                sqlstring = sqlstring & "'" & slcode & "')"
        '                ReDim Preserve INSERT(INSERT.Length)
        '                INSERT(INSERT.Length - 1) = sqlstring
        '            End If
        '        End If

        '    Next

        '    Dim DISCaccountcode As String
        '    Dim OTHACCOUNTCODE As String
        '    sqlstring = "Select DISCaccountcode,OTHACCOUNTCODE from INV_LINKSETUP "
        '    gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
        '    If (gdataset.Tables("INV_LINKSETUP").Rows.Count > 0) Then
        '        DISCaccountcode = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("DISCaccountcode")
        '        OTHACCOUNTCODE = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("OTHACCOUNTCODE")
        '    Else
        '        MessageBox.Show("CREATE ACCOUNTCODE FOR DISCOUNT AND OTHERCHARGES IN INVENTORY SETUP")
        '        Exit Sub
        '    End If
        '    amt = 0.0
        '    'ssgrid.Row = i
        '    'ssgrid.Col = 8
        '    amt = Convert.ToDouble(TXT_OVERALLdiscount.Text) + Convert.ToDouble(txt_totdisc.Text)
        '    If amt > 0 Then
        '        sqlstring = "SELECT ACCODE,acdesc FROM accountsglaccountmaster WHERE  accode='" + DISCaccountcode + "' and isnull(freezeflag,'')<>'Y'"
        '        gconnection.getDataSet(sqlstring, "TAB1")
        '        If gdataset.Tables("TAB1").Rows.Count > 0 Then
        '            accode = gdataset.Tables("TAB1").Rows(0).Item("ACCODE")
        '            acdesc = gdataset.Tables("TAB1").Rows(0).Item("acdesc")
        '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '            sqlstring = sqlstring & " AccountcodeDesc, CreditDebit, Amount, VOID)"
        '            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "', "
        '            sqlstring = sqlstring & "'STOCK-DISC', 'STOCK-DISC', '" & accode & "',"
        '            sqlstring = sqlstring & "'" & acdesc & "', 'CREDIT',"

        '            sqlstring = sqlstring & "'" & amt & "','N')"
        '            'SLCODE = ""
        '            'ssgrid.Row = i
        '            'ssgrid.Col = 1
        '            'SLCODE = ssgrid.Text
        '            'sqlstring = sqlstring & "'" & SLCODE & "')"
        '            ReDim Preserve INSERT(INSERT.Length)
        '            INSERT(INSERT.Length - 1) = sqlstring
        '        End If
        '    End If
        '    amt = Convert.ToDouble(txt_Surchargeamt.Text)
        '    If amt > 0 Then


        '        sqlstring = "SELECT ACCODE,acdesc FROM accountsglaccountmaster WHERE  accode='" + OTHACCOUNTCODE + "' and isnull(freezeflag,'')<>'Y'"
        '        gconnection.getDataSet(sqlstring, "TAB1")
        '        If gdataset.Tables("TAB1").Rows.Count > 0 Then
        '            accode = gdataset.Tables("TAB1").Rows(0).Item("ACCODE")
        '            acdesc = gdataset.Tables("TAB1").Rows(0).Item("acdesc")
        '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
        '            sqlstring = sqlstring & " AccountcodeDesc, CreditDebit, Amount, VOID)"
        '            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "', "
        '            sqlstring = sqlstring & "'STOCK-OTHERCHARGE', 'STOCK-OTHERCHARGE', '" & accode & "',"
        '            sqlstring = sqlstring & "'" & acdesc & "', 'DEBIT',"


        '            sqlstring = sqlstring & "'" & amt & "','N')"
        '            'SLCODE = ""
        '            'ssgrid.Row = i
        '            'ssgrid.Col = 1
        '            'SLCODE = ssgrid.Text
        '            'sqlstring = sqlstring & "'" & SLCODE & "')"
        '            ReDim Preserve INSERT(INSERT.Length)
        '            INSERT(INSERT.Length - 1) = sqlstring
        '        End If
        '    End If
        '    Dim slcode1 As String
        '    Dim sldesc1 As String
        '    Dim Accode1 As String
        '    Dim Acdesc1 As String
        '    sqlstring = "select slcode, sldesc,accode,acdesc from accountssubledgermaster  WHERE "
        '    'accode='" & gCreditors & "'  "
        '    sqlstring = sqlstring & " SLCODE='" & txt_Suppliercode.Text & "' AND SLNAME='" & txt_Suppliername.Text & "'"
        '    gconnection.getDataSet(sqlstring, "SLCODE1")
        '    If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
        '        slcode1 = gdataset.Tables("SLCODE1").Rows(0).Item("SLCODE")
        '        sldesc1 = gdataset.Tables("SLCODE1").Rows(0).Item("SLDESC")
        '        Accode1 = gdataset.Tables("SLCODE1").Rows(0).Item("accode")
        '        Acdesc1 = gdataset.Tables("SLCODE1").Rows(0).Item("acdesc")
        '    Else
        '        MessageBox.Show("CREATE SLCODE FOR SUPPLIER IN ACCOUNTSSUBLEDGERMASTER...")
        '        Exit Sub
        '    End If
        '    '***********JOURNALENTRY POSTING FOR CREDIT VALUE(SUPPLIER CODE)*****************
        '    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, "
        '    sqlstring = sqlstring & " AccountCode, AccountcodeDesc, CreditDebit, Amount, VOID, SLCODE, SLDESC)"
        '    sqlstring = sqlstring & "VALUES('" & txt_Grnno.Text & "','" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "',"
        '    sqlstring = sqlstring & "'STOCK-PURCHASE','STOCK-PURCHASE','" & Accode1 & "','" & Acdesc1 & "',"
        '    sqlstring = sqlstring & "'CREDIT','" & txt_Billamount.Text & "','N','" & slcode1 & "','" & sldesc1 & "')"
        '    ReDim Preserve INSERT(INSERT.Length)
        '    INSERT(INSERT.Length - 1) = sqlstring


        'End If
        gconnection.MoreTrans(INSERT)

      

        Dim SQL As String = "select count(*) as a from  po_itemdetails where ISNULL(qtystatus,'') <> 'RECEIVED' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
        gconnection.getDataSet(SQL, "po_itemdetails")
        If gdataset.Tables("po_itemdetails").Rows.Count > 0 Then
            If Val(gdataset.Tables("po_itemdetails").Rows(0).Item("a").ToString()) > 0 Then
            Else
                sqlstring = "update po_hdr set postatus='CLOSED' where   pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                gconnection.dataOperation(6, sqlstring, )
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

                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "' and I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')"

                    Else

                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"

                    End If

                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then

                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))

                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            Dim sql1 As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z


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
jjj:                        SQL = "select TAXCODE, taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                            gconnection.getDataSet(SQL, "Itemtaxtagging")
                            If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then

                                If (check_tAXtYPE(gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxcode"))) = False Then
                                    AxfpSpread1.Col = 10
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                                    AxfpSpread1.Col = 11
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                                End If

                            Else
                                If (MessageBox.Show("Do You Want to Create No TaxCode For Item :" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE")), MyCompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Col = 1
                                    Dim sst As String = "select count(*) from Itemtaxtagging where itemcode='" + AxfpSpread1.Text + "' "
                                    If gconnection.getvalue(sst) = 0 Then
                                        SQL = "Insert into Itemtaxtagging(itemCode,Itemname,Taxcode,Taxdesc,taxperc,GLACCOUNTIN,void) values( "
                                        SQL = SQL & " '" + AxfpSpread1.Text + "',"

                                        AxfpSpread1.Col = 2
                                        SQL = SQL & " '" + AxfpSpread1.Text.Replace("'", " ") + "',"



                                        SQL = SQL & " 'NTAX',"


                                        SQL = SQL & " 'NO TAX',"


                                        SQL = SQL & " '0',"


                                        SQL = SQL & " 'NTAX',"


                                        SQL = SQL & " 'N')"
                                        gconnection.dataOperation(6, SQL, "Itemtaxtagging")
                                    Else
                                        SQL = "Update Itemtaxtagging set "
                                        '(Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,void,tablename,colname) values( "
                                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                        AxfpSpread1.Col = 1

                                        SQL = SQL & "itemCode= '" + AxfpSpread1.Text + "',"

                                        AxfpSpread1.Col = 2
                                        SQL = SQL & "Itemname= '" + AxfpSpread1.Text.Replace("'", " ") + "',"


                                        AxfpSpread1.Col = 3
                                        SQL = SQL & "Taxcode= 'NTAX',"

                                        AxfpSpread1.Col = 4
                                        SQL = SQL & "Taxdesc= 'NO TAX',"

                                        AxfpSpread1.Col = 5
                                        SQL = SQL & "taxperc= '0',"

                                        AxfpSpread1.Col = 6
                                        SQL = SQL & "GLACCOUNTIN= 'NTAX'"
                                        ' Sql = Sql & " 'N'"
                                        SQL = SQL & " where "

                                        AxfpSpread1.Col = 1

                                        SQL = SQL & "  ItemCode='" + AxfpSpread1.Text + "'"
                                        gconnection.dataOperation(6, SQL, "Itemtaxtagging")
                                        GoTo jjj
                                    End If

                                Else


                                    MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                End If
                            End If

                            SQL = "SELECT TOP 1   RATE as rate,UOM  FROM LiqRate WHERE ITEMCODE='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "' AND storecode='" + txt_Storecode.Text + "' ORDER BY AUTOID DESC"
                            gconnection.getDataSet(SQL, "RATE")
                            If (gdataset.Tables("RATE").Rows.Count > 0) Then
                                AxfpSpread1.Col = 3
                                AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("uom")
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

                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                        End If
                    End If
                End If

                If CMB_CATEGORY.Text = "BAR--->BAR" Then
                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        SQL = "SELECT TOP 1   RATE as rate,UOM  FROM closingqty WHERE ITEMCODE='" + Trim(AxfpSpread1.Text) + "' AND storecode='" + txt_Storecode.Text + "' ORDER BY AUTOID DESC"
                        gconnection.getDataSet(SQL, "RATE")
                        If (gdataset.Tables("RATE").Rows.Count > 0) Then
                            'SQL = "SELECT *  FROM INVENTORY_TRANSCONVERSION WHERE BASEUOM='" + gdataset.Tables("RATE").Rows(0).Item("UOM") + "' AND TRANSUOM='LTR' AND ISNULL(freeze,'N')<>'Y'"
                            'gconnection.getDataSet(SQL, "UOM")
                            'If (gdataset.Tables("UOM").Rows.Count > 0) Then
                            Label8.Text = Trim(AxfpSpread1.Text) & "   :   "

                            Label8.Text = Label8.Text & Trim(gdataset.Tables("RATE").Rows(0).Item("RATE")) + "/ " & Trim(gdataset.Tables("RATE").Rows(0).Item("UOM")) + " "
                            'Else
                            '    Label8.Text = ""
                            'End If
                        Else
                            Label8.Text = ""
                        End If
                    End If

                End If
                '''        ------------------------------------------- SLP CESS  ------------------------------------------- 
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) <> "" Then
                    Dim item As String = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 3
                    If Trim(AxfpSpread1.Text) <> "" Then
                        Dim val As Double = GetSPLCESS(item, Trim(AxfpSpread1.Text))
                        AxfpSpread1.Col = 22
                        AxfpSpread1.Text = val
                    End If
                End If
                '''        ------------------------------------------- SLP CESS  ------------------------------------------- 
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


                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then

                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
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
kkk:                        SQL = "select TAXCODE, taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                            gconnection.getDataSet(SQL, "Itemtaxtagging")
                            If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                                If (check_tAXtYPE(gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxcode"))) = False Then
                                    AxfpSpread1.Col = 10
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                                    AxfpSpread1.Col = 11
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                                End If

                            Else
                                If (MessageBox.Show("Do You Want to Create No TaxCode For Item :" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE")), MyCompanyName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Col = 1
                                    Dim sst As String = "select count(*) from Itemtaxtagging where itemcode='" + AxfpSpread1.Text + "' "
                                    If gconnection.getvalue(sst) = 0 Then
                                        SQL = "Insert into Itemtaxtagging(itemCode,Itemname,Taxcode,Taxdesc,taxperc,GLACCOUNTIN,void) values( "
                                        SQL = SQL & " '" + AxfpSpread1.Text + "',"

                                        AxfpSpread1.Col = 2
                                        SQL = SQL & " '" + AxfpSpread1.Text.Replace("'", " ") + "',"



                                        SQL = SQL & " 'NTAX',"


                                        SQL = SQL & " 'NO TAX',"


                                        SQL = SQL & " '0',"


                                        SQL = SQL & " 'NTAX',"


                                        SQL = SQL & " 'N')"
                                        gconnection.dataOperation(6, SQL, "Itemtaxtagging")
                                    Else
                                        SQL = "Update Itemtaxtagging set "
                                        '(Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,void,tablename,colname) values( "
                                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                        AxfpSpread1.Col = 1

                                        SQL = SQL & "itemCode= '" + AxfpSpread1.Text + "',"

                                        AxfpSpread1.Col = 2
                                        SQL = SQL & "Itemname= '" + AxfpSpread1.Text.Replace("'", " ") + "',"


                                        AxfpSpread1.Col = 3
                                        SQL = SQL & "Taxcode= 'NTAX',"

                                        AxfpSpread1.Col = 4
                                        SQL = SQL & "Taxdesc= 'NO TAX',"

                                        AxfpSpread1.Col = 5
                                        SQL = SQL & "taxperc= '0',"

                                        AxfpSpread1.Col = 6
                                        SQL = SQL & "GLACCOUNTIN= 'NTAX'"
                                        ' Sql = Sql & " 'N'"
                                        SQL = SQL & " where "

                                        AxfpSpread1.Col = 1

                                        SQL = SQL & "  ItemCode='" + AxfpSpread1.Text + "'"
                                        gconnection.dataOperation(6, SQL, "Itemtaxtagging")
                                        GoTo kkk
                                    End If

                                Else


                                    MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                End If
                            End If
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(2, AxfpSpread1.ActiveRow)
                        End If
                    End If
                End If
                '''        ------------------------------------------- SLP CESS  ------------------------------------------- 
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) <> "" Then
                    Dim item As String = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 3
                    If Trim(AxfpSpread1.Text) <> "" Then
                        Dim val As Double = GetSPLCESS(item, Trim(AxfpSpread1.Text))
                        AxfpSpread1.Col = 22
                        AxfpSpread1.Text = val
                    End If
                End If
                '''        ------------------------------------------- SLP CESS  ------------------------------------------- 
            ElseIf AxfpSpread1.ActiveCol = 3 Then
                AxfpSpread1.Col = 3
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)

                'QTY
            ElseIf AxfpSpread1.ActiveCol = 4 Then
                Dim ITEMCODE As String
                Dim gqty As Double

                AxfpSpread1.Col = 4
                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.Col = 1
                    ITEMCODE = AxfpSpread1.Text
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
                    If (gpocode <> "Y") Then
                        AxfpSpread1.Col = 4
                        check_MinMaxQTY("X", Trim(txt_Storecode.Text), ITEMCODE, Val(AxfpSpread1.Text))
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
            ElseIf AxfpSpread1.ActiveCol = 7 And AxfpSpread1.Lock = False Then
                AxfpSpread1.Col = 7
                If Trim(AxfpSpread1.Text) = "" Or Trim(AxfpSpread1.Text) = "0.00" Then
                    If (CATCODE(1) = "BAR") Or CATCODE(0) = "LIQ" Then
                        Dim FRM As New Frmmargin
                        FRM.farPoint = AxfpSpread1
                        AxfpSpread1.Col = 2

                        FRM.Label5.Text = "Tax Calculation For " + AxfpSpread1.Text
                        AxfpSpread1.Col = 6
                        FRM.TxtBase.Text = Val(AxfpSpread1.Text)
                        FRM.Label9.Text = AxfpSpread1.ActiveRow

                        FRM.ShowDialog(Me)
                        CALCULATE()

                    Else
                        AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                    End If

                    AxfpSpread1.SetActiveCell(23, AxfpSpread1.ActiveRow)
                Else

                    CALCULATE()
                    AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)

                End If
            ElseIf AxfpSpread1.ActiveCol = 10 Then
                AxfpSpread1.Col = 10

                If Trim(AxfpSpread1.Text) = "" Then
                    bindtaxcode()
                    AxfpSpread1.SetActiveCell(1, i + 1)
                Else
                    Dim row As Integer = AxfpSpread1.Row
                    If (check_tAXtYPE(AxfpSpread1.Text)) = False Then
                        AxfpSpread1.Row = row
                        If check_VendorType(txt_Suppliercode.Text) Then
                            SQL = "select taxper from invtaxgroupmaster where taxgroupcode='" + AxfpSpread1.Text + "'  and taxper='0'"
                        Else
                            SQL = "select taxper from invtaxgroupmaster where taxgroupcode='" + AxfpSpread1.Text + "' "
                        End If

                        Dim taxper As Double = gconnection.getvalue(SQL)

                        AxfpSpread1.Col = 11
                        AxfpSpread1.SetText(11, i, Val(taxper))
                        CALCULATE()
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 22 Then
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) <> "" Then
                    Dim item As String = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 3
                    If Trim(AxfpSpread1.Text) <> "" Then
                        Dim val As Double = GetSPLCESS(item, Trim(AxfpSpread1.Text))
                        AxfpSpread1.Col = 4
                        Dim GQTY As Double = AxfpSpread1.Text
                        AxfpSpread1.Col = 22
                        AxfpSpread1.Text = (val * GQTY)
                        CALCULATE()
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 23 Then
                CALCULATE()
                AxfpSpread1.SetActiveCell(1, i + 1)

            ElseIf AxfpSpread1.ActiveCol = 24 Then
                If Trim(AxfpSpread1.Text) <> "" Then
                    expirycheck()
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    '  AxfpSpread1.SetActiveCell(1, i + 1)
                Else
                    AxfpSpread1.SetActiveCell(24, AxfpSpread1.ActiveRow)
                End If
            End If
        ElseIf e.keyCode = Keys.F1 Then
            txt_Remarks.Focus()
        ElseIf e.keyCode = Keys.F3 Then
            CALCULATE()
            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)

        End If


    End Sub
    Private Sub bindtaxcode()
        Dim vform As New ListOperattion1

        gSQLString = "select taxgroupcode,taxper from  invtaxgroupmaster  "
        If check_VendorType(txt_Suppliercode.Text) Then
            M_WhereCondition = " where isnull(void,'')<>'Y' and taxper='0'"
        Else
            M_WhereCondition = " where isnull(void,'')<>'Y'"
        End If

        vform.Field = " Taxgroupcode "
        vform.vFormatstring = "    Taxgroupcode    |      Taxper        "
        vform.vCaption = "Tax MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1


        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_tAXtYPE(Trim(vform.keyfield))) = False Then
                AxfpSpread1.Col = 10
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.Col = 11
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield1)
                CALCULATE()
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
                If j = 4 Or j = 5 Then

                Else
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

        gSQLString = "SELECT ISNULL(pono,'') AS PONO,ISNULL(podate,'')AS PODATE,ISNULL(podepartment,'') AS PODEPARTMENT FROM PO_HDR"
        ' M_WhereCondition = " WHERE FREEZE <> 'Y' AND '" & Trim(CATEGORY) & "' = substring(pono,5,3) and postatus ='RELEASED' AND (GETDATE() BETWEEN POVALIDFROM AND POVALIDUPTO ) "
        M_WhereCondition = " WHERE FREEZE <> 'Y' AND  postatus ='RELEASED' AND (cast(GETDATE() as date) BETWEEN POVALIDFROM AND POVALIDUPTO ) "
        M_ORDERBY = " order by PONO DESC"

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
            CATCODE = Split(CMB_CATEGORY.Text, "--->")


            gSQLString = "SELECT Grndetails,Grndate,SUPPLIERNAME,STOREDESC FROM Grn_header"

            If txt_Storecode.Text <> "" Then
                M_WhereCondition = " Where Isnull(GRNTYPE,'')='GRN' and storecode='" & txt_Storecode.Text & "' AND ISNULL(GRNDETAILS,'') LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%'"
            Else
                M_WhereCondition = " Where Isnull(GRNTYPE,'')='GRN'  AND ISNULL(GRNDETAILS,'') LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%'"
            End If


            Dim vform As New List_Operation
            vform.Field = "GRNDETAILS,GRNDATE,SUPPLIERNAME,STOREDESC"
            vform.vFormatstring1 = "       GRN NO                     |         GRN DATE            |     SUPPLIERNAME                     |               STORE DESC.                  "
            vform.vCaption = "GRN CUM PURCHASE BILL HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Grnno.Text = Trim(vform.keyfield & "")
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Call txt_Grnno_Validated(txt_Grnno.Text, e)
                '  Call Grid_lock()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_Grnnohelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
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
            strsql = "SELECT * FROM PO_HDR WHERE pono='" & Trim(Txt_PONo.Text) & "'"
            strsql = strsql & " AND FREEZE <> 'Y'  and isnull(postatus,'')='RELEASED' and (cast(getdate() as date) between cast(povalidfrom as date) and cast(povalidupto as date))"
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
                    CMB_CATEGORY.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYcode")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
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
                txt_totdisc.Text = Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount")), "0.00")
                overalldiscountpo = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC"))

                TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC")), "0.00")
                '     txt_totdisc.Text = Format(Val(TOTDISC).ToString(), "0.00")
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
                    strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity AS quantity,"
                    strsql = strsql & "A.rate,A.discper, a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                    '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                    strsql = strsql & "DiscAmt,VatAmt,a.taxcode  FROM PO_ITEMDETAILS A  LEFT OUTER  JOIN GRN_DETAILS B "
                    strsql = strsql & "ON A.pono =B.POno AND A.itemcode =B.Itemcode AND A.uom =B.UOM  and a.versionno=b.versionno "
                    strsql = strsql & "WHERE A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "' GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                    strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                    strsql = strsql & ",DiscAmt,VatAmt,A.quantity  "
                    strsql = strsql & " ORDER BY A.AUTOID "

                ElseIf (potype = "RATE IN RANGE QUANTITY IN RANGE") Then

                    strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity-ISNULL(SUM(ISNULL(B.QTY,0)),0) AS quantity,"
                    strsql = strsql & "A.rate,A.discper, a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                    '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                    strsql = strsql & "DiscAmt,VatAmt,a.taxcode  FROM PO_ITEMDETAILS A  LEFT OUTER  JOIN GRN_DETAILS B "
                    strsql = strsql & "ON A.pono =B.POno AND A.itemcode =B.Itemcode AND A.uom =B.UOM  and a.versionno=b.versionno "
                    strsql = strsql & "WHERE A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "' GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                    strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                    strsql = strsql & ",DiscAmt,VatAmt,A.quantity,A.QTYRANGE HAVING "
                    strsql = strsql & "(A.quantity+A.QTYRANGE)-ISNULL(SUM(ISNULL(B.QTY,0)),0)>0 ORDER BY A.AUTOID "


                Else


                    strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity-ISNULL(SUM(ISNULL(B.QTY,0)),0) AS quantity,"
                    strsql = strsql & "A.rate,A.discper, a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                    '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                    strsql = strsql & "DiscAmt,VatAmt,a.taxcode  FROM PO_ITEMDETAILS A  LEFT OUTER  JOIN GRN_DETAILS B "
                    strsql = strsql & "ON A.pono =B.POno AND A.itemcode =B.Itemcode AND A.uom =B.UOM  and a.versionno=b.versionno "
                    strsql = strsql & "WHERE A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "' GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                    strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                    strsql = strsql & ",DiscAmt,VatAmt,A.quantity HAVING "
                    strsql = strsql & "A.quantity-ISNULL(SUM(ISNULL(B.QTY,0)),0)>0 ORDER BY A.AUTOID "
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

                        tcode = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode")
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
                            Dim sql222 As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode") + "'"

                            gconnection.getDataSet(sql222, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                AxfpSpread1.Row = i + 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z






                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("uom")
                            .Col = 4
                            'If ((Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "FIXED RATE FIXED QUANTITY") Or (Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "OPEN RATE FIXED QUANTITY")) Then
                            '    AxfpSpread1.Lock = True
                            'Else
                            '    AxfpSpread1.Lock = False
                            'End If


                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("quantity")

                            .Col = 5
                            If ((Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "FIXED RATE FIXED QUANTITY") Or (Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "FIXED RATE OPEN QUANTITY")) Then
                                AxfpSpread1.Lock = True
                            Else
                                AxfpSpread1.Lock = False
                            End If
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("rate"), "0.00"))
                            .Col = 6
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("baseamount"), "0.00"))

                            .Col = 7
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("discper"), "0.00"))


                            .Col = 8
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("DiscAmt"), "0.00"))
                            .Col = 9
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("amountafterdiscount"), "0.00"))
                            .Col = 10
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("taxcode")

                            .Col = 11
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("taxper"), "0.00"))

                            .Col = 12
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("VatAmt"), "0.00"))
                            .Col = 13
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("totalamount"), "0.00"))
                            .Col = 15
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("othchg"), "0.00"))

                            '  .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("raterange")

                            '  .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("qtyrange")

                        End With
                    Next
                    CALCULATE()
                    '    txt_totdisc.Text = Format(Val(Discnt), "0.00") ' + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount"))), "0.00")

                    '   TXT_OVERALLdiscount.Text = Format(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTOTALDISCOUNT"))), "0.00")
                    totAmt = Format(Val(txt_total.Text) - Val(txt_totdisc.Text) - Val(TXT_OVERALLdiscount.Text), "0.00")
                    ' txt_total.Text = Format(Val(totAmt), "0.00")
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

                    txt_Surchargeamt.Text = Format(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTRANSPORT"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POCF"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgplus"))) - Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgmin"))) + Val(OTHER_taxes), "0.00")
                    txt_Billamount.Text = Format(Val(txt_total.Text) - Val(txt_totdisc.Text) - Val(gdataset.Tables("PO_HDR").Rows(0).Item("POoveralldisc")) + Val(txt_Surchargeamt.Text), "0.00")
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
            If validateoninsert() = False Then

                Array.Clear(GrnQuery, 0, GrnQuery.Length)

                addoperation()
                Call UpdateGST("GRN", Trim(txt_Grnno.Text), Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy"))


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
                strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, txt_Grnno.Text, "GRN")
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

                Call UpdateGST("GRN", Trim(txt_Grnno.Text), Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy"))
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
                strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, txt_Grnno.Text, "GRN")
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
                sqlstring = sqlstring & " ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,"
                sqlstring = sqlstring & " ISNULL(STORECODE,'') STORECODE , ISNULL(STOREDESC,'MAINSTORE') STOREDESC, ISNULL(OVERALLDISCOUNT,0) OVERALLDISCOUNT,isnull(voiddate,getdate()) as voiddate,ISNULL(TotGSTAmt,0) AS TotGSTAmt,ISNULL(TotSGSTAmt,0) AS TotSGSTAmt,ISNULL(TotCGSTAmt,0) AS TotCGSTAmt,ISNULL(TotIGSTAmt,0) AS TotIGSTAmt,ISNULL(LoadingCharge,0) AS LoadingCharge  FROM GRN_HEADER"
                sqlstring = sqlstring & " WHERE ( Grndetails='" & Trim(txt_Grnno.Text) & "') "
                sqlstring = sqlstring & " and   isnull(GrnType,'')='GRN'"
                gconnection.getDataSet(sqlstring, "GRNHEADER")
                '''************************************************* SELECT record from Grn_header *********************************************''''                
                If gdataset.Tables("GRNHEADER").Rows.Count > 0 Then

                    'If Val(Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("TotGSTAmt"))) = Val(Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("TotSGSTAmt"))) + Val(Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("TotCGSTAmt"))) + Val(Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("TotIGSTAmt"))) Then
                    '    VATFLAG = False
                    'Else
                    '    VATFLAG = True
                    'End If

                    'Call GridUnLock()
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Grnno.ReadOnly = True
                    If gvendorlink = "Y" Then
                        txt_Suppliercode.Enabled = False
                        cmd_Suppliercodehelp.Enabled = False
                    End If
                    Dim SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "'"
                    gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                    If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                        CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                    End If
                    'CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY"))
                    txt_Grnno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDETAILS"))
                    Txt_PONo.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO"))

                    dtp_Grndate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDATE")), "dd/MMM/yyyy")
                    txt_Supplierinvno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERINVNO"))
                    dtp_Supplierinvdate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERDATE")), "dd/MMM/yyyy")
                    txt_Suppliercode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERCODE"))
                    txt_Suppliername.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERNAME"))
                    txt_Storecode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("STORECODE"))
                    txt_StoreDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("STOREDESC"))
                    TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("OVERALLdiscount")), "0.00")
                    txtLoadingChrg.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("LoadingCharge")), "0.00")
                    txt_Surchargeamt.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("SURCHARGEAMT")), "0.00")
                    txt_Billamount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("BILLAMOUNT")), "0.00")
                    txt_Remarks.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("REMARKS"))
                    If Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("VOID")) = "Y" Then
                        Cmd_Add.Enabled = False
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("voiddate")), "dd/MMM/yyyy")
                        Cmd_Freeze.Enabled = False
                    End If
                    '''************************************************* SELECT record from Grn_details *********************************************''''                
                    Dim vtmpitemcode, strsql As String
                    sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,isnull(baseamount,0) as baseamount,isnull(discper,0) as discper,isnull(taxcode,'') as taxcode,isnull(batchno,'') as batchno,"
                    sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(TAXPER,0) AS TAXPER,ISNULL(TAXAMOUNT,0) AS TAXAMOUNT,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,ISNULL(AMOUNTAFTERDISCOUNT,0) AS AMOUNTAFTERDISCOUNT,"
                    If GEXPIRY = "Y" Then
                        sqlstring = sqlstring & "ISNULL(EXPIRYDATE,'') AS EXPIRYDATE,"
                    End If
                    sqlstring = sqlstring & " ISNULL(VOIDITEM,'') AS VOIDITEM , isnull(OTHCHARGE,0) AS OTHCHARGE,ISNULL(MARGIN,0) AS MARGIN,ISNULL(TAX2,0) AS TAX2,ISNULL(TAX2AMT,0) AS TAX2AMT,ISNULL(ITTCS,0) AS ITTCS,ISNULL(ITTCSAMT,0) AS ITTCSAMT,ISNULL(SPLCESS,0) AS SPLCESS,ISNULL(LoadingChg,0) AS LoadingChg FROM GRN_DETAILS WHERE  GRNDETAILS ='" & Trim(txt_Grnno.Text) & "'"
                    sqlstring = sqlstring & " ORDER BY AUTOID "
                    gconnection.getDataSet(sqlstring, "GRNDETAILS")
                    If gdataset.Tables("GRNDETAILS").Rows.Count > 0 Then
                        For I = 1 To gdataset.Tables("GRNDETAILS").Rows.Count
                            AxfpSpread1.SetText(1, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE")))
                            vtmpitemcode = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMNAME")))
                            AxfpSpread1.Col = 3
                            Dim sql1 As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("GRNDETAILS").Rows(J).Item("itemcode") + "'"

                            gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                AxfpSpread1.Row = I
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z

                            ' AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))

                            '    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                            AxfpSpread1.SetText(3, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM")))

                            '  AxfpSpread1.Text = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                            AxfpSpread1.SetText(4, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("QTY")))
                            AxfpSpread1.SetText(5, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("RATE")), "0.00"))
                            AxfpSpread1.SetText(6, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("baseamount")), "0.00"))
                            '            ssgrid.SetText(7, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("PROFITPER")), "0.00"))
                            AxfpSpread1.SetText(7, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("discper")), "0.00"))
                            AxfpSpread1.SetText(8, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("discount")), "0.00"))
                            AxfpSpread1.SetText(9, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("amountafterdiscount")), "0.00"))

                            AxfpSpread1.SetText(11, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("taxper")), "0.00"))
                            AxfpSpread1.SetText(12, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("taxamount")), "0.00"))
                            AxfpSpread1.SetText(13, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("amount")), "0.00"))
                            AxfpSpread1.SetText(10, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("taxcode"))
                            AxfpSpread1.SetText(14, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("batchno"))
                            AxfpSpread1.SetText(15, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("othcharge")), "0.00"))
                            AxfpSpread1.SetText(16, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("voiditem"))
                            AxfpSpread1.SetText(17, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("MARGIN")), "0.00"))
                            AxfpSpread1.SetText(18, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("TAX2")), "0.00"))
                            AxfpSpread1.SetText(19, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("TAX2AMT")), "0.00"))
                            AxfpSpread1.SetText(20, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITTCS")), "0.00"))
                            AxfpSpread1.SetText(21, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITTCSAMT")), "0.00"))
                            AxfpSpread1.SetText(22, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("SPLCESS")), "0.00"))
                            AxfpSpread1.SetText(23, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("LoadingChg")), "0.00"))
                            If GEXPIRY = "Y" Then
                                AxfpSpread1.SetText(24, I, Format(gdataset.Tables("GRNDETAILS").Rows(J).Item("EXPIRYDATE"), "dd/MM/yy"))
                            End If
                            '           ssgrid.SetText(11, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("SALERATE")), "0.00"))
                            '          ssgrid.SetText(12, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("DBLAMOUNT")), "0.00"))
                            '         ssgrid.SetText(13, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("DBLUOM")))
                            'ssgrid.SetText(14, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("HIGHRATIO")), "0.00"))
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
                        'Call GetRights()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid GRN No : txt_Grnno_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub txt_totdisc_TextChanged(sender As Object, e As EventArgs) Handles txt_totdisc.TextChanged
        CALCULATE()
    End Sub

    Private Sub txt_totaltax_TextChanged(sender As Object, e As EventArgs) Handles txt_totaltax.TextChanged
        CALCULATE()

    End Sub

    Private Sub TXT_OVERALLdiscount_TextChanged(sender As Object, e As EventArgs) Handles TXT_OVERALLdiscount.TextChanged
        CALCULATE()

    End Sub

    Private Sub txt_Surchargeamt_TextChanged(sender As Object, e As EventArgs) Handles txt_Surchargeamt.TextChanged
        CALCULATE()

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


        Dim TaType = TaxType("GRN", Trim(txt_Grnno.Text), Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy"))

        If TaType = "GST" Or TaType = "IGST" Or TaType = "TAXL" Then

            If TaType = "GST" Or TaType = "IGST" Or TaType = "TAXL" Then
                '    Try
                '        ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
                '        Dim rViewer As New Viewer
                '        Dim sqlstring, SSQL As String
                '        Dim r As New Rpt_GrnBillMGCIGST                   'Rpt_GrnBill Rpt_GrnBill
                '        sqlstring = "SELECT ISNULL(C.RATE,0) AS PONO, ISNULL(d.GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                '        sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                '        sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                '        sqlstring = sqlstring & " ISNULL(d.ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(d.UOM,'') AS UOM, ISNULL(d.QTY,0) AS QTY, ISNULL(d.RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                '        sqlstring = sqlstring & " ISNULL(d.AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(d.Adddate,'') AS ADDDATE,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt ,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE "
                '        sqlstring = sqlstring & " FROM VW_INV_GRNBILL d LEFT  JOIN CLOSINGQTY C ON D.Itemcode=C.itemcode AND D.grndetails=C.Trnno "

                '        sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "'"
                '        'If rdo_code.Checked = True Then
                '        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                '        'ElseIf rdo_name.Checked = True Then
                '        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                '        'Else
                '        sqlstring = sqlstring & " ORDER BY d.AUTOID ,GRNDETAILS,GRNDATE "
                '        'End If
                '        gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
                '        If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then
                '            'If chk_excel.Checked = True Then
                '            '    Dim exp As New exportexcel
                '            '    exp.Show()
                '            '    Call exp.export(sqlstring, "GRN CUM PURCHASE BILL ", "")
                '            'Else
                '            rViewer.ssql = sqlstring
                '            rViewer.Report = r
                '            rViewer.TableName = "VW_INV_GRNBILL"
                '            Dim textobj1 As TextObject
                '            textobj1 = r.ReportDefinition.ReportObjects("Text13")
                '            textobj1.Text = MyCompanyName
                '            Dim textobj14 As TextObject
                '            textobj14 = r.ReportDefinition.ReportObjects("Text32")
                '            textobj14.Text = UCase(gCompanyAddress(0))
                '            Dim textobj16 As TextObject
                '            textobj1 = r.ReportDefinition.ReportObjects("Text33")
                '            textobj1.Text = UCase(gCompanyAddress(1))
                '            Dim textobj18 As TextObject
                '            textobj1 = r.ReportDefinition.ReportObjects("Text35")
                '            textobj1.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                '            Dim textobj2 As TextObject
                '            textobj2 = r.ReportDefinition.ReportObjects("Text30")
                '            textobj2.Text = gUsername

                '            Dim textobj26 As TextObject
                '            textobj26 = r.ReportDefinition.ReportObjects("Text26")
                '            textobj26.Text = "                                                Store Incharge"

                '            '   If MyCompanyName = "THE BENGAL CLUB" Then
                '            Dim textobj3 As TextObject
                '            textobj3 = r.ReportDefinition.ReportObjects("Text28")
                '            textobj3.Text = ""

                '            Dim textobj188 As TextObject
                '            textobj188 = r.ReportDefinition.ReportObjects("Text18")
                '            If UCase(gShortname) = "KBA" Then

                '                textobj188.Text = "GST/TCS"
                '            Else
                '                textobj188.Text = "GST %"
                '            End If

                '            ' End If
                '            rViewer.Show()
                '            'End If
                '        Else
                '            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                '        End If

                '        '''Else
                '        '''    gPrint = False
                '        '''    Call printoperation()
                '        '''End If
                '    Catch ex As Exception
                '        MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '        Exit Sub
                '    End Try
                'ElseIf TaType = "TAXL" Then
                '    Try
                '        ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
                '        Dim rViewer As New Viewer
                '        Dim sqlstring, SSQL As String
                '        Dim r As New Rpt_GrnBillMGCGSTNew                   'Rpt_GrnBill Rpt_GrnBill
                '        sqlstring = "SELECT ISNULL(C.RATE,0) AS PONO, ISNULL(d.GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                '        sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                '        sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                '        sqlstring = sqlstring & " ISNULL(d.ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(d.UOM,'') AS UOM, ISNULL(d.QTY,0) AS QTY, ISNULL(d.RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                '        sqlstring = sqlstring & " ISNULL(d.AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(d.Adddate,'') AS ADDDATE,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt, ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE  "
                '        sqlstring = sqlstring & " FROM VW_INV_GRNBILL d LEFT  JOIN CLOSINGQTY C ON D.Itemcode=C.itemcode AND D.grndetails=C.Trnno "

                '        sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "'"
                '        'If rdo_code.Checked = True Then
                '        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                '        'ElseIf rdo_name.Checked = True Then
                '        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                '        'Else
                '        sqlstring = sqlstring & " ORDER BY d.AUTOID ,GRNDETAILS,GRNDATE "
                '        'End If
                '        gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
                '        If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then

                '            Dim sqlstring1 = "SELECT * FROM vW_GRN_DET WHERE GRNDETAILS='" & Trim(txt_Grnno.Text) & "' "
                '            gconnection.getDataSet(sqlstring1, "vW_GRN_DET")

                '            Call rViewer.GetDetails1New(sqlstring1, "vW_GRN_DET", r)

                '            'If chk_excel.Checked = True Then
                '            '    Dim exp As New exportexcel
                '            '    exp.Show()
                '            '    Call exp.export(sqlstring, "GRN CUM PURCHASE BILL ", "")
                '            'Else
                '            rViewer.ssql = sqlstring
                '            rViewer.Report = r
                '            rViewer.TableName = "VW_INV_GRNBILL"
                '            Dim textobj1 As TextObject
                '            textobj1 = r.ReportDefinition.ReportObjects("Text13")
                '            textobj1.Text = MyCompanyName
                '            Dim textobj14 As TextObject
                '            textobj14 = r.ReportDefinition.ReportObjects("Text32")
                '            textobj14.Text = UCase(gCompanyAddress(0))
                '            Dim textobj16 As TextObject
                '            textobj1 = r.ReportDefinition.ReportObjects("Text33")
                '            textobj1.Text = UCase(gCompanyAddress(1))
                '            Dim textobj18 As TextObject
                '            textobj1 = r.ReportDefinition.ReportObjects("Text35")
                '            textobj1.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                '            Dim textobj2 As TextObject
                '            textobj2 = r.ReportDefinition.ReportObjects("Text30")
                '            textobj2.Text = gUsername

                '            Dim textobj26 As TextObject
                '            textobj26 = r.ReportDefinition.ReportObjects("Text26")
                '            textobj26.Text = "                                                Store Incharge"

                '            '   If MyCompanyName = "THE BENGAL CLUB" Then
                '            Dim textobj3 As TextObject
                '            textobj3 = r.ReportDefinition.ReportObjects("Text28")
                '            textobj3.Text = ""

                '            Dim textobj188 As TextObject
                '            textobj188 = r.ReportDefinition.ReportObjects("Text18")
                '            If UCase(gShortname) = "KBA" Then

                '                textobj188.Text = "GST/TCS"
                '            Else
                '                textobj188.Text = "GST %"
                '            End If

                '            ' End If
                '            rViewer.Show()
                '            'End If
                '        Else
                '            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                '        End If

                '        '''Else
                '        '''    gPrint = False
                '        '''    Call printoperation()
                '        '''End If
                '    Catch ex As Exception
                '        MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '        Exit Sub
                '    End Try
                'Else
                Try
                    ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL As String
                    Dim r As New Rpt_GrnBillMGCGSTNew                   'Rpt_GrnBill Rpt_GrnBill
                    sqlstring = "SELECT ISNULL(C.RATE+ case when isnull(LoadingChg,0) <>0 then LoadingChg/C.qty else 0 end ,0) AS PONO, ISNULL(d.GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                    sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                    sqlstring = sqlstring & " ISNULL(d.ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(d.UOM,'') AS UOM, ISNULL(d.QTY,0) AS QTY, ISNULL(d.RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                    sqlstring = sqlstring & " ISNULL(d.AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(d.Adddate,'') AS ADDDATE,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt , ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE "
                    sqlstring = sqlstring & " FROM VW_INV_GRNBILL d LEFT  JOIN CLOSINGQTY C ON D.Itemcode=C.itemcode AND D.grndetails=C.Trnno "

                    sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "'"
                    'If rdo_code.Checked = True Then
                    '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                    'ElseIf rdo_name.Checked = True Then
                    '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                    'Else
                    sqlstring = sqlstring & " ORDER BY d.AUTOID ,GRNDETAILS,GRNDATE "
                    'End If
                    gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
                    If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then

                        Dim sqlstring1 = "SELECT * FROM vW_GRN_DET WHERE GRNDETAILS='" & Trim(txt_Grnno.Text) & "'  ORDER BY ORD , TOTALAMOUNT"
                        gconnection.getDataSet(sqlstring1, "vW_GRN_DET")

                        Call rViewer.GetDetails1New(sqlstring1, "vW_GRN_DET", r)

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

                        Dim textobj26 As TextObject
                        textobj26 = r.ReportDefinition.ReportObjects("Text26")
                        textobj26.Text = "                               Store Incharge"

                        '   If MyCompanyName = "THE BENGAL CLUB" Then
                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text28")
                        textobj3.Text = ""

                        Dim textobj188 As TextObject
                        textobj188 = r.ReportDefinition.ReportObjects("Text18")
                       textobj188.Text = "GST %"


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
                Dim r As New Rpt_GrnBillMGC                   'Rpt_GrnBill Rpt_GrnBill
                sqlstring = "SELECT ISNULL(C.RATE+ case when isnull(LoadingChg,0) <>0 then LoadingChg/C.qty else 0 end ,0) AS PONO, ISNULL(d.GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                sqlstring = sqlstring & " ISNULL(d.ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(d.UOM,'') AS UOM, ISNULL(d.QTY,0) AS QTY, ISNULL(d.RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                sqlstring = sqlstring & " ISNULL(d.AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(d.Adddate,'') AS ADDDATE  "
                sqlstring = sqlstring & " FROM VW_INV_GRNBILL d LEFT  JOIN CLOSINGQTY C ON D.Itemcode=C.itemcode AND D.grndetails=C.Trnno "

                sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "'"
                'If rdo_code.Checked = True Then
                '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                'ElseIf rdo_name.Checked = True Then
                '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                'Else
                sqlstring = sqlstring & " ORDER BY d.AUTOID ,GRNDETAILS,GRNDATE "
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

                    Dim textobj26 As TextObject
                    textobj26 = r.ReportDefinition.ReportObjects("Text26")
                    textobj26.Text = "                                                Store Incharge"

                    '   If MyCompanyName = "THE BENGAL CLUB" Then
                    Dim textobj3 As TextObject
                    textobj3 = r.ReportDefinition.ReportObjects("Text28")
                    textobj3.Text = ""

                    Dim textobj188 As TextObject
                    textobj188 = r.ReportDefinition.ReportObjects("Text18")
                    If UCase(gShortname) = "KBA" Then

                        textobj188.Text = "VAT/TCS"
                    Else
                        textobj188.Text = "VAT%"
                    End If

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

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
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
            strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode)
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
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Suppliercode_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub txt_Supplierinvno_Validated(sender As Object, e As EventArgs) Handles txt_Supplierinvno.Validated
        Dim sqlstring As String

        sqlstring = "Select * from grn_header where Supplierinvno='" + txt_Supplierinvno.Text + "' and Suppliercode='" + txt_Suppliercode.Text + "'"
        gconnection.getDataSet(sqlstring, "grn_header")
        If (gdataset.Tables("grn_header").Rows.Count > 0) Then
            MessageBox.Show("Invoice No Already Exist", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub

        End If
    End Sub

    Private Sub AxfpSpread1_Advance(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread1.Advance

    End Sub

    Private Sub directgrn_CheckedChanged(sender As Object, e As EventArgs) Handles directgrn.CheckedChanged

        If directgrn.Checked = True Then
            grp_Grngroup1.Visible = False
        Else
            grp_Grngroup1.Visible = True
        End If

    End Sub
End Class