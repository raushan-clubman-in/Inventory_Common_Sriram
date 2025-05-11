Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Public Class sub_Sub_Group_Master
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
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents txt_GroupDesc As System.Windows.Forms.TextBox
    Friend WithEvents txt_GroupCode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_GroupDescription As System.Windows.Forms.Label
    Friend WithEvents lbl_GroupCode As System.Windows.Forms.Label
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGroupCode As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmd_rpt As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sub_Sub_Group_Master))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.txt_GroupDesc = New System.Windows.Forms.TextBox()
        Me.txt_GroupCode = New System.Windows.Forms.TextBox()
        Me.lbl_GroupDescription = New System.Windows.Forms.Label()
        Me.lbl_GroupCode = New System.Windows.Forms.Label()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.cmd_rpt = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.cmdGroupCode = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.frmbut.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(241, 13)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(261, 22)
        Me.lbl_Heading.TabIndex = 8
        Me.lbl_Heading.Text = "SUB SUB GROUP  MASTER"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_GroupDesc
        '
        Me.txt_GroupDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_GroupDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_GroupDesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_GroupDesc.Location = New System.Drawing.Point(177, 54)
        Me.txt_GroupDesc.MaxLength = 50
        Me.txt_GroupDesc.Name = "txt_GroupDesc"
        Me.txt_GroupDesc.Size = New System.Drawing.Size(213, 26)
        Me.txt_GroupDesc.TabIndex = 1
        '
        'txt_GroupCode
        '
        Me.txt_GroupCode.BackColor = System.Drawing.Color.Wheat
        Me.txt_GroupCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_GroupCode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_GroupCode.Location = New System.Drawing.Point(177, 22)
        Me.txt_GroupCode.MaxLength = 10
        Me.txt_GroupCode.Name = "txt_GroupCode"
        Me.txt_GroupCode.Size = New System.Drawing.Size(192, 26)
        Me.txt_GroupCode.TabIndex = 0
        '
        'lbl_GroupDescription
        '
        Me.lbl_GroupDescription.AutoSize = True
        Me.lbl_GroupDescription.BackColor = System.Drawing.Color.Transparent
        Me.lbl_GroupDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_GroupDescription.Location = New System.Drawing.Point(10, 54)
        Me.lbl_GroupDescription.Name = "lbl_GroupDescription"
        Me.lbl_GroupDescription.Size = New System.Drawing.Size(155, 15)
        Me.lbl_GroupDescription.TabIndex = 12
        Me.lbl_GroupDescription.Text = "SUB GROUP DESCRIPTION"
        '
        'lbl_GroupCode
        '
        Me.lbl_GroupCode.AutoSize = True
        Me.lbl_GroupCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_GroupCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_GroupCode.Location = New System.Drawing.Point(10, 22)
        Me.lbl_GroupCode.Name = "lbl_GroupCode"
        Me.lbl_GroupCode.Size = New System.Drawing.Size(110, 15)
        Me.lbl_GroupCode.TabIndex = 13
        Me.lbl_GroupCode.Text = "SUB GROUP CODE"
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.Cmd_Exit)
        Me.frmbut.Controls.Add(Me.cmd_rpt)
        Me.frmbut.Controls.Add(Me.Cmd_View)
        Me.frmbut.Controls.Add(Me.Cmd_Freeze)
        Me.frmbut.Controls.Add(Me.Cmd_Add)
        Me.frmbut.Controls.Add(Me.cmd_export)
        Me.frmbut.Controls.Add(Me.Button1)
        Me.frmbut.Location = New System.Drawing.Point(788, 115)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(139, 367)
        Me.frmbut.TabIndex = 14
        Me.frmbut.TabStop = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Exit.FlatAppearance.BorderSize = 0
        Me.Cmd_Exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(7, 304)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(126, 46)
        Me.Cmd_Exit.TabIndex = 26
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'cmd_rpt
        '
        Me.cmd_rpt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_rpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_rpt.FlatAppearance.BorderSize = 0
        Me.cmd_rpt.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_rpt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_rpt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_rpt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_rpt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_rpt.ForeColor = System.Drawing.Color.Black
        Me.cmd_rpt.Image = CType(resources.GetObject("cmd_rpt.Image"), System.Drawing.Image)
        Me.cmd_rpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_rpt.Location = New System.Drawing.Point(7, 208)
        Me.cmd_rpt.Name = "cmd_rpt"
        Me.cmd_rpt.Size = New System.Drawing.Size(126, 46)
        Me.cmd_rpt.TabIndex = 25
        Me.cmd_rpt.Text = "Report [F1]"
        Me.cmd_rpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_rpt.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_View.FlatAppearance.BorderSize = 0
        Me.Cmd_View.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(7, 160)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(126, 46)
        Me.Cmd_View.TabIndex = 23
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Freeze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Freeze.FlatAppearance.BorderSize = 0
        Me.Cmd_Freeze.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(7, 112)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(126, 46)
        Me.Cmd_Freeze.TabIndex = 22
        Me.Cmd_Freeze.Text = "Void[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Add.FlatAppearance.BorderSize = 0
        Me.Cmd_Add.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(7, 64)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(126, 46)
        Me.Cmd_Add.TabIndex = 21
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_export.FlatAppearance.BorderSize = 0
        Me.cmd_export.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Image = CType(resources.GetObject("cmd_export.Image"), System.Drawing.Image)
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(7, 256)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(126, 46)
        Me.cmd_export.TabIndex = 24
        Me.cmd_export.Text = "Export[F12]"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(7, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 46)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Clear[F6]"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_auth.FlatAppearance.BorderSize = 0
        Me.cmd_auth.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_auth.ForeColor = System.Drawing.Color.Black
        Me.cmd_auth.Image = CType(resources.GetObject("cmd_auth.Image"), System.Drawing.Image)
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.Location = New System.Drawing.Point(794, 489)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(126, 46)
        Me.cmd_auth.TabIndex = 439
        Me.cmd_auth.Text = "Authorize"
        Me.cmd_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_auth.UseVisualStyleBackColor = False
        Me.cmd_auth.Visible = False
        '
        'cmdGroupCode
        '
        Me.cmdGroupCode.Image = CType(resources.GetObject("cmdGroupCode.Image"), System.Drawing.Image)
        Me.cmdGroupCode.Location = New System.Drawing.Point(373, 21)
        Me.cmdGroupCode.Name = "cmdGroupCode"
        Me.cmdGroupCode.Size = New System.Drawing.Size(23, 26)
        Me.cmdGroupCode.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_GroupCode)
        Me.GroupBox1.Controls.Add(Me.cmdGroupCode)
        Me.GroupBox1.Controls.Add(Me.lbl_GroupCode)
        Me.GroupBox1.Controls.Add(Me.txt_GroupDesc)
        Me.GroupBox1.Controls.Add(Me.lbl_GroupDescription)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 115)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 107)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Location = New System.Drawing.Point(0, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(639, 234)
        Me.GroupBox2.TabIndex = 419
        Me.GroupBox2.TabStop = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(225, 460)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(171, 22)
        Me.lbl_Freeze.TabIndex = 15
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(30, 240)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(676, 201)
        Me.ssgrid.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(204, 497)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(513, 17)
        Me.Label6.TabIndex = 418
        Me.Label6.Text = "Press F4 for HELP / Press F3 for DELETE record /Press ENTER to navigate"
        '
        'sub_Sub_Group_Master
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(944, 543)
        Me.Controls.Add(Me.cmd_auth)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ssgrid)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "sub_Sub_Group_Master"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SUB SUB GROUP MASTER "
        Me.frmbut.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim i As Integer = 1
    Private Sub Sub_Sub_Group_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.DoubleBuffered = True

            ssgrid.Visible = True
            'GroupBox2.Controls.Add(ssgrid)

            txt_GroupCode.Enabled = True
            txt_GroupCode.ReadOnly = False
            txt_GroupDesc.ReadOnly = False
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            SubGroupMasterbool = True
            If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
                If Licensebool = False Then
                    gconnection.FocusSetting(Me)
                    Me.Button1.Visible = True
                    Me.Cmd_Exit.Visible = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try
    End Sub

    Private Sub GetRights()
        Try
            Dim i, j, k, x As Integer
            Dim vmain, vsmod, vssmod As Long
            Dim ssql, SQLSTRING As String
            Dim M1 As New MainMenu
            Dim chstr As String
            GmoduleName = "SubSubGroup Master"

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
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub


    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    Dim FrReport As New ReportDesigner
        '    tables = " From inventorysubsubgroupmaster"
        '    Gheader = "SUBGROUP MASTER"
        '    FrReport.SsGridReport.SetText(2, 1, "GROUPCODE")
        '    FrReport.SsGridReport.SetText(3, 1, 15)
        '    FrReport.SsGridReport.SetText(2, 2, "GROUPDESC")
        '    FrReport.SsGridReport.SetText(3, 2, 35)
        '    FrReport.SsGridReport.SetText(2, 3, "SUBGROUPCODE")
        '    FrReport.SsGridReport.SetText(3, 3, 15)
        '    FrReport.SsGridReport.SetText(2, 4, "SUBGROUPDESC")
        '    FrReport.SsGridReport.SetText(3, 4, 35)
        '    FrReport.SsGridReport.SetText(2, 5, "FREEZE")
        '    FrReport.SsGridReport.SetText(3, 5, 5)
        '    FrReport.Show()
        'Catch ex As Exception
        '    MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End Try
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub cmdGroupCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroupCode.Click
        Try
            gSQLString = "SELECT subgroupcode,subgroupdesc FROM inventorysubgroupmaster"
            M_WhereCondition = " WHERE freeze='N' "
            Dim vform As New List_Operation
            vform.Field = " subGROUPDESC,subGROUPCODE"
            vform.vFormatstring1 = "       SUBGROUP CODE     |         SUBGROUP DESCRIPTION                                              "
            vform.vCaption = "SUB GROUP MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_GroupCode.Text = Trim(vform.keyfield & "")
                Call txt_GroupCode_Validated(txt_GroupCode, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_GroupCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_GroupCode.KeyPress
        getAlphanumeric(e)
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_GroupCode.Text) = "" Then
                    Call cmdGroupCode_Click(cmdGroupCode, e)
                Else
                    Me.txt_GroupCode_Validated(txt_GroupCode, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_GroupDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_GroupDesc.KeyPress
        getAlphanumeric(e)
        Try
            If Asc(e.KeyChar) = 13 Then
                ssgrid.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Public Sub checkValidation()
        Try
            boolchk = False
            '''********** Check  Store Code Can't be blank *********************'''
            If Trim(txt_GroupCode.Text) = "" Then
                MessageBox.Show(" Store Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_GroupCode.Focus()
                Exit Sub
            End If
            '''********** Check  Store desc Can't be blank *********************'''
            If Trim(txt_GroupDesc.Text) = "" Then
                MessageBox.Show(" Store Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_GroupDesc.Focus()
                Exit Sub
            End If
            ''' ********** Check SubgroupCode and Subgroupdesc can't be blank ***********'''
            With ssgrid
                For i = 1 To .DataRowCnt
                    .Row = i
                    .Col = 1
                    If Trim(.Text) = "" Then
                        MessageBox.Show("SubGroupCode can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        .SetActiveCell(1, ssgrid.ActiveRow)
                        .Focus()
                        Exit Sub
                    End If
                    .Col = 2
                    If Trim(.Text) = "" Then
                        MessageBox.Show("SubGroupdesc can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        .SetActiveCell(2, ssgrid.ActiveRow)
                        .Focus()
                        Exit Sub
                    End If
                Next i
            End With
            boolchk = True
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Public Sub checkValidationU()
        Try
            boolchk = False
            '''********** Check  Store Code Can't be blank *********************'''
            If Trim(txt_GroupCode.Text) = "" Then
                MessageBox.Show(" Subgroup Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_GroupCode.Focus()
                Exit Sub
            End If
            '''********** Check  Store desc Can't be blank *********************'''
            If Trim(txt_GroupDesc.Text) = "" Then
                MessageBox.Show(" Subgroup Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_GroupDesc.Focus()
                Exit Sub
            End If
            ''' ********** Check SubgroupCode and Subgroupdesc can't be blank ***********'''
            With ssgrid
                For i = 1 To .DataRowCnt
                    .Row = i
                    .Col = 1
                    If Trim(.Text) = "" Then
                        MessageBox.Show("SubSubGroupCode can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        .SetActiveCell(1, ssgrid.ActiveRow)
                        .Focus()
                        Exit Sub
                    Else
                        sqlstring = "select isnull(SubSubGroupCode,'') as SubSubGroupCode from inv_inventoryitemmaster where SubSubGroupCode='" & Trim(.Text) & "'  and isnull(void,'N')<>'Y'"
                        gconnection.getDataSet(sqlstring, "inv1")
                        If gdataset.Tables("inv1").Rows.Count > 0 Then
                            'MessageBox.Show(" Sub Sub Group  already used in transaction u can't be update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            '.SetActiveCell(1, ssgrid.ActiveRow)
                            '.Focus()
                            'Exit Sub
                        End If

                    End If
                    .Col = 2
                    If Trim(.Text) = "" Then
                        MessageBox.Show("SubSubGroupdesc can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        .SetActiveCell(2, ssgrid.ActiveRow)
                        .Focus()
                        Exit Sub
                    End If
                Next i
            End With
            boolchk = True
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_GroupCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_GroupCode.Validated
        Try
            Dim j As Integer
            If Trim(txt_GroupCode.Text) <> "" Then
                sqlstring = "SELECT ISNULL(inventorysubsubgroupmaster.subgroupcode,'') AS subgroupcode,ISNULL(inventorysubgroupmaster.SUBGroupdesc,'') AS SUBGroupdesc,ISNULL(inventorysubsubgroupmaster.SUBSubgroupcode,'') AS SUBSubgroupcode,ISNULL(inventorysubsubgroupmaster.SUBSubgroupdesc,'') AS SUBSubgroupdesc,ISNULL(inventorysubsubgroupmaster.freeze,'N') AS freeze,ISNULL(inventorysubsubgroupmaster.voiddate,GETDATE()) AS voiddate "
                sqlstring = sqlstring & " FROM inventorySUBsubgroupmaster inner join inventorysubgroupmaster on inventorysubgroupmaster.subgroupcode=inventorySUBsubgroupmaster.subgroupcode WHERE inventorySUBsubgroupmaster.SUBGROUPCODE='" & Trim(txt_GroupCode.Text) & "'"
                gconnection.getDataSet(sqlstring, "inventorysubsubgroupmaster")
                If gdataset.Tables("inventorysubsubgroupmaster").Rows.Count > 0 Then
                    txt_GroupDesc.Text = Trim(gdataset.Tables("inventorysubsubgroupmaster").Rows(0).Item("SUBGroupdesc"))
                    With ssgrid
                        For i = 1 To gdataset.Tables("inventorysubsubgroupmaster").Rows.Count
                            .SetText(1, i, Trim(gdataset.Tables("inventorysubsubgroupmaster").Rows(j).Item("SUBSubgroupcode")) & "")
                            .SetText(2, i, Trim(gdataset.Tables("inventorysubsubgroupmaster").Rows(j).Item("SUBSubgroupdesc")) & "")
                            j = j + 1
                        Next
                    End With
                    If gdataset.Tables("inventorysubsubgroupmaster").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("inventorysubsubgroupmaster").Rows(0).Item("voiddate")), "dd/MMM/yyyy")
                        Me.Cmd_Freeze.Text = "Void[F8]"

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

                    sqlstring = "SELECT * FROM inventorysubgroupmaster WHERE SUBGroupcode='" & Trim(txt_GroupCode.Text) & "' AND Freeze='N'"
                    gconnection.getDataSet(sqlstring, "inventorysubgroupmaster")
                    If gdataset.Tables("inventorysubgroupmaster").Rows.Count > 0 Then
                        txt_GroupCode.Text = Trim(gdataset.Tables("inventorysubgroupmaster").Rows(0).Item("SUBGroupcode"))
                        txt_GroupDesc.Text = Trim(gdataset.Tables("inventorysubgroupmaster").Rows(0).Item("SUBGroupdesc"))
                        txt_GroupCode.ReadOnly = True
                        Me.Cmd_Add.Text = "Add [F7]"
                        txt_GroupDesc.Focus()
                    Else
                        txt_GroupCode.Text = ""
                        txt_GroupDesc.Text = ""
                        txt_GroupCode.Focus()
                    End If
                End If
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
            Else
                txt_GroupCode.Text = ""
                txt_GroupDesc.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Sub_Sub_Group_Master_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        Try
            If e.KeyCode = Keys.F6 Then
                Call Button1_Click(Button1, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
                Call Cmd_Freeze_Click_1(Cmd_Freeze, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then

                Call Cmd_Add_Click_1(Cmd_Add, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F9 And Cmd_View.Visible = True Then
                Call Cmd_View_Click_1(Cmd_View, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
                ' Cmd_Exit_Click
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F12 And cmd_export.Visible = True Then
                Call cmd_export_Click(cmd_export, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F1 And cmd_rpt.Visible = True Then
                Call cmd_rpt_Click(cmd_rpt, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F3 Then
                ' Cmd_Exit_Click
                'Call cmd_export_Click(cmd_export, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_GroupCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_GroupCode.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If cmdGroupCode.Enabled = True Then
                    search = Trim(txt_GroupCode.Text)
                    Call cmdGroupCode_Click(cmdGroupCode, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Sub_Sub_Group_Master_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Try
            SubGroupMasterbool = False
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub ssgrid_KeyDownEvent1(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        Try
            If e.keyCode = Keys.F3 Then
                With ssgrid
                    .Row = .ActiveRow
                    .ClearRange(1, .ActiveRow, 11, .ActiveRow, True)
                    .DeleteRows(.ActiveRow, 1)
                    .SetActiveCell(1, ssgrid.ActiveRow)
                    .Focus()
                End With
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Call clearform(Me)
            Me.lbl_Freeze.Visible = False
            Me.lbl_Freeze.Text = "Record Freezed  On "
            ssgrid.ClearRange(1, 1, -1, -1, True)
            ssgrid.SetActiveCell(1, 1)
            Me.Cmd_Freeze.Text = "Void[F8]"
            Cmd_Add.Text = "Add [F7]"
            txt_GroupCode.Enabled = True
            txt_GroupCode.ReadOnly = False
            txt_GroupDesc.ReadOnly = False
            txt_GroupCode.Text = ""
            txt_GroupDesc.Text = ""
            Me.Cmd_Add.Enabled = True
            Me.Cmd_Freeze.Enabled = True

            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            txt_GroupCode.Focus()
            If gValidity = False Then
                Me.Cmd_Add.Enabled = False
                Me.cmd_auth.Enabled = False
                Me.Cmd_Freeze.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Add_Click_1(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Try
            Dim strSQL As String
            Dim Insert(0) As String
            Dim subgroupdesc As String
            If Cmd_Add.Text = "Add [F7]" Then
                Call checkValidation() '''--->Check Validation
                If boolchk = False Then Exit Sub
                For i = 1 To ssgrid.DataRowCnt
                    With ssgrid
                        .Col = 2
                        .Row = i
                        If Trim(.Text) <> "" Then
                            strSQL = " INSERT INTO inventorysubsubgroupmaster (Subgroupcode,SUBSubgroupCODE,SUBSubgroupdesc,Freeze,Adduser,Adddate)"
                            strSQL = strSQL & " VALUES ( '" & Trim(txt_GroupCode.Text) & "',"
                            .Col = 1
                            strSQL = strSQL & "'" & Trim(.Text) & "',"
                            .Col = 2
                            strSQL = strSQL & "'" & Trim(.Text) & "',"
                            strSQL = strSQL & " 'N','" & Trim(gUsername) & "','" & Format(Now, "dd/MMM/yyyy") & "')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = strSQL
                        End If
                    End With
                Next i
                gconnection.MoreTrans(Insert)
                Me.Button1_Click(sender, e)
            ElseIf Cmd_Add.Text = "Update[F7]" Then
                Call checkValidationU() '''--->Check Validation
                If boolchk = False Then Exit Sub
                If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                    If Me.lbl_Freeze.Visible = True Then
                        MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        boolchk = False
                    End If
                End If
                strSQL = strSQL & " DELETE FROM inventorysubsubgroupmaster WHERE Subgroupcode='" & Trim(txt_GroupCode.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = strSQL
                For i = 1 To ssgrid.DataRowCnt
                    With ssgrid
                        .Col = 2
                        .Row = i
                        If Trim(.Text) <> "" Then
                            strSQL = " INSERT INTO inventorysubsubgroupmaster (Subgroupcode,SUBSubgroupcode,SUBSubgroupdesc,Freeze,Adduser,Adddate)"
                            strSQL = strSQL & " VALUES ( '" & Trim(txt_GroupCode.Text) & "',"
                            .Col = 1
                            strSQL = strSQL & "'" & Trim(.Text) & "',"
                            .Col = 2
                            strSQL = strSQL & "'" & Trim(.Text) & "',"
                            strSQL = strSQL & " 'N','" & Trim(gUsername) & "','" & Format(Now, "dd/MMM/yyyy") & "')"
                            ReDim Preserve Insert(Insert.Length)
                            Insert(Insert.Length - 1) = strSQL
                        End If
                    End With
                Next i
                gconnection.MoreTrans(Insert)
                Me.Button1_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Freeze_Click_1(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Try
            Call checkValidation() ''-->Check Validation
            If boolchk = False Then Exit Sub
            Dim sqlq As String = "select isnull(Subgroupcode,'') from InventorysubsubGroupMaster where Subgroupcode in(select isnull(Subgroupcode,'') from INV_InventoryItemMaster where isnull(void,'')<>'Y')  and isnull(Subgroupcode,'')='" + txt_GroupCode.Text + "'"
            gconnection.getDataSet(sqlq, "inventorygroupmaster")
            If gdataset.Tables("inventorygroupmaster").Rows.Count > 0 Then
                MessageBox.Show(" Can't Void the Records Because Transaction is Available on this Sub Sub Group ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_GroupCode.Focus()
                Exit Sub
            End If

            If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
                sqlstring = "UPDATE  inventorysubsubgroupmaster "
                sqlstring = sqlstring & " SET Freeze= 'Y',Adduser='" & gUsername & " ', Adddate=getDate()"
                sqlstring = sqlstring & " WHERE subGroupcode = '" & Trim(txt_GroupCode.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "inventorysubsubgroupmaster")
                Me.Button1_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            Else
                sqlstring = "UPDATE  inventorysubsubgroupmaster "
                sqlstring = sqlstring & " SET Freeze= 'N',Adduser='" & gUsername & " ', Adddate=getDate()"
                sqlstring = sqlstring & " WHERE subGroupcode = '" & Trim(txt_GroupCode.Text) & "'"
                gconnection.dataOperation(4, sqlstring, "inventorysubsubgroupmaster")
                Me.Button1_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_View_Click_1(sender As Object, e As EventArgs) Handles Cmd_View.Click
        Dim FRM As New ReportDesigner
        If txt_GroupCode.Text.Length > 0 Then
            tables = " FROM inventorysubsubgroupmaster WHERE Subgroupcode ='" & txt_GroupCode.Text & "' "
        Else
            tables = "FROM inventorysubsubgroupmaster "
        End If
        Gheader = "GROUPMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"Subgroupcode", "14"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"Subgroupcode", "12"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SubSUBgroupcode", "12"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SubSUBgroupdesc", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Freeze", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adduser", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adddate", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UPDATEUSER", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UPDATETIME", "11"}
        'FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub cmd_export_Click(sender As Object, e As EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "inventorysubsubgroupmaster"
        sqlstring = "select * from inventorysubsubgroupmaster"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub Cmd_Exit_Click_1(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 732
        K = 1016
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
                        ElseIf Controls(i_i).Name = "frmbut" Then
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

    Private Sub cmd_rpt_Click(sender As Object, e As EventArgs) Handles cmd_rpt.Click
        gPrint = False
        'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
        Dim rViewer As New Viewer
        Dim sqlstring, SSQL As String
        Dim r As New subsubgroupreport
        sqlstring = "SELECT inventorysubsubgroupmaster.subgroupcode,inventorysubgroupmaster.subgroupdesc,inventorysubsubgroupmaster.subsubgroupcode, inventorysubsubgroupmaster.subsubgroupdesc,inventorysubsubgroupmaster.freeze"
        sqlstring = sqlstring & "     FROM inventorysubsubgroupmaster INNER JOIN inventorysubgroupmaster ON inventorysubgroupmaster.subgroupcode=inventorysubsubgroupmaster.subgroupcode   order by subgroupdesc  "
        gconnection.getDataSet(sqlstring, "inventorysubsubgroupmaster")
        If gdataset.Tables("inventorysubsubgroupmaster").Rows.Count > 0 Then
            'If chk_excel.Checked = True Then
            '    Dim exp As New exportexcel
            '    exp.Show()
            '    Call exp.export(sqlstring, "SUBGROUP MASTER ", "")
            'Else
            rViewer.ssql = sqlstring
            rViewer.Report = r
            rViewer.TableName = "inventorysubsubgroupmaster"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text13")
            textobj1.Text = MyCompanyName
            Dim textobj2 As TextObject
            textobj2 = r.ReportDefinition.ReportObjects("Text21")
            textobj2.Text = gUsername

            Dim textobj17 As TextObject
            textobj17 = r.ReportDefinition.ReportObjects("Text17")
            textobj17.Text = "INVENTORY SUBSUBGROUP MASTER"

            If MyCompanyName = "THE BENGAL CLUB" Then
                Dim textobj3 As TextObject
                textobj3 = r.ReportDefinition.ReportObjects("Text27")
                textobj3.Text = ""
            End If
            rViewer.Show()
            'End If
        Else
            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        End If
        'Else
        'PRINTOPERATION()
        '  End If
    End Sub

    Private Sub cmd_auth_Click(sender As Object, e As EventArgs) Handles cmd_auth.Click
        Authocheck("INVENTORY", "SubSubGroup Master", gUsername, "InventorySubSubGroupMaster", "subsubgroupcode", Me)

    End Sub

End Class
