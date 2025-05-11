Imports System.IO
Imports System.Data.SqlClient
Public Class rptStockledgermainstockreport
    Dim hrow(100) As Integer
    Dim DR As DataRow
    Dim DC As DataColumn
    Dim ROW, COL As Integer
    Dim I As Integer = 0
    Dim J As Integer = 0
    Dim gconnection As New GlobalClass
    Public Function GridColumnname(ByVal GRID As AxFPSpreadADO.AxfpSpread, ByVal columnname() As String, ByVal columnname1() As String, ByVal colsize() As Integer)
        ROW = 1
        COL = 1
        With GRID
            .Row = ROW
            .Col = COL
            For I = 0 To columnname.Length - 1
                .Row = ROW
                .Col = COL
                .set_ColWidth(COL, colsize(I))
                .FontSize = 10
                .FontBold = True
                .BackColor = Color.Wheat
                .ForeColor = Color.Black
                .Text = columnname(I)
                COL = COL + 1
            Next
            .MaxCols = columnname.Length
        End With
        ROW = 2
        COL = 1
        With GRID
            .Row = ROW
            .Col = COL
            For I = 0 To columnname1.Length - 1
                .Row = ROW
                .Col = COL
                .set_ColWidth(COL, colsize(I))
                .FontSize = 10
                .FontBold = True
                .BackColor = Color.Wheat
                .ForeColor = Color.Black
                .Text = columnname1(I)
                COL = COL + 1
            Next
            .MaxCols = columnname1.Length
        End With
    End Function

    Public Function BodyOfGrid(ByVal GRID As AxFPSpreadADO.AxfpSpread)
        Dim ITEMCODE, ITEMDESC, GROUPDESC, GRNDETAILS, ISSUEDETAILS, GRNDATE, SQLSTRING As String
        Dim ISSUEVALUE, BALQTY, OPBAL, RCVQTY, ISSQTY, TOTRECEIPT, TOTISSUE, OPQTY As Double
        Dim ITEMBOOL As Boolean
        ROW = 3 : COL = 1
        I = 0 : J = 0
        With GRID
            .Row = ROW
            .Col = 1
            .FontBold = True
            .ForeColor = Color.Magenta
            .Text = GROUPDESC
            ROW = ROW + 1
            For Each DR In gdataset.Tables("GRIDVIEW").Rows
                If Trim(GROUPDESC) <> Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("GROUPDESC")) Then
                    .Row = ROW
                    .Col = 1
                    .FontBold = True
                    .ForeColor = Color.Magenta
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                    .Text = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("GROUPDESC"))
                    ROW = ROW + 1
                    GROUPDESC = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("GROUPDESC"))
                End If
                If Trim(ITEMCODE) <> Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE")) Then
                    If ITEMBOOL = True Then
                        .Row = ROW
                        .Col = 1
                        .FontBold = True
                        .Text = Format(CDate(DR("GRNDATE")), "dd/MM/yyyy")
                        .Col = 2
                        .FontBold = True
                        .Text = Trim("********* CLOSING BALANCE ***********")
                        .Col = 9
                        .FontBold = True
                        .Text = Format(Val(BALQTY), "0.00")
                        .Row = ROW + 1
                        .Col = 4
                        .FontBold = True
                        .Text = "RECEIPT :"
                        .Col = 7
                        .FontBold = True
                        .Text = Format(Val(TOTRECEIPT), "0.00")
                        .Row = ROW + 1
                        .Col = 4
                        .FontBold = True
                        .Text = "ISSUES  :"
                        .Col = 7
                        .FontBold = True
                        .Text = Format(Val(TOTISSUE), "0.00")
                        .Col = 1
                        .FontBold = True
                        .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("ITEMCODE")))
                        .Row = ROW
                        .Col = 2
                        .FontBold = True
                        .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("ITEMNAME")))
                        .Row = ROW
                        .Col = 3
                        .FontBold = True
                        .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("STOCKUOM")))
                        .Row = ROW
                        .Col = 4
                        .FontBold = True
                        .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("VALUATION")))
                        .Row = ROW + 1
                        .Col = 1
                        .FontBold = True
                        .Text = "01/04/" & gFinancalyearStart
                        .Col = 2
                        .FontBold = True
                        .Text = Trim("********* OPENING BALANCE ***********")
                        .Col = 9
                        .FontBold = True
                        .Text = Format(Val(OPQTY), "0.00")
                        ITEMCODE = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE"))
                        ROW = ROW + 1
                    Else
                        .Row = ROW
                        .Col = 1
                        .FontBold = True
                        .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("ITEMCODE")))
                        .Row = ROW
                        .Col = 2
                        .FontBold = True
                        .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("ITEMNAME")))
                        .Row = ROW
                        .Col = 3
                        .FontBold = True
                        .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("STOCKUOM")))
                        .Row = ROW
                        .Col = 4
                        .FontBold = True
                        .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("VALUATION")))
                        ROW = ROW + 1
                        .Row = ROW
                        .Col = 1
                        .FontBold = True
                        .Text = "01/04/" & gFinancalyearStart
                        .Col = 2
                        .FontBold = True
                        .Text = Trim("********* OPENING BALANCE ***********")
                        .Col = 9
                        .FontBold = True
                        .Text = Format(Val(OPQTY), "0.00")
                        ITEMCODE = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE"))
                        ITEMBOOL = True
                        ROW = ROW + 1
                    End If
                End If
                If (GRNDETAILS <> Trim(CStr(DR("GRNDETAILS")))) Then
                    SQLSTRING = "SELECT * FROM  VIEWSTOCKLEDGERMAINSTORE WHERE itemcode='" & ITEMCODE & "' AND Grndetails='" & Trim(CStr(DR("Grndetails"))) & "' order by grndate"
                    gconnection.getDataSet(SQLSTRING, "stockledgerfilter")
                    If gdataset.Tables("stockledgerfilter").Rows.Count > 0 Then
                        For I = 0 To gdataset.Tables("stockledgerfilter").Rows.Count - 1
                            With gdataset.Tables("stockledgerfilter").Rows(I)
                                If Mid(CStr(.Item("GRNDETAILS")), 1, 3) = "GRN" Then
                                    GRID.Row = ROW
                                    GRID.Col = 1
                                    GRID.FontBold = True
                                    GRID.Text = Mid(Format(CDate(.Item("GRNDATE")), "dd/MM/yyyy"), 1, 15)
                                    GRID.Row = ROW
                                    GRID.Col = 2
                                    GRID.FontBold = True
                                    GRID.Text = Mid(CStr(.Item("GRNDETAILS")), 1, 20)
                                    GRID.Col = 3
                                    GRID.FontBold = True
                                    GRID.Text = Mid(CStr(.Item("SUPPLIERNAME")), 1, 10)
                                    GRID.Col = 4
                                    GRID.FontBold = True
                                    GRID.Text = ""
                                    GRID.Col = 5
                                    GRID.FontBold = True
                                    GRID.Text = Mid(Format(Val(.Item("GRNRATE")), "0.00"), 1, 10)
                                    GRID.Col = 6
                                    GRID.FontBold = True
                                    GRID.Text = Mid(Format(Val(.Item("GRNQTY")), "0.00"), 1, 10)
                                    RCVQTY = Format(Val(.Item("GrnQty")), "0.00")
                                    TOTRECEIPT = TOTRECEIPT + Val(RCVQTY)
                                    GRNDATE = Format(CDate(.Item("Grndate")), "dd/MM/yyyy")
                                    ROW = ROW + 1

                                Else
                                    GRID.Row = ROW
                                    GRID.Col = 1
                                    GRID.FontBold = True
                                    GRID.Text = Mid(Format(CDate(.Item("GRNDATE")), "dd/MM/yyyy"), 1, 15)
                                    GRID.Row = ROW
                                    GRID.Col = 2
                                    GRID.FontBold = True
                                    GRID.Text = Mid(CStr(.Item("GRNDETAILS")), 1, 20)
                                    GRID.Col = 3
                                    GRID.FontBold = True
                                    GRID.Text = ""
                                    GRID.Col = 4
                                    GRID.FontBold = True
                                    GRID.Text = ""
                                    GRID.Col = 5
                                    GRID.FontBold = True
                                    GRID.Text = Mid(Format(Val(.Item("GRNRATE")), "0.00"), 1, 10)
                                    ISSUEVALUE = Val(.Item("Grnrate")) * Val(.Item("GRNQTY"))
                                    GRID.Col = 6
                                    GRID.FontBold = True
                                    GRID.Text = Mid(Format(Val(ISSUEVALUE), "0.00"), 1, 10)
                                    GRID.Col = 7
                                    GRID.FontBold = True
                                    GRID.Text = Mid(Format(Val(.Item("GRNQTY")), "0.00"), 1, 10)
                                    ISSQTY = Format(Val(DR("GRNQTY")), "0.00")
                                    TOTISSUE = TOTISSUE + Val(ISSQTY)
                                    BALQTY = OPBAL + RCVQTY - ISSQTY
                                    GRID.Col = 8
                                    GRID.FontBold = True
                                    GRID.Text = Mid(Format(Val(BALQTY), "0.00"), 1, 10)
                                    OPBAL = BALQTY
                                    GRNDATE = Format(CDate(.Item("GRNDATE")), "dd/MM/yyyy")
                                    ROW = ROW + 1
                                End If
                            End With
                        Next I
                        GRNDETAILS = Trim(CStr(gdataset.Tables("stockledgerfilter").Rows(I - 1).Item("Grndetails")))
                    End If
                End If
                ROW = ROW + 1
                I = I + 1
            Next
            'FOR GROUP TOTAL AT END 
            .Row = ROW
            .Col = 1
            .FontBold = True
            .Text = Format(CDate(DR("GRNDATE")), "dd/MM/yyyy")
            .Col = 2
            .FontBold = True
            .Text = Trim("********* CLOSING BALANCE ***********")
            .Col = 9
            .FontBold = True
            .Text = Format(Val(BALQTY), "0.00")
            ROW = ROW + 1
            .Row = ROW
            .Col = 4
            .FontBold = True
            .Text = "RECEIPT :"
            .Col = 7
            .FontBold = True
            .Text = Format(Val(TOTRECEIPT), "0.00")
            ROW = ROW + 1
            .Row = ROW
            .Col = 4
            .FontBold = True
            .Text = "ISSUES  :"
            .Col = 7
            .FontBold = True
            .Text = Format(Val(TOTISSUE), "0.00")
            ROW = ROW + 1
            hrow(J) = ROW - 1
            .MaxRows = ROW + 1
        End With
    End Function
    Public Function KeyDownEvent(ByVal GRID As AxFPSpreadADO.AxfpSpread, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent)
        With GRID
            If e.keyCode = Keys.Enter Then
                .Col = .ActiveCol
                .Row = .ActiveRow
                If .Col = .MaxCols Then
                    .SetActiveCell(1, .Row + 1)
                Else
                    .SetActiveCell(.Col + 1, .Row)
                End If
            End If
        End With
    End Function

    Public Function DoubleClick(ByVal GRID As AxFPSpreadADO.AxfpSpread, ByVal e As AxFPSpreadADO._DSpreadEvents_DblClickEvent)
        Dim COL, ROW As Integer
        Dim COLUMNTEXT As String
        Dim I As Integer
        COL = GRID.ActiveCol
        ROW = GRID.ActiveRow
        For I = 0 To hrow.Length - 1
            If ROW < hrow(I) Then
                GRID.GetText(1, hrow(I - 1) + 2, COLUMNTEXT)
                Exit For
            End If
        Next
        MsgBox(COLUMNTEXT)
    End Function
End Class
