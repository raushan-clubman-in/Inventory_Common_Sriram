

Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_Freestock
    Dim gconnection As New GlobalClass
    Dim sqlstring As String

    Private Sub Frm_Freestock_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F6) Then
            clearoperation()
        ElseIf (e.KeyCode = Keys.F9) Then
            Cmd_View_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F10) Then
            Cmd_View_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F11) Then
            Cmd_Exit_Click(sender, e)
        ElseIf (e.KeyCode = Keys.F12) Then
            ButExport_Click(sender, e)
        End If
    End Sub


    Private Sub Frm_Freestock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillItemdetails()

        If UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/01/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        If gUserCategory <> "S" Then
            Call GetRights()
        End If

    End Sub
    Private Sub FillItemdetails()
        Dim i As Integer
        Dim sqlstring As String
        CheckedListBox3.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(SPONSORCODE,'') AS SPONSORCODE,ISNULL(SPONSORDESC,'') AS SPONSORDESC FROM Inv_SponsorMaster where isnull(FREEZE,'N') <> 'Y' ORDER BY SPONSORCODE "
        gconnection.getDataSet(sqlstring, "Inv_SponsorMaster")
        If gdataset.Tables("Inv_SponsorMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("Inv_SponsorMaster").Rows.Count - 1
                With gdataset.Tables("Inv_SponsorMaster").Rows(i)
                    CheckedListBox3.Items.Add(Trim(CStr(.Item("SPONSORCODE"))) & "-->" & Trim(CStr(.Item("SPONSORDESC"))))
                End With
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
    Private Sub GetRights()
        Dim i, x As Integer
        'Dim vmain, vsmod, vssmod As Long
        Dim SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = " Free Stock And Sponsered Stock Report"
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



    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()
    End Sub

    Sub clearoperation()
        ChkFREESTK.Checked = False
        ChkSPONSERED.Checked = False
        txt_mainstore.Text = ""
        txt_mainstorecode.Text = ""
    End Sub


    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub ButExport_Click(sender As Object, e As EventArgs) Handles ButExport.Click
        Dim Heading(0), ITEMcode() As String
        Dim sqlstring, sql As String
        Dim I As Integer

        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub

        If ChkFREESTK.Checked = True Then



            sqlstring = "select * from GRN_DETAILs  where  FreeQty<>'0' "
            sqlstring = sqlstring & " AND cast(convert(varchar(11),grndate,106)as datetime) BETWEEN"
            sqlstring = sqlstring & " '" & Format(CDate(dtpfromdate.Value), "dd/MMM/yyyy") & "' AND ' " & Format(CDate(dtptodate.Value), "dd/MMM/yyyy") & "'"
            sqlstring = sqlstring & " AND STORECODE = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(VOIDITEM,'N')<>'Y' "
            sqlstring = sqlstring & " ORDER BY PONO "

            gconnection.getDataSet(sqlstring, "GRN_DETAILs")
            If gdataset.Tables("GRN_DETAILs").Rows.Count > 0 Then

                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, " Free Stock Received " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Exit Sub
            End If

        ElseIf ChkSPONSERED.Checked = True Then

            sqlstring = "SELECT ISNULL(grndetails,'') AS GRNDETAILS,grndate,Itemcode,Itemname,QTY,RATE,taxper AS 'TAX %',AMOUNT ,SPONSORCODE AS SPONSOR,ISNULL(Remarks,'') AS REMARKS FROM VW_PURCHASEREGISTERNEW WHERE ("
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "   pono IN ("
                For I = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMcode = Split(CheckedListBox3.CheckedItems(I), "-->")
                    sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & "  ) OR "
            If CheckedListBox3.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "   SPONSORCODE IN ("
                For I = 0 To CheckedListBox3.CheckedItems.Count - 1
                    ITEMcode = Split(CheckedListBox3.CheckedItems(I), "-->")
                    sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND cast(convert(varchar(11),grndate,106)as datetime) BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
            sqlstring = sqlstring & " AND STORECODE = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(VOID,'N')<>'Y' "
            sqlstring = sqlstring & " ORDER BY GRNDETAILS "

            gconnection.getDataSet(sqlstring, "VW_PURCHASEREGISTER")
            If gdataset.Tables("VW_PURCHASEREGISTER").Rows.Count > 0 Then
                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, " Sponsor Stock Received " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If

        End If




    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click

        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub

        If ChkFREESTK.Checked = True Then
            Call Freestock()
        ElseIf ChkSPONSERED.Checked = True Then
            Call Sponsersstock()
        ElseIf CheckBox1.Checked = True Then
            Call FULLDISCOUNT()
        Else
            MsgBox("Select any Opetion  ", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Freestock()
        Dim rViewer As New Viewer
        Dim r As New FReEStockREpoRt
        Dim Heading(0) As String
        Dim sqlstring As String

        If txt_mainstorecode.Text <> "" Then

        Else
            MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        sqlstring = "select * from GRN_DETAILs  where  FreeQty<>'0' "
        sqlstring = sqlstring & " AND cast(convert(varchar(11),grndate,106)as datetime) BETWEEN"
        sqlstring = sqlstring & " '" & Format(CDate(dtpfromdate.Value), "dd/MMM/yyyy") & "' AND ' " & Format(CDate(dtptodate.Value), "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & " AND STORECODE = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(VOIDITEM,'N')<>'Y' "
        sqlstring = sqlstring & " ORDER BY PONO "

        gconnection.getDataSet(sqlstring, "GRN_DETAILs")
        If gdataset.Tables("GRN_DETAILs").Rows.Count > 0 Then
            rViewer.Report = r
            rViewer.ssql = sqlstring
            rViewer.TableName = "GRN_DETAILs"
            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
            TXTOBJ1.Text = MyCompanyName

            Dim TXTOBJ19 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ19 = r.ReportDefinition.ReportObjects("Text6")
            TXTOBJ19.Text = gFinancalyearStart + "-" + gFinancialyearEnd

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text4")
            TXTOBJ16.Text = Format(dtpfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtptodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text17")
            TXTOBJ5.Text = UCase(Address1)
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text18")
            TXTOBJ6.Text = UCase(Address2)

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text9")
            'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text10")
            'TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Dim TXTOBJ3 As TextObject
            TXTOBJ3 = r.ReportDefinition.ReportObjects("Text4")
            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
            rViewer.Show()

        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub Sponsersstock()
        Dim rViewer As New Viewer
        Dim r As New SponsorsStocklReport
        Dim Heading(0), ITEMcode() As String
        Dim sqlstring, sql As String
        Dim I As Integer

        If txt_mainstorecode.Text <> "" Then

        Else
            MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        sqlstring = "SELECT * FROM VW_PURCHASEREGISTERnEW WHERE ("
        If CheckedListBox3.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "   pono IN ("
            For I = 0 To CheckedListBox3.CheckedItems.Count - 1
                ITEMcode = Split(CheckedListBox3.CheckedItems(I), "-->")
                sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        Else
            MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        sqlstring = sqlstring & "  ) OR "
        If CheckedListBox3.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & "   SPONSORCODE IN ("
            For I = 0 To CheckedListBox3.CheckedItems.Count - 1
                ITEMcode = Split(CheckedListBox3.CheckedItems(I), "-->")
                sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        Else
            MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        sqlstring = sqlstring & " AND cast(convert(varchar(11),grndate,106)as datetime) BETWEEN"
        sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & " AND STORECODE = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(VOID,'N')<>'Y' "
        sqlstring = sqlstring & " ORDER BY GRNDETAILS "

       

        ' sql = "SELECT * FROM Inv_SponsorMaster"
        '  gconnection.getDataSet(sql, "Inv_SponsorMaster")
        gconnection.getDataSet(sqlstring, "VW_PURCHASEREGISTER")
        If gdataset.Tables("VW_PURCHASEREGISTER").Rows.Count > 0 Then
            rViewer.Report = r
            rViewer.ssql = sqlstring
            rViewer.TableName = "VW_PURCHASEREGISTER"
            ' rViewer.ssql = sql
            'rViewer.TableName = "Inv_SponsorMaster"
            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text4")
            TXTOBJ1.Text = MyCompanyName

            'Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ16 = r.ReportDefinition.ReportObjects("Text8")
            'TXTOBJ16.Text = Format(dtpfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtptodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text13")
            TXTOBJ5.Text = UCase(Address1)
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text18")
            TXTOBJ6.Text = UCase(Address2)

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text3")
            'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text10")
            'TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Dim TXTOBJ3 As TextObject
            TXTOBJ3 = r.ReportDefinition.ReportObjects("Text8")
            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
            rViewer.Show()

        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
 
    Private Sub FULLDISCOUNT()
        Dim rViewer As New Viewer
        Dim r As New DiscountStocklReport
        Dim Heading(0), ITEMcode() As String
        Dim sqlstring, sql As String
        Dim I As Integer

        If txt_mainstorecode.Text <> "" Then

        Else
            MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        sqlstring = "SELECT * FROM VW_PURCHASEREGISTER WHERE   cast (discper as numeric)<>0 and "
        'If CheckedListBox3.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & "   pono IN ("
        '    For I = 0 To CheckedListBox3.CheckedItems.Count - 1
        '        ITEMcode = Split(CheckedListBox3.CheckedItems(I), "-->")
        '        sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'Else
        '    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End If
        'sqlstring = sqlstring & "  ) OR "
        'If CheckedListBox3.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & "   SPONSORCODE IN ("
        '    For I = 0 To CheckedListBox3.CheckedItems.Count - 1
        '        ITEMcode = Split(CheckedListBox3.CheckedItems(I), "-->")
        '        sqlstring = sqlstring & "'" & ITEMcode(0) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'Else
        '    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End If
        sqlstring = sqlstring & "  cast(convert(varchar(11),grndate,106)as datetime) BETWEEN"
        sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & " AND STORECODE = '" & Trim(txt_mainstorecode.Text) & "' AND ISNULL(VOID,'N')<>'Y' "
        sqlstring = sqlstring & " ORDER BY GRNDETAILS "



        ' sql = "SELECT * FROM Inv_SponsorMaster"
        '  gconnection.getDataSet(sql, "Inv_SponsorMaster")
        gconnection.getDataSet(sqlstring, "VW_PURCHASEREGISTER")
        If gdataset.Tables("VW_PURCHASEREGISTER").Rows.Count > 0 Then
            rViewer.Report = r
            rViewer.ssql = sqlstring
            rViewer.TableName = "VW_PURCHASEREGISTER"
            ' rViewer.ssql = sql
            'rViewer.TableName = "Inv_SponsorMaster"
            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text4")
            TXTOBJ1.Text = MyCompanyName

            'Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            'TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text11")
            TXTOBJ5.Text = UCase(Address1)
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text16")
            TXTOBJ6.Text = UCase(Address2)

            Dim TXTOBJ19 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ19 = r.ReportDefinition.ReportObjects("Text9")
            TXTOBJ19.Text = gFinancalyearStart + "-" + gFinancialyearEnd

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text3")
            'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text10")
            'TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Dim TXTOBJ3 As TextObject
            TXTOBJ3 = r.ReportDefinition.ReportObjects("Text8")
            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
            rViewer.Show()

        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub txt_mainstorecode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_mainstorecode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_mainstorecode.Text) = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
            Else
                Call txt_mainstorecode_Validated(sender, e)
                dtpfromdate.Focus()
            End If
        End If
    End Sub
    Public Function Checkdaterangevalidate(ByVal Startdate As Date, ByVal Enddate As Date) As Boolean
        chkdatevalidate = True
        If DateDiff(DateInterval.Day, Enddate, DateValue(Now)) < 0 Then
            MessageBox.Show("To Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            chkdatevalidate = False
            Exit Function
        End If
        If DateDiff(DateInterval.Day, Startdate, Enddate) < 0 Then
            MessageBox.Show("From Date cannot be greater than To Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            chkdatevalidate = False
            Exit Function
        End If
        If CDate(Startdate) >= CDate(Startdate) And CDate(Enddate) <= CDate(Enddate) Then
            chkdatevalidate = True
        Else
            MsgBox("Date should be within Financial Year", MsgBoxStyle.Critical)
            chkdatevalidate = False
            Exit Function
        End If
        Return chkdatevalidate
    End Function

    Private Sub txt_mainstorecode_TextChanged(sender As Object, e As EventArgs) Handles txt_mainstorecode.TextChanged

    End Sub

    Private Sub txt_mainstorecode_Validated(sender As Object, e As EventArgs) Handles txt_mainstorecode.Validated
        Try
            If Trim(txt_mainstorecode.Text) <> "" Then
                sqlstring = "SELECT * FROM storemaster WHERE storecode='" & Trim(txt_mainstorecode.Text) & "' AND STORESTATUS='M'"
                gconnection.getDataSet(sqlstring, "storemaster")
                If gdataset.Tables("storemaster").Rows.Count > 0 Then
                    txt_mainstorecode.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                    txt_mainstore.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                    dtpfromdate.Focus()
                End If
            End If
        Catch
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_storecode_Click(sender As Object, e As EventArgs) Handles cmd_storecode.Click
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
        M_WhereCondition = " where freeze <> 'Y'  AND STORESTATUS='M'"
        Dim vform As New ListOperattion1

        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "             STORE CODE                   |                   STORE DESCRIPTION                             "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_mainstorecode.Text = Trim(vform.keyfield & "")
            txt_mainstore.Text = Trim(vform.keyfield1 & "")
            dtpfromdate.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFREESTK.CheckedChanged
        If ChkFREESTK.Checked = True Then
            ChkSPONSERED.Checked = False
            CheckBox1.Checked = False
            GroupBox4.Visible = False
        End If
    End Sub

    Private Sub ChkSPONSERED_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSPONSERED.CheckedChanged
        If ChkSPONSERED.Checked = True Then
            ChkFREESTK.Checked = False
            CheckBox1.Checked = False
            GroupBox4.Visible = True
        Else
            GroupBox4.Visible = False
        End If
    End Sub

    Private Sub ChkItemCode_CheckedChanged(sender As Object, e As EventArgs) Handles ChkItemCode.CheckedChanged
        Dim i As Integer = 0
        If (ChkItemCode.Checked = True) Then
            For i = 0 To CheckedListBox3.Items.Count - 1
                CheckedListBox3.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CheckedListBox3.Items.Count - 1
                CheckedListBox3.SetItemChecked(i, False)
            Next

        End If

    End Sub

  

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ChkFREESTK.Checked = False
            ChkSPONSERED.Checked = False
            GroupBox4.Visible = False
        End If
    End Sub
End Class


