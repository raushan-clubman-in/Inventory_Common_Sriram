Imports System.Data.SqlClient
Imports System.IO
Public Class GRN_Cum_Purchase_Bill
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
    Friend WithEvents cmd_Grnnohelp As System.Windows.Forms.Button
    Friend WithEvents dtp_Excisepassdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Grndate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Supplierinvno As System.Windows.Forms.Label
    Friend WithEvents lbl_Grndate As System.Windows.Forms.Label
    Friend WithEvents lbl_Grnno As System.Windows.Forms.Label
    Friend WithEvents lbl_Supplierinvdate As System.Windows.Forms.Label
    Friend WithEvents lbl_Excisepassno As System.Windows.Forms.Label
    Friend WithEvents lbl_Excisepassdate As System.Windows.Forms.Label
    Friend WithEvents lbl_Totalamt As System.Windows.Forms.Label
    Friend WithEvents txt_Totalamt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Remarks As System.Windows.Forms.Label
    Friend WithEvents lbl_Suppliercode As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents txt_Discountamt As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Discountamt As System.Windows.Forms.Label
    Friend WithEvents cmd_Suppliercodehelp As System.Windows.Forms.Button
    Friend WithEvents txt_Excisepassno As System.Windows.Forms.TextBox
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Suppliername As System.Windows.Forms.Label
    Friend WithEvents grp_Grngroup1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbo_Storelocation As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_Supplierinvdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Creditdays As System.Windows.Forms.Label
    Friend WithEvents lbl_Grn As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdValueby As System.Windows.Forms.Button
    Friend WithEvents OptPercentage As System.Windows.Forms.RadioButton
    Friend WithEvents OptValue As System.Windows.Forms.RadioButton
    Friend WithEvents txtChangeValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRoundoff As System.Windows.Forms.Button
    Friend WithEvents OptNearest As System.Windows.Forms.RadioButton
    Friend WithEvents OptNone As System.Windows.Forms.RadioButton
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents lbl_Help As System.Windows.Forms.Label
    Friend WithEvents grp_StockGrndetails As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_StockGrndetails As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_StockGrnprint As System.Windows.Forms.Button
    Friend WithEvents Cmd_StockGrnView As System.Windows.Forms.Button
    Friend WithEvents Cmd_StockGrnexit As System.Windows.Forms.Button
    Friend WithEvents Cmd_StockGrnClear As System.Windows.Forms.Button
    Friend WithEvents grp_Billingdetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grp_Excisedetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Lbl_SubledgerCode As System.Windows.Forms.Label
    Friend WithEvents Lbl_CostCenterCode As System.Windows.Forms.Label
    Friend WithEvents Cmd_CostCenterCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_CostCenterDesc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_CostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_SlCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_SlDesc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Slcode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_GLAcDesc As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_GLAcHelp As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_GLAcIn As System.Windows.Forms.TextBox
    Friend WithEvents txt_Creditdays As System.Windows.Forms.TextBox
    Friend WithEvents txt_Suppliercode As System.Windows.Forms.TextBox
    Friend WithEvents txt_Suppliername As System.Windows.Forms.TextBox
    Friend WithEvents txt_Grnno As System.Windows.Forms.TextBox
    Friend WithEvents txt_Supplierinvno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Glaccountdesc As System.Windows.Forms.Label
    Friend WithEvents Lbl_SubledgerName As System.Windows.Forms.Label
    Friend WithEvents Lbl_CostCenterDesc As System.Windows.Forms.Label
    Friend WithEvents grp_grnposting As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Trucknumber As System.Windows.Forms.TextBox
    Friend WithEvents dtp_Stockindate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Trucknumber As System.Windows.Forms.Label
    Friend WithEvents lbl_Stockindate As System.Windows.Forms.Label
    Friend WithEvents lbl_Billterms As System.Windows.Forms.Label
    Friend WithEvents cbo_Billingterms As System.Windows.Forms.ComboBox
    Friend WithEvents ssgrid_billdetails As AxFPSpreadADO.AxfpSpread
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cmd_ToDocno As System.Windows.Forms.Button
    Friend WithEvents Cmd_FromDocno As System.Windows.Forms.Button
    Friend WithEvents txt_ToDocno As System.Windows.Forms.TextBox
    Friend WithEvents txt_FromDocno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ToDocno As System.Windows.Forms.Label
    Friend WithEvents lbl_FromDocno As System.Windows.Forms.Label
    Friend WithEvents lbl_Vatamount As System.Windows.Forms.Label
    Friend WithEvents lbl_Surchargeamt As System.Windows.Forms.Label
    Friend WithEvents lbl_Billamount As System.Windows.Forms.Label
    Friend WithEvents txt_Vatamount As System.Windows.Forms.TextBox
    Friend WithEvents txt_Surchargeamt As System.Windows.Forms.TextBox
    Friend WithEvents txt_Billamount As System.Windows.Forms.TextBox
    Friend WithEvents CMB_CATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_print As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GRN_Cum_Purchase_Bill))
        Me.cmd_Grnnohelp = New System.Windows.Forms.Button
        Me.dtp_Excisepassdate = New System.Windows.Forms.DateTimePicker
        Me.lbl_Totalamt = New System.Windows.Forms.Label
        Me.txt_Totalamt = New System.Windows.Forms.TextBox
        Me.txt_Remarks = New System.Windows.Forms.TextBox
        Me.lbl_Remarks = New System.Windows.Forms.Label
        Me.lbl_Suppliercode = New System.Windows.Forms.Label
        Me.lbl_Suppliername = New System.Windows.Forms.Label
        Me.frmbut = New System.Windows.Forms.GroupBox
        Me.cmd_print = New System.Windows.Forms.Button
        Me.dtp_Grndate = New System.Windows.Forms.DateTimePicker
        Me.lbl_Heading = New System.Windows.Forms.Label
        Me.lbl_Freeze = New System.Windows.Forms.Label
        Me.lbl_Supplierinvno = New System.Windows.Forms.Label
        Me.lbl_Grndate = New System.Windows.Forms.Label
        Me.lbl_Grnno = New System.Windows.Forms.Label
        Me.grp_Grngroup1 = New System.Windows.Forms.GroupBox
        Me.txt_Discountamt = New System.Windows.Forms.TextBox
        Me.lbl_Discountamt = New System.Windows.Forms.Label
        Me.cmd_Suppliercodehelp = New System.Windows.Forms.Button
        Me.cbo_Storelocation = New System.Windows.Forms.ComboBox
        Me.lbl_Supplierinvdate = New System.Windows.Forms.Label
        Me.lbl_Excisepassno = New System.Windows.Forms.Label
        Me.lbl_Excisepassdate = New System.Windows.Forms.Label
        Me.dtp_Supplierinvdate = New System.Windows.Forms.DateTimePicker
        Me.txt_Excisepassno = New System.Windows.Forms.TextBox
        Me.lbl_Creditdays = New System.Windows.Forms.Label
        Me.lbl_Grn = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdRoundoff = New System.Windows.Forms.Button
        Me.OptNearest = New System.Windows.Forms.RadioButton
        Me.OptNone = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdValueby = New System.Windows.Forms.Button
        Me.OptPercentage = New System.Windows.Forms.RadioButton
        Me.OptValue = New System.Windows.Forms.RadioButton
        Me.txtChangeValue = New System.Windows.Forms.TextBox
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Freeze = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.lbl_Help = New System.Windows.Forms.Label
        Me.grp_StockGrndetails = New System.Windows.Forms.GroupBox
        Me.lbl_StockGrndetails = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Cmd_StockGrnprint = New System.Windows.Forms.Button
        Me.Cmd_StockGrnView = New System.Windows.Forms.Button
        Me.Cmd_StockGrnexit = New System.Windows.Forms.Button
        Me.Cmd_StockGrnClear = New System.Windows.Forms.Button
        Me.lbl_FromDocno = New System.Windows.Forms.Label
        Me.txt_FromDocno = New System.Windows.Forms.TextBox
        Me.Cmd_FromDocno = New System.Windows.Forms.Button
        Me.txt_ToDocno = New System.Windows.Forms.TextBox
        Me.Cmd_ToDocno = New System.Windows.Forms.Button
        Me.lbl_ToDocno = New System.Windows.Forms.Label
        Me.grp_Billingdetails = New System.Windows.Forms.GroupBox
        Me.ssgrid_billdetails = New AxFPSpreadADO.AxfpSpread
        Me.Label2 = New System.Windows.Forms.Label
        Me.grp_Excisedetails = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txt_Trucknumber = New System.Windows.Forms.TextBox
        Me.dtp_Stockindate = New System.Windows.Forms.DateTimePicker
        Me.lbl_Trucknumber = New System.Windows.Forms.Label
        Me.lbl_Stockindate = New System.Windows.Forms.Label
        Me.Lbl_SubledgerCode = New System.Windows.Forms.Label
        Me.Lbl_CostCenterCode = New System.Windows.Forms.Label
        Me.Cmd_CostCenterCodeHelp = New System.Windows.Forms.Button
        Me.Txt_CostCenterDesc = New System.Windows.Forms.TextBox
        Me.Txt_CostCenterCode = New System.Windows.Forms.TextBox
        Me.Cmd_SlCodeHelp = New System.Windows.Forms.Button
        Me.Txt_SlDesc = New System.Windows.Forms.TextBox
        Me.Txt_Slcode = New System.Windows.Forms.TextBox
        Me.Txt_GLAcDesc = New System.Windows.Forms.TextBox
        Me.Cmd_GLAcHelp = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_GLAcIn = New System.Windows.Forms.TextBox
        Me.txt_Creditdays = New System.Windows.Forms.TextBox
        Me.txt_Suppliercode = New System.Windows.Forms.TextBox
        Me.txt_Suppliername = New System.Windows.Forms.TextBox
        Me.txt_Grnno = New System.Windows.Forms.TextBox
        Me.txt_Supplierinvno = New System.Windows.Forms.TextBox
        Me.lbl_Glaccountdesc = New System.Windows.Forms.Label
        Me.Lbl_SubledgerName = New System.Windows.Forms.Label
        Me.Lbl_CostCenterDesc = New System.Windows.Forms.Label
        Me.grp_grnposting = New System.Windows.Forms.GroupBox
        Me.lbl_Billterms = New System.Windows.Forms.Label
        Me.cbo_Billingterms = New System.Windows.Forms.ComboBox
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread
        Me.lbl_Vatamount = New System.Windows.Forms.Label
        Me.lbl_Surchargeamt = New System.Windows.Forms.Label
        Me.lbl_Billamount = New System.Windows.Forms.Label
        Me.txt_Vatamount = New System.Windows.Forms.TextBox
        Me.txt_Surchargeamt = New System.Windows.Forms.TextBox
        Me.txt_Billamount = New System.Windows.Forms.TextBox
        Me.CMB_CATEGORY = New System.Windows.Forms.ComboBox
        Me.frmbut.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grp_StockGrndetails.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.grp_Billingdetails.SuspendLayout()
        CType(Me.ssgrid_billdetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Excisedetails.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_Grnnohelp
        '
        Me.cmd_Grnnohelp.Image = CType(resources.GetObject("cmd_Grnnohelp.Image"), System.Drawing.Image)
        Me.cmd_Grnnohelp.Location = New System.Drawing.Point(464, 56)
        Me.cmd_Grnnohelp.Name = "cmd_Grnnohelp"
        Me.cmd_Grnnohelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_Grnnohelp.TabIndex = 24
        '
        'dtp_Excisepassdate
        '
        Me.dtp_Excisepassdate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Excisepassdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Excisepassdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Excisepassdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Excisepassdate.Location = New System.Drawing.Point(240, 128)
        Me.dtp_Excisepassdate.Name = "dtp_Excisepassdate"
        Me.dtp_Excisepassdate.Size = New System.Drawing.Size(216, 26)
        Me.dtp_Excisepassdate.TabIndex = 2
        '
        'lbl_Totalamt
        '
        Me.lbl_Totalamt.AutoSize = True
        Me.lbl_Totalamt.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Totalamt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Totalamt.Location = New System.Drawing.Point(608, 512)
        Me.lbl_Totalamt.Name = "lbl_Totalamt"
        Me.lbl_Totalamt.Size = New System.Drawing.Size(111, 17)
        Me.lbl_Totalamt.TabIndex = 2
        Me.lbl_Totalamt.Text = "TOTAL AMOUNT :"
        '
        'txt_Totalamt
        '
        Me.txt_Totalamt.BackColor = System.Drawing.Color.Wheat
        Me.txt_Totalamt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Totalamt.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Totalamt.Location = New System.Drawing.Point(744, 512)
        Me.txt_Totalamt.MaxLength = 15
        Me.txt_Totalamt.Name = "txt_Totalamt"
        Me.txt_Totalamt.ReadOnly = True
        Me.txt_Totalamt.Size = New System.Drawing.Size(176, 21)
        Me.txt_Totalamt.TabIndex = 0
        Me.txt_Totalamt.Text = ""
        Me.txt_Totalamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BackColor = System.Drawing.Color.White
        Me.txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Remarks.Location = New System.Drawing.Point(176, 536)
        Me.txt_Remarks.MaxLength = 200
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(368, 40)
        Me.txt_Remarks.TabIndex = 14
        Me.txt_Remarks.Text = ""
        '
        'lbl_Remarks
        '
        Me.lbl_Remarks.AutoSize = True
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Remarks.Location = New System.Drawing.Point(72, 536)
        Me.lbl_Remarks.Name = "lbl_Remarks"
        Me.lbl_Remarks.Size = New System.Drawing.Size(75, 17)
        Me.lbl_Remarks.TabIndex = 43
        Me.lbl_Remarks.Text = "REMARKS :"
        '
        'lbl_Suppliercode
        '
        Me.lbl_Suppliercode.AutoSize = True
        Me.lbl_Suppliercode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Suppliercode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Suppliercode.Location = New System.Drawing.Point(96, 126)
        Me.lbl_Suppliercode.Name = "lbl_Suppliercode"
        Me.lbl_Suppliercode.Size = New System.Drawing.Size(125, 18)
        Me.lbl_Suppliercode.TabIndex = 28
        Me.lbl_Suppliercode.Text = "SUPPLIER CODE :"
        '
        'lbl_Suppliername
        '
        Me.lbl_Suppliername.AutoSize = True
        Me.lbl_Suppliername.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Suppliername.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Suppliername.Location = New System.Drawing.Point(520, 128)
        Me.lbl_Suppliername.Name = "lbl_Suppliername"
        Me.lbl_Suppliername.Size = New System.Drawing.Size(125, 18)
        Me.lbl_Suppliername.TabIndex = 30
        Me.lbl_Suppliername.Text = "SUPPLIER NAME :"
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.cmd_print)
        Me.frmbut.Location = New System.Drawing.Point(176, 632)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(696, 56)
        Me.frmbut.TabIndex = 44
        Me.frmbut.TabStop = False
        '
        'cmd_print
        '
        Me.cmd_print.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_print.ForeColor = System.Drawing.Color.White
        Me.cmd_print.Image = CType(resources.GetObject("cmd_print.Image"), System.Drawing.Image)
        Me.cmd_print.Location = New System.Drawing.Point(472, 16)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(104, 32)
        Me.cmd_print.TabIndex = 20
        Me.cmd_print.Text = "Print [F10]"
        '
        'dtp_Grndate
        '
        Me.dtp_Grndate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Grndate.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtp_Grndate.CalendarTitleForeColor = System.Drawing.Color.AliceBlue
        Me.dtp_Grndate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Grndate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Grndate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Grndate.Location = New System.Drawing.Point(696, 56)
        Me.dtp_Grndate.Name = "dtp_Grndate"
        Me.dtp_Grndate.Size = New System.Drawing.Size(208, 26)
        Me.dtp_Grndate.TabIndex = 1
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(272, 8)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(381, 31)
        Me.lbl_Heading.TabIndex = 21
        Me.lbl_Heading.Text = "GRN CUM PURCHASE BILL For"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(216, 608)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(312, 25)
        Me.lbl_Freeze.TabIndex = 47
        Me.lbl_Freeze.Text = "Record Void  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'lbl_Supplierinvno
        '
        Me.lbl_Supplierinvno.AutoSize = True
        Me.lbl_Supplierinvno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Supplierinvno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Supplierinvno.Location = New System.Drawing.Point(96, 91)
        Me.lbl_Supplierinvno.Name = "lbl_Supplierinvno"
        Me.lbl_Supplierinvno.Size = New System.Drawing.Size(114, 18)
        Me.lbl_Supplierinvno.TabIndex = 26
        Me.lbl_Supplierinvno.Text = "PARTY INV. NO :"
        '
        'lbl_Grndate
        '
        Me.lbl_Grndate.AutoSize = True
        Me.lbl_Grndate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grndate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grndate.Location = New System.Drawing.Point(520, 60)
        Me.lbl_Grndate.Name = "lbl_Grndate"
        Me.lbl_Grndate.Size = New System.Drawing.Size(84, 18)
        Me.lbl_Grndate.TabIndex = 25
        Me.lbl_Grndate.Text = "GRN DATE :"
        '
        'lbl_Grnno
        '
        Me.lbl_Grnno.AutoSize = True
        Me.lbl_Grnno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grnno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grnno.Location = New System.Drawing.Point(96, 56)
        Me.lbl_Grnno.Name = "lbl_Grnno"
        Me.lbl_Grnno.Size = New System.Drawing.Size(68, 18)
        Me.lbl_Grnno.TabIndex = 23
        Me.lbl_Grnno.Text = "GRN NO :"
        '
        'grp_Grngroup1
        '
        Me.grp_Grngroup1.BackColor = System.Drawing.Color.Transparent
        Me.grp_Grngroup1.Location = New System.Drawing.Point(72, 40)
        Me.grp_Grngroup1.Name = "grp_Grngroup1"
        Me.grp_Grngroup1.Size = New System.Drawing.Size(848, 152)
        Me.grp_Grngroup1.TabIndex = 22
        Me.grp_Grngroup1.TabStop = False
        '
        'txt_Discountamt
        '
        Me.txt_Discountamt.BackColor = System.Drawing.Color.White
        Me.txt_Discountamt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Discountamt.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Discountamt.Location = New System.Drawing.Point(744, 584)
        Me.txt_Discountamt.MaxLength = 15
        Me.txt_Discountamt.Name = "txt_Discountamt"
        Me.txt_Discountamt.Size = New System.Drawing.Size(176, 21)
        Me.txt_Discountamt.TabIndex = 1
        Me.txt_Discountamt.Text = ""
        Me.txt_Discountamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Discountamt
        '
        Me.lbl_Discountamt.AutoSize = True
        Me.lbl_Discountamt.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Discountamt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Discountamt.Location = New System.Drawing.Point(582, 584)
        Me.lbl_Discountamt.Name = "lbl_Discountamt"
        Me.lbl_Discountamt.Size = New System.Drawing.Size(137, 17)
        Me.lbl_Discountamt.TabIndex = 3
        Me.lbl_Discountamt.Text = "DISCOUNT AMOUNT :"
        '
        'cmd_Suppliercodehelp
        '
        Me.cmd_Suppliercodehelp.Image = CType(resources.GetObject("cmd_Suppliercodehelp.Image"), System.Drawing.Image)
        Me.cmd_Suppliercodehelp.Location = New System.Drawing.Point(464, 124)
        Me.cmd_Suppliercodehelp.Name = "cmd_Suppliercodehelp"
        Me.cmd_Suppliercodehelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_Suppliercodehelp.TabIndex = 29
        '
        'cbo_Storelocation
        '
        Me.cbo_Storelocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Storelocation.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Storelocation.Location = New System.Drawing.Point(784, 1000)
        Me.cbo_Storelocation.Name = "cbo_Storelocation"
        Me.cbo_Storelocation.Size = New System.Drawing.Size(192, 23)
        Me.cbo_Storelocation.TabIndex = 8
        '
        'lbl_Supplierinvdate
        '
        Me.lbl_Supplierinvdate.AutoSize = True
        Me.lbl_Supplierinvdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Supplierinvdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Supplierinvdate.Location = New System.Drawing.Point(520, 94)
        Me.lbl_Supplierinvdate.Name = "lbl_Supplierinvdate"
        Me.lbl_Supplierinvdate.Size = New System.Drawing.Size(130, 18)
        Me.lbl_Supplierinvdate.TabIndex = 27
        Me.lbl_Supplierinvdate.Text = "PARTY INV. DATE :"
        '
        'lbl_Excisepassno
        '
        Me.lbl_Excisepassno.AutoSize = True
        Me.lbl_Excisepassno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Excisepassno.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Excisepassno.Location = New System.Drawing.Point(64, 88)
        Me.lbl_Excisepassno.Name = "lbl_Excisepassno"
        Me.lbl_Excisepassno.Size = New System.Drawing.Size(164, 21)
        Me.lbl_Excisepassno.TabIndex = 5
        Me.lbl_Excisepassno.Text = "EXCISE PASS NO       :"
        '
        'lbl_Excisepassdate
        '
        Me.lbl_Excisepassdate.AutoSize = True
        Me.lbl_Excisepassdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Excisepassdate.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Excisepassdate.Location = New System.Drawing.Point(64, 128)
        Me.lbl_Excisepassdate.Name = "lbl_Excisepassdate"
        Me.lbl_Excisepassdate.Size = New System.Drawing.Size(168, 21)
        Me.lbl_Excisepassdate.TabIndex = 6
        Me.lbl_Excisepassdate.Text = "EXCISE PASS DATE   :"
        '
        'dtp_Supplierinvdate
        '
        Me.dtp_Supplierinvdate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Supplierinvdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Supplierinvdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Supplierinvdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Supplierinvdate.Location = New System.Drawing.Point(696, 89)
        Me.dtp_Supplierinvdate.Name = "dtp_Supplierinvdate"
        Me.dtp_Supplierinvdate.Size = New System.Drawing.Size(208, 26)
        Me.dtp_Supplierinvdate.TabIndex = 3
        '
        'txt_Excisepassno
        '
        Me.txt_Excisepassno.BackColor = System.Drawing.Color.White
        Me.txt_Excisepassno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Excisepassno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Excisepassno.Location = New System.Drawing.Point(240, 88)
        Me.txt_Excisepassno.MaxLength = 15
        Me.txt_Excisepassno.Name = "txt_Excisepassno"
        Me.txt_Excisepassno.Size = New System.Drawing.Size(216, 26)
        Me.txt_Excisepassno.TabIndex = 1
        Me.txt_Excisepassno.Text = ""
        '
        'lbl_Creditdays
        '
        Me.lbl_Creditdays.AutoSize = True
        Me.lbl_Creditdays.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Creditdays.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Creditdays.Location = New System.Drawing.Point(520, 162)
        Me.lbl_Creditdays.Name = "lbl_Creditdays"
        Me.lbl_Creditdays.Size = New System.Drawing.Size(109, 18)
        Me.lbl_Creditdays.TabIndex = 32
        Me.lbl_Creditdays.Text = "CREDIT DAYS  :"
        '
        'lbl_Grn
        '
        Me.lbl_Grn.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Grn.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Grn.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Grn.Location = New System.Drawing.Point(8, 624)
        Me.lbl_Grn.Name = "lbl_Grn"
        Me.lbl_Grn.Size = New System.Drawing.Size(160, 24)
        Me.lbl_Grn.TabIndex = 45
        Me.lbl_Grn.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(72, 1000)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(480, 128)
        Me.GroupBox1.TabIndex = 352
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdRoundoff)
        Me.GroupBox2.Controls.Add(Me.OptNearest)
        Me.GroupBox2.Controls.Add(Me.OptNone)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox2.Location = New System.Drawing.Point(264, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(208, 88)
        Me.GroupBox2.TabIndex = 353
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rounded Off"
        '
        'cmdRoundoff
        '
        Me.cmdRoundoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRoundoff.ForeColor = System.Drawing.Color.Blue
        Me.cmdRoundoff.Location = New System.Drawing.Point(136, 16)
        Me.cmdRoundoff.Name = "cmdRoundoff"
        Me.cmdRoundoff.Size = New System.Drawing.Size(56, 39)
        Me.cmdRoundoff.TabIndex = 2
        Me.cmdRoundoff.Text = "Round Off"
        '
        'OptNearest
        '
        Me.OptNearest.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptNearest.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptNearest.Location = New System.Drawing.Point(24, 44)
        Me.OptNearest.Name = "OptNearest"
        Me.OptNearest.Size = New System.Drawing.Size(85, 16)
        Me.OptNearest.TabIndex = 2
        Me.OptNearest.Text = "Nearest Rs"
        '
        'OptNone
        '
        Me.OptNone.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptNone.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptNone.Location = New System.Drawing.Point(24, 18)
        Me.OptNone.Name = "OptNone"
        Me.OptNone.Size = New System.Drawing.Size(88, 16)
        Me.OptNone.TabIndex = 1
        Me.OptNone.Text = "None"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdValueby)
        Me.GroupBox3.Controls.Add(Me.OptPercentage)
        Me.GroupBox3.Controls.Add(Me.OptValue)
        Me.GroupBox3.Controls.Add(Me.txtChangeValue)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(8, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(248, 88)
        Me.GroupBox3.TabIndex = 352
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Discount Amount"
        '
        'cmdValueby
        '
        Me.cmdValueby.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdValueby.ForeColor = System.Drawing.Color.Blue
        Me.cmdValueby.Location = New System.Drawing.Point(191, 16)
        Me.cmdValueby.Name = "cmdValueby"
        Me.cmdValueby.Size = New System.Drawing.Size(48, 40)
        Me.cmdValueby.TabIndex = 3
        Me.cmdValueby.Text = "Value Chg"
        '
        'OptPercentage
        '
        Me.OptPercentage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptPercentage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptPercentage.Location = New System.Drawing.Point(10, 56)
        Me.OptPercentage.Name = "OptPercentage"
        Me.OptPercentage.Size = New System.Drawing.Size(87, 16)
        Me.OptPercentage.TabIndex = 2
        Me.OptPercentage.Text = "Percentage"
        '
        'OptValue
        '
        Me.OptValue.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OptValue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OptValue.Location = New System.Drawing.Point(10, 24)
        Me.OptValue.Name = "OptValue"
        Me.OptValue.Size = New System.Drawing.Size(80, 16)
        Me.OptValue.TabIndex = 1
        Me.OptValue.Text = "Value"
        '
        'txtChangeValue
        '
        Me.txtChangeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChangeValue.Location = New System.Drawing.Point(100, 56)
        Me.txtChangeValue.MaxLength = 10
        Me.txtChangeValue.Name = "txtChangeValue"
        Me.txtChangeValue.Size = New System.Drawing.Size(92, 20)
        Me.txtChangeValue.TabIndex = 3
        Me.txtChangeValue.Text = ""
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.Location = New System.Drawing.Point(184, 648)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 17
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(528, 648)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 19
        Me.Cmd_View.Text = " View[F9]"
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(408, 648)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 18
        Me.Cmd_Freeze.Text = "Void[F8]"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.Location = New System.Drawing.Point(296, 648)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 16
        Me.Cmd_Add.Text = "Add [F7]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(760, 648)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 20
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'lbl_Help
        '
        Me.lbl_Help.AutoSize = True
        Me.lbl_Help.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Help.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Help.ForeColor = System.Drawing.Color.Black
        Me.lbl_Help.Location = New System.Drawing.Point(24, 696)
        Me.lbl_Help.Name = "lbl_Help"
        Me.lbl_Help.Size = New System.Drawing.Size(917, 17)
        Me.lbl_Help.TabIndex = 46
        Me.lbl_Help.Text = "Press F4 For help option/Press F3 for deleting particular row/F12  to focus on Bi" & _
        "lling Terms/Alt+R to focus on Remarks box "
        '
        'grp_StockGrndetails
        '
        Me.grp_StockGrndetails.BackgroundImage = CType(resources.GetObject("grp_StockGrndetails.BackgroundImage"), System.Drawing.Image)
        Me.grp_StockGrndetails.Controls.Add(Me.lbl_StockGrndetails)
        Me.grp_StockGrndetails.Controls.Add(Me.GroupBox5)
        Me.grp_StockGrndetails.Controls.Add(Me.lbl_FromDocno)
        Me.grp_StockGrndetails.Controls.Add(Me.txt_FromDocno)
        Me.grp_StockGrndetails.Controls.Add(Me.Cmd_FromDocno)
        Me.grp_StockGrndetails.Controls.Add(Me.txt_ToDocno)
        Me.grp_StockGrndetails.Controls.Add(Me.Cmd_ToDocno)
        Me.grp_StockGrndetails.Controls.Add(Me.lbl_ToDocno)
        Me.grp_StockGrndetails.Location = New System.Drawing.Point(222, 1000)
        Me.grp_StockGrndetails.Name = "grp_StockGrndetails"
        Me.grp_StockGrndetails.Size = New System.Drawing.Size(514, 238)
        Me.grp_StockGrndetails.TabIndex = 361
        Me.grp_StockGrndetails.TabStop = False
        '
        'lbl_StockGrndetails
        '
        Me.lbl_StockGrndetails.BackColor = System.Drawing.Color.Maroon
        Me.lbl_StockGrndetails.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StockGrndetails.ForeColor = System.Drawing.Color.White
        Me.lbl_StockGrndetails.Location = New System.Drawing.Point(0, 7)
        Me.lbl_StockGrndetails.Name = "lbl_StockGrndetails"
        Me.lbl_StockGrndetails.Size = New System.Drawing.Size(520, 25)
        Me.lbl_StockGrndetails.TabIndex = 26
        Me.lbl_StockGrndetails.Text = "GRN CHECKLIST"
        Me.lbl_StockGrndetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.Cmd_StockGrnprint)
        Me.GroupBox5.Controls.Add(Me.Cmd_StockGrnView)
        Me.GroupBox5.Controls.Add(Me.Cmd_StockGrnexit)
        Me.GroupBox5.Controls.Add(Me.Cmd_StockGrnClear)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 168)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(496, 56)
        Me.GroupBox5.TabIndex = 25
        Me.GroupBox5.TabStop = False
        '
        'Cmd_StockGrnprint
        '
        Me.Cmd_StockGrnprint.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_StockGrnprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_StockGrnprint.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_StockGrnprint.ForeColor = System.Drawing.Color.White
        Me.Cmd_StockGrnprint.Image = CType(resources.GetObject("Cmd_StockGrnprint.Image"), System.Drawing.Image)
        Me.Cmd_StockGrnprint.Location = New System.Drawing.Point(256, 16)
        Me.Cmd_StockGrnprint.Name = "Cmd_StockGrnprint"
        Me.Cmd_StockGrnprint.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_StockGrnprint.TabIndex = 25
        Me.Cmd_StockGrnprint.Text = "Print [F10]"
        '
        'Cmd_StockGrnView
        '
        Me.Cmd_StockGrnView.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_StockGrnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_StockGrnView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_StockGrnView.ForeColor = System.Drawing.Color.White
        Me.Cmd_StockGrnView.Image = CType(resources.GetObject("Cmd_StockGrnView.Image"), System.Drawing.Image)
        Me.Cmd_StockGrnView.Location = New System.Drawing.Point(128, 16)
        Me.Cmd_StockGrnView.Name = "Cmd_StockGrnView"
        Me.Cmd_StockGrnView.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_StockGrnView.TabIndex = 13
        Me.Cmd_StockGrnView.Text = "View [F9]"
        '
        'Cmd_StockGrnexit
        '
        Me.Cmd_StockGrnexit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_StockGrnexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_StockGrnexit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_StockGrnexit.ForeColor = System.Drawing.Color.White
        Me.Cmd_StockGrnexit.Image = CType(resources.GetObject("Cmd_StockGrnexit.Image"), System.Drawing.Image)
        Me.Cmd_StockGrnexit.Location = New System.Drawing.Point(376, 16)
        Me.Cmd_StockGrnexit.Name = "Cmd_StockGrnexit"
        Me.Cmd_StockGrnexit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_StockGrnexit.TabIndex = 15
        Me.Cmd_StockGrnexit.Text = "Exit[F11]"
        '
        'Cmd_StockGrnClear
        '
        Me.Cmd_StockGrnClear.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_StockGrnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_StockGrnClear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_StockGrnClear.ForeColor = System.Drawing.Color.White
        Me.Cmd_StockGrnClear.Image = CType(resources.GetObject("Cmd_StockGrnClear.Image"), System.Drawing.Image)
        Me.Cmd_StockGrnClear.Location = New System.Drawing.Point(8, 16)
        Me.Cmd_StockGrnClear.Name = "Cmd_StockGrnClear"
        Me.Cmd_StockGrnClear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_StockGrnClear.TabIndex = 24
        Me.Cmd_StockGrnClear.Text = "Clear[F6]"
        '
        'lbl_FromDocno
        '
        Me.lbl_FromDocno.AutoSize = True
        Me.lbl_FromDocno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_FromDocno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FromDocno.Location = New System.Drawing.Point(38, 67)
        Me.lbl_FromDocno.Name = "lbl_FromDocno"
        Me.lbl_FromDocno.Size = New System.Drawing.Size(135, 22)
        Me.lbl_FromDocno.TabIndex = 2
        Me.lbl_FromDocno.Text = "FROM GRN NO :"
        '
        'txt_FromDocno
        '
        Me.txt_FromDocno.BackColor = System.Drawing.Color.Wheat
        Me.txt_FromDocno.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FromDocno.Location = New System.Drawing.Point(184, 64)
        Me.txt_FromDocno.Name = "txt_FromDocno"
        Me.txt_FromDocno.Size = New System.Drawing.Size(208, 29)
        Me.txt_FromDocno.TabIndex = 4
        Me.txt_FromDocno.Text = ""
        '
        'Cmd_FromDocno
        '
        Me.Cmd_FromDocno.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_FromDocno.Image = CType(resources.GetObject("Cmd_FromDocno.Image"), System.Drawing.Image)
        Me.Cmd_FromDocno.Location = New System.Drawing.Point(392, 64)
        Me.Cmd_FromDocno.Name = "Cmd_FromDocno"
        Me.Cmd_FromDocno.Size = New System.Drawing.Size(23, 29)
        Me.Cmd_FromDocno.TabIndex = 38
        '
        'txt_ToDocno
        '
        Me.txt_ToDocno.BackColor = System.Drawing.Color.Wheat
        Me.txt_ToDocno.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ToDocno.Location = New System.Drawing.Point(184, 112)
        Me.txt_ToDocno.Name = "txt_ToDocno"
        Me.txt_ToDocno.Size = New System.Drawing.Size(208, 29)
        Me.txt_ToDocno.TabIndex = 5
        Me.txt_ToDocno.Text = ""
        '
        'Cmd_ToDocno
        '
        Me.Cmd_ToDocno.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_ToDocno.Image = CType(resources.GetObject("Cmd_ToDocno.Image"), System.Drawing.Image)
        Me.Cmd_ToDocno.Location = New System.Drawing.Point(392, 112)
        Me.Cmd_ToDocno.Name = "Cmd_ToDocno"
        Me.Cmd_ToDocno.Size = New System.Drawing.Size(23, 29)
        Me.Cmd_ToDocno.TabIndex = 39
        '
        'lbl_ToDocno
        '
        Me.lbl_ToDocno.AutoSize = True
        Me.lbl_ToDocno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ToDocno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ToDocno.Location = New System.Drawing.Point(64, 114)
        Me.lbl_ToDocno.Name = "lbl_ToDocno"
        Me.lbl_ToDocno.Size = New System.Drawing.Size(109, 22)
        Me.lbl_ToDocno.TabIndex = 3
        Me.lbl_ToDocno.Text = "TO GRN NO :"
        '
        'grp_Billingdetails
        '
        Me.grp_Billingdetails.BackColor = System.Drawing.SystemColors.Control
        Me.grp_Billingdetails.BackgroundImage = CType(resources.GetObject("grp_Billingdetails.BackgroundImage"), System.Drawing.Image)
        Me.grp_Billingdetails.Controls.Add(Me.ssgrid_billdetails)
        Me.grp_Billingdetails.Controls.Add(Me.Label2)
        Me.grp_Billingdetails.Location = New System.Drawing.Point(16, 1000)
        Me.grp_Billingdetails.Name = "grp_Billingdetails"
        Me.grp_Billingdetails.Size = New System.Drawing.Size(664, 310)
        Me.grp_Billingdetails.TabIndex = 364
        Me.grp_Billingdetails.TabStop = False
        '
        'ssgrid_billdetails
        '
        Me.ssgrid_billdetails.ContainingControl = Me
        Me.ssgrid_billdetails.DataSource = Nothing
        Me.ssgrid_billdetails.Location = New System.Drawing.Point(24, 48)
        Me.ssgrid_billdetails.Name = "ssgrid_billdetails"
        Me.ssgrid_billdetails.OcxState = CType(resources.GetObject("ssgrid_billdetails.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid_billdetails.Size = New System.Drawing.Size(608, 248)
        Me.ssgrid_billdetails.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(661, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "BILLING DETAILS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grp_Excisedetails
        '
        Me.grp_Excisedetails.BackgroundImage = CType(resources.GetObject("grp_Excisedetails.BackgroundImage"), System.Drawing.Image)
        Me.grp_Excisedetails.Controls.Add(Me.Label5)
        Me.grp_Excisedetails.Controls.Add(Me.txt_Trucknumber)
        Me.grp_Excisedetails.Controls.Add(Me.dtp_Stockindate)
        Me.grp_Excisedetails.Controls.Add(Me.lbl_Trucknumber)
        Me.grp_Excisedetails.Controls.Add(Me.lbl_Stockindate)
        Me.grp_Excisedetails.Controls.Add(Me.lbl_Excisepassno)
        Me.grp_Excisedetails.Controls.Add(Me.txt_Excisepassno)
        Me.grp_Excisedetails.Controls.Add(Me.lbl_Excisepassdate)
        Me.grp_Excisedetails.Controls.Add(Me.dtp_Excisepassdate)
        Me.grp_Excisedetails.Location = New System.Drawing.Point(216, 1000)
        Me.grp_Excisedetails.Name = "grp_Excisedetails"
        Me.grp_Excisedetails.Size = New System.Drawing.Size(512, 206)
        Me.grp_Excisedetails.TabIndex = 366
        Me.grp_Excisedetails.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Maroon
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(506, 24)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "EXCISE DETAILS"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_Trucknumber
        '
        Me.txt_Trucknumber.BackColor = System.Drawing.Color.White
        Me.txt_Trucknumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Trucknumber.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Trucknumber.Location = New System.Drawing.Point(240, 168)
        Me.txt_Trucknumber.MaxLength = 15
        Me.txt_Trucknumber.Name = "txt_Trucknumber"
        Me.txt_Trucknumber.Size = New System.Drawing.Size(216, 26)
        Me.txt_Trucknumber.TabIndex = 3
        Me.txt_Trucknumber.Text = ""
        '
        'dtp_Stockindate
        '
        Me.dtp_Stockindate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Stockindate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Stockindate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Stockindate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Stockindate.Location = New System.Drawing.Point(240, 48)
        Me.dtp_Stockindate.Name = "dtp_Stockindate"
        Me.dtp_Stockindate.Size = New System.Drawing.Size(216, 26)
        Me.dtp_Stockindate.TabIndex = 0
        '
        'lbl_Trucknumber
        '
        Me.lbl_Trucknumber.AutoSize = True
        Me.lbl_Trucknumber.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Trucknumber.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Trucknumber.Location = New System.Drawing.Point(64, 168)
        Me.lbl_Trucknumber.Name = "lbl_Trucknumber"
        Me.lbl_Trucknumber.Size = New System.Drawing.Size(162, 21)
        Me.lbl_Trucknumber.TabIndex = 7
        Me.lbl_Trucknumber.Text = "TRUCK NUMBER      :"
        '
        'lbl_Stockindate
        '
        Me.lbl_Stockindate.AutoSize = True
        Me.lbl_Stockindate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Stockindate.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Stockindate.Location = New System.Drawing.Point(64, 48)
        Me.lbl_Stockindate.Name = "lbl_Stockindate"
        Me.lbl_Stockindate.Size = New System.Drawing.Size(163, 21)
        Me.lbl_Stockindate.TabIndex = 4
        Me.lbl_Stockindate.Text = "STOCK IN DATE        :"
        '
        'Lbl_SubledgerCode
        '
        Me.Lbl_SubledgerCode.AutoSize = True
        Me.Lbl_SubledgerCode.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubledgerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubledgerCode.Location = New System.Drawing.Point(88, 244)
        Me.Lbl_SubledgerCode.Name = "Lbl_SubledgerCode"
        Me.Lbl_SubledgerCode.Size = New System.Drawing.Size(73, 18)
        Me.Lbl_SubledgerCode.TabIndex = 37
        Me.Lbl_SubledgerCode.Text = "SL CODE :"
        Me.Lbl_SubledgerCode.Visible = False
        '
        'Lbl_CostCenterCode
        '
        Me.Lbl_CostCenterCode.AutoSize = True
        Me.Lbl_CostCenterCode.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_CostCenterCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CostCenterCode.Location = New System.Drawing.Point(83, 280)
        Me.Lbl_CostCenterCode.Name = "Lbl_CostCenterCode"
        Me.Lbl_CostCenterCode.Size = New System.Drawing.Size(155, 18)
        Me.Lbl_CostCenterCode.TabIndex = 40
        Me.Lbl_CostCenterCode.Text = "COST CENTER CODE :"
        Me.Lbl_CostCenterCode.Visible = False
        '
        'Cmd_CostCenterCodeHelp
        '
        Me.Cmd_CostCenterCodeHelp.Image = CType(resources.GetObject("Cmd_CostCenterCodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_CostCenterCodeHelp.Location = New System.Drawing.Point(464, 280)
        Me.Cmd_CostCenterCodeHelp.Name = "Cmd_CostCenterCodeHelp"
        Me.Cmd_CostCenterCodeHelp.Size = New System.Drawing.Size(24, 26)
        Me.Cmd_CostCenterCodeHelp.TabIndex = 41
        Me.Cmd_CostCenterCodeHelp.Visible = False
        '
        'Txt_CostCenterDesc
        '
        Me.Txt_CostCenterDesc.BackColor = System.Drawing.Color.Wheat
        Me.Txt_CostCenterDesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CostCenterDesc.Location = New System.Drawing.Point(696, 280)
        Me.Txt_CostCenterDesc.MaxLength = 50
        Me.Txt_CostCenterDesc.Name = "Txt_CostCenterDesc"
        Me.Txt_CostCenterDesc.ReadOnly = True
        Me.Txt_CostCenterDesc.Size = New System.Drawing.Size(208, 26)
        Me.Txt_CostCenterDesc.TabIndex = 13
        Me.Txt_CostCenterDesc.Text = ""
        Me.Txt_CostCenterDesc.Visible = False
        '
        'Txt_CostCenterCode
        '
        Me.Txt_CostCenterCode.BackColor = System.Drawing.Color.Wheat
        Me.Txt_CostCenterCode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CostCenterCode.Location = New System.Drawing.Point(256, 280)
        Me.Txt_CostCenterCode.MaxLength = 10
        Me.Txt_CostCenterCode.Name = "Txt_CostCenterCode"
        Me.Txt_CostCenterCode.Size = New System.Drawing.Size(208, 26)
        Me.Txt_CostCenterCode.TabIndex = 12
        Me.Txt_CostCenterCode.Text = ""
        Me.Txt_CostCenterCode.Visible = False
        '
        'Cmd_SlCodeHelp
        '
        Me.Cmd_SlCodeHelp.Image = CType(resources.GetObject("Cmd_SlCodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_SlCodeHelp.Location = New System.Drawing.Point(464, 243)
        Me.Cmd_SlCodeHelp.Name = "Cmd_SlCodeHelp"
        Me.Cmd_SlCodeHelp.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_SlCodeHelp.TabIndex = 38
        Me.Cmd_SlCodeHelp.Visible = False
        '
        'Txt_SlDesc
        '
        Me.Txt_SlDesc.BackColor = System.Drawing.Color.Wheat
        Me.Txt_SlDesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SlDesc.Location = New System.Drawing.Point(696, 244)
        Me.Txt_SlDesc.MaxLength = 50
        Me.Txt_SlDesc.Name = "Txt_SlDesc"
        Me.Txt_SlDesc.ReadOnly = True
        Me.Txt_SlDesc.Size = New System.Drawing.Size(208, 26)
        Me.Txt_SlDesc.TabIndex = 11
        Me.Txt_SlDesc.Text = ""
        Me.Txt_SlDesc.Visible = False
        '
        'Txt_Slcode
        '
        Me.Txt_Slcode.BackColor = System.Drawing.Color.Wheat
        Me.Txt_Slcode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Slcode.Location = New System.Drawing.Point(256, 244)
        Me.Txt_Slcode.MaxLength = 10
        Me.Txt_Slcode.Name = "Txt_Slcode"
        Me.Txt_Slcode.Size = New System.Drawing.Size(208, 26)
        Me.Txt_Slcode.TabIndex = 10
        Me.Txt_Slcode.Text = ""
        Me.Txt_Slcode.Visible = False
        '
        'Txt_GLAcDesc
        '
        Me.Txt_GLAcDesc.BackColor = System.Drawing.Color.Wheat
        Me.Txt_GLAcDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_GLAcDesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_GLAcDesc.Location = New System.Drawing.Point(696, 208)
        Me.Txt_GLAcDesc.MaxLength = 50
        Me.Txt_GLAcDesc.Name = "Txt_GLAcDesc"
        Me.Txt_GLAcDesc.ReadOnly = True
        Me.Txt_GLAcDesc.Size = New System.Drawing.Size(208, 26)
        Me.Txt_GLAcDesc.TabIndex = 9
        Me.Txt_GLAcDesc.Text = ""
        '
        'Cmd_GLAcHelp
        '
        Me.Cmd_GLAcHelp.Image = CType(resources.GetObject("Cmd_GLAcHelp.Image"), System.Drawing.Image)
        Me.Cmd_GLAcHelp.Location = New System.Drawing.Point(464, 208)
        Me.Cmd_GLAcHelp.Name = "Cmd_GLAcHelp"
        Me.Cmd_GLAcHelp.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_GLAcHelp.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 208)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 18)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "GL A/C IN :"
        '
        'Txt_GLAcIn
        '
        Me.Txt_GLAcIn.BackColor = System.Drawing.Color.Wheat
        Me.Txt_GLAcIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_GLAcIn.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_GLAcIn.Location = New System.Drawing.Point(256, 208)
        Me.Txt_GLAcIn.MaxLength = 10
        Me.Txt_GLAcIn.Name = "Txt_GLAcIn"
        Me.Txt_GLAcIn.Size = New System.Drawing.Size(208, 26)
        Me.Txt_GLAcIn.TabIndex = 8
        Me.Txt_GLAcIn.Text = ""
        '
        'txt_Creditdays
        '
        Me.txt_Creditdays.BackColor = System.Drawing.Color.Wheat
        Me.txt_Creditdays.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Creditdays.Location = New System.Drawing.Point(696, 155)
        Me.txt_Creditdays.MaxLength = 50
        Me.txt_Creditdays.Name = "txt_Creditdays"
        Me.txt_Creditdays.ReadOnly = True
        Me.txt_Creditdays.Size = New System.Drawing.Size(208, 26)
        Me.txt_Creditdays.TabIndex = 7
        Me.txt_Creditdays.Text = ""
        '
        'txt_Suppliercode
        '
        Me.txt_Suppliercode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Suppliercode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Suppliercode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Suppliercode.Location = New System.Drawing.Point(256, 124)
        Me.txt_Suppliercode.MaxLength = 50
        Me.txt_Suppliercode.Name = "txt_Suppliercode"
        Me.txt_Suppliercode.Size = New System.Drawing.Size(208, 26)
        Me.txt_Suppliercode.TabIndex = 4
        Me.txt_Suppliercode.Text = ""
        '
        'txt_Suppliername
        '
        Me.txt_Suppliername.BackColor = System.Drawing.Color.Wheat
        Me.txt_Suppliername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Suppliername.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Suppliername.Location = New System.Drawing.Point(696, 122)
        Me.txt_Suppliername.MaxLength = 50
        Me.txt_Suppliername.Name = "txt_Suppliername"
        Me.txt_Suppliername.Size = New System.Drawing.Size(208, 26)
        Me.txt_Suppliername.TabIndex = 5
        Me.txt_Suppliername.Text = ""
        '
        'txt_Grnno
        '
        Me.txt_Grnno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Grnno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Grnno.Location = New System.Drawing.Point(256, 56)
        Me.txt_Grnno.MaxLength = 50
        Me.txt_Grnno.Name = "txt_Grnno"
        Me.txt_Grnno.Size = New System.Drawing.Size(208, 26)
        Me.txt_Grnno.TabIndex = 0
        Me.txt_Grnno.Text = ""
        '
        'txt_Supplierinvno
        '
        Me.txt_Supplierinvno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Supplierinvno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Supplierinvno.Location = New System.Drawing.Point(256, 90)
        Me.txt_Supplierinvno.MaxLength = 50
        Me.txt_Supplierinvno.Name = "txt_Supplierinvno"
        Me.txt_Supplierinvno.Size = New System.Drawing.Size(232, 26)
        Me.txt_Supplierinvno.TabIndex = 2
        Me.txt_Supplierinvno.Text = ""
        '
        'lbl_Glaccountdesc
        '
        Me.lbl_Glaccountdesc.AutoSize = True
        Me.lbl_Glaccountdesc.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Glaccountdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Glaccountdesc.Location = New System.Drawing.Point(520, 208)
        Me.lbl_Glaccountdesc.Name = "lbl_Glaccountdesc"
        Me.lbl_Glaccountdesc.TabIndex = 36
        Me.lbl_Glaccountdesc.Text = "GL A/C DESC :"
        '
        'Lbl_SubledgerName
        '
        Me.Lbl_SubledgerName.AutoSize = True
        Me.Lbl_SubledgerName.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubledgerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubledgerName.Location = New System.Drawing.Point(520, 244)
        Me.Lbl_SubledgerName.Name = "Lbl_SubledgerName"
        Me.Lbl_SubledgerName.Size = New System.Drawing.Size(73, 18)
        Me.Lbl_SubledgerName.TabIndex = 39
        Me.Lbl_SubledgerName.Text = "SL NAME :"
        '
        'Lbl_CostCenterDesc
        '
        Me.Lbl_CostCenterDesc.AutoSize = True
        Me.Lbl_CostCenterDesc.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_CostCenterDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CostCenterDesc.Location = New System.Drawing.Point(520, 280)
        Me.Lbl_CostCenterDesc.Name = "Lbl_CostCenterDesc"
        Me.Lbl_CostCenterDesc.Size = New System.Drawing.Size(153, 18)
        Me.Lbl_CostCenterDesc.TabIndex = 42
        Me.Lbl_CostCenterDesc.Text = "COST CENTER DESC :"
        '
        'grp_grnposting
        '
        Me.grp_grnposting.BackColor = System.Drawing.Color.Transparent
        Me.grp_grnposting.Location = New System.Drawing.Point(72, 192)
        Me.grp_grnposting.Name = "grp_grnposting"
        Me.grp_grnposting.Size = New System.Drawing.Size(848, 120)
        Me.grp_grnposting.TabIndex = 33
        Me.grp_grnposting.TabStop = False
        '
        'lbl_Billterms
        '
        Me.lbl_Billterms.AutoSize = True
        Me.lbl_Billterms.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Billterms.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Billterms.Location = New System.Drawing.Point(96, 161)
        Me.lbl_Billterms.Name = "lbl_Billterms"
        Me.lbl_Billterms.Size = New System.Drawing.Size(52, 18)
        Me.lbl_Billterms.TabIndex = 31
        Me.lbl_Billterms.Text = "TYPE  :"
        '
        'cbo_Billingterms
        '
        Me.cbo_Billingterms.BackColor = System.Drawing.Color.Wheat
        Me.cbo_Billingterms.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Billingterms.Location = New System.Drawing.Point(256, 158)
        Me.cbo_Billingterms.Name = "cbo_Billingterms"
        Me.cbo_Billingterms.Size = New System.Drawing.Size(232, 27)
        Me.cbo_Billingterms.TabIndex = 6
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(72, 312)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(848, 192)
        Me.ssgrid.TabIndex = 367
        '
        'lbl_Vatamount
        '
        Me.lbl_Vatamount.AutoSize = True
        Me.lbl_Vatamount.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Vatamount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Vatamount.Location = New System.Drawing.Point(624, 536)
        Me.lbl_Vatamount.Name = "lbl_Vatamount"
        Me.lbl_Vatamount.Size = New System.Drawing.Size(95, 17)
        Me.lbl_Vatamount.TabIndex = 368
        Me.lbl_Vatamount.Text = "VAT AMOUNT :"
        '
        'lbl_Surchargeamt
        '
        Me.lbl_Surchargeamt.AutoSize = True
        Me.lbl_Surchargeamt.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Surchargeamt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Surchargeamt.Location = New System.Drawing.Point(600, 560)
        Me.lbl_Surchargeamt.Name = "lbl_Surchargeamt"
        Me.lbl_Surchargeamt.Size = New System.Drawing.Size(123, 17)
        Me.lbl_Surchargeamt.TabIndex = 369
        Me.lbl_Surchargeamt.Text = "OTHER CHARGES :"
        '
        'lbl_Billamount
        '
        Me.lbl_Billamount.AutoSize = True
        Me.lbl_Billamount.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Billamount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Billamount.Location = New System.Drawing.Point(620, 608)
        Me.lbl_Billamount.Name = "lbl_Billamount"
        Me.lbl_Billamount.Size = New System.Drawing.Size(97, 17)
        Me.lbl_Billamount.TabIndex = 370
        Me.lbl_Billamount.Text = "BILL AMOUNT :"
        '
        'txt_Vatamount
        '
        Me.txt_Vatamount.BackColor = System.Drawing.Color.White
        Me.txt_Vatamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Vatamount.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Vatamount.Location = New System.Drawing.Point(744, 536)
        Me.txt_Vatamount.MaxLength = 15
        Me.txt_Vatamount.Name = "txt_Vatamount"
        Me.txt_Vatamount.Size = New System.Drawing.Size(176, 21)
        Me.txt_Vatamount.TabIndex = 371
        Me.txt_Vatamount.Text = ""
        Me.txt_Vatamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Surchargeamt
        '
        Me.txt_Surchargeamt.BackColor = System.Drawing.Color.White
        Me.txt_Surchargeamt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Surchargeamt.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Surchargeamt.Location = New System.Drawing.Point(744, 560)
        Me.txt_Surchargeamt.MaxLength = 15
        Me.txt_Surchargeamt.Name = "txt_Surchargeamt"
        Me.txt_Surchargeamt.Size = New System.Drawing.Size(176, 21)
        Me.txt_Surchargeamt.TabIndex = 372
        Me.txt_Surchargeamt.Text = ""
        Me.txt_Surchargeamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Billamount
        '
        Me.txt_Billamount.BackColor = System.Drawing.Color.Wheat
        Me.txt_Billamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Billamount.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Billamount.Location = New System.Drawing.Point(744, 608)
        Me.txt_Billamount.MaxLength = 15
        Me.txt_Billamount.Name = "txt_Billamount"
        Me.txt_Billamount.ReadOnly = True
        Me.txt_Billamount.Size = New System.Drawing.Size(176, 21)
        Me.txt_Billamount.TabIndex = 373
        Me.txt_Billamount.Text = ""
        Me.txt_Billamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMB_CATEGORY
        '
        Me.CMB_CATEGORY.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_CATEGORY.Location = New System.Drawing.Point(656, 8)
        Me.CMB_CATEGORY.Name = "CMB_CATEGORY"
        Me.CMB_CATEGORY.Size = New System.Drawing.Size(256, 25)
        Me.CMB_CATEGORY.TabIndex = 374
        '
        'GRN_Cum_Purchase_Bill
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(998, 724)
        Me.Controls.Add(Me.CMB_CATEGORY)
        Me.Controls.Add(Me.grp_StockGrndetails)
        Me.Controls.Add(Me.grp_Billingdetails)
        Me.Controls.Add(Me.txt_Billamount)
        Me.Controls.Add(Me.txt_Surchargeamt)
        Me.Controls.Add(Me.txt_Vatamount)
        Me.Controls.Add(Me.lbl_Billamount)
        Me.Controls.Add(Me.lbl_Surchargeamt)
        Me.Controls.Add(Me.lbl_Vatamount)
        Me.Controls.Add(Me.lbl_Billterms)
        Me.Controls.Add(Me.Lbl_CostCenterDesc)
        Me.Controls.Add(Me.Lbl_SubledgerName)
        Me.Controls.Add(Me.lbl_Glaccountdesc)
        Me.Controls.Add(Me.txt_Supplierinvno)
        Me.Controls.Add(Me.txt_Grnno)
        Me.Controls.Add(Me.txt_Suppliername)
        Me.Controls.Add(Me.txt_Suppliercode)
        Me.Controls.Add(Me.txt_Creditdays)
        Me.Controls.Add(Me.Lbl_SubledgerCode)
        Me.Controls.Add(Me.Lbl_CostCenterCode)
        Me.Controls.Add(Me.Txt_CostCenterDesc)
        Me.Controls.Add(Me.Txt_CostCenterCode)
        Me.Controls.Add(Me.Txt_SlDesc)
        Me.Controls.Add(Me.Txt_Slcode)
        Me.Controls.Add(Me.Txt_GLAcDesc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_GLAcIn)
        Me.Controls.Add(Me.lbl_Help)
        Me.Controls.Add(Me.lbl_Creditdays)
        Me.Controls.Add(Me.lbl_Supplierinvdate)
        Me.Controls.Add(Me.txt_Remarks)
        Me.Controls.Add(Me.lbl_Remarks)
        Me.Controls.Add(Me.lbl_Suppliercode)
        Me.Controls.Add(Me.lbl_Suppliername)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.lbl_Supplierinvno)
        Me.Controls.Add(Me.lbl_Grndate)
        Me.Controls.Add(Me.lbl_Grnno)
        Me.Controls.Add(Me.txt_Totalamt)
        Me.Controls.Add(Me.lbl_Totalamt)
        Me.Controls.Add(Me.lbl_Discountamt)
        Me.Controls.Add(Me.txt_Discountamt)
        Me.Controls.Add(Me.ssgrid)
        Me.Controls.Add(Me.grp_Excisedetails)
        Me.Controls.Add(Me.cbo_Billingterms)
        Me.Controls.Add(Me.Cmd_CostCenterCodeHelp)
        Me.Controls.Add(Me.Cmd_SlCodeHelp)
        Me.Controls.Add(Me.Cmd_GLAcHelp)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.lbl_Grn)
        Me.Controls.Add(Me.dtp_Supplierinvdate)
        Me.Controls.Add(Me.cbo_Storelocation)
        Me.Controls.Add(Me.cmd_Suppliercodehelp)
        Me.Controls.Add(Me.cmd_Grnnohelp)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.dtp_Grndate)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.grp_Grngroup1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_grnposting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "GRN_Cum_Purchase_Bill"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GRN CUM PURCHASE BILL"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.frmbut.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.grp_StockGrndetails.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.grp_Billingdetails.ResumeLayout(False)
        CType(Me.ssgrid_billdetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Excisedetails.ResumeLayout(False)
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public i, TotalCount, billrow As Integer
    Dim GRNno(), sqlstring, Gr As String
    Dim gconnection As New GlobalClass
    Dim vsearch, vitem, accountcode, sstr As String
    Public Listbox As System.Windows.Forms.ListBox
    Dim boolchk, costcentercodestatus, slcodestatus, blnchkupdateclsbal As Boolean
    Dim CATEGORY As String
    Private Sub GRN_Cum_Purchase_Bill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GRNCumPurchaseBillTransbool = True
            Call categoryfill()
            'Call autogenerate()
            Call FillStore()
            Call CreateListBox()
            Call FillBillterms()
            Call Fillbilldetails()
            Call GridLock()
            Lbl_SubledgerCode.Visible = False
            Lbl_SubledgerName.Visible = False
            Txt_Slcode.Visible = False
            Cmd_SlCodeHelp.Visible = False
            Txt_SlDesc.Visible = False
            Lbl_CostCenterCode.Visible = False
            Lbl_CostCenterDesc.Visible = False
            Txt_CostCenterCode.Visible = False
            Txt_CostCenterDesc.Visible = False
            Cmd_CostCenterCodeHelp.Visible = False
            'DISABLE GLACCOUNT
            'Txt_GLAcIn.Visible = False
            'Txt_GLAcDesc.Visible = False
            'Cmd_GLAcHelp.Visible = False
            'lbl_Glaccountdesc.Visible = False
            'Label1.Visible = False

            grp_StockGrndetails.Top = 1000
            grp_grnposting.Height = 48
            grp_grnposting.Width = 848
            grp_Excisedetails.Top = 1000

            'DISABLE GLACCOUNT
            ssgrid.Top = 240
            'ssgrid.Top = 192
            ssgrid.Left = 72
            ssgrid.Height = 264
            'ssgrid.Height = 312

            ssgrid.Focus()
            ssgrid.SetActiveCell(1, 1)
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            'dtp_Grndate.Focus()
            Show()
            CMB_CATEGORY.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : LOAD " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Function categoryfill()
        Try
            Dim I As Integer
            CMB_CATEGORY.Items.Clear()
            sstr = "SELECT DISTINCT CATEGORY FROM INVENTORYITEMMASTER"
            gconnection.getDataSet(sstr, "INVENTORYITEMMASTER")
            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                For I = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                    CMB_CATEGORY.Items.Add(gdataset.Tables("INVENTORYITEMMASTER").Rows(I).Item("CATEGORY"))
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CATEGORYFILL " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Try
            Call clearform(Me)
            Call autogenerate()
            Call FillStore()
            Call FillBillterms()
            Call Fillbilldetails()
            Me.lbl_Freeze.Visible = False
            Me.lbl_Freeze.Text = "Record Void  On "
            ssgrid.ClearRange(1, 1, -1, -1, True)
            ssgrid_billdetails.ClearRange(1, 1, -1, -1, True)
            Me.Cmd_Freeze.Text = "Void[F8]"
            Cmd_Add.Text = "Add [F7]"
            txt_Grnno.Enabled = True
            txt_Grnno.ReadOnly = False
            txt_Remarks.Clear()
            txt_Totalamt.Clear()
            txt_Discountamt.Clear()
            txt_Excisepassno.Clear()
            txt_Trucknumber.Clear()
            txt_Suppliercode.ReadOnly = False
            grp_StockGrndetails.Top = 1000
            Lbl_SubledgerCode.Visible = False
            Lbl_SubledgerName.Visible = False
            Txt_Slcode.Visible = False
            Cmd_SlCodeHelp.Visible = False
            Txt_SlDesc.Visible = False
            Lbl_CostCenterCode.Visible = False
            Lbl_CostCenterDesc.Visible = False
            Txt_CostCenterCode.Visible = False
            Txt_CostCenterDesc.Visible = False

            'DISABLE GLACCOUNT
            'Txt_GLAcIn.Visible = False
            'Txt_GLAcDesc.Visible = False
            'Cmd_GLAcHelp.Visible = False
            'lbl_Glaccountdesc.Visible = False
            'Label1.Visible = False

            Cmd_Add.Enabled = True
            Cmd_Freeze.Enabled = True
            Cmd_CostCenterCodeHelp.Visible = False
            grp_StockGrndetails.Top = 1000
            grp_grnposting.Height = 48
            grp_grnposting.Width = 848
            grp_Excisedetails.Top = 1000
            'ssgrid.Top = 192
            ssgrid.Top = 240
            ssgrid.Left = 72
            ssgrid.Height = 264
            'ssgrid.Height = 312
            dtp_Grndate.Value = DateValue(Now)
            dtp_Supplierinvdate.Value = DateValue(Now)
            dtp_Excisepassdate.Value = DateValue(Now)
            ssgrid.Focus()
            ssgrid.SetActiveCell(1, 1)
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            Call categoryfill()
            '        txt_Grnno.Focus()
            CMB_CATEGORY.Enabled = True
            CMB_CATEGORY.SelectedIndex = -1
            Show()
            CMB_CATEGORY.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CMD CLEAR" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
            SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INV' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
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
            MessageBox.Show("Plz Check Error : GETRIGHTS " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Try
            Dim Totalamount, Taxamount, Calamount, Caltax, CalBilamount, BillAmount, Batchno, Avgrate, Avgquantity As Double
            Dim dblBasic, dblDiscount, dblExcise, dblVAT, dblSurchase, dblTranportation, dblOthpostcharge, dblOthNegcharge As Double
            Dim Qty, Amount, totQty, discount As Double
            Dim sqlstring, varchk, Typecode() As String
            Dim Insert(0) As String
            Dim i As Integer
            Call checkValidation() '''--->Check Validation

            If boolchk = False Then Exit Sub
            '******************************************* $  CALCULATE TOTAL AMOUNT OR BASIC AMOUNT $ ************************************
            Me.txt_Totalamt.Text = 0
            'Me.txt_Billamount.Text = 0
            For i = 1 To ssgrid.DataRowCnt
                ssgrid.Row = i
                ssgrid.Col = 4
                Qty = Val(ssgrid.Text)
                ssgrid.Col = 6
                discount = Val(ssgrid.Text)
                ' Me.txt_Discountamt.Text = Format(Val(Me.txt_Discountamt.Text) + Val(discount), "0.00")
                Me.txt_Discountamt.Text = Format(Val(Me.txt_Discountamt.Text), "0.00")
                ssgrid.Col = 7
                Amount = Val(ssgrid.Text)
                totQty = Val(totQty) + Val(Qty)
                Me.txt_Totalamt.Text = Format(Val(Me.txt_Totalamt.Text) + Val(Amount), "0.00")
            Next i
            Me.txt_Billamount.Text = Format(Val(txt_Totalamt.Text) + Val(txt_Vatamount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_Discountamt.Text), "0.00")
            '''**************************************** $ COMPLETE CALCUTATION FOR BASIC AMOUNT  $ **************************************
            '****************************************** $ CALCULATE BILLAMT,BASIC,DISCOUNT,EXCISEAMT,VAT,SURCHARGE,ETC $ ************************************
            grp_Billingdetails.Top = 1000
            For i = 1 To ssgrid_billdetails.DataRowCnt
                ssgrid_billdetails.Row = i
                ssgrid_billdetails.Col = 1
                If Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "BAS" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblBasic = dblBasic + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "DIS" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblDiscount = dblDiscount + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "EXC" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblExcise = dblExcise + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "V.A" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblVAT = dblVAT + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "SUR" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblSurchase = dblSurchase + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "TRA" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblTranportation = dblTranportation + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 12, 6) = "ES (+)" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblOthpostcharge = dblOthpostcharge + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 12, 6) = "ES (-)" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblOthNegcharge = dblOthNegcharge + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "BIL" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        BillAmount = BillAmount + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                End If
            Next i
            '''**************************************** $ COMPLETE CALCUTATION FOR BASIC AMOUNT  $ **************************************
            '''*********************************************************** Case-1 : Add [F7] ***************************************************'''
            If Mid(CStr(Cmd_Add.Text), 1, 1) = "A" Then
                GRNno = Split(Trim(txt_Grnno.Text), "/")
                Typecode = Split(Trim(cbo_Billingterms.Text), " ")
                '''*********************************************************** INSERT INTO GRN_HEADER *******************************************'''
                sqlstring = "INSERT INTO Grn_header(Grnno,Grndetails,Grndate,Supplierinvno,Supplierdate,Suppliercode,"
                sqlstring = sqlstring & " Suppliername,Typecode,Typedesc,Excisepassno,Excisedate,Stockindate,Trucknumber,Creditdays,Glaccountcode,Glaccountname,"
                sqlstring = sqlstring & " Slcode,Slname,Costcentercode,Costcentername,Totalamount,VATamount,Surchargeamt,Discount,Billamount,Remarks,Void,Adduser,Adddate,Updateuser,Updatetime)"
                sqlstring = sqlstring & " VALUES ('" & CStr(GRNno(2)) & "','" & Trim(CStr(txt_Grnno.Text)) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Grndate.Value), "dd-MMM-yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Supplierinvno.Text)) & "','" & Format(CDate(dtp_Supplierinvdate.Value), "dd-MMM-yyyy") & "', "
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Suppliercode.Text)) & "','" & Trim(CStr(txt_Suppliername.Text)) & "','" & Trim(CStr(Typecode(0))) & "','" & Trim(CStr(Typecode(2))) & "',"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Excisepassno.Text)) & "','" & Format(CDate(dtp_Excisepassdate.Value), "dd-MMM-yyyy ") & "','" & Format(CDate(dtp_Stockindate.Value), "dd-MMM-yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Trucknumber.Text)) & "'," & Val(txt_Creditdays.Text) & ",'" & Trim(CStr(Txt_GLAcIn.Text)) & "','" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
                sqlstring = sqlstring & " '" & Trim(CStr(Txt_Slcode.Text)) & "','" & Trim(CStr(Txt_SlDesc.Text)) & "','" & Trim(CStr(Txt_CostCenterCode.Text)) & "','" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
                sqlstring = sqlstring & " " & Format(Val(txt_Totalamt.Text), "0.00") & "," & Format(Val(txt_Vatamount.Text), "0.00") & "," & Format(Val(txt_Surchargeamt.Text), "0.00") & "," & Format(Val(txt_Discountamt.Text), "0.00") & ","
                sqlstring = sqlstring & " " & IIf(Val(BillAmount) = 0, Format(Val(txt_Totalamt.Text) + Val(txt_Vatamount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_Discountamt.Text), "0.00"), Val(BillAmount)) & ","
                sqlstring = sqlstring & " '" & Trim(CStr(txt_Remarks.Text)) & "','N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                Insert(0) = sqlstring
                '''******************************************************** INSERT INTO GRN_DETAILS **********************************'''
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 1
                    Avgrate = CalAverageRate(Trim(ssgrid.Text))
                    Avgquantity = CalAverageQuantity(Trim(ssgrid.Text))
                    sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,Suppliercode,Suppliername,Itemcode,Itemname,"
                    sqlstring = sqlstring & " UOM,Qty,Rate,Discount,Amount,Dblamount,DblUOM,Highratio,Voiditem,Avgqty,Avgrate,Category,Adduser,Adddate,UpdateUser,Updatetime)"
                    sqlstring = sqlstring & " VALUES('" & CStr(GRNno(2)) & "','" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd-MMM-yyyy ") & "',"
                    sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
                    ssgrid.Col = 1
                    sqlstring = sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 2
                    sqlstring = sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 3
                    sqlstring = sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 4
                    sqlstring = sqlstring & " " & Format(Val(ssgrid.Text), "0.000") & ","
                    ssgrid.Col = 5
                    sqlstring = sqlstring & " " & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 6
                    sqlstring = sqlstring & " " & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 7
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 8
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 9
                    sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 10
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
                    sqlstring = sqlstring & "'N'," & Format(Val(Avgquantity), "0.000") & "," & Format(Val(Avgrate), "0.00") & ",'" & Trim(CMB_CATEGORY.Text) & "',"
                    sqlstring = sqlstring & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    '''********************************************* UPDATE PURCHASE RATE IN INVENTORY ITEMMASTER *************************'''
                    ssgrid.Col = 5
                    ssgrid.Row = i
                    sqlstring = "UPDATE INVENTORYITEMMASTER SET PURCHASERATE = " & Format(Val(ssgrid.Text), "0.00") & " "
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    sqlstring = sqlstring & "WHERE ITEMCODE = '" & Trim(ssgrid.Text) & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    '''********************************************* UPDATE COMPLETE ******************************************************'''
                Next i
                '''************************************************* INSERT BILLING DETAILS INTO GRN_BILLTERMS ****************************'''
                For i = 1 To ssgrid_billdetails.DataRowCnt
                    ssgrid_billdetails.Row = i
                    sqlstring = "INSERT INTO Grn_billterms(Grndetails,Grndate,Billterms,Percentage,Taxcode,Amount,"
                    sqlstring = sqlstring & " Slno,Formula,Signs,Accode,Acdesc)"
                    sqlstring = sqlstring & " VALUES('" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd-MMM-yyyy ") & "',"
                    ssgrid_billdetails.Col = 1
                    sqlstring = sqlstring & "'" & Trim(ssgrid_billdetails.Text) & "',"
                    ssgrid_billdetails.Col = 2
                    sqlstring = sqlstring & "" & Format(Val(ssgrid_billdetails.Text), "0.00") & ","
                    ssgrid_billdetails.Col = 3
                    sqlstring = sqlstring & "'" & Trim(ssgrid_billdetails.Text) & "',"
                    ssgrid_billdetails.Col = 4
                    sqlstring = sqlstring & "" & Format(Val(ssgrid_billdetails.Text), "0.00") & ","
                    ssgrid_billdetails.Col = 5
                    sqlstring = sqlstring & "" & Format(Val(ssgrid_billdetails.Text), "0.00") & ","
                    ssgrid_billdetails.Col = 6
                    sqlstring = sqlstring & "'" & Trim(ssgrid_billdetails.Text) & "',"
                    ssgrid_billdetails.Col = 7
                    sqlstring = sqlstring & "'" & Trim(ssgrid_billdetails.Text) & "',"
                    ssgrid_billdetails.Col = 8
                    sqlstring = sqlstring & "'" & Trim(ssgrid_billdetails.Text) & "',"
                    ssgrid_billdetails.Col = 9
                    sqlstring = sqlstring & "'" & Replace(Trim(ssgrid_billdetails.Text), "'", "") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next i
                '''****************************************** UPDATE COMPLETE *********************************************
                gconnection.MoreTrans(Insert)
                If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    If Trim(txt_Grnno.Text) <> "" Then
                        txt_FromDocno.Text = Trim(txt_Grnno.Text)
                        txt_ToDocno.Text = Trim(txt_Grnno.Text)
                    End If
                    Call Cmd_View_Click(Cmd_View, e)
                    'Call Cmd_Clear_Click(sender, e)
                Else
                    Call Cmd_Clear_Click(sender, e)
                End If
                '''*********************************************************** Case-2 : Update [F7] *******************************************'''
            ElseIf Mid(CStr(Cmd_Add.Text), 1, 1) = "U" Then
                GRNno = Split(Trim(txt_Grnno.Text), "/")
                Me.txt_Totalamt.Text = 0
                'Me.txt_Discountamt.Text = 0
                Me.txt_Billamount.Text = 0

                '============================================
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 4
                    Qty = Val(ssgrid.Text)
                    ssgrid.Col = 6
                    discount = Val(ssgrid.Text)
                    'Me.txt_Discountamt.Text = Format(Val(Me.txt_Discountamt.Text) + Val(discount), "0.00")
                    ssgrid.Col = 7
                    Amount = Val(ssgrid.Text)
                    totQty = Val(totQty) + Val(Qty)
                    Me.txt_Totalamt.Text = Format(Val(Me.txt_Totalamt.Text) + Val(Amount), "0.00")
                Next i
                '============================================
                Me.txt_Billamount.Text = Format(Val(txt_Totalamt.Text) + Val(txt_Vatamount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_Discountamt.Text), "0.00")
                GRNno = Split(Trim(txt_Grnno.Text), "/")
                Typecode = Split(Trim(cbo_Billingterms.Text), " ")
                '''********************************************************** UPDATING OPENING STOCK ****************************************************'''
                Dim strsql As String
                Dim vitemcode, vclsstock, vcurqty, vgrnqty, vdiff, vnetclosing, VDBLAMT, VHIGHRATIO
                Dim closingbalance As Double
                Dim j, k As Int16
                blnchkupdateclsbal = True
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 1
                    vitemcode = ssgrid.Text
                    ssgrid.Col = 4
                    vcurqty = ssgrid.Text
                    ssgrid.Col = 12
                    vclsstock = ssgrid.Text
                    ssgrid.Col = 11
                    vgrnqty = ssgrid.Text
                    ssgrid.Col = 10
                    VHIGHRATIO = ssgrid.Text
                    '''******************************** CALCULATION THE STOCK OPENING STOCK **************************'''
                    vdiff = Val(vgrnqty) - Val(vcurqty)
                    vnetclosing = Val(vclsstock) - Val(vdiff)
                    If vnetclosing < 0 Then
                        MessageBox.Show(" InSufficient Stock For Updation ...", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        ssgrid.Text = ""
                        ssgrid.SetActiveCell(4, i)
                        ssgrid.Focus()
                        Exit Sub
                    Else
                    End If
                Next
                '''********************************************************** UPDATE GRN_HEADER *********************************************************'''
                sqlstring = "UPDATE Grn_header SET Grndate='" & Format(CDate(dtp_Grndate.Value), "dd-MMM-yyyy") & "',"
                sqlstring = sqlstring & " Supplierinvno='" & Trim(CStr(txt_Supplierinvno.Text)) & "',Supplierdate='" & Format(CDate(dtp_Supplierinvdate.Value), "dd-MMM-yyyy") & "',"
                sqlstring = sqlstring & " Suppliercode='" & Trim(CStr(txt_Suppliercode.Text)) & "',Suppliername='" & Trim(CStr(txt_Suppliername.Text)) & "',Typecode = '" & Trim(CStr(Typecode(0))) & "',Typedesc = '" & Trim(CStr(Typecode(2))) & "',"
                sqlstring = sqlstring & " Excisepassno='" & Trim(CStr(txt_Excisepassno.Text)) & "',Excisedate='" & Format(CDate(dtp_Excisepassdate.Value), "dd-MMM-yyyy") & "',Stockindate ='" & Format(CDate(dtp_Stockindate.Value), "dd-MMM-yyyy") & "', "
                sqlstring = sqlstring & " Trucknumber ='" & Trim(CStr(txt_Trucknumber.Text)) & "' ,Creditdays=" & Val(txt_Creditdays.Text) & ",Glaccountcode = '" & Trim(CStr(Txt_GLAcIn.Text)) & "',Glaccountname ='" & Trim(CStr(Txt_GLAcDesc.Text)) & "', "
                sqlstring = sqlstring & " Slcode = '" & Trim(CStr(Txt_Slcode.Text)) & "',Slname='" & Trim(CStr(Txt_SlDesc.Text)) & "',Costcentercode ='" & Trim(CStr(Txt_CostCenterCode.Text)) & "',Costcentername ='" & Trim(CStr(Txt_CostCenterDesc.Text)) & "',"
                sqlstring = sqlstring & " Totalamount=" & Format(Val(txt_Totalamt.Text), "0.00") & ",VATamount = " & Format(Val(txt_Vatamount.Text), "0.00") & ",Surchargeamt = " & Format(Val(txt_Surchargeamt.Text), "0.00") & " ,Discount=" & Format(Val(txt_Discountamt.Text), "0.00") & ","
                sqlstring = sqlstring & " Billamount = " & IIf(Val(BillAmount) = 0, Format(Val(txt_Totalamt.Text) + Val(txt_Vatamount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_Discountamt.Text), "0.00"), Val(BillAmount)) & ","
                sqlstring = sqlstring & " Remarks = '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "") & "',Updateuser='" & Trim(gUsername) & "',Updatetime='" & Format(Now, "dd-MMM-yyyy hh:mm") & "'"
                sqlstring = sqlstring & " WHERE Grndetails='" & Trim(txt_Grnno.Text) & "' "
                Insert(0) = sqlstring
                '''********************************************************* DELETE FROM GRN_DETAILS *****************************************************'''
                sqlstring = "DELETE FROM Grn_details WHERE Grndetails='" & Trim(txt_Grnno.Text) & "' "
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                '''******************************************************** INSERT INTO GRN_DETAILS ******************************************************'''
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 1
                    Avgrate = CalAverageRate(Trim(ssgrid.Text))
                    Avgquantity = CalAverageQuantity(Trim(ssgrid.Text))
                    sqlstring = "INSERT INTO Grn_details(Grnno,Grndetails,Grndate,Suppliercode,Suppliername,Itemcode,Itemname,"
                    sqlstring = sqlstring & " UOM,Qty,Rate,Discount,Amount,Dblamount,DblUOM,Highratio,Voiditem,Avgqty,Avgrate,Category,Adduser,Adddate,UpdateUser,Updatetime)"
                    sqlstring = sqlstring & " VALUES('" & CStr(GRNno(2)) & "','" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd-MMM-yyyy ") & "',"
                    sqlstring = sqlstring & " '" & Trim(txt_Suppliercode.Text) & "','" & Trim(txt_Suppliername.Text) & "',"
                    ssgrid.Col = 1
                    sqlstring = sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 2
                    sqlstring = sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 3
                    sqlstring = sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 4
                    sqlstring = sqlstring & " " & Format(Val(ssgrid.Text), "0.000") & ","
                    ssgrid.Col = 5
                    sqlstring = sqlstring & " " & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 6
                    sqlstring = sqlstring & " " & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 7
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 8
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 9
                    sqlstring = sqlstring & "'" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 10
                    sqlstring = sqlstring & "" & Format(Val(ssgrid.Text), "0.00") & ","
                    sqlstring = sqlstring & "'N'," & Format(Val(Avgquantity), "0.000") & "," & Format(Val(Avgrate), "0.00") & ",'" & Trim(CMB_CATEGORY.Text) & "',"
                    sqlstring = sqlstring & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    '''********************************************* UPDATE PURCHASE RATE IN INVENTORY ITEMMASTER *************************'''
                    ssgrid.Col = 5
                    ssgrid.Row = i
                    sqlstring = "UPDATE INVENTORYITEMMASTER SET PURCHASERATE = " & Format(Val(ssgrid.Text), "0.00") & " "
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    sqlstring = sqlstring & "WHERE ITEMCODE = '" & Trim(ssgrid.Text) & "'"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    '''********************************************* UPDATE COMPLETE ******************************************************'''
                Next i
                '''********************************************************* DELETE FROM GRN_DETAILS *****************************************************'''
                sqlstring = "DELETE FROM Grn_billterms WHERE Grndetails='" & Trim(txt_Grnno.Text) & "' "
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring
                '''************************************************* INSERT BILLING DETAILS INTO GRN_BILLTERMS ****************************'''
                For i = 1 To ssgrid_billdetails.DataRowCnt
                    ssgrid_billdetails.Row = i
                    sqlstring = "INSERT INTO Grn_billterms(Grndetails,Grndate,Billterms,Percentage,Taxcode,Amount,"
                    sqlstring = sqlstring & " Slno,Formula,Signs,Accode,Acdesc)"
                    sqlstring = sqlstring & " VALUES('" & Trim(txt_Grnno.Text) & "','" & Format(CDate(dtp_Grndate.Value), "dd-MMM-yyyy ") & "',"
                    ssgrid_billdetails.Col = 1
                    sqlstring = sqlstring & "'" & Trim(ssgrid_billdetails.Text) & "',"
                    ssgrid_billdetails.Col = 2
                    sqlstring = sqlstring & "" & Format(Val(ssgrid_billdetails.Text), "0.00") & ","
                    ssgrid_billdetails.Col = 3
                    sqlstring = sqlstring & "'" & Trim(ssgrid_billdetails.Text) & "',"
                    ssgrid_billdetails.Col = 4
                    sqlstring = sqlstring & "" & Format(Val(ssgrid_billdetails.Text), "0.00") & ","
                    ssgrid_billdetails.Col = 5
                    sqlstring = sqlstring & "" & Format(Val(ssgrid_billdetails.Text), "0.00") & ","
                    ssgrid_billdetails.Col = 6
                    sqlstring = sqlstring & "'" & Trim(ssgrid_billdetails.Text) & "',"
                    ssgrid_billdetails.Col = 7
                    sqlstring = sqlstring & "'" & Trim(ssgrid_billdetails.Text) & "',"
                    ssgrid_billdetails.Col = 8
                    sqlstring = sqlstring & "'" & Trim(ssgrid_billdetails.Text) & "',"
                    ssgrid_billdetails.Col = 9
                    sqlstring = sqlstring & "'" & Replace(Trim(ssgrid_billdetails.Text), "'", "") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next i
                ''''***************************************** COMPLETE ACCOUNT POSTING FOR BILLDETAILS SECTIONS ****************************'''
                '''****************************************** UPDATE Complete *********************************************
                gconnection.MoreTrans(Insert)
                If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    If Trim(txt_Grnno.Text) <> "" Then
                        txt_FromDocno.Text = Trim(txt_Grnno.Text)
                        txt_ToDocno.Text = Trim(txt_Grnno.Text)
                    End If
                    Call Cmd_View_Click(Cmd_View, e)
                    'Call Cmd_Clear_Click(sender, e)
                Else
                    Call Cmd_Clear_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CMD_ADD_CLEAR" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub checkupdate_clsbal()
        Try
            Dim vclsstock, vcurqty, vgrnqty, vdiff, vnetclosing As Double
            Dim strsql, vitemcode As String
            Dim i, j, k As Integer
            blnchkupdateclsbal = True
            For i = 1 To ssgrid.DataRowCnt
                ssgrid.Row = i
                ssgrid.Col = 1
                vitemcode = Trim(ssgrid.Text)
                ssgrid.Col = 4
                vcurqty = Val(ssgrid.Text)
                ssgrid.Col = 12
                vclsstock = Val(ssgrid.Text)
                ssgrid.Col = 11
                vgrnqty = Val(ssgrid.Text)
                ''********************************** CALCULATION OF STOCK ********************************'''
                vdiff = Val(vgrnqty) - Val(vcurqty)
                vnetclosing = Val(vclsstock) - Val(vdiff)
                If vnetclosing < 0 Then
                    MessageBox.Show(" Insufficient Stock For Updation ...", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    ssgrid.Focus()
                    blnchkupdateclsbal = False
                    Exit Sub
                End If
            Next i
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CHECKUPDATE_CLBAL" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Try
            Call checkValidation() ''-->Check Validation
            Dim insert(0) As String
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
                '''***************************************** Void the GRNNO in Grn_header **************************'''
                sqlstring = "UPDATE  GRN_HEADER "
                sqlstring = sqlstring & " SET Void= 'Y',"
                sqlstring = sqlstring & " Updateuser='" & Trim(gUsername) & " ',"
                sqlstring = sqlstring & " Updatetime ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE Grndetails = '" & Trim(txt_Grnno.Text) & "'"
                insert(0) = sqlstring
                '''***************************************** Void the GRNNO in Complete **********************************'''
                '''***************************************** Void the GRNNO in Grn_details **************************'''
                For i = 1 To ssgrid.DataRowCnt
                    With ssgrid
                        sqlstring = "UPDATE  GRN_DETAILS "
                        sqlstring = sqlstring & " SET Voiditem= 'Y',"
                        sqlstring = sqlstring & " Updateuser='" & Trim(gUsername) & " ',"
                        sqlstring = sqlstring & " Updatetime ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                        sqlstring = sqlstring & " WHERE Grndetails = '" & Trim(txt_Grnno.Text) & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring
                    End With
                Next i
                '''***************************************** Void the GRNNO is Complete **********************************'''
                '''***************************************** Void the GRNNO in Grn_header **************************'''
                'BLOCKJOURNALENTRY****************************************************************************************
                'sqlstring = "UPDATE  JOURNALENTRY "
                'sqlstring = sqlstring & " SET Void= 'Y',"
                'sqlstring = sqlstring & " FreezeUserId='" & Trim(gUsername) & " ',"
                'sqlstring = sqlstring & " FreezeDateTime ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                'sqlstring = sqlstring & " WHERE Voucherno = '" & Trim(txt_Grnno.Text) & "'"
                'ReDim Preserve insert(insert.Length)
                'insert(insert.Length - 1) = sqlstring
                '''***************************************** Void the GRNNO in Complete **********************************'''
                ''''********************************** CALCULATION OF AVERAGE FOR A PARTICULAR ITEM ***************'''
                'Dim opquantity, opamount, grnquantity, grnamount As Double
                'Dim issuequantity, issueamount As Double
                'Dim calrate, clsquantity, calquantity As Double
                '''''********************************* From Opening Stock *********************************'''
                'For i = 1 To ssgrid.DataRowCnt
                '    With ssgrid
                '        .Row = i
                '        .Col = 1
                '        '''********************************** CALCULATION OF AVERAGE FOR A PARTICULAR ITEM ***************'''
                '        ''''********************************* From Opening Stock *********************************'''
                '        sqlstring = "SELECT opstock,opvalue FROM inventoryitemmaster WHERE Itemcode='" & Trim(.Text) & "'"
                '        gconnection.getDataSet(sqlstring, "inventoryitemmaster")
                '        If gdataset.Tables("inventoryitemmaster").Rows.Count > 0 Then
                '            opquantity = Format(Val(gdataset.Tables("inventoryitemmaster").Rows(0).Item("opstock") & ""), "0.000")
                '            opamount = Format(Val(gdataset.Tables("inventoryitemmaster").Rows(0).Item("opvalue") & ""), "0.00")
                '        Else
                '            opquantity = 0
                '            opamount = 0
                '        End If
                '        ''''********************************* From Grn_details *********************************'''
                '        sqlstring = "SELECT SUM(qty) AS QTY ,SUM(AMOUNT) AS AMOUNT FROM grn_details WHERE Itemcode='" & Trim(.Text) & "' AND Voiditem='N'"
                '        gconnection.getDataSet(sqlstring, "grn_details")
                '        If gdataset.Tables("grn_details").Rows.Count > 0 Then
                '            grnquantity = Format(Val(gdataset.Tables("grn_details").Rows(0).Item("QTY") & ""), "0.000")
                '            grnamount = Format(Val(gdataset.Tables("grn_details").Rows(0).Item("AMOUNT") & ""), "0.00")
                '        Else
                '            grnquantity = 0
                '            grnamount = 0
                '        End If
                '        calquantity = Val(opquantity) + Val(grnquantity)
                '        If calquantity = 0 Then
                '            calrate = 0
                '        Else
                '            calrate = (Val(opamount) + Val(grnamount)) / Val(calquantity)
                '        End If
                '        ''''********************************* From Stockissuedetail *********************************'''
                '        sqlstring = "SELECT SUM(qty) AS QTY  FROM stockissuedetail WHERE Itemcode='" & Trim(.Text) & "' AND Void='N'"
                '        gconnection.getDataSet(sqlstring, "stockissuedetail")
                '        If gdataset.Tables("stockissuedetail").Rows.Count > 0 Then
                '            issuequantity = Format(Val(gdataset.Tables("stockissuedetail").Rows(0).Item("Qty") & ""), "0.000")
                '            issueamount = Val(calrate) * Val(issuequantity)
                '        Else
                '            issuequantity = 0
                '            issueamount = 0
                '        End If
                '        ''' ********************************* To Find Out Closing Balance ***************************'''
                '        calquantity = (Val(opquantity) + Val(grnquantity) - Val(issuequantity))
                '        If calquantity = 0 Then
                '            calrate = 0
                '        Else
                '            calrate = (Val(opamount) + Val(grnamount) - Val(issueamount)) / (Val(calquantity))
                '        End If
                '        clsquantity = (Val(opquantity) + Val(grnquantity) - Val(issuequantity))
                '        '''******************************************
                '        '''****************************************** UPDATE Opening Stock ***************************************
                '        sqlstring = "UPDATE OpeningStock SET "
                '        .Col = 4
                '        sqlstring = sqlstring & " mainclstock = mainclstock - " & Format(Val(.Text), "0") & ","
                '        .Col = 8
                '        sqlstring = sqlstring & " doublevalue= doublevalue - " & Format(Val(.Text), "0.00") & ","
                '        sqlstring = sqlstring & " avgrate= " & Format(Val(calrate), "0.00") & ","
                '        sqlstring = sqlstring & " avgvalue= " & Format(Val(clsquantity) * Val(calrate), "0.00") & ","
                '        sqlstring = sqlstring & "Adduser='" & Trim(gUsername) & "',Adddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                '        .Col = 1
                '        sqlstring = sqlstring & "WHERE Itemcode='" & Trim(.Text) & "' "
                '        ReDim Preserve insert(insert.Length)
                '        insert(insert.Length - 1) = sqlstring
                '    End With
                'Next i
                gconnection.MoreTrans(insert)
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
                '''****************************************** UPDATE Complete *********************************************
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CMD_FREEZE" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Function printoperation()
        Try
            Dim i As Integer
            Dim objGrncumpurchase As New rptGrncumpurchaseNote
            Dim sqlstring = "SELECT ISNULL(G.GRNDETAILS,'') AS GRNDETAILS,G.GRNDATE, ISNULL(G.SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(G.SUPPLIERNAME,'') AS SUPPLIERNAME,"
            sqlstring = sqlstring & " ISNULL(G.SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(G.EXCISEPASSNO,'') AS EXCISEPASSNO,ISNULL(G.GLACCOUNTCODE,'') AS GLACCOUNTCODE,ISNULL(G.GLACCOUNTNAME,'') AS GLACCOUNTNAME,"
            sqlstring = sqlstring & " ISNULL(G.TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(G.SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(G.DISCOUNT,0) AS DISCOUNT,ISNULL(G.BILLAMOUNT,0) AS BILLAMOUNT,"
            sqlstring = sqlstring & " ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM, ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE, "
            sqlstring = sqlstring & " ISNULL(D.AMOUNT,0) AS AMOUNT FROM GRN_HEADER AS G INNER JOIN GRN_DETAILS AS D ON G.GRNDETAILS = D.GRNDETAILS"
            sqlstring = sqlstring & " WHERE G.GRNDETAILS BETWEEN '" & Trim(txt_Grnno.Text) & "' AND '" & Trim(txt_Grnno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY G.GRNDETAILS,G.GRNDATE"
            Dim heading() As String = {"GRN CUM PURCHASE BILL"}
            objGrncumpurchase.ReportDetails(sqlstring, heading, txt_Grnno.Text, txt_Grnno.Text)
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Printoperation " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Try
            gPrint = False
            Call printoperation()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : View Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Exit Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Grnno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Grnno.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_Grnno.Text) = "" Then
                    Call cmd_Grnnohelp_Click(cmd_Grnnohelp, e)
                Else
                    txt_Grnno_Validated(txt_Grnno, e)
                    dtp_Grndate.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Grnno Key Press " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub dtp_Grndate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Grndate.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                txt_Supplierinvno.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Grn Date Keypress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Supplierinvno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Supplierinvno.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                dtp_Supplierinvdate.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Supplier Invno Keypress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub dtp_Supplierinvdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Supplierinvdate.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                grp_Excisedetails.Top = 104
                grp_Excisedetails.Left = 216
                grp_Excisedetails.BringToFront()
                dtp_Stockindate.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : dtp_Supplierinvdate_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Suppliercode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Suppliercode.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_Suppliercode.Text) = "" Then
                    Call cmd_Suppliercodehelp_Click(cmd_Suppliercodehelp, e)
                Else
                    Call txt_Suppliercode_Validated(txt_Suppliercode, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Suppliercode_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Suppliername_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Suppliername.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If slcodestatus = True Then
                    Txt_Slcode.Focus()
                Else
                    ssgrid.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Suppliername_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Excisepassno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Excisepassno.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                dtp_Excisepassdate.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Excisepassno_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub dtp_Excisepassdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Excisepassdate.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                txt_Trucknumber.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : dtp_Excisepassdate_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cbo_Storelocation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_Storelocation.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                txt_Creditdays.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cbo_Storelocation_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Creditdays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Creditdays.KeyPress
        Try
            getNumeric(e)
            If Asc(e.KeyChar) = 13 Then
                ssgrid.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Creditdays_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Totalamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Totalamt.KeyPress
        Try
            getNumeric(e)
            If Asc(e.KeyChar) = 13 Then
                txt_Vatamount.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Totalamt_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Billamt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            getNumeric(e)
            If Asc(e.KeyChar) = 13 Then
                Cmd_Add.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Billamt_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_Grnnohelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Grnnohelp.Click
        Try
            gSQLString = "SELECT Grndetails,Grndate FROM Grn_header"
            M_WhereCondition = " "
            Dim vform As New List_Operation
            vform.Field = "GRNDETAILS,GRNDATE"
            vform.vFormatstring = "       GRN CODE       |         GRN DATE                             "
            vform.vCaption = "GRN CUM PURCHASE BILL HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Grnno.Text = Trim(vform.keyfield & "")
                Call txt_Grnno_Validated(txt_Grnno, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_Grnnohelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Grnno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Grnno.Validated
        Dim I, J, K As Integer
        Dim vString, sqlstring As String
        Dim vTypeseqno, Clsquantity As Double
        Dim vGroupseqno As Double
        Dim dt As New DataTable
        If Trim(txt_Grnno.Text) <> "" Then
            Try
                sqlstring = "SELECT  ISNULL(GRNNO,'') AS GRNNO,ISNULL(GRNDETAILS,'') AS GRNDETAILS,GRNDATE,ISNULL(SUPPLIERINVNO,'') AS SUPPLIERINVNO,"
                sqlstring = sqlstring & " SUPPLIERDATE,ISNULL(SUPPLIERCODE,'') AS SUPPLIERCODE,ISNULL(SUPPLIERNAME,'') AS SUPPLIERNAME,ISNULL(TYPECODE,'') AS TYPECODE,"
                sqlstring = sqlstring & " ISNULL(TYPEDESC,'') AS TYPEDESC, ISNULL(EXCISEPASSNO,'') AS EXCISEPASSNO,EXCISEDATE,STOCKINDATE,ISNULL(TRUCKNUMBER,'') AS TRUCKNUMBER,"
                sqlstring = sqlstring & " ISNULL(CREDITDAYS,0) AS CREDITDAYS,ISNULL(GLACCOUNTCODE,'') AS GLACCOUNTCODE,ISNULL(GLACCOUNTNAME,'') AS GLACCOUNTNAME,"
                sqlstring = sqlstring & " ISNULL(SLCODE,'') AS SLCODE,ISNULL(SLNAME,'') AS SLNAME,ISNULL(COSTCENTERCODE,'') AS COSTCENTERCODE,ISNULL(COSTCENTERNAME,'') AS COSTCENTERNAME,"
                sqlstring = sqlstring & " ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(BILLAMOUNT,0) AS BILLAMOUNT,ISNULL(REMARKS,'') AS REMARKS,"
                sqlstring = sqlstring & " ISNULL(VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,UPDATETIME  FROM GRN_HEADER"
                sqlstring = sqlstring & " WHERE GRNNO = '" & Format(Val(txt_Grnno.Text), "0000") & "' OR Grndetails='" & Trim(txt_Grnno.Text) & "'"
                gconnection.getDataSet(sqlstring, "GRNHEADER")
                '''************************************************* SELECT record from Grn_header *********************************************''''                
                If gdataset.Tables("GRNHEADER").Rows.Count > 0 Then
                    Call GridUnLock()
                    Cmd_Add.Text = "Update[F7]"
                    Me.txt_Grnno.ReadOnly = True
                    txt_Grnno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDETAILS"))
                    dtp_Grndate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDATE")), "dd-MMM-yyyy")
                    txt_Supplierinvno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERINVNO"))
                    dtp_Supplierinvdate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERDATE")), "dd-MMM-yyyy")
                    txt_Suppliercode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERCODE"))
                    txt_Suppliername.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SUPPLIERNAME"))
                    cbo_Billingterms.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("TYPECODE")) & "  " & Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("TYPEDESC"))
                    txt_Excisepassno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("EXCISEPASSNO"))
                    dtp_Excisepassdate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("EXCISEDATE")), "dd-MMM-yyyy")
                    dtp_Stockindate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("STOCKINDATE")), "dd-MMM-yyyy")
                    txt_Trucknumber.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("TRUCKNUMBER"))
                    txt_Creditdays.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("CREDITDAYS")), "0")
                    Txt_GLAcIn.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("GLACCOUNTCODE"))
                    Txt_GLAcDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("GLACCOUNTNAME"))
                    Txt_Slcode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SLCODE"))
                    Txt_SlDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("SLNAME"))
                    txt_Totalamt.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("TOTALAMOUNT")), "0.00")
                    If Trim(Txt_Slcode.Text) <> "" Then
                        grp_grnposting.Top = 192
                        grp_grnposting.Width = 848
                        grp_grnposting.Height = 80
                        ssgrid.Left = 72
                        ssgrid.Top = 272
                        ssgrid.Height = 280
                        Lbl_SubledgerCode.Visible = True
                        Lbl_SubledgerName.Visible = True
                        Txt_Slcode.Visible = True
                        Cmd_SlCodeHelp.Visible = True
                        Txt_SlDesc.Visible = True
                    Else
                        grp_grnposting.Top = 192
                        grp_grnposting.Height = 48
                        grp_grnposting.Width = 848
                        ssgrid.Top = 240
                        ssgrid.Left = 72
                        ssgrid.Height = 264
                    End If
                    Txt_CostCenterCode.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("COSTCENTERCODE"))
                    Txt_CostCenterDesc.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("COSTCENTERNAME"))
                    If Trim(Txt_CostCenterCode.Text) <> "" And Trim(Txt_Slcode.Text) <> "" Then
                        grp_grnposting.Top = 192
                        grp_grnposting.Height = 120
                        grp_grnposting.Width = 848
                        ssgrid.Top = 312
                        ssgrid.Left = 72
                        ssgrid.Height = 240
                        lbl_Creditdays.Top = 280
                        lbl_Creditdays.Left = 504
                        txt_Creditdays.Top = 280
                        txt_Creditdays.Left = 672
                    ElseIf Trim(Txt_CostCenterCode.Text) = "" And Trim(Txt_Slcode.Text) <> "" Then
                        grp_grnposting.Top = 192
                        grp_grnposting.Width = 848
                        grp_grnposting.Height = 80
                        ssgrid.Left = 72
                        ssgrid.Top = 272
                        ssgrid.Height = 224
                        Lbl_SubledgerCode.Visible = True
                        Lbl_SubledgerName.Visible = True
                        Txt_Slcode.Visible = True
                        Cmd_SlCodeHelp.Visible = True
                        Txt_SlDesc.Visible = True
                    Else
                        grp_grnposting.Top = 192
                        grp_grnposting.Height = 48
                        grp_grnposting.Width = 848
                        ssgrid.Top = 240
                        ssgrid.Left = 72
                        ssgrid.Height = 264
                    End If
                    txt_Discountamt.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("DISCOUNT")), "0.00")
                    txt_Vatamount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("VATAMOUNT")), "0.00")
                    txt_Surchargeamt.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("SURCHARGEAMT")), "0.00")
                    txt_Billamount.Text = Format(Val(gdataset.Tables("GRNHEADER").Rows(0).Item("BILLAMOUNT")), "0.00")
                    txt_Remarks.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("REMARKS"))
                    If Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("VOID")) = "Y" Then
                        Cmd_Add.Enabled = False
                        Cmd_Freeze.Enabled = False
                    End If
                    '''************************************************* SELECT record from Grn_details *********************************************''''                

                    Dim vtmpitemcode, strsql As String
                    sqlstring = "SELECT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,ISNULL(UOM,'') AS UOM,"
                    sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,"
                    sqlstring = sqlstring & " ISNULL(DBLAMOUNT,0) AS DBLAMOUNT,ISNULL(DBLUOM,'') AS DBLUOM,ISNULL(HIGHRATIO,0) AS HIGHRATIO,ISNULL(VOIDITEM,'') AS VOIDITEM FROM GRN_DETAILS WHERE  GRNDETAILS ='" & Trim(txt_Grnno.Text) & "'"
                    gconnection.getDataSet(sqlstring, "GRNDETAILS")
                    If gdataset.Tables("GRNDETAILS").Rows.Count > 0 Then
                        For I = 1 To gdataset.Tables("GRNDETAILS").Rows.Count
                            ssgrid.SetText(1, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE")))
                            vtmpitemcode = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMCODE"))
                            ssgrid.SetText(2, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("ITEMNAME")))
                            ssgrid.Col = 3
                            ssgrid.Row = I
                            ssgrid.TypeComboBoxString = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                            ssgrid.Text = Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("UOM"))
                            ssgrid.SetText(4, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("QTY")))
                            ssgrid.SetText(5, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("RATE")), "0.00"))
                            ssgrid.SetText(6, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("DISCOUNT")), "0.00"))
                            ssgrid.SetText(7, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("AMOUNT")), "0.00"))
                            ssgrid.SetText(8, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("DBLAMOUNT")), "0.00"))
                            ssgrid.SetText(9, I, Trim(gdataset.Tables("GRNDETAILS").Rows(J).Item("DBLUOM")))
                            ssgrid.SetText(10, I, Format(Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("HIGHRATIO")), "0.00"))
                            ssgrid.SetText(11, I, Val(gdataset.Tables("GRNDETAILS").Rows(J).Item("QTY")))
                            'Clsquantity = ClosingQuantity(vtmpitemcode, "MNS")
                            Clsquantity = ClosingQuantity(vtmpitemcode, GetMainStore())
                            ssgrid.SetText(12, I, Clsquantity)
                            CMB_CATEGORY.Text = gdataset.Tables("GRNDETAILS").Rows(J).Item("CATEGORY")
                            'strsql = "SELECT ISNULL(MAINCLSTOCK,0) AS MAINCLSTOCK FROM OPENINGSTOCK WHERE ITEMCODE = '" & Trim(vtmpitemcode) & "' "
                            'gconnection.getDataSet(strsql, "OPENINGSTOCK")
                            'If gdataset.Tables("OPENINGSTOCK").Rows.Count > 0 Then
                            '    ssgrid.SetText(12, I, gdataset.Tables("OPENINGSTOCK").Rows(0).Item(0))
                            'End If
                            J = J + 1
                        Next
                    End If
                    TotalCount = gdataset.Tables("GRNDETAILS").Rows.Count
                    ssgrid.SetActiveCell(1, 1)
                    sqlstring = "SELECT ISNULL(BillTerms,'') AS BillTerms,ISNULL(Percentage,0) AS Percentage,ISNULL(TaxCode,'') AS Taxcode,ISNULL(Amount,0) AS Amount,ISNULL(SlNo,0) AS SlNo,ISNULL(Formula,'')AS Formula,"
                    sqlstring = sqlstring & "ISNULL(Signs,'') AS Signs,ISNULL(Accode,'') AS Accode,ISNULL(Acdesc,'') AS Acdesc FROM grn_billterms WHERE  Grndetails='" & Trim(txt_Grnno.Text) & "' ORDER BY AUTOID"
                    gconnection.getDataSet(sqlstring, "grn_billterms")
                    If gdataset.Tables("grn_billterms").Rows.Count > 0 Then
                        For I = 1 To gdataset.Tables("grn_billterms").Rows.Count
                            ssgrid_billdetails.SetText(1, I, Trim(gdataset.Tables("grn_billterms").Rows(K).Item("BillTerms")))
                            ssgrid_billdetails.SetText(2, I, Format(Val(gdataset.Tables("grn_billterms").Rows(K).Item("Percentage")), "0.00"))
                            ssgrid_billdetails.SetText(3, I, Trim(gdataset.Tables("grn_billterms").Rows(K).Item("Taxcode")))
                            ssgrid_billdetails.SetText(4, I, Format(Val(gdataset.Tables("grn_billterms").Rows(K).Item("Amount")), "0.00"))
                            ssgrid_billdetails.SetText(5, I, Format(Val(gdataset.Tables("grn_billterms").Rows(K).Item("SlNo")), "0"))
                            ssgrid_billdetails.SetText(6, I, Trim(gdataset.Tables("grn_billterms").Rows(K).Item("Formula")))
                            ssgrid_billdetails.SetText(7, I, Trim(gdataset.Tables("grn_billterms").Rows(K).Item("Signs")))
                            ssgrid_billdetails.SetText(8, I, Trim(gdataset.Tables("grn_billterms").Rows(K).Item("Accode")))
                            ssgrid_billdetails.SetText(9, I, Trim(gdataset.Tables("grn_billterms").Rows(K).Item("Acdesc")))
                            K = K + 1
                        Next
                    End If
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid GRN No : txt_Grnno_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub cmd_Suppliercodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Suppliercodehelp.Click
        Try
            gSQLString = "SELECT SLCODE,SLNAME FROM accountssubledgermaster "
            M_WhereCondition = " WHERE ACCODE = '" & Trim(gCreditors) & "' "
            Dim vform As New List_Operation
            vform.Field = "SLCODE,SLNAME"
            vform.vFormatstring = "       SLCODE                    |                      SLNAME                             "
            vform.vCaption = "SIDE LEDGER MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Suppliercode.Text = Trim(vform.keyfield & "")
                Call txt_Suppliercode_Validated(txt_Suppliercode, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_Suppliercodehelp_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub txt_Grnno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Grnno.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If cmd_Grnnohelp.Enabled = True Then
                    search = Trim(txt_Grnno.Text)
                    Call cmd_Grnnohelp_Click(cmd_Grnnohelp, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Grnno_KeyDown" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub GRN_Cum_Purchase_Bill_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F2 Then
                txt_Grnno.Text = ""
                txt_Grnno.Focus()
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F12 Then
                Call billingterms()
                Exit Sub
            ElseIf e.KeyCode = Keys.Escape Then
                If grp_Excisedetails.Top = 104 Then
                    grp_Excisedetails.Top = 1000
                    dtp_Supplierinvdate.Focus()
                    Exit Sub
                ElseIf grp_Billingdetails.Top = 144 Then
                    grp_Billingdetails.Top = 1000
                    txt_Remarks.Focus()
                    Exit Sub
                ElseIf grp_StockGrndetails.Top = 176 Then
                    grp_StockGrndetails.Top = 1000
                    Cmd_View.Focus()
                    Exit Sub
                Else
                    Call Cmd_Exit_Click(Cmd_Exit, e)
                    Exit Sub
                End If
            ElseIf e.Alt = True And e.KeyCode = Keys.R Then
                Me.txt_Remarks.Focus()
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.D Then
                Me.txt_Discountamt.Focus()
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.G Then
                Me.ssgrid.Focus()
                Me.ssgrid.SetActiveCell(1, 1)
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.V Then
                Me.txt_Vatamount.Focus()
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.N Then
                Me.txt_Grnno.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub autogenerate()
        Try
            Dim sqlstring, financalyear As String
            Dim month As String
            Dim CATLEN As Integer

            month = UCase(Format(Now, "MMM"))
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialyearEnd, 3, 2)

            sqlstring = "SELECT ISNULL(CATEGORY,'') AS CATEGORY FROM INVENTORYITEMMASTER WHERE ISNULL(CATEGORY,'')='" & Trim(CMB_CATEGORY.Text & "") & "' GROUP BY CATEGORY"
            gconnection.getDataSet(sqlstring, "CATEGORY")
            If gdataset.Tables("CATEGORY").Rows.Count > 0 Then
                CATEGORY = Mid(Trim(gdataset.Tables("CATEGORY").Rows(0).Item("CATEGORY") & ""), 1, 3)
                CATLEN = Len(Trim(CATEGORY))
            Else
                CATLEN = 3
                CATEGORY = month
            End If
            sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER WHERE SUBSTRING(GRNDETAILS,5," & CATLEN & ")='" & CATEGORY & "'"
            '        sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    txt_Grnno.Text = "GRN/" & CATEGORY & "/0001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    txt_Grnno.Text = "GRN/" & CATEGORY & "/" & Format(gdreader(0) + 1, "0000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txt_Grnno.Text = "GRN/" & CATEGORY & "/0001/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : autogenerate" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Calculate()
        Try
            Dim ValQty, ValRate, ValDiscount, VarTotal As Double
            Dim ValHighratio, ValItemamount, ValDblamount As Double
            Dim i As Integer
            If ssgrid.ActiveCol = 1 Or ssgrid.ActiveCol = 2 Or ssgrid.ActiveCol = 3 Or ssgrid.ActiveCol = 4 Or ssgrid.ActiveCol = 5 Or ssgrid.ActiveCol = 6 Then
                i = ssgrid.ActiveRow
                ssgrid.Col = 4
                ssgrid.Row = i
                ValQty = Val(ssgrid.Text)
                ssgrid.Col = 5
                ssgrid.Row = i
                ValRate = Val(ssgrid.Text)
                ssgrid.Col = 6
                ssgrid.Row = i
                ValDiscount = Val(ssgrid.Text)
                ssgrid.Col = 10
                ssgrid.Row = i
                ValHighratio = Val(ssgrid.Text())
                ValItemamount = Format(Val(ValQty) * Val(ValRate), "0.00")
                ValDblamount = Format(Val(ValQty) * Val(ValHighratio), "0.00")
                If Val(ValItemamount) = 0 Then
                    ssgrid.SetText(7, i, "")
                    ssgrid.SetText(8, i, "")
                Else
                    ssgrid.SetText(7, i, Val(ValItemamount))
                    ssgrid.SetText(8, i, Val(ValDblamount))
                End If
                Me.txt_Totalamt.Text = 0
                'Me.txt_Discountamt.Text = 0
                Me.txt_Billamount.Text = 0
                ValDiscount = 0 : VarTotal = 0
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Col = 6
                    ssgrid.Row = i
                    ValDiscount = Val(ssgrid.Text)
                    ssgrid.Col = 7
                    ssgrid.Row = i
                    VarTotal = Val(ssgrid.Text)
                    'Me.txt_Discountamt.Text = Format(Val(Me.txt_Discountamt.Text) + Val(ValDiscount), "0.00")
                    Me.txt_Totalamt.Text = Format(Val(Me.txt_Totalamt.Text) + Val(VarTotal), "0.00")
                    Me.txt_Billamount.Text = Format(Val(Me.txt_Totalamt.Text) - Val(Me.txt_Discountamt.Text), "0.00")
                Next i
                i = i - 1
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Calculate" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub checkValidation()
        Try
            boolchk = False
            '''**************************************** Check DATEVALIDATION *******************************************''
            Call Checkdatevalidate(Format(dtp_Grndate.Value, "dd-MMM-yyyy"))
            If chkdatevalidate = False Then Exit Sub
            '''**************************************** Check GRN NO. can't be blank *******************************************''
            If Trim(txt_Grnno.Text) = "" Then
                MessageBox.Show("GRN NO. Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_Grnno.Focus()
                Exit Sub
            End If
            '''**************************************** Check SUPPLIER INVOICENO. can't be blank *******************************************''
            If Trim(txt_Supplierinvno.Text) = "" Then
                MessageBox.Show("Supplier Invoice no. Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_Supplierinvno.Focus()
                Exit Sub
            End If
            '''**************************************** Check SUPPLIER CODE can't be blank *******************************************''
            If Trim(txt_Suppliercode.Text) = "" Then
                MessageBox.Show("Supplier Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_Suppliercode.Focus()
                Exit Sub
            End If
            '''**************************************** Check SUPPLIER NAME can't be blank *******************************************''
            If Trim(txt_Suppliername.Text) = "" Then
                MessageBox.Show("Supplier Name Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_Suppliername.Focus()
                Exit Sub
            End If

            sqlstring = "SELECT ISNULL(CATEGORY,'') AS CATEGORY FROM INVENTORYITEMMASTER WHERE ISNULL(CATEGORY,'')='" & Trim(CMB_CATEGORY.Text & "") & "' GROUP BY CATEGORY"
            gconnection.getDataSet(sqlstring, "CATEGORY")
            If gdataset.Tables("CATEGORY").Rows.Count <= 0 Then
                MsgBox("Select Valid Category....", MsgBoxStyle.OKOnly, "Category")
                CMB_CATEGORY.Focus()
            End If

            ''''**************************************** Check EXCISE PASS NO. can't be blank *******************************************''
            'If Trim(txt_Excisepassno.Text) = "" Then
            '    MessageBox.Show("Excise Pass no. Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    txt_Excisepassno.Focus()
            '    Exit Sub
            'End If
            ''''**************************************** Check Discount Amount can't be More then 100 *******************************************''
            ''=============================
            '''''If Val(txt_Discountamt.Text) >= 0 And Val(txt_Discountamt.Text) <= 100 Then
            '''''Else
            '''''    MessageBox.Show("Discount Amount can't be More then 100", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '''''    txt_Discountamt.Text = ""
            '''''    txt_Discountamt.Focus()
            '''''    Exit Sub
            '''''End If
            '============================  
            '''**************************************** Check TOTAL AMOUNT can't be blank *******************************************''
            If Trim(txt_Totalamt.Text) = "" Then
                MessageBox.Show("Total Amount Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txt_Totalamt.Focus()
                Exit Sub
            End If
            '''**************************************** Check BILL AMOUNT can't be blank *******************************************''
            'If Trim(txt_Billamt.Text) = "" Then
            '    MessageBox.Show("Bill Amount Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            '    txt_Billamt.Focus()
            '    Exit Sub
            'End If
            'DISABLE GLACCOUNT
            If Trim(Txt_GLAcIn.Text) = "" Then
                MessageBox.Show("GLAcin cannot be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Txt_GLAcIn.Focus()
                Exit Sub
            End If

            If Trim(Txt_Slcode.Text) = "" And slcodestatus = True Then
                MessageBox.Show("Slcode cannot be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Txt_GLAcIn.Focus()
                Exit Sub
            End If
            If Trim(Txt_CostCenterCode.Text) = "" And costcentercodestatus = True Then
                MessageBox.Show("Costcentercode cannot be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Txt_GLAcIn.Focus()
                Exit Sub
            End If
            '''********************************************* Check ssgrid value can't be blank ********************************************'''
            For i = 1 To ssgrid.DataRowCnt
                ssgrid.Row = i
                ssgrid.Col = 1
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Item Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                ssgrid.Col = 2
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Item Description can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                ssgrid.Col = 3
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                ssgrid.Col = 4
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Quantity can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                ssgrid.Col = 5
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                ssgrid.Col = 7
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                ssgrid.Col = 8
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Double Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(8, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                ssgrid.Col = 9
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Double Conv can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(9, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                ssgrid.Col = 10
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("High Ratio can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(10, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
            Next
            If Cmd_Add.Text = "Update[F7]" And Me.lbl_Grn.Text = "Bill Generated" Then
                If Me.ssgrid.DataRowCnt > TotalCount Then
                    MsgBox("GRN Has Been Generated You Can Not Add More Item", MsgBoxStyle.Exclamation, MyCompanyName)
                    Exit Sub
                End If
            End If
            ''''**********check if the bill is matched
            Dim strsql As String
            strsql = "select count(*) as count from matching where avoucherno='" & Trim(txt_Grnno.Text) & "' "
            gconnection.getDataSet(strsql, "matching")
            If gdataset.Tables("matching").Rows.Count > 0 Then
                If gdataset.Tables("matching").Rows(0).Item("Count") >= 1 Then
                    MsgBox("Bill is Already Matched ..." & vbCrLf & "You Cannot Modify the Bill", MsgBoxStyle.Exclamation, MyCompanyName)
                    boolchk = False
                    Exit Sub
                End If
            End If
            boolchk = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : checkValidation" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillMenu()
        Try
            Dim vform As New List_Operation
            Dim K As Integer
            '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
            gSQLString = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,ISNULL(I.PURCHASERATE,0) AS PURCHASERATE, "
            gSQLString = gSQLString & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK  AS O ON O.ITEMCODE = I.ITEMCODE "
            If Trim(search) = " " Then
                M_WhereCondition = ""
            Else
                M_WhereCondition = " WHERE I.ITEMCODE LIKE '" & Trim(search) & "%' AND ISNULL(I.FREEZE,'') <> 'Y' AND CATEGORY = '" & Trim(CMB_CATEGORY.Text) & "'"
            End If
            vform.Field = " I.ITEMNAME,I.ITEMCODE"
            vform.vFormatstring = "    ITEMCODE    |                     ITEMNAME                    |  STOCKUOM  | PURCHASERATE | CONVUOM | HIGHRATIO |"
            vform.vCaption = "INVENTORY ITEM CODE HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.Keypos5 = 5
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
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
                ssgrid.TypeComboBoxString = Trim(vform.keyfield2)
                ssgrid.Text = Trim(vform.keyfield2)
                ssgrid.Col = 5
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Format(Val(vform.keyfield3), "0.00")
                ssgrid.Col = 9
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield4)
                ssgrid.Col = 10
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Format(Val(vform.keyfield5), "0.00")
                ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                ssgrid.Focus()
            Else
                ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : FillMenu" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillMenuItem()
        Try
            Dim vform As New List_Operation
            Dim K As Integer
            Dim ssql As String
            '''******************************************************** $ FILL THE ITEMDESC,ITEMCODE INTO SSGRID ********** 
            gSQLString = "SELECT DISTINCT ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.STOCKUOM,'') AS STOCKUOM,ISNULL(I.PURCHASERATE,0) AS PURCHASERATE, "
            gSQLString = gSQLString & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK  AS O ON O.ITEMCODE = I.ITEMCODE "
            If Trim(search) = " " Then
                M_WhereCondition = ""
            Else
                M_WhereCondition = " WHERE I.ITEMNAME LIKE '" & Trim(search) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'  AND CATEGORY = '" & Trim(CMB_CATEGORY.Text) & "'"
            End If
            vform.Field = "I.ITEMNAME,I.ITEMCODE"
            vform.vFormatstring = "                     ITEMNAME                |   ITEMCODE    | STOCKUOM  |PURCHASERATE | CONVUOM | HIGHRATIO |"
            vform.vCaption = "INVENTORY ITEM CODE HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.Keypos5 = 5
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
                ssgrid.TypeComboBoxString = Trim(vform.keyfield2)
                ssgrid.Text = Trim(vform.keyfield2)
                ssgrid.Col = 5
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Format(Val(vform.keyfield3), "0.00")
                ssgrid.Col = 9
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield4)
                ssgrid.Col = 10
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Format(Val(vform.keyfield5), "0.00")
                ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                ssgrid.Focus()
            Else
                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : FillMenuItem" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_Totalamt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Totalamt.LostFocus
        Try
            txt_Totalamt.Text = Format(Val(txt_Totalamt.Text), "0.00")
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Totalamt_LostFocus" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Discountamt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Discountamt.LostFocus
        Try
            If Val(txt_Discountamt.Text) <> 0 Then
                txt_Billamount.Text = Format(Val(txt_Totalamt.Text) + Val(txt_Vatamount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_Discountamt.Text), "0.00")
            End If
            txt_Discountamt.Text = Format(Val(txt_Discountamt.Text), "0.00")
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Discountamt_LostFocus" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    'Private Sub txt_Taxamt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    txt_Taxamt.Text = Format(Val(txt_Taxamt.Text), "0.00")
    'End Sub

    'Private Sub txt_Billamt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    txt_Billamt.Text = Format(Val(txt_Billamt.Text), "0.00")
    'End Sub

    Private Sub txt_Supplierinvno_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Supplierinvno.LostFocus
        Try
            Call supplerinvno()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Supplierinvno_LostFocus" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub supplerinvno()
        Try
            If Trim(txt_Supplierinvno.Text) = "" Then
                txt_Supplierinvno.Text = Trim(txt_Grnno.Text)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : supplerinvno" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillStore()
        Try
            Dim i As Integer
            sqlstring = "SELECT distinct(Storedesc) FROM StoreMaster ORDER BY Storedesc ASC"
            gconnection.getDataSet(sqlstring, "StoreMaster")
            cbo_Storelocation.Items.Clear()
            cbo_Storelocation.Sorted = True
            If gdataset.Tables("StoreMaster").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
                    cbo_Storelocation.Items.Add(gdataset.Tables("StoreMaster").Rows(i).Item("Storedesc"))
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : FillStore" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    'Private Sub txt_Totalamt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Totalamt.TextChanged
    '    Me.txt_Billamt.Text = Format(Val(Me.txt_Taxamt.Text) + Val(Me.txt_Totalamt.Text) - Val(Me.txt_Discountamt.Text), "0.00")
    'End Sub

    'Private Sub txt_Taxamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.txt_Billamt.Text = Format(Val(Me.txt_Taxamt.Text) + Val(Me.txt_Totalamt.Text) - Val(Me.txt_Discountamt.Text), "0.00")
    'End Sub

    'Private Sub txt_Discountamt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Discountamt.TextChanged
    '    Me.txt_Billamt.Text = Format(Val(Me.txt_Taxamt.Text) + Val(Me.txt_Totalamt.Text) - Val(Me.txt_Discountamt.Text), "0.00")
    'End Sub
    Public Function CreateListBox()
        Try
            Listbox = New System.Windows.Forms.ListBox
            Listbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Listbox.Location = New System.Drawing.Point(1000, 1000)
            Listbox.Name = "ListViewHelp"
            Listbox.Size = New System.Drawing.Size(10, 10)
            Listbox.TabIndex = 29
            Listbox.ScrollAlwaysVisible = False
            Listbox.HorizontalScrollbar = False
            Me.Controls.Add(Listbox)
            Listbox.BringToFront()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CreateListBox" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Public Function TextBoxKeydownevent(ByVal e As System.Windows.Forms.KeyEventArgs, ByVal ObjTextBox As TextBox)
        If e.KeyCode = Keys.Down Then
            Try
                Listbox.SelectedIndex = Listbox.SelectedIndex + 1
            Catch ex As Exception
                Listbox.SelectedIndex = 0
            End Try
        End If
        If e.KeyCode = Keys.Up Then
            Try
                Listbox.SelectedIndex = Listbox.SelectedIndex - 1
            Catch ex As Exception
                Listbox.SelectedIndex = Listbox.Items.Count - 1
            End Try
        End If
        If e.KeyCode = Keys.Enter Then
            ObjTextBox.Text = Listbox.SelectedItem()
            Listbox.Location = New System.Drawing.Point(1000, 1000)
        End If
        If e.KeyCode = Keys.Escape Then
            Listbox.Location = New System.Drawing.Point(1000, 1000)
            ObjTextBox.Focus()
        End If
    End Function
    Public Function TextBoxTextchangeevent(ByVal e As System.EventArgs, ByVal ObjTextBox As TextBox, ByVal Sqlstring As String, ByVal Tablename As String, ByVal ds As DataSet)
        Try
            gadapter = New SqlDataAdapter(Sqlstring, gconnection.Myconn)
            If ds.Tables.Contains(Tablename) = True Then
                ds.Tables.Remove(Tablename)
            End If
            gadapter.Fill(ds, Tablename)
            Call TextBoxHelp(ObjTextBox, Tablename, ds)
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Public Function TextBoxHelp(ByVal ObjTextBox As TextBox, ByVal Tablename As String, ByVal ds As DataSet)
        Dim drow As DataRow
            Listbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Listbox.Location = New System.Drawing.Point(ObjTextBox.Left, ObjTextBox.Top + ObjTextBox.Height)
            Listbox.Size = New System.Drawing.Size(ObjTextBox.Width, 100)
            Listbox.Items.Clear()
            If ds.Tables(Tablename).Rows.Count > 0 Then
                For Each drow In ds.Tables(Tablename).Rows
                    Listbox.Items.Add(drow.Item(1))
                Next
            End If
            Try
                Listbox.SelectedIndex = 0
            Catch ex As Exception
        End Try
    End Function

    Private Sub txt_Suppliername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Suppliername.TextChanged
        'If txt_Suppliername.Focus = True Then
        '    sqlstring = "SELECT SLCODE,SLNAME FROM accountssubledgermaster WHERE ACCODE = 'SCRS' AND SLNAME LIKE '" & Trim(txt_Suppliername.Text) & "%'"
        '    Call TextBoxTextchangeevent(e, txt_Suppliername, sqlstring, "MASTER", gdataset)
        'End If
    End Sub

    Private Sub txt_Suppliername_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Suppliername.KeyDown
        'If e.KeyCode = Keys.F4 Then
        '    Call cmd_Suppliercodehelp_Click(cmd_Suppliercodehelp, e)
        'Else
        '    Call TextBoxKeydownevent(e, txt_Suppliername)
        'End If
    End Sub

    Private Sub txt_Suppliername_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Suppliername.Validated
        Try
            If Trim(txt_Suppliername.Text) <> "" Then
                sqlstring = "SELECT SLCODE,SLNAME FROM accountssubledgermaster WHERE ACCODE = '" & Trim(gCreditors) & "'AND SLNAME='" & Trim(txt_Suppliername.Text) & "'"
                gconnection.getDataSet(sqlstring, "accountssubledgermaster")
                If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
                    txt_Suppliername.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("SLNAME"))
                    txt_Suppliercode.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("SLCODE"))
                    txt_Excisepassno.Focus()
                    txt_Suppliercode.ReadOnly = True
                Else
                    txt_Suppliercode.Text = ""
                    txt_Suppliercode.ReadOnly = False
                    txt_Suppliername.Focus()
                End If
            Else
                txt_Suppliercode.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Suppliername_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub Cmd_StockGrnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_StockGrnClear.Click
        Try
            Me.txt_FromDocno.Text = ""
            Me.txt_ToDocno.Text = ""
            Me.txt_FromDocno.ReadOnly = False
            Me.txt_FromDocno.ReadOnly = False
            Me.txt_FromDocno.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_StockGrnClear_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_StockGrnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_StockGrnView.Click
        Try
            Dim i As Integer
            Dim objGrncumpurchase As New rptGrncumpurchase
            gPrint = False
            If Trim(txt_FromDocno.Text) = "" Then
                MessageBox.Show("From Grn No. can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            ElseIf Trim(txt_ToDocno.Text) = "" Then
                MessageBox.Show("To Grn No. can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
            'Dim sqlstring = "SELECT ISNULL(G.GRNDETAILS,'') AS GRNDETAILS,G.GRNDATE, ISNULL(G.SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(G.SUPPLIERNAME,'') AS SUPPLIERNAME,"
            'sqlstring = sqlstring & " ISNULL(G.SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(G.EXCISEPASSNO,'') AS EXCISEPASSNO,ISNULL(G.GLACCOUNTCODE,'') AS GLACCOUNTCODE,ISNULL(G.GLACCOUNTNAME,'') AS GLACCOUNTNAME,"
            'sqlstring = sqlstring & " ISNULL(G.TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(G.SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(G.DISCOUNT,0) AS DISCOUNT,ISNULL(G.BILLAMOUNT,0) AS BILLAMOUNT,"
            'sqlstring = sqlstring & " ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM, ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE, "
            'sqlstring = sqlstring & " ISNULL(D.AMOUNT,0) AS AMOUNT FROM GRN_HEADER AS G INNER JOIN GRN_DETAILS AS D ON G.GRNDETAILS = D.GRNDETAILS"
            'sqlstring = sqlstring & " WHERE G.GRNDETAILS BETWEEN '" & Trim(txt_FromDocno.Text) & "' AND '" & Trim(txt_ToDocno.Text) & "'"
            'sqlstring = sqlstring & " ORDER BY G.GRNDETAILS,G.GRNDATE"
            'Dim heading() As String = {"GRN CUM PURCHASE BILL"}
            'objGrncumpurchase.ReportDetails(sqlstring, heading, Now, Now)
            sqlstring = " SELECT * FROM VIEWPURCHASEREGISTERSUMMARY "
            sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_FromDocno.Text) & "' AND '" & Trim(txt_ToDocno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMCODE  "
            'gconnection.getDataSet(sqlstring, "GRIDVIEW")
            'gridviewstatus = "Purchasereisterreport"
            'Dim griddesign As New GridDesign
            'griddesign.FormBorderStyle = FormBorderStyle.FixedDialog
            'griddesign.MdiParent = MDIParentobj
            'Me.Close()
            'griddesign.Show()
            Dim heading() As String = {"GRN CUM PURCHASE BILL"}
            Dim ObjStockPurchaseregisterReport As New rptStockPurchaseregister
            ObjStockPurchaseregisterReport.Reportdetails(sqlstring, heading, Now, Now)
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_StockGrnView_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_StockGrnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_StockGrnprint.Click
        Try
            gPrint = True
            'Call Cmd_StockGrnView_Click(sender, e)
            Dim i As Integer
            Dim objGrncumpurchase As New rptGrncumpurchase
            If Trim(txt_FromDocno.Text) = "" Then
                MessageBox.Show("From Grn No. can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            ElseIf Trim(txt_ToDocno.Text) = "" Then
                MessageBox.Show("To Grn No. can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
            'Dim sqlstring = "SELECT ISNULL(G.GRNDETAILS,'') AS GRNDETAILS,G.GRNDATE, ISNULL(G.SUPPLIERCODE,'') AS SUPPLIERCODE, ISNULL(G.SUPPLIERNAME,'') AS SUPPLIERNAME,"
            'sqlstring = sqlstring & " ISNULL(G.SUPPLIERINVNO,'') AS SUPPLIERINVNO,  ISNULL(G.EXCISEPASSNO,'') AS EXCISEPASSNO,ISNULL(G.GLACCOUNTCODE,'') AS GLACCOUNTCODE,ISNULL(G.GLACCOUNTNAME,'') AS GLACCOUNTNAME,"
            'sqlstring = sqlstring & " ISNULL(G.TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(VATAMOUNT,0) AS VATAMOUNT,ISNULL(G.SURCHARGEAMT,0) AS SURCHARGEAMT,ISNULL(G.DISCOUNT,0) AS DISCOUNT,ISNULL(G.BILLAMOUNT,0) AS BILLAMOUNT,"
            'sqlstring = sqlstring & " ISNULL(D.ITEMCODE,'') AS ITEMCODE, ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM, ISNULL(D.QTY,0) AS QTY, ISNULL(D.RATE,0) AS RATE, "
            'sqlstring = sqlstring & " ISNULL(D.AMOUNT,0) AS AMOUNT FROM GRN_HEADER AS G INNER JOIN GRN_DETAILS AS D ON G.GRNDETAILS = D.GRNDETAILS"
            'sqlstring = sqlstring & " WHERE G.GRNDETAILS BETWEEN '" & Trim(txt_FromDocno.Text) & "' AND '" & Trim(txt_ToDocno.Text) & "'"
            'sqlstring = sqlstring & " ORDER BY G.GRNDETAILS,G.GRNDATE"
            'Dim heading() As String = {"GRN CUM PURCHASE BILL"}
            'objGrncumpurchase.ReportDetails(sqlstring, heading, Now, Now)
            sqlstring = " SELECT * FROM VIEWPURCHASEREGISTERSUMMARY "
            sqlstring = sqlstring & " WHERE GRNDETAILS BETWEEN '" & Trim(txt_FromDocno.Text) & "' AND '" & Trim(txt_ToDocno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMCODE  "
            'gconnection.getDataSet(sqlstring, "GRIDVIEW")
            'gridviewstatus = "Purchasereisterreport"
            'Dim griddesign As New GridDesign
            'griddesign.FormBorderStyle = FormBorderStyle.FixedDialog
            'griddesign.MdiParent = MDIParentobj
            'Me.Close()
            'griddesign.Show()
            Dim heading() As String = {"GRN CUM PURCHASE BILL"}
            Dim ObjStockPurchaseregisterReport As New rptStockPurchaseregister
            ObjStockPurchaseregisterReport.Reportdetails(sqlstring, heading, Now, Now)
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_StockGrnprint_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_StockGrnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_StockGrnexit.Click
        Try
            txt_FromDocno.Text = ""
            txt_ToDocno.Text = ""
            grp_StockGrndetails.Top = 1000
            Cmd_Clear_Click(Cmd_Clear, e)
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_StockGrnexit_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_FromDocno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_FromDocno.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_FromDocno.Text) = "" Then
                    Call Cmd_FromDocno_Click(Cmd_FromDocno, e)
                Else
                    txt_FromDocno_Validated(txt_FromDocno, e)
                    txt_ToDocno.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_FromDocno_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_ToDocno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ToDocno.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_ToDocno.Text) = "" Then
                    Call Cmd_ToDocno_Click(Cmd_ToDocno, e)
                Else
                    txt_ToDocno_Validated(txt_ToDocno, e)
                    Cmd_StockGrnView.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_ToDocno_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_FromDocno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FromDocno.Click
        Try
            gSQLString = "SELECT GRNDETAILS,GRNDATE FROM Grn_header"
            M_WhereCondition = " "
            Dim vform As New List_Operation
            vform.Field = "GRNDETAILS,GRNDATE"
            vform.vFormatstring = "          GRN CODE              |         GRN DATE                             "
            vform.vCaption = "GRN CUM PURCHASE BILL HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_FromDocno.Text = Trim(vform.keyfield & "")
                txt_ToDocno.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_FromDocno_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_ToDocno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ToDocno.Click
        Try
            gSQLString = "SELECT GRNDETAILS,GRNDATE FROM Grn_header"
            M_WhereCondition = " "
            Dim vform As New List_Operation
            vform.Field = "GRNDETAILS,GRNDATE"
            vform.vFormatstring = "          GRN CODE              |         GRN DATE                             "
            vform.vCaption = "GRN CUM PURCHASE BILL HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_ToDocno.Text = Trim(vform.keyfield & "")
                Cmd_StockGrnView.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_ToDocno_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_GLAcHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_GLAcHelp.Click
        Try
            Dim vform As New List_Operation
            gSQLString = "SELECT accode,acdesc FROM accountsglaccountmaster"
            M_WhereCondition = ""
            vform.Field = "ACCODE,ACDESC"
            vform.vFormatstring = "  ACCODE                              |                      ACDESC                                "
            vform.vCaption = "GLACCOUNT MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_GLAcIn.Text = Trim(vform.keyfield & "")
                Txt_GLAcDesc.Text = Trim(vform.keyfield1 & "")
                Call Glaccountvalidate()
            Else
                Me.Txt_GLAcIn.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_GLAcHelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Glaccountvalidate()
        Try
            Dim sqlstring As String
            If Trim(Txt_GLAcIn.Text) <> "" Then
                sqlstring = "SELECT slcode,slname FROM accountssubledgermaster WHERE accode = '" & Trim(Txt_GLAcIn.Text) & "'"
                gconnection.getDataSet(sqlstring, "accountssubledgermaster")
                If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
                    Lbl_SubledgerCode.Visible = True
                    Lbl_SubledgerName.Visible = True
                    Txt_Slcode.Visible = True
                    Cmd_SlCodeHelp.Visible = True
                    Txt_SlDesc.Visible = True
                    slcodestatus = True
                    grp_grnposting.Top = 192
                    grp_grnposting.Height = 80
                    ssgrid.Left = 72
                    ssgrid.Top = 272
                    ssgrid.Height = 224
                    ssgrid.Focus()
                Else
                    Lbl_SubledgerCode.Visible = False
                    Lbl_SubledgerName.Visible = False
                    Txt_Slcode.Visible = False
                    Cmd_SlCodeHelp.Visible = False
                    Txt_SlDesc.Visible = False
                    slcodestatus = False
                    grp_grnposting.Top = 192
                    grp_grnposting.Height = 48
                    grp_grnposting.Width = 848
                    ssgrid.Top = 240
                    ssgrid.Left = 72
                    ssgrid.Height = 264
                    ssgrid.Focus()
                End If
                gdataset.Tables("accountssubledgermaster").Dispose()
                Call Costcentervalidate()
            Else
                Txt_GLAcIn.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Glaccountvalidate" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Costcentervalidate()
        Try
            Dim SQLSTRING As String
            Dim DR As DataRow
            Dim i As Integer
            If Trim(Txt_GLAcIn.Text) <> "" Then
                SQLSTRING = "SELECT PRIMARYGROUPCODE FROM ACCOUNTTAGGING WHERE GLACCODE = '" & Trim(Txt_GLAcIn.Text) & "'"
                gconnection.getDataSet(SQLSTRING, "MASTER1")
                If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                    Lbl_CostCenterCode.Visible = True
                    Lbl_CostCenterDesc.Visible = True
                    Txt_CostCenterCode.Visible = True
                    Txt_CostCenterDesc.Visible = True
                    Cmd_CostCenterCodeHelp.Visible = True
                    costcentercodestatus = True
                    grp_grnposting.Top = 192
                    grp_grnposting.Width = 848
                    grp_grnposting.Height = 120
                    ssgrid.Top = 312
                    ssgrid.Left = 72
                    ssgrid.Height = 240
                    lbl_Creditdays.Top = 280
                    lbl_Creditdays.Left = 504
                    txt_Creditdays.Top = 280
                    txt_Creditdays.Left = 672
                    Gr = Nothing
                    For Each DR In gdataset.Tables("MASTER1").Rows
                        If Trim(Gr) = "" Then
                            Gr = "'" & Trim(DR("PRIMARYGROUPCODE")) & "'"
                        Else
                            Gr = Gr & ",'" & Trim(DR("PRIMARYGROUPCODE")) & "'"
                        End If
                    Next
                Else
                    Lbl_CostCenterCode.Visible = False
                    Lbl_CostCenterDesc.Visible = False
                    Txt_CostCenterCode.Visible = False
                    Txt_CostCenterDesc.Visible = False
                    Cmd_CostCenterCodeHelp.Visible = False
                    costcentercodestatus = False
                    If slcodestatus = True Then
                        grp_grnposting.Top = 192
                        grp_grnposting.Height = 80
                        ssgrid.Left = 72
                        ssgrid.Top = 272
                        ssgrid.Height = 224
                        Txt_Slcode.Focus()
                    Else
                        grp_grnposting.Height = 48
                        grp_grnposting.Width = 848
                        ssgrid.Top = 240
                        ssgrid.Left = 72
                        ssgrid.Height = 264
                        ssgrid.Focus()
                    End If
                End If
            Else
                Txt_GLAcIn.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Costcentervalidate" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_GLAcIn_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_GLAcIn.Validated
        Try
            Dim sqlstring As String
            If Trim(Txt_GLAcIn.Text) <> "" Then
                sqlstring = "select accode, acdesc from accountsglaccountmaster where accode = '" & Trim(Txt_GLAcIn.Text) & "'"
                gconnection.getDataSet(sqlstring, "accountsglaccountmaster")
                If gdataset.Tables("accountsglaccountmaster").Rows.Count > 0 Then
                    Txt_GLAcDesc.Text = Trim(UCase(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("acdesc")))
                    If slcodestatus = True Then
                        Txt_Slcode.Focus()
                    Else
                        ssgrid.Focus()
                    End If
                Else
                    Txt_GLAcIn.Text = ""
                    Txt_GLAcDesc.Text = ""
                End If
                gdataset.Tables("accountsglaccountmaster").Dispose()
                Call Glaccountvalidate()
            Else
                Txt_GLAcIn.Text = ""
                Txt_GLAcIn.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Txt_GLAcIn_Validated " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_Slcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Slcode.Validated
        Try
            Dim sqlstring As String
            If Trim(Txt_Slcode.Text) <> "" Then
                sqlstring = "SELECT slcode, sldesc from accountssubledgermaster WHERE accode = '" & Trim(Txt_GLAcIn.Text) & "' and slcode = '" & Trim(Txt_Slcode.Text) & "'"
                gconnection.getDataSet(sqlstring, "accountssubledgermaster")
                If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
                    Txt_Slcode.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("slcode")))
                    Txt_SlDesc.Text = Trim(UCase(gdataset.Tables("accountssubledgermaster").Rows(0).Item("sldesc")))
                    If costcentercodestatus = True Then
                        Txt_CostCenterCode.Focus()
                    Else
                        ssgrid.Focus()
                    End If
                Else
                    Txt_Slcode.Text = ""
                    Txt_SlDesc.Text = ""
                End If
                gdataset.Tables("accountssubledgermaster").Dispose()
            Else
                Txt_Slcode.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Txt_Slcode_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_CostCenterCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_CostCenterCode.Validated
        Try
            Dim sqlstring As String
            If Trim(Txt_CostCenterCode.Text) = "" Then
                sqlstring = "SELECT COSTCENTERCODE,COSTCENTERDESC from accountscostcentermaster where COSTCENTERCODE = '" & Trim(Txt_CostCenterCode.Text) & "' And PRIMARYGROUPCODE IN (" & Gr & ")"
                gconnection.getDataSet(sqlstring, "accountscostcentermaster")
                If gdataset.Tables("accountscostcentermaster").Rows.Count > 0 Then
                    Txt_CostCenterDesc.Text = Trim(UCase(gdataset.Tables("accountscostcentermaster").Rows(0).Item("COSTCENTERDESC")))
                    Cmd_Add.Focus()
                Else
                    Txt_CostCenterDesc.Text = ""
                    Txt_CostCenterCode.Text = ""
                End If
                gdataset.Tables("accountscostcentermaster").Dispose()
            Else
                Txt_CostCenterCode.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Txt_CostCenterCode_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_CostCenterCodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CostCenterCodeHelp.Click
        Try
            Dim vform As New List_Operation
            gSQLString = "SELECT COSTCENTERCODE,COSTCENTERDESC FROM ACCOUNTSCOSTCENTERMASTER"
            M_WhereCondition = " WHERE PRIMARYGROUPCODE IN (" & Gr & ")"
            vform.Field = "COSTCENTERCODE"
            vform.Field = "COSTCENTERDESC"
            vform.vFormatstring = "  COSTCENTERCODE                   |                          COSTCENTERDESC                                "
            vform.vCaption = "COSTCENTER MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_CostCenterCode.Text = Trim(vform.keyfield & "")
                Txt_CostCenterDesc.Text = Trim(vform.keyfield1 & "")
                ssgrid.Focus()
            Else
                Me.Txt_Slcode.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_CostCenterCodeHelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_SlCodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_SlCodeHelp.Click
        Try
            Dim vform As New List_Operation
            gSQLString = "SELECT slcode,sldesc FROM accountssubledgermaster"
            M_WhereCondition = " WHERE accode = '" & Trim(Txt_GLAcIn.Text) & "'"
            vform.Field = "SLCODE"
            vform.Field = "SLDESC"
            vform.vFormatstring = "  SLCODE                             |                          SLDESC                                "
            vform.vCaption = "SUBLEDGER MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_Slcode.Text = Trim(vform.keyfield & "")
                Txt_SlDesc.Text = Trim(vform.keyfield1 & "")
            Else
                Me.Txt_GLAcIn.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Cmd_SlCodeHelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_GLAcIn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_GLAcIn.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                Call Cmd_GLAcHelp_Click(sender, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Txt_GLAcIn_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_Slcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Slcode.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                Call Cmd_SlCodeHelp_Click(sender, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Txt_Slcode_KeyDown" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_CostCenterCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_CostCenterCode.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                Call Cmd_CostCenterCodeHelp_Click(sender, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Txt_CostCenterCode_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_GLAcIn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_GLAcIn.KeyPress
        Try
            getAlphanumeric(e)
            If Asc(e.KeyChar) = 13 Then
                If Trim(Txt_GLAcIn.Text) = "" Then
                    Call Cmd_GLAcHelp_Click(Cmd_GLAcHelp, e)
                Else
                    Call Txt_GLAcIn_Validated(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Txt_GLAcIn_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_Slcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Slcode.KeyPress
        Try
            getAlphanumeric(e)
            If Asc(e.KeyChar) = 13 Then
                If Trim(Txt_Slcode.Text) = "" Then
                    Call Cmd_SlCodeHelp_Click(Cmd_SlCodeHelp, e)
                    ssgrid.Focus()
                Else
                    Call Txt_Slcode_Validated(Txt_Slcode, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Txt_Slcode_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_CostCenterCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CostCenterCode.KeyPress
        Try
            getAlphanumeric(e)
            If Asc(e.KeyChar) = 13 Then
                If Trim(Txt_Slcode.Text) = "" Then
                    Call Cmd_CostCenterCodeHelp_Click(Cmd_CostCenterCodeHelp, e)
                Else
                    Call Txt_CostCenterCode_Validated(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Txt_CostCenterCode_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Suppliercode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Suppliercode.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                Call cmd_Suppliercodehelp_Click(cmd_Suppliercodehelp, e)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Suppliercode_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Suppliercode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Suppliercode.Validated
        Try
            If Trim(txt_Suppliercode.Text) <> "" Then
                sqlstring = "SELECT SLCODE,SLNAME,creditperiod FROM accountssubledgermaster WHERE ACCODE = '" & Trim(gCreditors) & "'AND SLCODE='" & Trim(txt_Suppliercode.Text) & "'"
                gconnection.getDataSet(sqlstring, "accountssubledgermaster")
                If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
                    txt_Suppliername.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("SLNAME"))
                    txt_Suppliercode.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("SLCODE"))
                    txt_Creditdays.Text = Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("creditperiod"))
                    txt_Suppliername.ReadOnly = True
                    cbo_Billingterms.Focus()
                Else
                    txt_Suppliercode.Text = ""
                    txt_Suppliercode.Text = ""
                    txt_Suppliername.ReadOnly = False
                    txt_Suppliercode.Focus()
                End If
            Else
                txt_Suppliercode.Text = ""
                txt_Suppliername.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Suppliercode_Validated" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub dtp_Stockindate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Stockindate.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                txt_Excisepassno.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : dtp_Stockindate_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Trucknumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Trucknumber.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                grp_Excisedetails.Top = 1000
                txt_Suppliercode.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Trucknumber_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Trucknumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Trucknumber.LostFocus
        Try
            grp_Excisedetails.Top = 1000
            txt_Suppliercode.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Trucknumber_LostFocus " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub dtp_Supplierinvdate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtp_Supplierinvdate.LostFocus
        Try
            grp_Excisedetails.Top = 104
            grp_Excisedetails.Left = 216
            dtp_Stockindate.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : dtp_Supplierinvdate_LostFocus" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cbo_Billingterms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_Billingterms.KeyPress
        Try
            Call Blank(e)
            If Asc(e.KeyChar) = 13 Then
                'DISABLE GLACCOUNT
                Txt_GLAcIn.Focus()

                ssgrid.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cbo_Billingterms_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillBillterms()
        Try
            Dim i As Integer
            sqlstring = "SELECT DISTINCT ISNULL(TYPECODE,'') AS TYPECODE,ISNULL(TYPEDESC,'') AS TYPEDESC  FROM PURCHASEBILLTERMS WHERE  ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "PURCHASEBILLTERMS")
            If gdataset.Tables("PURCHASEBILLTERMS").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("PURCHASEBILLTERMS").Rows.Count - 1 Step 1
                    cbo_Billingterms.Text = Trim(gdataset.Tables("PURCHASEBILLTERMS").Rows(i).Item("Typecode")) & "  " & Trim(UCase(gdataset.Tables("PURCHASEBILLTERMS").Rows(i).Item("Typedesc")))
                Next i
            Else
                cbo_Billingterms.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : FillBillterms " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub billingterms()
        Try
            Dim per As Double
            Call FillBillterms()
            Call Fillbilldetails()
            grp_Billingdetails.Top = 144
            grp_Billingdetails.Left = 160
            ssgrid_billdetails.Col = 4
            ssgrid_billdetails.Row = 1
            ssgrid_billdetails.Text = Format(Val(txt_Totalamt.Text), "0.00")
            ssgrid_billdetails.Focus()
            ssgrid_billdetails.SetActiveCell(2, 2)
            ssgrid_billdetails.Col = 4
            ssgrid_billdetails.Row = 2
            ssgrid_billdetails.Text = Format(Val(txt_Discountamt.Text), "0.00")
            per = (Val(txt_Discountamt.Text) * 100) / Val(txt_Totalamt.Text)
            ssgrid_billdetails.Col = 2
            ssgrid_billdetails.Row = 2
            ssgrid_billdetails.Text = per
            ssgrid_billdetails.Col = 4
            ssgrid_billdetails.Row = billrow
            ssgrid_billdetails.Text = Format(Val(txt_Totalamt.Text), "0.00")
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : billingterms" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_Remarks_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Remarks.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                Call billingterms()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Remarks_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Fillbilldetails()
        Try
            Dim i, j As Integer
            Dim typecode() As String
            typecode = Split(Trim(cbo_Billingterms.Text), "  ")
            sqlstring = "SELECT ISNuLL(Billdescription,'') As Billdescription,ISNULL(slno,0) AS SLNO,FORMULA,SIGNS,ISNULL(Accode,'') AS ACCODE ,ISNULL(Acdesc,'') AS ACDESC FROM purchasebillterms WHERE  Typecode = '" & Trim(typecode(0)) & "' AND ISNULL(Freeze,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "purchasebillterms")
            j = 2
            If gdataset.Tables("purchasebillterms").Rows.Count > 0 Then
                ssgrid_billdetails.SetText(1, 1, "BASIC" & "  " & ":")
                ssgrid_billdetails.Col = 1
                ssgrid_billdetails.Row = 1
                ssgrid_billdetails.Lock = True
                ssgrid_billdetails.Col = 2
                ssgrid_billdetails.Row = 1
                ssgrid_billdetails.Lock = True
                ssgrid_billdetails.Col = 3
                ssgrid_billdetails.Row = 1
                ssgrid_billdetails.Lock = True
                For i = 0 To gdataset.Tables("purchasebillterms").Rows.Count - 1 Step 1
                    ssgrid_billdetails.SetText(1, j, Trim(gdataset.Tables("purchasebillterms").Rows(i).Item("Billdescription")) & "  " & ":")
                    ssgrid_billdetails.SetText(5, j, Trim(gdataset.Tables("purchasebillterms").Rows(i).Item("SLNO")))
                    ssgrid_billdetails.SetText(6, j, Trim(gdataset.Tables("purchasebillterms").Rows(i).Item("FORMULA")))
                    ssgrid_billdetails.SetText(7, j, Trim(gdataset.Tables("purchasebillterms").Rows(i).Item("SIGNS")))
                    ssgrid_billdetails.SetText(8, j, Trim(gdataset.Tables("purchasebillterms").Rows(i).Item("ACCODE")))
                    ssgrid_billdetails.SetText(9, j, Trim(gdataset.Tables("purchasebillterms").Rows(i).Item("ACDESC")))
                    j = j + 1
                Next i
                ssgrid_billdetails.SetText(1, j, "BILL AMOUNT" & "  " & ":")
                billrow = j
                ssgrid_billdetails.Col = 1
                ssgrid_billdetails.Row = j
                ssgrid_billdetails.Lock = True
                ssgrid_billdetails.Col = 2
                ssgrid_billdetails.Row = j
                ssgrid_billdetails.Lock = True
                ssgrid_billdetails.Col = 3
                ssgrid_billdetails.Row = j
                ssgrid_billdetails.Lock = True
                ssgrid_billdetails.SetActiveCell(2, 2)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Fillbilldetails " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub billingtermsrefresh(ByVal Activerow As Integer)
        Try
            Dim Totalamount, Taxamount, Calamount, Caltax, CalBilamount, BillAmount, Batchno, Avgrate, Avgquantity As Double
            Dim dblBasic, dblDiscount, dblExcise, dblVAT, dblSurchase, dblTranportation, dblOthpostcharge, dblOthNegcharge As Double
            Dim Sign, Formula, slno As String
            Dim Formule() As Char
            Dim II, J As Integer
            Dim Camt, amt, Bamt, Gramt, GrTot, Gtot As Double
            Dim per As Double

            ssgrid_billdetails.Row = 1
            ssgrid_billdetails.Col = 4
            amt = Val(ssgrid_billdetails.Text)

            ssgrid_billdetails.Col = 4
            ssgrid_billdetails.Row = ssgrid_billdetails.DataRowCnt
            ssgrid_billdetails.Text = amt

            dblBasic = Format(Val(ssgrid_billdetails.Text), "0.00")

            For i = 2 To ssgrid_billdetails.DataRowCnt - 1
                ssgrid_billdetails.Row = i
                ssgrid_billdetails.Col = 7
                Sign = ssgrid_billdetails.Text

                ssgrid_billdetails.Col = 4
                Gramt = Val(ssgrid_billdetails.Text)

                If Sign = "+" Then
                    ssgrid_billdetails.Col = 4
                    ssgrid_billdetails.Row = ssgrid_billdetails.DataRowCnt
                    ssgrid_billdetails.Text = Format(Val(ssgrid_billdetails.Text) + Val(Gramt), "0.00")
                End If

                If Sign = "-" Then
                    ssgrid_billdetails.Col = 4
                    ssgrid_billdetails.Row = ssgrid_billdetails.DataRowCnt
                    Bamt = ssgrid_billdetails.Text
                    ssgrid_billdetails.Text = Format(Val(ssgrid_billdetails.Text) - Val(Gramt), "0.00")
                End If

                ssgrid_billdetails.Row = i
                ssgrid_billdetails.Col = 1
                If Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "BAS" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblBasic = dblBasic + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "DIS" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblDiscount = dblDiscount + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "EXC" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblExcise = dblExcise + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "V.A" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblVAT = dblVAT + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "SUR" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblSurchase = dblSurchase + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "TRA" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblTranportation = dblTranportation + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 12, 6) = "ES (+)" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblOthpostcharge = dblOthpostcharge + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 12, 6) = "ES (-)" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        dblOthNegcharge = dblOthNegcharge + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                ElseIf Mid(Trim(CStr(ssgrid_billdetails.Text)), 1, 3) = "BIL" Then
                    ssgrid_billdetails.Col = 4
                    If Val(ssgrid_billdetails.Text) > 0 Then
                        BillAmount = BillAmount + Format(Val(ssgrid_billdetails.Text), "0.00")
                    End If
                End If
            Next i

            ssgrid_billdetails.Col = 4
            ssgrid_billdetails.Row = ssgrid_billdetails.DataRowCnt
            BillAmount = Format(Val(ssgrid_billdetails.Text), "0.00")

            txt_Totalamt.Text = Format(dblBasic, "0.00")
            txt_Vatamount.Text = Format(dblVAT + dblExcise, "0.00")
            txt_Surchargeamt.Text = Format(dblSurchase + dblOthpostcharge + dblTranportation, "0.00")
            txt_Discountamt.Text = Format(dblDiscount + dblOthNegcharge, "0.00")
            txt_Billamount.Text = Format(BillAmount, "0.00")
            ssgrid_billdetails.Row = Activerow
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : billingtermsrefresh " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub billingtermstaxamount(ByVal Activerow)
        'new
        Try
            Dim Sign, Formula, slno As String
            Dim Formule() As Char
            Dim II, J As Integer
            Dim Camt, amt, Bamt, Gramt, GrTot, Gtot As Double
            Dim per As Double

            ssgrid_billdetails.Row = 1
            ssgrid_billdetails.Col = 4
            amt = Val(ssgrid_billdetails.Text)

            ssgrid_billdetails.Row = Activerow
            ssgrid_billdetails.Col = 2
            per = Val(ssgrid_billdetails.Text)
            ssgrid_billdetails.Col = 7
            Sign = ssgrid_billdetails.Text

            ssgrid_billdetails.Col = 6
            Formula = ssgrid_billdetails.Text
            Formule = Formula.ToCharArray

            Gtot = 0
            ssgrid_billdetails.Row = Activerow
            ssgrid_billdetails.Col = 2
            per = Val(ssgrid_billdetails.Text)

            For II = 1 To Formule.Length - 1
                For J = 2 To ssgrid_billdetails.DataRowCnt
                    ssgrid_billdetails.Col = 5
                    ssgrid_billdetails.Row = J
                    If Trim(Formule(II)) = Trim(ssgrid_billdetails.Text) Then
                        ssgrid_billdetails.Col = 4
                        Gtot = Gtot + Val(ssgrid_billdetails.Text)
                        Exit For
                    End If
                Next J
            Next II
            Camt = ((Gtot + amt) * per) / 100
            ssgrid_billdetails.Col = 4
            ssgrid_billdetails.Row = Activerow
            If Camt > 0 Then
                ssgrid_billdetails.Text = Format(Val(Camt), "0.00")
            Else
                ssgrid_billdetails.Text = 0.0
            End If
            Call billingtermsrefresh(Activerow)
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : billingtermstaxamount" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        'end new
    End Sub
    Private Sub BillingTermsTaxPercentage(ByVal Activerow)
        'new
        Try
            Dim Sign, Formula, slno, Billdesc() As String
            Dim Formule() As Char
            Dim II, J As Integer
            Dim Camt, amt, Bamt, Gramt, GrTot, Gtot As Double
            Dim per As Double


            ssgrid_billdetails.Row = 1
            ssgrid_billdetails.Col = 4
            amt = Val(ssgrid_billdetails.Text)

            ssgrid_billdetails.Col = 4
            ssgrid_billdetails.Row = billrow
            ssgrid_billdetails.Text = Format(amt, "0.00")

            ssgrid_billdetails.Row = Activerow
            ssgrid_billdetails.Col = 2
            per = ssgrid_billdetails.Text
            ssgrid_billdetails.Col = 7
            Sign = ssgrid_billdetails.Text

            ssgrid_billdetails.Col = 6
            Formula = ssgrid_billdetails.Text
            Formule = Formula.ToCharArray

            Gtot = 0
            For II = 1 To Formule.Length - 1
                For J = 2 To ssgrid_billdetails.DataRowCnt
                    ssgrid_billdetails.Col = 5
                    ssgrid_billdetails.Row = J
                    If Trim(Formule(II)) = Trim(ssgrid_billdetails.Text) Then
                        ssgrid_billdetails.Col = 4
                        Gtot = Gtot + Val(ssgrid_billdetails.Text)
                        Exit For
                    End If
                Next J
            Next II


            ssgrid_billdetails.Col = 1
            ssgrid_billdetails.Row = Activerow
            Billdesc = Split(Trim(ssgrid_billdetails.Text), ":")

            sqlstring = "SELECT Tax FROM purchasebillterms WHERE Billdescription = '" & Trim(Billdesc(0)) & "'AND ISNULL(FREEZE,'N') <> 'Y' "
            gconnection.getDataSet(sqlstring, "purchasebillterms")
            If gdataset.Tables("purchasebillterms").Rows.Count > 0 Then
                If gdataset.Tables("purchasebillterms").Rows(0).Item("Tax") & "" <> "Y" Then
                    GrTot = Gtot + amt
                    ssgrid_billdetails.Row = Activerow
                    ssgrid_billdetails.Col = 2
                    If Gtot > 0 Then
                        ssgrid_billdetails.Col = 4
                        Gtot = Val(ssgrid_billdetails.Text)
                        ssgrid_billdetails.Col = 2
                        ssgrid_billdetails.Text = Format((Gtot / amt) * 100, "0.00")
                    Else
                        If GrTot > 0 Then
                            ssgrid_billdetails.Col = 4
                            Gtot = Val(ssgrid_billdetails.Text)
                            ssgrid_billdetails.Col = 2
                            ssgrid_billdetails.Text = Format((Gtot / amt) * 100, "0.00")
                        Else
                            ssgrid_billdetails.Text = 0.0
                        End If
                    End If
                    Call billingtermsrefresh(Activerow)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : BillingTermsTaxPercentage" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub ssgrid_billdetails_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid_billdetails.KeyDownEvent
        Try
            Dim Taxcode, Billdesc(), Sqlstring As String

            Dim Sign, Formula, slno As String
            Dim Formule() As Char
            Dim II, J As Integer
            Dim Camt, amt, Bamt, Gramt, GrTot, Gtot As Double
            Dim per As Double
            If e.keyCode = Keys.Enter Or e.keyCode = Keys.Tab Then
                If ssgrid_billdetails.ActiveCol = 1 Then
                    ssgrid_billdetails.Col = 1
                    ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                    If Trim(ssgrid_billdetails.Text) <> "" Then
                        ssgrid_billdetails.SetActiveCell(1, ssgrid_billdetails.ActiveRow)
                    End If
                ElseIf ssgrid_billdetails.ActiveCol = 2 Then
                    ssgrid_billdetails.Col = 1
                    ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                    Billdesc = Split(Trim(ssgrid_billdetails.Text), ":")

                    Sqlstring = "SELECT Tax FROM purchasebillterms WHERE Billdescription = '" & Trim(Billdesc(0)) & "'AND ISNULL(FREEZE,'N') <> 'Y' "
                    gconnection.getDataSet(Sqlstring, "purchasebillterms")
                    If gdataset.Tables("purchasebillterms").Rows.Count > 0 Then
                        If gdataset.Tables("purchasebillterms").Rows(0).Item("Tax") & "" = "Y" Then
                            ssgrid_billdetails.Col = 2
                            ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                            ssgrid_billdetails.Lock = True
                            ssgrid_billdetails.Text = "0.00"
                            ssgrid_billdetails.Col = 3
                            ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                            ssgrid_billdetails.Text = ""
                            ssgrid_billdetails.Lock = False
                            ssgrid_billdetails.SetActiveCell(2, ssgrid_billdetails.ActiveRow)
                        Else
                            ssgrid_billdetails.Col = 2
                            ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                            If Val(ssgrid_billdetails.Text) = 0 Then
                                ssgrid_billdetails.Text = "0.00"
                                ssgrid_billdetails.Col = 4
                                ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                                ssgrid_billdetails.Text = "0.00"
                                ssgrid_billdetails.Lock = False
                                ssgrid_billdetails.SetActiveCell(3, ssgrid_billdetails.ActiveRow)
                            Else
                                ssgrid_billdetails.Col = 4
                                ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                                Call billingtermsrefresh(ssgrid_billdetails.ActiveRow)
                                ssgrid_billdetails.Lock = False
                                ssgrid_billdetails.SetActiveCell(3, ssgrid_billdetails.ActiveRow)
                            End If
                        End If
                        Call billingtermstaxamount(ssgrid_billdetails.ActiveRow)
                    End If
                ElseIf ssgrid_billdetails.ActiveCol = 3 Then
                    ssgrid_billdetails.Col = 1
                    ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                    Billdesc = Split(Trim(ssgrid_billdetails.Text), ":")
                    Sqlstring = "SELECT Tax FROM purchasebillterms WHERE Billdescription = '" & Trim(Billdesc(0)) & "'AND ISNULL(FREEZE,'N') <> 'Y' "
                    gconnection.getDataSet(Sqlstring, "purchasebillterms")
                    If gdataset.Tables("purchasebillterms").Rows.Count > 0 Then
                        If gdataset.Tables("purchasebillterms").Rows(0).Item("Tax") & "" = "Y" Then
                            ssgrid_billdetails.Col = 3
                            ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                            If Trim(ssgrid_billdetails.Text) = "" Then
                                Call FillTaxmaster() '''---> Show Taxcode,Taxpercentage 
                                Exit Sub
                            Else
                                Taxcode = Trim(ssgrid.Text)
                                Sqlstring = "SELECT Taxcode,Taxdesc,Taxpercentage,Typeoftax,GLACCOUNTIN,GLACCOUNTDESC  FROM AccountsTaxMaster WHERE Taxcode = '" & Trim(Taxcode) & "'AND ISNULL(FREEZEFLAG,'N') <> 'Y' "
                                gconnection.getDataSet(Sqlstring, "AccountsTaxMaster")
                                If gdataset.Tables("AccountsTaxMaster").Rows.Count = 0 Then
                                    Sqlstring = "SELECT Taxcode,Taxdesc,Taxpercentage,Typeoftax,GLACCOUNTIN,GLACCOUNTDESC  FROM AccountsTaxMaster WHERE Taxcode = '" & Trim(Taxcode) & "'AND ISNULL(FREEZEFLAG,'N') <> 'Y' "
                                    gconnection.getDataSet(Sqlstring, "AccountsTaxMaster")
                                End If
                                If gdataset.Tables("AccountsTaxMaster").Rows.Count > 0 Then
                                    ssgrid_billdetails.Col = 2
                                    ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                                    ssgrid_billdetails.Text = Trim(gdataset.Tables("AccountsTaxMaster").Rows(0).Item("Taxpercentage") & "")
                                    ssgrid_billdetails.Col = 3
                                    ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                                    ssgrid_billdetails.Text = Trim(gdataset.Tables("AccountsTaxMaster").Rows(0).Item("Taxcode") & "")
                                    ssgrid_billdetails.Col = 8
                                    ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                                    ssgrid_billdetails.Text = Trim(gdataset.Tables("AccountsTaxMaster").Rows(0).Item("GLACCOUNTIN") & "")
                                    ssgrid_billdetails.Col = 9
                                    ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                                    ssgrid_billdetails.Text = Trim(gdataset.Tables("AccountsTaxMaster").Rows(0).Item("GLACCOUNTDESC") & "")
                                    gdataset.Tables("AccountsTaxMaster").Dispose()
                                Else
                                    Call FillTaxmaster() '''---> Show Taxcode,Taxpercentage 
                                End If
                            End If
                        End If
                        Call billingtermstaxamount(ssgrid_billdetails.ActiveRow)
                    End If
                ElseIf ssgrid_billdetails.ActiveCol = 4 Then
                    ssgrid_billdetails.Col = 4
                    ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                    Call BillingTermsTaxPercentage(ssgrid_billdetails.ActiveRow)
                    ssgrid_billdetails.SetActiveCell(1, ssgrid_billdetails.ActiveRow + 1)
                End If
            End If

            If e.keyCode = Keys.F4 Then
                If ssgrid_billdetails.ActiveCol = 3 Then
                    If ssgrid_billdetails.Lock = False Then
                        search = Nothing
                        ssgrid.GetText(2, ssgrid.ActiveRow, search)
                        Dim vform As New List_Operation
                        gSQLString = "SELECT Taxcode,Taxdesc,Taxpercentage,Typeoftax,GLACCOUNTIN,GLACCOUNTDESC  FROM AccountsTaxMaster"
                        M_WhereCondition = " WHERE  ISNULL(FREEZEFLAG,'N') <> 'Y'"
                        vform.Field = "TAXCODE,TAXDESC"
                        vform.vFormatstring = "           TAXCODE            |                  TAX DESCRIPTION         |       TAXPERCENTAGE       |   TYPE OF TAX  | GLACCOUNTIN  |  GLACCOUNTDESC  "
                        vform.vCaption = "TAX MASTER HELP"
                        vform.KeyPos = 0
                        vform.KeyPos1 = 1
                        vform.KeyPos2 = 2
                        vform.Keypos3 = 3
                        vform.keypos4 = 4
                        vform.Keypos5 = 5
                        vform.ShowDialog(Me)
                        If Trim(vform.keyfield & "") <> "" Then
                            ssgrid_billdetails.SetText(3, ssgrid_billdetails.ActiveRow, Trim(vform.keyfield & ""))
                            ssgrid_billdetails.SetText(2, ssgrid_billdetails.ActiveRow, Val(vform.keyfield2))
                            ssgrid_billdetails.SetText(8, ssgrid_billdetails.ActiveRow, Trim(vform.keyfield4))
                            ssgrid_billdetails.SetText(9, ssgrid_billdetails.ActiveRow, Trim(vform.keyfield5))
                            Call billingtermsrefresh(ssgrid_billdetails.ActiveRow)
                            ssgrid_billdetails.SetActiveCell(3, ssgrid_billdetails.ActiveRow)
                            Taxcode = Trim(vform.keyfield & "")
                        Else
                            ssgrid_billdetails.SetActiveCell(ssgrid_billdetails.ActiveCol, ssgrid_billdetails.ActiveRow)
                            ssgrid_billdetails.SetText(ssgrid_billdetails.ActiveCol, ssgrid_billdetails.ActiveRow, "")
                            Taxcode = ""
                        End If
                        vform.Close()
                        vform = Nothing
                        Call BillingTermsTaxPercentage(ssgrid_billdetails.ActiveRow)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : ssgrid_billdetails_KeyDownEvent " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillTaxmaster()
        Try
            Dim ACHEAD As String
            search = Nothing
            ssgrid.GetText(2, ssgrid.ActiveRow, search)
            Dim vform As New List_Operation
            gSQLString = "SELECT Taxcode,Taxdesc,Taxpercentage,Typeoftax,GLACCOUNTIN,GLACCOUNTDESC  FROM AccountsTaxMaster"
            M_WhereCondition = " WHERE  ISNULL(FREEZEFLAG,'N') <> 'Y'"
            vform.Field = "TAXCODE,TAXDESC"
            vform.vFormatstring = "           TAXCODE       |             TAX DESCRIPTION         |    TAXPERCENTAGE       |   TYPE OF TAX  | GLACCOUNTIN  |  GLACCOUNTDESC  "
            vform.vCaption = "TAX MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.Keypos5 = 5
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                ssgrid_billdetails.SetText(3, ssgrid_billdetails.ActiveRow, Trim(vform.keyfield & ""))
                ssgrid_billdetails.SetText(2, ssgrid_billdetails.ActiveRow, Val(vform.keyfield2))
                ssgrid_billdetails.SetText(8, ssgrid_billdetails.ActiveRow, Trim(vform.keyfield4))
                ssgrid_billdetails.SetText(9, ssgrid_billdetails.ActiveRow, Trim(vform.keyfield5))
                Call billingtermsrefresh(ssgrid_billdetails.ActiveRow)
                ssgrid_billdetails.SetActiveCell(3, ssgrid_billdetails.ActiveRow)
                ACHEAD = Trim(vform.keyfield & "")
            Else
                ssgrid_billdetails.SetActiveCell(ssgrid_billdetails.ActiveCol, ssgrid_billdetails.ActiveRow)
                ssgrid_billdetails.SetText(ssgrid_billdetails.ActiveCol, ssgrid_billdetails.ActiveRow, "")
                ssgrid_billdetails.SetActiveCell(2, ssgrid_billdetails.ActiveRow)
                ACHEAD = ""
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : FillTaxmaster " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub ssgrid_billdetails_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid_billdetails.LeaveCell
        Try
            Dim Taxcode, Billdesc(), Sqlstring As String
            Dim Sign, Formula, slno As String
            Dim Formule() As Char
            Dim II, J As Integer
            Dim Camt, amt, Bamt, Gramt, GrTot, Gtot As Double
            Dim per As Double
            If ssgrid_billdetails.ActiveCol = 1 Then
                ssgrid_billdetails.Col = 1
                ssgrid_billdetails.Row = ssgrid_billdetails.ActiveRow
                If Trim(ssgrid_billdetails.Text) <> "" Then
                    ssgrid_billdetails.SetActiveCell(2, ssgrid_billdetails.ActiveRow)
                Else
                    ssgrid_billdetails.SetActiveCell(2, ssgrid_billdetails.ActiveRow)
                End If
            ElseIf ssgrid_billdetails.ActiveCol = 2 Then
                Call billingtermstaxamount(ssgrid_billdetails.ActiveRow)
            ElseIf ssgrid_billdetails.ActiveCol = 3 Then
                Call billingtermsrefresh(ssgrid_billdetails.ActiveRow)
            ElseIf ssgrid_billdetails.ActiveCol >= 4 Then
                Call BillingTermsTaxPercentage(ssgrid_billdetails.ActiveRow)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : ssgrid_billdetails_LeaveCell " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub GridLock()
        Try
            Dim Row, Col As Integer
            ssgrid.Col = 6
            ssgrid.Row = ssgrid.ActiveRow
            For Row = 1 To 50
                For Col = 1 To 6
                    ssgrid.Row = Row
                    ssgrid.Col = Col
                    ssgrid.Lock = True
                Next
            Next
            ssgrid.Row = 1
            For Col = 1 To 6
                ssgrid.Col = Col
                ssgrid.Lock = False
            Next
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GridLock " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub GridUnLock()
        Try
            Dim i, j As Integer
            For i = 1 To 100
                For j = 1 To 6
                    ssgrid.Col = j
                    ssgrid.Row = i
                    ssgrid.Lock = False
                Next j
            Next i
        Catch ex As Exception
            MessageBox.Show("Plz Check Error :  GridUnLock" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        Dim ItemQty, ItemAmount, ItemRate, Highratio, Dblamount As Double
        Dim sqlstring, Itemcode, Itemdesc As String
        Dim focusbool As Boolean
        Dim VaritemDesc As String
        Dim i, j, K As Integer
        search = Nothing
        Try
            If e.keyCode = Keys.Enter Then
                i = ssgrid.ActiveRow
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.Col = 2
                    ssgrid.Row = 1
                    VaritemDesc = Trim(ssgrid.Text)
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            Call FillMenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        ElseIf Trim(ssgrid.Text) <> "" Then
                            If VaritemDesc = "" Then
                                Itemcode = Trim(ssgrid.Text)
                                ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                sqlstring = " SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,ISNULL(I.PURCHASERATE,0) AS PURCHASERATE, "
                                sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK  AS O ON O.ITEMCODE = I.ITEMCODE "
                                sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'  AND CATEGORY = '" & Trim(CMB_CATEGORY.Text) & "' AND STORECODE='MNS' "
                                gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
                                If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                                    ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                    'For K = 1 To ssgrid.DataRowCnt
                                    '    ssgrid.Row = K
                                    '    ssgrid.Col = 1
                                    '    If Itemvalidate(ssgrid, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")), 1) = True Then
                                    '        ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                    '        ssgrid.Focus()
                                    '        Exit Sub
                                    '    End If
                                    'Next
                                    ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMNAME")))
                                    ssgrid.Col = 3
                                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM"))
                                    ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM"))
                                    ssgrid.SetText(5, i, Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("PURCHASERATE")), "0.00"))
                                    ssgrid.SetText(9, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("CONVUOM")))
                                    ssgrid.SetText(10, i, Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("HIGHRATIO")), "0.00"))
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
                        End If
                    Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    End If
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.Col = 2
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            ssgrid.Col = 4
                            ssgrid.Row = i
                            If Trim(ssgrid.Text) = "" Then
                                Itemdesc = Trim(ssgrid.Text)
                                ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC  $ **************************************'''
                                sqlstring = " SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,ISNULL(I.PURCHASERATE,0) AS PURCHASERATE, "
                                sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK  AS O ON O.ITEMCODE = I.ITEMCODE "
                                sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'  AND CATEGORY = '" & Trim(CMB_CATEGORY.Text) & "'"
                                gconnection.getDataSet(sqlstring, "inventoryitemMaster")
                                If gdataset.Tables("inventoryitemMaster").Rows.Count > 0 Then
                                    ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                    'For K = 1 To ssgrid.DataRowCnt
                                    '    ssgrid.Row = K
                                    '    ssgrid.Col = 1
                                    '    If Itemvalidate(ssgrid, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")), 1) = True Then
                                    '        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                    '        ssgrid.Focus()
                                    '        Exit Sub
                                    '    End If
                                    'Next
                                    ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMNAME")))
                                    ssgrid.Col = 3
                                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM"))
                                    ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM"))
                                    ssgrid.SetText(5, i, Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("PURCHASERATE")), "0.00"))
                                    ssgrid.SetText(9, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("CONVUOM")))
                                    ssgrid.SetText(10, i, Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("HIGHRATIO")), "0.00"))
                                    ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                Else
                                    MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                    ssgrid.Text = ""
                                    ssgrid.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 3 Then
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 4 Then
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                        Else
                            Call Calculate() '''--> Calculate total amount
                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                            ssgrid.Focus()
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 5 Then
                    ssgrid.Col = 5
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                        Else
                            Call Calculate() '''--> Calculate total amount
                            ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                            ssgrid.Focus()
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 6 Then
                    ssgrid.Col = 6
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            Call Calculate() '''--> Calculate total amount
                            ssgrid.Col = 6
                            ssgrid.Row = ssgrid.ActiveRow
                            ssgrid.Text = "0.00"
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
                ElseIf ssgrid.ActiveCol = 7 Then
                    ssgrid.Col = 7
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
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(8, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 10 Then
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(9, ssgrid.ActiveRow)
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
                ssgrid.Row = i
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.ClearRange(1, ssgrid.ActiveRow, 15, ssgrid.ActiveRow, True)
                ssgrid.DeleteRows(ssgrid.ActiveRow, 1)
                Call Calculate()
                ssgrid.Row = ssgrid.ActiveRow
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
                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : ssgrid_KeyDownEvent " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub ssgrid_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid.LeaveCell
        Dim ItemQty, ItemAmount, ItemRate, Highratio, Dblamount, DblQty As Double
        Dim sqlstring, Itemcode, Itemdesc As String
        Dim discount, quantity As Double
        Dim focusbool As Boolean
        Dim i, j As Integer
        Dim vitemdesc As String
        search = Nothing
        Try
            i = ssgrid.ActiveRow
            If ssgrid.ActiveCol = 2 Then
                ssgrid.Col = 2
                ssgrid.Row = i
                vitemdesc = Trim(ssgrid.Text)
                ssgrid.Col = 4
                ssgrid.Row = i
                DblQty = Val(ssgrid.Text)
                ssgrid.Col = 2
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Trim(ssgrid.Text) <> "" Then
                        If vitemdesc = "" Then
                            If Val(DblQty) = 0 Then
                                Itemdesc = Trim(ssgrid.Text)
                                ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC  $ **************************************'''
                                sqlstring = " SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM,ISNULL(I.PURCHASERATE,0) AS PURCHASERATE, "
                                sqlstring = sqlstring & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK  AS O ON O.ITEMCODE = I.ITEMCODE "
                                sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'"
                                gconnection.getDataSet(sqlstring, "inventoryitemMaster")
                                If gdataset.Tables("inventoryitemMaster").Rows.Count > 0 Then
                                    ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMCODE")))
                                    ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("ITEMNAME")))
                                    ssgrid.SetText(3, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("STOCKUOM")))
                                    ssgrid.SetText(5, i, Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("PURCHASERATE")), "0.00"))
                                    ssgrid.SetText(9, i, Trim(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("CONVUOM")))
                                    ssgrid.SetText(10, i, Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(j).Item("HIGHRATIO")), "0.00"))
                                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                Else
                                    MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                    ssgrid.Text = ""
                                    ssgrid.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf ssgrid.ActiveCol = 3 Then
                ssgrid.Col = 3
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Trim(ssgrid.Text) = "" Then
                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                    Else
                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                    End If
                End If
            ElseIf ssgrid.ActiveCol = 4 Then
                ssgrid.Col = 4
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Val(ssgrid.Text) = 0 Then
                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                    Else
                        Call Calculate() '''--> Calculate total amount
                        ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                    End If
                End If
            ElseIf ssgrid.ActiveCol = 6 Then
                ssgrid.Col = 6
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Val(ssgrid.Text) = 0 Then
                        Call Calculate() '''--> Calculate total amount
                        ssgrid.Col = 6
                        ssgrid.Row = ssgrid.ActiveRow
                        ssgrid.Text = "0.00"
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
            ElseIf ssgrid.ActiveCol = 7 Then
                ssgrid.Col = 7
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Trim(ssgrid.Text) = "" Then
                        ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
                    Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                    End If
                End If
            ElseIf ssgrid.ActiveCol = 8 Then
                ssgrid.Col = 8
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Trim(ssgrid.Text) = "" Then
                        ssgrid.SetActiveCell(8, ssgrid.ActiveRow)
                    Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                    End If
                End If
            ElseIf ssgrid.ActiveCol = 9 Then
                ssgrid.Col = 9
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Trim(ssgrid.Text) = "" Then
                        ssgrid.SetActiveCell(9, ssgrid.ActiveRow)
                    Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                    End If
                End If
            ElseIf ssgrid.ActiveCol = 10 Then
                ssgrid.Col = 3
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Trim(ssgrid.Text) = "" Then
                        ssgrid.SetActiveCell(10, ssgrid.ActiveRow)
                    Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : ssgrid_LeaveCell " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Vatamount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Vatamount.TextChanged
        Try
            If Val(txt_Vatamount.Text) <> 0 Then
                txt_Billamount.Text = Format(Val(txt_Totalamt.Text) + Val(txt_Vatamount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_Discountamt.Text), "0.00")
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Vatamount_TextChanged " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Vatamount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Vatamount.KeyPress
        Try
            Call getNumeric(e)
            If Asc(e.KeyChar) = 13 Then
                txt_Surchargeamt.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Vatamount_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Surchargeamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Surchargeamt.KeyPress
        Try
            Call getNumeric(e)
            If Asc(e.KeyChar) = 13 Then
                txt_Discountamt.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Surchargeamt_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Discountamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Discountamt.KeyPress
        Try
            Call getNumeric(e)
            If Asc(e.KeyChar) = 13 Then
                Cmd_Add.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Discountamt_KeyPress " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Surchargeamt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Surchargeamt.TextChanged
        Try
            If Val(txt_Surchargeamt.Text) <> 0 Then
                txt_Billamount.Text = Format(Val(txt_Totalamt.Text) + Val(txt_Vatamount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_Discountamt.Text), "0.00")
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Surchargeamt_TextChanged" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_Discountamt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Discountamt.TextChanged
        Try
            If Val(txt_Discountamt.Text) <> 0 Then
                txt_Billamount.Text = Format(Val(txt_Totalamt.Text) + Val(txt_Vatamount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_Discountamt.Text), "0.00")
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Discountamt_TextChanged" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Vatamount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Vatamount.LostFocus
        Try
            txt_Vatamount.Text = Format(Val(txt_Vatamount.Text), "0.00")
            If Val(txt_Vatamount.Text) <> 0 Then
                txt_Billamount.Text = Format(Val(txt_Totalamt.Text) + Val(txt_Vatamount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_Discountamt.Text), "0.00")
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Vatamount_LostFocus" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Surchargeamt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Surchargeamt.LostFocus
        Try
            txt_Surchargeamt.Text = Format(Val(txt_Surchargeamt.Text), "0.00")
            If Val(txt_Surchargeamt.Text) <> 0 Then
                txt_Billamount.Text = Format(Val(txt_Totalamt.Text) + Val(txt_Vatamount.Text) + Val(txt_Surchargeamt.Text) - Val(txt_Discountamt.Text), "0.00")
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_Surchargeamt_LostFocus" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub GRN_Cum_Purchase_Bill_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Try
            GRNCumPurchaseBillTransbool = False
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : GRN_Cum_Purchase_Bill_Closed" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_FromDocno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_FromDocno.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If Cmd_FromDocno.Enabled = True Then
                    search = Trim(txt_FromDocno.Text)
                    Call Cmd_FromDocno_Click(Cmd_FromDocno, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_FromDocno_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_ToDocno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ToDocno.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If Cmd_ToDocno.Enabled = True Then
                    search = Trim(txt_ToDocno.Text)
                    Call Cmd_ToDocno_Click(Cmd_ToDocno, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_ToDocno_KeyDown" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_FromDocno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_FromDocno.Validated
        If Trim(txt_FromDocno.Text) <> "" Then
            Try
                sqlstring = "SELECT  ISNULL(GRNNO,'') AS GRNNO,ISNULL(GRNDETAILS,'') AS GRNDETAILS"
                sqlstring = sqlstring & " FROM GRN_HEADER WHERE GRNNO = '" & Format(Val(txt_FromDocno.Text), "0000") & "' OR GRNDETAILS='" & Trim(txt_FromDocno.Text) & "'"
                gconnection.getDataSet(sqlstring, "GRNHEADER")
                If gdataset.Tables("GRNHEADER").Rows.Count > 0 Then
                    Me.txt_FromDocno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDETAILS"))
                    Me.txt_FromDocno.ReadOnly = True
                End If
            Catch
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub txt_ToDocno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ToDocno.Validated
        If Trim(txt_ToDocno.Text) <> "" Then
            Try
                sqlstring = "SELECT  ISNULL(GRNNO,'') AS GRNNO,ISNULL(GRNDETAILS,'') AS GRNDETAILS"
                sqlstring = sqlstring & " FROM GRN_HEADER WHERE GRNNO = '" & Format(Val(txt_ToDocno.Text), "0000") & "' OR GRNDETAILS='" & Trim(txt_ToDocno.Text) & "'"
                gconnection.getDataSet(sqlstring, "GRNHEADER")
                If gdataset.Tables("GRNHEADER").Rows.Count > 0 Then
                    Me.txt_ToDocno.Text = Trim(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDETAILS"))
                    Me.txt_ToDocno.ReadOnly = True
                End If
            Catch
                Exit Sub
            End Try
        End If
    End Sub
    Private Sub CMB_CATEGORY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_CATEGORY.SelectedIndexChanged
        Try
            Call autogenerate()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub cmd_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_print.Click
        Try
            gPrint = True
            Call printoperation()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_print_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub CMB_CATEGORY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMB_CATEGORY.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                Call autogenerate()
                dtp_Grndate.Focus()
                CMB_CATEGORY.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CMB_CATEGORY_KeyDown " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class
