<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GRN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_GRN))
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
        Me.Lbl_SubledgerName = New System.Windows.Forms.Label()
        Me.GRP_GRNDET = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.BTN_EXIT = New System.Windows.Forms.Button()
        Me.btn_view = New System.Windows.Forms.Button()
        Me.CHKLST_GRNS = New System.Windows.Forms.CheckedListBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CHKGRN = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ChkSupplier = New System.Windows.Forms.CheckBox()
        Me.CHKLST_SUPPLIERS = New System.Windows.Forms.CheckedListBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DTP_TODATE = New System.Windows.Forms.DateTimePicker()
        Me.DTP_FROMDATE = New System.Windows.Forms.DateTimePicker()
        Me.Lbl_SubledgerCode = New System.Windows.Forms.Label()
        Me.Txt_SlDesc = New System.Windows.Forms.TextBox()
        Me.Txt_Slcode = New System.Windows.Forms.TextBox()
        Me.Cmd_SlCodeHelp = New System.Windows.Forms.Button()
        Me.lbl_Glaccountdesc = New System.Windows.Forms.Label()
        Me.Txt_GLAcDesc = New System.Windows.Forms.TextBox()
        Me.Cmd_GLAcHelp = New System.Windows.Forms.Button()
        Me.Txt_GLAcIn = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.AxfpSpread1 = New AxFPUSpreadADO.AxfpSpread()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txt_Ertax = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TXT_ERSALETAX = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Txt_bill_2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_SPLCESS = New System.Windows.Forms.TextBox()
        Me.txt_RoundUP = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
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
        Me.BTN_GRNDET = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GRP_HSN = New System.Windows.Forms.GroupBox()
        Me.Lbl_Last = New System.Windows.Forms.Label()
        Me.grp_Grngroup1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GRP_GRNDET.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GRP_HSN.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(328, 28)
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
        Me.grp_Grngroup1.Controls.Add(Me.cmd_SPONhelp)
        Me.grp_Grngroup1.Controls.Add(Me.TXT_Sponsor)
        Me.grp_Grngroup1.Controls.Add(Me.LBL_SPONSOR)
        Me.grp_Grngroup1.Controls.Add(Me.CmbGrnType)
        Me.grp_Grngroup1.Controls.Add(Me.Label7)
        Me.grp_Grngroup1.Controls.Add(Me.Label4)
        Me.grp_Grngroup1.Controls.Add(Me.Txt_PONo)
        Me.grp_Grngroup1.Controls.Add(Me.cmd_PONOhelp)
        Me.grp_Grngroup1.Location = New System.Drawing.Point(34, 160)
        Me.grp_Grngroup1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grp_Grngroup1.Name = "grp_Grngroup1"
        Me.grp_Grngroup1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grp_Grngroup1.Size = New System.Drawing.Size(986, 62)
        Me.grp_Grngroup1.TabIndex = 23
        Me.grp_Grngroup1.TabStop = False
        '
        'cmd_SPONhelp
        '
        Me.cmd_SPONhelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_SPONhelp.Image = CType(resources.GetObject("cmd_SPONhelp.Image"), System.Drawing.Image)
        Me.cmd_SPONhelp.Location = New System.Drawing.Point(916, 17)
        Me.cmd_SPONhelp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmd_SPONhelp.Name = "cmd_SPONhelp"
        Me.cmd_SPONhelp.Size = New System.Drawing.Size(34, 40)
        Me.cmd_SPONhelp.TabIndex = 492
        Me.cmd_SPONhelp.Visible = False
        '
        'TXT_Sponsor
        '
        Me.TXT_Sponsor.BackColor = System.Drawing.Color.Wheat
        Me.TXT_Sponsor.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_Sponsor.Location = New System.Drawing.Point(657, 20)
        Me.TXT_Sponsor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXT_Sponsor.MaxLength = 50
        Me.TXT_Sponsor.Name = "TXT_Sponsor"
        Me.TXT_Sponsor.Size = New System.Drawing.Size(256, 28)
        Me.TXT_Sponsor.TabIndex = 491
        Me.TXT_Sponsor.Visible = False
        '
        'LBL_SPONSOR
        '
        Me.LBL_SPONSOR.AutoSize = True
        Me.LBL_SPONSOR.BackColor = System.Drawing.Color.Transparent
        Me.LBL_SPONSOR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_SPONSOR.Location = New System.Drawing.Point(448, 26)
        Me.LBL_SPONSOR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBL_SPONSOR.Name = "LBL_SPONSOR"
        Me.LBL_SPONSOR.Size = New System.Drawing.Size(145, 19)
        Me.LBL_SPONSOR.TabIndex = 490
        Me.LBL_SPONSOR.Text = "SPONSOR CODE"
        Me.LBL_SPONSOR.Visible = False
        '
        'CmbGrnType
        '
        Me.CmbGrnType.FormattingEnabled = True
        Me.CmbGrnType.Items.AddRange(New Object() {"PO", "SPONSOR", "DIRECT GRN"})
        Me.CmbGrnType.Location = New System.Drawing.Point(150, 20)
        Me.CmbGrnType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CmbGrnType.Name = "CmbGrnType"
        Me.CmbGrnType.Size = New System.Drawing.Size(138, 28)
        Me.CmbGrnType.TabIndex = 486
        Me.CmbGrnType.Text = "PO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 22)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 19)
        Me.Label7.TabIndex = 485
        Me.Label7.Text = "GRN TYPE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(524, 25)
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
        Me.Txt_PONo.Location = New System.Drawing.Point(657, 20)
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
        Me.cmd_PONOhelp.Location = New System.Drawing.Point(916, 17)
        Me.cmd_PONOhelp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmd_PONOhelp.Name = "cmd_PONOhelp"
        Me.cmd_PONOhelp.Size = New System.Drawing.Size(34, 40)
        Me.cmd_PONOhelp.TabIndex = 434
        '
        'CMB_CATEGORY
        '
        Me.CMB_CATEGORY.BackColor = System.Drawing.Color.Wheat
        Me.CMB_CATEGORY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_CATEGORY.Location = New System.Drawing.Point(153, 18)
        Me.CMB_CATEGORY.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CMB_CATEGORY.Name = "CMB_CATEGORY"
        Me.CMB_CATEGORY.Size = New System.Drawing.Size(174, 29)
        Me.CMB_CATEGORY.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 23)
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
        Me.GroupBox4.Location = New System.Drawing.Point(32, 228)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Size = New System.Drawing.Size(988, 62)
        Me.GroupBox4.TabIndex = 469
        Me.GroupBox4.TabStop = False
        '
        'dtp_Grndate
        '
        Me.dtp_Grndate.CalendarMonthBackground = System.Drawing.Color.Wheat
        Me.dtp_Grndate.CustomFormat = "dd/MMM/yyyy"
        Me.dtp_Grndate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Grndate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Grndate.Location = New System.Drawing.Point(800, 18)
        Me.dtp_Grndate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtp_Grndate.Name = "dtp_Grndate"
        Me.dtp_Grndate.Size = New System.Drawing.Size(164, 28)
        Me.dtp_Grndate.TabIndex = 471
        '
        'lbl_Grnno
        '
        Me.lbl_Grnno.AutoSize = True
        Me.lbl_Grnno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grnno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grnno.Location = New System.Drawing.Point(336, 23)
        Me.lbl_Grnno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Grnno.Name = "lbl_Grnno"
        Me.lbl_Grnno.Size = New System.Drawing.Size(76, 19)
        Me.lbl_Grnno.TabIndex = 23
        Me.lbl_Grnno.Text = "GRN NO"
        '
        'txt_Grnno
        '
        Me.txt_Grnno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Grnno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Grnno.Location = New System.Drawing.Point(430, 18)
        Me.txt_Grnno.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Grnno.MaxLength = 50
        Me.txt_Grnno.Name = "txt_Grnno"
        Me.txt_Grnno.Size = New System.Drawing.Size(193, 28)
        Me.txt_Grnno.TabIndex = 2
        '
        'cmd_Grnnohelp
        '
        Me.cmd_Grnnohelp.Image = CType(resources.GetObject("cmd_Grnnohelp.Image"), System.Drawing.Image)
        Me.cmd_Grnnohelp.Location = New System.Drawing.Point(627, 17)
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
        Me.Label14.Location = New System.Drawing.Point(660, 18)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 37)
        Me.Label14.TabIndex = 470
        Me.Label14.Text = "F4"
        Me.Label14.Visible = False
        '
        'lbl_Grndate
        '
        Me.lbl_Grndate.AutoSize = True
        Me.lbl_Grndate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grndate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grndate.Location = New System.Drawing.Point(702, 23)
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
        Me.Label16.Location = New System.Drawing.Point(284, 23)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 37)
        Me.Label16.TabIndex = 471
        Me.Label16.Text = "F4"
        Me.Label16.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(332, 75)
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
        Me.Label15.Location = New System.Drawing.Point(284, 66)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 37)
        Me.Label15.TabIndex = 471
        Me.Label15.Text = "F4"
        Me.Label15.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(333, 28)
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
        Me.lbl_Suppliercode.Location = New System.Drawing.Point(6, 28)
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
        Me.txt_Suppliercode.Location = New System.Drawing.Point(153, 23)
        Me.txt_Suppliercode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Suppliercode.MaxLength = 50
        Me.txt_Suppliercode.Name = "txt_Suppliercode"
        Me.txt_Suppliercode.Size = New System.Drawing.Size(96, 28)
        Me.txt_Suppliercode.TabIndex = 4
        '
        'cmd_Suppliercodehelp
        '
        Me.cmd_Suppliercodehelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Suppliercodehelp.Image = CType(resources.GetObject("cmd_Suppliercodehelp.Image"), System.Drawing.Image)
        Me.cmd_Suppliercodehelp.Location = New System.Drawing.Point(250, 22)
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
        Me.txt_Supplierinvno.Location = New System.Drawing.Point(801, 23)
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
        Me.lbl_Supplierinvno.Location = New System.Drawing.Point(672, 28)
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
        Me.lbl_Supplierinvdate.Location = New System.Drawing.Point(672, 75)
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
        Me.dtp_Supplierinvdate.Location = New System.Drawing.Point(802, 72)
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
        Me.txt_Storecode.Location = New System.Drawing.Point(153, 72)
        Me.txt_Storecode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Storecode.MaxLength = 15
        Me.txt_Storecode.Name = "txt_Storecode"
        Me.txt_Storecode.Size = New System.Drawing.Size(96, 28)
        Me.txt_Storecode.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(60, 77)
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
        Me.Cmd_Storecode.Location = New System.Drawing.Point(250, 65)
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
        Me.GroupBox6.Controls.Add(Me.Lbl_SubledgerName)
        Me.GroupBox6.Controls.Add(Me.GRP_GRNDET)
        Me.GroupBox6.Controls.Add(Me.Lbl_SubledgerCode)
        Me.GroupBox6.Controls.Add(Me.Txt_SlDesc)
        Me.GroupBox6.Controls.Add(Me.Txt_Slcode)
        Me.GroupBox6.Controls.Add(Me.Cmd_SlCodeHelp)
        Me.GroupBox6.Controls.Add(Me.lbl_Glaccountdesc)
        Me.GroupBox6.Controls.Add(Me.Txt_GLAcDesc)
        Me.GroupBox6.Controls.Add(Me.Cmd_GLAcHelp)
        Me.GroupBox6.Controls.Add(Me.Txt_GLAcIn)
        Me.GroupBox6.Controls.Add(Me.Label25)
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
        Me.GroupBox6.Location = New System.Drawing.Point(30, 294)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox6.Size = New System.Drawing.Size(988, 209)
        Me.GroupBox6.TabIndex = 470
        Me.GroupBox6.TabStop = False
        '
        'Lbl_SubledgerName
        '
        Me.Lbl_SubledgerName.AutoSize = True
        Me.Lbl_SubledgerName.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubledgerName.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubledgerName.Location = New System.Drawing.Point(363, 168)
        Me.Lbl_SubledgerName.Name = "Lbl_SubledgerName"
        Me.Lbl_SubledgerName.Size = New System.Drawing.Size(85, 19)
        Me.Lbl_SubledgerName.TabIndex = 483
        Me.Lbl_SubledgerName.Text = "SL NAME "
        '
        'GRP_GRNDET
        '
        Me.GRP_GRNDET.Controls.Add(Me.Button3)
        Me.GRP_GRNDET.Controls.Add(Me.BTN_EXIT)
        Me.GRP_GRNDET.Controls.Add(Me.btn_view)
        Me.GRP_GRNDET.Controls.Add(Me.CHKLST_GRNS)
        Me.GRP_GRNDET.Controls.Add(Me.Label24)
        Me.GRP_GRNDET.Controls.Add(Me.PictureBox2)
        Me.GRP_GRNDET.Controls.Add(Me.CHKGRN)
        Me.GRP_GRNDET.Controls.Add(Me.Label21)
        Me.GRP_GRNDET.Controls.Add(Me.PictureBox1)
        Me.GRP_GRNDET.Controls.Add(Me.Label23)
        Me.GRP_GRNDET.Controls.Add(Me.Label22)
        Me.GRP_GRNDET.Controls.Add(Me.ChkSupplier)
        Me.GRP_GRNDET.Controls.Add(Me.CHKLST_SUPPLIERS)
        Me.GRP_GRNDET.Controls.Add(Me.Label19)
        Me.GRP_GRNDET.Controls.Add(Me.Label18)
        Me.GRP_GRNDET.Controls.Add(Me.DTP_TODATE)
        Me.GRP_GRNDET.Controls.Add(Me.DTP_FROMDATE)
        Me.GRP_GRNDET.Location = New System.Drawing.Point(108, 75)
        Me.GRP_GRNDET.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GRP_GRNDET.Name = "GRP_GRNDET"
        Me.GRP_GRNDET.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GRP_GRNDET.Size = New System.Drawing.Size(882, 494)
        Me.GRP_GRNDET.TabIndex = 490
        Me.GRP_GRNDET.TabStop = False
        Me.GRP_GRNDET.Visible = False
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.Inventory.My.Resources.Resources.view
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(684, 148)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(188, 88)
        Me.Button3.TabIndex = 500
        Me.Button3.Text = "View"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'BTN_EXIT
        '
        Me.BTN_EXIT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_EXIT.Image = CType(resources.GetObject("BTN_EXIT.Image"), System.Drawing.Image)
        Me.BTN_EXIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_EXIT.Location = New System.Drawing.Point(684, 345)
        Me.BTN_EXIT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTN_EXIT.Name = "BTN_EXIT"
        Me.BTN_EXIT.Size = New System.Drawing.Size(188, 88)
        Me.BTN_EXIT.TabIndex = 499
        Me.BTN_EXIT.Text = "EXIT"
        Me.BTN_EXIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_EXIT.UseVisualStyleBackColor = True
        '
        'btn_view
        '
        Me.btn_view.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view.Image = Global.Inventory.My.Resources.Resources.view
        Me.btn_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_view.Location = New System.Drawing.Point(684, 243)
        Me.btn_view.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(188, 88)
        Me.btn_view.TabIndex = 499
        Me.btn_view.Text = "View"
        Me.btn_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_view.UseVisualStyleBackColor = True
        '
        'CHKLST_GRNS
        '
        Me.CHKLST_GRNS.FormattingEnabled = True
        Me.CHKLST_GRNS.Location = New System.Drawing.Point(375, 166)
        Me.CHKLST_GRNS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CHKLST_GRNS.Name = "CHKLST_GRNS"
        Me.CHKLST_GRNS.Size = New System.Drawing.Size(298, 257)
        Me.CHKLST_GRNS.TabIndex = 498
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Maroon
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label24.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(588, 123)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(48, 37)
        Me.Label24.TabIndex = 497
        Me.Label24.Text = "F3"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(520, 123)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 37)
        Me.PictureBox2.TabIndex = 496
        Me.PictureBox2.TabStop = False
        '
        'CHKGRN
        '
        Me.CHKGRN.AutoSize = True
        Me.CHKGRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKGRN.Location = New System.Drawing.Point(382, 92)
        Me.CHKGRN.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CHKGRN.Name = "CHKGRN"
        Me.CHKGRN.Size = New System.Drawing.Size(92, 26)
        Me.CHKGRN.TabIndex = 495
        Me.CHKGRN.Text = "GRNS"
        Me.CHKGRN.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Maroon
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(288, 120)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(48, 37)
        Me.Label21.TabIndex = 494
        Me.Label21.Text = "F3"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(237, 120)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 37)
        Me.PictureBox1.TabIndex = 493
        Me.PictureBox1.TabStop = False
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Maroon
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(380, 123)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(255, 37)
        Me.Label23.TabIndex = 492
        Me.Label23.Text = "SELECT GRN :  "
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Maroon
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(33, 120)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(298, 37)
        Me.Label22.TabIndex = 492
        Me.Label22.Text = "SELECT SUPPLIER CODE :  "
        '
        'ChkSupplier
        '
        Me.ChkSupplier.AutoSize = True
        Me.ChkSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkSupplier.Location = New System.Drawing.Point(33, 92)
        Me.ChkSupplier.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ChkSupplier.Name = "ChkSupplier"
        Me.ChkSupplier.Size = New System.Drawing.Size(183, 24)
        Me.ChkSupplier.TabIndex = 491
        Me.ChkSupplier.Text = "SUPPLIER NAME"
        Me.ChkSupplier.UseVisualStyleBackColor = True
        '
        'CHKLST_SUPPLIERS
        '
        Me.CHKLST_SUPPLIERS.CheckOnClick = True
        Me.CHKLST_SUPPLIERS.FormattingEnabled = True
        Me.CHKLST_SUPPLIERS.Location = New System.Drawing.Point(33, 163)
        Me.CHKLST_SUPPLIERS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CHKLST_SUPPLIERS.Name = "CHKLST_SUPPLIERS"
        Me.CHKLST_SUPPLIERS.Size = New System.Drawing.Size(298, 257)
        Me.CHKLST_SUPPLIERS.TabIndex = 490
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(321, 46)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 21)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "To Date"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(28, 43)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 21)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "From Date"
        '
        'DTP_TODATE
        '
        Me.DTP_TODATE.Location = New System.Drawing.Point(410, 43)
        Me.DTP_TODATE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTP_TODATE.Name = "DTP_TODATE"
        Me.DTP_TODATE.Size = New System.Drawing.Size(145, 28)
        Me.DTP_TODATE.TabIndex = 0
        '
        'DTP_FROMDATE
        '
        Me.DTP_FROMDATE.Location = New System.Drawing.Point(132, 40)
        Me.DTP_FROMDATE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTP_FROMDATE.Name = "DTP_FROMDATE"
        Me.DTP_FROMDATE.Size = New System.Drawing.Size(178, 28)
        Me.DTP_FROMDATE.TabIndex = 0
        '
        'Lbl_SubledgerCode
        '
        Me.Lbl_SubledgerCode.AutoSize = True
        Me.Lbl_SubledgerCode.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubledgerCode.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubledgerCode.Location = New System.Drawing.Point(48, 168)
        Me.Lbl_SubledgerCode.Name = "Lbl_SubledgerCode"
        Me.Lbl_SubledgerCode.Size = New System.Drawing.Size(85, 19)
        Me.Lbl_SubledgerCode.TabIndex = 481
        Me.Lbl_SubledgerCode.Text = "SL CODE "
        Me.Lbl_SubledgerCode.Visible = False
        '
        'Txt_SlDesc
        '
        Me.Txt_SlDesc.BackColor = System.Drawing.Color.Wheat
        Me.Txt_SlDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SlDesc.Location = New System.Drawing.Point(478, 158)
        Me.Txt_SlDesc.MaxLength = 50
        Me.Txt_SlDesc.Name = "Txt_SlDesc"
        Me.Txt_SlDesc.ReadOnly = True
        Me.Txt_SlDesc.Size = New System.Drawing.Size(328, 30)
        Me.Txt_SlDesc.TabIndex = 478
        Me.Txt_SlDesc.Visible = False
        '
        'Txt_Slcode
        '
        Me.Txt_Slcode.BackColor = System.Drawing.Color.Wheat
        Me.Txt_Slcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Slcode.Location = New System.Drawing.Point(153, 162)
        Me.Txt_Slcode.MaxLength = 10
        Me.Txt_Slcode.Name = "Txt_Slcode"
        Me.Txt_Slcode.Size = New System.Drawing.Size(138, 30)
        Me.Txt_Slcode.TabIndex = 477
        Me.Txt_Slcode.Visible = False
        '
        'Cmd_SlCodeHelp
        '
        Me.Cmd_SlCodeHelp.Image = CType(resources.GetObject("Cmd_SlCodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_SlCodeHelp.Location = New System.Drawing.Point(298, 160)
        Me.Cmd_SlCodeHelp.Name = "Cmd_SlCodeHelp"
        Me.Cmd_SlCodeHelp.Size = New System.Drawing.Size(30, 34)
        Me.Cmd_SlCodeHelp.TabIndex = 482
        Me.Cmd_SlCodeHelp.Visible = False
        '
        'lbl_Glaccountdesc
        '
        Me.lbl_Glaccountdesc.AutoSize = True
        Me.lbl_Glaccountdesc.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Glaccountdesc.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Glaccountdesc.Location = New System.Drawing.Point(351, 125)
        Me.lbl_Glaccountdesc.Name = "lbl_Glaccountdesc"
        Me.lbl_Glaccountdesc.Size = New System.Drawing.Size(119, 19)
        Me.lbl_Glaccountdesc.TabIndex = 476
        Me.lbl_Glaccountdesc.Text = "GL A/C DESC  "
        Me.lbl_Glaccountdesc.Visible = False
        '
        'Txt_GLAcDesc
        '
        Me.Txt_GLAcDesc.BackColor = System.Drawing.Color.Wheat
        Me.Txt_GLAcDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_GLAcDesc.Enabled = False
        Me.Txt_GLAcDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_GLAcDesc.Location = New System.Drawing.Point(478, 118)
        Me.Txt_GLAcDesc.MaxLength = 50
        Me.Txt_GLAcDesc.Name = "Txt_GLAcDesc"
        Me.Txt_GLAcDesc.ReadOnly = True
        Me.Txt_GLAcDesc.Size = New System.Drawing.Size(332, 30)
        Me.Txt_GLAcDesc.TabIndex = 473
        Me.Txt_GLAcDesc.Visible = False
        '
        'Cmd_GLAcHelp
        '
        Me.Cmd_GLAcHelp.Image = CType(resources.GetObject("Cmd_GLAcHelp.Image"), System.Drawing.Image)
        Me.Cmd_GLAcHelp.Location = New System.Drawing.Point(294, 117)
        Me.Cmd_GLAcHelp.Name = "Cmd_GLAcHelp"
        Me.Cmd_GLAcHelp.Size = New System.Drawing.Size(32, 37)
        Me.Cmd_GLAcHelp.TabIndex = 475
        Me.Cmd_GLAcHelp.Visible = False
        '
        'Txt_GLAcIn
        '
        Me.Txt_GLAcIn.BackColor = System.Drawing.Color.Wheat
        Me.Txt_GLAcIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_GLAcIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_GLAcIn.Location = New System.Drawing.Point(152, 118)
        Me.Txt_GLAcIn.MaxLength = 10
        Me.Txt_GLAcIn.Name = "Txt_GLAcIn"
        Me.Txt_GLAcIn.Size = New System.Drawing.Size(139, 30)
        Me.Txt_GLAcIn.TabIndex = 472
        Me.Txt_GLAcIn.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(57, 123)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(85, 19)
        Me.Label25.TabIndex = 474
        Me.Label25.Text = "GL A/C IN "
        Me.Label25.Visible = False
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.Button2)
        Me.GroupBox10.Controls.Add(Me.AxfpSpread1)
        Me.GroupBox10.Location = New System.Drawing.Point(27, 511)
        Me.GroupBox10.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox10.Size = New System.Drawing.Size(992, 277)
        Me.GroupBox10.TabIndex = 477
        Me.GroupBox10.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(9, 337)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(182, 42)
        Me.Button2.TabIndex = 489
        Me.Button2.Text = "Get Weight [F1]"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(11, 18)
        Me.AxfpSpread1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(687, 145)
        Me.AxfpSpread1.TabIndex = 0
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.txt_Ertax)
        Me.GroupBox8.Controls.Add(Me.Label29)
        Me.GroupBox8.Controls.Add(Me.TXT_ERSALETAX)
        Me.GroupBox8.Controls.Add(Me.Label28)
        Me.GroupBox8.Controls.Add(Me.Txt_bill_2)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Controls.Add(Me.Txt_SPLCESS)
        Me.GroupBox8.Controls.Add(Me.txt_RoundUP)
        Me.GroupBox8.Controls.Add(Me.Label8)
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
        Me.GroupBox8.Location = New System.Drawing.Point(30, 802)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox8.Size = New System.Drawing.Size(990, 162)
        Me.GroupBox8.TabIndex = 478
        Me.GroupBox8.TabStop = False
        '
        'txt_Ertax
        '
        Me.txt_Ertax.BackColor = System.Drawing.Color.Wheat
        Me.txt_Ertax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Ertax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Ertax.Location = New System.Drawing.Point(807, 114)
        Me.txt_Ertax.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_Ertax.MaxLength = 15
        Me.txt_Ertax.Name = "txt_Ertax"
        Me.txt_Ertax.Size = New System.Drawing.Size(154, 28)
        Me.txt_Ertax.TabIndex = 492
        Me.txt_Ertax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_Ertax.Visible = False
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(660, 111)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(146, 51)
        Me.Label29.TabIndex = 491
        Me.Label29.Text = "EXCISE RELATED TAX"
        Me.Label29.Visible = False
        '
        'TXT_ERSALETAX
        '
        Me.TXT_ERSALETAX.BackColor = System.Drawing.Color.Wheat
        Me.TXT_ERSALETAX.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_ERSALETAX.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_ERSALETAX.Location = New System.Drawing.Point(496, 109)
        Me.TXT_ERSALETAX.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXT_ERSALETAX.MaxLength = 15
        Me.TXT_ERSALETAX.Name = "TXT_ERSALETAX"
        Me.TXT_ERSALETAX.Size = New System.Drawing.Size(154, 28)
        Me.TXT_ERSALETAX.TabIndex = 490
        Me.TXT_ERSALETAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXT_ERSALETAX.Visible = False
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(346, 105)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(142, 52)
        Me.Label28.TabIndex = 489
        Me.Label28.Text = "EXCISE RELATED SALE TAX"
        Me.Label28.Visible = False
        '
        'Txt_bill_2
        '
        Me.Txt_bill_2.BackColor = System.Drawing.Color.Wheat
        Me.Txt_bill_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_bill_2.Enabled = False
        Me.Txt_bill_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_bill_2.Location = New System.Drawing.Point(801, -5)
        Me.Txt_bill_2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Txt_bill_2.MaxLength = 15
        Me.Txt_bill_2.Name = "Txt_bill_2"
        Me.Txt_bill_2.ReadOnly = True
        Me.Txt_bill_2.Size = New System.Drawing.Size(168, 28)
        Me.Txt_bill_2.TabIndex = 488
        Me.Txt_bill_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_bill_2.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 115)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(161, 19)
        Me.Label9.TabIndex = 486
        Me.Label9.Text = "TOTAL ADD. CESS "
        '
        'Txt_SPLCESS
        '
        Me.Txt_SPLCESS.BackColor = System.Drawing.Color.Wheat
        Me.Txt_SPLCESS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_SPLCESS.Enabled = False
        Me.Txt_SPLCESS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SPLCESS.Location = New System.Drawing.Point(183, 109)
        Me.Txt_SPLCESS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Txt_SPLCESS.MaxLength = 15
        Me.Txt_SPLCESS.Name = "Txt_SPLCESS"
        Me.Txt_SPLCESS.ReadOnly = True
        Me.Txt_SPLCESS.Size = New System.Drawing.Size(154, 28)
        Me.Txt_SPLCESS.TabIndex = 487
        Me.Txt_SPLCESS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_RoundUP
        '
        Me.txt_RoundUP.BackColor = System.Drawing.Color.Wheat
        Me.txt_RoundUP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_RoundUP.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_RoundUP.Location = New System.Drawing.Point(496, 109)
        Me.txt_RoundUP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txt_RoundUP.MaxLength = 15
        Me.txt_RoundUP.Name = "txt_RoundUP"
        Me.txt_RoundUP.Size = New System.Drawing.Size(154, 28)
        Me.txt_RoundUP.TabIndex = 485
        Me.txt_RoundUP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(346, 109)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 19)
        Me.Label8.TabIndex = 444
        Me.Label8.Text = "ROUND OFF"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(660, 31)
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
        Me.Label2.Location = New System.Drawing.Point(345, 31)
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
        Me.Label1.Location = New System.Drawing.Point(18, 31)
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
        Me.txt_total.Location = New System.Drawing.Point(807, 25)
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
        Me.txt_totaltax.Location = New System.Drawing.Point(496, 26)
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
        Me.txt_totdisc.Location = New System.Drawing.Point(183, 26)
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
        Me.lbl_Surchargeamt.Location = New System.Drawing.Point(345, 71)
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
        Me.Label6.Location = New System.Drawing.Point(18, 71)
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
        Me.txt_Surchargeamt.Location = New System.Drawing.Point(496, 68)
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
        Me.TXT_OVERALLdiscount.Location = New System.Drawing.Point(183, 68)
        Me.TXT_OVERALLdiscount.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TXT_OVERALLdiscount.MaxLength = 30
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
        Me.lbl_Billamount.Location = New System.Drawing.Point(660, 71)
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
        Me.txt_Billamount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Billamount.Location = New System.Drawing.Point(812, 68)
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
        Me.GroupBox9.Location = New System.Drawing.Point(27, 952)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox9.Size = New System.Drawing.Size(993, 86)
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
        Me.Label20.Visible = False
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
        Me.txt_Remarks.Size = New System.Drawing.Size(846, 47)
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
        Me.Cmd_Freeze.Location = New System.Drawing.Point(8, 322)
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(8, 20)
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
        Me.Cmd_Add.Location = New System.Drawing.Point(8, 95)
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(8, 397)
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
        Me.Cmd_View.Location = New System.Drawing.Point(8, 171)
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
        Me.lbl_Freeze.Location = New System.Drawing.Point(914, 100)
        Me.lbl_Freeze.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(334, 38)
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
        Me.GroupBox1.Location = New System.Drawing.Point(1036, 171)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(186, 486)
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
        Me.Button1.Location = New System.Drawing.Point(8, 246)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 71)
        Me.Button1.TabIndex = 483
        Me.Button1.Text = " Print[F10]"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BTN_GRNDET
        '
        Me.BTN_GRNDET.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BTN_GRNDET.FlatAppearance.BorderSize = 0
        Me.BTN_GRNDET.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.BTN_GRNDET.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BTN_GRNDET.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BTN_GRNDET.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN_GRNDET.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_GRNDET.Image = CType(resources.GetObject("BTN_GRNDET.Image"), System.Drawing.Image)
        Me.BTN_GRNDET.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_GRNDET.Location = New System.Drawing.Point(1036, 722)
        Me.BTN_GRNDET.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BTN_GRNDET.Name = "BTN_GRNDET"
        Me.BTN_GRNDET.Size = New System.Drawing.Size(171, 71)
        Me.BTN_GRNDET.TabIndex = 496
        Me.BTN_GRNDET.Text = "GRNDETAILS"
        Me.BTN_GRNDET.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_GRNDET.UseVisualStyleBackColor = False
        Me.BTN_GRNDET.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(291, 768)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 20)
        Me.Label10.TabIndex = 487
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(285, 114)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(247, 16)
        Me.Label17.TabIndex = 488
        Me.Label17.Text = "PRESS F12 FOR CHECK ITEM RATE"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(14, 38)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(81, 20)
        Me.Label26.TabIndex = 491
        Me.Label26.Text = "HSN NO"
        Me.Label26.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(14, 82)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(75, 20)
        Me.Label27.TabIndex = 492
        Me.Label27.Text = "Label27"
        Me.Label27.Visible = False
        '
        'GRP_HSN
        '
        Me.GRP_HSN.BackColor = System.Drawing.Color.Transparent
        Me.GRP_HSN.Controls.Add(Me.Label26)
        Me.GRP_HSN.Controls.Add(Me.Label27)
        Me.GRP_HSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRP_HSN.Location = New System.Drawing.Point(1028, 814)
        Me.GRP_HSN.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GRP_HSN.Name = "GRP_HSN"
        Me.GRP_HSN.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GRP_HSN.Size = New System.Drawing.Size(219, 122)
        Me.GRP_HSN.TabIndex = 493
        Me.GRP_HSN.TabStop = False
        Me.GRP_HSN.Text = "HSN NO DETAILS"
        Me.GRP_HSN.Visible = False
        '
        'Lbl_Last
        '
        Me.Lbl_Last.AutoSize = True
        Me.Lbl_Last.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Last.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Last.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Last.Location = New System.Drawing.Point(572, 108)
        Me.Lbl_Last.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Last.Name = "Lbl_Last"
        Me.Lbl_Last.Size = New System.Drawing.Size(146, 21)
        Me.Lbl_Last.TabIndex = 610
        Me.Lbl_Last.Text = "LAST GRN NO :"
        Me.Lbl_Last.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Frm_GRN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1257, 1038)
        Me.Controls.Add(Me.Lbl_Last)
        Me.Controls.Add(Me.BTN_GRNDET)
        Me.Controls.Add(Me.GRP_HSN)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btn_auth)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.cmd_export)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.cmd_print)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.grp_Grngroup1)
        Me.Controls.Add(Me.GroupBox8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_GRN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_GRN"
        Me.grp_Grngroup1.ResumeLayout(False)
        Me.grp_Grngroup1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GRP_GRNDET.ResumeLayout(False)
        Me.GRP_GRNDET.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GRP_HSN.ResumeLayout(False)
        Me.GRP_HSN.PerformLayout()
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
    Friend WithEvents txt_RoundUP As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_SPLCESS As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Txt_bill_2 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GRP_GRNDET As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents DTP_TODATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_FROMDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents BTN_GRNDET As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ChkSupplier As System.Windows.Forms.CheckBox
    Friend WithEvents CHKLST_SUPPLIERS As System.Windows.Forms.CheckedListBox
    Friend WithEvents CHKGRN As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CHKLST_GRNS As System.Windows.Forms.CheckedListBox
    Friend WithEvents btn_view As System.Windows.Forms.Button
    Friend WithEvents BTN_EXIT As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents lbl_Glaccountdesc As System.Windows.Forms.Label
    Friend WithEvents Txt_GLAcDesc As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_GLAcHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_GLAcIn As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Lbl_SubledgerName As System.Windows.Forms.Label
    Friend WithEvents Lbl_SubledgerCode As System.Windows.Forms.Label
    Friend WithEvents Txt_SlDesc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Slcode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_SlCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents GRP_HSN As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As Label
    Friend WithEvents TXT_ERSALETAX As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txt_Ertax As TextBox
    Friend WithEvents Lbl_Last As Label
    'Friend WithEvents CachedCryAuditTrialGroupWise1 As Inventory.CachedCryAuditTrialGroupWise
End Class
