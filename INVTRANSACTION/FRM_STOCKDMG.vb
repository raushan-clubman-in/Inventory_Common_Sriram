Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FRM_STOCKDMG
    Dim gconnection As New GlobalClass
    Dim doctype1 As String
    Dim sqlstring As String
    Dim doctype As String
    Dim ddate As DateTime

    Private Sub FRM_STOCKDMG_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub

            ElseIf e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 And Cmd_View.Visible = True Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F10 And cmd_Print.Visible = True Then
                Call cmd_Print_Click(cmd_Print, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.Escape Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_COMMON_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FRM_STOCKDMG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.DoubleBuffered = True
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        Dim sqlstring As String = "Select getdate()"
        ddate = gconnection.getvalue(sqlstring)

        'Resize_Form()
        autogenerate()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If

        If gShortname = "RSAOI" Then
            Me.Cmdauth.Visible = True
            CHECKUSER()
        End If

        Dim thr As New System.Threading.Thread(Sub() Check())
        thr.Start()
    End Sub
    Sub CHECKUSER()
        If gUserCategory = "A" And ModuleAdmin = True Then
            If Mid(Cmd_Add.Text, 1, 1) = "U" And Autherize = "Y" Then
                Me.Cmd_Add.Enabled = True
            End If
        End If
        sqlstring = "SELECT * FROM MCARIGHTS WHERE  MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' "
        gconnection.getDataSet(sqlstring, "USERADMIN")
        If gdataset.Tables("USERADMIN").Rows.Count > 0 Then
            Dim USERNAME As String
            If UCase(gUsername) = UCase(gdataset.Tables("USERADMIN").Rows(0).Item("CHECKER1ID")) Then
                Cmdauth.Enabled = True
                Cmdauth.Text = "CHECKER PENDING [F5]"
            ElseIf UCase(gUsername) = UCase(gdataset.Tables("USERADMIN").Rows(0).Item("CHECKER2ID")) Then
                Cmdauth.Enabled = True
                Cmdauth.Text = "CHECKER PENDING [F5]"
            ElseIf UCase(gUsername) = UCase(gdataset.Tables("USERADMIN").Rows(0).Item("AUTHOR1ID")) Then
                Cmdauth.Enabled = True
                Cmdauth.Text = "AUTHORIZER PENDING [F5]"
            ElseIf UCase(gUsername) = UCase(gdataset.Tables("USERADMIN").Rows(0).Item("AUTHOR2ID")) Then
                Cmdauth.Enabled = True
                Cmdauth.Text = "AUTHORIZER PENDING [F5]"
            ElseIf UCase(gUsername) = UCase(gdataset.Tables("USERADMIN").Rows(0).Item("AUTHOR3ID")) Then
                Cmdauth.Enabled = True
                Cmdauth.Text = "AUTHORIZER PENDING [F5]"
            End If
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String

        GmoduleName = "Stock Damage"

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

    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 768
        K = 1024
        Me.ResizeRedraw = True
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
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

    Private Sub autogenerate()
        Dim Sqlstring, Financalyear, doctype As String
        If TXT_FROMSTORECODE.Text <> "" Then
            Try

                gcommand = New SqlCommand
                'doctype1 = "DMG"
                If Len(TXT_FROMSTORECODE.Text) < 3 Then
                    doctype = Mid(TXT_FROMSTORECODE.Text, 1, 2)
                Else
                    doctype = Mid(TXT_FROMSTORECODE.Text, 1, 3)
                End If

                Financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
                'Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) FROM STOCKDMGHEADER WHERE doctype='" & Trim(doctype1) & "'"
                If Len(TXT_FROMSTORECODE.Text) < 3 Then
                    Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) FROM STOCKDMGHEADER WHERE  SUBSTRING(docDETAILS,1,2)='" & Trim(doctype) & "'"
                Else
                    Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) FROM STOCKDMGHEADER WHERE  SUBSTRING(docDETAILS,1,3)='" & Trim(doctype) & "'"
                End If

                gconnection.openConnection()
                gcommand.CommandText = Sqlstring
                gcommand.CommandType = CommandType.Text
                gcommand.Connection = gconnection.Myconn
                gdreader = gcommand.ExecuteReader

                If gdreader.Read Then
                    If gdreader(0) Is System.DBNull.Value Then
                        txt_Docno.Text = doctype & "/000001/" & Financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    Else
                        txt_Docno.Text = doctype & "/" & Format(gdreader(0) + 1, "000000") & "/" & Financalyear
                        gdreader.Close()
                        gcommand.Dispose()
                        gconnection.closeConnection()
                    End If
                Else
                    txt_Docno.Text = doctype & "/000001/" & Financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If


            Catch ex As Exception
                Exit Sub
            Finally
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End Try
        Else
            txt_Docno.Text = ""
        End If
    End Sub


    Private Function check_Duplicate(ByVal Itemcode As String) As Boolean
        Dim i As Integer

        AxfpSpread1.Col = 1
        For i = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i
            If i <> AxfpSpread1.ActiveRow Then
                If Trim(AxfpSpread1.Text) = Trim(Itemcode) Then
                    MsgBox("Item Already exists", MsgBoxStyle.Critical, "Duplicate")
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub binditemcode()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim myValue As Object
        Dim UOM1 As String
        message = "Enter Batch No"
        title = "Batch No"



        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess, M.Category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "'"
        vform.Field = " I.itemcode, M.Itemname,uom"
        vform.vFormatstring = "     Itemcode    |                    Itemname                    |      UOM      |    batchprocess  "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then

            If (check_Duplicate(vform.keyfield) = False) Then
                AxfpSpread1.Col = 1
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)

                AxfpSpread1.Col = 2
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield1)
                AxfpSpread1.Col = 3
                Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                Next Z
                'Dim a As String=
                If Trim(vform.keyfield3) = "YES1" Then
                    AxfpSpread1.Col = 5
                    AxfpSpread1.ColHidden = False

                    '  gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), Trim(vform.keyfield2))
                    'Dim sql As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno,priority order by priority "
                    'Dim sql As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                    'sql = sql & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                    '
                    Dim SQL1 As String = "with a as ( "
                    SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE cast(convert(varchar(11),trndate,106)as datetime)<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                    SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                    SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,closingqty.uom as uom from a inner  join closingqty on "
                    SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                    SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                    'SQL1 = SQL1 & " "
                    SQL1 = SQL1 & " and   a.storecode=closingqty.storecode  "
                    SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(vform.keyfield) + "'"
                    SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND cast(convert(varchar(11),A.trndate,106)as datetime)<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate desc,AUTOID desc "


                    gconnection.getDataSet(SQL1, "closingtable")

                    If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                        GroupBox3.Visible = True

                        AxfpSpread2.ClearRange(1, 1, -1, -1, True)
                        For i As Integer = 0 To gdataset.Tables("closingtable").Rows.Count - 1
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 1
                            AxfpSpread2.SetText(1, i + 1, Trim(vform.keyfield))


                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 2
                            AxfpSpread2.SetText(2, i + 1, gdataset.Tables("closingtable").Rows(i).Item("batchno"))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 3
                            AxfpSpread2.SetText(3, i + 1, Val(gdataset.Tables("closingtable").Rows(i).Item("quantity")))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 4
                            AxfpSpread2.SetText(4, i + 1, gdataset.Tables("closingtable").Rows(i).Item("uom"))




                        Next

                        AxfpSpread2.SetActiveCell(5, 1)
                        AxfpSpread2.Focus()
                    Else
                        GroupBox3.Visible = False

                        AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                    End If

                Else
                    Dim convvalue As Double

                    'sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                    'gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                    'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                    '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                    '    Dim sql1 As String
                    '    'If rateflag = "W" Then
                    '    '    sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                    '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                    '    'Else
                    '    '    sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "'"
                    '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                    '    'End If
                    '    If rateflag = "W" Then

                    '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + vform.keyfield + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                    '    Else
                    '        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + vform.keyfield + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
                    '    End If
                    '    gconnection.getDataSet(sql1, "ratelist")
                    '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                    '        Dim pr As Double

                    '        AxfpSpread1.Col = 3
                    '        sql1 = "select isnull(convvalue,0) as convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                    '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                    '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                    '        Else
                    '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                    '            Exit Sub
                    '        End If
                    '        AxfpSpread1.Col = 7
                    '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue))
                    '    Else
                    '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + vform.keyfield + "' AND  openningqty<>0 "
                    '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                    '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                    '            Dim pr As Double

                    '            AxfpSpread1.Col = 3
                    '            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                    '            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                    '            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    '                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    '                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                    '            Else
                    '                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                    '                Exit Sub
                    '            End If
                    '            AxfpSpread1.Col = 7
                    '            AxfpSpread1.Row = AxfpSpread1.ActiveRow


                    '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)


                    '        Else
                    '            AxfpSpread1.Col = 7
                    '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '            AxfpSpread1.Text = 0

                    '        End If
                    '    End If



                    'End If

                    AxfpSpread1.Col = 5
                    AxfpSpread1.ColHidden = True
                    Dim sql11 As String
                    ' Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom from closingqty where itemcode='" + vform.keyfield + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and CONVERT(VARCHAR(11), Trndate, 106)<='" + Format(CDate(dtp_Docdate.Value), "dd MMM yyyy") + "' order by trns_seq desc,AUTOID desc"


                    'gconnection.getDataSet(sql11, "closingtable")
                    gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), vform.keyfield, Trim(TXT_FROMSTORECODE.Text), "")
                    Dim closingqty, rate As Double
                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                        rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                    Else
                        closingqty = 0
                        rate = 0
                    End If
                    UOM1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                    sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + UOM1 + "' and transuom='" + vform.keyfield2 + "'"
                    gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                    Else
                        convvalue = 0
                    End If
                    closingqty = Format(closingqty * convvalue, "0.000")
                    AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, closingqty)
                    AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, rate / convvalue)

                    'If GBATCHNO = "Y" Then
                    '    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                    'Else
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    '  End If

                End If
            End If


        End If
    End Sub
    Private Sub binditemname()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue As String
        Dim myValue As Object
        Dim uom1 As String
        gSQLString = "select I.itemcode,M.Itemname,uom,batchprocess,M.category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
        gSQLString = gSQLString & " I.itemcode=M.itemcode "
        M_WhereCondition = " where M.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "'"
        vform.Field = " I.itemcode, m.Itemname,I.Uom,batchprocess"
        vform.vFormatstring = "    Itemcode    |              Itemname                 |       UOM     "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        'vform.KeyPos1 = 3
        'vform.KeyPos1 = 4
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_Duplicate(vform.keyfield) = False) Then
                AxfpSpread1.Col = 1
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.Col = 2
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield1)
                AxfpSpread1.Col = 3
                Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + vform.keyfield + "'"

                gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                    AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                    AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                Next Z
                If Trim(vform.keyfield3) = "YES1" Then

                    '      gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), Trim(vform.keyfield2))
                    '  Dim sql As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                    'Dim sql As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                    'sql = sql & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                    Dim SQL1 As String = "with a as ( "
                    SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE cast(convert(varchar(11),trndate,106)as datetime)<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                    SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                    SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,closingqty.uom as uom from a inner  join closingqty on "
                    SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                    SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                    'SQL1 = SQL1 & " "
                    SQL1 = SQL1 & " and   a.storecode=closingqty.storecode  "
                    SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(vform.keyfield) + "'"
                    SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND cast(convert(varchar(11),A.trndate,106)as datetime)<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  closingqty.closingstock>0 order by trndate desc,AUTOID desc "



                    gconnection.getDataSet(SQL1, "closingtable")
                    If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                        GroupBox3.Visible = True

                        For i As Integer = 0 To gdataset.Tables("closingtable").Rows.Count
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 1
                            AxfpSpread2.SetText(1, i + 1, Trim(vform.keyfield))

                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 2
                            AxfpSpread2.SetText(2, i + 1, gdataset.Tables("closingtable").Rows(i).Item("batchno"))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 3
                            AxfpSpread2.SetText(3, i + 1, Val(gdataset.Tables("closingtable").Rows(i).Item("quantity")))
                            AxfpSpread2.Row = i
                            AxfpSpread2.Col = 4
                            AxfpSpread2.SetText(4, i + 1, gdataset.Tables("closingtable").Rows(i).Item("uom"))



                        Next
                        AxfpSpread2.Focus()
                        AxfpSpread2.SetActiveCell(5, 1)

                    End If

                Else
                    Dim convvalue As Double

                    'sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + vform.keyfield4 + "'"
                    'gconnection.getDataSet(sql, "INVENTORYCATEGORYMASTER")
                    'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                    '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                    '    Dim sql1 As String
                    '    'If rateflag = "W" Then
                    '    '    sql1 = " select TOP 1  weightedrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                    '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                    '    'Else
                    '    '    sql1 = " select TOP 1  batchrate as rate,uom from VW_ratelist where itemcode='" + vform.keyfield + "' "
                    '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                    '    'End If
                    '    If rateflag = "W" Then

                    '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + vform.keyfield + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                    '    Else
                    '        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + vform.keyfield + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
                    '    End If
                    '    gconnection.getDataSet(sql1, "ratelist")
                    '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then
                    '        Dim pr As Double

                    '        AxfpSpread1.Col = 3
                    '        sql1 = "select isnull(convvalue,0) as convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                    '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                    '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                    '        Else
                    '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                    '            Exit Sub
                    '        End If
                    '        AxfpSpread1.Col = 7
                    '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") * (convvalue))
                    '    Else
                    '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + vform.keyfield + "'  AND  openningqty<>0 "
                    '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                    '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                    '            Dim pr As Double

                    '            AxfpSpread1.Col = 3
                    '            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                    '            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                    '            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    '                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    '                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                    '            Else
                    '                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                    '                Exit Sub
                    '            End If
                    '            AxfpSpread1.Col = 7
                    '            AxfpSpread1.Row = AxfpSpread1.ActiveRow


                    '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)


                    '        Else
                    '            AxfpSpread1.Col = 7
                    '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                    '            AxfpSpread1.Text = 0

                    '        End If
                    '    End If



                    'End If

                    AxfpSpread1.Col = 5
                    AxfpSpread1.ColHidden = True
                    Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom from closingqty where itemcode='" + vform.keyfield + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                    ' gconnection.getDataSet(sql11, "closingtable")

                    gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), vform.keyfield, Trim(TXT_FROMSTORECODE.Text), "")
                    Dim closingqty, rate As Double
                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                        rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                    Else
                        closingqty = 0
                        rate = 0
                    End If
                    uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                    sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + vform.keyfield2 + "'"
                    gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                    If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                        convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                    Else
                        convvalue = 0
                    End If
                    closingqty = Format(closingqty * convvalue, "0.000")
                    AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, closingqty)
                    AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, rate / convvalue)
                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)



                End If
            End If


            '  AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
        End If




    End Sub


    Private Sub cmd_fromStorecodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_fromStorecodeHelp.Click

        gSQLString = "SELECT DISTINCT storecode,ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER"
        M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_FROMSTORECODE.Text = Trim(vform.keyfield & "")
            txt_FromStorename.Text = Trim(vform.keyfield1 & "")
            doctype1 = "DMG"
            ' ADDED BY SRI FOR FROM SHELF
            If GSHELVING = "Y" Then
                sqlstring = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster WHERE  STORECODE='" + TXT_FROMSTORECODE.Text + "' And ISNULL(FREEZE,'')<>'Y'"
                gconnection.getDataSet(sqlstring, "FROMSHELF")
                If gdataset.Tables("FROMSHELF").Rows.Count > 0 Then
                    AxfpSpread1.Col = 9
                    AxfpSpread1.ColHidden = False
                Else
                    AxfpSpread1.Col = 9
                    AxfpSpread1.ColHidden = True
                End If
            End If
            ' END 
            Call autogenerate()
        Else
            Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
        End If

        vform.Close()
        dtp_Docdate.Focus()
        vform = Nothing
    End Sub

    Private Sub TXT_FROMSTORECODE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_FROMSTORECODE.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            If (TXT_FROMSTORECODE.Text <> "") Then
                TXT_FROMSTORECODE_Validated(sender, e)
            Else
                cmd_fromStorecodeHelp_Click(sender, e)
            End If

        End If
    End Sub

    Private Sub TXT_FROMSTORECODE_Validated(sender As Object, e As EventArgs) Handles TXT_FROMSTORECODE.Validated
        If Trim(TXT_FROMSTORECODE.Text) <> "" Then
            sqlstring = "SELECT * FROM STOREMASTER WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
            gconnection.getDataSet(sqlstring, "storemaster")
            If gdataset.Tables("storemaster").Rows.Count > 0 Then
                TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                txt_FromStorename.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                doctype1 = ""
                doctype1 = "DMG"
                ' ADDED BY SRI FOR FROM SHELF
                If GSHELVING = "Y" Then
                    sqlstring = "Select  Shelfcode,ShelfDesc FROM InventoryShelfMaster WHERE  STORECODE='" + TXT_FROMSTORECODE.Text + "' And ISNULL(FREEZE,'')<>'Y'"
                    gconnection.getDataSet(sqlstring, "FROMSHELF")
                    If gdataset.Tables("FROMSHELF").Rows.Count > 0 Then
                        AxfpSpread1.Col = 9
                        AxfpSpread1.ColHidden = False
                    Else
                        AxfpSpread1.Col = 9
                        AxfpSpread1.ColHidden = True
                    End If
                End If
                ' END 
                Call autogenerate()
                dtp_Docdate.Focus()
                AxfpSpread1.Focus()
            Else
                TXT_FROMSTORECODE.Text = ""
                TXT_FROMSTORECODE.Focus()
            End If
        End If
    End Sub

    Private Sub AxfpSpread1_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread1.KeyDownEvent
        Dim i As Integer
        Dim SQL As String
        Dim message, title, defaultValue As String
        Dim myValue As Object
        Dim uom1 As String
        If e.keyCode = Keys.Enter Then
            i = AxfpSpread1.ActiveRow
            'ITEMCODE
            AxfpSpread1.Row = i


            If AxfpSpread1.ActiveCol = 1 And AxfpSpread1.Lock = False Then

                AxfpSpread1.Col = 1
                If Trim(AxfpSpread1.Text) = "" Then



                    binditemcode()
                Else

                    SQL = " select I.itemcode,Itemname,uom,batchprocess,m.category from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(I.itemcode,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                        AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                        AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                        SQL = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                        gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                        AxfpSpread1.Col = 3
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                        Next Z
                        If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES1" Then


                            ' gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            '                     GroupBox3.Visible = True
                            ' Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                            Dim SQL1 As String = "with a as ( "
                            SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE cast(convert(varchar(11),trndate,106)as datetime)<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                            SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                            SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,closingqty.uom as uom from a inner  join closingqty on "
                            SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                            SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                            'SQL1 = SQL1 & " "
                            SQL1 = SQL1 & " and   a.storecode=closingqty.storecode  "
                            SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                            SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND cast(convert(varchar(11),A.trndate,106)as datetime)<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  ISNULL(closingqty.closingstock,0)>0 order by trndate desc,AUTOID desc "


                            'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                            'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "

                            gconnection.getDataSet(SQL1, "closingtable")
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                For k As Integer = 0 To gdataset.Tables("closingtable").Rows.Count
                                    AxfpSpread2.Row = k
                                    AxfpSpread2.Col = 1
                                    AxfpSpread2.SetText(1, k + 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))

                                    AxfpSpread2.Row = k
                                    AxfpSpread2.Col = 2
                                    AxfpSpread2.SetText(2, k + 1, gdataset.Tables("closingtable").Rows(k).Item("batchno"))
                                    AxfpSpread2.Row = k
                                    AxfpSpread2.Col = 3
                                    AxfpSpread2.SetText(3, k + 1, Val(gdataset.Tables("closingtable").Rows(k).Item("quantity")))
                                    AxfpSpread2.Row = k
                                    AxfpSpread2.Col = 4
                                    AxfpSpread2.SetText(4, k + 1, gdataset.Tables("closingtable").Rows(k).Item("uom"))

                                Next
                                AxfpSpread2.SetActiveCell(1, 5)
                                AxfpSpread2.Focus()

                            End If
                            Calculate()
                        Else
                            Dim convvalue As Double

                            'SQL = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                            'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                            'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                            '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                            '    Dim sql1 As String
                            '    'If rateflag = "W" Then
                            '    '    sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' "
                            '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                            '    'Else
                            '    '    sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' "
                            '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                            '    'End If
                            '    If rateflag = "W" Then

                            '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > cast(convert(varchar(11),trndate,106)as datetime) and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                            '    Else
                            '        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
                            '    End If
                            '    gconnection.getDataSet(sql1, "ratelist")
                            '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then

                            '        Dim pr As Double

                            '        AxfpSpread1.Col = 3
                            '        sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                            '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                            '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                            '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                            '        Else
                            '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                            '            Exit Sub
                            '        End If
                            '        AxfpSpread1.Col = 7
                            '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                            '    Else
                            '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and isnull(openningqty,0) <>0 "
                            '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                            '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                            '            Dim pr As Double

                            '            AxfpSpread1.Col = 3
                            '            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                            '            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                            '            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            '                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                            '                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                            '            Else
                            '                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                            '                Exit Sub
                            '            End If
                            '            AxfpSpread1.Col = 7
                            '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                            '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                            '        End If
                            '    End If



                            'End If

                            AxfpSpread1.Col = 5
                            AxfpSpread1.ColHidden = True
                            Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom from closingqty where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                            'gconnection.getDataSet(sql11, "closingtable")
                            gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), "")
                            Dim closingqty, rate As Double
                            If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                rate = gdataset.Tables("closingstock").Rows(0).Item("rate")

                            Else
                                closingqty = 0
                            End If
                            uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                            sql11 = "select isnull(convvalue,0) AS CONVVALUE,ISNULL(PRECISE,0) AS PRECISE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")) + "'"
                            gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                            Dim PRECISE As Double
                            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                PRECISE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("PRECISE")
                            Else
                                convvalue = 0
                            End If
                            AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, rate / convvalue)
                            closingqty = Format(closingqty * convvalue, "0.000")
                            AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, closingqty)
                            'If GBATCHNO = "Y" Then
                            '    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                            'Else
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                            '   End If
                        End If
                    End If
                End If                'ITEMNAME
            ElseIf AxfpSpread1.ActiveCol = 2 And AxfpSpread1.Lock = False Then
                AxfpSpread1.Col = 2
                If Trim(AxfpSpread1.Text) = "" Then
                    binditemname()
                Else

                    SQL = " select I.itemcode,Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                    SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(m.itemname,'')='" + Trim(AxfpSpread1.Text) + "'"
                    gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                    If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                        AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                        AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                        SQL = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"

                        gconnection.getDataSet(SQL, "INVITEM_TRANSUOM_LINK")
                        For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                            AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                        Next Z
                        If Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("batchprocess")) = "YES1" Then
                            '  gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            GroupBox3.Visible = True
                            '  Dim sql1 As String = "select sum(qty*mf) as quantity,rate,batchno from closingtable group by rate,batchno"
                            'Dim sql1 As String = "select sum(B.qty*B.mf) as quantity,A.Rate,A.batchno from closingtable A right outer join closingtable B "
                            'sql1 = sql1 & " on A.batchno=B.batchno where isnull(A.RATE,0)<>0 group by A.RATE,A.batchno,A.priority order by A.priority "
                            Dim SQL1 As String = "with a as ( "
                            SQL1 = SQL1 & " select MAX(trndate) as trndate,itemcode,storecode,batchno from closingqty WHERE cast(convert(varchar(11),trndate,106)as datetime)<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' "
                            SQL1 = SQL1 & " group by itemcode,storecode,batchno"
                            SQL1 = SQL1 & " ) select a.trndate,a.itemcode,a.storecode,a.batchno,ISNULL(closingqty.closingstock,0) as quantity,closingqty.uom as uom from a inner  join closingqty on "
                            SQL1 = SQL1 & "    a.trndate = closingqty.trndate And a.itemcode = closingqty.itemcode"
                            SQL1 = SQL1 & " and a.storecode=closingqty.storecode and a.batchno=closingqty.batchno"
                            'SQL1 = SQL1 & " "
                            SQL1 = SQL1 & " and   a.storecode=closingqty.storecode  "
                            SQL1 = SQL1 & "  WHERE A.ITEMCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                            SQL1 = SQL1 & " AND a.STORECODE='" + Trim(TXT_FROMSTORECODE.Text) + "' AND cast(convert(varchar(11),A.trndate,106)as datetime)<'" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' AND  closingqty.closingstock>0 order by trndate desc,AUTOID desc "


                            gconnection.getDataSet(SQL1, "closingtable")
                            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                                For k As Integer = 0 To gdataset.Tables("closingtable").Rows.Count
                                    AxfpSpread2.Row = k
                                    AxfpSpread2.Col = 1
                                    AxfpSpread2.SetText(1, k + 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))

                                    AxfpSpread2.Row = k
                                    AxfpSpread2.Col = 2
                                    AxfpSpread2.SetText(2, k + 1, gdataset.Tables("closingtable").Rows(k).Item("batchno"))
                                    AxfpSpread2.Row = k
                                    AxfpSpread2.Col = 3
                                    AxfpSpread2.SetText(3, k + 1, Val(gdataset.Tables("closingtable").Rows(k).Item("quantity")))
                                    AxfpSpread2.Row = k
                                    AxfpSpread2.Col = 4
                                    AxfpSpread2.SetText(4, k + 1, gdataset.Tables("closingtable").Rows(k).Item("uom"))

                                Next
                                AxfpSpread2.SetActiveCell(1, 5)
                                AxfpSpread2.Focus()

                            Else
                                Dim convvalue As Double

                                'SQL = "sELECT ISNULL(RATEFLAG,'') AS RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                                'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")
                                '    'If rateflag = "W" Then
                                '    '    SQL1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                                '    'Else
                                '    '    SQL1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'"
                                '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                                '    'End If
                                '    If rateflag = "W" Then

                                '        SQL1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                                '    Else
                                '        SQL1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
                                '    End If
                                '    gconnection.getDataSet(SQL1, "ratelist")
                                '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then

                                '        Dim pr As Double

                                '        AxfpSpread1.Col = 3
                                '        SQL1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                                '        gconnection.getDataSet(SQL1, "INVENTORY_TRANSCONVERSION")
                                '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                '        Else
                                '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                                '            Exit Sub
                                '        End If
                                '        AxfpSpread1.Col = 7
                                '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                                '    Else
                                '        SQL1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' and isnull(openningqty,0) <>0 "
                                '        gconnection.getDataSet(SQL1, "inv_InventoryOpenningstock")
                                '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                                '            Dim pr As Double

                                '            AxfpSpread1.Col = 3
                                '            SQL1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                                '            gconnection.getDataSet(SQL1, "INVENTORY_TRANSCONVERSION")
                                '            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                '                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                '                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                                '            Else
                                '                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                                '                Exit Sub
                                '            End If
                                '            AxfpSpread1.Col = 7
                                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                                '        End If
                                '    End If



                                'End If


                                AxfpSpread1.Col = 5
                                AxfpSpread1.ColHidden = True
                                Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom from closingqty where itemcode='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")) + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                                ' gconnection.getDataSet(sql11, "closingtable")
                                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), "")
                                Dim closingqty, rate As Double
                                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                    rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                                Else
                                    closingqty = 0
                                    rate = 0
                                End If
                                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                                sql11 = "select isnull(convvalue,0) AS CONVVALUE,ISNULL(PRECISE,0) AS PRECISE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")) + "'"
                                gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
                                Dim PRECISE As Double
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                                    PRECISE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("PRECISE")
                                Else
                                    convvalue = 1
                                End If
                                closingqty = Format(closingqty * convvalue, "0.000")
                                AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, closingqty)
                                AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, rate / convvalue)
                                'If GBATCHNO = "Y" Then
                                '    AxfpSpread1.SetActiveCell(5, AxfpSpread1.ActiveRow)
                                'Else
                                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                                '   End If
                            End If
                        End If
                        'AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                    Else
                        AxfpSpread1.SetActiveCell(2, AxfpSpread1.ActiveRow)
                    End If
                End If

                'QTY
            ElseIf AxfpSpread1.ActiveCol = 3 And AxfpSpread1.Lock = False Then
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Col = 1
                Dim sql1 As String
                Dim ITEMCODE As String
                Dim convvalue As Double
                Dim pr As Double
                ITEMCODE = AxfpSpread1.Text


                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), "")
                Dim closingqty, rate As Double
                If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
                    uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                Else
                    closingqty = 0
                End If

                AxfpSpread1.Col = 3
                SQL = "select isnull(convvalue,0) AS CONVVALUE,ISNULL(PRECISE,0) AS PRECISE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + AxfpSpread1.Text + "'"
                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                Dim PRECISE As Double
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                    PRECISE = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("PRECISE")
                Else
                    convvalue = 0
                End If

                AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, closingqty)
                AxfpSpread1.Col = 7
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(rate / convvalue)

                AxfpSpread1.SetActiveCell(4, AxfpSpread1.Row)
                'SQL = "    sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER inner join inv_inventoryitemmaster on"
                'SQL = SQL & " inv_inventoryitemmaster.category = INVENTORYCATEGORYMASTER.CATEGORYCODE where itemcode='" + Trim(ITEMCODE) + "'"
                ''  sql = "sELECT RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" + Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("category")) + "'"
                'gconnection.getDataSet(SQL, "INVENTORYCATEGORYMASTER")
                'If (gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0) Then
                '    Dim rateflag As String = gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATEFLAG")

                '    'If rateflag = "W" Then
                '    '    sql1 = " select TOP 1  weightedrate as rate,uom from ratelist where itemcode='" + Trim(ITEMCODE) + "' and storecode='" + TXT_FROMSTORECODE.Text + "'"
                '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "
                '    'Else
                '    '    sql1 = " select TOP 1  batchrate as rate,uom from ratelist where itemcode='" + Trim(ITEMCODE) + "' and storecode='" + TXT_FROMSTORECODE.Text + "'"
                '    '    sql1 = sql1 & " and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' > grndate  order by grndate desc "

                '    'End If
                '    If rateflag = "W" Then

                '        sql1 = "select TOP 1  closingstock,closingvalue ,uom,(closingvalue/closingstock) as rate from CLOSINGQTY where itemcode='" + Trim(ITEMCODE) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > Trndate and ttype in('GRN','Openning')  and qty<>0 order by Trndate desc "
                '    Else
                '        sql1 = "select TOP 1  uom, rate from TrnsView where itemcode='" + Trim(ITEMCODE) + "'  and  '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "'  > docdate and ttype in('GRN','Openning') order by docdate desc"
                '    End If
                '    gconnection.getDataSet(sql1, "ratelist")
                '    If (gdataset.Tables("ratelist").Rows.Count > 0) Then

                '        Dim convvalue As Double
                '        Dim pr As Double

                '        AxfpSpread1.Col = 3
                '        sql1 = "select isnull(convvalue,0) as convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("ratelist").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                '        gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                '        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                '            pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                '        Else
                '            MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("ratelist").Rows(0).Item("Uom"))
                '            Exit Sub
                '        End If
                '        AxfpSpread1.Col = 7
                '        AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '        AxfpSpread1.Text = Trim(gdataset.Tables("ratelist").Rows(0).Item("Rate") / convvalue)
                '    Else
                '        sql1 = "select (openningvalue/openningqty) as rate,uom from inv_InventoryOpenningstock where itemcode='" + Trim(gdataset.Tables("INDENTDETAILS").Rows(0).Item("itemcode")) + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and isnull(openningqty,0) <>0 "
                '        gconnection.getDataSet(sql1, "inv_InventoryOpenningstock")
                '        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then
                '            Dim convvalue As Double
                '            Dim pr As Double

                '            AxfpSpread1.Col = 3
                '            sql1 = "select  isnull(convvalue,0) as convvalue,isnull(precise,0) as precise  from INVENTORY_TRANSCONVERSION where baseuom='" + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom") + "' and transuom='" + AxfpSpread1.Text + "'"
                '            gconnection.getDataSet(sql1, "INVENTORY_TRANSCONVERSION")
                '            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                '                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
                '                pr = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("precise")
                '            Else
                '                MessageBox.Show("Please create Relation Between " + AxfpSpread1.Text + " and " + gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Uom"))
                '                Exit Sub
                '            End If
                '            AxfpSpread1.Col = 7
                '            AxfpSpread1.Row = AxfpSpread1.ActiveRow
                '            AxfpSpread1.Text = Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Rate") / convvalue)
                '        End If
                '    End If
                'End If

            ElseIf AxfpSpread1.ActiveCol = 4 And AxfpSpread1.Lock = False Then

                AxfpSpread1.Col = 1
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim itemcode1 As String = AxfpSpread1.Text
                AxfpSpread1.Col = 2
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim itemname1 As String = AxfpSpread1.Text
                AxfpSpread1.Col = 3
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim uom3 As String = AxfpSpread1.Text
                AxfpSpread1.Col = 4
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                Dim totqty As String = AxfpSpread1.Text
                If GBATCHNO = "Y" Then
                    If (Val(AxfpSpread1.Text) <> 0) Then
                        Dim match As New Matching
                        match.LBL_ITEMCODE.Text = itemcode1
                        match.lbl_itemname.Text = itemname1
                        match.TType = "DAMAGE"
                        match.STORECODE = TXT_FROMSTORECODE.Text
                        match.TotalQTY = totqty
                        match.docno = txt_Docno.Text
                        match.docdate = Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy")
                        match.uom = uom3
                        match.ShowDialog()
                    End If
                End If

                AxfpSpread1.Col = 1
                If AxfpSpread1.Lock = False Then
                    AxfpSpread1.Col = 4
                    If (Val(AxfpSpread1.Text) <> 0) Then
                        Dim dMGqty As Double = Val(AxfpSpread1.Text)
                        AxfpSpread1.Col = 7
                        Dim RATE As Double = Val(AxfpSpread1.Text)
                        AxfpSpread1.Col = 8
                        AxfpSpread1.Text = dMGqty * RATE
                        AxfpSpread1.Col = 1
                        Dim itemcode As String = AxfpSpread1.Text
                        AxfpSpread1.Col = 5
                        Dim batchno As String = AxfpSpread1.Text
                        SQL = "select ISNULL(batchprocess,'') AS batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
                        gconnection.getDataSet(SQL, "INV_InventoryItemMaster")
                        If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                            If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
                                AxfpSpread1.Col = 3
                                Dim uom As String = AxfpSpread1.Text
                                '   gconnection.closingbatch(CStr(Format(dtp_Docdate.Value, "dd/MMM/yyyy")), itemcode, Trim(TXT_FROMSTORECODE.Text), uom)
                                Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                                '  gconnection.getDataSet(sql11, "closingtable")

                                'If GBATCHNO = "Y" Then
                                '    gconnection.BatchWiseClosingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), batchno)
                                ' Else
                                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
                                '   End If
                                Dim closingqty As Double
                                If (gdataset.Tables("closingstock").Rows.Count > 0) Then

                                    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                                    RATE = gdataset.Tables("closingstock").Rows(0).Item("rate")
                                Else
                                    closingqty = 0
                                    RATE = 0
                                End If
                                uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
                                SQL = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                                gconnection.getDataSet(SQL, "INVENTORY_TRANSCONVERSION")
                                Dim convvalue As Double
                                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                                Else
                                    convvalue = 0
                                End If
                                closingqty = Format(closingqty * convvalue, "0.000")
                                If (dMGqty > closingqty) Then
                                    MessageBox.Show("Damage Quantity Cannot be Greater than Closing Quantity   " + closingqty.ToString())

                                    AxfpSpread1.Col = 4
                                    AxfpSpread1.Row = AxfpSpread1.ActiveRow
                                    AxfpSpread1.Text = Val(closingqty)

                                    AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                                Else
                                    AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                                End If
                            End If

                        End If
                        Calculate()

                        '        End If
                    Else
                        AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)

                    End If
                    Calculate()
                    If (GroupBox3.Visible = True) Then
                        AxfpSpread2.SetActiveCell(5, 1)
                        AxfpSpread2.Focus()
                    Else
                        AxfpSpread1.Col = 4
                        If (Val(AxfpSpread1.Text) = 0) Then
                            AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                        Else
                            AxfpSpread1.SetActiveCell(1, AxfpSpread1.Row + 1)
                        End If


                    End If
                End If

            End If
        ElseIf AxfpSpread1.ActiveCol = 5 Then
            ''If GBATCHNO = "Y" Then
            ''    AxfpSpread1.Col = 5
            ''    BatchNoSelection()
            ''End If
            'AxfpSpread1.Col = 1
            'Dim itemcode As String = AxfpSpread1.Text
            'AxfpSpread1.Col = 3
            'Dim uom As String = AxfpSpread1.Text
            'AxfpSpread1.Col = 5
            'Dim Batchno As String = AxfpSpread1.Text
            'Dim convvalue As Double
            'Dim sql11 As String
            'gconnection.BatchWiseClosingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), Batchno)
            'Dim closingqty, rate As Double
            'If (gdataset.Tables("closingstock").Rows.Count > 0) Then
            '    closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
            '    rate = gdataset.Tables("closingstock").Rows(0).Item("rate")
            'Else
            '    closingqty = 0
            '    rate = 0
            'End If
            'uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
            'sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
            'gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
            'If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
            '    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")
            'Else
            '    convvalue = 0
            'End If
            'closingqty = Format(closingqty * convvalue, "0.000")
            'AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, closingqty)
            'AxfpSpread1.SetText(7, AxfpSpread1.ActiveRow, rate / convvalue)
            'AxfpSpread1.SetActiveCell(4, AxfpSpread1.Row)
        ElseIf AxfpSpread1.ActiveCol = 9 Then
            If GSHELVING = "Y" Then
                AxfpSpread1.Col = 9
                Fromshelf()
            End If
        ElseIf e.keyCode = Keys.F3 Then
            If Mid(Cmd_Add.Text, 1, 1).ToUpper() = "A" Then
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
                AxfpSpread1.SetActiveCell(1, AxfpSpread1.ActiveRow)
            End If

            '   Calculate()


        End If
        Calculate()

        If (GroupBox3.Visible = True) Then
            AxfpSpread2.SetActiveCell(5, 1)
            AxfpSpread2.Focus()
            Me.Focus()
        End If
    End Sub
    Private Sub Fromshelf()
        Dim vform As New ListOperattion1
        gSQLString = "SELECT distinct Shelfcode,ShelfDesc FROM InventoryShelfMaster"
        M_WhereCondition = " WHERE STORECODE='" + TXT_FROMSTORECODE.Text + "' AND ISNULL(FREEZE,'')<>'Y' "
        'M_Groupby = " c.itemcode,i.itemname,c.batchno "
        M_ORDERBY = " Shelfcode "
        vform.Field = " Shelfcode,ShelfDesc"
        vform.vFormatstring = "    Shelf code    |   Shelf Desc      "
        vform.vCaption = "Shelf Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_Duplicate(vform.keyfield) = False) Then
                AxfpSpread1.Col = 9
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield)
                AxfpSpread1.SetActiveCell(9, 1)
                AxfpSpread1.Focus()
            Else
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If
        End If
    End Sub
    Private Sub BatchNoSelection()
        Dim vform As New ListOperattion1
        Dim message, title, defaultValue, itemcode As String
        Dim myValue As Object
        message = "Enter Batch No"
        title = "Batch No"
        AxfpSpread1.Col = 1
        AxfpSpread1.Row = AxfpSpread1.ActiveRow
        itemcode = AxfpSpread1.Text
        gSQLString = "select  DISTINCT c.itemcode,i.itemname,c.batchno,c.qty from INV_InventoryItemMaster i inner join  closingqty c  on "
        gSQLString = gSQLString & " i.itemcode=c.itemcode "
        M_WhereCondition = " where i.Category in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(i.void,'')='N' and isnull(c.storecode,'')='" + TXT_FROMSTORECODE.Text + "'  and isnull(c.batchno,'') <>'' and c.itemcode ='" + itemcode + "' "
        'M_Groupby = " c.itemcode,i.itemname,c.batchno "
        M_ORDERBY = " c.itemcode "
        vform.Field = " c.itemcode,i.itemname,c.batchno,cast(C.QTY as varchar) "
        vform.vFormatstring = "    Itemcode    |                       Itemname                  |   batchno      |  QTY  "
        vform.vCaption = "Item MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            If (check_Duplicate(vform.keyfield) = False) Then
                AxfpSpread1.Col = 5
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield2)
                AxfpSpread1.Col = 4
                AxfpSpread1.Row = AxfpSpread1.ActiveRow
                AxfpSpread1.Text = Trim(vform.keyfield3)
                AxfpSpread1.SetActiveCell(4, AxfpSpread1.ActiveRow)
                'AxfpSpread1.SetActiveCell(4, 1)
                AxfpSpread1.Focus()
            Else
                AxfpSpread1.DeleteRows(AxfpSpread1.ActiveRow, 1)
            End If
        End If
    End Sub
    Private Sub Calculate()
        Try
            Dim ValQty As Double
            Dim Calqty As Double
            Dim Itemcode As String
            Dim i, j As Integer
            '  If AxfpSpread1.ActiveCol = 1 Or AxfpSpread1.ActiveCol = 2 Or AxfpSpread1.ActiveCol = 3 Or AxfpSpread1.ActiveCol = 4 Or AxfpSpread1.ActiveCol = 5 Or AxfpSpread1.ActiveCol = 6 Then




            Me.txt_Totalqty.Text = ""
            For i = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Col = 4
                AxfpSpread1.Row = i
                ValQty = Val(AxfpSpread1.Text)
                Me.txt_Totalqty.Text = Format(Val(Me.txt_Totalqty.Text) + Val(ValQty), "0.000")
            Next i

            'End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub addoperation()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim ITEMCODE As String
        Dim AMT As Double = 0
        docno = Split(Trim(txt_Docno.Text), "/")
        sqlstring = "INSERT INTO STOCKDMGHEADER(Docno,Docdetails,Docdate,Doctype,storecode,storedesc "
        sqlstring = sqlstring & ", Totalqty,Remarks,Void,Adduser,Adddate)"
        sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
        sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
        sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
        sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
        sqlstring = sqlstring & " " & Format(Val(txt_Totalqty.Text), "0.000") & " ,"
        sqlstring = sqlstring & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,"
        sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',getDate())"
        'sqlstring = sqlstring & " '',getDate())"

        insert(0) = sqlstring
        'Dim Seq As Double = gconnection.getInvSeq(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"))

        For i As Integer = 1 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Row = i

            sqlstring = "INSERT INTO STOCKDMGDETAIL(Docno,Docdetails,Docdate,Doctype,storecode,storedesc,"
            'If Trim(UCase(gShortname)) = "CGC" Then
            '    sqlstring = sqlstring & " Itemcode,Itemname,Uom,Qty,BatchNo,ClosingQty,"
            '    sqlstring = sqlstring & " Void,Adduser,Adddatetime,rate,amount)"
            'Else
            '    sqlstring = sqlstring & " Itemcode,Itemname,Uom,DMGQty,BatchNo,ClosingQty,"
            '    sqlstring = sqlstring & " Void,Adduser,Adddate,rate,amount)"
            'End If
            sqlstring = sqlstring & " Itemcode,Itemname,Uom,DMGQty,BatchNo,ClosingQty,"
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "SHELF,"
            End If
            sqlstring = sqlstring & " Void,Adduser,Adddate,rate,amount)"

            sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
            sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
            sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
            AxfpSpread1.Col = 1
            ITEMCODE = AxfpSpread1.Text
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 2
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 3
            sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            AxfpSpread1.Col = 4
            Dim qty As Double
            qty = Val(AxfpSpread1.Text)
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","

            AxfpSpread1.Col = 5
            sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
            AxfpSpread1.Col = 6
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            If GSHELVING = "Y" Then
                AxfpSpread1.Col = 9
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
            End If
            sqlstring = sqlstring & " 'N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "',getDate(),"
            AxfpSpread1.Col = 7

            Dim rate As Double = Val(AxfpSpread1.Text)
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
            AxfpSpread1.Col = 8
            AMT = AMT + Val(AxfpSpread1.Text)
            sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ")"





            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            'Dim closingqty As Double
            'Dim closingvalue As Double
            'Dim closingqty1 As Double
            'Dim closingvalue1 As Double
            'Dim UOM As String
            'Dim uom1 As String
            'Dim convvalue As Double

            'sqlstring = " Select batchprocess from inv_inventoryitemmaster where itemcode='" + ITEMCODE + "' "
            'gconnection.getDataSet(sqlstring, "inv_inventoryitemmaster")
            'If (gdataset.Tables("inv_inventoryitemmaster").Rows.Count > 0) Then
            '    If (gdataset.Tables("inv_inventoryitemmaster").Rows(0).Item("batchprocess")) = "YES" Then
            '        Dim batchno As String
            '        AxfpSpread1.Row = i
            '        AxfpSpread1.Col = 5
            '        batchno = AxfpSpread1.Text
            '        AxfpSpread1.Row = i
            '        AxfpSpread1.Col = 3
            '        UOM = AxfpSpread1.Text
            '        '  sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,uom from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + TXT_FROMSTORECODE.Text + "'   and batchno='" + batchno + "' and trndate<'" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
            '        'gconnection.getDataSet(sqlstring, "closingqty")
            '        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), ITEMCODE, Trim(TXT_FROMSTORECODE.Text), "")
            '        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '            uom1 = gdataset.Tables("closingqty").Rows(0).Item("uom")
            '            Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
            '            convvalue = gconnection.getvalue(sql)

            '            closingqty = gdataset.Tables("closingqty").Rows(0).Item("closingstock")
            '            closingvalue = gdataset.Tables("closingqty").Rows(0).Item("closingvalue")
            '        Else
            '            closingqty = 0
            '            convvalue = 1
            '        End If
            '        sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,trns_seq)"
            '        sqlstring = sqlstring & " values ('" + txt_Docno.Text + "',"
            '        AxfpSpread1.Col = 1
            '        sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            '        AxfpSpread1.Col = 3
            '        sqlstring = sqlstring & "'" + uom1 + "', "
            '        sqlstring = sqlstring & "  '" + TXT_FROMSTORECODE.Text + "',"
            '        sqlstring = sqlstring & " '" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "',"
            '        AxfpSpread1.Col = 4

            '        sqlstring = sqlstring & " " & Format(Val(closingqty), "0.000") & ","

            '        sqlstring = sqlstring & "'" + Format(Val(closingvalue), "0.000") + "' ,"
            '        AxfpSpread1.Col = 4
            '        sqlstring = sqlstring & " " & Format((Val(AxfpSpread1.Text) / convvalue) * -1, "0.000") & ","
            '        sqlstring = sqlstring & " " & Format(Val(closingqty) + ((Val(AxfpSpread1.Text) / convvalue) * -1), "0.000") & ","

            '        sqlstring = sqlstring & "'" + Format(Val(closingvalue) - Val(qty * rate), "0.000") + "' ,"


            '        sqlstring = sqlstring & " 'Y',"
            '        sqlstring = sqlstring & "  'DAMAGE', "
            '        AxfpSpread1.Col = 5
            '        sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(dtp_Docdate.Value, "dd/MMM/yyyy") & "'))"
            '        ReDim Preserve insert(insert.Length)
            '        insert(insert.Length - 1) = sqlstring

            '    Else
            '        AxfpSpread1.Col = 3
            '        UOM = AxfpSpread1.Text
            '        'sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,uom from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and trndate<'" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
            '        '  gconnection.getDataSet(sqlstring, "closingqty")
            '        gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), ITEMCODE, Trim(TXT_FROMSTORECODE.Text), "")
            '        If (gdataset.Tables("closingstock").Rows.Count > 0) Then
            '            uom1 = gdataset.Tables("closingstock").Rows(0).Item("uom")
            '            Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + UOM + "'"
            '            convvalue = gconnection.getvalue(sql)

            '            closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
            '            closingvalue = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
            '        End If
            '        sqlstring = "insert into closingqty(Trnno,itemcode,uom,storecode,Trndate,openningstock,openningvalue,qty,closingstock,closingvalue,batchyn,ttype,batchno,trns_seq)"
            '        sqlstring = sqlstring & " values ('" + txt_Docno.Text + "',"
            '        AxfpSpread1.Col = 1
            '        sqlstring = sqlstring & "'" + AxfpSpread1.Text + "',"
            '        AxfpSpread1.Col = 3
            '        sqlstring = sqlstring & "'" + uom1 + "', "
            '        sqlstring = sqlstring & "  '" + TXT_FROMSTORECODE.Text + "',"
            '        sqlstring = sqlstring & " '" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "',"


            '        sqlstring = sqlstring & " '" & Format(Val(closingqty), "0.000") & "',"

            '        sqlstring = sqlstring & "'" + Format(Val(closingvalue), "0.000") + "' ,"
            '        AxfpSpread1.Col = 4
            '        sqlstring = sqlstring & " " & Format((Val(AxfpSpread1.Text) / convvalue) * -1, "0.000") & ","
            '        sqlstring = sqlstring & " " & Format(closingqty - (Val(AxfpSpread1.Text) / convvalue), "0.000") & ","

            '        sqlstring = sqlstring & "'" + Format(Val(closingvalue) - Val(qty * rate), "0.000") + "' ,"


            '        sqlstring = sqlstring & " 'N',"
            '        sqlstring = sqlstring & "  'DAMAGE', "
            '        AxfpSpread1.Col = 5
            '        sqlstring = sqlstring & "  '" + AxfpSpread1.Text + "',DBO.INV_GETSEQNO('" & Format(dtp_Docdate.Value, "dd/MMM/yyyy") & "'))"
            '        ReDim Preserve insert(insert.Length)
            '        insert(insert.Length - 1) = sqlstring

            '    End If
            '    'sqlstring = "update CLOSINGQTY set TRNS_SEQ=g.TRNS_SEQ from CLOSINGQTY c inner join STOCKDMGDETAIL g on trnno='" + txt_Docno.Text + "' where c.Itemcode='" + ITEMCODE + "' and  c.Trndate= G.Docdate"
            '    'ReDim Preserve insert(insert.Length)
            '    'insert(insert.Length - 1) = sqlstring
            '    'gconnection.MoreTrans1(insert)
            '    'ReDim insert(0)
            'End If
            'sqlstring = "Select getdate()"
            'ddate = gconnection.getvalue(sqlstring)
            'If (Format(CDate(ddate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
            '    Dim batchyn As String
            '    Dim AUTOID As Integer = 0

            '    '  sqlstring = "select TOP 1  ISNULL(closingstock,0) AS closingstock,closingvalue,autoid from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + TXT_FROMSTORECODE.Text + "'and trndate<='" + Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"
            '    '  gconnection.getDataSet(sqlstring, "closingqty")
            '    gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), ITEMCODE, Trim(TXT_FROMSTORECODE.Text), "")
            '    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
            '        AUTOID = Val(gdataset.Tables("closingstock").Rows(0).Item("AUTOID"))
            '        closingqty = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
            '        closingvalue = gdataset.Tables("closingstock").Rows(0).Item("closingvalue")
            '    End If

            '    sqlstring = "update closingqty set openningstock= openningstock -" + Format(Val(qty), "0.000") + " ,"
            '    sqlstring = sqlstring & "  openningvalue="
            '    sqlstring = sqlstring & "  CASE WHEN openningstock=0"
            '    sqlstring = sqlstring & "  THEN"
            '    sqlstring = sqlstring & "   '" + Format(Val((qty * rate)), "0.000") + "' "
            '    sqlstring = sqlstring & "    Else"

            '    sqlstring = sqlstring & "  openningvalue -" + Format(Val((qty * rate)), "0.000") + ""
            '    sqlstring = sqlstring & "    End"
            '    sqlstring = sqlstring & " ,closingstock= closingstock -" + Format(Val(qty), "0.000") + " ,"
            '    sqlstring = sqlstring & "  closingvalue="
            '    sqlstring = sqlstring & "  CASE WHEN closingstock=0"
            '    sqlstring = sqlstring & "  THEN "
            '    sqlstring = sqlstring & "  0 "
            '    sqlstring = sqlstring & "  Else"
            '    sqlstring = sqlstring & "     closingvalue -" + Format(Val((qty * rate)), "0.000") + ""
            '    sqlstring = sqlstring & "       End"

            '    sqlstring = sqlstring & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "'"
            '    sqlstring = sqlstring & "   and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + ITEMCODE + "'"
            '    '  sqlstring = sqlstring & " AND AUTOID >'" + AUTOID.ToString() + "'  "
            '    'If (batchyn = "Y") Then
            '    '    AxfpSpread1.Col = 6
            '    '    sqlstring = sqlstring & "  and  batchno='" + AxfpSpread1.Text + "'"
            '    'End If
            '    ReDim Preserve insert(insert.Length)
            '    insert(insert.Length - 1) = sqlstring



            'End If

        Next

        If GACCPOST.ToUpper() = "Y" Then


            'sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Docno.Text) + "' AND  VoucherType='DAMAGE'"
            'ReDim Preserve insert(insert.Length)
            'insert(insert.Length - 1) = sqlstring

            'Dim damGLCODE, DAMGLDESC, ACCOUNTCODE, ACCOUNTDESC, damcccode, damccdesc, costcentercode, costcenterdesc As String
            'Dim decription As String
            'Dim amount As Double
            'If gAcPostingWise = "ITEM" Then
            '    For k As Integer = 1 To AxfpSpread1.DataRowCnt

            '        AxfpSpread1.Row = k

            '        AxfpSpread1.Col = 9
            '        amount = Val(AxfpSpread1.Text)
            '        AMT = amount
            '        AxfpSpread1.Col = 1
            '        If Trim(AxfpSpread1.Text) <> "" Then
            '            sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
            '            gconnection.getDataSet(sqlstring, "SLCODE1")
            '            If gdataset.Tables("SLCODE1").Rows.Count > 0 Then

            '                damGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("damGLCODE")
            '                DAMGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("DAMGLDESC")
            '                ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
            '                ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
            '                damcccode = gdataset.Tables("SLCODE1").Rows(0).Item("damcccode")
            '                damccdesc = gdataset.Tables("SLCODE1").Rows(0).Item("damccdesc")
            '                costcentercode = gdataset.Tables("SLCODE1").Rows(0).Item("costcentercode")
            '                costcenterdesc = gdataset.Tables("SLCODE1").Rows(0).Item("costcenterdesc")
            '            Else
            '                MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
            '                Exit Sub
            '            End If
            '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            '            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
            '            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
            '            sqlstring = sqlstring & "'', 'DAMAGE', '" & damGLCODE & "',"
            '            sqlstring = sqlstring & "'" & DAMGLDESC & "',"
            '            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
            '            sqlstring = sqlstring & "'" & damcccode & "','" & damccdesc & "',"
            '            sqlstring = sqlstring & "'DEBIT',"
            '            'AMT = Format(Val(txt_Billamount.Text), "0.000")
            '            decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
            '            sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

            '            'slcode = txt_Storecode.Text
            '            sqlstring = sqlstring & "'N','" + gUsername + "')"
            '            ReDim Preserve insert(insert.Length)
            '            insert(insert.Length - 1) = sqlstring


            '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            '            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
            '            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
            '            sqlstring = sqlstring & "'', 'DAMAGE', '" & ACCOUNTCODE & "',"
            '            sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
            '            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
            '            sqlstring = sqlstring & "'" & costcentercode & "','" & costcenterdesc & "',"
            '            sqlstring = sqlstring & "'CREDIT',"
            '            'amt = Format(Val(txt_Billamount.Text), "0.000")
            '            decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
            '            sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

            '            'slcode = txt_Storecode.Text
            '            sqlstring = sqlstring & "'N','" + gUsername + "')"
            '            ReDim Preserve insert(insert.Length)
            '            insert(insert.Length - 1) = sqlstring
            '        End If

            '    Next
            'ElseIf gAcPostingWise = "CATEGORY" Then
            '    For k As Integer = 1 To AxfpSpread1.DataRowCnt

            '        AxfpSpread1.Row = k

            '        AxfpSpread1.Col = 9
            '        amount = Val(AxfpSpread1.Text)
            '        AMT = amount
            '        AxfpSpread1.Col = 1
            '        If Trim(AxfpSpread1.Text) <> "" Then
            '            sqlstring = "select * from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category AND IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
            '            gconnection.getDataSet(sqlstring, "SLCODE1")
            '            If gdataset.Tables("SLCODE1").Rows.Count > 0 Then

            '                damGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("damGLCODE")
            '                DAMGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("DAMGLDESC")
            '                ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
            '                ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
            '                damcccode = gdataset.Tables("SLCODE1").Rows(0).Item("damcccode")
            '                damccdesc = gdataset.Tables("SLCODE1").Rows(0).Item("damccdesc")
            '                costcentercode = gdataset.Tables("SLCODE1").Rows(0).Item("costcentercode")
            '                costcenterdesc = gdataset.Tables("SLCODE1").Rows(0).Item("costcenterdesc")
            '            Else
            '                MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
            '                Exit Sub
            '            End If
            '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            '            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
            '            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
            '            sqlstring = sqlstring & "'', 'DAMAGE', '" & damGLCODE & "',"
            '            sqlstring = sqlstring & "'" & DAMGLDESC & "',"
            '            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
            '            sqlstring = sqlstring & "'" & damcccode & "','" & damccdesc & "',"
            '            sqlstring = sqlstring & "'DEBIT',"
            '            'AMT = Format(Val(txt_Billamount.Text), "0.000")
            '            decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
            '            sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

            '            'slcode = txt_Storecode.Text
            '            sqlstring = sqlstring & "'N','" + gUsername + "')"
            '            ReDim Preserve insert(insert.Length)
            '            insert(insert.Length - 1) = sqlstring


            '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            '            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
            '            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
            '            sqlstring = sqlstring & "'', 'DAMAGE', '" & ACCOUNTCODE & "',"
            '            sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
            '            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
            '            sqlstring = sqlstring & "'" & costcentercode & "','" & costcenterdesc & "',"
            '            sqlstring = sqlstring & "'CREDIT',"
            '            'amt = Format(Val(txt_Billamount.Text), "0.000")
            '            decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
            '            sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

            '            'slcode = txt_Storecode.Text
            '            sqlstring = sqlstring & "'N','" + gUsername + "')"
            '            ReDim Preserve insert(insert.Length)
            '            insert(insert.Length - 1) = sqlstring
            '        End If

            '    Next
            'Else

            '    sqlstring = "select damGLCODE, DAMGLDESC,ACCOUNTCODE,ACCOUNTDESC,damcccode,damccdesc,costcentercode,costcenterdesc from ACCOUNTSTAGGINGNEW  WHERE "
            '    sqlstring = sqlstring & "CODE='" & TXT_FROMSTORECODE.Text & "' AND DESCRIPTION='" & txt_FromStorename.Text & "' AND  isnull(VOID,'')<>'Y'"
            '    gconnection.getDataSet(sqlstring, "SLCODE1")

            '    If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
            '        damGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("damGLCODE")
            '        DAMGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("DAMGLDESC")
            '        ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
            '        ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
            '        damcccode = gdataset.Tables("SLCODE1").Rows(0).Item("damcccode")
            '        damccdesc = gdataset.Tables("SLCODE1").Rows(0).Item("damccdesc")
            '        costcentercode = gdataset.Tables("SLCODE1").Rows(0).Item("costcentercode")
            '        costcenterdesc = gdataset.Tables("SLCODE1").Rows(0).Item("costcenterdesc")

            '    Else
            '        MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
            '        Exit Sub
            '    End If
            '    If damGLCODE = "" Then

            '        MessageBox.Show("NO GL FOUND FOR DAMAGE POSTING...")
            '        'check = False

            '        Exit Sub

            '    End If

            '    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            '    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
            '    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
            '    sqlstring = sqlstring & "'', 'DAMAGE', '" & damGLCODE & "',"
            '    sqlstring = sqlstring & "'" & DAMGLDESC & "',"
            '    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
            '    sqlstring = sqlstring & "'" & damcccode & "','" & damccdesc & "',"
            '    sqlstring = sqlstring & "'DEBIT',"
            '    'AMT = Format(Val(txt_Billamount.Text), "0.000")
            '    decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
            '    sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

            '    'slcode = txt_Storecode.Text
            '    sqlstring = sqlstring & "'N')"
            '    ReDim Preserve insert(insert.Length)
            '    insert(insert.Length - 1) = sqlstring


            '    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            '    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID)"
            '    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
            '    sqlstring = sqlstring & "'', 'DAMAGE', '" & ACCOUNTCODE & "',"
            '    sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
            '    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
            '    sqlstring = sqlstring & "'" & costcentercode & "','" & costcenterdesc & "',"
            '    sqlstring = sqlstring & "'CREDIT',"
            '    'amt = Format(Val(txt_Billamount.Text), "0.000")
            '    decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
            '    sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

            '    'slcode = txt_Storecode.Text
            '    sqlstring = sqlstring & "'N','" + gUsername + "')"
            '    ReDim Preserve insert(insert.Length)
            '    insert(insert.Length - 1) = sqlstring
            'End If





        End If




            gconnection.MoreTrans(insert)

        If gShortname = "RSAOI" Then
            'For Maker/Checker
            gconnection.FORM_MCA(GmoduleName, "STOCKDMGHEADER", "Docdetails='" & Trim(txt_Docno.Text) & "'", "I") '''for mca
            gconnection.FORM_MCA(GmoduleName, "STOCKDMGDETAIL", "Docdetails='" & Trim(txt_Docno.Text) & "'", "I") '''for mca
            If TO_CHK_MCA_YN(GmoduleName) = True And gUserCategory = "U" Then
                sqlstring = "insert into authPending (Docdetail,Docdate,Storecode,Itemcode,TType) "
                sqlstring = sqlstring & "select Docdetails,Docdate,storecode,Itemcode,'DAMAGE' from STOCKDMGDETAIL where Docdetails='" & txt_Docno.Text & "'"
                gconnection.dataOperation(6, sqlstring, )
            End If
            ' End
        End If
        If GBATCHNO = "Y" Then
            Dim strsql As String
            strsql = "update temp_batchdetails set qty= qty*-1 WHERE STORECODE= '" & TXT_FROMSTORECODE.Text & "' "
            gconnection.getDataSet(strsql, "updateminusqty")
            strsql = "insert into inv_Batchdetails(trnno,itemcode,uom,storecode,trndate,QTY,ttype,batchno,rate,expirydate)"
            strsql = strsql & " select Trnno,itemcode,uom,storecode,Trndate,qty,ttype,batchno,rate,expirydate from temp_batchdetails where trnno= '" & txt_Docno.Text & "'"
            gconnection.dataOperation(6, strsql, )
            strsql = "delete from temp_batchdetails "
            gconnection.dataOperation(6, strsql, )
        End If
    End Sub
    Private Sub UpdateOperation()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim ITEMCODE As String
        Dim qty As Double
        Dim AMT As Double
        sqlstring = "select * from STOCKDMGHEADER WHERE docdetails='" + Trim(CStr(txt_Docno.Text)) + "' and cast(convert(varchar(11),Docdate,106)as datetime)='" & Format(Me.dtp_Docdate.Value, "dd/MMM/yyyy") & "'"
        gconnection.getDataSet(sqlstring, "backdate")
        If gdataset.Tables("backdate").Rows.Count > 0 Then
            docno = Split(Trim(txt_Docno.Text), "/")
            If gShortname = "RSAOI" Then
                ''TO CHECK MCA Y/N
                If TO_CHK_MCA_YN(GmoduleName) = True And (gUserCategory <> "S" And ModuleAdmin <> True) And Autherize = "Y" Then
                    MessageBox.Show("You don't Have rights to Update this Record, Super User/Module Admin Only can update this Record!.", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If

                If MCA <> "M" And Autherize <> "Y" Then
                    MessageBox.Show("You Can't' Update the Checked Records", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
                'End
            End If

            'FOR LOG DATA
            sqlstring = "INSERT INTO STOCKDMGHEADER_LOG(Docno,Docdetails,Docdate,Doctype,storecode,storedesc "
            sqlstring = sqlstring & ", Totalqty,Remarks,Void,Adduser,Adddate) "
            sqlstring = sqlstring & " SELECT Docno,Docdetails,Docdate,Doctype,storecode,storedesc "
            sqlstring = sqlstring & ", Totalqty,Remarks,Void,Adduser,Adddate FROM STOCKDMGHEADER WHERE Docdetails='" & Trim(txt_Docno.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOCKDMGHEADER_LOG")

            sqlstring = "INSERT INTO STOCKDMGDETAIL_LOG(Docno,Docdetails,Docdate,Doctype,storecode,storedesc,"
            sqlstring = sqlstring & " Itemcode,Itemname,Uom,DMGQty,BatchNo,ClosingQty,"
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "SHELF,"
            End If
            sqlstring = sqlstring & " Void,UPDATEuser,UPDATEtime,rate,amount)"
            sqlstring = sqlstring & " SELECT Docno,Docdetails,Docdate,Doctype,storecode,storedesc,"
            sqlstring = sqlstring & " Itemcode,Itemname,Uom,DMGQty,BatchNo,ClosingQty,"
            If GSHELVING = "Y" Then
                sqlstring = sqlstring & "SHELF,"
            End If
            sqlstring = sqlstring & " Void,UPDATEuser,UPDATEtime,rate,amount from STOCKDMGDETAIL WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
            gconnection.getDataSet(sqlstring, "STOCKDMGDETAIL_LOG")
            'LOG DATA ENDS 


            sqlstring = "UPDATE STOCKDMGHEADER SET Docdate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "', "
            sqlstring = sqlstring & " Doctype='" & Trim(doctype1) & "',"
            sqlstring = sqlstring & " Storecode='" & Trim(TXT_FROMSTORECODE.Text) & "',"
            sqlstring = sqlstring & " Storedesc='" & Trim(txt_FromStorename.Text) & "', "
            sqlstring = sqlstring & " TOTALQTY=" & Format(Val(txt_Totalqty.Text), "0.000") & ","
            sqlstring = sqlstring & " Remarks='" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,"
            sqlstring = sqlstring & " Void='N',Updateuser='" & Trim(gUsername) & "',"
            sqlstring = sqlstring & " Updatetime=getDate()"
            sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
            insert(0) = sqlstring
            sqlstring = "DELETE FROM STOCKDMGDETAIL WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
            '''******************************************************** INSERT INTO stockissuedetail ******************************************************'''
            docno = Split(Trim(txt_Docno.Text), "/")

            Dim SQL1 As String
            Dim SEQ1 As Double

            For i As Integer = 1 To AxfpSpread1.DataRowCnt
                AxfpSpread1.Row = i
                AxfpSpread1.Col = 1
                ITEMCODE = AxfpSpread1.Text

                'SQL1 = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
                'SQL1 = SQL1 & " and Trnno='" + txt_Docno.Text + "' and itemcode='" & ITEMCODE & "'"
                'gconnection.getDataSet(SQL1, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '    SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
                'End If

                sqlstring = "INSERT INTO STOCKDMGDETAIL(Docno,Docdetails,Docdate,Doctype,storecode,storedesc,"
                sqlstring = sqlstring & " Itemcode,Itemname,Uom,DMGQty,BatchNo,ClosingQty,"
                If GSHELVING = "Y" Then
                    sqlstring = sqlstring & "SHELF,"
                End If
                sqlstring = sqlstring & " Void,UPDATEuser,UPDATEtime,rate,amount)"
                sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"

                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 2
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 3
                sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                AxfpSpread1.Col = 4
                qty = Val(AxfpSpread1.Text)
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AxfpSpread1.Col = 5
                sqlstring = sqlstring & " '" & AxfpSpread1.Text & "',"
                AxfpSpread1.Col = 6
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                If GSHELVING = "Y" Then
                    AxfpSpread1.Col = 9
                    sqlstring = sqlstring & " '" & Trim(AxfpSpread1.Text) & "',"
                End If

                sqlstring = sqlstring & " 'N',"
                sqlstring = sqlstring & " '" & Trim(gUsername) & "',getDate(),"
                AxfpSpread1.Col = 7
                Dim rate As Double = Val(AxfpSpread1.Text)
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ","
                AMT = AMT + (rate * qty)
                AxfpSpread1.Col = 8
                sqlstring = sqlstring & " " & Format(Val(AxfpSpread1.Text), "0.000") & ")"

                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring

                'Dim qty1 As Double
                'Dim batchyn As String
                'Dim uom As String
                'Dim uom1 As String
                'Dim convvalue As Double
                'Dim batchno As String
                'AxfpSpread1.Col = 3
                'uom1 = AxfpSpread1.Text
                'AxfpSpread1.Col = 5
                'batchno = AxfpSpread1.Text

                'SQL1 = "select qty,batchyn,uom from closingqty where  itemcode='" + ITEMCODE + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
                'SQL1 = SQL1 & " and Trnno='" + txt_Docno.Text + "' "
                ''If (batchno <> "") Then
                ''    SQL1 = SQL1 & " and  batchno='" + batchno + "' "
                ''End If

                'gconnection.getDataSet(SQL1, "closingqty")
                'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                '    qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                '    batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                '    uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                '    Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                '    convvalue = gconnection.getvalue(sql)
                'Else
                '    qty1 = 0
                '    convvalue = 1
                'End If
                'SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + ",qty=-" + Format(Val(qty / convvalue), "0.000") + ""
                ''SQL1 = SQL1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + "*(closingvalue/closingstock))"
                ''SQL1 = SQL1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + "*(openningvalue/openningstock))"
                'SQL1 = SQL1 & "  where trns_seq=" & SEQ1.ToString() & " and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + ITEMCODE + "' "
                ''If (batchyn = "Y") Then
                ''    SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
                ''End If
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = SQL1

                'SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1) - (qty / convvalue)), "0.000") + ""
                '' SQL1 = SQL1 & ",closingvalue=closingvalue+(" + Format(Val(qty - qty1), "0.000") + "*(closingvalue/closingstock))"
                ''SQL1 = SQL1 & ",openningvalue=openningvalue+(" + Format(Val(qty - qty1), "0.000") + "*(openningvalue/openningstock))"
                'SQL1 = SQL1 & "  where trns_seq>" & SEQ1.ToString() & " and  and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + ITEMCODE + "' "
                ''If (batchyn = "Y") Then
                ''    SQL1 = SQL1 & "  and  batchno='" + txt_Docno.Text + "'"
                ''End If
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = SQL1
                'sqlstring = "    update ratelist set weightedrate=case when closingstock=0 then batchrate    Else closingvalue/closingstock end ,"
                'sqlstring = sqlstring & "  lastweightedrate="
                'sqlstring = sqlstring & "  case when openningvalue=0 then"
                'sqlstring = sqlstring & "      batchrate "
                'sqlstring = sqlstring & "   Else"
                'sqlstring = sqlstring & "  openningvalue/openningstock "
                'sqlstring = sqlstring & "     End"
                'sqlstring = sqlstring & "  from ratelist inner join CLOSINGQTY on ratelist.grnno=CLOSINGQTY.trnno where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "'"
                'sqlstring = sqlstring & "   and CLOSINGQTY.storecode='" + TXT_FROMSTORECODE.Text + "' and CLOSINGQTY.itemcode='" + ITEMCODE + "'"
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sqlstring

            Next
            'sqlstring = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
            'sqlstring = sqlstring & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
            'sqlstring = sqlstring & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
            'sqlstring = sqlstring & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
            'sqlstring = sqlstring & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
            'sqlstring = sqlstring & " from inv_Inventoryuomstorelink a inner join closingqty b"
            'sqlstring = sqlstring & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
            'ReDim Preserve insert(insert.Length)
            'insert(insert.Length - 1) = sqlstring

            If GACCPOST.ToUpper() = "Y" Then

                'sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" + Trim(txt_Docno.Text) + "' AND  VoucherType='DAMAGE'"
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sqlstring

                'Dim damGLCODE, DAMGLDESC, ACCOUNTCODE, ACCOUNTDESC, damcccode, damccdesc, costcentercode, costcenterdesc As String
                'Dim decription As String
                'Dim amount As Double
                'If gAcPostingWise = "ITEM" Then
                '    For k As Integer = 1 To AxfpSpread1.DataRowCnt

                '        AxfpSpread1.Row = k

                '        AxfpSpread1.Col = 8
                '        amount = Val(AxfpSpread1.Text)
                '        AMT = amount
                '        AxfpSpread1.Col = 1
                '        If Trim(AxfpSpread1.Text) <> "" Then
                '            sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                '            gconnection.getDataSet(sqlstring, "SLCODE1")
                '            If gdataset.Tables("SLCODE1").Rows.Count > 0 Then

                '                damGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("damGLCODE")
                '                DAMGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("DAMGLDESC")
                '                ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
                '                ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
                '                damcccode = gdataset.Tables("SLCODE1").Rows(0).Item("damcccode")
                '                damccdesc = gdataset.Tables("SLCODE1").Rows(0).Item("damccdesc")
                '                costcentercode = gdataset.Tables("SLCODE1").Rows(0).Item("costcentercode")
                '                costcenterdesc = gdataset.Tables("SLCODE1").Rows(0).Item("costcenterdesc")
                '            Else
                '                MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                '                Exit Sub
                '            End If
                '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                '            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                '            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                '            sqlstring = sqlstring & "'', 'DAMAGE', '" & damGLCODE & "',"
                '            sqlstring = sqlstring & "'" & DAMGLDESC & "',"
                '            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                '            sqlstring = sqlstring & "'" & damcccode & "','" & damccdesc & "',"
                '            sqlstring = sqlstring & "'DEBIT',"
                '            'AMT = Format(Val(txt_Billamount.Text), "0.000")
                '            decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                '            sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

                '            'slcode = txt_Storecode.Text
                '            sqlstring = sqlstring & "'N','" + gUsername + "')"
                '            ReDim Preserve insert(insert.Length)
                '            insert(insert.Length - 1) = sqlstring


                '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                '            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                '            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                '            sqlstring = sqlstring & "'', 'DAMAGE', '" & ACCOUNTCODE & "',"
                '            sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                '            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                '            sqlstring = sqlstring & "'" & costcentercode & "','" & costcenterdesc & "',"
                '            sqlstring = sqlstring & "'CREDIT',"
                '            'amt = Format(Val(txt_Billamount.Text), "0.000")
                '            decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                '            sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

                '            'slcode = txt_Storecode.Text
                '            sqlstring = sqlstring & "'N','" + gUsername + "')"
                '            ReDim Preserve insert(insert.Length)
                '            insert(insert.Length - 1) = sqlstring
                '        End If
                '    Next
                'ElseIf gAcPostingWise = "CATEGORY" Then
                '    For k As Integer = 1 To AxfpSpread1.DataRowCnt

                '        AxfpSpread1.Row = k

                '        AxfpSpread1.Col = 8
                '        amount = Val(AxfpSpread1.Text)
                '        AMT = amount
                '        AxfpSpread1.Col = 1
                '        If Trim(AxfpSpread1.Text) <> "" Then
                '            sqlstring = "select * from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category AND IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
                '            gconnection.getDataSet(sqlstring, "SLCODE1")
                '            If gdataset.Tables("SLCODE1").Rows.Count > 0 Then

                '                damGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("damGLCODE")
                '                DAMGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("DAMGLDESC")
                '                ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
                '                ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
                '                damcccode = gdataset.Tables("SLCODE1").Rows(0).Item("damcccode")
                '                damccdesc = gdataset.Tables("SLCODE1").Rows(0).Item("damccdesc")
                '                costcentercode = gdataset.Tables("SLCODE1").Rows(0).Item("costcentercode")
                '                costcenterdesc = gdataset.Tables("SLCODE1").Rows(0).Item("costcenterdesc")
                '            Else
                '                MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                '                Exit Sub
                '            End If
                '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                '            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                '            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                '            sqlstring = sqlstring & "'', 'DAMAGE', '" & damGLCODE & "',"
                '            sqlstring = sqlstring & "'" & DAMGLDESC & "',"
                '            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                '            sqlstring = sqlstring & "'" & damcccode & "','" & damccdesc & "',"
                '            sqlstring = sqlstring & "'DEBIT',"
                '            'AMT = Format(Val(txt_Billamount.Text), "0.000")
                '            decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                '            sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

                '            'slcode = txt_Storecode.Text
                '            sqlstring = sqlstring & "'N','" + gUsername + "')"
                '            ReDim Preserve insert(insert.Length)
                '            insert(insert.Length - 1) = sqlstring


                '            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                '            sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                '            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                '            sqlstring = sqlstring & "'', 'DAMAGE', '" & ACCOUNTCODE & "',"
                '            sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                '            sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                '            sqlstring = sqlstring & "'" & costcentercode & "','" & costcenterdesc & "',"
                '            sqlstring = sqlstring & "'CREDIT',"
                '            'amt = Format(Val(txt_Billamount.Text), "0.000")
                '            decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                '            sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

                '            'slcode = txt_Storecode.Text
                '            sqlstring = sqlstring & "'N','" + gUsername + "')"
                '            ReDim Preserve insert(insert.Length)
                '            insert(insert.Length - 1) = sqlstring
                '        End If

                '    Next
                'Else

                '    sqlstring = "select damGLCODE, DAMGLDESC,ACCOUNTCODE,ACCOUNTDESC,damcccode,damccdesc,costcentercode,costcenterdesc from ACCOUNTSTAGGINGNEW  WHERE "
                '    sqlstring = sqlstring & "CODE='" & TXT_FROMSTORECODE.Text & "' AND DESCRIPTION='" & txt_FromStorename.Text & "' AND  isnull(VOID,'')<>'Y'"
                '    gconnection.getDataSet(sqlstring, "SLCODE1")

                '    If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
                '        damGLCODE = gdataset.Tables("SLCODE1").Rows(0).Item("damGLCODE")
                '        DAMGLDESC = gdataset.Tables("SLCODE1").Rows(0).Item("DAMGLDESC")
                '        ACCOUNTCODE = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTCODE")
                '        ACCOUNTDESC = gdataset.Tables("SLCODE1").Rows(0).Item("ACCOUNTDESC")
                '        damcccode = gdataset.Tables("SLCODE1").Rows(0).Item("damcccode")
                '        damccdesc = gdataset.Tables("SLCODE1").Rows(0).Item("damccdesc")
                '        costcentercode = gdataset.Tables("SLCODE1").Rows(0).Item("costcentercode")
                '        costcenterdesc = gdataset.Tables("SLCODE1").Rows(0).Item("costcenterdesc")

                '    Else
                '        MessageBox.Show("CREATE GLCODE & SLCODE FOR CONSUMPTION IN ACCOUNTSTAGGING ...")
                '        Exit Sub
                '    End If
                '    If damGLCODE = "" Then

                '        MessageBox.Show("NO GL FOUND FOR DAMAGE POSTING...")
                '        'check = False

                '        Exit Sub

                '    End If

                '    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                '    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                '    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                '    sqlstring = sqlstring & "'', 'DAMAGE', '" & damGLCODE & "',"
                '    sqlstring = sqlstring & "'" & DAMGLDESC & "',"
                '    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                '    sqlstring = sqlstring & "'" & damcccode & "','" & damccdesc & "',"
                '    sqlstring = sqlstring & "'DEBIT',"
                '    'AMT = Format(Val(txt_Billamount.Text), "0.000")
                '    decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                '    sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

                '    'slcode = txt_Storecode.Text
                '    sqlstring = sqlstring & "'N','" + gUsername + "')"
                '    ReDim Preserve insert(insert.Length)
                '    insert(insert.Length - 1) = sqlstring


                '    sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
                '    sqlstring = sqlstring & " AccountcodeDesc,slcode,sldesc,costcentercode,costcenterdesc, CreditDebit, Amount,DESCRIPTION, VOID,AdduserId)"
                '    sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy ") & "', "
                '    sqlstring = sqlstring & "'', 'DAMAGE', '" & ACCOUNTCODE & "',"
                '    sqlstring = sqlstring & "'" & ACCOUNTDESC & "',"
                '    sqlstring = sqlstring & "'" & TXT_FROMSTORECODE.Text & "','" & txt_FromStorename.Text & "',"
                '    sqlstring = sqlstring & "'" & costcentercode & "','" & costcenterdesc & "',"
                '    sqlstring = sqlstring & "'CREDIT',"
                '    'amt = Format(Val(txt_Billamount.Text), "0.000")
                '    decription = "Damage bill no " + txt_Docno.Text + " date " + dtp_Docdate.Text + ""
                '    sqlstring = sqlstring & "'" & AMT & "','" & decription & "',"

                '    'slcode = txt_Storecode.Text
                '    sqlstring = sqlstring & "'N','" + gUsername + "')"
                '    ReDim Preserve insert(insert.Length)
                '    insert(insert.Length - 1) = sqlstring
                'End If





            End If




            gconnection.MoreTrans(insert)
            If gShortname = "RSAOI" Then
                ' For Maker / Checker By Sri
                If TO_CHK_MCA_YN(GmoduleName) = True And (gUserCategory <> "S" And ModuleAdmin <> True) And Autherize = "N" Then
                    MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'clearoperation()
                    Exit Sub
                End If
                ' End
            End If
        Else
            voidoperationupdate()
            addoperation()
        End If
    End Sub

    Private Sub voidoperationupdate()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim i As Integer

        'Dim SEQ1 As Double
        'sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        'sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
        'gconnection.getDataSet(sqlstring, "closingqty")
        'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '    SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        'End If

        docno = Split(Trim(txt_Docno.Text), "/")
        'sqlstring = "UPDATE STOCKDMGHEADER SET "
        'sqlstring = sqlstring & " Void='Y' "
        'sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        sqlstring = "delete from STOCKDMGHEADER  WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        insert(0) = sqlstring

        If GACCPOST.ToUpper() = "Y" Then
            sqlstring = "delete from JOURNALENTRY  WHERE VoucherNo='" & Trim(txt_Docno.Text) & "' AND  VoucherType='DAMAGE'"
            'sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
        End If
        sqlstring = "delete from STOCKDMGDETAIL  WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
        'sqlstring = "UPDATE  STOCKDMGDETAIL set Void='Y' WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring
        sqlstring = "delete from closingqty  WHERE trnno='" & Trim(txt_Docno.Text) & "' "
        'sqlstring = "UPDATE  STOCKDMGDETAIL set Void='Y' WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring
        'For i = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = i
        '    Dim qty1 As Double
        '    Dim batchyn As String
        '    Dim uom As String
        '    Dim rate As Double
        '    Dim uom1 As String
        '    Dim itemcode As String
        '    AxfpSpread1.Col = 1
        '    itemcode = AxfpSpread1.Text
        '    Dim convvalue As Double
        '    Dim batchno As String
        '    Dim sql1 As String
        '    AxfpSpread1.Row = i
        '    AxfpSpread1.Col = 5
        '    batchno = AxfpSpread1.Text
        '    AxfpSpread1.Col = 3
        '    uom1 = AxfpSpread1.Text
        '    AxfpSpread1.Col = 6
        '    rate = Val(AxfpSpread1.Text)
        '    sql1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
        '    sql1 = sql1 & " and Trnno='" + txt_Docno.Text + "' "
        '    If batchno <> "" Then
        '        sql1 = sql1 & " and batchno='" + batchno + "'"
        '    End If
        '    gconnection.getDataSet(sql1, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '        uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
        '        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
        '        convvalue = gconnection.getvalue(sql)
        '    Else
        '        qty1 = 0
        '        convvalue = 1
        '    End If
        '    sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + ",qty=0,closingvalue=closingvalue+" + Format(Val(-(qty1) * rate), "0.000") + ""
        '    'sql1 = sql1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
        '    sql1 = sql1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
        '    sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    If (batchyn = "Y") Then
        '        sql1 = sql1 & "  and  batchno='" + batchno + "'"
        '    End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = sql1

        '    sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1)), "0.000") + ""
        '    sql1 = sql1 & ",closingvalue=closingvalue+(" + Format(Val(-qty1), "0.000") + "*(closingvalue/closingstock))"
        '    sql1 = sql1 & ",openningvalue=openningvalue+(" + Format(Val(-qty1), "0.000") + "*(openningvalue/openningstock))"
        '    sql1 = sql1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    If (batchyn = "Y") Then
        '        sql1 = sql1 & "  and  batchno='" + batchno + "'"
        '    End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = sql1
        'Next i
        'sqlstring = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
        'sqlstring = sqlstring & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
        'sqlstring = sqlstring & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
        'sqlstring = sqlstring & " from inv_Inventoryuomstorelink a inner join closingqty b"
        'sqlstring = sqlstring & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
        'ReDim Preserve insert(insert.Length)
        'insert(insert.Length - 1) = sqlstring

        gconnection.MoreTrans1(insert)
        'For k As Integer = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = k
        '    AxfpSpread1.Col = 1
        '    gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, SEQ1)

        'Next
    End Sub


    Private Sub voidoperation()
        Dim insert(0) As String
        Dim docno(0) As String
        Dim i As Integer

        'Dim SEQ1 As Double
        'sqlstring = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        'sqlstring = sqlstring & " and Trnno='" + txt_Docno.Text + "' "
        'gconnection.getDataSet(sqlstring, "closingqty")
        'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '    SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        'End If

        docno = Split(Trim(txt_Docno.Text), "/")
        sqlstring = "UPDATE STOCKDMGHEADER SET "
        sqlstring = sqlstring & " Void='Y' "
        sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
        insert(0) = sqlstring

        If GACCPOST.ToUpper() = "Y" Then
            sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "' AND VoucherType='DAMAGE'  "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
        End If

        sqlstring = "UPDATE  STOCKDMGDETAIL set Void='Y' WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
        ReDim Preserve insert(insert.Length)
        insert(insert.Length - 1) = sqlstring
        'For i = 1 To AxfpSpread1.DataRowCnt
        '    AxfpSpread1.Row = i
        '    Dim qty1 As Double
        '    Dim batchyn As String
        '    Dim uom As String
        '    Dim rate As Double
        '    Dim uom1 As String
        '    Dim itemcode As String
        '    AxfpSpread1.Col = 1
        '    itemcode = AxfpSpread1.Text
        '    Dim convvalue As Double
        '    Dim batchno As String
        '    Dim sql1 As String
        '    AxfpSpread1.Row = i
        '    AxfpSpread1.Col = 5
        '    batchno = AxfpSpread1.Text
        '    AxfpSpread1.Col = 3
        '    uom1 = AxfpSpread1.Text
        '    AxfpSpread1.Col = 6
        '    rate = Val(AxfpSpread1.Text)
        '    SQL1 = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "' "
        '    SQL1 = SQL1 & " and Trnno='" + txt_Docno.Text + "' "
        '    If batchno <> "" Then
        '        SQL1 = SQL1 & " and batchno='" + batchno + "'"
        '    End If
        '    gconnection.getDataSet(SQL1, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
        '        batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
        '        uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
        '        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
        '        convvalue = gconnection.getvalue(sql)
        '    Else
        '        qty1 = 0
        '        convvalue = 1
        '    End If
        '    sql1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + ",qty=0,closingvalue=closingvalue+" + Format(Val(-(qty1) * rate), "0.000") + ""
        '    'sql1 = sql1 & ",closingvalue=closingvalue+(" + Format(Val(-(qty1)), "0.000") + "*(closingvalue/closingstock))"
        '    'sql1 = sql1 & ",openningvalue=openningvalue+(" + Format(Val(-(qty1)), "0.000") + "*(openningvalue/openningstock))"
        '    sql1 = sql1 & "  where trndate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and trnno='" + txt_Docno.Text + "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    'If (batchyn = "Y") Then
        '    '    SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
        '    'End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = SQL1

        '    SQL1 = "update closingqty set closingstock= closingstock +" + Format(Val(-(qty1)), "0.000") + " ,openningstock=openningstock+" + Format(Val(-(qty1)), "0.000") + ""
        '    sql1 = sql1 & ",closingvalue=closingvalue+(" + Format(Val(-qty1), "0.000") + "*(closingvalue/closingstock))"
        '    sql1 = sql1 & ",openningvalue=openningvalue+(" + Format(Val(-qty1), "0.000") + "*(openningvalue/openningstock))"
        '    SQL1 = SQL1 & "  where trndate>'" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "' "
        '    'If (batchyn = "Y") Then
        '    '    SQL1 = SQL1 & "  and  batchno='" + batchno + "'"
        '    'End If
        '    ReDim Preserve insert(insert.Length)
        '    insert(insert.Length - 1) = SQL1
        'Next i
        'sqlstring = "   update closingqty  set openningstock= round(openningstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2) ,"
        'sqlstring = sqlstring & " closingstock=round(closingstock*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & "  where BASEUOM=a.reportuom and TRANSUOM=b.UOM)),2),"
        'sqlstring = sqlstring & "uom=a.reportUOM,qty=round(qty*(1/(select convvalue from INVENTORY_TRANSCONVERSION"
        'sqlstring = sqlstring & " where BASEUOM=a.reportuom and TRANSUOM=b.uom)),2)"
        'sqlstring = sqlstring & " from inv_Inventoryuomstorelink a inner join closingqty b"
        'sqlstring = sqlstring & " on a.itemcode=b.itemcode and a.storecode=b.storecode and b.Trnno='" + txt_Docno.Text + "'"
        'ReDim Preserve insert(insert.Length)
        'insert(insert.Length - 1) = sqlstring

        gconnection.MoreTrans(insert)
        'For k As Integer = 1 To AxfpSpread1.DataRowCnt
        '    Dim sql1 As String
        '    AxfpSpread1.Row = k
        '    AxfpSpread1.Col = 1
        '    SQL1 = "select TRNS_SEQ FROM CLOSINGQTY where  storecode='" + TXT_FROMSTORECODE.Text + "' "
        '    SQL1 = SQL1 & " and Trnno='" + txt_Docno.Text + "' and itemcode='" & AxfpSpread1.Text & "'"
        '    gconnection.getDataSet(SQL1, "closingqty")
        '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then
        '        SEQ1 = gdataset.Tables("closingqty").Rows(0).Item("TRNS_SEQ")
        '    End If
        '    gconnection.CalStockValue(TXT_FROMSTORECODE.Text, AxfpSpread1.Text, SEQ1)

        'Next

        If GBATCHNO = "Y" Then
            Dim strsql As String
            strsql = "delete from inv_Batchdetails where trnno= '" & Trim(txt_Docno.Text) & "'  "
            gconnection.dataOperation(6, strsql, )
        End If
    End Sub

    Private Sub Clearoperation()
        TXT_FROMSTORECODE.Text = ""
        txt_FromStorename.Text = ""
        AxfpSpread1.ClearRange(1, 1, -1, -1, True)
        txt_Remarks.Text = ""
        txt_Totalamt.Text = ""
        autogenerate()
        txt_Totalqty.Text = ""
        Me.lbl_Freeze.Text = ""

        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True

        Me.dtp_Docdate.Value = Format(Now, "dd/MMM/yyyy")
        Cmd_Add.Text = "ADD[F7]"
        For k As Integer = 0 To 10
            For m As Integer = 0 To AxfpSpread1.TypeComboBoxCount
                AxfpSpread1.TypeComboBoxClear(3, k)
            Next
        Next
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True
        If GBATCHNO = "Y" Then
            Dim STRSQL As String
            STRSQL = "delete from temp_batchdetails "
            gconnection.dataOperation(6, STRSQL, )
        End If
        If gShortname = "RSAOI" Then
            '========================# IM POLICY CODE START #===========================
            Autherize = ""
            MCA = ""
            '========================# IM POLICY CODE END #===========================
        End If
    End Sub


    Private Sub cmd_Docnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Docnohelp.Click
        Try
            gSQLString = "SELECT docdetails,docdate FROM STOCKDMGHEADER"
            ' M_WhereCondition = " where docdetails like '%DMG%' "
            M_WhereCondition = ""
            M_ORDERBY = "order by DOCDETAILS desc,Autoid desc"
            Dim vform As New List_Operation
            vform.Field = "DOCDETAILS,DOCDATE"
            vform.vFormatstring1 = "       DOC NO                       |         DOC DATE                                                           "
            vform.vCaption = "STOCK IN HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Docno.Text = Trim(vform.keyfield & "")
                AxfpSpread1.ClearRange(1, 1, -1, -1, True)
                Call txt_Docno_Validated(txt_Docno, e)
                Grid_lock()
                AxfpSpread1.SetActiveCell(4, 1)
            End If

            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub


    Private Function Grid_lock()
        Dim i, j As Integer
        For i = 1 To 100
            AxfpSpread1.Row = i
            For j = 1 To AxfpSpread1.MaxCols

                If j = 4 Then
                    AxfpSpread1.Col = j
                    AxfpSpread1.Lock = False
                Else
                    AxfpSpread1.Col = j
                    AxfpSpread1.Lock = True
                End If
            Next
        Next
    End Function

    Private Sub txt_Docno_Validated(sender As Object, e As EventArgs) Handles txt_Docno.Validated
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, STRITEMCODE, STRITEMUOM, remarks As String
        Dim vTypeseqno, vGroupseqno, Clsquantity As Double
        Dim varqty As Double
        Me.txt_Totalqty.Text = 0
        varqty = 0
        If Trim(txt_Docno.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,"
                If gShortname = "RSAOI" Then
                    sqlstring = sqlstring & " isnull(authorised,'') as authorised,isnull(MCA,'') as MCA,"
                End If
                sqlstring = sqlstring & " ISNULL(H.STORECODE,'') AS FROMSTORECODE,ISNULL(H.STOREDESC,'') AS FROMSTOREDESC,"
                sqlstring = sqlstring & " ISNULL(H.TOTALQTY,0) AS TOTALQTY,"
                sqlstring = sqlstring & " ISNULL(H.REMARKS,'') AS REMARKS,ISNULL(H.VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE ,"
                sqlstring = sqlstring & " UPDATETIME  FROM STOCKDMGHEADER AS H WHERE DOCNO='" & Trim(txt_Docno.Text) & "'OR DOCDETAILS='" & Trim(txt_Docno.Text) & "'"
                gconnection.getDataSet(sqlstring, "stocktransferheader")
                '''************************************************* SELECT RECORD FROM STOCKTRANSFERHEADER *********************************************''''                
                If gdataset.Tables("stocktransferheader").Rows.Count > 0 Then
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Docno.ReadOnly = True
                    txt_Docno.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("DOCDETAILS"))
                    dtp_Docdate.Value = Format(CDate(gdataset.Tables("stocktransferheader").Rows(0).Item("DOCDATE")), "dd/MMM/yyyy")
                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("FROMSTORECODE"))
                    ' cbo_Fromstore.DropDownStyle = ComboBoxStyle.DropDown
                    ' cbo_Fromstore.Enabled = False
                    txt_FromStorename.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("FROMSTOREDESC"))
                    If gShortname = "RSAOI" Then
                        Autherize = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("Authorised") & "")
                        MCA = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("MCA") & "")
                    End If
                    'txt_FromStorename.DropDownStyle = ComboBoxStyle.DropDownList
                    '''txt_storecode.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("STORECODE"))
                    ' cbo_Tostore.DropDownStyle = ComboBoxStyle.DropDown
                    ' cbo_Tostore.Enabled = False
                    '''txt_storeDesc.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("STOREDESC"))
                    ' cbo_Tostore.DropDownStyle = ComboBoxStyle.DropDownList
                    txt_Totalqty.Text = Format(Val(gdataset.Tables("stocktransferheader").Rows(0).Item("TOTALQTY")), "0.000")
                    remarks = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("REMARKS"))
                    txt_Remarks.Text = Replace(remarks, "?", "'")
                    ''''********************************* 
                    sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                    gconnection.getDataSet(sqlstring, "STOREMASTER1")
                    If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                        doctype1 = ""
                        'If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
                        'doctype1 = "RET"
                        'lbl_Heading.Text = "STOCK RETURN"
                        'Else
                        doctype1 = "DMG"
                        'lbl_Heading.Text = "STOCK TRANSFER"
                        'End If
                    End If
                    If Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("VOID") & "") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("stocktransferheader").Rows(0).Item("adddate")), "dd/MMM/yyyy")
                        Me.Cmd_Add.Enabled = False
                        Me.Cmd_Freeze.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        'Me.Button2.Enabled = True
                        Me.lbl_Freeze.Text = "Record Void  On "
                        'Me.Button2.Text = "Void[F8]"
                        Me.Cmd_Add.Enabled = True
                        Me.Cmd_Freeze.Enabled = True
                    End If
                    '''************************************************* SELECT RECORD FROM STOCKTRANSFERDETAISL *********************************************''''                
                    sqlstring = "SELECT ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,D.DOCDATE AS DOCDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE, "
                    sqlstring = sqlstring & " ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM,"
                    'If Trim(UCase(gShortname)) = "CGC" Then
                    '    sqlstring = sqlstring & "ISNULL(QTY,0) AS QTY,ISNULL(D.BATCHNO,'') AS BATCHNO,ISNULL(D.CLOSINGQTY,0) AS CLOSINGQTY,"
                    'Else
                    '    sqlstring = sqlstring & "ISNULL(DMGQTY,0) AS QTY,ISNULL(D.BATCHNO,'') AS BATCHNO,ISNULL(D.CLOSINGQTY,0) AS CLOSINGQTY,"
                    'End If
                    sqlstring = sqlstring & "ISNULL(DMGQTY,0) AS QTY,ISNULL(D.BATCHNO,'') AS BATCHNO,ISNULL(D.CLOSINGQTY,0) AS CLOSINGQTY,"
                    If GSHELVING = "Y" Then
                        sqlstring = sqlstring & "isnull(d.SHELF,'') as Shelf,"
                    End If
                    sqlstring = sqlstring & "isnull(rate,0) as rate,isnull(amount,0) as amount "
                    sqlstring = sqlstring & " FROM STOCKDMGDETAIL AS D WHERE  DOCDETAILS ='" & Trim(txt_Docno.Text) & "' ORDER BY AUTOID"
                    gconnection.getDataSet(sqlstring, "stocktransferdetail")
                    If gdataset.Tables("stocktransferdetail").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("stocktransferdetail").Rows.Count
                            'Call GridUOM(i) '''--> Fill UOM in ssgrid
                            AxfpSpread1.SetText(1, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMCODE")))
                            STRITEMCODE = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMCODE"))
                            AxfpSpread1.SetText(2, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMNAME")))
                            AxfpSpread1.Col = 3
                            AxfpSpread1.Row = i
                            Dim sql As String = "select distinct tranuom from INVITEM_TRANSUOM_LINK where itemcode='" + gdataset.Tables("stocktransferdetail").Rows(j).Item("itemcode") + "'"

                            gconnection.getDataSet(sql, "INVITEM_TRANSUOM_LINK")
                            For Z As Integer = 0 To gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows.Count - 1

                                AxfpSpread1.TypeComboBoxString = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                                AxfpSpread1.Text = Trim(gdataset.Tables("INVITEM_TRANSUOM_LINK").Rows(Z).Item("tranuom"))
                            Next Z


                            AxfpSpread1.Text = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("UOM"))
                            'ssgrid.Text = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("UOM"))
                            STRITEMUOM = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("UOM"))
                            AxfpSpread1.SetText(4, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("QTY")), "0.000"))
                            'ssgrid.SetText(12, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("QTY")), "0.000"))

                            AxfpSpread1.SetText(5, i, Format(gdataset.Tables("stocktransferdetail").Rows(j).Item("BATCHNO"), ""))
                            AxfpSpread1.SetText(6, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("CLOSINGQTY")), "0.000"))
                            '                         ssgrid.SetText(7, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("DBLAMT")), "0.000"))
                            '                        ssgrid.SetText(8, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("DBLCONV")) & "")
                            '                       ssgrid.SetText(9, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("HIGHRATIO")), "0.000"))
                            If GSHELVING = "Y" Then
                                AxfpSpread1.Col = 9
                                AxfpSpread1.Row = i
                                AxfpSpread1.SetText(9, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("SHELF")))
                            End If

                            AxfpSpread1.SetText(7, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("rate")), "0.000"))
                            AxfpSpread1.SetText(8, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("amount")), "0.000"))

                            '  Dim TRFDATE As Date
                            ' TRFDATE = Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy")

                            '                      Clsquantity = ClosingQuantity_Date(STRITEMCODE, Trim(TXT_FROMSTORECODE.Text), STRITEMUOM, TRFDATE)

                            'Clsquantity = ClosingQuantity(STRITEMCODE, Trim(txt_fromstorecode.Text))
                            ' Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMCODE") & "' ,'" & Trim(TXT_FROMSTORECODE.Text) & "','" & STRITEMUOM & "')"
                            'Dim cls As Double = gconnection.getvalue(SQL)

                            'AxfpSpread1.SetText(9, i, cls)
                            varqty = varqty + Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("QTY")), "0.000")
                            j = j + 1
                        Next
                        Me.txt_Totalqty.Text = Format(varqty, "0.000")
                    End If
                    If gUserCategory <> "S" Then
                        '  Call GetRights()
                    End If
                    'TotalCount = gdataset.Tables("stocktransferdetail").Rows.Count
                    AxfpSpread1.SetActiveCell(1, 1)
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub ButOK_Click(sender As Object, e As EventArgs) Handles ButOK.Click
        Dim SQL As String
        Dim qty As Double
        Dim K As Integer
        Dim col2 As Integer
        Dim row As Integer
        Dim itemcode As String
        Dim batchqty, totbatchqty As Double
        Dim INDQTY As Double
        Dim m As Double = 1
        Dim uom As String
        Dim uom1 As String
        Dim convvalue As Double
        K = AxfpSpread1.ActiveRow
        If AxfpSpread2.DataRowCnt >= 1 Then
            AxfpSpread2.Col = 1
            itemcode = AxfpSpread2.Text

            For l As Integer = 1 To AxfpSpread2.DataRowCnt
                AxfpSpread2.Row = l
                AxfpSpread2.Col = 5
                batchqty = Val(AxfpSpread2.Text)
                row = l
                AxfpSpread2.Col = 4
                uom = AxfpSpread2.Text
                AxfpSpread1.Col = 3
                uom1 = AxfpSpread1.Text
                Sql = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                gconnection.getDataSet(Sql, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = Val(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
                Else
                    convvalue = 1
                End If
                If (batchqty <> 0) Then
                    If (m = 1) Then
                        AxfpSpread2.Row = l
                        AxfpSpread1.SetText(4, K, batchqty * convvalue)
                        AxfpSpread2.Col = 2
                        AxfpSpread1.SetText(5, K, AxfpSpread2.Text)
                        AxfpSpread2.Col = 3
                        AxfpSpread1.SetText(6, K, AxfpSpread2.Text)
                        ' If (GINDENTNO = "Y") Then
                        '    AxfpSpread1.Col = 4
                        '    INDQTY = Val(AxfpSpread1.Text)
                        '    AxfpSpread1.SetText(4, K, batchqty * convvalue)
                        'End If
                    Else
                        AxfpSpread1.InsertRows(K + m, 1)
                        SQL = " select I.itemcode,Itemname,uom,batchprocess from  inv_InventoryOpenningstock  I inner join INV_InventoryItemMaster M on "
                        SQL = SQL & " I.itemcode=M.itemcode  where M.Category  in (select categorycode from categoryuserdetail where usercode='" + gUsername + "') and isnull(M.void,'')='N' and isnull(I.storecode,'')='" + TXT_FROMSTORECODE.Text + "' and isnull(I.itemcode,'')='" + Trim(itemcode) + "'"
                        gconnection.getDataSet(SQL, "inv_InventoryOpenningstock")
                        If (gdataset.Tables("inv_InventoryOpenningstock").Rows.Count > 0) Then

                            AxfpSpread1.SetText(1, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("itemcode")))
                            AxfpSpread1.SetText(2, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("Itemname")))
                            AxfpSpread1.SetText(3, K + m - 1, Trim(gdataset.Tables("inv_InventoryOpenningstock").Rows(0).Item("uom")))
                            AxfpSpread2.Row = l
                            AxfpSpread1.SetText(4, K + m - 1, batchqty * convvalue)
                            AxfpSpread2.Col = 2
                            AxfpSpread1.SetText(5, K + m - 1, AxfpSpread2.Text)
                            AxfpSpread2.Col = 3
                            AxfpSpread1.SetText(6, K + m - 1, AxfpSpread2.Text)

                            '     AxfpSpread2.Col = 5
                            '    AxfpSpread1.SetText(7, K, AxfpSpread2.Text)
                            'If (GINDENTNO = "Y") Then
                            '    If (batchqty * convvalue < INDQTY - totbatchqty) Then
                            '        AxfpSpread1.SetText(4, K + m - 1, batchqty * convvalue)

                            '    Else
                            '        AxfpSpread1.SetText(4, K + m - 1, INDQTY - totbatchqty)

                            '    End If
                            'End If
                        End If

                    End If
                    m = m + 1
                    totbatchqty = totbatchqty + (batchqty * convvalue)
                    AxfpSpread1.SetActiveCell(1, K + m - 1)
                    '  Calculate()
                End If

            Next
        End If
        For i As Integer = 0 To AxfpSpread2.DataRowCnt
            AxfpSpread2.Col = 5
            qty += Val(AxfpSpread2.Text)

        Next
        GroupBox3.Visible = False

    End Sub

    Private Sub ButCANCEL_Click(sender As Object, e As EventArgs) Handles ButCANCEL.Click
        GroupBox3.Visible = False

    End Sub

    Private Sub AxfpSpread2_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles AxfpSpread2.KeyDownEvent
        If (e.keyCode = Keys.Enter) Then
            If AxfpSpread2.ActiveCol = 5 Then
                AxfpSpread2.Row = AxfpSpread2.ActiveRow
                AxfpSpread2.Col = 5
                Dim batchqty As Double = Val(AxfpSpread2.Text)
                AxfpSpread2.Col = 3
                Dim clsqty As Double = Val(AxfpSpread2.Text)
                If (batchqty > clsqty) Then
                    MessageBox.Show("Damage Quantity Must be Less Than Closing Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    AxfpSpread2.SetText(5, AxfpSpread2.ActiveRow, "0.000")
                    AxfpSpread2.SetActiveCell(5, AxfpSpread2.ActiveRow)

                End If
                'If (indentqty < batchqty) Then
                '    MessageBox.Show("Issued Quantity Must be Less Than indent Quantity ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                '    AxfpSpread2.SetActiveCell(5, AxfpSpread2.ActiveRow)
                'Else

                'End If
                AxfpSpread2.SetActiveCell(5, AxfpSpread2.ActiveRow + 1)
            Else
                AxfpSpread2.SetActiveCell(5, AxfpSpread2.ActiveRow + 1)
            End If

        End If

    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Clearoperation()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
    End Sub
    Private Function validateoninsert() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
        'Else
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
        'End If

        Dim bdate1 As String
        Dim sql1 As String

        sql1 = "select convert(varchar(11),bdate,106) as bdate1 from Businessdate"
        gconnection.getDataSet(sql1, "Businessdate")

        If (gdataset.Tables("Businessdate").Rows.Count > 0) Then
            bdate1 = "Your current Business date is " & gdataset.Tables("Businessdate").Rows(0).Item("bdate1").ToString
        End If

        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
        If checkBdate = True And RESU1 = False Then
            MsgBox(bdate1)
            flag = True
            Return flag
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
            flag = True
            Return flag
        End If

        If DateDiff(DateInterval.Day, (CDate(dtp_Docdate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("Doc. Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If

        If txt_Docno.Text = "" Then
            MessageBox.Show("Please Fill IssueDocno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag


        End If
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If
        For j As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            Dim sql As String
            Dim uom1 As String
            Dim dMGqty As Double
            AxfpSpread1.Col = 4
            If (Val(AxfpSpread1.Text) <> 0) Then
                dMGqty = Val(AxfpSpread1.Text)
                AxfpSpread1.Col = 1
                Dim itemcode As String = AxfpSpread1.Text
                sql = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
                gconnection.getDataSet(sql, "INV_InventoryItemMaster")
                If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
                    If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
                        AxfpSpread1.Col = 3
                        Dim uom As String = AxfpSpread1.Text
                        Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


                        gconnection.getDataSet(sql11, "closingtable")
                        Dim closingqty As Double
                        If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                            closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")
                            uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
                        Else
                            closingqty = 0
                            uom1 = uom
                        End If

                        sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
                        gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                        Dim convvalue As Double
                        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                            convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                        Else
                            MessageBox.Show("Please create Conversion Factor For " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                            flag = True
                            Return flag
                            '                            convvalue = 0
                        End If
                        closingqty = closingqty * convvalue
                        If (dMGqty > closingqty) Then
                            MessageBox.Show("Damage Quantity Cannot be Greater than Closing Quantity" + closingqty.ToString())
                            flag = True
                            Return flag
                        End If
                        sql = "select closingstock +" + Format(Val(-(dMGqty)), "0.000") + " from closingqty where CAST(trndate AS DATE)>=CAST('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' AS DATE) "
                        sql = sql & "and closingstock +" + Format(Val(-(dMGqty)), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and itemcode='" + itemcode + "'"
                        'If batchyn = "Y" Then
                        '    sql = sql & " and batchno='" + batchno + "'"
                        'End If
                        gconnection.getDataSet(sql, "closingqty")
                        If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                            MessageBox.Show("Damage  create " + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            flag = True
                            Return flag

                        End If
                    End If

                End If

                'If (Format(CDate(ddate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
                '    Dim count As Double = 0


                '    sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate "

                '    gconnection.getDataSet(sql, "closingqty")
                '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

                '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
                '        count = count - Val(dMGqty)
                '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
                '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
                '            If count < 0 Then
                '                MessageBox.Show("Damage create  " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                '                flag = True
                '                Return flag
                '            End If
                '        Next
                '    End If
                'End If

            End If
        Next


        If (GACCPOST.ToUpper() = "Y") Then
            If UCase(gShortname) <> "HIND" Then
                Dim accode, TRNCODE As String
                If gAcPostingWise = "ITEM" Then
                    For k As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = k
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("DAMGLCODE")
                                If accode = "" Or TRNCODE = "" Then

                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                    flag = True
                                    Return flag

                                End If
                            Else
                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                flag = True
                                Return flag
                            End If
                        End If

                    Next


                ElseIf gAcPostingWise = "CATEGORY" Then

                    For k As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = k
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "select accountcode,DAMGLCODE,AC.CategoryCode  from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category WHERE IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("DAMGLCODE")
                                If accode = "" Or TRNCODE = "" Then

                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(gdataset.Tables("CODE").Rows(0).Item("CategoryCode")) + " FOR ITEMCODE='" + Trim(AxfpSpread1.Text) + "'")
                                    flag = True
                                    Return flag

                                End If
                            Else
                                MessageBox.Show("NO CATEGORY FOUND FOR ITEMCODE='" + Trim(AxfpSpread1.Text) + "'")
                                flag = True
                                Return flag
                            End If
                        End If

                    Next



                Else
                    sqlstring = "Select * from AccountstaggingnEW where CODE='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                        TRNCODE = gdataset.Tables("CODE").Rows(0).Item("DAMGLCODE")
                        If accode = "" Or TRNCODE = "" Then

                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE  " + Trim(TXT_FROMSTORECODE.Text) + "")
                            flag = True
                            Return flag

                        End If
                    Else
                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE " + Trim(TXT_FROMSTORECODE.Text) + "")
                        flag = True
                        Return flag
                    End If

                End If
            End If
        End If

            Return False
    End Function
    Private Function validateonupdate() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        'If Mid(UCase(gShortname), 1, 3) = "CCL" Then
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
        'Else
        '    checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
        'End If

        checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
        If checkBdate = True And RESU1 = False Then
            MsgBox("Business date closed..")
            flag = True
            Return flag
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
            flag = True
            Return flag
        End If
        If DateDiff(DateInterval.Day, (CDate(dtp_Docdate.Value)), DateValue(Now)) < 0 Then
            MessageBox.Show("Doc. Date cannot be greater than Current Date", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            flag = True
            Return flag
        End If
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If

        If txt_Docno.Text = "" Then
            MessageBox.Show("Please Fill IssueDocno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag


        End If
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt - 1
            AxfpSpread1.Row = i + 1

            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 4
            Dim qty As String = Val(AxfpSpread1.Text)
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim convvalue As Double
            Dim batchno As String
            AxfpSpread1.Col = 5
            batchno = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            uom1 = AxfpSpread1.Text
            Dim sql As String = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  "
            sql = sql & " and Trnno='" + txt_Docno.Text + "' "
            If (batchno <> "") Then
                sql = sql & " and  batchno='" + batchno + "' "
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                sql = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

                Else
                    MessageBox.Show("Please create Conversion Factor For " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    flag = True
                    Return flag
                    '                            convvalue = 0
                End If


                '                convvalue = gconnection.getvalue(sql)
            Else
                qty1 = 0
                convvalue = 1

            End If
            sql = "select closingstock +" + Format(Val(-(qty / convvalue) - qty1), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            sql = sql & "and closingstock +" + Format(Val(-(qty / convvalue) - qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' and  itemcode='" + itemcode + "'"
            If batchyn = "Y" Then
                sql = sql & " and batchno='" + batchno + "'"
            End If
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                MessageBox.Show("Updation create" + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                flag = True
                Return flag
            End If

            'If (Format(CDate(ddate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
            '    Dim count As Double = 0


            '    sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate,priority "

            '    gconnection.getDataSet(sql, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

            '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
            '        count = count - Val(qty1 + qty)
            '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
            '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
            '            If count < 0 Then
            '                MessageBox.Show("Damage create  " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        Next
            '    End If
            'End If
        Next
        'For j As Integer = 0 To AxfpSpread1.DataRowCnt
        '    Dim sql As String
        '    Dim uom1 As String
        '    AxfpSpread1.Col = 4
        '    If (Val(AxfpSpread1.Text) <> 0) Then
        '        Dim dMGqty As Double = Val(AxfpSpread1.Text)
        '        AxfpSpread1.Col = 1
        '        Dim itemcode As String = AxfpSpread1.Text
        '        sql = "select batchprocess from INV_InventoryItemMaster where itemcode='" + itemcode + "' "
        '        gconnection.getDataSet(sql, "INV_InventoryItemMaster")
        '        If (gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0) Then
        '            If (gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("batchprocess") = "NO") Then
        '                AxfpSpread1.Col = 3
        '                Dim uom As String = AxfpSpread1.Text
        '                Dim sql11 As String ''= "select TOP 1  ISNULL(closingstock,0) AS closingstock,uom from closingqty where itemcode='" + itemcode + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


        '                ' gconnection.getDataSet(sql11, "closingtable")
        '                gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), itemcode, Trim(TXT_FROMSTORECODE.Text), "")
        '                Dim closingqty As Double
        '                If (gdataset.Tables("closingtable").Rows.Count > 0) Then
        '                    closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

        '                Else
        '                    closingqty = 0
        '                End If
        '                uom1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
        '                sql = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + uom1 + "' and transuom='" + uom + "'"
        '                gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
        '                Dim convvalue As Double
        '                If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
        '                    convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

        '                Else
        '                    MessageBox.Show("Please create Conversion Factor For " + uom1 + " and " + uom, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        '                    flag = True
        '                    Return flag
        '                End If
        '                closingqty = closingqty * convvalue
        '                If (dMGqty > closingqty) Then
        '                    MessageBox.Show("Damage Quantity Cannot be Greater than Closing Quantity" + closingqty.ToString())
        '                    flag = True
        '                    Return flag


        '                End If
        '            End If

        '        End If



        '    End If
        'Next

        If (GACCPOST.ToUpper() = "Y") Then
            If UCase(gShortname) <> "HIND" Then
                Dim accode, TRNCODE As String
                If gAcPostingWise = "ITEM" Then
                    For k As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = k
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "Select * from AccountstaggingForITEM where ITEMCODE='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("DAMGLCODE")
                                If accode = "" Or TRNCODE = "" Then

                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                    flag = True
                                    Return flag

                                End If
                            Else
                                MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF ITEMCODE " + Trim(AxfpSpread1.Text) + "")
                                flag = True
                                Return flag
                            End If
                        End If

                    Next


                ElseIf gAcPostingWise = "CATEGORY" Then

                    For k As Integer = 1 To AxfpSpread1.DataRowCnt
                        AxfpSpread1.Row = k
                        AxfpSpread1.Col = 1
                        If Trim(AxfpSpread1.Text) <> "" Then
                            sqlstring = "select accountcode,DAMGLCODE,AC.CategoryCode  from AccountstaggingForCategory AC INNER JOIN INV_InventoryItemMaster IM ON AC.CategoryCode=IM.category WHERE IM.itemcode='" & Trim(AxfpSpread1.Text) & "'"
                            gconnection.getDataSet(sqlstring, "CODE")
                            If (gdataset.Tables("CODE").Rows.Count > 0) Then
                                accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                                TRNCODE = gdataset.Tables("CODE").Rows(0).Item("DAMGLCODE")
                                If accode = "" Or TRNCODE = "" Then

                                    MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF CATEGORY " + Trim(gdataset.Tables("CODE").Rows(0).Item("CategoryCode")) + " FOR ITEMCODE='" + Trim(AxfpSpread1.Text) + "'")
                                    flag = True
                                    Return flag

                                End If
                            Else
                                MessageBox.Show("NO CATEGORY FOUND FOR ITEMCODE='" + Trim(AxfpSpread1.Text) + "'")
                                flag = True
                                Return flag
                            End If
                        End If

                    Next



                Else
                    sqlstring = "Select * from AccountstaggingnEW where CODE='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                    gconnection.getDataSet(sqlstring, "CODE")
                    If (gdataset.Tables("CODE").Rows.Count > 0) Then
                        accode = gdataset.Tables("CODE").Rows(0).Item("accountcode")
                        TRNCODE = gdataset.Tables("CODE").Rows(0).Item("DAMGLCODE")
                        If accode = "" Or TRNCODE = "" Then

                            MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE  " + Trim(TXT_FROMSTORECODE.Text) + "")
                            flag = True
                            Return flag

                        End If
                    Else
                        MessageBox.Show("NO GL FOUND FOR ACCOUNT POSTING OF STORE " + Trim(TXT_FROMSTORECODE.Text) + "")
                        flag = True
                        Return flag
                    End If

                End If
            End If
        End If


            Return False
    End Function

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
            If validateoninsert() = False Then

                addoperation()
                Dim ITEMCODE, sqlstring As String
                Dim I As Integer
                Dim items As String
                items = ""

                Dim dtitem As New DataTable
                dtitem.Columns.Add("itemcode")
                dtitem.TableName = "TpItems"

                For I = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = I
                    AxfpSpread1.Col = 1
                    ITEMCODE = Trim(AxfpSpread1.Text)
                    items = items & "'" & Trim(ITEMCODE) & "',"
                    dtitem.Rows.Add(ITEMCODE)
                Next
                items = Mid(items, 1, Len(items) - 1)
                Call Randomize()
                vOutfile = Mid("WE" & (Rnd() * 800000000), 1, 10)
                vOutfile = Replace(vOutfile, ".", "")
                vOutfile = Replace(vOutfile, "+", "")
                Dim strrate As String
                Dim loccode As String
                sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "loccode")
                If gdataset.Tables("loccode").Rows.Count > 0 Then
                    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                Else
                    loccode = "M"
                End If
                If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "DAMAGE")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "DAMAGE")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If

                sqlstring = " exec proc_closingqtyone 'DAMAGE_ADD' "
                gconnection.ExcuteStoreProcedure(sqlstring)
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)

                Clearoperation()




            End If
        ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
            If validateonupdate() = False Then
                UpdateOperation()
                Dim ITEMCODE, sqlstring As String
                Dim I As Integer
                Dim items As String
                items = ""
                Dim dtitem As New DataTable
                dtitem.Columns.Add("itemcode")
                dtitem.TableName = "TpItems"
                For I = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = I
                    AxfpSpread1.Col = 1
                    ITEMCODE = Trim(AxfpSpread1.Text)
                    items = items & "'" & Trim(ITEMCODE) & "',"
                    dtitem.Rows.Add(ITEMCODE)
                Next
                items = Mid(items, 1, Len(items) - 1)
                Call Randomize()
                vOutfile = Mid("WE" & (Rnd() * 800000000), 1, 10)
                vOutfile = Replace(vOutfile, ".", "")
                vOutfile = Replace(vOutfile, "+", "")
                Dim strrate As String
                Dim loccode As String
                sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "loccode")
                If gdataset.Tables("loccode").Rows.Count > 0 Then
                    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                Else
                    loccode = "M"
                End If
                If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "DAMAGE")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "DAMAGE")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If


                sqlstring = " exec proc_closingqtyone 'DAMAGE_UPDATE' "
                gconnection.ExcuteStoreProcedure(sqlstring)
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)

                Clearoperation()

            End If
        End If

    End Sub
    Private Function validateonvoid() As Boolean
        Dim flag As Boolean
        Dim checkBdate As Boolean
        If Mid(UCase(gShortname), 1, 3) = "CCL" Then
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"), TXT_FROMSTORECODE.Text)
        Else
            checkBdate = gconnection.checkBdate(Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd"))
        End If
        If checkBdate = True And RESU1 = False Then
            MsgBox("Business date closed..")
            flag = True
            Return flag
        End If

        If checkBdate = True And RESU1 = True Then
            MsgBox("Business date closed , Due to Adjustement Entry")
            flag = True
            Return flag
        End If
        If (TXT_FROMSTORECODE.Text = "") Then
            MessageBox.Show("Please Fill Main Storecode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag

        End If

        If txt_Docno.Text = "" Then
            MessageBox.Show("Please Fill IssueDocno ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            flag = True
            Return flag


        End If
        If AxfpSpread1.DataRowCnt <= 0 Then
            MessageBox.Show("Please Select Item ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            AxfpSpread1.SetActiveCell(1, 1)

            flag = True
            Return flag


        End If
        For i As Integer = 0 To AxfpSpread1.DataRowCnt
            AxfpSpread1.Col = 1
            Dim itemcode As String = AxfpSpread1.Text
            AxfpSpread1.Col = 5
            Dim qty As String = Val(AxfpSpread1.Text)
            Dim qty1 As Double
            Dim batchyn As String
            Dim uom As String
            Dim uom1 As String
            Dim convvalue As Double
            Dim batchno As String
            AxfpSpread1.Col = 3
            uom1 = AxfpSpread1.Text
            Dim sql As String = "select qty,batchyn,uom from closingqty where  itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  "
            sql = sql & " and Trnno='" + txt_Docno.Text + "' "
            gconnection.getDataSet(sql, "closingqty")
            If (gdataset.Tables("closingqty").Rows.Count > 0) Then
                qty1 = gdataset.Tables("closingqty").Rows(0).Item("qty")
                batchyn = gdataset.Tables("closingqty").Rows(0).Item("batchyn")
                uom = gdataset.Tables("closingqty").Rows(0).Item("uom")
                sql = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom='" + uom + "' and transuom='" + uom1 + "'"
                convvalue = gconnection.getvalue(sql)

            Else
                qty1 = 0
                convvalue = 1

            End If
            'sql = "select closingstock +" + Format(Val(-qty1), "0.000") + " from closingqty where trndate>='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' "
            'sql = sql & "and closingstock +" + Format(Val(-qty1), "0.000") + "<0 and storecode='" + TXT_FROMSTORECODE.Text + "' "
            'If batchyn = "Y" Then
            '    sql = sql & " and batchno='" + batchno + "'"
            'End If
            'gconnection.getDataSet(sql, "closingqty")
            'If (gdataset.Tables("closingqty").Rows.Count > 0) Then
            '    MessageBox.Show("Deletion create" + itemcode + " Stock  Negative in " + TXT_FROMSTORECODE.Text, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    flag = True
            '    Return flag
            'End If
            'If (Format(CDate(ddate), "yyyy/MM/dd") > Format(CDate(dtp_Docdate.Value), "yyyy/MM/dd")) Then
            '    Dim count As Double = 0


            '    sql = "select * from closingqty where trndate > '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "' and itemcode='" + itemcode + "' and storecode='" + TXT_FROMSTORECODE.Text + "'  order by trndate,priority "

            '    gconnection.getDataSet(sql, "closingqty")
            '    If (gdataset.Tables("closingqty").Rows.Count > 0) Then

            '        count = Val(gdataset.Tables("closingqty").Rows(0).Item("openningstock"))
            '        count = count - Val(qty1)
            '        For b As Integer = 0 To gdataset.Tables("closingqty").Rows.Count - 1
            '            count = count + (Val(gdataset.Tables("closingqty").Rows(b).Item("qty")))
            '            If count < 0 Then
            '                MessageBox.Show("Damage create  " + itemcode + " Stock  Negative ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '                flag = True
            '                Return flag
            '            End If
            '        Next
            '    End If
            'End If
        Next

        Return False
    End Function

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click

        If MessageBox.Show("Do You Want void it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then
            Exit Sub
        End If

        If Mid(CStr(Cmd_Freeze.Text), 1, 1) = "V" Then
            If validateonvoid() = False Then
                voidoperation()
                Dim ITEMCODE, sqlstring As String
                Dim I As Integer
                Dim items As String
                items = ""

                Dim dtitem As New DataTable
                dtitem.Columns.Add("itemcode")
                dtitem.TableName = "TpItems"

                For I = 1 To AxfpSpread1.DataRowCnt
                    AxfpSpread1.Row = I
                    AxfpSpread1.Col = 1
                    ITEMCODE = Trim(AxfpSpread1.Text)
                    items = items & "'" & Trim(ITEMCODE) & "',"
                    dtitem.Rows.Add(ITEMCODE)
                Next
                items = Mid(items, 1, Len(items) - 1)
                Call Randomize()
                vOutfile = Mid("WE" & (Rnd() * 800000000), 1, 10)
                vOutfile = Replace(vOutfile, ".", "")
                vOutfile = Replace(vOutfile, "+", "")
                Dim strrate As String
                Dim loccode As String
                sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "loccode")
                If gdataset.Tables("loccode").Rows.Count > 0 Then
                    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                Else
                    loccode = "M"
                End If
                If Mid(UCase(gShortname), 1, 5) = "RSAOI" Then
                    strrate = CALC_WEIGHTEDRSI_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "DAMAGE")

                Else
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "DAMAGE")
                    sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                    gconnection.ExcuteStoreProcedure(sqlstring)
                End If

                sqlstring = " exec proc_closingqtyone 'DAMAGE_VOID' "
                gconnection.ExcuteStoreProcedure(sqlstring)
                'Dim sqls As String
                'sqls = "UPDATE INVENTORY_INDENTDET SET Rate=isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0), AMOUNT= INVENTORY_INDENTDET.QTY*isnull((SELECT top 1 isnull(weighted_rate,0) as weighted_rate  FROM " & strrate & " b WHERE b.ITEMCODE=INVENTORY_INDENTDET.itemcode  order by rowid desc),0) FROM  " & strrate & " A "
                'sqls = sqls & " WHERE INDENT_NO='" & Trim(Txt_IndentNo.Text) & "' and  A.ITEMCODE=INVENTORY_INDENTDET.Itemcode  "
                'sqls = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM " & strrate & " A "
                'sqls = sqls & " WHERE STOCKISSUEDETAIL.DOCDETAILS='" & Trim(txt_Docno.Text) & "' and A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE TO' "
                ''gconnection.ExcuteStoreProcedure(SQLS)
                'gconnection.ExcuteStoreProcedure(sqls)

                Clearoperation()

            End If
        End If

    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub dtp_Docdate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_Docdate.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            AxfpSpread1.SetActiveCell(1, 1)
            AxfpSpread1.Focus()
        End If
    End Sub

    Private Sub AxfpSpread1_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles AxfpSpread1.LeaveCell
        If AxfpSpread1.ActiveCol = 4 Then
            Calculate()
        ElseIf AxfpSpread1.ActiveCol = 3 Then

            AxfpSpread1.Col = 1
            Dim ITEMCODE As String = AxfpSpread1.Text
            AxfpSpread1.Col = 3
            Dim UOM As String = AxfpSpread1.Text
            Dim UOM1 As String
            Dim sql11 As String = "select TOP 1  ISNULL(closingstock,0) AS closingstock, uom from closingqty where itemcode='" + ITEMCODE + "' and storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and trndate<= '" + Format(dtp_Docdate.Value, "dd/MMM/yyyy") + "' order by trndate desc,AUTOID desc"


            gconnection.getDataSet(sql11, "closingtable")
            Dim closingqty As Double
            If (gdataset.Tables("closingtable").Rows.Count > 0) Then
                closingqty = gdataset.Tables("closingtable").Rows(0).Item("closingstock")

            Else
                closingqty = 0
            End If
            UOM1 = gdataset.Tables("closingtable").Rows(0).Item("uom")
            sql11 = "select isnull(convvalue,0) AS CONVVALUE from INVENTORY_TRANSCONVERSION where baseuom='" + UOM1 + "' and transuom='" + UOM + "'"
            gconnection.getDataSet(sql11, "INVENTORY_TRANSCONVERSION")
            Dim convvalue As Double
            If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
                convvalue = gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue")

            Else
                convvalue = 1
            End If
            closingqty = closingqty * convvalue

            AxfpSpread1.SetText(6, AxfpSpread1.ActiveRow, Format(Val(closingqty), "0.000"))

        End If


    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Try

            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New CryStkDmg
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(STORECODE,'') AS STORECODE,"
            sqlstring = sqlstring & " ISNULL(STOREDESC,'') AS STOREDESC ,"
            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(DMGQTY,0) AS DMGQTY,ISNULL(BAtCHNO,'') AS BAtCHNO,ISNULL(REMARKS,'') AS REMARKS,ISNULL(ADDDATE,'') AS ADDDATE,ISNULL(RATE,0) AS RATE,ISNULL(AMOUNT,0) AS AMOUNT "
            sqlstring = sqlstring & " FROM STOCKDMGDETAIL"
            sqlstring = sqlstring & " WHERE DOCDETAILS ='" & Trim(txt_Docno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"

            gconnection.getDataSet(sqlstring, "VW_INV_STKDMGBILL")
            If gdataset.Tables("VW_INV_STKDMGBILL").Rows.Count > 0 Then
                'If chk_excel.Checked = True Then
                '    Dim exp As New exportexcel
                '    exp.Show()
                '    Call exp.export(sqlstring, "STOCK DAMAGE ", "")
                'Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_INV_STKDMGBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                Dim textobj11 As TextObject
                textobj11 = r.ReportDefinition.ReportObjects("Text15")
                textobj11.Text = UCase(Address1)
                Dim textobj12 As TextObject
                textobj12 = r.ReportDefinition.ReportObjects("Text16")
                textobj12.Text = UCase(Address2)
                Dim textobj23 As TextObject
                textobj23 = r.ReportDefinition.ReportObjects("Text3")
                textobj23.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text11")
                textobj2.Text = gUsername
                If UCase(gShortname) = "TMA" Then
                    Dim textobj13 As TextObject
                    textobj13 = r.ReportDefinition.ReportObjects("Text13")
                    textobj13.Text = "                 Store Keeper                                                                                                     Manager"
                End If

                rViewer.Show()
                '   End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub cmd_Print_Click(sender As Object, e As EventArgs) Handles cmd_Print.Click
       Try

            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New CryStkDmg
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(STORECODE,'') AS STORECODE,"
            sqlstring = sqlstring & " ISNULL(STOREDESC,'') AS STOREDESC ,"
            sqlstring = sqlstring & " ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(DMGQTY,0) AS DMGQTY,ISNULL(BAtCHNO,'') AS BAtCHNO,ISNULL(REMARKS,'') AS REMARKS,ISNULL(ADDDATE,'') AS ADDDATE "
            sqlstring = sqlstring & " FROM STOCKDMGDETAIL"
            sqlstring = sqlstring & " WHERE DOCDETAILS ='" & Trim(txt_Docno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"

            gconnection.getDataSet(sqlstring, "VW_INV_STKDMGBILL")
            If gdataset.Tables("VW_INV_STKDMGBILL").Rows.Count > 0 Then
                'If chk_excel.Checked = True Then
                '    Dim exp As New exportexcel
                '    exp.Show()
                '    Call exp.export(sqlstring, "STOCK DAMAGE ", "")
                'Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_INV_STKDMGBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text12")
                textobj1.Text = MyCompanyName
                Dim textobj11 As TextObject
                textobj11 = r.ReportDefinition.ReportObjects("Text15")
                textobj11.Text = UCase(Address1)
                Dim textobj12 As TextObject
                textobj12 = r.ReportDefinition.ReportObjects("Text16")
                textobj12.Text = UCase(Address2)
                Dim textobj23 As TextObject
                textobj23 = r.ReportDefinition.ReportObjects("Text3")
                textobj23.Text = gFinancalyearStart + "-" + gFinancialyearEnd

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text11")
                textobj2.Text = gUsername

                rViewer.Show()
                '   End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub btn_auth_Click(sender As Object, e As EventArgs) Handles Cmdauth.Click
        '========================# IM POLICY CODE START #===========================
        Dim SSQLSTR, SSQLSTR2 As String
        Dim MCA, C, A, F As String
        Dim level As Integer
        Dim multi(2) As String


        multi(0) = "Update STOCKDMGHEADER set "
        multi(1) = "Update STOCKDMGDETAIL set "

        SSQLSTR2 = " SELECT * FROM  MCARIGHTS WHERE  MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "'"
        gconnection.getDataSet(SSQLSTR2, "MCARIGHTS")
        If gdataset.Tables("MCARIGHTS").Rows.Count > 0 Then
            ''level =1 for MAKER
            level = 1
            If gdataset.Tables("MCARIGHTS").Rows(0).Item("CHECKER") = "Y" Then
                C = "Y"
                level += 1
            End If
            If gdataset.Tables("MCARIGHTS").Rows(0).Item("AUTHORIZER") = "Y" Then
                A = "Y"
                If C Is Nothing Then
                    level += 1
                End If
                level += 1
            End If
            If gdataset.Tables("MCARIGHTS").Rows(0).Item("FINVALIDATION") = "Y" Then
                F = "Y"
            End If
            '' TO  AUTHER
            If C = "Y" Then
                MCA = "'C'" ''IF CHECK IS YES THEN ONLY NEED TO CHECK THE CHECKER RECORDS
            Else
                MCA = "'M'" ''ELSE GET ONLY MAKER RECORDS
            End If
        Else
            MCA = "'M'"
        End If


        If Mid(Cmdauth.Text, 1, 1) = "A" Then
            SSQLSTR2 = " SELECT * FROM MCARIGHTS WHERE  MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND (ISNULL(AUTHOR1ID,'')='" & gUsername & "' OR ISNULL(AUTHOR2ID,'')='" & gUsername & "' OR ISNULL(AUTHOR3ID,'')='" & gUsername & "' )"
            gconnection.getDataSet(SSQLSTR2, "CHECKER")
            If gdataset.Tables("CHECKER").Rows.Count > 0 Then
                If F = "Y" Then
                    Dim findauth1, findauth2, findauth3 As String
                    Dim AUTHERLIMIT1, AUTHERLIMIT2, AUTHERLIMIT3, LIMIT As String

                    findauth1 = UCase(gdataset.Tables("CHECKER").Rows(0).Item("AUTHOR1ID"))
                    findauth2 = UCase(gdataset.Tables("CHECKER").Rows(0).Item("AUTHOR2ID"))
                    findauth3 = UCase(gdataset.Tables("CHECKER").Rows(0).Item("AUTHOR3ID"))

                    If findauth1 = UCase(gUsername) Then
                        LIMIT = "AUTHERLIMIT1"
                    ElseIf findauth2 = UCase(gUsername) Then
                        LIMIT = "AUTHERLIMIT2"
                    ElseIf findauth3 = UCase(gUsername) Then
                        LIMIT = "AUTHERLIMIT3"
                    End If
                    SSQLSTR2 = " SELECT * FROM STOCKDMGHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN (" & MCA & ") and isnull(void,'N')='N' " '''query to change
                    SSQLSTR2 = SSQLSTR2 & " and AMOUNT <= " & Val(gdataset.Tables("CHECKER").Rows(0).Item(LIMIT))
                Else
                    SSQLSTR2 = " SELECT  isnull(Docdetails,'') as Docdetails,isnull(docdate,'') as docdate,isnull(Storecode,'') as Storecode,ISNULL(MCA,'') AS MCA,ISNULL(Authorised,'') AS Authorised FROM STOCKDMGHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN (" & MCA & ") and isnull(void,'N')='N' " '''query to change
                End If
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    Dim VIEW1 As New AUTHORISATION
                    VIEW1.DTAUTH.DataSource = Nothing
                    VIEW1.DTAUTH.Rows.Clear()
                    Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZE"), False, Me, "UPDATE STOCKDMGHEADER set  ", "Docdetails", level, 3, 0, "Y", multi) '''query to change
                    VIEW1.ShowDialog()
                    If VIEW1.Returnkeyvalue <> "" Then
                        txt_Docno.Text = Trim(VIEW1.Returnkeyvalue)
                        Call txt_Docno_Validated(sender, e)
                    End If
                    If AuthYN = True Then
                        Dim ITEMCODE, GRNNO As String
                        Dim I As Integer
                        Dim items, GRN As String
                        GRN = ""
                        For I = 1 To VIEW1.AUTHDT.RowCount
                            If VIEW1.AUTHDT.Rows(I - 1).Cells(0).Value = True Then
                                GRNNO = VIEW1.AUTHDT.Rows(I - 1).Cells(2).Value.ToString()
                                GRN = GRN & "'" & Trim(GRNNO) & "',"
                            End If
                        Next
                        GRN = Mid(GRN, 1, Len(GRN) - 1)

                        mysql = "SELECT DISTINCT ITEMCODE FROM STOCKDMGDETAIL WHERE Docdetails IN (" & GRN & ")"
                        gconnection.getDataSet(mysql, "GRN")
                        If gdataset.Tables("GRN").Rows.Count > 0 Then
                            ' Call updateAuth(gdataset.Tables("GRN"), GRN)
                        End If

                        mysql = " delete from authPending where Docdetail  IN (" & GRN & ") and ttype='DAMAGE'"
                        gconnection.dataOperation(6, mysql, )


                        AuthYN = False
                    End If

                Else
                    MsgBox(" No Checker Records to Check ")
                End If
            Else
                MsgBox(" No Checker Records to Check")
            End If


        ElseIf Mid(Cmdauth.Text, 1, 1) = "C" Then
            SSQLSTR2 = " SELECT comment, isnull(Docdetails,'') as Docdetails,isnull(docdate,'') as docdate,isnull(Storecode,'') as Storecode,ISNULL(MCA,'') AS MCA,ISNULL(Authorised,'') AS Authorised FROM STOCKDMGHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN ('M','C') and isnull(void,'N')='N' "
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR2 = " SELECT * FROM MCARIGHTS WHERE  MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND (ISNULL(CHECKER1ID,'')='" & gUsername & "' OR ISNULL(CHECKER2ID,'')='" & gUsername & "')" '''query to change
                gconnection.getDataSet(SSQLSTR2, "CHECKER")
                If gdataset.Tables("CHECKER").Rows.Count > 0 Then
                    Dim VIEW1 As New AUTHORISATION
                    VIEW1.DTAUTH.DataSource = Nothing
                    VIEW1.DTAUTH.Rows.Clear()
                    Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZE"), False, Me, "UPDATE STOCKDMGHEADER set  ", "Docdetails", level, 2, 1, "Y", multi) '''query to change

                    VIEW1.ShowDialog()
                    If VIEW1.Returnkeyvalue <> "" Then
                        txt_Docno.Text = Trim(VIEW1.Returnkeyvalue)
                        Call txt_Docno_Validated(sender, e)
                    End If
                Else
                    MsgBox(" No Checker Records to Check")
                End If
            Else
                MsgBox("No Pending Records to Check")
            End If
        ElseIf Mid(Cmdauth.Text, 1, 1) = "M" Then
            SSQLSTR2 = " SELECT  isnull(Docdetails,'') as Docdetails,isnull(docdate,'') as docdate,isnull(Storecode,'') as Storecode,ISNULL(MCA,'') AS MCA,ISNULL(Authorised,'') AS Authorised FROM STOCKDMGHEADER WHERE ISNULL(Authorised,'')<>'Y' AND ISNULL(MCA,'') IN ('M') and isnull(comment,'')<>'' and isnull(void,'N')='N' "
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                Dim VIEW1 As New AUTHORISATION
                VIEW1.DTAUTH.DataSource = Nothing
                VIEW1.DTAUTH.Rows.Clear()
                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZE"), False, Me, "UPDATE STOCKDMGHEADER set  ", "Docdetails", 1, 1, 0, "Y", multi) '''query to change
                VIEW1.ShowDialog()
                If VIEW1.Returnkeyvalue <> "" Then
                    txt_Docno.Text = Trim(VIEW1.Returnkeyvalue)
                    Call txt_Docno_Validated(sender, e)
                End If
            Else
                MsgBox("No Pending Records to Check")
            End If
        End If
    End Sub
End Class