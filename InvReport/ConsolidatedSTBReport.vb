Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class ConsolidatedSTBReport
    Dim sqlstring As String
    Dim gconnection As New GlobalClass

    Private Sub ConsolidatedSTBReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Resize_Form()
        Me.DoubleBuffered = True
        grp_SalebillChecklist.Top = 1000
        Call FillStoredetails()
        Call FillItemdetails()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub

    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 720
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
                        If Controls(i_i).Name = "frmbut" Then
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
                        ElseIf Controls(i_i).Name = "grp_orderby" Then
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
                        ElseIf Controls(i_i).Name = "GroupBox3" Then
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
                If Right(x) = "P" Then

                End If
            Next
        End If
    End Sub

    Private Sub FillItemdetails()
        Dim i As Integer
        Dim sqlstring As String
        Chklist_Itemdetails.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME FROM inv_INVENTORYITEMMASTER  ORDER BY ITEMCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                    Chklist_Itemdetails.Items.Add(Trim(CStr(.Item("ITEMCODE"))) & "-->" & Trim(CStr(.Item("ITEMNAME"))))
                End With
            Next
        End If
    End Sub
    Private Sub FillStoredetails()
        Dim i As Integer
        Dim sqlstring As String
        chklist_storecode.Items.Clear()
        '  sqlstring = "SELECT DISTINCT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE CATEGORY IN(" & USER & ") AND STORECODE IN ('MNS1','BAR','BVI','OAT','AGM','MOAT') "
        sqlstring = "SELECT DISTINCT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER "
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                With gdataset.Tables("STOREMASTER").Rows(i)
                    chklist_storecode.Items.Add(Trim(CStr(.Item("STORECODE"))))
                End With
            Next
        End If
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        chklist_storecode.Items.Clear()
        Chklist_Itemdetails.Items.Clear()
    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Dim vsqlstring, vsqlstring1 As String
       
        If chklist_storecode.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Store Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
                If Chklist_Itemdetails.CheckedItems.Count = 0 Then
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                'If CHK_VALUE.Checked = False Then
                '    MessageBox.Show("Select the Transaction", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'End If
           
        
        '*********       
        '**************************************
        Checkdaterangevalidate(Format(DTP_FROMDATE.Value, "dd/MMM/yyyy"), Format(DTP_TODATE.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        'gPrint = False
        grp_SalebillChecklist.Top = 502
        grp_SalebillChecklist.Left = 241
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 10
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Chk_SelectAllItem_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_SelectAllItem.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllItem.Checked = True Then
            For i = 0 To Chklist_Itemdetails.Items.Count - 1
                Chklist_Itemdetails.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To Chklist_Itemdetails.Items.Count - 1
                Chklist_Itemdetails.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub CHK_SELECTALL_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_SELECTALL.CheckedChanged
        Dim i As Integer
        If CHK_SELECTALL.Checked = True Then
            For i = 0 To chklist_storecode.Items.Count - 1
                chklist_storecode.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_storecode.Items.Count - 1
                chklist_storecode.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 1
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"



        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_SalebillChecklist.Top = 1000
            Call OPENING_VIEW_ALTER()
            'Call RCVVIEW_ALTER()
            Call CONSO_STB()

        End If
    End Sub

    Public Sub OPENING_VIEW_ALTER()
        Try

            Dim SLSTRING, STORECODE As String
            Dim DATE1 As Date
            DATE1 = Format(CDate("26/03/" & gFinancalyearStart), "dd/MMM/yyyy")
            I = 0
            SLSTRING = ""
            For I = 0 To chklist_storecode.CheckedItems.Count - 1
                STORECODE = chklist_storecode.CheckedItems(I)
                SLSTRING = SLSTRING & "'" & STORECODE & "', "
            Next
            SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)
            sqlstring = " ALTER VIEW VIEW_CONSSTB_OPENING "
            sqlstring = sqlstring & " AS "

            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY) AS OPQTY, SUM(AMOUNT) AS OPVALUE FROM GRN_DETAILS WHERE storecode IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),GRNDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Voiditem,'')<>'Y' GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY) * -1 AS OPQTY, SUM(AMOUNT) * -1 AS OPVALUE FROM STOCKISSUEDETAIL WHERE storeLOCATIONcode IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY)  AS OPQTY, SUM(AMOUNT) AS OPVALUE FROM STOCKISSUEDETAIL WHERE Opstorelocationcode  IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY) * -1 AS OPQTY, SUM(AMOUNT) * -1 AS OPVALUE FROM STOCKTRANSFERDETAIL WHERE Fromstorecode  IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY) AS OPQTY, SUM(AMOUNT) AS OPVALUE FROM STOCKTRANSFERDETAIL WHERE Tostorecode  IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY) * -1 AS OPQTY, SUM(AMOUNT) * -1 AS OPVALUE FROM STOCKDMGDETAIL WHERE storecode  IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY) * -1 AS OPQTY, SUM(AMOUNT) * -1 AS OPVALUE FROM SUBSTORECONSUMPTIONDETAIL WHERE Storelocationcode  IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(Adjustedstock) * -1 AS OPQTY, SUM(AMOUNT) * -1 AS OPVALUE FROM STOCKADJUSTDETAILS WHERE StoreCode  IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(consumption) * -1 AS OPQTY, SUM(AMOUNT) * -1 AS OPVALUE FROM stockConsumption_1 WHERE storecode  IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & "SELECT i.ITEMCODE, ITEMNAME, SUM([openningqty ])  AS OPQTY, SUM(openningvalue) AS OPVALUE FROM inv_inventoryopenningstock i inner join INV_InventoryItemMaster d on d.itemcode=i.itemcode WHERE storecode  IN (" & SLSTRING & ") AND ISNULL(i.void,'')<>'Y' GROUP BY i.ITEMCODE, ITEMNAME"
            gconnection.ExcuteStoreProcedure(sqlstring)

            'sqlstring = "DROP TABLE TEMP_CONSOLIDATED_STB"
            'gconnection.ExcuteStoreProcedure(sqlstring)

            'sqlstring = "CREATE TABLE TEMP_CONSOLIDATED_STB( "
            'sqlstring = sqlstring & "ITEMCODE VARCHAR (20) NULL, "
            'sqlstring = sqlstring & "ITEMNAME VARCHAR (50) NULL, "
            'sqlstring = sqlstring & "UOM VARCHAR (20) NULL, "
            'sqlstring = sqlstring & "OPQTY NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "OPRATE  NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "OPVALUE NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "RCVQTY NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "RCVRATE  NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "RCVVALUE NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "VALUEOFRATEREVISION NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "TOTALSTOCKQTY NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "TOTALATOCKVALUE NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "ISSUEQTY  NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "ISSUEVALUE NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "BALQTY NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "BALVALUE NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "LOSSDAMAGEQTY NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "PROFITONSOLDQTY NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "CLSQTY NUMERIC(18,2) NULL, "
            'sqlstring = sqlstring & "CLSVALUE NUMERIC(18,2) NULL "
            'sqlstring = sqlstring & ") "
            'gconnection.ExcuteStoreProcedure(sqlstring)

        Catch ex As Exception
            MessageBox.Show("Error on running application", ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub RCVVIEW_ALTER()
        Try

            Dim SLSTRING, STORECODE As String
            Dim DATE1 As Date
            DATE1 = Format(CDate("26/03/" & gFinancalyearStart), "dd/MMM/yyyy")
            I = 0
            SLSTRING = ""
            For I = 0 To chklist_storecode.CheckedItems.Count - 1
                STORECODE = chklist_storecode.CheckedItems(I)
                SLSTRING = SLSTRING & "'" & STORECODE & "', "
            Next
            SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)
            sqlstring = "ALTER VIEW VIEW_CONSSTB_ISSUE "
            sqlstring = sqlstring & " AS "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY) * -1 AS issqty, SUM(AMOUNT) * -1 AS issval FROM SUBSTORECONSUMPTIONDETAIL WHERE Storelocationcode IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL"
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(Adjustedstock) * -1 AS issqty, SUM(AMOUNT) * -1 AS issval FROM STOCKADJUSTDETAILS WHERE StoreCode IN (" & SLSTRING & ") AND CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            gconnection.ExcuteStoreProcedure(sqlstring)

        Catch ex As Exception
            MessageBox.Show("Error on running application", ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub CONSO_STB()
        Try
            '******* EXECUTE PROCEDURE 
            gconnection.openConnection()
            gcommand = New SqlCommand("[UPDATE_barRATE_detailed]", gconnection.Myconn)
            gcommand.CommandTimeout = 1000000000
            gcommand.CommandType = CommandType.StoredProcedure
            gcommand.ExecuteNonQuery()
            gconnection.closeConnection()

            Dim SLSTRING, STORECODE, ITEMCODE(0) As String
            Dim DATE1 As Date
            DATE1 = Format(CDate("26/03/" & gFinancalyearStart), "dd/MMM/yyyy")
            I = 0
            SLSTRING = ""
            For I = 0 To chklist_storecode.CheckedItems.Count - 1
                STORECODE = chklist_storecode.CheckedItems(I)
                SLSTRING = SLSTRING & "'" & STORECODE & "', "
            Next
            SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)
            sqlstring = "delete from TEMP_CONSOLIDATED_STB"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "INSERT INTO TEMP_CONSOLIDATED_STB (ITEMCODE,OPQTY)(select itemcode, sum(opqty) as opqty from VIEW_CONSSTB_OPENING group by ITEMCODE)"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "INSERT INTO TEMP_CONSOLIDATED_STB (ITEMCODE,RCVQTY,RCVRATE,RCVVALUE)select itemcode,SUM(qty) as rcvqty, rate, SUM(amount) as  rcvvalue from INV_BAR_FINAL_TAB_DETAILED  where CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME)  between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and storecode in (" & SLSTRING & ") and TYPE = 'grn' group by ITEMCODE, RATE order by ITEMCODE"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "INSERT INTO TEMP_CONSOLIDATED_STB (ITEMCODE,qtyforraterev,VALUEOFRATEREVISION)select itemcode,clsstock,(ROUND((LASTSTOCK * WEIGHTED_RATE),2)-ROUND((laststock * LASTRATE),2))as raterev_Value from INV_BAR_FINAL_TAB_DETAILED  where  CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME)  between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and storecode in (" & SLSTRING & ") and TYPE = 'grn' and weighted_Rate<>LASTRATE"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "insert into TEMP_CONSOLIDATED_STB(ITEMCODE,ISSUEQTY,ISSUEVALUE,issuerate)select itemcode,SUM(qty) as issueqty, SUM(amount) as issueval,rate from INV_BAR_FINAL_TAB_DETAILED  where CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "'  and storecode in (" & SLSTRING & ") and TYPE in ('CONSUMPTION','EXPEND') group by ITEMCODE, RATE"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "insert into TEMP_CONSOLIDATED_STB(ITEMCODE, LOSSDAMAGEQTY,LOSSDAMAGERATE)select itemcode,SUM(qty) as damageqty, SUM(amount) as damageval from INV_BAR_FINAL_TAB_DETAILED  where  CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME)  between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "'  and storecode in (" & SLSTRING & ") and TYPE in ('DAMAGE') group by ITEMCODE"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "insert into TEMP_CONSOLIDATED_STB(ITEMCODE,TOTALSTOCKQTY)select itemcode,SUM(qty) as totalstockqty from INV_BAR_FINAL_TAB_DETAILED  where  CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME)  between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "'  and storecode in (" & SLSTRING & ") and TYPE in ('grn','opening') group by ITEMCODE"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "insert into TEMP_CONSOLIDATED_STB(ITEMCODE,BALQTY)select itemcode,SUM(qty) as balqty from INV_BAR_FINAL_TAB_DETAILED  where  CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME)  between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "'  and storecode in (" & SLSTRING & ") and TYPE in ('grn','opening','CONSUMPTION','EXPEND') group by ITEMCODE"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "insert into TEMP_CONSOLIDATED_STB(ITEMCODE,clsqty)select itemcode,SUM(qty) as clsqty from INV_BAR_FINAL_TAB_DETAILED  where  CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME)  between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "'  and storecode in (" & SLSTRING & ") and TYPE in ('grn','opening','CONSUMPTION','EXPEND','Damage') group by ITEMCODE"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "drop table   STKOPNRATE "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "drop table stkpurchaserate "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "SELECT * INTO stkpurchaserate FROM OPENING_RATE WHERE Grndate<='" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "'  ORDER BY Grndate DESC    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "SELECT * INTO STKOPNRATE FROM   OPENING_RATE WHERE Grndate<='" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "'  ORDER BY Grndate DESC  "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "update TEMP_CONSOLIDATED_STB set Oprate=(SELECT TOP 1 rate from STKOPNRATE b where b.itemcode=TEMP_CONSOLIDATED_STB.itemcode   "
            sqlstring = sqlstring & " and b.type='GRN')    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "update TEMP_CONSOLIDATED_STB  set Oprate= (SELECT TOP 1 rate from STKOPNRATE b where b.itemcode=TEMP_CONSOLIDATED_STB.itemcode  "
            sqlstring = sqlstring & " and b.type='opening') WHERE Itemcode not in (SELECT ITEMCODE from STKOPNRATE where TYPE='grn' )   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "update TEMP_CONSOLIDATED_STB set opvalue=(OPRATE * opqty)"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = " update TEMP_CONSOLIDATED_STB set TOTALSTOCKQTY = (select sum(isnull(TOTALSTOCKQTY,0) + isnull(OPQTY,0)) from "
            sqlstring = sqlstring & " TEMP_CONSOLIDATED_STB t where TEMP_CONSOLIDATED_STB.ITEMCODE=t.ITEMCODE and ISNULL(OPQTY,0)<>0  group by itemcode) where ISNULL(OPQTY,0)<>0"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "update TEMP_CONSOLIDATED_STB set BALQTY = (select sum(isnull(BALQTY,0) + isnull(OPQTY,0)) from "
            sqlstring = sqlstring & " TEMP_CONSOLIDATED_STB t where TEMP_CONSOLIDATED_STB.ITEMCODE=t.ITEMCODE  and ISNULL(OPQTY,0)<>0  group by itemcode) where ISNULL(OPQTY,0)<>0"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "update TEMP_CONSOLIDATED_STB set CLSQTY = (select sum(isnull(CLSQTY,0) + isnull(OPQTY,0)) from "
            sqlstring = sqlstring & " TEMP_CONSOLIDATED_STB t where TEMP_CONSOLIDATED_STB.ITEMCODE=t.ITEMCODE  and ISNULL(OPQTY,0)<>0  group by itemcode) where ISNULL(OPQTY,0)<>0"
            gconnection.ExcuteStoreProcedure(sqlstring)
            'ITEMCODE = ""
            SLSTRING = ""
            For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                ITEMCODE = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                SLSTRING = SLSTRING & "'" & ITEMCODE(0) & "', "
            Next
            SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)

            '****UPDATE CLSRATE
            sqlstring = "update TEMP_CONSOLIDATED_STB set CLSRATE=(SELECT TOP 1 rate from stkpurchaserate b where b.itemcode=TEMP_CONSOLIDATED_STB.itemcode   "
            sqlstring = sqlstring & " and b.type='GRN')    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "update TEMP_CONSOLIDATED_STB  set CLSRATE= (SELECT TOP 1 rate from stkpurchaserate b where b.itemcode=TEMP_CONSOLIDATED_STB.itemcode  "
            sqlstring = sqlstring & " and b.type='opening') WHERE Itemcode not in (SELECT ITEMCODE from stkpurchaserate where TYPE='grn' )   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            '************

            sqlstring = "SELECT itemcode,itemname,stockuom,SUM(opqty) AS opqty,oprate,SUM(opvalue) AS opvalue, SUM(rcvqty) AS rcvqty,SUM(rcvvalue) AS rcvvalue,"
            sqlstring = sqlstring & " SUM(rcvrate) AS RCVRATE,SUM(VALUEOFRATEREVISION) AS VALUEOFRATEREVISION, SUM(TOTALSTOCKQTY) AS TOTALSTOCKQTY,SUM(totalstockvalue) AS totalstockvalue,"
            sqlstring = sqlstring & " SUM(qtyforraterev) AS qtyforraterev,SUM(issueqty) AS issueqty, SUM(issuevalue) AS issuevalue,SUM(issuerate) AS  issuerate,"
            sqlstring = sqlstring & " SUM(balqty) AS balqty,SUM(BALVALUE) AS BALVALUE , SUM(profitamt) AS profitamt, SUM(lossdamageqty) AS lossdamageqty,SUM(clsqty) AS clsqty,"
            sqlstring = sqlstring & " SUM(balvalue1) AS balvalue1,SUM(clsrate) AS clsrate ,groupcode,groupname,SUM(wholesaleamount) AS wholesaleamount "

            sqlstring = sqlstring & " FROM view_consolidated WHERE ITEMCODE IN (" & SLSTRING & ")  "
            sqlstring = sqlstring & " GROUP BY  itemcode,itemname,stockuom,oprate,groupcode,groupname  ORDER BY ITEMCODE"
            'sqlstring = sqlstring & " from TEMP_CONSOLIDATED_STB t, inventoryitemmaster i where t.ITEMCODE=i.itemcode "
            'sqlstring = sqlstring & " and i.storecode='MNS1' group by t.ITEMCODE, RCVRATE,OPRATE,i.itemname, i.stockuom, issuerate order by ITEMCODE"
            'sqlstring = "SELECT * FROM view_consolidated WHERE ITEMCODE IN (" & SLSTRING & ") ORDER BY ITEMCODE"
           
            If CHK_EXCEL.Checked = True Then

                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "CONSOLIDATED SUMMARY " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & " TO " & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")
            Else
                gconnection.getDataSet(sqlstring, "view_consolidated")
                If gdataset.Tables("view_consolidated").Rows.Count > 0 Then
                    Dim RVIEWER As New Viewer
                    Dim CONSOREPORT As New Crys_consolidatedreport
                    RVIEWER.ssql = sqlstring
                    RVIEWER.Report = CONSOREPORT
                    RVIEWER.TableName = "view_consolidated"
                    Dim textobj1 As TextObject
                    textobj1 = CONSOREPORT.ReportDefinition.ReportObjects("Text22")
                    textobj1.Text = MyCompanyName
                    Dim textobj2 As TextObject
                    textobj2 = CONSOREPORT.ReportDefinition.ReportObjects("Text23")
                    textobj2.Text = Address1
                    Dim textobj3 As TextObject
                    textobj3 = CONSOREPORT.ReportDefinition.ReportObjects("Text24")
                    textobj3.Text = Address2
                    Dim textobj4 As TextObject
                    textobj4 = CONSOREPORT.ReportDefinition.ReportObjects("Text30")
                    textobj4.Text = "FROM DATE: " & Format(DTP_FROMDATE.Value, "dd/MM/yyyy") & " TO DATE: " & Format(DTP_TODATE.Value, "dd/MM/yyyy")
                    RVIEWER.Show()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error on running application", ex.Message)
            Exit Sub
        End Try

    End Sub


    'Public Function CALC_WEIGHTED()
    '    Dim MITEM, SQLS, itemc As String
    '    Dim z As Integer
    '    Dim MLASTSTOCK, MLASTRATE, MCLSSTOCK As Double
    '    Array.Clear(Insert, 0, Insert.Length)
    '    Try
    '        Dim WET_SETUP As String
    '        sqlstring = "SELECT ISNULL(Setup_type,'') AS Setup_type FROM weightedRate_Master_Setup"
    '        gconnection.getDataSet(sqlstring, "WETRT")
    '        If gdataset.Tables("WETRT").Rows.Count > 0 Then
    '            WET_SETUP = gdataset.Tables("WETRT").Rows(0).Item("Setup_type")
    '        End If

    '        'itemc = Mid(itemc, 1, Len(itemc) - 1)

    '        sqlstring = "DROP TABLE INV_WEIGHTED_TAB2"
    '        gconnection.ExcuteStoreProcedure(sqlstring)
    '        SQLS = "SELECT * INTO INV_WEIGHTED_TAB2 FROM INV_WEIGHTED_VIEW2 WHERE 1<0 AND CATEGORY IN ('RAS')"
    '        gconnection.ExcuteStoreProcedure(SQLS)

    '        sqlstring = "ALTER TABLE INV_WEIGHTED_TAB2 ADD ROWID INTEGER IDENTITY(1,1)"
    '        gconnection.ExcuteStoreProcedure(sqlstring)
    '        SQLS = " INSERT INTO INV_WEIGHTED_TAB2 (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY) "
    '        '*******CHECK THE WEIGHTED SETUP DATE OR DATETIME
    '        'If WET_SETUP = "DATEY" Then
    '        '    SQLS = SQLS & "SELECT DOCDETAILS,ITEMCODE, ITEMNAME, CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) AS DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY FROM INV_WEIGHTED_VIEW2 where itemcode in ("
    '        'ElseIf WET_SETUP = "DATEN" Then
    '        '    SQLS = SQLS & "SELECT DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE AS DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY FROM INV_WEIGHTED_VIEW2 where itemcode in ("
    '        'End If
    '        SQLS = SQLS & "SELECT DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE AS DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY FROM INV_WEIGHTED_VIEW2 where itemcode in ("

    '        '****** select the itemcode from the grid ************
    '        For z = 1 To ssgrid.DataRowCnt
    '            ssgrid.Col = 1
    '            ssgrid.Row = z
    '            itemc = ssgrid.Text
    '            SQLS = SQLS & "'" & itemc & "',"
    '        Next
    '        SQLS = Mid(SQLS, 1, Len(SQLS) - 1)
    '        SQLS = SQLS & " ) AND ITEMCODE NOT IN (SELECT ITEMCODE FROM INVENTORYITEMMASTER WHERE ISNULL(GOVTRATION,'')='Y') ORDER BY  ITEMCODE,"
    '        'If WET_SETUP = "DATEY" Then
    '        '    SQLS = SQLS & " CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME), PRIORITY"
    '        'ElseIf WET_SETUP = "DATEN" Then
    '        '    SQLS = SQLS & " DOCDATE, PRIORITY"
    '        'End If
    '        SQLS = SQLS & " DOCDATE, PRIORITY"

    '        gconnection.ExcuteStoreProcedure(SQLS)

    '        SQLS = "ALTER TABLE INV_WEIGHTED_TAB2 ADD WEIGHTED_RATE NUMERIC(18,2)"
    '        gconnection.ExcuteStoreProcedure(SQLS)

    '        SQLS = "UPDATE INV_WEIGHTED_TAB2 SET WEIGHTED_RATE =0"
    '        gconnection.ExcuteStoreProcedure(SQLS)

    '        SQLS = " UPDATE INV_WEIGHTED_TAB2 SET CLSSTOCK=(SELECT SUM(QTY) FROM INV_WEIGHTED_TAB2 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB2.ITEMCODE AND A.ROWID<=INV_WEIGHTED_TAB2.ROWID )"
    '        gconnection.ExcuteStoreProcedure(SQLS)
    '        SQLS = " UPDATE INV_WEIGHTED_TAB2 SET LASTSTOCK=(SELECT ISNULL(SUM(QTY),0) FROM INV_WEIGHTED_TAB2 A WHERE A.ITEMCODE=INV_WEIGHTED_TAB2.ITEMCODE AND A.ROWID<INV_WEIGHTED_TAB2.ROWID )"
    '        gconnection.ExcuteStoreProcedure(SQLS)

    '        SQLS = " UPDATE INV_WEIGHTED_TAB2 SET LASTRATE=(SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM INV_WEIGHTED_TAB2 A "
    '        SQLS = SQLS & " WHERE  A.ITEMCODE=INV_WEIGHTED_TAB2.ITEMCODE AND A.ROWID<INV_WEIGHTED_TAB2.ROWID AND A.TYPE IN ('OPENING','GRN') ORDER BY A.ROWID DESC) "
    '        SQLS = SQLS & " WHERE TYPE IN ('OPENING','GRN')"
    '        gconnection.ExcuteStoreProcedure(SQLS)
    '        SQLS = " UPDATE  INV_WEIGHTED_TAB2 SET LASTRATE=RATE WHERE TYPE IN ('OPENING','GRN') AND ISNULL(LASTRATE,0)=0"
    '        gconnection.ExcuteStoreProcedure(SQLS)

    '        SQLS = " UPDATE INV_WEIGHTED_TAB2 SET WEIGHTED_RATE = RATE WHERE TYPE='OPENING'"
    '        gconnection.ExcuteStoreProcedure(SQLS)

    '        sqlstring = "SELECT * FROM INV_WEIGHTED_TAB2 WHERE STORECODE='MNS' ORDER BY ROWID"
    '        Dim SqlConnection As New SqlConnection
    '        SqlConnection.ConnectionString = gconnection.Getconnection()
    '        SqlConnection.Open()
    '        Dim DS As New DataSet
    '        Dim DA As New SqlDataAdapter(sqlstring, SqlConnection)
    '        '  DA.Fill(DS)
    '        Dim DT As New DataTable
    '        DA.Fill(DT)
    '        DT.TableName = "INV_WEIGHTED_TAB2"
    '        If DS.Tables.Contains("INV_WEIGHTED_TAB2") = True Then
    '            DS.Tables.Remove("INV_WEIGHTED_TAB2")
    '        End If
    '        DS.Tables.Add(DT)

    '        SqlConnection.Close()

    '        'gconnection.getDataSet(sqlstring, "INV_WEIGHTED_TAB2")
    '        If DS.Tables("INV_WEIGHTED_TAB2").Rows.Count > 0 Then
    '            Dim ITEMCODE As String
    '            Dim RATE As Double
    '            Dim QTY As Double
    '            ITEMCODE = DS.Tables("INV_WEIGHTED_TAB2").Rows(0).Item("ITEMCODE")
    '            For i = 0 To DS.Tables("INV_WEIGHTED_TAB2").Rows.Count - 1
    '                'If ITEMCODE = "LPDR105" Then
    '                '    MessageBox.Show("LPDR105")
    '                'End If
    '                If ITEMCODE <> DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE") Then
    '                    QTY = 0
    '                    RATE = 0
    '                    ITEMCODE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("ITEMCODE")

    '                    QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
    '                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
    '                        RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

    '                    ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Then
    '                        If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
    '                            RATE = ((DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
    '                            DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
    '                        Else
    '                            RATE = 0
    '                        End If
    '                    Else
    '                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

    '                    End If
    '                Else
    '                    QTY = QTY + DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY")
    '                    If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
    '                        RATE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE")

    '                    ElseIf DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("TYPE") = "GRN" Then
    '                        If DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
    '                            RATE = ((DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("CLSSTOCK"))
    '                            DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
    '                        Else
    '                            RATE = 0
    '                        End If
    '                    Else
    '                        DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

    '                    End If
    '                End If
    '                'If i < DS.Tables("INV_WEIGHTED_TAB2").Rows.Count - 1 Then
    '                '    ITEMCODE = DS.Tables("INV_WEIGHTED_TAB2").Rows(i + 1).Item("ITEMCODE")
    '                'End If

    '            Next

    '        End If

    '        SQLS = "DROP TABLE INV_WEIGHTED_TAB3 "
    '        gconnection.ExcuteStoreProcedure(SQLS)

    '        SQLS = "CREATE TABLE INV_WEIGHTED_TAB3 (ROWID INTEGER, WEIGHTED_RATE NUMERIC(18,2) )"
    '        gconnection.ExcuteStoreProcedure(SQLS)

    '        'SQLS = "ALTER TABLE INV_WEIGHTED_TAB3 ALTER COLUMN ROWID INTEGER"
    '        'gconnection.ExcuteStoreProcedure(SQLS)
    '        'SQLS = "ALTER TABLE INV_WEIGHTED_TAB3 ADD ROWID INTEGER"
    '        'gconnection.ExcuteStoreProcedure(SQLS)
    '        Dim SQLS1 As String
    '        Dim J As Integer
    '        SQLS = ""
    '        For i = 0 To DS.Tables("INV_WEIGHTED_TAB2").Rows.Count - 1
    '            SQLS = SQLS & "INSERT INTO INV_WEIGHTED_TAB3 (ROWID, WEIGHTED_RATE) VALUES ( "

    '            For J = 0 To DS.Tables("INV_WEIGHTED_TAB2").Columns.Count - 1
    '                If ((UCase(DS.Tables("INV_WEIGHTED_TAB2").Columns(J).ColumnName) = "ROWID") Or (UCase(DS.Tables("INV_WEIGHTED_TAB2").Columns(J).ColumnName) = "WEIGHTED_RATE")) Then
    '                    SQLS = SQLS & "'" & DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item(J) & "',"
    '                End If
    '                'SQLS = SQLS & "'" & DS.Tables("INV_WEIGHTED_TAB2").Rows(i).Item(J) & "',"
    '            Next
    '            SQLS = Mid(SQLS, 1, Len(SQLS) - 2)
    '            SQLS = SQLS & " ')"

    '        Next
    '        If SQLS <> "" Then
    '            gconnection.ExcuteStoreProcedure(SQLS)
    '        End If

    '        SQLS = "UPDATE INV_WEIGHTED_TAB2 SET WEIGHTED_RATE=A.WEIGHTED_RATE  FROM  INV_WEIGHTED_TAB3 A WHERE A.ROWID=INV_WEIGHTED_TAB2.ROWID"
    '        gconnection.ExcuteStoreProcedure(SQLS)

    '        '*********UPDATION IN THE FINAL TABLE FOR THE REPORT ***********************
    '        SQLS = "DELETE FROM INV_WEIGHTED_FINAL_TAB  where itemcode in ("
    '        '****** select the itemcode from the grid ************
    '        itemc = ""
    '        For z = 1 To ssgrid.DataRowCnt
    '            ssgrid.Col = 1
    '            ssgrid.Row = z
    '            itemc = ssgrid.Text
    '            SQLS = SQLS & "'" & itemc & "',"
    '        Next
    '        SQLS = Mid(SQLS, 1, Len(SQLS) - 1)
    '        SQLS = SQLS & " )"
    '        gconnection.ExcuteStoreProcedure(SQLS)
    '        SQLS = "INSERT INTO INV_WEIGHTED_FINAL_TAB (DOCDETAILS,ITEMCODE,ITEMNAME,DOCDATE,QTY,RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,"
    '        SQLS = SQLS & " LASTSTOCK,LASTRATE,WEIGHTED_RATE)  "
    '        SQLS = SQLS & " SELECT DOCDETAILS,ITEMCODE,ITEMNAME,DOCDATE,QTY,RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,"
    '        SQLS = SQLS & " LASTSTOCK,LASTRATE,WEIGHTED_RATE FROM INV_WEIGHTED_TAB2"
    '        gconnection.ExcuteStoreProcedure(SQLS)


    '    Catch ex As Exception
    '        MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '        Exit Function
    '    End Try
    'End Function
End Class