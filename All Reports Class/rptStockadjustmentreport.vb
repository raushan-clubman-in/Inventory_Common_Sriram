Imports System.Data.SqlClient
Imports System.IO
Public Class rptStockadjustmentreport
    Dim dr As DataRow
    Dim dc As DataColumn
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim gconnection As New GlobalClass
    Public Function ReportDetails(ByVal sqlstring As String, ByVal pageheading() As String, ByVal columnheading() As String, ByVal colsize() As Integer)
        Dim x As String
        Dim I As Integer
        Dim total(10) As Double
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Filewrite.Write(Chr(15))
            gconnection.getDataSet(sqlstring, "Stockadjustmentreport")
            Call Print_Headers(pageheading)
            Call Print_Columnheaders(columnheading, colsize)
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            For Each dr In gdataset.Tables("Stockadjustmentreport").Rows
                If pagesize > 55 Then
                    For I = 0 To 123
                        Filewrite.Write("-")
                    Next
                    Filewrite.Write(Chr(12))
                    pageno = pageno + 1
                    Call Print_Headers(pageheading)
                    Call Print_Columnheaders(columnheading, colsize)
                End If

                Filewrite.Write(Mid(Trim(dr("Itemcode")), 1, 15))
                Filewrite.Write(Space(colsize(0) - Len(Mid(Trim(dr("Itemcode")), 1, 15))))

                Filewrite.Write(Mid(Trim(dr("Itemname")), 1, 30))
                Filewrite.Write(Space(colsize(1) - Len(Mid(Trim(dr("Itemname")), 1, 30))))

                Filewrite.Write(Mid(Trim(dr("UOM")), 1, 12))
                Filewrite.Write(Space(colsize(2) - Len(Mid(Trim(dr("UOM")), 1, 12))))

                Filewrite.Write(Space(colsize(3) - Len(Mid(Trim(Format(dr("stockinhand"), "0.000")), 1, 16) - 2)))
                Filewrite.Write(Mid(Trim(Format(dr("stockinhand"), "0.000")), 1, 16))
                Filewrite.Write(Space(2))
                total(0) = total(0) + Trim(dr("stockinhand"))

                Filewrite.Write(Space(colsize(4) - Len(Mid(Trim(Format(dr("physicalstock"), "0.000")), 1, 16)) - 2))
                Filewrite.Write(Mid(Trim(Format(dr("physicalstock"), "0.000")), 1, 16))
                Filewrite.Write(Space(2))

                Filewrite.Write(Space(colsize(5) - Len(Mid(Trim(Format(dr("adjustedstock"), "0.000")), 1, 16)) - 2))
                Filewrite.Write(Mid(Trim(Format(dr("adjustedstock"), "0.000")), 1, 16))
                Filewrite.Write(Space(2))

                Filewrite.Write(Space(colsize(6) - Len(Mid(Trim(Format(dr("Rate"), "0.00")), 1, 10)) - 2))
                Filewrite.Write(Mid(Trim(Format(dr("Rate"), "0.00")), 1, 10))
                Filewrite.Write(Space(2))
                total(1) = total(1) + Trim(dr("Rate"))

                Filewrite.Write(Space(colsize(7) - Len(Mid(Trim(Format(dr("Amount"), "0.00")), 1, 10)) - 2))
                Filewrite.Write(Mid(Trim(Format(dr("Amount"), "0.00")), 1, 10))
                Filewrite.Write(Space(2))
                total(2) = total(2) + Trim(dr("Amount"))

                Filewrite.WriteLine()
                pagesize = pagesize + 1
            Next
            Print_Grandtotals("GRAND TOTAL ===>", colsize, total)
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
    Private Function Print_Headers(ByVal pageheading() As String)
        'Dim I, COLUMNCOUNT As Integer
        'Dim CHECKEDITEMSNO As Integer
        'Dim Vheader() As String = {"THE CALCUTTA SWIMMING CLUB", "1, STRAND ROAD", "KOLKATA -700001"}
        'Dim vsubheader() As String = {"DOC NO. : ", "DOC DATE : ", "MAIN STORE CODE : ", "MAIN STORE NAME : ", "TO STORE CODE  : ", "TO STORE NAME :"}
        'Dim head As String = "STOCK ISSUE TO BAR"
        'Dim x As String
        'pagesize = 0
        'Try
        '    Filewrite.Write(Space((123 - (Len(Vheader(0)))) / 2))
        '    Filewrite.WriteLine(Vheader(0))
        '    pagesize = pagesize + 1
        '    Filewrite.Write(Space((123 - (Len(Vheader(1)))) / 2))
        '    Filewrite.WriteLine(Vheader(1))
        '    pagesize = pagesize + 1
        '    Filewrite.Write(Space((123 - (Len(Vheader(2)))) / 2))
        '    Filewrite.WriteLine(Vheader(2))
        '    pagesize = pagesize + 1
        '    Filewrite.Write(Space((123 - (Len(head))) / 2))
        '    Filewrite.WriteLine(head)
        '    pagesize = pagesize + 1
        '    Filewrite.Write(Space((123 - (Len(head))) / 2))
        '    For I = 0 To head.Length
        '        Filewrite.Write("-")
        '    Next
        '    Filewrite.WriteLine()
        '    If gdataset.Tables("Report_tables").Rows.Count > 0 Then
        '        With gdataset.Tables("Report_tables").Rows(0)
        '            Filewrite.Write(vsubheader(0))
        '            Filewrite.Write(Trim(.Item("docdetails")))
        '            Filewrite.Write(Space(80 - (Trim(.Item("docdetails")).Length + Len(vsubheader(0)))))
        '            Filewrite.Write(vsubheader(1))
        '            Filewrite.WriteLine(Trim(Format(.Item("docdate"), "dd-MM-yyyy")))
        '            pagesize = pagesize + 1
        '            Filewrite.WriteLine()
        '            pagesize = pagesize + 1

        '            Filewrite.Write(vsubheader(2))
        '            Filewrite.Write(Trim(.Item("storelocationcode")))
        '            Filewrite.Write(Space(80 - (Trim(.Item("storelocationcode")).Length + Len(vsubheader(2)))))
        '            Filewrite.Write(vsubheader(3))
        '            Filewrite.WriteLine(Trim(.Item("storelocationdesc")))
        '            pagesize = pagesize + 1

        '        End With
        '    End If
        '    Filewrite.WriteLine()
        'Catch ex As Exception
        '    Exit Function
        'End Try

        Dim I, COLUMNCOUNT As Integer
        Dim CHECKEDITEMSNO As Integer
        'Dim Vheader() As String = {"THE HINDUSTHAN CLUB", "4/1,SARAT BOSE ROAD,", "KOLKATA-700020"}
        Dim Vheader() As String = {MyCompanyName, Address1, Address2}
        Dim head As String = "STOCK ADJUSTMENT"
        Dim x As String
        pagesize = 0
        Try
            Filewrite.Write(Space(10))
            Filewrite.WriteLine(Chr(14) & Chr(15) & Vheader(0))
            pagesize = pagesize + 1
            Filewrite.Write(Space((123 - (Len(Vheader(1)))) / 2))
            Filewrite.WriteLine(Vheader(1))
            pagesize = pagesize + 1
            Filewrite.Write(Space((123 - (Len(Vheader(2)))) / 2))
            Filewrite.WriteLine(Vheader(2))
            pagesize = pagesize + 1
            Filewrite.Write(Space((123 - (Len(head))) / 2))
            Filewrite.WriteLine(head)
            pagesize = pagesize + 1
            Filewrite.Write(Space((123 - (Len(head))) / 2))
            For I = 0 To head.Length
                Filewrite.Write("-")
            Next
            Filewrite.WriteLine()
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
            Filewrite.Write(Space(colsize(i) - Len(x)))
            i = i + 1
        Next
        Filewrite.WriteLine()
        pagesize = pagesize + 1
        For i = 0 To 123
            Filewrite.Write("-")
        Next
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
        Filewrite.Write(Format(total(0), "0.000"))
        Filewrite.Write(Space(2))

        Filewrite.Write(Space((colsize(4) + colsize(5) + colsize(6)) - Len(Trim(Format(total(1), "0.00"))) - 2))
        Filewrite.Write(Format(total(1), "0.00"))
        Filewrite.Write(Space(2))

        Filewrite.Write(Space(colsize(7) - Len(Trim(Format(total(2), "0.00"))) - 2))
        Filewrite.Write(Format(total(2), "0.00"))
        Filewrite.Write(Space(2))

        Filewrite.WriteLine()
        pagesize = pagesize + 1
        For i = 0 To 123
            Filewrite.Write("-")
        Next
        Filewrite.WriteLine()
    End Function
End Class
