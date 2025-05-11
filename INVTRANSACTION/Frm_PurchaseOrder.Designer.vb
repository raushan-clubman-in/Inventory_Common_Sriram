<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_PurchaseOrder
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_PurchaseOrder))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cmd_PONoHelp = New System.Windows.Forms.Button()
        Me.Cmd_VcodeHelp = New System.Windows.Forms.Button()
        Me.cmd_DeptHelp = New System.Windows.Forms.Button()
        Me.CmbPoType = New System.Windows.Forms.ComboBox()
        Me.dtpvalidto = New System.Windows.Forms.DateTimePicker()
        Me.dtpvalidfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_Storecode = New System.Windows.Forms.TextBox()
        Me.cbo_dept = New System.Windows.Forms.TextBox()
        Me.Cbo_PODate = New System.Windows.Forms.DateTimePicker()
        Me.Cbo_POStatus = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cbo_Approvedby = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_QuotNo = New System.Windows.Forms.TextBox()
        Me.Txt_Vcode = New System.Windows.Forms.TextBox()
        Me.Txt_Vname = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_PONo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lbl_GroupCode = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.cbo_warehouse = New System.Windows.Forms.ComboBox()
        Me.GB_DELI = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ChkLst_Group = New System.Windows.Forms.CheckedListBox()
        Me.Chk_AllGroup = New System.Windows.Forms.CheckBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cmddochelp = New System.Windows.Forms.Button()
        Me.txt_docno = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXT_GROSSVALUE = New System.Windows.Forms.TextBox()
        Me.Txt_Remarks = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtothchargemin = New System.Windows.Forms.TextBox()
        Me.txtothchargeplus = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TXT_OVERALLDISC = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TXT_TRANSPORT = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_AdvanceAmt = New System.Windows.Forms.TextBox()
        Me.TXT_ADVANCEPERC = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.AxfpSpread1 = New AxFPSpreadADO.AxfpSpread()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CMD_APPROVE = New System.Windows.Forms.Button()
        Me.cmd_dos_print = New System.Windows.Forms.Button()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.CmdFreeze = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Labqty = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Txt_CST = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Txt_Balance = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Octra = New System.Windows.Forms.TextBox()
        Me.Txt_PTax = New System.Windows.Forms.TextBox()
        Me.Txt_TotalVat = New System.Windows.Forms.TextBox()
        Me.Txt_TotalTax = New System.Windows.Forms.TextBox()
        Me.Txt_MODVat = New System.Windows.Forms.TextBox()
        Me.TXT_CF = New System.Windows.Forms.TextBox()
        Me.Txt_LST = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Txt_Insurance = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Txt_POValue = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chk_amnd_foll = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Txt_AddCess = New System.Windows.Forms.TextBox()
        Me.TXT_DELIVTERMS_DESC = New System.Windows.Forms.TextBox()
        Me.Txt_DeliveryTerms = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TXT_PAYMTTERMS_DESC = New System.Windows.Forms.TextBox()
        Me.Txt_POTerms = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.txt_SalesTax = New System.Windows.Forms.TextBox()
        Me.txt_MOD = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.TXT_DOCTHROUGH = New System.Windows.Forms.TextBox()
        Me.Cmd_POTermsHelp = New System.Windows.Forms.Button()
        Me.Cmd_DeliveryTermHelp = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TXT_PTERM = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.RICH_INDNO = New System.Windows.Forms.RichTextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.DTP_DELIVERDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.TXT_DEPT_CON_EMAIL = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TXT_DEP_CON_NO = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.TXT_DEPTCONPERSON = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TXT_TODEPT = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TXT_DNO = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.TXT_DEPART = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.lbl_closingqty = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.CBO_QUOT_DATE = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.GB_DELI.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.CBO_QUOT_DATE)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.Cmd_PONoHelp)
        Me.GroupBox1.Controls.Add(Me.Cmd_VcodeHelp)
        Me.GroupBox1.Controls.Add(Me.cmd_DeptHelp)
        Me.GroupBox1.Controls.Add(Me.CmbPoType)
        Me.GroupBox1.Controls.Add(Me.dtpvalidto)
        Me.GroupBox1.Controls.Add(Me.dtpvalidfrom)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Txt_Storecode)
        Me.GroupBox1.Controls.Add(Me.cbo_dept)
        Me.GroupBox1.Controls.Add(Me.Cbo_PODate)
        Me.GroupBox1.Controls.Add(Me.Cbo_POStatus)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Cbo_Approvedby)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Txt_QuotNo)
        Me.GroupBox1.Controls.Add(Me.Txt_Vcode)
        Me.GroupBox1.Controls.Add(Me.Txt_Vname)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txt_PONo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.lbl_GroupCode)
        Me.GroupBox1.Controls.Add(Me.Label47)
        Me.GroupBox1.Controls.Add(Me.cbo_warehouse)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 110)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'Cmd_PONoHelp
        '
        Me.Cmd_PONoHelp.FlatAppearance.BorderSize = 0
        Me.Cmd_PONoHelp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_PONoHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_PONoHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_PONoHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_PONoHelp.Image = CType(resources.GetObject("Cmd_PONoHelp.Image"), System.Drawing.Image)
        Me.Cmd_PONoHelp.Location = New System.Drawing.Point(660, 9)
        Me.Cmd_PONoHelp.Name = "Cmd_PONoHelp"
        Me.Cmd_PONoHelp.Size = New System.Drawing.Size(24, 26)
        Me.Cmd_PONoHelp.TabIndex = 5614
        '
        'Cmd_VcodeHelp
        '
        Me.Cmd_VcodeHelp.FlatAppearance.BorderSize = 0
        Me.Cmd_VcodeHelp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_VcodeHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_VcodeHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_VcodeHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_VcodeHelp.Image = CType(resources.GetObject("Cmd_VcodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_VcodeHelp.Location = New System.Drawing.Point(335, 32)
        Me.Cmd_VcodeHelp.Name = "Cmd_VcodeHelp"
        Me.Cmd_VcodeHelp.Size = New System.Drawing.Size(24, 26)
        Me.Cmd_VcodeHelp.TabIndex = 5613
        '
        'cmd_DeptHelp
        '
        Me.cmd_DeptHelp.FlatAppearance.BorderSize = 0
        Me.cmd_DeptHelp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_DeptHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_DeptHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_DeptHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_DeptHelp.Image = CType(resources.GetObject("cmd_DeptHelp.Image"), System.Drawing.Image)
        Me.cmd_DeptHelp.Location = New System.Drawing.Point(335, 5)
        Me.cmd_DeptHelp.Name = "cmd_DeptHelp"
        Me.cmd_DeptHelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_DeptHelp.TabIndex = 5612
        '
        'CmbPoType
        '
        Me.CmbPoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPoType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbPoType.Items.AddRange(New Object() {"FIXED RATE FIXED QUANTITY", "FIXED RATE OPEN QUANTITY", "OPEN RATE FIXED QUANTITY", "OPEN RATE OPEN QUANTITY", "RATE IN RANGE QUANTITY IN RANGE"})
        Me.CmbPoType.Location = New System.Drawing.Point(83, 57)
        Me.CmbPoType.MaxLength = 25
        Me.CmbPoType.Name = "CmbPoType"
        Me.CmbPoType.Size = New System.Drawing.Size(100, 22)
        Me.CmbPoType.TabIndex = 5596
        '
        'dtpvalidto
        '
        Me.dtpvalidto.CustomFormat = "dd-MMM-yyyy"
        Me.dtpvalidto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpvalidto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpvalidto.Location = New System.Drawing.Point(557, 64)
        Me.dtpvalidto.Name = "dtpvalidto"
        Me.dtpvalidto.Size = New System.Drawing.Size(120, 20)
        Me.dtpvalidto.TabIndex = 5595
        '
        'dtpvalidfrom
        '
        Me.dtpvalidfrom.CustomFormat = "dd-MMM-yyyy"
        Me.dtpvalidfrom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpvalidfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpvalidfrom.Location = New System.Drawing.Point(283, 59)
        Me.dtpvalidfrom.Name = "dtpvalidfrom"
        Me.dtpvalidfrom.Size = New System.Drawing.Size(152, 20)
        Me.dtpvalidfrom.TabIndex = 5594
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(466, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 14)
        Me.Label13.TabIndex = 5593
        Me.Label13.Text = "PO VALID UPTO "
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(186, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(94, 14)
        Me.Label10.TabIndex = 5592
        Me.Label10.Text = "PO VALID FROM "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 14)
        Me.Label9.TabIndex = 5591
        Me.Label9.Text = "PO TYPE "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_Storecode
        '
        Me.Txt_Storecode.BackColor = System.Drawing.Color.White
        Me.Txt_Storecode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Storecode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Storecode.Location = New System.Drawing.Point(282, 12)
        Me.Txt_Storecode.MaxLength = 10
        Me.Txt_Storecode.Name = "Txt_Storecode"
        Me.Txt_Storecode.Size = New System.Drawing.Size(50, 20)
        Me.Txt_Storecode.TabIndex = 5590
        '
        'cbo_dept
        '
        Me.cbo_dept.BackColor = System.Drawing.Color.White
        Me.cbo_dept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cbo_dept.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_dept.Location = New System.Drawing.Point(363, 11)
        Me.cbo_dept.MaxLength = 10
        Me.cbo_dept.Name = "cbo_dept"
        Me.cbo_dept.ReadOnly = True
        Me.cbo_dept.Size = New System.Drawing.Size(100, 20)
        Me.cbo_dept.TabIndex = 571
        '
        'Cbo_PODate
        '
        Me.Cbo_PODate.CustomFormat = "dd-MMM-yyyy"
        Me.Cbo_PODate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_PODate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Cbo_PODate.Location = New System.Drawing.Point(557, 40)
        Me.Cbo_PODate.Name = "Cbo_PODate"
        Me.Cbo_PODate.Size = New System.Drawing.Size(120, 20)
        Me.Cbo_PODate.TabIndex = 2
        '
        'Cbo_POStatus
        '
        Me.Cbo_POStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_POStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_POStatus.Items.AddRange(New Object() {"PENDING", "RELEASED", "CLOSED", "CANCELLED", "AMENDED"})
        Me.Cbo_POStatus.Location = New System.Drawing.Point(282, 82)
        Me.Cbo_POStatus.MaxLength = 25
        Me.Cbo_POStatus.Name = "Cbo_POStatus"
        Me.Cbo_POStatus.Size = New System.Drawing.Size(152, 22)
        Me.Cbo_POStatus.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(186, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 14)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "P.O. STATUS  "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cbo_Approvedby
        '
        Me.Cbo_Approvedby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_Approvedby.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Approvedby.Items.AddRange(New Object() {"PENDING FOR APPROVAL", "APPROVED"})
        Me.Cbo_Approvedby.Location = New System.Drawing.Point(83, 82)
        Me.Cbo_Approvedby.MaxLength = 25
        Me.Cbo_Approvedby.Name = "Cbo_Approvedby"
        Me.Cbo_Approvedby.Size = New System.Drawing.Size(100, 22)
        Me.Cbo_Approvedby.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 14)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "APPROVAL"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 14)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "QUOT.  NO.  "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_QuotNo
        '
        Me.Txt_QuotNo.BackColor = System.Drawing.Color.White
        Me.Txt_QuotNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_QuotNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_QuotNo.Location = New System.Drawing.Point(83, 34)
        Me.Txt_QuotNo.MaxLength = 10
        Me.Txt_QuotNo.Name = "Txt_QuotNo"
        Me.Txt_QuotNo.Size = New System.Drawing.Size(100, 20)
        Me.Txt_QuotNo.TabIndex = 3
        Me.Txt_QuotNo.Text = "NA"
        '
        'Txt_Vcode
        '
        Me.Txt_Vcode.BackColor = System.Drawing.Color.White
        Me.Txt_Vcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Vcode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Vcode.Location = New System.Drawing.Point(282, 36)
        Me.Txt_Vcode.MaxLength = 10
        Me.Txt_Vcode.Name = "Txt_Vcode"
        Me.Txt_Vcode.Size = New System.Drawing.Size(50, 20)
        Me.Txt_Vcode.TabIndex = 4
        '
        'Txt_Vname
        '
        Me.Txt_Vname.BackColor = System.Drawing.Color.White
        Me.Txt_Vname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Vname.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Vname.Location = New System.Drawing.Point(363, 36)
        Me.Txt_Vname.MaxLength = 50
        Me.Txt_Vname.Name = "Txt_Vname"
        Me.Txt_Vname.ReadOnly = True
        Me.Txt_Vname.Size = New System.Drawing.Size(100, 20)
        Me.Txt_Vname.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(186, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 23)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "VENDOR CODE  "
        '
        'txt_PONo
        '
        Me.txt_PONo.BackColor = System.Drawing.Color.White
        Me.txt_PONo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_PONo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PONo.Location = New System.Drawing.Point(522, 14)
        Me.txt_PONo.MaxLength = 25
        Me.txt_PONo.Name = "txt_PONo"
        Me.txt_PONo.Size = New System.Drawing.Size(135, 20)
        Me.txt_PONo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(466, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "P.O. DATE "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(186, 14)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(84, 14)
        Me.Label38.TabIndex = 570
        Me.Label38.Text = "DEPARTMENT  "
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_GroupCode
        '
        Me.lbl_GroupCode.AutoSize = True
        Me.lbl_GroupCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_GroupCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupCode.Location = New System.Drawing.Point(465, 17)
        Me.lbl_GroupCode.Name = "lbl_GroupCode"
        Me.lbl_GroupCode.Size = New System.Drawing.Size(57, 14)
        Me.lbl_GroupCode.TabIndex = 9
        Me.lbl_GroupCode.Text = "P.O.  NO.  "
        Me.lbl_GroupCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(10, 12)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(71, 14)
        Me.Label47.TabIndex = 576
        Me.Label47.Text = "CATEGORY  "
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbo_warehouse
        '
        Me.cbo_warehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_warehouse.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_warehouse.Location = New System.Drawing.Point(83, 9)
        Me.cbo_warehouse.Name = "cbo_warehouse"
        Me.cbo_warehouse.Size = New System.Drawing.Size(100, 22)
        Me.cbo_warehouse.TabIndex = 5589
        '
        'GB_DELI
        '
        Me.GB_DELI.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.GB_DELI.Controls.Add(Me.btnCancel)
        Me.GB_DELI.Controls.Add(Me.ChkLst_Group)
        Me.GB_DELI.Controls.Add(Me.Chk_AllGroup)
        Me.GB_DELI.Controls.Add(Me.Label28)
        Me.GB_DELI.Location = New System.Drawing.Point(7, 94)
        Me.GB_DELI.Name = "GB_DELI"
        Me.GB_DELI.Size = New System.Drawing.Size(687, 372)
        Me.GB_DELI.TabIndex = 5612
        Me.GB_DELI.TabStop = False
        Me.GB_DELI.Text = "PO_DeliveryTerms"
        Me.GB_DELI.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(321, 323)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 32)
        Me.btnCancel.TabIndex = 500
        Me.btnCancel.Text = "&Close"
        '
        'ChkLst_Group
        '
        Me.ChkLst_Group.CheckOnClick = True
        Me.ChkLst_Group.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkLst_Group.Location = New System.Drawing.Point(35, 71)
        Me.ChkLst_Group.Name = "ChkLst_Group"
        Me.ChkLst_Group.Size = New System.Drawing.Size(678, 244)
        Me.ChkLst_Group.TabIndex = 497
        '
        'Chk_AllGroup
        '
        Me.Chk_AllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_AllGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_AllGroup.Location = New System.Drawing.Point(40, 23)
        Me.Chk_AllGroup.Name = "Chk_AllGroup"
        Me.Chk_AllGroup.Size = New System.Drawing.Size(136, 24)
        Me.Chk_AllGroup.TabIndex = 498
        Me.Chk_AllGroup.Text = "SELECT ALL "
        Me.Chk_AllGroup.UseVisualStyleBackColor = False
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Maroon
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(40, 46)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(677, 24)
        Me.Label28.TabIndex = 499
        Me.Label28.Text = "Delivery Term Selection :"
        '
        'cmddochelp
        '
        Me.cmddochelp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddochelp.Image = CType(resources.GetObject("cmddochelp.Image"), System.Drawing.Image)
        Me.cmddochelp.Location = New System.Drawing.Point(46, 50)
        Me.cmddochelp.Name = "cmddochelp"
        Me.cmddochelp.Size = New System.Drawing.Size(24, 25)
        Me.cmddochelp.TabIndex = 578
        Me.cmddochelp.Visible = False
        '
        'txt_docno
        '
        Me.txt_docno.BackColor = System.Drawing.Color.White
        Me.txt_docno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_docno.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_docno.Location = New System.Drawing.Point(28, 53)
        Me.txt_docno.MaxLength = 10
        Me.txt_docno.Name = "txt_docno"
        Me.txt_docno.Size = New System.Drawing.Size(58, 20)
        Me.txt_docno.TabIndex = 577
        Me.txt_docno.Visible = False
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(158, 61)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(95, 14)
        Me.Label52.TabIndex = 576
        Me.Label52.Text = "AUTH. DOC NO.  :"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label52.Visible = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(69, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 23)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "NAME  :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Visible = False
        '
        'TXT_GROSSVALUE
        '
        Me.TXT_GROSSVALUE.BackColor = System.Drawing.Color.LightBlue
        Me.TXT_GROSSVALUE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_GROSSVALUE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_GROSSVALUE.Location = New System.Drawing.Point(589, 14)
        Me.TXT_GROSSVALUE.MaxLength = 4
        Me.TXT_GROSSVALUE.Name = "TXT_GROSSVALUE"
        Me.TXT_GROSSVALUE.Size = New System.Drawing.Size(88, 20)
        Me.TXT_GROSSVALUE.TabIndex = 5605
        Me.TXT_GROSSVALUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_Remarks
        '
        Me.Txt_Remarks.BackColor = System.Drawing.Color.White
        Me.Txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Remarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Remarks.Location = New System.Drawing.Point(81, 14)
        Me.Txt_Remarks.MaxLength = 200
        Me.Txt_Remarks.Name = "Txt_Remarks"
        Me.Txt_Remarks.Size = New System.Drawing.Size(414, 20)
        Me.Txt_Remarks.TabIndex = 5604
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 12)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(66, 23)
        Me.Label25.TabIndex = 5603
        Me.Label25.Text = "REMARKS "
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox3.Controls.Add(Me.txtothchargemin)
        Me.GroupBox3.Controls.Add(Me.txtothchargeplus)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.TXT_OVERALLDISC)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Controls.Add(Me.TXT_TRANSPORT)
        Me.GroupBox3.Controls.Add(Me.Label45)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Txt_AdvanceAmt)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 390)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(302, 93)
        Me.GroupBox3.TabIndex = 5600
        Me.GroupBox3.TabStop = False
        '
        'txtothchargemin
        '
        Me.txtothchargemin.BackColor = System.Drawing.Color.LightBlue
        Me.txtothchargemin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtothchargemin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtothchargemin.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtothchargemin.Location = New System.Drawing.Point(217, 41)
        Me.txtothchargemin.MaxLength = 12
        Me.txtothchargemin.Name = "txtothchargemin"
        Me.txtothchargemin.Size = New System.Drawing.Size(70, 20)
        Me.txtothchargemin.TabIndex = 5590
        Me.txtothchargemin.TabStop = False
        Me.txtothchargemin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtothchargeplus
        '
        Me.txtothchargeplus.BackColor = System.Drawing.Color.LightBlue
        Me.txtothchargeplus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtothchargeplus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtothchargeplus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtothchargeplus.Location = New System.Drawing.Point(79, 41)
        Me.txtothchargeplus.MaxLength = 12
        Me.txtothchargeplus.Name = "txtothchargeplus"
        Me.txtothchargeplus.Size = New System.Drawing.Size(70, 20)
        Me.txtothchargeplus.TabIndex = 5589
        Me.txtothchargeplus.TabStop = False
        Me.txtothchargeplus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(149, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(67, 14)
        Me.Label26.TabIndex = 5588
        Me.Label26.Text = "OTHCHG(-) "
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(1, 44)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 14)
        Me.Label24.TabIndex = 5587
        Me.Label24.Text = "OTHCHG(+)  "
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_OVERALLDISC
        '
        Me.TXT_OVERALLDISC.BackColor = System.Drawing.Color.LightBlue
        Me.TXT_OVERALLDISC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_OVERALLDISC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_OVERALLDISC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_OVERALLDISC.Location = New System.Drawing.Point(79, 67)
        Me.TXT_OVERALLDISC.MaxLength = 12
        Me.TXT_OVERALLDISC.Name = "TXT_OVERALLDISC"
        Me.TXT_OVERALLDISC.Size = New System.Drawing.Size(70, 20)
        Me.TXT_OVERALLDISC.TabIndex = 5582
        Me.TXT_OVERALLDISC.TabStop = False
        Me.TXT_OVERALLDISC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.Transparent
        Me.Label41.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(0, 71)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(86, 14)
        Me.Label41.TabIndex = 5580
        Me.Label41.Text = "OVRALL DISC  "
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_TRANSPORT
        '
        Me.TXT_TRANSPORT.BackColor = System.Drawing.Color.LightBlue
        Me.TXT_TRANSPORT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_TRANSPORT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_TRANSPORT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_TRANSPORT.Location = New System.Drawing.Point(79, 16)
        Me.TXT_TRANSPORT.MaxLength = 12
        Me.TXT_TRANSPORT.Name = "TXT_TRANSPORT"
        Me.TXT_TRANSPORT.Size = New System.Drawing.Size(70, 20)
        Me.TXT_TRANSPORT.TabIndex = 5586
        Me.TXT_TRANSPORT.TabStop = False
        Me.TXT_TRANSPORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(1, 18)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(75, 14)
        Me.Label45.TabIndex = 5584
        Me.Label45.Text = "TRANSPORT "
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(151, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 14)
        Me.Label6.TabIndex = 5564
        Me.Label6.Text = "ADVANCE "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_AdvanceAmt
        '
        Me.Txt_AdvanceAmt.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_AdvanceAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_AdvanceAmt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AdvanceAmt.Location = New System.Drawing.Point(219, 14)
        Me.Txt_AdvanceAmt.MaxLength = 12
        Me.Txt_AdvanceAmt.Name = "Txt_AdvanceAmt"
        Me.Txt_AdvanceAmt.Size = New System.Drawing.Size(68, 20)
        Me.Txt_AdvanceAmt.TabIndex = 5557
        Me.Txt_AdvanceAmt.TabStop = False
        Me.Txt_AdvanceAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXT_ADVANCEPERC
        '
        Me.TXT_ADVANCEPERC.BackColor = System.Drawing.Color.LightBlue
        Me.TXT_ADVANCEPERC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_ADVANCEPERC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_ADVANCEPERC.Location = New System.Drawing.Point(72, 72)
        Me.TXT_ADVANCEPERC.MaxLength = 4
        Me.TXT_ADVANCEPERC.Name = "TXT_ADVANCEPERC"
        Me.TXT_ADVANCEPERC.Size = New System.Drawing.Size(72, 20)
        Me.TXT_ADVANCEPERC.TabIndex = 579
        Me.TXT_ADVANCEPERC.Text = "0.00"
        Me.TXT_ADVANCEPERC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXT_ADVANCEPERC.Visible = False
        '
        'Label57
        '
        Me.Label57.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(106, 72)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(24, 23)
        Me.Label57.TabIndex = 578
        Me.Label57.Text = "%"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label57.Visible = False
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(40, 55)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(61, 14)
        Me.Label56.TabIndex = 576
        Me.Label56.Text = "ADVANCE:"
        Me.Label56.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.AutoSize = True
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox4.Controls.Add(Me.AxfpSpread1)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 201)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(690, 147)
        Me.GroupBox4.TabIndex = 5604
        Me.GroupBox4.TabStop = False
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxfpSpread1.Location = New System.Drawing.Point(3, 16)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(684, 128)
        Me.AxfpSpread1.TabIndex = 0
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
        Me.CMD_APPROVE.Location = New System.Drawing.Point(728, 414)
        Me.CMD_APPROVE.Name = "CMD_APPROVE"
        Me.CMD_APPROVE.Size = New System.Drawing.Size(124, 46)
        Me.CMD_APPROVE.TabIndex = 5607
        Me.CMD_APPROVE.Text = "APPROVE"
        Me.CMD_APPROVE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_APPROVE.UseVisualStyleBackColor = False
        Me.CMD_APPROVE.Visible = False
        '
        'cmd_dos_print
        '
        Me.cmd_dos_print.BackColor = System.Drawing.Color.Transparent
        Me.cmd_dos_print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_dos_print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_dos_print.ForeColor = System.Drawing.Color.Black
        Me.cmd_dos_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_dos_print.Location = New System.Drawing.Point(6, 248)
        Me.cmd_dos_print.Name = "cmd_dos_print"
        Me.cmd_dos_print.Size = New System.Drawing.Size(125, 40)
        Me.cmd_dos_print.TabIndex = 5606
        Me.cmd_dos_print.Text = "Dos Print"
        Me.cmd_dos_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_dos_print.UseVisualStyleBackColor = False
        Me.cmd_dos_print.Visible = False
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdExit.BackgroundImage = CType(resources.GetObject("CmdExit.BackgroundImage"), System.Drawing.Image)
        Me.CmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdExit.FlatAppearance.BorderSize = 0
        Me.CmdExit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CmdExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdExit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.ForeColor = System.Drawing.Color.Black
        Me.CmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdExit.Location = New System.Drawing.Point(6, 246)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(124, 46)
        Me.CmdExit.TabIndex = 5604
        Me.CmdExit.Text = "Exit[F11]"
        Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_export.BackgroundImage = CType(resources.GetObject("cmd_export.BackgroundImage"), System.Drawing.Image)
        Me.cmd_export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_export.FlatAppearance.BorderSize = 0
        Me.cmd_export.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(728, 342)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(124, 46)
        Me.cmd_export.TabIndex = 5603
        Me.cmd_export.Text = "Export"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        Me.cmd_export.Visible = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdClear.BackgroundImage = CType(resources.GetObject("CmdClear.BackgroundImage"), System.Drawing.Image)
        Me.CmdClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdClear.FlatAppearance.BorderSize = 0
        Me.CmdClear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CmdClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(6, 11)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(124, 46)
        Me.CmdClear.TabIndex = 19
        Me.CmdClear.Text = "Clear[F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdAdd.BackgroundImage = CType(resources.GetObject("CmdAdd.BackgroundImage"), System.Drawing.Image)
        Me.CmdAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdAdd.FlatAppearance.BorderSize = 0
        Me.CmdAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CmdAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdAdd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.Color.Black
        Me.CmdAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAdd.Location = New System.Drawing.Point(6, 58)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(124, 46)
        Me.CmdAdd.TabIndex = 29
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAdd.UseVisualStyleBackColor = False
        '
        'CmdFreeze
        '
        Me.CmdFreeze.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdFreeze.BackgroundImage = CType(resources.GetObject("CmdFreeze.BackgroundImage"), System.Drawing.Image)
        Me.CmdFreeze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdFreeze.FlatAppearance.BorderSize = 0
        Me.CmdFreeze.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CmdFreeze.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdFreeze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CmdFreeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdFreeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFreeze.ForeColor = System.Drawing.Color.Black
        Me.CmdFreeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdFreeze.Location = New System.Drawing.Point(6, 199)
        Me.CmdFreeze.Name = "CmdFreeze"
        Me.CmdFreeze.Size = New System.Drawing.Size(124, 46)
        Me.CmdFreeze.TabIndex = 20
        Me.CmdFreeze.Text = "Void[F8]"
        Me.CmdFreeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdFreeze.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdView.BackgroundImage = CType(resources.GetObject("CmdView.BackgroundImage"), System.Drawing.Image)
        Me.CmdView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdView.FlatAppearance.BorderSize = 0
        Me.CmdView.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CmdView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(6, 105)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(124, 46)
        Me.CmdView.TabIndex = 21
        Me.CmdView.Text = " View[F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CmdPrint.BackgroundImage = CType(resources.GetObject("CmdPrint.BackgroundImage"), System.Drawing.Image)
        Me.CmdPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CmdPrint.FlatAppearance.BorderSize = 0
        Me.CmdPrint.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CmdPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CmdPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPrint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.Black
        Me.CmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrint.Location = New System.Drawing.Point(6, 152)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(124, 46)
        Me.CmdPrint.TabIndex = 22
        Me.CmdPrint.Text = "Print[F10]"
        Me.CmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrint.UseVisualStyleBackColor = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(610, 61)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(139, 16)
        Me.lbl_Freeze.TabIndex = 5608
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_auth.ForeColor = System.Drawing.Color.Black
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.Location = New System.Drawing.Point(111, 51)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(41, 48)
        Me.cmd_auth.TabIndex = 5605
        Me.cmd_auth.Text = " Authorize"
        Me.cmd_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_auth.UseVisualStyleBackColor = False
        Me.cmd_auth.Visible = False
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(204, 18)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(188, 22)
        Me.lbl_Heading.TabIndex = 5609
        Me.lbl_Heading.Text = "PURCHASE ORDER"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox7
        '
        Me.GroupBox7.AutoSize = True
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox7.Controls.Add(Me.CmdClear)
        Me.GroupBox7.Controls.Add(Me.CmdAdd)
        Me.GroupBox7.Controls.Add(Me.CmdExit)
        Me.GroupBox7.Controls.Add(Me.CmdFreeze)
        Me.GroupBox7.Controls.Add(Me.CmdView)
        Me.GroupBox7.Controls.Add(Me.CmdPrint)
        Me.GroupBox7.Controls.Add(Me.cmd_dos_print)
        Me.GroupBox7.Location = New System.Drawing.Point(722, 96)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(137, 311)
        Me.GroupBox7.TabIndex = 5610
        Me.GroupBox7.TabStop = False
        '
        'GroupBox8
        '
        Me.GroupBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox8.Controls.Add(Me.TextBox1)
        Me.GroupBox8.Controls.Add(Me.Label17)
        Me.GroupBox8.Controls.Add(Me.Labqty)
        Me.GroupBox8.Controls.Add(Me.Label25)
        Me.GroupBox8.Controls.Add(Me.TXT_GROSSVALUE)
        Me.GroupBox8.Controls.Add(Me.Txt_Remarks)
        Me.GroupBox8.Location = New System.Drawing.Point(8, 346)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(687, 43)
        Me.GroupBox8.TabIndex = 5611
        Me.GroupBox8.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.LightBlue
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(589, 14)
        Me.TextBox1.MaxLength = 4
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(88, 20)
        Me.TextBox1.TabIndex = 5607
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(501, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 23)
        Me.Label17.TabIndex = 5608
        Me.Label17.Text = "BASIC VALUE"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Labqty
        '
        Me.Labqty.AutoSize = True
        Me.Labqty.Location = New System.Drawing.Point(521, 20)
        Me.Labqty.Name = "Labqty"
        Me.Labqty.Size = New System.Drawing.Size(0, 13)
        Me.Labqty.TabIndex = 5606
        Me.Labqty.Visible = False
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(194, 538)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(42, 23)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "E.D.   :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label23.Visible = False
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(259, 515)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(48, 23)
        Me.Label40.TabIndex = 5581
        Me.Label40.Text = "C && F :"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label40.Visible = False
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(-153, 71)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 23)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "LST :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label20.Visible = False
        '
        'Txt_CST
        '
        Me.Txt_CST.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_CST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CST.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CST.Location = New System.Drawing.Point(122, 523)
        Me.Txt_CST.MaxLength = 4
        Me.Txt_CST.Name = "Txt_CST"
        Me.Txt_CST.Size = New System.Drawing.Size(72, 20)
        Me.Txt_CST.TabIndex = 10
        Me.Txt_CST.Text = "0.00"
        Me.Txt_CST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_CST.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(69, 526)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 14)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "CST    :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label19.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(153, 537)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 14)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "OCTROI :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label18.Visible = False
        '
        'Txt_Balance
        '
        Me.Txt_Balance.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_Balance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Balance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Balance.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Balance.Location = New System.Drawing.Point(569, 38)
        Me.Txt_Balance.MaxLength = 12
        Me.Txt_Balance.Name = "Txt_Balance"
        Me.Txt_Balance.ReadOnly = True
        Me.Txt_Balance.Size = New System.Drawing.Size(105, 20)
        Me.Txt_Balance.TabIndex = 5569
        Me.Txt_Balance.TabStop = False
        Me.Txt_Balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(174, 529)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 14)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "MOD VAT     :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label16.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(496, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 23)
        Me.Label5.TabIndex = 5562
        Me.Label5.Text = "BALANCE "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_Octra
        '
        Me.Txt_Octra.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_Octra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Octra.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Octra.Location = New System.Drawing.Point(138, 550)
        Me.Txt_Octra.MaxLength = 4
        Me.Txt_Octra.Name = "Txt_Octra"
        Me.Txt_Octra.Size = New System.Drawing.Size(72, 20)
        Me.Txt_Octra.TabIndex = 13
        Me.Txt_Octra.Text = "0.00"
        Me.Txt_Octra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_Octra.Visible = False
        '
        'Txt_PTax
        '
        Me.Txt_PTax.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_PTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PTax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PTax.Location = New System.Drawing.Point(103, -49)
        Me.Txt_PTax.MaxLength = 4
        Me.Txt_PTax.Name = "Txt_PTax"
        Me.Txt_PTax.Size = New System.Drawing.Size(72, 20)
        Me.Txt_PTax.TabIndex = 12
        Me.Txt_PTax.Text = "0.00"
        Me.Txt_PTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_PTax.Visible = False
        '
        'Txt_TotalVat
        '
        Me.Txt_TotalVat.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_TotalVat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_TotalVat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TotalVat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TotalVat.Location = New System.Drawing.Point(188, 517)
        Me.Txt_TotalVat.MaxLength = 12
        Me.Txt_TotalVat.Name = "Txt_TotalVat"
        Me.Txt_TotalVat.ReadOnly = True
        Me.Txt_TotalVat.Size = New System.Drawing.Size(72, 20)
        Me.Txt_TotalVat.TabIndex = 5570
        Me.Txt_TotalVat.TabStop = False
        Me.Txt_TotalVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_TotalVat.Visible = False
        '
        'Txt_TotalTax
        '
        Me.Txt_TotalTax.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_TotalTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_TotalTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_TotalTax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_TotalTax.Location = New System.Drawing.Point(382, 12)
        Me.Txt_TotalTax.MaxLength = 12
        Me.Txt_TotalTax.Name = "Txt_TotalTax"
        Me.Txt_TotalTax.ReadOnly = True
        Me.Txt_TotalTax.Size = New System.Drawing.Size(107, 20)
        Me.Txt_TotalTax.TabIndex = 5568
        Me.Txt_TotalTax.TabStop = False
        Me.Txt_TotalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_MODVat
        '
        Me.Txt_MODVat.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_MODVat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MODVat.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MODVat.Location = New System.Drawing.Point(258, 523)
        Me.Txt_MODVat.MaxLength = 4
        Me.Txt_MODVat.Name = "Txt_MODVat"
        Me.Txt_MODVat.Size = New System.Drawing.Size(72, 20)
        Me.Txt_MODVat.TabIndex = 11
        Me.Txt_MODVat.Text = "0.00"
        Me.Txt_MODVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_MODVat.Visible = False
        '
        'TXT_CF
        '
        Me.TXT_CF.BackColor = System.Drawing.Color.LightBlue
        Me.TXT_CF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_CF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_CF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CF.Location = New System.Drawing.Point(305, 518)
        Me.TXT_CF.MaxLength = 12
        Me.TXT_CF.Name = "TXT_CF"
        Me.TXT_CF.Size = New System.Drawing.Size(74, 20)
        Me.TXT_CF.TabIndex = 5583
        Me.TXT_CF.TabStop = False
        Me.TXT_CF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXT_CF.Visible = False
        '
        'Txt_LST
        '
        Me.Txt_LST.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_LST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_LST.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_LST.Location = New System.Drawing.Point(-98, 72)
        Me.Txt_LST.MaxLength = 4
        Me.Txt_LST.Name = "Txt_LST"
        Me.Txt_LST.Size = New System.Drawing.Size(72, 20)
        Me.Txt_LST.TabIndex = 15
        Me.Txt_LST.Text = "0.00"
        Me.Txt_LST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_LST.Visible = False
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(124, 549)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(70, 23)
        Me.Label42.TabIndex = 5585
        Me.Label42.Text = "DELIVERY :"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label42.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(194, 546)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 23)
        Me.Label4.TabIndex = 5561
        Me.Label4.Text = "TOTAL VAT :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Visible = False
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(-23, 16)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(24, 23)
        Me.Label30.TabIndex = 569
        Me.Label30.Text = "%"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label30.Visible = False
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(199, 529)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(20, 23)
        Me.Label31.TabIndex = 570
        Me.Label31.Text = "%"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label31.Visible = False
        '
        'Txt_Insurance
        '
        Me.Txt_Insurance.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_Insurance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Insurance.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Insurance.Location = New System.Drawing.Point(161, -77)
        Me.Txt_Insurance.MaxLength = 4
        Me.Txt_Insurance.Name = "Txt_Insurance"
        Me.Txt_Insurance.Size = New System.Drawing.Size(72, 20)
        Me.Txt_Insurance.TabIndex = 14
        Me.Txt_Insurance.Text = "0.00"
        Me.Txt_Insurance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(497, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 32)
        Me.Label2.TabIndex = 5599
        Me.Label2.Text = "P.O. VALUE "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(301, 521)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(18, 23)
        Me.Label32.TabIndex = 571
        Me.Label32.Text = "%"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label32.Visible = False
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(173, 539)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(20, 23)
        Me.Label35.TabIndex = 574
        Me.Label35.Text = "%"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label35.Visible = False
        '
        'Txt_POValue
        '
        Me.Txt_POValue.BackColor = System.Drawing.Color.Pink
        Me.Txt_POValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_POValue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_POValue.Location = New System.Drawing.Point(569, 12)
        Me.Txt_POValue.MaxLength = 12
        Me.Txt_POValue.Name = "Txt_POValue"
        Me.Txt_POValue.ReadOnly = True
        Me.Txt_POValue.Size = New System.Drawing.Size(105, 20)
        Me.Txt_POValue.TabIndex = 5598
        Me.Txt_POValue.TabStop = False
        Me.Txt_POValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(-25, 42)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(15, 23)
        Me.Label33.TabIndex = 572
        Me.Label33.Text = "%"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label33.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(305, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 23)
        Me.Label3.TabIndex = 5603
        Me.Label3.Text = "TOTAL TAX :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chk_amnd_foll
        '
        Me.chk_amnd_foll.BackColor = System.Drawing.Color.Transparent
        Me.chk_amnd_foll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_amnd_foll.Location = New System.Drawing.Point(161, 514)
        Me.chk_amnd_foll.Name = "chk_amnd_foll"
        Me.chk_amnd_foll.Size = New System.Drawing.Size(109, 39)
        Me.chk_amnd_foll.TabIndex = 5603
        Me.chk_amnd_foll.Text = "Amendment && Followup"
        Me.chk_amnd_foll.UseVisualStyleBackColor = False
        Me.chk_amnd_foll.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label7.Location = New System.Drawing.Point(276, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 16)
        Me.Label7.TabIndex = 5604
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(146, 537)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(20, 23)
        Me.Label36.TabIndex = 575
        Me.Label36.Text = "%"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label36.Visible = False
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(190, 532)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(20, 23)
        Me.Label34.TabIndex = 573
        Me.Label34.Text = "%"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label34.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Txt_AddCess)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Txt_POValue)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Txt_Insurance)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Txt_LST)
        Me.GroupBox2.Controls.Add(Me.Txt_TotalTax)
        Me.GroupBox2.Controls.Add(Me.Txt_PTax)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Txt_Balance)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 489)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(712, 77)
        Me.GroupBox2.TabIndex = 5601
        Me.GroupBox2.TabStop = False
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(84, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 23)
        Me.Label21.TabIndex = 5606
        Me.Label21.Text = "TOTAL ADD. CESS :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Txt_AddCess
        '
        Me.Txt_AddCess.BackColor = System.Drawing.Color.LightBlue
        Me.Txt_AddCess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_AddCess.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_AddCess.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_AddCess.Location = New System.Drawing.Point(197, 13)
        Me.Txt_AddCess.MaxLength = 12
        Me.Txt_AddCess.Name = "Txt_AddCess"
        Me.Txt_AddCess.ReadOnly = True
        Me.Txt_AddCess.Size = New System.Drawing.Size(107, 20)
        Me.Txt_AddCess.TabIndex = 5605
        Me.Txt_AddCess.TabStop = False
        Me.Txt_AddCess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXT_DELIVTERMS_DESC
        '
        Me.TXT_DELIVTERMS_DESC.BackColor = System.Drawing.Color.White
        Me.TXT_DELIVTERMS_DESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DELIVTERMS_DESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DELIVTERMS_DESC.Location = New System.Drawing.Point(141, 37)
        Me.TXT_DELIVTERMS_DESC.MaxLength = 50
        Me.TXT_DELIVTERMS_DESC.Name = "TXT_DELIVTERMS_DESC"
        Me.TXT_DELIVTERMS_DESC.Size = New System.Drawing.Size(83, 20)
        Me.TXT_DELIVTERMS_DESC.TabIndex = 5599
        Me.TXT_DELIVTERMS_DESC.Text = "IMMEDIATELY"
        '
        'Txt_DeliveryTerms
        '
        Me.Txt_DeliveryTerms.BackColor = System.Drawing.Color.White
        Me.Txt_DeliveryTerms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_DeliveryTerms.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_DeliveryTerms.Location = New System.Drawing.Point(75, 36)
        Me.Txt_DeliveryTerms.MaxLength = 25
        Me.Txt_DeliveryTerms.Name = "Txt_DeliveryTerms"
        Me.Txt_DeliveryTerms.Size = New System.Drawing.Size(40, 20)
        Me.Txt_DeliveryTerms.TabIndex = 22
        Me.Txt_DeliveryTerms.Text = "IMM"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(1, 39)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 14)
        Me.Label27.TabIndex = 22
        Me.Label27.Text = "DEL TERMS"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_PAYMTTERMS_DESC
        '
        Me.TXT_PAYMTTERMS_DESC.BackColor = System.Drawing.Color.White
        Me.TXT_PAYMTTERMS_DESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_PAYMTTERMS_DESC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_PAYMTTERMS_DESC.Location = New System.Drawing.Point(141, 11)
        Me.TXT_PAYMTTERMS_DESC.MaxLength = 25
        Me.TXT_PAYMTTERMS_DESC.Name = "TXT_PAYMTTERMS_DESC"
        Me.TXT_PAYMTTERMS_DESC.Size = New System.Drawing.Size(83, 20)
        Me.TXT_PAYMTTERMS_DESC.TabIndex = 5600
        Me.TXT_PAYMTTERMS_DESC.Text = "CHEQUE"
        '
        'Txt_POTerms
        '
        Me.Txt_POTerms.BackColor = System.Drawing.Color.White
        Me.Txt_POTerms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_POTerms.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_POTerms.Location = New System.Drawing.Point(75, 11)
        Me.Txt_POTerms.MaxLength = 25
        Me.Txt_POTerms.Name = "Txt_POTerms"
        Me.Txt_POTerms.Size = New System.Drawing.Size(40, 20)
        Me.Txt_POTerms.TabIndex = 5558
        Me.Txt_POTerms.Text = "CHQ"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(2, 14)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 14)
        Me.Label22.TabIndex = 5556
        Me.Label22.Text = "PAY TERMS "
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(224, 15)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(93, 14)
        Me.Label53.TabIndex = 5601
        Me.Label53.Text = "SALE REMARKS "
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(224, 39)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(96, 14)
        Me.Label54.TabIndex = 5602
        Me.Label54.Text = "DESPATCH MODE"
        '
        'txt_SalesTax
        '
        Me.txt_SalesTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_SalesTax.Location = New System.Drawing.Point(323, 13)
        Me.txt_SalesTax.Name = "txt_SalesTax"
        Me.txt_SalesTax.Size = New System.Drawing.Size(80, 20)
        Me.txt_SalesTax.TabIndex = 5603
        '
        'txt_MOD
        '
        Me.txt_MOD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_MOD.Location = New System.Drawing.Point(323, 36)
        Me.txt_MOD.Name = "txt_MOD"
        Me.txt_MOD.Size = New System.Drawing.Size(80, 20)
        Me.txt_MOD.TabIndex = 5604
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(1, 65)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(87, 14)
        Me.Label55.TabIndex = 5605
        Me.Label55.Text = "Docs Through "
        '
        'TXT_DOCTHROUGH
        '
        Me.TXT_DOCTHROUGH.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DOCTHROUGH.Location = New System.Drawing.Point(94, 62)
        Me.TXT_DOCTHROUGH.Name = "TXT_DOCTHROUGH"
        Me.TXT_DOCTHROUGH.Size = New System.Drawing.Size(132, 20)
        Me.TXT_DOCTHROUGH.TabIndex = 5606
        '
        'Cmd_POTermsHelp
        '
        Me.Cmd_POTermsHelp.FlatAppearance.BorderSize = 0
        Me.Cmd_POTermsHelp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_POTermsHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_POTermsHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_POTermsHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_POTermsHelp.Image = CType(resources.GetObject("Cmd_POTermsHelp.Image"), System.Drawing.Image)
        Me.Cmd_POTermsHelp.Location = New System.Drawing.Point(115, 6)
        Me.Cmd_POTermsHelp.Name = "Cmd_POTermsHelp"
        Me.Cmd_POTermsHelp.Size = New System.Drawing.Size(24, 26)
        Me.Cmd_POTermsHelp.TabIndex = 5615
        '
        'Cmd_DeliveryTermHelp
        '
        Me.Cmd_DeliveryTermHelp.FlatAppearance.BorderSize = 0
        Me.Cmd_DeliveryTermHelp.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_DeliveryTermHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_DeliveryTermHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_DeliveryTermHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_DeliveryTermHelp.Image = CType(resources.GetObject("Cmd_DeliveryTermHelp.Image"), System.Drawing.Image)
        Me.Cmd_DeliveryTermHelp.Location = New System.Drawing.Point(115, 31)
        Me.Cmd_DeliveryTermHelp.Name = "Cmd_DeliveryTermHelp"
        Me.Cmd_DeliveryTermHelp.Size = New System.Drawing.Size(24, 26)
        Me.Cmd_DeliveryTermHelp.TabIndex = 5616
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox5.Controls.Add(Me.TXT_PTERM)
        Me.GroupBox5.Controls.Add(Me.Label50)
        Me.GroupBox5.Controls.Add(Me.Cmd_DeliveryTermHelp)
        Me.GroupBox5.Controls.Add(Me.Cmd_POTermsHelp)
        Me.GroupBox5.Controls.Add(Me.TXT_DOCTHROUGH)
        Me.GroupBox5.Controls.Add(Me.Label55)
        Me.GroupBox5.Controls.Add(Me.txt_MOD)
        Me.GroupBox5.Controls.Add(Me.txt_SalesTax)
        Me.GroupBox5.Controls.Add(Me.Label54)
        Me.GroupBox5.Controls.Add(Me.Label53)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.Txt_POTerms)
        Me.GroupBox5.Controls.Add(Me.TXT_PAYMTTERMS_DESC)
        Me.GroupBox5.Controls.Add(Me.Label27)
        Me.GroupBox5.Controls.Add(Me.Txt_DeliveryTerms)
        Me.GroupBox5.Controls.Add(Me.TXT_DELIVTERMS_DESC)
        Me.GroupBox5.Location = New System.Drawing.Point(312, 390)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(408, 93)
        Me.GroupBox5.TabIndex = 5602
        Me.GroupBox5.TabStop = False
        '
        'TXT_PTERM
        '
        Me.TXT_PTERM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_PTERM.Location = New System.Drawing.Point(94, 62)
        Me.TXT_PTERM.Name = "TXT_PTERM"
        Me.TXT_PTERM.Size = New System.Drawing.Size(308, 20)
        Me.TXT_PTERM.TabIndex = 5618
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(-3, 65)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(93, 14)
        Me.Label50.TabIndex = 5617
        Me.Label50.Text = "PAYMENT TERM "
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.RICH_INDNO)
        Me.GroupBox6.Controls.Add(Me.Label46)
        Me.GroupBox6.Controls.Add(Me.DTP_DELIVERDATE)
        Me.GroupBox6.Controls.Add(Me.Label44)
        Me.GroupBox6.Controls.Add(Me.TXT_DEPT_CON_EMAIL)
        Me.GroupBox6.Controls.Add(Me.Label43)
        Me.GroupBox6.Controls.Add(Me.TXT_DEP_CON_NO)
        Me.GroupBox6.Controls.Add(Me.Label39)
        Me.GroupBox6.Controls.Add(Me.TXT_DEPTCONPERSON)
        Me.GroupBox6.Controls.Add(Me.Label37)
        Me.GroupBox6.Controls.Add(Me.TXT_TODEPT)
        Me.GroupBox6.Controls.Add(Me.Label29)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 578)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(844, 85)
        Me.GroupBox6.TabIndex = 5613
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Delivery Details"
        '
        'RICH_INDNO
        '
        Me.RICH_INDNO.Location = New System.Drawing.Point(643, 42)
        Me.RICH_INDNO.Name = "RICH_INDNO"
        Me.RICH_INDNO.Size = New System.Drawing.Size(195, 31)
        Me.RICH_INDNO.TabIndex = 5624
        Me.RICH_INDNO.Text = ""
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(528, 39)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(109, 43)
        Me.Label46.TabIndex = 5623
        Me.Label46.Text = "INDENT/MATERIAL REQUEST NO. & DATE"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DTP_DELIVERDATE
        '
        Me.DTP_DELIVERDATE.CustomFormat = "dd-MMM-yyyy"
        Me.DTP_DELIVERDATE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_DELIVERDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_DELIVERDATE.Location = New System.Drawing.Point(643, 16)
        Me.DTP_DELIVERDATE.Name = "DTP_DELIVERDATE"
        Me.DTP_DELIVERDATE.Size = New System.Drawing.Size(93, 20)
        Me.DTP_DELIVERDATE.TabIndex = 5622
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(529, 14)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(108, 24)
        Me.Label44.TabIndex = 5607
        Me.Label44.Text = "DELIVER BY DATE"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_DEPT_CON_EMAIL
        '
        Me.TXT_DEPT_CON_EMAIL.BackColor = System.Drawing.Color.White
        Me.TXT_DEPT_CON_EMAIL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DEPT_CON_EMAIL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DEPT_CON_EMAIL.Location = New System.Drawing.Point(393, 48)
        Me.TXT_DEPT_CON_EMAIL.MaxLength = 30
        Me.TXT_DEPT_CON_EMAIL.Name = "TXT_DEPT_CON_EMAIL"
        Me.TXT_DEPT_CON_EMAIL.Size = New System.Drawing.Size(131, 20)
        Me.TXT_DEPT_CON_EMAIL.TabIndex = 5621
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(275, 46)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(96, 29)
        Me.Label43.TabIndex = 5620
        Me.Label43.Text = "DEPT. CONTACT EMAIL"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_DEP_CON_NO
        '
        Me.TXT_DEP_CON_NO.BackColor = System.Drawing.Color.White
        Me.TXT_DEP_CON_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DEP_CON_NO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DEP_CON_NO.Location = New System.Drawing.Point(393, 18)
        Me.TXT_DEP_CON_NO.MaxLength = 10
        Me.TXT_DEP_CON_NO.Name = "TXT_DEP_CON_NO"
        Me.TXT_DEP_CON_NO.Size = New System.Drawing.Size(131, 20)
        Me.TXT_DEP_CON_NO.TabIndex = 5619
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(274, 21)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(115, 14)
        Me.Label39.TabIndex = 5618
        Me.Label39.Text = "DEPT. CONTACT NO. "
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_DEPTCONPERSON
        '
        Me.TXT_DEPTCONPERSON.BackColor = System.Drawing.Color.White
        Me.TXT_DEPTCONPERSON.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DEPTCONPERSON.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DEPTCONPERSON.Location = New System.Drawing.Point(123, 47)
        Me.TXT_DEPTCONPERSON.MaxLength = 50
        Me.TXT_DEPTCONPERSON.Name = "TXT_DEPTCONPERSON"
        Me.TXT_DEPTCONPERSON.Size = New System.Drawing.Size(146, 20)
        Me.TXT_DEPTCONPERSON.TabIndex = 5617
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(9, 42)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(96, 30)
        Me.Label37.TabIndex = 5616
        Me.Label37.Text = "DEPT. CONTACT PERSON"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_TODEPT
        '
        Me.TXT_TODEPT.BackColor = System.Drawing.Color.White
        Me.TXT_TODEPT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_TODEPT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_TODEPT.Location = New System.Drawing.Point(123, 18)
        Me.TXT_TODEPT.MaxLength = 50
        Me.TXT_TODEPT.Name = "TXT_TODEPT"
        Me.TXT_TODEPT.Size = New System.Drawing.Size(146, 20)
        Me.TXT_TODEPT.TabIndex = 5615
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(7, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(111, 14)
        Me.Label29.TabIndex = 5591
        Me.Label29.Text = "DELIVERY TO DEPT. "
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(5, 5)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(88, 14)
        Me.Label48.TabIndex = 5625
        Me.Label48.Text = "DOCUMENT NO."
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_DNO
        '
        Me.TXT_DNO.BackColor = System.Drawing.Color.White
        Me.TXT_DNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DNO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DNO.Location = New System.Drawing.Point(5, 24)
        Me.TXT_DNO.MaxLength = 50
        Me.TXT_DNO.Name = "TXT_DNO"
        Me.TXT_DNO.Size = New System.Drawing.Size(128, 20)
        Me.TXT_DNO.TabIndex = 5625
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(6, 49)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(78, 14)
        Me.Label49.TabIndex = 5626
        Me.Label49.Text = "DEPARTMENT"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TXT_DEPART
        '
        Me.TXT_DEPART.BackColor = System.Drawing.Color.White
        Me.TXT_DEPART.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DEPART.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DEPART.Location = New System.Drawing.Point(6, 68)
        Me.TXT_DEPART.MaxLength = 50
        Me.TXT_DEPART.Name = "TXT_DEPART"
        Me.TXT_DEPART.Size = New System.Drawing.Size(127, 20)
        Me.TXT_DEPART.TabIndex = 5627
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RichTextBox1)
        Me.Panel1.Controls.Add(Me.Label51)
        Me.Panel1.Controls.Add(Me.TXT_DNO)
        Me.Panel1.Controls.Add(Me.TXT_DEPART)
        Me.Panel1.Controls.Add(Me.Label48)
        Me.Panel1.Controls.Add(Me.Label49)
        Me.Panel1.Location = New System.Drawing.Point(724, 438)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(138, 159)
        Me.Panel1.TabIndex = 5628
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 110)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(126, 42)
        Me.RichTextBox1.TabIndex = 5625
        Me.RichTextBox1.Text = ""
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(6, 93)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(75, 14)
        Me.Label51.TabIndex = 5628
        Me.Label51.Text = "TAX DETAILS"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_closingqty
        '
        Me.lbl_closingqty.AutoSize = True
        Me.lbl_closingqty.BackColor = System.Drawing.Color.Transparent
        Me.lbl_closingqty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_closingqty.Location = New System.Drawing.Point(317, 68)
        Me.lbl_closingqty.Name = "lbl_closingqty"
        Me.lbl_closingqty.Size = New System.Drawing.Size(80, 15)
        Me.lbl_closingqty.TabIndex = 5615
        Me.lbl_closingqty.Text = "closingstock"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(467, 85)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(75, 14)
        Me.Label58.TabIndex = 5615
        Me.Label58.Text = "QUOT.  DATE "
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CBO_QUOT_DATE
        '
        Me.CBO_QUOT_DATE.CustomFormat = "dd-MMM-yyyy"
        Me.CBO_QUOT_DATE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBO_QUOT_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.CBO_QUOT_DATE.Location = New System.Drawing.Point(557, 86)
        Me.CBO_QUOT_DATE.Name = "CBO_QUOT_DATE"
        Me.CBO_QUOT_DATE.Size = New System.Drawing.Size(120, 20)
        Me.CBO_QUOT_DATE.TabIndex = 5616
        '
        'Frm_PurchaseOrder
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(876, 675)
        Me.Controls.Add(Me.lbl_closingqty)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.CMD_APPROVE)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.chk_amnd_foll)
        Me.Controls.Add(Me.cmd_export)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.TXT_ADVANCEPERC)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.cmddochelp)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.txt_docno)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.cmd_auth)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TXT_CF)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Txt_MODVat)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Txt_TotalVat)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Txt_CST)
        Me.Controls.Add(Me.Txt_Octra)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GB_DELI)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Frm_PurchaseOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_PurchaseOrder"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GB_DELI.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmddochelp As System.Windows.Forms.Button
    Friend WithEvents txt_docno As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents cbo_dept As System.Windows.Forms.TextBox
    Friend WithEvents Cbo_PODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Cbo_POStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Approvedby As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_QuotNo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Vcode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_Vname As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_PONo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lbl_GroupCode As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents cbo_warehouse As System.Windows.Forms.ComboBox
    Friend WithEvents TXT_GROSSVALUE As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_ADVANCEPERC As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents TXT_TRANSPORT As System.Windows.Forms.TextBox
    Friend WithEvents TXT_OVERALLDISC As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_AdvanceAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents AxfpSpread1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CMD_APPROVE As System.Windows.Forms.Button
    Friend WithEvents cmd_dos_print As System.Windows.Forms.Button
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CmdFreeze As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents Txt_Storecode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents CmbPoType As System.Windows.Forms.ComboBox
    Friend WithEvents dtpvalidto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpvalidfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtothchargemin As System.Windows.Forms.TextBox
    Friend WithEvents txtothchargeplus As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Labqty As System.Windows.Forms.Label
    Friend WithEvents cmd_DeptHelp As System.Windows.Forms.Button
    Friend WithEvents Cmd_VcodeHelp As System.Windows.Forms.Button
    Friend WithEvents Cmd_PONoHelp As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Txt_CST As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Txt_Balance As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_Octra As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PTax As System.Windows.Forms.TextBox
    Friend WithEvents Txt_TotalVat As System.Windows.Forms.TextBox
    Friend WithEvents Txt_TotalTax As System.Windows.Forms.TextBox
    Friend WithEvents Txt_MODVat As System.Windows.Forms.TextBox
    Friend WithEvents TXT_CF As System.Windows.Forms.TextBox
    Friend WithEvents Txt_LST As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Txt_Insurance As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Txt_POValue As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chk_amnd_foll As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_DELIVTERMS_DESC As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DeliveryTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TXT_PAYMTTERMS_DESC As System.Windows.Forms.TextBox
    Friend WithEvents Txt_POTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents txt_SalesTax As System.Windows.Forms.TextBox
    Friend WithEvents txt_MOD As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents TXT_DOCTHROUGH As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_POTermsHelp As System.Windows.Forms.Button
    Friend WithEvents Cmd_DeliveryTermHelp As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Txt_AddCess As System.Windows.Forms.TextBox
    Friend WithEvents GB_DELI As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ChkLst_Group As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_AllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label39 As Label
    Friend WithEvents TXT_DEPTCONPERSON As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents TXT_TODEPT As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents TXT_DEP_CON_NO As TextBox
    Friend WithEvents RICH_INDNO As RichTextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents DTP_DELIVERDATE As DateTimePicker
    Friend WithEvents Label44 As Label
    Friend WithEvents TXT_DEPT_CON_EMAIL As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents TXT_DNO As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents TXT_DEPART As TextBox
    Friend WithEvents TXT_PTERM As TextBox
    Friend WithEvents Label50 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents lbl_closingqty As Label
    Friend WithEvents CBO_QUOT_DATE As DateTimePicker
    Friend WithEvents Label58 As Label
End Class
