<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_StockIssue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_StockIssue))
        Me.grp_issue2 = New System.Windows.Forms.GroupBox()
        Me.dtp_IndentDate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Docdate = New System.Windows.Forms.Label()
        Me.cmd_IndentNoHelp = New System.Windows.Forms.Button()
        Me.Txt_IndentNo = New System.Windows.Forms.TextBox()
        Me.lbl_Docno = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.grp_issue1 = New System.Windows.Forms.GroupBox()
        Me.TXT_FROMSTORECODE = New System.Windows.Forms.TextBox()
        Me.txt_FromStorename = New System.Windows.Forms.TextBox()
        Me.cmd_fromStorecodeHelp = New System.Windows.Forms.Button()
        Me.txt_storecode = New System.Windows.Forms.TextBox()
        Me.txt_STOREDESC = New System.Windows.Forms.TextBox()
        Me.lbl_Tostore = New System.Windows.Forms.Label()
        Me.lbl_Mainstore = New System.Windows.Forms.Label()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TXT_PARTYNO = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dtp_Docdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmd_Docnohelp = New System.Windows.Forms.Button()
        Me.txt_Docno = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.AxfpSpread1 = New AxFPSpreadADO.AxfpSpread()
        Me.Txt_qty = New System.Windows.Forms.TextBox()
        Me.txt_Totalamount = New System.Windows.Forms.TextBox()
        Me.lbl_closingqty = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_Remarks = New System.Windows.Forms.TextBox()
        Me.lbl_Remarks = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButCANCEL = New System.Windows.Forms.Button()
        Me.ButOK = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AxfpSpread2 = New AxFPSpreadADO.AxfpSpread()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.LBL_SESSION = New System.Windows.Forms.Label()
        Me.CMB_SESSION = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_buffet = New System.Windows.Forms.TextBox()
        Me.cmd_buffet = New System.Windows.Forms.Button()
        Me.grp_issue2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_issue1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmbut.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.AxfpSpread2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp_issue2
        '
        Me.grp_issue2.BackColor = System.Drawing.Color.Transparent
        Me.grp_issue2.Controls.Add(Me.dtp_IndentDate)
        Me.grp_issue2.Controls.Add(Me.lbl_Docdate)
        Me.grp_issue2.Controls.Add(Me.cmd_IndentNoHelp)
        Me.grp_issue2.Controls.Add(Me.Txt_IndentNo)
        Me.grp_issue2.Controls.Add(Me.lbl_Docno)
        Me.grp_issue2.Controls.Add(Me.Label16)
        Me.grp_issue2.Controls.Add(Me.PictureBox2)
        Me.grp_issue2.Location = New System.Drawing.Point(18, 103)
        Me.grp_issue2.Name = "grp_issue2"
        Me.grp_issue2.Size = New System.Drawing.Size(315, 86)
        Me.grp_issue2.TabIndex = 381
        Me.grp_issue2.TabStop = False
        '
        'dtp_IndentDate
        '
        Me.dtp_IndentDate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_IndentDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_IndentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_IndentDate.Location = New System.Drawing.Point(161, 57)
        Me.dtp_IndentDate.Name = "dtp_IndentDate"
        Me.dtp_IndentDate.Size = New System.Drawing.Size(96, 21)
        Me.dtp_IndentDate.TabIndex = 384
        '
        'lbl_Docdate
        '
        Me.lbl_Docdate.AutoSize = True
        Me.lbl_Docdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Docdate.Location = New System.Drawing.Point(5, 57)
        Me.lbl_Docdate.Name = "lbl_Docdate"
        Me.lbl_Docdate.Size = New System.Drawing.Size(80, 15)
        Me.lbl_Docdate.TabIndex = 479
        Me.lbl_Docdate.Text = "INDENT DATE"
        '
        'cmd_IndentNoHelp
        '
        Me.cmd_IndentNoHelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_IndentNoHelp.Image = CType(resources.GetObject("cmd_IndentNoHelp.Image"), System.Drawing.Image)
        Me.cmd_IndentNoHelp.Location = New System.Drawing.Point(243, 20)
        Me.cmd_IndentNoHelp.Name = "cmd_IndentNoHelp"
        Me.cmd_IndentNoHelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_IndentNoHelp.TabIndex = 478
        '
        'Txt_IndentNo
        '
        Me.Txt_IndentNo.BackColor = System.Drawing.Color.Wheat
        Me.Txt_IndentNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_IndentNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_IndentNo.Location = New System.Drawing.Point(112, 21)
        Me.Txt_IndentNo.MaxLength = 15
        Me.Txt_IndentNo.Name = "Txt_IndentNo"
        Me.Txt_IndentNo.Size = New System.Drawing.Size(128, 21)
        Me.Txt_IndentNo.TabIndex = 477
        '
        'lbl_Docno
        '
        Me.lbl_Docno.AutoSize = True
        Me.lbl_Docno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Docno.Location = New System.Drawing.Point(5, 22)
        Me.lbl_Docno.Name = "lbl_Docno"
        Me.lbl_Docno.Size = New System.Drawing.Size(68, 15)
        Me.lbl_Docno.TabIndex = 476
        Me.lbl_Docno.Text = "INDENT NO"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(269, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 24)
        Me.Label16.TabIndex = 475
        Me.Label16.Text = "F4"
        Me.Label16.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(123, 50)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 474
        Me.PictureBox2.TabStop = False
        '
        'grp_issue1
        '
        Me.grp_issue1.BackColor = System.Drawing.Color.Transparent
        Me.grp_issue1.Controls.Add(Me.TXT_FROMSTORECODE)
        Me.grp_issue1.Controls.Add(Me.txt_FromStorename)
        Me.grp_issue1.Controls.Add(Me.cmd_fromStorecodeHelp)
        Me.grp_issue1.Controls.Add(Me.txt_storecode)
        Me.grp_issue1.Controls.Add(Me.txt_STOREDESC)
        Me.grp_issue1.Controls.Add(Me.lbl_Tostore)
        Me.grp_issue1.Controls.Add(Me.lbl_Mainstore)
        Me.grp_issue1.Controls.Add(Me.cmd_storecode)
        Me.grp_issue1.Location = New System.Drawing.Point(339, 103)
        Me.grp_issue1.Name = "grp_issue1"
        Me.grp_issue1.Size = New System.Drawing.Size(366, 73)
        Me.grp_issue1.TabIndex = 380
        Me.grp_issue1.TabStop = False
        '
        'TXT_FROMSTORECODE
        '
        Me.TXT_FROMSTORECODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_FROMSTORECODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_FROMSTORECODE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_FROMSTORECODE.Location = New System.Drawing.Point(97, 44)
        Me.TXT_FROMSTORECODE.MaxLength = 50
        Me.TXT_FROMSTORECODE.Name = "TXT_FROMSTORECODE"
        Me.TXT_FROMSTORECODE.Size = New System.Drawing.Size(64, 21)
        Me.TXT_FROMSTORECODE.TabIndex = 394
        '
        'txt_FromStorename
        '
        Me.txt_FromStorename.BackColor = System.Drawing.Color.Wheat
        Me.txt_FromStorename.Enabled = False
        Me.txt_FromStorename.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FromStorename.Location = New System.Drawing.Point(189, 44)
        Me.txt_FromStorename.MaxLength = 50
        Me.txt_FromStorename.Name = "txt_FromStorename"
        Me.txt_FromStorename.Size = New System.Drawing.Size(167, 21)
        Me.txt_FromStorename.TabIndex = 395
        '
        'cmd_fromStorecodeHelp
        '
        Me.cmd_fromStorecodeHelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_fromStorecodeHelp.Image = CType(resources.GetObject("cmd_fromStorecodeHelp.Image"), System.Drawing.Image)
        Me.cmd_fromStorecodeHelp.Location = New System.Drawing.Point(163, 11)
        Me.cmd_fromStorecodeHelp.Name = "cmd_fromStorecodeHelp"
        Me.cmd_fromStorecodeHelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_fromStorecodeHelp.TabIndex = 396
        '
        'txt_storecode
        '
        Me.txt_storecode.BackColor = System.Drawing.Color.Wheat
        Me.txt_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_storecode.Location = New System.Drawing.Point(96, 15)
        Me.txt_storecode.Name = "txt_storecode"
        Me.txt_storecode.Size = New System.Drawing.Size(64, 21)
        Me.txt_storecode.TabIndex = 377
        '
        'txt_STOREDESC
        '
        Me.txt_STOREDESC.BackColor = System.Drawing.Color.Wheat
        Me.txt_STOREDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_STOREDESC.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_STOREDESC.Location = New System.Drawing.Point(189, 13)
        Me.txt_STOREDESC.MaxLength = 15
        Me.txt_STOREDESC.Name = "txt_STOREDESC"
        Me.txt_STOREDESC.ReadOnly = True
        Me.txt_STOREDESC.Size = New System.Drawing.Size(168, 21)
        Me.txt_STOREDESC.TabIndex = 376
        '
        'lbl_Tostore
        '
        Me.lbl_Tostore.AutoSize = True
        Me.lbl_Tostore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Tostore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Tostore.Location = New System.Drawing.Point(6, 18)
        Me.lbl_Tostore.Name = "lbl_Tostore"
        Me.lbl_Tostore.Size = New System.Drawing.Size(83, 15)
        Me.lbl_Tostore.TabIndex = 378
        Me.lbl_Tostore.Text = "ISSUE STORE"
        '
        'lbl_Mainstore
        '
        Me.lbl_Mainstore.AutoSize = True
        Me.lbl_Mainstore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Mainstore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Mainstore.Location = New System.Drawing.Point(5, 46)
        Me.lbl_Mainstore.Name = "lbl_Mainstore"
        Me.lbl_Mainstore.Size = New System.Drawing.Size(78, 15)
        Me.lbl_Mainstore.TabIndex = 375
        Me.lbl_Mainstore.Text = "MAIN STORE"
        '
        'cmd_storecode
        '
        Me.cmd_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(163, 39)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 380
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.dtp_Docdate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Cmd_Docnohelp)
        Me.GroupBox1.Controls.Add(Me.txt_Docno)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 191)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(661, 43)
        Me.GroupBox1.TabIndex = 382
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.TXT_PARTYNO)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Location = New System.Drawing.Point(513, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(171, 56)
        Me.GroupBox4.TabIndex = 477
        Me.GroupBox4.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(121, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 26)
        Me.Button1.TabIndex = 45
        '
        'TXT_PARTYNO
        '
        Me.TXT_PARTYNO.BackColor = System.Drawing.Color.Lavender
        Me.TXT_PARTYNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_PARTYNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_PARTYNO.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.TXT_PARTYNO.Location = New System.Drawing.Point(65, 9)
        Me.TXT_PARTYNO.MaxLength = 200
        Me.TXT_PARTYNO.Name = "TXT_PARTYNO"
        Me.TXT_PARTYNO.Size = New System.Drawing.Size(56, 23)
        Me.TXT_PARTYNO.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(6, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 15)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "Party No. "
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(267, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 22)
        Me.Label4.TabIndex = 476
        Me.Label4.Text = "F4"
        Me.Label4.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(482, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 26)
        Me.PictureBox1.TabIndex = 475
        Me.PictureBox1.TabStop = False
        '
        'dtp_Docdate
        '
        Me.dtp_Docdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Docdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Docdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Docdate.Location = New System.Drawing.Point(373, 16)
        Me.dtp_Docdate.Name = "dtp_Docdate"
        Me.dtp_Docdate.Size = New System.Drawing.Size(109, 21)
        Me.dtp_Docdate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(297, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 378
        Me.Label2.Text = "ISSUE DATE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 15)
        Me.Label1.TabIndex = 375
        Me.Label1.Text = "ISSUE DOC NO"
        '
        'Cmd_Docnohelp
        '
        Me.Cmd_Docnohelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Docnohelp.Image = CType(resources.GetObject("Cmd_Docnohelp.Image"), System.Drawing.Image)
        Me.Cmd_Docnohelp.Location = New System.Drawing.Point(241, 13)
        Me.Cmd_Docnohelp.Name = "Cmd_Docnohelp"
        Me.Cmd_Docnohelp.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_Docnohelp.TabIndex = 21
        '
        'txt_Docno
        '
        Me.txt_Docno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Docno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Docno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Docno.Location = New System.Drawing.Point(108, 15)
        Me.txt_Docno.MaxLength = 15
        Me.txt_Docno.Name = "txt_Docno"
        Me.txt_Docno.Size = New System.Drawing.Size(132, 21)
        Me.txt_Docno.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.AxfpSpread1)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 241)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(666, 267)
        Me.GroupBox2.TabIndex = 383
        Me.GroupBox2.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(8, 234)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 27)
        Me.Button2.TabIndex = 490
        Me.Button2.Text = "Get Weight [F1]"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(5, 15)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(654, 209)
        Me.AxfpSpread1.TabIndex = 0
        '
        'Txt_qty
        '
        Me.Txt_qty.BackColor = System.Drawing.Color.Wheat
        Me.Txt_qty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_qty.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_qty.Location = New System.Drawing.Point(329, 11)
        Me.Txt_qty.MaxLength = 15
        Me.Txt_qty.Name = "Txt_qty"
        Me.Txt_qty.ReadOnly = True
        Me.Txt_qty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Txt_qty.Size = New System.Drawing.Size(87, 26)
        Me.Txt_qty.TabIndex = 385
        Me.Txt_qty.Text = "."
        '
        'txt_Totalamount
        '
        Me.txt_Totalamount.BackColor = System.Drawing.Color.Wheat
        Me.txt_Totalamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Totalamount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Totalamount.Location = New System.Drawing.Point(508, 11)
        Me.txt_Totalamount.MaxLength = 15
        Me.txt_Totalamount.Name = "txt_Totalamount"
        Me.txt_Totalamount.ReadOnly = True
        Me.txt_Totalamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Totalamount.Size = New System.Drawing.Size(84, 26)
        Me.txt_Totalamount.TabIndex = 384
        '
        'lbl_closingqty
        '
        Me.lbl_closingqty.AutoSize = True
        Me.lbl_closingqty.BackColor = System.Drawing.Color.Transparent
        Me.lbl_closingqty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_closingqty.Location = New System.Drawing.Point(9, 17)
        Me.lbl_closingqty.Name = "lbl_closingqty"
        Me.lbl_closingqty.Size = New System.Drawing.Size(80, 15)
        Me.lbl_closingqty.TabIndex = 478
        Me.lbl_closingqty.Text = "closingstock"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(26, 21)
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
        Me.txt_Remarks.Location = New System.Drawing.Point(114, 5)
        Me.txt_Remarks.MaxLength = 200
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(504, 32)
        Me.txt_Remarks.TabIndex = 14
        '
        'lbl_Remarks
        '
        Me.lbl_Remarks.AutoSize = True
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Remarks.Location = New System.Drawing.Point(26, 5)
        Me.lbl_Remarks.Name = "lbl_Remarks"
        Me.lbl_Remarks.Size = New System.Drawing.Size(70, 15)
        Me.lbl_Remarks.TabIndex = 43
        Me.lbl_Remarks.Text = "REMARKS :"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(495, 66)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(328, 25)
        Me.lbl_Freeze.TabIndex = 469
        Me.lbl_Freeze.Text = "Record Void  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.Cmd_Clear)
        Me.frmbut.Controls.Add(Me.cmd_Print)
        Me.frmbut.Controls.Add(Me.Cmd_Exit)
        Me.frmbut.Controls.Add(Me.Cmd_Add)
        Me.frmbut.Controls.Add(Me.Cmd_Freeze)
        Me.frmbut.Controls.Add(Me.Cmd_View)
        Me.frmbut.Location = New System.Drawing.Point(720, 114)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(136, 306)
        Me.frmbut.TabIndex = 470
        Me.frmbut.TabStop = False
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
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(7, 11)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Clear.TabIndex = 7
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'cmd_Print
        '
        Me.cmd_Print.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_Print.BackgroundImage = CType(resources.GetObject("cmd_Print.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Print.FlatAppearance.BorderSize = 0
        Me.cmd_Print.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Print.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Print.Location = New System.Drawing.Point(7, 155)
        Me.cmd_Print.Name = "cmd_Print"
        Me.cmd_Print.Size = New System.Drawing.Size(124, 46)
        Me.cmd_Print.TabIndex = 22
        Me.cmd_Print.Text = "Print[F10]"
        Me.cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Print.UseVisualStyleBackColor = False
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
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(7, 251)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Exit.TabIndex = 11
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
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(7, 59)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Add.TabIndex = 8
        Me.Cmd_Add.Text = "Add [F7]"
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
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(7, 203)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Freeze.TabIndex = 9
        Me.Cmd_Freeze.Text = "Void[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
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
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(7, 107)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_View.TabIndex = 10
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmdauth
        '
        Me.Cmdauth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmdauth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmdauth.FlatAppearance.BorderSize = 0
        Me.Cmdauth.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmdauth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmdauth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmdauth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.Color.Black
        Me.Cmdauth.Image = CType(resources.GetObject("Cmdauth.Image"), System.Drawing.Image)
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(728, 422)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(124, 46)
        Me.Cmdauth.TabIndex = 466
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdauth.UseVisualStyleBackColor = False
        Me.Cmdauth.Visible = False
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
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(728, 469)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(124, 46)
        Me.cmd_export.TabIndex = 467
        Me.cmd_export.Text = "Export"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        Me.cmd_export.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Silver
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.ButCANCEL)
        Me.GroupBox3.Controls.Add(Me.ButOK)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.AxfpSpread2)
        Me.GroupBox3.Location = New System.Drawing.Point(18, 252)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(663, 258)
        Me.GroupBox3.TabIndex = 471
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(688, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Label5"
        Me.Label5.Visible = False
        '
        'ButCANCEL
        '
        Me.ButCANCEL.Location = New System.Drawing.Point(437, 219)
        Me.ButCANCEL.Name = "ButCANCEL"
        Me.ButCANCEL.Size = New System.Drawing.Size(75, 30)
        Me.ButCANCEL.TabIndex = 3
        Me.ButCANCEL.Text = "CANCEL"
        Me.ButCANCEL.UseVisualStyleBackColor = True
        '
        'ButOK
        '
        Me.ButOK.Location = New System.Drawing.Point(344, 218)
        Me.ButOK.Name = "ButOK"
        Me.ButOK.Size = New System.Drawing.Size(75, 30)
        Me.ButOK.TabIndex = 2
        Me.ButOK.Text = "OK"
        Me.ButOK.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(285, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "CLOSING STOCK AT "
        '
        'AxfpSpread2
        '
        Me.AxfpSpread2.DataSource = Nothing
        Me.AxfpSpread2.Location = New System.Drawing.Point(19, 61)
        Me.AxfpSpread2.Name = "AxfpSpread2"
        Me.AxfpSpread2.OcxState = CType(resources.GetObject("AxfpSpread2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread2.Size = New System.Drawing.Size(779, 148)
        Me.AxfpSpread2.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(316, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 24)
        Me.Label6.TabIndex = 472
        Me.Label6.Text = "STOCK ISSUE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(263, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 15)
        Me.Label7.TabIndex = 473
        Me.Label7.Text = "Total Qty."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(437, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 15)
        Me.Label8.TabIndex = 474
        Me.Label8.Text = "Total Amt."
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.lbl_closingqty)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Txt_qty)
        Me.GroupBox5.Controls.Add(Me.txt_Totalamount)
        Me.GroupBox5.Location = New System.Drawing.Point(18, 514)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(661, 43)
        Me.GroupBox5.TabIndex = 475
        Me.GroupBox5.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(120, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 15)
        Me.Label9.TabIndex = 478
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.txt_Remarks)
        Me.GroupBox6.Controls.Add(Me.lbl_Remarks)
        Me.GroupBox6.Location = New System.Drawing.Point(18, 572)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(659, 59)
        Me.GroupBox6.TabIndex = 476
        Me.GroupBox6.TabStop = False
        '
        'LBL_SESSION
        '
        Me.LBL_SESSION.AutoSize = True
        Me.LBL_SESSION.BackColor = System.Drawing.Color.Transparent
        Me.LBL_SESSION.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_SESSION.Location = New System.Drawing.Point(63, 66)
        Me.LBL_SESSION.Name = "LBL_SESSION"
        Me.LBL_SESSION.Size = New System.Drawing.Size(58, 15)
        Me.LBL_SESSION.TabIndex = 480
        Me.LBL_SESSION.Text = "SESSION"
        Me.LBL_SESSION.Visible = False
        '
        'CMB_SESSION
        '
        Me.CMB_SESSION.BackColor = System.Drawing.Color.Wheat
        Me.CMB_SESSION.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_SESSION.Location = New System.Drawing.Point(127, 63)
        Me.CMB_SESSION.Name = "CMB_SESSION"
        Me.CMB_SESSION.Size = New System.Drawing.Size(117, 23)
        Me.CMB_SESSION.TabIndex = 481
        Me.CMB_SESSION.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(538, 175)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 15)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Buffet "
        '
        'txt_buffet
        '
        Me.txt_buffet.BackColor = System.Drawing.Color.Lavender
        Me.txt_buffet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_buffet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_buffet.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txt_buffet.Location = New System.Drawing.Point(598, 173)
        Me.txt_buffet.MaxLength = 200
        Me.txt_buffet.Name = "txt_buffet"
        Me.txt_buffet.Size = New System.Drawing.Size(56, 23)
        Me.txt_buffet.TabIndex = 46
        '
        'cmd_buffet
        '
        Me.cmd_buffet.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_buffet.Image = CType(resources.GetObject("cmd_buffet.Image"), System.Drawing.Image)
        Me.cmd_buffet.Location = New System.Drawing.Point(654, 172)
        Me.cmd_buffet.Name = "cmd_buffet"
        Me.cmd_buffet.Size = New System.Drawing.Size(23, 26)
        Me.cmd_buffet.TabIndex = 46
        '
        'Frm_StockIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(870, 640)
        Me.Controls.Add(Me.cmd_buffet)
        Me.Controls.Add(Me.txt_buffet)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CMB_SESSION)
        Me.Controls.Add(Me.LBL_SESSION)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.cmd_export)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.grp_issue2)
        Me.Controls.Add(Me.grp_issue1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_StockIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_StockIssue"
        Me.grp_issue2.ResumeLayout(False)
        Me.grp_issue2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_issue1.ResumeLayout(False)
        Me.grp_issue1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmbut.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.AxfpSpread2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp_issue2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents grp_issue1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dtp_Docdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Docnohelp As System.Windows.Forms.Button
    Friend WithEvents txt_Docno As System.Windows.Forms.TextBox
    Friend WithEvents txt_storecode As System.Windows.Forms.TextBox
    Friend WithEvents txt_STOREDESC As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Tostore As System.Windows.Forms.Label
    Friend WithEvents lbl_Mainstore As System.Windows.Forms.Label
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents Txt_IndentNo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Docno As System.Windows.Forms.Label
    Friend WithEvents cmd_IndentNoHelp As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AxfpSpread1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_Docdate As System.Windows.Forms.Label
    Friend WithEvents dtp_IndentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXT_FROMSTORECODE As System.Windows.Forms.TextBox
    Friend WithEvents txt_FromStorename As System.Windows.Forms.TextBox
    Friend WithEvents cmd_fromStorecodeHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_qty As System.Windows.Forms.TextBox
    Friend WithEvents txt_Totalamount As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Remarks As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents AxfpSpread2 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButCANCEL As System.Windows.Forms.Button
    Friend WithEvents ButOK As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_closingqty As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_PARTYNO As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LBL_SESSION As Label
    Friend WithEvents CMB_SESSION As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txt_buffet As TextBox
    Friend WithEvents cmd_buffet As Button
End Class
