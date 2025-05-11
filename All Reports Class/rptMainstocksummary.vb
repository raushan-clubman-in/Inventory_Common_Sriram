Imports System.Data.SqlClient
Imports System.io
Public Class rptMainstocksummary
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Public Function Reportdetails(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal As Double
        Dim ITEMCODE, DOCDETAILS As String
        Dim ITEMBOOL, DOCBOOL As Boolean
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
            gconnection.getDataSet(SQLSTRING, "MAINSTOCKSUMMARY")
            If gdataset.Tables("MAINSTOCKSUMMARY").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                For Each dr In gdataset.Tables("MAINSTOCKSUMMARY").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(155, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If ITEMCODE <> Trim(CStr(dr("ITEMCODE"))) Then
                        Filewrite.Write("{0,-6}", Mid(Trim(CStr(dr("ITEMCODE"))), 1, 5))
                        Filewrite.Write("{0,-20}", Mid(Trim(CStr(dr("ITEMNAME"))), 1, 20))
                        Filewrite.Write("{0,-6}", Mid(Trim(CStr(dr("UOM"))), 1, 5))
                        Filewrite.Write("{0,-8}", Mid(Format(Val(dr("OPQTY")), "0.000"), 1, 8))
                        Filewrite.Write("{0,10}", Mid(Format(Val(dr("OPRATE")), "0.00"), 1, 10))
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPVAL")), "0.00"), 1, 12))
                        Filewrite.Write("{0,-1}", "")

                        Filewrite.Write("{0,-8}", Mid(Format(Val(dr("RCVQTY")), "0.000"), 1, 8))
                        Filewrite.Write("{0,10}", Mid(Format(Val(dr("RCVRATE")), "0.00"), 1, 10))
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVVAL")), "0.00"), 1, 12))
                        Filewrite.Write("{0,-1}", "")

                        Filewrite.Write("{0,-8}", Mid(Format(Val(dr("ISSQTY")), "0.000"), 1, 8))
                        Filewrite.Write("{0,10}", Mid(Format(Val(dr("ISSRATE")), "0.00"), 1, 10))
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSVAL")), "0.00"), 1, 12))
                        Filewrite.Write("{0,-1}", "")

                        Filewrite.Write("{0,-8}", Mid(Format(Val(dr("CLSQTY")), "0.000"), 1, 8))
                        Filewrite.Write("{0,10}", Mid(Format(Val(dr("CLSRATE")), "0.00"), 1, 10))
                        Filewrite.WriteLine("{0,13}", Mid(Format(Val(dr("CLSVAL")), "0.00"), 1, 12))
                        pagesize = pagesize + 1
                    End If
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(155, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,-50}{1,-35}{2,-20}{3,12}{4,15}", "", "GRAND TOTAL =====>", "", "", Format(Val(dblGrandTotal), "0.00"))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(155, "="))
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
            Filewrite.WriteLine("{0,-30}{1,105}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-35}{2,-30}{3,-36}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-35}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,68}{1,-10}", " ", "SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,145}{1,-10}", " ", "PAGE :" & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,107}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(155, "-"))
            pagesize = pagesize + 1
            Filewrite.Write("{0,-6}{1,-20}{2,-6}{3,-31}", "ITEM", "ITEM NAME", "UOM", "            OPENING      ")
            Filewrite.WriteLine("{0,-31}{1,-31}{2,-31}", "            RECEIPT      ", "            ISSUE      ", "            CLOSING      ")
            pagesize = pagesize + 1
            Filewrite.Write("{0,-6}{1,-20}{2,-6}{3,-31}", "CODE", "", "", "QUANTITY      RATE       VALUE")
            Filewrite.WriteLine("{0,-31}{1,-31}{2,-31}", "QUANTITY      RATE       VALUE", "QUANTITY      RATE       VALUE", "QUANTITY      RATE       VALUE")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(155, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
