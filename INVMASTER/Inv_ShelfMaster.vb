Public Class Inv_ShelfMaster
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Private Sub Inv_ShelfMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_ShelfCode.Enabled = True
        txt_ShelfCode.ReadOnly = False
        txt_ShelfDesc.ReadOnly = False
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        GroupMasterbool = True
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Shelf Master"

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
        'Me.Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    'Me.Cmd_View.Enabled = True
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
                    'Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    ' Me.cmd_auth.Enabled = True
                End If
            Next
        End If
    End Sub
    Public Sub checkValidationU()
        boolchk = False
        '''********** Check  Shelf Code Can't be blank *********************'''
        If Trim(txt_ShelfCode.Text) = "" Then
            MessageBox.Show(" Shelf Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_ShelfCode.Focus()
            Exit Sub
        End If
        '''********** Check  Shelf desc Can't be blank *********************'''
        If Trim(txt_ShelfDesc.Text) = "" Then
            MessageBox.Show(" Shelf Desc. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_ShelfDesc.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        txt_ShelfCode.Enabled = True
        txt_ShelfCode.ReadOnly = False
        txt_ShelfDesc.ReadOnly = False
        txt_ShelfCode.Text = ""
        txt_ShelfDesc.Text = ""
        txt_Locationcode.Text = ""
        txt_Locationdesc.Text = ""
        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True
        Cmd_Freeze.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txt_ShelfCode.Focus()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Shelf Code Can't be blank *********************'''
        If Trim(txt_ShelfCode.Text) = "" Then
            MessageBox.Show(" Shelf Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_ShelfCode.Focus()
            Exit Sub
        End If
        '''********** Check  Location desc Can't be blank *********************'''
        If Trim(txt_ShelfDesc.Text) = "" Then
            MessageBox.Show(" Shelf Desc. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_ShelfDesc.Focus()
            Exit Sub
        End If
        If Trim(txt_Locationcode.Text) = "" Then
            MessageBox.Show(" Location Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_Locationcode.Focus()
            Exit Sub
        End If
        If Trim(txt_Locationdesc.Text) = "" Then
            MessageBox.Show(" Location Desc. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_Locationdesc.Focus()
            Exit Sub
        End If
        sqlstring = "select isnull(Shelfcode,'') as Shelfcode from InventoryShelfMaster where Shelfcode='" & Trim(txt_ShelfCode.Text) & "'"
        gconnection.getDataSet(sqlstring, "inv1")
        If gdataset.Tables("inv1").Rows.Count > 0 Then
            MessageBox.Show(" Shelf Code already exists ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_ShelfCode.Text = ""
            txt_ShelfCode.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            strSQL = " INSERT INTO InventoryShelfMaster (Shelfcode,ShelfDesc,Storecode,Storedesc,Freeze,Adduser,Adddate)"
            strSQL = strSQL & "VALUES ( '" & Trim(txt_ShelfCode.Text) & "','" & Replace(Trim(txt_ShelfDesc.Text), "'", "") & "','" & txt_Locationcode.Text & "','" & Replace(Trim(txt_Locationdesc.Text), "'", "") & "',"
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Date.Now, "dd/MMM/yyyy") & "')"
            gconnection.dataOperation(1, strSQL, "InventoryShelfMaster")
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidationU() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    ' Exit Sub
                End If
            End If
            strSQL = "UPDATE  InventoryShelfMaster "
            strSQL = strSQL & " SET ShelfDesc='" & Replace(Trim(txt_ShelfDesc.Text), "'", "") & "',Storecode='" + txt_Locationcode.Text + "',Storedesc='" + Replace(Trim(txt_Locationdesc.Text), "'", "") & "',"
            strSQL = strSQL & "UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(Now, "dd/MMM/yyyy") & "',freeze='N'"
            strSQL = strSQL & " WHERE Shelfcode = '" & Trim(txt_ShelfCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "InventoryShelfMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Call checkValidationU() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
            sqlstring = "UPDATE  InventoryShelfMaster "
            sqlstring = sqlstring & " SET Freeze= 'Y',voiduser='" & gUsername & " ', voiddate=getDate()"
            sqlstring = sqlstring & " WHERE Shelfcode = '" & Trim(txt_ShelfCode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "InventoryShelfMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        ElseIf Mid(Me.Cmd_Freeze.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE  InventoryShelfMaster "
            sqlstring = sqlstring & " SET Freeze= 'N',voiduser='" & gUsername & " ', voiddate=getDate()"
            sqlstring = sqlstring & " WHERE Shelfcode = '" & Trim(txt_ShelfCode.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "InventoryShelfMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Inv_ShelfMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
            If Cmd_Freeze.Enabled = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 And Cmd_View.Visible = True Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F12 And cmd_export.Visible = True Then
            Call cmd_export_Click(cmd_export, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F4 Then
            Call cmdShelfCode_Click(cmdShelfCode, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If

    End Sub

    Private Sub cmdShelfCode_Click(sender As Object, e As EventArgs) Handles cmdShelfCode.Click
        gSQLString = "SELECT ISNULL(Shelfcode,'') AS Shelfcode,ISNULL(ShelfDesc,'') AS ShelfDesc FROM InventoryShelfMaster"
        M_WhereCondition = "  "
        Dim vform As New ListOperattion1

        vform.Field = "ShelfDesc,Shelfcode"
        vform.vFormatstring = "         SHELF CODE              |                  SHELF DESCRIPTION                                                                                              "
        vform.vCaption = "SHELF MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_ShelfCode.Text = Trim(vform.keyfield & "")
            Call txt_ShelfCode_Validated(txt_ShelfCode, e)
        End If
        vform.Close()
        vform = Nothing

    End Sub

    Private Sub txt_ShelfCode_Validated(sender As Object, e As EventArgs) Handles txt_ShelfCode.Validated
        If Trim(txt_ShelfCode.Text) <> "" Then
            sqlstring = "SELECT isnull(Shelfcode,'') as Shelfcode,isnull(ShelfDesc,'') as ShelfDesc,isnull(Storecode,'') as Storecode,isnull(Storedesc,'') as Storedesc,isnull(freeze,'') as freeze,isnull(voiddate,'01/01/1900') as voiddate FROM InventoryShelfMaster WHERE Shelfcode='" & Trim(txt_ShelfCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "InventoryShelfMaster")
            If gdataset.Tables("InventoryShelfMaster").Rows.Count > 0 Then
                txt_ShelfCode.Text = Trim(gdataset.Tables("InventoryShelfMaster").Rows(0).Item("Shelfcode"))
                txt_ShelfDesc.Text = Trim(gdataset.Tables("InventoryShelfMaster").Rows(0).Item("ShelfDesc"))
                txt_Locationcode.Text = Trim(gdataset.Tables("InventoryShelfMaster").Rows(0).Item("Storecode"))
                txt_Locationdesc.Text = Trim(gdataset.Tables("InventoryShelfMaster").Rows(0).Item("Storedesc"))
                txt_Locationdesc.Focus()
                txt_Locationcode.ReadOnly = True
                If gdataset.Tables("InventoryShelfMaster").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("InventoryShelfMaster").Rows(0).Item("voiddate")), "dd/MMM/yyyy")
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_Add.Enabled = False
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                End If
                Me.Cmd_Add.Text = "Update[F7]"
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txt_ShelfCode.ReadOnly = False
                txt_ShelfDesc.Focus()
            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Else
            txt_ShelfCode.Text = ""
            txt_ShelfDesc.Focus()
        End If
    End Sub
    Private Sub txt_ShelfCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_ShelfCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdShelfCode.Enabled = True Then
                If txt_ShelfCode.Text = "" Then
                    search = Trim(txt_ShelfCode.Text)
                    Call cmdShelfCode_Click(cmdShelfCode, e)
                End If
            End If
        End If
    End Sub

    Private Sub txt_ShelfDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_ShelfDesc.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Or e.KeyCode = 18 Then
            txt_Locationcode.Focus()
        End If
    End Sub

    Private Sub txt_ShelfCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ShelfCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_ShelfCode.Text) = "" Then
                Call cmdShelfCode_Click(cmdShelfCode, e)
            Else
                txt_ShelfCode_Validated(txt_ShelfCode, e)
            End If
        End If
    End Sub

    Private Sub cmd_export_Click(sender As Object, e As EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "InventoryShelfMaster"
        sqlstring = "select * from InventoryShelfMaster"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub Cmd_View_Click(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Dim FRM As New ReportDesigner
        If txt_Locationcode.Text.Length > 0 Then
            tables = " FROM InventoryShelfMaster WHERE Shelfcode ='" & txt_ShelfCode.Text & "' "
        Else
            tables = "FROM InventoryShelfMaster "
        End If
        Gheader = "SHELF MASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100
        Dim ROW As String() = New String() {"Shelfcode", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ShelfDesc", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Freeze", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adduser", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adddate", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATETIME", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)

    End Sub

    Private Sub Cmd_Location_Click(sender As Object, e As EventArgs) Handles Cmd_Location.Click
        gSQLString = "SELECT distinct ISNULL(Storecode,'') AS Storecode,ISNULL(storedesc,'') AS storedesc FROM STOREMASTER"
        M_WhereCondition = " WHERE  FREEZE<>'Y'"
        Dim vform As New ListOperattion1
        vform.Field = "storedesc,Storecode"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Locationcode.Text = Trim(vform.keyfield & "")
            txt_Locationdesc.Text = Trim(vform.keyfield1 & "")
        End If
        vform.Close()
        vform = Nothing
        Cmd_Add.Focus()
    End Sub

    Private Sub txt_Locationcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Locationcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Cmd_Location.Enabled = True Then
                If txt_Locationcode.Text = "" Then
                    search = Trim(txt_Locationcode.Text)
                    Call Cmd_Location_Click(Cmd_Location, e)
                End If
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If txt_Locationcode.Text = "" Then
                search = Trim(txt_Locationcode.Text)
                Call Cmd_Location_Click(Cmd_Location, e)
            Else
                Cmd_Add.Focus()
            End If
        End If
    End Sub
    Private Sub txt_Locationcode_Validated(sender As Object, e As EventArgs) Handles txt_Locationcode.Validated
        sqlstring = "SELECT distinct ISNULL(Storecode,'') AS Storecode,ISNULL(storedesc,'') AS storedesc FROM InventoryLocationMaster where FREEZE<>'Y' and Storecode='" + txt_Locationcode.Text + "'"
        gconnection.getDataSet(sqlstring, "InventoryLocationMaster")
        If (gdataset.Tables("InventoryLocationMaster").Rows.Count > 0) Then
            txt_Locationcode.Text = Trim(gdataset.Tables("InventoryLocationMaster").Rows(0).Item("Storecode") & "")
            txt_Locationdesc.Text = Trim(gdataset.Tables("InventoryLocationMaster").Rows(0).Item("storedesc") & "")
        Else
            txt_Locationcode.Text = ""
            txt_Locationdesc.Text = ""
        End If
    End Sub
    Private Sub txt_ShelfDesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ShelfDesc.KeyPress
        getAlphanumeric(e)
    End Sub
End Class