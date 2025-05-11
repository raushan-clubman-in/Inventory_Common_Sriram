Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions
Public Class Frm_PurchaseOrder_amendment
    Dim SSTR As String
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Dim sql As String
    Dim doctype As String
    Dim grtot, grvat, totaldiscount As Double
    Dim boolchk As Boolean
    Dim potype As String
    Dim VATFLAG As Boolean = True


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
            Dim sql As String = "Select categorycode,Usercode from Categoryuserdetail where usercode='" & gUsername & "' and isnull(void,'')<>'Y'"

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
        Dim sqlstring, financalyear, shorNAme As String
        Try
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            sqlstring = "SELECT MAX(Cast(SUBSTRING(PO_NO,1,6) As Numeric)) FROM PO_HDR "
            shorNAme = Mid(gShortname, 1, 3)
            '  sqlstring = " SELECT MAX(Cast(SUBSTRING(POno,12,6) As Numeric)) FROM PO_HDR "
            If gconnection.Myconn.State <> ConnectionState.Open Then
                gconnection.openConnection()
            End If

            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    '    txt_PONo.Text = gShortname & "/" & doctype & "/PO/000001/" & financalyear
                    txt_PONo.Text = shorNAme & "/PO/000001/" & financalyear

                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    '  txt_PONo.Text = gShortname & "/" & doctype & "/PO/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    txt_PONo.Text = shorNAme & "/PO/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear

                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                '  txt_PONo.Text = gShortname & "/" & doctype & "/PO/000001/" & financalyear
                txt_PONo.Text = shorNAme & "/PO/000001/" & financalyear

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
    End Sub
    Private Sub autogenerateversion()
        Dim sqlstring, financalyear As String
        Try
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            'sqlstring = " SELECT MAX(Cast(SUBSTRING(versionno,21,(LEN(versionno)-20) )As Numeric))  FROM PO_HDR  WHERE PONO='" + txt_PONo.Text + "'  "
            sqlstring = " SELECT MAX(Cast(SUBSTRING(versionno,22,(LEN(versionno)-21) )As Numeric))   FROM PO_HDR  WHERE PONO='" + txt_PONo.Text + "'  "
            If gconnection.Myconn.State <> ConnectionState.Open Then
                gconnection.openConnection()
            End If

            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    txtversion.Text = txt_PONo.Text + "-" + Format(gdreader(0))
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    txtversion.Text = txt_PONo.Text + "-" + Format(gdreader(0))
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txtversion.Text = txt_PONo.Text + "-" + Format(gdreader(0))
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
    End Sub


    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Purchase Order Amendment"
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.cmd_view.Enabled = False
        Me.cmd_print.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_view.Enabled = True
                    Me.cmd_print.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.cmd_view.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.cmd_print.Enabled = True
                End If
            Next
        End If


    End Sub

    Private Sub binditemcode()
        Dim vform As New ListOperattion1
        sqlstring = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "'"
        gconnection.getDataSet(sqlstring, "Inv_VendorMaster")

        gSQLString = "select I.itemcode,M.Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then

            M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "')"

        Else
            M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "'"


        End If

        ' M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "'"
        vform.Field = " I.itemcode,Itemname,uom"
        vform.vFormatstring = "    itemcode    |      Itemname        |  Uom           "
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

                End If
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            End If
        End If

    End Sub
    Private Sub binditemname()
        Dim vform As New ListOperattion1

        sqlstring = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "'"
        gconnection.getDataSet(sqlstring, "Inv_VendorMaster")

        gSQLString = "select itemcode,Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "

        If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then

            M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "')"

        Else
            M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "'"


        End If
        '  M_WhereCondition = " where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "'"
        vform.Field = " I.itemcode, I.Itemname,I.Uom,batchprocess"
        vform.vFormatstring = "    itemcode    |     Itemname              |       UOM     |"
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos1 = 2
        vform.KeyPos1 = 3
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

                End If
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            End If
        End If

    End Sub

    Private Sub CALCULATE()
        Dim ITEMCODE, UOM As String
        ' Dim overalldisc, othercharge, extra As Double
        Dim totqty, totamt, taxamt, discamt, freeqty, totfreeqty, grossamt As Double
        Dim itemqty, itemrate, itemamount, itemtax, itemdisc, discperc, itemamountwithdisc, taxperc, itemtot, SPLCESS, ISPLCESS, TOSPLCESS As Double

        If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Or AxfpSpread1.ActiveCol = 7 Or AxfpSpread1.ActiveCol = 8 Or AxfpSpread1.ActiveCol = 10 Or AxfpSpread1.ActiveCol = 18 Then

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
                AxfpSpread1.Text = itemamount
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 7
                discperc = Val(AxfpSpread1.Text)

                itemdisc = (itemamount * discperc) / 100
                itemamountwithdisc = itemamount - itemdisc
                AxfpSpread1.SetText(9, i, Val(itemamountwithdisc))

                AxfpSpread1.Row = i
                AxfpSpread1.Col = 11
                taxperc = Val(AxfpSpread1.Text)
                itemtax = Val(Math.Round((itemamountwithdisc * taxperc) / 100, 2))


                If ITEMCODE <> "" And UOM <> "" Then

                    If Mid(CStr(CmdAdd.Text), 1, 1) = "A" Then
                        SPLCESS = GetSPLCESS(ITEMCODE, Trim(UOM))
                        ISPLCESS = (SPLCESS * itemqty)
                        AxfpSpread1.Col = 18
                        AxfpSpread1.Text = ISPLCESS
                    Else
                        AxfpSpread1.Col = 18
                        ISPLCESS = Val(AxfpSpread1.Text)
                    End If
                Else
                    AxfpSpread1.Col = 18
                    ISPLCESS = Format(AxfpSpread1.Text, "0.00")

                End If
                TOSPLCESS = TOSPLCESS + ISPLCESS
                itemtot = itemamountwithdisc + itemtax + ISPLCESS

                AxfpSpread1.Col = 8
                AxfpSpread1.Text = itemdisc
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
            TXT_Addcess.Text = Math.Round(TOSPLCESS, 2)
            Txt_TotalTax.Text = Math.Round(taxamt, 2)
            TXT_GROSSVALUE.Text = Math.Round(grossamt, 2)
            Txt_POValue.Text = Math.Round(itemtot, 2)
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
    Private Sub caloperation()
        Dim i, withoutvat, tottax, totqty As Double
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
        Txt_POValue.Text = Format(Val((grtot)) + Val(TXT_CF.Text) + Val(TXT_TRANSPORT.Text) + Val(TXT_DELIVERY.Text) - Val(TXT_OVERALLDISC.Text) + Val(txtothchargeplus.Text) - Val(txtothchargemin.Text), "0.00")
        Txt_TotalVat.Text = Format(Val(grvat), "0.00")
        Txt_TotalTax.Text = Format(Val(tottax), "0.00")
        Txt_Balance.Text = Format(Val(Txt_POValue.Text) - Val(Txt_AdvanceAmt.Text), "0.00")

    End Sub
    Private Sub addoperation()
        Dim i As Integer
        Dim insert(0) As String
        Dim version As String
        Dim versionindex As Integer
        Dim POSTATUS As String
        If Mid(CmdAdd.Text, 1, 1) = "U" Then
            autogenerateversion()


            Dim sqlstring = "Update po_hdr set postatus='AMENDED' where pono='" + txt_PONo.Text + "'  and isnull(postatus,'') not in ('CANCELLED','CLOSED','AMENDED') "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
            Dim index As Integer = txtversion.Text.LastIndexOf("-")
            version = txtversion.Text.Substring(index + 1, (txtversion.Text.Length - (index + 1)))
            versionindex = Val(version) + 1
            Dim pono() As String
            pono = Split(Trim(txt_PONo.Text), "/")

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

            sqlstring = "DELETE FROM  po_hdr  where pono='" + txt_PONo.Text + "'   "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            sqlstring = "insert into po_hdr ([pono] ,[DOCTYPE] ,[storecode],[podate] ,[poquotno] ,[povendorcode] ,[podepartment] ,[poapprovedby] ,[postatus] , [potype],[povalidfrom],[povalidupto],"
            sqlstring = sqlstring & " [povalue] ,[pototalvat] ,[pototaltax] ,[pototaldiscount],[poadvance] ,[pobalance] ,[poterms],[pootherchgplus],[pootherchgmin],"
            sqlstring = sqlstring & "[podeliveryterms] , [pomcpo] ,[poremarks] ,[poclosure] ,[poquotdate],  "
            sqlstring = sqlstring & "[freeze] ,[adduser] ,[adddatetime],[POOVERALLDISC],[POCF],[POTRANSPORT],[PODELIVERYAMT],[POSALET],[PODESPMODE],[PODOCSTHROUGH],[totqty],[VERSIONno],[po_no]) Values("
            sqlstring = sqlstring & "'" + txt_PONo.Text + "',"
            sqlstring = sqlstring & "'" & doctype & "',"
            sqlstring = sqlstring & "'" & Txt_Storecode.Text & "',"

            sqlstring = sqlstring & "'" & Format(CDate(Cbo_PODate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & "'" & Me.Txt_QuotNo.Text & "',"
            sqlstring = sqlstring & "'" & Me.Txt_Vcode.Text & "',"
            sqlstring = sqlstring & "'" & Me.cbo_dept.Text & "',"
            sqlstring = sqlstring & "'" & Me.Cbo_Approvedby.Text & "',"
            If (Cbo_POStatus.Text = "AMENDED") Then
                POSTATUS = "RELEASED"
            Else
                POSTATUS = Cbo_POStatus.Text
            End If
            sqlstring = sqlstring & "'" & POSTATUS & "',"
            sqlstring = sqlstring & "'" & Me.CmbPoType.Text & "',"
            sqlstring = sqlstring & "'" & Format(CDate(dtpvalidfrom.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & "'" & Format(CDate(dtpvalidto.Value), "dd/MMM/yyyy") & "',"


            sqlstring = sqlstring & Format(Val(Me.Txt_POValue.Text), "0.00") & ","
            sqlstring = sqlstring & Format(Val(Me.Txt_TotalVat.Text), "0.00") & ","
            sqlstring = sqlstring & Format(Val(Me.Txt_TotalTax.Text), "0.00") & ","
            sqlstring = sqlstring & Format(Val(totaldiscount), "0.00") & ","
            sqlstring = sqlstring & Format(Val(Me.Txt_AdvanceAmt.Text), "0.00") & ","
            sqlstring = sqlstring & Format(Val(Me.Txt_Balance.Text), "0.00") & ","
            sqlstring = sqlstring & "'" & Txt_POTerms.Text & "',"

            sqlstring = sqlstring & "'" & Format(Val(txtothchargeplus.Text), "0.00") & "',"
            sqlstring = sqlstring & "'" & Format(Val(txtothchargemin.Text), "0.00") & "',"
            sqlstring = sqlstring & "'" & Txt_DeliveryTerms.Text & "',"
            sqlstring = sqlstring & "'N',"

            sqlstring = sqlstring & "'" & Replace(Trim(CStr(Txt_Remarks.Text)), "'", "?") & "',"
            sqlstring = sqlstring & "'N'," 'FOR CLOSURE DEFAULT NO
            sqlstring = sqlstring & "'" & Format(CDate(CBO_QUOT_DATE.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & "'N',"

            sqlstring = sqlstring & "'" & Trim(gUsername) & "',"
            sqlstring = sqlstring & "getDate(),"

            sqlstring = sqlstring & Format(Val(Me.TXT_OVERALLDISC.Text), "0.00") & ","
            sqlstring = sqlstring & Format(Val(Me.TXT_CF.Text), "0.00") & ","
            sqlstring = sqlstring & Format(Val(Me.TXT_TRANSPORT.Text), "0.00") & ","
            sqlstring = sqlstring & Format(Val(Me.TXT_DELIVERY.Text), "0.00") & ","
            sqlstring = sqlstring & " '" & txt_SalesTax.Text & "',"
            sqlstring = sqlstring & " '" & txt_MOD.Text & "',"
            sqlstring = sqlstring & " '" & TXT_DOCTHROUGH.Text & "',"
            sqlstring = sqlstring & " '" & Format(Val(LabQTY.Text), "0.00") & "',"
            sqlstring = sqlstring & " '" & txt_PONo.Text + "-" + versionindex.ToString() & "','" + pono(2) + "')"
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
                        sql(i) = "INSERT INTO po_ITEMDETAILS(PONO,ITEMCODE,itemname,UOM,QUANTITY,RATE,baseamount,discper,DiscAmt,amountafterdiscount,taxcode,taxper,VatAmt,TOTALamount,othchg,raterange,qtyrange,freeze,versionno,companycode,SPLCESS) Values("
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
                        sql(i) = sql(i) & Format(Val(rate), "0.00") & ","
                        .Col = 6
                        .Row = i
                        baseamt = Val(.Text)
                        sql(i) = sql(i) & Format(Val(baseamt), "0.00") & ","

                        .Col = 7
                        .Row = i
                        discper = Val(.Text)
                        sql(i) = sql(i) & Format(Val(discper), "0.00") & ","
                        .Col = 8
                        .Row = i
                        '   discount = (rate * quantity * discper) / 100
                        discount = Val(.Text)
                        sql(i) = sql(i) & Format(Val(discount), "0.00") & ","
                        .Col = 9
                        .Row = i
                        amountaftdisc = Val(.Text)
                        sql(i) = sql(i) & Format(Val(amountaftdisc), "0.00") & ","
                        .Col = 10
                        .Row = i
                        '  Amount = .Text
                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        .Col = 11
                        .Row = i
                        taxper = Val(.Text)
                        ' DiscAmt = .Text
                        sql(i) = sql(i) & Format(Val(taxper), "0.00") & ","
                        .Col = 12
                        .Row = i
                        VatAmt = Val(.Text)
                        sql(i) = sql(i) & Format(Val(VatAmt), "0.00") & ","
                        .Col = 13
                        .Row = i
                        total = Val(.Text)
                        sql(i) = sql(i) & Format(Val(AxfpSpread1.Text), "0.00") & ","
                        .Col = 14
                        .Row = i
                        othchg = Val(.Text)
                        sql(i) = sql(i) & Format(Val(othchg), "0.00") & ","
                        .Col = 15
                        .Row = i

                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        .Col = 16
                        .Row = i

                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        .Col = 17
                        .Row = i
                        sql(i) = sql(i) & "'N','" + txt_PONo.Text + "-" + versionindex.ToString() + "','" & AxfpSpread1.Text & "',"
                        .Col = 18
                        .Row = i
                        SPLCESS = Val(.Text)
                        sql(i) = sql(i) & Format(Val(SPLCESS), "0.00") & ")"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sql(i)

                    End If
                Next
                'ReDim sqlArray(sql.Length)
                'sqlArray.Copy(sql, sqlArray, sql.Length)

            End With
            gconnection.MoreTrans(insert)
        End If
    End Sub
    Private Sub clearoperation()
        Call clearform(Me)
        Me.Txt_POTerms.Text = "CHQ"
        Me.txt_PONo.Text = ""
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
        Me.Txt_Vname.Clear()
        Me.Txt_Storecode.Text = ""
        'Me.Cbo_POStatus.SelectedIndex = -1
        Me.Txt_ED.Clear()
        Me.Txt_CST.Clear()
        Me.Txt_MODVat.Clear()
        Me.Txt_PTax.Clear()

        Me.CmdAdd.Enabled = True
        Me.CmdFreeze.Enabled = True


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
        Me.txtversion.Clear()


        Me.CmdFreeze.Enabled = True
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.Enabled = True
        Me.TXT_GROSSVALUE.Text = ""
        Me.TXT_CF.Text = ""
        Me.TXT_TRANSPORT.Text = ""
        Me.TXT_OVERALLDISC.Text = ""
        Me.TXT_ADVANCEPERC.Text = ""
        Me.TXT_Addcess.Text = ""
        lbl_Freeze.Visible = False

        'Me.AmendmentGrid.Visible = False
        'Me.FollowupGrid.Visible = False

        Me.Txt_Remarks.Clear()
        Call autogenerate()
        '  Me.cbo_dept.Focus()
        txt_docno.Focus()

    End Sub
    Private Sub voidoperation()
        If Mid(CmdFreeze.Text, 1, 1) = "F" Then
            If gShortname = "SKYYE" Then
                sqlstring = "SELECT isnull(APPROVE,'')as approve FROM PO_HDR WHERE pono='" & txt_PONo.Text & "' "
                gconnection.getDataSet(sqlstring, "updte")
                Dim APPR As String
                APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
                If APPR = "Y" Then
                    MsgBox("This Po is already Approved  You can't void it ")
                    Exit Sub
                End If
            End If


            sqlstring = "UPDATE  po_HDR "
            sqlstring = sqlstring & " SET Freeze= 'Y',Freezeuser='" & gUsername & " ', Freezedatetime='" & Format(Now, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "PO_HDR")
            sqlstring = "UPDATE  po_ITEMDETAILS "
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
            sqlstring = " insert into poamendment_IMAGEHDR( [pono] ,[DOCTYPE] ,[storecode],[podate] ,[poquotno] ,[povendorcode] ,[podepartment] ,[poapprovedby] ,[postatus] , [potype],[povalidfrom],[povalidupto], "
            sqlstring = sqlstring & " [povalue] ,[pototalvat] ,[pototaltax] ,[pototaldiscount],[poadvance] ,[pobalance] ,[poterms],[pootherchgplus],[pootherchgmin],"
            sqlstring = sqlstring & "[podeliveryterms] , [pomcpo] ,[poremarks] ,[poclosure] ,  "
            sqlstring = sqlstring & "[freeze] ,[adduser] ,[adddatetime],[POOVERALLDISC],[POCF],[POTRANSPORT],[PODELIVERYAMT],[POSALET],[PODESPMODE],[PODOCSTHROUGH],[totqty]) "

            sqlstring = sqlstring & " select [pono] ,[DOCTYPE] ,[storecode],[podate] ,[poquotno] ,[povendorcode] ,[podepartment] ,[poapprovedby] ,[postatus] , [potype],[povalidfrom],[povalidupto], "
            sqlstring = sqlstring & " [povalue] ,[pototalvat] ,[pototaltax] ,[pototaldiscount],[poadvance] ,[pobalance] ,[poterms],[pootherchgplus],[pootherchgmin],"
            sqlstring = sqlstring & "[podeliveryterms] , [pomcpo] ,[poremarks] ,[poclosure] ,  "
            sqlstring = sqlstring & "[freeze] ,[adduser] ,[adddatetime],[POOVERALLDISC],[POCF],[POTRANSPORT],[PODELIVERYAMT],[POSALET],[PODESPMODE],[PODOCSTHROUGH],[totqty] "
            sqlstring = sqlstring & " from poamendment_hdr where poamendment_hdr.pono= '" & txt_PONo.Text & "'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring


            sqlstring = " Update   poamendment_hdr set "
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

            sqlstring = sqlstring & " povalue=" & Format(Val(Me.Txt_POValue.Text), "0.00") & ","
            sqlstring = sqlstring & " pototalvat=" & Format(Val(Me.Txt_TotalVat.Text), "0.00") & ","
            sqlstring = sqlstring & " pototaltax=" & Format(Val(Me.Txt_TotalTax.Text), "0.00") & ","
            sqlstring = sqlstring & " pototaldiscount=" & Format(Val(totaldiscount), "0.00") & ","
            sqlstring = sqlstring & " poadvance=" & Format(Val(Me.Txt_AdvanceAmt.Text), "0.00") & ","
            sqlstring = sqlstring & " pobalance =" & Format(Val(Me.Txt_Balance.Text), "0.00") & ","
            sqlstring = sqlstring & " poterms='" & Txt_POTerms.Text & "',"

            sqlstring = sqlstring & " pootherchgplus =" & Format(Val(Me.txtothchargeplus.Text), "0.00") & ","
            sqlstring = sqlstring & " pootherchgmin='" & Format(Val(Me.txtothchargemin.Text), "0.00") & "',"

            sqlstring = sqlstring & " podeliveryterms='" & Txt_DeliveryTerms.Text & "',"
            sqlstring = sqlstring & " pomcpo='N',"

            sqlstring = sqlstring & " poremarks='" & Replace(Trim(CStr(Txt_Remarks.Text)), "'", "?") & "',"
            sqlstring = sqlstring & " poclosure='N'," 'FOR CLOSURE DEFAULT NO
            sqlstring = sqlstring & " freeze='N',"

            sqlstring = sqlstring & " adduser='" & Trim(gUsername) & "',"
            sqlstring = sqlstring & " adddatetime='getDate(),"

            sqlstring = sqlstring & " POOVERALLDISC=" & Format(Val(Me.TXT_OVERALLDISC.Text), "0.00") & ","
            sqlstring = sqlstring & " POCF=" & Format(Val(Me.TXT_CF.Text), "0.00") & ","
            sqlstring = sqlstring & " POTRANSPORT=" & Format(Val(Me.TXT_TRANSPORT.Text), "0.00") & ","
            sqlstring = sqlstring & " PODELIVERYAMT=" & Format(Val(Me.TXT_DELIVERY.Text), "0.00") & ","
            sqlstring = sqlstring & " POSALET='" & txt_SalesTax.Text & "',"
            sqlstring = sqlstring & " PODESPMODE='" & txt_MOD.Text & "',"
            sqlstring = sqlstring & " PODOCSTHROUGH='" & TXT_DOCTHROUGH.Text & "',"
            sqlstring = sqlstring & " totqty=" & Format(Val(Me.Labqty.Text), "0.00") & ""

            sqlstring = sqlstring & " WHERE PONO = '" & Trim(txt_PONo.Text) & "'"

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring


            sqlstring = "INSERT INTO poamendment_ITEMDETAILS_LOG(PONO,ITEMCODE,itemname,UOM,QUANTITY,RATE,baseamount,discper,DiscAmt,amountafterdiscount,taxcode,taxper,VatAmt,TOTALamount,othchg,raterange,qtyrange,freeze,updateuser,updatedatetime)  "
            sqlstring = sqlstring & " select PONO,ITEMCODE,itemname,UOM,QUANTITY,RATE,baseamount,discper,DiscAmt,amountafterdiscount,taxcode,taxper,VatAmt,TOTALamount,othchg,raterange,qtyrange,freeze,'" + gUsername + "',getdate() "
            sqlstring = sqlstring & " from PO_ITEMDETAILS "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            sqlstring = "delete from poamendment_ITEMDETAILS WHERE PONO='" & txt_PONo.Text & "'"
            'gconnection.dataOperation(6, sqlstring, "PO_ITEMDETAILS")
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            With AxfpSpread1
                Dim itemcode, itemname, uom, quantity, sqlArray() As String
                Dim sql(Me.AxfpSpread1.DataRowCnt + 20) As String
                Dim requireddate As Date
                Dim rate, baseamt, discper, taxper, discount, vat, vattotal, total, Amount, DiscAmt, VatAmt, amountaftdisc, othchg As Double
                For i = 1 To .DataRowCnt
                    .Col = 1
                    .Row = i
                    itemcode = .Text
                    If Trim(itemcode) <> "" Then
                        sql(i) = "INSERT INTO poamendment_ITEMDETAILS(PONO,ITEMCODE,itemname,UOM,QUANTITY,RATE,baseamount,discper,DiscAmt,amountafterdiscount,taxcode,taxper,VatAmt,TOTALamount,othchg,raterange,qtyrange,freeze) Values("
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
                        sql(i) = sql(i) & Format(Val(rate), "0.00") & ","
                        .Col = 6
                        .Row = i
                        baseamt = Val(.Text)
                        sql(i) = sql(i) & Format(Val(baseamt), "0.00") & ","

                        .Col = 7
                        .Row = i
                        discper = Val(.Text)
                        sql(i) = sql(i) & Format(Val(discper), "0.00") & ","
                        .Col = 8
                        .Row = i
                        '   discount = (rate * quantity * discper) / 100
                        discount = Val(.Text)
                        sql(i) = sql(i) & Format(Val(discount), "0.00") & ","
                        .Col = 9
                        .Row = i
                        amountaftdisc = Val(.Text)
                        sql(i) = sql(i) & Format(Val(amountaftdisc), "0.00") & ","
                        .Col = 10
                        .Row = i
                        '  Amount = .Text
                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        .Col = 11
                        .Row = i
                        taxper = Val(.Text)
                        ' DiscAmt = .Text
                        sql(i) = sql(i) & Format(Val(taxper), "0.00") & ","
                        .Col = 12
                        .Row = i
                        VatAmt = Val(.Text)
                        sql(i) = sql(i) & Format(Val(VatAmt), "0.00") & ","
                        .Col = 13
                        .Row = i
                        total = Val(.Text)
                        sql(i) = sql(i) & Format(Val(AxfpSpread1.Text), "0.00") & ","
                        .Col = 14
                        .Row = i
                        othchg = Val(.Text)
                        sql(i) = sql(i) & Format(Val(othchg), "0.00") & ","
                        .Col = 15
                        .Row = i

                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        .Col = 16
                        .Row = i

                        sql(i) = sql(i) & "'" & AxfpSpread1.Text & "',"
                        sql(i) = sql(i) & "'N')"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sql(i)

                    End If
                Next


            End With
            gconnection.MoreTrans(insert)
        End If

    End Sub

    Private Function validateonupdate() As Boolean
        Dim flag As Boolean

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
        Return False
    End Function

    Private Function validateoninsert() As Boolean
        Dim flag As Boolean

        If cbo_warehouse.Text = "" Then

            flag = True
            Return flag
        End If
        If gShortname = "SKYYE" Then
            sqlstring = "SELECT isnull(APPROVE,'')as approve FROM PO_HDR WHERE pono='" & txt_PONo.Text & "' "
            gconnection.getDataSet(sqlstring, "updte")
            Dim APPR As String
            APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
            If APPR = "Y" Then
                MsgBox("This Po is already Approved  You can't update it ")
                flag = True
                Return flag
            End If
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
        sql = "select postatus from PO_hdr where pono='" + txt_PONo.Text + "' and postatus='CLOSED' "
        Dim postatus As String = gconnection.getvalue(sql)
        If (postatus = "CLOSED") Then
            MessageBox.Show("PO IS CLOSED YOU CANT UPDATE", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag
        End If

        'If check_taxcode() = True Then

        '    flag = True
        '    Return flag


        'End If
        Return False
    End Function


    Private Sub bindtaxcode()
        Dim vform As New ListOperattion1

        gSQLString = "select taxgroupcode,taxper from  invtaxgroupmaster  "

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
            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)

        End If

    End Sub

     Private Sub cbo_dept_Validated(sender As Object, e As EventArgs) Handles cbo_dept.Validated
        Dim j As Integer
        If Trim(cbo_dept.Text) <> "" Then
            'sqlstring = "SELECT SLCODE,SLNAME,FREEZEFLAG FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & gCreditors & "' AND SLCODE='" & Trim(Txt_Vcode.Text) & "'"
            sqlstring = "Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "'"
            gconnection.getDataSet(sqlstring, "Invstore_CategoryMaster")


            sqlstring = "SELECT isnull(STORECODE,'') AS STORECODE , ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER "
            If (gdataset.Tables("Invstore_CategoryMaster").Rows.Count > 0) Then
                sqlstring = sqlstring & " where STORECODE = '" & Txt_Storecode.Text & "' and storecode in (Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "' )"

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
        End If
    End Sub

   

    Private Sub Txt_POTerms_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_POTerms.KeyDown
        If Txt_POTerms.Text = "" Then
            Me.Cmd_POTermsHelp_Click(sender, e)
        Else
            Txt_POTerms_Validated(sender, e)
        End If
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
    End Sub

    Private Sub Txt_DeliveryTerms_Validated(sender As Object, e As EventArgs) Handles Txt_DeliveryTerms.Validated
        Dim j As Integer
        If Trim(Txt_DeliveryTerms.Text) <> "" Then
            sqlstring = "SELECT ISNULL(DELIVERYTERMCODE,0) AS DELIVERYTERMCODE,ISNULL(DELIVERYTERMDESC,'') AS DELIVERYTERMDESC FROM PO_DELIVERYTERMS where deliverytermcode = '" & Txt_DeliveryTerms.Text & "' "
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
                    SQL = SQL & " I.itemcode=M.itemcode "
                    If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then

                        SQL = SQL & "  where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "')"

                    Else
                        SQL = SQL & "     where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
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

                            SQL = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom,contractyn FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "' and ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' and isnull(contractyn,0)='1'"
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

                            End If
                            'SQL = "select taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                            'gconnection.getDataSet(SQL, "Itemtaxtagging")
                            'If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                            '    AxfpSpread1.Col = 8
                            '    AxfpSpread1.Row = i
                            '    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                            '    AxfpSpread1.Col = 12
                            '    AxfpSpread1.Row = i
                            '    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("GLACCOUNTIN")
                            'Else
                            '    MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            'End If
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
                    Call UPdateHSNNO(item)
                End If

                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 2 Then
                AxfpSpread1.Col = 2
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemname()
                Else
                    sqlstring = "sELECT * FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "'"
                    gconnection.getDataSet(sqlstring, "Inv_VendorMaster")

                    SQL = " select I.itemcode,M.Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode "
                    If (gdataset.Tables("Inv_VendorMaster").Rows.Count > 0) Then

                        SQL = SQL & "  where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and isnull(m.itemname,'')='" + Trim(AxfpSpread1.Text) + "' AND I.itemcode IN (sELECT ITEMCODE FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "')"

                    Else
                        SQL = SQL & "     where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and isnull(m.itemname,'')='" + Trim(AxfpSpread1.Text) + "'"
                        '  SQL = SQL & "     where M.Category='" + cbo_warehouse.Text + "' and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + Txt_Storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
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
                            SQL = "  sELECT isnull(rate,0) as rate,isnull(uom,'') as uom FROM Invitem_VendorMaster WHERE VENDORCODE='" + Txt_Vcode.Text + "' and ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' and isnull(contractyn,0)='1'"
                            gconnection.getDataSet(SQL, "Invitem_VendorMaster")
                            If (gdataset.Tables("Invitem_VendorMaster").Rows.Count > 0) Then
                                AxfpSpread1.Col = 3
                                AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("uom")
                                AxfpSpread1.Col = 5
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = gdataset.Tables("Invitem_VendorMaster").Rows(0).Item("rate")
                                AxfpSpread1.Lock = True
                            End If
                            'SQL = "select taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                            'gconnection.getDataSet(SQL, "Itemtaxtagging")
                            'If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                            '    AxfpSpread1.Col = 8
                            '    AxfpSpread1.Row = i
                            '    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                            '    AxfpSpread1.Col = 12
                            '    AxfpSpread1.Row = i
                            '    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("GLACCOUNTIN")
                            'Else
                            '    MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            'End If
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        End If

                    Else
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    End If
                End If
                'QTY
            ElseIf AxfpSpread1.ActiveCol = 4 Then
                AxfpSpread1.Col = 4
                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                Else
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
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

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

                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)
                Else
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)

                End If
            ElseIf AxfpSpread1.ActiveCol = 10 Then
                AxfpSpread1.Col = 10

                If Trim(AxfpSpread1.Text) = "" Then
                    bindtaxcode()
                    ' AxfpSpread1.SetActiveCell(1, i + 1)
                Else
                    SQL = "select taxper from invtaxgroupmaster where taxgroupcode='" + AxfpSpread1.Text + "' "
                    Dim taxper As Double = gconnection.getvalue(SQL)

                    AxfpSpread1.Col = 11
                    AxfpSpread1.SetText(11, i, Val(taxper))
                    CALCULATE()
                    'AxfpSpread1.SetActiveCell(1, i + 1)

                End If
            ElseIf AxfpSpread1.ActiveCol = 17 Then
                SQL = " select ISNULL(COMPANYREQ,'NO')  AS COMPANYREQ from INV_InventoryItemMaster where ITEMCODE='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(SQL, "ITEM")
                If (gdataset.Tables("ITEM").Rows.Count > 0) Then
                    If UCase(gdataset.Tables("ITEM").Rows(0).Item("COMPANYREQ")) = "YES" Then
                        AxfpSpread1.Col = 17
                        If Trim(AxfpSpread1.Text) = "" Then
                            Dim vform As New ListOperattion1
                            gSQLString = "select * from InvCompany_ItemMaster   "
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
                AxfpSpread1.SetActiveCell(1, i + 1)
            End If
        ElseIf e.keyCode = Keys.F1 Then
            Txt_Remarks.Focus()
        ElseIf e.keyCode = Keys.F3 Then
            If UCase(gShortname) = "BRC" Then
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                CALCULATE()
            Else
                If Mid(CmdAdd.Text, 1, 1).ToUpper() = "A" Then
                    caloperation()
                    AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                End If
        End If
          
           

        End If

    End Sub

    Private Sub cbo_warehouse_GotFocus(sender As Object, e As EventArgs) Handles cbo_warehouse.GotFocus
        cbo_warehouse.BackColor = Color.Gold
    End Sub



    Private Sub cbo_warehouse_LostFocus(sender As Object, e As EventArgs) Handles cbo_warehouse.LostFocus
        cbo_warehouse.BackColor = Color.White
    End Sub

    Private Sub cbo_warehouse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_warehouse.SelectedIndexChanged

        Try
            'Call FOOTER()
            If CmdAdd.Text = "Add [F7]" Then
                If Mid(UCase(gCompanyname), 1, 6) = "KARNAT" Then
                    doctype = "PUR"
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
        If Mid(CmdAdd.Text, 1, 1) = "U" Then
            If validateoninsert() = False Then
                ' updateoperation()
                addoperation()
                Call UpdateGST("PO", Trim(txt_PONo.Text), Format(CDate(Cbo_PODate.Value), "dd/MMM/yyyy"))
                clearoperation()


            End If


            'ElseIf Mid(CmdAdd.Text, 1, 1) = "U" Then
            '    If validateonupdate() = False Then

            '        updateoperation()
            '        clearoperation()
            '    End If

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

            PoNumber = Trim(Me.txt_PONo.Text)
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            'GetRights()
        End If
    End Sub

    Private Sub VOUCHERNOVALIDATIONS(ByVal VoucherNo As String, ByVal VoucherType As String)
        Dim I, J, K As Integer
        Dim strsql, itemcode, Remarks, po() As String
        Dim e As System.EventArgs
        If Trim(txt_PONo.Text) <> "" Then
            po = Split(txt_PONo.Text, "/")
            If po(1) <> "PO" Then
                sqlstring = " SELECT MAX(Cast(SUBSTRING(versionno,22,(LEN(versionno)-21)) As Numeric))  FROM PO_HDR  WHERE PONO='" + txt_PONo.Text + "' "

            Else
                sqlstring = " SELECT MAX(Cast(SUBSTRING(versionno,22,(LEN(versionno)-21)) As Numeric))  FROM PO_HDR  WHERE PONO='" + txt_PONo.Text + "' "

            End If
            
            If (IsDBNull(gconnection.getvalue(sqlstring)) = False) Then
                If txtversion.Text = "" Then
                    autogenerateversion()
                End If
                'strsql = "SELECT *  FROM PO_HDR WHERE pono='" & Trim(txt_PONo.Text) & "' and versionno='" & txtversion.Text & "' and autoid in (SELECT max(autoid)  FROM PO_HDR WHERE pono='" & Trim(txt_PONo.Text) & "' and versionno='" & txtversion.Text & "'  )"
                strsql = "SELECT ISNULL(TotGSTAmt,0) AS TotGSTAmt,ISNULL(TotSGSTAmt,0) AS TotSGSTAmt,ISNULL(TotCGSTAmt,0) AS TotCGSTAmt,ISNULL(TotIGSTAmt,0) AS TotIGSTAmt,*  FROM PO_HDR WHERE pono='" & Trim(txt_PONo.Text) & "' and autoid in (SELECT max(autoid)  FROM PO_HDR WHERE pono='" & Trim(txt_PONo.Text) & "'  )"
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
                    cbo_warehouse.SelectedIndex = index

                    cbo_warehouse.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("doctype"))
                    txt_PONo.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PONO"))

                    ' cbo_warehouse.FindString()
                    ' TXT_ADVANCEPERC.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POADVPERC"))
                    txt_MOD.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODESPMODE"))
                    TXT_DOCTHROUGH.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODOCSTHROUGH"))
                    txt_SalesTax.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POSALET"))
                    Cbo_PODate.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODATE"))
                    dtpvalidfrom.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("povalidfrom"))
                    CBO_QUOT_DATE.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("poquotdate"))

                    dtpvalidto.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("povalidupto"))

                    cbo_dept.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("PODepartment"))
                    'txt_docno.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("auth_docno"))
                    Txt_QuotNo.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POquotno"))
                    Txt_Vcode.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("povendorcode"))
                    Txt_Storecode.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("storecode"))
                    CmbPoType.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("potype"))
                    strsql = "SELECT ISNULL(VENDORCODE,0) AS VENDORCODE, ISNULL(VENDORNAME,'') AS VENDORNAME FROM PO_VIEW_VENDORMASTER WHERE VENDORCODE = '" & Trim(Txt_Vcode.Text) & "' "
                    'strsql = "SELECT slname FROM accountssubledgermaster WHERE slcode='" & Trim(Txt_Vcode.Text) & "'"
                    gconnection.getDataSet(strsql, "accountssubledgermaster")
                    Txt_Vname.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("vendorname"))

                    Cbo_Approvedby.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POapprovedby"))


                    Cbo_POStatus.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POstatus"))
                    'Txt_ED.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POed"))
                    'Txt_CST.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POcst"))
                    'Txt_MODVat.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POmodvat"))
                    'Txt_PTax.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POptax"))
                    'Txt_Octra.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POoctra"))
                    'Txt_Insurance.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POinsurance"))
                    'Txt_LST.Text = Trim(gdataset.Tables("PO_HDR").Rows(0).Item("POlst"))
                    Txt_POValue.Text = Trim(Format(gdataset.Tables("PO_HDR").Rows(0).Item("POvalue"), "0.00"))
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
                        '  Me.CmdFreeze.Enabled = True

                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.CmdFreeze.Text = "Freeze[F8]"
                        Me.CmdAdd.Enabled = True
                        Me.CmdFreeze.Enabled = True

                    End If
                    'strsql = "SELECT * FROM PO_ITEMDETAILS WHERE pono='" & Trim(txt_PONo.Text) & "' and versionno='" + txtversion.Text + "' ORDER BY AUTOID "
                    strsql = "SELECT ISNULL(SPLCESS,0) AS SPLCESS,* FROM PO_ITEMDETAILS WHERE pono='" & Trim(txt_PONo.Text) & "'  ORDER BY AUTOID "
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
                                .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("baseamount"), "0.00"))

                                .Col = 7
                                .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("discper"), "0.000"))


                                .Col = 8
                                .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("DiscAmt"), "0.00"))
                                .Col = 9
                                .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("amountafterdiscount"), "0.00"))
                                .Col = 10
                                .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("taxcode")

                                .Col = 11
                                .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("taxper"), "0.00"))

                                .Col = 12
                                .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("VatAmt"), "0.00"))
                                .Col = 13
                                .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("totalamount"), "0.00"))
                                .Col = 14
                                .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("othchg"), "0.00"))
                                .Col = 15
                                .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("raterange")
                                .Col = 16
                                .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("qtyrange")
                                .Col = 17
                                .Text = gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("companycode")
                                .Col = 18
                                .Text = Trim(Format(gdataset.Tables("PO_ITEMDETAILS").Rows(I).Item("SPLCESS"), "0.00"))
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
                sqlstring = "SELECT GRNDETAILS FROM GRN_header WHERE PONO='" + txt_PONo.Text + "' and versionno='" & txtversion.Text & "'"
                gconnection.getDataSet(sqlstring, "GRN_DETAILS")
                If (gdataset.Tables("GRN_DETAILS").Rows.Count > 0) Then
                    Label7.Text = "Ref no."
                    For m As Integer = 0 To gdataset.Tables("GRN_DETAILS").Rows.Count - 1
                        Label7.Text += gdataset.Tables("GRN_DETAILS").Rows(m).Item("GRNDETAILS")

                    Next
                Else
                    Label7.Text = ""
                End If
            End If
        End If
    End Sub



    Private Sub CmdView_Click(sender As Object, e As EventArgs) Handles CmdView.Click
        gPrint = False
        Try
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL As String
            Dim r As New Rpt_POBill
            sqlstring = " SELECT * FROM  VW_PO_POBILL "
            sqlstring = sqlstring & " WHERE PONO BETWEEN '" & Trim(txt_PONo.Text) & "' AND '" & Trim(txt_PONo.Text) & "'"
            sqlstring = sqlstring & " ORDER BY PONO,PODATE"

            gconnection.getDataSet(sqlstring, "VW_PO_POBILL")
            If gdataset.Tables("VW_PO_POBILL").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_PO_POBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName

                Dim textobj3 As TextObject
                textobj3 = r.ReportDefinition.ReportObjects("Text5")
                textobj3.Text = Address1 & " , " & Address2 & " , " & gCity & " - " & gPincode

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text30")
                textobj2.Text = gUsername
                Dim t1 As TextObject
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

    End Sub

    Private Sub Txt_Storecode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Storecode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Txt_Storecode.Text = "" Then
                Call cmd_DeptHelp_Click(cbo_dept, e)
            Else
                Call cbo_dept_Validated(cbo_dept, e)
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

    Private Sub Frm_PurchaseOrder_amendment_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call CmdClear_Click(CmdClear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 And CmdFreeze.Visible = True Then
                Call CmdFreeze_Click(CmdFreeze, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 And CmdAdd.Visible = True Then
                Call CmdAdd_Click(CmdAdd, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 And CmdView.Visible = True Then
                Call CmdView_Click(CmdView, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 And CmdPrint.Enabled = True Then
                Call cmd_print_Click(sender, e)
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
    '     ByVal e As System.EventArgs) Handles Me.Resize

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
    Private Sub Frm_PurchaseOrder_amendment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.CmdClear.Visible = True
                Me.CmdExit.Visible = True
            End If
        End If
        Me.DoubleBuffered = True
        If gValidity = False Then
            Me.CmdAdd.Enabled = False
            Me.cmd_auth.Enabled = False
            Me.CmdFreeze.Enabled = False
        End If
        'ssgrid.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width * 17.57) / 100, (Screen.PrimaryScreen.WorkingArea.Height * 35.57) / 100)
        'Resize_Form()

        GroupBox4.Controls.Add(AxfpSpread1)
        AxfpSpread1.Location = New Point(3, 8)
        AxfpSpread1.Height = GroupBox4.Height - 30
        Show()

        Me.Cbo_Approvedby.SelectedIndex = 0
        Me.Cbo_POStatus.SelectedIndex = 0
        'Me.AmendmentGrid.Visible = False
        'Me.FollowupGrid.Visible = False
        Timer1.Enabled = True
        Timer1.Start()
        'Call FillStore()
        'Call FOOTER()
        FillGRNTYPE()
        Call categoryfill()
        Me.txt_PONo.Focus()
        '    Me.grp_footer.Visible = False
        'Me.cbo_warehouse.SelectedIndex = 0
        Call autogenerate()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If

    End Sub


    Private Sub txtversion_Validated(sender As Object, e As EventArgs) Handles txtversion.Validated

    End Sub

 

    Private Sub cmd_view_Click(sender As Object, e As EventArgs) Handles cmd_view.Click
        gPrint = False

        Dim TaType = TaxType("PO", Trim(txt_PONo.Text), Format(CDate(Cbo_PODate.Value), "dd/MMM/yyyy"))

        If TaType = "GST" Or TaType = "IGST" Then
            If Mid(UCase(Trim(gShortname)), 1, 3) <> "SAT" Then
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

                        sql = "select  Adduser,povalue from po_hdr WHERE pono='" + txt_PONo.Text + "'  "

                        gconnection.getDataSet(sql, "po_hdr")
                        If gdataset.Tables("po_hdr").Rows.Count > 0 Then
                            Dim Text37 As TextObject
                            Text37 = r.ReportDefinition.ReportObjects("Text37")
                            Text37.Text = "Prepared By " & Trim(gdataset.Tables("po_hdr").Rows(0).Item("Adduser"))

                            sql = "select [dbo].NumberToWords (" & Val(gdataset.Tables("po_hdr").Rows(0).Item("povalue")) & ") as aMount"
                            gconnection.getDataSet(sql, "NumberToWords")
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

                        sql = "select  Adduser,povalue from po_hdr WHERE pono='" + txt_PONo.Text + "'  "

                        gconnection.getDataSet(sql, "po_hdr")
                        If gdataset.Tables("po_hdr").Rows.Count > 0 Then
                            Dim Text37 As TextObject
                            Text37 = r.ReportDefinition.ReportObjects("Text37")
                            Text37.Text = "Prepared By " & Trim(gdataset.Tables("po_hdr").Rows(0).Item("Adduser"))

                            sql = "select [dbo].NumberToWords (" & Val(gdataset.Tables("po_hdr").Rows(0).Item("povalue")) & ") as aMount"
                            gconnection.getDataSet(sql, "NumberToWords")
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

            End If
        End If


    End Sub

    Private Sub cmd_print_Click(sender As Object, e As EventArgs) Handles cmd_print.Click
        gPrint = False


        If GSTSTARTdATE <= Cbo_PODate.Value Then
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

                        sql = "select  Adduser,povalue from po_hdr WHERE pono='" + txt_PONo.Text + "'  "

                        gconnection.getDataSet(sql, "po_hdr")
                        If gdataset.Tables("po_hdr").Rows.Count > 0 Then
                            Dim Text37 As TextObject
                            Text37 = r.ReportDefinition.ReportObjects("Text37")
                            Text37.Text = "Prepared By " & Trim(gdataset.Tables("po_hdr").Rows(0).Item("Adduser"))

                            sql = "select [dbo].NumberToWords (" & Val(gdataset.Tables("po_hdr").Rows(0).Item("povalue")) & ") as aMount"
                            gconnection.getDataSet(sql, "NumberToWords")
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

            End If
        Else
            If Mid(UCase(Trim(gShortname)), 1, 3) <> "SAT" Then
                Try
                    Dim rViewer As New Viewer
                    Dim sqlstring, SSQL, addr As String
                    Dim r As New CryPO
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

                        sql = "select  Adduser,povalue from po_hdr WHERE pono='" + txt_PONo.Text + "'  "

                        gconnection.getDataSet(sql, "po_hdr")
                        If gdataset.Tables("po_hdr").Rows.Count > 0 Then
                            Dim Text37 As TextObject
                            Text37 = r.ReportDefinition.ReportObjects("Text37")
                            Text37.Text = "Prepared By " & Trim(gdataset.Tables("po_hdr").Rows(0).Item("Adduser"))

                            sql = "select [dbo].NumberToWords (" & Val(gdataset.Tables("po_hdr").Rows(0).Item("povalue")) & ") as aMount"
                            gconnection.getDataSet(sql, "NumberToWords")
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

            End If
        End If


    End Sub

  
   
    Private Sub cmd_DeptHelp_Click(sender As Object, e As EventArgs) Handles cmd_DeptHelp.Click
        sqlstring = "Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "'"
        gconnection.getDataSet(sqlstring, "Invstore_CategoryMaster")


        gSQLString = "SELECT isnull(STORECODE,'') AS STORECODE , ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER "
        If (gdataset.Tables("Invstore_categorymaster").Rows.Count > 0) Then
            M_WhereCondition = " WHERE STORESTATUS = 'M' and storecode in ( Select storecode from  Invstore_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "' )"
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
        'gSQLString = "SELECT ISNULL(SLCODE,0) AS SLCODE, ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER "
        sqlstring = " select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "'"
        gconnection.getDataSet(sqlstring, "Invvendor_CategoryMaster")

        gSQLString = "SELECT distinct ISNULL(VENDORCODE,'') AS VENDORCODE, ISNULL(VENDORNAME,'') AS VENDORNAME FROM PO_VIEW_VENDORMASTER "
        If gdataset.Tables("Invvendor_CategoryMaster").Rows.Count > 0 Then
            M_WhereCondition = " where vendorcode in ( select ISNULL(VENDORCODE,'') AS VENDORCODE from Invvendor_CategoryMaster where categorycode='" + Trim(cbo_warehouse.Text) + "' )"
        Else
            M_WhereCondition = " "
        End If
        vform.Field = " VENDORNAME,VENDORCODE "
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



        gSQLString = "SELECT DISTINCT(ISNULL(pono,'')) AS PONO,ISNULL(podate,'') AS PODATE,ISNULL(podepartment,'') AS PODEPARTMENT FROM PO_HDR"
        If cbo_dept.Text <> "" Then
            M_WhereCondition = " where postatus IN ('RELEASED','CLOSED') AND PODEPARTMENT='" + cbo_dept.Text + "' and storecode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "')  "
        Else
            M_WhereCondition = " where postatus IN ('RELEASED','CLOSED')  and storecode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "') "
        End If

        M_ORDERBY = "pono DESC ,podate desc"

        vform.Field = "PONO,PODEPARTMENT"
        vform.vFormatstring = "         PONO                      |     PODATE                    |   PODEPARTMENT                   "
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

  
    Private Sub cmd_version_Click(sender As Object, e As EventArgs) Handles cmd_version.Click
        gSQLString = "SELECT ISNULL(versionno,'') AS versionno,ISNULL(podate,'') AS PODATE,ISNULL(postatus,'') AS postatus FROM PO_HDR"
        M_WhereCondition = " where pono='" + txt_PONo.Text + "' and isnull(freeze,'')<>'Y'"
        Dim vform As New ListOperattion1
        vform.Field = "PONO,VERSIONNO,POSTATUS"
        vform.vFormatstring = "         VERSIONNO                |     PONO                  |           POSTATUS          "
        vform.vCaption = "PURCHASE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txtversion.Text = Trim(vform.keyfield & "")
            Call txt_PONo_Validated(txt_PONo.Text, e)
        End If
        vform.Close()
        vform = Nothing
        'txt_PONo.Focus()
        CmdFreeze.Enabled = True

    End Sub

  
    Private Sub Cmd_POTermsHelp_Click(sender As Object, e As EventArgs) Handles Cmd_POTermsHelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(PAYMENTTERMCODE,0) AS PAYMENTTERMCODE,ISNULL(PAYMENTTERMDESC,'') AS PAYMENTTERMDESC FROM PO_PAYMENTTERMS "
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

  
    Private Sub Cmd_DeliveryTermHelp_Click(sender As Object, e As EventArgs) Handles Cmd_DeliveryTermHelp.Click
        Dim sqlstring As String
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(DELIVERYTERMCODE,0) AS DELIVERYTERMCODE,ISNULL(DELIVERYTERMDESC,'') AS DELIVERYTERMDESC FROM PO_DELIVERYTERMS "
        M_WhereCondition = ""
        vform.Field = " DELIVERYTERMCODE, DELIVERYTERMDESC "
        vform.vFormatstring = "     DELIVERYTERM CODE     |                   DELIVERYTERMDESC        "
        vform.vCaption = "DELIVERYTERM MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_DeliveryTerms.Text = Trim(vform.keyfield & "")
            TXT_DELIVTERMS_DESC.Text = Trim(vform.keyfield1 & "")
            Call Txt_DeliveryTerms_Validated(Txt_DeliveryTerms, e)
        End If
        vform.Close()
        vform = Nothing
        Me.txt_SalesTax.Focus()

    End Sub

    Private Sub txt_PONo_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_PONo.KeyDown
        If txt_PONo.Text <> "" Then
            txt_PONo_Validated(txt_PONo.Text, e)
        Else
            Call Cmd_PONoHelp_Click(txt_PONo.Text, e)
        End If

    End Sub

    Private Sub Frm_PurchaseOrder_amendment_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub
End Class