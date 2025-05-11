Imports System.IO
Imports System.Data.SqlClient
Public Class rptIssuedetailsreport
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
        Dim GROUPDESC As String = ""
        Dim VOUCHERTOTAL As Double = 0
        Dim VOUCHERQTY As Double = 0
        Dim VOUCHERRATE As Double = 0
        Dim GROUPTOTAL As Double = 0
        Dim GROUPQTY As Double = 0
        Dim GROUPRATE As Double = 0
        ROW = 3 : COL = 1
        I = 0 : J = 0
        GROUPDESC = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("GROUPDESC"))
        GRID.Row = ROW
        GRID.Col = 1
        GRID.FontBold = True
        GRID.ForeColor = Color.Magenta
        GRID.Text = GROUPDESC
        ROW = ROW + 1
        For Each DR In gdataset.Tables("GRIDVIEW").Rows
            If Trim(GROUPDESC) <> Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("GROUPDESC")) Then
                ROW = ROW + 1
                GRID.Row = ROW
                GRID.Col = 4
                GRID.FontBold = True
                GRID.ForeColor = Color.Magenta
                GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                GRID.Text = "SUB TOTAL :"

                GRID.Row = ROW
                GRID.Col = 6
                GRID.FontBold = True
                GRID.ForeColor = Color.Magenta
                GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                GRID.Text = GROUPQTY

                GRID.Row = ROW
                GRID.Col = 7
                GRID.FontBold = True
                GRID.ForeColor = Color.Magenta
                GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                GRID.Text = GROUPRATE

                GRID.Row = ROW
                GRID.Col = 8
                GRID.FontBold = True
                GRID.ForeColor = Color.Magenta
                GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                GRID.Text = GROUPTOTAL
                ROW = ROW + 2

                GRID.Row = ROW
                GRID.Col = 1
                GRID.FontBold = True
                GRID.ForeColor = Color.Magenta
                GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                GRID.Text = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("GROUPDESC"))
                ROW = ROW + 1
                GROUPDESC = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("GROUPDESC"))
                GROUPTOTAL = 0 : GROUPQTY = 0 : GROUPRATE = 0
            End If
            If Trim(ITEMCODE) <> Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE")) Then
                GRID.Row = ROW
                GRID.Col = 1
                GRID.FontBold = True
                GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("ITEMCODE"))) & "      " & gdataset.Tables("gridview").Rows(I).Item("ITEMNAME").ToString()
                ITEMCODE = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE"))
                ITEMDESC = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMNAME"))

            End If

            GRID.Row = ROW
            GRID.Col = 2
            GRID.FontBold = True
            GRID.Text = Trim(CStr(gdataset.Tables("GRIDVIEW").Rows(I).Item("LOCATIONNAME")))

            GRID.Row = ROW
            GRID.Col = 3
            GRID.FontBold = True
            GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("UOM")))

            GRID.Row = ROW
            GRID.Col = 4
            GRID.FontBold = True
            GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            GRID.Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("QTY")), "0")

            GRID.Row = ROW
            GRID.Col = 5
            GRID.FontBold = True
            GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            GRID.Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("RATE")), "0.00")

            GRID.Row = ROW
            GRID.Col = 6
            GRID.FontBold = True
            GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            GRID.Text = Format(Val(gdataset.Tables("gridview").Rows(I).Item("AMOUNT")), "0.00")

            GROUPTOTAL = Val(GROUPTOTAL) + Format(Val(gdataset.Tables("gridview").Rows(I).Item("AMOUNT")), "0.00")
            GROUPRATE = Val(GROUPRATE) + Format(Val(gdataset.Tables("gridview").Rows(I).Item("RATE")), "0.00")
            GROUPQTY = Val(GROUPQTY) + Format(Val(gdataset.Tables("gridview").Rows(I).Item("QTY")), "0")

            ROW = ROW + 1
            I = I + 1
        Next
        'FOR GROUP TOTAL AT END 
        ROW = ROW + 1
        GRID.Row = ROW
        GRID.Col = 4
        GRID.FontBold = True
        GRID.ForeColor = Color.Magenta
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
        GRID.Text = "SUB TOTAL : "

        GRID.Row = ROW
        GRID.Col = 6
        GRID.FontBold = True
        GRID.ForeColor = Color.Magenta
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        GRID.Text = GROUPQTY

        GRID.Row = ROW
        GRID.Col = 7
        GRID.FontBold = True
        GRID.ForeColor = Color.Magenta
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        GRID.Text = GROUPRATE

        GRID.Row = ROW
        GRID.Col = 8
        GRID.FontBold = True
        GRID.ForeColor = Color.Magenta
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        GRID.Text = GROUPTOTAL
        ROW = ROW + 1

        hrow(J) = ROW - 1
        Call TOTAL(GRID, ROW, 4)
        GRID.MaxRows = ROW + 1
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
