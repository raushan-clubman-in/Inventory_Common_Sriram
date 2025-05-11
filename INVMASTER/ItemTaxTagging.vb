Public Class ItemTaxTagging
    Dim gconnection As New GlobalClass
  

    Function checkvalidate() As Boolean
        Dim flag As Boolean = False
        Dim Taxcode As String
        Dim accountcode As String
        For s As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = s
            AxfpSpread1.Col = 3
            Taxcode = AxfpSpread1.Text
            If Taxcode <> "" Then
                'Dim sql As String = " select * from accountstaxmaster where taxcode='" + Axfpspread1.Text + "'"
                'gconnection.getDataSet(sql, "Accountsglaccountmaster")
                'If (gdataset.Tables("Accountsglaccountmaster").Rows.Count = 0) Then
                '    MsgBox("Taxcode is incorrect..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname)
                '    Exit Function
                'End If
            End If
            AxfpSpread1.Row = s
            AxfpSpread1.Col = 6
            accountcode = AxfpSpread1.Text
            If accountcode <> "" Then
                'Dim sql As String = " select * from accountstaxmaster where glaccountin='" + Axfpspread1.Text + "'"
                'gconnection.getDataSet(sql, "Accountsglaccountmaster")
                'If (gdataset.Tables("Accountsglaccountmaster").Rows.Count = 0) Then
                '    MsgBox("Accountcode is incorrect..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname)
                '    Exit Function
                'End If
            End If
        Next
        flag = True
        Return flag
    End Function


    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 732
        K = 1016
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
                        ElseIf Controls(i_i).Name = "GroupBox2" Then
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

    Private Sub ItemTaxTagging_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F7 And cmd_save.Visible = True Then
            Call cmd_save_Click(cmd_save, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmd_exit_Click(cmd_exit, e)
            Exit Sub
        End If
    End Sub


    Private Sub ItemTaxTagging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                'Me.CmdClear.Visible = True
                Me.cmd_exit.Visible = True
            End If
        End If

        gconnection.ExcuteStoreProcedure("delete  from Itemtaxtagging where TaxCode=''")
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        GroupBox1.Controls.Add(AxfpSpread1)
        AxfpSpread1.Location = New Point(10, 10)
        AxfpSpread1.Width = GroupBox1.Width - 10



        Dim sql1 As String = "Select ItemCode,Itemname,Taxcode,ISNULL(Taxdesc,'')  AS Taxdesc,invtaxgroupmaster.taxper AS taxperc,GLACCOUNTIN from Itemtaxtagging inner join invtaxgroupmaster ON Itemtaxtagging.TaxCode= invtaxgroupmaster.taxgroupcode  where isnull(Itemtaxtagging.void,'')<>'Y' UNION "
        sql1 = sql1 & " SELECT distinct ItemCode,Itemname,'' AS Taxcode,'' AS Taxdesc,'0' AS taxperc,'' AS GLACCOUNTIN FROM INV_InventoryItemMaster "
        sql1 = sql1 & " WHERE itemcode NOT IN (Select ItemCode from Itemtaxtagging where isnull(void,'')<>'Y') and isnull(void,'')<>'Y' "
        'order by " & Codeorderfield

        gconnection.getDataSet(sql1, "Itemtaxtagging")
        If gdataset.Tables("Itemtaxtagging").Rows.Count > 0 Then
            AxfpSpread1.MaxRows = gdataset.Tables("Itemtaxtagging").Rows.Count
            For i As Integer = 0 To gdataset.Tables("Itemtaxtagging").Rows.Count - 1
                With AxfpSpread1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("Itemtaxtagging").Rows(i).Item("ItemCode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("Itemtaxtagging").Rows(i).Item("Itemname")
                    .Row = i + 1
                    .Col = 3
                    .Text = gdataset.Tables("Itemtaxtagging").Rows(i).Item("Taxcode")
                    .Row = i + 1
                    .Col = 4
                    .Text = gdataset.Tables("Itemtaxtagging").Rows(i).Item("Taxdesc")
                    .Row = i + 1
                    .Col = 5
                    .Text = gdataset.Tables("Itemtaxtagging").Rows(i).Item("taxperc")
                    .Row = i + 1
                    .Col = 6
                    .Text = gdataset.Tables("Itemtaxtagging").Rows(i).Item("GLACCOUNTIN")
                    '.Row = i + 1
                    '.Col = 7
                    '.Text = gdataset.Tables("Accountstagging").Rows(i).Item("costcentercode")
                    '.Row = i + 1
                    '.Col = 8
                    '.Text = gdataset.Tables("Accountstagging").Rows(i).Item("costcenterdesc")


                End With
            Next
        End If
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        AxfpSpread1.Row = 1
        AxfpSpread1.Col = 3
        AxfpSpread1.Focus()
    End Sub


    Private Sub GetRights()
        Dim i, x As Integer
        'Dim vmain, vsmod, vssmod As Long
        Dim SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "Group Master"

        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.cmd_save.Enabled = False
        '  Me.Cmd_Freeze.Enabled = False
        'Me.Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_save.Enabled = True
                    '  Me.Cmd_Freeze.Enabled = True
                    'Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.cmd_save.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.cmd_save.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.cmd_save.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    '   Me.Cmd_Freeze.Enabled = True
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

    Private Sub FillTax()
        AxfpSpread1.Col = 3
        If AxfpSpread1.Text = "" Then
            Try
                Dim vform As New ListOperattion1
                Dim K As Integer
                ' gSQLString = " select taxcode,taxdesc,taxpercentage,GLACCOUNTIN from accountstaxmaster "

                gSQLString = " select taxgroupcode as code, taxper as taxpercentage from invtaxgroupmaster "

                '  gSQLString = gSQLString & " ISNULL(CONVVALUE,0) AS CONVUOM FROM INVENTORYITEMMASTER I"
                If Trim(search) = " " Then
                    M_WhereCondition = ""
                Else
                    M_WhereCondition = " WHERE  isnull(void,'') <> 'Y' "
                End If
                vform.Field = " Taxgroupcode "
                vform.vFormatstring = "    Taxgroupcode    |  Taxper  "
                vform.vCaption = "INVENTORY Tax CODE HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1
                'vform.KeyPos2 = 2
                'vform.Keypos3 = 3
                'vform.Keypos5 = 5
                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then
                    AxfpSpread1.Col = 3
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(vform.keyfield)
                    'Axfpspread1.Col = 4
                    'Axfpspread1.Row = Axfpspread1.ActiveRow
                    'Axfpspread1.Text = Trim(vform.keyfield1)
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(vform.keyfield1)
                    'Axfpspread1.Col = 6
                    'Axfpspread1.Row = Axfpspread1.ActiveRow
                    'Axfpspread1.Text = Trim(vform.keyfield3)
                    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                Else

                    Exit Sub
                End If
                vform.Close()
                vform = Nothing
            Catch ex As Exception
                MessageBox.Show("Plz Check Error : FillMenu" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            Try

                Dim vform As New ListOperattion1
                Dim K As Integer

                AxfpSpread1.Col = 3
                Dim sqlstring As String = ""
                SQLString = " select taxgroupcode as code, taxper as taxpercentage from invtaxgroupmaster where  void <> 'Y' and taxgroupcode='" + AxfpSpread1.Text + "'"

                ' gSQLString = " select taxcode,taxdesc,taxpercentage,GLACCOUNTIN from accountstaxmaster "
                '  gSQLString = gSQLString & " ISNULL(CONVVALUE,0) AS CONVUOM FROM INVENTORYITEMMASTER I"
                'If Trim(search) = " " Then
                '    M_WhereCondition = ""
                'Else
                '    M_WhereCondition = " WHERE  void <> 'Y' and taxgroupcode='" + AxfpSpread1.Text + "' "
                'End If
                'vform.Field = " Taxgroupcode "
                'vform.vFormatstring = "    Taxgroupcode    |  Taxpercentage  "
                'vform.vCaption = "INVENTORY Tax CODE HELP"
                'vform.KeyPos = 0
                'vform.KeyPos1 = 1

                'vform.Keypos5 = 5
                gconnection.getDataSet(sqlstring, "invtaxgroupmaster")

                If gdataset.Tables("invtaxgroupmaster").Rows.Count > 0 Then
                    AxfpSpread1.Col = 3
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(gdataset.Tables("invtaxgroupmaster").Rows(0).Item("code"))
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(gdataset.Tables("invtaxgroupmaster").Rows(0).Item("taxpercentage"))
                    'Axfpspread1.Col = 5
                    'Axfpspread1.Row = Axfpspread1.ActiveRow
                    'Axfpspread1.Text = Trim(vform.keyfield2)
                    'Axfpspread1.Col = 6
                    'Axfpspread1.Row = Axfpspread1.ActiveRow
                    'Axfpspread1.Text = Trim(vform.keyfield3)
                    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                Else

                    Exit Sub
                End If
                ' vform.Close()
                'vform = Nothing
            Catch ex As Exception
                MessageBox.Show("Plz Check Error : FillMenu" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub FillTaxdesc()

        If AxfpSpread1.Text = "" Then
            Try
                Dim vform As New ListOperattion1
                Dim K As Integer
                gSQLString = " select taxcode,taxdesc,taxpercentage,GLACCOUNTIN from accountstaxmaster "
                '  gSQLString = gSQLString & " ISNULL(CONVVALUE,0) AS CONVUOM FROM INVENTORYITEMMASTER I"
                If Trim(search) = " " Then
                    M_WhereCondition = ""
                Else
                    M_WhereCondition = " WHERE  freezeflag <> 'Y' "
                End If
                vform.Field = " Taxcode,Taxdesc "
                vform.vFormatstring = "    Taxcode    |                     Taxdesc                    |  Taxpercentage  "
                vform.vCaption = "INVENTORY Tax CODE HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1
                vform.KeyPos2 = 2
                vform.Keypos3 = 3
                'vform.Keypos5 = 5
                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then
                    AxfpSpread1.Col = 3
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(vform.keyfield)
                    AxfpSpread1.Col = 4
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(vform.keyfield1)
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(vform.keyfield2)
                    AxfpSpread1.Col = 6
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(vform.keyfield3)
                    AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow + 1)
                Else

                    Exit Sub
                End If
                vform.Close()
                vform = Nothing
            Catch ex As Exception
                MessageBox.Show("Plz Check Error : FillMenu" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        Else
            Try

                Dim vform As New ListOperattion1
                Dim K As Integer

                AxfpSpread1.Col = 4
                gSQLString = " select taxcode,taxdesc,taxpercentage,GLACCOUNTIN from accountstaxmaster "
                '  gSQLString = gSQLString & " ISNULL(CONVVALUE,0) AS CONVUOM FROM INVENTORYITEMMASTER I"
                If Trim(search) = " " Then
                    M_WhereCondition = ""
                Else
                    M_WhereCondition = " WHERE  freezeflag <> 'Y' and taxdesc='" + AxfpSpread1.Text + "' "
                End If
                vform.Field = " Taxcode,Taxdesc "
                vform.vFormatstring = "    Taxcode    |                     Taxdesc                    |  Taxpercentage  "
                vform.vCaption = "INVENTORY Tax CODE HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1
                vform.KeyPos2 = 2
                vform.Keypos3 = 3
                'vform.Keypos5 = 5
                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then
                    AxfpSpread1.Col = 3
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(vform.keyfield)
                    AxfpSpread1.Col = 4
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(vform.keyfield1)
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(vform.keyfield2)
                    AxfpSpread1.Col = 6
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(vform.keyfield3)
                    AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow + 1)
                Else

                    Exit Sub
                End If
                vform.Close()
                vform = Nothing
            Catch ex As Exception
                MessageBox.Show("Plz Check Error : FillMenu" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub
  
    Sub bindaccode()
        AxfpSpread1.Row = AxfpSpread1.ActiveRow
        AxfpSpread1.Col = 6


        If AxfpSpread1.Text = "" Then
            gSQLString = "Select Accode,ACDESC from Accountsglaccountmaster"
            M_WhereCondition = " where isnull(freezeflag,'') <> 'Y' "
            Dim vform As New ListOperattion1
            vform.Field = "Accode "
            vform.vFormatstring = "ACCOUNT CODE | ACCOUNT DESCRIPTION            |  "
            vform.vCaption = "ACCOUNT CODE MASTER HELP"
            vform.KeyPos = 0


            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                AxfpSpread1.Col = 6
                AxfpSpread1.Text = vform.keyfield
                AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow + 1)
                'If vform.keyfield3 = "A" Or vform.keyfield3 = "L" Then
                '    If MsgBox("You Are Using Asset and Liabilities Account..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname) = MsgBoxResult.No Then
                '        'Axfpspread1.Col = 3

                '        'Axfpspread1.Focus()
                '        Axfpspread1.SetActiveCell(5, Axfpspread1.ActiveRow)
                '        Exit Sub

                '    Else

                '        Axfpspread1.Col = 3
                '        Axfpspread1.Text = vform.keyfield

                '        Axfpspread1.Col = 4
                '        Axfpspread1.Text = vform.keyfield1
                '        If vform.keyfield2 = "Y" Then
                '            Axfpspread1.Col = 5
                '            Axfpspread1.Text = ""

                '        End If
                '    End If
                'ElseIf vform.keyfield3 = "I" Or vform.keyfield3 = "E" Then

                '    Axfpspread1.Col = 3
                '    Axfpspread1.Text = vform.keyfield

                '    Axfpspread1.Col = 4
                '    Axfpspread1.Text = vform.keyfield1


                '    If vform.keyfield2 = "Y" Then
                '        'Axfpspread1.Col = 5
                '        'Axfpspread1.Text = ""
                '        'Axfpspread1.Focus()
                '        Axfpspread1.SetActiveCell(4, Axfpspread1.ActiveRow)
                '    Else
                '        'If Costcenter = True Then
                '        '    'Axfpspread1.Col = 7
                '        '    'Axfpspread1.Text = ""
                '        '    'Axfpspread1.Focus()
                '        '    Axfpspread1.SetActiveCell(6, Axfpspread1.ActiveRow)
                '        'End If
                '        'Axfpspread1.Col = 3
                '        'Axfpspread1.Focus()
                '        Axfpspread1.SetActiveCell(2, Axfpspread1.ActiveRow + 1)
                '    End If


                'End If

            End If

            vform.Close()
            vform = Nothing
        Else
            AxfpSpread1.Row = AxfpSpread1.ActiveRow

            AxfpSpread1.Col = 6
            gSQLString = "Select Accode,Acdesc from Accountsglaccountmaster where Accode='" + AxfpSpread1.Text + "'"
            gconnection.getDataSet(gSQLString, "Accountsglaccountmaster")
            If (gdataset.Tables("Accountsglaccountmaster").Rows.Count > 0) Then

                AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow + 1)
                'If Trim(gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc") & "") <> "" Then
                '    If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "A" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "L" Then
                '        If MsgBox("You Are Using Asset and Liabilities Account..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname) = MsgBoxResult.No Then
                '            Axfpspread1.Col = 3

                '            Axfpspread1.Focus()
                '            Axfpspread1.SetActiveCell(2, Axfpspread1.ActiveRow)
                '            Exit Sub

                '        Else

                '            Axfpspread1.Col = 4
                '            Axfpspread1.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                '            If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                '                Axfpspread1.Col = 5
                '                Axfpspread1.Text = ""

                '            End If
                '        End If
                '    ElseIf gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "I" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "E" Then


                '        Axfpspread1.Col = 4
                '        Axfpspread1.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                '        If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                '            Axfpspread1.Col = 5
                '            Axfpspread1.Text = ""

                '        Else
                '            'If Costcenter = True Then
                '            '    Axfpspread1.Col = 7
                '            '    Axfpspread1.Text = ""
                '            '    Axfpspread1.Focus()
                '            '    Axfpspread1.SetActiveCell(6, Axfpspread1.ActiveRow)
                '            'End If

                '        End If


                '    End If

                'End If
            Else
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Col = 6
                AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, "")
            End If
          
        End If



    End Sub

  
    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        Me.Close()
    End Sub

    Private Sub cmd_save_Click(sender As Object, e As EventArgs) Handles cmd_save.Click
        If checkvalidate() = False Then
            Exit Sub
        End If
        Dim Sql As String = ""
        Dim insert(0) As String
        For s As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = s + 1
            AxfpSpread1.Col = 1
            Dim sst As String = "select count(*) from Itemtaxtagging where itemcode='" + AxfpSpread1.Text + "' "
            If gconnection.getvalue(sst) = 0 Then
                Sql = "Insert into Itemtaxtagging(itemCode,Itemname,Taxcode,Taxdesc,taxperc,GLACCOUNTIN,void) values( "
                Sql = Sql & " '" + AxfpSpread1.Text + "',"

                AxfpSpread1.Col = 2
                Sql = Sql & " '" + AxfpSpread1.Text.Replace("'", " ") + "',"


                AxfpSpread1.Col = 3
                Sql = Sql & " '" + AxfpSpread1.Text + "',"

                AxfpSpread1.Col = 4
                Sql = Sql & " '" + AxfpSpread1.Text + "',"

                AxfpSpread1.Col = 5
                Sql = Sql & " '" + AxfpSpread1.Text + "',"

                AxfpSpread1.Col = 6
                Sql = Sql & " '" + AxfpSpread1.Text + "',"

                AxfpSpread1.Col = 7
                Sql = Sql & " 'N')"
                'Axfpspread1.Row = s
                'Axfpspread1.Col = 8
                'Sql = Sql & " '" + Axfpspread1.Text + "',"
                'Sql = Sql & " 'N',"
                'Sql = Sql & " '" + tabname + "',"
                'Sql = Sql & " )"
            Else
                Sql = "Update Itemtaxtagging set "
                '(Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,void,tablename,colname) values( "
                AxfpSpread1.Row = s + 1
                AxfpSpread1.Col = 1

                Sql = Sql & "itemCode= '" + AxfpSpread1.Text + "',"

                AxfpSpread1.Col = 2
                Sql = Sql & "Itemname= '" + AxfpSpread1.Text.Replace("'", " ") + "',"


                AxfpSpread1.Col = 3
                Sql = Sql & "Taxcode= '" + AxfpSpread1.Text + "',"

                AxfpSpread1.Col = 4
                Sql = Sql & "Taxdesc= '" + AxfpSpread1.Text + "',"

                AxfpSpread1.Col = 5
                Sql = Sql & "taxperc= '" + AxfpSpread1.Text + "',"

                AxfpSpread1.Col = 6
                Sql = Sql & "GLACCOUNTIN= '" + AxfpSpread1.Text + "'"
                ' Sql = Sql & " 'N'"
                Sql = Sql & " where "

                AxfpSpread1.Col = 1

                Sql = Sql & "  ItemCode='" + AxfpSpread1.Text + "'"


            End If
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = Sql

        Next
        gconnection.MoreTrans(insert)

    End Sub

    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        If e.keyCode = Keys.Enter Then
            If AxfpSpread1.ActiveCol = 3 Then
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                FillTax()


            ElseIf AxfpSpread1.ActiveCol = 6 Then
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                bindaccode()
            End If
        ElseIf e.keyCode = Keys.F8 Then
            Dim search As New frmSearch
            search.farPoint = AxfpSpread1
            search.Text = "Item Search"
            search.ShowDialog(Me)
            Exit Sub
        ElseIf e.keyCode = Keys.F3 Then
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Col = 3
            AxfpSpread1.Text = ""
            AxfpSpread1.Col = 4
            AxfpSpread1.Text = ""

            AxfpSpread1.Col = 5
            AxfpSpread1.Text = "0.00"
            AxfpSpread1.Col = 6
            AxfpSpread1.Text = ""
          
            AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow)
        End If
    End Sub
    Private Sub ItemTaxTagging_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

    End Sub
End Class