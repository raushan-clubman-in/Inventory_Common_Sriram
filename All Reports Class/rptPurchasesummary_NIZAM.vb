Imports System.Data.SqlClient
Imports System.io
Public Class rptPurchasesummary_NIZAM
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Public Function Reportdetails(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dblGrandTotal, dblBasicTotal, dblVATTotal, dblOtherTotal, dblDiscountTotal As Double

        Dim dblDayTotal As Double
        Dim c As Integer
        Dim SUPPLIERNAME As String
        Dim GRNDATE As Date
        Dim SUPPLIERNAMEBOOL, GRNBOOL As Boolean
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
            c = 0
            gconnection.getDataSet(SQLSTRING, "PURCHASEREGISTERSUMMARYREPORT")
            If gdataset.Tables("PURCHASEREGISTERSUMMARYREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine("{0,-12}", Mid(Format(CDate(gdataset.Tables("PURCHASEREGISTERSUMMARYREPORT").Rows(0).Item("GRNDATE")), "dd/MM/yyyy"), 1, 12))
                pagesize = pagesize + 1
                For Each dr In gdataset.Tables("PURCHASEREGISTERSUMMARYREPORT").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(130, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If GRNDATE <> CDate(dr("GRNDATE")) And c > 0 Then
                        Filewrite.WriteLine(StrDup(130, "="))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-18}{1,-12}{2,-9}{3,-79}{4,12}", "DAY TOTAL =====>", Mid(Format(CDate(GRNDATE), "dd/MM/yyyy"), 1, 12), "", "", Mid(Format(Val(dblDayTotal), "0.00"), 1, 12))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine(StrDup(130, "="))
                        Filewrite.WriteLine("{0,-12}", Mid(Format(CDate(dr("GRNDATE")), "dd/MM/yyyy"), 1, 12))
                        pagesize = pagesize + 1
                        dblDayTotal = 0
                    End If
                    Filewrite.Write("{0,-18}", Mid(Trim(CStr(dr("GRNDETAILS"))), 1, 18))
                    Filewrite.Write("{0,-18}", Mid(Trim(CStr(dr("supplierinvno"))), 1, 18))
                    Filewrite.Write("{0,-12}", Mid(Format(CDate(dr("supplierdate")), "dd/MM/yyyy"), 1, 12))
                    Filewrite.Write("{0,-40}", Mid(Trim(CStr(dr("SUPPLIERNAME"))), 1, 40))
                    Filewrite.Write("{0,-27}", Mid(Trim(CStr(dr("glaccountname"))), 1, 27))
                    Filewrite.WriteLine("{0,15}", Mid(Format(Val(dr("BILLAMOUNT")), "0.00"), 1, 12))
                    pagesize = pagesize + 1

                    dblGrandTotal = dblGrandTotal + Format(Val(dr("BILLAMOUNT")), "0.00")
                    dblDayTotal = dblDayTotal + Format(Val(dr("BILLAMOUNT")), "0.00")
                    c = c + 1
                    GRNDATE = CDate(dr("GRNDATE"))
                Next dr
                Filewrite.WriteLine(StrDup(130, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-18}{1,-12}{2,-9}{3,-79}{4,12}", "DAY TOTAL =====>", Mid(Format(CDate(GRNDATE), "dd/MM/yyyy"), 1, 12), "", "", Mid(Format(Val(dblDayTotal), "0.00"), 1, 12))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(130, "="))

                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-18}{1,-12}{2,-9}{3,-79}{4,12}", "GRAND TOTAL =====>", "", "", "", Mid(Format(Val(dblGrandTotal), "0.00"), 1, 12))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(130, "="))
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
            '            Filewrite.WriteLine("{0,62}{1,-10}", " ", "SUMMARY")
            '            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE :" & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(130, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("GRN NO            INV./DC/BILL NO.    DATE      SUPPLIER NAME                           GL ACCOUNT NAME                BILL AMOUNT")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(130, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
