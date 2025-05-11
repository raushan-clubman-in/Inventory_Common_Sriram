Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class Frm_stockConsumption

    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Dim doctype1 As String
    Dim docno(0) As String
    Dim doctype As String
    Dim condate As DateTime

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
        If U = 1024 Then
            T = T - 0
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
                            If U = 1024 Then
                                L = L + 45
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
                            If U = 1024 Then
                                L = L + 45
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

    Private Sub cmd_fromStorecodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_fromStorecodeHelp.Click
        gSQLString = "SELECT DISTINCT storecode,ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER"
        M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
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


            Call autogenerate()
        Else
            Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
        End If
        vform.Close()
        vform = Nothing
        AxfpSpread1.Focus()
        AxfpSpread1.SetActiveCell(1, 1)

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
            sqlstring = "SELECT * FROM STOREMASTER WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
            gconnection.getDataSet(sqlstring, "storemaster")
            If gdataset.Tables("storemaster").Rows.Count > 0 Then
                TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                txt_FromStorename.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))


                Call autogenerate()
                AxfpSpread1.Focus()
                AxfpSpread1.SetActiveCell(1, 1)
            Else
                TXT_FROMSTORECODE.Text = ""
                TXT_FROMSTORECODE.Focus()
            End If
        End If
    End Sub

    Private Sub binditemcode()
        Dim vform As New ListOperattion1


        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess, M.Category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "'"
        vform.Field = " I.itemcode, M.Itemname,uom"
        vform.vFormatstring = "    itemcode    |        Itemname             |   UOM      |  batchprocess  | Category   "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
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

            Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
            Next Z

            'Dim a As String=
            If Trim(vform.keyfield3) = "YES" Then
                AxfpSpread1.Col = 5
                AxfpSpread1.ColHidden = False
                Dim SQL1 As String = "with a as ( "
                SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_Ratelist.batchrate as rate,closingqty.uom as uom from a inner  join closingqty on "
                SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                SQL1 = SQL1 & " inner  join Vw_Ratelist on a.batchno=Vw_Ratelist.batchno"
                SQL1 = SQL1 & " and a.itemcode=Vw_Ratelist.itemcode and  a.storecode=closingqty.storecode and a.storecode=vw_ratelist.storecode "
                SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(vform.keyfield) + "'"
                SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND A.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate "


                gconnection.getDataSet(SQL1, "closingtable")

                If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                    AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                    GroupBox5.Visible = True
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
                Dim convvalue As Double

                sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                    Dim sql1 As String
                    If rateflag = "W" Then
                        sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                    Else
                        sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                    End If
                    gconnection.getDataSet(sql1, "ratelist")
                    If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                        Dim pr As Double

                        AxfpSpread1.Col = 3
                        sql1 = "select isnull(convvalue,0) as convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                        Else
                            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                            Exit Sub
                        End If
                        AxfpSpread1.Col = 8
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue))
                    Else
                        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + vform.keyfield + "'  AND  openningqty<>0 "
                        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                            Dim pr As Double

                            AxfpSpread1.Col = 3
                            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                            Else
                                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                                Exit Sub
                            End If
                            AxfpSpread1.Col = 8
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow


                            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)


                        Else
                            AxfpSpread1.Col = 8
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = 0

                        End If
                    End If
                   

                End If

                AxfpSpread1.Col = 5
                AxfpSpread1.ColHidden = True
                AxfpSpread1.Col = 3

                Dim uom As String = AxfpSpread1.Text
                Dim uom1 As String
                Dim itemcode As String
                AxfpSpread1.Col = 1
                itemcode = AxfpSpread1.Text
                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                gconnection.getDataSet(sql11, "closingtable")
                Dim closingqty As Double
                If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

                Else
                    closingqty = 0
                End If
                uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    convvalue = 1
                End If
                closingqty = closingqty * convvalue

                AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))

                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)

            End If

        End If
    End Sub
    Private Sub binditemname()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim myValue As Object

        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess,M.category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "'"
        vform.Field = " I.itemcode, M.Itemname,I.Uom,batchprocess"
        vform.vFormatstring = "    itemcode    |        Itemname             |   UOM      |  batchprocess  | Category   "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
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

            Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
            Next Z

            If Trim(vform.keyfield3) = "YES" Then
                AxfpSpread1.Col = 5
                AxfpSpread1.ColHidden = False

                GroupBox5.Visible = True
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
                    GroupBox5.Visible = False
                End If

            Else
                Dim convvalue As Double

                sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                    Dim sql1 As String
                    If rateflag = "W" Then
                        sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                    Else
                        sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                    End If
                    gconnection.getDataSet(sql1, "ratelist")
                    If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                        Dim pr As Double

                        AxfpSpread1.Col = 3
                        sql1 = "select isnull(convvalue,0) as convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                        Else
                            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                            Exit Sub
                        End If
                        AxfpSpread1.Col = 8
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue))
                    Else
                        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + vform.keyfield + "'  AND  openningqty<>0 "
                        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                            Dim pr As Double

                            AxfpSpread1.Col = 3
                            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                            Else
                                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                                Exit Sub
                            End If
                            AxfpSpread1.Col = 8
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow


                            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)


                        Else
                            AxfpSpread1.Col = 8
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = 0

                        End If
                    End If


                End If

                AxfpSpread1.Col = 5
                AxfpSpread1.ColHidden = True
                AxfpSpread1.Col = 3

                Dim uom As String = AxfpSpread1.Text
                Dim uom1 As String
                Dim itemcode As String
                AxfpSpread1.Col = 1
                itemcode = AxfpSpread1.Text
                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                gconnection.getDataSet(sql11, "closingtable")
                Dim closingqty As Double
                If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

                Else
                    closingqty = 0
                End If
                uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    convvalue = 1
                End If
                closingqty = closingqty * convvalue

                AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))

                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)


            End If



        End If

    End Sub
    Private Sub autogenerate()
        Dim Sqlstring, Financalyear, doctype As String
        If TXT_FROMSTORECODE.Text <> "" Then

            Try

                doctype = Mid(TXT_FROMSTORECODE.Text, 1, 3)
                Financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
                Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) FROM StockConsumption_header WHERE SUBSTRING(docDETAILS,1,3)='" & Trim(doctype) & "'"
                gconnection.openConnection()
                gcommand = New SqlCommand(Sqlstring, gconnection.Myconn)
                gdreader = gcommand.ExecuteReader
                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        txt_Docno.Text = doctype & "/000001/" & Financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        txt_Docno.Text = doctype & "/" & Format(gdreader(0) + 1, "000000") & "/" & Financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    txt_Docno.Text = doctype & "/000001/" & Financalyear
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
        Else
            txt_Docno.Text = ""
        End If
    End Sub

    Private Sub Clearoperation()
        TXT_FROMSTORECODE.Text = ""
        txt_FromStorename.Text = ""
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        txt_Remarks.Text = ""
        Cmd_Add.Text = "ADD[F7]"
        Me.dtp_Docdate.Value = Format(Now, "dd/MMM/yyyy")
        autogenerate()
    End Sub
    Private Sub addoperation()
        Dim Insert(0) As String
        Dim docno(0) As String
        docno = Split(Trim(txt_Docno.Text), "/")

        sqlstring = "INSERT INTO StockConsumption_header(Docno,Docdetails,Docdate,Doctype,storecode,storedesc,totalqty, "
        sqlstring = sqlstring & " Remarks,Void,Adduser,Adddate )"
        sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
        sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
        sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
        sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "','" + Format(Val(Txttotqty.Text), "0.000") + "',"

        sqlstring = sqlstring & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,"
        sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',getDate())"


        Insert(0) = sqlstring
        'Dim Seq As Double = gconnection.getInvSeq(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"))
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i

            sqlstring = "INSERT INTO StockConsumption_detail(Docno,Docdetails,Docdate,Doctype,storecode,storedesc,"
            sqlstring = sqlstring & " Itemcode,Itemname,Uom,BatchNo,Qty,Consumer,ClosingQty,"
            sqlstring = sqlstring & " Void,Adduser,Adddate,rate,amount,TRNS_SEQ)"
            sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
            sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 5
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

            AxfpSpread1.Col = 4
            Dim qty1 As Double = Val(AxfpSpread1.Text)

            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 6
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 7
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

            sqlstring = sqlstring & " 'N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "',getDate(),"
            AxfpSpread1.Col = 8
            Dim rate As Double = Val(AxfpSpread1.Text)
            sqlstring = sqlstring & " '" & Format(Val(AxfpSpread1.Text), "0.000") & "',"
            AxfpSpread1.Col = 9

            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ",DBO.INV_GETSEQNO('" & Format(dtp_Docdate.Value, "dd/MMM/yyyy") & "'))"

            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            Dim closingqty As Double
            Dim closingvalue As Double
            Dim closingqty1 As Double
            Dim closingvalue1 As Double
            Dim UOM As String
            Dim uom1 As String
            Dim convvalue As Double

            sqlstring = " Select batchprocess from inv_inventoryitemmaster where itemcode='" + itemcode + "' "
            gconnection.getDataSet(sqlstring, "inv_inventoryitemmaster")
            If (gdataset.Tables("inv_inventoryitemmaster").Rows.Count > 0) Then
                If (gdataset.Tables("inv_inventoryitemmaster").Rows(0).Item("batchprocess")) = "YES" Then
                    Dim batchno As String
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 5
                    batchno = AxfpSpread1.Text
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 3
                    UOM = AxfpSpread1.Text
                    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,uom from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + TXT_FROMSTORECODE.Text + "'   and batchno='" + batchno + "' and trndate<'" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
                    gconnection.getDataSet(sqlstring, "closingqty")
                    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                        uom1 = gdataset.Tables("closingqty").Rows(0).Item("uom")
                        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
                        convvalue = gconnection.getvalue(sql)

                        closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
                        closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
                    Else
                        closingqty = 0
                        convvalue = 1
                    End If
                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,trns_seq)"
                    sqlstring = sqlstring & " values ('" + txt_Docno.Text + "',"
                    AxfpSpread1.Col = 1
                    sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 3
                    sqlstring = sqlstring & "'" + uom1 + "', "
                    sqlstring = sqlstring & "  '" + TXT_FROMSTORECODE.Text + "',"
                    sqlstring = sqlstring & " '" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "',"
                    AxfpSpread1.Col = 4

                    sqlstring = sqlstring & " " & Format(Val(closingqty), "0.000") & ","

                    sqlstring = sqlstring & "'" + Format(Val(closingvalue), "0.000") + "' ,"
                    AxfpSpread1.Col = 4
                    sqlstring = sqlstring & " " & Format((Val(AxfpSpread1.Text) / convvalue) * -1, "0.000") & ","
                    sqlstring = sqlstring & " " & Format(Val(closingqty) + ((Val(AxfpSpread1.Text) / convvalue) * -1), "0.000") & ","

                    sqlstring = sqlstring & "'" + Format(Val(closingvalue) - Val(qty1 * rate), "0.000") + "' ,"


                    sqlstring = sqlstring & " 'Y',"
                    sqlstring = sqlstring & "  'CONSUME', "
                    AxfpSpread1.Col = 5
                    sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(dtp_Docdate.Value, "dd/MMM/yyyy") & "'))"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                Else
                    AxfpSpread1.Col = 3
                    UOM = AxfpSpread1.Text
                    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,uom from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and trndate<'" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
                    gconnection.getDataSet(sqlstring, "closingqty")
                    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                        uom1 = gdataset.Tables("closingqty").Rows(0).Item("uom")
                        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
                        convvalue = gconnection.getvalue(sql)

                        closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
                        closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
                    End If
                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,trns_seq)"
                    sqlstring = sqlstring & " values ('" + txt_Docno.Text + "',"
                    AxfpSpread1.Col = 1
                    sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
                    AxfpSpread1.Col = 3
                    sqlstring = sqlstring & "'" + uom1 + "', "
                    sqlstring = sqlstring & "  '" + TXT_FROMSTORECODE.Text + "',"
                    sqlstring = sqlstring & " '" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "',"


                    sqlstring = sqlstring & " '" & Format(Val(closingqty), "0.000") & "',"

                    sqlstring = sqlstring & "'" + Format(Val(closingvalue), "0.000") + "' ,"
                    AxfpSpread1.Col = 4
                    Dim qty As Double = Val(AxfpSpread1.Text) / convvalue
                    sqlstring = sqlstring & " " & Format((Val(AxfpSpread1.Text) / convvalue) * -1, "0.000") & ","
                    sqlstring = sqlstring & " " & Format(closingqty - (Val(AxfpSpread1.Text) / convvalue), "0.000") & ","

                    sqlstring = sqlstring & "'" + Format(Val(closingvalue) - Val(qty1 * rate), "0.000") + "' ,"


                    sqlstring = sqlstring & " 'N',"
                    sqlstring = sqlstring & "  'CONSUME', "
                    AxfpSpread1.Col = 5
                    sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(dtp_Docdate.Value, "dd/MMM/yyyy") & "'))"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring

                End If

                sqlstring = "update CLOSINGQTY set TRNS_SEQ=g.TRNS_SEQ from CLOSINGQTY c inner join StockConsumption_detail g on trnno='" + txt_Docno.Text + "' where c.Itemcode='" + itemcode + "' and  c.Trndate= G.Docdate"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                gconnection.MoreTrans1(Insert)
                ReDim Insert(0)
                sqlstring = "Select getdate()"
                condate = gconnection.getvalue(sqlstring)
                If (Format(CDate(condate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
                    Dim batchyn As String
                    Dim AUTOID As Integer = 0

                    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid from closingqty where itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and trndate<='" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
                    gconnection.getDataSet(sqlstring, "closingqty")
                    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                        AUTOID = Val(gdataset.Tables("closingqty").Rows(0).Item("AUTOID"))
                        closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
                        closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
                    End If

                    sqlstring = "update closingqty set openningstock= openningstock -" + Format(Val(qty1), "0.000") + " ,"
                    sqlstring = sqlstring & "  openningvalue="
                    sqlstring = sqlstring & "  CASE WHEN openningstock=0"
                    sqlstring = sqlstring & "  THEN"
                    sqlstring = sqlstring & "   '" + Format(Val((qty1 * rate)), "0.000") + "' "
                    sqlstring = sqlstring & "    Else"

                    sqlstring = sqlstring & "  openningvalue -" + Format(Val((qty1 * rate)), "0.000") + ""
                    sqlstring = sqlstring & "    End"
                    sqlstring = sqlstring & " ,closingstock= closingstock -" + Format(Val(qty1), "0.000") + " ,"
                    sqlstring = sqlstring & "  closingvalue="
                    sqlstring = sqlstring & "  CASE WHEN closingstock=0"
                    sqlstring = sqlstring & "  THEN "
                    sqlstring = sqlstring & "  0 "
                    sqlstring = sqlstring & "  Else"
                    sqlstring = sqlstring & "     closingvalue -" + Format(Val((qty1 * rate)), "0.000") + ""
                    sqlstring = sqlstring & "       End"

                    sqlstring = sqlstring & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "'"
                    sqlstring = sqlstring & "   and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "'"
                    '  sqlstring = sqlstring & " AND AUTOID >'" + AUTOID.ToString() + "'  "
                    'If (batchyn = "Y") Then
                    '    AxfpSpread1.Col = 6
                    '    sqlstring = sqlstring & "  and  batchno='" + AxfpSpread1.Text + "'"
                    'End If
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                End If



            End If


        Next
        'sqlstring = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
        'sqlstring = sqlstring & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
        'sqlstring = sqlstring & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
        'sqlstring = sqlstring & " from inv_Inventoryuomstorelink a inner join closingqty b"
        'sqlstring = sqlstring & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
        'ReDim Preserve Insert(Insert.Length)
        'Insert(Insert.Length - 1) = sqlstring

        gconnection.MoreTrans(Insert)


    End Sub

    Private Sub updateoperation()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim seq As Double

        sqlstring = "select * from StockConsumption_header WHERE Docdetails='" + Trim(CStr(txt_Docno.Text)) + "' and cast(convert(varchar(11),Docdate,106)as datetime)='" & Format(Me.dtp_Docdate.Value, "dd/MMM/yyyy") & "'"
        gconnection.getDataSet(sqlstring, "backdate")
        If gdataset.Tables("backdate").Rows.Count > 0 Then


            sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
            sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
            gconnection.getDataSet(sqlstring, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
            End If

            docno = Split(Trim(txt_Docno.Text), "/")
            sqlstring = "UPDATE StockConsumption_header SET Docdate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "', "
            sqlstring = sqlstring & " Doctype='" & Trim(doctype1) & "',"
            sqlstring = sqlstring & " Storecode='" & Trim(TXT_FROMSTORECODE.Text) & "',"
            sqlstring = sqlstring & " Storedesc='" & Trim(txt_FromStorename.Text) & "', "
            sqlstring = sqlstring & " Totalqty=" & Format(Val(Txttotqty.Text), "0.000") & ","
            sqlstring = sqlstring & " Remarks='" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,"
            sqlstring = sqlstring & " Void='N',Updateuser='" & Trim(gUsername) & "',"
            sqlstring = sqlstring & " Updatetime=getDate()"
            sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
            insert(0) = sqlstring
            sqlstring = "DELETE FROM StockConsumption_detail WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
            Dim SQL1 As String
            Dim SEQ1 As Double
            SQL1 = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
            SQL1 = SQL1 & " and Trnno='" + txt_Docno.Text + "' "
            gconnection.getDataSet(SQL1, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
            End If
            For i As Integer = 1 To AxfpSpread1.DataRowCnt


                sqlstring = "INSERT INTO StockConsumption_detail(Docno,Docdetails,Docdate,Doctype,storecode,storedesc,"
                sqlstring = sqlstring & " Itemcode,Itemname,Uom,BatchNo,Qty,Consumer,ClosingQty,"
                sqlstring = sqlstring & " Void,Adduser,Adddate,rate,amount,TRNS_SEQ)"
                sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
                AxfpSpread1.Col = 1
                Dim itemcode As String = AxfpSpread1.Text
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 2
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 3
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 5
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

                AxfpSpread1.Col = 4
                Dim qty As Double = Val(AxfpSpread1.Text)
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 6
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 7
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

                sqlstring = sqlstring & " 'N',"
                sqlstring = sqlstring & " '" & Trim(gUsername) & "',getDate(),"
                AxfpSpread1.Col = 8
                sqlstring = sqlstring & " '" & Format(Val(AxfpSpread1.Text), "0.000") & "',"
                AxfpSpread1.Col = 9
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & "," & SEQ1.ToString() & ")"

                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring


                Dim qty1 As Double
                Dim batchyn As String
                Dim uom As String
                Dim uom1 As String
                Dim convvalue As Double
                Dim batchno As String
                AxfpSpread1.Col = 3
                uom1 = AxfpSpread1.Text
                AxfpSpread1.Col = 5
                batchno = AxfpSpread1.Text

                SQL1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
                SQL1 = SQL1 & " and Trnno='" + txt_Docno.Text + "' "
                'If (batchno <> "") Then
                '    SQL1 = SQL1 & " and  batchno='" + batchno + "' "
                'End If

                gconnection.getDataSet(SQL1, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                    Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                    convvalue = gconnection.getvalue(sql)
                Else
                    qty1 = 0
                    convvalue = 1
                End If
                SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + ",qty=-" + Format(Val(qty / convvalue), "0.000") + ""
                SQL1 = SQL1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + "*(closingvalue/closingstock))"
                SQL1 = SQL1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + "*(openningvalue/openningstock))"
                SQL1 = SQL1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
                'If (batchyn = "Y") Then
                '    SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
                'End If
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = SQL1

                SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + ""
                SQL1 = SQL1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + "*(closingvalue/closingstock))"
                SQL1 = SQL1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + "*(openningvalue/openningstock))"
                SQL1 = SQL1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
                'If (batchyn = "Y") Then
                '    SQL1 = SQL1 & "  and  batchno='" + txt_Docno.Text + "'"
                'End If
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = SQL1



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

            gconnection.MoreTrans(insert)
            For k As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = k
                AxfpSpread1.Col = 1
                sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
                sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' and itemcode='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(sqlstring, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
                End If
                gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, seq)

            Next
        Else
            voidoperationupdate()
            addoperation()
        End If
    End Sub

    Private Sub voidoperationupdate()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim i As Integer

        Dim seq As Double

        sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
        gconnection.getDataSet(sqlstring, "closingqty")
        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        End If

        docno = Split(Trim(txt_Docno.Text), "/")
        'sqlstring = "UPDATE StockConsumption_header SET "
        'sqlstring = sqlstring & " Void='Y' "
        'sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "

        sqlstring = "delete from  StockConsumption_header  where Docdetails='" & Trim(txt_Docno.Text) & "'"
        insert(0) = sqlstring

        ' sqlstring = "UPDATE  StockConsumption_detail set void='Y' WHERE docdetails='" & Trim(txt_Docno.Text) & "' "

        sqlstring = "delete from  StockConsumption_detail  where Docdetails='" & Trim(txt_Docno.Text) & "'"

        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring
        sqlstring = "delete from  closingqty  where trnno='" & Trim(txt_Docno.Text) & "'"
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim itemcode As String
            AxfpSpread1.Col = 1
            itemcode = AxfpSpread1.Text
            Dim convvalue As Double
            Dim batchno As String
            Dim sql1 As String
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 5
            batchno = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            uom1 = AxfpSpread1.Text
            sql1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
            sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
            If batchno <> "" Then
                sql1 = sql1 & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql1, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                convvalue = gconnection.getvalue(sql)
            Else
                qty1 = 0
                convvalue = 1
            End If
            sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + ",qty=-" + Format(Val(0 / convvalue), "0.000") + ""
            sql1 = sql1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
            sql1 = sql1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
            sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
            If (batchyn = "Y") Then
                sql1 = sql1 & "  and  batchno='" + batchno + "'"
            End If
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sql1

            sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1)), "0.000") + ""
            sql1 = sql1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
            sql1 = sql1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
            sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
            If (batchyn = "Y") Then
                sql1 = sql1 & "  and  batchno='" + batchno + "'"
            End If
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sql1
        Next i
        'sqlstring = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
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
        '    gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, seq)

        'Next

    End Sub



    Private Sub voidoperation()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim i As Integer

        Dim seq As Double

        sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
        gconnection.getDataSet(sqlstring, "closingqty")
        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        End If

        docno = Split(Trim(txt_Docno.Text), "/")
        sqlstring = "UPDATE StockConsumption_header SET "
        sqlstring = sqlstring & " Void='Y' "
        sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        insert(0) = sqlstring
        sqlstring = "UPDATE  StockConsumption_detail set void='Y' WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim itemcode As String
            AxfpSpread1.Col = 1
            itemcode = AxfpSpread1.Text
            Dim convvalue As Double
            Dim batchno As String
            Dim sql1 As String
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 5
            batchno = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            uom1 = AxfpSpread1.Text
            sql1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
            sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
            If batchno <> "" Then
                sql1 = sql1 & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql1, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                convvalue = gconnection.getvalue(sql)
            Else
                qty1 = 0
                convvalue = 1
            End If
            sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + ",qty=-" + Format(Val(0 / convvalue), "0.000") + ""
            sql1 = sql1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
            sql1 = sql1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
            sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
            If (batchyn = "Y") Then
                sql1 = sql1 & "  and  batchno='" + batchno + "'"
            End If
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sql1

            sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1)), "0.000") + ""
            sql1 = sql1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
            sql1 = sql1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
            sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
            If (batchyn = "Y") Then
                sql1 = sql1 & "  and  batchno='" + batchno + "'"
            End If
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sql1
        Next i
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

        For k As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = k
            AxfpSpread1.Col = 1
            sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
            sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' and itemcode='" + AxfpSpread1.Text + "'"
            gconnection.getDataSet(sqlstring, "closingqty")
            gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, seq)

        Next

    End Sub
    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String
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
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                        AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                        AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                        AxfpSpread1.Col = 3
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow

                        SQL = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                        gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                        Next Z
                        If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES" Then


                            ' gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))


                            ' Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                            Dim SQL1 As String = "with a as ( "
                            SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty where trndate<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'"
                            SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                            SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_Ratelist.batchrate as rate,closingqty.uom from a inner  join closingqty on "
                            SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                            SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                            SQL1 = SQL1 & " inner  join Vw_Ratelist on a.batchno=Vw_Ratelist.batchno"
                            SQL1 = SQL1 & " and a.itemcode=Vw_Ratelist.itemcode and  a.storecode=closingqty.storecode and a.storecode=vw_ratelist.storecode "
                            SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                            SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND a.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  closingqty.closingstock>0 order by trndate "
                            'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                            'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "

                            gconnection.getDataSet(SQL1, "closingtable")
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                                GroupBox5.Visible = True
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
                                GroupBox5.Visible = False
                                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                            End If
                            '  Calculate()
                        Else
                            Dim convvalue As Double

                            SQL = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                            gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                            If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                                Dim sql1 As String
                                If rateflag = "W" Then
                                    sql1 = " select TOP 1  weightedrate as rate,UOM from vw_ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' >= grndate  order by grndate desc "
                                Else
                                    sql1 = " select TOP 1  batchrate as rate,UOM from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' >= grndate  order by grndate desc "

                                End If
                                gconnection.getDataSet(sql1, "ratelist")
                                If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                                    Dim pr As Double

                                    AxfpSpread1.Col = 3
                                    sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                                    gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                        convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                        pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                    Else
                                        MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                                        Exit Sub
                                    End If
                                    AxfpSpread1.Col = 8
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                                Else
                                    sql1 = "select (openningvalue/openningqty) as rate,UOM from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and isnull(openningqty,0)<>0 "
                                    gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                                        Dim pr As Double

                                        AxfpSpread1.Col = 3
                                        sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                                        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                        Else
                                            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                                            Exit Sub
                                        End If
                                        AxfpSpread1.Col = 8
                                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                        AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                                    Else
                                        AxfpSpread1.Col = 8
                                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                        AxfpSpread1.Text = "0"

                                    End If
                                End If


                            End If

                            AxfpSpread1.Col = 5
                            AxfpSpread1.ColHidden = True
                            AxfpSpread1.Col = 3

                            Dim uom As String = AxfpSpread1.Text
                            Dim uom1 As String
                            Dim itemcode As String
                            AxfpSpread1.Col = 1
                            itemcode = AxfpSpread1.Text
                            '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                            Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                            gconnection.getDataSet(sql11, "closingtable")
                            Dim closingqty As Double
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

                            Else
                                closingqty = 0
                            End If
                            uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                            sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                            gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                            Else
                                convvalue = 1
                            End If
                            closingqty = closingqty * convvalue

                            AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))

                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)


                        End If

                    Else

                    End If

                End If                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 2 And AxfpSpread1.Lock = False Then
                AxfpSpread1.Col = 2
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemname()
                Else

                    SQL = " select I.itemcode,Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(m.itemname,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

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
                        If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES" Then
                            '  gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            '  Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                            'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                            'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                            Dim SQL1 As String = "with a as ( "
                            SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty where trndate<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                            SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                            SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_Ratelist.batchrate as rate,closingqty.uom as uom from a inner  join closingqty on "
                            SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                            SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                            SQL1 = SQL1 & " inner  join Vw_Ratelist on a.batchno=Vw_Ratelist.batchno"
                            SQL1 = SQL1 & " and a.itemcode=Vw_Ratelist.itemcode and  a.storecode=closingqty.storecode and a.storecode=vw_ratelist.storecode "
                            SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                            SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND a.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  closingqty.closingstock>0 order by trndate "

                            gconnection.getDataSet(SQL1, "closingtable")
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                                GroupBox5.Visible = True

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
                                GroupBox5.Visible = False
                                AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)

                            End If


                        Else
                            Dim convvalue As Double

                            SQL = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                            gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                            If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                                Dim sql1 As String
                                If rateflag = "W" Then
                                    sql1 = " select TOP 1  weightedrate as rate,uom from vw_ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' "
                                    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                                Else
                                    sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                                End If
                                gconnection.getDataSet(sql1, "ratelist")
                                If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                                    Dim pr As Double

                                    AxfpSpread1.Col = 3
                                    sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                                    gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                        convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                        pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                    Else
                                        MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                                        Exit Sub
                                    End If
                                    AxfpSpread1.Col = 8
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                                Else
                                    sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and isnull(openningqty,0)<>0 "
                                    gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                                        Dim pr As Double

                                        AxfpSpread1.Col = 3
                                        sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                                        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                        Else
                                            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                                            Exit Sub
                                        End If
                                        AxfpSpread1.Col = 8
                                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                        AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                                    Else
                                        AxfpSpread1.Col = 8
                                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                        AxfpSpread1.Text = "0"

                                    End If
                                End If


                            End If


                            AxfpSpread1.Col = 5
                            AxfpSpread1.ColHidden = True
                            AxfpSpread1.Col = 3

                            Dim uom As String = AxfpSpread1.Text
                            Dim uom1 As String
                            Dim itemcode As String
                            AxfpSpread1.Col = 1
                            itemcode = AxfpSpread1.Text
                            '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                            Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                            gconnection.getDataSet(sql11, "closingtable")
                            Dim closingqty As Double
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

                            Else
                                closingqty = 0
                            End If
                            uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                            sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                            gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                            Else
                                convvalue = 1
                            End If
                            closingqty = closingqty * convvalue

                            AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))

                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)


                        End If
                        'AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(2, AxfpSpread1.ActiveRow)
                    End If
                End If

                'QTY
            ElseIf AxfpSpread1.ActiveCol = 3 Then
                Dim convvalue As Double

                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Col = 1
                Dim sql1 As String
                Dim ITEMCODE As String
                ITEMCODE = AxfpSpread1.Text
                SQL = "    sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER inner join inv_inventoryitemmaster on"
                SQL = SQL & " inv_inventoryitemmaster.category = INVENTORYCATEGORYMASTER.CATEGORYCODE where itemcode='" + Trim(ITEMCODE) + "'"
                '  sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")

                    If rateflag = "W" Then
                        sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(ITEMCODE) + "' "
                        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                    Else
                        sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(ITEMCODE) + "' "
                        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                    End If
                    gconnection.getDataSet(sql1, "ratelist")
                    If (gdataset.Tables("ratelist").Rows.Count > 0) Then


                        Dim pr As Double

                        AxfpSpread1.Col = 3
                        sql1 = "select isnull(convvalue,0) as convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                        Else
                            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                            Exit Sub
                        End If
                        AxfpSpread1.Col = 8
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                    Else
                        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(0).Item("itemcode")) + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and isnull(openningqty,0) <>0 "
                        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                            Dim pr As Double

                            AxfpSpread1.Col = 3
                            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                            Else
                                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                                Exit Sub
                            End If
                            AxfpSpread1.Col = 8
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                        End If
                    End If
                End If
                AxfpSpread1.Col = 1
                ITEMCODE = AxfpSpread1.Text
                AxfpSpread1.Col = 3
                Dim UOM As String = AxfpSpread1.Text
                Dim UOM1 As String
                Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                gconnection.getDataSet(sql11, "closingtable")
                Dim closingqty As Double
                If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

                Else
                    closingqty = 0
                End If
                UOM1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + UOM1 + "' and transuom='" + UOM + "'"
                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")

                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    convvalue = 1
                End If
                closingqty = closingqty * convvalue

                AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))



            ElseIf AxfpSpread1.ActiveCol = 4 Then



                AxfpSpread1.Col = 4
                If (Val(AxfpSpread1.Text) <> 0) Then
                    Dim issuedqty As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 8
                    Dim RATE As Double = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 9
                    AxfpSpread1.Text = issuedqty * RATE

                    AxfpSpread1.Col = 1
                    Dim itemcode As String = AxfpSpread1.Text
                    SQL = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
                    gconnection.getDataSet(SQL, "INV_InventoryItemMaster")
                    If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                        If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
                            AxfpSpread1.Col = 3
                            Dim uom As String = AxfpSpread1.Text
                            Dim uom1 As String
                            '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                            Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                            gconnection.getDataSet(sql11, "closingtable")
                            Dim closingqty As Double
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

                            Else
                                closingqty = 0
                            End If
                            uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                            SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                            gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                            Dim convvalue As Double
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                            Else
                                convvalue = 0
                            End If
                            closingqty = closingqty * convvalue
                            If (issuedqty > Format(Val(closingqty), "0.000")) Then
                                MessageBox.Show("Consume Quantity Cannot be Greater than Closing Quantity " + closingqty.ToString())
                                AxfpSpread1.SetText(4, AxfpSpread1.ActiveRow, "0.0")
                                AxfpSpread1.SetActiveCell(4, AxfpSpread1.Row)
                            Else
                                AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                            End If
                        End If

                    End If


                Else

                    'Calculate()
                    If (GroupBox3.Visible = True) Then
                        AxfpSpread2.SetActiveCell(5, 1)
                        AxfpSpread2.Focus()
                    Else


                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                    End If
                End If
            ElseIf AxfpSpread1.ActiveCol = 6 Then

                AxfpSpread1.Col = 6
                If Trim(AxfpSpread1.Text) = "" Then


                    bindconsumercode()
                Else

                    sqlstring = "SELECT ISNULL(CONNAME,'') AS CONNAME,ISNULL(CONTYPE,'') AS CONTYPE,ISNULL(FREEZE,'') AS FREEZE,ADDDATE FROM CONSUMERMASTER WHERE CONNAME='" & Trim(AxfpSpread1.Text) & "'"
                    gconnection.getDataSet(sqlstring, "CONSUMERMASTER")
                    If gdataset.Tables("CONSUMERMASTER").Rows.Count > 0 Then
                        AxfpSpread1.Text = Trim(gdataset.Tables("CONSUMERMASTER").Rows(0).Item("CONNAME"))
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    Else
                        AxfpSpread1.Text = ""
                    End If

                End If
            End If

        ElseIf e.keyCode = Keys.F3 Then

            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)

        End If

        If (GroupBox3.Visible = True) Then
            AxfpSpread2.SetActiveCell(5, 1)
            AxfpSpread2.Focus()
            Me.Focus()
        End If

    End Sub

    Private Sub bindconsumercode()
        gSQLString = "SELECT ISNULL(CONTYPE,'') AS CONTYPE,ISNULL(CONNAME,'') AS CONNAME FROM CONSUMERMASTER"
        M_WhereCondition = "  "
        Dim vform As New ListOperattion1
        vform.Field = "CONNAME,CONTYPE"
        vform.vFormatstring = "         CONSUMER NO              |                CONSUMER NAME                                                                                                 "
        vform.vCaption = "CONSUMER MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            AxfpSpread1.Col = 6
            AxfpSpread1.Text = vform.keyfield1
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Frm_stockConsumption_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub Frm_stockConsumption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        doctype1 = "CON"
        'Call Resize_Form()
        'Me.DoubleBuffered = True
        autogenerate()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "CONSUMPTION"

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

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Clearoperation()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub ButCANCEL_Click(sender As Object, e As EventArgs) Handles ButCANCEL.Click
        GroupBox5.Visible = False
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
                sql = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
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
                        AxfpSpread1.SetText(7, K, Val(AxfpSpread2.Text) * convvalue)

                    Else
                        AxfpSpread1.InsertRows(K + m, 1)
                        sql = " select I.itemcode,Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                        sql = sql & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(I.itemcode,'')='" + Trim(itemcode) + "'"
                        gconnection.getDataSet(sql, "inv_InventoryOpenningstock")
                        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                            AxfpSpread1.SetText(1, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            AxfpSpread1.SetText(3, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            AxfpSpread2.Row = l
                            AxfpSpread1.SetText(4, K + m - 1, batchqty * convvalue)
                            AxfpSpread2.Col = 2
                            AxfpSpread1.SetText(5, K + m - 1, AxfpSpread2.Text)
                            AxfpSpread2.Col = 3
                            AxfpSpread1.SetText(7, K + m - 1, Val(AxfpSpread2.Text))


                        End If

                    End If
                    m = m + 1
                    totbatchqty = totbatchqty + (batchqty * convvalue)
                    AxfpSpread1.SetActiveCell(6, K)
                    ' Calculate()
                End If

            Next
        End If
        For i As Integer = 0 To AxfpSpread2.DataRowCnt
            AxfpSpread2.Col = 5
            qty += Val(AxfpSpread2.Text)

        Next
        GroupBox5.Visible = False

    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            If validateoninsert() = False Then

                addoperation()
                Clearoperation()
            End If
        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
            If validateonupdate() = False Then
                updateoperation()
                Clearoperation()

            End If
        End If
    End Sub



    Private Function validateoninsert() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        If Mid(UCase(gShortname), 1, 3) = "CCL" Then
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
        Else
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
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
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If
        For j As Integer = 0 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 4
            If (Val(AxfpSpread1.Text) <> 0) Then
                Dim issuedqty As Double = Val(AxfpSpread1.Text)
                Dim sql As String
                AxfpSpread1.Col = 1
                Dim itemcode As String = AxfpSpread1.Text
                sql = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
                gconnection.getDataSet(sql, "INV_InventoryItemMaster")
                If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                    If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
                        AxfpSpread1.Col = 3
                        Dim uom As String = AxfpSpread1.Text
                        Dim uom1 As String
                        '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                        Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                        gconnection.getDataSet(sql11, "closingtable")
                        Dim closingqty As Double
                        If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                            closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

                        Else
                            closingqty = 0
                        End If
                        uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                        sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                        gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                        Dim convvalue As Double
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                        Else
                            convvalue = 0
                        End If
                        closingqty = closingqty * convvalue
                        sql = "select closingstock +" + Format(Val(-(issuedqty)), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
                        sql = sql & "and closingstock +" + Format(Val(-(issuedqty)), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "'"
                        'If batchyn = "Y" Then
                        '    sql = sql & " and batchno='" + batchno + "'"
                        'End If
                        gconnection.getDataSet(sql, "closingqty")
                        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                            MessageBox.Show("Consumption  create " + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag
                        End If
                        If (issuedqty > Format(Val(closingqty), "0.000")) Then
                            MessageBox.Show("Consume Quantity Cannot be Greater than Closing Quantity " + closingqty.ToString())
                            flag = True
                            Return flag



                        End If
                    End If

                End If



            End If
        Next

        Return False
    End Function

    Private Function validateonupdate() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        If Mid(UCase(gShortname), 1, 3) = "CCL" Then
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
        Else
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
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
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i + 1

            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 5
            Dim qty As String = Val(AxfpSpread1.Text)
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim convvalue As Double
            Dim batchno As String
            AxfpSpread1.Col = 6
            batchno = AxfpSpread1.Text
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
            sql = "select closingstock +" + Format(Val(-(qty / convvalue) - qty1), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(-(qty / convvalue) - qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "'"
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Updation create" + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If


        Next
        For j As Integer = 0 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 4
            If (Val(AxfpSpread1.Text) <> 0) Then
                Dim issuedqty As Double = Val(AxfpSpread1.Text)
                Dim sql As String
                AxfpSpread1.Col = 1
                Dim itemcode As String = AxfpSpread1.Text
                sql = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
                gconnection.getDataSet(sql, "INV_InventoryItemMaster")
                If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                    If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
                        AxfpSpread1.Col = 3
                        Dim uom As String = AxfpSpread1.Text
                        Dim uom1 As String
                        '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                        Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trns_seq desc"


                        gconnection.getDataSet(sql11, "closingtable")
                        Dim closingqty As Double
                        If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                            closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

                        Else
                            closingqty = 0
                        End If
                        uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                        sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                        gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                        Dim convvalue As Double
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                        Else
                            convvalue = 0
                        End If
                        closingqty = closingqty * convvalue
                        If (issuedqty > closingqty) Then
                            MessageBox.Show("Consume Quantity Cannot be Greater than Closing Quantity " + closingqty.ToString())
                            flag = True
                            Return flag



                        End If
                    End If

                End If



            End If
        Next

        Return False
    End Function

    Private Function validateonvoid() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        If Mid(UCase(gShortname), 1, 3) = "CCL" Then
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
        Else
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
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

        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 5
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
            sql = "select closingstock +" + Format(Val(-qty1), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(-qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Deletion create" + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If

        Next

        Return False
    End Function

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        If MessageBox.Show("Do You Want void it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then
            Exit Sub
        End If

        If Mid(CStr(Cmd_Freeze.Text), 1, 1) = "V" Then
            If validateonvoid() = False Then
                voidoperation()
                Clearoperation()

            End If
        End If
    End Sub

    Private Sub cmd_Docnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Docnohelp.Click
        Try
            gSQLString = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE FROM StockConsumption_header"
            M_WhereCondition = ""
            Dim vform As New List_Operation
            vform.Field = "DOCDETAILS,DOCDATE"
            vform.vFormatstring1 = "       DOC NO.            |         DOC DATE                             "
            vform.vCaption = "STOCK CONSUMTION HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Docno.Text = Trim(vform.keyfield & "")
                Call txt_Docno_Validated(txt_Docno, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Docno_Validated(sender As Object, e As EventArgs) Handles txt_Docno.Validated
        Dim vString, sqlstring, Stritemcode As String
        Dim Clsquantity As Double
        Dim dt As New DataTable
        Dim j, i As Integer
        If Trim(txt_Docno.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(DOCNO,'') AS DOCNO,ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(STORECODE,'') AS STORECODE, "
                sqlstring = sqlstring & " ISNULL(StoreDESC,'') AS StoreDESC,"
                sqlstring = sqlstring & " ISNULL(REMARKS,'') AS REMARKS,ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,"
                sqlstring = sqlstring & " ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,UPDATETIME FROM StockConsumption_header "
                sqlstring = sqlstring & " WHERE  (DOCNO='" & Trim(txt_Docno.Text) & "'OR DOCDETAILS='" & Trim(txt_Docno.Text) & "')"
                gconnection.getDataSet(sqlstring, "STOCKADJUSTHEADER")
                '''************************************************* SELECT RECORD FROM STOCKADJUSTHEADER *********************************************''''                
                If gdataset.Tables("STOCKADJUSTHEADER").Rows.Count > 0 Then
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Docno.ReadOnly = True
                    txt_Docno.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("DOCDETAILS"))
                    dtp_Docdate.Value = Format(CDate(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("DOCDATE")), "dd/MMM/yyyy")
                    txt_Remarks.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("REMARKS") & "")
                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("STORECODE"))
                    txt_FromStorename.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("StoreDESC"))
                    If gdataset.Tables("stockadjustheader").Rows(0).Item("VOID") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("UPDATETIME")), "dd/MMM/yyyy")
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.Cmd_Freeze.Enabled = True
                        Me.lbl_Freeze.Text = "Record Void  On "
                        Me.Cmd_Freeze.Text = "Void[F8]"
                    End If
                    '''************************************************* SELECT RECORD FROM STOCKADJUSTEDDETAILS *********************************************''''                
                    sqlstring = "SELECT ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,D.DOCDATE AS DOCDATE,ISNULL(D.STORECODE,'') AS STORELOCATIONCODE,  "
                    sqlstring = sqlstring & " ISNULL(D.STOREDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
                    sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(D.QTY,0) AS QTY "
                    sqlstring = sqlstring & " ,ISNULL(D.BATCHNO,0) AS BATCHNO,"
                    sqlstring = sqlstring & " isnull(d.CONSUMER,'') as consumer,isnull(closingqty,0) as closingqty,isnull(rate,0) as rate,isnull(amount,0) as amount "
                    sqlstring = sqlstring & "  FROM StockConsumption_detail AS D WHERE ISNULL(D.DOCDETAILS,'')='" & Trim(txt_Docno.Text) & "'"
                    gconnection.getDataSet(sqlstring, "STOCKCONSUMTIONDETAILS")
                    If gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count > 0 Then
                        For i = 0 To gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count - 1

                            AxfpSpread1.Row = i + 1
                            AxfpSpread1.SetText(1, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("ITEMCODE")))
                            Stritemcode = Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("ITEMNAME")))
                            Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("itemcode") + "'"

                            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                AxfpSpread1.Col = 3
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z

                            AxfpSpread1.SetText(3, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("UOM")))
                            AxfpSpread1.SetText(4, i + 1, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("QTY")), "0.000"))
                            AxfpSpread1.SetText(5, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("BATCHNO")))
                            AxfpSpread1.SetText(6, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("consumer")))
                            AxfpSpread1.SetText(7, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("CLOSINGQTY")))
                            AxfpSpread1.SetText(7, i + 1, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("rate")), "0.000"))
                            AxfpSpread1.SetText(8, i + 1, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("amount")), "0.000"))

                            '                            ssgrid.SetText(12, i, Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(j).Item("STOCKINHAND")), "0.000"))
                            '  AxfpSpread1.SetText(7, i, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("consumerCODE")))
                            '   ssgrid.SetText(14, i, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("DBLAMOUNT")), "0.000"))
                            '  ssgrid.SetText(8, i, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("DBLCONV")))
                            ' ssgrid.SetText(9, i, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("HIGHRATIO")), "0.000"))


                            ' Clsquantity = ClosingQuantity(Trim(gdataset.Tables("STOCKADJUSTDETAILS").Rows(j).Item("ITEMCODE")), Trim(txt_Storecode.Text))
                            '  AxfpSpread1.SetText(10, i, Format(Val(cls), "0.000"))
                            j = j + 1
                        Next i
                    End If
                    If gUserCategory <> "S" Then
                        ' Call GetRights()
                    End If
                    '   TotalCount = gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count
                    AxfpSpread1.SetActiveCell(1, 1)
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Try

            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Crystkcon
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(STORECODE,'') AS STORECODE,"
            sqlstring = sqlstring & " ISNULL(STOREDESC,'') AS STOREDESC ,"
            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(qty,0) AS qty,ISNULL(BAtCHNO,'') AS BAtCHNO,ISNULL(consumer,'') AS consumer,ISNULL(REMARKS,'') AS REMARKS,ISNULL(ADDDATE,'') AS ADDDATE "
            sqlstring = sqlstring & " FROM StockConsumption_detail"
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
                textobj2 = r.ReportDefinition.ReportObjects("Text19")
                textobj2.Text = gUsername

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
            Dim r As New Crystkadj
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(STORECODE,'') AS STORECODE,"
            sqlstring = sqlstring & " ISNULL(STOREDESC,'') AS STOREDESC ,"
            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(qty,0) AS qty,ISNULL(BATCHNO,'') AS BATCHNO,ISNULL(consumer,'') AS consumer,ISNULL(REMARKS,'') AS REMARKS,ISNULL(ADDDATE,'') AS ADDDATE "
            sqlstring = sqlstring & " FROM StockConsumption_detail"
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
                textobj2 = r.ReportDefinition.ReportObjects("Text19")
                textobj2.Text = gUsername

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


    Private Sub AxfpSpread1_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread1.LeaveCell
        If AxfpSpread1.ActiveCol = 3 Then

            AxfpSpread1.Col = 1
            Dim ITEMCODE As String = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            Dim UOM As String = AxfpSpread1.Text
            Dim UOM1 As String
            Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


            gconnection.getDataSet(sql11, "closingtable")
            Dim closingqty As Double
            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

            Else
                closingqty = 0
            End If
            UOM1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
            sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + UOM1 + "' and transuom='" + UOM + "'"
            gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
            Dim convvalue As Double
            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

            Else
                convvalue = 1
            End If
            closingqty = closingqty * convvalue

            AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))

        End If
    End Sub
End Class