Imports System.Data.SqlClient
Public Class Cock_Tail_Ratio
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
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents grp_Cocktail As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents AxfpSpread1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents AxfpSpread2 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents AxfpSpread3 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents txt_sellingprice As System.Windows.Forms.TextBox
    Friend WithEvents txt_Costprice As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Menuitemcode As System.Windows.Forms.Label
    Friend WithEvents lbl_Itemuom As System.Windows.Forms.Label
    Friend WithEvents lbl_Salerate As System.Windows.Forms.Label
    Friend WithEvents txt_Menucode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Menucodehelp As System.Windows.Forms.Button
    Friend WithEvents lbl_menuname As System.Windows.Forms.Label
    Friend WithEvents txt_Salerate As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Sales As System.Windows.Forms.Label
    Friend WithEvents lbl_Production As System.Windows.Forms.Label
    Friend WithEvents lbl_Vs As System.Windows.Forms.Label
    Friend WithEvents Cbo_Production As System.Windows.Forms.ComboBox
    Friend WithEvents Cbo_Sales As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Uom As System.Windows.Forms.Label
    Friend WithEvents lbl_Costprice As System.Windows.Forms.Label
    Friend WithEvents lbl_Witheffectfrom As System.Windows.Forms.Label
    Friend WithEvents lbl_Sellingprice As System.Windows.Forms.Label
    Friend WithEvents lbl_Profit As System.Windows.Forms.Label
    Friend WithEvents lbl_Remarks As System.Windows.Forms.Label
    Friend WithEvents dtp_Witheffectfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_Menuname As System.Windows.Forms.TextBox
    Friend WithEvents txt_Profitamt As System.Windows.Forms.TextBox
    Friend WithEvents txt_Profitper As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_Itemuom As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cock_Tail_Ratio))
        Me.txt_Remarks = New System.Windows.Forms.TextBox()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.grp_Cocktail = New System.Windows.Forms.GroupBox()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.txt_sellingprice = New System.Windows.Forms.TextBox()
        Me.txt_Costprice = New System.Windows.Forms.TextBox()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.lbl_Menuitemcode = New System.Windows.Forms.Label()
        Me.lbl_Itemuom = New System.Windows.Forms.Label()
        Me.lbl_Salerate = New System.Windows.Forms.Label()
        Me.txt_Menucode = New System.Windows.Forms.TextBox()
        Me.Cmd_Menucodehelp = New System.Windows.Forms.Button()
        Me.lbl_menuname = New System.Windows.Forms.Label()
        Me.txt_Salerate = New System.Windows.Forms.TextBox()
        Me.AxfpSpread1 = New AxFPSpreadADO.AxfpSpread()
        Me.lbl_Sales = New System.Windows.Forms.Label()
        Me.lbl_Production = New System.Windows.Forms.Label()
        Me.lbl_Vs = New System.Windows.Forms.Label()
        Me.Cbo_Production = New System.Windows.Forms.ComboBox()
        Me.Cbo_Sales = New System.Windows.Forms.ComboBox()
        Me.lbl_Uom = New System.Windows.Forms.Label()
        Me.lbl_Costprice = New System.Windows.Forms.Label()
        Me.lbl_Witheffectfrom = New System.Windows.Forms.Label()
        Me.lbl_Sellingprice = New System.Windows.Forms.Label()
        Me.lbl_Profit = New System.Windows.Forms.Label()
        Me.lbl_Remarks = New System.Windows.Forms.Label()
        Me.AxfpSpread2 = New AxFPSpreadADO.AxfpSpread()
        Me.AxfpSpread3 = New AxFPSpreadADO.AxfpSpread()
        Me.dtp_Witheffectfrom = New System.Windows.Forms.DateTimePicker()
        Me.txt_Menuname = New System.Windows.Forms.TextBox()
        Me.txt_Profitamt = New System.Windows.Forms.TextBox()
        Me.txt_Profitper = New System.Windows.Forms.TextBox()
        Me.Cbo_Itemuom = New System.Windows.Forms.ComboBox()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxfpSpread2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxfpSpread3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BackColor = System.Drawing.Color.White
        Me.txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Remarks.Location = New System.Drawing.Point(264, 488)
        Me.txt_Remarks.MaxLength = 15
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(312, 24)
        Me.txt_Remarks.TabIndex = 7
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Location = New System.Drawing.Point(216, 624)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(592, 56)
        Me.frmbut.TabIndex = 36
        Me.frmbut.TabStop = False
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(384, 16)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(320, 26)
        Me.lbl_Heading.TabIndex = 19
        Me.lbl_Heading.Text = "BILL OF MATERIAL [BOM]"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(280, 600)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(328, 25)
        Me.lbl_Freeze.TabIndex = 35
        Me.lbl_Freeze.Text = "Record Void  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'grp_Cocktail
        '
        Me.grp_Cocktail.BackgroundImage = CType(resources.GetObject("grp_Cocktail.BackgroundImage"), System.Drawing.Image)
        Me.grp_Cocktail.Location = New System.Drawing.Point(136, 64)
        Me.grp_Cocktail.Name = "grp_Cocktail"
        Me.grp_Cocktail.Size = New System.Drawing.Size(792, 88)
        Me.grp_Cocktail.TabIndex = 20
        Me.grp_Cocktail.TabStop = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.Location = New System.Drawing.Point(232, 640)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 13
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(576, 640)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 11
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(464, 640)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 10
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.Location = New System.Drawing.Point(344, 640)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 9
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(688, 640)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 12
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'txt_sellingprice
        '
        Me.txt_sellingprice.BackColor = System.Drawing.Color.Wheat
        Me.txt_sellingprice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_sellingprice.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sellingprice.Location = New System.Drawing.Point(768, 592)
        Me.txt_sellingprice.MaxLength = 15
        Me.txt_sellingprice.Name = "txt_sellingprice"
        Me.txt_sellingprice.ReadOnly = True
        Me.txt_sellingprice.Size = New System.Drawing.Size(160, 26)
        Me.txt_sellingprice.TabIndex = 17
        '
        'txt_Costprice
        '
        Me.txt_Costprice.BackColor = System.Drawing.Color.Wheat
        Me.txt_Costprice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Costprice.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Costprice.Location = New System.Drawing.Point(768, 528)
        Me.txt_Costprice.MaxLength = 15
        Me.txt_Costprice.Name = "txt_Costprice"
        Me.txt_Costprice.ReadOnly = True
        Me.txt_Costprice.Size = New System.Drawing.Size(160, 26)
        Me.txt_Costprice.TabIndex = 14
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(136, 168)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(792, 272)
        Me.ssgrid.TabIndex = 369
        '
        'lbl_Menuitemcode
        '
        Me.lbl_Menuitemcode.AutoSize = True
        Me.lbl_Menuitemcode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Menuitemcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Menuitemcode.Location = New System.Drawing.Point(144, 85)
        Me.lbl_Menuitemcode.Name = "lbl_Menuitemcode"
        Me.lbl_Menuitemcode.Size = New System.Drawing.Size(106, 16)
        Me.lbl_Menuitemcode.TabIndex = 21
        Me.lbl_Menuitemcode.Text = "MENU CODE :"
        '
        'lbl_Itemuom
        '
        Me.lbl_Itemuom.AutoSize = True
        Me.lbl_Itemuom.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Itemuom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemuom.Location = New System.Drawing.Point(158, 122)
        Me.lbl_Itemuom.Name = "lbl_Itemuom"
        Me.lbl_Itemuom.Size = New System.Drawing.Size(90, 16)
        Me.lbl_Itemuom.TabIndex = 24
        Me.lbl_Itemuom.Text = "ITEM UOM :"
        '
        'lbl_Salerate
        '
        Me.lbl_Salerate.AutoSize = True
        Me.lbl_Salerate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Salerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Salerate.Location = New System.Drawing.Point(532, 124)
        Me.lbl_Salerate.Name = "lbl_Salerate"
        Me.lbl_Salerate.Size = New System.Drawing.Size(99, 16)
        Me.lbl_Salerate.TabIndex = 25
        Me.lbl_Salerate.Text = "SALE RATE :"
        '
        'txt_Menucode
        '
        Me.txt_Menucode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Menucode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Menucode.Location = New System.Drawing.Point(271, 80)
        Me.txt_Menucode.MaxLength = 50
        Me.txt_Menucode.Name = "txt_Menucode"
        Me.txt_Menucode.Size = New System.Drawing.Size(144, 26)
        Me.txt_Menucode.TabIndex = 0
        '
        'Cmd_Menucodehelp
        '
        Me.Cmd_Menucodehelp.Image = CType(resources.GetObject("Cmd_Menucodehelp.Image"), System.Drawing.Image)
        Me.Cmd_Menucodehelp.Location = New System.Drawing.Point(416, 80)
        Me.Cmd_Menucodehelp.Name = "Cmd_Menucodehelp"
        Me.Cmd_Menucodehelp.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_Menucodehelp.TabIndex = 22
        '
        'lbl_menuname
        '
        Me.lbl_menuname.AutoSize = True
        Me.lbl_menuname.BackColor = System.Drawing.Color.Transparent
        Me.lbl_menuname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_menuname.Location = New System.Drawing.Point(520, 83)
        Me.lbl_menuname.Name = "lbl_menuname"
        Me.lbl_menuname.Size = New System.Drawing.Size(107, 16)
        Me.lbl_menuname.TabIndex = 23
        Me.lbl_menuname.Text = "MENU NAME :"
        '
        'txt_Salerate
        '
        Me.txt_Salerate.BackColor = System.Drawing.Color.Wheat
        Me.txt_Salerate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Salerate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Salerate.Location = New System.Drawing.Point(648, 120)
        Me.txt_Salerate.MaxLength = 15
        Me.txt_Salerate.Name = "txt_Salerate"
        Me.txt_Salerate.ReadOnly = True
        Me.txt_Salerate.Size = New System.Drawing.Size(144, 26)
        Me.txt_Salerate.TabIndex = 2
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(544, 448)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(386, 163)
        Me.AxfpSpread1.TabIndex = 380
        '
        'lbl_Sales
        '
        Me.lbl_Sales.AutoSize = True
        Me.lbl_Sales.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Sales.Location = New System.Drawing.Point(472, 384)
        Me.lbl_Sales.Name = "lbl_Sales"
        Me.lbl_Sales.Size = New System.Drawing.Size(56, 16)
        Me.lbl_Sales.TabIndex = 28
        Me.lbl_Sales.Text = "SALES"
        '
        'lbl_Production
        '
        Me.lbl_Production.AutoSize = True
        Me.lbl_Production.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Production.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Production.Location = New System.Drawing.Point(272, 384)
        Me.lbl_Production.Name = "lbl_Production"
        Me.lbl_Production.Size = New System.Drawing.Size(112, 16)
        Me.lbl_Production.TabIndex = 26
        Me.lbl_Production.Text = "PRODUCTION "
        '
        'lbl_Vs
        '
        Me.lbl_Vs.AutoSize = True
        Me.lbl_Vs.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Vs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Vs.Location = New System.Drawing.Point(408, 384)
        Me.lbl_Vs.Name = "lbl_Vs"
        Me.lbl_Vs.Size = New System.Drawing.Size(28, 16)
        Me.lbl_Vs.TabIndex = 27
        Me.lbl_Vs.Text = "VS"
        '
        'Cbo_Production
        '
        Me.Cbo_Production.BackColor = System.Drawing.Color.Wheat
        Me.Cbo_Production.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Production.Location = New System.Drawing.Point(264, 408)
        Me.Cbo_Production.Name = "Cbo_Production"
        Me.Cbo_Production.Size = New System.Drawing.Size(136, 27)
        Me.Cbo_Production.TabIndex = 4
        '
        'Cbo_Sales
        '
        Me.Cbo_Sales.BackColor = System.Drawing.Color.Wheat
        Me.Cbo_Sales.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Sales.Location = New System.Drawing.Point(440, 408)
        Me.Cbo_Sales.Name = "Cbo_Sales"
        Me.Cbo_Sales.Size = New System.Drawing.Size(136, 27)
        Me.Cbo_Sales.TabIndex = 5
        '
        'lbl_Uom
        '
        Me.lbl_Uom.AutoSize = True
        Me.lbl_Uom.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Uom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Uom.Location = New System.Drawing.Point(200, 416)
        Me.lbl_Uom.Name = "lbl_Uom"
        Me.lbl_Uom.Size = New System.Drawing.Size(50, 16)
        Me.lbl_Uom.TabIndex = 29
        Me.lbl_Uom.Text = "UOM :"
        '
        'lbl_Costprice
        '
        Me.lbl_Costprice.AutoSize = True
        Me.lbl_Costprice.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Costprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Costprice.Location = New System.Drawing.Point(640, 536)
        Me.lbl_Costprice.Name = "lbl_Costprice"
        Me.lbl_Costprice.Size = New System.Drawing.Size(106, 16)
        Me.lbl_Costprice.TabIndex = 32
        Me.lbl_Costprice.Text = "COST PRICE :"
        '
        'lbl_Witheffectfrom
        '
        Me.lbl_Witheffectfrom.AutoSize = True
        Me.lbl_Witheffectfrom.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Witheffectfrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Witheffectfrom.Location = New System.Drawing.Point(88, 448)
        Me.lbl_Witheffectfrom.Name = "lbl_Witheffectfrom"
        Me.lbl_Witheffectfrom.Size = New System.Drawing.Size(164, 16)
        Me.lbl_Witheffectfrom.TabIndex = 30
        Me.lbl_Witheffectfrom.Text = "WITH EFFECT FROM :"
        '
        'lbl_Sellingprice
        '
        Me.lbl_Sellingprice.AutoSize = True
        Me.lbl_Sellingprice.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Sellingprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Sellingprice.Location = New System.Drawing.Point(624, 600)
        Me.lbl_Sellingprice.Name = "lbl_Sellingprice"
        Me.lbl_Sellingprice.Size = New System.Drawing.Size(127, 16)
        Me.lbl_Sellingprice.TabIndex = 34
        Me.lbl_Sellingprice.Text = "SELLING PRICE :"
        '
        'lbl_Profit
        '
        Me.lbl_Profit.AutoSize = True
        Me.lbl_Profit.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Profit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Profit.Location = New System.Drawing.Point(664, 568)
        Me.lbl_Profit.Name = "lbl_Profit"
        Me.lbl_Profit.Size = New System.Drawing.Size(88, 16)
        Me.lbl_Profit.TabIndex = 33
        Me.lbl_Profit.Text = "PROFIT % :"
        '
        'lbl_Remarks
        '
        Me.lbl_Remarks.AutoSize = True
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Remarks.Location = New System.Drawing.Point(168, 488)
        Me.lbl_Remarks.Name = "lbl_Remarks"
        Me.lbl_Remarks.Size = New System.Drawing.Size(89, 16)
        Me.lbl_Remarks.TabIndex = 31
        Me.lbl_Remarks.Text = "REMARKS :"
        '
        'AxfpSpread2
        '
        Me.AxfpSpread2.DataSource = Nothing
        Me.AxfpSpread2.Location = New System.Drawing.Point(136, 152)
        Me.AxfpSpread2.Name = "AxfpSpread2"
        Me.AxfpSpread2.OcxState = CType(resources.GetObject("AxfpSpread2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread2.Size = New System.Drawing.Size(792, 208)
        Me.AxfpSpread2.TabIndex = 3
        '
        'AxfpSpread3
        '
        Me.AxfpSpread3.DataSource = Nothing
        Me.AxfpSpread3.Location = New System.Drawing.Point(592, 360)
        Me.AxfpSpread3.Name = "AxfpSpread3"
        Me.AxfpSpread3.OcxState = CType(resources.GetObject("AxfpSpread3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread3.Size = New System.Drawing.Size(336, 160)
        Me.AxfpSpread3.TabIndex = 8
        '
        'dtp_Witheffectfrom
        '
        Me.dtp_Witheffectfrom.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Witheffectfrom.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Witheffectfrom.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Witheffectfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Witheffectfrom.Location = New System.Drawing.Point(264, 448)
        Me.dtp_Witheffectfrom.Name = "dtp_Witheffectfrom"
        Me.dtp_Witheffectfrom.Size = New System.Drawing.Size(184, 26)
        Me.dtp_Witheffectfrom.TabIndex = 6
        '
        'txt_Menuname
        '
        Me.txt_Menuname.BackColor = System.Drawing.Color.Wheat
        Me.txt_Menuname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Menuname.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Menuname.Location = New System.Drawing.Point(648, 80)
        Me.txt_Menuname.MaxLength = 15
        Me.txt_Menuname.Name = "txt_Menuname"
        Me.txt_Menuname.Size = New System.Drawing.Size(256, 26)
        Me.txt_Menuname.TabIndex = 18
        '
        'txt_Profitamt
        '
        Me.txt_Profitamt.BackColor = System.Drawing.Color.Wheat
        Me.txt_Profitamt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Profitamt.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Profitamt.Location = New System.Drawing.Point(840, 560)
        Me.txt_Profitamt.MaxLength = 15
        Me.txt_Profitamt.Name = "txt_Profitamt"
        Me.txt_Profitamt.ReadOnly = True
        Me.txt_Profitamt.Size = New System.Drawing.Size(88, 26)
        Me.txt_Profitamt.TabIndex = 16
        '
        'txt_Profitper
        '
        Me.txt_Profitper.BackColor = System.Drawing.Color.Wheat
        Me.txt_Profitper.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Profitper.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Profitper.Location = New System.Drawing.Point(768, 560)
        Me.txt_Profitper.MaxLength = 15
        Me.txt_Profitper.Name = "txt_Profitper"
        Me.txt_Profitper.ReadOnly = True
        Me.txt_Profitper.Size = New System.Drawing.Size(56, 26)
        Me.txt_Profitper.TabIndex = 15
        '
        'Cbo_Itemuom
        '
        Me.Cbo_Itemuom.BackColor = System.Drawing.Color.Wheat
        Me.Cbo_Itemuom.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Itemuom.Location = New System.Drawing.Point(272, 117)
        Me.Cbo_Itemuom.Name = "Cbo_Itemuom"
        Me.Cbo_Itemuom.Size = New System.Drawing.Size(168, 27)
        Me.Cbo_Itemuom.TabIndex = 1
        '
        'Cock_Tail_Ratio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(990, 691)
        Me.Controls.Add(Me.Cbo_Itemuom)
        Me.Controls.Add(Me.txt_Profitper)
        Me.Controls.Add(Me.txt_Profitamt)
        Me.Controls.Add(Me.txt_Menuname)
        Me.Controls.Add(Me.lbl_Remarks)
        Me.Controls.Add(Me.lbl_Profit)
        Me.Controls.Add(Me.lbl_Sellingprice)
        Me.Controls.Add(Me.lbl_Witheffectfrom)
        Me.Controls.Add(Me.lbl_Costprice)
        Me.Controls.Add(Me.lbl_Uom)
        Me.Controls.Add(Me.lbl_Vs)
        Me.Controls.Add(Me.lbl_Sales)
        Me.Controls.Add(Me.lbl_Production)
        Me.Controls.Add(Me.txt_Salerate)
        Me.Controls.Add(Me.lbl_menuname)
        Me.Controls.Add(Me.txt_Menucode)
        Me.Controls.Add(Me.lbl_Salerate)
        Me.Controls.Add(Me.lbl_Itemuom)
        Me.Controls.Add(Me.lbl_Menuitemcode)
        Me.Controls.Add(Me.txt_sellingprice)
        Me.Controls.Add(Me.txt_Costprice)
        Me.Controls.Add(Me.txt_Remarks)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.dtp_Witheffectfrom)
        Me.Controls.Add(Me.AxfpSpread3)
        Me.Controls.Add(Me.AxfpSpread2)
        Me.Controls.Add(Me.Cbo_Sales)
        Me.Controls.Add(Me.Cbo_Production)
        Me.Controls.Add(Me.Cmd_Menucodehelp)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.grp_Cocktail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "Cock_Tail_Ratio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BILL OF MATERIAL [BOM]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxfpSpread2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxfpSpread3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim i As Integer
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim vsearch, vitem, accountcode As String

    Private Sub Cock_Tail_Ratio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CockTailRatioTransbool = True
        'txt_ItemCode.Enabled = True
        'txt_ItemCode.ReadOnly = False
        'txt_ItemDesc.ReadOnly = False
        CockTailRatioTransbool = True
        'ssgrid.SetActiveCell(1, 1)
        'Call FillUOM()
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        'Call FillUOM()
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Void  On "
        'ssgrid.ClearRange(1, 1, -1, -1, True)
        Me.Cmd_Freeze.Text = "Void [F8]"
        Cmd_Add.Text = "Add [F7]"
        'ssgrid.SetActiveCell(1, 1)
        'txt_ItemCode.Enabled = True
        'txt_ItemCode.ReadOnly = False
        'txt_ItemDesc.ReadOnly = False
        'txt_ItemCode.Focus()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        'Dim totalamt, totalqty As Double
        'Dim sqlstring As String
        'Dim Insert(0) As String
        'Dim i As Integer
        'Call checkValidation() '''--->Check Validation
        'If boolchk = False Then Exit Sub
        ''''*********************************************************** Calculate TotalQuantity And TotalAmount *******************'''
        'With ssgrid
        '    Me.txt_Totalamount.Text = 0
        '    Me.txt_Totalqty.Text = 0
        '    For i = 1 To .DataRowCnt
        '        .Row = i
        '        .Col = 4
        '        totalqty = Val(.Text)
        '        Me.txt_Totalqty.Text = Format(Val(Me.txt_Totalqty.Text) + Val(totalqty), "0.000")
        '        .Col = 6
        '        totalamt = Val(.Text)
        '        Me.txt_Totalamount.Text = Format(Val(Me.txt_Totalamount.Text) + Val(totalamt), "0.00")
        '    Next i
        'End With
        ''''*********************************************************** Calculate TotalQuantity And TotalAmount *******************'''
        ''''*********************************************************** Case-1 : Add [F7] *******************************************'''
        'If Cmd_Add.Text = "Add [F7]" Then
        '    sqlstring = "INSERT INTO cocktailratio_hdr(Itemcode,Itemname,ItemUOM,ItemEOQ,Itemtype,totalqty,totalamt,Void,Adduser,Adddate)"
        '    sqlstring = sqlstring & " VALUES ('" & Trim(txt_ItemCode.Text) & "',"
        '    sqlstring = sqlstring & "'" & Replace(Trim(txt_ItemDesc.Text), "'", "") & "',"
        '    sqlstring = sqlstring & "'" & Trim(cbo_Uom.Text) & "','" & Format(Val(txt_Eoq.Text), "0.00") & "', "
        '    sqlstring = sqlstring & "'" & Trim(cbo_Type.Text) & "','" & Format(Val(txt_Totalqty.Text), "0.000") & "', "
        '    sqlstring = sqlstring & "'" & Format(Val(txt_Totalamount.Text), "0.00") & "', "
        '    sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
        '    Insert(0) = sqlstring
        '    '''******************************************************** Insert into Grn_details **********************************'''
        '    For i = 1 To ssgrid.DataRowCnt
        '        With ssgrid
        '            sqlstring = "INSERT INTO cocktailratio_det(Itemcode,Itemname,ItemUOM,ItemEOQ,Itemtype,totalqty,totalamt,gitemcode,"
        '            sqlstring = sqlstring & " gitemname,gUOM,gqty,grate,gamount,gdblamt,ghighratio,ggroupcode,gsubgroupcode,Void,Adduser,Adddate)"
        '            sqlstring = sqlstring & " VALUES('" & Trim(txt_ItemCode.Text) & "','" & Replace(Trim(txt_ItemDesc.Text), "'", "") & "',"
        '            sqlstring = sqlstring & "'" & Trim(cbo_Uom.Text) & "','" & Format(Val(txt_Eoq.Text), "0.00") & "',"
        '            sqlstring = sqlstring & "'" & Trim(cbo_Type.Text) & "','" & Format(Val(txt_Totalqty.Text), "0.000") & "', "
        '            sqlstring = sqlstring & "'" & Format(Val(txt_Totalamount.Text), "0.00") & "', "
        '            .Row = i
        '            .Col = 1
        '            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
        '            .Col = 2
        '            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
        '            .Col = 3
        '            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
        '            .Col = 4
        '            sqlstring = sqlstring & "" & Format(Val(.Text), "0.000") & ","
        '            .Col = 5
        '            sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
        '            .Col = 6
        '            sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
        '            .Col = 7
        '            sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
        '            .Col = 8
        '            sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
        '            .Col = 9
        '            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
        '            .Col = 10
        '            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
        '            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
        '            ReDim Preserve Insert(Insert.Length)
        '            Insert(Insert.Length - 1) = sqlstring
        '        End With
        '    Next i
        '    '''****************************************** UPDATE Opening Stock ***************************************
        '    For i = 1 To ssgrid.DataRowCnt
        '        With ssgrid
        '            .Row = i
        '            sqlstring = "UPDATE OpeningStock SET "
        '            .Col = 4
        '            sqlstring = sqlstring & " mainclstock = mainclstock + " & Format(Val(.Text), "0") & ","
        '            .Col = 8
        '            sqlstring = sqlstring & " doublevalue= doublevalue + " & Format(Val(.Text), "0.00") & ","
        '            sqlstring = sqlstring & "Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
        '            .Col = 1
        '            sqlstring = sqlstring & "WHERE Itemcode='" & Trim(.Text) & "' "
        '            ReDim Preserve Insert(Insert.Length)
        '            Insert(Insert.Length - 1) = sqlstring
        '        End With
        '    Next i
        '    '''****************************************** UPDATE Completed ********************************************
        '    gconnection.MoreTrans(Insert)
        '    If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
        '        Call Cmd_View_Click(Cmd_View, e)
        '        Call Cmd_Clear_Click(sender, e)
        '    Else
        '        Call Cmd_Clear_Click(sender, e)
        '    End If
        '    '''*********************************************************** Case-2 : Update [F7] *******************************************'''
        'Else
        '    '''********************************************************** UPDATE GRN_HEADER *********************************************************'''
        '    sqlstring = " UPDATE cocktailratio_hdr SET Itemname='" & Replace(Trim(txt_ItemDesc.Text), "'", "") & "',"
        '    sqlstring = sqlstring & " ItemUOM='" & Trim(cbo_Uom.Text) & "',ItemEOQ='" & Format(Val(txt_Eoq.Text), "0.000") & "',"
        '    sqlstring = sqlstring & " Itemtype='" & Trim(cbo_Type.Text) & "',totalqty='" & Format(Val(txt_Totalqty.Text), "0.000") & "',"
        '    sqlstring = sqlstring & " totalamt='" & Format(Val(txt_Totalamount.Text), "0.00") & "',Void='N',"
        '    sqlstring = sqlstring & " Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy") & "' "
        '    sqlstring = sqlstring & " WHERE itemcode='" & Trim(txt_ItemCode.Text) & "' "
        '    Insert(0) = sqlstring
        '    '''********************************************************* DELETE FROM GRN_DETAILS *****************************************************'''
        '    sqlstring = "DELETE FROM cocktailratio_det WHERE itemcode='" & Trim(txt_ItemCode.Text) & "' "
        '    ReDim Preserve Insert(Insert.Length)
        '    Insert(Insert.Length - 1) = sqlstring
        '    '''******************************************************** INSERT INTO GRN_DETAILS ******************************************************'''
        '    For i = 1 To ssgrid.DataRowCnt
        '        With ssgrid
        '            sqlstring = "INSERT INTO cocktailratio_det(Itemcode,Itemname,ItemUOM,ItemEOQ,Itemtype,totalqty,totalamt,gitemcode,"
        '            sqlstring = sqlstring & " gitemname,gUOM,gqty,grate,gamount,gdblamt,ghighratio,ggroupcode,gsubgroupcode,Void,Adduser,Adddate)"
        '            sqlstring = sqlstring & " VALUES('" & Trim(txt_ItemCode.Text) & "','" & Replace(Trim(txt_ItemDesc.Text), "'", "") & "',"
        '            sqlstring = sqlstring & "'" & Trim(cbo_Uom.Text) & "','" & Format(Val(txt_Eoq.Text), "0.00") & "',"
        '            sqlstring = sqlstring & "'" & Trim(cbo_Type.Text) & "','" & Format(Val(txt_Totalqty.Text), "0.000") & "', "
        '            sqlstring = sqlstring & "'" & Format(Val(txt_Totalamount.Text), "0.00") & "', "
        '            .Row = i
        '            .Col = 1
        '            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
        '            .Col = 2
        '            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
        '            .Col = 3
        '            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
        '            .Col = 4
        '            sqlstring = sqlstring & "" & Format(Val(.Text), "0.000") & ","
        '            .Col = 5
        '            sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
        '            .Col = 6
        '            sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
        '            .Col = 7
        '            sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
        '            .Col = 8
        '            sqlstring = sqlstring & "" & Format(Val(.Text), "0.00") & ","
        '            .Col = 9
        '            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
        '            .Col = 10
        '            sqlstring = sqlstring & "'" & Trim(.Text) & "',"
        '            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy") & "')"
        '            ReDim Preserve Insert(Insert.Length)
        '            Insert(Insert.Length - 1) = sqlstring
        '        End With
        '    Next i
        '    '''****************************************** UPDATE Opening Stock ***************************************
        '    For i = 1 To ssgrid.DataRowCnt
        '        With ssgrid
        '            .Row = i
        '            sqlstring = "UPDATE OpeningStock SET "
        '            .Col = 4
        '            sqlstring = sqlstring & " mainclstock = mainclstock + " & Format(Val(.Text), "0") & ","
        '            .Col = 8
        '            sqlstring = sqlstring & " doublevalue= doublevalue + " & Format(Val(.Text), "0.00") & ","
        '            sqlstring = sqlstring & "Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
        '            .Col = 1
        '            sqlstring = sqlstring & "WHERE Itemcode='" & Trim(.Text) & "' "
        '            ReDim Preserve Insert(Insert.Length)
        '            Insert(Insert.Length - 1) = sqlstring
        '        End With
        '    Next i
        '    '''****************************************** UPDATE Completed ********************************************
        '    gconnection.MoreTrans(Insert)
        '    If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
        '        Call Cmd_View_Click(Cmd_View, e)
        '        Call Cmd_Clear_Click(sender, e)
        '    Else
        '        Call Cmd_Clear_Click(sender, e)
        '    End If
        'End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        'Call checkValidation() ''-->Check Validation
        'Dim i As Integer
        'Dim insert(0) As String
        'Call checkValidation() ''-->Check Validation
        'If boolchk = False Then Exit Sub
        'If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
        '    '''***************************************** Void the DOCNO in stockissueheader **************************'''
        '    sqlstring = "UPDATE  cocktailratio_hdr "
        '    sqlstring = sqlstring & " SET Void= 'Y',Adduser='" & gUsername & " ', Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
        '    sqlstring = sqlstring & " WHERE itemcode = '" & Trim(txt_ItemCode.Text) & "'"
        '    gconnection.dataOperation(3, sqlstring, "cocktailratio_hdr")
        '    insert(0) = sqlstring
        '    '''***************************************** Void the DOCNO in Complete **********************************'''
        '    '''***************************************** Void the DOCNO in stockissuedetails **************************'''
        '    For i = 1 To ssgrid.DataRowCnt
        '        With ssgrid
        '            sqlstring = "UPDATE  cocktailratio_det "
        '            sqlstring = sqlstring & " SET Void= 'Y',"
        '            sqlstring = sqlstring & " Adduser='" & gUsername & " ',"
        '            sqlstring = sqlstring & " Adddate ='" & Format(Now, "dd-MMM-yyyy") & "'"
        '            sqlstring = sqlstring & " WHERE itemcode = '" & Trim(txt_ItemCode.Text) & "'"
        '            ReDim Preserve insert(insert.Length)
        '            insert(insert.Length - 1) = sqlstring
        '        End With
        '    Next i
        '    '''***************************************** Void the DOCNO is Complete **********************************'''
        '    '''****************************************** UPDATE Opening Stock ***************************************
        '    For i = 1 To ssgrid.DataRowCnt
        '        With ssgrid
        '            .Row = i
        '            sqlstring = "UPDATE OpeningStock SET "
        '            .Col = 4
        '            sqlstring = sqlstring & " mainclstock = mainclstock - " & Format(Val(.Text), "0") & ","
        '            .Col = 8
        '            sqlstring = sqlstring & " doublevalue= doublevalue - " & Format(Val(.Text), "0.00") & ","
        '            sqlstring = sqlstring & "Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
        '            .Col = 1
        '            sqlstring = sqlstring & "WHERE Itemcode='" & Trim(.Text) & "' "
        '            ReDim Preserve insert(insert.Length)
        '            insert(insert.Length - 1) = sqlstring
        '        End With
        '    Next i
        '    '''****************************************** UPDATE Completed ********************************************
        '    gconnection.MoreTrans(insert)
        '    Me.Cmd_Clear_Click(sender, e)
        '    Cmd_Add.Text = "Add [F7]"
        'End If
    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Dim objCocktailratio As New frmCocktailratiochart
        objCocktailratio.Show()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cock_Tail_Ratio_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        CockTailRatioTransbool = False
    End Sub
    Public Sub checkValidation()
        boolchk = False
        ''''********** Check  Item Code Can't be blank *********************'''
        'If Trim(txt_ItemCode.Text) = "" Then
        '    MessageBox.Show(" Item Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_ItemCode.Focus()
        '    Exit Sub
        'End If
        ''''********** Check  Item desc Can't be blank *********************'''
        'If Trim(txt_ItemDesc.Text) = "" Then
        '    MessageBox.Show(" Item Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_ItemDesc.Focus()
        '    Exit Sub
        'End If
        ''''********** Check  EOQ Can't be blank *********************'''
        'If Val(txt_Eoq.Text) = 0 Then
        '    MessageBox.Show(" EOQ can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txt_Eoq.Focus()
        '    Exit Sub
        'End If
        ''''********** Check  UOM Can't be blank *********************'''
        'If Trim(cbo_Uom.Text) = "" Then
        '    MessageBox.Show(" UOM can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cbo_Uom.Focus()
        '    Exit Sub
        'End If
        '''' ********** Check ItemCode,ItemDesc,UOM,Rate can't be blank ***********'''
        'For i = 1 To ssgrid.DataRowCnt
        '    ssgrid.Row = i
        '    ssgrid.Col = 1
        '    If Trim(ssgrid.Text) = "" Then
        '        MessageBox.Show("ItemCode can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
        '        ssgrid.Focus()
        '        Exit Sub
        '    End If
        '    ssgrid.Col = 2
        '    If Trim(ssgrid.Text) = "" Then
        '        MessageBox.Show("Itemdesc can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
        '        ssgrid.Focus()
        '        Exit Sub
        '    End If
        '    ssgrid.Col = 3
        '    If Trim(ssgrid.Text) = "" Then
        '        MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
        '        ssgrid.Focus()
        '        Exit Sub
        '    End If
        '    ssgrid.Col = 4
        '    If Val(ssgrid.Text) = 0 Then
        '        MessageBox.Show("Quantity can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
        '        ssgrid.Focus()
        '        Exit Sub
        '    End If
        '    ssgrid.Col = 5
        '    If Val(ssgrid.Text) = 0 Then
        '        MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
        '        ssgrid.Focus()
        '        Exit Sub
        '    End If
        '    ssgrid.Col = 6
        '    If Val(ssgrid.Text) = 0 Then
        '        MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
        '        ssgrid.Focus()
        '        Exit Sub
        '    End If
        '    ssgrid.Col = 7
        '    If Val(ssgrid.Text) = 0 Then
        '        MessageBox.Show("dblamount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
        '        ssgrid.Focus()
        '        Exit Sub
        '    End If
        '    ssgrid.Col = 8
        '    If Val(ssgrid.Text) = 0 Then
        '        MessageBox.Show("High Ratio can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        ssgrid.SetActiveCell(8, ssgrid.ActiveRow)
        '        ssgrid.Focus()
        '        Exit Sub
        '    End If
        '    ssgrid.Col = 9
        '    If Trim(ssgrid.Text) = "" Then
        '        MessageBox.Show("Group Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        ssgrid.SetActiveCell(9, ssgrid.ActiveRow)
        '        ssgrid.Focus()
        '        Exit Sub
        '    End If
        '    ssgrid.Col = 10
        '    If Trim(ssgrid.Text) = "" Then
        '        MessageBox.Show("Sub Group Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        ssgrid.SetActiveCell(10, ssgrid.ActiveRow)
        '        ssgrid.Focus()
        '        Exit Sub
        '    End If
        'Next i
        'boolchk = True
    End Sub

    Private Sub Cock_Tail_Ratio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'If e.KeyCode = Keys.F6 Then
        '    Call Cmd_Clear_Click(Cmd_Clear, e)
        '    Exit Sub
        'ElseIf e.KeyCode = Keys.F8 Then
        '    Call Cmd_Freeze_Click(Cmd_Freeze, e)
        '    Exit Sub
        'ElseIf e.KeyCode = Keys.F7 Then
        '    Call Cmd_Add_Click(Cmd_Add, e)
        '    Exit Sub
        'ElseIf e.KeyCode = Keys.F2 Then
        '    txt_ItemCode.Text = ""
        '    txt_ItemCode.Focus()
        '    Exit Sub
        'ElseIf e.KeyCode = Keys.F9 Then
        '    Call Cmd_View_Click(Cmd_View, e)
        '    Exit Sub
        'ElseIf e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
        '    Call Cmd_Exit_Click(Cmd_Exit, e)
        '    Exit Sub
        'ElseIf e.Alt = True And e.KeyCode = Keys.R Then
        '    Me.txt_Remarks.Focus()
        '    Exit Sub
        'ElseIf e.Alt = True And e.KeyCode = Keys.G Then
        '    Me.ssgrid.Focus()
        '    Me.ssgrid.SetActiveCell(1, 1)
        '    Exit Sub
        'ElseIf e.Alt = True And e.KeyCode = Keys.U Then
        '    Me.cbo_Uom.Focus()
        '    Exit Sub
        'ElseIf e.Alt = True And e.KeyCode = Keys.T Then
        '    Me.cbo_Type.Focus()
        '    Exit Sub
        'End If
    End Sub

    Private Sub txt_ItemDesc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            Cbo_Itemuom.Focus()
        End If
    End Sub

    Private Sub cbo_Uom_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            ssgrid.Focus()
        End If
    End Sub

    Private Sub txt_Eoq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            ssgrid.Focus()
        End If
    End Sub

    Private Sub FillMenu()
        Dim Avgrate, clsquantity As Double
        Dim K As Integer
        Dim vform As New List_Operation
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(O.AVGRATE,0) AS AVGRATE, "
        gSQLString = gSQLString & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE , isnull(i.storecode,'MNS') as storecode FROM INVENTORYITEMMASTER AS I  "
        gSQLString = gSQLString & " INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
        If Trim(vsearch) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " WHERE I.ITEMCODE LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'"
        End If
        vform.Field = "I.ITEMCODE,I.ITEMNAME"
        vform.vFormatstring1 = "   ITEMCODE    |                      ITEMNAME              | STOCKUOM | AVGRATE | CONVUOM | HIGHRATIO |"
        vform.vCaption = "INVENTORY ITEM CODE HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
        vform.Keypos5 = 5
        vform.Keypos6 = 6
        vform.Keypos7 = 7
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Call GridUOM(ssgrid.ActiveRow) '''---> Fill the UOM feild
            ssgrid.Col = 1
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield)
            'For K = 1 To ssgrid.DataRowCnt
            '    ssgrid.Row = K
            '    ssgrid.Col = 1
            '    If Itemvalidate(ssgrid, Trim(vform.keyfield), 1) = True Then
            '        ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
            '        ssgrid.Focus()
            '        Exit Sub
            '    End If
            'Next
            ssgrid.Col = 2
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield1)
            ssgrid.Col = 3
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
            ssgrid.TypeComboBoxString = vform.keyfield2
            ssgrid.Text = Trim(vform.keyfield2)
            ssgrid.Col = 5
            ssgrid.Row = ssgrid.ActiveRow
            Avgrate = CalAverageRate(Trim(vform.keyfield))
            ssgrid.Text = Format(Val(Avgrate), "0.00")
            ssgrid.Col = 8
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield4)
            ssgrid.Col = 9
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Format(Val(vform.keyfield5), "0.00")
            ssgrid.Col = 10
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield6)
            ssgrid.Col = 11
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield7)
            'clsquantity = ClosingQuantity(Trim(vform.keyfield), "MNS")
            clsquantity = ClosingQuantity(Trim(vform.keyfield), GetMainStore())
            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
            ssgrid.Focus()
        Else
            ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
            Exit Sub
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FillMenuItem()
        Dim Avgrate, clsquantity As Double
        Dim K As Integer
        Dim vform As New List_Operation
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMDESC,ITEMCODE INTO SSGRID ********** 
        gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(O.AVGRATE,0) AS AVGRATE, "
        gSQLString = gSQLString & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
        gSQLString = gSQLString & " INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
        If Trim(vsearch) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " WHERE I.ITEMNAME like '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'"
        End If
        vform.Field = "I.ITEMNAME,I.ITEMCODE"
        vform.vFormatstring1 = "             ITEMNAME               |  ITEMCODE    | STOCKUOM | AVGRATE | CONVUOM | HIGHRATIO |"
        vform.vCaption = "INVENTORY ITEM CODE HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
        vform.Keypos5 = 5
        vform.Keypos6 = 6
        vform.Keypos7 = 7
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            ssgrid.Col = 1
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield1)
            'For K = 1 To ssgrid.DataRowCnt
            '    ssgrid.Row = K
            '    ssgrid.Col = 1
            '    If Itemvalidate(ssgrid, Trim(vform.keyfield1), 1) = True Then
            '        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
            '        ssgrid.Focus()
            '        Exit Sub
            '    End If
            'Next
            ssgrid.Col = 2
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield)
            ssgrid.Col = 3
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
            ssgrid.TypeComboBoxString = vform.keyfield2
            ssgrid.Text = Trim(vform.keyfield2)
            ssgrid.Col = 5
            ssgrid.Row = ssgrid.ActiveRow
            Avgrate = CalAverageRate(Trim(vform.keyfield))
            ssgrid.Text = Format(Val(Avgrate), "0.00")
            ssgrid.Col = 8
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield4)
            ssgrid.Col = 9
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Format(Val(vform.keyfield5), "0.00")
            ssgrid.Col = 10
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield6)
            ssgrid.Col = 11
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform.keyfield7)
            'clsquantity = ClosingQuantity(Trim(vform.keyfield1), "MNS")
            clsquantity = ClosingQuantity(Trim(vform.keyfield1), GetMainStore())
            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
            ssgrid.Focus()
        Else
            ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
            Exit Sub
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Calculate()
        Dim ValQty, ValRate, ValDiscount, VarTotal, clsquantiy As Double
        Dim ValHighratio, ValItemamount, ValDblamount, Calqty As Double
        Dim Itemcode As String
        Dim i, j As Integer
        If ssgrid.ActiveCol = 1 Or ssgrid.ActiveCol = 2 Or ssgrid.ActiveCol = 3 Or ssgrid.ActiveCol = 4 Or ssgrid.ActiveCol = 5 Or ssgrid.ActiveCol = 6 Then
            i = ssgrid.ActiveRow
            ssgrid.Col = 4
            ssgrid.Row = i
            ValQty = Val(ssgrid.Text)
            ssgrid.Col = 5
            ssgrid.Row = i
            ValRate = Val(ssgrid.Text)
            ssgrid.Col = 9
            ssgrid.Row = i
            ValHighratio = Val(ssgrid.Text())
            ValItemamount = Format(Val(ValQty) * Val(ValRate), "0.00")
            ValDblamount = Format(Val(ValQty) * Val(ValHighratio), "0.000")
            If Val(ValItemamount) = 0 Then
                ssgrid.SetText(6, i, "")
                ssgrid.SetText(7, i, "")
            Else
                ssgrid.SetText(6, i, Val(ValItemamount))
                ssgrid.SetText(7, i, Val(ValDblamount))
            End If
            ssgrid.Col = 1
            ssgrid.Row = ssgrid.ActiveRow
            Itemcode = Trim(ssgrid.Text)
            For j = 1 To ssgrid.DataRowCnt
                ssgrid.Col = 1
                ssgrid.Row = j
                If Trim(Itemcode) = Trim(ssgrid.Text) Then
                    ssgrid.Col = 4
                    ssgrid.Row = j
                    Calqty = Calqty + Val(ssgrid.Text)
                End If
            Next
            i = i - 1
        End If
    End Sub
    Private Sub GridUOM(ByVal i As Integer)
        Dim j As Integer
        sqlstring = "SELECT UOMdesc FROM UOMMaster WHERE freeze='N'"
        gconnection.getDataSet(sqlstring, "UOMMaster1")
        If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
            For j = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
                ssgrid.Col = 3
                ssgrid.Row = i
                ssgrid.TypeComboBoxString = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMdesc"))
                ssgrid.Text = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMdesc"))
            Next j
        End If
    End Sub

    Private Sub cbo_Type_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            'txt_Eoq.Focus()
        End If
    End Sub

    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        Dim Issuerate, Highratio, Dblamount, clsquantity As Double
        Dim ItemQty, ItemAmount, ItemRate As Double
        Dim sqlstring, Itemcode, Itemdesc As String
        Dim focusbool As Boolean
        Dim i, j, K As Integer
        search = Nothing
        Try
            If e.keyCode = Keys.Enter Then
                i = ssgrid.ActiveRow
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            Call FillMenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemcode = Trim(ssgrid.Text)
                            ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                            '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
                            sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                            sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
                            sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                            If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                Call GridUOM(i) '''---> Fill the UOM feild
                                ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                'For K = 1 To ssgrid.DataRowCnt
                                '    ssgrid.Row = K
                                '    ssgrid.Col = 1
                                '    If Itemvalidate(ssgrid, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
                                '        ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                '        ssgrid.Focus()
                                '        Exit Sub
                                '    End If
                                'Next
                                ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                ssgrid.Col = 3
                                ssgrid.Row = i
                                ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                ssgrid.SetText(5, i, Format(Val(Issuerate), "0.00"))
                                ssgrid.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
                                ssgrid.SetText(9, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
                                ssgrid.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
                                ssgrid.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
                                'clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), "MNS")
                                clsquantity = ClosingQuantity(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), GetMainStore())
                                'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
                                ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                                ssgrid.Focus()
                            Else
                                MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                Exit Sub
                            End If
                        End If
                    Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    End If
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.Col = 2
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemdesc = Trim(ssgrid.Text)
                            ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                            '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
                            sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                            sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
                            sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                            If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                Call GridUOM(i) '''---> Fill the UOM feild
                                ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                'For K = 1 To ssgrid.DataRowCnt
                                '    ssgrid.Row = K
                                '    ssgrid.Col = 1
                                '    If Itemvalidate(ssgrid, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), 1) = True Then
                                '        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                '        ssgrid.Focus()
                                '        Exit Sub
                                '    End If
                                'Next
                                ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                ssgrid.Col = 3
                                ssgrid.Row = i
                                ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                Issuerate = CalAverageRate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                ssgrid.SetText(5, i, Format(Val(Issuerate), "0.00"))
                                ssgrid.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
                                ssgrid.SetText(9, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
                                ssgrid.SetText(10, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
                                ssgrid.SetText(11, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
                                'clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), "MNS")
                                clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), GetMainStore())
                                'lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
                                ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                            Else
                                MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 3 Then
                    ssgrid.Col = 3
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 4 Then
                    ssgrid.Col = 4
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                        Else
                            Call Calculate() '''--> Calculate total amount
                            ssgrid.Row = ssgrid.ActiveRow + 1
                            ssgrid.Col = 1
                            ssgrid.Lock = False
                            ssgrid.Col = 2
                            ssgrid.Lock = False
                            ssgrid.Col = 3
                            ssgrid.Lock = False
                            ssgrid.Col = 4
                            ssgrid.Lock = False
                            ssgrid.Col = 5
                            ssgrid.Lock = False
                            ssgrid.Col = 6
                            ssgrid.Lock = False
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 5 Then
                    ssgrid.Col = 5
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                        Else
                            Call Calculate() '''--> Calculate total amount
                            ssgrid.Row = ssgrid.ActiveRow + 1
                            ssgrid.Col = 1
                            ssgrid.Lock = False
                            ssgrid.Col = 2
                            ssgrid.Lock = False
                            ssgrid.Col = 3
                            ssgrid.Lock = False
                            ssgrid.Col = 4
                            ssgrid.Lock = False
                            ssgrid.Col = 5
                            ssgrid.Lock = False
                            ssgrid.Col = 6
                            ssgrid.Lock = False
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 6 Then
                    ssgrid.Col = 6
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    Else
                        ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
                    End If
                ElseIf ssgrid.ActiveCol = 7 Then
                    ssgrid.Col = 7
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 8 Then
                    ssgrid.Col = 8
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 9 Then
                    ssgrid.Col = 9
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(8, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                End If
            ElseIf e.keyCode = Keys.F4 Then
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        ssgrid.Col = 1
                        ssgrid.Row = ssgrid.ActiveRow
                        search = Trim(ssgrid.Text)
                        Call FillMenu()
                    End If
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.Col = 2
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        ssgrid.Col = 2
                        ssgrid.Row = ssgrid.ActiveRow
                        search = Trim(ssgrid.Text)
                        Call FillMenuItem()
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                ssgrid.Col = ssgrid.ActiveCol
                i = ssgrid.ActiveRow
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    With ssgrid
                        .Row = .ActiveRow
                        .ClearRange(1, .ActiveRow, 11, .ActiveRow, True)
                        .DeleteRows(.ActiveRow, 1)
                        Call Calculate()
                        .SetActiveCell(1, ssgrid.ActiveRow)
                        .Focus()
                    End With
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Menucodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Menucodehelp.Click
        gSQLString = "SELECT  ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') FROM ITEMMASTER"
        If Trim(search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        Dim vform As New ListOperattion1
        vform.Field = "ITEMDESC,ITEMCODE"
        vform.vFormatstring = "  ITEM CODE         |                               ITEM DESCRIPTION                             "
        vform.vCaption = " ITEM MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Menucode.Text = Trim(vform.keyfield & "")
            Call txt_Menucode_Validated(txt_Menucode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_Menucode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Menucode.Validated
        Dim J, K As Integer
        If Trim(txt_Menucode.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(H.ITEMCODE,'') AS ITEMCODE,ISNULL(H.ITEMNAME,'') AS ITEMDESC,ISNULL(H.ITEMUOM,'') AS ITEMUOM,"
                sqlstring = sqlstring & " ISNULL(H.VOID,'') AS VOID FROM COCKTAILRATIO_HDR AS H WHERE ISNULL(H.ITEMCODE,'')  ='" & Trim(txt_Menucode.Text) & "'"
                gconnection.getDataSet(sqlstring, "COCKTAILRATIO_HDR")
                If gdataset.Tables("COCKTAILRATIO_HDR").Rows.Count > 0 Then
                    txt_Menucode.Text = Trim(gdataset.Tables("COCKTAILRATIO_HDR").Rows(0).Item("ITEMCODE"))
                    txt_Menuname.Text = Trim(gdataset.Tables("COCKTAILRATIO_HDR").Rows(0).Item("ITEMDESC"))
                    Cbo_Itemuom.DropDownStyle = ComboBoxStyle.DropDown
                    Cbo_Itemuom.Text = Trim(gdataset.Tables("COCKTAILRATIO_HDR").Rows(0).Item("ITEMUOM"))
                    Cbo_Itemuom.DropDownStyle = ComboBoxStyle.DropDownList
                    '------------------------------------- SELECT RECORDS FROM COCKTAILRATIO_DET -------------
                    sqlstring = "SELECT ISNULL(D.GITEMCODE,'') AS ITEMCODE,ISNULL(D.GITEMNAME,'') AS ITEMDESC,ISNULL(D.GUOM,'') AS UOM,"
                    sqlstring = sqlstring & " ISNULL(D.GQTY,0) AS QTY,ISNULL(D.GRATE,0) AS RATE,ISNULL(D.GAMOUNT,0) AS AMOUNT,ISNULL(D.GDBLAMT,0) AS DBLAMT,"
                    sqlstring = sqlstring & " ISNULL(D.GHIGHRATIO,0) AS HIGHRATIO,ISNULL(D.GGROUPCODE,'') AS GROUPCODE,ISNULL(D.GSUBGROUPCODE,'') AS SUBGROUPCODE,"
                    sqlstring = sqlstring & " ISNULL(D.VOID,'') AS VOID FROM COCKTAILRATIO_DET AS D WHERE ISNULL(D.ITEMCODE,'')  ='" & Trim(txt_Menucode.Text) & "'"
                    gconnection.getDataSet(sqlstring, "COCKTAILRATIO_DET")
                    If gdataset.Tables("COCKTAILRATIO_DET").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("COCKTAILRATIO_DET").Rows.Count
                            ssgrid.SetText(1, i, Trim(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("GITEMCODE")))
                            ssgrid.SetText(2, i, Trim(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("GITEMNAME")))
                            ssgrid.Col = 3
                            ssgrid.Row = i
                            ssgrid.TypeComboBoxString = Trim(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("UOM"))
                            ssgrid.Text = Trim(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("UOM"))
                            ssgrid.SetText(4, i, Format(Val(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("QTY")), "0.000"))
                            ssgrid.SetText(5, i, Format(Val(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("RATE")), "0.00"))
                            ssgrid.SetText(6, i, Format(Val(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("AMOUNT")), "0.00"))
                            ssgrid.SetText(7, i, Format(Val(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("DBLAMT")), "0.00"))
                            ssgrid.SetText(8, i, Format(Val(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("HIGHRATIO")), "0.00"))
                            ssgrid.SetText(9, i, Trim(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("GROUPCODE")))
                            ssgrid.SetText(10, i, Trim(gdataset.Tables("COCKTAILRATIO_DET").Rows(J).Item("SUBGROUPCODE")))
                            J = J + 1
                        Next
                        Cbo_Itemuom.SelectedIndex = 0
                        Cbo_Itemuom.Focus()
                    End If
                    txt_Menucode.ReadOnly = True
                    txt_Menuname.ReadOnly = True
                    Me.Cmd_Add.Text = "Update[F7]"
                Else
                    sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(R.UOM,'') AS UOM"
                    sqlstring = sqlstring & " FROM ITEMMASTER AS I  INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE"
                    sqlstring = sqlstring & " WHERE ISNULL(I.ITEMCODE,'') = '" & Trim(txt_Menucode.Text) & "' AND ISNULL(I.FREEZE,'') <> 'Y' "
                    gconnection.getDataSet(sqlstring, "ITEMMASTER")
                    If gdataset.Tables("ITEMMASTER").Rows.Count > 0 Then
                        txt_Menucode.Text = Trim(gdataset.Tables("ITEMMASTER").Rows(0).Item("ITEMCODE"))
                        txt_Menuname.Text = Trim(gdataset.Tables("ITEMMASTER").Rows(0).Item("ITEMDESC"))
                        For K = 0 To gdataset.Tables("ITEMMASTER").Rows.Count - 1 Step 1
                            Cbo_Itemuom.Items.Add(Trim(gdataset.Tables("ITEMMASTER").Rows(K).Item("UOM")))
                        Next K
                        Cbo_Itemuom.DropDownStyle = ComboBoxStyle.DropDownList
                        Cbo_Itemuom.SelectedIndex = 0
                        txt_Menucode.ReadOnly = True
                        txt_Menuname.ReadOnly = True
                        Cbo_Itemuom.Focus()
                    Else
                        Me.Cmd_Add.Text = "Add [F7]"
                        txt_Menucode.ReadOnly = False
                        txt_Menucode.Text = ""
                        txt_Menucode.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Enter a valid ITEM CODE ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Cbo_Itemuom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Itemuom.SelectedIndexChanged
        Dim sqlstring As String
        If Trim(Cbo_Itemuom.Text) <> "" Then
            sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMDESC,'') AS ITEMDESC,ISNULL(R.UOM,'') AS UOM,ISNULL(R.ITEMRATE,0) AS ITEMRATE"
            sqlstring = sqlstring & " FROM ITEMMASTER AS I  INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE"
            sqlstring = sqlstring & " WHERE ISNULL(I.ITEMCODE,'') = '" & Trim(txt_Menucode.Text) & "' AND ISNULL(R.UOM,'') = '" & Trim(Cbo_Itemuom.Text) & "' AND ISNULL(I.FREEZE,'') <> 'Y' "
            gconnection.getDataSet(sqlstring, "ITEMMASTERSELECTION")
            If gdataset.Tables("ITEMMASTERSELECTION").Rows.Count > 0 Then
                txt_Salerate.Text = Format(Val(gdataset.Tables("ITEMMASTERSELECTION").Rows(0).Item("ITEMRATE")), "0.00")
                ssgrid.Focus()
            Else
                txt_Salerate.Text = ""
            End If
        Else
            Cbo_Itemuom.Focus()
        End If
    End Sub

    Private Sub txt_Menucode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Menucode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Cmd_Menucodehelp.Enabled = True Then
                search = Trim(txt_Menucode.Text)
                Call Cmd_Menucodehelp_Click(Cmd_Menucodehelp, e)
            End If
        End If
    End Sub

    Private Sub txt_Menucode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Menucode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_Menucode.Text) = "" Then
                Call Cmd_Menucodehelp_Click(Cmd_Menucodehelp, e)
            Else
                txt_Menucode_Validated(txt_Menucode, e)
                Cbo_Itemuom.Focus()
            End If
        End If
    End Sub

    Private Sub ssgrid_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid.LeaveCell
        Dim Issuerate, Highratio, Dblamount, ItemQty, ItemAmount, ItemRate, clsquantity As Double
        Dim sqlstring, Itemcode, Itemdesc As String
        Dim focusbool As Boolean
        Dim i, j, K As Integer
        search = Nothing
        If ssgrid.ActiveCol = 1 Or ssgrid.ActiveCol = 2 Then
            Call Calculate()
        End If
        Try
            i = ssgrid.ActiveRow
            If ssgrid.ActiveCol = 4 Then
                ssgrid.Col = 4
                i = ssgrid.ActiveRow
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Val(ssgrid.Text) = 0 Then
                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                    Else
                        Call Calculate() '''--> Calculate total amount
                        ssgrid.Row = ssgrid.ActiveRow + 1
                        ssgrid.Col = 1
                        ssgrid.Lock = False
                        ssgrid.Col = 2
                        ssgrid.Lock = False
                        ssgrid.Col = 3
                        ssgrid.Lock = False
                        ssgrid.Col = 4
                        ssgrid.Lock = False
                        ssgrid.Col = 5
                        ssgrid.Lock = False
                        ssgrid.Col = 6
                        ssgrid.Lock = False
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                    End If
                End If
            ElseIf ssgrid.ActiveCol = 5 Then
                ssgrid.Col = 5
                i = ssgrid.ActiveRow
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Val(ssgrid.Text) = 0 Then
                        ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                    Else
                        Call Calculate() '''--> Calculate total amount
                        ssgrid.Row = ssgrid.ActiveRow + 1
                        ssgrid.Col = 1
                        ssgrid.Lock = False
                        ssgrid.Col = 2
                        ssgrid.Lock = False
                        ssgrid.Col = 3
                        ssgrid.Lock = False
                        ssgrid.Col = 4
                        ssgrid.Lock = False
                        ssgrid.Col = 5
                        ssgrid.Lock = False
                        ssgrid.Col = 6
                        ssgrid.Lock = False
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

End Class
