Public Class rptBarStockposition
    Dim hrow(100) As Integer
    Dim DR As DataRow
    Dim DC As DataColumn
    Dim ROW, COL As Integer
    Dim I As Integer = 0
    Dim J As Integer = 0
    Dim gclass As New GlobalClass
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
        Dim ITEMCODE As String = ""
        Dim ITEMDESC As String = ""
        ROW = 3 : COL = 1
        I = 0 : J = 0
        With GRID
            ROW = ROW + 1
            For Each DR In gdataset.Tables("GRIDVIEW").Rows
                If Trim(ITEMCODE) <> Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE")) Then
                    .Row = ROW
                    .Col = 1
                    .FontBold = True
                    .Text = Trim(CStr(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE")))

                    .Row = ROW
                    .Col = 2
                    .FontBold = True
                    .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("ITEMNAME")))

                    .Row = ROW
                    .Col = 3
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                    .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("UOM")))

                    .Row = ROW
                    .Col = 4
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                    .Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("VALUATION")))

                    .Row = ROW
                    .Col = 5
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("OPQTY")), "0")

                    .Col = 6
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("OPRATE")), "0.00")

                    .Col = 7
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("OPVAL")), "0.00")

                    .Row = ROW
                    .Col = 8
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("RCVQTY")), "0")

                    .Row = ROW
                    .Col = 9
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("RCVRATE")), "0")

                    .Row = ROW
                    .Col = 10
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("RCVVAL")), "0")

                    .Row = ROW
                    .Col = 11
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("ISSUQTY")), "0")

                    .Row = ROW
                    .Col = 12
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("ISSURATE")), "0")

                    .Row = ROW
                    .Col = 13
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("ISSUVAL")), "0")

                    .Row = ROW
                    .Col = 14
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("CLSQTY")), "0.00")

                    .Row = ROW
                    .Col = 15
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("CLSRATE")), "0.00")

                    .Row = ROW
                    .Col = 16
                    .FontBold = True
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("CLSVAL")), "0.00")
                    ITEMCODE = Trim(CStr(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE")))
                    ROW = ROW + 1
                    I = I + 1

                End If
            Next
            hrow(J) = ROW - 1
            'Call TOTAL(GRID, ROW, 4)
            .MaxRows = ROW + 1
        End With
    End Function
    Private Function TOTAL(ByVal GRID As AxFPSpreadADO.AxfpSpread, ByVal ROW As Integer, ByVal COL As Integer)
        Dim DR As DataRow
        Dim TOT As Double = 0
        Dim QTY As Double = 0
        Dim RATE As Double = 0
        Dim I As Integer = 0
        With GRID
            For Each DR In gdataset.Tables("GRIDVIEW").Rows
                QTY = QTY + gdataset.Tables("GRIDVIEW").Rows(I).Item("QTY")
                RATE = RATE + gdataset.Tables("GRIDVIEW").Rows(I).Item("RATE")
                TOT = TOT + gdataset.Tables("GRIDVIEW").Rows(I).Item("AMOUNT")
                I = I + 1
            Next
            .BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleFixedSingle
            .Row = ROW
            .Col = COL
            .BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleFixedSingle
            .FontBold = True
            .ForeColor = Color.Red
            .Text = "GRAND TOTAL : "

            .Row = ROW
            .Col = COL + 2
            .BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleFixedSingle
            .FontBold = True
            .ForeColor = Color.Red
            .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            .Text = Format(QTY, "0.00")

            .Row = ROW
            .Col = COL + 3
            .BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleFixedSingle
            .FontBold = True
            .ForeColor = Color.Red
            .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            .Text = Format(RATE, "0.00")

            .Row = ROW
            .Col = COL + 4
            .BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleFixedSingle
            .FontBold = True
            .ForeColor = Color.Red
            .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            .Text = Format(TOT, "0.00")
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
