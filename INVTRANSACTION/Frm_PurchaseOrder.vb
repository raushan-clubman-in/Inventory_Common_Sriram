Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions
Public Class Frm_PurchaseOrder
    Dim SSTR As String
    Dim gconnection As New GlobalClass
    Dim sqlstring, SQL As String
    'Dim sql As String
    Dim doctype As String
    Dim grtot, grvat, totaldiscount As Double
    Dim boolchk As Boolean
    Dim potype As String
    Dim VATFLAG As Boolean = True
    Public pono_del As String



    Private Sub Frm_PurchaseOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call CmdClear_Click(CmdClear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 And CmdFreeze.Enabled = True Then
                Call CmdFreeze_Click(CmdFreeze, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 And CmdAdd.Visible = True Then
                Call CmdAdd_Click(CmdAdd, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 And CmdView.Visible = True Then
                Call CmdView_Click(CmdView, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F10 And CmdPrint.Enabled = True Then
                Call CmdPrint_Click(CmdPrint, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Then
                Call CmdExit_Click(CmdExit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.Escape Then
                Call CmdExit_Click(CmdExit, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

   

   
 
  
    'Private Sub Raju_Resize(ByVal sender As Object, _
    '      ByVal e As System.EventArgs) Handles Me.Resize

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

    Private Sub FillDELIVERYTERM()
        Dim i As Integer
        ChkLst_Group.Items.Clear()
        sqlstring = " SELECT ISNULL(DELIVERYTERMCODE,0) AS DELIVERYTERMCODE,ISNULL(DELIVERYTERMDESC,'') AS DELIVERYTERMDESC FROM PO_DELIVERYTERMS  where isnull(freeze,'N')<>'Y' "
        gconnection.getDataSet(sqlstring, "SUBLEDGERMASTER")
        If gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1
                With gdataset.Tables("SUBLEDGERMASTER").Rows(i)
                    ChkLst_Group.Items.Add(Trim(CStr(.Item("DELIVERYTERMCODE"))) & "-->" & Trim(CStr(.Item("DELIVERYTERMDESC"))))
                End With
            Next i
        End If
    End Sub

    Private Sub Frm_PurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.CmdClear.Visible = True
                Me.CmdExit.Visible = True

            End If
        End If
        'Me.DoubleBuffered = True
        If gValidity = False Then
            Me.CmdAdd.Enabled = False
            Me.cmd_auth.Enabled = False
            Me.CmdFreeze.Enabled = False
        End If
        'Resize_Form()

        Call FillDELIVERYTERM()

        Label17.Visible = False
        TextBox1.Visible = False

        AxfpSpread1.Col = 17
        AxfpSpread1.ColHidden = True
        'IW = Me.Width
        'IH = Me.Height
        GroupBox4.Controls.Add(AxfpSpread1)
        'AxfpSpread1.Location = New Point(3, 8)
        'AxfpSpread1.Height = GroupBox4.Height - 30
        Show()

        If Mid(gShortname, 1, 3) = "CCF" Then
            ' CmbPoType.Items.Remove()
        Else

        End If

        Me.Cbo_Approvedby.SelectedIndex = 0
        Me.Cbo_POStatus.SelectedIndex = 0
        Timer1.Enabled = True
        Timer1.Start()
        FillGRNTYPE()
        Call categoryfill()
        Me.cbo_warehouse.Focus()
        Call autogenerate()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Me.GB_DELI.Visible = False
        If gShortname = "BGC" Then
            GroupBox6.Visible = True
            Label55.Visible = False
            TXT_DOCTHROUGH.Visible = False
            Panel1.Visible = True
            BGCVIEW()


        Else
            GroupBox6.Visible = False
            Label50.Visible = False
            TXT_PTERM.Visible = False
            Panel1.Visible = False
        End If



    End Sub
    Private Sub BGCVIEW()
        sqlstring = " ALTER VIEW [dbo].[VW_POBILL] AS      SELECT      dbo.PO_HDR.pono, dbo.PO_HDR.doctype, dbo.PO_HDR.storecode, dbo.PO_HDR.podate, dbo.PO_HDR.poquotno, dbo.PO_HDR.povendorcode,   dbo.PO_HDR.podepartment, dbo.PO_HDR.potype, dbo.PO_HDR.povalidfrom, dbo.PO_HDR.povalidupto, dbo.PO_ITEMDETAILS.ITEMCODE, dbo.PO_ITEMDETAILS.ITEMNAME, dbo.PO_ITEMDETAILS.UOM, dbo.PO_ITEMDETAILS.QUANTITY, dbo.PO_ITEMDETAILS.baseamount,  dbo.PO_ITEMDETAILS.Rate,    dbo.PO_ITEMDETAILS.discper, dbo.PO_ITEMDETAILS.taxper, dbo.PO_ITEMDETAILS.discamt,  dbo.PO_ITEMDETAILS.vatamt, dbo.PO_ITEMDETAILS.TOTALamount,    dbo.PO_ITEMDETAILS.taxcode,dbo.PO_ITEMDETAILS.amountafterdiscount,  dbo.PO_ITEMDETAILS.othchg, dbo.PO_HDR.versionno, dbo.PO_HDR.POOVERALLDISC,dbo.PO_HDR.pobalance, dbo.PO_HDR.poadvance,   dbo.PO_HDR.pototaldiscount, dbo.PO_HDR.pototaltax, dbo.PO_HDR.pototalvat, dbo.PO_HDR.povalue,    dbo.PO_HDR.pootherchgplus,   dbo.PO_HDR.pootherchgmin, dbo.PO_HDR.POtransport, dbo.PO_HDR.postatus,iv.vendorNAME AS vendorNAME, ISNULL(IV.contactperson,'') AS contactperson,ISNULL(IV.address1,'') AS address1,ISNULL(IV.address2,'') AS address2,  ISNULL(IV.city,'') AS city,ISNULL(IV.state,'') AS state,ISNULL(IV.PIN,'') AS pIN , ISNULL(IV.phoneno,'') AS PhONENO, ISNULL(GSTINNO,'') AS GSTINNO ,ISNULL(VENDORTYPE,'') AS VENDORTYPE , isnull(dbo.PO_HDR.podelivery,'') as podelivery,dbo.PO_HDR.poremarks as remarks,isnull((SELECT ISNULL(PAYMENTTERMDESC,'') AS PAYMENTTERMDESC FROM PO_PAYMENTTERMS where PAYMENTTERMCODE=poterms),'') as poterms,ISNULL(CGSTAmt,0) AS CGSTAmt,ISNULL(SGSTAmt,0) AS SGSTAmt,ISNULL(IGSTAmt,0 )AS IGSTAmt , ISNULL(GSTAmt,0 )AS GSTAmt ,ISNULL(I.HSNNO,'') AS HSNNO,ISNULL(I.TAXTYPE,'') AS  TAXTYPE  ,ISNULL(dbo.PO_ITEMDETAILS .SPLCESS,0) AS SPLCESS,ISNULL(DELIVERTODEPT,'')AS DELIVERTODEPT,ISNULL(DEPTCONPERSON,'')AS DEPTCONPERSON,ISNULL(DEPTCONNO,'')AS DEPTCONNO, ISNULL(DEPTCONEMAIL,'')AS DEPTCONEMAIL,ISNULL(IND_MAT_REQNO,'')AS IND_MAT_REQNO, DELIVERBYDATE,ISNULL(DNO,'')AS DNO,ISNULL(DEPART,'')AS DEPART,ISNULL(GSTAPPLICAPLE,'')AS  GSTAPPLICAPLE FROM         dbo.PO_HDR  INNER JOIN dbo.PO_ITEMDETAILS ON dbo.PO_HDR.pono = dbo.PO_ITEMDETAILS.pono   INNER JOIN SUPPLIERDetails iv on PO_HDR.povendorcode=iv.vendorcode  INNER JOIN INV_InventoryItemMaster I ON I.itemcode=dbo.PO_ITEMDETAILS.Itemcode  WHERE ISNULL(postatus,'') <>'AMENDED'"
        gconnection.getDataSet(sqlstring, "INVSETUP")
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
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 655
        K = 1054
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
                        If Controls(i_i).Name = "GroupBox7" Then
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
    Private Function categoryfill()
        Try
            Dim I As Integer
            Dim INDEX As Integer
            cbo_warehouse.Items.Clear()
            Dim sql As String = "Select distinct categorycode,Usercode from Categoryuserdetail where usercode='" & gUsername & "' and isnull(void,'')<>'Y'"

            '   SSTR = "SELECT DISTINCT CATEGORY FROM INV_InventoryItemMaster"
            gconnection.getDataSet(sql, "INV_InventoryItemMaster")
            If gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0 Then
                For I = 0 To gdataset.Tables("INV_InventoryItemMaster").Rows.Count - 1
                    cbo_warehouse.Items.Add(gdataset.Tables("INV_InventoryItemMaster").Rows(I).Item("categorycode"))
                Next
                INDEX = cbo_warehouse.FindString(DefaultGRN)
                cbo_warehouse.SelectedIndex = INDEX
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CATEGORYFILL " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Private Sub autogenerate()
        Dim sqlstring, financalyear, doctype, shorNAme As String
        If Txt_Storecode.Text <> "" And Mid(CmdAdd.Text, 1, 1) = "A" Then
            Try
                shorNAme = gShortname
                gcommand = New SqlCommand
                doctype = Mid(Txt_Storecode.Text, 1, 3)
                financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)

                '  sqlstring = "SELECT MAX(Cast(SUBSTRING(PO_NO,1,6) As Numeric)) FROM PO_HDR "
                If gShortname.Length = 4 Then
                    sqlstring = "SELECT MAX(Cast(SUBSTRING(PO_NO,1,6) As Numeric)) FROM PO_HDR WHERE SUBSTRING(PONO,6,3)='" & doctype & "'  and PONO like '%" + financalyear + "'"
                ElseIf gShortname.Length = 3 Then

                    If doctype.Length = 2 Then
                        sqlstring = "SELECT MAX(Cast(SUBSTRING(PO_NO,1,6) As Numeric)) FROM PO_HDR WHERE SUBSTRING(PONO,5,2)='" & doctype & "'  and PONO like '%" + financalyear + "'"
                    Else
                        sqlstring = "SELECT MAX(Cast(SUBSTRING(PO_NO,1,6) As Numeric)) FROM PO_HDR WHERE SUBSTRING(PONO,5,3)='" & doctype & "' and PONO like '%" + financalyear + "'"
                    End If


                Else
                    shorNAme = Mid(gShortname, 1, 3)
                    sqlstring = "Select MAX(Cast(SUBSTRING(PO_NO,1,6) As Numeric)) FROM PO_HDR WHERE SUBSTRING(PONO,5,3)='" & doctype & "' and PONO like '%" + financalyear + "'"

                End If

                '  sqlstring = " SELECT MAX(Cast(SUBSTRING(POno,8,6) As Numeric)) FROM PO_HDR "
                If gconnection.Myconn.State <> ConnectionState.Open Then
                    gconnection.openConnection()
                End If
                doctype = Mid(Txt_Storecode.Text, 1, 3)
                gcommand.CommandText = sqlstring
                gcommand.CommandType = CommandType.Text
                gcommand.Connection = gconnection.Myconn
                gdreader = gcommand.ExecuteReader
                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        '  txt_PONo.Text = gShortname & "/" & doctype & "/PO/000001/" & financalyear
                        ' txt_PONo.Text = gShortname & "/PO/000001/" & financalyear
                        txt_PONo.Text = shorNAme & "/" & doctype & "/000001/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        '  txt_PONo.Text = gShortname & "/" & doctype & "/PO/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                        txt_PONo.Text = shorNAme & "/" & doctype & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear

                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    '  txt_PONo.Text = gShortname & "/" & doctype & "/PO/000001/" & financalyear
                    txt_PONo.Text = shorNAme & "/" & doctype & "/000001/" & financalyear

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

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Purchase Order"
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE  '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdAdd.Enabled = False
        Me.CmdFreeze.Enabled = False
        Me.CmdView.Enabled = False
        Me.CmdPrint.Enabled = False
        Me.cmd_export.Enabled = False
        Me.cmd_auth.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.CmdFreeze.Enabled = True
                    Me.CmdView.Enabled = True
                    Me.cmd_auth.Enabled = True
                    Me.cmd_export.Enabled = True
                    Me.CmdPrint.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.CmdAdd.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.CmdAdd.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.CmdAdd.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.CmdFreeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                    'Me.cmd_rpt.Enabled = True
                    Me.cmd_export.Enabled = True
                End If
                If Right(x) = "U" Then
                    Me.cmd_auth.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.CmdPrint.Enabled = True
                End If
            Next
        End If


    End Sub

    Private Sub binditemcode()
        Dim vform As New ListOperattion1

        sqlstring = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "'"
        gconnection.getDataSet(sqlstring, "Inv_VendorMaster")
        gSQLString = "select  distinct (I.itemcode),M.Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "




        If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then

            ' M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "' ) and itemcode not in (select itemcode from trnsView where storecode<>'" + Txt_Storecode.Text + "' and ttype='GRN') )"
            M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "' ) "

        Else
            ' M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and i.itemcode not in (select itemcode from trnsView where storecode<>'" + Txt_Storecode.Text + "' and ttype='GRN')"
            If UCase(gShortname) = "BRC" Then
                M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "' ) "
            Else
                M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' "
            End If
        End If

        vform.Field = " I.itemcode,m.Itemname,uom"
        vform.vFormatstring = "         itemcode        |                       Itemname                       |       Uom    "
        vform.vCaption = "ITEM MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2

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

                Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

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

                If UCase(gShortname) <> "SKYYE" Or gShortname <> "CFC" Or gShortname <> "HBC" Then
                    sql = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom, isnull(contractyn,'0') as contractyn FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "' and ITEMCODE='" + vform.keyfield + "'  AND cast('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE "
                    gconnection.getDataSet(sql, "Invitem_VendorMaster")
                    If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                        AxfpSpread1.Col = 3
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

                If cbo_warehouse.Text = "LIQ" Or cbo_warehouse.Text = "RAW" Then
                    sql = "SELECT TOP 1  rate as rate  FROM LiqRate  WHERE itemcode='" + Trim(vform.keyfield) + "' AND storecode='" + Txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y'ORDER BY grndate DESC"
                    gconnection.getDataSet(sql, "RATE")
                    If (gdataset.Tables("RATE").Rows.Count > 0) Then

                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                        AxfpSpread1.Lock = False
                    Else
                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        'AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                        AxfpSpread1.Lock = False
                    End If
                End If
                If UCase(gShortname) <> "CCL" Then
                    sql = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + Trim(vform.keyfield) + "'"
                    sql = sql & " AND CAST('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                    gconnection.getDataSet(sql, "Itemtaxtagging")

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
                        MessageBox.Show("No Tax Group found For Item  :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    End If
                End If
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            End If
        End If

    End Sub
    Private Sub binditemname()
        Dim vform As New ListOperattion1



        sqlstring = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "'"
        gconnection.getDataSet(sqlstring, "Inv_VendorMaster")

        gSQLString = "select  distinct (I.itemcode),Itemname,uom from  CLOSINGQTY  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then

            M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "')"

        Else
            M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' "
        End If
        vform.Field = " I.itemcode, m.Itemname,I.Uom "
        vform.vFormatstring = "    itemcode    |                   Itemname                    |          UOM         |"
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2

        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If check_Duplicate(vform.keyfield) = False Then
                AxfpSpread1.Col = 1
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.Col = 2
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield1)
                AxfpSpread1.Col = 3
                AxfpSpread1.Row = AxfpSpread1.ActiveRow

                Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                Next Z

                If UCase(gShortname) = "SKYYE" Or UCase(gShortname) = "CFC" Or UCase(gShortname) = "HBC" Then
                    Dim sql1 As String = "select ISNULL(DEFAULTUOM,'')AS DEFAULTUOM from inv_inventoryitemmaster where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                    gconnection.getDataSet(sql1, "DEFAULTUOM")
                    AxfpSpread1.Text = gdataset.Tables("DEFAULTUOM").Rows(0).Item("DEFAULTUOM")
                End If

                If UCase(gShortname) <> "SKYYE" Or gShortname <> "CFC" Or UCase(gShortname) <> "HBC" Then
                    sql = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom,isnull(contractyn,'0') as contractyn  FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "' and ITEMCODE='" + vform.keyfield + "' "
                    gconnection.getDataSet(sql, "Invitem_VendorMaster")
                    If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                        AxfpSpread1.Col = 3
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

                If cbo_warehouse.Text = "LIQ" Then
                    sql = "SELECT TOP 1  rate as rate  FROM LiqRate WHERE itemcode='" + Trim(vform.keyfield) + "' AND storecode='" + Txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y'ORDER BY grndate DESC"
                    gconnection.getDataSet(sql, "RATE")
                    If (gdataset.Tables("RATE").Rows.Count > 0) Then

                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                        AxfpSpread1.Lock = False
                    Else
                        AxfpSpread1.Col = 5
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        'AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                        AxfpSpread1.Lock = False
                    End If
                End If

                If UCase(gShortname) <> "CCL" Then
                    sql = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + Trim(vform.keyfield) + "'"
                    sql = sql & " AND CAST('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                    gconnection.getDataSet(sql, "Itemtaxtagging")
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
                        MessageBox.Show("Create TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    End If
                End If
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            End If
        End If

    End Sub

    Private Sub CALCULATE()
        Dim ITEMCODE, UOM As String
        ' Dim overalldisc, othercharge, extra As Double
        Dim totqty, totamt, taxamt, discamt, freeqty, totfreeqty, grossamt, BASaMT As Double
        Dim itemqty, itemrate, itemamount, itemtax, itemdisc, discperc, itemamountwithdisc, taxperc, itemtot, SPLCESS, ISPLCESS, TOSPLCESS As Double

        If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Or AxfpSpread1.ActiveCol = 7 Or AxfpSpread1.ActiveCol = 8 Or AxfpSpread1.ActiveCol = 10 Or AxfpSpread1.ActiveCol = 12 Or AxfpSpread1.ActiveCol = 18 Then

            For i As Integer = 1 To AxfpSpread1.DataRowCnt

                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                ITEMCODE = Trim(AxfpSpread1.Text)

                AxfpSpread1.Col = 3
                UOM = Trim(AxfpSpread1.Text)

                AxfpSpread1.Row = i
                AxfpSpread1.Col = 4
                itemqty = Val(AxfpSpread1.Text)
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 5
                itemrate = Val(AxfpSpread1.Text)

                AxfpSpread1.Row = i
                AxfpSpread1.Col = 6
                itemamount = itemqty * itemrate
                BASaMT = BASaMT + itemamount
                AxfpSpread1.Text = itemamount
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 7
                discperc = Val(AxfpSpread1.Text)

                If AxfpSpread1.Text = "0.00" Or AxfpSpread1.Text = "0.000" Or AxfpSpread1.Text = "" Then

                    AxfpSpread1.Col = 8
                    AxfpSpread1.Row = i

                    'taxperc = Val(AxfpSpread1.Text)
                    If AxfpSpread1.Text = "0.00" Or AxfpSpread1.Text = "0.000" Or AxfpSpread1.Text = "" Then
                        itemdisc = (itemamount * discperc) / 100
                        AxfpSpread1.Text = itemdisc
                    Else

                        itemdisc = Val(AxfpSpread1.Text)
                    End If

                Else
                    itemdisc = (itemamount * discperc) / 100
                    AxfpSpread1.Col = 8
                    AxfpSpread1.Text = itemdisc

                End If

                ' itemdisc = (itemamount * discperc) / 100
                itemamountwithdisc = itemamount - itemdisc
                AxfpSpread1.SetText(9, i, Val(itemamountwithdisc))

                AxfpSpread1.Row = i
                AxfpSpread1.Col = 11
                taxperc = Val(AxfpSpread1.Text)

                ' itemtax = Math.Round(Val(Math.Round((itemamountwithdisc * taxperc) / 100, 2)))
                AxfpSpread1.Col = 10
                ' itemtax = Math.Round((amtwithoutdisc * taxperc) / 100)
                If AxfpSpread1.Text = "NONE" Then
                    itemtax = Math.Round(Val(Math.Round((itemamountwithdisc * taxperc) / 100, 2)), 2)
                Else
                    itemtax = Val(Math.Round((itemamountwithdisc * taxperc) / 100, 2))
                End If

     


                If ITEMCODE <> "" And UOM <> "" Then

                    If Mid(CStr(CmdAdd.Text), 1, 1) = "A" Then
                        SPLCESS = GetSPLCESS(ITEMCODE, Trim(UOM))
                        ISPLCESS = (SPLCESS * itemqty)
                        AxfpSpread1.Col = 18
                        AxfpSpread1.Text = ISPLCESS
                    Else
                        'SPLCESS = GetSPLCESS(ITEMCODE, Trim(UOM))
                        'TOSPLCESS = (SPLCESS * itemqty)
                        AxfpSpread1.Col = 18
                        'AxfpSpread1.Text = TOSPLCESS
                        ISPLCESS = Val(AxfpSpread1.Text)
                    End If
                Else
                    AxfpSpread1.Col = 18
                    ISPLCESS = Format(AxfpSpread1.Text, "0.000")

                End If

                TOSPLCESS = TOSPLCESS + ISPLCESS

                itemtot = itemamountwithdisc + itemtax + ISPLCESS
                'AxfpSpread1.Col = 8
                ' AxfpSpread1.Text = itemdisc
                AxfpSpread1.Col = 12
                AxfpSpread1.Text = itemtax
                AxfpSpread1.Col = 13
                AxfpSpread1.Text = itemtot
                totqty = totqty + itemqty
                ' totfreeqty = totfreeqty + freeqty
                totamt = totamt + itemtot
                taxamt = taxamt + itemtax
                discamt = discamt + itemdisc
                grossamt = grossamt + itemtot

            Next

            '  txt_totdisc.Text = discamt
            Txt_TotalTax.Text = Math.Round(taxamt, 3)
            Txt_AddCess.Text = Math.Round(TOSPLCESS, 3)
            TXT_GROSSVALUE.Text = Math.Round(grossamt, 3)
            TextBox1.Text = Math.Round(BASaMT, 3)
            Call caloperation()
        End If
    End Sub

    Private Sub caloperation()
        Dim i, withoutvat, tottax, totqty, splcess, itemsplcess, totsplcess As Double
        Dim quantity, rate, vat, temp, discount As Double
        Dim ed, cst, modvat, ptax, octra, insurance, lst, extra As Double
        ed = cst = modvat = ptax = octra = insurance = lst = vat = 0
        grtot = 0 : grvat = 0 : totaldiscount = 0
        With AxfpSpread1
            ' .Width = 920
            '.Height = 120
            If .DataRowCnt > 1 Then ' For More than 1 item ordering 
                For i = 1 To .DataRowCnt
                    'QTY IN COL-4
                    .Col = 4
                    .Row = i
                    quantity = Val(.Text)
                    totqty = totqty + quantity
                    'RATE IN COL-6
                    .Col = 5
                    .Row = i
                    rate = Val(.Text)
                    temp = quantity * rate
                    'DISCOUNT IN COL-7
                    .Col = 7
                    .Row = i
                    discount = Val(.Text)
                    discount = (temp * discount) / 100 ' old delete this line
                    totaldiscount = totaldiscount + discount
                    temp = temp - discount
                    'VAT IN COL-8
                    .Col = 11
                    .Row = i
                    vat = (temp * Val(.Text)) / 100
                    'TOTAL IN A ROW COL-9
                    .Col = 13
                    .Row = i
                    grtot = grtot + Val(.Text)
                    grvat = grvat + vat
                    vat = 0
                    temp = 0
                    quantity = 0
                    rate = 0
                Next
                withoutvat = grtot - grvat
            Else ' For Only 1 item ordering
                'QTY IN COL-4
                .Col = 4
                .Row = 1
                quantity = Val(.Text)
                totqty = totqty + quantity
                'RATE IN COL-6
                .Col = 5
                .Row = 1
                rate = Val(.Text)
                temp = quantity * rate
                'DISCOUNT IN COL-7
                .Col = 7
                .Row = 1
                discount = Val(.Text)
                discount = (discount * temp) / 100
                totaldiscount = discount
                temp = temp - discount
                .Col = 11
                .Row = 1
                vat = (temp * Val(.Text)) / 100
                .Col = 13
                .Row = 1
                grtot = Val(.Text)
                grvat = vat
                temp = 0
                quantity = 0
                rate = 0
                withoutvat = grtot - grvat
            End If
        End With
        If Val(Me.TXT_OVERALLDISC.Text) > 0 Then
            withoutvat = withoutvat - Val(Me.TXT_OVERALLDISC.Text)
        End If
        '====================TAX CALCULATION======================
        'ed = Format((withoutvat * Val(Txt_ED.Text)) / 100, "0.00")
        'cst = Format((withoutvat * Val(Txt_CST.Text)) / 100, "0.00")
        'modvat = Format((withoutvat * Val(Txt_MODVat.Text)) / 100, "0.00")
        'ptax = Format((withoutvat * Val(Txt_PTax.Text)) / 100, "0.00")
        'octra = Format((withoutvat * Val(Txt_Octra.Text)) / 100, "0.00")
        'insurance = Format((withoutvat * Val(Txt_Insurance.Text)) / 100, "0.00")
        '  lst = Format((withoutvat * Val(Txt_LST.Text)) / 100, "0.00")
        'TOTAL TAX
        tottax = Format(grvat, "0.00")
        extra = Format(insurance + Val(TXT_TRANSPORT.Text) - Val(Me.TXT_OVERALLDISC.Text) + Val(txtothchargeplus.Text) - Val(txtothchargemin.Text), "0.00")
        '====================PO VALUE CALCULATION======================
        With AxfpSpread1
            '.Width = 920
            '.Height = 120
            grtot = 0
            temp = 0
            TXT_GROSSVALUE.Text = 0
            For i = 1 To .DataRowCnt
                .Col = 4
                .Row = i
                quantity = Val(.Text)
                .Col = 14
                .Row = i
                AxfpSpread1.Text = Format(((Val(quantity) / Val(totqty)) * Val(extra)), "0.00")
                'QTY IN COL-4
                .Col = 13
                .Row = i
                temp = Val(.Text)
                grtot = grtot + temp

                TXT_GROSSVALUE.Text = Val(grtot)

                '.Col = 10
                '.Row = i
                'temp = Val(.Text)
                '   TXT_GROSSVALUE.Text = Val(TXT_GROSSVALUE.Text) + Val(temp)
                TXT_GROSSVALUE.Refresh()

                temp = 0
            Next
        End With
        '=================================================================
        Labqty.Text = Format(Val(totqty), "0.00")
        Txt_POValue.Text = Format(Val((grtot)) + Val(TXT_CF.Text) + Val(TXT_TRANSPORT.Text) - Val(TXT_OVERALLDISC.Text) + Val(txtothchargeplus.Text) - Val(txtothchargemin.Text), "0.00")
        Txt_TotalVat.Text = Format(Val(grvat), "0.00")
        Txt_TotalTax.Text = Format(Val(tottax), "0.00")
        Txt_Balance.Text = Format(Val(Txt_POValue.Text) - Val(Txt_AdvanceAmt.Text), "0.00")

    End Sub
    Private Sub addoperation()
        Dim i As Integer
        Dim pono() As String
        ' pono = Split(Trim(txt_PONo.Text), "/")

        If CmdAdd.Text = "Add [F7]" Then

            Dim sqlstring As String = "insert into po_hdr ([pono] ,[PO_NO],[DOCTYPE] ,[storecode],[podate] ,[poquotno] ,[povendorcode] ,[podepartment] ,[poapprovedby] ,[postatus] , [potype],[povalidfrom],[povalidupto],"
            sqlstring = sqlstring & " [povalue] ,[pototalvat] ,[pototaltax] ,[pototaldiscount],[poadvance] ,[pobalance] ,[poterms],[pootherchgplus],[pootherchgmin],"
            sqlstring = sqlstring & "[podeliveryterms] ,podelivery, [pomcpo] ,[poremarks] ,[poclosure] ,[poquotdate],  "
            If gShortname = "BGC" Then
                sqlstring = sqlstring & "DELIVERTODEPT,DEPTCONPERSON,DEPTCONNO,DEPTCONEMAIL,DELIVERBYDATE,IND_MAT_REQNO,PTERM,DNO,DEPART,GSTAPPLICAPLE,"
            End If
            sqlstring = sqlstring & "[freeze] ,[adduser] ,[adddatetime],[POOVERALLDISC],[POCF],[POTRANSPORT],[POSALET],[PODESPMODE],[PODOCSTHROUGH],[totqty],[VERSIONNO]) Values("
            Call autogenerate()
            pono = Split(Trim(txt_PONo.Text), "/")
            sqlstring = sqlstring & "'" + txt_PONo.Text + "',"
            sqlstring = sqlstring & "'" + pono(2) + "',"
            sqlstring = sqlstring & "'" & doctype & "',"
            sqlstring = sqlstring & "'" & Txt_Storecode.Text & "',"

            sqlstring = sqlstring & "'" & Format(CDate(Cbo_PODate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & "'" & Me.Txt_QuotNo.Text & "',"
            sqlstring = sqlstring & "'" & Me.Txt_Vcode.Text & "',"
            sqlstring = sqlstring & "'" & Me.cbo_dept.Text & "',"
            sqlstring = sqlstring & "'" & Me.Cbo_Approvedby.Text & "',"
            sqlstring = sqlstring & "'" & Me.Cbo_POStatus.Text & "',"
            sqlstring = sqlstring & "'" & Me.CmbPoType.Text & "',"
            sqlstring = sqlstring & "'" & Format(CDate(dtpvalidfrom.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & "'" & Format(CDate(dtpvalidto.Value), "dd/MMM/yyyy") & "',"


            sqlstring = sqlstring & Format(Val(Me.Txt_POValue.Text), "0.000") & ","
            sqlstring = sqlstring & Format(Val(Me.Txt_TotalVat.Text), "0.000") & ","
            sqlstring = sqlstring & Format(Val(Me.Txt_TotalTax.Text), "0.000") & ","
            sqlstring = sqlstring & Format(Val(totaldiscount), "0.000") & ","
            sqlstring = sqlstring & Format(Val(Me.Txt_AdvanceAmt.Text), "0.0000") & ","
            sqlstring = sqlstring & Format(Val(Me.Txt_Balance.Text), "0.000") & ","
            sqlstring = sqlstring & "'" & Txt_POTerms.Text & "',"

            sqlstring = sqlstring & "'" & Format(Val(txtothchargeplus.Text), "0.000") & "',"
            sqlstring = sqlstring & "'" & Format(Val(txtothchargemin.Text), "0.000") & "',"
            sqlstring = sqlstring & "'" & Txt_DeliveryTerms.Text & "',"
            sqlstring = sqlstring & "'" & TXT_DELIVTERMS_DESC.Text & "',"
            sqlstring = sqlstring & "'N',"

            sqlstring = sqlstring & "'" & Replace(Trim(CStr(Txt_Remarks.Text)), "'", "?") & "',"
            sqlstring = sqlstring & "'N'," 'FOR CLOSURE DEFAULT NO
            sqlstring = sqlstring & "'" & Format(CDate(CBO_QUOT_DATE.Value), "dd/MMM/yyyy") & "',"

            If gShortname = "BGC" Then
                sqlstring = sqlstring & " '" & TXT_TODEPT.Text & "','" & TXT_DEPTCONPERSON.Text & "','" & TXT_DEP_CON_NO.Text & "','" & TXT_DEPT_CON_EMAIL.Text & "','" & Format(CDate(DTP_DELIVERDATE.Value), "dd/MMM/yyyy") & "','" & RICH_INDNO.Text & "','" & TXT_PTERM.Text & "','" & TXT_DNO.Text & "','" & TXT_DEPART.Text & "','" & RichTextBox1.Text & "',  "
            End If
            sqlstring = sqlstring & "'N',"

            sqlstring = sqlstring & "'" & Trim(gUsername) & "',"
            sqlstring = sqlstring & "getDate(),"

            sqlstring = sqlstring & Format(Val(Me.TXT_OVERALLDISC.Text), "0.000") & ","
            sqlstring = sqlstring & Format(Val(Me.TXT_CF.Text), "0.000") & ","
            sqlstring = sqlstring & Format(Val(Me.TXT_TRANSPORT.Text), "0.000") & ","

            sqlstring = sqlstring & " '" & txt_SalesTax.Text & "',"
            sqlstring = sqlstring & " '" & txt_MOD.Text & "',"
            sqlstring = sqlstring & " '" & TXT_DOCTHROUGH.Text & "',"
            sqlstring = sqlstring & " '" & Format(Val(Labqty.Text), "0.000") & "',"
            sqlstring = sqlstring & " '" & txt_PONo.Text + "-0" & "')"
            gconnection.dataOperation(6, sqlstring, "PO_HDR")
            With AxfpSpread1
                Dim itemcode, itemname, uom, quantity, sqlArray() As String
                Dim sql(Me.AxfpSpread1.DataRowCnt + 20) As String
                Dim requireddate As Date
                Dim rate, baseamt, discper, taxper, discount, vat, vattotal, total, Amount, DiscAmt, VatAmt, amountaftdisc, othchg, SPLCESS As Double
                For i = 1 To .DataRowCnt
                    .Col = 1
                    .Row = i
                    itemcode = .Text
                    If Trim(itemcode) <> "" Then
                        sql(i) = "INSERT INTO PO_ITEMDETAILS(PONO,ITEMCODE,itemname,UOM,QUANTITY,RATE,baseamount,discper,DiscAmt,amountafterdiscount,taxcode,taxper,VatAmt,TOTALamount,othchg,raterange,qtyrange,freeze,VERSIONNO,companycode,SPLCESS) Values("
                        sql(i) = sql(i) & "'" & txt_PONo.Text & "',"

                        sql(i) = sql(i) & "'" & itemcode & "',"
                        .Col = 2
                        .Row = i
                        itemname = .Text
                        sql(i) = sql(i) & "'" & itemname & "',"

                        .Col = 3
                        .Row = i
                        uom = .Text
                        sql(i) = sql(i) & "'" & uom & "',"
                        .Col = 4
                        .Row = i
                        quantity = Val(.Text)
                        sql(i) = sql(i) & "'" & quantity & "',"

                        '  requireddate = .Text
                        ' sql(i) = sql(i) & "'" & Format(requireddate, "dd-MMM-yyyy") & "',"
                        .Col = 5
                        .Row = i
                        rate = Val(.Text)
                        sql(i) = sql(i) & Format(Val(rate), "0.000") & ","
                        .Col = 6
                        .Row = i
                        baseamt = Val(.Text)
                        sql(i) = sql(i) & Format(Val(baseamt), "0.000") & ","

                        .Col = 7
                        .Row = i
                        discper = Val(.Text)
                        sql(i) = sql(i) & Format(Val(discper), "0.000") & ","
                        .Col = 8
                        .Row = i
                        '   discount = (rate * quantity * discper) / 100
                        discount = Val(.Text)
                        sql(i) = sql(i) & Format(Val(discount), "0.000") & ","
                        .Col = 9
                        .Row = i
                        amountaftdisc = Val(.Text)
                        sql(i) = sql(i) & Format(Val(amountaftdisc), "0.000") & ","
                        .Col = 10
                        .Row = i
                        '  Amount = .Text
                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        .Col = 11
                        .Row = i
                        taxper = Val(.Text)
                        ' DiscAmt = .Text
                        sql(i) = sql(i) & Format(Val(taxper), "0.000") & ","
                        .Col = 12
                        .Row = i
                        VatAmt = Val(.Text)
                        sql(i) = sql(i) & Format(Val(VatAmt), "0.000") & ","
                        .Col = 13
                        .Row = i
                        total = Val(.Text)
                        sql(i) = sql(i) & Format(Val(AxfpSpread1.Text), "0.000") & ","
                        .Col = 14
                        .Row = i
                        othchg = Val(.Text)
                        sql(i) = sql(i) & Format(Val(othchg), "0.000") & ","
                        .Col = 15
                        .Row = i

                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        .Col = 16
                        .Row = i

                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        sql(i) = sql(i) & "'N','" + txt_PONo.Text + "-0" + "',"
                        .Col = 17
                        .Row = i
                        sql(i) = sql(i) & "'" + AxfpSpread1.Text + "',"
                        .Col = 18
                        .Row = i
                        SPLCESS = Val(.Text)
                        sql(i) = sql(i) & Format(Val(SPLCESS), "0.000") & ")"
                    End If
                Next
                ReDim sqlArray(sql.Length)
                sqlArray.Copy(sql, sqlArray, sql.Length)
               

                gconnection.MoreTrans(sqlArray)

            End With

            Dim J As Integer
            Dim GROUPCODE() As String

            For J = 0 To ChkLst_Group.CheckedItems.Count - 1

                GROUPCODE = Split(ChkLst_Group.CheckedItems(J), "-->")

                sqlstring = "insert into PO_DELIVERYTERMS_DET ( PONO,  SNO ,    PODELIVERYTERMS ,  PODELIVERY) values ("
                sqlstring = sqlstring & " '" & txt_PONo.Text & "'," & Val(J + 1).ToString() & ",'" & Trim(GROUPCODE(0)) & "','" & Trim(GROUPCODE(1)) & "')"
                gconnection.dataOperation(6, sqlstring, "PO_HDR")
            Next

        End If
    End Sub
    Private Sub clearoperation()
        Call clearform(Me)
        Me.Txt_POTerms.Text = "CHQ"
        Me.TXT_PAYMTTERMS_DESC.Text = "CHEQUE"
        Me.Txt_DeliveryTerms.Text = "IMM"
        Me.TXT_DELIVTERMS_DESC.Text = "IMMEDIATELY"
        'Call Txt_DeliveryTerms_Validated(sender, e)
        Me.Txt_QuotNo.Text = "NA"
        txt_docno.Text = ""
        cbo_dept.Text = ""
        Me.CmdFreeze.Enabled = True
        Me.Cbo_POStatus.Text = "PENDING"
        Me.Cbo_Approvedby.Text = "PENDING FOR APPROVAL"
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        Label7.Text = ""
        Me.txt_PONo.Clear()
        Me.Txt_Vcode.Clear()
        'Me.Cbo_Approvedby.SelectedIndex = -1
        Me.Cbo_PODate.Value = DateTime.Now()
        Me.CBO_QUOT_DATE.Value = DateTime.Now()
        Me.Txt_Vname.Clear()
        Me.Txt_Storecode.Text = ""
        'Me.Cbo_POStatus.SelectedIndex = -1
        ' Me.Txt_ED.Clear()
        Me.Txt_CST.Clear()
        Me.Txt_MODVat.Clear()
        Me.Txt_PTax.Clear()
        Me.Txt_Octra.Clear()
        Me.Txt_Insurance.Clear()
        Me.Txt_LST.Clear()
        Me.Txt_POValue.Clear()
        'Me.Txt_POTerms.Clear()
        Me.Txt_TotalVat.Clear()
        Me.Txt_TotalTax.Clear()
        Me.Txt_AdvanceAmt.Clear()
        Me.Txt_Balance.Clear()
        Me.txtothchargeplus.Clear()
        Me.txtothchargemin.Clear()
        Me.txt_PONo.ReadOnly = False
        Me.Txt_POTerms.ReadOnly = False

        Me.chk_amnd_foll.Checked = False
        Chk_AllGroup.Checked = False
        Call FillDELIVERYTERM()
        Me.CmdAdd.Enabled = True
        Me.CmdFreeze.Enabled = True

        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.Enabled = True
        Me.TXT_GROSSVALUE.Text = ""
        Me.TXT_CF.Text = ""
        Me.TXT_TRANSPORT.Text = ""
        Me.TXT_OVERALLDISC.Text = ""
        Me.TXT_ADVANCEPERC.Text = ""
        Me.Txt_AddCess.Text = ""
        lbl_Freeze.Visible = False
        CMD_APPROVE.Visible = False

        If gShortname = "BGC" Then
            TXT_TODEPT.Text = ""
            TXT_DEPTCONPERSON.Text = ""
            TXT_DEPT_CON_EMAIL.Text = ""
            TXT_DEP_CON_NO.Text = ""
            RICH_INDNO.Text = ""
            TXT_PTERM.Text = ""
            TXT_DNO.Text = ""
            TXT_DEPART.Text = ""
            RichTextBox1.Text = ""

            DTP_DELIVERDATE.Value = DateTime.Now()
        End If

        'Me.AmendmentGrid.Visible = False
        'Me.FollowupGrid.Visible = False

        Me.Txt_Remarks.Clear()
        Call autogenerate()
        '  Me.cbo_dept.Focus()
        txt_docno.Focus()
        For k As Integer = 0 To 10
            For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                AxfpSpread1.TypeComboBoxClear(3, k)
            Next
        Next

    End Sub
    Private Sub voidoperation()
        If Mid(CmdFreeze.Text, 1, 1) = "F" Then

            If gShortname = "SKYYE" Then
                sqlstring = "SELECT isnull(APPROVE,'')as approve FROM PO_HDR WHERE pono='" & txt_PONo.Text & "' "
                gconnection.getDataSet(sqlstring, "updte")
                Dim APPR As String
                APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
                If APPR = "Y" Then
                    MsgBox("This Po is already Approved  You can't void  it ")
                    Exit Sub
                End If
            End If

            sqlstring = "UPDATE  PO_HDR "
            sqlstring = sqlstring & " SET Freeze= 'Y',Freezeuser='" & gUsername & " ', Freezedatetime='" & Format(Now, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "PO_HDR")
            sqlstring = "UPDATE  PO_ITEMDETAILS "
            sqlstring = sqlstring & " SET Freeze= 'Y'"
            sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "PO_HDR")

            CmdAdd.Text = "Add [F7]"

        End If
    End Sub

    Private Sub updateoperation()
        Dim i As Integer
        Dim insert(0) As String
        If Mid(CmdAdd.Text, 1, 1) = "U" And Me.lbl_Freeze.Visible = True Then
            MessageBox.Show(" The Freezed Record Cannot Be Updated", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            boolchk = False
        ElseIf Mid(CmdAdd.Text, 1, 1) = "U" And Me.lbl_Freeze.Visible = False Then
            sqlstring = " insert into PO_IMAGEHDR( [pono] ,[DOCTYPE] ,[storecode],[podate] ,[poquotno] ,[povendorcode] ,[podepartment] ,[poapprovedby] ,[postatus] , [potype],[povalidfrom],[povalidupto], "
            sqlstring = sqlstring & " [povalue] ,[pototalvat] ,[pototaltax] ,[pototaldiscount],[poadvance] ,[pobalance] ,[poterms],[pootherchgplus],[pootherchgmin],"
            sqlstring = sqlstring & "[podeliveryterms] , [pomcpo] ,[poremarks] ,[poclosure] ,  "
            sqlstring = sqlstring & "[freeze] ,[adduser] ,[adddatetime],[POOVERALLDISC],[POCF],[POTRANSPORT],[POSALET],[PODESPMODE],[PODOCSTHROUGH],[totqty],[versionno]) "

            sqlstring = sqlstring & " select [pono] ,[DOCTYPE] ,[storecode],[podate] ,[poquotno] ,[povendorcode] ,[podepartment] ,[poapprovedby] ,[postatus] , [potype],[povalidfrom],[povalidupto], "
            sqlstring = sqlstring & " [povalue] ,[pototalvat] ,[pototaltax] ,[pototaldiscount],[poadvance] ,[pobalance] ,[poterms],[pootherchgplus],[pootherchgmin],"
            sqlstring = sqlstring & "[podeliveryterms] , [pomcpo] ,[poremarks] ,[poclosure] ,  "
            sqlstring = sqlstring & "[freeze] ,[adduser] ,[adddatetime],[POOVERALLDISC],[POCF],[POTRANSPORT],[POSALET],[PODESPMODE],[PODOCSTHROUGH],[totqty],[versionno] "
            sqlstring = sqlstring & " from po_hdr where po_hdr.pono= '" & txt_PONo.Text & "'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring


            sqlstring = " Update   po_hdr set "
            sqlstring = sqlstring & " DOCTYPE='" & doctype & "',"
            sqlstring = sqlstring & " storecode='" & Me.Txt_Storecode.Text & "',"
            sqlstring = sqlstring & " podate='" & Format(CDate(Cbo_PODate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " poquotno='" & Me.Txt_QuotNo.Text & "',"
            sqlstring = sqlstring & " povendorcode='" & Me.Txt_Vcode.Text & "',"
            sqlstring = sqlstring & " podepartment='" & Me.cbo_dept.Text & "',"
            sqlstring = sqlstring & " poapprovedby='" & Me.Cbo_Approvedby.Text & "',"
            sqlstring = sqlstring & " postatus='" & Me.Cbo_POStatus.Text & "',"
            sqlstring = sqlstring & " potype='" & Me.CmbPoType.Text & "',"
            sqlstring = sqlstring & " POVALIDFROM='" & Format(CDate(dtpvalidfrom.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " povalidupto='" & Format(CDate(dtpvalidto.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " poquotdate='" & Format(CDate(CBO_QUOT_DATE.Value), "dd/MMM/yyyy") & "',"

            If gShortname = "BGC" Then
                sqlstring = sqlstring & " DELIVERTODEPT='" & TXT_TODEPT.Text & "',DEPTCONPERSON='" & TXT_DEPTCONPERSON.Text & "',DEPTCONNO='" & TXT_DEP_CON_NO.Text & "',DEPTCONEMAIL='" & TXT_DEPT_CON_EMAIL.Text & "',DELIVERBYDATE='" & Format(CDate(DTP_DELIVERDATE.Value), "dd/MMM/yyyy") & "',IND_MAT_REQNO='" & RICH_INDNO.Text & "',PTERM='" & TXT_PTERM.Text & "',DNO='" & TXT_DNO.Text & "',DEPART='" & TXT_DEPART.Text & "',GSTAPPLICAPLE='" & RichTextBox1.Text & "',"
            End If

            sqlstring = sqlstring & " povalue=" & Format(Val(Me.Txt_POValue.Text), "0.000") & ","
            sqlstring = sqlstring & " pototalvat=" & Format(Val(Me.Txt_TotalVat.Text), "0.000") & ","
            sqlstring = sqlstring & " pototaltax=" & Format(Val(Me.Txt_TotalTax.Text), "0.000") & ","
            sqlstring = sqlstring & " pototaldiscount=" & Format(Val(totaldiscount), "0.000") & ","
            sqlstring = sqlstring & " poadvance=" & Format(Val(Me.Txt_AdvanceAmt.Text), "0.000") & ","
            sqlstring = sqlstring & " pobalance =" & Format(Val(Me.Txt_Balance.Text), "0.000") & ","
            sqlstring = sqlstring & " poterms='" & Txt_POTerms.Text & "',"

            sqlstring = sqlstring & " pootherchgplus =" & Format(Val(Me.txtothchargeplus.Text), "0.000") & ","
            sqlstring = sqlstring & " pootherchgmin='" & Format(Val(Me.txtothchargemin.Text), "0.000") & "',"

            sqlstring = sqlstring & " podeliveryterms='" & Txt_DeliveryTerms.Text & "',"
            sqlstring = sqlstring & " podelivery='" & TXT_DELIVTERMS_DESC.Text & "',"
            sqlstring = sqlstring & " pomcpo='N',"

            sqlstring = sqlstring & " poremarks='" & Replace(Trim(CStr(Txt_Remarks.Text)), "'", "?") & "',"
            sqlstring = sqlstring & " poclosure='N'," 'FOR CLOSURE DEFAULT NO
            sqlstring = sqlstring & " freeze='N',"

            sqlstring = sqlstring & " adduser='" & Trim(gUsername) & "',"
            sqlstring = sqlstring & " adddatetime='" & Format(Now, "dd-MMM-yyyy") & "',"

            sqlstring = sqlstring & " POOVERALLDISC=" & Format(Val(Me.TXT_OVERALLDISC.Text), "0.000") & ","
            sqlstring = sqlstring & " POCF=" & Format(Val(Me.TXT_CF.Text), "0.000") & ","
            sqlstring = sqlstring & " POTRANSPORT=" & Format(Val(Me.TXT_TRANSPORT.Text), "0.000") & ","
            ' sqlstring = sqlstring & " PODELIVERYAMT=" & Format(Val(Me.TXT_DELIVERY.Text), "0.00") & ","
            sqlstring = sqlstring & " POSALET='" & txt_SalesTax.Text & "',"
            sqlstring = sqlstring & " PODESPMODE='" & txt_MOD.Text & "',"
            sqlstring = sqlstring & " PODOCSTHROUGH='" & TXT_DOCTHROUGH.Text & "',"
            sqlstring = sqlstring & " totqty=" & Format(Val(Me.Labqty.Text), "0.000") & ""

            sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'"

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring


            sqlstring = "INSERT INTO PO_ITEMDETAILS_LOG(PONO,ITEMCODE,itemname,UOM,QUANTITY,RATE,baseamount,discper,DiscAmt,amountafterdiscount,taxcode,taxper,VatAmt,TOTALamount,othchg,raterange,qtyrange,freeze,updateuser,updatedatetime,versionno,companycode,SPLCESS)  "
            sqlstring = sqlstring & " select PONO,ITEMCODE,itemname,UOM,QUANTITY,RATE,baseamount,discper,DiscAmt,amountafterdiscount,taxcode,taxper,VatAmt,TOTALamount,othchg,raterange,qtyrange,freeze,'" + gUsername + "',getdate(),versionno,companycode,SPLCESS "
            sqlstring = sqlstring & " from PO_ITEMDETAILS "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            sqlstring = "delete from PO_ITEMDETAILS WHERE PONO='" & txt_PONo.Text & "'"
            'gconnection.dataOperation(6, sqlstring, "PO_ITEMDETAILS")
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            With AxfpSpread1
                Dim itemcode, itemname, uom, quantity, sqlArray() As String
                Dim sql(Me.AxfpSpread1.DataRowCnt + 20) As String
                Dim requireddate As Date
                Dim rate, baseamt, discper, taxper, discount, vat, vattotal, total, Amount, DiscAmt, VatAmt, amountaftdisc, othchg, SPLCESS As Double
                For i = 1 To .DataRowCnt
                    .Col = 1
                    .Row = i
                    itemcode = .Text
                    If Trim(itemcode) <> "" Then
                        sql(i) = "INSERT INTO PO_ITEMDETAILS(PONO,ITEMCODE,itemname,UOM,QUANTITY,RATE,baseamount,discper,DiscAmt,amountafterdiscount,taxcode,taxper,VatAmt,TOTALamount,othchg,raterange,qtyrange,freeze,versionno,companycode,SPLCESS) Values("
                        sql(i) = sql(i) & "'" & txt_PONo.Text & "',"

                        sql(i) = sql(i) & "'" & itemcode & "',"
                        .Col = 2
                        .Row = i
                        itemname = .Text
                        sql(i) = sql(i) & "'" & itemname & "',"

                        .Col = 3
                        .Row = i
                        uom = .Text
                        sql(i) = sql(i) & "'" & uom & "',"
                        .Col = 4
                        .Row = i
                        quantity = Val(.Text)
                        sql(i) = sql(i) & "'" & quantity & "',"

                        '  requireddate = .Text
                        ' sql(i) = sql(i) & "'" & Format(requireddate, "dd-MMM-yyyy") & "',"
                        .Col = 5
                        .Row = i
                        rate = Val(.Text)
                        sql(i) = sql(i) & Format(Val(rate), "0.000") & ","
                        .Col = 6
                        .Row = i
                        baseamt = Val(.Text)
                        sql(i) = sql(i) & Format(Val(baseamt), "0.000") & ","

                        .Col = 7
                        .Row = i
                        discper = Val(.Text)
                        sql(i) = sql(i) & Format(Val(discper), "0.000") & ","
                        .Col = 8
                        .Row = i
                        '   discount = (rate * quantity * discper) / 100
                        discount = Val(.Text)
                        sql(i) = sql(i) & Format(Val(discount), "0.000") & ","
                        .Col = 9
                        .Row = i
                        amountaftdisc = Val(.Text)
                        sql(i) = sql(i) & Format(Val(amountaftdisc), "0.000") & ","
                        .Col = 10
                        .Row = i
                        '  Amount = .Text
                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        .Col = 11
                        .Row = i
                        taxper = Val(.Text)
                        ' DiscAmt = .Text
                        sql(i) = sql(i) & Format(Val(taxper), "0.000") & ","
                        .Col = 12
                        .Row = i
                        VatAmt = Val(.Text)
                        sql(i) = sql(i) & Format(Val(VatAmt), "0.000") & ","
                        .Col = 13
                        .Row = i
                        total = Val(.Text)
                        sql(i) = sql(i) & Format(Val(AxfpSpread1.Text), "0.000") & ","
                        .Col = 14
                        .Row = i
                        othchg = Val(.Text)
                        sql(i) = sql(i) & Format(Val(othchg), "0.000") & ","
                        .Col = 15
                        .Row = i

                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        .Col = 16
                        .Row = i

                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        sql(i) = sql(i) & "'N','" + txt_PONo.Text + "-0" + "',"
                        .Col = 17
                        .Row = i

                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        .Col = 18
                        .Row = i
                        SPLCESS = Val(.Text)
                        sql(i) = sql(i) & Format(Val(SPLCESS), "0.000") & ")"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sql(i)

                    End If
                Next


            End With

            gconnection.MoreTrans(insert)
            Dim J As Integer
            Dim GROUPCODE() As String

            sqlstring = "delete from PO_DELIVERYTERMS_DET where pono='" & txt_PONo.Text & "'"
            gconnection.dataOperation(6, sqlstring, "PO_HDR")
            For J = 0 To ChkLst_Group.CheckedItems.Count - 1

                GROUPCODE = Split(ChkLst_Group.CheckedItems(J), "-->")

                sqlstring = "insert into PO_DELIVERYTERMS_DET ( PONO,  SNO ,    PODELIVERYTERMS ,  PODELIVERY) values ("
                sqlstring = sqlstring & " '" & txt_PONo.Text & "'," & Val(J + 1).ToString() & ",'" & Trim(GROUPCODE(0)) & "','" & Trim(GROUPCODE(1)) & "')"
                gconnection.dataOperation(6, sqlstring, "PO_HDR")
            Next

        End If

    End Sub

    Private Function validateonupdate() As Boolean
        Dim STOCKUOM, uom As String
        Dim itemcode1 As String
        Dim flag As Boolean
        AxfpSpread1.Focus()
        Call CALCULATE()

        If DateDiff(DateInterval.Day, (CDate(Cbo_PODate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("PO date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If gShortname = "SKYYE" Then
            sqlstring = "SELECT  isnull(APPROVE,'')as approve FROM PO_HDR WHERE pono='" & txt_PONo.Text & "' "
            gconnection.getDataSet(sqlstring, "updte")
            Dim APPR As String
            APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
            If APPR = "Y" Then
                MsgBox("This Po is already Approved  You can't update it ")
                flag = True
                Return flag
            End If
        End If

        If cbo_warehouse.Text = "" Then

            flag = True
            Return flag
        End If
        If Txt_Storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Storecode.BackColor = Color.Red
            Txt_Storecode.Focus()
            flag = True
            Return flag
        Else
            Txt_Storecode.BackColor = Color.White

        End If
        If Trim(Label7.Text) <> "" Then
            MessageBox.Show("Purchase Order is in Process,You Can't Update it ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If txt_PONo.Text = "" Then
            MessageBox.Show("Please Fill POno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_PONo.BackColor = Color.Red
            txt_PONo.Focus()

            flag = True
            Return flag
        Else
            txt_PONo.BackColor = Color.White

        End If
        If Txt_Vcode.Text = "" Then
            MessageBox.Show("Please Fill Vendor Code ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Vcode.BackColor = Color.Red
            Txt_Vcode.Focus()

            flag = True
            Return flag
        Else
            Txt_Vcode.BackColor = Color.White

        End If
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)
            flag = True
            Return flag
        End If
        sql = "select postatus from PO_hdr where pono='" + txt_PONo.Text + "' "
        Dim postatus As String = gconnection.getvalue(sql)
        If (postatus <> "PENDING") Then
            MessageBox.Show("PO IS APPROVED YOU CANT UPDATE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag
        End If
        Dim ComVen As Boolean = check_VendorType(Txt_Vcode.Text)
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i


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

            AxfpSpread1.Col = 1



            itemcode1 = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            uom = AxfpSpread1.Text
            sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode1 + "'"
            STOCKUOM = gconnection.getvalue(sqlstring)
            sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
            gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '  CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                ' precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
            Else
                MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
                Exit Function
            End If

            AxfpSpread1.Col = 7
            Dim grndis As Double = Val(AxfpSpread1.Text)
            If (grndis > 100) Then
                MessageBox.Show("Discount Cannot be Greater than 100%", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.Text = ""
                AxfpSpread1.SetActiveCell(7, i)
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
                AxfpSpread1.SetActiveCell(8, i)
                flag = True
                Return flag

            End If

            SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + itemcode1 + "'"
            gconnection.getDataSet(SQL, "ITEM")
            If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then
                    AxfpSpread1.Col = 17
                    SQL = " select * from InvCompany_ItemMaster where COMPANYCODE='" + AxfpSpread1.Text + "' AND ITEMCODE='" + itemcode1 + "' "
                    gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                    If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then

                    Else
                        MessageBox.Show("Select Company Code .", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.Text = ""
                        AxfpSpread1.SetActiveCell(17, i)
                        flag = True
                        Return flag
                    End If
                End If
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


        Next
        Return False
    End Function

    Private Function validateoninsert() As Boolean
        Dim flag As Boolean
        Dim STOCKUOM, uom As String
        Dim itemcode1 As String
        AxfpSpread1.Focus()
        Call CALCULATE()
        If CmbPoType.Text = "" Then
            CmbPoType.SelectedIndex = 1
        End If

        Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd"))
        If checkBdate = True Then
            MsgBox("Business date closed..")
            flag = True
            Return flag
        End If
        If DateDiff(DateInterval.Day, (CDate(Cbo_PODate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("PO date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If cbo_warehouse.Text = "" Then

            flag = True
            Return flag
        End If
        If Txt_Storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Storecode.BackColor = Color.Red
            Txt_Storecode.Focus()

            flag = True
            Return flag
        Else
            Txt_Storecode.BackColor = Color.White
        End If
        If txt_PONo.Text = "" Then
            MessageBox.Show("Please Fill POno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_PONo.BackColor = Color.Red
            txt_PONo.Focus()

            flag = True
            Return flag
        Else
            txt_PONo.BackColor = Color.White

        End If
        If Txt_Vcode.Text = "" Then
            MessageBox.Show("Please Fill Vendor Code ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Vcode.BackColor = Color.Red
            Txt_Vcode.Focus()

            flag = True
            Return flag
        Else
            Txt_Vcode.BackColor = Color.White

        End If
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)





            flag = True
            Return flag


        End If

        Dim ComVen As Boolean = check_VendorType(Txt_Vcode.Text)

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            itemcode1 = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            uom = AxfpSpread1.Text
            sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode1 + "'"
            STOCKUOM = gconnection.getvalue(sqlstring)
            sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
            gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '  CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                ' precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
               
            Else
                MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                GmoduleName = "Uom Convertion Entry"
                Dim uomr As New FrmUOMRelation
                'uomr.MdiParent = Me
                uomr.baseuom = STOCKUOM
                uomr.transuom = uom
                uomr.ShowDialog()

                sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode1 + "'"
                STOCKUOM = gconnection.getvalue(sqlstring)
                sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
                gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    flag = False
                    Return flag
                Else
                    flag = True

                    Return flag
                End If
                Exit Function
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
                AxfpSpread1.SetActiveCell(8, i)
                flag = True
                Return flag

            End If

            SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + itemcode1 + "'"
            gconnection.getDataSet(SQL, "ITEM")
            If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then
                    AxfpSpread1.Col = 17
                    SQL = " select * from InvCompany_ItemMaster where COMPANYCODE='" + AxfpSpread1.Text + "' AND ITEMCODE='" + itemcode1 + "' "
                    gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                    If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then

                    Else
                        MessageBox.Show("Select Company Code .", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.Text = ""
                        AxfpSpread1.SetActiveCell(17, i)
                        flag = True
                        Return flag
                    End If
                End If
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

            AxfpSpread1.Col = 10
            Dim taxCODE As String = AxfpSpread1.Text
            AxfpSpread1.Col = 11
            Dim tax As Double = Val(AxfpSpread1.Text)
            If taxCODE <> "" Then
                SQL = "select ISNULL(sum(taxper),0)  as taxper from invtaxgroupmasterdetail where taxgroupcode='" + taxCODE + "' and ISNULL(void,'')<>'Y'"
                gconnection.getDataSet(SQL, "invtaxgroupmasterdetail")
                If (gdataset.Tables("invtaxgroupmasterdetail").Rows.Count > 0) Then
                    If (Val(gdataset.Tables("invtaxgroupmasterdetail").Rows(0).Item("taxper")) <> tax) Then
                        MessageBox.Show("Tax Groupcode and tax per. not matching ! ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If
            Else
                If tax <> 0 Then
                    MessageBox.Show("Tax Groupcode and tax per. not matching ! ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag
                End If
            End If

        Next
       

        'If check_taxcode() = True Then

        '    flag = True
        '    Return flag


        'End If
        Return False
    End Function

    Private Function check_Duplicate(ByVal Itemcode As String) As Boolean
        Dim i As Integer

        AxfpSpread1.Col = 1
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            If i <> AxfpSpread1.ActiveRow Then


                If Trim(AxfpSpread1.Text) = Trim(Itemcode) And Trim(Itemcode) <> "OPT" Then
                    MsgBox("Item Already exists", MsgBoxStyle.Critical, "Duplicate")
                    Return True
                End If
            End If

        Next
        Return False
    End Function
    Private Function check_tAXtYPE(ByVal TAXGROUP As String) As Boolean
        Dim i As Integer
        Dim VAT, GST, OTHER As Boolean
        AxfpSpread1.Col = 10
        AxfpSpread1.Text = TAXGROUP
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i


            SQL = "SELECT * FROM vW_iNV_TAX_TYPE  where taxgroupcode='" & AxfpSpread1.Text & "'"
            gconnection.getDataSet(SQL, "vW_iNV_TAX_TYPE")
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

    Private Sub bindtaxcode()

        Dim vform As New ListOperattion1


        gSQLString = "select i.taxgroupcode,sum(t.taxper) as Taxper,t.Effectfrom from  invtaxgroupmaster I INNER JOIN invtaxgroupmasterdetail T ON I.taxgroupcode=T.taxgroupcode  "

        M_WhereCondition = "  where isnull(i.void,'')<>'Y'  AND CAST('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(t.Effectfrom AS DATE) AND  CAST(ISNULL(t.effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' AS DATE) "
        M_Groupby = " GROUP BY i.taxgroupcode,t.Effectfrom "

        vform.Field = " i.Taxgroupcode "
        vform.vFormatstring = "    Taxgroupcode    |      Taxper        "
        vform.vCaption = "Tax MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1


        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_tAXtYPE(Trim(vform.keyfield))) = False Then
                AxfpSpread1.Col = 10
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.Col = 11
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield1)
                CALCULATE()

                If Mid(Trim(vform.keyfield), 1, 2) = "NO" Then
                    AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                End If
            End If

          
            ' AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)

        End If

    End Sub
   

    Private Sub bindCompany()
        Dim vform As New ListOperattion1

        gSQLString = "select companycode,COMPANYDESC from  InvCompany_ItemMaster  "

        M_WhereCondition = " where isnull(void,'')<>'Y'"
        vform.Field = " Taxgroupcode "
        vform.vFormatstring = "    Taxgroupcode    |      Taxper        "
        vform.vCaption = "Tax MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1


        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then


            AxfpSpread1.Col = 10
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield)
            AxfpSpread1.Col = 11
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield1)
            CALCULATE()

            If Mid(Trim(vform.keyfield), 1, 2) = "NO" Then
                AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
            Else
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
            End If
            ' AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)

        End If

    End Sub

    Private Sub cbo_dept_Validated(sender As Object, e As EventArgs) Handles cbo_dept.Validated
        Dim j As Integer
        If Trim(cbo_dept.Text) <> "" Then
            'sqlstring = "SELECT SLCODE,SLNAME,FREEZEFLAG FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & gCreditors & "' AND SLCODE='" & Trim(Txt_Vcode.Text) & "'"
            sqlstring = "Select * from  Invstore_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "'"
            gconnection.getDataSet(sqlstring, "Invstore_CategoryMaster")

            sqlstring = "SELECT isnull(STORECODE,'') AS STORECODE , ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER "
            If (gdataset.Tables("Invstore_CategoryMaster").Rows.Count > 0) Then
                sqlstring = sqlstring & " where STORECODE = '" & Txt_Storecode.Text & "' and storecode in (select storecode from Invstore_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "')"
            Else
                sqlstring = sqlstring & " where STORECODE = '" & Txt_Storecode.Text & "'"
            End If

            gconnection.getDataSet(sqlstring, "storecode1")
            If gdataset.Tables("storecode1").Rows.Count > 0 Then
                Txt_Storecode.Text = Trim(gdataset.Tables("storecode1").Rows(0).Item("STORECODE"))
                cbo_dept.Text = Trim(gdataset.Tables("storecode1").Rows(0).Item("STOREdesc"))
                Me.Txt_QuotNo.Focus()
            Else
                cbo_dept.Text = ""
                Me.cbo_dept.Focus()
            End If
            Call autogenerate()
        End If
    End Sub

  

    Private Sub Txt_POTerms_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_POTerms.KeyDown
        If Txt_POTerms.Text = "" Then
            Me.Cmd_POTermsHelp_Click(sender, e)
        Else
            Txt_POTerms_Validated(sender, e)
        End If
        Frm_PurchaseOrder_KeyDown(sender, e)
    End Sub

    Private Sub Txt_POTerms_Validated(sender As Object, e As EventArgs) Handles Txt_POTerms.Validated
        Dim j As Integer
        If Trim(Txt_POTerms.Text) <> "" Then
            sqlstring = "SELECT ISNULL(PAYMENTTERMCODE,0) AS PAYMENTTERMCODE,ISNULL(PAYMENTTERMDESC,'') AS PAYMENTTERMDESC FROM PO_PAYMENTTERMS WHERE PAYMENTTERMCODE = '" & Txt_POTerms.Text & "' "
            gconnection.getDataSet(sqlstring, "PO_PAYMENTTERMS")
            If gdataset.Tables("PO_PAYMENTTERMS").Rows.Count > 0 Then
                Txt_POTerms.Text = Trim(gdataset.Tables("PO_PAYMENTTERMS").Rows(0).Item("PAYMENTTERMCODE"))
                TXT_PAYMTTERMS_DESC.Text = Trim(gdataset.Tables("PO_PAYMENTTERMS").Rows(0).Item("PAYMENTTERMDESC"))
                'Me.Txt_POTerms.ReadOnly = True
                Me.Txt_DeliveryTerms.Focus()
            Else
                Me.Cmd_POTermsHelp_Click(sender, e)
            End If
        Else
            Me.Txt_POTerms.Focus()
        End If
    End Sub

   

    Private Sub Txt_DeliveryTerms_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_DeliveryTerms.KeyDown
        If Txt_POTerms.Text = "" Then
            Me.Cmd_DeliveryTermHelp_Click(sender, e)
        Else
            Txt_DeliveryTerms_Validated(sender, e)
        End If
        Frm_PurchaseOrder_KeyDown(sender, e)

    End Sub

    Private Sub Txt_DeliveryTerms_Validated(sender As Object, e As EventArgs) Handles Txt_DeliveryTerms.Validated
        Dim j As Integer
        If Trim(Txt_DeliveryTerms.Text) <> "" Then
            sqlstring = "SELECT ISNULL(DELIVERYTERMCODE,0) AS DELIVERYTERMCODE,ISNULL(DELIVERYTERMDESC,'') AS DELIVERYTERMDESC FROM PO_DELIVERYTERMS where deliverytermcode = '" & Txt_DeliveryTerms.Text & "' and isnull(freeze,'N')<>'Y' "
            gconnection.getDataSet(sqlstring, "PO_DELIVERYTERMS")
            If gdataset.Tables("PO_DELIVERYTERMS").Rows.Count > 0 Then
                Txt_DeliveryTerms.Text = Trim(gdataset.Tables("PO_DELIVERYTERMS").Rows(0).Item("DELIVERYTERMCODE"))
                TXT_DELIVTERMS_DESC.Text = Trim(gdataset.Tables("PO_DELIVERYTERMS").Rows(0).Item("DELIVERYTERMDESC"))
                Me.txt_SalesTax.Focus()
            Else
                Me.Cmd_DeliveryTermHelp_Click(sender, e)
            End If
        Else
            Me.txt_SalesTax.Focus()
        End If
    End Sub

   


    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String

        If e.keyCode = Keys.Enter Then
            i = AxfpSpread1.ActiveRow
            AxfpSpread1.Row = i
            'ITEMCODE

            If AxfpSpread1.ActiveCol = 1 Then
                AxfpSpread1.Col = 1


                If Trim(AxfpSpread1.Text) = "" Then
                    binditemcode()
                Else

                    sqlstring = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "'"
                    gconnection.getDataSet(sqlstring, "Inv_VendorMaster")


                    SQL = " select I.itemcode,M.Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  "
                    If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then

                        SQL = SQL & "  where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "') "

                    Else
                        If UCase(gShortname) = "BRC" Then
                            SQL = SQL & "  where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "')"
                        Else
                            SQL = SQL & " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "' "
                        End If

                    End If
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then
                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))

                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            SQL = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z

                            If UCase(gShortname) = "SKYYE" Or UCase(gShortname) = "CFC" Or UCase(gShortname) = "HBC" Then
                                Dim sql1 As String = "select ISNULL(DEFAULTUOM,'')AS DEFAULTUOM from inv_inventoryitemmaster where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                gconnection.getDataSet(sql1, "DEFAULTUOM")
                                AxfpSpread1.Text = gdataset.Tables("DEFAULTUOM").Rows(0).Item("DEFAULTUOM")
                            End If



                            If UCase(gShortname) <> "SKYYE" Or gShortname <> "CFC" Or UCase(gShortname) <> "HBC" Then
                                SQL = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom,isnull(contractyn,'0') as contractyn FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "' and ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND cast('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE  "
                                gconnection.getDataSet(SQL, "Invitem_VendorMaster")
                                If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                                    AxfpSpread1.Col = 3
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
                            If cbo_warehouse.Text = "LIQ" Then
                                SQL = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + Txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y'ORDER BY grndate DESC"
                                gconnection.getDataSet(SQL, "RATE")
                                If (gdataset.Tables("RATE").Rows.Count > 0) Then

                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    AxfpSpread1.Lock = False
                                Else
                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    'AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    AxfpSpread1.Lock = False
                                End If
                            End If
                            '   AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            If UCase(gShortname) <> "CCL" Then
                                SQL = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                SQL = SQL & " AND CAST('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                                gconnection.getDataSet(SQL, "Itemtaxtagging")
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
                                    MessageBox.Show("No Tax Group found For Item : " + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                End If
                            End If
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        End If
                    Else
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    End If
                End If

                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) <> "" Then
                    Dim item As String = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 3
                    If Trim(AxfpSpread1.Text) <> "" Then
                        Dim val As Double = GetSPLCESS(item, Trim(AxfpSpread1.Text))
                        AxfpSpread1.Col = 18
                        AxfpSpread1.Text = val
                    End If

                    Call UpdateHSNNO(item)
                End If
            ElseIf AxfpSpread1.ActiveCol = 2 Then
                AxfpSpread1.Col = 2
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemname()
                Else
                    sqlstring = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "'"
                    gconnection.getDataSet(sqlstring, "Inv_VendorMaster")

                    SQL = " select I.itemcode,M.Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  "

                    If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then

                        SQL = SQL & "  where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and isnull(m.itemNAME,'')='" + Trim(AxfpSpread1.Text) + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "'  "

                    Else
                        SQL = SQL & "     where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and isnull(m.itemNAME,'')='" + Trim(AxfpSpread1.Text) + "'"
                    End If
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If (check_Duplicate(Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode"))) = False) Then
                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            SQL = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z


                            If UCase(gShortname) = "SKYYE" Or UCase(gShortname) = "CFC" Or UCase(gShortname) = "HBC" Then
                                Dim sql1 As String = "select ISNULL(DEFAULTUOM,'')AS DEFAULTUOM from inv_inventoryitemmaster where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                gconnection.getDataSet(sql1, "DEFAULTUOM")
                                AxfpSpread1.Text = gdataset.Tables("DEFAULTUOM").Rows(0).Item("DEFAULTUOM")
                            End If


                            SQL = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom,isnull(contractyn,'0') as contractyn FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "' and ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND cast('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' as date) BETWEEN FROMDATE AND TODATE "
                            gconnection.getDataSet(SQL, "Invitem_VendorMaster")
                            If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                                AxfpSpread1.Col = 3
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
                            If cbo_warehouse.Text = "LIQ" Then
                                SQL = "SELECT TOP 1   rate as rate  FROM LiqRate WHERE itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' AND storecode='" + Txt_Storecode.Text + "' and isnull(RET_QTY,0)=0 and isnull(Voiditem,'N')<>'Y'ORDER BY grndate DESC"
                                gconnection.getDataSet(SQL, "RATE")
                                If (gdataset.Tables("RATE").Rows.Count > 0) Then

                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    AxfpSpread1.Lock = False
                                Else
                                    AxfpSpread1.Col = 5
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    'AxfpSpread1.Text = gdataset.Tables("RATE").Rows(0).Item("rate") ') / Val(gdataset.Tables("RATE").Rows(0).Item("CLOSINGSTOCK"))
                                    AxfpSpread1.Lock = False
                                End If
                            End If
                            If UCase(gShortname) <> "CCL" Then
                                SQL = "SELECT i.TaxCode,SUM(taxper) as taxper,Effectfrom FROM Itemtaxtagging I INNER JOIN invtaxgroupmasterdetail T ON I.TaxCode=T.taxgroupcode  where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                SQL = SQL & " AND CAST('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' AS DATE)>=CAST(Effectfrom AS DATE) AND  CAST(ISNULL(effectto,GETDATE()) AS DATE)>= CAST('" & Format(CDate(Cbo_PODate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY i.TaxCode,Effectfrom"
                                gconnection.getDataSet(SQL, "Itemtaxtagging")
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
                                    MessageBox.Show("Create TaxCode For Item :" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                                End If
                            End If
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        End If

                    Else
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    End If
                End If
                'QTY
            ElseIf AxfpSpread1.ActiveCol = 4 Then
                Dim POQTY As Double
                AxfpSpread1.Col = 4

                If Trim(AxfpSpread1.Text) = "" Or Val(AxfpSpread1.Text) = 0 Then

                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                Else
                    POQTY = Val(AxfpSpread1.Text)

                    If (potype = "RATE IN RANGE QUANTITY IN RANGE") Then

                        Dim message, title, defaultValue As String
                        Dim myValue As Object
                        message = "Enter Quantity Range"
                        title = "Quantity Range"
                        defaultValue = 10
                        myValue = InputBox(message, title, defaultValue)
                        If myValue = "" Then myValue = defaultValue
                        AxfpSpread1.Col = 15
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = myValue
                    Else
                        AxfpSpread1.Col = 15
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = 0
                    End If

                    AxfpSpread1.Col = 1
                    Dim icode As String = Trim(AxfpSpread1.Text)
                    If check_VendorTypeRU(Txt_Vcode.Text, icode) Then
                        AxfpSpread1.Col = 13
                        AxfpSpread1.Lock = False
                        AxfpSpread1.SetActiveCell(13, AxfpSpread1.ActiveRow)

                    Else

                        CALCULATE()

                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    End If

                    'CALCULATE()
                    'AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    check_MinMaxQTY("X", Trim(Txt_Storecode.Text), icode, POQTY)

                End If



                'RATE
            ElseIf AxfpSpread1.ActiveCol = 5 Then
                AxfpSpread1.Col = 5
                If Trim(AxfpSpread1.Text) = "" Or Val(AxfpSpread1.Text) = 0 Then
                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                Else
                    If (potype = "RATE IN RANGE QUANTITY IN RANGE") Then
                        Dim message, title, defaultValue As String
                        Dim myValue As Object
                        message = "Enter Rate Range"
                        title = "Rate Range"
                        defaultValue = 10
                        myValue = InputBox(message, title, defaultValue)
                        If myValue = "" Then myValue = defaultValue
                        AxfpSpread1.Col = 16
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = myValue
                    Else
                        AxfpSpread1.Col = 16
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = 0
                    End If
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(7, AxfpSpread1.ActiveRow)

                End If
                'DISC%

            ElseIf AxfpSpread1.ActiveCol = 7 Then
                AxfpSpread1.Col = 7

                If Trim(AxfpSpread1.Text) = "0.00" Or Trim(AxfpSpread1.Text) = "" Then
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

                If Trim(AxfpSpread1.Text) = "" Or Trim(AxfpSpread1.Text) = "0.00" Then
                    AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.Col = 6
                    Dim A As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 8
                    If A >= Val(AxfpSpread1.Text) Then
                        AxfpSpread1.Col = 7
                        Dim b As Double = Val(AxfpSpread1.Text)
                        If Trim(AxfpSpread1.Text) = "" Or Trim(AxfpSpread1.Text) = "0.00" Then
                            AxfpSpread1.Col = 8
                            Dim Discount As Double = Val(AxfpSpread1.Text)

                            AxfpSpread1.Col = 7
                            AxfpSpread1.Text = (Discount * 100) / (A)

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
                    AxfpSpread1.Col = 10
                    If Mid(AxfpSpread1.Text, 1, 4) = "NONE" Then
                        AxfpSpread1.SetActiveCell(12, i)
                    Else
                        ' AxfpSpread1.SetActiveCell(1, i + 1)
                    End If
                Else
                    If (check_tAXtYPE(Trim(AxfpSpread1.Text))) = False Then
                        SQL = "select taxper from invtaxgroupmaster where taxgroupcode='" + AxfpSpread1.Text + "' "
                        Dim taxper As Double = gconnection.getvalue(SQL)

                        AxfpSpread1.Col = 11
                        AxfpSpread1.SetText(11, i, Val(taxper))
                        CALCULATE()
                        AxfpSpread1.Col = 10

                        If Mid(AxfpSpread1.Text, 1, 4) = "NONE" Then
                            AxfpSpread1.SetActiveCell(12, i)
                        Else
                            'AxfpSpread1.SetActiveCell(1, i + 1)
                        End If
                    End If



                End If
                AxfpSpread1.Col = 1
                '  SQL = "select * from InvCompany_ItemMaster where ITEMCODE='" + AxfpSpread1.Text + "' "

                SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(SQL, "ITEM")
                If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                    If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then

                        SQL = " select * from InvCompany_ItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                        gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                        If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then
                            If Val(gdataset.Tables("InvCompany_ItemMaster").Rows.Count) = 1 Then
                                AxfpSpread1.Col = 17
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.Col = 17
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(17, i)
                            End If
                        Else
                            AxfpSpread1.Col = 17
                            AxfpSpread1.ColHidden = False
                            AxfpSpread1.SetActiveCell(17, i)
                        End If
                    Else
                        AxfpSpread1.Col = 10
                        If Mid(AxfpSpread1.Text, 1, 2) = "NO" Then
                            AxfpSpread1.SetActiveCell(12, i)
                        Else
                            AxfpSpread1.SetActiveCell(1, i + 1)
                        End If
                    End If
                Else
                    AxfpSpread1.Col = 10
                    If Mid(AxfpSpread1.Text, 1, 2) = "NO" Then
                        AxfpSpread1.SetActiveCell(12, i)
                    Else
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    End If
                End If



            ElseIf AxfpSpread1.ActiveCol = 12 Then

                Dim BA, TP, TA As Double
                AxfpSpread1.Col = 9
                BA = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 12
                TA = Val(AxfpSpread1.Text)
                If TA = 0 Then
                    AxfpSpread1.SetActiveCell(12, i)
                Else
                    TP = (TA * 100) / BA
                    AxfpSpread1.Col = 11
                    AxfpSpread1.SetText(11, i, TP)

                    'AxfpSpread1.SetActiveCell(1, i + 1)
                    AxfpSpread1.Col = 12
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(1, i + 1)
                End If
                'TP = Math.Round((TA * 100) / BA)

                AxfpSpread1.ActiveCol = 1

                SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(SQL, "ITEM")
                If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                    If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then

                        SQL = " select * from InvCompany_ItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                        gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                        If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then
                            If Val(gdataset.Tables("InvCompany_ItemMaster").Rows.Count) = 1 Then
                                AxfpSpread1.Col = 17
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.Col = 17
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(17, i)
                            End If
                        Else
                            AxfpSpread1.Col = 17
                            AxfpSpread1.ColHidden = False
                            AxfpSpread1.SetActiveCell(17, i)
                        End If
                    Else
                        If TA = 0 Then
                            AxfpSpread1.SetActiveCell(12, i)
                        Else
                            TP = (TA * 100) / BA
                            AxfpSpread1.Col = 11
                            AxfpSpread1.SetText(11, i, TP)

                            'AxfpSpread1.SetActiveCell(1, i + 1)
                            AxfpSpread1.Col = 12
                            CALCULATE()
                            AxfpSpread1.SetActiveCell(1, i + 1)
                        End If
                    End If
                Else
                    If TA = 0 Then
                        AxfpSpread1.SetActiveCell(12, i)
                    Else
                        TP = (TA * 100) / BA
                        AxfpSpread1.Col = 11
                        AxfpSpread1.SetText(11, i, TP)

                        'AxfpSpread1.SetActiveCell(1, i + 1)
                        AxfpSpread1.Col = 12
                        CALCULATE()
                        AxfpSpread1.SetActiveCell(1, i + 1)
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
                                AxfpSpread1.Col = 17
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = Trim(vform.keyfield)
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            End If
                        Else
                            Dim ITEM As String
                            AxfpSpread1.Col = 1
                            ITEM = AxfpSpread1.Text
                            SQL = " select * from InvCompany_ItemMaster where COMPANYCODE='" + AxfpSpread1.Text + "' AND ITEMCODE='" + ITEM + "' "
                            gconnection.getDataSet(SQL, "InvCompany_ItemMaster")
                            If (gdataset.Tables("InvCompany_ItemMaster").Rows.Count > 0) Then


                                AxfpSpread1.Col = 17
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("InvCompany_ItemMaster").Rows(0).Item("COMPANYCODE")
                                AxfpSpread1.ColHidden = False
                                AxfpSpread1.SetActiveCell(1, i + 1)
                            Else
                                AxfpSpread1.Col = 17
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = ""
                                AxfpSpread1.SetActiveCell(17, i)
                            End If

                        End If
                    Else
                        AxfpSpread1.SetActiveCell(1, i + 1)
                    End If
                Else
                    AxfpSpread1.SetActiveCell(1, i + 1)
                End If
            ElseIf AxfpSpread1.ActiveCol = 18 Then
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) <> "" Then
                    Dim item As String = Trim(AxfpSpread1.Text)
                    AxfpSpread1.Col = 3
                    If Trim(AxfpSpread1.Text) <> "" Then
                        Dim val As Double = GetSPLCESS(item, Trim(AxfpSpread1.Text))
                        AxfpSpread1.Col = 4
                        Dim GQTY As Double = AxfpSpread1.Text
                        AxfpSpread1.Col = 18
                        AxfpSpread1.Text = (val * GQTY)
                        CALCULATE()
                    End If
                End If
            End If
        ElseIf e.keyCode = Keys.F1 Then
            Txt_Remarks.Focus()
        ElseIf e.keyCode = Keys.F3 Then
            If Mid(CmdAdd.Text, 1, 1).ToUpper() = "A" Then
                caloperation()
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
            End If
        ElseIf e.keyCode = Keys.F2 Then


            AxfpSpread1.Col = 1
            Dim ITEMCODE As String = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            Dim UOM As String = AxfpSpread1.Text

            gconnection.closingStock(Format(Cbo_PODate.Value, "dd/MMM/yyyy"), ITEMCODE, Trim(Txt_Storecode.Text), "")
            Dim uom1 As String = gdataset.Tables("closingstock").Rows(0).Item("uom")
            Dim closingqty As Double = gdataset.Tables("closingstock").Rows(0).Item("closingstock")

            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + UOM + "' and transuom='" + uom1 + "'"
                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                Dim convvalue1 As Double
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    MessageBox.Show("Please Create relation Between " + UOM + " and " + uom1)
                    Exit Sub
                End If

                closingqty = Format(closingqty / convvalue1, "0.000")


                lbl_closingqty.Text = "" + ITEMCODE + " has closing qty is " + closingqty.ToString() + "  " + UOM



            End If



        End If


    End Sub

    Private Sub cbo_warehouse_GotFocus(sender As Object, e As EventArgs) Handles cbo_warehouse.GotFocus
        cbo_warehouse.BackColor = Color.Gold
    End Sub

    Private Sub cbo_warehouse_KeyDown(sender As Object, e As KeyEventArgs) Handles cbo_warehouse.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Txt_Storecode.Focus()
            'Call cmd_DeptHelp_Click(cmd_DeptHelp, e)
        End If

        Frm_PurchaseOrder_KeyDown(sender, e)
        '' Catch ex As Exception
    End Sub

    Private Sub cbo_warehouse_LostFocus(sender As Object, e As EventArgs) Handles cbo_warehouse.LostFocus
        cbo_warehouse.BackColor = Color.White
    End Sub

    Private Sub cbo_warehouse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_warehouse.SelectedIndexChanged

        Try
            'Call FOOTER()
            If CmdAdd.Text = "Add [F7]" Then
                If Mid(UCase(gCompanyname), 1, 6) = "KARNAT" Then
                    ' doctype = "PUR"
                    doctype = Trim(cbo_warehouse.Text)
                    Call autogenerate()
                Else
                    doctype = Trim(cbo_warehouse.Text)
                    'Call autogenerate_Inv()
                    Call autogenerate()
                    Txt_Storecode.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

  

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
    End Sub

    Private Sub Txt_Storecode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Storecode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmd_DeptHelp.Enabled = True Then
                Call cmd_DeptHelp_Click(cmd_DeptHelp, e)
            End If
      

        End If


    End Sub

    'Private Sub Txt_ED_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    getNumeric(e)
    '    If Asc(e.KeyChar) = 13 Then
    '        If Format(Val(Txt_ED.Text), "0.00") > 100 Then
    '            MsgBox("PERCENTAGE SHOULD BE LESS THAN 100")
    '            Txt_ED.Text = ""
    '            Txt_ED.Focus()
    '            Exit Sub
    '        End If
    '        Call AxfpSpread1_Leave(sender, e)
    '        Txt_CST.Focus()
    '    End If
    'End Sub

   
    Private Sub Txt_CST_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_CST.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Format(Val(Txt_CST.Text), "0.00") > 100 Then
                MsgBox("PERCENTAGE SHOULD BE LESS THAN 100")
                Txt_CST.Text = ""
                Txt_CST.Focus()
                Exit Sub
            End If
            Call AxfpSpread1_Leave(sender, e)
            Txt_MODVat.Focus()
        End If
    End Sub

    Private Sub Txt_CST_TextChanged(sender As Object, e As EventArgs) Handles Txt_CST.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_CST.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            '  Txt_ED.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub Txt_MODVat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_MODVat.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Format(Val(Txt_MODVat.Text), "0.00") > 100 Then
                MsgBox("PERCENTAGE SHOULD BE LESS THAN 100")
                Txt_MODVat.Text = ""
                Txt_MODVat.Focus()
                Exit Sub
            End If
            Call AxfpSpread1_Leave(sender, e)
            Txt_PTax.Focus()
        End If

    End Sub



    Private Sub Txt_MODVat_TextChanged(sender As Object, e As EventArgs) Handles Txt_MODVat.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_MODVat.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            Txt_MODVat.Text = "0.00"
            Exit Sub
        End If
    End Sub

    Private Sub Txt_PTax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_PTax.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Format(Val(Txt_Octra.Text), "0.00") > 100 Then
                MsgBox("PERCENTAGE SHOULD BE LESS THAN 100")
                Txt_PTax.Text = ""
                Txt_PTax.Focus()
                Exit Sub
            End If
            Call AxfpSpread1_Leave(sender, e)
            Txt_Octra.Focus()
        End If

    End Sub

    Private Sub Txt_PTax_TextChanged(sender As Object, e As EventArgs) Handles Txt_PTax.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_MODVat.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            ' Txt_ED.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub Txt_Octra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Octra.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Format(Val(Txt_Octra.Text), "0.00") > 100 Then
                MsgBox("PERCENTAGE SHOULD BE LESS THAN 100")
                Txt_PTax.Text = ""
                Txt_PTax.Focus()
                Exit Sub
            End If
            Call AxfpSpread1_Leave(sender, e)
            Txt_Insurance.Focus()
        End If
    End Sub

    Private Sub Txt_Octra_TextChanged(sender As Object, e As EventArgs) Handles Txt_Octra.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_Octra.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            Txt_Octra.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub Txt_Insurance_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Insurance.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Format(Val(Txt_Insurance.Text), "0.00") > 100 Then
                MsgBox("PERCENTAGE SHOULD BE LESS THAN 100")
                Txt_Insurance.Text = ""
                Txt_Insurance.Focus()
                Exit Sub
            End If
            Call AxfpSpread1_Leave(sender, e)
            TXT_TRANSPORT.Focus()
        End If
    End Sub

    Private Sub Txt_Insurance_TextChanged(sender As Object, e As EventArgs) Handles Txt_Insurance.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_Insurance.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            Txt_Insurance.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub Txt_LST_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_LST.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Format(Val(Txt_LST.Text), "0.00") > 100 Then
                MsgBox("PERCENTAGE SHOULD BE LESS THAN 100")
                Txt_LST.Text = ""
                Txt_LST.Focus()
                Exit Sub
            End If
            Call AxfpSpread1_Leave(sender, e)
            Txt_POTerms.Focus()
        End If

    End Sub




    Private Sub Txt_LST_TextChanged(sender As Object, e As EventArgs) Handles Txt_LST.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_LST.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            Txt_LST.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub TXT_ADVANCEPERC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_ADVANCEPERC.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Format(Val(TXT_ADVANCEPERC.Text), "0.00") > 100 Then
                MsgBox("PERCENTAGE SHOULD BE LESS THAN 100")
                TXT_ADVANCEPERC.Text = ""
                TXT_ADVANCEPERC.Focus()
                Exit Sub
            End If
            Call AxfpSpread1_Leave(sender, e)
            txt_SalesTax.Focus()
        End If

    End Sub



    Private Sub TXT_ADVANCEPERC_TextChanged(sender As Object, e As EventArgs) Handles TXT_ADVANCEPERC.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(TXT_ADVANCEPERC.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            TXT_ADVANCEPERC.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub AxfpSpread1_Leave(sender As Object, e As EventArgs) Handles AxfpSpread1.Leave
        caloperation()
    End Sub
  
    Private Sub CmdClear_Click(sender As Object, e As EventArgs) Handles CmdClear.Click
        clearoperation()
        If gValidity = False Then
            Me.CmdAdd.Enabled = False
            Me.cmd_auth.Enabled = False
            Me.CmdFreeze.Enabled = False
        End If
    End Sub

  
    Private Sub CmdAdd_Click(sender As Object, e As EventArgs) Handles CmdAdd.Click
        If CmdAdd.Text = "Add [F7]" Then
            'Call autogenerate()
            If validateoninsert() = False Then
                addoperation()
                Call UpdateGST("PO", Trim(txt_PONo.Text), Format(CDate(Cbo_PODate.Value), "dd/MMM/yyyy"))
                clearoperation()


            End If


        ElseIf Mid(CmdAdd.Text, 1, 1) = "U" Then
            If validateonupdate() = False Then

                updateoperation()
                Call UpdateGST("PO", Trim(txt_PONo.Text), Format(CDate(Cbo_PODate.Value), "dd/MMM/yyyy"))
                clearoperation()
            End If

        End If

    End Sub

    Private Sub CmdFreeze_Click(sender As Object, e As EventArgs) Handles CmdFreeze.Click

        If MessageBox.Show("Do You Want void it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then
            Exit Sub
        End If

        voidoperation()
        clearoperation()
    End Sub

  
    Private Sub txt_PONo_Validated(sender As Object, e As EventArgs) Handles txt_PONo.Validated
        Dim sqlstring, financalyear As String
        Dim voucherno As String
        Dim CreditDebit As String
        Dim i, j As Integer
        Dim amount As Double
        Dim accounthead, slhead, costhead As String

        PoNumber = Nothing

        If Trim(Me.txt_PONo.Text) <> "" Then
            'voucherno = VOUCHERNOVALIDATE()
            'sqlstring = "Select * From JournalEntry Where VoucherNo='" & voucherno & "' and VoucherType='" & Trim(Me.Txt_VoucherPrefix.Text) & "' Order By OppAccountCode,CreditDebit"
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            If Val(Me.txt_PONo.Text) > 0 Then
                'Me.txt_PONo.Text = "PUR" & "/" & Format(Val(Me.txt_PONo.Text), "000000") & "/" & financalyear
                Me.txt_PONo.Text = doctype & "/" & Format(Val(Me.txt_PONo.Text), "000000") & "/" & financalyear
            End If
            Call VOUCHERNOVALIDATIONS(Me.txt_PONo.Text, "PUR")
            Call validateFillDELIVERYTERM()
            PoNumber = Trim(Me.txt_PONo.Text)
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            'GetRights()
        End If
        If Mid(CmdAdd.Text, 1, 1) = "U" Then
            CMD_APPROVE.Visible = True
        Else
            CMD_APPROVE.Visible = False
        End If
    End Sub

    Private Sub VOUCHERNOVALIDATIONS(ByVal VoucherNo As String, ByVal VoucherType As String)
        Dim I, J, K As Integer
        Dim strsql, itemcode, Remarks As String
        Dim e As System.EventArgs
        If Trim(txt_PONo.Text) <> "" Then

            AxfpSpread1.ClearRange(1, 1, -1, -1, True)
            For Mk As Integer = 0 To 10
                For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                    AxfpSpread1.TypeComboBoxClear(3, Mk)
                Next
            Next


            strsql = "SELECT ISNULL(PODESPMODE,'') AS PODESPMODE,ISNULL(PODOCSTHROUGH,'') AS PODOCSTHROUGH,ISNULL(POSALET,'') AS POSALET,ISNULL(totGSTAmt,0) AS totGSTAmt,ISNULL(totCGSTAmt,0) AS totCGSTAmt,ISNULL(totSGSTAmt,0) AS totSGSTAmt,ISNULL(totIGSTAmt,0 )AS totIGSTAmt , ISNULL(totGSTAmt,0 )AS totGSTAmt ,*  FROM PO_HDR WHERE pono='" & Trim(txt_PONo.Text) & "' and postatus<>'AMENDED' "
            gconnection.getDataSet(strsql, "PO_HDR")
            If gdataset.Tables("PO_HDR").Rows.Count > 0 Then

                'If Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("TotGSTAmt"))) = Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("TotSGSTAmt"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("TotCGSTAmt"))) + Val(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("TotIGSTAmt"))) Then
                '    VATFLAG = False
                'Else
                '    VATFLAG = True
                'End If



                'If Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DOCTYPE")) = "DRY" Then
                '    cbo_warehouse.Text = "DRY RATION"
                'ElseIf Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DOCTYPE")) = "GDN" Then
                '    cbo_warehouse.Text = "GODOWN"
                'End If

                ' cbo_warehouse.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POdepartment"))
                Dim index As Integer
                index = cbo_warehouse.FindString(Trim(gdataset.Tables("PO_HDR").Rows(0).Item("doctype")))
                ' cbo_warehouse.SelectedIndex = index
                cbo_warehouse.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("doctype"))
                txt_PONo.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PONO"))

                ' cbo_warehouse.FindString()
                ' TXT_ADVANCEPERC.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POADVPERC"))
                txt_MOD.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODESPMODE"))
                TXT_DOCTHROUGH.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODOCSTHROUGH"))
                txt_SalesTax.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POSALET"))
                Cbo_PODate.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODATE"))
                dtpvalidfrom.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("povalidfrom"))

                dtpvalidto.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("povalidupto"))
                CBO_QUOT_DATE.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("poquotdate"))

                cbo_dept.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODepartment"))
                '  txt_docno.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("auth_docno"))
                Txt_QuotNo.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POquotno"))
                Txt_Vcode.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("povendorcode"))
                Txt_Storecode.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("storecode"))
                CmbPoType.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("potype"))
                strsql = "SELECT ISNULL(VENDORCODE,0) AS VENDORCODE, ISNULL(VENDORNAME,'') AS VENDORNAME FROM PO_VIEW_VENDORMASTER WHERE VENDORCODE = '" & Trim(Txt_Vcode.Text) & "' "
                'strsql = "SELECT slname FROM accountssubledgermaster WHERE slcode='" & Trim(Txt_Vcode.Text) & "'"
                gconnection.getDataSet(strsql, "accountssubledgermaster")
                Txt_Vname.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("vendorname"))

                Cbo_Approvedby.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POapprovedby"))

                If gShortname = "BGC" Then
                    TXT_TODEPT.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DELIVERTODEPT"))
                    TXT_DEPTCONPERSON.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DEPTCONPERSON"))
                    TXT_DEP_CON_NO.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DEPTCONNO"))
                    TXT_DEPT_CON_EMAIL.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DEPTCONEMAIL"))
                    RICH_INDNO.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("IND_MAT_REQNO"))
                    DTP_DELIVERDATE.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DELIVERBYDATE"))
                    TXT_DNO.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DNO"))
                    TXT_DEPART.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("DEPART"))
                    TXT_PTERM.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PTERM"))
                    RichTextBox1.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("GSTAPPLICAPLE"))
                End If


                Cbo_POStatus.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POstatus"))
                'Txt_ED.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POed"))
                'Txt_CST.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POcst"))
                'Txt_MODVat.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POmodvat"))
                'Txt_PTax.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POptax"))
                'Txt_Octra.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POoctra"))
                'Txt_Insurance.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POinsurance"))
                'Txt_LST.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POlst"))
                Txt_POValue.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("POvalue"), "0.000"))
                Txt_TotalVat.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("POtotalvat"), "0.00"))
                Txt_TotalTax.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("POtotaltax"), "0.00"))
                Txt_AdvanceAmt.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("POadvance"), "0.00"))

                TXT_OVERALLDISC.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("POOVERALLDISC"), "0.00"))
                TXT_CF.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POCF"))
                TXT_TRANSPORT.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("POTRANSPORT"), "0.00"))
                '  TXT_DELIVERY.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("PODELIVERYAMT"), "0.00"))
                txtothchargeplus.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgplus"), "0.00"))
                txtothchargemin.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("pootherchgmin"), "0.00"))

                Txt_Balance.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("PObalance"), "0.00"))
                Txt_POTerms.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POterms"))
                TXT_GROSSVALUE.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POterms"))

                Txt_DeliveryTerms.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POdeliveryterms"))
                If Trim(Txt_DeliveryTerms.Text) <> "" Then
                    sqlstring = "SELECT ISNULL(DELIVERYTERMCODE,0) AS DELIVERYTERMCODE,ISNULL(DELIVERYTERMDESC,'') AS DELIVERYTERMDESC FROM PO_DELIVERYTERMS where deliverytermcode = '" & Txt_DeliveryTerms.Text & "' "
                    gconnection.getDataSet(sqlstring, "PO_DELIVERYTERMS")
                    If gdataset.Tables("PO_DELIVERYTERMS").Rows.Count > 0 Then
                        Txt_DeliveryTerms.Text = Trim(gdataset.Tables("PO_DELIVERYTERMS").Rows(0).Item("DELIVERYTERMCODE"))
                        TXT_DELIVTERMS_DESC.Text = Trim(gdataset.Tables("PO_DELIVERYTERMS").Rows(0).Item("DELIVERYTERMDESC"))
                        Me.Txt_AdvanceAmt.Focus()
                    End If
                End If


                Remarks = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POremarks"))
                Txt_Remarks.Text = Replace(Remarks, "?", "'")
                If gdataset.Tables("PO_HDR").Rows(0).Item("POclosure") = "C" Then
                    CmdFreeze.Enabled = False
                    CmdAdd.Enabled = False
                End If

                'For Managing Committee Purchase Order Starts Retrieve Here
                txt_PONo.ReadOnly = True
                If gdataset.Tables("PO_HDR").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("PO_HDR").Rows(0).Item("AddDatetime")), "dd-MMM-yyyy")
                    Me.CmdFreeze.Enabled = False
                    Me.CmdAdd.Enabled = False
                    ' Me.Cmd_Freeze.Enabled = True
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.CmdFreeze.Text = "Freeze[F8]"
                    Me.CmdAdd.Enabled = True
                    Me.CmdFreeze.Enabled = True
                End If
                strsql = "SELECT isnull(companycode,'') as companycode,ISNULL(SPLCESS,0) AS SPLCESS,isnull(taxcode,'')as taxcode ,* FROM PO_ITEMDETAILS WHERE pono='" & Trim(txt_PONo.Text) & "'  ORDER BY AUTOID "
                gconnection.getDataSet(strsql, "PO_ITEMDETAILS")
                If gdataset.Tables("PO_ITEMDETAILS").Rows.Count > 0 Then
                    Dim count, temp, tcode As String
                    For I = 0 To gdataset.Tables("PO_ITEMDETAILS").Rows.Count - 1
                        tcode = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("itemcode")
                        count = gdataset.Tables("PO_ITEMDETAILS").Rows.Count
                        With AxfpSpread1
                            .Row = I + 1
                            .Col = 1
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("itemcode")

                            .Col = 2
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("itemname")

                            .Col = 3
                            Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("itemcode") + "'"

                            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                .Row = I + 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z

                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("uom")

                            .Col = 4
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("quantity"), "0.000"))

                            .Col = 5
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("rate")
                            .Col = 6
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("baseamount"), "0.000"))

                            .Col = 7
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("discper"), "0.00"))


                            .Col = 8
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("DiscAmt"), "0.00"))
                            .Col = 9
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("amountafterdiscount"), "0.000"))
                            .Col = 10
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("taxcode")

                            .Col = 11
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("taxper"), "0.000"))

                            .Col = 12
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("VatAmt"), "0.000"))
                            .Col = 13
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("totalamount"), "0.000"))
                            .Col = 14
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("othchg"), "0.000"))
                            .Col = 15
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("raterange")
                            .Col = 16
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("qtyrange")
                            .Col = 17
                            .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("companycode")
                            .Col = 18
                            .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("SPLCESS"), "0.000"))
                        End With
                    Next
                End If
                Me.CmdAdd.Text = "Update[F7]"

                txt_PONo.ReadOnly = False
                Txt_QuotNo.Focus()
                CALCULATE()
                caloperation()
            Else
                Txt_QuotNo.Focus()

                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
            End If
            sqlstring = "SELECT GRNDETAILS FROM GRN_header WHERE PONO='" + txt_PONo.Text + "'"
            gconnection.getDataSet(sqlstring, "GRN_DETAILS")
            If (gdataset.Tables("GRN_DETAILS").Rows.Count > 0) Then
                Label7.Text = "Ref no."
                For m As Integer = 0 To gdataset.Tables("GRN_DETAILS").Rows.Count - 1
                    Label7.Text += gdataset.Tables("GRN_DETAILS").Rows(m).Item("GRNDETAILS")

                Next
                MessageBox.Show("GRN Already Done for this PO. Ref no." & gdataset.Tables("GRN_DETAILS").Rows(0).Item("GRNDETAILS"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                Label7.Text = ""
            End If
        End If
    End Sub

    Private Sub CmdView_Click(sender As Object, e As EventArgs) Handles CmdView.Click
        gPrint = False


        Dim TaType = TaxType("PO", Trim(txt_PONo.Text), Format(CDate(Cbo_PODate.Value), "dd/MMM/yyyy"))

        If TaType = "GST" Or TaType = "IGST" Or TaType = "TAXL" Then


            If TaType = "GST" Or TaType = "IGST" Or TaType = "TAXL" Then
                If Mid(UCase(Trim(gShortname)), 1, 3) = "CCL" Then
                    Try
                        Dim rViewer As New Viewer
                        Dim sqlstring, SSQL, addr As String

                        Dim r As New CryPOGSTNEW
                        sqlstring = " SELECT * FROM  VW_POBILL  "
                        'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                        sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                        sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                        gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                        If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then

                            Dim sqlstring1 = "SELECT * FROM vW_PO_TAX_DET WHERE pono='" & Trim(txt_PONo.Text) & "' "
                            gconnection.getDataSet(sqlstring1, "vW_PO_TAX_DET")

                            Call rViewer.GetDetails1New(sqlstring1, "vW_PO_TAX_DET", r)

                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_PO_POBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text12")
                            textobj1.Text = MyCompanyName
                            addr = ""
                            Dim textobj3 As TextObject
                            textobj3 = r.ReportDefinition.ReportObjects("Text15")
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

                            Dim textobj13 As TextObject
                            textobj13 = r.ReportDefinition.ReportObjects("Text6")
                            textobj13.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text36")
                            textobj2.Text = gUsername
                            '   Dim t1 As TextObject
                            't1 = r.ReportDefinition.ReportObjects("Text54")
                            't1.Text = "Tel:" & GPHONE & " , Fax:" & gFax & ", Email:" & gEmail & ", Web:" & gWebsite
                            'Dim textobj4 As TextObject
                            'textobj4 = r.ReportDefinition.ReportObjects("Text20")
                            'textobj4.Text = "Tin No.:" & gTinNo & ",Service Tax:" & gServiceTax
                            If UCase(gShortname) = "CCL" Then
                                Dim textobj43 As TextObject
                                textobj43 = r.ReportDefinition.ReportObjects("Text43")
                                textobj43.Text = "                 CIN : U91990WB1914GAP002567 "

                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = " Authourised by "
                            End If

                            If Trim(UCase(gShortname)) = "NIZAM" Then
                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = "         Prepared by                                       Checked By                                  Convenor                              Hon. Secretary "
                            End If

                            rViewer.Show()
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                ElseIf gShortname = "HGA" Then

                    Call View_Report(Txt_Vcode.Text, txt_PONo.Text)

                ElseIf Mid(UCase(Trim(gShortname)), 1, 3) = "SAT" Then

                    Try
                        Dim rViewer As New Viewer
                        Dim sqlstring, SSQL, addr As String
                        Dim r As New CryPOSATCGSTNew

                        sqlstring = " SELECT * FROM  VW_POBILL "
                        'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                        sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                        sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                        gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                        If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then

                            Dim sqlstring1 = "SELECT * FROM vW_PO_TAX_DET WHERE pono='" & Trim(txt_PONo.Text) & "' "
                            gconnection.getDataSet(sqlstring1, "vW_PO_TAX_DET")

                            Call rViewer.GetDetails1New(sqlstring1, "vW_PO_TAX_DET", r)

                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_PO_POBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text12")
                            textobj1.Text = MyCompanyName
                            addr = ""
                            Dim textobj3 As TextObject
                            textobj3 = r.ReportDefinition.ReportObjects("Text15")
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

                            Dim textobj13 As TextObject
                            textobj13 = r.ReportDefinition.ReportObjects("Text1")
                            textobj13.Text = gPhone1

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text2")
                            textobj2.Text = gPhone2

                            Dim textobj4 As TextObject
                            textobj4 = r.ReportDefinition.ReportObjects("Text4")
                            textobj4.Text = gFax

                            Dim textobj6 As TextObject
                            textobj6 = r.ReportDefinition.ReportObjects("Text6")
                            textobj6.Text = gEMail

                            Dim textobj35 As TextObject
                            textobj35 = r.ReportDefinition.ReportObjects("Text35")
                            textobj35.Text = "GSTIN NO - " & gGSTINNO

                            SQL = "select  Adduser,povalue from po_hdr WHERE pono='" + txt_PONo.Text + "'  "

                            gconnection.getDataSet(SQL, "po_hdr")
                            If gdataset.Tables("po_hdr").Rows.Count > 0 Then
                                Dim Text37 As TextObject
                                Text37 = r.ReportDefinition.ReportObjects("Text37")
                                Text37.Text = "Prepared By " & Trim(gdataset.Tables("po_hdr").Rows(0).Item("Adduser"))

                                SQL = "select [dbo].NumberToWords (" & Val(gdataset.Tables("po_hdr").Rows(0).Item("povalue")) & ") as aMount"
                                gconnection.getDataSet(SQL, "NumberToWords")
                                If gdataset.Tables("NumberToWords").Rows.Count > 0 Then
                                    Dim Text43 As TextObject
                                    Text43 = r.ReportDefinition.ReportObjects("Text43")
                                    Text43.Text = "( " & Trim(gdataset.Tables("NumberToWords").Rows(0).Item("aMount")) & ")"
                                End If

                            End If

                            rViewer.Show()
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                ElseIf Mid(UCase(Trim(gShortname)), 1, 3) = "KBA" Then
                    Try
                        Dim rViewer As New Viewer
                        Dim sqlstring, SSQL, addr As String

                        Dim r As New CryPOGSTNEW_KBA
                        sqlstring = " SELECT * FROM  VW_POBILL  "
                        'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                        sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                        sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                        gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                        If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then

                            Dim sqlstring1 = "SELECT * FROM vW_PO_TAX_DET WHERE pono='" & Trim(txt_PONo.Text) & "' "
                            gconnection.getDataSet(sqlstring1, "vW_PO_TAX_DET")

                            Call rViewer.GetDetails1New(sqlstring1, "vW_PO_TAX_DET", r)

                            Dim sqlstring11 = "SELECT * FROM PO_DELIVERYTERMS_DET WHERE pono='" & Trim(txt_PONo.Text) & "' "
                            gconnection.getDataSet(sqlstring11, "PO_DELIVERYTERMS_DET")

                            '  Call rViewer.GetDetails3(sqlstring11, "PO_DELIVERYTERMS_DET", r)


                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_PO_POBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text12")
                            textobj1.Text = MyCompanyName
                            addr = ""
                            Dim textobj3 As TextObject
                            textobj3 = r.ReportDefinition.ReportObjects("Text15")
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

                            'Dim textobj16 As TextObject
                            'textobj16 = r.ReportDefinition.ReportObjects("Text16")
                            'textobj16.Text = "GSTIN NO : " & gGSTINNO

                            Dim textobj13 As TextObject
                            textobj13 = r.ReportDefinition.ReportObjects("Text6")
                            textobj13.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text36")
                            textobj2.Text = gUsername

                            Dim textobj24 As TextObject
                            textobj24 = r.ReportDefinition.ReportObjects("Text24")
                            textobj24.Text = "Our GSTIN NO : " & gGSTINNO

                            '   Dim t1 As TextObject
                            't1 = r.ReportDefinition.ReportObjects("Text54")
                            't1.Text = "Tel:" & GPHONE & " , Fax:" & gFax & ", Email:" & gEmail & ", Web:" & gWebsite
                            'Dim textobj4 As TextObject
                            'textobj4 = r.ReportDefinition.ReportObjects("Text20")
                            'textobj4.Text = "Tin No.:" & gTinNo & ",Service Tax:" & gServiceTax


                            rViewer.Show()
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else

                    Try
                        Dim rViewer As New Viewer
                        Dim sqlstring, SSQL, addr As String

                        Dim r
                        If UCase(gShortname) = "CFC" Then
                            r = New CryPOGSTNEW_CFC
                        ElseIf UCase(gShortname) = "BGC" Then
                            r = New CryPOGSTNEW_BGC
                        ElseIf UCase(gShortname) = "SKYYE" Then
                            r = New CryPOGSTNEW_SKYYE
                        Else
                            r = New CryPOGSTNEW_NIZAM
                        End If
                        sqlstring = " SELECT * FROM  VW_POBILL  "
                        'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                        sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                        sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                        gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                        If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then

                            Dim sqlstring11 = "SELECT * FROM PO_DELIVERYTERMS_DET WHERE pono='" & Trim(txt_PONo.Text) & "' "
                            gconnection.getDataSet(sqlstring11, "PO_DELIVERYTERMS_DET")

                            Call rViewer.GetDetails1New(sqlstring11, "PO_DELIVERYTERMS_DET", r)

                            Dim sqlstring1 = "SELECT * FROM vW_PO_TAX_DET WHERE pono='" & Trim(txt_PONo.Text) & "' "
                            gconnection.getDataSet(sqlstring1, "vW_PO_TAX_DET")

                            Call rViewer.GetDetails1New(sqlstring1, "vW_PO_TAX_DET", r)




                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_PO_POBILL"
                            If gShortname <> "BGC" Then
                                Dim textobj1 As TextObject
                                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                                textobj1.Text = MyCompanyName
                            End If
                            addr = ""
                            If gShortname <> "BGC" Then

                                Dim textobj3 As TextObject
                                textobj3 = r.ReportDefinition.ReportObjects("Text15")
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
                            End If

                            'Dim textobj16 As TextObject
                            'textobj16 = r.ReportDefinition.ReportObjects("Text16")
                            'textobj16.Text = "GSTIN NO : " & gGSTINNO
                            If gShortname <> "BGC" Then
                                If UCase(gShortname) = "CAT" Then
                                    Dim inv_Email, sqlstring2 As String
                                    sqlstring2 = "SELECT ISNULL(INV_EMAIL,'')AS INV_EMAIL FROM inv_linksetup "
                                    gconnection.getDataSet(sqlstring2, "inv_linksetup")
                                    inv_Email = Trim(CStr(gdataset.Tables("inv_linksetup").Rows(0).Item("INV_EMAIL")))
                                    Dim textobj16 As TextObject
                                    textobj16 = r.ReportDefinition.ReportObjects("Text16")
                                    textobj16.Text = "GSTIN NO : " & gGSTINNO + "," + inv_Email
                                Else
                                    Dim textobj16 As TextObject
                                    textobj16 = r.ReportDefinition.ReportObjects("Text16")
                                    textobj16.Text = "GSTIN NO : " & gGSTINNO
                                End If
                                If gShortname <> "BGC" Then
                                    Dim textobj13 As TextObject
                                    textobj13 = r.ReportDefinition.ReportObjects("Text6")
                                    textobj13.Text = gFinancalyearStart + "-" + gFinancialyearEnd
                                End If
                            End If

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text36")
                            textobj2.Text = gUsername
                            '   Dim t1 As TextObject
                            't1 = r.ReportDefinition.ReportObjects("Text54")
                            't1.Text = "Tel:" & GPHONE & " , Fax:" & gFax & ", Email:" & gEmail & ", Web:" & gWebsite
                            'Dim textobj4 As TextObject
                            'textobj4 = r.ReportDefinition.ReportObjects("Text20")
                            'textobj4.Text = "Tin No.:" & gTinNo & ",Service Tax:" & gServiceTax
                            If UCase(gShortname) = "CCL" Then
                                Dim textobj43 As TextObject
                                textobj43 = r.ReportDefinition.ReportObjects("Text43")
                                textobj43.Text = "                 CIN : U91990WB1914GAP002567 "

                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = " Authourised by "
                            End If

                            If UCase(gShortname) = "BRC" Then
                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = " Authorised by "
                            End If


                            If Mid(UCase(Trim(gCompanyname)), 1, 7) = "THE NIZ" Or Mid(UCase(Trim(gShortname)), 1, 3) = "NIZ" Then
                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = "         Prepared by                                       Checked By                                  Convenor                              Hon. Secretary "
                            End If

                            'If gShortname = "BGC" Then
                            '    Dim textobj16 As TextObject
                            '    textobj16 = r.ReportDefinition.ReportObjects("Text2")
                            '    textobj16.Text = "GSTIN NO : " & gGSTINNO
                            'End If

                            rViewer.Show()
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try

                End If
            ElseIf TaType = "TAXL" Then
                If Mid(UCase(Trim(gShortname)), 1, 3) <> "SAT" Then
                    Try
                        Dim rViewer As New Viewer
                        Dim sqlstring, SSQL, addr As String

                        Dim r As New CryPOGSTNEW
                        sqlstring = " SELECT * FROM  VW_POBILL  "
                        'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                        sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                        sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                        gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                        If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_PO_POBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text12")
                            textobj1.Text = MyCompanyName
                            addr = ""
                            Dim textobj3 As TextObject
                            textobj3 = r.ReportDefinition.ReportObjects("Text15")
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

                            Dim textobj13 As TextObject
                            textobj13 = r.ReportDefinition.ReportObjects("Text6")
                            textobj13.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text36")
                            textobj2.Text = gUsername
                            '   Dim t1 As TextObject
                            't1 = r.ReportDefinition.ReportObjects("Text54")
                            't1.Text = "Tel:" & GPHONE & " , Fax:" & gFax & ", Email:" & gEmail & ", Web:" & gWebsite
                            'Dim textobj4 As TextObject
                            'textobj4 = r.ReportDefinition.ReportObjects("Text20")
                            'textobj4.Text = "Tin No.:" & gTinNo & ",Service Tax:" & gServiceTax
                            If UCase(gShortname) = "CCL" Then
                                Dim textobj43 As TextObject
                                textobj43 = r.ReportDefinition.ReportObjects("Text43")
                                textobj43.Text = "                 CIN : U91990WB1914GAP002567 "

                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = " Authourised by "
                            End If

                            If UCase(gShortname) = "BRC" Then
                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = " Authorised by "
                            End If


                            rViewer.Show()
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                Else
                    Try
                        Dim rViewer As New Viewer
                        Dim sqlstring, SSQL, addr As String
                        Dim r As New CryPOSATCIGST

                        sqlstring = " SELECT * FROM  VW_POBILL "
                        'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                        sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                        sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                        gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                        If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_PO_POBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text12")
                            textobj1.Text = MyCompanyName
                            addr = ""
                            Dim textobj3 As TextObject
                            textobj3 = r.ReportDefinition.ReportObjects("Text15")
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

                            Dim textobj13 As TextObject
                            textobj13 = r.ReportDefinition.ReportObjects("Text1")
                            textobj13.Text = gPhone1

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text2")
                            textobj2.Text = gPhone2

                            Dim textobj4 As TextObject
                            textobj4 = r.ReportDefinition.ReportObjects("Text4")
                            textobj4.Text = gFax

                            Dim textobj6 As TextObject
                            textobj6 = r.ReportDefinition.ReportObjects("Text6")
                            textobj6.Text = gEMail

                            SQL = "select  Adduser,povalue from po_hdr WHERE pono='" + txt_PONo.Text + "'  "

                            gconnection.getDataSet(SQL, "po_hdr")
                            If gdataset.Tables("po_hdr").Rows.Count > 0 Then
                                Dim Text37 As TextObject
                                Text37 = r.ReportDefinition.ReportObjects("Text37")
                                Text37.Text = "Prepared By " & Trim(gdataset.Tables("po_hdr").Rows(0).Item("Adduser"))

                                SQL = "select [dbo].NumberToWords (" & Val(gdataset.Tables("po_hdr").Rows(0).Item("povalue")) & ") as aMount"
                                gconnection.getDataSet(SQL, "NumberToWords")
                                If gdataset.Tables("NumberToWords").Rows.Count > 0 Then
                                    Dim Text43 As TextObject
                                    Text43 = r.ReportDefinition.ReportObjects("Text43")
                                    Text43.Text = "( " & Trim(gdataset.Tables("NumberToWords").Rows(0).Item("aMount")) & ")"
                                End If

                            End If

                            Dim textobj35 As TextObject
                            textobj35 = r.ReportDefinition.ReportObjects("Text35")
                            textobj35.Text = "GSTIN NO - " & gGSTINNO



                            rViewer.Show()
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try
                End If
            Else
                If Mid(UCase(Trim(gShortname)), 1, 3) <> "SAT" Then
                    Try
                        Dim rViewer As New Viewer
                        Dim sqlstring, SSQL, addr As String

                        Dim r As New CryPOGST
                        sqlstring = " SELECT * FROM  VW_POBILL  "
                        'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                        sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                        sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                        gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                        If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_PO_POBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text12")
                            textobj1.Text = MyCompanyName
                            addr = ""
                            Dim textobj3 As TextObject
                            textobj3 = r.ReportDefinition.ReportObjects("Text15")
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

                            Dim textobj13 As TextObject
                            textobj13 = r.ReportDefinition.ReportObjects("Text6")
                            textobj13.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text36")
                            textobj2.Text = gUsername




                            '   Dim t1 As TextObject


                            't1 = r.ReportDefinition.ReportObjects("Text54")
                            't1.Text = "Tel:" & GPHONE & " , Fax:" & gFax & ", Email:" & gEmail & ", Web:" & gWebsite
                            'Dim textobj4 As TextObject
                            'textobj4 = r.ReportDefinition.ReportObjects("Text20")
                            'textobj4.Text = "Tin No.:" & gTinNo & ",Service Tax:" & gServiceTax
                            If UCase(gShortname) = "CCL" Then
                                Dim textobj43 As TextObject
                                textobj43 = r.ReportDefinition.ReportObjects("Text43")
                                textobj43.Text = "                 CIN : U91990WB1914GAP002567 "

                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = " Authourised by "
                            End If

                            If UCase(gShortname) = "BRC" Then
                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = " Authorised by "
                            End If


                            rViewer.Show()
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try

                Else
                    Try
                        Dim rViewer As New Viewer
                        Dim sqlstring, SSQL, addr As String
                        Dim r As New CryPOSATCGST

                        sqlstring = " SELECT * FROM  VW_POBILL "
                        'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                        sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                        sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                        gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                        If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_PO_POBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text12")
                            textobj1.Text = MyCompanyName
                            addr = ""
                            Dim textobj3 As TextObject
                            textobj3 = r.ReportDefinition.ReportObjects("Text15")
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

                            Dim textobj13 As TextObject
                            textobj13 = r.ReportDefinition.ReportObjects("Text1")
                            textobj13.Text = gPhone1

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text2")
                            textobj2.Text = gPhone2

                            Dim textobj4 As TextObject
                            textobj4 = r.ReportDefinition.ReportObjects("Text4")
                            textobj4.Text = gFax

                            Dim textobj6 As TextObject
                            textobj6 = r.ReportDefinition.ReportObjects("Text6")
                            textobj6.Text = gEMail

                            SQL = "select  Adduser,povalue from po_hdr WHERE pono='" + txt_PONo.Text + "'  "

                            gconnection.getDataSet(SQL, "po_hdr")
                            If gdataset.Tables("po_hdr").Rows.Count > 0 Then
                                Dim Text37 As TextObject
                                Text37 = r.ReportDefinition.ReportObjects("Text37")
                                Text37.Text = "Prepared By " & Trim(gdataset.Tables("po_hdr").Rows(0).Item("Adduser"))

                                SQL = "select [dbo].NumberToWords (" & Val(gdataset.Tables("po_hdr").Rows(0).Item("povalue")) & ") as aMount"
                                gconnection.getDataSet(SQL, "NumberToWords")
                                If gdataset.Tables("NumberToWords").Rows.Count > 0 Then
                                    Dim Text43 As TextObject
                                    Text43 = r.ReportDefinition.ReportObjects("Text43")
                                    Text43.Text = "( " & Trim(gdataset.Tables("NumberToWords").Rows(0).Item("aMount")) & ")"
                                End If

                            End If

                            Dim textobj35 As TextObject
                            textobj35 = r.ReportDefinition.ReportObjects("Text35")
                            textobj35.Text = "GSTIN NO - " & gGSTINNO



                            rViewer.Show()
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End Try

                End If
            End If

        Else
            If Mid(UCase(Trim(gShortname)), 1, 3) = "SAT" Then

                Try
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL, addr As String
                    Dim r As New CryPOSATC

                    sqlstring = " SELECT * FROM  VW_POBILL "
                    'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                    sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                    sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                    gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                    If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "VW_PO_POBILL"
                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName
                        addr = ""
                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text15")
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

                        Dim textobj13 As TextObject
                        textobj13 = r.ReportDefinition.ReportObjects("Text1")
                        textobj13.Text = gPhone1

                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text2")
                        textobj2.Text = gPhone2

                        Dim textobj4 As TextObject
                        textobj4 = r.ReportDefinition.ReportObjects("Text4")
                        textobj4.Text = gFax

                        Dim textobj6 As TextObject
                        textobj6 = r.ReportDefinition.ReportObjects("Text6")
                        textobj6.Text = gEMail

                        SQL = "select  Adduser,povalue from po_hdr WHERE pono='" + txt_PONo.Text + "'  "

                        gconnection.getDataSet(SQL, "po_hdr")
                        If gdataset.Tables("po_hdr").Rows.Count > 0 Then
                            Dim Text37 As TextObject
                            Text37 = r.ReportDefinition.ReportObjects("Text37")
                            Text37.Text = "Prepared By " & Trim(gdataset.Tables("po_hdr").Rows(0).Item("Adduser"))

                            SQL = "select [dbo].NumberToWords (" & Val(gdataset.Tables("po_hdr").Rows(0).Item("povalue")) & ") as aMount"
                            gconnection.getDataSet(SQL, "NumberToWords")
                            If gdataset.Tables("NumberToWords").Rows.Count > 0 Then
                                Dim Text43 As TextObject
                                Text43 = r.ReportDefinition.ReportObjects("Text43")
                                Text43.Text = "( " & Trim(gdataset.Tables("NumberToWords").Rows(0).Item("aMount")) & ")"
                            End If

                        End If


                        Dim Text29 As TextObject
                        Text29 = r.ReportDefinition.ReportObjects("Text29")
                        Text29.Text = "GSTIN NO - " & gGSTINNO


                        rViewer.Show()
                    Else
                        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try

            ElseIf Mid(UCase(Trim(gShortname)), 1, 3) = "BGC" Then

                Try
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL, addr As String
                    Dim r As New CryPOGSTNEW_BGC
                    sqlstring = " SELECT * FROM  VW_POBILL "
                    'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                    sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                    sqlstring = sqlstring & " ORDER BY PONO,PODATE"
                    gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                    If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "VW_PO_POBILL"
                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text62")
                        textobj1.Text = MyCompanyName
                        addr = ""
                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text1")
                        If Address1 <> "" Then
                            addr = addr & Address1
                        End If
                        If Address2 <> "" Then
                            addr = addr & ", " & Address2
                        End If
                        If gCity <> "" Then
                            addr = addr & ", " & gCity
                        End If

                        'If gPincode <> "" Then
                        '    addr = addr & " - " & gPincode
                        'End If

                        textobj3.Text = addr

                        'Dim textobj13 As TextObject
                        'textobj13 = r.ReportDefinition.ReportObjects("Text1")
                        'textobj13.Text = gPhone1

                        'Dim textobj2 As TextObject
                        'textobj2 = r.ReportDefinition.ReportObjects("Text2")
                        'textobj2.Text = gPhone2

                        'Dim textobj4 As TextObject
                        'textobj4 = r.ReportDefinition.ReportObjects("Text4")
                        'textobj4.Text = gFax

                        'Dim textobj6 As TextObject
                        'textobj6 = r.ReportDefinition.ReportObjects("Text6")
                        'textobj6.Text = gEMail

                        SQL = "select  Adduser,povalue from po_hdr WHERE pono='" + txt_PONo.Text + "'  "
                        gconnection.getDataSet(SQL, "po_hdr")
                        If gdataset.Tables("po_hdr").Rows.Count > 0 Then
                            'Dim Text37 As TextObject
                            'Text37 = r.ReportDefinition.ReportObjects("Text37")
                            'Text37.Text = "Prepared By " & Trim(gdataset.Tables("po_hdr").Rows(0).Item("Adduser"))
                            SQL = "select [dbo].NumberToWords (" & Val(gdataset.Tables("po_hdr").Rows(0).Item("povalue")) & ") as aMount"
                            gconnection.getDataSet(SQL, "NumberToWords")
                            If gdataset.Tables("NumberToWords").Rows.Count > 0 Then
                                Dim Text43 As TextObject
                                Text43 = r.ReportDefinition.ReportObjects("Text69")
                                Text43.Text = "( " & Trim(gdataset.Tables("NumberToWords").Rows(0).Item("aMount")) & ")"
                            End If
                        End If
                        Dim Text29 As TextObject
                        Text29 = r.ReportDefinition.ReportObjects("Text2")
                        Text29.Text = gGSTINNO
                        rViewer.Show()
                    Else
                        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try




            ElseIf Mid(UCase(Trim(gShortname)), 1, 3) = "CAT" Then

                Try
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL, addr As String

                    Dim r As New CryPOGSTNEW_NIZAM
                    sqlstring = " SELECT * FROM  VW_POBILL  "
                    'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                    sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                    sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                    gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
                    If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then

                        Dim sqlstring1 = "SELECT * FROM vW_PO_TAX_DET WHERE pono='" & Trim(txt_PONo.Text) & "' "
                        gconnection.getDataSet(sqlstring1, "vW_PO_TAX_DET")

                        Call rViewer.GetDetails1New(sqlstring1, "vW_PO_TAX_DET", r)

                        Dim sqlstring11 = "SELECT * FROM PO_DELIVERYTERMS_DET WHERE pono='" & Trim(txt_PONo.Text) & "' "
                        gconnection.getDataSet(sqlstring11, "PO_DELIVERYTERMS_DET")
                        Call rViewer.GetDetails1New(sqlstring11, "PO_DELIVERYTERMS_DET", r)
                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "VW_PO_POBILL"
                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text12")
                        textobj1.Text = MyCompanyName
                        addr = ""
                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text15")
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

                        Dim inv_Email, SQLSTRING2 As String
                        SQLSTRING2 = "SELECT ISNULL(INV_EMAIL,'')AS INV_EMAIL FROM inv_linksetup "
                        gconnection.getDataSet(SQLSTRING2, "inv_linksetup")
                        inv_Email = Trim(CStr(gdataset.Tables("inv_linksetup").Rows(0).Item("INV_EMAIL")))

                        'Dim textobj16 As TextObject
                        'textobj16 = r.ReportDefinition.ReportObjects("Text16")
                        'textobj16.Text = "GSTIN NO : " & gGSTINNO
                        Dim textobj16 As TextObject
                        textobj16 = r.ReportDefinition.ReportObjects("Text16")
                        textobj16.Text = "GSTIN NO : " & gGSTINNO + "," + inv_Email
                        Dim textobj13 As TextObject
                        textobj13 = r.ReportDefinition.ReportObjects("Text6")
                        textobj13.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text36")
                        textobj2.Text = gUsername
                        '   Dim t1 As TextObject
                        't1 = r.ReportDefinition.ReportObjects("Text54")
                        't1.Text = "Tel:" & GPHONE & " , Fax:" & gFax & ", Email:" & gEmail & ", Web:" & gWebsite
                        'Dim textobj4 As TextObject
                        'textobj4 = r.ReportDefinition.ReportObjects("Text20")
                        'textobj4.Text = "Tin No.:" & gTinNo & ",Service Tax:" & gServiceTax
                        If UCase(gShortname) = "CCL" Then
                            Dim textobj43 As TextObject
                            textobj43 = r.ReportDefinition.ReportObjects("Text43")
                            textobj43.Text = "                 CIN : U91990WB1914GAP002567 "

                            Dim textobj44 As TextObject
                            textobj44 = r.ReportDefinition.ReportObjects("Text44")
                            textobj44.Text = " Authourised by "
                        End If

                        If Mid(UCase(Trim(gCompanyname)), 1, 7) = "THE NIZ" Or Mid(UCase(Trim(gShortname)), 1, 3) = "NIZ" Then
                            Dim textobj44 As TextObject
                            textobj44 = r.ReportDefinition.ReportObjects("Text44")
                            textobj44.Text = "         Prepared by                                       Checked By                                  Convenor                              Hon. Secretary "
                        End If

                        rViewer.Show()
                    Else
                        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try


            Else
                Try
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL, addr As String
                    Dim r
                    If UCase(gShortname) = "BGC" Then
                        r = New CryPOGSTNEW_BGC
                    ElseIf UCase(gShortname) = "SKYYE" Then
                        r = New CryPO_SKYYE
                    Else
                        r = New CryPO
                    End If
                    sqlstring = " SELECT * FROM  VW_POBILL  "
                    'sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
                    sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'  "
                    sqlstring = sqlstring & " ORDER BY PONO,PODATE"

                    gconnection.getDataSet(sqlstring, "VW_PO_POBILL")

                    If gShortname = "BGC" Then

                        Try
                            If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
                                rViewer.ssql = sqlstring
                                rViewer.Report = r
                                rViewer.TableName = "VW_PO_POBILL"
                                Dim textobj1 As TextObject
                                textobj1 = r.ReportDefinition.ReportObjects("Text62")
                                textobj1.Text = MyCompanyName
                                addr = ""
                                Dim textobj3 As TextObject
                                textobj3 = r.ReportDefinition.ReportObjects("Text1")
                                If Address1 <> "" Then
                                    addr = addr & Address1
                                End If
                                If Address2 <> "" Then
                                    addr = addr & ", " & Address2
                                End If
                                If gCity <> "" Then
                                    addr = addr & ", " & gCity
                                End If
                                textobj3.Text = addr


                                SQL = "select  Adduser,povalue from po_hdr WHERE pono='" + txt_PONo.Text + "'  "
                                gconnection.getDataSet(SQL, "po_hdr")
                                If gdataset.Tables("po_hdr").Rows.Count > 0 Then
                                    'Dim Text37 As TextObject
                                    'Text37 = r.ReportDefinition.ReportObjects("Text37")
                                    'Text37.Text = "Prepared By " & Trim(gdataset.Tables("po_hdr").Rows(0).Item("Adduser"))
                                    SQL = "select [dbo].NumberToWords (" & Val(gdataset.Tables("po_hdr").Rows(0).Item("povalue")) & ") as aMount"
                                    gconnection.getDataSet(SQL, "NumberToWords")
                                    If gdataset.Tables("NumberToWords").Rows.Count > 0 Then
                                        Dim Text43 As TextObject
                                        Text43 = r.ReportDefinition.ReportObjects("Text69")
                                        Text43.Text = "( " & Trim(gdataset.Tables("NumberToWords").Rows(0).Item("aMount")) & ")"
                                    End If
                                End If
                                Dim Text29 As TextObject
                                Text29 = r.ReportDefinition.ReportObjects("Text2")
                                Text29.Text = gGSTINNO
                                rViewer.Show()
                            Else
                                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                            End If
                        Catch ex As Exception
                            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End Try

                    Else


                        If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
                            rViewer.ssql = sqlstring
                            rViewer.Report = r
                            rViewer.TableName = "VW_PO_POBILL"
                            Dim textobj1 As TextObject
                            textobj1 = r.ReportDefinition.ReportObjects("Text12")
                            textobj1.Text = MyCompanyName
                            addr = ""
                            Dim textobj3 As TextObject
                            textobj3 = r.ReportDefinition.ReportObjects("Text15")
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

                            Dim textobj13 As TextObject
                            textobj13 = r.ReportDefinition.ReportObjects("Text6")
                            textobj13.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                            Dim textobj2 As TextObject
                            textobj2 = r.ReportDefinition.ReportObjects("Text36")
                            textobj2.Text = gUsername
                            '   Dim t1 As TextObject
                            't1 = r.ReportDefinition.ReportObjects("Text54")
                            't1.Text = "Tel:" & GPHONE & " , Fax:" & gFax & ", Email:" & gEmail & ", Web:" & gWebsite
                            'Dim textobj4 As TextObject
                            'textobj4 = r.ReportDefinition.ReportObjects("Text20")
                            'textobj4.Text = "Tin No.:" & gTinNo & ",Service Tax:" & gServiceTax
                            If UCase(gShortname) = "CCL" Then
                                Dim textobj43 As TextObject
                                textobj43 = r.ReportDefinition.ReportObjects("Text43")
                                textobj43.Text = "                 CIN : U91990WB1914GAP002567 "

                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = " Authourised by "
                            End If

                            If UCase(gShortname) = "BRC" Then
                                Dim textobj44 As TextObject
                                textobj44 = r.ReportDefinition.ReportObjects("Text44")
                                textobj44.Text = " Authorised by "
                            End If


                            rViewer.Show()
                        Else
                            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
                        End If
                    End If





                Catch ex As Exception
                    MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End Try
            End If
        End If



    End Sub
    Public Sub View_Report(suppcode As String, pono As String)
        gPrint = False

        Try
            ' If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL As String
            Dim PMTTRMS, DLVTRMS As String
            Dim vcode As String


            ''

            Dim str1 As String = "UPDATE po_vendormaster SET   GSTINNO = A.GSTINNO  FROM po_vendormaster P INNER JOIN ACCOUNTSSUBLEDGERMASTER A  ON P.VENDORCODE =A.SLCODE WHERE ISNULL(P.GSTINNO,'')=''"
            gconnection.dataOperation1(6, str1, "item")

            vcode = suppcode

            sqlstring = ""
            sqlstring = "select ISNULL(address,'') as address1,ISNULL(address2,'') as address2,ISNULL(address3,'') as address3,"
            sqlstring = sqlstring & "ISNULL(city,'') as city,ISNULL(pincode,0) as pincode,  ISNULL(email,'') as email, ISNULL(phone1,'') as phone1, ISNULL(phone2,'') as phone2, isnull(fax,0) as fax,"
            sqlstring = sqlstring & "ISNULL(contactperson,'') as contactperson, ISNULL(tinno,'') as tinno, ISNULL(panno,'') as panno ,ISNULL(GSTINNO,'') AS GSTINNO from po_vendormaster where vendorcode='" & vcode & "'"
            gconnection.getDataSet(sqlstring, "vdetails")

            If gdataset.Tables("vdetails").Rows.Count > 0 Then

            Else
                sqlstring = "select ISNULL(address1,'') as address1,ISNULL(address2,'') as address2,ISNULL(address3,'') as address3,"
                sqlstring = sqlstring & "ISNULL(city,'') as city,ISNULL(pin,0) as pincode,  ISNULL(emailid,'') as email, ISNULL(cellno,'') as phone1, ISNULL(phoneno,'') as phone2, "
                sqlstring = sqlstring & "ISNULL(contactperson,'') as contactperson, ISNULL(tinno,'') as tinno, ISNULL(panno,'') as panno,isnull(fax,0) as fax,ISNULL(GSTINNO,'') AS GSTINNO from ACCOUNTSSUBLEDGERMASTER where slcode='" & vcode & "' and accode='scrs'"
                gconnection.getDataSet(sqlstring, "vdet")
            End If


            sqlstring = "SELECT SUM(VATAMT) AS VATAMT, VAT FROM PO_ITEMDETAILS WHERE pono='" & Trim(pono) & "' GROUP BY VAT"
            gconnection.getDataSet(sqlstring, "vw_vatrate")

            sqlstring = " SELECT * FROM  VW_PO_POBILL "
            sqlstring = sqlstring & " WHERE PONO = '" & Trim(pono) & "'"
            sqlstring = sqlstring & " ORDER BY AUTOID,PONO,PODATE"
            gconnection.getDataSet(sqlstring, "VW_PO_POBILL")

            Dim SSQL1 = "SELECT sum(Taxamt) as Taxamt,pono,podate,TaxDesc,torder FROM VW_PO_POBILL_DET WHERE  PONO = '" & Trim(pono) & "'  GROUP BY pono,podate,TaxDesc,torder order  BY torder "
            gconnection.getDataSet(SSQL1, "VW_PO_POBILL_DET")
            Dim r

            r = New Rpt_POBill_Common





            Call Viewer.GetDetails1New(sqlstring, "VIEW_JOURNAL", r)

            Call Viewer.GetDetails1New(SSQL1, "VW_PO_POBILL_DET", r)

            If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
                vcode = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("suppliercode")
                PMTTRMS = UCase(gdataset.Tables("VW_PO_POBILL").Rows(0).Item("PAYMENTTERMS"))
                DLVTRMS = UCase(gdataset.Tables("VW_PO_POBILL").Rows(0).Item("DELIVERYTERMS"))
                Dim subj As String
                subj = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("subject")
                Dim txt As TextObject
                txt = r.ReportDefinition.ReportObjects("Text44")
                txt.Text = subj

                Dim TMT As TextObject
                Dim quotno As String
                'TMT = r.ReportDefinition.ReportObjects("Text11")
                'TMT.Text = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("MODVATVAL")

                'TMT = r.ReportDefinition.ReportObjects("Text76")
                'TMT.Text = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("ED")

                'TMT = r.ReportDefinition.ReportObjects("Text77")
                'TMT.Text = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("CST")

                'TMT = r.ReportDefinition.ReportObjects("Text78")
                'TMT.Text = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("POMODVAT")

                'TMT = r.ReportDefinition.ReportObjects("Text91")
                'TMT.Text = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("POPTAX")

                quotno = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("poquotno")
                If quotno = "NA" Then
                    TMT = r.ReportDefinition.ReportObjects("Text102")
                    TMT.Text = ""
                Else
                    TMT = r.ReportDefinition.ReportObjects("Text102")
                    TMT.Text = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("quot_date")
                End If

                'TMT = r.ReportDefinition.ReportObjects("Text103")
                'TMT.Text = "SERVICE CH."
                'TMT = r.ReportDefinition.ReportObjects("Text104")
                'TMT.Text = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("ser_ch")

                'If Not String.IsNullOrEmpty(gdataset.Tables("VW_PO_POBILL").Rows(0).Item("WARRANTY")) Then
                '    TMT = r.ReportDefinition.ReportObjects("Text106")
                '    TMT.Text = "WARRANTY : " & gdataset.Tables("VW_PO_POBILL").Rows(0).Item("WARRANTY")
                'End If
                Dim tax As TextObject
                tax = r.ReportDefinition.ReportObjects("Text4")
                tax.Text = UCase(gdataset.Tables("VW_PO_POBILL").Rows(0).Item("POSALET"))

                Dim PMT As TextObject
                PMT = r.ReportDefinition.ReportObjects("Text67")
                PMT.Text = UCase(gdataset.Tables("VW_PO_POBILL").Rows(0).Item("PAYMENTTERMDESC"))

                Dim DVT As TextObject
                DVT = r.ReportDefinition.ReportObjects("Text37")
                DVT.Text = UCase(gdataset.Tables("VW_PO_POBILL").Rows(0).Item("DELIVERYTERMDESC"))






                Dim POTOTAL As Double
                POTOTAL = gdataset.Tables("VW_PO_POBILL").Rows(0).Item("POTOTAL")
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_PO_POBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName
                Dim Text5, Text54, Text20 As String

                Text5 = Address1 & "  " & Address2 & " , " & gCity & " - " & gPincode
                Text54 = "Tel: " & gPhone1 & " ,Email:" & gEMail & ", Web:"
                Text20 = "TIN No.: " & TINNO & ",Service Tax: " & SERVICETAX.ToUpper() & " GSTIN No. :" & gGSTINNO.ToUpper()



                Dim textobj3 As TextObject
                textobj3 = r.ReportDefinition.ReportObjects("Text5")
                textobj3.Text = Text5

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text30")
                textobj2.Text = gUsername
                Dim t1 As TextObject
                t1 = r.ReportDefinition.ReportObjects("Text54")
                t1.Text = Text54
                Dim textobj4 As TextObject
                textobj4 = r.ReportDefinition.ReportObjects("Text20")
                textobj4.Text = Text20.ToUpper()

                If Val(POTOTAL) < 25000.0 Then
                    Dim TXTOBJ7 As TextObject
                    TXTOBJ7 = r.ReportDefinition.ReportObjects("Text116")
                    TXTOBJ7.Text = "CHIEF  OF  ADMINISTRATION "

                Else
                    Dim TXTOBJ7 As TextObject
                    TXTOBJ7 = r.ReportDefinition.ReportObjects("Text116")
                    TXTOBJ7.Text = "HON. SECRETARY"
                End If
                If gShortname = "HGA" Then
                    Dim TXTOBJ7 As TextObject
                    TXTOBJ7 = r.ReportDefinition.ReportObjects("Text116")
                    TXTOBJ7.Text = "HON. SECRETARY / GEN. MANAGER"
                End If
                'If Val(POTOTAL) < 100000.0 Then
                '    Dim TXTOBJ7 As TextObject
                '    TXTOBJ7 = r.ReportDefinition.ReportObjects("Text112")
                '    TXTOBJ7.Text = ""

                'End If




                If MyCompanyName = "Karnataka Golf Association" Then
                    Dim tc As TextObject
                    tc = r.ReportDefinition.ReportObjects("Text28")
                    tc.Text = ""
                End If

                Dim CN As TextObject
                CN = r.ReportDefinition.ReportObjects("Text26")
                CN.Text = MyCompanyName


                Dim t5 As TextObject
                Dim TT As TextObject
                Dim vat, VATAMT As String
                Dim tet, TET1 As String
                't5 = r.ReportDefinition.ReportObjects("Text11")
                ' t5 = r.ReportDefinition.ReportObjects("Text88")
                'TT = r.ReportDefinition.ReportObjects("Text89")


                ' ''' ***** start filling Vat rate *****

                'If gdataset.Tables("vw_vatrate").Rows.Count > 0 Then
                '    For i = 0 To gdataset.Tables("vw_vatrate").Rows.Count - 1
                '        vat = gdataset.Tables("vw_vatrate").Rows(i).Item("VAT")
                '        VATAMT = gdataset.Tables("vw_vatrate").Rows(i).Item("VATAMT")
                '        If tet = "" Then
                '            tet = vat
                '            TET1 = VATAMT
                '        Else
                '            tet = tet & vbNewLine & vat
                '            TET1 = TET1 & vbNewLine & VATAMT
                '        End If
                '    Next
                '    t5.Text = t5.Text & tet & ""
                '    TT.Text = TT.Text & TET1 & ""
                'End If
                ''' ***** End filling Vat rate *****



                ''' ***** Start filling Address *****

                If gdataset.Tables("vdetails").Rows.Count > 0 Then
                    Dim vadd As TextObject
                    Dim city As String
                    vadd = r.ReportDefinition.ReportObjects("Text92")
                    vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("address1")
                    vadd = r.ReportDefinition.ReportObjects("Text93")
                    vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("address2")
                    vadd = r.ReportDefinition.ReportObjects("Text94")
                    vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("address3")
                    vadd = r.ReportDefinition.ReportObjects("Text95")
                    city = gdataset.Tables("vdetails").Rows(0).Item("city") & "-" & gdataset.Tables("vdetails").Rows(0).Item("pincode")
                    vadd.Text = city
                    vadd = r.ReportDefinition.ReportObjects("Text96")
                    vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("email")
                    vadd = r.ReportDefinition.ReportObjects("Text98")
                    vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("phone1").ToString() & "," & gdataset.Tables("vdetails").Rows(0).Item("phone2").ToString()
                    'vadd = r.ReportDefinition.ReportObjects("Text97")
                    'vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("phone2")
                    vadd = r.ReportDefinition.ReportObjects("Text105")
                    vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("fax")
                    vadd = r.ReportDefinition.ReportObjects("Text99")
                    vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("contactperson")
                    vadd = r.ReportDefinition.ReportObjects("Text100")
                    vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("tinno")
                    vadd = r.ReportDefinition.ReportObjects("Text101")
                    vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("panno")
                    vadd = r.ReportDefinition.ReportObjects("Text50")
                    vadd.Text = gdataset.Tables("vdetails").Rows(0).Item("GSTINNO")

                Else

                    If gdataset.Tables("vdet").Rows.Count > 0 Then
                        Dim vadd As TextObject
                        Dim city As String
                        vadd = r.ReportDefinition.ReportObjects("Text92")
                        vadd.Text = gdataset.Tables("vdet").Rows(0).Item("address1")
                        vadd = r.ReportDefinition.ReportObjects("Text93")
                        vadd.Text = gdataset.Tables("vdet").Rows(0).Item("address2")
                        vadd = r.ReportDefinition.ReportObjects("Text94")
                        vadd.Text = gdataset.Tables("vdet").Rows(0).Item("address3")
                        vadd = r.ReportDefinition.ReportObjects("Text95")
                        city = gdataset.Tables("vdet").Rows(0).Item("city") & "-" & gdataset.Tables("vdet").Rows(0).Item("pincode")
                        vadd.Text = city
                        vadd = r.ReportDefinition.ReportObjects("Text96")
                        vadd.Text = gdataset.Tables("vdet").Rows(0).Item("email")
                        vadd = r.ReportDefinition.ReportObjects("Text98")
                        vadd.Text = gdataset.Tables("vdet").Rows(0).Item("phone1") & "," & gdataset.Tables("vdet").Rows(0).Item("phone2")
                        'vadd = r.ReportDefinition.ReportObjects("Text97")
                        'vadd.Text = gdataset.Tables("vdet").Rows(0).Item("phone2")
                        vadd = r.ReportDefinition.ReportObjects("Text105")
                        vadd.Text = gdataset.Tables("vdet").Rows(0).Item("fax")
                        vadd = r.ReportDefinition.ReportObjects("Text99")
                        vadd.Text = gdataset.Tables("vdet").Rows(0).Item("contactperson")
                        vadd = r.ReportDefinition.ReportObjects("Text100")
                        vadd.Text = gdataset.Tables("vdet").Rows(0).Item("tinno")
                        vadd = r.ReportDefinition.ReportObjects("Text101")
                        vadd.Text = gdataset.Tables("vdet").Rows(0).Item("panno")
                        vadd = r.ReportDefinition.ReportObjects("Text50")
                        vadd.Text = gdataset.Tables("vdet").Rows(0).Item("GSTINNO")
                    End If
                End If
                ''' ***** end filling Address *****
                '********************************************************************

                rViewer.Show()
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If

            '''Else
            '''    gPrint = False
            '''    Call printoperation()
            '''End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Txt_Storecode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Storecode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Txt_Storecode.Text = "" Then
                Call cmd_DeptHelp_Click(cbo_dept, e)
            Else
                Txt_Storecode_Validated(sender, e)
            End If
        End If

    End Sub

    Private Sub Txt_QuotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_QuotNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_Vcode.Focus()
        End If

    End Sub

    Private Sub Txt_Vcode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Vcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Cmd_VcodeHelp.Enabled = True Then
                Call Cmd_VcodeHelp_Click(Cmd_VcodeHelp, e)
            End If
        End If

    End Sub

    Private Sub Txt_Vcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Vcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Txt_Vcode.Text = "" Then
                Call Cmd_VcodeHelp_Click(Cmd_VcodeHelp, e)
            Else
                Call Txt_Vcode_Validated(sender, e)
            End If
        End If

    End Sub

    Private Sub Cbo_Approvedby_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cbo_Approvedby.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If (Cbo_Approvedby.Text = "APPROVED") Then
                Cbo_POStatus.Text = "RELEASED"

            End If
            Cbo_POStatus.Focus()
        End If

    End Sub




    Private Sub Cbo_POStatus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cbo_POStatus.KeyPress
        If Asc(e.KeyChar) = 13 Then
            AxfpSpread1.Focus()
            AxfpSpread1.SetActiveCell(1, 1)
        End If

    End Sub

    Private Sub Txt_Remarks_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Remarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXT_TRANSPORT.Focus()

        End If
    End Sub

    
    Private Sub txt_SalesTax_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_SalesTax.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_MOD.Focus()
        End If
    End Sub

    Private Sub txt_MOD_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_MOD.KeyDown
        If e.KeyCode = Keys.Enter Then
            TXT_DOCTHROUGH.Focus()
        End If
    End Sub

    Private Sub TXT_DOCTHROUGH_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_DOCTHROUGH.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmdAdd.Focus()
        End If
    End Sub

    Private Sub Cbo_PODate_KeyDown(sender As Object, e As KeyEventArgs) Handles Cbo_PODate.KeyDown
        If e.KeyCode = Keys.Enter Then
            CmbPoType.Focus()
        End If
    End Sub

    Private Sub CmbPoType_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbPoType.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpvalidfrom.Focus()
        End If
    End Sub

    Private Sub dtpvalidfrom_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpvalidfrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpvalidto.Focus()
        End If
    End Sub

    Private Sub dtpvalidto_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpvalidto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cbo_Approvedby.Focus()
        End If
    End Sub

    Private Sub TXT_TRANSPORT_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_TRANSPORT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call AxfpSpread1_Leave(sender, e)
            Txt_AdvanceAmt.Focus()
        End If
    End Sub

    Private Sub TXT_TRANSPORT_TextChanged(sender As Object, e As EventArgs) Handles TXT_TRANSPORT.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_Insurance.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            TXT_TRANSPORT.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub TXT_OVERALLDISC_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_OVERALLDISC.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call AxfpSpread1_Leave(sender, e)
            Txt_POTerms.Focus()
        End If
    End Sub

    Private Sub TXT_OVERALLDISC_TextChanged(sender As Object, e As EventArgs) Handles TXT_OVERALLDISC.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_Insurance.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            TXT_OVERALLDISC.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub Txt_AdvanceAmt_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_AdvanceAmt.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call AxfpSpread1_Leave(sender, e)
            txtothchargeplus.Focus()
        End If
    End Sub


   

   
    Private Sub Txt_AdvanceAmt_TextChanged(sender As Object, e As EventArgs) Handles Txt_AdvanceAmt.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_Insurance.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            Txt_AdvanceAmt.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub txtothchargeplus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtothchargeplus.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call AxfpSpread1_Leave(sender, e)
            txtothchargemin.Focus()

        End If
    End Sub

    Private Sub txtothchargeplus_TextChanged(sender As Object, e As EventArgs) Handles txtothchargeplus.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_Insurance.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            txtothchargeplus.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub txtothchargemin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtothchargemin.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call AxfpSpread1_Leave(sender, e)
            TXT_OVERALLDISC.Focus()
        End If
    End Sub

    Private Sub txtothchargemin_TextChanged(sender As Object, e As EventArgs) Handles txtothchargemin.TextChanged
        Dim myRegex As New Regex("^[0-9]*\.?[0-9]{0,2}$")
        If myRegex.IsMatch(Txt_Insurance.Text.Trim) = False Then
            MsgBox("Invalid characters found")
            txtothchargemin.Text = ""
            Exit Sub
        End If
    End Sub

   

  
    Private Sub CmbPoType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPoType.SelectedIndexChanged
        potype = CmbPoType.Text
    End Sub

   
   
    Private Sub CmdPrint_Click(sender As Object, e As EventArgs) Handles CmdPrint.Click
        gPrint = True

        CmdView_Click(sender, e)
        'Try
        '    Dim rViewer As New Viewer
        '    Dim sqlstring, SSQL As String
        '    Dim r As New CryPO
        '    sqlstring = " SELECT * FROM  VW_POBILL "
        '    sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "' AND VERSIONNO ='" + Trim(txt_PONo.Text) + "-0'"
        '    sqlstring = sqlstring & " ORDER BY PONO,PODATE"

        '    gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
        '    If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
        '        rViewer.ssql = sqlstring
        '        rViewer.Report = r
        '        rViewer.TableName = "VW_PO_POBILL"
        '        Dim textobj1 As TextObject
        '        textobj1 = r.ReportDefinition.ReportObjects("Text12")
        '        textobj1.Text = MyCompanyName

        '        Dim textobj3 As TextObject
        '        textobj3 = r.ReportDefinition.ReportObjects("Text15")
        '        textobj3.Text = Address1 & " , " & Address2 & " , " & gCity & " - " & gPincode
        '        Dim textobj13 As TextObject
        '        textobj13 = r.ReportDefinition.ReportObjects("Text6")
        '        textobj13.Text = gFinancalyearStart + "-" + gFinancialyearEnd


        '        rViewer.Show()
        '    Else
        '        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        '    End If

        'Catch ex As Exception
        '    MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End Try

    End Sub

  
    Private Sub cmd_DeptHelp_Click(sender As Object, e As EventArgs) Handles cmd_DeptHelp.Click
        sqlstring = "Select * from  Invstore_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "'"
        gconnection.getDataSet(sqlstring, "Invstore_CategoryMaster")

        gSQLString = "SELECT isnull(STORECODE,'') AS STORECODE , ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER "
        If (gdataset.Tables("Invstore_CategoryMaster").Rows.Count > 0) Then
            M_WhereCondition = " WHERE STORESTATUS = 'M'  and storecode in ( select Storecode from Invstore_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "') "
        Else
            M_WhereCondition = " WHERE STORESTATUS = 'M' "
        End If

        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "  STORECODE   |        STORE DESCRIPTION                 "
        vform.vCaption = "DEPARTMENT HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_Storecode.Text = vform.keyfield
            cbo_dept.Text = Trim(vform.keyfield1 & "")
            Call cbo_dept_Validated(txt_PONo.Text, e)
        End If
        vform.Close()
        vform = Nothing

    End Sub

 

    Private Sub Cmd_VcodeHelp_Click(sender As Object, e As EventArgs) Handles Cmd_VcodeHelp.Click
        Dim vform As New ListOperattion1
        sqlstring = "select vendorcode from Invvendor_CategoryMaster where categorycode='" + cbo_warehouse.Text + "'"



        gconnection.getDataSet(sqlstring, "Invvendor_CategoryMaster")
        If UCase(gShortname) = "CCL" Then
            gSQLString = "SELECT ISNULL(SLCODE,0) AS SLCODE, ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER"
        Else
            gSQLString = "SELECT ISNULL(VENDORCODE,'') AS VENDORCODE, ISNULL(VENDORNAME,'') AS VENDORNAME FROM PO_VIEW_VENDORMASTER "
        End If

        If (gdataset.Tables("Invvendor_CategoryMaster").Rows.Count > 0) Then
            If UCase(gShortname) = "CCL" Then
                M_WhereCondition = " where ACCODE='L1090' AND SLCODE in (select vendorcode from Invvendor_CategoryMaster where categorycode='" + cbo_warehouse.Text + "')"
            Else
                M_WhereCondition = " where vendorcode in (select vendorcode from Invvendor_CategoryMaster where categorycode='" + cbo_warehouse.Text + "')"
            End If

        Else
            If UCase(gShortname) = "CCL" Then
                M_WhereCondition = " where ACCODE='L1090'  "
            Else
                M_WhereCondition = " "
            End If
            M_WhereCondition = " where vendorcode in (select vendorcode from Invvendor_CategoryMaster where categorycode='" + cbo_warehouse.Text + "')"
        End If
        'If Trim(search) = " " Then
        '    M_WhereCondition = " WHERE ACCODE= '" & gCreditors & "' "
        '    M_WhereCondition = " "
        'Else
        '    M_WhereCondition = " "
        'End If
        If UCase(gShortname) = "CCL" Then
            vform.Field = " SLCODE,SLNAME "
        Else
            vform.Field = " VENDORNAME,VENDORCODE "
        End If

            vform.vFormatstring = "     VENDOR CODE     |                   VENDOR NAME                   "
            vform.vCaption = "VENDOR MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_Vcode.Text = Trim(vform.keyfield & "")
                Txt_Vname.Text = Trim(vform.keyfield1 & "")
                Txt_Vcode.Focus()
            End If
            vform.Close()
            vform = Nothing
            Cbo_PODate.Focus()

    End Sub
 
  Private Sub Cmd_PONoHelp_Click(sender As Object, e As EventArgs) Handles Cmd_PONoHelp.Click
        Dim vform As New ListOperattion1

        Dim Q As String = ""

        If Mid(UCase(gShortname), 1, 3) = "NIZ" Then
            gSQLString = "SELECT ISNULL(pono,'') AS PONO,ISNULL(podate,'') AS PODATE,ISNULL(podepartment,'') AS PODEPARTMENT,ISNULL(vendorname,'') AS vendorname FROM PO_HDR H INNER JOIN  PO_VIEW_VENDORMASTER V ON H.povendorcode=V.vendorcode"

            M_WhereCondition = " where  storecode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "')  "

            If cbo_dept.Text <> "" Then
                Q = " and PODEPARTMENT='" + cbo_dept.Text + "'"
                ' M_WhereCondition = " where versionno=pono+'-0' and PODEPARTMENT='" + cbo_dept.Text + "'"
            Else
                ' M_WhereCondition = " where versionno=pono+'-0'"
            End If
            If UCase(gShortname).Trim() <> "SATC" Then
                If cbo_warehouse.Text <> "" Then
                    Q = Q & " and doctype='" + cbo_warehouse.Text + "'"
                    ' M_WhereCondition = " where versionno=pono+'-0' and PODEPARTMENT='" + cbo_dept.Text + "'"
                Else
                    ' M_WhereCondition = " where versionno=pono+'-0'"
                End If
            End If
            M_WhereCondition = M_WhereCondition & Q

            M_ORDERBY = " podate DESC ,Autoid desc"
            vform.Field = "PONO,PODEPARTMENT"
            vform.vFormatstring = "           PONO                |      PODATE            |         PODEPARTMENT         |             VENORNAME            "

        Else
            If gShortname = "SKYYE" Then
                gSQLString = "SELECT ISNULL(pono,'') AS PONO,ISNULL(podate,'') AS PODATE,ISNULL(podepartment,'') AS PODEPARTMENT,ISNULL(APPROVE,'N')AS APPROVE FROM PO_HDR"
            Else
                gSQLString = "SELECT ISNULL(pono,'') AS PONO,ISNULL(podate,'') AS PODATE,ISNULL(podepartment,'') AS PODEPARTMENT FROM PO_HDR"
            End If


            M_WhereCondition = " where  storecode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "')  "

            If cbo_dept.Text <> "" Then
                Q = " and PODEPARTMENT='" + cbo_dept.Text + "'"
                ' M_WhereCondition = " where versionno=pono+'-0' and PODEPARTMENT='" + cbo_dept.Text + "'"
            Else
                ' M_WhereCondition = " where versionno=pono+'-0'"
            End If
            If UCase(gShortname).Trim() <> "SATC" Then
                If cbo_warehouse.Text <> "" Then
                    Q = Q & " and doctype='" + cbo_warehouse.Text + "'"
                    ' M_WhereCondition = " where versionno=pono+'-0' and PODEPARTMENT='" + cbo_dept.Text + "'"
                Else
                    ' M_WhereCondition = " where versionno=pono+'-0'"
                End If
            End If
            M_WhereCondition = M_WhereCondition & Q

            M_ORDERBY = " podate DESC ,Autoid desc"

            vform.Field = "PONO,PODEPARTMENT"


            If gShortname = "SKYYE" Then
                vform.vFormatstring = "                 PONO                 |     PODATE      |      PODEPARTMENT   |     APPROVE      "
            Else
                vform.vFormatstring = "                 PONO                       |            PODATE              |         PODEPARTMENT                 "
            End If

        End If





        vform.vCaption = "PURCHASE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_PONo.Text = Trim(vform.keyfield & "")
            Call txt_PONo_Validated(txt_PONo.Text, e)
        End If
        vform.Close()
        M_ORDERBY = ""
        vform = Nothing
        'txt_PONo.Focus()
        CmdFreeze.Enabled = True

    End Sub

 

    Private Sub Cmd_POTermsHelp_Click(sender As Object, e As EventArgs) Handles Cmd_POTermsHelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "Select ISNULL(PAYMENTTERMCODE,0) As PAYMENTTERMCODE,ISNULL(PAYMENTTERMDESC,'') AS PAYMENTTERMDESC FROM PO_PAYMENTTERMS "
        M_WhereCondition = ""
        vform.Field = " PAYMENTTERMCODE, PAYMENTTERMDESC "
        vform.vFormatstring = "     PAYMENTTERM CODE     |                   PAYMENTTERMDESC               "
        vform.vCaption = "PAYMENTTERM MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_POTerms.Text = Trim(vform.keyfield & "")
            TXT_PAYMTTERMS_DESC.Text = Trim(vform.keyfield1 & "")
            Call Txt_POTerms_Validated(Txt_POTerms, e)
        End If
        vform.Close()
        vform = Nothing
        Me.Txt_DeliveryTerms.Focus()
    End Sub

    Private Sub validateFillDELIVERYTERM()

        Dim GROUPCODE() As String
        Chk_AllGroup.Checked = False
        Dim i, m As Integer
        sqlstring = " SELECT ISNULL(PODELIVERYTERMS,0) AS DELIVERYTERMCODE,ISNULL(PODELIVERY,'') AS DELIVERYTERMDESC FROM PO_DELIVERYTERMS_DET where pono='" & txt_PONo.Text & "'"
        gconnection.getDataSet(sqlstring, "PO_DELIVERYTERMS_DET")
        If gdataset.Tables("PO_DELIVERYTERMS_DET").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("PO_DELIVERYTERMS_DET").Rows.Count - 1
                With gdataset.Tables("PO_DELIVERYTERMS_DET").Rows(i)
                    For m = 0 To ChkLst_Group.Items.Count - 1
                        GROUPCODE = Split(ChkLst_Group.Items(m), "-->")
                        If Trim(GROUPCODE(0)) = Trim(CStr(.Item("DELIVERYTERMCODE"))) Then
                            ChkLst_Group.SetItemChecked(m, True)
                        End If
                    Next
                End With
            Next
        End If
    End Sub

   
    Private Sub Cmd_DeliveryTermHelp_Click(sender As Object, e As EventArgs) Handles Cmd_DeliveryTermHelp.Click

        'Dim objStockSummary1 As New PO_DeliveryTerm
        'pono_del = Trim(txt_PONo.Text)
        'objStockSummary1.pono = Trim(txt_PONo.Text)
        'objStockSummary1.ShowDialog()

        Me.GB_DELI.Visible = True
        GB_DELI.BringToFront()

        'Dim sqlstring As String
        'Dim vform As New ListOperattion1


        'gSQLString = "SELECT ISNULL(DELIVERYTERMCODE,0) AS DELIVERYTERMCODE,ISNULL(DELIVERYTERMDESC,'') AS DELIVERYTERMDESC FROM PO_DELIVERYTERMS "
        'M_WhereCondition = "  where isnull(freeze,'N')<>'Y' "
        'vform.Field = " DELIVERYTERMCODE, DELIVERYTERMDESC "
        'vform.vFormatstring = "     DELIVERYTERM CODE     |                   DELIVERYTERMDESC        "
        'vform.vCaption = "DELIVERYTERM MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.ShowDialog(Me)
        'If Trim(vform.keyfield & "") <> "" Then
        '    Txt_DeliveryTerms.Text = Trim(vform.keyfield & "")
        '    TXT_DELIVTERMS_DESC.Text = Trim(vform.keyfield1 & "")
        '    Call Txt_DeliveryTerms_Validated(Txt_DeliveryTerms, e)
        'End If
        'vform.Close()
        'vform = Nothing
        Me.txt_SalesTax.Focus()
    End Sub

    Private Sub Txt_Storecode_Validated(sender As Object, e As EventArgs) Handles Txt_Storecode.Validated
        sqlstring = "Select * from  Invstore_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "'"
        gconnection.getDataSet(sqlstring, "Invstore_CategoryMaster")

        sqlstring = "SELECT isnull(STORECODE,'') AS STORECODE , ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER "
        If (gdataset.Tables("Invstore_CategoryMaster").Rows.Count > 0) Then
            sqlstring = sqlstring & " WHERE STORESTATUS = 'M'  and storecode in ( select Storecode from Invstore_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "')  and  STORECODE='" + Txt_Storecode.Text + "'"
        Else
            sqlstring = sqlstring & " WHERE STORESTATUS = 'M' and  STORECODE='" + Txt_Storecode.Text + "'"
        End If
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        If (gdataset.Tables("Storemaster").Rows.Count > 0) Then
            Txt_Storecode.Text = gdataset.Tables("Storemaster").Rows(0).Item("STORECODE")
            cbo_dept.Text = Trim(gdataset.Tables("Storemaster").Rows(0).Item("STOREDESC"))
            Call cbo_dept_Validated(txt_PONo.Text, e)
        Else
            Txt_Storecode.Text = ""
        End If
      
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label39_Click(sender As Object, e As EventArgs) Handles Label39.Click

    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click

    End Sub

    Private Sub CMD_APPROVE_Click(sender As Object, e As EventArgs) Handles CMD_APPROVE.Click

        sqlstring = "SELECT  isnull(APPROVE,'')as approve FROM PO_HDR WHERE pono='" & txt_PONo.Text & "' "
        gconnection.getDataSet(sqlstring, "updte")
        Dim APPR As String
        APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
        If APPR = "Y" Then
            MsgBox("This Po is already Approved ")
            Exit Sub
        End If


        Dim sql, pwd, altpwd As String
        sql = "select isnull(po_password,'')as po_password,isnull(po_altpassword,'')as po_altpassword from INV_LINKSETUP"
        gconnection.getDataSet(sql, "password")

        pwd = gdataset.Tables("password").Rows(0).Item("po_password")
        altpwd = gdataset.Tables("password").Rows(0).Item("po_altpassword")

        Dim Pas As String
        '  Pas = InputBox("Enter Approve Password", gCompanyname)

        Dim Cinput As New InputBoxCustom
        Cinput.ShowDialog(Me)
        If Cinput.COMMENT = "" Then
            MessageBox.Show("Password Can't Be Blank")
            Exit Sub
        Else
            Pas = Cinput.COMMENT
        End If


        If Pas = pwd Or Pas = altpwd Then
            MsgBox("Po Approved Successfully")
            Dim sql1 As String = "update po_hdr set APPROVE='Y' where pono='" & txt_PONo.Text & "'"
            gconnection.getDataSet(sql1, "updte")
            CmdClear_Click(sender, e)
        Else
            MsgBox("Approve Password is Incorrect")
            Exit Sub
        End If


    End Sub

    Private Sub Txt_Vcode_Validated(sender As Object, e As EventArgs) Handles Txt_Vcode.Validated

        sqlstring = "select vendorcode from Invvendor_CategoryMaster where categorycode='" + cbo_warehouse.Text + "'"

        gconnection.getDataSet(sqlstring, "Invvendor_CategoryMaster")


        If (gdataset.Tables("Invvendor_CategoryMaster").Rows.Count > 0) Then
            If UCase(gShortname) = "CCL" Then
                sqlstring = "SELECT ISNULL(SLCODE,0) AS SLCODE, ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER  where ACCODE='L1090' AND SLCODE in (select vendorcode from Invvendor_CategoryMaster where categorycode='" + cbo_warehouse.Text + "') AND SLCODE='" + Txt_Vcode.Text + "'"
            Else
                sqlstring = "SELECT ISNULL(VENDORCODE,'') AS SLCODE, ISNULL(VENDORNAME,'') AS SLNAME FROM PO_VIEW_VENDORMASTER  where vendorcode in (select vendorcode from Invvendor_CategoryMaster where categorycode='" + cbo_warehouse.Text + "') AND VENDORCODE='" + Txt_Vcode.Text + "'"
            End If

        Else
            If UCase(gShortname) = "CCL" Then
                sqlstring = "SELECT ISNULL(SLCODE,0) AS SLCODE, ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER  where ACCODE='L1090' AND SLCODE='" + Txt_Vcode.Text + "'"
            Else
                sqlstring = "SELECT ISNULL(VENDORCODE,'') AS SLCODE, ISNULL(VENDORNAME,'') AS SLNAME FROM PO_VIEW_VENDORMASTER  WHERE  VENDORCODE='" + Txt_Vcode.Text + "' "
            End If

        End If
        gconnection.getDataSet(sqlstring, "ACCOUNTSSUBLEDGERMASTER")
        If (gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows.Count > 0) Then
            Txt_Vcode.Text = gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("SLCODE")
            Txt_Vname.Text = gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("SLNAME")
            Cbo_PODate.Focus()
        Else
            Txt_Vcode.Text = ""
            Txt_Vcode.Focus()
        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.GB_DELI.Visible = False
    End Sub

    Private Sub Chk_AllGroup_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_AllGroup.CheckedChanged
        Dim i As Integer = 0
        If (Chk_AllGroup.Checked = True) Then
            For i = 0 To ChkLst_Group.Items.Count - 1
                ChkLst_Group.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To ChkLst_Group.Items.Count - 1
                ChkLst_Group.SetItemChecked(i, False)
            Next

        End If

    End Sub
End Class