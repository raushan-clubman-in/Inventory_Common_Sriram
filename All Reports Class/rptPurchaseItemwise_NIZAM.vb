Imports System.Data.SqlClient
Imports System.io
Public Class rptPurchaseItemwise_NIZAM
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Public Function Reportdetails(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dblGrandTotal, dblITEMTotal As Double
        Dim dblTAXGrandTotal, dblTAXITEMTotal As Double
        Dim dblqtyGrandTotal, dblqtyITEMTotal As Double
        Dim dblactutalTAXITEMTotal, dblACTUALTAXGrandTotal As Double

        Dim c As Integer
        Dim SUPPLIERNAME As String
        Dim itemcode As String
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
                For Each dr In gdataset.Tables("PURCHASEREGISTERSUMMARYREPORT").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(Chr(12))
                        Filewrite.Write(StrDup(115, "-"))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If itemcode <> Trim(CStr(dr("ITEMCODE"))) And c > 0 Then
                        Filewrite.WriteLine(StrDup(115, "="))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine("{0,-18}{1,-12}{2,-22}{3,-12}{4,-8}{5,12}{6,12}{7,12}", "ITEM TOTAL=====>", Mid(Trim(CStr(dr("ITEMCODE"))), 1, 12), "", Mid(Format(Val(dblqtyITEMTotal), "0.000"), 1, 12), "", Mid(Format(Val(dblITEMTotal), "0.00"), 1, 12), Mid(Format(Val(dblTAXITEMTotal), "0.00"), 1, 12), Mid(Format(Val(dblactutalTAXITEMTotal), "0.00"), 1, 12))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine(StrDup(115, "="))
                        dblITEMTotal = 0
                        dblTAXITEMTotal = 0
                        dblqtyITEMTotal = 0
                        dblactutalTAXITEMTotal = 0
                        c = 0
                    End If
                    c = c + 1

                    Filewrite.Write("{0,-5}", Mid(Format(Val(c), "0"), 1, 4))
                    If itemcode <> Trim(CStr(dr("ITEMCODE"))) Then
                        Filewrite.Write("{0,-30}", Mid(Trim(CStr(dr("ITEMNAME"))), 1, 30))
                    Else
                        Filewrite.Write("{0,-30}", " ")
                    End If
                    Filewrite.Write("{0,-12}", Mid(Format(CDate(dr("GRNDATE")), "dd/MM/yyyy"), 1, 12))
                    Filewrite.Write("{0,11}", Mid(Format(Val(dr("QTY")), "0.000"), 1, 10))
                    Filewrite.Write("{0,13}", Mid(Format(Val(dr("RATE")), "0.00"), 1, 12))
                    Filewrite.Write("{0,13}", Mid(Format(Val(dr("AMOUNT")), "0.00"), 1, 12))
                    Filewrite.Write("{0,13}", Mid(Format(Val(dr("TAXAMOUNT")), "0.00"), 1, 12))
                    Filewrite.WriteLine("{0,13}", Mid(Format(Val(dr("ACTUALTAXAMOUNT")), "0.00"), 1, 12))

                    pagesize = pagesize + 1

                    dblGrandTotal = dblGrandTotal + Format(Val(dr("AMOUNT")), "0.00")
                    dblITEMTotal = dblITEMTotal + Format(Val(dr("AMOUNT")), "0.00")

                    dblTAXGrandTotal = dblTAXGrandTotal + Format(Val(dr("TAXAMOUNT")), "0.00")
                    dblTAXITEMTotal = dblTAXITEMTotal + Format(Val(dr("TAXAMOUNT")), "0.00")

                    dblACTUALTAXGrandTotal = dblACTUALTAXGrandTotal + Format(Val(dr("ACTUALTAXAMOUNT")), "0.00")
                    dblactutalTAXITEMTotal = dblactutalTAXITEMTotal + Format(Val(dr("ACTUALTAXAMOUNT")), "0.00")

                    dblqtyGrandTotal = dblqtyGrandTotal + Format(Val(dr("QTY")), "0.000")
                    dblqtyITEMTotal = dblqtyITEMTotal + Format(Val(dr("QTY")), "0.000")

                    itemcode = Trim(CStr(dr("ITEMCODE")))
                Next dr

                Filewrite.WriteLine(StrDup(115, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-18}{1,-12}{2,-22}{3,-12}{4,-8}{5,12}{6,12}{7,12}", "ITEM TOTAL=====>", Mid(Trim(CStr(dr("ITEMCODE"))), 1, 12), "", Mid(Format(Val(dblqtyITEMTotal), "0.000"), 1, 12), "", Mid(Format(Val(dblITEMTotal), "0.00"), 1, 12), Mid(Format(Val(dblTAXITEMTotal), "0.00"), 1, 12), Mid(Format(Val(dblactutalTAXITEMTotal), "0.00"), 1, 12))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(115, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-18}{1,-12}{2,-22}{3,-12}{4,-8}{5,12}{6,12}{7,12}", "GRAND TOTAL====>", "", Mid(Format(Val(dblqtyGrandTotal), "0.000"), 1, 12), "", Mid(Format(Val(dblGrandTotal), "0.00"), 1, 12), "", Mid(Format(Val(dblTAXGrandTotal), "0.00"), 1, 12), Mid(Format(Val(dblACTUALTAXGrandTotal), "0.00"), 1, 12))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(115, "="))
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
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE :" & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(115, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO  ITEM DESCRIPTION                 DATE            QTY          RATE      AMOUNT    TAX AMOUNT    MASTER TAX")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(115, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
