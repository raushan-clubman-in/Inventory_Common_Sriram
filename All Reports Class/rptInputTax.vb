Imports System.Data.SqlClient
Imports System.io
Public Class rptInputtax
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow

    Public Function Reportdetails_SECOND(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dblGroupbillamt, dblGrandbillamt, dblGroupBasicamt, dblGrandBasicamt, dblVATamount As Double
        Dim dblGroupVATamt, dblGrandVATamt, dblGroupOtherchg, dblGrandOtherchg, dblGroupdiscountamt As Double
        Dim dblBasicamount, dblothercharge, dbldiscountamt, dblBillamount, dblGranddiscountamt As Double
        Dim SUPPLIERNAME, GRNDETAILS, SSQL As String
        Dim SUPPLIERNAMEBOOL, GRNBOOL As Boolean
        Dim STRSQL, SQLSTR As String
        Dim TBILLAMOUNT, TTAXAMOUNT As Double
        Dim I, C As Integer
        Dim clsquantity As Double
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            Call PrintHeader_SECOND(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "ROL")
            C = 0
            If gdataset.Tables("ROL").Rows.Count > 0 Then
                For I = 0 To gdataset.Tables("ROL").Rows.Count - 1 Step 1
                    If pagesize > 56 Then
                        Filewrite.Write(StrDup(124, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader_SECOND(PAGEHEAD, FROMDATE, TODATE)
                    End If

                    With gdataset.Tables("ROL").Rows(I)
                        If GRNDETAILS <> Trim(.Item("GRNDETAILS")) Then
                            C = C + 1
                            STRSQL = Space(4 - Len(Mid(Trim(Format(C, "0")), 1, 4))) & Mid(Trim(Format(C, "0")), 1, 4)
                            STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("GRNDETAILS")), 1, 18) & Space(18 - Len(Mid(Trim(.Item("GRNDETAILS")), 1, 18)))
                            STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(.Item("GRNDATE"), "dd/MM/yyyy")), 1, 10))) & Mid(Trim(Format(.Item("GRNDATE"), "dd/MM/yyyy")), 1, 10)
                            STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("CRNAME")), 1, 20) & Space(20 - Len(Mid(Trim(.Item("CRNAME")), 1, 20)))
                            STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("TINNO")), 1, 12) & Space(12 - Len(Mid(Trim(.Item("TINNO")), 1, 12)))
                        Else
                            STRSQL = Space(68)
                        End If
                        STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("ITEMNAME")), 1, 20) & Space(20 - Len(Mid(Trim(.Item("ITEMNAME")), 1, 20)))
                        STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(.Item("BILLAMOUNT"), "0.00")), 1, 10))) & Mid(Trim(Format(.Item("BILLAMOUNT"), "0.00")), 1, 10)
                        STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(.Item("TPER"), "0.00")), 1, 10))) & Mid(Trim(Format(.Item("TPER"), "0.00")), 1, 10)
                        STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(.Item("ACTUALTAXAMOUNT"), "0.00")), 1, 10))) & Mid(Trim(Format(.Item("ACTUALTAXAMOUNT"), "0.00")), 1, 10)
                        GRNDETAILS = Trim(.Item("GRNDETAILS"))
                        TBILLAMOUNT = TBILLAMOUNT + Val(.Item("BILLAMOUNT"))
                        TTAXAMOUNT = TTAXAMOUNT + Val(.Item("ACTUALTAXAMOUNT"))

                        Filewrite.WriteLine(STRSQL)
                        pagesize = pagesize + 1
                        If pagesize > 54 Then
                            Filewrite.Write(StrDup(124, "-"))
                            Filewrite.Write(Chr(12))
                            pageno = pageno + 1
                            Call PrintHeader_SECOND(PAGEHEAD, FROMDATE, TODATE)
                        End If
                    End With
                Next
                Filewrite.WriteLine(StrDup(124, "."))
                STRSQL = Space(90) & Space(10 - Len(Mid(Trim(Format(TBILLAMOUNT, "0.00")), 1, 10))) & Mid(Trim(Format(TBILLAMOUNT, "0.00")), 1, 10)
                STRSQL = STRSQL & Space(11)
                STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(TTAXAMOUNT, "0.00")), 1, 10))) & Mid(Trim(Format(TTAXAMOUNT, "0.00")), 1, 10)
                Filewrite.WriteLine(STRSQL)
                Filewrite.WriteLine(StrDup(124, "."))
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

    Private Function PrintHeader_SECOND(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
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
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,57}{1,-10}", " ", "INPUT VAT REPORT")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE :" & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(124, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO  GRN NO/Date                   Supplier Name        TIN No       Item Name                Amount        %      Vat Amt")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(124, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Public Function Reportdetails(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dblGroupbillamt, dblGrandbillamt, dblGroupBasicamt, dblGrandBasicamt, dblVATamount As Double
        Dim dblGroupVATamt, dblGrandVATamt, dblGroupOtherchg, dblGrandOtherchg, dblGroupdiscountamt As Double
        Dim dblBasicamount, dblothercharge, dbldiscountamt, dblBillamount, dblGranddiscountamt As Double
        Dim SUPPLIERNAME, GRNDETAILS, SSQL As String
        Dim SUPPLIERNAMEBOOL, GRNBOOL As Boolean
        Dim STRSQL, SQLSTR As String
        Dim TBILLAMOUNT, TTAXAMOUNT, TTOTALAMOUNT As Double
        Dim I As Integer
        Dim clsquantity As Double
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
            gconnection.getDataSet(SQLSTRING, "ROL")
            If gdataset.Tables("ROL").Rows.Count > 0 Then
                For I = 0 To gdataset.Tables("ROL").Rows.Count - 1 Step 1
                    If pagesize > 56 Then
                        Filewrite.Write(StrDup(175, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                    End If
                    With gdataset.Tables("ROL").Rows(I)
                        STRSQL = Space(4 - Len(Mid(Trim(Format(I + 1, "0")), 1, 4))) & Mid(Trim(Format(I + 1, "0")), 1, 4)
                        STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("GRNDETAILS")), 1, 18) & Space(18 - Len(Mid(Trim(.Item("GRNDETAILS")), 1, 18)))
                        STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(.Item("GRNDATE"), "dd/MM/yyyy")), 1, 10))) & Mid(Trim(Format(.Item("GRNDATE"), "dd/MM/yyyy")), 1, 10)
                        STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("BILLDETAILS")), 1, 15) & Space(15 - Len(Mid(Trim(.Item("BILLDETAILS")), 1, 15)))
                        STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("TINNO")), 1, 15) & Space(15 - Len(Mid(Trim(.Item("TINNO")), 1, 15)))
                        STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(.Item("BILLDATE"), "dd/MM/yyyy")), 1, 10))) & Mid(Trim(Format(.Item("BILLDATE"), "dd/MM/yyyy")), 1, 10)
                        '  STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("CRCODE")), 1, 5) & Space(5 - Len(Mid(Trim(.Item("CRCODE")), 1, 5)))
                        STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("CRNAME")), 1, 26) & Space(26 - Len(Mid(Trim(.Item("CRNAME")), 1, 26)))
                        'STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("DRCODE")), 1, 5) & Space(5 - Len(Mid(Trim(.Item("DRCODE")), 1, 5)))
                        'STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("DRNAME")), 1, 26) & Space(26 - Len(Mid(Trim(.Item("DRNAME")), 1, 26)))
                        STRSQL = STRSQL & Space(1) & Mid(Trim(.Item("ITEMNAME")), 1, 26) & Space(26 - Len(Mid(Trim(.Item("ITEMNAME")), 1, 26)))

                        STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(.Item("TOTALAMOUNT"), "0.00")), 1, 10))) & Mid(Trim(Format(.Item("TOTALAMOUNT"), "0.00")), 1, 10)
                        STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(.Item("TPER"), "0.00")), 1, 10))) & Mid(Trim(Format(.Item("TPER"), "0.00")), 1, 10)
                        STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(.Item("TAMT"), "0.00")), 1, 10))) & Mid(Trim(Format(.Item("TAMT"), "0.00")), 1, 10)
                        STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(.Item("BILLAMOUNT"), "0.00")), 1, 10))) & Mid(Trim(Format(.Item("BILLAMOUNT"), "0.00")), 1, 10)

                        TBILLAMOUNT = TBILLAMOUNT + Val(.Item("BILLAMOUNT"))
                        TTAXAMOUNT = TTAXAMOUNT + Val(.Item("TAMT"))
                        TTOTALAMOUNT = TTOTALAMOUNT + Val(.Item("TOTALAMOUNT"))

                        Filewrite.WriteLine(STRSQL)
                        pagesize = pagesize + 1
                        If pagesize > 54 Then
                            Filewrite.Write(StrDup(175, "-"))
                            Filewrite.Write(Chr(12))
                            pageno = pageno + 1
                            Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        End If
                    End With
                Next
                Filewrite.WriteLine(StrDup(175, "."))
                STRSQL = Space(132) & Space(10 - Len(Mid(Trim(Format(TTOTALAMOUNT, "0.00")), 1, 10))) & Mid(Trim(Format(TTOTALAMOUNT, "0.00")), 1, 10)
                STRSQL = STRSQL & Space(11)
                STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(TTAXAMOUNT, "0.00")), 1, 10))) & Mid(Trim(Format(TTAXAMOUNT, "0.00")), 1, 10)
                STRSQL = STRSQL & Space(1) & Space(10 - Len(Mid(Trim(Format(TBILLAMOUNT, "0.00")), 1, 10))) & Mid(Trim(Format(TBILLAMOUNT, "0.00")), 1, 10)
                Filewrite.WriteLine(STRSQL)
                Filewrite.WriteLine(StrDup(175, "."))
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
            Filewrite.WriteLine("{0,57}{1,-10}", " ", "INPUT VAT REPORT")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE :" & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(175, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO  GRN NO/Date                   Bill No/Date    TIN No.                    Credit A/c Head            Item Name                    Turnover      VAT %    Vat Amt        Net  ")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(175, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class
