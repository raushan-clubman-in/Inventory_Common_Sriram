Imports System.Data.SqlClient
Imports System.io
Public Class rptStockadjustment
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Public Function Reportdetails_ITEMCODE(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal As Double
        Dim STOREDESC, DOCDETAILS As String
        Dim ITEMCODE As String
        Dim STOREBOOL, DOCBOOL As Boolean
        Dim I As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "STOCKADJUSTMENTREPORT")
            If gdataset.Tables("STOCKADJUSTMENTREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                For Each dr In gdataset.Tables("STOCKADJUSTMENTREPORT").Rows
                    If pagesize > 56 Then
                        Filewrite.Write(StrDup(135, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If

                    If ITEMCODE <> Trim(CStr(dr("ITEMCODE"))) Then
                        If DOCBOOL = True Then
                            Filewrite.WriteLine()
                            pagesize = pagesize + 1
                            Filewrite.WriteLine(StrDup(135, "."))
                            pagesize = pagesize + 1
                            Filewrite.Write("{0,-13}{1,-30}{2,-10}{3,-23}", "", "ITEM TOTAL ====>", "", "")
                            Filewrite.WriteLine("{0,-5}{1,10}{2,10}{3,10}{4,12}{5,12}", "", "", "", "", "", Format(Val(dbldocTotal), "0.00"))
                            pagesize = pagesize + 1
                            Filewrite.WriteLine(StrDup(135, "."))
                            pagesize = pagesize + 1
                            ITEMCODE = dr("ITEMCODE")
                            DOCBOOL = True
                            dbldocTotal = 0
                        Else
                            ITEMCODE = dr("ITEMCODE")
                            DOCBOOL = True
                            dbldocTotal = 0
                        End If
                        'Else
                        '    Filewrite.Write("{0,-13}", "")
                        '    Filewrite.Write("{0,-18}", "")
                        '    Filewrite.Write("{0,-12}", "")
                    End If
                    Filewrite.Write("{0,-13}", Mid(Trim(CStr(dr("STORELOCATIONDESC"))), 1, 13))
                    Filewrite.Write("{0,-18}", Mid(Trim(CStr(dr("DOCDETAILS"))), 1, 18))
                    Filewrite.Write("{0,-12}", Mid(Format(CDate(dr("DOCDATE")), "dd/MM/yyyy"), 1, 12))
                    Filewrite.Write("{0,-10}", Mid(Trim(CStr(dr("ITEMCODE"))), 1, 10))
                    Filewrite.Write("{0,-23}", Mid(Trim(CStr(dr("ITEMNAME"))), 1, 23))
                    Filewrite.Write("{0,-5}", Mid(Trim(CStr(dr("UOM"))), 1, 10))
                    Filewrite.Write("{0,10}", Mid(Format(Val(dr("STOCKINHAND")), "0.000"), 1, 10))
                    Filewrite.Write("{0,10}", Mid(Format(Val(dr("PHYSICALSTOCK")), "0.000"), 1, 10))
                    Filewrite.Write("{0,10}", Mid(Format(Val(dr("ADJUSTEDSTOCK")), "0.000"), 1, 10))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RATE")), "0.00"), 1, 12))
                    Filewrite.WriteLine("{0,12}", Mid(Format(Val(dr("AMOUNT")), "0.00"), 1, 15))
                    pagesize = pagesize + 1
                    dbldocTotal = dbldocTotal + Format(Val(dr("AMOUNT")), "0.00")
                    dblGrandTotal = dblGrandTotal + Format(Val(dr("AMOUNT")), "0.00")
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "."))
                pagesize = pagesize + 1
                Filewrite.Write("{0,-13}{1,-30}{2,-10}{3,-23}", "", "ITEM TOTAL ====>", "", "")
                Filewrite.WriteLine("{0,-5}{1,10}{2,10}{3,10}{4,12}{5,12}", "", "", "", "", "", Format(Val(dbldocTotal), "0.00"))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "."))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "="))
                pagesize = pagesize + 1
                Filewrite.Write("{0,-13}{1,-30}{2,-10}{3,-23}", "", "GRAND TOTAL =====>", "", "")
                Filewrite.WriteLine("{0,-5}{1,10}{2,10}{3,10}{4,12}{5,12}", "", "", "", "", "", Format(Val(dblGrandTotal), "0.00"))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "="))
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
    Public Function Reportdetails_DOCDETAILS(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal As Double
        Dim STROEDESC, DOCDETAILS As String
        Dim STOREBOOL, DOCBOOL As Boolean
        Dim I As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "STOCKADJUSTMENTREPORT")
            If gdataset.Tables("STOCKADJUSTMENTREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                For Each dr In gdataset.Tables("STOCKADJUSTMENTREPORT").Rows
                    If pagesize > 56 Then
                        Filewrite.Write(StrDup(135, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If DOCDETAILS <> Trim(CStr(dr("DOCDETAILS"))) Then
                        If DOCBOOL = True Then
                            Filewrite.WriteLine()
                            pagesize = pagesize + 1
                            Filewrite.WriteLine(StrDup(135, "."))
                            pagesize = pagesize + 1
                            Filewrite.Write("{0,-13}{1,-30}{2,-10}{3,-23}", "", "DOC TOTAL =====>", "", "")
                            Filewrite.WriteLine("{0,-5}{1,10}{2,10}{3,10}{4,12}{5,12}", "", "", "", "", "", Format(Val(dbldocTotal), "0.00"))
                            pagesize = pagesize + 1
                            Filewrite.WriteLine(StrDup(135, "."))
                            pagesize = pagesize + 1
                            Filewrite.Write("{0,-13}", Mid(Trim(CStr(dr("STORELOCATIONDESC"))), 1, 13))
                            Filewrite.Write("{0,-18}", Mid(Trim(CStr(dr("DOCDETAILS"))), 1, 18))
                            Filewrite.Write("{0,-12}", Mid(Format(CDate(dr("DOCDATE")), "dd/MM/yyyy"), 1, 12))
                            DOCDETAILS = dr("DOCDETAILS")
                            DOCBOOL = True
                            dbldocTotal = 0
                        Else
                            Filewrite.Write("{0,-13}", Mid(Trim(CStr(dr("STORELOCATIONDESC"))), 1, 13))
                            Filewrite.Write("{0,-18}", Mid(Trim(CStr(dr("DOCDETAILS"))), 1, 18))
                            Filewrite.Write("{0,-12}", Mid(Format(CDate(dr("DOCDATE")), "dd/MM/yyyy"), 1, 12))
                            DOCDETAILS = dr("DOCDETAILS")
                            DOCBOOL = True
                            dbldocTotal = 0
                        End If
                    Else
                        Filewrite.Write("{0,-13}", "")
                        Filewrite.Write("{0,-18}", "")
                        Filewrite.Write("{0,-12}", "")
                    End If
                    Filewrite.Write("{0,-10}", Mid(Trim(CStr(dr("ITEMCODE"))), 1, 10))
                    Filewrite.Write("{0,-23}", Mid(Trim(CStr(dr("ITEMNAME"))), 1, 23))
                    Filewrite.Write("{0,-5}", Mid(Trim(CStr(dr("UOM"))), 1, 10))
                    Filewrite.Write("{0,10}", Mid(Format(Val(dr("STOCKINHAND")), "0.000"), 1, 10))
                    Filewrite.Write("{0,10}", Mid(Format(Val(dr("PHYSICALSTOCK")), "0.000"), 1, 10))
                    Filewrite.Write("{0,10}", Mid(Format(Val(dr("ADJUSTEDSTOCK")), "0.000"), 1, 10))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RATE")), "0.00"), 1, 12))
                    Filewrite.WriteLine("{0,12}", Mid(Format(Val(dr("AMOUNT")), "0.00"), 1, 15))
                    pagesize = pagesize + 1
                    dbldocTotal = dbldocTotal + Format(Val(dr("AMOUNT")), "0.00")
                    dblGrandTotal = dblGrandTotal + Format(Val(dr("AMOUNT")), "0.00")
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "."))
                pagesize = pagesize + 1
                Filewrite.Write("{0,-13}{1,-30}{2,-10}{3,-23}", "", "DOC TOTAL =====>", "", "")
                Filewrite.WriteLine("{0,-5}{1,10}{2,10}{3,10}{4,12}{5,12}", "", "", "", "", "", Format(Val(dbldocTotal), "0.00"))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "."))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "="))
                pagesize = pagesize + 1
                Filewrite.Write("{0,-13}{1,-30}{2,-10}{3,-23}", "", "GRAND TOTAL =====>", "", "")
                Filewrite.WriteLine("{0,-5}{1,10}{2,10}{3,10}{4,12}{5,12}", "", "", "", "", "", Format(Val(dblGrandTotal), "0.00"))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(135, "="))
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
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE :" & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(135, "-"))
            pagesize = pagesize + 1
            Filewrite.Write("{0,-13}{1,-18}{2,-12}{3,-10}{4,-23}", "STORE LOC.", "DOC NO.", "DOC DATE", "ITEM CODE", "ITEM NAME")
            Filewrite.WriteLine("{0,-5}{1,10}{2,10}{3,10}{4,12}{5,12}", "UOM", "STOCK IN", "PHYSICAL", "ADJUSTED", "RATE", "AMOUNT")
            pagesize = pagesize + 1
            Filewrite.Write("{0,-13}{1,-18}{2,-12}{3,-10}{4,-23}", "", "", "", "", "")
            Filewrite.WriteLine("{0,-5}{1,10}{2,10}{3,10}{4,12}{5,12}", "", "HAND", "STOCK", "STOCK", "", "")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(135, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
