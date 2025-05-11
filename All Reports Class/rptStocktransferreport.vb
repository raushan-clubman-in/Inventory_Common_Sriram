Imports System.Data.SqlClient
Imports System.IO
Public Class rptStockTransferreport
    Dim dr As DataRow
    Dim dc As DataColumn
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim gconnection As New GlobalClass
    Public Function Reportdetails(ByVal sqlstring As String, ByVal pageheading() As String, ByVal columnheading() As String, ByVal colsize() As Integer)
        Dim x, docno, printline As String
        Dim I As Integer
        Dim booldocno As Boolean
        Dim total(10) As Double
        Dim vsubheader() As String = {"DOC NO. : ", "DOC DATE : ", "FROM STORE CODE : ", "FROM STORE NAME : ", "TO STORE CODE  : ", "TO STORE NAME :"}
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            gconnection.getDataSet(sqlstring, "Stockissuereport")
            Call Print_Headers(pageheading)
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            For Each dr In gdataset.Tables("Stockissuereport").Rows
                If pagesize > 55 Then
                    For I = 0 To 123
                        Filewrite.Write("-")
                    Next
                    Filewrite.Write(Chr(12))
                    pageno = pageno + 1
                    Call Print_Headers(pageheading)
                End If
                If docno <> dr("docdetails") Then
                    If booldocno = True Then
                        For I = 0 To 5
                            Filewrite.WriteLine("")
                            pagesize = pagesize + 1
                        Next I
                        For I = 0 To 123
                            Filewrite.Write("-")
                        Next I
                    End If
                    Filewrite.WriteLine()
                    pagesize = pagesize + 1
                    printline = ""
                    printline = Space(8) & vsubheader(0) & Trim(dr("docdetails"))
                    printline = printline & Space(80 - (Trim(dr("docdetails")).Length + Len(vsubheader(0))))
                    printline = printline & vsubheader(1) & Trim(Format(dr("docdate"), "dd-MM-yyyy"))
                    Filewrite.WriteLine(printline)
                    pagesize = pagesize + 1
                    Filewrite.WriteLine()
                    pagesize = pagesize + 1

                    printline = vsubheader(2) & Trim(dr("FROMSTORECODE"))
                    printline = printline & Space(80 - (Trim(dr("FROMSTORECODE")).Length + Len(vsubheader(2))))
                    printline = printline & Space(1) & vsubheader(3) & Trim(dr("FROMSTOREdesc"))
                    Filewrite.WriteLine(printline)
                    pagesize = pagesize + 1
                    Filewrite.WriteLine()
                    pagesize = pagesize + 1

                    printline = Space(1) & vsubheader(4) & Trim(dr("TOSTORECODE"))
                    printline = printline & Space(82 - (Trim(dr("TOSTORECODE")).Length + Len(vsubheader(4))))
                    printline = printline & vsubheader(5)
                    printline = printline & Trim(dr("TOSTOREdesc"))
                    'printline = printline & Trim(dr("TOSTOREdesc"))
                    Filewrite.WriteLine(printline)
                    pagesize = pagesize + 1
                    Filewrite.WriteLine()
                    pagesize = pagesize + 1

                    docno = Trim(dr("docdetails"))
                    Call Print_Columnheaders(columnheading, colsize)
                    booldocno = True
                End If
                printline = Mid(Trim(dr("Itemcode")), 1, 12) & Space(colsize(0) - Trim(dr("Itemcode")).Length)
                printline = printline & Mid(Trim(dr("Itemname")), 1, 39) & Space(colsize(1) - Trim(dr("Itemname")).Length)
                printline = printline & Mid(Trim(dr("UOM")), 1, 8) & Space(colsize(2) - Mid(Trim(dr("UOM")), 1, 8).Length)
                printline = printline & Space(colsize(3) - Len(Trim(Format(dr("Qty"), "0.000"))) - 2) & Mid(Trim(Format(dr("Qty"), "0.000")), 1, 10) & Space(2)
                total(0) = total(0) + Trim(dr("Qty"))
                printline = printline & Space(colsize(4) - Len(Trim(Format(dr("Rate"), "0.00"))) - 2) & Mid(Trim(Format(dr("Rate"), "0.00")), 1, 10) & Space(2)
                total(1) = total(1) + Trim(dr("Rate"))
                printline = printline & Space(colsize(5) - Len(Trim(Format(dr("Amount"), "0.00"))) - 2) & Mid(Trim(Format(dr("Amount"), "0.00")), 1, 10) & Space(2)
                total(2) = total(2) + Trim(dr("Amount"))
                Filewrite.WriteLine(printline)
                pagesize = pagesize + 1
            Next dr
            For I = 0 To 5
                Filewrite.WriteLine("")
                pagesize = pagesize + 1
            Next I
            Call Print_Grandtotals("GRAND TOTAL ===>", colsize, total)
            Filewrite.WriteLine(Space(0) & " Remarks:" & Trim(dr("remarks")))
            If pagesize < 50 Then
                Dim A As Integer
                For A = 1 To 50 - pagesize
                    Filewrite.WriteLine()
                Next
            End If

            If (Trim(dr("FROMSTORECODE")) = "GDN" Or Trim(dr("TOSTORECODE")) = "GDN") And Trim(dr("UPDFOOTER")) <> "" Then
                'Filewrite.WriteLine(Chr(27) & "E" & " Indent By         			Supervisor          		Initials of Issues         			Received by " & Chr(27) & "F")
                Filewrite.WriteLine(Space(2) & Trim(dr("UPDFOOTER")))
                Filewrite.Write(Chr(12))
            Else
                Filewrite.WriteLine(Chr(27) & "E" & " Prepared By         			Supervisor          		Initials of Issues         			Received by " & Chr(27) & "F")
                Filewrite.Write(Chr(12))
            End If

            'Filewrite.WriteLine(Chr(27) & "E" & " Prepared By         			Supervisor          		Initials of Issues         			Received by " & Chr(27) & "F")
            'Filewrite.Write(Chr(12))
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
    Private Function Print_Headers(ByVal pageheading() As String)
        Dim I, COLUMNCOUNT As Integer
        Dim CHECKEDITEMSNO As Integer
        'Dim Vheader() As String = {"THE HINDUSTHAN CLUB", "4/1,SARAT BOSE ROAD,", "KOLKATA-700020"}
        Dim Vheader() As String = {MyCompanyName, Address1, Address2}
        Dim head As String = "STORE TRANSFER/RETURN"
        Dim x As String
        pagesize = 0
        Try
            Filewrite.WriteLine(Chr(27) & "E" & Chr(15) & Space(61 - Len(Trim(Vheader(0))) / 2) & Vheader(0))
            pagesize = pagesize + 1
            'For Addresss ********
            'Filewrite.Write(Space((123 - (Len(Vheader(1)))) / 2))
            'Filewrite.WriteLine(Vheader(1))
            'pagesize = pagesize + 1
            'Filewrite.Write(Space((123 - (Len(Vheader(2)))) / 2))
            'Filewrite.WriteLine(Vheader(2))
            'pagesize = pagesize + 1
            Filewrite.Write(Space((127 - (Len(head))) / 2))
            Filewrite.WriteLine(head)
            pagesize = pagesize + 1
            ''For I = 0 To head.Length
            ''    Filewrite.Write("-")
            ''Next
            ''Filewrite.WriteLine()
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Private Function Print_Columnheaders(ByVal columnheading() As String, ByVal colsize() As Integer)
        Dim x As String
        Dim i As Integer
        i = 0
        For i = 0 To 123
            Filewrite.Write("-")
        Next
        Filewrite.WriteLine()
        pagesize = pagesize + 1
        i = 0
        For Each x In columnheading
            Filewrite.Write(x)
            If columnheading(i) = "QUANTITY" Then
                Filewrite.Write(Space(4))
                Filewrite.Write(Space(colsize(i) - Len(x)))

            Else
                Filewrite.Write(Space(colsize(i) - Len(x)))
            End If
            i = i + 1
        Next
        Filewrite.WriteLine()
        pagesize = pagesize + 1
        For i = 0 To 123
            Filewrite.Write("-")
        Next
        Filewrite.WriteLine()
        pagesize = pagesize + 1
    End Function
    Private Function Print_Grandtotals(ByVal captot As String, ByVal colsize() As Integer, ByVal total() As Double)
        Dim x, y As String
        Dim bool As Boolean
        Dim i, j As Integer
        i = 0
        For i = 0 To 123
            Filewrite.Write("-")
        Next
        Filewrite.WriteLine()
        pagesize = pagesize + 1
        Filewrite.Write(Trim(captot))
        Filewrite.Write(Space((colsize(0) + colsize(1) + colsize(2)) - (Len(Trim(captot)))))
        Filewrite.Write(Space(colsize(3) - Len(Trim(Format(total(0), "0.000"))) - 2))
        Filewrite.Write(Format(total(0), "0.00"))
        Filewrite.Write(Space(3))
        Filewrite.Write(Space(0))

        Filewrite.Write(Space(colsize(4) - Len(Trim(Format(total(1), "0.00"))) - 2))
        Filewrite.Write(Format(total(1), "0.00"))
        Filewrite.Write(Space(2))
        Filewrite.Write(Space(0))

        Filewrite.Write(Space(colsize(5) - Len(Trim(Format(total(2), "0.00"))) - 2))
        Filewrite.Write(Format(total(2), "0.00"))
        Filewrite.Write(Space(2))

        Filewrite.WriteLine()
        pagesize = pagesize + 1
        For i = 0 To 123
            Filewrite.Write("-")
        Next
        Filewrite.WriteLine()
        pagesize = pagesize + 1
    End Function
End Class
