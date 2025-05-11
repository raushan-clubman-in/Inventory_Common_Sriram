Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Threading
Imports CrystalDecisions.Shared
Imports System.Net.Mail
Public Class Frm_STOCKINDENT
    Dim gconnection As New GlobalClass
    Dim sql As String
    Dim GrnQuery(0) As String
    Dim docno As String
    Dim costcenterflag As Boolean = False
    Dim STORESTATUS As String

    Private Sub Frm_STOCKINDENT_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.KeyCode = Keys.F9 And cmd_View.Visible = True Then
                Call cmd_View_Click(cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F10 Then
                Call Button1_Click(Button1, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Then
                Call cmd_Exit_Click(cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.Escape Then
                Call cmd_Exit_Click(cmd_Exit, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub
    Private Sub autogenerate()

        Dim store As Integer
        Try
            If (TXT_FROMSTORECODE.Text <> "" Or txt_storecode.Text <> "") And Mid(Cmd_Add.Text, 1, 1) = "A" And (UCase(gShortname) <> "NIZAM") Then

                If UCase(gShortname) <> "MLA" Then

                    If UCase(gShortname) <> "FMC" Then
                        Dim sqlstring, financalyear As String
                        gcommand = New SqlCommand
                        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
                        'docno = "IND"
                        If UCase(gShortname) = "CATH" Then
                            If txt_storecode.Text <> "" Then
                                docno = Mid(txt_storecode.Text, 1, 3)
                            Else
                                Exit Sub
                            End If
                        Else
                            If TXT_FROMSTORECODE.Text <> "" Then
                                docno = Mid(TXT_FROMSTORECODE.Text, 1, 3)
                            Else
                                Exit Sub
                            End If
                        End If
                        If Mid(UCase(gShortname), 1, 3) = "FMC" Then
                            sqlstring = "SELECT MAX(DOCNO) FROM INVENTORY_INDENTHDR  "
                        Else

                            If Len(Trim(docno)) = 2 Then

                                'store = 2

                                sqlstring = "SELECT MAX(SUBSTRING(DOCNO,5,4)) FROM INVENTORY_INDENTHDR WHERE SUBSTRING(indent_no,1,2)='" & docno & "' "
                            Else

                                'store = 3

                                sqlstring = "SELECT MAX(SUBSTRING(DOCNO,5,5)) FROM INVENTORY_INDENTHDR WHERE SUBSTRING(indent_no,1,3)='" & docno & "' "
                            End If





                        End If

                        ' WHERE storelocationcode ='" & docno & "'"
                        gconnection.openConnection()
                        gcommand.CommandText = sqlstring
                        gcommand.CommandType = CommandType.Text
                        gcommand.Connection = gconnection.Myconn
                        gdreader = gcommand.ExecuteReader
                        If gdreader.Read Then
                            If gdreader(0) Is System.DBNull.Value Then
                                txt_IndentNo.Text = docno & "/00001/" & financalyear
                                gdreader.Close()
                                gcommand.Dispose()
                                gconnection.closeConnection()
                            Else
                                txt_IndentNo.Text = docno & "/" & Format(gdreader(0) + 1, "00000") & "/" & financalyear
                                gdreader.Close()
                                gcommand.Dispose()
                                gconnection.closeConnection()
                            End If
                        Else
                            txt_IndentNo.Text = docno & "/00001/" & financalyear
                            gdreader.Close()
                            gcommand.Dispose()
                            gconnection.closeConnection()
                        End If
                    End If
                End If





            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub Frm_STOCKINDENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.cmd_Exit.Visible = True
            End If
        End If
        ' Resize_Form()

        'Me.DoubleBuffered = True
        If UCase(gShortname) <> "HGA" And UCase(gShortname) <> "KGA" And UCase(gShortname) <> "CSC" Then
            autogenerate()
        End If

        txt_storecode.Focus()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If

        lbl_closingqty.Visible = True
        lbl_closingqty.ForeColor = Color.Red
        lbl_closingqty.Text = ""
        Call Clearoperation()
        dtp_Indentdate.Focus()
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
                        If Controls(i_i).Name = "GroupBox3" Then
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

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "Stock Indent"

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


    Private Sub binditemcode()
        Dim vform As New ListOperattion1

        gSQLString = "select I.itemcode,Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (Select categorycode from Categoryuserdetail where usercode='" & gUsername & "')  and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_storecode.Text + "'"
        vform.Field = " I.itemcode,Itemname ,I.uom"
        vform.vFormatstring = "    Itemcode    |         Itemname                                        |  UOM        "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2

        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            AxfpSpread1.Col = 1
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield)
            AxfpSpread1.Col = 2
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield1)
            AxfpSpread1.Col = 3
            Dim uom1 As String
            AxfpSpread1.Row = AxfpSpread1.ActiveRow


            If Mid(UCase(gShortname), 1, 3) = "SAT" Then

                Dim sql As String = "select DISTINCT tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    'AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(vform.keyfield2)
                Next Z
            Else
                Dim sql As String = "select DISTINCT tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                Next Z
            End If

            If UCase(gShortname) = "SKYYE" Or UCase(gShortname) = "CFC" Or UCase(gShortname) = "HBC" Then
                Dim sql1 As String = "select ISNULL(DEFAULTUOM,'')AS DEFAULTUOM from inv_inventoryitemmaster where itemcode='" + vform.keyfield + "'"
                gconnection.getDataSet(sql1, "DEFAULTUOM")
                AxfpSpread1.Text = gdataset.Tables("DEFAULTUOM").Rows(0).Item("DEFAULTUOM")
            End If


            If (check_Duplicate(vform.keyfield) = False) Then

                AxfpSpread1.Col = 1
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.Col = 2
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield1)
                'AxfpSpread1.Col = 3
                'AxfpSpread1.Row = AxfpSpread1.ActiveRow

                'sql = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

                'gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                'For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                '    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                '    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                '    AxfpSpread1.Col = 18
                '    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                '    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                '    AxfpSpread1.Col = 3
                '    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                'Next Z
                ''''''''''''''''''''''''''''''''



                'AxfpSpread1.Text = Trim(vform.keyfield2)

                AxfpSpread1.Col = 5

                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Col = 3
                Dim uom As String = AxfpSpread1.Text


                gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), vform.keyfield, Trim(TXT_FROMSTORECODE.Text), "")
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Format(gdataset.Tables("closingstock").Rows(0).Item("closingstock"), "0.000")

                    'closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
                End If

                Dim closingqty, RATE As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    RATE = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                Else
                    closingqty = 0
                    RATE = 0
                End If
                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")

                If gShortname <> "SKYYE" Or gShortname <> "CFC" Or UCase(gShortname) <> "HBC" Then
                    sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                    gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                    Dim convvalue1 As Double
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                    Else
                        MessageBox.Show("Please Create relation Between " + uom1 + " and " + uom)
                        Exit Sub
                    End If

                    closingqty = Format(closingqty * convvalue1, "0.000")

                    AxfpSpread1.Col = 7
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(RATE / convvalue1)
                Else
                    sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                    gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                    Dim convvalue1 As Double
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                    Else
                        MessageBox.Show("Please Create relation Between " + uom + " and " + uom1)
                        Exit Sub
                    End If

                    closingqty = Format(closingqty / convvalue1, "0.000")
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = closingqty

                    AxfpSpread1.Col = 7
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(RATE * convvalue1)


                End If

                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            End If
        End If
    End Sub

    Private Function check_Duplicate(ByVal Itemcode As String) As Boolean
        Dim i As Integer

        Dim uom As String
        AxfpSpread1.Col = 3
        uom = AxfpSpread1.Text

        AxfpSpread1.Col = 1
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            If i <> AxfpSpread1.ActiveRow Then
                If Trim(AxfpSpread1.Text) = Trim(Itemcode) Then
                    sql = "SELECT * FROM uommaster WHERE uomcode='" + uom + "' AND ISNULL(isweight,'NO')='YES'"
                    gconnection.getDataSet(sql, "WM")
                    If (gdataset.Tables("WM").Rows.Count > 0) Then
                        Return False
                    Else
                        MsgBox("Item Already exists", MsgBoxStyle.Critical, "Duplicate")
                        AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)

                        Return True
                    End If
                    End If
            End If
        Next
        Return False
    End Function
    Private Sub binditemname()
        Dim vform As New ListOperattion1


        gSQLString = "select I.itemcode,m.Itemname,uom ,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (Select categorycode from Categoryuserdetail where usercode='" & gUsername & "')  and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_storecode.Text + "'"
        vform.Field = " I.itemcode, M.Itemname,I.Uom"
        vform.vFormatstring = "    itemcode    |     Itemname                             |       UOM     "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        'vform.KeyPos1 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then

            AxfpSpread1.Col = 1
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield)
            AxfpSpread1.Col = 2
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield1)
            AxfpSpread1.Col = 3
            AxfpSpread1.Row = AxfpSpread1.ActiveRow

            Dim sql As String = "select DISTINCT tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
            Next Z

            If UCase(gShortname) = "SKYYE" Or UCase(gShortname) = "CFC" Or UCase(gShortname) = "HBC" Then
                Dim sql1 As String = "select ISNULL(DEFAULTUOM,'')AS DEFAULTUOM from inv_inventoryitemmaster where itemcode='" + vform.keyfield + "'"
                gconnection.getDataSet(sql1, "DEFAULTUOM")
                AxfpSpread1.Text = gdataset.Tables("DEFAULTUOM").Rows(0).Item("DEFAULTUOM")
            End If


            'AxfpSpread1.Text = Trim(vform.keyfield2)
            AxfpSpread1.Col = 5
            AxfpSpread1.Row = AxfpSpread1.ActiveRow

            '  sql = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue from closingqty where itemcode='" + vform.keyfield + "' AND  storecode='" + TXT_FROMSTORECODE.Text + "'and  CONVERT(VARCHAR(11), Trndate, 106)<='" + Format(CDate(dtp_Indentdate.Value), "dd MMM yyyy") + "' order by trndate desc,AUTOID desc"
            ' sql = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid from closingqty where itemcode='" + vform.keyfield + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and trndate<='" + Format(CDate(dtp_Indentdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
            gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), vform.keyfield, Trim(TXT_FROMSTORECODE.Text), "")
            'gconnection.getDataSet(sql, "closingstock")
            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                AxfpSpread1.Col = 5
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Format(gdataset.Tables("closingstock").Rows(0).Item("closingstock"), "0.00")

                'closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
            End If
            'skyye

            If gShortname = "SKYYE" Or gShortname = "CFC" Or UCase(gShortname) = "HBC" Then
                AxfpSpread1.Col = 3
                Dim uom As String = AxfpSpread1.Text
                Dim closingqty, RATE As Double
                Dim uom1 As String
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    RATE = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                Else
                    closingqty = 0
                    RATE = 0
                End If
                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")

                sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                Dim convvalue1 As Double
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    MessageBox.Show("Please Create relation Between " + uom + " and " + uom1)
                    Exit Sub
                End If

                closingqty = Format(closingqty / convvalue1, "0.000")
                AxfpSpread1.Col = 5
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = closingqty

                AxfpSpread1.Col = 7
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(RATE * convvalue1)
            End If




            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
        End If

    End Sub


    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String
        Dim itemcode As String
        If e.keyCode = Keys.Enter Then



            i = AxfpSpread1.ActiveRow
            'ITEMCODE

            If AxfpSpread1.ActiveCol = 1 Then
                AxfpSpread1.Col = 1
                AxfpSpread1.Row = i
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemcode()
                Else
                    SQL = " select M.itemcode,Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category in (Select categorycode from Categoryuserdetail where usercode='" & gUsername & "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")

                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then
                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            itemcode = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode"))
                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            Dim sql1 As String = "select DISTINCT tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z


                            AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            'ADDED BY SRIRAM FOR FIXED UOM 
                            If UCase(gShortname) = "SKYYE" Or UCase(gShortname) = "CFC" Or UCase(gShortname) = "HBC" Then
                                Dim sql2 As String = "select ISNULL(DEFAULTUOM,'')AS DEFAULTUOM from inv_inventoryitemmaster where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                gconnection.getDataSet(sql2, "DEFAULTUOM")
                                AxfpSpread1.Text = gdataset.Tables("DEFAULTUOM").Rows(0).Item("DEFAULTUOM")
                            End If


                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)

                            AxfpSpread1.Col = 5
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            'SQL = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue from closingqty where itemcode='" + itemcode + "' AND  storecode='" + TXT_FROMSTORECODE.Text + "'and  CONVERT(VARCHAR(11), Trndate, 106)<='" + Format(CDate(dtp_Indentdate.Value), "dd MMM yyyy") + "' order by trndate desc,AUTOID desc"
                            'gconnection.getDataSet(SQL, "closingqty")
                            'SQL = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid from closingqty where itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and trndate<='" + Format(CDate(dtp_Indentdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
                            'gconnection.getDataSet(SQL, "closingqty")

                            gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                AxfpSpread1.Col = 5
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = Format(gdataset.Tables("closingstock").Rows(0).Item("closingstock"), "0.000")

                                'closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
                            End If
                        Else
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                        End If
                End If
            End If

                AxfpSpread1.Col = 3
                Dim uom As String = AxfpSpread1.Text
                Dim uom1 As String
                AxfpSpread1.Col = 1

                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                Dim sql11 As String ' = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + AxfpSpread1.Text + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                ' gconnection.getDataSet(sql11, "closingtable")

                gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), AxfpSpread1.Text, Trim(TXT_FROMSTORECODE.Text), "")

                Dim closingqty, RATE As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    RATE = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                    uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                Else
                    closingqty = 0
                    RATE = 0
                    uom1 = uom
                End If
                If gShortname <> "SKYYE" Or gShortname <> "CFC" Or UCase(gShortname) <> "HBC" Then
                    SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                    gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                    Dim convvalue1 As Double
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    Else
                        MessageBox.Show("Please Create relation Between " + uom1 + " and " + uom)
                        Exit Sub
                    End If
                    closingqty = Format(closingqty * convvalue1, "0.000")
                    AxfpSpread1.Col = 7
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(RATE / convvalue1)
                    AxfpSpread1.Col = 1
                    lbl_closingqty.Text = "" + AxfpSpread1.Text + " has closing qty is " + closingqty.ToString() + "  " + uom1
                Else
                    SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                    gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                    Dim convvalue1 As Double
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                    Else
                        MessageBox.Show("Please Create relation Between " + uom + " and " + uom1)
                        Exit Sub
                    End If

                    closingqty = Format(closingqty / convvalue1, "0.000")


                    'AxfpSpread1.Col = 7
                    'AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    'AxfpSpread1.Text = Trim(RATE * convvalue1)
                    'AxfpSpread1.Col = 5
                    'AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    'AxfpSpread1.Text = closingqty

                    AxfpSpread1.Col = 7
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(RATE * convvalue1)

                    AxfpSpread1.Col = 1
                    lbl_closingqty.Text = "" + AxfpSpread1.Text + " has closing qty is " + closingqty.ToString() + "  " + uom

                End If


                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 2 Then
                AxfpSpread1.Col = 2
                AxfpSpread1.Row = i
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemname()
                Else

                    SQL = " select M.itemcode,Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category in (Select categorycode from Categoryuserdetail where usercode='" & gUsername & "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_storecode.Text + "' and isnull(M.itemname,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                        AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                        itemcode = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode"))
                        Dim sql1 As String = "select DISTINCT tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                        AxfpSpread1.Col = 3
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                        Next Z


                        AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))

                        If UCase(gShortname) = "SKYYE" Or UCase(gShortname) = "CFC" Or UCase(gShortname) = "HBC" Then
                            Dim sql2 As String = "select ISNULL(DEFAULTUOM,'')AS DEFAULTUOM from inv_inventoryitemmaster where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                            gconnection.getDataSet(sql2, "DEFAULTUOM")
                            AxfpSpread1.Text = gdataset.Tables("DEFAULTUOM").Rows(0).Item("DEFAULTUOM")
                        End If

                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow


                        '  SQL = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue from closingqty where itemcode='" + itemcode + "' AND  storecode='" + TXT_FROMSTORECODE.Text + "'and  CONVERT(VARCHAR(11), Trndate, 106)<='" + Format(CDate(dtp_Indentdate.Value), "dd MMM yyyy") + "' order by trns_seq desc,AUTOID desc"
                        '  SQL = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid from closingqty where itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and trndate<='" + Format(CDate(dtp_Indentdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"

                        'gconnection.getDataSet(SQL, "closingqty")
                        gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                            AxfpSpread1.Col = 5
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = Format(gdataset.Tables("closingstock").Rows(0).Item("closingstock"), "0.00")

                            'closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
                        End If
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 4 Then
                AxfpSpread1.Col = 4
                AxfpSpread1.Row = i

                If Val(AxfpSpread1.Text) = 0 Then
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                Else
                    Dim issuedqty As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 7
                    Dim RATE As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 8
                    AxfpSpread1.Text = issuedqty * RATE
                    AxfpSpread1.Col = 1
                    itemcode = AxfpSpread1.Text
                    If UCase(gShortname) = "BRC" Then
                        AxfpSpread1.Col = 5
                        Dim clqty As Double = Val(AxfpSpread1.Text)
                        AxfpSpread1.Col = 4
                        If clqty < Val(AxfpSpread1.Text) Then
                            AxfpSpread1.Text = clqty
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                        End If
                    ElseIf UCase(gShortname) = "RCL" Or UCase(gShortname) = "HIND" Then

                        AxfpSpread1.Col = 5
                        Dim clqty As Double = Val(AxfpSpread1.Text)
                        AxfpSpread1.Col = 4
                        If clqty < Val(AxfpSpread1.Text) Then
                            MessageBox.Show(itemcode + " has closing qty is " + clqty.ToString() + " in " & TXT_FROMSTORECODE.Text.ToUpper(), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            AxfpSpread1.Text = clqty
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                        End If
                    ElseIf UCase(gShortname) = "KGA" Or UCase(gShortname) = "SKYYE"  Then
                        AxfpSpread1.Col = 5
                        Dim clqty As Double = Val(AxfpSpread1.Text)
                        AxfpSpread1.Col = 4
                        If clqty < Val(AxfpSpread1.Text) Then
                            MessageBox.Show(itemcode + " has closing qty is " + clqty.ToString() + " in " & TXT_FROMSTORECODE.Text.ToUpper(), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            AxfpSpread1.Text = clqty
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                        End If
                    Else
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    End If

                    AxfpSpread1.Col = 4

                    check_MinMaxQTY("X", Trim(txt_storecode.Text), itemcode, Val(AxfpSpread1.Text))

                    check_MinMaxQTY("N", Trim(TXT_FROMSTORECODE.Text), itemcode, Val(AxfpSpread1.Text))

                End If


                Calculate()
            End If
        ElseIf (e.keyCode = Keys.F3) Then
            If UCase(gShortname) = "BRC" Then
                'If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
            ElseIf UCase(gShortname) = "SATC" Or gShortname = "SKYYE" Then
                'If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            ElseIf Mid(UCase(Trim(gCompanyname)), 1, 7) = "THE NIZ" Or Mid(UCase(Trim(gShortname)), 1, 3) = "NIZ" Then
                'If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                'End If
            Else
                If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                    AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)

                Else
                    i = AxfpSpread1.ActiveRow
                    AxfpSpread1.Col = 1
                    AxfpSpread1.Row = i

                    gconnection.getDataSet("SELECT * FROM  INVENTORY_INDENTDET WHERE ITEMCODE='" & Trim(AxfpSpread1.Text) & "' AND INDENT_NO='" & txt_IndentNo.Text & "'", "storemaster")
                    If gdataset.Tables("storemaster").Rows.Count > 0 Then
                        AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)

                    Else
                        AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                    End If

                End If
            End If



        End If

    End Sub

    Private Sub cmd_storecode_Click(sender As Object, e As EventArgs) Handles cmd_storecode.Click
        gSQLString = "Select storecode,storedesc,ctype,STORESTATUS from Vw_Store_Costcenter"
        'gSQLString = "SELECT DISTINCT(storecode),storedesc,'S' FROM STOREMASTER   "
        'gSQLString = gSQLString + " Union select distinct(Costcentercode),costcenterdesc,'C' from ACCOUNTSCOSTCENTERMASTER "
        M_WhereCondition = " where  STORESTATUS<>'M' "
        M_ORDERBY = ""
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "DEPARTMENT MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_storecode.Text = Trim(vform.keyfield & "")
            txt_storeDesc.Text = Trim(vform.keyfield1 & "")

            If UCase(gShortname) <> "HGA" And UCase(gShortname) <> "KGA" And UCase(gShortname) <> "CSC" Then
                Call autogenerate()
            End If



            If (vform.keyfield2 = "C") Then
                costcenterflag = True
            Else
                costcenterflag = False
            End If
            STORESTATUS = vform.keyfield3
        End If

        vform.Close()
        vform = Nothing
    End Sub



    Private Sub cmd_fromStorecodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_fromStorecodeHelp.Click
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "

        If costcenterflag = True Then
            M_WhereCondition = " where freeze <> 'Y' "

        Else
            M_WhereCondition = " where freeze <> 'Y' and STORESTATUS='M'"

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
            If UCase(gShortname) <> "HGA" And UCase(gShortname) <> "KGA" And UCase(gShortname) <> "CSC" Then
                autogenerate()
            End If



        Else
            Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub TXT_FROMSTORECODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_FROMSTORECODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_FROMSTORECODE.Text) = "" Then
                Call cmd_fromStorecodeHelp_Click(TXT_FROMSTORECODE.Text, e)
            Else
                Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
            End If
        End If
    End Sub

    Private Sub TXT_FROMSTORECODE_Validated(sender As Object, e As EventArgs) Handles TXT_FROMSTORECODE.Validated
        If Trim(TXT_FROMSTORECODE.Text) <> "" Then


            sql = "SELECT * FROM storemaster WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(Freeze,'') <> 'Y'"
            If (costcenterflag = False) Then

                sql = sql & " and STORESTATUS='M'"

            End If
            gconnection.getDataSet(sql, "storemaster")
            If gdataset.Tables("storemaster").Rows.Count > 0 Then
                TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                txt_FromStorename.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                AxfpSpread1.Focus()
                AxfpSpread1.SetActiveCell(1, 1)
            Else
                TXT_FROMSTORECODE.Text = ""
                TXT_FROMSTORECODE.Focus()
            End If
            If UCase(gShortname) <> "HGA" And UCase(gShortname) <> "KGA" And UCase(gShortname) <> "CSC" Then
                Call autogenerate()

            End If
        End If
    End Sub

    Private Sub addoperation()
        Dim Insert(0) As String
        Dim itemcode As String
        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            If UCase(gShortname) <> "HGA" And UCase(gShortname) <> "KGA" And UCase(gShortname) <> "CSC" Then
                If UCase(gShortname) <> "FMC" Then
                    Call autogenerate()
                End If

            End If

        End If

        sql = "INSERT INTO INVENTORY_INDENTHDR(DOCNO,INDENT_NO,INDENT_DATE,fromStoreCode,Storelocationcode,Storelocationname, "
        sql = sql & " Remarks,Void,Adduser,Adddatetime)"
        'If GINDENTNO = "Y" Then
        '    docno1 = Split(Trim(txt_IndentNo.Text), "/")
        '    sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"
        'Else
        sql = sql & " VALUES ('" & Trim(txt_IndentNo.Text) & "','" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"
        '  End If
        sql = sql & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_storecode.Text) & "',"
        sql = sql & " '" & Trim(txt_storeDesc.Text) & "',"
        sql = sql & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,'N',"
        sql = sql & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"

        Insert(0) = sql
        Dim amt As String = 0
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            sql = "INSERT INTO INVENTORY_INDENTDET(INDENT_NO,INDENT_DATE,Itemcode,Itemname,Uom,Qty,"
            If gShortname = "KGA" Then
                sql = sql & "CLSQTY,"
            End If
            sql = sql & " VOID,Rate,Amount,Adduser,adddatetime)"
            sql = sql & " VALUES ('" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"

            AxfpSpread1.Col = 1
            itemcode = Trim(AxfpSpread1.Text)
            sql = sql & "'" & Trim(itemcode) & "',"
            AxfpSpread1.Col = 2
            sql = sql & "'" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sql = sql & "'" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            Dim qty As Double = Val(AxfpSpread1.Text)
            sql = sql & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","
            If gShortname = "KGA" Then
                AxfpSpread1.Col = 5
                sql = sql & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            End If
            sql = sql & "'N',"
            AxfpSpread1.Col = 7
            Dim rate As Double = Val(AxfpSpread1.Text)
            sql = sql & "'" & Format(Val(AxfpSpread1.Text), "0.000") & "',"
            amt = amt + Val(rate * qty)
            sql = sql & "" & Format(Val(rate * qty), "0.000") & ","

            sql = sql & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
            '   ssgrid.Col = 4


            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sql
        Next i
        gconnection.MoreTrans(Insert)



    End Sub

    Private Sub updateoperation()
        Dim Insert(0) As String
        Dim amt As String = 0
        Dim itemcode, SQLSTRING As String

        'FOR LOG DATA
        SQLSTRING = "INSERT INTO INVENTORY_INDENTHDRLOG(DOCNO,INDENT_NO,INDENT_DATE,fromStoreCode,Storelocationcode,Storelocationname,Remarks,Void,Adduser,Adddatetime) "
        SQLSTRING = SQLSTRING & " SELECT DOCNO,INDENT_NO,INDENT_DATE,fromStoreCode,Storelocationcode,Storelocationname,Remarks,Void,Adduser,Adddatetime FROM INVENTORY_INDENTHDR WHERE INDENT_NO='" & Trim(txt_IndentNo.Text) & "'"
        gconnection.getDataSet(SQLSTRING, "INVENTORY_INDENTHDRLOG")

        SQLSTRING = "INSERT INTO INVENTORY_INDENTDETLOG(INDENT_NO,INDENT_DATE,Itemcode,Itemname,Uom,Qty,"
        If gShortname = "KGA" Then
            SQLSTRING = SQLSTRING & "CLSQTY,"
        End If
        SQLSTRING = SQLSTRING & " VOID,Rate,Amount,Adduser,adddatetime)"
        SQLSTRING = SQLSTRING & " SELECT INDENT_NO,INDENT_DATE,Itemcode,Itemname,Uom,Qty,"
        If gShortname = "KGA" Then
            SQLSTRING = SQLSTRING & "CLSQTY,"
        End If
        SQLSTRING = SQLSTRING & " VOID,Rate,Amount,Adduser,adddatetime from INVENTORY_INDENTDET where INDENT_NO='" + Trim(txt_IndentNo.Text) + "' "
        gconnection.getDataSet(SQLSTRING, "INVENTORY_INDENTDETLOG")
        'LOG DATA ENDS 




        sql = "UPDATE INVENTORY_INDENTHDR SET INDENT_DATE='" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "', "
        sql = sql & " fromStorecode='" & Trim(TXT_FROMSTORECODE.Text) & "',"
        sql = sql & " Storelocationcode='" & Trim(txt_storecode.Text) & "',"
        sql = sql & " Storelocationname='" & Trim(txt_storeDesc.Text) & "',"

        sql = sql & " Remarks='" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,Void='N',"
        sql = sql & " Updateuser='" & Trim(gUsername) & "',"
      
        sql = sql & " Updatetime='" & Format(Now, "dd-MMM-yyyy") & "'"
        sql = sql & " WHERE INDENT_NO='" & Trim(txt_IndentNo.Text) & "' "
        Insert(0) = sql
        sql = "delete from INVENTORY_INDENTDET where INDENT_NO='" + Trim(txt_IndentNo.Text) + "'"
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            sql = "INSERT INTO INVENTORY_INDENTDET(INDENT_NO,INDENT_DATE,Itemcode,Itemname,Uom,Qty,"
            If gShortname = "KGA" Then
                sql = sql & "CLSQTY,"
            End If
            sql = sql & " VOID,Rate,Amount,Adduser,adddatetime)"
            sql = sql & " VALUES ('" & Trim(txt_IndentNo.Text) & "','" & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & "',"

            AxfpSpread1.Col = 1
            itemcode = Trim(AxfpSpread1.Text)
            sql = sql & "'" & Trim(itemcode) & "',"
            AxfpSpread1.Col = 2
            sql = sql & "'" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sql = sql & "'" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            Dim qty As Double = Val(AxfpSpread1.Text)
            sql = sql & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","
            If gShortname = "KGA" Then
                AxfpSpread1.Col = 5
                sql = sql & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            End If
            AxfpSpread1.Col = 6
            sql = sql & "'" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 7
            Dim rate As Double = Val(AxfpSpread1.Text)
            sql = sql & "'" & Format(Val(AxfpSpread1.Text), "0.000") & "',"
            amt = amt + Val(rate * qty)
            sql = sql & "" & Format(Val(rate * qty), "0.000") & ","
            sql = sql & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"

            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sql
        Next i
        gconnection.MoreTrans(Insert)


    End Sub

    Private Sub voidoperation()
        Dim Insert(0) As String
        Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Indentdate.Value), "yyyy/MM/dd"))
        If checkBdate = True Then
            MsgBox("Business date closed..")
            Exit Sub
        End If
        If gShortname = "SKYYE" Then
            gSQLString = "SELECT isnull(APPROVE,'')as approve FROM INVENTORY_INDENTHDR WHERE indent_no='" & txt_IndentNo.Text & "' "
            gconnection.getDataSet(gSQLString, "updte")
            Dim APPR As String
            APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
            If APPR = "Y" Then
                MsgBox("This Indent is already Approved You can't Void it ")
                Exit Sub
            End If
        End If

        sql = "UPDATE INVENTORY_INDENTHDR SET "
        sql = sql & " Void='Y',voiduser='" + gUsername + "',voiddatetime=getdate() "
        sql = sql & " WHERE INDENT_NO='" & Trim(txt_IndentNo.Text) & "' "
        Insert(0) = sql
        sql = "UPDATE INVENTORY_INDENTDET SET "
        sql = sql & " Void='Y',voiduser='" + gUsername + "',voiddatetime=getdate() "
        sql = sql & " WHERE INDENT_NO='" & Trim(txt_IndentNo.Text) & "' "
        ReDim Preserve Insert(Insert.Length)
        Insert(Insert.Length - 1) = sql

        gconnection.MoreTrans(Insert)


    End Sub
    Private Sub Clearoperation()
        txt_IndentNo.Text = ""
        CMD_APPROVE.Visible = False
        Me.txt_IndentNo.ReadOnly = False
        txt_storecode.Text = ""
        txt_storeDesc.Text = ""
        txt_Totalamount.Text = ""
        TXT_FROMSTORECODE.Text = ""
        txt_FromStorename.Text = ""
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        txt_Remarks.Text = ""
        Me.dtp_Indentdate.Value = Format(Now, "dd/MMM/yyyy")
        Cmd_Add.Text = "Add [F7]"

        Me.Txt_qty.Text = ""
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True

        Me.Cmd_Add.Enabled = True
        Me.lbl_Freeze.Visible = False
        Me.Cmd_Freeze.Enabled = True
        If UCase(gShortname) <> "HGA" And UCase(gShortname) <> "KGA" And UCase(gShortname) <> "CSC" Then
            autogenerate()
        End If
        For k As Integer = 0 To 10
            For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                AxfpSpread1.TypeComboBoxClear(3, k)
            Next
        Next
        dtp_Indentdate.Focus()
    End Sub
    'function fire on txtindent text box
    Private Function validateoninsert() As Boolean
        Dim flag As Boolean


        Dim checkBdate As Boolean
        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Indentdate.Value), "yyyy/MM/dd"), txt_storecode.Text, TXT_FROMSTORECODE.Text)
        'Else
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Indentdate.Value), "yyyy/MM/dd"))
        'End If

        'Added by Sri for all club said by Sandeep sir on 05.01.2021
        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Indentdate.Value), "yyyy/MM/dd"), txt_storecode.Text, TXT_FROMSTORECODE.Text)
        'End

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
        If gShortname <> "BRC" Then
            If DateDiff(DateInterval.Day, (CDate(dtp_Indentdate.Value)), DateValue(Now)) < 0 Then
                MessageBox.Show("Indent date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If
        End If
        
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If

        If txt_IndentNo.Text = "" Then
            MessageBox.Show("Please Fill Indent No ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

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
        For j As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 1
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
            If AxfpSpread1.Text = "" Or Val(AxfpSpread1.Text) <= 0 Then
                MessageBox.Show("Quantity can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(4, j)

                flag = True
                Return flag
            End If

            If UCase(gShortname) = "BRC" Or UCase(gShortname) = "RCL" Then
                AxfpSpread1.Col = 5
                Dim clqty As Double = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 4
                If clqty < Val(AxfpSpread1.Text) Then

                    MessageBox.Show("Quantity can't be Greater Than Closing Stock ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    AxfpSpread1.Text = ""
                    AxfpSpread1.SetActiveCell(4, j)

                    flag = True
                    Return flag
                Else
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                End If
            Else
            End If
        Next
        Return False
    End Function

    Private Function validateonupdate() As Boolean
        Dim flag As Boolean
        ' Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Indentdate.Value), "yyyy/MM/dd"))
        Dim checkBdate As Boolean
        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Indentdate.Value), "yyyy/MM/dd"), txt_storecode.Text, TXT_FROMSTORECODE.Text)
        If checkBdate = True And RESU1 = False Then
            MsgBox("Business date closed..")
            flag = True
            Return flag
        End If

        If gShortname = "SKYYE" Then
            gSQLString = "SELECT isnull(APPROVE,'')as approve FROM INVENTORY_INDENTHDR WHERE indent_no='" & txt_IndentNo.Text & "' "
            gconnection.getDataSet(gSQLString, "updte")
            Dim APPR As String
            APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
            If APPR = "Y" Then
                MsgBox("This Indent is already Approved  You can't update it ")
                flag = True
                Return flag
            End If
        End If

        If gShortname = "SKYYE" Then
            If gUserCategory <> "S" Then
                gSQLString = "SELECT isnull(PRODUCT_TYPE,'')as PRODUCT_TYPE FROM INVENTORY_INDENTHDR WHERE indent_no='" & txt_IndentNo.Text & "' "
                gconnection.getDataSet(gSQLString, "printflag")
                Dim APPRs As String
                APPRs = gdataset.Tables("printflag").Rows(0).Item("PRODUCT_TYPE")
                If APPRs = "Y" Then
                    MsgBox("This Indent is already Print Out Taken You can't update it ")
                    flag = True
                    Return flag
                End If
            End If
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
            flag = True
            Return flag
        End If

        If UCase(gShortname) <> "BRC" Then
            If DateDiff(DateInterval.Day, (CDate(dtp_Indentdate.Value)), DateValue(Now)) < 0 Then
                MessageBox.Show("Indent date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If
        End If


        If txt_IndentNo.Text <> "" Then
            sql = "select * from STOCKISSUEDETAIL where IndentNo='" + txt_IndentNo.Text + "' ANd isnull(void,'N')<>'Y'  "
            gconnection.getDataSet(sql, "STOCKISSUEDETAIL")
            If (gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0) Then
                MessageBox.Show("Indent has closed  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ' Call Clearoperation()
                flag = True
                Return flag
            Else

            End If
        End If


        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If

        If txt_IndentNo.Text = "" Then
            MessageBox.Show("Please Fill Indent No ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

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
        For j As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 1
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
            If AxfpSpread1.Text = "" Or Val(AxfpSpread1.Text) <= 0 Then
                MessageBox.Show("Quantity can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(4, j)

                flag = True
                Return flag
            End If

            If UCase(gShortname) = "RCL" Then
                AxfpSpread1.Col = 5
                Dim clqty As Double = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 4
                If clqty <= Val(AxfpSpread1.Text) Then

                    MessageBox.Show("Quantity can't be Greater Than Closing Stock ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    AxfpSpread1.Text = ""
                    AxfpSpread1.SetActiveCell(4, j)

                    flag = True
                    Return flag
                Else
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                End If
            Else
            End If

        Next
        Return False
    End Function


    Private Sub cmd_indentnoHelp_Click(sender As Object, e As EventArgs) Handles cmd_indentnoHelp.Click
        Try
            If gShortname = "SKYYE" Then
                gSQLString = "SELECT indent_no,indent_date,ISNULL(APPROVE,'N')AS APPROVE FROM inventory_indenthdr "
            Else
                gSQLString = "SELECT indent_no,indent_date FROM inventory_indenthdr "
            End If



            M_WhereCondition = "  where  fromStoreCode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "')   "
            M_ORDERBY = "ORDER BY INDENT_DATE DESC,INDENT_NO desc"
            Dim vform As New List_Operation
            vform.Field = "INDENT_NO,INDENT_DATE"
            If gShortname = "SKYYE" Then
                vform.vFormatstring1 = "       INDENT_NO         |     INDENT_DATE        |    APPROVE     "
            Else
                vform.vFormatstring1 = "       INDENT_NO                  |     INDENT_DATE                                                           "
            End If

            vform.vCaption = "STOCK INDENT HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_IndentNo.Text = Trim(vform.keyfield & "")
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Call txt_IndentNo_Validated(txt_IndentNo, e)
                dtp_Indentdate.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_IndentNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_IndentNo.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If cmd_indentnoHelp.Enabled = True Then
                    search = Trim(txt_IndentNo.Text)
                    Call cmd_indentnoHelp_Click(cmd_indentnoHelp, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_IndentNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_IndentNo.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_IndentNo.Text) = "" Then
                    Call cmd_indentnoHelp_Click(cmd_indentnoHelp, e)
                Else
                    txt_IndentNo_Validated(txt_IndentNo, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_IndentNo_Validated(sender As Object, e As EventArgs) Handles txt_IndentNo.Validated
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, remarks As String
        Dim vTypeseqno, Clsquantity, vGroupseqno As Double
        Try
            If Trim(txt_IndentNo.Text) <> "" Then
                sqlstring = " SELECT ISNULL(H.INDENT_NO,'') AS INDENT_NO,H.INDENT_DATE AS INDENT_DATE,ISNULL(FROMSTORECODE,'') FROMSTORECODE , ISNULL(H.STORELOCATIONCODE,'') AS STORELOCATIONCODE, "
                sqlstring = sqlstring & " ISNULL(H.STORELOCATIONNAME,'') AS STORELOCATIONNAME,"
                sqlstring = sqlstring & " ISNULL(H.REMARKS,'') AS REMARKS, ISNULL(H.VOID,'') AS VOID,"
                sqlstring = sqlstring & " ISNULL(H.ADDUSER,'') AS ADDUSER,ADDDATETIME,ISNULL(H.UPDATEUSER,'') AS UPDATEUSER,UPDATETIME,h.voiddatetime as voiddatetime"
                sqlstring = sqlstring & " FROM INVENTORY_INDENTHDR AS H "
                sqlstring = sqlstring & " WHERE INDENT_NO='" & txt_IndentNo.Text & "'"
                gconnection.getDataSet(sqlstring, "INDENTHDR")
                '''************************************************* SELECT RECORD FROM INDENTHDR *********************************************''''                
                If gdataset.Tables("INDENTHDR").Rows.Count > 0 Then
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_IndentNo.ReadOnly = True
                    'VSTRDOCNO = Trim(txt_Docno.Text)
                    dtp_Indentdate.Value = Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("INDENT_DATE")), "dd-MMM-yyyy")

                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("fromStoreCode") & "")
                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("fromStoreCode") & "")
                    Call TXT_FROMSTORECODE_Validated(txt_IndentNo.Text, e)
                    txt_IndentNo.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("INDENT_NO") & "")

                    txt_storecode.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("STORELOCATIONCODE"))
                    txt_storeDesc.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("STORELOCATIONNAME"))
                    remarks = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("REMARKS"))
                    txt_Remarks.Text = Replace(remarks, "?", "'")
                    If gdataset.Tables("INDENTHDR").Rows(0).Item("VOID") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = "Record Freezed On " & Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("voiddatetime")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Enabled = True
                        Me.Cmd_Add.Enabled = False
                        ' Me.Cmd_FREEZE.Text = "UnVoid[F8]"
                        Cmd_Freeze.Enabled = False
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        'Me.Cmd_Add.Enabled = True
                        Me.lbl_Freeze.Visible = False
                        Me.Cmd_Freeze.Enabled = True
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Void[F8]"
                        Me.Cmd_Add.Enabled = True
                        Me.Cmd_Freeze.Enabled = True
                    End If


                    sql = "select * from STOCKISSUEDETAIL where IndentNo='" + txt_IndentNo.Text + "' and isnull(void,'N')<>'Y' "
                    gconnection.getDataSet(sql, "STOCKISSUEDETAIL")
                    If (gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0) Then
                        Me.Cmd_Add.Enabled = True
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = "Indent Issue On " & Format(CDate(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("docdate")), "dd-MMM-yyyy") & " AND ISSUE NO IS :" & gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("Docdetails")
                        Me.Cmd_Freeze.Enabled = False
                    Else

                    End If


                    '''************************************************* SELECT RECORD FROM INDENTDETAILS *********************************************''''                
                    Dim strsql As String
                    Dim STRITEMCODE, STRITEMUOM As String
                    sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,ISNULL(QTY,0) AS QTY ,ISNULL(VOID,'N') AS VOID,ISNULL(rate,0) AS rate,ISNULL(amount,0) AS amount"
                    sqlstring = sqlstring & " FROM INVENTORY_INDENTDET WHERE  INDENT_NO ='" & Trim(txt_IndentNo.Text) & "' ORDER BY AUTOID"
                    gconnection.getDataSet(sqlstring, "INDENTDETAILS")
                    If gdataset.Tables("INDENTDETAILS").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("INDENTDETAILS").Rows.Count
                            '  Call GridUOM(i) '''---> FILL GRID UOM
                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE")))
                            STRITEMCODE = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMNAME")))
                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = i
                            Dim sql1 As String = "select DISTINCT tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE")) + "'"
                            gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z
                            AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM")))
                            ' AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                            '  STRITEMUOM = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                            AxfpSpread1.SetText(4, i, Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY")))
                            AxfpSpread1.Col = 6
                            AxfpSpread1.Row = i
                            AxfpSpread1.Text = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("VOID"))
                            AxfpSpread1.Col = 7
                            AxfpSpread1.Row = i
                            AxfpSpread1.SetText(7, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("RATE")))
                            AxfpSpread1.Col = 8
                            AxfpSpread1.Row = i
                            AxfpSpread1.SetText(8, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("amount")))

                            sql = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue from closingqty where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE")) + "' AND  storecode='" + TXT_FROMSTORECODE.Text + "'and  CONVERT(VARCHAR(11), Trndate, 106)<='" + Format(CDate(dtp_Indentdate.Value), "dd MMM yyyy") + "' order by trndate desc,AUTOID desc"
                            gconnection.getDataSet(sql, "closingqty")

                            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                                AxfpSpread1.Col = 5
                                AxfpSpread1.Row = i
                                'AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = Format(gdataset.Tables("closingqty").Rows(0).Item("closingstock"), "0.00")

                                'closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
                            End If

                            sqlstring = "SELECT SUM(AMOUNT)AS AMOUNT FROM Inventory_INDENTDET WHERE INDENT_NO  ='" & Trim(txt_IndentNo.Text) & "'"
                            gconnection.getDataSet(sqlstring, "INDENTS")
                            If gdataset.Tables("INDENTS").Rows.Count > 0 Then
                                txt_Totalamount.Text = gdataset.Tables("INDENTS").Rows(0).Item("AMOUNT")
                            End If
                            If gShortname = "NIZAM" Then
                                sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,ISNULL(QTY,0) AS QTY ,ISNULL(VOID,'N') AS VOID,ISNULL(rate,0) AS rate,ISNULL(amount,0) AS amount"
                                sqlstring = sqlstring & " FROM INVENTORY_INDENTDET WHERE  INDENT_NO ='" & Trim(txt_IndentNo.Text) & "' ORDER BY AUTOID"
                                gconnection.getDataSet(sqlstring, "INDENTDETAILS")
                                If gdataset.Tables("INDENTDETAILS").Rows.Count > 0 Then
                                    'STRITEMCODE = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE"))
                                    gconnection.closingStock(Format(dtp_Indentdate.Value, "dd/MMM/yyyy"), STRITEMCODE, Trim(TXT_FROMSTORECODE.Text), "")
                                    Dim closingqty, CRRATE, iqty As Double
                                    Dim precise As Double
                                    Dim uom1, uom As String
                                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                        closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                        uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                                        CRRATE = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                                        uom = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                                        sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                        gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                                        Dim convvalue As Double
                                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                            precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                        Else
                                            MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                            Exit Sub
                                        End If
                                        closingqty = closingqty * convvalue
                                    Else
                                        closingqty = 0
                                    End If

                                    If closingqty > Val(Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY"))) Then
                                        'AxfpSpread1.SetText(5, i, Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY")))
                                        iqty = Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY"))
                                    Else
                                        'AxfpSpread1.SetText(5, i, Val(closingqty))
                                        iqty = Val(closingqty)
                                    End If
                                    AxfpSpread1.SetText(7, i, CRRATE)
                                    AxfpSpread1.SetText(8, i, CRRATE * iqty)
                                End If
                            End If

                            j = j + 1
                        Next
                    End If
                    If gShortname = "NIZAM" Then
                        sql = "select projno from STD_PRODUCTIONPLAN_HEADER where projno='" & txt_IndentNo.Text & "'"
                        sql = sql & " union all "
                        sql = sql & " select TRFRNO from STD_STOCKINDENT_HEADER where TRFRNO='" & txt_IndentNo.Text & "'"
                        gconnection.getDataSet(sql, "COSTING_INDENT")
                        If (gdataset.Tables("COSTING_INDENT").Rows.Count > 0) Then
                            Me.Cmd_Add.Enabled = False
                        Else
                            Me.Cmd_Add.Enabled = True
                        End If
                    End If


                    If gUserCategory <> "S" Then
                        '  Call GetRights()
                    End If
                    ' ssgrid.Focus()
                    dtp_Indentdate.Focus()
                    AxfpSpread1.SetActiveCell(1, 1)
                    Calculate()
                Else
                    dtp_Indentdate.Focus()
                End If
            Else
                dtp_Indentdate.Focus()
            End If

            If Mid(Cmd_Add.Text, 1, 1) = "U" Then
                CMD_APPROVE.Visible = True
            Else
                CMD_APPROVE.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub txt_storecode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_storecode.KeyDown
        Dim sqlstring As String
        If e.KeyCode = Keys.Enter Then
            If txt_storecode.Text = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
                TXT_FROMSTORECODE.Focus()
            Else
                sqlstring = "Select storecode,storedesc,ctype,STORESTATUS from Vw_Store_Costcenter where storecode='" + txt_storecode.Text + "' and storestatus <>'M'"

                'sqlstring = " SELECT DISTINCT(storecode),storedesc FROM STOREMASTER "
                'sqlstring = sqlstring & " WHERE STORECODE = '" & txt_storecode.Text & "' AND freeze <> 'Y' AND STORESTATUS<>'M' "
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    txt_storeDesc.Text = gdataset.Tables("STOREMASTER1").Rows(0).Item("STOREDESC")
                    STORESTATUS = gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")
                    If (gdataset.Tables("STOREMASTER1").Rows(0).Item("ctype") = "C") Then
                        costcenterflag = True
                    Else
                        costcenterflag = False
                    End If

                    TXT_FROMSTORECODE.Focus()
                Else
                    txt_storecode.Text = ""
                    ' txt_IndentNo.Text = ""
                    txt_storecode.Focus()
                End If
            End If
            
                TXT_FROMSTORECODE.Focus()
        End If

    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Clearoperation()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
    End Sub
    Sub id()
        Dim PrinterConn As New OleDb.OleDbConnection
        Dim Printercmd As New OleDb.OleDbDataAdapter
        Dim GetPrinter As New DataSet
        Dim sql, ssql As String
        Try
            sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
            sql = sql & AppPath & "\DBS_KEY.MDB"
            PrinterConn.ConnectionString = sql
            PrinterConn.Open()
            ssql = "SELECT email from email"
            Printercmd = New OleDb.OleDbDataAdapter(ssql, PrinterConn)
            Printercmd.Fill(GetPrinter)
            If GetPrinter.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To GetPrinter.Tables(0).Rows.Count - 1
                    If mailid = "" Then
                        mailid = Trim(GetPrinter.Tables(0).Rows(i).Item(0) & "")
                    Else
                        mailid = mailid & "," & Trim(GetPrinter.Tables(0).Rows(i).Item(0) & "")
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Failed To Connect To Computer Printer", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            PrinterConn.Close()
        End Try
    End Sub
    Private Function  Mail_softcopy(dtl As String, subject As String)
        Try
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Rpt_Indentbill_KGA
            sqlstring = sqlstring & " SELECT 	ISNULL(INDENT_NO,'') INDENT_NO, ISNULL(INDENT_DATE,'')  INDENT_DATE,"
            sqlstring = sqlstring & " ISNULL(FROMSTORECODE,'') FROMSTORECODE , ISNULL(STORELOCATIONCODE,'') STORELOCATIONCODE, ISNULL(STORELOCATIONNAME,'') STORELOCATIONNAME,"
            sqlstring = sqlstring & " ISNULL(PRODUCT_TYPE,'') PRODUCT_TYPE, ISNULL(REMARKS,'') REMARKS,ISNULL(updsign,'') updsign,ISNULL(updfooter,'') updfooter,"
            sqlstring = sqlstring & "	ISNULL(ITEMCODE,'') ITEMCODE, ISNULL(ITEMNAME,'') ITEMNAME, ISNULL(UOM,'') UOM,"
            sqlstring = sqlstring & " ISNULL(QTY,0) QTY, ISNULL(RATE,0) RATE, ISNULL(AMOUNT,0) AMOUNT, ISNULL(CLSQTY,0) CLSQTY, ISNULL(ADDDATE,'') ADDDATE "
            sqlstring = sqlstring & " FROM VW_INV_IDENTBILL"
            ' Sqlstring = Sqlstring & " INNER JOIN INVENTORY_INDENTDET AS DET ON HDR.INDENT_NO = DET.INDENT_NO"
            sqlstring = sqlstring & " WHERE INDENT_NO BETWEEN '" & Trim(txt_IndentNo.Text) & "' AND '" & Trim(txt_IndentNo.Text) & "'"
            gconnection.getDataSet(sqlstring, "VW_INV_IDENTBILL")
            SSQL = " SELECT STOREDESC FROM STOREMASTER WHERE STORECODE = '" & gdataset.Tables("VW_INV_IDENTBILL").Rows(0).Item("FROMSTORECODE") & "' "
            gconnection.getDataSet(SSQL, "FROMSTORE")
            If gdataset.Tables("FROMSTORE").Rows.Count > 0 Then
                FROMSTORE = gdataset.Tables("FROMSTORE").Rows(0).Item("STOREDESC")
            End If
            If gdataset.Tables("VW_INV_IDENTBILL").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_INV_IDENTBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName
                Dim textobj16 As TextObject
                textobj16 = r.ReportDefinition.ReportObjects("Text16")
                textobj16.Text = UCase(Address1)
                Dim textobj19 As TextObject
                textobj19 = r.ReportDefinition.ReportObjects("Text19")
                textobj19.Text = UCase(Address2)
                Dim textobj21 As TextObject
                textobj21 = r.ReportDefinition.ReportObjects("Text21")
                textobj21.Text = UCase(gUsername)
                'Dim textobj5 As TextObject
                'textobj5 = r.ReportDefinition.ReportObjects("Text28")
                'textobj5.Text = TINNO
                'Dim textobj6 As TextObject
                'textobj6 = r.ReportDefinition.ReportObjects("Text30")
                'textobj6.Text = SERVICETAX
                Dim textobj As TextObject
                textobj = r.ReportDefinition.ReportObjects("Text17")
                textobj.Text = FROMSTORE
                Dim textobj25 As TextObject
                textobj25 = r.ReportDefinition.ReportObjects("Text25")
                textobj25.Text = gFinancalyearStart + " to " + gFinancialyearEnd
                rViewer.Show()
                If gpdf = "" Then
                    MessageBox.Show("Pls Provide PDF Path in Dbs key..")
                    Exit Function
                End If
                If Directory.Exists(gpdf) Then
                Else
                    MessageBox.Show(gpdf & " not exists")
                    Exit Function
                End If
                If Directory.Exists(gpdf & "\" & gFinancalyearStart & "-" & gFinancialyearEnd) Then
                Else
                    Directory.CreateDirectory(gpdf & "\" & gFinancalyearStart & "-" & gFinancialyearEnd)
                End If
                Dim FILEPATH As String
                Dim AFILE As File
                FILEPATH = gpdf & "\" & gFinancalyearStart & "-" & gFinancialyearEnd & "\" & Trim(txt_IndentNo.Text) & ".PDF"
                If AFILE.Exists(FILEPATH) Then
                    AFILE.Delete(FILEPATH)
                End If
                Dim CREXPORTOPTIONS As ExportOptions
                Dim CRDISKFILEDESTINATIONOPTIONS As New DiskFileDestinationOptions()
                Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                CRDISKFILEDESTINATIONOPTIONS.DiskFileName = FILEPATH
                CREXPORTOPTIONS = r.ExportOptions
                With CREXPORTOPTIONS
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                    .DestinationOptions = CRDISKFILEDESTINATIONOPTIONS
                    .FormatOptions = CrFormatTypeOptions
                End With
                r.Export()
                rViewer.Close()
                id()
                If mailid <> "" Then
                    'Label1.Visible = True
                    'Label1.Text = "Sending " & FILEPATH & " to" & ECODE & " .."
                    Call mail(mailid, FILEPATH, "", "Dear Sir," & vbCrLf & vbCrLf & dtl & "." & vbCrLf & vbCrLf & "Thanks & Regards" & vbCrLf & UCase(txt_storeDesc.Text), subject)
                Else
                End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Public Function mail(ByVal emailid As String, ByVal FILEPATH As String, ByVal MailMessage As String, ByVal filename As String, ByVal subject As String)
        Dim sqlstring As String
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Try
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("erp@kga.in", "h4?WW.tq9*TD")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "mail.kga.in"
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("erp@kga.in", "KGA Inventory Service")
            e_mail.To.Add(emailid)
            If subject = "" Then
                e_mail.Subject = "KGA" & " DEPT." & UCase(txt_storeDesc.Text) & " STOCK INDENT."
            Else
                e_mail.Subject = subject
            End If
            e_mail.IsBodyHtml = False
            e_mail.Body = filename
            e_mail.Attachments.Add(New Attachment(FILEPATH))
            Smtp_Server.Send(e_mail)
            sqlstring = "delete from sendmail  where indentno ='" & txt_IndentNo.Text & "'"
            gconnection.GetValues(sqlstring)
            sqlstring = "insert into sendmail (emailid,sentdate,indentno,username) values ('" & emailid & "',getdate(),'" & txt_IndentNo.Text & "','" & gUsername & "')"
            gconnection.GetValues(sqlstring)
        Catch ex As Exception
            MsgBox(ex.Message, "Mail sending process failed. Kindly check your internet connection and Credential", "Dear User")
            sqlstring = "delete from sendmail  where indentno ='" & txt_IndentNo.Text & "'"
            gconnection.GetValues(sqlstring)
            Exit Function
        End Try
    End Function

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        If Cmd_Add.Text = "Add [F7]" Then
            If UCase(gShortname) <> "HGA" And UCase(gShortname) <> "KGA" And UCase(gShortname) <> "CSC" Then
                If UCase(gShortname) <> "FMC" Then
                    Call autogenerate()
                End If

            End If
            If validateoninsert() = False Then
                addoperation()
                'Added by Sriram only for KGA Indent Mail Process
                If UCase(gShortname) = "KGA" Then
                    Mail_softcopy("Please find the attached stock indent no " & Trim(txt_IndentNo.Text) & " dated " & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & " for " & UCase(txt_storeDesc.Text) & " DEPARTMENT added by " & gUsername, "Stock Indent " & UCase(txt_storeDesc.Text))
                End If
                'End
                If MsgBox("DO you want to View ?", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "View Report") = MsgBoxResult.Ok Then
                    Call cmd_View_Click(cmd_View, e)
                End If
                Clearoperation()
                End If
            ElseIf (Cmd_Add.Text = "Update[F7]") Then
            If validateonupdate() = False Then
                updateoperation()
                'Added by Sriram only for KGA Indent Mail Process
                If UCase(gShortname) = "KGA" Then
                    Mail_softcopy("Please find the attached stock indent no " & Trim(txt_IndentNo.Text) & " dated " & Format(CDate(dtp_Indentdate.Value), "dd-MMM-yyyy") & " for " & txt_storeDesc.Text & " DEPARTMENT updated by " & gUsername, "Revised Stock Indent " & UCase(txt_storeDesc.Text))
                End If
                'End
                If MsgBox("DO you want to View ?", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "View Report") = MsgBoxResult.Ok Then
                    Call cmd_View_Click(cmd_View, e)
                End If
                Clearoperation()
            End If
        End If

    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        If MessageBox.Show("Do You Want void it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then
            Exit Sub
        End If

        voidoperation()
        Clearoperation()
    End Sub

   
    Private Sub cmd_export_Click(sender As Object, e As EventArgs)
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VW_INV_IDENTBILL"
        sqlstring = "select * from VW_INV_IDENTBILL"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub cmd_print_Click(sender As Object, e As EventArgs) Handles cmd_print.Click

    End Sub

    Private Sub cmd_Exit_Click(sender As Object, e As EventArgs) Handles cmd_Exit.Click
        Me.Close()
    End Sub

  
    Private Sub dtp_Indentdate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_Indentdate.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txt_storecode.Focus()
        End If
    End Sub

  


    Private Sub cmd_View_Click(sender As Object, e As EventArgs) Handles cmd_View.Click
        Try
            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE, addr, asql As String
            Dim r
            If UCase(gShortname) = "CFC" Then
                r = New Rpt_IndentbillCFC_
            ElseIf UCase(gShortname) = "KGA" Then
                r = New Rpt_Indentbill_KGA
            ElseIf UCase(gShortname) = "HGA" Then
                r = New Rpt_Indentbill_HGA
            ElseIf UCase(gShortname) = "SKYYE" Then
                r = New Rpt_Indentbill_SKYYE
            Else
                r = New Rpt_Indentbill_
            End If
            sqlstring = " SELECT 	ISNULL(INDENT_NO,'') INDENT_NO, ISNULL(INDENT_DATE,'')  INDENT_DATE,"
            sqlstring = sqlstring & " ISNULL(FROMSTORECODE,'') FROMSTORECODE , ISNULL(STORELOCATIONCODE,'') STORELOCATIONCODE, ISNULL(STORELOCATIONNAME,'') STORELOCATIONNAME,"
            sqlstring = sqlstring & "  ISNULL(REMARKS,'') REMARKS,"
            sqlstring = sqlstring & "	ISNULL(ITEMCODE,'') ITEMCODE, ISNULL(ITEMNAME,'') ITEMNAME, ISNULL(UOM,'') UOM,"
            sqlstring = sqlstring & " ISNULL(QTY,0) QTY,isnull(clsqty,0)as clsqty, left(CONVERT(CHAR(20),isnull(ADDDATE,'01-01-1900'), 25), 19) as  ADDDATE,ADDUSER,RATE ,AMOUNT "
            sqlstring = sqlstring & " FROM VW_INV_IDENTBILL"
            ' Sqlstring = Sqlstring & " INNER JOIN INVENTORY_INDENTDET AS DET ON HDR.INDENT_NO = DET.INDENT_NO"
            sqlstring = sqlstring & " WHERE INDENT_NO BETWEEN '" & Trim(txt_IndentNo.Text) & "' AND '" & Trim(txt_IndentNo.Text) & "' "
            sqlstring = sqlstring & "ORDER BY ITEMCODE"

            gconnection.getDataSet(sqlstring, "VW_INV_IDENTBILL")

            If gShortname = "SKYYE" Then
                asql = "update inventory_indenthdr set PRODUCT_TYPE='Y' where INDENT_NO='" & Trim(txt_IndentNo.Text) & "'"
                gconnection.getDataSet(asql, "PrintFlag")
            End If

            SSQL = " SELECT STOREDESC FROM STOREMASTER WHERE STORECODE = '" & gdataset.Tables("VW_INV_IDENTBILL").Rows(0).Item("FROMSTORECODE") & "' "
            gconnection.getDataSet(SSQL, "FROMSTORE")
            If gdataset.Tables("FROMSTORE").Rows.Count > 0 Then
                FROMSTORE = gdataset.Tables("FROMSTORE").Rows(0).Item("STOREDESC")
            End If


            If gdataset.Tables("VW_INV_IDENTBILL").Rows.Count > 0 Then
                If UCase(gShortname) = "CFC" Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "VW_INV_IDENTBILL"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text13")
                    textobj1.Text = MyCompanyName
                    Dim textobj As TextObject
                    textobj = r.ReportDefinition.ReportObjects("Text17")
                    textobj.Text = FROMSTORE
                    Dim textobj16 As TextObject
                    textobj16 = r.ReportDefinition.ReportObjects("Text16")
                    textobj16.Text = UCase(Address1) + "," + UCase(Address2)

                    Dim textobj19 As TextObject
                    textobj19 = r.ReportDefinition.ReportObjects("Text19")
                    textobj19.Text = UCase(gState) + "," + UCase(gPincode)

                    Dim textobj27 As TextObject
                    textobj19 = r.ReportDefinition.ReportObjects("Text27")
                    textobj19.Text = UCase(gPhone1) + "," + UCase(gPhone2)
                    Dim textobj30 As TextObject
                    textobj30 = r.ReportDefinition.ReportObjects("Text30")
                    textobj30.Text = "GSTIN NO : " & UCase(gGSTINNO)
                    Dim textobj21 As TextObject
                    textobj21 = r.ReportDefinition.ReportObjects("Text21")
                    textobj21.Text = UCase(gUsername)

                    Dim textobj5 As TextObject
                    textobj5 = r.ReportDefinition.ReportObjects("Text5")
                    textobj5.Text = "Created by : " & UCase(gdataset.Tables("VW_INV_IDENTBILL").Rows(0).Item("ADDUSER")) & ""

                    Dim textobj25 As TextObject
                    textobj25 = r.ReportDefinition.ReportObjects("Text25")
                    textobj25.Text = gFinancalyearStart + " to " + gFinancialyearEnd
                Else


                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "VW_INV_IDENTBILL"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text13")
                    textobj1.Text = MyCompanyName
                    Dim textobj As TextObject
                    textobj = r.ReportDefinition.ReportObjects("Text17")
                    textobj.Text = FROMSTORE

                    If UCase(gShortname) = "SKYYE" Then
                        addr = ""
                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text19")
                        If Address1 <> "" Then
                            addr = addr & Address1
                        End If

                        If Address2 <> "" Then
                            addr = addr & ", " & Address2
                        End If

                        If gCity <> "" Then
                            addr = addr & ", " & gCity
                        End If

                        If gPincode <> "" Then
                            addr = addr & " - " & gPincode
                        End If

                        textobj3.Text = addr
                    Else

                        Dim textobj16 As TextObject
                        textobj16 = r.ReportDefinition.ReportObjects("Text16")
                        textobj16.Text = UCase(Address1)

                        Dim textobj19 As TextObject
                        textobj19 = r.ReportDefinition.ReportObjects("Text19")
                        textobj19.Text = UCase(Address2)

                    End If












                    Dim textobj21 As TextObject
                    textobj21 = r.ReportDefinition.ReportObjects("Text21")
                    textobj21.Text = UCase(gUsername)

                    Dim textobj5 As TextObject
                    textobj5 = r.ReportDefinition.ReportObjects("Text5")
                    textobj5.Text = "Created by : " & UCase(gdataset.Tables("VW_INV_IDENTBILL").Rows(0).Item("ADDUSER")) & ""

                    Dim textobj25 As TextObject
                    textobj25 = r.ReportDefinition.ReportObjects("Text25")
                    textobj25.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text6")
                    If UCase(gShortname) = "TMA" Then
                        textobj6.Text = "                     Store Keeper:                                                                                             Manager: "
                    End If
                End If

                rViewer.Show()

            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If
            'Else
            'gPrint = False
            'Call printoperation()
            ''End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        cmd_View_Click(sender, e)
        'Try
        '    'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
        '    Dim rViewer As New Viewer
        '    Dim sqlstring, SSQL, FROMSTORE As String
        '    Dim r As New Rpt_Indentbill_
        '    sqlstring = sqlstring & " SELECT 	ISNULL(INDENT_NO,'') INDENT_NO, ISNULL(INDENT_DATE,'')  INDENT_DATE,"
        '    sqlstring = sqlstring & " ISNULL(FROMSTORECODE,'') FROMSTORECODE , ISNULL(STORELOCATIONCODE,'') STORELOCATIONCODE, ISNULL(STORELOCATIONNAME,'') STORELOCATIONNAME,"
        '    sqlstring = sqlstring & "  ISNULL(REMARKS,'') REMARKS,"
        '    sqlstring = sqlstring & "	ISNULL(ITEMCODE,'') ITEMCODE, ISNULL(ITEMNAME,'') ITEMNAME, ISNULL(UOM,'') UOM,"
        '    sqlstring = sqlstring & " ISNULL(QTY,0) QTY,  cast(ISNULL(ADDDATE,'') as smalldatetime) as  ADDDATE"
        '    sqlstring = sqlstring & " FROM VW_INV_IDENTBILL"
        '    ' Sqlstring = Sqlstring & " INNER JOIN INVENTORY_INDENTDET AS DET ON HDR.INDENT_NO = DET.INDENT_NO"
        '    sqlstring = sqlstring & " WHERE INDENT_NO BETWEEN '" & Trim(txt_IndentNo.Text) & "' AND '" & Trim(txt_IndentNo.Text) & "'"

        '    gconnection.getDataSet(sqlstring, "VW_INV_IDENTBILL")

        '    SSQL = " SELECT STOREDESC FROM STOREMASTER WHERE STORECODE = '" & gdataset.Tables("VW_INV_IDENTBILL").Rows(0).Item("FROMSTORECODE") & "' "
        '    gconnection.getDataSet(SSQL, "FROMSTORE")
        '    If gdataset.Tables("FROMSTORE").Rows.Count > 0 Then
        '        FROMSTORE = gdataset.Tables("FROMSTORE").Rows(0).Item("STOREDESC")
        '    End If
        '    If gdataset.Tables("VW_INV_IDENTBILL").Rows.Count > 0 Then

        '        rViewer.ssql = sqlstring
        '        rViewer.Report = r
        '        rViewer.TableName = "VW_INV_IDENTBILL"
        '        Dim textobj1 As TextObject
        '        textobj1 = r.ReportDefinition.ReportObjects("Text13")
        '        textobj1.Text = MyCompanyName
        '        Dim textobj As TextObject
        '        textobj = r.ReportDefinition.ReportObjects("Text17")
        '        textobj.Text = FROMSTORE
        '        rViewer.Show()

        '    Else
        '        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        '    End If
        '    'Else
        '    'gPrint = False
        '    'Call printoperation()
        '    ''End If
        'Catch ex As Exception
        '    MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End Try

    End Sub


    Private Sub Calculate()
        Try
            Dim ValQty As Double
            Dim Calqty As Double
            Dim Itemcode As String
            Dim i, j As Integer
            '  If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 3 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Then




            Me.Txt_qty.Text = ""

            For i = 1 To AxfpSpread1.DataRowCnt

                AxfpSpread1.Col = 6
                AxfpSpread1.Row = i
                If AxfpSpread1.Text <> "Y" Then
                    AxfpSpread1.Col = 4
                    ValQty = Val(AxfpSpread1.Text)
                    Me.Txt_qty.Text = Format(Val(Me.Txt_qty.Text) + Val(ValQty), "0.000")
                End If

            Next i
            '  ValQty = 0
            Me.txt_Totalamount.Text = ""

            For i = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 6
                If AxfpSpread1.Text <> "Y" Then
                    AxfpSpread1.Col = 8
                    ValQty = Val(AxfpSpread1.Text)
                    Me.txt_Totalamount.Text = Format(Val(Me.txt_Totalamount.Text) + Val(ValQty), "0.000")
                End If

            Next i

            'End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub btn_Auto_fill_Click(sender As Object, e As EventArgs) Handles btn_Auto_fill.Click
        Dim i As Integer

        Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Indentdate.Value), "yyyy/MM/dd"))
        If checkBdate = True Then
            MsgBox("Business date closed..")
            Exit Sub
        End If
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill  Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            TXT_FROMSTORECODE.Focus()
            Exit Sub
        End If

        If (txt_storecode.Text = "") Then
            MessageBox.Show("Please Fill  Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_storecode.Focus()
            Exit Sub
        End If

        Dim sql As String

        Me.Cursor = Cursors.WaitCursor
        Dim sqlstring As String


    

        sqlstring = "SELECT C.ITEMCODE,itemname,UOM,TRNDATE,TRNS_SEQ,storecode,closingstock,rate FROM CLOSINGQTY C INNER JOIN INV_InventoryItemMaster IV ON IV.itemcode=C.itemcode WHERE storecode='" & TXT_FROMSTORECODE.Text & "' AND CAST(TRNDATE AS DATE)<=CAST('" & Format(CDate(dtp_Indentdate.Value), "yyyy/MM/dd") & "' AS DATE)   "
        sqlstring = sqlstring & " AND CAST(TRNS_SEQ AS CHAR)+CAST(C.itemcode AS CHAR) IN (SELECT CAST(MAX(TRNS_SEQ) AS CHAR)+ CAST(itemcode AS CHAR) FROM CLOSINGQTY WHERE  ITEMCODE IN (SELECT ITEMCODE FROM INVENTORY_INDENTDET WHERE INDENT_NO IN ( select MAX(INDENT_NO) from inventory_indenthdr where fromStoreCode='" + TXT_FROMSTORECODE.Text + "' AND STORELOCATIONCODE='" + txt_storecode.Text + "' and isnull(void,'N')<>'Y' )) AND "
        sqlstring = sqlstring & " storecode='" & TXT_FROMSTORECODE.Text & "' AND CAST( TRNDATE AS DATE)<= CAST('" & Format(CDate(dtp_Indentdate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY itemcode) AND ISNULL(CLOSINGSTOCK,0)>0 AND  iv.Category in (Select categorycode from Categoryuserdetail where usercode='" & gUsername & "')  order by c.itemcode"

        gconnection.getDataSet(sqlstring, "stocksummary")
        If gdataset.Tables("stocksummary").Rows.Count > 0 Then

            For i = 0 To gdataset.Tables("stocksummary").Rows.Count - 1

                AxfpSpread1.Row = i + 1
                AxfpSpread1.Col = 1
                AxfpSpread1.Lock = True
                AxfpSpread1.SetText(1, i + 1, Trim(gdataset.Tables("stocksummary").Rows(i).Item("ITEMCODE")))

                AxfpSpread1.SetText(2, i + 1, Trim(gdataset.Tables("stocksummary").Rows(i).Item("ITEMNAME")))


                AxfpSpread1.SetText(3, i + 1, Trim(gdataset.Tables("stocksummary").Rows(i).Item("UOM")))
                AxfpSpread1.Col = 3
                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("stocksummary").Rows(i).Item("UOM"))
                AxfpSpread1.Text = Trim(gdataset.Tables("stocksummary").Rows(i).Item("UOM"))

                AxfpSpread1.SetText(4, i + 1, Format(Val(0), "0.000"))
                'AxfpSpread1.SetText(5, i + 1, Trim(gdataset.Tables("StockConsumption_1").Rows(i).Item("BATCHNO")))
                AxfpSpread1.SetText(5, i + 1, Format(Val(gdataset.Tables("stocksummary").Rows(i).Item("closingstock")), "0.000"))
                
            Next i
            AxfpSpread1.Col = 0
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 2
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 3
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 4
            AxfpSpread1.Lock = False
            AxfpSpread1.Col = 6
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 7
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 8
            AxfpSpread1.Lock = True

        Else
            MsgBox("NO ITEM AVILABLE FOR INDENT  ")
        End If
        If gUserCategory <> "S" Then
            ' Call GetRights()
        End If
        '   TotalCount = gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count
        AxfpSpread1.SetActiveCell(4, 1)
        Me.Cursor = Cursors.Default
    End Sub

    
    Private Sub AxfpSpread1_Advance(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread1.Advance

    End Sub

    Private Sub lbl_closingqty_Click(sender As Object, e As EventArgs) Handles lbl_closingqty.Click

    End Sub

    Private Sub lbl_Freeze_Click(sender As Object, e As EventArgs) Handles lbl_Freeze.Click

    End Sub

    Private Sub AxfpSpread1_KeyPressEvent(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_KeyPressEvent) Handles AxfpSpread1.KeyPressEvent



        Dim i As Integer
        Dim SQL As String
        Dim itemcode As String
        i = AxfpSpread1.ActiveRow

        If AxfpSpread1.ActiveCol = 4 Then
            AxfpSpread1.Col = 4
            AxfpSpread1.Row = i

            If Val(AxfpSpread1.Text) < 0 Then
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            Else

                Dim issuedqty As Double = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 7
                Dim RATE As Double = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 8
                AxfpSpread1.Text = issuedqty * RATE
                AxfpSpread1.Col = 1
                itemcode = AxfpSpread1.Text
                If UCase(gShortname) = "BRC" Then
                    AxfpSpread1.Col = 5
                    Dim clqty As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 4
                    If clqty <= Val(AxfpSpread1.Text) Then
                        AxfpSpread1.Text = clqty
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        '  AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    End If
                ElseIf UCase(gShortname) = "RCL" Or UCase(gShortname) = "HIND" Then

                    AxfpSpread1.Col = 5
                    Dim clqty As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 4
                    If clqty < Val(AxfpSpread1.Text) Then
                        MessageBox.Show(itemcode + " has closing qty is " + clqty.ToString() + " in " & TXT_FROMSTORECODE.Text.ToUpper(), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.Text = clqty
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        'AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    End If
                ElseIf UCase(gShortname) = "KGA" Or UCase(gShortname) = "SKYYE" Then
                    AxfpSpread1.Col = 5
                    Dim clqty As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 4
                    If clqty < Val(AxfpSpread1.Text) Then
                        MessageBox.Show(itemcode + " has closing qty is " + clqty.ToString() + " in " & TXT_FROMSTORECODE.Text.ToUpper(), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.Text = clqty
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        '  AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    End If
                Else
                    ' AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                End If

                AxfpSpread1.Col = 4

                check_MinMaxQTY("X", Trim(txt_storecode.Text), itemcode, Val(AxfpSpread1.Text))

                check_MinMaxQTY("N", Trim(TXT_FROMSTORECODE.Text), itemcode, Val(AxfpSpread1.Text))

            End If


            Calculate()
        End If

    End Sub

    Private Sub AxfpSpread1_LeaveCell(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread1.LeaveCell

        Dim i As Integer
        Dim SQL As String
        Dim itemcode As String
        i = AxfpSpread1.ActiveRow

        If AxfpSpread1.ActiveCol = 4 Then
            AxfpSpread1.Col = 4
            AxfpSpread1.Row = i

            If Val(AxfpSpread1.Text) = 0 Then
                'AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            Else
                Dim issuedqty As Double = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 7
                Dim RATE As Double = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 8
                AxfpSpread1.Text = issuedqty * RATE
                AxfpSpread1.Col = 1
                itemcode = AxfpSpread1.Text
                If UCase(gShortname) = "BRC" Then
                    AxfpSpread1.Col = 5
                    Dim clqty As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 4
                    If clqty <= Val(AxfpSpread1.Text) Then
                        AxfpSpread1.Text = clqty
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    End If
                ElseIf UCase(gShortname) = "RCL" Or UCase(gShortname) = "HIND" Then

                    AxfpSpread1.Col = 5
                    Dim clqty As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 4
                    If clqty < Val(AxfpSpread1.Text) Then
                        MessageBox.Show(itemcode + " has closing qty is " + clqty.ToString() + " in " & TXT_FROMSTORECODE.Text.ToUpper(), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.Text = clqty
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    End If
                ElseIf UCase(gShortname) = "KGA" Or UCase(gShortname) = "SKYYE" Then
                    AxfpSpread1.Col = 5
                    Dim clqty As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 4
                    If clqty < Val(AxfpSpread1.Text) Then
                        MessageBox.Show(itemcode + " has closing qty is " + clqty.ToString() + " in " & TXT_FROMSTORECODE.Text.ToUpper(), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.Text = clqty
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    End If
                Else
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                End If

                AxfpSpread1.Col = 4

                check_MinMaxQTY("X", Trim(txt_storecode.Text), itemcode, Val(AxfpSpread1.Text))

                check_MinMaxQTY("N", Trim(TXT_FROMSTORECODE.Text), itemcode, Val(AxfpSpread1.Text))

            End If


            Calculate()
        End If
    End Sub

    Private Sub CMD_APPROVE_Click(sender As Object, e As EventArgs) Handles CMD_APPROVE.Click
        gSQLString = "SELECT isnull(APPROVE,'')as approve FROM INVENTORY_INDENTHDR WHERE indent_no='" & txt_IndentNo.Text & "' "
        gconnection.getDataSet(gSQLString, "updte")
        Dim APPR As String
        APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
        If APPR = "Y" Then
            MsgBox("This Indent is already Approved ")
            Exit Sub
        End If

        Dim sql, pwd, altpwd As String
        sql = "select isnull(indent_password,'')as indent_password,isnull(indent_altpassword,'')as indent_altpassword from INV_LINKSETUP"
        gconnection.getDataSet(sql, "password")

        pwd = gdataset.Tables("password").Rows(0).Item("indent_password")
        altpwd = gdataset.Tables("password").Rows(0).Item("indent_altpassword")

        Dim Pas As String
        'Pas = InputBox("Enter Approve Password", gCompanyname)
        Dim Cinput As New InputBoxCustom
        Cinput.ShowDialog(Me)
        If Cinput.COMMENT = "" Then
            MessageBox.Show("Password Can't Be Blank")
            Exit Sub
        Else
            Pas = Cinput.COMMENT
        End If
        If Pas = pwd Or Pas = altpwd Then
            MsgBox("Indent Approved Successfully")
            Dim sql1 As String = "update INVENTORY_INDENTHDR set APPROVE='Y' where indent_no='" & txt_IndentNo.Text & "'"
            gconnection.getDataSet(sql1, "updte")
            Cmd_Clear_Click(sender, e)
        Else
            MsgBox("Approve Password is Incorrect")
            Exit Sub
        End If

    End Sub

End Class