<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_STOCKINDENT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_STOCKINDENT))
        Me.grp_Grngroup1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_IndentNo = New System.Windows.Forms.TextBox()
        Me.txt_storecode = New System.Windows.Forms.TextBox()
        Me.lbl_Suppliercode = New System.Windows.Forms.Label()
        Me.TXT_FROMSTORECODE = New System.Windows.Forms.TextBox()
        Me.lbl_Grndate = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_FromStorename = New System.Windows.Forms.TextBox()
        Me.cmd_fromStorecodeHelp = New System.Windows.Forms.Button()
        Me.lbl_Grnno = New System.Windows.Forms.Label()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.txt_storeDesc = New System.Windows.Forms.TextBox()
        Me.dtp_Indentdate = New System.Windows.Forms.DateTimePicker()
        Me.cmd_indentnoHelp = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_Totalamount = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.AxfpSpread1 = New AxFPUSpreadADO.AxfpSpread()
        Me.Txt_qty = New System.Windows.Forms.TextBox()
        Me.lbl_closingqty = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_Remarks = New System.Windows.Forms.TextBox()
        Me.lbl_Remarks = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.cmd_print = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.cmd_Exit = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btn_Auto_fill = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmd_View = New System.Windows.Forms.Button()
        Me.CMD_APPROVE = New System.Windows.Forms.Button()
        Me.grp_Grngroup1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_Grngroup1
        '
        Me.grp_Grngroup1.BackColor = System.Drawing.Color.Transparent
        Me.grp_Grngroup1.Controls.Add(Me.PictureBox2)
        Me.grp_Grngroup1.Controls.Add(Me.Label1)
        Me.grp_Grngroup1.Controls.Add(Me.txt_IndentNo)
        Me.grp_Grngroup1.Controls.Add(Me.txt_storecode)
        Me.grp_Grngroup1.Controls.Add(Me.lbl_Suppliercode)
        Me.grp_Grngroup1.Controls.Add(Me.TXT_FROMSTORECODE)
        Me.grp_Grngroup1.Controls.Add(Me.lbl_Grndate)
        Me.grp_Grngroup1.Controls.Add(Me.Label16)
        Me.grp_Grngroup1.Controls.Add(Me.txt_FromStorename)
        Me.grp_Grngroup1.Controls.Add(Me.cmd_fromStorecodeHelp)
        Me.grp_Grngroup1.Controls.Add(Me.lbl_Grnno)
        Me.grp_Grngroup1.Controls.Add(Me.cmd_storecode)
        Me.grp_Grngroup1.Controls.Add(Me.txt_storeDesc)
        Me.grp_Grngroup1.Controls.Add(Me.dtp_Indentdate)
        Me.grp_Grngroup1.Controls.Add(Me.cmd_indentnoHelp)
        Me.grp_Grngroup1.Location = New System.Drawing.Point(12, 90)
        Me.grp_Grngroup1.Name = "grp_Grngroup1"
        Me.grp_Grngroup1.Size = New System.Drawing.Size(643, 126)
        Me.grp_Grngroup1.TabIndex = 23
        Me.grp_Grngroup1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(456, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 473
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(119, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 15)
        Me.Label1.TabIndex = 395
        Me.Label1.Text = "MAIN STORE :"
        '
        'txt_IndentNo
        '
        Me.txt_IndentNo.BackColor = System.Drawing.Color.Wheat
        Me.txt_IndentNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_IndentNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_IndentNo.Location = New System.Drawing.Point(109, 16)
        Me.txt_IndentNo.MaxLength = 50
        Me.txt_IndentNo.Name = "txt_IndentNo"
        Me.txt_IndentNo.Size = New System.Drawing.Size(128, 21)
        Me.txt_IndentNo.TabIndex = 1
        '
        'txt_storecode
        '
        Me.txt_storecode.BackColor = System.Drawing.Color.Wheat
        Me.txt_storecode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_storecode.Location = New System.Drawing.Point(219, 51)
        Me.txt_storecode.MaxLength = 50
        Me.txt_storecode.Name = "txt_storecode"
        Me.txt_storecode.Size = New System.Drawing.Size(48, 21)
        Me.txt_storecode.TabIndex = 2
        '
        'lbl_Suppliercode
        '
        Me.lbl_Suppliercode.AutoSize = True
        Me.lbl_Suppliercode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Suppliercode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Suppliercode.Location = New System.Drawing.Point(10, 20)
        Me.lbl_Suppliercode.Name = "lbl_Suppliercode"
        Me.lbl_Suppliercode.Size = New System.Drawing.Size(74, 15)
        Me.lbl_Suppliercode.TabIndex = 28
        Me.lbl_Suppliercode.Text = "INDENT NO :"
        '
        'TXT_FROMSTORECODE
        '
        Me.TXT_FROMSTORECODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_FROMSTORECODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_FROMSTORECODE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_FROMSTORECODE.Location = New System.Drawing.Point(219, 80)
        Me.TXT_FROMSTORECODE.MaxLength = 50
        Me.TXT_FROMSTORECODE.Name = "TXT_FROMSTORECODE"
        Me.TXT_FROMSTORECODE.Size = New System.Drawing.Size(48, 21)
        Me.TXT_FROMSTORECODE.TabIndex = 3
        '
        'lbl_Grndate
        '
        Me.lbl_Grndate.AutoSize = True
        Me.lbl_Grndate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grndate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grndate.Location = New System.Drawing.Point(357, 17)
        Me.lbl_Grndate.Name = "lbl_Grndate"
        Me.lbl_Grndate.Size = New System.Drawing.Size(86, 15)
        Me.lbl_Grndate.TabIndex = 25
        Me.lbl_Grndate.Text = "INDENT DATE :"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(268, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 24)
        Me.Label16.TabIndex = 472
        Me.Label16.Text = "F4"
        Me.Label16.Visible = False
        '
        'txt_FromStorename
        '
        Me.txt_FromStorename.BackColor = System.Drawing.Color.Wheat
        Me.txt_FromStorename.Enabled = False
        Me.txt_FromStorename.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FromStorename.Location = New System.Drawing.Point(295, 79)
        Me.txt_FromStorename.MaxLength = 50
        Me.txt_FromStorename.Name = "txt_FromStorename"
        Me.txt_FromStorename.Size = New System.Drawing.Size(208, 21)
        Me.txt_FromStorename.TabIndex = 392
        '
        'cmd_fromStorecodeHelp
        '
        Me.cmd_fromStorecodeHelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_fromStorecodeHelp.Image = CType(resources.GetObject("cmd_fromStorecodeHelp.Image"), System.Drawing.Image)
        Me.cmd_fromStorecodeHelp.Location = New System.Drawing.Point(268, 77)
        Me.cmd_fromStorecodeHelp.Name = "cmd_fromStorecodeHelp"
        Me.cmd_fromStorecodeHelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_fromStorecodeHelp.TabIndex = 393
        '
        'lbl_Grnno
        '
        Me.lbl_Grnno.AutoSize = True
        Me.lbl_Grnno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grnno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grnno.Location = New System.Drawing.Point(119, 54)
        Me.lbl_Grnno.Name = "lbl_Grnno"
        Me.lbl_Grnno.Size = New System.Drawing.Size(86, 15)
        Me.lbl_Grnno.TabIndex = 23
        Me.lbl_Grnno.Text = "ISSUE STORE:"
        '
        'cmd_storecode
        '
        Me.cmd_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(268, 49)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 375
        '
        'txt_storeDesc
        '
        Me.txt_storeDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_storeDesc.Enabled = False
        Me.txt_storeDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_storeDesc.Location = New System.Drawing.Point(294, 51)
        Me.txt_storeDesc.MaxLength = 50
        Me.txt_storeDesc.Name = "txt_storeDesc"
        Me.txt_storeDesc.Size = New System.Drawing.Size(208, 21)
        Me.txt_storeDesc.TabIndex = 4
        '
        'dtp_Indentdate
        '
        Me.dtp_Indentdate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Indentdate.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtp_Indentdate.CalendarTitleForeColor = System.Drawing.Color.AliceBlue
        Me.dtp_Indentdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Indentdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Indentdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Indentdate.Location = New System.Drawing.Point(492, 15)
        Me.dtp_Indentdate.Name = "dtp_Indentdate"
        Me.dtp_Indentdate.Size = New System.Drawing.Size(123, 21)
        Me.dtp_Indentdate.TabIndex = 1
        '
        'cmd_indentnoHelp
        '
        Me.cmd_indentnoHelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_indentnoHelp.Image = CType(resources.GetObject("cmd_indentnoHelp.Image"), System.Drawing.Image)
        Me.cmd_indentnoHelp.Location = New System.Drawing.Point(240, 14)
        Me.cmd_indentnoHelp.Name = "cmd_indentnoHelp"
        Me.cmd_indentnoHelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_indentnoHelp.TabIndex = 377
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_Totalamount)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.AxfpSpread1)
        Me.GroupBox1.Controls.Add(Me.Txt_qty)
        Me.GroupBox1.Controls.Add(Me.lbl_closingqty)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 218)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(643, 242)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(462, 212)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 15)
        Me.Label8.TabIndex = 5610
        Me.Label8.Text = "Total Amt."
        '
        'txt_Totalamount
        '
        Me.txt_Totalamount.BackColor = System.Drawing.Color.Wheat
        Me.txt_Totalamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Totalamount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Totalamount.Location = New System.Drawing.Point(537, 208)
        Me.txt_Totalamount.MaxLength = 15
        Me.txt_Totalamount.Name = "txt_Totalamount"
        Me.txt_Totalamount.ReadOnly = True
        Me.txt_Totalamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Totalamount.Size = New System.Drawing.Size(84, 26)
        Me.txt_Totalamount.TabIndex = 5609
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(293, 212)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 15)
        Me.Label7.TabIndex = 493
        Me.Label7.Text = "Total Qty."
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(6, 16)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(631, 179)
        Me.AxfpSpread1.TabIndex = 0
        '
        'Txt_qty
        '
        Me.Txt_qty.BackColor = System.Drawing.Color.Wheat
        Me.Txt_qty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_qty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_qty.Location = New System.Drawing.Point(359, 206)
        Me.Txt_qty.MaxLength = 15
        Me.Txt_qty.Name = "Txt_qty"
        Me.Txt_qty.ReadOnly = True
        Me.Txt_qty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Txt_qty.Size = New System.Drawing.Size(87, 26)
        Me.Txt_qty.TabIndex = 492
        Me.Txt_qty.Text = "."
        '
        'lbl_closingqty
        '
        Me.lbl_closingqty.AutoSize = True
        Me.lbl_closingqty.BackColor = System.Drawing.Color.Transparent
        Me.lbl_closingqty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_closingqty.Location = New System.Drawing.Point(17, 219)
        Me.lbl_closingqty.Name = "lbl_closingqty"
        Me.lbl_closingqty.Size = New System.Drawing.Size(80, 15)
        Me.lbl_closingqty.TabIndex = 491
        Me.lbl_closingqty.Text = "closingstock"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.txt_Remarks)
        Me.GroupBox4.Controls.Add(Me.lbl_Remarks)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 480)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(587, 62)
        Me.GroupBox4.TabIndex = 467
        Me.GroupBox4.TabStop = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(16, 32)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 24)
        Me.Label20.TabIndex = 477
        Me.Label20.Text = "ALT+ R"
        Me.Label20.Visible = False
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BackColor = System.Drawing.Color.White
        Me.txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Remarks.Location = New System.Drawing.Point(104, 16)
        Me.txt_Remarks.MaxLength = 200
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(459, 32)
        Me.txt_Remarks.TabIndex = 14
        '
        'lbl_Remarks
        '
        Me.lbl_Remarks.AutoSize = True
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Remarks.Location = New System.Drawing.Point(16, 16)
        Me.lbl_Remarks.Name = "lbl_Remarks"
        Me.lbl_Remarks.Size = New System.Drawing.Size(67, 15)
        Me.lbl_Remarks.TabIndex = 43
        Me.lbl_Remarks.Text = "REMARKS "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(229, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 24)
        Me.Label2.TabIndex = 468
        Me.Label2.Text = "STOCK INDENT"
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
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(7, 204)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(114, 46)
        Me.Cmd_Freeze.TabIndex = 487
        Me.Cmd_Freeze.Text = "Void[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
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
        Me.Cmd_Clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(7, 11)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(114, 46)
        Me.Cmd_Clear.TabIndex = 488
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
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
        Me.Cmd_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(7, 59)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(114, 46)
        Me.Cmd_Add.TabIndex = 486
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'cmd_print
        '
        Me.cmd_print.BackColor = System.Drawing.Color.Transparent
        Me.cmd_print.BackgroundImage = Global.Inventory.My.Resources.Resources.print
        Me.cmd_print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_print.ForeColor = System.Drawing.Color.Black
        Me.cmd_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_print.Location = New System.Drawing.Point(764, 27)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(57, 19)
        Me.cmd_print.TabIndex = 483
        Me.cmd_print.Text = "Print [F10]"
        Me.cmd_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_print.UseVisualStyleBackColor = False
        Me.cmd_print.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(221, 51)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(585, 25)
        Me.lbl_Freeze.TabIndex = 474
        Me.lbl_Freeze.Text = " "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'cmd_Exit
        '
        Me.cmd_Exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_Exit.BackgroundImage = CType(resources.GetObject("cmd_Exit.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Exit.FlatAppearance.BorderSize = 0
        Me.cmd_Exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Exit.Location = New System.Drawing.Point(7, 300)
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.Size = New System.Drawing.Size(114, 46)
        Me.cmd_Exit.TabIndex = 489
        Me.cmd_Exit.Text = "Exit[F11]"
        Me.cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Exit.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.btn_Auto_fill)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.cmd_View)
        Me.GroupBox3.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox3.Controls.Add(Me.cmd_Exit)
        Me.GroupBox3.Controls.Add(Me.Cmd_Add)
        Me.GroupBox3.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox3.Location = New System.Drawing.Point(709, 110)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(130, 359)
        Me.GroupBox3.TabIndex = 490
        Me.GroupBox3.TabStop = False
        '
        'btn_Auto_fill
        '
        Me.btn_Auto_fill.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_Auto_fill.BackgroundImage = Global.Inventory.My.Resources.Resources.save
        Me.btn_Auto_fill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_Auto_fill.FlatAppearance.BorderSize = 0
        Me.btn_Auto_fill.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btn_Auto_fill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_Auto_fill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_Auto_fill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Auto_fill.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Auto_fill.ForeColor = System.Drawing.Color.Black
        Me.btn_Auto_fill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Auto_fill.Location = New System.Drawing.Point(7, 252)
        Me.btn_Auto_fill.Name = "btn_Auto_fill"
        Me.btn_Auto_fill.Size = New System.Drawing.Size(114, 46)
        Me.btn_Auto_fill.TabIndex = 492
        Me.btn_Auto_fill.Text = "Auto Fill"
        Me.btn_Auto_fill.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_Auto_fill.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(7, 156)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 46)
        Me.Button1.TabIndex = 491
        Me.Button1.Text = "Print[F10]"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmd_View
        '
        Me.cmd_View.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_View.BackgroundImage = CType(resources.GetObject("cmd_View.BackgroundImage"), System.Drawing.Image)
        Me.cmd_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_View.FlatAppearance.BorderSize = 0
        Me.cmd_View.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_View.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View.ForeColor = System.Drawing.Color.Black
        Me.cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_View.Location = New System.Drawing.Point(7, 107)
        Me.cmd_View.Name = "cmd_View"
        Me.cmd_View.Size = New System.Drawing.Size(114, 46)
        Me.cmd_View.TabIndex = 490
        Me.cmd_View.Text = " View[F9]"
        Me.cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_View.UseVisualStyleBackColor = False
        '
        'CMD_APPROVE
        '
        Me.CMD_APPROVE.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CMD_APPROVE.FlatAppearance.BorderSize = 0
        Me.CMD_APPROVE.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CMD_APPROVE.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CMD_APPROVE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CMD_APPROVE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMD_APPROVE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_APPROVE.Image = CType(resources.GetObject("CMD_APPROVE.Image"), System.Drawing.Image)
        Me.CMD_APPROVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_APPROVE.Location = New System.Drawing.Point(709, 475)
        Me.CMD_APPROVE.Name = "CMD_APPROVE"
        Me.CMD_APPROVE.Size = New System.Drawing.Size(124, 46)
        Me.CMD_APPROVE.TabIndex = 5608
        Me.CMD_APPROVE.Text = "APPROVE"
        Me.CMD_APPROVE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_APPROVE.UseVisualStyleBackColor = False
        Me.CMD_APPROVE.Visible = False
        '
        'Frm_STOCKINDENT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(859, 547)
        Me.Controls.Add(Me.CMD_APPROVE)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.cmd_print)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_Grngroup1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Frm_STOCKINDENT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_STOCKINDENT"
        Me.grp_Grngroup1.ResumeLayout(False)
        Me.grp_Grngroup1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp_Grngroup1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_IndentNo As System.Windows.Forms.TextBox
    Friend WithEvents txt_storecode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Suppliercode As System.Windows.Forms.Label
    Friend WithEvents TXT_FROMSTORECODE As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Grndate As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_FromStorename As System.Windows.Forms.TextBox
    Friend WithEvents cmd_fromStorecodeHelp As System.Windows.Forms.Button
    Friend WithEvents lbl_Grnno As System.Windows.Forms.Label
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents txt_storeDesc As System.Windows.Forms.TextBox
    Friend WithEvents dtp_Indentdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmd_indentnoHelp As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AxfpSpread1 As AxFPUSpreadADO.AxfpSpread
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Remarks As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents cmd_print As System.Windows.Forms.Button
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmd_View As System.Windows.Forms.Button
    Friend WithEvents btn_Auto_fill As System.Windows.Forms.Button
    Friend WithEvents lbl_closingqty As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_qty As System.Windows.Forms.TextBox
    Friend WithEvents CMD_APPROVE As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_Totalamount As TextBox
End Class
