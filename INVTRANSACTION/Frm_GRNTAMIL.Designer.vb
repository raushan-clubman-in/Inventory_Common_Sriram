<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GRNTAMIL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GRNTAMIL))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.grp_Grngroup1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_PONo = New System.Windows.Forms.TextBox()
        Me.cmd_PONOhelp = New System.Windows.Forms.Button()
        Me.CMB_CATEGORY = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtp_Grndate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Grnno = New System.Windows.Forms.Label()
        Me.txt_Grnno = New System.Windows.Forms.TextBox()
        Me.cmd_Grnnohelp = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbl_Grndate = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbl_Suppliercode = New System.Windows.Forms.Label()
        Me.txt_Suppliercode = New System.Windows.Forms.TextBox()
        Me.cmd_Suppliercodehelp = New System.Windows.Forms.Button()
        Me.txt_Suppliername = New System.Windows.Forms.TextBox()
        Me.txt_Supplierinvno = New System.Windows.Forms.TextBox()
        Me.lbl_Supplierinvno = New System.Windows.Forms.Label()
        Me.lbl_Supplierinvdate = New System.Windows.Forms.Label()
        Me.dtp_Supplierinvdate = New System.Windows.Forms.DateTimePicker()
        Me.txt_Storecode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmd_Storecode = New System.Windows.Forms.Button()
        Me.txt_StoreDesc = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.AxfpSpread1 = New AxFPUSpreadADO.AxfpSpread()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLoadingChrg = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.txt_totaltax = New System.Windows.Forms.TextBox()
        Me.txt_totdisc = New System.Windows.Forms.TextBox()
        Me.lbl_Surchargeamt = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Surchargeamt = New System.Windows.Forms.TextBox()
        Me.TXT_OVERALLdiscount = New System.Windows.Forms.TextBox()
        Me.lbl_Billamount = New System.Windows.Forms.Label()
        Me.txt_Billamount = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.LabelClosingQuantity = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_Remarks = New System.Windows.Forms.TextBox()
        Me.lbl_Remarks = New System.Windows.Forms.Label()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.btn_auth = New System.Windows.Forms.Button()
        Me.cmd_print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.directgrn = New System.Windows.Forms.CheckBox()
        Me.grp_Grngroup1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(338, 34)
        Me.lbl_Heading.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(382, 33)
        Me.lbl_Heading.TabIndex = 22
        Me.lbl_Heading.Text = "GRN CUM PURCHASE BILL"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp_Grngroup1
        '
        Me.grp_Grngroup1.BackColor = System.Drawing.Color.Transparent
        Me.grp_Grngroup1.Controls.Add(Me.Label4)
        Me.grp_Grngroup1.Controls.Add(Me.Txt_PONo)
        Me.grp_Grngroup1.Controls.Add(Me.cmd_PONOhelp)
        Me.grp_Grngroup1.Location = New System.Drawing.Point(23, 183)
        Me.grp_Grngroup1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grp_Grngroup1.Name = "grp_Grngroup1"
        Me.grp_Grngroup1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grp_Grngroup1.Size = New System.Drawing.Size(501, 62)
        Me.grp_Grngroup1.TabIndex = 23
        Me.grp_Grngroup1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 19)
        Me.Label4.TabIndex = 433
        Me.Label4.Text = "P.O NO"
        '
        'Txt_PONo
        '
        Me.Txt_PONo.BackColor = System.Drawing.Color.Wheat
        Me.Txt_PONo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PONo.Location = New System.Drawing.Point(183, 18)
        Me.Txt_PONo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Txt_PONo.MaxLength = 50
        Me.Txt_PONo.Name = "Txt_PONo"
        Me.Txt_PONo.Size = New System.Drawing.Size(256, 28)
        Me.Txt_PONo.TabIndex = 0
        '
        'cmd_PONOhelp
        '
        Me.cmd_PONOhelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_PONOhelp.Image = CType(resources.GetObject("cmd_PONOhelp.Image"), System.Drawing.Image)
        Me.cmd_PONOhelp.Location = New System.Drawing.Point(444, 17)
        Me.cmd_PONOhelp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmd_PONOhelp.Name = "cmd_PONOhelp"
        Me.cmd_PONOhelp.Size = New System.Drawing.Size(34, 40)
        Me.cmd_PONOhelp.TabIndex = 434
        '
        'CMB_CATEGORY
        '
        Me.CMB_CATEGORY.BackColor = System.Drawing.Color.Wheat
        Me.CMB_CATEGORY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_CATEGORY.Location = New System.Drawing.Point(117, 18)
        Me.CMB_CATEGORY.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CMB_CATEGORY.Name = "CMB_CATEGORY"
        Me.CMB_CATEGORY.Size = New System.Drawing.Size(148, 29)
        Me.CMB_CATEGORY.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 23)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 19)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "CATEGORY"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CMB_CATEGORY)
        Me.GroupBox4.Controls.Add(Me.dtp_Grndate)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.lbl_Grnno)
        Me.GroupBox4.Controls.Add(Me.txt_Grnno)
        Me.GroupBox4.Controls.Add(Me.cmd_Grnnohelp)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.lbl_Grndate)
        Me.GroupBox4.Location = New System.Drawing.Point(22, 246)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Size = New System.Drawing.Size(993, 62)
        Me.GroupBox4.TabIndex = 469
        Me.GroupBox4.TabStop = False
        '
        'dtp_Grndate
        '
        Me.dtp_Grndate.CalendarMonthBackground = System.Drawing.Color.Wheat
        Me.dtp_Grndate.CustomFormat = "dd/MMM/yyyy"
        Me.dtp_Grndate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Grndate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Grndate.Location = New System.Drawing.Point(792, 18)
        Me.dtp_Grndate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtp_Grndate.Name = "dtp_Grndate"
        Me.dtp_Grndate.Size = New System.Drawing.Size(186, 28)
        Me.dtp_Grndate.TabIndex = 471
        '
        'lbl_Grnno
        '
        Me.lbl_Grnno.AutoSize = True
        Me.lbl_Grnno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grnno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grnno.Location = New System.Drawing.Point(270, 23)
        Me.lbl_Grnno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Grnno.Name = "lbl_Grnno"
        Me.lbl_Grnno.Size = New System.Drawing.Size(96, 19)
        Me.lbl_Grnno.TabIndex = 23
        Me.lbl_Grnno.Text = "GRN NO    "
        '
        'txt_Grnno
        '
        Me.txt_Grnno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Grnno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Grnno.Location = New System.Drawing.Point(362, 18)
        Me.txt_Grnno.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Grnno.MaxLength = 50
        Me.txt_Grnno.Name = "txt_Grnno"
        Me.txt_Grnno.Size = New System.Drawing.Size(238, 28)
        Me.txt_Grnno.TabIndex = 2
        '
        'cmd_Grnnohelp
        '
        Me.cmd_Grnnohelp.Image = CType(resources.GetObject("cmd_Grnnohelp.Image"), System.Drawing.Image)
        Me.cmd_Grnnohelp.Location = New System.Drawing.Point(604, 17)
        Me.cmd_Grnnohelp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmd_Grnnohelp.Name = "cmd_Grnnohelp"
        Me.cmd_Grnnohelp.Size = New System.Drawing.Size(34, 40)
        Me.cmd_Grnnohelp.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(644, 18)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 37)
        Me.Label14.TabIndex = 470
        Me.Label14.Text = "F4"
        Me.Label14.Visible = False
        '
        'lbl_Grndate
        '
        Me.lbl_Grndate.AutoSize = True
        Me.lbl_Grndate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grndate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grndate.Location = New System.Drawing.Point(693, 23)
        Me.lbl_Grndate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Grndate.Name = "lbl_Grndate"
        Me.lbl_Grndate.Size = New System.Drawing.Size(94, 19)
        Me.lbl_Grndate.TabIndex = 25
        Me.lbl_Grndate.Text = "GRN DATE"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(276, 25)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 37)
        Me.Label16.TabIndex = 471
        Me.Label16.Text = "F4"
        Me.Label16.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(333, 75)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 19)
        Me.Label12.TabIndex = 432
        Me.Label12.Text = "STORE "
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(276, 68)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 37)
        Me.Label15.TabIndex = 471
        Me.Label15.Text = "F4"
        Me.Label15.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(330, 28)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 19)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "SUPPLIER "
        '
        'lbl_Suppliercode
        '
        Me.lbl_Suppliercode.AutoSize = True
        Me.lbl_Suppliercode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Suppliercode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_Suppliercode.Location = New System.Drawing.Point(-3, 28)
        Me.lbl_Suppliercode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Suppliercode.Name = "lbl_Suppliercode"
        Me.lbl_Suppliercode.Size = New System.Drawing.Size(144, 19)
        Me.lbl_Suppliercode.TabIndex = 28
        Me.lbl_Suppliercode.Text = "SUPPLIER CODE"
        '
        'txt_Suppliercode
        '
        Me.txt_Suppliercode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Suppliercode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Suppliercode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Suppliercode.Location = New System.Drawing.Point(136, 23)
        Me.txt_Suppliercode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Suppliercode.MaxLength = 50
        Me.txt_Suppliercode.Name = "txt_Suppliercode"
        Me.txt_Suppliercode.Size = New System.Drawing.Size(106, 28)
        Me.txt_Suppliercode.TabIndex = 4
        '
        'cmd_Suppliercodehelp
        '
        Me.cmd_Suppliercodehelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Suppliercodehelp.Image = CType(resources.GetObject("cmd_Suppliercodehelp.Image"), System.Drawing.Image)
        Me.cmd_Suppliercodehelp.Location = New System.Drawing.Point(243, 23)
        Me.cmd_Suppliercodehelp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmd_Suppliercodehelp.Name = "cmd_Suppliercodehelp"
        Me.cmd_Suppliercodehelp.Size = New System.Drawing.Size(34, 40)
        Me.cmd_Suppliercodehelp.TabIndex = 29
        '
        'txt_Suppliername
        '
        Me.txt_Suppliername.BackColor = System.Drawing.Color.Wheat
        Me.txt_Suppliername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Suppliername.Enabled = False
        Me.txt_Suppliername.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Suppliername.Location = New System.Drawing.Point(429, 23)
        Me.txt_Suppliername.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Suppliername.MaxLength = 50
        Me.txt_Suppliername.Name = "txt_Suppliername"
        Me.txt_Suppliername.Size = New System.Drawing.Size(223, 28)
        Me.txt_Suppliername.TabIndex = 5
        '
        'txt_Supplierinvno
        '
        Me.txt_Supplierinvno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Supplierinvno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Supplierinvno.Location = New System.Drawing.Point(822, 23)
        Me.txt_Supplierinvno.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Supplierinvno.MaxLength = 50
        Me.txt_Supplierinvno.Name = "txt_Supplierinvno"
        Me.txt_Supplierinvno.Size = New System.Drawing.Size(148, 28)
        Me.txt_Supplierinvno.TabIndex = 5
        '
        'lbl_Supplierinvno
        '
        Me.lbl_Supplierinvno.AutoSize = True
        Me.lbl_Supplierinvno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Supplierinvno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Supplierinvno.Location = New System.Drawing.Point(692, 28)
        Me.lbl_Supplierinvno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Supplierinvno.Name = "lbl_Supplierinvno"
        Me.lbl_Supplierinvno.Size = New System.Drawing.Size(127, 19)
        Me.lbl_Supplierinvno.TabIndex = 26
        Me.lbl_Supplierinvno.Text = "PARTY INV. NO"
        '
        'lbl_Supplierinvdate
        '
        Me.lbl_Supplierinvdate.AutoSize = True
        Me.lbl_Supplierinvdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Supplierinvdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Supplierinvdate.Location = New System.Drawing.Point(694, 75)
        Me.lbl_Supplierinvdate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Supplierinvdate.Name = "lbl_Supplierinvdate"
        Me.lbl_Supplierinvdate.Size = New System.Drawing.Size(87, 19)
        Me.lbl_Supplierinvdate.TabIndex = 27
        Me.lbl_Supplierinvdate.Text = "INV. DATE"
        '
        'dtp_Supplierinvdate
        '
        Me.dtp_Supplierinvdate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Supplierinvdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtp_Supplierinvdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Supplierinvdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Supplierinvdate.Location = New System.Drawing.Point(824, 72)
        Me.dtp_Supplierinvdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtp_Supplierinvdate.Name = "dtp_Supplierinvdate"
        Me.dtp_Supplierinvdate.Size = New System.Drawing.Size(148, 28)
        Me.dtp_Supplierinvdate.TabIndex = 6
        '
        'txt_Storecode
        '
        Me.txt_Storecode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Storecode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Storecode.Location = New System.Drawing.Point(135, 72)
        Me.txt_Storecode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Storecode.MaxLength = 15
        Me.txt_Storecode.Name = "txt_Storecode"
        Me.txt_Storecode.Size = New System.Drawing.Size(106, 28)
        Me.txt_Storecode.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(-2, 75)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 431
        Me.Label3.Text = "STORE  "
        '
        'Cmd_Storecode
        '
        Me.Cmd_Storecode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Storecode.Image = CType(resources.GetObject("Cmd_Storecode.Image"), System.Drawing.Image)
        Me.Cmd_Storecode.Location = New System.Drawing.Point(243, 66)
        Me.Cmd_Storecode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmd_Storecode.Name = "Cmd_Storecode"
        Me.Cmd_Storecode.Size = New System.Drawing.Size(34, 40)
        Me.Cmd_Storecode.TabIndex = 430
        Me.Cmd_Storecode.UseVisualStyleBackColor = False
        '
        'txt_StoreDesc
        '
        Me.txt_StoreDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_StoreDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_StoreDesc.Enabled = False
        Me.txt_StoreDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_StoreDesc.Location = New System.Drawing.Point(429, 72)
        Me.txt_StoreDesc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_StoreDesc.MaxLength = 50
        Me.txt_StoreDesc.Name = "txt_StoreDesc"
        Me.txt_StoreDesc.Size = New System.Drawing.Size(223, 28)
        Me.txt_StoreDesc.TabIndex = 429
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.lbl_Suppliercode)
        Me.GroupBox6.Controls.Add(Me.txt_Suppliercode)
        Me.GroupBox6.Controls.Add(Me.cmd_Suppliercodehelp)
        Me.GroupBox6.Controls.Add(Me.txt_Suppliername)
        Me.GroupBox6.Controls.Add(Me.txt_Supplierinvno)
        Me.GroupBox6.Controls.Add(Me.lbl_Supplierinvno)
        Me.GroupBox6.Controls.Add(Me.lbl_Supplierinvdate)
        Me.GroupBox6.Controls.Add(Me.dtp_Supplierinvdate)
        Me.GroupBox6.Controls.Add(Me.txt_Storecode)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.Cmd_Storecode)
        Me.GroupBox6.Controls.Add(Me.txt_StoreDesc)
        Me.GroupBox6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(22, 325)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox6.Size = New System.Drawing.Size(993, 123)
        Me.GroupBox6.TabIndex = 470
        Me.GroupBox6.TabStop = False
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.AxfpSpread1)
        Me.GroupBox10.Location = New System.Drawing.Point(22, 457)
        Me.GroupBox10.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox10.Size = New System.Drawing.Size(992, 262)
        Me.GroupBox10.TabIndex = 477
        Me.GroupBox10.TabStop = False
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(6, 14)
        Me.AxfpSpread1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(648, 137)
        Me.AxfpSpread1.TabIndex = 0
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.txtLoadingChrg)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.Label7)
        Me.GroupBox8.Controls.Add(Me.Label5)
        Me.GroupBox8.Controls.Add(Me.Label2)
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Controls.Add(Me.txt_total)
        Me.GroupBox8.Controls.Add(Me.txt_totaltax)
        Me.GroupBox8.Controls.Add(Me.txt_totdisc)
        Me.GroupBox8.Controls.Add(Me.lbl_Surchargeamt)
        Me.GroupBox8.Controls.Add(Me.Label6)
        Me.GroupBox8.Controls.Add(Me.txt_Surchargeamt)
        Me.GroupBox8.Controls.Add(Me.TXT_OVERALLdiscount)
        Me.GroupBox8.Controls.Add(Me.lbl_Billamount)
        Me.GroupBox8.Controls.Add(Me.txt_Billamount)
        Me.GroupBox8.Location = New System.Drawing.Point(22, 746)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox8.Size = New System.Drawing.Size(990, 192)
        Me.GroupBox8.TabIndex = 478
        Me.GroupBox8.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(330, 125)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(171, 19)
        Me.Label9.TabIndex = 446
        Me.Label9.Text = "LOADING CHARGES"
        '
        'txtLoadingChrg
        '
        Me.txtLoadingChrg.BackColor = System.Drawing.Color.Wheat
        Me.txtLoadingChrg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLoadingChrg.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadingChrg.Location = New System.Drawing.Point(500, 120)
        Me.txtLoadingChrg.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLoadingChrg.MaxLength = 15
        Me.txtLoadingChrg.Name = "txtLoadingChrg"
        Me.txtLoadingChrg.ReadOnly = True
        Me.txtLoadingChrg.Size = New System.Drawing.Size(154, 28)
        Me.txtLoadingChrg.TabIndex = 445
        Me.txtLoadingChrg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(15, 158)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 20)
        Me.Label8.TabIndex = 444
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 117)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.TabIndex = 443
        Me.Label7.Text = "Label7"
        Me.Label7.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(669, 28)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 19)
        Me.Label5.TabIndex = 442
        Me.Label5.Text = "TOTAL AMT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(334, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 19)
        Me.Label2.TabIndex = 441
        Me.Label2.Text = "TOTAL TAX"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 19)
        Me.Label1.TabIndex = 440
        Me.Label1.Text = "TOTAL DISC"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.Wheat
        Me.txt_total.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_total.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(801, 22)
        Me.txt_total.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_total.MaxLength = 15
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(154, 28)
        Me.txt_total.TabIndex = 439
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totaltax
        '
        Me.txt_totaltax.BackColor = System.Drawing.Color.Wheat
        Me.txt_totaltax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totaltax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totaltax.Location = New System.Drawing.Point(500, 23)
        Me.txt_totaltax.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_totaltax.MaxLength = 15
        Me.txt_totaltax.Name = "txt_totaltax"
        Me.txt_totaltax.Size = New System.Drawing.Size(154, 28)
        Me.txt_totaltax.TabIndex = 438
        Me.txt_totaltax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totdisc
        '
        Me.txt_totdisc.BackColor = System.Drawing.Color.Wheat
        Me.txt_totdisc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totdisc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totdisc.Location = New System.Drawing.Point(174, 23)
        Me.txt_totdisc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_totdisc.MaxLength = 15
        Me.txt_totdisc.Name = "txt_totdisc"
        Me.txt_totdisc.Size = New System.Drawing.Size(154, 28)
        Me.txt_totdisc.TabIndex = 437
        Me.txt_totdisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Surchargeamt
        '
        Me.lbl_Surchargeamt.AutoSize = True
        Me.lbl_Surchargeamt.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Surchargeamt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Surchargeamt.Location = New System.Drawing.Point(334, 75)
        Me.lbl_Surchargeamt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Surchargeamt.Name = "lbl_Surchargeamt"
        Me.lbl_Surchargeamt.Size = New System.Drawing.Size(154, 19)
        Me.lbl_Surchargeamt.TabIndex = 369
        Me.lbl_Surchargeamt.Text = "OTHER CHARGES"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 74)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 19)
        Me.Label6.TabIndex = 436
        Me.Label6.Text = "OVERALL DISC"
        '
        'txt_Surchargeamt
        '
        Me.txt_Surchargeamt.BackColor = System.Drawing.Color.Wheat
        Me.txt_Surchargeamt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Surchargeamt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Surchargeamt.Location = New System.Drawing.Point(500, 72)
        Me.txt_Surchargeamt.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Surchargeamt.MaxLength = 15
        Me.txt_Surchargeamt.Name = "txt_Surchargeamt"
        Me.txt_Surchargeamt.Size = New System.Drawing.Size(154, 28)
        Me.txt_Surchargeamt.TabIndex = 10
        Me.txt_Surchargeamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXT_OVERALLdiscount
        '
        Me.TXT_OVERALLdiscount.BackColor = System.Drawing.Color.Wheat
        Me.TXT_OVERALLdiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_OVERALLdiscount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_OVERALLdiscount.Location = New System.Drawing.Point(174, 66)
        Me.TXT_OVERALLdiscount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXT_OVERALLdiscount.MaxLength = 15
        Me.TXT_OVERALLdiscount.Name = "TXT_OVERALLdiscount"
        Me.TXT_OVERALLdiscount.Size = New System.Drawing.Size(154, 28)
        Me.TXT_OVERALLdiscount.TabIndex = 11
        Me.TXT_OVERALLdiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Billamount
        '
        Me.lbl_Billamount.AutoSize = True
        Me.lbl_Billamount.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Billamount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Billamount.Location = New System.Drawing.Point(669, 75)
        Me.lbl_Billamount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Billamount.Name = "lbl_Billamount"
        Me.lbl_Billamount.Size = New System.Drawing.Size(125, 19)
        Me.lbl_Billamount.TabIndex = 370
        Me.lbl_Billamount.Text = "BILL AMOUNT "
        '
        'txt_Billamount
        '
        Me.txt_Billamount.BackColor = System.Drawing.Color.Wheat
        Me.txt_Billamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Billamount.Enabled = False
        Me.txt_Billamount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Billamount.Location = New System.Drawing.Point(801, 72)
        Me.txt_Billamount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Billamount.MaxLength = 15
        Me.txt_Billamount.Name = "txt_Billamount"
        Me.txt_Billamount.ReadOnly = True
        Me.txt_Billamount.Size = New System.Drawing.Size(154, 28)
        Me.txt_Billamount.TabIndex = 373
        Me.txt_Billamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.LabelClosingQuantity)
        Me.GroupBox9.Controls.Add(Me.Label20)
        Me.GroupBox9.Controls.Add(Me.txt_Remarks)
        Me.GroupBox9.Controls.Add(Me.lbl_Remarks)
        Me.GroupBox9.Location = New System.Drawing.Point(22, 948)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox9.Size = New System.Drawing.Size(990, 86)
        Me.GroupBox9.TabIndex = 479
        Me.GroupBox9.TabStop = False
        '
        'LabelClosingQuantity
        '
        Me.LabelClosingQuantity.AutoSize = True
        Me.LabelClosingQuantity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelClosingQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelClosingQuantity.Location = New System.Drawing.Point(618, 26)
        Me.LabelClosingQuantity.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelClosingQuantity.Name = "LabelClosingQuantity"
        Me.LabelClosingQuantity.Size = New System.Drawing.Size(0, 24)
        Me.LabelClosingQuantity.TabIndex = 477
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(12, 45)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 37)
        Me.Label20.TabIndex = 476
        Me.Label20.Text = "ALT+ R"
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BackColor = System.Drawing.Color.White
        Me.txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Remarks.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Remarks.Location = New System.Drawing.Point(132, 20)
        Me.txt_Remarks.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Remarks.MaxLength = 200
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(472, 47)
        Me.txt_Remarks.TabIndex = 14
        '
        'lbl_Remarks
        '
        Me.lbl_Remarks.AutoSize = True
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Remarks.Location = New System.Drawing.Point(12, 20)
        Me.lbl_Remarks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Remarks.Name = "lbl_Remarks"
        Me.lbl_Remarks.Size = New System.Drawing.Size(91, 19)
        Me.lbl_Remarks.TabIndex = 43
        Me.lbl_Remarks.Text = "REMARKS"
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
        Me.Cmd_Freeze.Location = New System.Drawing.Point(14, 318)
        Me.Cmd_Freeze.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(171, 71)
        Me.Cmd_Freeze.TabIndex = 481
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
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(14, 23)
        Me.Cmd_Clear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(171, 71)
        Me.Cmd_Clear.TabIndex = 482
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
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
        Me.Cmd_Add.Location = New System.Drawing.Point(14, 97)
        Me.Cmd_Add.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(171, 71)
        Me.Cmd_Add.TabIndex = 480
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.Transparent
        Me.cmd_export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(855, 3)
        Me.cmd_export.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(108, 58)
        Me.cmd_export.TabIndex = 471
        Me.cmd_export.Text = "Export"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        Me.cmd_export.Visible = False
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(14, 394)
        Me.Cmd_Exit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(171, 71)
        Me.Cmd_Exit.TabIndex = 468
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'btn_auth
        '
        Me.btn_auth.BackColor = System.Drawing.Color.Transparent
        Me.btn_auth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_auth.Enabled = False
        Me.btn_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_auth.ForeColor = System.Drawing.Color.Black
        Me.btn_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_auth.Location = New System.Drawing.Point(966, 3)
        Me.btn_auth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn_auth.Name = "btn_auth"
        Me.btn_auth.Size = New System.Drawing.Size(108, 58)
        Me.btn_auth.TabIndex = 470
        Me.btn_auth.Text = "Authorize"
        Me.btn_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_auth.UseVisualStyleBackColor = False
        Me.btn_auth.Visible = False
        '
        'cmd_print
        '
        Me.cmd_print.BackColor = System.Drawing.Color.Transparent
        Me.cmd_print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_print.ForeColor = System.Drawing.Color.Black
        Me.cmd_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_print.Location = New System.Drawing.Point(1184, 3)
        Me.cmd_print.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(117, 58)
        Me.cmd_print.TabIndex = 467
        Me.cmd_print.Text = "Print [F10]"
        Me.cmd_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_print.UseVisualStyleBackColor = False
        Me.cmd_print.Visible = False
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
        Me.Cmd_View.Location = New System.Drawing.Point(14, 171)
        Me.Cmd_View.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(171, 71)
        Me.Cmd_View.TabIndex = 469
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(772, 117)
        Me.lbl_Freeze.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(300, 38)
        Me.lbl_Freeze.TabIndex = 483
        Me.lbl_Freeze.Text = "Record Void  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox1.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox1.Controls.Add(Me.Cmd_Add)
        Me.GroupBox1.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox1.Controls.Add(Me.Cmd_View)
        Me.GroupBox1.Location = New System.Drawing.Point(1070, 265)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(198, 482)
        Me.GroupBox1.TabIndex = 484
        Me.GroupBox1.TabStop = False
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
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(14, 245)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 71)
        Me.Button1.TabIndex = 483
        Me.Button1.Text = " Print[F10]"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'directgrn
        '
        Me.directgrn.AutoSize = True
        Me.directgrn.BackColor = System.Drawing.Color.Lime
        Me.directgrn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.directgrn.Location = New System.Drawing.Point(541, 200)
        Me.directgrn.Name = "directgrn"
        Me.directgrn.Size = New System.Drawing.Size(117, 24)
        Me.directgrn.TabIndex = 485
        Me.directgrn.Text = "Direct GRN"
        Me.directgrn.UseVisualStyleBackColor = False
        '
        'Frm_GRNTAMIL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1328, 1106)
        Me.Controls.Add(Me.directgrn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_auth)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.cmd_export)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.cmd_print)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grp_Grngroup1)
        Me.Controls.Add(Me.lbl_Heading)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Frm_GRNTAMIL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_GRN"
        Me.grp_Grngroup1.ResumeLayout(False)
        Me.grp_Grngroup1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents grp_Grngroup1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_PONo As System.Windows.Forms.TextBox
    Friend WithEvents cmd_PONOhelp As System.Windows.Forms.Button
    Friend WithEvents CMB_CATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_Grndate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Grnno As System.Windows.Forms.Label
    Friend WithEvents txt_Grnno As System.Windows.Forms.TextBox
    Friend WithEvents cmd_Grnnohelp As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbl_Grndate As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbl_Suppliercode As System.Windows.Forms.Label
    Friend WithEvents txt_Suppliercode As System.Windows.Forms.TextBox
    Friend WithEvents cmd_Suppliercodehelp As System.Windows.Forms.Button
    Friend WithEvents txt_Suppliername As System.Windows.Forms.TextBox
    Friend WithEvents txt_Supplierinvno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Supplierinvno As System.Windows.Forms.Label
    Friend WithEvents lbl_Supplierinvdate As System.Windows.Forms.Label
    Friend WithEvents dtp_Supplierinvdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_Storecode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Storecode As System.Windows.Forms.Button
    Friend WithEvents txt_StoreDesc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Surchargeamt As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_Surchargeamt As System.Windows.Forms.TextBox
    Friend WithEvents TXT_OVERALLdiscount As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Billamount As System.Windows.Forms.Label
    Friend WithEvents txt_Billamount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelClosingQuantity As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Remarks As System.Windows.Forms.Label
    Friend WithEvents AxfpSpread1 As AxFPUSpreadADO.AxfpSpread
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_total As System.Windows.Forms.TextBox
    Friend WithEvents txt_totaltax As System.Windows.Forms.TextBox
    Friend WithEvents txt_totdisc As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents btn_auth As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents cmd_print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLoadingChrg As System.Windows.Forms.TextBox
    Friend WithEvents directgrn As System.Windows.Forms.CheckBox
End Class
