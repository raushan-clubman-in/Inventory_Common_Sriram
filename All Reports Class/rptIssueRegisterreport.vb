Imports System.IO
Imports System.Data.SqlClient
Public Class rptIssueRegisterreport
    Dim hrow(100) As Integer
    Dim DR As DataRow
    Dim DC As DataColumn
    Dim ROW, COL As Integer
    Dim I As Integer = 0
    Dim J As Integer = 0
    Dim VOUCHERNO As String = ""
    Dim LOCATIONNAME As String = ""
    Dim gclass As New GlobalClass
    Public Function GridColumnname(ByVal GRID As AxFPSpreadADO.AxfpSpread, ByVal columnname() As String, ByVal columnname1() As String, ByVal colsize() As Integer)
        ROW = 1
        COL = 1
        GRID.Row = ROW
        GRID.Col = COL
        For I = 0 To columnname.Length - 1
            GRID.Row = ROW
            GRID.Col = COL
            GRID.set_ColWidth(COL, colsize(I))
            GRID.FontSize = 10
            GRID.FontBold = True
            GRID.BackColor = Color.Wheat
            GRID.ForeColor = Color.Black
            GRID.Text = columnname(I)
            COL = COL + 1
        Next
        GRID.MaxCols = columnname.Length
        ROW = 2
        COL = 1
        GRID.Row = ROW
        GRID.Col = COL
        For I = 0 To columnname1.Length - 1
            GRID.Row = ROW
            GRID.Col = COL
            GRID.set_ColWidth(COL, colsize(I))
            GRID.FontSize = 10
            GRID.FontBold = True
            GRID.BackColor = Color.Wheat
            GRID.ForeColor = Color.Black
            GRID.Text = columnname1(I)
            COL = COL + 1
        Next
        GRID.MaxCols = columnname1.Length
    End Function

    Public Function BodyOfGrid(ByVal GRID As AxFPSpreadADO.AxfpSpread)
        Dim VOUCHERTOTAL, VOUCHERQTY, VOUCHERRATE, GROUPTOTAL, GROUPQTY, QTY, GROUPRATE As Double
        Dim VOUCHERBOOL, LOCATIONBOOL As Boolean
        ROW = 3 : COL = 1
        I = 0 : J = 0
        GRID.Row = ROW
        GRID.Col = 1
        GRID.FontBold = True
        GRID.ForeColor = Color.Magenta
        GRID.Text = LOCATIONNAME
        ROW = ROW + 1
        For Each DR In gdataset.Tables("GRIDVIEW").Rows
            If Trim(LOCATIONNAME) <> Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("LOCATIONNAME")) Then
                If LOCATIONBOOL = True Then
                    hrow(J) = ROW - 1
                    J = J + 1
                    ROW = ROW + 1
                    GRID.Row = ROW
                    GRID.Col = 4
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Navy
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                    GRID.Text = "DOC TOTAL : "

                    '.Row = ROW
                    '.Col = 6
                    '.FontBold = True
                    '.ForeColor = Color.Navy
                    '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    '.Text = VOUCHERQTY

                    '.Row = ROW
                    '.Col = 7
                    '.FontBold = True
                    '.ForeColor = Color.Navy
                    '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    '.Text = VOUCHERRATE

                    GRID.Row = ROW
                    GRID.Col = 8
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Navy
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = VOUCHERTOTAL
                    ROW = ROW + 1
                    ROW = ROW + 1
                    GRID.Row = ROW
                    GRID.Col = 4
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Magenta
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                    GRID.Text = "GROUP TOTAL : "

                    '.Row = ROW
                    '.Col = 6
                    '.FontBold = True
                    '.ForeColor = Color.Magenta
                    '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    '.Text = GROUPQTY

                    '.Row = ROW
                    '.Col = 7
                    '.FontBold = True
                    '.ForeColor = Color.Magenta
                    '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    '.Text = GROUPRATE

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
                    GRID.Text = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("LOCATIONNAME"))
                    ROW = ROW + 1
                    LOCATIONNAME = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("LOCATIONNAME"))
                    GROUPTOTAL = 0 : GROUPQTY = 0 : GROUPRATE = 0
                Else
                    GRID.Row = ROW
                    GRID.Col = 1
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Magenta
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                    GRID.Text = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("LOCATIONNAME"))
                    ROW = ROW + 1
                    LOCATIONNAME = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("LOCATIONNAME"))
                    GROUPTOTAL = 0 : GROUPQTY = 0 : GROUPRATE = 0
                    LOCATIONBOOL = True
                End If
            End If
            If Trim(VOUCHERNO) <> Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("DOCDETAILS")) Then
                If VOUCHERBOOL = True Then
                    hrow(J) = ROW - 1
                    J = J + 1
                    ROW = ROW + 1
                    GRID.Row = ROW
                    GRID.Col = 4
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Navy
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                    GRID.Text = "DOC TOTAL : "

                    '.Row = ROW
                    '.Col = 6
                    '.FontBold = True
                    '.ForeColor = Color.Navy
                    '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    '.Text = VOUCHERQTY

                    '.Row = ROW
                    '.Col = 7
                    '.FontBold = True
                    '.ForeColor = Color.Navy
                    '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    '.Text = VOUCHERRATE

                    GRID.Row = ROW
                    GRID.Col = 8
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Navy
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = VOUCHERTOTAL
                    ROW = ROW + 1
                    GRID.Row = ROW
                    GRID.Col = 1
                    GRID.FontBold = True
                    GRID.Text = gdataset.Tables("gridview").Rows(I).Item("DOCDETAILS").ToString()

                    GRID.Row = ROW
                    GRID.Col = 2
                    GRID.FontBold = True
                    GRID.Text = gdataset.Tables("gridview").Rows(I).Item("DOCDATE").ToString()

                    VOUCHERTOTAL = 0 : VOUCHERQTY = 0 : VOUCHERRATE = 0
                    VOUCHERNO = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("DOCDETAILS"))
                Else
                    GRID.Row = ROW
                    GRID.Col = 1
                    GRID.FontBold = True
                    GRID.Text = gdataset.Tables("gridview").Rows(I).Item("DOCDETAILS").ToString()

                    GRID.Row = ROW
                    GRID.Col = 2
                    GRID.FontBold = True
                    GRID.Text = gdataset.Tables("gridview").Rows(I).Item("DOCDATE").ToString()
                    VOUCHERTOTAL = 0 : VOUCHERQTY = 0 : VOUCHERRATE = 0
                    VOUCHERNO = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("DOCDETAILS"))
                    VOUCHERBOOL = True
                End If
            End If
            GRID.Row = ROW
            GRID.Col = 3
            GRID.FontBold = True
            GRID.Text = ""

            GRID.Row = ROW
            GRID.Col = 4
            GRID.FontBold = True
            GRID.Text = gdataset.Tables("gridview").Rows(I).Item("ITEMNAME").ToString()

            GRID.Row = ROW
            GRID.Col = 5
            GRID.FontBold = True
            GRID.Text = gdataset.Tables("gridview").Rows(I).Item("UOM").ToString()

            GRID.Row = ROW
            GRID.Col = 6
            GRID.FontBold = True
            GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            GRID.Text = gdataset.Tables("gridview").Rows(I).Item("QTY")
            QTY = Format(Val(gdataset.Tables("gridview").Rows(I).Item("QTY")), "0.00")
            GRID.Row = ROW
            GRID.Col = 7
            GRID.FontBold = True
            GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            GRID.Text = gdataset.Tables("gridview").Rows(I).Item("RATE").ToString()

            GRID.Row = ROW
            GRID.Col = 8
            GRID.FontBold = True
            GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            GRID.Text = gdataset.Tables("gridview").Rows(I).Item("AMOUNT").ToString()

            VOUCHERTOTAL = Val(VOUCHERTOTAL) + gdataset.Tables("gridview").Rows(I).Item("AMOUNT").ToString()
            VOUCHERQTY = Val(VOUCHERQTY) + gdataset.Tables("gridview").Rows(I).Item("QTY").ToString()
            VOUCHERRATE = Val(VOUCHERRATE) + gdataset.Tables("gridview").Rows(I).Item("RATE").ToString()

            GROUPTOTAL = Val(GROUPTOTAL) + gdataset.Tables("gridview").Rows(I).Item("AMOUNT").ToString()
            GROUPQTY = Val(GROUPQTY) + gdataset.Tables("gridview").Rows(I).Item("QTY").ToString()
            GROUPRATE = Val(GROUPRATE) + gdataset.Tables("gridview").Rows(I).Item("RATE").ToString()

            ROW = ROW + 1
            If gIssueregister = True Then
                If Format(Val(DR("CONVVALUE")), "0.00") > 1 Then
                    GRID.Row = ROW
                    GRID.Col = 5
                    GRID.FontBold = True
                    GRID.Text = gdataset.Tables("gridview").Rows(I).Item("CONV").ToString()

                    GRID.Row = ROW
                    GRID.Col = 6
                    GRID.FontBold = True
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = QTY * Format(Val(gdataset.Tables("gridview").Rows(I).Item("DBLAMT").ToString()), "0.00")
                    ROW = ROW + 1
                End If
            End If
            I = I + 1
            QTY = 0
        Next DR

        'FOR DOC TOTAL AT END 
        ROW = ROW + 1
        GRID.Row = ROW
        GRID.Col = 4
        GRID.FontBold = True
        GRID.ForeColor = Color.Navy
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
        GRID.Text = "DOC TOTAL : "

        '.Row = ROW
        '.Col = 6
        '.FontBold = True
        '.ForeColor = Color.Navy
        '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        '.Text = VOUCHERQTY

        '.Row = ROW
        '.Col = 7
        '.FontBold = True
        '.ForeColor = Color.Navy
        '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        '.Text = VOUCHERRATE

        GRID.Row = ROW
        GRID.Col = 8
        GRID.FontBold = True
        GRID.ForeColor = Color.Navy
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        GRID.Text = VOUCHERTOTAL
        ROW = ROW + 1

        'FOR GROUP TOTAL AT END 
        ROW = ROW + 1
        GRID.Row = ROW
        GRID.Col = 4
        GRID.FontBold = True
        GRID.ForeColor = Color.Magenta
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
        GRID.Text = "GROUP TOTAL : "

        '.Row = ROW
        '.Col = 6
        '.FontBold = True
        '.ForeColor = Color.Magenta
        '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        '.Text = GROUPQTY

        '.Row = ROW
        '.Col = 7
        '.FontBold = True
        '.ForeColor = Color.Magenta
        '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        '.Text = GROUPRATE

        GRID.Row = ROW
        GRID.Col = 8
        GRID.FontBold = True
        GRID.ForeColor = Color.Magenta
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        GRID.Text = GROUPTOTAL
        ROW = ROW + 1

        hrow(J) = ROW - 1
        'Call TOTAL(GRID, ROW, COL)
        Call TOTAL(GRID, ROW, 4)
        GRID.MaxRows = ROW + 1
        'Highlight(GRID)
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
            GRID.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleFixedSingle
            GRID.Row = ROW
            GRID.Col = COL
            GRID.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleFixedSingle
            GRID.FontBold = True
            GRID.ForeColor = Color.Red
            GRID.Text = "GRAND TOTAL : "

            '.Row = ROW
            '.Col = COL + 2
            '.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleFixedSingle
            '.FontBold = True
            '.ForeColor = Color.Red
            '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            '.Text = Format(QTY, "0.00")

            '.Row = ROW
            '.Col = COL + 3
            '.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleFixedSingle
            '.FontBold = True
            '.ForeColor = Color.Red
            '.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            '.Text = Format(RATE, "0.00")

            GRID.Row = ROW
            GRID.Col = COL + 4
            GRID.BorderStyle = FPSpreadADO.BorderStyleConstants.BorderStyleFixedSingle
            GRID.FontBold = True
            GRID.ForeColor = Color.Red
            GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            GRID.Text = Format(TOT, "0.00")
        End With
    End Function
    Public Function KeyDownEvent(ByVal GRID As AxFPSpreadADO.AxfpSpread, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent)
        If e.keyCode = Keys.Enter Then
            GRID.Col = GRID.ActiveCol
            GRID.Row = GRID.ActiveRow
            If GRID.Col = GRID.MaxCols Then
                GRID.SetActiveCell(1, GRID.Row + 1)
            Else
                GRID.SetActiveCell(GRID.Col + 1, GRID.Row)
            End If
        End If
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
