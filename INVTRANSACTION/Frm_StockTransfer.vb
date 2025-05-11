Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Public Class Frm_StockTransfer
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim doctype1, Status As String
    Dim docno(0) As String
    Dim doctype As String
    Dim slcode, sldesc, costcode, costdesc, decription, accode, acdesc As String
    Dim tdate As DateTime


    Private Sub Frm_StockTransfer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub

            ElseIf e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 And Cmd_View.Visible = True Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F10 And cmd_Print.Visible = True Then
                Call cmd_Print_Click(cmd_Print, e)
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
    Private Sub Frm_StockTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Resize_Form()
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If

        'Me.DoubleBuffered = True
        doctype = "TRF"
        Dim sqlstring As String = "Select getdate()"
        tdate = gconnection.getvalue(sqlstring)

        If gUserCategory <> "S" Then
            Call GetRights()
        End If


        Me.Cursor = Cursors.WaitCursor
        Call Check()
        Me.Cursor = Cursors.Default

        If GSHELVING <> "Y" Then
            AxfpSpread1.Col = 10
            AxfpSpread1.ColHidden = True
            AxfpSpread1.Col = 11
            AxfpSpread1.ColHidden = True
        End If
        Label3.Visible = False
        TXT_PARTYNO.Visible = False
        Button1.Visible = False
        Label11.Visible = False
        txt_buffet.Visible = False
        cmd_buffet.Visible = False



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
                        If Controls(i_i).Name = "frmbut" Then
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
                        ElseIf Controls(i_i).Name = "GroupBox3" Then
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

        GmoduleName = "Stock Transfer/Return"

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


    Private Sub cmd_fromStorecodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_fromStorecodeHelp.Click


        gSQLString = "SELECT DISTINCT storecode,ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER"
        If UCase(gShortname) = "MGC" Or UCase(gShortname) = "CCL" Or UCase(gShortname) = "RCL" Then
            M_WhereCondition = " WHERE  ISNULL(STORESTATUS,'') in ('S','M') AND ISNULL(FREEZE,'') <> 'Y'"
        Else
            M_WhereCondition = " WHERE  ISNULL(STORESTATUS,'') = 'S' AND ISNULL(FREEZE,'') <> 'Y'"
        End If

        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_FROMSTORECODE.Text = Trim(vform.keyfield & "")
            txt_FromStorename.Text = Trim(vform.keyfield1 & "")
            Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
        Else
            Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
        End If
        ' ADDED BY SRI FOR FROM SHELF
        If GSHELVING = "Y" Then
            sqlstring = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster WHERE  STORECODE='" + TXT_FROMSTORECODE.Text + "' And ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "FROMSHELF")
            If gdataset.Tables("FROMSHELF").Rows.Count > 0 Then
                AxfpSpread1.Col = 10
                AxfpSpread1.ColHidden = False
            Else
                AxfpSpread1.Col = 10
                AxfpSpread1.ColHidden = True
            End If
            ' END
        End If

        sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE BUFFET='YES' AND STORECODE='" & txt_storecode.Text & "'"
        gconnection.getDataSet(sqlstring, "BUFFET")
        If gdataset.Tables("BUFFET").Rows.Count > 0 Then
            Label11.Visible = True
            txt_buffet.Visible = True
            cmd_buffet.Visible = True
            '  cmd_buffet_Click(sender, e)
        Else
            Label11.Visible = False
            txt_buffet.Visible = False
            cmd_buffet.Visible = False
        End If

        sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE Banquet='YES' AND STORECODE='" & txt_storecode.Text & "'"
        gconnection.getDataSet(sqlstring, "Banquet")
        If gdataset.Tables("Banquet").Rows.Count > 0 Then
            Label3.Visible = True
            TXT_PARTYNO.Visible = True
            Button1.Visible = True
            '  Button1_Click(sender, e)
        Else
            Label3.Visible = False
            TXT_PARTYNO.Visible = False
            Button1.Visible = False
        End If


        vform.Close()
        vform = Nothing
    End Sub

    Private Sub TXT_FROMSTORECODE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_FROMSTORECODE.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (TXT_FROMSTORECODE.Text <> "") Then
                TXT_FROMSTORECODE_Validated(sender, e)
            Else
                cmd_fromStorecodeHelp_Click(sender, e)
            End If
        End If
    End Sub



    Private Sub TXT_FROMSTORECODE_Validated(sender As Object, e As EventArgs) Handles TXT_FROMSTORECODE.Validated
        If Trim(TXT_FROMSTORECODE.Text) <> "" Then

            If UCase(gShortname) = "MGC" Or UCase(gShortname) = "CCL" Or UCase(gShortname) = "RCL" Then
                sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' and STORESTATUS in ('M','S') ORDER BY STOREDESC ASC"
            Else
                sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' and STORESTATUS<>'M' ORDER BY STOREDESC ASC"
            End If
            gconnection.getDataSet(sqlstring, "STOREMASTER1")
            If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                doctype1 = ""
                Status = Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS"))
                If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" And Status = "S" Then
                    doctype1 = "RET"
                    lbl_Heading.Text = "STOCK RETURN"
                Else
                    doctype1 = "TRF"
                    lbl_Heading.Text = "STOCK TRANSFER"
                End If
            End If
            If UCase(gShortname) = "MGC" Or UCase(gShortname) = "CCL" Or UCase(gShortname) = "RCL" Then
                sqlstring = "SELECT * FROM STOREMASTER WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' and STORESTATUS in ('M','S')"
            Else
                sqlstring = "SELECT * FROM STOREMASTER WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' and STORESTATUS <>'M'"
            End If

            gconnection.getDataSet(sqlstring, "storemaster")
            If gdataset.Tables("storemaster").Rows.Count > 0 Then
                TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                txt_FromStorename.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                txt_storecode.Focus()
                autogenerate()
            Else
                TXT_FROMSTORECODE.Text = ""
                TXT_FROMSTORECODE.Focus()
            End If
            ' ADDED BY SRI FOR FROM SHELF
            If GSHELVING = "Y" Then
                sqlstring = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster WHERE  STORECODE='" + TXT_FROMSTORECODE.Text + "' And ISNULL(FREEZE,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "FROMSHELF")
                If gdataset.Tables("FROMSHELF").Rows.Count > 0 Then
                    AxfpSpread1.Col = 10
                    AxfpSpread1.ColHidden = False
                Else
                    AxfpSpread1.Col = 10
                    AxfpSpread1.ColHidden = True
                End If
                ' END
            End If


        End If
    End Sub
    Private Sub autogenerate()
        Dim Sqlstring, Financalyear, storecode As String

        If Trim(TXT_FROMSTORECODE.Text) <> "" And Mid(Cmd_Add.Text, 1, 1) = "A" Then
            Try
                Dim LEN As Integer
                storecode = Mid(TXT_FROMSTORECODE.Text, 1, 3)
                LEN = storecode.Length
                Financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
                Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) FROM STOCKTRANSFERHEADER WHERE SUBSTRING(docDETAILS,1,3)='" & Trim(doctype1) & "' and SUBSTRING(docDETAILS,5," & LEN & ")='" & Trim(storecode) & "' "
                gconnection.openConnection()
                gcommand = New SqlCommand(Sqlstring, gconnection.Myconn)
                gdreader = gcommand.ExecuteReader
                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        txt_Docno.Text = doctype1 & "/" & storecode & "/000001/" & Financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        txt_Docno.Text = doctype1 & "/" & storecode & "/" & Format(gdreader(0) + 1, "000000") & "/" & Financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    txt_Docno.Text = doctype1 & "/" & storecode & "/" & "/000001/" & Financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If


            Catch ex As Exception
                Exit Sub
            Finally
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End Try
        End If
    End Sub

    Private Sub cmd_storecode_Click(sender As Object, e As EventArgs) Handles cmd_storecode.Click
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM STOREMASTER "
        M_WhereCondition = " where freeze <> 'Y' and storecode<>'" + TXT_FROMSTORECODE.Text + "' "
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "

        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_storecode.Text = Trim(vform.keyfield & "")
            txt_storeDesc.Text = Trim(vform.keyfield1 & "")

            If txt_storecode.Text = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
                sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(txt_storecode.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    doctype1 = ""
                    If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" And Status = "S" Then
                        doctype1 = "RET"
                        lbl_Heading.Text = "STOCK RETURN"
                    Else
                        doctype1 = "TRF"
                        lbl_Heading.Text = "STOCK TRANSFER"
                    End If
                    Call autogenerate()
                End If
                ' ADDED BY SRI FOR  To SHELF
                If GSHELVING = "Y" Then
                    sqlstring = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster  WHERE STORECODE='" + txt_storecode.Text + "' And ISNULL(FREEZE,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "TOSHELF")
                    If gdataset.Tables("TOSHELF").Rows.Count > 0 Then
                        AxfpSpread1.Col = 11
                        AxfpSpread1.ColHidden = False
                    Else
                        AxfpSpread1.Col = 11
                        AxfpSpread1.ColHidden = True
                    End If
                    ' END
                End If


            Else
                sqlstring = " SELECT DISTINCT(storecode),storedesc FROM STOREMASTER"
                sqlstring = sqlstring & " WHERE STORECODE = '" & txt_storecode.Text & "'"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    txt_storeDesc.Text = gdataset.Tables("STOREMASTER1").Rows(0).Item("STOREDESC")

                End If
                sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(txt_storecode.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    doctype1 = ""
                    If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" And Status = "S" Then
                        doctype1 = "RET"
                        lbl_Heading.Text = "STOCK RETURN"
                    Else
                        doctype1 = "TRF"
                        lbl_Heading.Text = "STOCK TRANSFER"
                    End If
                    Call autogenerate()
                End If
                ' ADDED BY SRI FOR  To SHELF
                If GSHELVING = "Y" Then
                    sqlstring = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster WHERE  STORECODE='" + txt_storecode.Text + "' And ISNULL(FREEZE,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "TOSHELF")
                    If gdataset.Tables("TOSHELF").Rows.Count > 0 Then
                        AxfpSpread1.Col = 11
                        AxfpSpread1.ColHidden = False
                    Else
                        AxfpSpread1.Col = 11
                        AxfpSpread1.ColHidden = True
                    End If
                    ' END
                End If

            End If

        End If

        sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE BUFFET='YES' AND STORECODE='" & txt_storecode.Text & "'"
        gconnection.getDataSet(sqlstring, "BUFFET")
        If gdataset.Tables("BUFFET").Rows.Count > 0 Then
            Label11.Visible = True
            txt_buffet.Visible = True
            cmd_buffet.Visible = True
            '  cmd_buffet_Click(sender, e)
        Else
            Label11.Visible = False
            txt_buffet.Visible = False
            cmd_buffet.Visible = False
        End If

        sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE Banquet='YES' AND STORECODE='" & txt_storecode.Text & "'"
        gconnection.getDataSet(sqlstring, "Banquet")
        If gdataset.Tables("Banquet").Rows.Count > 0 Then
            Label3.Visible = True
            TXT_PARTYNO.Visible = True
            Button1.Visible = True
            '  Button1_Click(sender, e)
        Else
            Label3.Visible = False
            TXT_PARTYNO.Visible = False
            Button1.Visible = False
        End If

        vform.Close()
        vform = Nothing
    End Sub
    Private Sub binditemcode()
        Dim vform As New ListOperattion1
        Dim convvalue As Double
        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess, M.Category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_storecode.Text + "'"
        vform.Field = " I.itemcode, M.Itemname,uom"
        vform.vFormatstring = "    Itemcode    |                       Itemname                      |      UOM      |     batchprocess  |       Category   "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
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
                Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"
                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                Next Z
                'Dim a As String=
                If Trim(vform.keyfield3) = "YES1" Then
                    AxfpSpread1.Col = 5
                    AxfpSpread1.ColHidden = False
                    Dim SQL1 As String = "with a as ( "
                    SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE TRNDATE<'" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                    SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                    SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_Ratelist.batchrate as rate,closingqty.uom as uom from a inner  join closingqty on "
                    SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                    SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                    SQL1 = SQL1 & " inner  join Vw_Ratelist on a.batchno=Vw_Ratelist.batchno"
                    SQL1 = SQL1 & " and a.itemcode=Vw_Ratelist.itemcode and  a.storecode=closingqty.storecode and a.storecode=vw_ratelist.storecode "
                    SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(vform.keyfield) + "'"
                    SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND A.TRNDATE<'" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate "
                    gconnection.getDataSet(SQL1, "closingtable")
                    If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                        AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                        GroupBox4.Visible = True
                        For i As Integer = 0 To gdataset.Tables("closingtable").Rows.Count - 1
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 1
                            AxfpSpread2.SetText(1, i + 1, Trim(vform.keyfield))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 2
                            AxfpSpread2.SetText(2, i + 1, gdataset.Tables("closingtable").Rows(i).Item("batchno"))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 3
                            AxfpSpread2.SetText(3, i + 1, Val(gdataset.Tables("closingtable").Rows(i).Item("quantity")))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 4
                            AxfpSpread2.SetText(4, i + 1, gdataset.Tables("closingtable").Rows(i).Item("uom"))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 5
                            AxfpSpread2.SetText(5, i + 1, Val(gdataset.Tables("closingtable").Rows(i).Item("rate")))
                        Next

                        Me.Focus()
                        AxfpSpread2.Focus()
                        AxfpSpread2.SetActiveCell(6, AxfpSpread2.ActiveRow)
                    Else
                        AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                        AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                    End If

                Else
                    'sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                    'gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                    'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                    '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                    '    Dim sql1 As String
                    '    'If rateflag = "W" Then
                    '    '    sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                    '    '    sql1 = sql1 & " and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                    '    'Else
                    '    '    sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                    '    '    sql1 = sql1 & " and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                    '    'End If

                    '    If rateflag = "W" Then

                    '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + vform.keyfield + "'  and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate  and storecode='" + TXT_FROMSTORECODE.Text + "'  and qty<>0 and closingstock<>0 order by Trndate desc "
                    '    Else
                    '        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + vform.keyfield + "'  and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
                    '    End If
                    '    gconnection.getDataSet(sql1, "ratelist")
                    '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then

                    '        Dim pr As Double

                    '        AxfpSpread1.Col = 3
                    '        sql1 = "select isnull(convvalue,0) as convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                    '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                    '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                    '        Else
                    '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                    '            Exit Sub
                    '        End If
                    '        AxfpSpread1.Col = 7
                    '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue))
                    '    Else
                    '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + vform.keyfield + "' and storecode='" + TXT_FROMSTORECODE.Text + "' AND  openningqty<>0 "
                    '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                    '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then


                    '            Dim pr As Double

                    '            AxfpSpread1.Col = 3
                    '            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                    '            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                    '            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    '                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    '                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                    '            Else
                    '                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                    '                Exit Sub
                    '            End If
                    '            AxfpSpread1.Col = 7
                    '            AxfpSpread1.Row = AxfpSpread1.ActiveRow


                    '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)


                    '        Else
                    '            AxfpSpread1.Col = 7
                    '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '            AxfpSpread1.Text = 0

                    '        End If
                    '    End If



                    'End If
                    If GBATCHNO = "Y" Then
                        AxfpSpread1.Col = 5
                        AxfpSpread1.ColHidden = False
                    Else
                        AxfpSpread1.Col = 5
                        AxfpSpread1.ColHidden = True

                    End If

                    AxfpSpread1.Col = 3

                    Dim uom As String = AxfpSpread1.Text
                    Dim uom1 As String
                    Dim itemcode As String
                    AxfpSpread1.Col = 1
                    itemcode = AxfpSpread1.Text
                    Dim sql11 As String
                    '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                    '  Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                    'gconnection.getDataSet(sql11, "closingtable")
                    gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                    Dim closingqty, Rate As Double
                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                        uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                        Rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                    Else
                        closingqty = 0
                        uom1 = uom
                        Rate = 0
                    End If

                    sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                    gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")

                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                    Else
                        convvalue = 1
                    End If
                    closingqty = Format(closingqty * convvalue, "0.000")

                    AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))

                    AxfpSpread1.SetText(3, AxfpSpread1.ActiveRow, uom1)

                    AxfpSpread1.Col = 7
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(Rate * (convvalue))
                    ' Added by Sri for Batch No & Shelving
                    '  batchnocheck()
                    FROMShelfcheck()
                    ToShelfcheck()
                    ' BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
                    'If BATCH_REQ = "YES" Then
                    '    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    If GSHELVING = "Y" Then
                        If (gdataset.Tables("FROMShelfcheck").Rows.Count > 0) Then
                            AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                        ElseIf (gdataset.Tables("ToShelfcheck").Rows.Count > 0) Then
                            AxfpSpread1.SetActiveCell(11, AxfpSpread1.ActiveRow)
                        End If
                    Else
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    End If
                    ' end
                End If
            Else
            End If
        End If
    End Sub
    Private Sub batchnocheck()
        If GBATCHNO = "Y" Then
            Dim ITEMCODE As String
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                ITEMCODE = AxfpSpread1.Text
                AxfpSpread1.Col = 5
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(BATCHNO,'') AS BATCHNO FROM INV_InventoryItemMaster WHERE ITEMCODE='" & ITEMCODE & "' AND  ISNULL(VOID,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "BATCHREQ")
                    Dim BATCH_REQ As String
                    BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
                End If
            Next
        End If
    End Sub
    Private Sub FROMShelfcheck()
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = TXT_FROMSTORECODE.Text
            AxfpSpread1.Col = 10
            If AxfpSpread1.Text = "" Then
                'AxfpSpread1.Col = 22
                Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                gconnection.getDataSet(sqlstring, "FROMShelfcheck")
            End If
        End If
    End Sub
    Private Sub ToShelfcheck()
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = txt_storecode.Text
            AxfpSpread1.Col = 11
            If AxfpSpread1.Text = "" Then
                'AxfpSpread1.Col = 22
                Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                gconnection.getDataSet(sqlstring, "ToShelfcheck")
            End If
        End If
    End Sub
    Private Sub binditemname()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim myValue As Object
        Dim convvalue As Double
        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess,M.category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_storecode.Text + "'"
        vform.Field = " I.itemcode, M.Itemname,I.Uom,batchprocess"
        vform.vFormatstring = "    Itemcode    |                         Itemname                      |       UOM      |     batchprocess  |     Category   "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
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
                Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                Next Z

                If Trim(vform.keyfield3) = "YES1" Then
                    AxfpSpread1.Col = 5
                    AxfpSpread1.ColHidden = False

                    GroupBox4.Visible = True
                    '  Dim sql As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                    'Dim sql As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                    'sql = sql & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                    Dim SQL1 As String = "with a as ( "
                    SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE TRNDATE<'" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "'"
                    SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                    SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_Ratelist.batchrate as rate,closingqty.uom as uom from a inner  join closingqty on "
                    SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                    SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                    SQL1 = SQL1 & " inner  join Vw_Ratelist on a.batchno=Vw_Ratelist.batchno"
                    SQL1 = SQL1 & " and a.itemcode=Vw_Ratelist.itemcode and  a.storecode=closingqty.storecode and a.storecode=vw_ratelist.storecode "
                    SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(vform.keyfield) + "'"
                    SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND A.TRNDATE<'" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate "

                    gconnection.getDataSet(SQL1, "closingtable")
                    If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                        AxfpSpread2.ClearRange(1, 1, -1, -1, True)

                        For i As Integer = 0 To gdataset.Tables("closingtable").Rows.Count
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 1
                            AxfpSpread2.SetText(1, i + 1, Trim(vform.keyfield))

                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 2
                            AxfpSpread2.SetText(2, i + 1, gdataset.Tables("closingtable").Rows(i).Item("batchno"))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 3
                            AxfpSpread2.SetText(3, i + 1, Val(gdataset.Tables("closingtable").Rows(i).Item("quantity")))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 4
                            AxfpSpread2.SetText(4, i + 1, gdataset.Tables("closingtable").Rows(i).Item("uom"))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 5
                            AxfpSpread2.SetText(5, i + 1, Val(gdataset.Tables("closingtable").Rows(i).Item("rate")))



                        Next
                        AxfpSpread2.Focus()
                        AxfpSpread2.SetActiveCell(6, 1)
                    Else
                        AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                        AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                        GroupBox4.Visible = False
                    End If

                Else
                    'sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                    'gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                    'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                    '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                    '    Dim sql1 As String
                    '    'If rateflag = "W" Then
                    '    '    sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                    '    '    sql1 = sql1 & " and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                    '    'Else
                    '    '    sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                    '    '    sql1 = sql1 & " and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                    '    'End If
                    '    If rateflag = "W" Then

                    '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + vform.keyfield + "'  and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate  and storecode='" + TXT_FROMSTORECODE.Text + "'  and qty<>0 and closingstock<>0 order by Trndate desc "
                    '    Else
                    '        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + vform.keyfield + "'  and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
                    '    End If
                    '    gconnection.getDataSet(sql1, "ratelist")
                    '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then

                    '        Dim pr As Double

                    '        AxfpSpread1.Col = 3
                    '        sql1 = "select isnull(convvalue,0) as convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                    '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                    '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                    '        Else
                    '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                    '            Exit Sub
                    '        End If
                    '        AxfpSpread1.Col = 7
                    '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue))
                    '    Else
                    '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + vform.keyfield + "'  AND  openningqty<>0 "
                    '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                    '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then


                    '            Dim pr As Double

                    '            AxfpSpread1.Col = 3
                    '            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                    '            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                    '            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    '                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    '                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                    '            Else
                    '                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                    '                Exit Sub
                    '            End If
                    '            AxfpSpread1.Col = 7
                    '            AxfpSpread1.Row = AxfpSpread1.ActiveRow


                    '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)


                    '        Else
                    '            AxfpSpread1.Col = 7
                    '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '            AxfpSpread1.Text = 0

                    '        End If
                    '    End If



                    'End If


                    AxfpSpread1.Col = 5
                    AxfpSpread1.ColHidden = True
                    AxfpSpread1.Col = 3

                    Dim uom As String = AxfpSpread1.Text
                    Dim uom1 As String
                    Dim itemcode As String
                    AxfpSpread1.Col = 1
                    itemcode = AxfpSpread1.Text
                    '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                    Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                    'gconnection.getDataSet(sql11, "closingtable")
                    gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                    Dim closingqty, rate As Double
                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                        rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                    Else
                        closingqty = 0
                        rate = 0
                    End If
                    uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                    sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                    gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")

                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                    Else
                        convvalue = 1
                    End If
                    closingqty = Format(closingqty * convvalue, "0.000")
                    AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Val(rate / convvalue))

                    AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Val(closingqty))

                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)


                End If
            End If


        End If

    End Sub
    Private Sub addoperation()
        Dim insert(0) As String
        Dim amt As Double = 0

        Dim rate1 As Double

        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            Call autogenerate()
        End If


        docno = Split(Trim(txt_Docno.Text), "/")
        sqlstring = "INSERT INTO STOCKTRANSFERHEADER(Docno,Docdetails,Docdate,Doctype,Fromstorecode,Fromstoredesc, "
        sqlstring = sqlstring & " Tostorecode, Tostoredesc,Remarks,Void,Adduser,Adddate,BUFFETMENU,partybookingno)"
        sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(2))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
        sqlstring = sqlstring & " '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
        sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
        sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
        sqlstring = sqlstring & " '" & Trim(txt_storecode.Text) & "','" & Trim(txt_storeDesc.Text) & "',"

        sqlstring = sqlstring & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,"
        sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',GETDATE(),'" & Trim(txt_buffet.Text) & "','" & Trim(TXT_PARTYNO.Text) & "')"

        insert(0) = sqlstring
        ' Dim Seq As Double = gconnection.getInvSeq(Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy"))
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            '     Avgrate = CalAverageRate(Trim(ssgrid.Text))
            '    AvgQuantity = CalAverageQuantity(Trim(ssgrid.Text))
            sqlstring = "INSERT INTO STOCKTRANSFERDETAIL(Docno,Docdetails,Docdate,Doctype,Fromstorecode,"
            sqlstring = sqlstring & " Fromstoredesc,Tostorecode,Tostoredesc,Itemcode,Itemname,Uom,Qty,batchno,closingqty,"
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "FROMSHELF,TOSHELF,"
            End If
            sqlstring = sqlstring & " Void,Adduser,Adddatetime,RATE,amount)"
            sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(2))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
            sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
            sqlstring = sqlstring & " '" & Trim(txt_storecode.Text) & "','" & Trim(txt_storeDesc.Text) & "',"

            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            Dim qty As Double = Val(AxfpSpread1.Text)
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 5
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 6
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            If GSHELVING = "Y" Then
                AxfpSpread1.Col = 10
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 11
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            End If

            sqlstring = sqlstring & " 'N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "',GETDATE(),"
            AxfpSpread1.Col = 7
            Dim rate As Double = Val(AxfpSpread1.Text)
            sqlstring = sqlstring & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
            AxfpSpread1.Col = 8
            amt = amt + (rate * qty)
            sqlstring = sqlstring & " '" + Format(Val(amt), "0.000") + "')"

            ' sqlstring = sqlstring & " ' ',getDate())"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
        Next
        '    Dim closingqty As Double
        '    Dim closingvalue As Double
        '    Dim closingqty1 As Double
        '    Dim closingvalue1, TRNvalue, TRNqty As Double
        '    Dim UOM As String
        '    Dim uom1 As String
        '    Dim convvalue As Double
        '    Dim precise As Double
        '    Dim RateFleg As String
        '    sqlstring = " Select batchprocess from inv_inventoryitemmaster where itemcode='" + itemcode + "' "
        '    gconnection.getDataSet(sqlstring, "inv_inventoryitemmaster")
        '    If (gdataset.Tables("inv_inventoryitemmaster").Rows.Count > 0) Then
        '        If (gdataset.Tables("inv_inventoryitemmaster").Rows(0).Item("batchprocess")) = "YES" Then
        '            Dim batchno As String
        '            AxfpSpread1.Row = i
        '            AxfpSpread1.Col = 5
        '            batchno = AxfpSpread1.Text
        '            AxfpSpread1.Row = i
        '            AxfpSpread1.Col = 3
        '            UOM = AxfpSpread1.Text
        '            ' sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'   and batchno='" + batchno + "' and trndate<'" + Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
        '            ' gconnection.getDataSet(sqlstring, "closingqty")
        '            gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
        '            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
        '                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
        '                Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
        '                convvalue = gconnection.getvalue(sql)

        '                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock") * convvalue
        '                closingvalue = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
        '            Else
        '                closingqty = 0
        '                convvalue = 1
        '            End If
        '            sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock ,closingvalue,batchyn,ttype,batchno,trns_seq)"
        '            sqlstring = sqlstring & " values ('" + txt_Docno.Text + "',"
        '            AxfpSpread1.Col = 1
        '            sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
        '            AxfpSpread1.Col = 3
        '            sqlstring = sqlstring & "'" + uom1 + "', "
        '            sqlstring = sqlstring & "  '" + TXT_FROMSTORECODE.Text + "',"
        '            sqlstring = sqlstring & " '" + Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") + "',"
        '            AxfpSpread1.Col = 4

        '            sqlstring = sqlstring & " " & Format(Val(closingqty / convvalue), "0.000") & ","

        '            sqlstring = sqlstring & "'" + Format(Val(closingvalue), "0.000") + "' ,"
        '            AxfpSpread1.Col = 4
        '            sqlstring = sqlstring & " " & Format((Val(AxfpSpread1.Text) / convvalue) * -1, "0.000") & ","
        '            sqlstring = sqlstring & " " & Format(Val(closingqty / convvalue) + ((Val(AxfpSpread1.Text) / convvalue) * -1), "0.000") & ","

        '            sqlstring = sqlstring & "'" + Format(Val(closingvalue) - Val(rate * qty), "0.000") + "' ,"


        '            sqlstring = sqlstring & " 'Y',"
        '            sqlstring = sqlstring & "  'TRANSFER', "
        '            AxfpSpread1.Col = 5
        '            sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(Dtp_Docdate.Value, "dd/MMM/yyyy") & "'))"
        '            ReDim Preserve insert(insert.Length)
        '            insert(insert.Length - 1) = sqlstring
        '            'sqlstring = "select TOP 1  ISNULL(closingstock,0) AS  closingstock,closingvalue,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'   and batchno='" + batchno + "' and trndate<'" + Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
        '            '  gconnection.getDataSet(sqlstring, "closingqty")
        '            gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(txt_storecode.Text), "")
        '            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
        '                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
        '                Dim sql As String = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
        '                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
        '                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
        '                    convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
        '                    precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))
        '                End If


        '                closingqty1 = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
        '                closingvalue1 = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")

        '                sqlstring = "SELECT * FROM Grn_details WHERE grndetails='" & gdataset.Tables("CLOSINGQTY").Rows(i).Item("TRNNO") & "' and itemcode='" & itemcode & "'"
        '                gconnection.getDataSet(sqlstring, "Grn_details")
        '                If (gdataset.Tables("Grn_details").Rows.Count > 0) Then
        '                    TRNvalue = Val(gdataset.Tables("Grn_details").Rows(0).Item("amount"))
        '                    TRNqty = Val(gdataset.Tables("Grn_details").Rows(0).Item("qty"))
        '                End If

        '                sqlstring = " select rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
        '                sqlstring = sqlstring & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" & itemcode & "'  "
        '                gconnection.getDataSet(sqlstring, "ratelist")
        '                If (gdataset.Tables("ratelist").Rows.Count > 0) Then
        '                    RateFleg = gdataset.Tables("ratelist").Rows(0).Item("rateflag")
        '                Else
        '                    MsgBox("Fill properly detail of itemcode= " & itemcode & "  in ItemMaster")
        '                    Exit Sub
        '                End If
        '                If Trim(RateFleg.ToUpper()) = "W" Then
        '                    rate1 = (closingvalue1 + rate) / (closingqty1 + qty)
        '                Else
        '                    rate1 = rate / qty
        '                End If
        '            Else
        '                convvalue = 1
        '                closingqty1 = 0
        '                closingvalue1 = 0
        '            End If
        '            sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,trns_seq)"
        '            sqlstring = sqlstring & " values ('" + txt_Docno.Text + "',"
        '            AxfpSpread1.Col = 1
        '            sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
        '            AxfpSpread1.Col = 3
        '            sqlstring = sqlstring & "'" + uom1 + "', "
        '            sqlstring = sqlstring & "  '" + txt_storecode.Text + "',"
        '            sqlstring = sqlstring & " '" + Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") + "',"
        '            sqlstring = sqlstring & " " & Format(Val(closingqty1), "0.000") & ","

        '            sqlstring = sqlstring & "'" + Format(Val(closingvalue1), "0.000") + "' ,"
        '            AxfpSpread1.Col = 4
        '            sqlstring = sqlstring & " " & Format(((Val(AxfpSpread1.Text) / convvalue) + (Val(AxfpSpread1.Text) * precise)) * 1, "0.000") & ","
        '            sqlstring = sqlstring & " " & Format(Val(closingqty1) + (((Val(AxfpSpread1.Text) / convvalue) + (Val(AxfpSpread1.Text) * precise)) * 1), "0.000") & ","

        '            sqlstring = sqlstring & "'" + Format(Val(closingvalue1) + Val(rate1 * qty), "0.000") + "' ,"


        '            sqlstring = sqlstring & " 'Y',"
        '            sqlstring = sqlstring & "  'RECEIEVE', "
        '            AxfpSpread1.Col = 5
        '            sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(Dtp_Docdate.Value, "dd/MMM/yyyy") & "'))"
        '            ReDim Preserve insert(insert.Length)
        '            insert(insert.Length - 1) = sqlstring

        '        Else
        '            AxfpSpread1.Col = 3
        '            UOM = AxfpSpread1.Text
        '            ' sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock, closingvalue,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and trndate<'" + Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by TRNS_SEQ desc"
        '            ' gconnection.getDataSet(sqlstring, "closingqty")
        '            gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
        '            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
        '                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
        '                Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
        '                convvalue = gconnection.getvalue(sql)

        '                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
        '                closingvalue = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
        '            End If
        '            sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,trns_seq,rate)"
        '            sqlstring = sqlstring & " values ('" + txt_Docno.Text + "',"
        '            AxfpSpread1.Col = 1
        '            sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
        '            AxfpSpread1.Col = 3
        '            sqlstring = sqlstring & "'" + uom1 + "', "
        '            sqlstring = sqlstring & "  '" + TXT_FROMSTORECODE.Text + "',"
        '            sqlstring = sqlstring & " '" + Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") + "',"


        '            sqlstring = sqlstring & " " & closingqty & ","

        '            sqlstring = sqlstring & "'" + Format(Val(closingvalue), "0.000") + "' ,"
        '            AxfpSpread1.Col = 4
        '            sqlstring = sqlstring & " " & Format(((Val(AxfpSpread1.Text) / convvalue) + (Val(AxfpSpread1.Text) * precise)) * -1, "0.000") & ","
        '            sqlstring = sqlstring & " " & Format(closingqty - ((Val(AxfpSpread1.Text) / convvalue) + (Val(AxfpSpread1.Text) * precise)), "0.000") & ","

        '            sqlstring = sqlstring & "'" + Format(Val(closingvalue) - Val(rate * qty), "0.000") + "' ,"


        '            sqlstring = sqlstring & " 'N',"
        '            sqlstring = sqlstring & "  'TRANSFER', "
        '            AxfpSpread1.Col = 5
        '            sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(Dtp_Docdate.Value, "dd/MMM/yyyy") & "')," & rate.ToString() & ")"
        '            ReDim Preserve insert(insert.Length)
        '            insert(insert.Length - 1) = sqlstring
        '            ' sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'and trndate<'" + Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by TRNS_SEQ desc"
        '            '   gconnection.getDataSet(sqlstring, "closingqty")
        '            gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(txt_storecode.Text), "")
        '            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
        '                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
        '                Dim sql As String = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
        '                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
        '                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then

        '                    convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
        '                    precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))
        '                End If

        '                closingqty1 = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
        '                closingvalue1 = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
        '                rate1 = gdataset.Tables("closingstock").Rows(0).Item("rate")
        '                'sqlstring = " select isnull(rateflag,'N') as rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
        '                'sqlstring = sqlstring & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" & itemcode & "'  "
        '                'gconnection.getDataSet(sqlstring, "ratelist")
        '                'If (gdataset.Tables("ratelist").Rows.Count > 0) Then
        '                '    RateFleg = gdataset.Tables("ratelist").Rows(0).Item("rateflag")
        '                'Else
        '                '    MsgBox("Fill properly detail of itemcode= " & itemcode & "  in ItemMaster")
        '                '    Exit Sub
        '                'End If
        '                'If Trim(RateFleg.ToUpper()) = "W" Then
        '                '    rate1 = (closingvalue1 + rate) / (closingqty1 + qty)
        '                'Else
        '                '    rate1 = rate / qty
        '                'End If

        '            End If
        '            sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,trns_seq,rate)"
        '            sqlstring = sqlstring & " values ('" + txt_Docno.Text + "',"
        '            AxfpSpread1.Col = 1
        '            sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
        '            AxfpSpread1.Col = 3
        '            sqlstring = sqlstring & "'" + uom1 + "', "
        '            sqlstring = sqlstring & "  '" + txt_storecode.Text + "',"
        '            sqlstring = sqlstring & " '" + Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") + "',"


        '            sqlstring = sqlstring & " " & closingqty1 & ","

        '            sqlstring = sqlstring & "'" + Format(Val(closingvalue1), "0.000") + "' ,"
        '            AxfpSpread1.Col = 4
        '            sqlstring = sqlstring & " " & Format(((Val(AxfpSpread1.Text) / convvalue) + Val(AxfpSpread1.Text) * precise) * 1, "0.000") & ","
        '            sqlstring = sqlstring & " " & Format(closingqty1 + (((Val(AxfpSpread1.Text) / convvalue) + Val(AxfpSpread1.Text) * precise)), "0.000") & ","

        '            sqlstring = sqlstring & "'" + Format(Val(closingvalue1) + Val(rate1 * qty), "0.000") + "' ,"


        '            sqlstring = sqlstring & " 'N',"
        '            sqlstring = sqlstring & "  'RECEIEVE', "
        '            AxfpSpread1.Col = 5
        '            sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(Dtp_Docdate.Value, "dd/MMM/yyyy") & "')," & rate.ToString() & ")"
        '            ReDim Preserve insert(insert.Length)
        '            insert(insert.Length - 1) = sqlstring

        '        End If

        '        'sqlstring = "update CLOSINGQTY set TRNS_SEQ=g.TRNS_SEQ from CLOSINGQTY c inner join STOCKTRANSFERDETAIL g on trnno='" + txt_Docno.Text + "' where c.Itemcode='" + itemcode + "' and  c.Trndate= G.Docdate"
        '        'ReDim Preserve insert(insert.Length)
        '        'insert(insert.Length - 1) = sqlstring
        '        'gconnection.MoreTrans1(insert)
        '        'ReDim insert(0)

        '        sqlstring = "Select getdate()"
        '        tdate = gconnection.getvalue(sqlstring)
        '        If (Format(CDate(tdate), "yyyy/MM/dd") > Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd")) Then
        '            Dim batchyn As String
        '            Dim AUTOID As Integer = 0
        '            Dim TRNS_SEQ As Double
        '            ' sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid,ISNULL(TRNS_SEQ,0) AS TRNS_SEQ, ISNULL(batchyn,'N') AS batchyn from closingqty where itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'and trndate<='" + Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
        '            ' gconnection.getDataSet(sqlstring, "closingqty")

        '            gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(txt_storecode.Text), "")

        '            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
        '                AUTOID = Val(gdataset.Tables("closingstock").Rows(0).Item("AUTOID"))
        '                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
        '                closingvalue = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
        '                TRNS_SEQ = gdataset.Tables("closingstock").Rows(0).Item("TRNS_SEQ")
        '                batchyn = gdataset.Tables("closingstock").Rows(0).Item("batchyn")
        '            End If

        '            sqlstring = "update closingqty set openningstock= openningstock +" + Format(Val(qty), "0.000") + " ,"
        '            sqlstring = sqlstring & "  openningvalue="
        '            sqlstring = sqlstring & "  CASE WHEN openningstock=0"
        '            sqlstring = sqlstring & "  THEN"
        '            sqlstring = sqlstring & "   '" + Format(Val((qty * rate)), "0.000") + "' "
        '            sqlstring = sqlstring & "    Else"

        '            sqlstring = sqlstring & "  openningvalue +" + Format(Val((qty * rate)), "0.000") + ""
        '            sqlstring = sqlstring & "    End"
        '            sqlstring = sqlstring & " ,closingstock= closingstock +" + Format(Val(qty), "0.000") + " ,"
        '            sqlstring = sqlstring & "  closingvalue="
        '            sqlstring = sqlstring & "  CASE WHEN closingstock=0"
        '            sqlstring = sqlstring & "  THEN "
        '            sqlstring = sqlstring & "  0 "
        '            sqlstring = sqlstring & "  Else"
        '            sqlstring = sqlstring & "     closingvalue +" + Format(Val((qty * rate)), "0.000") + ""
        '            sqlstring = sqlstring & "       End"

        '            sqlstring = sqlstring & "  where trndate>'" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "'"
        '            sqlstring = sqlstring & "   and storecode='" + txt_storecode.Text + "' and itemcode='" + itemcode + "'"
        '            sqlstring = sqlstring & " AND TRNS_SEQ >" + TRNS_SEQ.ToString() + "  "
        '            'If (batchyn = "Y") Then
        '            '    AxfpSpread1.Col = 6
        '            '    sqlstring = sqlstring & "  and  batchno='" + AxfpSpread1.Text + "'"
        '            'End If
        '            ReDim Preserve insert(insert.Length)
        '            insert(insert.Length - 1) = sqlstring

        '            ' sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid,ISNULL(TRNS_SEQ,0) AS TRNS_SEQ from closingqty where itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and trndate<='" + Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by TRNS_SEQ desc"
        '            ' gconnection.getDataSet(sqlstring, "closingqty")
        '            gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
        '            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
        '                AUTOID = Val(gdataset.Tables("closingstock").Rows(0).Item("AUTOID"))
        '                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
        '                closingvalue = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
        '                TRNS_SEQ = gdataset.Tables("closingstock").Rows(0).Item("TRNS_SEQ")
        '            End If

        '            sqlstring = "update closingqty set openningstock= openningstock -" + Format(Val(qty), "0.000") + " ,"
        '            sqlstring = sqlstring & "  openningvalue="
        '            sqlstring = sqlstring & "  CASE WHEN openningstock=0"
        '            sqlstring = sqlstring & "  THEN"
        '            sqlstring = sqlstring & "   '" + Format(Val((qty * rate)), "0.000") + "' "
        '            sqlstring = sqlstring & "    Else"

        '            sqlstring = sqlstring & "  openningvalue -" + Format(Val((qty * rate1)), "0.000") + ""
        '            sqlstring = sqlstring & "    End"
        '            sqlstring = sqlstring & " ,closingstock= closingstock -" + Format(Val(qty), "0.000") + " ,"
        '            sqlstring = sqlstring & "  closingvalue="
        '            sqlstring = sqlstring & "  CASE WHEN closingstock=0"
        '            sqlstring = sqlstring & "  THEN "
        '            sqlstring = sqlstring & "  0 "
        '            sqlstring = sqlstring & "  Else"
        '            sqlstring = sqlstring & "     closingvalue -" + Format(Val((qty * rate1)), "0.000") + ""
        '            sqlstring = sqlstring & "       End"

        '            sqlstring = sqlstring & "  where trndate>'" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "'"
        '            sqlstring = sqlstring & "   and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "'"
        '            sqlstring = sqlstring & " AND TRNS_SEQ >" + TRNS_SEQ.ToString() + "  "
        '            'If (batchyn = "Y") Then
        '            '    AxfpSpread1.Col = 6
        '            '    sqlstring = sqlstring & "  and  batchno='" + AxfpSpread1.Text + "'"
        '            'End If
        '            ReDim Preserve insert(insert.Length)
        '            insert(insert.Length - 1) = sqlstring



        '        End If
        '    End If


        'Next
        'sqlstring = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
        'sqlstring = sqlstring & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
        'sqlstring = sqlstring & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
        'sqlstring = sqlstring & " from inv_Inventoryuomstorelink a inner join closingqty b"
        'sqlstring = sqlstring & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
        If (GACCPOST.ToUpper() = "Y") And gAcPostingWise = "STORE" Then


            sqlstring = "Select  * from AccountstaggingNEW where code='" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(VOID,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "CODE")
            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                sqlstring = sqlstring & " VALUES('" & Trim(txt_Docno.Text) & "', '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy ") & "', "
                sqlstring = sqlstring & "'', 'STOCK TRANSFER', '" & accode & "',"
                sqlstring = sqlstring & "'" & acdesc & "',"
                sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                sqlstring = sqlstring & "'CREDIT',"

                'Dim qty As Double = Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))
                ' amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text)) / TOTALISSUEQTY) * qty, "0.000")
                decription = "Stock Transfer  no " + Trim(txt_Docno.Text) + " date " + Format(CDate(Dtp_Docdate.Value), "dd-MMM-yyyy") + ""
                sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                ''slcode = txt_Storecode.Text
                sqlstring = sqlstring & "'N','" + gUsername + "')"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
            Else
                MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR StoreCode:-'" & txt_storecode.Text & "'")
                Exit Sub
            End If
            sqlstring = "Select  * from AccountstaggingNEW where code='" & Trim(txt_storecode.Text) & "' AND ISNULL(VOID,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "CODE")
            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                sqlstring = sqlstring & " VALUES('" & Trim(txt_Docno.Text) & "', '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy ") & "', "
                sqlstring = sqlstring & "'', 'STOCK TRANSFER', '" & accode & "',"
                sqlstring = sqlstring & "'" & acdesc & "',"
                sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                sqlstring = sqlstring & "'DEBIT',"

                'Dim qty As Double = Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))
                ' amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text)) / TOTALISSUEQTY) * qty, "0.000")
                decription = "Stock Transfer  no " + Trim(txt_Docno.Text) + " date " + Format(CDate(Dtp_Docdate.Value), "dd-MMM-yyyy") + ""
                sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                ''slcode = txt_Storecode.Text
                sqlstring = sqlstring & "'N','" + gUsername + "')"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
            Else
                MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR StoreCode:-'" & txt_storecode.Text & "'")
                Exit Sub
            End If

        End If



        gconnection.MoreTrans(insert)
        'Dim SEQ As Double
        ''sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        ''sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
        ''gconnection.getDataSet(sqlstring, "closingqty")
        ''If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        ''    SEQ = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        ''End If
        'For k As Integer = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = k
        '    AxfpSpread1.Col = 1


        '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        '    sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' AND ITEMCODE='" & AxfpSpread1.Text & "'"
        '    gconnection.getDataSet(sqlstring, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        SEQ = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        '        gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, SEQ)
        '    End If
        '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + txt_storecode.Text + "' "
        '    sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' AND ITEMCODE='" & AxfpSpread1.Text & "'"
        '    gconnection.getDataSet(sqlstring, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        SEQ = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        '        gconnection.CalStockValue(txt_storecode.Text, AxfpSpread1.Text, SEQ)
        '    End If
        'Next

        If GBATCHNO = "Y" Then
            Dim strsql As String
            strsql = "update temp_batchdetails set qty= qty*-1 WHERE STORECODE= '" & TXT_FROMSTORECODE.Text & "' "
            gconnection.getDataSet(strsql, "updateminusqty")
            strsql = "insert into inv_Batchdetails(trnno,itemcode,uom,storecode,trndate,QTY,ttype,batchno,rate,expirydate)"
            strsql = strsql & " select Trnno,itemcode,uom,storecode,Trndate,qty,ttype,batchno,rate,expirydate from temp_batchdetails where trnno= '" & txt_Docno.Text & "'"
            gconnection.dataOperation(6, strsql, )
            strsql = "delete from temp_batchdetails "
            gconnection.dataOperation(6, strsql, )
        End If

    End Sub

    Private Sub updateoperation()
        Dim insert(0) As String
        Dim amt As Double
        sqlstring = "select * from STOCKTRANSFERHEADER WHERE Docdetails='" + Trim(CStr(txt_Docno.Text)) + "' and cast(convert(varchar(11),Docdate,106)as datetime)='" & Format(Me.Dtp_Docdate.Value, "dd/MMM/yyyy") & "'"
        gconnection.getDataSet(sqlstring, "backdate")
        If gdataset.Tables("backdate").Rows.Count > 0 Then

            docno = Split(Trim(txt_Docno.Text), "/")

            'FOR LOG DATA
            sqlstring = "INSERT INTO STOCKTRANSFERHEADER_LOG(Docno,Docdetails,Docdate,Doctype,Fromstorecode,Fromstoredesc, "
            sqlstring = sqlstring & " Tostorecode, Tostoredesc,Remarks,Void,Adduser,Adddate) "
            sqlstring = sqlstring & " SELECT Docno,Docdetails,Docdate,Doctype,Fromstorecode,Fromstoredesc, "
            sqlstring = sqlstring & " Tostorecode, Tostoredesc,Remarks,Void,Adduser,Adddate FROM STOCKTRANSFERHEADER WHERE Docdetails='" & Trim(txt_Docno.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOCKTRANSFERHEADER_LOG")

            sqlstring = "INSERT INTO STOCKTRANSFERDETAIL_LOG(Docno,Docdetails,Docdate,Doctype,Fromstorecode,"
            sqlstring = sqlstring & " Fromstoredesc,Tostorecode,Tostoredesc,Itemcode,Itemname,Uom,Qty,batchno,closingqty,"
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "FROMSHELF,TOSHELF,"
            End If
            sqlstring = sqlstring & " Void,Adduser,Adddatetime,RATE,amount)"
            sqlstring = sqlstring & " SELECT Docno,Docdetails,Docdate,Doctype,Fromstorecode,"
            sqlstring = sqlstring & " Fromstoredesc,Tostorecode,Tostoredesc,Itemcode,Itemname,Uom,Qty,batchno,closingqty,"
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "FROMSHELF,TOSHELF,"
            End If
            sqlstring = sqlstring & " Void,Adduser,Adddatetime,RATE,amount  FROM  STOCKTRANSFERDETAIL where Docdetails='" & Trim(txt_Docno.Text) & "' "
            gconnection.getDataSet(sqlstring, "STOCKTRANSFERDETAIL_LOG")
            'LOG DATA ENDS 



            sqlstring = "UPDATE STOCKTRANSFERHEADER SET Docdate='" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "', "
            sqlstring = sqlstring & " Doctype='" & Trim(doctype1) & "',"
            sqlstring = sqlstring & " Fromstorecode='" & Trim(TXT_FROMSTORECODE.Text) & "',"
            sqlstring = sqlstring & " Fromstoredesc='" & Trim(txt_FromStorename.Text) & "',"
            sqlstring = sqlstring & " Tostorecode='" & Trim(txt_storecode.Text) & "',"
            sqlstring = sqlstring & " Tostoredesc='" & Trim(txt_storeDesc.Text) & "', "
            sqlstring = sqlstring & " BUFFETMENU='" & Trim(txt_buffet.Text) & "', "
            sqlstring = sqlstring & " partybookingno='" & Trim(TXT_PARTYNO.Text) & "', "
            sqlstring = sqlstring & " Remarks='" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,"
            sqlstring = sqlstring & " Void='N',Updateuser='" & Trim(gUsername) & "',"
            sqlstring = sqlstring & " UpdateDATE=GETDATE()"
            sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "

            insert(0) = sqlstring
            sqlstring = "delete from STOCKTRANSFERDETAIL where Docdetails='" & Trim(txt_Docno.Text) & "'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            Dim sql1 As String
            Dim SEQ As Double

            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                '     Avgrate = CalAverageRate(Trim(ssgrid.Text))
                '    AvgQuantity = CalAverageQuantity(Trim(ssgrid.Text))

                AxfpSpread1.Col = 1
                Dim itemcode As String = AxfpSpread1.Text

                'sql1 = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
                'sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' and itemcode='" + itemcode + "'"
                'gconnection.getDataSet(sql1, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '    SEQ = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
                'End If


                sqlstring = "INSERT INTO STOCKTRANSFERDETAIL(Docno,Docdetails,Docdate,Doctype,Fromstorecode,"
                sqlstring = sqlstring & " Fromstoredesc,Tostorecode,Tostoredesc,Itemcode,Itemname,Uom,Qty,batchno,closingqty,"
                If GSHELVING = "Y" Then
                    sqlstring = sqlstring & "FROMSHELF,TOSHELF,"
                End If

                sqlstring = sqlstring & " Void,Adduser,Adddatetime,RATE,amount)"
                sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(2))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                sqlstring = sqlstring & " '" & Trim(txt_storecode.Text) & "','" & Trim(txt_storeDesc.Text) & "',"


                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 2
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 3
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 4
                Dim qty As Double = Format(Val(AxfpSpread1.Text), "0.000")
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 5
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 6
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                If GSHELVING = "Y" Then
                    AxfpSpread1.Col = 10
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 11
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                End If
                AxfpSpread1.Col = 9
                sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"

                '  sqlstring = sqlstring & " 'N',"
                sqlstring = sqlstring & " '" & Trim(gUsername) & "',GETDATE(),"
                AxfpSpread1.Col = 7
                Dim rate As Double = Val(AxfpSpread1.Text)
                sqlstring = sqlstring & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                AxfpSpread1.Col = 8
                amt = amt + (rate * qty)
                sqlstring = sqlstring & " '" + Format(Val(amt), "0.000") + "')"


                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring


                'Dim qty1 As Double
                'Dim batchyn As String
                'Dim uom As String
                'Dim uom1 As String
                'Dim convvalue As Double
                'Dim precise As Double
                'Dim batchno As String
                'Dim TRNS_SEQ As Double
                'AxfpSpread1.Col = 3
                'uom1 = AxfpSpread1.Text
                'AxfpSpread1.Col = 5
                'batchno = AxfpSpread1.Text
                'sql1 = "select qty,batchyn,uom,batchno,TRNS_SEQ from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "' "
                'sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
                'If (batchno <> "") Then
                '    sql1 = sql1 & " and  batchno='" + batchno + "' "
                'End If

                'gconnection.getDataSet(sql1, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                '    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                '    '                    batchno = gdataset.Tables("closingqty").Rows(0).Item("batchno")
                '    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                '    TRNS_SEQ = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
                '    Dim sql As String = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                '    gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                '    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '        convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                '        precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")

                '    End If
                'Else
                '    qty1 = 0
                '    convvalue = 1
                'End If
                'sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(qty * ((1 / convvalue) + (Val(AxfpSpread1.Text) * precise)) - (qty1)), "0.000") + ",qty=" + Format(Val((qty / convvalue) + (Val(AxfpSpread1.Text) * precise)), "0.000") + " "
                ''sql1 = sql1 & ",closingvalue=case when closingstock=0 then  closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock)) else  closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock)) end"
                ''sql1 = sql1 & ",openningvalue=case when openningstock =0 then   openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock)) else openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock)) end"
                'sql1 = sql1 & "  where  trnno='" + txt_Docno.Text + "' and storecode='" + txt_storecode.Text + "' and itemcode='" + itemcode + "' "
                ''If (batchyn = "Y") Then
                ''    sql1 = sql1 & "  and  batchno='" + batchno + "'"
                ''End If
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sql1

                'sql1 = "update closingqty set closingstock= closingstock +" + Format(Val((qty * (1 / convvalue) + (Val(AxfpSpread1.Text) * precise)) - (qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val((qty * (1 / convvalue) + (Val(AxfpSpread1.Text) * precise)) - (qty1)), "0.000") + ""
                ''sql1 = sql1 & ",closingvalue= case when closingstock=0 then  closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock)) else  closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock)) end"
                '' sql1 = sql1 & ",openningvalue=  case when openningstock=0 then  openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock)) else openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock)) end "
                'sql1 = sql1 & "  where  trns_seq>" & SEQ.ToString() & " and storecode='" + txt_storecode.Text + "' and itemcode='" + itemcode + "' "
                ''If (batchyn = "Y") Then
                ''    sql1 = sql1 & "  and  batchno='" + txt_Docno.Text + "'"
                ''End If
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sql1
                'sql1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
                'sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
                'If (batchno <> "") Then
                '    sql1 = sql1 & " and  batchno='" + batchno + "' "
                'End If

                'gconnection.getDataSet(sql1, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                '    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                '    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                '    Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                '    convvalue = gconnection.getvalue(sql)
                'Else
                '    qty1 = 0
                '    convvalue = 1
                'End If
                'sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) - ((qty / convvalue) + (qty * precise))), "0.000") + ",qty=-" + Format((Val(qty / convvalue) + (qty * precise)), "0.000") + ""
                '' sql1 = sql1 & " ,closingvalue= case when closingstock=0 then   closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock)) else  closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock)) end"
                ''sql1 = sql1 & " ,openningvalue=  case when openningstock=0 then openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock)) else  openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock)) end"

                'sql1 = sql1 & "  where trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "'  "
                ''If (batchyn = "Y") Then
                ''    sql1 = sql1 & "  and  batchno='" + batchno + "'"
                ''End If
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sql1

                'sql1 = "update closingqty set closingstock=  closingstock +" + Format(Val(-(qty1) - ((qty / convvalue) + (qty * precise))), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1) - ((qty / convvalue) + (qty * precise))), "0.000") + ""
                '' sql1 = sql1 & " ,closingvalue= case when closingstock=0 then  closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock)) else  closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock)) end"
                '' sql1 = sql1 & " ,openningvalue=  case when openningstock=0 then openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock)) else  openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock)) end "
                'sql1 = sql1 & "  where  trns_seq>" & SEQ.ToString() & "  and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
                ''If (batchyn = "Y") Then
                ''    sql1 = sql1 & "  and  batchno='" + batchno + "'"
                ''End If
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sql1

            Next
            'sqlstring = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
            'sqlstring = sqlstring & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
            'sqlstring = sqlstring & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
            'sqlstring = sqlstring & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
            'sqlstring = sqlstring & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
            'sqlstring = sqlstring & " from inv_Inventoryuomstorelink a inner join closingqty b"
            'sqlstring = sqlstring & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
            'ReDim Preserve insert(insert.Length)
            'insert(insert.Length - 1) = sqlstring

            If (GACCPOST.ToUpper() = "Y") And gAcPostingWise = "STORE" Then


                sqlstring = "Select  * from AccountstaggingNEW where code='" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(VOID,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "' AND VoucherType='STOCK TRANSFER'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring

                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                    sqlstring = sqlstring & " VALUES('" & Trim(txt_Docno.Text) & "', '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy ") & "', "
                    sqlstring = sqlstring & "'', 'STOCK TRANSFER', '" & accode & "',"
                    sqlstring = sqlstring & "'" & acdesc & "',"
                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                    sqlstring = sqlstring & "'CREDIT',"

                    'Dim qty As Double = Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))
                    ' amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text)) / TOTALISSUEQTY) * qty, "0.000")
                    decription = "Stock Transfer  no " + Trim(txt_Docno.Text) + " date " + Format(CDate(Dtp_Docdate.Value), "dd-MMM-yyyy") + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    ''slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N','" + gUsername + "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                Else
                    MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR StoreCode:-'" & txt_storecode.Text & "'")
                    Exit Sub
                End If
                sqlstring = "Select  * from AccountstaggingNEW where code='" & Trim(txt_storecode.Text) & "' AND ISNULL(VOID,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                    sqlstring = sqlstring & " VALUES('" & Trim(txt_Docno.Text) & "', '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy ") & "', "
                    sqlstring = sqlstring & "'', 'STOCK TRANSFER', '" & accode & "',"
                    sqlstring = sqlstring & "'" & acdesc & "',"
                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                    sqlstring = sqlstring & "'DEBIT',"

                    'Dim qty As Double = Val(gdataset.Tables("StoreMaster").Rows(l).Item("quantity"))
                    ' amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text)) / TOTALISSUEQTY) * qty, "0.000")
                    decription = "Stock Transfer  no " + Trim(txt_Docno.Text) + " date " + Format(CDate(Dtp_Docdate.Value), "dd-MMM-yyyy") + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    ''slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N','" + gUsername + "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                Else
                    MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR StoreCode:-'" & txt_storecode.Text & "'")
                    Exit Sub
                End If

            End If

            gconnection.MoreTrans(insert)
            'For k As Integer = 1 To AxfpSpread1.DataRowCnt
            '    AxfpSpread1.Row = k
            '    AxfpSpread1.Col = 1

            '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
            '    sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' AND ITEMCODE='" & AxfpSpread1.Text & "'"
            '    gconnection.getDataSet(sqlstring, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '        SEQ = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
            '        gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, SEQ)
            '    End If

            '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + txt_storecode.Text + "' "
            '    sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' AND ITEMCODE='" & AxfpSpread1.Text & "'"
            '    gconnection.getDataSet(sqlstring, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '        SEQ = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
            '        gconnection.CalStockValue(txt_storecode.Text, AxfpSpread1.Text, SEQ)
            '    End If

            'Next

        Else
            voidoperationupdate()
            addoperation()
        End If
    End Sub

    Private Sub voidoperationupdate()
        Dim insert(0) As String
        Dim i As Integer
        Dim SEQ1 As Double

        docno = Split(Trim(txt_Docno.Text), "/")
        'sqlstring = "UPDATE STOCKTRANSFERHEADER SET "
        'sqlstring = sqlstring & " Void='Y',voiduser='" & Trim(gUsername) & "',"
        'sqlstring = sqlstring & " voidDATE=getDate()"
        'sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        sqlstring = "delete from STOCKTRANSFERHEADER  WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "

        insert(0) = sqlstring

        If (GACCPOST.ToUpper() = "Y") Then
            'sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "'"
            sqlstring = "delete from  JOURNALENTRY  where VoucherNo='" & Trim(txt_Docno.Text) & "' AND VoucherType='STOCK TRANSFER'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

        End If
        'sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + txt_storecode.Text + "' "
        'sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
        'gconnection.getDataSet(sqlstring, "closingqty")
        'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '    SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        'End If
        'sqlstring = "UPDATE STOCKTRANSFERDETAIL SET "
        'sqlstring = sqlstring & " Void='Y',voiduser='" & Trim(gUsername) & "',"
        'sqlstring = sqlstring & " voidDATE=getDate()"
        'sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        sqlstring = "delete from STOCKTRANSFERDETAIL  WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring

        'sqlstring = "delete from  closingqty where   trnno='" + Trim(txt_Docno.Text) + "'"

        'ReDim Preserve insert(insert.Length)
        'insert(insert.Length - 1) = sqlstring

        'For i = 1 To AxfpSpread1.DataRowCnt
        '    Dim qty1 As Double
        '    Dim batchyn As String
        '    Dim uom As String
        '    Dim uom1 As String
        '    Dim itemcode As String
        '    AxfpSpread1.Col = 1
        '    itemcode = AxfpSpread1.Text
        '    Dim convvalue As Double
        '    Dim batchno As String
        '    AxfpSpread1.Row = i
        '    ' AxfpSpread1.Col = 6
        '    batchno = ""
        '    AxfpSpread1.Col = 3
        '    uom1 = AxfpSpread1.Text
        '    Dim SQL1 As String = "select qty,batchyn,uom,batchno from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "' "
        '    SQL1 = SQL1 & " and Trnno='" + txt_Docno.Text + "' "
        '    If (batchno <> "") Then
        '        SQL1 = SQL1 & " and batchno='" + batchno + "' "
        '    End If
        '    gconnection.getDataSet(SQL1, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '        batchno = gdataset.Tables("closingqty").Rows(0).Item("batchno")
        '        uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
        '        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
        '        convvalue = gconnection.getvalue(sql)

        '    Else
        '        qty1 = 0
        '        convvalue = 1
        '    End If
        '    SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + ",qty=" + Format(Val(0 / convvalue), "0.000") + " "
        '    'SQL1 = SQL1 & " ,closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
        '    ' SQL1 = SQL1 & " ,openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"

        '    SQL1 = SQL1 & "  where trndate='" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + txt_storecode.Text + "' and itemcode='" + itemcode + "' "
        '    If (batchyn = "Y") Then
        '        SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
        '    End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = SQL1

        '    SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1)), "0.000") + ""
        '    'SQL1 = SQL1 & " ,closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
        '    ' SQL1 = SQL1 & " ,openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
        '    SQL1 = SQL1 & "  where trndate>'" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + txt_storecode.Text + "' and itemcode='" + itemcode + "' "
        '    If (batchyn = "Y") Then
        '        SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
        '    End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = SQL1
        '    SQL1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
        '    SQL1 = SQL1 & " and Trnno='" + txt_Docno.Text + "' "
        '    If batchno <> "" Then
        '        SQL1 = SQL1 & " and batchno='" + batchno + "'"
        '    End If
        '    gconnection.getDataSet(SQL1, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '        uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
        '        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
        '        convvalue = gconnection.getvalue(sql)
        '    Else
        '        qty1 = 0
        '        convvalue = 1
        '    End If
        '    SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + ",qty=-" + Format(Val(0 / convvalue), "0.000") + ""
        '    ' SQL1 = SQL1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
        '    ' SQL1 = SQL1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
        '    SQL1 = SQL1 & "  where trndate='" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    If (batchyn = "Y") Then
        '        SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
        '    End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = SQL1

        '    SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1)), "0.000") + ""
        '    'SQL1 = SQL1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
        '    'SQL1 = SQL1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
        '    SQL1 = SQL1 & "  where trndate>'" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    If (batchyn = "Y") Then
        '        SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
        '    End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = SQL1
        'Next i
        ''sqlstring = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
        'sqlstring = sqlstring & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
        'sqlstring = sqlstring & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
        'sqlstring = sqlstring & " from inv_Inventoryuomstorelink a inner join closingqty b"
        'sqlstring = sqlstring & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
        'ReDim Preserve insert(insert.Length)
        'insert(insert.Length - 1) = sqlstring

        gconnection.MoreTrans1(insert)
        'For k As Integer = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = k
        '    AxfpSpread1.Col = 1
        '    gconnection.CalStockValue(txt_storecode.Text, AxfpSpread1.Text, SEQ1)
        '    gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, SEQ1)
        'Next

    End Sub

    Private Sub voidoperation()
        Dim insert(0) As String
        Dim i As Integer
        Dim SEQ1 As Double

        docno = Split(Trim(txt_Docno.Text), "/")
        sqlstring = "UPDATE STOCKTRANSFERHEADER SET "
        sqlstring = sqlstring & " Void='Y',voiduser='" & Trim(gUsername) & "',"
        sqlstring = sqlstring & " voidDATE=GETDATE()"
        sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "

        insert(0) = sqlstring

        If (GACCPOST.ToUpper() = "Y") Then
            sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "' AND VoucherType='STOCK TRANSFER'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

        End If
        'sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + txt_storecode.Text + "' "
        'sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
        'gconnection.getDataSet(sqlstring, "closingqty")
        'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '    SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        'End If
        sqlstring = "UPDATE STOCKTRANSFERDETAIL SET "
        sqlstring = sqlstring & " Void='Y',voiduser='" & Trim(gUsername) & "',"
        sqlstring = sqlstring & " voidDATE=GETDATE()"
        sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring
        'For i = 1 To AxfpSpread1.DataRowCnt
        '    Dim qty1 As Double
        '    Dim batchyn As String
        '    Dim uom As String
        '    Dim uom1 As String
        '    Dim itemcode As String
        '    AxfpSpread1.Col = 1
        '    itemcode = AxfpSpread1.Text
        '    Dim convvalue As Double
        '    Dim batchno As String
        '    AxfpSpread1.Row = i
        '    ' AxfpSpread1.Col = 6
        '    batchno = ""
        '    AxfpSpread1.Col = 3
        '    uom1 = AxfpSpread1.Text
        '    Dim SQL1 As String = "select qty,batchyn,uom,batchno from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "' "
        '    SQL1 = SQL1 & " and Trnno='" + txt_Docno.Text + "' "
        '    'If (batchno <> "") Then
        '    '    SQL1 = SQL1 & " and batchno='" + batchno + "' "
        '    'End If
        '    gconnection.getDataSet(SQL1, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '        batchno = gdataset.Tables("closingqty").Rows(0).Item("batchno")
        '        uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
        '        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
        '        convvalue = gconnection.getvalue(sql)

        '    Else
        '        qty1 = 0
        '        convvalue = 1
        '    End If
        '    SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + ",qty=" + Format(Val(0 / convvalue), "0.000") + " "
        '    'SQL1 = SQL1 & " ,closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
        '    ' SQL1 = SQL1 & " ,openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"

        '    SQL1 = SQL1 & "  where trndate='" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + txt_storecode.Text + "' and itemcode='" + itemcode + "' "
        '    'If (batchyn = "Y") Then
        '    '    SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
        '    'End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = SQL1

        '    SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1)), "0.000") + ""
        '    'SQL1 = SQL1 & " ,closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
        '    ' SQL1 = SQL1 & " ,openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
        '    SQL1 = SQL1 & "  where trndate>'" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + txt_storecode.Text + "' and itemcode='" + itemcode + "' "
        '    'If (batchyn = "Y") Then
        '    '    SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
        '    'End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = SQL1
        '    SQL1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
        '    SQL1 = SQL1 & " and Trnno='" + txt_Docno.Text + "' "
        '    'If batchno <> "" Then
        '    '    SQL1 = SQL1 & " and batchno='" + batchno + "'"
        '    'End If
        '    gconnection.getDataSet(SQL1, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '        uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
        '        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
        '        convvalue = gconnection.getvalue(sql)
        '    Else
        '        qty1 = 0
        '        convvalue = 1
        '    End If
        '    SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + ",qty=-" + Format(Val(0 / convvalue), "0.000") + ""
        '    ' SQL1 = SQL1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
        '    ' SQL1 = SQL1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
        '    SQL1 = SQL1 & "  where trndate='" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    'If (batchyn = "Y") Then
        '    '    SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
        '    'End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = SQL1

        '    SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1)), "0.000") + ""
        '    'SQL1 = SQL1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
        '    'SQL1 = SQL1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
        '    SQL1 = SQL1 & "  where trndate>'" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    'If (batchyn = "Y") Then
        '    '    SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
        '    'End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = SQL1
        'Next i
        'sqlstring = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
        'sqlstring = sqlstring & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
        'sqlstring = sqlstring & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
        'sqlstring = sqlstring & " from inv_Inventoryuomstorelink a inner join closingqty b"
        'sqlstring = sqlstring & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
        'ReDim Preserve insert(insert.Length)
        'insert(insert.Length - 1) = sqlstring

        gconnection.MoreTrans(insert)
        'For k As Integer = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = k
        '    AxfpSpread1.Col = 1


        '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        '    sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' AND ITEMCODE='" & AxfpSpread1.Text & "'"
        '    gconnection.getDataSet(sqlstring, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        '        gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, SEQ1)
        '    End If
        '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + txt_storecode.Text + "' "
        '    sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' AND ITEMCODE='" & AxfpSpread1.Text & "'"
        '    gconnection.getDataSet(sqlstring, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        '        gconnection.CalStockValue(txt_storecode.Text, AxfpSpread1.Text, SEQ1)
        '    End If
        'Next

        If GBATCHNO = "Y" Then
            Dim strsql As String
            strsql = "delete from inv_Batchdetails where trnno= '" & Trim(txt_Docno.Text) & "'  "
            gconnection.dataOperation(6, strsql, )
        End If

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

    Private Sub clearoperation()
        TXT_FROMSTORECODE.Text = ""
        Call GridUnLock()
        txt_FromStorename.Text = ""
        txt_storecode.Text = ""
        TXT_PARTYNO.Text = ""
        txt_buffet.Text = ""
        txt_storeDesc.Text = ""
        lbl_Freeze.Visible = False
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        txt_Docno.Text = ""
        autogenerate()
        Cmd_Add.Text = "ADD[F7]"
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True
        Me.Cmd_Add.Enabled = True
        Me.Dtp_Docdate.Value = Format(Now, "dd/MMM/yyyy")
        For k As Integer = 0 To 10
            For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                AxfpSpread1.TypeComboBoxClear(3, k)
            Next
        Next
        If gUserCategory <> "S" Then
            Call GetRights()
        End If

        If GBATCHNO = "Y" Then
            Dim STRSQL As String
            STRSQL = "delete from temp_batchdetails "
            gconnection.dataOperation(6, STRSQL, )
        End If
    End Sub

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

    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String
        Dim message, title, defaultValue As String
        Dim myValue As Object
        Dim convvalue As Double
        If e.keyCode = Keys.Enter Then
            i = AxfpSpread1.ActiveRow
            'ITEMCODE
            AxfpSpread1.Row = i




            If AxfpSpread1.ActiveCol = 1 And AxfpSpread1.Lock = False Then

                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) = "" Then




                    binditemcode()
                Else

                    SQL = " select I.itemcode,Itemname,uom,batchprocess,m.category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then



                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            SQL = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z
                            If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES1" Then


                                ' gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))


                                ' Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                                Dim SQL1 As String = "with a as ( "
                                SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty where trndate<'" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "'"
                                SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                                SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_Ratelist.batchrate as rate,closingqty.uom from a inner  join closingqty on "
                                SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                                SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                                SQL1 = SQL1 & " inner  join Vw_Ratelist on a.batchno=Vw_Ratelist.batchno"
                                SQL1 = SQL1 & " and a.itemcode=Vw_Ratelist.itemcode and  a.storecode=closingqty.storecode and a.storecode=vw_ratelist.storecode "
                                SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND a.TRNDATE<'" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  closingqty.closingstock>0 order by trndate "
                                'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                                'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "

                                gconnection.getDataSet(SQL1, "closingtable")
                                If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                    AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                                    GroupBox4.Visible = True
                                    For k As Integer = 0 To gdataset.Tables("closingtable").Rows.Count
                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 1
                                        AxfpSpread2.SetText(1, k + 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))

                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 2
                                        AxfpSpread2.SetText(2, k + 1, gdataset.Tables("closingtable").Rows(k).Item("batchno"))
                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 3
                                        AxfpSpread2.SetText(3, k + 1, Val(gdataset.Tables("closingtable").Rows(k).Item("quantity")))
                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 4
                                        AxfpSpread2.SetText(4, k + 1, gdataset.Tables("closingtable").Rows(k).Item("uom"))
                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 5
                                        AxfpSpread2.SetText(5, k + 1, Val(gdataset.Tables("closingtable").Rows(k).Item("rate")))

                                    Next
                                    AxfpSpread2.SetActiveCell(1, 6)
                                    AxfpSpread2.Focus()
                                Else


                                    AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                                    GroupBox4.Visible = False
                                    AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                                End If
                                '  Calculate()
                            Else

                                AxfpSpread1.Col = 5
                                AxfpSpread1.ColHidden = True
                                AxfpSpread1.Col = 3

                                Dim uom As String = AxfpSpread1.Text
                                Dim uom1 As String
                                Dim itemcode As String
                                AxfpSpread1.Col = 1
                                itemcode = AxfpSpread1.Text
                                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                                Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                                ' gconnection.getDataSet(sql11, "closingtable")
                                gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")

                                Dim closingqty, Rate As Double
                                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                    Rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                                Else
                                    closingqty = 0
                                    Rate = 0
                                End If
                                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                                Else
                                    convvalue = 1
                                End If
                                closingqty = Format(closingqty * convvalue, "0.00")
                                AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Val(Rate / convvalue))
                                AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Val(closingqty))
                                ' Added by Sri for Batch No & Shelving
                                '  batchnocheck()
                                FROMShelfcheck()
                                ToShelfcheck()
                                ' BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
                                'If BATCH_REQ = "YES" Then
                                '    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                                If GSHELVING = "Y" Then
                                    If (gdataset.Tables("FROMShelfcheck").Rows.Count > 0) Then
                                        AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                                    ElseIf (gdataset.Tables("ToShelfcheck").Rows.Count > 0) Then
                                        AxfpSpread1.SetActiveCell(11, AxfpSpread1.ActiveRow)
                                    End If
                                Else
                                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                                End If
                                ' end
                            End If
                        End If


                    End If

                End If                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 2 And AxfpSpread1.Lock = False Then
                AxfpSpread1.Col = 2
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemname()
                Else

                    SQL = " select I.itemcode,Itemname,uom,batchprocess, M.Category  from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_storecode.Text + "' and isnull(m.itemname,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then


                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            SQL = "select  distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z
                            If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES1" Then
                                '  gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                                '  Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                                'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                                'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                                Dim SQL1 As String = "with a as ( "
                                SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty where trndate<'" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                                SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                                SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_Ratelist.batchrate as rate,closingqty.uom as uom from a inner  join closingqty on "
                                SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                                SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                                SQL1 = SQL1 & " inner  join Vw_Ratelist on a.batchno=Vw_Ratelist.batchno"
                                SQL1 = SQL1 & " and a.itemcode=Vw_Ratelist.itemcode and  a.storecode=closingqty.storecode and a.storecode=vw_ratelist.storecode "
                                SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND a.TRNDATE<'" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  closingqty.closingstock>0 order by trndate "

                                gconnection.getDataSet(SQL1, "closingtable")
                                If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                    AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                                    GroupBox4.Visible = True

                                    For k As Integer = 0 To gdataset.Tables("closingtable").Rows.Count
                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 1
                                        AxfpSpread2.SetText(1, k + 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))

                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 2
                                        AxfpSpread2.SetText(2, k + 1, gdataset.Tables("closingtable").Rows(k).Item("batchno"))
                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 3
                                        AxfpSpread2.SetText(3, k + 1, Val(gdataset.Tables("closingtable").Rows(k).Item("quantity")))
                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 4
                                        AxfpSpread2.SetText(4, k + 1, gdataset.Tables("closingtable").Rows(k).Item("uom"))
                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 5
                                        AxfpSpread2.SetText(5, k + 1, Val(gdataset.Tables("closingtable").Rows(k).Item("rate")))

                                    Next
                                    AxfpSpread2.SetActiveCell(1, 6)
                                    AxfpSpread2.Focus()

                                Else
                                    GroupBox4.Visible = False
                                    AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                                    AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)

                                End If


                            Else
                                'SQL = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                                'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                                '    Dim sql1 As String
                                '    If rateflag = "W" Then
                                '        sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' "
                                '        sql1 = sql1 & " and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                                '    Else
                                '        sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                '        sql1 = sql1 & " and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                                '    End If
                                '    gconnection.getDataSet(sql1, "ratelist")
                                '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then


                                '        Dim pr As Double

                                '        AxfpSpread1.Col = 3
                                '        sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                                '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                                '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                '        Else
                                '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                                '            Exit Sub
                                '        End If
                                '        AxfpSpread1.Col = 7
                                '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                                '    Else
                                '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' and isnull(openningqty,0) <>0 "
                                '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                                '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                                '            Dim pr As Double

                                '            AxfpSpread1.Col = 3
                                '            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                                '            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                                '            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                '                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                '                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                '            Else
                                '                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                                '                Exit Sub
                                '            End If
                                '            AxfpSpread1.Col = 7
                                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                                '        End If
                                '    End If



                                'End If
                                AxfpSpread1.Col = 5
                                AxfpSpread1.ColHidden = True
                                AxfpSpread1.Col = 3

                                Dim uom As String = AxfpSpread1.Text
                                Dim uom1 As String
                                Dim itemcode As String
                                AxfpSpread1.Col = 1
                                itemcode = AxfpSpread1.Text
                                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                                Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                                '  gconnection.getDataSet(sql11, "closingtable")
                                gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                                Dim closingqty, Rate As Double
                                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                    Rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                                Else
                                    closingqty = 0
                                    Rate = 0
                                End If
                                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                                Else
                                    convvalue = 1
                                End If
                                closingqty = Format(closingqty * convvalue, "0.00")
                                AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Val(Rate / convvalue))
                                AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Val(closingqty))

                                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)


                            End If

                        End If
                        'AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(2, AxfpSpread1.ActiveRow)
                    End If
                End If

                'QTY
            ElseIf AxfpSpread1.ActiveCol = 3 Then
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                'AxfpSpread1.Col = 1
                'Dim sql1 As String
                Dim ITEMCODE As String
                'ITEMCODE = AxfpSpread1.Text
                'SQL = "    sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER inner join inv_inventoryitemmaster on"
                'SQL = SQL & " inv_inventoryitemmaster.category = INVENTORYCATEGORYMASTER.CATEGORYCODE where itemcode='" + Trim(ITEMCODE) + "'"
                ''  sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")

                '    If rateflag = "W" Then
                '        sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(ITEMCODE) + "' "
                '        sql1 = sql1 & " and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                '    Else
                '        sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(ITEMCODE) + "' "
                '        sql1 = sql1 & " and  '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                '    End If
                '    gconnection.getDataSet(sql1, "ratelist")
                '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then


                '        Dim pr As Double

                '        AxfpSpread1.Col = 3
                '        sql1 = "select isnull(convvalue,0) as convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                '        Else
                '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                '            Exit Sub
                '        End If
                '        AxfpSpread1.Col = 7
                '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                '    Else
                '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(0).Item("itemcode")) + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and isnull(openningqty,0) <>0 "
                '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                '            Dim pr As Double

                '            AxfpSpread1.Col = 3
                '            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                '            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                '            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                '                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                '            Else
                '                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                '                Exit Sub
                '            End If
                '            AxfpSpread1.Col = 7
                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                '        End If
                '    End If
                'End If
                AxfpSpread1.Col = 1
                ITEMCODE = AxfpSpread1.Text
                AxfpSpread1.Col = 3
                Dim UOM As String = AxfpSpread1.Text
                Dim UOM1 As String
                Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"

                gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), ITEMCODE, Trim(TXT_FROMSTORECODE.Text), "")
                ' gconnection.getDataSet(sql11, "closingtable")
                Dim closingqty, Rate As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    Rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                Else
                    closingqty = 0
                    Rate = 0
                End If
                UOM1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + UOM1 + "' and transuom='" + UOM + "'"
                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")

                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    convvalue = 1
                End If
                closingqty = closingqty * convvalue
                AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(Rate / convvalue), "0.000"))
                AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))


            ElseIf AxfpSpread1.ActiveCol = 4 Then

                AxfpSpread1.Col = 1
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim itemcode1 As String = AxfpSpread1.Text
                AxfpSpread1.Col = 2
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim itemname1 As String = AxfpSpread1.Text
                AxfpSpread1.Col = 3
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim uom3 As String = AxfpSpread1.Text
                AxfpSpread1.Col = 4
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim totqty As String = AxfpSpread1.Text
                If GBATCHNO = "Y" Then
                    If (Val(AxfpSpread1.Text) <> 0) Then
                        Dim match As New Matching
                        match.LBL_ITEMCODE.Text = itemcode1
                        match.lbl_itemname.Text = itemname1
                        match.TType = "TRANSFER"
                        match.STORECODE = TXT_FROMSTORECODE.Text
                        match.STORECOD2 = txt_storecode.Text
                        match.TotalQTY = totqty
                        match.docno = txt_Docno.Text
                        match.docdate = Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy")
                        match.uom = uom3
                        match.ShowDialog()
                    End If
                End If



                AxfpSpread1.Col = 4
                If (Val(AxfpSpread1.Text) <> 0) Then
                    Dim issuedqty As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 7
                    Dim RATE As Double = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 8
                    AxfpSpread1.Text = Format(Val(issuedqty * RATE), "0.000")
                    AxfpSpread1.Col = 1
                    Dim itemcode As String = AxfpSpread1.Text
                    AxfpSpread1.Col = 5
                    Dim Batchno As String = AxfpSpread1.Text
                    SQL = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
                    gconnection.getDataSet(SQL, "INV_InventoryItemMaster")
                    If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                        If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
                            AxfpSpread1.Col = 3
                            Dim uom As String = AxfpSpread1.Text
                            Dim uom1 As String
                            '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                            Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                            ' gconnection.getDataSet(sql11, "closingtable")

                            ' SRI For BatchWise Closing Stock
                            'If GBATCHNO = "Y" Then
                            '    gconnection.BatchWiseClosingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), Batchno)
                            ' Else
                            gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                            '   End If
                            ' Ends
                            Dim closingqty As Double
                            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                            Else
                                closingqty = 0

                            End If

                            SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                            gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                            Else
                                convvalue = 0
                            End If
                            closingqty = closingqty * convvalue

                            If (issuedqty > closingqty) Then
                                MessageBox.Show("Transfer Quantity Cannot be Greater than Closing Quantity " + closingqty.ToString())
                                AxfpSpread1.SetText(4, AxfpSpread1.ActiveRow, "0.0")
                                AxfpSpread1.SetActiveCell(4, AxfpSpread1.Row)
                                AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, "0.0")
                                AxfpSpread1.SetActiveCell(8, AxfpSpread1.Row)
                            Else
                                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                            End If
                        End If

                    End If
                    'If GINDENTNO = "Y" Then
                    '    AxfpSpread1.Col = 4
                    '    Dim indentqty As Double = Val(AxfpSpread1.Text)
                    '    If (issuedqty > indentqty) Then
                    '        MessageBox.Show("Issued Quantity Cannot be Greater than Indent Quantity")
                    '        AxfpSpread1.SetActiveCell(5, AxfpSpread1.Row)
                    '    End If
                    'Else
                    '    '    Calculate()
                    '    AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                    'End If


                Else

                    'Calculate()
                    If (GroupBox3.Visible = True) Then
                        AxfpSpread2.SetActiveCell(5, 1)
                        AxfpSpread2.Focus()
                    Else


                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                    End If
                End If

            End If
        ElseIf AxfpSpread1.ActiveCol = 5 Then
            'If GBATCHNO = "Y" Then
            '    AxfpSpread1.Col = 5
            '    BatchNoSelection()
            'End If
        ElseIf AxfpSpread1.ActiveCol = 10 Then
            If GSHELVING = "Y" Then
                AxfpSpread1.Col = 10
                Fromshelf()
            End If
        ElseIf AxfpSpread1.ActiveCol = 11 Then
            If GSHELVING = "Y" Then
                AxfpSpread1.Col = 11
                ToShelf()
            End If
        ElseIf e.keyCode = Keys.F3 Then
            If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
            ElseIf Mid(Cmd_Add.Text, 1, 1).ToUpper() = "U" Then
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                End If


            End If
        Else
            If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                AxfpSpread1.Lock = False
            End If


        End If

        If (GroupBox3.Visible = True) Then
            AxfpSpread2.SetActiveCell(5, 1)
            AxfpSpread2.Focus()
            Me.Focus()
        End If

    End Sub
    Private Sub Fromshelf()
        Dim vform As New ListOperattion1
        gSQLString = "SELECT distinct Shelfcode,ShelfDesc FROM InventoryShelfMaster"
        M_WhereCondition = "  WHERE STORECODE='" + TXT_FROMSTORECODE.Text + "' AND ISNULL(FREEZE,'')<>'Y' "
        'M_Groupby = " c.itemcode,i.itemname,c.batchno "
        M_ORDERBY = " Shelfcode "
        vform.Field = " Shelfcode,ShelfDesc"
        vform.vFormatstring = "    Shelf code    |   Shelf Desc      "
        vform.vCaption = "Shelf Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_Duplicate(vform.keyfield) = False) Then
                AxfpSpread1.Col = 10
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.SetActiveCell(10, 1)
                AxfpSpread1.Focus()
            Else
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If
        End If
    End Sub
    Private Sub ToShelf()
        Dim vform As New ListOperattion1
        gSQLString = "SELECT distinct Shelfcode,ShelfDesc FROM InventoryShelfMaster"
        M_WhereCondition = "  WHERE  STORECODE='" + txt_storecode.Text + "' AND ISNULL(FREEZE,'')<>'Y' "
        'M_Groupby = " c.itemcode,i.itemname,c.batchno "
        M_ORDERBY = " Shelfcode "
        vform.Field = " Shelfcode,ShelfDesc"
        vform.vFormatstring = "    Shelf code    |   Shelf Desc      "
        vform.vCaption = "Shelf Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_Duplicate(vform.keyfield) = False) Then
                AxfpSpread1.Col = 11
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.SetActiveCell(4, 1)
                AxfpSpread1.Focus()
            Else
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If
        End If
    End Sub
    Private Sub BatchNoSelection()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue, itemcode As String
        Dim myValue As Object
        message = "Enter Batch No"
        title = "Batch No"
        AxfpSpread1.Col = 1
        AxfpSpread1.Row = AxfpSpread1.ActiveRow
        itemcode = AxfpSpread1.Text
        gSQLString = "select  DISTINCT c.itemcode,i.itemname,c.batchno,C.QTY from INV_InventoryItemMaster i inner join  closingqty c  on "
        gSQLString = gSQLString & " i.itemcode=c.itemcode "
        M_WhereCondition = " where i.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(i.void,'')='N' and isnull(c.storecode,'')='" + TXT_FROMSTORECODE.Text + "'  and isnull(c.batchno,'') <>'' and c.itemcode ='" + itemcode + "' "
        'M_Groupby = " c.itemcode,i.itemname,c.batchno "
        M_ORDERBY = " c.itemcode "
        vform.Field = " c.itemcode,i.itemname,c.batchno,cast(C.QTY as varchar) "
        vform.vFormatstring = "    Itemcode    |         Itemname                  |   batchno                        |  QTY  "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_Duplicate(vform.keyfield) = False) Then
                AxfpSpread1.Col = 5
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield2)
                AxfpSpread1.Col = 4
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield3)
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                AxfpSpread1.Focus()
            Else
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If
        End If
    End Sub

    Private Sub txt_storecode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_storecode.KeyDown

        If e.KeyCode = Keys.Enter Then
            If txt_storecode.Text = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
                sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(txt_storecode.Text) & "' and storecode<>'" + Trim(TXT_FROMSTORECODE.Text) + "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    doctype1 = ""
                    If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
                        doctype1 = "RET"
                        lbl_Heading.Text = "STOCK RETURN"
                    Else
                        doctype1 = "TRF"
                        lbl_Heading.Text = "STOCK TRANSFER"
                    End If
                    Call autogenerate()
                End If
                Dtp_Docdate.Focus()
            Else
                sqlstring = " SELECT DISTINCT(storecode),storedesc FROM STOREMASTER"
                sqlstring = sqlstring & " WHERE STORECODE = '" & txt_storecode.Text & "' "
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    txt_storeDesc.Text = gdataset.Tables("STOREMASTER1").Rows(0).Item("STOREDESC")
                    Dtp_Docdate.Focus()
                End If
                sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(txt_storecode.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    doctype1 = ""
                    If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
                        doctype1 = "RET"
                        lbl_Heading.Text = "STOCK RETURN"
                    Else
                        doctype1 = "TRF"
                        lbl_Heading.Text = "STOCK TRANSFER"
                    End If
                    Call autogenerate()
                End If
            End If
        End If
        If e.KeyCode = Keys.F4 Then
            Call cmd_storecode_Click(cmd_storecode, e)
        End If


    End Sub





    Private Sub Dtp_Docdate_KeyDown(sender As Object, e As KeyEventArgs) Handles Dtp_Docdate.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            AxfpSpread1.Focus()
            AxfpSpread1.SetActiveCell(1, 1)
        End If
    End Sub

    Private Sub ButCANCEL_Click(sender As Object, e As EventArgs) Handles ButCANCEL.Click
        GroupBox4.Visible = False
    End Sub

    Private Sub AxfpSpread2_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread2.KeyDownEvent
        If (e.keyCode = Keys.Enter) Then
            If AxfpSpread2.ActiveCol = 6 Then
                Dim totqty As Double
                AxfpSpread2.Row = AxfpSpread2.ActiveRow
                AxfpSpread2.Col = 6
                Dim batchqty As Double = Val(AxfpSpread2.Text)
                AxfpSpread2.Col = 3
                Dim clsqty As Double = Val(AxfpSpread2.Text)

                If (batchqty > clsqty) Then
                    MessageBox.Show("Issued Quantity Must be Less Than Closing Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    AxfpSpread2.SetText(6, AxfpSpread2.ActiveRow, "0.000")
                    AxfpSpread2.SetActiveCell(6, AxfpSpread2.ActiveRow)

                End If


                AxfpSpread2.SetActiveCell(6, AxfpSpread2.ActiveRow + 1)
            Else
                AxfpSpread2.SetActiveCell(6, AxfpSpread2.ActiveRow + 1)
            End If

        End If

    End Sub

    Private Sub ButOK_Click(sender As Object, e As EventArgs) Handles ButOK.Click
        Dim qty As Double
        Dim K As Integer
        Dim col2 As Integer
        Dim row As Integer
        Dim itemcode As String
        Dim batchqty, totbatchqty As Double
        Dim INDQTY As Double
        Dim m As Double = 1
        Dim uom As String
        Dim uom1 As String
        Dim sql As String
        Dim convvalue As Double
        K = AxfpSpread1.ActiveRow
        If AxfpSpread2.DataRowCnt >= 1 Then
            AxfpSpread2.Col = 1
            itemcode = AxfpSpread2.Text

            For l As Integer = 1 To AxfpSpread2.DataRowCnt
                AxfpSpread2.Row = l
                AxfpSpread2.Col = 6
                batchqty = Val(AxfpSpread2.Text)
                row = l
                AxfpSpread2.Col = 4
                uom = AxfpSpread2.Text
                AxfpSpread1.Col = 3
                uom1 = AxfpSpread1.Text
                Sql = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                gconnection.getDataSet(Sql, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
                Else
                    convvalue = 1
                End If
                If (batchqty <> 0) Then
                    If (m = 1) Then
                        AxfpSpread2.Row = l
                        AxfpSpread1.SetText(4, K, batchqty * convvalue)
                        AxfpSpread2.Col = 2
                        AxfpSpread1.SetText(5, K, AxfpSpread2.Text)
                        AxfpSpread2.Col = 3
                        AxfpSpread1.SetText(6, K, Val(AxfpSpread2.Text) * convvalue)

                    Else
                        AxfpSpread1.InsertRows(K + m, 1)
                        Sql = " select I.itemcode,Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                        Sql = Sql & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(itemcode) + "'"
                        gconnection.getDataSet(Sql, "inv_InventoryOpenningstock")
                        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                            AxfpSpread1.SetText(1, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            AxfpSpread1.SetText(3, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            AxfpSpread2.Row = l
                            AxfpSpread1.SetText(4, K + m - 1, batchqty * convvalue)
                            AxfpSpread2.Col = 2
                            AxfpSpread1.SetText(5, K + m - 1, AxfpSpread2.Text)
                            AxfpSpread2.Col = 3
                            AxfpSpread1.SetText(6, K, Val(AxfpSpread2.Text))


                        End If

                    End If
                    m = m + 1
                    totbatchqty = totbatchqty + (batchqty * convvalue)
                    AxfpSpread1.SetActiveCell(1, K + m - 1)
                    ' Calculate()
                End If

            Next
        End If
        For i As Integer = 0 To AxfpSpread2.DataRowCnt
            AxfpSpread2.Col = 5
            qty += Val(AxfpSpread2.Text)

        Next
        GroupBox4.Visible = False

    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
    End Sub





    Private Function validateoninsert() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd"), txt_storecode.Text)
        'Else
        '    checkBdate = gconnection.checkBdate(Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd"))
        'End If
        Dim bdate1 As String
        Dim sql1 As String

        sql1 = "select convert(varchar(11),bdate,106) as bdate1 from Businessdate"
        gconnection.getDataSet(sql1, "Businessdate")

        If (gdataset.Tables("Businessdate").Rows.Count > 0) Then
            bdate1 = "Your current Business date is " & gdataset.Tables("Businessdate").Rows(0).Item("bdate1").ToString
        End If



        checkBdate = gconnection.checkBdate(Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd"), txt_storecode.Text, TXT_FROMSTORECODE.Text)
        If checkBdate = True And RESU1 = False Then
            MsgBox(bdate1)
            flag = True
            Return flag
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
            flag = True
            Return flag
        End If
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If
        If DateDiff(DateInterval.Day, (CDate(Dtp_Docdate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("Doc Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If txt_Docno.Text = "" Then
            MessageBox.Show("Please Fill IssueDocno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

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
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If

        '********************

        For j As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 1
            Dim itemcode As String
            Dim qty As Double
            If AxfpSpread1.Text = "" Then
                MessageBox.Show("Item Code Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(1, j)

                flag = True
                Return flag
            End If
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 2
            If AxfpSpread1.Text = "" Then
                MessageBox.Show("Item Name Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(2, j)

                flag = True
                Return flag
            End If
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 3
            If AxfpSpread1.Text = "" Then
                MessageBox.Show("UOM Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(3, j)

                flag = True
                Return flag
            End If
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 4
            qty = Val(AxfpSpread1.Text)
            If AxfpSpread1.Text <= 0 Then
                MessageBox.Show("Quantity can't be Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(4, j)

                flag = True
                Return flag
            End If


            AxfpSpread1.Col = 4
            If (Val(AxfpSpread1.Text) <> 0) Then
                Dim issuedqty As Double = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 1
                itemcode = AxfpSpread1.Text
                Dim sql2 As String
                sql2 = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
                gconnection.getDataSet(sql2, "INV_InventoryItemMaster")
                If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                    If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
                        AxfpSpread1.Col = 3
                        Dim uom As String = AxfpSpread1.Text
                        Dim uom1 As String
                        '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                        ' sql1 = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                        ' gconnection.getDataSet(sql1, "closingtable")
                        Dim closingqty As Double
                        gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                            closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                            uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                        Else
                            closingqty = 0
                            uom1 = uom
                        End If

                        sql1 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                        Dim convvalue As Double
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                        Else
                            MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag

                        End If
                        closingqty = closingqty * convvalue
                        If (issuedqty > closingqty) Then
                            MessageBox.Show("Transfer Quantity Cannot be Greater than Closing Quantity " + closingqty.ToString())
                            flag = True
                            Return flag

                        End If
                        sql1 = "select closingstock +" + Format(Val(-(issuedqty)), "0.000") + " from closingqty where   CAST(Trndate AS dATE)>cast( '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' as Date) "
                        sql1 = sql1 & "and closingstock +" + Format(Val(-(issuedqty)), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' AND ITEMCODE='" + itemcode + "'"
                        'If batchyn = "Y" Then
                        '    sql = sql & " and batchno='" + batchno + "'"
                        'End If
                        gconnection.getDataSet(sql1, "closingqty")
                        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                            MessageBox.Show("Transfer  create " + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag
                        End If
                    End If


                End If
            End If
            'sqlstring = "Select getdate()"
            'tdate = gconnection.getvalue(sqlstring)
            'If (Format(CDate(tdate), "yyyy/MM/dd") > Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd")) Then
            '    Dim count As Double = 0
            '    Dim sql As String

            '    sql = "select * from closingqty where   CAST(Trndate AS dATE) > '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate,priority "

            '    gconnection.getDataSet(sql, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

            '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
            '        count = count - qty
            '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
            '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
            '            If count < 0 Then
            '                MessageBox.Show("Issue create   " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        Next
            '    End If
            'End If


        Next
        If (GACCPOST.ToUpper() = "Y") And gAcPostingWise = "STORE" Then
            Dim sql As String

            Sql = "Select * from AccountstaggingnEW where  CODE='" & Trim(txt_storecode.Text) & "'"
            gconnection.getDataSet(Sql, "CODE")
            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                If accode = "" Then

                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE  " + Trim(txt_storecode.Text) + "")
                    flag = True
                    Return flag

                End If
            Else
                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE " + Trim(txt_storecode.Text) + "")
                flag = True
                Return flag
            End If


            Sql = "Select * from AccountstaggingnEW where  CODE='" & Trim(TXT_FROMSTORECODE.Text) & "'"
            gconnection.getDataSet(Sql, "CODE")
            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                If accode = "" Then

                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE  " + Trim(TXT_FROMSTORECODE.Text) + "")
                    flag = True
                    Return flag

                End If
            Else
                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE " + Trim(TXT_FROMSTORECODE.Text) + "")
                flag = True
                Return flag
            End If
        End If
        If GBATCHNO = "Y" Then
            'Dim ITEMCODE As String
            'For j As Integer = 1 To AxfpSpread1.DataRowCnt
            '    AxfpSpread1.Row = j
            '    AxfpSpread1.Col = 1
            '    ITEMCODE = AxfpSpread1.Text
            '    AxfpSpread1.Col = 5
            '    If AxfpSpread1.Text = "" Then
            '        'AxfpSpread1.Col = 22
            '        Dim sqlstring As String = "SELECT ISNULL(BATCHNO,'') AS BATCHNO FROM INV_InventoryItemMaster WHERE ITEMCODE='" & ITEMCODE & "' AND  ISNULL(VOID,'N') <> 'Y'"
            '        gconnection.getDataSet(sqlstring, "BATCHREQ")
            '        Dim BATCH_REQ As String
            '        BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
            '        If gdataset.Tables("BATCHREQ").Rows.Count > 0 Then
            '            If BATCH_REQ = "YES" Then
            '                MessageBox.Show("Please Enter Batch No. ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        End If
            '    End If
            'Next
        End If
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = TXT_FROMSTORECODE.Text
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 10
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "FROMShelfcheck")
                    If gdataset.Tables("FROMShelfcheck").Rows.Count > 0 Then
                        MessageBox.Show("Please Enter From  Shelf ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If
            Next
        End If
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = txt_storecode.Text
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 11
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "ToShelfcheck")
                    If gdataset.Tables("ToShelfcheck").Rows.Count > 0 Then
                        MessageBox.Show("Please Enter To Shelf ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If
            Next
        End If


        Return False
    End Function

    Private Function validateonupdate() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd"), txt_storecode.Text)
        'Else
        '    checkBdate = gconnection.checkBdate(Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd"))
        'End If

        'Dim checkBdate As Boolean
        checkBdate = gconnection.checkBdate(Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd"), txt_storecode.Text, TXT_FROMSTORECODE.Text)
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
        If DateDiff(DateInterval.Day, (CDate(Dtp_Docdate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("Doc Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If

        If txt_Docno.Text = "" Then
            MessageBox.Show("Please Fill IssueDocno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag


        End If
        If txt_storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_storecode.BackColor = Color.Red
            txt_storecode.Focus()

            flag = True
            Return flag
        Else
            txt_storecode.BackColor = Color.White
        End If
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = i + 1

            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 4
            Dim qty As String = Val(AxfpSpread1.Text)
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim convvalue As Double
            Dim batchno As String
            AxfpSpread1.Col = 6
            batchno = ""
            AxfpSpread1.Col = 3
            uom1 = AxfpSpread1.Text
            Dim sql As String = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  "
            sql = sql & " and Trnno='" + txt_Docno.Text + "' "
            If (batchno <> "") Then
                sql = sql & " and  batchno='" + batchno + "' "
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                sql = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                convvalue = gconnection.getvalue(sql)
            Else
                qty1 = 0
                convvalue = 1

            End If
            sql = "select closingstock +" + Format(Val(-(qty / convvalue) - qty1), "0.000") + " from closingqty where trndate>'" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(-(qty / convvalue) - qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and  itemcode='" + itemcode + "' "
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Updation create " + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If

            If UCase(gShortname) <> "CCL" Then
                sql = "select qty,batchyn,uom,batchno from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'  "
                sql = sql & " and Trnno='" + txt_Docno.Text + "' "
                If (batchno <> "") Then
                    sql = sql & " and  batchno='" + batchno + "' "
                End If

                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                    batchno = gdataset.Tables("closingqty").Rows(0).Item("batchno")
                    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                    sql = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                    convvalue = gconnection.getvalue(sql)

                Else
                    qty1 = 0
                    batchyn = "N"
                    convvalue = 1
                End If
                sql = "select closingstock +" + Format(Val((qty / convvalue) - qty1), "0.000") + " from closingqty where trndate>'" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
                sql = sql & "and closingstock +" + Format(Val((qty / convvalue) - qty1), "0.000") + "<0 and storecode='" + txt_storecode.Text + "'  and itemcode='" + itemcode + "' "
                If batchyn = "Y" Then
                    sql = sql & " and batchno='" + batchno + "'"
                End If
                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    MessageBox.Show("Updation create " + itemcode + " Stock  Negative in " + txt_storecode.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag
                End If
            End If



            'If (Format(CDate(tdate), "yyyy/MM/dd") > Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd")) Then
            '    Dim count As Double = 0

            '    sql = "select * from closingqty where trndate > '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate "

            '    gconnection.getDataSet(sql, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

            '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
            '        count = count - Val(qty - (qty1))
            '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
            '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
            '            If count < 0 Then
            '                MessageBox.Show("Deletion create" + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        Next
            '    End If

            '    sql = "select * from closingqty where trndate > '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'  order by trndate,priority "

            '    gconnection.getDataSet(sql, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

            '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
            '        count = count - Val(-qty + (qty1))
            '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
            '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
            '            If count < 0 Then
            '                MessageBox.Show("Deletion create" + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        Next
            '    End If
            'End If

        Next
        If GBATCHNO = "Y" Then
            'Dim ITEMCODE As String
            'For j As Integer = 1 To AxfpSpread1.DataRowCnt
            '    AxfpSpread1.Row = j
            '    AxfpSpread1.Col = 1
            '    ITEMCODE = AxfpSpread1.Text
            '    AxfpSpread1.Col = 5
            '    If AxfpSpread1.Text = "" Then
            '        'AxfpSpread1.Col = 22
            '        Dim sqlstring As String = "SELECT ISNULL(BATCHNO,'') AS BATCHNO FROM INV_InventoryItemMaster WHERE ITEMCODE='" & ITEMCODE & "' AND  ISNULL(VOID,'N') <> 'Y'"
            '        gconnection.getDataSet(sqlstring, "BATCHREQ")
            '        Dim BATCH_REQ As String
            '        BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
            '        If gdataset.Tables("BATCHREQ").Rows.Count > 0 Then
            '            If BATCH_REQ = "YES" Then
            '                MessageBox.Show("Please Enter Batch No. ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        End If
            '    End If
            'Next
        End If
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = TXT_FROMSTORECODE.Text
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 10
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "FROMShelfcheck")
                    If gdataset.Tables("FROMShelfcheck").Rows.Count > 0 Then
                        MessageBox.Show("Please Enter From  Shelf ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If
            Next
        End If
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = txt_storecode.Text
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 11
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "ToShelfcheck")
                    If gdataset.Tables("ToShelfcheck").Rows.Count > 0 Then
                        MessageBox.Show("Please Enter To Shelf ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If
            Next
        End If
        Return False
    End Function

    Private Function validateonvoid() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        If Mid(UCase(gShortname), 1, 3) = "CCL" Then
            checkBdate = gconnection.checkBdate(Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd"), txt_storecode.Text)
        Else
            checkBdate = gconnection.checkBdate(Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd"))
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
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If

        If txt_Docno.Text = "" Then
            MessageBox.Show("Please Fill IssueDocno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag


        End If
        If txt_storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_storecode.BackColor = Color.Red
            txt_storecode.Focus()

            flag = True
            Return flag
        Else
            txt_storecode.BackColor = Color.White
        End If
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 4
            Dim qty As String = Val(AxfpSpread1.Text)
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim convvalue As Double
            Dim batchno As String
            AxfpSpread1.Col = 3
            uom1 = AxfpSpread1.Text
            Dim sql As String = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  "
            sql = sql & " and Trnno='" + txt_Docno.Text + "' "
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                sql = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                convvalue = gconnection.getvalue(sql)

            Else
                qty1 = 0
                convvalue = 1

            End If
            sql = "select closingstock +" + Format(Val(-qty1), "0.000") + " from closingqty where trndate>'" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(-qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and  itemcode='" + itemcode + "' "
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Deletion create       " + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If

            If UCase(gShortname) <> "CCL" Then

                sql = "select qty,batchyn,uom,batchno from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'  "
                sql = sql & " and Trnno='" + txt_Docno.Text + "' "
                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                    batchno = gdataset.Tables("closingqty").Rows(0).Item("batchno")
                    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                    sql = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                    convvalue = gconnection.getvalue(sql)

                Else
                    qty1 = 0
                    batchyn = "N"
                    convvalue = 1
                End If
                sql = "select closingstock +" + Format(-(qty1), "0.000") + " from closingqty where  itemcode='" + itemcode + "' and trndate>'" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
                sql = sql & "and closingstock +" + Format(Val(-qty1), "0.000") + "<0 and storecode='" + txt_storecode.Text + "'  and itemcode='" + itemcode + "'  "
                If batchyn = "Y" Then
                    sql = sql & " and batchno='" + batchno + "'"
                End If
                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    MessageBox.Show("Deletion create    " + itemcode + " Stock  Negative in " + txt_storecode.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag
                End If
                sqlstring = "Select getdate()"
                tdate = gconnection.getvalue(sqlstring)
                If (Format(CDate(tdate), "yyyy/MM/dd") > Format(CDate(Dtp_Docdate.Value), "yyyy/MM/dd")) Then
                    Dim count As Double = 0

                    'sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate "

                    'gconnection.getDataSet(sql, "closingqty")
                    'If (gdataset.Tables("closingqty").Rows.Count > 0) Then

                    '    count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
                    '    count = count - Val(qty - (qty1))
                    '    For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
                    '        count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
                    '        If count < 0 Then
                    '            MessageBox.Show("Deletion create" + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    '            flag = True
                    '            Return flag
                    '        End If
                    '    Next
                    'End If

                    sql = "select * from closingqty where trndate > '" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'  order by trndate,priority "

                    gconnection.getDataSet(sql, "closingqty")
                    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

                        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
                        count = count - Val(qty1)
                        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
                            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
                            If count < 0 Then
                                MessageBox.Show("Deletion create" + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                flag = True
                                Return flag
                            End If
                        Next
                    End If
                End If
            End If

        Next

        Return False
    End Function


    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            Call autogenerate()
            If validateoninsert() = False Then

                addoperation()

                Dim ITEMCODE, sqlstring As String
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
                sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_storecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "loccode")
                If gdataset.Tables("loccode").Rows.Count > 0 Then
                    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                Else
                    loccode = "M"
                End If
                If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(Dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_storecode.Text), "Q", vOutfile, loccode, txt_Docno.Text, "STOCK TRANSFER")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(Dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_storecode.Text), "Q", vOutfile, loccode, txt_Docno.Text, "STOCK TRANSFER")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If

                sqlstring = " exec proc_closingqtyone 'STOCKTRANSFER_ADD' "
                gconnection.ExcuteStoreProcedure(sqlstring)
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)


                clearoperation()
            End If
        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
            If validateonupdate() = False Then
                updateoperation()
                Dim ITEMCODE, sqlstring As String
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
                sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_storecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "loccode")
                If gdataset.Tables("loccode").Rows.Count > 0 Then
                    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                Else
                    loccode = "M"
                End If
                If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(Dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_storecode.Text), "Q", vOutfile, loccode, txt_Docno.Text, "STOCK TRANSFER")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(Dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_storecode.Text), "Q", vOutfile, loccode, txt_Docno.Text, "STOCK TRANSFER")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)

                End If

                sqlstring = " exec proc_closingqtyone 'STOCKTRANSFER_UPDATE' "
                gconnection.ExcuteStoreProcedure(sqlstring)
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)


                clearoperation()

            End If
        End If
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click

        If MessageBox.Show("Do You Want void it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then
            Exit Sub
        End If

        If Mid(CStr(Cmd_Freeze.Text), 1, 1) = "V" Then
            If validateonvoid() = False Then
                voidoperation()
                Dim ITEMCODE, sqlstring As String
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
                sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_storecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "loccode")
                If gdataset.Tables("loccode").Rows.Count > 0 Then
                    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                Else
                    loccode = "M"
                End If
                If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(Dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_storecode.Text), "Q", vOutfile, loccode, txt_Docno.Text, "STOCK TRANSFER")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(Dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_storecode.Text), "Q", vOutfile, loccode, txt_Docno.Text, "STOCK TRANSFER")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If


                sqlstring = " exec proc_closingqtyone 'STOCKTRANSFER_VOID' "
                gconnection.ExcuteStoreProcedure(sqlstring)

                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)


                clearoperation()

            End If
        End If

    End Sub

    Private Sub cmd_Docnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Docnohelp.Click
        Try
            gSQLString = "SELECT docdetails,docdate FROM stocktransferheader"

            M_WhereCondition = " "
            M_ORDERBY = "ORDER BY docdetails DESC,docno desc"
            Dim vform As New List_Operation
            vform.Field = "DOCDETAILS,DOCDATE"
            vform.vFormatstring1 = "       DOC NO                       |         DOC DATE                                                           "
            vform.vCaption = "STOCK TRANSFER/RETURN NO HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Docno.Text = Trim(vform.keyfield & "")
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Call txt_Docno_Validated(txt_Docno, e)
            End If
            vform.Close()
            vform = Nothing

            sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE BUFFET='YES' AND STORECODE='" & txt_storecode.Text & "'"
            gconnection.getDataSet(sqlstring, "BUFFET")
            If gdataset.Tables("BUFFET").Rows.Count > 0 Then
                Label11.Visible = True
                txt_buffet.Visible = True
                cmd_buffet.Visible = True
                '  cmd_buffet_Click(sender, e)
            Else
                Label11.Visible = False
                txt_buffet.Visible = False
                cmd_buffet.Visible = False
            End If

            sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE Banquet='YES' AND STORECODE='" & txt_storecode.Text & "'"
            gconnection.getDataSet(sqlstring, "Banquet")
            If gdataset.Tables("Banquet").Rows.Count > 0 Then
                Label3.Visible = True
                TXT_PARTYNO.Visible = True
                Button1.Visible = True
                '  Button1_Click(sender, e)
            Else
                Label3.Visible = False
                TXT_PARTYNO.Visible = False
                Button1.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Docno_Validated(sender As Object, e As EventArgs) Handles txt_Docno.Validated
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, STRITEMCODE, STRITEMUOM, remarks As String
        Dim vTypeseqno, vGroupseqno, Clsquantity As Double
        Dim varqty As Double
        Me.txt_Totalqty.Text = 0
        varqty = 0
        If Trim(txt_Docno.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,ISNULL(H.TRANSFERNO,'') AS TRANSFERNO,"
                sqlstring = sqlstring & " ISNULL(H.FROMSTORECODE,'') AS FROMSTORECODE,ISNULL(H.FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(H.TOSTORECODE,'') AS TOSTORECODE,"
                sqlstring = sqlstring & " ISNULL(H.TOSTOREDESC,'') AS TOSTOREDESC,"
                sqlstring = sqlstring & " ISNULL(H.REMARKS,'') AS REMARKS,ISNULL(H.VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,ISNULL(H.partybookingno,'') AS partybookingno,ISNULL(H.BUFFETMENU,'') AS BUFFETMENU"
                sqlstring = sqlstring & "  FROM STOCKTRANSFERHEADER AS H WHERE DOCNO='" & Trim(txt_Docno.Text) & "'OR DOCDETAILS='" & Trim(txt_Docno.Text) & "'"
                gconnection.getDataSet(sqlstring, "stocktransferheader")
                '''************************************************* SELECT RECORD FROM STOCKTRANSFERHEADER *********************************************''''                
                If gdataset.Tables("stocktransferheader").Rows.Count > 0 Then
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Docno.ReadOnly = True
                    txt_Docno.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("DOCDETAILS"))
                    Dtp_Docdate.Value = Format(CDate(gdataset.Tables("stocktransferheader").Rows(0).Item("DOCDATE")), "dd/MMM/yyyy")
                    TXT_PARTYNO.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("partybookingno"))
                    txt_buffet.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("BUFFETMENU"))
                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("FROMSTORECODE"))
                    ' cbo_Fromstore.DropDownStyle = ComboBoxStyle.DropDown
                    ' cbo_Fromstore.Enabled = False
                    txt_FromStorename.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("FROMSTOREDESC"))
                    'txt_FromStorename.DropDownStyle = ComboBoxStyle.DropDownList
                    txt_storecode.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("TOSTORECODE"))
                    ' cbo_Tostore.DropDownStyle = ComboBoxStyle.DropDown
                    ' cbo_Tostore.Enabled = False
                    txt_storeDesc.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("TOSTOREDESC"))
                    ' cbo_Tostore.DropDownStyle = ComboBoxStyle.DropDownList
                    remarks = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("REMARKS"))
                    txt_Remarks.Text = Replace(remarks, "?", "'")
                    ''''********************************* 
                    sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(txt_storecode.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                    gconnection.getDataSet(sqlstring, "STOREMASTER1")
                    If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                        doctype1 = ""
                        If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
                            doctype1 = "RET"
                            lbl_Heading.Text = "STOCK RETURN"
                        Else
                            doctype1 = "TRF"
                            lbl_Heading.Text = "STOCK TRANSFER"
                        End If
                    End If
                    If Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("VOID") & "") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("stocktransferheader").Rows(0).Item("adddate")), "dd/MMM/yyyy")
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Freeze.Enabled = False
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.Cmd_Freeze.Enabled = True
                        Me.lbl_Freeze.Text = "Record Void  On "
                        Me.Cmd_Freeze.Text = "Void[F8]"
                        Me.Cmd_Add.Enabled = True
                        Me.Cmd_Freeze.Enabled = True
                    End If
                    '''************************************************* SELECT RECORD FROM STOCKTRANSFERDETAISL *********************************************''''                
                    sqlstring = "SELECT ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,D.DOCDATE AS DOCDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE, "
                    If GSHELVING = "Y" Then
                        sqlstring = sqlstring & "FROMSHELF,TOSHELF,"
                    End If
                    sqlstring = sqlstring & " ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM,ISNULL(QTY,0) AS QTY,ISNULL(BATCHNO,'') AS BATCHNO,ISNULL(CLOSINGQTY,0) AS CLOSINGQTY,isnull(rate,0) as rate,isnull(amount,0) as amount,ISNULL(D.void,'N') AS void "
                    sqlstring = sqlstring & " FROM STOCKTRANSFERDETAIL AS D WHERE  DOCDETAILS ='" & Trim(txt_Docno.Text) & "' "
                    gconnection.getDataSet(sqlstring, "stocktransferdetail")
                    If gdataset.Tables("stocktransferdetail").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("stocktransferdetail").Rows.Count
                            'Call GridUOM(i) '''--> Fill UOM in ssgrid
                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMCODE")))
                            AxfpSpread1.Col = 1
                            AxfpSpread1.Lock = True
                            STRITEMCODE = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMNAME")))
                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = i
                            Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("stocktransferdetail").Rows(j).Item("itemcode") + "'"

                            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z


                            AxfpSpread1.Text = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("UOM"))
                            'ssgrid.Text = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("UOM"))
                            STRITEMUOM = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("UOM"))
                            AxfpSpread1.SetText(4, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("QTY")), "0.000"))
                            AxfpSpread1.SetText(5, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("BATCHNO")))
                            AxfpSpread1.SetText(6, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("CLOSINGQTY")), "0.000"))
                            AxfpSpread1.SetText(7, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("rate")), "0.000"))
                            AxfpSpread1.SetText(8, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("amount")), "0.000"))
                            If GSHELVING = "Y" Then
                                AxfpSpread1.Col = 10
                                AxfpSpread1.Row = i
                                AxfpSpread1.SetText(10, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("FROMSHELF")))
                                AxfpSpread1.Col = 11
                                AxfpSpread1.Row = i
                                AxfpSpread1.SetText(11, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("TOSHELF")))

                            End If

                            AxfpSpread1.Col = 9
                            AxfpSpread1.Row = i
                            AxfpSpread1.SetText(9, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("void")))
                            'ssgrid.SetText(12, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("QTY")), "0.000"))
                            '  AxfpSpread1.SetText(5, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("RATE")), "0.000"))
                            '   AxfpSpread1.SetText(6, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("AMOUNT")), "0.000"))
                            'ssgrid.SetText(7, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("DBLAMT")), "0.000"))
                            ' ssgrid.SetText(8, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("DBLCONV")) & "")
                            '  ssgrid.SetText(9, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("HIGHRATIO")), "0.000"))
                            '  AxfpSpread1.SetText(7, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("GROUPCODE")))
                            '  AxfpSpread1.SetText(8, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("SUBGROUPCODE")))

                            'Dim TRFDATE As Date
                            'TRFDATE = Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy")

                            'Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(Dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMCODE") & "' ,'" & Trim(TXT_FROMSTORECODE.Text) & "','" & gdataset.Tables("stocktransferdetail").Rows(j).Item("UOM") & "')"
                            'Dim cls As Double = gconnection.getvalue(SQL)
                            'AxfpSpread1.SetText(9, i, Format(Val(cls), "0.000"))

                            '                            Clsquantity = ClosingQuantity_Date(STRITEMCODE, Trim(TXT_FROMSTORECODE.Text), STRITEMUOM, TRFDATE)

                            'Clsquantity = ClosingQuantity(STRITEMCODE, Trim(txt_fromstorecode.Text))
                            '   ssgrid.SetText(13, i, Clsquantity)
                            varqty = varqty + Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("QTY")), "0.000")
                            j = j + 1
                        Next
                        Me.txt_Totalqty.Text = Format(varqty, "0.000")
                    End If
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    ' TotalCount = gdataset.Tables("stocktransferdetail").Rows.Count
                    ' AxfpSpread1.SetActiveCell(1, 1)
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub cmd_buffet_Click(sender As Object, e As EventArgs) Handles cmd_buffet.Click
        Try

            gSQLString = "SELECT  ITEMCODE,ItemDesc,GROUPCODEDEC,BaseUOMstd FROM BUFFET_MENU  "
            Dim vform As New List_Operation
            M_ORDERBY = "order by ItemDesc desc"

            vform.Field = "ITEMCODE,ItemDesc,GROUPCODEDEC,BaseUOMstd"
            vform.vFormatstring1 = "       ITEMCODE                    |     ItemDesc                                             |     GROUPCODEDEC                  |      BaseUOMstd               "
            vform.vCaption = "BUFFET MENU HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_buffet.Text = Trim(vform.keyfield & "")
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            gSQLString = "SELECT BOOKINGNO,PARTYDATE,GUESTNAME FROM BANQUET_BOOKINGNO  "
            M_WhereCondition = " WHERE ISNULL(FREEZE,'N')<>'Y'  AND cast( PARTYDATE as Date)= Cast('" & Format(CDate(Dtp_Docdate.Value), "dd MMM yyyy") & "' as Date) "
            Dim vform As New List_Operation
            M_ORDERBY = "order by BOOKINGNO desc"

            vform.Field = "BOOKINGNO,PARTYDATE,GUESTNAME"
            vform.vFormatstring1 = "       BOOKINGNO                    |     PARTYDATE                                             |     GUESTNAME              "
            vform.vCaption = "PARTY BOOKING HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXT_PARTYNO.Text = Trim(vform.keyfield & "")
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Try

            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Crystktrf
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(fromSTORECODE,'') AS fromSTORECODE,"
            sqlstring = sqlstring & " ISNULL(fromSTOREDESC,'') AS fromSTOREDESC , isnull(tostorecode,'') as tostorecode,isnull(tostoredesc,'') as tostoredesc,"
            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(qty,0) AS qty,ISNULL(rate,0) AS rate,ISNULL(Amount,0) AS Amount,ISNULL(BAtCHNO,'') AS BAtCHNO ,ISNULL(ADDDATEtime,'') AS ADDDATEtime "
            sqlstring = sqlstring & " FROM STOCKTRANSFERDETAIL"
            sqlstring = sqlstring & " WHERE DOCDETAILS ='" & Trim(txt_Docno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"

            gconnection.getDataSet(sqlstring, "VW_INV_STKDMGBILL")
            If gdataset.Tables("VW_INV_STKDMGBILL").Rows.Count > 0 Then
                'If chk_excel.Checked = True Then
                '    Dim exp As New exportexcel
                '    exp.Show()
                '    Call exp.export(sqlstring, "STOCK DAMAGE ", "")
                'Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_INV_STKDMGBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                Dim textobj11 As TextObject
                textobj11 = r.ReportDefinition.ReportObjects("Text15")
                textobj11.Text = UCase(gCompanyAddress(0))
                Dim textobj12 As TextObject
                textobj12 = r.ReportDefinition.ReportObjects("Text16")
                textobj12.Text = UCase(gCompanyAddress(1))
                Dim textobj23 As TextObject
                textobj23 = r.ReportDefinition.ReportObjects("Text3")
                textobj23.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text18")
                textobj2.Text = gUsername
                ' rViewer.PictureBox1.Image


                If UCase(gShortname) = "TMA" Then
                    Dim textobj22 As TextObject
                    textobj22 = r.ReportDefinition.ReportObjects("TEXT22")
                    textobj22.Text = "  Store Keeper:                                                                                             Manager: "

                End If

                rViewer.Show()
                '   End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub cmd_Print_Click(sender As Object, e As EventArgs) Handles cmd_Print.Click
        Try

            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Crystktrf
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(fromSTORECODE,'') AS fromSTORECODE,"
            sqlstring = sqlstring & " ISNULL(fromSTOREDESC,'') AS fromSTOREDESC , isnull(tostorecode,'') as tostorecode,isnull(tostoredesc,'') as tostoredesc,"
            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(qty,0) AS qty,ISNULL(BAtCHNO,'') AS BAtCHNO,ISNULL(ADDDATEtime,'') AS ADDDATEtime "
            sqlstring = sqlstring & " FROM STOCKTRANSFERDETAIL"
            sqlstring = sqlstring & " WHERE DOCDETAILS ='" & Trim(txt_Docno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"

            gconnection.getDataSet(sqlstring, "VW_INV_STKDMGBILL")
            If gdataset.Tables("VW_INV_STKDMGBILL").Rows.Count > 0 Then
                'If chk_excel.Checked = True Then
                '    Dim exp As New exportexcel
                '    exp.Show()
                '    Call exp.export(sqlstring, "STOCK DAMAGE ", "")
                'Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_INV_STKDMGBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                Dim textobj11 As TextObject
                textobj11 = r.ReportDefinition.ReportObjects("Text15")
                textobj11.Text = UCase(gCompanyAddress(0))
                Dim textobj12 As TextObject
                textobj12 = r.ReportDefinition.ReportObjects("Text16")
                textobj12.Text = UCase(gCompanyAddress(1))
                Dim textobj23 As TextObject
                textobj23 = r.ReportDefinition.ReportObjects("Text3")
                textobj23.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text18")
                textobj2.Text = gUsername

                If UCase(gShortname) = "MGC" Then
                    Dim textobj20 As TextObject
                    textobj20 = r.ReportDefinition.ReportObjects("Text20")
                    textobj20.Text = "STORE KEEPER NAME : "
                Else
                    Dim textobj22 As TextObject
                    textobj22 = r.ReportDefinition.ReportObjects("Text22")
                    textobj22.Text = ""

                End If

                rViewer.Show()
                '   End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub AxfpSpread1_LeaveCell(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread1.LeaveCell
        If AxfpSpread1.ActiveCol = 3 Then

            AxfpSpread1.Col = 1
            Dim ITEMCODE As String = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            Dim UOM As String = AxfpSpread1.Text
            Dim UOM1, sql11 As String
            ' Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(Dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


            '  gconnection.getDataSet(sql11, "closingtable")
            Dim closingqty As Double
            gconnection.closingStock(Format(Dtp_Docdate.Value, "dd/MMM/yyyy"), ITEMCODE, Trim(TXT_FROMSTORECODE.Text), "")
            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")

            Else
                closingqty = 0
            End If
            uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
            sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
            gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
            Dim convvalue As Double
            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

            Else
                convvalue = 1
            End If
            closingqty = closingqty * convvalue

            AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))

        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub lbl_Tostore_Click(sender As Object, e As EventArgs) Handles lbl_Tostore.Click
        

    End Sub

    Private Sub AxfpSpread1_Advance(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread1.Advance

    End Sub

    Private Sub lbl_Freeze_Click(sender As Object, e As EventArgs) Handles lbl_Freeze.Click

    End Sub
End Class