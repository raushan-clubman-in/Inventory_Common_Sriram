<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GRNNonStockableUpdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GRNNonStockableUpdate))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.grp_Grngroup1 = New System.Windows.Forms.GroupBox()
        Me.cmd_SPONhelp = New System.Windows.Forms.Button()
        Me.TXT_Sponsor = New System.Windows.Forms.TextBox()
        Me.LBL_SPONSOR = New System.Windows.Forms.Label()
        Me.CmbGrnType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
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
        Me.lbl_Heading.Location = New System.Drawing.Point(181, 18)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(383, 22)
        Me.lbl_Heading.TabIndex = 22
        Me.lbl_Heading.Text = "NONSTOCKABLE GRN UPDATION FORM"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp_Grngroup1
        '
        Me.grp_Grngroup1.BackColor = System.Drawing.Color.Transparent
        Me.grp_Grngroup1.Controls.Add(Me.cmd_SPONhelp)
        Me.grp_Grngroup1.Controls.Add(Me.TXT_Sponsor)
        Me.grp_Grngroup1.Controls.Add(Me.LBL_SPONSOR)
        Me.grp_Grngroup1.Controls.Add(Me.CmbGrnType)
        Me.grp_Grngroup1.Controls.Add(Me.Label7)
        Me.grp_Grngroup1.Controls.Add(Me.Label4)
        Me.grp_Grngroup1.Controls.Add(Me.Txt_PONo)
        Me.grp_Grngroup1.Controls.Add(Me.cmd_PONOhelp)
        Me.grp_Grngroup1.Location = New System.Drawing.Point(21, 104)
        Me.grp_Grngroup1.Name = "grp_Grngroup1"
        Me.grp_Grngroup1.Size = New System.Drawing.Size(645, 40)
        Me.grp_Grngroup1.TabIndex = 23
        Me.grp_Grngroup1.TabStop = False
        '
        'cmd_SPONhelp
        '
        Me.cmd_SPONhelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_SPONhelp.Image = CType(resources.GetObject("cmd_SPONhelp.Image"), System.Drawing.Image)
        Me.cmd_SPONhelp.Location = New System.Drawing.Point(610, 11)
        Me.cmd_SPONhelp.Name = "cmd_SPONhelp"
        Me.cmd_SPONhelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_SPONhelp.TabIndex = 492
        Me.cmd_SPONhelp.Visible = False
        '
        'TXT_Sponsor
        '
        Me.TXT_Sponsor.BackColor = System.Drawing.Color.Wheat
        Me.TXT_Sponsor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_Sponsor.Location = New System.Drawing.Point(438, 13)
        Me.TXT_Sponsor.MaxLength = 50
        Me.TXT_Sponsor.Name = "TXT_Sponsor"
        Me.TXT_Sponsor.Size = New System.Drawing.Size(172, 21)
        Me.TXT_Sponsor.TabIndex = 491
        Me.TXT_Sponsor.Visible = False
        '
        'LBL_SPONSOR
        '
        Me.LBL_SPONSOR.AutoSize = True
        Me.LBL_SPONSOR.BackColor = System.Drawing.Color.Transparent
        Me.LBL_SPONSOR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_SPONSOR.Location = New System.Drawing.Point(299, 17)
        Me.LBL_SPONSOR.Name = "LBL_SPONSOR"
        Me.LBL_SPONSOR.Size = New System.Drawing.Size(90, 14)
        Me.LBL_SPONSOR.TabIndex = 490
        Me.LBL_SPONSOR.Text = "SPONSOR CODE"
        Me.LBL_SPONSOR.Visible = False
        '
        'CmbGrnType
        '
        Me.CmbGrnType.FormattingEnabled = True
        Me.CmbGrnType.Items.AddRange(New Object() {"PO", "SPONSOR", "DIRECT GRN"})
        Me.CmbGrnType.Location = New System.Drawing.Point(100, 13)
        Me.CmbGrnType.Name = "CmbGrnType"
        Me.CmbGrnType.Size = New System.Drawing.Size(93, 21)
        Me.CmbGrnType.TabIndex = 486
        Me.CmbGrnType.Text = "PO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 14)
        Me.Label7.TabIndex = 485
        Me.Label7.Text = "GRN TYPE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(349, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 433
        Me.Label4.Text = "P.O NO"
        '
        'Txt_PONo
        '
        Me.Txt_PONo.BackColor = System.Drawing.Color.Wheat
        Me.Txt_PONo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PONo.Location = New System.Drawing.Point(438, 13)
        Me.Txt_PONo.MaxLength = 50
        Me.Txt_PONo.Name = "Txt_PONo"
        Me.Txt_PONo.Size = New System.Drawing.Size(172, 21)
        Me.Txt_PONo.TabIndex = 0
        '
        'cmd_PONOhelp
        '
        Me.cmd_PONOhelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_PONOhelp.Image = CType(resources.GetObject("cmd_PONOhelp.Image"), System.Drawing.Image)
        Me.cmd_PONOhelp.Location = New System.Drawing.Point(611, 11)
        Me.cmd_PONOhelp.Name = "cmd_PONOhelp"
        Me.cmd_PONOhelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_PONOhelp.TabIndex = 434
        '
        'CMB_CATEGORY
        '
        Me.CMB_CATEGORY.BackColor = System.Drawing.Color.Wheat
        Me.CMB_CATEGORY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_CATEGORY.Location = New System.Drawing.Point(102, 12)
        Me.CMB_CATEGORY.Name = "CMB_CATEGORY"
        Me.CMB_CATEGORY.Size = New System.Drawing.Size(93, 23)
        Me.CMB_CATEGORY.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 14)
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
        Me.GroupBox4.Location = New System.Drawing.Point(19, 148)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(655, 40)
        Me.GroupBox4.TabIndex = 469
        Me.GroupBox4.TabStop = False
        '
        'dtp_Grndate
        '
        Me.dtp_Grndate.CalendarMonthBackground = System.Drawing.Color.Wheat
        Me.dtp_Grndate.CustomFormat = "dd/MMM/yyyy"
        Me.dtp_Grndate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Grndate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Grndate.Location = New System.Drawing.Point(533, 12)
        Me.dtp_Grndate.Name = "dtp_Grndate"
        Me.dtp_Grndate.Size = New System.Drawing.Size(121, 21)
        Me.dtp_Grndate.TabIndex = 471
        '
        'lbl_Grnno
        '
        Me.lbl_Grnno.AutoSize = True
        Me.lbl_Grnno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grnno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grnno.Location = New System.Drawing.Point(221, 15)
        Me.lbl_Grnno.Name = "lbl_Grnno"
        Me.lbl_Grnno.Size = New System.Drawing.Size(47, 14)
        Me.lbl_Grnno.TabIndex = 23
        Me.lbl_Grnno.Text = "GRN NO"
        '
        'txt_Grnno
        '
        Me.txt_Grnno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Grnno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Grnno.Location = New System.Drawing.Point(287, 12)
        Me.txt_Grnno.MaxLength = 50
        Me.txt_Grnno.Name = "txt_Grnno"
        Me.txt_Grnno.Size = New System.Drawing.Size(130, 21)
        Me.txt_Grnno.TabIndex = 2
        '
        'cmd_Grnnohelp
        '
        Me.cmd_Grnnohelp.Image = CType(resources.GetObject("cmd_Grnnohelp.Image"), System.Drawing.Image)
        Me.cmd_Grnnohelp.Location = New System.Drawing.Point(418, 11)
        Me.cmd_Grnnohelp.Name = "cmd_Grnnohelp"
        Me.cmd_Grnnohelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_Grnnohelp.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(440, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 24)
        Me.Label14.TabIndex = 470
        Me.Label14.Text = "F4"
        Me.Label14.Visible = False
        '
        'lbl_Grndate
        '
        Me.lbl_Grndate.AutoSize = True
        Me.lbl_Grndate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grndate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grndate.Location = New System.Drawing.Point(468, 15)
        Me.lbl_Grndate.Name = "lbl_Grndate"
        Me.lbl_Grndate.Size = New System.Drawing.Size(59, 14)
        Me.lbl_Grndate.TabIndex = 25
        Me.lbl_Grndate.Text = "GRN DATE"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(189, 15)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(24, 24)
        Me.Label16.TabIndex = 471
        Me.Label16.Text = "F4"
        Me.Label16.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(221, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 14)
        Me.Label12.TabIndex = 432
        Me.Label12.Text = "STORE "
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(189, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 24)
        Me.Label15.TabIndex = 471
        Me.Label15.Text = "F4"
        Me.Label15.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(221, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 14)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "SUPPLIER "
        '
        'lbl_Suppliercode
        '
        Me.lbl_Suppliercode.AutoSize = True
        Me.lbl_Suppliercode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Suppliercode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_Suppliercode.Location = New System.Drawing.Point(4, 18)
        Me.lbl_Suppliercode.Name = "lbl_Suppliercode"
        Me.lbl_Suppliercode.Size = New System.Drawing.Size(90, 14)
        Me.lbl_Suppliercode.TabIndex = 28
        Me.lbl_Suppliercode.Text = "SUPPLIER CODE"
        '
        'txt_Suppliercode
        '
        Me.txt_Suppliercode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Suppliercode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Suppliercode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Suppliercode.Location = New System.Drawing.Point(102, 15)
        Me.txt_Suppliercode.MaxLength = 50
        Me.txt_Suppliercode.Name = "txt_Suppliercode"
        Me.txt_Suppliercode.Size = New System.Drawing.Size(65, 21)
        Me.txt_Suppliercode.TabIndex = 4
        '
        'cmd_Suppliercodehelp
        '
        Me.cmd_Suppliercodehelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Suppliercodehelp.Image = CType(resources.GetObject("cmd_Suppliercodehelp.Image"), System.Drawing.Image)
        Me.cmd_Suppliercodehelp.Location = New System.Drawing.Point(167, 14)
        Me.cmd_Suppliercodehelp.Name = "cmd_Suppliercodehelp"
        Me.cmd_Suppliercodehelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_Suppliercodehelp.TabIndex = 29
        '
        'txt_Suppliername
        '
        Me.txt_Suppliername.BackColor = System.Drawing.Color.Wheat
        Me.txt_Suppliername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Suppliername.Enabled = False
        Me.txt_Suppliername.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Suppliername.Location = New System.Drawing.Point(286, 15)
        Me.txt_Suppliername.MaxLength = 50
        Me.txt_Suppliername.Name = "txt_Suppliername"
        Me.txt_Suppliername.Size = New System.Drawing.Size(150, 21)
        Me.txt_Suppliername.TabIndex = 5
        '
        'txt_Supplierinvno
        '
        Me.txt_Supplierinvno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Supplierinvno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Supplierinvno.Location = New System.Drawing.Point(548, 15)
        Me.txt_Supplierinvno.MaxLength = 50
        Me.txt_Supplierinvno.Name = "txt_Supplierinvno"
        Me.txt_Supplierinvno.Size = New System.Drawing.Size(100, 21)
        Me.txt_Supplierinvno.TabIndex = 5
        '
        'lbl_Supplierinvno
        '
        Me.lbl_Supplierinvno.AutoSize = True
        Me.lbl_Supplierinvno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Supplierinvno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Supplierinvno.Location = New System.Drawing.Point(462, 18)
        Me.lbl_Supplierinvno.Name = "lbl_Supplierinvno"
        Me.lbl_Supplierinvno.Size = New System.Drawing.Size(83, 14)
        Me.lbl_Supplierinvno.TabIndex = 26
        Me.lbl_Supplierinvno.Text = "PARTY INV. NO"
        '
        'lbl_Supplierinvdate
        '
        Me.lbl_Supplierinvdate.AutoSize = True
        Me.lbl_Supplierinvdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Supplierinvdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Supplierinvdate.Location = New System.Drawing.Point(462, 49)
        Me.lbl_Supplierinvdate.Name = "lbl_Supplierinvdate"
        Me.lbl_Supplierinvdate.Size = New System.Drawing.Size(57, 14)
        Me.lbl_Supplierinvdate.TabIndex = 27
        Me.lbl_Supplierinvdate.Text = "INV. DATE"
        '
        'dtp_Supplierinvdate
        '
        Me.dtp_Supplierinvdate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Supplierinvdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtp_Supplierinvdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Supplierinvdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Supplierinvdate.Location = New System.Drawing.Point(549, 47)
        Me.dtp_Supplierinvdate.Name = "dtp_Supplierinvdate"
        Me.dtp_Supplierinvdate.Size = New System.Drawing.Size(100, 21)
        Me.dtp_Supplierinvdate.TabIndex = 6
        '
        'txt_Storecode
        '
        Me.txt_Storecode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Storecode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Storecode.Location = New System.Drawing.Point(102, 47)
        Me.txt_Storecode.MaxLength = 15
        Me.txt_Storecode.Name = "txt_Storecode"
        Me.txt_Storecode.Size = New System.Drawing.Size(65, 21)
        Me.txt_Storecode.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(4, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 14)
        Me.Label3.TabIndex = 431
        Me.Label3.Text = "STORE  "
        '
        'Cmd_Storecode
        '
        Me.Cmd_Storecode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Storecode.Image = CType(resources.GetObject("Cmd_Storecode.Image"), System.Drawing.Image)
        Me.Cmd_Storecode.Location = New System.Drawing.Point(167, 42)
        Me.Cmd_Storecode.Name = "Cmd_Storecode"
        Me.Cmd_Storecode.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_Storecode.TabIndex = 430
        Me.Cmd_Storecode.UseVisualStyleBackColor = False
        '
        'txt_StoreDesc
        '
        Me.txt_StoreDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_StoreDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_StoreDesc.Enabled = False
        Me.txt_StoreDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_StoreDesc.Location = New System.Drawing.Point(286, 47)
        Me.txt_StoreDesc.MaxLength = 50
        Me.txt_StoreDesc.Name = "txt_StoreDesc"
        Me.txt_StoreDesc.Size = New System.Drawing.Size(150, 21)
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
        Me.GroupBox6.Location = New System.Drawing.Point(19, 191)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(655, 80)
        Me.GroupBox6.TabIndex = 470
        Me.GroupBox6.TabStop = False
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.AxfpSpread1)
        Me.GroupBox10.Location = New System.Drawing.Point(19, 273)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(654, 220)
        Me.GroupBox10.TabIndex = 477
        Me.GroupBox10.TabStop = False
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(6, 15)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(649, 199)
        Me.AxfpSpread1.TabIndex = 0
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
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
        Me.GroupBox8.Location = New System.Drawing.Point(22, 499)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(650, 72)
        Me.GroupBox8.TabIndex = 478
        Me.GroupBox8.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(442, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 14)
        Me.Label5.TabIndex = 442
        Me.Label5.Text = "TOTAL AMT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(230, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 14)
        Me.Label2.TabIndex = 441
        Me.Label2.Text = "TOTAL TAX"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 14)
        Me.Label1.TabIndex = 440
        Me.Label1.Text = "TOTAL DISC"
        '
        'txt_total
        '
        Me.txt_total.BackColor = System.Drawing.Color.Wheat
        Me.txt_total.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_total.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(530, 16)
        Me.txt_total.MaxLength = 15
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(104, 21)
        Me.txt_total.TabIndex = 439
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totaltax
        '
        Me.txt_totaltax.BackColor = System.Drawing.Color.Wheat
        Me.txt_totaltax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totaltax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totaltax.Location = New System.Drawing.Point(328, 17)
        Me.txt_totaltax.MaxLength = 15
        Me.txt_totaltax.Name = "txt_totaltax"
        Me.txt_totaltax.Size = New System.Drawing.Size(104, 21)
        Me.txt_totaltax.TabIndex = 438
        Me.txt_totaltax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_totdisc
        '
        Me.txt_totdisc.BackColor = System.Drawing.Color.Wheat
        Me.txt_totdisc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totdisc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totdisc.Location = New System.Drawing.Point(122, 17)
        Me.txt_totdisc.MaxLength = 15
        Me.txt_totdisc.Name = "txt_totdisc"
        Me.txt_totdisc.Size = New System.Drawing.Size(104, 21)
        Me.txt_totdisc.TabIndex = 437
        Me.txt_totdisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Surchargeamt
        '
        Me.lbl_Surchargeamt.AutoSize = True
        Me.lbl_Surchargeamt.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Surchargeamt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Surchargeamt.Location = New System.Drawing.Point(230, 46)
        Me.lbl_Surchargeamt.Name = "lbl_Surchargeamt"
        Me.lbl_Surchargeamt.Size = New System.Drawing.Size(96, 14)
        Me.lbl_Surchargeamt.TabIndex = 369
        Me.lbl_Surchargeamt.Text = "OTHER CHARGES"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 14)
        Me.Label6.TabIndex = 436
        Me.Label6.Text = "OVERALL DISC"
        '
        'txt_Surchargeamt
        '
        Me.txt_Surchargeamt.BackColor = System.Drawing.Color.Wheat
        Me.txt_Surchargeamt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Surchargeamt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Surchargeamt.Location = New System.Drawing.Point(330, 44)
        Me.txt_Surchargeamt.MaxLength = 15
        Me.txt_Surchargeamt.Name = "txt_Surchargeamt"
        Me.txt_Surchargeamt.Size = New System.Drawing.Size(104, 21)
        Me.txt_Surchargeamt.TabIndex = 10
        Me.txt_Surchargeamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXT_OVERALLdiscount
        '
        Me.TXT_OVERALLdiscount.BackColor = System.Drawing.Color.Wheat
        Me.TXT_OVERALLdiscount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_OVERALLdiscount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_OVERALLdiscount.Location = New System.Drawing.Point(122, 44)
        Me.TXT_OVERALLdiscount.MaxLength = 15
        Me.TXT_OVERALLdiscount.Name = "TXT_OVERALLdiscount"
        Me.TXT_OVERALLdiscount.Size = New System.Drawing.Size(104, 21)
        Me.TXT_OVERALLdiscount.TabIndex = 11
        Me.TXT_OVERALLdiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Billamount
        '
        Me.lbl_Billamount.AutoSize = True
        Me.lbl_Billamount.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Billamount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Billamount.Location = New System.Drawing.Point(442, 46)
        Me.lbl_Billamount.Name = "lbl_Billamount"
        Me.lbl_Billamount.Size = New System.Drawing.Size(84, 14)
        Me.lbl_Billamount.TabIndex = 370
        Me.lbl_Billamount.Text = "BILL AMOUNT "
        '
        'txt_Billamount
        '
        Me.txt_Billamount.BackColor = System.Drawing.Color.Wheat
        Me.txt_Billamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Billamount.Enabled = False
        Me.txt_Billamount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Billamount.Location = New System.Drawing.Point(530, 44)
        Me.txt_Billamount.MaxLength = 15
        Me.txt_Billamount.Name = "txt_Billamount"
        Me.txt_Billamount.ReadOnly = True
        Me.txt_Billamount.Size = New System.Drawing.Size(104, 21)
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
        Me.GroupBox9.Location = New System.Drawing.Point(22, 579)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(650, 56)
        Me.GroupBox9.TabIndex = 479
        Me.GroupBox9.TabStop = False
        '
        'LabelClosingQuantity
        '
        Me.LabelClosingQuantity.AutoSize = True
        Me.LabelClosingQuantity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelClosingQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelClosingQuantity.Location = New System.Drawing.Point(412, 17)
        Me.LabelClosingQuantity.Name = "LabelClosingQuantity"
        Me.LabelClosingQuantity.Size = New System.Drawing.Size(0, 16)
        Me.LabelClosingQuantity.TabIndex = 477
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(8, 29)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 24)
        Me.Label20.TabIndex = 476
        Me.Label20.Text = "ALT+ R"
        Me.Label20.Visible = False
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BackColor = System.Drawing.Color.White
        Me.txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Remarks.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Remarks.Location = New System.Drawing.Point(88, 13)
        Me.txt_Remarks.MaxLength = 200
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(546, 32)
        Me.txt_Remarks.TabIndex = 14
        '
        'lbl_Remarks
        '
        Me.lbl_Remarks.AutoSize = True
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Remarks.Location = New System.Drawing.Point(8, 13)
        Me.lbl_Remarks.Name = "lbl_Remarks"
        Me.lbl_Remarks.Size = New System.Drawing.Size(59, 14)
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
        Me.Cmd_Freeze.Location = New System.Drawing.Point(6, 211)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(124, 46)
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(6, 15)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(124, 46)
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
        Me.Cmd_Add.Location = New System.Drawing.Point(6, 64)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(124, 46)
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
        Me.cmd_export.Location = New System.Drawing.Point(570, 2)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(72, 38)
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(6, 260)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(124, 46)
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
        Me.btn_auth.Location = New System.Drawing.Point(644, 2)
        Me.btn_auth.Name = "btn_auth"
        Me.btn_auth.Size = New System.Drawing.Size(72, 38)
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
        Me.cmd_print.Location = New System.Drawing.Point(789, 2)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(78, 38)
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
        Me.Cmd_View.Location = New System.Drawing.Point(6, 113)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(124, 46)
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
        Me.lbl_Freeze.Location = New System.Drawing.Point(230, 67)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(637, 25)
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
        Me.GroupBox1.Location = New System.Drawing.Point(713, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(132, 322)
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
        Me.Button1.Location = New System.Drawing.Point(6, 162)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 46)
        Me.Button1.TabIndex = 483
        Me.Button1.Text = " Print[F10]"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Frm_GRNNonStockableUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(859, 642)
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
        Me.Name = "Frm_GRNNonStockableUpdate"
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
    Friend WithEvents CmbGrnType As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_SPONhelp As System.Windows.Forms.Button
    Friend WithEvents TXT_Sponsor As System.Windows.Forms.TextBox
    Friend WithEvents LBL_SPONSOR As System.Windows.Forms.Label
End Class
