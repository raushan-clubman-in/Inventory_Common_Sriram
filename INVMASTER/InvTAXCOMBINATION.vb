Public Class InvTAXCOMBINATION
    Dim gconnection As New GlobalClass
    Dim taxlist As New ArrayList
    Dim taxlist2 As New ArrayList
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

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "Tax Grouping"

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
        '  Me.Cmd_Freeze.Enabled = False
        'Me.Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    '  Me.Cmd_Freeze.Enabled = True
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

    Private Sub InvTAXCOMBINATION_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 And Cmd_Clear.Visible = True Then
            ' addoperation()
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
            ' addoperation()
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
            ' addoperation()
            Call Cmd_Freeze_Click(Cmd_Freeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 And Cmd_Exit.Visible = True Then
            ' addoperation()
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub


    Private Sub InvTAXCOMBINATION_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        'AxfpSpread1.Width = GroupBox1.Width - 60
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
    End Sub

    Private Sub addoperatin()
        Dim sql As String
        Dim insert(0) As String
        sqlstring = "Insert into invtaxgroupmaster (taxgroupcode,taxper,void,adduser,adddate,Effectfrom) values("
        sqlstring = sqlstring & "'" + txt_taxgroup.Text + "','" + txttaxper.Text + "','N','" + gUsername + "',getdate(),getDate() )"
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
         
            sql = "Insert into invtaxgroupmasterdetail (taxgroupcode,tax,taxon,taxper,adduser,adddate,Effectfrom)"
                sql = sql & " values ('" + txt_taxgroup.Text + "',"
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                sql = sql & "  '" + AxfpSpread1.Text + "',"
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 2
                sql = sql & "  '" + AxfpSpread1.Text + "',"
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 3

                sql = sql & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
            sql = sql & " '" + gUsername + "' ,getdate(),getdate())"

                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sql




        Next
        gconnection.MoreTrans(insert)

    End Sub
    Private Sub updateoperation()

        Call calc()


        Dim sql As String
        Dim insert(0) As String

        sqlstring = "select isnull(taxgroupcode,'') as taxgroupcode,isnull(Effectfrom,GETDATE()) as Effectfrom from invtaxgroupmaster where taxgroupcode='" & Trim(txt_taxgroup.Text) & "' and cast( isnull(Effectfrom,GETDATE()) as date)>=cast('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' as date)"
        gconnection.getDataSet(sqlstring, "inv1")
        If gdataset.Tables("inv1").Rows.Count > 0 Then
            MessageBox.Show(" Effect Date should be greater than last Effect Date :" + Trim(gdataset.Tables("inv1").Rows(0).Item("Effectfrom")), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txttaxper.Focus()
            Exit Sub
        End If

        sqlstring = "update invtaxgroupmaster set taxper='" + txttaxper.Text + "',void='N',updateuser='" + gUsername + "',updatedate=getdate(),Effectfrom='" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' where taxgroupcode='" + txt_taxgroup.Text + "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring
        sql = "update invtaxgroupmasterdetail set Effectto= dateadd(day, -1,CAST('" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "' AS dATE))  where taxgroupcode='" + txt_taxgroup.Text + "' and Effectto is null "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sql
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
         
            sql = "Insert into invtaxgroupmasterdetail (taxgroupcode,tax,taxon,taxper,adduser,adddate,Effectfrom)"
            sql = sql & " values ('" + txt_taxgroup.Text + "',"
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            sql = sql & "  '" + AxfpSpread1.Text + "',"
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 2
            sql = sql & "  '" + AxfpSpread1.Text + "',"
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 3

            sql = sql & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
            sql = sql & " '" + gUsername + "' ,getdate(),'" & Format(CDate(dtp_effectdate.Value), "yyyy/MM/dd") & "')"

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sql


            '  End If

        Next

        gconnection.MoreTrans(insert)
        clearoperation()
    End Sub

    Private Sub voidoperation()
        Dim sql As String
        Dim insert(0) As String
        sqlstring = "update invtaxgroupmaster set void='Y',updateuser='" + gUsername + "',voiddate=getdate() where taxgroupcode='" + txt_taxgroup.Text + "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring

       
        sql = "update invtaxgroupmasterdetail set void='Y',voiduser='" + gUsername + "',voiddate=getdate() "
        sql = sql & " where taxgroupcode='" + txt_taxgroup.Text + "'"

                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sql
        gconnection.MoreTrans(insert)

    End Sub

    Private Sub Filltax(ByVal i As Integer)
        Try
            Dim Z As Integer
            Dim sqlstring As String
            Dim taxcode As String
            Dim sqls As String = ""
            sqlstring = "SELECT ISNULL(taxcode,'') AS taxcode FROM accountstaxmaster WHERE "
            If i > 1 Then
                sqlstring = sqlstring & " taxcode not in ( "
                For Z = 1 To i - 1
                    AxfpSpread1.Col = 1
                    AxfpSpread1.Row = Z
                    AxfpSpread1.Lock = True
                    taxcode = AxfpSpread1.Text
                    sqlstring = sqlstring & "'" & taxcode & "',"
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 1)
                sqlstring = sqlstring & ") and "
            End If
            sqlstring = sqlstring & " isnull(FREEZEFLAG,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "accountstaxmaster")
            If gdataset.Tables("accountstaxmaster").Rows.Count > 0 Then
                AxfpSpread1.Col = 1
                AxfpSpread1.Row = i
                AxfpSpread1.TypeComboBoxString = ""

                AxfpSpread1.TypeComboBoxClear(1, i)
                For Z = 0 To gdataset.Tables("accountstaxmaster").Rows.Count - 1

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("accountstaxmaster").Rows(Z).Item("taxcode"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("accountstaxmaster").Rows(Z).Item("taxcode"))
                Next Z
                AxfpSpread1.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    
    Private Function basestr(ByVal mindex) As String
        Dim basestr1 As String = ""
        For i As Integer = 0 To mindex - 1
            If basestr1 = "" Then
                basestr1 = i.ToString()
            Else
                basestr1 = basestr1 + i.ToString()
            End If
        Next
        Return basestr1
    End Function

    Private Function combination(ByVal basestr1 As String, ByVal ti As Integer)

        Dim sindex As Integer = basestr1.IndexOf("0")
        Dim lindex As Integer = basestr1.Length - 1
        Dim cindex As Integer = lindex - 1
        Dim charArray As Char() = basestr1.ToCharArray()
        Dim posindex As Integer
        If basestr1.Length = 1 Then
            For j As Integer = sindex To ti - 1
                basestr1 = j.ToString()
                taxlist2.Add(basestr1)
            Next
        ElseIf (basestr1.Length = 2) Then
            For m As Integer = sindex To ti - 2
                If (m = 0) Then
                    lindex = m + 1
                    basestr1 = m.ToString() + basestr1.Substring(1, basestr1.Length - 1)

                Else
                    lindex = m + 1
                    basestr1 = m.ToString() + basestr1.Substring(1, basestr1.Length - 1)

                End If
                For p As Integer = lindex To ti - 1
                    basestr1 = basestr1.Substring(0, 1) + p.ToString()
                    taxlist2.Add(basestr1)

                Next
            Next
        Else
           
line1:
            Dim pap As New String(charArray)
            taxlist2.Add(pap)
            '    taxlist2.Add(pap)


            posindex = lindex
            Dim tarun As Integer = Conversion.Int(charArray(posindex).ToString())
            For k As Integer = Conversion.Int(charArray(posindex).ToString()) To ti - 1
                Dim temp As Int16 = Conversion.Int(charArray(posindex).ToString())
                Dim temp1 As Int16 = temp + 1


                If (Conversion.Int(charArray(posindex).ToString()) = ti - 1) Then
                    If (temp1 >= ti - 1) Then

                        Dim p As Integer = lindex
                        While p >= 0
                            If (Conversion.Int(charArray(p).ToString()) = ti - basestr1.Length + p) Then
                                If (p = 1) Then
                                    p = 0
                                ElseIf (p = 0) Then

                                    GoTo line2
                                Else
                                    p = p - 1

                                End If
                            Else
                                Dim temp2 As Int16 = Conversion.Int(charArray(p).ToString())
                                Dim temp3 As Int16 = temp2 + 1
                                charArray.SetValue(Convert.ToChar(temp3.ToString()), p)

                                Exit While
                            End If

                        End While
                        For m As Integer = p + 1 To lindex
                            Dim temp2 As Int16 = Conversion.Int(charArray(m - 1).ToString())
                            Dim temp3 As Int16 = temp2 + 1
                            charArray.SetValue(Convert.ToChar(temp3.ToString()), m)
                            If (m = lindex) Then
                                ' ListBox1.Items.Add(charArray)
                                GoTo line1

                            End If
                        Next

                    End If

                Else
                    charArray.SetValue(Convert.ToChar(temp1.ToString()), posindex)
                    Dim pap1 As New String(charArray)
                    taxlist2.Add(pap1)

                End If
            Next
line2:

         
        End If




    End Function

    'Private Sub fillcombination()
    '    For Each item In taxlist2.
    'Dim charArray As Char() = item.ToCharArray()
    '        Dim temp As String
    '        For i = 0 To charArray.Length - 1
    '            If (i = 0) Then
    '                temp = taxlist.Item(Conversion.Int(charArray(i).ToString()))
    '            Else
    '                temp = temp + "+" + taxlist.Item(Conversion.Int(charArray(i).ToString()))

    '            End If
    '        Next


    '        ListBox2.Items.Add(temp)
    '    Next
    'End Sub

    Private Sub cmdStoreCode_Click(sender As Object, e As EventArgs) Handles cmdtaxgroupCode.Click
        gSQLString = "SELECT distinct ISNULL(taxgroupcode,'') AS taxgroupcode,taxper  FROM invtaxgroupmaster"
        M_WhereCondition = " WHERE  void<>'Y'"
        Dim vform As New ListOperattion1
        vform.Field = "taxgroupcode"
        vform.vFormatstring = "         TaxGroup CODE              |                  TaxPer       "
        vform.vCaption = "Tax MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_taxgroup.Text = Trim(vform.keyfield & "")
            Call txt_taxgroup_Validated(txt_taxgroup, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

  
    Private Sub bindcomination(i As Integer)

        taxlist.Clear()

        If i = 1 Then
            taxlist.Add("Base Amount")
        Else
            taxlist.Add("Base Amount")

            For Z As Integer = 1 To i - 1
                AxfpSpread1.Col = 1
                AxfpSpread1.Row = Z
                AxfpSpread1.Lock = True
                taxlist.Add(AxfpSpread1.Text)

            Next
        End If
        taxlist2.Clear()
        For m As Integer = 1 To taxlist.Count

            combination(basestr(m), taxlist.Count)

        Next
        AxfpSpread1.TypeComboBoxClear(2, i)
        For Each str As String In taxlist2
            Dim charArray As Char() = str.ToCharArray()
            Dim temp As String
            For l As Integer = 0 To charArray.Length - 1
                If (l = 0) Then
                    temp = taxlist.Item(Conversion.Int(charArray(l).ToString()))
                Else
                    temp = temp + "+" + taxlist.Item(Conversion.Int(charArray(l).ToString()))

                End If
            Next
            AxfpSpread1.Col = 2
            AxfpSpread1.Row = i
            AxfpSpread1.TypeComboBoxString = temp
            AxfpSpread1.Text = temp

        Next

    End Sub
    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer

        If e.keyCode = Keys.Enter Then

            i = AxfpSpread1.ActiveRow
            AxfpSpread1.Row = i
            If (AxfpSpread1.ActiveCol = 1) Then
                AxfpSpread1.Col = 1
                If (AxfpSpread1.Text = "") Then
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                Else
                    bindcomination(i)
                    AxfpSpread1.SetActiveCell(2, AxfpSpread1.ActiveRow)
                    AxfpSpread1.Focus()
                End If
            ElseIf (AxfpSpread1.ActiveCol = 2) Then
                AxfpSpread1.Col = 2

                If (AxfpSpread1.Text = "") Then
                    AxfpSpread1.SetActiveCell(2, AxfpSpread1.ActiveRow)
                Else
                    Dim temp(0) As String
                    AxfpSpread1.Col = 2
                    If AxfpSpread1.Text.Contains("+") Then
                        temp = AxfpSpread1.Text.Split("+")
                    Else
                        temp(0) = AxfpSpread1.Text

                    End If

                    Dim tot As Double = 0
                    Dim tot1 As Double
                    For K As Integer = 0 To temp.Length - 1
                        Dim taxcode As String

                        If temp(K) = "Base Amount" Then

                            tot = 100

                        Else
                            For m As Integer = 1 To AxfpSpread1.DataRowCnt
                                If (temp(K) <> "") Then
                                    AxfpSpread1.Row = m
                                    AxfpSpread1.Col = 1
                                    If (AxfpSpread1.Text) = temp(K) Then
                                        AxfpSpread1.Col = 3

                                        tot = tot + Val(AxfpSpread1.Text)
                                    End If
                                End If
                            Next

                        End If

                    Next
                    AxfpSpread1.Col = 1
                    AxfpSpread1.Row = i
                    Dim taxper1 As Double
                    Dim sql1 As String = "select isnull(taxpercentage,0) as taxper from accountstaxmaster where taxcode='" + AxfpSpread1.Text + "'"
                    taxper1 = gconnection.getvalue(sql1)
                    tot = tot * taxper1 / 100
                    AxfpSpread1.Col = 3
                    AxfpSpread1.Text = Val(tot)
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    Filltax(AxfpSpread1.ActiveRow)
                    calc()
                End If
            ElseIf (AxfpSpread1.ActiveCol = 3) Then
                AxfpSpread1.Col = 3

                If (AxfpSpread1.Text = "") Then
                    AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    Filltax(AxfpSpread1.ActiveRow)
                End If

            End If
        ElseIf e.keyCode = Keys.F3 Then
            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
            Filltax(AxfpSpread1.ActiveRow)

        End If
    End Sub


    Private Sub AxfpSpread1_LeaveCell(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread1.LeaveCell
        Dim row As Integer
        row = AxfpSpread1.ActiveRow
        AxfpSpread1.Row = row

        If AxfpSpread1.ActiveCol = 2 Then
            Dim temp(0) As String
            AxfpSpread1.Col = 2
            If AxfpSpread1.Text.Contains("+") Then
                temp = AxfpSpread1.Text.Split("+")
            Else
                temp(0) = AxfpSpread1.Text

            End If

            Dim tot As Double = 0
            Dim tot1 As Double
            For i As Integer = 0 To temp.Length - 1
                Dim taxcode As String

                If temp(i) = "Base Amount" Then

                    tot = 100

                Else
                    For m As Integer = 1 To AxfpSpread1.DataRowCnt
                        If (temp(i) <> "") Then
                            AxfpSpread1.Row = m
                            AxfpSpread1.Col = 1
                            If (AxfpSpread1.Text) = temp(i) Then
                                AxfpSpread1.Col = 3

                                tot = tot + Val(AxfpSpread1.Text)
                            End If
                        End If
                    Next

                End If

            Next
            AxfpSpread1.Col = 1
            AxfpSpread1.Row = row
            Dim taxper1 As Double
            Dim sql1 As String = "select isnull(taxpercentage,0) as taxper from accountstaxmaster where taxcode='" + AxfpSpread1.Text + "'"
            taxper1 = gconnection.getvalue(sql1)
            tot = tot * taxper1 / 100
            AxfpSpread1.Col = 3
            AxfpSpread1.Text = Val(tot)
            calc()
        ElseIf (AxfpSpread1.ActiveCol = 3) Then
            AxfpSpread1.Col = 3

            If (AxfpSpread1.Text = "") Then
                AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow)
            Else
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                Filltax(AxfpSpread1.ActiveRow)
            End If
        ElseIf (AxfpSpread1.ActiveCol = 1) Then
            AxfpSpread1.Col = 1
            If (AxfpSpread1.Text = "") Then
                ' AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
            Else
                bindcomination(row)
                AxfpSpread1.SetActiveCell(2, AxfpSpread1.ActiveRow)
                AxfpSpread1.Focus()
            End If

        End If
    End Sub
    Private Sub calc()
        Dim tot As Double = 0
        For m As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 3
            AxfpSpread1.Row = m
            tot = tot + Val(AxfpSpread1.Text)

        Next
        txttaxper.Text = Math.Round(tot, 2).ToString()
    End Sub
    Private Sub clearoperation()
        txttaxper.Text = ""
        Cmd_Add.Text = "Add[F7]"
        txt_taxgroup.Text = ""
        lbl_Freeze.Visible = False
        Dim Z As Integer

        For Z = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 1
            AxfpSpread1.Row = Z
            AxfpSpread1.Lock = False

        Next
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)

    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        If (Cmd_Add.Text = "Add[F7]") Then
            addoperatin()
            clearoperation()
        ElseIf (Cmd_Add.Text = "Update[F7]") Then

            updateoperation()

        End If
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub txt_taxgroup_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_taxgroup.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (txt_taxgroup.Text <> "") Then
                txt_taxgroup_Validated(sender, e)
               
            End If

        End If
    End Sub

    Private Sub txt_taxgroup_Validated(sender As Object, e As EventArgs) Handles txt_taxgroup.Validated


        Dim Z As Integer

        For Z = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 1
            AxfpSpread1.Row = Z
            AxfpSpread1.Lock = False

        Next
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)

        Dim sqlstring = " select isnull(Effectfrom,case when updatedate is null then adddate else updatedate end ) as Effectfrom,* from invtaxgroupmaster where taxgroupcode='" + txt_taxgroup.Text + "'"
        gconnection.getDataSet(sqlstring, "invtaxgroupmaster")
        If (gdataset.Tables("invtaxgroupmaster").Rows.Count > 0) Then
            txttaxper.Text = Val(gdataset.Tables("invtaxgroupmaster").Rows(0).Item("Taxper"))
            If gdataset.Tables("invtaxgroupmaster").Rows(0).Item("void") = "Y" Then

                lbl_Freeze.Text = "Recode void on " + gdataset.Tables("invtaxgroupmaster").Rows(0).Item("voiddate")
                Cmd_Add.Enabled = False
                Cmd_Freeze.Enabled = False
                lbl_Freeze.Visible = True
            Else
                Cmd_Add.Enabled = True
                Cmd_Freeze.Enabled = True
                lbl_Freeze.Visible = False
                Label3.Visible = True
                dtp_effectdate.Visible = True
            End If

            dtp_effectdate.Value = gdataset.Tables("invtaxgroupmaster").Rows(0).Item("Effectfrom")


            Dim sql As String = "select * from invtaxgroupmasterdetail where taxgroupcode='" + txt_taxgroup.Text + "' and effectto is null"
            gconnection.getDataSet(sql, "invtaxgroupmasterdetail")
            If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then
                'AxfpSpread1_GotFocus(sender, e)
                For i As Integer = 0 To gdataset.Tables("invtaxgroupmasterdetail").Rows.Count - 1
                    AxfpSpread1.Row = i + 1
                    Filltax(i + 1)
                    ''  AxfpSpread1.SetText(1, i + 1, gdataset.Tables("invtaxgroupmasterdetail").Rows(i).Item("Tax"))
                    'AxfpSpread1.Col = 1
                    'AxfpSpread1.Text = gdataset.Tables("invtaxgroupmasterdetail").Rows(i).Item("Tax")
                    ''AxfpSpread1_LeaveCell(sender, e
                    '' bindcomination(i + 1)
                    'AxfpSpread1.SetText(2, i + 1, gdataset.Tables("invtaxgroupmasterdetail").Rows(i).Item("Taxon"))
                    'AxfpSpread1.SetText(3, i + 1, Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(i).Item("Taxper")))

                    AxfpSpread1.Col = 1
                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(i).Item("Tax"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(i).Item("Tax"))
                    bindcomination(i + 1)
                    AxfpSpread1.Col = 2
                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(i).Item("Taxon"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(i).Item("Taxon"))

                    AxfpSpread1.Col = 3
                    ' AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(i).Item("Tax"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(i).Item("Taxper"))


                Next
                Cmd_Add.Text = "Update[F7]"
            End If
        Else


            Filltax(1)
            AxfpSpread1.SetActiveCell(1, 1)
            AxfpSpread1.Focus()
        End If

    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click

        Call voidoperation()
        clearoperation()
    End Sub

    Private Sub AxfpSpread1_Advance(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread1.Advance

    End Sub
End Class