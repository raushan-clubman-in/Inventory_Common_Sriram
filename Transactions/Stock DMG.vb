Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class Stock_DMG
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
    Friend WithEvents txt_Docno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Tostore As System.Windows.Forms.Label
    Friend WithEvents lbl_Fromstore As System.Windows.Forms.Label
    Friend WithEvents dtp_Docdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Challanno As System.Windows.Forms.Label
    Friend WithEvents lbl_Docdate As System.Windows.Forms.Label
    Friend WithEvents lbl_Docno As System.Windows.Forms.Label
    Friend WithEvents grp_Stocktransfer2 As System.Windows.Forms.GroupBox
    Friend WithEvents grp_Stocktransfer1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Challanno As System.Windows.Forms.TextBox
    Friend WithEvents cmd_Docnohelp As System.Windows.Forms.Button
    Friend WithEvents dtp_Challandate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Challandate As System.Windows.Forms.Label
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents txt_Totalamt As System.Windows.Forms.TextBox
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Remarks As System.Windows.Forms.Label
    Friend WithEvents txt_Totalqty As System.Windows.Forms.TextBox
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents grp_Stockissue As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Stockissuedetails As System.Windows.Forms.Label
    Friend WithEvents Cmd_ToDocno As System.Windows.Forms.Button
    Friend WithEvents Cmd_FromDocno As System.Windows.Forms.Button
    Friend WithEvents txt_ToDocno As System.Windows.Forms.TextBox
    Friend WithEvents txt_FromDocno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ToDocno As System.Windows.Forms.Label
    Friend WithEvents lbl_FromDocno As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Issueprint As System.Windows.Forms.Button
    Friend WithEvents Cmd_IssueView As System.Windows.Forms.Button
    Friend WithEvents Cmd_Issueexit As System.Windows.Forms.Button
    Friend WithEvents Cmd_IssueClear As System.Windows.Forms.Button
    Friend WithEvents lbl_closingqty As System.Windows.Forms.Label
    Friend WithEvents grp_footer As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_signature As System.Windows.Forms.TextBox
    Friend WithEvents Txt_footer As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Chk_item As System.Windows.Forms.CheckBox
    Friend WithEvents TXT_FROMSTORECODE As System.Windows.Forms.TextBox
    Friend WithEvents txt_FromStorename As System.Windows.Forms.TextBox
    Friend WithEvents cmd_fromStorecodeHelp As System.Windows.Forms.Button
    Friend WithEvents txt_storecode As System.Windows.Forms.TextBox
    Friend WithEvents txt_storeDesc As System.Windows.Forms.TextBox
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lbl_clsqty As System.Windows.Forms.Label
    Friend WithEvents txt_clsqty As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btn_auth As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelClosingQuantity As System.Windows.Forms.Label
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stock_DMG))
        Me.txt_Docno = New System.Windows.Forms.TextBox()
        Me.txt_Totalamt = New System.Windows.Forms.TextBox()
        Me.txt_Remarks = New System.Windows.Forms.TextBox()
        Me.lbl_Remarks = New System.Windows.Forms.Label()
        Me.lbl_Tostore = New System.Windows.Forms.Label()
        Me.lbl_Fromstore = New System.Windows.Forms.Label()
        Me.dtp_Docdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.lbl_Challanno = New System.Windows.Forms.Label()
        Me.lbl_Docdate = New System.Windows.Forms.Label()
        Me.lbl_Docno = New System.Windows.Forms.Label()
        Me.grp_Stocktransfer2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmd_Docnohelp = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grp_Stocktransfer1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_FROMSTORECODE = New System.Windows.Forms.TextBox()
        Me.txt_FromStorename = New System.Windows.Forms.TextBox()
        Me.cmd_fromStorecodeHelp = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_storecode = New System.Windows.Forms.TextBox()
        Me.txt_storeDesc = New System.Windows.Forms.TextBox()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.txt_Challanno = New System.Windows.Forms.TextBox()
        Me.txt_Totalqty = New System.Windows.Forms.TextBox()
        Me.dtp_Challandate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Challandate = New System.Windows.Forms.Label()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.btn_auth = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.grp_Stockissue = New System.Windows.Forms.GroupBox()
        Me.lbl_Stockissuedetails = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Cmd_Issueprint = New System.Windows.Forms.Button()
        Me.Cmd_IssueView = New System.Windows.Forms.Button()
        Me.Cmd_Issueexit = New System.Windows.Forms.Button()
        Me.Cmd_IssueClear = New System.Windows.Forms.Button()
        Me.txt_FromDocno = New System.Windows.Forms.TextBox()
        Me.Cmd_FromDocno = New System.Windows.Forms.Button()
        Me.lbl_FromDocno = New System.Windows.Forms.Label()
        Me.txt_ToDocno = New System.Windows.Forms.TextBox()
        Me.Cmd_ToDocno = New System.Windows.Forms.Button()
        Me.lbl_ToDocno = New System.Windows.Forms.Label()
        Me.lbl_closingqty = New System.Windows.Forms.Label()
        Me.grp_footer = New System.Windows.Forms.GroupBox()
        Me.Txt_signature = New System.Windows.Forms.TextBox()
        Me.Txt_footer = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Chk_item = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelClosingQuantity = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lbl_clsqty = New System.Windows.Forms.Label()
        Me.txt_clsqty = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.grp_Stocktransfer2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Stocktransfer1.SuspendLayout()
        Me.frmbut.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Stockissue.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grp_footer.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_Docno
        '
        Me.txt_Docno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Docno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Docno.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Docno.Location = New System.Drawing.Point(74, 23)
        Me.txt_Docno.MaxLength = 15
        Me.txt_Docno.Name = "txt_Docno"
        Me.txt_Docno.Size = New System.Drawing.Size(145, 22)
        Me.txt_Docno.TabIndex = 3
        '
        'txt_Totalamt
        '
        Me.txt_Totalamt.BackColor = System.Drawing.Color.Wheat
        Me.txt_Totalamt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Totalamt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Totalamt.Location = New System.Drawing.Point(575, 15)
        Me.txt_Totalamt.MaxLength = 15
        Me.txt_Totalamt.Name = "txt_Totalamt"
        Me.txt_Totalamt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Totalamt.Size = New System.Drawing.Size(89, 22)
        Me.txt_Totalamt.TabIndex = 8
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BackColor = System.Drawing.Color.White
        Me.txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Remarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Remarks.Location = New System.Drawing.Point(95, 16)
        Me.txt_Remarks.MaxLength = 100
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(269, 53)
        Me.txt_Remarks.TabIndex = 7
        '
        'lbl_Remarks
        '
        Me.lbl_Remarks.AutoSize = True
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Remarks.Location = New System.Drawing.Point(7, 16)
        Me.lbl_Remarks.Name = "lbl_Remarks"
        Me.lbl_Remarks.Size = New System.Drawing.Size(64, 15)
        Me.lbl_Remarks.TabIndex = 26
        Me.lbl_Remarks.Text = "REMARKS"
        '
        'lbl_Tostore
        '
        Me.lbl_Tostore.AutoSize = True
        Me.lbl_Tostore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Tostore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Tostore.Location = New System.Drawing.Point(13, 156)
        Me.lbl_Tostore.Name = "lbl_Tostore"
        Me.lbl_Tostore.Size = New System.Drawing.Size(101, 16)
        Me.lbl_Tostore.TabIndex = 18
        Me.lbl_Tostore.Text = "RECV STORE :"
        Me.lbl_Tostore.Visible = False
        '
        'lbl_Fromstore
        '
        Me.lbl_Fromstore.AutoSize = True
        Me.lbl_Fromstore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Fromstore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Fromstore.Location = New System.Drawing.Point(4, 27)
        Me.lbl_Fromstore.Name = "lbl_Fromstore"
        Me.lbl_Fromstore.Size = New System.Drawing.Size(82, 15)
        Me.lbl_Fromstore.TabIndex = 16
        Me.lbl_Fromstore.Text = "FROM STORE"
        '
        'dtp_Docdate
        '
        Me.dtp_Docdate.CustomFormat = "dd/MMM/yyyy"
        Me.dtp_Docdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Docdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Docdate.Location = New System.Drawing.Point(132, 60)
        Me.dtp_Docdate.Name = "dtp_Docdate"
        Me.dtp_Docdate.Size = New System.Drawing.Size(96, 26)
        Me.dtp_Docdate.TabIndex = 4
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 12.75!, System.Drawing.FontStyle.Bold)
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(181, 74)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(143, 19)
        Me.lbl_Heading.TabIndex = 92
        Me.lbl_Heading.Text = "STOCK DAMAGE"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Challanno
        '
        Me.lbl_Challanno.AutoSize = True
        Me.lbl_Challanno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Challanno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Challanno.Location = New System.Drawing.Point(12, 240)
        Me.lbl_Challanno.Name = "lbl_Challanno"
        Me.lbl_Challanno.Size = New System.Drawing.Size(98, 16)
        Me.lbl_Challanno.TabIndex = 20
        Me.lbl_Challanno.Text = "CHALLAN NO :"
        Me.lbl_Challanno.Visible = False
        '
        'lbl_Docdate
        '
        Me.lbl_Docdate.AutoSize = True
        Me.lbl_Docdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Docdate.Location = New System.Drawing.Point(6, 66)
        Me.lbl_Docdate.Name = "lbl_Docdate"
        Me.lbl_Docdate.Size = New System.Drawing.Size(64, 15)
        Me.lbl_Docdate.TabIndex = 24
        Me.lbl_Docdate.Text = "DOC DATE"
        '
        'lbl_Docno
        '
        Me.lbl_Docno.AutoSize = True
        Me.lbl_Docno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Docno.Location = New System.Drawing.Point(6, 27)
        Me.lbl_Docno.Name = "lbl_Docno"
        Me.lbl_Docno.Size = New System.Drawing.Size(52, 15)
        Me.lbl_Docno.TabIndex = 22
        Me.lbl_Docno.Text = "DOC NO"
        '
        'grp_Stocktransfer2
        '
        Me.grp_Stocktransfer2.BackColor = System.Drawing.Color.Transparent
        Me.grp_Stocktransfer2.Controls.Add(Me.PictureBox2)
        Me.grp_Stocktransfer2.Controls.Add(Me.lbl_Docno)
        Me.grp_Stocktransfer2.Controls.Add(Me.Label16)
        Me.grp_Stocktransfer2.Controls.Add(Me.cmd_Docnohelp)
        Me.grp_Stocktransfer2.Controls.Add(Me.txt_Docno)
        Me.grp_Stocktransfer2.Controls.Add(Me.lbl_Docdate)
        Me.grp_Stocktransfer2.Controls.Add(Me.dtp_Docdate)
        Me.grp_Stocktransfer2.Location = New System.Drawing.Point(582, 107)
        Me.grp_Stocktransfer2.Name = "grp_Stocktransfer2"
        Me.grp_Stocktransfer2.Size = New System.Drawing.Size(274, 108)
        Me.grp_Stocktransfer2.TabIndex = 21
        Me.grp_Stocktransfer2.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(96, 54)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 46
        Me.PictureBox2.TabStop = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(244, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 24)
        Me.Label16.TabIndex = 472
        Me.Label16.Text = "F4"
        Me.Label16.Visible = False
        '
        'cmd_Docnohelp
        '
        Me.cmd_Docnohelp.Image = CType(resources.GetObject("cmd_Docnohelp.Image"), System.Drawing.Image)
        Me.cmd_Docnohelp.Location = New System.Drawing.Point(220, 22)
        Me.cmd_Docnohelp.Name = "cmd_Docnohelp"
        Me.cmd_Docnohelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_Docnohelp.TabIndex = 23
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 328)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'grp_Stocktransfer1
        '
        Me.grp_Stocktransfer1.BackColor = System.Drawing.Color.Transparent
        Me.grp_Stocktransfer1.Controls.Add(Me.Label1)
        Me.grp_Stocktransfer1.Controls.Add(Me.TXT_FROMSTORECODE)
        Me.grp_Stocktransfer1.Controls.Add(Me.txt_FromStorename)
        Me.grp_Stocktransfer1.Controls.Add(Me.cmd_fromStorecodeHelp)
        Me.grp_Stocktransfer1.Controls.Add(Me.lbl_Fromstore)
        Me.grp_Stocktransfer1.Location = New System.Drawing.Point(189, 106)
        Me.grp_Stocktransfer1.Name = "grp_Stocktransfer1"
        Me.grp_Stocktransfer1.Size = New System.Drawing.Size(391, 108)
        Me.grp_Stocktransfer1.TabIndex = 15
        Me.grp_Stocktransfer1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(347, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 24)
        Me.Label1.TabIndex = 472
        Me.Label1.Text = "F4"
        Me.Label1.Visible = False
        '
        'TXT_FROMSTORECODE
        '
        Me.TXT_FROMSTORECODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_FROMSTORECODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_FROMSTORECODE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_FROMSTORECODE.Location = New System.Drawing.Point(108, 24)
        Me.TXT_FROMSTORECODE.MaxLength = 50
        Me.TXT_FROMSTORECODE.Name = "TXT_FROMSTORECODE"
        Me.TXT_FROMSTORECODE.Size = New System.Drawing.Size(60, 22)
        Me.TXT_FROMSTORECODE.TabIndex = 0
        '
        'txt_FromStorename
        '
        Me.txt_FromStorename.BackColor = System.Drawing.Color.Wheat
        Me.txt_FromStorename.Enabled = False
        Me.txt_FromStorename.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FromStorename.Location = New System.Drawing.Point(194, 25)
        Me.txt_FromStorename.MaxLength = 50
        Me.txt_FromStorename.Name = "txt_FromStorename"
        Me.txt_FromStorename.Size = New System.Drawing.Size(190, 22)
        Me.txt_FromStorename.TabIndex = 395
        '
        'cmd_fromStorecodeHelp
        '
        Me.cmd_fromStorecodeHelp.Image = CType(resources.GetObject("cmd_fromStorecodeHelp.Image"), System.Drawing.Image)
        Me.cmd_fromStorecodeHelp.Location = New System.Drawing.Point(168, 23)
        Me.cmd_fromStorecodeHelp.Name = "cmd_fromStorecodeHelp"
        Me.cmd_fromStorecodeHelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_fromStorecodeHelp.TabIndex = 396
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(120, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 24)
        Me.Label2.TabIndex = 473
        Me.Label2.Text = "F4"
        Me.Label2.Visible = False
        '
        'txt_storecode
        '
        Me.txt_storecode.BackColor = System.Drawing.Color.Wheat
        Me.txt_storecode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_storecode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_storecode.Location = New System.Drawing.Point(9, 176)
        Me.txt_storecode.MaxLength = 50
        Me.txt_storecode.Name = "txt_storecode"
        Me.txt_storecode.Size = New System.Drawing.Size(80, 22)
        Me.txt_storecode.TabIndex = 1
        Me.txt_storecode.Visible = False
        '
        'txt_storeDesc
        '
        Me.txt_storeDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_storeDesc.Enabled = False
        Me.txt_storeDesc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_storeDesc.Location = New System.Drawing.Point(8, 207)
        Me.txt_storeDesc.MaxLength = 50
        Me.txt_storeDesc.Name = "txt_storeDesc"
        Me.txt_storeDesc.Size = New System.Drawing.Size(132, 22)
        Me.txt_storeDesc.TabIndex = 398
        Me.txt_storeDesc.Visible = False
        '
        'cmd_storecode
        '
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(92, 175)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 399
        Me.cmd_storecode.Visible = False
        '
        'txt_Challanno
        '
        Me.txt_Challanno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Challanno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Challanno.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Challanno.Location = New System.Drawing.Point(12, 259)
        Me.txt_Challanno.MaxLength = 15
        Me.txt_Challanno.Name = "txt_Challanno"
        Me.txt_Challanno.Size = New System.Drawing.Size(112, 22)
        Me.txt_Challanno.TabIndex = 3
        Me.txt_Challanno.Visible = False
        '
        'txt_Totalqty
        '
        Me.txt_Totalqty.BackColor = System.Drawing.Color.Wheat
        Me.txt_Totalqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Totalqty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Totalqty.Location = New System.Drawing.Point(421, 14)
        Me.txt_Totalqty.MaxLength = 15
        Me.txt_Totalqty.Name = "txt_Totalqty"
        Me.txt_Totalqty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txt_Totalqty.Size = New System.Drawing.Size(82, 22)
        Me.txt_Totalqty.TabIndex = 9
        '
        'dtp_Challandate
        '
        Me.dtp_Challandate.CustomFormat = "dd/MMM/yyyy"
        Me.dtp_Challandate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Challandate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Challandate.Location = New System.Drawing.Point(46, 333)
        Me.dtp_Challandate.Name = "dtp_Challandate"
        Me.dtp_Challandate.Size = New System.Drawing.Size(96, 26)
        Me.dtp_Challandate.TabIndex = 5
        Me.dtp_Challandate.Visible = False
        '
        'lbl_Challandate
        '
        Me.lbl_Challandate.AutoSize = True
        Me.lbl_Challandate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Challandate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Challandate.Location = New System.Drawing.Point(9, 306)
        Me.lbl_Challandate.Name = "lbl_Challandate"
        Me.lbl_Challandate.Size = New System.Drawing.Size(115, 16)
        Me.lbl_Challandate.TabIndex = 25
        Me.lbl_Challandate.Text = "CHALLAN DATE :"
        Me.lbl_Challandate.Visible = False
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.btn_auth)
        Me.frmbut.Controls.Add(Me.Button5)
        Me.frmbut.Controls.Add(Me.Button4)
        Me.frmbut.Controls.Add(Me.Button3)
        Me.frmbut.Controls.Add(Me.Button2)
        Me.frmbut.Controls.Add(Me.Button1)
        Me.frmbut.Controls.Add(Me.Cmd_Clear)
        Me.frmbut.Controls.Add(Me.chk_excel)
        Me.frmbut.Location = New System.Drawing.Point(869, 82)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(139, 498)
        Me.frmbut.TabIndex = 30
        Me.frmbut.TabStop = False
        '
        'btn_auth
        '
        Me.btn_auth.BackColor = System.Drawing.Color.Transparent
        Me.btn_auth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btn_auth.ForeColor = System.Drawing.Color.Black
        Me.btn_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_auth.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_auth.Location = New System.Drawing.Point(13, 428)
        Me.btn_auth.Name = "btn_auth"
        Me.btn_auth.Size = New System.Drawing.Size(115, 56)
        Me.btn_auth.TabIndex = 479
        Me.btn_auth.Text = "Authorize"
        Me.btn_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_auth.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImage = Global.Inventory.My.Resources.Resources._Exit
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button5.Location = New System.Drawing.Point(11, 366)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(118, 56)
        Me.Button5.TabIndex = 475
        Me.Button5.Text = "Exit[F11]"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = Global.Inventory.My.Resources.Resources.print
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button4.Location = New System.Drawing.Point(11, 304)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(118, 56)
        Me.Button4.TabIndex = 478
        Me.Button4.Text = "Print[F10]"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.Inventory.My.Resources.Resources.view
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button3.Location = New System.Drawing.Point(13, 215)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(116, 56)
        Me.Button3.TabIndex = 477
        Me.Button3.Text = " View[F9]"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.Inventory.My.Resources.Resources.Delete
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2.Location = New System.Drawing.Point(13, 153)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 56)
        Me.Button2.TabIndex = 475
        Me.Button2.Text = "Void[F8]"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.Inventory.My.Resources.Resources.save
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(11, 87)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 56)
        Me.Button1.TabIndex = 476
        Me.Button1.Text = "Add [F7]"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.BackgroundImage = Global.Inventory.My.Resources.Resources.Clear
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cmd_Clear.Location = New System.Drawing.Point(11, 21)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(119, 56)
        Me.Cmd_Clear.TabIndex = 475
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'chk_excel
        '
        Me.chk_excel.BackColor = System.Drawing.Color.Transparent
        Me.chk_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_excel.Location = New System.Drawing.Point(19, 277)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(72, 24)
        Me.chk_excel.TabIndex = 465
        Me.chk_excel.Text = "EXCEL"
        Me.chk_excel.UseVisualStyleBackColor = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(181, 14)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(146, 22)
        Me.lbl_Freeze.TabIndex = 29
        Me.lbl_Freeze.Text = "Record Void  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(209, 235)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(640, 225)
        Me.ssgrid.TabIndex = 369
        '
        'grp_Stockissue
        '
        Me.grp_Stockissue.BackgroundImage = CType(resources.GetObject("grp_Stockissue.BackgroundImage"), System.Drawing.Image)
        Me.grp_Stockissue.Controls.Add(Me.lbl_Stockissuedetails)
        Me.grp_Stockissue.Controls.Add(Me.GroupBox2)
        Me.grp_Stockissue.Controls.Add(Me.txt_FromDocno)
        Me.grp_Stockissue.Controls.Add(Me.Cmd_FromDocno)
        Me.grp_Stockissue.Controls.Add(Me.lbl_FromDocno)
        Me.grp_Stockissue.Controls.Add(Me.txt_ToDocno)
        Me.grp_Stockissue.Controls.Add(Me.Cmd_ToDocno)
        Me.grp_Stockissue.Controls.Add(Me.lbl_ToDocno)
        Me.grp_Stockissue.Location = New System.Drawing.Point(231, 1000)
        Me.grp_Stockissue.Name = "grp_Stockissue"
        Me.grp_Stockissue.Size = New System.Drawing.Size(513, 230)
        Me.grp_Stockissue.TabIndex = 370
        Me.grp_Stockissue.TabStop = False
        '
        'lbl_Stockissuedetails
        '
        Me.lbl_Stockissuedetails.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Stockissuedetails.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Stockissuedetails.ForeColor = System.Drawing.Color.White
        Me.lbl_Stockissuedetails.Location = New System.Drawing.Point(0, 10)
        Me.lbl_Stockissuedetails.Name = "lbl_Stockissuedetails"
        Me.lbl_Stockissuedetails.Size = New System.Drawing.Size(517, 24)
        Me.lbl_Stockissuedetails.TabIndex = 26
        Me.lbl_Stockissuedetails.Text = "TRANSFER CHECKLIST"
        Me.lbl_Stockissuedetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmd_Issueprint)
        Me.GroupBox2.Controls.Add(Me.Cmd_IssueView)
        Me.GroupBox2.Controls.Add(Me.Cmd_Issueexit)
        Me.GroupBox2.Controls.Add(Me.Cmd_IssueClear)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 168)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(496, 56)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        '
        'Cmd_Issueprint
        '
        Me.Cmd_Issueprint.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Issueprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Issueprint.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Issueprint.ForeColor = System.Drawing.Color.White
        Me.Cmd_Issueprint.Image = CType(resources.GetObject("Cmd_Issueprint.Image"), System.Drawing.Image)
        Me.Cmd_Issueprint.Location = New System.Drawing.Point(256, 16)
        Me.Cmd_Issueprint.Name = "Cmd_Issueprint"
        Me.Cmd_Issueprint.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Issueprint.TabIndex = 25
        Me.Cmd_Issueprint.Text = "Print [F10]"
        Me.Cmd_Issueprint.UseVisualStyleBackColor = False
        '
        'Cmd_IssueView
        '
        Me.Cmd_IssueView.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_IssueView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_IssueView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_IssueView.ForeColor = System.Drawing.Color.White
        Me.Cmd_IssueView.Image = CType(resources.GetObject("Cmd_IssueView.Image"), System.Drawing.Image)
        Me.Cmd_IssueView.Location = New System.Drawing.Point(128, 16)
        Me.Cmd_IssueView.Name = "Cmd_IssueView"
        Me.Cmd_IssueView.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_IssueView.TabIndex = 13
        Me.Cmd_IssueView.Text = "View [F9]"
        Me.Cmd_IssueView.UseVisualStyleBackColor = False
        '
        'Cmd_Issueexit
        '
        Me.Cmd_Issueexit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Issueexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Issueexit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Issueexit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Issueexit.Image = CType(resources.GetObject("Cmd_Issueexit.Image"), System.Drawing.Image)
        Me.Cmd_Issueexit.Location = New System.Drawing.Point(376, 16)
        Me.Cmd_Issueexit.Name = "Cmd_Issueexit"
        Me.Cmd_Issueexit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Issueexit.TabIndex = 15
        Me.Cmd_Issueexit.Text = "Exit[F11]"
        Me.Cmd_Issueexit.UseVisualStyleBackColor = False
        '
        'Cmd_IssueClear
        '
        Me.Cmd_IssueClear.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_IssueClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_IssueClear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_IssueClear.ForeColor = System.Drawing.Color.White
        Me.Cmd_IssueClear.Image = CType(resources.GetObject("Cmd_IssueClear.Image"), System.Drawing.Image)
        Me.Cmd_IssueClear.Location = New System.Drawing.Point(8, 16)
        Me.Cmd_IssueClear.Name = "Cmd_IssueClear"
        Me.Cmd_IssueClear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_IssueClear.TabIndex = 24
        Me.Cmd_IssueClear.Text = "Clear[F6]"
        Me.Cmd_IssueClear.UseVisualStyleBackColor = False
        '
        'txt_FromDocno
        '
        Me.txt_FromDocno.BackColor = System.Drawing.Color.Wheat
        Me.txt_FromDocno.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FromDocno.Location = New System.Drawing.Point(192, 64)
        Me.txt_FromDocno.Name = "txt_FromDocno"
        Me.txt_FromDocno.Size = New System.Drawing.Size(208, 29)
        Me.txt_FromDocno.TabIndex = 4
        '
        'Cmd_FromDocno
        '
        Me.Cmd_FromDocno.Image = CType(resources.GetObject("Cmd_FromDocno.Image"), System.Drawing.Image)
        Me.Cmd_FromDocno.Location = New System.Drawing.Point(400, 64)
        Me.Cmd_FromDocno.Name = "Cmd_FromDocno"
        Me.Cmd_FromDocno.Size = New System.Drawing.Size(23, 29)
        Me.Cmd_FromDocno.TabIndex = 38
        '
        'lbl_FromDocno
        '
        Me.lbl_FromDocno.AutoSize = True
        Me.lbl_FromDocno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_FromDocno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FromDocno.Location = New System.Drawing.Point(43, 64)
        Me.lbl_FromDocno.Name = "lbl_FromDocno"
        Me.lbl_FromDocno.Size = New System.Drawing.Size(134, 19)
        Me.lbl_FromDocno.TabIndex = 2
        Me.lbl_FromDocno.Text = "FROM DOC NO :"
        '
        'txt_ToDocno
        '
        Me.txt_ToDocno.BackColor = System.Drawing.Color.Wheat
        Me.txt_ToDocno.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ToDocno.Location = New System.Drawing.Point(192, 112)
        Me.txt_ToDocno.Name = "txt_ToDocno"
        Me.txt_ToDocno.Size = New System.Drawing.Size(208, 29)
        Me.txt_ToDocno.TabIndex = 5
        '
        'Cmd_ToDocno
        '
        Me.Cmd_ToDocno.Image = CType(resources.GetObject("Cmd_ToDocno.Image"), System.Drawing.Image)
        Me.Cmd_ToDocno.Location = New System.Drawing.Point(400, 111)
        Me.Cmd_ToDocno.Name = "Cmd_ToDocno"
        Me.Cmd_ToDocno.Size = New System.Drawing.Size(23, 29)
        Me.Cmd_ToDocno.TabIndex = 39
        '
        'lbl_ToDocno
        '
        Me.lbl_ToDocno.AutoSize = True
        Me.lbl_ToDocno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ToDocno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ToDocno.Location = New System.Drawing.Point(72, 112)
        Me.lbl_ToDocno.Name = "lbl_ToDocno"
        Me.lbl_ToDocno.Size = New System.Drawing.Size(107, 19)
        Me.lbl_ToDocno.TabIndex = 3
        Me.lbl_ToDocno.Text = "TO DOC NO :"
        '
        'lbl_closingqty
        '
        Me.lbl_closingqty.AutoSize = True
        Me.lbl_closingqty.BackColor = System.Drawing.Color.Transparent
        Me.lbl_closingqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_closingqty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl_closingqty.Location = New System.Drawing.Point(183, 673)
        Me.lbl_closingqty.Name = "lbl_closingqty"
        Me.lbl_closingqty.Size = New System.Drawing.Size(159, 24)
        Me.lbl_closingqty.TabIndex = 372
        Me.lbl_closingqty.Text = "CLOSING QTY :"
        Me.lbl_closingqty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_closingqty.Visible = False
        '
        'grp_footer
        '
        Me.grp_footer.BackColor = System.Drawing.Color.Transparent
        Me.grp_footer.Controls.Add(Me.Txt_signature)
        Me.grp_footer.Controls.Add(Me.Txt_footer)
        Me.grp_footer.Controls.Add(Me.Label9)
        Me.grp_footer.Controls.Add(Me.Label7)
        Me.grp_footer.Controls.Add(Me.Label8)
        Me.grp_footer.Location = New System.Drawing.Point(77, 389)
        Me.grp_footer.Name = "grp_footer"
        Me.grp_footer.Size = New System.Drawing.Size(33, 80)
        Me.grp_footer.TabIndex = 465
        Me.grp_footer.TabStop = False
        '
        'Txt_signature
        '
        Me.Txt_signature.Location = New System.Drawing.Point(120, 48)
        Me.Txt_signature.MaxLength = 79
        Me.Txt_signature.Name = "Txt_signature"
        Me.Txt_signature.Size = New System.Drawing.Size(536, 22)
        Me.Txt_signature.TabIndex = 441
        '
        'Txt_footer
        '
        Me.Txt_footer.Location = New System.Drawing.Point(120, 16)
        Me.Txt_footer.MaxLength = 150
        Me.Txt_footer.Name = "Txt_footer"
        Me.Txt_footer.Size = New System.Drawing.Size(536, 22)
        Me.Txt_footer.TabIndex = 440
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 16)
        Me.Label9.TabIndex = 439
        Me.Label9.Text = "FOOTER SIGN:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(40, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 15)
        Me.Label7.TabIndex = 438
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 16)
        Me.Label8.TabIndex = 438
        Me.Label8.Text = "FOOTER NAME:"
        '
        'Chk_item
        '
        Me.Chk_item.BackColor = System.Drawing.Color.Transparent
        Me.Chk_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_item.Location = New System.Drawing.Point(184, 651)
        Me.Chk_item.Name = "Chk_item"
        Me.Chk_item.Size = New System.Drawing.Size(120, 24)
        Me.Chk_item.TabIndex = 464
        Me.Chk_item.Text = "FooterUpdation"
        Me.Chk_item.UseVisualStyleBackColor = False
        Me.Chk_item.Visible = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(5, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 23)
        Me.Label10.TabIndex = 466
        Me.Label10.Text = "[F3 DELETE A ROW IN GRID]"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LabelClosingQuantity)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txt_Remarks)
        Me.GroupBox1.Controls.Add(Me.lbl_Remarks)
        Me.GroupBox1.Location = New System.Drawing.Point(189, 533)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(669, 80)
        Me.GroupBox1.TabIndex = 467
        Me.GroupBox1.TabStop = False
        '
        'LabelClosingQuantity
        '
        Me.LabelClosingQuantity.AutoSize = True
        Me.LabelClosingQuantity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelClosingQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelClosingQuantity.Location = New System.Drawing.Point(373, 22)
        Me.LabelClosingQuantity.Name = "LabelClosingQuantity"
        Me.LabelClosingQuantity.Size = New System.Drawing.Size(0, 16)
        Me.LabelClosingQuantity.TabIndex = 480
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(10, 38)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 24)
        Me.Label20.TabIndex = 477
        Me.Label20.Text = "ALT+ R"
        '
        'lbl_clsqty
        '
        Me.lbl_clsqty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_clsqty.Location = New System.Drawing.Point(490, 39)
        Me.lbl_clsqty.Name = "lbl_clsqty"
        Me.lbl_clsqty.Size = New System.Drawing.Size(80, 23)
        Me.lbl_clsqty.TabIndex = 468
        Me.lbl_clsqty.Text = "Closing Qty"
        Me.lbl_clsqty.Visible = False
        '
        'txt_clsqty
        '
        Me.txt_clsqty.Location = New System.Drawing.Point(575, 39)
        Me.txt_clsqty.Name = "txt_clsqty"
        Me.txt_clsqty.Size = New System.Drawing.Size(75, 22)
        Me.txt_clsqty.TabIndex = 469
        Me.txt_clsqty.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Location = New System.Drawing.Point(189, 214)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(667, 256)
        Me.GroupBox3.TabIndex = 474
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.txt_clsqty)
        Me.GroupBox4.Controls.Add(Me.txt_Totalqty)
        Me.GroupBox4.Controls.Add(Me.txt_Totalamt)
        Me.GroupBox4.Controls.Add(Me.lbl_Freeze)
        Me.GroupBox4.Controls.Add(Me.lbl_clsqty)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Location = New System.Drawing.Point(187, 469)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(670, 68)
        Me.GroupBox4.TabIndex = 475
        Me.GroupBox4.TabStop = False
        '
        'Stock_DMG
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1014, 736)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lbl_closingqty)
        Me.Controls.Add(Me.lbl_Challandate)
        Me.Controls.Add(Me.txt_Challanno)
        Me.Controls.Add(Me.lbl_Tostore)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.lbl_Challanno)
        Me.Controls.Add(Me.txt_storecode)
        Me.Controls.Add(Me.txt_storeDesc)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_footer)
        Me.Controls.Add(Me.grp_Stockissue)
        Me.Controls.Add(Me.ssgrid)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.dtp_Challandate)
        Me.Controls.Add(Me.grp_Stocktransfer2)
        Me.Controls.Add(Me.grp_Stocktransfer1)
        Me.Controls.Add(Me.Chk_item)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmd_storecode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "Stock_DMG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STOCK DAMAGE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_Stocktransfer2.ResumeLayout(False)
        Me.grp_Stocktransfer2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Stocktransfer1.ResumeLayout(False)
        Me.grp_Stocktransfer1.PerformLayout()
        Me.frmbut.ResumeLayout(False)
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Stockissue.ResumeLayout(False)
        Me.grp_Stockissue.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.grp_footer.ResumeLayout(False)
        Me.grp_footer.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim boolchk As Boolean
    Dim Dupchk As Boolean
    Dim TotalCount As Integer
    Dim gconnection As New GlobalClass
    Dim sqlstring, financalyear As String
    Dim docno(), transferdocno, doctype1 As String
    Dim vsearch, vitem, accountcode As String

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
                        If Controls(i_i).Name = "GroupBox9" Then
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
                        ElseIf Controls(i_i).Name = "frmbut" Then
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

    Private Sub Stock_DMG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            doctype1 = ""
            Resize_Form()
            Me.DoubleBuffered = True
            GroupBox3.Controls.Add(ssgrid)
            ssgrid.Location = New Point(10, 10)
            ssgrid.Width = GroupBox3.Width - 15
            ssgrid.Height = GroupBox3.Height - 15
            StockTransferTransbool = True
            Me.dtp_Docdate.Value = Format(Now, "dd/MMM/yyyy")
            Me.dtp_Challandate.Value = Format(Now, "dd/MMM/yyyy")
            Call FOOTER()
            grp_footer.Visible = False
            Call autogenerate() '''--> Fill DOC NO.
            Me.lbl_closingqty.Text = ""
            Me.grp_Stockissue.Top = 1000
            'Me.lbl_Heading.Text = "STOCK TRANSFER/RETURN"
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            txt_Docno.Text = ""
            Me.Show()
            TXT_FROMSTORECODE.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Function check_Duplicate(ByVal Itemcode As String)
        Dim i As Integer
        Dupchk = False
        ssgrid.Col = 1
        For i = 1 To ssgrid.DataRowCnt
            ssgrid.Row = i
            If i <> ssgrid.ActiveRow Then
                If Trim(ssgrid.Text) = Trim(Itemcode) Then
                    MsgBox("Item Already exists", MsgBoxStyle.Critical, "Duplicate")
                    Dupchk = True
                End If
            End If
        Next
    End Function




    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub autogenerate()
        Dim Sqlstring, Financalyear As String
        Try
            Financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            Sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) FROM STOCKDMGHEADER WHERE doctype='" & Trim(doctype1) & "'"
            gconnection.openConnection()
            gcommand = New SqlCommand(Sqlstring, gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    txt_Docno.Text = doctype1 & "/000001/" & Financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    txt_Docno.Text = doctype1 & "/" & Format(gdreader(0) + 1, "000000") & "/" & Financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                txt_Docno.Text = doctype1 & "/000001/" & Financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub

    Private Sub txt_Docno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Docno.Validated
        Dim j, i As Integer
        Dim dt As New DataTable
        Dim vString, sqlstring, STRITEMCODE, STRITEMUOM, remarks As String
        Dim vTypeseqno, vGroupseqno, Clsquantity As Double
        Dim varqty As Double
        Me.txt_Totalqty.Text = 0
        varqty = 0
        If Trim(txt_Docno.Text) <> "" Then
            Try
                sqlstring = "SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE AS DOCDATE,ISNULL(H.TRANSFERNO,'') AS TRANSFERNO,"
                sqlstring = sqlstring & " ISNULL(H.FROMSTORECODE,'') AS FROMSTORECODE,ISNULL(H.FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(H.FROMSTORECODE,'') AS FROMSTORECODE,ISNULL(H.FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(H.TOSTORECODE,'') AS TOSTORECODE,"
                sqlstring = sqlstring & " ISNULL(H.TOSTOREDESC,'') AS TOSTOREDESC,ISNULL(H.CHALLENNO,'') AS CHALLENNO,H.CHALLENDATE,ISNULL(H.TOTALAMT,0) AS TOTALAMT,"
                sqlstring = sqlstring & " ISNULL(H.REMARKS,'') AS REMARKS,ISNULL(H.VOID,'') AS VOID,ISNULL(ADDUSER,'') AS ADDUSER,ADDDATE,ISNULL(UPDATEUSER,'') AS UPDATEUSER,"
                sqlstring = sqlstring & " UPDATETIME ,isnull(UPDFOOTER,'') AS UPDFOOTER,isnull(UPdsign,'') AS UPdsign FROM STOCKDMGHEADER AS H WHERE DOCNO='" & Trim(txt_Docno.Text) & "'OR DOCDETAILS='" & Trim(txt_Docno.Text) & "'"
                gconnection.getDataSet(sqlstring, "stocktransferheader")
                '''************************************************* SELECT RECORD FROM STOCKTRANSFERHEADER *********************************************''''                
                If gdataset.Tables("stocktransferheader").Rows.Count > 0 Then
                    Button1.Text = "Update[F7]"
                    Me.txt_Docno.ReadOnly = True
                    txt_Docno.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("DOCDETAILS"))
                    dtp_Docdate.Value = Format(CDate(gdataset.Tables("stocktransferheader").Rows(0).Item("DOCDATE")), "dd/MMM/yyyy")
                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("FROMSTORECODE"))
                    ' cbo_Fromstore.DropDownStyle = ComboBoxStyle.DropDown
                    ' cbo_Fromstore.Enabled = False
                    txt_FromStorename.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("FROMSTOREDESC"))
                    'txt_FromStorename.DropDownStyle = ComboBoxStyle.DropDownList
                    '''txt_storecode.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("STORECODE"))
                    ' cbo_Tostore.DropDownStyle = ComboBoxStyle.DropDown
                    ' cbo_Tostore.Enabled = False
                    '''txt_storeDesc.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("STOREDESC"))
                    ' cbo_Tostore.DropDownStyle = ComboBoxStyle.DropDownList
                    txt_Challanno.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("CHALLENNO"))
                    dtp_Challandate.Value = Format(CDate(gdataset.Tables("stocktransferheader").Rows(0).Item("CHALLENDATE")), "dd/MMM/yyyy")
                    txt_Totalamt.Text = Format(Val(gdataset.Tables("stocktransferheader").Rows(0).Item("TOTALAMT")), "0.00")
                    remarks = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("REMARKS"))
                    txt_Remarks.Text = Replace(remarks, "?", "'")
                    Txt_footer.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("UPDFOOTER"))
                    Txt_signature.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("UPdsign"))
                    ''''********************************* 
                    sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(txt_storecode.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                    gconnection.getDataSet(sqlstring, "STOREMASTER1")
                    If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                        doctype1 = ""
                        'If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
                        'doctype1 = "RET"
                        'lbl_Heading.Text = "STOCK RETURN"
                        'Else
                        doctype1 = "DMG"
                        'lbl_Heading.Text = "STOCK TRANSFER"
                        'End If
                    End If
                    If Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("VOID") & "") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("stocktransferheader").Rows(0).Item("adddate")), "dd/MMM/yyyy")
                        Me.Button1.Enabled = False
                        Me.Button2.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.Button2.Enabled = True
                        Me.lbl_Freeze.Text = "Record Void  On "
                        Me.Button2.Text = "Void[F8]"
                    End If
                    '''************************************************* SELECT RECORD FROM STOCKTRANSFERDETAISL *********************************************''''                
                    sqlstring = "SELECT ISNULL(D.DOCDETAILS,'') AS DOCDETAILS,D.DOCDATE AS DOCDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE, "
                    sqlstring = sqlstring & " ISNULL(D.ITEMNAME,'') AS ITEMNAME,ISNULL(D.UOM,'') AS UOM,ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,"
                    sqlstring = sqlstring & " ISNULL(D.AMOUNT,0) AS AMOUNT,"
                    sqlstring = sqlstring & " ISNULL(D.GROUPCODE,'') AS GROUPCODE,ISNULL(D.SUBGROUPCODE,'') AS SUBGROUPCODE"
                    sqlstring = sqlstring & " FROM STOCKDMGDETAIL AS D WHERE  DOCDETAILS ='" & Trim(txt_Docno.Text) & "' ORDER BY AUTOID"
                    gconnection.getDataSet(sqlstring, "stocktransferdetail")
                    If gdataset.Tables("stocktransferdetail").Rows.Count > 0 Then
                        For i = 1 To gdataset.Tables("stocktransferdetail").Rows.Count
                            'Call GridUOM(i) '''--> Fill UOM in ssgrid
                            ssgrid.SetText(1, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMCODE")))
                            STRITEMCODE = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMCODE"))
                            ssgrid.SetText(2, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMNAME")))
                            ssgrid.Col = 3
                            ssgrid.Row = i
                            ssgrid.Text = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("UOM"))
                            'ssgrid.Text = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("UOM"))
                            STRITEMUOM = Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("UOM"))
                            ssgrid.SetText(4, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("QTY")), "0.000"))
                            'ssgrid.SetText(12, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("QTY")), "0.000"))
                            ssgrid.SetText(5, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("RATE")), "0.00"))
                            ssgrid.SetText(6, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("AMOUNT")), "0.00"))
                            '                         ssgrid.SetText(7, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("DBLAMT")), "0.00"))
                            '                        ssgrid.SetText(8, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("DBLCONV")) & "")
                            '                       ssgrid.SetText(9, i, Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("HIGHRATIO")), "0.00"))
                            ssgrid.SetText(7, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("GROUPCODE")))
                            ssgrid.SetText(8, i, Trim(gdataset.Tables("stocktransferdetail").Rows(j).Item("SUBGROUPCODE")))

                            '  Dim TRFDATE As Date
                            ' TRFDATE = Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy")

                            '                      Clsquantity = ClosingQuantity_Date(STRITEMCODE, Trim(TXT_FROMSTORECODE.Text), STRITEMUOM, TRFDATE)

                            'Clsquantity = ClosingQuantity(STRITEMCODE, Trim(txt_fromstorecode.Text))
                            Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & gdataset.Tables("stocktransferdetail").Rows(j).Item("ITEMCODE") & "' ,'" & Trim(TXT_FROMSTORECODE.Text) & "','" & STRITEMUOM & "')"
                            Dim cls As Double = gconnection.getvalue(SQL)

                            ssgrid.SetText(9, i, cls)
                            varqty = varqty + Format(Val(gdataset.Tables("stocktransferdetail").Rows(j).Item("QTY")), "0.000")
                            j = j + 1
                        Next
                        Me.txt_Totalqty.Text = Format(varqty, "0.00")
                    End If
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    TotalCount = gdataset.Tables("stocktransferdetail").Rows.Count
                    ssgrid.SetActiveCell(1, 1)
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid DOC No :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub cmd_Docnohelp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Docnohelp.Click
        Try
            gSQLString = "SELECT docdetails,docdate FROM STOCKDMGHEADER"
            M_WhereCondition = " where docdetails like '%DMG%' "
            Dim vform As New List_Operation
            vform.Field = "DOCDETAILS,DOCDATE"
            vform.vFormatstring1 = "       DOC NO                       |         DOC DATE                                                           "
            vform.vCaption = "STOCK IN HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Docno.Text = Trim(vform.keyfield & "")
                ssgrid.ClearRange(1, 1, -1, -1, True)
                Call txt_Docno_Validated(txt_Docno, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        Dim Issuerate, clsquantity As Double
        Dim ItemQty, ItemAmount, ItemRate, IssueQty, CurrentQty, purrate, conv As Double
        Dim sqlstring, Itemcode, Itemdesc As String
        '  Dim focusbool As Boolean
        Dim i, j, K As Integer
        search = Nothing
        Try


            If e.keyCode = Keys.Enter Then
                i = ssgrid.ActiveRow
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    ssgrid.Lock = False
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            'Call FillMenu() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE

                            Call FillMenuNew()
                        Else
                            Itemcode = Trim(ssgrid.Text)
                            Call check_Duplicate(Itemcode)
                            If Dupchk = True Then
                                ssgrid.Col = 1
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                ssgrid.Focus()
                                Exit Sub
                            End If
                            ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                            '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
                            sqlstring = sqlstring & " ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(SALERATE,0) AS SALERATE, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                            sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I"
                            sqlstring = sqlstring & " WHERE I.ITEMCODE ='" & Trim(Itemcode) & "'  AND ISNULL(I.FREEZE,'') <> 'Y'  AND I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                            If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                Call check_Duplicate(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                If Dupchk = True Then
                                    ssgrid.Col = 1
                                    ssgrid.Row = ssgrid.ActiveRow
                                    ssgrid.Text = ""
                                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                    ssgrid.Focus()
                                    Exit Sub
                                End If
                                ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                ssgrid.Col = 3
                                ssgrid.Row = ssgrid.ActiveRow
                                ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                                sqlstring = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")) & "'"
                                gconnection.getDataSet(sqlstring, "InventoryItemUOM")
                                If (gdataset.Tables("InventoryItemUOM").Rows.Count > 0) Then
                                    FillTRANSUOM(ssgrid.ActiveRow, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))

                                Else
                                    ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                End If
                                'ssgrid.Col = 3
                                'ssgrid.Row = i
                                'FillTRANSUOM(ssgrid.ActiveRow, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))

                                'ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                'ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))

                                Dim transuom As String = ssgrid.Text
                                conv = changerate(transuom, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                Dim purchaserate As Double = Format(Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("Purchaserate")), "0.00")
                                purchaserate = purchaserate / conv
                                '  ssgrid.SetText(3, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))

                                ssgrid.SetText(5, i, Val(purchaserate))
                                ssgrid.SetText(7, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
                                ssgrid.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
                                Dim cls As Double = gconnection.closing(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))

                                'Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")) & "' ,'" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")) & "')"
                                'Dim cls As Double = gconnection.getvalue(SQL)
                                ssgrid.SetText(9, ssgrid.ActiveRow, Format(Val(cls), "0.00"))
                                LabelClosingQuantity.Text = "Closing Stock For Item Code " & Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")) & " Is " & Format(Val(cls), "0.00") & " Qty"

                            Else
                                MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                Exit Sub
                            End If
                        End If
                    Else
                        ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                    End If
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.Col = 2
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            Call FillMenuNew() ''' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        Else
                            Itemdesc = Trim(ssgrid.Text)
                            ssgrid.ClearRange(1, ssgrid.ActiveRow, 10, ssgrid.ActiveRow, True)
                            '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                            sqlstring = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, "
                            sqlstring = sqlstring & "  ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(PURCHASERATE,0) AS PURCHASERATE, "
                            sqlstring = sqlstring & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I "
                            sqlstring = sqlstring & " WHERE I.ITEMNAME ='" & Trim(Itemdesc) & "'  AND ISNULL(I.FREEZE,'') <> 'Y' AND I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "'"
                            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER1")
                            If gdataset.Tables("INVENTORYITEMMASTER1").Rows.Count > 0 Then
                                ' Call GridUOM(i) '''---> Fill the UOM feild
                                ssgrid.SetText(1, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                ssgrid.SetText(2, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME")))
                                ssgrid.Col = 3
                                ssgrid.Row = ssgrid.ActiveRow
                                ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                                sqlstring = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")) & "'"
                                gconnection.getDataSet(sqlstring, "InventoryItemUOM")
                                If (gdataset.Tables("InventoryItemUOM").Rows.Count > 0) Then
                                    FillTRANSUOM(ssgrid.ActiveRow, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))

                                Else
                                    ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                End If
                                'ssgrid.Col = 3
                                'ssgrid.Row = i
                                'FillTRANSUOM(ssgrid.ActiveRow, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))

                                'ssgrid.TypeComboBoxString = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))
                                'ssgrid.Text = Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM"))

                                Dim transuom As String = ssgrid.Text
                                conv = changerate(transuom, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")))
                                Dim purchaserate As Double = Format(Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("Purchaserate")), "0.00")
                                purchaserate = purchaserate / conv
                                '  ssgrid.SetText(3, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))

                                ssgrid.SetText(5, i, Val(purchaserate))
                                '  ssgrid.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("CONVUOM")))
                                ' ssgrid.SetText(9, i, Val(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("HIGHRATIO")))
                                ssgrid.SetText(7, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("GROUPCODE")))
                                ssgrid.SetText(8, i, Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("SUBGROUPCODE")))
                                'clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), "MNS")
                                '         clsquantity = ClosingQuantity(Trim(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE"))), Trim(txt_Mainstorecode.Text))
                                '        lbl_closingqty.Text = UCase(Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMNAME"))) & " CLOSING QTY : " & Format(Val(clsquantity), "0.000")
                                'Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")) & "' ,'" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")) & "')"
                                'Dim cls As Double = gconnection.getvalue(SQL)
                                Dim cls As Double = gconnection.closing(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("STOCKUOM")))

                                ssgrid.SetText(9, ssgrid.ActiveRow, Format(Val(cls), "0.00"))
                                LabelClosingQuantity.Text = "Closing Stock For Item Code " & Trim(gdataset.Tables("INVENTORYITEMMASTER1").Rows(j).Item("ITEMCODE")) & " Is " & Format(Val(cls), "0.00") & " Qty"

                                ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                            Else
                                MessageBox.Show("Specified ITEM DESCRIPTION not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 3 Then
                    ssgrid.Col = 3
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                        End If
                    End If
                ElseIf ssgrid.ActiveCol = 4 Then

                    Dim sqlrol, rolitem As String
                    Dim mqty, CQty, ROLQty, pqty As Double

                    mqty = 0 : CQty = 0 : ROLQty = 0

                    ssgrid.Col = 9
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    pqty = Val(ssgrid.Text)

                    ssgrid.Col = 4
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    CQty = pqty - Val(ssgrid.Text)


                    ssgrid.Col = 1
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    rolitem = Val(ssgrid.Text)

                    sqlrol = "select isnull(minqty,0) as minqty, isnull(reorderlevel,0) as reorderlevel from inventoryitemmaster where itemcode ='" & Trim(rolitem) & "' and storecode ='" & TXT_FROMSTORECODE.Text & "'"
                    gconnection.getDataSet(sqlrol, "INVENTORYROL")
                    If gdataset.Tables("inventoryrol").Rows.Count > 0 Then
                        mqty = gdataset.Tables("inventoryrol").Rows(0).Item("minqty")
                        ROLQty = gdataset.Tables("inventoryrol").Rows(0).Item("reorderlevel")
                    End If

                    If ROLQty <> 0 Then
                        If CQty < mqty Then
                            If CQty >= ROLQty Then
                                MsgBox("Your Stock Reached ReorderLevel Qty")
                            End If
                        End If
                    End If

                    If mqty <> 0 Then
                        If CQty >= mqty Then
                            MsgBox("Your Stock Reached Minimumlevel Qty")
                        End If
                    End If

                    CurrentQty = 0 : IssueQty = 0
                    ssgrid.Col = 4
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    ssgrid.Lock = False

                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
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

                            ssgrid.Col = 4
                            i = ssgrid.ActiveRow
                            ssgrid.Row = i
                            IssueQty = Val(ssgrid.Text)

                            ssgrid.Col = 9
                            i = ssgrid.ActiveRow
                            ssgrid.Row = i
                            CurrentQty = Val(ssgrid.Text)
                            If IssueQty > CurrentQty Then
                                MsgBox("Stock Not Available to Issue for this Item")
                                ssgrid.Col = 4
                                ssgrid.Row = i
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(4, i)
                                ssgrid.Focus()
                                Exit Sub
                                'ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                                'Exit Sub
                            Else
                                ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                            End If
                        End If
                        txt_clsqty.Text = ""
                    Else
                        ssgrid.Col = 4
                        i = ssgrid.ActiveRow
                        ssgrid.Row = i
                        IssueQty = Val(ssgrid.Text)

                        ssgrid.Col = 9
                        i = ssgrid.ActiveRow
                        ssgrid.Row = i
                        CurrentQty = Val(ssgrid.Text)

                        If IssueQty > CurrentQty Then
                            MsgBox("Issue Qty cannot Be Greater Than Indent Qty")
                            ssgrid.Col = 4
                            ssgrid.Row = i
                            ssgrid.Text = ""
                            ssgrid.SetActiveCell(4, i)
                            ssgrid.Focus()
                            Exit Sub
                            'ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                            'Exit Sub
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)

                        End If
                    End If

                ElseIf ssgrid.ActiveCol = 5 Then
                    ssgrid.Col = 5
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
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
                ElseIf ssgrid.ActiveCol = 6 Then
                    ssgrid.Col = 6
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Val(ssgrid.Text) = 0 Then
                            ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(0, ssgrid.ActiveRow + 1)
                        End If
                    Else
                        ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
                    End If
                ElseIf ssgrid.ActiveCol = 7 Then
                    ssgrid.Col = 7
                    i = ssgrid.ActiveRow
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
                    i = ssgrid.ActiveRow
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
                    i = ssgrid.ActiveRow
                    ssgrid.Row = i
                    If ssgrid.Lock = False Then
                        If Trim(ssgrid.Text) = "" Then
                            ssgrid.SetActiveCell(8, ssgrid.ActiveRow)
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
                        Call FillMenuItem()
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
                i = ssgrid.ActiveRow
                ssgrid.Row = i
                ssgrid.Lock = False
                ' If ssgrid.Lock = False Then
                With ssgrid
                    .Row = .ActiveRow
                    ' .ClearRange(1, .ActiveRow, 11, .ActiveRow, True)
                    .DeleteRows(.ActiveRow, 1)
                    Call Calculate()
                    .SetActiveCell(1, ssgrid.ActiveRow)
                    .Focus()
                    LabelClosingQuantity.Text = ""
                End With
                ' End If
                txt_clsqty.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    'Private Sub FillMenu()
    '    Try
    '        Dim Avgrate, Clsquantity As Double
    '        Dim vform As New ListOperattion1
    '        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
    '        gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(CLSTOCK,0) AS CLSTOCK,ISNULL(CLVALUE,0) AS CLVALUE,0 AS MAINCLSTOCK,ISNULL(I.STOCKUOM,'') AS STOCKUOM, 0 AS AVGRATE, "
    '        gSQLString = gSQLString & " ISNULL(CONVVALUE,0) AS CONVUOM,0 AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
    '        If Trim(vsearch) = " " Then
    '            M_WhereCondition = " "
    '        Else
    '            M_WhereCondition = " WHERE I.ITEMCODE LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'"
    '        End If
    '        vform.Field = "I.ITEMNAME,I.ITEMCODE"
    '        vform.vFormatstring = "   ITEMCODE    |         ITEMNAME       | CLSTOCK   | CLVALUE    | MAINCLSTOCK | STOCKUOM | AVGRATE | CONVUOM | HIGHRATIO |"
    '        vform.vCaption = "INVENTORY ITEM MASTER HELP"
    '        vform.KeyPos = 0
    '        vform.KeyPos1 = 1
    '        vform.KeyPos2 = 4
    '        vform.Keypos3 = 5
    '        vform.keypos4 = 6
    '        vform.Keypos5 = 7
    '        vform.Keypos6 = 8
    '        vform.Keypos7 = 9
    '        vform.Keypos8 = 10
    '        vform.ShowDialog(Me)
    '        If Trim(vform.keyfield & "") <> "" Then
    '            ' Call GridUOM(ssgrid.ActiveRow) '''---> Fill the UOM feild
    '            ssgrid.Col = 1
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Trim(vform.keyfield)
    '            ssgrid.Col = 2
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Trim(vform.keyfield1)

    '            ssgrid.Col = 3
    '            ssgrid.Row = ssgrid.ActiveRow
    '            '  ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
    '            ssgrid.Text = vform.keyfield3
    '            ssgrid.Text = Trim(vform.keyfield3)




    '            ssgrid.Col = 5
    '            ssgrid.Row = ssgrid.ActiveRow
    '            Avgrate = CalAverageRate(Trim(vform.keyfield))
    '            ssgrid.Text = Format(Val(Avgrate), "0.00")
    '            ssgrid.Col = 8
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Trim(vform.keyfield5)
    '            ssgrid.Col = 9
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Format(Val(vform.keyfield6), "0.00")
    '            ssgrid.Col = 10
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Trim(vform.keyfield7)
    '            ssgrid.Col = 11
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Trim(vform.keyfield8)
    '            Clsquantity = ClosingQuantity(Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text))
    '            lbl_closingqty.Text = UCase(Trim(vform.keyfield1)) & " CLOSING QTY : " & Format(Val(Clsquantity), "0.000")
    '            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
    '            ssgrid.Focus()
    '        Else
    '            ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
    '            Exit Sub
    '        End If
    '        vform.Close()
    '        vform = Nothing
    '    Catch ex As Exception
    '        MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub FillMenuNew()
    '    Try
    '        Dim Avgrate, Clsquantity As Double
    '        Dim vform As New ListOperattion1
    '        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
    '        If gsalerate = "Y" Then
    '            gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(CLSTOCK,0) AS CLSTOCK,ISNULL(CLVALUE,0) AS CLVALUE,0 AS MAINCLSTOCK,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(SALERATE,0) AS PURCHASERATE, "
    '            gSQLString = gSQLString & "  ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
    '            If Trim(vsearch) = " " Then
    '                M_WhereCondition = "  WHERE ISNULL(I.STORECODE,'')='" & Trim(TXT_FROMSTORECODE.Text) & "' "
    '            Else
    '                M_WhereCondition = " WHERE I.ITEMCODE LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'  AND ISNULL(I.STORECODE,'')='" & Trim(TXT_FROMSTORECODE.Text) & "'"
    '            End If
    '        Else
    '            gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(CLSTOCK,0) AS CLSTOCK,ISNULL(CLVALUE,0) AS CLVALUE,0 AS MAINCLSTOCK,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(PURCHASERATE,0) AS PURCHASERATE, "
    '            gSQLString = gSQLString & "  ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
    '            If Trim(vsearch) = " " Then
    '                M_WhereCondition = "  WHERE ISNULL(I.STORECODE,'')='" & Trim(TXT_FROMSTORECODE.Text) & "' "
    '            Else
    '                M_WhereCondition = " WHERE I.ITEMCODE LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'  AND ISNULL(I.STORECODE,'')='" & Trim(TXT_FROMSTORECODE.Text) & "'"
    '            End If
    '        End If
    '        vform.Field = "I.ITEMNAME,I.ITEMCODE"
    '        vform.vFormatstring = "   ITEMCODE    |         ITEMNAME       | CLSTOCK   | CLVALUE    | MAINCLSTOCK | STOCKUOM | PURCHASERATE |"
    '        vform.vCaption = "INVENTORY ITEM MASTER HELP"
    '        vform.KeyPos = 0
    '        vform.KeyPos1 = 1
    '        vform.KeyPos2 = 4
    '        vform.Keypos3 = 5
    '        vform.keypos4 = 6
    '        vform.Keypos5 = 7
    '         vform.ShowDialog(Me)
    '        If Trim(vform.keyfield & "") <> "" Then
    '            ' Call GridUOM(ssgrid.ActiveRow) '''---> Fill the UOM feild
    '            ssgrid.Col = 1
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Trim(vform.keyfield)
    '            Call check_Duplicate(vform.keyfield)
    '            If Dupchk = True Then
    '                ssgrid.Col = 1
    '                ssgrid.Row = ssgrid.ActiveRow
    '                ssgrid.Text = ""
    '                ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
    '                ssgrid.Focus()
    '                Exit Sub
    '            End If
    '            ssgrid.Col = 2
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Trim(vform.keyfield1)
    '            Dim Transuom As String
    '            ssgrid.Col = 3
    '            Dim SqlQuery As String
    '            SqlQuery = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & Trim(vform.keyfield) & "'  "
    '            gconnection.getDataSet(SqlQuery, "InventoryItemUOM")
    '            If gdataset.Tables("InventoryItemUOM").Rows.Count > 1 Then
    '                Call FillTransUOM(Trim(vform.keyfield))
    '            ElseIf gdataset.Tables("InventoryItemUOM").Rows.Count = 1 Then
    '                ssgrid.Row = ssgrid.ActiveRow
    '                ssgrid.TypeComboBoxString = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
    '                ssgrid.Text = Trim(gdataset.Tables("InventoryItemUOM").Rows(0).Item("Tranuom"))
    '            Else
    '                ssgrid.Row = ssgrid.ActiveRow
    '                ssgrid.Text = Trim(vform.keyfield3)
    '            End If
    '            Transuom = ssgrid.Text
    '            Dim TRFDATE As Date
    '            TRFDATE = Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy")
    '            'txt_clsqty.Text = ClosingQuantity_Date(Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), Transuom, TRFDATE)
    '            Clsquantity = ClosingQuantity_Date(Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), Transuom, TRFDATE)
    '            txt_clsqty.Text = Format(Val(Clsquantity), "0.000")
    '            '' Clsquantity = ClosingQuantity_NewTrans(Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text), Transuom)
    '            '''ssgrid.Row = ssgrid.ActiveRow
    '            ''''  ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
    '            '''ssgrid.Text = vform.keyfield3
    '            '''ssgrid.Text = Trim(vform.keyfield3)
    '            'ssgrid.Col = 5
    '            'ssgrid.Row = ssgrid.ActiveRow
    '            ''Avgrate = CalAverageRate_new(Trim(vform.keyfield), TRFDATE, Trim(TXT_FROMSTORECODE.Text), Transuom)
    '            ''ssgrid.Text = Format(Val(vform.keyfield4), "0.00")

    '            ''-----changed by ganesh 08/nov/13------
    '            'ssgrid.Text = Format(GetUomRate(vform.keyfield, TRFDATE, Transuom), "0.00")
    '            ''--------------------------------------
    '            '-------------*Added by GANESH on 16/NOV/2013 to get uom convertion rate
    '            'ssgrid.Col = 5
    '            'ssgrid.Row = ssgrid.ActiveRow
    '            ''Avgrate = CalAverageRate_new(Trim(vform.keyfield), TRFDATE, Trim(TXT_FROMSTORECODE.Text), Transuom)
    '            'ssgrid.Text = Format(Val(vform.keyfield4), "0.00")

    '            Dim curuom As String
    '            Dim currate, prate As Double

    '            ssgrid.Col = 3
    '            ssgrid.Row = ssgrid.ActiveRow
    '            curuom = Trim(ssgrid.Text)

    '            If gsalerate = "Y" Then
    '                currate = GetGRNUomSaleRate(Trim(vform.keyfield), dtp_Docdate.Value, curuom)
    '                If currate > 0 Then
    '                    ssgrid.Col = 5
    '                    ssgrid.Row = ssgrid.ActiveRow
    '                    ssgrid.Text = Format(Val(currate), "0.00")
    '                Else
    '                    currate = GetInvUomSaleRate(Trim(vform.keyfield), dtp_Docdate.Value, curuom, Trim(TXT_FROMSTORECODE.Text))
    '                    ssgrid.Col = 5
    '                    ssgrid.Row = ssgrid.ActiveRow
    '                    ssgrid.Text = Format(Val(currate), "0.00")
    '                End If
    '                If boolConv = False Then
    '                    Call DelSsGridItem(ssgrid, 11, ssgrid.ActiveRow)
    '                    Call Calculate()
    '                    Exit Sub
    '                End If
    '            Else
    '                currate = GetGRNUomRate(Trim(vform.keyfield), dtp_Docdate.Value, curuom)
    '                If currate > 0 Then
    '                    ssgrid.Col = 5
    '                    ssgrid.Row = ssgrid.ActiveRow
    '                    ssgrid.Text = Format(Val(currate), "0.00")
    '                Else
    '                    currate = GetInvUomRate(Trim(vform.keyfield), dtp_Docdate.Value, curuom, Trim(TXT_FROMSTORECODE.Text))
    '                    ssgrid.Col = 5
    '                    ssgrid.Row = ssgrid.ActiveRow
    '                    ssgrid.Text = Format(Val(currate), "0.00")
    '                End If
    '                If boolConv = False Then
    '                    Call DelSsGridItem(ssgrid, 11, ssgrid.ActiveRow)
    '                    Call Calculate()
    '                    Exit Sub
    '                End If
    '            End If

    '            '--------------*----------------------------------------------------------------

    '            ssgrid.Col = 8
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Trim(vform.keyfield5)
    '            ssgrid.Col = 9
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Format(Val(vform.keyfield6), "0.00")
    '            ssgrid.Col = 10
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Trim(vform.keyfield7)
    '            ssgrid.Col = 11
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Trim(vform.keyfield8)
    '            ssgrid.Col = 13
    '            ssgrid.Row = ssgrid.ActiveRow
    '            ssgrid.Text = Format(Val(Clsquantity), "0.000")
    '            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
    '            ssgrid.Focus()
    '        Else
    '            ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
    '            Exit Sub
    '        End If
    '        vform.Close()
    '        vform = Nothing
    '    Catch ex As Exception
    '        MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '        Exit Sub
    '    End Try
    'End Sub

    Private Sub FillTRANSUOM(ByVal i As Integer, ByVal itemcode As String)
        Try
            Dim Z As Integer
            sqlstring = "SELECT ISNULL(TranUom,'') AS UOMDESC FROM INVITEM_TRANSUOM_LINK WHERE itemcode='" & itemcode & "'"
            gconnection.getDataSet(sqlstring, "UOMMASTER1")
            If gdataset.Tables("UOMMASTER1").Rows.Count > 0 Then
                For Z = 0 To gdataset.Tables("UOMMASTER1").Rows.Count - 1
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    ssgrid.TypeComboBoxString = Trim(gdataset.Tables("UOMMASTER1").Rows(Z).Item("UOMDESC"))
                    ssgrid.Text = Trim(gdataset.Tables("UOMMASTER1").Rows(Z).Item("UOMDESC"))
                Next Z
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Function changerate(ByVal uomr As String, ByVal itemcode As String) As Double
        Dim conv As Double
        Dim sql As String = "select convvalue from INVENTORY_TRANSCONVERSION where baseuom=(select distinct stockuom from inventoryitemmaster where storecode='" + Trim(TXT_FROMSTORECODE.Text) + "' and itemcode='" + itemcode + "')"
        sql = sql & " and Transuom='" + uomr + "'"
        gconnection.getDataSet(sql, "INVENTORY_TRANSCONVERSION")
        If (gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0) Then
            conv = Convert.ToDouble(gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows(0).Item("convvalue"))
        Else
            conv = 1
        End If
        Return conv
    End Function
    Private Sub FillMenuNew()
        Try
            Dim Avgrate, clsquantity, conv As Double
            Dim K As Integer
            Dim vform As New ListOperattion1
            If gsalerate = "Y" Then
                gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(CLSTOCK,0) AS CLSTOCK,ISNULL(CLVALUE,0) AS CLVALUE,ISNULL(I.STOCKUOM,'') AS STOCKUOM,ISNULL(PURCHASERATE,0) AS PURCHASERATE, "
                gSQLString = gSQLString & "  ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
                If Trim(vsearch) = " " Then
                    M_WhereCondition = " WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "'"
                Else
                    M_WhereCondition = " WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND " & "I.ITEMCODE LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'"
                End If
            Else

                gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(CLSTOCK,0) AS CLSTOCK,ISNULL(CLVALUE,0) AS CLVALUE,ISNULL(I.STOCKUOM,'') AS STOCKUOM,ISNULL(PURCHASERATE,0) AS PURCHASERATE, "
                gSQLString = gSQLString & "  ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
                If Trim(vsearch) = " " Then
                    M_WhereCondition = " WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "'"
                Else
                    M_WhereCondition = " WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND " & "I.ITEMCODE LIKE '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'"
                End If
            End If
            vform.Field = "I.ITEMNAME,I.ITEMCODE"
            vform.vFormatstring = "   ITEMCODE    |              ITEMNAME              | CLSTOCK   | CLVALUE   | STOCKUOM | PURCHASERATE | GROUPCODE | SUBGROUPCODE |"
            vform.vCaption = "INVENTORY ITEM CODE HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.Keypos5 = 5
            vform.Keypos6 = 6
            vform.Keypos7 = 7

            '  vform.Keypos6 = 8
            '  vform.Keypos7 = 9
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                ' Call GridUOM(ssgrid.ActiveRow) '''---> Fill the UOM feild
                ssgrid.Col = 1
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield)
                Call check_Duplicate(vform.keyfield)
                If Dupchk = True Then
                    ssgrid.Col = 1
                    ssgrid.Row = ssgrid.ActiveRow
                    ssgrid.Text = ""
                    ssgrid.SetActiveCell(0, ssgrid.ActiveRow)
                    ssgrid.Focus()
                    Exit Sub
                End If
                Dim SqlQuery As String
                ssgrid.Col = 2
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield1)
                ssgrid.Col = 3
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                SqlQuery = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & Trim(vform.keyfield) & "'"
                gconnection.getDataSet(SqlQuery, "InventoryItemUOM")
                If (gdataset.Tables("InventoryItemUOM").Rows.Count > 0) Then
                    FillTransUOM(ssgrid.ActiveRow, Trim(vform.keyfield))

                Else
                    ssgrid.Text = Trim(vform.keyfield4)
                End If
                Dim transuom As String = ssgrid.Text
                conv = changerate(ssgrid.Text, vform.keyfield)
                Dim purchaserate As Double = Format(Val(vform.keyfield5), "0.00")
                purchaserate = purchaserate / conv

                ssgrid.Col = 5
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.SetText(5, ssgrid.ActiveRow, Format(Val(purchaserate), "0.00"))

                ssgrid.Col = 7
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.SetText(7, ssgrid.ActiveRow, (Trim(vform.keyfield6)))

                ssgrid.Col = 8
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.SetText(8, ssgrid.ActiveRow, (Trim(vform.keyfield7)))

                ' ssgrid.Col = 9
                'ssgrid.Row = ssgrid.ActiveRow
                'ssgrid.SetText(9, ssgrid.ActiveRow, (Trim(vform.keyfield2)))
                Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & vform.keyfield & "' ,'" & Trim(TXT_FROMSTORECODE.Text) & "','" & vform.keyfield4 & "')"
                Dim cls As Double = gconnection.getvalue(SQL)
                ssgrid.SetText(9, ssgrid.ActiveRow, Format(Val(cls), "0.00"))
                LabelClosingQuantity.Text = "Closing Stock For Item " & vform.keyfield & " Is " & Format(Val(cls), "0.00") & " Qty"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub

    Private Sub FillTransUOM(ByVal itemcode As String)
        gSQLString = "SELECT ISNULL(Tranuom,'') AS Tranuom  FROM  INVITEM_TRANSUOM_LINK  WHERE Itemcode ='" & itemcode & "'   "
        If Trim(search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " AND  Tranuom LIKE '" & Trim(search) & "%'"
        End If
        Dim vform1 As New ListOperattion1
        vform1.Field = "TRANUOM"
        vform1.vFormatstring = "     TRANS UOM                                                                                                   "
        vform1.vCaption = " PURCHASE UOMMASTER HELP"
        vform1.KeyPos = 0
        vform1.ShowDialog(Me)
        If Trim(vform1.keyfield & "") <> "" Then
            ssgrid.Col = 3
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Text = Trim(vform1.keyfield & "")
            ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
            ssgrid.Focus()
        End If
        vform1.Close()
        vform1 = Nothing
    End Sub

    Private Sub FillMenuItem()
        Try
            Dim Avgrate, Clsquantity As Double
            Dim vform As New ListOperattion1
            Dim ssql As String
            '''******************************************************** $ FILL THE ITEMDESC,ITEMCODE INTO SSGRID ********** 
            gSQLString = " SELECT DISTINCT  ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.ITEMCODE,'') AS ITEMCODE,0 AS MAINCLSTOCK,ISNULL(I.STOCKUOM,'') AS STOCKUOM,  "
            gSQLString = gSQLString & " isnull(i.purchaserate,0) as purchaserate,  ISNULL(I.GROUPCODE,'') AS GROUPCODE, ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I  "
            If Trim(vsearch) = " " Then
                M_WhereCondition = " I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' "
            Else
                M_WhereCondition = " WHERE I.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND I.ITEMNAME like '" & Trim(vsearch) & "%' AND ISNULL(I.FREEZE,'') <> 'Y'"
            End If
            vform.Field = "I.ITEMNAME,I.ITEMCODE"
            vform.vFormatstring = "             ITEMNAME               |  ITEMCODE   | MAINCLSTOCK | STOCKUOM | AVGRATE |"
            vform.vCaption = "INVENTORY ITEM CODE HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.keypos4 = 4
            vform.Keypos5 = 5
            vform.Keypos6 = 6
            vform.Keypos7 = 7
            vform.Keypos8 = 8
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                ssgrid.Col = 1
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield1)
                ssgrid.Col = 2
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield)
                ssgrid.Col = 3
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeComboBox
                ssgrid.Text = vform.keyfield3
                ssgrid.Text = Trim(vform.keyfield3)
                ssgrid.Col = 5
                ssgrid.Row = ssgrid.ActiveRow
                '   Avgrate = CalAverageRate(Trim(vform.keyfield))
                ssgrid.Text = Format(Val(vform.keyfield4), "0.00")
                ssgrid.Col = 7
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Trim(vform.keyfield5)
                ssgrid.Col = 8
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.Text = Format(Val(vform.keyfield6), "0.00")
                Clsquantity = ClosingQuantity(Trim(vform.keyfield), Trim(TXT_FROMSTORECODE.Text))
                lbl_closingqty.Text = UCase(Trim(vform.keyfield1)) & " CLOSING QTY : " & Format(Val(Clsquantity), "0.000")
                ssgrid.SetActiveCell(9, ssgrid.ActiveRow)
                ssgrid.Focus()
            Else
                ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Challanno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Challanno.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                dtp_Docdate.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub dtp_Docdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_Docdate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                'dtp_Challandate.Focus()
                ssgrid.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub dtp_Challandate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_Challandate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                ssgrid.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Totalamt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Totalamt.LostFocus
        Try
            txt_Totalamt.Text = Format(Val(txt_Totalamt.Text), "0.00")
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Totalqty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Totalqty.LostFocus
        Try
            txt_Totalqty.Text = Format(Val(txt_Totalqty.Text), "0.00")
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Totalamt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Totalamt.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txt_Totalqty.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Totalqty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Totalqty.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                txt_Remarks.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Remarks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Remarks.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Button1.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Stock_DMG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call Button1_Click(Cmd_Clear, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F8 Then
                Call Cmd_Freeze_Click(Button2, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F7 Then
                Call Cmd_Add_Click(Button1, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F2 Then
                txt_Docno.Text = ""
                txt_Docno.Focus()
                Exit Sub
            ElseIf e.KeyCode = Keys.F9 Then
                Call Cmd_View_Click(Button3, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F10 Then
                Call cmd_Print_Click(Button4, e)
                Exit Sub
            ElseIf e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
                If grp_Stockissue.Top = 176 Then
                    grp_Stockissue.Top = 1000
                    Button3.Focus()
                    Exit Sub
                Else
                    Call Cmd_Exit_Click(Button5, e)
                    Exit Sub
                End If
            ElseIf e.Alt = True And e.KeyCode = Keys.R Then
                Me.txt_Remarks.Focus()
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.A Then
                Me.txt_Totalamt.Focus()
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.G Then
                Me.ssgrid.Focus()
                Me.ssgrid.SetActiveCell(1, 1)
                Exit Sub
            ElseIf e.Alt = True And e.KeyCode = Keys.Q Then
                Me.txt_Totalqty.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub checkValidation()
        Try
            Dim i, j As Integer
            Dim itemcode As String
            boolchk = False
            Call Checkdatevalidate(Format(dtp_Docdate.Value, "dd/MMM/yyyy"))
            If chkdatevalidate = False Then Exit Sub
            '''********** Check  From Store Can't be blank *********************'''
            If Trim(TXT_FROMSTORECODE.Text) = "" Then
                MessageBox.Show(" From Store field can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_FROMSTORECODE.Focus()
                Exit Sub
            End If
            '''********** Check  To Store Can't be blank *********************'''
            'If Trim(txt_storecode.Text) = "" Then
            '    MessageBox.Show(" To Store field can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_storecode.Focus()
            '    Exit Sub
            'End If
            '''********** Check  Challan No. Can't be blank *********************'''
            'If Trim(txt_Challanno.Text) = "" Then
            '    MessageBox.Show(" Challan No. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_Challanno.Focus()
            '    Exit Sub
            'End If
            '''********** Check  Totalamount Can't be blank *********************'''
            If Val(txt_Totalamt.Text) = 0 Then
                MessageBox.Show(" Totalamount can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_Totalamt.Focus()
                Exit Sub
            End If
            '''********** Check  DOC No. Can't be blank *********************'''
            If Trim(txt_Docno.Text) = "" Then
                MessageBox.Show(" DOC No. field can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_Docno.Focus()
                Exit Sub
            End If
            ''' ********** Check ItemCode,ItemDesc,UOM,Rate can't be blank ***********'''
            For i = 1 To ssgrid.DataRowCnt
                ssgrid.Row = i
                ssgrid.Col = 1
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("ItemCode can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(1, i)
                    Exit Sub
                End If
                ssgrid.Col = 2
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Itemdesc can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(2, i)
                    Exit Sub
                End If
                ssgrid.Col = 3
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("UOM can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(3, i)
                    Exit Sub
                End If
                ssgrid.Col = 4
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Quantity can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(4, i)
                    Exit Sub
                End If
                ssgrid.Col = 5
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Rate can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(5, i)
                    Exit Sub
                End If
                ssgrid.Col = 6
                If Val(ssgrid.Text) = 0 Then
                    MessageBox.Show("Amount can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(6, i)
                    Exit Sub
                End If
                ssgrid.Col = 7
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Group Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(8, i)
                    Exit Sub
                End If
                ssgrid.Col = 8
                If Trim(ssgrid.Text) = "" Then
                    MessageBox.Show("Sub Group Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ssgrid.SetActiveCell(10, i)
                    Exit Sub
                End If
            Next i

            ''''****************************************CHECK FOR CLSSTOCK OF CORRESPONDING SUBSTORE ******************************************************'''
            'Dim CURQTY, PREVQTY, CLSQTY, VDIFF As Double
            'For i = 1 To ssgrid.DataRowCnt
            '    ssgrid.Row = i
            '    ssgrid.Col = 4
            '    CURQTY = Val(ssgrid.Text)
            '    ssgrid.Col = 12
            '    PREVQTY = Val(ssgrid.Text)
            '    ssgrid.Col = 13
            '    CLSQTY = Val(ssgrid.Text)
            '    VDIFF = Val(CLSQTY) + Val(PREVQTY) - Val(CURQTY)
            '    If Val(VDIFF) < 0 Then
            '        MessageBox.Show("STOCK IS NOT SUFFICIENT TO  MODIFY...", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        ssgrid.Col = 4
            '        ssgrid.Text = ""
            '        ssgrid.SetActiveCell(4, i)
            '        ssgrid.Focus()
            '        Exit Sub
            '    End If
            'Next

            '''''''****************************************** Check if that specified quantity is avaliable or not *************************************************'''
            ''''For i = 1 To ssgrid.DataRowCnt
            ''''    ssgrid.Row = i
            ''''    ssgrid.Col = 1
            ''''    itemcode = Trim(ssgrid.Text)
            ''''    Dim VCHKCURQTY, VCHKCLQTY As Double
            ''''    ssgrid.Col = 4
            ''''    VCHKCURQTY = ssgrid.Text
            ''''    VCHKCLQTY = ClosingQuantity(Trim(itemcode), Trim(TXT_FROMSTORECODE.Text))
            ''''    If Val(VCHKCURQTY) > Val(VCHKCLQTY) Then
            ''''        MessageBox.Show("Specified quantity is not available" & vbCrLf & " for itemcode " & itemcode, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            ''''        ssgrid.SetActiveCell(4, i)
            ''''        ssgrid.Text = ""
            ''''        ssgrid.Focus()
            ''''        Exit Sub
            ''''    End If
            ''''Next i

            '''****************************************** Check if that specified quantity is completed *************************************************'''
            boolchk = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub GridUOM(ByVal i As Integer)
        Try
            Dim j As Integer
            sqlstring = "SELECT UOMdesc FROM UOMMaster WHERE freeze='N'"
            gconnection.getDataSet(sqlstring, "UOMMaster1")
            If gdataset.Tables("UOMMaster1").Rows.Count > 0 Then
                For j = 0 To gdataset.Tables("UOMMaster1").Rows.Count - 1
                    ssgrid.Col = 3
                    ssgrid.Row = i
                    ssgrid.Text = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMdesc"))
                    ssgrid.Text = Trim(gdataset.Tables("UOMMaster1").Rows(j).Item("UOMdesc"))
                Next j
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Calculate()
        Try
            Dim ValQty, ValRate, ValDiscount, VarTotal, Clsquantiy As Double
            Dim ValHighratio, ValItemamount, ValDblamount, Calqty, Varqty As Double
            Dim Itemcode As String
            Dim i, j As Integer
            If ssgrid.ActiveCol = 1 Or ssgrid.ActiveCol = 2 Or ssgrid.ActiveCol = 3 Or ssgrid.ActiveCol = 4 Or ssgrid.ActiveCol = 5 Or ssgrid.ActiveCol = 6 Then
                i = ssgrid.ActiveRow
                ssgrid.Col = 4
                ssgrid.Row = i
                ValQty = Val(ssgrid.Text)
                ssgrid.Col = 5
                ssgrid.Row = i
                ValRate = Val(ssgrid.Text)
                ssgrid.Col = 9
                ssgrid.Row = i
                ValHighratio = Val(ssgrid.Text())
                ValItemamount = Format(Val(ValQty) * Val(ValRate), "0.00")
                ValDblamount = Format(Val(ValQty) * Val(ValHighratio), "0.00")
                If Val(ValItemamount) = 0 Then
                    ssgrid.SetText(6, i, "")
                    '   ssgrid.SetText(7, i, "")
                Else
                    ssgrid.SetText(6, i, Val(ValItemamount))
                    '   ssgrid.SetText(7, i, Val(ValDblamount))
                End If
                ssgrid.Col = 1
                ssgrid.Row = ssgrid.ActiveRow
                Itemcode = Trim(ssgrid.Text)
                For j = 1 To ssgrid.DataRowCnt
                    ssgrid.Col = 1
                    ssgrid.Row = j
                    If Trim(Itemcode) = Trim(ssgrid.Text) Then
                        ssgrid.Col = 4
                        ssgrid.Row = j
                        Calqty = Calqty + Val(ssgrid.Text)
                    End If
                Next j
                'Clsquantiy = ClosingQuantity(Trim(Itemcode), Trim(TXT_FROMSTORECODE.Text))
                ssgrid.Col = 2
                ssgrid.Row = i
                lbl_closingqty.Text = UCase(Trim(ssgrid.Text)) & " CLOSING QTY : " & Format(Val(Clsquantiy - Calqty), "0.000")
                Me.txt_Totalamt.Text = 0
                VarTotal = 0
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Col = 6
                    ssgrid.Row = i
                    VarTotal = Val(ssgrid.Text)
                    Me.txt_Totalamt.Text = Format(Val(Me.txt_Totalamt.Text) + Val(VarTotal), "0.00")
                Next i
                i = i - 1

                Me.txt_Totalqty.Text = 0
                Varqty = 0
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    Varqty = Val(ssgrid.Text)
                    Me.txt_Totalqty.Text = Format(Val(Me.txt_Totalqty.Text) + Val(Varqty), "0.00")
                Next i
                i = i - 1

            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Docno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Docno.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                If cmd_Docnohelp.Enabled = True Then
                    search = Trim(txt_Docno.Text)
                    Call cmd_Docnohelp_Click(cmd_Docnohelp, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Docno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Docno.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_Docno.Text) = "" Then
                    Call cmd_Docnohelp_Click(cmd_Docnohelp, e)
                Else
                    txt_Docno_Validated(txt_Docno, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Stock_DMG_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Try
            StockTransferTransbool = False
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub ssgrid_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid.LeaveCell
        Dim Issuerate, Highratio, Dblamount, conv As Double
        Dim ItemQty, ItemAmount, ItemRate As Double
        Dim sqlstring, Itemcode, Itemdesc As String
        Dim focusbool As Boolean
        Dim i, j As Integer
        search = Nothing

        Try
            If ssgrid.ActiveCol = 1 Or ssgrid.ActiveCol = 2 Then
                Call Calculate()
            End If
            i = ssgrid.ActiveRow
            If ssgrid.ActiveCol = 3 Then
                ssgrid.Col = 1
                Itemcode = ssgrid.Text
                ssgrid.Col = 3
                Dim uomc As String = ssgrid.Text
                Dim cls As Double = gconnection.closing(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"), Trim(Itemcode), Trim(TXT_FROMSTORECODE.Text), Trim(uomc))
                ssgrid.SetText(9, ssgrid.ActiveRow, Format(Val(cls), "0.00"))
                LabelClosingQuantity.Text = "Closing Stock For Item " & Trim(Itemcode) & " Is " & Format(Val(cls), "0.00") & " Qty"
                conv = changerate(uomc, Trim(Itemcode))
                Dim purchaserate As Double = Format(Val(ItemRate), "0.00")
                Dim sql1 As String = "select purchaserate from inventoryitemmaster where itemcode='" & Itemcode & "' and storecode='" & TXT_FROMSTORECODE.Text & "' and isnull(Freeze,'')<>'Y'"
                gconnection.getDataSet(sql1, "INVENTORYROL")
                If (gdataset.Tables("INVENTORYROL").Rows.Count > 0) Then
                    purchaserate = Convert.ToDouble(gdataset.Tables("INVENTORYROL").Rows(0).Item("purchaserate"))
                End If


                purchaserate = purchaserate / conv
                ssgrid.SetText(5, i, Val(purchaserate))
            ElseIf ssgrid.ActiveCol = 4 Then
                ssgrid.Col = 4
                i = ssgrid.ActiveRow
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Val(ssgrid.Text) = 0 Then
                        ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
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
            ElseIf ssgrid.ActiveCol = 5 Then
                ssgrid.Col = 5
                i = ssgrid.ActiveRow
                ssgrid.Row = i
                If ssgrid.Lock = False Then
                    If Val(ssgrid.Text) = 0 Then
                        ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
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
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_FromDocno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_FromDocno.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Cmd_FromDocno.Enabled = True Then
                search = Trim(txt_FromDocno.Text)
                Call Cmd_FromDocno_Click(Cmd_FromDocno, e)
            End If
        End If
    End Sub
    Private Sub txt_FromDocno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_FromDocno.Validated
        If Trim(txt_FromDocno.Text) <> "" Then
            Try
                sqlstring = "SELECT  ISNULL(DOCDETAILS,'') AS DOCDETAILS"
                sqlstring = sqlstring & " FROM STOCKISSUEHEADER WHERE DOCDETAILS='" & Trim(txt_FromDocno.Text) & "'"
                gconnection.getDataSet(sqlstring, "STOCKISSUEHEADER")
                '''************************************************* SELECT record from Grn_header *********************************************''''                
                If gdataset.Tables("STOCKISSUEHEADER").Rows.Count > 0 Then
                    Me.txt_FromDocno.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("DOCDETAILS"))
                    Me.txt_FromDocno.ReadOnly = True
                End If
            Catch ex As Exception
                MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
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
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_ToDocno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ToDocno.Validated
        If Trim(txt_ToDocno.Text) <> "" Then
            Try
                sqlstring = "SELECT  ISNULL(DOCDETAILS,'') AS DOCDETAILS"
                sqlstring = sqlstring & " FROM STOCKISSUEHEADER WHERE DOCDETAILS='" & Trim(txt_ToDocno.Text) & "'"
                gconnection.getDataSet(sqlstring, "STOCKISSUEHEADER")
                '''************************************************* SELECT record from Grn_header *********************************************''''                
                If gdataset.Tables("STOCKISSUEHEADER").Rows.Count > 0 Then
                    Me.txt_ToDocno.Text = Trim(gdataset.Tables("STOCKISSUEHEADER").Rows(0).Item("DOCDETAILS"))
                    Me.txt_ToDocno.ReadOnly = True
                End If
            Catch ex As Exception
                MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub Cmd_FromDocno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_FromDocno.Click
        Try
            gSQLString = "SELECT docdetails,docdate FROM STOCKTRANSFERHEADER"
            M_WhereCondition = " "
            Dim vform As New List_Operation
            vform.Field = "DOCDETAILS,DOCDATE"
            vform.vFormatstring1 = "       DOC NO.            |         DOC DATE                             "
            vform.vCaption = "STOCK TRANSFER/RETURN HELP"
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
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_ToDocno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ToDocno.Click
        Try
            gSQLString = "SELECT docdetails,docdate FROM STOCKTRANSFERHEADER"
            M_WhereCondition = " "
            Dim vform As New List_Operation
            vform.Field = "DOCDETAILS,DOCDATE"
            vform.vFormatstring1 = "       DOC NO.            |         DOC DATE                             "
            vform.vCaption = "STOCK TRANSFER/RETURN HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_ToDocno.Text = Trim(vform.keyfield & "")
                Cmd_IssueView.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
                    Cmd_IssueView.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_IssueView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_IssueView.Click
        Try
            gPrint = False
            Dim i As Integer
            Dim objStockIssueClass As New rptStockissuereport
            If Trim(txt_FromDocno.Text) = "" Then
                MessageBox.Show("From doc no. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Trim(txt_ToDocno.Text) = "" Then
                MessageBox.Show("To doc no. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            Dim arraystring() As String = {"ITEM CODE", "ITEM NAME", "UOM", "QUANTITY", "RATE", "AMOUNT"}
            Dim heading() As String = {"STOCK ISSUE TO BAR"}
            Dim colsize() As Integer = {15, 40, 16, 10, 10, 12}
            objStockIssueClass.Reportdetails(sqlstring, heading, arraystring, colsize)
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
            GmoduleName = "Stock Damage"

            SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
            gconnection.getDataSet(SQLSTRING, "USER")
            If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                    With gdataset.Tables("USER").Rows(i)
                        chstr = abcdMINUS(.Item("RIGHTS"))
                    End With
                Next
            End If
            Me.Button1.Enabled = False
            Me.Button2.Enabled = False
            Me.Button3.Enabled = False
            'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
            If Len(chstr) > 0 Then
                Dim Right() As Char
                Right = chstr.ToCharArray
                For x = 0 To Right.Length - 1
                    If Right(x) = "A" Then
                        Me.Button1.Enabled = True
                        Me.Button2.Enabled = True
                        Me.Button3.Enabled = True
                        Exit Sub
                    End If
                    If UCase(Mid(Me.Button1.Text, 1, 1)) = "A" Then
                        If Right(x) = "S" Then
                            Me.Button1.Enabled = True
                        End If
                    Else
                        If Right(x) = "M" Then
                            Me.Button1.Enabled = True
                        End If
                    End If
                    If Right(x) = "D" Then
                        Me.Button2.Enabled = True
                    End If
                    If Right(x) = "V" Then
                        Me.Button3.Enabled = True
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Chk_item_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_item.CheckedChanged
        If Chk_item.Checked = True Then
            grp_footer.Visible = True
            Txt_footer.Focus()
        Else
            grp_footer.Visible = False
        End If
    End Sub
    Private Sub Txt_footer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_footer.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_footer.Text) <> "" Then
                Txt_signature.Focus()
            Else
                Txt_footer.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_signature_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_signature.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Chk_item.Focus()
        End If
    End Sub
    Public Function FOOTER()
        sqlstring = "SELECT isnull(UPDFOOTER,'') as UPDFOOTER,isnull(UPDsign,'') as UPDsign FROM stocktransferheader WHERE  AUTOID IN (SELECT MAX(AUTOID) FROM STOCKISSUEHEADER )"
        gconnection.getDataSet(sqlstring, "stocktransferheader")
        If gdataset.Tables("stocktransferheader").Rows.Count > 0 Then
            Txt_footer.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("UPDFOOTER"))
            Txt_signature.Text = Trim(gdataset.Tables("stocktransferheader").Rows(0).Item("UPdsign"))
        End If
    End Function

    Private Sub cmd_fromStorecodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_fromStorecodeHelp.Click
        gSQLString = "SELECT DISTINCT storecode,ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER"
        M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_FROMSTORECODE.Text = Trim(vform.keyfield & "")
            txt_FromStorename.Text = Trim(vform.keyfield1 & "")
            doctype1 = ""
            doctype1 = "DMG"
            Call autogenerate()
        Else
            Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub TXT_FROMSTORECODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_FROMSTORECODE.Validated
        If Trim(TXT_FROMSTORECODE.Text) <> "" Then
            sqlstring = "SELECT * FROM STOREMASTER WHERE storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
            gconnection.getDataSet(sqlstring, "storemaster")
            If gdataset.Tables("storemaster").Rows.Count > 0 Then
                TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                txt_FromStorename.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                doctype1 = ""
                doctype1 = "DMG"
                Call autogenerate()
                dtp_Docdate.Focus()
            Else
                TXT_FROMSTORECODE.Text = ""
                TXT_FROMSTORECODE.Focus()
            End If
        End If
    End Sub

    Private Sub cmd_storecode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_storecode.Click
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM STOREMASTER "
        M_WhereCondition = " where freeze <> 'Y' "
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "         STORE CODE              |                  STORE DESCRIPTION                                                                                                   "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_FROMSTORECODE.Text = Trim(vform.keyfield & "")
            txt_FromStorename.Text = Trim(vform.keyfield1 & "")

            If txt_storecode.Text = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
                sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    doctype1 = ""
                    'If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
                    'doctype1 = "RET"
                    'lbl_Heading.Text = "STOCK RETURN"
                    'Else
                    doctype1 = "DMG"
                    'lbl_Heading.Text = "STOCK TRANSFER"
                    'End If
                    Call autogenerate()
                End If
                txt_Challanno.Focus()
            Else
                sqlstring = " SELECT DISTINCT(storecode),storedesc FROM STOREMASTER"
                sqlstring = sqlstring & " WHERE STORECODE = '" & txt_storecode.Text & "'"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    txt_storeDesc.Text = gdataset.Tables("STOREMASTER1").Rows(0).Item("STOREDESC")
                    txt_Challanno.Focus()
                End If
                sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    doctype1 = ""
                    'If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
                    'doctype1 = "RET"
                    'lbl_Heading.Text = "STOCK RETURN"
                    'Else
                    doctype1 = "DMG"
                    'lbl_Heading.Text = "STOCK TRANSFER"
                    'End If
                    Call autogenerate()
                End If
            End If
            txt_Challanno.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_storecode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_storecode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txt_storecode.Text = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
                sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    doctype1 = ""
                    'If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
                    doctype1 = "DMG"
                    'lbl_Heading.Text = "STOCK RETURN"
                    'Else
                    'doctype1 = "TRF"
                    'lbl_Heading.Text = "STOCK TRANSFER"
                    'End If
                    Call autogenerate()
                End If
                dtp_Docdate.Focus()
            Else
                sqlstring = " SELECT DISTINCT(storecode),storedesc FROM STOREMASTER"
                sqlstring = sqlstring & " WHERE STORECODE = '" & txt_storecode.Text & "'"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    txt_storeDesc.Text = gdataset.Tables("STOREMASTER1").Rows(0).Item("STOREDESC")
                    dtp_Docdate.Focus()
                End If
                sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
                gconnection.getDataSet(sqlstring, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    doctype1 = ""
                    'If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
                    doctype1 = "DMG"
                    'lbl_Heading.Text = "STOCK RETURN"
                    'Else
                    'doctype1 = "TRF"
                    'lbl_Heading.Text = "STOCK TRANSFER"
                    'End If
                    Call autogenerate()
                End If
            End If
        End If
    End Sub

    Private Sub txt_storecode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_storecode.LostFocus
        txt_storecode.BackColor = Color.Wheat
        Label2.Visible = False
    End Sub
    Private Sub txt_storecode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_storecode.GotFocus
        txt_storecode.BackColor = Color.Gold
        Label2.Visible = True
    End Sub
    Private Sub TXT_FROMSTORECODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_FROMSTORECODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_FROMSTORECODE.Text) = "" Then
                Call cmd_fromStorecodeHelp_Click(TXT_FROMSTORECODE.Text, e)
                Me.dtp_Docdate.Focus()
            Else
                Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
            End If
        End If
    End Sub
    Private Sub TXT_FROMSTORECODE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_FROMSTORECODE.LostFocus
        TXT_FROMSTORECODE.BackColor = Color.Wheat
        Label1.Visible = False
    End Sub
    Private Sub TXT_FROMSTORECODE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_FROMSTORECODE.GotFocus
        TXT_FROMSTORECODE.BackColor = Color.Gold
        Label1.Visible = True
    End Sub

    Private Sub txt_Docno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Docno.GotFocus
        txt_Docno.BackColor = Color.Gold
        Label16.Visible = True
    End Sub

    Private Sub txt_Docno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Docno.LostFocus
        txt_Docno.BackColor = Color.Wheat
        Label16.Visible = False
    End Sub

    Private Sub ssgrid_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid.Advance

    End Sub

    Private Sub txt_Docno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Docno.TextChanged

    End Sub
    Private Sub TXT_FROMSTORECODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_FROMSTORECODE.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    If TXT_FROMSTORECODE.Text = "" Then
        '        Call cmd_storecode_Click(cmd_storecode, e)
        '        sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
        '        gconnection.getDataSet(sqlstring, "STOREMASTER1")
        '        If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
        '            doctype1 = ""
        '            'If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
        '            doctype1 = "DMG"
        '            'lbl_Heading.Text = "STOCK RETURN"
        '            'Else
        '            'doctype1 = "TRF"
        '            'lbl_Heading.Text = "STOCK TRANSFER"
        '            'End If
        '            Call autogenerate()
        '        End If
        '        dtp_Docdate.Focus()
        '    Else
        '        sqlstring = " SELECT DISTINCT(storecode),storedesc FROM STOREMASTER"
        '        sqlstring = sqlstring & " WHERE STORECODE = '" & txt_storecode.Text & "'"
        '        gconnection.getDataSet(sqlstring, "STOREMASTER1")
        '        If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
        '            txt_storeDesc.Text = gdataset.Tables("STOREMASTER1").Rows(0).Item("STOREDESC")
        '            dtp_Docdate.Focus()
        '        End If
        '        sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
        '        gconnection.getDataSet(sqlstring, "STOREMASTER1")
        '        If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
        '            doctype1 = ""
        '            'If Trim(gdataset.Tables("STOREMASTER1").Rows(0).Item("STORESTATUS")) = "M" Then
        '            doctype1 = "DMG"
        '            'lbl_Heading.Text = "STOCK RETURN"
        '            'Else
        '            'doctype1 = "TRF"
        '            'lbl_Heading.Text = "STOCK TRANSFER"
        '            'End If
        '            Call autogenerate()
        '        End If
        '        dtp_Docdate.Focus()
        '    End If
        'End If
    End Sub

    Private Sub txt_storecode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_storecode.TextChanged

    End Sub

    Private Sub TXT_FROMSTORECODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_FROMSTORECODE.TextChanged

    End Sub

    Private Sub dtp_Challandate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_Challandate.ValueChanged

    End Sub

    Private Sub cmd_Print_ContextMenuChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    'MANISH03/01/2014
    '**********ACCOUNTS POSTING
    Public Sub ACCPOST()
        Dim INSERT(0) As String
        Dim ACCPOSTING, ITEMCODE1, ACCODE, ACDESC, INTTAX, SLCODE, TAXCODE, SLCODE1, SLDESC1, SCODE1 As String
        Dim AMT, TAXPERC As Double
        Dim SQLS As String
        SQLS = "SELECT ISNULL(INVACCPOSTING,'')AS INVACCPOSTING FROM ACCOUNTSSETUP WHERE ScrsDesc='SUNDRY CREDITORS'"
        gconnection.getDataSet(SQLS, "INV")
        If gdataset.Tables("INV").Rows.Count > 0 Then
            ACCPOSTING = gdataset.Tables("INV").Rows(0).Item("INVACCPOSTING")
        End If
        If ACCPOSTING = "Y" Then
            'For i = 1 To ssgrid.DataRowCnt
            '    ssgrid.Row = i
            '    ssgrid.Col = 1
            '    'ITEMCODE1 = ""
            '    ITEMCODE1 = ssgrid.Text
            '    sqlstring = ""
            '    '*************LDEGER SELECTION FOR ITEMCODE*******************
            '    SQLS = "SELECT LEDGER FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & ITEMCODE1 & "'"
            '    gconnection.getDataSet(SQLS, "CODE")
            '    If gdataset.Tables("CODE").Rows.Count > 0 Then
            '        ACCODE = gdataset.Tables("CODE").Rows(0).Item("LEDGER")
            '    Else
            '        MessageBox.Show("ACCOUNT CONFIGURATION NOT DONE FOR THIS ITEM:-'" & ITEMCODE1 & "'")
            '    End If
            '    '*************ACCOUNT CODE SELECTION FROM GLCODE**************
            '    SQLS = "SELECT accode, ACDESC FROM accountsglaccountmaster  WHERE ACCODE='" & ACCODE & "'"
            '    gconnection.getDataSet(SQLS, "GLCODE")
            '    If gdataset.Tables("GLCODE").Rows.Count > 0 Then
            '        ACCODE = ""
            '        ACCODE = gdataset.Tables("GLCODE").Rows(0).Item("ACCODE")
            '        ACDESC = ""
            '        ACDESC = gdataset.Tables("GLCODE").Rows(0).Item("ACDESC")
            '    End If
            '*************JOURNALENTRY INSERTION FOR CREDIT VALUE(WITHOUT TAX)***********
            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            sqlstring = sqlstring & " AccountcodeDesc, CreditDebit, Amount, VOID)"
            sqlstring = sqlstring & " VALUES('" & txt_Docno.Text & "', '" & Format(dtp_Docdate.Value, "dd/MMM/yyyy") & "', "
            sqlstring = sqlstring & "'STOCK-DAMAGE', 'STOCK-DAMAGE', 'E0901',"
            sqlstring = sqlstring & "'DIRECT EXPENSES ~ DRINKS', 'CREDIT','" & txt_Totalamt.Text & "','N')"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
            ''************CHECK FOR TAX***********************************
            'SQLS = "SELECT ISNULL(INPUTTAX,'') AS INPUTTAX FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & ITEMCODE1 & "'"
            'gconnection.getDataSet(SQLS, "TAX")
            'If gdataset.Tables("TAX").Rows.Count > 0 Then
            '    INTTAX = gdataset.Tables("TAX").Rows(0).Item("INPUTTAX")
            'End If
            'If INTTAX = "Y" Then
            '    '**********ACCOUNTCODE SELECTION FOR TAX***************************
            '    ssgrid.Col = 8
            '    ssgrid.Row = i
            '    TAXPERC = ssgrid.Text
            '    If TAXPERC = "5.00" Then
            '        SQLS = "SELECT ACCODE FROM accountsglaccountmaster WHERE  acDESC='VAT INPUT CR. RECEIBALE 4%'"
            '        gconnection.getDataSet(SQLS, "TAB1")
            '        If gdataset.Tables("TAB1").Rows.Count > 0 Then
            '            TAXCODE = gdataset.Tables("TAB1").Rows(0).Item("ACCODE")
            '        End If
            '    ElseIf TAXPERC = "14.50" Then
            '        SQLS = "SELECT ACCODE FROM accountsglaccountmaster WHERE  acDESC='VAT INPUT CR RECEIBALE 13.5%'"
            '        gconnection.getDataSet(SQLS, "TAB1")
            '        If gdataset.Tables("TAB1").Rows.Count > 0 Then
            '            TAXCODE = gdataset.Tables("TAB1").Rows(0).Item("ACCODE")
            '        End If
            '    End If
            '**********JOURNALENTRY POSTING FOR TAX(DEBIT VALUE)****************
            'sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, AccountCode, "
            'sqlstring = sqlstring & " AccountcodeDesc, CreditDebit, Amount, VOID, SLCODE)"
            'sqlstring = sqlstring & " VALUES('" & txt_Grnno.Text & "', '" & Format(dtp_Grndate.Value, "dd/MMM/yyyy") & "', "
            'sqlstring = sqlstring & "'ITEM-TAX', 'ITEM-TAX', '" & TAXCODE & "',"
            'sqlstring = sqlstring & "'" & ACDESC & "', 'DEBIT',"
            'AMT = 0.0
            'ssgrid.Row = i
            'ssgrid.Col = 9
            'AMT = ssgrid.Text
            'sqlstring = sqlstring & "'" & AMT & "','N',"
            'SLCODE = ""
            'ssgrid.Row = i
            'ssgrid.Col = 1
            'SLCODE = ssgrid.Text
            'sqlstring = sqlstring & "'" & SLCODE & "')"
            'ReDim Preserve INSERT(INSERT.Length)
            'INSERT(INSERT.Length - 1) = sqlstring
            ' End If
            '    '************GET SCRS CODE FROM ACCOUNTSSETUP***************
            '    SQLS = "SELECT ScrsCode FROM ACCOUNTSSETUP WHERE  SCRSDESC ='SUNDRY CREDITORS'"
            '    gconnection.getDataSet(SQLS, "SCODE")
            '    If gdataset.Tables("SCODE").Rows.Count > 0 Then
            '        SCODE1 = gdataset.Tables("SCODE").Rows(0).Item("SCRSCODE")
            '    Else
            '        MessageBox.Show("CREATE CODE FOR SUNDRY CREDITORS IN ACCOUNTSSETUP...")
            '    End If
            '    '************GET SCRS CODE FROM ACCOUNTSGLACCOUNTMASTER*********
            '    SQLS = "SELECT * FROM accountsglaccountmaster WHERE accode='" & SCODE1 & "'"
            '    gconnection.getDataSet(SQLS, "SCODE1")
            '    If gdataset.Tables("SCODE1").Rows.Count > 0 Then
            '        SCODE1 = ""
            '        SCODE1 = gdataset.Tables("SCODE1").Rows(0).Item("ACCODE")
            '        ACDESC = ""
            '        ACDESC = gdataset.Tables("SCODE1").Rows(0).Item("ACDESC")
            '    Else
            '        MessageBox.Show("CREATE ACCOUNT CODE FOR SUNDRY CREDITORS IN ACCOUNTSGLACCOUNTMASTER...")
            '        Exit Sub
            '    End If
            'Next i
            ''***********GET SUPPLIER CODE FROM ACCOUNTSSUBLEDGERMASTER*********************
            'SQLS = "select slcode, sldesc from accountssubledgermaster  WHERE accode='" & SCODE1 & "' AND "
            'SQLS = SQLS & "SLCODE='" & txt_Suppliercode.Text & "' AND SLNAME='" & txt_Suppliername.Text & "'"
            'gconnection.getDataSet(SQLS, "SLCODE1")
            'If gdataset.Tables("SLCODE1").Rows.Count > 0 Then
            '    SLCODE1 = gdataset.Tables("SLCODE1").Rows(0).Item("SLCODE")
            '    SLDESC1 = gdataset.Tables("SLCODE1").Rows(0).Item("SLDESC")
            'Else
            '    MessageBox.Show("CREATE SLCODE FOR SUPPLIER IN ACCOUNTSSUBLEDGERMASTER...")
            '    Exit Sub
            'End If
            '***********JOURNALENTRY POSTING FOR DEBIT VALUE(SUPPLIER CODE)*****************
            sqlstring = "INSERT INTO JOURNALENTRY(VoucherNo, VoucherDate, VoucherCategory, VoucherType, "
            sqlstring = sqlstring & " AccountCode, AccountcodeDesc, CreditDebit, Amount, VOID)"
            sqlstring = sqlstring & "VALUES('" & txt_Docno.Text & "','" & Format(dtp_Docdate.Value, "dd/MMM/yyyy") & "',"
            sqlstring = sqlstring & "'STOCK-DAMAGE','STOCK-DAMAGE','E0901A','WINE ~ DAMAGED OR ADJUSTMENT',"
            sqlstring = sqlstring & "'DEBIT','" & txt_Totalamt.Text & "','N')"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

        End If
        gconnection.MoreTrans(INSERT)

        '=========================MANISH
    End Sub


    Private Sub cmd_auth_Click(sender As Object, e As EventArgs)
        Authocheck("INVENTORY", "Stock Damage", gUsername, "STOCKDMGDETAIL", "dOCDETAILS", Me)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Try
            doctype1 = ""
            Call clearform(Me)
            Call FOOTER()
            grp_footer.Visible = False
            Call autogenerate() '''--> Fill DOC NO.
            Me.dtp_Docdate.Value = Format(Now, "dd/MMM/yyyy")
            Me.lbl_Freeze.Visible = False
            Me.grp_Stockissue.Top = 1000
            Me.lbl_Freeze.Text = "Record Void  On "
            Me.ssgrid.ClearRange(1, 1, -1, -1, True)
            Me.Button2.Text = "Void [F8]"
            Me.Button1.Text = "Add [F7]"
            Me.ssgrid.SetActiveCell(1, 1)
            Me.txt_Docno.Enabled = True
            Me.txt_Docno.ReadOnly = False
            Me.lbl_closingqty.Text = ""
            'Me.lbl_Heading.Text = "STOCK TRANSFER"
            Me.TXT_FROMSTORECODE.Text = ""
            Me.txt_FromStorename.Text = ""
            Me.txt_storecode.Text = ""
            Me.txt_storeDesc.Text = ""
            Me.button2.Enabled = True
            Me.Button1.Enabled = True
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            TXT_FROMSTORECODE.Focus()
            txt_Docno.Text = ""
            txt_clsqty.Text = ""
            LabelClosingQuantity.Text = ""
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim Totalamt, Totalqty, Avgrate, AvgQuantity As Double
            Dim Sqlstring, Insert(0), Doctype As String
            Dim i As Integer
            Dim currentuom As String
            Dim clqty, CLQTY1 As Integer
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            For i = 1 To ssgrid.DataRowCnt
                ssgrid.Row = i
                ssgrid.Col = 1
                Dim itemcode1 As String = ssgrid.Text
                ssgrid.Col = 3
                Dim uom1 As String = ssgrid.Text
                ssgrid.Col = 4
                Dim clqty12 As Double = Format(Val(ssgrid.Text), "0.00")
                ' Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & itemcode1 & "' ,'" & Trim(TXT_FROMSTORECODE.Text) & "','" & uom1 & "')"
                ' Dim cls As Double = gconnection.getvalue(SQL)
                Dim cls As Double = gconnection.closing(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"), itemcode1, Trim(TXT_FROMSTORECODE.Text), uom1)

                cls = cls - clqty12
                If (cls < 0) Then
                    MessageBox.Show("You Cannot INSERT this item,it Make Stock Negative")
                    Exit Sub
                End If
            Next


            '''*********************************************************** Calculate TotalQuantity And TotalAmount *******************'''
            Me.txt_Totalamt.Text = 0
            Me.txt_Totalqty.Text = 0
            For i = 1 To ssgrid.DataRowCnt
                ssgrid.Row = i
                ssgrid.Col = 4
                Totalqty = Val(ssgrid.Text)
                Me.txt_Totalqty.Text = Format(Val(Me.txt_Totalqty.Text) + Val(Totalqty), "0.000")
                ssgrid.Col = 6
                Totalamt = Val(ssgrid.Text)
                Me.txt_Totalamt.Text = Format(Val(Me.txt_Totalamt.Text) + Val(Totalamt), "0.00")
            Next i
            '''*********************************************************** Calculate TotalQuantity And TotalAmount *******************'''
            Sqlstring = "SELECT ISNULL(STORESTATUS,'') AS STORESTATUS FROM STOREMASTER WHERE ISNULL(STORECODE,'') = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND ISNULL(FREEZE,'') <> 'Y' ORDER BY STOREDESC ASC"
            gconnection.getDataSet(Sqlstring, "STOREMASTER1")
            If gdataset.Tables("StoreMaster1").Rows.Count > 0 Then
                Doctype = ""
                'If Trim(gdataset.Tables("StoreMaster1").Rows(0).Item("STORESTATUS")) = "M" Then
                '    Doctype = "RET"
                'Else
                Doctype = "DMG"
                'End If
            End If
            '''*****************************************************0****** CASE - 1 : ADD [F7] *******************************************'''
            '''******************************************************** $ INSERT INTO STOCKDMGHEADER **********************************'''
            If Button1.Text = "Add [F7]" Then
                docno = Split(Trim(txt_Docno.Text), "/")
                transferdocno = Trim(TXT_FROMSTORECODE.Text) & "/" & Trim(txt_storecode.Text) & "/" & docno(1) & "/" & financalyear
                Sqlstring = "INSERT INTO STOCKDMGHEADER(Docno,Docdetails,Docdate,Doctype,Transferno,storecode,storedesc,Fromstorecode,Fromstoredesc, "
                Sqlstring = Sqlstring & " Tostorecode, Tostoredesc,Challenno,Challendate, Totalamt,Remarks,Void,Adduser,Adddate,Updateuser,Updatetime,UPDFOOTER,UPDSIGN)"
                Sqlstring = Sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
                Sqlstring = Sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                Sqlstring = Sqlstring & " '" & Trim(Doctype) & "','" & Trim(transferdocno) & "',"
                Sqlstring = Sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
                Sqlstring = Sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                Sqlstring = Sqlstring & " '" & Trim(txt_storecode.Text) & "','" & Trim(txt_storeDesc.Text) & "',"
                Sqlstring = Sqlstring & " '" & Trim(txt_Challanno.Text) & "','" & Format(CDate(dtp_Challandate.Value), "dd/MMM/yyyy") & "',"
                Sqlstring = Sqlstring & " " & Format(Val(txt_Totalamt.Text), "0.00") & " ,"
                Sqlstring = Sqlstring & " '" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,"
                Sqlstring = Sqlstring & " 'N','" & Trim(gUsername) & "',getDate(),"
                Sqlstring = Sqlstring & " '',getDate(),"
                Sqlstring = Sqlstring & " '" & Trim(Txt_footer.Text) & "',' " & Trim(Txt_signature.Text) & "' )"
                Insert(0) = Sqlstring
                '''******************************************************** $ INSERT INTO STOCKDMGDETAILS **********************************'''
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 1
                    Avgrate = CalAverageRate(Trim(ssgrid.Text))
                    AvgQuantity = CalAverageQuantity(Trim(ssgrid.Text))
                    Sqlstring = "INSERT INTO STOCKDMGDETAIL(Docno,Docdetails,Docdate,Doctype,Transferno,storecode,storedesc,Fromstorecode,"
                    Sqlstring = Sqlstring & " Fromstoredesc,Tostorecode,Tostoredesc,Challenno,Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                    Sqlstring = Sqlstring & " Groupcode,Subgroupcode,Void,Adduser,Adddatetime,Updateuser,Updatetime)"
                    Sqlstring = Sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
                    Sqlstring = Sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                    Sqlstring = Sqlstring & " '" & Trim(Doctype) & "','" & Trim(transferdocno) & "',"
                    Sqlstring = Sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
                    Sqlstring = Sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                    Sqlstring = Sqlstring & " '" & Trim(txt_storecode.Text) & "','" & Trim(txt_storeDesc.Text) & "',"
                    Sqlstring = Sqlstring & " '" & Trim(txt_Challanno.Text) & "',"
                    ssgrid.Col = 1
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 2
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 3
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 4
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text), "0.000") & ","
                    ssgrid.Col = 5
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 6
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 7
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 8
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    Sqlstring = Sqlstring & " 'N',"
                    Sqlstring = Sqlstring & " '" & Trim(gUsername) & "',getDate(),"
                    Sqlstring = Sqlstring & " ' ',getDate())"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = Sqlstring

                    ' UPDATING CURRENT STOCK IN INVENTORYITEMMASTER -START  --***VENUJD

                    ssgrid.Col = 3
                    ssgrid.Row = i
                    currentuom = Trim(ssgrid.Text)
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    Sqlstring = "UPDATE INVENTORYITEMMASTER SET clstock = (ISNULL(clstock,0) - " & Format(Val(ssgrid.Text), "0.00") & " * B.CONVVALUE)  FROM INVENTORY_TRANSCONVERSION B "
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    Sqlstring = Sqlstring & "WHERE ITEMCODE = '" & Trim(ssgrid.Text) & "' AND STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND STOCKUOM = B.TRANSUOM AND  '" & Trim(currentuom) & "' = B.BASEUOM"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = Sqlstring
                    ' UPDATING CURRENT STOCK IN INVENTORYITEMMASTER -END  --***VENUJD

                    '''************************************************** UPDATE OPENING STOCK ********************'''
                    ''''*********************************** UPDATE OPENING STOCK COMPLETE ********************'''
                Next i
                gconnection.MoreTrans(Insert)
                Sqlstring = "update inventoryitemmaster set CLVALUE=(isnull(clstock,0) * ISNULL(PURCHASERATE,0))"
                gconnection.dataOperation1(6, Sqlstring, "inventoryitemmaster")

                Call ACCPOST()
                Me.Button1_Click(sender, e)
                Button1.Text = "Add [F7]"
                '''****************************************** UPDATE Complete *********************************************
                If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
                    Call Cmd_View_Click(Button3, e)
                    Call Button1_Click(sender, e)
                Else
                    Call Button1_Click(sender, e)
                End If
                '''*********************************************************** Case-2 : Update [F7] *******************************************'''
            Else
                ''''****************************************CHECK FOR CLSSTOCK OF CORRESPONDING SUBSTORE ******************************************************'''
                Dim CURQTY, PREVQTY, CLSQTY, VDIFF As Double
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 1
                    Dim itemcode1 As String = ssgrid.Text
                    ssgrid.Col = 3
                    Dim uom1 As String = ssgrid.Text
                    ssgrid.Col = 4
                    Dim clqty12 As Double = Format(Val(ssgrid.Text), "0.00")
                    ' Dim SQL As String = "SELECT ISNULL(SUM(QTY*MF),0) FROM CLOSINGVLAUE('" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "','" & itemcode1 & "' ,'" & Trim(TXT_FROMSTORECODE.Text) & "','" & uom1 & "')"
                    ' Dim cls As Double = gconnection.getvalue(SQL)
                    Dim cls As Double = gconnection.closing(Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy"), itemcode1, Trim(TXT_FROMSTORECODE.Text), uom1)

                    cls = cls - clqty12
                    If (cls < 0) Then
                        MessageBox.Show("You Cannot INSERT this GRN,Updation Make Stock Negative")
                        Exit Sub
                    End If
                Next

                '''********************************************************** UPDATE stockissueheader *********************************************************'''
                Sqlstring = "UPDATE STOCKDMGHEADER SET Docdate='" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "', "
                Sqlstring = Sqlstring & " Doctype='" & Trim(Doctype) & "',"
                Sqlstring = Sqlstring & " Storecode='" & Trim(TXT_FROMSTORECODE.Text) & "',"
                Sqlstring = Sqlstring & " Storedesc='" & Trim(txt_FromStorename.Text) & "', "
                Sqlstring = Sqlstring & " Fromstorecode='" & Trim(TXT_FROMSTORECODE.Text) & "',"
                Sqlstring = Sqlstring & " Fromstoredesc='" & Trim(txt_FromStorename.Text) & "',"
                Sqlstring = Sqlstring & " Tostorecode='" & Trim(txt_storecode.Text) & "',"
                Sqlstring = Sqlstring & " Tostoredesc='" & Trim(txt_storeDesc.Text) & "', "
                Sqlstring = Sqlstring & " Challenno='" & Trim(txt_Challanno.Text) & "',"
                Sqlstring = Sqlstring & " Challendate='" & Format(CDate(dtp_Challandate.Value), "dd/MMM/yyyy") & "', "
                Sqlstring = Sqlstring & " Totalamt=" & Format(Val(txt_Totalamt.Text), "0.00") & ","
                Sqlstring = Sqlstring & " UPDFOOTER = ' " & Trim(Txt_footer.Text) & " ' ,"
                Sqlstring = Sqlstring & " UPDSIGN = ' " & Trim(Txt_signature.Text) & " ' ,"
                Sqlstring = Sqlstring & " Remarks='" & Replace(Trim(CStr(txt_Remarks.Text)), "'", "?") & "' ,"
                Sqlstring = Sqlstring & " Void='N',Updateuser='" & Trim(gUsername) & "',"
                Sqlstring = Sqlstring & " Updatetime=getDate()"
                Sqlstring = Sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
                Insert(0) = Sqlstring
                '''********************************************************* DELETE FROM stockissuedetail *****************************************************'''
                Sqlstring = "DELETE FROM STOCKDMGDETAIL WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = Sqlstring
                '''******************************************************** INSERT INTO stockissuedetail ******************************************************'''
                docno = Split(Trim(txt_Docno.Text), "/")
                For i = 1 To ssgrid.DataRowCnt
                    ssgrid.Row = i
                    ssgrid.Col = 1
                    Avgrate = CalAverageRate(Trim(ssgrid.Text))
                    AvgQuantity = CalAverageQuantity(Trim(ssgrid.Text))
                    Sqlstring = "INSERT INTO STOCKDMGDETAIL(Docno,Docdetails,Docdate,Doctype,Transferno,storecode,storedesc,Fromstorecode,"
                    Sqlstring = Sqlstring & " Fromstoredesc,Tostorecode,Tostoredesc,Challenno,Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                    Sqlstring = Sqlstring & " Groupcode,Subgroupcode,Void,Adduser,Adddatetime,Updateuser,Updatetime)"
                    Sqlstring = Sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
                    Sqlstring = Sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                    Sqlstring = Sqlstring & " '" & Trim(Doctype) & "','" & Trim(transferdocno) & "',"
                    Sqlstring = Sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
                    Sqlstring = Sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                    Sqlstring = Sqlstring & " '" & Trim(txt_storecode.Text) & "','" & Trim(txt_storeDesc.Text) & "',"
                    Sqlstring = Sqlstring & " '" & Trim(txt_Challanno.Text) & "',"
                    ssgrid.Col = 1
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 2
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 3
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 4
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text), "0.000") & ","
                    ssgrid.Col = 5
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 6
                    Sqlstring = Sqlstring & " " & Format(Val(ssgrid.Text), "0.00") & ","
                    ssgrid.Col = 7
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    ssgrid.Col = 8
                    Sqlstring = Sqlstring & " '" & Trim(ssgrid.Text) & "',"
                    Sqlstring = Sqlstring & " 'N',"
                    Sqlstring = Sqlstring & " '" & Trim(gUsername) & "',getDate(),"
                    Sqlstring = Sqlstring & " ' ',getDate())"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = Sqlstring

                    ' UPDATING CURRENT STOCK IN INVENTORYITEMMASTER -START  --***VENUJD
                    clqty = 0
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    Sqlstring = "select (QTY * b.convvalue) as QTY from STOCKDMGDETAIL,INVENTORY_TRANSCONVERSION B,INVENTORYITEMMASTER i WHERE DOCDETAILS ='" & txt_Docno.Text & "' AND i.ITEMCODE ='" & Trim(ssgrid.Text) & "' AND i.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND i.STOCKUOM = B.TRANSUOM AND  uom = B.BASEUOM"
                    gconnection.getDataSet(Sqlstring, "STOCKDMGDETAIL")
                    If gdataset.Tables("STOCKDMGDETAIL").Rows.Count > 0 Then
                        clqty = gdataset.Tables("STOCKDMGDETAIL").Rows(0).Item("QTY")
                    End If

                    ssgrid.Col = 3
                    ssgrid.Row = i
                    currentuom = Trim(ssgrid.Text)
                    ssgrid.Col = 4
                    ssgrid.Row = i
                    Sqlstring = "UPDATE INVENTORYITEMMASTER SET clstock = (ISNULL(clstock,0) + " & Format(Val(clqty), "0.00") & ") - (" & Format(Val(ssgrid.Text), "0.00") & " * B.CONVVALUE)  FROM INVENTORY_TRANSCONVERSION B "
                    ssgrid.Col = 1
                    ssgrid.Row = i
                    Sqlstring = Sqlstring & "WHERE ITEMCODE = '" & Trim(ssgrid.Text) & "' AND STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND STOCKUOM = B.TRANSUOM AND  '" & Trim(currentuom) & "' = B.BASEUOM"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = Sqlstring
                    ' UPDATING CURRENT STOCK IN INVENTORYITEMMASTER -END  --***VENUJD

                    '''************************************************** UPDATE OPENING STOCK ********************'''
                    '''*********************************** UPDATE OPENING STOCK COMPLETE ********************'''
                Next i
                gconnection.MoreTrans(Insert)
                Sqlstring = "update inventoryitemmaster set CLVALUE=(isnull(clstock,0) * ISNULL(PURCHASERATE,0))"
                gconnection.dataOperation1(6, Sqlstring, "inventoryitemmaster")

                ' For i = 1 To ssgrid.DataRowCnt
                'ssgrid.Row = i
                'ssgrid.Col = 1
                'Dim pitemcode As String = ssgrid.Text
                '  Dim sql123 = " select rateflag from INVENTORYCATEGORYMASTER where CATEGORYCODE=(select distinct category from inventoryitemmaster where itemcode='" & pitemcode & "' )"

                'CALWAR(Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy"), Format(dtp_Docdate.Value, "dd/MMM/yyyy"), pitemcode, txt_storecode.Text)

                '                Next

                '*********DELETE FROM JOURNALENTRY
                '  Sqlstring = "DELETE FROM JOURNALENTRY WHERE VOUCHERNO='" & txt_Docno.Text & "'"
                'ReDim Preserve Insert(Insert.Length)
                'Insert(Insert.Length - 1) = Sqlstring
                Call ACCPOST()
                ' Call Cmd_Clear_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim i As Integer
            Dim insert(0) As String
            Dim clqty, clqty1 As Integer
            Dim currentuom As String
            If Mid(Me.Button2.Text, 1, 1) = "V" Then

                If MsgBox("Are you Sure to Freeze the Record..", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                    Exit Sub
                End If
                '''***************************************** Void the DOCNO in stockissueheader **************************'''
                sqlstring = "UPDATE  STOCKDMGHEADER "
                sqlstring = sqlstring & " SET Void= 'Y',"
                sqlstring = sqlstring & " Updateuser='" & Trim(gUsername) & " ',"
                sqlstring = sqlstring & " Updatetime =getDate()"
                sqlstring = sqlstring & " WHERE Docdetails = '" & Trim(txt_Docno.Text) & "'"
                insert(0) = sqlstring
                '''***************************************** Void the DOCNO in Complete **********************************'''
                '''***************************************** Void the DOCNO in stockissuedetails **************************'''
                For i = 1 To ssgrid.DataRowCnt
                    With ssgrid
                        sqlstring = "UPDATE  STOCKDMGDETAIL "
                        sqlstring = sqlstring & " SET Void= 'Y',"
                        sqlstring = sqlstring & " Updateuser='" & Trim(gUsername) & " ',"
                        sqlstring = sqlstring & " Updatetime =getDate()"
                        sqlstring = sqlstring & " WHERE Docdetails = '" & Trim(txt_Docno.Text) & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring

                        ' UPDATING CURRENT STOCK IN INVENTORYITEMMASTER -START  --***VENUJD
                        clqty = 0
                        ssgrid.Col = 1
                        ssgrid.Row = i
                        sqlstring = "select (QTY * b.convvalue) as QTY from STOCKDMGDETAIL,INVENTORY_TRANSCONVERSION B,INVENTORYITEMMASTER i WHERE DOCDETAILS ='" & txt_Docno.Text & "' AND i.ITEMCODE ='" & Trim(ssgrid.Text) & "' AND i.STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' AND i.STOCKUOM = B.TRANSUOM AND  uom = B.BASEUOM"
                        gconnection.getDataSet(sqlstring, "STOCKDMGDETAIL")
                        If gdataset.Tables("STOCKDMGDETAIL").Rows.Count > 0 Then
                            clqty = gdataset.Tables("STOCKDMGDETAIL").Rows(0).Item("QTY")
                        End If

                        ssgrid.Col = 3
                        ssgrid.Row = i
                        currentuom = Trim(ssgrid.Text)
                        ssgrid.Col = 4
                        ssgrid.Row = i
                        sqlstring = "UPDATE INVENTORYITEMMASTER SET clstock = (ISNULL(clstock,0) + " & Format(Val(clqty), "0.00") & ")  "
                        ssgrid.Col = 1
                        ssgrid.Row = i
                        sqlstring = sqlstring & "WHERE ITEMCODE = '" & Trim(ssgrid.Text) & "' AND STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "' "
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = sqlstring

                        ' UPDATING CURRENT STOCK IN INVENTORYITEMMASTER -END  --***VENUJD

                    End With
                Next i
                ''''***************************************** Void the DOCNO is Complete **********************************'''
                '        '''*********************************** UPDATE OPENING STOCK COMPLETE ********************'''

                gconnection.MoreTrans(insert)
                Me.Button1_Click(sender, e)
                Button1.Text = "Add [F7]"
                '''****************************************** UPDATE Complete *********************************************
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Rpt_StkDMGBill
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(FROMSTORECODE,'') AS FROMSTORECODE,"
            sqlstring = sqlstring & " ISNULL(FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(TOSTORECODE,'') AS TOSTORECODE,ISNULL(TOSTOREDESC,'') AS TOSTOREDESC,"
            sqlstring = sqlstring & " ISNULL(CHALLENNO,'') AS CHALLENNO,CHALLENDATE AS CHALLENDATE,ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(REMARKS,'') AS REMARKS,ISNULL(UPDFOOTER,'') AS UPDFOOTER ,ISNULL(UPDSIGN,'') AS UPDSIGN,ISNULL(ADDDATE,'') AS ADDDATE "
            sqlstring = sqlstring & " FROM VW_INV_STKDMGBILL"
            sqlstring = sqlstring & " WHERE DOCDETAILS ='" & Trim(txt_Docno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"

            gconnection.getDataSet(sqlstring, "VW_INV_STKDMGBILL")
            If gdataset.Tables("VW_INV_STKDMGBILL").Rows.Count > 0 Then
                If chk_excel.Checked = True Then
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "STOCK DAMAGE ", "")
                Else
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "VW_INV_STKDMGBILL"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text13")
                    textobj1.Text = MyCompanyName
                    Dim textobj2 As TextObject
                    textobj2 = r.ReportDefinition.ReportObjects("Text30")
                    textobj2.Text = gUsername
                    If MyCompanyName = "THE BENGAL CLUB" Then
                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text27")
                        textobj3.Text = ""
                    End If
                    rViewer.Show()
                End If
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If
            '''Else
            '''gPrint = False
            '''Dim i As Integer
            '''Dim objStockIssueClass As New rptStockTransferreport
            '''Dim sqlstring = "SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE,ISNULL(H.FROMSTORECODE,'') AS FROMSTORECODE,"
            '''sqlstring = sqlstring & " ISNULL(H.FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(H.TOSTORECODE,'') AS TOSTORECODE,ISNULL(H.TOSTOREDESC,'') AS TOSTOREDESC,"
            '''sqlstring = sqlstring & " ISNULL(H.CHALLENNO,'') AS CHALLENNO,H.CHALLENDATE AS CHALLENDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
            '''sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(D.QTY,0) AS QTY,ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT,ISNULL(REMARKS,'') AS REMARKS,ISNULL(H.UPDFOOTER,'') AS UPDFOOTER ,ISNULL(H.UPDSIGN,'') AS UPDSIGN "
            '''sqlstring = sqlstring & " FROM STOCKTRANSFERHEADER AS H INNER JOIN STOCKTRANSFERDETAIL AS D ON H.DOCDETAILS = D.DOCDETAILS"
            '''sqlstring = sqlstring & " WHERE H.DOCDETAILS ='" & Trim(txt_Docno.Text) & "'"
            '''sqlstring = sqlstring & " ORDER BY H.DOCDETAILS,H.DOCDATE"
            '''Dim arraystring() As String = {"ITEM CODE", "ITEM NAME", "UOM", "QUANTITY", "RATE", "AMOUNT"}
            '''Dim heading() As String = {"STOCK ISSUE"}
            '''Dim colsize() As Integer = {15, 40, 16, 10, 10, 12}
            '''objStockIssueClass.Reportdetails(sqlstring, heading, arraystring, colsize)
            '''End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '''Try
        '''    gPrint = True
        '''    Dim i As Integer
        '''    Dim objStockIssueClass As New rptStockTransferreport
        '''    Dim sqlstring = "SELECT ISNULL(H.DOCDETAILS,'') AS DOCDETAILS,H.DOCDATE,ISNULL(H.FROMSTORECODE,'') AS FROMSTORECODE,"
        '''    sqlstring = sqlstring & " ISNULL(H.FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(H.TOSTORECODE,'') AS TOSTORECODE,ISNULL(H.TOSTOREDESC,'') AS TOSTOREDESC,"
        '''    sqlstring = sqlstring & " ISNULL(H.CHALLENNO,'') AS CHALLENNO,H.CHALLENDATE AS CHALLENDATE,ISNULL(D.ITEMCODE,'') AS ITEMCODE,ISNULL(D.ITEMNAME,'') AS ITEMNAME,"
        '''    sqlstring = sqlstring & " ISNULL(D.UOM,'') AS UOM,ISNULL(D.QTY,0) AS QTY,ISNULL(D.RATE,0) AS RATE,ISNULL(D.AMOUNT,0) AS AMOUNT, ISNULL(REMARKS,'') AS REMARKS,ISNULL(H.UPDFOOTER,'') AS UPDFOOTER ,ISNULL(H.UPDSIGN,'') AS UPDSIGN "
        '''    sqlstring = sqlstring & " FROM STOCKTRANSFERHEADER AS H INNER JOIN STOCKTRANSFERDETAIL AS D ON H.DOCDETAILS = D.DOCDETAILS"
        '''    sqlstring = sqlstring & " WHERE H.DOCDETAILS ='" & Trim(txt_Docno.Text) & "'"
        '''    sqlstring = sqlstring & " ORDER BY H.DOCDETAILS,H.DOCDATE"
        '''    Dim arraystring() As String = {"ITEM CODE", "ITEM NAME", "UOM", "QUANTITY", "RATE", "AMOUNT"}
        '''    Dim heading() As String = {"STOCK ISSUE"}
        '''    Dim colsize() As Integer = {15, 40, 16, 10, 10, 12}
        '''    objStockIssueClass.Reportdetails(sqlstring, heading, arraystring, colsize)
        '''Catch ex As Exception
        '''    MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '''    Exit Sub
        '''End Try
        Try

            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Group Master") = MsgBoxResult.Yes Then
            Dim rViewer As New Viewer
            Dim sqlstring, SSQL, FROMSTORE As String
            Dim r As New Rpt_StkDMGBill
            sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS,DOCDATE,ISNULL(FROMSTORECODE,'') AS FROMSTORECODE,"
            sqlstring = sqlstring & " ISNULL(FROMSTOREDESC,'') AS FROMSTOREDESC,ISNULL(TOSTORECODE,'') AS TOSTORECODE,ISNULL(TOSTOREDESC,'') AS TOSTOREDESC,"
            sqlstring = sqlstring & " ISNULL(CHALLENNO,'') AS CHALLENNO,CHALLENDATE AS CHALLENDATE,ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,"
            sqlstring = sqlstring & " ISNULL(UOM,'') AS UOM,ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(REMARKS,'') AS REMARKS,ISNULL(UPDFOOTER,'') AS UPDFOOTER ,ISNULL(UPDSIGN,'') AS UPDSIGN,ISNULL(ADDDATE,'') AS ADDDATE "
            sqlstring = sqlstring & " FROM VW_INV_STKDMGBILL"
            sqlstring = sqlstring & " WHERE DOCDETAILS ='" & Trim(txt_Docno.Text) & "'"
            sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE"

            gconnection.getDataSet(sqlstring, "VW_INV_STKDMGBILL")
            If gdataset.Tables("VW_INV_STKDMGBILL").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "VW_INV_STKDMGBILL"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text30")
                textobj2.Text = gUsername

                rViewer.Show()
            Else
                MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub

    Private Sub btn_auth_Click(sender As Object, e As EventArgs) Handles btn_auth.Click

    End Sub
End Class
