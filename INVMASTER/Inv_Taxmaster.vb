Public Class Inv_Taxmaster
    Dim gconnection As New GlobalClass
    Private Sub clearoperation()
        Txt_taxcode.Text = ""
        Txt_taxname.Text = ""
        Txt_taxper.Text = 0
        cbo_CONTYPE.SelectedIndex = -1
        Cmd_Add.Text = "Add[F7]"
        LblFreeze.Visible = False
        Cmd_Freeze.Text = "Freeze[F8]"
        Txt_taxcode.Focus()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
      
    End Sub


    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "Tax Master"

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
        'Me.Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    'Me.Cmd_View.Enabled = True
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
                    'Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    ' Me.cmd_auth.Enabled = True
                End If
            Next
        End If
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


    Private Function validateadd() As Boolean
        Dim sqlstring As String
        If (Txt_taxcode.Text = "") Then
            Return True

        End If
        If (Txt_taxname.Text = "") Then
            Return True
        End If
        If (Txt_taxper.Text = "") Then
            Return True
        End If
        If (cbo_CONTYPE.Text = "") Then
            Return True
        End If
        If (Cmd_Add.Text = "Add[F7]") Then
            sqlstring = "select isnull(taxcode,'') as taxcode from inv_taxmaster where taxcode='" & Trim(Txt_taxcode.Text) & "'"
            gconnection.getDataSet(sqlstring, "inv1")
            If gdataset.Tables("inv1").Rows.Count > 0 Then
                MessageBox.Show(" Tax Code already exists ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_taxcode.Text = ""
                Txt_taxcode.Focus()
                Return True
                Exit Function
            End If
        End If
       Return False
    End Function
    Private Sub addoperation()

        If (validateadd() = False) Then
            Dim sql As String = "Insert into inv_taxmaster(taxcode,taxname,taxper,taxtype,void,adduser,adddatetime)"
            sql = sql & " values('" + Txt_taxcode.Text + "','" + Txt_taxname.Text + "','" + Txt_taxper.Text + "','" + cbo_CONTYPE.Text + "','N','" + gUsername + "',getdate())"
            gconnection.dataOperation(1, sql, "inv_taxmaster")
        End If

    End Sub
    Private Sub updateoperation()
        Dim insert(0) As String
        If (validateadd() = False) Then
            Dim sql As String = "Insert into inv_taxmaster_log ( taxcode,taxname,taxper,taxtype,updateuser,updatedatetime)select taxcode,taxname,taxper,taxtype,'" + gUsername + "',getdate() from inv_taxmaster  "
            insert(0) = sql

            sql = " update inv_taxmaster set taxper=" + Txt_taxper.Text + " ,taxname='" + Txt_taxname.Text + "', void='N', updateuser='" + gUsername + "' , updatedatetime= getdate() where  taxcode='" + Txt_taxcode.Text + "'"
            gconnection.dataOperation(6, sql, "inv_taxmaster")
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sql
            gconnection.MoreTrans(insert)

        End If
    End Sub
    Private Sub voidoperation()
        Dim insert(0) As String
        If (validateadd() = False) Then
            Dim sql As String = "Insert into inv_taxmaster_log ( taxcode,taxname,taxper,taxtype,voiduser,voiddatetime)select taxcode,taxname,taxper,taxtype,'" + gUsername + "',getdate() from inv_taxmaster where  taxcode='" + Txt_taxcode.Text + "'"
            insert(0) = sql

            sql = " update inv_taxmaster set taxper=" + Txt_taxper.Text + " , void='Y', voiduser='" + gUsername + "' , voiddatetime= getdate() where  taxcode='" + Txt_taxcode.Text + "'"

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sql
            gconnection.MoreTrans(insert)


                End If
    End Sub
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()
    End Sub

    Private Sub Inv_Taxmaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub


    Private Sub Inv_Taxmaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Txt_taxcode.ReadOnly = False
        Txt_taxname.ReadOnly = False
        Txt_taxper.ReadOnly = False

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
    End Sub

    Private Sub cmD_CONNOHELP_Click(sender As Object, e As EventArgs) Handles cmD_CONNOHELP.Click
        gSQLString = "SELECT ISNULL(taxcode,'') AS taxcode,ISNULL(taxname,'') AS taxname,isnull(taxper,0) as taxper FROM inv_taxmaster"
        M_WhereCondition = " where isnull(void,'')<>'Y' "
        Dim vform As New ListOperattion1
        vform.Field = "taxcode,taxname"
        vform.vFormatstring = "        Tax Code      |           Tax Name             |  Tax Per                             "
        vform.vCaption = "TAX MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_taxcode.Text = Trim(vform.keyfield & "")
            Call Txt_taxcode_Validated(Txt_taxcode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Txt_taxcode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_taxcode.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (Txt_taxcode.Text = "") Then
                cmD_CONNOHELP_Click(sender, e)
                Txt_taxname.Focus()
            Else
                Txt_taxname.Focus()
            End If
        End If
    End Sub



    Private Sub Txt_taxcode_Validated(sender As Object, e As EventArgs) Handles Txt_taxcode.Validated
        If (Txt_taxcode.Text <> "") Then
            Dim SQL As String = "SELECT TAXNAME,TAXPER,TAXTYPE,VOID FROM inv_taxmaster where taxcode='" + Txt_taxcode.Text + "'  "
            gconnection.getDataSet(SQL, "inv_taxmaster")
            If (gdataset.Tables("inv_taxmaster").Rows.Count > 0) Then
                Txt_taxname.Text = gdataset.Tables("inv_taxmaster").Rows(0).Item("TAXNAME").ToString()
                Txt_taxper.Text = gdataset.Tables("inv_taxmaster").Rows(0).Item("TAXPER").ToString()
                cbo_CONTYPE.Text = gdataset.Tables("inv_taxmaster").Rows(0).Item("TAXTYPE").ToString()
                If (gdataset.Tables("inv_taxmaster").Rows(0).Item("TAXTYPE").ToString() = "Y") Then
                    LblFreeze.Text = "Record Freezed"
                    LblFreeze.Visible = True
                    Cmd_Add.Text = "Update[F7]"
                Else
                    Cmd_Add.Text = "Update[F7]"
                    LblFreeze.Visible = False
                End If
            End If
        Else
            Txt_taxcode.Focus()
        End If


    End Sub

    Private Sub Txt_taxname_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_taxname.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (Txt_taxname.Text <> "") Then
                Txt_taxper.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_taxper_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_taxper.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (Txt_taxper.Text <> "") Then
                cbo_CONTYPE.Focus()
            End If
        End If
    End Sub

    Private Sub cbo_CONTYPE_KeyDown(sender As Object, e As KeyEventArgs) Handles cbo_CONTYPE.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (cbo_CONTYPE.Text <> "") Then
                Cmd_Add.Focus()
            End If
        End If
    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        If (Cmd_Add.Text = "Add[F7]") Then
            addoperation()
            clearoperation()
        ElseIf (Cmd_Add.Text = "Update[F7]") Then
            updateoperation()
            clearoperation()
        End If
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        If (Cmd_Freeze.Text = "Freeze[F8]") Then
            voidoperation()
            clearoperation()
        Else

        End If

    End Sub

    
End Class