Imports System.Data
Imports System.io
Imports System.data.SqlClient
Public Class GlobalClass
    Public sqlconnection, sqlconnection1, sqlconnection_log As String
    Public Myconn, Myconn1 As New SqlConnection
    Dim MyTrans As SqlTransaction
    Dim MyTrans1 As SqlTransaction
    Dim Cmd As New SqlCommand
    Dim DataString As String
    Dim ssql, sqlstring As String
    Public Sub FocusSetting(ByVal parentCtr As Control)

        Dim ctr As Control

        For Each ctr In parentCtr.Controls

            If TypeOf ctr Is Button Then

                ctr.Visible = False

            End If
            If TypeOf ctr Is GroupBox Then 'FOR nested containers

                Dim CTRL As Control
                For Each CTRL In ctr.Controls
                    If TypeOf CTRL Is Button Then
                        CTRL.Visible = False
                    End If
                Next

            End If



        Next



    End Sub
    Public Sub FORM_MCA(ByVal FORNAME, ByVal TABLENAME, ByVal WHERE, ByVal type)
        Dim DOCNO As String
        If type = "I" Then
            sqlstring = "SELECT * FROM MCARIGHTS WHERE Modulename='INVENTORY' AND FORMNAME='" & FORNAME & "' and (isnull(CHECKER,'N')='Y'  OR ISNULL(AUTHORIZER,'N')='Y')"
            getDataSet(sqlstring, "USERADMIN")
            If gdataset.Tables("USERADMIN").Rows.Count > 0 Then
                If gUserCategory <> "S" And gUserCategory <> "A" Then
                    sqlstring = "UPDATE " & TABLENAME & " SET Authorised='N', MCA='M' WHERE " & WHERE & ""
                    dataOperation(6, sqlstring, "MCA")
                Else
                    sqlstring = "UPDATE " & TABLENAME & " SET Authorised='Y', MCA='M' WHERE " & WHERE & ""
                    dataOperation(6, sqlstring, "MCA")

                    If UCase(Trim(TABLENAME)) = "GRN_DETAILS" Or UCase(Trim(TABLENAME)) = "STOCKADJUSTDETAILS" Or UCase(Trim(TABLENAME)) = "STOCKISSUEDETAIL" Or UCase(Trim(TABLENAME)) = "STOCKDMGDETAIL" Or UCase(Trim(TABLENAME)) = "PRN_DETAILS" Or UCase(Trim(TABLENAME)) = "STOCKCONSUMPTION_1" Then

                        If UCase(Trim(TABLENAME)) = "GRN_DETAILS" Then
                            DOCNO = "GRNDETAILS"
                        ElseIf UCase(Trim(TABLENAME)) = "STOCKADJUSTDETAILS" Or UCase(Trim(TABLENAME)) = "STOCKDMGDETAIL" Or UCase(Trim(TABLENAME)) = "STOCKISSUEDETAIL" Then
                            DOCNO = "DOCDETAILS"
                        ElseIf UCase(Trim(TABLENAME)) = "PRN_DETAILS" Then
                            DOCNO = "PRNDETAILS"
                        ElseIf UCase(Trim(TABLENAME)) = "STOCKCONSUMPTION_1" Then
                            DOCNO = "DOCNO"

                        End If

                        mysql = "SELECT DISTINCT ITEMCODE," & DOCNO & " as DOCNO FROM " & TABLENAME & " WHERE " & WHERE & ""
                        getDataSet(mysql, "GRN")
                        'If gdataset.Tables("GRN").Rows.Count > 0 Then
                        '    Call updateAuth(gdataset.Tables("GRN"))
                        'End If
                    End If

                    If FORNAME = "Purchase Order" And TABLENAME = "PO_HDR" And TO_CHK_MCA_YN(FORNAME) = True Then
                        sqlstring = "UPDATE " & TABLENAME & " SET postatus='RELEASED' WHERE " & WHERE & ""
                        dataOperation(6, sqlstring, "MCA")
                    End If
                End If

            Else
                sqlstring = "UPDATE " & TABLENAME & " SET Authorised='Y', MCA='M' WHERE " & WHERE & ""
                dataOperation(6, sqlstring, "MCA")

                If UCase(Trim(TABLENAME)) = "GRN_DETAILS" Or UCase(Trim(TABLENAME)) = "STOCKADJUSTDETAILS" Or UCase(Trim(TABLENAME)) = "STOCKISSUEDETAIL" Or UCase(Trim(TABLENAME)) = "STOCKDMGDETAIL" Or UCase(Trim(TABLENAME)) = "PRN_DETAILS" Or UCase(Trim(TABLENAME)) = "STOCKCONSUMPTION_1" Then

                    If UCase(Trim(TABLENAME)) = "GRN_DETAILS" Then
                        DOCNO = "GRNDETAILS"
                    ElseIf UCase(Trim(TABLENAME)) = "STOCKADJUSTDETAILS" Or UCase(Trim(TABLENAME)) = "STOCKDMGDETAIL" Or UCase(Trim(TABLENAME)) = "STOCKISSUEDETAIL" Then
                        DOCNO = "DOCDETAILS"
                    ElseIf UCase(Trim(TABLENAME)) = "PRN_DETAILS" Then
                        DOCNO = "PRNDETAILS"
                    ElseIf UCase(Trim(TABLENAME)) = "STOCKCONSUMPTION_1" Then
                        DOCNO = "DOCNO"

                    End If

                    mysql = "SELECT DISTINCT ITEMCODE," & DOCNO & " as DOCNO FROM " & TABLENAME & " WHERE " & WHERE & ""
                    getDataSet(mysql, "GRN")


                    getDataSet(mysql, "GRN")
                    'If gdataset.Tables("GRN").Rows.Count > 0 Then
                    '    Call updateAuth(gdataset.Tables("GRN"))
                    'End If
                End If
                If FORNAME = "Purchase Order" And TABLENAME = "PO_HDR" And TO_CHK_MCA_YN(FORNAME) = True Then
                    sqlstring = "UPDATE " & TABLENAME & " SET postatus='RELEASED' WHERE " & WHERE & ""
                    dataOperation(6, sqlstring, "MCA")
                End If
            End If
        ElseIf type = "D" Then
            sqlstring = "UPDATE " & TABLENAME & " SET Authorised='D', MCA='" & gUserCategory & "' WHERE " & WHERE & ""
            dataOperation(6, sqlstring, "MCA")
        End If
    End Sub

    Public Function FillTableFromDataSet(ByVal Dt As DataTable, ByVal TableName As String) As String

        Dim SqlConnection As New SqlConnection
        SqlConnection.ConnectionString = Getconnection()
        SqlConnection.Open()



        Using bulkCopy As SqlBulkCopy = _
            New SqlBulkCopy(SqlConnection)
            bulkCopy.DestinationTableName = TableName
            bulkCopy.BulkCopyTimeout = 1000000000
            Try
                ' Write from the source to the destination.
                bulkCopy.WriteToServer(Dt)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Console.WriteLine(ex.Message)
            Finally
                SqlConnection.Close()
            End Try
        End Using

    End Function
     
    Public Enum genum
        Add = 1
        Update = 2
        Freeze = 3
        unFreeze = 4
        View = 5
        Delete = 6
    End Enum

    Public Function getMonthName(ByVal intMonth As Int16) As String
        Select Case intMonth
            Case 4
                Return "APRIL"
            Case 5
                Return "MAY"
            Case 6
                Return "JUN"
            Case 7
                Return "JULY"
            Case 8
                Return "AUGUST"
            Case 9
                Return "SEPTEMBER"
            Case 10
                Return "OCTOBER"
            Case 11
                Return "NOVEMBER"
            Case 12
                Return "DECEMBER"
            Case 1
                Return "JANUARY"
            Case 2
                Return "FEBRUARY"
            Case 3
                Return "MARCH"
            Case Else
                Return "Not Found For " & Trim(CStr(intMonth))
        End Select
    End Function

    Public Function getMonthNo(ByVal strMonth As String) As Int16
        Select Case strMonth
            Case "APRIL"
                Return 4
            Case "MAY"
                Return 5
            Case "JUNE"
                Return 6
            Case "JULY"
                Return 7
            Case "AUGUST"
                Return 8
            Case "SEPTEMBER"
                Return 9
            Case "OCTOBER"
                Return 10
            Case "NOVEMBER"
                Return 11
            Case "DECEMBER"
                Return 12
            Case "JANUARY"
                Return 1
            Case "FEBRUARY"
                Return 2
            Case "MARCH"
                Return 3
        End Select
    End Function
    Public Function checkBdate(TRNSDATE As DateTime, Optional ByVal storecode As String = "", Optional ByVal storecode1 As String = "") As Boolean
        Dim curBdate, adjdate As DateTime
        Dim resu As Boolean
        RESU1 = False

        sqlstring = "select [modulename] from [dayendmodulesetup] WHERE modulename='INVENTORY' AND [closetype]='DAILY'"
        getDataSet(sqlstring, "dayendmodulesetup")
        'If (gdataset.Tables("dayendmodulesetup").Rows.Count = 0) Then
        '    Return True
        '    Exit Function
        'End If

        sqlstring = "select cast(bdate as date) as bdate from Businessdate"
        getDataSet(sqlstring, "Businessdate")

        If gShortname <> "MGC" Or gShortname <> "CFC" Then
            If (gdataset.Tables("Businessdate").Rows.Count > 0) Then
                curBdate = CDate(gdataset.Tables("Businessdate").Rows(0).Item("bdate"))
                If gShortname = "KGA" Then
                    sqlstring = "SELECT  isnull(MAX(DOCDATE),'" & gFinancalyearStart & "')-2  AS DOCDATE FROM  STOCKADJUSTDETAILS WHERE ISNULL(Void,'N')<>'Y' AND STORECODE IN('" & storecode & "','" & storecode1 & "') AND    Adduser  IS NOT NULL  AND   Adddate  IS NOT NULL AND ISNULL( TTYPE,'') <>'C'"
                Else
                    sqlstring = "SELECT  isnull(MAX(DOCDATE ),'" & gFinancalyearStart & "')-2  AS DOCDATE FROM  STOCKADJUSTDETAILS WHERE ISNULL(Void,'N')<>'Y' AND STORECODE IN('" & storecode & "','" & storecode1 & "')"
                End If

                getDataSet(sqlstring, "ADJUSTMENTDATE")
                If (gdataset.Tables("ADJUSTMENTDATE").Rows.Count > 0) Then
                    adjdate = CDate(gdataset.Tables("ADJUSTMENTDATE").Rows(0).Item("DOCDATE"))
                    If adjdate > curBdate Then
                        curBdate = adjdate
                        RESU1 = True
                    Else
                        RESU1 = False

                    End If
                End If
                'End If
            Else
                curBdate = gFinancialyearStart
            End If
        End If

        Format(curBdate, "yyyy/MM/dd")
        Format(TRNSDATE, "yyyy/MM/dd")

        If gShortname = "MRC" Then
            If DateDiff(DateInterval.Day, curBdate, TRNSDATE) = 1 Then
                Return False
                Exit Function
            Else
                Return True
                Exit Function
            End If


        End If


        If DateDiff(DateInterval.Day, curBdate, TRNSDATE) <= 0 Then

            Return True
            Exit Function
        Else
            ' Return False
            ' Exit Function
        End If





        curBdate = gFinancialyearEnding


        If DateDiff(DateInterval.Day, curBdate, TRNSDATE) > 0 Then
            MsgBox("Financial Year closed..")
            resu = True
            Exit Function
        Else
            resu = False

        End If

        If DateDiff(DateInterval.Day, gFinancialyearStart, TRNSDATE) >= 0 And DateDiff(DateInterval.Day, gFinancialyearEnding, TRNSDATE) <= 0 Then
            resu = False
        Else
            MsgBox("Financial Year closed..")
            resu = True
        End If

        sqlstring = "select distinct storelocationcode from SUBSTORECONSUMPTIONDETAIL where docdetails in (select voucherno from journalentry where vouchercategory ='CONSUMPTION' and cast(voucherdate as date)>= '" & Format(TRNSDATE, "dd MMM yyyy") & "' and isnull(void,'N')<>'Y') and storelocationcode='" & storecode & "' AND ISNULL(VOID,'N')<>'Y'"
        getDataSet(sqlstring, "lock")
        If (gdataset.Tables("lock").Rows.Count > 0) Then
            MsgBox("Consumption Already Posted for " & storecode & " Store. Any updation not Allowed", MsgBoxStyle.Exclamation, gCompanyname)
            resu = True
        Else
            resu = False
        End If
        Return resu

    End Function

    Public Function getInvSeq(TRNSDATE As DateTime) As Double
        Dim cuDate, nDate As DateTime
        Dim cuDate1, nDate1, TRNSDATE1, day As String
        Dim Tdate() As String
        Dim trns_seq, Nexttrns_seq As String
        Dim seq As Integer = 0
        Dim INSERT(0) As String
        Dim sqlstring As String
        Dim a As Double
        'mydt.ToString("dd MMM yy tt")
        'insert(0) = sqlstring
        sqlstring = "select TOP 1  isnull(TRNS_SEQ,0) as TRNS_SEQ,trndate from closingqty where   CONVERT(VARCHAR(11), Trndate, 106)= '" & Format(TRNSDATE, "dd MMM yyyy") & "' order by trndate desc,AUTOID desc "
        getDataSet(sqlstring, "TRNS_SEQ")
        If (gdataset.Tables("TRNS_SEQ").Rows.Count > 0) Then

            If Val(gdataset.Tables("TRNS_SEQ").Rows(0).Item("TRNS_SEQ")) <> 0 Then
                cuDate = Format(gdataset.Tables("TRNS_SEQ").Rows(0).Item("trndate"), "dd/MMM/yyyy")
                cuDate1 = cuDate.ToString("dd/MM/yy")
                TRNSDATE = Format(TRNSDATE, "dd/MMM/yyyy")
                TRNSDATE1 = TRNSDATE.ToString("dd/MM/yy")


                If cuDate1 = TRNSDATE1 Then
                    Nexttrns_seq = Val(gdataset.Tables("TRNS_SEQ").Rows(0).Item("TRNS_SEQ"))
                    Nexttrns_seq = Nexttrns_seq + 1
                Else
                    Tdate = Split(Trim(cuDate1), "/")
                    Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
                    Nexttrns_seq = Nexttrns_seq & Format(1, "00000")
                End If
            Else
                TRNSDATE = Format(TRNSDATE, "dd/MMM/yyyy")
                TRNSDATE1 = TRNSDATE.ToString("dd/MM/yy")
                Tdate = Split(Trim(TRNSDATE1), "/")
                Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
                Nexttrns_seq = Nexttrns_seq & Format(1, "00000")
            End If


        Else
            TRNSDATE = Format(TRNSDATE, "dd/MMM/yyyy")
            TRNSDATE1 = TRNSDATE.ToString("dd/MM/yy")
            Tdate = Split(Trim(TRNSDATE1), "/")
            Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
            Nexttrns_seq = Nexttrns_seq & Format(1, "00000")


        End If
        'MoreTrans(INSERT)
        Return Nexttrns_seq
    End Function
    'Public Function getInvSeq() As Double
    '    Try
    '        Dim sqlstring As String
    '        gcommand = New SqlCommand

    '        sqlstring = "select isnull(max(TRNS_SEQ),0) from InvSeq"
    '        openConnection()
    '        gcommand.CommandText = sqlstring
    '        gcommand.CommandType = CommandType.Text
    '        gcommand.Connection = Myconn
    '        gdreader = gcommand.ExecuteReader
    '        If gdreader.Read Then
    '            If gdreader(0) Is System.DBNull.Value Then
    '                GInvSeq = 0
    '                gdreader.Close()
    '                gcommand.Dispose()
    '                closeConnection()
    '            Else
    '                GInvSeq = gdreader(0) + 1
    '                gdreader.Close()
    '                gcommand.Dispose()
    '                closeConnection()
    '            End If
    '        Else
    '            GInvSeq = 0
    '            gdreader.Close()
    '            gcommand.Dispose()
    '            closeConnection()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '        Exit Function
    '    End Try
    '    Return GInvSeq
    'End Function
    Public Function STORELOCATION(ByVal STORECODE As String) As String
        Dim sqlstring, STRLOCATION As String
        sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & STORECODE & "' AND ISNULL(FREEZE,'') <> 'Y'"
        getDataSet(sqlstring, "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            STRLOCATION = (gdataset.Tables("STOREMASTER").Rows(0).Item("STOREDESC") & "")
        End If
        Return STRLOCATION
    End Function

    Public Sub ManualUpdateNew()
        Dim cuDate, nDate, TRNSDATE As DateTime
        Dim cuDate1, nDate1 As String
        Dim Tdate() As String
        Dim Nexttrns_seq, sqlstring As String
        Dim seq As Integer = 0
        Dim INSERT(0) As String
        Dim trns_seq, TRNSDATE1 As String
        Dim I, J, K As Integer
        Dim ttype() As String
        Dim fLAG As Boolean
        'mydt.ToString("dd MMM yy tt")
        Try

            INSERT(0) = sqlstring

            sqlstring = "with T as (select docdetails,docdate,itemcode,uom,qty,rate,storecode,trns_seq,ttype,[priority] from TrnsView where  right(left(convert(varchar, cast(docdate  as date), 112),8),6)<>LEFT(isnull(trns_seq,0),6) union all"
            sqlstring = sqlstring & " select docdetails,docdate,itemcode,uom,qty,rate,storecode,trns_seq,ttype,[priority] from TrnsView where trns_seq in (select trns_seq from TrnsView where ttype not in ('ISSUE', 'RECEIEVE','TRANSFER_FROM','TRANSFER_TO')  group by trns_seq having count(trns_seq)>1))"
            sqlstring = sqlstring & " select docdetails,docdate,itemcode,uom,qty,rate,storecode,trns_seq,ttype,[priority] from  T   "

            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                sqlstring = sqlstring & " where t.docdate>='2016-01-01 00:00:00.000' "
            End If
            sqlstring = sqlstring & " group by docdetails,docdate,itemcode,uom,qty,rate,storecode,trns_seq,ttype,[priority] order by CAST(CONVERT(VARCHAR(11),t.docdate ,106) AS DATETIME),[priority]"
            getDataSet(sqlstring, "TrnsView")
            If (gdataset.Tables("TrnsView").Rows.Count > 0) Then
                For I = 0 To gdataset.Tables("TrnsView").Rows.Count - 1
                    Try

                        sqlstring = "select MAX(TRNS_SEQ) AS TRNS_SEQ from TrnsView where   CONVERT(VARCHAR(11), docdate, 106)= '" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd MMM yyyy") & "'"
                        getDataSet(sqlstring, "TRNS_SEQ")

                        If (gdataset.Tables("TRNS_SEQ").Rows.Count > 0) Then
                            cuDate = Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy")
                            cuDate1 = cuDate.ToString("dd/MM/yy")
                            Nexttrns_seq = Val(gdataset.Tables("TRNS_SEQ").Rows(0).Item("TRNS_SEQ"))

                            If Nexttrns_seq = 0 Or Mid(Nexttrns_seq, 1, 6) <> Val(cuDate.ToString("yyMMdd")) Then

                                sqlstring = "select isnull(MAX(TRNS_SEQ),0) AS TRNS_SEQ from TrnsView where   LEFT(trns_seq,6)= '" & Val(cuDate.ToString("yyMMdd")) & "'"
                                getDataSet(sqlstring, "TRNS")
                                If (gdataset.Tables("TRNS").Rows.Count > 0) Then
                                    Nexttrns_seq = Val(gdataset.Tables("TRNS").Rows(0).Item("TRNS_SEQ"))

                                    If Nexttrns_seq = 0 Then
                                        Tdate = Split(Trim(cuDate1), "/")
                                        Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
                                        Nexttrns_seq = Nexttrns_seq & Format(1, "00000")
                                    Else
                                        Nexttrns_seq = Nexttrns_seq + 1
                                    End If

                                Else
                                    Tdate = Split(Trim(cuDate1), "/")
                                    Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
                                    Nexttrns_seq = Nexttrns_seq & Format(1, "00000")
                                End If
                            Else
                                Nexttrns_seq = Nexttrns_seq + 1
                            End If
                        Else
                            TRNSDATE = Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy")
                            TRNSDATE1 = TRNSDATE.ToString("dd/MM/yy")
                            Tdate = Split(Trim(TRNSDATE1), "/")
                            Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
                            Nexttrns_seq = Nexttrns_seq & Format(1, "00000")
                        End If

                        ttype = Split(Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")), "/")

                        If ttype(0) = "Openning" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "Openning" Then
                            sqlstring = "update inv_InventoryOpenningstock set trns_seq=" & Val(Nexttrns_seq) & " where storecode='" & gdataset.Tables("TrnsView").Rows(I).Item("storecode") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and 'Openning'='" & gdataset.Tables("TrnsView").Rows(I).Item("ttype") & "'"
                            dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "GRN" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "GRN" Then
                            sqlstring = "update Grn_details set trns_seq=" & Val(Nexttrns_seq) & " where grndetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and grndate='" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "'"
                            dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "PRN" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "PRN" Then
                            sqlstring = "update Prn_details set trns_seq=" & Val(Nexttrns_seq) & " where Prndetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and Prndate='" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "'"
                            dataOperation(6, sqlstring, )
                        ElseIf ttype(0) = "ISSUE" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "ISSUE" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "RECEIEVE" Then

                            If Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "ISSUE" Then

                                sqlstring = "update STOCKISSUEdetail set trns_seq=" & Val(Nexttrns_seq) & " where STORELOCATIONCODE='" + Trim(gdataset.Tables("TrnsView").Rows(I).Item("STORECODE")) + "' AND  docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND    itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            Else
                                sqlstring = "update STOCKISSUEdetail set trns_seq=" & Val(Nexttrns_seq) & " where OPSTORELOCATIONCODE='" + Trim(gdataset.Tables("TrnsView").Rows(I).Item("STORECODE")) + "' AND  docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND    itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            End If

                            'sqlstring = "update STOCKISSUEdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "ADJ" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "ADJUSTMENT1" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "ADJUSTMENT" Then
                            sqlstring = "update STOCKADJUSTDETAILs set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "CON" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "CONSUME" Then
                            sqlstring = "update stockConsumption_1 set trns_seq=" & Val(Nexttrns_seq) & " where docNO='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            dataOperation(6, sqlstring, )

                            sqlstring = "update StockConsumption_detail set trns_seq=" & Val(Nexttrns_seq) & " where docNO='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "DMG" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "DAMAGE" Then

                            sqlstring = "update STOCKDMGdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "RET" Or ttype(0) = "TRF" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "TRANSFER_TO" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "TRANSFER_FROM" Then

                            sqlstring = "update STOCKTRANSFERdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
                            dataOperation(6, sqlstring, )

                        ElseIf ttype(0) = "KOT" Or ttype(0) = "DBAR" Or ttype(0) = "KBAR" Or ttype(0) = "BARD" Or Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype")) = "KOT" Then
                            sqlstring = "update SUBSTORECONSUMPTIONDETAIL set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "'  and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"

                            dataOperation(6, sqlstring, )
                        End If
                    Catch ex As Exception
                        ' Continue For
                    End Try
                Next
            End If



            Dim closingstock, closingvalue, openningstock, openningvalue, qty, rate, WRATE, TRNrate, TRNqty, TRNvalue As Double

            Dim storecode, Storestatus, trntype, itemcode, uom, trnno, sql1 As String
            Dim TrnDATE As DateTime
            Dim RateFleg As String = "P"
            Dim priority As Integer
            Dim STOCKUOM, RETURNFLAG As String
            Dim CONVVALUE As Double
            Dim precise As Double

            sqlstring = "select * from TrnsView "

            If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
                sqlstring = sqlstring & " where docdate>='2016-01-01 00:00:00.000'"
            End If
            'sqlstring = sqlstring & " order  by CAST(CONVERT(VARCHAR(11),docdate ,106) AS DATETIME),priority"
            sqlstring = sqlstring & " order  by trns_seq"
            getDataSet(sqlstring, "TrnsView")
            If (gdataset.Tables("TrnsView").Rows.Count > 0) Then

                sqlstring = "truncate  table closingqty"

                dataOperation(6, sqlstring, )


                For I = 0 To gdataset.Tables("TrnsView").Rows.Count - 1
                    Try


                        STOCKUOM = 0
                        CONVVALUE = 1
                        closingstock = 0
                        closingvalue = 0
                        openningstock = 0
                        openningvalue = 0
                        qty = 0
                        rate = 0
                        trntype = ""

                        itemcode = Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode"))
                        'If itemcode <> "BC101" Then
                        '    '  Continue For
                        'Else
                        '    MsgBox("")

                        'End If

                        itemcode = Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode"))
                        uom = Trim(gdataset.Tables("TrnsView").Rows(I).Item("uom"))
                        trnno = Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails"))
                        storecode = Trim(gdataset.Tables("TrnsView").Rows(I).Item("storecode"))
                        TrnDATE = CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate"))
                        trntype = Trim(gdataset.Tables("TrnsView").Rows(I).Item("ttype"))
                        trns_seq = Val(gdataset.Tables("TrnsView").Rows(I).Item("trns_seq"))
                        priority = Val(gdataset.Tables("TrnsView").Rows(I).Item("priority"))


                        sqlstring = "select isnull(Stockuom,'') from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
                        STOCKUOM = getvalue(sqlstring)
                        If STOCKUOM = "" Then
chkstock:                   GmoduleName = "Item Master"
                            Dim uomr As New Frm_InventoryItemmastervb
                            uomr.ItemcodeM = itemcode
                            MsgBox("Please define stock uom for item!")
                            uomr.ShowDialog()
                            sqlstring = "select isnull(Stockuom,'') from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
                            STOCKUOM = getvalue(sqlstring)
                            If STOCKUOM = "" Then
                                Dim result As Integer = MessageBox.Show("Please define stock uom for item to complete the manual updation process!", "Alert", MessageBoxButtons.YesNo)
                                If result = DialogResult.Yes Then
                                    GoTo chkstock
                                Else
                                    MessageBox.Show("Please define stock uom of item to complete the manual updation process!", "Alert")
                                    GoTo chkstock
                                End If
                            End If

                        End If
                        sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
                        getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                            precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                        Else
                            MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom + "  for Itemcode=" + itemcode, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            ' MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            GmoduleName = "Uom Convertion Entry"
                            Dim uomr As New FrmUOMRelation
                            'uomr.MdiParent = Me
                            uomr.baseuom = STOCKUOM
                            uomr.transuom = uom
                            uomr.ShowDialog()
                            sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
                            STOCKUOM = getvalue(sqlstring)
                            sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
                            getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then

                                sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
                                STOCKUOM = getvalue(sqlstring)
                                sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
                                getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                    precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                End If


                            Else

                                Exit Sub
                            End If
                        End If



                        If Trim(trntype.ToUpper()) <> "OPENNING" Then
                            sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and cast(convert(varchar(11),trndate,106)as datetime)<='" & Format(CDate(TrnDATE), "yyyy-MM-dd") & "'  order by TRNS_SEQ DESC"
                            ' sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and trns_seq<" & trns_seq & " order by trns_seq desc "
                            getDataSet(sqlstring, "closingqty")

                            If (gdataset.Tables("closingqty").Rows.Count > 0) Then

                                openningstock = Val(gdataset.Tables("closingqty").Rows(0).Item("closingstock"))
                                openningvalue = Val(gdataset.Tables("closingqty").Rows(0).Item("closingvalue"))

                                qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("QTY"))

                                ''----------------------------------------------------------------------------------------------------------------------------------------


                                qty = qty / CONVVALUE
                                ''-----------------------------------------------------------------------------------------------------------------------------------------------------------
                                If Trim(trntype.ToUpper()) = "GRN" Then

                                    sql1 = " select isnull(rateflag,'P') as rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
                                    sql1 = sql1 & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" & itemcode & "'  "
                                    getDataSet(sql1, "RATEFLAG")
                                    If (gdataset.Tables("RATEFLAG").Rows.Count > 0) Then
                                        RateFleg = gdataset.Tables("RATEFLAG").Rows(0).Item("RATEFLAG")
                                    Else
                                        'MsgBox("Fill RATEFLAG detail of itemcode= " & itemcode & "  in ItemMaster")
                                        'Continue For
                                        RateFleg = "P"
                                    End If

                                    sqlstring = "SELECT ISNULL(amount,0) AS amount , ISNULL(qty,0) AS qty,ISNULL(RET_qty,0) AS RET_qty FROM Grn_details WHERE grndetails='" & trnno & "' and itemcode='" & itemcode & "'"
                                    getDataSet(sqlstring, "Grn_details")

                                    If (gdataset.Tables("Grn_details").Rows.Count > 0) Then
                                        TRNqty = Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) - Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty"))

                                        'If Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")) <> 0 Then
                                        '    TRNvalue = (Val(gdataset.Tables("Grn_details").Rows(0).Item("amount")) / Val(gdataset.Tables("Grn_details").Rows(0).Item("qty"))) * (Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) - Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")))
                                        'Else
                                        '    TRNvalue = Val(gdataset.Tables("Grn_details").Rows(0).Item("amount"))
                                        'End If

                                        If TRNqty = 0 Then
                                            sqlstring = "SELECT TOP 1  ISNULL(closingstock,0) AS closingstock,ISNULL(closingvalue,0) AS closingvalue,ISNULL(openningstock,0) AS openningstock,ISNULL(OPENNingvalue,0) AS OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and cast(convert(varchar(11),trndate,106)as datetime)<='" & Format(CDate(TrnDATE), "yyyy-MM-dd") & "' AND TTYPE IN ('GRN') order by TRNS_SEQ DESC "
                                            getDataSet(sqlstring, "Grn_detailsbACK")
                                            If (gdataset.Tables("Grn_detailsbACK").Rows.Count > 0) Then
                                                TRNvalue = Val(gdataset.Tables("Grn_detailsbACK").Rows(0).Item("closingvalue"))
                                                TRNqty = Val(gdataset.Tables("Grn_detailsbACK").Rows(0).Item("closingstock"))
                                            End If
                                        Else
                                            If Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")) <> 0 Then

                                                If Val(gdataset.Tables("Grn_details").Rows(0).Item("amount")) <> 0 And Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) <> 0 Then
                                                    TRNvalue = (Val(gdataset.Tables("Grn_details").Rows(0).Item("amount")) / Val(gdataset.Tables("Grn_details").Rows(0).Item("qty"))) * (Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) - Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")))
                                                Else
                                                    TRNvalue = 0
                                                End If

                                            Else
                                                TRNvalue = Val(gdataset.Tables("Grn_details").Rows(0).Item("amount"))
                                            End If
                                        End If
                                    End If

                                    If Trim(RateFleg.ToUpper()) = "W" Then
                                        If (openningvalue + TRNvalue) <> 0 And (openningstock + TRNqty) <> 0 Then
                                            rate = Math.Round((openningvalue + TRNvalue) / (openningstock + TRNqty), 3)
                                        Else
                                            sqlstring = "select TOP 1 isnull(rate,0) rate from closingqty where itemcode='" & itemcode & "' AND   trns_seq<" & Val(trns_seq) & " and ttype in ('GRN','Openning') and isnull(rate,0)<>0  order by TRNS_SEQ DESC"
                                            getDataSet(sqlstring, "lastTrn1")
                                            If (gdataset.Tables("lastTrn1").Rows.Count > 0) Then
                                                rate = Val(gdataset.Tables("lastTrn1").Rows(0).Item("rate").ToString)
                                            Else
                                                rate = 0
                                            End If
                                        End If
                                    Else

                                        If TRNvalue <> 0 And TRNqty <> 0 Then
                                            rate = Math.Round(TRNvalue / TRNqty, 3)
                                        Else
                                            sqlstring = "select TOP 1 isnull(rate,0) rate from closingqty where itemcode='" & itemcode & "' AND   trns_seq<" & Val(trns_seq) & " and ttype in ('GRN','Openning') and isnull(rate,0)<>0  order by TRNS_SEQ DESC"
                                            getDataSet(sqlstring, "lastTrn1")
                                            If (gdataset.Tables("lastTrn1").Rows.Count > 0) Then
                                                rate = Val(gdataset.Tables("lastTrn1").Rows(0).Item("rate").ToString)
                                            Else
                                                rate = 0
                                            End If
                                        End If


                                    End If
                                ElseIf Trim(trntype.ToUpper()) = "RECEIEVE" Then

                                    rate = Math.Round(Val(gdataset.Tables("TrnsView").Rows(I).Item("RATE")), 3)
                                Else


                                    If openningvalue = 0 And openningstock = 0 Then

                                        sqlstring = "select TOP 1 isnull(rate,0) rate from closingqty where itemcode='" & itemcode & "' AND   trns_seq<" & Val(trns_seq) & " and ttype in ('GRN','Openning') and isnull(rate,0)<>0  order by TRNS_SEQ DESC"
                                        getDataSet(sqlstring, "lastTrn1")
                                        If (gdataset.Tables("lastTrn1").Rows.Count > 0) Then
                                            rate = Val(gdataset.Tables("lastTrn1").Rows(0).Item("rate").ToString)
                                        Else
                                            If Math.Round(Val(gdataset.Tables("TrnsView").Rows(I).Item("RATE")), 3) > 0 Then
                                                rate = Math.Round(Val(gdataset.Tables("TrnsView").Rows(I).Item("RATE")), 3)
                                            Else
                                                rate = 1
                                            End If
                                        End If


                                    Else
                                        rate = Math.Round(openningvalue / openningstock, 3)
                                    End If

                                End If


                                If Trim(trntype.ToUpper()) = "ISSUE" Or Trim(trntype.ToUpper()) = "KOT" Or Trim(trntype.ToUpper()) = "CONSUME" Or Trim(trntype.ToUpper()) = "DAMAGE" Or Trim(trntype.ToUpper()) = "PRN" Or Trim(trntype.ToUpper()) = "TRANSFER_FROM" Then
                                    qty = qty * -1
                                End If

                                closingstock = openningstock + qty
                                closingvalue = closingstock * rate

                            Else
                                openningstock = 0
                                openningvalue = 0

                                qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("QTY"))
                                rate = Val(gdataset.Tables("TrnsView").Rows(I).Item("RATE"))

                                closingstock = qty
                                closingvalue = qty * rate
                            End If
                        Else
                            qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("QTY"))
                            rate = Val(gdataset.Tables("TrnsView").Rows(I).Item("RATE"))

                            If Trim(trntype.ToUpper()) = "ISSUE" Or Trim(trntype.ToUpper()) = "KOT" Or Trim(trntype.ToUpper()) = "CONSUME" Or Trim(trntype.ToUpper()) = "DAMAGE" Or Trim(trntype.ToUpper()) = "PRN" Or Trim(trntype.ToUpper()) = "TRANSFER_FROM" Then
                                qty = qty * -1
                            End If
                            closingstock = qty
                            closingvalue = qty * rate
                        End If

                        If Trim(trntype.ToUpper()) = "ADJUSTMENT1" Then
                            trntype = "ADJUSTMENT"
                        End If
                        If Trim(trntype.ToUpper()) = "TRANSFER_FROM" Then
                            trntype = "TRANSFER"
                        End If
                        If Trim(trntype.ToUpper()) = "TRANSFER_TO" Then
                            trntype = "RECEIEVE"
                        End If

                        If Double.IsNaN(rate) Or Double.IsNaN(closingvalue) Then
                            ' Continue For
                        End If

                        sql1 = " SELECT TRNS_SEQ FROM CLOSINGQTY WHERE TRNS_SEQ=" + trns_seq + ""
                        getDataSet(sql1, "A")

                        If (gdataset.Tables("A").Rows.Count > 0) Then

                            fLAG = True
                        Else
                            fLAG = False
                        End If


                        sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,ttype,batchyn,batchno,TRNS_SEQ,priority,rate)"
                        sqlstring = sqlstring & " values ('" & trnno & "',"
                        sqlstring = sqlstring & " '" & itemcode & "',"
                        sqlstring = sqlstring & " '" & STOCKUOM & "',"
                        sqlstring = sqlstring & "'" & storecode & "',"
                        sqlstring = sqlstring & "'" & Format(CDate(TrnDATE), "dd/MMM/yyyy") & "',"
                        sqlstring = sqlstring & " " & Format(openningstock, "0.000") & ","
                        sqlstring = sqlstring & "" & Format(openningvalue, "0.000") & ","
                        sqlstring = sqlstring & "" & Format(qty, "0.000") & ","
                        sqlstring = sqlstring & "" & Format(closingstock, "0.000") & ","
                        sqlstring = sqlstring & "" & Format(closingvalue, "0.000") & ","
                        sqlstring = sqlstring & "'" & trntype & "','','',"
                        If trntype = "RECEIEVE" Or Trim(trntype.ToUpper()) = "TRANSFER_TO" Or fLAG = True Then
                            sqlstring = sqlstring & "DBO.INV_GETSEQNO('" + Format(CDate(TrnDATE), "dd/MMM/yyyy") + "'),"
                            fLAG = False
                        Else
                            sqlstring = sqlstring & "" & trns_seq & ","
                            fLAG = False
                        End If

                        sqlstring = sqlstring & "" & priority & "," & Format(rate, "0.000") & ")"

                        dataOperation(6, sqlstring, )

                        ' sqlstring = sqlstring & " " & Format((qty / CONVVALUE) + (qty * precise), "0.000") & ","
                        ' sqlstring = sqlstring & " " & Format((qty / CONVVALUE) + (qty * precise) + closingqty, "0.000") & ","

                    Catch ex As Exception
                        MsgBox("Problem found in manualupdate :" & ex.ToString())
                    End Try
                Next
                dataOperation(6, "update closingqty set openningstock=isnull((select sum(qty) from closingqty a where a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ group by a.storecode,a.itemcode),0) ", )
                dataOperation(6, "update closingqty set closingstock=openningstock+qty", )

                'sqlstring = "update closingqty set openningvalue=ISNULL((SELECT TOP 1 closingvalue FROM CLOSINGQTY A WHERE a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ ORDER BY A.TRNS_SEQ DESC),0)"
                'dataOperation(6, sqlstring, )
                sqlstring = "update closingqty set openningvalue=0 where openningstock=0 "
                dataOperation(6, sqlstring, )
                sqlstring = "update closingqty set closingvalue=0 where closingstock=0 "
                dataOperation(6, sqlstring, )

                sqlstring = "update closingqty set openningvalue=openningstock*ISNULL((SELECT TOP 1 rate FROM CLOSINGQTY A WHERE a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ ORDER BY A.TRNS_SEQ DESC),0)"
                dataOperation(6, sqlstring, )

                sqlstring = "update closingqty set closingvalue=closingSTOCK*rate"
                dataOperation(6, sqlstring, )
                sqlstring = "update closingqty set openningvalue=ISNULL((SELECT TOP 1 closingvalue FROM CLOSINGQTY A WHERE a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ ORDER BY A.TRNS_SEQ DESC),0)"
                dataOperation(6, sqlstring, )
                ' sqlstring = "update closingqty set closingvalue=closingSTOCK*ISNULL((SELECT TOP 1 rate FROM CLOSINGQTY A WHERE a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ and closingstock<>0 ORDER BY A.TRNS_SEQ DESC),0) where ttype not in ('GRN','Openning') "
                ' dataOperation(6, sqlstring, )
                'sqlstring = "update closingqty set openningvalue=ISNULL((SELECT TOP 1 closingvalue FROM CLOSINGQTY A WHERE a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ ORDER BY A.TRNS_SEQ DESC),0)"
                'dataOperation(6, sqlstring, )
                sqlstring = "update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end ,  lastweightedrate=  case when openningvalue=0 then batchrate    Else  openningvalue/openningstock      End  from ratelist r inner join CLOSINGQTY on r.grnno=CLOSINGQTY.trnno where trndate = r.grndate And CLOSINGQTY.storecode = r.storecode And CLOSINGQTY.itemcode = r.Itemcode and CLOSINGQTY.openningstock<>0 "
                dataOperation(6, sqlstring, )
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
            Exit Sub
        End Try
        MsgBox("Stock Manual Updation Completed....")
    End Sub

    '================================NEW WEIGHTED FUNCTION=================================================

    Public Function CALC_WEIGHTED()

        Dim SQLS, itemc As String
        Dim Insert(0) As String
        Dim i, J As Integer
        Array.Clear(Insert, 0, Insert.Length)
        Try
            Dim CNT As Integer
            CNT = 2
            For J = 0 To CNT - 1
                sqlstring = "DROP TABLE INV_WEIGHTED_TAB3"
                ExcuteStoreProcedure(sqlstring)
                SQLS = "SELECT * INTO INV_WEIGHTED_TAB3 FROM INV_WEIGHTED_VIEW2 WHERE 1<0 "
                ExcuteStoreProcedure(SQLS)

                sqlstring = "ALTER TABLE INV_WEIGHTED_TAB3 ADD ROWID INTEGER IDENTITY(1,1)"
                ExcuteStoreProcedure(sqlstring)



                SQLS = " INSERT INTO INV_WEIGHTED_TAB3 (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE,LOCATION, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY ) "

                SQLS = SQLS & "SELECT DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE AS DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE,LOCATION, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY  FROM INV_WEIGHTED_VIEW2 "
                SQLS = SQLS & " ORDER BY  ITEMCODE,"

                SQLS = SQLS & " DOCDATE, PRIORITY,LOCATION"
                ExcuteStoreProcedure(SQLS)

                SQLS = "ALTER TABLE INV_WEIGHTED_TAB3 ADD WEIGHTED_RATE NUMERIC(18,2)"
                ExcuteStoreProcedure(SQLS)

                SQLS = "UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE =0"
                ExcuteStoreProcedure(SQLS)

                SQLS = " UPDATE INV_WEIGHTED_TAB3 SET CLSSTOCK=(SELECT SUM(QTY) FROM INV_WEIGHTED_TAB3 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.LOCATION=INV_WEIGHTED_TAB3.LOCATION AND STORECODE IN (SELECT STORECODE FROM STOREMASTER WHERE ISNULL(STORESTATUS,'')='M') AND A.ROWID<=INV_WEIGHTED_TAB3.ROWID )"
                ExcuteStoreProcedure(SQLS)
                SQLS = " UPDATE INV_WEIGHTED_TAB3 SET LASTSTOCK=(SELECT ISNULL(SUM(QTY),0) FROM INV_WEIGHTED_TAB3 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.LOCATION=INV_WEIGHTED_TAB3.LOCATION AND STORECODE IN (SELECT STORECODE FROM STOREMASTER WHERE ISNULL(STORESTATUS,'')='M') AND A.ROWID<INV_WEIGHTED_TAB3.ROWID )"
                ExcuteStoreProcedure(SQLS)

                SQLS = " UPDATE INV_WEIGHTED_TAB3 SET LASTRATE=(SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM INV_WEIGHTED_TAB3 A "
                SQLS = SQLS & " WHERE  A.ITEMCODE=INV_WEIGHTED_TAB3.ITEMCODE AND A.ROWID<INV_WEIGHTED_TAB3.ROWID AND A.TYPE IN ('OPENING','GRN','ISSUE GRN') ORDER BY A.ROWID DESC) "
                SQLS = SQLS & " WHERE TYPE IN ('OPENING','GRN','ISSUE GRN')"
                ExcuteStoreProcedure(SQLS)
                SQLS = " UPDATE  INV_WEIGHTED_TAB3 SET LASTRATE=RATE WHERE TYPE IN ('OPENING','GRN','ISSUE GRN') AND ISNULL(LASTRATE,0)=0"
                ExcuteStoreProcedure(SQLS)

                SQLS = " UPDATE INV_WEIGHTED_TAB3 SET WEIGHTED_RATE = RATE WHERE TYPE='OPENING'"
                ExcuteStoreProcedure(SQLS)

                'sqlstring = "SELECT * FROM INV_WEIGHTED_TAB2 WHERE STORECODE='MNS' ORDER BY ROWID"
                sqlstring = "SELECT * FROM INV_WEIGHTED_TAB3 ORDER BY ROWID"
                Dim SqlConnection As New SqlConnection
                SqlConnection.ConnectionString = Getconnection()
                SqlConnection.Open()
                Dim DS As New DataSet
                Dim DA As New SqlDataAdapter(sqlstring, SqlConnection)

                Dim DT As New DataTable
                DA.Fill(DT)
                DT.TableName = "INV_WEIGHTED_TAB2"
                If DS.Tables.Contains("INV_WEIGHTED_TAB2") = True Then
                    DS.Tables.Remove("INV_WEIGHTED_TAB2")
                End If
                DS.Tables.Add(DT)

                SqlConnection.Close()

                If DS.Tables("INV_WEIGHTED_TAB2").Rows.Count > 0 Then
                    Dim ITEMCODE, LOCATION As String
                    Dim RATE As Double
                    Dim QTY As Double
                    LOCATION = DS.Tables("INV_WEIGHTED_TAB2").Rows(0).Item("STORECODE")
                    ITEMCODE = DS.Tables("INV_WEIGHTED_TAB2").Rows(0).Item("ITEMCODE")
                    For i = 0 To DS.Tables("INV_WEIGHTED_TAB2").Rows.Count - 1


                        If LOCATION <> DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("STORECODE") Then
                            QTY = 0
                            RATE = 0
                            ITEMCODE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("STORECODE")

                            If ITEMCODE <> DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE") Then
                                QTY = 0
                                RATE = 0
                                ITEMCODE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE")

                                QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                        RATE = ((DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                End If
                            Else
                                QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                                If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                    RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                                ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                        RATE = ((DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                        RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                    Else
                                        RATE = 0
                                    End If
                                Else
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                                End If
                            End If
                        Else
                            QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
                            If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                                RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

                            ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Or DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "ISSUE GRN" Then
                                If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                    RATE = ((DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") < 0 Then
                                    RATE = Math.Abs(DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))
                                    DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                                Else
                                    RATE = 0
                                End If
                            Else
                                DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                            End If
                        End If

                    Next

                End If

                DS.Tables("INV_WEIGHTED_TAB2").Columns.Remove("TOSTORECODE")
                DS.Tables("INV_WEIGHTED_TAB2").Columns.Remove("LOCATION")
                openConnection()
                gcommand = New SqlCommand("Update_RateNEW", Myconn)
                gcommand.CommandTimeout = 1000000000
                gcommand.CommandType = CommandType.StoredProcedure
                gcommand.Parameters.AddWithValue("@INV_WEIGHTED_TAB2", DS.Tables("INV_WEIGHTED_TAB2"))
                gcommand.ExecuteNonQuery()
                closeConnection()

                ''SQLS = "UPDATE INV_WEIGHTED_TAB2 SET WEIGHTED_RATE=A.WEIGHTED_RATE  FROM  INV_WEIGHTED_TAB3 A WHERE A.ROWID=INV_WEIGHTED_TAB2.ROWID"
                ''gconnection.ExcuteStoreProcedure(SQLS)

                ' ''*********UPDATION IN THE FINAL TABLE FOR THE REPORT ***********************
                'SQLS = "Update INV_WEIGHTED_final_tabNEW Set WEIGHTED_RATE = ISnull((Select Top 1 Rate From stockissuedetail B  Where B.Itemcode = INV_WEIGHTED_final_tabNEW.ITEMCODE And     B.Opstorelocationcode = INV_WEIGHTED_final_tabNEW.STORECODE And B.Docdate<INV_WEIGHTED_final_tabNEW.DOCDATE    Order By Docdate Desc),0) where isnull(WEIGHTED_RATE,0) <= 0    "
                'ExcuteStoreProcedure(SQLS)
                'SQLS = " Update INV_WEIGHTED_final_tabNEW Set WEIGHTED_RATE = isnull((Select Top 1 Rate From INV_WEIGHTED_final_tabNEW B     Where B.Itemcode = INV_WEIGHTED_final_tabNEW.ITEMCODE  And B.Docdate<=INV_WEIGHTED_final_tabNEW.DOCDATE and rate>0    Order By Docdate Desc),0) where isnull(WEIGHTED_RATE,0) <= 0 "
                'ExcuteStoreProcedure(SQLS)
                ''**********updation of purchase rate in inventory itemmaster **********"
                'SQLS = "update inventoryitemmaster set purchaserate=a.weighted_rate, salerate=a.weighted_rate FROM INV_WEIGHTED_final_tabNEW A "
                'SQLS = SQLS & " WHERE  A.ITEMCODE=inventoryitemmaster.Itemcode and TYPE in ('GRN') AND DOCDETAILS IN (SELECT MAX(DOCDETAILS) FROM INV_WEIGHTED_final_tabNEW "
                'SQLS = SQLS & " WHERE TYPE IN ('GRN') ) "
                'ExcuteStoreProcedure(SQLS)

                'SQLS = "update inventoryitemmaster set purchaserate='0.001', salerate='0.001' FROM INV_WEIGHTED_final_tabNEW A "
                'SQLS = SQLS & " WHERE  A.ITEMCODE=inventoryitemmaster.Itemcode and TYPE in ('GRN') AND DOCDETAILS IN "
                'SQLS = SQLS & " (SELECT MAX(DOCDETAILS) FROM INV_WEIGHTED_final_tabNEW "
                'SQLS = SQLS & " WHERE TYPE IN ('GRN') ) And A.WEIGHTED_RATE<=0"
                'ExcuteStoreProcedure(SQLS)


                ' ''***** UPDATION OF THE TRANSACTION AFTER CALCULATING WEIGHTED RATE **********************
                'SQLS = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
                'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                'ExcuteStoreProcedure(SQLS)



                'SQLS = "UPDATE STOCKDMGDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKDMGDETAIL.dmgqty*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
                'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKDMGDETAIL.Docdetails AND A.ITEMCODE=STOCKDMGDETAIL.Itemcode AND A.TYPE='DAMAGE' "
                'gconnection.ExcuteStoreProcedure(SQLS)

                'SQLS = "UPDATE STOCKTRANSFERDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKTRANSFERDETAIL.QTY*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
                'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKTRANSFERDETAIL.Docdetails AND A.ITEMCODE=STOCKTRANSFERDETAIL.Itemcode AND A.TYPE='TRANSFER' "
                'gconnection.ExcuteStoreProcedure(SQLS)

                'SQLS = "UPDATE STOCKADJUSTDETAILS SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKADJUSTDETAILS.AdjustedStock*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
                'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKADJUSTDETAILS.Docdetails AND A.ITEMCODE=STOCKADJUSTDETAILS.Itemcode AND A.TYPE='ADJUSTMENT' "
                'gconnection.ExcuteStoreProcedure(SQLS)

                'SQLS = "UPDATE SUBSTORECONSUMPTIONDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= SUBSTORECONSUMPTIONDETAIL.QTY*A.WEIGHTED_RATE FROM INV_WEIGHTED_final_tabNEW A "
                'SQLS = SQLS & " WHERE A.DOCDETAILS=SUBSTORECONSUMPTIONDETAIL.Docdetails AND A.ITEMCODE=SUBSTORECONSUMPTIONDETAIL.Itemcode AND A.TYPE='CONSUMPTION' "
                'gconnection.ExcuteStoreProcedure(SQLS)


            Next

        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function


    '======================================================================================================








    Public Sub ManualUpdate()

        'Dim closingstock, closingvalue, openningstock, openningvalue, qty, rate, WRATE, TRNrate, TRNqty, TRNvalue As Double

        'Dim storecode, Storestatus, trntype, itemcode, uom, trnno, sql1 As String
        'Dim TrnDATE As DateTime
        'Dim RateFleg As String = "P"
        'Dim priority As Integer
        'Dim STOCKUOM, RETURNFLAG As String
        'Dim CONVVALUE As Double
        'Dim precise As Double
        'Dim i, trns_seq As Integer
        'Try
        '    sqlstring = "select * from TrnsView_NEW "

        '    If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Then
        '        sqlstring = sqlstring & " where docdate>='2016-01-01 00:00:00.000'"
        '    End If
        '    'sqlstring = sqlstring & " order  by CAST(CONVERT(VARCHAR(11),docdate ,106) AS DATETIME),priority"
        '    '  sqlstring = sqlstring & " order  by trns_seq"
        '    getDataSet(sqlstring, "TrnsView")
        '    If (gdataset.Tables("TrnsView").Rows.Count > 0) Then

        '        sqlstring = "truncate  table closingqty"

        '        dataOperation(6, sqlstring, )


        '        For i = 0 To gdataset.Tables("TrnsView").Rows.Count - 1
        '            Try


        '                STOCKUOM = 0
        '                CONVVALUE = 1
        '                closingstock = 0
        '                closingvalue = 0
        '                openningstock = 0
        '                openningvalue = 0
        '                qty = 0
        '                rate = 0
        '                trntype = ""

        '                ' itemcode = Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode"))
        '                'If itemcode <> "BC101" Then
        '                '    '  Continue For
        '                'Else
        '                '    MsgBox("")

        '                'End If

        '                itemcode = Trim(gdataset.Tables("TrnsView").Rows(i).Item("itemcode"))
        '                uom = Trim(gdataset.Tables("TrnsView").Rows(i).Item("convuom"))
        '                trnno = Trim(gdataset.Tables("TrnsView").Rows(i).Item("docdetails"))
        '                storecode = Trim(gdataset.Tables("TrnsView").Rows(i).Item("storecode"))
        '                TrnDATE = CDate(gdataset.Tables("TrnsView").Rows(i).Item("docdate"))
        '                trntype = Trim(gdataset.Tables("TrnsView").Rows(i).Item("ttype"))
        '                trns_seq = Val(gdataset.Tables("TrnsView").Rows(i).Item("seqno"))
        '                priority = Val(gdataset.Tables("TrnsView").Rows(i).Item("priority"))


        '                '                    sqlstring = "select isnull(Stockuom,'') from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
        '                '                    STOCKUOM = getvalue(sqlstring)
        '                '                    If STOCKUOM = "" Then
        '                'chkstock:               GmoduleName = "Item Master"
        '                '                        Dim uomr As New Frm_InventoryItemmastervb
        '                '                        uomr.ItemcodeM = itemcode
        '                '                        MsgBox("Please define stock uom for item!")
        '                '                        uomr.ShowDialog()
        '                '                        sqlstring = "select isnull(Stockuom,'') from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
        '                '                        STOCKUOM = getvalue(sqlstring)
        '                '                        If STOCKUOM = "" Then
        '                '                            Dim result As Integer = MessageBox.Show("Please define stock uom for item to complete the manual updation process!", "Alert", MessageBoxButtons.YesNo)
        '                '                            If result = DialogResult.Yes Then
        '                '                                GoTo chkstock
        '                '                            Else
        '                '                                MessageBox.Show("Please define stock uom of item to complete the manual updation process!", "Alert")
        '                '                                GoTo chkstock
        '                '                            End If
        '                '                        End If

        '                '                    End If
        '                '                    sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
        '                '                    getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
        '                '                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
        '                '                        CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
        '                '                        precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
        '                '                    Else
        '                '                        MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom + "  for Itemcode=" + itemcode, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        '                '                        ' MessageBox.Show("Generate relation between " + STOCKUOM + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        '                '                        GmoduleName = "Uom Convertion Entry"
        '                '                        Dim uomr As New FrmUOMRelation
        '                '                        'uomr.MdiParent = Me
        '                '                        uomr.baseuom = STOCKUOM
        '                '                        uomr.transuom = uom
        '                '                        uomr.ShowDialog()
        '                '                        sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
        '                '                        STOCKUOM = getvalue(sqlstring)
        '                '                        sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
        '                '                        getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
        '                '                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then

        '                '                            sqlstring = "select Stockuom from inv_inventoryitemmaster where itemcode='" + itemcode + "'"
        '                '                            STOCKUOM = getvalue(sqlstring)
        '                '                            sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + STOCKUOM + "' and transuom='" + uom + "'"
        '                '                            getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
        '                '                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
        '                '                                CONVVALUE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
        '                '                                precise = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
        '                '                            End If


        '                '                        Else

        '                '                            Exit Sub
        '                '                        End If
        '                '                    End If



        '                If Trim(trntype.ToUpper()) <> "OPENNING" Then
        '                    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and cast(convert(varchar(11),trndate,106)as datetime)<='" & Format(CDate(TrnDATE), "yyyy-MM-dd") & "'  order by TRNS_SEQ DESC"
        '                    ' sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and trns_seq<" & trns_seq & " order by trns_seq desc "
        '                    getDataSet(sqlstring, "closingqty")

        '                    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

        '                        openningstock = Val(gdataset.Tables("closingqty").Rows(0).Item("closingstock"))
        '                        openningvalue = Val(gdataset.Tables("closingqty").Rows(0).Item("closingvalue"))

        '                        qty = Val(gdataset.Tables("TrnsView").Rows(i).Item("convQTY"))

        '                        ''----------------------------------------------------------------------------------------------------------------------------------------


        '                        'qty = qty / CONVVALUE
        '                        ''-----------------------------------------------------------------------------------------------------------------------------------------------------------
        '                        If Trim(trntype.ToUpper()) = "GRN" Then

        '                            sql1 = " select isnull(rateflag,'P') as rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
        '                            sql1 = sql1 & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" & itemcode & "'  "
        '                            getDataSet(sql1, "RATEFLAG")
        '                            If (gdataset.Tables("RATEFLAG").Rows.Count > 0) Then
        '                                RateFleg = gdataset.Tables("RATEFLAG").Rows(0).Item("RATEFLAG")
        '                            Else
        '                                'MsgBox("Fill RATEFLAG detail of itemcode= " & itemcode & "  in ItemMaster")
        '                                'Continue For
        '                                RateFleg = "P"
        '                            End If

        '                            sqlstring = "SELECT ISNULL(amount,0) AS amount , ISNULL(qty,0) AS qty,ISNULL(RET_qty,0) AS RET_qty FROM Grn_details WHERE grndetails='" & trnno & "' and itemcode='" & itemcode & "'"
        '                            getDataSet(sqlstring, "Grn_details")

        '                            If (gdataset.Tables("Grn_details").Rows.Count > 0) Then
        '                                TRNqty = Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) - Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty"))

        '                                'If Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")) <> 0 Then
        '                                '    TRNvalue = (Val(gdataset.Tables("Grn_details").Rows(0).Item("amount")) / Val(gdataset.Tables("Grn_details").Rows(0).Item("qty"))) * (Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) - Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")))
        '                                'Else
        '                                '    TRNvalue = Val(gdataset.Tables("Grn_details").Rows(0).Item("amount"))
        '                                'End If

        '                                If TRNqty = 0 Then
        '                                    sqlstring = "SELECT TOP 1  ISNULL(closingstock,0) AS closingstock,ISNULL(closingvalue,0) AS closingvalue,ISNULL(openningstock,0) AS openningstock,ISNULL(OPENNingvalue,0) AS OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and cast(convert(varchar(11),trndate,106)as datetime)<='" & Format(CDate(TrnDATE), "yyyy-MM-dd") & "' AND TTYPE IN ('GRN') order by TRNS_SEQ DESC "
        '                                    getDataSet(sqlstring, "Grn_detailsbACK")
        '                                    If (gdataset.Tables("Grn_detailsbACK").Rows.Count > 0) Then
        '                                        TRNvalue = Val(gdataset.Tables("Grn_detailsbACK").Rows(0).Item("closingvalue"))
        '                                        TRNqty = Val(gdataset.Tables("Grn_detailsbACK").Rows(0).Item("closingstock"))
        '                                    End If
        '                                Else
        '                                    If Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")) <> 0 Then

        '                                        If Val(gdataset.Tables("Grn_details").Rows(0).Item("amount")) <> 0 And Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) <> 0 Then
        '                                            TRNvalue = (Val(gdataset.Tables("Grn_details").Rows(0).Item("amount")) / Val(gdataset.Tables("Grn_details").Rows(0).Item("qty"))) * (Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) - Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")))
        '                                        Else
        '                                            TRNvalue = 0
        '                                        End If

        '                                    Else
        '                                        TRNvalue = Val(gdataset.Tables("Grn_details").Rows(0).Item("amount"))
        '                                    End If
        '                                End If
        '                            End If

        '                            If Trim(RateFleg.ToUpper()) = "W" Then
        '                                If (openningvalue + TRNvalue) <> 0 And (openningstock + TRNqty) <> 0 Then
        '                                    rate = Math.Round((openningvalue + TRNvalue) / (openningstock + TRNqty), 3)
        '                                Else
        '                                    sqlstring = "select TOP 1 isnull(rate,0) rate from closingqty where itemcode='" & itemcode & "' AND   trns_seq<" & Val(trns_seq) & " and ttype in ('GRN','Openning') and isnull(rate,0)<>0  order by TRNS_SEQ DESC"
        '                                    getDataSet(sqlstring, "lastTrn1")
        '                                    If (gdataset.Tables("lastTrn1").Rows.Count > 0) Then
        '                                        rate = Val(gdataset.Tables("lastTrn1").Rows(0).Item("rate").ToString)
        '                                    Else
        '                                        rate = 0
        '                                    End If
        '                                End If
        '                            Else

        '                                If TRNvalue <> 0 And TRNqty <> 0 Then
        '                                    rate = Math.Round(TRNvalue / TRNqty, 3)
        '                                Else
        '                                    sqlstring = "select TOP 1 isnull(rate,0) rate from closingqty where itemcode='" & itemcode & "' AND   trns_seq<" & Val(trns_seq) & " and ttype in ('GRN','Openning') and isnull(rate,0)<>0  order by TRNS_SEQ DESC"
        '                                    getDataSet(sqlstring, "lastTrn1")
        '                                    If (gdataset.Tables("lastTrn1").Rows.Count > 0) Then
        '                                        rate = Val(gdataset.Tables("lastTrn1").Rows(0).Item("rate").ToString)
        '                                    Else
        '                                        rate = 0
        '                                    End If
        '                                End If


        '                            End If
        '                        ElseIf Trim(trntype.ToUpper()) = "RECEIEVE" Then

        '                            rate = Math.Round(Val(gdataset.Tables("TrnsView").Rows(i).Item("RATE")), 3)
        '                        Else


        '                            If openningvalue = 0 And openningstock = 0 Then

        '                                sqlstring = "select TOP 1 isnull(rate,0) rate from closingqty where itemcode='" & itemcode & "' AND   trns_seq<" & Val(trns_seq) & " and ttype in ('GRN','Openning') and isnull(rate,0)<>0  order by TRNS_SEQ DESC"
        '                                getDataSet(sqlstring, "lastTrn1")
        '                                If (gdataset.Tables("lastTrn1").Rows.Count > 0) Then
        '                                    rate = Val(gdataset.Tables("lastTrn1").Rows(0).Item("rate").ToString)
        '                                Else
        '                                    If Math.Round(Val(gdataset.Tables("TrnsView").Rows(i).Item("RATE")), 3) > 0 Then
        '                                        rate = Math.Round(Val(gdataset.Tables("TrnsView").Rows(i).Item("RATE")), 3)
        '                                    Else
        '                                        rate = 1
        '                                    End If
        '                                End If


        '                            Else
        '                                rate = Math.Round(openningvalue / openningstock, 3)
        '                            End If

        '                        End If


        '                        'If Trim(trntype.ToUpper()) = "ISSUE" Or Trim(trntype.ToUpper()) = "KOT" Or Trim(trntype.ToUpper()) = "CONSUME" Or Trim(trntype.ToUpper()) = "DAMAGE" Or Trim(trntype.ToUpper()) = "PRN" Or Trim(trntype.ToUpper()) = "TRANSFER_FROM" Then
        '                        '    qty = qty * -1
        '                        'End If

        '                        closingstock = openningstock + qty
        '                        closingvalue = closingstock * rate

        '                    Else
        '                        openningstock = 0
        '                        openningvalue = 0

        '                        qty = Val(gdataset.Tables("TrnsView").Rows(i).Item("conVQTY"))
        '                        rate = Val(gdataset.Tables("TrnsView").Rows(i).Item("RATE"))

        '                        closingstock = qty
        '                        closingvalue = qty * rate
        '                    End If
        '                Else
        '                    qty = Val(gdataset.Tables("TrnsView").Rows(i).Item("conVQTY"))
        '                    rate = Val(gdataset.Tables("TrnsView").Rows(i).Item("RATE"))

        '                    'If Trim(trntype.ToUpper()) = "ISSUE" Or Trim(trntype.ToUpper()) = "KOT" Or Trim(trntype.ToUpper()) = "CONSUME" Or Trim(trntype.ToUpper()) = "DAMAGE" Or Trim(trntype.ToUpper()) = "PRN" Or Trim(trntype.ToUpper()) = "TRANSFER_FROM" Then
        '                    '    qty = qty * -1
        '                    'End If
        '                    closingstock = qty
        '                    closingvalue = qty * rate
        '                End If

        '                If Trim(trntype.ToUpper()) = "ADJUSTMENT1" Then
        '                    trntype = "ADJUSTMENT"
        '                End If
        '                If Trim(trntype.ToUpper()) = "TRANSFER_FROM" Then
        '                    trntype = "TRANSFER"
        '                End If
        '                If Trim(trntype.ToUpper()) = "TRANSFER_TO" Then
        '                    trntype = "RECEIEVE"
        '                End If

        '                If Double.IsNaN(rate) Or Double.IsNaN(closingvalue) Then
        '                    ' Continue For
        '                End If

        '                'sql1 = " SELECT TRNS_SEQ FROM CLOSINGQTY WHERE TRNS_SEQ=" + trns_seq + ""
        '                'getDataSet(sql1, "A")

        '                'If (gdataset.Tables("A").Rows.Count > 0) Then

        '                '    fLAG = True
        '                'Else
        '                '    fLAG = False
        '                'End If


        '                sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,ttype,batchyn,batchno,TRNS_SEQ,priority,rate)"
        '                sqlstring = sqlstring & " values ('" & trnno & "',"
        '                sqlstring = sqlstring & " '" & itemcode & "',"
        '                sqlstring = sqlstring & " '" & uom & "',"
        '                sqlstring = sqlstring & "'" & storecode & "',"
        '                sqlstring = sqlstring & "'" & Format(CDate(TrnDATE), "dd/MMM/yyyy") & "',"
        '                sqlstring = sqlstring & " " & Format(openningstock, "0.000") & ","
        '                sqlstring = sqlstring & "" & Format(openningvalue, "0.000") & ","
        '                sqlstring = sqlstring & "" & Format(qty, "0.000") & ","
        '                sqlstring = sqlstring & "" & Format(closingstock, "0.000") & ","
        '                sqlstring = sqlstring & "" & Format(closingvalue, "0.000") & ","
        '                sqlstring = sqlstring & "'" & trntype & "','','',"
        '                'If trntype = "RECEIEVE" Or Trim(trntype.ToUpper()) = "TRANSFER_TO" Or fLAG = True Then
        '                '    sqlstring = sqlstring & "DBO.INV_GETSEQNO('" + Format(CDate(TrnDATE), "dd/MMM/yyyy") + "'),"
        '                '    fLAG = False
        '                'Else
        '                sqlstring = sqlstring & "" & trns_seq & ","
        '                '    fLAG = False
        '                'End If

        '                sqlstring = sqlstring & "" & priority & "," & Format(rate, "0.000") & ")"

        '                dataOperation(6, sqlstring, )

        '                ' sqlstring = sqlstring & " " & Format((qty / CONVVALUE) + (qty * precise), "0.000") & ","
        '                ' sqlstring = sqlstring & " " & Format((qty / CONVVALUE) + (qty * precise) + closingqty, "0.000") & ","

        '            Catch ex As Exception
        '                MsgBox("Problem found in manualupdate :" & ex.ToString())
        '            End Try
        '        Next
        '        dataOperation(6, "update closingqty set openningstock=isnull((select sum(qty) from closingqty a where a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ group by a.storecode,a.itemcode),0) ", )
        '        dataOperation(6, "update closingqty set closingstock=openningstock+qty", )

        '        'sqlstring = "update closingqty set openningvalue=ISNULL((SELECT TOP 1 closingvalue FROM CLOSINGQTY A WHERE a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ ORDER BY A.TRNS_SEQ DESC),0)"
        '        'dataOperation(6, sqlstring, )
        '        sqlstring = "update closingqty set openningvalue=0 where openningstock=0 "
        '        dataOperation(6, sqlstring, )
        '        sqlstring = "update closingqty set closingvalue=0 where closingstock=0 "
        '        dataOperation(6, sqlstring, )

        '        sqlstring = "update closingqty set openningvalue=openningstock*ISNULL((SELECT TOP 1 rate FROM CLOSINGQTY A WHERE a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ ORDER BY A.TRNS_SEQ DESC),0)"
        '        dataOperation(6, sqlstring, )

        '        sqlstring = "update closingqty set closingvalue=closingSTOCK*rate"
        '        dataOperation(6, sqlstring, )
        '        sqlstring = "update closingqty set openningvalue=ISNULL((SELECT TOP 1 closingvalue FROM CLOSINGQTY A WHERE a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ ORDER BY A.TRNS_SEQ DESC),0)"
        '        dataOperation(6, sqlstring, )
        '        ' sqlstring = "update closingqty set closingvalue=closingSTOCK*ISNULL((SELECT TOP 1 rate FROM CLOSINGQTY A WHERE a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ and closingstock<>0 ORDER BY A.TRNS_SEQ DESC),0) where ttype not in ('GRN','Openning') "
        '        ' dataOperation(6, sqlstring, )
        '        'sqlstring = "update closingqty set openningvalue=ISNULL((SELECT TOP 1 closingvalue FROM CLOSINGQTY A WHERE a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ ORDER BY A.TRNS_SEQ DESC),0)"
        '        'dataOperation(6, sqlstring, )
        '        sqlstring = "update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end ,  lastweightedrate=  case when openningvalue=0 then batchrate    Else  openningvalue/openningstock      End  from ratelist r inner join CLOSINGQTY on r.grnno=CLOSINGQTY.trnno where trndate = r.grndate And CLOSINGQTY.storecode = r.storecode And CLOSINGQTY.itemcode = r.Itemcode and CLOSINGQTY.openningstock<>0 "
        '        dataOperation(6, sqlstring, )
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString())
        '    Exit Sub
        'End Try
        MsgBox("Stock Manual Updation Completed....")



        'Dim cuDate, nDate, TRNSDATE As DateTime
        'Dim cuDate1, nDate1 As String
        'Dim Tdate() As String
        'Dim Nexttrns_seq, sqlstring As String
        'Dim seq As Integer = 0
        'Dim INSERT(0) As String
        'Dim trns_seq, TRNSDATE1 As String
        ''mydt.ToString("dd MMM yy tt")
        'INSERT(0) = sqlstring

        ''


        'Dim POSLOCATION As String
        'Dim POSITEMCODE, POSITEMUOM As String
        'Dim AVGRATE, AVGQUANTITY, dblCalqty As Double
        'Dim I, J, K As Integer
        'Dim sqlvendor As String

        'Dim closingqty As Double
        'Dim closingvalue, openningQty, openningvalue, qty As Double
        'Dim curDate As DateTime
        'Try


        'sqlstring = "UPDATE closingqty SET priority=1 WHERE ttype='Openning'"
        'dataOperation(6, sqlstring, )
        'sqlstring = "UPDATE closingqty SET priority=2 WHERE ttype='GRN'"
        'dataOperation(6, sqlstring, )
        'sqlstring = "UPDATE closingqty SET priority=3 WHERE ttype='ISSUE'"
        'dataOperation(6, sqlstring, )
        'sqlstring = "UPDATE closingqty SET priority=4 WHERE ttype='TRANSFER'"
        'dataOperation(6, sqlstring, )
        'sqlstring = "UPDATE closingqty SET priority=5 WHERE ttype='RECEIEVE'"
        'dataOperation(6, sqlstring, )
        'sqlstring = "UPDATE closingqty SET priority=6 WHERE ttype='DAMAGE'"
        'dataOperation(6, sqlstring, )
        'sqlstring = "UPDATE closingqty SET priority=7 WHERE ttype='ADJUSTMENT'"
        'dataOperation(6, sqlstring, )
        'sqlstring = "UPDATE closingqty SET priority=8 WHERE ttype='CONSUME'"
        'dataOperation(6, sqlstring, )
        'sqlstring = "UPDATE closingqty SET priority=9 WHERE ttype='KOT'"
        'dataOperation(6, sqlstring, )

        'sqlstring = "Select getdate()"

        'curDate = Format(getvalue(sqlstring), "dd/MMM/yyyy")
        'Tdate = Split(Trim(curDate), "/")
        'Nexttrns_seq = Mid(Tdate(2), 3, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)

        ''Dim strSQL = "   SELECT * FROM SYSOBJECTS WHERE name='closingqty" & Nexttrns_seq & "'"
        ''getDataSet(strSQL, "SYSOBJECTS")
        ''If gdataset.Tables("SYSOBJECTS").Rows.Count = 1 Then
        ''    sqlstring = "DROP TABLE closingqty" & Nexttrns_seq & ""
        ''    dataOperation(6, sqlstring, )
        ''End If

        ''sqlstring = "Select * Into CLOSINGQTY" & Nexttrns_seq & " From closingqty order by CAST(CONVERT(VARCHAR(11),TRNDATE ,106) AS DATETIME),priority"
        ''dataOperation(6, sqlstring, )

        ''strSQL = "   SELECT * FROM SYSOBJECTS WHERE name='closingqty" & Nexttrns_seq & "'"
        ''getDataSet(strSQL, "SYSOBJECTS")
        ''If gdataset.Tables("SYSOBJECTS").Rows.Count = 1 Then
        ''    sqlstring = "DROP TABLE closingqty"
        ''    dataOperation(6, sqlstring, )
        ''End If
        ''sqlstring = "Select * Into closingqty From CLOSINGQTY" & Nexttrns_seq & " ORDER by CAST(CONVERT(VARCHAR(11),TRNDATE ,106) AS DATETIME),priority"
        ''dataOperation(6, sqlstring, )


        '    sqlstring = "select * from closingqty where  ISNULL(trns_seq,0)=0     ORDER BY CAST(CONVERT(VARCHAR(11),TRNDATE ,106) AS DATETIME),priority"
        'getDataSet(sqlstring, "closingqtyT")
        'If (gdataset.Tables("closingqtyT").Rows.Count > 0) Then
        '    For I = 0 To gdataset.Tables("closingqtyT").Rows.Count - 1

        '        cuDate = Format(gdataset.Tables("closingqtyT").Rows(I).Item("trndate"), "dd/MMM/yyyy")
        '        cuDate1 = cuDate.ToString("dd/MM/yy")
        '        nDate1 = cuDate1
        '        seq = 1
        '        Do While cuDate1 = nDate1 And gdataset.Tables("closingqtyT").Rows.Count > I


        '            Tdate = Split(Trim(cuDate1), "/")
        '            Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
        '            Nexttrns_seq = Nexttrns_seq & Format(seq, "00000")


        '            sqlstring = "update closingqty set trns_seq=" & Val(Nexttrns_seq) & " where autoid=" & Val(gdataset.Tables("closingqtyT").Rows(I).Item("autoid")) & ""
        '            ReDim Preserve INSERT(INSERT.Length)
        '            INSERT(INSERT.Length - 1) = sqlstring
        '            seq = seq + 1
        '            I = I + 1
        '            If gdataset.Tables("closingqtyT").Rows.Count > I Then
        '                nDate = Format(gdataset.Tables("closingqtyT").Rows(I).Item("trndate"), "dd/MMM/yyyy")
        '                nDate1 = nDate.ToString("dd/MM/yy")
        '            End If

        '        Loop
        '        I = I - 1

        '    Next

        'End If
        'MoreTrans1(INSERT)
        'ReDim INSERT(0)

        '    sqlstring = "update inv_InventoryOpenningstock  set TRNS_SEQ=c.TRNS_SEQ from inv_InventoryOpenningstock i inner join closingqty c on i.storecode=c.storecode where   c.itemcode=i.itemcode and  c.uom=i.uom and c.ttype='openning'"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring

        'sqlstring = "update Grn_details set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from Grn_details g inner join CLOSINGQTY on grndetails=CLOSINGQTY.trnno where G.Itemcode=CLOSINGQTY.itemcode AND G.grndate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update STOCKISSUEdetail  set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from STOCKISSUEdetail  S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update STOCKADJUSTDETAILs   set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from STOCKADJUSTDETAILs   S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update StockConsumption_detail   set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from StockConsumption_detail   S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update stockConsumption_1    set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from stockConsumption_1    S inner join CLOSINGQTY on docno=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update STOCKDMGdetail    set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from STOCKDMGdetail    S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update STOCKTRANSFERdetail     set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from STOCKTRANSFERdetail     S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        'sqlstring = "update SUBSTORECONSUMPTIONDETAIL      set TRNS_SEQ=CLOSINGQTY.TRNS_SEQ from SUBSTORECONSUMPTIONDETAIL      S inner join CLOSINGQTY on Docdetails=CLOSINGQTY.trnno where S.Itemcode=CLOSINGQTY.itemcode AND S.Docdate=CLOSINGQTY.Trndate"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring

        'MoreTrans1(INSERT)
        'Dim ttype() As String
        'Dim INSERT1(0) As String
        '    sqlstring = "select * from TrnsView where ISNULL(trns_seq,0)=0 order by CAST(CONVERT(VARCHAR(11),docdate ,106) AS DATETIME),priority"
        'getDataSet(sqlstring, "TrnsView")
        'If (gdataset.Tables("TrnsView").Rows.Count > 0) Then
        '    For I = 0 To gdataset.Tables("TrnsView").Rows.Count - 1

        '        sqlstring = "select MAX(TRNS_SEQ) AS TRNS_SEQ from TrnsView where   CONVERT(VARCHAR(11), docdate, 106)= '" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd MMM yyyy") & "'"
        '        getDataSet(sqlstring, "TRNS_SEQ")

        '        If (gdataset.Tables("TRNS_SEQ").Rows.Count > 0) Then
        '            '    For i As Integer = 0 To gdataset.Tables("closingqtyT").Rows.Count - 1

        '            cuDate = Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy")
        '            cuDate1 = cuDate.ToString("dd/MM/yy")
        '            Nexttrns_seq = Val(gdataset.Tables("TRNS_SEQ").Rows(0).Item("TRNS_SEQ"))
        '            If Nexttrns_seq = 0 Then
        '                Tdate = Split(Trim(cuDate1), "/")
        '                Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
        '                Nexttrns_seq = Nexttrns_seq & Format(1, "00000")
        '            Else
        '                Nexttrns_seq = Nexttrns_seq + 1
        '            End If

        '            ttype = Split(Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")), "/")

        '            sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue from closingqty where itemcode='" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode")) & "' AND  storecode='" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("storecode")) & "'and trndate<='" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("DOCDATE")), "dd/MMM/yyyy") & "'  order by trndate desc, AUTOID desc"
        '            getDataSet(sqlstring, "clStock")
        '                If (gdataset.Tables("clStock").Rows.Count > 0) Then

        '                    closingqty = gdataset.Tables("clStock").Rows(0).Item("closingstock")
        '                    closingvalue = gdataset.Tables("clStock").Rows(0).Item("closingvalue")
        '                Else
        '                    closingqty = 0
        '                    closingvalue = 0
        '                End If
        '                If ttype(0) = "Openning" Then
        '                    sqlstring = "update inv_InventoryOpenningstock set trns_seq=" & Val(Nexttrns_seq) & " where storecode='" & gdataset.Tables("TrnsView").Rows(I).Item("storecode") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and 'Openning'='" & gdataset.Tables("TrnsView").Rows(I).Item("ttype") & "'"
        '                    dataOperation(6, sqlstring, )


        '                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,ttype,TRNS_SEQ)"
        '                    sqlstring = sqlstring & " values ('" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("uom")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("storecode")) & "',"
        '                    sqlstring = sqlstring & "'" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "',"
        '                    sqlstring = sqlstring & "0.00,"
        '                    sqlstring = sqlstring & "0.00,"

        '                    sqlstring = sqlstring & "0.00,"
        '                    qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("qty"))
        '                    openningQty = Val(closingqty) + Val(qty)
        '                    openningvalue = Val(closingvalue) + (Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) * Val(gdataset.Tables("TrnsView").Rows(I).Item("rate")))
        '                    sqlstring = sqlstring & " " & Val(openningQty) & ","
        '                    sqlstring = sqlstring & "" & Val(openningvalue) & ","
        '                    sqlstring = sqlstring & "'Openning',"
        '                    sqlstring = sqlstring & "" & Val(Nexttrns_seq) & ")"
        '                    dataOperation(6, sqlstring, )

        '                ElseIf ttype(0) = "GRN" Then
        '                    sqlstring = "update Grn_details set trns_seq=" & Val(Nexttrns_seq) & " where grndetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and grndate='" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "'"

        '                    dataOperation(6, sqlstring, )

        '                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,ttype,TRNS_SEQ)"
        '                    sqlstring = sqlstring & " values ('" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("uom")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("storecode")) & "',"
        '                    sqlstring = sqlstring & "'" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "',"
        '                    sqlstring = sqlstring & "" & Val(closingqty) & ","
        '                    sqlstring = sqlstring & "" & Val(closingvalue) & ","

        '                    sqlstring = sqlstring & "" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) & ","
        '                    qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("qty"))
        '                    openningQty = Val(closingqty) + Val(qty)
        '                    openningvalue = Val(closingvalue) + (Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) * Val(gdataset.Tables("TrnsView").Rows(I).Item("rate")))
        '                    sqlstring = sqlstring & " " & Val(openningQty) & ","
        '                    sqlstring = sqlstring & "" & Val(openningvalue) & ","
        '                    ' sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'GRN',"
        '                    'sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "" & Val(Nexttrns_seq) & ")"
        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "ISSUE" Then
        '                    sqlstring = "update STOCKISSUEdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,ttype,TRNS_SEQ)"
        '                    sqlstring = sqlstring & " values ('" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("uom")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("storecode")) & "',"
        '                    sqlstring = sqlstring & "'" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "',"
        '                    sqlstring = sqlstring & "" & Val(closingqty) & ","
        '                    sqlstring = sqlstring & "" & Val(closingvalue) & ","

        '                    sqlstring = sqlstring & "" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) & ","
        '                    qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("qty"))
        '                    openningQty = Val(closingqty) + Val(qty)
        '                    openningvalue = Val(closingvalue) + (Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) * Val(gdataset.Tables("TrnsView").Rows(I).Item("rate")))
        '                    sqlstring = sqlstring & " " & Val(openningQty) & ","
        '                    sqlstring = sqlstring & "" & Val(openningvalue) & ","
        '                    ' sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'ISSUE',"
        '                    'sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "" & Val(Nexttrns_seq) & ")"
        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "ADJ" Then
        '                    sqlstring = "update STOCKADJUSTDETAILs set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "CON" Then
        '                    sqlstring = "update stockConsumption_1 set trns_seq=" & Val(Nexttrns_seq) & " where docNO='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                    sqlstring = "update StockConsumption_detail set trns_seq=" & Val(Nexttrns_seq) & " where docNO='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "DMG" Then

        '                    sqlstring = "update STOCKDMGdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "TRF" Then
        '                    sqlstring = "update STOCKTRANSFERdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "KOT" Or ttype(0) = "DBAR" Or ttype(0) = "KBAR" Or ttype(0) = "BARD" Then
        '                    sqlstring = "update SUBSTORECONSUMPTIONDETAIL set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"

        '                    dataOperation(6, sqlstring, )

        '                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,ttype,TRNS_SEQ)"
        '                    sqlstring = sqlstring & " values ('" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("uom")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("storecode")) & "',"
        '                    sqlstring = sqlstring & "'" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "',"
        '                    sqlstring = sqlstring & "" & Val(closingqty) & ","
        '                    sqlstring = sqlstring & "" & Val(closingvalue) & ","

        '                    sqlstring = sqlstring & "-" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) & ","

        '                    qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("qty"))
        '                    openningQty = Val(closingqty) - Val(qty)
        '                    openningvalue = Val(closingvalue) - (Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) * Val(gdataset.Tables("TrnsView").Rows(I).Item("rate")))
        '                    sqlstring = sqlstring & "" & Val(openningQty) & ","
        '                    sqlstring = sqlstring & "" & Val(openningvalue) & ","

        '                    'sqlstring = sqlstring & "openningstock-" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) & ","
        '                    'sqlstring = sqlstring & "openningvalue-(" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) & "*(openningvalue/openningstock)),"
        '                    ' sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'KOT',"
        '                    ' sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "" & Val(Nexttrns_seq) & ")"

        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "RET" Then
        '                    sqlstring = "update STOCKTRANSFERdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                End If


        '            Else
        '                TRNSDATE = Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy")
        '                TRNSDATE1 = TRNSDATE.ToString("dd/MM/yy")
        '                Tdate = Split(Trim(TRNSDATE1), "/")
        '                Nexttrns_seq = Mid(Tdate(2), 1, 2) & Mid(Tdate(1), 1, 2) & Mid(Tdate(0), 1, 2)
        '                Nexttrns_seq = Nexttrns_seq & Format(1, "00000")

        '                ttype = Split(Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")), "/")
        '                If ttype(0) = "Openning" Then
        '                    sqlstring = "update inv_InventoryOpenningstock set trns_seq=" & Val(Nexttrns_seq) & " where storecode='" & gdataset.Tables("TrnsView").Rows(I).Item("storecode") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and uom='" & gdataset.Tables("TrnsView").Rows(I).Item("uom") & "' and 'Openning'='" & gdataset.Tables("TrnsView").Rows(I).Item("ttype") & "'"
        '                    dataOperation(6, sqlstring, )


        '                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,ttype,TRNS_SEQ)"
        '                    sqlstring = sqlstring & " values ('" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("uom")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("storecode")) & "',"
        '                    sqlstring = sqlstring & "'" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "',"
        '                    sqlstring = sqlstring & "0.00,"
        '                    sqlstring = sqlstring & "0.00,"

        '                    sqlstring = sqlstring & "0.00,"
        '                    qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("qty"))
        '                    openningQty = Val(closingqty) + Val(qty)
        '                    openningvalue = Val(closingvalue) + (Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) * Val(gdataset.Tables("TrnsView").Rows(I).Item("rate")))
        '                    sqlstring = sqlstring & " " & Val(openningQty) & ","
        '                    sqlstring = sqlstring & "" & Val(openningvalue) & ","
        '                    sqlstring = sqlstring & "'Openning',"
        '                    sqlstring = sqlstring & "" & Val(Nexttrns_seq) & ")"
        '                    dataOperation(6, sqlstring, )

        '                ElseIf ttype(0) = "GRN" Then
        '                    sqlstring = "update Grn_details set trns_seq=" & Val(Nexttrns_seq) & " where grndetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and grndate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )

        '                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,ttype,TRNS_SEQ)"
        '                    sqlstring = sqlstring & " values ('" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("uom")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("storecode")) & "',"
        '                    sqlstring = sqlstring & "'" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "',"
        '                    sqlstring = sqlstring & "" & Val(closingqty) & ","
        '                    sqlstring = sqlstring & "" & Val(closingvalue) & ","
        '                    sqlstring = sqlstring & "" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) & ","
        '                    qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("qty"))
        '                    openningQty = Val(closingqty) + Val(qty)
        '                    openningvalue = Val(closingvalue) + (Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) * Val(gdataset.Tables("TrnsView").Rows(I).Item("rate")))
        '                    sqlstring = sqlstring & " " & Val(openningQty) & ","
        '                    sqlstring = sqlstring & "" & Val(openningvalue) & ","
        '                    'sqlstring = sqlstring & "openningstock+" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) & ","
        '                    'sqlstring = sqlstring & "openningvalue+(" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) * Val(gdataset.Tables("TrnsView").Rows(I).Item("rate")) & "),"
        '                    'sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'GRN',"
        '                    'sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "" & Val(Nexttrns_seq) & ")"
        '                    dataOperation(6, sqlstring, )


        '                ElseIf ttype(0) = "ISSUE" Then
        '                    sqlstring = "update STOCKISSUEdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "ADJ" Then
        '                    sqlstring = "update STOCKADJUSTDETAILs set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "CON" Then
        '                    sqlstring = "update stockConsumption_1 set trns_seq=" & Val(Nexttrns_seq) & " where docNO='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                    sqlstring = "update StockConsumption_detail set trns_seq=" & Val(Nexttrns_seq) & " where docNO='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )

        '                ElseIf ttype(0) = "DMG" Then
        '                    sqlstring = "update STOCKDMGdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "TRF" Then
        '                    sqlstring = "update STOCKTRANSFERdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "KOT" Or ttype(0) = "DBAR" Or ttype(0) = "KBAR" Or ttype(0) = "BARD" Then
        '                    sqlstring = "update SUBSTORECONSUMPTIONDETAIL set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )

        '                    sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,ttype,TRNS_SEQ)"
        '                    sqlstring = sqlstring & " values ('" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("itemcode")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("uom")) & "',"
        '                    sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("storecode")) & "',"
        '                    sqlstring = sqlstring & "'" & Format(CDate(gdataset.Tables("TrnsView").Rows(I).Item("docdate")), "dd/MMM/yyyy") & "',"
        '                    sqlstring = sqlstring & "" & Val(closingqty) & ","
        '                    sqlstring = sqlstring & "" & Val(closingvalue) & ","
        '                    sqlstring = sqlstring & "-" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) & ","
        '                    qty = Val(gdataset.Tables("TrnsView").Rows(I).Item("qty"))
        '                    openningQty = Val(closingqty) - Val(qty)
        '                    openningvalue = Val(closingvalue) - (Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) * Val(gdataset.Tables("TrnsView").Rows(I).Item("rate")))
        '                    sqlstring = sqlstring & " " & Val(openningQty) & ","
        '                    sqlstring = sqlstring & "" & Val(openningvalue) & ","
        '                    'sqlstring = sqlstring & "openningstock-" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) & ","
        '                    'sqlstring = sqlstring & "openningvalue-(" & Val(gdataset.Tables("TrnsView").Rows(I).Item("qty")) & "*(openningvalue/openningstock)),"
        '                    ' sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "'KOT',"
        '                    ' sqlstring = sqlstring & "'" & Trim(gdataset.Tables("TrnsView").Rows(I).Item("docdetails")) & "',"
        '                    sqlstring = sqlstring & "" & Val(Nexttrns_seq) & ")"

        '                    dataOperation(6, sqlstring, )
        '                ElseIf ttype(0) = "RET" Then
        '                    sqlstring = "update STOCKTRANSFERdetail set trns_seq=" & Val(Nexttrns_seq) & " where docdetails='" & gdataset.Tables("TrnsView").Rows(I).Item("docdetails") & "' AND  itemcode='" & gdataset.Tables("TrnsView").Rows(I).Item("itemcode") & "' and docdate='" & Format(gdataset.Tables("TrnsView").Rows(I).Item("docdate"), "dd/MMM/yyyy") & "'"
        '                    dataOperation(6, sqlstring, )
        '                End If

        '            End If
        '    Next

        'End If
        'Call stockUpdate()
        '    Call valuation()
        'Catch ex As Exception
        '    MsgBox(ex.ToString())
        'End Try
        'MsgBox("Stock Manual Updation Completed....")
    End Sub

    Public Sub stockUpdate()
        'Dim sqlstring As String
        'Dim closingqty As Double
        'Dim closingvalue As Double
        'Dim i As Integer

        'sqlstring = "update  closingqty set closingstock=i.[closingqty ],closingvalue=i.closingvalue from closingqty c, inv_InventoryOpenningstock i where c.closingstock<>i.[closingqty ] and i.itemcode=c.itemcode and c.storecode=i.storecode and c.ttype='openning' and c.uom=i.uom "
        'dataOperation(6, sqlstring, )

        'sqlstring = ""
        'sqlstring = "select * from closingqty    ORDER BY CAST(CONVERT(VARCHAR(11),TRNDATE ,106) AS DATETIME),priority"
        'getDataSet(sqlstring, "closingqtyT")
        'Try


        'If (gdataset.Tables("closingqtyT").Rows.Count > 0) Then

        '        For i = 0 To gdataset.Tables("closingqtyT").Rows.Count - 1
        '            'If i <> 12687 Then
        '            '    Continue For
        '            'Else
        '            '    MsgBox("")

        '            'End If
        '            sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue from closingqty where itemcode='" & Trim(gdataset.Tables("closingqtyT").Rows(i).Item("itemcode")) & "' AND  storecode='" & Trim(gdataset.Tables("closingqtyT").Rows(i).Item("storecode")) & "'and trns_seq<" & gdataset.Tables("closingqtyT").Rows(i).Item("trns_seq") & " order by trns_seq desc"
        '            getDataSet(sqlstring, "clStock")
        '            If (gdataset.Tables("clStock").Rows.Count > 0) Then
        '                If Trim(gdataset.Tables("closingqtyT").Rows(i).Item("autoid")) = "100812" Then
        '                    'MsgBox("")

        '                End If
        '                closingqty = gdataset.Tables("clStock").Rows(0).Item("closingstock")
        '                closingvalue = gdataset.Tables("clStock").Rows(0).Item("closingvalue")
        '                sqlstring = "update closingqty set openningstock=" & Val(closingqty) & ",openningvalue=" & Val(closingvalue) & ",closingstock = case when qty=0  then " & Val(closingqty) & " else " & Val(closingqty) & "+qty end  where trns_seq=" & Trim(gdataset.Tables("closingqtyT").Rows(i).Item("trns_seq")) & ""
        '                dataOperation(6, sqlstring, )
        '            End If
        '        Next


        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString())
        'End Try
    End Sub


    Public Sub valuation()

        'Dim curDate As DateTime
        'Dim sqlstring As String
        'Dim cuDate, nDate, TRNSDATE As DateTime
        'Dim cuDate1, nDate1 As String
        'Dim Tdate() As String
        'Dim Nexttrns_seq As String
        'Dim seq As Integer = 0
        'Dim INSERT(0) As String
        'Dim trns_seq, TRNSDATE1 As String

        'Dim closingqty As Double
        'Dim closingvalue As Double
        'Dim openningstock As Double
        'Dim openningvalue As Double
        'Dim TRNrate As Double
        'Dim TRNQTY As Double
        'Dim WRATE As Double
        'Dim itemcode As String
        'Dim storecode, Storestatus As String
        'Dim RateFleg As String = "P"
        'Dim I As Integer
        'Dim nextSeqGRN, curSeqGRN As Double

        'Try

        '    sqlstring = "update  closingqty set closingvalue=i.closingvalue from closingqty c, inv_InventoryOpenningstock i where c.closingvalue<>i.closingvalue and i.itemcode=c.itemcode and c.storecode=i.storecode and c.ttype='openning' and c.uom=i.uom "
        '    dataOperation(6, sqlstring, )



        '    sqlstring = "select * from CLOSINGQTY where ttype in('GRN','Openning')  order by storecode,itemcode,priority,TRNS_SEQ"
        'getDataSet(sqlstring, "closingqty")
        'For I = 0 To gdataset.Tables("closingqty").Rows.Count - 1

        '        'If I <> "140006" Then
        '        '    Continue For
        '        'Else
        '        '    MsgBox("")

        '        'End If




        '        itemcode = gdataset.Tables("closingqty").Rows(I).Item("ITEMCODE")

        '        storecode = gdataset.Tables("closingqty").Rows(I).Item("STORECODE")

        '        If String.IsNullOrEmpty(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) Then

        '            MsgBox("Sequence no for record " & gdataset.Tables("closingqty").Rows(I).Item("trnno") & " not avilable, plz update it first ! " & Chr(13) & "weighted rate not updated..")
        '            Exit Sub
        '        Else
        '            curSeqGRN = Val(gdataset.Tables("closingqty").Rows(I).Item("TRNS_SEQ"))

        '            If I < gdataset.Tables("closingqty").Rows.Count - 1 Then

        '                If itemcode <> gdataset.Tables("closingqty").Rows(I + 1).Item("ITEMCODE") And Trim(gdataset.Tables("closingqty").Rows(I).Item("ttype").ToUpper()) = "OPENNING" Then
        '                    Continue For
        '                Else

        '                End If
        '                If itemcode = gdataset.Tables("closingqty").Rows(I + 1).Item("ITEMCODE") Then
        '                    nextSeqGRN = Val(gdataset.Tables("closingqty").Rows(I + 1).Item("TRNS_SEQ"))
        '                Else
        '                    nextSeqGRN = 0
        '                End If
        '            Else
        '                nextSeqGRN = 0
        '            End If
        '        End If



        '        Dim sql1 As String = " select rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
        '        sql1 = sql1 & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" & itemcode & "'  "
        '        getDataSet(sql1, "ratelist2")
        '        If (gdataset.Tables("ratelist2").Rows.Count > 0) Then
        '            RateFleg = gdataset.Tables("ratelist2").Rows(0).Item("rateflag")

        '        Else
        '            MsgBox("Fill RATEFLAG detail of itemcode= " & itemcode & "  in ItemMaster")

        '            Continue For
        '        End If


        '        sqlstring = "select Storestatus from StoreMaster WHERE STORECODE='" & storecode & "' and isnull(Freeze,'')<>'Y' "
        '        getDataSet(sqlstring, "STOREMASTER")

        '        If (gdataset.Tables("STOREMASTER").Rows.Count > 0) Then
        '            Storestatus = gdataset.Tables("STOREMASTER").Rows(0).Item("Storestatus")
        '        Else
        '            MsgBox("Fill Storestatus  of STORECODE= " & storecode & "  in StoreMaster")

        '            Continue For
        '        End If

        '        If Trim(Storestatus.ToUpper()) = "M" And gdataset.Tables("closingqty").Rows(I).Item("ttype") = "GRN" Then



        '            If Trim(RateFleg.ToUpper()) = "W" Then

        '                sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and trndate<'" & Format(CDate(gdataset.Tables("closingqty").Rows(I).Item("trndate")), "dd/MMM/yyyy") & "' order by TRNS_SEQ DESC"
        '                getDataSet(sqlstring, "closingqty1")

        '                If (gdataset.Tables("closingqty1").Rows.Count > 0) Then

        '                    closingqty = gdataset.Tables("closingqty1").Rows(0).Item("closingstock")
        '                    closingvalue = gdataset.Tables("closingqty1").Rows(0).Item("closingvalue")
        '                    openningstock = gdataset.Tables("closingqty1").Rows(0).Item("openningstock")
        '                    openningvalue = gdataset.Tables("closingqty1").Rows(0).Item("openningvalue")
        '                Else
        '                    closingqty = 0
        '                    closingvalue = 0
        '                End If

        '                sqlstring = "SELECT * FROM Grn_details WHERE grndetails='" & gdataset.Tables("closingqty").Rows(I).Item("TRNNO") & "' and itemcode='" & itemcode & "'"
        '                getDataSet(sqlstring, "Grn_details")
        '                If (gdataset.Tables("Grn_details").Rows.Count > 0) Then

        '                    TRNQTY = Val(gdataset.Tables("Grn_details").Rows(0).Item("qty"))
        '                    TRNrate = Val(Val(gdataset.Tables("Grn_details").Rows(0).Item("amountafterdiscount")) / Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")))
        '                    'Dim OLDRATE As Double
        '                    'Dim TRNRATE As Double

        '                    'If closingqty <= 0 Then
        '                    '    OLDRATE = 0
        '                    'Else
        '                    '    OLDRATE = closingvalue / closingqty
        '                    'End If
        '                    'Dim OVal As Double = closingvalue
        '                    'Dim TVal As Double = TRNrate * TRNQTY
        '                    'Dim CQty As Double = closingqty + TRNQTY
        '                    'WRATE = (closingvalue + TVal) / CQty

        '                    WRATE = CalweightedRate(closingvalue, Val(gdataset.Tables("Grn_details").Rows(0).Item("amountafterdiscount")), closingqty, TRNQTY)
        '                    If WRATE < 0 Then
        '                        WRATE = 1
        '                    End If
        '                    If String.IsNullOrEmpty(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) Then

        '                        MsgBox("Sequence no for record " & gdataset.Tables("closingqty").Rows(I).Item("trnno") & " not avilable, plz update it first ! " & Chr(13) & "weighted rate not updated..")
        '                        Exit Sub
        '                    Else
        '                        If nextSeqGRN <> 0 Then
        '                            sqlstring = "update CLOSINGQTY set closingvalue= " & WRATE & "*closingstock where  itemcode='" & itemcode & "' and trns_seq =" & Val(curSeqGRN) & " and storecode='" & storecode & "'"
        '                            dataOperation(6, sqlstring, )

        '                            sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(WRATE) & ",closingvalue=" & WRATE & "*closingstock where  itemcode='" & itemcode & "' and trns_seq between " & Val(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) + 1 & " and " & Val(nextSeqGRN) - 1 & " and storecode='" & storecode & "'"
        '                            dataOperation(6, sqlstring, )

        '                            sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(WRATE) & "  where  itemcode='" & itemcode & "' and trns_seq = " & Val(nextSeqGRN) & "  and storecode='" & storecode & "'"
        '                            dataOperation(6, sqlstring, )
        '                        Else
        '                            sqlstring = "update CLOSINGQTY set closingvalue= " & Val(WRATE) & "*closingstock where  itemcode='" & itemcode & "' and trns_seq =" & Val(curSeqGRN) & " and storecode='" & storecode & "'"
        '                            dataOperation(6, sqlstring, )
        '                            sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(WRATE) & ",closingvalue=" & Val(WRATE) & "*closingstock where  itemcode='" & itemcode & "' and trns_seq > " & Val(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) + 1 & ""
        '                            dataOperation(6, sqlstring, )
        '                        End If

        '                    End If


        '                End If
        '            Else
        '                sqlstring = "SELECT * FROM Grn_details WHERE grndetails='" & gdataset.Tables("closingqty").Rows(I).Item("TRNNO") & "' and itemcode='" & itemcode & "'"
        '                getDataSet(sqlstring, "Grn_details")
        '                If (gdataset.Tables("Grn_details").Rows.Count > 0) Then
        '                    TRNrate = Val(Val(gdataset.Tables("Grn_details").Rows(0).Item("amountafterdiscount")) / Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")))

        '                End If

        '                If String.IsNullOrEmpty(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) Then

        '                    MsgBox("Sequence no for record " & gdataset.Tables("closingqty").Rows(I).Item("trnno") & " not avilable, plz update it first ! " & Chr(13) & "weighted rate not updated..")
        '                    Exit Sub
        '                Else
        '                    If nextSeqGRN <> 0 Then
        '                        sqlstring = "update CLOSINGQTY set closingvalue= " & TRNrate & "*closingstock where  itemcode='" & itemcode & "' and trns_seq =" & Val(curSeqGRN) & " and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )

        '                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(TRNrate) & ",closingvalue=" & TRNrate & "*closingstock where  itemcode='" & itemcode & "' and trns_seq between " & Val(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) + 1 & " and " & Val(nextSeqGRN) - 1 & " and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )

        '                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(TRNrate) & "  where  itemcode='" & itemcode & "' and trns_seq = " & Val(nextSeqGRN) & "  and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )
        '                    Else
        '                        sqlstring = "update CLOSINGQTY set closingvalue= " & Val(TRNrate) & "*closingstock where  itemcode='" & itemcode & "' and trns_seq =" & Val(curSeqGRN) & " and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )
        '                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(TRNrate) & ",closingvalue=" & Val(TRNrate) & "*closingstock where  itemcode='" & itemcode & "' and trns_seq > " & Val(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) + 1 & ""
        '                        dataOperation(6, sqlstring, )
        '                    End If

        '                End If


        '            End If

        '            ' End If
        '        ElseIf Trim(Storestatus.ToUpper()) = "M" And gdataset.Tables("closingqty").Rows(I).Item("ttype") = "Openning" Then
        '            If Trim(RateFleg.ToUpper()) = "W" Then
        '                sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and trns_seq<=" & gdataset.Tables("closingqty").Rows(I).Item("trns_seq") & " order by trns_seq desc"
        '                getDataSet(sqlstring, "closingqty1")

        '                If (gdataset.Tables("closingqty1").Rows.Count > 0) Then

        '                    closingqty = Val(gdataset.Tables("closingqty1").Rows(0).Item("closingstock"))
        '                    closingvalue = Val(gdataset.Tables("closingqty1").Rows(0).Item("closingvalue"))
        '                    If closingqty < 1 Then
        '                        TRNrate = 1
        '                    Else
        '                        TRNrate = Val(closingvalue \ closingqty)
        '                    End If

        '                End If


        '                If String.IsNullOrEmpty(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) Then

        '                    MsgBox("Sequence no for record " & gdataset.Tables("closingqty").Rows(I).Item("trnno") & " not avilable, plz update it first ! " & Chr(13) & "weighted rate not updated..")
        '                    Exit Sub
        '                Else
        '                     If nextSeqGRN <> 0 Then
        '                        sqlstring = "update CLOSINGQTY set closingvalue= " & TRNrate & "*closingstock where  itemcode='" & itemcode & "' and trns_seq =" & Val(curSeqGRN) & " and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )

        '                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(TRNrate) & ",closingvalue=" & TRNrate & "*closingstock where  itemcode='" & itemcode & "' and trns_seq between " & Val(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) + 1 & " and " & Val(nextSeqGRN) - 1 & " and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )

        '                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(TRNrate) & "  where  itemcode='" & itemcode & "' and trns_seq = " & Val(nextSeqGRN) & "  and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )
        '                    Else
        '                        sqlstring = "update CLOSINGQTY set closingvalue= " & Val(TRNrate) & "*closingstock where  itemcode='" & itemcode & "' and trns_seq =" & Val(curSeqGRN) & " and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )
        '                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(TRNrate) & ",closingvalue=" & Val(TRNrate) & "*closingstock where  itemcode='" & itemcode & "' and trns_seq > " & Val(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) + 1 & ""
        '                        dataOperation(6, sqlstring, )
        '                    End If

        '                End If


        '            Else
        '                sqlstring = "SELECT * FROM Grn_details WHERE grndetails='" & gdataset.Tables("closingqty").Rows(I).Item("TRNNO") & "' and itemcode='" & itemcode & "'"
        '                getDataSet(sqlstring, "Grn_details")
        '                If (gdataset.Tables("Grn_details").Rows.Count > 0) Then
        '                    TRNrate = Val(Val(gdataset.Tables("Grn_details").Rows(0).Item("amountafterdiscount")) / Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")))

        '                End If

        '                If String.IsNullOrEmpty(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) Then

        '                    MsgBox("Sequence no for record " & gdataset.Tables("closingqty").Rows(I).Item("trnno") & " not avilable, plz update it first ! " & Chr(13) & "weighted rate not updated..")
        '                    Exit Sub

        '                Else
        '                     If nextSeqGRN <> 0 Then
        '                        sqlstring = "update CLOSINGQTY set closingvalue= " & TRNrate & "*closingstock where  itemcode='" & itemcode & "' and trns_seq =" & Val(curSeqGRN) & " and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )

        '                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(TRNrate) & ",closingvalue=" & TRNrate & "*closingstock where  itemcode='" & itemcode & "' and trns_seq between " & Val(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) + 1 & " and " & Val(nextSeqGRN) - 1 & " and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )

        '                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(TRNrate) & "  where  itemcode='" & itemcode & "' and trns_seq = " & Val(nextSeqGRN) & "  and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )
        '                    Else
        '                        sqlstring = "update CLOSINGQTY set closingvalue= " & Val(TRNrate) & "*closingstock where  itemcode='" & itemcode & "' and trns_seq =" & Val(curSeqGRN) & " and storecode='" & storecode & "'"
        '                        dataOperation(6, sqlstring, )
        '                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(TRNrate) & ",closingvalue=" & Val(TRNrate) & "*closingstock where  itemcode='" & itemcode & "' and trns_seq > " & Val(gdataset.Tables("closingqty").Rows(I).Item("trns_seq")) + 1 & ""
        '                        dataOperation(6, sqlstring, )
        '                    End If

        '                End If



        '            End If
        '        End If
        '    Next
        'Catch ex As Exception
        '    MsgBox(ex.ToString())
        'End Try
        'MsgBox("Stock rate Manual Updation Completed....")
    End Sub


    Public Function CalweightedRate(ByVal clsval As Double, ByVal trnsval As Double, ByVal clsqty As Double, ByVal trnsqty As Double) As Double

        Return Math.Round(Double.Parse((clsval + trnsval) / (clsqty + trnsqty)), 2)
    End Function

    Public Function CalStockValue(ByVal storecode As String, ByVal itemcode As String, TRNS_SEQ As Double) As Boolean
        Dim sqlstring, RateFleg As String
        Dim closingqty, closingvalue, PreRate, TRNrate, TRNvalue, TRNqty, rate, rate1, nextSeqGRN, curSeqGRN As Double
        Dim i As Integer

        dataOperation(6, "update closingqty set openningstock=isnull((select sum(qty) from closingqty a where a.itemcode=closingqty.itemcode and a.storecode=closingqty.storecode and a.TRNS_SEQ<closingqty.TRNS_SEQ group by a.storecode,a.itemcode),0) ", )
        dataOperation(6, "update closingqty set closingstock=openningstock+qty", )

        sqlstring = "update closingqty set openningvalue=0 where openningstock=0 "
        dataOperation(6, sqlstring, )
        sqlstring = "update closingqty set closingvalue=0 where closingstock=0 "
        dataOperation(6, sqlstring, )


        sqlstring = "select * from CLOSINGQTY where ttype='GRN' AND ISNULL(QTY,0)<>0 and itemcode='" & Trim(itemcode) & "' and storecode='" & Trim(storecode) & "' and  TRNS_SEQ>= " & Val(TRNS_SEQ) & " order by TRNS_SEQ"
        getDataSet(sqlstring, "CLOSINGQTY")

        If (gdataset.Tables("CLOSINGQTY").Rows.Count > 0) Then

            sqlstring = " select rateflag from INVENTORYCATEGORYMASTER inner join INV_InventoryItemMaster"
            sqlstring = sqlstring & " on INVENTORYCATEGORYMASTER.CATEGORYCODE=INV_InventoryItemMaster.category and itemcode='" & itemcode & "'  "
            getDataSet(sqlstring, "ratelist")
            If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                RateFleg = gdataset.Tables("ratelist").Rows(0).Item("rateflag")
            Else
                MsgBox("Fill properly detail of itemcode= " & itemcode & "  in ItemMaster")
                Exit Function
            End If


            For i = 0 To gdataset.Tables("CLOSINGQTY").Rows.Count - 1

                curSeqGRN = Val(gdataset.Tables("CLOSINGQTY").Rows(i).Item("trns_seq"))

                If TRNS_SEQ < curSeqGRN And i = 0 Then

                    sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and trns_seq<" & Val(TRNS_SEQ) & " and closingstock<>0 and ttype in ('GRN') order by TRNS_SEQ DESC"
                    getDataSet(sqlstring, "lastTrn1")

                    If (gdataset.Tables("lastTrn1").Rows.Count > 0) Then

                        closingqty = Val(gdataset.Tables("lastTrn1").Rows(0).Item("closingstock"))
                        closingvalue = Val(gdataset.Tables("lastTrn1").Rows(0).Item("closingvalue"))
                        If closingqty = 0 Then
                            Continue For
                        Else
                            rate1 = closingvalue / closingqty
                        End If


                    Else
                        closingqty = 0
                        closingvalue = 0
                        rate1 = 0
                    End If

                    sqlstring = "update CLOSINGQTY set closingvalue= " & rate1 & "*closingstock ,RATE =" & rate1 & "  where  itemcode='" & itemcode & "' and trns_seq =" & TRNS_SEQ & " and storecode='" & storecode & "'"
                    dataOperation(6, sqlstring, )

                    sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(rate1) & ",closingvalue=" & rate1 & "*closingstock,RATE =" & rate1 & " where  itemcode='" & itemcode & "' and trns_seq between " & Val(TRNS_SEQ + 1) & " and " & Val(curSeqGRN) - 1 & ""
                    dataOperation(6, sqlstring, )

                    sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(rate1) & "  where  itemcode='" & itemcode & "' and trns_seq = " & Val(curSeqGRN) & "  and storecode='" & storecode & "'"
                    dataOperation(6, sqlstring, )
                End If

                sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and trns_seq<" & Val(gdataset.Tables("CLOSINGQTY").Rows(i).Item("TRNS_SEQ")) & " order by TRNS_SEQ DESC"
                getDataSet(sqlstring, "lastTrn")

                If (gdataset.Tables("lastTrn").Rows.Count > 0) Then

                    closingqty = Val(gdataset.Tables("lastTrn").Rows(0).Item("closingstock"))
                    closingvalue = Val(gdataset.Tables("lastTrn").Rows(0).Item("closingvalue"))
                Else
                    closingqty = 0
                    closingvalue = 0
                End If
                sqlstring = "SELECT amount,qty,ISNULL(RET_qty,0) AS RET_qty FROM Grn_details WHERE grndetails='" & gdataset.Tables("CLOSINGQTY").Rows(i).Item("TRNNO") & "' and itemcode='" & itemcode & "'"
                getDataSet(sqlstring, "Grn_details")


                If (gdataset.Tables("Grn_details").Rows.Count > 0) Then
                    TRNqty = Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) - Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty"))

                    'If Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")) <> 0 Then
                    '    TRNvalue = (Val(gdataset.Tables("Grn_details").Rows(0).Item("amount")) / Val(gdataset.Tables("Grn_details").Rows(0).Item("qty"))) * (Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) - Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")))
                    'Else
                    '    TRNvalue = Val(gdataset.Tables("Grn_details").Rows(0).Item("amount"))
                    'End If

                    If TRNqty = 0 Then
                        sqlstring = "SELECT TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue from closingqty where itemcode='" & itemcode & "' AND  storecode='" & storecode & "'and  trns_seq<" & Val(gdataset.Tables("CLOSINGQTY").Rows(i).Item("TRNS_SEQ")) & " AND TTYPE IN ('GRN') order by TRNS_SEQ DESC "
                        getDataSet(sqlstring, "Grn_detailsbACK")
                        If (gdataset.Tables("Grn_detailsbACK").Rows.Count > 0) Then
                            TRNvalue = Val(gdataset.Tables("Grn_detailsbACK").Rows(0).Item("closingvalue"))
                            TRNqty = Val(gdataset.Tables("Grn_detailsbACK").Rows(0).Item("closingstock"))
                        End If
                    Else
                        If Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")) <> 0 Then
                            TRNvalue = (Val(gdataset.Tables("Grn_details").Rows(0).Item("amount")) / Val(gdataset.Tables("Grn_details").Rows(0).Item("qty"))) * (Val(gdataset.Tables("Grn_details").Rows(0).Item("qty")) - Val(gdataset.Tables("Grn_details").Rows(0).Item("RET_qty")))
                        Else
                            TRNvalue = Val(gdataset.Tables("Grn_details").Rows(0).Item("amount"))
                        End If
                    End If
                End If
                If Trim(RateFleg.ToUpper()) = "W" Then

                    rate = Math.Round((closingvalue + TRNvalue) / (closingqty + TRNqty), 3)
                    If Double.IsNaN(rate) Then

                    End If
                Else
                    rate = Math.Round(TRNvalue / TRNqty, 3)
                End If

                'If (gdataset.Tables("Grn_details").Rows.Count > 0) Then
                '    TRNvalue = Val(gdataset.Tables("Grn_details").Rows(0).Item("amount"))
                '    TRNqty = Val(gdataset.Tables("Grn_details").Rows(0).Item("qty"))
                'End If

                'If Trim(RateFleg.ToUpper()) = "W" Then
                '    If (TRNqty + closingqty) = 0 Then
                '        Continue For
                '    Else
                '        rate = (closingvalue + TRNvalue) / (closingqty + TRNqty)
                '    End If

                'Else
                '    If TRNqty = 0 Then
                '        Continue For
                '    Else
                '        rate = TRNvalue / TRNqty
                '    End If

                'End If


                If i < gdataset.Tables("CLOSINGQTY").Rows.Count - 1 Then

                    curSeqGRN = Val(gdataset.Tables("CLOSINGQTY").Rows(i).Item("trns_seq"))
                    nextSeqGRN = Val(gdataset.Tables("CLOSINGQTY").Rows(i + 1).Item("trns_seq"))

                    sqlstring = "update CLOSINGQTY set closingvalue= " & rate & "*closingstock ,RATE =" & rate & " where  itemcode='" & itemcode & "' and trns_seq =" & curSeqGRN & " and storecode='" & storecode & "'"
                    dataOperation(6, sqlstring, )

                    sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(rate) & ",closingvalue=" & rate & "*closingstock,RATE =" & rate & " where  itemcode='" & itemcode & "' and trns_seq between " & Val(curSeqGRN + 1) & " and " & Val(nextSeqGRN) - 1 & ""
                    dataOperation(6, sqlstring, )

                    sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(rate) & "  where  itemcode='" & itemcode & "' and trns_seq = " & Val(nextSeqGRN) & "  and storecode='" & storecode & "'"
                    dataOperation(6, sqlstring, )
                Else


                    If i = 0 Then
                        sqlstring = "update CLOSINGQTY set closingvalue= " & rate & "*closingstock, RATE =" & rate & "  where  itemcode='" & itemcode & "' and trns_seq =" & curSeqGRN & " and storecode='" & storecode & "'"
                        dataOperation(6, sqlstring, )

                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(rate) & ",closingvalue=" & rate & "*closingstock , RATE =" & rate & " where  itemcode='" & itemcode & "' and trns_seq > " & Val(curSeqGRN + 1) & ""
                        dataOperation(6, sqlstring, )

                        'sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(rate) & "  where  itemcode='" & itemcode & "' and trns_seq = " & Val(TRNS_SEQ) & "  and storecode='" & storecode & "'"
                        'dataOperation(6, sqlstring, )
                    Else
                        sqlstring = "update CLOSINGQTY set closingvalue= " & rate & "*closingstock , RATE =" & rate & "  where  itemcode='" & itemcode & "' and trns_seq =" & nextSeqGRN & " and storecode='" & storecode & "'"
                        dataOperation(6, sqlstring, )
                        sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(rate) & ",closingvalue=" & rate & "*closingstock, RATE =" & rate & " where  itemcode='" & itemcode & "' and trns_seq > " & Val(nextSeqGRN + 1) & ""
                        dataOperation(6, sqlstring, )
                    End If

                End If

            Next
        Else
            sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,ISNULL(openningstock,0) AS openningstock,OPENNingvalue,rate from closingqty where itemcode='" & itemcode & "' AND   trns_seq<" & Val(TRNS_SEQ) & " and ttype in ('GRN','Openning') and qty<>0  order by TRNS_SEQ DESC"
            getDataSet(sqlstring, "lastTrn1")

            If (gdataset.Tables("lastTrn1").Rows.Count > 0) Then


                'closingqty = Val(gdataset.Tables("lastTrn1").Rows(0).Item("closingstock"))
                'closingvalue = Val(gdataset.Tables("lastTrn1").Rows(0).Item("closingvalue"))
                'If closingqty = 0 Then
                '    Exit Function
                'Else
                rate1 = Val(gdataset.Tables("lastTrn1").Rows(0).Item("rate"))

                ' End If


            Else
                closingqty = 0
                closingvalue = 0
                rate1 = 0
        End If

            sqlstring = "update CLOSINGQTY set closingvalue= ISNULL((" & rate1 & " * closingstock),0),RATE =ISNULL(" & rate1 & ",0)  where  itemcode='" & itemcode & "' and trns_seq =" & TRNS_SEQ & " and storecode='" & storecode & "'"
            dataOperation(6, sqlstring, )

            sqlstring = "update CLOSINGQTY set openningvalue=ISNULL(openningstock*" & Val(rate1) & ",0), closingvalue=ISNULL(" & rate1 & " * closingstock,0) ,RATE =ISNULL(" & rate1 & ",0) where  itemcode='" & itemcode & "' and trns_seq > " & Val(TRNS_SEQ + 1) & ""
            dataOperation(6, sqlstring, )

            'sqlstring = "update CLOSINGQTY set openningvalue=openningstock*" & Val(rate1) & "  where  itemcode='" & itemcode & "' and trns_seq = " & Val(curSeqGRN) & "  and storecode='" & storecode & "'"
            'dataOperation(6, sqlstring, )
        End If

        dataOperation(6, "update CLOSINGQTY set closingvalue=ISNULL((ISNULL(rate,0)*ISNULL(closingstock,0)),0) WHERE  itemcode='" & itemcode & "' AND storecode='" & storecode & "'", )

        dataOperation(6, ";WITH OPVAL AS(   SELECT ROW_NUMBER() OVER ( ORDER BY TRNS_SEQ  ) AS RECORDNO,closingvalue, TRNS_SEQ,itemcode,storecode  FROM CLOSINGQTY WHERE itemcode='" & itemcode & "' AND storecode='" & storecode & "'), OPVAlupd AS(   SELECT ROW_NUMBER() OVER ( ORDER BY TRNS_SEQ  ) AS RECORDNO,closingvalue, TRNS_SEQ,itemcode,storecode  FROM CLOSINGQTY WHERE itemcode='" & itemcode & "' AND storecode='" & storecode & "' ) update CLOSINGQTY set openningvalue = Isnull(b.closingvalue,0)  from OPVAL a inner join OPVAlupd b on a.RECORDNO=b.RECORDNO+1  where a.TRNS_SEQ=CLOSINGQTY.TRNS_SEQ", )
        
        sqlstring = " update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end ,  lastweightedrate=  case when openningvalue=0 then "
        sqlstring = sqlstring & " batchrate    Else  openningvalue/openningstock End  "
        sqlstring = sqlstring & " from ratelist r inner join CLOSINGQTY on r.grnno=CLOSINGQTY.trnno where"
        sqlstring = sqlstring & " trndate = r.grndate And CLOSINGQTY.storecode = r.storecode And CLOSINGQTY.itemcode = r.Itemcode and CLOSINGQTY.openningstock<>0 AND CLOSINGQTY.ttype='GRN' AND  CLOSINGQTY.itemcode='" & itemcode & "' and CLOSINGQTY.storecode='" & storecode & "' "

        dataOperation(6, sqlstring, "ratelist")
    End Function


    Public Function Getconnection() As String
        Try
            sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            Return sqlconnection
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Public Function closingbatch(ByVal grndate As String, ByVal itemcode1 As String, ByVal store As String, ByVal uom1 As String) As DataSet
        Dim ds As DataSet = Nothing
        Dim sql As String = " exec closingstock '" & Format(CDate(grndate), "dd/MMM/yyyy") & "','" & itemcode1 & "' ,'" & Trim(store) & "','" & uom1 & "'"
        dataOperation(6, sql, "closingstock")
    End Function
    Public Function BatchWiseClosingStock(ByVal trndate As String, ByVal itemcode As String, ByVal storecode As String, ByVal Batchno As String) As DataSet
        If GBATCHNO = "Y" Then
            Dim sql11 As String = "select SUM(QTY) as closingstock,uom,sum(isnull(BATCHRATE*qty,0)) as closingvalue,batchno,sum(isnull(BATCHRATE*qty,0))/SUM(QTY)  Rate from closingqty where  itemcode='" + itemcode + "' and storecode='" + storecode + "' and batchno ='" + Batchno + "' and cast(convert(varchar(11),trndate,106)as datetime)<= '" + trndate + "' group by uom,batchno  "
            getDataSet(sql11, "closingStock")
            Dim SQL2 As String = "SELECT * FROM GRN_DETAILS WHERE ITEMCODE='" + itemcode + "' AND BATCH_NO='" + Batchno + "' AND '" + trndate + "' >=expirydate  "
            getDataSet(SQL2, "expirydate")
            If (gdataset.Tables("expirydate").Rows.Count > 0) Then
                sql11 = "select SUM(0) as closingstock,uom,sum(isnull(closingvalue-openningvalue,0)) as closingvalue,batchno,0  Rate from closingqty where  itemcode='" + itemcode + "' and storecode='" + storecode + "' and batchno ='" + Batchno + "' and cast(convert(varchar(11),trndate,106)as datetime)<= '" + trndate + "' group by uom,batchno  "
                getDataSet(sql11, "closingStock")
            End If
        End If
    End Function

    Public Function closingStock(ByVal trndate As String, ByVal itemcode As String, ByVal storecode As String, ByVal uom1 As String) As DataSet
        If UCase(gShortname) = "JHIC" Then
            Dim sql11 As String = "select TOP 1 ISNULL(AUTOID,0) as AUTOID, ISNULL(closingstock,0) AS closingstock, uom,isnull(closingvalue,0) as closingvalue,isnull(TRNS_SEQ,0) as TRNS_SEQ,isnull(batchyn,'N') as batchyn,isnull(rate,0) as rate from closingqty where itemcode='" + itemcode + "' and storecode='" + storecode + "' and cast(convert(varchar(11),trndate,106)as datetime)<= '" + trndate + "' order by trndate desc,PRIORITY DESC"
            getDataSet(sql11, "closingStock")
        Else
            Dim sql11 As String = "select TOP 1 ISNULL(AUTOID,0) as AUTOID, ISNULL(closingstock,0) AS closingstock, uom,isnull(closingvalue,0) as closingvalue,isnull(TRNS_SEQ,0) as TRNS_SEQ,isnull(batchyn,'N') as batchyn,isnull(rate,0) as rate from closingqty where itemcode='" + itemcode + "' and storecode='" + storecode + "' and cast(convert(varchar(11),trndate,106)as datetime)<= '" + trndate + "' order by autoid desc,PRIORITY DESC"
            getDataSet(sql11, "closingStock")
        End If
    End Function
    Public Function oPENINGStock(ByVal trndate As String, ByVal itemcode As String, ByVal storecode As String, ByVal uom1 As String) As DataSet
        Dim sql11 As String = "select TOP 1 ISNULL(AUTOID,0) as AUTOID, ISNULL(openningstock,0) AS closingstock, uom,isnull(closingstock*RATE,0) as closingvalue,isnull(TRNS_SEQ,0) as TRNS_SEQ,isnull(batchyn,'N') as batchyn,isnull(rate,0) as rate from closingqty where itemcode='" + itemcode + "' and storecode='" + storecode + "' and cast(convert(varchar(11),trndate,106)as datetime)<= '" + trndate + "' order by autoid desc,PRIORITY DESC"
        getDataSet(sql11, "closingStock")

    End Function

    Public Function closing(ByVal grndate As String, ByVal itemcode1 As String, ByVal store As String, ByVal uom1 As String) As Double

        Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(grndate), "dd/MMM/yyyy") & "','" & itemcode1 & "' ,'" & Trim(store) & "','" & uom1 & "')"
        Dim cls As Double = getvalue(SQL)
        Return cls
    End Function

    Function getvalue(ByVal QryString As String)
        Dim objVariable As Object
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If

            Cmd.Connection = Myconn
            Cmd.CommandTimeout = 1000000000
            Cmd.CommandText = QryString
            Cmd.CommandType = CommandType.Text
            objVariable = Cmd.ExecuteScalar()
            Myconn.Close()
            Return objVariable
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            Myconn.Close()
        End Try
    End Function
    Function getdata(ByVal qry As String, ByVal qrytab As String)
        Dim datatb As New DataSet
        If Myconn.State <> ConnectionState.Open Then
            openConnection()
        End If
        Dim daa As New SqlDataAdapter(qry, Myconn)
        daa.SelectCommand.CommandTimeout = 1000000000
        daa.Fill(datatb, qrytab)
        Myconn.Close()
        Return datatb
    End Function
    Public Function getDataSet(ByVal strSQL As String, ByVal Tabname As String)
        'Dim dt As New DataTable
        Dim dt As New DataTable
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 1000000000
            gadapter.Fill(dt)
            dt.TableName = Tabname
            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function getCompanyinfo(ByVal strSQL As String, ByVal Tabname As String)
        Dim dt As New DataTable
        Try
            Call GetfrontConnection()
            ' Call openConnection()
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 1000000000
            gadapter.Fill(dt)
            dt.TableName = Tabname
            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function

    Public Function MoreTrans(ByVal str() As String)
        Dim i As Integer

        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function MoreTrans_log(ByVal str() As String)
        Dim i As Integer
        Try
            If Myconn1.State <> ConnectionState.Open Then
                openConnection_log()
            End If
            MyTrans1 = Myconn1.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans1
            Cmd.Connection = Myconn1
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans1.Commit()
            MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Myconn1.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn1.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    'MANISH================
    Public Function MoreTrans2(ByVal str() As String) As Boolean
        Dim i As Integer
        Dim flg As Boolean = False
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            ' MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            flg = True
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            flg = False
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
        Return flg
    End Function

    '==============MANISH

    Public Function MoreTrans_womsg(ByVal str() As String)
        Dim i As Integer
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function

    Public Function dataOperation(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable")
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            gtrans = Myconn.BeginTransaction
            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''
                Case 1
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Update record into Database $ *************************'''
                Case 2
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Updated Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Freeze record into Database $ **************************'''
                Case 3
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Freezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''***************************** $ UnFreezed record into Database $ ************************'''
                Case 4
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Unfreezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 5
                    '****************************** $ Always Give Full Select Statement without Any Condition $ *******'''
                    gadapter = New SqlDataAdapter(ssql, Myconn)
                    gadapter.SelectCommand.CommandTimeout = 1000000000
                    If gdataset.Tables.Contains(Tabname) = True Then
                        gdataset.Tables.Remove(Tabname)
                    End If
                    gadapter.Fill(gdataset.Tables(Tabname))
                    gtrans.Commit()
                Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function dataOperation2(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable") As Boolean
        Dim oprflg As Boolean = True
        Try
            openConnection_log()
            gtrans = Myconn1.BeginTransaction

            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''
                Case 1
                    gcommand = New SqlCommand(ssql, Myconn1)
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    'MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Update record into Database $ *************************'''
                Case 2
                    gcommand = New SqlCommand(ssql, Myconn1)
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    'MessageBox.Show("Record Updated Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Freeze record into Database $ **************************'''
                Case 3
                    gcommand = New SqlCommand(ssql, Myconn1)
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    'MessageBox.Show("Record Freezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''***************************** $ UnFreezed record into Database $ ************************'''
                Case 4
                    gcommand = New SqlCommand(ssql, Myconn1)
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    'MessageBox.Show("Record Unfreezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 5
                    '****************************** $ Always Give Full Select Statement without Any Condition $ *******'''
                    gadapter = New SqlDataAdapter(ssql, Myconn1)
                    If gdataset.Tables.Contains(Tabname) = True Then
                        gdataset.Tables.Remove(Tabname)
                    End If
                    gadapter.Fill(gdataset.Tables(Tabname))
                    gtrans.Commit()
                Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            oprflg = False

        Finally
            closeConnection()
        End Try

        Return oprflg
    End Function
    Public Sub dataOperation1(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable")
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            gtrans = Myconn.BeginTransaction
            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''

                Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            'MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            closeConnection()
        End Try
    End Sub
    Public Sub openConnection()
        Try
            If Trim(gserver & "") <> "" Then
                sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            Else
                sqlconnection = "Data Source= (local);Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & gDatabase & ";"
            End If
            Myconn.ConnectionString = sqlconnection
            Myconn.Open()
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub openConnection_log()
        Try
            If Trim(gserver & "") <> "" Then
                sqlconnection_log = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & Trim(History) & ";"
            Else
                sqlconnection_log = "Data Source= (local);Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= " & Trim(History) & ";"
            End If
            If Myconn1.State <> ConnectionState.Open Then
                Myconn1.ConnectionString = sqlconnection_log
                Myconn1.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Public Sub GetfrontConnection()
        Try

            If Trim(gserver & "") <> "" Then
                sqlconnection1 = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= MASTER;"
            Else
                sqlconnection1 = "Data Source= (local);Persist Security Info=False;User ID=" & ggusername & ";pwd=" & ggpassword & ";Initial Catalog= MASTER;"
            End If

            Myconn.ConnectionString = sqlconnection1
            Myconn.Open()
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub closeConnection()
        Myconn.Close()
    End Sub
    Public Function GetValues(ByVal ssql As String) As DataTable
        Dim Dt As New DataTable
        Dim Sqladapter As New SqlDataAdapter(ssql, Myconn)
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            Sqladapter.SelectCommand.CommandTimeout = 1000000000
            Sqladapter.Fill(Dt)
            Return Dt
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function ExcuteStoreProcedure(ByVal qry As String)
        Dim i As Integer
        ' Myconn.ConnectionString = sqlconnection
        EXECBOOL = False
        Try
            'Myconn.Open()
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            MyTrans.Commit()
            Myconn.Close()
            EXECBOOL = True
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Throw
        End Try
    End Function

    Public Function ExcuteStoreProcedure_Long(ByVal qry As String)
        Dim i As Integer
        ' Myconn.ConnectionString = sqlconnection
        Try
            'Myconn.Open()
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 999999999
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Throw
        End Try
    End Function



    Public Function MoreTrans1(ByVal str() As String)
        Dim i As Integer
        Try
            Myconn.Open()
            MyTrans = Myconn.BeginTransaction()
            Cmd.CommandTimeout = 1000000000
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Function FileInfo(ByVal MyFilePath As String)
        If File.Exists(MyFilePath) Then

            Dim MyFile As New FileInfo(MyFilePath)
            Filepath = MyFilePath
            FileSize = MyFile.Length
            dtCreationDate = MyFile.CreationTime
            dtLastAccessTime = MyFile.LastAccessTime
            dtLastWriteTime = MyFile.LastWriteTime

            '            MsgBox(Filepath)
            '           MsgBox(FileSize)
            '          MsgBox(dtCreationDate)
            '         MsgBox(dtLastAccessTime)
            '        MsgBox(dtLastWriteTime)

        End If
    End Function

End Class
