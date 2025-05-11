Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Threading

Public Class Frm_StockIssue
    Public gconnection As New GlobalClass
    Dim sql As String
    Dim STORESTATUS As String
    Public viewprint As Boolean
    Dim idate As DateTime
    Dim weighall As Integer = 1

    Dim slcode, sldesc, costcode, costdesc, decription, accode, acdesc As String



    Dim costcenterflag As Boolean = False
    Private Sub cmd_IndentNoHelp_Click(sender As Object, e As EventArgs) Handles cmd_IndentNoHelp.Click
        Try



            Dim vform As New List_Operation
            If UCase(gShortname) = "UC" Then

                If TXT_FROMSTORECODE.Text = "" Then
                    MessageBox.Show("Plz Select Main Store", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                gconnection.dataOperation(6, " update PO_STOCKINDENTAUTH_DET set IssTransQty=isnull((select sum(qty) as qty from STOCKISSUEDETAIL g where g.Itemcode=PO_STOCKINDENTAUTH_DET.ITEMCODE and g.IndentNo=PO_STOCKINDENTAUTH_DET.IndentNo  and isnull(g.VOID,'N')<>'Y' ),0) ")
                gconnection.dataOperation(6, "   Update   PO_STOCKINDENTAUTH_HDR set ISSUESTATUS='OPEN' where Docdetails  in   (select distinct Docdetails from PO_STOCKINDENTAUTH_DET where isnull(QTY,0)<>isnull(IssTransQty,0)) ")
                gconnection.dataOperation(6, "  Update   PO_STOCKINDENTAUTH_HDR set ISSUESTATUS='CLOSED' where Docdetails not in   (select distinct Docdetails from PO_STOCKINDENTAUTH_DET where isnull(QTY,0)<>isnull(IssTransQty,0)) ")




                gSQLString = "SELECT IndentNo,	IndentDate  FROM PO_STOCKINDENTAUTH_HDR  "
                M_WhereCondition = "  WHERE ISSUESTATUS='OPEN'   AND Opstorelocationcode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "')   "

                M_ORDERBY = "order by IndentNo desc"

                vform.Field = "IndentNo,IndentDate"

            Else

                gSQLString = "SELECT DISTINCT INDENT_NO, INDENT_DATE FROM PendingIndent  "
                    M_WhereCondition = " where fromStoreCode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "')   "



                M_ORDERBY = "order by INDENT_NO desc"

                vform.Field = "INDENT_NO,INDENT_DATE"

            End If

            vform.vFormatstring1 = "       INDENT_NO                    |     INDENT_DATE                                                           "
            vform.vCaption = "STOCK INDENT HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_IndentNo.Text = Trim(vform.keyfield & "")
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Call Txt_IndentNo_Validated(Txt_IndentNo, e)
                ' txt_storecode.Focus()
                AxfpSpread1.SetActiveCell(5, 1)
            End If
            vform.Close()
            vform = Nothing

            gSQLString = "SELECT STORECODE FROM STOREMASTER WHERE BUFFET='YES' AND STORECODE='" & txt_storecode.Text & "'"
            gconnection.getDataSet(gSQLString, "BUFFET")
            If gdataset.Tables("BUFFET").Rows.Count > 0 Then
                Label11.Visible = True
                txt_buffet.Visible = True
                cmd_buffet.Visible = True
                ' cmd_buffet_Click(sender, e)
            Else
                Label11.Visible = False
                txt_buffet.Visible = False
                cmd_buffet.Visible = False
            End If

            gSQLString = "SELECT STORECODE FROM STOREMASTER WHERE Banquet='YES' AND STORECODE='" & txt_storecode.Text & "'"
            gconnection.getDataSet(gSQLString, "Banquet")
            If gdataset.Tables("Banquet").Rows.Count > 0 Then
                GroupBox4.Visible = True
                'Button1_Click(sender, e)
            Else
                GroupBox4.Visible = False
            End If


        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub DOCNO_INDNO_VALIDATE()
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, remarks, SSQL, SSQL1, VSTRDOCNO As String
        Dim vTypeseqno, Clsquantity, vGroupseqno, Totqty, TOTAMT, TOTALQTY, ISSUEQTY As Double

        TOTALQTY = 0
        SSQL = "SELECT isnull(SUM(QTY),0) AS QTY"
        SSQL = SSQL & " FROM INVENTORY_INDENTDET WHERE  INDENT_NO ='" & Trim(Txt_IndentNo.Text) & "'"
        gconnection.getDataSet(SSQL, "STOCKISSUEHEADER1")
        If gdataset.Tables("STOCKISSUEHEADER1").Rows.Count > 0 Then
            TOTALQTY = Trim(gdataset.Tables("STOCKISSUEHEADER1").Rows(0).Item("QTY"))
        End If

        ISSUEQTY = 0
        SSQL1 = "SELECT isnull(SUM(QTY),0) AS QTY"
        SSQL1 = SSQL1 & " FROM STOCKISSUEDETAIL WHERE  INDENTNO ='" & Trim(Txt_IndentNo.Text) & "' and isnull(void,'')<>'Y' "
        gconnection.getDataSet(SSQL1, "STOCKISSUEHEADER11")
        If gdataset.Tables("STOCKISSUEHEADER11").Rows.Count > 0 Then
            ISSUEQTY = Trim(gdataset.Tables("STOCKISSUEHEADER11").Rows(0).Item("QTY"))
        End If

        If Trim(Txt_IndentNo.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,H.INDENTNO INDENTNO, H.INDENTDATE AS INDENTDATE, "
                sqlstring = sqlstring & " ISNULL(H.STORELOCATIONCODE,'') AS STORELOCATIONCODE,"
                sqlstring = sqlstring & " ISNULL(H.STORELOCATIONNAME,'') AS STORELOCATIONNAME,ISNULL(H.OPSTORELOCATIONCODE,'') AS OPSTORELOCATIONCODE,"
                sqlstring = sqlstring & " ISNULL(H.OPSTORELOCATIONNAME,'') AS OPSTORELOCATIONNAME,ISNULL(H.TOTALAMT,0) AS TOTALAMT,ISNULL(H.REMARKS,'') AS REMARKS,"
                sqlstring = sqlstring & " ISNULL(H.VOID,'') AS VOID,ISNULL(H.ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(H.UPDATEUSER,'') AS UPDATEUSER,UPDATETIME,voidtime"
                sqlstring = sqlstring & " FROM STOCKISSUEHEADER AS H WHERE INDENTNO='" & Trim(Txt_IndentNo.Text) & "'"
                gconnection.getDataSet(sqlstring, "STOCKISSUEHEADER")
                '''************************************************* SELECT RECORD FROM STOCKISSUEHEADER *********************************************''''                
                If gdataset.Tables("STOCKISSUEHEADER").Rows.Count > 0 Then
                    'Cmd_Add.Text = "Update[F7]"
                    Me.txt_Docno.ReadOnly = True
                    VSTRDOCNO = Trim(txt_Docno.Text)
                    '  txt_Docno.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("DOCDETAILS") & "")
                    Txt_IndentNo.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("INDENTNO") & "")
                    dtp_IndentDate.Value = Format(CDate(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("INDENTDATE")), "dd-MMM-yyyy")
                    dtp_IndentDate.Enabled = False
                    'dtp_Docdate.Value = Format(CDate(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("DOCDATE")), "dd-MMM-yyyy")
                    ' Me.dtp_Docdate.Value = Format(Now, "dd/MMM/yyyy")
                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("STORELOCATIONCODE"))
                    txt_FromStorename.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("STORELOCATIONNAME"))
                    txt_storecode.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("OPSTORELOCATIONCODE"))
                    'cbo_Tostore.DropDownStyle = ComboBoxStyle.DropDown
                    'VSTORECODE = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("OPSTORELOCATIONCODE"))
                    'VSTORENAME = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("OPSTORELOCATIONNAME"))
                    txt_STOREDESC.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("OPSTORELOCATIONNAME"))
                    '   cbo_Tostore.DropDownStyle = ComboBoxStyle.DropDownList
                    ' txt_Totalamount.Text = Format(Val(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("TOTALAMT")), "0.000")
                    remarks = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("REMARKS"))
                    txt_Remarks.Text = Replace(remarks, "?", "'")
                    If gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("VOID") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = Me.lbl_Freeze.Text & Format(CDate(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("voidtime")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.Cmd_Freeze.Enabled = True
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Void[F8]"
                    End If
                    If Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("VOID")) = "Y" Then
                        Cmd_Add.Enabled = False
                        Cmd_Freeze.Enabled = False
                    End If
                    '''************************************************* SELECT RECORD FROM STOCKISSUEDETAILS *********************************************''''                
                    ' If TOTALQTY <> ISSUEQTY Then
                    Dim strsql As String
                    Dim STRITEMCODE As String
                    sqlstring = "SELECT ISNULL(A.ITEMCODE,'') AS ITEMCODE,ISNULL(A.ITEMNAME,'') AS ITEMNAME,ISNULL(A.UOM,'') AS UOM,(SUM(B.ISSQTY)- SUM(A.ISSQTY)) AS QTY "

                    sqlstring = sqlstring & " FROM INV_BREAK_ISSUE A, INV_BREAK_INDENT B WHERE   A.INDENTNO='" & Trim(Txt_IndentNo.Text) & "' AND "
                    sqlstring = sqlstring & "A.ITEMCODE=B.ITEMCODE AND A.INDENTNO=B.INDENTNO   "
                    sqlstring = sqlstring & " GROUP BY A.itemcode,A.itemname,A.UOM,A.INDENTNO HAVING (SUM(B.ISSQTY)- SUM(A.ISSQTY)) >0"

                    gconnection.getDataSet(sqlstring, "STOCKISSUEDETAILSALL")
                    If gdataset.Tables("STOCKISSUEDETAILSALL").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("STOCKISSUEDETAILSALL").Rows.Count
                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("ITEMCODE")))
                            STRITEMCODE = Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("ITEMNAME")))
                            AxfpSpread1.Col = 3


                            AxfpSpread1.Row = i

                            Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("ITEMCODE") + "'"

                            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z


                            AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("UOM")))


                            AxfpSpread1.SetText(4, i, Val(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("QTY")))

                            Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + STRITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                            gconnection.getDataSet(sql11, "closingtable")
                            Dim closingqty, iqty As Double
                            Dim precise As Double
                            Dim uom1, uom As String
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")
                                uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")

                                uom = Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("UOM"))

                                If gShortname = "SKYYE" Or gShortname = "HBC" Then
                                    sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                                    gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                                Else
                                    sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                    gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                                End If

                                Dim convvalue As Double
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                Else
                                    MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    Exit Sub


                                End If

                                If gShortname = "SKYYE" Or gShortname = "HBC" Then
                                    closingqty = closingqty / convvalue
                                Else
                                    closingqty = closingqty * convvalue
                                End If

                            Else
                                closingqty = 0
                            End If

                            If closingqty > Val(Val(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("QTY"))) Then
                                AxfpSpread1.SetText(5, i, Val(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("QTY")))
                                iqty = Val(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("QTY"))
                            Else
                                AxfpSpread1.SetText(5, i, Val(closingqty))
                                iqty = Val(closingqty)
                            End If




                            Totqty = Totqty + Format(Val(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("qty")), "0.000")
                            sql = "    sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER inner join inv_inventoryitemmaster on"
                            sql = sql & " inv_inventoryitemmaster.category = INVENTORYCATEGORYMASTER.CATEGORYCODE where itemcode='" + Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("ITEMCODE")) + "'"
                            '  sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                            gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                            If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                                Dim sql1 As String
                                If rateflag = "W" Then
                                    sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("itemcode")) + "' "
                                    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > CONVERT(VARCHAR(11), grndate, 106)  order by trns_seq desc"
                                    'sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("ITEMCODE") + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 and storecode='" + TXT_FROMSTORECODE.Text + "' order by Trndate desc "
                                Else

                                    sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("itemcode")) + "' "
                                    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > CONVERT(VARCHAR(11), grndate, 106)  order by trns_seq desc"
                                    'sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("ITEMCODE") + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') and storecode='" + TXT_FROMSTORECODE.Text + "' order by docdate desc"
                                    'select TOP 1   uom, rate,* from TrnsView where itemcode='A01'  and  '15/Dec/2015 11:07:01' > docdate and ttype='GRN' order by docdate desc 
                                End If
                                gconnection.getDataSet(sql1, "ratelist")
                                If (gdataset.Tables("ratelist").Rows.Count > 0) Then

                                    Dim convvalue As Double
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
                                    AxfpSpread1.Col = 7
                                    '- AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)


                                    AxfpSpread1.Col = 8
                                    AxfpSpread1.Text = Trim(Val(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue) * iqty)
                                End If
                            End If


                            j = j + 1
                        Next
                        Txt_qty.Text = Totqty
                        txt_Totalamount.Text = TOTAMT
                    Else

                        Dim STRITEMUOM As String
                        sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,ISNULL(QTY,0) AS QTY"

                        sqlstring = sqlstring & " FROM INVENTORY_INDENTDET WHERE  INDENT_NO ='" & Trim(Txt_IndentNo.Text) & "' AND ITEMCODE NOT IN (SELECT ITEMCODE FROM STOCKISSUEDETAIL WHERE IndentNo='" + Trim(Txt_IndentNo.Text) + "' AND ISNULL(VOID,'N')<>'Y') and isnull(void,'N')<>'Y' ORDER BY AUTOID"
                        gconnection.getDataSet(sqlstring, "INDENTDETAILS")
                        If gdataset.Tables("INDENTDETAILS").Rows.Count > 0 Then

                            lbl_Freeze.Visible = False
                            Cmd_Add.Enabled = True
                            For i = 1 To gdataset.Tables("INDENTDETAILS").Rows.Count
                                '  Call GridUOM(i) '''---> FILL GRID UOM
                                AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE")))
                                STRITEMCODE = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE"))
                                AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMNAME")))

                                AxfpSpread1.Col = 3


                                AxfpSpread1.Row = i
                                AxfpSpread1.TypeComboBoxClear(3, i)

                                Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE") + "'"

                                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                Next Z


                                AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM")))


                                ' AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                                '  STRITEMUOM = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                                AxfpSpread1.SetText(4, i, Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY")))
                                sql = "    sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER inner join inv_inventoryitemmaster on"
                                sql = sql & " inv_inventoryitemmaster.category = INVENTORYCATEGORYMASTER.CATEGORYCODE where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE")) + "'"
                                '  sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                                gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                                If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                                    Dim sql1 As String
                                    If rateflag = "W" Then
                                        sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("itemcode")) + "' "
                                        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > CONVERT(VARCHAR(11), grndate, 106)  order by trns_seq desc"
                                        'sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 and storecode='" + TXT_FROMSTORECODE.Text + "' order by Trndate desc "
                                    Else

                                        sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("itemcode")) + "' "
                                        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > CONVERT(VARCHAR(11), grndate, 106)  order by trns_seq desc"
                                        'sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') and storecode='" + TXT_FROMSTORECODE.Text + "' order by docdate desc"
                                        'select TOP 1   uom, rate,* from TrnsView where itemcode='A01'  and  '15/Dec/2015 11:07:01' > docdate and ttype='GRN' order by docdate desc 
                                    End If
                                    gconnection.getDataSet(sql1, "ratelist")
                                    If (gdataset.Tables("ratelist").Rows.Count > 0) Then

                                        Dim convvalue As Double
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
                                        AxfpSpread1.SetText(7, i, Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue))


                                    Else
                                        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("itemcode")) + "'  and isnull(openningqty,0) <>0 "
                                        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                                        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                                            Dim convvalue As Double
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
                                            AxfpSpread1.SetText(7, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue))

                                        End If
                                    End If
                                End If
                                j = j + 1
                            Next
                        End If
                    End If
                    If GUSERCATEGORY <> "S" Then
                        Call GetRights()
                    End If
                    '  TotalCount = gdataset.Tables("STOCKISSUEDETAILSALL").Rows.Count
                    AxfpSpread1.SetActiveCell(5, 1)
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Txt_IndentNo_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_IndentNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_IndentNo.Text <> "" Then
                Txt_IndentNo_Validated(sender, e)
            Else
                cmd_IndentNoHelp_Click(sender, e)
            End If

        End If
    End Sub


    Private Sub Txt_IndentNo_Validated(sender As Object, e As EventArgs) Handles Txt_IndentNo.Validated
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, remarks As String
        Dim vTypeseqno, Clsquantity, vGroupseqno As Double
        Try
            If Trim(Txt_IndentNo.Text) <> "" Then
                Grid_lock()




                If UCase(gShortname) = "UC" Then

                    If TXT_FROMSTORECODE.Text = "" Then
                        MessageBox.Show("Plz Select Main Store", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    FillAuthIN()
                Else

                    sqlstring = "SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,H.INDENTNO INDENTNO, H.INDENTDATE AS INDENTDATE, "
                    sqlstring = sqlstring & " ISNULL(H.STORELOCATIONCODE,'') AS STORELOCATIONCODE,"
                    sqlstring = sqlstring & " ISNULL(H.STORELOCATIONNAME,'') AS STORELOCATIONNAME,ISNULL(H.OPSTORELOCATIONCODE,'') AS OPSTORELOCATIONCODE,"
                    sqlstring = sqlstring & " ISNULL(H.OPSTORELOCATIONNAME,'') AS OPSTORELOCATIONNAME,ISNULL(H.TOTALAMT,0) AS TOTALAMT,ISNULL(H.REMARKS,'') AS REMARKS,"
                    sqlstring = sqlstring & " ISNULL(H.VOID,'') AS VOID,ISNULL(H.ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(H.UPDATEUSER,'') AS UPDATEUSER,UPDATETIME"
                    sqlstring = sqlstring & " FROM STOCKISSUEHEADER AS H WHERE isnull(void,'')<>'Y' and  INDENTNO='" & Trim(Txt_IndentNo.Text) & "'"
                    gconnection.getDataSet(sqlstring, "STOCKISSUEHEADER")

                    If gdataset.Tables("STOCKISSUEHEADER").Rows.Count > 0 Then
                        Call DOCNO_INDNO_VALIDATE()
                    Else
                        sqlstring = " SELECT ISNULL(H.INDENT_NO,'') AS INDENT_NO,H.INDENT_DATE AS INDENT_DATE,ISNULL(FROMSTORECODE,'') FROMSTORECODE , ISNULL(H.STORELOCATIONCODE,'') AS STORELOCATIONCODE, "
                        sqlstring = sqlstring & " ISNULL(H.STORELOCATIONNAME,'') AS STORELOCATIONNAME,"
                        sqlstring = sqlstring & " ISNULL(H.REMARKS,'') AS REMARKS, ISNULL(H.VOID,'') AS VOID,"
                        sqlstring = sqlstring & " ISNULL(H.ADDUSER,'') AS ADDUSER,ADDDATETIME,ISNULL(H.UPDATEUSER,'') AS UPDATEUSER,UPDATETIME,voiddatetime "
                        sqlstring = sqlstring & " FROM INVENTORY_INDENTHDR AS H "
                        sqlstring = sqlstring & " WHERE INDENT_NO='" & Txt_IndentNo.Text & "'"
                        gconnection.getDataSet(sqlstring, "INDENTHDR")
                        '''************************************************* SELECT RECORD FROM INDENTHDR *********************************************''''                
                        If gdataset.Tables("INDENTHDR").Rows.Count > 0 Then
                            ' Cmd_Add.Text = "Update[F7]"
                            Me.Txt_IndentNo.ReadOnly = True
                            'VSTRDOCNO = Trim(txt_Docno.Text)
                            Txt_IndentNo.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("INDENT_NO") & "")
                            dtp_IndentDate.Value = Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("INDENT_DATE")), "dd-MMM-yyyy")

                            If UCase(gShortname) = "NIZAM" Then
                                dtp_Docdate.Value = Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("INDENT_DATE")), "dd-MMM-yyyy")

                            End If

                            dtp_IndentDate.Enabled = False
                            TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("fromStoreCode") & "")
                            Call TXT_FROMSTORECODE_Validated(Txt_IndentNo.Text, e)
                            txt_storecode.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("STORELOCATIONCODE"))
                            Call txt_storecode_Validated(sender, e)
                            txt_STOREDESC.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("STORELOCATIONNAME"))
                            remarks = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("REMARKS"))
                            txt_Remarks.Text = Replace(remarks, "?", "'")
                            If gdataset.Tables("INDENTHDR").Rows(0).Item("VOID") = "Y" Then
                                Me.lbl_Freeze.Visible = True
                                Me.lbl_Freeze.Text = "Record Freezed On " & Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("voiddatetime")), "dd-MMM-yyyy")
                                Me.Cmd_Freeze.Enabled = True
                                Me.Cmd_Add.Enabled = False
                                ' Me.Cmd_FREEZE.Text = "UnVoid[F8]"
                                Cmd_Freeze.Enabled = False
                            Else
                                Me.lbl_Freeze.Visible = False
                                Me.Cmd_Freeze.Enabled = True
                                Me.lbl_Freeze.Text = "Record Freezed  On "
                                Me.Cmd_Freeze.Text = "Void[F8]"
                            End If
                            '''************************************************* SELECT RECORD FROM INDENTDETAILS *********************************************''''                
                            Dim strsql As String
                            Dim STRITEMCODE, STRITEMUOM As String
                            sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,ISNULL(QTY,0) AS QTY"

                            'sqlstring = sqlstring & " FROM INVENTORY_INDENTDET WHERE  INDENT_NO ='" & Trim(Txt_IndentNo.Text) & "' AND ISNULL(VOID,'N')<>'Y' ORDER BY AUTOID"

                            sqlstring = sqlstring & " FROM INVENTORY_INDENTDET WHERE  INDENT_NO ='" & Trim(Txt_IndentNo.Text) & "' AND ISNULL(VOID,'N')<>'Y' ORDER BY autoid"
                            gconnection.getDataSet(sqlstring, "INDENTDETAILS")
                            If gdataset.Tables("INDENTDETAILS").Rows.Count > 0 Then
                                For i = 1 To gdataset.Tables("INDENTDETAILS").Rows.Count
                                    '  Call GridUOM(i) '''---> FILL GRID UOM
                                    AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE")))
                                    STRITEMCODE = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE"))
                                    AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMNAME")))

                                    AxfpSpread1.Col = 3


                                    AxfpSpread1.Row = i
                                    AxfpSpread1.TypeComboBoxClear(3, i)

                                    Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE") + "'"

                                    gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                                    For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                        AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                        AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                    Next Z


                                    AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM")))


                                    ' AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                                    '  STRITEMUOM = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                                    AxfpSpread1.Text = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                                    AxfpSpread1.SetText(4, i, Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY")))

                                    Dim sql11 As String '= "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + STRITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                                    'gconnection.getDataSet(sql11, "closingtable")

                                    gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), STRITEMCODE, Trim(TXT_FROMSTORECODE.Text), "")
                                    Dim closingqty, CRRATE, iqty As Double
                                    Dim precise As Double
                                    Dim uom1, uom As String
                                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                        closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                        uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                                        CRRATE = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                                        uom = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))

                                        If gShortname = "SKYYE" Or gShortname = "HBC" Then
                                            sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                                            gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                                        Else
                                            sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                            gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                                        End If

                                        Dim convvalue As Double
                                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                            precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                        Else
                                            MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                            Exit Sub


                                        End If
                                        If gShortname = "SKYYE" Or gShortname = "HBC" Then
                                            closingqty = closingqty / convvalue
                                        Else
                                            closingqty = closingqty * convvalue
                                        End If
                                        If gShortname = "SKYYE" Or gShortname = "HBC" Then
                                            AxfpSpread1.SetText(7, i, CRRATE * convvalue)
                                            AxfpSpread1.SetText(8, i, (CRRATE * convvalue) * iqty)
                                        End If

                                    Else
                                        closingqty = 0
                                    End If

                                    If closingqty > Val(Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY"))) Then
                                        AxfpSpread1.SetText(5, i, Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY")))
                                        iqty = Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY"))
                                    Else
                                        AxfpSpread1.SetText(5, i, Val(closingqty))
                                        iqty = Val(closingqty)
                                    End If
                                    If gShortname <> "SKYYE" Or gShortname <> "HBC" Then
                                        AxfpSpread1.SetText(7, i, CRRATE)
                                        AxfpSpread1.SetText(8, i, CRRATE * iqty)

                                    End If



                                    If UCase(gShortname) = "KGA" Then
                                        AxfpSpread1.SetText(10, i, Val(closingqty))
                                    End If


                                    'sql = "    sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER inner join inv_inventoryitemmaster on"
                                    'sql = sql & " inv_inventoryitemmaster.category = INVENTORYCATEGORYMASTER.CATEGORYCODE where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE")) + "'"
                                    ''  sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                                    'gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                                    'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                    '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                                    '    Dim sql1 As String
                                    '    If rateflag = "W" Then
                                    '        sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("itemcode")) + "' "
                                    '        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > CONVERT(VARCHAR(11), grndate, 106)  order by trns_seq desc"
                                    '        'sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 and storecode='" + TXT_FROMSTORECODE.Text + "' order by Trndate desc "
                                    '    Else

                                    '        sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("itemcode")) + "' "
                                    '        sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > CONVERT(VARCHAR(11), grndate, 106)  order by trns_seq desc"
                                    '        'sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') and storecode='" + TXT_FROMSTORECODE.Text + "' order by docdate desc"
                                    '        'select TOP 1   uom, rate,* from TrnsView where itemcode='A01'  and  '15/Dec/2015 11:07:01' > docdate and ttype='GRN' order by docdate desc 
                                    '    End If
                                    '    gconnection.getDataSet(sql1, "ratelist")
                                    '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then

                                    '        Dim convvalue As Double
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
                                    '        AxfpSpread1.SetText(7, i, Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue))
                                    '        AxfpSpread1.SetText(8, i, Val(Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)) * iqty)


                                    '    Else
                                    '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("itemcode")) + "'  and isnull(openningqty,0) <>0 "
                                    '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                                    '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                                    '            Dim convvalue As Double
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
                                    '            AxfpSpread1.SetText(7, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue))
                                    '            AxfpSpread1.SetText(8, i, Val(Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)) * iqty)

                                    '        End If
                                    '    End If
                                    'End If
                                    j = j + 1
                                Next
                            End If

                            If gUserCategory <> "S" Then
                                '  Call GetRights()
                            End If
                            Calculate()
                            ' ssgrid.Focus()
                            dtp_IndentDate.Focus()
                            AxfpSpread1.SetActiveCell(1, 1)

                        Else
                            dtp_IndentDate.Focus()
                        End If
                    End If
                End If


                Call autogenerate()
                AxfpSpread1.SetActiveCell(5, 1)
            End If
        Catch ex As Exception
            MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub


    Private Sub FillAuthIN()
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, remarks As String
        Dim vTypeseqno, Clsquantity, vGroupseqno As Double




            sqlstring = " SELECT ISNULL(H.INDENTNO,'') AS INDENT_NO,H.INDENTDATE AS INDENT_DATE,ISNULL(Storelocationcode,'') FROMSTORECODE , ISNULL(H.Opstorelocationcode,'')   "
            sqlstring = sqlstring & " AS STORELOCATIONCODE, ISNULL(H.Opstorelocationname,'') AS STORELOCATIONNAME,ISNULL(H.REMARKS,'') AS REMARKS, ISNULL(H.VOID,'') AS VOID, "
            sqlstring = sqlstring & " ISNULL(H.ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(H.UPDATEUSER,'') AS UPDATEUSER,UPDATETIME FROM PO_STOCKINDENTAUTH_HDR AS H WHERE INDENTNO='" & Txt_IndentNo.Text & "'"
            gconnection.getDataSet(sqlstring, "INDENTHDR")

            '''************************************************* SELECT RECORD FROM INDENTHDR *********************************************''''                
            If gdataset.Tables("INDENTHDR").Rows.Count > 0 Then
                ' Cmd_Add.Text = "Update[F7]"
                Me.Txt_IndentNo.ReadOnly = True
                'VSTRDOCNO = Trim(txt_Docno.Text)
                Txt_IndentNo.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("INDENT_NO") & "")
                dtp_IndentDate.Value = Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("INDENT_DATE")), "dd-MMM-yyyy")
                dtp_IndentDate.Enabled = False
                '     TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("fromStoreCode") & "")
                '  Call TXT_FROMSTORECODE_Validated(Txt_IndentNo.Text, e)
                txt_storecode.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("STORELOCATIONCODE"))
                Dim arg As EventArgs
                Call txt_storecode_Validated(txt_storecode, arg)
                txt_STOREDESC.Text = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("STORELOCATIONNAME"))
                remarks = Trim(gdataset.Tables("INDENTHDR").Rows(0).Item("REMARKS"))
                txt_Remarks.Text = Replace(remarks, "?", "'")
                If gdataset.Tables("INDENTHDR").Rows(0).Item("VOID") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                Me.lbl_Freeze.Text = "Record Freezed On " & Format(CDate(gdataset.Tables("INDENTHDR").Rows(0).Item("voiddatetime")), "dd-MMM-yyyy")
                Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_Add.Enabled = False
                    ' Me.Cmd_FREEZE.Text = "UnVoid[F8]"
                    Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.Cmd_Freeze.Enabled = True
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                End If
                '''************************************************* SELECT RECORD FROM INDENTDETAILS *********************************************''''                
                Dim strsql As String
                Dim STRITEMCODE, STRITEMUOM As String


          
            sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,ISNULL(QTY ,0)- ISNULL(IssTransQty,0) AS QTY"

                sqlstring = sqlstring & " FROM PO_STOCKINDENTAUTH_DET WHERE  INDENTNO ='" & Trim(Txt_IndentNo.Text) & "' AND ISNULL(VOID,'N')<>'Y' and AUTHORISED='Y' AND QTY<> ISNULL(IssTransQty,0) ORDER BY AUTOID"
                gconnection.getDataSet(sqlstring, "INDENTDETAILS")
                If gdataset.Tables("INDENTDETAILS").Rows.Count > 0 Then
                    For i = 1 To gdataset.Tables("INDENTDETAILS").Rows.Count
                        '  Call GridUOM(i) '''---> FILL GRID UOM
                        AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE")))
                        STRITEMCODE = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE"))
                        AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMNAME")))

                        AxfpSpread1.Col = 3


                        AxfpSpread1.Row = i
                        AxfpSpread1.TypeComboBoxClear(3, i)

                        Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("INDENTDETAILS").Rows(j).Item("ITEMCODE") + "'"

                        gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                        Next Z


                        AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM")))


                        ' AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                        '  STRITEMUOM = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                        AxfpSpread1.Text = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                        AxfpSpread1.SetText(4, i, Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY")))

                        Dim sql11 As String '= "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + STRITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                        'gconnection.getDataSet(sql11, "closingtable")

                        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), STRITEMCODE, Trim(TXT_FROMSTORECODE.Text), "")

                        Dim closingqty, CRRATE, iqty As Double
                        Dim precise As Double
                        Dim uom1, uom As String
                        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                            closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                            uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                            CRRATE = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                            uom = Trim(gdataset.Tables("INDENTDETAILS").Rows(j).Item("UOM"))
                            sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                            gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                            Dim convvalue As Double
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                            Else
                                MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                Exit Sub


                            End If

                            closingqty = closingqty * convvalue
                        Else
                            closingqty = 0
                        End If

                        If closingqty > Val(Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY"))) Then
                            AxfpSpread1.SetText(5, i, Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY")))
                            iqty = Val(gdataset.Tables("INDENTDETAILS").Rows(j).Item("QTY"))
                        Else
                            AxfpSpread1.SetText(5, i, Val(closingqty))
                            iqty = Val(closingqty)
                        End If

                        AxfpSpread1.SetText(7, i, CRRATE)
                        AxfpSpread1.SetText(8, i, CRRATE * iqty)

                        j = j + 1
                    Next
                End If

                If gUserCategory <> "S" Then
                    '  Call GetRights()
                End If
                Calculate()
                ' ssgrid.Focus()
                dtp_IndentDate.Focus()
                AxfpSpread1.SetActiveCell(1, 1)

            Else
                dtp_IndentDate.Focus()
            End If


    End Sub
    Private Sub cmd_storecode_Click(sender As Object, e As EventArgs) Handles cmd_storecode.Click
        Dim SQLSTRING As String
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "

        If costcenterflag = True Then
            M_WhereCondition = " where freeze <> 'Y' "
        Else
            M_WhereCondition = " where freeze <> 'Y' and STORESTATUS='M'"

        End If

        'gSQLString = "SELECT DISTINCT(storecode),storedesc,STORESTATUS FROM STOREMASTER   "
        'M_WhereCondition = " where freeze <> 'Y'" ' AND STORESTATUS='M' "
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "DEPARTMENT MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_FROMSTORECODE.Text = Trim(vform.keyfield & "")
            txt_FromStorename.Text = Trim(vform.keyfield1 & "")
            STORESTATUS = Trim(vform.keyfield2 & "")
            txt_storecode.Focus()
        End If
        ' ADDED BY SRI FOR FROM SHELF
        If GSHELVING = "Y" Then
            SQLSTRING = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster WHERE  STORECODE='" + TXT_FROMSTORECODE.Text + "' And ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(SQLSTRING, "FROMSHELF")
            If gdataset.Tables("FROMSHELF").Rows.Count > 0 Then
                AxfpSpread1.Col = 11
                AxfpSpread1.ColHidden = False
            Else
                AxfpSpread1.Col = 11
                AxfpSpread1.ColHidden = True
            End If
        End If
        ' END 
        Call autogenerate()
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub TXT_FROMSTORECODE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_FROMSTORECODE.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (TXT_FROMSTORECODE.Text <> "") Then
                TXT_FROMSTORECODE_Validated(sender, e)
            Else
                cmd_storecode_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub TXT_FROMSTORECODE_Validated(sender As Object, e As EventArgs) Handles TXT_FROMSTORECODE.Validated
        Dim SQL As String
        If Trim(TXT_FROMSTORECODE.Text) <> "" Then
            SQL = "SELECT * FROM storemaster WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(Freeze,'') <> 'Y' "
            If (costcenterflag = False) Then
                SQL = SQL & " and STORESTATUS='M'"
            End If
            gconnection.getDataSet(SQL, "storemaster")
            If gdataset.Tables("storemaster").Rows.Count > 0 Then
                TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                txt_FromStorename.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                AxfpSpread1.Focus()
                AxfpSpread1.SetActiveCell(1, 1)

            Else
                TXT_FROMSTORECODE.Text = ""
                TXT_FROMSTORECODE.Focus()
            End If
            Call autogenerate()
        End If
    End Sub

    Private Sub cmd_fromStorecodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_fromStorecodeHelp.Click
        Dim SQLSTRING As String
        gSQLString = "Select storecode,storedesc,ctype,STORESTATUS from Vw_Store_Costcenter"
        'gSQLString = "SELECT DISTINCT(storecode),storedesc,'S' FROM STOREMASTER   "
        'gSQLString = gSQLString + " Union select distinct(Costcentercode),costcenterdesc,'C' from ACCOUNTSCOSTCENTERMASTER "
        If UCase(gShortname) = "MGC" Then
            M_WhereCondition = " where  STORESTATUS <>'M'  "
        Else
            M_WhereCondition = " where  STORESTATUS<>'M' "
        End If

        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_storecode.Text = Trim(vform.keyfield & "")
            txt_STOREDESC.Text = Trim(vform.keyfield1 & "")
            If (vform.keyfield2 = "C") Then
                costcenterflag = True
            Else
                costcenterflag = False
            End If
            Call autogenerate()
            STORESTATUS = vform.keyfield3
        End If
        ' ADDED BY SRI FOR  To SHELF
        If GSHELVING = "Y" Then
            SQLSTRING = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster  WHERE STORECODE='" + txt_storecode.Text + "' And ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(SQLSTRING, "TOSHELF")
            If gdataset.Tables("TOSHELF").Rows.Count > 0 Then
                AxfpSpread1.Col = 12
                AxfpSpread1.ColHidden = False
            Else
                AxfpSpread1.Col = 12
                AxfpSpread1.ColHidden = True
            End If
        End If
        ' END
        If gShortname = "FNCC" Then
            SQLSTRING = " SELECT ISNULL(SESSIONREQ,'')AS SESSIONREQ FROM STOREMASTER WHERE STORECODE='" & txt_storecode.Text & "' AND  ISNULL(FREEZE,'N') <> 'Y' "
            gconnection.getDataSet(SQLSTRING, "SESSIONRE")
            Dim SESSIONREQ As String
            SESSIONREQ = Trim(gdataset.Tables("SESSIONRE").Rows(0).Item("SESSIONREQ"))
            If SESSIONREQ = "YES" Then
                LBL_SESSION.Visible = True
                CMB_SESSION.Visible = True
                BINDSESSION()
            Else
                LBL_SESSION.Visible = False
                CMB_SESSION.Visible = False
            End If
        End If

        SQLSTRING = "SELECT STORECODE FROM STOREMASTER WHERE BUFFET='YES' AND STORECODE='" & txt_storecode.Text & "'"
        gconnection.getDataSet(SQLSTRING, "BUFFET")
        If gdataset.Tables("BUFFET").Rows.Count > 0 Then
            Label11.Visible = True
            txt_buffet.Visible = True
            cmd_buffet.Visible = True
            ' cmd_buffet_Click(sender, e)
        Else
            Label11.Visible = False
            txt_buffet.Visible = False
            cmd_buffet.Visible = False
        End If

        SQLSTRING = "SELECT STORECODE FROM STOREMASTER WHERE Banquet='YES' AND STORECODE='" & txt_storecode.Text & "'"
        gconnection.getDataSet(SQLSTRING, "Banquet")
        If gdataset.Tables("Banquet").Rows.Count > 0 Then
            GroupBox4.Visible = True
            'Button1_Click(sender, e)
        Else
            GroupBox4.Visible = False
        End If




        TXT_FROMSTORECODE.Focus()
            vform.Close()
            vform = Nothing


    End Sub

    Private Sub Frm_StockIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.KeyCode = Keys.F10 And Cmd_View.Visible = True Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.Escape Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F1 Then
                Call Button2_Click(Button2, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Frm_StockIssue_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Frm_StockIssue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If


        MinimizeBox = False
        MaximizeBox = False

        'Resize_Form()
        'Me.DoubleBuffered = True
        Dim sqlstring As String = "Select getdate()"
        idate = gconnection.getvalue(sqlstring)


        autogenerate()

        If UCase(gShortname) = "BBSR" Or UCase(gShortname) = "JSCA" Then
            GroupBox4.Visible = True
        Else
            GroupBox4.Visible = False
        End If
        If UCase(gShortname) <> "KGA" Then
            AxfpSpread1.Col = 10
            AxfpSpread1.ColHidden = True
        End If

        txt_STOREDESC.Enabled = False
        txt_FromStorename.Enabled = False
        If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
            lbl_closingqty.Visible = True
            lbl_closingqty.ForeColor = Color.Red
        Else
            lbl_closingqty.Visible = True
            lbl_closingqty.ForeColor = Color.Red
        End If

        Txt_qty.Visible = True
        txt_Totalamount.Visible = True

        If (GINDENTNO = "Y") Then
            grp_issue2.Visible = True
            Call Grid_lock()

            txt_storecode.Enabled = False
            TXT_FROMSTORECODE.Enabled = False
            txt_STOREDESC.Enabled = False

            cmd_fromStorecodeHelp.Enabled = False



            cmd_storecode.Enabled = False
            If UCase(gShortname) = "UC" Then
                TXT_FROMSTORECODE.Enabled = True
                cmd_storecode.Enabled = True
            End If

        Else
            dtp_IndentDate.Value = dtp_Docdate.Value
            AxfpSpread1.Col = 4
            AxfpSpread1.ColHidden = True
            grp_issue2.Visible = False

            Call GridUnLock()
        End If
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        If (GINDENTNO = "Y") Then
            Txt_IndentNo.Focus()
        Else
            Me.txt_storecode.Focus()
        End If

        If GSHELVING <> "Y" Then
            AxfpSpread1.Col = 11
            AxfpSpread1.ColHidden = True
            AxfpSpread1.Col = 12
            AxfpSpread1.ColHidden = True
        End If

        'Dim thr As New Thread(Sub() Check())
        'thr.Start()
        Get_Qty_InputSetUp()
        If gShortname = "RSAOI" Then
            Me.Cmdauth.Visible = True
            Call CHECKUSER()
        End If
        'If gShortname = "HGA" Then
        '    Dim STRSQL As String
        '    STRSQL = "delete from temp_employeeissue "
        '    gconnection.dataOperation(6, STRSQL, )
        'End If
        GroupBox4.Visible = False
        Label11.Visible = False
        txt_buffet.Visible = False
        cmd_buffet.Visible = False


    End Sub
    Sub BINDSESSION()
        Dim I As Integer
        Try
            CMB_SESSION.Items.Clear()
            Dim sql As String = "Select SESSIONCODE,SESSIONDESC FROM INV_SESSIONMASTER WHERE isnull(void,'')<>'Y'"
            gconnection.getDataSet(sql, "INV_SESSIONMASTER")
            If (gdataset.Tables("INV_SESSIONMASTER").Rows.Count > 0) Then
                For I = 0 To gdataset.Tables("INV_SESSIONMASTER").Rows.Count - 1
                    CMB_SESSION.Items.Add(gdataset.Tables("INV_SESSIONMASTER").Rows(I).Item("SESSIONDESC"))
                Next
                CMB_SESSION.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub CHECKUSER()
        Dim sqlstring As String
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


    Private Sub Calculate()
        Try
            Dim ValQty As Double
            Dim Calqty As Double
            Dim Itemcode As String
            Dim i, j As Integer
            '  If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 3 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Then




            Me.Txt_qty.Text = ""

            For i = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Col = 9
                AxfpSpread1.Row = i
                If AxfpSpread1.Text <> "Y" Then
                    AxfpSpread1.Col = 5
                    ValQty = Val(AxfpSpread1.Text)
                    Me.Txt_qty.Text = Format(Val(Me.Txt_qty.Text) + Val(ValQty), "0.000")
                End If

            Next i
            ValQty = 0
            Me.txt_Totalamount.Text = ""

            For i = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 9
                If AxfpSpread1.Text <> "Y" Then
                    AxfpSpread1.Col = 8
                    ValQty = Val(AxfpSpread1.Text)
                    Me.txt_Totalamount.Text = Format(Val(Me.txt_Totalamount.Text) + Val(ValQty), "0.000")
                End If

            Next i

            'End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub AxfpSpread1_DockChanged(sender As Object, e As EventArgs) Handles AxfpSpread1.DockChanged

    End Sub
    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String
        If e.keyCode = Keys.Enter Then
            i = AxfpSpread1.ActiveRow
            'ITEMCODE
            AxfpSpread1.Row = i

            AxfpSpread1.Lock = False

            If AxfpSpread1.ActiveCol = 1 And AxfpSpread1.Lock = False Then

                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) = "" Then


                    binditemcode()
                Else

                    SQL = " select  distinct (I.itemcode),Itemname,uom,batchprocess,m.category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                        AxfpSpread1.Col = 3
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow

                        SQL = "select distinct  UPPER(tranuom) AS tranuom  from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                        gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                        AxfpSpread1.TypeComboBoxClear(3, i)
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                        Next Z

                        AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")).ToUpper())

                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then


                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            '    AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))

                            'AxfpSpread1.Col = 3
                            'AxfpSpread1.Row = AxfpSpread1.ActiveRow

                            'SQL = "select distinct  UPPER(tranuom) AS tranuom  from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            'gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                            'AxfpSpread1.TypeComboBoxClear(3, i)
                            'For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            '    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            '    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            'Next Z

                            'AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")).ToUpper())

                            If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES" Then


                                ' gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                                GroupBox3.Visible = True
                                ' Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                                Dim SQL1 As String = "with a as ( "
                                SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,isnull(batchno,'') as  batchno from closingqty where trndate<='" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'"
                                SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                                SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_RatelistNew.batchrate as rate,closingqty.uom from a inner  join closingqty on "
                                SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                                SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                                SQL1 = SQL1 & " inner  join Vw_RatelistNew on a.batchno=Vw_RatelistNew.batchno"
                                SQL1 = SQL1 & " and a.itemcode=Vw_RatelistNew.itemcode and  a.storecode=closingqty.storecode and a.storecode=Vw_RatelistNew.storecode "
                                SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND a.TRNDATE<='" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  closingqty.closingstock>0 order by trndate desc,AUTOID desc "
                                'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                                'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "

                                gconnection.getDataSet(SQL1, "closingtable")
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
                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 5
                                        AxfpSpread2.SetText(5, k + 1, Val(gdataset.Tables("closingtable").Rows(k).Item("rate")))

                                    Next
                                    AxfpSpread2.SetActiveCell(1, 6)
                                    AxfpSpread2.Focus()
                                Else
                                    AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                                    GroupBox6.Visible = False
                                    AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                                End If
                                Calculate()
                            Else


                                'SQL = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                                'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                                '    Dim sql1 As String
                                '    If rateflag = "W" Then
                                '        sql1 = " select TOP 1  weightedrate as rate,uom from Vw_RatelistNew where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                '        sql1 = sql1 & " and  cast( CONVERT(VARCHAR(11),'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "', 106) as Date) >  cast( CONVERT(VARCHAR(11), grndate, 106) as Date)  order by trns_seq desc"
                                '    Else
                                '        sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' "
                                '        sql1 = sql1 & " and  cast( CONVERT(VARCHAR(11),'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "', 106) as Date) >  cast( CONVERT(VARCHAR(11), grndate, 106) as Date)  order by trns_seq desc"

                                '    End If
                                '    gconnection.getDataSet(sql1, "ratelist")
                                '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                                '        Dim convvalue As Double
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
                                '        AxfpSpread1.Col = 7
                                '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                                '    Else
                                '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and isnull(openningqty,0)<>0 "
                                '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                                '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                                '            Dim convvalue As Double
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
                                '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                                '        Else
                                '            AxfpSpread1.Col = 7
                                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                '            AxfpSpread1.Text = "0"

                                '        End If
                                '    End If
                                '    If (GINDENTNO = "Y") Then
                                '        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                                '    Else
                                '        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                                '    End If


                                'End If
                            End If
                        Else
                            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
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

                End If

                AxfpSpread1.Col = 3
                Dim uom As String = AxfpSpread1.Text
                Dim uom1 As String
                AxfpSpread1.Col = 1

                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                Dim sql11 As String ' = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + AxfpSpread1.Text + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                ' gconnection.getDataSet(sql11, "closingtable")

                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), AxfpSpread1.Text, Trim(TXT_FROMSTORECODE.Text), "")

                Dim closingqty, RATE As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    RATE = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                Else
                    closingqty = 0
                    RATE = 0
                End If
                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                Dim convvalue1 As Double
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    MessageBox.Show("Please Create relation Between " + uom1 + " and " + uom)
                    Exit Sub
                End If
                '   closingqty = Format(closingqty * convvalue1, "0.000")

                AxfpSpread1.Col = 7
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(RATE / convvalue1)

                AxfpSpread1.Col = 1
                lbl_closingqty.Text = "" + AxfpSpread1.Text + " has closing qty is " + closingqty.ToString() + "  " + uom1
                ''Added by Sri For Batch No
                ' batchnocheck()
                FROMShelfcheck()
                ToShelfcheck()
                ' BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
                'If BATCH_REQ = "YES" Then
                '    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                If GSHELVING = "Y" Then
                    If (gdataset.Tables("FROMShelfcheck").Rows.Count > 0) Then
                        AxfpSpread1.SetActiveCell(11, AxfpSpread1.ActiveRow)
                    ElseIf (gdataset.Tables("ToShelfcheck").Rows.Count > 0) Then
                        AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                    End If
                ElseIf (GINDENTNO = "Y") Then
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                End If
                ' end 
                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 2 And AxfpSpread1.Lock = False Then
                AxfpSpread1.Col = 2
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemname()
                Else

                    SQL = " select  distinct (I.itemcode),Itemname,uom,batchprocess,CATEGORY from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(m.itemname,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        If (check_Duplicate(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) = False) Then
                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            '  AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))

                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.TypeComboBoxClear(3, i)

                            SQL = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                            gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z


                            If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES1" Then
                                '  gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                                GroupBox3.Visible = True
                                '  Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                                'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                                'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                                Dim SQL1 As String = "with a as ( "
                                SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,isnull(batchno,'') as  batchno from closingqty where trndate<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                                SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                                SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_RatelistNew.batchrate as rate,closingqty.uom as uom from a inner  join closingqty on "
                                SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                                SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                                SQL1 = SQL1 & " inner  join Vw_RatelistNew on a.batchno=Vw_RatelistNew.batchno"
                                SQL1 = SQL1 & " and a.itemcode=Vw_RatelistNew.itemcode and  a.storecode=closingqty.storecode and a.storecode=Vw_RatelistNew.storecode "
                                SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND a.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  closingqty.closingstock>0 order by trndate desc,AUTOID desc "

                                gconnection.getDataSet(SQL1, "closingtable")
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
                                        AxfpSpread2.Row = k
                                        AxfpSpread2.Col = 5
                                        AxfpSpread2.SetText(5, k + 1, Val(gdataset.Tables("closingtable").Rows(k).Item("rate")))

                                    Next
                                    AxfpSpread2.SetActiveCell(1, 6)
                                    AxfpSpread2.Focus()

                                Else
                                End If


                            Else
                                'SQL = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                                'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                                '    Dim sql1 As String
                                '    If rateflag = "W" Then
                                '        sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                '        sql1 = sql1 & " and   cast( CONVERT(VARCHAR(11),'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "', 106) as Date) >  cast( CONVERT(VARCHAR(11), grndate, 106) as Date)  order by trns_seq desc"
                                '    Else
                                '        sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                '        sql1 = sql1 & " and  cast( CONVERT(VARCHAR(11),'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "', 106) as Date) >  cast( CONVERT(VARCHAR(11), grndate, 106) as Date)  order by trns_seq desc"

                                '    End If
                                '    gconnection.getDataSet(sql1, "ratelist")
                                '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then

                                '        Dim convvalue As Double
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
                                '        AxfpSpread1.Col = 7
                                '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                                '    Else
                                '        sql1 = "select (openningvalue/openningqty) as rate from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' and isnull(openningqty,0) <>0 "
                                '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                                '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                                '            Dim convvalue As Double
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
                                '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                                '        End If
                                '    End If
                                '    If (GINDENTNO = "Y") Then
                                '        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                                '    Else
                                '        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                                '    End If


                                'End If
                                AxfpSpread1.Col = 3
                                Dim uom As String = AxfpSpread1.Text
                                Dim uom1 As String
                                AxfpSpread1.Col = 1

                                Dim sql11 As String
                                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), AxfpSpread1.Text, Trim(TXT_FROMSTORECODE.Text), "")

                                Dim closingqty, RATE As Double
                                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                    RATE = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                                Else
                                    closingqty = 0
                                    RATE = 0
                                End If
                                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                                SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                                Dim convvalue1 As Double
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                                Else
                                    MessageBox.Show("Please Create relation Between " + uom1 + " and " + uom)
                                    Exit Sub
                                End If

                                ' closingqty = Format(closingqty * convvalue1, "0.000")

                                AxfpSpread1.Col = 7
                                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                AxfpSpread1.Text = Trim(RATE / convvalue1)



                                AxfpSpread1.Col = 1
                                lbl_closingqty.Text = "" + AxfpSpread1.Text + " has closing qty is " + closingqty.ToString() + "" + "  " + uom1

                                If (GINDENTNO = "Y") Then
                                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                                Else
                                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                                End If

                            End If
                            'AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(2, AxfpSpread1.ActiveRow)
                        End If
                    End If

                End If
            ElseIf AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Then
                'QTY
                '===========================================================================
                AxfpSpread1.Col = 3
                Dim uom As String = AxfpSpread1.Text
                Dim uom1 As String
                AxfpSpread1.Col = 1

                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                Dim sql11 As String ' = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + AxfpSpread1.Text + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                ' gconnection.getDataSet(sql11, "closingtable")


                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), AxfpSpread1.Text, Trim(TXT_FROMSTORECODE.Text), "")

                Dim closingqty As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                Else
                    closingqty = 0
                    uom1 = uom
                End If

                'uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                Dim convvalue1 As Double
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    MessageBox.Show("Please Create relation Between " + uom1 + " and " + uom)
                    Exit Sub
                End If
                'closingqty = Format(closingqty * convvalue1, "0.000")
                AxfpSpread1.Col = 1
                lbl_closingqty.Text = "" + AxfpSpread1.Text + " has closing qty is " + closingqty.ToString() + "  " + uom1
                '==================================================================================================
            ElseIf AxfpSpread1.ActiveCol = 3 Then

                AxfpSpread1.Col = 3
                Dim uom As String = AxfpSpread1.Text
                Dim uom1 As String
                AxfpSpread1.Col = 1


                Dim sql11 As String
                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), AxfpSpread1.Text, Trim(TXT_FROMSTORECODE.Text), "")

                Dim closingqty, Rate As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    Rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                Else
                    closingqty = 0
                    Rate = 0
                End If
                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                Dim convvalue1 As Double
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    MessageBox.Show("Please Create relation Between " + uom1 + " and " + uom)
                    Exit Sub
                End If
                closingqty = closingqty * convvalue1

                AxfpSpread1.Col = 7
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(Rate / convvalue1)

                'AxfpSpread1.Row = AxfpSpread1.ActiveRow
                'AxfpSpread1.Col = 1
                'Dim sql1 As String
                'Dim ITEMCODE As String
                'Dim closingqty As Double
                'ITEMCODE = AxfpSpread1.Text
                'SQL = "    sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER inner join inv_inventoryitemmaster on"
                'SQL = SQL & " inv_inventoryitemmaster.category = INVENTORYCATEGORYMASTER.CATEGORYCODE where itemcode='" + Trim(ITEMCODE) + "'"
                ''  sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")

                '    If rateflag = "W" Then
                '        sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(ITEMCODE) + "' "
                '        sql1 = sql1 & " and   cast( CONVERT(VARCHAR(11),'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "', 106) as Date) >  cast( CONVERT(VARCHAR(11), grndate, 106) as Date)  order by trns_seq desc"
                '    Else
                '        sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(ITEMCODE) + "'"
                '        sql1 = sql1 & " and  cast( CONVERT(VARCHAR(11),'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "', 106) as Date) >  cast( CONVERT(VARCHAR(11), grndate, 106) as Date)  order by trns_seq desc"

                '    End If
                '    gconnection.getDataSet(sql1, "ratelist")
                '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then

                '        Dim convvalue As Double
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
                '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)

                '        AxfpSpread1.Col = 4
                '        If AxfpSpread1.Text <> "" Then
                '            Dim iqty As Double
                '            iqty = Val(AxfpSpread1.Text)
                '            AxfpSpread1.Col = 8
                '            AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue) * iqty
                '        Else

                '        End If

                '        AxfpSpread1.Col = 3
                '        SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                '        gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                '        Dim convvalue1 As Double
                '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '            convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                '        Else
                '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                '            Exit Sub
                '        End If

                '        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), ITEMCODE, Trim(TXT_FROMSTORECODE.Text), "")

                '        ' Dim closingqty As Double
                '        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                '            closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")

                '        Else
                '            closingqty = 0
                '        End If
                '        closingqty = closingqty * convvalue1
                '        AxfpSpread1.Col = 1
                '        lbl_closingqty.Text = "" + AxfpSpread1.Text + " has closing qty is " + closingqty.ToString() + ""

                '    Else
                '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(0).Item("itemcode")) + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and isnull(openningqty,0) <>0 "
                '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                '            Dim convvalue As Double
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
                '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                '        End If
                '    End If
                'End If
            ElseIf AxfpSpread1.ActiveCol = 4 Then
                AxfpSpread1.Col = 4
                If (Val(AxfpSpread1.Text) <> 0) Then
                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.Row)
                End If

            ElseIf AxfpSpread1.ActiveCol = 9 Then
                Calculate()
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)


            ElseIf AxfpSpread1.ActiveCol = 5 Then

                AxfpSpread1.Col = 1
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim itemcode1 As String = AxfpSpread1.Text
                AxfpSpread1.Col = 2
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim itemname1 As String = AxfpSpread1.Text
                AxfpSpread1.Col = 3
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim uom3 As String = AxfpSpread1.Text
                AxfpSpread1.Col = 5
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim totqty As String = AxfpSpread1.Text
                If GBATCHNO = "Y" Then
                    If (Val(AxfpSpread1.Text) <> 0) Then
                        Dim match As New Matching
                        match.LBL_ITEMCODE.Text = itemcode1
                        match.lbl_itemname.Text = itemname1
                        match.TType = "ISSUE"
                        match.STORECODE = TXT_FROMSTORECODE.Text
                        match.STORECOD2 = txt_storecode.Text
                        match.TotalQTY = totqty
                        match.docno = txt_Docno.Text
                        match.docdate = Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy")
                        match.uom = uom3
                        match.ShowDialog()
                    End If
                End If


                AxfpSpread1.Col = 5
                    If (Val(AxfpSpread1.Text) <> 0) Then
                        Dim issuedqty As Double = Val(AxfpSpread1.Text)
                        AxfpSpread1.Col = 7
                        Dim RATE As Double = Val(AxfpSpread1.Text)

                        AxfpSpread1.Col = 8
                        AxfpSpread1.Text = issuedqty * RATE
                        AxfpSpread1.Col = 1
                        Dim itemcode As String = AxfpSpread1.Text
                    ''' Sri
                    'AxfpSpread1.Col = 6
                    'Dim Batchno As String = AxfpSpread1.Text
                    '''
                    SQL = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
                        gconnection.getDataSet(SQL, "INV_InventoryItemMaster")
                        If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                            If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
                                AxfpSpread1.Col = 3
                                Dim uom As String = AxfpSpread1.Text
                                Dim uom1 As String
                                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                                Dim sql11 As String '= "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                                ' gconnection.getDataSet(sql11, "closingtable")
                                Dim closingqty As Double
                            'Added by sri for Batch no
                            '  batchnocheck()
                            ' BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
                            'If BATCH_REQ = "YES" Then
                            '        gconnection.BatchWiseClosingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), Batchno)
                            '    Else
                            gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                            ' End If
                            ' end 

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
                                    MessageBox.Show("Please Create relation Between " + uom1 + " and " + uom)
                                    Exit Sub
                                End If
                                closingqty = closingqty * convvalue
                                If (issuedqty > closingqty) Then
                                    '' Sri for Expiry 
                                    'If (gdataset.Tables("expirydate").Rows.Count = 0) Then
                                    '    MessageBox.Show("You have " + closingqty.ToString() + " or more 0 balance items")
                                    '    AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, "0.0")
                                    '    AxfpSpread1.SetActiveCell(5, AxfpSpread1.Row)
                                    'Else
                                    '    MsgBox("This Batch No. Items are Expired !!", MsgBoxStyle.Exclamation)
                                    '    AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, "0.0")
                                    '    AxfpSpread1.SetActiveCell(5, AxfpSpread1.Row)
                                    'End If
                                    ''
                                    MessageBox.Show("You have " + closingqty.ToString() + " or more 0 balance items")
                                    AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, "0.0")
                                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.Row)
                                Else
                                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                                    AxfpSpread1.Col = 6
                                    AxfpSpread1.Lock = True
                                    AxfpSpread1.Col = 11
                                    AxfpSpread1.Lock = True
                                    AxfpSpread1.Col = 12
                                    AxfpSpread1.Lock = True
                                End If
                                If GINDENTNO = "Y" Then
                                    AxfpSpread1.Col = 4
                                    Dim indentqty As Double = Val(AxfpSpread1.Text)
                                    ' Added by Sriram For Nizam Costing indent 
                                    If gShortname = "NIZAM" Then
                                        'SQL = "select docno from inventory_indenthdr where docno in(select indentno from STD_PRODUCTIONPLAN_HEADER where projno='" &  & "')"
                                        'SQL = SQL & " union all"
                                        'SQL = SQL & " Select  docno from inventory_indenthdr where docno In(Select indentno from STD_STOCKINDENT_HEADER)"

                                        SQL = "select projno from STD_PRODUCTIONPLAN_HEADER where projno='" & Txt_IndentNo.Text & "'"
                                        SQL = SQL & " union all "
                                        SQL = SQL & " select TRFRNO from STD_STOCKINDENT_HEADER where TRFRNO='" & Txt_IndentNo.Text & "'"
                                        gconnection.getDataSet(SQL, "COSTING_INDENT")
                                        If (gdataset.Tables("COSTING_INDENT").Rows.Count > 0) Then
                                        Else
                                            If (issuedqty > indentqty) Then
                                                MessageBox.Show("Issued Quantity Cannot be Greater than Indent Quantity")
                                                AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, "0.0")
                                                AxfpSpread1.SetActiveCell(5, AxfpSpread1.Row)
                                            End If
                                        End If
                                    End If
                                    ' End 
                                    If gShortname <> "NIZAM" Then
                                        If (issuedqty > indentqty) Then
                                            MessageBox.Show("Issued Quantity Cannot be Greater than Indent Quantity")
                                            AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, "0.0")
                                            AxfpSpread1.SetActiveCell(5, AxfpSpread1.Row)
                                        End If
                                    End If
                                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                                    Calculate()
                                Else
                                    Calculate()
                                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                                End If
                                If GINDENTNO = "N" Then
                                    AxfpSpread1.Col = 5
                                    check_MinMaxQTY("X", Trim(txt_storecode.Text), itemcode, Val(AxfpSpread1.Text))

                                    check_MinMaxQTY("N", Trim(TXT_FROMSTORECODE.Text), itemcode, Val(AxfpSpread1.Text))
                                End If

                            End If
                        End If
                    Else
                        Dim row As Integer = AxfpSpread1.ActiveRow
                        Dim uom As String
                        Dim indqty As Double
                        Dim uom1 As String

                        If GINDENTNO = "Y" Then
                            AxfpSpread1.Col = 4
                            indqty = Val(AxfpSpread1.Text)
                            AxfpSpread1.Col = 3
                            uom = AxfpSpread1.Text
                            AxfpSpread1.Col = 1
                            SQL = " select I.itemcode,M.Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                            SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
                            gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                            If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                                If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES" Then


                                    '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                                    GroupBox3.Visible = True
                                    '    Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno order by batchno"
                                    'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                                    'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                                    Dim SQL1 As String = "with a as ( "
                                    SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty where trndate<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                                    SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                                    SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0)  as quantity,Vw_RatelistNew.batchrate as rate,closingqty.uom as uom from a inner  join closingqty on "
                                    SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                                    SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                                    SQL1 = SQL1 & " inner  join Vw_RatelistNew on a.batchno=Vw_RatelistNew.batchno"
                                    SQL1 = SQL1 & " and a.itemcode=Vw_RatelistNew.itemcode and  a.storecode=closingqty.storecode and a.storecode=Vw_RatelistNew.storecode "
                                    SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                    SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND a.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  closingqty.closingstock>0 order by trndate desc,AUTOID desc "

                                    gconnection.getDataSet(SQL1, "closingtable")
                                    If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                        For k As Integer = 0 To gdataset.Tables("closingtable").Rows.Count - 1
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
                                            uom1 = gdataset.Tables("closingtable").Rows(k).Item("uom")
                                            AxfpSpread2.SetText(4, k + 1, gdataset.Tables("closingtable").Rows(k).Item("uom"))
                                            AxfpSpread2.Row = k
                                            AxfpSpread2.Col = 5
                                            AxfpSpread2.SetText(5, k + 1, Val(gdataset.Tables("closingtable").Rows(k).Item("rate")))

                                        Next

                                        SQL = "select isnull(convvalue,0),isnull(precise,0) as precise AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                        gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                                        Dim convvalue As Double
                                        Dim pr As Double
                                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                        Else
                                            MessageBox.Show("Please Create Relation Between " + uom1 + " And " + uom)
                                            Exit Sub
                                        End If
                                        AxfpSpread2.SetText(7, 1, Format(Val(indqty / convvalue) + indqty * pr, "0.000"))

                                        AxfpSpread2.SetActiveCell(1, 6)
                                        AxfpSpread2.Focus()

                                    End If

                                Else

                                End If

                                Calculate()
                                If (GroupBox3.Visible = True) Then
                                    AxfpSpread2.SetActiveCell(5, 1)
                                    AxfpSpread2.Focus()
                                Else


                                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                                End If
                            End If
                        End If

                    End If

                    'ElseIf e.keyCode = Keys.F3 Then
                    '    If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                    '        AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                    '        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    '    Else
                    '        If GINDENTNO = "N" Then
                    '            AxfpSpread1.Col = 1
                    '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '            SQL = " select * from STOCKISSUEDETAIL where itemcode='" + Trim(AxfpSpread1.Text) + "' and docdetails='" + txt_Docno.Text + "'"
                    '            gconnection.getDataSet(SQL, "stockissuedetails")
                    '            If (gdataset.Tables("stockissuedetails").Rows.Count > 0) Then
                    '                MessageBox.Show("Please Select Y in Void column for Remove..", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    '            Else
                    '                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                    '                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    '            End If
                    '        End If
                    '    End If

                ElseIf AxfpSpread1.ActiveCol = 6 Then
                If GBATCHNO = "Y" Then
                    AxfpSpread1.Col = 6
                    BatchNoSelection()
                End If
            ElseIf AxfpSpread1.ActiveCol = 11 Then
                    If GSHELVING = "Y" Then
                        AxfpSpread1.Col = 11
                        Fromshelf()
                    End If
                ElseIf AxfpSpread1.ActiveCol = 12 Then
                    If GSHELVING = "Y" Then
                        AxfpSpread1.Col = 12
                        ToShelf()
                    End If
                ElseIf AxfpSpread1.ActiveCol = 5 Then
                    Dim row As Integer = AxfpSpread1.ActiveRow
                Dim uom As String
                Dim indqty As Double
                Dim uom1 As String

                If GINDENTNO = "Y" Then
                    AxfpSpread1.Col = 4
                    indqty = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 3
                    uom = AxfpSpread1.Text
                    AxfpSpread1.Col = 1
                    SQL = " select I.itemcode,M.Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                        If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES" Then


                            '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            GroupBox3.Visible = True
                            '    Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno order by batchno"
                            'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                            'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                            Dim SQL1 As String = "with a as ( "
                            SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,isnull(batchno,'') as  batchno from closingqty where trndate<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                            SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                            SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_RatelistNew.batchrate as rate,closingqty.uom as uom from a inner  join closingqty on "
                            SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                            SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                            SQL1 = SQL1 & " inner  join Vw_RatelistNew on a.batchno=Vw_RatelistNew.batchno"
                            SQL1 = SQL1 & " and a.itemcode=Vw_RatelistNew.itemcode and  a.storecode=closingqty.storecode and a.storecode=Vw_RatelistNew.storecode "
                            SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                            SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND a.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0) >0 order by trndate desc,AUTOID desc "

                            gconnection.getDataSet(SQL1, "closingtable")
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                For k As Integer = 0 To gdataset.Tables("closingtable").Rows.Count - 1
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
                                    uom1 = gdataset.Tables("closingtable").Rows(k).Item("uom")
                                    AxfpSpread2.SetText(4, k + 1, gdataset.Tables("closingtable").Rows(k).Item("uom"))
                                    AxfpSpread2.Row = k
                                    AxfpSpread2.Col = 5
                                    AxfpSpread2.SetText(5, k + 1, Val(gdataset.Tables("closingtable").Rows(k).Item("rate")))

                                Next

                                SQL = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                                Dim convvalue As Double
                                Dim pr As Double
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                    pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                Else
                                    MessageBox.Show("Please create Relation Between " + uom + " and " + uom1)
                                    Exit Sub
                                End If
                                AxfpSpread2.SetText(7, 1, Format(Val(indqty / convvalue) + pr * indqty, "0.000"))

                                AxfpSpread2.SetActiveCell(1, 6)
                                AxfpSpread2.Focus()

                            End If

                        Else
                            AxfpSpread1.Col = 5
                            AxfpSpread1.Lock = False
                        End If
                    End If
                End If
            End If
        End If

        If e.keyCode = Keys.F3 Then
            If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
            Else
                If GINDENTNO = "N" Then
                    AxfpSpread1.Col = 1
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    SQL = " select * from STOCKISSUEDETAIL where itemcode='" + Trim(AxfpSpread1.Text) + "' and docdetails='" + txt_Docno.Text + "'"
                    gconnection.getDataSet(SQL, "stockissuedetails")
                    If (gdataset.Tables("stockissuedetails").Rows.Count > 0) Then
                        MessageBox.Show("Please Select Y in Void column for Remove..", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Else
                        AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
                    End If
                End If
            End If
        End If
        ''Added by sriram for HGA stationary stock issue 
        'If gShortname = "HGA" Then
        '    If e.keyCode = Keys.F2 Then
        '        AxfpSpread1.Col = 1
        '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
        '        Dim itemcode1 As String = AxfpSpread1.Text
        '        AxfpSpread1.Col = 2
        '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
        '        Dim itemname1 As String = AxfpSpread1.Text
        '        AxfpSpread1.Col = 5
        '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
        '        Dim totqty As String = AxfpSpread1.Text
        '        If (Val(AxfpSpread1.Text) <> 0) Then
        '            Dim match As New Employeewise
        '            match.LBL_ITEMCODE.Text = itemcode1
        '            match.lbl_itemname.Text = itemname1
        '            match.TType = "ISSUE"
        '            match.STORECODE = TXT_FROMSTORECODE.Text
        '            match.STORECOD2 = txt_storecode.Text
        '            match.TotalQTY = totqty
        '            match.docno = txt_Docno.Text
        '            match.docdate = Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy")
        '            '  match.uom = uom3
        '            match.ShowDialog()
        '        End If
        '    End If
        'End If





        If (GroupBox3.Visible = True) Then
            AxfpSpread2.SetActiveCell(5, 1)
            AxfpSpread2.Focus()
            Me.Focus()
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
        gSQLString = "select  DISTINCT c.itemcode,i.itemname,c.batchno,c.qty from INV_InventoryItemMaster i inner join  closingqty c  on "
        gSQLString = gSQLString & " i.itemcode=c.itemcode "
        M_WhereCondition = " where i.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(i.void,'')='N' and isnull(c.storecode,'')='" + TXT_FROMSTORECODE.Text + "'  and isnull(c.batchno,'') <>'' and c.itemcode ='" + itemcode + "' "
        'M_Groupby = " c.itemcode,i.itemname,c.batchno "
        M_ORDERBY = " c.itemcode "
        vform.Field = " c.itemcode,i.itemname,c.batchno,cast(C.QTY as varchar)"
        vform.vFormatstring = "    Itemcode    |          Itemname  |         batchno                   |  QTY      "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_Duplicate(vform.keyfield) = False) Then
                AxfpSpread1.Col = 6
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield2)
                ' Added by Sri for Shelving
                If GSHELVING = "Y" Then
                    FROMShelfcheck()
                    ToShelfcheck()
                End If
                If GSHELVING = "Y" Then
                    If (gdataset.Tables("FROMShelfcheck").Rows.Count > 0) Then
                        AxfpSpread1.SetActiveCell(11, AxfpSpread1.ActiveRow)
                    ElseIf (gdataset.Tables("ToShelfcheck").Rows.Count > 0) Then
                        AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                    End If
                End If
                AxfpSpread1.Col = 5
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield3)
                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                ' end
                AxfpSpread1.Focus()
                Else
                    AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If
        End If
    End Sub
    Private Sub FROMShelfcheck()
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = TXT_FROMSTORECODE.Text
            AxfpSpread1.Col = 11
            If AxfpSpread1.Text = "" Then
                'AxfpSpread1.Col = 22
                Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                gconnection.getDataSet(sqlstring, "FROMShelfcheck")
            End If
        End If
    End Sub
    Private Sub ToShelfcheck()
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = txt_storecode.Text
            AxfpSpread1.Col = 12
            If AxfpSpread1.Text = "" Then
                'AxfpSpread1.Col = 22
                Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                gconnection.getDataSet(sqlstring, "ToShelfcheck")
            End If
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
                AxfpSpread1.Col = 11
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                'Added by Sri for Shelving
                ToShelfcheck()
                If (gdataset.Tables("ToShelfcheck").Rows.Count > 0) Then
                    AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                End If
                ' end
                AxfpSpread1.Focus()
            Else
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If
        End If
    End Sub
    Private Sub ToShelf()
        Dim vform As New ListOperattion1
        gSQLString = "SELECT distinct Shelfcode,ShelfDesc FROM InventoryShelfMaster"
        M_WhereCondition = "  WHERE  STORECODE='" + txt_storecode.Text + "' AND ISNULL(FREEZE,'')<>'Y' "
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
                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                AxfpSpread1.Focus()
            Else
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If
        End If
    End Sub

    Private Function check_Duplicate(ByVal Itemcode As String) As Boolean
        Dim i As Integer
        Dim uom As String
        AxfpSpread1.Col = 3
        uom = AxfpSpread1.Text

        AxfpSpread1.Col = 1
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            If i <> AxfpSpread1.ActiveRow Then
                If Trim(AxfpSpread1.Text) = Trim(Itemcode) Then

                    sql = "SELECT * FROM uommaster WHERE uomcode='" + uom + "' AND ISNULL(isweight,'NO')='YES' "
                    gconnection.getDataSet(sql, "WM")
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
    Private Sub binditemcode()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim myValue As Object
        message = "Enter Batch No"
        title = "Batch No"

        gSQLString = "select  distinct ( I.itemcode),M.Itemname,uom,batchprocess, M.Category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "'"
        M_ORDERBY = "I.itemcode"
        vform.Field = " I.itemcode, M.Itemname,uom"
        vform.vFormatstring = "    itemcode    |                       Itemname                  |   UOM      |  batchprocess  "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then

            AxfpSpread1.Col = 3
            AxfpSpread1.Row = AxfpSpread1.ActiveRow

            Dim sql As String = "select distinct UPPER(tranuom) AS tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")

            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
            Next Z
            AxfpSpread1.Text = Trim(vform.keyfield2.ToUpper())

            If (check_Duplicate(vform.keyfield) = False) Then
                AxfpSpread1.Col = 1
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)

                AxfpSpread1.Col = 2
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield1)
                'AxfpSpread1.Col = 3
                'AxfpSpread1.Row = AxfpSpread1.ActiveRow

                'Dim sql As String = "select distinct UPPER(tranuom) AS tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

                'gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")

                'For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                '    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                '    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                'Next Z

                'AxfpSpread1.Text = Trim(vform.keyfield2.ToUpper())

                If Trim(vform.keyfield3) = "YES1" Then

                    GroupBox3.Visible = True
                    Dim SQL1 As String = "with a as ( "
                    SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,isnull(batchno,'') as  batchno from closingqty WHERE TRNDATE<='" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                    SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                    SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_RatelistNew.batchrate as rate,closingqty.uom as uom from a inner  join closingqty on "
                    SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                    SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                    SQL1 = SQL1 & " inner  join Vw_RatelistNew on a.batchno=Vw_RatelistNew.batchno"
                    SQL1 = SQL1 & " and a.itemcode=Vw_RatelistNew.itemcode and  a.storecode=closingqty.storecode and a.storecode=Vw_RatelistNew.storecode "
                    SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(vform.keyfield) + "'"
                    SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND A.TRNDATE<='" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate desc,AUTOID desc "


                    gconnection.getDataSet(SQL1, "closingtable")

                    If (gdataset.Tables("closingtable").Rows.Count > 0) Then
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

                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 5
                            AxfpSpread2.SetText(5, i + 1, Val(gdataset.Tables("closingtable").Rows(i).Item("rate")))



                        Next

                        AxfpSpread2.SetActiveCell(6, 1)
                        AxfpSpread2.Focus()
                    End If

                Else


                    AxfpSpread1.Col = 3
                    Dim uom As String = AxfpSpread1.Text
                    Dim uom1 As String
                    AxfpSpread1.Col = 1

                    Dim sql11 As String
                    gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), AxfpSpread1.Text, Trim(TXT_FROMSTORECODE.Text), "")

                    Dim closingqty, RATE As Double
                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                        RATE = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                    Else
                        closingqty = 0
                        RATE = 0
                    End If
                    uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                    sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                    gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                    Dim convvalue1 As Double
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                    Else
                        MessageBox.Show("Please Create relation Between " + uom1 + " and " + uom)
                        Exit Sub
                    End If

                    closingqty = Format(closingqty * convvalue1, "0.000")

                    AxfpSpread1.Col = 7
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(RATE / convvalue1)

                    If (GINDENTNO = "Y") Then
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    End If
                    'For Batch No Checking
                    ' batchnocheck()
                    FROMShelfcheck()
                    ToShelfcheck()
                    'If GBATCHNO = "Y" Then
                    '    BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
                    'End If
                    'If BATCH_REQ = "YES" Then
                    '    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                    If GSHELVING = "Y" Then
                        If (gdataset.Tables("FROMShelfcheck").Rows.Count > 0) Then
                            AxfpSpread1.SetActiveCell(11, AxfpSpread1.ActiveRow)
                        ElseIf (gdataset.Tables("ToShelfcheck").Rows.Count > 0) Then
                            AxfpSpread1.SetActiveCell(12, AxfpSpread1.ActiveRow)
                        End If
                    ElseIf (GINDENTNO = "Y") Then
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    End If

                    'sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                    'gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                    'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                    '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                    '    Dim sql1 As String
                    '    If rateflag = "W" Then
                    '        sql1 = " select TOP 1  weightedrate as rate,uom from Vw_Ratelist where itemcode='" + vform.keyfield + "' "
                    '        sql1 = sql1 & " and  cast( CONVERT(VARCHAR(11),'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "', 106) as Date) > cast( CONVERT(VARCHAR(11), grndate, 106) as Date) order by trns_seq desc"
                    '    Else
                    '        sql1 = " select TOP 1  batchrate as rate,uom from Vw_Ratelist where itemcode='" + vform.keyfield + "' "
                    '        sql1 = sql1 & " and  cast( CONVERT(VARCHAR(11),'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "', 106) as Date) >  cast( CONVERT(VARCHAR(11), grndate, 106) as Date)  order by trns_seq desc"

                    '    End If
                    '    gconnection.getDataSet(sql1, "ratelist")
                    '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                    '        Dim convvalue As Double
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
                    '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue))
                    '    Else
                    '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + vform.keyfield + "' AND  openningqty<>0 "
                    '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                    '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                    '            Dim convvalue As Double
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


                    '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)


                    '        Else
                    '            AxfpSpread1.Col = 7
                    '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '            AxfpSpread1.Text = 0

                    '        End If
                    '    End If
                    '    If (GINDENTNO = "Y") Then
                    '        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    '    Else
                    '        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    '    End If


                    'End If

                End If
            Else
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If


        End If
    End Sub
    Private Sub batchnocheck()
        If GBATCHNO = "Y" Then
            Dim ITEMCODE As String
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                ITEMCODE = AxfpSpread1.Text
                AxfpSpread1.Col = 6
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(BATCHNO,'') AS BATCHNO FROM INV_InventoryItemMaster WHERE ITEMCODE='" & ITEMCODE & "' AND  ISNULL(VOID,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "BATCHREQ")
                    Dim BATCH_REQ As String
                    BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
                End If
            Next
        End If
    End Sub
    Private Sub binditemname()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim myValue As Object

        gSQLString = "select  distinct (I.itemcode),M.Itemname,uom,batchprocess,M.category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "'"
        vform.Field = " I.itemcode, M.Itemname,I.Uom,batchprocess"
        vform.vFormatstring = "    itemcode    |               Itemname              |       UOM     |"
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

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                Next Z

                If Trim(vform.keyfield3) = "YES1" Then

                    gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), Trim(vform.keyfield2))
                    GroupBox3.Visible = True
                    '  Dim sql As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                    'Dim sql As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                    'sql = sql & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                    Dim SQL1 As String = "with a as ( "
                    SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'"
                    SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                    SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,Vw_RatelistNew.batchrate as rate,closingqty.uom as uom from a inner  join closingqty on "
                    SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                    SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                    SQL1 = SQL1 & " inner  join Vw_RatelistNew on a.batchno=Vw_RatelistNew.batchno"
                    SQL1 = SQL1 & " and a.itemcode=Vw_RatelistNew.itemcode and  a.storecode=closingqty.storecode and a.storecode=Vw_RatelistNew.storecode "
                    SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(vform.keyfield) + "'"
                    SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND A.TRNDATE<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate desc,AUTOID desc "

                    gconnection.getDataSet(SQL1, "closingtable")
                    If (gdataset.Tables("closingtable").Rows.Count > 0) Then
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

                    End If

                Else

                    AxfpSpread1.Col = 3
                    Dim uom As String = AxfpSpread1.Text
                    Dim uom1 As String
                    AxfpSpread1.Col = 1

                    Dim sql11 As String
                    gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), AxfpSpread1.Text, Trim(TXT_FROMSTORECODE.Text), "")

                    Dim closingqty, RATE As Double
                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                        RATE = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                    Else
                        closingqty = 0
                        RATE = 0
                    End If
                    uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                    sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                    gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                    Dim convvalue1 As Double
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue1 = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                    Else
                        MessageBox.Show("Please Create relation Between " + uom1 + " and " + uom)
                        Exit Sub
                    End If

                    closingqty = Format(closingqty * convvalue1, "0.000")

                    AxfpSpread1.Col = 7
                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    AxfpSpread1.Text = Trim(RATE / convvalue1)

                    If (GINDENTNO = "Y") Then
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    End If

                    'sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                    'gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                    'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                    '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                    '    Dim sql1 As String
                    '    If rateflag = "W" Then
                    '        sql1 = " select TOP 1  weightedrate as rate,UOM from ratelist where itemcode='" + vform.keyfield + "' "
                    '        sql1 = sql1 & " and   cast( CONVERT(VARCHAR(11),'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "', 106) as Date) >  cast( CONVERT(VARCHAR(11), grndate, 106) as Date)  order by trns_seq desc"
                    '    Else
                    '        sql1 = " select TOP 1  batchrate as rate,UOM from ratelist where itemcode='" + vform.keyfield + "' "
                    '        sql1 = sql1 & " and  cast( CONVERT(VARCHAR(11),'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "', 106) as Date) >  cast( CONVERT(VARCHAR(11), grndate, 106) as Date)  order by trns_seq desc"

                    '    End If
                    '    gconnection.getDataSet(sql1, "ratelist")
                    '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                    '        Dim convvalue As Double
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
                    '        AxfpSpread1.Col = 7
                    '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                    '    Else
                    '        sql1 = "select (openningvalue/openningqty) as rate from inv_InventoryOpenningstock where itemcode='" + vform.keyfield + "'  and openningqty<>0 "
                    '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                    '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                    '            Dim convvalue As Double
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
                    '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                    '        End If
                    '    End If
                    '    If (GINDENTNO = "Y") Then
                    '        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    '    Else
                    '        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    '    End If


                    'End If
                    '  AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                End If


            End If



        End If

    End Sub

    Private Sub clearoperation()
        Me.dtp_Docdate.Enabled = True
        Txt_IndentNo.Text = ""
        Me.dtp_Docdate.Value = Format(Now, "dd/MMM/yyyy")
        If (GINDENTNO = "Y") Then

            Me.dtp_IndentDate.Value = Format(Now, "dd/MMM/yyyy")
            Call Grid_lock()
        Else
            GridUnLock()
            txt_storecode.Focus()
            dtp_IndentDate.Value = dtp_Docdate.Value
        End If
        TXT_FROMSTORECODE.Enabled = True
        txt_storecode.Enabled = True
        TXT_FROMSTORECODE.Text = ""
        TXT_PARTYNO.Text = ""
        txt_buffet.Text = ""
        txt_storecode.Text = ""
        txt_FromStorename.Text = ""
        Cmd_Add.Enabled = True
        txt_STOREDESC.Text = ""
        txt_Docno.Text = ""
        For k As Integer = 0 To 10
            For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                AxfpSpread1.TypeComboBoxClear(3, k)
            Next
        Next
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        AxfpSpread2.ClearRange(1, 1, -1, -1, True)


        lbl_closingqty.Text = ""

        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True

        txt_Remarks.Text = ""
        Txt_qty.Text = ""
        txt_Totalamount.Text = ""
        autogenerate()
        Txt_IndentNo.Enabled = True
        cmd_IndentNoHelp.Enabled = True

        AxfpSpread1.SetActiveCell(1, 1)
        Cmd_Add.Text = "Add [F7]"
        Cmd_Add.Enabled = True
        Cmd_Freeze.Enabled = True
        Me.lbl_Freeze.Text = ""
        Me.Txt_IndentNo.ReadOnly = False
        If gShortname = "FNCC" Then
            LBL_SESSION.Visible = False
            CMB_SESSION.Visible = False
        End If
        If GBATCHNO = "Y" Then
            Dim STRSQL As String
            STRSQL = "delete from temp_batchdetails "
            gconnection.dataOperation(6, strsql, )
        End If
        'If gShortname = "HGA" Then
        '    Dim STRSQL As String
        '    STRSQL = "delete from temp_employeeissue "
        '    gconnection.dataOperation(6, STRSQL, )
        'End If
    End Sub

    Private Sub Addoperation()
        Dim docno1() As String
        Dim insert(0) As String
        Dim sqlstring As String
        Dim itemcode As String
        Dim i As Integer
        'If Cmd_Add.Text = "Add [F7]" Then
        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            Call autogenerate()
        End If
        docno1 = Split(Trim(txt_Docno.Text), "/")
        sqlstring = "INSERT INTO STOCKISSUEHEADER(Docno,Docdetails,Doctype,Docdate,IndentNo,IndentDate,Storelocationcode,Storelocationname, "
        sqlstring = sqlstring & " Opstorelocationcode, Opstorelocationname, Totalamt,Remarks,Void,VoidReason,Adduser,Adddate,BUFFETMENU,partybookingno)" ',Updateuser,Updatetime)"
        sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "','" + CStr(docno1(0)) + "',"
        'sqlstring = sqlstring & " VALUES ('" & Trim(txt_Docno.Text) & "','" & Trim(txt_Docno.Text) & "','" & Trim(docno) & "',"
        sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "','" & Trim(Txt_IndentNo.Text) & "','" & Format(CDate(dtp_IndentDate.Value), "dd-MMM-yyyy") & "',"
        sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "','" & Trim(txt_storecode.Text) & "', "
        sqlstring = sqlstring & " '" & Trim(txt_STOREDESC.Text) & "'," & Format(Val(txt_Totalamount.Text), "0.000") & " ,"
        sqlstring = sqlstring & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,'N','" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "',"
        sqlstring = sqlstring & " '" & Trim(gUsername) & "',GETDATE(), '" & Trim(txt_buffet.Text) & "','" & Replace(Trim(CStr(TXT_PARTYNO.Text)), "'", "?") & "')"
        ' sqlstring = sqlstring & " '',GETDATE()"
        ' sqlstring = sqlstring & ")"

        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring
        Dim amt As String = 0

        '''******************************************************** Insert into stockissuedetail **********************************'''
        ''' 
        ' Dim Seq As Double = gconnection.getInvSeq(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"))
        For i = 1 To AxfpSpread1.DataRowCnt





            sqlstring = "INSERT INTO STOCKISSUEDETAIL(Docno,Docdetails,Docdate,IndentNo,IndentDate,Storelocationcode,Storelocationname,"
            sqlstring = sqlstring & " Opstorelocationcode,Opstorelocationname,Itemcode,Itemname,Uom,IND_QTY,Qty,batchno,rate,amount,"
            If gShortname = "KGA" Then
                sqlstring = sqlstring & "CLSQTY,"
            End If
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "FROMSHELF,TOSHELF,"
            End If
            If gShortname = "FNCC" Then
                sqlstring = sqlstring & "SESSION,"
            End If
            sqlstring = sqlstring & " Void,Adduser,adddatetime)"
            sqlstring = sqlstring & " VALUES ('" & Trim(txt_Docno.Text) & "','" & Trim(txt_Docno.Text) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(Txt_IndentNo.Text) & "','" & Format(CDate(dtp_IndentDate.Value), "dd-MMM-yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "

            sqlstring = sqlstring & " '" & Trim(txt_storecode.Text) & "','" & Trim(txt_STOREDESC.Text) & "',"
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            itemcode = Trim(AxfpSpread1.Text)
            sqlstring = sqlstring & "'" & Trim(itemcode) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 5
            Dim qty As Double = Val(AxfpSpread1.Text)
            sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 6
            sqlstring = sqlstring & "'" & AxfpSpread1.Text & "',"
            AxfpSpread1.Col = 7
            Dim rate As Double = Val(AxfpSpread1.Text)
            sqlstring = sqlstring & "'" & Format(Val(AxfpSpread1.Text), "0.000") & "',"
            amt = amt + Val(rate * qty)
            sqlstring = sqlstring & "" & Format(Val(rate * qty), "0.000") & ","
            If gShortname = "KGA" Then
                AxfpSpread1.Col = 10
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            End If
            If GSHELVING = "Y" Then
                AxfpSpread1.Col = 11
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 12
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            End If
            If gShortname = "FNCC" Then
                sqlstring = sqlstring & " '" & CMB_SESSION.Text & "',"
            End If
            sqlstring = sqlstring & "'N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "',GETDATE())"
            ' sqlstring = sqlstring & " ' ',GETDATE())"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring



        Next i


        If gShortname = "HGA" Then

            sqlstring = "INSERT INTO stockConsumption_1("
            sqlstring = sqlstring & " Itemcode,Itemname,Uom,storecode,storedesc,docdate,adddate,adduser,stockinhand,physicalstock,consumption,"
            sqlstring = sqlstring & " rate,amount,Void,docno,doctype,remarks)"
            sqlstring = sqlstring & " SELECT Itemcode,Itemname,Uom,opstorelocationcode,opstorelocationname,docdate,GETDATE(),adduser,0,0,qty, rate,amount,Void,docno,'CON','Auto Consumption in Issue time'  FROM STOCKISSUEDETAIL where Docdetails='" + txt_Docno.Text + "' AND ITEMCODE NOT IN ( SELECT ITEMCODE FROM  INV_INVENTORYITEMMASTER WHERE GROUPCODE IN('ABV','TBC','FRBV','CLBV') ) "


            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

        ElseIf Mid(UCase(gShortname), 1, 3) = "NIZ" And Trim(txt_storecode.Text) = "KIT" Then
            sqlstring = "INSERT INTO stockConsumption_1("
            sqlstring = sqlstring & " Itemcode,Itemname,Uom,storecode,storedesc,docdate,adddate,adduser,stockinhand,physicalstock,consumption,"
            sqlstring = sqlstring & " rate,amount,Void,docno,doctype,remarks)"
            sqlstring = sqlstring & " SELECT Itemcode,Itemname,Uom,opstorelocationcode,opstorelocationname,docdate,GETDATE(),adduser,0,0,qty, rate,amount,Void,docno,'CON','Auto Consumption in Issue time'  FROM STOCKISSUEDETAIL where Docdetails='" + txt_Docno.Text + "' "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

        End If



        'sqlstring = "Select * from sysobjects where name='vw_inv_autoconsumption_items' and xtype='V'"
        'gconnection.getDataSet(sqlstring, "vw_inv_autoconsumption_items")
        'If gdataset.Tables("vw_inv_autoconsumption_items").Rows.Count > 0 Then

        '    sqlstring = "INSERT INTO stockConsumption_1("
        '    sqlstring = sqlstring & " Itemcode,Itemname,Uom,storecode,storedesc,docdate,adddate,adduser,stockinhand,physicalstock,consumption,"
        '    sqlstring = sqlstring & " rate,amount,Void,docno,doctype,remarks)"
        '    sqlstring = sqlstring & " SELECT Itemcode,Itemname,Uom,opstorelocationcode,opstorelocationname,docdate,GETDATE(),adduser,0,0,qty, rate,amount,Void,docno,'CON','Auto Consumption in Issue time'  FROM STOCKISSUEDETAIL where Docdetails='" + txt_Docno.Text + "' AND ITEMCODE IN ( SELECT ITEMCODE FROM  vw_inv_autoconsumption_items) "
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = sqlstring

        'End If


        If UCase(gShortname) = "UC" Then

            sqlstring = "INSERT INTO Indent_Used("
            sqlstring = sqlstring & " Indent_no,Docno,Indentdate,Docdate,itemcode,storecode,indentqty,TransactionQty,rate,TransactionType,Trn_no,Freeze )"
            sqlstring = sqlstring & " SELECT Indentno,Docno,Indentdate,Docdate,itemcode,opstorelocationcode,ind_qty,qty,rate,'ISSUE','','N'    FROM STOCKISSUEDETAIL where Docdetails='" + txt_Docno.Text + "' "

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            sqlstring = " update PO_STOCKINDENTAUTH_DET set IssTransQty=isnull((select sum(qty) as qty from STOCKISSUEDETAIL g where g.Itemcode=PO_STOCKINDENTAUTH_DET.ITEMCODE and g.IndentNo=PO_STOCKINDENTAUTH_DET.IndentNo  and isnull(g.VOID,'N')<>'Y' ),0)  WHERE Indentno ='" & Txt_IndentNo.Text & "' "

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            sqlstring = "   Update   PO_STOCKINDENTAUTH_HDR set ISSUESTATUS='OPEN' where Docdetails  in   (select distinct Docdetails from PO_STOCKINDENTAUTH_DET where isnull(QTY,0)<>isnull(IssTransQty,0)) AND Indentno ='" & Txt_IndentNo.Text & "'"

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            sqlstring = "  Update   PO_STOCKINDENTAUTH_HDR set ISSUESTATUS='CLOSED' where Docdetails not in   (select distinct Docdetails from PO_STOCKINDENTAUTH_DET where isnull(QTY,0)<>isnull(IssTransQty,0)) AND Indentno ='" & Txt_IndentNo.Text & "' "

            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring



        End If

        gconnection.MoreTrans(insert)
        If gShortname = "RSAOI" Then
            'For Maker / Checker 
            gconnection.FORM_MCA(GmoduleName, "STOCKISSUEHEADER", "Docdetails='" & Trim(txt_Docno.Text) & "'", "I") '''for mca
            gconnection.FORM_MCA(GmoduleName, "STOCKISSUEDETAIL", "Docdetails='" & Trim(txt_Docno.Text) & "'", "I") '''for mca
            If TO_CHK_MCA_YN(GmoduleName) = True And gUserCategory = "U" Then
                sqlstring = "insert into authPending (Docdetail,Docdate,Storecode,Itemcode,TType) "
                sqlstring = sqlstring & "select Docdetails,Docdate,storelocationcode,Itemcode,'ISSUE' from STOCKISSUEDETAIL where Docdetails='" & txt_Docno.Text & "'"
                gconnection.dataOperation(6, sqlstring, )
                sqlstring = "insert into authPending (Docdetail,Docdate,Storecode,Itemcode,TType) "
                sqlstring = sqlstring & "select Docdetails,Docdate,opstorelocationname,Itemcode,'RECEIEVE' from STOCKISSUEDETAIL where Docdetails='" & txt_Docno.Text & "'"
                gconnection.dataOperation(6, sqlstring, )

            End If
            ' End
        End If

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

        'If gShortname = "HGA" Then
        '    Dim strsql As String
        '    strsql = "insert into inv_EMPLOYEEISSUE(trnno,itemcode,trndate,QTY,empcode,REMARKS,issqty,EMPNAME,ITEMNAME)"
        '    strsql = strsql & " select Trnno,itemcode,Trndate,qty,empcode,remarks,issqty,EMPNAME,ITEMNAME from temp_employeeissue where trnno= '" & txt_Docno.Text & "'"
        '    gconnection.dataOperation(6, strsql, )
        '    strsql = "delete from temp_employeeissue "
        '    gconnection.dataOperation(6, strsql, )
        'End If


    End Sub

    Private Sub updateoperation()
        Dim docno1() As String
        Dim insert(0) As String
        Dim sqlstring As String
        Dim itemcode As String
        Dim i As Integer
        Dim SEQ As Double
        Dim amt As String = 0
        If Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
            sqlstring = "select * from STOCKISSUEHEADER WHERE Docdetails='" + Trim(CStr(txt_Docno.Text)) + "' and cast(convert(varchar(11),Docdate,106)as datetime)='" & Format(Me.dtp_Docdate.Value, "dd/MMM/yyyy") & "'"
            gconnection.getDataSet(sqlstring, "backdate")
            If gdataset.Tables("backdate").Rows.Count > 0 Then
                docno1 = Split(Trim(txt_Docno.Text), "/")
                If gShortname = "RSAOI" Then
                    ''TO CHECK MCA Y/N
                    If TO_CHK_MCA_YN(GmoduleName) = True And (gUserCategory <> "S" And ModuleAdmin <> True) And Autherize = "Y" Then
                        MessageBox.Show("You don't Have rights to Update this Record, Super User/Module Admin Only can update this Record!.", MyCompanyName, MessageBoxButtons.OK)
                        Exit Sub
                    End If
                    If MCA <> "M" And Autherize <> "Y" Then
                        MessageBox.Show("You Can't' Update the Checked Records", MyCompanyName, MessageBoxButtons.OK)
                        Exit Sub
                    End If
                    ' End
                End If
                'FOR LOG DATA
                sqlstring = "INSERT INTO STOCKISSUEHEADER_LOG(Docno,Docdetails,Doctype,Docdate,IndentNo,IndentDate,Storelocationcode,Storelocationname,Opstorelocationcode, Opstorelocationname, Totalamt,Remarks,Void,VoidReason,Adduser,Adddate,partybookingno) "
                sqlstring = sqlstring & " SELECT Docno,Docdetails,Doctype,Docdate,IndentNo,IndentDate,Storelocationcode,Storelocationname,Opstorelocationcode, Opstorelocationname, Totalamt,Remarks,Void,VoidReason,Adduser,Adddate,partybookingno FROM STOCKISSUEHEADER WHERE  Docdetails='" & Trim(txt_Docno.Text) & "' AND INDENTNO = '" & Trim(Txt_IndentNo.Text) & "'"
                gconnection.getDataSet(sqlstring, "STOCKISSUEHEADER_LOG")

                sqlstring = "INSERT INTO STOCKISSUEDETAIL_LOG(Docno,Docdetails,Docdate,IndentNo,IndentDate,Storelocationcode,Storelocationname,"
                sqlstring = sqlstring & " Opstorelocationcode,Opstorelocationname,Itemcode,Itemname,Uom,IND_QTY,Qty,batchno,rate,amount,"
                If gShortname = "KGA" Then
                    sqlstring = sqlstring & "CLSQTY,"
                End If
                If GSHELVING = "Y" Then
                    sqlstring = sqlstring & "FROMSHELF,TOSHELF,"
                End If
                If gShortname = "FNCC" Then
                    sqlstring = sqlstring & "SESSION,"
                End If
                sqlstring = sqlstring & " Void,Adduser,adddatetime,Updateuser,Updatetime)"
                sqlstring = sqlstring & " SELECT Docno,Docdetails,Docdate,IndentNo,IndentDate,Storelocationcode,Storelocationname,"
                sqlstring = sqlstring & " Opstorelocationcode,Opstorelocationname,Itemcode,Itemname,Uom,IND_QTY,Qty,batchno,rate,amount,"
                If gShortname = "KGA" Then
                    sqlstring = sqlstring & "CLSQTY,"
                End If
                If GSHELVING = "Y" Then
                    sqlstring = sqlstring & "FROMSHELF,TOSHELF,"
                End If
                If gShortname = "FNCC" Then
                    sqlstring = sqlstring & "SESSION,"
                End If
                sqlstring = sqlstring & " Void,Adduser,adddatetime,Updateuser,Updatetime FROM STOCKISSUEDETAIL WHERE docdetails='" & Trim(txt_Docno.Text) & "' AND INDENTNO = '" & Trim(Txt_IndentNo.Text) & "' "
                gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL_LOG")
                'LOG DATA ENDS 
                sqlstring = "UPDATE STOCKISSUEHEADER SET Docdate='" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "', "
                sqlstring = sqlstring & " Storelocationcode='" & Trim(TXT_FROMSTORECODE.Text) & "',"
                sqlstring = sqlstring & " Storelocationname='" & Trim(txt_FromStorename.Text) & "',"
                sqlstring = sqlstring & " Opstorelocationcode='" & Trim(txt_storecode.Text) & "',"
                sqlstring = sqlstring & " Opstorelocationname='" & Trim(txt_STOREDESC.Text) & "', "
                sqlstring = sqlstring & " Totalamt=" & Format(Val(txt_Totalamount.Text), "0.000") & ","
                sqlstring = sqlstring & " Remarks='" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,Void='N',"
                sqlstring = sqlstring & " partybookingno='" & Replace(Trim(CStr(TXT_PARTYNO.Text)), "'", "?") & "' ,"
                sqlstring = sqlstring & " BUFFETMENU='" & Trim(txt_buffet.Text) & "', "
                sqlstring = sqlstring & " VoidReason = '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "',Updateuser='" & Trim(gUsername) & "',"
                sqlstring = sqlstring & " Updatetime=GETDATE()"
                sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
                sqlstring = sqlstring & " AND INDENTNO = '" & Trim(Txt_IndentNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring

                '''********************************************************* DELETE FROM stockissuedetail *****************************************************'''
                sqlstring = "DELETE FROM STOCKISSUEDETAIL WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
                sqlstring = sqlstring & " AND INDENTNO = '" & Trim(Txt_IndentNo.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring

                Dim sql1 As String



                For i = 1 To AxfpSpread1.DataRowCnt


                    sqlstring = "INSERT INTO STOCKISSUEDETAIL(Docno,Docdetails,Docdate,IndentNo,IndentDate,Storelocationcode,Storelocationname,"
                    sqlstring = sqlstring & " Opstorelocationcode,Opstorelocationname,Itemcode,Itemname,Uom,IND_QTY,Qty,batchno,rate,amount,"
                    If gShortname = "KGA" Then
                        sqlstring = sqlstring & "CLSQTY,"
                    End If
                    If GSHELVING = "Y" Then
                        sqlstring = sqlstring & "FROMSHELF,TOSHELF,"
                    End If
                    If gShortname = "FNCC" Then
                        sqlstring = sqlstring & "SESSION,"
                    End If
                    sqlstring = sqlstring & " Void,Adduser,adddatetime,Updateuser,Updatetime)"
                    sqlstring = sqlstring & " VALUES ('" & Trim(txt_Docno.Text) & "','" & Trim(txt_Docno.Text) & "',"
                    sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
                    sqlstring = sqlstring & " '" & Trim(Txt_IndentNo.Text) & "','" & Format(CDate(dtp_IndentDate.Value), "dd-MMM-yyyy") & "',"
                    sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                    sqlstring = sqlstring & " '" & Trim(txt_storecode.Text) & "','" & Trim(txt_STOREDESC.Text) & "',"
                    AxfpSpread1.Row = i

                    AxfpSpread1.Col = 1
                    itemcode = Trim(AxfpSpread1.Text)
                    sqlstring = sqlstring & "'" & Trim(itemcode) & "',"
                    AxfpSpread1.Col = 2
                    sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 3
                    sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Col = 4
                    sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Row = i

                    AxfpSpread1.Col = 5
                    Dim qty As Double = Val(AxfpSpread1.Text)
                    sqlstring = sqlstring & "" & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    AxfpSpread1.Row = i

                    AxfpSpread1.Col = 6
                    sqlstring = sqlstring & "'" & AxfpSpread1.Text & "',"
                    AxfpSpread1.Row = i

                    AxfpSpread1.Col = 7
                    Dim rate As Double = Val(AxfpSpread1.Text)
                    amt = amt + Val(rate * qty)
                    sqlstring = sqlstring & "'" & Format(Val(rate), "0.000") & "',"
                    sqlstring = sqlstring & "" & Format(qty * rate, "0.000") & ","
                    If gShortname = "KGA" Then
                        AxfpSpread1.Col = 10
                        sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                    End If
                    If GSHELVING = "Y" Then
                        AxfpSpread1.Col = 11
                        sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                        AxfpSpread1.Col = 12
                        sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                    End If
                    If gShortname = "FNCC" Then
                        sqlstring = sqlstring & " '" & CMB_SESSION.Text & "',"
                    End If

                    AxfpSpread1.Col = 9
                    sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
                    sqlstring = sqlstring & " '" & Trim(gUsername) & "',GETDATE(),"
                    sqlstring = sqlstring & " '" & Trim(gUsername) & "',GETDATE())"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring

                Next i

                If gShortname = "HGA" Then

                    sqlstring = "UPDATE  stockConsumption_1 SET VOID='Y' WHERE DOCNO='" & Trim(txt_Docno.Text) & "' AND ITEMCODE NOT IN ( SELECT ITEMCODE FROM  INV_INVENTORYITEMMASTER WHERE GROUPCODE IN('ABV','TBC','FRBV','CLBV') )"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring

                    sqlstring = "INSERT INTO stockConsumption_1("
                    sqlstring = sqlstring & " Itemcode,Itemname,Uom,storecode,storedesc,docdate,adddate,adduser,stockinhand,physicalstock,consumption,"
                    sqlstring = sqlstring & " rate,amount,Void,docno,doctype,remarks)"
                    sqlstring = sqlstring & " SELECT Itemcode,Itemname,Uom,opstorelocationcode,opstorelocationname,docdate,GETDATE(),adduser,0,0,qty, rate,amount,Void,docno,'CON','Auto Consumption in Issue time'  FROM STOCKISSUEDETAIL where Docdetails='" + txt_Docno.Text + "' AND ITEMCODE NOT IN ( SELECT ITEMCODE FROM  INV_INVENTORYITEMMASTER WHERE GROUPCODE IN('ABV','TBC','FRBV','CLBV') ) "

                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring

                End If

                If UCase(gShortname) = "UC" Then

                    sqlstring = "UPDATE  Indent_Used SET FREEZE='Y' WHERE Indent_no='" & Trim(Txt_IndentNo.Text) & "' "
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring

                    sqlstring = "INSERT INTO Indent_Used("
                    sqlstring = sqlstring & " Indent_no,Docno,Indentdate,Docdate,itemcode,storecode,indentqty,TransactionQty,rate,TransactionType,Trn_no,Freeze )"
                    sqlstring = sqlstring & " SELECT Indentno,Docno,Indentdate,Docdate,itemcode,opstorelocationcode,ind_qty,qty,rate,'ISSUE','','N'    FROM STOCKISSUEDETAIL where Indentno='" + Txt_IndentNo.Text + "' "

                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring

                    sqlstring = " update PO_STOCKINDENTAUTH_DET set IssTransQty=isnull((select sum(qty) as qty from STOCKISSUEDETAIL g where g.Itemcode=PO_STOCKINDENTAUTH_DET.ITEMCODE and g.IndentNo=PO_STOCKINDENTAUTH_DET.IndentNo  and isnull(g.VOID,'N')<>'Y' ),0)  WHERE Indentno ='" & Txt_IndentNo.Text & "' "

                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring

                    sqlstring = "   Update   PO_STOCKINDENTAUTH_HDR set ISSUESTATUS='OPEN' where Docdetails  in   (select distinct Docdetails from PO_STOCKINDENTAUTH_DET where isnull(QTY,0)<>isnull(IssTransQty,0)) AND Indentno ='" & Txt_IndentNo.Text & "'"

                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring

                    sqlstring = "  Update   PO_STOCKINDENTAUTH_HDR set ISSUESTATUS='CLOSED' where Docdetails not in   (select distinct Docdetails from PO_STOCKINDENTAUTH_DET where isnull(QTY,0)<>isnull(IssTransQty,0)) AND Indentno ='" & Txt_IndentNo.Text & "' "

                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring



                End If


                'If (GACCPOST.ToUpper() = "Y") And gAcPostingWise = "STORE" Then

                '    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "'"
                '    ReDim Preserve insert(insert.Length)
                '    insert(insert.Length - 1) = sqlstring


                '    sqlstring = "Select  * from AccountstaggingNEW where code='" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(VOID,'')<>'Y'"
                '    gconnection.getDataSet(sqlstring, "CODE")
                '    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                '        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                '        acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                '        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                '        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                '        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                '        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                '        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                '        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                '        sqlstring = sqlstring & " VALUES('" & Trim(txt_Docno.Text) & "', '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy ") & "', "
                '        sqlstring = sqlstring & "'', 'ISSUE', '" & accode & "',"
                '        sqlstring = sqlstring & "'" & acdesc & "',"
                '        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                '        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                '        sqlstring = sqlstring & "'CREDIT',"


                '        decription = "Issue  no " + Trim(txt_Docno.Text) + " date " + Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") + ""
                '        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                '        sqlstring = sqlstring & "'N','" + gUsername + "')"
                '        ReDim Preserve insert(insert.Length)
                '        insert(insert.Length - 1) = sqlstring
                '    Else
                '        MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR StoreCode:-'" & txt_storecode.Text & "'")
                '        Exit Sub
                '    End If
                '    sqlstring = "Select  * from AccountstaggingNEW where code='" & Trim(txt_storecode.Text) & "' AND ISNULL(VOID,'')<>'Y'"
                '    gconnection.getDataSet(sqlstring, "CODE")
                '    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                '        accode = gdataset.Tables("CODE").Rows(0).Item("Accountcode")
                '        acdesc = gdataset.Tables("CODE").Rows(0).Item("accountdesc")
                '        slcode = gdataset.Tables("CODE").Rows(0).Item("slcode")
                '        sldesc = gdataset.Tables("CODE").Rows(0).Item("sldesc")
                '        costcode = gdataset.Tables("CODE").Rows(0).Item("costcentercode")
                '        costdesc = gdataset.Tables("CODE").Rows(0).Item("costcenterdesc")

                '        sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                '        sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                '        sqlstring = sqlstring & " VALUES('" & Trim(txt_Docno.Text) & "', '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy ") & "', "
                '        sqlstring = sqlstring & "'', 'ISSUE', '" & accode & "',"
                '        sqlstring = sqlstring & "'" & acdesc & "',"
                '        sqlstring = sqlstring & "'" & slcode & "','" & sldesc & "',"
                '        sqlstring = sqlstring & "'" & costcode & "','" & costdesc & "',"
                '        sqlstring = sqlstring & "'DEBIT',"


                '        decription = "Issue  no " + Trim(txt_Docno.Text) + " date " + Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") + ""
                '        sqlstring = sqlstring & "'" & amt & "','" & decription & "',"

                '        ''slcode = txt_Storecode.Text
                '        sqlstring = sqlstring & "'N','" + gUsername + "')"
                '        ReDim Preserve insert(insert.Length)
                '        insert(insert.Length - 1) = sqlstring
                '    Else
                '        MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR StoreCode:-'" & txt_storecode.Text & "'")
                '        Exit Sub
                '    End If
                'End If

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
                Addoperation()
            End If
        End If
    End Sub
    Private Sub voidoperationupdate()
        Dim sqlstring As String
        Dim insert(0) As String
        Dim i As Integer
        Dim seq1 As Double


        sqlstring = "delete from STOCKISSUEHEADER  WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        insert(0) = sqlstring

        sqlstring = "delete from STOCKISSUEDETAIL  WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring

        sqlstring = "delete from  closingqty where   trnno='" + Trim(txt_Docno.Text) + "'"

        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring


        If (GACCPOST.ToUpper() = "Y") Then

            ' sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "'"
            sqlstring = "delete from  JOURNALENTRY  where VoucherNo='" & Trim(txt_Docno.Text) & "'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

        End If


        gconnection.MoreTrans1(insert)

    End Sub
    Private Sub voidoperation()
        Dim sqlstring As String
        Dim insert(0) As String
        Dim i As Integer
        Dim seq1 As Double
        sqlstring = "UPDATE STOCKISSUEHEADER SET "
        sqlstring = sqlstring & " Void='Y',"
        sqlstring = sqlstring & " VoidReason = '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "',voiduser='" & Trim(gUsername) & "',"
        sqlstring = sqlstring & " voidtime='" & Format(Now, "dd-MMM-yyyy") & "'"
        sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "

        insert(0) = sqlstring
        sqlstring = " update STOCKISSUEDETAIL set void='Y',voiduser='" & Trim(gUsername) & "',voidtime=GETDATE() where  docdetails='" & Trim(txt_Docno.Text) & "' "

        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring

        If gShortname = "HGA" Then

            sqlstring = "UPDATE  stockConsumption_1 SET VOID='Y' WHERE DOCNO='" & Trim(txt_Docno.Text) & "' AND ITEMCODE NOT IN ( SELECT ITEMCODE FROM  INV_INVENTORYITEMMASTER WHERE GROUPCODE IN('ABV','TBC','FRBV','CLBV') )"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring


            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

        End If

        If (GACCPOST.ToUpper() = "Y") Then

            sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

        End If
        If UCase(gShortname) = "UC" Then

            sqlstring = "UPDATE  Indent_Used SET FREEZE='Y' WHERE DOCNO='" & Trim(txt_Docno.Text) & "' "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
        End If
        If GBATCHNO = "Y" Then
            Dim strsql As String
            strsql = "delete from inv_Batchdetails where trnno= '" & Trim(txt_Docno.Text) & "'  "
            gconnection.dataOperation(6, strsql, )
        End If
        gconnection.MoreTrans(insert)

    End Sub

    Private Function validateoninsert() As Boolean
        Dim flag, checkBdate As Boolean
        Dim qty, closingqty, closingvalue As Double
        Cmd_Add.Enabled = False

        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), txt_storecode.Text)
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



        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), txt_storecode.Text, TXT_FROMSTORECODE.Text)
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
            MessageBox.Show("Doc Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If
        If (GINDENTNO = "Y") Then
            If Txt_IndentNo.Text = "" Then
                MessageBox.Show("Please Fill Indent No ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If

            If Txt_IndentNo.Text <> "" Then

                If UCase(gShortname) = "UC" Then
                    sql = "select * from PO_STOCKINDENTAUTH_HDR where INDENTNO='" + Txt_IndentNo.Text + "'  AND ISSUESTATUS='OPEN'"
                    gconnection.getDataSet(sql, "PendingIndent")
                    If (gdataset.Tables("PendingIndent").Rows.Count > 0) Then

                    Else
                        MessageBox.Show("Indent has closed  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Call clearoperation()
                        flag = True
                        Return flag
                    End If
               
                Else
                    sql = "select * from PendingIndent where INDENT_NO='" + Txt_IndentNo.Text + "' "
                    gconnection.getDataSet(sql, "PendingIndent")
                    If (gdataset.Tables("PendingIndent").Rows.Count > 0) Then

                    Else
                        MessageBox.Show("Indent has closed  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Call clearoperation()
                        flag = True
                        Return flag
                    End If
                End If

            End If

            
        Else
            dtp_IndentDate.Value = dtp_Docdate.Value
        End If
        If txt_Docno.Text = "" Then
            MessageBox.Show("Please Fill IssueDocno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag


        End If
        If txt_storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_storecode.BackColor = Color.Red
            txt_storecode.Focus()

            flag = True
            Return flag
        Else
            txt_storecode.BackColor = Color.White
        End If
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If



        If Trim(TXT_PARTYNO.Text) <> "" Then
            Dim no As Integer = Val(TXT_PARTYNO.Text)
            sql = "select * from Party_Hallbooking_Hdr WHERE ISNULL(FREEZE,'N')<>'Y' AND BOOKINGNO=" & Trim(no) & "  AND cast( PARTYDATE as Date)= Cast('" & Format(CDate(dtp_Docdate.Value), "dd MMM yyyy") & "' as Date) "

            gconnection.getDataSet(sql, "Party_Hallbooking_Hdr")
            If (gdataset.Tables("Party_Hallbooking_Hdr").Rows.Count > 0) Then

            Else
                MessageBox.Show("Party Booking No not Available.. ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If
        Else

            'MessageBox.Show("Plz enter Party Booking No .. ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            'flag = True
            'Return flag

        End If


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
            AxfpSpread1.Col = 5
            If AxfpSpread1.Text = "" Or Val(AxfpSpread1.Text) <= 0 Then
                If gShortname <> "NIZAM" Then
                    MessageBox.Show("Quantity can't be blank or Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    AxfpSpread1.SetActiveCell(4, j)
                    flag = True
                    Return flag
                End If
            End If
            ' Added by Sriram For Nizam Costing indent 
            AxfpSpread1.Row = j
            AxfpSpread1.Col = 5
            If AxfpSpread1.Text = "" Or Val(AxfpSpread1.Text) <= 0 Then
                If gShortname = "NIZAM" Then
                    sql = "select projno from STD_PRODUCTIONPLAN_HEADER where projno='" & Txt_IndentNo.Text & "'"
                    sql = sql & " union all "
                    sql = sql & " select TRFRNO from STD_STOCKINDENT_HEADER where TRFRNO='" & Txt_IndentNo.Text & "'"
                    gconnection.getDataSet(sql, "COSTING_INDENT")
                    If (gdataset.Tables("COSTING_INDENT").Rows.Count > 0) Then
                    Else
                        MessageBox.Show("Quantity can't be blank or Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AxfpSpread1.SetActiveCell(4, j)
                        flag = True
                        Return flag
                    End If
                End If
            End If
            ' End
            AxfpSpread1.Col = 5
            qty = Val(AxfpSpread1.Text)
            If (Val(AxfpSpread1.Text) <> 0) Then
                Dim issuedqty As Double = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 1
                itemcode = AxfpSpread1.Text
                '' Sri
                AxfpSpread1.Col = 6
                Dim Batchno As String = AxfpSpread1.Text
                ''
                sql = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
                gconnection.getDataSet(sql, "INV_InventoryItemMaster")
                If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                    If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
                        AxfpSpread1.Col = 3
                        Dim uom As String = AxfpSpread1.Text
                        Dim uom1 As String

                        ''Added by sri for Batch no
                        'batchnocheck()
                        '' BATCH_REQ = Trim(gdataset.Tables("BATCHREQ").Rows(0).Item("BATCHNO"))
                        'If BATCH_REQ = "YES" Then
                        '    gconnection.BatchWiseClosingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), Batchno)
                        'Else
                        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                        '  End If
                        ' end 


                        Dim precise As Double
                        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                            closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                            uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                            If gShortname = "SKYYE" Or gShortname = "HBC" Then
                                sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                            Else
                                sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                            End If

                            Dim convvalue As Double
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                            Else
                                MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                flag = True
                                Return flag

                            End If
                            If gShortname = "SKYYE" Or gShortname = "HBC" Then
                                closingqty = closingqty / convvalue
                            Else
                                closingqty = closingqty * convvalue
                            End If

                            qty = qty / convvalue
                            If closingqty <= 0 Then
                                MessageBox.Show("Stock is not available....:-" & itemcode)
                                flag = True
                                Return flag
                            End If
                        Else
                            MessageBox.Show("Stock Is Not Available:- " & itemcode)
                            flag = True
                            Return flag
                        End If
                        If (issuedqty > closingqty) Then
                            MessageBox.Show("Issued Quantity Cannot be Greater than Closing Quantity" + closingqty.ToString())
                            flag = True
                            Return flag

                        End If
                    End If

                End If
                If GINDENTNO = "Y" Then
                    AxfpSpread1.Col = 4
                    Dim indentqty As Double = Val(AxfpSpread1.Text)
                    If gShortname = "NIZAM" Then
                        sql = "select projno from STD_PRODUCTIONPLAN_HEADER where projno='" & Txt_IndentNo.Text & "'"
                        sql = sql & " union all "
                        sql = sql & " select TRFRNO from STD_STOCKINDENT_HEADER where TRFRNO='" & Txt_IndentNo.Text & "'"
                        gconnection.getDataSet(sql, "COSTING_INDENT")
                        If (gdataset.Tables("COSTING_INDENT").Rows.Count > 0) Then
                        Else
                            If (issuedqty > indentqty) Then
                                MessageBox.Show("Issued Quantity Cannot be Greater than Indent Quantity")
                                AxfpSpread1.SetText(5, AxfpSpread1.ActiveRow, "0.0")
                                AxfpSpread1.SetActiveCell(5, AxfpSpread1.Row)
                            End If
                        End If
                    End If
                    If gShortname <> "NIZAM" Then
                        If (issuedqty > indentqty) Then
                            MessageBox.Show("Issued Quantity Cannot be Greater than Indent Quantity")
                            flag = True
                            Return flag
                        End If

                    End If
                End If
            End If

            sql = "Select getdate()"
            idate = gconnection.getvalue(sql)
            If (Format(CDate(idate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
                Dim count As Double = 0
                sql = " select trndate,closingstock -" & qty & "  from closingqty where closingstock -" & qty & "<0 and cast(convert(varchar(11),trndate,106)as datetime) > cast(convert(varchar(11),'" & Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd") & "',106)as datetime) and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  "

                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    MessageBox.Show("Issue create " + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text + "  on" + gdataset.Tables("closingqty").Rows(0).Item("trndate").ToString(), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag
                End If
            End If

        Next
        If GBATCHNO = "Y" Then
            Dim ITEMCODE As String
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 1
                ITEMCODE = AxfpSpread1.Text
                AxfpSpread1.Col = 6
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    ' Dim sqlstring As String = "SELECT ISNULL(ExpiryDate,'') AS ExpiryDate FROM INV_InventoryItemMaster WHERE ITEMCODE='" & ITEMCODE & "' AND  ISNULL(VOID,'N') <> 'Y'"
                    Dim sqlstring As String = "select * from INV_InventoryItemMaster where isnull(expirydate,'')='yes' and itemcode in(select itemcode from tEmp_Batchdetails)"
                    gconnection.getDataSet(sqlstring, "BATCHREQ")
                    If gdataset.Tables("BATCHREQ").Rows.Count = 0 Then
                        'If BATCH_REQ = "YES" Then
                        MessageBox.Show("Please Enter Batch No. ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                        'End If
                    End If
                End If
            Next
        End If
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = TXT_FROMSTORECODE.Text
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 11
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "FROMShelfcheck")
                    If gdataset.Tables("FROMShelfcheck").Rows.Count > 0 Then
                        MessageBox.Show("Please Enter From  Shelf ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If
            Next
        End If
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = txt_storecode.Text
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 12
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "ToShelfcheck")
                    If gdataset.Tables("ToShelfcheck").Rows.Count > 0 Then
                        MessageBox.Show("Please Enter To Shelf ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If
            Next
        End If
        Return False
    End Function

    Private Function validateonupdate() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), txt_storecode.Text)
        'Else
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
        'End If
        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), txt_storecode.Text, TXT_FROMSTORECODE.Text)

        If checkBdate = True And RESU1 = False Then
            MsgBox("Business date closed..")
            flag = True
            Return flag
        End If
        If gShortname = "SKYYE" Then
            gSQLString = "SELECT isnull(APPROVE,'')as approve FROM INVENTORY_INDENTHDR WHERE indent_no='" & Txt_IndentNo.Text & "' "
            gconnection.getDataSet(gSQLString, "updte")
            Dim APPR As String
            APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
            If APPR = "Y" Then
                MsgBox("This Indent is already Approved You cant update it ")
                flag = True
                Return flag
            End If
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
            flag = True
            Return flag
        End If
        If DateDiff(DateInterval.Day, (CDate(dtp_Docdate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("Doc Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If
        If (GINDENTNO = "Y") Then
            If Txt_IndentNo.Text = "" Then
                MessageBox.Show("Please Fill Indent No ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If
        End If
        If txt_Docno.Text = "" Then
            MessageBox.Show("Please Fill IssueDocno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag


        End If
        If txt_storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_storecode.BackColor = Color.Red
            txt_storecode.Focus()

            flag = True
            Return flag
        Else
            txt_storecode.BackColor = Color.White
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
            AxfpSpread1.Col = 5
            Dim qty As String = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 9
            Dim iVOID As String = AxfpSpread1.Text
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim convvalue As Double
            Dim precise As Double
            Dim batchno As String
            AxfpSpread1.Col = 6

            If qty <= 0 Then
                MessageBox.Show("Quantity can't be blank or Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(5, i + 1)
                flag = True
                Return flag
            End If


            batchno = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            uom1 = AxfpSpread1.Text
            Dim sql As String = "select qty,isnull(batchyn,'') as  batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  "
            sql = sql & " and Trnno='" + txt_Docno.Text + "' "
            If (batchno <> "") Then
                sql = sql & " and  batchno='" + batchno + "' "
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                sql = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
                    precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))
                Else
                    MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag

                End If

                '       convvalue = gconnection.getvalue(sql)
            Else
                qty1 = 0
                convvalue = 1

            End If

            sql = "select closingstock +" + Format(Val(-((qty / convvalue) + (qty * precise)) - qty1), "0.000") + " from closingqty where cast (CONVERT(VARCHAR(11), trndate, 106) as Date)>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(-((qty / convvalue) + (qty * precise)) - qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "'  "
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                If iVOID = "N" Then
                    MessageBox.Show("Updation create" + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag
                End If

            End If

            If (costcenterflag = False) Then

                sql = "select qty,batchyn,uom,isnull(batchno,'') as  batchno from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'  "
                sql = sql & " and Trnno='" + txt_Docno.Text + "' "
                If (batchno <> "") Then
                    sql = sql & " and  batchno='" + batchno + "' "
                End If

                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                    batchno = gdataset.Tables("closingqty").Rows(0).Item("batchno")
                    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                    sql = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"

                    gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
                        precise = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise"))
                    Else
                        MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag

                    End If




                Else
                    qty1 = 0
                    batchyn = "N"
                    convvalue = 1
                End If
                If iVOID = "Y" Then
                    qty = 0
                End If
                sql = "select closingstock +" + Format(Val(((qty / convvalue) + (qty * precise)) - qty1), "0.000") + " from closingqty where cast( CONVERT(VARCHAR(11), trndate, 106) as date)>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
                sql = sql & "and closingstock +" + Format(Val(((qty / convvalue) + (qty * precise)) - qty1), "0.000") + "<0 and storecode='" + txt_storecode.Text + "' and itemcode='" + itemcode + "' "
                If batchyn = "Y" Then
                    sql = sql & " and batchno='" + batchno + "'"
                End If
                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                    MessageBox.Show("Updation create" + itemcode + " Stock  Negative in " + txt_storecode.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    flag = True
                    Return flag
                End If
            End If
            sql = "Select getdate()"
            idate = gconnection.getvalue(sql)




            'If (Format(CDate(idate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
            '    Dim count As Double = 0

            '    sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate,priority "

            '    gconnection.getDataSet(sql, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

            '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
            '        count = count - Val(qty - (qty1))
            '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
            '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
            '            If count < 0 Then
            '                MessageBox.Show("Updation create" + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        Next
            '    End If

            '    sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'  order by trndate,priority "

            '    gconnection.getDataSet(sql, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

            '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
            '        count = count - Val(-qty + (qty1))
            '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
            '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
            '            If count < 0 Then
            '                MessageBox.Show("Updation create" + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        Next
            '    End If
            'End If

        Next
        For j As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 5
            If (Val(AxfpSpread1.Text) <> 0) Then
                Dim issuedqty As Double = Val(AxfpSpread1.Text)
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
                        Dim sql11 As String ' = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")

                        ' gconnection.getDataSet(sql11, "closingtable")
                        Dim closingqty As Double

                        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                            closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")

                        Else
                            closingqty = 0
                        End If
                        uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                        sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                        gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                        Dim convvalue As Double
                        Dim precise As Double
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                            precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                        Else
                            MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag

                        End If
                        closingqty = closingqty * convvalue
                        'If (issuedqty > closingqty) Then
                        '    MessageBox.Show("Issued Quantity Cannot be Greater than Closing Quantity" + closingqty.ToString())
                        '    flag = True
                        '    Return flag

                        'End If
                    End If

                End If
                If GINDENTNO = "Y" Then
                    AxfpSpread1.Col = 4
                    Dim indentqty As Double = Val(AxfpSpread1.Text)
                    If (issuedqty > indentqty) Then
                        MessageBox.Show("Issued Quantity Cannot be Greater than Indent Quantity")
                        flag = True
                        Return flag
                    End If

                End If
            End If
        Next
        If GBATCHNO = "Y" Then
            'Dim ITEMCODE As String
            'For j As Integer = 1 To AxfpSpread1.DataRowCnt
            '    AxfpSpread1.Row = j
            '    AxfpSpread1.Col = 1
            '    ITEMCODE = AxfpSpread1.Text
            '    AxfpSpread1.Col = 6
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
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = TXT_FROMSTORECODE.Text
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 11
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "FROMShelfcheck")
                    If gdataset.Tables("FROMShelfcheck").Rows.Count > 0 Then
                        MessageBox.Show("Please Enter From  Shelf ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If
            Next
        End If
        If GSHELVING = "Y" Then
            Dim STORECODE As String
            STORECODE = txt_storecode.Text
            For j As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 12
                If AxfpSpread1.Text = "" Then
                    'AxfpSpread1.Col = 22
                    Dim sqlstring As String = "SELECT ISNULL(SHELFCODE,'') AS SHELFCODE FROM InventoryShelfMaster WHERE STORECODE='" & STORECODE & "' AND  ISNULL(FREEZE,'N') <> 'Y'"
                    gconnection.getDataSet(sqlstring, "ToShelfcheck")
                    If gdataset.Tables("ToShelfcheck").Rows.Count > 0 Then
                        MessageBox.Show("Please Enter To Shelf ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        flag = True
                        Return flag
                    End If
                End If
            Next
        End If


        Return False
    End Function

    Private Function validateonvoid() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        If Mid(UCase(gShortname), 1, 3) = "CCL" Then
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), txt_storecode.Text)
        Else
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
        End If
        If gShortname = "SKYYE" Then
            gSQLString = "SELECT isnull(APPROVE,'')as approve FROM INVENTORY_INDENTHDR WHERE indent_no='" & Txt_IndentNo.Text & "' "
            gconnection.getDataSet(gSQLString, "updte")
            Dim APPR As String
            APPR = gdataset.Tables("updte").Rows(0).Item("APPROVE")
            If APPR = "Y" Then
                MsgBox("This Indent is already Approved You cant void it ")
                flag = True
                Return flag
            End If
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
        If txt_storecode.Text = "" Then
            MessageBox.Show("Please Fill Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_storecode.BackColor = Color.Red
            txt_storecode.Focus()

            flag = True
            Return flag
        Else
            txt_storecode.BackColor = Color.White
        End If
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 5
            Dim qty As String = Val(AxfpSpread1.Text)
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim convvalue As Double
            Dim precise As Double
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
                sql = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                End If
                '  convvalue = gconnection.getvalue(sql)

            Else
                qty1 = 0
                convvalue = 1

            End If
            sql = "select closingstock +" + Format(Val(-qty1), "0.000") + " from closingqty where  cast (CONVERT(VARCHAR(11), trndate, 106) as date)>= cast (CONVERT(VARCHAR(11), '" & Format(CDate(dtp_Docdate.Value), "yyyy-MM-dd") & "', 106) as date) "
            sql = sql & "and closingstock +" + Format(Val(-qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and  itemcode='" + itemcode + "'"
            'If batchyn = "Y" Then
            '    sql = sql & " and batchno='" + batchno + "'"
            'End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Deletion create" + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If
            sql = "select qty,batchyn,uom,isnull(batchno,'') as  batchno from closingqty where  itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'  "
            sql = sql & " and Trnno='" + txt_Docno.Text + "' "
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                batchno = gdataset.Tables("closingqty").Rows(0).Item("batchno")
                uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                sql = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                convvalue = gconnection.getvalue(sql)

            Else
                qty1 = 0
                batchyn = "N"
                convvalue = 1
            End If
            sql = "select closingstock +" + Format(-(qty1), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(-qty1), "0.000") + "<0 and storecode='" + txt_storecode.Text + "' and  itemcode='" + itemcode + "' "
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Deletion create" + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If gUserCategory <> "S" Then
                    flag = True
                    Return flag
                End If
            End If

            If (Format(CDate(idate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
                Dim count As Double = 0

                'sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate "

                'gconnection.getDataSet(sql, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then

                '    count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
                '    count = count - Val(qty - (qty1))
                '    For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
                '        count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
                '        If count < 0 Then
                '            MessageBox.Show("Deletion create" + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '            flag = True
                '            Return flag
                '        End If
                '    Next
                'End If

                sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + txt_storecode.Text + "'  order by trndate,priority "

                gconnection.getDataSet(sql, "closingqty")
                If (gdataset.Tables("closingqty").Rows.Count > 0) Then

                    count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
                    count = count - Val(qty1)
                    For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
                        count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
                        If count < 0 Then
                            MessageBox.Show("Deletion create" + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            If gUserCategory <> "S" Then
                                flag = True
                                Return flag
                            End If
                        End If
                    Next
                End If
            End If


        Next

        Return False
    End Function

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
    Private Function Grid_lock()
        Dim i, j As Integer
        For i = 1 To 100
            AxfpSpread1.Row = i
            For j = 1 To AxfpSpread1.MaxCols

                If j = 5 Or j = 9 Then
                    AxfpSpread1.Col = j
                    AxfpSpread1.Lock = False
                Else
                    AxfpSpread1.Col = j
                    AxfpSpread1.Lock = True
                End If
            Next
        Next
    End Function




    Private Sub autogenerate()
        Try

            If Mid(Me.Cmd_Add.Text, 1, 1) = "A" Then

                Dim sqlstring, financalyear As String
                Dim CATLEN As Integer
                gcommand = New SqlCommand
                financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
                Dim docno As String
                If TXT_FROMSTORECODE.Text <> "" Or txt_storecode.Text <> "" Then
                    If UCase(gShortname) = "JHIC" Or UCase(gShortname) = "FMC" Then
                        docno = Mid(txt_storecode.Text, 1, 3)
                    Else
                        docno = Mid(TXT_FROMSTORECODE.Text, 1, 3)
                    End If
                    If Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 3) = "FNC" Or Mid(UCase(Trim(gShortname)), 1, 2) = "DC" Or UCase(gShortname) = "HGA" Then
                        docno = Mid(txt_storecode.Text, 1, 3)
                    Else
                        If UCase(gShortname) = "MGC" Then
                            docno = Mid(txt_FromStorename.Text, 1, 3)
                        Else
                            docno = Mid(TXT_FROMSTORECODE.Text, 1, 3)
                        End If

                    End If
                    CATLEN = docno.Length
                Else
                    docno = "ISSUE"
                    CATLEN = 5
                End If

                If Mid(UCase(gShortname), 1, 3) = "FMC" Then
                    sqlstring = "SELECT MAX(SUBSTRING(docno,1,5)) FROM stockissueheader --WHERE SUBSTRING(docDETAILS,1," & CATLEN & ")='" & docno & "'"

                Else
                    sqlstring = "SELECT MAX(SUBSTRING(docno,1,5)) FROM stockissueheader WHERE SUBSTRING(docDETAILS,1," & CATLEN & ")='" & docno & "'"
                End If

                gconnection.openConnection()
                gcommand.CommandText = sqlstring
                gcommand.CommandType = CommandType.Text
                gcommand.Connection = gconnection.Myconn
                gdreader = gcommand.ExecuteReader


                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        txt_Docno.Text = docno & "/00001/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        txt_Docno.Text = docno & "/" & Format(gdreader(0) + 1, "00000") & "/" & financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    txt_Docno.Text = docno & "/00001/" & financalyear
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
    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click

        Calculate()

        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then

            If validateoninsert() = False Then

                Addoperation()
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
                vOutfile = Mid("WEI" & (Rnd() * 800000000), 1, 10)
                vOutfile = Replace(vOutfile, ".", "")
                vOutfile = Replace(vOutfile, "+", "")
                vOutfile = Replace(vOutfile, "-", "")
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
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ISSUE")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ISSUE")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If



                sqlstring = " exec proc_closingqtyone 'ISSUE_ADD' "
                gconnection.ExcuteStoreProcedure(sqlstring)
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)

                If MsgBox("DO you want to Print ?", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, "View Report") = MsgBoxResult.Ok Then
                    viewprint = True
                    Call Cmd_View_Click(Cmd_View, e)
                    viewprint = False
                End If
                clearoperation()
            Else
                Cmd_Add.Enabled = True
            End If
        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
            If validateonupdate() = False Then
                updateoperation()
                ' Addoperation()
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
                vOutfile = Mid("WEI" & (Rnd() * 800000000), 1, 10)
                vOutfile = Replace(vOutfile, ".", "")
                vOutfile = Replace(vOutfile, "+", "")
                vOutfile = Replace(vOutfile, "-", "")
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
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ISSUE")
                Else
                    Dim thr As New Thread(Sub() CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ISSUE"))
                    thr.Start()
                End If


                sqlstring = " exec proc_closingqtyone 'ISSUE_UPDATE' "
                gconnection.ExcuteStoreProcedure(sqlstring)

                '   strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ISSUE")
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)
                'sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                'gconnection.ExcuteStoreProcedure(sqlstring)

                If MsgBox("DO you want to Print ?", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, "View Report") = MsgBoxResult.Ok Then
                    viewprint = True
                    Call Cmd_View_Click(Cmd_View, e)
                End If
                viewprint = False
                clearoperation()

            End If
        End If
    End Sub

    Private Sub txt_storecode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_storecode.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (txt_storecode.Text <> "") Then
                txt_storecode_Validated(sender, e)
            Else
                cmd_fromStorecodeHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txt_storecode_Validated(sender As Object, e As EventArgs) Handles txt_storecode.Validated
        Dim SQL As String
        If Trim(txt_storecode.Text) <> "" Then
            If UCase(gShortname) = "MGC" Then
                SQL = "Select storecode,storedesc,ctype,STORESTATUS from Vw_Store_Costcenter where storecode='" + txt_storecode.Text + "' and storestatus <>'M'"
            Else
                SQL = "Select storecode,storedesc,ctype,STORESTATUS from Vw_Store_Costcenter where storecode='" + txt_storecode.Text + "' and storestatus <>'M'"
            End If

            '   SQL = "SELECT * FROM storemaster WHERE storecode='" & Trim(txt_storecode.Text) & "' AND ISNULL(Freeze,'') <> 'Y' and STORESTATUS<>'M'"
            gconnection.getDataSet(SQL, "storemaster")
            If gdataset.Tables("storemaster").Rows.Count > 0 Then
                txt_storecode.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                txt_STOREDESC.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                STORESTATUS = Trim(gdataset.Tables("storemaster").Rows(0).Item("STORESTATUS"))
                If (gdataset.Tables("storemaster").Rows(0).Item("ctype") = "S") Then
                    costcenterflag = False

                Else
                    costcenterflag = True

                End If
                TXT_FROMSTORECODE.Focus()
            Else
                txt_storecode.Text = ""
                txt_storecode.Focus()
            End If
            Call autogenerate()
            If gShortname = "FNCC" Then
                Dim sqlstring As String
                sqlstring = " SELECT ISNULL(SESSIONREQ,'')AS SESSIONREQ FROM STOREMASTER WHERE STORECODE='" & txt_storecode.Text & "' AND  ISNULL(FREEZE,'N') <> 'Y' "
                gconnection.getDataSet(SQLSTRING, "SESSIONRE")
                Dim SESSIONREQ As String
                SESSIONREQ = Trim(gdataset.Tables("SESSIONRE").Rows(0).Item("SESSIONREQ"))
                If SESSIONREQ = "YES" Then
                    LBL_SESSION.Visible = True
                    CMB_SESSION.Visible = True
                    BINDSESSION()
                Else
                    LBL_SESSION.Visible = False
                    CMB_SESSION.Visible = False
                End If
            End If
        Else
            Me.txt_storecode.Text = ""
            Me.txt_storecode.Focus()
        End If

    End Sub

    Private Sub ButCANCEL_Click(sender As Object, e As EventArgs) Handles ButCANCEL.Click
        GroupBox3.Visible = False
    End Sub

    Private Sub AxfpSpread2_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread2.KeyDownEvent
        If (e.keyCode = Keys.Enter) Then
            If AxfpSpread2.ActiveCol = 6 Then
                Dim totqty As Double
                AxfpSpread2.Row = AxfpSpread2.ActiveRow
                AxfpSpread2.Col = 6
                Dim batchqty As Double = Val(AxfpSpread2.Text)
                AxfpSpread2.Col = 3
                Dim clsqty As Double = Val(AxfpSpread2.Text)
                AxfpSpread2.Col = 7
                Dim indentqty As Double = Val(AxfpSpread2.Text)
                If (batchqty > clsqty) Then
                    MessageBox.Show("Issued Quantity Must be Less Than Closing Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    AxfpSpread2.SetText(6, AxfpSpread2.ActiveRow, "0.000")
                    AxfpSpread2.SetActiveCell(6, AxfpSpread2.ActiveRow)

                End If
                If GINDENTNO = "Y" Then
                    If (indentqty < batchqty) Then
                        MessageBox.Show("Issued Quantity Must be Less Than indent Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        AxfpSpread2.SetText(6, AxfpSpread2.ActiveRow, "0.000")
                        AxfpSpread2.SetActiveCell(6, AxfpSpread2.ActiveRow)
                        Exit Sub
                    Else
                        totqty = totqty + batchqty
                        AxfpSpread2.SetText(7, AxfpSpread2.ActiveRow, Val(batchqty))

                        AxfpSpread2.SetText(7, AxfpSpread2.ActiveRow + 1, Val(indentqty - totqty))
                    End If
                End If

                AxfpSpread2.SetActiveCell(6, AxfpSpread2.ActiveRow + 1)
            Else
                AxfpSpread2.SetActiveCell(6, AxfpSpread2.ActiveRow + 1)
            End If

        End If
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
                        AxfpSpread1.SetText(5, K, batchqty * convvalue)
                        AxfpSpread2.Col = 2
                        AxfpSpread1.SetText(6, K, AxfpSpread2.Text)
                        AxfpSpread2.Col = 5
                        AxfpSpread1.SetText(7, K, AxfpSpread2.Text)
                        If (GINDENTNO = "Y") Then
                            AxfpSpread1.Col = 4
                            INDQTY = Val(AxfpSpread1.Text)
                            AxfpSpread1.SetText(4, K, batchqty * convvalue)
                        End If
                    Else
                        AxfpSpread1.InsertRows(K + m, 1)
                        sql = " select I.itemcode,Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                        sql = sql & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + txt_storecode.Text + "' and isnull(I.itemcode,'')='" + Trim(itemcode) + "'"
                        gconnection.getDataSet(sql, "inv_InventoryOpenningstock")
                        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                            AxfpSpread1.SetText(1, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            AxfpSpread1.SetText(3, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            AxfpSpread2.Row = l
                            AxfpSpread1.SetText(5, K + m - 1, batchqty * convvalue)
                            AxfpSpread2.Col = 2
                            AxfpSpread1.SetText(6, K + m - 1, AxfpSpread2.Text)
                            AxfpSpread2.Col = 5
                            AxfpSpread1.SetText(7, K, AxfpSpread2.Text)
                            If (GINDENTNO = "Y") Then
                                If (batchqty * convvalue < INDQTY - totbatchqty) Then
                                    AxfpSpread1.SetText(4, K + m - 1, batchqty * convvalue)

                                Else
                                    AxfpSpread1.SetText(4, K + m - 1, INDQTY - totbatchqty)

                                End If
                            End If
                        End If

                    End If
                    m = m + 1
                    totbatchqty = totbatchqty + (batchqty * convvalue)
                    AxfpSpread1.SetActiveCell(1, K + m - 1)
                    Calculate()
                End If

            Next
        End If
        For i As Integer = 0 To AxfpSpread2.DataRowCnt
            AxfpSpread2.Col = 5
            qty += Val(AxfpSpread2.Text)

        Next
        GroupBox3.Visible = False
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False

            If gShortname = "RSAOI" Then
                '========================# IM POLICY CODE START #===========================
                Autherize = ""
                ' Authorized = ""
                MCA = ""
            End If
            '========================# IM POLICY CODE END #===========================

        End If


    End Sub


    Private Sub Cmd_Docnohelp_Click(sender As Object, e As EventArgs) Handles Cmd_Docnohelp.Click
        Try

            If gShortname = "BBSR" Then
                gSQLString = "SELECT docdetails,docdate,isnull(partybookingno,'')as partybookingno,isnull(indentno,'')as indentno FROM stockissueheader"
            Else
                gSQLString = "SELECT docdetails,docdate,isnull(indentno,'')as indentno FROM stockissueheader"
            End If

            If Trim(UCase(gShortname)) = "CGC" Then
                M_WhereCondition = " WHERE VOID ='N' "
            Else
                M_WhereCondition = " where Storelocationcode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "')  "
            End If
            M_ORDERBY = "ORDER BY Docdate DESC,AUTOID desc"
            Dim vform As New List_Operation
            If gShortname = "BBSR" Then
                vform.Field = "indentno,DOCDETAILS,DOCDATE,partybookingno"
            Else
                vform.Field = "indentno,DOCDETAILS,DOCDATE"
            End If

            vform.vFormatstring1 = "       DOC NO                       |         DOC DATE                 |       INDENT NO "
            vform.vCaption = "STOCK ISSUE NO HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Docno.Text = Trim(vform.keyfield & "")
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Call txt_Docno_Validated(txt_Docno, e)

                cmd_IndentNoHelp.Enabled = False
                Txt_IndentNo.Enabled = False
                Calculate()
                AxfpSpread1.SetActiveCell(4, 1)
            End If
            vform.Close()
            vform = Nothing

            gSQLString = "SELECT STORECODE FROM STOREMASTER WHERE BUFFET='YES' AND STORECODE='" & txt_storecode.Text & "'"
            gconnection.getDataSet(gSQLString, "BUFFET")
            If gdataset.Tables("BUFFET").Rows.Count > 0 Then
                Label11.Visible = True
                txt_buffet.Visible = True
                cmd_buffet.Visible = True
                ' cmd_buffet_Click(sender, e)
            Else
                Label11.Visible = False
                txt_buffet.Visible = False
                cmd_buffet.Visible = False
            End If

            gSQLString = "SELECT STORECODE FROM STOREMASTER WHERE Banquet='YES' AND STORECODE='" & txt_storecode.Text & "'"
            gconnection.getDataSet(gSQLString, "Banquet")
            If gdataset.Tables("Banquet").Rows.Count > 0 Then
                GroupBox4.Visible = True
                'Button1_Click(sender, e)
            Else
                GroupBox4.Visible = False
            End If


        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub txt_Docno_Validated(sender As Object, e As EventArgs) Handles txt_Docno.Validated
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, VSTRDOCNO As String
        Dim vTypeseqno, Clsquantity, vGroupseqno, TotalCount As Double
        If Trim(txt_Docno.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,H.INDENTNO INDENTNO, H.INDENTDATE AS INDENTDATE, "
                If gShortname = "RSAOI" Then
                    sqlstring = sqlstring & " isnull(authorised,'') as authorised,isnull(MCA,'') as MCA, "
                End If
                sqlstring = sqlstring & " ISNULL(H.STORELOCATIONCODE,'') AS STORELOCATIONCODE,"
                sqlstring = sqlstring & " ISNULL(H.STORELOCATIONNAME,'') AS STORELOCATIONNAME,ISNULL(H.OPSTORELOCATIONCODE,'') AS OPSTORELOCATIONCODE,"
                sqlstring = sqlstring & " ISNULL(H.OPSTORELOCATIONNAME,'') AS OPSTORELOCATIONNAME,ISNULL(H.TOTALAMT,0) AS TOTALAMT,ISNULL(H.REMARKS,'') AS REMARKS,"
                sqlstring = sqlstring & " ISNULL(H.VOID,'') AS VOID,ISNULL(H.VOIDREASON,'') AS VOIDREASON,ISNULL(H.ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(H.UPDATEUSER,'') AS UPDATEUSER,UPDATETIME,voidtime,ISNULL(H.partybookingno,'') AS partybookingno,ISNULL(H.BUFFETMENU,'') AS BUFFETMENU"
                sqlstring = sqlstring & " FROM STOCKISSUEHEADER AS H WHERE DOCNO='" & Trim(txt_Docno.Text) & "'OR DOCDETAILS='" & Trim(txt_Docno.Text) & "' "
                gconnection.getDataSet(sqlstring, "STOCKISSUEHEADER")
                '''************************************************* SELECT RECORD FROM STOCKISSUEHEADER *********************************************''''                
                If gdataset.Tables("STOCKISSUEHEADER").Rows.Count > 0 Then
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Docno.ReadOnly = True
                    VSTRDOCNO = Trim(txt_Docno.Text)
                    txt_Docno.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("DOCDETAILS") & "")
                    Txt_IndentNo.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("INDENTNO") & "")
                    If (IsDBNull(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("INDENTDATE")) = True) Then
                    Else
                        dtp_IndentDate.Value = Format(CDate(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("INDENTDATE")), "dd-MMM-yyyy")

                    End If
                    If gShortname = "RSAOI" Then
                        '========================# IM POLICY CODE START #===========================
                        Autherize = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("Authorised") & "")
                        MCA = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("MCA") & "")
                        '========================# IM POLICY CODE END #===========================
                    End If


                    dtp_Docdate.Value = Format(CDate(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("DOCDATE")), "dd-MMM-yyyy")
                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("STORELOCATIONCODE"))
                    txt_FromStorename.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("STORELOCATIONNAME"))

                    TXT_FROMSTORECODE.Enabled = False
                    txt_storecode.Enabled = False
                    txt_STOREDESC.Enabled = False
                    txt_storecode.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("OPSTORELOCATIONCODE"))
                    txt_STOREDESC.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("OPSTORELOCATIONNAME"))
                    '  Txt_qty.Text = Format(Val(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("qty")), "0.000")
                    txt_Totalamount.Text = Format(Val(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("TOTALAMT")), "0.000")
                    txt_Remarks.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("REMARKS"))
                    TXT_PARTYNO.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("partybookingno"))
                    txt_buffet.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("BUFFETMENU"))
                    If gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("VOID") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = Me.lbl_Freeze.Text & Format(CDate(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("voidtime")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Enabled = False
                        Me.Cmd_Add.Enabled = False
                        '   Me.Cmd_Freeze.Enabled = True
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.Cmd_Freeze.Enabled = True
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Void[F8]"
                        Me.Cmd_Add.Enabled = True
                        Me.Cmd_Freeze.Enabled = True
                    End If
                    If Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("VOID")) = "Y" Then
                        Cmd_Add.Enabled = False
                        Cmd_Freeze.Enabled = False
                    End If
                    '''************************************************* SELECT RECORD FROM STOCKISSUEDETAILS *********************************************''''                
                    Dim strsql As String
                    Dim STRITEMCODE, STRITEMUOM As String
                    sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,ISNULL(QTY,0) AS QTY ,"
                    If GSHELVING = "Y" Then
                        sqlstring = sqlstring & "FROMSHELF,TOSHELF,"
                    End If
                    If gShortname = "FNCC" Then
                        sqlstring = sqlstring & "Session,"
                    End If
                    sqlstring = sqlstring & " ISNULL(AMOUNT,0) AS AMOUNT,isnull(IND_QTY,0) as IND_QTY,isnull(batchno,'') as batchno,isnull(RATE,0) as RATE,ISNULL(AMOUNT,0) AS AMOUNT,isnull(void,'N') as void "
                    sqlstring = sqlstring & " FROM STOCKISSUEDETAIL WHERE  DOCDETAILS ='" & Trim(txt_Docno.Text) & "' ORDER BY AUTOID"
                    gconnection.getDataSet(sqlstring, "STOCKISSUEDETAILSALL")
                    If gdataset.Tables("STOCKISSUEDETAILSALL").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("STOCKISSUEDETAILSALL").Rows.Count
                            ' Call GridUOM(i) '''---> FILL GRID UOM
                            j = i - 1
                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("ITEMCODE")))
                            STRITEMCODE = Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("ITEMNAME")))
                            AxfpSpread1.Col = 3


                            AxfpSpread1.Row = i

                            Dim sql As String = "select tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("itemcode") + "'"

                            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z


                            AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("UOM")))
                            AxfpSpread1.Col = 4
                            AxfpSpread1.Row = i
                            AxfpSpread1.SetText(4, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("IND_QTY")))
                            AxfpSpread1.Col = 5
                            AxfpSpread1.Row = i
                            AxfpSpread1.SetText(5, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("QTY")))
                            AxfpSpread1.Col = 6
                            AxfpSpread1.Row = i
                            AxfpSpread1.SetText(6, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("batchno")))
                            AxfpSpread1.Col = 7
                            AxfpSpread1.Row = i
                            AxfpSpread1.SetText(7, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("RATE")))

                            AxfpSpread1.Col = 8
                            AxfpSpread1.Row = i
                            AxfpSpread1.SetText(8, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("AMOUNT")))

                            AxfpSpread1.Col = 9
                            AxfpSpread1.Row = i
                            AxfpSpread1.SetText(9, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("void")))
                            If GSHELVING = "Y" Then
                                AxfpSpread1.Col = 11
                                AxfpSpread1.Row = i
                                AxfpSpread1.SetText(11, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("FROMSHELF")))
                                AxfpSpread1.Col = 12
                                AxfpSpread1.Row = i
                                AxfpSpread1.SetText(12, i, Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("TOSHELF")))
                            End If
                            If gShortname = "FNCC" Then
                                sqlstring = " SELECT ISNULL(SESSIONREQ,'')AS SESSIONREQ FROM STOREMASTER WHERE STORECODE='" & txt_storecode.Text & "' AND  ISNULL(FREEZE,'N') <> 'Y' "
                                gconnection.getDataSet(sqlstring, "SESSIONRE")
                                Dim SESSIONREQ As String
                                SESSIONREQ = Trim(gdataset.Tables("SESSIONRE").Rows(0).Item("SESSIONREQ"))
                                If SESSIONREQ = "YES" Then
                                    LBL_SESSION.Visible = True
                                    CMB_SESSION.Visible = True
                                    CMB_SESSION.Text = Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("SESSION"))
                                Else
                                    LBL_SESSION.Visible = False
                                    CMB_SESSION.Visible = False
                                End If
                            End If

                            If (Trim(gdataset.Tables("STOCKISSUEDETAILSALL").Rows(j).Item("batchno")) <> "") Then

                            End If
                        Next
                    End If
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    TotalCount = gdataset.Tables("STOCKISSUEDETAILSALL").Rows.Count
                    AxfpSpread1.SetActiveCell(1, 1)
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

    End Sub
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
        Try
            Dim i, j, k, x As Integer
            Dim vmain, vsmod, vssmod As Long
            Dim ssql, SQLSTRING As String
            Dim M1 As New MainMenu
            Dim chstr As String
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
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click

        If MessageBox.Show("Do You Want void it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then
            Exit Sub
        End If

        If Mid(CStr(Cmd_Freeze.Text), 1, 1) = "V" Then
            If validateonvoid() = False Then
                voidoperation()
                ' Addoperation()
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
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ISSUE")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ISSUE")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If


                sqlstring = " exec proc_closingqtyone 'ISSUE_VOID' "
                gconnection.ExcuteStoreProcedure(sqlstring)

                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)

                clearoperation()

            End If
        End If


    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Try
            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE, addr As String
            Dim r
            If UCase(gShortname) = "CFC" Then
                r = New Rpt_IndentIssueCFC_
            ElseIf UCase(gShortname) = "KGA" Then
                r = New Rpt_IndentIssue_KGA
            ElseIf UCase(gShortname) = "HGA" Then
                r = New Rpt_IndentIssue__HGA
            ElseIf UCase(gShortname) = "FNCC" Then
                r = New Rpt_IndentIssue__FNCC
            ElseIf UCase(gShortname) = "SKYYE" Then
                r = New Rpt_IndentIssue_SKYYE
            ElseIf UCase(gShortname) = "HG" Then
                r = New Rpt_IndentIssueHG
            ElseIf UCase(gShortname) = "VFNCC" Then
                r = New Rpt_IndentIssue_VFNCC_
            Else
                r = New Rpt_IndentIssue_
            End If



            sqlstring = "SELECT TOP 100 PERCENT docdetails, docdate, storelocationname, "
            sqlstring = sqlstring & " opstorelocationname, itemcode,storelocationcode,opstorelocationcode, "
            If UCase(gShortname) = "KGA" Then
                sqlstring = sqlstring & "CLSQTY, "
            End If
            'If UCase(gShortname) = "FNCC" Then
            '    sqlstring = sqlstring & "ISNULL(SESSION,'')AS SESSION, "
            'End If
            sqlstring = sqlstring & " itemname, uom,qty, rate, amount , indentno , indentdate,remarks,partybookingno "
            If UCase(gShortname) = "VFNCC" Then
                sqlstring = sqlstring & ",gROUPDESC "
            End If
            sqlstring = sqlstring & " FROM VW_INV_ISSUEBILL "
            sqlstring = sqlstring & " WHERE docdetails = '" & Trim(txt_Docno.Text) & "' "
            sqlstring = sqlstring & " ORDER BY docdetails"

            gconnection.getDataSet(sqlstring, "VW_INV_ISSUEBILL")
            If gdataset.Tables("VW_INV_ISSUEBILL").Rows.Count > 0 Then
                If UCase(gShortname) = "CFC" Then
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "VW_INV_ISSUEBILL"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text13")
                    textobj1.Text = MyCompanyName

                    Dim textobj11 As TextObject
                    textobj11 = r.ReportDefinition.ReportObjects("Text23")
                    textobj11.Text = UCase(Address1) + "," + UCase(Address2)
                    Dim textobj26 As TextObject
                    textobj26 = r.ReportDefinition.ReportObjects("Text26")
                    textobj26.Text = UCase(gState) + "," + UCase(gPincode)

                    Dim textobj31 As TextObject
                    textobj31 = r.ReportDefinition.ReportObjects("Text31")
                    textobj31.Text = UCase(gPhone1) + "," + UCase(gPhone2)
                    Dim textobj32 As TextObject
                    textobj32 = r.ReportDefinition.ReportObjects("Text32")
                    textobj32.Text = "GSTIN NO : " & UCase(gGSTINNO)
                    Dim textobj25 As TextObject
                    textobj25 = r.ReportDefinition.ReportObjects("Text29")
                    textobj25.Text = gFinancalyearStart + " to " + gFinancialyearEnd



                    Dim Text21 As TextObject
                    Text21 = r.ReportDefinition.ReportObjects("Text21")
                    Text21.Text = gUsername
                Else

                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "VW_INV_ISSUEBILL"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text13")
                    textobj1.Text = MyCompanyName

                    If UCase(gShortname) = "SKYYE" Then
                        addr = ""
                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text23")
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
                        Dim textobj11 As TextObject
                        textobj11 = r.ReportDefinition.ReportObjects("Text23")
                        textobj11.Text = UCase(gCompanyAddress(0))
                        Dim textobj12 As TextObject
                        textobj12 = r.ReportDefinition.ReportObjects("Text26")
                        textobj12.Text = UCase(gCompanyAddress(1))



                    End If




                    Dim textobj25 As TextObject
                    textobj25 = r.ReportDefinition.ReportObjects("Text29")
                    textobj25.Text = gFinancalyearStart + " to " + gFinancialyearEnd



                    Dim Text21 As TextObject
                    Text21 = r.ReportDefinition.ReportObjects("Text21")
                    Text21.Text = gUsername
                End If
                If UCase(gShortname) = "MGC" Then
                    Dim textobj20 As TextObject
                    textobj20 = r.ReportDefinition.ReportObjects("Text20")
                    textobj20.Text = "STORE KEEPER NAME :"

                Else
                    If gShortname <> "SKYYE" Then
                        Dim textobj22, textobj26 As TextObject
                        textobj22 = r.ReportDefinition.ReportObjects("Text22")
                        ' textobj22.Text = ""


                        If UCase(gShortname) = "TMA" Then
                            textobj22.Text = "  Store Keeper:                                                                                             Manager: "

                        End If
                        If UCase(gShortname) = "KBA" Then
                            textobj26 = r.ReportDefinition.ReportObjects("Text22")
                            textobj26.Text = "Section Incharge                                                                                                                                                    Accounts"
                        End If
                    End If

                End If
                Dim SQL20 As String
                If viewprint = True Then
                    Try
                        rViewer.Show()
                        r.PrintOptions.PrinterName = "\\" & computername & "\" & Printername
                        SQL20 = "select '\\" & computername & "\" & Printername & "' as Printername"
                        gconnection.getDataSet(SQL20, "EMAILSENT")
                        r.PrintToPrinter(1, False, 0, 0)
                        r.Close()
                        r.Dispose()
                        rViewer.Refresh()
                        rViewer.Close()
                        rViewer.Dispose()
                        GC.Collect()
                        Exit Sub
                    Catch EX As Exception
                    End Try
                Else
                    rViewer.Show()
                End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If
            ''''Else

            ''''gPrint = False
            ''''Dim i As Integer
            ''''Dim objStockIssueClass As New rptStockissuereport
            ''''sqlstring = "SELECT TOP 100 PERCENT dbo.stockissueheader.docdetails, dbo.stockissueheader.docdate, dbo.stockissueheader.storelocationname, "
            ''''sqlstring = sqlstring & " dbo.stockissueheader.opstorelocationname, dbo.stockissuedetail.itemcode,dbo.stockissueheader.storelocationcode,dbo.stockissueheader.opstorelocationcode, "
            ''''sqlstring = sqlstring & " dbo.stockissuedetail.itemname, dbo.stockissuedetail.uom,dbo.stockissuedetail.qty, dbo.stockissuedetail.rate, dbo.stockissuedetail.amount , dbo.stockissueheader.indentno ,  dbo.stockissueheader.indentdate,dbo.stockissueheader.remarks,dbo.stockissueheader.UPDFOOTER,dbo.stockissueheader.UPDSIGN"
            ''''sqlstring = sqlstring & " FROM dbo.stockissuedetail INNER JOIN dbo.stockissueheader ON dbo.stockissuedetail.docdetails = dbo.stockissueheader.docdetails"
            ''''sqlstring = sqlstring & " WHERE dbo.stockissueheader.docdetails = '" & Trim(txt_Docno.Text) & "' "
            ''''sqlstring = sqlstring & " ORDER BY dbo.stockissueheader.docdetails"
            ''''Dim arraystring() As String = {"SLNO", "ITEM CODE", "ITEM NAME", "UOM", "QUANTITY", "RATE", "AMOUNT"}
            ''''Dim heading() As String = {"STOCK ISSUE"}
            ''''Dim colsize() As Integer = {5, 15, 40, 16, 10, 12, 12}
            ''''objStockIssueClass.Reportdetails(sqlstring, heading, arraystring, colsize)
            ''''End If
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
            Dim r
            If UCase(gShortname) = "HG" Then
                r = New Rpt_IndentIssueHG
            Else
                r = New Rpt_IndentIssue_
            End If

            sqlstring = "SELECT TOP 100 PERCENT docdetails, docdate, storelocationname, "
            sqlstring = sqlstring & " opstorelocationname, itemcode,storelocationcode,opstorelocationcode, "
            sqlstring = sqlstring & " itemname, uom,qty, rate, amount , indentno , indentdate,remarks "
            sqlstring = sqlstring & " FROM VW_INV_ISSUEBILL "
            sqlstring = sqlstring & " WHERE docdetails = '" & Trim(txt_Docno.Text) & "' "
            sqlstring = sqlstring & " ORDER BY docdetails"

            gconnection.getDataSet(sqlstring, "VW_INV_ISSUEBILL")
            If gdataset.Tables("VW_INV_ISSUEBILL").Rows.Count > 0 Then
                'If chk_excel.Checked = True Then
                '    Dim exp As New exportexcel
                '    exp.Show()
                '    Call exp.export(sqlstring, "STOCK ISSUE ", "")
                'Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_INV_ISSUEBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName
                Dim textobj11 As TextObject
                textobj11 = r.ReportDefinition.ReportObjects("Text23")
                textobj11.Text = UCase(gCompanyAddress(0))
                Dim textobj12 As TextObject
                textobj12 = r.ReportDefinition.ReportObjects("Text26")
                textobj12.Text = UCase(gCompanyAddress(1))
                Dim textobj25 As TextObject
                textobj25 = r.ReportDefinition.ReportObjects("Text29")
                textobj25.Text = gFinancalyearStart + " to " + gFinancialyearEnd

                viewprint = True
                Dim SQL20 As String
                If viewprint = True Then
                    Try
                        rViewer.Show()
                        r.PrintOptions.PrinterName = "\\" & computername & "\" & Printername
                        SQL20 = "select '\\" & computername & "\" & Printername & "' as Printername"
                        gconnection.getDataSet(SQL20, "EMAILSENT")
                        r.PrintToPrinter(1, False, 0, 0)
                        r.Close()
                        r.Dispose()
                        rViewer.Refresh()
                        rViewer.Close()
                        rViewer.Dispose()
                        GC.Collect()
                        Exit Sub
                    Catch EX As Exception
                    End Try
                Else
                    rViewer.Show()
                End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If
            ''''Else

            ''''gPrint = False
            ''''Dim i As Integer
            ''''Dim objStockIssueClass As New rptStockissuereport
            ''''sqlstring = "SELECT TOP 100 PERCENT dbo.stockissueheader.docdetails, dbo.stockissueheader.docdate, dbo.stockissueheader.storelocationname, "
            ''''sqlstring = sqlstring & " dbo.stockissueheader.opstorelocationname, dbo.stockissuedetail.itemcode,dbo.stockissueheader.storelocationcode,dbo.stockissueheader.opstorelocationcode, "
            ''''sqlstring = sqlstring & " dbo.stockissuedetail.itemname, dbo.stockissuedetail.uom,dbo.stockissuedetail.qty, dbo.stockissuedetail.rate, dbo.stockissuedetail.amount , dbo.stockissueheader.indentno ,  dbo.stockissueheader.indentdate,dbo.stockissueheader.remarks,dbo.stockissueheader.UPDFOOTER,dbo.stockissueheader.UPDSIGN"
            ''''sqlstring = sqlstring & " FROM dbo.stockissuedetail INNER JOIN dbo.stockissueheader ON dbo.stockissuedetail.docdetails = dbo.stockissueheader.docdetails"
            ''''sqlstring = sqlstring & " WHERE dbo.stockissueheader.docdetails = '" & Trim(txt_Docno.Text) & "' "
            ''''sqlstring = sqlstring & " ORDER BY dbo.stockissueheader.docdetails"
            ''''Dim arraystring() As String = {"SLNO", "ITEM CODE", "ITEM NAME", "UOM", "QUANTITY", "RATE", "AMOUNT"}
            ''''Dim heading() As String = {"STOCK ISSUE"}
            ''''Dim colsize() As Integer = {5, 15, 40, 16, 10, 12, 12}
            ''''objStockIssueClass.Reportdetails(sqlstring, heading, arraystring, colsize)
            ''''End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub AxfpSpread1_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread1.Advance

    End Sub

    Private Sub lbl_Freeze_Click(sender As Object, e As EventArgs) Handles lbl_Freeze.Click

    End Sub

    Private Sub Cmdauth_Click(sender As Object, e As EventArgs) Handles Cmdauth.Click
        '========================# IM POLICY CODE START #===========================
        Dim SSQLSTR, SSQLSTR2 As String
        Dim MCA, C, A, F As String
        Dim level As Integer
        Dim multi(2) As String
        multi(0) = "Update STOCKISSUEHEADER set "
        multi(1) = "Update STOCKISSUEDETAIL set "
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
                    SSQLSTR2 = " SELECT isnull(Docdetails,'') as Docdetails,isnull(docdate,'') as docdate,isnull(IndentNo,'') as IndentNo,isnull(Storelocationname,'') as Storelocationname,isnull(Opstorelocationname,'') as Opstorelocationname,ISNULL(totalamt,0) AS totalamt,ISNULL(MCA,'') AS MCA,ISNULL(Authorised,'') AS Authorised FROM STOCKISSUEHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN (" & MCA & ") " '''query to change
                    SSQLSTR2 = SSQLSTR2 & " and totalamt <= " & Val(gdataset.Tables("CHECKER").Rows(0).Item(LIMIT))
                Else
                    SSQLSTR2 = " SELECT isnull(Docdetails,'') as Docdetails,isnull(docdate,'') as docdate,isnull(IndentNo,'') as IndentNo,isnull(Storelocationname,'') as Storelocationname,isnull(Opstorelocationname,'') as Opstorelocationname,ISNULL(totalamt,0) AS totalamt,ISNULL(MCA,'') AS MCA,ISNULL(Authorised,'') AS Authorised  FROM STOCKISSUEHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN (" & MCA & ") " '''query to change
                End If
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    Dim VIEW1 As New AUTHORISATION
                    VIEW1.DTAUTH.DataSource = Nothing
                    VIEW1.DTAUTH.Rows.Clear()
                    Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZE"), False, Me, "UPDATE STOCKISSUEHEADER set  ", "Docdetails", level, 3, 0, "Y", multi) '''query to change
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
                        gconnection.getDataSet(MYSQL, "GRN")
                        If gdataset.Tables("GRN").Rows.Count > 0 Then
                            ' Call updateAuth(gdataset.Tables("GRN"), GRN)
                        End If

                        mysql = " delete from authPending where Docdetail  IN (" & GRN & ") and TTYPE IN ('ISSUE','RECEIEVE')"
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
            SSQLSTR2 = " SELECT comment,isnull(Docdetails,'') as Docdetails,isnull(docdate,'') as docdate,isnull(IndentNo,'') as IndentNo,isnull(Storelocationname,'') as Storelocationname,isnull(Opstorelocationname,'') as Opstorelocationname,ISNULL(totalamt,0) AS totalamt,ISNULL(MCA,'') AS MCA,ISNULL(Authorised,'') AS Authorised  FROM STOCKISSUEHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN ('M','C') "
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR2 = " SELECT * FROM MCARIGHTS WHERE  MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND (ISNULL(CHECKER1ID,'')='" & gUsername & "' OR ISNULL(CHECKER2ID,'')='" & gUsername & "')" '''query to change
                gconnection.getDataSet(SSQLSTR2, "CHECKER")
                If gdataset.Tables("CHECKER").Rows.Count > 0 Then
                    Dim VIEW1 As New AUTHORISATION
                    VIEW1.DTAUTH.DataSource = Nothing
                    VIEW1.DTAUTH.Rows.Clear()
                    Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZE"), False, Me, "UPDATE STOCKISSUEHEADER set  ", "Docdetails", level, 2, 1, "Y", multi) '''query to change

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
            SSQLSTR2 = " SELECT isnull(Docdetails,'') as Docdetails,isnull(docdate,'') as docdate,isnull(IndentNo,'') as IndentNo,isnull(Storelocationname,'') as Storelocationname,isnull(Opstorelocationname,'') as Opstorelocationname,ISNULL(totalamt,0) AS totalamt,ISNULL(MCA,'') AS MCA,ISNULL(Authorised,'') AS Authorised  FROM STOCKISSUEHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN ('M') and isnull(comment,'')<>'' "
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                Dim VIEW1 As New AUTHORISATION
                VIEW1.DTAUTH.DataSource = Nothing
                VIEW1.DTAUTH.Rows.Clear()
                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZE"), False, Me, "UPDATE STOCKISSUEHEADER set  ", "Docdetails", 1, 1, 0, "Y", multi) '''query to change
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

    Private Sub txt_Docno_TextChanged(sender As Object, e As EventArgs) Handles txt_Docno.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub cmd_buffet_Click(sender As Object, e As EventArgs) Handles cmd_buffet.Click
        Try

            gSQLString = "SELECT  ITEMCODE,ItemDesc,GROUPCODEDEC,BaseUOMstd FROM BUFFET_MENU  "
            Dim vform As New List_Operation
            M_ORDERBY = "order by ItemDesc desc"

            vform.Field = "ITEMCODE,ItemDesc,GROUPCODEDEC,BaseUOMstd"
            vform.vFormatstring1 = "       ITEMCODE                    |     ItemDesc                                             |     GROUPCODEDEC                  |      BaseUOMstd               "
            vform.vCaption = "BUFFET MENU HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_buffet.Text = Trim(vform.keyfield & "")
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub grp_issue1_Enter(sender As Object, e As EventArgs) Handles grp_issue1.Enter

    End Sub

    Private Sub AxfpSpread1_KeyUpEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyUpEvent) Handles AxfpSpread1.KeyUpEvent
        Dim j As Integer

        ' For j As Integer = 1 To AxfpSpread1.DataRowCnt
        If e.keyCode = Keys.Enter Then
            If AxfpSpread1.DataRowCnt > 0 Then
                j = AxfpSpread1.ActiveRow
                AxfpSpread1.Row = j
                AxfpSpread1.Col = 5


                If (Val(AxfpSpread1.Text) <> 0) Then
                    Dim issuedqty As Double = Val(AxfpSpread1.Text)
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
                            Dim sql11 As String '= "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                            ' gconnection.getDataSet(sql11, "closingtable")
                            gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")

                            Dim closingqty As Double
                            Dim precise As Double
                            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                                sql = "select isnull(convvalue,0) AS CONVVALUE,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                                Dim convvalue As Double
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                Else
                                    MessageBox.Show("Please MAKE Conversion Factor for  " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    Exit Sub


                                End If
                                closingqty = Format(closingqty * convvalue, "0.000")
                            Else
                                closingqty = 0
                            End If


                            If (issuedqty > closingqty) Then
                                MessageBox.Show("You have " + closingqty.ToString() + " balance items")
                                AxfpSpread1.Row = j
                                AxfpSpread1.Col = 5
                                AxfpSpread1.SetText(5, j, Val(closingqty))

                                Exit Sub


                            End If
                        End If

                    End If
                    If GINDENTNO = "Y" Then
                        AxfpSpread1.Col = 4
                        Dim indentqty As Double = Val(AxfpSpread1.Text)
                        If (issuedqty > indentqty) Then
                            MessageBox.Show("Issued Quantity Cannot be Greater than Indent Quantity")
                            AxfpSpread1.Row = j
                            AxfpSpread1.Col = 5
                            AxfpSpread1.SetText(5, j, Val(indentqty))
                            Exit Sub

                        End If

                    End If
                End If
            End If
        End If




        '    Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            gSQLString = "SELECT BOOKINGNO,PARTYDATE,GUESTNAME FROM BANQUET_BOOKINGNO  "
            M_WhereCondition = " WHERE ISNULL(FREEZE,'N')<>'Y'  AND cast( PARTYDATE as Date)= Cast('" & Format(CDate(dtp_Docdate.Value), "dd MMM yyyy") & "' as Date) "
            Dim vform As New List_Operation
            M_ORDERBY = "order by BOOKINGNO desc"

            vform.Field = "BOOKINGNO,PARTYDATE,GUESTNAME"
            vform.vFormatstring1 = "       BOOKINGNO                    |     PARTYDATE                                             |     GUESTNAME              "
            vform.vCaption = "PARTY BOOKING HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXT_PARTYNO.Text = Trim(vform.keyfield & "")
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
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
                        Me.AxfpSpread1.Col = 5
                        Me.AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        Me.AxfpSpread1.Text = Format(ABC, "0.000")
                        Dim issuedqty As Double = Val(Me.AxfpSpread1.Text)
                        AxfpSpread1.Col = 7
                        Dim RATE As Double = Val(AxfpSpread1.Text)

                        AxfpSpread1.Col = 8
                        AxfpSpread1.Text = issuedqty * RATE

                        Me.AxfpSpread1.Lock = True
                        Me.AxfpSpread1.Col = 1
                        Me.AxfpSpread1.Row = AxfpSpread1.ActiveRow + 1
                        AxfpSpread1.Focus()
                        AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow + 1)
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
    Private Sub Get_Qty_InputSetUp()

        Dim SQLSTRING As String

        SQLSTRING = " IF not  EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'weighingmachineovveridehistory') Begin CREATE TABLE [dbo].[weighingmachineovveridehistory](	[allowed] [int] NULL,	[adduser] [varchar](20) NULL,	[adddatetime] [datetime] NULL)   End "
        gconnection.ExcuteStoreProcedure(SQLSTRING)

        SQLSTRING = " IF not  EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'weighingmachineovveride') Begin CREATE TABLE [dbo].[weighingmachineovveride](	[allowed] [int] NULL)   End "
        gconnection.ExcuteStoreProcedure(SQLSTRING)

        SQLSTRING = "select isnull(allowed,0)as allowed from weighingmachineovveride"
        gconnection.getDataSet(SQLSTRING, "weigh")
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
        'Call lock_Qty()
    End Sub
    Private Sub AxfpSpread1_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread1.LeaveCell
        If AxfpSpread1.Col = 5 Then
            Call Calculate()
        End If
    End Sub

    Private Sub AxfpSpread1_EditChange(sender As Object, e As AxFPSpreadADO._DSpreadEvents_EditChangeEvent) Handles AxfpSpread1.EditChange

    End Sub
End Class