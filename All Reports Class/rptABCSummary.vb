Imports System.Data.SqlClient
Imports System.io
Public Class rptABCSummary
    Public pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Public Function Reportdetails(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal, DBRATE As Double
        Dim ITEMCODE, DOCDETAILS, GROUPNAME, SUBGROUPNAME, ABCNAME As String
        Dim ITEMBOOL, DOCBOOL As Boolean
        Dim COUNT As Int16
        Dim opval, issval, closeval, rcval, groupvalue, GRPVAL, GAMT As Double
        Dim Topval, Tissval, Tcloseval, Trcval, Tgroupvalue, TGRPVAL, SALEVAL, TGMT As Double
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
            TGRPVAL = 0
            GRPVAL = 0
            TGMT = 0
            GAMT = 0
            COUNT = 0
            Filewrite.Write(Chr(15))
            Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "STOCKSUMMARYREPORT")
            If gdataset.Tables("STOCKSUMMARYREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                GROUPNAME = Trim(gdataset.Tables("stocksummaryreport").Rows(0).Item("GROUPNAME"))
                SUBGROUPNAME = Trim(gdataset.Tables("stocksummaryreport").Rows(0).Item("SUBGROUPNAME"))
                ABCNAME = Trim(gdataset.Tables("stocksummaryreport").Rows(0).Item("ABC"))
                Filewrite.WriteLine()
                'Filewrite.WriteLine(Chr(15) & ABCNAME)
                Filewrite.WriteLine(Chr(15) & ABCNAME & " - CATEGORY ITEMS ")
                Filewrite.WriteLine()
                pagesize = pagesize + 3

                For Each dr In gdataset.Tables("STOCKSUMMARYREPORT").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(77, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If

                    If ABCNAME <> Trim(CStr(dr("ABC"))) Then
                        COUNT = COUNT + 1
                        Filewrite.WriteLine(StrDup(77, "."))
                        'Filewrite.WriteLine("{0,43}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,24}", " TOTAL =======>  ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), " ", Format(groupvalue, "0.00"), Format(GRPVAL, "0.00"))
                        Filewrite.Write(Space(23) & " TOTAL =======>  " & Space(13))

                        'Filewrite.Write(Space(10 - Len(Mid(Format(opval, "0.000"), 1, 10))) & Mid(Format(opval, "0.000"), 1, 10))
                        'Filewrite.Write(Space(10 - Len(Mid(Format(GAMT, "0.000"), 1, 10))) & Mid(Format(GAMT, "0.000"), 1, 10))
                        'Filewrite.Write(Space(10 - Len(Mid(Format(rcval, "0.000"), 1, 10))) & Mid(Format(rcval, "0.000"), 1, 10))
                        'Filewrite.Write(Space(10 - Len(Mid(Format(issval, "0.000"), 1, 10))) & Mid(Format(issval, "0.000"), 1, 10))
                        Filewrite.Write(Space(10 - Len(Mid(Format(closeval, "0.000"), 1, 10))) & Mid(Format(closeval, "0.000"), 1, 10))
                        'Filewrite.WriteLine(Space(8) & Space(12 - Len(Mid(Format(groupvalue, "0.000"), 1, 12))) & Mid(Format(groupvalue, "0.000"), 1, 12))
                        Filewrite.WriteLine(Space(4) & Space(12 - Len(Mid(Format(GRPVAL, "0.000"), 1, 12))) & Mid(Format(GRPVAL, "0.000"), 1, 12))
                        Topval = Topval + opval
                        Tgroupvalue = Tgroupvalue + groupvalue
                        Trcval = Trcval + rcval
                        Tissval = Tissval + issval
                        Tcloseval = Tcloseval + closeval
                        Filewrite.WriteLine(StrDup(77, "."))
                        Filewrite.WriteLine()
                        opval = 0
                        rcval = 0
                        issval = 0
                        closeval = 0
                        groupvalue = 0
                        GRPVAL = 0
                        If COUNT = 1 Then
                            ABCNAME = "B"
                        ElseIf COUNT = 2 Then
                            ABCNAME = "C"
                        End If
                        Filewrite.WriteLine()
                        Filewrite.WriteLine(Chr(15) & ABCNAME & " - CATEGORY ITEMS ")
                        'Filewrite.WriteLine(Chr(15) & GROUPNAME & " - " & SUBGROUPNAME)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 7
                        GROUPNAME = Trim(CStr(dr("GROUPNAME")))
                        SUBGROUPNAME = Trim(CStr(dr("SUBGROUPNAME")))

                    End If
                    Filewrite.Write("{0,-10}", Chr(15) & Mid(Trim(CStr(dr("ITEMCODE"))), 1, 10))
                    Filewrite.Write("{0,-25}", Mid(Trim(CStr(dr("ITEMDESC"))), 1, 25))
                    Filewrite.Write("{0,-6}", Mid(Trim(CStr(dr("UOM"))), 1, 6))
                    Filewrite.Write("{0,8}", Mid(Format(Val(dr("RATE")), "0.00"), 1, 8))
                    'opval = opval + Val(dr("opqty"))
                    'If Val(dr("GAMOUNT")) <> 0 Then
                    '    Filewrite.Write("{0,10}", Mid(Format(Val(dr("GAMOUNT")), "0.000"), 1, 10))
                    'Else
                    '    Filewrite.Write(Space(10))
                    'End If
                    'GAMT = GAMT + dr("GAMOUNT")
                    'TGMT = TGMT + dr("GAMOUNT")
                    'Filewrite.Write("{0,10}", Mid(Format(Val(dr("RCVQTY")), "0.000"), 1, 10))
                    'rcval = rcval + Val(dr("rcvqty"))
                    'Filewrite.Write("{0,10}", Mid(Format(Val(dr("ISSQTY")), "0.000"), 1, 10))
                    'issval = issval + Val(dr("issqty"))
                    Filewrite.Write("{0,15}", Mid(Format(Val(dr("CLSQTY")), "0.000"), 1, 15))
                    closeval = closeval + Val(dr("clsqty"))
                    'Filewrite.Write("{0,8}", Mid(Format(Val(dr("RATE")), "0.00"), 1, 8))
                    'DBRATE = DBRATE + Val(dr("RATE"))
                    'Filewrite.WriteLine("{0,12}", Mid(Format(Val(dr("VALUE")), "0.000"), 1, 12))
                    'Filewrite.Write("{0,8}", Mid(Format(Val(dr("SALERATE")), "0.00"), 1, 8))
                    SALEVAL = Val(dr("RATE")) * Val(dr("CLSQTY"))
                    Filewrite.WriteLine("{0,12}", Mid(Format(Val(SALEVAL), "0.000"), 1, 12))
                    GRPVAL = Val(GRPVAL) + Val(SALEVAL)
                    TGRPVAL = Val(TGRPVAL) + Val(SALEVAL)
                    groupvalue = groupvalue + Val(dr("VALUE"))
                    dblGrandTotal = dblGrandTotal + Format(Val(dr("VALUE")), "0.000")
                    pagesize = pagesize + 1
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(77, "."))
                'Filewrite.WriteLine("{0,43}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), " ", Format(groupvalue, "0.00"))
                'Filewrite.WriteLine("{0,43}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,24}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), " ", Format(groupvalue, "0.00"), Format(GRPVAL, "0.00"))
                Filewrite.Write(Space(23) & " TOTAL =======>  " & Space(13))
                'Filewrite.Write(Space(10 - Len(Mid(Format(opval, "0.000"), 1, 10))) & Mid(Format(opval, "0.000"), 1, 10))
                'Filewrite.Write(Space(10 - Len(Mid(Format(GAMT, "0.000"), 1, 10))) & Mid(Format(GAMT, "0.000"), 1, 10))
                'Filewrite.Write(Space(10 - Len(Mid(Format(rcval, "0.000"), 1, 10))) & Mid(Format(rcval, "0.000"), 1, 10))
                'Filewrite.Write(Space(10 - Len(Mid(Format(issval, "0.000"), 1, 10))) & Mid(Format(issval, "0.000"), 1, 10))
                Filewrite.Write(Space(10 - Len(Mid(Format(closeval, "0.000"), 1, 10))) & Mid(Format(closeval, "0.000"), 1, 10))
                'Filewrite.WriteLine(Space(8) & Space(12 - Len(Mid(Format(groupvalue, "0.000"), 1, 12))) & Mid(Format(groupvalue, "0.000"), 1, 12))
                Filewrite.WriteLine(Space(4) & Space(12 - Len(Mid(Format(GRPVAL, "0.000"), 1, 12))) & Mid(Format(GRPVAL, "0.000"), 1, 12))
                Topval = Topval + opval
                Tgroupvalue = Tgroupvalue + groupvalue
                Trcval = Trcval + rcval
                Tissval = Tissval + issval
                Tcloseval = Tcloseval + closeval
                Filewrite.WriteLine(StrDup(77, "."))
                Filewrite.WriteLine(StrDup(77, "="))
                pagesize = pagesize + 1
                'Filewrite.WriteLine("{0,43}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}", "GRAND TOTAL =======>        ", Format(Topval, "0.000"), Format(Trcval, "0.000"), Format(Tissval, "0.000"), Format(Tcloseval, "0.000"), " ", Format(Tgroupvalue, "0.00"))
                'Filewrite.WriteLine("{0,43}{1,12}{2,12}{3,12}{4,12}{5,12}{6,12}{7,24}", "GRAND TOTAL =======>        ", Format(Topval, "0.000"), Format(Trcval, "0.000"), Format(Tissval, "0.000"), Format(Tcloseval, "0.000"), " ", Format(Tgroupvalue, "0.00"), Format(TGRPVAL, "0.00"))
                Filewrite.Write(Space(27) & " GRAND TOTAL =======>   " & Space(2))
                'Filewrite.Write(Space(10 - Len(Mid(Format(Topval, "0.000"), 1, 10))) & Mid(Format(Topval, "0.000"), 1, 10))
                'Filewrite.Write(Space(10 - Len(Mid(Format(Trcval, "0.000"), 1, 10))) & Mid(Format(Trcval, "0.000"), 1, 10))
                ' Filewrite.Write(Space(10 - Len(Mid(Format(Tissval, "0.000"), 1, 10))) & Mid(Format(Tissval, "0.000"), 1, 10))
                Filewrite.Write(Space(10 - Len(Mid(Format(Tcloseval, "0.000"), 1, 10))) & Mid(Format(Tcloseval, "0.000"), 1, 10))
                'Filewrite.WriteLine(Space(8) & Space(12 - Len(Mid(Format(Tgroupvalue, "0.000"), 1, 12))) & Mid(Format(Tgroupvalue, "0.000"), 1, 12))
                Filewrite.WriteLine(Space(4) & Space(12 - Len(Mid(Format(TGRPVAL, "0.000"), 1, 12))) & Mid(Format(TGRPVAL, "0.000"), 1, 12))
                pagesize = pagesize + 2
                Filewrite.WriteLine(StrDup(77, "="))
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
            Filewrite.WriteLine(Chr(15))
            Filewrite.WriteLine("{0,50}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            pagesize = pagesize + 1
            'Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
            Filewrite.WriteLine("{0,-30}{1,-10}{2,-30}{3,-25}{4,-24}", " ", " ", Mid(Trim(Heading(0)), 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-10}{2,-30}", " ", " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(70) & "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.Write("{0,-30}{1,87}{2,16}", " " & "AS ON" & " " & Format(msktodate, "MMM dd,yyyy"), " ", " ")
            Filewrite.WriteLine(Chr(15))
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(77, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("ITEM   ITEM                        UOM      CLOSING     CLOSING     CLOSING     ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("CODE   DESCRIPTION                 QTY       RATE        QTY         VALUE      ")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(77, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function


End Class
