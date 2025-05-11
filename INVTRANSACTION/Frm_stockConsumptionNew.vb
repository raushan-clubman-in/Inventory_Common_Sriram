Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.Threading
Public Class Frm_stockConsumptionNew

    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Dim doctype1 As String
    Dim docno(0) As String
    Dim doctype As String
    Dim condate As DateTime
    Dim AUTOFILL As Boolean
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
                                L = L + 30
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
                                L = L + 30
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
                            If U = 1024 Then
                                L = L + 30
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

    Private Sub cmd_fromStorecodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_fromStorecodeHelp.Click

        gSQLString = "SELECT DISTINCT storecode,ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER"

        If Trim(UCase(gConsumpTionAllow)) = "S" Then
            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y' and storestatus='S'"
        ElseIf Trim(UCase(gConsumpTionAllow)) = "M" Then
            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y' and storestatus='M'"
        Else
            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
        End If
        M_ORDERBY = ""
        'M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
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
            ' ADDED BY SRI FOR FROM SHELF
            If GSHELVING = "Y" Then
                sqlstring = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster WHERE  STORECODE='" + TXT_FROMSTORECODE.Text + "' And ISNULL(FREEZE,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "FROMSHELF")
                If gdataset.Tables("FROMSHELF").Rows.Count > 0 Then
                    AxfpSpread1.Col = 10
                    AxfpSpread1.ColHidden = False
                Else
                    AxfpSpread1.Col = 10
                    AxfpSpread1.ColHidden = True
                End If
            End If
            ' END 
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
            'If Trim(UCase(gShortname)) = "CCL" Then
            '    sqlstring = "SELECT * FROM STOREMASTER WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' AND   ISNULL(FREEZE,'') <> 'Y' and storestatus='S'  "
            'Else
            '    sqlstring = "SELECT * FROM STOREMASTER WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' AND   ISNULL(FREEZE,'') <> 'Y'"
            'End If


            If Trim(UCase(gConsumpTionAllow)) = "S" Then
                sqlstring = "SELECT * FROM STOREMASTER WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' AND   ISNULL(FREEZE,'') <> 'Y' and storestatus='S'  "
            ElseIf Trim(UCase(gConsumpTionAllow)) = "M" Then
                sqlstring = "SELECT * FROM STOREMASTER WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' AND   ISNULL(FREEZE,'') <> 'Y' and storestatus='M'  "
            Else
                sqlstring = "SELECT * FROM STOREMASTER WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' AND   ISNULL(FREEZE,'') <> 'Y'"
            End If

            gconnection.getDataSet(sqlstring, "storemaster")
            If gdataset.Tables("storemaster").Rows.Count > 0 Then
                TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                txt_FromStorename.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))

                ' ADDED BY SRI FOR FROM SHELF
                If GSHELVING = "Y" Then
                    sqlstring = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster WHERE  STORECODE='" + TXT_FROMSTORECODE.Text + "' And ISNULL(FREEZE,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "FROMSHELF")
                    If gdataset.Tables("FROMSHELF").Rows.Count > 0 Then
                        AxfpSpread1.Col = 10
                        AxfpSpread1.ColHidden = False
                    Else
                        AxfpSpread1.Col = 10
                        AxfpSpread1.ColHidden = True
                    End If
                End If
                ' END 
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
        Dim uom1 As String


        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess, M.Category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "'"
        vform.Field = " I.itemcode, M.Itemname,uom"
        vform.vFormatstring = "    Itemcode    |                      Itemname                     |       UOM      |     batchprocess  | Category   "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
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

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom")).ToUpper()
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom")).ToUpper()
                Next Z
                AxfpSpread1.Text = Trim(vform.keyfield2.ToUpper())
                'If Trim(vform.keyfield3) = "YES" Then
                '     AxfpSpread1.Col = 4
                '     AxfpSpread1.ColHidden = False

                '     '  gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), Trim(vform.keyfield2))
                '     'Dim sql As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno,priority order by priority "
                '     'Dim sql As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                '     'sql = sql & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                '     '
                '     Dim SQL1 As String = "with a as ( "
                '     SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                '     SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                '     SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,closingqty.uom as uom from a inner  join closingqty on "
                '     SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                '     SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                '     'SQL1 = SQL1 & " "
                '     SQL1 = SQL1 & " and   a.storecode=closingqty.storecode  "
                '     SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(vform.keyfield) + "'"
                '     SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND A.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate "


                '     gconnection.getDataSet(SQL1, "closingtable")

                '     If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                '         GroupBox5.Visible = True

                '         AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                '         For i As Integer = 0 To gdataset.Tables("closingtable").Rows.Count - 1
                '             AxfpSpread2.Row = i
                '             AxfpSpread2.Col = 1
                '             AxfpSpread2.SetText(1, i + 1, Trim(vform.keyfield))


                '             AxfpSpread2.Row = i
                '             AxfpSpread2.Col = 2
                '             AxfpSpread2.SetText(2, i + 1, gdataset.Tables("closingtable").Rows(i).Item("batchno"))
                '             AxfpSpread2.Row = i
                '             AxfpSpread2.Col = 3
                '             AxfpSpread2.SetText(3, i + 1, Val(gdataset.Tables("closingtable").Rows(i).Item("quantity")))
                '             AxfpSpread2.Row = i
                '             AxfpSpread2.Col = 4
                '             AxfpSpread2.SetText(4, i + 1, gdataset.Tables("closingtable").Rows(i).Item("uom"))




                '         Next

                '         AxfpSpread2.SetActiveCell(5, 1)
                '         AxfpSpread2.Focus()
                '     Else
                '         GroupBox5.Visible = False

                '         AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                '     End If

                'Else

                Dim convvalue As Double

                'sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                'gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                '    Dim sql1 As String
                '    'If rateflag = "W" Then
                '    '    sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                '    'Else
                '    '    sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                '    'End If
                '    If rateflag = "W" Then

                '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + vform.keyfield + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                '    Else
                '        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + vform.keyfield + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
                '    End If
                '    gconnection.getDataSet(sql1, "ratelist")
                '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                '        Dim pr As Double

                '        AxfpSpread1.Col = 3
                '        sql1 = "select isnull(convvalue,0) as convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                '        Else
                '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                '            Exit Sub
                '        End If
                '        AxfpSpread1.Col = 7
                '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '        AxfpSpread1.Text = Format(Val(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue)), "0.000")
                '    Else
                '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + vform.keyfield + "'  AND  openningqty<>0 "
                '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                '            Dim pr As Double

                '            AxfpSpread1.Col = 3
                '            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                '            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                '            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                '                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                '            Else
                '                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                '                Exit Sub
                '            End If
                '            AxfpSpread1.Col = 7
                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow


                '            AxfpSpread1.Text = Format(Val(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue)), "0.000")


                '        Else
                '            AxfpSpread1.Col = 7
                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '            AxfpSpread1.Text = 0

                '        End If
                '    End If


                'End If


                'AxfpSpread1.Col = 4
                'AxfpSpread1.ColHidden = True
                Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom,closingvalue from closingqty where itemcode='" + vform.keyfield + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                '   gconnection.getDataSet(sql11, "closingtable")

                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), vform.keyfield, Trim(TXT_FROMSTORECODE.Text), "")

                Dim closingqty, rate As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                Else
                    closingqty = 0
                    rate = 0
                End If

                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom1 + "'"
                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    convvalue = 0
                End If
                closingqty = closingqty * convvalue

                AxfpSpread1.SetText(3, AxfpSpread1.ActiveRow, uom1)
                AxfpSpread1.SetText(4, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))
                AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(rate / convvalue), "0.000"))
                AxfpSpread1.Col = 7
                'AxfpSpread1.Text = Format(Val(gdataset.Tables("closingtable").Rows(0).Item("closingvalue")), "0.000")

                'If GBATCHNO = "Y" Then
                '    AxfpSpread1.SetActiveCell(9, AxfpSpread1.ActiveRow)

                'Else
                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)

                '  End If
            End If
        End If

           

        'End If


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
                SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'"
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
                    'If rateflag = "W" Then
                    '    sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                    'Else
                    '    sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                    'End If
                    If rateflag = "W" Then

                        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + vform.keyfield + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                    Else
                        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + vform.keyfield + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
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
                Dim sql11 As String '= "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"

                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), vform.keyfield, Trim(TXT_FROMSTORECODE.Text), "")

                ' gconnection.getDataSet(sql11, "closingstock")
                Dim closingqty As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")

                Else
                    closingqty = 0
                End If
                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    convvalue = 1
                End If
                closingqty = closingqty * convvalue

                AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))

                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)


            End If



        End If

    End Sub
    Private Sub autogenerate()
        Dim Sqlstring, Financalyear, doctype As String
        If TXT_FROMSTORECODE.Text <> "" And Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            Try
                If Len(TXT_FROMSTORECODE.Text) < 3 Then
                    doctype = Mid(TXT_FROMSTORECODE.Text, 1, 2)
                Else
                    doctype = Mid(TXT_FROMSTORECODE.Text, 1, 3)
                End If


                Financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
                If Len(TXT_FROMSTORECODE.Text) < 2 Then
                    Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,4,6) As varchar)) FROM stockConsumption_1 WHERE SUBSTRING(docno,1,2)='" & Trim(doctype) & "'"
                ElseIf Len(TXT_FROMSTORECODE.Text) = 2 Then
                    Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,4,5) As varchar)) FROM stockConsumption_1 WHERE SUBSTRING(docno,1,2)='" & Trim(doctype) & "'"
                Else
                    Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,5,6) As varchar)) FROM stockConsumption_1 WHERE SUBSTRING(docno,1,3)='" & Trim(doctype) & "'"
                End If

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
                MessageBox.Show(ex.Message)
                '   MessageBox.Show("Enter valid GRN No : txt_Grnno_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Finally
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End Try
        Else
            If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                txt_Docno.Text = ""
            End If

        End If
    End Sub

    Private Sub Clearoperation()
        TXT_FROMSTORECODE.Text = ""
        txt_FromStorename.Text = ""
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        AxfpSpread1.Col = 1
        AxfpSpread1.Lock = False
        For k As Integer = 0 To 10
            For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                AxfpSpread1.TypeComboBoxClear(3, k)
            Next
        Next
        txt_Remarks.Text = ""
        AUTOFILL = False
        Cmd_Add.Text = "ADD[F7]"
        Cmd_Freeze.Enabled = True
        Me.btn_Auto_fill.Enabled = True
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True
        Me.dtp_Docdate.Value = Format(Now, "dd/MMM/yyyy")
        Me.lbl_Freeze.Visible = False
        autogenerate()
        Me.dtp_Docdate.Focus()
        If GBATCHNO = "Y" Then
            Dim STRSQL As String
            STRSQL = "delete from temp_batchdetails "
            gconnection.dataOperation(6, STRSQL, )
        End If
    End Sub
    Private Sub addoperation()
        Dim Insert(0) As String
        Dim docno(0) As String
        Dim AMT As Double = 0
        Dim sql2 As String

        docno = Split(Trim(txt_Docno.Text), "/")

        autogenerate()

        'Dim Seq As Double = gconnection.getInvSeq(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"))

        For i As Integer = 1 To AxfpSpread1.DataRowCnt

            AxfpSpread1.Row = i

            sqlstring = "INSERT INTO stockConsumption_1("
            sqlstring = sqlstring & " Itemcode,Itemname,Uom,storecode,storedesc,docdate,adddate,adduser,stockinhand,physicalstock,consumption,"
            If GBATCHNO = "Y" Then
                sqlstring = sqlstring & "BatchNo,"
            End If
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "SHELF,"
            End If
            sqlstring = sqlstring & " rate,amount,Void,docno,doctype,remarks)"

            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            sqlstring = sqlstring & "VALUES ( '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " getdate(),'" & gUsername & "',"
            'sqlstring = sqlstring & " getdate(),"

            AxfpSpread1.Col = 4
            sqlstring = sqlstring & " " & Trim(AxfpSpread1.Text) & ","
            AxfpSpread1.Col = 5
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 6
            Dim qty1 As Double = Val(AxfpSpread1.Text)
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            If GBATCHNO = "Y" Then
                AxfpSpread1.Col = 9
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            End If
            If GSHELVING = "Y" Then
                AxfpSpread1.Col = 10
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            End If
            AxfpSpread1.Col = 7
            Dim rate As Double = Val(AxfpSpread1.Text)
            AMT = AMT + (qty1 * rate)
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 7
            sqlstring = sqlstring & " " & Format(Val(qty1 * rate), "0.000") & ",'N',"
            sqlstring = sqlstring & " '" & CStr(Trim(txt_Docno.Text)) & "','" + doctype1 + "','" & CStr(Trim(txt_Remarks.Text)) & "')"



            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            'Dim closingqty As Double
            'Dim closingvalue As Double
            'Dim closingqty1 As Double
            'Dim closingvalue1 As Double
            'Dim UOM As String
            'Dim uom1 As String
            'Dim convvalue As Double

            'sqlstring = " Select batchprocess from inv_inventoryitemmaster where itemcode='" + itemcode + "' "
            'gconnection.getDataSet(sqlstring, "inv_inventoryitemmaster")
            'If (gdataset.Tables("inv_inventoryitemmaster").Rows.Count > 0) Then
            '    If (gdataset.Tables("inv_inventoryitemmaster").Rows(0).Item("batchprocess")) = "YES" Then
            '        Dim batchno As String
            '        AxfpSpread1.Row = i
            '        AxfpSpread1.Col = 5
            '        batchno = AxfpSpread1.Text
            '        AxfpSpread1.Row = i
            '        AxfpSpread1.Col = 3
            '        UOM = AxfpSpread1.Text
            '        '     sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'   and batchno='" + batchno + "' and trndate<'" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
            '        '   gconnection.getDataSet(sqlstring, "closingqty")
            '        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
            '        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
            '            uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
            '            Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
            '            convvalue = gconnection.getvalue(sql)

            '            closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
            '            closingvalue = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
            '        Else
            '            closingqty = 0
            '            convvalue = 1
            '        End If
            '        sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,TRNS_SEQ,RATE)"
            '        sqlstring = sqlstring & " values ('" + txt_Docno.Text + "',"
            '        AxfpSpread1.Col = 1
            '        sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            '        AxfpSpread1.Col = 3
            '        sqlstring = sqlstring & "'" + uom1 + "', "
            '        sqlstring = sqlstring & "  '" + TXT_FROMSTORECODE.Text + "',"
            '        sqlstring = sqlstring & " '" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "',"
            '        AxfpSpread1.Col = 4

            '        sqlstring = sqlstring & " " & Format(Val(closingqty), "0.000") & ","

            '        sqlstring = sqlstring & "'" + Format(Val(closingvalue), "0.000") + "' ,"
            '        AxfpSpread1.Col = 4
            '        sqlstring = sqlstring & " " & Format((Val(AxfpSpread1.Text) / convvalue) * -1, "0.000") & ","
            '        sqlstring = sqlstring & " " & Format(Val(closingqty) + ((Val(AxfpSpread1.Text) / convvalue) * -1), "0.000") & ","

            '        sqlstring = sqlstring & "'" + Format(Val(closingvalue) - Val(qty1 * rate), "0.000") + "' ,"


            '        sqlstring = sqlstring & " 'Y',"
            '        sqlstring = sqlstring & "  'CONSUME', "
            '        AxfpSpread1.Col = 5
            '        sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(dtp_Docdate.Value, "dd/MMM/yyyy") & "')," & rate.ToString() & ")"
            '        ReDim Preserve Insert(Insert.Length)
            '        Insert(Insert.Length - 1) = sqlstring

            '    Else
            '        AxfpSpread1.Col = 3
            '        UOM = AxfpSpread1.Text
            '        ' sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and trndate<'" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trns_seq desc"
            '        ' gconnection.getDataSet(sqlstring, "closingqty")
            '        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
            '        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
            '            uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
            '            Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
            '            convvalue = gconnection.getvalue(sql)

            '            closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
            '            closingvalue = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
            '        End If
            '        sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,trns_seq,RATE)"
            '        sqlstring = sqlstring & " values ('" + txt_Docno.Text + "',"
            '        AxfpSpread1.Col = 1
            '        sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            '        AxfpSpread1.Col = 3
            '        sqlstring = sqlstring & "'" + uom1 + "', "
            '        sqlstring = sqlstring & "  '" + TXT_FROMSTORECODE.Text + "',"
            '        sqlstring = sqlstring & " '" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "',"


            '        sqlstring = sqlstring & " '" & Format(Val(closingqty), "0.000") & "',"

            '        sqlstring = sqlstring & "'" + Format(Val(closingvalue), "0.000") + "' ,"
            '        AxfpSpread1.Col = 6
            '        Dim qty As Double = Val(AxfpSpread1.Text) / convvalue

            '        ' sqlstring = sqlstring & "' " & Format(closingqty - (Val(AxfpSpread1.Text) / convvalue), "0.000") & "',"

            '        sqlstring = sqlstring & " '" & Format((Val(AxfpSpread1.Text) / convvalue) * -1, "0.000") & "',"
            '        sqlstring = sqlstring & " '" & Format((closingqty - (Val(AxfpSpread1.Text) / convvalue)), "0.000") & "',"

            '        sqlstring = sqlstring & "'" + Format(Val(closingvalue) - Val(qty1 * rate), "0.000") + "' ,"


            '        sqlstring = sqlstring & " 'N',"
            '        sqlstring = sqlstring & "  'CONSUME', "
            '        AxfpSpread1.Col = 5
            '        sqlstring = sqlstring & "'',DBO.INV_GETSEQNO('" & Format(dtp_Docdate.Value, "dd/MMM/yyyy") & "')," & rate.ToString() & ")"
            '        ReDim Preserve Insert(Insert.Length)
            '        Insert(Insert.Length - 1) = sqlstring

            '    End If

            '    'sqlstring = "update CLOSINGQTY set TRNS_SEQ=g.TRNS_SEQ from CLOSINGQTY c inner join stockConsumption_1 g on C.itemcode=G.itemcode AND trnno='" + txt_Docno.Text + "' where c.Itemcode='" + itemcode + "' and  c.Trndate= G.Docdate"
            '    'ReDim Preserve Insert(Insert.Length)
            '    'Insert(Insert.Length - 1) = sqlstring
            '    'gconnection.MoreTrans1(Insert)
            '    'ReDim Insert(0)

            '    sqlstring = "Select getdate()"
            '    condate = gconnection.getvalue(sqlstring)

            '    If (Format(CDate(condate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
            '        Dim batchyn As String
            '        Dim AUTOID As Integer = 0

            '        'sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid from closingqty where itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and CONVERT(VARCHAR(11), trndate, 106)= '" & Format(CDate(dtp_Docdate.Value), "dd MMM yyyy") & "' "
            '        ' gconnection.getDataSet(sqlstring, "closingqty")
            '        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
            '        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
            '            AUTOID = Val(gdataset.Tables("closingstock").Rows(0).Item("AUTOID"))
            '            closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
            '            closingvalue = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
            '        End If

            '        If rate < 0 Then
            '            rate = rate * -1
            '        End If

            '        sqlstring = "update closingqty set openningstock= openningstock -" + Format(Val(qty1), "0.000") + " "
            '        'sqlstring = sqlstring & "  openningvalue="
            '        'sqlstring = sqlstring & "  CASE WHEN openningstock=0"
            '        'sqlstring = sqlstring & "  THEN"
            '        'sqlstring = sqlstring & "   '" + Format(Val((qty1 * rate)), "0.000") + "' "
            '        'sqlstring = sqlstring & "    Else"

            '        'sqlstring = sqlstring & "  openningvalue -" + Format(Val((qty1 * rate)), "0.000") + ""
            '        'sqlstring = sqlstring & "    End"
            '        sqlstring = sqlstring & " ,closingstock= closingstock -" + Format(Val(qty1), "0.000") + " "
            '        'sqlstring = sqlstring & "  closingvalue="
            '        'sqlstring = sqlstring & "  CASE WHEN closingstock=0"
            '        'sqlstring = sqlstring & "  THEN "
            '        'sqlstring = sqlstring & "  0 "
            '        'sqlstring = sqlstring & "  Else"
            '        'sqlstring = sqlstring & "     closingvalue -" + Format(Val((qty1 * rate)), "0.000") + ""
            '        'sqlstring = sqlstring & "       End"

            '        sqlstring = sqlstring & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' AND TTYPE='CONSUME'"
            '        sqlstring = sqlstring & "   and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "'"
            '        '  sqlstring = sqlstring & " AND AUTOID >'" + AUTOID.ToString() + "'  "
            '        'If (batchyn = "Y") Then
            '        '    AxfpSpread1.Col = 6
            '        '    sqlstring = sqlstring & "  and  batchno='" + AxfpSpread1.Text + "'"
            '        'End If
            '        ReDim Preserve Insert(Insert.Length)
            '        Insert(Insert.Length - 1) = sqlstring


            '        'sqlstring = "    update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end ,"
            '        'sqlstring = sqlstring & "  lastweightedrate="
            '        'sqlstring = sqlstring & "  case when openningvalue=0 then"
            '        'sqlstring = sqlstring & "      batchrate "
            '        'sqlstring = sqlstring & "   Else"
            '        'sqlstring = sqlstring & "  openningvalue/openningstock "
            '        'sqlstring = sqlstring & "     End"
            '        'sqlstring = sqlstring & "  from ratelist inner join CLOSINGQTY on ratelist.grnno=CLOSINGQTY.trnno where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "'"
            '        'sqlstring = sqlstring & "   and CLOSINGQTY.storecode='" + TXT_FROMSTORECODE.Text + "' and CLOSINGQTY.itemcode='" + itemcode + "'"
            '        'ReDim Preserve Insert(Insert.Length)
            '        'Insert(Insert.Length - 1) = sqlstring

            '    End If
            '    'gconnection.MoreTrans(Insert)
            '    'ReDim Insert(0)



            'End If



        Next
        If gShortname <> "RSAOI" Then
            If gShortname <> "HIND" Then

                If GACCPOST.ToUpper() = "Y" Then
                    Dim CONGLCODE, CONGLDESC, ACCOUNTCODE, ACCOUNTDESC, CONCCCODE, CONCCDESC, COSTCENTERCODE, COSTCENTERDESC As String
                    Dim decription As String

                    If gAcPostingWise = "ITEM" Then
                        Dim amount, POSTAMT As Double
                        For k As Integer = 1 To AxfpSpread1.DataRowCnt

                            AxfpSpread1.Row = k

                            AxfpSpread1.Col = 8
                            amount = Val(AxfpSpread1.Text)
                            AMT = amount
                            AxfpSpread1.Col = 1
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "Select CONGLCODE,CONGLDESC,CONCCCODE,CONCCDESC,COSTCENTERCODE,COSTCENTERDESC,ACCOUNTCODE,ACCOUNTDESC from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                                gconnection.getDataSet(sqlstring, "SLCODE1")
                                If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                                    CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("CONGLCODE")
                                    CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("CONGLDESC")
                                    CONCCCODE = gdataset.Tables("SLCODE1").Rows(0).Item("CONCCCODE")
                                    CONCCDESC = gdataset.Tables("SLCODE1").Rows(0).Item("CONCCDESC")
                                    ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
                                    ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
                                    COSTCENTERCODE = gdataset.Tables("SLCODE1").Rows(0).Item("COSTCENTERCODE")
                                    COSTCENTERDESC = gdataset.Tables("SLCODE1").Rows(0).Item("COSTCENTERDESC")
                                Else
                                    MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                                    Exit Sub
                                End If
                                If CONGLCODE = "" Then

                                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                                    Exit Sub

                                End If
                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,COSTCENTERCODE,COSTCENTERDESC, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'CONSUMPTION', '" & CONGLCODE & "',"
                                sqlstring = sqlstring & "'" & CONGLDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                sqlstring = sqlstring & "'" & CONCCCODE & "','" & CONCCDESC & "',"
                                sqlstring = sqlstring & "'DEBIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Stock Consumption no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "'" & Format(AMT, "0.000") & "','" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" + gUsername + "')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring


                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,COSTCENTERCODE,COSTCENTERDESC, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'CONSUMPTION', '" & ACCOUNTCODE & "',"
                                sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                sqlstring = sqlstring & "'" & COSTCENTERCODE & "','" & COSTCENTERDESC & "',"
                                sqlstring = sqlstring & "'CREDIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Stock Consumption no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "'" & Format(AMT, "0.000") & "','" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" + gUsername + "')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            End If

                        Next
                    ElseIf gAcPostingWise = "CATEGORY" Then
                        Dim amount, POSTAMT As Double
                        For k As Integer = 1 To AxfpSpread1.DataRowCnt

                            AxfpSpread1.Row = k

                            AxfpSpread1.Col = 8
                            amount = Val(AxfpSpread1.Text)
                            AMT = amount
                            AxfpSpread1.Col = 1
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "select * from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category AND IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
                                gconnection.getDataSet(sqlstring, "SLCODE1")
                                If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                                    CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("CONGLCODE")
                                    CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("CONGLDESC")
                                    CONCCCODE = gdataset.Tables("SLCODE1").Rows(0).Item("CONCCCODE")
                                    CONCCDESC = gdataset.Tables("SLCODE1").Rows(0).Item("CONCCDESC")
                                    ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
                                    ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
                                    COSTCENTERCODE = gdataset.Tables("SLCODE1").Rows(0).Item("COSTCENTERCODE")
                                    COSTCENTERDESC = gdataset.Tables("SLCODE1").Rows(0).Item("COSTCENTERDESC")
                                Else
                                    MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                                    Exit Sub
                                End If
                                If CONGLCODE = "" Then

                                    MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                                    Exit Sub

                                End If
                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,COSTCENTERCODE,COSTCENTERDESC, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'CONSUMPTION', '" & CONGLCODE & "',"
                                sqlstring = sqlstring & "'" & CONGLDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                sqlstring = sqlstring & "'" & CONCCCODE & "','" & CONCCDESC & "',"
                                sqlstring = sqlstring & "'DEBIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Stock Consumption no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "'" & Format(AMT, "0.000") & "','" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" + gUsername + "')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring


                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,COSTCENTERCODE,COSTCENTERDESC, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'CONSUMPTION', '" & ACCOUNTCODE & "',"
                                sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                sqlstring = sqlstring & "'" & COSTCENTERCODE & "','" & COSTCENTERDESC & "',"
                                sqlstring = sqlstring & "'CREDIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Stock Consumption no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "'" & Format(AMT, "0.000") & "','" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" + gUsername + "')"
                                ReDim Preserve Insert(Insert.Length)
                                Insert(Insert.Length - 1) = sqlstring
                            End If

                        Next
                    Else

                        sqlstring = "select CONGLCODE, CONGLDESC,CONCCCODE,CONCCDESC,ACCOUNTCODE,ACCOUNTDESC,COSTCENTERCODE,COSTCENTERDESC from ACCOUNTSTAGGINGNEW  WHERE "
                        sqlstring = sqlstring & "CODE='" & TXT_FROMSTORECODE.Text & "' AND DESCRIPTION='" & txt_FromStorename.Text & "' AND  isnull(VOID,'')<>'Y'"
                        gconnection.getDataSet(sqlstring, "SLCODE1")

                        If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                            CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("CONGLCODE")
                            CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("CONGLDESC")
                            CONCCCODE = gdataset.Tables("SLCODE1").Rows(0).Item("CONCCCODE")
                            CONCCDESC = gdataset.Tables("SLCODE1").Rows(0).Item("CONCCDESC")
                            ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
                            ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
                            COSTCENTERCODE = gdataset.Tables("SLCODE1").Rows(0).Item("COSTCENTERCODE")
                            COSTCENTERDESC = gdataset.Tables("SLCODE1").Rows(0).Item("COSTCENTERDESC")
                        Else
                            MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                            Exit Sub
                        End If
                        If CONGLCODE = "" Then

                            MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
                            Exit Sub

                        End If
                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,COSTCENTERCODE,COSTCENTERDESC, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                        sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'', 'CONSUMPTION', '" & CONGLCODE & "',"
                        sqlstring = sqlstring & "'" & CONGLDESC & "',"
                        sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                        sqlstring = sqlstring & "'" & CONCCCODE & "','" & CONCCDESC & "',"
                        sqlstring = sqlstring & "'DEBIT',"
                        'amt = Format(Val(txt_Billamount.Text), "0.000")
                        decription = "Stock Consumption no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                        sqlstring = sqlstring & "'" & Format(AMT, "0.000") & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N','" + gUsername + "')"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring


                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,COSTCENTERCODE,COSTCENTERDESC, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                        sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'', 'CONSUMPTION', '" & ACCOUNTCODE & "',"
                        sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                        sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                        sqlstring = sqlstring & "'" & COSTCENTERCODE & "','" & COSTCENTERDESC & "',"
                        sqlstring = sqlstring & "'CREDIT',"
                        'amt = Format(Val(txt_Billamount.Text), "0.000")
                        decription = "Stock Consumption no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                        sqlstring = sqlstring & "'" & Format(AMT, "0.000") & "','" & decription & "',"

                        'slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N','" + gUsername + "')"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    End If


                End If

            End If
            End If



            gconnection.MoreTrans(Insert)

        If GBATCHNO = "Y" Then
            Dim strsql As String
            strsql = "update temp_batchdetails set qty= qty*-1 WHERE STORECODE= '" & TXT_FROMSTORECODE.Text & "' "
            gconnection.getDataSet(strsql, "updateminusqty")
            strsql = "insert into inv_Batchdetails(trnno,itemcode,uom,storecode,trndate,QTY,ttype,batchno,rate,expirydate)"
            strsql = strsql & " select Trnno,itemcode,uom,storecode,Trndate,qty,ttype,batchno,rate,expirydate from temp_batchdetails where trnno= '" & txt_Docno.Text & "'"
            gconnection.dataOperation(6, strsql, )
            strsql = "delete from temp_batchdetails "
            gconnection.dataOperation(6, strsql, )
        End If



    End Sub

    Private Sub updateoperation()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim AMT As Double
        Dim SEQ As Double


        sqlstring = "select * from stockConsumption_1 WHERE docno='" + Trim(CStr(txt_Docno.Text)) + "' and cast(convert(varchar(11),docdate,106)as datetime)='" & Format(Me.dtp_Docdate.Value, "dd/MMM/yyyy") & "'"
        gconnection.getDataSet(sqlstring, "backdate")
        If gdataset.Tables("backdate").Rows.Count > 0 Then

            'FOR LOG DATA
            sqlstring = "INSERT INTO stockConsumption_1LOG(Itemcode,Itemname,Uom,storecode,storedesc,docdate,adddate,adduser,stockinhand,physicalstock,consumption,"
            If GBATCHNO = "Y" Then
                sqlstring = sqlstring & "BatchNo,"
            End If
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "SHELF,"
            End If
            sqlstring = sqlstring & " rate,amount,Void,docno,doctype,remarks) "
            sqlstring = sqlstring & " SELECT Itemcode,Itemname,Uom,storecode,storedesc,docdate,adddate,adduser,stockinhand,physicalstock,consumption,"
            If GBATCHNO = "Y" Then
                sqlstring = sqlstring & "BatchNo,"
            End If
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "SHELF,"
            End If
            sqlstring = sqlstring & " rate,amount,Void,docno,doctype,remarks FROM stockConsumption_1 WHERE docno='" & Trim(txt_Docno.Text) & "'"
            gconnection.getDataSet(sqlstring, "stockConsumption_1LOG")


            'LOG DATA ENDS 



            sqlstring = "DELETE FROM stockConsumption_1 WHERE docno='" & Trim(txt_Docno.Text) & "' "
            ReDim Preserve insert(insert.Length)

            insert(insert.Length - 1) = sqlstring

            Dim sql1 As String



            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                Dim itemcode As String = AxfpSpread1.Text

                'sql1 = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
                'sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' AND ITEMCODE='" + itemcode + "'  "
                'gconnection.getDataSet(sql1, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '    SEQ = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
                'End If

                sqlstring = "INSERT INTO stockConsumption_1("
                sqlstring = sqlstring & " Itemcode,Itemname,Uom,storecode,storedesc,docdate,adddate,adduser,stockinhand,physicalstock,consumption,"
                If GBATCHNO = "Y" Then
                    sqlstring = sqlstring & "BatchNo,"
                End If
                If GSHELVING = "Y" Then
                    sqlstring = sqlstring & "SHELF,"
                End If
                sqlstring = sqlstring & " rate,amount,Void,docno,doctype,remarks)"



                sqlstring = sqlstring & "VALUES ( '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 2
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 3
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',getdate(),'" & Trim(gUsername) & "',"
                AxfpSpread1.Col = 4
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 5
                sqlstring = sqlstring & " " & Trim(AxfpSpread1.Text) & ","
                AxfpSpread1.Col = 6
                Dim qty1 As Double = Val(AxfpSpread1.Text)
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                If GBATCHNO = "Y" Then
                    AxfpSpread1.Col = 9
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                End If
                If GSHELVING = "Y" Then
                    AxfpSpread1.Col = 10
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                End If
                AxfpSpread1.Col = 7
                Dim rate As Double = Val(AxfpSpread1.Text)
                AMT = AMT + (qty1 * rate)
                sqlstring = sqlstring & " " & Trim(rate) & ","
                AxfpSpread1.Col = 8
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ",'N',"
                sqlstring = sqlstring & " '" & CStr(Trim(txt_Docno.Text)) & "','" + doctype1 + "','" & CStr(Trim(txt_Remarks.Text)) & "')"

                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring

                Dim qty As Double
                Dim batchyn As String
                Dim uom As String
                Dim uom1 As String
                Dim convvalue As Double
                Dim batchno As String

                AxfpSpread1.Col = 1
                itemcode = AxfpSpread1.Text

                AxfpSpread1.Col = 3
                uom1 = AxfpSpread1.Text
                'AxfpSpread1.Col = 5
                batchno = ""

                'sql1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
                'sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
                ''If (batchno <> "") Then
                ''    sql1 = sql1 & " and  batchno='" + batchno + "' "
                ''End If

                'gconnection.getDataSet(sql1, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '    qty = gdataset.Tables("closingqty").Rows(0).Item("qty")
                '    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                '    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                '    Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                '    convvalue = gconnection.getvalue(sql)
                'Else
                '    qty = 0
                '    convvalue = 1
                'End If

                'sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty) - (qty1 / convvalue)), "0.000") + ",qty=-" + Format(Val(qty1 / convvalue), "0.000") + ""
                'sql1 = sql1 & ",closingvalue=closingstock*" + Format(Val(rate), "0.000") + ""
                'sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
                ''If (batchyn = "Y") Then
                ''    sql1 = sql1 & "  and  batchno='" + batchno + "'"
                ''End If
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sql1

                'sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty) - (qty1 / convvalue)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty) - (qty1 / convvalue)), "0.000") + ""
                'sql1 = sql1 & ",closingvalue=closingstock*" + Format(Val(rate), "0.000") + ""
                'sql1 = sql1 & ",openningvalue=openningstock*" + Format(Val(rate), "0.000") + ""

                '',closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
                '',openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
                'sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
                ''If (batchyn = "Y") Then
                ''    sql1 = sql1 & "  and  batchno='" + txt_Docno.Text + "'"
                ''End If
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sql1

                'sqlstring = "    update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end  ,"
                'sqlstring = sqlstring & "  lastweightedrate="
                'sqlstring = sqlstring & "  case when openningvalue=0 then"
                'sqlstring = sqlstring & "      batchrate "
                'sqlstring = sqlstring & "   Else"
                'sqlstring = sqlstring & "  openningvalue/openningstock "
                'sqlstring = sqlstring & "     End"
                'sqlstring = sqlstring & "  from ratelist inner join CLOSINGQTY on ratelist.grnno=CLOSINGQTY.trnno where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "'"
                'sqlstring = sqlstring & "   and CLOSINGQTY.storecode='" + TXT_FROMSTORECODE.Text + "' and CLOSINGQTY.itemcode='" + itemcode + "'"
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sqlstring

            Next

            'If GACCPOST.ToUpper() = "Y" Then

            '    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Docno.Text) + "' AND VoucherType='CONSUMPTION'  "
            '    gconnection.dataOperation(6, sqlstring, )

            '    Dim CONGLCODE, CONGLDESC, ACCOUNTCODE, ACCOUNTDESC, CONCCCODE, CONCCDESC, COSTCENTERCODE, COSTCENTERDESC As String
            '    Dim decription As String
            '    sqlstring = "select CONGLCODE, CONGLDESC,CONCCCODE,CONCCDESC,ACCOUNTCODE,ACCOUNTDESC,COSTCENTERCODE,COSTCENTERDESC from ACCOUNTSTAGGINGNEW  WHERE "
            '    sqlstring = sqlstring & "CODE='" & TXT_FROMSTORECODE.Text & "' AND DESCRIPTION='" & txt_FromStorename.Text & "' AND  isnull(VOID,'')<>'Y'"
            '    gconnection.getDataSet(sqlstring, "SLCODE1")

            '    If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
            '        CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("CONGLCODE")
            '        CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("CONGLDESC")
            '        CONCCCODE = gdataset.Tables("SLCODE1").Rows(0).Item("CONCCCODE")
            '        CONCCDESC = gdataset.Tables("SLCODE1").Rows(0).Item("CONCCDESC")
            '        ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
            '        ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
            '        COSTCENTERCODE = gdataset.Tables("SLCODE1").Rows(0).Item("COSTCENTERCODE")
            '        COSTCENTERDESC = gdataset.Tables("SLCODE1").Rows(0).Item("COSTCENTERDESC")
            '    Else
            '        MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
            '        Exit Sub
            '    End If
            '    If CONGLCODE = "" Then

            '        MessageBox.Show("NO GL FOUND FOR STOCK POSTING...")
            '        Exit Sub

            '    End If
            '    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            '    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,COSTCENTERCODE,COSTCENTERDESC , CreditDebit, Amount,DESCRIPTION, VOID)"
            '    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
            '    sqlstring = sqlstring & "'', 'CONSUMPTION', '" & CONGLCODE & "',"
            '    sqlstring = sqlstring & "'" & CONGLDESC & "',"
            '    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
            '    sqlstring = sqlstring & "'" & CONCCCODE & "','" & CONCCDESC & "',"
            '    sqlstring = sqlstring & "'DEBIT',"
            '    'amt = Format(Val(txt_Billamount.Text), "0.000")
            '    decription = "Stock Consumption no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
            '    sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

            '    'slcode = txt_Storecode.Text
            '    sqlstring = sqlstring & "'N')"
            '    ReDim Preserve insert(insert.Length)
            '    insert(insert.Length - 1) = sqlstring


            '    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            '    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,COSTCENTERCODE,COSTCENTERDESC, CreditDebit, Amount,DESCRIPTION, VOID)"
            '    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
            '    sqlstring = sqlstring & "'', 'CONSUMPTION', '" & ACCOUNTCODE & "',"
            '    sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
            '    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
            '    sqlstring = sqlstring & "'" & COSTCENTERCODE & "','" & COSTCENTERDESC & "',"
            '    sqlstring = sqlstring & "'CREDIT',"
            '    'amt = Format(Val(txt_Billamount.Text), "0.000")
            '    decription = "Stock Consumption no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
            '    sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

            '    'slcode = txt_Storecode.Text
            '    sqlstring = sqlstring & "'N')"
            '    ReDim Preserve insert(insert.Length)
            '    insert(insert.Length - 1) = sqlstring


            'End If


            gconnection.MoreTrans(insert)

            'For k As Integer = 1 To AxfpSpread1.DataRowCnt
            '    AxfpSpread1.Row = k
            '    AxfpSpread1.Col = 1

            '    sql1 = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
            '    sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' and itemcode='" & AxfpSpread1.Text & "' "
            '    gconnection.getDataSet(sql1, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '        SEQ = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
            '    End If

            '    gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, SEQ)

            'Next
        Else
            voidoperationupdate()
            addoperation()
        End If
    End Sub

    Private Sub voidoperationupdate()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim i As Integer
        'Dim seq As Double
        'sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        'sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
        'gconnection.getDataSet(sqlstring, "closingqty")
        'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '    seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        'End If
        sqlstring = "delete from  stockConsumption_1  where docno='" & Trim(txt_Docno.Text) & "'"
        'sqlstring = "UPDATE  stockConsumption_1 set void='Y' WHERE docno='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring

        
        If (GACCPOST.ToUpper() = "Y") Then

            'sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Docno.Text) + "'"
            sqlstring = "delete from  JOURNALENTRY  where VoucherNo='" & Trim(txt_Docno.Text) & "' AND  VoucherType='CONSUMPTION'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

        End If
        gconnection.MoreTrans1(insert)

    End Sub

    Private Sub voidoperation()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim i As Integer
        Dim seq As Double
 
        sqlstring = "UPDATE  stockConsumption_1 set void='Y' WHERE docno='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring

        If (GACCPOST.ToUpper() = "Y") Then

            sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Docno.Text) + "' AND VoucherType='CONSUMPTION'  "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

        End If
        gconnection.MoreTrans(insert)

        If GBATCHNO = "Y" Then
            Dim strsql As String
            strsql = "delete from inv_Batchdetails where trnno= '" & Trim(txt_Docno.Text) & "'  "
            gconnection.dataOperation(6, strsql, )
        End If

    End Sub
    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String
        Dim closingval As Double

        If e.keyCode = Keys.F1 Then
            Dim search As New frmSearch
            search.farPoint = AxfpSpread1
            search.Text = "Item Search"
            search.ShowDialog(Me)
            Exit Sub
        End If


        If e.keyCode = Keys.Enter Then
            i = AxfpSpread1.ActiveRow
            'ITEMCODE
            AxfpSpread1.Row = i

            'If AxfpSpread1.ActiveCol = 1 And AxfpSpread1.Lock = False Then
            If AxfpSpread1.ActiveCol = 1 Then

                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) = "" Then


                    binditemcode()
                Else

                    SQL = " select I.itemcode,Itemname,uom,batchprocess,m.category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If Cmd_Add.Text <> "Update[F7]" Then
                            If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then
                                AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                                AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                                AxfpSpread1.Col = 3
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow

                                SQL = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                                gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom")).ToUpper()
                                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom")).ToUpper()
                                Next Z
                                AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")).ToUpper())
                                Dim convvalue As Double

                                AxfpSpread1.Col = 3

                                Dim uom As String = AxfpSpread1.Text
                                Dim uom1 As String
                                Dim itemcode As String
                                AxfpSpread1.Col = 1
                                itemcode = AxfpSpread1.Text
                                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                                Dim sql11 As String ' = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"

                                If Mid(Cmd_Add.Text, 1, 1) = "A" Then
                                    gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                                Else
                                    sql11 = "SELECT * FROM StockConsumption_1 WHERE ITEMCODE='" + itemcode + "' AND DOCNO='" + txt_Docno.Text + "'"
                                    gconnection.getDataSet(sql11, "CHECK")
                                    If (gdataset.Tables("CHECK").Rows.Count > 0) Then
                                        gconnection.oPENINGStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                                    Else
                                        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                                    End If

                                End If

                                'gconnection.getDataSet(sql11, "closingtable")
                                Dim closingqty, Rate As Double
                                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                    Rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                                Else
                                    closingqty = 0
                                    Rate = 0
                                End If
                                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom1 + "'"
                                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                                Else
                                    convvalue = 1
                                End If

                                closingqty = Format(closingqty * convvalue, "0.000")
                                AxfpSpread1.SetText(3, AxfpSpread1.ActiveRow, uom1)

                                AxfpSpread1.SetText(4, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))
                                AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(Rate / convvalue), "0.000"))
                                'If GBATCHNO = "Y" Then
                                '    AxfpSpread1.SetActiveCell(9, AxfpSpread1.ActiveRow)
                                'Else
                                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                                ' End If
                            End If
                        End If
                    End If


                    'Else
                End If
            ElseIf AxfpSpread1.ActiveCol = 3 Then
                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
            ElseIf AxfpSpread1.ActiveCol = 5 Then

                AxfpSpread1.Col = 5
                closingval = Format(Val(AxfpSpread1.Text), "0.000")
                AxfpSpread1.Col = 4
                Dim STINH As Double = Format(Val(AxfpSpread1.Text), "0.000")
                If closingval > STINH Then
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Text = ""
                    MsgBox("Physical can't be greater than Stock in hand")
                    Exit Sub

                Else
                    Dim RATE As Double = 0
                    AxfpSpread1.Col = 7
                    RATE = AxfpSpread1.Text
                    AxfpSpread1.Col = 6
                    AxfpSpread1.Text = Format(Val(STINH - closingval), "0.000")
                    AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(RATE * Val(AxfpSpread1.Text)), "0.000"))
                    If AUTOFILL = True Then
                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow + 1)
                    Else
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                    End If


                End If
            ElseIf AxfpSpread1.ActiveCol = 6 Then

                AxfpSpread1.Col = 6
                closingval = Format(Val(AxfpSpread1.Text), "0.00")
                AxfpSpread1.Col = 4
                Dim STINH As Double = Val(Trim(AxfpSpread1.Text))
                If closingval > Val(Trim(AxfpSpread1.Text)) Then
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Text = ""
                    MsgBox("Physical can't be greater than Stock in hand")
                    Exit Sub

                Else
                    Dim RATE As Double = 0
                    AxfpSpread1.Col = 7
                    RATE = AxfpSpread1.Text
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Text = Format(Val(STINH - closingval), "0.00")
                    AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(RATE * Val(closingval)), "0.000"))

                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
                End If
            ElseIf AxfpSpread1.ActiveCol = 9 Then
                ''If GBATCHNO = "Y" Then
                ''    AxfpSpread1.Col = 9
                ''    BatchNoSelection()
                ''End If
                'AxfpSpread1.Col = 3
                'Dim uom As String = AxfpSpread1.Text
                'AxfpSpread1.Col = 1
                'Dim itemcode As String = AxfpSpread1.Text
                'AxfpSpread1.Col = 9
                'Dim Batchno As String = AxfpSpread1.Text
                'Dim convvalue As Double
                'Dim sql11 As String
                'gconnection.BatchWiseClosingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), Batchno)
                'Dim closingqty, rate As Double
                'If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                '    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                '    rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                'Else
                '    closingqty = 0
                '    rate = 0
                'End If
                'Dim uom1 As String = gdataset.Tables("closingstock").Rows(0).Item("uom")
                'sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom1 + "'"
                'gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                'If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                'Else
                '    convvalue = 0
                'End If
                'closingqty = closingqty * convvalue
                'AxfpSpread1.SetText(3, AxfpSpread1.ActiveRow, uom1)
                'AxfpSpread1.SetText(4, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))
                'AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(rate / convvalue), "0.000"))
                'AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
            End If
        ElseIf AxfpSpread1.ActiveCol = 10 Then
            If GSHELVING = "Y" Then
                AxfpSpread1.Col = 10
                Fromshelf()
            End If

        ElseIf e.keyCode = Keys.F3 Then
            'If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
            'End If
        End If
        'ITEMNAME
    End Sub
    Private Sub Fromshelf()
        Dim vform As New ListOperattion1
        gSQLString = "SELECT distinct Shelfcode,ShelfDesc FROM InventoryShelfMaster"
        M_WhereCondition = " WHERE STORECODE='" + TXT_FROMSTORECODE.Text + "' AND ISNULL(FREEZE,'')<>'Y' "
        'M_Groupby = " c.itemcode,i.itemname,c.batchno "
        M_ORDERBY = " Shelfcode "
        vform.Field = " Shelfcode,ShelfDesc"
        vform.vFormatstring = "    Shelf code    |   Shelf Desc      "
        vform.vCaption = "Shelf Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_Duplicate(vform.keyfield) = False) Then
                AxfpSpread1.Col = 10
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.SetActiveCell(10, 1)
                AxfpSpread1.Focus()
            Else
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If
        End If
    End Sub
    Private Sub BatchNoSelection()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue, itemcode As String
        Dim myValue As Object
        message = "Enter Batch No"
        title = "Batch No"
        AxfpSpread1.Col = 1
        AxfpSpread1.Row = AxfpSpread1.ActiveRow
        itemcode = AxfpSpread1.Text
        gSQLString = "select  DISTINCT c.itemcode,i.itemname,c.batchno from INV_InventoryItemMaster i inner join  closingqty c  on "
        gSQLString = gSQLString & " i.itemcode=c.itemcode "
        M_WhereCondition = " where i.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(i.void,'')='N' and isnull(c.storecode,'')='" + TXT_FROMSTORECODE.Text + "'  and isnull(c.batchno,'') <>'' and c.itemcode ='" + itemcode + "' "
        'M_Groupby = " c.itemcode,i.itemname,c.batchno "
        M_ORDERBY = " c.itemcode "
        vform.Field = " c.itemcode,i.itemname,c.batchno"
        vform.vFormatstring = "    Itemcode    |                       Itemname                  |   batchno      |  QTY  "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            AxfpSpread1.Col = 9
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield2)
            AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
            AxfpSpread1.Focus()
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

    Private Sub Frm_stockConsumptionNew_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub Frm_stockConsumptionNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        doctype1 = "CON"
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        ' Call Resize_Form()
        ' Me.DoubleBuffered = True
        autogenerate()
        sqlstring = "Select getdate()"
        condate = gconnection.getvalue(sqlstring)
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        'Me.Cursor = Cursors.WaitCursor
        'Call Check()
        'Me.Cursor = Cursors.Default
        Dim thr As New Thread(Sub() Check())
        thr.Start()

    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "Stock Consumption"

        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME = '" & Trim(GmoduleName) & "' ORDER BY RIGHTS"
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


                Dim ITEMCODE, sqlstring As String
                Dim I As Integer
                Dim items As String
                items = ""

                Dim dtitem As New DataTable
                dtitem.Columns.Add("itemcode")
                dtitem.TableName = "TpItems"

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
                sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "loccode")
                If gdataset.Tables("loccode").Rows.Count > 0 Then
                    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                Else
                    loccode = "M"
                End If
                If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "CONSUMPTION")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "CONSUMPTION")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If

                sqlstring = " exec proc_closingqtyone 'CONSUMPTION_ADD' "
                gconnection.ExcuteStoreProcedure(sqlstring)
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)

                Clearoperation()
            End If
        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
            If validateonupdate() = False Then
                updateoperation()
                Dim ITEMCODE, sqlstring As String
                Dim I As Integer
                Dim items As String
                items = ""

                Dim dtitem As New DataTable
                dtitem.Columns.Add("itemcode")
                dtitem.TableName = "TpItems"

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
                sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "loccode")
                If gdataset.Tables("loccode").Rows.Count > 0 Then
                    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                Else
                    loccode = "M"
                End If
                If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "CONSUMPTION")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "CONSUMPTION")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If
                sqlstring = " exec proc_closingqtyone 'CONSUMPTION_UPDATE' "
                gconnection.ExcuteStoreProcedure(sqlstring)

                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)

                Clearoperation()
            End If
        End If

        If MsgBox("DO U Want to Manual Update Stock......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
            Me.Cursor = Cursors.WaitCursor
            If Mid(UCase(gShortname), 1, 5) = "RSAOI" Or Mid(UCase(gShortname), 1, 3) = "MLA" Or Mid(UCase(gShortname), 1, 3) = "CTC" Or Mid(UCase(gShortname), 1, 4) = "JHIC" Or Mid(UCase(gShortname), 1, 4) = "SATC" Then
                CALC_WEIGHTEDRSI()
            Else
                CALC_WEIGHTED()
                'CALC_WEIGHTEDRSI()
            End If
            If gShortname = "HGA" Then
                Dim sqlstring As String
                sqlstring = "  exec passinvntoryunmatchedentries "
                gconnection.ExcuteStoreProcedure(sqlstring)
            End If
            MsgBox("Stock Manual Updation Completed....")
            Me.Cursor = Cursors.Default
        Else
            MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
        End If

    End Sub



    Private Function validateoninsert() As Boolean
        Dim flag As Boolean

        Dim checkBdate As Boolean
        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
        'Else
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
        'End If
        Dim bdate1 As String
        Dim sql1 As String

        sql1 = "select convert(varchar(11),bdate,106) as bdate1 from Businessdate"
        gconnection.getDataSet(sql1, "Businessdate")

        If (gdataset.Tables("Businessdate").Rows.Count > 0) Then
            bdate1 = "Your current Business date is " & gdataset.Tables("Businessdate").Rows(0).Item("bdate1").ToString
        End If
        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
        If checkBdate = True And RESU1 = False Then
            MsgBox(bdate1)
            flag = True
            Return flag
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
            flag = True
            Return flag
        End If
        If DateDiff(DateInterval.Day, (CDate(dtp_Docdate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("Doc. DATE cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        Dim sql As String
        '   If Mid(UCase(Trim(gShortname)), 1, 3) <> "SAT" Then
        'sql = "select * from stockConsumption_1  where CONVERT(VARCHAR(11), docdate, 111)>'" & Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd") & "' and Storecode='" & TXT_FROMSTORECODE.Text & "' and isnull(void,'')<>'Y'"
        'gconnection.getDataSet(sql, "stockConsumption_1")
        'If (gdataset.Tables("stockConsumption_1").Rows.Count > 0) Then
        '    MessageBox.Show("Doc. Date cannot be less than last Consumption Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    flag = True
        '    Return flag

        'End If
        '  Else
        sql = "select * from stockConsumption_1  where cast(docdate as date)>'" & Format(dtp_Docdate.Value, "dd MMM yyyy") & "' and Storecode='" & TXT_FROMSTORECODE.Text & "' and isnull(void,'')<>'Y' and remarks<>'Auto Consumption in Issue time'"
        gconnection.getDataSet(sql, "stockConsumption_1")
            If (gdataset.Tables("stockConsumption_1").Rows.Count > 0) Then
                MessageBox.Show("Doc. Date cannot be less than last Consumption Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            '                flag = True
            '           Return flag

        End If
        '  End If


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

            AxfpSpread1.Row = j + 1
            AxfpSpread1.Col = 6
            'AxfpSpread1.Col = 1
            If (Val(AxfpSpread1.Text) <> 0) Then
                Dim issuedqty As Double = Val(AxfpSpread1.Text)
                'Dim sql As String
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
                        ' Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trns_seq desc"

                        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")


                        '   gconnection.getDataSet(sql11, "closingtable")
                        Dim closingqty As Double
                        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                            ' closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")
                            closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                            uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                        Else
                            uom1 = uom
                            closingqty = 0
                        End If

                        sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                        gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                        Dim convvalue As Double
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                        Else
                            MessageBox.Show(" Make conversion factor between " + uom1 + " and  " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag
                            convvalue = 0
                        End If

                        closingqty = closingqty * convvalue
                        sql = "select closingstock +" + Format(Val(-((issuedqty / convvalue))), "0.000") + " from closingqty where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
                        sql = sql & "and closingstock +" + Format(Val(-((issuedqty / convvalue))), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "'"
                        'If batchyn = "Y" Then
                        '    sql = sql & " and batchno='" + batchno + "'"
                        'End If
                        gconnection.getDataSet(Sql, "closingqty")
                        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                            MessageBox.Show("Consumption  create " + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag
                        End If
                        If ((issuedqty) > Format(Val(closingqty), "0.000")) Then
                            MessageBox.Show("Consume Quantity Cannot be Greater than Closing Quantity " + closingqty.ToString() + " For Itemcode=" + itemcode)
                            flag = True
                            Return flag



                        End If
                    End If

                End If
            End If
        Next

        For j As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            If AxfpSpread1.Text = "" Then
                MessageBox.Show("Item Code Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(1, j)

                flag = True
                Return flag
            End If
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 2
            If AxfpSpread1.Text = "" Then
                MessageBox.Show("Item Name Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(2, j)

                flag = True
                Return flag
            End If
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 3
            If AxfpSpread1.Text = "" Then
                MessageBox.Show("UOM Can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(3, j)

                flag = True
                Return flag
            End If
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 6
            If AxfpSpread1.Text = "" Or Val(AxfpSpread1.Text) <= 0 Then
                MessageBox.Show("Quantity can't be blank or Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(4, j)

                flag = True
                Return flag
            End If
        Next


        If (GACCPOST.ToUpper() = "Y") Then
            If UCase(gShortname) <> "HIND" Then
                Dim accode, TRNCODE As String
                If gAcPostingWise = "ITEM" Then
                    For k As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = k
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("CONGLCODE")
                                If accode = "" Or TRNCODE = "" Then

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

                    For k As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = k
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "select accountcode,CONGLCODE,AC.CategoryCode  from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category WHERE IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("CONGLCODE")
                                If accode = "" Or TRNCODE = "" Then

                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(gdataset.Tables("CODE").Rows(0).Item("CategoryCode")) + " FOR ITEMCODE='" + Trim(AxfpSpread1.Text) + "'")
                                    flag = True
                                    Return flag

                                End If
                            Else
                                MessageBox.Show("NO CATEGORY FOUND FOR ITEMCODE='" + Trim(AxfpSpread1.Text) + "'")
                                flag = True
                                Return flag
                            End If
                        End If

                    Next



                Else
                    sqlstring = "Select * from AccountstaggingnEW where CODE='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                        TRNCODE = gdataset.Tables("CODE").Rows(0).Item("CONGLCODE")
                        If accode = "" Or TRNCODE = "" Then

                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE  " + Trim(TXT_FROMSTORECODE.Text) + "")
                            flag = True
                            Return flag

                        End If
                    Else
                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE " + Trim(TXT_FROMSTORECODE.Text) + "")
                        flag = True
                        Return flag
                    End If

                End If
            End If
        End If



            Return False
    End Function

    Private Function validateonupdate() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), txt_FromStorename.Text)
        'Else
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
        'End If

        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
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
        If DateDiff(DateInterval.Day, (CDate(dtp_Docdate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("Doc. Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = i + 1

            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 6
            Dim qty As String = Val(AxfpSpread1.Text)
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim convvalue As Double
            Dim batchno As String
            AxfpSpread1.Col = 6
            batchno = ""
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
            sql = "select closingstock +" + Format(Val(-(qty / convvalue) - qty1), "0.000") + " from closingqty where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(-(qty / convvalue) - qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' AND ITEMCODE= '" + itemcode + "' "
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show(" Updation create   " + itemcode + " Stock  Negative in  " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If


        Next
        'For j As Integer = 0 To AxfpSpread1.DataRowCnt - 1
        '    AxfpSpread1.Col = 6
        '    If (Val(AxfpSpread1.Text) <> 0) Then
        '        Dim issuedqty As Double = Val(AxfpSpread1.Text)
        '        Dim sql As String
        '        AxfpSpread1.Col = 1
        '        Dim itemcode As String = AxfpSpread1.Text
        '        sql = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
        '        gconnection.getDataSet(sql, "INV_InventoryItemMaster")
        '        If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
        '            If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
        '                AxfpSpread1.Col = 3
        '                Dim uom As String = AxfpSpread1.Text
        '                Dim uom1 As String
        '                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
        '                Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and cast(trndate as date)<cast('" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' as date) order by trns_seq desc"


        '                gconnection.getDataSet(sql11, "closingtable")
        '                Dim closingqty As Double
        '                If (gdataset.Tables("closingtable").Rows.Count > 0) Then
        '                    closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")
        '                    uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
        '                Else
        '                    closingqty = 0
        '                    uom1 = uom
        '                End If

        '                sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
        '                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
        '                Dim convvalue As Double
        '                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
        '                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

        '                Else
        '                    convvalue = 0
        '                End If
        '                closingqty = closingqty * convvalue
        '                If (issuedqty > closingqty) Then
        '                    'MessageBox.Show("Consume Quantity Cannot be Greater than Closing Quantity " + closingqty.ToString() + " For Itemcode :" + itemcode)
        '                    'flag = True
        '                    'Return flag



        '                End If
        '            End If

        '        End If



        '    End If
        'Next

        If (GACCPOST.ToUpper() = "Y") Then
            If UCase(gShortname) <> "HIND" Then
                Dim accode, TRNCODE As String
                If gAcPostingWise = "ITEM" Then
                    For k As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = k
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("CONGLCODE")
                                If accode = "" Or TRNCODE = "" Then

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

                    For k As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = k
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "select accountcode,CONGLCODE,AC.CategoryCode  from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category WHERE IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("CONGLCODE")
                                If accode = "" Or TRNCODE = "" Then

                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(gdataset.Tables("CODE").Rows(0).Item("CategoryCode")) + " FOR ITEMCODE='" + Trim(AxfpSpread1.Text) + "'")
                                    flag = True
                                    Return flag

                                End If
                            Else
                                MessageBox.Show("NO CATEGORY FOUND FOR ITEMCODE='" + Trim(AxfpSpread1.Text) + "'")
                                flag = True
                                Return flag
                            End If
                        End If

                    Next

                Else
                    sqlstring = "Select * from AccountstaggingnEW where CODE='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                        TRNCODE = gdataset.Tables("CODE").Rows(0).Item("CONGLCODE")
                        If accode = "" Or TRNCODE = "" Then

                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE  " + Trim(TXT_FROMSTORECODE.Text) + "")
                            flag = True
                            Return flag

                        End If
                    Else
                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE " + Trim(TXT_FROMSTORECODE.Text) + "")
                        flag = True
                        Return flag
                    End If

                End If
            End If
        End If


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
            'sql = "select closingstock +" + Format(Val(-qty1), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            'sql = sql & "and closingstock +" + Format(Val(-qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
            'If batchyn = "Y" Then
            '    sql = sql & " and batchno='" + batchno + "'"
            'End If
            'gconnection.getDataSet(sql, "closingqty")
            'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '    MessageBox.Show("Deletion create" + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    flag = True
            '    Return flag
            'End If

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

                Dim ITEMCODE, sqlstring As String
                Dim I As Integer
                Dim items As String
                items = ""

                Dim dtitem As New DataTable
                dtitem.Columns.Add("itemcode")
                dtitem.TableName = "TpItems"


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
                sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "loccode")
                If gdataset.Tables("loccode").Rows.Count > 0 Then
                    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                Else
                    loccode = "M"
                End If
                If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "CONSUMPTION")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "CONSUMPTION")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If

                sqlstring = " exec proc_closingqtyone 'CONSUMPTION_VOID' "
                gconnection.ExcuteStoreProcedure(sqlstring)
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)

                Clearoperation()




            End If
        End If
    End Sub

    Private Sub cmd_Docnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Docnohelp.Click
        Try

            gSQLString = "SELECT distinct  ISNULL(DOCNO,'') AS DOCNO,DOCDATE,ISNULL(VOID,'N') AS VOID FROM StockConsumption_1"
            M_WhereCondition = ""
            M_ORDERBY = " order by docno desc, DOCDATE desc ,VOID"
            Dim vform As New List_Operation
            vform.Field = "DOCNO,DOCDATE"
            vform.vFormatstring1 = "       DOC NO.            |            DOC DATE           |       VOID     "
            vform.vCaption = "STOCK CONSUMTION HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Docno.Text = Trim(vform.keyfield & "")
                Call txt_Docno_Validated(txt_Docno, e)
                'Grid_lock()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Function Grid_lock()
        Dim i, j As Integer
        For i = 1 To 100
            AxfpSpread1.Row = i
            For j = 1 To AxfpSpread1.MaxCols
                If j = 5 Then

                Else
                    AxfpSpread1.Col = j
                    AxfpSpread1.Lock = True


                End If
            Next
        Next
    End Function

    Private Sub txt_Docno_Validated(sender As Object, e As EventArgs) Handles txt_Docno.Validated
        Dim vString, sqlstring, Stritemcode As String
        Dim Clsquantity As Double
        Dim dt As New DataTable
        Dim j, i As Integer
        If Trim(txt_Docno.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(DOCNO,'') AS DOCNO,DOCDATE,ISNULL(STORECODE,'') AS STORECODE, "
                sqlstring = sqlstring & " ISNULL(StoreDESC,'') AS StoreDESC,"
                sqlstring = sqlstring & " ISNULL(REMARKS,'') AS REMARKS,ISNULL(VOID,'') AS VOID ,ADDDATE FROM StockConsumption_1 "
                sqlstring = sqlstring & " WHERE  (DOCNO='" & Trim(txt_Docno.Text) & "')"
                gconnection.getDataSet(sqlstring, "StockConsumption_1")
                '''************************************************* SELECT RECORD FROM STOCKADJUSTHEADER *********************************************''''                
                If gdataset.Tables("StockConsumption_1").Rows.Count > 0 Then
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Docno.ReadOnly = True
                    txt_Docno.Text = Trim(gdataset.Tables("StockConsumption_1").Rows(0).Item("DOCNO"))
                    dtp_Docdate.Value = Format(CDate(gdataset.Tables("StockConsumption_1").Rows(0).Item("DOCDATE")), "dd/MMM/yyyy")
                    txt_Remarks.Text = Trim(gdataset.Tables("StockConsumption_1").Rows(0).Item("REMARKS") & "")
                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("StockConsumption_1").Rows(0).Item("STORECODE"))
                    txt_FromStorename.Text = Trim(gdataset.Tables("StockConsumption_1").Rows(0).Item("StoreDESC"))
                    If gdataset.Tables("StockConsumption_1").Rows(0).Item("VOID") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("StockConsumption_1").Rows(0).Item("ADDDATE")), "dd/MMM/yyyy")
                        Me.Cmd_Freeze.Enabled = False
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.Cmd_Freeze.Enabled = True
                        Me.lbl_Freeze.Text = "Record Void  On "
                        Me.Cmd_Freeze.Text = "Void[F8]"
                        Me.btn_Auto_fill.Enabled = False
                        Me.Cmd_Add.Enabled = True
                        Me.Cmd_Freeze.Enabled = True
                    End If

                    If GBATCHNO = "Y" Then
                        sqlstring = "SELECT D.DOCDATE AS DOCDATE,ISNULL(D.STORECODE,'') AS STORELOCATIONCODE,  "
                        sqlstring = sqlstring & " ISNULL(D.STOREDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.batchno,'') AS batchno,"
                        sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,isnull(stockinhand,0) AS stockinhand,ISNULL(d.physicalstock,0) AS physicalstock, "
                        If GSHELVING = "Y" Then
                            sqlstring = sqlstring & "SHELF,"
                        End If

                        sqlstring = sqlstring & " isnull(d.consumption,0) as consumer,isnull(stockinhand,0) as closingqty,isnull(c.rate/CONVVALUE,0) as rate,isnull(isnull(d.consumption,0)*isnull(c.rate/CONVVALUE,0),0) as amount "
                        sqlstring = sqlstring & "  FROM StockConsumption_1 AS D inner join closingqty c on d.docno=c.Trnno and d.itemcode=c.itemcode and d.storecode=c.storecode  AND C.BATCHNO=D.BATCHNO  inner join INVENTORY_TRANSCONVERSION t on t.BASEUOM=c.uom and t.TRANSUOM=d.uom   WHERE ISNULL(D.DOCNO,'')='" & Trim(txt_Docno.Text) & "'"
                    Else
                        sqlstring = "SELECT D.DOCDATE AS DOCDATE,ISNULL(D.STORECODE,'') AS STORELOCATIONCODE,  "
                        sqlstring = sqlstring & " ISNULL(D.STOREDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
                        sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(c.openningstock*CONVVALUE,0) AS stockinhand,ISNULL(d.physicalstock,0) AS physicalstock, "
                        If GSHELVING = "Y" Then
                            sqlstring = sqlstring & "SHELF,"
                        End If
                        sqlstring = sqlstring & " isnull(d.consumption,0) as consumer,isnull(stockinhand,0) as closingqty,isnull(c.rate/CONVVALUE,0) as rate,isnull(isnull(d.consumption,0)*isnull(c.rate/CONVVALUE,0),0) as amount "
                        sqlstring = sqlstring & "  FROM StockConsumption_1 AS D inner join closingqty c on d.docno=c.Trnno and d.itemcode=c.itemcode and d.storecode=c.storecode inner join INVENTORY_TRANSCONVERSION t on t.BASEUOM=c.uom and t.TRANSUOM=d.uom   WHERE ISNULL(D.DOCNO,'')='" & Trim(txt_Docno.Text) & "'"
                    End If

                    If UCase(gShortname) <> "CCL" Then

                    Else
                        sqlstring = sqlstring & " union all "
                        sqlstring = sqlstring & " SELECT ''AS DOCDATE,storecode AS STORELOCATIONCODE, '' AS STORELOCATIONDESC, C.ITEMCODE,itemname,UOM,closingstock as stockinhand,0 as physicalstock,closingstock as consumer,closingstock as closingqty,  "
                        sqlstring = sqlstring & " rate,closingstock*rate as amount FROM CLOSINGQTY C INNER JOIN INV_InventoryItemMaster  "
                        sqlstring = sqlstring & " IV ON IV.itemcode=C.itemcode WHERE storecode='" & TXT_FROMSTORECODE.Text & "' AND CAST( TRNDATE AS DATE)<= CAST('" & Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd") & "' AS DATE)  "
                        sqlstring = sqlstring & " AND CAST(TRNS_SEQ AS CHAR)+CAST(C.itemcode AS CHAR) IN (SELECT CAST(MAX(TRNS_SEQ) AS CHAR)+ CAST(itemcode AS CHAR) FROM CLOSINGQTY  "
                        sqlstring = sqlstring & "  WHERE  storecode='" & TXT_FROMSTORECODE.Text & "' AND CAST( TRNDATE AS DATE)<= CAST('" & Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd") & "' AS DATE) and itemcode not in (select itemcode from StockConsumption_1 where DOCNO='" & Trim(txt_Docno.Text) & "' ) GROUP BY itemcode) AND ISNULL(CLOSINGSTOCK,0)>0  "

                    End If
                    
                    gconnection.getDataSet(sqlstring, "StockConsumption_1")

                    If gdataset.Tables("StockConsumption_1").Rows.Count > 0 Then
                        For i = 0 To gdataset.Tables("StockConsumption_1").Rows.Count - 1

                            AxfpSpread1.Row = i + 1
                            AxfpSpread1.SetText(1, i + 1, Trim(gdataset.Tables("StockConsumption_1").Rows(i).Item("ITEMCODE")))
                            Stritemcode = Trim(gdataset.Tables("StockConsumption_1").Rows(i).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, i + 1, Trim(gdataset.Tables("StockConsumption_1").Rows(i).Item("ITEMNAME")))
                            Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("StockConsumption_1").Rows(i).Item("itemcode") + "'"

                            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                AxfpSpread1.Col = 3
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z

                            AxfpSpread1.SetText(3, i + 1, Trim(gdataset.Tables("StockConsumption_1").Rows(i).Item("UOM")))
                            AxfpSpread1.SetText(4, i + 1, Format(Val(gdataset.Tables("StockConsumption_1").Rows(i).Item("stockinhand")), "0.000"))
                            AxfpSpread1.SetText(6, i + 1, Format(Val(gdataset.Tables("StockConsumption_1").Rows(i).Item("stockinhand")) - Val(gdataset.Tables("StockConsumption_1").Rows(i).Item("physicalstock")), "0.000"))
                            AxfpSpread1.SetText(5, i + 1, Format(Val(gdataset.Tables("StockConsumption_1").Rows(i).Item("physicalstock")))) '- Val(gdataset.Tables("StockConsumption_1").Rows(i).Item("consumer"))), "0.000"))
                            If GSHELVING = "Y" Then
                                AxfpSpread1.Col = 10
                                AxfpSpread1.Row = i
                                AxfpSpread1.SetText(10, i, Trim(gdataset.Tables("StockConsumption_1").Rows(j).Item("SHELF")))
                            End If
                            AxfpSpread1.SetText(7, i + 1, Format(Val(gdataset.Tables("StockConsumption_1").Rows(i).Item("rate")), "0.000"))
                            AxfpSpread1.SetText(8, i + 1, Format(Val(gdataset.Tables("StockConsumption_1").Rows(i).Item("amount")), "0.000"))
                            If GBATCHNO = "Y" Then
                                AxfpSpread1.SetText(9, i + 1, Trim(gdataset.Tables("StockConsumption_1").Rows(i).Item("batchno")))
                            End If


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
            sqlstring = "SELECT DOCDATE,ISNULL(STORECODE,'') AS STORECODE,"
            sqlstring = sqlstring & " ISNULL(STOREDESC,'') AS STOREDESC ,"
            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(STOCKINHAND,0) AS qty,ISNULL(consumption,0) AS consumer,ISNULL(REMARKS,'') AS REMARKS "
            sqlstring = sqlstring & " ,isnull(itemname,'') as itemname,docno,consumption,rate,amount FROM StockConsumption_1"
            sqlstring = sqlstring & " WHERE DOCNO ='" & Trim(txt_Docno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY DOCDATE"

            gconnection.getDataSet(sqlstring, "StockConsumption_1")
            If gdataset.Tables("StockConsumption_1").Rows.Count > 0 Then
                'If chk_excel.Checked = True Then
                '    Dim exp As New exportexcel
                '    exp.Show()
                '    Call exp.export(sqlstring, "STOCK DAMAGE ", "")
                'Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "StockConsumption_1"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                Dim textobj11 As TextObject
                textobj11 = r.ReportDefinition.ReportObjects("Text15")
                textobj11.Text = UCase(Address1)
                Dim textobj12 As TextObject
                textobj12 = r.ReportDefinition.ReportObjects("Text16")
                textobj12.Text = UCase(Address2)
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
            Dim r As New Crystkcon
            sqlstring = "SELECT DOCDATE,ISNULL(STORECODE,'') AS STORECODE,"
            sqlstring = sqlstring & " ISNULL(STOREDESC,'') AS STOREDESC ,"
            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(STOCKINHAND,0) AS qty,ISNULL(consumption,0) AS consumer,ISNULL(REMARKS,'') AS REMARKS "
            sqlstring = sqlstring & "  ,isnull(itemname,'') as itemname,docno,consumption,rate,amount FROM StockConsumption_1"
            sqlstring = sqlstring & " WHERE DOCNO ='" & Trim(txt_Docno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY DOCDATE"

            gconnection.getDataSet(sqlstring, "StockConsumption_1")
            If gdataset.Tables("StockConsumption_1").Rows.Count > 0 Then
                'If chk_excel.Checked = True Then
                '    Dim exp As New exportexcel
                '    exp.Show()
                '    Call exp.export(sqlstring, "STOCK DAMAGE ", "")
                'Else  Docdetails1
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "StockConsumption_1"

                'Dim textobj15 As TextObject
                'textobj15 = r.ReportDefinition.ReportObjects("Docdetails1")
                'textobj15.Text = Trim(txt_Docno.Text)

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                Dim textobj11 As TextObject
                textobj11 = r.ReportDefinition.ReportObjects("Text15")
                textobj11.Text = UCase(Address1)
                Dim textobj12 As TextObject
                textobj12 = r.ReportDefinition.ReportObjects("Text16")
                textobj12.Text = UCase(Address2)
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

    Private Sub AxfpSpread1_KeyUpEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyUpEvent) Handles AxfpSpread1.KeyUpEvent
        Dim i As Integer
        i = AxfpSpread1.ActiveRow
        'ITEMCODE
        Dim closingval1, STOCKINHAND As Double
        AxfpSpread1.Row = i

        If AxfpSpread1.ActiveCol = 5 Then


            AxfpSpread1.Col = 5
            closingval1 = Format(Val(AxfpSpread1.Text), "0.000")
            AxfpSpread1.Col = 4
            STOCKINHAND = Format(Val(AxfpSpread1.Text), "0.000")
            If closingval1 > STOCKINHAND Then
                AxfpSpread1.Col = 5
                AxfpSpread1.Text = STOCKINHAND
                MsgBox("Physical can't be greater than Stock in hand")
                Exit Sub


            Else
                ' AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
            End If
        End If

    End Sub


    Private Sub AxfpSpread1_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread1.LeaveCell
        Dim i As Integer
        i = AxfpSpread1.ActiveRow
 
        AxfpSpread1.Row = i
        If AxfpSpread1.ActiveCol = 3 Then

            AxfpSpread1.Col = 1
            Dim ITEMCODE As String = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            Dim UOM As String = AxfpSpread1.Text
            Dim UOM1 As String
            Dim sql11 As String = ""

            If Cmd_Add.Text = "Update[F7]" Then
                sql11 = "select TOP 1  ISNULL(openningstock,0) AS closingstock, uom,isnull(rate,0) as Rate from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,priority desc"
            Else
                sql11 = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom,isnull(rate,0) as Rate from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc, priority desc"
            End If


            gconnection.getDataSet(sql11, "closingtable")
            Dim closingqty, rate As Double
            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")
                rate = gdataset.Tables("closingtable").Rows(0).Item("rate")
            Else
                closingqty = 0
                rate = 0
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

            AxfpSpread1.SetText(4, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))
            AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(rate / convvalue), "0.000"))
        ElseIf AxfpSpread1.ActiveCol = 5 Then
            Dim s, p, c As Double
            AxfpSpread1.Col = 4
            s = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 5
            p = Val(AxfpSpread1.Text)
            AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Format(Val(s - p), "0.000"))
        ElseIf AxfpSpread1.ActiveCol = 6 Then
            Dim s, p, c As Double
            AxfpSpread1.Col = 4
            s = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 6
            p = Val(AxfpSpread1.Text)
            AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(s - p), "0.000"))
        End If

        If AxfpSpread1.ActiveCol = 6 Or AxfpSpread1.ActiveCol = 6 Then
            Dim s, p, c As Double
            AxfpSpread1.Col = 6
            s = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 7
            p = Val(AxfpSpread1.Text)
            AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(s * p), "0.000"))
        End If
    End Sub

    Private Sub btn_Auto_fill_Click(sender As Object, e As EventArgs) Handles btn_Auto_fill.Click
        Dim i As Integer

        Dim checkBdate As Boolean = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
        If checkBdate = True Then
            MsgBox("Business date closed..")
            Exit Sub
        End If
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill  Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            TXT_FROMSTORECODE.Focus()
            Exit Sub
        End If


        If DateDiff(DateInterval.Day, dtp_Docdate.Value, DateValue(Now)) < 0 Then
            MessageBox.Show("To Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            chkdatevalidate = False
            Exit Sub
        End If

        Dim sql As String
        If Mid(UCase(Trim(gShortname)), 1, 3) <> "SAT" Then
            sql = "select * from stockConsumption_1  where CONVERT(VARCHAR(11), docdate, 111)>='" & Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd") & "' and Storecode='" & TXT_FROMSTORECODE.Text & "' and isnull(void,'')<>'Y' and remarks<>'Auto Consumption in Issue time'"
            gconnection.getDataSet(sql, "stockConsumption_1")
            If (gdataset.Tables("stockConsumption_1").Rows.Count > 0) Then
                MessageBox.Show("Doc. Date cannot be less than last Consumption Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                dtp_Docdate.Focus()
                '                Exit Sub
            End If
        Else
            sql = "select * from stockConsumption_1  where CONVERT(VARCHAR(11), docdate, 111)>'" & Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd") & "' and Storecode='" & TXT_FROMSTORECODE.Text & "' and isnull(void,'')<>'Y' and remarks<>'Auto Consumption in Issue time' "
            gconnection.getDataSet(sql, "stockConsumption_1")
            If (gdataset.Tables("stockConsumption_1").Rows.Count > 0) Then
                MessageBox.Show("Doc. Date cannot be less than last Consumption Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                dtp_Docdate.Focus()
                '                Exit Sub
            End If
        End If

        Me.Cursor = Cursors.WaitCursor



        Dim sqlstring As String



        sqlstring = "SELECT C.ITEMCODE,itemname,UOM,TRNDATE,TRNS_SEQ,storecode,closingstock,rate FROM CLOSINGQTY C INNER JOIN INV_InventoryItemMaster IV ON IV.itemcode=C.itemcode WHERE storecode='" & TXT_FROMSTORECODE.Text & "' AND CAST(TRNDATE AS DATE)<=CAST('" & Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd") & "' AS DATE)   "
        sqlstring = sqlstring & " AND CAST(TRNS_SEQ AS CHAR)+CAST(C.itemcode AS CHAR) IN (SELECT CAST(MAX(TRNS_SEQ) AS CHAR)+ CAST(itemcode AS CHAR) FROM CLOSINGQTY WHERE "
        sqlstring = sqlstring & " storecode='" & TXT_FROMSTORECODE.Text & "' AND CAST( TRNDATE AS DATE)<= CAST('" & Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd") & "' AS DATE) GROUP BY itemcode) AND ISNULL(CLOSINGSTOCK,0)>0 and IV.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') order by c.itemcode"

        gconnection.getDataSet(sqlstring, "stocksummary")
        If gdataset.Tables("stocksummary").Rows.Count > 0 Then
            AUTOFILL = True
            For i = 0 To gdataset.Tables("stocksummary").Rows.Count - 1

                AxfpSpread1.Row = i + 1
                AxfpSpread1.Col = 1
                AxfpSpread1.Lock = True
                AxfpSpread1.SetText(1, i + 1, Trim(gdataset.Tables("stocksummary").Rows(i).Item("ITEMCODE")))

                AxfpSpread1.SetText(2, i + 1, Trim(gdataset.Tables("stocksummary").Rows(i).Item("ITEMNAME")))
                sql = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("stocksummary").Rows(i).Item("itemcode") + "'"

                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                    AxfpSpread1.Col = 3
                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                Next Z

                AxfpSpread1.SetText(3, i + 1, Trim(gdataset.Tables("stocksummary").Rows(i).Item("UOM")))
                AxfpSpread1.SetText(4, i + 1, Format(Val(gdataset.Tables("stocksummary").Rows(i).Item("closingstock")), "0.000"))
                'AxfpSpread1.SetText(5, i + 1, Trim(gdataset.Tables("StockConsumption_1").Rows(i).Item("BATCHNO")))
                AxfpSpread1.SetText(5, i + 1, 0)
                AxfpSpread1.SetText(6, i + 1, Format(Val(gdataset.Tables("stocksummary").Rows(i).Item("closingstock")), "0.000"))
                ' AxfpSpread1.SetText(5, i + 1, Format(Val(Val(gdataset.Tables("stocksummary").Rows(i).Item("QTY")) - Val(gdataset.Tables("StockConsumption_1").Rows(i).Item("consumer"))), "0.000"))

                ' AxfpSpread1.SetText(7, i + 1, Trim(gdataset.Tables("StockConsumption_1").Rows(i).Item("CLOSINGQTY")))
                AxfpSpread1.SetText(7, i + 1, Format(Val(gdataset.Tables("stocksummary").Rows(i).Item("rate")), "0.000"))
                AxfpSpread1.SetText(8, i + 1, Format(Val(gdataset.Tables("stocksummary").Rows(i).Item("rate")), "0.000") * Val(gdataset.Tables("stocksummary").Rows(i).Item("closingstock")))



            Next i
            AxfpSpread1.Col = 0
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 2
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 3
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 4
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 6
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 7
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 8
            AxfpSpread1.Lock = True

        Else
            MsgBox("NO ITEM AVILABLE FOR CONSUME  ")
        End If
        If gUserCategory <> "S" Then
            ' Call GetRights()
        End If
        '   TotalCount = gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count
        AxfpSpread1.SetActiveCell(5, 1)
        Me.Cursor = Cursors.Default



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox6.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Checkdaterangevalidate(Format(dtpfromdate.Value, "dd/MM/yyyy"), Format(dtptodate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub



        Dim sqlstring, CATEGORY(), ITEMNAME() As String
        Dim i As Integer


        ' gconnection.valuation()
        Me.Cursor = Cursors.WaitCursor

        sqlstring = " update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end ,  lastweightedrate=  case when openningvalue=0 then "
        sqlstring = sqlstring & " batchrate    Else  openningvalue/openningstock      End  "
        sqlstring = sqlstring & " from ratelist r inner join CLOSINGQTY on r.grnno=CLOSINGQTY.trnno where"
        sqlstring = sqlstring & " trndate = r.grndate And CLOSINGQTY.storecode = r.storecode And CLOSINGQTY.itemcode = r.Itemcode and CLOSINGQTY.openningstock<>0 "

        gconnection.dataOperation(6, sqlstring, "ratelist")


        sqlstring = " delete from stocksummary"
        gconnection.dataOperation(6, sqlstring, "stocksummary")
        sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY) "
        sqlstring = sqlstring & " select itemcode,ITEMNAME,'" + TXT_FROMSTORECODE.Text + "',STOCKUOM ,'0','0','0' "
        sqlstring = sqlstring & " from INV_InventoryItemMaster where  ISNULL(void,'') <>'Y'"


        gconnection.dataOperation(6, sqlstring, "stocksummary")

        sqlstring = " update stocksummary set uom=O.uom,opstk=O.openningqty,OPENNINGQTY=O.openningqty"
        ' sqlstring = sqlstring & " select O.itemcode,I.ITEMNAME,storecode, "
        sqlstring = sqlstring & " from inv_InventoryOpenningstock O inner join stocksummary on O.ITEMCODE=stocksummary.ITEMCODE  where O.storecode ='" + TXT_FROMSTORECODE.Text + "' "


        sqlstring = sqlstring & " AND ISNULL(O.void,'') <>'Y' "


        gconnection.dataOperation(6, sqlstring, "stocksummary")
        sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(dtpfromdate.Value, "dd/MMM/yyyy") + "','" + Format(dtptodate.Value, "dd/MMM/yyyy ") + "','" + TXT_FROMSTORECODE.Text + "'"

        gconnection.ExcuteStoreProcedure(sqlstring)

        Me.Cursor = Cursors.Default
        GroupBox6.Visible = False



        sqlstring = "SELECT  * from stocksummary where closingqty>0 order by itemcode "



        gconnection.getDataSet(sqlstring, "stocksummary")
        If gdataset.Tables("stocksummary").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("stocksummary").Rows.Count - 1

                AxfpSpread1.Row = i + 1
                AxfpSpread1.SetText(1, i + 1, Trim(gdataset.Tables("stocksummary").Rows(i).Item("ITEMCODE")))

                AxfpSpread1.SetText(2, i + 1, Trim(gdataset.Tables("stocksummary").Rows(i).Item("ITEMNAME")))
                Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("stocksummary").Rows(i).Item("itemcode") + "'"

                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                    AxfpSpread1.Col = 3
                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                Next Z

                AxfpSpread1.SetText(3, i + 1, Trim(gdataset.Tables("stocksummary").Rows(i).Item("UOM")))
                AxfpSpread1.SetText(4, i + 1, Format(Val(gdataset.Tables("stocksummary").Rows(i).Item("closingqty")), "0.000"))
                'AxfpSpread1.SetText(5, i + 1, Trim(gdataset.Tables("StockConsumption_1").Rows(i).Item("BATCHNO")))
                AxfpSpread1.SetText(5, i + 1, 0)
                AxfpSpread1.SetText(6, i + 1, Format(Val(gdataset.Tables("stocksummary").Rows(i).Item("closingqty")), "0.000"))
                ' AxfpSpread1.SetText(5, i + 1, Format(Val(Val(gdataset.Tables("stocksummary").Rows(i).Item("QTY")) - Val(gdataset.Tables("StockConsumption_1").Rows(i).Item("consumer"))), "0.000"))

                ' AxfpSpread1.SetText(7, i + 1, Trim(gdataset.Tables("StockConsumption_1").Rows(i).Item("CLOSINGQTY")))
                AxfpSpread1.SetText(7, i + 1, Format(Val(gdataset.Tables("stocksummary").Rows(i).Item("clrate")), "0.000"))
                AxfpSpread1.SetText(8, i + 1, Format(Val(gdataset.Tables("stocksummary").Rows(i).Item("clrate")), "0.000") * Val(gdataset.Tables("stocksummary").Rows(i).Item("closingqty")))

                '                            ssgrid.SetText(12, i, Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(j).Item("STOCKINHAND")), "0.000"))
                '  AxfpSpread1.SetText(7, i, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("consumerCODE")))
                '   ssgrid.SetText(14, i, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("DBLAMOUNT")), "0.000"))
                '  ssgrid.SetText(8, i, Trim(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("DBLCONV")))
                ' ssgrid.SetText(9, i, Format(Val(gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows(j).Item("HIGHRATIO")), "0.000"))


                ' Clsquantity = ClosingQuantity(Trim(gdataset.Tables("STOCKADJUSTDETAILS").Rows(j).Item("ITEMCODE")), Trim(txt_Storecode.Text))
                '  AxfpSpread1.SetText(10, i, Format(Val(cls), "0.000"))


            Next i
        Else
            MsgBox("NO ITEM AVILABLE FOR CONSUME  ")
        End If
        If gUserCategory <> "S" Then
            ' Call GetRights()
        End If
        '   TotalCount = gdataset.Tables("STOCKCONSUMTIONDETAILS").Rows.Count
        AxfpSpread1.SetActiveCell(5, 1)





    End Sub

    Private Sub AxfpSpread1_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread1.Advance

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TXT_FROMSTORECODE_TextChanged(sender As Object, e As EventArgs) Handles TXT_FROMSTORECODE.TextChanged

    End Sub
End Class