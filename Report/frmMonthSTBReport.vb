Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmMonthSTBReport
    Dim i As Integer
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Private Sub frmMonthSTBReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call FILLGRID_STORE()
        DTP_TODATE.Value = Format(Date.Now, "dd/MM/yyyy")
        DTP_FROMDATE.Value = Format(Date.Now, "dd/MM/yyyy")
    End Sub

    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 724
        K = 1024
        Me.ResizeRedraw = True

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        If U = 800 Then
            T = T - 50
        End If
        If U = 1280 Then
            T = T - 50
        End If
        If U = 1360 Then
            T = T - 75
        End If
        If U = 1366 Then
            T = T - 75
        End If
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Width = U
        Me.Height = T


        With Me
            For i_i = 0 To .Controls.Count - 1
                ' MsgBox(Controls(i_i).Name)
                If TypeOf .Controls(i_i) Is Form Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0
                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If
                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is Panel Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is GroupBox Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "GroupBox3" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If

                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is Label Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                End If
            Next i_i
        End With
    End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If

        Me.Cmd_View.Enabled = False

        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then

                    Me.Cmd_View.Enabled = True

                    Exit Sub
                End If

                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True

                End If
                If Right(x) = "U" Then
                    'Me.btn_validation.Enabled = True
                End If
                If Right(x) = "P" Then
                    ' Me.cmd_print.Enabled = True
                End If
            Next
        End If
    End Sub

    Public Sub FILLGRID_STORE()
        Chk_StoreCode.Items.Clear()
        sqlstring = "SELECT STORECODE FROM STOREMASTER ORDER BY Storecode "
        gconnection.getDataSet(sqlstring, "STOREMASTER")

        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            For i = 0 To (gdataset.Tables("STOREMASTER").Rows.Count - 1)
                'CMB_StoreCode.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STORECODE"))
                Chk_StoreCode.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STORECODE"))
            Next
        End If
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        'CMB_StoreCode.Text = ""
        'For i = 0 To Chk_StoreCode.CheckedItems.Count - 1
        Chk_StoreCode.SelectedItem = False
        Call FILLGRID_STORE()
        'Next
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Call STBReport()
    End Sub

    Private Sub STBReport()
        Try
            Dim str, MTYPE(), tspilt(), SITEMCODE As String
            Dim i, j As Integer
            Dim rViewer As New Viewer
            Dim r As New CrysMonthSTBRSI
            Dim Heading(0) As String
            Dim sqlstring, SSQL As String

            Dim Clsquantity, Itemcode(), Update(0), Storecode As String
            Dim Boolupdate As Boolean
            Storecode = "" : Clsquantity = "" : i = 0
            Dim SLSTRING, Itemcode1 As String
            Dim rate As Double
            Dim ITEMTABLE As DataTable


            'sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & SLSTRING & ")"
            'gconnection.getDataSet(sqlstring, "ITEMMASTER1")



            sqlstring = "DELETE FROM TempMonthSTBrsi"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "DELETE FROM MonthSTBrsi"
            gconnection.ExcuteStoreProcedure(sqlstring)

            For i = 0 To Chk_StoreCode.CheckedItems.Count - 1

                'If CMB_StoreCode.Text <> "" Then
                Storecode = Chk_StoreCode.CheckedItems(i)
                Me.Cursor = Cursors.WaitCursor


                sqlstring = " delete from stocksummary"
                gconnection.dataOperation(6, sqlstring, "stocksummary")
                sqlstring = " insert into stocksummary(itemcode,ITEMNAME,storecode,UOM,opstk,OPENNINGQTY,OPQTY) "
                sqlstring = sqlstring & " select i.itemcode,i.ITEMNAME,'" + Storecode + "',O.uom ,O.openningqty,O.openningqty,'0' "
                sqlstring = sqlstring & " from INV_InventoryItemMaster i,inv_InventoryOpenningstock O where i.itemcode=O.itemcode and  O.storecode ='" + Storecode + "'    "

                gconnection.dataOperation(6, sqlstring, "stocksummary")







                'sqlstring = "select DISTINCT itemcode from inventoryitemmaster WHERE StoreCode IN ('" & Storecode & "') and freeze<>'Y'"
                'gconnection.getDataSet(sqlstring, "inventoryitemmaster")
                'ITEMTABLE = gdataset.Tables("inventoryitemmaster")
                sqlstring = "select DISTINCT itemcode from inv_inventoryopenningstock WHERE StoreCode IN ('" & Storecode & "') and void<>'Y'"
                gconnection.getDataSet(sqlstring, "inv_inventoryopenningstock")
                ITEMTABLE = gdataset.Tables("inv_inventoryopenningstock")
                If ITEMTABLE.Rows.Count > 0 Then

                    For j = 0 To ITEMTABLE.Rows.Count - 1
                        If Itemcode1 = "" Then
                            Itemcode1 = "'" & ITEMTABLE.Rows(j).Item("itemcode").ToString() & "'"
                        Else
                            Itemcode1 = Itemcode1 & "," & "'" & ITEMTABLE.Rows(j).Item("itemcode").ToString() & "'"
                        End If
                    Next
                    'SLSTRING = SLSTRING & "'" & Itemcode(i) & "', "
                End If
                sqlstring = " update inv_INVENTORYITEMMASTER SET selectyn='N' WHERE ITEMCODE NOT IN(" & Itemcode1 & ")  "
                gconnection.ExcuteStoreProcedure(sqlstring)
                sqlstring = " update inv_INVENTORYITEMMASTER SET selectyn='Y' WHERE ITEMCODE IN(" & Itemcode1 & ") "
                gconnection.ExcuteStoreProcedure(sqlstring)








                '---------------------- EXECUTE STORE PROCEDURE --------------------------'

                sqlstring = " exec CP_stocksummary  '" + Format(gFinancialyearStart, "dd/MMM/yyyy") + "', '" + Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") + "','" + Format(DTP_TODATE.Value, "dd/MMM/yyyy  23:59:59") + "','" + Storecode + "'"
                gconnection.ExcuteStoreProcedure(sqlstring)

                'gconnection.openConnection()


                'gcommand = New SqlCommand("Cp_StockSummary3", gconnection.Myconn)

                'gcommand.CommandTimeout = 1000000000
                'gcommand.CommandType = CommandType.StoredProcedure
                ''gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
                ''gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_FROMDATE.Value), "dd/MMM/yyyy")
                ''gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy")
                '''gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate(gstartingdate), "dd/MM/yyyy")
                ''gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
                ''gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy")
                '''gcommand.Parameters.Add(New SqlParameter("@rate", SqlDbType.Float)).Value = rate
                'gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
                'gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_FROMDATE.Value), "dd/MMM/yyyy")
                'gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_TODATE.Value), "dd/MMM/yyyy")
                'gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
                'gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(DTP_TODATE.Value), "dd/MMM/yyyy")
                'gcommand.ExecuteNonQuery()
                'gconnection.closeConnection()

                '--------------------------------------------------------------------------'
                'Else
                'MessageBox.Show("Select the Store Loc.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Exit Sub
                'End If
                sqlstring = " INSERT INTO TempMonthSTBrsi (ITEMCODE, ITEMNAME, STORECODE,CLSQTY, CLSRATE, groupcode, groupname)"
                sqlstring = sqlstring & " (SELECT ITEMCODE, ITEMNAME, STORECODE, closingqty, CLRATE, groupcode, groupdesc FROM STOCKSUMMARY where storecode='" & Storecode & "')"
                gconnection.ExcuteStoreProcedure(sqlstring)
            Next
            sqlstring = "INSERT INTO MonthSTBrsi (ITEMCODE,CLSQTY, CLSRATE, groupcode, groupname)"
            sqlstring = sqlstring & " (SELECT ITEMCODE, SUM(ISNULL(CLSQTY,0)), CLSRATE, groupcode, groupname FROM TempMonthSTBrsi GROUP BY ITEMCODE, CLSRATE, groupcode, groupname)"
            gconnection.ExcuteStoreProcedure(sqlstring)

            '****** 01/12/2014
            sqlstring = "Update MonthSTBrsi set Clsrate=0 where isnull(Clsqty,0)=0"
            gconnection.ExcuteStoreProcedure(sqlstring)
            '********************



            sqlstring = "SELECT * FROM SYSOBJECTS WHERE name='View_MonthSTBrsi' AND XTYPE='V'"
            gconnection.getDataSet(sqlstring, "View_MonthSTBrsi")
            If gdataset.Tables("View_MonthSTBrsi").Rows.Count > 0 Then
                sqlstring = "ALTER VIEW View_MonthSTBrsi  "
                sqlstring = sqlstring & " AS  "
                sqlstring = sqlstring & " SELECT distinct S.ITEMCODE, I.Itemname, S.ClsqtY AS STOCKBAL, S.Clsrate AS WHOLESALERATE,(S.Clsrate + ((S.Clsrate*I.Profitper)/100))   "
                sqlstring = sqlstring & " AS RETAILRATE, (S.Clsrate * S.Clsqty) AS WHOLESALEVALUE, (S.Clsqty *(S.Clsrate + ((S.Clsrate*I.Profitper)/100))) AS RETAILVALUE,  "
                sqlstring = sqlstring & " ((S.Clsqty *(S.Clsrate + ((S.Clsrate*I.Profitper)/100))) - (S.Clsrate * S.Clsqty)) AS PROFITAMOUNT "
                sqlstring = sqlstring & " , isnull(S.groupcode,'') as GROUPCODE, ISNULL(S.groupname,'') AS GROUPNAME "
                sqlstring = sqlstring & " FROM MonthSTBrsi S, inv_INVENTORYITEMMASTER I WHERE S.Itemcode=I.itemcode  and isnull(i.void,'')<>'Y'"
                gconnection.ExcuteStoreProcedure(sqlstring)
            Else
                sqlstring = "CREATE VIEW View_MonthSTBrsi  "
                sqlstring = sqlstring & " AS  "
                sqlstring = sqlstring & " SELECT distinct S.ITEMCODE, I.Itemname, S.ClsqtY AS STOCKBAL, S.Clsrate AS WHOLESALERATE,(S.Clsrate + ((S.Clsrate*I.Profitper)/100))   "
                sqlstring = sqlstring & " AS RETAILRATE, (S.Clsrate * S.Clsqty) AS WHOLESALEVALUE, (S.Clsqty *(S.Clsrate + ((S.Clsrate*I.Profitper)/100))) AS RETAILVALUE  "
                sqlstring = sqlstring & " , isnull(groupcode,'') as GROUPCODE, ISNULL(groupname,'') AS GROUPNAME "
                sqlstring = sqlstring & " FROM MonthSTBrsi S, inv_INVENTORYITEMMASTER I WHERE S.Itemcode=I.itemcode  and isnull(i.void,'')<>'Y'"
                gconnection.ExcuteStoreProcedure(sqlstring)
            End If

            sqlstring = "SELECT distinct itemcode, isnull(itemname,'') as itemname, isnull(stockbal,0) as stockbal, isnull(wholesalerate,0) as wholesalerate, isnull(retailrate,0) as retailrate, isnull(wholesalevalue,0) as wholesalevalue, isnull(retailvalue,0) as retailvalue,isnull(profitamount,0) as profitamount, isnull(groupcode,'') as GROUPCODE, ISNULL(groupname,'') AS GROUPNAME  FROM View_MonthSTBrsi WHERE ISNULL(STOCKBAL,0)<>0 ORDER BY ITEMCODE"
            gconnection.getDataSet(sqlstring, "View_MonthSTBrsi1")
            If gdataset.Tables("View_MonthSTBrsi1").Rows.Count > 0 Then
                rViewer.TableName = "View_MonthSTBrsi1"
                rViewer.ssql = sqlstring
                rViewer.Report = r

                Dim T1 As TextObject
                T1 = r.ReportDefinition.ReportObjects("Text10")
                T1.Text = MyCompanyName

                T1 = r.ReportDefinition.ReportObjects("Text11")
                T1.Text = Address1 & ", " & Address2

                T1 = r.ReportDefinition.ReportObjects("Text15")
                T1.Text = gUsername

                T1 = r.ReportDefinition.ReportObjects("Text12")
                T1.Text = "STOCK STATUS REPORT MONTH- " & Format(DTP_TODATE.Value, "MMMMM")

                rViewer.Show()
            Else
                MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error" + ex.Message, MyCompanyName)
        End Try
    End Sub
End Class