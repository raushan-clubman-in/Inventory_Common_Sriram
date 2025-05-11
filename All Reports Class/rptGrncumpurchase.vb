Imports System.Data.SqlClient
Imports System.IO
Public Class rptGrncumpurchase
    Dim dr As DataRow
    Dim dc As DataColumn
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim gconnection As New GlobalClass
    Public Function ReportDetails(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim DBLDOCTOTAL, DBLGROUPTOTAL, DBLGRANDTOTAL As Double
        Dim STROEDESC, DOCDETAILS As String
        Dim STOREBOOL, DOCBOOL As Boolean
        Dim I, J, K As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            PrintHeader(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "GRNPURCHASEBILL")
            If gdataset.Tables("GRNPURCHASEBILL").Rows.Count > 0 Then
                For K = 0 To gdataset.Tables("GRNPURCHASEBILL").Rows.Count - 1
                    If pagesize > 56 Then
                        Filewrite.Write(StrDup(135, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If DOCDETAILS <> Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDETAILS"))) Then
                        If DOCBOOL = True Then
                            Filewrite.WriteLine()
                            pagesize = pagesize + 1
                            Filewrite.WriteLine(StrDup(135, "."))
                            pagesize = pagesize + 1
                            Filewrite.Write("{0,-15}{1,-33}{2,-12}{3,-10}", "", "DOC TOTAL =====>", "", "")
                            Filewrite.WriteLine("{0,-25}{1,-5}{2,10}{3,12}{4,12}", "", "", "", "", Format(Val(DBLDOCTOTAL), "0.00"))
                            pagesize = pagesize + 1
                            Filewrite.WriteLine(StrDup(135, "."))
                            pagesize = pagesize + 1
                            Filewrite.Write("{0,-18}", Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDETAILS"))), 1, 18))
                            Filewrite.Write("{0,-12}", Mid(Format(CDate(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDATE")), "dd/MM/yyyy"), 1, 12))
                            Filewrite.Write("{0,-18}", Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERCODE"))), 1, 18))
                            Filewrite.Write("{0,-18}", Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERNAME"))), 1, 18))
                            DOCDETAILS = gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDETAILS")

                            DOCBOOL = True
                            DBLDOCTOTAL = 0
                        Else
                            Filewrite.Write("{0,-18}", Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDETAILS"))), 1, 18))
                            Filewrite.Write("{0,-12}", Mid(Format(CDate(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDATE")), "dd/MM/yyyy"), 1, 12))
                            Filewrite.Write("{0,-18}", Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERCODE"))), 1, 18))
                            Filewrite.Write("{0,-18}", Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERNAME"))), 1, 18))
                            DOCDETAILS = gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDETAILS")
                            DOCBOOL = True
                            DBLDOCTOTAL = 0
                        End If
                    End If
                    Filewrite.Write("{0,-10}", Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ITEMCODE"))), 1, 10))
                    Filewrite.Write("{0,-25}", Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ITEMNAME"))), 1, 25))
                    Filewrite.Write("{0,-5}", Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("UOM"))), 1, 10))
                    Filewrite.Write("{0,10}", Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("QTY")), "0.000"), 1, 10))
                    Filewrite.Write("{0,12}", Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("RATE")), "0.00"), 1, 12))
                    Filewrite.WriteLine("{0,12}", Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("AMOUNT")), "0.00"), 1, 15))
                    pagesize = pagesize + 1
                    DBLDOCTOTAL = DBLDOCTOTAL + Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("AMOUNT")), "0.00")
                    DBLGRANDTOTAL = DBLGRANDTOTAL + Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("AMOUNT")), "0.00")
                Next K
            Else
                MessageBox.Show("NO RECORD TO BE DISPLAYED", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "CHECKLIST")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE :" & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(135, "-"))
            pagesize = pagesize + 1
            Filewrite.Write("{0,-15}{1,-15}{2,-18}{3,-12}{4,-10}", "GRN NO.", "GRN DATE", "SUPPLIER", "SUPPLIER", "")
            Filewrite.WriteLine("{0,-25}{1,-5}{2,10}{3,12}{4,12}", "", "", "", "", "")
            pagesize = pagesize + 1
            Filewrite.Write("{0,-15}{1,-15}{2,-18}{3,-12}{4,-10}", "", "", "CODE", "NAME", "ITEM CODE")
            Filewrite.WriteLine("{0,-25}{1,-5}{2,10}{3,12}{4,12}", "ITEM NAME", "UOM", "QTY", "RATE", "AMOUNT")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(135, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
