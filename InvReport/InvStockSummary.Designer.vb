<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvStockSummary
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvStockSummary))
        Me.ChkItemCode = New System.Windows.Forms.CheckBox()
        Me.ChkCategory = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox3 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_Itemlist = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DTPaSondATE = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txt_mainstore = New System.Windows.Forms.TextBox()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.txt_mainstorecode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtptodate = New System.Windows.Forms.DateTimePicker()
        Me.dtpfromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChBZero = New System.Windows.Forms.CheckBox()
        Me.ButExport = New System.Windows.Forms.Button()
        Me.chkdetail = New System.Windows.Forms.CheckBox()
        Me.chksummary = New System.Windows.Forms.CheckBox()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chk_without_zero = New System.Windows.Forms.CheckBox()
        Me.CHK_DisplayColumn = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChkItemCode
        '
        Me.ChkItemCode.AutoSize = True
        Me.ChkItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkItemCode.Location = New System.Drawing.Point(314, 12)
        Me.ChkItemCode.Name = "ChkItemCode"
        Me.ChkItemCode.Size = New System.Drawing.Size(90, 17)
        Me.ChkItemCode.TabIndex = 10
        Me.ChkItemCode.Text = "ITEMCODE"
        Me.ChkItemCode.UseVisualStyleBackColor = True
        '
        'ChkCategory
        '
        Me.ChkCategory.AutoSize = True
        Me.ChkCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCategory.Location = New System.Drawing.Point(69, 12)
        Me.ChkCategory.Name = "ChkCategory"
        Me.ChkCategory.Size = New System.Drawing.Size(93, 17)
        Me.ChkCategory.TabIndex = 9
        Me.ChkCategory.Text = "CATEGORY"
        Me.ChkCategory.UseVisualStyleBackColor = True
        '
        'CheckedListBox3
        '
        Me.CheckedListBox3.CheckOnClick = True
        Me.CheckedListBox3.FormattingEnabled = True
        Me.CheckedListBox3.Location = New System.Drawing.Point(314, 56)
        Me.CheckedListBox3.Name = "CheckedListBox3"
        Me.CheckedListBox3.Size = New System.Drawing.Size(200, 274)
        Me.CheckedListBox3.TabIndex = 8
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Location = New System.Drawing.Point(69, 56)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(200, 274)
        Me.CheckedListBox2.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbl_Itemlist)
        Me.GroupBox1.Controls.Add(Me.ChkItemCode)
        Me.GroupBox1.Controls.Add(Me.ChkCategory)
        Me.GroupBox1.Controls.Add(Me.CheckedListBox3)
        Me.GroupBox1.Controls.Add(Me.CheckedListBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(541, 351)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Maroon
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(480, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 25)
        Me.Label10.TabIndex = 511
        Me.Label10.Text = "F1"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(457, 33)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox4.TabIndex = 510
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Maroon
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(231, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 24)
        Me.Label9.TabIndex = 509
        Me.Label9.Text = "F2"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(210, 31)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.TabIndex = 508
        Me.PictureBox3.TabStop = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Maroon
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(68, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(198, 24)
        Me.Label6.TabIndex = 504
        Me.Label6.Text = "SELECT CATEGORY :"
        '
        'lbl_Itemlist
        '
        Me.lbl_Itemlist.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Itemlist.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemlist.ForeColor = System.Drawing.Color.White
        Me.lbl_Itemlist.Location = New System.Drawing.Point(314, 32)
        Me.lbl_Itemlist.Name = "lbl_Itemlist"
        Me.lbl_Itemlist.Size = New System.Drawing.Size(200, 24)
        Me.lbl_Itemlist.TabIndex = 503
        Me.lbl_Itemlist.Text = "SELECT  ITEMCODE :"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.txt_mainstore)
        Me.GroupBox3.Controls.Add(Me.cmd_storecode)
        Me.GroupBox3.Controls.Add(Me.txt_mainstorecode)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.dtptodate)
        Me.GroupBox3.Controls.Add(Me.dtpfromdate)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 482)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(626, 109)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.DTPaSondATE)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 58)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(626, 54)
        Me.GroupBox4.TabIndex = 494
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Visible = False
        '
        'DTPaSondATE
        '
        Me.DTPaSondATE.CustomFormat = "dd/MMM/yyyy"
        Me.DTPaSondATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPaSondATE.Location = New System.Drawing.Point(245, 18)
        Me.DTPaSondATE.Name = "DTPaSondATE"
        Me.DTPaSondATE.Size = New System.Drawing.Size(200, 20)
        Me.DTPaSondATE.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(182, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "DATE"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(9, 42)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(91, 17)
        Me.CheckBox1.TabIndex = 493
        Me.CheckBox1.Text = "AS ON DATE"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txt_mainstore
        '
        Me.txt_mainstore.Location = New System.Drawing.Point(244, 14)
        Me.txt_mainstore.Name = "txt_mainstore"
        Me.txt_mainstore.Size = New System.Drawing.Size(167, 20)
        Me.txt_mainstore.TabIndex = 487
        '
        'cmd_storecode
        '
        Me.cmd_storecode.FlatAppearance.BorderSize = 0
        Me.cmd_storecode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_storecode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_storecode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(211, 13)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 486
        '
        'txt_mainstorecode
        '
        Me.txt_mainstorecode.Location = New System.Drawing.Point(91, 15)
        Me.txt_mainstorecode.Name = "txt_mainstorecode"
        Me.txt_mainstorecode.Size = New System.Drawing.Size(117, 20)
        Me.txt_mainstorecode.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "STORE"
        '
        'dtptodate
        '
        Me.dtptodate.CustomFormat = "dd/MM/yyyy"
        Me.dtptodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtptodate.Location = New System.Drawing.Point(358, 67)
        Me.dtptodate.Name = "dtptodate"
        Me.dtptodate.Size = New System.Drawing.Size(200, 20)
        Me.dtptodate.TabIndex = 3
        '
        'dtpfromdate
        '
        Me.dtpfromdate.CustomFormat = "dd/MM/yyyy"
        Me.dtpfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfromdate.Location = New System.Drawing.Point(89, 67)
        Me.dtpfromdate.Name = "dtpfromdate"
        Me.dtpfromdate.Size = New System.Drawing.Size(200, 20)
        Me.dtpfromdate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(295, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TODATE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FROM DATE"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.CHK_DisplayColumn)
        Me.GroupBox2.Controls.Add(Me.ChBZero)
        Me.GroupBox2.Controls.Add(Me.ButExport)
        Me.GroupBox2.Controls.Add(Me.chkdetail)
        Me.GroupBox2.Controls.Add(Me.chksummary)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.Cmd_Print)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Location = New System.Drawing.Point(580, 115)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 346)
        Me.GroupBox2.TabIndex = 488
        Me.GroupBox2.TabStop = False
        '
        'ChBZero
        '
        Me.ChBZero.AutoSize = True
        Me.ChBZero.Location = New System.Drawing.Point(2, 285)
        Me.ChBZero.Name = "ChBZero"
        Me.ChBZero.Size = New System.Drawing.Size(116, 17)
        Me.ChBZero.TabIndex = 494
        Me.ChBZero.Text = "WITH ZERO QTY."
        Me.ChBZero.UseVisualStyleBackColor = True
        '
        'ButExport
        '
        Me.ButExport.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButExport.BackgroundImage = CType(resources.GetObject("ButExport.BackgroundImage"), System.Drawing.Image)
        Me.ButExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButExport.FlatAppearance.BorderSize = 0
        Me.ButExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButExport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButExport.ForeColor = System.Drawing.Color.Black
        Me.ButExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButExport.Location = New System.Drawing.Point(3, 159)
        Me.ButExport.Name = "ButExport"
        Me.ButExport.Size = New System.Drawing.Size(144, 46)
        Me.ButExport.TabIndex = 493
        Me.ButExport.Text = "Export[F12]"
        Me.ButExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButExport.UseVisualStyleBackColor = False
        '
        'chkdetail
        '
        Me.chkdetail.AutoSize = True
        Me.chkdetail.Location = New System.Drawing.Point(3, 308)
        Me.chkdetail.Name = "chkdetail"
        Me.chkdetail.Size = New System.Drawing.Size(64, 17)
        Me.chkdetail.TabIndex = 492
        Me.chkdetail.Text = "DETAIL"
        Me.chkdetail.UseVisualStyleBackColor = True
        Me.chkdetail.Visible = False
        '
        'chksummary
        '
        Me.chksummary.AutoSize = True
        Me.chksummary.Location = New System.Drawing.Point(2, 260)
        Me.chksummary.Name = "chksummary"
        Me.chksummary.Size = New System.Drawing.Size(115, 17)
        Me.chksummary.TabIndex = 491
        Me.chksummary.Text = "WITH OPENNING"
        Me.chksummary.UseVisualStyleBackColor = True
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(3, 208)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Exit.TabIndex = 490
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Print.BackgroundImage = CType(resources.GetObject("Cmd_Print.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Print.FlatAppearance.BorderSize = 0
        Me.Cmd_Print.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(3, 110)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Print.TabIndex = 489
        Me.Cmd_Print.Text = " Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_View.BackgroundImage = CType(resources.GetObject("Cmd_View.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_View.FlatAppearance.BorderSize = 0
        Me.Cmd_View.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(4, 61)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_View.TabIndex = 488
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(4, 12)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Clear.TabIndex = 487
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(209, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(198, 23)
        Me.Label16.TabIndex = 491
        Me.Label16.Text = "STOCK SUMMARY"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chk_without_zero
        '
        Me.chk_without_zero.AutoSize = True
        Me.chk_without_zero.Location = New System.Drawing.Point(580, 467)
        Me.chk_without_zero.Name = "chk_without_zero"
        Me.chk_without_zero.Size = New System.Drawing.Size(166, 17)
        Me.chk_without_zero.TabIndex = 495
        Me.chk_without_zero.Text = "WITH ZERO CLOSING QTY."
        Me.chk_without_zero.UseVisualStyleBackColor = True
        '
        'CHK_DisplayColumn
        '
        Me.CHK_DisplayColumn.AutoSize = True
        Me.CHK_DisplayColumn.Location = New System.Drawing.Point(3, 329)
        Me.CHK_DisplayColumn.Name = "CHK_DisplayColumn"
        Me.CHK_DisplayColumn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CHK_DisplayColumn.Size = New System.Drawing.Size(123, 17)
        Me.CHK_DisplayColumn.TabIndex = 496
        Me.CHK_DisplayColumn.Text = "With Display Column"
        Me.CHK_DisplayColumn.UseVisualStyleBackColor = True
        '
        'InvStockSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(769, 613)
        Me.Controls.Add(Me.chk_without_zero)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "InvStockSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InvStockSummary"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChkItemCode As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCategory As System.Windows.Forms.CheckBox
    Friend WithEvents CheckedListBox3 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBox2 As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_mainstore As System.Windows.Forms.TextBox
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents txt_mainstorecode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtptodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkdetail As System.Windows.Forms.CheckBox
    Friend WithEvents chksummary As System.Windows.Forms.CheckBox
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents ButExport As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Itemlist As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPaSondATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChBZero As System.Windows.Forms.CheckBox
    Friend WithEvents chk_without_zero As CheckBox
    Friend WithEvents CHK_DisplayColumn As System.Windows.Forms.CheckBox
End Class
