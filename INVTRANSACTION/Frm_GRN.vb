Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Frm_GRN
    Dim gconnection As New GlobalClass
    Dim GrnQuery(0) As String
    Dim gr As String
    Dim sql As String
    Dim GRNno(), versionno, CATCODE(), CATCODE1() As String
    Dim accode, acdesc, taxcode As String
    Dim overalldiscountpo, otherchargepo, totpoqty As Double
    Dim potype, sqlstring As String
    Dim issuedocno As String
    Dim gdate As DateTime
    Dim amt, roundAmt As Double
    Dim weighall As Integer = 1
    Dim viewprint As Boolean
    Dim slcode, sldesc, costcode, costdesc, decription As String
    Dim calcbool, costcentercodestatus, slcodestatus As Boolean
    Dim check As Boolean = True
    Dim VATFLAG As Boolean = True
    Dim VendorType As Boolean = False
    Dim gconnection4BGP As New GClass4backgroundprocess
    ' Set grntype defaultly 
    Private Sub Get_Qty_InputSetUp()



        sqlstring = " IF not  EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'weighingmachineovveridehistory') Begin CREATE TABLE [dbo].[weighingmachineovveridehistory](	[allowed] [int] NULL,	[adduser] [varchar](20) NULL,	[adddatetime] [datetime] NULL)   End "
        gconnection.ExcuteStoreProcedure(sqlstring)

        sqlstring = " IF not  EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'weighingmachineovveride') Begin CREATE TABLE [dbo].[weighingmachineovveride](	[allowed] [int] NULL)   End "
        gconnection.ExcuteStoreProcedure(sqlstring)

        sqlstring = "select isnull(allowed,0)as allowed from weighingmachineovveride"
        gconnection.getDataSet(sqlstring, "weigh")
        If gdataset.Tables("weigh").Rows.Count > 0 Then
            weighall = 1 'gdataset.Tables("weigh").Rows(0).Item(0)
        Else
            weighall = 1
        End If
        If weighall = 0 Then
            Button2.Visible = True
        Else
            Button2.Visible = True
        End If
        Call lock_Qty()
    End Sub

    

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
    Private Sub BinDGrnTYpe()
        CmbGrnType.Items.Clear()
        CmbGrnType.Items.Add("PO")
        CmbGrnType.Items.Add("DO")
        CmbGrnType.SelectedIndex = 0
    End Sub
    Private Sub BinDGrnTYpeKGA()
        If gUserCategory <> "S" Then
            sqlstring = " Select  DISTINCT USERNAME  FROM USERADMIN  WHERE USERNAME='" & gUsername & "'  AND Modulename='DIRECT GRN' "
            gconnection.getDataSet(sqlstring, "directgrn")
            If gdataset.Tables("directgrn").Rows.Count > 0 Then
            Else
                CmbGrnType.Items.Clear()
                CmbGrnType.Items.Add("PO")
                CmbGrnType.SelectedIndex = 0
            End If
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
            If txt_Storecode.Text <> "" And Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                Dim sqlstring, financalyear As String
                Dim month As String
                Dim CATLEN, STORE As Integer
                Dim category, storecode As String
                Dim S As String
                month = UCase(Format(Now, "MMM"))
                gcommand = New SqlCommand
                If Len(Trim(txt_Storecode.Text)) = 2 Then
                    storecode = Mid(txt_Storecode.Text, 1, 2)
                    STORE = 2
                Else
                    storecode = Mid(txt_Storecode.Text, 1, 3)
                    STORE = 3
                End If

                'storecode = Mid(txt_Storecode.Text, 1, 3)
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

                ' sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER WHERE SUBSTRING(GRNDETAILS,5," & CATLEN & ")='" & category & "' AND ISNULL(GRNTYPE,'')='GRN'"
                If Mid(UCase(gShortname), 1, 3) = "MBC" Or Mid(UCase(gShortname), 1, 3) = "FMC" Then

                    If Mid(UCase(gShortname), 1, 3) = "FMC" Then
                        sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER WHERE SUBSTRING(GRNDETAILS,5," & CATLEN & ")='" & category & "'  AND ISNULL(GRNTYPE,'')='GRN'"
                    Else
                        sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER "
                    End If

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
                Else
                    sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER WHERE SUBSTRING(GRNDETAILS,6+ " & STORE & "," & CATLEN & ")='" & category & "' AND SUBSTRING(GRNDETAILS,5," & STORE & ")='" & storecode & "'  AND ISNULL(GRNTYPE,'')='GRN'"
                    '        sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER"
                    gconnection.openConnection()
                    gcommand.CommandText = sqlstring
                    gcommand.CommandType = CommandType.Text
                    gcommand.Connection = gconnection.Myconn
                    gdreader = gcommand.ExecuteReader

                    If gdreader.Read Then
                        If gdreader(0) Is System.DBNull.Value Then
                            txt_Grnno.Text = "GRN/" & storecode & "/" & category & "/" & "0001/" & financalyear
                            gdreader.Close()
                            gcommand.Dispose()
                            gconnection.closeConnection()
                        Else
                            txt_Grnno.Text = "GRN/" & storecode & "/" & category & "/" & Format(gdreader(0) + 1, "0000") & "/" & financalyear
                            gdreader.Close()
                            gcommand.Dispose()
                            gconnection.closeConnection()
                        End If
                    Else
                        txt_Grnno.Text = "GRN/" & storecode & "/" & category & "/0001/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                End If
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
            ElseIf e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F12 Then
                Dim objStockSummary1 As New GRN_RATE_CHECK
                objStockSummary1.ShowDialog()
                Exit Sub
            ElseIf e.KeyCode = Keys.F2 Then
                txt_Grnno.Text = ""
                txt_Grnno.Focus()
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 And Cmd_View.Visible = True Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F10 Then
                Call Button1_Click(Button1, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F1 Then
                Call Button2_Click(Button2, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.Escape Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.U Then
                'If MsgBox("DO U Want to Manual Update Stock......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
                '    Me.Cursor = Cursors.WaitCursor
                '    gconnection.ManualUpdate()
                '    Me.Cursor = Cursors.Default
                'Else
                '    MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
                'End If
            ElseIf e.KeyCode = Keys.R Then
                'If MsgBox("DO U Want to Manual Update Rate......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
                '    Me.Cursor = Cursors.WaitCursor
                '    gconnection.valuation()
                '    Me.Cursor = Cursors.Default
                'Else
                '    MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
                'End If

            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Frm_GRN_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        sqlstring = "  Select isnull(MSupplier,'N') as MSupplier  from inv_linksetup"
        gconnection.getDataSet(sqlstring, "inv_linksetup")

        If (gdataset.Tables("inv_linksetup").Rows.Count > 0) Then
            If (gdataset.Tables("inv_linksetup").Rows(0).Item("MSupplier").ToString() = "Y") Then
                GSUPPLIER = "Y"
            Else
                GSUPPLIER = "N"
            End If
        End If
        If UCase(gShortname) = "HSR" Then
            Button2.Visible = False
        End If
        '   End If
        If (gpocode = "Y") Then
            grp_Grngroup1.Visible = True

            'gconnection.dataOperation(6, "update PO_ITEMDETAILS set receivedqty=isnull((select sum(qty-isnull(RET_QTY,0)) as qty from Grn_details g where g.Itemcode=PO_ITEMDETAILS.ITEMCODE and g.pono=PO_ITEMDETAILS.pono  and isnull(g.Voiditem,'N')<>'Y' ),0)")
            'gconnection.dataOperation(6, "     Update   po_hdr set postatus='RELEASED' where pono  in   (select distinct pono from po_itemdetails where isnull(Quantity,0)<>isnull(receivedqty,0))")
            'gconnection.dataOperation(6, "    Update   po_hdr set postatus='CLOSED' where pono not in   (select distinct pono from po_itemdetails where isnull(Quantity,0)<>isnull(receivedqty,0))")

        Else
            grp_Grngroup1.Visible = False
            CmbGrnType.Text = "DIRECT GRN"
        End If
        ' Me.DoubleBuffered = True
        'Resize_Form()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        FillGRNTYPE()
        FILLGRNDETAILS()
        If gShortname <> "RSAOI" Then
            Fillsuppliername()
        End If
        bindcategory()
        If gShortname = "HG" Then
            BTN_GRNDET.Visible = True
        End If

        Call Get_Qty_InputSetUp()


        If UCase(gShortname) = "OUT" Or Mid(UCase(gShortname), 1, 3) = "FMC" Then
            lbl_Glaccountdesc.Visible = True
            Txt_GLAcIn.Visible = True
            Txt_GLAcDesc.Visible = True
            Label25.Visible = True
            Cmd_GLAcHelp.Visible = True
            Cmd_SlCodeHelp.Visible = True
            'Cmd_CostCenterCodeHelp.Visible = True
            Lbl_SubledgerCode.Visible = True
            Lbl_SubledgerName.Visible = True
            'Lbl_CostCenterCode.Visible = True
            'Lbl_CostCenterDesc.Visible = True
            Txt_Slcode.Visible = True
            Txt_SlDesc.Visible = True
            'Txt_CostCenterCode.Visible = True
            'Txt_CostCenterDesc.Visible = True
        Else
            lbl_Glaccountdesc.Visible = False
            Txt_GLAcIn.Visible = False
            Txt_GLAcDesc.Visible = False
            Label25.Visible = False
            Cmd_GLAcHelp.Visible = False
            Cmd_SlCodeHelp.Visible = False
            'Cmd_CostCenterCodeHelp.Visible = False
            Lbl_SubledgerCode.Visible = False
            Lbl_SubledgerName.Visible = False
            'Lbl_CostCenterCode.Visible = False
            'Lbl_CostCenterDesc.Visible = False
            Txt_Slcode.Visible = False
            Txt_SlDesc.Visible = False
            'Txt_CostCenterCode.Visible = False
            'Txt_CostCenterDesc.Visible = False

        End If
        '   

        sqlstring = "Select getdate()"
        gdate = gconnection.getvalue(sqlstring)

        If Trim(UCase(gShortname)) = "CGC" Then
            lock_Frqty()
        End If

        If gShortname = "CPC" Then
            Label28.Visible = True
            Label29.Visible = True
            TXT_ERSALETAX.Visible = True
            txt_Ertax.Visible = True
            txt_Ertax.ReadOnly = False
        End If
        If GBATCHNO = "N" Then
            AxfpSpread1.Col = 22
            AxfpSpread1.ColHidden = True
        Else
            '   lock_Batchno()
        End If
        If GEXPIRY = "N" Then
            AxfpSpread1.Col = 23
            AxfpSpread1.ColHidden = True
        Else
            lock_Expiry()
            AxfpSpread1.Col = 23
            AxfpSpread1.ColHidden = False
        End If

        If GSHELVING = "N" Then
            AxfpSpread1.Col = 24
            AxfpSpread1.ColHidden = True
        End If

        If gShortname = "KSCA" Then
            AxfpSpread1.Col = 25
            AxfpSpread1.ColHidden = True
        Else
            AxfpSpread1.Col = 25
            AxfpSpread1.ColHidden = True
        End If

        LBL_SPONSOR.Hide()
        TXT_Sponsor.Hide()
        cmd_SPONhelp.Hide()

        For RW As Integer = 1 To 100
            AxfpSpread1.Col = 19
            AxfpSpread1.ColHidden = True
        Next

        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If

        If Trim(UCase(gShortname)) = "UC" Then
            BinDGrnTYpe()
        End If

        BinDGrnTYpeKGA()

        If Trim(UCase(gShortname)) = "KBA" Or Trim(UCase(gShortname)) = "NIZAM" Or Trim(UCase(gShortname)) = "FNCC" Then
            autogenerate()
            lbl_Surchargeamt.Visible = True
            Label8.Visible = True
            txt_RoundUP.Visible = True
        ElseIf Trim(UCase(gShortname)) = "HGA" Then
            Label8.Visible = True
            txt_RoundUP.Visible = True
        Else
            Label8.Visible = True
            txt_RoundUP.Visible = True
            ' Label8.Visible = False
            lbl_Surchargeamt.Visible = True
            ' txt_RoundUP.Visible = False
        End If

    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        GmoduleName = "GRN Cum Purchase Bill"
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
            sqlstring = " select DISTINCT ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "'"
            gconnection.getDataSet(sqlstring, "Invvendor_CategoryMaster")
            gSQLString = "SELECT DISTINCT SLCODE,SLNAME FROM accountssubledgermaster "

            If (gdataset.Tables("Invvendor_CategoryMaster").Rows.Count > 0) Then
                If GSUPPLIER = "Y" Then
                    M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "') AND ISNULL(freezeflag,'N')<>'Y' and  slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
                Else
                    M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "') AND ISNULL(freezeflag,'N')<>'Y' and  slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
                End If
            Else
                If GSUPPLIER = "N" Then
                    M_WhereCondition = " WHERE  ACCODE IN ('" & Trim(gCreditors) & "') AND ISNULL(freezeflag,'N')<>'Y' "
                Else
                    M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "') AND ISNULL(freezeflag,'N')<>'Y' "
                End If
                ' M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "')  and  slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
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

            sqlstring = " select  DISTINCT ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "'"
            gconnection.getDataSet(sqlstring, "Invvendor_CategoryMaster")


            If GSUPPLIER = "Y" Then
                M_WhereCondition = " WHERE  ISNULL(freezeflag,'N')<>'Y' and  slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
            Else
                M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "') AND ISNULL(freezeflag,'N')<>'Y' and  slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
            End If



            If Trim(txt_Suppliercode.Text) <> "" Then
                If UCase(gShortname) = "KGA" Then
                    sqlstring = "SELECT  ISNULL(VENDORCODE,'') AS SLCODE, ISNULL(VENDORNAME,'') AS SLNAME, 0 as creditperiod FROM PO_VIEW_VENDORMASTER "
                Else
                    sqlstring = "SELECT SLCODE,SLNAME,isnull(creditperiod,0) as creditperiod FROM accountssubledgermaster "

                End If

                If (gdataset.Tables("Invvendor_CategoryMaster").Rows.Count > 0) Then
                    If GSUPPLIER = "Y" Then
                        sqlstring = sqlstring & " WHERE SLCODE='" & Trim(txt_Suppliercode.Text) & "' and sltype='SUPPLIER' and   slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"

                    Else
                        If UCase(gShortname) = "KGA" Then
                            sqlstring = sqlstring & " WHERE  VENDORCODE='" & Trim(txt_Suppliercode.Text) & "'"
                        Else
                            sqlstring = sqlstring & " WHERE ACCODE IN ("
                            sqlstring = sqlstring & "'" & Trim(gCreditors) & "') AND SLCODE='" & Trim(txt_Suppliercode.Text) & "' and sltype='SUPPLIER' and   slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
                        End If



                    End If

                Else
                    If GSUPPLIER = "Y" Then
                        sqlstring = sqlstring & " WHERE  SLCODE='" & Trim(txt_Suppliercode.Text) & "' and sltype='SUPPLIER'"
                    Else
                        sqlstring = sqlstring & " WHERE ACCODE IN ("
                        sqlstring = sqlstring & "'" & Trim(gCreditors) & "') AND SLCODE='" & Trim(txt_Suppliercode.Text) & "' and sltype='SUPPLIER' "
                    End If

                    ' sqlstring = sqlstring & "'" & Trim(gCreditors) & "') AND SLCODE='" & Trim(txt_Suppliercode.Text) & "' and   slcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"
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
                If check_VendorTypeRU(txt_Suppliercode.Text) Then
                    VendorType = True
                    Label2.Text = "TOTAL TAX LIBILITY "
                    txt_Billamount.Visible = False
                    Txt_bill_2.Visible = True
                Else
                    VendorType = True
                    Label2.Text = "TOTAL TAX"
                    txt_Billamount.Visible = True
                    Txt_bill_2.Visible = False
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
        CATCODE = Split(CMB_CATEGORY.Text, "--->")
        sqlstring = "Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "'"
        gconnection.getDataSet(sqlstring, "Invstore_CategoryMaster")

        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
        If (gdataset.Tables("Invstore_CategoryMaster").Rows.Count > 0) Then
            M_WhereCondition = " where freeze <> 'Y' and storestatus='M'  and  storecode in ( Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(CATCODE(0)) + "' )"

        Else
            M_WhereCondition = " where freeze <> 'Y' and storestatus='M' "

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

            If Trim(UCase(gShortname)) = "KBA" Or Trim(UCase(gShortname)) = "NIZAM" Or Trim(UCase(gShortname)) = "FNCC" Then
                autogenerate()
            End If

            AxfpSpread1.Focus()
            AxfpSpread1.SetActiveCell(1, 1)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub bindlocation()
        AxfpSpread1.Row = AxfpSpread1.ActiveRow
        AxfpSpread1.Col = 24
        If AxfpSpread1.Text = "" Then
            gSQLString = "Select Shelfcode,ShelfDesc from InventoryShelfMaster"
            M_WhereCondition = " where isnull(freeze,'') <> 'Y' and storecode= '" & Trim(txt_Storecode.Text) & "' "
            Dim vform As New ListOperattion1
            vform.Field = "Shelfcode "
            vform.vFormatstring = "SHELF CODE | SHELF DESCRIPTION            |  "
            vform.vCaption = "SHELF MASTER HELP"
            vform.KeyPos = 0
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                AxfpSpread1.Col = 24
                AxfpSpread1.Text = vform.keyfield
                AxfpSpread1.SetActiveCell(24, AxfpSpread1.ActiveRow + 1)
            End If
            vform.Close()
            vform = Nothing
        Else
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Col = 24
            gSQLString = "Select Shelfcode,ShelfDesc from InventoryShelfMaster where  storecode= '" & Trim(txt_Storecode.Text) & "'"
            gconnection.getDataSet(gSQLString, "InventoryShelfMaster")
            If (gdataset.Tables("InventoryShelfMaster").Rows.Count > 0) Then
                AxfpSpread1.SetActiveCell(24, AxfpSpread1.ActiveRow + 1)
            Else
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Col = 24
                AxfpSpread1.SetText(24, AxfpSpread1.ActiveRow, "")
            End If
        End If
    End Sub

    Private Sub binditemcode()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim myValue As Object
        message = "Enter Batch No"
        title = "Batch No"
        defaultValue = txt_Grnno.Text
        M_Groupby = ""
        CATCODE = Split(CMB_CATEGORY.Text, "--->")

        sql = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "'"
            gconnection.getDataSet(sql, "Invitem_VendorMaster")



        gSQLString = "select DISTINCT I.itemcode,M.Itemname,uom,batchprocess,I.RATE AS RATE from  CLOSINGQTY  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "

        If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then



            If UCase(gShortname) = "NIZAM" Or UCase(gShortname) = "RGC" Then
                M_WhereCondition = "  where  I.Autoid IN (SELECT MAX(Autoid) FROM CLOSINGQTY C WHERE I.itemcode=C.itemcode and isnull(C.storecode,'')='" + txt_Storecode.Text + "'  ) and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'  AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' )"
            ElseIf UCase(gShortname) = "HIND" Or UCase(gShortname) = "MCEME" Then

                M_WhereCondition = " where M.Category='" + CATCODE(0) + "'  AND I.Autoid IN (SELECT MAX(Autoid) FROM CLOSINGQTY C WHERE I.itemcode=C.itemcode and isnull(C.storecode,'')='" + txt_Storecode.Text + "'  ) and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'"
            Else
                M_WhereCondition = "  where  M.Category='" + CATCODE(0) + "' AND I.Autoid IN (SELECT MAX(Autoid) FROM CLOSINGQTY C WHERE I.itemcode=C.itemcode and isnull(C.storecode,'')='" + txt_Storecode.Text + "'  ) and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'  AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' )"
            End If

        Else
            M_WhereCondition = " where M.Category='" + CATCODE(0) + "'  AND I.Autoid IN (SELECT MAX(Autoid) FROM CLOSINGQTY C WHERE I.itemcode=C.itemcode and isnull(C.storecode,'')='" + txt_Storecode.Text + "'  ) and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'"
        End If
        gconnection.getDataSet(gSQLString, "Invitem_VendorMaster")
        vform.Field = " I.itemcode, M.Itemname,uom"
        vform.vFormatstring = "    Itemcode     |                        Itemname                            |        UOM      |    batchprocess  |    RATE   "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then

            AxfpSpread1.Col = 3
            AxfpSpread1.Row = AxfpSpread1.ActiveRow

            Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                AxfpSpread1.Col = 18
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                AxfpSpread1.Col = 3
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
            Next Z

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

                If UCase(gShortname) <> "FNCC" Or UCase(gShortname) <> "HGA" Or UCase(gShortname) <> "RCL" Or UCase(gShortname) <> "HIND" Or UCase(gShortname) <> "KIC" Then
                    sql = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom, isnull(contractyn,'0') as contractyn  FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and ITEMCODE='" + vform.keyfield + "' AND cast('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE "
                    gconnection.getDataSet(sql, "Invitem_VendorMaster")
                    If UCase(gShortname) <> "HIND" Or UCase(gShortname) = "MCEME" Then


                        If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                            AxfpSpread1.Col = 3
                            AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                            AxfpSpread1.Col = 18
                            AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                            AxfpSpread1.Col = 5
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("rate")
                            If (Val(gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("contractyn")) = 1) Then
                                AxfpSpread1.Lock = False
                            Else
                                AxfpSpread1.Lock = True
                            End If
                        Else
                            MessageBox.Show("Vendor Item link Expired . Plz update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                        End If
                    End If
                End If



                If UCase(gShortname) = "NIZAM" Then
                    sql = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY GRNDATE  DESC"
                ElseIf CATCODE(0) = "LIQ" Or UCase(gShortname) = "FNCC" Or UCase(gShortname) = "MLRF" Or UCase(gShortname) = "CFC" Or UCase(gShortname) = "HGA" Or UCase(gShortname) = "RCL" Or UCase(gShortname) = "HIND" Or UCase(gShortname) = "JSCA" Then

                    If GSUPPLIER = "Y" Then
                        sql = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "' and Suppliercode='" + txt_Suppliercode.Text + "'  ORDER BY autoid  DESC"
                    Else
                        sql = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY autoid  DESC"
                    End If
                    'sql = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY autoid  DESC"

                Else
                    sql = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY autoid  DESC"
                End If
                gconnection.getDataSet(sql, "RATE")

                If gShortname <> "BBSR" Then
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
                End If
               
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


            If UCase(gShortname) <> "CCL" Then

                If check_VendorType(txt_Suppliercode.Text) Then
                    AxfpSpread1.Col = 10
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = ""

                    AxfpSpread1.Col = 11
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = 0
                    AxfpSpread1.Lock = True
                Else
                    sql = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + Trim(vform.keyfield) + "'"
                    sql = sql & " AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                    gconnection.getDataSet(sql, "Itemtaxtagging")
                    If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                        If (check_tAXtYPE(gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxcode"))) = False Then
                            AxfpSpread1.Col = 10
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                            AxfpSpread1.Col = 11
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxper")
                            AxfpSpread1.Lock = True
                        End If

                        'AxfpSpread1.Col = 12
                        'AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        'AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("GLACCOUNTIN")
                    Else
                        MessageBox.Show("Create TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    End If
                End If


            End If
            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
        Else
            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
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
            If UCase(gShortname) = "NIZAM" Then
                M_WhereCondition = "  where isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'  AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')"
            Else
                M_WhereCondition = "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'  AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')"
            End If



        Else

            M_WhereCondition = " where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "'"
        End If
        vform.Field = " I.itemcode, m.Itemname,I.Uom,batchprocess"
        vform.vFormatstring = "    Itemcode    |                  Itemname                    |       UOM      |"
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


                If UCase(gShortname) <> "FNCC" Or UCase(gShortname) <> "HGA" Or UCase(gShortname) <> "KIC" Then
                    sql = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and itemcode='" + Trim(vform.keyfield) + "' and isnull(contractyn,0)='1' "
                    gconnection.getDataSet(sql, "Invitem_VendorMaster")
                    If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                        AxfpSpread1.Col = 3
                        AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("rate")
                        AxfpSpread1.Lock = True
                    Else
                        MessageBox.Show("Vendor Item link Expire . Plz update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    End If
                End If


                If CATCODE(0) = "LIQ" Or UCase(gShortname) = "NIZAM" Or UCase(gShortname) = "FNCC" Or UCase(gShortname) = "MLRF" Or UCase(gShortname) = "CFC" Or UCase(gShortname) = "HGA" Or gShortname = "JSCA" Then
                    'sql = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE itemcode='" + Trim(vform.keyfield) + "' AND storecode='" + txt_Storecode.Text + "'  and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and   cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY autoid  DESC"

                    If GSUPPLIER = "Y" Then
                        sql = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "' and Suppliercode='" + txt_Suppliercode.Text + "'  ORDER BY autoid  DESC"
                    Else
                        sql = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + vform.keyfield + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY autoid  DESC"
                    End If


                    gconnection.getDataSet(sql, "RATE")
                    If (gdataset.Tables("RATE").Rows.Count > 0) Then

                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                        AxfpSpread1.Lock = False
                    Else
                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                        AxfpSpread1.Lock = True
                    End If
                End If
                If UCase(gShortname) <> "CCL" Then
                    sql = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + Trim(vform.keyfield) + "'"
                    sql = sql & " AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                    gconnection.getDataSet(sql, "Itemtaxtagging")
                    If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                        If (check_tAXtYPE(gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxcode"))) = False Then
                            AxfpSpread1.Col = 10
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                            AxfpSpread1.Col = 11
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxper")
                            AxfpSpread1.Lock = True
                        End If

                    Else
                        MessageBox.Show("Create TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    End If
                End If
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            End If
        End If

    End Sub


    Private Function validateonupdate() As Boolean
        Dim flag As Boolean
        AxfpSpread1.Focus()
        Call CALCULATE()
        ' Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"))

        Dim checkBdate As Boolean

        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"), txt_Storecode.Text)


        If checkBdate = True And RESU1 = False Then
            MsgBox("Business date closed..")
            flag = True
            Return flag
        End If
        If gShortname = "SKYYE" Then
            sqlstring = "SELECT APPROVE FROM PO_HDR WHERE pono='" & Txt_PONo.Text & "' "
            gconnection.getDataSet(sqlstring, "updte")
            Dim APPR As String
            APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
            If APPR = "Y" Then
                MsgBox("This Po is already Approved  You can't update it ")
                flag = True
                Return flag
            End If
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
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
        If txt_Supplierinvno.Text <> "" And txt_Supplierinvno.Text <> "NA" Then
            ''sql = "select * from grn_header where isnull(void,'N')<>'Y' and Supplierinvno='" & txt_Supplierinvno.Text & "'"
            'gconnection.getDataSet(sql, "GH")
            'If (gdataset.Tables("GH").Rows.Count > 0) Then
            '    MessageBox.Show(" Supplier inv. no. already Process in GRN NO. :" & gdataset.Tables("GH").Rows(0).Item("GRNDETAILS"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    flag = True
            '    Return flag
            'End If

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

                If UCase(gShortname) = "CCL" Then
                    If MsgBox("DO U Want Account Reposting......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
                        txt_Grnno.Focus()
                        txt_Supplierinvno.Focus()
                        '  Call ReaccountPost()

                        NewAccountPosting(txt_Grnno.Text, "GRN")
                        sqlstring = "Select  DOCDETAILS from STOCKISSUEDETAIL where batchno='" + txt_Grnno.Text + "'"
                        gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
                        If (gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0) Then
                            For b As Integer = 0 To gdataset.Tables("STOCKISSUEDETAIL").Rows.Count - 1
                                NewAccountPosting(gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("DOCDETAILS"), "ISSUE")
                            Next
                        End If

                        clearoperation()
                    End If
                End If

                flag = True
                Return flag

            End If


        End If

        Dim ComVen As Boolean = check_VendorType(txt_Suppliercode.Text)

        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = i + 1
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 4
            Dim qty As Double = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 17
            Dim fQqty As Double = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 3
            Dim uom As String = AxfpSpread1.Text
            AxfpSpread1.Col = 18
            Dim fQuom As String = AxfpSpread1.Text
            AxfpSpread1.Col = 16
            Dim IVOID As String = AxfpSpread1.Text
            If AxfpSpread1.Text = "" Then
                IVOID = "N"
            End If
            Dim qty1 As Double
            Dim batchyn As String
            Dim SQLSTring As String
            Dim stockuom As String
            Dim convvalue As Double


            If Trim(CmbGrnType.SelectedItem) = "DO" Then
                SQLSTring = "   Select isnull(QTY,0) as QTY,isnull(receivedqty,0) as receivedqty from DI_DET  where DI_DET.DINO='" + Txt_PONo.Text + "' and itemcode='" + itemcode + "'"
                gconnection.getDataSet(SQLSTring, "po_itemdetails")
                If (gdataset.Tables("po_itemdetails").Rows.Count > 0) Then

                    Dim qty2 As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("QTY"))
                    Dim receivedqty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("receivedqty"))

                    If (((qty2) - receivedqty) < qty) Then
                        MessageBox.Show("Quantity Cannot be Greater than DO Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.Text = ""
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        flag = True
                        Return flag
                    End If

                End If
            End If



            AxfpSpread1.Col = 3

            If (AxfpSpread1.Text = "") Then
                MessageBox.Show("UOM Cannot be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(3, i)

                flag = True
                Return flag

            End If

            AxfpSpread1.Col = 4
            Dim grnqty As Double = Val(AxfpSpread1.Text)
            If (grnqty <= 0) Then
                MessageBox.Show("Quantity Cannot be Zero", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(4, i)

                flag = True
                Return flag

            End If
            AxfpSpread1.Col = 5
            Dim grnrate As Double = Val(AxfpSpread1.Text)
            If (grnrate <= 0) Then
                MessageBox.Show("Rate Cannot be Zero", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(5, i)

                flag = True
                Return flag

            End If

            AxfpSpread1.Col = 7
            Dim grndis As Double = Val(AxfpSpread1.Text)
            If (grndis > 100) Then
                MessageBox.Show("Discount Cannot be Greater than 100%", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(7, i)
                flag = True
                Return flag

            End If


            AxfpSpread1.Col = 6
            Dim grndisAmt As Double = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 8
            If (grndisAmt < Val(AxfpSpread1.Text)) Then
                MessageBox.Show("Discount Cannot be Greater than Amt.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(8, i)
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


            '  If Mid(UCase(Trim(gShortname)), 1, 3) <> "FNC" Then

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

            If gShortname <> "RSAOI" And gShortname <> "CSC" Then
                SQLSTring = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + stockuom + "' and transuom='" + fQuom + "'"
                gconnection.getDataSet(SQLSTring, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                Else
                    MessageBox.Show("Generate relation between " + stockuom + " and " + fQuom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Exit Function
                End If
                fQqty = fQqty / convvalue
                qty = qty + fQqty
            End If

            If IVOID = "Y" Then
                qty = 0
            End If

            If gShortname <> "HIND" Then
                Dim sql As String = "select qty,isnull(batchyn,'N') as batchyn from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "'  "
                sql = sql & " and Trnno='" + txt_Grnno.Text + "' "
                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                End If
                sql = "select closingstock +" + Format(Val(qty - qty1), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "' "
                sql = sql & "and closingstock +" + Format(Val(qty - qty1), "0.000") + "<0 AND itemcode='" + itemcode + "'  and storecode='" + txt_Storecode.Text + "' "
                If batchyn = "Y" Then
                    sql = sql & " and batchno='" + txt_Grnno.Text + "'"
                End If
                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    MessageBox.Show("Updation create   " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag
                End If
            End If

            ' End If


            If IVOID = "N" Then


                sql = " SELECT * FROM INV_PROFITITEMS WHERE ITEMCODE ='" + itemcode + "'"
                gconnection.getDataSet(sql, "INV_PROFITITEMS")
                If (gdataset.Tables("INV_PROFITITEMS").Rows.Count > 0) Then
                    sql = " SELECT * FROM bom_det WHERE gitemcode='" + itemcode + "' AND ISNULL(Void,'')<>'Y'"
                    gconnection.getDataSet(sql, "bom_det")
                    If (gdataset.Tables("bom_det").Rows.Count > 0) Then

                    Else
                        MessageBox.Show("Please Define Bill Of Material for Itemcode: " + itemcode, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If




                If CmbGrnType.Text = "DIRECT GRN" Then
                    sql = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + itemcode + "'"
                    gconnection.getDataSet(sql, "ITEM")
                    If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                        If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then
                            AxfpSpread1.Col = 20
                            sql = " select * from InvCompany_ItemMaster where COMPANYCODE='" + AxfpSpread1.Text + "' AND ITEMCODE='" + itemcode + "' "
                            gconnection.getDataSet(sql, "InvCompany_ItemMaster")
                            If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then

                            Else
                                MessageBox.Show("Select Company Code .", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                AxfpSpread1.Text = ""
                                AxfpSpread1.SetActiveCell(20, i)
                                flag = True
                                Return flag
                            End If
                        End If
                    End If
                End If
            End If



        Next



        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)
            flag = True
            Return flag
        End If

        If (GACCPOST.ToUpper() = "Y") Then
            If gAcPostingWise = "ITEM" Then

                For k As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = k
                    AxfpSpread1.Col = 16

                    Dim IVOID As String = AxfpSpread1.Text
                    If IVOID = "" Then
                        IVOID = "N"
                    End If

                    If IVOID = "N" Then
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                If accode = "" Then
                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                    flag = True
                                    Return flag

                                End If
                            Else
                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                flag = True
                                Return flag
                            End If
                        End If
                    End If


                Next


            ElseIf gAcPostingWise = "CATEGORY" Then
                sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORYCODE " + Trim(CATCODE(0)) + "")
                        flag = True
                        Return flag

                    End If
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                    flag = True
                    Return flag
                End If
            Else
                sqlstring = "Select * from AccountstaggingnEW where CODE='" & Trim(txt_Storecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE  " + Trim(txt_Storecode.Text) + "")
                        flag = True
                        Return flag

                    End If
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE " + Trim(txt_Storecode.Text) + "")
                    flag = True
                    Return flag
                End If

            End If
            If CmbGrnType.Text = "SPONSOR" Then


                For j As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = j
                    AxfpSpread1.Col = 1
                    If AxfpSpread1.Text <> "" Then

                        AxfpSpread1.Col = 16

                        Dim IVOID As String = AxfpSpread1.Text
                        If IVOID = "" Then
                            IVOID = "N"
                        End If

                        If IVOID = "N" Then
                            AxfpSpread1.Col = 19
                            Dim sqlstring As String = "SELECT * FROM SponsorAccountstagging WHERE code='" & Trim(AxfpSpread1.Text) & "' AND  ISNULL(VOID,'N') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If gdataset.Tables("CODE").Rows.Count > 0 Then

                                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                                If accode = "" Then

                                    MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING...")
                                    flag = True
                                    Return flag

                                End If
                                If accode <> "" And costcode = "" Then

                                    MessageBox.Show("NO COST CENTRE CODE FOR SPON. POSTING...")
                                    flag = True
                                    Return flag

                                End If

                            Else
                                MessageBox.Show("Please Fill Sponsor ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                flag = True
                                Return flag
                            End If
                        End If

                    End If

                Next
            End If

            If (Txt_SPLCESS.Text) > 0 Then

                sqlstring = "Select isnull(inputtaxaccountin,'') as inputtaxaccountin,isnull(inputtaxaccountinDESC,'') as inputtaxaccountinDESC from accountstaxmaster where TAXCODE='IN_ADDCESS' "
                gconnection.getDataSet(sqlstring, "CODE")

                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                    acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                    If accode = "" Then

                        MessageBox.Show("NO INPUTTAX A/C FOUND FOR ACCOUNT POSTING OF TAXCODE IN_ADDCESS")
                        flag = True
                        Return flag

                    End If
                Else
                    MessageBox.Show("NO INPUTTAX A/C FOUND FOR ACCOUNT POSTING OF TAXCODE IN_ADDCESS")
                    flag = True
                    Return flag
                End If
            End If

        End If

        Return False
    End Function


    Private Sub ReaccountPost()
        Dim rate, amt, qty As Double
        Dim rateflag, itemcode, insert(0) As String

        ReDim Preserve GrnQuery(0)



        sqlstring = "delete from  JOURNALENTRY where VoucherNo='" + Trim(txt_Grnno.Text) + "' "
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring

        Call accountPost()
        If (GACCPOST.ToUpper() = "Y") Then

            sqlstring = "Select  * from STOCKISSUEDETAIL where batchno='" + txt_Grnno.Text + "'"
            gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
            If (gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0) Then

                sqlstring = "delete  from JOURNALENTRY where VoucherNo in (select Docdetails from STOCKISSUEDETAIL where batchno='" + Trim(txt_Grnno.Text) + "') and Vouchertype='ISSUE'"
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

                For b As Integer = 0 To gdataset.Tables("STOCKISSUEDETAIL").Rows.Count - 1

                    Dim sql As String = "select weightedrate,batchrate  from ratelist where Itemcode='" + gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("itemcode") + "' and grnno='" + txt_Grnno.Text + "'"
                    gconnection.getDataSet(sql, "ratelist")

                    Dim sql1 As String = " select isnull(rateflag,'P') as rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
                    sql1 = sql1 & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" + gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("itemcode") + "' "
                    gconnection.getDataSet(sql1, "ratelist2")
                    If (gdataset.Tables("ratelist2").Rows.Count > 0) Then
                        If (gdataset.Tables("ratelist2").Rows(0).Item("rateflag") = "W") Then
                            rate = Format(Val(gdataset.Tables("ratelist").Rows(0).Item("weightedrate")), "0.000")

                        ElseIf (gdataset.Tables("ratelist2").Rows(0).Item("rateflag") = "P") Then
                            rate = Format(Val(gdataset.Tables("ratelist").Rows(0).Item("batchrate")), "0.000")

                        Else
                            AxfpSpread1.Col = 5
                            rate = Val(AxfpSpread1.Text)
                        End If

                    End If

                    qty = Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("qty"))
                    amt = rate * qty
                    issuedocno = gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("docdetails")
                    sqlstring = "Select  * from AccountstaggingNEW where code='" & Trim(gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("opstorelocationcode")) & "' AND ISNULL(VOID,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                        acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                        If accode = "" Then

                            MessageBox.Show("NO GL FOUND FOR STOCK POSTING...:-" & Trim(gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("opstorelocationcode")))
                            check = False
                            Exit Sub


                        End If

                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        sqlstring = sqlstring & " VALUES('" & Trim(issuedocno) & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'ISSUE', '" & accode & "',"
                        sqlstring = sqlstring & "'" & acdesc & "',"
                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        sqlstring = sqlstring & "'DEBIT',"


                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N')"
                        ReDim Preserve GrnQuery(GrnQuery.Length)
                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                    Else
                        MessageBox.Show("NO GL FOUND FOR STOCK POSTING...:-'" & Trim(gdataset.Tables("STOCKISSUEDETAIL").Rows(b).Item("opstorelocationcode")) & "'")
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
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        sqlstring = sqlstring & " VALUES('" & Trim(issuedocno) & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'ISSUE', '" & accode & "',"
                        sqlstring = sqlstring & "'" & acdesc & "',"
                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        sqlstring = sqlstring & "'CREDIT',"



                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N')"
                        ReDim Preserve GrnQuery(GrnQuery.Length)
                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                    Else
                        MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR StoreCode:-'" & txt_Storecode.Text & "'")
                        Exit Sub
                    End If
                Next
                gconnection.MoreTrans(GrnQuery)
            End If






        End If


    End Sub
    'Private Sub updateissueoperation()
    '    ' Dim docno1() As String
    '    Dim insert(0) As String
    '    Dim sqlstring As String
    '    Dim itemcode As String
    '    Dim i As Integer
    '    If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
    '        docno1 = Split(Trim(txt_Docno.Text), "/")
    '        sqlstring = "UPDATE STOCKISSUEHEADER SET Docdate='" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "', "
    '        sqlstring = sqlstring & " Storelocationcode='" & Trim(TXT_FROMSTORECODE.Text) & "',"
    '        sqlstring = sqlstring & " Storelocationname='" & Trim(txt_FromStorename.Text) & "',"
    '        sqlstring = sqlstring & " Opstorelocationcode='" & Trim(txt_Storecode.Text) & "',"
    '        sqlstring = sqlstring & " Opstorelocationname='" & Trim(txt_StoreDesc.Text) & "', "
    '        sqlstring = sqlstring & " Totalamt=" & Format(Val(txt_Totalamount.Text), "0.000") & ","
    '        sqlstring = sqlstring & " Remarks='" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,Void='N',"
    '        sqlstring = sqlstring & " VoidReason = '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "',Updateuser='" & Trim(gUsername) & "',"
    '        sqlstring = sqlstring & " Updatetime='" & Format(Now, "dd-MMM-yyyy") & "'"
    '        sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
    '        sqlstring = sqlstring & " AND INDENTNO = '" & Trim(Txt_IndentNo.Text) & "'"
    '        ReDim Preserve insert(insert.Length)
    '        insert(insert.Length - 1) = sqlstring

    '        '''********************************************************* DELETE FROM stockissuedetail *****************************************************'''
    '        sqlstring = "DELETE FROM STOCKISSUEDETAIL WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
    '        sqlstring = sqlstring & " AND INDENTNO = '" & Trim(Txt_IndentNo.Text) & "'"
    '        ReDim Preserve insert(insert.Length)
    '        insert(insert.Length - 1) = sqlstring
    '        For i = 1 To AxfpSpread1.DataRowCnt

    '            AxfpSpread1.Row = i
    '            sqlstring = "INSERT INTO STOCKISSUEDETAIL(Docno,Docdetails,Docdate,IndentNo,IndentDate,Storelocationcode,Storelocationname,"
    '            sqlstring = sqlstring & " Opstorelocationcode,Opstorelocationname,Itemcode,Itemname,Uom,IND_QTY,Qty,batchno,rate,amount,"
    '            sqlstring = sqlstring & " Void,Adduser,adddatetime,Updateuser,Updatetime)"
    '            sqlstring = sqlstring & " VALUES ('" & Trim(txt_Docno.Text) & "','" & Trim(txt_Docno.Text) & "',"
    '            sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
    '            sqlstring = sqlstring & " '" & Trim(Txt_IndentNo.Text) & "','" & Format(CDate(dtp_IndentDate.Value), "dd-MMM-yyyy") & "',"
    '            sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
    '            sqlstring = sqlstring & " '" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
    '            AxfpSpread1.Row = i

    '            AxfpSpread1.Col = 1
    '            itemcode = Trim(AxfpSpread1.Text)
    '            sqlstring = sqlstring & "'" & Trim(itemcode) & "',"
    '            AxfpSpread1.Col = 2
    '            sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
    '            AxfpSpread1.Col = 3
    '            sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
    '            AxfpSpread1.Col = 4
    '            sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","
    '            AxfpSpread1.Row = i

    '            AxfpSpread1.Col = 5
    '            Dim qty As Double = Val(AxfpSpread1.Text)
    '            sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","
    '            AxfpSpread1.Row = i

    '            AxfpSpread1.Col = 6
    '            sqlstring = sqlstring & "'" & AxfpSpread1.Text & "',"
    '            AxfpSpread1.Row = i

    '            AxfpSpread1.Col = 7
    '            Dim rate As Double = Val(AxfpSpread1.Text)
    '            sqlstring = sqlstring & "'" & Format(Val(rate), "0.000") & "',"
    '            sqlstring = sqlstring & "" & Format(qty * rate, "0.000") & ","

    '            sqlstring = sqlstring & "'N',"
    '            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "',"
    '            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
    '            ReDim Preserve insert(insert.Length)
    '            insert(insert.Length - 1) = sqlstring
    '            Dim qty1 As Double
    '            Dim batchyn As String
    '            Dim uom As String
    '            Dim uom1 As String
    '            Dim convvalue As Double
    '            Dim precise As Double
    '            Dim batchno As String
    '            Dim sql1 As String
    '            AxfpSpread1.Col = 3
    '            uom1 = AxfpSpread1.Text
    '            AxfpSpread1.Col = 6
    '            batchno = AxfpSpread1.Text
    '            If (costcenterflag = False) Then

    '                sql1 = "select qty,batchyn,uom,batchno from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
    '                sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
    '                If (batchno <> "") Then
    '                    sql1 = sql1 & " and  batchno='" + batchno + "' "
    '                End If

    '                gconnection.getDataSet(sql1, "closingqty")
    '                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
    '                    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
    '                    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
    '                    '                    batchno = gdataset.Tables("closingqty").Rows(0).Item("batchno")
    '                    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
    '                    Dim sql As String = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
    '                    gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
    '                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
    '                        convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
    '                        precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))

    '                    End If

    '                Else
    '                    qty1 = 0
    '                    convvalue = 1
    '                End If
    '                sql1 = "update closingqty set closingstock= closingstock +" + Format(Val((qty * (1 / convvalue)) + (qty * precise) - (qty1)), "0.000") + ",qty=" + Format((Val(qty / convvalue) + (qty * precise)), "0.000") + " "
    '                sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
    '                If (batchyn = "Y") Then
    '                    sql1 = sql1 & "  and  batchno='" + batchno + "'"
    '                End If
    '                ReDim Preserve insert(insert.Length)
    '                insert(insert.Length - 1) = sql1

    '                sql1 = "update closingqty set closingstock= closingstock +" + Format(Val((qty * (1 / convvalue) + (qty * precise)) - (qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val((qty * (1 / convvalue) + (qty * precise)) - (qty1)), "0.000") + ""
    '                ',closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
    '                ',openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
    '                sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + txt_Storecode.Text + "' and itemcode='" + itemcode + "' "
    '                If (batchyn = "Y") Then
    '                    sql1 = sql1 & "  and  batchno='" + txt_Docno.Text + "'"
    '                End If
    '                ReDim Preserve insert(insert.Length)
    '                insert(insert.Length - 1) = sql1
    '            End If

    '            sql1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
    '            sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
    '            If (batchno <> "") Then
    '                sql1 = sql1 & " and  batchno='" + batchno + "' "
    '            End If

    '            gconnection.getDataSet(sql1, "closingqty")
    '            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
    '                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
    '                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
    '                uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
    '                Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
    '                convvalue = gconnection.getvalue(sql)
    '            Else
    '                qty1 = 0
    '                convvalue = 1
    '            End If
    '            sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) - ((qty / convvalue) + (qty * precise))), "0.000") + ",qty=-" + Format(Val((qty / convvalue) + (qty * precise)), "0.000") + ""
    '            sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
    '            If (batchyn = "Y") Then
    '                sql1 = sql1 & "  and  batchno='" + batchno + "'"
    '            End If
    '            ReDim Preserve insert(insert.Length)
    '            insert(insert.Length - 1) = sql1

    '            sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) - ((qty / convvalue) + (qty * precise))), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1) - ((qty / convvalue) + (qty * precise))), "0.000") + ""
    '            ',closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
    '            ',openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
    '            sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
    '            If (batchyn = "Y") Then
    '                sql1 = sql1 & "  and  batchno='" + txt_Docno.Text + "'"
    '            End If
    '            ReDim Preserve insert(insert.Length)
    '            insert(insert.Length - 1) = sql1
    '        Next i
    '        'sql = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
    '        'sql = sql & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
    '        'sql = sql & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
    '        'sql = sql & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
    '        'sql = sql & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
    '        'sql = sql & " from inv_Inventoryuomstorelink a inner join closingqty b"
    '        'sql = sql & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
    '        'ReDim Preserve insert(insert.Length)
    '        'insert(insert.Length - 1) = sql

    '        gconnection.MoreTrans(insert)
    '    End If
    'End Sub

    Private Function check_Duplicate(ByVal Itemcode As String) As Boolean
        Dim i As Integer

        Dim uom As String
        AxfpSpread1.Col = 3
        uom = AxfpSpread1.Text

        AxfpSpread1.Col = 1
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            If i <> AxfpSpread1.ActiveRow Then
                If Trim(AxfpSpread1.Text) = Trim(Itemcode) And Trim(Itemcode) <> "OPT" Then
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
        AxfpSpread1.Focus()
        Cmd_Add.Enabled = False
        Call CALCULATE()
        Dim flag As Boolean
        ' Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"))


        Dim checkBdate As Boolean
        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"), txt_Storecode.Text)



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

        ' ADDED BY SRI FOR LOCKING SYSTEM
        'sqlstring = "SELECT LOCK FROM STOREMASTER WHERE STORECODE='" + txt_Storecode.Text + "' "
        'gconnection.getDataSet(sqlstring, "LOCKED")
        'If gdataset.Tables("LOCKED").Rows.Count > 0 Then
        '    Dim LOCK As String
        '    LOCK = Trim(gdataset.Tables("LOCKED").Rows(0).Item("LOCK"))
        '    If LOCK = "Y" Then
        '        MsgBox("This Store is in use Please wait for some times")
        '        flag = True
        '        Return flag
        '    End If
        'End If

        If UCase(gShortname) = "KGA" Then

        Else
            CATCODE = Split(CMB_CATEGORY.Text, "--->")
            sqlstring = "SELECT ISNULL(CATEGORY,'') AS CATEGORY FROM INV_InventoryItemMaster WHERE ISNULL(CATEGORY,'')='" & Trim(CATCODE(0) & "") & "' GROUP BY CATEGORY"
            gconnection.getDataSet(sqlstring, "CATEGORY")
            If gdataset.Tables("CATEGORY").Rows.Count > 0 Then

            Else
                MessageBox.Show("No Any Item in this category. Plz select other caegory...", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If
        End If






        sqlstring = "SELECT storecode,storedesc FROM STOREMASTER "
        sqlstring = sqlstring & " WHERE freeze <> 'Y' and storestatus='M' AND STORECODE='" + txt_Storecode.Text + "'"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then

        Else
            MessageBox.Show("Store code Not valid . Plz select other store...", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If



        If DateDiff(DateInterval.Day, (CDate(dtp_Grndate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("GRN DATE cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If

        'If CmbGrnType.Text = "PO" Then
        '    Dim sqlstring As String = "SELECT PODATE FROM PO_HDR WHERE PONO='" & Txt_PONo.Text & "'"
        '    gconnection.getDataSet(sqlstring, "PO_HDR")
        '    Dim PO_DATE As Date
        '    PO_DATE = Format(CDate(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODATE"))))
        '    If gdataset.Tables("PO_HDR").Rows.Count > 0 Then
        '        If DateDiff(DateInterval.Day, (CDate(dtp_Grndate.Value)), PO_DATE) > 0 Then
        '            MessageBox.Show("GRN Date cannot be Lesser than PO. Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '            flag = True
        '            Return flag
        '        End If
        '    End If
        'End If

        If DateDiff(DateInterval.Day, (CDate(dtp_Supplierinvdate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("Suppler date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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

        If CMB_CATEGORY.Text = "" Then
            MessageBox.Show("Please select Category ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            CMB_CATEGORY.BackColor = Color.Red
            CMB_CATEGORY.Focus()

            flag = True
            Return flag
        Else

        End If



        If CmbGrnType.Text = "PO" And grp_Grngroup1.Visible = True Then
            If Txt_PONo.Text = "" And Txt_PONo.Visible = True Then
                MessageBox.Show("Please Fill POno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Txt_PONo.BackColor = Color.Red
                Txt_PONo.Focus()

                flag = True
                Return flag
            Else
                Txt_PONo.BackColor = Color.White

            End If
        ElseIf Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                If AxfpSpread1.Text <> "" Then
                    AxfpSpread1.Col = 19
                    Dim sqlstring As String = "Select isnull(SPONSORcode,'') as SPONSORcode,isnull(SPONSORdesc,'') as SPONSORdesc,isnull(freeze,'') as freeze,isnull(adddate,'') as adddate FROM inv_SPONSORmaster WHERE SPONSORcode='" & Trim(AxfpSpread1.Text) & "' AND  ISNULL(freeze,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "inv_SPONSORmaster")
                    If gdataset.Tables("inv_SPONSORmaster").Rows.Count > 0 Then


                    Else
                        MessageBox.Show("Please Fill Sponsor ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If
            Next
        ElseIf GBATCHNO = "Y" Then
            'Dim ITEMCODE As String
            'For j As Integer = 1 To AxfpSpread1.DataRowCnt
            '    AxfpSpread1.Row = j
            '    AxfpSpread1.Col = 1
            '    ITEMCODE = AxfpSpread1.Text
            '    AxfpSpread1.Col = 22
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
        If GEXPIRY = "Y" Then
            Dim ITEMCODE As String
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                ITEMCODE = AxfpSpread1.Text
                AxfpSpread1.Col = 23
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
                            AxfpSpread1.Col = 23
                            AxfpSpread1.Text = ""

                        End If
                    End If
                End If
            Next
        End If
        If GSHELVING = "Y" Then
            Dim ITEMCODE As String
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                ITEMCODE = AxfpSpread1.Text
                AxfpSpread1.Col = 24
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(shelving,'') AS shelving FROM INV_InventoryItemMaster WHERE ITEMCODE='" & ITEMCODE & "' AND  ISNULL(VOID,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "SHELVINGREQ")
                    Dim SHELVING_REQ As String
                    SHELVING_REQ = Trim(gdataset.Tables("SHELVINGREQ").Rows(0).Item("shelving"))
                    If gdataset.Tables("SHELVINGREQ").Rows.Count > 0 Then
                        If SHELVING_REQ = "YES" Then
                            MessageBox.Show("Please Enter Shelf ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag
                        End If
                    End If
                End If
            Next
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

        If txt_Supplierinvno.Text <> "" And txt_Supplierinvno.Text <> "NA" Then
            sql = "select * from grn_header where isnull(void,'N')<>'Y' and Supplierinvno='" & txt_Supplierinvno.Text & "' AND  Suppliercode='" & txt_Suppliercode.Text & "'"
            gconnection.getDataSet(sql, "GH")
            If (gdataset.Tables("GH").Rows.Count > 0) Then
                MessageBox.Show(" Supplier inv. no. already Process in GRN NO. :" & gdataset.Tables("GH").Rows(0).Item("GRNDETAILS"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If

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
            Dim ITEM As String
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 1
            ITEM = AxfpSpread1.Text
            If Trim(CmbGrnType.SelectedItem) = "PO" Then
                sql = "Select isnull(quantity,0) as quantity,isnull(receivedqty,0) as receivedqty,isnull(qtyrange,'') as qtyrange,isnull(PO_HDR.potype,'') as potype  from po_itemdetails inner join po_hdr on po_hdr.pono=po_itemdetails.pono and po_hdr.versionno=po_itemdetails.versionno where po_hdr.pono='" + Txt_PONo.Text + "' and po_hdr.versionno='" + versionno + "'and itemcode='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(sql, "po_itemdetails")
                If (gdataset.Tables("po_itemdetails").Rows.Count > 0) Then
                    Dim qtyrange As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("qtyrange"))
                    Dim qty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("quantity"))
                    Dim receivedqty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("receivedqty"))
                    If Mid(UCase(Trim(gShortname)), 1, 3) = "CCF" Then
                        ' If (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "FIXED RATE FIXED QUANTITY" Or gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "OPEN RATE FIXED QUANTITY") Then

                        AxfpSpread1.Col = 4
                        Dim quant As Double = Val(AxfpSpread1.Text)
                        If ((qty + qtyrange) - receivedqty < quant) Then
                            MessageBox.Show("Quantity Cannot be Greater than PO Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            AxfpSpread1.Text = ""
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                            flag = True
                            Return flag
                        End If
                        'ElseIf (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "RATE IN RANGE QUANTITY IN RANGE") Then
                        'AxfpSpread1.Col = 4
                        'Dim quant As Double = Val(AxfpSpread1.Text)
                        'If ((qty + qtyrange) - receivedqty < quant) Then
                        '    MessageBox.Show("Quantity Cannot be Greater than PO Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        '    AxfpSpread1.Text = ""
                        '    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        '    flag = True
                        '    Return flag
                        'End If
                        'End If
                    Else
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

                End If
            ElseIf Trim(CmbGrnType.SelectedItem) = "DO" Then
                sqlstring = "   Select isnull(QTY,0) as QTY,isnull(receivedqty,0) as receivedqty from DI_DET  where DI_DET.DINO='" + Txt_PONo.Text + "' and itemcode='" + ITEM + "'"
                '    sqlstring = "Select isnull(QTY,0) as QTY,isnull(receivedqty,0) as receivedqty from po_itemdetails inner join po_hdr on po_hdr.pono=po_itemdetails.pono and po_hdr.versionno=po_itemdetails.versionno where po_hdr.pono='" + Txt_PONo.Text + "' and po_hdr.versionno='" + versionno + "'and itemcode='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(sqlstring, "po_itemdetails")
                If (gdataset.Tables("po_itemdetails").Rows.Count > 0) Then

                    Dim qty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("QTY"))
                    Dim receivedqty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("receivedqty"))
                    AxfpSpread1.Col = 4
                    Dim quant As Double = Val(AxfpSpread1.Text)
                    If ((qty) - receivedqty < quant) Then
                        MessageBox.Show("Quantity Cannot be Greater than DO Quantity :", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.Text = ""
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        flag = True
                        Return flag
                    End If

                End If
              

            End If

            Dim STOCKUOM, uom, fquom As String
            AxfpSpread1.Col = 3
            uom = AxfpSpread1.Text
            AxfpSpread1.Col = 18
            fquom = AxfpSpread1.Text

            sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + ITEM + "'"
            STOCKUOM = gconnection.getvalue(sqlstring)
            sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
            gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then

            Else
                MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If
            '=====Adding Free Qty for CCL ==========
            If Trim(UCase(gShortname)) = "CCL" Then
                sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + fquom + "'"
                gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then

                Else
                    MessageBox.Show("Generate relation between " + uom + " and " + fquom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag
                End If
            Else

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

            sql = " SELECT * FROM INV_PROFITITEMS WHERE ITEMCODE ='" + ITEM + "'"
            gconnection.getDataSet(sql, "INV_PROFITITEMS")
            If (gdataset.Tables("INV_PROFITITEMS").Rows.Count > 0) Then
                sql = " SELECT * FROM bom_det WHERE gitemcode='" + ITEM + "' AND ISNULL(Void,'')<>'Y'"
                gconnection.getDataSet(sql, "bom_det")
                If (gdataset.Tables("bom_det").Rows.Count > 0) Then

                Else
                    MessageBox.Show("Please Define Bill Of Material for Itemcode: " + ITEM, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag
                End If
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


            If CmbGrnType.Text = "DIRECT GRN" Then
                sql = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + ITEM + "'"
                gconnection.getDataSet(sql, "ITEM")
                If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                    If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then
                        AxfpSpread1.Col = 20
                        sql = " select * from InvCompany_ItemMaster where COMPANYCODE='" + AxfpSpread1.Text + "' AND ITEMCODE='" + ITEM + "' "
                        gconnection.getDataSet(sql, "InvCompany_ItemMaster")
                        If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then

                        Else
                            MessageBox.Show("Select Company Code .", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            AxfpSpread1.Text = ""
                            AxfpSpread1.SetActiveCell(20, j)
                            flag = True
                            Return flag
                        End If
                    End If
                End If
            End If


        Next

        

        If (GACCPOST.ToUpper() = "Y") Then
            If gAcPostingWise = "ITEM" Then
                For k As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = k
                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                        gconnection.getDataSet(sqlstring, "CODE")
                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")

                            If accode = "" Then

                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                flag = True
                                Return flag

                            End If
                        Else
                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                            flag = True
                            Return flag
                        End If
                    End If

                Next


            ElseIf gAcPostingWise = "CATEGORY" Then
                sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORYCODE " + Trim(CATCODE(0)) + "")
                        flag = True
                        Return flag


                    End If
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                    flag = True
                    Return flag

                End If
            Else
                sqlstring = "Select * from AccountstaggingnEW where  CODE='" & Trim(txt_Storecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE  " + Trim(txt_Storecode.Text) + "")
                        flag = True
                        Return flag


                    End If
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE " + Trim(txt_Storecode.Text) + "")
                    flag = True
                    Return flag
                End If

            End If

            If (Txt_SPLCESS.Text) > 0 Then

                sqlstring = "Select isnull(inputtaxaccountin,'') as inputtaxaccountin,isnull(inputtaxaccountinDESC,'') as inputtaxaccountinDESC from accountstaxmaster where TAXCODE='IN_ADDCESS' "
                gconnection.getDataSet(sqlstring, "CODE")

                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                    acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                    If accode = "" Then

                        MessageBox.Show("NO INPUTTAX A/C FOUND FOR ACCOUNT POSTING OF TAXCODE IN_ADDCESS")
                        flag = True
                        Return flag

                    End If
                Else
                    MessageBox.Show("NO INPUTTAX A/C FOUND FOR ACCOUNT POSTING OF TAXCODE IN_ADDCESS")
                    flag = True
                    Return flag
                End If
            End If

            If Val(txt_totaltax.Text) <> 0 Then
                Dim amount, POSTAMT As Double
                Dim TAXyN As String

                '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER ==========================

                For k As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = k

                    AxfpSpread1.Col = 10
                    TAXyN = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 1


                    If Trim(AxfpSpread1.Text) <> "" And TAXyN <> "" Then
                        If TAXyN = "NONE" Then
                            AxfpSpread1.Col = 12
                            POSTAMT = Val(AxfpSpread1.Text)
                            AxfpSpread1.Col = 1
                            sqlstring = "Select  isnull(taxrebate,'NO') AS taxrebate from INV_InventoryItemMaster where itemcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'"
                            gconnection.getDataSet(sqlstring, "INV_InventoryItemMaster")
                            If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                                If gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("taxrebate") = "YES" Then

                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS YES ==========================
                                    sqlstring = "Select * from accountstaxmaster where TAXCODE='" + TAXyN + "'"
                                    gconnection.getDataSet(sqlstring, "CODE")

                                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                        accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                        acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                                        If accode = "" Then

                                            MessageBox.Show("NO INPUTTAX A/C FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                            flag = True
                                            Return flag

                                        End If


                                    Else
                                        MessageBox.Show("NO INPUTTAX A/C FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                        flag = True
                                        Return flag

                                    End If
                                Else
                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS NO ==========================

                                    accode = ""
                                    acdesc = ""
                                    slcode = ""
                                    sldesc = ""
                                    costcode = ""
                                    costdesc = ""

                                    If gAcPostingWise = "ITEM" Then
                                        AxfpSpread1.Col = 1
                                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                            If accode = "" Then

                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(AxfpSpread1.Text) + "")
                                                flag = True
                                                Return flag

                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                            check = False
                                            Exit Function
                                        End If
                                    ElseIf gAcPostingWise = "CATEGORY" Then
                                        sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")

                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                                flag = True
                                                Return flag

                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                            check = False
                                            Exit Function

                                        End If
                                    Else
                                        sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountDESC")

                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                                                flag = True
                                                Return flag

                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                                            flag = True
                                            Return flag

                                        End If
                                    End If



                                End If
                            End If
                        Else
                            amount = 0
                            POSTAMT = 0

                            'For k1 As Integer = 1 To AxfpSpread1.DataRowCnt
                            '    AxfpSpread1.Row = k1

                            'AxfpSpread1.Col = 9
                            'amount = Val(AxfpSpread1.Text)

                            AxfpSpread1.Col = 10
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "Select  * from invtaxgroupmasterdetail where taxgroupcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'  "
                                gconnection.getDataSet(sqlstring, "invtaxgroupmasterdetail")
                                If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then

                                    For Z As Integer = 0 To gdataset.Tables("invtaxgroupmasterdetail").Rows.Count - 1
                                        'POSTAMT = (amount * Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAXPER"))) / 100

                                        'If UCase(gShortname) <> "CCL" Then
                                        '    sqlstring = "select * from TaxAccountstagging where TaxCode='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "' AND ISNULL(VOID,'N')<>'Y'"
                                        '    gconnection.getDataSet(sqlstring, "TaxAccountstagging")

                                        '    If (gdataset.Tables("TaxAccountstagging").Rows.Count > 0) Then
                                        '    Else
                                        '        MessageBox.Show("NO GL A/C FOUND FOR '" + Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) + "' TAX CODE")
                                        '        flag = True
                                        '        Return flag
                                        '    End If
                                        'Else
                                        sqlstring = "Select isnull(inputtaxaccountin,'') as inputtaxaccountin, isnull(OUTputtaxaccountin,'')  as OUTputtaxaccountin from accountstaxmaster where TAXCODE='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("OUTputtaxaccountin")
                                            If accode = "" Then

                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                flag = True
                                                Return flag
                                            End If

                                            If check_VendorTypeRU(txt_Suppliercode.Text) Then
                                                If acdesc = "" Then

                                                    MessageBox.Show("NO OUTPUT A\C CODE  FOUND FOR ACCOUNT POSTING OF TAXCODE: " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                    flag = True
                                                    Return flag
                                                End If

                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                            flag = True
                                            Return flag
                                        End If
                                        'End If

                                    Next Z
                                Else
                                    MessageBox.Show("TAX GROUP NOT FOUND : " + Trim(AxfpSpread1.Text) + "")
                                    flag = True
                                    Return flag

                                End If
                            End If
                        End If

                    End If

                Next
                If CmbGrnType.Text = "SPONSOR" Then


                    For j As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = j
                        AxfpSpread1.Col = 1
                        If AxfpSpread1.Text <> "" Then
                            AxfpSpread1.Col = 19
                            Dim sqlstring As String = "SELECT * FROM SponsorAccountstagging WHERE code='" & Trim(AxfpSpread1.Text) & "' AND  ISNULL(VOID,'N') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If gdataset.Tables("CODE").Rows.Count > 0 Then

                                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                                If accode = "" Then

                                    MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING...")
                                    flag = True
                                    Return flag

                                End If
                                If accode <> "" And costcode = "" Then

                                    MessageBox.Show("NO COST CENTRE CODE FOR SPON. POSTING...")
                                    flag = True
                                    Return flag

                                End If

                            Else
                                MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                flag = True
                                Return flag
                            End If
                        End If

                    Next
                End If
            End If

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
                            Cmd_Add.Enabled = True
                            Return flag
                        End If
                    Next
                Else
                    MessageBox.Show("Issue All Nonstockable Items", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Cmd_Add.Enabled = True
                    Return flag
                End If
            End If
        End If


        'If check_taxcode() = True Then

        '    flag = True
        '    Return flag


        'End If
        Return False
    End Function

    Private Function validateonvoid() As Boolean

        Dim flag As Boolean
        Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd"))
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
        If gShortname = "SKYYE" Then
            sqlstring = "SELECT APPROVE FROM PO_HDR WHERE pono='" & Txt_PONo.Text & "' "
            gconnection.getDataSet(sqlstring, "updte")
            Dim APPR As String
            APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
            If APPR = "Y" Then
                MsgBox("This Po is already Approved  You can't void it ")
                flag = True
                Return flag
            End If
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

        If txt_Storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_Storecode.BackColor = Color.Red
            txt_Storecode.Focus()
            flag = True
            Return flag
        Else
            txt_Storecode.BackColor = Color.White

        End If
        If Trim(CmbGrnType.SelectedItem) = "PO" Then
            If Txt_PONo.Text = "" And Txt_PONo.Visible = True Then
                MessageBox.Show("Please Fill POno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Txt_PONo.BackColor = Color.Red
                Txt_PONo.Focus()

                flag = True
                Return flag
            Else
                Txt_PONo.BackColor = Color.White

            End If
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



        'If check_taxcode() = True Then

        '    flag = True
        '    Return flag


        'End If




        'For i As Integer = 0 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Col = 1
        '    Dim itemcode As String = AxfpSpread1.Text
        '    AxfpSpread1.Col = 4
        '    Dim qty As String = Val(AxfpSpread1.Text)
        '    Dim qty1, trns_seq As Double
        '    Dim batchyn As String
        Dim sql As String
        '= "select qty,batchyn,isnull(trns_seq,0) as trns_seq from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
        '            sql = sql & " and Trnno='" + txt_Grnno.Text + "' "
        '            gconnection.getDataSet(sql, "closingqty")
        '            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '                trns_seq = gdataset.Tables("closingqty").Rows(0).Item("trns_seq")
        '            End If
        '            sql = "select closingstock -" + Format(Val(qty), "0.000") + " from closingqty where trns_seq>='" & trns_seq & "' and itemcode='" + itemcode + "' and storecode='" + txt_Storecode.Text + "' "
        '            sql = sql & " and closingstock -" + Format(Val(qty), "0.000") + "<0 "
        '            If batchyn = "Y" Then
        '                sql = sql & " and batchno='" + txt_Grnno.Text + "'"
        '            End If
        '            gconnection.getDataSet(sql, "closingqty")
        '            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '                MessageBox.Show("Deletion create  " + itemcode + "  Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '                flag = True
        '                Return flag
        '            End If


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



       


        Return False
    End Function


    Private Sub CALCULATE()
        Dim ITEMCODE, UOM As String
        Dim overalldisc, othercharge, extra, ROUNDOFF, grossamt As Double
        Dim totqty, totamt, taxamt, discamt, freeqty, totfreeqty, SPLCESS, ISPLCESS, TOSPLCESS As Double
        Dim itemqty, itemrate, itemamount, itemtax, itemdisc, discperc, taxperc, itemtot, amtwithoutdisc, overdiscextra, overotherextra As Double
        calcbool = True
        If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Or AxfpSpread1.ActiveCol = 7 Or AxfpSpread1.ActiveCol = 8 Or AxfpSpread1.ActiveCol = 10 Or AxfpSpread1.ActiveCol = 12 Or AxfpSpread1.ActiveCol = 16 Or AxfpSpread1.ActiveCol = 17 Or AxfpSpread1.ActiveCol = 21 Or AxfpSpread1.ActiveCol = 13 Then
            For i As Integer = 1 To AxfpSpread1.DataRowCnt



                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                ITEMCODE = Trim(AxfpSpread1.Text)

                AxfpSpread1.Col = 3
                UOM = Trim(AxfpSpread1.Text)


                AxfpSpread1.Row = i
                AxfpSpread1.Col = 16
                If AxfpSpread1.Text <> "Y" Then
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
                    itemamount = Nothing
                    itemamount = itemqty * itemrate
                    If Val(AxfpSpread1.Text) <> Val(itemamount) Then
                        AxfpSpread1.Text = Format(itemamount, "0.00")
                    End If

                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 7
                    discperc = Val(AxfpSpread1.Text)
                    If AxfpSpread1.Text = "0.00" Or AxfpSpread1.Text = "" Then

                        AxfpSpread1.Col = 8
                        AxfpSpread1.Row = i

                        'taxperc = Val(AxfpSpread1.Text)
                        If AxfpSpread1.Text = "0.00" Then
                            itemdisc = (itemamount * discperc) / 100
                            AxfpSpread1.Text = itemdisc
                        Else

                            itemdisc = Val(AxfpSpread1.Text)
                        End If



                    Else
                        itemdisc = (itemamount * discperc) / 100
                        AxfpSpread1.Col = 8
                        AxfpSpread1.Text = itemdisc
                        AxfpSpread1.Col = 9
                        amtwithoutdisc = itemamount - itemdisc
                        AxfpSpread1.Text = amtwithoutdisc
                    End If

                    If ITEMCODE <> "" And UOM <> "" Then

                        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                            SPLCESS = GetSPLCESS(ITEMCODE, Trim(UOM))
                            ISPLCESS = (SPLCESS * itemqty)
                            AxfpSpread1.Col = 21
                            AxfpSpread1.Text = ISPLCESS
                        Else
                            'SPLCESS = GetSPLCESS(ITEMCODE, Trim(UOM))
                            'TOSPLCESS = (SPLCESS * itemqty)
                            AxfpSpread1.Col = 21
                            'AxfpSpread1.Text = TOSPLCESS
                            ISPLCESS = Val(AxfpSpread1.Text)
                        End If
                    Else
                        AxfpSpread1.Col = 21
                        ISPLCESS = Format(AxfpSpread1.Text, "0.00")

                    End If

                    AxfpSpread1.Col = 9
                    amtwithoutdisc = itemamount - itemdisc
                    AxfpSpread1.Text = amtwithoutdisc


                    AxfpSpread1.Col = 11
                    taxperc = Val(AxfpSpread1.Text)



                    AxfpSpread1.Col = 10
                    ' itemtax = Math.Round((amtwithoutdisc * taxperc) / 100)
                    If AxfpSpread1.Text = "NONE" Then
                        itemtax = Math.Round((amtwithoutdisc * taxperc) / 100, 2)
                    Else
                        itemtax = (amtwithoutdisc * taxperc) / 100
                    End If

                    AxfpSpread1.Col = 12
                    AxfpSpread1.Text = itemtax

                    AxfpSpread1.Col = 13

                    ''''SPLCESS
                    TOSPLCESS = TOSPLCESS + ISPLCESS
                    itemamount = itemamount + (ISPLCESS)
                    itemtot = itemamount + itemtax - itemdisc ''+ (SPLCESS * itemqty)
                    '''
                    AxfpSpread1.Text = itemtot
                    totqty = totqty + itemqty
                    totfreeqty = totfreeqty + freeqty
                    totamt = totamt + itemamount
                    taxamt = taxamt + itemtax
                    discamt = discamt + itemdisc
                    grossamt = grossamt + itemtot
                    AxfpSpread1.Col = 11
                    If AxfpSpread1.Lock = True Then
                        AxfpSpread1.Col = 12
                        AxfpSpread1.Lock = True
                    Else
                        AxfpSpread1.Lock = False
                    End If
                End If
            Next

            If GBATCHNO = "N" Then
                AxfpSpread1.Col = 22
                AxfpSpread1.ColHidden = True
               
            Else
                lock_Batchno()
            End If

            If GEXPIRY = "N" Then
                AxfpSpread1.Col = 23
                AxfpSpread1.ColHidden = True
            Else
                AxfpSpread1.Col = 23
                AxfpSpread1.ColHidden = False
            End If

            txt_totdisc.Text = Format(Val(discamt), "0.00")
            txt_totaltax.Text = Math.Round(taxamt, 3)
            txt_total.Text = Format(Val(totamt), "0.00")


            overalldisc = Convert.ToDouble(Format(Val(TXT_OVERALLdiscount.Text), "0.00"))
            othercharge = Convert.ToDouble(Format(Val(txt_Surchargeamt.Text), "0.00"))
            ROUNDOFF = Convert.ToDouble(Format(Val(txt_RoundUP.Text), "0.00"))
            'othercharge = othercharge + ROUNDOFF
            otherchargepo = othercharge
            If (gpocode = "Y" And totpoqty <> 0) Then
                extra = (othercharge - overalldiscountpo) / (totpoqty)
                ' extra = (otherchargepo - overalldiscountpo) / (totpoqty)
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
                    If Mid(UCase(gShortname), 1, 3) = "NIZ" Then
                    Else
                        If (gpocode = "Y" And totpoqty <> 0) Then
                            overdiscextra = overdiscextra + (overalldiscountpo / totpoqty) * itemqty
                            overotherextra = overotherextra + (otherchargepo / totpoqty) * itemqty
                        Else
                            overotherextra = othercharge
                        End If
                    End If
                  

                End If
            Next
            If (gpocode = "Y") Then
                If Mid(UCase(gShortname), 1, 3) = "NIZ" Then
                Else
                    txt_Surchargeamt.Text = Format(Val(overotherextra), "0.00")
                End If

                ' TXT_OVERALLdiscount.Text = Format(Val(overdiscextra) + Val(TXT_OVERALLdiscount.Text), "0.000")

                TXT_OVERALLdiscount.Text = Format(Val(TXT_OVERALLdiscount.Text), "0.00")
            End If
            Txt_SPLCESS.Text = Format(Val(TOSPLCESS), "0.00")
            '  txt_Billamount.Text = Format(Val(txt_total.Text) - Val(overalldisc) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")
            'If UCase(gShortname) = "BRC" Then
            '    Dim bILLAMT, DisAmt, dif As Double

            '    If Val(txt_RoundUP.Text) > 0 Then
            '        txt_Surchargeamt.Text = Format(Val(txt_Surchargeamt.Text) + Val(txt_RoundUP.Text) * -1, "0.000")
            '    Else
            '        TXT_OVERALLdiscount.Text = Format(Val(TXT_OVERALLdiscount.Text) + Val(txt_RoundUP.Text), "0.000")
            '    End If

            '    txt_Billamount.Text = Format(Val(txt_total.Text) - Val(TXT_OVERALLdiscount.Text) + Val(txt_Surchargeamt.Text) + Val(TXT_ERSALETAX.Text) + Val(TXT_ERTAX.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")
            '    bILLAMT = Val(txt_Billamount.Text)
            '    txt_Billamount.Text = Math.Round(Val(txt_Billamount.Text), 0)
            '    If bILLAMT < Val(txt_Billamount.Text) Then
            '        dif = Val(txt_Billamount.Text) - bILLAMT
            '        txt_RoundUP.Text = Format(Val(dif), "0.000")
            '        txt_Surchargeamt.Text = Format(Val(txt_Surchargeamt.Text) + Val(txt_RoundUP.Text), "0.000")
            '        TXT_ERSALETAX.Text = Format(Val(TXT_ERSALETAX.Text) + Val(txt_RoundUP.Text), "0.000")
            '        TXT_ERTAX.Text = Format(Val(TXT_ERTAX.Text) + Val(txt_RoundUP.Text), "0.000")
            '    Else
            '        dif = bILLAMT - Val(txt_Billamount.Text)
            '        txt_RoundUP.Text = Format(Val(dif * -1), "0.000")
            '        TXT_OVERALLdiscount.Text = Format(Val(TXT_OVERALLdiscount.Text) + Val(dif), "0.000")
            '    End If

            'Else

            txt_Billamount.Text = Format(Val(txt_total.Text) + Val(txt_Surchargeamt.Text) + Val(TXT_ERSALETAX.Text) + Val(txt_Ertax.Text) + Val(txt_totaltax.Text) + Val(txt_RoundUP.Text) - (Val(TXT_OVERALLdiscount.Text) + Val(txt_totdisc.Text)), "0.00")

            '            Val(txt_RoundUP.Text) +

            '   End If
            '

            Txt_bill_2.Text = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.00")

        End If
        calcbool = False
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
                txt_Surchargeamt.Text = Format(Val(overotherextra), "0.000")
                TXT_OVERALLdiscount.Text = Format(Val(overdiscextra), "0.000")

            End If
            '  txt_Billamount.Text = Format(Val(txt_total.Text) - Val(overalldisc) + Val(txt_Surchargeamt.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.000")

            '            txt_Billamount.Text = Format(Val(txt_total.Text) + Val(txt_Surchargeamt.Text) + Val(TXT_ERSALETAX.Text) + Val(txt_Ertax.Text) + Val(txt_totaltax.Text) - (Val(TXT_OVERALLdiscount.Text) + Val(txt_totdisc.Text)), "0.000")
            txt_Billamount.Text = Format(Val(txt_total.Text) + Val(txt_Surchargeamt.Text) + Val(TXT_ERSALETAX.Text) + Val(txt_Ertax.Text) + Val(txt_totaltax.Text) - (Val(TXT_OVERALLdiscount.Text) + Val(txt_totdisc.Text)), "0.00")

        End If
    End Sub
    Private Sub clearoperation()
        Txt_GLAcIn.Text = ""
        Txt_GLAcDesc.Text = ""
        Txt_Slcode.Text = ""
        Txt_SlDesc.Text = ""
        'Txt_CostCenterCode.Text = ""
        'Txt_CostCenterDesc.Text = ""
        Txt_PONo.Text = ""
        TXT_Sponsor.Text = ""
        txt_RoundUP.Text = ""
        txt_Grnno.ReadOnly = False
        LBL_SPONSOR.Hide()
        TXT_Sponsor.Hide()
        cmd_SPONhelp.Hide()
        lbl_Freeze.Text = ""
        txt_Grnno.Text = ""
        If CmbGrnType.Text <> "PO" Then
            If CmbGrnType.Text = "DO" Then
                CmbGrnType.Text = "DO"
            Else
                CmbGrnType.Text = "PO"
            End If

        End If
        CmbGrnType.Enabled = True
        CMB_CATEGORY.Enabled = True
        ' CMB_CATEGORY.SelectedIndex = 0
        ' CMB_CATEGORY.Items.Clear()
        If gvendorlink = "Y" Then
            txt_Suppliercode.Enabled = True
            cmd_Suppliercodehelp.Enabled = True
        End If
        CmbGrnType.Enabled = True
        CMB_CATEGORY.Enabled = True

        txt_Storecode.Enabled = True
        Cmd_Storecode.Enabled = True


        Label4.Show()
        Txt_PONo.Show()
        cmd_PONOhelp.Show()

        If Trim(UCase(gShortname)) = "KBA" Or Trim(UCase(gShortname)) = "NIZAM" Or Trim(UCase(gShortname)) = "FNCC" Then
            autogenerate()
        End If

        dtp_Grndate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Suppliercode.Text = ""
        txt_Suppliername.Text = ""
        txt_Supplierinvno.Text = ""
        dtp_Supplierinvdate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Storecode.Text = ""
        txt_StoreDesc.Text = ""
        Txt_SPLCESS.Text = ""
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        txt_total.Text = ""
        txt_totaltax.Text = ""
        txt_totdisc.Text = ""
        TXT_OVERALLdiscount.Text = ""
        txt_Surchargeamt.Text = ""
        txt_Billamount.Text = ""
        TXT_ERSALETAX.Text = ""
        TXT_ERTAX.Text = ""
        txt_Remarks.Text = ""
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        Cmd_Add.Enabled = True
        Cmd_Freeze.Enabled = True
        GridUnLock()
        nonstockable.Rows.Clear()

        Label2.Text = "TOTAL TAX"

        txt_Billamount.Visible = True
        Txt_bill_2.Visible = False

        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True

        nonstockable.Columns.Clear()
        For k As Integer = 0 To 10
            For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                AxfpSpread1.TypeComboBoxClear(3, k)
                AxfpSpread1.TypeComboBoxClear(18, k)
            Next
        Next
        GroupBox8.Visible = True
        GroupBox9.Visible = True
        GRP_GRNDET.Visible = False

        GRP_HSN.Visible = False
        Label26.Visible = False
        Label27.Visible = False
        Label26.Text = ""
        Label27.Text = ""

        If GBATCHNO = "N" Then
            AxfpSpread1.Col = 22
            AxfpSpread1.ColHidden = True
        Else
            lock_Batchno()
        End If

        If GEXPIRY = "N" Then
            AxfpSpread1.Col = 23
            AxfpSpread1.ColHidden = True
        End If

        If GSHELVING = "N" Then
            AxfpSpread1.Col = 24
            AxfpSpread1.ColHidden = True
        End If
        If gShortname = "KSCA" Then
            AxfpSpread1.Col = 25
            AxfpSpread1.ColHidden = True
        Else
            AxfpSpread1.Col = 25
            AxfpSpread1.ColHidden = True
        End If


        GetLastNo()
    End Sub
    Private Sub GetLastNo()
        Dim SQLSTRING As String
        Dim DR As DataRow
        CATCODE = Split(CMB_CATEGORY.Text, "--->")
        SQLSTRING = "SELECT Isnull(Max(GRNDETAILS),0)as GRNDETAILS FROM GRN_HEADER where category='" & Trim(CATCODE(0)) & "'"
        gconnection.getDataSet(SQLSTRING, "membermaster")
        If gdataset.Tables("membermaster").Rows.Count > 0 Then
            Me.Lbl_Last.Text = "Last No IS : " & " " & gdataset.Tables("membermaster").Rows(0).Item(0)
        Else
            Me.Lbl_Last.Text = "Last No" & " " & 0
        End If

    End Sub
    Private Sub clearoperation1()
        Txt_PONo.Text = ""
        TXT_Sponsor.Text = ""
        'LBL_SPONSOR.Hide()
        'TXT_Sponsor.Hide()
        'cmd_SPONhelp.Hide()
        'CmbGrnType.SelectedItem = "PO"
        'Label4.Show()
        'Txt_PONo.Show()
        'cmd_PONOhelp.Show()

        '  autogenerate()
        dtp_Grndate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Suppliercode.Text = ""
        txt_Suppliername.Text = ""
        txt_Supplierinvno.Text = ""
        dtp_Supplierinvdate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Storecode.Text = ""
        txt_StoreDesc.Text = ""
        'AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        txt_total.Text = ""
        txt_totaltax.Text = ""
        txt_totdisc.Text = ""
        Txt_SPLCESS.Text = ""
        TXT_OVERALLdiscount.Text = ""
        txt_Surchargeamt.Text = ""
        txt_Billamount.Text = ""
        txt_Remarks.Text = ""
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        Cmd_Add.Enabled = True
        ' GridUnLock()
        nonstockable.Rows.Clear()

        nonstockable.Columns.Clear()
        If AxfpSpread1.IsHandleCreated = True Then

            AxfpSpread1.Row = 1
            AxfpSpread1.Col = 19
            If AxfpSpread1.ColHidden = False Then
                For RW As Integer = 1 To 100

                    AxfpSpread1.Col = 19
                    AxfpSpread1.ColHidden = True
                Next
            End If
        End If

    End Sub

    Private Function addoperation()
        Dim GRNNO_NEW As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim uom As String
        Dim fquom As String
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        Dim weightedrate As Double
        Dim lastweightedrate As Double
        Dim STOCKUOM As String
        Dim CONVVALUE As Double
        Dim FQCONVVALUE As Double
        Dim precise As Double
        Dim fqprecise As Double
        Try


            If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                Call autogenerate()
            End If
            GRNno = Split(Trim(txt_Grnno.Text), "/")
            CATCODE = Split(CMB_CATEGORY.Text, "--->")
            If Mid(UCase(gShortname), 1, 3) = "MBC" Or Mid(UCase(gShortname), 1, 3) = "FMC" Then
                GRNNO_NEW = CStr(GRNno(2))
            Else
                GRNNO_NEW = CStr(GRNno(3))
            End If


            sqlstring = "INSERT INTO Grn_header(category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
            ' sqlstring = sqlstring & ",Typecode,Typedesc,Excisepassno,Excisedate,Stockindate,Trucknumber,Creditdays,Glaccountcode,Glaccountname,Slcode,Slname,Costcentercode,Costcentername,"
            If gShortname = "CPC" Then
                sqlstring = sqlstring & "ERSALETAX,ERTAX,"
            End If
            sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,GRN_TYPE1,RoundupAmt,glacccode,glaccdesc,slcode,sldesc)"

            If (Trim(CmbGrnType.SelectedItem) = "PO" Or Trim(CmbGrnType.Text) = "DO") And grp_Grngroup1.Visible = True Then

                If UCase(gpocode) <> "Y" Then
                    versionno = Trim(txt_Grnno.Text + "-0")
                    potype = Trim("")
                End If

                sqlstring = sqlstring & " VALUES ('" & Trim(CATCODE(0)) & "','" & CStr(GRNNO_NEW) & "','" & Trim(CStr(txt_Grnno.Text)) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
                '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
                '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
                ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
                If gShortname = "CPC" Then
                    sqlstring = sqlstring & " " & Format(Val(TXT_ERSALETAX.Text), "0.000") & "," & Format(Val(txt_Ertax.Text), "0.000") & ","
                End If
                sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.000") & "," & Format(Val(txt_totaltax.Text), "0.000") & "," & Format(Val(txt_Surchargeamt.Text), "0.000") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.000") & "," & Format(Val(txt_totdisc.Text), "0.000") & ","
                sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.000") & ","
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',GETDATE(),"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
                sqlstring = sqlstring & "  'GRN','" + versionno + "','" + CmbGrnType.Text + "'," + Format(Val(txt_RoundUP.Text), "0.000") + ",'" & Trim(Txt_GLAcIn.Text) & "','" & Trim(Txt_GLAcDesc.Text) & "','" & Trim(Txt_Slcode.Text) & "','" & Trim(Txt_SlDesc.Text) & "')"
            Else

                sqlstring = sqlstring & " VALUES ('" & Trim(CATCODE(0)) & "','" & CStr(GRNNO_NEW) & "','" & Trim(CStr(txt_Grnno.Text)) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_Sponsor.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
                If gShortname = "CPC" Then
                    sqlstring = sqlstring & " " & Format(Val(TXT_ERSALETAX.Text), "0.000") & "," & Format(Val(TXT_ERTAX.Text), "0.000") & ","
                End If
                '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
                '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
                ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
                sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.000") & "," & Format(Val(txt_totaltax.Text), "0.000") & "," & Format(Val(txt_Surchargeamt.Text), "0.000") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.000") & "," & Format(Val(txt_totdisc.Text), "0.000") & ","
                sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.000") & ","
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',GETDATE(),"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
                sqlstring = sqlstring & "  'GRN','','" + CmbGrnType.Text + "'," + Format(Val(txt_RoundUP.Text), "0.000") + ",'" & Trim(Txt_GLAcIn.Text) & "','" & Trim(Txt_GLAcDesc.Text) & "','" & Trim(Txt_Slcode.Text) & "','" & Trim(Txt_SlDesc.Text) & "')"

            End If

            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            ' Dim Seq As Double = gconnection.getInvSeq(Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy"))
            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                Dim fqqty As Double
                Dim qty1 As Double
                If Trim(CmbGrnType.SelectedItem) = "PO" Or Trim(CmbGrnType.Text) = "DO" Then
                    sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
                    If gShortname = "CPC" Then
                        sqlstring = sqlstring & "ERSALETAX,ERTAX,"
                    End If
                    If GBATCHNO = "Y" Then
                        sqlstring = sqlstring & "Batch_no,"
                    End If
                    If GEXPIRY = "Y" Then
                        sqlstring = sqlstring & "ExpiryDate,"
                    End If
                    sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,Discount,amountafterdiscount,taxcode,TaxPer,taxamount,amount,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FqUom,SPONSORCODE,SPLCESS,MRPRATE)"
                    sqlstring = sqlstring & " VALUES('" & CStr(GRNNO_NEW) & "','" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
                    sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
                    sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
                    AxfpSpread1.Col = 1
                    itemcode1 = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    If gShortname = "CPC" Then
                        sqlstring = sqlstring & " " & Format(Val(TXT_ERSALETAX.Text), "0.000") & "," & Format(Val(TXT_ERTAX.Text), "0.000") & ","
                    End If
                    If GBATCHNO = "Y" Then
                        AxfpSpread1.Col = 22
                        sqlstring = sqlstring & " '" & Trim(txt_Grnno.Text) & "',"
                    End If

                    If GEXPIRY = "Y" Then
                        AxfpSpread1.Col = 23
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
                    qty1 = Format(Val(AxfpSpread1.Text), "0.000")
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 5
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 6
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 7
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 8
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 9
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 10
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

                    AxfpSpread1.Col = 11
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 12
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 13
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    totalamount = Val(AxfpSpread1.Text)
                    ' sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                    AxfpSpread1.Col = 14
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                    AxfpSpread1.Col = 15
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    totalothchg = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 16
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

                    sqlstring = sqlstring & "'" & Trim(CATCODE(0)) & "',"
                    sqlstring = sqlstring & "'" & Trim(gUsername) & "',GETDATE(),"
                    sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
                    sqlstring = sqlstring & "'GRN','" + versionno + "',"

                    AxfpSpread1.Col = 17
                    fqqty = Format(Val(AxfpSpread1.Text), "0.000")
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 18
                    fquom = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 19
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

                    AxfpSpread1.Col = 21
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 25
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ")"


                Else
                    sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
                    If gShortname = "CPC" Then
                        sqlstring = sqlstring & "ERSALETAX,ERTAX,"
                    End If
                    sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,Discount,amountafterdiscount,taxcode,TaxPer,taxamount,amount,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FREEQTY,FqUom,SPONSORCODE,companycode,"
                    If GBATCHNO = "Y" Then
                        sqlstring = sqlstring & "Batch_no,"
                    End If
                    If GEXPIRY = "Y" Then
                        sqlstring = sqlstring & "ExpiryDate,"
                    End If
                    If GSHELVING = "Y" Then
                        sqlstring = sqlstring & "SHELF,"
                    End If
                    sqlstring = sqlstring & "SPLCESS,MRPRATE)"

                    sqlstring = sqlstring & " VALUES('" & CStr(GRNNO_NEW) & "','" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"

                    sqlstring = sqlstring & " '" & Trim(TXT_Sponsor.Text) & " ',"
                    sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
                    AxfpSpread1.Col = 1
                    itemcode1 = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    If gShortname = "CPC" Then
                        sqlstring = sqlstring & " " & Format(Val(TXT_ERSALETAX.Text), "0.000") & "," & Format(Val(TXT_ERTAX.Text), "0.000") & ","
                    End If
                    AxfpSpread1.Col = 3
                    uom = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 4
                    qty1 = Format(Val(AxfpSpread1.Text), "0.000")
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 5
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 6
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 7
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 8
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 9
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 10
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

                    AxfpSpread1.Col = 11
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 12
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 13
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    totalamount = Val(AxfpSpread1.Text)
                    ' sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                    AxfpSpread1.Col = 14
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                    AxfpSpread1.Col = 15
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    totalothchg = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 16
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

                    sqlstring = sqlstring & "'" & Trim(CATCODE(0)) & "',"
                    sqlstring = sqlstring & "'" & Trim(gUsername) & "',GETDATE(),"
                    sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
                    sqlstring = sqlstring & "'GRN','',"

                    AxfpSpread1.Col = 17
                    fqqty = Format(Val(AxfpSpread1.Text), "0.000")
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                    AxfpSpread1.Col = 18
                    fquom = AxfpSpread1.Text
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 19

                    sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 20
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                    'If GBATCHNO = "Y" Then
                    '    AxfpSpread1.Col = 22
                    '    sqlstring = sqlstring & " '" & Trim(txt_Grnno.Text) & "',"
                    '    AxfpSpread1.Col = 23
                    '    If AxfpSpread1.Text = "" Then
                    '        sqlstring = sqlstring & " '01/01/1900',"
                    '    Else
                    '        sqlstring = sqlstring & " '" & Format(CDate(AxfpSpread1.Text), "dd/MMM/yyyy") & "',"
                    '    End If
                    'End If

                    If GBATCHNO = "Y" Then
                        AxfpSpread1.Col = 22
                        sqlstring = sqlstring & " '" & Trim(txt_Grnno.Text) & "',"
                    End If

                    If GEXPIRY = "Y" Then
                        AxfpSpread1.Col = 23
                        If AxfpSpread1.Text = "" Then
                            sqlstring = sqlstring & " '01/01/1900',"
                        Else
                            sqlstring = sqlstring & " '" & Format(CDate(AxfpSpread1.Text), "dd/MMM/yyyy") & "',"
                        End If
                    End If

                    If GSHELVING = "Y" Then
                        AxfpSpread1.Col = 24
                        sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                    End If
                    AxfpSpread1.Col = 21
                    sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Col = 25
                    sqlstring = sqlstring & " '" & Format(Val(AxfpSpread1.Text), "0.000") & "')"

                End If
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring



                sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode1 + "'"
                STOCKUOM = gconnection.getvalue(sqlstring)
                sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
                gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                Else
                    MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
                '=====Adding Free Qty for CCL ==========
                If Trim(UCase(gShortname)) = "CCL" Then
                    sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + fquom + "'"
                    gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        FQCONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                        fqprecise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                        fqqty = (fqqty / FQCONVVALUE) + (fqqty * fqprecise)
                        qty1 = qty1 + fqqty
                    Else
                        MessageBox.Show("Generate relation between " + uom + " and " + fquom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Function
                    End If
                Else

                End If

                sqlstring = "insert into ratelist(grnno,batchno,itemcode,uom,batchrate,grndate,weightedrate,lastweightedrate,storecode,adddate,adduser)"
                sqlstring = sqlstring & " values ('" + txt_Grnno.Text + "',"
                AxfpSpread1.Col = 14
                sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
                AxfpSpread1.Col = 1
                sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
                AxfpSpread1.Col = 3
                sqlstring = sqlstring & "'" + AxfpSpread1.Text + "', "
                AxfpSpread1.Col = 5
                sqlstring = sqlstring & "'" + Format(Val((totalamount + totalothchg) / qty1), "0.000") + "' ,"
                sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
                sqlstring = sqlstring & "0 , "
                sqlstring = sqlstring & "0 , "
                sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',GETDATE(),'" & Trim(gUsername) & "')"
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

                '                If gShortname = "KSCA" Then
                Dim item As String
                AxfpSpread1.Col = 1
                item = AxfpSpread1.Text
                AxfpSpread1.Col = 25
                If AxfpSpread1.Text > 0 Then
                    sqlstring = "update inv_inventoryitemmaster set mrprate='" + AxfpSpread1.Text + "' where itemcode='" + item + "'"
                    ReDim Preserve GrnQuery(GrnQuery.Length)
                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                End If
                'End If

            Next


            sqlstring = " UPDATE Grn_details SET ITEM_TYPE  = 'YES' WHERE ITEM_TYPE IS NULL AND Itemcode IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem)  AND Grndetails ='" + txt_Grnno.Text + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            sqlstring = " UPDATE Grn_details SET ITEM_TYPE  = 'NO' WHERE ISNULL(ITEM_TYPE,'')='' AND Itemcode NOT  IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem) AND Grndetails ='" + txt_Grnno.Text + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring


            If Trim(CmbGrnType.SelectedItem) = "DO" Then

                sqlstring = "update DI_DET set receivedqty=isnull((select sum(qty-isnull(RET_QTY,0)) as qty from Grn_details g where g.Itemcode=DI_DET.ITEMCODE and g.pono=DI_DET.DINO  and isnull(g.Voiditem,'N')<>'Y' ),0) where DINO='" & Txt_PONo.Text & "'  "
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

                sqlstring = "    Update   DI_HDR set DISTATUS='RELEASED' where DINO  in   (select distinct DINO from DI_DET where isnull(QTY,0)<>isnull(receivedqty,0)) "
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

                sqlstring = "   Update   DI_HDR set DISTATUS='CLOSED' where DINO not in   (select distinct DINO from DI_DET where isnull(QTY,0)<>isnull(receivedqty,0))"
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

            End If



            'If (GACCPOST.ToUpper() = "Y") Then
            '    Call accountPost()
            '    If check = False Then
            '        Exit Function
            '    End If
            'End If



            If (gdirissue = "Y") Then
                If nonstockable.Rows.Count > 0 Then
                    Call Addissueoperation()
                End If
            End If

        Catch ex As Exception
            Throw
        End Try

    End Function




    Private Sub accountPost()

        Dim sqlstring, roundup, OTHACCOUNTCODE As String


        sqlstring = " select isnull(ROUNDUPYESNO,'N') as ROUNDUPYESNO,isnull(OTHACCOUNTCODE,'') as OTHACCOUNTCODE from inv_linksetup"
        gconnection.getDataSet(sqlstring, "setup")
        If gdataset.Tables("setup").Rows.Count > 0 Then
            roundup = gdataset.Tables("setup").Rows(0).Item("ROUNDUPYESNO")
            OTHACCOUNTCODE = gdataset.Tables("setup").Rows(0).Item("OTHACCOUNTCODE")
        End If

        check = False
        ' Dim INSERT(0) As String
        '========================= POSTING FOR SPONSOR CREDIT===========================================

        If Trim(CmbGrnType.SelectedItem) = "SPONSOR" And CmbGrnType.Visible = True Then

            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                If AxfpSpread1.Text <> "" Then
                    AxfpSpread1.Col = 19
                    sqlstring = "Select * from SponsorAccountstagging where code='" & AxfpSpread1.Text & "' AND  isnull(VOID,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                        acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                        If accode = "" Then

                            MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING...")
                            check = False
                            Exit Sub

                        End If
                        If accode <> "" And costcode = "" Then

                            MessageBox.Show("NO COST CENTRE CODE FOR SPON. POSTING...")
                            check = False
                            Exit Sub

                        End If
                        AxfpSpread1.Col = 13

                        amt = Val(AxfpSpread1.Text)
                        If amt > 0 Then


                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                            sqlstring = sqlstring & "'" & acdesc & "',"
                            sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                            sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'CREDIT',"
                            'amt = Format(Val(txt_Billamount.Text), "0.000")
                            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                            sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                            slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N')"
                            ReDim Preserve GrnQuery(GrnQuery.Length)
                            GrnQuery(GrnQuery.Length - 1) = sqlstring
                        End If
                    Else
                        MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING. : '" & TXT_Sponsor.Text & "'")
                        check = False
                        Exit Sub
                    End If
                End If

            Next


            If gAcPostingWise = "ITEM" Then

                Dim amount, POSTAMT As Double
                For k As Integer = 1 To AxfpSpread1.DataRowCnt

                    AxfpSpread1.Row = k
                    AxfpSpread1.Col = 9
                    amount = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                        gconnection.getDataSet(sqlstring, "CODE")
                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                            If accode = "" Then

                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                check = False
                                Exit Sub


                            End If
                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                            sqlstring = sqlstring & "'" & acdesc & "',"
                            sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                            sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'DEBIT',"

                            amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                            sqlstring = sqlstring & "'" & amount & "','" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N')"
                            ReDim Preserve GrnQuery(GrnQuery.Length)
                            GrnQuery(GrnQuery.Length - 1) = sqlstring
                        Else
                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                            check = False
                            Exit Sub

                        End If
                    End If

                Next

            ElseIf gAcPostingWise = "CATEGORY" Then
                sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                        check = False
                        Exit Sub


                    End If
                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                    sqlstring = sqlstring & "'" & acdesc & "',"
                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                    sqlstring = sqlstring & "'DEBIT',"

                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    'slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N')"
                    ReDim Preserve GrnQuery(GrnQuery.Length)
                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                    check = False
                    Exit Sub

                End If

            Else
                sqlstring = "Select * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
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


                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    If amt > 0 Then


                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                        sqlstring = sqlstring & "'" & acdesc & "',"
                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        sqlstring = sqlstring & "'DEBIT',"


                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N')"
                        ReDim Preserve GrnQuery(GrnQuery.Length)
                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                    End If
                Else
                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                    check = False
                    Exit Sub
                End If




            End If


            If Val(txt_totaltax.Text) <> 0 Then


                Dim amount, POSTAMT As Double
                Dim TAXyN As String

                '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER ==========================





                For k As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = k

                    AxfpSpread1.Col = 10
                    TAXyN = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 1


                    If Trim(AxfpSpread1.Text) <> "" And TAXyN <> "" Then
                        If TAXyN = "NONE" Then
                            AxfpSpread1.Col = 12
                            POSTAMT = Val(AxfpSpread1.Text)
                            AxfpSpread1.Col = 1
                            sqlstring = "Select  isnull(taxrebate,'NO') AS taxrebate from INV_InventoryItemMaster where itemcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'"
                            gconnection.getDataSet(sqlstring, "INV_InventoryItemMaster")
                            If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                                If gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("taxrebate") = "YES" Then

                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS YES ==========================
                                    sqlstring = "Select * from accountstaxmaster where TAXCODE='" + TAXyN + "'"
                                    gconnection.getDataSet(sqlstring, "CODE")

                                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                        accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                        acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                                        'slcode = gdataset.Tables("CODE").Rows(0).Item("subledgercode")
                                        'sldesc = gdataset.Tables("CODE").Rows(0).Item("subledgerdesc")
                                        'costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                        'costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                        slcode = "" : sldesc = "" : costcode = "" : costdesc = ""
                                        If accode = "" Then

                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                            check = False
                                            Exit Sub
                                        End If

                                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                        sqlstring = sqlstring & "'" & acdesc & "',"
                                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                        sqlstring = sqlstring & "'DEBIT',"
                                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                        sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                        slcode = txt_Storecode.Text
                                        sqlstring = sqlstring & "'N')"
                                        ReDim Preserve GrnQuery(GrnQuery.Length)
                                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                                    Else
                                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                        check = False
                                        Exit Sub
                                    End If
                                Else
                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS NO ==========================

                                    accode = ""
                                    acdesc = ""
                                    slcode = ""
                                    sldesc = ""
                                    costcode = ""
                                    costdesc = ""

                                    If gAcPostingWise = "ITEM" Then
                                        AxfpSpread1.Col = 1
                                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then

                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(AxfpSpread1.Text) + "")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                            check = False
                                            Exit Sub
                                        End If
                                    ElseIf gAcPostingWise = "CATEGORY" Then
                                        sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                            check = False
                                            Exit Sub

                                        End If
                                    Else
                                        sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountDESC")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                                            check = False
                                            Exit Sub
                                        End If
                                    End If
                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'DEBIT',"
                                    'amt = Format(Val(txt_totaltax.Text), "0.000")
                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                    sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                    slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N')"
                                    ReDim Preserve GrnQuery(GrnQuery.Length)
                                    GrnQuery(GrnQuery.Length - 1) = sqlstring

                                End If
                            End If
                        Else
                            amount = 0
                            POSTAMT = 0

                            AxfpSpread1.Col = 9
                            amount = Val(AxfpSpread1.Text)

                            AxfpSpread1.Col = 10
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "Select  tax,taxper from invtaxgroupmasterdetail where taxgroupcode='" & Trim(AxfpSpread1.Text) & "'   AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)  AND ISNULL(VOID,'N')<>'Y'  "
                                gconnection.getDataSet(sqlstring, "invtaxgroupmasterdetail")
                                If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then

                                    For Z As Integer = 0 To gdataset.Tables("invtaxgroupmasterdetail").Rows.Count - 1

                                        POSTAMT = (amount * Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAXPER"))) / 100
                                        If POSTAMT > 0 Then
                                            If UCase(gShortname) <> "CCL" Then
                                                sqlstring = "select * from TaxAccountstagging where TaxCode='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "' AND ISNULL(VOID,'N')<>'Y'"
                                                gconnection.getDataSet(sqlstring, "TaxAccountstagging")
                                                If (gdataset.Tables("TaxAccountstagging").Rows.Count > 0) Then

                                                    accode = gdataset.Tables("TaxAccountstagging").Rows(0).Item("GLACCOUNTCODE")
                                                    acdesc = gdataset.Tables("TaxAccountstagging").Rows(0).Item("GLACCOUNTDESC")
                                                    slcode = gdataset.Tables("TaxAccountstagging").Rows(0).Item("slcode")
                                                    sldesc = gdataset.Tables("TaxAccountstagging").Rows(0).Item("sldesc")
                                                    costcode = ""
                                                    costdesc = ""
                                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                                    sqlstring = sqlstring & "'DEBIT',"
                                                    'amt = Format(Val(txt_totaltax.Text), "0.000")
                                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                                    sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                                    slcode = txt_Storecode.Text
                                                    sqlstring = sqlstring & "'N')"
                                                    ReDim Preserve GrnQuery(GrnQuery.Length)
                                                    GrnQuery(GrnQuery.Length - 1) = sqlstring


                                                Else
                                                    MessageBox.Show("NO GL A/C FOUND FOR " + Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("taxcode")) + " TAXCODE")
                                                    check = False
                                                    Exit Sub
                                                End If
                                            Else

                                                sqlstring = "Select * from accountstaxmaster where TAXCODE='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "'"
                                                gconnection.getDataSet(sqlstring, "CODE")

                                                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                                    accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                                    acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                                                    'slcode = gdataset.Tables("CODE").Rows(0).Item("subledgercode")
                                                    'sldesc = gdataset.Tables("CODE").Rows(0).Item("subledgerdesc")
                                                    'costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                                    'costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                                    slcode = "" : sldesc = "" : costcode = "" : costdesc = ""
                                                    If accode = "" Then

                                                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                        check = False
                                                        Exit Sub
                                                    End If

                                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                                    sqlstring = sqlstring & "'DEBIT',"
                                                    'amt = Format(Val(txt_totaltax.Text), "0.000")
                                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                                    sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                                    slcode = txt_Storecode.Text
                                                    sqlstring = sqlstring & "'N')"
                                                    ReDim Preserve GrnQuery(GrnQuery.Length)
                                                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                                                Else
                                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                    check = False
                                                    Exit Sub
                                                End If
                                            End If
                                        End If
                                    Next Z
                                Else
                                    MessageBox.Show("TAX GROUP NOT FOUND")
                                    check = False
                                    Exit Sub
                                End If
                            End If
                        End If

                    End If
                Next
                'End If

            End If
            '====================== POSTING FOR PO PART==========================
        Else

           
            '====================== POSTING FOR SUPPLIER (CREDIT)==========================
            sqlstring = "select slcode, sldesc,ACCODE,ACDESC from accountssubledgermaster  WHERE "
            sqlstring = sqlstring & "SLCODE='" & txt_Suppliercode.Text & "' AND  isnull(freezeflag,'')<>'Y'  and accode in( select ScrsCode from ACCOUNTSSETUP)"
            gconnection.getDataSet(sqlstring, "SLCODE1")

            If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                accode = gdataset.Tables("SLCODE1").Rows(0).Item("ACCODE")
                slcode = gdataset.Tables("SLCODE1").Rows(0).Item("SLCODE")
                sldesc = gdataset.Tables("SLCODE1").Rows(0).Item("SLDESC")
                acdesc = gdataset.Tables("SLCODE1").Rows(0).Item("ACDESC")
            Else
                MessageBox.Show("CREATE SLCODE FOR SUPPLIER IN ACCOUNTSSUBLEDGERMASTER...")
                check = False
                Exit Sub
            End If
            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID)"
            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
            sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
            sqlstring = sqlstring & "'" & acdesc & "',"
            sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
            ' sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
            sqlstring = sqlstring & "'CREDIT',"
            If roundup = "Y" Then
                amt = Format(Val(txt_Billamount.Text), "0")
                roundAmt = Format(Format(Val(txt_Billamount.Text), "0.00") - amt, "0.00")
            Else
                amt = Format(Val(txt_Billamount.Text), "0.000")
            End If

            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
            sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

            slcode = txt_Storecode.Text
            sqlstring = sqlstring & "'N')"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            If roundup = "Y" Then
                sqlstring = "select isnull(ACCODE,'') as ACCODE,isnull(ACDESC,'') as ACDESC  from accountsglaccountmaster  WHERE "
                sqlstring = sqlstring & "acCODE='" & OTHACCOUNTCODE & "' AND  isnull(freezeflag,'')<>'Y'  "
                gconnection.getDataSet(sqlstring, "SLCODE1")

                If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                    accode = gdataset.Tables("SLCODE1").Rows(0).Item("ACCODE")
                    slcode = ""
                    sldesc = ""
                    acdesc = gdataset.Tables("SLCODE1").Rows(0).Item("ACDESC")
                Else
                    MessageBox.Show("CREATE SLCODE FOR SUPPLIER IN ACCOUNTSSUBLEDGERMASTER...")
                    check = False
                    Exit Sub
                End If

                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                sqlstring = sqlstring & "'" & acdesc & "',"
                sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                ' sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                If roundAmt > 0 Then
                    sqlstring = sqlstring & "'CREDIT',"
                Else
                    sqlstring = sqlstring & "'DEBIT',"
                    roundAmt = roundAmt * -1
                End If


                decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                sqlstring = sqlstring & "'" & roundAmt & "','" & decription & "',"

                slcode = txt_Storecode.Text
                sqlstring = sqlstring & "'N')"
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

            End If
            
            '====================== POSTING FOR PO PART  DEBIT SIDE ==========================
            If gAcPostingWise = "ITEM" Then

                Dim amount, POSTAMT As Double
                For k As Integer = 1 To AxfpSpread1.DataRowCnt

                    AxfpSpread1.Row = k

                    AxfpSpread1.Col = 9
                    amount = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                        gconnection.getDataSet(sqlstring, "CODE")
                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                            If accode = "" Then

                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(AxfpSpread1.Text) + "")
                                check = False
                                Exit Sub


                            End If
                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                            sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                            sqlstring = sqlstring & "'" & acdesc & "',"
                            sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                            sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'DEBIT',"

                            amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                            decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                            sqlstring = sqlstring & "'" & amount & "','" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N')"
                            ReDim Preserve GrnQuery(GrnQuery.Length)
                            GrnQuery(GrnQuery.Length - 1) = sqlstring
                        Else
                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                            check = False
                            Exit Sub

                        End If
                    End If

                Next




            ElseIf gAcPostingWise = "CATEGORY" Then
                sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                gconnection.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                    acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                    slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                    sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                    costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                    costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                    If accode = "" Then

                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                        check = False
                        Exit Sub


                    End If
                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                    sqlstring = sqlstring & "'" & acdesc & "',"
                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                    sqlstring = sqlstring & "'DEBIT',"

                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    'slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N')"
                    ReDim Preserve GrnQuery(GrnQuery.Length)
                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                Else
                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                    check = False
                    Exit Sub

                End If

            Else
                sqlstring = "Select * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
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
                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                    sqlstring = sqlstring & "'" & acdesc & "',"
                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                    sqlstring = sqlstring & "'DEBIT',"

                    amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                    sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                    'slcode = txt_Storecode.Text
                    sqlstring = sqlstring & "'N')"
                    ReDim Preserve GrnQuery(GrnQuery.Length)
                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                Else
                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                    check = False
                    Exit Sub
                End If




            End If
            '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) ==========================


            If Val(txt_totaltax.Text) <> 0 Then


                Dim amount, POSTAMT As Double
                Dim TAXyN As String

                '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER ==========================
                For k As Integer = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = k

                    AxfpSpread1.Col = 10
                    TAXyN = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 1


                    If Trim(AxfpSpread1.Text) <> "" And TAXyN <> "" Then
                        If TAXyN = "NONE" Then
                            AxfpSpread1.Col = 12
                            POSTAMT = Val(AxfpSpread1.Text)
                            AxfpSpread1.Col = 1
                            sqlstring = "Select  isnull(taxrebate,'NO') AS taxrebate from INV_InventoryItemMaster where ITEMcode='" & Trim(AxfpSpread1.Text) & "' AND ISNULL(VOID,'N')<>'Y'"
                            gconnection.getDataSet(sqlstring, "INV_InventoryItemMaster")
                            If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                                If gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("taxrebate") = "YES" Then

                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS YES ==========================
                                    sqlstring = "Select * from accountstaxmaster where TAXCODE='" + TAXyN + "'"
                                    gconnection.getDataSet(sqlstring, "CODE")

                                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                        accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                        acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                                        'slcode = gdataset.Tables("CODE").Rows(0).Item("subledgercode")
                                        'sldesc = gdataset.Tables("CODE").Rows(0).Item("subledgerdesc")
                                        'costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                        'costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                        slcode = ""
                                        sldesc = ""
                                        costcode = ""
                                        costdesc = ""
                                        If accode = "" Then

                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                            check = False
                                            Exit Sub
                                        End If

                                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                        sqlstring = sqlstring & "'" & acdesc & "',"
                                        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                        sqlstring = sqlstring & "'DEBIT',"
                                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                                        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                        sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                        slcode = txt_Storecode.Text
                                        sqlstring = sqlstring & "'N')"
                                        ReDim Preserve GrnQuery(GrnQuery.Length)
                                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                                    Else
                                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " + Trim(TAXyN) + "")
                                        check = False
                                        Exit Sub
                                    End If
                                Else
                                    '====================== POSTING FOR PO PART  DEBIT SIDE (TAX PART) FOR OTHER IF TAXREBAT IS NO ==========================

                                    accode = ""
                                    acdesc = ""
                                    slcode = ""
                                    sldesc = ""
                                    costcode = ""
                                    costdesc = ""

                                    If gAcPostingWise = "ITEM" Then
                                        AxfpSpread1.Col = 1
                                        sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then

                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(AxfpSpread1.Text) + "")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                            check = False
                                            Exit Sub
                                        End If
                                    ElseIf gAcPostingWise = "CATEGORY" Then
                                        sqlstring = "Select * from AccountstaggingForCategory where CATEGORYcode='" & Trim(CATCODE(0)) & "'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(CATCODE(0)) + "")
                                            check = False
                                            Exit Sub

                                        End If
                                    Else
                                        sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                                        gconnection.getDataSet(sqlstring, "CODE")
                                        If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                            accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                                            acdesc = gdataset.Tables("CODE").Rows(0).Item("AccountDESC")
                                            slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                                            sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                                            costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                            costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                            If accode = "" Then
                                                MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                                                check = False
                                                Exit Sub
                                            End If
                                        Else
                                            MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                                            check = False
                                            Exit Sub
                                        End If
                                    End If
                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                    sqlstring = sqlstring & "'" & acdesc & "',"
                                    sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                    sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'DEBIT',"
                                    'amt = Format(Val(txt_totaltax.Text), "0.000")
                                    decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                    sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                    slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N')"
                                    ReDim Preserve GrnQuery(GrnQuery.Length)
                                    GrnQuery(GrnQuery.Length - 1) = sqlstring

                                End If
                            End If
                        Else
                            amount = 0
                            POSTAMT = 0
                            AxfpSpread1.Col = 9
                            amount = Val(AxfpSpread1.Text)

                            AxfpSpread1.Col = 10
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "Select  tax,taxper from invtaxgroupmasterdetail where taxgroupcode='" & Trim(AxfpSpread1.Text) & "'   AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)  AND ISNULL(VOID,'N')<>'Y'  "
                                gconnection.getDataSet(sqlstring, "invtaxgroupmasterdetail")
                                If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then

                                    For Z As Integer = 0 To gdataset.Tables("invtaxgroupmasterdetail").Rows.Count - 1
                                        POSTAMT = (amount * Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAXPER"))) / 100


                                        If UCase(gShortname) <> "CCL12" Then

                                            '    sqlstring = "select * from TaxAccountstagging where TaxCode='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "' AND ISNULL(VOID,'N')<>'Y'"
                                            '    gconnection.getDataSet(sqlstring, "TaxAccountstagging")

                                            '    If (gdataset.Tables("TaxAccountstagging").Rows.Count > 0) Then

                                            '        accode = gdataset.Tables("TaxAccountstagging").Rows(0).Item("GLACCOUNTCODE")
                                            '        acdesc = gdataset.Tables("TaxAccountstagging").Rows(0).Item("GLACCOUNTDESC")
                                            '        slcode = gdataset.Tables("TaxAccountstagging").Rows(0).Item("slcode")
                                            '        sldesc = gdataset.Tables("TaxAccountstagging").Rows(0).Item("sldesc")
                                            '        costcode = ""
                                            '        costdesc = ""
                                            '        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                            '        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                            '        sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                            '        sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                            '        sqlstring = sqlstring & "'" & acdesc & "',"
                                            '        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                            '        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                            '        sqlstring = sqlstring & "'DEBIT',"
                                            '        'amt = Format(Val(txt_totaltax.Text), "0.000")
                                            '        decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                            '        sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                            '        slcode = txt_Storecode.Text
                                            '        sqlstring = sqlstring & "'N')"
                                            '        ReDim Preserve GrnQuery(GrnQuery.Length)
                                            '        GrnQuery(GrnQuery.Length - 1) = sqlstring

                                            '    Else
                                            '        MessageBox.Show("NO GL A/C FOUND FOR " + Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) + " TAXCODE")
                                            '        check = False
                                            '        Exit Sub
                                            '    End If
                                            'Else
                                            sqlstring = "Select * from accountstaxmaster where TAXCODE='" & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "'"
                                            gconnection.getDataSet(sqlstring, "CODE")

                                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                                accode = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountin")
                                                acdesc = gdataset.Tables("CODE").Rows(0).Item("inputtaxaccountinDESC")
                                                'slcode = gdataset.Tables("CODE").Rows(0).Item("subledgercode")
                                                'sldesc = gdataset.Tables("CODE").Rows(0).Item("subledgerdesc")
                                                'costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                                                'costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                                                slcode = "" : sldesc = "" : costcode = "" : costdesc = ""
                                                If accode = "" Then

                                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                    check = False
                                                    Exit Sub
                                                End If

                                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                                                sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                                                sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                                                sqlstring = sqlstring & "'" & acdesc & "',"
                                                sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                                                sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                                sqlstring = sqlstring & "'DEBIT',"
                                                'amt = Format(Val(txt_totaltax.Text), "0.000")
                                                decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                                                sqlstring = sqlstring & "'" & POSTAMT & "','" & decription & "',"

                                                slcode = txt_Storecode.Text
                                                sqlstring = sqlstring & "'N')"
                                                ReDim Preserve GrnQuery(GrnQuery.Length)
                                                GrnQuery(GrnQuery.Length - 1) = sqlstring
                                            Else
                                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF TAXCODE " & Trim(gdataset.Tables("invtaxgroupmasterdetail").Rows(Z).Item("TAX")) & "")
                                                check = False
                                                Exit Sub
                                            End If
                                        End If


                                    Next Z
                                Else
                                    MessageBox.Show("TAX GROUP NOT FOUND")
                                    check = False
                                    Exit Sub
                                End If
                            End If
                        End If

                    End If
                Next
                'End If
            End If
        End If

        check = True
        'gconnection.MoreTrans1(INSERT)
    End Sub



    Private Function accountPostingValidation() As Boolean
        Dim flag As Boolean
        Dim sqlstring As String
        Dim INSERT(0) As String



        '========================= POSTING FOR SPONSOR CREDIT===========================================

        If Trim(CmbGrnType.SelectedItem) = "SPONSOR" And CmbGrnType.Visible = True Then
            sqlstring = "Select * from SponsorAccountstagging where code='" & TXT_Sponsor.Text & "' AND  isnull(VOID,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "CODE")
            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                If accode = "" Then

                    MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING...")
                    check = False
                    Exit Function

                End If
                If accode <> "" And costcode = "" Then

                    MessageBox.Show("NO COST CENTRE CODE FOR SPON. POSTING...")
                    check = False
                    Exit Function

                End If

                'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                'sqlstring = sqlstring & "'" & acdesc & "',"
                'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                'sqlstring = sqlstring & "'CREDIT',"
                'amt = Format(Val(txt_Billamount.Text), "0.000")
                'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                'slcode = txt_Storecode.Text
                'sqlstring = sqlstring & "'N')"
                'ReDim Preserve INSERT(INSERT.Length)
                'INSERT(INSERT.Length - 1) = sqlstring
            Else
                MessageBox.Show("NO GL FOUND FOR SPONSORSHIP POSTING. : '" & TXT_Sponsor.Text & "'")
                check = False
                Exit Function
            End If




            sqlstring = "Select * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
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
                    Exit Function


                End If
                'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                'sqlstring = sqlstring & "'" & acdesc & "',"
                'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                'sqlstring = sqlstring & "'DEBIT',"

                'amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                ''slcode = txt_Storecode.Text
                'sqlstring = sqlstring & "'N')"
                'ReDim Preserve INSERT(INSERT.Length)
                'INSERT(INSERT.Length - 1) = sqlstring
                If Val(txt_totaltax.Text) <> 0 Then
                    sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("TAXGLCODE")
                        acdesc = gdataset.Tables("CODE").Rows(0).Item("TAXGLDESC")
                        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                        If accode = "" Then
                            MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                            check = False
                            Exit Function
                        End If

                        'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                        'sqlstring = sqlstring & "'" & acdesc & "',"
                        'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        'sqlstring = sqlstring & "'DEBIT',"
                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                        'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        'sqlstring = sqlstring & "'N')"
                        'ReDim Preserve INSERT(INSERT.Length)
                        'INSERT(INSERT.Length - 1) = sqlstring
                    Else
                        MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                        check = False
                        Exit Function
                    End If
                End If

            Else
                MessageBox.Show("CREATE SLCODE FOR STORE IN ACCOUNTSSUBLEDGERMASTER...")
                check = False
                Exit Function
            End If
        Else
            '====================== POSTING FOR SUPPLIER (CREDIT)==========================
            sqlstring = "select slcode, sldesc,ACCODE,ACDESC from accountssubledgermaster  WHERE "
            sqlstring = sqlstring & "SLCODE='" & txt_Suppliercode.Text & "' AND  isnull(freezeflag,'')<>'Y'  and accode in( select ScrsCode from ACCOUNTSSETUP)"
            gconnection.getDataSet(sqlstring, "SLCODE1")

            If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                accode = gdataset.Tables("SLCODE1").Rows(0).Item("ACCODE")
                slcode = gdataset.Tables("SLCODE1").Rows(0).Item("SLCODE")
                sldesc = gdataset.Tables("SLCODE1").Rows(0).Item("SLDESC")
                acdesc = gdataset.Tables("SLCODE1").Rows(0).Item("ACDESC")
            Else
                MessageBox.Show("CREATE SLCODE FOR SUPPLIER IN ACCOUNTSSUBLEDGERMASTER...")
                check = False
                Exit Function
            End If
            'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID)"
            'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
            'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
            'sqlstring = sqlstring & "'" & acdesc & "',"
            'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
            '' sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
            'sqlstring = sqlstring & "'CREDIT',"
            'amt = Format(Val(txt_Billamount.Text), "0.000")
            'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
            'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

            'slcode = txt_Storecode.Text
            'sqlstring = sqlstring & "'N')"
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = sqlstring



            sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "CODE")
            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                If accode = "" Then
                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING")
                    check = False
                    Exit Function
                End If
                'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                'sqlstring = sqlstring & "'" & acdesc & "',"
                'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                'sqlstring = sqlstring & "'DEBIT',"

                'amt = Format(Val(txt_Billamount.Text) - Val(txt_totaltax.Text), "0.000")
                'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                ''slcode = txt_Storecode.Text
                'sqlstring = sqlstring & "'N')"
                'ReDim Preserve INSERT(INSERT.Length)
                'INSERT(INSERT.Length - 1) = sqlstring
                If Val(txt_totaltax.Text) <> 0 Then
                    sqlstring = "Select  * from AccountstaggingNEW where code='" & txt_Storecode.Text & "' AND ISNULL(VOID,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("TAXGLCODE")
                        acdesc = gdataset.Tables("CODE").Rows(0).Item("TAXGLDESC")
                        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")
                        If accode = "" Then
                            MessageBox.Show("NO GL FOUND FOR TAX POSTING")
                            check = False
                            Exit Function
                        End If

                        'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        'sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
                        'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy ") & "', "
                        'sqlstring = sqlstring & "'" + Trim(CATCODE(0)) + "', 'GRN', '" & accode & "',"
                        'sqlstring = sqlstring & "'" & acdesc & "',"
                        'sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                        'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        'sqlstring = sqlstring & "'DEBIT',"
                        'amt = Format(Val(txt_totaltax.Text), "0.000")
                        'decription = "Purchase bill no " + txt_Supplierinvno.Text + " date " + dtp_Supplierinvdate.Text + ""
                        'sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        'sqlstring = sqlstring & "'N')"
                        'ReDim Preserve INSERT(INSERT.Length)
                        'INSERT(INSERT.Length - 1) = sqlstring
                    Else
                        MessageBox.Show("NO GL FOUND FOR TAX POSTING FOR StoreCode:-'" & txt_Storecode.Text & "'")
                        check = False
                        Exit Function
                    End If
                End If

            End If

        End If






        gconnection.MoreTrans1(INSERT)
    End Function
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
                                    If Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then
                                        'amt = Format((Val((txt_Billamount.Text)) / TOTALISSUEQTY) * qty, "0.000")
                                        amt = Format(rate * qty, "0.000")
                                    Else
                                        'amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text)) / TOTALISSUEQTY) * qty, "0.000")
                                        amt = Format(rate * qty, "0.000")
                                    End If

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

                                    If Trim(CmbGrnType.SelectedItem) = "SPONSOR" Then
                                        ' amt = Format(Val((txt_Billamount.Text)), "0.000")
                                        amt = Format(rate * qty, "0.000")
                                    Else
                                        amt = Format(rate * qty, "0.000")
                                        ' amt = Format((Val((txt_Billamount.Text) - Val(txt_totaltax.Text))), "0.000")
                                    End If
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
        sqlstring = sqlstring & " Void='Y',voiduser='" & Trim(gUsername) & "',"
        sqlstring = sqlstring & " voiddate=GETDATE()"
        sqlstring = sqlstring & "  where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        INSERT(0) = sqlstring

        sqlstring = "Update  Grn_details set  voidITEM='Y',VoidUser='" & Trim(gUsername) & "',VoidDate=GETDATE() where Grndetails='" + Trim(txt_Grnno.Text) + "'"
         ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring

        sqlstring = "Update  stockissuedetail set  void='Y' where batchno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring

        sqlstring = "Update  STOCKISSUEHEADER set  void='Y' where Docdetails in (select Docdetails from stockissuedetail  where batchno='" + Trim(txt_Grnno.Text) + "' )"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring


        If (GACCPOST.ToUpper() = "Y") Then

            sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
            sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo IN (SELECT DOCDETAILS FROM STOCKISSUEDETAIL WHERE BATCHNO='" + Trim(txt_Grnno.Text) + "') AND VOUCHERTYPE='ISSUE'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

        End If

        If Trim(CmbGrnType.SelectedItem) = "PO" Then
            sqlstring = "Update po_itemdetails set receivedqty=receivedqty-qty,QTYstatus='' from PO_ITEMDETAILS inner join Grn_details"
            sqlstring = sqlstring & "    on PO_ITEMDETAILS.ITEMCODE=Grn_details.Itemcode and PO_ITEMDETAILS.pono=Grn_details.pono and PO_ITEMDETAILS.versionno=Grn_details.versionno "
            sqlstring = sqlstring & " where Grn_details.pono='" + Txt_PONo.Text + "' and Grn_details.versionno='" + versionno + "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            sqlstring = "update po_hdr set postatus='RELEASED' where pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
        ElseIf Trim(CmbGrnType.SelectedItem) = "DO" Then
            sqlstring = "update DI_DET set receivedqty=isnull((select sum(qty-isnull(RET_QTY,0)) as qty from Grn_details g where g.Itemcode=DI_DET.ITEMCODE and g.pono=DI_DET.DINO  and isnull(g.Voiditem,'N')<>'Y' ),0) where  DINO='" & Txt_PONo.Text & "'  "
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            sqlstring = "    Update   DI_HDR set DISTATUS='RELEASED' where DINO  in   (select distinct DINO from DI_DET where isnull(QTY,0)<>isnull(receivedqty,0)) "
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            sqlstring = "   Update   DI_HDR set DISTATUS='CLOSED' where DINO not in   (select distinct DINO from DI_DET where isnull(QTY,0)<>isnull(receivedqty,0))"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

        End If
        sqlstring = "update ratelist  set void='Y' where   grnno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring

        gconnection.MoreTrans(INSERT)




    End Sub


    Private Sub cancelAdd()
        Dim GrnQuery(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim lastweightedrate As Double
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        GRNno = Split(Trim(txt_Grnno.Text), "/")

        sqlstring = " delete from Grn_header where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"

        'sqlstring = "Update  Grn_header set "
        'sqlstring = sqlstring & " void='Y'"
        'sqlstring = sqlstring & "  where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   Grn_details  where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ' sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   closingqty  where trnno='" + Trim(txt_Grnno.Text) + "'"
        ' sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        If (GACCPOST.ToUpper() = "Y") Then
            '    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring
            sqlstring = "delete from  JOURNALENTRY where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ' sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

        End If

        sqlstring = "delete from  ratelist where   grnno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        gconnection.MoreTrans1(GrnQuery)

    End Sub
    Private Sub cancelUpdate()
        Dim GrnQuery(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim lastweightedrate As Double
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        GRNno = Split(Trim(txt_Grnno.Text), "/")

        sqlstring = " delete from Grn_header where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   Grn_details  where Grndetails='" + Trim(txt_Grnno.Text) + "'"


        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   closingqty  where trnno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring

        If (GACCPOST.ToUpper() = "Y") Then
            sqlstring = "delete from  JOURNALENTRY where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

        End If

        sqlstring = "delete from  ratelist where   grnno='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        gconnection.MoreTrans1(GrnQuery)

        sqlstring = "INSERT INTO GRN_HEADER(category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
        sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno)"
        sqlstring = sqlstring & " SELECT category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
        sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno"
        sqlstring = sqlstring & " FROM GRN_HEADERlog WHERE Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring

        sqlstring = "iNSERT INTO GRN_DETAILS(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
        sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FQUOM,oldqty,trns_seq)"

        sqlstring = sqlstring & " SELECT Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
        sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FQUOM,oldqty,trns_seq"
        sqlstring = sqlstring & "  FROM Grn_detailslog where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring

    End Sub



    Private Sub voidoperationupdate()
        Dim INSERT(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim lastweightedrate As Double
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        GRNno = Split(Trim(txt_Grnno.Text), "/")

        sqlstring = " delete from Grn_header where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"

        'sqlstring = "Update  Grn_header set "
        'sqlstring = sqlstring & " void='Y'"
        'sqlstring = sqlstring & "  where Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   Grn_details  where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ' sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        sqlstring = "delete from   closingqty  where trnno='" + Trim(txt_Grnno.Text) + "'"
        ' sqlstring = "Update  Grn_details set  voidITEM='Y' where Grndetails='" + Trim(txt_Grnno.Text) + "'"
        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring
        If (GACCPOST.ToUpper() = "Y") Then
            '    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            '    ReDim Preserve INSERT(INSERT.Length)
            '    INSERT(INSERT.Length - 1) = sqlstring
            sqlstring = "delete from  JOURNALENTRY where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ' sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

        End If

        If Trim(CmbGrnType.SelectedItem) = "PO" Then
            sqlstring = "Update po_itemdetails set receivedqty=receivedqty-qty,QTYstatus='' from PO_ITEMDETAILS inner join Grn_details"
            sqlstring = sqlstring & "    on PO_ITEMDETAILS.ITEMCODE=Grn_details.Itemcode and PO_ITEMDETAILS.pono=Grn_details.pono and PO_ITEMDETAILS.versionno=Grn_details.versionno "
            sqlstring = sqlstring & " where Grn_details.pono='" + Txt_PONo.Text + "' and Grn_details.versionno='" + versionno + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring
            sqlstring = "update po_hdr set postatus='RELEASED' where pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring
        End If
        sqlstring = "delete from  ratelist where   grnno='" + Trim(txt_Grnno.Text) + "'"

        ReDim Preserve GrnQuery(GrnQuery.Length)
        GrnQuery(GrnQuery.Length - 1) = sqlstring

        'gconnection.MoreTrans1(INSERT)
    End Sub

    Private Sub UpdateOperation()
        'Dim INSERT(0) As String
        Dim GRNNO_NEW As String
        Dim sqlstring As String
        Dim itemcode1 As String
        Dim uom As String
        Dim totalamount As Decimal
        Dim totalothchg As Decimal
        Dim weightedrate As Decimal
        Dim lastweightedrate As Decimal
        'Dim INSERT1(0) As String
        'Dim INSERT2(0) As String
        Dim stockuom As String
        Dim convvalue As Double
        Dim precise As Double
        Dim FQCONVVALUE As Double

        Dim fqprecise As Double

        Dim fqqty As Double
        Dim fquom As String
        sqlstring = "select * from grn_details WHERE Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "' and cast(convert(varchar(11),grndate,106)as datetime)='" & Format(Me.dtp_Grndate.Value, "dd/MMM/yyyy") & "'"
        gconnection.getDataSet(sqlstring, "backdate")
        If gdataset.Tables("backdate").Rows.Count > 0 Then

            GRNno = Split(Trim(txt_Grnno.Text), "/")
            CATCODE = Split(CMB_CATEGORY.Text, "--->")

            If Mid(UCase(gShortname), 1, 3) = "MBC" Or Mid(UCase(gShortname), 1, 3) = "FMC" Then
                GRNNO_NEW = CStr(GRNno(2))
            Else
                GRNNO_NEW = CStr(GRNno(3))
            End If

            sqlstring = "INSERT INTO GRN_HEADERLOG(category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
            If gShortname = "CPC" Then
                sqlstring = sqlstring & "ERSALETAX,ERTAX,"
            End If
            sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,RoundupAmt,glacccode,glaccdesc,slcode,sldesc)"
            sqlstring = sqlstring & " SELECT category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
            If gShortname = "CPC" Then
                sqlstring = sqlstring & "ERSALETAX,ERTAX,"
            End If
            sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,RoundupAmt,glacccode,glaccdesc,slcode,sldesc"
            sqlstring = sqlstring & " FROM GRN_HEADER WHERE Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            sqlstring = " DELETE FROM GRN_HEADER WHERE Grndetails='" + Trim(CStr(txt_Grnno.Text)) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            sqlstring = "iNSERT INTO GRN_DETAILSLOG(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
            If gShortname = "CPC" Then
                sqlstring = sqlstring & "ERSALETAX,ERTAX,"
            End If
            sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FQUOM,oldqty,trns_seq,"
            If GBATCHNO = "Y" Then
                sqlstring = sqlstring & "Batch_no,"
            End If
            If GEXPIRY = "Y" Then
                sqlstring = sqlstring & "ExpiryDate,"
            End If
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "SHELF,"
            End If
            sqlstring = sqlstring & " SPLCESS)"


            sqlstring = sqlstring & " Select Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
            If gShortname = "CPC" Then
                sqlstring = sqlstring & "ERSALETAX,ERTAX,"
            End If
            sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FQUOM,oldqty,trns_seq,"
            If GBATCHNO = "Y" Then
                sqlstring = sqlstring & "Batch_no,"
            End If
            If GEXPIRY = "Y" Then
                sqlstring = sqlstring & "ExpiryDate,"
            End If

            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "SHELF,"
            End If
            sqlstring = sqlstring & "SPLCESS"

            sqlstring = sqlstring & "  FROM Grn_details where Grndetails='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            sqlstring = " insert into ratelist_up ([grnno],[batchno],[Itemcode],[uom],[batchrate],[weightedrate],[lastweightedrate],[storecode],[adddate],[adduser],[grndate],[freezeuser],[freezedatetime],[VOID],[TRNS_SEQ])"
            sqlstring = sqlstring & "select [grnno],[batchno],[Itemcode],[uom],[batchrate],[weightedrate],[lastweightedrate],[storecode],[adddate],[adduser],[grndate],[freezeuser],[freezedatetime],[VOID],[TRNS_SEQ] from ratelist   WHERE grnno='" + Trim(CStr(txt_Grnno.Text)) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            sqlstring = " DELETE FROM RATELIST WHERE grnno='" + Trim(CStr(txt_Grnno.Text)) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            sqlstring = "INSERT INTO Grn_header(category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername,"
            If gShortname = "CPC" Then
                sqlstring = sqlstring & "ERSALETAX,ERTAX,"
            End If
            sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype,versionno,Grn_type1,RoundupAmt,glacccode,glaccdesc,slcode,sldesc)"
            sqlstring = sqlstring & " VALUES ('" & Trim(CATCODE(0)) & "','" & CStr(GRNNO_NEW) & "','" & Trim(CStr(txt_Grnno.Text)) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
            If Trim(CmbGrnType.SelectedItem) = "PO" Or Trim(CmbGrnType.SelectedItem) = "DO" Then
                sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
            Else
                sqlstring = sqlstring & " '" & Trim(TXT_Sponsor.Text) & "',"
            End If

            sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
            If gShortname = "CPC" Then
                sqlstring = sqlstring & " " & Format(Val(TXT_ERSALETAX.Text), "0.000") & "," & Format(Val(TXT_ERTAX.Text), "0.000") & ","
            End If
            sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.000") & "," & Format(Val(txt_totaltax.Text), "0.000") & "," & Format(Val(txt_Surchargeamt.Text), "0.000") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.000") & "," & Format(Val(txt_totdisc.Text), "0.000") & ","
            sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.000") & ","
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',GETDATE(),"
            sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
            sqlstring = sqlstring & "  'GRN','" + versionno + "','" + CmbGrnType.Text + "'," + Format(Val(txt_RoundUP.Text), "0.000") + ",'" & Trim(Txt_GLAcIn.Text) & "','" & Trim(Txt_GLAcDesc.Text) & "','" & Trim(Txt_Slcode.Text) & "','" & Trim(Txt_SlDesc.Text) & "')"

            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            sqlstring = "Delete from Grn_details where Grndetails='" + Trim(txt_Grnno.Text) + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            If Trim(CmbGrnType.SelectedItem) = "PO" And grp_Grngroup1.Visible = True Then

                sqlstring = "Update po_itemdetails set receivedqty=receivedqty-qty,qtystatus='' from PO_ITEMDETAILS inner join Grn_details"
                sqlstring = sqlstring & "    on PO_ITEMDETAILS.ITEMCODE=Grn_details.Itemcode and PO_ITEMDETAILS.pono=Grn_details.pono and PO_ITEMDETAILS.versionno=Grn_details.versionno  "
                sqlstring = sqlstring & " where Grn_details.pono='" + Txt_PONo.Text + "' and grn_details.versionno='" + versionno + "' "
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

                sqlstring = "update po_hdr set postatus='RELEASED' where pono='" + Txt_PONo.Text + "'"
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring
            ElseIf Trim(CmbGrnType.SelectedItem) = "DO" And grp_Grngroup1.Visible = True Then
            End If

            Dim sql1 As String
            Dim SEQ1 As Double
            Dim seq As Double

            For i As Integer = 1 To AxfpSpread1.DataRowCnt

                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1

                sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
                If gShortname = "CPC" Then
                    sqlstring = sqlstring & "ERSALETAX,ERTAX,"
                End If
                sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,Discount,amountafterdiscount,taxcode,TaxPer,taxamount,amount,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,versionno,FreeQty,FqUom,oldqty,TRNS_SEQ,SPONSORCODE,COMPANYcode,"
                If GBATCHNO = "Y" Then
                    sqlstring = sqlstring & "Batch_no,"
                End If
                If GEXPIRY = "Y" Then
                    sqlstring = sqlstring & "ExpiryDate,"
                End If
                If GSHELVING = "Y" Then
                    sqlstring = sqlstring & "SHELF,"
                End If
                sqlstring = sqlstring & " SPLCESS,MRPRATE)"

                sqlstring = sqlstring & " VALUES('" & CStr(GRNNO_NEW) & "','" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"

                If Trim(CmbGrnType.SelectedItem) = "PO" Or Trim(CmbGrnType.SelectedItem) = "DO" Then
                    sqlstring = sqlstring & " '" & Trim(Txt_PONo.Text) & "',"
                Else
                    sqlstring = sqlstring & " '" & Trim(TXT_Sponsor.Text) & "',"
                End If


                sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
                AxfpSpread1.Col = 1
                itemcode1 = AxfpSpread1.Text
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 2
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                If gShortname = "CPC" Then
                    sqlstring = sqlstring & " " & Format(Val(TXT_ERSALETAX.Text), "0.000") & "," & Format(Val(TXT_ERTAX.Text), "0.000") & ","
                End If
                AxfpSpread1.Col = 3
                uom = AxfpSpread1.Text
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 4
                Dim qty1 As Double = Format(Val(AxfpSpread1.Text), "0.000")
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 5
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 6
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                AxfpSpread1.Col = 7
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                AxfpSpread1.Col = 8
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 9
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 10
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

                AxfpSpread1.Col = 11
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 12
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                AxfpSpread1.Col = 13
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                totalamount = Val(AxfpSpread1.Text)
                ' sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                AxfpSpread1.Col = 14
                sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                AxfpSpread1.Col = 15
                sqlstring = sqlstring & " '" & Format(Val(AxfpSpread1.Text), "0.000") & "',"
                totalothchg = Val(AxfpSpread1.Text)

                AxfpSpread1.Col = 16
                sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

                sqlstring = sqlstring & "'" & Trim(CATCODE(0)) & "',"
                sqlstring = sqlstring & "'" & Trim(gUsername) & "',GETDATE(),"
                sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"

                If Trim(CmbGrnType.SelectedItem) = "PO" Or Trim(CmbGrnType.SelectedItem) = "DO" Then
                    sqlstring = sqlstring & "'GRN','" + versionno + "',"
                Else
                    sqlstring = sqlstring & "'GRN', '',"
                End If


                AxfpSpread1.Col = 17
                fqqty = Format(Val(AxfpSpread1.Text), "0.000")
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                AxfpSpread1.Col = 18
                fquom = AxfpSpread1.Text
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

                sql1 = "select qty,batchyn,AUTOID from closingqty where  itemcode='" + itemcode1 + "' and storecode='" + txt_Storecode.Text + "' "
                sql1 = sql1 & " and Trnno='" + txt_Grnno.Text + "' "
                gconnection.getDataSet(sql1, "closingqty")
                Dim oldQty As Double
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    oldQty = gdataset.Tables("closingqty").Rows(0).Item("qty")
                End If

                sql1 = "select isnull(TRNS_SEQ,0) as TRNS_SEQ FROM CLOSINGQTY where  storecode='" + txt_Storecode.Text + "' "
                sql1 = sql1 & " and Trnno='" + txt_Grnno.Text + "' AND ITEMCODE='" & itemcode1 & "'"
                gconnection.getDataSet(sql1, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
                End If
                AxfpSpread1.Col = 19
                sqlstring = sqlstring & " '" & Format(Val(oldQty), "0.000") & "','" & SEQ1 & "','" + Trim(AxfpSpread1.Text) + "',"
                AxfpSpread1.Col = 20
                sqlstring = sqlstring & " '" + Trim(AxfpSpread1.Text) + "',"
                'If GBATCHNO = "Y" Then
                '    AxfpSpread1.Col = 22
                '    sqlstring = sqlstring & " '" & Trim(txt_Grnno.Text) & "',"
                '    AxfpSpread1.Col = 23
                '    sqlstring = sqlstring & " '" & Format(CDate(AxfpSpread1.Text), "dd/MMM/yyyy") & "',"
                'End If

                If GBATCHNO = "Y" Then
                    AxfpSpread1.Col = 22
                    sqlstring = sqlstring & " '" & Trim(txt_Grnno.Text) & "',"
                End If

                If GEXPIRY = "Y" Then
                    AxfpSpread1.Col = 23
                    If AxfpSpread1.Text = "" Then
                        sqlstring = sqlstring & " '01/01/1900',"
                    Else
                        sqlstring = sqlstring & " '" & Format(CDate(AxfpSpread1.Text), "dd/MMM/yyyy") & "',"
                    End If
                End If
                If GSHELVING = "Y" Then
                    AxfpSpread1.Col = 24
                    sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                End If

                AxfpSpread1.Col = 21
                sqlstring = sqlstring & " " + Format(Val(AxfpSpread1.Text), "0.00") + ","

                AxfpSpread1.Col = 25
                sqlstring = sqlstring & " " + Format(Val(AxfpSpread1.Text), "0.00") + ")"

                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

                AxfpSpread1.Col = 1
                If Trim(CmbGrnType.SelectedItem) = "PO" Then

                    sqlstring = "select isnull(receivedqty,0) as receivedqty ,isnull(qtystatus,'') as qtystatus,isnull(quantity,0) as quantity from  po_itemdetails where isnull(qtystatus,'') <> 'RECEIVED' and pono='" + Txt_PONo.Text + "' and"
                    sqlstring = sqlstring & " itemcode='" + AxfpSpread1.Text + "' and versionno='" + versionno + "'"
                    gconnection.getDataSet(sqlstring, "po_itemdetails")
                    If (gdataset.Tables("po_itemdetails").Rows.Count > 0) Then
                        Dim receivedqty As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("receivedqty"))
                        Dim quantity As Double = Val(gdataset.Tables("po_itemdetails").Rows(0).Item("quantity"))

                        AxfpSpread1.Col = 4
                        qty1 = Format(Val(AxfpSpread1.Text), "0.000")
                        receivedqty = qty1 - receivedqty
                        If (quantity >= receivedqty + qty1) Then

                            AxfpSpread1.Col = 1
                            sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                        ElseIf (quantity = receivedqty + qty1) Then
                            AxfpSpread1.Col = 1
                            sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + ",qtystatus='RECEIVED' where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                        Else
                            MessageBox.Show("Quantity Can't be greater than PO Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If

                    ReDim Preserve GrnQuery(GrnQuery.Length)
                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                End If

                sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode1 + "'"
                stockuom = gconnection.getvalue(sqlstring)
                sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + stockuom + "' and transuom='" + uom + "'"
                gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                Else
                    MessageBox.Show("Generate relation between " + stockuom + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
                If Trim(UCase(gShortname)) = "CCL" Then
                    sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + fquom + "'"
                    gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        FQCONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                        fqprecise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                        fqqty = (fqqty / FQCONVVALUE) + (fqqty * fqprecise)
                        qty1 = qty1 + fqqty
                    Else
                        MessageBox.Show("Generate relation between " + uom + " and " + fquom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Else

                End If

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
                sqlstring = sqlstring & "'" + Format(Val((totalamount + totalothchg) / qty1), "0.000") + "' ,"
                sqlstring = sqlstring & " '" + Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") + "',"
                sqlstring = sqlstring & "0, "
                sqlstring = sqlstring & "0 , "
                sqlstring = sqlstring & "  '" + txt_Storecode.Text + "',GETDATE(),'" & Trim(gUsername) & "')"

                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

                '                If gShortname = "KSCA" Then
                Dim item As String
                AxfpSpread1.Col = 1
                item = AxfpSpread1.Text
                AxfpSpread1.Col = 25
                If AxfpSpread1.Text > 0 Then
                    sqlstring = "update inv_inventoryitemmaster set mrprate='" + AxfpSpread1.Text + "' where itemcode='" + item + "'"
                    ReDim Preserve GrnQuery(GrnQuery.Length)
                    GrnQuery(GrnQuery.Length - 1) = sqlstring
                End If
                'End If
            Next


            sqlstring = " update grn_Details set voiduser='" & Trim(gUsername) & "',Voiddate=getdate() where voiditem='Y' AND Grndetails ='" + txt_Grnno.Text + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            sqlstring = " UPDATE Grn_details SET ITEM_TYPE  = 'YES' WHERE ITEM_TYPE IS NULL AND Itemcode IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem)  AND Grndetails ='" + txt_Grnno.Text + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            sqlstring = " UPDATE Grn_details SET ITEM_TYPE  = 'NO' WHERE ISNULL(ITEM_TYPE,'')='' AND Itemcode NOT  IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem) AND Grndetails ='" + txt_Grnno.Text + "'"
            ReDim Preserve GrnQuery(GrnQuery.Length)
            GrnQuery(GrnQuery.Length - 1) = sqlstring

            'If (GACCPOST.ToUpper() = "Y") Then


            '    sqlstring = "DELETE   JOURNALENTRY  where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
            '    ReDim Preserve GrnQuery(GrnQuery.Length)
            '    GrnQuery(GrnQuery.Length - 1) = sqlstring
            '    accountPost()

            '    If check = False Then
            '        Exit Sub
            '    End If

            'End If

            If Trim(CmbGrnType.SelectedItem) = "PO" And grp_Grngroup1.Visible = True Then
                Dim SQL As String = "select count(*) as a from  po_itemdetails where ISNULL(qtystatus,'') <> 'RECEIVED' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                gconnection.getDataSet(SQL, "po_itemdetails")
                If gdataset.Tables("po_itemdetails").Rows.Count > 0 Then
                    If Val(gdataset.Tables("po_itemdetails").Rows(0).Item("a").ToString()) > 0 Then
                    Else
                        sqlstring = "update po_hdr set postatus='CLOSED' where   pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

                        ReDim Preserve GrnQuery(GrnQuery.Length)
                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                    End If
                End If
            ElseIf Trim(CmbGrnType.SelectedItem) = "DO" Then
                sqlstring = "update DI_DET set receivedqty=isnull((select sum(qty-isnull(RET_QTY,0)) as qty from Grn_details g where g.Itemcode=DI_DET.ITEMCODE and g.pono=DI_DET.DINO  and isnull(g.Voiditem,'N')<>'Y' ),0) where  DINO='" & Txt_PONo.Text & "'  "
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

                sqlstring = "    Update   DI_HDR set DISTATUS='RELEASED' where DINO  in   (select distinct DINO from DI_DET where isnull(QTY,0)<>isnull(receivedqty,0)) "
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

                sqlstring = "   Update   DI_HDR set DISTATUS='CLOSED' where DINO not in   (select distinct DINO from DI_DET where isnull(QTY,0)<>isnull(receivedqty,0))"
                ReDim Preserve GrnQuery(GrnQuery.Length)
                GrnQuery(GrnQuery.Length - 1) = sqlstring

            End If
        Else

            ' ReDim Preserve GrnQuery(0)
            voidoperationupdate()
            addoperation()
        End If


    End Sub

    Private Sub AxfpSpread1_ComboSelChange(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_ComboSelChangeEvent) Handles AxfpSpread1.ComboSelChange
        Dim i As Integer = AxfpSpread1.ActiveRow

        If AxfpSpread1.ActiveCol = 3 Then
            If Trim(AxfpSpread1.Text) <> "" Then

                Dim uomstr As String
                AxfpSpread1.GetText(3, i, uomstr)
                AxfpSpread1.SetText(18, i, uomstr)

            End If
        End If



    End Sub
    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String
        Dim message, title, defaultValue, Ic As String
        Dim myValue As Object
        Dim prate As Decimal

        message = "Enter Batch No"
        title = "Batch No"

        defaultValue = txt_Grnno.Text

        If e.keyCode = Keys.Enter Then
            i = AxfpSpread1.ActiveRow
            'ITEMCODE
            AxfpSpread1.Row = i

            If AxfpSpread1.ActiveCol = 24 Then
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                bindlocation()
            End If

            '            If gShortname = "KSCA" Then
            AxfpSpread1.Col = 25
            AxfpSpread1.Lock = False
            '        End If

            If AxfpSpread1.ActiveCol = 1 And AxfpSpread1.Lock = False Then
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemcode()
                Else
                    CATCODE = Split(CMB_CATEGORY.Text, "--->")



                    SQL = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "'"
                    gconnection.getDataSet(SQL, "Invitem_VendorMaster")





                    SQL = " select I.itemcode,Itemname,uom,batchprocess, isnull(m.mrprate,0) as mrprate, isnull(m.prate,0) as prate from  CLOSINGQTY  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode "
                    If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then

                        If UCase(gShortname) = "NIZAM" Then
                            SQL = SQL & "  where isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "' and I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')" ' and itemcode not in (select itemcode from trnsView where storecode<>'" + txt_Storecode.Text + "' and ttype='GRN'))"
                        ElseIf UCase(gShortname) = "HIND" Or UCase(gShortname) = "MCEME" Then

                            SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
                        Else
                            SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "' and I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')" ' and itemcode not in (select itemcode from trnsView where storecode<>'" + txt_Storecode.Text + "' and ttype='GRN'))"
                        End If



                    Else

                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'" ' and I.itemcode IN (select itemcode from trnsView where storecode<>'" + txt_Storecode.Text + "' and ttype='GRN') "

                    End If

                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                        If Val(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("prate")) <> 0 Then
                            prate = gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("prate")
                            AxfpSpread1.Col = 5
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = prate
                        Else
                            prate = 0
                        End If


                        AxfpSpread1.Col = 3
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow

                        Dim sql1 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                        gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))

                            AxfpSpread1.Col = 18
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                        Next Z

                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then

                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))

                            'AxfpSpread1.Col = 3
                            'AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            'sql1 = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            'gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
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
                            AxfpSpread1.Col = 1

                            If UCase(gShortname) <> "FNCC" Or UCase(gShortname) <> "HGA" Or UCase(gShortname) <> "RCL" Or UCase(gShortname) <> "HIND" Or UCase(gShortname) <> "KIC" Or UCase(gShortname) = "MCEME" Then

                                SQL = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom,isnull(contractyn,'0') as contractyn FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and ITEMCODE='" + Trim(AxfpSpread1.Text) + "'  AND cast('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE"
                                gconnection.getDataSet(SQL, "Invitem_VendorMaster")
                                If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                                    AxfpSpread1.Col = 3
                                    AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                                    AxfpSpread1.Col = 18
                                    AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                                    If prate = 0 Then
                                        AxfpSpread1.Col = 5
                                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                        AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("rate")
                                    End If

                                    If (Val(gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("contractyn")) = 1) Then
                                        AxfpSpread1.Lock = False
                                    Else
                                        AxfpSpread1.Lock = True
                                        If AxfpSpread1.Text = "0.000" Then
                                            AxfpSpread1.Lock = False
                                        Else
                                            AxfpSpread1.Lock = True
                                        End If
                                    End If
                                Else
                                    MessageBox.Show("Vendor Item link Expired . Plz update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                End If

                            End If
                            '' Added by SRI FOR SHELVING
                            If GSHELVING = "Y" Then
                                SQL = "SELECT TOP 1  ISNULL(SHELF,'') AS SHELF FROM LiqRate  WHERE ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + txt_Storecode.Text + "'  and isnull(Voiditem,'N')<>'Y' and   cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY autoid  DESC"
                                gconnection.getDataSet(SQL, "SHELVING")
                                If (gdataset.Tables("SHELVING").Rows.Count > 0) Then
                                    AxfpSpread1.Col = 24
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("SHELVING").Rows(0).Item("SHELF")
                                    AxfpSpread1.Lock = False
                                Else
                                    AxfpSpread1.Col = 24
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Lock = False
                                End If
                            End If
                            '' sri
                            If CATCODE(0) = "LIQ" Or UCase(gShortname) = "NIZAM" Or UCase(gShortname) = "FNCC" Or UCase(gShortname) = "MLRF" Or UCase(gShortname) = "RCL" Or UCase(gShortname) = "HIND" Then

                                If GSUPPLIER = "Y" Then
                                    SQL = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "' and Suppliercode='" + txt_Suppliercode.Text + "'  ORDER BY autoid  DESC"
                                Else
                                    SQL = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY autoid  DESC"
                                End If

                                'SQL = "SELECT TOP 1   rate as rate  FROM LiqRate  WHERE ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and   cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "' and suppliercode='" & txt_Suppliercode.Text & "'   ORDER BY autoid  DESC"
                                gconnection.getDataSet(SQL, "RATE")
                                If (gdataset.Tables("RATE").Rows.Count > 0) Then

                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    If prate = 0 Then
                                        AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))

                                    End If

                                    AxfpSpread1.Lock = False
                                Else
                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    'AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    AxfpSpread1.Lock = False
                                End If
                            Else
                                If gShortname <> "BBSR" Then
                                    If GSUPPLIER = "Y" Then
                                        SQL = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "' and Suppliercode='" + txt_Suppliercode.Text + "'  ORDER BY autoid  DESC"
                                    Else
                                        SQL = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY autoid  DESC"
                                    End If

                                    'SQL = "SELECT TOP 1   rate as rate  FROM LiqRate  WHERE ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and   cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "' and suppliercode='" & txt_Suppliercode.Text & "'  ORDER BY autoid  DESC"

                                    gconnection.getDataSet(SQL, "RATE")
                                    If (gdataset.Tables("RATE").Rows.Count > 0) Then

                                        AxfpSpread1.Col = 5
                                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                        If prate = 0 Then
                                            AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                        End If
                                        AxfpSpread1.Lock = False
                                    Else
                                        AxfpSpread1.Col = 5
                                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                        'AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                        AxfpSpread1.Lock = False
                                    End If
                                End If

                            End If
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

                            If UCase(gShortname) <> "CCL" Then
                                If check_VendorType(txt_Suppliercode.Text) Then

                                    AxfpSpread1.Col = 10
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = ""

                                    AxfpSpread1.Col = 11
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = ""
                                    AxfpSpread1.Lock = True
                                Else
                                    SQL = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                                    SQL = SQL & " AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                                    gconnection.getDataSet(SQL, "Itemtaxtagging")

                                    'SQL = "select TAXCODE, taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                                    'gconnection.getDataSet(SQL, "Itemtaxtagging")

                                    If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                                        If (check_tAXtYPE(gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxcode"))) = False Then
                                            AxfpSpread1.Col = 10
                                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                                            AxfpSpread1.Col = 11
                                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxper")
                                            AxfpSpread1.Lock = True

                                        End If
                                    Else
                                        MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                    End If
                                End If


                            End If

                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)


                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)

                        End If
                    End If
                End If
                If UCase(gShortname) = "CCFC" Then
                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        SQL = "SELECT TOP 1   RATE as rate,UOM  FROM GRN_DETAILS WHERE ITEMCODE='" + Trim(AxfpSpread1.Text) + "' AND storecode='" + txt_Storecode.Text + "' ORDER BY AUTOID DESC"
                        gconnection.getDataSet(SQL, "RATE")
                        If (gdataset.Tables("RATE").Rows.Count > 0) Then

                            Label10.Text = Trim(AxfpSpread1.Text) & "   :   "

                            Label10.Text = Label10.Text & Trim(gdataset.Tables("RATE").Rows(0).Item("RATE")) + "/ " & Trim(gdataset.Tables("RATE").Rows(0).Item("UOM")) + " "

                        Else
                            Label10.Text = ""
                        End If
                    End If
                End If
                If UCase(gShortname) = "OUT" Then
                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        SQL = "SELECT TOP 1   RATE as rate,UOM  FROM GRN_DETAILS WHERE ITEMCODE='" + Trim(AxfpSpread1.Text) + "' AND storecode='" + txt_Storecode.Text + "' ORDER BY AUTOID DESC"
                        gconnection.getDataSet(SQL, "RATE")
                        If (gdataset.Tables("RATE").Rows.Count > 0) Then

                            Label10.Text = Trim(AxfpSpread1.Text) & "   :   "

                            Label10.Text = Label10.Text & Trim(gdataset.Tables("RATE").Rows(0).Item("RATE")) + "/ " & Trim(gdataset.Tables("RATE").Rows(0).Item("UOM")) + " "

                        Else
                            Label10.Text = ""
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
                        AxfpSpread1.Col = 21
                        AxfpSpread1.Text = val
                    End If
                    Call UPdateHSNNO(item)

                    If Mid(UCase(gShortname), 1, 3) = "RGC" Then
                        Dim sqlstring As String
                        sqlstring = " select  isnull(hsnno,'') AS hsnno    FROM INV_INVENTORYITEMMASTER WHERE ITEMCODE='" & item & "'  and  isnull(hsnno,'')<>''"
                        gconnection.getDataSet(sqlstring, "INV")
                        If gdataset.Tables("INV").Rows.Count > 0 Then
                            Label26.Text = item
                            Label27.Text = Trim(gdataset.Tables("INV").Rows(0).Item("hsnno"))

                            GRP_HSN.Visible = True
                            Label26.Visible = True
                            Label27.Visible = True
                        Else
                            GRP_HSN.Visible = False
                            Label26.Visible = False
                            Label27.Visible = False

                        End If
                    End If

                End If
                '''        ------------------------------------------- SLP CESS  ------------------------------------------- 
                ''' 
                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 2 And AxfpSpread1.Lock = False Then
                AxfpSpread1.Col = 2
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemname()
                Else
                    CATCODE = Split(CMB_CATEGORY.Text, "--->")

                    SQL = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "'"
                    gconnection.getDataSet(SQL, "Invitem_VendorMaster")


                    SQL = " select I.itemcode,Itemname,uom,batchprocess, isnull(m.mrprate,0) as mrprate, isnull(m.prate,0) as prate from  CLOSINGQTY  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  "
                    If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                        If UCase(gShortname) = "NIZAM" Then
                            SQL = SQL & "  where  isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(itemname,'')='" + Trim(AxfpSpread1.Text) + "' and I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')"
                        Else
                            SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(itemname,'')='" + Trim(AxfpSpread1.Text) + "' and I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "')"
                        End If


                    Else
                        SQL = SQL & "  where M.Category='" + CATCODE(0) + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_Storecode.Text + "' and isnull(itemname,'')='" + Trim(AxfpSpread1.Text) + "'"

                    End If

                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then


                        If Val(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("prate")) <> 0 Then
                            prate = gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("prate")
                            AxfpSpread1.Col = 5
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = prate
                        Else
                            prate = 0
                        End If

                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then

                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))

                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            Dim sql1 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))

                                AxfpSpread1.Col = 18
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Col = 3
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            Next Z

                            If UCase(gShortname) <> "FNCC" Or UCase(gShortname) <> "HGA" Then
                                AxfpSpread1.Col = 1
                                SQL = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom,isnull(contractyn,'0') as contractyn FROM Invitem_VendorMaster WHERE VENDORCODE='" + txt_Suppliercode.Text + "' and ITEMCODE='" + Trim(AxfpSpread1.Text) + "'  AND cast('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE"
                                gconnection.getDataSet(SQL, "Invitem_VendorMaster")
                                If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                                    AxfpSpread1.Col = 3
                                    AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                                    AxfpSpread1.Col = 18
                                    AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    If prate = 0 Then
                                        AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("rate")
                                    End If

                                    If (Val(gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("contractyn")) = 1) Then
                                        AxfpSpread1.Lock = False
                                    Else
                                        AxfpSpread1.Lock = True
                                        If AxfpSpread1.Text = "0.00" Then
                                            AxfpSpread1.Lock = False
                                        Else
                                            AxfpSpread1.Lock = True
                                        End If
                                    End If
                                Else
                                    MessageBox.Show("Vendor Item link Expired . Plz update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                End If
                            End If




                            If CATCODE(0) = "LIQ" Or UCase(gShortname) = "NIZAM" Then
                                'SQL = "SELECT TOP 1   rate as rate  FROM LiqRate  WHERE ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and   cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY TRNS_SEQ  DESC"
                                If GSUPPLIER = "Y" Then
                                    SQL = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "' and Suppliercode='" + txt_Suppliercode.Text + "'  ORDER BY autoid  DESC"
                                Else
                                    SQL = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y' and  cast(convert(varchar(11),grndate,106)as datetime)<='" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'   ORDER BY autoid  DESC"
                                End If

                                gconnection.getDataSet(SQL, "RATE")
                                If (gdataset.Tables("RATE").Rows.Count > 0) Then

                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    If prate = 0 Then
                                        AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    End If
                                    AxfpSpread1.Lock = False
                                Else
                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    'AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    AxfpSpread1.Lock = False
                                End If
                            End If
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



                            If UCase(gShortname) <> "CCL" Then

                                If check_VendorType(txt_Suppliercode.Text) Then

                                    AxfpSpread1.Col = 10
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = ""

                                    AxfpSpread1.Col = 11
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = ""
                                    AxfpSpread1.Lock = True
                                Else
                                    SQL = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                                    SQL = SQL & " AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                                    gconnection.getDataSet(SQL, "Itemtaxtagging")
                                    If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then

                                        If (check_tAXtYPE(gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxcode"))) = False Then
                                            AxfpSpread1.Col = 10
                                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("TAXCODE")

                                            AxfpSpread1.Col = 11
                                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxper")
                                            AxfpSpread1.Lock = True
                                        End If

                                    Else
                                        MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                    End If
                                End If

                            End If
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                        End If
                    End If
                End If
                'QTY
                If UCase(gShortname) = "CCFC" Then
                    AxfpSpread1.Col = 1
                    If Trim(AxfpSpread1.Text) <> "" Then
                        SQL = "SELECT TOP 1   RATE as rate,UOM  FROM GRN_DETAILS WHERE ITEMCODE='" + Trim(AxfpSpread1.Text) + "' AND storecode='" + txt_Storecode.Text + "' ORDER BY AUTOID DESC"
                        gconnection.getDataSet(SQL, "RATE")
                        If (gdataset.Tables("RATE").Rows.Count > 0) Then

                            Label10.Text = Trim(AxfpSpread1.Text) & "   :   "

                            Label10.Text = Label10.Text & Trim(gdataset.Tables("RATE").Rows(0).Item("RATE")) + "/ " & Trim(gdataset.Tables("RATE").Rows(0).Item("UOM")) + " "

                        Else
                            Label10.Text = ""
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
                        AxfpSpread1.Col = 21
                        AxfpSpread1.Text = val
                    End If
                    Call UPdateHSNNO(item)

                    If Mid(UCase(gShortname), 1, 3) = "RGC" Then
                        Dim sqlstring As String
                        sqlstring = " select  isnull(hsnno,'') AS hsnno    FROM INV_INVENTORYITEMMASTER WHERE ITEMCODE='" & item & "' AND isnull(taxtype,'GST')='GST' and  isnull(hsnno,'')<>''"
                        gconnection.getDataSet(sqlstring, "INV")
                        If gdataset.Tables("INV").Rows.Count > 0 Then
                            Label26.Text = item
                            Label27.Text = Trim(gdataset.Tables("INV").Rows(0).Item("hsnno"))

                            GRP_HSN.Visible = True
                            Label26.Visible = True
                            Label27.Visible = True
                        Else
                            GRP_HSN.Visible = False
                            Label26.Visible = False
                            Label27.Visible = False
                            Label26.Text = ""
                            Label27.Text = ""


                        End If
                    End If

                End If
                '''        ------------------------------------------- SLP CESS  ------------------------------------------- 
                ''' 
                ''' 
                ''' 

            ElseIf AxfpSpread1.ActiveCol = 4 Then
                Dim ITEMCODE As String
                Dim gqty As Double
                AxfpSpread1.Col = 4
                If Trim(AxfpSpread1.Text) = "0.000" Or Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)

                Else
                    AxfpSpread1.Col = 1
                    ITEMCODE = AxfpSpread1.Text
                    SQL = "Select isnull(quantity,0) as quantity,isnull(receivedqty,0) as receivedqty,isnull(qtyrange,'') as qtyrange,isnull(po_hdr.potype,'') as potype  from po_itemdetails inner join po_hdr on po_hdr.pono=po_itemdetails.pono and po_hdr.versionno=po_itemdetails.versionno where po_hdr.pono='" + Txt_PONo.Text + "' and po_hdr.versionno='" + versionno + "'and itemcode='" + AxfpSpread1.Text + "'"
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
                                AxfpSpread1.Text = Val(qty)
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
                        AxfpSpread1.Col = 1
                        Dim icode As String = Trim(AxfpSpread1.Text)
                        If check_VendorTypeRU(txt_Suppliercode.Text, icode) Then
                            AxfpSpread1.Col = 13
                            AxfpSpread1.Lock = False
                            AxfpSpread1.SetActiveCell(13, AxfpSpread1.ActiveRow)

                        Else
                            CALCULATE()

                            AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                        End If


                    End If
                    If CmbGrnType.Text = "DIRECT GRN" Then
                        AxfpSpread1.Col = 4
                        check_MinMaxQTY("X", Trim(txt_Storecode.Text), ITEMCODE, Val(AxfpSpread1.Text))
                    End If


                End If
                'RATE
            ElseIf AxfpSpread1.ActiveCol = 5 Then
                AxfpSpread1.Col = 5
                If Val(AxfpSpread1.Text) = 0 Or Trim(AxfpSpread1.Text) = "" Or Val(AxfpSpread1.Text) <= 0 Then
                    'If UCase(gShortname) = "CCFC" Then
                    '    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                    '    AxfpSpread1.Col = 6

                    '    AxfpSpread1.Lock = False
                    'Else
                    '    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    'End If
                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.Col = 1
                    SQL = "Select isnull(rate,0) as rate,isnull(raterange,'') as raterange ,po_hdr.POTYPE from po_itemdetails INNER JOIN PO_HDR ON PO_HDR.pono=po_itemdetails.PONO AND "
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

                            If UCase(gShortname) = "CCFC" Then
                                AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                            Else
                                AxfpSpread1.SetActiveCell(7, AxfpSpread1.ActiveRow)
                            End If
                        End If

                    Else
                        CALCULATE()
                        If UCase(gShortname) = "CCFC" Then
                            AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(7, AxfpSpread1.ActiveRow)
                        End If


                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 6 Then
                AxfpSpread1.Col = 6
                If Trim(AxfpSpread1.Text) = "0.00" Or Trim(AxfpSpread1.Text) = "" Or Val(AxfpSpread1.Text) <= 0 Then

                    'Dim r, a, q As Double
                    'a = Val(AxfpSpread1.Text)
                    'AxfpSpread1.Col = 4
                    'q = Val(AxfpSpread1.Text)

                    'r = Format(a / q, "0.00")
                    'AxfpSpread1.Col = 5
                    'AxfpSpread1.Text = r

                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                Else
                    Dim r, a, q As Double
                    a = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 4
                    q = Val(AxfpSpread1.Text)

                    r = Format(a / q, "0.000")
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Text = r
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(7, AxfpSpread1.ActiveRow)
                End If
                'DISC%
                'ElseIf AxfpSpread1.ActiveCol = 7 And AxfpSpread1.Lock = False Then

            ElseIf AxfpSpread1.ActiveCol = 7 Then
                AxfpSpread1.Col = 7
                If Val(AxfpSpread1.Text) = 0 Or Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(8, AxfpSpread1.ActiveRow)
                Else
                    If Val(AxfpSpread1.Text) <= 100 Then
                        CALCULATE()
                        AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.Text = ""
                        AxfpSpread1.SetActiveCell(7, AxfpSpread1.ActiveRow)
                    End If


                End If
            ElseIf AxfpSpread1.ActiveCol = 8 Then
                AxfpSpread1.Col = 8
                If Val(AxfpSpread1.Text) = 0 Or Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.Col = 6
                    Dim a As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 8
                    If a >= Val(AxfpSpread1.Text) Then
                        AxfpSpread1.Col = 7
                        Dim b As Double = Val(AxfpSpread1.Text)
                        If Trim(AxfpSpread1.Text) = "" Or Val(AxfpSpread1.Text) = 0 Then
                            AxfpSpread1.Col = 8
                            Dim Discount As Double = Val(AxfpSpread1.Text)

                            AxfpSpread1.Col = 7
                            AxfpSpread1.Text = (Discount * 100) / (a)

                        End If
                        CALCULATE()
                        AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.Text = ""
                        AxfpSpread1.SetActiveCell(8, AxfpSpread1.ActiveRow)
                    End If


                End If



            ElseIf AxfpSpread1.ActiveCol = 10 Then
                AxfpSpread1.Col = 10

                If Trim(AxfpSpread1.Text) = "" Then
                    bindtaxcode()
                    AxfpSpread1.Col = 17
                    If AxfpSpread1.Lock = True Then
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    Else
                        AxfpSpread1.Col = 10
                        AxfpSpread1.Row = i
                        If Mid(Trim(AxfpSpread1.Text), 1, 2) = "NO" Then
                            AxfpSpread1.SetActiveCell(12, i)
                        Else
                            AxfpSpread1.SetActiveCell(17, i)
                        End If

                    End If
                    ' AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)

                    ' AxfpSpread1.SetActiveCell(1, i + 1)

                Else
                    If (check_tAXtYPE(Trim(AxfpSpread1.Text))) = False Then
                        If check_VendorType(txt_Suppliercode.Text) Then
                            SQL = "select taxper from invtaxgroupmaster where taxgroupcode='" + AxfpSpread1.Text + "'  and taxper='0' "
                        Else

                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Col = 10
                            SQL = "select taxper from invtaxgroupmaster where taxgroupcode='" + AxfpSpread1.Text + "' "
                        End If

                        Dim taxper As Double = gconnection.getvalue(SQL)

                        AxfpSpread1.Col = 11
                        AxfpSpread1.SetText(11, i, Val(taxper))
                        AxfpSpread1.Lock = True
                        CALCULATE()
                        AxfpSpread1.Row = i
                        AxfpSpread1.Col = 10

                        If Mid(Trim(AxfpSpread1.Text), 1, 2) = "NO" Then
                            AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.Col = 17
                            If AxfpSpread1.Lock = True Then
                                ' AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                'AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                            End If
                        End If
                    End If



                End If

                If CmbGrnType.Text = "DIRECT GRN" Then
                    AxfpSpread1.Col = 1
                    SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                    gconnection.getDataSet(SQL, "ITEM")
                    If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                        If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then

                            SQL = " select * from InvCompany_ItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                            gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                            If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then
                                If Val(gdataset.Tables("InvCompany_ItemMaster").Rows.Count) = 1 Then
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(1, i + 1)
                                Else
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(20, i)
                                End If
                            Else
                                AxfpSpread1.Col = 20
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(20, i)
                            End If
                        Else
                            AxfpSpread1.Col = 17
                            If AxfpSpread1.Lock = True Then
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.Col = 10

                                If Mid(Trim(AxfpSpread1.Text), 1, 2) = "NO" Then
                                    AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                                Else
                                    AxfpSpread1.Col = 17
                                    If AxfpSpread1.Lock = True Then
                                        AxfpSpread1.SetActiveCell(1, i + 1)
                                    Else
                                        AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                                    End If
                                End If
                                'AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                            End If
                        End If
                    Else
                        AxfpSpread1.Col = 17
                        If AxfpSpread1.Lock = True Then
                            AxfpSpread1.SetActiveCell(1, i + 1)
                        Else

                            AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                        End If
                    End If
                Else
                    AxfpSpread1.Col = 10

                    If Mid(Trim(AxfpSpread1.Text), 1, 2) = "NO" Then
                        AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.Col = 17
                        If AxfpSpread1.Lock = True Then
                            AxfpSpread1.SetActiveCell(1, i + 1)
                        Else
                            AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                        End If
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 12 Then

                Dim BA, TP, TA As Double
                AxfpSpread1.Col = 9
                BA = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 12
                TA = Val(AxfpSpread1.Text)
                ' TP = Math.Round((TA * 100) / BA)
                If TA = 0 Then
                    AxfpSpread1.SetText(11, i, "0.000")
                    AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                Else
                    TP = (TA * 100) / BA
                    AxfpSpread1.Col = 11
                    AxfpSpread1.SetText(11, i, TP)

                    'AxfpSpread1.SetActiveCell(1, i + 1)
                    CALCULATE()
                    AxfpSpread1.Col = 17
                    If Trim(AxfpSpread1.Text) = "" Then
                        AxfpSpread1.SetText(17, i, "0.000")

                        AxfpSpread1.SetActiveCell(1, i + 1)
                    Else
                        AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                        'AxfpSpread1.SetActiveCell(1, i + 1)

                    End If
                End If

                If CmbGrnType.Text = "DIRECT GRN" Then

                    AxfpSpread1.Col = 1
                    SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                    gconnection.getDataSet(SQL, "ITEM")
                    If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                        If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then

                            SQL = " select * from InvCompany_ItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                            gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                            If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then
                                If Val(gdataset.Tables("InvCompany_ItemMaster").Rows.Count) = 1 Then
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(1, i + 1)
                                Else
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(20, i)
                                End If
                            Else
                                AxfpSpread1.Col = 20
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(20, i)
                            End If
                        Else
                            AxfpSpread1.Col = 17
                            If Trim(AxfpSpread1.Text) = "" Then
                                AxfpSpread1.SetText(17, i, "0.000")
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                            End If
                        End If
                    Else
                        AxfpSpread1.Col = 17
                        If Trim(AxfpSpread1.Text) = "" Then
                            AxfpSpread1.SetText(17, i, "0.000")
                            AxfpSpread1.SetActiveCell(1, i + 1)
                        Else
                            AxfpSpread1.SetActiveCell(18, AxfpSpread1.ActiveRow)
                        End If
                    End If
                Else
                    AxfpSpread1.Col = 17
                    If Trim(AxfpSpread1.Text) = "" Then
                        AxfpSpread1.SetText(17, i, "0.000")
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    Else
                        AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 13 Then

                Dim RRate, RQTY, RbasicAmt, RTaxP, RTaxAmt, RAmt As Double

                If Val(AxfpSpread1.Text) = 0 Then
                    AxfpSpread1.SetActiveCell(5, i)
                Else
                    AxfpSpread1.Col = 13
                    RAmt = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 11
                    RTaxP = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 4
                    RQTY = Val(AxfpSpread1.Text)

                    '  RAmt = Val(AxfpSpread1.Text)

                    RbasicAmt = (RAmt) / (100 + RTaxP) * 100

                    RRate = RbasicAmt / RQTY

                    AxfpSpread1.SetText(5, i, Val(RRate))
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(17, AxfpSpread1.ActiveRow)
                End If

            ElseIf AxfpSpread1.ActiveCol = 17 Then
                Batchnocheck()
                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetText(17, i, "0.000")
                    If CmbGrnType.Text = "SPONSOR" Then
                        AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                    ElseIf exp_req = "YES" Then
                        AxfpSpread1.SetActiveCell(23, AxfpSpread1.ActiveRow)
                    ElseIf gShortname = "KSCA" Then
                        AxfpSpread1.SetActiveCell(25, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(1, i + 1)
                        '08-06-2023

                        'AxfpSpread1.Col = 22
                        'AxfpSpread1.Lock = True
                        'AxfpSpread1.Col = 23
                        'AxfpSpread1.Lock = True
                    End If
                Else
                    AxfpSpread1.SetActiveCell(18, AxfpSpread1.ActiveRow)
                End If

                If CmbGrnType.Text = "DIRECT GRN" Then

                    AxfpSpread1.Col = 1
                    SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                    gconnection.getDataSet(SQL, "ITEM")
                    If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                        If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then

                            SQL = " select * from InvCompany_ItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                            gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                            If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then
                                If Val(gdataset.Tables("InvCompany_ItemMaster").Rows.Count) = 1 Then
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(1, i + 1)
                                Else
                                    AxfpSpread1.Col = 20
                                    AxfpSpread1.ColHidden = False
                                    AxfpSpread1.SetActiveCell(20, i)
                                End If
                            Else
                                AxfpSpread1.Col = 20
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(20, i)
                            End If
                        Else
                            If CmbGrnType.Text = "SPONSOR" Then
                                AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                            ElseIf exp_req = "YES" Then
                                AxfpSpread1.SetActiveCell(23, AxfpSpread1.ActiveRow)
                            Else
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            End If
                        End If
                    Else
                        If CmbGrnType.Text = "SPONSOR" Then
                            AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(1, i + 1)
                        End If
                    End If
                Else
                    If CmbGrnType.Text = "SPONSOR" Then
                        AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 18 Then
                If CmbGrnType.Text = "SPONSOR" Then
                    AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                Else

                    AxfpSpread1.SetActiveCell(1, i + 1)

                End If
            ElseIf AxfpSpread1.ActiveCol = 16 Then
                CALCULATE()
                If CmbGrnType.Text = "SPONSOR" Then
                    AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.SetActiveCell(1, i + 1)
                End If
            ElseIf AxfpSpread1.ActiveCol = 19 Then
                If CmbGrnType.Text = "SPONSOR" Then
                    AxfpSpread1.Col = 19
                    If Trim(AxfpSpread1.Text) = "" Then
                        ' cmd_SPONhelp()
                        gSQLString = "SELECT ISNULL(SPONSORCODE,'') AS SPONSORCODE,ISNULL(SPONSORDESC,'') AS SPONSORDESC FROM INV_SPONSORMASTER"
                        M_WhereCondition = " where ISNULL(freeze,'N') <> 'Y'"
                        Dim vform As New ListOperattion1

                        vform.Field = "SPONSORDESC,SPONSORCODE"
                        vform.vFormatstring = "         SPONSOR CODE              |                  SPONSOR DESCRIPTION                                                                                              "
                        vform.vCaption = "SPONSOR MASTER HELP"
                        vform.KeyPos = 0
                        vform.KeyPos1 = 1
                        vform.ShowDialog(Me)
                        If Trim(vform.keyfield & "") <> "" Then

                            'AxfpSpread1.Text = Trim(vform.keyfield & "")
                            AxfpSpread1.SetText(19, i, Trim(vform.keyfield & ""))
                        End If
                        vform.Close()
                        vform = Nothing
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    Else
                        If Trim(AxfpSpread1.Text) <> "" Then
                            Dim sqlstring As String = "SELECT isnull(SPONSORcode,'') as SPONSORcode,isnull(SPONSORdesc,'') as SPONSORdesc,isnull(freeze,'') as freeze,isnull(adddate,'') as adddate FROM inv_SPONSORmaster WHERE SPONSORcode='" & Trim(AxfpSpread1.Text) & "' AND  ISNULL(freeze,'N') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "inv_SPONSORmaster")
                            If gdataset.Tables("inv_SPONSORmaster").Rows.Count > 0 Then
                                AxfpSpread1.Text = Trim(gdataset.Tables("inv_SPONSORmaster").Rows(0).Item("SPONSORcode"))
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)
                            End If

                        Else
                            AxfpSpread1.SetActiveCell(19, AxfpSpread1.ActiveRow)

                        End If
                    End If

                Else

                    AxfpSpread1.SetActiveCell(1, i + 1)

                End If


            ElseIf AxfpSpread1.ActiveCol = 20 Then
                AxfpSpread1.Col = 1
                SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(SQL, "ITEM")
                If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                    If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then
                        AxfpSpread1.Col = 17
                        If Trim(AxfpSpread1.Text) = "" Then
                            Dim vform As New ListOperattion1
                            gSQLString = "select distinct COMPANYCODE,COMPANYDESC from InvCompany_ItemMaster   "
                            AxfpSpread1.Col = 1
                            M_WhereCondition = " where ITEMCODE='" + AxfpSpread1.Text + "' and  isnull(freeze,'')<>'Y'"
                            vform.Field = " COMPANYCODE,COMPANYDESC "
                            vform.vFormatstring = "    COMPANY CODE    |      COMPANY DESC.        "
                            vform.vCaption = "COMPANY MASTER HELP"
                            vform.KeyPos = 0
                            vform.KeyPos1 = 1
                            vform.ShowDialog(Me)
                            If Trim(vform.keyfield & "") <> "" Then
                                AxfpSpread1.Col = 20
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = Trim(vform.keyfield)
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            End If
                        Else
                            Dim ITEM As String
                            AxfpSpread1.Col = 1
                            ITEM = AxfpSpread1.Text
                            AxfpSpread1.Col = 20
                            SQL = " select * from InvCompany_ItemMaster where COMPANYCODE='" + AxfpSpread1.Text + "' AND ITEMCODE='" + ITEM + "' "
                            gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                            If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then


                                AxfpSpread1.Col = 20
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.Col = 20
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = ""
                                AxfpSpread1.SetActiveCell(20, i)
                            End If

                        End If
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 21 Then
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) <> "" Then
                    Dim item As String = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 3
                    If Trim(AxfpSpread1.Text) <> "" Then
                        Dim val As Double = GetSPLCESS(item, Trim(AxfpSpread1.Text))
                        AxfpSpread1.Col = 4
                        Dim GQTY As Double = AxfpSpread1.Text
                        AxfpSpread1.Col = 21
                        AxfpSpread1.Text = (val * GQTY)
                        CALCULATE()
                    End If
                End If

            ElseIf AxfpSpread1.ActiveCol = 22 Then
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) <> "" Then
                    AxfpSpread1.Col = 22
                    If Trim(AxfpSpread1.Text) <> "" Then
                        Dim batch As String = Trim(AxfpSpread1.Text)
                        sqlstring = "SELECT isnull(EXPIRYDATE,'')as EXPIRYDATE ,isnull(Batch_no,'')as Batch_no FROM GRN_DETAILS WHERE BATCH_NO='" + batch + "'  GROUP BY EXPIRYDATE,Batch_no HAVING COUNT(BATCH_NO)>1"
                        gconnection.getDataSet(sqlstring, "BATCHCHECK")
                        If gdataset.Tables("BATCHCHECK").Rows.Count > 0 Then
                            MessageBox.Show("This Batch No. is already there you want to add this into same Batch No.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            AxfpSpread1.Col = 23
                            AxfpSpread1.Text = Format(CDate(gdataset.Tables("BATCHCHECK").Rows(0).Item("EXPIRYDATE")), "dd/MM/yy")
                            If GSHELVING = "Y" Then
                                AxfpSpread1.SetActiveCell(24, AxfpSpread1.ActiveRow)
                            Else
                                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                            End If
                        End If
                    End If
                    '   AxfpSpread1.ActiveCol = 22
                    If Trim(AxfpSpread1.Text) <> "" Then
                        AxfpSpread1.SetActiveCell(23, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(22, AxfpSpread1.ActiveRow)
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 23 Then
                If Trim(AxfpSpread1.Text) <> "" Then
                    expirycheck()
                    If GSHELVING = "Y" Then
                        AxfpSpread1.SetActiveCell(24, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    End If

                    '  AxfpSpread1.SetActiveCell(1, i + 1)
                Else
                    AxfpSpread1.SetActiveCell(23, AxfpSpread1.ActiveRow)
                End If
            ElseIf AxfpSpread1.ActiveCol = 24 Then
                If Trim(AxfpSpread1.Text) <> "" Then
                    AxfpSpread1.SetActiveCell(1, i + 1)
                Else
                    AxfpSpread1.SetActiveCell(24, AxfpSpread1.ActiveRow)
                End If
            ElseIf AxfpSpread1.ActiveCol = 25 Then
                If Trim(AxfpSpread1.Text) <> "" Then
                    AxfpSpread1.SetActiveCell(1, i + 1)
                Else
                    AxfpSpread1.SetActiveCell(25, AxfpSpread1.ActiveRow)
                End If

            Else
                If Mid(UCase(Cmd_Add.Text), 1, 1) = "A" And CmbGrnType.Enabled = True Then
                    GridUnLock()
                Else
                    If CmbGrnType.Text = "DIRECT GRN" Then
                        GridUnLock()
                    Else
                        Grid_lock()
                    End If

                End If

            End If



        ElseIf e.keyCode = Keys.F1 Then
            txt_Remarks.Focus()
        ElseIf e.keyCode = Keys.F3 Then
            If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then

                txt_RoundUP.Text = ""
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                CALCULATE()
            Else
                If gShortname <> "HIND" Then
                    i = AxfpSpread1.ActiveRow
                    AxfpSpread1.Row = i

                    SQL = "  select * from grn_details where itemcode='" + Trim(AxfpSpread1.Text) + "' and Grndetails='" + txt_Grnno.Text + "'"
                    gconnection.getDataSet(SQL, "grn")
                    If gdataset.Tables("grn").Rows.Count > 0 Then
                        MessageBox.Show("Please Select Y in Void column for Remove..", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Else
                        If AxfpSpread1.Lock = True Then
                            AxfpSpread1.Col = 1
                            If Trim(AxfpSpread1.Text) = "" Then
                                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                                CALCULATE()
                            End If
                        Else
                            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                            CALCULATE()
                        End If
                    End If
                Else
                    AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    CALCULATE()
                End If

            End If

        End If


    End Sub
    Private Sub Batchnocheck()
        If GBATCHNO = "Y" Then
            Dim ITEMCODE As String
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                ITEMCODE = AxfpSpread1.Text
                AxfpSpread1.Col = 22
                If AxfpSpread1.Text = "" Then
                    Dim sqlstring As String = "SELECT ISNULL(BATCHNO,'') AS BATCHNO,ISNULL(ExpiryDate,'') AS ExpiryDate FROM INV_InventoryItemMaster WHERE ITEMCODE='" & ITEMCODE & "' AND  ISNULL(VOID,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "BATCHREQ")
                    BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
                    exp_req = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("ExpiryDate"))
                End If
            Next
        End If
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
            AxfpSpread1.Col = 23
            expiry = AxfpSpread1.Text
            Dim sqlstring As String = "SELECT ISNULL(EXPIRYDATE,'') AS EXPIRYDATE FROM INV_InventoryItemMaster WHERE ITEMCODE='" & ITEMCODE & "' AND  ISNULL(VOID,'N') <> 'Y'"
            gconnection.getDataSet(sqlstring, "BATCHREQ")
            If gdataset.Tables("BATCHREQ").Rows.Count > 0 Then
                If expiry <= Today.Date Then
                    MessageBox.Show("Expiry date is less than today's date  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    AxfpSpread1.Col = 23
                    AxfpSpread1.Text = ""

                End If
            End If
        End If
    End Sub

    Private Sub bindtaxcode()
        Dim vform As New ListOperattion1


        gSQLString = "select i.taxgroupcode,sum(t.taxper) as Taxper,t.Effectfrom from  invtaxgroupmaster I INNER JOIN invtaxgroupmasterdetail T ON I.taxgroupcode=T.taxgroupcode  "

        M_WhereCondition = "  where isnull(i.void,'')<>'Y'  AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(t.Effectfrom AS DATE) AND  CAST(ISNULL(t.effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) "

        If check_VendorType(txt_Suppliercode.Text) Then
            M_Groupby = " GROUP BY i.taxgroupcode,t.Effectfrom   having sum(t.taxper)=0 "
        Else
            M_Groupby = " GROUP BY i.taxgroupcode,t.Effectfrom   "
        End If


        M_ORDERBY = "  taxper"
        vform.Field = " i.Taxgroupcode "
        vform.vFormatstring = "    Taxgroupcode    |      Taxper        "
        vform.vCaption = "Tax MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1


        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_tAXtYPE(Trim(vform.keyfield & ""))) = False Then
                AxfpSpread1.Col = 10
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.Col = 11
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield1)
                AxfpSpread1.Lock = True

                CALCULATE()
                If Mid(vform.keyfield, 1, 2) = "NO" Then
                    AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                End If
            End If

           

        End If

    End Sub
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()
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

    Private Function lock_Qty()
        Dim i, j As Integer
        For i = 1 To 100
            AxfpSpread1.Row = i
            For j = 1 To AxfpSpread1.MaxCols
                If weighall = 0 Then
                    If j = 4 Then
                        AxfpSpread1.Col = j
                        AxfpSpread1.Lock = True
                    End If
                Else
                    If j = 4 Then
                        AxfpSpread1.Col = j
                        AxfpSpread1.Lock = False
                    End If
                End If
              
            Next
        Next
    End Function
    Private Function Grid_lock()
        'Dim i, j As Integer
        'For i = 1 To 100
        '    AxfpSpread1.Row = i

        '    For j = 1 To AxfpSpread1.MaxCols
        '        If j = 4 Or j = 5 Or j = 7 Or j = 8 Or j = 12 Or j = 16 Or j = 17 Or j = 18 Or j = 10 Then
        '            If Mid(UCase(Trim(gShortname)), 1, 3) = "CCF" And j = 5 Then
        '                AxfpSpread1.Col = j
        '                AxfpSpread1.Lock = True
        '            End If
        '        Else
        '            If j = 1 Then
        '                If CmbGrnType.Text <> "PO" Then
        '                    AxfpSpread1.Col = j
        '                    AxfpSpread1.Lock = False
        '                End If
        '            Else
        '                AxfpSpread1.Col = j
        '                AxfpSpread1.Lock = True
        '            End If
        '        End If
        '    Next
        'Next
        'If gShortname = "KGA" Then
        '    AxfpSpread1.Col = 3
        '    AxfpSpread1.Lock = False
        'End If
      
    End Function

    Private Function lock_Frqty()
        Dim i, j As Integer
        For i = 1 To 100
            AxfpSpread1.Row = i
            For j = 1 To AxfpSpread1.MaxCols
                If j = 17 Or j = 18 Then
                    AxfpSpread1.Col = j
                    AxfpSpread1.Lock = True

                End If
            Next
        Next
    End Function



    Private Function lock_Batchno()
        'Dim i, j As Integer
        'For i = 1 To 100
        '    AxfpSpread1.Row = i
        '    For j = 1 To AxfpSpread1.MaxCols
        '        If j = 22 Then
        '            AxfpSpread1.Col = j
        '            AxfpSpread1.Lock = False
        '        End If
        '    Next
        'Next
    End Function
    Private Function lock_Expiry()
        'Dim i, j As Integer
        'For i = 1 To 100
        '    AxfpSpread1.Row = i
        '    For j = 1 To AxfpSpread1.MaxCols
        '        If j = 23 Then
        '            AxfpSpread1.Col = j
        '            AxfpSpread1.Lock = False
        '        End If
        '    Next
        'Next
    End Function


    Private Sub cmd_PONOhelp_Click(sender As Object, e As EventArgs) Handles cmd_PONOhelp.Click

        If CmbGrnType.Text = "DO" Then

            Dim CATEGORY As String

            gconnection.dataOperation(6, "update DI_DET set receivedqty=isnull((select sum(qty-isnull(RET_QTY,0)) as qty from Grn_details g where g.Itemcode=DI_DET.ITEMCODE and g.pono=DI_DET.DINO  and isnull(g.Voiditem,'N')<>'Y' ),0) ")
            gconnection.dataOperation(6, "    Update   DI_HDR set DISTATUS='RELEASED' where DINO  in   (select distinct DINO from DI_DET where isnull(QTY,0)<>isnull(receivedqty,0)) ")
            gconnection.dataOperation(6, "   Update   DI_HDR set DISTATUS='CLOSED' where DINO not in   (select distinct DINO from DI_DET where isnull(QTY,0)<>isnull(receivedqty,0))")


            CATCODE = Split(CMB_CATEGORY.Text, "--->")
            CATEGORY = Mid(CStr(CMB_CATEGORY.Text), 1, 3)
            clearoperation()


            gSQLString = " SELECT distinct ISNULL(DINO,'') AS DINO,ISNULL(DIDATE,'')AS DIDATE,ISNULL(STORE,'') AS STORE FROM ViewPendingDO  "
            M_WhereCondition = "  where STORE in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "')  "
            M_ORDERBY = " order by DIDATE DESC,DINO DESC"
            M_WhereCondition = ""
            Dim vform As New List_Operation
            vform.Field = "DINO,DIDATE,STORE"
            vform.vFormatstring1 = "         DINO                        |        DIDATE             |        STORE                                   "
            vform.vCaption = "DELIVERY MASTER HELP"
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

        Else

            Dim CATEGORY As String

            gconnection.dataOperation(6, "update PO_ITEMDETAILS set receivedqty=isnull((select sum(qty-isnull(RET_QTY,0)) as qty from Grn_details g where g.Itemcode=PO_ITEMDETAILS.ITEMCODE and g.pono=PO_ITEMDETAILS.pono  and isnull(g.Voiditem,'N')<>'Y' ),0)")
            gconnection.dataOperation(6, "     Update   po_hdr set postatus='RELEASED' where pono  in   (select distinct pono from po_itemdetails where isnull(Quantity,0)<>isnull(receivedqty,0))")
            gconnection.dataOperation(6, "    Update   po_hdr set postatus='CLOSED' where pono not in   (select distinct pono from po_itemdetails where isnull(Quantity,0)<>isnull(receivedqty,0))")

            CATCODE = Split(CMB_CATEGORY.Text, "--->")

            CATEGORY = Mid(CStr(CMB_CATEGORY.Text), 1, 3)



            clearoperation()

            gSQLString = "SELECT distinct ISNULL(pono,'') AS PONO,ISNULL(podate,'')AS PODATE,ISNULL(podepartment,'') AS PODEPARTMENT FROM ViewPendingPO "
            ' M_WhereCondition = " WHERE FREEZE <> 'Y' AND '" & Trim(CATEGORY) & "' = substring(pono,5,3) and postatus ='RELEASED' AND (GETDATE() BETWEEN POVALIDFROM AND POVALIDUPTO ) "
            M_WhereCondition = "  where substring (PONO,5,3) in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "')  "
            'M_WhereCondition = " WHERE FREEZE <> 'Y' AND  postatus ='RELEASED' AND (GETDATE() BETWEEN POVALIDFROM AND POVALIDUPTO and PONO  IN (SELECT a.PONO from PO_ITEMDETAILS a, Grn_details b where a.pono=b.pono and a.ITEMCODE<>b.Itemcode) ) "
            M_ORDERBY = " order by podate DESC,pono DESC"
            M_WhereCondition = ""

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
            If gShortname = "KGA" Then
                AxfpSpread1.Col = 3
                AxfpSpread1.Lock = False
            End If
            vform.Close()
            vform = Nothing
            M_ORDERBY = ""
            'txt_PONo.Focus()
            Cmd_Freeze.Enabled = True
        End If

    End Sub

    Private Function categorycode(ByVal categorydesc As String)
        Dim sqlquery, code As String
        sqlquery = "select CATEGORYDESC from INVENTORYCATEGORYMASTER where CATEGORYCODE='" & categorydesc & "'"

        gconnection.getDataSet(sqlquery, "inv")
        If gdataset.Tables("inv").Rows.Count > 0 Then
            code = Trim(gdataset.Tables("inv").Rows(0).Item("CATEGORYDESC"))
        Else

        End If
        Return code
    End Function
    Private Sub cmd_Grnnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Grnnohelp.Click

        Try
            Dim voidStatus As String

            Dim grnno() As String

            CATCODE = Split(CMB_CATEGORY.Text, "--->")

            '  CATCODE = Split(Trim(Mid(CMB_CATEGORY.Text, 1, 3)), "--->")
            If Trim(UCase(gShortname)) = "CGC" Then
                voidStatus = " and void ='N'"
            Else
                voidStatus = ""
            End If

            gSQLString = "SELECT Grndetails,Grndate,SUPPLIERNAME FROM Grn_header"

            If UCase(gShortname) = "KGA" Then
                CATCODE1 = Split(categorycode(CMB_CATEGORY.Text), "--->")
                M_WhereCondition = " Where Isnull(GRNTYPE,'')='GRN' " & voidStatus & "  AND ( (ISNULL(CAST(LEFT((PARSENAME(REPLACE(Grndetails,'GRN/'+storecode+'/',''),1)), 3) AS  varchar(20)) ,'')) LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%' OR ISNULL(CAST(LEFT((PARSENAME(REPLACE(Grndetails,'GRN/',''),1)), 3) AS  varchar(20)) ,'') LIKE '%" & Trim(Mid(CATCODE(1), 1, 3)) & "%' ) and storecode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "') "
            Else
                M_WhereCondition = " Where Isnull(GRNTYPE,'')='GRN' " & voidStatus & "  AND ISNULL(GRNDETAILS,'') LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%' and storecode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "') "
            End If

            If grp_Grngroup1.Visible = True Then
                If UCase(gShortname) = "HGA" Or UCase(gShortname) = "MBC" Or Mid(UCase(gShortname), 1, 3) = "FMC" Then
                    'M_WhereCondition = M_WhereCondition & "AND GRN_TYPE1='" + CmbGrnType.Text + "'"
                Else
                    M_WhereCondition = M_WhereCondition & "AND GRN_TYPE1='" + CmbGrnType.Text + "'"
                End If
            End If
            M_ORDERBY = "  order by Grndate  desc ,Autoid desc  "
            Dim vform As New List_Operation
            vform.Field = "GRNDETAILS,GRNDATE,SUPPLIERNAME"
            vform.vFormatstring1 = "       GRN NO                     |              GRN DATE             |                     SUPPLIERNAME                   "
            vform.vCaption = "GRN CUM PURCHASE BILL HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Grnno.Text = Trim(vform.keyfield & "")
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Call txt_Grnno_Validated(txt_Grnno.Text, e)
                Call Grid_lock()
            End If
            vform.Close()
            M_ORDERBY = ""
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_Grnnohelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_PONo_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_PONo.KeyDown

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
    Public Function CheckDBNull(ByVal obj As Object, Optional ByVal ObjectType As enumObjectType = enumObjectType.StrType) As Object
        Dim objReturn As Object
        objReturn = obj
        If ObjectType = enumObjectType.StrType And IsDBNull(obj) Then
            objReturn = ""
        ElseIf ObjectType = enumObjectType.IntType And IsDBNull(obj) Then
            objReturn = 0
        ElseIf ObjectType = enumObjectType.DblType And IsDBNull(obj) Then
            objReturn = 0.0
        End If
        Return objReturn
    End Function
    Enum enumObjectType
        StrType = 0
        IntType = 1
        DblType = 2
    End Enum

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

        If Trim(Me.Txt_PONo.Text) <> "" And CmbGrnType.Text = "PO" Then
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            If Val(Me.Txt_PONo.Text) > 0 Then
                Me.Txt_PONo.Text = doctype & "/" & Format(Val(Me.Txt_PONo.Text), "000000") & "/" & financalyear
            End If
            PoNumber = Trim(Me.Txt_PONo.Text)
        End If


        If Trim(Txt_PONo.Text) <> "" Then
            Dim x As Integer
            For x = 1 To 100
                AxfpSpread1.ClearRange(18, x, -1, -1, True)
            Next


            If CmbGrnType.Text = "DO" Then


                gconnection.dataOperation(6, "update DI_DET set receivedqty=isnull((select sum(qty-isnull(RET_QTY,0)) as qty from Grn_details g where g.Itemcode=DI_DET.ITEMCODE and g.pono=DI_DET.DINO  and isnull(g.Voiditem,'N')<>'Y' ),0) ")
                gconnection.dataOperation(6, "    Update   DI_HDR set DISTATUS='RELEASED' where DINO  in   (select distinct DINO from DI_DET where isnull(QTY,0)<>isnull(receivedqty,0)) ")
                gconnection.dataOperation(6, "   Update   DI_HDR set DISTATUS='CLOSED' where DINO not in   (select distinct DINO from DI_DET where isnull(QTY,0)<>isnull(receivedqty,0))")

                strsql = "SELECT * FROM DI_HDR WHERE DINO='" & Trim(Txt_PONo.Text) & "'"
                strsql = strsql & " AND FREEZE <> 'Y'  and isnull(DIstatus,'')='RELEASED'   and DINO IN (SELECT DINO FROM ViewPendingdo)"
                gconnection.getDataSet(strsql, "PO_HDR")
                If gdataset.Tables("PO_HDR").Rows.Count > 0 Then

                    overalldiscountpo = 0

                    txt_Suppliercode.Enabled = False
                    cmd_Suppliercodehelp.Enabled = False

                    CmbGrnType.Enabled = False
                    CMB_CATEGORY.Enabled = False

                    Txt_PONo.Text = CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DINO").ToString), enumObjectType.StrType)

                    txt_Storecode.Text = CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("STORE").ToString), enumObjectType.StrType)
                    
                   

                   

                    versionno = CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("AUTHDOCNO").ToString()), enumObjectType.StrType)
                    '    potype = CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("potype").ToString()), enumObjectType.StrType)
                    strsql = " SELECT * FROM STOREMASTER WHERE STOREcode = '" & CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("STORE").ToString()), enumObjectType.StrType) & "'"
                    gconnection.getDataSet(strsql, "STORECOD")
                    If gdataset.Tables("storecod").Rows.Count > 0 Then
                        txt_Storecode.Text = Trim(gdataset.Tables("storecod").Rows(0).Item("storecode"))
                        txt_StoreDesc.Text = Trim(gdataset.Tables("storecod").Rows(0).Item("storedesc"))
                    End If
                    ''txt_Supplierinvno.Text = CheckDBNull(gdataset.Tables("PO_HDR").Rows(0).Item("POquotno"), enumObjectType.StrType)
                    txt_Suppliercode.Text = CheckDBNull(gdataset.Tables("PO_HDR").Rows(0).Item("VENDORCODE"), enumObjectType.StrType)
                    '   Dim TOTDISC As Double = Val(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount"))
                    '  Dim OVDISC As Double = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC"))
                    ' txt_totdisc.Text = CheckDBNull(Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount").ToString), "0.000"), enumObjectType.IntType)
                    ' overalldiscountpo = CheckDBNull(Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC").ToString), "0.000"), enumObjectType.IntType)

                    'TXT_OVERALLdiscount.Text = CheckDBNull(Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC")), "0.000"), enumObjectType.IntType)
                    'TXT_OVERALLdiscount.Text = Val(overalldiscountpo)
                    '     txt_totdisc.Text = Format(Val(TOTDISC).ToString(), "0.000")
                    'txt_totaltax.Text = CheckDBNull(Format(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pototaltax").ToString)), enumObjectType.IntType)
                    'totpoqty = CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("totqty").ToString())), enumObjectType.IntType)
                    strsql = "SELECT ISNULL(VENDORCODE,0) AS VENDORCODE, ISNULL(VENDORNAME,'') AS VENDORNAME FROM PO_VIEW_VENDORMASTER WHERE VENDORCODE = '" & Trim(txt_Suppliercode.Text) & "' "
                    gconnection.getDataSet(strsql, "accountssubledgermaster")
                    txt_Suppliername.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("vendorname"))
                    Txt_PONo.ReadOnly = True

                    If gdataset.Tables("PO_HDR").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("PO_HDR").Rows(0).Item("AddDatetime")), "dd/MMM/yyyy")
                        ' Me.Cmd_Freeze.Text = "UnVoid[F8]"

                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Void[F8]"
                    End If
                    
                    strsql = " SELECT A.autoid,A.DINO,A.itemcode,a.itemname,A.uom,A.QTY  AS quantity, "
                    strsql = strsql & "   A.rate,AMOUNT AS  totalamount,AMOUNT AS baseamount, AMOUNT  AS  amountafterdiscount FROM DI_DET A  "
                    strsql = strsql & "    WHERE isnull(a.receivedqty,0)<a.QTY and  A.DINO='" & Trim(Txt_PONo.Text) & "'  and  ITEMCODE not in(select ITEMCODE from Grn_details where  "

                    strsql = strsql & " A.QTY<qty  and DINO='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')='N')  "
                    strsql = strsql & " GROUP BY A.autoid,A.DINO,A.itemcode,A.uom ,A.rate,AMOUNT "
                    strsql = strsql & " ,a.itemname,A.QTY      ORDER BY A.AUTOID "

                    gconnection.getDataSet(strsql, "PO_ITEMDETAILS")

                    Dim count, temp, tcode As String
                    For i = 0 To gdataset.Tables("PO_ITEMDETAILS").Rows.Count - 1
                        Dim message, title, defaultValue As String
                        Dim myValue As Object
                        message = "Enter Batch No"
                        title = "Batch No"
                        defaultValue = txt_Grnno.Text
                        Dim GRNQTY As Double = 0

                        tcode = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode")




                        If i = 0 Then
                            Dim SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE IN (select category from INV_InventoryItemMaster where itemcode in	('" & tcode & "'))"
                            gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                            If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                CMB_CATEGORY.Text = CheckDBNull(Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYCODE").ToString), enumObjectType.StrType) + "--->" + CheckDBNull(Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC").ToString), enumObjectType.StrType)
                            End If

                        End If

                        




                        strsql = "SELECT isnull(SUM(QTY),0) AS QTY"
                        strsql = strsql & " FROM Grn_details WHERE itemcode='" + tcode + "' and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')<>'Y'"
                        gconnection.getDataSet(strsql, "Grn_details")
                        If gdataset.Tables("Grn_details").Rows.Count > 0 Then
                            GRNQTY = Trim(gdataset.Tables("Grn_details").Rows(0).Item("QTY"))
                        End If

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
                            .Text = CheckDBNull(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemname").ToString(), enumObjectType.StrType)

                            .Col = 3
                            Dim sql222 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode") + "'"


                            gconnection.getDataSet(sql222, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                AxfpSpread1.Row = i + 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))

                                .Col = 18

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                .Col = 3


                            Next Z






                            .Text = CheckDBNull(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("uom"), enumObjectType.StrType)
                            .Col = 4
                            'If ((Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "FIXED RATE FIXED QUANTITY") Or (Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "OPEN RATE FIXED QUANTITY")) Then
                            '    AxfpSpread1.Lock = True
                            'Else
                            '    AxfpSpread1.Lock = False
                            'End If


                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("quantity") - GRNQTY

                            .Col = 5
                            ''If CheckDBNull(((Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype").ToString()) = "FIXED RATE FIXED QUANTITY") Or (Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype").ToString()) = "FIXED RATE OPEN QUANTITY")), enumObjectType.StrType) Then
                            ''    AxfpSpread1.Lock = True
                            ''Else
                            ''    AxfpSpread1.Lock = False
                            ''End If
                            .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("rate").ToString), "0.000"), enumObjectType.IntType)
                            .Col = 6
                            .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("baseamount").ToString()), "0.000"), enumObjectType.IntType)

                            .Col = 7
                            .Text = CheckDBNull(Format(Val(0), "0.000"), enumObjectType.IntType)


                            .Col = 8
                            .Text = CheckDBNull(Format(Val(0), "0.000"), enumObjectType.IntType)
                            .Col = 9
                            .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("baseamount").ToString()), "0.000"), enumObjectType.IntType)

                            

                            SQL = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + Trim(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode")) + "'"
                            SQL = SQL & " AND CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(dtp_Grndate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                            gconnection.getDataSet(SQL, "Itemtaxtagging")

                            'sql = "select taxperc,taxcode from Itemtaxtagging where itemcode='" + Trim(vform.keyfield) + "'"
                            'gconnection.getDataSet(sql, "Itemtaxtagging")
                            If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                                If (check_tAXtYPE(gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxcode"))) = False Then
                                    AxfpSpread1.Col = 10
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxcode")
                                    AxfpSpread1.Col = 11
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxper")
                                End If

                            Else
                                ' MessageBox.Show("No Tax Group found For Item  :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            End If


                            '.Col = 12
                            '.Text = CheckDBNull(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("VatAmt").ToString()), "0.000")
                            '.Col = 13
                            '.Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("totalamount").ToString), "0.000"), enumObjectType.IntType)
                            '.Col = 15
                            '.Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("othchg").ToString()), "0.000"), enumObjectType.IntType)
                            '.Col = 20
                            '.Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("COMPANYCODE")
                            '  .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("raterange")

                            '  .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("qtyrange")

                        End With
                    Next

                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    CALCULATE()
                    '    txt_totdisc.Text = Format(Val(Discnt), "0.000") ' + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount"))), "0.000")

                    '   TXT_OVERALLdiscount.Text = Format(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTOTALDISCOUNT"))), "0.000")
                    totAmt = CheckDBNull(Format(Val(txt_total.Text) - Val(txt_totdisc.Text) - Val(TXT_OVERALLdiscount.Text), "0.000"), enumObjectType.IntType)
                    ' txt_total.Text = Format(Val(totAmt), "0.000")
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
                    'otherchargepo = CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTRANSPORT").ToString())) + CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POCF").ToString())) + CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgplus").ToString())) - CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgmin").ToString())) + Val(OTHER_taxes), enumObjectType.IntType))))

                    'txt_Surchargeamt.Text = CheckDBNull(Format(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTRANSPORT").ToString())) + CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POCF").ToString())) + CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgplus").ToString())) - CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgmin").ToString())) + CheckDBNull(Val(OTHER_taxes).ToString(), "0.000"), enumObjectType.IntType)))))
                    'txt_Billamount.Text = CheckDBNull(Format((Val(txt_total.Text).ToString()) + CheckDBNull(Format((Val(txt_totaltax.Text).ToString()) - CheckDBNull(Format((Val(txt_totdisc.Text).ToString()) - CheckDBNull(Format((Val(gdataset.Tables("PO_HDR").Rows(0).Item("POoveralldisc").ToString()) + CheckDBNull(Format((Val(txt_Surchargeamt.Text).ToString()), "0.000")))))), enumObjectType.IntType)))))
                    'TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC")), "0.000")
                    'Discnt = 0 : totAmt = 0
                Else
                    MsgBox("DO CLOSED")
                End If








            Else

                gconnection.dataOperation(6, "update PO_ITEMDETAILS set receivedqty=isnull((select sum(qty-isnull(RET_QTY,0)) as qty from Grn_details g where g.Itemcode=PO_ITEMDETAILS.ITEMCODE and g.pono=PO_ITEMDETAILS.pono  and isnull(g.Voiditem,'N')<>'Y' ),0) where pono='" & Txt_PONo.Text & "'")
                gconnection.dataOperation(6, "     Update   po_hdr set postatus='RELEASED' where pono  in   (select distinct pono from po_itemdetails where isnull(Quantity,0)<>isnull(receivedqty,0)) and pono='" & Txt_PONo.Text & "'")
                gconnection.dataOperation(6, "    Update   po_hdr set postatus='CLOSED' where pono not in   (select distinct pono from po_itemdetails where isnull(Quantity,0)<>isnull(receivedqty,0)) and pono='" & Txt_PONo.Text & "'")


                strsql = "SELECT * FROM VwPendingPO_HDR WHERE pono='" & Trim(Txt_PONo.Text) & "'"
                If Mid(UCase(gShortname), 1, 3) = "HGA" Then

                    strsql = strsql & " AND FREEZE <> 'Y'  and isnull(postatus,'')='RELEASED'   and PONO IN (SELECT PONO FROM ViewPendingPO)"
                Else
                    strsql = strsql & " AND FREEZE <> 'Y'  and isnull(postatus,'')='RELEASED' and (cast(GETDATE() as Date) BETWEEN cast(ISNULL(POVALIDFROM,GETDATE()) as Date) AND cast(ISNULL(POVALIDUPTO,GETDATE()) as Date))  and PONO IN (SELECT PONO FROM ViewPendingPO)"
                End If



                gconnection.getDataSet(strsql, "PO_HDR")
                If gdataset.Tables("PO_HDR").Rows.Count > 0 Then
                    overalldiscountpo = 0

                    If gvendorlink = "Y" Then
                        txt_Suppliercode.Enabled = False
                        cmd_Suppliercodehelp.Enabled = False
                    End If
                    CmbGrnType.Enabled = False
                    CMB_CATEGORY.Enabled = False

                    'txt_Storecode.Enabled = False
                    'Cmd_Storecode.Enabled = False


                    Txt_PONo.Text = CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PONO").ToString), enumObjectType.StrType)
                    txt_Remarks.Text = CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POremarks").ToString), enumObjectType.StrType)
                    txt_Storecode.Text = CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODEPARTMENT").ToString), enumObjectType.StrType)
                    strsql = " SELECT * FROM STOREMASTER WHERE  STOREcode = '" & CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODEPARTMENT").ToString()), enumObjectType.StrType) & "'"
                    gconnection.getDataSet(strsql, "STORECOD")
                    If gdataset.Tables("storecod").Rows.Count > 0 Then
                        txt_StoreDesc.Text = Trim(gdataset.Tables("storecod").Rows(0).Item("storedesc"))
                    End If
                    'txt_StoreDesc.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODEPARTMENT"))

                    'Cbo_PODate.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODATE"))
                    '  CMB_CATEGORY.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DOCTYPE"))
                    Dim SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DOCTYPE").ToString), enumObjectType.StrType) + "'"
                    gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                    If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                        CMB_CATEGORY.Text = CheckDBNull(Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYCODE").ToString), enumObjectType.StrType) + "--->" + CheckDBNull(Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC").ToString), enumObjectType.StrType)
                    End If

                    If CMB_CATEGORY.Text = "" Then
                        'Cbo_PODate.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODATE"))
                        CMB_CATEGORY.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DOCTYPE"))
                    End If

                    versionno = CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno").ToString()), enumObjectType.StrType)
                    potype = CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("potype").ToString()), enumObjectType.StrType)
                    strsql = " SELECT * FROM STOREMASTER WHERE STOREDESC='" & txt_StoreDesc.Text & "'  OR STOREcode = '" & CheckDBNull(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("STORECODE").ToString()), enumObjectType.StrType) & "'"
                    gconnection.getDataSet(strsql, "STORECOD")
                    If gdataset.Tables("storecod").Rows.Count > 0 Then
                        txt_Storecode.Text = Trim(gdataset.Tables("storecod").Rows(0).Item("storecode"))
                        txt_StoreDesc.Text = Trim(gdataset.Tables("storecod").Rows(0).Item("storedesc"))
                    End If
                    txt_Supplierinvno.Text = CheckDBNull(gdataset.Tables("PO_HDR").Rows(0).Item("POquotno"), enumObjectType.StrType)
                    txt_Suppliercode.Text = CheckDBNull(gdataset.Tables("PO_HDR").Rows(0).Item("povendorcode"), enumObjectType.StrType)
                    '   Dim TOTDISC As Double = Val(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount"))
                    '  Dim OVDISC As Double = Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC"))
                    txt_totdisc.Text = CheckDBNull(Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount").ToString), "0.000"), enumObjectType.IntType)
                    overalldiscountpo = CheckDBNull(Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC").ToString), "0.000"), enumObjectType.IntType)

                    TXT_OVERALLdiscount.Text = CheckDBNull(Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC")), "0.000"), enumObjectType.IntType)
                    TXT_OVERALLdiscount.Text = Val(overalldiscountpo)
                    '     txt_totdisc.Text = Format(Val(TOTDISC).ToString(), "0.000")
                    txt_totaltax.Text = CheckDBNull(Format(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pototaltax").ToString)), enumObjectType.IntType)
                    totpoqty = CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("totqty").ToString())), enumObjectType.IntType)
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
                        strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity  AS quantity,"
                        strsql = strsql & " A.rate,A.discper, a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                        '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                        strsql = strsql & " DiscAmt,VatAmt,a.taxcode ,ISNULL(A.COMPANYCODE,'') AS COMPANYCODE  FROM VwPendingPO_itemdetails A"
                        '   strsql = strsql & " WHERE  a.receivedqty<a.Quantity and A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "'  and  ITEMCODE not in(select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')='N') GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                        strsql = strsql & " WHERE  a.receivedqty<a.Quantity and A.pono='" & Trim(Txt_PONo.Text) & "' and  ITEMCODE not in(select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')='N') GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                        strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                        strsql = strsql & ",DiscAmt,VatAmt,A.quantity,A.COMPANYCODE  "
                        strsql = strsql & " ORDER BY A.AUTOID "

                    ElseIf (potype = "RATE IN RANGE QUANTITY IN RANGE") Then

                        'strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity-ISNULL(SUM(ISNULL(B.QTY,0)),0) AS quantity,"
                        'strsql = strsql & "A.rate,A.discper, a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                        ''  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                        'strsql = strsql & "DiscAmt,VatAmt,a.taxcode  FROM PO_ITEMDETAILS A  LEFT OUTER  JOIN GRN_DETAILS B "
                        'strsql = strsql & "ON A.pono =B.POno AND A.itemcode =B.Itemcode AND A.uom =B.UOM  and a.versionno=b.versionno "
                        'strsql = strsql & "WHERE A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "' GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                        'strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                        'strsql = strsql & ",DiscAmt,VatAmt,A.quantity,A.QTYRANGE HAVING "
                        'strsql = strsql & "(A.quantity+A.QTYRANGE)-ISNULL(SUM(ISNULL(B.QTY,0)),0)>0 ORDER BY A.AUTOID "

                        strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity AS quantity,"
                        strsql = strsql & "A.rate,A.discper, A.VAT,a.taxper,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                        '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                        strsql = strsql & "DiscAmt,VatAmt,a.taxcode ,ISNULL(A.COMPANYCODE,'') AS COMPANYCODE  FROM VwPendingPO_itemdetails A inner JOIN GRN_DETAILS B "
                        strsql = strsql & "ON A.pono =B.POno and a.versionno=b.versionno "
                        '   strsql = strsql & "WHERE a.itemcode not in (select ITEMCODE from Grn_details where A.quantity<qty  and isnull(voiditem,'N')='N'  and pono='" & Trim(Txt_PONo.Text) & "') and  A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "' GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                        strsql = strsql & "WHERE a.itemcode not in (select ITEMCODE from Grn_details where A.quantity<qty  and isnull(voiditem,'N')='N'  and pono='" & Trim(Txt_PONo.Text) & "') and  A.pono='" & Trim(Txt_PONo.Text) & "' GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                        strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                        strsql = strsql & ",DiscAmt,A.VAT,VatAmt,A.quantity,A.COMPANYCODE    "
                        strsql = strsql & " ORDER BY A.AUTOID "

                    ElseIf UCase(gShortname) = "RSAOI" Then
                        strsql = "       SELECT A.autoid,A.pono,A.itemcode,i.itemname,A.uom,A.quantity  AS quantity,"
                        strsql = strsql & " A.rate,A.discper, a.taxper,A.TAXCODE,A.VAT,A.VATAMT,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                        '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                        strsql = strsql & " DiscAmt,VatAmt,a.taxcode ,ISNULL(A.COMPANYCODE,'') AS COMPANYCODE FROM PO_ITEMDETAILS A,INV_InventoryItemMaster i"
                        '   strsql = strsql & " WHERE a.receivedqty<a.Quantity and  A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "'  and  ITEMCODE not in(select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')='N') GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxper,totalamount,A.baseamount"
                        strsql = strsql & " where  isnull(a.receivedqty,0)<a.Quantity and  A.pono='" & Trim(Txt_PONo.Text) & "'  and  A.ITEMCODE not in(select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')='N')  and i.itemcode=a.itemcode  GROUP BY A.autoid,A.pono,A.itemcode,A.uom,A.rate,A.discper, a.taxper,A.TAXCODE,A.VAT,A.VATAMT,totalamount,A.baseamount"
                        strsql = strsql & " ,a.taxcode,i.itemname,A.amountafterdiscount,A.othchg "
                        strsql = strsql & ",DiscAmt,VatAmt,A.quantity ,A.COMPANYCODE  "
                        strsql = strsql & " ORDER BY A.AUTOID "

                    Else


                        strsql = "       SELECT A.autoid,A.pono,A.itemcode,a.itemname,A.uom,A.quantity  AS quantity,"
                        strsql = strsql & " A.rate,A.discper, a.taxper,A.TAXCODE,A.VAT,A.VATAMT,totalamount,A.baseamount,A.amountafterdiscount,A.othchg,"
                        '  strsql = strsql & ",itemrec_tilldate,value_tilldate "
                        strsql = strsql & " DiscAmt,VatAmt,a.taxcode ,ISNULL(A.COMPANYCODE,'') AS COMPANYCODE FROM VwPendingPO_itemdetails A"
                        '   strsql = strsql & " WHERE a.receivedqty<a.Quantity and  A.pono='" & Trim(Txt_PONo.Text) & "' AND A.VERSIONNO='" + Trim(gdataset.Tables("PO_HDR").Rows(0).Item("versionno")) + "'  and  ITEMCODE not in(select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')='N') GROUP BY A.autoid,A.pono,A.itemcode,A.uom ,A.rate,A.discper, a.taxpepo_r,totalamount,A.baseamount"
                        strsql = strsql & " where  isnull(a.receivedqty,0)<a.Quantity and  A.pono='" & Trim(Txt_PONo.Text) & "'  and  A.ITEMCODE not in(select ITEMCODE from Grn_details where A.quantity<qty  and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')='N') GROUP BY A.autoid,A.pono,A.itemcode,A.uom,A.rate,A.discper, a.taxper,A.TAXCODE,A.VAT,A.VATAMT,totalamount,A.baseamount"
                        strsql = strsql & " ,a.taxcode,a.itemname,A.amountafterdiscount,A.othchg "
                        strsql = strsql & ",DiscAmt,VatAmt,A.quantity ,A.COMPANYCODE  "
                        strsql = strsql & " ORDER BY A.AUTOID "
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
                            Dim GRNQTY As Double = 0

                            tcode = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode")


                            strsql = "SELECT isnull(SUM(QTY),0) AS QTY"
                            strsql = strsql & " FROM Grn_details WHERE itemcode='" + tcode + "' and pono='" & Trim(Txt_PONo.Text) & "' and isnull(voiditem,'N')<>'Y'"
                            gconnection.getDataSet(strsql, "Grn_details")
                            If gdataset.Tables("Grn_details").Rows.Count > 0 Then
                                GRNQTY = Trim(gdataset.Tables("Grn_details").Rows(0).Item("QTY"))
                            End If

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
                                .Text = CheckDBNull(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemname").ToString(), enumObjectType.StrType)

                                .Col = 3
                                AxfpSpread1.Lock = False
                                Dim sql222 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("itemcode") + "'"


                                gconnection.getDataSet(sql222, "INVITEM_TRANSUOM_LINK")
                                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                    AxfpSpread1.Row = i + 1

                                    AxfpSpread1.TypeComboBoxString = UCase(Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom")))
                                    AxfpSpread1.Text = UCase(Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom")))

                                    .Col = 18

                                    AxfpSpread1.TypeComboBoxString = UCase(Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom")))
                                    AxfpSpread1.Text = UCase(Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom")))
                                    .Col = 3


                                Next Z

                                If gShortname <> "KGA" Then
                                    .Text = CheckDBNull(UCase(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("uom")), enumObjectType.StrType)
                                End If
                                .Col = 4
                                'If ((Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "FIXED RATE FIXED QUANTITY") Or (Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype")) = "OPEN RATE FIXED QUANTITY")) Then
                                '    AxfpSpread1.Lock = True
                                'Else
                                '    AxfpSpread1.Lock = False
                                'End If


                                .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("quantity") - GRNQTY

                                .Col = 5
                                If CheckDBNull(((Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype").ToString()) = "FIXED RATE FIXED QUANTITY") Or (Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POtype").ToString()) = "FIXED RATE OPEN QUANTITY")), enumObjectType.StrType) Then
                                    AxfpSpread1.Lock = True
                                Else
                                    AxfpSpread1.Lock = False
                                End If
                                .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("rate").ToString), "0.000"), enumObjectType.IntType)
                                .Col = 6
                                .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("baseamount").ToString()), "0.000"), enumObjectType.IntType)

                                .Col = 7
                                .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("discper").ToString()), "0.000"), enumObjectType.IntType)


                                .Col = 8
                                .Text = CheckDBNull(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("DiscAmt").ToString, "0.000"), enumObjectType.IntType)
                                .Col = 9
                                .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("amountafterdiscount").ToString), "0.000"), enumObjectType.IntType)
                                .Col = 10
                                .Text = CheckDBNull(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("taxcode").ToString(), enumObjectType.StrType)

                                .Col = 11
                                If UCase(gcompname) = "HGA" Or UCase(gcompname) = "KGA" Then

                                    .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("VAT").ToString), "0.00"), enumObjectType.IntType)
                                Else

                                    .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("taxper").ToString), "0.00"), enumObjectType.IntType)
                                End If
                                .Col = 12
                                .Text = CheckDBNull(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("VatAmt").ToString()), "0.000")
                                .Col = 13
                                .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("totalamount").ToString), "0.000"), enumObjectType.IntType)
                                .Col = 15
                                .Text = CheckDBNull(Format(Val(gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("othchg").ToString()), "0.000"), enumObjectType.IntType)
                                .Col = 20
                                .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("COMPANYCODE")
                                '  .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("raterange")

                                '  .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(i).Item("qtyrange")

                            End With
                        Next
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                        CALCULATE()
                        '    txt_totdisc.Text = Format(Val(Discnt), "0.000") ' + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pototaldiscount"))), "0.000")

                        '   TXT_OVERALLdiscount.Text = Format(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTOTALDISCOUNT"))), "0.000")
                        totAmt = CheckDBNull(Format(Val(txt_total.Text) - Val(txt_totdisc.Text) - Val(TXT_OVERALLdiscount.Text), "0.000"), enumObjectType.IntType)
                        ' txt_total.Text = Format(Val(totAmt), "0.000")
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
                        'otherchargepo = CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTRANSPORT").ToString())) + CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POCF").ToString())) + CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgplus").ToString())) - CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgmin").ToString())) + Val(OTHER_taxes), enumObjectType.IntType))))

                        txt_Surchargeamt.Text = CheckDBNull(Format(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POTRANSPORT").ToString())) + CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POCF").ToString())) + CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgplus").ToString())) - CheckDBNull(Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgmin").ToString())) + CheckDBNull(Val(OTHER_taxes).ToString(), "0.000"), enumObjectType.IntType)))))
                        txt_Billamount.Text = CheckDBNull(Format((Val(txt_total.Text).ToString()) + CheckDBNull(Format((Val(txt_totaltax.Text).ToString()) - CheckDBNull(Format((Val(txt_totdisc.Text).ToString()) - CheckDBNull(Format((Val(gdataset.Tables("PO_HDR").Rows(0).Item("POoveralldisc").ToString()) + CheckDBNull(Format((Val(txt_Surchargeamt.Text).ToString()), "0.000")))))), enumObjectType.IntType)))))
                        TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC")), "0.000")
                        Discnt = 0 : totAmt = 0
                    Else
                        MsgBox("PO CLOSED")
                    End If

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
        Dim docdetails As String
       
        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
        Call CALCULATE()

        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            'Call autogenerate()
            Array.Clear(GrnQuery, 0, GrnQuery.Length)
            If validateoninsert() = False Then
                addoperation()

                Call UpdateTransportationCharges(Trim(txt_Grnno.Text))

                If check = False Then
                    Exit Sub
                End If

                If GrnQuery.Length > 0 Then

                    Dim dtitem As New DataTable
                    dtitem.Columns.Add("itemcode")
                    dtitem.TableName = "TpItems"


                    If (gconnection.MoreTrans2(GrnQuery)) Then

                        Call UpdateGST("GRN", Trim(txt_Grnno.Text), Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy"))

                        Dim ITEMCODE As String
                        Dim I As Integer
                        Dim items As String
                        items = ""
                        For I = 0 To AxfpSpread1.DataRowCnt
                            AxfpSpread1.Row = I
                            AxfpSpread1.Col = 1
                            ITEMCODE = Trim(AxfpSpread1.Text)
                            items = items & "'" & Trim(ITEMCODE) & "',"
                            dtitem.Rows.Add(ITEMCODE)
                        Next

                        items = Mid(items, 1, Len(items) - 1)
                        Call Randomize()
                        vOutfile = Mid("WEI" & (Rnd() * 800000000), 1, 10)
                        vOutfile = Replace(vOutfile, ".", "")
                        vOutfile = Replace(vOutfile, "+", "")

                        Dim loccode As String
                        sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_Storecode.Text) & "'"
                        gconnection.getDataSet(sqlstring, "loccode")
                        If gdataset.Tables("loccode").Rows.Count > 0 Then
                            loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                        Else
                            loccode = "M"
                        End If
                        If Mid(UCase(gShortname), 1, 5) = "RSAOI" Or Mid(UCase(gShortname), 1, 3) = "CTC" Then
                            Try
                                Dim strrate As String
                                strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, txt_Grnno.Text, "GRN")

                            Catch ex As Exception
                                MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                Call cancelAdd()
                                Exit Sub
                            End Try
                        Else
                            Try
                                Dim strrate As String
                                strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, txt_Grnno.Text, "GRN")
                                sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                                gconnection.ExcuteStoreProcedure(sqlstring)
                            Catch ex As Exception
                                MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                Call cancelAdd()
                                Exit Sub
                            End Try
                        End If

                        sqlstring = " exec proc_closingqtyone 'GRN_ADD' "
                        gconnection.ExcuteStoreProcedure(sqlstring)


                        '==============================================
                        Array.Clear(GrnQuery, 0, GrnQuery.Length)
                            '=============================================
                            For I = 1 To AxfpSpread1.DataRowCnt
                                AxfpSpread1.Row = I
                                AxfpSpread1.Col = 1
                                Dim fqqty As Double
                                Dim qty1 As Double
                                Dim itemcode1 As String
                                AxfpSpread1.Col = 1
                                itemcode1 = AxfpSpread1.Text

                                AxfpSpread1.Col = 4
                                qty1 = Format(Val(AxfpSpread1.Text), "0.000")
                                'updation in po_itemdetails
                                If Trim(CmbGrnType.SelectedItem) = "PO" And grp_Grngroup1.Visible = True Then
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
                                                sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                                            Else
                                                AxfpSpread1.Col = 1

                                                sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + ",qtystatus='RECEIVED' where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

                                            End If
                                        ElseIf (gdataset.Tables("po_itemdetails").Rows(0).Item("potype") = "RATE IN RANGE QUANTITY IN RANGE") Then
                                            If ((quantity - qtyrange) < (receivedqty + qty1) Or (receivedqty + qty1) > (quantity + qtyrange)) Then
                                                If (MessageBox.Show("Do You want to Close PO for:" + itemcode1, "Purchase Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
                                                    GoTo l
                                                End If

                                                AxfpSpread1.Col = 1
                                                sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                                            ElseIf (qty1 < receivedqty + quantity) Then
                                                AxfpSpread1.Col = 1
                                                sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

                                            ElseIf (quantity + qtyrange = receivedqty + qty1) Or (receivedqty + qty1 = quantity - qtyrange) Then
                                                AxfpSpread1.Col = 1
l:
                                                sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + ",qtystatus='RECEIVED' where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                                            Else
                                                MessageBox.Show("Quantity Can't be greater than PO Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                            End If
                                        Else
                                            AxfpSpread1.Col = 1
                                            sqlstring = "update po_itemdetails set receivedqty=" + Format(Val(receivedqty + qty1), "0.000") + " where  itemcode='" + AxfpSpread1.Text + "' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"

                                        End If
                                        ReDim Preserve GrnQuery(GrnQuery.Length)
                                        GrnQuery(GrnQuery.Length - 1) = sqlstring
                                    End If
                                End If
                                'END PO 
                            Next

                            If (gconnection.MoreTrans2(GrnQuery)) Then
                                If Trim(CmbGrnType.SelectedItem) = "PO" And grp_Grngroup1.Visible = True And Trim(UCase(gShortname)) = "CCL" Then
                                    Dim SQL As String = "select count(*) as a from  po_itemdetails where ISNULL(qtystatus,'') <> 'RECEIVED' and pono='" + Txt_PONo.Text + "' and versionno='" + versionno + "'"
                                    gconnection.getDataSet(SQL, "po_itemdetails")
                                    If gdataset.Tables("po_itemdetails").Rows.Count > 0 Then
                                        If Val(gdataset.Tables("po_itemdetails").Rows(0).Item("a").ToString()) > 0 Then

                                        Else
                                            sqlstring = "update po_hdr set postatus='CLOSED' where   pono='" + Txt_PONo.Text + "' AND POTYPE NOT IN ('FIXED RATE OPEN QUANTITY' ,'OPEN RATE OPEN QUANTITY') AND VERSIONNO='" + versionno + "'"
                                            gconnection.dataOperation(6, sqlstring, )
                                        End If
                                    End If
                                End If
                            End If
                            ' Added by Sri for batch
                            If GBATCHNO = "Y" Then
                                Dim strsql As String
                                strsql = "insert into inv_Batchdetails(trnno,itemcode,uom,storecode,trndate,QTY,ttype,batchno,EXPIRYDATE,RATE)"
                                strsql = strsql & " SELECT grndetails,Itemcode,uom,storecode,Grndate,qty,'GRN',Batch_no,ExpiryDate,RATE from grn_details WHERE Grndetails= '" & txt_Grnno.Text & "'"
                                gconnection.dataOperation(6, strsql, )
                            End If
                            ' end 
                            MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            '==============================================
                            If UCase(gShortname) = "OUT" Or Mid(UCase(gShortname), 1, 3) = "FMC" Then
                                Call NewAccountPosting_OUTR("GRN", Trim(txt_Grnno.Text))

                            End If
                        If gShortname <> "RSAOI" And gShortname <> "CSC" Then
                            Call UpdateProfitItems()
                        End If
                        If UCase(gShortname) <> "SATC" Then
                                If MsgBox("DO you want to View ?", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "View Report") = MsgBoxResult.Ok Then
                                    Call Cmd_View_Click(Cmd_View, e)
                                End If
                            End If


                            If (gdirissue = "Y") Then

                                sqlstring = "SELECT DISTINCT DOCDETAILS FROM STOCKISSUEDETAIL WHERE batchno='" & Trim(txt_Grnno.Text) & "' AND ISNULL(void,'N')<>'Y' "
                                gconnection.getDataSet(sqlstring, "ISSUEPOST")

                                If gdataset.Tables("ISSUEPOST").Rows.Count > 0 Then
                                    For I = 0 To gdataset.Tables("ISSUEPOST").Rows.Count - 1
                                        NewAccountPosting(gdataset.Tables("ISSUEPOST").Rows(I).Item("DOCDETAILS"), "ISSUE")
                                    Next

                                End If

                            End If



                            clearoperation()
                        Else
                            'MsgBox("Transaction failed , Plz try again.. ")
                            Cmd_Add.Enabled = True
                        MessageBox.Show("Transaction  failed , Plz try again..", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                Cmd_Add.Enabled = True
            End If

        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then

            If validateonupdate() = False Then
                '==============================================
                Array.Clear(GrnQuery, 0, GrnQuery.Length)
                '=============================================

                UpdateOperation()
                Call UpdateTransportationCharges(Trim(txt_Grnno.Text))
                If check = False Then
                    Exit Sub
                End If
                Dim dtitem As New DataTable
                dtitem.Columns.Add("itemcode")
                dtitem.TableName = "TpItems"

                If GrnQuery.Length > 0 Then
                    If (gconnection.MoreTrans2(GrnQuery)) Then

                        Call UpdateGST("GRN", Trim(txt_Grnno.Text), Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy"))

                        Dim ITEMCODE As String
                        Dim I As Integer
                        Dim items As String
                        items = ""
                        For I = 0 To AxfpSpread1.DataRowCnt
                            AxfpSpread1.Row = I
                            AxfpSpread1.Col = 1
                            ITEMCODE = Trim(AxfpSpread1.Text)
                            items = items & "'" & Trim(ITEMCODE) & "',"
                            dtitem.Rows.Add(ITEMCODE)
                        Next
                        items = Mid(items, 1, Len(items) - 1)
                        Call Randomize()
                        vOutfile = Mid("WEI" & (Rnd() * 800000000), 1, 10)
                        vOutfile = Replace(vOutfile, ".", "")
                        vOutfile = Replace(vOutfile, "+", "")

                        Dim loccode As String
                        sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(txt_Storecode.Text) & "'"
                        gconnection.getDataSet(sqlstring, "loccode")
                        If gdataset.Tables("loccode").Rows.Count > 0 Then
                            loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                        Else
                            loccode = "M"
                        End If

                        If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                            Try
                                Dim strrate As String
                                strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, txt_Grnno.Text, "GRN")

                            Catch ex As Exception
                                MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                Dim STRRATE As String
                                STRRATE = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, txt_Grnno.Text, "GRN")
                            End Try
                        Else
                            Try
                                Dim strrate As String
                                strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, txt_Grnno.Text, "GRN")
                                sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                                gconnection.ExcuteStoreProcedure(sqlstring)
                            Catch ex As Exception
                                MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                Dim STRRATE As String
                                STRRATE = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, txt_Grnno.Text, "GRN")
                            End Try
                        End If


                        sqlstring = " exec proc_closingqtyone 'GRN_UPDATE' "
                        gconnection.ExcuteStoreProcedure(sqlstring)



                        ' Added by Sri for Batch
                        If GBATCHNO = "Y" Then
                            Dim strsql As String
                            strsql = "delete from inv_Batchdetails where trnno='" & txt_Grnno.Text & "' "
                            gconnection.dataOperation(6, strsql, )
                            strsql = "insert into inv_Batchdetails(trnno,itemcode,uom,storecode,trndate,QTY,ttype,batchno,EXPIRYDATE,RATE)"
                            strsql = strsql & " SELECT grndetails,Itemcode,uom,storecode,Grndate,qty,'GRN',Batch_no,ExpiryDate,RATE from grn_details WHERE Grndetails= '" & txt_Grnno.Text & "'"
                            gconnection.dataOperation(6, strsql, )
                        End If
                        ' end

                        MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)




                        If UCase(gShortname) = "OUT" Or UCase(gShortname) = "FMC" Then
                            sqlstring = "DELETE  from JOURNALENTRY  where VoucherNo='" + Trim(txt_Grnno.Text) + "'"
                            gconnection.getDataSet(sqlstring, "journalentry")
                            Call NewAccountPosting_OUTR("GRN", Trim(txt_Grnno.Text))
                        End If



                        If gShortname <> "RSAOI" And gShortname <> "CSC" Then
                            Call UpdateProfitItems()
                        End If


                        If UCase(gShortname) <> "SATC" Then
                            If MsgBox("DO you want to View ?", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "View Report") = MsgBoxResult.Ok Then
                                Call Cmd_View_Click(Cmd_View, e)
                            End If
                        End If
                        Call clearoperation()
                    End If
                End If
            End If

        End If

    End Sub

    Private Sub txt_Grnno_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Grnno.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            dtp_Grndate.Focus()
        End If
    End Sub

    Private Sub UpdateProfitItems()
        'sqlstring = " UPDATE ratemaster SET EndingDate = DATEADD(day,-1,'" + Format(dtp_Grndate.Value, "dd-MMM-yyyy") + "') WHERE AUTOID IN ( SELECT AUTOID FROM ratemaster where AUTOID IN (SELECT MAX(AUTOID) FROM ratemaster WHERE ItemCode IN  "
        'sqlstring = sqlstring & " (SELECT distinct BITEM FROM VW_INV_RATEMASTER I WHERE Grndetails='" + txt_Grnno.Text + "'  ) GROUP BY  ItemCode,rposcode )) "
        'gconnection.ExcuteStoreProcedure(sqlstring)
        sqlstring = " UPDATE ratemaster SET EndingDate = DATEADD(day,-1,'" + Format(dtp_Grndate.Value, "dd-MMM-yyyy") + "') WHERE AUTOID IN ( SELECT AUTOID FROM ratemaster  WHERE ItemCode IN  "
        sqlstring = sqlstring & " (SELECT distinct BITEM FROM VW_INV_RATEMASTER I WHERE Grndetails='" + txt_Grnno.Text + "'  ) and EndingDate is null  GROUP BY AUTOID ,ItemCode,rposcode ) "
        gconnection.ExcuteStoreProcedure(sqlstring)


        sqlstring = " INSERT INTO RATEMASTER ( WithEffectFrom,ItemCode,ItemCodeseqno,UOM,ItemRate,purcahseRate,StartingDate,EndingDate,Freeze,AddUserId,AddDateTime, ITEMNAME,RGrndetails,rposcode)"
        sqlstring = sqlstring & " SELECT grndate,bitem,ItemCodeseqno,BUOM2,RATE,PURRATE,grndate,NULL,'N','" + gUsername + "',GETDATE(),BITEMNAME,Grndetails,Pos FROM VW_INV_RATEMASTER WHERE Grndetails='" + txt_Grnno.Text + "'  "
        gconnection.ExcuteStoreProcedure(sqlstring)

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
                sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,"
                If gShortname = "CPC" Then
                    sqlstring = sqlstring & "ISNULL(ERSALETAX,0) AS ERSALETAX,ISNULL(ERTAX,0) AS ERTAX,"
                End If
                sqlstring = sqlstring & " ISNULL(BILLAMOUNT, 0) As BILLAMOUNT,ISNULL(REMARKS,'') AS REMARKS,"
                sqlstring = sqlstring & " ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,ISNULL(voiddate,'') AS voiddate,"
                sqlstring = sqlstring & " ISNULL(STORECODE,'') STORECODE , ISNULL(STOREDESC,'MAINSTORE') STOREDESC, ISNULL(OVERALLDISCOUNT,0) OVERALLDISCOUNT,isnull(RET_STATUS,'N') as RET_STATUS,isnull(GRN_TYPE1,'Direct GRN') as GRN_TYPE1,isnull(RoundupAmt,0) as RoundupAmt ,ISNULL(TotGSTAmt,0) AS TotGSTAmt,ISNULL(TotSGSTAmt,0) AS TotSGSTAmt,ISNULL(TotCGSTAmt,0) AS TotCGSTAmt,ISNULL(TotIGSTAmt,0) AS TotIGSTAmt,isnull(glacccode,'')as glacccode,isnull(glaccdesc,'')as glaccdesc,ISNULL(SLCODE,'')AS SLCODE,ISNULL(SLDESC,'')AS SLDESC FROM GRN_HEADER"
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
                    clearoperation()
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Grnno.ReadOnly = True
                    If gvendorlink = "Y" Then
                        txt_Suppliercode.Enabled = False
                        cmd_Suppliercodehelp.Enabled = False
                    End If
                    CmbGrnType.Enabled = False
                    CMB_CATEGORY.Enabled = True

                    Dim SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "'"
                    gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                    If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                        CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                    End If
                    'CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY"))
                    Txt_PONo.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO"))
                    Dim grnTYPE() As String = Split(Txt_PONo.Text, "/")

                    'SQL = " SELECT * FROM INV_SPONSORMASTER where ISNULL(Freeze,'N')<>'Y' and  SPONSORCODE='" + Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO")) + "'"
                    'gconnection.getDataSet(SQL, "INV_SPONSORMASTER")
                    If Txt_PONo.Text = "" Then
                        CmbGrnType.Text = "DIRECT GRN"
                    Else
                        CmbGrnType.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("grn_type1"))
                    End If

                    If CmbGrnType.Text = "SPONSOR" Then
                        'CmbGrnType.Text = "SPONSOR"
                        'LBL_SPONSOR.Show()
                        'TXT_Sponsor.Show()
                        'cmd_SPONhelp.Show()
                        'TXT_Sponsor.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO"))
                    ElseIf CmbGrnType.Text = "DIRECT GRN" Then
                        ' CmbGrnType.Text = "DIRCET GRN"
                        LBL_SPONSOR.Hide()
                        TXT_Sponsor.Hide()
                        cmd_SPONhelp.Hide()
                        Txt_PONo.Hide()
                        Label4.Hide()
                        cmd_PONOhelp.Hide()
                    Else

                        Txt_PONo.Show()
                        Label4.Show()
                        cmd_PONOhelp.Show()
                        '  CmbGrnType.Text = "PO"
                    End If

                    txt_Grnno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDETAILS"))



                    dtp_Grndate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDATE")), "dd/MMM/yyyy")
                    'dtp_Grndate.Enabled = False
                    txt_Supplierinvno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERINVNO"))
                    dtp_Supplierinvdate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERDATE")), "dd/MMM/yyyy")
                    txt_Suppliercode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERCODE"))
                    txt_Suppliername.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERNAME"))
                    txt_Storecode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("STORECODE"))
                    txt_StoreDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("STOREDESC"))
                    If gShortname = "CPC" Then
                        TXT_ERSALETAX.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("ERSALETAX"))
                        txt_Ertax.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("ERTAX"))
                    End If
                    If Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("VOID")) = "Y" Then
                        Cmd_Add.Enabled = False
                        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or UCase(gShortname) = "HSR" Then
                            Cmd_Freeze.Enabled = False
                            Cmd_Add.Enabled = False
                            Me.lbl_Freeze.Visible = True
                            Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("voiddate")), "dd/MMM/yyyy")
                        Else
                            Cmd_Freeze.Enabled = False
                            Me.lbl_Freeze.Visible = True
                            Me.lbl_Freeze.Visible = True
                            Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("voiddate")), "dd/MMM/yyyy")
                        End If

                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Freeze.Enabled = False


                    ElseIf Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("RET_STATUS")) = "Y" Then
                        Cmd_Freeze.Enabled = False
                        Cmd_Add.Enabled = False
                        sqlstring = "select * from pRN_HEADER where grndetails='" + txt_Grnno.Text + "'"
                        gconnection.getDataSet(sqlstring, "pRN_HEADER")
                        If gdataset.Tables("pRN_HEADER").Rows.Count > 0 Then
                            Me.lbl_Freeze.Text = " GRN is Return on " & Format(CDate(gdataset.Tables("pRN_HEADER").Rows(0).Item("prndate")), "dd/MMM/yyyy")
                            Me.lbl_Freeze.Visible = True
                        End If
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.Cmd_Add.Enabled = True
                            Me.Cmd_Freeze.Enabled = True

                        End If
                        '''************************************************* SELECT record from Grn_details *********************************************''''                
                        Dim vtmpitemcode, strsql As String
                        sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,isnull(baseamount,0) as baseamount,isnull(discper,0) as discper,isnull(taxcode,'') as taxcode,isnull(batchno,'') as batchno,"
                        sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(TAXPER,0) AS TAXPER,ISNULL(TAXAMOUNT,0) AS TAXAMOUNT,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,ISNULL(AMOUNTAFTERDISCOUNT,0) AS AMOUNTAFTERDISCOUNT,"
                    sqlstring = sqlstring & " ISNULL(VOIDITEM,'N') AS VOIDITEM , isnull(OTHCHARGE,0) AS OTHCHARGE,isnull(freeqty,0) AS freeqty,ISNULL(FQUOM,'') AS FQUOM,ISNULL(SPONSORCODE,'') AS SPONSORCODE,ISNULL(COMPANYCODE,'') AS COMPANYCODE,"
                    If GBATCHNO = "Y" Then
                        sqlstring = sqlstring & "isnull(batch_no,'') as batch_no,"
                    End If
                    If GEXPIRY = "Y" Then
                        sqlstring = sqlstring & "ISNULL(EXPIRYDATE,'') AS EXPIRYDATE,"
                    End If
                    If GSHELVING = "Y" Then
                        sqlstring = sqlstring & "isnull(SHELF,'') as SHELF,"
                    End If
                    sqlstring = sqlstring & " ISNULL(SPLCESS, 0) As SPLCESS  FROM GRN_DETAILS WHERE  GRNDETAILS ='" & Trim(txt_Grnno.Text) & "'"
                    sqlstring = sqlstring & " ORDER BY AUTOID "
                    gconnection.getDataSet(sqlstring, "GRNDETAILS")

                    AxfpSpread1.ClearRange(1, 1, -1, -1, True)

                        If gdataset.Tables("GRNDETAILS").Rows.Count > 0 Then
                            For I = 1 To gdataset.Tables("GRNDETAILS").Rows.Count
                                AxfpSpread1.SetText(1, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE")))
                                vtmpitemcode = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE"))
                                AxfpSpread1.SetText(2, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMNAME")))
                                AxfpSpread1.Col = 3
                                Dim sql1 As String = "Select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("GRNDETAILS").Rows(J).Item("itemcode") + "'"

                                gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                    AxfpSpread1.Row = I
                                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                    AxfpSpread1.Col = 18
                                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                    AxfpSpread1.Col = 3
                                Next Z

                                ' AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))

                                '    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                                AxfpSpread1.SetText(3, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM")))
                                '   AxfpSpread1.SetText(18, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM")))

                                '  AxfpSpread1.Text = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                                AxfpSpread1.SetText(4, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("qty")), "0.000"))
                            AxfpSpread1.SetText(5, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("RATE")), "0.00"))
                            AxfpSpread1.SetText(6, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("baseamount")), "0.00"))
                            '            ssgrid.SetText(7, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("PROFITPER")), "0.000"))
                            AxfpSpread1.SetText(7, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("discper")), "0.00"))
                            AxfpSpread1.SetText(8, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("discount")), "0.00"))
                            AxfpSpread1.SetText(9, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("amountafterdiscount")), "0.00"))

                            AxfpSpread1.SetText(11, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("taxper")), "0.00"))
                            AxfpSpread1.SetText(12, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("taxamount")), "0.00"))
                            AxfpSpread1.SetText(13, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("amount")), "0.00"))
                            AxfpSpread1.SetText(10, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("taxcode"))
                                AxfpSpread1.SetText(14, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("batchno"))
                            AxfpSpread1.SetText(15, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("othcharge")), "0.00"))
                            ' AxfpSpread1.SetText(16, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("voiditem"))
                            AxfpSpread1.Row = I
                                AxfpSpread1.Col = 16
                                '     AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("voiditem"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("voiditem"))

                                AxfpSpread1.SetText(17, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("FREEQTY")))
                                AxfpSpread1.SetText(18, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("FQUOM"))
                                AxfpSpread1.SetText(19, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("SPONSORCODE"))
                            AxfpSpread1.SetText(20, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("COMPANYCODE"))
                            If GBATCHNO = "Y" Then
                                AxfpSpread1.SetText(22, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("batch_no"))
                            End If
                            If GEXPIRY = "Y" Then
                                AxfpSpread1.SetText(23, I, Format(gdataset.Tables("GRNDETAILS").Rows(J).Item("EXPIRYDATE"), "dd/MM/yy"))
                            End If
                            If GSHELVING = "Y" Then
                                AxfpSpread1.SetText(24, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("SHELF"))
                            End If
                            AxfpSpread1.SetText(21, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("SPLCESS")), "0.00"))
                            '           ssgrid.SetText(11, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("SALERATE")), "0.000"))
                            '          ssgrid.SetText(12, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("DBLAMOUNT")), "0.000"))
                            '         ssgrid.SetText(13, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("DBLUOM")))
                            'ssgrid.SetText(14, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("HIGHRATIO")), "0.000"))
                            'AxfpSpread1.SetText(21, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("VOIDITEM")))
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
                    txt_RoundUP.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("RoundupAmt")), "0.00")
                    txt_Billamount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("BILLAMOUNT")), "0.00")
                    TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("OVERALLdiscount")), "0.00")
                    txt_Surchargeamt.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("SURCHARGEAMT")), "0.00")
                    If gShortname = "CPC" Then
                        TXT_ERSALETAX.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("ERSALETAX")), "0.00")
                        txt_Ertax.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("ERTAX")), "0.00")
                    End If
                    txt_Remarks.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("REMARKS"))
                        ''mani
                        Txt_GLAcIn.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("glacccode"))
                        Txt_GLAcDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("glaccdesc"))
                        Txt_Slcode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("slcode"))
                        Txt_SlDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("sldesc"))
                        'Txt_CostCenterCode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("costcentercode"))
                        'Txt_CostCenterDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("costcenterdesc"))

                        Call txt_Suppliercode_Validated(txt_Suppliercode, e)

                        'TotalCount = gdataset.Tables("GRNDETAILS").Rows.Count
                        CALCULATE()
                        AxfpSpread1.SetActiveCell(1, 1)
                        If gUserCategory <> "S" Then
                            Call GetRights()
                        End If
                        Cmd_Add.Text = "Update[F7]"
                        SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "'"
                        gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                        If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                            CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                        End If
                    End If
            Catch ex As Exception
                MessageBox.Show("Enter valid GRN No : txt_Grnno_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub txt_totdisc_TextChanged(sender As Object, e As EventArgs) Handles txt_totdisc.TextChanged
        If calcbool = False Then
            CALCULATE()
        End If
    End Sub

    Private Sub txt_totaltax_TextChanged(sender As Object, e As EventArgs) Handles txt_totaltax.TextChanged
        '        If calcbool = False Then
        CALCULATE()
        'End If
    End Sub

    Private Sub TXT_OVERALLdiscount_TextChanged(sender As Object, e As EventArgs) Handles TXT_OVERALLdiscount.TextChanged
        Dim bill As Double

        If Mid(UCase(gShortname), 1, 4) <> "HIND" Then



            If check_VendorTypeRU(txt_Suppliercode.Text) Then

                bill = Val(Format(Val(txt_total.Text) + Val(txt_Surchargeamt.Text) + Val(txt_RoundUP.Text) - Val(txt_totdisc.Text), "0.00"))

            Else
                bill = Val(Format(Val(txt_total.Text) + Val(txt_Surchargeamt.Text) + Val(txt_RoundUP.Text) - Val(txt_totdisc.Text) + Val(txt_totaltax.Text), "0.00"))

            End If
            If Val(TXT_OVERALLdiscount.Text) > bill Then
                TXT_OVERALLdiscount.Text = ""
            Else

                If Mid(UCase(gShortname), 1, 3) = "NIZ" Or Mid(UCase(gShortname), 1, 3) = "CFC" Or Mid(UCase(gShortname), 1, 3) = "BRC" Then
                    txt_Billamount.Text = Format(Val(txt_total.Text) + Val(txt_Surchargeamt.Text) + Val(txt_RoundUP.Text) + Val(TXT_ERSALETAX.Text) + Val(txt_Ertax.Text) + Val(txt_totaltax.Text) - (Val(TXT_OVERALLdiscount.Text) + Val(txt_totdisc.Text)), "0.000")
                Else
                    '                    If calcbool = False Then
                    CALCULATE()
                    '                End If

                End If
            End If
        End If


    End Sub

    Private Sub txt_Surchargeamt_TextChanged(sender As Object, e As EventArgs) Handles txt_Surchargeamt.TextChanged
        If Mid(UCase(gShortname), 1, 4) <> "HIND" Then
            If Mid(UCase(gShortname), 1, 3) = "NIZ" Or Mid(UCase(gShortname), 1, 3) = "CFC" Or Mid(UCase(gShortname), 1, 3) = "BRC" Then
                txt_Billamount.Text = Format(Val(txt_total.Text) + Val(txt_Surchargeamt.Text) + Val(txt_RoundUP.Text) + Val(TXT_ERSALETAX.Text) + Val(txt_Ertax.Text) + Val(txt_totaltax.Text) - (Val(TXT_OVERALLdiscount.Text) + Val(txt_totdisc.Text)), "0.000")
            Else
                '                If calcbool = False Then
                CALCULATE()
                '            End If

            End If
        End If

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
            If UCase(gShortname) = "OUTR" Then
                Txt_GLAcIn.Focus()
            Else
                AxfpSpread1.Focus()
            End If


        End If
    End Sub


    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click

        Dim TaType As String = TaxType("GRN", Trim(txt_Grnno.Text), Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy"))


        If TaType = "GST" Or TaType = "IGST" Or TaType = "TAXL" Then

            If TaType = "GST" Or TaType = "IGST" Or TaType = "TAXL" Then
                Try
                    ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL, addr As String

                    If UCase(gShortname) = "SATC" Then

                        Dim r As New Rpt_GrnBillSATCGST
                        sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                        sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                        sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                        sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                        sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt  ,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt, ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE"
                        sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                        sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "'"

                        sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "

                        gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
                        If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then

                            Dim sqlstring1 = "SELECT * FROM vW_GRN_DET WHERE GRNDETAILS='" & Trim(txt_Grnno.Text) & "'  ORDER BY ORD , TOTALAMOUNT"
                            gconnection.getDataSet(sqlstring1, "vW_GRN_DET")

                            Call rViewer.GetDetails1New(sqlstring1, "vW_GRN_DET", r)

                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_INV_GRNBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text13")
                            textobj1.Text = MyCompanyName
                            addr = ""

                            Dim textobj14 As TextObject
                            textobj14 = r.ReportDefinition.ReportObjects("Text32")
                            ' textobj14.Text = UCase(Address1)
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

                            textobj14.Text = addr
                            ' Dim textobj16 As TextObject
                            ' textobj1 = r.ReportDef    inition.ReportObjects("Text33")
                            ' textobj1.Text = UCase(Address2)
                            Dim textobj18 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text35")
                            textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text30")
                            textobj2.Text = gUsername

                            Dim Text62 As TextObject
                            Text62 = r.ReportDefinition.ReportObjects("Text62")
                            Text62.Text = gGSTINNO


                            Dim textobj188 As TextObject
                            textobj188 = r.ReportDefinition.ReportObjects("Text18")
                            If UCase(gShortname) = "KBA" Then

                                textobj188.Text = "GST/TCS"
                            Else
                                textobj188.Text = "GST %"
                            End If


                            If UCase(gShortname) = "SATC" Then
                                Dim textobj144 As TextObject
                                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                                textobj144.Text = "GRN CUM PURCHASE BILL"
                            Else
                                Dim textobj144 As TextObject
                                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                                textobj144.Text = "PURCHASE BILL"
                            End If
                            ' Dim textobj199 As TextObject
                            ' textobj199 = r.ReportDefinition.ReportObjects("Text21")

                            Dim textobj26 As TextObject
                            textobj26 = r.ReportDefinition.ReportObjects("Text26")

                            If UCase(gShortname) = "KBA" Then
                                Dim I As Integer
                                sql = "select DISTINCT TAXGROUPCODE from VW_INV_GRNBILL WHERE GRNDETAILS='" + txt_Grnno.Text + "'  "
                                'End If
                                gconnection.getDataSet(sql, "TAXGROUPCODE")
                                If gdataset.Tables("TAXGROUPCODE").Rows.Count > 0 Then
                                    sql = ""
                                    For I = 0 To gdataset.Tables("TAXGROUPCODE").Rows.Count - 1
                                        ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                                        sql = sql & " " & Trim(gdataset.Tables("TAXGROUPCODE").Rows(I).Item("TAXGROUPCODE")) & " ,"
                                    Next
                                End If

                                sql = Mid(sql, 1, Len(sql) - 2)

                                '  textobj199.Text = sql + "  :"

                                textobj26.Text = "Section Incharge                                                                 Admin                                                                                              Accounts"
                            Else
                                ' textobj199.Text = "VAT AMOUNT :"
                            End If

                            'Dim textobj3 As TextObject
                            'textobj3 = r.ReportDefinition.ReportObjects("Text28")
                            'textobj3.Text = ""




                            'textobj3.Text = addr

                            Dim Text43 As TextObject
                            Text43 = r.ReportDefinition.ReportObjects("Text43")
                            Text43.Text = gPhone1

                            Dim Text44 As TextObject
                            Text44 = r.ReportDefinition.ReportObjects("Text44")
                            Text44.Text = gPhone2

                            Dim Text45 As TextObject
                            Text45 = r.ReportDefinition.ReportObjects("Text45")
                            Text45.Text = gFax

                            Dim Text46 As TextObject
                            Text46 = r.ReportDefinition.ReportObjects("Text46")
                            Text46.Text = gEMail

                            sql = "select  Adduser from grn_header WHERE GRNDETAILS='" + txt_Grnno.Text + "'  "

                            gconnection.getDataSet(sql, "grn_header")
                            If gdataset.Tables("grn_header").Rows.Count > 0 Then
                                Dim Text37 As TextObject
                                Text37 = r.ReportDefinition.ReportObjects("Text37")
                                Text37.Text = Trim(gdataset.Tables("grn_header").Rows(0).Item("Adduser"))
                            End If


                            rViewer.Refresh()
                            rViewer.Show()

                            If viewprint = True Then

                                r.PrintToPrinter(1, False, 0, 0)
                                rViewer.Visible = False
                                viewprint = False
                            End If

                            'End If
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If
                    Else
                        Dim r
                        If UCase(gShortname) = "MLRF" Then
                            r = New Rpt_GrnBillGSTNEW_MLRF
                            sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                            sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                            sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                            sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt ,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE "
                            sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                            sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "' AND ISNULL(VOIDITEM,'')<>'Y'"
                            'If rdo_code.Checked = True Then
                            '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                            'ElseIf rdo_name.Checked = True Then
                            '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                            'Else
                            sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "
                        ElseIf UCase(gShortname) = "CFC" Then
                            r = New Rpt_GrnBillGSTNEW_CFC

                            sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                            sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                            sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                            sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt ,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE, "
                            sqlstring = sqlstring & " ISNULL(FREEQTY,0)AS FREEQTY FROM VW_INV_GRNBILL "
                            sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "' AND ISNULL(VOIDITEM,'')<>'Y'"
                            'If rdo_code.Checked = True Then
                            '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                            'ElseIf rdo_name.Checked = True Then
                            '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                            'Else
                            sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "
                            'End If
                        Else
                            If gShortname = "SKYYE" Then
                                r = New Rpt_GrnBillGSTNEW_SKYYE
                            Else
                                r = New Rpt_GrnBillGSTNEW
                            End If



                            If gShortname = "BRC" Then
                                sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                                sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, ISNULL(SUPPLIERDATE,'') AS SUPPLIERDATE , "
                                sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                                sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                                sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt ,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE "
                                sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                                sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "' AND ISNULL(VOIDITEM,'')<>'Y'"

                            Else
                                sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE,supplierdate, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                                sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                                sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                                sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                                sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt ,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE "
                                sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                                sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "' AND ISNULL(VOIDITEM,'')<>'Y'"

                            End If


                          'If rdo_code.Checked = True Then
                            '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                            'ElseIf rdo_name.Checked = True Then
                            '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                            'Else
                            sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "
                        End If
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
                            If UCase(gShortname) = "CFC" Then
                                rViewer.ssql = sqlstring
                                rViewer.Report = r
                                rViewer.TableName = "VW_INV_GRNBILL"
                                Dim textobj1 As TextObject
                                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                                textobj1.Text = MyCompanyName
                                Dim textobj14 As TextObject
                                textobj14 = r.ReportDefinition.ReportObjects("Text32")
                                textobj14.Text = UCase(Address1) + "," + UCase(Address2)
                                Dim textobj16 As TextObject
                                textobj1 = r.ReportDefinition.ReportObjects("Text33")
                                textobj1.Text = UCase(gState) + " , " + UCase(gPincode)
                                Dim textobj23 As TextObject
                                textobj1 = r.ReportDefinition.ReportObjects("Text23")
                                textobj1.Text = "PHONE NO : " & UCase(gPhone1) + " , " + UCase(gPhone2)
                                Dim textobj25 As TextObject
                                textobj25 = r.ReportDefinition.ReportObjects("Text25")
                                textobj25.Text = "GSTIN NO : " & UCase(gGSTINNO)
                                Dim textobj18 As TextObject
                                textobj1 = r.ReportDefinition.ReportObjects("Text35")
                                textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                                Dim textobj2 As TextObject
                                textobj2 = r.ReportDefinition.ReportObjects("Text30")
                                textobj2.Text = gUsername
                                Dim textobj188 As TextObject
                                textobj188 = r.ReportDefinition.ReportObjects("Text18")

                            Else
                                rViewer.ssql = sqlstring
                                rViewer.Report = r
                                rViewer.TableName = "VW_INV_GRNBILL"

                                'If gpocode = "Y" Then
                                '    Dim DTPODATE As New DataTable
                                '    DTPODATE = gconnection.GetValues("select format(podate,'dd/MM/yyyy') as podate from po_hdr where pono in (select pono from grn_header where grndetails='" & txt_Grnno.Text & "')")
                                '    If DTPODATE.Rows.Count > 0 Then
                                '        Dim textobj19 As TextObject
                                '        textobj19 = r.ReportDefinition.ReportObjects("Text22")
                                '        textobj19.Text = Format(CDate(DTPODATE.Rows(0).Item("podate")), "dd/MM/yyyy")
                                '    End If
                                'Else
                                '    'Dim textobj19 As TextObject
                                '    'textobj19 = r.ReportDefinition.ReportObjects("Text22")
                                '    'textobj19.Text = ""
                                'End If



                                Dim textobj1 As TextObject
                                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                                textobj1.Text = MyCompanyName

                                If UCase(gShortname) = "SKYYE" Then
                                    addr = ""
                                    Dim textobj3 As TextObject
                                    textobj3 = r.ReportDefinition.ReportObjects("Text32")
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
                                    Dim textobj14 As TextObject
                                    textobj14 = r.ReportDefinition.ReportObjects("Text32")
                                    textobj14.Text = UCase(Address1)
                                    Dim textobj16 As TextObject
                                    textobj1 = r.ReportDefinition.ReportObjects("Text33")
                                    textobj1.Text = UCase(Address2) + " , " + UCase(gCity)

                                End If

                                Dim textobj18 As TextObject
                                textobj1 = r.ReportDefinition.ReportObjects("Text35")
                                textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                                Dim textobj2 As TextObject
                                textobj2 = r.ReportDefinition.ReportObjects("Text30")
                                textobj2.Text = gUsername
                                Dim textobj188 As TextObject
                                textobj188 = r.ReportDefinition.ReportObjects("Text18")

                                If UCase(gShortname) = "KBA" Then

                                    textobj188.Text = "GST/TCS"
                                Else
                                    textobj188.Text = "GST%"
                                End If
                            End If

                            If UCase(gShortname) = "SATC" Or UCase(gShortname) = "HGA" Then
                                Dim textobj144 As TextObject
                                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                                textobj144.Text = "GRN CUM PURCHASE BILL"
                            ElseIf UCase(gShortname) = "KEA" Or UCase(gShortname) = "KBA" Or UCase(gShortname) = "CATH" Or UCase(gShortname) = "KGA" Or UCase(gShortname) = "SKYYE" Then
                                Dim textobj144 As TextObject
                                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                                textobj144.Text = "GOODS RECEIPT NOTE"
                            Else
                                Dim textobj144 As TextObject
                                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                                textobj144.Text = "PURCHASE BILL"
                            End If
                            'Dim textobj199 As TextObject
                            ' textobj199 = r.ReportDefinition.ReportObjects("Text21")

                            Dim textobj26 As TextObject
                            textobj26 = r.ReportDefinition.ReportObjects("Text26")

                            If UCase(gShortname) = "KBA" Then
                                Dim I As Integer
                                sql = "select DISTINCT TAXGROUPCODE from VW_INV_GRNBILL WHERE GRNDETAILS='" + txt_Grnno.Text + "'  "
                                'End If
                                gconnection.getDataSet(sql, "TAXGROUPCODE")
                                If gdataset.Tables("TAXGROUPCODE").Rows.Count > 0 Then
                                    sql = ""
                                    For I = 0 To gdataset.Tables("TAXGROUPCODE").Rows.Count - 1
                                        ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                                        sql = sql & " " & Trim(gdataset.Tables("TAXGROUPCODE").Rows(I).Item("TAXGROUPCODE")) & " ,"
                                    Next
                                End If

                                sql = Mid(sql, 1, Len(sql) - 2)

                                '  textobj199.Text = sql + "  :"

                                textobj26.Text = "           Section Incharge      I.                                                                                                  Accounts: "
                            Else
                                If UCase(gShortname) <> "SKYYE" Then
                                    Dim textobj21 As TextObject
                                    textobj21 = r.ReportDefinition.ReportObjects("Text21")
                                    textobj21.Text = ""
                                End If

                                If UCase(gShortname) = "KEA" Then
                                    textobj26.Text = "Chairman Bar Committee                                        Office Manager                              Treasurer                             Hon. Secretary"
                                End If
                                    If UCase(gShortname) = "DGC" Then
                                        textobj26.Text = "Store Keeper                                                              Asst. Manager                                                                       Asst. Secretary"
                                    End If
                                If UCase(gShortname) = "TMA" Then
                                    textobj26.Text = "Store Keeper:                                                                                                                                                  Manager: "
                                End If
                                If UCase(gShortname) = "KGA" Then
                                    textobj26.Text = "                 Store Keeper                                                                                                      Asst. Manager"
                                End If
                                'If UCase(gShortname) = "HGA" Then
                                '    textobj26.Text = "Store Keeper:                                                                                                                                             Manager:            "
                                'End If
                                If UCase(gShortname) = "HGA" Then
                                        textobj26.Text = "Store Keeper:                                                                                                                                             Authorized Signature:            "
                                    End If
                                    If UCase(gShortname) = "MLRF" Then
                                        textobj26.Text = "Prepared By:                                                                                                                                                 Approved By:            "
                                    End If
                                End If
                            If gShortname <> "SKYYE" Then
                                Dim textobj3 As TextObject
                                textobj3 = r.ReportDefinition.ReportObjects("Text28")
                                textobj3.Text = ""
                            End If
                            ' End If
                            rViewer.Show()
                                rViewer.Refresh()


                                If viewprint = True Then

                                    r.PrintToPrinter(1, False, 0, 0)
                                    rViewer.Visible = False
                                    viewprint = False
                                End If
                                'End If
                            Else
                                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If
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
                Dim sqlstring, SSQL, addr As String

                If UCase(gShortname) = "SATC" Then

                    Dim r As New Rpt_GrnBillSATC
                    sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                    sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                    sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                    sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt  "
                    sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                    sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "'"

                    sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "

                    gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
                    If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then

                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "VW_INV_GRNBILL"
                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text13")
                        textobj1.Text = MyCompanyName
                        addr = ""

                        Dim textobj14 As TextObject
                        textobj14 = r.ReportDefinition.ReportObjects("Text32")
                        ' textobj14.Text = UCase(Address1)
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

                        textobj14.Text = addr
                        ' Dim textobj16 As TextObject
                        ' textobj1 = r.ReportDefinition.ReportObjects("Text33")
                        ' textobj1.Text = UCase(Address2)
                        Dim textobj18 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text35")
                        textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text30")
                        textobj2.Text = gUsername
                        Dim textobj188 As TextObject
                        textobj188 = r.ReportDefinition.ReportObjects("Text18")
                        If UCase(gShortname) = "KBA" Then

                            textobj188.Text = "VAT/TCS"
                        Else
                            textobj188.Text = "VAT%"
                        End If

                        Dim Text62 As TextObject
                        Text62 = r.ReportDefinition.ReportObjects("Text62")
                        Text62.Text = gGSTINNO

                        If UCase(gShortname) = "SATC" Then
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "GRN CUM PURCHASE BILL"
                        Else
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "PURCHASE BILL"
                        End If
                        Dim textobj199 As TextObject
                        textobj199 = r.ReportDefinition.ReportObjects("Text21")

                        Dim textobj26 As TextObject
                        textobj26 = r.ReportDefinition.ReportObjects("Text26")

                        If UCase(gShortname) = "KBA" Then
                            Dim I As Integer
                            sql = "select DISTINCT TAXGROUPCODE from VW_INV_GRNBILL WHERE GRNDETAILS='" + txt_Grnno.Text + "'  "
                            'End If
                            gconnection.getDataSet(sql, "TAXGROUPCODE")
                            If gdataset.Tables("TAXGROUPCODE").Rows.Count > 0 Then
                                sql = ""
                                For I = 0 To gdataset.Tables("TAXGROUPCODE").Rows.Count - 1
                                    ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                                    sql = sql & " " & Trim(gdataset.Tables("TAXGROUPCODE").Rows(I).Item("TAXGROUPCODE")) & " ,"
                                Next
                            End If

                            sql = Mid(sql, 1, Len(sql) - 2)

                            textobj199.Text = sql + "  :"

                            textobj26.Text = "Section Incharge                                                                 Admin                                                                                   Accounts"
                        Else
                            textobj199.Text = "VAT AMOUNT :"
                        End If

                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text28")
                        textobj3.Text = ""



                        'If Address1 <> "" Then
                        '    addr = addr & Address1
                        'End If

                        'If Address2 <> "" Then
                        '    addr = addr & ", " & Address2
                        'End If

                        'If gCity <> "" Then
                        '    addr = addr & ", " & gCity
                        'End If

                        'If gPincode <> "" Then
                        '    addr = addr & " - " & gPincode
                        'End If

                        textobj3.Text = addr

                        Dim Text43 As TextObject
                        Text43 = r.ReportDefinition.ReportObjects("Text43")
                        Text43.Text = gPhone1

                        Dim Text44 As TextObject
                        Text44 = r.ReportDefinition.ReportObjects("Text44")
                        Text44.Text = gPhone2

                        Dim Text45 As TextObject
                        Text45 = r.ReportDefinition.ReportObjects("Text45")
                        Text45.Text = gFax

                        Dim Text46 As TextObject
                        Text46 = r.ReportDefinition.ReportObjects("Text46")
                        Text46.Text = gEMail

                        sql = "select  Adduser from grn_header WHERE GRNDETAILS='" + txt_Grnno.Text + "'  "

                        gconnection.getDataSet(sql, "grn_header")
                        If gdataset.Tables("grn_header").Rows.Count > 0 Then
                            Dim Text37 As TextObject
                            Text37 = r.ReportDefinition.ReportObjects("Text37")
                            Text37.Text = Trim(gdataset.Tables("grn_header").Rows(0).Item("Adduser"))
                        End If


                        rViewer.Refresh()
                        rViewer.Show()

                        If viewprint = True Then

                            r.PrintToPrinter(1, False, 0, 0)
                            rViewer.Visible = False
                            viewprint = False
                        End If

                        'End If
                    Else
                        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                    End If
                Else
                    Dim r
                    If UCase(gShortname) = "MLRF" Then
                        r = New Rpt_GrnBill_MLRF
                        sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                        sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                        sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                        sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                        sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt  "
                        sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                        sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "'AND ISNULL(VOIDITEM,'')<>'Y'"
                        'If rdo_code.Checked = True Then
                        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                        'ElseIf rdo_name.Checked = True Then
                        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                        'Else
                        sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "
                    ElseIf UCase(gShortname) = "CFC" Then
                        r = New Rpt_GrnBill_CFC
                        sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                        sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                        sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                        sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                        sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt,ISNULL(FREEQTY,'')AS FREEQTY "
                        sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                        sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "' AND ISNULL(VOIDITEM,'')<>'Y'"
                        'If rdo_code.Checked = True Then
                        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                        'ElseIf rdo_name.Checked = True Then
                        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                        'Else
                        sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "
                        'End If
                        'End If
                    Else
                        If gShortname = "SKYYE" Then
                            r = New Rpt_GrnBiLL_SKYYE
                        Else
                            r = New Rpt_GrnBill
                        End If

                        sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                        sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                        sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                        sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                        sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt  "
                        sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                        sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "'AND ISNULL(VOIDITEM,'')<>'Y'"
                        'If rdo_code.Checked = True Then
                        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                        'ElseIf rdo_name.Checked = True Then
                        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                        'Else
                        sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "
                    End If
                    gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
                    If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then
                        'If chk_excel.Checked = True Then
                        '    Dim exp As New exportexcel
                        '    exp.Show()
                        '    Call exp.export(sqlstring, "GRN CUM PURCHASE BILL ", "")
                        'Else


                        'Dim sqlstring1 = "SELECT * FROM vW_GRN_DET WHERE GRNDETAILS='" & Trim(txt_Grnno.Text) & "'  ORDER BY ORD , TOTALAMOUNT"
                        'gconnection.getDataSet(sqlstring1, "vW_GRN_DET")

                        'Call rViewer.GetDetails1New(sqlstring1, "vW_GRN_DET", r)

                        If UCase(gShortname) = "CFC" Then
                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_INV_GRNBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text13")
                            textobj1.Text = MyCompanyName


                            Dim textobj14 As TextObject
                                textobj14 = r.ReportDefinition.ReportObjects("Text32")
                                textobj14.Text = UCase(Address1) + "," + UCase(Address2)
                                Dim textobj16 As TextObject
                                textobj1 = r.ReportDefinition.ReportObjects("Text33")
                                textobj1.Text = UCase(gState) + "," + UCase(gPincode)












                            Dim textobj46 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text46")
                            textobj1.Text = "PHONE NO : " & UCase(gPhone1) + "," + UCase(gPhone2)
                            Dim textobj47 As TextObject
                            textobj47 = r.ReportDefinition.ReportObjects("Text47")
                            textobj47.Text = "GSTIN NO : " & UCase(gGSTINNO)
                            Dim textobj18 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text35")
                            textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text30")
                            textobj2.Text = gUsername
                            Dim textobj188 As TextObject
                            textobj188 = r.ReportDefinition.ReportObjects("Text18")
                            If UCase(gShortname) = "KBA" Then

                                textobj188.Text = "VAT/TCS"
                            Else
                                textobj188.Text = "VAT%"
                            End If

                        Else
                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_INV_GRNBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text13")
                            textobj1.Text = MyCompanyName


                            If UCase(gShortname) = "SKYYE" Then
                                addr = ""
                                Dim textobj3 As TextObject
                                textobj3 = r.ReportDefinition.ReportObjects("Text32")
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
                                Dim textobj14 As TextObject
                                textobj14 = r.ReportDefinition.ReportObjects("Text32")
                                textobj14.Text = UCase(Address1)
                                Dim textobj16 As TextObject
                                textobj1 = r.ReportDefinition.ReportObjects("Text33")
                                textobj1.Text = UCase(Address2)
                            End If

                            Dim textobj18 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text35")
                            textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text30")
                            textobj2.Text = gUsername
                            Dim textobj188 As TextObject
                            textobj188 = r.ReportDefinition.ReportObjects("Text18")
                            If UCase(gShortname) = "KBA" Then

                                textobj188.Text = "VAT/TCS"
                            Else
                                textobj188.Text = "TAX%"
                            End If


                            'If gpocode = "Y" Then
                            '    Dim DTPODATE As New DataTable
                            '    DTPODATE = gconnection.GetValues("select format(podate,'dd/MMM/yyyy') as podate from po_hdr where pono in (select pono from grn_header where grndetails='" & txt_Grnno.Text & "')")
                            '    If DTPODATE.Rows.Count > 0 Then
                            '        Dim textobj19 As TextObject
                            '        textobj19 = r.ReportDefinition.ReportObjects("Text46")
                            '        textobj19.Text = Format(CDate(DTPODATE.Rows(0).Item("podate")), "dd/MM/yyyy")
                            '    End If
                            'Else
                            '    'Dim textobj19 As TextObject
                            '    'textobj19 = r.ReportDefinition.ReportObjects("Text46")
                            '    'textobj19.Text = ""
                            'End If

                            'For Hiding % after Other charges Other Than Deccan Club

                            If UCase(gShortname) = "DC" Then
                            Else

                                Dim textobj45 As TextObject
                                textobj45 = r.ReportDefinition.ReportObjects("Text45")
                                textobj45.Text = ""
                            End If


                        End If
                        If UCase(gShortname) = "SATC" Then
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "GRN CUM PURCHASE BILL"
                        ElseIf UCase(gShortname) = "KEA" Or UCase(gShortname) = "KBA" Or UCase(gShortname) = "CATH" Or UCase(gShortname) = "KGA" Or gShortname = "SKYYE" Then
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "GOODS RECEIPT NOTE"
                        ElseIf UCase(gShortname) = "HGA" Then
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "GRN CUM PURCHASE BILL"
                        Else
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "PURCHASE BILL"
                        End If
                        Dim textobj199 As TextObject
                        textobj199 = r.ReportDefinition.ReportObjects("Text21")

                        Dim textobj26 As TextObject
                        textobj26 = r.ReportDefinition.ReportObjects("Text26")
                        If UCase(gShortname) = "KGA" Then
                            textobj26.Text = "                 Store Keeper                                                                                                      Asst. Manager"
                        End If

                        Dim textobj44 As TextObject
                        textobj44 = r.ReportDefinition.ReportObjects("Text44")

                        If UCase(gShortname) = "KBA" Then
                            Dim I As Integer
                            sql = "select DISTINCT TAXGROUPCODE from VW_INV_GRNBILL WHERE GRNDETAILS='" + txt_Grnno.Text + "'  "
                            'End If
                            gconnection.getDataSet(sql, "TAXGROUPCODE")
                            If gdataset.Tables("TAXGROUPCODE").Rows.Count > 0 Then
                                sql = ""
                                For I = 0 To gdataset.Tables("TAXGROUPCODE").Rows.Count - 1
                                    ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                                    sql = sql & " " & Trim(gdataset.Tables("TAXGROUPCODE").Rows(I).Item("TAXGROUPCODE")) & " ,"
                                Next
                            End If

                            sql = Mid(sql, 1, Len(sql) - 2)

                            textobj199.Text = sql + "  :"

                            textobj26.Text = "Section Incharge  1                                                                                                                                                  Accounts"
                            textobj44.Text = "Section Incharge  2                                              "
                        Else
                            If UCase(gShortname) = "KEA" Then
                                textobj26.Text = "Chairman Bar Committee                                          Office Manager                                     Treasurer                                             Hon. Secretary"
                            End If
                            textobj199.Text = "TAX AMOUNT :"
                        End If
                        If UCase(gShortname) = "MLRF" Then
                            textobj26.Text = "      Prepared By:                                                                                                                                                  Approved By:           "
                        End If


                        If UCase(gShortname) = "HGA" Then
                            textobj26.Text = "Store Keeper:                                                                                                                                             Authorized Signature:            "
                        End If

                        If UCase(gShortname) = "KGA" Then
                            textobj26.Text = "Store Keeper                                                              Asst. Manager"
                        End If

                        If UCase(gShortname) <> "SKYYE" Then
                            Dim textobj3 As TextObject
                            textobj3 = r.ReportDefinition.ReportObjects("Text28")
                            textobj3.Text = ""
                        End If
                        ' End If

                        rViewer.Show()
                            rViewer.Refresh()


                            If viewprint = True Then

                                r.PrintToPrinter(1, False, 0, 0)
                                rViewer.Visible = False
                                viewprint = False
                            End If
                            'End If
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                    End If
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
    Public Sub GRNPRINTVIEW(ByVal GRNNO As String, ByVal GRNDATE As Date)
        Dim TaType As String = TaxType("GRN", Trim(GRNNO), Format(CDate(GRNDATE), "dd/MMM/yyyy"))

        If TaType = "GST" Or TaType = "IGST" Or TaType = "TAXL" Then

            If TaType = "GST" Or TaType = "IGST" Or TaType = "TAXL" Then
                Try
                    ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL, addr As String


                    'If UCase(gShortname) = "CPC" Then

                    '    Dim r As New Rpt_GrnBillSATCGST
                    '    sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                    '    sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                    '    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                    '    sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                    '    sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt  ,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt, ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE"
                    '    sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                    '    sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(GRNNO) & "' AND '" & Trim(GRNDATE) & "'"

                    '    sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "

                    '    gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
                    '    If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then

                    '        Dim sqlstring1 = "SELECT * FROM vW_GRN_DET WHERE GRNDETAILS='" & Trim(GRNNO) & "'  ORDER BY ORD , TOTALAMOUNT"
                    '        gconnection.getDataSet(sqlstring1, "vW_GRN_DET")

                    '        Call rViewer.GetDetails1New(sqlstring1, "vW_GRN_DET", r)

                    '        rViewer.ssql = sqlstring
                    '        rViewer.Report = r
                    '        rViewer.TableName = "VW_INV_GRNBILL"
                    '        Dim textobj1 As TextObject
                    '        textobj1 = r.ReportDefinition.ReportObjects("Text13")
                    '        textobj1.Text = MyCompanyName
                    '        addr = ""

                    '        Dim textobj14 As TextObject
                    '        textobj14 = r.ReportDefinition.ReportObjects("Text32")
                    '        ' textobj14.Text = UCase(Address1)
                    '        If Address1 <> "" Then
                    '            addr = addr & Address1
                    '        End If

                    '        If Address2 <> "" Then
                    '            addr = addr & ", " & Address2
                    '        End If

                    '        If gCity <> "" Then
                    '            addr = addr & ", " & gCity
                    '        End If

                    '        If gPincode <> "" Then
                    '            addr = addr & " - " & gPincode
                    '        End If

                    '        textobj14.Text = addr
                    '        ' Dim textobj16 As TextObject
                    '        ' textobj1 = r.ReportDef    inition.ReportObjects("Text33")
                    '        ' textobj1.Text = UCase(Address2)
                    '        Dim textobj18 As TextObject
                    '        textobj1 = r.ReportDefinition.ReportObjects("Text35")
                    '        textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                    '        Dim textobj2 As TextObject
                    '        textobj2 = r.ReportDefinition.ReportObjects("Text30")
                    '        textobj2.Text = gUsername

                    '        Dim Text62 As TextObject
                    '        Text62 = r.ReportDefinition.ReportObjects("Text62")
                    '        Text62.Text = gGSTINNO


                    '        Dim textobj188 As TextObject
                    '        textobj188 = r.ReportDefinition.ReportObjects("Text18")
                    '        If UCase(gShortname) = "KBA" Then

                    '            textobj188.Text = "GST/TCS"
                    '        Else
                    '            textobj188.Text = "GST %"
                    '        End If


                    '        If UCase(gShortname) = "CPC" Then
                    '            Dim textobj144 As TextObject
                    '            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                    '            textobj144.Text = "GRN CUM PURCHASE BILL"
                    '        Else
                    '            Dim textobj144 As TextObject
                    '            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                    '            textobj144.Text = "PURCHASE BILL"
                    '        End If
                    '        ' Dim textobj199 As TextObject
                    '        ' textobj199 = r.ReportDefinition.ReportObjects("Text21")

                    '        Dim textobj26 As TextObject
                    '        textobj26 = r.ReportDefinition.ReportObjects("Text26")

                    '        If UCase(gShortname) = "KBA" Then
                    '            Dim I As Integer
                    '            sql = "select DISTINCT TAXGROUPCODE from VW_INV_GRNBILL WHERE GRNDETAILS='" + GRNNO + "'  "
                    '            'End If
                    '            gconnection.getDataSet(sql, "TAXGROUPCODE")
                    '            If gdataset.Tables("TAXGROUPCODE").Rows.Count > 0 Then
                    '                sql = ""
                    '                For I = 0 To gdataset.Tables("TAXGROUPCODE").Rows.Count - 1
                    '                    ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                    '                    sql = sql & " " & Trim(gdataset.Tables("TAXGROUPCODE").Rows(I).Item("TAXGROUPCODE")) & " ,"
                    '                Next
                    '            End If

                    '            sql = Mid(sql, 1, Len(sql) - 2)

                    '            '  textobj199.Text = sql + "  :"

                    '            textobj26.Text = "Section Incharge                                                                 Admin                                                                                              Accounts"
                    '        Else
                    '            ' textobj199.Text = "VAT AMOUNT :"
                    '        End If

                    '        'Dim textobj3 As TextObject
                    '        'textobj3 = r.ReportDefinition.ReportObjects("Text28")
                    '        'textobj3.Text = ""




                    '        'textobj3.Text = addr

                    '        Dim Text43 As TextObject
                    '        Text43 = r.ReportDefinition.ReportObjects("Text43")
                    '        Text43.Text = gPhone1

                    '        Dim Text44 As TextObject
                    '        Text44 = r.ReportDefinition.ReportObjects("Text44")
                    '        Text44.Text = gPhone2

                    '        Dim Text45 As TextObject
                    '        Text45 = r.ReportDefinition.ReportObjects("Text45")
                    '        Text45.Text = gFax

                    '        Dim Text46 As TextObject
                    '        Text46 = r.ReportDefinition.ReportObjects("Text46")
                    '        Text46.Text = gEMail

                    '        sql = "select  Adduser from grn_header WHERE GRNDETAILS='" + GRNNO + "'  "

                    '        gconnection.getDataSet(sql, "grn_header")
                    '        If gdataset.Tables("grn_header").Rows.Count > 0 Then
                    '            Dim Text37 As TextObject
                    '            Text37 = r.ReportDefinition.ReportObjects("Text37")
                    '            Text37.Text = Trim(gdataset.Tables("grn_header").Rows(0).Item("Adduser"))
                    '        End If


                    '        rViewer.Refresh()
                    '        rViewer.Show()

                    '        If viewprint = True Then

                    '            r.PrintToPrinter(1, False, 0, 0)
                    '            rViewer.Visible = False
                    '            viewprint = False
                    '        End If
                    '    End If
                    '    'End If
                    'Else
                    '    MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                    'End If


                    If UCase(gShortname) = "SATC" Then

                        Dim r As New Rpt_GrnBillSATCGST
                        sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                        sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                        sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                        sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                        sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt  ,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt, ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE"
                        sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                        sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(GRNNO) & "' AND '" & Trim(GRNDATE) & "'"

                        sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "

                        gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
                        If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then

                            Dim sqlstring1 = "SELECT * FROM vW_GRN_DET WHERE GRNDETAILS='" & Trim(GRNNO) & "'  ORDER BY ORD , TOTALAMOUNT"
                            gconnection.getDataSet(sqlstring1, "vW_GRN_DET")

                            Call rViewer.GetDetails1New(sqlstring1, "vW_GRN_DET", r)

                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_INV_GRNBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text13")
                            textobj1.Text = MyCompanyName
                            addr = ""

                            Dim textobj14 As TextObject
                            textobj14 = r.ReportDefinition.ReportObjects("Text32")
                            ' textobj14.Text = UCase(Address1)
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

                            textobj14.Text = addr
                            ' Dim textobj16 As TextObject
                            ' textobj1 = r.ReportDef    inition.ReportObjects("Text33")
                            ' textobj1.Text = UCase(Address2)
                            Dim textobj18 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text35")
                            textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text30")
                            textobj2.Text = gUsername

                            Dim Text62 As TextObject
                            Text62 = r.ReportDefinition.ReportObjects("Text62")
                            Text62.Text = gGSTINNO


                            Dim textobj188 As TextObject
                            textobj188 = r.ReportDefinition.ReportObjects("Text18")
                            If UCase(gShortname) = "KBA" Then

                                textobj188.Text = "GST/TCS"
                            Else
                                textobj188.Text = "GST %"
                            End If


                            If UCase(gShortname) = "SATC" Then
                                Dim textobj144 As TextObject
                                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                                textobj144.Text = "GRN CUM PURCHASE BILL"
                            Else
                                Dim textobj144 As TextObject
                                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                                textobj144.Text = "PURCHASE BILL"
                            End If
                            ' Dim textobj199 As TextObject
                            ' textobj199 = r.ReportDefinition.ReportObjects("Text21")

                            Dim textobj26 As TextObject
                            textobj26 = r.ReportDefinition.ReportObjects("Text26")

                            If UCase(gShortname) = "KBA" Then
                                Dim I As Integer
                                sql = "select DISTINCT TAXGROUPCODE from VW_INV_GRNBILL WHERE GRNDETAILS='" + GRNNO + "'  "
                                'End If
                                gconnection.getDataSet(sql, "TAXGROUPCODE")
                                If gdataset.Tables("TAXGROUPCODE").Rows.Count > 0 Then
                                    sql = ""
                                    For I = 0 To gdataset.Tables("TAXGROUPCODE").Rows.Count - 1
                                        ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                                        sql = sql & " " & Trim(gdataset.Tables("TAXGROUPCODE").Rows(I).Item("TAXGROUPCODE")) & " ,"
                                    Next
                                End If

                                sql = Mid(sql, 1, Len(sql) - 2)

                                '  textobj199.Text = sql + "  :"

                                textobj26.Text = "Section Incharge                                                                 Admin                                                                                              Accounts"
                            Else
                                ' textobj199.Text = "VAT AMOUNT :"
                            End If

                            'Dim textobj3 As TextObject
                            'textobj3 = r.ReportDefinition.ReportObjects("Text28")
                            'textobj3.Text = ""




                            'textobj3.Text = addr

                            Dim Text43 As TextObject
                            Text43 = r.ReportDefinition.ReportObjects("Text43")
                            Text43.Text = gPhone1

                            Dim Text44 As TextObject
                            Text44 = r.ReportDefinition.ReportObjects("Text44")
                            Text44.Text = gPhone2

                            Dim Text45 As TextObject
                            Text45 = r.ReportDefinition.ReportObjects("Text45")
                            Text45.Text = gFax

                            Dim Text46 As TextObject
                            Text46 = r.ReportDefinition.ReportObjects("Text46")
                            Text46.Text = gEMail

                            sql = "select  Adduser from grn_header WHERE GRNDETAILS='" + GRNNO + "'  "

                            gconnection.getDataSet(sql, "grn_header")
                            If gdataset.Tables("grn_header").Rows.Count > 0 Then
                                Dim Text37 As TextObject
                                Text37 = r.ReportDefinition.ReportObjects("Text37")
                                Text37.Text = Trim(gdataset.Tables("grn_header").Rows(0).Item("Adduser"))
                            End If


                            rViewer.Refresh()
                            rViewer.Show()

                            If viewprint = True Then

                                r.PrintToPrinter(1, False, 0, 0)
                                rViewer.Visible = False
                                viewprint = False
                            End If

                            'End If
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If
                    Else
                        Dim r As New Rpt_GrnBillGSTNEW
                        sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                        sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                        sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                        sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                        sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt ,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE "
                        sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                        sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(GRNNO) & "' AND '" & Trim(GRNNO) & "'"
                        'If rdo_code.Checked = True Then
                        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                        'ElseIf rdo_name.Checked = True Then
                        '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                        'Else
                        sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "
                        'End If
                        gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
                        If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then

                            Dim sqlstring1 = "SELECT * FROM vW_GRN_DET WHERE GRNDETAILS='" & Trim(GRNNO) & "'  ORDER BY ORD , TOTALAMOUNT"
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
                            textobj14.Text = UCase(Address1)
                            Dim textobj16 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text33")
                            textobj1.Text = UCase(Address2) + " , " + UCase(gCity)
                            Dim textobj18 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text35")
                            textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text30")
                            textobj2.Text = gUsername
                            Dim textobj188 As TextObject
                            textobj188 = r.ReportDefinition.ReportObjects("Text18")
                            If UCase(gShortname) = "KBA" Then

                                textobj188.Text = "GST/TCS"
                            Else
                                textobj188.Text = "GST%"
                            End If


                            If UCase(gShortname) = "SATC" Then
                                Dim textobj144 As TextObject
                                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                                textobj144.Text = "GRN CUM PURCHASE BILL"
                            ElseIf UCase(gShortname) = "KEA" Or UCase(gShortname) = "KBA" Or UCase(gShortname) = "CATH" Then
                                Dim textobj144 As TextObject
                                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                                textobj144.Text = "GOODS RECEIPT NOTE"
                            Else
                                Dim textobj144 As TextObject
                                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                                textobj144.Text = "PURCHASE BILL"
                            End If
                            'Dim textobj199 As TextObject
                            ' textobj199 = r.ReportDefinition.ReportObjects("Text21")

                            Dim textobj26 As TextObject
                            textobj26 = r.ReportDefinition.ReportObjects("Text26")

                            If UCase(gShortname) = "KBA" Then
                                Dim I As Integer
                                sql = "select DISTINCT TAXGROUPCODE from VW_INV_GRNBILL WHERE GRNDETAILS='" + GRNNO + "'  "
                                'End If
                                gconnection.getDataSet(sql, "TAXGROUPCODE")
                                If gdataset.Tables("TAXGROUPCODE").Rows.Count > 0 Then
                                    sql = ""
                                    For I = 0 To gdataset.Tables("TAXGROUPCODE").Rows.Count - 1
                                        ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                                        sql = sql & " " & Trim(gdataset.Tables("TAXGROUPCODE").Rows(I).Item("TAXGROUPCODE")) & " ,"
                                    Next
                                End If

                                sql = Mid(sql, 1, Len(sql) - 2)

                                '  textobj199.Text = sql + "  :"

                                textobj26.Text = "           Section Incharge      I.                                                                                                  Accounts: "
                            Else

                                Dim textobj21 As TextObject
                                textobj21 = r.ReportDefinition.ReportObjects("Text21")
                                textobj21.Text = ""

                                If UCase(gShortname) = "KEA" Then
                                    textobj26.Text = "Bar Chairman                                          Office Manager                                     Treasurer                                             Hon. Secretary"
                                End If
                                If UCase(gShortname) = "DGC" Then
                                    textobj26.Text = "Store Keeper                                                              Asst. Manager                                                                       Asst. Secretary"
                                End If
                                If UCase(gShortname) = "HG" Then
                                    textobj26.Text = "Store Keeper                                                               Manager                "
                                End If
                            End If

                            Dim textobj3 As TextObject
                            textobj3 = r.ReportDefinition.ReportObjects("Text28")
                            textobj3.Text = ""
                            ' End If
                            rViewer.Show()
                            rViewer.Refresh()


                            If viewprint = True Then

                                r.PrintToPrinter(1, False, 0, 0)
                                rViewer.Visible = False
                                viewprint = False
                            End If
                            'End If
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If
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
                Dim sqlstring, SSQL, addr As String

                If UCase(gShortname) = "SATC" Then

                    Dim r As New Rpt_GrnBillSATC
                    sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                    sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                    sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                    sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt  "
                    sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                    sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(GRNNO) & "' AND '" & Trim(GRNNO) & "'"

                    sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "

                    gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
                    If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then

                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "VW_INV_GRNBILL"
                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text13")
                        textobj1.Text = MyCompanyName
                        addr = ""

                        Dim textobj14 As TextObject
                        textobj14 = r.ReportDefinition.ReportObjects("Text32")
                        ' textobj14.Text = UCase(Address1)
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

                        textobj14.Text = addr
                        ' Dim textobj16 As TextObject
                        ' textobj1 = r.ReportDefinition.ReportObjects("Text33")
                        ' textobj1.Text = UCase(Address2)
                        Dim textobj18 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text35")
                        textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text30")
                        textobj2.Text = gUsername
                        Dim textobj188 As TextObject
                        textobj188 = r.ReportDefinition.ReportObjects("Text18")
                        If UCase(gShortname) = "KBA" Then

                            textobj188.Text = "VAT/TCS"
                        Else
                            textobj188.Text = "VAT%"
                        End If

                        Dim Text62 As TextObject
                        Text62 = r.ReportDefinition.ReportObjects("Text62")
                        Text62.Text = gGSTINNO

                        If UCase(gShortname) = "SATC" Then
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "GRN CUM PURCHASE BILL"
                        Else
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "PURCHASE BILL"
                        End If
                        Dim textobj199 As TextObject
                        textobj199 = r.ReportDefinition.ReportObjects("Text21")

                        Dim textobj26 As TextObject
                        textobj26 = r.ReportDefinition.ReportObjects("Text26")

                        If UCase(gShortname) = "KBA" Then
                            Dim I As Integer
                            sql = "select DISTINCT TAXGROUPCODE from VW_INV_GRNBILL WHERE GRNDETAILS='" + GRNNO + "'  "
                            'End If
                            gconnection.getDataSet(sql, "TAXGROUPCODE")
                            If gdataset.Tables("TAXGROUPCODE").Rows.Count > 0 Then
                                sql = ""
                                For I = 0 To gdataset.Tables("TAXGROUPCODE").Rows.Count - 1
                                    ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                                    sql = sql & " " & Trim(gdataset.Tables("TAXGROUPCODE").Rows(I).Item("TAXGROUPCODE")) & " ,"
                                Next
                            End If

                            sql = Mid(sql, 1, Len(sql) - 2)

                            textobj199.Text = sql + "  :"

                            textobj26.Text = "Section Incharge                                                                 Admin                                                                                   Accounts"
                        Else
                            textobj199.Text = "VAT AMOUNT :"
                        End If

                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text28")
                        textobj3.Text = ""



                        'If Address1 <> "" Then
                        '    addr = addr & Address1
                        'End If

                        'If Address2 <> "" Then
                        '    addr = addr & ", " & Address2
                        'End If

                        'If gCity <> "" Then
                        '    addr = addr & ", " & gCity
                        'End If

                        'If gPincode <> "" Then
                        '    addr = addr & " - " & gPincode
                        'End If

                        textobj3.Text = addr

                        Dim Text43 As TextObject
                        Text43 = r.ReportDefinition.ReportObjects("Text43")
                        Text43.Text = gPhone1

                        Dim Text44 As TextObject
                        Text44 = r.ReportDefinition.ReportObjects("Text44")
                        Text44.Text = gPhone2

                        Dim Text45 As TextObject
                        Text45 = r.ReportDefinition.ReportObjects("Text45")
                        Text45.Text = gFax

                        Dim Text46 As TextObject
                        Text46 = r.ReportDefinition.ReportObjects("Text46")
                        Text46.Text = gEMail

                        sql = "select  Adduser from grn_header WHERE GRNDETAILS='" + GRNNO + "'  "

                        gconnection.getDataSet(sql, "grn_header")
                        If gdataset.Tables("grn_header").Rows.Count > 0 Then
                            Dim Text37 As TextObject
                            Text37 = r.ReportDefinition.ReportObjects("Text37")
                            Text37.Text = Trim(gdataset.Tables("grn_header").Rows(0).Item("Adduser"))
                        End If


                        rViewer.Refresh()
                        rViewer.Show()

                        If viewprint = True Then

                            r.PrintToPrinter(1, False, 0, 0)
                            rViewer.Visible = False
                            viewprint = False
                        End If

                        'End If
                    Else
                        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                    End If
                Else
                    Dim r As New Rpt_GrnBill
                    sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
                    sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
                    sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
                    sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
                    sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt  "
                    sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
                    sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(GRNNO) & "' AND '" & Trim(GRNNO) & "'"
                    'If rdo_code.Checked = True Then
                    '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMcode "
                    'ElseIf rdo_name.Checked = True Then
                    '    sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE,ITEMNAME "
                    'Else
                    sqlstring = sqlstring & " ORDER BY AUTOID ,GRNDETAILS,GRNDATE "
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
                        textobj14.Text = UCase(Address1)
                        Dim textobj16 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text33")
                        textobj1.Text = UCase(Address2)
                        Dim textobj18 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text35")
                        textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text30")
                        textobj2.Text = gUsername
                        Dim textobj188 As TextObject
                        textobj188 = r.ReportDefinition.ReportObjects("Text18")
                        If UCase(gShortname) = "KBA" Then

                            textobj188.Text = "VAT/TCS"
                        Else
                            textobj188.Text = "VAT%"
                        End If


                        If UCase(gShortname) = "SATC" Then
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "GRN CUM PURCHASE BILL"
                        ElseIf UCase(gShortname) = "KEA" Or UCase(gShortname) = "KBA" Or UCase(gShortname) = "CATH" Then
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "GOODS RECEIPT NOTE"
                        Else
                            Dim textobj144 As TextObject
                            textobj144 = r.ReportDefinition.ReportObjects("Text14")
                            textobj144.Text = "PURCHASE BILL"
                        End If
                        Dim textobj199 As TextObject
                        textobj199 = r.ReportDefinition.ReportObjects("Text21")

                        Dim textobj26 As TextObject
                        textobj26 = r.ReportDefinition.ReportObjects("Text26")

                        Dim textobj44 As TextObject
                        textobj44 = r.ReportDefinition.ReportObjects("Text44")

                        If UCase(gShortname) = "KBA" Then
                            Dim I As Integer
                            sql = "select DISTINCT TAXGROUPCODE from VW_INV_GRNBILL WHERE GRNDETAILS='" + GRNNO + "'  "
                            'End If
                            gconnection.getDataSet(sql, "TAXGROUPCODE")
                            If gdataset.Tables("TAXGROUPCODE").Rows.Count > 0 Then
                                sql = ""
                                For I = 0 To gdataset.Tables("TAXGROUPCODE").Rows.Count - 1
                                    ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                                    sql = sql & " " & Trim(gdataset.Tables("TAXGROUPCODE").Rows(I).Item("TAXGROUPCODE")) & " ,"
                                Next
                            End If

                            sql = Mid(sql, 1, Len(sql) - 2)

                            textobj199.Text = sql + "  :"

                            textobj26.Text = "Section Incharge  1                                                                                                                                                  Accounts"
                            textobj44.Text = "Section Incharge  2                                              "
                        Else
                            If UCase(gShortname) = "KEA" Then
                                textobj26.Text = "Bar Chairman                                          Office Manager                                     Treasurer                                             Hon. Secretary"
                            End If
                            textobj199.Text = "VAT AMOUNT :"
                        End If

                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text28")
                        textobj3.Text = ""
                        ' End If
                        rViewer.Show()
                        rViewer.Refresh()


                        If viewprint = True Then

                            r.PrintToPrinter(1, False, 0, 0)
                            rViewer.Visible = False
                            viewprint = False
                        End If
                        'End If
                    Else
                        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                    End If
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
        Dim result As DialogResult = MessageBox.Show("ARE YOU SURE WANT TO FREEZE THIS RECORD?", gcompname, MessageBoxButtons.YesNo)

        If result = DialogResult.No Then
            Exit Sub

        End If


        If validateonvoid() = False Then
            voidoperation()
            Dim ITEMCODE As String
            Dim I As Integer
            Dim items As String

            Dim dtitem As New DataTable
            dtitem.Columns.Add("itemcode")
            dtitem.TableName = "TpItems"

            items = ""
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

            If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, txt_Grnno.Text, "GRN")

            Else
                strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Grndate.Value, "dd MMM yyyy"), items, dtitem, Trim(txt_Storecode.Text), "Q", vOutfile, loccode, txt_Grnno.Text, "GRN")
                sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                gconnection.ExcuteStoreProcedure(sqlstring)

            End If


            sqlstring = " exec proc_closingqtyone 'GRN_VOID' "
            gconnection.ExcuteStoreProcedure(sqlstring)



            UpdateProfitItems()

            clearoperation()


        End If
    End Sub

    Private Sub CMB_CATEGORY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_CATEGORY.SelectedIndexChanged
        'autogenerate()
        GetLastNo()
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

                    If Trim(UCase(gShortname)) = "KBA" Or Trim(UCase(gShortname)) = "NIZAM" Or Trim(UCase(gShortname)) = "FNCC" Then
                        autogenerate()
                    End If

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
                txt_Storecode.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Suppliercode_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub




    Private Sub CmbGrnType_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbGrnType.SelectedValueChanged
        If CmbGrnType.SelectedItem = "SPONSOR" Then

            clearoperation1()
            Label4.Hide()
            Txt_PONo.Hide()
            cmd_PONOhelp.Hide()
            GridUnLock()
            bindcategory()

            ' If gAcPostingWise <> "STORE" Then
            For RW As Integer = 1 To 100
                AxfpSpread1.Col = 19
                AxfpSpread1.ColHidden = False
            Next

            'End If
            'LBL_SPONSOR.Show()
            'TXT_Sponsor.Show()
            'cmd_SPONhelp.Show()
        ElseIf CmbGrnType.SelectedItem = "DIRECT GRN" Then
            For RW As Integer = 1 To 100
                AxfpSpread1.Col = 19
                AxfpSpread1.ColHidden = True
            Next

            clearoperation1()
            LBL_SPONSOR.Hide()
            TXT_Sponsor.Hide()
            cmd_SPONhelp.Hide()
            Label4.Hide()
            Txt_PONo.Hide()
            cmd_PONOhelp.Hide()
        ElseIf CmbGrnType.SelectedItem = "DO" Or CmbGrnType.Text = "DO" Then
            clearoperation1()
            LBL_SPONSOR.Hide()
            TXT_Sponsor.Hide()
            cmd_SPONhelp.Hide()

            Label4.Text = "DO NO."
            Label4.Show()

            Txt_PONo.Show()
            cmd_PONOhelp.Show()

        Else

            Label4.Text = "PO NO."
            'AxfpSpread1.Row = 1
            'AxfpSpread1.Col = 19
            'If AxfpSpread1.ColHidden = False Then
            '    For RW As Integer = 1 To 100

            '        AxfpSpread1.Col = 19
            '        AxfpSpread1.ColHidden = True
            '    Next
            'End If
            clearoperation1()
            LBL_SPONSOR.Hide()
            TXT_Sponsor.Hide()
            cmd_SPONhelp.Hide()

            Label4.Show()
            Txt_PONo.Show()
            cmd_PONOhelp.Show()
        End If
    End Sub



    Private Sub cmd_SPONhelp_Click(sender As Object, e As EventArgs) Handles cmd_SPONhelp.Click

        gSQLString = "SELECT ISNULL(SPONSORCODE,'') AS SPONSORCODE,ISNULL(SPONSORDESC,'') AS SPONSORDESC FROM INV_SPONSORMASTER"
        M_WhereCondition = ""
        Dim vform As New ListOperattion1

        vform.Field = "SPONSORDESC,SPONSORCODE"
        vform.vFormatstring = "         SPONSOR CODE              |                  SPONSOR DESCRIPTION                                                                                              "
        vform.vCaption = "SPONSOR MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_Sponsor.Text = Trim(vform.keyfield & "")
            Call txt_GroupCode_Validated(TXT_Sponsor, e)
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


            sql = "SELECT * FROM vW_iNV_TAX_TYPE  where taxgroupcode='" & AxfpSpread1.Text & "'"
            gconnection.getDataSet(sql, "vW_iNV_TAX_TYPE")
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
    Private Sub txt_GroupCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_Sponsor.Validated
        If Trim(TXT_Sponsor.Text) <> "" Then
            Dim sqlstring As String = "SELECT isnull(SPONSORcode,'') as SPONSORcode,isnull(SPONSORdesc,'') as SPONSORdesc,isnull(freeze,'') as freeze,isnull(adddate,'') as adddate FROM inv_SPONSORmaster WHERE SPONSORcode='" & Trim(TXT_Sponsor.Text) & "'"
            gconnection.getDataSet(sqlstring, "inv_SPONSORmaster")
            If gdataset.Tables("inv_SPONSORmaster").Rows.Count > 0 Then
                TXT_Sponsor.Text = Trim(gdataset.Tables("inv_SPONSORmaster").Rows(0).Item("SPONSORcode"))
                CMB_CATEGORY.Focus()
                'txt_SponDesc.Text = Trim(gdataset.Tables("inv_SPONSORmaster").Rows(0).Item("SPONSORdesc"))
                'txt_SponDesc.Focus()
                'txt_SponCode.ReadOnly = True
                'If gdataset.Tables("inv_SPONSORmaster").Rows(0).Item("Freeze") = "Y" Then
                '    Me.lbl_Freeze.Visible = True
                '    Me.lbl_Freeze.Text = ""
                '    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("inv_SPONSORmaster").Rows(0).Item("AddDate")), "dd/MMM/yyyy")
                '    Me.Cmd_Freeze.Text = "UnVoid[F8]"
                '    Me.Cmd_Freeze.Enabled = True
                'Else
                '    Me.lbl_Freeze.Visible = False
                '    Me.lbl_Freeze.Text = "Record Freezed  On "
                '    Me.Cmd_Freeze.Text = "Void[F8]"
                'End If
                'Me.Cmd_Add.Text = "Update[F7]"
            Else
                'Me.lbl_Freeze.Visible = False
                'Me.lbl_Freeze.Text = "Record Freezed  On "
                'Me.Cmd_Add.Text = "Add [F7]"
                'txt_SponCode.ReadOnly = False
                'txt_SponDesc.Focus()
            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Else
            TXT_Sponsor.Text = ""
            TXT_Sponsor.Focus()
        End If
    End Sub


    Private Sub Cmd_Add_Validated(sender As Object, e As EventArgs) Handles Cmd_Add.Validated

    End Sub

    Private Sub TXT_Sponsor_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_Sponsor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TXT_Sponsor.Text <> "" Then
                Call txt_GroupCode_Validated(TXT_Sponsor, e)
            Else
                Call cmd_SPONhelp_Click(TXT_Sponsor.Text, e)
            End If
        End If
    End Sub



    Private Sub TXT_OVERALLdiscount_Validated(sender As Object, e As EventArgs) Handles TXT_OVERALLdiscount.Validated
        If Val(TXT_OVERALLdiscount.Text) > Val(txt_Billamount.Text) Then

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        viewprint = True
        Call Cmd_View_Click(txt_Grnno.Text, e)
    End Sub

    Private Sub txt_RoundUP_TextChanged(sender As Object, e As EventArgs) Handles txt_RoundUP.TextChanged
        '        If calcbool = False Then
        CALCULATE()
        'End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim objStockSummary1 As New GRN_RATE_CHECK
        objStockSummary1.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim ServerConn As New OleDb.OleDbConnection
        Dim servercmd As New OleDb.OleDbDataAdapter
        Dim getserver As New DataSet
        Dim sql, ssql, UOM As String
        Dim ABC As Double
        sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
        sql = sql & AppPath & "\weights.MDB"
        ServerConn.ConnectionString = sql
        Try
            ServerConn.Open()
            'Mk Kannan
            'Begin
            'UserName and Password is Added on 06 Oct'07
            ssql = "SELECT WEIGHT FROM CurrWeight"
            'End
            servercmd = New OleDb.OleDbDataAdapter(ssql, ServerConn)
            servercmd.Fill(getserver)
            If getserver.Tables(0).Rows.Count > 0 Then
                ABC = (Val(getserver.Tables(0).Rows(0).Item("WEIGHT")))
                Me.AxfpSpread1.Col = 3
                UOM = Me.AxfpSpread1.Text
                If UOM <> "" Then
                    If Mid(UOM, 1, 2).ToString().ToUpper() = "KG" Then
                        Me.AxfpSpread1.Col = 4
                        Me.AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        Me.AxfpSpread1.Text = Format(ABC, "0.000")
                        Me.AxfpSpread1.Lock = True
                        Me.AxfpSpread1.Col = 5
                        Me.AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Focus()
                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Failed to connect to data source")
            MsgBox(ex.Message)
        Finally
            ServerConn.Close()
        End Try

    End Sub



    Private Sub AxfpSpread1_LeaveCell(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread1.LeaveCell
        AxfpSpread1.Row = AxfpSpread1.ActiveRow
        AxfpSpread1.Col = AxfpSpread1.ActiveCol
        If AxfpSpread1.Col = 10 Then
            If AxfpSpread1.Text <> "" Then
                Dim taxgroupcode As String = AxfpSpread1.Text
                AxfpSpread1.Col = 11
                Dim taxper As Double = Val(AxfpSpread1.Text)
                sql = "select ISNULL(sum(taxper),0)  as taxper from invtaxgroupmasterdetail where taxgroupcode='" + taxgroupcode + "' and ISNULL(void,'')<>'Y'"
                gconnection.getDataSet(sql, "invtaxgroupmasterdetail")
                If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then
                    If (Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(0).Item("taxper")) <> taxper) Then
                        MessageBox.Show("Taxgroupcode and tax per. not matching ! ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.Col = 11
                        AxfpSpread1.Text = ""
                        AxfpSpread1.Col = 10
                        AxfpSpread1.Text = ""
                        Call CALCULATE()
                        AxfpSpread1.SetActiveCell(11, AxfpSpread1.ActiveRow)
                    End If
                End If


            End If
        ElseIf AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Then
            CALCULATE()
        End If
    End Sub



    Private Sub ChkSupplier_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSupplier.CheckedChanged
        Dim i As Integer = 0
        If (ChkSupplier.Checked = True) Then
            For i = 0 To CHKLST_SUPPLIERS.Items.Count - 1
                CHKLST_SUPPLIERS.SetItemChecked(i, True)
                Call SUPPLIER()
            Next

        Else
            For i = 0 To CHKLST_SUPPLIERS.Items.Count - 1
                CHKLST_SUPPLIERS.SetItemChecked(i, False)
                Call SUPPLIER()
            Next

        End If

    End Sub

    Private Sub CHKGRN_CheckedChanged(sender As Object, e As EventArgs) Handles CHKGRN.CheckedChanged
        Dim i As Integer = 0
        If (CHKGRN.Checked = True) Then
            For i = 0 To CHKLST_GRNS.Items.Count - 1
                CHKLST_GRNS.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CHKLST_GRNS.Items.Count - 1
                CHKLST_GRNS.SetItemChecked(i, False)
            Next

        End If

    End Sub
    Private Sub Fillsuppliername()
        Dim i As Integer
        CHKLST_SUPPLIERS.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(SLCODE,'') AS SLCODE,ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER  WHERE SLCODE IN(select distinct suppliercode from grn_header where isnull(void,'')<>'Y') ORDER BY SLCODE"
        gconnection.getDataSet(sqlstring, "SUBLEDGERMASTER")
        If gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1
                With gdataset.Tables("SUBLEDGERMASTER").Rows(i)
                    CHKLST_SUPPLIERS.Items.Add(Trim(.Item("SLNAME")))
                End With
            Next i
        End If
    End Sub
    Private Sub FILLGRNDETAILS()
        Dim I As Integer
        CHKLST_GRNS.Items.Clear()
        sqlstring = "SELECT DISTINCT GRNDETAILS FROM GRN_DETAILS WHERE GRNDETAILS IN (SELECT DISTINCT GRNDETAILS FROM GRN_HEADER WHERE ISNULL(VOID,'')<>'Y') ORDER BY GRNDETAILS"
        gconnection.getDataSet(sqlstring, "GRN_DETAILS")
        If gdataset.Tables("GRN_DETAILS").Rows.Count - 1 >= 0 Then
            For I = 0 To gdataset.Tables("GRN_DETAILS").Rows.Count - 1
                With gdataset.Tables("GRN_DETAILS").Rows(I)
                    CHKLST_GRNS.Items.Add(Trim(.Item("GRNDETAILS")))
                End With
            Next I
        End If
    End Sub

    Private Sub BTN_GRNDET_Click_1(sender As Object, e As EventArgs) Handles BTN_GRNDET.Click
        GroupBox8.Visible = False
        GroupBox9.Visible = False
        GRP_GRNDET.Visible = True
        btn_view.Visible = False
    End Sub

    Private Sub BTN_EXIT_Click(sender As Object, e As EventArgs) Handles BTN_EXIT.Click
        Me.Close()
    End Sub


    Private Sub CHKLST_SUPPLIERS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CHKLST_SUPPLIERS.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = " SELECT DISTINCT GRNDETAILS FROM GRN_DETAILS  "
        sqlstring = sqlstring & " WHERE SUPPLIERNAME IN ("

        For J = 0 To CHKLST_SUPPLIERS.CheckedItems.Count - 1
            If J = CHKLST_SUPPLIERS.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CHKLST_SUPPLIERS.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CHKLST_SUPPLIERS.CheckedItems(J) & "', "
            End If
        Next

        If CHKLST_SUPPLIERS.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") AND  CAST(CONVERT(VARCHAR(11),GRNDATE,106)AS DATETIME)  BETWEEN  '" + Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") + "'  AND  '" + Format(DTP_TODATE.Value, "dd/MMM/yyyy") + "'  ORDER BY GRNDETAILS "
            gconnection.getDataSet(sqlstring, "GRN_DETAILS")
            If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
                CHKLST_GRNS.Items.Clear()
                For i = 0 To gdataset.Tables("GRN_DETAILS").Rows.Count - 1
                    With gdataset.Tables("GRN_DETAILS").Rows(i)
                        ''  CHKLST_GROUPDETAILS.Items.Add(Trim(.Item("groupdesc")))
                        CHKLST_GRNS.Items.Add(Trim(.Item("GRNDETAILS")))
                    End With
                Next i
            End If
        Else
            CHKLST_GRNS.Items.Clear()
        End If
    End Sub
    Private Sub SUPPLIER()
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = " SELECT DISTINCT GRNDETAILS FROM GRN_DETAILS "
        sqlstring = sqlstring & " WHERE SUPPLIERNAME IN ("

        For J = 0 To CHKLST_SUPPLIERS.CheckedItems.Count - 1
            If J = CHKLST_SUPPLIERS.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & CHKLST_SUPPLIERS.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & CHKLST_SUPPLIERS.CheckedItems(J) & "', "
            End If
        Next
        If CHKLST_SUPPLIERS.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY GRNDETAILS "
            gconnection.getDataSet(sqlstring, "GRN_DETAILS")
            If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
                CHKLST_GRNS.Items.Clear()
                For i = 0 To gdataset.Tables("GRN_DETAILS").Rows.Count - 1
                    With gdataset.Tables("GRN_DETAILS").Rows(i)
                        ''  CHKLST_GROUPDETAILS.Items.Add(Trim(.Item("groupdesc")))
                        CHKLST_GRNS.Items.Add(Trim(.Item("GRNDETAILS")))
                    End With
                Next i
            End If
        Else
            CHKLST_GRNS.Items.Clear()
        End If
    End Sub

    Private Sub view_grn_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_view_Click(sender As Object, e As EventArgs) Handles btn_view.Click

        Dim SQL, GRNNO, GRNDATE As String
        Dim I, J As Integer
        For J = 0 To CHKLST_GRNS.CheckedItems.Count - 1

            GRNNO = CHKLST_GRNS.CheckedItems(J)
            sqlstring = "SELECT GRNDATE FROM GRN_DETAILS WHERE GRNDETAILS=('" & GRNNO & "')"
            gconnection.getDataSet(sqlstring, "GRN_DETAILS")
            If gdataset.Tables("GRN_DETAILS").Rows.Count - 1 Then
                With gdataset.Tables("GRN_DETAILS").Rows(I)
                    GRNDATE = .Item("GRNDATE")
                End With
            End If

            Call GRNPRINTVIEW(GRNNO, Format(CDate(GRNDATE), "dd/MMM/yyyy"))
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim rViewer As New Viewer
        Dim sqlstring, SSQL, addr, GRNDETAILSSS As String
        Dim J As Integer

        If CHKLST_GRNS.CheckedItems.Count > 0 Then
            For J = 0 To CHKLST_GRNS.CheckedItems.Count - 1
                ' gd = Split(CHKLST_GRNS.CheckedItems(I), "-->")
                '   GRNDETAILSSS = CHKLST_GRNS.CheckedItems(J)
                GRNDETAILSSS = GRNDETAILSSS & " '" & CHKLST_GRNS.CheckedItems(J) & "', "
            Next
            GRNDETAILSSS = Mid(GRNDETAILSSS, 1, Len(GRNDETAILSSS) - 2)
        Else
            MsgBox("please select SUBgroup details", vbInformation)
        End If

        Dim r As New Rpt_GrnBillGSTNEW_NW
        sqlstring = "SELECT ISNULL(PONO,'') AS PONO, ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE, ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,"
        sqlstring = sqlstring & " ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO, "
        sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,"
        sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE, ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM, ISNULL(QTY,0) AS QTY, ISNULL(RATE,0) AS RATE,ISNULL(REMARKS,'') AS REMARKS, "
        sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(discount,0) as ddiscount,isnull(taxper,0) as taxper,isnull(taxamount,0) as taxamount, isnull(OverallDiscount,0) OverallDiscount,ISNULL(Adddate,'') AS ADDDATE,isnull(RoundupAmt,0) as RoundupAmt,ISNULL(IGSTAmt,0) AS IGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(CGSTAmt,0) AS CGSTAmt ,ISNULL(contactperson,'') AS contactperson,ISNULL(address1,'') AS address1,ISNULL(address2,'') AS address2,  ISNULL(city,'') AS city,ISNULL(state,'') AS state,ISNULL(PIN,'') AS pIN , ISNULL(phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE ,ISNULL(HSNNO,'') AS HSNNO,ISNULL(TAXTYPE,'') AS  TAXTYPE "
        sqlstring = sqlstring & " FROM VW_INV_GRNBILL "
        'sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(GRNno) & "' AND '" & Trim(GRNno) & "'"
        sqlstring = sqlstring & " WHERE    CAST(CONVERT(VARCHAR(11),GRNDATE,106)AS DATETIME)  BETWEEN  '" + Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") + "' "
        sqlstring = sqlstring & " AND  '" + Format(DTP_TODATE.Value, "dd/MMM/yyyy") + "'   AND  GRNDETAILS IN (" & GRNDETAILSSS & ")  "


        sqlstring = sqlstring & " GROUP BY pono,GRNDETAILS,GRNDATE,SUPPLIERCODE,SUPPLIERNAME,SUPPLIERINVNO,EXCISEPASSNO,TOTALAMOUNT,VATAMOUNT,SURCHARGEAMT,DISCOUNT,BILLAMOUNT,ITEMCODE,ITEMNAME,UOM,QTY,RATE,REMARKS,AMOUNT,DDISCOUNT,TAXPER,TAXAMOUNT,OverallDiscount,ADDDATE,RoundupAmt,IGSTAmt,SGSTAmt,CGSTAmt,contactperson,address1,address2,city,state,pIN,phoneno,gstinno,VENDORTYPE,hsnno,TAXTYPE"
        sqlstring = sqlstring & " ORDER BY GRNDETAILS,GRNDATE "
        'End If
        gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL")
        If gdataset.Tables("VW_INV_GRNBILL").Rows.Count > 0 Then
            Dim sqlstring1 As String
            sqlstring1 = "SELECT * FROM vW_GRN_DET WHERE GRNDETAILS IN (SELECT  GRNDETAILS  FROM GRN_DETAILS  WHERE   CAST(CONVERT(VARCHAR(11),GRNDATE,106)AS DATETIME)  BETWEEN  '" + Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") + "'  AND  '" + Format(DTP_TODATE.Value, "dd/MMM/yyyy") + "'  ) "
            sqlstring1 = sqlstring1 & " AND   GRNDETAILS IN (" & GRNDETAILSSS & ")  group by GRNDETAILS,COLDESC ,TOTALAMOUNT ,ORD ORDER BY  GRNDETAILS,ORD , TOTALAMOUNT"
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
            textobj14.Text = UCase(Address1)
            Dim textobj16 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text33")
            textobj1.Text = UCase(Address2) + " , " + UCase(gCity)
            Dim textobj18 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text35")
            textobj1.Text = gFinancalyearStart + " - " + gFinancialyearEnd

            Dim textobj2 As TextObject
            textobj2 = r.ReportDefinition.ReportObjects("Text30")
            textobj2.Text = gUsername
            Dim textobj188 As TextObject
            textobj188 = r.ReportDefinition.ReportObjects("Text18")
            If UCase(gShortname) = "KBA" Then

                textobj188.Text = "GST/TCS"
            Else
                textobj188.Text = "GST%"
            End If


            If UCase(gShortname) = "SATC" Then
                Dim textobj144 As TextObject
                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                textobj144.Text = "GRN CUM PURCHASE BILL"
            ElseIf UCase(gShortname) = "KEA" Or UCase(gShortname) = "KBA" Or UCase(gShortname) = "CATH" Then
                Dim textobj144 As TextObject
                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                textobj144.Text = "GOODS RECEIPT NOTE"
            Else
                Dim textobj144 As TextObject
                textobj144 = r.ReportDefinition.ReportObjects("Text14")
                textobj144.Text = "PURCHASE BILL"
            End If
            'Dim textobj199 As TextObject
            ' textobj199 = r.ReportDefinition.ReportObjects("Text21")

            Dim textobj26 As TextObject
            textobj26 = r.ReportDefinition.ReportObjects("Text26")

            If UCase(gShortname) = "KBA" Then
                Dim I As Integer
                sql = "select DISTINCT TAXGROUPCODE from VW_INV_GRNBILL   "
                'End If
                gconnection.getDataSet(sql, "TAXGROUPCODE")
                If gdataset.Tables("TAXGROUPCODE").Rows.Count > 0 Then
                    sql = ""
                    For I = 0 To gdataset.Tables("TAXGROUPCODE").Rows.Count - 1
                        ' STORECODE = Split(CheckedListBox2.CheckedItems(i), "-")
                        sql = sql & " " & Trim(gdataset.Tables("TAXGROUPCODE").Rows(I).Item("TAXGROUPCODE")) & " ,"
                    Next
                End If

                sql = Mid(sql, 1, Len(sql) - 2)

                '  textobj199.Text = sql + "  :"

                textobj26.Text = "           Section Incharge      I.                                                                                                  Accounts: "
            Else

                Dim textobj21 As TextObject
                textobj21 = r.ReportDefinition.ReportObjects("Text21")
                textobj21.Text = ""

                If UCase(gShortname) = "KEA" Then
                    textobj26.Text = "Bar Chairman                                          Office Manager                                     Treasurer                                             Hon. Secretary"
                End If
                If UCase(gShortname) = "DGC" Then
                    textobj26.Text = "Store Keeper                                                              Asst. Manager                                                                       Asst. Secretary"
                End If
                If UCase(gShortname) = "HGA" Then
                    textobj26.Text = "Store Keeper                                                               Manager                "
                End If
            End If

            Dim textobj3 As TextObject
            textobj3 = r.ReportDefinition.ReportObjects("Text28")
            textobj3.Text = ""
            ' End If
            rViewer.Show()
            rViewer.Refresh()


            If viewprint = True Then

                r.PrintToPrinter(1, False, 0, 0)
                rViewer.Visible = False
                viewprint = False
            End If
            'End If
        Else
            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        End If
    End Sub

    Private Sub TXT_Sponsor_TextChanged(sender As Object, e As EventArgs) Handles TXT_Sponsor.TextChanged

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Txt_GLAcIn_Validated(sender As Object, e As EventArgs) Handles Txt_GLAcIn.Validated

    End Sub

    Private Sub GRP_HSN_Enter(sender As Object, e As EventArgs) Handles GRP_HSN.Enter

    End Sub

    Private Sub dtp_Grndate_ValueChanged(sender As Object, e As EventArgs) Handles dtp_Grndate.ValueChanged
    End Sub

    Private Sub lbl_Freeze_Click(sender As Object, e As EventArgs) Handles lbl_Freeze.Click

    End Sub

    Private Sub GRP_GRNDET_Enter(sender As Object, e As EventArgs) Handles GRP_GRNDET.Enter

    End Sub

    Private Sub Cmd_GLAcHelp_Click(sender As Object, e As EventArgs) Handles Cmd_GLAcHelp.Click
        Try
            Dim vform As New ListOperattion1
            gSQLString = "SELECT accode,acdesc FROM accountsglaccountmaster"
            M_WhereCondition = ""
            vform.Field = "ACDESC,ACCODE"
            vform.vFormatstring = "  ACCODE                              |                      ACDESC                                                                                                     "
            vform.vCaption = "GLACCOUNT MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_GLAcIn.Text = Trim(vform.keyfield & "")
                Txt_GLAcDesc.Text = Trim(vform.keyfield1 & "")
                Call Glaccountvalidate()
            Else
                Me.Txt_GLAcIn.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_GLAcHelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Glaccountvalidate()
        Try
            Dim sqlstring As String
            If Trim(Txt_GLAcIn.Text) <> "" Then
                sqlstring = "SELECT slcode,slname FROM accountssubledgermaster WHERE accode = '" & Trim(Txt_GLAcIn.Text) & "'"
                gconnection.getDataSet(sqlstring, "accountssubledgermaster")
                If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
                    Lbl_SubledgerCode.Visible = True
                    Lbl_SubledgerName.Visible = True
                    Txt_Slcode.Visible = True
                    Cmd_SlCodeHelp.Visible = True
                    Txt_SlDesc.Visible = True
                    slcodestatus = True
                    'grp_grnposting.Top = 218
                    'grp_grnposting.Height = 80
                    'AxfpSpread1.Left = 10
                    'AxfpSpread1.Top = 272
                    'AxfpSpread1.Height = 224
                    Txt_Slcode.Focus()
                Else
                    Lbl_SubledgerCode.Visible = False
                    Lbl_SubledgerName.Visible = False
                    Txt_Slcode.Visible = False
                    Cmd_SlCodeHelp.Visible = False
                    Txt_SlDesc.Visible = False
                    slcodestatus = False
                    'grp_grnposting.Top = 218
                    'grp_grnposting.Height = 48
                    'grp_grnposting.Width = 848
                    'AxfpSpread1.Top = 272
                    'AxfpSpread1.Left = 10
                    'AxfpSpread1.Height = 250
                    'AxfpSpread1.Focus()
                    'Txt_CostCenterCode.Focus()
                End If
                gdataset.Tables("accountssubledgermaster").Dispose()
                Call Costcentervalidate()
            Else
                Txt_GLAcIn.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Glaccountvalidate" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Costcentervalidate()
        'Try
        '    Dim SQLSTRING As String
        '    Dim DR As DataRow
        '    Dim i As Integer
        '    If Trim(Txt_GLAcIn.Text) <> "" Then
        '        SQLSTRING = "SELECT PRIMARYGROUPCODE FROM ACCOUNTTAGGING WHERE GLACCODE = '" & Trim(Txt_GLAcIn.Text) & "'"
        '        gconnection.getDataSet(SQLSTRING, "MASTER1")
        '        If gdataset.Tables("MASTER1").Rows.Count > 0 Then
        '            Lbl_CostCenterCode.Visible = True
        '            Lbl_CostCenterDesc.Visible = True
        '            Txt_CostCenterCode.Visible = True
        '            Txt_CostCenterDesc.Visible = True
        '            Cmd_CostCenterCodeHelp.Visible = True
        '            costcentercodestatus = True
        '            'grp_grnposting.Top = 218
        '            'grp_grnposting.Width = 848
        '            'grp_grnposting.Height = 120
        '            'AxfpSpread1.Top = 344
        '            'AxfpSpread1.Left = 10
        '            'AxfpSpread1.Height = 195
        '            'lbl_Creditdays.Top = 280
        '            'lbl_Creditdays.Left = 504
        '            'txt_Creditdays.Top = 280
        '            'txt_Creditdays.Left = 672
        '            Gr = Nothing
        '            For Each DR In gdataset.Tables("MASTER1").Rows
        '                If Trim(Gr) = "" Then
        '                    Gr = "'" & Trim(DR("PRIMARYGROUPCODE")) & "'"
        '                Else
        '                    Gr = Gr & ",'" & Trim(DR("PRIMARYGROUPCODE")) & "'"
        '                End If
        '            Next
        '        Else
        '            Lbl_CostCenterCode.Visible = False
        '            Lbl_CostCenterDesc.Visible = False
        '            Txt_CostCenterCode.Visible = False
        '            Txt_CostCenterDesc.Visible = False
        '            Cmd_CostCenterCodeHelp.Visible = False
        '            costcentercodestatus = False
        '            If slcodestatus = True Then
        '                'grp_grnposting.Top = 218
        '                'grp_grnposting.Height = 80
        '                'AxfpSpread1.Left = 65
        '                'AxfpSpread1.Top = 272
        '                'AxfpSpread1.Height = 215
        '                Txt_Slcode.Focus()
        '            Else
        '                'grp_grnposting.Height = 48
        '                'grp_grnposting.Width = 848
        '                'AxfpSpread1.Top = 272
        '                'AxfpSpread1.Left = 10
        '                'AxfpSpread1.Height = 255
        '                'AxfpSpread1.Focus()
        '            End If
        '        End If
        '    Else
        '        Txt_GLAcIn.Focus()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Plz Check Error : Costcentervalidate" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End Try
    End Sub
    Public Function NewAccountPosting_OUTR(ByVal Type As String, ByVal Docdetails As String)
        Dim SQLS, sqlstring, itemc As String
        Try

            Type = "GRN"

            sqlstring = " DELETE FROM INV_JV"
            gconnection4BGP.ExcuteStoreProcedure(sqlstring)


            sqlstring = " DELETE FROM INV_JV2"
            gconnection4BGP.ExcuteStoreProcedure(sqlstring)

            sqlstring = " DELETE FROM INV_JV3"
            gconnection4BGP.ExcuteStoreProcedure(sqlstring)

            sqlstring = " DELETE FROM INV_JV4"
            gconnection4BGP.ExcuteStoreProcedure(sqlstring)

            If Type = "GRN" Then

                sqlstring = "UPDATE Grn_details SET ITEM_TYPE  = 'YES' WHERE ITEM_TYPE IS NULL AND Itemcode IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem)"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = "UPDATE Grn_details SET ITEM_TYPE  = 'NO' WHERE ISNULL(ITEM_TYPE,'')='' AND Itemcode NOT  IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem)"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                If Mid(UCase(gShortname), 1, 3) = "BRC" Then

                    sqlstring = "UPDATE GRN_HEADER SET TOTALQTY =( SELECT SUM(QTY) FROM Grn_details WHERE ISNULL(VOIDITEM,'N')<>'Y' AND GRN_HEADER.Grndetails=Grn_details.Grndetails) "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                End If

                sqlstring = "UPDATE Grn_details SET supplierinvno  = g.supplierinvno from grn_header g where grn_details.grndetails=g.grndetails"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = "UPDATE Grn_details SET VENDOR_TYPE=VENDORTYPE FROM SUPPLIERDETAILS S, Grn_details G WHERE S.vendorcode=G.Suppliercode AND G.grndetails='" & Docdetails & "' "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = "UPDATE Grn_details SET TAX_TYPE=TAXTYPE,ITEM_TYPE=TaxRebate FROM INV_InventoryItemMaster S, Grn_details G WHERE S.itemcode=G.Itemcode AND G.grndetails='" & Docdetails & "' "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)




                '' wHICH TAX REBATE IS YES AND TAXCODE IS NONE
                sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'ITEM',grndetails,grndate,Itemcode,storecode,category ,amountafterdiscount FROM Grn_details  where isnull( Voiditem,'N')<>'Y' AND ISNULL(taxcode,'')='NONE' AND isnull(ITEM_TYPE,'NO')='YES' AND  GRNDETAILS='" + Docdetails + "'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                '' wHICH TAX REBATE IS NO AND TAXCODE IS NONE
                sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'ITEM',grndetails,grndate,Itemcode,storecode,category ,AMOUNT-ISNULL(SPLCESS,0) FROM Grn_details  where isnull( Voiditem,'N')<>'Y' AND ISNULL(taxcode,'')='NONE' AND isnull(ITEM_TYPE,'NO')='NO' AND  GRNDETAILS='" + Docdetails + "'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'SPL',grndetails,grndate,Itemcode,storecode,category ,ISNULL(SPLCESS,0) FROM Grn_details  where isnull( Voiditem,'N')<>'Y' and  GRNDETAILS='" + Docdetails + "' and isnull(splcess,0)<>0 AND isnull(ITEM_TYPE,'NO')='YES'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                If UCase(gShortname) = "BRC" Then
                    '' wHICH TAX REBATE IS YES AND TAXCODE IS NOT NONE
                    sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'ITEM',grndetails,grndate,Itemcode,storecode ,category ,amountafterdiscount FROM Grn_details  where isnull( Voiditem,'N')<>'Y' AND isnull(ITEM_TYPE,'NO')='YES' AND  GRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                Else
                    '' wHICH TAX REBATE IS YES AND TAXCODE IS NOT NONE
                    sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'ITEM',grndetails,grndate,Itemcode,storecode ,category ,amountafterdiscount FROM Grn_details  where isnull( Voiditem,'N')<>'Y' AND ISNULL(taxcode,'')<>'NONE' AND isnull(ITEM_TYPE,'NO')='YES' AND  GRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If

                'If check_VendorTypeRU("", "", Docdetails) Then

                'End If


                '' wHICH TAX REBATE IS NO AND TAXCODE IS NOT NONE
                sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'ITEM',grndetails,grndate,Itemcode,storecode ,category ,AMOUNT-ISNULL(SPLCESS,0) FROM Grn_details  where isnull( Voiditem,'N')<>'Y' AND ISNULL(taxcode,'')<>'NONE' AND isnull(ITEM_TYPE,'NO')='NO' AND  GRNDETAILS='" + Docdetails + "' "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                '                                                                                                                                                                      AMOUNT-ISNULL(SPLCESS,0)                                    
                'sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'ITEM',grndetails,grndate,Itemcode,storecode ,category ,amountafterdiscount FROM Grn_details  where isnull( Voiditem,'N')<>'Y' AND ISNULL(taxcode,'')<>'NONE' AND Itemcode  NOT IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem) AND  GRNDETAILS='" + Docdetails + "' AND grndetails IN (SELECT grndetails FROM   VW_INV_GRNBILL WHERE VENDORTYPE='UNREGISTERED')"
                'gconnection.ExcuteStoreProcedure(sqlstring)


                ''TAX ENTRY

                ''INSERT TAX AMOUNT WHICH TAX CODE IS NONE AND ITEM IN TAXREBATE YES
                If UCase(gShortname) = "BRC" Then
                    sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'TAX',grndetails,grndate,Tax,storecode ,category ,(taxamount*T.taxper)/G.taxper FROM Grn_details G INNER JOIN invtaxgroupmasterdetail T ON G.taxcode=T.taxgroupcode  where isnull( Voiditem,'N')<>'Y' AND  g.taxper<>0  AND T.taxper<>0 AND ISNULL(T.VOID,'N')<>'Y' AND Itemcode  IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem) AND  GRNDETAILS='" + Docdetails + "'"
                    gconnection.ExcuteStoreProcedure(sqlstring)

                    sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'TAX',grndetails,grndate,Tax,storecode ,category ,(taxamount*T.taxper)/G.taxper FROM Grn_details G INNER JOIN invtaxgroupmasterdetail T ON G.taxcode=T.taxgroupcode  where isnull( Voiditem,'N')<>'Y' AND ISNULL(G.taxcode,'')='NONE' AND T.taxper<>0 AND ISNULL(T.VOID,'N')<>'Y' AND isnull(ITEM_TYPE,'NO')='YES' AND  GRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                Else
                    sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'TAX',grndetails,grndate,Tax,storecode ,category ,(taxamount*T.taxper)/G.taxper FROM Grn_details G INNER JOIN invtaxgroupmasterdetail T ON G.taxcode=T.taxgroupcode  where isnull( Voiditem,'N')<>'Y' AND ISNULL(G.taxcode,'')='NONE' AND T.taxper<>0 AND ISNULL(T.VOID,'N')<>'Y' AND isnull(ITEM_TYPE,'NO')='YES' AND  GRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'TAX',grndetails,grndate,TAX,storecode ,category ,(taxamount*T.taxper)/G.taxper FROM Grn_details G INNER JOIN invtaxgroupmasterdetail T ON G.taxcode=T.taxgroupcode  where isnull( Voiditem,'N')<>'Y' AND ISNULL(G.taxcode,'')<>'NONE' AND T.taxper<>0 AND ISNULL(T.VOID,'N')<>'Y' AND isnull(ITEM_TYPE,'NO')='YES' AND  GRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If


                ''INSERT TAX AMOUNT WHICH TAX CODE IS NOT NONE AND ITEM IN TAXREBATE NO
                '' ''sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'TAX',grndetails,grndate,Tax,storecode ,category ,(taxamount*T.taxper)/G.taxper FROM Grn_details G INNER JOIN invtaxgroupmasterdetail T ON G.taxcode=T.taxgroupcode  where isnull( Voiditem,'N')<>'Y' AND ISNULL(G.taxcode,'')<>'NONE' AND T.taxper<>0 AND ISNULL(T.VOID,'N')<>'Y' AND isnull(ITEM_TYPE,'NO')='NO' AND  GRNDETAILS='" + Docdetails + "'"
                '' ''gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                ' ''INSERT TAX AMOUNT WHICH TAX CODE IS NOT NONE AND ITEM IN TAXREBATE YES
                ''sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'TAX',grndetails,grndate,TAX,storecode ,category ,(taxamount*T.taxper)/G.taxper FROM Grn_details G INNER JOIN invtaxgroupmasterdetail T ON G.taxcode=T.taxgroupcode  where isnull( Voiditem,'N')<>'Y' AND ISNULL(G.taxcode,'')<>'NONE' AND T.taxper<>0 AND ISNULL(T.VOID,'N')<>'Y' AND isnull(ITEM_TYPE,'NO')='YES' AND  GRNDETAILS='" + Docdetails + "'"
                ''gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                ''OVERALL DISCOUNT ENTRY

                ''INSERT DISCOUNT WHICH GRN OVERALL DISCOUNT IS AVILABLE
                sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'DISCOUNT',D.grndetails,D.grndate,Itemcode,D.storecode ,D.category ,(OverallDiscount*QTY)/H.TOTALQTY FROM Grn_details D INNER JOIN GRN_HEADER H  ON D.grndetails=H.Grndetails  where isnull( Voiditem,'N')<>'Y' AND OverallDiscount<>0 AND  D.GRNDETAILS='" + Docdetails + "'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                ''OTHER CHARGES ENTRY

                ''INSERT OTHER CHARGES WHICH GRN OVERALL DISCOUNT IS AVILABLE
                sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'OTHERCHARGE',D.grndetails,D.grndate,Itemcode,D.storecode ,D.category ,((Surchargeamt)*QTY)/h.TOTALQTY FROM Grn_details D INNER JOIN GRN_HEADER H  ON D.grndetails=H.Grndetails  where isnull( Voiditem,'N')<>'Y' AND Surchargeamt<>0  AND  D.GRNDETAILS='" + Docdetails + "'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                If gShortname <> "BRC" Then
                    sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'ROUNDOFF',D.grndetails,D.grndate,Itemcode,D.storecode ,D.category ,ROUNDUPAMT/(select count(*) from Grn_details where GRNDETAILS='" + Docdetails + "' and  isnull( Voiditem,'N')<>'Y' ) FROM Grn_details D INNER JOIN GRN_HEADER H  ON D.grndetails=H.Grndetails  where isnull( Voiditem,'N')<>'Y' AND  ROUNDUPAMT<>0 AND  D.GRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If


            ElseIf Type = "PRN" Then

                sqlstring = "UPDATE Prn_details SET ITEM_TYPE  = 'YES' WHERE ITEM_TYPE IS NULL AND Itemcode IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem)"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = "UPDATE Prn_details SET ITEM_TYPE  = 'NO' WHERE ISNULL(ITEM_TYPE,'')='' AND Itemcode NOT  IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem)"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)


                sqlstring = "UPDATE PRN_HEADER SET TOTALQTY =( SELECT SUM(QTY) FROM Prn_details WHERE PRN_HEADER.Prndetails=Prn_details.Prndetails) "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = "UPDATE Prn_details SET VENDOR_TYPE=VENDORTYPE FROM SUPPLIERDETAILS S, Prn_details G WHERE S.vendorcode=G.Suppliercode AND G.Prndetails='" & Docdetails & "' "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = "UPDATE Prn_details SET TAX_TYPE=TAXTYPE,ITEM_TYPE=TaxRebate FROM INV_InventoryItemMaster S, Prn_details G WHERE S.itemcode=G.Itemcode AND G.Prndetails='" & Docdetails & "' "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)




                '' wHICH TAX REBATE IS YES AND TAXCODE IS NONE
                sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'ITEM',Prndetails,prndate,Itemcode,storecode,category ,amountafterdiscount FROM Prn_details  where isnull( Voiditem,'N')<>'Y' AND ISNULL(taxcode,'')='NONE' AND isnull(ITEM_TYPE,'NO')='YES' AND  PRNDETAILS='" + Docdetails + "'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                '' wHICH TAX REBATE IS NO AND TAXCODE IS NONE
                sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'ITEM',Prndetails,Prndate,Itemcode,storecode,category ,AMOUNT-ISNULL(SPLCESS,0) FROM Prn_details  where isnull( Voiditem,'N')<>'Y' AND ISNULL(taxcode,'')='NONE' AND isnull(ITEM_TYPE,'NO')='NO' AND  PRNDETAILS='" + Docdetails + "'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'SPL',Prndetails,Prndate,Itemcode,storecode,category ,ISNULL(SPLCESS,0) FROM Prn_details  where isnull( Voiditem,'N')<>'Y' and  PRNDETAILS='" + Docdetails + "' and isnull(splcess,0)<>0 AND isnull(ITEM_TYPE,'NO')='NO'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                If UCase(gShortname) = "BRC" Then
                    '' wHICH TAX REBATE IS YES AND TAXCODE IS NOT NONE
                    sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'ITEM',Prndetails,Prndate,Itemcode,storecode ,category ,amountafterdiscount FROM Prn_details  where isnull( Voiditem,'N')<>'Y' AND isnull(ITEM_TYPE,'NO')='YES' AND  PRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                Else
                    '' wHICH TAX REBATE IS YES AND TAXCODE IS NOT NONE
                    sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'ITEM',Prndetails,Prndate,Itemcode,storecode ,category ,amountafterdiscount FROM Prn_details  where isnull( Voiditem,'N')<>'Y' AND ISNULL(taxcode,'')<>'NONE' AND isnull(ITEM_TYPE,'NO')='YES' AND PRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If

                'If check_VendorTypeRU("", "", Docdetails) Then

                'End If


                '' wHICH TAX REBATE IS NO AND TAXCODE IS NOT NONE
                sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'ITEM',Prndetails,Prndate,Itemcode,storecode ,category ,AMOUNT-ISNULL(SPLCESS,0) FROM Prn_details  where isnull( Voiditem,'N')<>'Y' AND ISNULL(taxcode,'')<>'NONE' AND isnull(ITEM_TYPE,'NO')='NO' AND  PRNDETAILS='" + Docdetails + "' "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                '                                                                                                                                                                      AMOUNT-ISNULL(SPLCESS,0)                                    
                'sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'ITEM',grndetails,grndate,Itemcode,storecode ,category ,amountafterdiscount FROM Grn_details  where isnull( Voiditem,'N')<>'Y' AND ISNULL(taxcode,'')<>'NONE' AND Itemcode  NOT IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem) AND  GRNDETAILS='" + Docdetails + "' AND grndetails IN (SELECT grndetails FROM   VW_INV_GRNBILL WHERE VENDORTYPE='UNREGISTERED')"
                'gconnection.ExcuteStoreProcedure(sqlstring)


                ''TAX ENTRY

                ''INSERT TAX AMOUNT WHICH TAX CODE IS NONE AND ITEM IN TAXREBATE YES
                If UCase(gShortname) = "BRC" Then
                    'sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'GRN' ,'TAX',grndetails,grndate,Tax,storecode ,category ,(taxamount*T.taxper)/G.taxper FROM Grn_details G INNER JOIN invtaxgroupmasterdetail T ON G.taxcode=T.taxgroupcode  where isnull( Voiditem,'N')<>'Y' AND  g.taxper<>0  AND T.taxper<>0 AND ISNULL(T.VOID,'N')<>'Y' AND Itemcode  IN (SELECT ITEMCODE FROM Vw_Inv_TaxRebateItem) AND  GRNDETAILS='" + Docdetails + "'"
                    'gconnection.ExcuteStoreProcedure(sqlstring)
                    sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'TAX',Prndetails,Prndate,Tax,storecode ,category ,(taxamount*T.taxper)/G.taxper FROM Prn_details G INNER JOIN invtaxgroupmasterdetail T ON G.taxcode=T.taxgroupcode  where isnull( Voiditem,'N')<>'Y' AND ISNULL(G.taxcode,'')='NONE' AND T.taxper<>0 AND ISNULL(T.VOID,'N')<>'Y' AND isnull(ITEM_TYPE,'NO')='YES' AND  pRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                Else
                    sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'TAX',Prndetails,Prndate,Tax,storecode ,category ,(taxamount*T.taxper)/G.taxper FROM Prn_details G INNER JOIN invtaxgroupmasterdetail T ON G.taxcode=T.taxgroupcode  where isnull( Voiditem,'N')<>'Y' AND ISNULL(G.taxcode,'')='NONE' AND T.taxper<>0 AND ISNULL(T.VOID,'N')<>'Y' AND isnull(ITEM_TYPE,'NO')='YES' AND  pRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If


                ''INSERT TAX AMOUNT WHICH TAX CODE IS NOT NONE AND ITEM IN TAXREBATE NO
                '' ''sqlstring = " INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'TAX',Prndetails,Prndate,Tax,storecode ,category ,(taxamount*T.taxper)/G.taxper FROM prn_details G INNER JOIN invtaxgroupmasterdetail T ON G.taxcode=T.taxgroupcode  where isnull( Voiditem,'N')<>'Y' AND ISNULL(G.taxcode,'')<>'NONE' AND T.taxper<>0 AND ISNULL(T.VOID,'N')<>'Y' AND isnull(ITEM_TYPE,'NO')='NO' AND  pRNDETAILS='" + Docdetails + "'"
                '' ''gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                ''OVERALL DISCOUNT ENTRY

                ''INSERT DISCOUNT WHICH GRN OVERALL DISCOUNT IS AVILABLE
                sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'DISCOUNT',D.Prndetails,D.Prndate,Itemcode,D.storecode ,D.category ,(OverallDiscount*QTY)/TOTALQTY FROM Prn_details D INNER JOIN PRN_HEADER H  ON D.prndetails=H.Prndetails  where isnull( Voiditem,'N')<>'Y' AND OverallDiscount<>0 AND  D.PRNDETAILS='" + Docdetails + "'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                ''OTHER CHARGES ENTRY

                ''INSERT OTHER CHARGES WHICH GRN OVERALL DISCOUNT IS AVILABLE
                sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'OTHERCHARGE',D.Prndetails,D.prndate,Itemcode,D.storecode ,D.category ,((Surchargeamt)*QTY)/TOTALQTY FROM Prn_details D INNER JOIN PRN_HEADER H  ON D.Prndetails=H.prndetails  where isnull( Voiditem,'N')<>'Y' AND Surchargeamt<>0  AND  D.PRNDETAILS='" + Docdetails + "'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                If gShortname <> "BRC" Then
                    sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'PRN' ,'ROUNDOFF',D.Prndetails,D.Prndate,Itemcode,D.storecode ,D.category ,ROUNDUPAMT/(select count(*) from Prn_details where PRNDETAILS='" + Docdetails + "' and  isnull( Voiditem,'N')<>'Y' ) FROM Prn_details D INNER JOIN pRN_HEADER H  ON D.Prndetails=H.Prndetails  where isnull( Voiditem,'N')<>'Y' AND  ROUNDUPAMT<>0 AND  D.PRNDETAILS='" + Docdetails + "'"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If

            ElseIf Type = "ISSUE" Then
                ''ISSUE
                If gShortname <> "CCFC" Then
                    If UCase(gShortname) <> "" Then
                        If UCase(gShortname) <> "BBSR" Then
                            If UCase(gShortname) <> "DGC" Then
                                sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT,opstorelocationcode) SELECT 'ISSUE','ITEM',Docdetails,Docdate,Itemcode,storelocationcode,'', SUM(AMOUNT),opstorelocationcode FROM STOCKISSUEDETAIL WHERE ISNULL(void,'')<>'Y' AND   Docdetails='" + Docdetails + "'  GROUP BY Docdetails,Docdate,Itemcode,storelocationcode,opstorelocationcode"
                                gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                            End If

                        End If

                    End If

                End If



            ElseIf Type = "STOCK TRANSFER" Then
                If gShortname <> "CCFC" Then
                    If UCase(gShortname) <> "" Then
                        If UCase(gShortname) <> "BBSR" Then
                            If UCase(gShortname) <> "DGC" Then
                                ''TRANSFER
                                sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT,opstorelocationcode) SELECT 'STOCK TRANSFER','ITEM',Docdetails,Docdate,Itemcode,fromstorecode,'', SUM(AMOUNT),TOSTORECODE FROM STOCKTRANSFERDETAIL WHERE ISNULL(void,'')<>'Y' AND   Docdetails='" + Docdetails + "' GROUP BY Docdetails,Docdate,Itemcode,fromstorecode,tostorecode"
                                gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                            End If
                        End If
                    End If
                End If





            ElseIf Type = "DAMAGE" Then
                ''DAMAGE
                sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'DAMAGE','ITEM',Docdetails,Docdate,Itemcode,Storecode,'', SUM(AMOUNT) FROM STOCKDMGDETAIL WHERE ISNULL(void,'')<>'Y' AND   Docdetails='" + Docdetails + "' GROUP BY Docdetails,Docdate,Itemcode,Storecode"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)


                ''--ADJUSTMENT
                'sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'ADJUSTMENT','ITEM',Docdetails,Docdate,Itemcode,Storecode,'', SUM(AMOUNT) FROM STOCKADJUSTDETAILS WHERE ISNULL(void,'')<>'Y' GROUP BY Docdetails,Docdate,Itemcode,Storecode"
                'gconnection.ExcuteStoreProcedure(sqlstring)
            ElseIf Type = "CONSUMPTION" Then
                ''--CONSUMPTION
                sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'CONSUMPTION','ITEM',docno,Docdate,Itemcode,Storecode,'', SUM(AMOUNT) FROM stockConsumption_1 WHERE ISNULL(void,'')<>'Y' AND   DOCNO='" + Docdetails + "' GROUP BY docno,Docdate,Itemcode,Storecode"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = "UPDATE INV_JV SET CATEGORY=I.category  FROM INV_JV A INNER JOIN INV_InventoryItemMaster I ON A.ITEMCODE=I.itemcode "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

            End If



            '  UPDATE ACCOUNTS POSTING WISE

            '  STORE WISE


            If gAcPostingWise = "STORE" Then

                If Type = "GRN" Or Type = "PRN" Then

                    ''GRN


                    sqlstring = "update INV_JV set ACCOUNTCODE=a.accountcode,SUBLEDGERIN=a.slcode,COSTCENTERCODE=a.costcentercode   from INV_JV i inner join Accountstaggingnew A on i.STORECODE=a.Code where TYPE in('ITEM','DISCOUNT','OTHERCHARGE')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                Else
                    ''ISSUE TRANSFER
                    sqlstring = "update INV_JV set ACCOUNTCODE=a.accountcode,SUBLEDGERIN=a.slcode,COSTCENTERCODE=a.costcentercode  from INV_JV i inner join Accountstaggingnew A on i.OPSTORELOCATIONCODE=a.Code where DOCTYPE in('ISSUE','STOCK TRANSFER') "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    sqlstring = "update INV_JV set PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode   from INV_JV i inner join Accountstaggingnew A on I.STORECODE=A.Code where DOCTYPE in('ISSUE','STOCK TRANSFER')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    ''DAMAGE
                    sqlstring = "update INV_JV set ACCOUNTCODE=a.DAMGLCODE,SUBLEDGERIN=a.DAMSLCODE,COSTCENTERCODE=a.DAMCCCODE ,PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode from INV_JV i inner join Accountstaggingnew A on i.STORECODE=a.Code where DOCTYPE in('DAMAGE')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)


                    If Type = "ADJUSTMENT" Then
                        ''ADJUSTMENT

                        sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,STORECODE,CATEGORY,AMOUNT) SELECT 'ADJUSTMENT','ITEM',Docdetails,Docdate,Storecode,'', SUM(AMOUNT) FROM STOCKADJUSTDETAILS WHERE ISNULL(void,'')<>'Y' AND   Docdetails='" + Docdetails + "' GROUP BY Docdetails,Docdate,Storecode"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)


                    End If

                    sqlstring = "update INV_JV set ACCOUNTCODE=a.accountcode,SUBLEDGERIN=a.slcode,COSTCENTERCODE=a.costcentercode  from INV_JV i inner join Accountstaggingnew A on i.STORECODE=a.Code where DOCTYPE in('ADJUSTMENT') AND AMOUNT<0 "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    sqlstring = "update INV_JV set PURCHASEACCOUNT=a.ADJGLCODE,SUBLEDGERIN2=a.ADJSLCODE,COSTCENTERCODE2=a.ADJCCCODE   from INV_JV i inner join Accountstaggingnew A on i.STORECODE=a.Code where DOCTYPE in('ADJUSTMENT') AND AMOUNT<0 "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    sqlstring = "update INV_JV set ACCOUNTCODE=a.ADJGLCODE,SUBLEDGERIN=a.ADJSLCODE,COSTCENTERCODE=a.ADJCCCODE  from INV_JV i inner join Accountstaggingnew A on i.STORECODE=a.Code where DOCTYPE in('ADJUSTMENT') AND AMOUNT>0 "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    sqlstring = "update INV_JV set PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode   from INV_JV i inner join Accountstaggingnew A on i.STORECODE=a.Code where DOCTYPE in('ADJUSTMENT') AND AMOUNT>0 "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    ''consuption
                    sqlstring = "update INV_JV set ACCOUNTCODE=a.CONGLCODE,SUBLEDGERIN=a.CONSLCODE,COSTCENTERCODE=a.CONCCCODE  from INV_JV i inner join Accountstaggingnew A on i.STORECODE=a.Code where DOCTYPE in('CONSUMPTION')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    sqlstring = "update INV_JV set PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode   from INV_JV i inner join Accountstaggingnew A on i.STORECODE=a.Code where DOCTYPE in('CONSUMPTION') "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                End If







                '  ITEM WISE
            ElseIf gAcPostingWise = "ITEM" Then

                If Type = "GRN" Then
                    If gShortname = "KBA" Then

                        sqlstring = "update INV_JV set ACCOUNTCODE=a.accountcode,SUBLEDGERIN=a.slcode,COSTCENTERCODE=a.costcentercode   from INV_JV i inner join AccountstaggingForItem A on i.ITEMCODE=a.ItemCode where TYPE in('ITEM','DISCOUNT','OTHERCHARGE')"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                        sqlstring = "update INV_JV set ACCOUNTCODE=( select OTHACCOUNTCODE  from INV_LINKSETUP )   where TYPE in('ROUNDOFF')"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    Else
                        sqlstring = "update INV_JV set ACCOUNTCODE=a.accountcode,SUBLEDGERIN=a.slcode,COSTCENTERCODE=a.costcentercode   from INV_JV i inner join AccountstaggingForItem A on i.ITEMCODE=a.ItemCode where TYPE in('ITEM','DISCOUNT','OTHERCHARGE')"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                        If Mid(UCase(gShortname), 1, 3) = "FMC" Then
                            sqlstring = "update INV_JV set ACCOUNTCODE='" & Trim(Txt_GLAcIn.Text) & "',SUBLEDGERIN='" & Trim(Txt_Slcode.Text) & "'"
                            gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                        End If
                        'sqlstring = "update INV_JV set ACCOUNTCODE='" & Trim(Txt_GLAcIn.Text) & "'"
                        'gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                        'sqlstring = "update INV_JV set ACCOUNTCODE=( select OTHACCOUNTCODE  from INV_LINKSETUP )   where TYPE in('ROUNDOFF')"
                        'gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    End If

                Else
                    If Type = "DAMAGE" Then

                        sqlstring = "update INV_JV set ACCOUNTCODE=a.DAMGLCODE,SUBLEDGERIN=a.DAMSLCODE,COSTCENTERCODE=a.DAMCCCODE ,PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode from INV_JV i inner join AccountstaggingForItem A on i.ItemCode=a.ItemCode where DOCTYPE in('DAMAGE')"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    ElseIf Type = "ADJUSTMENT" Then
                        sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'ADJUSTMENT','ITEM',Docdetails,Docdate,Itemcode,Storecode,'', SUM(AMOUNT) FROM STOCKADJUSTDETAILS WHERE ISNULL(void,'')<>'Y' and  Docdetails='" + Docdetails + "' GROUP BY Docdetails,Docdate,Itemcode,Storecode"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        sqlstring = " DELETE FROM INV_JV_1"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                        sqlstring = "INSERT INTO INV_JV_1 (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'ADJUSTMENT','ITEM',Docdetails,Docdate,Itemcode,Storecode,'', SUM(AMOUNT) FROM STOCKADJUSTDETAILS WHERE ISNULL(void,'')<>'Y' AND   Docdetails='" + Docdetails + "' GROUP BY Docdetails,Docdate,Itemcode,Storecode"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                        sqlstring = "update INV_JV set ACCOUNTCODE=a.accountcode,SUBLEDGERIN=a.slcode,COSTCENTERCODE=a.costcentercode  from INV_JV i inner join AccountstaggingForItem A on i.ITEMCODE=a.ItemCode where DOCTYPE in('ADJUSTMENT') AND AMOUNT>0 "
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        sqlstring = "update INV_JV set PURCHASEACCOUNT=a.ADJGLCODE,SUBLEDGERIN2=a.ADJSLCODE,COSTCENTERCODE2=a.ADJCCCODE   from INV_JV i inner join AccountstaggingForItem A on   i.ITEMCODE=a.ItemCode where DOCTYPE in('ADJUSTMENT') AND AMOUNT>0 "
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        sqlstring = "update INV_JV set ACCOUNTCODE=a.ADJGLCODE,SUBLEDGERIN=a.ADJSLCODE,COSTCENTERCODE=a.ADJCCCODE  from INV_JV i inner join AccountstaggingForItem A on  i.ITEMCODE=a.ItemCode where DOCTYPE in('ADJUSTMENT') AND AMOUNT<0 "
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        sqlstring = "update INV_JV set PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode   from INV_JV i inner join AccountstaggingForItem A on   i.ITEMCODE=a.ItemCode where DOCTYPE in('ADJUSTMENT') AND AMOUNT<0 "
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    ElseIf Type = "CONSUMPTION" Then


                        sqlstring = "update INV_JV set ACCOUNTCODE=a.CONGLCODE,SUBLEDGERIN=a.CONSLCODE,COSTCENTERCODE=a.CONCCCODE  from INV_JV i inner join AccountstaggingForItem A on   i.ITEMCODE=a.ItemCode  where DOCTYPE in('CONSUMPTION')"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        sqlstring = "update INV_JV set PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode   from INV_JV i inner join AccountstaggingForItem A on   i.ITEMCODE=a.ItemCode  where DOCTYPE in('CONSUMPTION') "
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        sqlstring = "UPDATE INV_JV SET COSTCENTERCODE2=a.costcentercode from INV_JV i inner join SToreCostCentertagging  A on i.STORECODE=a.StoreCode  where DOCTYPE in('CONSUMPTION') "
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        sqlstring = "UPDATE INV_JV SET COSTCENTERCODE=a.costcentercode from INV_JV i inner join SToreCostCentertagging A on i.opstorelocationcode=a.StoreCode    where DOCTYPE in('CONSUMPTION') "
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        sqlstring = "UPDATE INV_JV SET COSTCENTERCODE=a.costcentercode from INV_JV i inner join SToreCostCentertagging A on i.STORECODE=a.StoreCode    where DOCTYPE in('CONSUMPTION') "
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    ElseIf Type = "STOCK TRANSFER" Or Type = "ISSUE" Then

                        If gShortname <> "CCFC" Then
                            If UCase(gShortname) <> "NIZAM" Then
                                If UCase(gShortname) <> "BBSR" Then
                                    sqlstring = "update INV_JV set ACCOUNTCODE=a.accountcode,SUBLEDGERIN=a.slcode,COSTCENTERCODE=a.costcentercode  from INV_JV i inner join AccountstaggingForItem A on i.ITEMCODE=a.ItemCode  where DOCTYPE in('ISSUE','STOCK TRANSFER') "
                                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                                    sqlstring = "update INV_JV set PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode   from INV_JV i inner join AccountstaggingForItem A on   i.ITEMCODE=a.ItemCode  where DOCTYPE in('ISSUE','STOCK TRANSFER') "
                                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                                    sqlstring = "UPDATE INV_JV SET COSTCENTERCODE2=a.costcentercode from INV_JV i inner join SToreCostCentertagging  A on i.STORECODE=a.StoreCode  where DOCTYPE in('ISSUE','STOCK TRANSFER','CONSUMPTION') "
                                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                                    sqlstring = "UPDATE INV_JV SET COSTCENTERCODE=a.costcentercode from INV_JV i inner join SToreCostCentertagging A on i.opstorelocationcode=a.StoreCode    where DOCTYPE in('ISSUE','STOCK TRANSFER','CONSUMPTION') "
                                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                                    sqlstring = "UPDATE INV_JV SET COSTCENTERCODE=a.costcentercode from INV_JV i inner join SToreCostCentertagging A on i.STORECODE=a.StoreCode    where DOCTYPE in('CONSUMPTION') "
                                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                                End If
                            End If
                        End If



                    End If


                End If
                'CATEGORY WISE
            ElseIf gAcPostingWise = "CATEGORY" Then

                If Type = "GRN" Then

                Else

                    If Type = "ADJUSTMENT" Then
                        sqlstring = " DELETE FROM INV_JV_1"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                        sqlstring = "INSERT INTO INV_JV_1 (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'ADJUSTMENT','ITEM',Docdetails,Docdate,Itemcode,Storecode,'', SUM(AMOUNT) FROM STOCKADJUSTDETAILS WHERE ISNULL(void,'')<>'Y' AND   Docdetails='" + Docdetails + "' GROUP BY Docdetails,Docdate,Itemcode,Storecode"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    End If
                End If


                sqlstring = "UPDATE INV_JV SET CATEGORY=I.category  FROM INV_JV A INNER JOIN INV_InventoryItemMaster I ON A.ITEMCODE=I.itemcode "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                sqlstring = "UPDATE INV_JV_1 SET CATEGORY=I.category  FROM INV_JV_1 A INNER JOIN INV_InventoryItemMaster I ON A.ITEMCODE=I.itemcode "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)




                If Type = "GRN" Then
                    sqlstring = "update INV_JV set ACCOUNTCODE=a.accountcode,SUBLEDGERIN=a.slcode,COSTCENTERCODE=a.costcentercode   from INV_JV i inner join AccountstaggingForCategory A on i.CATEGORY=a.CategoryCode where TYPE in('ITEM','DISCOUNT','OTHERCHARGE')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                Else

                    ''--DAMAGE 
                    sqlstring = "update INV_JV set ACCOUNTCODE=a.DAMGLCODE,SUBLEDGERIN=a.DAMSLCODE,COSTCENTERCODE=a.DAMCCCODE ,PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode from INV_JV i inner join AccountstaggingForCategory A on i.CATEGORY=a.CategoryCode where DOCTYPE in('DAMAGE')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    If Type = "ADJUSTMENT" Then
                        ''--ADJUSTMENT

                        sqlstring = "INSERT INTO INV_JV_1 (DOCTYPE,TYPE,DOCNO,DOCDATE,STORECODE,CATEGORY,AMOUNT) SELECT 'ADJUSTMENT','ITEM',DOCNO,Docdate,Storecode,category, SUM(AMOUNT) FROM INV_JV_1 GROUP BY DOCNO,Docdate,Storecode,category"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                        sqlstring = "INSERT INTO INV_JV (DOCTYPE,TYPE,DOCNO,DOCDATE,ITEMCODE,STORECODE,CATEGORY,AMOUNT) SELECT 'ADJUSTMENT','ITEM',Docdetails,Docdate,Itemcode,Storecode,'', SUM(AMOUNT) FROM STOCKADJUSTDETAILS WHERE ISNULL(void,'')<>'Y' AND   Docdetails='" + Docdetails + "' GROUP BY Docdetails,Docdate,Itemcode,Storecode"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    End If

                    sqlstring = "update INV_JV set ACCOUNTCODE=a.accountcode,SUBLEDGERIN=a.slcode,COSTCENTERCODE=a.costcentercode  from INV_JV i inner join AccountstaggingForCategory A on i.CATEGORY=a.CategoryCode where DOCTYPE in('ADJUSTMENT') AND AMOUNT<0 "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    sqlstring = "update INV_JV set PURCHASEACCOUNT=a.ADJGLCODE,SUBLEDGERIN2=a.ADJSLCODE,COSTCENTERCODE2=a.ADJCCCODE   from INV_JV i inner join AccountstaggingForCategory A on  i.CATEGORY=a.CategoryCode where DOCTYPE in('ADJUSTMENT') AND AMOUNT<0 "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    sqlstring = "update INV_JV set ACCOUNTCODE=a.ADJGLCODE,SUBLEDGERIN=a.ADJSLCODE,COSTCENTERCODE=a.ADJCCCODE  from INV_JV i inner join AccountstaggingForCategory A on  i.CATEGORY=a.CategoryCode where DOCTYPE in('ADJUSTMENT') AND AMOUNT>0 "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    sqlstring = "update INV_JV set PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode   from INV_JV i inner join AccountstaggingForCategory A on  i.CATEGORY=a.CategoryCode where DOCTYPE in('ADJUSTMENT') AND AMOUNT>0 "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    ''--CONSUMPTION
                    sqlstring = "update INV_JV set ACCOUNTCODE=a.CONGLCODE,SUBLEDGERIN=a.CONSLCODE,COSTCENTERCODE=a.CONCCCODE  from INV_JV i inner join AccountstaggingForCategory A on  i.CATEGORY=a.CategoryCode  where DOCTYPE in('CONSUMPTION')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    sqlstring = "update INV_JV set PURCHASEACCOUNT=a.accountcode,SUBLEDGERIN2=a.slcode,COSTCENTERCODE2=a.costcentercode   from INV_JV i inner join AccountstaggingForCategory A on  i.CATEGORY=a.CategoryCode  where DOCTYPE in('CONSUMPTION') "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If


            End If

            If Type = "GRN" Or Type = "PRN" Then
                ' UPDATE TAX ACCOUNT CODE
                If gShortname = "CCL" Then

                    sqlstring = "update INV_JV set ACCOUNTCODE=a.INPUTTAXACCOUNTIN,SUBLEDGERIN=a.subledgercode,COSTCENTERCODE=a.costcentercode   from INV_JV i inner join accountstaxmaster A on i.ITEMCODE=a.taxcode where TYPE in('tax')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                Else
                    sqlstring = "update INV_JV set ACCOUNTCODE=a.INPUTTAXACCOUNTIN,SUBLEDGERIN=a.subledgercode,COSTCENTERCODE=a.costcentercode   from INV_JV i inner join accountstaxmaster A on i.ITEMCODE=a.taxcode where TYPE in('tax')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                End If

                sqlstring = "update INV_JV set ACCOUNTCODE=a.INPUTTAXACCOUNTIN,SUBLEDGERIN=a.subledgercode,COSTCENTERCODE=a.costcentercode  from INV_JV i , accountstaxmaster A  where TYPE in('SPL') and a.taxcode='IN_ADDCESS'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                '' UPDATE SUPPLIER/SPONSOR ACCOUNT CODE
                If Type = "GRN" Then
                    sqlstring = "update INV_JV set PURCHASEACCOUNT=s.accountcode,SUBLEDGERIN2=s.slcode,COSTCENTERCODE2=s.costcentercode  from INV_JV i  inner join Grn_details A on i.DOCNO=a.grndetails inner join SponsorAccountstagging s on A.SPONSORCODE=s.Code where SPONSORCODE<>'' "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    sqlstring = "update INV_JV set PURCHASEACCOUNT=s.ACCODE,SUBLEDGERIN2=s.slcode from INV_JV i  inner join Grn_details A on i.DOCNO=a.grndetails inner join accountssubledgermaster s on A.Suppliercode=s.SLCODE where isnull(SPONSORCODE,'')='' AND  isnull(freezeflag,'')<>'Y' "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    If UCase(gShortname) = "FMC" Then
                        sqlstring = "update INV_JV set PURCHASEACCOUNT=a.GLACCOUNTIN,SUBLEDGERIN2='',COSTCENTERCODE2='' from INV_JV i inner join accountstaxmaster A on i.ITEMCODE=a.taxcode where TYPE in('tax') and  DOCNO IN (SELECT grndetails FROM   VW_INV_GRNBILL WHERE VENDORTYPE='UNREGISTERED')"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    Else
                        sqlstring = "update INV_JV set PURCHASEACCOUNT=a.OUTPUTTAXACCOUNTIN,SUBLEDGERIN2='',COSTCENTERCODE2='' from INV_JV i inner join accountstaxmaster A on i.ITEMCODE=a.taxcode where TYPE in('tax') and  DOCNO IN (SELECT grndetails FROM   VW_INV_GRNBILL WHERE VENDORTYPE='UNREGISTERED')"
                        gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    End If




                Else
                    sqlstring = "update INV_JV set PURCHASEACCOUNT=s.accountcode,SUBLEDGERIN2=s.slcode,COSTCENTERCODE2=s.costcentercode  from INV_JV i  inner join Prn_details A on i.DOCNO=a.Prndetails inner join SponsorAccountstagging s on A.SPONSORCODE=s.Code where SPONSORCODE<>'' "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    sqlstring = "update INV_JV set PURCHASEACCOUNT=s.ACCODE,SUBLEDGERIN2=s.slcode from INV_JV i  inner join Prn_details A on i.DOCNO=a.Prndetails inner join accountssubledgermaster s on A.Suppliercode=s.SLCODE where isnull(SPONSORCODE,'')='' AND  isnull(freezeflag,'')<>'Y'  and accode in( select ScrsCode from ACCOUNTSSETUP)"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    sqlstring = "update INV_JV set PURCHASEACCOUNT=a.OUTPUTTAXACCOUNTIN,SUBLEDGERIN2='',COSTCENTERCODE2='' from INV_JV i inner join accountstaxmaster A on i.ITEMCODE=a.taxcode where TYPE in('tax') and  DOCNO IN (SELECT Prndetails FROM   VW_INV_PRNBILL WHERE VENDORTYPE='UNREGISTERED')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If





                'UPDATE DISCOUNT AMOUNT IN NAGETIVE
                sqlstring = "UPDATE inv_jv SET AMOUNT =AMOUNT *-1 WHERE TYPE='DISCOUNT'"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)
            End If


            sqlstring = "   select * from inv_jv  "
            gconnection4BGP.getDataSet(sqlstring, "MISMATCHpOSING")

            If gdataset.Tables("MISMATCHpOSING").Rows.Count > 0 Then


                ' VALIDATION 
                'CHECKING FOR ACCODE 
                sqlstring = "   select distinct accountcode,DOCNO,DOCTYPE from inv_jv where accountcode   not in ( select Accode from Accountsglaccountmaster where  isnull(freezeflag,'') <> 'Y') "
                gconnection4BGP.getDataSet(sqlstring, "MISMATCHpOSING")
                If gdataset.Tables("MISMATCHpOSING").Rows.Count > 0 Then
                    Dim I As Integer
                    For I = 0 To gdataset.Tables("MISMATCHpOSING").Rows.Count - 1
                        If UCase(gdataset.Tables("MISMATCHpOSING").Rows(0).Item("accountcode")) <> "" Then
                            MsgBox(" Invalied Accounct code: '" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("accountcode")) + "' for voucherno: " + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("docno")))
                            sqlstring = " DELETE FROM inv_jv WHERE DOCNO='" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("docno")) + "' AND DOCTYPE='" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("DOCTYPE")) + "'"
                            gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        End If
                    Next

                End If
                ''  CHECKING FOR SUPPLIER CODE
                sqlstring = "  select distinct purchaseaccount,docno,DOCTYPE from inv_jv where purchaseaccount   not in ( select Accode from Accountsglaccountmaster where  isnull(freezeflag,'') <> 'Y')"
                gconnection4BGP.getDataSet(sqlstring, "MISMATCHpOSING")
                If gdataset.Tables("MISMATCHpOSING").Rows.Count > 0 Then
                    Dim I As Integer
                    For I = 0 To gdataset.Tables("MISMATCHpOSING").Rows.Count - 1
                        If UCase(gdataset.Tables("MISMATCHpOSING").Rows(0).Item("purchaseaccount")) <> "" Then

                            MsgBox(" Invalied Accounct code: '" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("purchaseaccount")) + "' for voucherno: " + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("docno")))
                            sqlstring = " DELETE FROM inv_jv WHERE DOCNO='" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("docno")) + "' AND DOCTYPE='" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("DOCTYPE")) + "'"
                            gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                        End If
                    Next

                End If
                '' CHECKING FOR SL CODE
                sqlstring = "   select distinct subledgerin,DOCNO,DOCTYPE from inv_jv inner join  accountssubledgermaster on accode=subledgerin where  isnull(accountssubledgermaster.freezeflag,'') <> 'Y'   "
                gconnection4BGP.getDataSet(sqlstring, "MISMATCHpOSING")
                If gdataset.Tables("MISMATCHpOSING").Rows.Count > 0 Then
                    Dim I As Integer
                    For I = 0 To gdataset.Tables("MISMATCHpOSING").Rows.Count - 1
                        If UCase(gdataset.Tables("MISMATCHpOSING").Rows(0).Item("subledgerin")) <> "" Then
                            MsgBox(" Invalied SL  Accounct code: '" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("subledgerin")) + "' for voucherno: " + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("docno")))
                            sqlstring = " DELETE FROM inv_jv WHERE DOCNO='" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("docno")) + "' AND DOCTYPE='" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("DOCTYPE")) + "'"
                            gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        End If
                    Next
                End If

                '' CHECKING FOR COSTCENTERCODE 
                sqlstring = "  select distinct COSTCENTERCODE,DOCNO,DOCTYPE from inv_jv where COSTCENTERCODE   not in ( select costcentercode from AccountsCostCenterMaster where  isnull(freezeflag,'') <> 'Y') AND ISNULL(COSTCENTERCODE,'')<>''"
                gconnection4BGP.getDataSet(sqlstring, "MISMATCHpOSING")
                If gdataset.Tables("MISMATCHpOSING").Rows.Count > 0 Then
                    Dim I As Integer
                    For I = 0 To gdataset.Tables("MISMATCHpOSING").Rows.Count - 1
                        If UCase(gdataset.Tables("MISMATCHpOSING").Rows(0).Item("COSTCENTERCODE")) <> "" Then
                            MsgBox(" Invalied Cost Center Accounct code: '" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("COSTCENTERCODE")) + "' for voucherno: " + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("docno")))
                            sqlstring = " DELETE FROM inv_jv WHERE DOCNO='" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("docno")) + "' AND DOCTYPE='" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("DOCTYPE")) + "'"
                            gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        End If
                    Next
                End If


                '' CHECKING FOR COSTCENTERCODE 
                sqlstring = "  select distinct COSTCENTERCODE2,DOCNO,DOCTYPE from inv_jv where COSTCENTERCODE2   not in ( select costcentercode from AccountsCostCenterMaster where  isnull(freezeflag,'') <> 'Y') AND ISNULL(COSTCENTERCODE2,'')<>''"
                gconnection4BGP.getDataSet(sqlstring, "MISMATCHpOSING")
                If gdataset.Tables("MISMATCHpOSING").Rows.Count > 0 Then
                    Dim I As Integer
                    For I = 0 To gdataset.Tables("MISMATCHpOSING").Rows.Count - 1
                        If UCase(gdataset.Tables("MISMATCHpOSING").Rows(0).Item("COSTCENTERCODE2")) <> "" Then
                            MsgBox(" Invalied Cost Center   Accounct code: " + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("COSTCENTERCODE2")) + " for voucherno: " + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("docno")))
                            sqlstring = " DELETE FROM inv_jv WHERE DOCNO='" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("docno")) + "' AND DOCTYPE='" + UCase(gdataset.Tables("MISMATCHpOSING").Rows(I).Item("DOCTYPE")) + "'"
                            gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                        End If
                    Next
                End If


                If Type = "PRN" Then
                    sqlstring = " INSERT INTO INV_JV2 (VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE) SELECT  DOCNO,DOCDATE,DOCTYPE,SUM(AMOUNT),'CREDIT',ACCOUNTCODE,SUBLEDGERIN,isnull(COSTCENTERCODE,'')  FROM inv_jv GROUP BY DOCNO,DOCDATE,DOCTYPE,ACCOUNTCODE,SUBLEDGERIN,isnull(COSTCENTERCODE,'') "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    '' CREDIT SIDE
                    sqlstring = " INSERT INTO INV_JV2 (VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE) SELECT DOCNO,DOCDATE,DOCTYPE,SUM(AMOUNT),'DEBIT',PURCHASEACCOUNT,SUBLEDGERIN2,isnull(COSTCENTERCODE2,'') FROM inv_jv GROUP BY DOCNO,DOCDATE,DOCTYPE,PURCHASEACCOUNT,SUBLEDGERIN2,isnull(COSTCENTERCODE2,'') "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                Else
                    sqlstring = " INSERT INTO INV_JV2 (VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE) SELECT  DOCNO,DOCDATE,DOCTYPE,SUM(AMOUNT),'DEBIT',ACCOUNTCODE,SUBLEDGERIN,COSTCENTERCODE  FROM inv_jv GROUP BY DOCNO,DOCDATE,DOCTYPE,ACCOUNTCODE,SUBLEDGERIN,COSTCENTERCODE "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                    '' CREDIT SIDE
                    sqlstring = " INSERT INTO INV_JV2 (VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE) SELECT DOCNO,DOCDATE,DOCTYPE,SUM(AMOUNT),'CREDIT',PURCHASEACCOUNT,SUBLEDGERIN2,COSTCENTERCODE2 FROM inv_jv GROUP BY DOCNO,DOCDATE,DOCTYPE,PURCHASEACCOUNT,SUBLEDGERIN2,COSTCENTERCODE2 "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If
                '' INSERTING IN INV_JV2
                '' DEBIT SIDE




                sqlstring = "UPDATE INV_JV2 SET AMOUNT =AMOUNT *-1 WHERE VOUCHERTYPE='ADJUSTMENT' AND AMOUNT<0"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                If UCase(gShortname) = "NIZAM" Then
                    sqlstring = "INSERT INTO INV_JV3 (VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE,DESCRIPTION) "
                    sqlstring = sqlstring & " SELECT VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE,'NOT TO BE POST' FROM INV_JV2 WHERE voucherno IN (SELECT voucherno FROM  INV_JV2 WHERE SLCODE ='0001')  "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    sqlstring = " DELETE FROM INV_JV2 WHERE voucherno IN (SELECT voucherno FROM  INV_JV2 WHERE SLCODE ='0001')  "
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                End If


                '' VALIDATION 

                ''  DEBIT CREDIT AMOUNT NOT  MATCHING 
                '' INSERT IN DUMMY TABLE  

                sqlstring = "INSERT INTO INV_JV3 (VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE,DESCRIPTION) "
                sqlstring = sqlstring & " SELECT VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE,'ACCOUNT CODE NOT FOUND' FROM INV_JV2 WHERE ISNULL(ACCOUNTCODE,'') =''  "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = "INSERT INTO INV_JV3 (VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE,DESCRIPTION) "
                sqlstring = sqlstring & " SELECT VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE,'AMOUNT NOT MATCH' FROM INV_JV2 WHERE voucherno +VOUCHERTYPE IN ( SELECT voucherno +VOUCHERTYPE  FROM "
                sqlstring = sqlstring & " (select sum(amount) as CREDIT ,0 AS DEBIT, voucherno,VOUCHERTYPE from INV_JV2   WHERE  CREDITDEBIT='DEBIT' AND VoucherType IN ('GRN') group by voucherno,CREDITDEBIT,VOUCHERTYPE  "
                sqlstring = sqlstring & " UNION ALL "
                sqlstring = sqlstring & " select 0 as CREDIT ,sum(Billamount) AS DEBIT, Grndetails as  voucherno,'GRN' as VOUCHERTYPE from GRN_HEADER   WHERE   ISNULL(Void,'')<>'Y' group by Grndetails ) T "
                sqlstring = sqlstring & " group by voucherno,VOUCHERTYPE HAVING abs(SUM(CREDIT)-SUM(DEBIT))>1) "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                ''DELETING THESE RECORDS 
                sqlstring = " DELETE FROM INV_JV2 WHERE voucherno +VOUCHERTYPE IN ( "
                sqlstring = sqlstring & " SELECT voucherno +VOUCHERTYPE  FROM "
                sqlstring = sqlstring & " (select sum(amount) as CREDIT ,0 AS DEBIT, voucherno,VOUCHERTYPE from INV_JV2   WHERE  CREDITDEBIT='DEBIT' AND VoucherType IN ('GRN') group by voucherno,CREDITDEBIT,VOUCHERTYPE  "
                sqlstring = sqlstring & " UNION ALL "
                sqlstring = sqlstring & " select 0 as CREDIT ,sum(Billamount) AS DEBIT, Grndetails as  voucherno,'GRN' as VOUCHERTYPE from GRN_HEADER   WHERE   ISNULL(Void,'')<>'Y' group by Grndetails ) T "
                sqlstring = sqlstring & " group by voucherno,VOUCHERTYPE HAVING abs(SUM(CREDIT)-SUM(DEBIT))>1) "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                ''AND VOUCHERNO IN (SELECT grndetails FROM   VW_INV_GRNBILL WHERE VENDORTYPE<>'UNREGISTERED')'



                sqlstring = "INSERT INTO INV_JV3 (VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE,DESCRIPTION) "
                sqlstring = sqlstring & " SELECT VOUCHERNO,VOUCHERDATE,VOUCHERTYPE,AMOUNT,CREDITDEBIT,ACCOUNTCODE,SLCODE,COSTCENTERCODE,'AMOUNT NOT MATCH' FROM INV_JV2 WHERE voucherno +VOUCHERTYPE IN ( SELECT voucherno +VOUCHERTYPE  FROM MISMATCHpOSINGFORM_INV_JV) "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)




                ''DELETING THESE RECORDS 
                sqlstring = " DELETE FROM INV_JV2 WHERE voucherno +VOUCHERTYPE IN ( "
                sqlstring = sqlstring & " SELECT voucherno +VOUCHERTYPE  FROM MISMATCHpOSINGFORM_INV_JV) "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)


                sqlstring = " DELETE FROM INV_JV4 "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = " INSERT INTO INV_JV4 (VOUCHERNO,VOUCHERDATE,VOUCHERCATEGORY,vouchertype,CASHBANK,	ACCOUNTCODE,ACCOUNTDESC,SLCODE,	SLDESC,COSTCENTERCODE,COSTCENTERDESC,CREDITDEBIT,AMOUNT,DESCRIPTION)  "
                sqlstring = sqlstring & " SELECT VOUCHERNO,VOUCHERDATE,vouchertype,vouchertype,'',	ACCOUNTCODE,'' ,SLCODE,	'' ,COSTCENTERCODE,'' ,CREDITDEBIT,AMOUNT,SLCODE + CAST (VOUCHERDATE AS varchar) FROM INV_JV2  "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)


                sqlstring = "UPDATE INV_JV4 SET CREDITDEBIT ='CREDIT' WHERE VOUCHERTYPE='GRN' and amount<0"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = "UPDATE INV_JV4 SET AMOUNT =AMOUNT *-1 WHERE VOUCHERTYPE='GRN' and amount<0"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = " UPDATE INV_JV4 SET ACCOUNTDESC=A.acdesc FROM INV_JV4 B INNER JOIN Accountsglaccountmaster A ON  B.ACCOUNTCODE=A.accode "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = " UPDATE INV_JV4 SET sldesc=A.sldesc FROM INV_JV4 B INNER JOIN accountssubledgermaster A ON  B.SLCODE=A.slcode"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                sqlstring = " UPDATE INV_JV4 SET COSTCENTERDESC=A.costcenterdesc FROM INV_JV4 B INNER JOIN AccountsCostCenterMaster A ON  B.COSTCENTERCODE=A.costcentercode"
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)


                If UCase(gShortname) = "NIZAM" Then
                    sqlstring = " UPDATE journalentry SET Void='Y'  WHERE VoucherNO+VoucherType IN ( SELECT VoucherNO+VoucherType FROM INV_JV4 )"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    sqlstring = " UPDATE journalentry SET Void='Y'   WHERE VoucherNO+VoucherType IN ('" + Docdetails + Type + "')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                Else
                    sqlstring = " UPDATE journalentry SET Void='Y' ,VOIDUSER='" + gUsername + "' ,VOIDDATE=GETDATE()  WHERE VoucherNO+VoucherType IN ( SELECT VoucherNO+VoucherType FROM INV_JV4 )"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)

                    sqlstring = " UPDATE journalentry SET Void='Y' ,VOIDUSER='" + gUsername + "' ,VOIDDATE=GETDATE()  WHERE VoucherNO+VoucherType IN ('" + Docdetails + Type + "')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If


                If Type = "GRN" Then
                    sqlstring = " UPDATE journalentry SET Void='Y'   WHERE VoucherNO IN ('" + Docdetails + "')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If

                If UCase(gShortname) = "NIZAM" Then
                    sqlstring = "INSERT INTO journalentry (VOUCHERNO,VOUCHERDATE,VOUCHERCATEGORY,vouchertype,CASHBANK,	ACCOUNTCODE,AccountcodeDesc,SLCODE,	SLDESC,COSTCENTERCODE,COSTCENTERDESC,CREDITDEBIT,AMOUNT,VOID,DESCRIPTION,adduserid,adddatetime) "
                    sqlstring = sqlstring & " SELECT VOUCHERNO,VOUCHERDATE,VOUCHERCATEGORY,vouchertype,CASHBANK,	ACCOUNTCODE,ACCOUNTDESC,SLCODE,	SLDESC,COSTCENTERCODE,COSTCENTERDESC,CREDITDEBIT,AMOUNT,'N',DESCRIPTION,'" + gUsername + "',getDate() FROM INV_JV4"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                Else
                    sqlstring = "INSERT INTO journalentry (VOUCHERNO,VOUCHERDATE,VOUCHERCATEGORY,vouchertype,CASHBANK,	ACCOUNTCODE,AccountcodeDesc,SLCODE,	SLDESC,COSTCENTERCODE,COSTCENTERDESC,CREDITDEBIT,AMOUNT,VOID,DESCRIPTION,add_user,adduserid,adddatetime,add_date) "
                    sqlstring = sqlstring & " SELECT VOUCHERNO,VOUCHERDATE,VOUCHERCATEGORY,vouchertype,CASHBANK,	ACCOUNTCODE,ACCOUNTDESC,SLCODE,	SLDESC,COSTCENTERCODE,COSTCENTERDESC,CREDITDEBIT,AMOUNT,'N',DESCRIPTION,'" + gUsername + "','" + gUsername + "',getDate(),getDate() FROM INV_JV4"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If

                If UCase(gShortname) = "SATC" Then


                    sqlstring = " UPDATE journalentry SET AUTHORISED='Y'  WHERE VoucherNO+VoucherType IN ('" + Docdetails + Type + "')"
                    gconnection4BGP.ExcuteStoreProcedure(sqlstring)
                End If

                sqlstring = " DELETE FROM journalentry WHERE vouchertype in ('GRN','DAMAGE','STOCK TRANSFER','ADJUSTMENT','ISSUE','CONSUMPTION','PRN') AND ISNULL(ACCOUNTCODE,'')='' "
                gconnection4BGP.ExcuteStoreProcedure(sqlstring)

            End If





        Catch ex As Exception

        End Try
    End Function

    Private Sub Cmd_SlCodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_SlCodeHelp.Click
        Try
            Dim vform As New ListOperattion1
            gSQLString = "SELECT slcode,sldesc FROM accountssubledgermaster"
            M_WhereCondition = " WHERE accode = '" & Trim(Txt_GLAcIn.Text) & "'"
            vform.Field = "SLCODE"
            vform.Field = "SLDESC"
            vform.vFormatstring = "  SLCODE                             |                          SLDESC                                "
            vform.vCaption = "SUBLEDGER MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_Slcode.Text = Trim(vform.keyfield & "")
                Txt_SlDesc.Text = Trim(vform.keyfield1 & "")
                'Me.Txt_CostCenterCode.Focus()
            Else
                Me.Txt_GLAcIn.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_SlCodeHelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_CostCenterCodeHelp_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Txt_GLAcIn_TextChanged(sender As Object, e As EventArgs) Handles Txt_GLAcIn.TextChanged

    End Sub

    Private Sub Txt_GLAcIn_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_GLAcIn.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_GLAcIn.Text <> "" Then
                Txt_GLAcIn_Validated(sender, e)
            Else
                Cmd_GLAcHelp_Click(sender, e)
            End If

        End If
    End Sub



    Private Sub Txt_Slcode_Validated(sender As Object, e As EventArgs) Handles Txt_Slcode.Validated
        Try
            Dim sqlstring As String
            If Trim(Txt_Slcode.Text) <> "" Then
                sqlstring = "SELECT slcode, sldesc from accountssubledgermaster WHERE accode = '" & Trim(Txt_GLAcIn.Text) & "' and slcode = '" & Trim(Txt_Slcode.Text) & "'"
                gconnection.getDataSet(sqlstring, "accountssubledgermaster")
                If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
                    Txt_Slcode.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("slcode")))
                    Txt_SlDesc.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("sldesc")))
                    If costcentercodestatus = True Then
                        'Txt_CostCenterCode.Focus()
                        AxfpSpread1.Focus()
                    Else
                        AxfpSpread1.Focus()
                    End If
                Else
                    Txt_Slcode.Text = ""
                    Txt_SlDesc.Text = ""
                End If
                gdataset.Tables("accountssubledgermaster").Dispose()
            Else
                Txt_Slcode.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Txt_Slcode_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_Slcode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Slcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_Slcode.Text <> "" Then
                Txt_Slcode_Validated(sender, e)
            Else
                Cmd_SlCodeHelp_Click(sender, e)
            End If

        End If
    End Sub

    Private Sub Txt_CostCenterCode_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub Txt_CostCenterCode_Validated(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt_Surchargeamt_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Surchargeamt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Mid(UCase(gShortname), 1, 3) = "NIZ" Or Mid(UCase(gShortname), 1, 3) = "CFC" Then
                CALCULATE()
            End If
        End If

    End Sub

    Private Sub TXT_OVERALLdiscount_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_OVERALLdiscount.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Mid(UCase(gShortname), 1, 3) = "NIZ" Or Mid(UCase(gShortname), 1, 3) = "CFC" Then
                CALCULATE()
            End If
        End If
    End Sub

    Private Sub AxfpSpread1_Advance(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread1.Advance

    End Sub
End Class