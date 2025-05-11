Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class ConsolidatedSTBReports
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim I As Integer

    Private Sub ConsolidatedSTBReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Resize_Form()
        Me.DoubleBuffered = True
        grp_SalebillChecklist.Top = 1000
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
        sqlstring = "SELECT DISTINCT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER ORDER BY ITEMCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                    Chklist_Itemdetails.Items.Add(Trim(CStr(.Item("ITEMCODE"))) & "-->" & Trim(CStr(.Item("ITEMNAME"))))
                End With
            Next
        End If
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Chklist_Itemdetails.Items.Clear()
    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Dim vsqlstring, vsqlstring1 As String

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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 1
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"



        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_SalebillChecklist.Top = 1000
            Call View_Alter()
            Call ConsStockSummary()

        End If
    End Sub

    Public Sub OPENING_VIEW_ALTER()
        Try

            Dim SLSTRING, STORECODE As String
            Dim DATE1 As Date
            DATE1 = Format(CDate("26/03/" & gFinancalyearStart), "dd/MMM/yyyy")
            I = 0
            sqlstring = " ALTER VIEW VIEW_CONSSTB_OPENING "
            sqlstring = sqlstring & " AS "

            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY) AS OPQTY, SUM(AMOUNT) AS OPVALUE FROM GRN_DETAILS WHERE CAST(CONVERT(VARCHAR(11),GRNDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Voiditem,'')<>'Y' GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY) * -1 AS OPQTY, SUM(AMOUNT) * -1 AS OPVALUE FROM STOCKDMGDETAIL WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(QTY) * -1 AS OPQTY, SUM(AMOUNT) * -1 AS OPVALUE FROM SUBSTORECONSUMPTIONDETAIL WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(Adjustedstock) AS OPQTY, SUM(AMOUNT) AS OPVALUE FROM STOCKADJUSTDETAILS WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DATE1, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1,'" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(Void,'')<>'Y'  GROUP BY ITEMCODE, ITEMNAME"
            sqlstring = sqlstring & " UNION ALL "
            sqlstring = sqlstring & "SELECT ITEMCODE, ITEMNAME, SUM(opstock)  AS OPQTY, SUM(opvalue) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' GROUP BY ITEMCODE, ITEMNAME"
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

            sqlstring = "delete from TEMP_CONSOLIDATED_STB"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "INSERT INTO TEMP_CONSOLIDATED_STB (ITEMCODE,OPQTY)(select itemcode, sum(opqty) as opqty from VIEW_CONSSTB_OPENING group by ITEMCODE)"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "INSERT INTO TEMP_CONSOLIDATED_STB (ITEMCODE,RCVQTY,RCVRATE,RCVVALUE)select itemcode,SUM(qty) as rcvqty, rate, SUM(amount) as  rcvvalue from INV_BAR_FINAL_TAB_DETAILED  where CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and TYPE = 'grn' group by ITEMCODE, RATE order by ITEMCODE"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "INSERT INTO TEMP_CONSOLIDATED_STB (ITEMCODE,qtyforraterev,VALUEOFRATEREVISION)select itemcode,clsstock,((LASTSTOCK * WEIGHTED_RATE)-(laststock * LASTRATE))as raterev_Value from INV_BAR_FINAL_TAB_DETAILED  where CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and TYPE = 'grn' and weighted_Rate<>LASTRATE"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "insert into TEMP_CONSOLIDATED_STB(ITEMCODE,ISSUEQTY,ISSUEVALUE,issuerate)select itemcode,SUM(qty) as issueqty, SUM(amount) as issueval,rate from INV_BAR_FINAL_TAB_DETAILED  where CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and TYPE in ('CONSUMPTION','EXPEND') group by ITEMCODE, RATE"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "insert into TEMP_CONSOLIDATED_STB(ITEMCODE, LOSSDAMAGEQTY,LOSSDAMAGERATE)select itemcode,SUM(qty) as damageqty, SUM(amount) as damageval from INV_BAR_FINAL_TAB_DETAILED  where CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and TYPE in ('DAMAGE') group by ITEMCODE"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "insert into TEMP_CONSOLIDATED_STB(ITEMCODE,TOTALSTOCKQTY)select itemcode,SUM(qty) as totalstockqty from INV_BAR_FINAL_TAB_DETAILED  where CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and TYPE in ('grn','opening') group by ITEMCODE"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "insert into TEMP_CONSOLIDATED_STB(ITEMCODE,BALQTY)select itemcode,SUM(qty) as balqty from INV_BAR_FINAL_TAB_DETAILED  where CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and TYPE in ('grn','opening','CONSUMPTION','EXPEND') group by ITEMCODE"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "insert into TEMP_CONSOLIDATED_STB(ITEMCODE,clsqty)select itemcode,SUM(qty) as clsqty from INV_BAR_FINAL_TAB_DETAILED  where CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) between  '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and TYPE in ('grn','opening','CONSUMPTION','EXPEND','Damage') group by ITEMCODE"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "drop table   STKOPNRATE "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "drop table stkpurchaserate2 "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "SELECT * INTO stkpurchaserate2 FROM OPENING_RATE WHERE Grndate<='" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "'  ORDER BY Grndate DESC    "
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

            sqlstring = "update TEMP_CONSOLIDATED_STB set CLSRATE=(SELECT TOP 1 rate from stkpurchaserate2 b where b.itemcode=TEMP_CONSOLIDATED_STB.itemcode   "
            sqlstring = sqlstring & " and b.type='GRN')    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "update TEMP_CONSOLIDATED_STB  set CLSRATE= (SELECT TOP 1 rate from stkpurchaserate2 b where b.itemcode=TEMP_CONSOLIDATED_STB.itemcode  "
            sqlstring = sqlstring & " and b.type='opening') WHERE Itemcode not in (SELECT ITEMCODE from stkpurchaserate2 where TYPE='grn' )   "
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
            sqlstring = "update TEMP_CONSOLIDATED_STB set CLSVALUE=(CLSRATE * CLSQTY)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            'ITEMCODE = ""
            SLSTRING = ""
            For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                ITEMCODE = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                SLSTRING = SLSTRING & "'" & ITEMCODE(0) & "', "
            Next
            SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)

            sqlstring = "SELECT * FROM view_consolidated WHERE ITEMCODE IN (" & SLSTRING & ") ORDER BY ITEMCODE"
            gconnection.getDataSet(sqlstring, "view_consolidated")
            If gdataset.Tables("view_consolidated").Rows.Count > 0 Then
                If CHK_EXCEL.Checked = True Then
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "CONSOLIDATED SUMMARY " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")
                Else
                    Dim RVIEWER As New Viewer
                    Dim CONSOREPORT As New Crys_consolidatedreportNEW
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


    Private Sub View_Alter()
        Try

            sqlstring = "SELECT * FROM SYSOBJECTS WHERE name='View_Cons_Opening' AND XTYPE='V'"
            gconnection.getDataSet(sqlstring, "View_Cons_Opening")
            If gdataset.Tables("View_Cons_Opening").Rows.Count > 0 Then
                sqlstring = "ALTER VIEW View_Cons_Opening "
                sqlstring = sqlstring & " AS "
                sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS OPSTOCK,SUM(ISNULL(OPVALUE,0)) AS OPVALUE,'OPENING' AS TYPE  FROM INVENTORYITEMMASTER"
                sqlstring = sqlstring & " WHERE ISNULL(Freeze,'')<>'Y' GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, (SUM(QTY) + sum(isnull(freeqty,0)))  AS QTY, (SUM(AMOUNT) - sum(isnull(discount,0))) AS AMOUNT,'OPENING' AS TYPE FROM GRN_DETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE FROM GRN_DETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(ADJUSTEDSTOCK,0)) AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT,'ISSUE' AS TYPE FROM STOCKADJUSTDETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "') and ADJUSTEDSTOCK<=0 GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(ADJUSTEDSTOCK,0))  AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT,'ISSUE' AS TYPE FROM STOCKADJUSTDETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "') and ADJUSTEDSTOCK>0 GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE FROM STOCKDMGDETAIL"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "') GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE FROM SUBSTORECONSUMPTIONDETAIL"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "') GROUP BY itemcode, itemname"
                gconnection.ExcuteStoreProcedure(sqlstring)
            Else
                sqlstring = "CREATE VIEW View_Cons_Opening "
                sqlstring = sqlstring & " AS "
                sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS OPSTOCK,SUM(ISNULL(OPVALUE,0)) AS OPVALUE,'OPENING' AS TYPE  FROM INVENTORYITEMMASTER"
                sqlstring = sqlstring & " WHERE ISNULL(Freeze,'')<>'Y' GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, (SUM(QTY) + sum(isnull(freeqty,0)))  AS QTY, (SUM(AMOUNT) - sum(isnull(discount,0))) AS AMOUNT,'OPENING' AS TYPE FROM GRN_DETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE FROM GRN_DETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(ADJUSTEDSTOCK,0)) AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT,'ISSUE' AS TYPE FROM STOCKADJUSTDETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') and ADJUSTEDSTOCK<=0 GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(ADJUSTEDSTOCK,0))  AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT,'ISSUE' AS TYPE FROM STOCKADJUSTDETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') and ADJUSTEDSTOCK>0 GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE FROM STOCKDMGDETAIL"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE FROM SUBSTORECONSUMPTIONDETAIL"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(gstartingdateNew, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "') GROUP BY itemcode, itemname"
                gconnection.ExcuteStoreProcedure(sqlstring)
            End If

            sqlstring = "SELECT * FROM SYSOBJECTS WHERE name='View_Cons_Issue' AND XTYPE='V'"
            gconnection.getDataSet(sqlstring, "View_Cons_Issue")
            If gdataset.Tables("View_Cons_Issue").Rows.Count > 0 Then

                sqlstring = "ALTER VIEW View_Cons_Issue "
                sqlstring = sqlstring & " as "
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(ADJUSTEDSTOCK,0)) * -1 AS QTY, SUM(ISNULL(Amount,0)) * -1 AS AMOUNT,'ISSUE' AS TYPE FROM STOCKADJUSTDETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_Todate.Value, "dd/MMM/yyyy") & "' and ADJUSTEDSTOCK<=0 GROUP BY itemcode, itemname"
                'sqlstring = sqlstring & " UNION ALL"
                'sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(ADJUSTEDSTOCK,0))  AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT,'ISSUE' AS TYPE FROM STOCKADJUSTDETAILS"
                'sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_Todate.Value, "dd/MMM/yyyy") & "' and ADJUSTEDSTOCK>0 and Amount>0 GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'ISSUE' AS TYPE  FROM STOCKDMGDETAIL"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_Todate.Value, "dd/MMM/yyyy") & "' GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'ISSUE' AS TYPE  FROM SUBSTORECONSUMPTIONDETAIL"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_Todate.Value, "dd/MMM/yyyy") & "' GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'ISSUE' AS TYPE FROM GRN_DETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) BETWEEN '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_Todate.Value, "dd/MMM/yyyy") & "' AND ISNULL(grntype,'')='PRN' GROUP BY itemcode, itemname"
                gconnection.ExcuteStoreProcedure(sqlstring)
            Else
                sqlstring = "CREATE VIEW View_Cons_Issue "
                sqlstring = sqlstring & " as "
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(ADJUSTEDSTOCK,0)) * -1 AS QTY, SUM(ISNULL(Amount,0)) * -1 AS AMOUNT,'ISSUE' AS TYPE FROM STOCKADJUSTDETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and ADJUSTEDSTOCK<=0 GROUP BY itemcode, itemname"
                'sqlstring = sqlstring & " UNION ALL"
                'sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(ADJUSTEDSTOCK,0))  AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT,'ISSUE' AS TYPE FROM STOCKADJUSTDETAILS"
                'sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_Todate.Value, "dd/MMM/yyyy") & "' and ADJUSTEDSTOCK>0 and Amount>0 GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'ISSUE' AS TYPE  FROM STOCKDMGDETAIL"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'ISSUE' AS TYPE  FROM SUBSTORECONSUMPTIONDETAIL"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'ISSUE' AS TYPE FROM GRN_DETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' AND ISNULL(grntype,'')='PRN' GROUP BY itemcode, itemname"
                gconnection.ExcuteStoreProcedure(sqlstring)
            End If


            sqlstring = "SELECT * FROM SYSOBJECTS WHERE name='View_Cons_Receive' AND XTYPE='V'"
            gconnection.getDataSet(sqlstring, "View_Cons_Receive")
            If gdataset.Tables("View_Cons_Receive").Rows.Count > 0 Then
                sqlstring = "ALTER VIEW View_Cons_Receive "
                sqlstring = sqlstring & " as "
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(ADJUSTEDSTOCK,0)) AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT,'RECEIVE' AS TYPE  FROM STOCKADJUSTDETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_Todate.Value, "dd/MMM/yyyy") & "' and isnull(AdjustedStock,0)>0 GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, (SUM(QTY) + sum(isnull(freeqty,0))) as QTY, (SUM(AMOUNT) - sum(isnull(discount,0))) as amount, 'RECEIVE' FROM GRN_DETAILS WHERE CAST(CONVERT(VARCHAR(11),GRNDATE,106) AS DATETIME) "
                sqlstring = sqlstring & " BETWEEN '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_Todate.Value, "dd/MMM/yyyy") & "' AND ISNULL(VOIDITEM,'')<>'Y' AND ISNULL(GRNDETAILS,'') IN (SELECT ISNULL(GRNDETAILS,'') FROM GRN_HEADER WHERE GRNTYPE='GRN') GROUP BY ITEMCODE, ITEMNAME"

                gconnection.ExcuteStoreProcedure(sqlstring)
            Else
                sqlstring = "CREATE VIEW View_Cons_Receive "
                sqlstring = sqlstring & " as "
                sqlstring = sqlstring & " SELECT Itemcode, Itemname, SUM(ISNULL(ADJUSTEDSTOCK,0)) AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT,'RECEIVE' AS TYPE  FROM STOCKADJUSTDETAILS"
                sqlstring = sqlstring & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and isnull(AdjustedStock,0)>0 GROUP BY itemcode, itemname"
                sqlstring = sqlstring & " UNION ALL"
                sqlstring = sqlstring & " SELECT ITEMCODE, ITEMNAME, (SUM(QTY) + sum(isnull(freeqty,0))) as QTY, (SUM(AMOUNT) - sum(isnull(discount,0))) as amount, 'RECEIVE' FROM GRN_DETAILS WHERE CAST(CONVERT(VARCHAR(11),GRNDATE,106) AS DATETIME) "
                sqlstring = sqlstring & " BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' AND ISNULL(VOIDITEM,'')<>'Y' AND ISNULL(GRNDETAILS,'') IN (SELECT ISNULL(GRNDETAILS,'') FROM GRN_HEADER WHERE GRNTYPE='GRN') GROUP BY ITEMCODE, ITEMNAME"

                gconnection.ExcuteStoreProcedure(sqlstring)
            End If
        Catch ex As Exception
            MessageBox.Show("Please Check Error" + ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ConsStockSummary()
        Try
            Dim SLSTRING, ItemCode() As String
            Dim i As Integer
            sqlstring = "DELETE FROM TempConsolidatedStockSummary"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "DELETE FROM ConsolidatedStockSummary"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "INSERT INTO TempConsolidatedStockSummary(ITEMCODE, ITEMNAME, OPSTOCK,OPVALUE,TYPE)"
            sqlstring = sqlstring & " (SELECT ITEMCODE, ITEMNAME, OPSTOCK, OPVALUE, TYPE FROM View_Cons_Opening)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "INSERT INTO TempConsolidatedStockSummary(ITEMCODE, ITEMNAME, RCVSTOCK,RCVVALUE,TYPE)"
            'sqlstring = sqlstring & " (SELECT ITEMCODE, ITEMNAME, (SUM(QTY) + sum(isnull(freeqty,0))) as QTY, (SUM(AMOUNT) - sum(isnull(discount,0))) as amount, 'RECEIVE' FROM GRN_DETAILS WHERE CAST(CONVERT(VARCHAR(11),GRNDATE,106) AS DATETIME) "
            'sqlstring = sqlstring & " BETWEEN '" & Format(dtp_Fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_Todate.Value, "dd/MMM/yyyy") & "' AND ISNULL(VOIDITEM,'')<>'Y' AND ISNULL(GRNDETAILS,'') IN (SELECT ISNULL(GRNDETAILS,'') FROM GRN_HEADER WHERE GRNTYPE='GRN') GROUP BY ITEMCODE, ITEMNAME)"
            sqlstring = "INSERT INTO TempConsolidatedStockSummary(ITEMCODE, ITEMNAME, RCVSTOCK,RCVVALUE,TYPE)"
            sqlstring = sqlstring & " (SELECT ITEMCODE, ITEMNAME, QTY, AMOUNT, TYPE FROM View_Cons_Receive)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "INSERT INTO TempConsolidatedStockSummary(ITEMCODE, ITEMNAME, ISSUESTOCK, ISSUEVALUE,TYPE)"
            sqlstring = sqlstring & "(SELECT ITEMCODE, ITEMNAME, QTY, AMOUNT, TYPE FROM View_Cons_Issue)"
            gconnection.ExcuteStoreProcedure(sqlstring)

            'sqlstring = "INSERT INTO ConsolidatedStockSummary(ITEMCODE, OPSTOCK, OPVALUE,RCVSTOCK, RCVVALUE,ISSUESTOCK,ISSUEVALUE) "
            'sqlstring = sqlstring & "(SELECT ITEMCODE,  SUM(OPSTOCK), SUM(OPVALUE), SUM(RCVSTOCK), SUM(RCVVALUE), SUM(ISSUESTOCK), SUM(ISSUEVALUE) FROM TempConsolidatedStockSummary GROUP BY ITEMCODE, ITEMNAME)"
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "UPDATE ConsolidatedStockSummary SET CLSSTOCK=(isnull(OPSTOCK,0)+ isnull(RCVSTOCK,0))-isnull(ISSUESTOCK,0)"
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "UPDATE ConsolidatedStockSummary SET CLSVALUE=(OPVALUE+RCVVALUE)-ISSUEVALUE"
            'gconnection.ExcuteStoreProcedure(sqlstring)

            'sqlstring = "SELECT ISNULL(c.ITEMCODE,'') AS ITEMCODE, ISNULL(i.ITEMNAME,'') AS ITEMNAME, ISNULL(c.OPSTOCK,0) AS OPSTOCK, ISNULL(c.OPVALUE,0) AS OPVALUE,"
            'sqlstring = sqlstring & " ISNULL(c.RCVSTOCK,0) AS RCVSTOCK, ISNULL(c.RCVVALUE,0) AS RCVVALUE, ISNULL(c.ISSUESTOCK,0) AS ISSUESTOCK, ISNULL(c.ISSUEVALUE,0) AS ISSUEVALUE,"
            'sqlstring = sqlstring & " ISNULL(c.CLSSTOCK,0) AS CLSSTOCK, ISNULL(c.CLSVALUE,0) AS CLSVALUE FROM ConsolidatedStockSummary c, inventoryitemmaster i "
            'If CHK_ZEROQTY.Checked = True Then
            '    sqlstring = sqlstring & " WHERE c.itemcode=i.itemcode and i.storecode='MNS' and "
            'Else
            '    sqlstring = sqlstring & " WHERE c.itemcode=i.itemcode and i.storecode='MNS' and  ISNULL(c.OPSTOCK,0)<>0 or ISNULL(c.RCVSTOCK,0)<>0 or ISNULL(ISSUESTOCK,0)<>0 or ISNULL(c.CLSSTOCK,0)<>0 AND "
            'End If
            'If TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
            '    sqlstring = sqlstring & " c.ITEMCODE BETWEEN '" & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "'"
            'Else
            '    SLSTRING = ""
            '    For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
            '        ItemCode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
            '        SLSTRING = SLSTRING & "'" & ItemCode(0) & "', "
            '    Next
            '    SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)
            '    sqlstring = sqlstring & " c.ITEMCODE IN (" & SLSTRING & ")"
            'End If
            ''sqlstring = sqlstring & " group by c.itemcode,i.itemname"

            sqlstring = "INSERT INTO ConsolidatedStockSummary(ITEMCODE, OPSTOCK, OPVALUE,RCVSTOCK, RCVVALUE,ISSUESTOCK,ISSUEVALUE) "
            sqlstring = sqlstring & "(SELECT ITEMCODE, SUM(OPSTOCK), SUM(OPVALUE), SUM(RCVSTOCK), SUM(RCVVALUE), SUM(ISSUESTOCK), SUM(ISSUEVALUE) FROM TempConsolidatedStockSummary GROUP BY ITEMCODE)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET CLSSTOCK=(isnull(OPSTOCK,0)+ isnull(RCVSTOCK,0))-isnull(ISSUESTOCK,0)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET CLSVALUE=(ISNULL(OPVALUE,0)+ISNULL(RCVVALUE,0))-ISNULL(ISSUEVALUE,0)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET ItemName=(select distinct itemname from inventoryitemmaster B where B.ITEMCODE=ConsolidatedStockSummary.ITEMCODE AND b.storecode in ('MNS','MNS1','MNS2'))"
            gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "UPDATE ConsolidatedStockSummary SET ItemName=(select distinct itemname from inventoryitemmaster B where B.ITEMCODE=ConsolidatedStockSummary.ITEMCODE AND b.storecode in ('MNS1') and b.itemcode not in (select distinct itemcode from inventoryitemmaster where storecode in ('MNS','MNS2')))"
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "UPDATE ConsolidatedStockSummary SET ItemName=(select distinct itemname from inventoryitemmaster B where B.ITEMCODE=ConsolidatedStockSummary.ITEMCODE AND b.storecode in ('MNS2') and b.itemcode not in (select distinct itemcode from inventoryitemmaster where storecode in ('MNS','MNS1')))"
            'gconnection.ExcuteStoreProcedure(sqlstring)


            '********* update peg *******
            sqlstring = "UPDATE ConsolidatedStockSummary SET UOM=STOCKUOM FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=ConsolidatedStockSummary.ITEMCODE AND b.STORECODE in ('MNS','MNS1','MNS2')  "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET ConsolidatedStockSummary.uomdecimal=b.UOMDecimal FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=ConsolidatedStockSummary.ITEMCODE AND b.STORECODE in ('MNS','MNS1','MNS2') "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "update ConsolidatedStockSummary SET clsDISPQTY=0    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET clsDISPQTY=CLSstock-FLOOR(CLSstock) WHERE FLOOR(CLSstock)-CLSstock<0    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET clsDISPQTY=clsDISPQTY*(SELECT convvalue FROM INVENTORY_TRANSCONVERSION B WHERE B.BASEUOM=ConsolidatedStockSummary.Uom AND b.TRANSUOM=ConsolidatedStockSummary.uomdecimal)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "UPDATE ConsolidatedStockSummary SET clsDISPQTY=clsDISPQTY * 100"
            'gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET clsDISPQTY=FLOOR(CLSstock)+(clsdispqty/100)   WHERE (CLSstock-FLOOR(CLSstock))<>clsdispqty   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET clsDISPQTY=FLOOR(CLSstock)+(clsdispqty)   WHERE (CLSstock-FLOOR(CLSstock))=clsdispqty   "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "UPDATE ConsolidatedStockSummary SET clsDISPQTY=round(clsDISPQTY,0,1)  WHERE clsDISPQTY <0    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET clsDISPQTY=CLSstock  WHERE FLOOR(CLSstock)-CLSstock=0   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            '***************************
            '********* update peg issueqty *******
            sqlstring = "UPDATE ConsolidatedStockSummary SET UOM=STOCKUOM FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=ConsolidatedStockSummary.ITEMCODE AND b.STORECODE in ('MNS','MNS1','MNS2')  "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET ConsolidatedStockSummary.uomdecimal=b.UOMDecimal FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=ConsolidatedStockSummary.ITEMCODE AND b.STORECODE in ('MNS','MNS1','MNS2') "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "update ConsolidatedStockSummary SET issDISPQTY=0    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET issDISPQTY=issuestock-FLOOR(issuestock) WHERE FLOOR(issuestock)-issuestock <0    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET issDISPQTY=issDISPQTY*(SELECT convvalue FROM INVENTORY_TRANSCONVERSION B WHERE B.BASEUOM=ConsolidatedStockSummary.Uom AND b.TRANSUOM=ConsolidatedStockSummary.uomdecimal)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET issDISPQTY=FLOOR(issuestock)+(issDISPQTY/100)  where (issuestock -FLOOR(issuestock))<>issDISPQTY   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET issDISPQTY=FLOOR(issuestock)+(issDISPQTY)  where (issuestock -FLOOR(issuestock))=issDISPQTY   "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "UPDATE ConsolidatedStockSummary SET issDISPQTY=round(issDISPQTY,0,1)  WHERE issDISPQTY <0    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET issDISPQTY=issuestock  WHERE FLOOR(issuestock)-issuestock=0   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            '***************************
            '********* update peg Opqty *******
            sqlstring = "UPDATE ConsolidatedStockSummary SET UOM=STOCKUOM FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=ConsolidatedStockSummary.ITEMCODE AND b.STORECODE in ('MNS','MNS1','MNS2')  "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET ConsolidatedStockSummary.uomdecimal=b.UOMDecimal FROM INVENTORYITEMMASTER B WHERE B.ITEMCODE=ConsolidatedStockSummary.ITEMCODE AND b.STORECODE in ('MNS','MNS1','MNS2') "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "update ConsolidatedStockSummary SET OPDISPQTY=0    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET OPDISPQTY=OPstock-FLOOR(OPstock) WHERE FLOOR(OPstock)-OPstock <0    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET OPDISPQTY=OPDISPQTY*(SELECT convvalue FROM INVENTORY_TRANSCONVERSION B WHERE B.BASEUOM=ConsolidatedStockSummary.Uom AND b.TRANSUOM=ConsolidatedStockSummary.uomdecimal)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET OPDISPQTY=FLOOR(OPstock)+(OPDISPQTY/100)  where (OPstock -FLOOR(OPstock))<>OPDISPQTY   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET OPDISPQTY=FLOOR(OPstock)+(OPDISPQTY)  where (OPstock -FLOOR(OPstock))=OPDISPQTY   "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "UPDATE ConsolidatedStockSummary SET OPDISPQTY=round(OPDISPQTY,0,1)  WHERE OPDISPQTY <0    "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE ConsolidatedStockSummary SET OPDISPQTY=OPstock  WHERE FLOOR(OPstock)-OPstock=0   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            '***************************
            ''' Update amount when qty is 0 
            sqlstring = "update ConsolidatedStockSummary set OPVALUE=0 where ISNULL(OPSTOCK,0)=0"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "update ConsolidatedStockSummary set ISSUEVALUE=0 where ISNULL(ISSUESTOCK,0)=0"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "update ConsolidatedStockSummary set RCVVALUE=0 where ISNULL(RCVSTOCK,0)=0"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "update ConsolidatedStockSummary set CLSVALUE=0 where ISNULL(CLSSTOCK,0)=0"
            gconnection.ExcuteStoreProcedure(sqlstring)

            '******************

            sqlstring = "SELECT ISNULL(c.ITEMCODE,'') AS ITEMCODE, ISNULL(c.ITEMNAME,'') AS ITEMNAME, ISNULL(c.OPDISPQTY,0) AS OPSTOCK, ISNULL(c.OPVALUE,0) AS OPVALUE,"
            sqlstring = sqlstring & " ISNULL(c.RCVSTOCK,0) AS RCVSTOCK, ISNULL(c.RCVVALUE,0) AS RCVVALUE, ISNULL(c.issdispqty,0) AS ISSUESTOCK, ISNULL(c.ISSUEVALUE,0) AS ISSUEVALUE,"
            sqlstring = sqlstring & " ISNULL(c.clsdispqty,0) AS CLSSTOCK, ISNULL(c.CLSVALUE,0) AS CLSVALUE FROM ConsolidatedStockSummary c "
            If CHK_ZEROQTY.Checked = True Then
                sqlstring = sqlstring & " WHERE "
            Else
                sqlstring = sqlstring & " WHERE  (ISNULL(c.OPSTOCK,0)<>0 or ISNULL(c.RCVSTOCK,0)<>0 or ISNULL(ISSUESTOCK,0)<>0 or ISNULL(c.CLSSTOCK,0)<>0) AND "
            End If
            'If TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
            '    sqlstring = sqlstring & " c.ITEMCODE BETWEEN '" & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "'"
            'Else
            SLSTRING = ""
            For i = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                ItemCode = Split(Chklist_Itemdetails.CheckedItems(i), "-->")
                SLSTRING = SLSTRING & "'" & ItemCode(0) & "', "
            Next
            SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)
            sqlstring = sqlstring & " c.ITEMCODE IN (" & SLSTRING & ")"
            'End If
            sqlstring = sqlstring & " order by c.itemcode"

            gconnection.getDataSet(sqlstring, "ConsolidatedStockSummary")
            If gdataset.Tables("ConsolidatedStockSummary").Rows.Count > 0 Then
                If CHK_EXCEL.Checked = True Then
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "CONSOLIDATED STOCK SUMMARY " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")
                Else
                    Dim rViewer As New Viewer
                    Dim r As New Crys_ConsolidateStockSummaryNew
                    rViewer.ssql = sqlstring
                    rViewer.TableName = "ConsolidatedStockSummary"
                    rViewer.Report = r

                    Dim T1 As TextObject
                    T1 = r.ReportDefinition.ReportObjects("Text7")
                    T1.Text = gCompanyname

                    T1 = r.ReportDefinition.ReportObjects("Text8")
                    T1.Text = UCase(gCompanyAddress(0)) & ", " & UCase(gCompanyAddress(1))

                    T1 = r.ReportDefinition.ReportObjects("Text9")
                    T1.Text = "CONSOLIDATED STOCK SUMMARY REPORT"

                    T1 = r.ReportDefinition.ReportObjects("Text10")
                    T1.Text = "FROM " & Format(DTP_FROMDATE.Value, "dd/MM/yyyy") & " TO " & Format(DTP_TODATE.Value, "dd/MM/yyyy")

                    T1 = r.ReportDefinition.ReportObjects("Text13")
                    T1.Text = gUsername
                    rViewer.Show()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Please Check Error" + ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class