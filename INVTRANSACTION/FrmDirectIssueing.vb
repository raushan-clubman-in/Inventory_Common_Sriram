Public Class FrmDirectIssueing

    Public flg As Boolean = False
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Private Sub FrmDirectIssueing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        BINDGRID(nonstockable)
        AxfpSpread1.SetActiveCell(4, 1)
        AxfpSpread1.Focus()
    End Sub

    Private Sub Bindgrid(dt As DataTable)

        For j As Integer = 0 To dt.Rows.Count - 1

            AxfpSpread1.Row = j + 1
            AxfpSpread1.Col = 1
            AxfpSpread1.Text = dt.Rows(j).Item("itemcode").ToString()
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 2
            AxfpSpread1.Text = dt.Rows(j).Item("itemName").ToString()
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 3

            AxfpSpread1.Text = dt.Rows(j).Item("uOM").ToString()
            AxfpSpread1.Lock = True
            AxfpSpread1.Col = 4

            AxfpSpread1.Text = dt.Rows(j).Item("qUANTITY").ToString()
            AxfpSpread1.Col = 6

            AxfpSpread1.Text = dt.Rows(j).Item("totalqUANTITY").ToString()


        Next
        AxfpSpread1.MaxRows = dt.Rows.Count

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim insert(0), SQLS As String
        Dim itmcode, itmcodeprev, vvl As String
        Dim itemtot, itemtotprev As Double
        Dim j As Integer
        For j = 0 To nonstockable.Rows.Count - 1
            itmcode = Nothing
            itemtot = Nothing
            itmcode = nonstockable.Rows(j).Item("itemcode")
            itemtot = nonstockable.Rows(j).Item("totalquantity")

            itemtotprev = 0
            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                itmcodeprev = Nothing
                AxfpSpread1.GetText(1, i, itmcodeprev)
                If UCase(itmcodeprev) = UCase(itmcode) Then
                    vvl = Nothing
                    AxfpSpread1.GetText(4, i, vvl)
                    itemtotprev = itemtotprev + Val(vvl)
                End If

            Next
            If Val(itemtotprev) <> Val(itemtot) Then
                MsgBox("GRN qty and issue qty is not same for  :  " & itmcode)
                Exit Sub
            End If
        Next
        
        Call Randomize()
        directissueing = Replace(Replace(Mid("dir" & gUsername & Date.Now & Mid(Rnd() * 80000000, 1, 5), 1, 100), " ", ""), ":", "")
        directissueing = Replace(directissueing, ".", "")
        directissueing = Replace(directissueing, "-", "")
        directissueing = Replace(directissueing, "+", "")
        directissueing = Replace(directissueing, "/", "")
        TABNAME = directissueing

        sqlstring = "delete from directissueingNew"
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring

        sqlstring = "if exists(select * from sysobjects where name='" & directissueing & "') begin DROP TABLE " & directissueing & " end"
        gconnection.ExcuteStoreProcedure(sqlstring)


       

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 4
            If (Val(AxfpSpread1.Text) = 0) Or AxfpSpread1.Text = "" Then
                MessageBox.Show("Quantity can't be Zero or Blank..")
                AxfpSpread1.SetActiveCell(4, i)
                AxfpSpread1.Focus()
                Exit Sub
            End If
            AxfpSpread1.Col = 3
            If (AxfpSpread1.Text = "") Then
                MessageBox.Show("Please Select uom")
                AxfpSpread1.SetActiveCell(3, i)
                AxfpSpread1.Focus()
                Exit Sub
            End If
            AxfpSpread1.Col = 5
            If (AxfpSpread1.Text = "") Then
                MessageBox.Show("Please Select Storecode")
                AxfpSpread1.SetActiveCell(5, i)
                AxfpSpread1.Focus()
                Exit Sub
            Else

                sqlstring = " SELECT DISTINCT(storecode),storedesc FROM storemaster where storecode='" & Trim(AxfpSpread1.Text) & "' and isnull(freeze,'') <> 'Y' and storestatus='S' "
                gconnection.getDataSet(sqlstring, "storemaster")
                If (gdataset.Tables("storemaster").Rows.Count > 0) Then
                Else
                    MessageBox.Show("Please Select valid store code")
                    Exit Sub
                End If
            End If
        Next

        SQLS = "SELECT * INTO " & directissueing & " FROM directissueingNew where 1<0 "
        gconnection.ExcuteStoreProcedure(SQLS)

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 5
            If (AxfpSpread1.Text = "") Then
                MessageBox.Show("Please Select Storecode")
                AxfpSpread1.SetActiveCell(4, i)
                AxfpSpread1.Focus()
                Exit Sub
            Else
                sqlstring = "Insert into " & directissueing & "(itemcode,itemname,uom,quantity,storecode)"
                AxfpSpread1.Col = 1
                sqlstring = sqlstring & " values ('" + AxfpSpread1.Text + "',"
                AxfpSpread1.Col = 2
                sqlstring = sqlstring & " '" + AxfpSpread1.Text + "',"
                AxfpSpread1.Col = 3
                sqlstring = sqlstring & " '" + AxfpSpread1.Text + "',"
                AxfpSpread1.Col = 4
                sqlstring = sqlstring & " '" + Format(Val(AxfpSpread1.Text), "0.000") + "',"
                AxfpSpread1.Col = 5
                sqlstring = sqlstring & " '" + AxfpSpread1.Text + "') "
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
                flg = True
            End If
        Next

        If (flg = True) Then
            gconnection.MoreTrans(insert)
            Me.Hide()
        End If
    End Sub

    Private Sub bindstorecode()

        Dim sqlstring As String
      
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
        M_WhereCondition = " where freeze <> 'Y' and storestatus='S' "
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Dim row As Integer = AxfpSpread1.ActiveRow
            AxfpSpread1.Row = row
            AxfpSpread1.Col = 5
            AxfpSpread1.Text = vform.keyfield
            nonstockable.Rows(row - 1).Item("storecode") = vform.keyfield

            AxfpSpread1.Focus()
            AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow + 1)
        End If
        vform.Close()
        vform = Nothing
    End Sub


    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim row As Integer
        If (e.keyCode = Keys.Enter) Then

            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            row = AxfpSpread1.ActiveRow
            Dim itemcode1 As String
            AxfpSpread1.Col = 1
            itemcode1 = AxfpSpread1.Text
            If (AxfpSpread1.ActiveCol = 5) And itemcode1 <> "" Then
                AxfpSpread1.Col = 5
                If (AxfpSpread1.Text = "") Then
                    bindstorecode()
                Else

                    sqlstring = "SELECT DISTINCT(storecode) as storecode,storedesc FROM storemaster where  freeze <> 'Y' and storestatus='S' and storecode='" + AxfpSpread1.Text + "'  "
                    gconnection.getDataSet(sqlstring, "storemaster")
                    If (gdataset.Tables("storemaster").Rows.Count > 0) Then
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                        AxfpSpread1.Col = 5
                        AxfpSpread1.Text = gdataset.Tables("storemaster").Rows(0).Item("storecode")
                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow + 1)
                        nonstockable.Rows(AxfpSpread1.ActiveRow - 1).Item("storecode") = gdataset.Tables("storemaster").Rows(0).Item("storecode")
                    End If

                End If
            ElseIf (AxfpSpread1.ActiveCol = 4) Then
                AxfpSpread1.Col = 4
                If (Val(AxfpSpread1.Text) = "0") Then
                    MessageBox.Show("Quantity Cannot be 0")
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                Else
                    Dim itemcode As String
                    Dim itemname As String
                    Dim uom As String
                    Dim restqty As Double
                    AxfpSpread1.Col = 1
                    itemcode = AxfpSpread1.Text
                    AxfpSpread1.Col = 2
                    itemname = AxfpSpread1.Text
                    AxfpSpread1.Col = 3
                    uom = AxfpSpread1.Text

                    AxfpSpread1.Col = 4
                    Dim issqty = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 6
                    Dim grnqty = Val(AxfpSpread1.Text)
                    AxfpSpread1.Col = 1
                    restqty = totalqty(AxfpSpread1.Text)
                    If (restqty > 0) Then
                        AxfpSpread1.MaxRows = AxfpSpread1.MaxRows + 1
                        AxfpSpread1.InsertRows(AxfpSpread1.ActiveRow + 1, 1)
                        AxfpSpread1.Row = AxfpSpread1.ActiveRow + 1
                        AxfpSpread1.Col = 1
                        AxfpSpread1.Text = itemcode
                        AxfpSpread1.Lock = True
                        AxfpSpread1.Col = 2
                        AxfpSpread1.Text = itemname
                        AxfpSpread1.Lock = True
                        AxfpSpread1.Col = 3
                        AxfpSpread1.Text = uom
                        AxfpSpread1.Lock = True
                        AxfpSpread1.Col = 4
                        AxfpSpread1.Text = restqty
                        AxfpSpread1.Col = 6
                        AxfpSpread1.Text = grnqty
                        AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    ElseIf (restqty < 0) Then
                        AxfpSpread1.Row = row
                        AxfpSpread1.Col = 4
                        AxfpSpread1.Text = 0
                        AxfpSpread1.Col = 1
                        restqty = totalqty(AxfpSpread1.Text)
                        AxfpSpread1.Row = row
                        AxfpSpread1.Col = 4
                        AxfpSpread1.Text = restqty


                    End If

                End If
            End If
            AxfpSpread1.Col = 4
            If (AxfpSpread1.Text = "") Then
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
            Else
                AxfpSpread1.Row = row + 1
                AxfpSpread1.Col = 4
                If (AxfpSpread1.Text = "") Then
                    Button1.Focus()
                Else
                    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                End If

            End If
        ElseIf e.keyCode = Keys.F3 Or e.keyCode = 113 Then

            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)

            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)

            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            row = AxfpSpread1.ActiveRow
            Dim itemcode As String
            Dim itemname As String
            Dim uom As String
            Dim restqty As Double
            AxfpSpread1.Col = 1
            itemcode = AxfpSpread1.Text
            AxfpSpread1.Col = 2
            itemname = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            uom = AxfpSpread1.Text

            AxfpSpread1.Col = 4
            Dim issqty = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 6
            Dim grnqty = Val(AxfpSpread1.Text)
            AxfpSpread1.Col = 1
            restqty = totalqty(AxfpSpread1.Text)
            If (restqty > 0) Then
                AxfpSpread1.MaxRows = AxfpSpread1.MaxRows + 1
                AxfpSpread1.InsertRows(AxfpSpread1.ActiveRow + 1, 1)
                AxfpSpread1.Row = AxfpSpread1.ActiveRow + 1
                AxfpSpread1.Col = 1
                AxfpSpread1.Text = itemcode
                AxfpSpread1.Lock = True
                AxfpSpread1.Col = 2
                AxfpSpread1.Text = itemname
                AxfpSpread1.Lock = True
                AxfpSpread1.Col = 3
                AxfpSpread1.Text = uom
                AxfpSpread1.Lock = True
                AxfpSpread1.Col = 4
                AxfpSpread1.Text = restqty
                AxfpSpread1.Col = 6
                AxfpSpread1.Text = grnqty
                AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
            ElseIf (restqty < 0) Then
                AxfpSpread1.Row = row
                AxfpSpread1.Col = 4
                AxfpSpread1.Text = 0
                AxfpSpread1.Col = 1
                restqty = totalqty(AxfpSpread1.Text)
                AxfpSpread1.Row = row
                AxfpSpread1.Col = 4
                AxfpSpread1.Text = restqty


            End If
        End If

    End Sub

    Private Function totalqty(ByVal itemcode As String) As Double
        Dim totqty As Double = 0
        Dim issqty As Double = 0
        Dim grnqty As Double = 0

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 1
            AxfpSpread1.Row = i
            If (itemcode = AxfpSpread1.Text) Then
                AxfpSpread1.Col = 6
                AxfpSpread1.Row = i
                grnqty = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 4
                issqty = Val(AxfpSpread1.Text)
                totqty = totqty + issqty
               
            End If
        Next
        Return grnqty - totqty
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        Bindgrid(nonstockable)
    End Sub

    Private Sub AxfpSpread1_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles AxfpSpread1.Advance

    End Sub
End Class