Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared

Public Class GROUPORSUBGORUPWISEISSUE
    Dim I As Integer
    Dim gconnection As New GlobalClass
    'Dim CW As Integer = Me.Width ' Current Width
    'Dim CH As Integer = Me.Height ' Current Height
    'Dim IW As Integer = Me.Width ' Initial Width
    'Dim IH As Integer = Me.Height ' Initial Height
    'Dim workingRectangle As System.Drawing.Rectangle = Screen.PrimaryScreen.WorkingArea

    Private Sub invsubgroupissuedetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DTP_FROMDATE.Value = Format(Now, "dd/MM/yyyy")
        DTP_TODATE.Value = Format(Now, "dd/MM/yyyy")
        Call GROUPDETAILS()
        Call SUBGROUPDETAILS()
        Call storedetails()
        If gShortname = "HG" Then
            CHK_GROUPWISE.Visible = False
        End If


        '  Call Resize_Form()
        'IW = Me.Width
        'IH = Me.Height
    End Sub
    'Private Sub Raju_Resize(ByVal sender As Object, _
    '       ByVal e As System.EventArgs) Handles Me.Resize

    '    Dim RW As Double = (Me.Width - CW) / CW ' Ratio change of width
    '    Dim RH As Double = (Me.Height - CH) / CH ' Ratio change of height
    '    For Each Ctrl As Control In Controls
    '        Ctrl.Width += CInt(Ctrl.Width * RW)
    '        Ctrl.Height += CInt(Ctrl.Height * RH)
    '        Ctrl.Left += CInt(Ctrl.Left * RW)
    '        Ctrl.Top += CInt(Ctrl.Top * RH)
    '    Next
    '    CW = Me.Width
    '    CH = Me.Height

    'End Sub
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
                        If Controls(i_i).Name = "GroupBox4" Then
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
                        ElseIf Controls(i_i).Name = "frmbut" Then
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
    Private Sub GROUPDETAILS()

        Dim SQL As String
        SQL = "SELECT * FROM InventoryGroupMaster"
        gconnection.getDataSet(SQL, "ISSUEREGISTER")
        If gdataset.Tables("ISSUEREGISTER").Rows.Count - 1 > 0 Then
            For I = 0 To gdataset.Tables("ISSUEREGISTER").Rows.Count - 1
                With gdataset.Tables("ISSUEREGISTER").Rows(I)
                    CHKLST_GROUPDETAILS.Items.Add(Trim(.Item("GROUPCODE")) & "-->" & Trim(.Item("GROUPDESC")))
                End With

            Next
        End If
    End Sub
    Private Sub storedetails()
        Dim sql As String
        sql = "select DISTINCT OPSTORELOCATIONNAME from STOCKISSUEDETAIL"
        gconnection.getDataSet(sql, "STOCKISSUEDETAIL")
        If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count - 1 > 0 Then
            For I = 0 To gdataset.Tables("STOCKISSUEDETAIL").Rows.Count - 1
                With gdataset.Tables("STOCKISSUEDETAIL").Rows(I)
                    chklist_store.Items.Add(Trim(.Item("OPSTORELOCATIONNAME")))
                End With
            Next
        End If
    End Sub

    Private Sub SUBGROUPDETAILS()

        Dim SQL As String
        SQL = "SELECT * FROM InventorySubGroupMaster"
        gconnection.getDataSet(SQL, "ISGM")
        If gdataset.Tables("ISGM").Rows.Count - 1 > 0 Then
            For i = 0 To gdataset.Tables("ISGM").Rows.Count - 1
                With gdataset.Tables("ISGM").Rows(i)
                    CHKLST_SUBGROUPDETAILS.Items.Add(Trim(.Item("Subgroupcode")) & "-->" & Trim(.Item("Subgroupdesc")))
                End With
            Next
        End If

    End Sub
    Private Sub SUBGROUPWISEISSUEDETAILS()

        Try

            Dim SQL, strgd, strsgd As String
            Dim VIEWER As New Viewer
            Dim R As New SUBGROUPWISEISSUESUMMARY
            Dim R1 As New GROUPWISESALES
            Dim gd(0), sgd(0) As String


            If CHK_SUBGROUPWISE.Checked = True Then
                If CHKLST_SUBGROUPDETAILS.CheckedItems.Count > 0 Then
                    For I = 0 To CHKLST_SUBGROUPDETAILS.CheckedItems.Count - 1
                        gd = Split(CHKLST_SUBGROUPDETAILS.CheckedItems(I), "-->")
                        strgd = strgd & " '" & Trim(gd(1)) & "', "
                    Next
                    strgd = Mid(strgd, 1, Len(strgd) - 2)
                Else
                    MsgBox("please select SUBgroup details", vbInformation)
                End If
                If chklist_store.CheckedItems.Count > 0 Then
                    strsgd = ""
                    sgd = Nothing
                    For I = 0 To chklist_store.CheckedItems.Count - 1
                        sgd = Split(chklist_store.CheckedItems(I), "-->")
                        strsgd = strsgd & " '" & Trim(sgd(0)) & "', "
                    Next
                    strsgd = Mid(strsgd, 1, Len(strsgd) - 2)
                Else
                    MsgBox("Please select store details", vbInformation)
                End If

                SQL = "exec ISSUEDTL'" + Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") + "','" + Format(DTP_TODATE.Value, "dd/MMM/yyyy") + "' "
                gconnection.ExcuteStoreProcedure(SQL)

                SQL = "select storelocationname,SUBGroupcode,SUBGroupDesc,sum(Totamt) as Totamt,OPSTORELOCATIONNAME from vw_SUBgroupwiseissuedetails  where "
                If CHKLST_GROUPDETAILS.Items.Count > 0 Then
                    SQL = SQL & " SUBgroupdesc in ( " & strgd & " ) "
                End If

                If chklist_store.Items.Count > 0 Then
                    SQL = SQL & " AND OPstorelocationname in ( " & strsgd & " ) "
                End If

                'SQL = SQL & " and cast(convert(varchar(11),docdate,106) as date) between '" & Format(DTP_FROMDATE.Value, "yyyy-MM-dd") & "' and '" & Format(DTP_TODATE.Value, "yyyy-MM-dd") & "' "
                SQL = SQL & " GROUP BY  storelocationname,SUBgroupcode,SUBGroupDesc,OPSTORELOCATIONNAME "
                SQL = SQL & " ORDER BY  storelocationname"

                Dim textobj1 As TextObject
                textobj1 = R1.ReportDefinition.ReportObjects("Text1")
                textobj1.Text = MyCompanyName

                Dim textobj6 As TextObject
                textobj6 = R1.ReportDefinition.ReportObjects("Text10")
                textobj6.Text = UCase(gCompanyAddress(0))

                Dim textobj7 As TextObject
                textobj7 = R1.ReportDefinition.ReportObjects("Text15")
                textobj7.Text = UCase(gCompanyAddress(1))

                Call VIEWER.GetDetails(SQL, "vw_SUBgroupwiseissuedetails", R)
                VIEWER.TableName = "vw_SUBgroupwiseissuedetails"
                VIEWER.Show()

            ElseIf CHK_GROUPWISE.Checked = True Then

                If CHKLST_GROUPDETAILS.CheckedItems.Count > 0 Then
                    For I = 0 To CHKLST_GROUPDETAILS.CheckedItems.Count - 1
                        gd = Split(CHKLST_GROUPDETAILS.Items(I), "-->")
                        strgd = strgd & " '" & Trim(gd(0)) & "', "
                    Next
                    strgd = Mid(strgd, 1, Len(strgd) - 2)
                Else
                    MsgBox("please select group details", vbInformation)
                End If
                If CHKLST_SUBGROUPDETAILS.CheckedItems.Count > 0 Then
                    For I = 0 To CHKLST_SUBGROUPDETAILS.CheckedItems.Count - 1
                        sgd = Split(CHKLST_SUBGROUPDETAILS.Items(I), "-->")
                        strsgd = strsgd & " '" & Trim(sgd(0)) & "', "
                    Next
                    strsgd = Mid(strsgd, 1, Len(strsgd) - 2)
                Else
                    MsgBox("Please select subgroup details", vbInformation)
                End If

                'SQL = "EXEC ISSUEDTL '" & DTP_FROMDATE.Value & "' , '" & DTP_TODATE.Value & "'"
                SQL = "exec ISSUEDTL '" + Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") + "','" + Format(DTP_TODATE.Value, "dd/MMM/yyyy") + "'"
                gconnection.ExcuteStoreProcedure(SQL)

                SQL = "select GROUPCODE,GroupDesc,SUBGROUPCODE,subGroupdesc, QTY ,Totamt from vw_subgroupwiseissuedetails where "
                If CHKLST_GROUPDETAILS.Items.Count > 0 Then
                    SQL = SQL & " groupcode in ( " & strgd & " ) "
                End If

                If CHKLST_SUBGROUPDETAILS.Items.Count > 0 Then
                    SQL = SQL & " and subgroupcode in ( " & strsgd & " ) "
                End If

                'SQL = SQL & " and cast(convert(varchar(11),docdate,106) as date) between '" & Format(DTP_FROMDATE.Value, "yyyy-MM-dd") & "' and '" & Format(DTP_TODATE.Value, "yyyy-MM-dd") & "' "
                'SQL = SQL & " GROUP BY GROUPCODE,SUBGROUPCODE,GroupDesc,subGroupdesc "
                'SQL = SQL & " order BY GROUPCODE "


                Dim textobj1 As TextObject
                textobj1 = R.ReportDefinition.ReportObjects("Text6")
                textobj1.Text = MyCompanyName

                Dim textobj6 As TextObject
                textobj6 = R.ReportDefinition.ReportObjects("Text10")
                textobj6.Text = UCase(gCompanyAddress(0))

                Dim textobj7 As TextObject
                textobj7 = R.ReportDefinition.ReportObjects("Text15")
                textobj7.Text = UCase(gCompanyAddress(1))

                Call VIEWER.GetDetails(SQL, "vw_subgroupwiseissuedetails", R)
                VIEWER.TableName = "vw_subgroupwiseissuedetails"
                VIEWER.Show()
            Else
                MsgBox("Please select Groupwise or SubGroupwise", vbInformation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub CHK_GROUPDETAILS_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_GROUPDETAILS.CheckedChanged

        Dim i As Integer
        If CHK_GROUPDETAILS.Checked = True Then
            For i = 0 To CHKLST_GROUPDETAILS.Items.Count - 1
                CHKLST_GROUPDETAILS.SetItemChecked(i, True)
                Call CHK_SUBGROUP()
            Next
        Else
            For i = 0 To CHKLST_GROUPDETAILS.Items.Count - 1
                CHKLST_GROUPDETAILS.SetItemChecked(i, False)
            Next
        End If

    End Sub

    Private Sub CHK_SUBGROUPDETAILS_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_SUBGROUPDETAILS.CheckedChanged


        Dim I As Integer
        If CHK_SUBGROUPDETAILS.Checked = True Then
            For I = 0 To CHKLST_SUBGROUPDETAILS.Items.Count - 1
                CHKLST_SUBGROUPDETAILS.SetItemChecked(I, True)
            Next
        Else
            For I = 0 To CHKLST_SUBGROUPDETAILS.Items.Count - 1
                CHKLST_SUBGROUPDETAILS.SetItemChecked(I, False)
            Next

        End If


    End Sub





    Private Sub Btn_View_Click_1(sender As Object, e As EventArgs) Handles Btn_View.Click
        Call SUBGROUPWISEISSUEDETAILS()
    End Sub

    Private Sub Btn_Exit_Click_1(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Me.Close()
    End Sub

    Private Sub Btn_Clear_Click_1(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        CHK_GROUPDETAILS.Checked = False
        CHK_GROUPDETAILS_CheckedChanged(sender, e)
        CHK_SUBGROUPDETAILS.Checked = False
        CHK_SUBGROUPDETAILS_CheckedChanged(sender, e)
        DTP_FROMDATE.Value = Now
        DTP_TODATE.Value = Now
        CHK_GROUPWISE.Checked = False
        CHK_SUBGROUPWISE.Checked = False
        chk_storedetails.Checked = False

    End Sub

    Private Sub CHK_GROUPWISE_CheckedChanged(sender As Object, e As EventArgs)
        If CHK_GROUPWISE.Checked = False Then
            CHK_SUBGROUPWISE.Checked = False
        End If
    End Sub

    Private Sub CHK_SUBGROUPWISE_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_SUBGROUPWISE.CheckedChanged
        If CHK_SUBGROUPWISE.Checked = True Then
            CHK_GROUPWISE.Checked = False
        End If
    End Sub
   
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chk_storedetails.CheckedChanged
        Dim i As Integer
        If chk_storedetails.Checked = True Then
            For i = 0 To chklist_store.Items.Count - 1
                chklist_store.SetItemChecked(i, True)
                Call CHK_GROUP()
            Next
        Else
            For i = 0 To chklist_store.Items.Count - 1
                chklist_store.SetItemChecked(i, False)
                Call CHK_SUBGROUP()
            Next
        End If
    End Sub

   
    Private Sub chklist_store_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklist_store.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT distinct isnull(SUBgroupdesc,'')as SUBgroupdesc,ISNULL(SUBGROUPCODE,'')SUBGROUPCODE from vw_SUBgroupwiseissuedetails  "
        sqlstring = sqlstring & " WHERE OPstorelocationname IN ("

        For J = 0 To chklist_store.CheckedItems.Count - 1
            If J = chklist_store.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & chklist_store.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & chklist_store.CheckedItems(J) & "', "
            End If
        Next
        If chklist_store.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY SUBgroupdesc "
            gconnection.getDataSet(sqlstring, "vw_SUBgroupwiseissuedetails")
            If gdataset.Tables("vw_SUBgroupwiseissuedetails").Rows.Count > 0 Then
                CHKLST_GROUPDETAILS.Items.Clear()
                For i = 0 To gdataset.Tables("vw_SUBgroupwiseissuedetails").Rows.Count - 1
                    With gdataset.Tables("vw_SUBgroupwiseissuedetails").Rows(i)
                        ''  CHKLST_GROUPDETAILS.Items.Add(Trim(.Item("groupdesc")))
                        CHKLST_GROUPDETAILS.Items.Add(Trim(.Item("SUBGROUPDESC")))
                    End With
                Next i
            End If
        Else
            CHKLST_GROUPDETAILS.Items.Clear()
        End If
    End Sub

    Private Sub CHK_GROUP()
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT distinct isnull(SUBgroupdesc,'')as SUBgroupdesc ,ISNULL(SUBGROUPCODE,'')SUBGROUPCODE from vw_SUBgroupwiseissuedetails  "
        sqlstring = sqlstring & " WHERE OPstorelocationname IN ("

        For J = 0 To chklist_store.CheckedItems.Count - 1
            If J = chklist_store.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & chklist_store.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & chklist_store.CheckedItems(J) & "', "
            End If
        Next
        If chklist_store.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY SUBgroupdesc "
            gconnection.getDataSet(sqlstring, "vw_SUBgroupwiseissuedetails")
            If gdataset.Tables("vw_SUBgroupwiseissuedetails").Rows.Count > 0 Then
                CHKLST_GROUPDETAILS.Items.Clear()
                For i = 0 To gdataset.Tables("vw_SUBgroupwiseissuedetails").Rows.Count - 1
                    With gdataset.Tables("vw_SUBgroupwiseissuedetails").Rows(i)
                        '' CHKLST_GROUPDETAILS.Items.Add(Trim(.Item("groupdesc")))
                        CHKLST_GROUPDETAILS.Items.Add(Trim(.Item("SUBGROUPCODE")) & "-->" & Trim(.Item("SUBGROUPDESC")))
                    End With
                Next i
            End If
        Else
            CHKLST_GROUPDETAILS.Items.Clear()
        End If
    End Sub
    Private Sub CHK_SUBGROUP()
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT distinct isnull(subgroupdesc,'')as subgroupdesc,ISNULL(subGROUPCODE,'')subGROUPCODE from vw_subgroupwiseissuedetails  "
        sqlstring = sqlstring & " WHERE storelocationname IN ("

        For J = 0 To CHKLST_GROUPDETAILS.CheckedItems.Count - 1
            If J = CHKLST_GROUPDETAILS.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CHKLST_GROUPDETAILS.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CHKLST_GROUPDETAILS.CheckedItems(J) & "', "
            End If
        Next
        If CHKLST_GROUPDETAILS.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY subgroupdesc "
            gconnection.getDataSet(sqlstring, "vw_subgroupwiseissuedetails")
            If gdataset.Tables("vw_subgroupwiseissuedetails").Rows.Count > 0 Then
                CHKLST_SUBGROUPDETAILS.Items.Clear()
                For i = 0 To gdataset.Tables("vw_subgroupwiseissuedetails").Rows.Count - 1
                    With gdataset.Tables("vw_subgroupwiseissuedetails").Rows(i)
                        ''  CHKLST_GROUPDETAILS.Items.Add(Trim(.Item("groupdesc")))
                        CHKLST_SUBGROUPDETAILS.Items.Add(Trim(.Item("SUBGROUPCODE")) & "-->" & Trim(.Item("SUBGROUPDESC")))
                    End With
                Next i
            End If
        Else
            CHKLST_SUBGROUPDETAILS.Items.Clear()
        End If
    End Sub

   



    'Private Sub CHKLST_GROUPDETAILS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CHKLST_GROUPDETAILS.SelectedIndexChanged
    '    Dim i, J As Integer
    '    Dim sqlstring, ssql As String
    '    ssql = ""
    '    sqlstring = "SELECT distinct isnull(subgroupdesc,'')as subgroupdesc,ISNULL(subGROUPCODE,'')subGROUPCODE from vw_subgroupwiseissuedetails  "
    '    sqlstring = sqlstring & " WHERE GROUPDESC IN ("

    '    For J = 0 To CHKLST_GROUPDETAILS.CheckedItems.Count - 1
    '        If J = CHKLST_GROUPDETAILS.CheckedItems.Count - 1 Then
    '            ssql = ssql & " '" & CHKLST_GROUPDETAILS.CheckedItems(J) & "' "
    '        Else
    '            ssql = ssql & " '" & CHKLST_GROUPDETAILS.CheckedItems(J) & "', "
    '        End If
    '    Next
    '    If CHKLST_GROUPDETAILS.CheckedItems.Count > 0 Then
    '        sqlstring = sqlstring & ssql & ") ORDER BY subgroupdesc "
    '        gconnection.getDataSet(sqlstring, "vw_subgroupwiseissuedetails")
    '        If gdataset.Tables("vw_subgroupwiseissuedetails").Rows.Count > 0 Then
    '            CHKLST_SUBGROUPDETAILS.Items.Clear()
    '            For i = 0 To gdataset.Tables("vw_subgroupwiseissuedetails").Rows.Count - 1
    '                With gdataset.Tables("vw_subgroupwiseissuedetails").Rows(i)
    '                    ''  CHKLST_GROUPDETAILS.Items.Add(Trim(.Item("groupdesc")))
    '                    CHKLST_SUBGROUPDETAILS.Items.Add(Trim(.Item("SUBGROUPCODE")) & "-->" & Trim(.Item("SUBGROUPDESC")))
    '                End With
    '            Next i
    '        End If
    '    Else
    '        CHKLST_SUBGROUPDETAILS.Items.Clear()
    '    End If
    'End Sub

 
End Class