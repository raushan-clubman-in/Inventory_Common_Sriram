<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Inv_StoreCategoryLink
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inv_StoreCategoryLink))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.AxfpSpread1 = New AxFPSpreadADO.AxfpSpread()
        Me.txt_StoreCode = New System.Windows.Forms.TextBox()
        Me.lbl_StoreDescription = New System.Windows.Forms.Label()
        Me.lbl_StoreCode = New System.Windows.Forms.Label()
        Me.cmdStoreCode = New System.Windows.Forms.Button()
        Me.txt_StoreDesc = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.shelf_grid = New AxFPSpreadADO.AxfpSpread()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.RDB_SESSIONN = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RDB_SESSIONY = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lbl_shelfreq = New System.Windows.Forms.Label()
        Me.Rdb_ShelfNo = New System.Windows.Forms.RadioButton()
        Me.Rdb_ShelfYes = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Opt_Substore = New System.Windows.Forms.RadioButton()
        Me.Opt_Mainstore = New System.Windows.Forms.RadioButton()
        Me.text_storedesc = New System.Windows.Forms.TextBox()
        Me.help_storecode = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.text_storecode = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rdb_buffet_N = New System.Windows.Forms.RadioButton()
        Me.rdb_buffet_Y = New System.Windows.Forms.RadioButton()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rdb_banquet_N = New System.Windows.Forms.RadioButton()
        Me.rdb_banquet_Y = New System.Windows.Forms.RadioButton()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.shelf_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.GroupBox3.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox3.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox3.Controls.Add(Me.Cmd_Add)
        Me.GroupBox3.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox3.Location = New System.Drawing.Point(563, 174)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(136, 214)
        Me.GroupBox3.TabIndex = 606
        Me.GroupBox3.TabStop = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Clear.BackgroundImage = CType(resources.GetObject("Cmd_Clear.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.FlatAppearance.BorderSize = 0
        Me.Cmd_Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cmd_Clear.Location = New System.Drawing.Point(6, 10)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Clear.TabIndex = 597
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Exit.BackgroundImage = CType(resources.GetObject("Cmd_Exit.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Exit.FlatAppearance.BorderSize = 0
        Me.Cmd_Exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(6, 157)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Exit.TabIndex = 600
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Add.BackgroundImage = CType(resources.GetObject("Cmd_Add.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Add.FlatAppearance.BorderSize = 0
        Me.Cmd_Add.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cmd_Add.Location = New System.Drawing.Point(6, 59)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Add.TabIndex = 598
        Me.Cmd_Add.Text = "Add[F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Freeze.BackgroundImage = CType(resources.GetObject("Cmd_Freeze.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Freeze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Freeze.FlatAppearance.BorderSize = 0
        Me.Cmd_Freeze.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cmd_Freeze.Location = New System.Drawing.Point(6, 108)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Freeze.TabIndex = 599
        Me.Cmd_Freeze.Text = "Void[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.AxfpSpread1)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(532, 222)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(12, 17)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(509, 188)
        Me.AxfpSpread1.TabIndex = 0
        '
        'txt_StoreCode
        '
        Me.txt_StoreCode.BackColor = System.Drawing.Color.Wheat
        Me.txt_StoreCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_StoreCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_StoreCode.Location = New System.Drawing.Point(257, 26)
        Me.txt_StoreCode.MaxLength = 5
        Me.txt_StoreCode.Name = "txt_StoreCode"
        Me.txt_StoreCode.ReadOnly = True
        Me.txt_StoreCode.Size = New System.Drawing.Size(117, 21)
        Me.txt_StoreCode.TabIndex = 0
        '
        'lbl_StoreDescription
        '
        Me.lbl_StoreDescription.AutoSize = True
        Me.lbl_StoreDescription.BackColor = System.Drawing.Color.Transparent
        Me.lbl_StoreDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StoreDescription.Location = New System.Drawing.Point(100, 68)
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
        Me.lbl_StoreCode.Location = New System.Drawing.Point(100, 30)
        Me.lbl_StoreCode.Name = "lbl_StoreCode"
        Me.lbl_StoreCode.Size = New System.Drawing.Size(81, 15)
        Me.lbl_StoreCode.TabIndex = 11
        Me.lbl_StoreCode.Text = "STORE CODE"
        '
        'cmdStoreCode
        '
        Me.cmdStoreCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStoreCode.Image = CType(resources.GetObject("cmdStoreCode.Image"), System.Drawing.Image)
        Me.cmdStoreCode.Location = New System.Drawing.Point(376, 23)
        Me.cmdStoreCode.Name = "cmdStoreCode"
        Me.cmdStoreCode.Size = New System.Drawing.Size(28, 26)
        Me.cmdStoreCode.TabIndex = 12
        '
        'txt_StoreDesc
        '
        Me.txt_StoreDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_StoreDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_StoreDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_StoreDesc.Location = New System.Drawing.Point(257, 68)
        Me.txt_StoreDesc.MaxLength = 50
        Me.txt_StoreDesc.Name = "txt_StoreDesc"
        Me.txt_StoreDesc.ReadOnly = True
        Me.txt_StoreDesc.Size = New System.Drawing.Size(196, 21)
        Me.txt_StoreDesc.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(407, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 24)
        Me.Label16.TabIndex = 472
        Me.Label16.Text = "F4"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txt_StoreDesc)
        Me.GroupBox1.Controls.Add(Me.cmdStoreCode)
        Me.GroupBox1.Controls.Add(Me.lbl_StoreCode)
        Me.GroupBox1.Controls.Add(Me.lbl_StoreDescription)
        Me.GroupBox1.Controls.Add(Me.txt_StoreCode)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(480, 108)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage1)
        Me.TabControl2.Controls.Add(Me.TabPage2)
        Me.TabControl2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl2.Location = New System.Drawing.Point(1, 74)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(556, 509)
        Me.TabControl2.TabIndex = 607
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.shelf_grid)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.lbl_Freeze)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(548, 479)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Store Master"
        '
        'shelf_grid
        '
        Me.shelf_grid.DataSource = Nothing
        Me.shelf_grid.Location = New System.Drawing.Point(174, 345)
        Me.shelf_grid.Name = "shelf_grid"
        Me.shelf_grid.OcxState = CType(resources.GetObject("shelf_grid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.shelf_grid.Size = New System.Drawing.Size(276, 124)
        Me.shelf_grid.TabIndex = 599
        Me.shelf_grid.Visible = False
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
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(24, 428)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 46)
        Me.Button1.TabIndex = 598
        Me.Button1.Text = "Category Master"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(54, 308)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(319, 25)
        Me.lbl_Freeze.TabIndex = 471
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Freeze.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.GroupBox8)
        Me.GroupBox4.Controls.Add(Me.GroupBox7)
        Me.GroupBox4.Controls.Add(Me.GroupBox6)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Opt_Substore)
        Me.GroupBox4.Controls.Add(Me.Opt_Mainstore)
        Me.GroupBox4.Controls.Add(Me.text_storedesc)
        Me.GroupBox4.Controls.Add(Me.help_storecode)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.text_storecode)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(437, 299)
        Me.GroupBox4.TabIndex = 470
        Me.GroupBox4.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.RDB_SESSIONN)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.RDB_SESSIONY)
        Me.GroupBox6.Location = New System.Drawing.Point(40, 252)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(367, 35)
        Me.GroupBox6.TabIndex = 600
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Visible = False
        '
        'RDB_SESSIONN
        '
        Me.RDB_SESSIONN.BackColor = System.Drawing.Color.Transparent
        Me.RDB_SESSIONN.Checked = True
        Me.RDB_SESSIONN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDB_SESSIONN.Location = New System.Drawing.Point(272, 11)
        Me.RDB_SESSIONN.Name = "RDB_SESSIONN"
        Me.RDB_SESSIONN.Size = New System.Drawing.Size(53, 19)
        Me.RDB_SESSIONN.TabIndex = 477
        Me.RDB_SESSIONN.TabStop = True
        Me.RDB_SESSIONN.Text = "NO"
        Me.RDB_SESSIONN.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 15)
        Me.Label1.TabIndex = 477
        Me.Label1.Text = "SESSION REQUIRED"
        '
        'RDB_SESSIONY
        '
        Me.RDB_SESSIONY.BackColor = System.Drawing.Color.Transparent
        Me.RDB_SESSIONY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDB_SESSIONY.Location = New System.Drawing.Point(160, 12)
        Me.RDB_SESSIONY.Name = "RDB_SESSIONY"
        Me.RDB_SESSIONY.Size = New System.Drawing.Size(60, 19)
        Me.RDB_SESSIONY.TabIndex = 478
        Me.RDB_SESSIONY.Text = "YES"
        Me.RDB_SESSIONY.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lbl_shelfreq)
        Me.GroupBox5.Controls.Add(Me.Rdb_ShelfNo)
        Me.GroupBox5.Controls.Add(Me.Rdb_ShelfYes)
        Me.GroupBox5.Location = New System.Drawing.Point(40, 203)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(367, 46)
        Me.GroupBox5.TabIndex = 477
        Me.GroupBox5.TabStop = False
        '
        'lbl_shelfreq
        '
        Me.lbl_shelfreq.AutoSize = True
        Me.lbl_shelfreq.BackColor = System.Drawing.Color.Transparent
        Me.lbl_shelfreq.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shelfreq.Location = New System.Drawing.Point(7, 20)
        Me.lbl_shelfreq.Name = "lbl_shelfreq"
        Me.lbl_shelfreq.Size = New System.Drawing.Size(104, 15)
        Me.lbl_shelfreq.TabIndex = 474
        Me.lbl_shelfreq.Text = "SHELF REQUIRED"
        '
        'Rdb_ShelfNo
        '
        Me.Rdb_ShelfNo.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_ShelfNo.Checked = True
        Me.Rdb_ShelfNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb_ShelfNo.Location = New System.Drawing.Point(272, 16)
        Me.Rdb_ShelfNo.Name = "Rdb_ShelfNo"
        Me.Rdb_ShelfNo.Size = New System.Drawing.Size(53, 19)
        Me.Rdb_ShelfNo.TabIndex = 475
        Me.Rdb_ShelfNo.TabStop = True
        Me.Rdb_ShelfNo.Text = "NO"
        Me.Rdb_ShelfNo.UseVisualStyleBackColor = False
        '
        'Rdb_ShelfYes
        '
        Me.Rdb_ShelfYes.BackColor = System.Drawing.Color.Transparent
        Me.Rdb_ShelfYes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb_ShelfYes.Location = New System.Drawing.Point(161, 18)
        Me.Rdb_ShelfYes.Name = "Rdb_ShelfYes"
        Me.Rdb_ShelfYes.Size = New System.Drawing.Size(60, 19)
        Me.Rdb_ShelfYes.TabIndex = 476
        Me.Rdb_ShelfYes.Text = "YES"
        Me.Rdb_ShelfYes.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 15)
        Me.Label2.TabIndex = 473
        Me.Label2.Text = "STORE TYPE"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(351, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 24)
        Me.Label3.TabIndex = 472
        Me.Label3.Text = "F4"
        '
        'Opt_Substore
        '
        Me.Opt_Substore.BackColor = System.Drawing.Color.Transparent
        Me.Opt_Substore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Substore.Location = New System.Drawing.Point(313, 105)
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
        Me.Opt_Mainstore.Location = New System.Drawing.Point(201, 105)
        Me.Opt_Mainstore.Name = "Opt_Mainstore"
        Me.Opt_Mainstore.Size = New System.Drawing.Size(100, 19)
        Me.Opt_Mainstore.TabIndex = 2
        Me.Opt_Mainstore.Text = "MAIN STORE"
        Me.Opt_Mainstore.UseVisualStyleBackColor = False
        '
        'text_storedesc
        '
        Me.text_storedesc.BackColor = System.Drawing.Color.Wheat
        Me.text_storedesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.text_storedesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.text_storedesc.Location = New System.Drawing.Point(204, 68)
        Me.text_storedesc.MaxLength = 50
        Me.text_storedesc.Name = "text_storedesc"
        Me.text_storedesc.Size = New System.Drawing.Size(196, 21)
        Me.text_storedesc.TabIndex = 1
        '
        'help_storecode
        '
        Me.help_storecode.FlatAppearance.BorderSize = 0
        Me.help_storecode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.help_storecode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.help_storecode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.help_storecode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.help_storecode.Image = CType(resources.GetObject("help_storecode.Image"), System.Drawing.Image)
        Me.help_storecode.Location = New System.Drawing.Point(323, 22)
        Me.help_storecode.Name = "help_storecode"
        Me.help_storecode.Size = New System.Drawing.Size(23, 26)
        Me.help_storecode.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(47, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "STORE CODE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(47, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "STORE DESCRIPTION"
        '
        'text_storecode
        '
        Me.text_storecode.BackColor = System.Drawing.Color.Wheat
        Me.text_storecode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.text_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.text_storecode.Location = New System.Drawing.Point(204, 26)
        Me.text_storecode.MaxLength = 5
        Me.text_storecode.Name = "text_storecode"
        Me.text_storecode.Size = New System.Drawing.Size(117, 21)
        Me.text_storecode.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(548, 479)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Store Category Tagging"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(209, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(169, 22)
        Me.Label6.TabIndex = 469
        Me.Label6.Text = "STORE  MASTER"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.rdb_buffet_N)
        Me.GroupBox7.Controls.Add(Me.rdb_buffet_Y)
        Me.GroupBox7.Location = New System.Drawing.Point(43, 127)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(367, 37)
        Me.GroupBox7.TabIndex = 478
        Me.GroupBox7.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 15)
        Me.Label7.TabIndex = 474
        Me.Label7.Text = "BUFFET"
        '
        'rdb_buffet_N
        '
        Me.rdb_buffet_N.BackColor = System.Drawing.Color.Transparent
        Me.rdb_buffet_N.Checked = True
        Me.rdb_buffet_N.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_buffet_N.Location = New System.Drawing.Point(272, 13)
        Me.rdb_buffet_N.Name = "rdb_buffet_N"
        Me.rdb_buffet_N.Size = New System.Drawing.Size(53, 19)
        Me.rdb_buffet_N.TabIndex = 475
        Me.rdb_buffet_N.TabStop = True
        Me.rdb_buffet_N.Text = "NO"
        Me.rdb_buffet_N.UseVisualStyleBackColor = False
        '
        'rdb_buffet_Y
        '
        Me.rdb_buffet_Y.BackColor = System.Drawing.Color.Transparent
        Me.rdb_buffet_Y.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_buffet_Y.Location = New System.Drawing.Point(158, 14)
        Me.rdb_buffet_Y.Name = "rdb_buffet_Y"
        Me.rdb_buffet_Y.Size = New System.Drawing.Size(60, 19)
        Me.rdb_buffet_Y.TabIndex = 476
        Me.rdb_buffet_Y.Text = "YES"
        Me.rdb_buffet_Y.UseVisualStyleBackColor = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.rdb_banquet_N)
        Me.GroupBox8.Controls.Add(Me.rdb_banquet_Y)
        Me.GroupBox8.Location = New System.Drawing.Point(41, 170)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(367, 37)
        Me.GroupBox8.TabIndex = 479
        Me.GroupBox8.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 15)
        Me.Label8.TabIndex = 474
        Me.Label8.Text = "BANQUET"
        '
        'rdb_banquet_N
        '
        Me.rdb_banquet_N.BackColor = System.Drawing.Color.Transparent
        Me.rdb_banquet_N.Checked = True
        Me.rdb_banquet_N.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_banquet_N.Location = New System.Drawing.Point(273, 10)
        Me.rdb_banquet_N.Name = "rdb_banquet_N"
        Me.rdb_banquet_N.Size = New System.Drawing.Size(53, 19)
        Me.rdb_banquet_N.TabIndex = 475
        Me.rdb_banquet_N.TabStop = True
        Me.rdb_banquet_N.Text = "NO"
        Me.rdb_banquet_N.UseVisualStyleBackColor = False
        '
        'rdb_banquet_Y
        '
        Me.rdb_banquet_Y.BackColor = System.Drawing.Color.Transparent
        Me.rdb_banquet_Y.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdb_banquet_Y.Location = New System.Drawing.Point(159, 12)
        Me.rdb_banquet_Y.Name = "rdb_banquet_Y"
        Me.rdb_banquet_Y.Size = New System.Drawing.Size(60, 19)
        Me.rdb_banquet_Y.TabIndex = 476
        Me.rdb_banquet_Y.Text = "YES"
        Me.rdb_banquet_Y.UseVisualStyleBackColor = False
        '
        'Inv_StoreCategoryLink
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(709, 595)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Inv_StoreCategoryLink"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inv_StoreCategoryLink"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.shelf_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents AxfpSpread1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents txt_StoreCode As TextBox
    Friend WithEvents lbl_StoreDescription As Label
    Friend WithEvents lbl_StoreCode As Label
    Friend WithEvents cmdStoreCode As Button
    Friend WithEvents txt_StoreDesc As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lbl_Freeze As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Opt_Substore As RadioButton
    Friend WithEvents Opt_Mainstore As RadioButton
    Friend WithEvents text_storedesc As TextBox
    Friend WithEvents help_storecode As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents text_storecode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents shelf_grid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Rdb_ShelfYes As RadioButton
    Friend WithEvents Rdb_ShelfNo As RadioButton
    Friend WithEvents lbl_shelfreq As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents RDB_SESSIONN As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents RDB_SESSIONY As RadioButton
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents rdb_buffet_N As RadioButton
    Friend WithEvents rdb_buffet_Y As RadioButton
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents rdb_banquet_N As RadioButton
    Friend WithEvents rdb_banquet_Y As RadioButton
End Class
