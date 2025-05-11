Imports System.Data.SqlClient
Public Class VendorMaster
    Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ssGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btn_Membercodehelp As System.Windows.Forms.Button
    Friend WithEvents CMDfreeze As System.Windows.Forms.Button
    Friend WithEvents lbl_mname As System.Windows.Forms.Label
    Friend WithEvents txt_Vcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents cmd_view As System.Windows.Forms.Button
    Friend WithEvents btn_auth As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorMaster))
        Me.ssGrid = New AxFPSpreadADO.AxfpSpread()
        Me.btn_auth = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CMDfreeze = New System.Windows.Forms.Button()
        Me.btn_Membercodehelp = New System.Windows.Forms.Button()
        Me.txt_Vcode = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbl_mname = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmd_view = New System.Windows.Forms.Button()
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ssGrid
        '
        Me.ssGrid.DataSource = Nothing
        Me.ssGrid.Location = New System.Drawing.Point(253, 239)
        Me.ssGrid.Name = "ssGrid"
        Me.ssGrid.OcxState = CType(resources.GetObject("ssGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssGrid.Size = New System.Drawing.Size(512, 304)
        Me.ssGrid.TabIndex = 1
        '
        'btn_auth
        '
        Me.btn_auth.BackColor = System.Drawing.Color.Transparent
        Me.btn_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_auth.ForeColor = System.Drawing.Color.Black
        Me.btn_auth.Location = New System.Drawing.Point(870, 487)
        Me.btn_auth.Name = "btn_auth"
        Me.btn_auth.Size = New System.Drawing.Size(134, 56)
        Me.btn_auth.TabIndex = 435
        Me.btn_auth.Text = "Authorize "
        Me.btn_auth.UseVisualStyleBackColor = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.Transparent
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Image = Global.Inventory.My.Resources.Resources.excel
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(869, 423)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(134, 56)
        Me.cmd_export.TabIndex = 434
        Me.cmd_export.Text = "Export"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Image = Global.Inventory.My.Resources.Resources._Exit
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(870, 558)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(134, 56)
        Me.cmdexit.TabIndex = 429
        Me.cmdexit.Text = "Exit[F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.Transparent
        Me.CmdAdd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.Color.Black
        Me.CmdAdd.Image = Global.Inventory.My.Resources.Resources.save
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.Location = New System.Drawing.Point(870, 292)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(134, 56)
        Me.CmdAdd.TabIndex = 427
        Me.CmdAdd.Text = "Add[F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Transparent
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.Image = Global.Inventory.My.Resources.Resources.Clear
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(870, 229)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(134, 56)
        Me.CmdClear.TabIndex = 430
        Me.CmdClear.Text = "Clear[F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'CMDfreeze
        '
        Me.CMDfreeze.BackColor = System.Drawing.Color.Transparent
        Me.CMDfreeze.BackgroundImage = Global.Inventory.My.Resources.Resources.Delete
        Me.CMDfreeze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CMDfreeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDfreeze.ForeColor = System.Drawing.Color.Black
        Me.CMDfreeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMDfreeze.Location = New System.Drawing.Point(869, 626)
        Me.CMDfreeze.Name = "CMDfreeze"
        Me.CMDfreeze.Size = New System.Drawing.Size(134, 56)
        Me.CMDfreeze.TabIndex = 433
        Me.CMDfreeze.Text = "Freeze[F8]"
        Me.CMDfreeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMDfreeze.UseVisualStyleBackColor = False
        Me.CMDfreeze.Visible = False
        '
        'btn_Membercodehelp
        '
        Me.btn_Membercodehelp.BackColor = System.Drawing.Color.Transparent
        Me.btn_Membercodehelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Membercodehelp.Image = CType(resources.GetObject("btn_Membercodehelp.Image"), System.Drawing.Image)
        Me.btn_Membercodehelp.Location = New System.Drawing.Point(487, 183)
        Me.btn_Membercodehelp.Name = "btn_Membercodehelp"
        Me.btn_Membercodehelp.Size = New System.Drawing.Size(24, 25)
        Me.btn_Membercodehelp.TabIndex = 581
        Me.btn_Membercodehelp.UseVisualStyleBackColor = False
        '
        'txt_Vcode
        '
        Me.txt_Vcode.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txt_Vcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Vcode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Vcode.Location = New System.Drawing.Point(385, 186)
        Me.txt_Vcode.MaxLength = 10
        Me.txt_Vcode.Name = "txt_Vcode"
        Me.txt_Vcode.Size = New System.Drawing.Size(96, 21)
        Me.txt_Vcode.TabIndex = 579
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(274, 189)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 15)
        Me.Label18.TabIndex = 580
        Me.Label18.Text = "VENDOR CODE :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_mname
        '
        Me.lbl_mname.AutoSize = True
        Me.lbl_mname.BackColor = System.Drawing.Color.Transparent
        Me.lbl_mname.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_mname.Location = New System.Drawing.Point(561, 189)
        Me.lbl_mname.Name = "lbl_mname"
        Me.lbl_mname.Size = New System.Drawing.Size(48, 15)
        Me.lbl_mname.TabIndex = 582
        Me.lbl_mname.Text = "[NAME]"
        Me.lbl_mname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(183, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 22)
        Me.Label1.TabIndex = 583
        Me.Label1.Text = "VENDOR ITEM LINK"
        '
        'cmd_view
        '
        Me.cmd_view.BackColor = System.Drawing.Color.Transparent
        Me.cmd_view.BackgroundImage = Global.Inventory.My.Resources.Resources.view
        Me.cmd_view.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_view.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_view.ForeColor = System.Drawing.Color.Black
        Me.cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_view.Location = New System.Drawing.Point(869, 359)
        Me.cmd_view.Name = "cmd_view"
        Me.cmd_view.Size = New System.Drawing.Size(134, 56)
        Me.cmd_view.TabIndex = 584
        Me.cmd_view.Text = "View [F9]"
        Me.cmd_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_view.UseVisualStyleBackColor = False
        '
        'VendorMaster
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1016, 694)
        Me.Controls.Add(Me.cmd_view)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.CMDfreeze)
        Me.Controls.Add(Me.cmd_export)
        Me.Controls.Add(Me.btn_auth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_mname)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.txt_Vcode)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.btn_Membercodehelp)
        Me.Controls.Add(Me.ssGrid)
        Me.KeyPreview = True
        Me.Name = "VendorMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VENDORITEMLINK"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim VCONN As New GlobalClass
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        VCONN.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    'Me.CmdView.Enabled = True
                    'Me.CmdPrint.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    'Me.CmdView.Enabled = True
                    'Me.CmdPrint.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txt_Vcode.Enabled = True
        btn_Membercodehelp.Enabled = True
        txt_Vcode.Text = ""
        lbl_mname.Text = ""
        ssGrid.ClearRange(1, 1, -1, -1, True)
        ssGrid.SetActiveCell(1, 1)
        txt_Vcode.Focus()
        CmdAdd.Text = "Add [F7]"

    End Sub
    Private Sub ssGrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssGrid.KeyDownEvent
        Dim I As Integer
        Dim DEPT, TRANS As String
        Dim DOB As Date
        With ssGrid
            If e.keyCode = Keys.Enter Then
                I = .ActiveRow
                If .ActiveCol = 1 Then
                    .Row = I
                    .Col = 1
                    If Trim(.Text) = "" Then
                        Call fillTrans()
                    Else
                        sqlstring = "SELECT ISNULL(Itemcode,'') AS Itemcode,ISNULL(itemname,'') AS itemname FROM inventoryitemmaster "
                        sqlstring = sqlstring & " WHERE storecode='MNS' and Itemcode="
                        .Col = 1
                        .Row = I
                        TRANS = .Text
                        sqlstring = sqlstring & " '" & TRANS & "'"
                        VCONN.getDataSet(sqlstring, "TRANS")
                        If gdataset.Tables("TRANS").Rows.Count > 0 Then
                            .Col = 1
                            .Row = I
                            .Text = gdataset.Tables("TRANS").Rows(0).Item("Itemcode")
                            .Col = 2
                            .Row = I
                            .Text = gdataset.Tables("TRANS").Rows(0).Item("itemname")
                            ssGrid.SetActiveCell(0, .Row + 1)
                        Else
                            MsgBox("NO SUCH ITEMNAME FOUND")
                            .Text = ""
                            .SetActiveCell(1, I)
                        End If
                    End If
                ElseIf .ActiveCol = 2 Then
                    .SetActiveCell(2, I)
                End If
            End If
            If e.keyCode = Keys.F3 Then
                .DeleteRows(.ActiveRow, 1)
                .SetActiveCell(1, I)
                .Focus()
            End If
        End With
    End Sub
    Private Sub fillTrans()
        Dim sqlstring As String
        Dim I, J As Integer
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(Itemcode,'') AS Itemcode,ISNULL(itemname,'') AS itemname FROM inventoryitemmaster where  "
        M_WhereCondition = "storecode='MNS'"
        vform.Field = "Itemcode,itemname"
        vform.vFormatstring = "     Itemcode                  |    Itemname                                   "
        vform.vCaption = "ITEM MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssGrid
                .Col = 1
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield)
                .Col = 2
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield1)
                '.SetActiveCell(1, I)
                ssGrid.SetActiveCell(0, .Row + 1)
            End With
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim I As Integer
        Dim SQL(0), ITEMCODE, ITEMNAME As String
        Dim AGE As Double
        Try
            sqlstring = "DELETE FROM  Inv_VendorMaster WHERE VENDORCODE='" & Trim(txt_Vcode.Text) & "'"
            ReDim Preserve SQL(SQL.Length)
            SQL(SQL.Length - 1) = sqlstring
            With ssGrid
                For I = 1 To ssGrid.DataRowCnt
                    .Row = I
                    .Col = 1
                    ITEMCODE = .Text

                    .Row = I
                    .Col = 2
                    ITEMNAME = .Text
                    sqlstring = "INSERT INTO Inv_VendorMaster (vendorcode,Itemcode,ADDUSER,ADDDATE)"
                    sqlstring = sqlstring & " VALUES ('" & Trim(txt_Vcode.Text) & "','" & Trim(ITEMCODE) & "','" & gUsername & "','" & Format(Now(), "dd/MMM/yyyy") & "')"
                    ReDim Preserve SQL(SQL.Length)
                    SQL(SQL.Length - 1) = sqlstring

                Next I
            End With
            VCONN.MoreTrans(SQL)
            Call CmdClear_Click(sender, e)
        Catch ex As Exception
            MsgBox("ERROR IN : " & ex.Message)
        End Try
    End Sub
  
    Private Sub VendorMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Show()
        txt_Vcode.Focus()
        ' CmdAdd.Text = "Update [F7]"


    End Sub
    Private Sub btn_membercodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Membercodehelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT distinct ISNULL(SLCODE,'') AS SLCODE,ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER "
        M_WhereCondition = " WHERE ISNULL(FREEZEFLAG,'') <> 'Y' AND ISNULL(SLTYPE,'') = 'SUPPLIER'"
        vform.Field = " SLCODE,SLNAME "
        vform.vFormatstring = "VENDOR CODE             |VENDOR NAME                                  "
        vform.vCaption = "VENDOR MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Vcode.Text = Trim(vform.keyfield & "")
            lbl_mname.Text = Trim(vform.keyfield1 & "")
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_Vcode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Vcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call btn_membercodehelp_Click(sender, e)
            Exit Sub
        End If
    End Sub
    Private Sub txt_Vcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Vcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_Vcode.Text) = "" Then
                Call btn_membercodehelp_Click(sender, e)
            Else
                ssGrid.SetActiveCell(1, 1)
                ssGrid.Focus()
                ssGrid.Show()
            End If
        End If
    End Sub
    Private Sub txt_Vcode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Vcode.Validated
        Dim strsql As String
        Dim I As Integer
        strsql = "select * from ACCOUNTSSUBLEDGERMASTER WHERE SLCODE = '" & Trim(txt_Vcode.Text) & "' AND ISNULL(FREEZEFLAG,'') <> 'Y' AND ISNULL(SLTYPE,'') = 'SUPPLIER' "
        VCONN.getDataSet(strsql, "MEM")
        If gdataset.Tables("MEM").Rows.Count <= 0 Then
            Me.txt_Vcode.Text = ""
        Else
            lbl_mname.Text = Trim(gdataset.Tables("MEM").Rows(0).Item("SLNAME"))
            strsql = "select * from Inv_VendorMaster WHERE VENDORCODE = '" & Trim(txt_Vcode.Text) & "' "
            VCONN.getDataSet(strsql, "MEM1")
            If gdataset.Tables("MEM1").Rows.Count > 0 Then
                sqlstring = "select distinct ISNULL(v.vendorcode,'') AS VENDORCODE, ISNULL(v.itemcode,'') AS ICODE, ISNULL(a.slcode,'') AS SLCODE, ISNULL(a.slname,'') AS SLNAME, ISNULL(a.accode,'') AS ACCODE, ISNULL(i.itemcode,'') AS ITEMCODE, ISNULL(i.itemname,'') AS ITEMNAME from inv_vendormaster v, ACCOUNTSSUBLEDGERMASTER a, inventoryitemmaster i"
                sqlstring = sqlstring & " where v.vendorcode = a.slcode And v.itemcode = I.itemcode AND a.accode = 'SCRS' AND V.VENDORCODE = '" & Trim(txt_Vcode.Text) & "' "
                VCONN.getDataSet(sqlstring, "TRANS")
                If gdataset.Tables("TRANS").Rows.Count > 0 Then
                    lbl_mname.Text = Trim(gdataset.Tables("TRANS").Rows(I).Item("SLNAME"))
                    With ssGrid
                        For I = 0 To gdataset.Tables("TRANS").Rows.Count - 1
                            .Col = 1
                            .Row = I + 1
                            .Text = Trim(gdataset.Tables("TRANS").Rows(I).Item("ITEMCODE"))
                            .Col = 2
                            .Row = I + 1
                            .Text = Trim(gdataset.Tables("TRANS").Rows(I).Item("ITEMNAME"))

                        Next
                        CmdAdd.Text = "Update [F7]"
                        ssGrid.SetActiveCell(1, 1)
                        ssGrid.Focus()
                    End With
                    txt_Vcode.Enabled = False
                    btn_Membercodehelp.Enabled = False
                Else
                    MsgBox("NO RECORDS TO DISPLAY")
                    'Call CmdClear_Click(sender, e)
                End If
            End If
        End If
    End Sub
    Private Sub MEMBERFACILITY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(CmdClear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            Call CmdAdd_Click(CmdAdd, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call CMDfreeze_Click(CMDfreeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call cmd_view_Click(CmdAdd, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(cmdexit, e)
            Exit Sub
        End If
    End Sub
    Private Sub CMDfreeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDfreeze.Click
        'Dim strsql As String
        'If Mid(CMDfreeze.Text, 1, 1) = "F" Then
        '    strsql = "UPDATE  Inv_VendorMaster "
        '    strsql = strsql & " SET Freeze= 'Y',voiduser='" & gUsername & " ', voiddate='" & Format(Now, "dd-MMM-yyyy") & "'" 'where mcode='" & Trim(txt_Vcode.Text) & "'"
        '    VCONN.dataOperation(3, strsql, "Inv_VendorMaster")
        '    Me.CmdClear_Click(sender, e)
        '    CmdAdd.Text = "Add [F7]"
        '    'Else
        '    '    strsql = "UPDATE  MEMBER_TRANS_DETAILS "
        '    '    strsql = strsql & " SET Freeze= 'N',Adduserid='" & gUsername & " ',Adddate='" & Format(Now, "dd-MMM-yyyy") & "' where mcode='" & Trim(txt_Vcode.Text) & "'"
        '    '    VCONN.dataOperation(4, strsql, "MR_AFMMC")
        '    '    Me.CmdClear_Click(sender, e)
        '    '    CmdAdd.Text = "Add [F7]"
        'End If
    End Sub

    Private Sub ssGrid_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssGrid.Advance

    End Sub

    Private Sub txt_Vcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Vcode.TextChanged

    End Sub

    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "Inv_vendormaster"
        sqlstring = "select * from Inv_vendormaster"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

   

    Private Sub lbl_mname_Click(sender As Object, e As EventArgs) Handles lbl_mname.Click

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_view.Click
        Dim FRM As New ReportDesigner
        If txt_Vcode.Text.Length > 0 Then
            tables = " FROM Inv_vendormaster WHERE VENDORcode ='" & txt_Vcode.Text & "' "
        Else
            tables = "FROM Inv_vendormaster "
        End If
        Gheader = "VENDOR LINK DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"Vendorcode", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Itemcode", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"slcode", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"sldesc", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"sldesc", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"VOID", "4"}
        'FRM.DataGridView1.Rows.Add(ROW)
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

    Private Sub btn_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_auth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        Dim USERT As Integer
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 1
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 2
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 3
        End If
        If USERT = 1 Then
            SSQLSTR2 = " SELECT * FROM Inv_vendormaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM Inv_vendormaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE Inv_vendormaster set  ", "vendorcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM Inv_vendormaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM Inv_vendormaster  WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE Inv_vendormaster set  ", "vendorcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM Inv_vendormaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM Inv_vendormaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE Inv_vendormaster set  ", "vendorcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    'End Sub
End Class
