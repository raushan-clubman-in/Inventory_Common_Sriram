Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Public Class Category_Master
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
    Friend WithEvents txt_CATEGORYDesc As System.Windows.Forms.TextBox
    Friend WithEvents txt_CATEGORYCode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_StoreDescription As System.Windows.Forms.Label
    Friend WithEvents lbl_StoreCode As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmdStoreCode As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents cmd_rpt As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RDO_WEIGHTED As System.Windows.Forms.RadioButton
    Friend WithEvents RDO_PURCHASE As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents UserCheckList As System.Windows.Forms.CheckedListBox
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Category_Master))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.txt_CATEGORYDesc = New System.Windows.Forms.TextBox()
        Me.txt_CATEGORYCode = New System.Windows.Forms.TextBox()
        Me.lbl_StoreDescription = New System.Windows.Forms.Label()
        Me.lbl_StoreCode = New System.Windows.Forms.Label()
        Me.cmdStoreCode = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.UserCheckList = New System.Windows.Forms.CheckedListBox()
        Me.RDO_WEIGHTED = New System.Windows.Forms.RadioButton()
        Me.RDO_PURCHASE = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.cmd_rpt = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.lbl_Heading.Location = New System.Drawing.Point(246, 20)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(209, 22)
        Me.lbl_Heading.TabIndex = 9
        Me.lbl_Heading.Text = "CATEGORY  MASTER"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_CATEGORYDesc
        '
        Me.txt_CATEGORYDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_CATEGORYDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_CATEGORYDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CATEGORYDesc.Location = New System.Drawing.Point(193, 94)
        Me.txt_CATEGORYDesc.MaxLength = 50
        Me.txt_CATEGORYDesc.Name = "txt_CATEGORYDesc"
        Me.txt_CATEGORYDesc.Size = New System.Drawing.Size(225, 21)
        Me.txt_CATEGORYDesc.TabIndex = 1
        '
        'txt_CATEGORYCode
        '
        Me.txt_CATEGORYCode.BackColor = System.Drawing.Color.Wheat
        Me.txt_CATEGORYCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_CATEGORYCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CATEGORYCode.Location = New System.Drawing.Point(193, 52)
        Me.txt_CATEGORYCode.MaxLength = 5
        Me.txt_CATEGORYCode.Name = "txt_CATEGORYCode"
        Me.txt_CATEGORYCode.Size = New System.Drawing.Size(88, 21)
        Me.txt_CATEGORYCode.TabIndex = 0
        '
        'lbl_StoreDescription
        '
        Me.lbl_StoreDescription.AutoSize = True
        Me.lbl_StoreDescription.BackColor = System.Drawing.Color.Transparent
        Me.lbl_StoreDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StoreDescription.Location = New System.Drawing.Point(28, 94)
        Me.lbl_StoreDescription.Name = "lbl_StoreDescription"
        Me.lbl_StoreDescription.Size = New System.Drawing.Size(148, 15)
        Me.lbl_StoreDescription.TabIndex = 13
        Me.lbl_StoreDescription.Text = "CATEGORY DESCRIPTION"
        '
        'lbl_StoreCode
        '
        Me.lbl_StoreCode.AutoSize = True
        Me.lbl_StoreCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_StoreCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StoreCode.Location = New System.Drawing.Point(28, 52)
        Me.lbl_StoreCode.Name = "lbl_StoreCode"
        Me.lbl_StoreCode.Size = New System.Drawing.Size(103, 15)
        Me.lbl_StoreCode.TabIndex = 11
        Me.lbl_StoreCode.Text = "CATEGORY CODE"
        '
        'cmdStoreCode
        '
        Me.cmdStoreCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStoreCode.Image = CType(resources.GetObject("cmdStoreCode.Image"), System.Drawing.Image)
        Me.cmdStoreCode.Location = New System.Drawing.Point(287, 52)
        Me.cmdStoreCode.Name = "cmdStoreCode"
        Me.cmdStoreCode.Size = New System.Drawing.Size(23, 26)
        Me.cmdStoreCode.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.UserCheckList)
        Me.GroupBox1.Controls.Add(Me.RDO_WEIGHTED)
        Me.GroupBox1.Controls.Add(Me.RDO_PURCHASE)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmdStoreCode)
        Me.GroupBox1.Controls.Add(Me.lbl_StoreCode)
        Me.GroupBox1.Controls.Add(Me.lbl_StoreDescription)
        Me.GroupBox1.Controls.Add(Me.txt_CATEGORYCode)
        Me.GroupBox1.Controls.Add(Me.txt_CATEGORYDesc)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(50, 119)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 418)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'UserCheckList
        '
        Me.UserCheckList.CheckOnClick = True
        Me.UserCheckList.FormattingEnabled = True
        Me.UserCheckList.Location = New System.Drawing.Point(193, 177)
        Me.UserCheckList.MultiColumn = True
        Me.UserCheckList.Name = "UserCheckList"
        Me.UserCheckList.Size = New System.Drawing.Size(229, 229)
        Me.UserCheckList.TabIndex = 4
        '
        'RDO_WEIGHTED
        '
        Me.RDO_WEIGHTED.AutoSize = True
        Me.RDO_WEIGHTED.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDO_WEIGHTED.Location = New System.Drawing.Point(315, 137)
        Me.RDO_WEIGHTED.Name = "RDO_WEIGHTED"
        Me.RDO_WEIGHTED.Size = New System.Drawing.Size(117, 19)
        Me.RDO_WEIGHTED.TabIndex = 3
        Me.RDO_WEIGHTED.TabStop = True
        Me.RDO_WEIGHTED.Text = "WEIGHTED RATE"
        Me.RDO_WEIGHTED.UseVisualStyleBackColor = True
        '
        'RDO_PURCHASE
        '
        Me.RDO_PURCHASE.AutoSize = True
        Me.RDO_PURCHASE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDO_PURCHASE.Location = New System.Drawing.Point(193, 136)
        Me.RDO_PURCHASE.Name = "RDO_PURCHASE"
        Me.RDO_PURCHASE.Size = New System.Drawing.Size(120, 19)
        Me.RDO_PURCHASE.TabIndex = 2
        Me.RDO_PURCHASE.TabStop = True
        Me.RDO_PURCHASE.Text = "PURCHASE RATE"
        Me.RDO_PURCHASE.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 15)
        Me.Label3.TabIndex = 479
        Me.Label3.Text = "RATE TYPE"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(326, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 24)
        Me.Label16.TabIndex = 472
        Me.Label16.Text = "F4"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(153, 554)
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
        Me.chk_excel.Location = New System.Drawing.Point(517, 554)
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
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(11, 309)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Exit.TabIndex = 8
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_auth.ForeColor = System.Drawing.Color.Black
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.Location = New System.Drawing.Point(13, 256)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(124, 46)
        Me.cmd_auth.TabIndex = 8
        Me.cmd_auth.Text = "Authorize"
        Me.cmd_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_auth.UseVisualStyleBackColor = False
        Me.cmd_auth.Visible = False
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
        Me.Cmd_View.Location = New System.Drawing.Point(10, 112)
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
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(10, 161)
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
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(9, 63)
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
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(9, 14)
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
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Image = CType(resources.GetObject("cmd_export.Image"), System.Drawing.Image)
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(11, 260)
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
        Me.cmd_rpt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_rpt.ForeColor = System.Drawing.Color.Black
        Me.cmd_rpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_rpt.Location = New System.Drawing.Point(10, 210)
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
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.cmd_rpt)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Controls.Add(Me.cmd_export)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.cmd_auth)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Location = New System.Drawing.Point(507, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(140, 364)
        Me.GroupBox2.TabIndex = 468
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(519, 491)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 46)
        Me.Button1.TabIndex = 469
        Me.Button1.Text = "Authorize"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Category_Master
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(701, 629)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chk_excel)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Category_Master"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CATEGORY MASTER"
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
    Dim RATEFLAG As String
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 734
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



    Private Sub bindchecklist()
        UserCheckList.Items.Clear()
        '  Dim sqlstring = "SELECT DISTINCT USERNAME,CATEGORY FROM UserAdmin where Maingroup='Inventory'"
        Dim sqlstring = "  SELECT DISTINCT USERNAME,CATEGORY FROM UserAdmin where Maingroup='Inventory'"
        sqlstring = sqlstring & "    union "
        sqlstring = sqlstring & "  SELECT DISTINCT USERNAME,CATEGORY FROM UserAdmin where category='S'"
        ''sqlstring = sqlstring & "    union "
        '' sqlstring = sqlstring & "  SELECT DISTINCT USERNAME,CATEGORY FROM MASTER..UserAdmin where category='S'"

        gconnection.getDataSet(sqlstring, "UserAdmin")
        If (gdataset.Tables("UserAdmin").Rows.Count > 0) Then
            For i As Integer = 0 To gdataset.Tables("UserAdmin").Rows.Count - 1
                UserCheckList.Items.Add(gdataset.Tables("UserAdmin").Rows(i).Item("USERNAME"))

            Next
        End If

    End Sub

    Private Sub insertcheckeduser()
        Dim insert(0) As String

        For i As Integer = 0 To UserCheckList.CheckedItems.Count - 1
            Dim sql As String = "Insert into Categoryuserdetail(categorycode,Usercode,void,adddate,adduser)"
            sql = sql & " values('" & Trim(txt_CATEGORYCode.Text) & "','" & UserCheckList.CheckedItems(i) & "','N',GETDATE(),'" + Trim(gUsername) + "') "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sql

        Next
        gconnection.MoreTrans2(insert)
    End Sub
    Private Sub updatecheckeduser()
        Dim insert(0) As String


        Dim sql As String = "Update Categoryuserdetail set void='Y',Updatedate=GETDATE(),Updateuser='" + Trim(gUsername) + "'"
        sql = sql & " where categorycode='" & Trim(txt_CATEGORYCode.Text) & "' "
        gconnection.dataOperation(6, sql, "Categoryuserdetail")



    End Sub

    Private Sub updatecheckeduser1()
        Dim insert(0) As String


        Dim sql As String = "Update Categoryuserdetail set void='N',Updatedate=GETDATE(),Updateuser='" + Trim(gUsername) + "'"
        sql = sql & " where categorycode='" & Trim(txt_CATEGORYCode.Text) & "' "
        gconnection.dataOperation(6, sql, "Categoryuserdetail")



    End Sub
    Private Sub voidcheckeduser()
        Dim sql As String = "Update Categoryuserdetail set void='Y',Voiddate=GETDATE(),Voiduser='" + Trim(gUsername) + "'"
        sql = sql & " where categorycode='" & Trim(txt_CATEGORYCode.Text) & "' "
        gconnection.dataOperation(6, sql, "Categoryuserdetail")

    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            strSQL = " INSERT INTO inventorycategorymaster (categorycode,categorydesc,Freeze,Adduser,Adddate,RATEflag)"
            strSQL = strSQL & " VALUES ( '" & Trim(txt_CATEGORYCode.Text) & "','" & Replace(Trim(txt_CATEGORYDesc.Text), "'", "") & "',"
            strSQL = strSQL & "'N',"
            strSQL = strSQL & " '" & Trim(gUsername) & "',GETDATE(),"
            If RDO_WEIGHTED.Checked = True Then
                strSQL = strSQL & "'W')"
            ElseIf RDO_PURCHASE.Checked = True Then
                strSQL = strSQL & "'P')"
            End If

            'strSQL = strSQL & "'" & Trim(TXT_CATFLAG.Text) & "')"
            gconnection.dataOperation(1, strSQL, "inventorycategorymaster")
            insertcheckeduser()
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then






            Call checkValidationU() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                End If
            End If
            If boolchk = False Then Exit Sub
            If (RATEFLAG = "W" And RDO_PURCHASE.Checked = True) Or (RATEFLAG = "P" And RDO_WEIGHTED.Checked = True) Then

                If MsgBox(" U have change RATEFLAG  do U want  Manual Update for this category ......", MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton2, "Stock Update") = MsgBoxResult.Ok Then
                    Me.Cursor = Cursors.WaitCursor
                    gconnection.valuation()
                    Me.Cursor = Cursors.Default
                Else
                    ' MsgBox("Update Cancelled Try Again......", MsgBoxStyle.OkOnly, "Stock Update")
                    Exit Sub
                End If

            End If
            If boolchk = False Then Exit Sub
            strSQL = "UPDATE  inventorycategorymaster "
            strSQL = strSQL & " SET categorydesc='" & Replace(Trim(txt_CATEGORYDesc.Text), "'", "") & "',"
            strSQL = strSQL & " updateUSER='" & Trim(gUsername) & "',UPDATEDATE=GETDATE(),Freeze='N',"
            If RDO_WEIGHTED.Checked = True Then
                strSQL = strSQL & " RATEFLAG='W' "
            ElseIf RDO_PURCHASE.Checked = True Then
                strSQL = strSQL & " RATEFLAG='P' "

            End If
            'strSQL = strSQL & " categoryflag='" & Replace(Trim(TXT_CATFLAG.Text), "'", "") & "'"
            strSQL = strSQL & " WHERE CATEGORYCODE = '" & Trim(txt_CATEGORYCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "inventorycategorymaster")
            updatecheckeduser()

            insertcheckeduser()

            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"

        End If

    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
            sqlstring = "UPDATE  inventorycategorymaster "
            sqlstring = sqlstring & " SET Freeze= 'Y',voiduser='" & gUsername & " ', voiddate=GETDATE() "
            sqlstring = sqlstring & " WHERE CATEGORYCODE = '" & Trim(txt_CATEGORYCode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "inventorycategorymaster")
            updatecheckeduser()
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        Else
            sqlstring = "UPDATE  inventorycategorymaster "
            sqlstring = sqlstring & " SET Freeze= 'N',voiduser='" & gUsername & " ', voiddate=GETDATE() "
            sqlstring = sqlstring & " WHERE CATEGORYCODE = '" & Trim(txt_CATEGORYCode.Text) & "'"
            gconnection.dataOperation(6, sqlstring, "inventorycategorymaster")
            updatecheckeduser1()
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
            'Else
            '    sqlstring = "UPDATE  StoreMaster "
            '    sqlstring = sqlstring & " SET Freeze= 'N',Adduser='" & gUsername & " ', Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
            '    sqlstring = sqlstring & " WHERE Storecode = '" & Trim(txt_StoreCode.Text) & "'"
            '    gconnection.dataOperation(4, sqlstring, "StoreMaster")
            '    Me.Cmd_Clear_Click(sender, e)
            '    Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        Cmd_Freeze.Enabled = True
        ' txt_CATEGORYCode.Enabled = True
        'txt_CATEGORYCode.ReadOnly = False
        txt_CATEGORYDesc.ReadOnly = False
        'TXT_CATFLAG.Text = ""
        txt_CATEGORYCode.Text = ""
        txt_CATEGORYDesc.Text = ""

        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True

        UserCheckList.Items.Clear()
        bindchecklist()
        'TXT_USERNAME.Text = ""
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        RDO_PURCHASE.Checked = False
        RDO_WEIGHTED.Checked = False

        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
        txt_CATEGORYCode.Focus()
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Category Master"

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
        Me.cmd_auth.Enabled = False
        Me.cmd_rpt.Enabled = False
        Me.cmd_export.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Me.cmd_auth.Enabled = True
                    Me.cmd_rpt.Enabled = True
                    Me.cmd_export.Enabled = True
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
                    Me.cmd_rpt.Enabled = True
                    Me.cmd_export.Enabled = True
                End If
                If Right(x) = "U" Then
                    Me.cmd_auth.Enabled = True
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
        If txt_CATEGORYCode.Text.Length > 0 Then
            tables = " FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE ='" & txt_CATEGORYCode.Text & "' "
        Else
            tables = "FROM INVENTORYCATEGORYMASTER "
        End If
        Gheader = "INVENTORYCATEGORYMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"CATEGORYCODE", "13"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CATEGORYDESC", "30"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"USERNAME", "30"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"CATEGORYFLAG", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"RATEFLAG", "9"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Freeze", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adduser", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adddate", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"VOIDUSER", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"VOIDDATE", "11"}
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
        If e.KeyCode = Keys.F10 And cmd_rpt.Visible = True Then
            cmd_rpt_Click(cmd_rpt, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F4 Then
            Call cmdStoreCode_Click(cmdStoreCode, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F1 And cmd_rpt.Enabled = True Then
            Call cmd_rpt_Click(cmd_rpt, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F12 And cmd_export.Enabled = True Then
            Call cmd_export_Click(cmd_export, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub

    Private Sub cmdStoreCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStoreCode.Click
        gSQLString = "SELECT distinct ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER"
        M_WhereCondition = ""
        Dim vform As New ListOperattion1
        vform.Field = "CATEGORYDESC,CATEGORYCODE"
        vform.vFormatstring = "         CATEGORY CODE              |                  CATEGORY DESCRIPTION                                                                                                   "
        vform.vCaption = "CATEGORY MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_CATEGORYCode.Text = Trim(vform.keyfield & "")
            Call txt_StoreCode_Validated(txt_CATEGORYCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_StoreCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_CATEGORYCode.KeyDown
        'If e.KeyCode = Keys.F4 Then
        '    If cmdStoreCode.Enabled = True Then
        '        search = Trim(txt_CATEGORYCode.Text)
        '        'Call cmdStoreCode_Click(cmdStoreCode, e)
        '    End If
        'End If
    End Sub

    Private Sub txt_StoreDesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_CATEGORYDesc.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    Opt_Mainstore.Focus()
        'End If
    End Sub

    Private Sub txt_StoreCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_CATEGORYCode.Validated
        Dim rate As String
        If Trim(txt_CATEGORYCode.Text) <> "" Then
            sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC,ISNULL(FREEZE,'') AS FREEZE,ADDDATE, ISNULL(RATEFLAG,'') AS RATEFLAG,voiddate FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" & Trim(txt_CATEGORYCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "INVENTORYCATEGORYMASTER")
            If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0 Then
                txt_CATEGORYCode.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYCODE"))
                txt_CATEGORYDesc.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                'TXT_CATFLAG.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYFLAG"))
                rate = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("rateflag"))
                If rate = "W" Then
                    RDO_WEIGHTED.Checked = True
                    RATEFLAG = "W"
                ElseIf rate = "P" Then
                    RDO_PURCHASE.Checked = True
                    RATEFLAG = "P"
                End If

                'TXT_USERNAME.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("USERNAME"))
                If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("FREEZE") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("VOIDDATE")), "dd/MMM/yyyy")
                    ' JH
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_Add.Enabled = False
                    Me.Cmd_Freeze.Enabled = True
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                End If
                UserCheckList.Items.Clear()
                bindchecklist()
                sqlstring = "select Usercode from Categoryuserdetail where CATEGORYCODE='" & Trim(txt_CATEGORYCode.Text) & "' and isnull(void,'')='N'"
                gconnection.getDataSet(sqlstring, "Categoryuserdetail")
                Dim TYPE As String
                Dim Usercode As String
                If (gdataset.Tables("Categoryuserdetail").Rows.Count > 0) Then
                    For k As Integer = 0 To gdataset.Tables("Categoryuserdetail").Rows.Count - 1
                        Usercode = Trim(gdataset.Tables("Categoryuserdetail").Rows(k).Item("Usercode"))
                        For m As Integer = 0 To UserCheckList.Items.Count - 1
                            TYPE = UserCheckList.Items(m)
                            If TYPE = Usercode Then
                                UserCheckList.SetItemChecked(m, True)
                            End If
                        Next m
                    Next k
                End If

                'If Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("STORESTATUS")) = "M" Then
                '    Opt_Mainstore.Checked = True
                'Else
                '    Opt_Substore.Checked = True
                'End If
                Me.Cmd_Add.Text = "Update[F7]"
                '    txt_CATEGORYCode.ReadOnly = True
                '   txt_CATEGORYDesc.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                '  txt_CATEGORYCode.ReadOnly = False
                ' txt_CATEGORYDesc.Focus()
            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Else
            ' txt_CATEGORYCode.Text = ""
            'txt_CATEGORYDesc.Focus()
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  CATEGORY Code Can't be blank *********************'''
        If Trim(txt_CATEGORYCode.Text) = "" Then
            MessageBox.Show(" Category Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CATEGORYCode.Focus()
            Exit Sub
        End If
        '''********** Check  CATEGORY desc Can't be blank *********************'''
        If Trim(txt_CATEGORYDesc.Text) = "" Then
            MessageBox.Show(" Category Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CATEGORYDesc.Focus()
            Exit Sub
        End If


        ' '''********** Check  CATEGORY FLAG Can't be blank *********************'''
        'If Trim(TXT_CATFLAG.Text) = "" Then
        '    MessageBox.Show(" Category Flag can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    TXT_CATFLAG.Focus()
        '    Exit Sub
        'End If
        ' '''********** Check  USERNAME Can't be blank *********************'''
        'If Trim(TXT_USERNAME.Text) = "" Then
        '    MessageBox.Show(" User name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    TXT_USERNAME.Focus()
        '    Exit Sub
        'End If
        '*****check for double username***************
        'sqlstring = "select categorycode from INVENTORYCATEGORYMASTER where CATEGORYCODE='" & txt_CATEGORYCode.Text & "'"
        'gconnection.getDataSet(sqlstring, "INVENTORYCATEGORYMASTER")
        'If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0 Then
        '    MessageBox.Show("Sorry! Username already have a category")
        '    Exit Sub
        'End If

        '''********* RATE TYPE CHECK **********************
        If RDO_PURCHASE.Checked = True Then
            boolchk = True
            Exit Sub
        ElseIf RDO_WEIGHTED.Checked = True Then
            boolchk = True
            Exit Sub
        Else
            MessageBox.Show(" Rate Type can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ''**********CHECK FOR CATEGORY CODE AND CATEGORY FLAG**************
        'If Mid(txt_CATEGORYCode.Text, 1, 1) <> Mid(TXT_CATFLAG.Text, 1, 1) Then
        '    MessageBox.Show("Category Flag should be first letter of Category Code")
        '    Exit Sub
        'End If
        boolchk = True
    End Sub
    Private Sub Store_Master_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        StoreMasterbool = False
    End Sub

    Private Sub Opt_Mainstore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Cmd_Add.Focus()
        End If
    End Sub

    Private Sub txt_StoreCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_CATEGORYCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_CATEGORYCode.Text) = "" Then
                Call cmdStoreCode_Click(cmdStoreCode, e)
            Else
                txt_StoreCode_Validated(txt_CATEGORYCode, e)
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
        Dim PAGEHEADING() As String = {"CATEGORY MASTER"}
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            sqlstring = "SELECT CATEGORYCODE,CATEGORYDESC,CATEGORYFLAG,FREEZE FROM INVENTORYCATEGORYMASTER ORDER BY CATEGORYCODE"
            gconnection.getDataSet(sqlstring, "INVENTORYCATEGORYMASTER")
            Call Print_Headers(PAGEHEADING)
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            For Each dr In gdataset.Tables("INVENTORYCATEGORYMASTER").Rows
                Filewrite.WriteLine("|{0,-15}|{1,-40}|{2,10}|{3,10}|", Mid(dr.Item("CATEGORYCODE"), 1, 15), Mid(dr.Item("CATEGORYDESC"), 1, 40), Mid(dr.Item("CATEGORYFLAG"), 1, 10), Mid(dr.Item("FREEZE"), 1, 10))
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
            Filewrite.WriteLine("|{0,-15}|{1,-40}|{2,10}|{3,10}|", "CATEGORYCODE", "CATEGORY DESCRIPTION", "CATEGORYFLAG", "FREEZE")
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
        _export.TABLENAME = "inventorycategorymaster"
        sqlstring = "select * from inventorycategorymaster"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start(AppPath & "/STUDY/STOREMASTER.XLS")
    End Sub

    Private Sub cmd_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_auth.Click
        Authocheck("INVENTORY", "Category Master", gUsername, "INVENTORYCATEGORYMASTER", "CATEGORYCODE", Me)

    End Sub



    Private Sub cmd_rpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_rpt.Click
        gPrint = False
        '  If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Store Master") = MsgBoxResult.Yes Then
        Dim rViewer As New Viewer
        Dim sqlstring, SSQL As String
        Dim r As New RPT_CATEGORYMASTER
        sqlstring = "SELECT DISTINCT  CATEGORYCODE, CATEGORYDESC, FREEZE, RATEFLAG FROM inventorycategorymaster order by CATEGORYCODE  "
        gconnection.getDataSet(sqlstring, "inventorycategorymaster")
        If gdataset.Tables("inventorycategorymaster").Rows.Count > 0 Then
            If chk_excel.Checked = True Then
                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "CATEGORY MASTER ", "")
            Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "inventorycategorymaster"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text10")
                textobj1.Text = MyCompanyName
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text14")
                textobj2.Text = gUsername
                'Dim t1 As TextObject
                't1 = r.ReportDefinition.ReportObjects("Text11")
                't1.Text = gCompanyAddress(0)
                'Dim t2 As TextObject
                't2 = r.ReportDefinition.ReportObjects("Text12")
                't2.Text = gCompanyAddress(1)
                rViewer.Show()
            End If
        Else
            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        End If
        'Else
        '    PRINTOPERATION()
        'End If
    End Sub





    Private Sub TXT_USERNAME_Validated(sender As Object, e As EventArgs)
        Dim RATETYPE As String
        If Trim(txt_CATEGORYCode.Text) <> "" Then
            sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC,ISNULL(CATEGORYFLAG,'') AS CATEGORYFLAG,ISNULL(FREEZE,'') AS FREEZE,ADDDATE, RATEFLAG FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" & Trim(txt_CATEGORYCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "INVENTORYCATEGORYMASTER")
            If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0 Then
                txt_CATEGORYCode.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYCODE"))
                txt_CATEGORYDesc.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
                'TXT_CATFLAG.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYFLAG"))
                'TXT_USERNAME.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("USERNAME"))
                RATETYPE = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("RATETYPE"))
                If RATETYPE = "W" Then
                    RDO_WEIGHTED.Checked = True
                ElseIf RATETYPE = "P" Then
                    RDO_PURCHASE.Checked = True
                End If

                If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("FREEZE") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("VOIDDATE")), "dd/MMM/yyyy")
                    ' JH
                    ' Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Add.Text = "Update[F7]"
                End If
                'If Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("STORESTATUS")) = "M" Then
                '    Opt_Mainstore.Checked = True
                'Else
                '    Opt_Substore.Checked = True
                'End If
                'Me.Cmd_Add.Text = "Update[F7]"
                '   txt_CATEGORYCode.ReadOnly = True
                '  txt_CATEGORYDesc.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                'txt_CATEGORYCode.ReadOnly = False
                txt_CATEGORYCode.Focus()
            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Else
            txt_CATEGORYCode.Text = ""
            txt_CATEGORYCode.Focus()
        End If
    End Sub

    Private Sub CMD_USERBAME_Click(sender As Object, e As EventArgs)
        gSQLString = "SELECT DISTINCT ISNULL(USERNAME,'') AS USERNAME,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER"
        M_WhereCondition = "  "
        Dim vform As New ListOperattion1
        vform.Field = "USERNAME,CATEGORYDESC"
        vform.vFormatstring = "         USERNAME              |                  CATEGORY DESCRIPTION                                                                                                   "
        vform.vCaption = "CATEGORY MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            'TXT_USERNAME.Text = Trim(vform.keyfield & "")
            ' Call TXT_USERNAME_Validated(TXT_USERNAME, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Public Sub checkValidationU()
        boolchk = False
        '''********** Check  CATEGORY Code Can't be blank *********************'''
        If Trim(txt_CATEGORYCode.Text) = "" Then
            MessageBox.Show(" Category Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CATEGORYCode.Focus()
            Exit Sub
        End If
        '''********** Check  CATEGORY desc Can't be blank *********************'''
        If Trim(txt_CATEGORYDesc.Text) = "" Then
            MessageBox.Show(" Category Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CATEGORYDesc.Focus()
            Exit Sub
        End If


        'sqlstring = "select isnull(CATEGORY,'') as CATEGORY from GRN_DETAILS where CATEGORY='" & Trim(txt_CATEGORYCode.Text) & "'  and isnull(voiditem,'N')<>'Y'"
        'gconnection.getDataSet(sqlstring, "inv1")
        'If gdataset.Tables("inv1").Rows.Count > 0 Then
        '    MessageBox.Show("Category  already used in transaction u can't be update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_CATEGORYCode.Focus()
        '    Exit Sub

        'End If



        'sqlstring = "select isnull(CATEGORY,'') as CATEGORY from inv_inventoryitemmaster where CATEGORY='" & Trim(txt_CATEGORYCode.Text) & "'  and isnull(void,'N')<>'Y'"
        'gconnection.getDataSet(sqlstring, "inv1")
        'If gdataset.Tables("inv1").Rows.Count > 0 Then
        '    MessageBox.Show("Category  already used in transaction u can't be update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_CATEGORYCode.Focus()
        '    Exit Sub

        'End If

        'sqlstring = "select isnull(CATEGORYCODE,'') as CATEGORYCODE from InventoryGroupMaster where CATEGORYCODE='" & Trim(txt_CATEGORYCode.Text) & "' and isnull(freeze,'N')<>'Y'"
        'gconnection.getDataSet(sqlstring, "inv1")
        'If gdataset.Tables("inv1").Rows.Count > 0 Then
        '    MessageBox.Show(" Category  already used in transaction u can't be update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '   txt_CATEGORYCode.Focus()
        '    Exit Sub
        'End If

        'sqlstring = "select isnull(category,'') as category from inv_inventoryitemmaster where category='" & Trim(txt_CATEGORYCode.Text) & "'"
        'gconnection.getDataSet(sqlstring, "inv1")
        'If gdataset.Tables("inv1").Rows.Count > 0 Then
        '    MessageBox.Show(" Group Code already exists ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_CATEGORYCode.Text = ""
        '    txt_CATEGORYCode.Focus()
        '    Exit Sub
        'End If
        boolchk = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SSQLSTR, SSQLSTR2 As String
        Dim USERT As Integer
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 1
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 2
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 3
        End If
        If USERT = 1 Then
            SSQLSTR2 = " SELECT * FROM inventorycategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='Inventory' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM inventorycategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE inventorycategorymaster set  ", "Categorycode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM inventorycategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM inventorycategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE inventorycategorymaster set  ", "Categorycode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM inventorycategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM inventorycategorymaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE inventorycategorymaster set  ", "Categorycode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub


    Private Sub RDO_PURCHASE_CheckedChanged(sender As Object, e As EventArgs) Handles RDO_PURCHASE.CheckedChanged

    End Sub

    Private Sub RDO_PURCHASE_ContextMenuChanged(sender As Object, e As EventArgs) Handles RDO_PURCHASE.ContextMenuChanged

    End Sub

    Private Sub Category_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'bindchecklist()
        ''TXT_USERNAME.Enabled = False
        ''TXT_CATFLAG.ReadOnly = False
        ''TXT_USERNAME.ReadOnly = False
        ''txt_CATEGORYCode.Enabled = False
        '' txt_CATEGORYCode.ReadOnly = False
        ''     txt_CATEGORYDesc.ReadOnly = False
        'If gUserCategory <> "S" Then
        '    Call GetRights()
        'End If
        'StoreMasterbool = True
        'txt_CATEGORYCode.Focus()
        Call Cmd_Clear_Click(Cmd_Clear, e)
        'If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
        '    If Licensebool = False Then
        '        gconnection.FocusSetting(Me)
        '        Me.Cmd_Clear.Visible = True
        '        Me.Cmd_Exit.Visible = True
        '    End If
        'End If
        '  txt_CATEGORYCode.Focus()
    End Sub


End Class
