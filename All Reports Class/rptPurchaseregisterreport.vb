Public Class rptPurchaseregisterreport
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
        Dim ITEMCODE, ITEMDESC, SUPPLIERNAME, GRNDETAILS, ISSUEDETAILS, GRNDATE, SQLSTRING As String
        Dim VATAMOUNT, OTHERAMOUNTPLUS, OTHERAMOUNTMINUS As Integer
        Dim TOTAL, GRAND As Double
        Dim ITEMBOOL, GRNBOOL As Boolean
        Dim vref As Boolean = False
        ROW = 3 : COL = 1 : TOTAL = 0 : VATAMOUNT = 0 : GRAND = 0 : OTHERAMOUNTMINUS = 0 : OTHERAMOUNTPLUS = 0
        I = 0 : J = 0
        GRID.Row = ROW
        GRID.Col = 1
        GRID.FontBold = True
        GRID.ForeColor = Color.Magenta
        GRID.Text = SUPPLIERNAME
        ROW = ROW + 1
        For Each DR In gdataset.Tables("GRIDVIEW").Rows
            If Trim(SUPPLIERNAME) <> Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("SUPPLIERNAME")) Then
                If vref = True Then
                    ROW = ROW + 1
                    GRID.Row = ROW
                    GRID.Col = 1
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "PAID DETAILS "

                    GRID.Row = ROW
                    GRID.Col = 3
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "                                                                   BASIC : "
                    GRID.Row = ROW
                    GRID.Col = 7
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Val(TOTAL)

                    ROW = ROW + 1
                    GRID.Row = ROW
                    GRID.Col = 1
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "******************"

                    GRID.Row = ROW
                    GRID.Col = 3
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "                                                                   V.A.T"
                    GRID.Row = ROW
                    GRID.Col = 7
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Val(VATAMOUNT)

                    If Val(OTHERAMOUNTPLUS) > 0 Then
                        ROW = ROW + 1
                        GRID.Row = ROW
                        GRID.Col = 3
                        GRID.FontBold = True
                        GRID.ForeColor = Color.Blue
                        GRID.Text = "                                                                   OTHER CHARGES (+)"
                        GRID.Row = ROW
                        GRID.Col = 7
                        GRID.FontBold = True
                        GRID.ForeColor = Color.Blue
                        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                        GRID.Text = Val(OTHERAMOUNTPLUS)
                    End If
                    If Val(OTHERAMOUNTMINUS) > 0 Then
                        ROW = ROW + 1
                        GRID.Row = ROW
                        GRID.Col = 3
                        GRID.FontBold = True
                        GRID.ForeColor = Color.Blue
                        GRID.Text = "                                                                   OTHER CHARGES (-)"
                        GRID.Row = ROW
                        GRID.Col = 7
                        GRID.FontBold = True
                        GRID.ForeColor = Color.Blue
                        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                        GRID.Text = Val(OTHERAMOUNTMINUS)
                    End If
                    GRAND = Val(TOTAL) + Val(VATAMOUNT) - Val(OTHERAMOUNTMINUS) + Val(OTHERAMOUNTPLUS)
                    ROW = ROW + 2
                    GRID.Row = ROW
                    GRID.Col = 3
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "                                                                   GRAND TOTAL :"
                    GRID.Row = ROW
                    GRID.Col = 7
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Val(GRAND)

                    ROW = ROW + 1
                    GRID.Row = ROW
                    GRID.Col = 7
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "A/C : CLUB -"

                    GRID.Row = ROW
                    GRID.Col = 8
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "MAIN STORE "

                    ROW = ROW + 1
                End If
                GRID.Row = ROW
                GRID.Col = 1
                GRID.FontBold = True
                GRID.ForeColor = Color.Magenta
                GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                GRID.Text = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("SUPPLIERNAME"))
                ROW = ROW + 1
                SUPPLIERNAME = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("SUPPLIERNAME"))
                TOTAL = 0 : VATAMOUNT = 0 : OTHERAMOUNTMINUS = 0 : OTHERAMOUNTPLUS = 0
            End If
            vref = True
            If Trim(GRNDETAILS) <> Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("GRNDETAILS")) Then
                If GRNBOOL = True Then
                    'FOR GROUP TOTAL AT END 
                    ROW = ROW + 1
                    GRID.Row = ROW
                    GRID.Col = 1
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "PAID DETAILS "
                    GRID.Row = ROW
                    GRID.Col = 3
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "                                                                   BASIC : "
                    GRID.Row = ROW
                    GRID.Col = 7
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Val(TOTAL)

                    ROW = ROW + 1
                    GRID.Row = ROW
                    GRID.Col = 1
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "******************"

                    GRID.Row = ROW
                    GRID.Col = 3
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "                                                                   V.A.T."
                    GRID.Row = ROW
                    GRID.Col = 7
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Val(VATAMOUNT)

                    If Val(OTHERAMOUNTPLUS) > 0 Then
                        ROW = ROW + 1
                        GRID.Row = ROW
                        GRID.Col = 3
                        GRID.FontBold = True
                        GRID.ForeColor = Color.Blue
                        GRID.Text = "                                                                   OTHER CHARGES (+)"
                        GRID.Row = ROW
                        GRID.Col = 7
                        GRID.FontBold = True
                        GRID.ForeColor = Color.Blue
                        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                        GRID.Text = Val(OTHERAMOUNTPLUS)
                    End If
                    If Val(OTHERAMOUNTMINUS) > 0 Then
                        ROW = ROW + 1
                        GRID.Row = ROW
                        GRID.Col = 3
                        GRID.FontBold = True
                        GRID.ForeColor = Color.Blue
                        GRID.Text = "                                                                   OTHER CHARGES (-)"
                        GRID.Row = ROW
                        GRID.Col = 7
                        GRID.FontBold = True
                        GRID.ForeColor = Color.Blue
                        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                        GRID.Text = Val(OTHERAMOUNTMINUS)
                    End If

                    GRAND = Val(TOTAL) + Val(VATAMOUNT) - Val(OTHERAMOUNTMINUS) + Val(OTHERAMOUNTPLUS)

                    ROW = ROW + 2
                    GRID.Row = ROW
                    GRID.Col = 3
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "                                                                   GRAND TOTAL :"
                    GRID.Row = ROW
                    GRID.Col = 7
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Val(GRAND)

                    ROW = ROW + 1
                    GRID.Row = ROW
                    GRID.Col = 7
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "A/C : CLUB -"

                    GRID.Row = ROW
                    GRID.Col = 8
                    GRID.FontBold = True
                    GRID.ForeColor = Color.Blue
                    GRID.Text = "MAIN STORE "
                    GRNBOOL = True
                End If
                ROW = ROW + 1
                GRID.Row = ROW
                GRID.Col = 1
                GRID.FontBold = True
                GRID.Text = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("GRNDETAILS"))

                GRID.Row = ROW
                GRID.Col = 2
                GRID.FontBold = True
                GRID.Text = Format(gdataset.Tables("GRIDVIEW").Rows(I).Item("GRNDATE"), "dd/MM/yyyy")

                GRNDETAILS = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("GRNDETAILS"))
                TOTAL = 0 : VATAMOUNT = 0 : OTHERAMOUNTMINUS = 0 : OTHERAMOUNTPLUS = 0 : GRNBOOL = True
            End If

            If Trim(ITEMCODE) <> Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE")) Then
                TOTAL = Val(TOTAL) + gdataset.Tables("gridview").Rows(I).Item("AMOUNT")
                'DISCOUNT = Val(DISCOUNT) + gdataset.Tables("gridview").Rows(I).Item("DISCOUNT")
                If ITEMBOOL = True Then
                    GRID.Row = ROW
                    GRID.Col = 3
                    GRID.FontBold = True
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("ITEMCODE"))) & "          " & Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("ITEMNAME")))
                    GRID.Row = ROW
                    GRID.Col = 4
                    GRID.FontBold = True
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("UOM")))
                    GRID.Row = ROW
                    GRID.Col = 5
                    GRID.FontBold = True
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("QTY")))
                    GRID.Row = ROW
                    GRID.Col = 6
                    GRID.FontBold = True
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("RATE")))
                    GRID.Row = ROW
                    GRID.Col = 7
                    GRID.FontBold = True
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("AMOUNT")))

                    GRID.Col = 8
                    GRID.FontBold = True
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("DISCOUNT")))

                    ITEMCODE = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE"))
                    ROW = ROW + 1
                Else
                    If gdataset.Tables("gridview").Rows(I).Item("BILLTERMS") = "V.A.T  :" Then
                        VATAMOUNT = gdataset.Tables("gridview").Rows(I).Item("VATAMOUNT")
                    ElseIf gdataset.Tables("gridview").Rows(I).Item("BILLTERMS") = "OTHER CHARGES (+)  :" Then
                        OTHERAMOUNTPLUS = gdataset.Tables("gridview").Rows(I).Item("VATAMOUNT")
                    ElseIf gdataset.Tables("gridview").Rows(I).Item("BILLTERMS") = "OTHER CHARGES (-)  :" Then
                        OTHERAMOUNTMINUS = gdataset.Tables("gridview").Rows(I).Item("VATAMOUNT")
                    End If
                    GRID.Row = ROW
                    GRID.Col = 3
                    GRID.FontBold = True
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("ITEMCODE"))) & "          " & Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("ITEMNAME")))
                    GRID.Row = ROW
                    GRID.Col = 4
                    GRID.FontBold = True
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("UOM")))
                    GRID.Row = ROW
                    GRID.Col = 5
                    GRID.FontBold = True
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("QTY")))
                    GRID.Row = ROW
                    GRID.Col = 6
                    GRID.FontBold = True
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("RATE")))
                    GRID.Row = ROW
                    GRID.Col = 7
                    GRID.FontBold = True
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("AMOUNT")))
                    GRID.Col = 8
                    GRID.FontBold = True
                    GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    GRID.Text = Trim(CStr(gdataset.Tables("gridview").Rows(I).Item("DISCOUNT")))
                    ITEMCODE = Trim(gdataset.Tables("GRIDVIEW").Rows(I).Item("ITEMCODE"))
                    ITEMBOOL = True
                    ROW = ROW + 1
                End If
            Else
                If gdataset.Tables("gridview").Rows(I).Item("BILLTERMS") = "V.A.T  :" Then
                    VATAMOUNT = gdataset.Tables("gridview").Rows(I).Item("VATAMOUNT")
                ElseIf gdataset.Tables("gridview").Rows(I).Item("BILLTERMS") = "OTHER CHARGES (+)  :" Then
                    OTHERAMOUNTPLUS = gdataset.Tables("gridview").Rows(I).Item("VATAMOUNT")
                ElseIf gdataset.Tables("gridview").Rows(I).Item("BILLTERMS") = "OTHER CHARGES (-)  :" Then
                    OTHERAMOUNTMINUS = gdataset.Tables("gridview").Rows(I).Item("VATAMOUNT")
                End If
            End If
            I = I + 1
        Next
        'FOR GROUP TOTAL AT END 
        ROW = ROW + 1
        GRID.Row = ROW
        GRID.Col = 1
        GRID.FontBold = True
        GRID.ForeColor = Color.Blue
        GRID.Text = "PAID DETAILS "
        GRID.Row = ROW
        GRID.Col = 3
        GRID.FontBold = True
        GRID.ForeColor = Color.Blue
        GRID.Text = "                                                                   BASIC : "
        GRID.Row = ROW
        GRID.Col = 7
        GRID.FontBold = True
        GRID.ForeColor = Color.Blue
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        GRID.Text = Val(TOTAL)

        ROW = ROW + 1
        GRID.Row = ROW
        GRID.Col = 1
        GRID.FontBold = True
        GRID.ForeColor = Color.Blue
        GRID.Text = "******************"

        GRID.Row = ROW
        GRID.Col = 3
        GRID.FontBold = True
        GRID.ForeColor = Color.Blue
        GRID.Text = "                                                                   V.A.T."
        GRID.Row = ROW
        GRID.Col = 7
        GRID.FontBold = True
        GRID.ForeColor = Color.Blue
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        GRID.Text = Val(VATAMOUNT)

        If Val(OTHERAMOUNTPLUS) > 0 Then
            ROW = ROW + 1
            GRID.Row = ROW
            GRID.Col = 3
            GRID.FontBold = True
            GRID.ForeColor = Color.Blue
            GRID.Text = "                                                                   OTHER CHARGES (+)"
            GRID.Row = ROW
            GRID.Col = 7
            GRID.FontBold = True
            GRID.ForeColor = Color.Blue
            GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            GRID.Text = Val(OTHERAMOUNTPLUS)
        End If
        If Val(OTHERAMOUNTMINUS) > 0 Then
            ROW = ROW + 1
            GRID.Row = ROW
            GRID.Col = 3
            GRID.FontBold = True
            GRID.ForeColor = Color.Blue
            GRID.Text = "                                                                   OTHER CHARGES (-)"
            GRID.Row = ROW
            GRID.Col = 7
            GRID.FontBold = True
            GRID.ForeColor = Color.Blue
            GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
            GRID.Text = Val(OTHERAMOUNTMINUS)
        End If

        GRAND = Val(TOTAL) + Val(VATAMOUNT) - Val(OTHERAMOUNTMINUS) + Val(OTHERAMOUNTPLUS)

        ROW = ROW + 2
        GRID.Row = ROW
        GRID.Col = 3
        GRID.FontBold = True
        GRID.ForeColor = Color.Blue
        GRID.Text = "                                                                   GRAND TOTAL :"
        GRID.Row = ROW
        GRID.Col = 7
        GRID.FontBold = True
        GRID.ForeColor = Color.Blue
        GRID.CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
        GRID.Text = Val(GRAND)

        ROW = ROW + 1
        GRID.Row = ROW
        GRID.Col = 7
        GRID.FontBold = True
        GRID.ForeColor = Color.Blue
        GRID.Text = "A/C : CLUB -"

        GRID.Row = ROW
        GRID.Col = 8
        GRID.FontBold = True
        GRID.ForeColor = Color.Blue
        GRID.Text = "MAIN STORE "

        ROW = ROW + 1
        hrow(J) = ROW - 1
        GRID.MaxRows = ROW + 1
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
