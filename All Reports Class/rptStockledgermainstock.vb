Imports System.data.sqlclient
Imports System.io
Public Class rptStockledgermainstock
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Public Function ReportsDetails(ByVal SQLSTRING As String, ByVal pageheading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal STORENAME As String)
        Dim Groupdesc, Itemcode, grndetails, issuedetails, grndate, sqlstring1 As String
        Dim IssueValue, balQty, Opbal, rcvQty, issQty, totreceipt, totissue, opqty, oprate, opvalue, issrate, CLSVAL, opqty1, opvalue1, adjqty As Decimal
        Dim I, J As Integer
        Dim Itembool, calbool As Boolean
        Dim vref As Boolean = False
        Dim STORECODE, storestatus As String
        Dim SQLSTRING11 As String

        Dim Tot_Value, Tot_Cls, Tot_Iss, Tot_Rec As Double
        Tot_Value = 0 : Tot_Cls = 0 : Tot_Iss = 0 : Tot_Rec = 0
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1 : opqty = 0
            Filewrite.Write(Chr(15))
            SQLSTRING11 = "SELECT STORECODE,storestatus FROM STOREMASTER WHERE STOREDESC='" & Trim(STORENAME) & "'"
            gconnection.getDataSet(SQLSTRING11, "MAINSTORE")
            If gdataset.Tables("MAINSTORE").Rows.Count > 0 Then
                STORECODE = Trim(gdataset.Tables("MAINSTORE").Rows(0).Item("STORECODE"))
                storestatus = Trim(gdataset.Tables("MAINSTORE").Rows(0).Item("STORESTATUS"))
            Else
                STORECODE = ""
            End If
            Call PrintHeader(pageheading, mskfromdate, msktodate)
            gconnection.getDataSet(SQLSTRING, "VIEWSTOCKLEDGERREPORT")

            'If STORECODE = "MNS" Then
            If storestatus = "M" Then
                For J = 0 To gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows.Count - 1
                    'If Groupdesc <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPDESC"))) Then
                    If Groupdesc <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname"))) Then
                        ''Filewrite.WriteLine("{0,-30}", Mid("[" & Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname"))) & "]", 1, 30))
                        ''pagesize = pagesize + 1
                        ''Filewrite.WriteLine(StrDup(Len(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname")) + 2, "-"))
                        ''pagesize = pagesize + 1
                        Groupdesc = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("Groupname")))
                        vref = True
                    End If

                    If Itemcode <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE"))) Then
                        '-------------------------------------------------------------------------------------------
                        opqty = 0 : balQty = 0 : calbool = False : rcvQty = 0 : issQty = 0 : totreceipt = 0 : totissue = 0 : oprate = 0 : opvalue = 0
                        Itemcode = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")))
                        Filewrite.Write("{0,-18}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")), 1, 18))
                        Filewrite.Write("{0,-40}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMNAME")), 1, 40))
                        Filewrite.Write("{0,-10}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("STOCKUOM")), 1, 10))
                        Filewrite.WriteLine("{0,-7}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("VALUATION")), 1, 7))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine(StrDup(75, "-"))
                        pagesize = pagesize + 1
                        pagesize = pagesize + 1
                        '********************* Calculation of Opening Stock *****************************************************
                        sqlstring1 = "SELECT ISNULL(INVITMTRANSQTY,0) AS OPSTOCK,ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(INVITMTRANSVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(Itemcode) & "' AND STORECODE='" & STORECODE & "'"
                        gconnection.getDataSet(sqlstring1, "INVENTORYITEMMASTER")
                        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                            opqty = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                            oprate = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("PURCHASERATE")), "0.000")
                            opvalue1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPVALUE")), "0.00")
                            opqty1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                        End If
                        'SIVA--------------------------------- CALCULATION OF OPENING STOCK --------------------------------------------
                        sqlstring1 = "SELECT ISNULL(SUM(GRNTRANSQTY),0) AS TOTAL_GRN, ISNULL(SUM(GRNTRANSVALUE),0) AS GRN_VALUE FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOIDITEM,'') <> 'Y' AND GRNDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                        gconnection.getDataSet(sqlstring1, "INVENTORY_OPENING_GRN_QUANTITY")
                        If gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows.Count > 0 Then
                            opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows(0).Item("TOTAL_GRN")), "0.000")
                            opvalue1 = opvalue1 + Format(Val(gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows(0).Item("GRN_VALUE")), "0.00")
                            opqty1 = opqty1 + Format(Val(gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows(0).Item("TOTAL_GRN")), "0.000")
                        End If

                        sqlstring1 = "SELECT ISNULL(SUM(ISSTRANSQTY),0) AS TOTAL_ISSUE, ISNULL(SUM(ISSTRANSVALUE),0) AS ISS_VALUE FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                        gconnection.getDataSet(sqlstring1, "INVENTORY_ISSUE_QUANTITY")
                        If gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows.Count > 0 Then
                            opqty = opqty - Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("TOTAL_ISSUE")), "0.000")
                            'opvalue = opvalue - Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("ISS_VALUE")), "0.000")
                        End If

                        'sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_RETURN, ISNULL(SUM(AMOUNT),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND TOSTORECODE LIKE 'M%' "
                        sqlstring1 = "SELECT ISNULL(SUM(TRFTRANSQTY),0) AS TOTAL_RETURN, ISNULL(SUM(TRFTRANSVALUE),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND TOSTORECODE LIKE '" & STORECODE & "'"
                        gconnection.getDataSet(sqlstring1, "INVENTORY_RETURN_QUANTITY")
                        If gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows.Count > 0 Then
                            opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("TOTAL_RETURN")), "0.000")
                            'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("RET_VAL")), "0.000")
                        End If

                        sqlstring1 = "SELECT ISNULL(SUM(ADJTRANSQTY),0) AS TOTAL_ADJUST, ISNULL(SUM(ADJTRANSVALUE),0) ADJUSTED_VALUE FROM STOCKADJUSTDETAILS WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND STORELOCATIONCODE LIKE 'M%' "
                        gconnection.getDataSet(sqlstring1, "INVENTORY_ADJUSTED_QUANTITY")
                        If gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows.Count > 0 Then
                            opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("TOTAL_ADJUST")), "0.000")
                            'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("ADJUSTED_VALUE")), "0.000")
                        End If

                        sqlstring1 = "select ISNULL(OPRATE,0) AS OPRATE from stocksummary where itemcode='" & Trim(Itemcode) & "'"
                        gconnection.getDataSet(sqlstring1, "Rate1")
                        If gdataset.Tables("rate1").Rows.Count > 0 Then
                            oprate = Val(gdataset.Tables("rate1").Rows(0).Item("oprate"))
                        Else
                            sqlstring1 = "select count(*) as count from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                            gconnection.getDataSet(sqlstring1, "Rate")
                            If Val(gdataset.Tables("rate").Rows(0).Item("count")) > 0 Then
                                sqlstring1 = "select TOP 1 isnull(rate,0) rate from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and isnull(void,'') <> 'y' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' order by docdate desc"
                                gconnection.getDataSet(sqlstring1, "CurrentRate")
                                oprate = Val(gdataset.Tables("currentrate").Rows(0).Item("rate"))
                            Else
                                If opqty1 > 0 Then
                                    oprate = opvalue1 / opqty1
                                Else
                                    sqlstring1 = "select top 1 isnull(purchaserate,0) rate from inventoryitemmaster where itemcode='" & Trim(Itemcode) & "' AND STORECODE LIKE '" & STORECODE & "'"
                                    gconnection.getDataSet(sqlstring1, "OpeningRate")
                                    If gdataset.Tables("OpeningRate").Rows.Count > 0 Then
                                        oprate = Val(gdataset.Tables("OpeningRate").Rows(0).Item("rate"))
                                    Else
                                        oprate = 0
                                    End If
                                End If
                            End If
                        End If
                        opvalue = oprate * opqty
                        Filewrite.WriteLine("{0,-18}{1,-40}{2,-17}{3,10}{4,11}{5,26}{6,13}", Format(mskfromdate, "dd/MM/yyyy"), "********* OPENING BALANCE ***********", "", Mid(Format(Val(oprate), "0.00"), 1, 10), Mid(Format(Val(opvalue), "0.00"), 1, 11), "", Mid(Format(Val(opqty), "0.000"), 1, 13))
                        '********************************************************************************************************
                        Filewrite.WriteLine("")
                        pagesize = pagesize + 1
                        '-------------------------------------------------------------------------------------------
                        'sqlstring1 = "SELECT * FROM  VIEWSTOCKLEDGERMAINSTORE WHERE ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"

                        sqlstring1 = "SELECT INDENTNO ,GRNDATE,GRNDETAILS AS GRNDETAILS,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,SUPPLIERCODE,SUPPLIERNAME,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC , OPSTORELOCATIONNAME FROM VIEWSTOCKLEDGERMAINSTORE "
                        sqlstring1 = sqlstring1 & " WHERE ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"
                        sqlstring1 = sqlstring1 & " AND GRNDATE BETWEEN "
                        sqlstring1 = sqlstring1 & " '" & Format(mskfromdate, "dd-MMM-yyyy") & "' AND ' " & Format(msktodate, "dd-MMM-yyyy") & "' ORDER BY ITEMCODE,GRNDATE,GRNDETAILS"
                        gconnection.getDataSet(sqlstring1, "VIEWSTOCKLEDGERMAINSTORE1")
                        If gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows.Count > 0 Then
                            For I = 0 To gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows.Count - 1
                                If Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 1, 1) = "A" Or Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 1, 1) = "C" Or Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 1, 1) = "D" Then
                                    rcvQty = 0 : issQty = 0
                                    Filewrite.Write("{0,-12}", Mid(Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MM/yyyy"), 1, 12))
                                    Filewrite.Write("{0,-6}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS1")), 1, 3))
                                    Filewrite.Write("{0,-20}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS1")), 1, 20))
                                    Filewrite.Write("{0,-37}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("SUPPLIERNAME")), 1, 37))
                                    Filewrite.Write("{0,10}", Mid(Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")), "0.00"), 1, 10))
                                    Filewrite.Write("{0,11}", "")
                                    Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000"), 1, 13))
                                    pagesize = pagesize + 1
                                    rcvQty = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")
                                    totreceipt = totreceipt + Val(rcvQty)
                                    If calbool = False Then
                                        balQty = opqty + rcvQty - issQty
                                        calbool = True
                                    Else
                                        balQty = balQty + rcvQty - issQty
                                    End If
                                    Filewrite.Write("{0,13}", "")
                                    Filewrite.WriteLine("{0,13}", Mid(Format(Val(balQty), "0.000"), 1, 13))
                                    pagesize = pagesize + 1
                                    grndate = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("Grndate")), "dd/MM/yyyy")
                                Else
                                    If Mid(CStr(gdataset.Tables("viewstockledgermainstore1").Rows(I).Item("grndetails1")), 1, 3) <> "adj" Then
                                        rcvQty = 0 : issQty = 0 : adjqty = 0
                                        Filewrite.Write("{0,-12}", Mid(Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MM/yyyy"), 1, 10))
                                        Filewrite.Write("{0,-6}", "ISS")
                                        Filewrite.Write("{0,-20}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS1")), 1, 20))
                                        Filewrite.Write("{0,-15}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("INDENTNO")), 1, 15))
                                        Filewrite.Write("{0,-22}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("OPSTORELOCATIONNAME")), 1, 22))
                                        Filewrite.Write("{0,10}", Mid(Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")), "0.00"), 1, 10))
                                        issrate = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE"))
                                        IssueValue = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY"))
                                        Filewrite.Write("{0,11}", Mid(Format(Val(IssueValue), "0.00"), 1, 11))
                                        Filewrite.Write("{0,13}", "")
                                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000"), 1, 13))
                                        issQty = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")
                                        totissue = totissue + issQty
                                        If calbool = False Then
                                            balQty = opqty + rcvQty - issQty + adjqty
                                            calbool = True
                                        Else
                                            balQty = balQty + rcvQty - issQty + adjqty
                                        End If
                                        Filewrite.WriteLine("{0,13}", Mid(Format(Val(balQty), "0.000"), 1, 13))
                                        pagesize = pagesize + 1
                                        grndate = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MM/yyyy")
                                    Else
                                        rcvQty = 0 : issQty = 0 : adjqty = 0
                                        Filewrite.Write("{0,-12}", Mid(Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MM/yyyy"), 1, 10))
                                        Filewrite.Write("{0,-6}", "ADJ")
                                        Filewrite.Write("{0,-20}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 4, 20))
                                        Filewrite.Write("{0,-37}", "")
                                        Filewrite.Write("{0,10}", "")
                                        'issrate = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE"))
                                        'IssueValue = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY"))
                                        Filewrite.Write("{0,11}", "")
                                        Filewrite.Write("{0,13}", "")
                                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000"), 1, 13))
                                        adjqty = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")
                                        'totissue = totissue + issQty
                                        If calbool = False Then
                                            balQty = opqty + rcvQty - issQty + adjqty
                                            calbool = True
                                        Else
                                            balQty = balQty + rcvQty - issQty + adjqty
                                        End If
                                        Filewrite.WriteLine("{0,13}", Mid(Format(Val(balQty), "0.000"), 1, 13))
                                        pagesize = pagesize + 1
                                        grndate = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MM/yyyy")
                                    End If
                                End If
                                If pagesize > 56 Then
                                    Filewrite.Write(StrDup(137, "-"))
                                    Filewrite.Write(Chr(12))
                                    pageno = pageno + 1
                                    Call PrintHeader(pageheading, mskfromdate, msktodate)
                                End If
                            Next I
                            IssueValue = Val(issrate) * Val(balQty)
                            Filewrite.WriteLine("")
                            pagesize = pagesize + 1

                        End If
                        '-------------------------------------------------------------------------------------------
                        If calbool = False Then
                            balQty = opqty
                            IssueValue = opvalue
                            issrate = oprate
                        End If

                        Filewrite.WriteLine("{0,-18}{1,-40}{2,-17}{3,10}{4,11}{5,13}{6,13}{7,13}", Format(CDate(msktodate), "dd/MM/yyyy"), "********* CLOSING BALANCE ***********", "", Mid(Format(Val(issrate), "0.00"), 1, 10), Mid(Format(Val(IssueValue), "0.00"), 1, 11), "", Mid(Format(Val(balQty), "0.000"), 1, 13), Mid(Format(Val(balQty) * Val(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("CONVVALUE")), "0"), 1, 13))


                        pagesize = pagesize + 1

                        Filewrite.WriteLine("{0,-75}{1,-60}", "", StrDup(60, "-"))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-58}{1,17}{2,21}{4,13}", "", "RECEIPT :", "", "", Format(Val(totreceipt), "0.000"))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-58}{1,17}{2,21}{3,13}{4,13}", "", "ISSUES  :", "", "", Format(Val(totissue), "0.000"))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-75}{1,-60}", "", StrDup(60, "-"))
                        pagesize = pagesize + 1

                        Tot_Cls = Tot_Cls + Val(balQty)
                        Tot_Value = Tot_Value + Val(IssueValue)
                        Tot_Rec = Tot_Rec + Val(totreceipt)
                        Tot_Iss = Tot_Iss + Val(totissue)

                        '--------------------------------------------------------------------------------------------
                    End If
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(137, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(pageheading, mskfromdate, msktodate)
                    End If
                Next
            Else
                For J = 0 To gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows.Count - 1
                    'If Groupdesc <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPDESC"))) Then
                    If Groupdesc <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname"))) Then
                        'Filewrite.WriteLine("{0,-30}", Mid("[" & Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPDESC"))) & "]", 1, 30))
                        Filewrite.WriteLine("{0,-30}", Mid("[" & Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname"))) & "]", 1, 30))
                        pagesize = pagesize + 1
                        'Filewrite.WriteLine(StrDup(Len(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPDESC")) + 2, "-"))
                        Filewrite.WriteLine(StrDup(Len(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname")) + 2, "-"))
                        pagesize = pagesize + 1
                        'Groupdesc = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("Groupdesc")))
                        Groupdesc = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("Groupname")))
                        vref = True
                    End If
                    If Itemcode <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE"))) Then
                        '-------------------------------------------------------------------------------------------
                        opqty = 0 : balQty = 0 : calbool = False : rcvQty = 0 : issQty = 0 : totreceipt = 0 : totissue = 0 : oprate = 0 : opvalue = 0
                        Itemcode = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")))
                        Filewrite.Write("{0,-18}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")), 1, 18))
                        Filewrite.Write("{0,-40}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMNAME")), 1, 40))
                        Filewrite.Write("{0,-10}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("STOCKUOM")), 1, 10))
                        Filewrite.WriteLine("{0,-7}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("VALUATION")), 1, 7))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine(StrDup(75, "-"))
                        pagesize = pagesize + 1
                        pagesize = pagesize + 1
                        '********************* Calculation of Opening Stock *****************************************************
                        sqlstring1 = "SELECT ISNULL(OPSTOCK,0) AS OPSTOCK,ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(OPVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(Itemcode) & "' AND STORECODE='" & Trim(STORECODE) & "'"
                        gconnection.getDataSet(sqlstring1, "INVENTORYITEMMASTER")
                        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                            opqty = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                            oprate = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("PURCHASERATE")), "0.000")
                            opvalue1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPVALUE")), "0.00")
                            opqty1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                        End If
                        'SIVA--------------------------------- CALCULATION OF OPENING STOCK --------------------------------------------

                        sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_ISSUE, ISNULL(SUM(AMOUNT),0) AS ISS_VALUE FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND OPSTORELOCATIONCODE='" & Trim(STORECODE) & "'"
                        gconnection.getDataSet(sqlstring1, "INVENTORY_ISSUE_QUANTITY")
                        If gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows.Count > 0 Then
                            opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("TOTAL_ISSUE")), "0.000")
                            'opvalue = opvalue - Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("ISS_VALUE")), "0.000")
                        End If
                        sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_RETURN, ISNULL(SUM(AMOUNT),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND FROMSTORECODE='" & Trim(STORECODE) & "'"
                        gconnection.getDataSet(sqlstring1, "INVENTORY_RETURN_QUANTITY")
                        If gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows.Count > 0 Then
                            opqty = opqty - Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("TOTAL_RETURN")), "0.000")
                            'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("RET_VAL")), "0.000")
                        End If
                        sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_RETURN, ISNULL(SUM(AMOUNT),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND TOSTORECODE='" & Trim(STORECODE) & "'"
                        gconnection.getDataSet(sqlstring1, "INVENTORY_RETURN_QUANTITY1")
                        If gdataset.Tables("INVENTORY_RETURN_QUANTITY1").Rows.Count > 0 Then
                            opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY1").Rows(0).Item("TOTAL_RETURN")), "0.000")
                            'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("RET_VAL")), "0.000")
                        End If

                        sqlstring1 = "SELECT ISNULL(SUM(ADJUSTEDSTOCK),0) AS TOTAL_ADJUST, ISNULL(SUM(AMOUNT),0) ADJUSTED_VALUE FROM STOCKADJUSTDETAILS WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND STORELOCATIONCODE='" & Trim(STORECODE) & "'"
                        gconnection.getDataSet(sqlstring1, "INVENTORY_ADJUSTED_QUANTITY")
                        If gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows.Count > 0 Then
                            opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("TOTAL_ADJUST")), "0.000")
                            'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("ADJUSTED_VALUE")), "0.000")
                        End If

                        sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_SUB, ISNULL(SUM(AMOUNT),0) SUB_VALUE FROM SUBSTORECONSUMPTIONDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND STORELOCATIONCODE='" & Trim(STORECODE) & "'"
                        gconnection.getDataSet(sqlstring1, "SUBSTORE")
                        If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                            opqty = opqty - Format(Val(gdataset.Tables("SUBSTORE").Rows(0).Item("TOTAL_SUB")), "0.000")
                            'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("ADJUSTED_VALUE")), "0.000")
                        End If

                        sqlstring1 = "select ISNULL(OPRATE,0) AS OPRATE from stocksummary where itemcode='" & Trim(Itemcode) & "'"
                        gconnection.getDataSet(sqlstring1, "Rate1")
                        If gdataset.Tables("rate1").Rows.Count > 0 Then
                            oprate = Val(gdataset.Tables("rate1").Rows(0).Item("oprate"))
                        Else
                            sqlstring1 = "select count(*) as count from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                            gconnection.getDataSet(sqlstring1, "Rate")
                            If Val(gdataset.Tables("rate").Rows(0).Item("count")) > 0 Then
                                sqlstring1 = "select TOP 1 isnull(rate,0) rate from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and isnull(void,'') <> 'y' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' order by docdate desc"
                                gconnection.getDataSet(sqlstring1, "CurrentRate")
                                oprate = Val(gdataset.Tables("currentrate").Rows(0).Item("rate"))
                            Else
                                If opqty1 > 0 Then
                                    oprate = opvalue1 / opqty1
                                Else
                                    sqlstring1 = "select TOP 1 isnull(purchaserate,0) rate from inventoryitemmaster where itemcode='" & Trim(Itemcode) & "' AND STORECODE LIKE '" & STORECODE & "'"
                                    gconnection.getDataSet(sqlstring1, "OpeningRate")
                                    If gdataset.Tables("OpeningRate").Rows.Count > 0 Then
                                        oprate = Val(gdataset.Tables("OpeningRate").Rows(0).Item("rate"))
                                    Else
                                        oprate = 0
                                    End If
                                End If
                            End If
                        End If
                        opvalue = oprate * opqty
                        Filewrite.WriteLine("{0,-18}{1,-40}{2,-17}{3,10}{4,11}{5,26}{6,13}", Format(mskfromdate, "dd/MM/yyyy"), "********* OPENING BALANCE ***********", "", Mid(Format(Val(oprate), "0.00"), 1, 10), Mid(Format(Val(opvalue), "0.00"), 1, 11), "", Mid(Format(Val(opqty), "0.000"), 1, 13))
                        '********************************************************************************************************
                        Filewrite.WriteLine("")
                        pagesize = pagesize + 1
                        '-------------------------------------------------------------------------------------------
                        'sqlstring1 = "SELECT * FROM  VIEWSTOCKLEDGERMAINSTORE WHERE ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"
                        'sqlstring1 = "SELECT GRNDATE,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC FROM VIEWSTOCKLEDGERSUBSTORE "
                        sqlstring1 = "SELECT GRNDATE,GRNDETAILS AS GRNDETAILS,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC FROM VIEWSTOCKLEDGERSUBSTORE "
                        sqlstring1 = sqlstring1 & " WHERE STORECODE='" & STORECODE & "' AND ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"
                        sqlstring1 = sqlstring1 & " AND GRNDATE BETWEEN "
                        sqlstring1 = sqlstring1 & " '" & Format(mskfromdate, "dd-MMM-yyyy") & "' AND '" & Format(msktodate, "dd-MMM-yyyy") & "' ORDER BY ITEMCODE,GRNDATE,GRNDETAILS"
                        gconnection.getDataSet(sqlstring1, "SUBSTOREVIEW")
                        If gdataset.Tables("SUBSTOREVIEW").Rows.Count > 0 Then
                            For I = 0 To gdataset.Tables("SUBSTOREVIEW").Rows.Count - 1
                                If Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS")), 1, 1) = "B" Or Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS")), 1, 1) = "A" Or Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS")), 1, 1) = "D" Then
                                    rcvQty = 0 : issQty = 0 : adjqty = 0
                                    Filewrite.Write("{0,-12}", Mid(Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MM/yyyy"), 1, 12))
                                    'Filewrite.Write("{0,-6}", Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS1")), 1, 3))
                                    Filewrite.Write("{0,-6}", "RCV")
                                    Filewrite.Write("{0,-20}", Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS1")), 1, 20))
                                    'Filewrite.Write("{0,-37}", Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("SUPPLIERNAME")), 1, 37))
                                    Filewrite.Write("{0,-37}", "")
                                    Filewrite.Write("{0,10}", Mid(Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")), "0.00"), 1, 10))
                                    issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                    IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))
                                    Filewrite.Write("{0,11}", Mid(Format(Val(IssueValue), "0.00"), 1, 11))
                                    'Filewrite.Write("{0,11}", "")
                                    Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000"), 1, 13))
                                    pagesize = pagesize + 1
                                    rcvQty = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000")
                                    totreceipt = totreceipt + Val(rcvQty)
                                    If calbool = False Then
                                        balQty = opqty + rcvQty - issQty + adjqty
                                        calbool = True
                                    Else
                                        balQty = balQty + rcvQty - issQty + adjqty
                                    End If
                                    Filewrite.Write("{0,13}", "")
                                    Filewrite.WriteLine("{0,13}", Mid(Format(Val(balQty), "0.000"), 1, 13))
                                    pagesize = pagesize + 1
                                    grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("Grndate")), "dd/MM/yyyy")
                                Else
                                    If Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("grndetails1")), 1, 3) <> "adj" Then
                                        rcvQty = 0 : issQty = 0 : adjqty = 0
                                        Filewrite.Write("{0,-12}", Mid(Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MM/yyyy"), 1, 10))
                                        Filewrite.Write("{0,-6}", "ISS")
                                        Filewrite.Write("{0,-20}", Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS1")), 1, 20))
                                        Filewrite.Write("{0,-37}", "")
                                        Filewrite.Write("{0,10}", Mid(Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")), "0.00"), 1, 10))
                                        issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                        IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))
                                        Filewrite.Write("{0,11}", Mid(Format(Val(IssueValue), "0.00"), 1, 11))
                                        Filewrite.Write("{0,13}", "")
                                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000"), 1, 13))
                                        issQty = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000")
                                        totissue = totissue + Val(issQty)
                                        If calbool = False Then
                                            balQty = opqty + rcvQty - issQty + adjqty
                                            calbool = True
                                        Else
                                            balQty = balQty + rcvQty - issQty + adjqty
                                        End If
                                        Filewrite.WriteLine("{0,13}", Mid(Format(Val(balQty), "0.000"), 1, 13))
                                        pagesize = pagesize + 1
                                        grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MM/yyyy")
                                    Else
                                        rcvQty = 0 : issQty = 0 : adjqty = 0
                                        Filewrite.Write("{0,-12}", Mid(Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MM/yyyy"), 1, 10))
                                        Filewrite.Write("{0,-6}", "ADJ")
                                        Filewrite.Write("{0,-20}", Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS1")), 4, 20))
                                        Filewrite.Write("{0,-37}", "")
                                        Filewrite.Write("{0,10}", "")
                                        'issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                        'IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))
                                        Filewrite.Write("{0,11}", "")
                                        Filewrite.Write("{0,13}", "")
                                        Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000"), 1, 13))
                                        adjqty = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000")
                                        totissue = totissue + issQty - adjqty
                                        If calbool = False Then
                                            balQty = opqty + rcvQty - issQty + adjqty
                                            calbool = True
                                        Else
                                            balQty = balQty + rcvQty - issQty + adjqty
                                        End If
                                        Filewrite.WriteLine("{0,13}", Mid(Format(Val(balQty), "0.000"), 1, 13))
                                        pagesize = pagesize + 1
                                        grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MM/yyyy")

                                    End If
                                End If
                                If pagesize > 56 Then
                                    Filewrite.Write(StrDup(137, "-"))
                                    Filewrite.Write(Chr(12))
                                    pageno = pageno + 1
                                    Call PrintHeader(pageheading, mskfromdate, msktodate)
                                End If
                            Next I
                            IssueValue = Val(issrate) * Val(balQty)
                            gconnection.getDataSet("SELECT ISNULL(SUM(QTY),0) AS QTY FROM SUBSTORECONSUMPTIONDETAIL WHERE STORELOCATIONCODE='" & STORECODE & "' AND ITEMCODE='" & Itemcode & "' AND ISNULL(VOID,'') <> 'Y'  AND DOCDATE BETWEEN '" & Format(mskfromdate, "dd MMM yyyy") & "' AND '" & Format(msktodate, "dd MMM yyyy") & "'", "SALES")
                            If gdataset.Tables("SALES").Rows.Count > 0 Then
                                rcvQty = 0 : issQty = 0 : adjqty = 0
                                Filewrite.Write("{0,-12}", "")
                                Filewrite.Write("{0,-6}", "SALES")
                                Filewrite.Write("{0,-20}", "")
                                Filewrite.Write("{0,-37}", "")
                                Filewrite.Write("{0,10}", "")
                                'issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                'IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))
                                Filewrite.Write("{0,11}", "")
                                Filewrite.Write("{0,13}", "")
                                Filewrite.Write("{0,13}", Mid(Format(Val(gdataset.Tables("SALES").Rows(0).Item("QTY")), "0.000"), 1, 13))
                                issQty = Format(Val(gdataset.Tables("SALES").Rows(0).Item("QTY")), "0.000")
                                totissue = totissue + issQty
                                If calbool = False Then
                                    balQty = opqty + rcvQty - issQty + adjqty
                                    calbool = True
                                Else
                                    balQty = balQty + rcvQty - issQty + adjqty
                                End If
                                Filewrite.WriteLine("{0,13}", Mid(Format(Val(balQty), "0.000"), 1, 13))
                                pagesize = pagesize + 1
                                'grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MM/yyyy")
                            End If
                            Filewrite.WriteLine("")
                            pagesize = pagesize + 1
                            '-------------------------------------------------------------------------------------------

                            '--------------------------------------------------------------------------------------------
                        End If
                        If calbool = False Then
                            balQty = opqty
                            IssueValue = opvalue
                            issrate = oprate
                        End If
                        Filewrite.WriteLine("{0,-18}{1,-40}{2,-17}{3,10}{4,11}{5,13}{6,13}{7,13}", Format(CDate(msktodate), "dd/MM/yyyy"), "********* CLOSING BALANCE ***********", "", Mid(Format(Val(issrate), "0.00"), 1, 10), Mid(Format(Val(IssueValue), "0.00"), 1, 11), "", Mid(Format(Val(balQty), "0.000"), 1, 13), Mid(Format(Val(balQty) * Val(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("CONVVALUE")), "0"), 1, 13))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-75}{1,-60}", "", StrDup(60, "-"))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-58}{1,17}{2,21}{4,13}", "", "RECEIPT :", "", "", Format(Val(totreceipt), "0.000"))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-58}{1,17}{2,21}{3,13}{4,13}", "", "ISSUES  :", "", "", Format(Val(totissue), "0.000"))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-75}{1,-60}", "", StrDup(60, "-"))
                        pagesize = pagesize + 1

                        Tot_Cls = Tot_Cls + Val(balQty)
                        Tot_Value = Tot_Value + Val(IssueValue)
                        Tot_Rec = Tot_Rec + Val(totreceipt)
                        Tot_Iss = Tot_Iss + Val(totissue)
                    End If
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(137, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(pageheading, mskfromdate, msktodate)
                    End If

                Next
            End If
            Filewrite.WriteLine(StrDup(137, "-"))
            'Filewrite.WriteLine("{0,-18}{1,-40}{2,-17}{3,10}{4,11}{5,13}{6,13}{7,13}", "", "********* GRAND TOTAL ***********", "", "", Mid(Format(Val(Tot_Value), "0.00"), 1, 11), Mid(Format(Val(Tot_Rec), "0.00"), 1, 11), Mid(Format(Val(Tot_Iss), "0.00"), 1, 11), Mid(Format(Val(Tot_Cls), "0.000"), 1, 13))

            gconnection.getDataSet("SELECT ISNULL(SUM(ISNULL(CLSVAL,0)),0) AS CLSVAL,ISNULL(SUM(ISNULL(RCVQTY,0)),0) AS RCVQTY,ISNULL(SUM(ISNULL(ISSQTY,0)),0) AS ISSQTY,ISNULL(SUM(ISNULL(CLSQTY,0)),0) AS CLSQTY FROM STOCKSUMMARY ", "SALES")
            Filewrite.WriteLine("{0,-18}{1,-40}{2,-17}{3,10}{4,11}{5,13}{6,13}{7,13}", "", "********* GRAND TOTAL ***********", "", "", Mid(Format(Val(gdataset.Tables("SALES").Rows(0).Item("CLSVAL")), "0.00"), 1, 11), Mid(Format(Val(gdataset.Tables("SALES").Rows(0).Item("RCVQTY")), "0.000"), 1, 11), Mid(Format(Val(gdataset.Tables("SALES").Rows(0).Item("ISSQTY")), "0.000"), 1, 11), Mid(Format(Val(gdataset.Tables("SALES").Rows(0).Item("CLSQTY")), "0.000"), 1, 11))


            Filewrite.WriteLine(StrDup(137, "-"))
            pagesize = pagesize + 1
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Function
        End Try
    End Function
    Private Function PrintHeader(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,62}{1,-10}", " ", "DETAILS")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE :" & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(137, "-"))
            pagesize = pagesize + 1
            Filewrite.Write("{0,-12}{1,-10}{2,-20}{3,-20}{4,-12}{5,10}", "CODE/", "DOC", "ITEM NAME/", "INDENT NO./", "DEPT/", "RATE")
            Filewrite.WriteLine("{0,11}{1,13}{2,13}{3,13}", "VALUE", "RECEIPTS", "ISSUES", "BALANCE")
            pagesize = pagesize + 1
            Filewrite.Write("{0,-12}{1,-10}{2,-20}{3,-20}{4,-17}{5,5}", "DATE", "TYPE", "TYPE DOC NO.", "PARTY NAME", "REMARKS", "")
            Filewrite.WriteLine("{0,11}{1,13}{2,13}{3,13}", "", "QUANTITY", "QUANTITY", "QUANTITY")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(137, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
