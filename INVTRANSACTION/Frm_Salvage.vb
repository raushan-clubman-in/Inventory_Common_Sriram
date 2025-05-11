Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class Frm_Salvage

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


                'Call autogenerate()
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

            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)


            Else
                Dim convvalue As Double

              
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


        Try

            doctype = "SAL"
            Financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,5,6) As int)) FROM SAL_DETAILS WHERE SUBSTRING(DOCNO,1,3)='" & Trim(doctype) & "'"
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
        
    End Sub

    Private Sub Clearoperation()
        TXT_FROMSTORECODE.Text = ""
        txt_FromStorename.Text = ""
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)

        Cmd_Add.Text = "ADD[F7]"
        Me.dtp_Docdate.Value = Format(Now, "dd/MMM/yyyy")
        autogenerate()
    End Sub
    Private Sub addoperation()
        Dim Insert(0) As String
        Dim docno(0) As String
        docno = Split(Trim(txt_Docno.Text), "/")
 


        Insert(0) = sqlstring
        'Dim Seq As Double = gconnection.getInvSeq(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"))
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i

            sqlstring = "INSERT INTO SAL_DETAILS(Docno,Docdate,storecode,"
            sqlstring = sqlstring & " Itemcode,Itemname,Uom,SALQTY,INVOICENO,RECEIPTDATE,WONO,DQTY,"
            sqlstring = sqlstring & " Remarks,Void,Adduser,Adddate)"
            sqlstring = sqlstring & " VALUES ('" & CStr(Trim(txt_Docno.Text)) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"

            sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "',"
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            sqlstring = sqlstring & " " & Val(AxfpSpread1.Text) & ","
            AxfpSpread1.Col = 5
            sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

            AxfpSpread1.Col = 6
            sqlstring = sqlstring & " '" & Format(CDate(AxfpSpread1.Text), "dd/MMM/yyyy") & "',"
            AxfpSpread1.Col = 7
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 8
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 9
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","


            sqlstring = sqlstring & " 'N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "',getDate() )"
          
           

            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
 
 


        Next
         

        gconnection.MoreTrans(Insert)


    End Sub

    Private Sub updateoperation()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim seq As Double

        sqlstring = "select * from SAL_DETAILS WHERE Docdetails='" + Trim(CStr(txt_Docno.Text)) + "' "
        gconnection.getDataSet(sqlstring, "backdate")
        If gdataset.Tables("backdate").Rows.Count > 0 Then

 

     
            sqlstring = "DELETE FROM SAL_DETAILS WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i

                sqlstring = "INSERT INTO SAL_DETAILS(Docno,Docdate,storecode,"
                sqlstring = sqlstring & " Itemcode,Itemname,Uom,SALQTY,INVOICENO,RECEIPTDATE,WONO,DQTY,"
                sqlstring = sqlstring & " Remarks,Void,Adduser,Adddate)"
                sqlstring = sqlstring & " VALUES ('" & CStr(Trim(txt_Docno.Text)) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"

                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "',"
                AxfpSpread1.Col = 1
                Dim itemcode As String = AxfpSpread1.Text
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 2
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 3
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 4
                sqlstring = sqlstring & " " & Val(AxfpSpread1.Text) & ","
                AxfpSpread1.Col = 5
                sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"

                AxfpSpread1.Col = 6
                sqlstring = sqlstring & " '" & Format(CDate(AxfpSpread1.Text), "dd/MMM/yyyy") & "',"
                AxfpSpread1.Col = 7
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 8
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 9
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","


                sqlstring = sqlstring & " 'N',"
                sqlstring = sqlstring & " '" & Trim(gUsername) & "',getDate() )"



                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring




            Next

            gconnection.MoreTrans(insert)
        Else

        End If
    End Sub

    Private Sub void()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim i As Integer

        Dim seq As Double

        sqlstring = "select * from SAL_DETAILS WHERE DOCNO='" + Trim(CStr(txt_Docno.Text)) + "' "
        gconnection.getDataSet(sqlstring, "backdate")
        If gdataset.Tables("backdate").Rows.Count > 0 Then
            sqlstring = "UPDATE SL_DETAILS SET VOID='Y',VOIDUSER='" & gUsername & "',VOIDDATE='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "'  where Docdetails='" & Trim(txt_Docno.Text) & "'"

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
            gconnection.MoreTrans(insert)
        End If



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

                        gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                        Next Z

                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else

                    End If

                End If                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 4 Then
                AxfpSpread1.Col = 4

                If Val(AxfpSpread1.Text) <> 0 Then
                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                End If

            ElseIf AxfpSpread1.ActiveCol = 5 Then

                AxfpSpread1.Col = 5

                If AxfpSpread1.Text <> "" Then
                    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                End If

            ElseIf AxfpSpread1.ActiveCol = 6 Then

                AxfpSpread1.Col = 6

                If AxfpSpread1.Text <> "" Then
                    AxfpSpread1.SetActiveCell(7, AxfpSpread1.ActiveRow)
                End If

            ElseIf AxfpSpread1.ActiveCol = 7 Then

                AxfpSpread1.Col = 7

                If AxfpSpread1.Text <> "" Then
                    AxfpSpread1.SetActiveCell(8, AxfpSpread1.ActiveRow)
                End If

            ElseIf AxfpSpread1.ActiveCol = 8 Then

                AxfpSpread1.Col = 8

                If Val(AxfpSpread1.Text) <> 0 Then
                    AxfpSpread1.SetActiveCell(9, AxfpSpread1.ActiveRow)
                End If

            ElseIf AxfpSpread1.ActiveCol = 9 Then

                AxfpSpread1.Col = 9

                If Val(AxfpSpread1.Text) <> 0 Then
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                End If

            End If

        ElseIf e.keyCode = Keys.F3 Then

            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)


        End If



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
        doctype1 = "SAL"
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

        AxfpSpread1.Col = 4
        AxfpSpread1.ColHidden = False
        AxfpSpread1.Lock = False

        TXT_FROMSTORECODE.Focus()
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
        
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

  

     

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then


            addoperation()
            Clearoperation()

        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then

            updateoperation()
            Clearoperation()

        End If
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        void()
    End Sub

    Private Sub cmd_Docnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Docnohelp.Click
        Try
            gSQLString = "SELECT DISTINCT ISNULL(DOCNO,'') AS DOCNO,DOCDATE FROM SAL_DETAILS"
            M_WhereCondition = ""
            Dim vform As New List_Operation
            vform.Field = "DOCNO,DOCDATE"
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
           

                sqlstring = " SELECT DOCNO,DOCDATE,ISNULL(INVOICENO,'')INVOICENO,ISNULL(STORECODE,'')STORECODE,ISNULL(ITEMCODE,'')ITEMCODE,ISNULL(ITEMNAME,'')ITEMNAME"
                sqlstring = sqlstring & " , ISNULL (UOM,'')UOM,ISNULL(SALQTY,0)SALQTY,isnull(invoiceno,'')invoiceno,"
                sqlstring = sqlstring & "  ISNULL(RECEIPTDATE,'1-JAN-1990')RECEIPTDATE,ISNULL(WONO,'')WONO,ISNULL(Dqty,0)Dqty,ISNULL(Remarks,'')Remarks,ISNULL(VOID,'N')VOID  FROM SAL_details  where docno='" & Trim(txt_Docno.Text) & "'"

                gconnection.getDataSet(sqlstring, "STOCKCONSUMTIONDETAILS")

              
                If gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count > 0 Then

                    Cmd_Add.Text = "UPDATE [F7]"

                    For i = 0 To gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count - 1

                        AxfpSpread1.Row = i + 1
                        AxfpSpread1.SetText(1, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("ITEMCODE")))

                        AxfpSpread1.SetText(2, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("ITEMNAME")))
                        AxfpSpread1.Col = 2
                        AxfpSpread1.Lock = True
                        AxfpSpread1.SetText(3, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("UOM")))
                        AxfpSpread1.Col = 3
                        AxfpSpread1.Lock = True
                        AxfpSpread1.SetText(4, i + 1, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("SALQTY")), "0.000"))
                        AxfpSpread1.SetText(5, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("invoiceno")))
                        AxfpSpread1.SetText(6, i + 1, Format(CDate(Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("RECEIPTDATE"))), "dd/MM/yy"))
                        AxfpSpread1.SetText(7, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("WONO")))

                        AxfpSpread1.SetText(8, i + 1, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("DQTY")), "0.000"))
                        AxfpSpread1.SetText(9, i + 1, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("Remarks")))

                        TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("STORECODE"))
                        TXT_FROMSTORECODE_Validated(sender, e)
                        If Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(i).Item("Remarks")) = "Y" Then
                            lbl_Freeze.Visible = True
                            Cmd_Freeze.Enabled = False
                            Cmd_View.Enabled = False
                        Else
                            lbl_Freeze.Visible = False
                            Cmd_Freeze.Enabled = True
                            Cmd_View.Enabled = True
                        End If

                       
                        j = j + 1
                    Next i
                End If
                  
                    AxfpSpread1.SetActiveCell(1, 1)

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
            Dim sqlstring As String
            Dim r As New SALVAGE_REPORT
            sqlstring = "SELECT DOCNO,DOCDATE,ISNULL(INVOICENO,'')INVOICENO,ISNULL(STORECODE,'')STORECODE,ISNULL(ITEMCODE,'')ITEMCODE,ISNULL(ITEMNAME,'')ITEMNAME"
            sqlstring = sqlstring & " ,ISNULL (UOM,'')UOM,ISNULL(SALQTY,0)SALQTY,"
            sqlstring = sqlstring & " ISNULL(RECEIPTDATE,'1-JAN-1990')RECEIPTDATE,ISNULL(WONO,'')WONO,ISNULL(Dqty,0)Dqty,ISNULL(Remarks,'')Remarks,ISNULL(VOID,'N')VOID  FROM SAL_details WHERE DOCNO='" & Trim(txt_Docno.Text) & "' AND ISNULL(VOID,'N')<>'Y'"


            gconnection.getDataSet(sqlstring, "SAL_details")
            If gdataset.Tables("SAL_details").Rows.Count > 0 Then
               
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "SAL_details"
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
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub cmd_Print_Click(sender As Object, e As EventArgs) Handles cmd_Print.Click
        'Try

        '    'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
        '    Dim rViewer As New Viewer
        '    Dim sqlstring, SSQL, FROMSTORE As String
        '    Dim r As New Crystkadj
        '    sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(STORECODE,'') AS STORECODE,"
        '    sqlstring = sqlstring & " ISNULL(STOREDESC,'') AS STOREDESC ,"
        '    sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
        '    sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(qty,0) AS qty,ISNULL(BATCHNO,'') AS BATCHNO,ISNULL(consumer,'') AS consumer,ISNULL(REMARKS,'') AS REMARKS,ISNULL(ADDDATE,'') AS ADDDATE "
        '    sqlstring = sqlstring & " FROM StockConsumption_detail"
        '    sqlstring = sqlstring & " WHERE DOCDETAILS ='" & Trim(txt_Docno.Text) & "'"
        '    sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"

        '    gconnection.getDataSet(sqlstring, "VW_INV_STKDMGBILL")
        '    If gdataset.Tables("VW_INV_STKDMGBILL").Rows.Count > 0 Then
        '        'If chk_excel.Checked = True Then
        '        '    Dim exp As New exportexcel
        '        '    exp.Show()
        '        '    Call exp.export(sqlstring, "STOCK DAMAGE ", "")
        '        'Else
        '        rViewer.ssql = sqlstring
        '        rViewer.Report = r
        '        rViewer.TableName = "VW_INV_STKDMGBILL"
        '        Dim textobj1 As TextObject
        '        textobj1 = r.ReportDefinition.ReportObjects("Text12")
        '        textobj1.Text = MyCompanyName
        '        Dim textobj11 As TextObject
        '        textobj11 = r.ReportDefinition.ReportObjects("Text15")
        '        textobj11.Text = UCase(gCompanyAddress(0))
        '        Dim textobj12 As TextObject
        '        textobj12 = r.ReportDefinition.ReportObjects("Text16")
        '        textobj12.Text = UCase(gCompanyAddress(1))
        '        Dim textobj23 As TextObject
        '        textobj23 = r.ReportDefinition.ReportObjects("Text3")
        '        textobj23.Text = gFinancalyearStart + "-" + gFinancialyearEnd

        '        Dim textobj2 As TextObject
        '        textobj2 = r.ReportDefinition.ReportObjects("Text19")
        '        textobj2.Text = gUsername

        '        rViewer.Show()
        '        '   End If
        '    Else
        '        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End Try

    End Sub


    Private Sub AxfpSpread1_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread1.LeaveCell
    
    End Sub
End Class