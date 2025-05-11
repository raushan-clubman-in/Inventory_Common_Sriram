Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Public Class CoporateDet
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
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMemName As System.Windows.Forms.TextBox
    Friend WithEvents txt_CorpCode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_StoreCode As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmdCorpCode As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents cmd_rpt As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CbTrnType As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Docno As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmd_Docnohelp As System.Windows.Forms.Button
    Friend WithEvents txt_Docno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Docdate As System.Windows.Forms.Label
    Friend WithEvents dtp_Docdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtNameOfCorp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNomSL As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtNomRepNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DTPDateOfJoin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtValYear As System.Windows.Forms.TextBox
    Friend WithEvents TxtMemCode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_StoreDescription As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnSlHelp As System.Windows.Forms.Button
    Friend WithEvents BtnMCode As System.Windows.Forms.Button
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CoporateDet))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.txtMemName = New System.Windows.Forms.TextBox()
        Me.txt_CorpCode = New System.Windows.Forms.TextBox()
        Me.lbl_StoreCode = New System.Windows.Forms.Label()
        Me.cmdCorpCode = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSlHelp = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtMemCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtValYear = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DTPDateOfJoin = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtNomRepNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtNomSL = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNameOfCorp = New System.Windows.Forms.TextBox()
        Me.lbl_Docno = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmd_Docnohelp = New System.Windows.Forms.Button()
        Me.txt_Docno = New System.Windows.Forms.TextBox()
        Me.lbl_Docdate = New System.Windows.Forms.Label()
        Me.dtp_Docdate = New System.Windows.Forms.DateTimePicker()
        Me.CbTrnType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_StoreDescription = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.cmd_rpt = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.BtnMCode = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(397, 73)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(244, 18)
        Me.lbl_Heading.TabIndex = 9
        Me.lbl_Heading.Text = "CORPORATE NOMINEE DETAILS"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMemName
        '
        Me.txtMemName.BackColor = System.Drawing.Color.White
        Me.txtMemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemName.Location = New System.Drawing.Point(265, 345)
        Me.txtMemName.MaxLength = 200
        Me.txtMemName.Name = "txtMemName"
        Me.txtMemName.Size = New System.Drawing.Size(249, 21)
        Me.txtMemName.TabIndex = 21
        '
        'txt_CorpCode
        '
        Me.txt_CorpCode.BackColor = System.Drawing.Color.White
        Me.txt_CorpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CorpCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_CorpCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CorpCode.Location = New System.Drawing.Point(265, 120)
        Me.txt_CorpCode.MaxLength = 20
        Me.txt_CorpCode.Name = "txt_CorpCode"
        Me.txt_CorpCode.Size = New System.Drawing.Size(71, 21)
        Me.txt_CorpCode.TabIndex = 14
        '
        'lbl_StoreCode
        '
        Me.lbl_StoreCode.AutoSize = True
        Me.lbl_StoreCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_StoreCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StoreCode.Location = New System.Drawing.Point(75, 123)
        Me.lbl_StoreCode.Name = "lbl_StoreCode"
        Me.lbl_StoreCode.Size = New System.Drawing.Size(113, 15)
        Me.lbl_StoreCode.TabIndex = 11
        Me.lbl_StoreCode.Text = "CORPORATE CODE"
        '
        'cmdCorpCode
        '
        Me.cmdCorpCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCorpCode.Image = CType(resources.GetObject("cmdCorpCode.Image"), System.Drawing.Image)
        Me.cmdCorpCode.Location = New System.Drawing.Point(338, 119)
        Me.cmdCorpCode.Name = "cmdCorpCode"
        Me.cmdCorpCode.Size = New System.Drawing.Size(30, 24)
        Me.cmdCorpCode.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.BtnMCode)
        Me.GroupBox1.Controls.Add(Me.btnSlHelp)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.TxtMemCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtValYear)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.DTPDateOfJoin)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtNomRepNo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TxtNomSL)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtNameOfCorp)
        Me.GroupBox1.Controls.Add(Me.lbl_Docno)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmd_Docnohelp)
        Me.GroupBox1.Controls.Add(Me.txt_Docno)
        Me.GroupBox1.Controls.Add(Me.lbl_Docdate)
        Me.GroupBox1.Controls.Add(Me.dtp_Docdate)
        Me.GroupBox1.Controls.Add(Me.CbTrnType)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMemName)
        Me.GroupBox1.Controls.Add(Me.cmdCorpCode)
        Me.GroupBox1.Controls.Add(Me.lbl_StoreCode)
        Me.GroupBox1.Controls.Add(Me.lbl_StoreDescription)
        Me.GroupBox1.Controls.Add(Me.txt_CorpCode)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(223, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(635, 535)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'btnSlHelp
        '
        Me.btnSlHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlHelp.Image = CType(resources.GetObject("btnSlHelp.Image"), System.Drawing.Image)
        Me.btnSlHelp.Location = New System.Drawing.Point(421, 182)
        Me.btnSlHelp.Name = "btnSlHelp"
        Me.btnSlHelp.Size = New System.Drawing.Size(30, 24)
        Me.btnSlHelp.TabIndex = 17
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(78, 397)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(480, 100)
        Me.GroupBox3.TabIndex = 495
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(199, 63)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(143, 15)
        Me.Label12.TabIndex = 497
        Me.Label12.Text = "EX. MEMBERSHIP CODE "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(199, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 15)
        Me.Label11.TabIndex = 496
        Me.Label11.Text = "EX. MEMBERSHIP NAME"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(149, 15)
        Me.Label9.TabIndex = 495
        Me.Label9.Text = "EX. MEMBERSHIP CODE : "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(147, 15)
        Me.Label10.TabIndex = 494
        Me.Label10.Text = "EX. MEMBERSHIP NAME :"
        '
        'TxtMemCode
        '
        Me.TxtMemCode.BackColor = System.Drawing.Color.White
        Me.TxtMemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMemCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemCode.Location = New System.Drawing.Point(265, 313)
        Me.TxtMemCode.MaxLength = 100
        Me.TxtMemCode.Name = "TxtMemCode"
        Me.TxtMemCode.Size = New System.Drawing.Size(121, 21)
        Me.TxtMemCode.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(75, 318)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 15)
        Me.Label1.TabIndex = 493
        Me.Label1.Text = "MEMBERSHIP CODE"
        '
        'TxtValYear
        '
        Me.TxtValYear.BackColor = System.Drawing.Color.White
        Me.TxtValYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtValYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtValYear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValYear.Location = New System.Drawing.Point(265, 285)
        Me.TxtValYear.MaxLength = 5
        Me.TxtValYear.Name = "TxtValYear"
        Me.TxtValYear.Size = New System.Drawing.Size(121, 21)
        Me.TxtValYear.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(75, 288)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 15)
        Me.Label8.TabIndex = 491
        Me.Label8.Text = "VALIDITY IN YEAR"
        '
        'DTPDateOfJoin
        '
        Me.DTPDateOfJoin.CustomFormat = "dd/MMM/yyyy"
        Me.DTPDateOfJoin.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPDateOfJoin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPDateOfJoin.Location = New System.Drawing.Point(265, 248)
        Me.DTPDateOfJoin.Name = "DTPDateOfJoin"
        Me.DTPDateOfJoin.Size = New System.Drawing.Size(130, 26)
        Me.DTPDateOfJoin.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(75, 255)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 15)
        Me.Label7.TabIndex = 489
        Me.Label7.Text = "DATE OF JOINING"
        '
        'TxtNomRepNo
        '
        Me.TxtNomRepNo.BackColor = System.Drawing.Color.White
        Me.TxtNomRepNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomRepNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomRepNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomRepNo.Location = New System.Drawing.Point(265, 216)
        Me.TxtNomRepNo.MaxLength = 100
        Me.TxtNomRepNo.Name = "TxtNomRepNo"
        Me.TxtNomRepNo.Size = New System.Drawing.Size(153, 21)
        Me.TxtNomRepNo.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(75, 222)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(156, 15)
        Me.Label6.TabIndex = 487
        Me.Label6.Text = "NOMINEE FEE RECEIPT NO."
        '
        'TxtNomSL
        '
        Me.TxtNomSL.BackColor = System.Drawing.Color.White
        Me.TxtNomSL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNomSL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomSL.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNomSL.Location = New System.Drawing.Point(265, 184)
        Me.TxtNomSL.MaxLength = 20
        Me.TxtNomSL.Name = "TxtNomSL"
        Me.TxtNomSL.Size = New System.Drawing.Size(153, 21)
        Me.TxtNomSL.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(75, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 485
        Me.Label5.Text = "NOMINEE SL. NO."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(75, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(157, 15)
        Me.Label4.TabIndex = 484
        Me.Label4.Text = "NAME OF THE CORPORATE"
        '
        'TxtNameOfCorp
        '
        Me.TxtNameOfCorp.BackColor = System.Drawing.Color.White
        Me.TxtNameOfCorp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNameOfCorp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNameOfCorp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameOfCorp.Location = New System.Drawing.Point(265, 152)
        Me.TxtNameOfCorp.MaxLength = 500
        Me.TxtNameOfCorp.Name = "TxtNameOfCorp"
        Me.TxtNameOfCorp.ReadOnly = True
        Me.TxtNameOfCorp.Size = New System.Drawing.Size(249, 21)
        Me.TxtNameOfCorp.TabIndex = 483
        '
        'lbl_Docno
        '
        Me.lbl_Docno.AutoSize = True
        Me.lbl_Docno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Docno.Location = New System.Drawing.Point(74, 80)
        Me.lbl_Docno.Name = "lbl_Docno"
        Me.lbl_Docno.Size = New System.Drawing.Size(52, 15)
        Me.lbl_Docno.TabIndex = 478
        Me.lbl_Docno.Text = "DOC NO"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(297, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 22)
        Me.Label3.TabIndex = 482
        Me.Label3.Text = "F4"
        Me.Label3.Visible = False
        '
        'cmd_Docnohelp
        '
        Me.cmd_Docnohelp.Image = CType(resources.GetObject("cmd_Docnohelp.Image"), System.Drawing.Image)
        Me.cmd_Docnohelp.Location = New System.Drawing.Point(266, 74)
        Me.cmd_Docnohelp.Name = "cmd_Docnohelp"
        Me.cmd_Docnohelp.Size = New System.Drawing.Size(30, 24)
        Me.cmd_Docnohelp.TabIndex = 12
        '
        'txt_Docno
        '
        Me.txt_Docno.BackColor = System.Drawing.Color.White
        Me.txt_Docno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Docno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Docno.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Docno.Location = New System.Drawing.Point(142, 75)
        Me.txt_Docno.MaxLength = 15
        Me.txt_Docno.Name = "txt_Docno"
        Me.txt_Docno.Size = New System.Drawing.Size(123, 22)
        Me.txt_Docno.TabIndex = 11
        '
        'lbl_Docdate
        '
        Me.lbl_Docdate.AutoSize = True
        Me.lbl_Docdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Docdate.Location = New System.Drawing.Point(331, 79)
        Me.lbl_Docdate.Name = "lbl_Docdate"
        Me.lbl_Docdate.Size = New System.Drawing.Size(64, 15)
        Me.lbl_Docdate.TabIndex = 480
        Me.lbl_Docdate.Text = "DOC DATE"
        '
        'dtp_Docdate
        '
        Me.dtp_Docdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtp_Docdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Docdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Docdate.Location = New System.Drawing.Point(401, 73)
        Me.dtp_Docdate.Name = "dtp_Docdate"
        Me.dtp_Docdate.Size = New System.Drawing.Size(113, 26)
        Me.dtp_Docdate.TabIndex = 13
        '
        'CbTrnType
        '
        Me.CbTrnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbTrnType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbTrnType.FormattingEnabled = True
        Me.CbTrnType.Items.AddRange(New Object() {"New Nominee", "Nominee Inclusion", "Nominee Renewal"})
        Me.CbTrnType.Location = New System.Drawing.Point(265, 41)
        Me.CbTrnType.Name = "CbTrnType"
        Me.CbTrnType.Size = New System.Drawing.Size(139, 21)
        Me.CbTrnType.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(74, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 15)
        Me.Label2.TabIndex = 474
        Me.Label2.Text = "TYPE OF TRANSACTION"
        '
        'lbl_StoreDescription
        '
        Me.lbl_StoreDescription.AutoSize = True
        Me.lbl_StoreDescription.BackColor = System.Drawing.Color.Transparent
        Me.lbl_StoreDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_StoreDescription.Location = New System.Drawing.Point(75, 349)
        Me.lbl_StoreDescription.Name = "lbl_StoreDescription"
        Me.lbl_StoreDescription.Size = New System.Drawing.Size(120, 15)
        Me.lbl_StoreDescription.TabIndex = 13
        Me.lbl_StoreDescription.Text = "MEMBERSHIP NAME"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(625, 42)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(319, 25)
        Me.lbl_Freeze.TabIndex = 14
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Freeze.Visible = False
        '
        'chk_excel
        '
        Me.chk_excel.BackColor = System.Drawing.Color.Transparent
        Me.chk_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_excel.Location = New System.Drawing.Point(780, 467)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(72, 24)
        Me.chk_excel.TabIndex = 466
        Me.chk_excel.Text = "Excel"
        Me.chk_excel.UseVisualStyleBackColor = False
        Me.chk_excel.Visible = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = Global.Inventory.My.Resources.Resources._Exit
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(11, 324)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(123, 56)
        Me.Cmd_Exit.TabIndex = 8
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = Global.Inventory.My.Resources.Resources.view
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(10, 203)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(123, 56)
        Me.Cmd_View.TabIndex = 7
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Image = Global.Inventory.My.Resources.Resources.Delete
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(10, 141)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(123, 56)
        Me.Cmd_Freeze.TabIndex = 6
        Me.Cmd_Freeze.Text = "Void[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = Global.Inventory.My.Resources.Resources.save
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(9, 80)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(124, 56)
        Me.Cmd_Add.TabIndex = 4
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = Global.Inventory.My.Resources.Resources.Clear
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(8, 21)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(125, 56)
        Me.Cmd_Clear.TabIndex = 5
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.Transparent
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Image = Global.Inventory.My.Resources.Resources.excel
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(12, 262)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(122, 56)
        Me.cmd_export.TabIndex = 16
        Me.cmd_export.Text = "Export"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        '
        'cmd_rpt
        '
        Me.cmd_rpt.BackColor = System.Drawing.Color.Transparent
        Me.cmd_rpt.BackgroundImage = Global.Inventory.My.Resources.Resources.view
        Me.cmd_rpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_rpt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_rpt.ForeColor = System.Drawing.Color.Black
        Me.cmd_rpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_rpt.Location = New System.Drawing.Point(6, 448)
        Me.cmd_rpt.Name = "cmd_rpt"
        Me.cmd_rpt.Size = New System.Drawing.Size(123, 56)
        Me.cmd_rpt.TabIndex = 467
        Me.cmd_rpt.Text = "Report"
        Me.cmd_rpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_rpt.UseVisualStyleBackColor = False
        Me.cmd_rpt.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmd_auth)
        Me.GroupBox2.Controls.Add(Me.cmd_rpt)
        Me.GroupBox2.Controls.Add(Me.cmd_export)
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Location = New System.Drawing.Point(864, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(140, 518)
        Me.GroupBox2.TabIndex = 468
        Me.GroupBox2.TabStop = False
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cmd_auth.ForeColor = System.Drawing.Color.Black
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.Location = New System.Drawing.Point(5, 398)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(124, 56)
        Me.cmd_auth.TabIndex = 469
        Me.cmd_auth.Text = "Authorize"
        Me.cmd_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_auth.UseVisualStyleBackColor = False
        Me.cmd_auth.Visible = False
        '
        'BtnMCode
        '
        Me.BtnMCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMCode.Image = CType(resources.GetObject("BtnMCode.Image"), System.Drawing.Image)
        Me.BtnMCode.Location = New System.Drawing.Point(387, 312)
        Me.BtnMCode.Name = "BtnMCode"
        Me.BtnMCode.Size = New System.Drawing.Size(30, 24)
        Me.BtnMCode.TabIndex = 496
        '
        'CoporateDet
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1024, 738)
        Me.ControlBox = False
        Me.Controls.Add(Me.chk_excel)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "CoporateDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MASTER[STORE MASTER]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    'FINAL
    Dim dr As DataRow
    Dim dc As DataColumn
    Dim pageno As Integer
    Dim pagesize As Integer

    Private Sub Store_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Resize_Form()
        txt_CorpCode.Enabled = True
        txt_CorpCode.ReadOnly = False
        txtMemName.ReadOnly = False

        If gUserCategory <> "S" Then
            Call GetRights()
        End If

        docnofill()
    End Sub

    Private Sub docnofill()
        Dim dtl As New DataTable
        Dim docstr As String
        docstr = "select ISNULL(max(convert(int,docno)),0) as max from CORPORATE_DET"

        dtl = gconnection.GetValues(docstr)
        If dtl.Rows.Count > 0 Then
            txt_Docno.Text = Val(dtl.Rows(0).Item("max").ToString) + 1
        Else
            txt_Docno.Text = 1
        End If
    End Sub

    Private Sub slnofill()
        Dim dtl As New DataTable
        Dim docstr As String
        Dim slno As Integer
        If Mid(Cmd_Add.Text, 1, 1) = "A" Then
            docstr = "select max(substring(SLNO,LEN(SLNO)-2,LEN(SLNO))) AS MAX from CORPORATE_DET WHERE CORPORATECODE='" & txt_CorpCode.Text & "' AND isnull(VOID,'N')<>'Y'"

            dtl = gconnection.GetValues(docstr)
            If dtl.Rows.Count > 0 Then
                TxtNomSL.Text = txt_CorpCode.Text & "/" & Format(Val(dtl.Rows(0).Item("MAX").ToString) + 1, "000")
                slno = Val(dtl.Rows(0).Item("MAX").ToString) + 1
            Else
                TxtNomSL.Text = txt_CorpCode.Text & "/" & Format(1, "000")
                slno = 1
            End If
            docstr = "select CMNomembers from CORPORATEMASTER where isnull(freeze,'N')<>'Y' and cmCORPORATECODE='" & txt_CorpCode.Text & "'"
            dtl = gconnection.GetValues(docstr)
            If dtl.Rows.Count > 0 Then
                If slno <= Val(dtl.Rows(0).Item("CMNomembers").ToString) Then

                Else
                    MessageBox.Show(" Maximum nominee for this Exceed", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TxtNomSL.Text = ""
                    txt_CorpCode.Text = ""
                    TxtNameOfCorp.Text = ""
                    ' Call txt_StoreCode_Validated(txt_CorpCode, EventArgs)
                End If
            Else
                MessageBox.Show(" Maximum nominee for this Exceed", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TxtNomSL.Text = ""
                txt_CorpCode.Text = ""
                TxtNameOfCorp.Text = ""
            End If

            TxtNomSL.ReadOnly = True
        End If
        
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL, EX_MEM_CODE, EX_MEM_NAME, NEW_MEM_CODE, NEW_MEM_NAME As String
        If CbTrnType.Text = "Nominee Inclusion" Then
            EX_MEM_CODE = Label11.Text
            EX_MEM_NAME = Label12.Text
            ' NEW_MEM_CODE, NEW_MEM_NAME
        Else
            EX_MEM_CODE = TxtMemCode.Text
            EX_MEM_NAME = txtMemName.Text
        End If

        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub

           

            strSQL = " INSERT INTO CORPORATE_DET (TRANSTYPE,DOCNO,CORPORATECODE,DOCDATE,EX_MEM_CODE,NEW_MEM_CODE,NEW_MEM_NAME,EX_MEM_NAME,RECEIPT_NO,DATE_OF_jOIN,NO_OF_YEARS,EXPIRYDATE,SLNO,VOID,ADDUSER,ADDDATE)"
            strSQL = strSQL & " VALUES ( '" & Trim(CbTrnType.Text) & "','" & txt_Docno.Text & "','" & txt_CorpCode.Text & "','" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "','" & EX_MEM_CODE & "','" & TxtMemCode.Text & "','" & txtMemName.Text & "','" & EX_MEM_NAME & "','" & TxtNomRepNo.Text & "','" & Format(CDate(DTPDateOfJoin.Value), "dd-MMM-yyyy") & "','" & TxtValYear.Text & "',cast(year('" & Format(CDate(DTPDateOfJoin.Value), "dd-MMM-yyyy") & "')+" & TxtValYear.Text & " as varchar)+'-'+ cast(month('" & Format(CDate(DTPDateOfJoin.Value), "dd-MMM-yyyy") & "') as varchar)+'-'+cast(day('" & Format(CDate(DTPDateOfJoin.Value), "dd-MMM-yyyy") & "') as varchar)"

            '' 
            strSQL = strSQL & " ,'" & TxtNomSL.Text & "',"
            strSQL = strSQL & " 'N','" & Trim(gUsername) & "',getDate())"
            gconnection.dataOperation(1, strSQL, )
            If CbTrnType.Text <> "New Nominee" Then
                strSQL = "update CORPORATE_DET set VOID='Y',VOIDDATE=getDate(),VOIDUSER='" & gUsername & "' where DOCNO<'" & Trim(txt_Docno.Text) & "' and slno= '" & TxtNomSL.Text & "' and CORPORATECODE='" & txt_CorpCode.Text & "'"
                gconnection.dataOperation(6, strSQL, )
            End If
            strSQL = "update membermaster set NomSLNO='" & TxtNomSL.Text & "' where mcode='" & Trim(TxtMemCode.Text) & "' and corporatecode= '" & txt_CorpCode.Text & "'"
            gconnection.dataOperation(6, strSQL, )

            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                End If
            End If
            strSQL = "UPDATE  CORPORATE_DET "
            strSQL = strSQL & " SET RECEIPT_NO='" & Replace(Trim(TxtNomRepNo.Text), "'", "") & "',EX_MEM_CODE= '" & EX_MEM_CODE & "',NEW_MEM_CODE='" & TxtMemCode.Text & "',NEW_MEM_NAME='" & txtMemName.Text & "',EX_MEM_NAME='" & EX_MEM_NAME & "'"
            strSQL = strSQL & ", UPDATEUSER='" & Trim(gUsername) & "',updatedate=getDate(),void='N'"
            strSQL = strSQL & " WHERE docno = '" & Trim(txt_Docno.Text) & "' and slno= '" & TxtNomSL.Text & "'"
            gconnection.dataOperation(2, strSQL, "StoreMaster")

            strSQL = "update membermaster set NomSLNO='" & TxtNomSL.Text & "' where mcode='" & Trim(TxtMemCode.Text) & "' and corporatecode= '" & txt_CorpCode.Text & "'"
            gconnection.dataOperation(6, strSQL, )

            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"

        End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidationD() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
            sqlstring = "UPDATE  CORPORATE_DET "
            sqlstring = sqlstring & " SET void= 'Y',voiduser='" & gUsername & " ', voiddate=getDate()"
            sqlstring = sqlstring & "  WHERE docno = '" & Trim(txt_Docno.Text) & "' and slno= '" & TxtNomSL.Text & "'"
            gconnection.dataOperation(3, sqlstring, "StoreMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
            'Else
            '    sqlstring = "UPDATE  StoreMaster "
            '    sqlstring = sqlstring & " SET Freeze= 'N',Adduser='" & gUsername & " ', Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
            '    sqlstring = sqlstring & " WHERE Storecode = '" & Trim(txt_CorpCode.Text) & "'"
            '    gconnection.dataOperation(4, sqlstring, "StoreMaster")
            '    Me.Cmd_Clear_Click(sender, e)
            '    Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        Cmd_Freeze.Enabled = True
        CbTrnType.SelectedIndex = 0
        txt_CorpCode.Text = ""
        TxtNameOfCorp.Text = ""
        TxtNomSL.Text = ""
        TxtNomRepNo.Text = ""
        TxtValYear.Text = ""
        TxtMemCode.Text = ""
        txtMemName.Text = ""
        dtp_Docdate.Value = Date.Now
        DTPDateOfJoin.Value = Date.Now
        txt_CorpCode.Enabled = True
        txt_CorpCode.ReadOnly = False
        txtMemName.ReadOnly = False
        TxtNomRepNo.ReadOnly = False
        TxtValYear.ReadOnly = False
        TxtMemCode.ReadOnly = False
        GroupBox3.Visible = False
        Label11.Text = ""
        Label12.Text = ""
        BtnMCode.Enabled = True
        CbTrnType.Enabled = True
        txt_Docno.ReadOnly = False
        dtp_Docdate.Enabled = True
        txt_CorpCode.ReadOnly = False
        TxtNomSL.ReadOnly = False
        DTPDateOfJoin.Enabled = True

        Me.Cmd_Add.Enabled = True
        Me.Cmd_Freeze.Enabled = True

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        docnofill()
        txt_CorpCode.Focus()
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Store Master"
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
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
                If Right(x) = "P" Then
                    ' Me.cmd_auth.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        'gPrint = False
        ''If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Store Master") = MsgBoxResult.Yes Then
        'Dim rViewer As New Viewer
        'Dim sqlstring, SSQL As String
        'Dim r As New Rpt_StoreMaster
        'sqlstring = "SELECT * FROM storemaster order by Storedesc  "
        'gconnection.getDataSet(sqlstring, "storemaster")
        'If gdataset.Tables("storemaster").Rows.Count > 0 Then
        '    If chk_excel.Checked = True Then
        '        Dim exp As New exportexcel
        '        exp.Show()
        '        Call exp.export(sqlstring, "STORE MASTER ", "")
        '    Else
        '        rViewer.ssql = sqlstring
        '        rViewer.Report = r
        '        rViewer.TableName = "storemaster"
        '        Dim textobj1 As TextObject
        '        textobj1 = r.ReportDefinition.ReportObjects("Text13")
        '        textobj1.Text = MyCompanyName
        '        Dim textobj2 As TextObject
        '        textobj2 = r.ReportDefinition.ReportObjects("Text21")
        '        textobj2.Text = gUsername
        '        rViewer.Show()
        '    End If
        'Else
        '    MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        'End If
        ''Else
        '' PRINTOPERATION()
        '' End If
        Dim FRM As New ReportDesigner
        If txt_Docno.Text.Length > 0 Then
            tables = " FROM CORPORATE_DET WHERE DOCDATE ='" & txt_CorpCode.Text & "' "
        Else
            tables = "FROM CORPORATE_DET "
        End If
        Gheader = "CORPORATE DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"DOCNO", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"TRANSTYPE", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"DOCDATE", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CORPORATECODE", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"EX_MEM_CODE", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"EX_MEM_NAME", "50"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"NEW_MEM_CODE", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"NEW_MEM_NAME", "50"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"RECEIPT_NO", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"DATE_OF_jOIN", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"NO_OF_YEARS", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"EXPIRYDATE", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SLNO", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"VOID", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adduser", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adddate", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEDATE", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Store_Master_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call Cmd_Freeze_Click(Cmd_Freeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F10 Then
            'Call cmd_Print_Click(cmd_auth, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F4 Then
            Call cmdStoreCode_Click(cmdCorpCode, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub

    Private Sub cmdStoreCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCorpCode.Click
        gSQLString = "select CMCorporateCode ,CMCorporateName from CORPORATEMASTER "

        M_WhereCondition = " where ISNULL(freeze,'N')<>'Y' "


        Dim vform As New ListOperattion1
        vform.Field = "CMCorporateCode,CMCorporateName"
        vform.vFormatstring = "         CORPORATE CODE             |                  CORPORATE NAME                                                                                                   "
        vform.vCaption = "CORPORATE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_CorpCode.Text = Trim(vform.keyfield & "")
            Call txt_StoreCode_Validated(txt_CorpCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_StoreCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_CorpCode.KeyDown
        If e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If cmdCorpCode.Enabled = True Then
                If txt_CorpCode.Text = "" Then
                    search = Trim(txt_CorpCode.Text)
                    Call cmdStoreCode_Click(cmdCorpCode, e)
                End If
            End If
        End If
    End Sub

    Private Sub txt_StoreDesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMemName.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            ' Opt_Mainstore.Focus()
        End If
    End Sub

    Private Sub txt_StoreCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_CorpCode.Validated

        If CbTrnType.Text <> "" Then
            If Trim(txt_CorpCode.Text) <> "" Then
                sqlstring = "select CMCorporateCode ,CMCorporateName from CORPORATEMASTER WHERE CMCorporateCode='" & Trim(txt_CorpCode.Text) & "' AND ISNULL(FREEZE,'N')<>'Y'"
                gconnection.getDataSet(sqlstring, "CORPORATEMASTER")
                If gdataset.Tables("CORPORATEMASTER").Rows.Count > 0 Then
                    txt_CorpCode.Text = Trim(gdataset.Tables("CORPORATEMASTER").Rows(0).Item("CMCorporateCode"))
                    TxtNameOfCorp.Text = Trim(gdataset.Tables("CORPORATEMASTER").Rows(0).Item("CMCorporateName"))

                    If CbTrnType.Text = "New Nominee" Then
                        slnofill()
                        If txt_CorpCode.Text = "" Then
                            txt_CorpCode.Focus()
                        Else
                            TxtNomRepNo.Focus()
                        End If
                    Else
                        If CbTrnType.Text = "Nominee Inclusion" Then
                            ' TxtNomSL.Text = ""
                            TxtNomSL.ReadOnly = True
                            TxtNomSL.Focus()
                        Else
                            TxtNomSL.Text = ""
                            TxtNomSL.ReadOnly = False
                            TxtNomSL.Focus()
                        End If
                        
                    End If

                End If
            End If
        Else
            'MsgBox("Plz select Transaction Type first !", )
            MessageBox.Show("Plz select Transaction Type first ! ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

      
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(CbTrnType.Text) = "" Then
            MessageBox.Show(" Doc. No. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CbTrnType.Focus()
            Exit Sub
        End If

        If Trim(txt_Docno.Text) = "" Then
            MessageBox.Show(" Doc. No. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CorpCode.Focus()
            Exit Sub
        End If

        If Trim(txt_CorpCode.Text) = "" Then
            MessageBox.Show(" Corporate Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CorpCode.Focus()
            Exit Sub
        End If
        If Trim(TxtNameOfCorp.Text) = "" Then
            MessageBox.Show(" Corporate Desc. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CorpCode.Focus()
            Exit Sub
        End If

        If Trim(TxtNomSL.Text) = "" Then
            MessageBox.Show("Nominee Sl. No. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtNomSL.Focus()
            Exit Sub
        Else
            Dim docstr As String

            Dim dtl As New DataTable
            docstr = "select CMNomembers from CORPORATEMASTER where isnull(freeze,'N')<>'Y' and cmCORPORATECODE='" & txt_CorpCode.Text & "'"
            dtl = gconnection.GetValues(docstr)
            If dtl.Rows.Count > 0 Then
                Dim Sl As String()
                Sl = Split(TxtNomSL.Text, "/")
                If Val(Sl(1)) <= Val(dtl.Rows(0).Item("CMNomembers").ToString) Then

                Else
                    MessageBox.Show(" Maximum nominee for this Exceed", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TxtNomSL.Focus()
                    Exit Sub
                End If
            Else
                MessageBox.Show(" Maximum nominee for this Exceed", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TxtNomSL.Focus()
                Exit Sub
            End If
        End If


        If Trim(TxtNomRepNo.Text) = "" Then
            MessageBox.Show(" Nominee Fee Receipt No. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtNomRepNo.Focus()
            Exit Sub
        Else
            'Dim docstr As String

            'Dim dtl As New DataTable
            'docstr = "select* from JOURNALENTRY where instrumentno='" & TxtNomRepNo.Text & "' and isnull(Void,'')='Y'"
            'dtl = gconnection.GetValues(docstr)
            'If dtl.Rows.Count > 0 Then
            'Else
            '    MessageBox.Show(" Nominee Fee Receipt No. Not Exceed ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    TxtNomRepNo.Focus()
            '    Exit Sub
            'End If
        End If

        If Trim(TxtMemCode.Text) <> "" Then
            sqlstring = "SELECT * FROM CORPORATE_DET WHERE NEW_MEM_CODE='" & Trim(TxtMemCode.Text) & "' AND  ISNULL(VOID,'N')<>'Y'"
            gconnection.getDataSet(sqlstring, "CORPORATE_DET")
            If gdataset.Tables("CORPORATE_DET").Rows.Count > 0 Then
            Else
                sqlstring = "SELECT MCODE,MNAME,CorporateCode,DOJ FROM membermaster WHERE ISNULL(CorporateCode,'')<>'' AND ISNULL(VOID,'N')<>'Y' AND MCODE='" & TxtMemCode.Text & "'"
                gconnection.getDataSet(sqlstring, "membermasterA")
                If gdataset.Tables("membermasterA").Rows.Count > 0 Then
                Else
                    If DTPDateOfJoin.Value.Date < Date.Now.Date Then
                        MessageBox.Show(" Date of joining should be current date or future date... ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        TxtNomRepNo.Focus()
                        Exit Sub
                    End If
                End If
            End If
         End If

        If Trim(TxtValYear.Text) = "" Then
            MessageBox.Show("Validity Year can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtValYear.Focus()
            Exit Sub
        End If

        If Trim(txtMemName.Text) = "" Then
            MessageBox.Show("Membership Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMemName.Focus()
            Exit Sub
        End If
        If Trim(txtMemName.Text) = "" Then
            MessageBox.Show("Membership Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMemName.Focus()
            Exit Sub
        End If

        If Trim(TxtMemCode.Text) = "" Then
            MessageBox.Show("Membership Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtMemCode.Focus()
            Exit Sub
        End If


        '

        boolchk = True
    End Sub

    Public Sub checkValidationD()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(txt_CorpCode.Text) = "" Then
            MessageBox.Show(" Store Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CorpCode.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(txtMemName.Text) = "" Then
            MessageBox.Show(" Store Desc can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMemName.Focus()
            Exit Sub
        End If
        ''''*********** Check For P.K. ********************************
        'sqlstring = "select storecode from storemaster where storecode='" & txt_StoreCode.Text & "'"
        'gconnection.getDataSet(sqlstring, "storemaster")
        'If gdataset.Tables("storemaster").Rows.Count > 0 Then
        '    MessageBox.Show("Sorry ! Storecode already Exists")
        '    txt_StoreCode.Text = ""
        '    txt_StoreCode.Focus()
        '    Exit Sub
        'End If
        boolchk = True
    End Sub
    Private Sub Store_Master_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        StoreMasterbool = False
    End Sub

    Private Sub Opt_Mainstore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Cmd_Add.Focus()
        End If
    End Sub

    Private Sub txt_StoreCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_CorpCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_CorpCode.Text) = "" Then
                ' Call cmdStoreCode_Click(cmdCorpCode, e)
            Else
                txt_StoreCode_Validated(txt_CorpCode, e)
            End If
        End If
    End Sub

    'Private Sub cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_auth.Click
    '    gPrint = True
    '    Dim rViewer As New Viewer
    '    Dim sqlstring, SSQL As String
    '    Dim r As New Rpt_StoreMaster
    '    sqlstring = "SELECT * FROM storemaster order by Storedesc  "
    '    gconnection.getDataSet(sqlstring, "storemaster")
    '    If gdataset.Tables("storemaster").Rows.Count > 0 Then
    '        rViewer.ssql = sqlstring
    '        rViewer.Report = r
    '        rViewer.TableName = "storemaster"
    '        Dim textobj1 As TextObject
    '        textobj1 = r.ReportDefinition.ReportObjects("Text13")
    '        textobj1.Text = MyCompanyName
    '        Dim textobj2 As TextObject
    '        textobj2 = r.ReportDefinition.ReportObjects("Text21")
    '        textobj2.Text = MyCompanyName
    '        rViewer.Show()
    '    Else
    '        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
    '    End If
    '    'PRINTOPERATION()
    'End Sub

    Private Sub PRINTOPERATION()
        Dim x, docno, printline As String
        Dim I As Integer
        Dim booldocno As Boolean
        Dim total(10) As Double
        Dim vsubheader() As String = {"DOC NO. : ", "DOC DATE : ", "MAIN STORE CODE : ", "MAIN STORE NAME : ", "TO STORE CODE  : ", "TO STORE NAME :"}
        Dim PAGEHEADING() As String = {"STORE MASTER"}
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            sqlstring = "SELECT STORECODE,STOREDESC,STORESTATUS,FREEZE FROM STOREMASTER ORDER BY STORECODE"
            gconnection.getDataSet(sqlstring, "INVENTORYSTOREMASTER")
            Call Print_Headers(PAGEHEADING)
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            For Each dr In gdataset.Tables("INVENTORYSTOREMASTER").Rows
                Filewrite.WriteLine("|{0,-15}|{1,-40}|{2,10}|{3,10}|", Mid(dr.Item("STORECODE"), 1, 15), Mid(dr.Item("STOREDESC"), 1, 40), Mid(dr.Item("STORESTATUS"), 1, 10), Mid(dr.Item("FREEZE"), 1, 10))
                pagesize = pagesize + 1
                If pagesize > 58 Then
                    Filewrite.Write(StrDup(80, "-"))
                    Filewrite.Write(Chr(12))
                    pageno = pageno + 1
                    Call Print_Headers(PAGEHEADING)
                    Filewrite.WriteLine()
                    pagesize = pagesize + 1
                End If
            Next dr
            Filewrite.WriteLine(StrDup(80, "-"))
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Sub
        End Try
    End Sub

    Private Function Print_Headers(ByVal pageheading() As String)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine(Chr(18))
            Filewrite.WriteLine("{0,40}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MMM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,1}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(pageheading(0)), 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-1}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(pageheading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,70}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(80, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("|{0,-15}|{1,-40}|{2,10}|{3,10}|", "STORECODE", "STORE DESCRIPTION", "STATUS", "FREEZE")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(80, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "CORPORATE_DET"
        sqlstring = "select * from CORPORATE_DET"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start(AppPath & "/STUDY/STOREMASTER.XLS")
    End Sub



    Private Sub cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    

    Private Sub txt_StoreDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMemName.TextChanged

    End Sub

    Private Sub txt_StoreCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_CorpCode.TextChanged

    End Sub

    

    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 780
        K = 1044
        Me.ResizeRedraw = True

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        If U = 800 Then
            T = T - 50
        End If
        If U = 1280 Then
            T = T - 50
        End If
        If U = 1360 Then
            T = T - 75
        End If
        If U = 1366 Then
            T = T - 75
        End If
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Width = U
        Me.Height = T


        With Me
            For i_i = 0 To .Controls.Count - 1
                ' MsgBox(Controls(i_i).Name)
                If TypeOf .Controls(i_i) Is Form Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0
                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If
                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is Panel Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is GroupBox Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "GroupBox2" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        ElseIf Controls(i_i).Name = "grp_orderby" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        ElseIf Controls(i_i).Name = "GroupBox4" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If

                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is Label Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                End If
            Next i_i
        End With
    End Sub

   

    Private Sub cmd_Docnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Docnohelp.Click

        gSQLString = "SELECT DOCNO,TRANSTYPE,CORPORATECODE FROM CORPORATE_DET"
        M_WhereCondition = "  "
        Dim vform As New ListOperattion1

        vform.Field = "DOCNO,TRANSTYPE,CORPORATECODE"
        vform.vFormatstring = "         DOCNO       |              TRANSTYPE              |                 CORPORATECODE             "
        vform.vCaption = "GROUP MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2



        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Docno.Text = Trim(vform.keyfield & "")
            Call txt_Docno_Validated(txt_Docno, e)
        End If
        vform.Close()
        vform = Nothing

    End Sub

    Private Sub txt_Docno_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_Docno.KeyDown
       

        If e.KeyCode = Keys.F4 Or txt_Docno.Text = "" Then
            If cmd_Docnohelp.Enabled = True Then
                If txt_Docno.Text = "" Then
                    search = Trim(txt_Docno.Text)
                    Call cmd_Docnohelp_Click(cmd_Docnohelp, e)
                End If

            End If
        End If

    End Sub

    Private Sub txt_Docno_Validated(sender As Object, e As EventArgs) Handles txt_Docno.Validated
        If Trim(txt_Docno.Text) <> "" Then
            sqlstring = "SELECT * FROM CORPORATE_DET WHERE DOCNO='" & Trim(txt_Docno.Text) & "'"
            gconnection.getDataSet(sqlstring, "CORPORATE_DET")
            If gdataset.Tables("CORPORATE_DET").Rows.Count > 0 Then
                Me.Cmd_Add.Text = "Update[F7]"
                CbTrnType.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("TRANSTYPE"))

                txt_Docno.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("DOCNO"))

                dtp_Docdate.Value = Format(CDate(gdataset.Tables("CORPORATE_DET").Rows(0).Item("docdate")), "dd/MMM/yyyy")
                txt_CorpCode.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("CORPORATECODE"))
                Call txt_StoreCode_Validated(txt_CorpCode, e)
                TxtNomSL.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("SLNO"))
                TxtNomRepNo.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("RECEIPT_NO"))
                DTPDateOfJoin.Value = Format(CDate(gdataset.Tables("CORPORATE_DET").Rows(0).Item("DATE_OF_jOIN")), "dd/MMM/yyyy")

                TxtValYear.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NO_OF_YEARS"))
                TxtMemCode.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NEW_MEM_CODE"))
                txtMemName.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NEW_MEM_NAME"))

                CbTrnType.Enabled = False
                txt_Docno.ReadOnly = True
                dtp_Docdate.Enabled = False
                txt_CorpCode.ReadOnly = True
                TxtNomSL.ReadOnly = True
                DTPDateOfJoin.Enabled = False
                TxtMemCode.ReadOnly = True
                txtMemName.ReadOnly = True
                BtnMCode.Enabled = False
                If gdataset.Tables("CORPORATE_DET").Rows(0).Item("void") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("CORPORATE_DET").Rows(0).Item("VOIDDATE")), "dd/MMM/yyyy")
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_Add.Enabled = False
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                End If

            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txt_Docno.ReadOnly = False

            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Else
            txt_Docno.Text = ""
            txt_Docno.Focus()
        End If
    End Sub

    Private Sub TxtNameOfCorp_TextChanged(sender As Object, e As EventArgs) Handles TxtNameOfCorp.TextChanged

    End Sub

    Private Sub TxtValYear_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValYear.KeyPress
        getPositiveNumeric(e)
    End Sub

    Private Sub TxtNomSL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNomSL.KeyPress
        getPositiveNumeric(e)
    End Sub

    Private Sub CbTrnType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbTrnType.SelectedIndexChanged

    End Sub


    Private Sub TxtNomSL_Validated(sender As Object, e As EventArgs) Handles TxtNomSL.Validated
        If CbTrnType.Text = "" Then
            MessageBox.Show("Plz select Transaction Type ! ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If txt_CorpCode.Text = "" Then
            MessageBox.Show("Plz select Corporate Code ! ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If CbTrnType.Text <> "New Nominee" And TxtNomSL.Text <> "" And Mid(Cmd_Add.Text, 1, 1) = "A" Then
            If CbTrnType.Text = "Nominee Renewal" Then
                sqlstring = "SELECT * FROM CORPORATE_DET WHERE SLNO='" & Trim(TxtNomSL.Text) & "' AND CORPORATECODE='" & txt_CorpCode.Text & "' AND isnull(VOID,'N')<>'Y' AND  EXPIRYDATE<GETDATE()"
            Else
                sqlstring = "SELECT * FROM CORPORATE_DET WHERE SLNO='" & Trim(TxtNomSL.Text) & "' AND CORPORATECODE='" & txt_CorpCode.Text & "' AND isnull(VOID,'N')<>'Y'"
            End If

            gconnection.getDataSet(sqlstring, "CORPORATE_DET")

            If gdataset.Tables("CORPORATE_DET").Rows.Count > 0 Then
                CbTrnType.SelectedValue = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("TRANSTYPE"))

                docnofill()

                dtp_Docdate.Value = Format(CDate(gdataset.Tables("CORPORATE_DET").Rows(0).Item("docdate")), "dd/MMM/yyyy")
                txt_CorpCode.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("CORPORATECODE"))
                Call txt_StoreCode_Validated(txt_CorpCode, e)
                TxtNomSL.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("SLNO"))
                TxtNomRepNo.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("RECEIPT_NO"))

                DTPDateOfJoin.Value = Format(CDate(gdataset.Tables("CORPORATE_DET").Rows(0).Item("DATE_OF_jOIN")), "dd/MMM/yyyy")

                TxtValYear.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NO_OF_YEARS"))




                CbTrnType.Enabled = False
                txt_Docno.ReadOnly = True
                dtp_Docdate.Enabled = False
                txt_CorpCode.ReadOnly = True
                TxtNomSL.ReadOnly = True
                DTPDateOfJoin.Enabled = False
                TxtValYear.ReadOnly = True
                TxtNomRepNo.ReadOnly = True
                TxtMemCode.Focus()

                If CbTrnType.Text = "Nominee Renewal" Then
                    TxtMemCode.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NEW_MEM_CODE"))
                    txtMemName.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NEW_MEM_NAME"))
                    DTPDateOfJoin.Enabled = True
                    TxtValYear.ReadOnly = False
                    TxtNomRepNo.ReadOnly = False
                    TxtMemCode.ReadOnly = True
                    txtMemName.ReadOnly = True
                    TxtNomRepNo.Focus()
                Else
                    TxtMemCode.Text = ""
                    txtMemName.Text = ""
                    GroupBox3.Visible = True
                    Label11.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NEW_MEM_CODE"))
                    Label12.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NEW_MEM_NAME"))
                End If


                ' Me.Cmd_Add.Text = "Update[F7]"
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txt_Docno.ReadOnly = False

            End If
        End If
    End Sub

    Private Sub btnSlHelp_Click(sender As Object, e As EventArgs) Handles btnSlHelp.Click

        If CbTrnType.Text <> "New Nominee" And txt_CorpCode.Text <> "" Then


            gSQLString = "SELECT cast(slno as varchar),DOCNO,TRANSTYPE,EX_MEM_NAME FROM CORPORATE_DET  "
            If CbTrnType.Text = "Nominee Renewal" Then
                M_WhereCondition = " where corporatecode='" & txt_CorpCode.Text & "' and isnull(void,'N')<>'Y' and  EXPIRYDATE<GETDATE() "
            Else

                M_WhereCondition = " where corporatecode='" & txt_CorpCode.Text & "' and isnull(void,'N')<>'Y' "
            End If

            Dim vform As New ListOperattion1

            vform.Field = "cast(slno as varchar),DOCNO,TRANSTYPE,EX_MEM_NAME"
            vform.vFormatstring = "         SLNO       |         DOCNO       |              TRANSTYPE              |                 CORPORATECODE             "
            vform.vCaption = "CORPORATE DETAILS HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3


            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TxtNomSL.Text = Trim(vform.keyfield & "")
                Call TxtNomSL_Validated(TxtNomSL, e)
            End If
            vform.Close()
            vform = Nothing
        Else

        End If

    End Sub

    Private Sub TxtNomSL_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNomSL.KeyDown

        If TxtNomSL.Text = "" Then
            If btnSlHelp.Enabled = True Then
                If TxtNomSL.Text = "" Then
                    search = Trim(TxtNomSL.Text)
                    Call btnSlHelp_Click(btnSlHelp, e)
                End If

            End If
        End If
    End Sub

    Private Sub BtnMCode_Click(sender As Object, e As EventArgs) Handles BtnMCode.Click
        gSQLString = "SELECT MCODE,MNAME FROM membermaster  "
        If txt_CorpCode.Text <> "" Then
            M_WhereCondition = " where CorporateCode='" & txt_CorpCode.Text & "' and isnull(void,'N')<>'Y' "
        Else
            M_WhereCondition = " where ISNULL(CorporateCode,'')<>'' AND ISNULL(VOID,'N')<>'Y' "
        End If



        Dim vform As New ListOperattion1

        vform.Field = "MCODE,MNAME"
        vform.vFormatstring = "         MCODE        |                     MNAME                    "
        vform.vCaption = "MEMBER DETAILS HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
     


        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TxtMemCode.Text = Trim(vform.keyfield & "")
            Call TxtMemCode_Validated(TxtMemCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub TxtMemCode_Validated(sender As Object, e As EventArgs) Handles TxtMemCode.Validated
        If Trim(TxtMemCode.Text) <> "" And TxtMemCode.ReadOnly = False Then
            sqlstring = "SELECT * FROM CORPORATE_DET WHERE NEW_MEM_CODE='" & Trim(TxtMemCode.Text) & "' AND  ISNULL(VOID,'N')<>'Y'"
            gconnection.getDataSet(sqlstring, "CORPORATE_DET")
            If gdataset.Tables("CORPORATE_DET").Rows.Count > 0 Then
                Me.Cmd_Add.Text = "Update[F7]"
                CbTrnType.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("TRANSTYPE"))

                txt_Docno.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("DOCNO"))

                dtp_Docdate.Value = Format(CDate(gdataset.Tables("CORPORATE_DET").Rows(0).Item("docdate")), "dd/MMM/yyyy")
                txt_CorpCode.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("CORPORATECODE"))
                Call txt_StoreCode_Validated(txt_CorpCode, e)
                TxtNomSL.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("SLNO"))
                TxtNomRepNo.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("RECEIPT_NO"))
                DTPDateOfJoin.Value = Format(CDate(gdataset.Tables("CORPORATE_DET").Rows(0).Item("DATE_OF_jOIN")), "dd/MMM/yyyy")

                TxtValYear.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NO_OF_YEARS"))
                TxtMemCode.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NEW_MEM_CODE"))
                txtMemName.Text = Trim(gdataset.Tables("CORPORATE_DET").Rows(0).Item("NEW_MEM_NAME"))

                CbTrnType.Enabled = False
                txt_Docno.ReadOnly = True
                dtp_Docdate.Enabled = False
                txt_CorpCode.ReadOnly = True
                TxtNomSL.ReadOnly = True
                DTPDateOfJoin.Enabled = False

                If gdataset.Tables("CORPORATE_DET").Rows(0).Item("void") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("CORPORATE_DET").Rows(0).Item("VOIDDATE")), "dd/MMM/yyyy")
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_Add.Enabled = False
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                End If

            Else
                sqlstring = "SELECT MCODE,MNAME,CorporateCode,DOJ FROM membermaster WHERE ISNULL(CorporateCode,'')<>'' AND ISNULL(VOID,'N')<>'Y' AND MCODE='" & TxtMemCode.Text & "'"
                gconnection.getDataSet(sqlstring, "membermasterA")
                If gdataset.Tables("membermasterA").Rows.Count > 0 Then
                    txt_CorpCode.Text = Trim(gdataset.Tables("membermasterA").Rows(0).Item("CORPORATECODE"))
                    Call txt_StoreCode_Validated(txt_CorpCode, e)
                    TxtMemCode.Text = Trim(gdataset.Tables("membermasterA").Rows(0).Item("MCODE"))
                    txtMemName.Text = Trim(gdataset.Tables("membermasterA").Rows(0).Item("MNAME"))
                    DTPDateOfJoin.Value = Format(CDate(gdataset.Tables("membermasterA").Rows(0).Item("DOJ")), "dd/MMM/yyyy")
                    txtMemName.ReadOnly = True
                End If
                sqlstring = "SELECT MCODE,MNAME,CorporateCode,DOJ FROM membermaster WHERE ISNULL(CorporateCode,'')<>'" & txt_CorpCode.Text & "' AND ISNULL(VOID,'N')<>'Y' AND MCODE='" & TxtMemCode.Text & "'"
                gconnection.getDataSet(sqlstring, "membermaster")
                If gdataset.Tables("membermaster").Rows.Count > 0 Then
                    MessageBox.Show("Member code already exist with other Corporate ! ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    ' txt_CorpCode.Text = Trim(gdataset.Tables("membermaster").Rows(0).Item("CORPORATECODE"))
                    ' Call txt_StoreCode_Validated(txt_CorpCode, e)
                    TxtMemCode.Text = ""
                    txtMemName.Text = ""
                    DTPDateOfJoin.Value = Date.Now
                    TxtMemCode.Focus()
                End If
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txt_Docno.ReadOnly = False
                docnofill()
                
            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Else
            'TxtMemCode.Text = ""
            'txtMemName.Text = ""
            'TxtMemCode.Focus()
        End If
    End Sub

    Private Sub TxtMemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMemCode.KeyDown
        If e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Enter Then
            If cmdCorpCode.Enabled = True Then
                If TxtMemCode.Text = "" Then
                    search = Trim(TxtMemCode.Text)
                    Call BtnMCode_Click(BtnMCode, e)
                End If

            End If
        End If
    End Sub

    Private Sub TxtMemCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMemCode.KeyPress

    End Sub
End Class
