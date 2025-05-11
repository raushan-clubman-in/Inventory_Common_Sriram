Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Public Class Frm_Adjustment
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Dim doctype1 As String
    Dim docno1(0) As String
    Dim adate As DateTime

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

            doctype1 = "Adj"
            ' ADDED BY SRI FOR FROM SHELF
            If GSHELVING = "Y" Then
                sqlstring = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster WHERE  STORECODE='" + TXT_FROMSTORECODE.Text + "' And ISNULL(FREEZE,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "FROMSHELF")
                If gdataset.Tables("FROMSHELF").Rows.Count > 0 Then
                    AxfpSpread1.Col = 12
                    AxfpSpread1.ColHidden = False
                Else
                    AxfpSpread1.Col = 12
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
            If (TXT_FROMSTORECODE.Text = "") Then
                cmd_fromStorecodeHelp_Click(sender, e)
            Else
                TXT_FROMSTORECODE_Validated(sender, e)
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
                doctype1 = ""
                doctype1 = "ADJ"
                ' ADDED BY SRI FOR FROM SHELF
                If GSHELVING = "Y" Then
                    sqlstring = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster WHERE  STORECODE='" + TXT_FROMSTORECODE.Text + "' And ISNULL(FREEZE,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "FROMSHELF")
                    If gdataset.Tables("FROMSHELF").Rows.Count > 0 Then
                        AxfpSpread1.Col = 12
                        AxfpSpread1.ColHidden = False
                    Else
                        AxfpSpread1.Col = 12
                        AxfpSpread1.ColHidden = True
                    End If
                End If
                ' END 
                Call autogenerate()
                '  dtp_Docdate.Focus()
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
        Dim message, title, defaultValue As String
        Dim myValue As Object
        Dim UOM1 As String
        message = "Enter Batch No"
        title = "Batch No"



        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess, M.Category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "'"
        vform.Field = " I.itemcode, M.Itemname,uom"
        vform.vFormatstring = "    Itemcode    |                     Itemname                    |         UOM       |        batchprocess  "
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

            Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
            Next Z
            'Dim a As String=
            If Trim(vform.keyfield3) = "YES" Then
                AxfpSpread1.Col = 4
                AxfpSpread1.ColHidden = False

                '  gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), Trim(vform.keyfield2))
                'Dim sql As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno,priority order by priority "
                'Dim sql As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                'sql = sql & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                '
                Dim SQL1 As String = "with a as ( "
                SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,isnull(batchno,'') as  batchno from closingqty WHERE TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,closingqty.uom as uom from a inner  join closingqty on "
                SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                'SQL1 = SQL1 & " "
                SQL1 = SQL1 & " and   a.storecode=closingqty.storecode  "
                SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(vform.keyfield) + "'"
                SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND A.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate "


                gconnection.getDataSet(SQL1, "closingtable")

                If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                    GroupBox5.Visible = True

                    AxfpSpread2.ClearRange(1, 1, -1, -1, True)
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




                    Next

                    AxfpSpread2.SetActiveCell(5, 1)
                    AxfpSpread2.Focus()
                Else
                    GroupBox5.Visible = False

                    AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                End If

            Else

                Dim convvalue As Double

                'sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                'gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                '    Dim sql1 As String
                '    If rateflag = "W" Then
                '        sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                '        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + vform.keyfield + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                '    Else
                '        sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                '        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
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
                '        AxfpSpread1.Col = 8
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
                '            AxfpSpread1.Col = 8
                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow


                '            AxfpSpread1.Text = Format(Val(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue)), "0.000")


                '        Else
                '            AxfpSpread1.Col = 8
                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '            AxfpSpread1.Text = 0

                '        End If
                '    End If


                'End If


                AxfpSpread1.Col = 4
                AxfpSpread1.ColHidden = True
                Dim sql11 As String
                'Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom from closingqty where itemcode='" + vform.keyfield + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trns_seq desc"


                'gconnection.getDataSet(sql11, "closingtable")
                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), vform.keyfield, Trim(TXT_FROMSTORECODE.Text), "")
                Dim Physicalstock, stockinhand, adjustedstock, rate1 As Double
                If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
                    sqlstring = "SELECT ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,D.DOCDATE AS DOCDATE,ISNULL(D.storecode,'') AS STORELOCATIONCODE,  "
                    sqlstring = sqlstring & " ISNULL(D.STOREDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
                    sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(c.openningstock,0) AS STOCKINHAND,ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK,"
                    sqlstring = sqlstring & " ISNULL(D.PHYSICALSTOCK -c.openningstock ,0) AS ADJUSTEDSTOCK,ISNULL(D.batchno,0) AS batchno,isnull(c.rate,0) as rate,isnull(amount,0) as amount,isnull(remarks2,'')as remarks2 "
                    sqlstring = sqlstring & "  FROM STOCKADJUSTDETAILS AS D inner join closingqty c on c.itemcode=d.Itemcode and c.Trnno=d.Docdetails WHERE  ISNULL(D.DOCDETAILS,'')='" & Trim(txt_Docno.Text) & "' And c.ttype ='ADJUSTMENT'"
                    gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS1")

                    If gdataset.Tables("STOCKADJUSTDETAILS1").Rows.Count > 0 Then
                        Physicalstock = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("PHYSICALSTOCK")
                        stockinhand = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("STOCKINHAND")
                        adjustedstock = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("ADJUSTEDSTOCK")
                        rate1 = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("rate")
                    End If
                End If
                Dim closingqty, rate As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                Else
                    closingqty = 0
                    rate = 0
                End If
                UOM1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + UOM1 + "' and transuom='" + vform.keyfield2 + "'"
                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                Else
                    convvalue = 0
                End If
                closingqty = closingqty * convvalue
                If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
                    AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(rate1), "0.000"))
                    AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(stockinhand), "0.000"))
                    AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Format(Val(Physicalstock), "0.000"))
                    AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(adjustedstock), "0.000"))
                    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(rate / convvalue), "0.000"))
                    AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))
                    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                End If
                'If (GBATCHNO = "Y") Then
                '    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                'Else
                AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                ' End If
            End If
        End If
    End Sub
    Private Sub binditemname()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim Physicalstock, stockinhand, adjustedstock, rate1 As Double
        Dim myValue As Object
        Dim uom1 As String
        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess,M.category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "'"
        vform.Field = " I.itemcode, m.Itemname,I.Uom,batchprocess"
        vform.vFormatstring = "       itemcode        |                       Itemname                      |       UOM      |"
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        'vform.KeyPos1 = 3
        'vform.KeyPos1 = 4
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

            Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
            Next Z
            If Trim(vform.keyfield3) = "YES" Then
                AxfpSpread1.Col = 4
                AxfpSpread1.ColHidden = False

                '      gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), Trim(vform.keyfield2))
                '  Dim sql As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                'Dim sql As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                'sql = sql & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                Dim SQL1 As String = "with a as ( "
                SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,isnull(batchno,'') as  batchno from closingqty WHERE TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,closingqty.uom as uom from a inner  join closingqty on "
                SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                'SQL1 = SQL1 & " "
                SQL1 = SQL1 & " and   a.storecode=closingqty.storecode  "
                SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(vform.keyfield) + "'"
                SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND A.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate "



                gconnection.getDataSet(SQL1, "closingtable")
                If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                    GroupBox5.Visible = True

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



                    Next
                    AxfpSpread2.Focus()
                    AxfpSpread2.SetActiveCell(5, 1)

                End If

            Else
                Dim convvalue As Double

                'sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                'gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                '    Dim sql1 As String
                '    If rateflag = "W" Then
                '        ' sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                '        'sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + vform.keyfield + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                '    Else
                '        'sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                '        'sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
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
                '        AxfpSpread1.Col = 8
                '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue))
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
                '            AxfpSpread1.Col = 8
                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow


                '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)


                '        Else
                '            AxfpSpread1.Col = 8
                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '            AxfpSpread1.Text = 0

                '        End If
                '    End If


                'End If

                AxfpSpread1.Col = 4
                AxfpSpread1.ColHidden = True
                Dim sql11 As String
                'Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom from closingqty where itemcode='" + vform.keyfield + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                ' gconnection.getDataSet(sql11, "closingtable")
                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), vform.keyfield, Trim(TXT_FROMSTORECODE.Text), "")
                If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
                    sqlstring = "SELECT ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,D.DOCDATE AS DOCDATE,ISNULL(D.storecode,'') AS STORELOCATIONCODE,  "
                    sqlstring = sqlstring & " ISNULL(D.STOREDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
                    sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(c.openningstock,0) AS STOCKINHAND,ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK,"
                    sqlstring = sqlstring & " ISNULL(D.PHYSICALSTOCK -c.openningstock ,0) AS ADJUSTEDSTOCK,ISNULL(D.batchno,0) AS batchno,isnull(c.rate,0) as rate,isnull(amount,0) as amount,isnull(remarks2,'')as remarks2 "
                    sqlstring = sqlstring & "  FROM STOCKADJUSTDETAILS AS D inner join closingqty c on c.itemcode=d.Itemcode and c.Trnno=d.Docdetails WHERE  ISNULL(D.DOCDETAILS,'')='" & Trim(txt_Docno.Text) & "' And c.ttype ='ADJUSTMENT'"
                    gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS1")
                    If gdataset.Tables("STOCKADJUSTDETAILS1").Rows.Count > 0 Then
                        Physicalstock = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("PHYSICALSTOCK")
                        stockinhand = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("STOCKINHAND")
                        adjustedstock = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("ADJUSTEDSTOCK")
                        rate1 = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("rate")
                    End If
                End If
                Dim closingqty, Rate As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    Rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                Else
                    closingqty = 0
                    Rate = 0
                End If
                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + vform.keyfield2 + "'"
                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    convvalue = 0
                End If
                closingqty = closingqty * convvalue
                If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
                    AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(rate1), "0.000"))
                    AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(stockinhand), "0.000"))
                    AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Format(Val(Physicalstock), "0.000"))
                    AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(adjustedstock), "0.000"))
                    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(Rate / convvalue), "0.000"))
                    AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))
                    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                End If
            End If
            '  AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
        End If




    End Sub


    Private Sub autogenerate()
        Dim Sqlstring, Financalyear As String
        If Trim(TXT_FROMSTORECODE.Text) <> "" And Mid(Cmd_Add.Text, 1, 1) = "A" Then
            Try
                doctype1 = "ADJ"

                doctype1 = Mid(TXT_FROMSTORECODE.Text, 1, 3)

                If doctype1.Length <= 2 Then
                    doctype1 = "ADJ"
                End If


                Financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
                ' Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) FROM STOCKADJUSTHEADER "
                Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) FROM STOCKADJUSTHEADER WHERE SUBSTRING(docDETAILS,1,3)='" & Trim(doctype1) & "' "   'and SUBSTRING(docDETAILS,5,3)='" & Trim(doctype1) & "' "

                gconnection.openConnection()
                gcommand = New SqlCommand(Sqlstring, gconnection.Myconn)
                gdreader = gcommand.ExecuteReader
                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        txt_Docno.Text = doctype1 & "/000001/" & Financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        txt_Docno.Text = doctype1 & "/" & Format(gdreader(0) + 1, "000000") & "/" & Financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    txt_Docno.Text = doctype1 & "/000001/" & Financalyear
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
            If Mid(Cmd_Add.Text, 1, 1) = "A" Then
                txt_Docno.Text = ""
            End If

        End If
    End Sub

    Private Sub Clearoperation()
        TXT_FROMSTORECODE.Text = ""
        txt_FromStorename.Text = ""
        lbl_Freeze.Text = ""
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        txt_Remarks.Text = ""
        Cmd_Add.Text = "ADD[F7]"
        autogenerate()
        dtp_Docdate.Focus()
        txt_Totalqty.Text = ""

        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True

        dtp_Docdate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        For k As Integer = 0 To 10
            For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                AxfpSpread1.TypeComboBoxClear(3, k)
            Next
        Next
        If gShortname = "RSAOI" Then
            '========================# IM POLICY CODE START #===========================
            Autherize = ""
            MCA = ""
            '========================# IM POLICY CODE END #===========================
        End If

    End Sub
    Private Sub addoperation()
        Dim insert(0) As String
        Dim itemcode As String
        Dim amt As Double
        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            Call autogenerate()
        End If

        docno1 = Split(Trim(txt_Docno.Text), "/")

        sqlstring = "INSERT INTO STOCKADJUSTHEADER(Docno,Docdetails,Docdate,Storecode,Storedesc, "
        sqlstring = sqlstring & " Adjustedstock, Stockinhand, Physicalstock,Remarks,Void,Adduser,Adddate,Updateuser,Updatetime)"
        sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
        sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
        sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
        sqlstring = sqlstring & " " & Format(Val(txt_Totalamount.Text), "0.000") & " ," & Format(Val(txt_Totalqty.Text), "0.000") & ","
        sqlstring = sqlstring & " " & Format(Val(txt_Physicalstock.Text), "0.000") & ",'" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,"
        sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',getDate(),"
        sqlstring = sqlstring & " '',getDate())"
        insert(0) = sqlstring
        'Dim Seq As Double = gconnection.getInvSeq(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"))
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            '        Avgrate = CalAverageRate(Trim(ssgrid.Text))
            '       Avgquantity = CalAverageQuantity(Trim(ssgrid.Text))
            sqlstring = "INSERT INTO STOCKADJUSTDETAILS(Docno,Docdetails,DocDate,Storecode,StoreDESC,"
            sqlstring = sqlstring & " Itemcode,Itemname,Uom,batchno,Stockinhand,Physicalstock,Adjustedstock,"
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "SHELF,"
            End If
            sqlstring = sqlstring & " Remarks,Void,Adduser,Adddate,rate,amount,remarks2)"
            sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
            AxfpSpread1.Col = 1
            itemcode = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

            AxfpSpread1.Col = 5
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 6
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 7
            Dim qty As Double = Val(AxfpSpread1.Text)
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            If GSHELVING = "Y" Then
                AxfpSpread1.Col = 12
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            End If
            sqlstring = sqlstring & " '" & txt_Remarks.Text & "',"
            sqlstring = sqlstring & " 'N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "',getDate(),"
            AxfpSpread1.Col = 8
            Dim rate As Double = Val(AxfpSpread1.Text)
            amt = amt + (rate * qty)
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 9

            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

            AxfpSpread1.Col = 10
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "')"


            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
          



        Next

        If GACCPOST.ToUpper() = "Y" Then
            If UCase(gShortname) <> "HIND" Then


                Dim CONGLCODE, CONGLDESC, ACCOUNTCODE, ACCOUNTDESC, ADJGLCODE, ADJGLDESC As String
                Dim decription As String
                If gAcPostingWise = "ITEM" Then
                    Dim amount, POSTAMT As Double
                    For k As Integer = 1 To AxfpSpread1.DataRowCnt

                        AxfpSpread1.Row = k

                        AxfpSpread1.Col = 9
                        amount = Val(AxfpSpread1.Text)
                        amt = amount
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "Select ADJGLCODE,ADJGLDESC,ACCOUNTCODE,ACCOUNTDESC,ADJCCDESC,ADJCCCODE from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "SLCODE1")
                            If gdataset.Tables("SLCODE1").Rows.Count > 0 Then

                                CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJCCCODE")
                                CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJCCDESC")
                                ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
                                ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
                                ADJGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLCODE")
                                ADJGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLDESC")
                            Else
                                MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                                Exit Sub
                            End If
                            Dim AMT1 As Double

                            AMT1 = Math.Abs(amt)
                            If amt > 0 Then

                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                                sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                sqlstring = sqlstring & "'DEBIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = sqlstring


                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ADJGLCODE & "',"
                                sqlstring = sqlstring & "'" & ADJGLDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                sqlstring = sqlstring & "'CREDIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = sqlstring
                            Else
                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ADJGLCODE & "',"
                                sqlstring = sqlstring & "'" & ADJGLDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                sqlstring = sqlstring & "'DEBIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = sqlstring


                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                                sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                sqlstring = sqlstring & "'CREDIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = sqlstring

                            End If
                        End If

                    Next
                ElseIf gAcPostingWise = "CATEGORY" Then
                    Dim amount, POSTAMT As Double
                    For k As Integer = 1 To AxfpSpread1.DataRowCnt

                        AxfpSpread1.Row = k

                        AxfpSpread1.Col = 9
                        amount = Val(AxfpSpread1.Text)
                        amt = amount
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "select accountcode,accountDESC,ADJGLCODE,ADJGLDESC,AC.CategoryCode from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category AND IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "SLCODE1")
                            If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                                CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLCODE")
                                CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLDESC")
                                ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("accountcode")
                                ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("accountDESC")
                            Else
                                MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                                Exit Sub
                            End If
                            Dim AMT1 As Double

                            AMT1 = Math.Abs(amt)
                            If amt > 0 Then

                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                                sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                sqlstring = sqlstring & "'DEBIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = sqlstring


                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & CONGLCODE & "',"
                                sqlstring = sqlstring & "'" & CONGLDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                sqlstring = sqlstring & "'CREDIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = sqlstring
                            Else
                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & CONGLCODE & "',"
                                sqlstring = sqlstring & "'" & CONGLDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                sqlstring = sqlstring & "'DEBIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = sqlstring


                                sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                                sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                                sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                sqlstring = sqlstring & "'CREDIT',"
                                'amt = Format(Val(txt_Billamount.Text), "0.000")
                                decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                'slcode = txt_Storecode.Text
                                sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = sqlstring

                            End If
                        End If

                    Next
                Else
                    If gShortname = "BRC" Then
                        sqlstring = "select ADJGLCODE,ADJGLDESC,ADJCCCODE,ADJCCDESC,ACCOUNTCODE,accountdesc from ACCOUNTSTAGGINGNEW  WHERE "
                        sqlstring = sqlstring & "CODE='" & TXT_FROMSTORECODE.Text & "' AND DESCRIPTION='" & txt_FromStorename.Text & "' AND  isnull(VOID,'')<>'Y'"
                        gconnection.getDataSet(sqlstring, "SLCODE1")
                        If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                            CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJCCCODE")
                            CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJCCDESC")
                            ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
                            ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("accountdesc")
                            ADJGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLCODE")
                            ADJGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLDESC")
                        Else
                            MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                            Exit Sub
                        End If
                    Else
                        sqlstring = "select ADJGLCODE,ADJGLDESC,ADJCCCODE,ADJCCDESC from ACCOUNTSTAGGINGNEW  WHERE "
                        sqlstring = sqlstring & "CODE='" & TXT_FROMSTORECODE.Text & "' AND DESCRIPTION='" & txt_FromStorename.Text & "' AND  isnull(VOID,'')<>'Y'"
                        gconnection.getDataSet(sqlstring, "SLCODE1")
                        If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                            CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJCCCODE")
                            CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJCCDESC")
                            ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLCODE")
                            ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLDESC")
                        Else
                            MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                            Exit Sub
                        End If
                    End If
                    Dim AMT1 As Double
                    AMT1 = Math.Abs(amt)
                    If amt > 0 Then

                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                        sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                        sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                        sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                        'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        sqlstring = sqlstring & "'DEBIT',"
                        'amt = Format(Val(txt_Billamount.Text), "0.000")
                        decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                        sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                        'slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring
                        If gShortname = "BRC" Then
                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ADJGLCODE & "',"
                            sqlstring = sqlstring & "'" & ADJGLDESC & "',"
                            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                            'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'CREDIT',"
                            'amt = Format(Val(txt_Billamount.Text), "0.000")
                            decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                            sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"
                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring
                        Else
                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & CONGLCODE & "',"
                            sqlstring = sqlstring & "'" & CONGLDESC & "',"
                            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                            'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'CREDIT',"
                            'amt = Format(Val(txt_Billamount.Text), "0.000")
                            decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                            sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"
                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring
                        End If

                    Else
                        If gShortname = "BRC" Then
                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ADJGLCODE & "',"
                            sqlstring = sqlstring & "'" & ADJGLDESC & "',"
                            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                            'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'DEBIT',"
                            'amt = Format(Val(txt_Billamount.Text), "0.000")
                            decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                            sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring


                        Else
                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & CONGLCODE & "',"
                            sqlstring = sqlstring & "'" & CONGLDESC & "',"
                            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                            'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'DEBIT',"
                            'amt = Format(Val(txt_Billamount.Text), "0.000")
                            decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                            sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring

                        End If


                        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                        sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                        sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                        sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                        sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                        'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                        sqlstring = sqlstring & "'CREDIT',"
                        'amt = Format(Val(txt_Billamount.Text), "0.000")
                        decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                        sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                        'slcode = txt_Storecode.Text
                        sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring

                    End If
                End If

            End If




        End If



        gconnection.MoreTrans(insert)

        If gShortname = "RSAOI" Then
            ' For Maker/ Checker 
            gconnection.FORM_MCA(GmoduleName, "STOCKADJUSTHEADER", "Docdetails='" & Trim(txt_Docno.Text) & "'", "I") '''for mca
            gconnection.FORM_MCA(GmoduleName, "STOCKADJUSTDETAILS", "Docdetails='" & Trim(txt_Docno.Text) & "'", "I") '''for mca
            If TO_CHK_MCA_YN(GmoduleName) = True And gUserCategory = "U" Then
                sqlstring = "insert into authPending (Docdetail,Docdate,Storecode,Itemcode,TType) "
                sqlstring = sqlstring & "select Docdetails,Docdate,storecode,Itemcode,'ADJUSTMENT' from STOCKADJUSTDETAILS where Docdetails='" & txt_Docno.Text & "'"
                gconnection.dataOperation(6, sqlstring, )
            End If
            'End
        End If
    End Sub

    Private Sub updateoperation()
        Dim insert(0) As String
        Dim itemcode As String
        Dim qty As Double
        Dim amt As Double
        Dim seq As Double

        sqlstring = "select * from STOCKADJUSTHEADER WHERE Docdetails='" + Trim(CStr(txt_Docno.Text)) + "' and cast(convert(varchar(11),Docdate,106)as datetime)='" & Format(Me.dtp_Docdate.Value, "dd/MMM/yyyy") & "'"
        gconnection.getDataSet(sqlstring, "backdate")
        If gdataset.Tables("backdate").Rows.Count > 0 Then


            'sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
            'sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
            'gconnection.getDataSet(sqlstring, "closingqty")
            'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '    seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
            'End If

            docno1 = Split(Trim(txt_Docno.Text), "/")

            If gShortname = "RSAOI" Then
                '========================# IM POLICY CODE START #===========================
                ''TO CHECK MCA Y/N
                If TO_CHK_MCA_YN(GmoduleName) = True And (gUserCategory <> "S" And ModuleAdmin <> True) And Autherize = "Y" Then
                    MessageBox.Show("You don't Have rights to Update this Record, Super User/Module Admin Only can update this Record!.", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
                If MCA <> "M" And Autherize <> "Y" Then
                    MessageBox.Show("You Can't' Update the Checked Records", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
                'End
            End If
            'FOR LOG DATA
            sqlstring = "INSERT INTO STOCKADJUSTHEADER_LOG(Docno,Docdetails,Docdate,Storecode,Storedesc, "
            sqlstring = sqlstring & " Adjustedstock, Stockinhand, Physicalstock,Remarks,Void,Adduser,Adddate,Updateuser,Updatetime) "
            sqlstring = sqlstring & " SELECT Docno,Docdetails,Docdate,Storecode,Storedesc, "
            sqlstring = sqlstring & " Adjustedstock, Stockinhand, Physicalstock,Remarks,Void,Adduser,Adddate,Updateuser,Updatetime FROM STOCKADJUSTHEADER WHERE Docdetails='" & Trim(txt_Docno.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOCKADJUSTHEADER_LOG")

            'sqlstring = "INSERT INTO STOCKADJUSTDETAILS_LOG(INDENT_NO,INDENT_DATE,Itemcode,Itemname,Uom,Qty,"
            'If gShortname = "KGA" Then
            '    sqlstring = sqlstring & "CLSQTY,"
            'End If
            'sqlstring = sqlstring & " VOID,Rate,Amount,Adduser,adddatetime)"
            'sqlstring = sqlstring & " SELECT Docno,Docdetails,DocDate,Storecode,Storedesc,"
            'sqlstring = sqlstring & " Itemcode,Itemname,Uom,batchno,Stockinhand,Physicalstock,Adjustedstock,"
            'If GSHELVING = "Y" Then
            '    sqlstring = sqlstring & "SHELF,"
            'End If
            'sqlstring = sqlstring & " Remarks,Void,updateuser,updatetime,rate,amount,remarks2 from  STOCKADJUSTDETAILS WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
            'gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS_LOG")
            ''LOG DATA ENDS 



            sqlstring = "UPDATE STOCKADJUSTHEADER SET Docdate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "', "
            sqlstring = sqlstring & " Storecode='" & Trim(TXT_FROMSTORECODE.Text) & "',"
            sqlstring = sqlstring & " Storedesc='" & Trim(txt_FromStorename.Text) & "',"
            sqlstring = sqlstring & " Adjustedstock=" & Format(Val(txt_Totalamount.Text), "0.000") & ","
            sqlstring = sqlstring & " Stockinhand=" & Format(Val(txt_Totalqty.Text), "0.000") & ","
            sqlstring = sqlstring & " Physicalstock=" & Format(Val(txt_Physicalstock.Text), "0.000") & ","
            sqlstring = sqlstring & " Remarks='" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,"
            sqlstring = sqlstring & " Void='N',updateuser='" & Trim(gUsername) & "',"
            sqlstring = sqlstring & " Updatetime=getDate()"
            sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
            insert(0) = sqlstring
            sqlstring = "DELETE FROM STOCKADJUSTDETAILS WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                '        Avgrate = CalAverageRate(Trim(ssgrid.Text))
                '       Avgquantity = CalAverageQuantity(Trim(ssgrid.Text))
                sqlstring = "INSERT INTO STOCKADJUSTDETAILS(Docno,Docdetails,DocDate,Storecode,Storedesc,"
                sqlstring = sqlstring & " Itemcode,Itemname,Uom,batchno,Stockinhand,Physicalstock,Adjustedstock,"
                If GSHELVING = "Y" Then
                    sqlstring = sqlstring & "SHELF,"
                End If
                sqlstring = sqlstring & " Remarks,Void,updateuser,updatetime,rate,amount,remarks2)"
                sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                AxfpSpread1.Col = 1
                itemcode = AxfpSpread1.Text
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

                AxfpSpread1.Col = 2
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 3
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 4
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"

                AxfpSpread1.Col = 5
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 6

                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 7
                qty = Val(AxfpSpread1.Text)
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                If GSHELVING = "Y" Then
                    AxfpSpread1.Col = 12
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                End If
                sqlstring = sqlstring & " '" & txt_Remarks.Text & "',"
                AxfpSpread1.Col = 11
                sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"

                ' sqlstring = sqlstring & " 'N',"
                sqlstring = sqlstring & " '" & Trim(gUsername) & "',getDate(),"
                AxfpSpread1.Col = 8
                Dim rate As Double = Val(AxfpSpread1.Text)
                amt = amt + (rate * qty)

                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 9
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 10
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "')"


                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring

                'Dim qty1 As Double
                'Dim batchyn As String
                'Dim uom As String
                'Dim uom1 As String
                'Dim convvalue As Double
                'Dim batchno As String
                'AxfpSpread1.Col = 3
                'uom1 = AxfpSpread1.Text
                'AxfpSpread1.Col = 4
                'batchno = AxfpSpread1.Text
                'Dim sql1 As String
                'sql1 = "select qty,isnull(batchno,'') as  batchno,uom,isnull(batchyn,'N') as  batchyn from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
                'sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
                'If (batchno <> "") Then
                '    sql1 = sql1 & " and  batchno='" + batchno + "' "
                'End If

                'gconnection.getDataSet(sql1, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                '    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                '    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                '    Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                '    convvalue = gconnection.getvalue(sql)
                'Else
                '    qty1 = 0
                '    convvalue = 1
                'End If
                'sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) + (qty / convvalue)), "0.000") + ",qty=" + Format(Val(qty / convvalue), "0.000") + ""
                'sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
                'If (batchyn = "Y") Then
                '    sql1 = sql1 & "  and  batchno='" + batchno + "'"
                'End If
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sql1

                'sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) + (qty / convvalue)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1) + (qty / convvalue)), "0.000") + ""
                '',closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
                '',openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
                'sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
                'If (batchyn = "Y") Then
                '    sql1 = sql1 & "  and  batchno='" + txt_Docno.Text + "'"
                'End If
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sql1

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
            If GACCPOST.ToUpper() = "Y" Then
                If UCase(gShortname) <> "HIND" Then
                    Dim CONGLCODE, CONGLDESC, ACCOUNTCODE, ACCOUNTDESC As String
                    Dim decription As String
                    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "' AND VoucherType='ADJUSTMENT'"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring


                    If gAcPostingWise = "ITEM" Then
                        Dim amount, POSTAMT As Double
                        For k As Integer = 1 To AxfpSpread1.DataRowCnt

                            AxfpSpread1.Row = k

                            AxfpSpread1.Col = 9
                            amount = Val(AxfpSpread1.Text)
                            amt = amount
                            AxfpSpread1.Col = 1
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "Select ADJGLCODE,ADJGLDESC,ACCOUNTCODE,ACCOUNTDESC,ADJCCCODE,ADJCCDESC from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                                gconnection.getDataSet(sqlstring, "SLCODE1")
                                If gdataset.Tables("SLCODE1").Rows.Count > 0 Then

                                    CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJCCCODE")
                                    CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJCCDESC")
                                    ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
                                    ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
                                Else
                                    MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                                    Exit Sub
                                End If
                                Dim AMT1 As Double

                                AMT1 = Math.Abs(amt)
                                If amt > 0 Then

                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                                    sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                                    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                    'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'DEBIT',"
                                    'amt = Format(Val(txt_Billamount.Text), "0.000")
                                    decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                    sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = sqlstring


                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & CONGLCODE & "',"
                                    sqlstring = sqlstring & "'" & CONGLDESC & "',"
                                    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                    'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'CREDIT',"
                                    'amt = Format(Val(txt_Billamount.Text), "0.000")
                                    decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                    sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = sqlstring
                                Else
                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & CONGLCODE & "',"
                                    sqlstring = sqlstring & "'" & CONGLDESC & "',"
                                    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                    'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'DEBIT',"
                                    'amt = Format(Val(txt_Billamount.Text), "0.000")
                                    decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                    sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = sqlstring


                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                                    sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                                    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                    'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'CREDIT',"
                                    'amt = Format(Val(txt_Billamount.Text), "0.000")
                                    decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                    sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = sqlstring

                                End If
                            End If

                        Next
                    ElseIf gAcPostingWise = "CATEGORY" Then
                        Dim amount, POSTAMT As Double
                        For k As Integer = 1 To AxfpSpread1.DataRowCnt

                            AxfpSpread1.Row = k

                            AxfpSpread1.Col = 9
                            amount = Val(AxfpSpread1.Text)
                            amt = amount
                            AxfpSpread1.Col = 1
                            If Trim(AxfpSpread1.Text) <> "" Then
                                sqlstring = "select accountcode,accountDESC,ADJGLCODE,ADJGLDESC,AC.CategoryCode from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category AND IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
                                gconnection.getDataSet(sqlstring, "SLCODE1")
                                If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                                    CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLCODE")
                                    CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLDESC")
                                    ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("accountcode")
                                    ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("accountDESC")
                                Else
                                    MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                                    Exit Sub
                                End If
                                Dim AMT1 As Double

                                AMT1 = Math.Abs(amt)
                                If amt > 0 Then

                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                                    sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                                    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                    'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'DEBIT',"
                                    'amt = Format(Val(txt_Billamount.Text), "0.000")
                                    decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                    sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = sqlstring


                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & CONGLCODE & "',"
                                    sqlstring = sqlstring & "'" & CONGLDESC & "',"
                                    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                    'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'CREDIT',"
                                    'amt = Format(Val(txt_Billamount.Text), "0.000")
                                    decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                    sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = sqlstring
                                Else
                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & CONGLCODE & "',"
                                    sqlstring = sqlstring & "'" & CONGLDESC & "',"
                                    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                    'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'DEBIT',"
                                    'amt = Format(Val(txt_Billamount.Text), "0.000")
                                    decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                    sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = sqlstring


                                    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                                    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                                    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                                    sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                                    sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                                    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                                    'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                                    sqlstring = sqlstring & "'CREDIT',"
                                    'amt = Format(Val(txt_Billamount.Text), "0.000")
                                    decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                                    sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                                    'slcode = txt_Storecode.Text
                                    sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                                    ReDim Preserve insert(insert.Length)
                                    insert(insert.Length - 1) = sqlstring

                                End If
                            End If

                        Next
                    Else
                        sqlstring = "select ADJGLCODE,ADJGLDESC,ADJCCCODE,ADJCCDESC from ACCOUNTSTAGGINGNEW  WHERE "
                        sqlstring = sqlstring & "CODE='" & TXT_FROMSTORECODE.Text & "' AND DESCRIPTION='" & txt_FromStorename.Text & "' AND  isnull(VOID,'')<>'Y'"
                        gconnection.getDataSet(sqlstring, "SLCODE1")
                        If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                            CONGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJCCCODE")
                            CONGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJCCDESC")
                            ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLCODE")
                            ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ADJGLDESC")
                        Else
                            MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                            Exit Sub
                        End If
                        Dim AMT1 As Double
                        AMT1 = Math.Abs(amt)
                        If amt > 0 Then

                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                            sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                            'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'DEBIT',"
                            'amt = Format(Val(txt_Billamount.Text), "0.000")
                            decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                            sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring


                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & CONGLCODE & "',"
                            sqlstring = sqlstring & "'" & CONGLDESC & "',"
                            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                            'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'CREDIT',"
                            'amt = Format(Val(txt_Billamount.Text), "0.000")
                            decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                            sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring
                        Else
                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & CONGLCODE & "',"
                            sqlstring = sqlstring & "'" & CONGLDESC & "',"
                            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                            'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'DEBIT',"
                            'amt = Format(Val(txt_Billamount.Text), "0.000")
                            decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                            sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring


                            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc, CreditDebit, Amount,DESCRIPTION, VOID,adduserid,adddatetime)"
                            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                            sqlstring = sqlstring & "'', 'ADJUSTMENT', '" & ACCOUNTCODE & "',"
                            sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                            'sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                            sqlstring = sqlstring & "'CREDIT',"
                            'amt = Format(Val(txt_Billamount.Text), "0.000")
                            decription = "Adjustment bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                            sqlstring = sqlstring & "" & AMT1 & ",'" & decription & "',"

                            'slcode = txt_Storecode.Text
                            sqlstring = sqlstring & "'N','" & gUsername & "',getDate())"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = sqlstring

                        End If
                    End If
                End If



            End If

                gconnection.MoreTrans(insert)


            If gShortname = "RSAOI" Then
                ' For Maker / Checker By Sri
                If TO_CHK_MCA_YN(GmoduleName) = True And (gUserCategory <> "S" And ModuleAdmin <> True) And Autherize = "N" Then
                    MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'clearoperation()
                    Exit Sub
                End If
                ' End
            End If

        Else
            voidoperationupdate()
            addoperation()
        End If
    End Sub

    Private Sub voidoperationupdate()
        Dim insert(0) As String
        Dim seq As Double
        'sqlstring = "UPDATE STOCKADJUSTHEADER SET "
        'sqlstring = sqlstring & " Void='Y',voiduser='" & Trim(gUsername) & "',"
        'sqlstring = sqlstring & " voidtime=getDate()"
        'sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        sqlstring = "delete from STOCKADJUSTHEADER  WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        insert(0) = sqlstring

        sqlstring = "delete from STOCKADJUSTDETAILS  WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        'sqlstring = "UPDATE  STOCKADJUSTDETAILS set Void='Y' WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring




        'sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        'sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
        'gconnection.getDataSet(sqlstring, "closingqty")
        'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '    seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        'End If

        If GACCPOST.ToUpper() = "Y" Then
            'sqlstring = "update  JOURNALENTRY_DEMO set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "'"
            sqlstring = "delete from  JOURNALENTRY  where VoucherNo='" & Trim(txt_Docno.Text) & "'"

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
        End If

        'sqlstring = "delete from  closingqty  where trnno='" & Trim(txt_Docno.Text) & "'"

        'ReDim Preserve insert(insert.Length)
        'insert(insert.Length - 1) = sqlstring

        'For i As Integer = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = i

        '    Dim qty1 As Double
        '    Dim batchyn As String
        '    Dim uom As String
        '    Dim uom1 As String
        '    Dim convvalue As Double
        '    Dim batchno As String
        '    Dim itemcode As String
        '    Dim qty As Double
        '    AxfpSpread1.Col = 3
        '    uom1 = AxfpSpread1.Text
        '    AxfpSpread1.Col = 4
        '    batchno = AxfpSpread1.Text
        '    AxfpSpread1.Col = 1
        '    itemcode = AxfpSpread1.Text
        '    Dim sql1 As String
        '    sql1 = "select qty,isnull(batchno,'') as  batchno,uom,isnull(batchyn,'N') as  batchyn from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
        '    sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
        '    If (batchno <> "") Then
        '        sql1 = sql1 & " and  batchno='" + batchno + "' "
        '    End If

        '    gconnection.getDataSet(sql1, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '        uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
        '        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
        '        convvalue = gconnection.getvalue(sql)
        '    Else
        '        qty1 = 0
        '        convvalue = 1
        '    End If
        '    sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + ",qty=" + Format(Val(0 / convvalue), "0.000") + ""
        '    sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    If (batchyn = "Y") Then
        '        sql1 = sql1 & "  and  batchno='" + batchno + "'"
        '    End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = sql1

        '    sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1)), "0.000") + ""
        '    ',closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
        '    ',openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
        '    sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    If (batchyn = "Y") Then
        '        sql1 = sql1 & "  and  batchno='" + txt_Docno.Text + "'"
        '    End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = sql1

        'Next
        'sqlstring = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
        'sqlstring = sqlstring & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
        'sqlstring = sqlstring & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
        'sqlstring = sqlstring & " from inv_Inventoryuomstorelink a inner join closingqty b"
        'sqlstring = sqlstring & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
        'ReDim Preserve insert(insert.Length)
        'insert(insert.Length - 1) = sqlstring

        'gconnection.MoreTrans1(insert)
        ''For k As Integer = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = k
        '    AxfpSpread1.Col = 1
        '    gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, seq)

        'Next
        gconnection.MoreTrans1(insert)

    End Sub



    Private Sub voidoperation()
        Dim insert(0) As String
        Dim seq As Double
        sqlstring = "UPDATE STOCKADJUSTHEADER SET "
        sqlstring = sqlstring & " Void='Y',voiduser='" & Trim(gUsername) & "',"
        sqlstring = sqlstring & " voidtime=getDate()"
        sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        insert(0) = sqlstring
        sqlstring = "UPDATE  STOCKADJUSTDETAILS set Void='Y' WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring




        ' sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        'sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
        'gconnection.getDataSet(sqlstring, "closingqty")
        'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '    seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        'End If

        If GACCPOST.ToUpper() = "Y" Then
            sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
        End If

        'For i As Integer = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = i

        '    Dim qty1 As Double
        '    Dim batchyn As String
        '    Dim uom As String
        '    Dim uom1 As String
        '    Dim convvalue As Double
        '    Dim batchno As String
        '    Dim itemcode As String
        '    Dim qty As Double
        '    AxfpSpread1.Col = 3
        '    uom1 = AxfpSpread1.Text
        '    AxfpSpread1.Col = 4
        '    batchno = AxfpSpread1.Text
        '    AxfpSpread1.Col = 1
        '    itemcode = AxfpSpread1.Text
        '    Dim sql1 As String
        '    sql1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
        '    sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
        '    If (batchno <> "") Then
        '        sql1 = sql1 & " and  batchno='" + batchno + "' "
        '    End If

        '    gconnection.getDataSet(sql1, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '        uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
        '        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
        '        convvalue = gconnection.getvalue(sql)
        '    Else
        '        qty1 = 0
        '        convvalue = 1
        '    End If
        '    sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + ",qty=" + Format(Val(0 / convvalue), "0.000") + ""
        '    sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    If (batchyn = "Y") Then
        '        sql1 = sql1 & "  and  batchno='" + batchno + "'"
        '    End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = sql1

        '    sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1)), "0.000") + ""
        '    ',closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
        '    ',openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
        '    sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    If (batchyn = "Y") Then
        '        sql1 = sql1 & "  and  batchno='" + txt_Docno.Text + "'"
        '    End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = sql1

        'Next
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
        'For k As Integer = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = k
        '    AxfpSpread1.Col = 1
        '    sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        '    sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' AND ITEMCODE='" + AxfpSpread1.Text + "' "
        '    gconnection.getDataSet(sqlstring, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        seq = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        '    End If
        '    gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, seq)

        'Next


    End Sub

    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String
        Dim message, title, defaultValue As String
        Dim Physicalstock, stockinhand, adjustedstock, rate1 As Double
        Dim myValue As Object
        Dim uom1 As String
        Dim sql1 As String
        If e.keyCode = Keys.Enter Then
            i = AxfpSpread1.ActiveRow
            'ITEMCODE
            AxfpSpread1.Row = i
            If AxfpSpread1.ActiveCol = 1 Then
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
                        SQL = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                        gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                        AxfpSpread1.Col = 3
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                        Next Z
                        If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES1" Then


                            ' gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            '                     GroupBox5.Visible = True
                            ' Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                            sql1 = "with a as ( "
                            sql1 = sql1 & " select MAX(trndate) as trndate,itemcode,storecode,isnull(batchno,'') as  batchno from closingqty WHERE TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                            sql1 = sql1 & " group by itemcode,storecode,batchno"
                            sql1 = sql1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,closingqty.uom as uom from a inner  join closingqty on "
                            sql1 = sql1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                            sql1 = sql1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                            'SQL1 = SQL1 & " "
                            sql1 = sql1 & " and   a.storecode=closingqty.storecode  "
                            sql1 = sql1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                            sql1 = sql1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND A.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate "


                            'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                            'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "

                            gconnection.getDataSet(sql1, "closingtable")
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
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

                                Next
                                AxfpSpread2.SetActiveCell(1, 5)
                                AxfpSpread2.Focus()

                            End If
                            Calculate()
                        Else
                            Dim convvalue As Double

                            'SQL = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                            'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                            'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                            '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")

                            '    'If rateflag = "W" Then
                            '    '    sql1 = " select TOP 1  weightedrate as rate,uom from vw_ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' "
                            '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                            '    'Else
                            '    '    sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' "
                            '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                            '    'End If
                            '    If rateflag = "W" Then
                            '        ' sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                            '        'sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                            '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                            '    Else
                            '        'sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                            '        'sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                            '        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
                            '    End If
                            '    gconnection.getDataSet(sql1, "ratelist")
                            '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                            '        Dim pr As Double

                            '        AxfpSpread1.Col = 3
                            '        sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                            '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                            '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                            '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                            '        Else
                            '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                            '            Exit Sub
                            '        End If
                            '        AxfpSpread1.Col = 8
                            '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                            '    Else
                            '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and isnull(openningqty,0)<>0 "
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
                            '            AxfpSpread1.Col = 8
                            '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                            '        Else
                            '            AxfpSpread1.Col = 8
                            '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            '            AxfpSpread1.Text = "0"

                            '        End If
                            '    End If


                            'End If

                            AxfpSpread1.Col = 4
                            AxfpSpread1.ColHidden = True
                            gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), "")
                            If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
                                sqlstring = "SELECT ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,D.DOCDATE AS DOCDATE,ISNULL(D.storecode,'') AS STORELOCATIONCODE,  "
                                sqlstring = sqlstring & " ISNULL(D.STOREDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
                                sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(c.openningstock,0) AS STOCKINHAND,ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK,"
                                sqlstring = sqlstring & " ISNULL(D.PHYSICALSTOCK -c.openningstock ,0) AS ADJUSTEDSTOCK,ISNULL(D.batchno,0) AS batchno,isnull(c.rate,0) as rate,isnull(amount,0) as amount,isnull(remarks2,'')as remarks2 "
                                sqlstring = sqlstring & "  FROM STOCKADJUSTDETAILS AS D inner join closingqty c on c.itemcode=d.Itemcode and c.Trnno=d.Docdetails WHERE  ISNULL(D.DOCDETAILS,'')='" & Trim(txt_Docno.Text) & "' And c.ttype ='ADJUSTMENT'"
                                gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS1")
                                If gdataset.Tables("STOCKADJUSTDETAILS1").Rows.Count > 0 Then
                                    Physicalstock = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("PHYSICALSTOCK")
                                    stockinhand = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("STOCKINHAND")
                                    adjustedstock = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("ADJUSTEDSTOCK")
                                    rate1 = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("rate")
                                End If
                            End If
                            Dim closingqty, rate As Double
                            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                            Else
                                closingqty = 0
                                rate = 0
                            End If
                            uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                            SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")) + "'"
                            gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                            Else
                                convvalue = 0
                            End If
                            closingqty = closingqty * convvalue

                            If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
                                AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(rate1), "0.000"))
                                AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(stockinhand), "0.000"))
                                AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Format(Val(Physicalstock), "0.000"))
                                AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(adjustedstock), "0.000"))
                                AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                            Else
                                AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(rate / convvalue), "0.000"))
                                AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))
                                AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                            End If
                            'If (GBATCHNO = "Y") Then
                            '    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                            'Else
                            AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                            '  End If
                        End If

                    Else

                    End If
                    'SQL = "select taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                    'gconnection.getDataSet(SQL, "Itemtaxtagging")
                    'If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                    '    AxfpSpread1.Col = 8
                    '    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                    '    AxfpSpread1.Col = 12
                    '    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '    AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("GLACCOUNTIN")
                    'Else
                    '    MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    'End If
                    '    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    'Else
                    '    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    'End If

                End If                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 2 Then
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
                        SQL = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                        gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                        Next Z
                        If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES" Then
                            '  gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            GroupBox5.Visible = True
                            '  Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                            'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                            'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                            sql1 = "with a as ( "
                            sql1 = sql1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                            sql1 = sql1 & " group by itemcode,storecode,batchno"
                            sql1 = sql1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,closingqty.uom as uom from a inner  join closingqty on "
                            sql1 = sql1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                            sql1 = sql1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                            'SQL1 = SQL1 & " "
                            sql1 = sql1 & " and   a.storecode=closingqty.storecode  "
                            sql1 = sql1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                            sql1 = sql1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND A.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate "


                            gconnection.getDataSet(sql1, "closingtable")
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
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

                                Next
                                AxfpSpread2.SetActiveCell(1, 5)
                                AxfpSpread2.Focus()

                            Else
                                Dim convvalue As Double

                                'SQL = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                                'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                                '    'If rateflag = "W" Then
                                '    '    SQL1 = " select TOP 1  weightedrate as rate,uom from vw_ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' "
                                '    '    SQL1 = SQL1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                                '    'Else
                                '    '    SQL1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' "
                                '    '    SQL1 = SQL1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                                '    'End If
                                '    If rateflag = "W" Then

                                '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                                '    Else
                                '        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
                                '    End If
                                '    gconnection.getDataSet(sql1, "ratelist")
                                '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                                '        Dim pr As Double

                                '        AxfpSpread1.Col = 3
                                '        sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                                '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                                '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                '        Else
                                '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                                '            Exit Sub
                                '        End If
                                '        AxfpSpread1.Col = 8
                                '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                                '    Else
                                '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and isnull(openningqty,0)<>0 "
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
                                '            AxfpSpread1.Col = 8
                                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                                '        Else
                                '            AxfpSpread1.Col = 8
                                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                '            AxfpSpread1.Text = "0"

                                '        End If
                                '    End If


                                'End If
                                AxfpSpread1.Col = 4
                                AxfpSpread1.ColHidden = True
                                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), "")

                                If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
                                    sqlstring = "SELECT ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,D.DOCDATE AS DOCDATE,ISNULL(D.storecode,'') AS STORELOCATIONCODE,  "
                                    sqlstring = sqlstring & " ISNULL(D.STOREDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
                                    sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(c.openningstock,0) AS STOCKINHAND,ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK,"
                                    sqlstring = sqlstring & " ISNULL(D.PHYSICALSTOCK -c.openningstock ,0) AS ADJUSTEDSTOCK,ISNULL(D.batchno,0) AS batchno,isnull(c.rate,0) as rate,isnull(amount,0) as amount,isnull(remarks2,'')as remarks2 "
                                    sqlstring = sqlstring & "  FROM STOCKADJUSTDETAILS AS D inner join closingqty c on c.itemcode=d.Itemcode and c.Trnno=d.Docdetails WHERE  ISNULL(D.DOCDETAILS,'')='" & Trim(txt_Docno.Text) & "' And c.ttype ='ADJUSTMENT'"
                                    gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS1")
                                    If gdataset.Tables("STOCKADJUSTDETAILS1").Rows.Count > 0 Then
                                        Physicalstock = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("PHYSICALSTOCK")
                                        stockinhand = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("STOCKINHAND")
                                        adjustedstock = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("ADJUSTEDSTOCK")
                                        rate1 = gdataset.Tables("STOCKADJUSTDETAILS1").Rows(0).Item("rate")
                                    End If
                                End If

                                Dim closingqty, rate As Double
                                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                    rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                                Else
                                    closingqty = 0
                                    rate = 0
                                End If
                                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                                SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                                Else
                                    convvalue = 0
                                End If
                                closingqty = closingqty * convvalue
                                If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
                                    AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(rate1), "0.000"))
                                    AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(stockinhand), "0.000"))
                                    AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Format(Val(Physicalstock), "0.000"))
                                    AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(adjustedstock), "0.000"))
                                    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                                Else
                                    AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(rate / convvalue), "0.000"))
                                    AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))
                                    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                                End If
                            End If
                        Else
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

                Dim ITEMCODE As String
                ITEMCODE = AxfpSpread1.Text

                AxfpSpread1.Col = 4
                AxfpSpread1.ColHidden = True
                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), "")

                AxfpSpread1.Col = 3
                Dim UOM As String = AxfpSpread1.Text

                Dim closingqty, rate As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                    uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                Else
                    closingqty = 0
                    rate = 0
                    uom1 = UOM
                End If



                SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + Trim(UOM) + "'"
                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    convvalue = 0
                End If
                closingqty = closingqty * convvalue

                AxfpSpread1.SetText(8, AxfpSpread1.ActiveRow, Format(Val(rate / convvalue), "0.000"))
                AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))
                ' AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))
                AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)


                'SQL = "    sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER inner join inv_inventoryitemmaster on"
                'SQL = SQL & " inv_inventoryitemmaster.category = INVENTORYCATEGORYMASTER.CATEGORYCODE where itemcode='" + Trim(ITEMCODE) + "'"
                ''  sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")

                '    'If rateflag = "W" Then
                '    '    sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(ITEMCODE) + "' "
                '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                '    'Else
                '    '    sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(ITEMCODE) + "' "
                '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                '    'End If
                '    If rateflag = "W" Then

                '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + Trim(ITEMCODE) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                '    Else
                '        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + Trim(ITEMCODE) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
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
                '        AxfpSpread1.Col = 8
                '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                '    Else
                '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(0).Item("itemcode")) + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and isnull(openningqty,0) <>0 "
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
                '            AxfpSpread1.Col = 8
                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                '        End If
                '    End If
                'End If
                'AxfpSpread1.Col = 1
                'ITEMCODE = AxfpSpread1.Text
                'AxfpSpread1.Col = 3
                'Dim UOM As String = AxfpSpread1.Text
                'Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                'gconnection.getDataSet(sql11, "closingtable")
                'Dim closingqty As Double
                'If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                '    closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

                'Else
                '    closingqty = 0
                'End If
                'uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                'sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
                'gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")

                'If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                'Else
                '    convvalue = 1
                'End If
                'closingqty = closingqty * convvalue

                'AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))


            ElseIf AxfpSpread1.ActiveCol = 4 Then
                'If GBATCHNO = "Y" Then
                '    AxfpSpread1.Col = 4
                '    BatchNoSelection()
                'End If


                AxfpSpread1.Col = 4
                If (Val(AxfpSpread1.Text) <> 0) Then
                    Dim dMGqty As Double = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 8
                    Dim RATE As Double = Val(AxfpSpread1.Text)

                    AxfpSpread1.Col = 9
                    AxfpSpread1.Text = dMGqty * RATE

                    AxfpSpread1.Col = 1
                    Dim itemcode As String = AxfpSpread1.Text
                    AxfpSpread1.Col = 4
                    Dim Batchno As String = AxfpSpread1.Text
                    SQL = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
                    gconnection.getDataSet(SQL, "INV_InventoryItemMaster")
                    If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                        If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
                            AxfpSpread1.Col = 3
                            Dim uom As String = AxfpSpread1.Text
                            '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                            Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                            gconnection.getDataSet(sql11, "closingstock")

                            'If GBATCHNO = "Y" Then
                            '    gconnection.BatchWiseClosingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), Batchno)
                            'End If
                            Dim closingqty As Double
                            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")

                            Else
                                closingqty = 0
                            End If
                            uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                            SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                            gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                            Dim convvalue As Double
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                            Else
                                convvalue = 0
                            End If
                            closingqty = closingqty * convvalue
                            If (dMGqty > closingqty) Then
                                MessageBox.Show("Issued Quantity Cannot be Greater than Closing Quantity" + closingqty.ToString())
                                AxfpSpread1.SetActiveCell(5, AxfpSpread1.Row)

                            End If
                        End If

                    End If
                    Calculate()
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                    '        End If


                End If
                Calculate()
                If (GroupBox5.Visible = True) Then
                    AxfpSpread2.SetActiveCell(5, 1)
                    AxfpSpread2.Focus()
                Else


                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                End If
            ElseIf AxfpSpread1.ActiveCol = 6 Then
                AxfpSpread1.Col = 6
                If Val(AxfpSpread1.Text) >= 0 And AxfpSpread1.Text <> "" Then
                    'Dim stockinhand As Double
                    'Dim physicalstock As Double
                    Dim rate As Double
                    Dim remarks2 As String
                    physicalstock = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 5
                    stockinhand = Val(AxfpSpread1.Text)
                    AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, Format(Val(physicalstock) - Val(stockinhand), "0.000"))
                    AxfpSpread1.Col = 8
                    rate = Val(AxfpSpread1.Text)
                    AxfpSpread1.SetText(9, AxfpSpread1.ActiveRow, Format(Val((physicalstock) - Val(stockinhand)) * rate, "0.000"))

                    AxfpSpread1.SetActiveCell(10, AxfpSpread1.ActiveRow)



                End If



                'AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)

            ElseIf AxfpSpread1.ActiveCol = 10 Then
                AxfpSpread1.Col = 10

                If AxfpSpread1.Text = "" Then
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    'AxfpSpread1.Text = ""
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                Else
                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                End If
            ElseIf AxfpSpread1.ActiveCol = 12 Then
                If GSHELVING = "Y" Then
                    AxfpSpread1.Col = 12
                    Fromshelf()
                End If

            ElseIf (e.keyCode = Keys.F3) Then
                If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                    AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)

                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                End If

                '   Calculate()





            End If
            Calculate()

            If (GroupBox5.Visible = True) Then
                AxfpSpread2.SetActiveCell(5, 1)
                AxfpSpread2.Focus()
                Me.Focus()
            End If
        ElseIf (e.keyCode = Keys.F3) Then
            If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)

                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
            End If

            '   Calculate()
            'ElseIf e.keyCode = Keys.F1 Then
            '    Dim Advsearch As New frmListSearch
            '    Advsearch.Text = AxfpSpread1.Text
            '    Advsearch.Text = "Item Search"
            '    Advsearch.ShowDialog(Me)

        ElseIf e.keyCode = Keys.F1 Then
            Dim search As New frmSearch
            search.farPoint = AxfpSpread1
            search.Text = "Item Search"
            search.ShowDialog(Me)
            Exit Sub
        End If
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
                AxfpSpread1.Col = 12
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.SetActiveCell(12, 1)
                AxfpSpread1.Focus()
            Else
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If
        End If
    End Sub
    Private Function check_Duplicate(ByVal Itemcode As String) As Boolean
        Dim i As Integer
        Dim uom, SQL As String
        AxfpSpread1.Col = 3
        uom = AxfpSpread1.Text
        AxfpSpread1.Col = 1
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            If i <> AxfpSpread1.ActiveRow Then
                If Trim(AxfpSpread1.Text) = Trim(Itemcode) Then
                    Sql = "SELECT * FROM uommaster WHERE uomcode='" + uom + "' AND ISNULL(isweight,'NO')='YES' "
                    gconnection.getDataSet(Sql, "WM")
                    If (gdataset.Tables("WM").Rows.Count > 0) Then
                        Return False
                    Else
                        MsgBox("Item Already exists", MsgBoxStyle.Critical, "Duplicate")
                        Return True
                    End If
                End If
            End If
        Next
        Return False
    End Function

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
            AxfpSpread1.Col = 4
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield2)
            AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
            AxfpSpread1.Focus()
        End If
    End Sub



    Private Sub cmd_Docnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Docnohelp.Click
        Try
            gSQLString = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE FROM STOCKADJUSTHEADER"
            M_WhereCondition = ""
            M_ORDERBY = "order by DOCDETAILS desc,autoid desc"
            Dim vform As New List_Operation
            vform.Field = "DOCDETAILS,DOCDATE"
            vform.vFormatstring1 = "       DOC NO                       |         DOC DATE                                                           "
            vform.vCaption = "STOCK ADJUSTMENT HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Docno.Text = Trim(vform.keyfield & "")
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Call txt_Docno_Validated(txt_Docno, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub Frm_Adjustment_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.KeyCode = Keys.F9 And cmd_Print.Visible = True Then
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

    Private Sub Frm_Adjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.DoubleBuffered = True

        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        Dim sqlstring As String = "Select getdate()"
        adate = gconnection.getvalue(sqlstring)

        'Resize_Form()
        autogenerate()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If

        Me.Cursor = Cursors.WaitCursor
        ' Call Check()
        Me.Cursor = Cursors.Default

        Me.dtp_Docdate.Focus()

        If gShortname = "RSAOI" Then
            Me.Cmdauth.Visible = True
            CHECKUSER()
        End If
    End Sub
    Sub CHECKUSER()

        sqlstring = "SELECT * FROM MCARIGHTS WHERE  MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' "
        gconnection.getDataSet(sqlstring, "USERADMIN")
        If gdataset.Tables("USERADMIN").Rows.Count > 0 Then
            Dim USERNAME As String
            If UCase(gUsername) = UCase(gdataset.Tables("USERADMIN").Rows(0).Item("CHECKER1ID")) Then
                Cmdauth.Enabled = True
                Cmdauth.Text = "CHECKER PENDING [F5]"
            ElseIf UCase(gUsername) = UCase(gdataset.Tables("USERADMIN").Rows(0).Item("CHECKER2ID")) Then
                Cmdauth.Enabled = True
                Cmdauth.Text = "CHECKER PENDING [F5]"
            ElseIf UCase(gUsername) = UCase(gdataset.Tables("USERADMIN").Rows(0).Item("AUTHOR1ID")) Then
                Cmdauth.Enabled = True
                Cmdauth.Text = "AUTHORIZER PENDING [F5]"
            ElseIf UCase(gUsername) = UCase(gdataset.Tables("USERADMIN").Rows(0).Item("AUTHOR2ID")) Then
                Cmdauth.Enabled = True
                Cmdauth.Text = "AUTHORIZER PENDING [F5]"
            ElseIf UCase(gUsername) = UCase(gdataset.Tables("USERADMIN").Rows(0).Item("AUTHOR3ID")) Then
                Cmdauth.Enabled = True
                Cmdauth.Text = "AUTHORIZER PENDING [F5]"
            End If
        End If
        If gUserCategory = "A" And ModuleAdmin = True Then
            If Mid(Cmd_Add.Text, 1, 1) = "U" And Autherize = "Y" Then
                Me.Cmd_Add.Enabled = True
            End If
        End If

    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "Stock Adjustment"

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
                        If Controls(i_i).Name = "frmbut" Then
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

    Private Sub Calculate()
        Try
            Dim ValQty As Double
            Dim Calqty As Double
            Dim Itemcode As String
            Dim i, j As Integer
            '  If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 3 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Then




            Me.txt_Totalqty.Text = ""
            For i = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Col = 4
                AxfpSpread1.Row = i
                ValQty = Val(AxfpSpread1.Text)
                Me.txt_Totalqty.Text = Format(Val(Me.txt_Totalqty.Text) + Val(ValQty), "0.000")
            Next i

            'End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub AxfpSpread2_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread2.KeyDownEvent
        If (e.keyCode = Keys.Enter) Then
            If AxfpSpread2.ActiveCol = 5 Then
                AxfpSpread2.Row = AxfpSpread2.ActiveRow
                AxfpSpread2.Col = 5
                Dim batchqty As Double = Val(AxfpSpread2.Text)
                AxfpSpread2.Col = 3
                Dim clsqty As Double = Val(AxfpSpread2.Text)
                Dim qty1 As Double = batchqty - clsqty
                AxfpSpread2.SetText(6, AxfpSpread2.ActiveRow, Val(qty1))
                'If (batchqty > clsqty) Then
                '    MessageBox.Show("Adjusted Quantity Must be Less Than Closing Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    AxfpSpread2.SetText(5, AxfpSpread2.ActiveRow, "0.000")
                '    AxfpSpread2.SetActiveCell(5, AxfpSpread2.ActiveRow)

                'End If
                ''If (indentqty < batchqty) Then
                '    MessageBox.Show("Issued Quantity Must be Less Than indent Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                '    AxfpSpread2.SetActiveCell(5, AxfpSpread2.ActiveRow)
                'Else

                'End If
                AxfpSpread2.SetActiveCell(5, AxfpSpread2.ActiveRow + 1)
            Else
                AxfpSpread2.SetActiveCell(5, AxfpSpread2.ActiveRow + 1)
            End If

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

        If gcompname = "MRC" Or Mid(UCase(gShortname), 1, 3) = "MRC" Then
            Return False
            Exit Function
        End If

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
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If
        If DateDiff(DateInterval.Day, (CDate(dtp_Docdate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("Doc Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If txt_Docno.Text = "" Then
            MessageBox.Show("Please Fill AdjustmentDocno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = i + 1

            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 7
            Dim qty As String = Val(AxfpSpread1.Text)
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim convvalue As Double
            Dim batchno As String
            AxfpSpread1.Col = 4
            batchno = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            uom1 = AxfpSpread1.Text
            Dim sql As String
            sql = "select closingstock +" + Format(Val(qty), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(qty), "0.000") + "<0 and ITEMCODE='" & itemcode & "'AND  storecode='" + TXT_FROMSTORECODE.Text + "' "
            'If batchyn = "Y" Then
            '    sql = sql & " and batchno='" + batchno + "'"
            'End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                'MessageBox.Show("Adjustment  create " + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                'flag = True
                'Return flag
            End If
            sqlstring = "Select getdate()"
            adate = gconnection.getvalue(sqlstring)
            'If (Format(CDate(adate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
            '    Dim count As Double = 0


            '    sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate "

            '    gconnection.getDataSet(sql, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

            '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
            '        count = count + Val(qty)
            '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
            '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
            '            If count < 0 Then
            '                MessageBox.Show("Adjustment create  " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        Next
            '    End If
            'End If




        Next
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If


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
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("ADJGLCODE")
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
                            sqlstring = "select accountcode,ADJGLCODE,AC.CategoryCode  from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category WHERE IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("ADJGLCODE")
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
                        TRNCODE = gdataset.Tables("CODE").Rows(0).Item("ADJGLCODE")
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
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
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
            MessageBox.Show("Doc Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
            AxfpSpread1.Col = 7
            Dim qty As String = Val(AxfpSpread1.Text)
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim convvalue As Double
            Dim batchno As String
            AxfpSpread1.Col = 4
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
            sql = "select closingstock +" + Format(Val(+(qty / convvalue) - qty1), "0.000") + " from closingqty where itemcode='" + itemcode + "' and trndate>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(+(qty / convvalue) - qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' "
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")


            '' ------------------------ Allow nagative---------------------
            'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '    MessageBox.Show("Updation create " + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    flag = True
            '    Return flag
            'End If
            '' ------------------------ Allow nagative---------------------

            'If (Format(CDate(adate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
            '    Dim count As Double = 0


            '    sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate,priority "

            '    gconnection.getDataSet(sql, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

            '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
            '        count = count + Val(qty - qty1)
            '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
            '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
            '            If count < 0 Then
            '                MessageBox.Show("Adjustment create  " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        Next
            '    End If
            'End If
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
                                accode = gdataset.Tables("CODE").Rows(0).Item("ADJGLcode")

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

                    For k As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = k
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "select accountcode,ADJGLCODE,AC.CategoryCode  from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category WHERE IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("ADJGLcode")
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("ADJGLCODE")
                                If accode = "" Or TRNCODE = "" Then

                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(gdataset.Tables("CODE").Rows(0).Item("CategoryCode")) + "")
                                    flag = True
                                    Return flag

                                End If
                            Else
                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY  " + Trim(AxfpSpread1.Text) + "")
                                flag = True
                                Return flag
                            End If
                        End If

                    Next



                Else
                    sqlstring = "Select * from AccountstaggingnEW where CODE='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("ADJGLcode")
                        If accode = "" Then

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
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ADJUSTMENT")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ADJUSTMENT")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If

                sqlstring = " exec proc_closingqtyone 'ADJUSTMENT_ADD' "
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
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ADJUSTMENT")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ADJUSTMENT")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If

                sqlstring = " exec proc_closingqtyone 'ADJUSTMENT_UPDATE' "
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
    Private Function validateonvoid() As Boolean


        If gcompname = "MRC" Or Mid(UCase(gShortname), 1, 3) = "MRC" Then
            Return False
            Exit Function
        End If

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
            'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '    MessageBox.Show("Deletion create" + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    flag = True
            '    Return flag
            'End If


            If (Format(CDate(adate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
                Dim count As Double = 0


                sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate,priority "

                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then

                    count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
                    count = count - Val(qty1)
                    For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
                        count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
                        If count < 0 Then
                            MessageBox.Show("Adjustment create  " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag
                        End If
                    Next
                End If
            End If
        Next

        Return False
    End Function

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        If MsgBox("Do you want to Void this Record", MsgBoxStyle.Question + MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, Me.Text) = MsgBoxResult.Ok Then
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
                        strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ADJUSTMENT")

                    Else
                        strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ADJUSTMENT")
                        sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                        gconnection.ExcuteStoreProcedure(sqlstring)
                    End If

                    sqlstring = " exec proc_closingqtyone 'ADJUSTMENT_VOID' "
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
        End If
    End Sub

    Private Sub ButOK_Click(sender As Object, e As EventArgs) Handles ButOK.Click
        Dim SQL As String
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
        Dim convvalue As Double
        K = AxfpSpread1.ActiveRow
        If AxfpSpread2.DataRowCnt >= 1 Then
            AxfpSpread2.Col = 1
            itemcode = AxfpSpread2.Text

            For l As Integer = 1 To AxfpSpread2.DataRowCnt
                AxfpSpread2.Row = l
                AxfpSpread2.Col = 5
                batchqty = Val(AxfpSpread2.Text)
                row = l
                AxfpSpread2.Col = 4
                uom = AxfpSpread2.Text
                AxfpSpread1.Col = 3
                uom1 = AxfpSpread1.Text
                SQL = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
                Else
                    convvalue = 1
                End If
                If (batchqty <> 0) Then
                    If (m = 1) Then
                        AxfpSpread2.Row = l
                        AxfpSpread1.SetText(6, K, batchqty * convvalue)
                        AxfpSpread2.Col = 2
                        AxfpSpread1.SetText(4, K, AxfpSpread2.Text)
                        AxfpSpread2.Col = 3
                        AxfpSpread1.SetText(5, K, AxfpSpread2.Text)
                        AxfpSpread2.Col = 6
                        AxfpSpread1.SetText(7, K, AxfpSpread2.Text)

                        ' If (GINDENTNO = "Y") Then
                        '    AxfpSpread1.Col = 4
                        '    INDQTY = Val(AxfpSpread1.Text)
                        '    AxfpSpread1.SetText(4, K, batchqty * convvalue)
                        'End If
                    Else
                        AxfpSpread1.InsertRows(K + m, 1)
                        SQL = " select I.itemcode,Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                        SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(I.itemcode,'')='" + Trim(itemcode) + "'"
                        gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                            AxfpSpread1.SetText(1, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            AxfpSpread1.SetText(3, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            AxfpSpread2.Row = l
                            AxfpSpread1.SetText(6, K + m - 1, batchqty * convvalue)
                            AxfpSpread2.Col = 2
                            AxfpSpread1.SetText(4, K + m - 1, AxfpSpread2.Text)
                            AxfpSpread2.Col = 3
                            AxfpSpread1.SetText(5, K + m - 1, AxfpSpread2.Text)
                            AxfpSpread2.Col = 6
                            AxfpSpread1.SetText(7, K + m - 1, AxfpSpread2.Text)

                            '     AxfpSpread2.Col = 5
                            '    AxfpSpread1.SetText(7, K, AxfpSpread2.Text)
                            'If (GINDENTNO = "Y") Then
                            '    If (batchqty * convvalue < INDQTY - totbatchqty) Then
                            '        AxfpSpread1.SetText(4, K + m - 1, batchqty * convvalue)

                            '    Else
                            '        AxfpSpread1.SetText(4, K + m - 1, INDQTY - totbatchqty)

                            '    End If
                            'End If
                        End If

                    End If
                    m = m + 1
                    totbatchqty = totbatchqty + (batchqty * convvalue)
                    AxfpSpread1.SetActiveCell(1, K + m - 1)
                    '  Calculate()
                End If

            Next
        End If
        For i As Integer = 0 To AxfpSpread2.DataRowCnt
            AxfpSpread2.Col = 5
            qty += Val(AxfpSpread2.Text)

        Next
        GroupBox5.Visible = False

    End Sub

    Private Sub ButCancel_Click(sender As Object, e As EventArgs) Handles ButCancel.Click
        GroupBox5.Visible = False

    End Sub

    Private Sub txt_Docno_Validated(sender As Object, e As EventArgs) Handles txt_Docno.Validated
        Dim vString, sqlstring, Stritemcode, remarks As String
        Dim Clsquantity As Double
        Dim dt As New DataTable
        Dim j, i As Integer
        If Trim(txt_Docno.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(DOCNO,'') AS DOCNO,ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(storecode,'') AS STORELOCATIONCODE, "
                If gShortname = "RSAOI" Then
                    sqlstring = sqlstring & " isnull(authorised,'') as authorised,isnull(MCA,'') as MCA, "
                End If
                sqlstring = sqlstring & " ISNULL(storedesc,'') AS STORELOCATIONDESC ,"
                sqlstring = sqlstring & " ISNULL(REMARKS,'') AS REMARKS,ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,"
                sqlstring = sqlstring & " ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,UPDATETIME FROM STOCKADJUSTHEADER "
                sqlstring = sqlstring & "  WHERE DOCNO='" & Trim(txt_Docno.Text) & "'OR DOCDETAILS='" & Trim(txt_Docno.Text) & "'"
                gconnection.getDataSet(sqlstring, "STOCKADJUSTHEADER")
                '''************************************************* SELECT RECORD FROM STOCKADJUSTHEADER *********************************************''''                
                If gdataset.Tables("STOCKADJUSTHEADER").Rows.Count > 0 Then
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Docno.ReadOnly = True
                    txt_Docno.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("DOCDETAILS"))
                    dtp_Docdate.Value = Format(CDate(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("DOCDATE")), "dd/MMM/yyyy")
                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("STORELOCATIONCODE"))
                    txt_FromStorename.Text = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("STORELOCATIONDESC"))

                    If gShortname = "RSAOI" Then
                        '========================# IM POLICY CODE START #===========================
                        Autherize = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("Authorised") & "")
                        MCA = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("MCA") & "")
                        '========================# IM POLICY CODE END #===========================
                    End If
                    'txt_Totalamount.Text = Format(Val(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("ADJUSTEDAMOUNT")), "0.000")
                    'txt_Totalqty.Text = Format(Val(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("STOCKINHAND")), "0.000")
                    'txt_Physicalstock.Text = Format(Val(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("PHYSICALSTOCK")), "0.000")

                    remarks = Trim(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("REMARKS") & "")
                    txt_Remarks.Text = Replace(remarks, "?", "'")
                    If gdataset.Tables("stockadjustheader").Rows(0).Item("VOID") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("STOCKADJUSTHEADER").Rows(0).Item("UPDATETIME")), "dd/MMM/yyyy")
                        Me.Cmd_Freeze.Enabled = False
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.Cmd_Freeze.Enabled = True
                        Me.lbl_Freeze.Text = "Record Void  On "
                        Me.Cmd_Freeze.Text = "Void[F8]"
                        Me.Cmd_Add.Enabled = True
                        Me.Cmd_Freeze.Enabled = True
                    End If

                    '''************************************************* SELECT RECORD FROM STOCKADJUSTEDDETAILS *********************************************''''                
                    sqlstring = "SELECT ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,D.DOCDATE AS DOCDATE,ISNULL(D.storecode,'') AS STORELOCATIONCODE,  "
                    sqlstring = sqlstring & " ISNULL(D.STOREDESC,'') AS STORELOCATIONDESC,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
                    sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(c.openningstock,0) AS STOCKINHAND,ISNULL(D.PHYSICALSTOCK,0) AS PHYSICALSTOCK,"
                    If GSHELVING = "Y" Then
                        sqlstring = sqlstring & "isnull(d.SHELF,'') as Shelf,"
                    End If
                    sqlstring = sqlstring & " ISNULL(D.PHYSICALSTOCK -c.openningstock ,0) AS ADJUSTEDSTOCK,ISNULL(D.batchno,0) AS batchno,isnull(c.rate,0) as rate,isnull(amount,0) as amount,ISNULL(D.void,'N') AS void,isnull(remarks2,'')as remarks2 "
                    sqlstring = sqlstring & "  FROM STOCKADJUSTDETAILS AS D inner join closingqty c on c.itemcode=d.Itemcode and c.Trnno=d.Docdetails WHERE  ISNULL(D.DOCDETAILS,'')='" & Trim(txt_Docno.Text) & "' And c.ttype ='ADJUSTMENT'"
                    gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS1")
                    If gdataset.Tables("STOCKADJUSTDETAILS1").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("STOCKADJUSTDETAILS1").Rows.Count
                            '  Call GridUOM(i)
                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("ITEMCODE")))
                            Stritemcode = Trim(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("ITEMNAME")))
                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = i
                            Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("itemcode") + "'"

                            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z

                            ' AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("UOM"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("UOM"))
                            AxfpSpread1.SetText(5, i, Val(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("STOCKINHAND")))
                            AxfpSpread1.SetText(4, i, gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("batchno"))

                            AxfpSpread1.SetText(6, i, Val(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("PHYSICALSTOCK")))
                            If GSHELVING = "Y" Then
                                AxfpSpread1.Col = 12
                                AxfpSpread1.Row = i
                                AxfpSpread1.SetText(12, i, Trim(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("SHELF")))
                            End If
                            AxfpSpread1.SetText(7, i, Val(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("ADJUSTEDSTOCK")))
                            AxfpSpread1.SetText(8, i, Val(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("rate")))

                            AxfpSpread1.SetText(9, i, Val(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("amount")))

                            AxfpSpread1.SetText(10, i, Trim(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("remarks2")))
                            AxfpSpread1.Col = 11
                            AxfpSpread1.Row = i
                            AxfpSpread1.SetText(11, i, Trim(gdataset.Tables("STOCKADJUSTDETAILS1").Rows(j).Item("void")))


                            j = j + 1
                        Next
                    End If
                    If gUserCategory <> "S" Then
                        '   Call GetRights()
                    End If
                    'TotalCount = gdataset.Tables("STOCKADJUSTDETAILS1").Rows.Count
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
            Dim r

            If UCase(gShortname) = "MLRF" Then
                r = New Crystkadj_MLRF
                sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(STORECODE,'') AS STORECODE,"
                sqlstring = sqlstring & " ISNULL(STOREDESC,'') AS STOREDESC ,"
                sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
                sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(stockinhand,0) AS stockinhand,ISNULL(adjustedstock,0) AS adjustedstock,ISNULL(physicalstock,0) AS physicalstock,ISNULL(RATE,0) AS RATE,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(BAtCHNO,'') AS BAtCHNO,ISNULL(REMARKS,'') AS REMARKS,ISNULL(ADDDATE,'') AS ADDDATE,ISNULL(REMARKS2,'') AS REMARKS2"
                sqlstring = sqlstring & " FROM STOCKADJUSTDETAILS"
                sqlstring = sqlstring & " WHERE DOCDETAILS ='" & Trim(txt_Docno.Text) & "'"
                sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"

            ElseIf UCase(gShortname) = "MLA" Then
                r = New Crystkadj_MLA
            Else
                r = New Crystkadj
            End If
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(STORECODE,'') AS STORECODE,"
            sqlstring = sqlstring & " ISNULL(STOREDESC,'') AS STOREDESC ,"
            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(stockinhand,0) AS stockinhand,ISNULL(adjustedstock,0) AS adjustedstock,ISNULL(physicalstock,0) AS physicalstock,ISNULL(BAtCHNO,'') AS BAtCHNO,ISNULL(REMARKS,'') AS REMARKS,ISNULL(ADDDATE,'') AS ADDDATE,ISNULL(REMARKS2,'') AS REMARKS2"
            sqlstring = sqlstring & " FROM STOCKADJUSTDETAILS"
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
                    textobj11.Text = UCase(Address1)
                    Dim textobj12 As TextObject
                    textobj12 = r.ReportDefinition.ReportObjects("Text16")
                    textobj12.Text = UCase(Address2)
                    Dim textobj23 As TextObject
                    textobj23 = r.ReportDefinition.ReportObjects("Text3")
                    textobj23.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                    Dim textobj2 As TextObject
                    textobj2 = r.ReportDefinition.ReportObjects("Text5")
                    textobj2.Text = gUsername
                    Dim textobj26 As TextObject
                    textobj26 = r.ReportDefinition.ReportObjects("Text26")
                    If UCase(gShortname) = "MLRF" Then
                        textobj26.Text = "          Prepared By:                                                                                                                                                   Approved By:    "
                    End If
                    If UCase(gShortname) = "TMA" Then
                        textobj26 = r.ReportDefinition.ReportObjects("TEXT26")
                    textobj26.Text = "  Store Keeper:                                                                                             Manager: "

                ElseIf UCase(gShortname) = "MLA" Then
                    textobj26 = r.ReportDefinition.ReportObjects("TEXT26")
                    textobj26.Text = "                BAR MAN:                                                                     BAR COMMITTE :                                                                       SECRETARY :                "
                End If

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
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(stockinhand,0) AS stockinhand,ISNULL(adjustedstock,0) AS adjustedstock,ISNULL(physicalstock,0) AS physicalstock,ISNULL(BATCHNO,'') AS BACHNO,ISNULL(REMARKS,'') AS REMARKS,ISNULL(ADDDATE,'') AS ADDDATE,isnull(remarks2,'')as remarks2 "
            sqlstring = sqlstring & " FROM STOCKADJUSTDETAILS"
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
                textobj11.Text = UCase(Address1)
                Dim textobj12 As TextObject
                textobj12 = r.ReportDefinition.ReportObjects("Text16")
                textobj12.Text = UCase(Address2)
                Dim textobj23 As TextObject
                textobj23 = r.ReportDefinition.ReportObjects("Text3")
                textobj23.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text5")
                textobj2.Text = gUsername
                Dim textobj26 As TextObject
                textobj26 = r.ReportDefinition.ReportObjects("Text26")
                If UCase(gShortname) = "MLRF" Then
                    textobj26.Text = "          Prepared By:                                                                                                                                                   Approved By:    "
                End If
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

            AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))

        End If
    End Sub

   
    Private Sub txt_Docno_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Docno.KeyDown
        If txt_Docno.Text <> "" Then
            Call txt_Docno_Validated(txt_Docno.Text, e)
        Else
            cmd_Docnohelp_Click(sender, e)

        End If
    End Sub

    Private Sub AxfpSpread1_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread1.Advance

    End Sub

    Private Sub AxfpSpread2_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread2.Advance

    End Sub

    Private Sub AxfpSpread1_KeyPressEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyPressEvent) Handles AxfpSpread1.KeyPressEvent

    End Sub

    Private Sub Cmdauth_Click(sender As Object, e As EventArgs) Handles Cmdauth.Click
        '========================# IM POLICY CODE START #===========================
        Dim SSQLSTR, SSQLSTR2 As String
        Dim MCA, C, A, F As String
        Dim level As Integer
        Dim multi(2) As String


        multi(0) = "Update STOCKADJUSTHEADER set "
        multi(1) = "Update STOCKADJUSTDETAILS set "

        SSQLSTR2 = " SELECT * FROM  MCARIGHTS WHERE  MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "'"
        gconnection.getDataSet(SSQLSTR2, "MCARIGHTS")
        If gdataset.Tables("MCARIGHTS").Rows.Count > 0 Then
            ''level =1 for MAKER
            level = 1
            If gdataset.Tables("MCARIGHTS").Rows(0).Item("CHECKER") = "Y" Then
                C = "Y"
                level += 1
            End If
            If gdataset.Tables("MCARIGHTS").Rows(0).Item("AUTHORIZER") = "Y" Then
                A = "Y"
                If C Is Nothing Then
                    level += 1
                End If
                level += 1
            End If
            If gdataset.Tables("MCARIGHTS").Rows(0).Item("FINVALIDATION") = "Y" Then
                F = "Y"
            End If
            '' TO  AUTHER
            If C = "Y" Then
                MCA = "'C'" ''IF CHECK IS YES THEN ONLY NEED TO CHECK THE CHECKER RECORDS
            Else
                MCA = "'M'" ''ELSE GET ONLY MAKER RECORDS
            End If
        Else
            MCA = "'M'"
        End If


        If Mid(Cmdauth.Text, 1, 1) = "A" Then
            SSQLSTR2 = " SELECT * FROM MCARIGHTS WHERE  MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND (ISNULL(AUTHOR1ID,'')='" & gUsername & "' OR ISNULL(AUTHOR2ID,'')='" & gUsername & "' OR ISNULL(AUTHOR3ID,'')='" & gUsername & "' )"
            gconnection.getDataSet(SSQLSTR2, "CHECKER")
            If gdataset.Tables("CHECKER").Rows.Count > 0 Then
                If F = "Y" Then
                    Dim findauth1, findauth2, findauth3 As String
                    Dim AUTHERLIMIT1, AUTHERLIMIT2, AUTHERLIMIT3, LIMIT As String

                    findauth1 = UCase(gdataset.Tables("CHECKER").Rows(0).Item("AUTHOR1ID"))
                    findauth2 = UCase(gdataset.Tables("CHECKER").Rows(0).Item("AUTHOR2ID"))
                    findauth3 = UCase(gdataset.Tables("CHECKER").Rows(0).Item("AUTHOR3ID"))

                    If findauth1 = UCase(gUsername) Then
                        LIMIT = "AUTHERLIMIT1"
                    ElseIf findauth2 = UCase(gUsername) Then
                        LIMIT = "AUTHERLIMIT2"
                    ElseIf findauth3 = UCase(gUsername) Then
                        LIMIT = "AUTHERLIMIT3"
                    End If
                    SSQLSTR2 = " SELECT * FROM STOCKADJUSTHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN (" & MCA & ") " '''query to change
                    SSQLSTR2 = SSQLSTR2 & " and AMOUNT <= " & Val(gdataset.Tables("CHECKER").Rows(0).Item(LIMIT))
                Else
                    SSQLSTR2 = " SELECT isnull(Docdetails,'') as Docdetails,isnull(docdate,'') as docdate,isnull(Storelocationcode,'') as Storelocationcode,isnull(AddDate,'') as AddDate,ISNULL(MCA,'') AS MCA,ISNULL(Authorised,'') AS Authorised FROM STOCKADJUSTHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN (" & MCA & ") " '''query to change
                End If
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    Dim VIEW1 As New AUTHORISATION
                    VIEW1.DTAUTH.DataSource = Nothing
                    VIEW1.DTAUTH.Rows.Clear()
                    Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZE"), False, Me, "UPDATE STOCKADJUSTHEADER set  ", "Docdetails", level, 3, 0, "Y", multi) '''query to change
                    VIEW1.ShowDialog()
                    If VIEW1.Returnkeyvalue <> "" Then
                        txt_Docno.Text = Trim(VIEW1.Returnkeyvalue)
                        Call txt_Docno_Validated(sender, e)
                    End If
                    If AuthYN = True Then
                        Dim ITEMCODE, GRNNO As String
                        Dim I As Integer
                        Dim items, GRN As String
                        GRN = ""
                        For I = 1 To VIEW1.AUTHDT.RowCount
                            If VIEW1.AUTHDT.Rows(I - 1).Cells(0).Value = True Then
                                GRNNO = VIEW1.AUTHDT.Rows(I - 1).Cells(2).Value.ToString()
                                GRN = GRN & "'" & Trim(GRNNO) & "',"
                            End If
                        Next
                        GRN = Mid(GRN, 1, Len(GRN) - 1)

                        mysql = "SELECT DISTINCT ITEMCODE FROM STOCKISSUEDETAIL WHERE Docdetails IN (" & GRN & ")"
                        gconnection.getDataSet(mysql, "GRN")
                        If gdataset.Tables("GRN").Rows.Count > 0 Then
                            '  Call updateAuth(gdataset.Tables("GRN"), GRN)
                        End If

                        mysql = " delete from authPending where Docdetail  IN (" & GRN & ") and ttype='ADJUSTMENT'"
                        gconnection.dataOperation(6, mysql, )


                        AuthYN = False
                    End If
                Else
                    MsgBox(" No Checker Records to Check ")
                End If
            Else
                MsgBox(" No Checker Records to Check")
            End If


        ElseIf Mid(Cmdauth.Text, 1, 1) = "C" Then
            SSQLSTR2 = " SELECT comment,isnull(Docdetails,'') as Docdetails,isnull(docdate,'') as docdate,isnull(StoreDESC,'') as StoreDESC,isnull(AddDate,'') as AddDate,ISNULL(MCA,'') AS MCA,ISNULL(Authorised,'') AS Authorised FROM STOCKADJUSTHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN ('M','C') "
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR2 = " SELECT * FROM MCARIGHTS WHERE  MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND (ISNULL(CHECKER1ID,'')='" & gUsername & "' OR ISNULL(CHECKER2ID,'')='" & gUsername & "')" '''query to change
                gconnection.getDataSet(SSQLSTR2, "CHECKER")
                If gdataset.Tables("CHECKER").Rows.Count > 0 Then
                    Dim VIEW1 As New AUTHORISATION
                    VIEW1.DTAUTH.DataSource = Nothing
                    VIEW1.DTAUTH.Rows.Clear()
                    Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZE"), False, Me, "UPDATE STOCKADJUSTHEADER set  ", "Docdetails", level, 2, 1, "Y", multi) '''query to change

                    VIEW1.ShowDialog()
                    If VIEW1.Returnkeyvalue <> "" Then
                        txt_Docno.Text = Trim(VIEW1.Returnkeyvalue)
                        Call txt_Docno_Validated(sender, e)
                    End If
                Else
                    MsgBox(" No Checker Records to Check")
                End If
            Else
                MsgBox("No Pending Records to Check")
            End If
        ElseIf Mid(Cmdauth.Text, 1, 1) = "M" Then
            SSQLSTR2 = " SELECT isnull(Docdetails,'') as Docdetails,isnull(docdate,'') as docdate,isnull(StoreDESC,'') as StoreDESC,isnull(AddDate,'') as AddDate,ISNULL(MCA,'') AS MCA,ISNULL(Authorised,'') AS Authorised FROM STOCKADJUSTHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN ('M') and isnull(comment,'')<>'' "
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                Dim VIEW1 As New AUTHORISATION
                VIEW1.DTAUTH.DataSource = Nothing
                VIEW1.DTAUTH.Rows.Clear()
                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZE"), False, Me, "UPDATE STOCKADJUSTHEADER set  ", "Docdetails", 1, 1, 0, "Y", multi) '''query to change
                VIEW1.ShowDialog()
                If VIEW1.Returnkeyvalue <> "" Then
                    txt_Docno.Text = Trim(VIEW1.Returnkeyvalue)
                    Call txt_Docno_Validated(sender, e)
                End If
            Else
                MsgBox("No Pending Records to Check")
            End If
        End If
    End Sub
End Class