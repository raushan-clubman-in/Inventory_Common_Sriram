Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Public Class Store_Master
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_StoreDesc As System.Windows.Forms.TextBox
    Friend WithEvents txt_StoreCode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_StoreDescription As System.Windows.Forms.Label
    Friend WithEvents lbl_StoreCode As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmdStoreCode As System.Windows.Forms.Button
    Friend WithEvents Opt_Mainstore As System.Windows.Forms.RadioButton
    Friend WithEvents Opt_Substore As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents cmd_rpt As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Store_Master))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.txt_StoreDesc = New System.Windows.Forms.TextBox()
        Me.txt_StoreCode = New System.Windows.Forms.TextBox()
        Me.lbl_StoreDescription = New System.Windows.Forms.Label()
        Me.lbl_StoreCode = New System.Windows.Forms.Label()
        Me.cmdStoreCode = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Opt_Substore = New System.Windows.Forms.RadioButton()
        Me.Opt_Mainstore = New System.Windows.Forms.RadioButton()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.cmd_rpt = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(164, 18)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(169, 22)
        Me.lbl_Heading.TabIndex = 9
        Me.lbl_Heading.Text = "STORE  MASTER"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_StoreDesc
        '
        Me.txt_StoreDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_StoreDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_StoreDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_StoreDesc.Location = New System.Drawing.Point(204, 68)
        Me.txt_StoreDesc.MaxLength = 50
        Me.txt_StoreDesc.Name = "txt_StoreDesc"
        Me.txt_StoreDesc.Size = New System.Drawing.Size(196, 21)
        Me.txt_StoreDesc.TabIndex = 1
        '
        'txt_StoreCode
        '
        Me.txt_StoreCode.BackColor = System.Drawing.Color.Wheat
        Me.txt_StoreCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_StoreCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_StoreCode.Location = New System.Drawing.Point(204, 26)
        Me.txt_StoreCode.MaxLength = 5
        Me.txt_StoreCode.Name = "txt_StoreCode"
        Me.txt_StoreCode.Size = New System.Drawing.Size(117, 21)
        Me.txt_StoreCode.TabIndex = 0
        '
        'lbl_StoreDescription
        '
        Me.lbl_StoreDescription.AutoSize = True
        Me.lbl_StoreDescription.BackColor = System.Drawing.Color.Transparent
        Me.lbl_StoreDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StoreDescription.Location = New System.Drawing.Point(47, 68)
        Me.lbl_StoreDescription.Name = "lbl_StoreDescription"
        Me.lbl_StoreDescription.Size = New System.Drawing.Size(126, 15)
        Me.lbl_StoreDescription.TabIndex = 13
        Me.lbl_StoreDescription.Text = "STORE DESCRIPTION"
        '
        'lbl_StoreCode
        '
        Me.lbl_StoreCode.AutoSize = True
        Me.lbl_StoreCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_StoreCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StoreCode.Location = New System.Drawing.Point(47, 30)
        Me.lbl_StoreCode.Name = "lbl_StoreCode"
        Me.lbl_StoreCode.Size = New System.Drawing.Size(81, 15)
        Me.lbl_StoreCode.TabIndex = 11
        Me.lbl_StoreCode.Text = "STORE CODE"
        '
        'cmdStoreCode
        '
        Me.cmdStoreCode.FlatAppearance.BorderSize = 0
        Me.cmdStoreCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdStoreCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdStoreCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdStoreCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStoreCode.Image = CType(resources.GetObject("cmdStoreCode.Image"), System.Drawing.Image)
        Me.cmdStoreCode.Location = New System.Drawing.Point(329, 23)
        Me.cmdStoreCode.Name = "cmdStoreCode"
        Me.cmdStoreCode.Size = New System.Drawing.Size(23, 26)
        Me.cmdStoreCode.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Opt_Substore)
        Me.GroupBox1.Controls.Add(Me.Opt_Mainstore)
        Me.GroupBox1.Controls.Add(Me.txt_StoreDesc)
        Me.GroupBox1.Controls.Add(Me.cmdStoreCode)
        Me.GroupBox1.Controls.Add(Me.lbl_StoreCode)
        Me.GroupBox1.Controls.Add(Me.lbl_StoreDescription)
        Me.GroupBox1.Controls.Add(Me.txt_StoreCode)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 124)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(437, 160)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 473
        Me.Label1.Text = "STORE TYPE"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(363, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 24)
        Me.Label16.TabIndex = 472
        Me.Label16.Text = "F4"
        '
        'Opt_Substore
        '
        Me.Opt_Substore.BackColor = System.Drawing.Color.Transparent
        Me.Opt_Substore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Substore.Location = New System.Drawing.Point(313, 110)
        Me.Opt_Substore.Name = "Opt_Substore"
        Me.Opt_Substore.Size = New System.Drawing.Size(100, 20)
        Me.Opt_Substore.TabIndex = 3
        Me.Opt_Substore.Text = "SUB STORE"
        Me.Opt_Substore.UseVisualStyleBackColor = False
        '
        'Opt_Mainstore
        '
        Me.Opt_Mainstore.BackColor = System.Drawing.Color.Transparent
        Me.Opt_Mainstore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Mainstore.Location = New System.Drawing.Point(201, 110)
        Me.Opt_Mainstore.Name = "Opt_Mainstore"
        Me.Opt_Mainstore.Size = New System.Drawing.Size(100, 19)
        Me.Opt_Mainstore.TabIndex = 2
        Me.Opt_Mainstore.Text = "MAIN STORE"
        Me.Opt_Mainstore.UseVisualStyleBackColor = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(168, 338)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(319, 25)
        Me.lbl_Freeze.TabIndex = 14
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Freeze.Visible = False
        '
        'chk_excel
        '
        Me.chk_excel.BackColor = System.Drawing.Color.Transparent
        Me.chk_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_excel.Location = New System.Drawing.Point(415, 439)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(72, 24)
        Me.chk_excel.TabIndex = 466
        Me.chk_excel.Text = "Excel"
        Me.chk_excel.UseVisualStyleBackColor = False
        Me.chk_excel.Visible = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Exit.FlatAppearance.BorderSize = 0
        Me.Cmd_Exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(7, 303)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Exit.TabIndex = 8
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_View.FlatAppearance.BorderSize = 0
        Me.Cmd_View.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(7, 159)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_View.TabIndex = 7
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Freeze.FlatAppearance.BorderSize = 0
        Me.Cmd_Freeze.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(7, 111)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Freeze.TabIndex = 6
        Me.Cmd_Freeze.Text = "Void[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Add.FlatAppearance.BorderSize = 0
        Me.Cmd_Add.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(6, 63)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Add.TabIndex = 4
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Clear.FlatAppearance.BorderSize = 0
        Me.Cmd_Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(6, 15)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Clear.TabIndex = 5
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_export.FlatAppearance.BorderSize = 0
        Me.cmd_export.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Image = CType(resources.GetObject("cmd_export.Image"), System.Drawing.Image)
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(7, 255)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(124, 46)
        Me.cmd_export.TabIndex = 16
        Me.cmd_export.Text = "Export[F12]"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        '
        'cmd_rpt
        '
        Me.cmd_rpt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_rpt.BackgroundImage = CType(resources.GetObject("cmd_rpt.BackgroundImage"), System.Drawing.Image)
        Me.cmd_rpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_rpt.FlatAppearance.BorderSize = 0
        Me.cmd_rpt.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_rpt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_rpt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_rpt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_rpt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_rpt.ForeColor = System.Drawing.Color.Black
        Me.cmd_rpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_rpt.Location = New System.Drawing.Point(7, 207)
        Me.cmd_rpt.Name = "cmd_rpt"
        Me.cmd_rpt.Size = New System.Drawing.Size(124, 46)
        Me.cmd_rpt.TabIndex = 467
        Me.cmd_rpt.Text = "Report[F1]"
        Me.cmd_rpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_rpt.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmd_rpt)
        Me.GroupBox2.Controls.Add(Me.cmd_export)
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Location = New System.Drawing.Point(493, 124)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(140, 358)
        Me.GroupBox2.TabIndex = 468
        Me.GroupBox2.TabStop = False
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_auth.FlatAppearance.BorderSize = 0
        Me.cmd_auth.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cmd_auth.ForeColor = System.Drawing.Color.Black
        Me.cmd_auth.Image = CType(resources.GetObject("cmd_auth.Image"), System.Drawing.Image)
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.Location = New System.Drawing.Point(500, 488)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(124, 46)
        Me.cmd_auth.TabIndex = 469
        Me.cmd_auth.Text = "Authorize"
        Me.cmd_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_auth.UseVisualStyleBackColor = False
        Me.cmd_auth.Visible = False
        '
        'Store_Master
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(644, 532)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmd_auth)
        Me.Controls.Add(Me.chk_excel)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Store_Master"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MASTER[STORE MASTER]"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    'FINAL
    Dim dr As DataRow
    Dim dc As DataColumn
    Dim pageno As Integer
    Dim pagesize As Integer

    Private Sub Store_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True

        txt_StoreCode.Enabled = True
        txt_StoreCode.ReadOnly = False
        txt_StoreDesc.ReadOnly = False
        Opt_Substore.Checked = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        StoreMasterbool = True
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            strSQL = " INSERT INTO StoreMaster (Storecode,Storedesc,StoreStatus,Freeze,Adduser,Adddate)"
            strSQL = strSQL & " VALUES ( '" & Trim(txt_StoreCode.Text) & "','" & Replace(Trim(txt_StoreDesc.Text), "'", "") & "',"
            strSQL = strSQL & " '" & IIf(Opt_Mainstore.Checked = True, "M", "S") & "',"
            strSQL = strSQL & " 'N','" & Trim(gUsername) & "',getDate())"
            gconnection.dataOperation(1, strSQL, "StoreMaster")
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update [F7]" Then
            Call checkValidationU() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                End If
            End If
            strSQL = "UPDATE  StoreMaster "
            strSQL = strSQL & " SET Storedesc='" & Replace(Trim(txt_StoreDesc.Text), "'", "") & "',StoreStatus = '" & IIf(Opt_Mainstore.Checked = True, "M", "S") & "',"
            strSQL = strSQL & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME=getDate(),Freeze='N'"
            strSQL = strSQL & " WHERE Storecode = '" & Trim(txt_StoreCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "StoreMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"

        End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidationD() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
            sqlstring = "UPDATE  StoreMaster "
            sqlstring = sqlstring & " SET Freeze= 'Y',voiduser='" & gUsername & " ', voiddate=getDate()"
            sqlstring = sqlstring & " WHERE Storecode = '" & Trim(txt_StoreCode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "StoreMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        Else
            sqlstring = "UPDATE  StoreMaster "
            sqlstring = sqlstring & " SET Freeze= 'N',Adduser='" & gUsername & " ', Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " WHERE Storecode = '" & Trim(txt_StoreCode.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "StoreMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        Cmd_Freeze.Enabled = True
        txt_StoreCode.Enabled = True
        txt_StoreCode.ReadOnly = False
        txt_StoreDesc.ReadOnly = False
        Opt_Substore.Checked = True
        Me.txt_StoreCode.Text = ""
        Me.txt_StoreDesc.Text = ""

        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txt_StoreCode.Focus()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Store Master"
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

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        'gPrint = False
        ''If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Store Master") = MsgBoxResult.Yes Then
        'Dim rViewer As New Viewer
        'Dim sqlstring, SSQL As String
        'Dim r As New Rpt_StoreMaster
        'sqlstring = "SELECT * FROM storemaster order by Storedesc  "
        'gconnection.getDataSet(sqlstring, "storemaster")
        'If gdataset.Tables("storemaster").Rows.Count > 0 Then
        '    If chk_excel.Checked = True Then
        '        Dim exp As New exportexcel
        '        exp.Show()
        '        Call exp.export(sqlstring, "STORE MASTER ", "")
        '    Else
        '        rViewer.ssql = sqlstring
        '        rViewer.Report = r
        '        rViewer.TableName = "storemaster"
        '        Dim textobj1 As TextObject
        '        textobj1 = r.ReportDefinition.ReportObjects("Text13")
        '        textobj1.Text = MyCompanyName
        '        Dim textobj2 As TextObject
        '        textobj2 = r.ReportDefinition.ReportObjects("Text21")
        '        textobj2.Text = gUsername
        '        rViewer.Show()
        '    End If
        'Else
        '    MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        'End If
        ''Else
        '' PRINTOPERATION()
        '' End If
        Dim FRM As New ReportDesigner
        If txt_StoreCode.Text.Length > 0 Then
            tables = " FROM storemaster WHERE storecode ='" & txt_StoreCode.Text & "' "
        Else
            tables = "FROM storemaster "
        End If
        Gheader = "STOREMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"STORECODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"STOREDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"STORESTATUS", "20"}
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

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Store_Master_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
            Call Cmd_Freeze_Click(Cmd_Freeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 And Cmd_View.Visible = True Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F12 And Cmd_View.Visible = True Then
            Call cmd_export_Click(cmd_export, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F1 And Cmd_View.Visible = True Then
            Call cmd_rpt_Click(cmd_rpt, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F10 Then
            'Call cmd_Print_Click(cmd_auth, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F4 Then
            Call cmdStoreCode_Click(cmdStoreCode, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub

    Private Sub cmdStoreCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStoreCode.Click
        gSQLString = "SELECT ISNULL(STORECODE,'') AS STORECODE,ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER"
        If Opt_Mainstore.Checked = True Then
            M_WhereCondition = " where storestatus='M'"
        ElseIf Opt_Substore.Checked = True Then
            M_WhereCondition = " where storestatus='S'"
        Else
            M_WhereCondition = " "
        End If

        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_StoreCode.Text = Trim(vform.keyfield & "")
            Call txt_StoreCode_Validated(txt_StoreCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_StoreCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_StoreCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdStoreCode.Enabled = True Then
                If txt_StoreCode.Text = "" Then
                    search = Trim(txt_StoreCode.Text)
                    Call cmdStoreCode_Click(cmdStoreCode, e)
                End If

            End If
        End If
    End Sub

    Private Sub txt_StoreDesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_StoreDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Opt_Mainstore.Focus()
        End If
    End Sub

    Private Sub txt_StoreCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_StoreCode.Validated
        If Trim(txt_StoreCode.Text) <> "" Then
            sqlstring = "SELECT ISNULL(STORECODE,'') AS STORECODE,ISNULL(STOREDESC,'') AS STOREDESC,ISNULL(STORESTATUS,'') AS STORESTATUS,ISNULL(FREEZE,'') AS FREEZE,ADDDATE FROM StoreMaster WHERE storecode='" & Trim(txt_StoreCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "StoreMaster")
            If gdataset.Tables("StoreMaster").Rows.Count > 0 Then
                txt_StoreCode.Text = Trim(gdataset.Tables("StoreMaster").Rows(0).Item("STORECODE"))
                txt_StoreDesc.Text = Trim(gdataset.Tables("StoreMaster").Rows(0).Item("STOREDESC"))
                If gdataset.Tables("StoreMaster").Rows(0).Item("FREEZE") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("StoreMaster").Rows(0).Item("ADDDATE")), "dd/MMM/yyyy")
                    ' JH
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_Add.Enabled = False
                    'Me.Cmd_Freeze.Enabled = True
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Trim(gdataset.Tables("StoreMaster").Rows(0).Item("STORESTATUS")) = "M" Then
                    Opt_Mainstore.Checked = True
                Else
                    Opt_Substore.Checked = True
                End If
                Me.Cmd_Add.Text = "Update [F7]"
                txt_StoreCode.ReadOnly = True
                txt_StoreDesc.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txt_StoreCode.ReadOnly = False
                txt_StoreDesc.Focus()
            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Else
            txt_StoreCode.Text = ""
            txt_StoreDesc.Focus()
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(txt_StoreCode.Text) = "" Then
            MessageBox.Show(" Store Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_StoreCode.Focus()
            Exit Sub
        End If
        If Len(txt_StoreCode.Text) < 3 Then
            MessageBox.Show(" Store Code Length should be three char", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_StoreCode.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(txt_StoreDesc.Text) = "" Then
            MessageBox.Show(" Store Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_StoreDesc.Focus()
            Exit Sub
        End If
        ''''*********** Check For P.K. ********************************
        sqlstring = "select storecode from storemaster where storecode='" & txt_StoreCode.Text & "'"
        gconnection.getDataSet(sqlstring, "storemaster")
        If gdataset.Tables("storemaster").Rows.Count > 0 Then
            MessageBox.Show("Sorry ! Storecode already Exists")
            txt_StoreCode.Text = ""
            txt_StoreCode.Focus()
            Exit Sub
        End If
        sqlstring = "select distinct costcentercode from ACCOUNTSCOSTCENTERMASTER where costcentercode='" & txt_StoreCode.Text & "'"
        gconnection.getDataSet(sqlstring, "storemaster")
        If gdataset.Tables("storemaster").Rows.Count > 0 Then
            MessageBox.Show("Sorry ! Cost Center already Exists")
            txt_StoreCode.Text = ""
            txt_StoreCode.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Public Sub checkValidationD()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(txt_StoreCode.Text) = "" Then
            MessageBox.Show(" Store Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_StoreCode.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(txt_StoreDesc.Text) = "" Then
            MessageBox.Show(" Store Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_StoreDesc.Focus()
            Exit Sub
        End If
        ''''*********** Check For P.K. ********************************
        'sqlstring = "select storecode from storemaster where storecode='" & txt_StoreCode.Text & "'"
        'gconnection.getDataSet(sqlstring, "storemaster")
        'If gdataset.Tables("storemaster").Rows.Count > 0 Then
        '    MessageBox.Show("Sorry ! Storecode already Exists")
        '    txt_StoreCode.Text = ""
        '    txt_StoreCode.Focus()
        '    Exit Sub
        'End If
        boolchk = True
    End Sub
    Private Sub Store_Master_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        StoreMasterbool = False
    End Sub

    Private Sub Opt_Mainstore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Opt_Mainstore.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmd_Add.Focus()
        End If
    End Sub

    Private Sub txt_StoreCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_StoreCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_StoreCode.Text) = "" Then
                Call cmdStoreCode_Click(cmdStoreCode, e)
            Else
                txt_StoreCode_Validated(txt_StoreCode, e)
            End If
        End If
    End Sub

    'Private Sub cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_auth.Click
    '    gPrint = True
    '    Dim rViewer As New Viewer
    '    Dim sqlstring, SSQL As String
    '    Dim r As New Rpt_StoreMaster
    '    sqlstring = "SELECT * FROM storemaster order by Storedesc  "
    '    gconnection.getDataSet(sqlstring, "storemaster")
    '    If gdataset.Tables("storemaster").Rows.Count > 0 Then
    '        rViewer.ssql = sqlstring
    '        rViewer.Report = r
    '        rViewer.TableName = "storemaster"
    '        Dim textobj1 As TextObject
    '        textobj1 = r.ReportDefinition.ReportObjects("Text13")
    '        textobj1.Text = MyCompanyName
    '        Dim textobj2 As TextObject
    '        textobj2 = r.ReportDefinition.ReportObjects("Text21")
    '        textobj2.Text = MyCompanyName
    '        rViewer.Show()
    '    Else
    '        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
    '    End If
    '    'PRINTOPERATION()
    'End Sub

    Private Sub PRINTOPERATION()
        Dim x, docno, printline As String
        Dim I As Integer
        Dim booldocno As Boolean
        Dim total(10) As Double
        Dim vsubheader() As String = {"DOC NO. : ", "DOC DATE : ", "MAIN STORE CODE : ", "MAIN STORE NAME : ", "TO STORE CODE  : ", "TO STORE NAME :"}
        Dim PAGEHEADING() As String = {"STORE MASTER"}
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            sqlstring = "SELECT STORECODE,STOREDESC,STORESTATUS,FREEZE FROM STOREMASTER ORDER BY STORECODE"
            gconnection.getDataSet(sqlstring, "INVENTORYSTOREMASTER")
            Call Print_Headers(PAGEHEADING)
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            For Each dr In gdataset.Tables("INVENTORYSTOREMASTER").Rows
                Filewrite.WriteLine("|{0,-15}|{1,-40}|{2,10}|{3,10}|", Mid(dr.Item("STORECODE"), 1, 15), Mid(dr.Item("STOREDESC"), 1, 40), Mid(dr.Item("STORESTATUS"), 1, 10), Mid(dr.Item("FREEZE"), 1, 10))
                pagesize = pagesize + 1
                If pagesize > 58 Then
                    Filewrite.Write(StrDup(80, "-"))
                    Filewrite.Write(Chr(12))
                    pageno = pageno + 1
                    Call Print_Headers(PAGEHEADING)
                    Filewrite.WriteLine()
                    pagesize = pagesize + 1
                End If
            Next dr
            Filewrite.WriteLine(StrDup(80, "-"))
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Sub
        End Try
    End Sub

    Private Function Print_Headers(ByVal pageheading() As String)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine(Chr(18))
            Filewrite.WriteLine("{0,40}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MMM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,1}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(pageheading(0)), 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-1}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(pageheading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,70}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(80, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("|{0,-15}|{1,-40}|{2,10}|{3,10}|", "STORECODE", "STORE DESCRIPTION", "STATUS", "FREEZE")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(80, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "storemaster"
        sqlstring = "select * from storemaster"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start(AppPath & "/STUDY/STOREMASTER.XLS")
    End Sub



    Private Sub cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmd_rpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_rpt.Click
        gPrint = False
        'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Store Master") = MsgBoxResult.Yes Then
        Dim rViewer As New Viewer
        Dim sqlstring, SSQL As String
        Dim r As New Rpt_StoreMaster
        sqlstring = "SELECT * FROM storemaster order by Storedesc  "
        gconnection.getDataSet(sqlstring, "storemaster")
        If gdataset.Tables("storemaster").Rows.Count > 0 Then
            If chk_excel.Checked = True Then
                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "STORE MASTER ", "")
            Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "storemaster"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text21")
                textobj2.Text = gUsername
                If MyCompanyName = "THE BENGAL CLUB" Then
                    Dim textobj3 As TextObject
                    textobj3 = r.ReportDefinition.ReportObjects("Text27")
                    textobj3.Text = ""
                End If
                rViewer.Show()
            End If
        Else
            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        End If
        'Else
        ' PRINTOPERATION()
        ' End If
    End Sub

    Private Sub txt_StoreDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_StoreDesc.TextChanged

    End Sub

    Private Sub txt_StoreCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_StoreCode.TextChanged

    End Sub

    Public Sub checkValidationU()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(txt_StoreCode.Text) = "" Then
            MessageBox.Show(" Store Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_StoreCode.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(txt_StoreDesc.Text) = "" Then
            MessageBox.Show(" Store Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_StoreDesc.Focus()
            Exit Sub
        End If


        sqlstring = "select * from closingqty where storecode='" & Trim(txt_StoreCode.Text) & "' "
        gconnection.getDataSet(sqlstring, "inv1")
        If gdataset.Tables("inv1").Rows.Count > 0 Then
            MessageBox.Show(" Store already used in transaction u can't be update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_StoreCode.Focus()
            Exit Sub
        End If


        ' ''''*********** Check For P.K. ********************************
        'sqlstring = "select storecode from storemaster where storecode='" & txt_StoreCode.Text & "'"
        'gconnection.getDataSet(sqlstring, "storemaster")
        'If gdataset.Tables("storemaster").Rows.Count > 0 Then
        '    MessageBox.Show("Sorry ! Storecode already Exists")
        '    txt_StoreCode.Text = ""
        '    txt_StoreCode.Focus()
        '    Exit Sub
        'End If
        boolchk = True
    End Sub

    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 780
        K = 1044
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
                        If Controls(i_i).Name = "GroupBox2" Then
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
                        ElseIf Controls(i_i).Name = "GroupBox4" Then
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

    Private Sub cmd_auth_Click(sender As Object, e As EventArgs) Handles cmd_auth.Click
        Authocheck("INVENTORY", "Store Master", gUsername, "StoreMaster", "Storecode", Me)

    End Sub

    Private Sub Opt_Mainstore_CheckedChanged(sender As Object, e As EventArgs) Handles Opt_Mainstore.CheckedChanged

    End Sub

    Private Sub Opt_Substore_CheckedChanged(sender As Object, e As EventArgs) Handles Opt_Substore.CheckedChanged

    End Sub
End Class
