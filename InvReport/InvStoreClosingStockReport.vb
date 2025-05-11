Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine


Public Class InvStoreClosingStockReport
    Dim gconnection As New GlobalClass
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


    Private Sub FillGroupdetails()
        Dim i As Integer
        Dim sqlstring As String
        CheckedListBox2.Items.Clear()
        sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER  where CATEGORYCODE in (select CATEGORYCODE from INV_INVENTORYITEMMASTER) ORDER BY CATEGORYCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    CheckedListBox2.Items.Add(Trim(CStr(.Item("CATEGORYCODE"))))
                End With
            Next
        End If
    End Sub

    Private Sub FillStore()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT ISNULL(STOREcode,'') + '- '+ ISNULL(STOREdesc,'') AS STOREdesc FROM STOREMASTER WHERE  isnull(freeze,'') <> 'Y' ORDER BY STOREdesc ASC"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        CheckedListBox1.Items.Clear()
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                CheckedListBox1.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STOREdesc"))
            Next i
        End If
    End Sub

    Private Sub InvDamageReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub InvDamageReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' FillStore()
        FillGroupdetails()
        ' dtpfromdate.Value = Format(CDate("01/apr/" & gFinancalyearStart), "dd/MMM/yyyy")
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
        GmoduleName = "Stock Damage Details"
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
        ChkSupplier.Checked = False
        ChkCategory.Checked = False

    End Sub
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()

    End Sub

    Private Sub VIEWDAMAGEREGISTERCryLIQ()


        Try
            Dim sqlstring, ITEMcode(), STORECODE(), store, cat As String
            Dim i As Integer
            Dim r As New StoreWiseClosingStock4LIQ
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor

            If CheckedListBox2.CheckedItems.Count <> 0 Then
                cat = "("
                For i = 0 To CheckedListBox2.CheckedItems.Count - 1
                    cat = cat & " '" & Trim(CheckedListBox2.CheckedItems(i)) & "', "
                Next
                cat = Mid(cat, 1, Len(cat) - 2)
                cat = cat & ")"
            Else
                MessageBox.Show("Select the Category Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

         

            If CheckedListBox1.CheckedItems.Count <> 0 Then
                store = "("
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    STORECODE = Split(CheckedListBox1.Items(i), "-")
                    store = store & " '" & Trim(STORECODE(0)) & "', "
                Next
                store = Mid(store, 1, Len(store) - 2)
                store = store & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            sqlstring = " create table StoreStock  "
            If CheckedListBox1.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " ( ITEMCODE varchar(20),ITEMNAME varchar(100) ,UOM varchar(10),Groupcode varchar(10),Groupdesc varchar(50),"
                For i = 0 To CheckedListBox1.Items.Count - 1
                    STORECODE = Split(CheckedListBox1.Items(i), "-")
                    sqlstring = sqlstring & " " & Trim(STORECODE(0)) & " numeric(18, 2), "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ",TOTALQTY  numeric(18, 2),CLOSINGRATE  numeric(18, 2),CLOSINGVALUE  numeric(18, 2))"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = " insert into storestock (itemcode)  select distinct itemcode  from closingqty where storecode in " & store & " "
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set itemname=i.itemname,uom=i.stockuom,Groupcode=i.Groupcode from storestock s inner join INV_InventoryItemMaster i on s.itemcode=i.itemcode"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set Groupdesc=i.Groupdesc from storestock s inner join InventoryGroupMaster i on s.Groupcode=i.Groupcode"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = "update storestock set " & Trim(STORECODE(0)) & "= (select top 1 closingstock from closingqty i where storestock.itemcode=i.itemcode and i.Trndate<'" & Format(dtptodate.Value, "yyyy-MM-dd") & "' AND   storecode='" & Trim(STORECODE(0)) & "' order by TRNS_SEQ desc)"
                gconnection.dataOperation(6, sqlstring, "StoreStock")


                sqlstring = " update storestock set " & Trim(STORECODE(0)) & "= case when " & Trim(STORECODE(0)) & ">0  then cast(" & Trim(STORECODE(0)) & " as Int)+(((ABS(" & Trim(STORECODE(0)) & ")-cast(" & Trim(STORECODE(0)) & " as Int))*t.CONVVALUE)/100) else CAST(" & Trim(STORECODE(0)) & " AS INT)-(((ABS(" & Trim(STORECODE(0)) & "))+CAST(" & Trim(STORECODE(0)) & " AS INT))*t.CONVVALUE)/100 end "
                sqlstring = sqlstring & " from storestock s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM "
                gconnection.dataOperation(6, sqlstring, "StoreStock")

                sqlstring = "update storestock set " & Trim(STORECODE(0)) & "=0 WHERE " & Trim(STORECODE(0)) & " IS NULL"
                gconnection.dataOperation(6, sqlstring, "StoreStock")
            Next


            sqlstring = " update storestock set TOTALQTY="
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = sqlstring & " CAST(" & Trim(STORECODE(0)) & " AS decimal(18,3)) + "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ""
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = " update storestock set TOTALQTY= case when TOTALQTY>0  then cast(TOTALQTY as Int)+(((ABS(TOTALQTY)-cast(TOTALQTY as Int))*t.CONVVALUE)/100) else CAST(TOTALQTY AS INT)-(((ABS(TOTALQTY))+CAST(TOTALQTY AS INT))*t.CONVVALUE)/100 end "
            sqlstring = sqlstring & " from storestock s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM "
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGRATE= (select top 1 rate from closingqty i where storestock.itemcode=i.itemcode  and i.Trndate<'" & Format(dtptodate.Value, "yyyy-MM-dd") & "' order by TRNS_SEQ desc)"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGRATE=0 WHERE CLOSINGRATE IS NULL"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGVALUE= TOTALQTY*CLOSINGRATE "
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGVALUE=0 WHERE CLOSINGVALUE IS NULL"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            '  sqlstring = " delete from storestock where TOTALQTY=0  "
            ' gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "SELECT * FROM storestock where  groupcode in ( select distinct Groupcode from INV_InventoryItemMaster where category in " & cat & " ) order by itemcode"
            gconnection.getDataSet(sqlstring, "storestock")
            If gdataset.Tables("storestock").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "storestock"
                'Dim picture1 As PictureObject
                'picture1 = r.ReportDefinition.ReportObjects("picture1")
                'If (gShortname = "KOLKATA") Then
                '    picture1.ObjectFormat.EnableSuppress = False
                'Else
                '    picture1.ObjectFormat.EnableSuppress = True

                'End If
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text26")
                textobj1.Text = MyCompanyName

                Dim textobj5 As TextObject
                textobj5 = r.ReportDefinition.ReportObjects("Text25")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text27")
                textobj6.Text = UCase(Address2)

                Dim textobj22 As TextObject
                textobj22 = r.ReportDefinition.ReportObjects("Text32")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                'Dim TXTOBJ3 As TextObject
                'TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")

                Dim textobj29 As TextObject
                textobj29 = r.ReportDefinition.ReportObjects("Text33")
                textobj29.Text = Format(dtptodate.Value, "dd/MM/yyyy")


                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If
            Me.Cursor = Cursors.Default



        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub VIEWDAMAGEREGISTERCry()


        Try
            Dim sqlstring, ITEMcode(), STORECODE(), store, cat As String
            Dim i As Integer
            Dim r As New StoreWiseClosingStock
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor
            sqlstring = " drop table StoreStock  "
            gconnection.dataOperation(6, sqlstring, "StoreStock")



            If CheckedListBox2.CheckedItems.Count <> 0 Then
                cat = "("
                For i = 0 To CheckedListBox2.CheckedItems.Count - 1
                    cat = cat & " '" & Trim(CheckedListBox2.CheckedItems(i)) & "', "
                Next
                cat = Mid(cat, 1, Len(cat) - 2)
                cat = cat & ")"
            Else
                MessageBox.Show("Select the Category Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If cat = "( 'LIQ')" Then

                VIEWDAMAGEREGISTERCryLIQ()
                Exit Sub
            End If

            If CheckedListBox1.CheckedItems.Count <> 0 Then
                store = "("
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    STORECODE = Split(CheckedListBox1.Items(i), "-")
                    store = store & " '" & Trim(STORECODE(0)) & "', "
                Next
                store = Mid(store, 1, Len(store) - 2)
                store = store & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            sqlstring = " create table StoreStock  "
            If CheckedListBox1.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " ( ITEMCODE varchar(20),ITEMNAME varchar(100) ,UOM varchar(10),Groupcode varchar(10),Groupdesc varchar(50),"
                For i = 0 To CheckedListBox1.Items.Count - 1
                    STORECODE = Split(CheckedListBox1.Items(i), "-")
                    sqlstring = sqlstring & " " & Trim(STORECODE(0)) & " varchar(100), "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ",TOTALQTY  numeric(18, 3),CLOSINGRATE  numeric(18, 3),CLOSINGVALUE  numeric(18, 3))"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = " insert into storestock (itemcode)  select distinct itemcode  from closingqty where storecode in " & store & " "
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set itemname=i.itemname,uom=i.stockuom,Groupcode=i.Groupcode from storestock s inner join INV_InventoryItemMaster i on s.itemcode=i.itemcode"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set Groupdesc=i.Groupdesc from storestock s inner join InventoryGroupMaster i on s.Groupcode=i.Groupcode"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = "update storestock set " & Trim(STORECODE(0)) & "= (select top 1 closingstock from closingqty i where storestock.itemcode=i.itemcode and i.Trndate<'" & Format(dtptodate.Value, "yyyy-MM-dd") & "' AND   storecode='" & Trim(STORECODE(0)) & "' order by TRNS_SEQ desc)"
                gconnection.dataOperation(6, sqlstring, "StoreStock")

                sqlstring = " update storestock set " & Trim(STORECODE(0)) & "= case when " & Trim(STORECODE(0)) & ">0  then cast(" & Trim(STORECODE(0)) & " as Int)+(((ABS(" & Trim(STORECODE(0)) & ")-cast(" & Trim(STORECODE(0)) & " as Int))*t.CONVVALUE)/100) else CAST(" & Trim(STORECODE(0)) & " AS INT)-(((ABS(" & Trim(STORECODE(0)) & "))+CAST(" & Trim(STORECODE(0)) & " AS INT))*t.CONVVALUE)/100 end "
                sqlstring = sqlstring & " from storestock s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM "
                gconnection.dataOperation(6, sqlstring, "StoreStock")

                sqlstring = "update storestock set " & Trim(STORECODE(0)) & "=0 WHERE " & Trim(STORECODE(0)) & " IS NULL"
                gconnection.dataOperation(6, sqlstring, "StoreStock")
            Next

            sqlstring = " update storestock set TOTALQTY="
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = sqlstring & " CAST(" & Trim(STORECODE(0)) & " AS decimal(18,3)) + "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ""
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = " update storestock set TOTALQTY= case when TOTALQTY>0  then cast(TOTALQTY as Int)+(((ABS(TOTALQTY)-cast(TOTALQTY as Int))*t.CONVVALUE)/100) else CAST(TOTALQTY AS INT)-(((ABS(TOTALQTY))+CAST(TOTALQTY AS INT))*t.CONVVALUE)/100 end "
            sqlstring = sqlstring & " from storestock s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM "
            gconnection.dataOperation(6, sqlstring, "StoreStock")


            sqlstring = "update storestock set CLOSINGRATE= (select top 1 rate from closingqty i where storestock.itemcode=i.itemcode  and i.Trndate<'" & Format(dtptodate.Value, "yyyy-MM-dd") & "' order by TRNS_SEQ desc)"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGRATE=0 WHERE CLOSINGRATE IS NULL"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGVALUE= TOTALQTY*CLOSINGRATE "
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGVALUE=0 WHERE CLOSINGVALUE IS NULL"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            '  sqlstring = " delete from storestock where TOTALQTY=0  "
            ' gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "SELECT * FROM storestock where  groupcode in ( select distinct Groupcode from INV_InventoryItemMaster where category in " & cat & " ) order by itemcode"
            gconnection.getDataSet(sqlstring, "storestock")
            If gdataset.Tables("storestock").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "storestock"
                'Dim picture1 As PictureObject
                'picture1 = r.ReportDefinition.ReportObjects("picture1")
                'If (gShortname = "KOLKATA") Then
                '    picture1.ObjectFormat.EnableSuppress = False
                'Else
                '    picture1.ObjectFormat.EnableSuppress = True

                'End If
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text26")
                textobj1.Text = MyCompanyName

                Dim textobj5 As TextObject
                textobj5 = r.ReportDefinition.ReportObjects("Text25")
                textobj5.Text = UCase(Address1)
                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text27")
                textobj6.Text = UCase(Address2)

                Dim textobj22 As TextObject
                textobj22 = r.ReportDefinition.ReportObjects("Text32")
                textobj22.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                'Dim TXTOBJ3 As TextObject
                'TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")

                Dim textobj29 As TextObject
                textobj29 = r.ReportDefinition.ReportObjects("Text33")
                textobj29.Text = Format(dtptodate.Value, "dd/MM/yyyy")


                rViewer.Show()
                Me.Cursor = Cursors.Default

            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If
            Me.Cursor = Cursors.Default



        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MMM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub

        If chbCry.Checked = True Then
            VIEWDAMAGEREGISTERCry()
        Else
            VIEWDAMAGEREGISTER()
        End If



    End Sub

    Private Sub VIEWDAMAGEREGISTER()


        Try
            Dim sqlstring, ITEMcode(), STORECODE(), cat, store As String
            Dim i As Integer
            Dim r As New Crydmgreport
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor
            sqlstring = " drop table StoreStock  "
            gconnection.dataOperation(6, sqlstring, "StoreStock")



            If CheckedListBox2.CheckedItems.Count <> 0 Then
                cat = "("
                For i = 0 To CheckedListBox2.CheckedItems.Count - 1
                    ' ITEMNAME = Split(CheckedListBox3.CheckedItems(i), "-->")
                    cat = cat & " '" & Trim(CheckedListBox2.CheckedItems(i)) & "', "
                Next
                cat = Mid(cat, 1, Len(cat) - 2)
                cat = cat & ")"
            Else
                MessageBox.Show("Select the Category Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If CheckedListBox1.CheckedItems.Count <> 0 Then
                store = "("
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    STORECODE = Split(CheckedListBox1.Items(i), "-")
                    store = store & " '" & Trim(STORECODE(0)) & "', "
                Next
                store = Mid(store, 1, Len(store) - 2)
                store = store & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            sqlstring = " create table StoreStock  "
            If CheckedListBox1.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " ( ITEMCODE varchar(20),ITEMNAME varchar(100) ,UOM varchar(10),Groupcode varchar(10),Groupdesc varchar(50),"
                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                    STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                    sqlstring = sqlstring & " " & Trim(STORECODE(0)) & " numeric(18, 2), "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ",TOTALQTY  numeric(18, 2),CLOSINGRATE  numeric(18, 2),CLOSINGVALUE  numeric(18, 3))"
            Else
                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = " insert into storestock (itemcode)  select distinct itemcode  from closingqty "
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set itemname=i.itemname,uom=i.stockuom,Groupcode=i.Groupcode from storestock s inner join INV_InventoryItemMaster i on s.itemcode=i.itemcode"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set Groupdesc=i.Groupdesc from storestock s inner join InventoryGroupMaster i on s.Groupcode=i.Groupcode"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = "update storestock set " & Trim(STORECODE(0)) & "= (select top 1 closingstock from closingqty i where storestock.itemcode=i.itemcode and i.Trndate<'" & Format(dtptodate.Value, "yyyy-MM-dd") & "' AND   storecode='" & Trim(STORECODE(0)) & "' order by TRNS_SEQ desc)"
                gconnection.dataOperation(6, sqlstring, "StoreStock")

                sqlstring = " update storestock set " & Trim(STORECODE(0)) & "= case when " & Trim(STORECODE(0)) & ">0  then cast(" & Trim(STORECODE(0)) & " as Int)+(((ABS(" & Trim(STORECODE(0)) & ")-cast(" & Trim(STORECODE(0)) & " as Int))*t.CONVVALUE)/100) else CAST(" & Trim(STORECODE(0)) & " AS INT)-(((ABS(" & Trim(STORECODE(0)) & "))+CAST(" & Trim(STORECODE(0)) & " AS INT))*t.CONVVALUE)/100 end "
                sqlstring = sqlstring & " from storestock s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM "
                gconnection.dataOperation(6, sqlstring, "StoreStock")

                sqlstring = "update storestock set " & Trim(STORECODE(0)) & "=0 WHERE " & Trim(STORECODE(0)) & " IS NULL"
                gconnection.dataOperation(6, sqlstring, "StoreStock")


            Next

            sqlstring = " update storestock set TOTALQTY="
            For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                STORECODE = Split(CheckedListBox1.CheckedItems(i), "-")
                sqlstring = sqlstring & " CAST(" & Trim(STORECODE(0)) & " AS decimal(18,3)) + "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ""
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = " update storestock set TOTALQTY= case when TOTALQTY>0  then cast(TOTALQTY as Int)+(((ABS(TOTALQTY)-cast(TOTALQTY as Int))*t.CONVVALUE)/100) else CAST(TOTALQTY AS INT)-(((ABS(TOTALQTY))+CAST(TOTALQTY AS INT))*t.CONVVALUE)/100 end "
            sqlstring = sqlstring & " from storestock s inner join inv_Inventoryuomstorelink u on s.Itemcode=u.itemcode and  s.Uom<>u.reportdecimaluom and s.Itemcode=u.itemcode inner join INVENTORY_TRANSCONVERSION  t on s.Uom=t.BASEUOM and u.reportdecimaluom=TRANSUOM "
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGRATE= (select top 1 closingvalue/closingstock from closingqty i where storestock.itemcode=i.itemcode AND closingstock<>0 and i.Trndate<'" & Format(dtptodate.Value, "yyyy-MM-dd") & "' order by TRNS_SEQ desc)"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGRATE=0 WHERE CLOSINGRATE IS NULL"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGVALUE= TOTALQTY*CLOSINGRATE "
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "update storestock set CLOSINGVALUE=0 WHERE CLOSINGVALUE IS NULL"
            gconnection.dataOperation(6, sqlstring, "StoreStock")

            'sqlstring = " delete from storestock where TOTALQTY=0  "
            'gconnection.dataOperation(6, sqlstring, "StoreStock")

            sqlstring = "SELECT * FROM storestock where  groupcode in ( select distinct Groupcode from INV_InventoryItemMaster where category in " & cat & " ) order by itemcode"
            '  gconnection.getDataSet(sqlstring, "storestock")

            Dim exp As New exportexcel
            exp.Show()
            Call exp.export(sqlstring, "STORE CLOSING STOCK " & Format(dtpfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtptodate.Value, "dd-MMM-yyyy"), "")

            Me.Cursor = Cursors.Default
      

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Me.Cursor = Cursors.Default


    End Sub





    Private Sub ChkSupplier_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSupplier.CheckedChanged
        Dim i As Integer = 0
        If (ChkSupplier.Checked = True) Then
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, False)
            Next

        End If


    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub ButExport_Click(sender As Object, e As EventArgs) Handles ButExport.Click

       VIEWDAMAGEREGISTER()

    End Sub

    Private Sub CheckedListBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox1.KeyDown
        If e.KeyCode = Keys.F3 Then
            Dim Advsearch As New frmListSearch
            Advsearch.listbox = CheckedListBox1
            Advsearch.Text = "Store Code Search"
            Advsearch.ShowDialog(Me)
        End If
    End Sub

    Private Sub CheckedListBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckedListBox2.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim search As New frmListSearch
            search.listbox = CheckedListBox2
            search.Text = "Category Search"
            search.ShowDialog(Me)
        End If
    End Sub

    Private Sub CheckedListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox2.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql As String


        sqlstring = "SELECT DISTINCT ISNULL(STOREcode,'') + '- '+ ISNULL(STOREdesc,'') AS STOREdesc FROM STOREMASTER "
        sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' "
        sqlstring = sqlstring & "and storecode  IN ( select Storecode from Invstore_CategoryMaster where categorycode in ("

        For J = 0 To CheckedListBox2.CheckedItems.Count - 1
            If J = CheckedListBox2.CheckedItems.Count - 1 Then
                sqlstring = sqlstring & " '" & CheckedListBox2.CheckedItems(J) & "' "
            Else
                sqlstring = sqlstring & " '" & CheckedListBox2.CheckedItems(J) & "', "
            End If
        Next

        If CheckedListBox2.CheckedItems.Count > 0 Then

            sqlstring = sqlstring & "))"

            gconnection.getDataSet(sqlstring, "STOREMASTER")
            CheckedListBox1.Items.Clear()
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                    CheckedListBox1.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STOREdesc"))
                Next i
            End If
        Else
            CheckedListBox1.Items.Clear()
        End If
        


        'sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM Invstore_CategoryMaster AS I "
        'sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' and I.CATEGORY IN ("

        'For J = 0 To CheckedListBox2.CheckedItems.Count - 1
        '    If J = CheckedListBox2.CheckedItems.Count - 1 Then
        '        ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "' "
        '    Else
        '        ssql = ssql & " '" & CheckedListBox2.CheckedItems(J) & "', "
        '    End If
        'Next
        'If CheckedListBox2.CheckedItems.Count > 0 Then
        '    sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
        '    gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
        '    If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
        '        CheckedListBox1.Items.Clear()
        '        For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
        '            With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
        '                CheckedListBox1.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
        '            End With
        '        Next i
        '    End If
        'Else
        '    CheckedListBox1.Items.Clear()

        'End If
    End Sub

    Private Sub ChkCategory_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCategory.CheckedChanged
        Dim i As Integer = 0

        If (ChkCategory.Checked = True) Then
            For i = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, True)
            Next

        Else
            For i = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, False)
            Next

        End If
        CheckedListBox2_SelectedIndexChanged(sender, e)
    End Sub
End Class