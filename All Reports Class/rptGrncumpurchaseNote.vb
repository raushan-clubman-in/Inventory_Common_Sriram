Imports System.Data.SqlClient
Imports System.IO
Public Class rptGrncumpurchaseNote
    Dim dr As DataRow
    Dim dc As DataColumn
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim gconnection As New GlobalClass
    Public Function ReportDetails(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMNO As String, ByVal TONO As String)
        Dim DBLDOCTOTAL, DBLGROUPTOTAL, DBLGRANDTOTAL As Double
        Dim dbltaxamount As Double
        Dim STROEDESC, DOCDETAILS As String
        Dim STOREBOOL, DOCBOOL As Boolean
        Dim I, J, K, CC, ItemCnt As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            'Filewrite.Write(Chr(14) & Chr(15))
            ItemCnt = 0
            gconnection.getDataSet(SQLSTRING, "GRNPURCHASEBILL")
            SQLSTRING = " SELECT ISNULL(SUPPLIERINVNO,'') SUPPLIERINVNO FROM GRN_HEADER WHERE GRNDETAILS = '" & gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDETAILS") & "'"
            gconnection.getDataSet(SQLSTRING, "BILLNO")

            Filewrite.WriteLine()
            Filewrite.WriteLine()
            Filewrite.WriteLine()
            Filewrite.WriteLine()
            Filewrite.WriteLine()
            'Filewrite.WriteLine(Space(50) & "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 5
            Filewrite.WriteLine(Chr(18))
            Filewrite.Write(Chr(27) & "E")
            Filewrite.WriteLine(Space(28) & Trim(gCompanyname))
            Filewrite.WriteLine()

            pagesize = pagesize + 1
            Filewrite.WriteLine(Mid(MyCompanyName, 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Mid(Address1, 1, 30) & Space(22) & Mid(Trim(PAGEHEAD(0)), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(PAGEHEAD(0))), " "), 1, 30))
            pagesize = pagesize + 1
            Filewrite.Write(Chr(18))
            Filewrite.WriteLine(Space(51) & "PO NO : " & gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("PONO"))
            Filewrite.WriteLine(Space(49) & "BILL NO : " & gdataset.Tables("BILLNO").Rows(K).Item("SUPPLIERINVNO"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("CODE : " & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERCODE"))), 1, 18) & Space(18 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERCODE"))), 1, 18))) & Space(26) & "GRN NO: " & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDETAILS"))), 1, 18) & Space(18 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDETAILS"))), 1, 18))))
            pagesize = pagesize + 1
            Filewrite.WriteLine("NAME : " & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERNAME"))), 1, 40) & Space(40 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERNAME"))), 1, 40))) & Space(5) & "DATE : " & Space(12 - Len(Mid(Format(CDate(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDATE")), "dd/MM/yyyy"), 1, 12))) & Mid(Format(CDate(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDATE")), "dd/MM/yyyy"), 1, 12))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(77, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO CODE   ITEM NAME                 UOM         QTY       RATE        AMOUNT ")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(77, "-"))
            pagesize = pagesize + 1
            If gdataset.Tables("GRNPURCHASEBILL").Rows.Count > 0 Then
                For K = 0 To gdataset.Tables("GRNPURCHASEBILL").Rows.Count - 1
                    Filewrite.WriteLine(Space(3 - Len(Trim(Mid(CStr(K + 1), 1, 3)))) & Trim(Mid(CStr(K + 1), 1, 3)) & Space(1) & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ITEMCODE"))), 1, 6) & Space(6 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ITEMCODE"))), 1, 6))) & Space(1) & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ITEMNAME"))), 1, 25) & Space(25 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ITEMNAME"))), 1, 25))) & Space(1) & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("UOM"))), 1, 5) & Space(5 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("UOM"))), 1, 5))) & Space(1) & Space(10 - Len(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("QTY")), "0.000"), 1, 10))) & Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("QTY")), "0.000"), 1, 10) & Space(1) & Space(10 - Len(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("RATE")), "0.00"), 1, 10))) & Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("RATE")), "0.00"), 1, 10) & Space(1) & Space(12 - Len(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("AMOUNT")), "0.00"), 1, 12))) & Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("AMOUNT")), "0.00"), 1, 12))
                    pagesize = pagesize + 1
                    DBLDOCTOTAL = DBLDOCTOTAL + Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("AMOUNT")), "0.00")
                    dbltaxamount = dbltaxamount + Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("TAXAMOUNT")), "0.00")
                    ItemCnt = ItemCnt + 1
                Next K
                CC = 0
                If dbltaxamount <= 0 Then
                    dbltaxamount = Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("VATAMOUNT"))
                End If
                DBLDOCTOTAL = DBLDOCTOTAL + dbltaxamount
                Filewrite.WriteLine(StrDup(77, "-"))
                If Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("TOTALAMOUNT")) <> 0 Then
                    CC = CC + 1
                    Filewrite.WriteLine(Space(43) & " GROSS AMOUNT      " & Space(15 - Len(Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("TOTALAMOUNT")), "0.00"), 1, 15)))) & Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("TOTALAMOUNT")), "0.00"), 1, 15)))
                End If
                If dbltaxamount <> 0 Then
                    CC = CC + 1
                    Filewrite.WriteLine(Space(43) & " VAT AMOUNT        " & Space(15 - Len(Trim(Mid(Format(dbltaxamount, "0.00"), 1, 15)))) & Trim(Mid(Format(dbltaxamount, "0.00"), 1, 15)))
                End If
                If Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("SURCHARGEAMT")) <> 0 Then
                    CC = CC + 1
                    Filewrite.WriteLine(Space(43) & " SURCHARGE AMOUNT  " & Space(15 - Len(Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("SURCHARGEAMT")), "0.00"), 1, 15)))) & Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("SURCHARGEAMT")), "0.00"), 1, 15)))
                End If
                If Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("DISCOUNT")) <> 0 Then
                    CC = CC + 1
                    Filewrite.WriteLine(Space(43) & " DISCOUNT AMOUNT   " & Space(15 - Len(Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("DISCOUNT")), "0.00"), 1, 15)))) & Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("DISCOUNT")), "0.00"), 1, 15)))
                End If
                If CC > 0 Then
                    Filewrite.WriteLine(Space(43) & " BILL AMOUNT       " & Space(15 - Len(Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("BILLAMOUNT")), "0.00"), 1, 15)))) & Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("BILLAMOUNT")), "0.00"), 1, 15)))
                End If
                '    Filewrite.WriteLine(Space(62) & Space(15 - Len(Trim(Mid(Format(Val(DBLDOCTOTAL), "0.00"), 1, 15)))) & Trim(Mid(Format(Val(DBLDOCTOTAL), "0.00"), 1, 15)))
                Filewrite.WriteLine(StrDup(77, "-"))

                If pagesize < 50 Then
                    For J = 1 To (50 - pagesize)
                        Filewrite.WriteLine()
                    Next
                End If
                Filewrite.WriteLine(gdataset.Tables("BILLNO").Rows(K).Item("SUPPLIERINVNO"))
                '  Filewrite.WriteLine(" Store Keeper                 Asst. Manager Purchase               Secretary ")
                Filewrite.WriteLine(Chr(12))
            Else
                MessageBox.Show("NO RECORD TO BE DISPLAYED", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Function
            End If
            '            Filewrite.Write(Chr(12))
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
    Public Function ReportDetails_sc(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMNO As String, ByVal TONO As String)
        Dim DBLDOCTOTAL, DBLGROUPTOTAL, DBLGRANDTOTAL As Double
        Dim dbltaxamount As Double
        Dim STROEDESC, DOCDETAILS, STR As String
        Dim STOREBOOL, DOCBOOL As Boolean
        Dim I, J, K, CC, ItemCnt As Integer
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            'Filewrite.Write(Chr(14) & Chr(15))
            ItemCnt = 0
            gconnection.getDataSet(SQLSTRING, "GRNPURCHASEBILL")
            SQLSTRING = " SELECT ISNULL(PODATE,'') PODATE,ISNULL(DOCTYPE,'') DOCTYPE  FROM PO_HDR WHERE PONO = '" & gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("PONO") & "'"
            gconnection.getDataSet(SQLSTRING, "POD")

            Filewrite.WriteLine()
            Filewrite.WriteLine()
            Filewrite.WriteLine()
            Filewrite.WriteLine()
            Filewrite.WriteLine()
            'Filewrite.WriteLine(Space(50) & "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 5
            Filewrite.WriteLine(Chr(18))
            Filewrite.Write(Chr(27) & "E")
            Filewrite.WriteLine(Space((90 - Len(Trim(gCompanyname))) / 2) & Trim(gCompanyname))
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space((90 - Len(Trim(PAGEHEAD(0)))) / 2) & Trim(PAGEHEAD(0)))
            pagesize = pagesize + 1
            STR = "PO NO   : " & Chr(27) & Chr(45) & Chr(49) & gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("PONO") & Chr(27) & Chr(45) & Chr(48)
            Filewrite.WriteLine(Mid(MyCompanyName, 1, 30) & Space(30 - Len(Mid(MyCompanyName, 1, 30))) & Space(30) & STR)
            pagesize = pagesize + 1
            STR = "PO DATE : " & gdataset.Tables("POD").Rows(K).Item("PODATE")
            Filewrite.WriteLine(Mid(Address1, 1, 30) & Space(30 - Len(Mid(Address1, 1, 30))) & Space(30) & STR)
            pagesize = pagesize + 1
            STR = "GRN NO  : " & Chr(27) & Chr(45) & Chr(49) & gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDETAILS") & Chr(27) & Chr(45) & Chr(48)
            Filewrite.WriteLine(Mid(Address2, 1, 30) & Space(30 - Len(Mid(Address2, 1, 30))) & Space(30) & STR)
            pagesize = pagesize + 1
            Filewrite.Write(Chr(18))
            'Filewrite.WriteLine(Space(60) & "BILL NO : " & gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERINVNO"))
            Filewrite.WriteLine(Space(60) & "GRN DATE: " & Format(CDate(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDATE")), "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("CODE : " & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERCODE"))), 1, 18) & Space(18 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERCODE"))), 1, 18))))
            pagesize = pagesize + 1
            'Filewrite.WriteLine("NAME : " & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERNAME"))), 1, 40) & Space(40 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERNAME"))), 1, 40))) & Space(13) & "GRN DATE: " & Mid(Format(CDate(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GRNDATE")), "dd/MM/yyyy"), 1, 12))
            Filewrite.WriteLine("NAME : " & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERNAME"))), 1, 40) & Space(40 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERNAME"))), 1, 40))) & Space(13) & "BILL NO : " & Mid(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("SUPPLIERINVNO"), 1, 12))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(45) & "Inventory : " & gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GLACCOUNTNAME"))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(45) & "GL AC     : " & gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("GLACCOUNTCODE") & Chr(27) & "F")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(90, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO CODE   ITEM NAME                 UOM         QTY       RATE  DISC%  VAT %      AMOUNT")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(90, "-"))
            pagesize = pagesize + 1
            Dim DISCOUNT As Integer
            If gdataset.Tables("GRNPURCHASEBILL").Rows.Count > 0 Then
                DISCOUNT = 0
                For K = 0 To gdataset.Tables("GRNPURCHASEBILL").Rows.Count - 1
                    Filewrite.Write(Space(3 - Len(Trim(Mid(CStr(K + 1), 1, 3)))) & Trim(Mid(CStr(K + 1), 1, 3)))
                    Filewrite.Write(Space(1) & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ITEMCODE"))), 1, 6) & Space(6 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ITEMCODE"))), 1, 6))))
                    Filewrite.Write(Space(1) & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ITEMNAME"))), 1, 25) & Space(25 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ITEMNAME"))), 1, 25))))
                    Filewrite.Write(Space(1) & Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("UOM"))), 1, 5) & Space(5 - Len(Mid(Trim(CStr(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("UOM"))), 1, 5))))
                    Filewrite.Write(Space(1) & Space(10 - Len(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("QTY")), "0.000"), 1, 10))) & Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("QTY")), "0.000"), 1, 10))
                    Filewrite.Write(Space(1) & Space(10 - Len(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("RATE")), "0.00"), 1, 10))) & Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("RATE")), "0.00"), 1, 10))
                    DISCOUNT = (Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("ddiscount")) / Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("AMOUNT"))) * 100
                    Filewrite.Write(Space(1) & Space(5 - Len(Format(DISCOUNT, "0.00"))) & Format(DISCOUNT, "0.00"))
                    Filewrite.Write(Space(1) & Space(5 - Len(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("TAXPER")), "##,##0.00"), 1, 5))) & Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("TAXPER")), "##,##0.00"), 1, 5))
                    Filewrite.WriteLine(Space(1) & Space(12 - Len(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("AMOUNT")), "##,##0.00"), 1, 12))) & Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("AMOUNT")), "##,##0.00"), 1, 12))
                    pagesize = pagesize + 1
                    DBLDOCTOTAL = DBLDOCTOTAL + Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("AMOUNT")), "##,##0.00")
                    dbltaxamount = dbltaxamount + Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(K).Item("TAXAMOUNT")), "##,##0.00")
                    ItemCnt = ItemCnt + 1
                Next K
                CC = 0
                If dbltaxamount <= 0 Then
                    dbltaxamount = Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("VATAMOUNT"))
                End If
                DBLDOCTOTAL = DBLDOCTOTAL + dbltaxamount
                Filewrite.WriteLine(StrDup(90, "-"))
                If Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("TOTALAMOUNT")) <> 0 Then
                    CC = CC + 1
                    Filewrite.WriteLine(Space(55) & " GROSS AMOUNT      " & Space(15 - Len(Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("TOTALAMOUNT")), "##,##0.00"), 1, 15)))) & Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("TOTALAMOUNT")), "##,##0.00"), 1, 15)))
                    pagesize = pagesize + 1
                End If
                If dbltaxamount <> 0 Then
                    CC = CC + 1
                    Filewrite.WriteLine(Space(55) & " VAT AMOUNT        " & Space(15 - Len(Trim(Mid(Format(dbltaxamount, "0.00"), 1, 15)))) & Trim(Mid(Format(dbltaxamount, "##,##0.00"), 1, 15)))
                    pagesize = pagesize + 1
                End If
                If Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("SURCHARGEAMT")) <> 0 Then
                    CC = CC + 1
                    Filewrite.WriteLine(Space(55) & " OTHER AMOUNT  " & Space(15 - Len(Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("SURCHARGEAMT")), "##,##0.00"), 1, 15)))) & Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("SURCHARGEAMT")), "##,##0.00"), 1, 15)))
                    pagesize = pagesize + 1
                End If
                If Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("DISCOUNT")) <> 0 Then
                    CC = CC + 1
                    Filewrite.WriteLine(Space(55) & " DISCOUNT AMOUNT   " & Space(15 - Len(Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("DISCOUNT")), "##,##0.00"), 1, 15)))) & Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("DISCOUNT")), "##,##0.00"), 1, 15)))
                    pagesize = pagesize + 1
                End If
                If Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("OverallDISCOUNT")) <> 0 Then
                    CC = CC + 1
                    Filewrite.WriteLine(Space(55) & " OVERALL DISCOUNT  " & Space(15 - Len(Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("OverallDISCOUNT")), "##,##0.00"), 1, 15)))) & Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("OverallDISCOUNT")), "##,##0.00"), 1, 15)))
                    pagesize = pagesize + 1
                End If
                If CC > 0 Then
                    Filewrite.WriteLine(Space(55) & " BILL AMOUNT       " & Space(15 - Len(Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("BILLAMOUNT")), "##,##0.00"), 1, 15)))) & Trim(Mid(Format(Val(gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("BILLAMOUNT")), "##,##0.00"), 1, 15)))
                    pagesize = pagesize + 1
                End If
                '    Filewrite.WriteLine(Space(62) & Space(15 - Len(Trim(Mid(Format(Val(DBLDOCTOTAL), "0.00"), 1, 15)))) & Trim(Mid(Format(Val(DBLDOCTOTAL), "0.00"), 1, 15)))
                Filewrite.WriteLine(StrDup(90, "-"))
                Filewrite.WriteLine("")

                Filewrite.WriteLine("REMARKS:" & (gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("REMARKS")))
                If pagesize < 50 Then
                    For J = 1 To (50 - pagesize)
                        Filewrite.WriteLine()
                    Next
                End If

                'Filewrite.WriteLine(Chr(27) & "E" & "       Store Keeper                 Asst. Manager Purchase               Secretary " & Chr(27) & "F")
                If gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("UPDFOOTER") <> "" And gdataset.Tables("POD").Rows(0).Item("DOCTYPE") <> "DRY" Then
                    Filewrite.WriteLine(Chr(27) & "E" & (gdataset.Tables("GRNPURCHASEBILL").Rows(0).Item("UPDFOOTER")) & Chr(27) & "F")
                    Filewrite.WriteLine(Chr(12))
                Else
                    Filewrite.WriteLine(Chr(27) & "E" & "       Store Keeper                 Asst. Manager Purchase               Secretary " & Chr(27) & "F")
                    Filewrite.WriteLine(Chr(12))
                End If
Else

                    MessageBox.Show("NO RECORD TO BE DISPLAYED", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
                '            Filewrite.Write(Chr(12))
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
End Class
