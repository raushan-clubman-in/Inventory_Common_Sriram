Imports System.Data.SqlClient
Imports System.io
Public Class rptStockSummary
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Dim zeroval As Double
    Public Function Reportdetails(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal As Double
        Dim ITEMCODE, DOCDETAILS, GROUPNAME As String
        Dim ITEMBOOL, DOCBOOL As Boolean
        Dim opval, issval, closeval, rcval, groupvalue As Double
        Dim Topval, Tissval, Tcloseval, Trcval, Tgroupvalue As Double
        Dim I As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            opval = 0
            rcval = 0
            issval = 0
            closeval = 0
            groupvalue = 0
            Topval = 0
            Trcval = 0
            Tissval = 0
            Tcloseval = 0
            Tgroupvalue = 0
            Filewrite.Write(Chr(15))
            Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "STOCKSUMMARYREPORT")
            If gdataset.Tables("STOCKSUMMARYREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                GROUPNAME = Trim(gdataset.Tables("stocksummaryreport").Rows(0).Item("GROUPNAME"))
                Filewrite.WriteLine()
                Filewrite.WriteLine(Chr(15) & GROUPNAME)
                Filewrite.WriteLine()
                pagesize = pagesize + 3
                For Each dr In gdataset.Tables("STOCKSUMMARYREPORT").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(118, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If GROUPNAME <> Trim(CStr(dr("GROUPNAME"))) Then
                        GROUPNAME = Trim(CStr(dr("GROUPNAME")))
                        Filewrite.WriteLine(StrDup(118, "."))
                        Filewrite.WriteLine("{0,54}{1,12}{2,12}{3,12}{4,12}{5,12}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), Format(groupvalue, "0.00"))
                        Topval = Topval + opval
                        Tgroupvalue = Tgroupvalue + groupvalue
                        Trcval = Trcval + rcval
                        Tissval = Tissval + issval
                        Tcloseval = Tcloseval + closeval
                        Filewrite.WriteLine(StrDup(118, "."))
                        Filewrite.WriteLine()
                        opval = 0
                        rcval = 0
                        issval = 0
                        closeval = 0
                        groupvalue = 0
                        Filewrite.WriteLine()
                        Filewrite.WriteLine(Chr(15) & GROUPNAME)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 7
                    End If
                    zeroval = 0
                    Filewrite.Write("{0,-8}", Chr(15) & Mid(Trim(CStr(dr("ITEMCODE"))), 1, 8))
                    Filewrite.Write("{0,-24}", Mid(Trim(CStr(dr("ITEMDESC"))), 1, 24))
                    Filewrite.Write("{0,-10}", Mid(Trim(CStr(dr("UOM"))), 1, 10))
                    If Val(dr("VALUE")) <> 0 And Val(dr("CLSQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("VALUE")) / Val(dr("CLSQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPQTY")), "0.000"), 1, 12))
                    opval = opval + Val(dr("opqty"))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVQTY")), "0.000"), 1, 12))
                    rcval = rcval + Val(dr("rcvqty"))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSQTY")), "0.000"), 1, 12))
                    issval = issval + Val(dr("issqty"))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("CLSQTY")), "0.000"), 1, 12))
                    closeval = closeval + Val(dr("clsqty"))
                    Filewrite.WriteLine("{0,12}", Mid(Format(Val(dr("VALUE")), "0.00"), 1, 12))
                    groupvalue = groupvalue + Val(dr("VALUE"))
                    dblGrandTotal = dblGrandTotal + Format(Val(dr("VALUE")), "0.00")
                    pagesize = pagesize + 1
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(118, "."))
                Filewrite.WriteLine("{0,54}{1,12}{2,12}{3,12}{4,12}{5,12}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), Format(groupvalue, "0.00"))
                Topval = Topval + opval
                Tgroupvalue = Tgroupvalue + groupvalue
                Trcval = Trcval + rcval
                Tissval = Tissval + issval
                Tcloseval = Tcloseval + closeval
                Filewrite.WriteLine(StrDup(118, "."))
                Filewrite.WriteLine(StrDup(118, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,54}{1,12}{2,12}{3,12}{4,12}{5,12}", "GRAND TOTAL =======>        ", Format(Topval, "0.000"), Format(Trcval, "0.000"), Format(Tissval, "0.000"), Format(Tcloseval, "0.000"), Format(Tgroupvalue, "0.00"))
                pagesize = pagesize + 2
                Filewrite.WriteLine(StrDup(118, "="))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
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

    Public Function Reportdetails_closing(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal As Double
        Dim ITEMCODE, DOCDETAILS, GROUPNAME As String
        Dim ITEMBOOL, DOCBOOL As Boolean
        Dim opval, issval, closeval, rcval, groupvalue As Double
        Dim Topval, Tissval, Tcloseval, Trcval, Tgroupvalue As Double
        Dim I As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            opval = 0
            rcval = 0
            issval = 0
            closeval = 0
            groupvalue = 0
            Topval = 0
            Trcval = 0
            Tissval = 0
            Tcloseval = 0
            Tgroupvalue = 0
            Filewrite.Write(Chr(15))
            Call PrintHeader_closing(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "STOCKSUMMARYREPORT")
            If gdataset.Tables("STOCKSUMMARYREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                GROUPNAME = Trim(gdataset.Tables("stocksummaryreport").Rows(0).Item("GROUPNAME"))
                Filewrite.WriteLine()
                Filewrite.WriteLine(Chr(15) & GROUPNAME)
                Filewrite.WriteLine()
                pagesize = pagesize + 3
                For Each dr In gdataset.Tables("STOCKSUMMARYREPORT").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(82, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader_closing(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If GROUPNAME <> Trim(CStr(dr("GROUPNAME"))) Then
                        GROUPNAME = Trim(CStr(dr("GROUPNAME")))
                        Filewrite.WriteLine(StrDup(118, "."))
                        Filewrite.WriteLine("{0,54}{1,12}{2,12}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), Format(groupvalue, "0.00"))
                        Topval = Topval + opval
                        Tgroupvalue = Tgroupvalue + groupvalue
                        Trcval = Trcval + rcval
                        Tissval = Tissval + issval
                        Tcloseval = Tcloseval + closeval
                        Filewrite.WriteLine(StrDup(82, "."))
                        Filewrite.WriteLine()
                        opval = 0
                        rcval = 0
                        issval = 0
                        closeval = 0
                        groupvalue = 0
                        Filewrite.WriteLine()
                        Filewrite.WriteLine(Chr(15) & GROUPNAME)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 7
                    End If
                    If Val(dr("CLSQTY")) <> 0 Then
                        Filewrite.Write("{0,-8}", Chr(15) & Mid(Trim(CStr(dr("ITEMCODE"))), 1, 15))
                        Filewrite.Write("{0,-24}", Mid(Trim(CStr(dr("ITEMDESC"))), 1, 22))
                        Filewrite.Write("{0,-10}", Mid(Trim(CStr(dr("UOM"))), 1, 15))
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("RATE")), "0.00"), 1, 15))
                        '                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPQTY")), "0.000"), 1, 15))
                        opval = opval + Val(dr("opqty"))
                        '                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVQTY")), "0.000"), 1, 15))
                        rcval = rcval + Val(dr("rcvqty"))
                        '                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSQTY")), "0.000"), 1, 15))
                        issval = issval + Val(dr("issqty"))
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("CLSQTY")), "0.000"), 1, 15))
                        closeval = closeval + Val(dr("clsqty"))
                        Filewrite.WriteLine("{0,12}", Mid(Format(Val(dr("VALUE")), "0.00"), 1, 15))
                        groupvalue = groupvalue + Val(dr("VALUE"))
                        dblGrandTotal = dblGrandTotal + Format(Val(dr("VALUE")), "0.00")
                        pagesize = pagesize + 1
                    End If
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(82, "."))
                '                Filewrite.WriteLine("{0,54}{1,12}{2,12}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), Format(groupvalue, "0.00"))
                Filewrite.WriteLine("{0,54}{1,12}{2,12}", " TOTAL =======>        ", Format(closeval, "0.000"), Format(groupvalue, "0.00"))

                Filewrite.WriteLine(StrDup(82, "."))
                Filewrite.WriteLine(StrDup(82, "="))
                pagesize = pagesize + 4
                Topval = Topval + opval
                Tgroupvalue = Tgroupvalue + groupvalue
                Trcval = Trcval + rcval
                Tissval = Tissval + issval
                Tcloseval = Tcloseval + closeval
                Filewrite.WriteLine("{0,54}{1,12}{2,12}", "GRAND TOTAL =======>        ", Format(Tcloseval, "0.000"), Format(Tgroupvalue, "0.00"))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(82, "="))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
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

    Private Function PrintHeader_closing(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        Try
            Filewrite.WriteLine(Chr(18))
            Filewrite.WriteLine("{0,50}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "DETAILS")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.Write("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Chr(15) & StrDup(82, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("ITEM   ITEM                    UOM              Rate           CLOSING")
            Filewrite.WriteLine("CODE   DESCRIPTION                                            QTY       Value")
            pagesize = pagesize + 2
            Filewrite.WriteLine(StrDup(82, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function


    Public Function Reportdetails_Value(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal As Double
        Dim ITEMCODE, DOCDETAILS, GROUPNAME As String
        Dim ITEMBOOL, DOCBOOL As Boolean
        Dim opval, issval, clsval, rcVval, groupvalue As Double
        Dim OPQTY, RCVQTY, ISSQTY, CLSQTY As Double
        Dim Topval, Tissval, Tclsval, Trcvval, Tgroupvalue As Double
        Dim Topqty, Tissqty, Tclsqty, Trcvqty As Double

        Dim I As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1

            opval = 0 : rcVval = 0 : issval = 0 : clsval = 0 : groupvalue = 0

            Topqty = 0 : Trcvqty = 0 : Tissqty = 0 : Tclsqty = 0

            Topval = 0 : Trcvval = 0 : Tissval = 0 : Tclsval = 0 : Tgroupvalue = 0


            Filewrite.Write(Chr(15))
            Call PrintHeader_Value(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "STOCKSUMMARYREPORT")
            If gdataset.Tables("STOCKSUMMARYREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                GROUPNAME = Trim(gdataset.Tables("stocksummaryreport").Rows(0).Item("GROUPNAME"))
                Filewrite.WriteLine()
                Filewrite.WriteLine(Chr(15) & GROUPNAME)
                Filewrite.WriteLine()
                pagesize = pagesize + 3
                For Each dr In gdataset.Tables("STOCKSUMMARYREPORT").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(197, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader_Value(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If GROUPNAME <> Trim(CStr(dr("GROUPNAME"))) Then
                        GROUPNAME = Trim(CStr(dr("GROUPNAME")))
                        Filewrite.WriteLine(StrDup(197, "."))
                        Filewrite.WriteLine("{0,42}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}", " TOTAL =======>        ", Format(OPQTY, "0.000"), " ", Format(opval, "0.00"), Format(RCVQTY, "0.000"), " ", Format(rcVval, "0.00"), Format(ISSQTY, "0.000"), " ", Format(issval, "0.00"), Format(CLSQTY, "0.000"), " ", Format(clsval, "0.00"))

                        Topqty = Topqty + OPQTY
                        Trcvqty = Trcvqty + RCVQTY
                        Tissqty = Tissqty + ISSQTY
                        Tclsqty = Tclsqty + CLSQTY

                        Topval = Topval + opval
                        Tgroupvalue = Tgroupvalue + groupvalue
                        Trcvval = Trcvval + rcVval
                        Tissval = Tissval + issval
                        Tclsval = Tclsval + clsval

                        Filewrite.WriteLine(StrDup(197, "."))
                        Filewrite.WriteLine()
                        OPQTY = 0 : RCVQTY = 0 : ISSQTY = 0 : CLSQTY = 0 : opval = 0 : rcVval = 0 : issval = 0 : clsval = 0 : groupvalue = 0
                        Filewrite.WriteLine()
                        Filewrite.WriteLine(Chr(15) & GROUPNAME)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 7
                    End If
                    Filewrite.Write("{0,-8}", Chr(15) & Mid(Trim(CStr(dr("ITEMCODE"))), 1, 8))
                    Filewrite.Write("{0,-24}", Mid(Trim(CStr(dr("ITEMDESC"))), 1, 24))
                    Filewrite.Write("{0,-10}", Mid(Trim(CStr(dr("UOM"))), 1, 10))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPQTY")), "0.000"), 1, 12))
                    zeroval = 0
                    If Val(dr("OPVAL")) <> 0 And Val(dr("OPQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPVAL")) / Val(dr("OPQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPVAL")), "0.00"), 1, 12))
                    OPQTY = OPQTY + Val(dr("opqty"))
                    opval = opval + Val(dr("opval"))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVQTY")), "0.000"), 1, 12))
                    If (Val(dr("RCVVAL"))) <> 0 And (Val(dr("RCVQtY"))) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format((Val(dr("RCVVAL"))) / (Val(dr("RCVQtY"))), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVVAL")), "0.00"), 1, 12))
                    RCVQTY = RCVQTY + Val(dr("rcvqty"))
                    rcVval = rcVval + Val(dr("rcvVAL"))
                    zeroval = 0
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSQTY")), "0.000"), 1, 12))
                    ISSQTY = ISSQTY + Val(dr("issqty"))
                    If Val(dr("ISSVAL")) <> 0 And Val(dr("ISSQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSVAL")) / Val(dr("ISSQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSVAL")), "0.00"), 1, 12))
                    issval = issval + Val(dr("issVAL"))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("CLSQTY")), "0.000"), 1, 12))
                    CLSQTY = CLSQTY + Val(dr("clsqty"))
                    If Val(dr("VALUE")) <> 0 And Val(dr("CLSQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("VALUE")) / Val(dr("CLSQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("VALUE")), "0.00"), 1, 12))
                    Filewrite.WriteLine("{0,12}", Mid(Format(Val(dr("DISPQTY")), "0"), 1, 12))

                    clsval = clsval + Val(dr("VALUE"))
                    groupvalue = groupvalue + Val(dr("VALUE"))
                    dblGrandTotal = dblGrandTotal + Format(Val(dr("VALUE")), "0.00")
                    pagesize = pagesize + 1
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(197, "."))
                Filewrite.WriteLine("{0,42}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}", " TOTAL =======>        ", Format(OPQTY, "0.000"), " ", Format(opval, "0.00"), Format(RCVQTY, "0.000"), " ", Format(rcVval, "0.00"), Format(ISSQTY, "0.000"), " ", Format(issval, "0.00"), Format(CLSQTY, "0.000"), " ", Format(clsval, "0.00"))

                Topqty = Topqty + OPQTY
                Trcvqty = Trcvqty + RCVQTY
                Tissqty = Tissqty + ISSQTY
                Tclsqty = Tclsqty + CLSQTY

                Topval = Topval + opval
                Tgroupvalue = Tgroupvalue + groupvalue
                Trcvval = Trcvval + rcVval
                Tissval = Tissval + issval
                Tclsval = Tclsval + clsval
                Filewrite.WriteLine(StrDup(197, "."))

                Filewrite.WriteLine(StrDup(197, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,42}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}", "GRAND TOTAL =======>        ", Format(Topqty, "0.000"), " ", Format(Topval, "0.00"), Format(Trcvqty, "0.000"), " ", Format(Trcvval, "0.00"), Format(Tissqty, "0.000"), " ", Format(Tissval, "0.00"), Format(Tclsqty, "0.000"), " ", Format(Tclsval, "0.00"))
                pagesize = pagesize + 2
                Filewrite.WriteLine(StrDup(197, "="))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
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
    Private Function PrintHeader_Value(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine(Chr(18))
            Filewrite.WriteLine("{0,50}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "DETAILS")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.Write("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Chr(15) & StrDup(197, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("ITEM   ITEM                    UOM                          OPENING                             RECEIVED                             ISSUED                                  CLOSING                  ")
            Filewrite.WriteLine("CODE   DESCRIPTION                              ------------------------------  ------------------------------------  ----------------------------------  --------------------------------------------")
            Filewrite.WriteLine("                                                 QTY         RATE       VALUE         QTY          RATE       VALUE        QTY        RATE        VALUE        QTY        RATE       VALUE   Conv Qty.")
            pagesize = pagesize + 3
            Filewrite.WriteLine(StrDup(197, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Public Function Reportdetails_Qty(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal As Double
        Dim ITEMCODE, DOCDETAILS, GROUPNAME As String
        Dim ITEMBOOL, DOCBOOL As Boolean
        Dim opval, issval, clsval, rcVval, groupvalue As Double
        Dim OPQTY, RCVQTY, ISSQTY, CLSQTY As Double
        Dim RCVQTY1, ISSQTY1, RCVQTY2, ISSQTY2, RCVQTY3, ISSQTY3 As Double
        Dim RCVVAL1, ISSVAL1, RCVVAL2, ISSVAL2, RCVVAL3, ISSVAL3 As Double
        Dim TRCVQTY1, TISSQTY1, TRCVQTY2, TISSQTY2, TRCVQTY3, TISSQTY3 As Double

        Dim Topval, Tissval, Tclsval, Trcvval, Tgroupvalue As Double
        Dim Topqty, Tissqty, Tclsqty, Trcvqty As Double

        Dim I As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1

            opval = 0 : rcVval = 0 : issval = 0 : clsval = 0 : groupvalue = 0

            Topqty = 0 : Trcvqty = 0 : Tissqty = 0 : Tclsqty = 0

            Topval = 0 : Trcvval = 0 : Tissval = 0 : Tclsval = 0

            Tgroupvalue = 0
            TRCVQTY1 = 0 : TISSQTY1 = 0 : TRCVQTY2 = 0 : TISSQTY2 = 0 : TRCVQTY3 = 0 : TISSQTY3 = 0

            Filewrite.Write(Chr(15))
            Call PrintHeader_Qty(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "STOCKSUMMARYREPORT")
            If gdataset.Tables("STOCKSUMMARYREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                GROUPNAME = Trim(gdataset.Tables("stocksummaryreport").Rows(0).Item("GROUPNAME"))
                Filewrite.WriteLine()
                Filewrite.WriteLine(Chr(15) & GROUPNAME)
                Filewrite.WriteLine()
                pagesize = pagesize + 3
                For Each dr In gdataset.Tables("STOCKSUMMARYREPORT").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(255, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader_Qty(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If GROUPNAME <> Trim(CStr(dr("GROUPNAME"))) Then
                        GROUPNAME = Trim(CStr(dr("GROUPNAME")))
                        Filewrite.WriteLine(StrDup(255, "."))
                        Filewrite.WriteLine("{0,39}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}{13,12}{14,12}{15,12}{16,12}{17,12}{18,12}", " TOTAL =======>        ", Format(OPQTY, "0.000"), " ", Format(opval, "0.00"), Format(RCVQTY1, "0.000"), Format(RCVQTY2, "0.000"), Format(RCVQTY3, "0.000"), Format(RCVQTY, "0.000"), " ", Format(rcVval, "0.00"), Format(ISSQTY1, "0.000"), Format(ISSQTY2, "0.000"), Format(ISSQTY3, "0.000"), Format(ISSQTY, "0.000"), " ", Format(issval, "0.00"), Format(CLSQTY, "0.000"), " ", Format(clsval, "0.00"))

                        Topqty = Topqty + OPQTY
                        Trcvqty = Trcvqty + RCVQTY
                        Tissqty = Tissqty + ISSQTY
                        Tclsqty = Tclsqty + CLSQTY

                        TRCVQTY1 = TRCVQTY1 + RCVQTY1
                        TISSQTY1 = TISSQTY1 + ISSQTY1

                        TRCVQTY2 = TRCVQTY2 + RCVQTY2
                        TISSQTY2 = TISSQTY2 + ISSQTY2

                        TRCVQTY3 = TRCVQTY3 + RCVQTY3
                        TISSQTY3 = TISSQTY3 + ISSQTY3

                        Topval = Topval + opval
                        Tgroupvalue = Tgroupvalue + groupvalue
                        Trcvval = Trcvval + rcVval
                        Tissval = Tissval + issval
                        Tclsval = Tclsval + clsval

                        Filewrite.WriteLine(StrDup(255, "."))
                        Filewrite.WriteLine()
                        OPQTY = 0 : RCVQTY = 0 : ISSQTY = 0 : CLSQTY = 0

                        opval = 0 : rcVval = 0 : issval = 0 : clsval = 0
                        RCVQTY1 = 0 : ISSQTY1 = 0 : RCVQTY2 = 0 : ISSQTY2 = 0 : RCVQTY3 = 0 : ISSQTY3 = 0
                        groupvalue = 0

                        Filewrite.WriteLine()
                        Filewrite.WriteLine(Chr(15) & GROUPNAME)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 7
                    End If
                    Filewrite.Write("{0,-8}", Chr(15) & Mid(Trim(CStr(dr("ITEMCODE"))), 1, 8))
                    Filewrite.Write("{0,-21}", Mid(Trim(CStr(dr("ITEMDESC"))), 1, 21))
                    Filewrite.Write("{0,-10}", Mid(Trim(CStr(dr("UOM"))), 1, 10))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPQTY")), "0.000"), 1, 12))
                    zeroval = 0
                    If Val(dr("OPVAL")) <> 0 And Val(dr("OPQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPVAL")) / Val(dr("OPQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPVAL")), "0.00"), 1, 12))
                    OPQTY = OPQTY + Val(dr("opqty"))
                    opval = opval + Val(dr("opval"))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVQTY1")), "0.000"), 1, 12))
                    '                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVRATE1")), "0.00"), 1, 12))
                    '                   Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVVAL1")), "0.00"), 1, 12))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVQTY2")), "0.000"), 1, 12))
                    '                  Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVRATE2")), "0.00"), 1, 12))
                    '                 Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVVAL2")), "0.00"), 1, 12))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVQTY3")), "0.000"), 1, 12))
                    '                Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVRATE3")), "0.00"), 1, 12))
                    '               Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVVAL3")), "0.00"), 1, 12))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVQTY")), "0.000"), 1, 12))
                    If (Val(dr("RCVVAL"))) <> 0 And (Val(dr("RCVQTY"))) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format((Val(dr("RCVVAL"))) / (Val(dr("RCVQTY"))), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVVAL")), "0.00"), 1, 12))
                    RCVQTY = RCVQTY + Val(dr("rcvqty"))
                    RCVQTY1 = RCVQTY1 + Val(dr("rcvqty1"))
                    RCVQTY2 = RCVQTY2 + Val(dr("rcvqty2"))
                    RCVQTY3 = RCVQTY3 + Val(dr("rcvqty3"))

                    rcVval = rcVval + Val(dr("rcvVAL"))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSQTY1")), "0.000"), 1, 12))
                    '              Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSRATE1")), "0.00"), 1, 12))
                    '             Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSVAL1")), "0.00"), 1, 12))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSQTY2")), "0.000"), 1, 12))
                    '            Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSRATE2")), "0.00"), 1, 12))
                    '           Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSVAL2")), "0.00"), 1, 12))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSQTY3")), "0.000"), 1, 12))
                    '          Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSRATE3")), "0.00"), 1, 12))
                    '         Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSVAL3")), "0.00"), 1, 12))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSQTY")), "0.000"), 1, 12))
                    If Val(dr("ISSVAL")) <> 0 And Val(dr("ISSQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSVAL")) / Val(dr("ISSQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSVAL")), "0.00"), 1, 12))
                    ISSQTY = ISSQTY + Val(dr("issqty"))
                    ISSQTY1 = ISSQTY1 + Val(dr("issqty1"))
                    ISSQTY2 = ISSQTY2 + Val(dr("issqty2"))
                    ISSQTY3 = ISSQTY3 + Val(dr("issqty3"))

                    issval = issval + Val(dr("issVAL"))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("CLSQTY")), "0.000"), 1, 12))
                    CLSQTY = CLSQTY + Val(dr("clsqty"))
                    If Val(dr("VALUE")) <> 0 And Val(dr("CLSQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("VALUE")) / Val(dr("CLSQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.WriteLine("{0,12}", Mid(Format(Val(dr("VALUE")), "0.00"), 1, 12))
                    clsval = clsval + Val(dr("VALUE"))
                    groupvalue = groupvalue + Val(dr("VALUE"))
                    dblGrandTotal = dblGrandTotal + Format(Val(dr("VALUE")), "0.00")
                    pagesize = pagesize + 1
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(255, "."))
                Filewrite.WriteLine("{0,42}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}{13,12}{14,12}{15,12}{16,12}{17,12}{18,12}", " TOTAL =======>        ", Format(OPQTY, "0.000"), " ", Format(opval, "0.00"), Format(RCVQTY1, "0.000"), Format(RCVQTY2, "0.000"), Format(RCVQTY3, "0.000"), Format(RCVQTY, "0.000"), " ", Format(rcVval, "0.00"), Format(ISSQTY1, "0.000"), Format(ISSQTY2, "0.000"), Format(ISSQTY3, "0.000"), Format(ISSQTY, "0.000"), " ", Format(issval, "0.00"), Format(CLSQTY, "0.000"), " ", Format(clsval, "0.00"))

                Topqty = Topqty + OPQTY
                Trcvqty = Trcvqty + RCVQTY
                Tissqty = Tissqty + ISSQTY
                Tclsqty = Tclsqty + CLSQTY

                TRCVQTY1 = TRCVQTY1 + RCVQTY1
                TISSQTY1 = TISSQTY1 + ISSQTY1

                TRCVQTY2 = TRCVQTY2 + RCVQTY2
                TISSQTY2 = TISSQTY2 + ISSQTY2

                TRCVQTY3 = TRCVQTY3 + RCVQTY3
                TISSQTY3 = TISSQTY3 + ISSQTY3

                Topval = Topval + opval
                Tgroupvalue = Tgroupvalue + groupvalue
                Trcvval = Trcvval + rcVval
                Tissval = Tissval + issval
                Tclsval = Tclsval + clsval

                Filewrite.WriteLine(StrDup(255, "."))
                Filewrite.WriteLine(StrDup(255, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,42}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}{13,12}{14,12}{15,12}{16,12}{17,12}{18,12}", "GRAND TOTAL =======>        ", Format(Topqty, "0.000"), " ", Format(Topval, "0.00"), Format(TRCVQTY1, "0.000"), Format(TRCVQTY2, "0.000"), Format(TRCVQTY3, "0.000"), Format(Trcvqty, "0.000"), " ", Format(Trcvval, "0.00"), Format(TISSQTY1, "0.000"), Format(TISSQTY2, "0.000"), Format(TISSQTY3, "0.000"), Format(Tissqty, "0.000"), " ", Format(Tissval, "0.00"), Format(Tclsqty, "0.000"), " ", Format(Tclsval, "0.00"))
                pagesize = pagesize + 2
                Filewrite.WriteLine(StrDup(255, "="))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
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
    Private Function PrintHeader_Qty(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine(Chr(18))
            Filewrite.WriteLine("{0,50}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "DETAILS")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.Write("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Chr(15) & StrDup(255, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("ITEM   ITEM                    UOM                        OPENING                                                   RECEIVED                                                                  ISSUED                                     CLOSING        ")
            Filewrite.WriteLine("CODE   DESCRIPTION                            ------------------------------  -----------------------------------------------------------------------  ----------------------------------------------------------------------  ---------------------------------")
            Filewrite.WriteLine("                                               QTY         RATE       VALUE         QTY1        QTY2        QTY3      TOTAL         RATE       VALUE        QTY1        QTY2        QTY3        TOTAL       RATE        VALUE        QTY        RATE       VALUE")
            pagesize = pagesize + 3
            Filewrite.WriteLine(StrDup(255, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Private Function PrintHeader(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine(Chr(18))
            Filewrite.WriteLine("{0,50}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "DETAILS")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.Write("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Chr(15) & StrDup(118, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-8}{1,-24}{2,-10}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}", Chr(15) & "ITEM", "ITEM", "UOM", "RATE", "OPENING", "RECEIVED", "ISSUED", "CLOSING", "VALUE")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-8}{1,-24}{2,-10}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}", Chr(15) & "CODE", "DESCRIPTION", "", "", "QTY", "QTY", "QTY", "QTY", "")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(118, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Public Function Reportdetails_Value_withoutGroup(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal As Double
        Dim ITEMCODE, DOCDETAILS, GROUPNAME As String
        Dim ITEMBOOL, DOCBOOL As Boolean
        Dim opval, issval, clsval, rcVval, groupvalue As Double
        Dim OPQTY, RCVQTY, ISSQTY, CLSQTY As Double
        Dim Topval, Tissval, Tclsval, Trcvval, Tgroupvalue As Double
        Dim Topqty, Tissqty, Tclsqty, Trcvqty As Double

        Dim I As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1

            opval = 0 : rcVval = 0 : issval = 0 : clsval = 0 : groupvalue = 0

            Topqty = 0 : Trcvqty = 0 : Tissqty = 0 : Tclsqty = 0

            Topval = 0 : Trcvval = 0 : Tissval = 0 : Tclsval = 0 : Tgroupvalue = 0


            Filewrite.Write(Chr(15))
            Call PrintHeader_Value(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "STOCKSUMMARYREPORT")
            If gdataset.Tables("STOCKSUMMARYREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                GROUPNAME = Trim(gdataset.Tables("stocksummaryreport").Rows(0).Item("GROUPNAME"))
                'Filewrite.WriteLine()
                'Filewrite.WriteLine(Chr(15) & GROUPNAME)
                Filewrite.WriteLine()
                pagesize = pagesize + 3
                For Each dr In gdataset.Tables("STOCKSUMMARYREPORT").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(197, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader_Value(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    'If GROUPNAME <> Trim(CStr(dr("GROUPNAME"))) Then
                    '    GROUPNAME = Trim(CStr(dr("GROUPNAME")))
                    '    Filewrite.WriteLine(StrDup(197, "."))
                    '    Filewrite.WriteLine("{0,42}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}", " TOTAL =======>        ", Format(OPQTY, "0.000"), " ", Format(opval, "0.00"), Format(RCVQTY, "0.000"), " ", Format(rcVval, "0.00"), Format(ISSQTY, "0.000"), " ", Format(issval, "0.00"), Format(CLSQTY, "0.000"), " ", Format(clsval, "0.00"))

                    '    Topqty = Topqty + OPQTY
                    '    Trcvqty = Trcvqty + RCVQTY
                    '    Tissqty = Tissqty + ISSQTY
                    '    Tclsqty = Tclsqty + CLSQTY

                    '    Topval = Topval + opval
                    '    Tgroupvalue = Tgroupvalue + groupvalue
                    '    Trcvval = Trcvval + rcVval
                    '    Tissval = Tissval + issval
                    '    Tclsval = Tclsval + clsval

                    '    Filewrite.WriteLine(StrDup(197, "."))
                    '    Filewrite.WriteLine()
                    '    OPQTY = 0 : RCVQTY = 0 : ISSQTY = 0 : CLSQTY = 0 : opval = 0 : rcVval = 0 : issval = 0 : clsval = 0 : groupvalue = 0
                    '    Filewrite.WriteLine()
                    '    Filewrite.WriteLine(Chr(15) & GROUPNAME)
                    '    Filewrite.WriteLine()
                    '    pagesize = pagesize + 7
                    'End If
                    Filewrite.Write("{0,-8}", Chr(15) & Mid(Trim(CStr(dr("ITEMCODE"))), 1, 8))
                    Filewrite.Write("{0,-24}", Mid(Trim(CStr(dr("ITEMDESC"))), 1, 24))
                    Filewrite.Write("{0,-10}", Mid(Trim(CStr(dr("UOM"))), 1, 10))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPQTY")), "0.000"), 1, 12))
                    zeroval = 0
                    If Val(dr("OPVAL")) <> 0 And Val(dr("OPQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPVAL")) / Val(dr("OPQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPVAL")), "0.00"), 1, 12))
                    OPQTY = OPQTY + Val(dr("opqty"))
                    opval = opval + Val(dr("opval"))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVQTY")), "0.000"), 1, 12))
                    If (Val(dr("RCVVAL"))) <> 0 And (Val(dr("RCVQtY"))) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format((Val(dr("RCVVAL"))) / (Val(dr("RCVQtY"))), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVVAL")), "0.00"), 1, 12))
                    RCVQTY = RCVQTY + Val(dr("rcvqty"))
                    rcVval = rcVval + Val(dr("rcvVAL"))
                    zeroval = 0
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSQTY")), "0.000"), 1, 12))
                    ISSQTY = ISSQTY + Val(dr("issqty"))
                    If Val(dr("ISSVAL")) <> 0 And Val(dr("ISSQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSVAL")) / Val(dr("ISSQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSVAL")), "0.00"), 1, 12))
                    issval = issval + Val(dr("issVAL"))

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("CLSQTY")), "0.000"), 1, 12))
                    CLSQTY = CLSQTY + Val(dr("clsqty"))
                    If Val(dr("VALUE")) <> 0 And Val(dr("CLSQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("VALUE")) / Val(dr("CLSQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("VALUE")), "0.00"), 1, 12))
                    Filewrite.WriteLine("{0,12}", Mid(Format(Val(dr("DISPQTY")), "0"), 1, 12))

                    clsval = clsval + Val(dr("VALUE"))
                    groupvalue = groupvalue + Val(dr("VALUE"))
                    dblGrandTotal = dblGrandTotal + Format(Val(dr("VALUE")), "0.00")
                    pagesize = pagesize + 1
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                'Filewrite.WriteLine(StrDup(197, "."))
                'Filewrite.WriteLine("{0,42}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}", " TOTAL =======>        ", Format(OPQTY, "0.000"), " ", Format(opval, "0.00"), Format(RCVQTY, "0.000"), " ", Format(rcVval, "0.00"), Format(ISSQTY, "0.000"), " ", Format(issval, "0.00"), Format(CLSQTY, "0.000"), " ", Format(clsval, "0.00"))

                Topqty = Topqty + OPQTY
                Trcvqty = Trcvqty + RCVQTY
                Tissqty = Tissqty + ISSQTY
                Tclsqty = Tclsqty + CLSQTY

                Topval = Topval + opval
                Tgroupvalue = Tgroupvalue + groupvalue
                Trcvval = Trcvval + rcVval
                Tissval = Tissval + issval
                Tclsval = Tclsval + clsval
                'Filewrite.WriteLine(StrDup(197, "."))

                Filewrite.WriteLine(StrDup(197, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,42}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}{9,12}{10,12}{11,12}{12,12}", "GRAND TOTAL =======>        ", Format(Topqty, "0.000"), " ", Format(Topval, "0.00"), Format(Trcvqty, "0.000"), " ", Format(Trcvval, "0.00"), Format(Tissqty, "0.000"), " ", Format(Tissval, "0.00"), Format(Tclsqty, "0.000"), " ", Format(Tclsval, "0.00"))
                pagesize = pagesize + 2
                Filewrite.WriteLine(StrDup(197, "="))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
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
    Public Function Reportdetails_withoutGroup(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal As Double
        Dim ITEMCODE, DOCDETAILS, GROUPNAME As String
        Dim ITEMBOOL, DOCBOOL As Boolean
        Dim opval, issval, closeval, rcval, groupvalue As Double
        Dim Topval, Tissval, Tcloseval, Trcval, Tgroupvalue As Double
        Dim I As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            opval = 0
            rcval = 0
            issval = 0
            closeval = 0
            groupvalue = 0
            Topval = 0
            Trcval = 0
            Tissval = 0
            Tcloseval = 0
            Tgroupvalue = 0
            Filewrite.Write(Chr(15))
            Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "STOCKSUMMARYREPORT")
            If gdataset.Tables("STOCKSUMMARYREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                GROUPNAME = Trim(gdataset.Tables("stocksummaryreport").Rows(0).Item("GROUPNAME"))
                'Filewrite.WriteLine()
                'Filewrite.WriteLine(Chr(15) & GROUPNAME)
                Filewrite.WriteLine()
                pagesize = pagesize + 3
                For Each dr In gdataset.Tables("STOCKSUMMARYREPORT").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(118, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    'If GROUPNAME <> Trim(CStr(dr("GROUPNAME"))) Then
                    '    GROUPNAME = Trim(CStr(dr("GROUPNAME")))
                    '    Filewrite.WriteLine(StrDup(118, "."))
                    '    Filewrite.WriteLine("{0,54}{1,12}{2,12}{3,12}{4,12}{5,12}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), Format(groupvalue, "0.00"))
                    '    Topval = Topval + opval
                    '    Tgroupvalue = Tgroupvalue + groupvalue
                    '    Trcval = Trcval + rcval
                    '    Tissval = Tissval + issval
                    '    Tcloseval = Tcloseval + closeval
                    '    Filewrite.WriteLine(StrDup(118, "."))
                    '    Filewrite.WriteLine()
                    '    opval = 0
                    '    rcval = 0
                    '    issval = 0
                    '    closeval = 0
                    '    groupvalue = 0
                    '    Filewrite.WriteLine()
                    '    Filewrite.WriteLine(Chr(15) & GROUPNAME)
                    '    Filewrite.WriteLine()
                    '    pagesize = pagesize + 7
                    'End If
                    zeroval = 0
                    Filewrite.Write("{0,-8}", Chr(15) & Mid(Trim(CStr(dr("ITEMCODE"))), 1, 8))
                    Filewrite.Write("{0,-24}", Mid(Trim(CStr(dr("ITEMDESC"))), 1, 24))
                    Filewrite.Write("{0,-10}", Mid(Trim(CStr(dr("UOM"))), 1, 10))
                    If Val(dr("VALUE")) <> 0 And Val(dr("CLSQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("VALUE")) / Val(dr("CLSQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPQTY")), "0.000"), 1, 12))
                    opval = opval + Val(dr("opqty"))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVQTY")), "0.000"), 1, 12))
                    rcval = rcval + Val(dr("rcvqty"))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSQTY")), "0.000"), 1, 12))
                    issval = issval + Val(dr("issqty"))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("CLSQTY")), "0.000"), 1, 12))
                    closeval = closeval + Val(dr("clsqty"))
                    Filewrite.WriteLine("{0,12}", Mid(Format(Val(dr("VALUE")), "0.00"), 1, 12))
                    groupvalue = groupvalue + Val(dr("VALUE"))
                    dblGrandTotal = dblGrandTotal + Format(Val(dr("VALUE")), "0.00")
                    pagesize = pagesize + 1
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                'Filewrite.WriteLine(StrDup(118, "."))
                'Filewrite.WriteLine("{0,54}{1,12}{2,12}{3,12}{4,12}{5,12}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), Format(groupvalue, "0.00"))
                Topval = Topval + opval
                Tgroupvalue = Tgroupvalue + groupvalue
                Trcval = Trcval + rcval
                Tissval = Tissval + issval
                Tcloseval = Tcloseval + closeval
                'Filewrite.WriteLine(StrDup(118, "."))
                Filewrite.WriteLine(StrDup(118, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,54}{1,12}{2,12}{3,12}{4,12}{5,12}", "GRAND TOTAL =======>        ", Format(Topval, "0.000"), Format(Trcval, "0.000"), Format(Tissval, "0.000"), Format(Tcloseval, "0.000"), Format(Tgroupvalue, "0.00"))
                pagesize = pagesize + 2
                Filewrite.WriteLine(StrDup(118, "="))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
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
End Class
