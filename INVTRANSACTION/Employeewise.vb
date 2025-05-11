Imports CrystalDecisions.CrystalReports.Engine
Public Class Employeewise
    Public STORECODE, STORECOD2, ITEMCODE, TType, docno, uom As String
    Public TotalQTY, BalQTY As Double
    Dim gconnection As New GlobalClass
    Dim STRSQL As String
    Private Sub Employeewise_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Txt_QTY.Text = TotalQTY
        Dim qty As Double = TotalQTY
        AxfpSpread1.Col = 1
        AxfpSpread1.ColHidden = True
        AxfpSpread1.Col = 5
        AxfpSpread1.ColHidden = True
        cmd_clear_Click(sender, e)
    End Sub
    Private Sub bindempcode()
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(CONNO,'') AS CONNO,ISNULL(CONNAME,'') AS CONNAME,ISNULL(CONTYPE,'') AS CONTYPE FROM CONSUMERMASTER"
        M_WhereCondition = "  "
        vform.Field = "CONNAME,CONNO,CONTYPE"
        vform.vFormatstring = "         CONSUMER NO              |                CONSUMER NAME                  |           DEPARTMENT       "
        vform.vCaption = "CONSUMER MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            AxfpSpread1.Col = 1
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield)
            AxfpSpread1.Col = 2
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield1)
            AxfpSpread1.Col = 5
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield2)
            Me.AxfpSpread1.SetActiveCell(2, AxfpSpread1.ActiveRow)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub CmdOk_Click(sender As Object, e As EventArgs) Handles CmdOk.Click
        Dim insert(0) As String
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)
            Exit Sub
        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = i + 1
            AxfpSpread1.Col = 3
            Dim qty As String = Val(AxfpSpread1.Text)
            If qty <= 0 Then
                MessageBox.Show("Quantity can't be blank or Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(3, 1)
                Exit Sub
            End If
        Next

        If (CheckQty()) Then
            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 3
                If AxfpSpread1.Text > 0 Then
                    STRSQL = "insert into inv_EMPLOYEEISSUE(trnno,issqty,itemcode,itemname,trndate,QTY,empcode,EMPNAME,DEPARTMENT,REMARKS)"
                    STRSQL = STRSQL & "VALUES ('" & txt_Docno.Text & "','" & Txt_QTY.Text & "','" & LBL_ITEMCODE.Text & "','" & lbl_itemname.Text & "','" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 3
                    STRSQL = STRSQL & "'" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 1
                    STRSQL = STRSQL & "'" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 2
                    STRSQL = STRSQL & "'" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 5
                    STRSQL = STRSQL & "'" & Trim(AxfpSpread1.Text) & "',"
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 4
                    STRSQL = STRSQL & "'" & Trim(AxfpSpread1.Text) & "')"

                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = STRSQL

                End If
            Next
            gconnection.MoreTrans(insert)
            cmd_clear_Click(sender, e)
        End If
    End Sub
    Private Sub Cmd_Docnohelp_Click(sender As Object, e As EventArgs) Handles Cmd_Docnohelp.Click
        Try
            gSQLString = "select   docdetails,docdate,itemname,itemcode,qty from stockissuedetail"
            M_WhereCondition = " where Storelocationcode in (select storecode from  Inv_UserStoreLink where usercode='" + gUsername + "') and itemcode not in(select itemcode from  inv_EMPLOYEEISSUE where inv_EMPLOYEEISSUE.trnno=stockissuedetail.docdetails)  "
            M_Groupby = "ITEMNAME,docdetails,docdate,itemcode,qty"
            M_ORDERBY = "ORDER BY docdate DESC"
            Dim vform As New List_Operation
            vform.Field = "docdetails,docdate,ITEMNAME,itemcode,qty"
            vform.vFormatstring1 = "    DOC NO             | DOC DATE  |            ITEMNAME                     |  ITEMCODE     | ISSQTY    "
            vform.vCaption = "STOCK ISSUE NO HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Docno.Text = Trim(vform.keyfield & "")
                lbl_itemname.Text = Trim(vform.keyfield2 & "")
                LBL_ITEMCODE.Text = Trim(vform.keyfield3 & "")
                Txt_QTY.Text = Trim(vform.keyfield4 & "")
                dtp_Docdate.Value = vform.keyfield1
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Me.AxfpSpread1.Focus()
                Me.AxfpSpread1.SetActiveCell(2, 1)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim insert(0) As String
        Dim sqlstring As String
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)
            Exit Sub
        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = i + 1
            AxfpSpread1.Col = 3
            Dim qty As String = Val(AxfpSpread1.Text)
            If qty <= 0 Then
                MessageBox.Show("Quantity can't be blank or Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(3, 1)
                Exit Sub
            End If
        Next
        sqlstring = "DELETE FROM inv_employeeissue WHERE trnno='" & Trim(txt_Docno.Text) & "' "
        sqlstring = sqlstring & " AND itemcode = '" & LBL_ITEMCODE.Text & "'"
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 3
            If AxfpSpread1.Text > 0 Then
                sqlstring = "insert into inv_employeeissue(trnno,issqty,itemcode,itemname,trndate,QTY,empcode,EMPNAME,DEPARTMENT,REMARKS)"
                sqlstring = sqlstring & "VALUES ('" & txt_Docno.Text & "','" & Txt_QTY.Text & "','" & LBL_ITEMCODE.Text & "','" & lbl_itemname.Text & "','" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 3
                sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 2
                sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 5
                sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 4
                sqlstring = sqlstring & "'" & Trim(AxfpSpread1.Text) & "')"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
            End If
        Next
        gconnection.MoreTrans(insert)
        cmd_clear_Click(sender, e)
    End Sub

    Private Sub BTN_DIS_DOCNO_Click(sender As Object, e As EventArgs) Handles BTN_DIS_DOCNO.Click
        Try
            gSQLString = "select   TRNNO,TRNDATE,ITEMNAME,empname,qty from inv_EMPLOYEEISSUE"
            M_WhereCondition = " where isnull(void,'')<>'Y'  "
            'M_Groupby = "ITEMNAME,docdetails,docdate,itemcode,qty"
            M_ORDERBY = "ORDER BY TRNNO DESC,TRNDATE DESC,ITEMNAME,EMPNAME"
            Dim vform As New List_Operation
            vform.Field = "TRNNO,TRNDATE,ITEMNAME,EMPNAME,qty"
            vform.vFormatstring1 = "       DOC NO            |         DOC DATE             |     ITEMNAME              |      EMPNAME                   |    QTY            "
            vform.vCaption = "DISTRIBUTION NO HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXT_DIS_DOCNO.Text = Trim(vform.keyfield & "")
                lbl_itemname.Text = Trim(vform.keyfield2 & "")
                Call TXT_DIS_DOCNO_Validated(TXT_DIS_DOCNO, e)
                AxfpSpread1.SetActiveCell(2, 1)

            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub TXT_DIS_DOCNO_Validated(sender As Object, e As EventArgs) Handles TXT_DIS_DOCNO.Validated
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim sqlstring As String
        If Trim(TXT_DIS_DOCNO.Text) <> "" Then
            sqlstring = "select TRNNO,ITEMCODE,ISNULL(ITEMNAME,'')AS ITEMNAME,TRNDATE,QTY,EMPCODE,ISNULL(REMARKS,'')AS REMARKS,ISNULL(ISSQTY,0)AS ISSQTY,ISNULL(EMPNAME,'')AS EMPNAME,ISNULL(DEPARTMENT,'')AS DEPARTMENT from inv_EMPLOYEEISSUE "
            sqlstring = " WHERE TRNNO ='" & Trim(TXT_DIS_DOCNO.Text) & "' and isnull(void,'')<>'Y' AND ITEMNAME='" & Trim(lbl_itemname.Text) & "' "
            gconnection.getDataSet(sqlstring, "STOCKISSUEHEADER")
            If gdataset.Tables("STOCKISSUEHEADER").Rows.Count > 0 Then
                'Cmd_Add.Text = "Update[F7]"
                btn_update.Visible = True
                CmdOk.Visible = False
                txt_Docno.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("TRNNO") & "")
                LBL_ITEMCODE.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("ITEMCODE") & "")
                lbl_itemname.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("ITEMNAME") & "")
                dtp_Docdate.Value = Format(CDate(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("TRNDATE")), "dd-MMM-yyyy")
                Txt_QTY.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("ISSQTY") & "")
                For i = 1 To gdataset.Tables("STOCKISSUEHEADER").Rows.Count
                    j = i - 1
                    AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(j).Item("EMPCODE")))
                    AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(j).Item("EMPNAME")))
                    AxfpSpread1.Col = 3
                    AxfpSpread1.Row = i
                    AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(j).Item("QTY")))
                    AxfpSpread1.Col = 4
                    AxfpSpread1.Row = i
                    AxfpSpread1.SetText(4, i, Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(j).Item("REMARKS")))
                    AxfpSpread1.Col = 5
                    AxfpSpread1.Row = i
                    AxfpSpread1.SetText(5, i, Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(j).Item("DEPARTMENT")))
                Next
            End If
        End If
    End Sub

    Private Sub cmd_view_Click(sender As Object, e As EventArgs) Handles cmd_view.Click
        Try
            Dim rViewer As New Viewer
            Dim sqlstring As String
            Dim R As New HGA_DISTRIBUTION
            sqlstring = "select TRNNO,ITEMCODE,ISNULL(ITEMNAME,'')AS ITEMNAME,TRNDATE,QTY,EMPCODE,ISNULL(REMARKS,'')AS REMARKS,ISNULL(ISSQTY,0)AS ISSQTY,ISNULL(EMPNAME,'')AS EMPNAME,ISNULL(DEPARTMENT,'')AS DEPARTMENT from inv_EMPLOYEEISSUE "
            sqlstring = sqlstring & " WHERE TRNNO = '" & Trim(txt_Docno.Text) & "' AND ITEMNAME= '" & lbl_itemname.Text & "'  "
            sqlstring = sqlstring & " ORDER BY ITEMNAME"
            gconnection.getDataSet(sqlstring, "inv_EMPLOYEEISSUE")
            If gdataset.Tables("inv_EMPLOYEEISSUE").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = R
                rViewer.TableName = "inv_EMPLOYEEISSUE"
                Dim textobj1 As TextObject
                textobj1 = R.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName

                Dim textobj11 As TextObject
                textobj11 = R.ReportDefinition.ReportObjects("Text23")
                textobj11.Text = UCase(Address1) + "," + UCase(Address2)
                Dim textobj26 As TextObject
                textobj26 = R.ReportDefinition.ReportObjects("Text26")
                textobj26.Text = UCase(gState) + "," + UCase(gPincode)


                Dim textobj25 As TextObject
                textobj25 = R.ReportDefinition.ReportObjects("Text29")
                textobj25.Text = gFinancalyearStart + " to " + gFinancialyearEnd



                Dim Text21 As TextObject
                Text21 = R.ReportDefinition.ReportObjects("Text21")
                Text21.Text = gUsername

                rViewer.Show()

            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Dim sqlstring As String
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)
            Exit Sub
        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = i + 1
            AxfpSpread1.Col = 3
            Dim qty As String = Val(AxfpSpread1.Text)
            If qty <= 0 Then
                MessageBox.Show("Quantity can't be blank or Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                AxfpSpread1.SetActiveCell(3, 1)
                Exit Sub
            End If
        Next


        sqlstring = "UPDATE  inv_EMPLOYEEISSUE "
        sqlstring = sqlstring & " SET void= 'Y'"
        sqlstring = sqlstring & " WHERE trnno = '" & Trim(txt_Docno.Text) & "' and itemcode= '" & LBL_ITEMCODE.Text & "'"
        gconnection.dataOperation(3, sqlstring, "inventorygroupmaster")
        Me.cmd_clear_Click(sender, e)



    End Sub

    Private Sub cmd_clear_Click(sender As Object, e As EventArgs) Handles cmd_clear.Click
        txt_Docno.Text = ""
        Txt_QTY.Text = ""
        TXT_DIS_DOCNO.Text = ""
        LBL_ITEMCODE.Text = "ITEM CODE"
        lbl_itemname.Text = "ITEM NAME"
        Me.dtp_Docdate.Value = Format(Now, "dd/MMM/yyyy")
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        CmdOk.Visible = True
        btn_update.Visible = False
    End Sub

    Private Sub AxfpSpread1_KeyDownEvent_1(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        AxfpSpread1.Row = AxfpSpread1.ActiveRow
        If e.keyCode = Keys.Enter Then
            I = AxfpSpread1.ActiveRow
            AxfpSpread1.Row = I
            If AxfpSpread1.ActiveCol = 1 Then
                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) = "" Then
                    bindempcode()
                End If
            End If
            If AxfpSpread1.ActiveCol = 2 Then
                AxfpSpread1.Col = 2
                If Trim(AxfpSpread1.Text) = "" Then
                    bindempcode()
                End If
            End If
            Dim itc As String
            Dim cct, k As Integer
            For J = 1 To AxfpSpread1.DataRowCnt + 1
                'Dim ITC
                AxfpSpread1.Col = 1
                AxfpSpread1.Row = J
                itc = AxfpSpread1.Text
                For k = 1 To AxfpSpread1.DataRowCnt + 1
                    AxfpSpread1.Col = 1
                    AxfpSpread1.Row = k
                    If Trim(AxfpSpread1.Text) = itc Then
                        cct = cct + 1
                    End If
                Next
                If cct > 1 Then
                    MsgBox("duplicate  entry")
                    AxfpSpread1.ClearRange(1, AxfpSpread1.ActiveRow, 3, AxfpSpread1.ActiveRow, True)
                    ' AxfpSpread1.Col = 1
                    AxfpSpread1.Focus()
                    Exit Sub
                End If
                cct = 0
            Next
        End If
        If e.keyCode = Keys.F3 Then
            AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
        End If
    End Sub

    Public docdate As Date
    Dim I, J As Long
    Private Function CheckQty() As Boolean
        Dim qty As Double
        For I = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = I
            AxfpSpread1.Col = 3
            TotalQTY = Txt_QTY.Text
            qty = qty + Convert.ToDouble(AxfpSpread1.Text)
            If (qty > TotalQTY) Then
                MsgBox("Entered total quantity cannot be greater then total quantity")
                Return False
            End If
            '    If (QTY < totalqty) Then
            '        MsgBox("Entered total quantity cannot be lesser then total quantity")
            '        Return False
            '    End If
        Next
        Return True
    End Function
    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

End Class