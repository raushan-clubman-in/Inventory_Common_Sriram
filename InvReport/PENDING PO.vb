
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_REPORTS
    Dim gconnection As New GlobalClass
    Dim sqlstring As String

    Private Sub Frm_REPORTS_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub Frm_REPORTS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub


    Private Sub Frm_REPORTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If UCase(gShortname) = "RSAOI" Then
            dtpfromdate.Value = Format(CDate("01/01/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtpfromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        dtptodate.Value = Format(Now, "dd/MMM/yyyy")
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        ' ButExport.Enabled = False
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
        GmoduleName = "Pending PO And PO Wise GRN Report"
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
        ChkPoGrn.Checked = False
        Chkpendingpo.Checked = False
        ChkItemmaster.Checked = False
        ChkVendors.Checked = False
        ChkLapsedPO.Checked = False
        txt_mainstore.Text = ""
        txt_mainstorecode.Text = ""
    End Sub


    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub ButExport_Click(sender As Object, e As EventArgs) Handles ButExport.Click

    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click

        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub

        If Chkpendingpo.Checked = True Then
            Call POHDR()
        ElseIf ChkPoGrn.Checked = True Then
            Call GRNHEADER()
        ElseIf ChkItemmaster.Checked = True Then
            Call invitemmaster()
        ElseIf ChkVendors.Checked = True Then
            Call VendorsList()
        ElseIf ChkLapsedPO.Checked = True Then
            Call LapsedPO()

        End If
    End Sub
    Private Sub POHDR()
        Dim rViewer As New Viewer
        Dim r As New PendingposReport
        Dim Heading(0) As String
        Dim sqlstring As String

        If txt_mainstorecode.Text <> "" Then

        Else
            MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        sqlstring = "SELECT * FROM PO_HDR WHERE POSTATUS='PENDING'"
        sqlstring = sqlstring & " AND   CAST(CONVERT(VARCHAR(11),PODATE ,106) AS DATETIME) BETWEEN"
        sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & " AND STORECODE = '" & Trim(txt_mainstorecode.Text) & "' "
        sqlstring = sqlstring & " ORDER BY PONO "

        gconnection.getDataSet(sqlstring, "PO_HDR")
        If gdataset.Tables("PO_HDR").Rows.Count > 0 Then
            rViewer.Report = r
            rViewer.ssql = sqlstring
            rViewer.TableName = "PO_HDR"

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text9")
            TXTOBJ5.Text = MyCompanyName

            'Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            'TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text14")
            'TXTOBJ5.Text = "UserName : " & gUsername
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text15")
            'TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text16")
            'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
            'TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Dim TXTOBJ3 As TextObject
            TXTOBJ3 = r.ReportDefinition.ReportObjects("Text1")
            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
            rViewer.Show()

        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub GRNHEADER()
        Dim rViewer As New Viewer
        Dim r As New PowiseGRNreport
        Dim Heading(0) As String
        Dim sqlstring As String

        If txt_mainstorecode.Text <> "" Then

        Else
            MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        sqlstring = "SELECT * FROM VIEW_POWISEGRN WHERE "
        sqlstring = sqlstring & "   CAST(CONVERT(VARCHAR(11),PODATE ,106) AS DATETIME) BETWEEN"
        sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & " AND STORECODE = '" & Trim(txt_mainstorecode.Text) & "' "
        sqlstring = sqlstring & " ORDER BY PONO"


        gconnection.getDataSet(sqlstring, "VIEW_POWISEGRN")
        If gdataset.Tables("VIEW_POWISEGRN").Rows.Count > 0 Then

            rViewer.Report = r
            rViewer.ssql = sqlstring
            rViewer.TableName = "VIEW_POWISEGRN"
            'Dim TXTOBJ1 As CrystalDecisions.CrystalReportSs.Engine.TextObject
            'TXTOBJ1 = r.ReportDefinition.ReportObjects("Text19")
            ''TXTOBJ1.Text = MyCompanyName

            'Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            'TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text6")
            ''TXTOBJ5.Text = "UserName : " & gUsername
            'Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ6 = r.ReportDefinition.ReportObjects("Text7")
            ''TXTOBJ6.Text = Address1 & Address2

            'Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ8 = r.ReportDefinition.ReportObjects("Text8")
            ''TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text4")
            ''TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Dim TXTOBJ3 As TextObject
            TXTOBJ3 = r.ReportDefinition.ReportObjects("Text2")
            TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
            rViewer.Show()

        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub invitemmaster()
        Dim rViewer As New Viewer
        Dim r As New Invitemmaster
        Dim Heading(0) As String
        Dim sqlstring As String

        'sqlstring = "SELECT * FROM INV_InventoryItemMaster "
        sqlstring = "SELECT A.itemcode ,a.itemname ,a.groupcode ,a.subGroupcode ,a.category ,a.STOCKUOM ,a.STOCKCATEGORY ,b.storecode  as abccategory from INV_InventoryItemMaster A ,inv_InventoryOpenningstock B WHERE A.itemcode = b.itemcode"
        'sqlstring = sqlstring & " AND PODATE BETWEEN"
        'sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & " AND b.STORECODE = '" & Trim(txt_mainstorecode.Text) & "' "
        sqlstring = sqlstring & " ORDER BY a.ITEMCODE"


        gconnection.getDataSet(sqlstring, "INV_InventoryItemMaster")
        If gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0 Then

            rViewer.Report = r
            rViewer.ssql = sqlstring
            rViewer.TableName = "INV_InventoryItemMaster"


            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text2")
            TXTOBJ5.Text = MyCompanyName

            'Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            'TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text6")
            'TXTOBJ5.Text = "UserName : " & gUsername
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text7")
            'TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text8")
            'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text9")
            'TXTOBJ9.Text = "PhoneNo : " & gphoneno

            'Dim TXTOBJ3 As TextObject
            'TXTOBJ3 = r.ReportDefinition.ReportObjects("Text1")
            'TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
            rViewer.Show()

        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub VendorsList()
        Dim rViewer As New Viewer
        Dim r As New VendorsListReport
        Dim Heading(0) As String
        Dim sqlstring As String

        sqlstring = "SELECT * FROM ACCOUNTSSUBLEDGERMASTER  WHERE sltype='SUPPLIER' AND  accode='a4140'"
        'sqlstring = sqlstring & " AND PODATE BETWEEN"
        'sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
        'sqlstring = sqlstring & " AND STORECODE = '" & Trim(txt_mainstorecode.Text) & "' "
        sqlstring = sqlstring & " ORDER BY slcode"


        gconnection.getDataSet(sqlstring, "ACCOUNTSSUBLEDGERMASTER")
        If gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows.Count > 0 Then

            rViewer.Report = r
            rViewer.ssql = sqlstring
            rViewer.TableName = "ACCOUNTSSUBLEDGERMASTER"
            'Dim TXTOBJ1 As CrystalDecisions.CrystalReportSs.Engine.TextObject
            'TXTOBJ1 = r.ReportDefinition.ReportObjects("Text19")
            ''TXTOBJ1.Text = MyCompanyName

            'Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            'TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text1")
            TXTOBJ5.Text = MyCompanyName
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text7")
            'TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text8")
            'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text9")
            'TXTOBJ9.Text = "PhoneNo : " & gphoneno

            'Dim TXTOBJ3 As TextObject
            'TXTOBJ3 = r.ReportDefinition.ReportObjects("Text1")
            'TXTOBJ3.Text = Format(dtpfromdate.Value, "dd/MM/yyyy") & " To " & " " & Format(dtptodate.Value, "dd/MM/yyyy") & ""
            rViewer.Show()

        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub LapsedPO()
        Dim rViewer As New Viewer
        Dim r As New LapsedPO
        Dim Heading(0) As String
        Dim sqlstring As String

        If txt_mainstorecode.Text <> "" Then

        Else
            MessageBox.Show("Select the Store code", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        sqlstring = "SELECT  * FROM PO_HDR WHERE  pono not in(select pono from grn_header)  and povalidupto <= getdate() and povalidupto <= dateadd (day , 90 ,getdate())"
        sqlstring = sqlstring & " AND   CAST(CONVERT(VARCHAR(11),PODATE ,106) AS DATETIME) BETWEEN"
        sqlstring = sqlstring & " '" & Format(dtpfromdate.Value, "dd/MMM/yyyy") & "' AND ' " & Format(dtptodate.Value, "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & " AND STORECODE = '" & Trim(txt_mainstorecode.Text) & "' "
        'sqlstring = sqlstring & " ORDER BY PONO "

        gconnection.getDataSet(sqlstring, "PO_HDR")
        If gdataset.Tables("PO_HDR").Rows.Count > 0 Then
            rViewer.Report = r
            rViewer.ssql = sqlstring
            rViewer.TableName = "PO_HDR"
            'Dim TXTOBJ1 As CrystalDecisions.CrystalReportSs.Engine.TextObject
            'TXTOBJ1 = r.ReportDefinition.ReportObjects("Text19")
            ''TXTOBJ1.Text = MyCompanyName

            'Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            'TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text1")
            TXTOBJ5.Text = MyCompanyName
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text8")
            'TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text9")
            'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text10")
            'TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Dim TXTOBJ3 As TextObject
            TXTOBJ3 = r.ReportDefinition.ReportObjects("Text6")
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

    Private Sub Chkpendingpo_CheckedChanged(sender As Object, e As EventArgs) Handles Chkpendingpo.CheckedChanged
        If Chkpendingpo.Checked = True Then
            ChkPoGrn.Checked = False
        End If
    End Sub

    Private Sub ChkPoGrn_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPoGrn.CheckedChanged
        If ChkPoGrn.Checked = True Then
            Chkpendingpo.Checked = False
            ChkItemmaster.Checked = False
            ChkVendors.Checked = False
            ChkLapsedPO.Checked = False
        End If
    End Sub

    Private Sub ChkItemmaster_CheckedChanged(sender As Object, e As EventArgs) Handles ChkItemmaster.CheckedChanged
        If ChkItemmaster.Checked = True Then
            Chkpendingpo.Checked = False
            ChkPoGrn.Checked = False
            ChkVendors.Checked = False
            ChkLapsedPO.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkVendors.CheckedChanged
        If ChkVendors.Checked = True Then
            ChkItemmaster.Checked = False
            Chkpendingpo.Checked = False
            ChkPoGrn.Checked = False
            ChkLapsedPO.Checked = False

        End If
    End Sub


    Private Sub ChkLapsedPO_CheckedChanged(sender As Object, e As EventArgs) Handles ChkLapsedPO.CheckedChanged
        If ChkLapsedPO.Checked = True Then
            ChkVendors.Checked = False
            ChkItemmaster.Checked = False
            Chkpendingpo.Checked = False
            ChkPoGrn.Checked = False
        End If
    End Sub
End Class
