Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine


Public Class AuditTrail
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Dim ITEM As String
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

    Private Sub FillVOUCHER()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT VoucherType FROM JOURNALENTRY WHERE  isnull(void,'') <> 'Y' ORDER BY VoucherType ASC"
        gconnection.getDataSet(sqlstring, "JOURNALENTRY")
        ComboBox1.Items.Clear()
        If gdataset.Tables("JOURNALENTRY").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("JOURNALENTRY").Rows.Count - 1
                ComboBox1.Items.Add(gdataset.Tables("JOURNALENTRY").Rows(i).Item("VoucherType"))
            Next i
        End If
    End Sub

    Private Sub AuditTrail_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub AuditTrail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'FillVOUCHER()

        ' Call PostingChecking()

        'dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
            dtpfromdate.Value = Format(Now, "dd/MMM/yyyy")
        ElseIf UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/01/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Audit Trail"
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

    Sub clearoperation()
        '  ChkSupplier.Checked = False
    End Sub
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()

    End Sub

    Private Sub AUDITTRAILREPORTGroupWise()


        Try
            Dim sqlstring, ITEMcode(), STORECODE() As String
            Dim i As Integer
            Dim r As New CryAuditTrialGroupWise
            Dim rViewer As New Viewer
            'Dim ITEM As String
            If Trim(ComboBox1.SelectedItem.ToString()) = "GRN" Then
                ITEM = "GRN"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK ISSUE" Then
                ITEM = "ISSUE"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK CONSUMPTION" Then
                ITEM = "CONSUMPTION"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK TRANSFER" Then
                ITEM = "STOCK TRANSFER"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK DAMAGE" Then
                ITEM = "DAMAGE"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK ADJUSTMENT" Then
                ITEM = "ADJUSTMENT"
            End If

            'Me.Cursor = Cursors.WaitCursor
            'sqlstring = "exec cp_stockDAMAGE"
            'gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " SELECT * FROM JOURNALENTRY  "
            If ComboBox1.SelectedItem <> "" Then
                sqlstring = sqlstring & " WHERE VOUCHERTYPE IN ("
                'For i = 0 To ComboBox1.Sele.Count - 1
                '    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = sqlstring & " '" & Trim(ITEM) & "', "
                'Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Voucher type ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),VOUCHERDATE ,106) AS DATETIME) BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' and isnull(void,'N')<>'Y' ORDER BY VOUCHERDATE"
            gconnection.getDataSet(sqlstring, "JOURNALENTRY")
            If gdataset.Tables("JOURNALENTRY").Rows.Count > 0 Then


                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "AUDIT TRAIL"

                sqlstring = " SELECT sum(Amount) as  CreditAmt FROM JOURNALENTRY  "
                If ComboBox1.SelectedItem <> "" Then
                    sqlstring = sqlstring & " WHERE VOUCHERTYPE IN ("
                    'For i = 0 To ComboBox1.Sele.Count - 1
                    '    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                    sqlstring = sqlstring & " '" & Trim(ITEM) & "', "
                    'Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Voucher type ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),VOUCHERDATE ,106) AS DATETIME) BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' and CreditDebit='Credit' and isnull(void,'N')<>'Y'"
                gconnection.getDataSet(sqlstring, "CreditAmt")
                If gdataset.Tables("CreditAmt").Rows.Count > 0 Then
                    Dim textobj11 As TextObject
                    textobj11 = r.ReportDefinition.ReportObjects("Text15")
                    textobj11.Text = gdataset.Tables("CreditAmt").Rows(0).Item("CreditAmt")
                End If

                sqlstring = " SELECT sum(Amount) as DEBITAmt  FROM JOURNALENTRY  "
                If ComboBox1.SelectedItem <> "" Then
                    sqlstring = sqlstring & " WHERE VOUCHERTYPE IN ("
                    'For i = 0 To ComboBox1.Sele.Count - 1
                    '    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                    sqlstring = sqlstring & " '" & Trim(ITEM) & "', "
                    'Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Voucher type ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),VOUCHERDATE ,106) AS DATETIME) BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' and CreditDebit='DEBIT' and isnull(void,'N')<>'Y'"
                gconnection.getDataSet(sqlstring, "DEBITAmt")
                If gdataset.Tables("DEBITAmt").Rows.Count > 0 Then
                    Dim textobj13 As TextObject
                    textobj13 = r.ReportDefinition.ReportObjects("Text19")
                    textobj13.Text = gdataset.Tables("DEBITAmt").Rows(0).Item("DEBITAmt")
                End If

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName

                'Dim textobj5 As TextObject
                'textobj5 = r.ReportDefinition.ReportObjects("Text15")
                'textobj5.Text = UCase(gCompanyAddress(0))
                'Dim textobj6 As TextObject
                'textobj6 = r.ReportDefinition.ReportObjects("Text16")
                'textobj6.Text = UCase(gCompanyAddress(1))

                'Dim textobj2 As TextObject
                'textobj2 = r.ReportDefinition.ReportObjects("Text13")
                ' textobj2.Text = Trim(txt_mainstore.Text)
                Dim textobj22 As TextObject
                textobj22 = r.ReportDefinition.ReportObjects("Text7")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text8")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

                rViewer.Show()
                Me.Cursor = Cursors.Default



            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



    End Sub


    Private Sub AUDITTRAILREPORTExceptonVoucher()


        
        Try
            Dim sqlstring, ITEMcode(), STORECODE(), sql As String
            Dim i As Integer
            Dim r As New CryAuditTrialExVoucher
            Dim rViewer As New Viewer
            'Dim ITEM As String
            If Trim(ComboBox1.SelectedItem.ToString()) = "GRN" Then
                ITEM = "GRN"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK ISSUE" Then
                ITEM = "ISSUE"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK CONSUMPTION" Then
                ITEM = "CONSUMPTION"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK TRANSFER" Then
                ITEM = "STOCK TRANSFER"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK DAMAGE" Then
                ITEM = "DAMAGE"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK ADJUSTMENT" Then
                ITEM = "ADJUSTMENT"
            End If

            'Me.Cursor = Cursors.WaitCursor
            'sqlstring = "exec cp_stockDAMAGE"
            'gconnection.ExcuteStoreProcedure(sqlstring)

            gconnection.dataOperation1(6, "delete from Inv_JOURNALENTRY")
            sqlstring = " insert into Inv_JOURNALENTRY (VoucherNo,VoucherDate,AccountCode,AccountcodeDesc,SLCode,SLDesc,CostCenterCode,CostCenterDesc,CreditDebit,Amount) select VoucherNo,VoucherDate,AccountCode,AccountcodeDesc,SLCode,SLDesc,CostCenterCode,CostCenterDesc,CreditDebit,Amount FROM JOURNALENTRY  "
            If ComboBox1.SelectedItem <> "" Then
                sqlstring = sqlstring & " WHERE VOUCHERTYPE IN ("
                'For i = 0 To ComboBox1.Sele.Count - 1
                '    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = sqlstring & " '" & Trim(ITEM) & "', "
                'Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Voucher type ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),VOUCHERDATE ,106) AS DATETIME) BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' and isnull(void,'N')<>'Y' ORDER BY VOUCHERDATE"
            gconnection.getDataSet(sqlstring, "JOURNALENTRY")

            sqlstring = "update Inv_JOURNALENTRY set DRAmt=amount where CreditDebit='Debit'"
            gconnection.dataOperation1(6, sqlstring)
            sqlstring = "update Inv_JOURNALENTRY set CRAmt=amount where CreditDebit='Credit'"
            gconnection.dataOperation1(6, sqlstring)

            sqlstring = "update Inv_JOURNALENTRY set AccountcodeDesc=acdesc from Inv_JOURNALENTRY, accountsglaccountmaster where AccountCode=accode "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "select * from Inv_JOURNALENTRY  where VOUCHERNO+cast(cast (VoucherDate as date)as varchar) in (select dr.VOUCHERNO+cast(cast (dr.VoucherDate as date)as varchar) from Vw_AuditTrail_Dr dr inner join Vw_AuditTrail_Cr cr on dr.VOUCHERNO=cr.VOUCHERNO  AND dr.vouchertype=cr.vouchertype and cast (dr.voucherdate as date)=cast (Cr.voucherdate as date) where round(dr.amount,0)<>round(cr.amount,0) AND DR.VOUCHERTYPe='" & Trim(ITEM) & "' )"
            gconnection.getDataSet(sqlstring, "JOURNALENTRY_DEMO")


            If gdataset.Tables("JOURNALENTRY_DEMO").Rows.Count > 0 Then



                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "AUDIT TRAIL"

           

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName

                Dim textobj22 As TextObject
                textobj22 = r.ReportDefinition.ReportObjects("Text7")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text8")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MMM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        If CheckBox1.Checked = True Then
            AUDITTRAILREPORTGroupWise()
        ElseIf CheckBox2.Checked = True Then
            AUDITTRAILREPORTExceptonVoucher()
        Else
            AUDITTRAILREPORT()
        End If
    End Sub

    Private Sub AUDITTRAILREPORT()


        Try
            Dim sqlstring, ITEMcode(), STORECODE(), sql As String
            Dim i As Integer
            Dim r As New CryAuditTrial
            Dim rViewer As New Viewer
            'Dim ITEM As String
            If Trim(ComboBox1.SelectedItem.ToString()) = "GRN" Then
                ITEM = "GRN"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK ISSUE" Then
                ITEM = "ISSUE"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK CONSUMPTION" Then
                ITEM = "CONSUMPTION"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK TRANSFER" Then
                ITEM = "STOCK TRANSFER"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK DAMAGE" Then
                ITEM = "DAMAGE"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK ADJUSTMENT" Then
                ITEM = "ADJUSTMENT"
            End If

            'Me.Cursor = Cursors.WaitCursor
            'sqlstring = "exec cp_stockDAMAGE"
            'gconnection.ExcuteStoreProcedure(sqlstring)

            gconnection.dataOperation1(6, "delete from Inv_JOURNALENTRY")
            sqlstring = " insert into Inv_JOURNALENTRY (VoucherNo,VoucherDate,AccountCode,AccountcodeDesc,SLCode,SLDesc,CostCenterCode,CostCenterDesc,CreditDebit,Amount) select VoucherNo,VoucherDate,AccountCode,AccountcodeDesc,SLCode,SLDesc,CostCenterCode,CostCenterDesc,CreditDebit,Amount FROM JOURNALENTRY  "
            If ComboBox1.SelectedItem <> "" Then
                sqlstring = sqlstring & " WHERE VOUCHERTYPE IN ("
                'For i = 0 To ComboBox1.Sele.Count - 1
                '    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = sqlstring & " '" & Trim(ITEM) & "', "
                'Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Voucher type ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND CAST(CONVERT(VARCHAR(11),VOUCHERDATE ,106) AS DATETIME) BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' and isnull(void,'N')<>'Y' ORDER BY VOUCHERDATE"
            gconnection.getDataSet(sqlstring, "JOURNALENTRY")

            sqlstring = "update Inv_JOURNALENTRY set DRAmt=amount where CreditDebit='Debit'"
            gconnection.dataOperation1(6, sqlstring)
            sqlstring = "update Inv_JOURNALENTRY set CRAmt=amount where CreditDebit='Credit'"
            gconnection.dataOperation1(6, sqlstring)

            sqlstring = "update Inv_JOURNALENTRY set AccountcodeDesc=acdesc from Inv_JOURNALENTRY, accountsglaccountmaster where AccountCode=accode "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "select * from Inv_JOURNALENTRY " 'where VOUCHERNO+cast(cast (VoucherDate as date)as varchar) in (select dr.VOUCHERNO+cast(cast (dr.VoucherDate as date)as varchar) from Vw_AuditTrail_Dr dr inner join Vw_AuditTrail_Cr cr on dr.VOUCHERNO=cr.VOUCHERNO and cast (dr.voucherdate as date)=cast (Cr.voucherdate as date) where round(dr.amount,0)<>round(cr.amount,0) AND DR.VOUCHERTYPe='" & Trim(ITEM) & "' )"
            gconnection.getDataSet(sqlstring, "JOURNALENTRY_DEMO")


            If gdataset.Tables("JOURNALENTRY_DEMO").Rows.Count > 0 Then



                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "AUDIT TRAIL"

                Dim dt As New DataTable
                Dim ds As New DataSet
                dt = gconnection.GetValues(sqlstring)
                dt.TableName = "JOURNALENTRY_DEMO"
                ds.Tables.Add(dt)




                'dt = gconnection.GetValues("select * from Inv_JOURNALENTRY where VOUCHERNO+cast(cast (VoucherDate as date)as varchar) in (select dr.VOUCHERNO+cast(cast (dr.VoucherDate as date)as varchar) from Vw_AuditTrail_Dr dr inner join Vw_AuditTrail_Cr cr on dr.VOUCHERNO=cr.VOUCHERNO and cast (dr.voucherdate as date)=cast (Cr.voucherdate as date) where round(dr.amount,0)<>round(cr.amount,0) AND DR.VOUCHERTYPe='" & Trim(ITEM) & "' )")
                'dt.TableName = "Inv_JOURNALENTRY"
                'ds.Tables.Add(dt)



                sql = "select sum(amount) AS AMOUNT from ACCOUNTPOSTINVENTORYSUMMFROMACCOUNTS WHERE  CREDITDEBIT='DEBIT' AND VOUCHERTYPE IN('" & Trim(ITEM) & "') AND CAST(CONVERT(VARCHAR(11),VOUCHERDATE ,106) AS DATETIME) BETWEEN"
                sql = sql & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "' "


                gconnection.getDataSet(sql, "ACCOUNTPOSTINVENTORYDETAIL")
                If gdataset.Tables("ACCOUNTPOSTINVENTORYDETAIL").Rows.Count > 0 Then

                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text6")
                    textobj6.Text = "TOTAL  " + ITEM + "  AMOUNT  FROM  INVENTORY :  " & gdataset.Tables("ACCOUNTPOSTINVENTORYDETAIL").Rows(0).Item("AMOUNT")
                End If

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName



                'Dim textobj9 As TextObject
                'textobj9 = r.ReportDefinition.ReportObjects("Text9")
                'textobj9.Text = "TOTAL DEBIT " + ITEM + " AMOUNT :"


                Dim textobj22 As TextObject
                textobj22 = r.ReportDefinition.ReportObjects("Text7")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text8")
                TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""

                'rViewer.GetDetails1(ds, r)


                rViewer.Show()
                Me.Cursor = Cursors.Default



            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try



    End Sub





    'Private Sub ChkSupplier_CheckedChanged(sender As Object, e As EventArgs)
    '    Dim i As Integer = 0
    '    If (ChkSupplier.Checked = True) Then
    '        For i = 0 To CheckedListBox1.Items.Count - 1
    '            CheckedListBox1.SetItemChecked(i, True)
    '        Next

    '    Else
    '        For i = 0 To CheckedListBox1.Items.Count - 1
    '            CheckedListBox1.SetItemChecked(i, False)
    '        Next

    '    End If


    'End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub ButExport_Click(sender As Object, e As EventArgs) Handles ButExport.Click
        Try
            If Trim(ComboBox1.SelectedItem.ToString()) = "GRN" Then
                ITEM = "GRN"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK ISSUE" Then
                ITEM = "ISSUE"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK CONSUMPTION" Then
                ITEM = "CONSUMPTION"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK TRANSFER" Then
                ITEM = "STOCK TRANSFER"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK DAMAGE" Then
                ITEM = "DAMAGE"
            ElseIf Trim(ComboBox1.SelectedItem.ToString()) = "STOCK ADJUSTMENT" Then
                ITEM = "ADJUSTMENT"
            End If

            Dim sqlstring As String

            ' Me.Cursor = Cursors.WaitCursor
            'sqlstring = "exec cp_stockDAMAGE"
            'gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = " SELECT voucherno,accountcode,isnull(slcode,'') as slcode,isnull(costcentercode,'') as COSTCENTERCODE,ISNULL(CreditDebit,'') AS CreditDebit, AMOUNT FROM journalentry "
            If ComboBox1.SelectedItem <> "" Then
                sqlstring = sqlstring & " WHERE vouchertype IN ("
                'For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                '    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = sqlstring & " '" & Trim(ITEM) & "') "
                'Next
                ' sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                'sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Voucher Type.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND VOUCHERDATE BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
            gconnection.getDataSet(sqlstring, "JOUNALENTRY")
            If gdataset.Tables("JOUNALENTRY").Rows.Count > 0 Then
                Me.Cursor = Cursors.Default

                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "Audit Trail Register " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")


            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try


    End Sub

    Private Sub Cmd_Print_Click(sender As Object, e As EventArgs) Handles Cmd_Print.Click
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MMM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        AUDITTRAILREPORT()
    End Sub
End Class