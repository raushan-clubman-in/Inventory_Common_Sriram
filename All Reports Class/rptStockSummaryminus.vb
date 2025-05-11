Imports System.Data.SqlClient
Imports System.io
Public Class rptStockSummaryminus
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
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
                        Filewrite.Write(StrDup(126, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If GROUPNAME <> Trim(CStr(dr("GROUPNAME"))) Then
                        GROUPNAME = Trim(CStr(dr("GROUPNAME")))
                        Filewrite.WriteLine(StrDup(126, "."))
                        Filewrite.WriteLine("{0,62}{1,12}{2,12}{3,12}{4,12}{5,12}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), Format(groupvalue, "0.00"))
                        Topval = Topval + opval
                        Tgroupvalue = Tgroupvalue + groupvalue
                        Trcval = Trcval + rcval
                        Tissval = Tissval + issval
                        Tcloseval = Tcloseval + closeval
                        Filewrite.WriteLine(StrDup(126, "."))
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
                    Filewrite.Write("{0,-8}", Chr(15) & Mid(Trim(CStr(dr("storecode"))), 1, 8))
                    Filewrite.Write("{0,-8}", Chr(15) & Mid(Trim(CStr(dr("ITEMCODE"))), 1, 8))
                    Filewrite.Write("{0,-24}", Mid(Trim(CStr(dr("ITEMDESC"))), 1, 24))
                    Filewrite.Write("{0,-10}", Mid(Trim(CStr(dr("UOM"))), 1, 10))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("RATE")), "0.00"), 1, 12))
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
                Filewrite.WriteLine(StrDup(126, "."))
                Filewrite.WriteLine("{0,62}{1,12}{2,12}{3,12}{4,12}{5,12}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), Format(groupvalue, "0.00"))
                Topval = Topval + opval
                Tgroupvalue = Tgroupvalue + groupvalue
                Trcval = Trcval + rcval
                Tissval = Tissval + issval
                Tcloseval = Tcloseval + closeval
                Filewrite.WriteLine(StrDup(126, "."))
                Filewrite.WriteLine(StrDup(126, "="))
                pagesize = pagesize + 1
                Filewrite.WriteLine("{0,62}{1,12}{2,12}{3,12}{4,12}{5,12}", "GRAND TOTAL =======>        ", Format(Topval, "0.000"), Format(Trcval, "0.000"), Format(Tissval, "0.000"), Format(Tcloseval, "0.000"), Format(Tgroupvalue, "0.00"))
                pagesize = pagesize + 2
                Filewrite.WriteLine(StrDup(126, "="))
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
            If MsgBox("Print - Negative Stock", MsgBoxStyle.OKCancel + MsgBoxStyle.DefaultButton2, "Stock Alert") = MsgBoxResult.OK Then
                gPrint = True
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
            Filewrite.WriteLine(Chr(15) & StrDup(126, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-8}{0,-8}{1,-24}{2,-10}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}", Chr(15) & "STORE", "ITEM", "ITEM", "UOM", "RATE", "OPENING", "RECEIVED", "ISSUED", "CLOSING", "VALUE")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-8}{0,-8}{1,-24}{2,-10}{3,12}{4,12}{5,12}{6,12}{7,12}{8,12}", Chr(15) & "CODE", "CODE", "DESCRIPTION", "", "", "QTY", "QTY", "QTY", "QTY", "")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(126, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
