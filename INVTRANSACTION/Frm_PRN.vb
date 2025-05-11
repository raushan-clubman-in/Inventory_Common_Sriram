Imports System.Data.SqlClient
Public Class Frm_PRN
    Dim gconnection As New GlobalClass
    Dim sql As String

    Dim GRNno(), versionno, CATCODE() As String
    Dim accode, acdesc, taxcode As String
    Dim amt As Double
    Dim slcode As String
    ' Set grntype defaultly 
    Private Sub FillGRNTYPE()
        Dim Sqlstring As String
        Sqlstring = "SELECT ISNULL(GRNTYPE,'') AS GRNTYPE FROM INVSETUP"
        gconnection.getDataSet(Sqlstring, "INVSETUP")
        If gdataset.Tables("INVSETUP").Rows.Count > 0 Then
            DefaultGRN = Trim(gdataset.Tables("INVSETUP").Rows(0).Item("GRNTYPE"))
        Else
            DefaultGRN = "NA"
        End If
    End Sub
    'bind categorycode in dropdown
    Private Sub bindcategory()
        Dim I As Integer
        Dim index As Integer
        Try


            CMB_CATEGORY.Items.Clear()
            Dim sql As String = "Select categorycode,CATEGORYDESC FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE IN (SELECT CATEGORYCODE  from Categoryuserdetail where usercode='" & gUsername & "' and isnull(void,'')<>'Y')"
            gconnection.getDataSet(sql, "Categoryuserdetail")
            If (gdataset.Tables("Categoryuserdetail").Rows.Count > 0) Then
                For I = 0 To gdataset.Tables("Categoryuserdetail").Rows.Count - 1
                    CMB_CATEGORY.Items.Add(gdataset.Tables("Categoryuserdetail").Rows(I).Item("categorycode") + "--->" + gdataset.Tables("Categoryuserdetail").Rows(I).Item("CATEGORYDESC"))
                Next
                index = CMB_CATEGORY.FindString(DefaultGRN)
                CMB_CATEGORY.SelectedIndex = index
            End If

        Catch ex As Exception

        End Try

    End Sub
    'generate Grnno automatically
    Private Sub autogenerate()
        Try
            Dim sqlstring, financalyear As String
            Dim month As String
            Dim CATLEN As Integer
            Dim category As String
            month = UCase(Format(Now, "MMM"))
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialyearEnd, 3, 2)

            sqlstring = "SELECT ISNULL(CATEGORY,'') AS CATEGORY FROM INV_InventoryItemMaster WHERE ISNULL(CATEGORY,'')='" & Trim(CMB_CATEGORY.Text & "") & "' GROUP BY CATEGORY"
            gconnection.getDataSet(sqlstring, "CATEGORY")
            If gdataset.Tables("CATEGORY").Rows.Count > 0 Then
                category = Mid(Trim(gdataset.Tables("CATEGORY").Rows(0).Item("CATEGORY") & ""), 1, 3)
                CATLEN = Len(Trim(category))
            Else
                CATLEN = 3
                category = month
            End If
            sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER WHERE SUBSTRING(GRNDETAILS,5," & CATLEN & ")='" & category & "'  AND ISNULL(GRNTYPE,'')='GRN'"
            '        sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    txt_Prnno.Text = "PRN/" & category & "/" & "0001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    txt_Prnno.Text = "PRN/" & category & "/" & Format(gdreader(0) + 1, "0000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txt_Prnno.Text = "PRN/" & category & "/0001/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : autogenerate" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub Frm_PRN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (gpocode = "YES") Then
            grp_Grngroup1.Visible = True
        Else
            grp_Grngroup1.Visible = False
        End If
        FillGRNTYPE()
        bindcategory()
        autogenerate()


    End Sub

    Private Sub cmd_Suppliercodehelp_Click(sender As Object, e As EventArgs) Handles cmd_Suppliercodehelp.Click
        Try

            gSQLString = "SELECT SLCODE,SLNAME FROM accountssubledgermaster "
            M_WhereCondition = " WHERE ACCODE IN ('" & Trim(gCreditors) & "') "
            Dim vform As New ListOperattion1
            vform.Field = "SLNAME,SLCODE"
            vform.vFormatstring = "       SLCODE                    |                      SLNAME                                                                                                          "
            vform.vCaption = "SUB LEDGER MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Suppliercode.Text = Trim(vform.keyfield & "")
                Call txt_Suppliercode_Validated(txt_Suppliercode, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_Suppliercodehelp_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Suppliercode_Validated(sender As Object, e As EventArgs) Handles txt_Suppliercode.Validated
        Dim sqlstring As String
        Try
            If Trim(txt_Suppliercode.Text) <> "" Then
                sqlstring = "SELECT SLCODE,SLNAME,isnull(creditperiod,0) as creditperiod FROM accountssubledgermaster WHERE ACCODE IN ("
                sqlstring = sqlstring & "'" & Trim(gCreditors) & "') AND SLCODE='" & Trim(txt_Suppliercode.Text) & "'"
                gconnection.getDataSet(sqlstring, "accountssubledgermaster")
                If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
                    txt_Suppliername.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("SLNAME"))
                    txt_Suppliercode.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("SLCODE"))
                    txt_Suppliername.ReadOnly = True
                    If gvendorlink = "Y" Then
                        txt_Suppliercode.Enabled = False
                        cmd_Suppliercodehelp.Enabled = False
                    End If

                    txt_Supplierinvno.Focus()


                Else
                    txt_Suppliercode.Text = ""
                    txt_Suppliercode.Text = ""
                    txt_Suppliername.ReadOnly = False
                    txt_Suppliercode.Focus()
                End If
            Else
                txt_Suppliercode.Text = ""
                txt_Suppliername.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Suppliercode_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Cmd_Storecode_Click(sender As Object, e As EventArgs) Handles Cmd_Storecode.Click
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
        M_WhereCondition = " where freeze <> 'Y' and storestatus='M' "
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Storecode.Text = Trim(vform.keyfield & "")
            txt_StoreDesc.Text = Trim(vform.keyfield1 & "")
            'Txt_GLAcIn.Focus()
            AxfpSpread1.Focus()
            AxfpSpread1.SetActiveCell(1, 1)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub binditemcode()
        Dim vform As New ListOperattion1

        gSQLString = "select itemcode,Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category='" + CMB_CATEGORY.Text + "' and isnull(M.void)='N' and isnull(I.storecode)='" + txt_Storecode.Text + "'"
        vform.Field = " I.uomcode, I.uomdesc"
        vform.vFormatstring = "    uomcode    |                     uomdesc                   "
        vform.vCaption = "UOM MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos1 = 2

        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            AxfpSpread1.Col = 1
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield)
            AxfpSpread1.Col = 2
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield1)
            AxfpSpread1.Col = 3
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield2)
            sql = "select taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + Trim(vform.keyfield) + "'"
            gconnection.getDataSet(sql, "Itemtaxtagging")
            If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                AxfpSpread1.Col = 8
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                AxfpSpread1.Col = 12
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("GLACCOUNTIN")
            Else
                MessageBox.Show("Create TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            End If
            AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow)
        End If

    End Sub
    Private Sub binditemname()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim myValue As Object
        message = "Enter Batch No"
        title = "Batch No"
        defaultValue = txt_Prnno.Text
        gSQLString = "select itemcode,Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category='" + CMB_CATEGORY.Text + "' and isnull(M.void)='N' and isnull(I.storecode)='" + txt_Storecode.Text + "'"
        vform.Field = " I.itemcode, I.Itemname,I.Uom,batchprocess"
        vform.vFormatstring = "    itemcode    |     Itemname              |       UOM     |"
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos1 = 2
        vform.KeyPos1 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            AxfpSpread1.Col = 1
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield)
            AxfpSpread1.Col = 2
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield1)
            AxfpSpread1.Col = 3
            AxfpSpread1.Row = AxfpSpread1.ActiveRow
            AxfpSpread1.Text = Trim(vform.keyfield2)
            If Trim(vform.keyfield3) = "YES" Then
                myValue = InputBox(message, title, defaultValue)
                If myValue = "" Then myValue = defaultValue
                AxfpSpread1.Col = 13
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = myValue

            Else
                AxfpSpread1.Col = 13
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = defaultValue
            End If
            sql = "select taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + Trim(vform.keyfield) + "'"
            gconnection.getDataSet(sql, "Itemtaxtagging")
            If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                AxfpSpread1.Col = 8
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                AxfpSpread1.Col = 12
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("GLACCOUNTIN")
            Else
                MessageBox.Show("Create TaxCode For Item :" + Trim(vform.keyfield), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            End If
            AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow)
        End If

    End Sub
    Private Sub CALCULATE()
        Dim overalldisc, othercharge, extra As Double
        Dim totqty, totamt, taxamt, discamt, freeqty, totfreeqty As Double
        Dim itemqty, itemrate, itemamount, itemtax, itemdisc, discperc, taxperc, itemtot As Double

        If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Or AxfpSpread1.ActiveCol = 7 Or AxfpSpread1.ActiveCol = 8 Then

            For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 4
                itemqty = Val(AxfpSpread1.Text)
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 5
                itemrate = Val(AxfpSpread1.Text)
                If (itemrate = 0) Then
                    freeqty = itemqty
                Else
                    freeqty = 0
                End If
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 6
                itemamount = itemqty * itemrate
                AxfpSpread1.Text = itemamount
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 7
                discperc = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 8
                taxperc = Val(AxfpSpread1.Text)
                itemdisc = (itemamount * discperc) / 100
                itemtax = (itemamount * taxperc) / 100
                itemtot = itemamount + taxamt - discamt
                AxfpSpread1.Col = 9
                AxfpSpread1.Text = discamt
                AxfpSpread1.Col = 10
                AxfpSpread1.Text = taxamt
                AxfpSpread1.Col = 11
                AxfpSpread1.Text = itemtot
                totqty = totqty + itemqty
                totfreeqty = totfreeqty + freeqty
                totamt = totamt + itemamount
                taxamt = taxamt + itemtax
                discamt = discamt + itemdisc
            Next

            txt_totdisc.Text = discamt
            txt_totaltax.Text = taxamt
            txt_total.Text = totamt
            overalldisc = Convert.ToDouble(TXT_OVERALLdiscount.Text)
            othercharge = Convert.ToDouble(txt_Surchargeamt.Text)
            extra = (othercharge - overalldisc) / (totqty - totfreeqty)
            For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 4
                itemqty = Val(AxfpSpread1.Text)
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 5
                itemrate = Val(AxfpSpread1.Text)
                If (itemrate = 0) Then
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 14
                    AxfpSpread1.Text = 0
                Else
                    AxfpSpread1.Row = i
                    AxfpSpread1.Col = 14
                    AxfpSpread1.Text = extra * itemqty
                End If
            Next
        End If
    End Sub
    Private Sub clearoperation()
        Txt_GRNNO.Text = ""
        autogenerate()
        dtp_Grndate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Suppliercode.Text = ""
        txt_Suppliername.Text = ""
        txt_Supplierinvno.Text = ""
        dtp_Supplierinvdate.Value = DateTime.Now.ToString("dd/MMM/yyyy")
        txt_Storecode.Text = ""
        txt_StoreDesc.Text = ""
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        txt_total.Text = ""
        txt_totaltax.Text = ""
        txt_totdisc.Text = ""
        TXT_OVERALLdiscount.Text = ""
        txt_Surchargeamt.Text = ""
        txt_Billamount.Text = ""
        txt_Remarks.Text = ""
    End Sub
    Private Sub addoperation()
        Dim INSERT(0) As String
        Dim sqlstring As String
        Dim Itemcode1 As String
        GRNno = Split(Trim(txt_Prnno.Text), "/")

        sqlstring = "INSERT INTO Grn_header(category,Grnno,Grndetails,Grndate,POno,Supplierinvno,Supplierdate,Suppliercode, Suppliername"
        ' sqlstring = sqlstring & ",Typecode,Typedesc,Excisepassno,Excisedate,Stockindate,Trucknumber,Creditdays,Glaccountcode,Glaccountname,Slcode,Slname,Costcentercode,Costcentername,"
        sqlstring = sqlstring & " Totalamount,VATamount,Surchargeamt,OverallDiscount,Discount,Billamount,Remarks,Void,Adduser,Adddate,STORECODE, STOREDESC,Grntype)"
        sqlstring = sqlstring & " VALUES ('" & Trim(CMB_CATEGORY.Text) & "','" & CStr(GRNno(2)) & "','" & Trim(CStr(txt_Prnno.Text)) & "',"
        sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
        sqlstring = sqlstring & " '" & Trim(Txt_GRNNO.Text) & "',"
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "',"
        '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
        '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
        ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
        sqlstring = sqlstring & " " & Format(Val(txt_total.Text), "0.00") & "," & Format(Val(txt_totaltax.Text), "0.00") & "," & Format(Val(txt_Surchargeamt.Text), "0.00") & "," & Format(Val(TXT_OVERALLdiscount.Text), "0.00") & "," & Format(Val(txt_totdisc.Text), "0.00") & ","
        sqlstring = sqlstring & " " & Format(Val(txt_Billamount.Text), "0.00") & ","
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "',getDate(),"
        sqlstring = sqlstring & " '" & Trim(CStr(txt_Storecode.Text)) & "','" & Trim(CStr(txt_StoreDesc.Text)) & "',"
        sqlstring = sqlstring & "   'PRN')"
        INSERT(0) = sqlstring
        ' Dim Seq As Double = gconnection.getInvSeq(Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy"))
        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
            sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType,TRNS_SEQ)"
            sqlstring = sqlstring & " VALUES('" & CStr(GRNno(2)) & "','" & Trim(txt_Prnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(Txt_GRNNO.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
            AxfpSpread1.Col = 1
            Itemcode1 = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            Dim qty1 As Double = Format(Val(AxfpSpread1.Text), "0.000")
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 5
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 6
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","

            AxfpSpread1.Col = 7
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

            AxfpSpread1.Col = 8
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 9
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 10
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 11
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 12
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 13
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 14
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 15
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","

            sqlstring = sqlstring & "'" & Trim(CMB_CATEGORY.Text) & "',"
            sqlstring = sqlstring & "'" & Trim(gUsername) & "',getDate(),"
            sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
            sqlstring = sqlstring & "'PRN',DBO.INV_GETSEQNO('" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "'))"

            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
        Next

        gconnection.MoreTrans(INSERT)


    End Sub
    Private Sub voidoperation()
        Dim INSERT(0) As String
        Dim sqlstring As String

        GRNno = Split(Trim(txt_Prnno.Text), "/")

        sqlstring = "Update  Grn_header set "
        sqlstring = sqlstring & " void='Y'"
        sqlstring = sqlstring & "  where Grndetails='" + Trim(CStr(txt_Prnno.Text)) + "'"
        INSERT(0) = sqlstring
        sqlstring = "Update  Grn_details set  void='Y' where Grndetails='" + Trim(txt_Prnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring
        gconnection.MoreTrans(INSERT)
    End Sub
    Private Sub UpdateOperation()
        Dim INSERT(0) As String
        Dim sqlstring As String
        Dim itemcode1 As String
        GRNno = Split(Trim(txt_Prnno.Text), "/")

        sqlstring = "Update  Grn_header set "
        sqlstring = sqlstring & " category ='" & Trim(CMB_CATEGORY.Text) & "',"
        sqlstring = sqlstring & " Grndate= '" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
        sqlstring = sqlstring & "POno= '" & Trim(Txt_GRNNO.Text) & "',"
        sqlstring = sqlstring & "Supplierinvno= '" & Trim(CStr(txt_Supplierinvno.Text)) & "',Supplierdate='" & Format(CDate(dtp_Supplierinvdate.Value), "dd/MMM/yyyy") & "', "
        sqlstring = sqlstring & "Suppliercode= '" & Trim(CStr(txt_Suppliercode.Text)) & "',Suppliername='" & Trim(CStr(txt_Suppliername.Text)) & "',"
        '" & Trim(CStr(TypeCode(0))) & "','" & Trim(CStr(TypeCode(0))) & "',"  sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd/MMM/yyyy") & "','" & Format(CDate(dtp_Stockindate.Value), "dd/MMM/yyyy") & "',"
        '  sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
        ' sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
        sqlstring = sqlstring & "Totalamount= " & Format(Val(txt_total.Text), "0.00") & ",VATamount=" & Format(Val(txt_totaltax.Text), "0.00") & ",Surchargeamt=" & Format(Val(txt_Surchargeamt.Text), "0.00") & ",OverallDiscount=" & Format(Val(TXT_OVERALLdiscount.Text), "0.00") & ",Discount=" & Format(Val(txt_totdisc.Text), "0.00") & ","
        sqlstring = sqlstring & " Billamount=" & Format(Val(txt_Billamount.Text), "0.00") & ","
        sqlstring = sqlstring & "Remarks= '" & Trim(CStr(txt_Remarks.Text)) & "',Void='N',updateuser='" & Trim(gUsername) & "',updatedate=getDate(),"
        sqlstring = sqlstring & " storecode='" & Trim(CStr(txt_Storecode.Text)) & "',STOREDESC='" & Trim(CStr(txt_StoreDesc.Text)) & "',"
        sqlstring = sqlstring & " Grntype= 'GRN' where Grndetails='" + Trim(CStr(txt_Prnno.Text)) + "'"
        INSERT(0) = sqlstring
        sqlstring = "Delete from Grn_details where Grndetails='" + Trim(txt_Prnno.Text) + "'"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            AxfpSpread1.Col = 1
            sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,POno,Suppliercode,Suppliername,Itemcode,Itemname,"
            sqlstring = sqlstring & " UOM,Qty,Rate,baseamount,discper,TaxPer,Discount,TaxAmount,Amount,Taxcode,batchno,othcharge,voiditem,Category,Adduser,Adddate,STORECODE,STOREDESC,GrnType)"
            sqlstring = sqlstring & " VALUES('" & CStr(GRNno(2)) & "','" & Trim(txt_Prnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(Txt_GRNNO.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
            AxfpSpread1.Col = 1
            itemcode1 = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            Dim qty1 As Double = Format(Val(AxfpSpread1.Text), "0.000")
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 5
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 6
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","

            AxfpSpread1.Col = 7
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

            AxfpSpread1.Col = 8
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 9
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 10
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 11
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 12
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 13
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 14
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","
            AxfpSpread1.Col = 15
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.00") & ","

            sqlstring = sqlstring & "'" & Trim(CMB_CATEGORY.Text) & "',"
            sqlstring = sqlstring & "'" & Trim(gUsername) & "',getDate(),"
            sqlstring = sqlstring & "'" & Trim(txt_Storecode.Text) & "','" & Trim(txt_StoreDesc.Text) & "',"
            sqlstring = sqlstring & "'GRN')"

            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
        Next
        gconnection.MoreTrans(INSERT)

    End Sub
    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPUSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String
        If e.keyCode = Keys.Enter Then
            i = AxfpSpread1.ActiveRow
            'ITEMCODE
            If AxfpSpread1.ActiveCol = 1 Then

                If Trim(AxfpSpread1.Text) = "" Then
                    binditemcode()
                Else
                    SQL = " select itemcode,Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category='" + CMB_CATEGORY.Text + "' and isnull(M.void)='N' and isnull(I.storecode)='" + txt_Storecode.Text + "' and isnull(I.itemcode)='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                        AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                        AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                        SQL = "select taxperc,GLACCOUNTIN from Itemtaxtagging where itemcode='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE") + "'"
                        gconnection.getDataSet(SQL, "Itemtaxtagging")
                        If (gdataset.Tables("Itemtaxtagging").Rows.Count > 0) Then
                            AxfpSpread1.Col = 8
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("taxperc")
                            AxfpSpread1.Col = 12
                            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            AxfpSpread1.Text = gdataset.Tables("Itemtaxtagging").Rows(0).Item("GLACCOUNTIN")
                        Else
                            MessageBox.Show("Create TaxCode For Item :" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("ITEMCODE"), MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                        End If
                        AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(0, AxfpSpread1.ActiveRow)
                    End If
                End If
                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 2 Then
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemname()
                Else

                    SQL = " select itemcode,Itemname,uom from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category='" + CMB_CATEGORY.Text + "' and isnull(M.void)='N' and isnull(I.storecode)='" + txt_Storecode.Text + "' and isnull(I.itemname)='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                        AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                        AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                        AxfpSpread1.SetText(3, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))

                        AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(0, AxfpSpread1.ActiveRow)
                    End If
                End If
                'QTY
            ElseIf AxfpSpread1.ActiveCol = 4 Then
                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(3, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    CALCULATE()
                End If
                'RATE
            ElseIf AxfpSpread1.ActiveCol = 5 Then
                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                Else
                    AxfpSpread1.SetActiveCell(6, AxfpSpread1.ActiveRow)
                    CALCULATE()
                End If
                'DISC%
            ElseIf AxfpSpread1.ActiveCol = 7 Then
                If Trim(AxfpSpread1.Text) = "" Then
                    AxfpSpread1.SetActiveCell(0, AxfpSpread1.ActiveRow + 1)
                Else
                    AxfpSpread1.SetActiveCell(0, AxfpSpread1.ActiveRow + 1)
                    CALCULATE()
                End If

            End If
        End If

    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        clearoperation()
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub cmd_export_Click(sender As Object, e As EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VW_INV_GRNBILL"
        sqlstring = "select * from VW_INV_GRNBILL  WHERE GRNDETAILS LIKE 'GRN%'"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub

    End Sub

    Private Sub btn_auth_Click(sender As Object, e As EventArgs) Handles btn_auth.Click
        Authocheck("INVENTORY", "GRN Cum Purchase Bill", gUsername, "GRN_DETAILS", "GRNDETAILS", Me)

    End Sub


    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click

    End Sub

    Private Sub cmd_PONOhelp_Click(sender As Object, e As EventArgs) Handles cmd_PONOhelp.Click

        Try
            Dim voidStatus As String


            CATCODE = Split(CMB_CATEGORY.Text, "--->")
            '  CATCODE = Split(Trim(Mid(CMB_CATEGORY.Text, 1, 3)), "--->")
            If Trim(UCase(gShortname)) = "CGC" Then
                voidStatus = " and void ='N'"
            Else
                voidStatus = ""
            End If

            gSQLString = "SELECT Grndetails,Grndate,SUPPLIERNAME FROM Grn_header"
            M_WhereCondition = " Where Isnull(GRNTYPE,'')='GRN' " & voidStatus & "  AND ISNULL(GRNDETAILS,'') LIKE '%" & Trim(Mid(CATCODE(0), 1, 3)) & "%'"
            M_ORDERBY = "  order by Grndate desc "
            Dim vform As New List_Operation
            vform.Field = "GRNDETAILS,GRNDATE,SUPPLIERNAME"
            vform.vFormatstring1 = "       GRN NO                     |         GRN DATE                     |     SUPPLIERNAME                           "
            vform.vCaption = "GRN CUM PURCHASE BILL HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Prnno.Text = Trim(vform.keyfield & "")
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Call txt_Grnno_Validated(txt_Grnno.Text, e)
                '  Call Grid_lock()
            End If
            vform.Close()
            M_ORDERBY = ""
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_Grnnohelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_Grnnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Grnnohelp.Click

    End Sub

  
    Private Sub Txt_GRNNO_Validated(sender As Object, e As EventArgs) Handles Txt_GRNNO.Validated
        Dim I, J, K As Integer
        Dim vString, sqlstring As String
        Dim GRNDATE As Date
        Dim vTypeseqno, Clsquantity As Double
        Dim vGroupseqno As Double
        Dim dt As New DataTable
        If Trim(Txt_GRNNO.Text) <> "" Then
            Try
                sqlstring = "SELECT  ISNULL(GRNNO,'') AS GRNNO,ISNULL(GRNDETAILS,'') AS GRNDETAILS,ISNULL(PONO,'') AS PONO,GRNDATE,ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,"
                sqlstring = sqlstring & " SUPPLIERDATE,ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE,ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,ISNULL(CATEGORY,'') CATEGORY, "
                sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,ISNULL(REMARKS,'') AS REMARKS,"
                sqlstring = sqlstring & " ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,ISNULL(voiddate,'') AS voiddate,"
                sqlstring = sqlstring & " ISNULL(STORECODE,'') STORECODE , ISNULL(STOREDESC,'MAINSTORE') STOREDESC, ISNULL(OVERALLDISCOUNT,0) OVERALLDISCOUNT FROM GRN_HEADER"
                sqlstring = sqlstring & " WHERE ( Grndetails='" & Trim(Txt_GRNNO.Text) & "') "
                sqlstring = sqlstring & " and   isnull(GrnType,'')='GRN'"
                gconnection.getDataSet(sqlstring, "GRNHEADER")
                '''************************************************* SELECT record from Grn_header *********************************************''''                
                If gdataset.Tables("GRNHEADER").Rows.Count > 0 Then
                    'Call GridUnLock()
                    Cmd_Add.Text = "Update[F7]"
                    Me.Txt_GRNNO.ReadOnly = True
                    If gvendorlink = "Y" Then
                        txt_Suppliercode.Enabled = False
                        cmd_Suppliercodehelp.Enabled = False
                    End If
                    Dim SQL = "SELECT * FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "'"
                    gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                    If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                        CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY")) + "--->" + Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                    End If
                    'CMB_CATEGORY.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("CATEGORY"))
                    '  Txt_PONo.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO"))
                    '  Dim grnTYPE() As String = Split(Txt_PONo.Text, "/")
                    'If grnTYPE(0) = "CCL" Then
                    '    Txt_PONo.Show()
                    '    Label4.Show()
                    '    cmd_PONOhelp.Show()
                    '    CmbGrnType.Text = "PO"
                    'Else
                    '    CmbGrnType.Text = "SPONSOR"
                    '    LBL_SPONSOR.Show()
                    '    TXT_Sponsor.Show()
                    '    cmd_SPONhelp.Show()
                    '    TXT_Sponsor.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("PONO"))
                    'End If
                    Txt_GRNNO.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDETAILS"))



                    dtp_Grndate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDATE")), "dd/MMM/yyyy")
                    'dtp_Grndate.Enabled = False
                    txt_Supplierinvno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERINVNO"))
                    dtp_Supplierinvdate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERDATE")), "dd/MMM/yyyy")
                    txt_Suppliercode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERCODE"))
                    txt_Suppliername.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERNAME"))
                    txt_Storecode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("STORECODE"))
                    txt_StoreDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("STOREDESC"))
                    TXT_OVERALLdiscount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("OVERALLdiscount")), "0.000")
                    txt_Surchargeamt.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("SURCHARGEAMT")), "0.000")
                    txt_Billamount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("BILLAMOUNT")), "0.000")
                    txt_Remarks.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("REMARKS"))
                    If Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("VOID")) = "Y" Then
                        Cmd_Add.Enabled = False
                        Cmd_Freeze.Enabled = False
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("voiddate")), "dd/MMM/yyyy")

                    End If
                    '''************************************************* SELECT record from Grn_details *********************************************''''                
                    Dim vtmpitemcode, strsql As String
                    sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,isnull(baseamount,0) as baseamount,isnull(discper,0) as discper,isnull(taxcode,'') as taxcode,isnull(batchno,'') as batchno,"
                    sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(TAXPER,0) AS TAXPER,ISNULL(TAXAMOUNT,0) AS TAXAMOUNT,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,ISNULL(AMOUNTAFTERDISCOUNT,0) AS AMOUNTAFTERDISCOUNT,"
                    sqlstring = sqlstring & " ISNULL(VOIDITEM,'') AS VOIDITEM , isnull(OTHCHARGE,0) AS OTHCHARGE,isnull(freeqty,0) AS freeqty,ISNULL(FQUOM,'') AS FQUOM FROM GRN_DETAILS WHERE  GRNDETAILS ='" & Trim(Txt_GRNNO.Text) & "'"
                    sqlstring = sqlstring & " ORDER BY AUTOID "
                    gconnection.getDataSet(sqlstring, "GRNDETAILS")
                    If gdataset.Tables("GRNDETAILS").Rows.Count > 0 Then
                        For I = 1 To gdataset.Tables("GRNDETAILS").Rows.Count
                            AxfpSpread1.SetText(1, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE")))
                            vtmpitemcode = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMNAME")))
                            AxfpSpread1.Col = 3
                            Dim sql1 As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("GRNDETAILS").Rows(J).Item("itemcode") + "'"

                            gconnection.getDataSet(sql1, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1
                                AxfpSpread1.Row = I
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Col = 18
                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Col = 3
                            Next Z

                            ' AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))

                            '    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                            AxfpSpread1.SetText(3, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM")))

                            '  AxfpSpread1.Text = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                            AxfpSpread1.SetText(4, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("QTY")))
                            AxfpSpread1.SetText(5, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("RATE")), "0.000"))
                            AxfpSpread1.SetText(6, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("baseamount")), "0.000"))
                            '            ssgrid.SetText(7, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("PROFITPER")), "0.000"))
                            AxfpSpread1.SetText(7, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("discper")), "0.000"))
                            AxfpSpread1.SetText(8, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("discount")), "0.000"))
                            AxfpSpread1.SetText(9, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("amountafterdiscount")), "0.000"))

                            AxfpSpread1.SetText(11, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("taxper")), "0.000"))
                            AxfpSpread1.SetText(12, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("taxamount")), "0.000"))
                            AxfpSpread1.SetText(13, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("amount")), "0.000"))
                            AxfpSpread1.SetText(10, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("taxcode"))
                            AxfpSpread1.SetText(14, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("batchno"))
                            AxfpSpread1.SetText(15, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("othcharge")), "0.000"))
                            AxfpSpread1.SetText(16, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("voiditem"))
                            AxfpSpread1.SetText(17, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("FREEQTY")))
                            AxfpSpread1.SetText(18, I, gdataset.Tables("GRNDETAILS").Rows(J).Item("FQUOM"))
                            '           ssgrid.SetText(11, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("SALERATE")), "0.000"))
                            '          ssgrid.SetText(12, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("DBLAMOUNT")), "0.000"))
                            '         ssgrid.SetText(13, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("DBLUOM")))
                            'ssgrid.SetText(14, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("HIGHRATIO")), "0.000"))
                            'AxfpSpread1.SetText(11, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("VOIDITEM")))
                            'AxfpSpread1.SetText(10, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("othcharge")))
                            '        ssgrid.SetText(19, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("FREEQTY")))
                            GRNDATE = Format(CDate(dtp_Grndate.Value), "dd/MMM/yyyy")
                            'It's getting so late so commanded

                            '  Clsquantity = ClosingQuantity_Date(vtmpitemcode, Trim(txt_Storecode.Text), Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM")), GRNDATE)
                            ' Clsquantity = ClosingQuantity(vtmpitemcode, GetMainStore())
                            'ssgrid.SetText(17, I, Clsquantity)
                            '  CMB_CATEGORY.Text = gdataset.Tables("GRNDETAILS").Rows(J).Item("CATEGORY")
                            J = J + 1
                        Next
                    End If

                    'TotalCount = gdataset.Tables("GRNDETAILS").Rows.Count
                    CALCULATE()
                    AxfpSpread1.SetActiveCell(1, 1)
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Cmd_Add.Text = "Update[F7]"

                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid GRN No : txt_Grnno_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "GRN Cum Purchase Bill"

        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Me.Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    ' Me.cmd_auth.Enabled = True
                End If
            Next
        End If
    End Sub
End Class