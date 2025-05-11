Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmProductConversion_All
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents grp_Stocktransfer2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_Docno As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmd_Docnohelp As System.Windows.Forms.Button
    Friend WithEvents txt_Docno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Docdate As System.Windows.Forms.Label
    Friend WithEvents dtp_Docdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grp_Stocktransfer1 As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_FROMSTORECODE As System.Windows.Forms.TextBox
    Friend WithEvents txt_FromStorename As System.Windows.Forms.TextBox
    Friend WithEvents cmd_fromStorecodeHelp As System.Windows.Forms.Button
    Friend WithEvents lbl_Fromstore As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_CATEGORY As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_ItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_ItemCode As System.Windows.Forms.Button
    Friend WithEvents txt_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ItemCode As System.Windows.Forms.Label
    Friend WithEvents lbl_ItemName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tXT_sTOCKuom As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Clstock As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_NQty As System.Windows.Forms.Label
    Friend WithEvents txt_NStockUOM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_Ncategory As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_NItemcode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_NItemcode As System.Windows.Forms.Button
    Friend WithEvents Txt_NItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Rate As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtConVQty As System.Windows.Forms.TextBox
    Friend WithEvents lbl_AdjQty As System.Windows.Forms.Label
    Friend WithEvents TxtNConVQty As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SSGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LBL_AMOUNT As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_totconqty As System.Windows.Forms.TextBox
    Friend WithEvents txt_totconvalue As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_wastagesqty As System.Windows.Forms.TextBox
    Friend WithEvents txt_wastagevalue As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProductConversion_All))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.grp_Stocktransfer2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lbl_Docno = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmd_Docnohelp = New System.Windows.Forms.Button()
        Me.txt_Docno = New System.Windows.Forms.TextBox()
        Me.lbl_Docdate = New System.Windows.Forms.Label()
        Me.dtp_Docdate = New System.Windows.Forms.DateTimePicker()
        Me.grp_Stocktransfer1 = New System.Windows.Forms.GroupBox()
        Me.TXT_FROMSTORECODE = New System.Windows.Forms.TextBox()
        Me.txt_FromStorename = New System.Windows.Forms.TextBox()
        Me.cmd_fromStorecodeHelp = New System.Windows.Forms.Button()
        Me.lbl_Fromstore = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LBL_AMOUNT = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtConVQty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_Rate = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbl_Clstock = New System.Windows.Forms.Label()
        Me.tXT_sTOCKuom = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_CATEGORY = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_ItemCode = New System.Windows.Forms.TextBox()
        Me.Cmd_ItemCode = New System.Windows.Forms.Button()
        Me.txt_ItemName = New System.Windows.Forms.TextBox()
        Me.lbl_ItemCode = New System.Windows.Forms.Label()
        Me.lbl_ItemName = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SSGRID = New AxFPSpreadADO.AxfpSpread()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtNConVQty = New System.Windows.Forms.TextBox()
        Me.lbl_AdjQty = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_NQty = New System.Windows.Forms.Label()
        Me.txt_NStockUOM = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_Ncategory = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Txt_NItemcode = New System.Windows.Forms.TextBox()
        Me.Cmd_NItemcode = New System.Windows.Forms.Button()
        Me.Txt_NItemName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_totconqty = New System.Windows.Forms.TextBox()
        Me.txt_totconvalue = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_wastagesqty = New System.Windows.Forms.TextBox()
        Me.txt_wastagevalue = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.grp_Stocktransfer2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_Stocktransfer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(603, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(224, 16)
        Me.Label5.TabIndex = 429
        Me.Label5.Text = "Press ENTER key to navigate"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(601, 16)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(171, 22)
        Me.lbl_Freeze.TabIndex = 427
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(404, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(223, 18)
        Me.Label16.TabIndex = 423
        Me.Label16.Text = "PRODUCT CONVERSION"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.chk_excel)
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Location = New System.Drawing.Point(857, 125)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(139, 372)
        Me.GroupBox2.TabIndex = 200
        Me.GroupBox2.TabStop = False
        '
        'chk_excel
        '
        Me.chk_excel.BackColor = System.Drawing.Color.Transparent
        Me.chk_excel.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.chk_excel.Location = New System.Drawing.Point(8, 269)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(72, 24)
        Me.chk_excel.TabIndex = 466
        Me.chk_excel.Text = "Excel"
        Me.chk_excel.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = Global.Inventory.My.Resources.Resources.Clear
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(8, 14)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(126, 56)
        Me.Cmd_Clear.TabIndex = 17
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Image = Global.Inventory.My.Resources.Resources.Delete
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(8, 145)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(126, 56)
        Me.Cmd_Freeze.TabIndex = 19
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = Global.Inventory.My.Resources.Resources.save
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(8, 78)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(126, 56)
        Me.Cmd_Add.TabIndex = 18
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = Global.Inventory.My.Resources.Resources._Exit
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(7, 296)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(126, 56)
        Me.Cmd_Exit.TabIndex = 21
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = Global.Inventory.My.Resources.Resources.view
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(8, 207)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(126, 56)
        Me.Cmd_View.TabIndex = 20
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'grp_Stocktransfer2
        '
        Me.grp_Stocktransfer2.BackColor = System.Drawing.Color.Transparent
        Me.grp_Stocktransfer2.Controls.Add(Me.PictureBox2)
        Me.grp_Stocktransfer2.Controls.Add(Me.lbl_Docno)
        Me.grp_Stocktransfer2.Controls.Add(Me.Label1)
        Me.grp_Stocktransfer2.Controls.Add(Me.cmd_Docnohelp)
        Me.grp_Stocktransfer2.Controls.Add(Me.txt_Docno)
        Me.grp_Stocktransfer2.Controls.Add(Me.lbl_Docdate)
        Me.grp_Stocktransfer2.Controls.Add(Me.dtp_Docdate)
        Me.grp_Stocktransfer2.Location = New System.Drawing.Point(570, 104)
        Me.grp_Stocktransfer2.Name = "grp_Stocktransfer2"
        Me.grp_Stocktransfer2.Size = New System.Drawing.Size(281, 91)
        Me.grp_Stocktransfer2.TabIndex = 50
        Me.grp_Stocktransfer2.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(96, 54)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 46
        Me.PictureBox2.TabStop = False
        '
        'lbl_Docno
        '
        Me.lbl_Docno.AutoSize = True
        Me.lbl_Docno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Docno.Location = New System.Drawing.Point(6, 27)
        Me.lbl_Docno.Name = "lbl_Docno"
        Me.lbl_Docno.Size = New System.Drawing.Size(66, 16)
        Me.lbl_Docno.TabIndex = 22
        Me.lbl_Docno.Text = "DOC NO :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(244, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 24)
        Me.Label1.TabIndex = 472
        Me.Label1.Text = "F4"
        Me.Label1.Visible = False
        '
        'cmd_Docnohelp
        '
        Me.cmd_Docnohelp.Location = New System.Drawing.Point(220, 22)
        Me.cmd_Docnohelp.Name = "cmd_Docnohelp"
        Me.cmd_Docnohelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_Docnohelp.TabIndex = 6
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
        Me.txt_Docno.TabIndex = 5
        '
        'lbl_Docdate
        '
        Me.lbl_Docdate.AutoSize = True
        Me.lbl_Docdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Docdate.Location = New System.Drawing.Point(6, 66)
        Me.lbl_Docdate.Name = "lbl_Docdate"
        Me.lbl_Docdate.Size = New System.Drawing.Size(83, 16)
        Me.lbl_Docdate.TabIndex = 24
        Me.lbl_Docdate.Text = "DOC DATE :"
        '
        'dtp_Docdate
        '
        Me.dtp_Docdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Docdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Docdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Docdate.Location = New System.Drawing.Point(132, 60)
        Me.dtp_Docdate.Name = "dtp_Docdate"
        Me.dtp_Docdate.Size = New System.Drawing.Size(96, 26)
        Me.dtp_Docdate.TabIndex = 7
        '
        'grp_Stocktransfer1
        '
        Me.grp_Stocktransfer1.BackColor = System.Drawing.Color.Transparent
        Me.grp_Stocktransfer1.Controls.Add(Me.TXT_FROMSTORECODE)
        Me.grp_Stocktransfer1.Controls.Add(Me.txt_FromStorename)
        Me.grp_Stocktransfer1.Controls.Add(Me.cmd_fromStorecodeHelp)
        Me.grp_Stocktransfer1.Controls.Add(Me.lbl_Fromstore)
        Me.grp_Stocktransfer1.Location = New System.Drawing.Point(177, 105)
        Me.grp_Stocktransfer1.Name = "grp_Stocktransfer1"
        Me.grp_Stocktransfer1.Size = New System.Drawing.Size(391, 90)
        Me.grp_Stocktransfer1.TabIndex = 1
        Me.grp_Stocktransfer1.TabStop = False
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
        Me.TXT_FROMSTORECODE.TabIndex = 2
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
        Me.txt_FromStorename.TabIndex = 4
        '
        'cmd_fromStorecodeHelp
        '
        Me.cmd_fromStorecodeHelp.Location = New System.Drawing.Point(168, 23)
        Me.cmd_fromStorecodeHelp.Name = "cmd_fromStorecodeHelp"
        Me.cmd_fromStorecodeHelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_fromStorecodeHelp.TabIndex = 3
        '
        'lbl_Fromstore
        '
        Me.lbl_Fromstore.AutoSize = True
        Me.lbl_Fromstore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Fromstore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Fromstore.Location = New System.Drawing.Point(4, 27)
        Me.lbl_Fromstore.Name = "lbl_Fromstore"
        Me.lbl_Fromstore.Size = New System.Drawing.Size(103, 16)
        Me.lbl_Fromstore.TabIndex = 16
        Me.lbl_Fromstore.Text = "FROM STORE :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LBL_AMOUNT)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TxtConVQty)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lbl_Rate)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lbl_Clstock)
        Me.GroupBox1.Controls.Add(Me.tXT_sTOCKuom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TXT_CATEGORY)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txt_ItemCode)
        Me.GroupBox1.Controls.Add(Me.Cmd_ItemCode)
        Me.GroupBox1.Controls.Add(Me.txt_ItemName)
        Me.GroupBox1.Controls.Add(Me.lbl_ItemCode)
        Me.GroupBox1.Controls.Add(Me.lbl_ItemName)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(177, 196)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(621, 165)
        Me.GroupBox1.TabIndex = 100
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "EXISTING PRODUCT"
        '
        'LBL_AMOUNT
        '
        Me.LBL_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.LBL_AMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_AMOUNT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_AMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.LBL_AMOUNT.Location = New System.Drawing.Point(427, 125)
        Me.LBL_AMOUNT.Name = "LBL_AMOUNT"
        Me.LBL_AMOUNT.Size = New System.Drawing.Size(181, 27)
        Me.LBL_AMOUNT.TabIndex = 440
        Me.LBL_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(325, 131)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 14)
        Me.Label14.TabIndex = 439
        Me.Label14.Text = "AMOUNT:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(9, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 14)
        Me.Label13.TabIndex = 438
        Me.Label13.Text = "RATE:"
        '
        'TxtConVQty
        '
        Me.TxtConVQty.BackColor = System.Drawing.Color.Wheat
        Me.TxtConVQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConVQty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConVQty.Location = New System.Drawing.Point(427, 93)
        Me.TxtConVQty.MaxLength = 15
        Me.TxtConVQty.Name = "TxtConVQty"
        Me.TxtConVQty.Size = New System.Drawing.Size(128, 20)
        Me.TxtConVQty.TabIndex = 12
        Me.TxtConVQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(272, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 14)
        Me.Label6.TabIndex = 437
        Me.Label6.Text = "CONVERSION QTY. :"
        '
        'lbl_Rate
        '
        Me.lbl_Rate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_Rate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Rate.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Rate.Location = New System.Drawing.Point(124, 125)
        Me.lbl_Rate.Name = "lbl_Rate"
        Me.lbl_Rate.Size = New System.Drawing.Size(181, 27)
        Me.lbl_Rate.TabIndex = 436
        Me.lbl_Rate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 14)
        Me.Label11.TabIndex = 435
        Me.Label11.Text = "STOCK IN HAND:"
        '
        'lbl_Clstock
        '
        Me.lbl_Clstock.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Clstock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_Clstock.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Clstock.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Clstock.Location = New System.Drawing.Point(124, 88)
        Me.lbl_Clstock.Name = "lbl_Clstock"
        Me.lbl_Clstock.Size = New System.Drawing.Size(130, 26)
        Me.lbl_Clstock.TabIndex = 434
        Me.lbl_Clstock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tXT_sTOCKuom
        '
        Me.tXT_sTOCKuom.BackColor = System.Drawing.Color.Wheat
        Me.tXT_sTOCKuom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tXT_sTOCKuom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tXT_sTOCKuom.Location = New System.Drawing.Point(124, 59)
        Me.tXT_sTOCKuom.MaxLength = 50
        Me.tXT_sTOCKuom.Name = "tXT_sTOCKuom"
        Me.tXT_sTOCKuom.ReadOnly = True
        Me.tXT_sTOCKuom.Size = New System.Drawing.Size(130, 20)
        Me.tXT_sTOCKuom.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 14)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "STOCK UOM :"
        '
        'TXT_CATEGORY
        '
        Me.TXT_CATEGORY.BackColor = System.Drawing.Color.Wheat
        Me.TXT_CATEGORY.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_CATEGORY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CATEGORY.Location = New System.Drawing.Point(427, 55)
        Me.TXT_CATEGORY.MaxLength = 15
        Me.TXT_CATEGORY.Name = "TXT_CATEGORY"
        Me.TXT_CATEGORY.ReadOnly = True
        Me.TXT_CATEGORY.Size = New System.Drawing.Size(128, 20)
        Me.TXT_CATEGORY.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(314, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 14)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "CATEGORY :"
        '
        'txt_ItemCode
        '
        Me.txt_ItemCode.BackColor = System.Drawing.Color.Wheat
        Me.txt_ItemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_ItemCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ItemCode.Location = New System.Drawing.Point(124, 24)
        Me.txt_ItemCode.MaxLength = 15
        Me.txt_ItemCode.Name = "txt_ItemCode"
        Me.txt_ItemCode.Size = New System.Drawing.Size(104, 20)
        Me.txt_ItemCode.TabIndex = 7
        '
        'Cmd_ItemCode
        '
        Me.Cmd_ItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_ItemCode.Location = New System.Drawing.Point(228, 23)
        Me.Cmd_ItemCode.Name = "Cmd_ItemCode"
        Me.Cmd_ItemCode.Size = New System.Drawing.Size(24, 26)
        Me.Cmd_ItemCode.TabIndex = 8
        '
        'txt_ItemName
        '
        Me.txt_ItemName.BackColor = System.Drawing.Color.Wheat
        Me.txt_ItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_ItemName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ItemName.Location = New System.Drawing.Point(427, 24)
        Me.txt_ItemName.MaxLength = 50
        Me.txt_ItemName.Name = "txt_ItemName"
        Me.txt_ItemName.ReadOnly = True
        Me.txt_ItemName.Size = New System.Drawing.Size(182, 20)
        Me.txt_ItemName.TabIndex = 9
        '
        'lbl_ItemCode
        '
        Me.lbl_ItemCode.AutoSize = True
        Me.lbl_ItemCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ItemCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ItemCode.Location = New System.Drawing.Point(9, 28)
        Me.lbl_ItemCode.Name = "lbl_ItemCode"
        Me.lbl_ItemCode.Size = New System.Drawing.Size(71, 14)
        Me.lbl_ItemCode.TabIndex = 27
        Me.lbl_ItemCode.Text = "ITEM CODE :"
        '
        'lbl_ItemName
        '
        Me.lbl_ItemName.AutoSize = True
        Me.lbl_ItemName.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ItemName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ItemName.Location = New System.Drawing.Point(312, 28)
        Me.lbl_ItemName.Name = "lbl_ItemName"
        Me.lbl_ItemName.Size = New System.Drawing.Size(73, 14)
        Me.lbl_ItemName.TabIndex = 29
        Me.lbl_ItemName.Text = "ITEM NAME :"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.SSGRID)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(177, 366)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(620, 188)
        Me.GroupBox3.TabIndex = 150
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "NEW PRODUCTS"
        '
        'SSGRID
        '
        Me.SSGRID.DataSource = Nothing
        Me.SSGRID.Location = New System.Drawing.Point(12, 24)
        Me.SSGRID.Name = "SSGRID"
        Me.SSGRID.OcxState = CType(resources.GetObject("SSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID.Size = New System.Drawing.Size(604, 159)
        Me.SSGRID.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(5, 177)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 14)
        Me.Label12.TabIndex = 441
        Me.Label12.Text = "CONVERSION QTY. :"
        '
        'TxtNConVQty
        '
        Me.TxtNConVQty.BackColor = System.Drawing.Color.Wheat
        Me.TxtNConVQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNConVQty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNConVQty.Location = New System.Drawing.Point(122, 174)
        Me.TxtNConVQty.MaxLength = 15
        Me.TxtNConVQty.Name = "TxtNConVQty"
        Me.TxtNConVQty.Size = New System.Drawing.Size(88, 20)
        Me.TxtNConVQty.TabIndex = 440
        Me.TxtNConVQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_AdjQty
        '
        Me.lbl_AdjQty.BackColor = System.Drawing.Color.Transparent
        Me.lbl_AdjQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_AdjQty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_AdjQty.ForeColor = System.Drawing.Color.Blue
        Me.lbl_AdjQty.Location = New System.Drawing.Point(122, 200)
        Me.lbl_AdjQty.Name = "lbl_AdjQty"
        Me.lbl_AdjQty.Size = New System.Drawing.Size(90, 27)
        Me.lbl_AdjQty.TabIndex = 439
        Me.lbl_AdjQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl_AdjQty.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 14)
        Me.Label4.TabIndex = 436
        Me.Label4.Text = "STOCK IN HAND:"
        '
        'lbl_NQty
        '
        Me.lbl_NQty.BackColor = System.Drawing.Color.Transparent
        Me.lbl_NQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_NQty.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_NQty.ForeColor = System.Drawing.Color.Blue
        Me.lbl_NQty.Location = New System.Drawing.Point(122, 137)
        Me.lbl_NQty.Name = "lbl_NQty"
        Me.lbl_NQty.Size = New System.Drawing.Size(88, 27)
        Me.lbl_NQty.TabIndex = 434
        Me.lbl_NQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_NStockUOM
        '
        Me.txt_NStockUOM.BackColor = System.Drawing.Color.Wheat
        Me.txt_NStockUOM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_NStockUOM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NStockUOM.Location = New System.Drawing.Point(122, 74)
        Me.txt_NStockUOM.MaxLength = 50
        Me.txt_NStockUOM.Name = "txt_NStockUOM"
        Me.txt_NStockUOM.ReadOnly = True
        Me.txt_NStockUOM.Size = New System.Drawing.Size(90, 20)
        Me.txt_NStockUOM.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 14)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "STOCK UOM :"
        '
        'Txt_Ncategory
        '
        Me.Txt_Ncategory.BackColor = System.Drawing.Color.Wheat
        Me.Txt_Ncategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Ncategory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Ncategory.Location = New System.Drawing.Point(122, 107)
        Me.Txt_Ncategory.MaxLength = 15
        Me.Txt_Ncategory.Name = "Txt_Ncategory"
        Me.Txt_Ncategory.ReadOnly = True
        Me.Txt_Ncategory.Size = New System.Drawing.Size(88, 20)
        Me.Txt_Ncategory.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 14)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "CATEGORY :"
        '
        'Txt_NItemcode
        '
        Me.Txt_NItemcode.BackColor = System.Drawing.Color.Wheat
        Me.Txt_NItemcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NItemcode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NItemcode.Location = New System.Drawing.Point(122, 21)
        Me.Txt_NItemcode.MaxLength = 15
        Me.Txt_NItemcode.Name = "Txt_NItemcode"
        Me.Txt_NItemcode.Size = New System.Drawing.Size(59, 20)
        Me.Txt_NItemcode.TabIndex = 12
        '
        'Cmd_NItemcode
        '
        Me.Cmd_NItemcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_NItemcode.Location = New System.Drawing.Point(190, 16)
        Me.Cmd_NItemcode.Name = "Cmd_NItemcode"
        Me.Cmd_NItemcode.Size = New System.Drawing.Size(22, 26)
        Me.Cmd_NItemcode.TabIndex = 13
        '
        'Txt_NItemName
        '
        Me.Txt_NItemName.BackColor = System.Drawing.Color.Wheat
        Me.Txt_NItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_NItemName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NItemName.Location = New System.Drawing.Point(122, 48)
        Me.Txt_NItemName.MaxLength = 50
        Me.Txt_NItemName.Name = "Txt_NItemName"
        Me.Txt_NItemName.ReadOnly = True
        Me.Txt_NItemName.Size = New System.Drawing.Size(90, 20)
        Me.Txt_NItemName.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 14)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "ITEM CODE :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 14)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "ITEM NAME :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Txt_NItemName)
        Me.GroupBox4.Controls.Add(Me.Cmd_NItemcode)
        Me.GroupBox4.Controls.Add(Me.TxtNConVQty)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.Txt_NItemcode)
        Me.GroupBox4.Controls.Add(Me.lbl_AdjQty)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Txt_Ncategory)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txt_NStockUOM)
        Me.GroupBox4.Controls.Add(Me.lbl_NQty)
        Me.GroupBox4.Location = New System.Drawing.Point(1021, 87)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(222, 239)
        Me.GroupBox4.TabIndex = 442
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "GroupBox4"
        Me.GroupBox4.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.txt_totconqty)
        Me.GroupBox5.Controls.Add(Me.txt_totconvalue)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.txt_wastagesqty)
        Me.GroupBox5.Controls.Add(Me.txt_wastagevalue)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Location = New System.Drawing.Point(407, 576)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(391, 80)
        Me.GroupBox5.TabIndex = 443
        Me.GroupBox5.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(244, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 16)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Value:"
        '
        'txt_totconqty
        '
        Me.txt_totconqty.BackColor = System.Drawing.Color.Wheat
        Me.txt_totconqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_totconqty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totconqty.Location = New System.Drawing.Point(179, 16)
        Me.txt_totconqty.MaxLength = 50
        Me.txt_totconqty.Name = "txt_totconqty"
        Me.txt_totconqty.ReadOnly = True
        Me.txt_totconqty.Size = New System.Drawing.Size(60, 22)
        Me.txt_totconqty.TabIndex = 18
        '
        'txt_totconvalue
        '
        Me.txt_totconvalue.BackColor = System.Drawing.Color.Wheat
        Me.txt_totconvalue.Enabled = False
        Me.txt_totconvalue.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totconvalue.Location = New System.Drawing.Point(299, 17)
        Me.txt_totconvalue.MaxLength = 50
        Me.txt_totconvalue.Name = "txt_totconvalue"
        Me.txt_totconvalue.ReadOnly = True
        Me.txt_totconvalue.Size = New System.Drawing.Size(81, 22)
        Me.txt_totconvalue.TabIndex = 19
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(74, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(92, 16)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Total Con Qty:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(243, 50)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 16)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Value:"
        '
        'txt_wastagesqty
        '
        Me.txt_wastagesqty.BackColor = System.Drawing.Color.Wheat
        Me.txt_wastagesqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_wastagesqty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_wastagesqty.Location = New System.Drawing.Point(179, 48)
        Me.txt_wastagesqty.MaxLength = 50
        Me.txt_wastagesqty.Name = "txt_wastagesqty"
        Me.txt_wastagesqty.ReadOnly = True
        Me.txt_wastagesqty.Size = New System.Drawing.Size(60, 22)
        Me.txt_wastagesqty.TabIndex = 2
        '
        'txt_wastagevalue
        '
        Me.txt_wastagevalue.BackColor = System.Drawing.Color.Wheat
        Me.txt_wastagevalue.Enabled = False
        Me.txt_wastagevalue.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_wastagevalue.Location = New System.Drawing.Point(299, 49)
        Me.txt_wastagevalue.MaxLength = 50
        Me.txt_wastagevalue.Name = "txt_wastagevalue"
        Me.txt_wastagevalue.ReadOnly = True
        Me.txt_wastagevalue.Size = New System.Drawing.Size(81, 22)
        Me.txt_wastagevalue.TabIndex = 4
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(74, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 16)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Wastage Qty:"
        '
        'FrmProductConversion_All
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Wheat
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res1
        Me.ClientSize = New System.Drawing.Size(1364, 749)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_Stocktransfer2)
        Me.Controls.Add(Me.grp_Stocktransfer1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox2)
        Me.KeyPreview = True
        Me.Name = "FrmProductConversion_All"
        Me.Text = "r"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.grp_Stocktransfer2.ResumeLayout(False)
        Me.grp_Stocktransfer2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_Stocktransfer1.ResumeLayout(False)
        Me.grp_Stocktransfer1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Dim vseqno As Double
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim doctype1 As String
    Dim gconnection As New GlobalClass
    Dim docno(), transferdocno, docno1() As String
    Dim clqty, clqty1 As Integer

    'Private Function fillUOM()
    '    Dim I As Integer
    '    sqlstring = "SELECT ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM UOMMaster where isnull(freeze,'')<>'Y'"
    '    gconnection.getDataSet(sqlstring, "UOMMaster")
    '    If gdataset.Tables("UOMMaster").Rows.Count > 0 Then
    '        cmbUOMCode.Items.Clear()
    '        cmbSubUOM.Items.Clear()
    '        For I = 0 To gdataset.Tables("UOMMaster").Rows.Count - 1
    '            cmbUOMCode.Items.Add(gdataset.Tables("UOMMaster").Rows(I).Item("UOMCODE").ToString())
    '            cmbSubUOM.Items.Add(gdataset.Tables("UOMMaster").Rows(I).Item("UOMCODE").ToString())
    '        Next
    '        cmbUOMCode.SelectedIndex = 0
    '        cmbSubUOM.SelectedIndex = 0
    '    End If
    'End Function
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            'Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
        Cmd_Add.Enabled = True
        SSGRID.ClearRange(1, 1, -1, -1, True)
        TXT_FROMSTORECODE.Text = ""
        txt_FromStorename.Text = ""
        txt_Docno.Text = ""
        txt_ItemCode.Text = ""
        txt_ItemName.Text = ""
        tXT_sTOCKuom.Text = ""
        TXT_CATEGORY.Text = ""
        lbl_Clstock.Text = ""
        lbl_Rate.Text = ""

        Txt_NItemcode.Text = ""
        Txt_NItemName.Text = ""
        txt_NStockUOM.Text = ""
        Txt_Ncategory.Text = ""
        txt_totconqty.Text = ""
        txt_totconvalue.Text = ""
        txt_wastagesqty.Text = ""
        txt_wastagevalue.Text = ""
        lbl_NQty.Text = ""
        TxtNConVQty.Text = ""
        TxtConVQty.Text = ""
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Cmd_Add.Text = "Add [F7]"
        Cmd_Freeze.Enabled = True
        TXT_FROMSTORECODE.Focus()
    End Sub
    Private Sub TxtConvFactor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        getPositiveNumeric(e)
    End Sub
    Private Sub cmbUOMCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If cmbUOMCode.Text <> "" And cmbSubUOM.Text <> "" Then
        '    Dim dtl As New DataTable
        '    sqlstring = "select isnull(CONVVALUE,0)as CONVVALUE,ISNULL(Freeze,'') AS Freeze,ISNULL(VOIDDATETIME,'')AS VOIDDATETIME  from INVENTORY_TRANSCONVERSION where BASEUOM ='" & cmbUOMCode.Text & "' and TRANSUOM ='" & cmbSubUOM.Text & "' "
        '    dtl = gconnection.GetValues(sqlstring)
        '    If dtl.Rows.Count > 0 Then
        '        TxtConvFactor.Text = Val(dtl.Rows(0).Item("CONVVALUE").ToString())
        '        Me.Cmd_Add.Text = "Update[F7]"
        '        If dtl.Rows(0).Item("Freeze") = "Y" Then
        '            Me.lbl_Freeze.Visible = True
        '            Me.lbl_Freeze.Text = ""
        '            Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(dtl.Rows(0).Item("VOIDDATETIME")), "dd-MM-yyyy")
        '            Me.Cmd_Freeze.Text = "UnFreeze[F8]"
        '        Else
        '            Me.lbl_Freeze.Visible = False
        '            Me.lbl_Freeze.Text = "Record Freezed  On "
        '            Me.Cmd_Freeze.Text = "Freeze[F8]"
        '        End If
        '        'TxtConvFactor.Focus()
        '    Else
        '        'TxtConvFactor.Focus()
        '        TxtConvFactor.Text = ""
        '        Cmd_Add.Text = "Add [F7]"
        '    End If
        'End If
    End Sub
    Private Sub cmbSubUOM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If cmbUOMCode.Text <> "" And cmbSubUOM.Text <> "" Then
        '    Dim dtl As New DataTable
        '    sqlstring = "select isnull(CONVVALUE,0)as CONVVALUE,ISNULL(Freeze,'') AS Freeze,ISNULL(VOIDDATETIME,'')AS VOIDDATETIME  from INVENTORY_TRANSCONVERSION where BASEUOM ='" & cmbUOMCode.Text & "' and TRANSUOM ='" & cmbSubUOM.Text & "' "
        '    dtl = gconnection.GetValues(sqlstring)
        '    If dtl.Rows.Count > 0 Then
        '        TxtConvFactor.Text = Val(dtl.Rows(0).Item("CONVVALUE").ToString())
        '        Me.Cmd_Add.Text = "Update[F7]"
        '        If dtl.Rows(0).Item("Freeze") = "Y" Then
        '            Me.lbl_Freeze.Visible = True
        '            Me.lbl_Freeze.Text = ""
        '            Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(dtl.Rows(0).Item("VOIDDATETIME")), "dd-MM-yyyy")
        '            Me.Cmd_Freeze.Text = "UnFreeze[F8]"
        '        Else
        '            Me.lbl_Freeze.Visible = False
        '            Me.lbl_Freeze.Text = "Record Freezed  On "
        '            Me.Cmd_Freeze.Text = "Freeze[F8]"
        '        End If
        '        'TxtConvFactor.Focus()
        '    Else
        '        'TxtConvFactor.Focus()
        '        TxtConvFactor.Text = ""
        '        Cmd_Add.Text = "Add [F7]"
        '    End If
        'End If
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim Adjustedamt, SQty, SRate, Physicalstock, dblval, Avgquantity, Avgrate, ERate, Rate, Amount, EAmount, Con_Qty, ECon_Qty, con_Stockinhand As Double
        Dim Con_itemcode, Con_itemname, Con_uom, cat As String
        Dim Insert(0), Doctype As String
        Dim GRNDATE As Date
        Dim j As Integer
        Try
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Cmd_Add.Text = "Add [F7]" Then
            
                autogenerate()


                sqlstring = "INSERT INTO Inv_Product_Conversion (docdetails,DocDate,Storecode,itemcode,itemname,uom,Qty,void,AddDate,addUSER,CATEGORY,Rate,Amount ) VALUES ( "
                sqlstring = sqlstring & "'" & txt_Docno.Text & "',"
                sqlstring = sqlstring & "'" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
                sqlstring = sqlstring & "'" & (TXT_FROMSTORECODE.Text) & "',"
                sqlstring = sqlstring & "'" & (txt_ItemCode.Text) & "',"
                sqlstring = sqlstring & "'" & (txt_ItemName.Text) & "',"
                sqlstring = sqlstring & "'" & (tXT_sTOCKuom.Text) & "',"
                'sqlstring = sqlstring & "" & Val(lbl_Clstock.Text) & ","
                
                '  sqlstring = sqlstring & "" & (lbl_NQty.Text) & ","
                sqlstring = sqlstring & "" & (TxtConVQty.Text) & ","
                sqlstring = sqlstring & "'N',"
                sqlstring = sqlstring & "getDate(),"
                sqlstring = sqlstring & "'" & (gUsername) & "',"
                Rate = Val(lbl_Rate.Text)
                Amount = Rate * Val(TxtConVQty.Text)

                sqlstring = sqlstring & "'" & (TXT_CATEGORY.Text) & "'," & (lbl_Rate.Text) & " ," & (Amount).ToString() & "  )"

                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                With SSGRID
                    For j = 1 To .DataRowCnt
                        .Row = j
                        .Col = 1
                        Con_itemcode = .Text
                        .Col = 2
                        Con_itemname = .Text
                        .Col = 3
                        Con_uom = .Text
                        .Col = 4
                        cat = .Text
                        .Col = 6
                        ECon_Qty = Val(.Text)
                        .Col = 7
                        ERate = Val(.Text)
                        .Col = 8
                        EAmount = Val(.Text)




                        sqlstring = "INSERT INTO Inv_Product_Conversion_Del (docdetails,DocDate,Storecode,itemcode,itemname,uom,Qty,Con_itemcode,Con_itemname,Con_uom,Con_Qty,void,AddDate,addUSER,CATEGORY,Rate,ERate,Amount,EAmount,	ECon_Qty ) VALUES ( "
                        sqlstring = sqlstring & "'" & txt_Docno.Text & "',"
                        sqlstring = sqlstring & "'" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
                        sqlstring = sqlstring & "'" & (TXT_FROMSTORECODE.Text) & "',"
                        sqlstring = sqlstring & "'" & (txt_ItemCode.Text) & "',"
                        sqlstring = sqlstring & "'" & (txt_ItemName.Text) & "',"
                        sqlstring = sqlstring & "'" & (tXT_sTOCKuom.Text) & "',"
                        sqlstring = sqlstring & "" & Val(lbl_Clstock.Text) & ","
                        sqlstring = sqlstring & "'" & Con_itemcode & "',"
                        sqlstring = sqlstring & "'" & (Con_itemname) & "',"
                        sqlstring = sqlstring & "'" & (Con_uom) & "',"
                        '  sqlstring = sqlstring & "" & (lbl_NQty.Text) & ","
                        sqlstring = sqlstring & "" & (TxtConVQty.Text) & ","
                        sqlstring = sqlstring & "'N',"
                        sqlstring = sqlstring & "getDate(),"
                        sqlstring = sqlstring & "'" & (gUsername) & "',"
                        Rate = Val(lbl_Rate.Text)
                        Amount = Rate * Val(TxtConVQty.Text)

                        sqlstring = sqlstring & "'" & (cat) & "'," & (lbl_Rate.Text) & "," & (ERate).ToString() & "," & (Amount).ToString() & "," & (EAmount).ToString & "," & (ECon_Qty) & ")"

                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring


                    Next
                End With

                'autogenerate()

                'sqlstring = "INSERT INTO Inv_Product_Conversion (docdetails,DocDate,Storecode,itemcode,itemname,uom,Qty,Con_itemcode,Con_itemname,Con_uom,Con_Qty,void,AddDate,addUSER,CATEGORY,Rate,ERate,Amount,EAmount,	ECon_Qty ) VALUES ( "
                'sqlstring = sqlstring & "'" & txt_Docno.Text & "',"
                'sqlstring = sqlstring & "'" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
                'sqlstring = sqlstring & "'" & (TXT_FROMSTORECODE.Text) & "',"
                'sqlstring = sqlstring & "'" & (txt_ItemCode.Text) & "',"
                'sqlstring = sqlstring & "'" & (txt_ItemName.Text) & "',"
                'sqlstring = sqlstring & "'" & (tXT_sTOCKuom.Text) & "',"
                'sqlstring = sqlstring & "" & Val(lbl_Clstock.Text) & ","
                'sqlstring = sqlstring & "'" & (Txt_NItemcode.Text) & "',"
                'sqlstring = sqlstring & "'" & (Txt_NItemName.Text) & "',"
                'sqlstring = sqlstring & "'" & (txt_NStockUOM.Text) & "',"
                ''  sqlstring = sqlstring & "" & (lbl_NQty.Text) & ","
                'sqlstring = sqlstring & "" & (TxtConVQty.Text) & ","
                'sqlstring = sqlstring & "'N',"
                'sqlstring = sqlstring & "getDate(),"
                'sqlstring = sqlstring & "'" & (gUsername) & "',"
                'Rate = Val(lbl_Rate.Text)
                'Amount = Rate * Val(TxtConVQty.Text)
                'ERate = Amount / Val(TxtNConVQty.Text)
                'EAmount = ERate * Val(TxtNConVQty.Text)
                'sqlstring = sqlstring & "'" & (TXT_CATEGORY.Text) & "'," & (lbl_Rate.Text) & "," & (ERate).ToString() & "," & (Amount).ToString() & "," & (EAmount).ToString & "," & (TxtNConVQty.Text) & ")"

                'Insert(0) = sqlstring

                '==========wWASTAGES========
                docno = Split(Trim(txt_Docno.Text), "/")

                If Val(txt_wastagesqty.Text) > 0 Then
                    sqlstring = "INSERT INTO STOCKDMGHEADER(Docno,Docdetails,Docdate,Doctype,storecode,storedesc "
                    sqlstring = sqlstring & ", Totalqty,Remarks,Void,Adduser,Adddate)"
                    sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
                    sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                    sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
                    sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
                    sqlstring = sqlstring & " " & Format(Val(txt_wastagesqty.Text), "0.000") & " ,"
                    sqlstring = sqlstring & "   ' ' ,"
                    sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',getDate())"
                    'sqlstring = sqlstring & " '',getDate())"

                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring



                    sqlstring = "INSERT INTO STOCKDMGDETAIL(Docno,Docdetails,Docdate,Doctype,storecode,storedesc,"
                    sqlstring = sqlstring & " Itemcode,Itemname,Uom,DMGQty,BatchNo,ClosingQty,"
                    sqlstring = sqlstring & " Void,Adduser,Adddate,rate,amount)"

                    sqlstring = sqlstring & " VALUES ('" & CStr(Trim(docno(1))) & "','" & CStr(Trim(txt_Docno.Text)) & "',"
                    sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd/MMM/yyyy") & "',"
                    sqlstring = sqlstring & " '" & Trim(doctype1) & "',"
                    sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "',"
                    sqlstring = sqlstring & " '" & Trim(txt_ItemCode.Text) & "',"
                    sqlstring = sqlstring & " '" & Trim(txt_ItemName.Text) & "',"
                    sqlstring = sqlstring & " '" & Trim(tXT_sTOCKuom.Text) & "',"
                    sqlstring = sqlstring & " " & Val(txt_wastagesqty.Text) & ",'',"
                    sqlstring = sqlstring & " " & Val(lbl_Clstock.Text) & ",'N',"
                    sqlstring = sqlstring & " '" & gUsername & "',"
                    sqlstring = sqlstring & "  GETDATE()," & Val(lbl_Rate.Text) & "," & Val(txt_wastagevalue.Text) & ")"


                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                    '================
                End If

               



                docno1 = Split(Trim(txt_Docno.Text), "/")
                sqlstring = "INSERT INTO STOCKADJUSTHEADER(Docno,Docdetails,Docdate,Storecode,StoreDESC,Adjustedstock, Stockinhand,"
                sqlstring = sqlstring & "  Physicalstock,Remarks,Void,Adduser,Adddate )"
                sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy ") & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                'sqlstring = sqlstring & " " & Format(Val(LBL_AMOUNT.Text), "0.00") & " ," & Format(Val(TxtConVQty.Text), "0.00") & ","
                sqlstring = sqlstring & " 0 ,0,"
                sqlstring = sqlstring & " 0,'' ,"
                sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',getdate())"

                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                'Avgrate = CalAverageRate(Trim(txt_ItemCode.Text))
                'Avgquantity = CalAverageQuantity(Trim(txt_ItemCode.Text))

            
                sqlstring = "INSERT INTO STOCKADJUSTDETAILS(Docno,Docdetails,DocDate,Storelocationcode,Storecode,StoreDESC,Itemcode,Itemname,Uom,Stockinhand,Physicalstock,Adjustedstock,Rate,Amount,Void,Adduser,Adddate)"
                sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                sqlstring = sqlstring & " '" & Trim(txt_ItemCode.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(txt_ItemName.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(tXT_sTOCKuom.Text) & "',"
                sqlstring = sqlstring & " " & Val(lbl_Clstock.Text) - Val(txt_wastagesqty.Text) & ","

           
                sqlstring = sqlstring & " '" & Trim(Val(lbl_Clstock.Text) - Val(txt_totconqty.Text)) & " ',"
                sqlstring = sqlstring & " " & Format(Val(txt_totconqty.Text) * -1, "0.000") & ","
                sqlstring = sqlstring & " " & Format(Val(lbl_Rate.Text), "0.000") & ","
                sqlstring = sqlstring & "" & Format(Val(lbl_Rate.Text) * (Val(txt_totconqty.Text) * -1), "0.000") & ","
                sqlstring = sqlstring & " 'N',"
                sqlstring = sqlstring & " '" & Trim(gUsername) & "',getdate())"

                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                With SSGRID


                    For j = 1 To .DataRowCnt
                        .Row = j
                        .Col = 1
                        Con_itemcode = .Text
                        .Col = 2
                        Con_itemname = .Text
                        .Col = 3
                        Con_uom = .Text
                        .Col = 5
                        con_Stockinhand = Val(.Text)
                        .Col = 6
                        ECon_Qty = Val(.Text)
                        .Col = 7
                        ERate = Val(.Text)
                        .Col = 8
                        EAmount = Val(.Text)




                        sqlstring = "INSERT INTO STOCKADJUSTDETAILS(Docno,Docdetails,DocDate,Storecode,StoreDESC,Itemcode,Itemname,Uom,Stockinhand,Physicalstock,Adjustedstock,Rate,Amount,Void,Adduser,Adddate)"
                        sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
                        sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
                        sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                        sqlstring = sqlstring & " '" & Trim(Con_itemcode) & "',"
                        sqlstring = sqlstring & " '" & Trim(Con_itemname) & "',"
                        sqlstring = sqlstring & " '" & Trim(Con_uom) & "',"
                        sqlstring = sqlstring & " " & Trim(Val(con_Stockinhand)) & ","
                        sqlstring = sqlstring & " " & Format(Val(con_Stockinhand) + Val(ECon_Qty), "0.000") & ","
                        sqlstring = sqlstring & " " & Format(Val(ECon_Qty), "0.000") & ","
                        sqlstring = sqlstring & " " & Format(Val(ERate), "0.000") & ","
                        sqlstring = sqlstring & "" & Format(Val(ERate) * (Val(ECon_Qty) + Val(con_Stockinhand)), "0.000") & ","
                        sqlstring = sqlstring & " 'N',"
                        sqlstring = sqlstring & " '" & Trim(gUsername) & "',getDate())"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring

                    Next
                End With
                'sqlstring = "select * from INVENTORY_TRANSCONVERSION where BASEUOM='" + tXT_sTOCKuom.Text + "' and TRANSUOM='" + txt_NStockUOM.Text + "'  and isnull(freeze,'N')<>'Y'"
                'gconnection.getDataSet(sqlstring, "UOMMaster")
                'If gdataset.Tables("UOMMaster").Rows.Count > 0 Then
                '    SQty = Val(TxtNConVQty.Text) * Val(gdataset.Tables("UOMMaster").Rows(0).Item("CONVVALUE"))
                '    SRate = Val(lbl_Rate.Text) / Val(gdataset.Tables("UOMMaster").Rows(0).Item("CONVVALUE"))
                'End If

                
                ' lbl_Clstock.Text = Val(SQty)

               



                gconnection.MoreTrans(Insert)


            ElseIf Cmd_Add.Text = "Update[F7]" Then


                Rate = Val(lbl_Rate.Text)
                Amount = Rate * Val(TxtConVQty.Text)
                ERate = Amount / Val(TxtNConVQty.Text)
                EAmount = ERate * Val(TxtNConVQty.Text)


                If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                    If Me.lbl_Freeze.Visible = True Then
                        MessageBox.Show(" The Freezed Record Can Not Be Updated", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                        boolchk = False
                    End If
                End If
                sqlstring = "update Inv_Product_Conversion set DocDate ='" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "' ,UPDATEUSER='" & gUsername & "',UPDATEDATE=GETDATE(),Storecode='" & (TXT_FROMSTORECODE.Text) & "',itemcode='" & (txt_ItemCode.Text) & "',itemname='" & (txt_ItemName.Text) & "',uom='" & (tXT_sTOCKuom.Text) & "',Qty=" & Val(lbl_Clstock.Text) & ",Con_itemcode='" & (Txt_NItemcode.Text) & "',Con_itemname='" & (Txt_NItemName.Text) & "',Con_uom='" & (txt_NStockUOM.Text) & "',Con_Qty=" & (TxtConVQty.Text) & ",CATEGORY='" + TXT_CATEGORY.Text + "' ,Rate=" & (lbl_Rate.Text) & ",ERate=" & (ERate).ToString() & ",Amount=" & (Amount).ToString() & ",EAmount=" & (EAmount).ToString & ",ECon_Qty=" & (TxtNConVQty.Text) & " 	 where docdetails='" & txt_Docno.Text & "'"
                Insert(0) = sqlstring

                docno1 = Split(Trim(txt_Docno.Text), "/")
                sqlstring = "UPDATE  STOCKADJUSTHEADER SET"

                sqlstring = sqlstring & " storecode='" & Trim(TXT_FROMSTORECODE.Text) & "',Storedesc='" & Trim(txt_FromStorename.Text) & "', "
                '   sqlstring = sqlstring & " " & Format(Val(txt_Totalamount.Text), "0.00") & " ," & Format(Val(txt_Totalqty.Text), "0.00") & ","
                sqlstring = sqlstring & "Adjustedstock= 0 ,Stockinhand=0,"
                sqlstring = sqlstring & "Physicalstock= 0,Remarks='' ,"
                sqlstring = sqlstring & "Void= 'N',Updateuser='" & Trim(gUsername) & "',Updatetime=getDate()"
                sqlstring = sqlstring & "  where Docdetails='" + Trim(txt_Docno.Text) + "'"


                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring



                sqlstring = "UPDATE STOCKADJUSTDETAILS SET VOID ='Y',Updateuser='" & Trim(gUsername) & "',Updatetime=getDate() WHERE DOCDETAILS='" + txt_Docno.Text + "'  "

                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                sqlstring = "INSERT INTO STOCKADJUSTDETAILS(Docno,Docdetails,DocDate,Storecode,StoreDESC,Itemcode,Itemname,Uom,Stockinhand,Physicalstock,Adjustedstock,Rate,Amount,Void,Adduser,Adddate)"
                sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                sqlstring = sqlstring & " '" & Trim(txt_ItemCode.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(txt_ItemName.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(tXT_sTOCKuom.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(lbl_Clstock.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(Val(lbl_Clstock.Text) - Val(TxtConVQty.Text)) & " ',"
                sqlstring = sqlstring & " " & Format(Val(TxtConVQty.Text) * -1, "0.000") & ","
                sqlstring = sqlstring & " " & Format(Val(lbl_Rate.Text), "0.000") & ","
                sqlstring = sqlstring & "" & Format(Val(lbl_Rate.Text) * (Val(TxtConVQty.Text) * -1), "0.000") & ","
                sqlstring = sqlstring & " 'N',"
                sqlstring = sqlstring & " '" & Trim(gUsername) & "',getdate())"

                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring


                'sqlstring = "select * from INVENTORY_TRANSCONVERSION where BASEUOM='" + tXT_sTOCKuom.Text + "' and TRANSUOM='" + txt_NStockUOM.Text + "'  and isnull(freeze,'N')<>'Y'"
                'gconnection.getDataSet(sqlstring, "UOMMaster")
                'If gdataset.Tables("UOMMaster").Rows.Count > 0 Then
                '    SQty = Val(TxtNConVQty.Text) * Val(gdataset.Tables("UOMMaster").Rows(0).Item("CONVVALUE"))
                '    SRate = Val(lbl_Rate.Text) / Val(gdataset.Tables("UOMMaster").Rows(0).Item("CONVVALUE"))
                'End If

                ' lbl_Clstock.Text = Val(SQty)
                SQty = Val(TxtNConVQty.Text) * Val(1)
                SRate = Val(lbl_Rate.Text) / Val(1)
                sqlstring = "INSERT INTO STOCKADJUSTDETAILS(Docno,Docdetails,DocDate,Storecode,StoreDESC,Itemcode,Itemname,Uom,Stockinhand,Physicalstock,Adjustedstock,Rate,Amount,Void,Adduser,Adddate)"
                sqlstring = sqlstring & " VALUES ('" & CStr(docno1(1)) & "','" & Trim(txt_Docno.Text) & "',"
                sqlstring = sqlstring & " '" & Format(CDate(dtp_Docdate.Value), "dd-MMM-yyyy") & "',"
                sqlstring = sqlstring & " '" & Trim(TXT_FROMSTORECODE.Text) & "','" & Trim(txt_FromStorename.Text) & "', "
                sqlstring = sqlstring & " '" & Trim(Txt_NItemcode.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(Txt_NItemName.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(txt_NStockUOM.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(Val(lbl_NQty.Text)) & "',"
                sqlstring = sqlstring & " '" & Format(Val(SQty) + Val(lbl_NQty.Text), "0.000") & "',"
                sqlstring = sqlstring & " " & Format(Val(SQty), "0.000") & ","
                sqlstring = sqlstring & " " & Format(Val(SRate), "0.000") & ","
                sqlstring = sqlstring & "" & Format(Val(SRate) * (Val(SQty) + Val(lbl_NQty.Text)), "0.000") & ","
                sqlstring = sqlstring & " 'N',"
                sqlstring = sqlstring & " '" & Trim(gUsername) & "',getDate())"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = sqlstring

                gconnection.MoreTrans(Insert)

            End If

            If txt_ItemCode.Text = "" Or TXT_FROMSTORECODE.Text = "" Then
                Exit Sub
            End If

            Dim dtitem, dtitem_dmg As New DataTable
            dtitem.Columns.Add("itemcode")
            dtitem.TableName = "TpItems"
            dtitem_dmg.Columns.Add("itemcode")
            dtitem_dmg.TableName = "TpItems"
            Dim ITEMCODE As String
            Dim I As Integer
            Dim items As String
            items = items & "'" & Trim(txt_ItemCode.Text) & "','" & Trim(Txt_NItemcode.Text) & "'"
            dtitem.Rows.Add(txt_ItemCode.Text)
            'dtitem.Rows.Add(Txt_NItemcode.Text)
            dtitem_dmg.Rows.Add(txt_ItemCode.Text)


            For I = 0 To SSGRID.DataRowCnt
                SSGRID.Row = I
                SSGRID.Col = 1
                ITEMCODE = Trim(SSGRID.Text)
                items = items & ",'" & Trim(ITEMCODE) & "'"
                dtitem.Rows.Add(ITEMCODE)
            Next

            Call Randomize()
            vOutfile = Mid("WEI" & (Rnd() * 800000000), 1, 10)
            vOutfile = Replace(vOutfile, ".", "")
            vOutfile = Replace(vOutfile, "+", "")
            Dim strrate As String
            Dim loccode As String
            sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
            gconnection.getDataSet(sqlstring, "loccode")
            If gdataset.Tables("loccode").Rows.Count > 0 Then
                loccode = gdataset.Tables("loccode").Rows(0).Item("location")
            Else
                loccode = "M"
            End If
            Try

                If Val(txt_wastagesqty.Text) > 0 Then
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), Trim(txt_ItemCode.Text), dtitem_dmg, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "DAMAGE")
                End If


                strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ADJUSTMENT")
            Catch ex As Exception
                MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                If Val(txt_wastagesqty.Text) > 0 Then
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), Trim(txt_ItemCode.Text), dtitem_dmg, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "DAMAGE")
                End If

                strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ADJUSTMENT")
            End Try
            sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
            gconnection.ExcuteStoreProcedure(sqlstring)


        Catch ex As Exception
            MessageBox.Show("ERROR OCCURRED: " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Cmd_Clear_Click(sender, e)
    End Sub
    Public Sub checkValidation()
        Try
            boolchk = False
            '''********** Check  Store Code Can't be blank *********************'''
            If Trim(TXT_FROMSTORECODE.Text) = "" Then
                MessageBox.Show(" Store Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_FROMSTORECODE.Focus()
                Exit Sub
            End If

            If Val(lbl_Clstock.Text) <= 0 Then
                MessageBox.Show(" Stock Not Avilable ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_FromStorename.Focus()
                Exit Sub
            End If

            'If Trim(txt_ItemCode.Text) = Trim(Txt_NItemcode.Text) Then
            '    MessageBox.Show(" Select Any Other Item.... ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Txt_NItemcode.Focus()
            '    Exit Sub
            'End If

            If Val(TxtConVQty.Text) <= 0 Then
                MessageBox.Show("Conversion Qty. can't Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TxtConVQty.Focus()
                Exit Sub
            Else
                If Val(txt_totconqty.Text) <= 0 Then
                    MessageBox.Show("Conversion Qty. can't Zero ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TxtNConVQty.Focus()
                    Exit Sub
                Else

                    If Val(TxtConVQty.Text) < Val(txt_totconqty.Text) Then
                        MessageBox.Show("Conversion Qty. can't Greater then new Conversion Qty.   ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        TxtNConVQty.Focus()
                        Exit Sub
                    End If


                End If
            End If


            If Val(TxtConVQty.Text) > Val(lbl_Clstock.Text) Then
                MessageBox.Show("Conversion Qty. can't be Greater than closing stock... ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                TxtConVQty.Focus()
                Exit Sub
            End If
            '
            'sqlstring = "select * from INVENTORY_TRANSCONVERSION where BASEUOM='" + tXT_sTOCKuom.Text + "' and TRANSUOM='" + txt_NStockUOM.Text + "'  and isnull(freeze,'N')<>'Y'"
            'gconnection.getDataSet(sqlstring, "INVENTORY_TRANSCONVERSION")
            'If gdataset.Tables("INVENTORY_TRANSCONVERSION").Rows.Count > 0 Then

            'Else
            '    MessageBox.Show(" UOM Conversion Not Avilable ....  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_FromStorename.Focus()
            '    Exit Sub
            'End If


            'If Trim(tXT_sTOCKuom.Text) <> Trim(txt_NStockUOM.Text) Then
            '    MessageBox.Show(" UOM Not matching... ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_FromStorename.Focus()
            '    Exit Sub
            'End If


            '''********** Check  Subsequent UOM Can't be blank *********************'''
            If Trim(txt_FromStorename.Text) = "" Then
                MessageBox.Show(" Store Desc. can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_FromStorename.Focus()
                Exit Sub
            End If
            '''********** Check  Conversion factor Can't be blank *********************'''
            If Trim(txt_ItemCode.Text) = "" Then
                MessageBox.Show(" Item Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_ItemCode.Focus()
                Exit Sub
            End If
            If Trim(txt_ItemName.Text) = "" Then
                MessageBox.Show(" Item Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_ItemName.Focus()
                Exit Sub
            End If
            If Trim(tXT_sTOCKuom.Text) = "" Then
                MessageBox.Show(" Stock UOM can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                tXT_sTOCKuom.Focus()
                Exit Sub
            End If

            If Trim(TXT_CATEGORY.Text) = "" Then
                MessageBox.Show("Category can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_CATEGORY.Focus()
                Exit Sub
            End If


            With SSGRID
                Dim j As Integer
                For j = 1 To .DataRowCnt
                    .Row = j
                    .Col = 1
                    If .Text = "" Then
                        MessageBox.Show("In Grid ItemCode can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        SSGRID.SetActiveCell(1, j)
                        Exit For
                        Exit Sub
                    End If
                    .Col = 2
                    If .Text = "" Then
                        MessageBox.Show("In Grid Itemname can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        SSGRID.SetActiveCell(2, j)
                        Exit For
                        Exit Sub
                    End If
                    .Col = 3
                    If .Text = "" Then
                        MessageBox.Show("In Grid Stockuom can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        SSGRID.SetActiveCell(3, j)
                        Exit For
                        Exit Sub
                    End If
                    .Col = 4
                    If .Text = "" Then
                        MessageBox.Show("In Grid Category can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        SSGRID.SetActiveCell(4, j)
                        Exit For
                        Exit Sub
                    End If
                    .Col = 6
                    If .Text = "" Then
                        MessageBox.Show("In Grid Conversion Qty can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        SSGRID.SetActiveCell(6, j)
                        Exit For
                        Exit Sub
                    End If
                Next

            End With

            'If Trim(Txt_NItemcode.Text) = "" Then
            '    MessageBox.Show(" Item Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Txt_NItemcode.Focus()
            '    Exit Sub
            'End If
            'If Trim(Txt_NItemName.Text) = "" Then
            '    MessageBox.Show(" Item Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Txt_NItemName.Focus()
            '    Exit Sub
            'End If
            'If Trim(txt_NStockUOM.Text) = "" Then
            '    MessageBox.Show(" Stock UOM can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    txt_NStockUOM.Focus()
            '    Exit Sub
            'End If

            'If Trim(Txt_Ncategory.Text) = "" Then
            '    MessageBox.Show("Category can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Txt_Ncategory.Focus()
            '    Exit Sub
            'End If


            If Me.lbl_Freeze.Visible = True Then
                MessageBox.Show("Freeze record can't be Update ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_Ncategory.Focus()
                Exit Sub
            End If



            boolchk = True
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Dim insert(0) As String
        Try
            '-->Check Validation
            If Trim(txt_Docno.Text) = "" Then
                MessageBox.Show(" Doc. No. can't be blank  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_Docno.Focus()
                Exit Sub
            End If
            If Trim(txt_ItemCode.Text) = "" Then
                MessageBox.Show("Itemcode can't be blank  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_Docno.Focus()
                Exit Sub
            End If
           
            '''********** Check  Subsequent UOM Can't be blank *********************'''

            If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
                sqlstring = "UPDATE  Inv_Product_Conversion "
                sqlstring = sqlstring & " SET void='Y',VOIDUSER='" & gUsername & " ', VOIDDATE=GETDATE() "
                sqlstring = sqlstring & " WHERE Docdetails ='" & txt_Docno.Text & "'"
                ' gconnection.dataOperation(3, sqlstring)
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring


                sqlstring = "UPDATE STOCKADJUSTDETAILS SET VOID ='Y',Updateuser='" & Trim(gUsername) & "',Updatetime=GETDATE() WHERE DOCDETAILS='" + txt_Docno.Text + "'  "
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring

                sqlstring = sqlstring & " update STOCKADJUSTHEADER set Void= 'Y',Updateuser='" & Trim(gUsername) & "',Updatetime=GETdATE()"
                sqlstring = sqlstring & "  where Docdetails='" + Trim(txt_Docno.Text) + "'  "

                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring



                sqlstring = "UPDATE STOCKDMGHEADER SET "
                sqlstring = sqlstring & " Void='Y' "
                sqlstring = sqlstring & " WHERE Docdetails='" & Trim(txt_Docno.Text) & "' "
                insert(0) = sqlstring

                If GACCPOST.ToUpper() = "Y" Then
                    sqlstring = "update  JOURNALENTRY set void='Y' where VoucherNo='" & Trim(txt_Docno.Text) & "' AND VoucherType='DAMAGE'  "
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                End If

                sqlstring = "UPDATE  STOCKDMGDETAIL set Void='Y' WHERE docdetails='" & Trim(txt_Docno.Text) & "' "
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring


                gconnection.MoreTrans(insert)

                Dim dtitem As New DataTable
                dtitem.Columns.Add("itemcode")
                dtitem.TableName = "TpItems"

                Dim ITEMCODE As String
                Dim I As Integer
                Dim items As String
                items = items & "'" & Trim(txt_ItemCode.Text) & "','" & Trim(Txt_NItemcode.Text) & "'"
                dtitem.Rows.Add(txt_ItemCode.Text)
                dtitem.Rows.Add(Txt_NItemcode.Text)
                For I = 0 To SSGRID.DataRowCnt
                    SSGRID.Row = I
                    SSGRID.Col = 1
                    ITEMCODE = Trim(SSGRID.Text)
                    items = items & ",'" & Trim(ITEMCODE) & "'"
                    dtitem.Rows.Add(ITEMCODE)
                Next
                Call Randomize()
                vOutfile = Mid("WEI" & (Rnd() * 800000000), 1, 10)
                vOutfile = Replace(vOutfile, ".", "")
                vOutfile = Replace(vOutfile, "+", "")
                Dim strrate As String
                Dim loccode As String
                sqlstring = "select isnull(STORESTATUS,'')as location from storemaster where storecode='" & Trim(TXT_FROMSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "loccode")
                If gdataset.Tables("loccode").Rows.Count > 0 Then
                    loccode = gdataset.Tables("loccode").Rows(0).Item("location")
                Else
                    loccode = "M"
                End If
                Try
                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ADJUSTMENT")
                Catch ex As Exception
                    MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

                    strrate = CALC_WEIGHTED_A(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Docdate.Value, "dd MMM yyyy"), items, dtitem, Trim(TXT_FROMSTORECODE.Text), "Q", vOutfile, loccode, txt_Docno.Text, "ADJUSTMENT")
                End Try
                sqlstring = "if exists(select * from sysobjects where name='" & strrate & "') begin DROP TABLE " & strrate & " end"
                gconnection.ExcuteStoreProcedure(sqlstring)


                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error: " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub



    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Dim rViewer As New Viewer
        Dim sqlstring, SSQL As String
        Dim r As New Rpt_ProductConvertion
        sqlstring = "SELECT * FROM vw_Inv_Product_Conversion where docdetails='" & txt_Docno.Text & "' ORDER BY DOCDATE "
        gconnection.getDataSet(sqlstring, "Inv_Product_Conversion_del")
        If gdataset.Tables("Inv_Product_Conversion_del").Rows.Count > 0 Then
            If chk_excel.Checked = True Then
                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "PROCDUCT CONVERSION ", "")
            Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "Inv_Product_Conversion_del"
                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName
                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text21")
                textobj2.Text = gUsername
                rViewer.Show()
            End If
        Else
            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        End If
    End Sub

    Private Sub FrmUOMRelation_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F6 Then
                Call Cmd_Clear_Click(Cmd_Clear, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F9 And Cmd_View.Visible = True Then
                Call Cmd_View_Click(Cmd_View, e)
                Exit Sub
            End If
            If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
                Call Cmd_Exit_Click(Cmd_Exit, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub



    Private Sub cmd_fromStorecodeHelp_Click(sender As Object, e As EventArgs) Handles cmd_fromStorecodeHelp.Click
        gSQLString = "SELECT DISTINCT storecode,ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER"
        M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y' and isnull(Storestatus,'M')='M'"
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
            Call autogenerate()
            txt_ItemCode.Focus()
        Else
            Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub TXT_FROMSTORECODE_Validated(sender As Object, e As EventArgs) Handles TXT_FROMSTORECODE.Validated
        If Trim(TXT_FROMSTORECODE.Text) <> "" Then
            sqlstring = "SELECT * FROM STOREMASTER WHERE ISNULL(FREEZE,'') <> 'Y' and storecode='" & Trim(TXT_FROMSTORECODE.Text) & "' and  isnull(Storestatus,'M')='M'"
            gconnection.getDataSet(sqlstring, "storemaster")
            If gdataset.Tables("storemaster").Rows.Count > 0 Then
                TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                txt_FromStorename.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))

                Call autogenerate()
                dtp_Docdate.Focus()
            Else
                TXT_FROMSTORECODE.Text = ""
                TXT_FROMSTORECODE.Focus()
            End If
        End If
    End Sub

    Private Sub cmd_Docnohelp_Click(sender As Object, e As EventArgs) Handles cmd_Docnohelp.Click
        Try

            gSQLString = "SELECT docdetails,docdate FROM Inv_Product_Conversion "
            M_WhereCondition = " "
            Dim vform As New List_Operation
            vform.Field = "DOCDETAILS,DOCDATE"
            vform.vFormatstring1 = "       DOC NO                       |         DOC DATE                                                           "
            vform.vCaption = "Product Conversion HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_Docno.Text = Trim(vform.keyfield & "")
                Call txt_Docno_Validated(txt_Docno, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Docno_Validated(sender As Object, e As EventArgs) Handles txt_Docno.Validated
        Try
            If Trim(txt_Docno.Text) <> "" Then
                sqlstring = "SELECT * FROM Inv_Product_Conversion WHERE docdetails='" & Trim(txt_Docno.Text) & "'"
                gconnection.getDataSet(sqlstring, "Inv_Product_Conversion")
                If gdataset.Tables("Inv_Product_Conversion").Rows.Count > 0 Then

                    Cmd_Add.Enabled = False
                    'Me.Cmd_Add.Text = "Update[F7]"
                    dtp_Docdate.Value = Format(CDate(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("docdate")), "dd-MM-yyyy")

                    TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("storecode"))
                    sqlstring = " SELECT STOREDESC FROM STOREMASTER WHERE STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "'"
                    gconnection.getDataSet(sqlstring, "STOREMASTER")
                    If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                        txt_FromStorename.Text = Trim(gdataset.Tables("STOREmaster").Rows(0).Item("storeDESC"))
                    End If
                    txt_ItemCode.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("itemcode"))
                    txt_ItemName.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("itemname"))
                    TXT_CATEGORY.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("CATEGORY") & "")
                    'Txt_Ncategory.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("CATEGORY") & "")
                    tXT_sTOCKuom.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("uom") & "")
                    lbl_Rate.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("rate") & "")
                    TxtConVQty.Text = Format(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("qty"), "0.00")
                    LBL_AMOUNT.Text = Format(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("amount"), "0.000")

                    sqlstring = "SELECT * FROM Inv_Product_Conversion_del WHERE docdetails='" & Trim(txt_Docno.Text) & "'"
                    gconnection.getDataSet(sqlstring, "Inv_Product_Conversion_del")
                    If gdataset.Tables("Inv_Product_Conversion_del").Rows.Count > 0 Then

                        Dim n As Integer
                        Dim totqty As Double
                        totqty = 0
                        For n = 0 To gdataset.Tables("Inv_Product_Conversion_del").Rows.Count - 1
                            With SSGRID
                                .Row = n + 1
                                .Col = 1
                                .Text = gdataset.Tables("Inv_Product_Conversion_del").Rows(n).Item("Con_itemcode")
                                .Col = 2
                                .Text = gdataset.Tables("Inv_Product_Conversion_del").Rows(n).Item("Con_itemname")
                                .Col = 3
                                .Text = gdataset.Tables("Inv_Product_Conversion_del").Rows(n).Item("Con_uom")
                                .Col = 4
                                .Text = gdataset.Tables("Inv_Product_Conversion_del").Rows(n).Item("CATEGORY")

                                sqlstring = "SELECT * FROM STOCKADJUSTDETAILS WHERE docdetails='" & Trim(txt_Docno.Text) & "' and itemcode='" & gdataset.Tables("Inv_Product_Conversion_del").Rows(n).Item("Con_itemcode") & "'"
                                gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS")

                                If gdataset.Tables("STOCKADJUSTDETAILS").Rows.Count > 0 Then
                                    .Col = 5
                                    .Text = gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("Physicalstock")
                                End If

                                .Col = 6
                                .Text = gdataset.Tables("Inv_Product_Conversion_del").Rows(n).Item("eCon_Qty")
                                totqty = totqty + gdataset.Tables("Inv_Product_Conversion_del").Rows(n).Item("eCon_Qty")
                                .Col = 7
                                .Text = gdataset.Tables("Inv_Product_Conversion_del").Rows(n).Item("erate")

                                .Col = 8
                                .Text = gdataset.Tables("Inv_Product_Conversion_del").Rows(n).Item("eamount")
                            End With
                        Next


                        sqlstring = "SELECT * FROM STOCKDMGDETAIL WHERE docdetails='" & Trim(txt_Docno.Text) & "'"
                        gconnection.getDataSet(sqlstring, "STOCKDMGDETAIL")
                        If gdataset.Tables("STOCKDMGDETAIL").Rows.Count > 0 Then

                            txt_wastagevalue.Text = gdataset.Tables("STOCKDMGDETAIL").Rows(0).Item("amount")
                            txt_wastagesqty.Text = gdataset.Tables("STOCKDMGDETAIL").Rows(0).Item("dmgqty")

                            lbl_Clstock.Text = gdataset.Tables("STOCKDMGDETAIL").Rows(0).Item("closingqty")

                            txt_totconqty.Text = Format(TxtConVQty.Text - txt_wastagesqty.Text, "0.00")
                            txt_totconvalue.Text = Format(Val(LBL_AMOUNT.Text) - txt_wastagevalue.Text, "0.000")
                        End If


                    End If


                    ' ''Txt_NItemcode.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("Con_itemcode"))
                    ' ''Txt_NItemName.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("Con_itemname"))
                    ' ''txt_NStockUOM.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("Con_uom") & "")
                    ' GRNDATE = Format(CDate(Date.Now), "dd-MMM-yyyy")
                    ' ''lbl_AdjQty.Text = Trim(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("Con_Qty") & "")


                    Dim GRNDATE As Date

                    GRNDATE = Format(CDate(Date.Now), "dd-MMM-yyyy")
                    Dim lastQty As Double
                    lastQty = Val(lbl_NQty.Text)
                    ' lbl_Clstock.Text = ClosingQuantity_Date(Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom")), GRNDATE)
                    ' lbl_NQty.Text = Val(ClosingQuantity_bYpROC(Trim("'" + Txt_NItemcode.Text + "'"), Trim(TXT_FROMSTORECODE.Text), Trim(tXT_sTOCKuom.Text), GRNDATE)) - Val(lbl_AdjQty.Text)






                    


                    If gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("Void") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = "Record Freezed  On : " & Format(CDate(gdataset.Tables("Inv_Product_Conversion").Rows(0).Item("voidDate")), "dd-MMM-yyyy")
                        ' Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                        lbl_NQty.Text = (Val(TxtConVQty.Text) + Val(lbl_NQty.Text)).ToString()
                        Cmd_Freeze.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = ""
                        Me.Cmd_Freeze.Text = "Freeze[F8]"
                    End If

                    'GRNDATE = Format(CDate(Date.Now), "dd-MMM-yyyy")
                    'lbl_Clstock.Text = ClosingQuantity_Date(Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom")), GRNDATE)
                    'If Val(lbl_Clstock.Text) <= 0 Then
                    '    MessageBox.Show("Stock Not Avilable", MyCompanyName, MessageBoxButtons.OK)
                    '    txt_ItemCode.Text = ""
                    '    txt_ItemName.Text = ""
                    '    TXT_CATEGORY.Text = ""
                    '    tXT_sTOCKuom.Text = ""
                    '    txt_ItemCode.Focus()
                    'End If
                Else
                    Cmd_Add.Enabled = True
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_ItemCode_Click(sender As Object, e As EventArgs) Handles Cmd_ItemCode.Click
        gSQLString = "SELECT DISTINCT(itemcode),itemname  FROM INV_InventoryItemMaster "
        M_WhereCondition = " where itemcode in (select itemcode from inv_InventoryOpenningstock where storecode ='" & Trim(TXT_FROMSTORECODE.Text) & "' )  and isnull(void,'N')<>'Y' "
        Dim vform As New ListOperattion1
        vform.Field = "ITEMNAME,ITEMCODE"
        vform.vFormatstring = "          ITEM CODE              |                        ITEM DESCRIPTION                                                                                                "
        vform.vCaption = "INVENTORY ITEM MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_ItemCode.Text = Trim(vform.keyfield & "")
            Call txt_ItemCode_Validated(txt_ItemCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub autogenerate()

        If Cmd_Add.Text <> "Add [F7]" Then
            Exit Sub
        End If
        Dim Sqlstring, Financalyear As String
        If TXT_FROMSTORECODE.Text <> "" Then
            ' doctype1 = Mid(TXT_FROMSTORECODE.Text, 1, 3)
            doctype1 = "PCV"
        End If
        Try
            Financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialyearEnd, 3, 4)
            Sqlstring = "SELECT MAX(Cast(SUBSTRING(docdetails,5,6) As Numeric)) FROM Vw_Inv_GetDoc "
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

    Private Sub Cmd_NItemcode_Click(sender As Object, e As EventArgs) Handles Cmd_NItemcode.Click

        If txt_ItemCode.Text <> "" Then


            gSQLString = "SELECT DISTINCT(itemcode),itemname  FROM INV_InventoryItemMaster "
            M_WhereCondition = " where itemcode in (select itemcode from inv_InventoryOpenningstock where storecode ='" & Trim(TXT_FROMSTORECODE.Text) & "' )  and category='" + TXT_CATEGORY.Text + "' and isnull(void,'N')<>'Y' "
            Dim vform As New ListOperattion1
            vform.Field = "ITEMNAME,ITEMCODE"
            vform.vFormatstring = "          ITEM CODE              |                        ITEM DESCRIPTION                                                                                                "
            vform.vCaption = "INVENTORY ITEM MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_NItemcode.Text = Trim(vform.keyfield & "")
                Call Txt_NItemcode_Validated(Txt_NItemcode, e)
            End If
            vform.Close()
            vform = Nothing
        Else
            MessageBox.Show("Select Existing Product first..", MyCompanyName, MessageBoxButtons.OK)
            txt_ItemCode.Focus()
        End If

    End Sub


    Private Sub txt_ItemCode_Validated(sender As Object, e As EventArgs) Handles txt_ItemCode.Validated
        Dim GRNDATE As Date
        Try
            If Trim(txt_ItemCode.Text) <> "" And Mid(Cmd_Add.Text, 1, 1) = "A" Then
                sqlstring = "SELECT * FROM INV_InventoryItemMaster WHERE  itemcode in (select itemcode from inv_InventoryOpenningstock where itemcode='" & Trim(txt_ItemCode.Text) & "' and storecode = '" & Trim(TXT_FROMSTORECODE.Text) & "' ) and isnull(void,'N')<>'Y'  "
                gconnection.getDataSet(sqlstring, "INV_InventoryItemMaster")
                If gdataset.Tables("INV_InventoryItemMaster").Rows.Count > 0 Then


                    txt_ItemCode.Text = Trim(gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("itemcode"))
                    txt_ItemName.Text = Trim(gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("itemname"))
                    TXT_CATEGORY.Text = Trim(gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("CATEGORY") & "")
                    tXT_sTOCKuom.Text = Trim(gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("stockuom") & "")
                    ' lbl_Rate.Text = Trim(gdataset.Tables("INV_InventoryItemMaster").Rows(0).Item("purchaserate") & "")
                    GRNDATE = Format(CDate(Date.Now), "dd-MMM-yyyy")
                    ' lbl_Clstock.Text = ClosingQuantity_Date(Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom")), GRNDATE)

                    gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), txt_ItemCode.Text, Trim(TXT_FROMSTORECODE.Text), "")

                    '   Dim closingqty, RATE As Double
                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        lbl_Clstock.Text = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                        lbl_Rate.Text = gdataset.Tables("closingstock").Rows(0).Item("RATE")
                    Else
                        lbl_Clstock.Text = "0"
                        lbl_Rate.Text = "0"
                    End If

                    If Val(lbl_Clstock.Text) <= 0 Then
                        MessageBox.Show("Stock Not Avilable", MyCompanyName, MessageBoxButtons.OK)
                        txt_ItemCode.Text = ""
                        txt_ItemName.Text = ""
                        TXT_CATEGORY.Text = ""
                        tXT_sTOCKuom.Text = ""
                        txt_ItemCode.Focus()
                    Else
                        'sqlstring = "SELECT * FROM inventoryitemmaster WHERE itemcode='" & Trim(txt_ItemCode.Text) & "(FR)' and category='" + TXT_CATEGORY.Text + "' and storecode = '" & Trim(TXT_FROMSTORECODE.Text) & "'"
                        'gconnection.getDataSet(sqlstring, "inventoryitemmaster")
                        'If gdataset.Tables("inventoryitemmaster").Rows.Count > 0 Then

                        '    'TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("storecode"))
                        '    'sqlstring = " SELECT STOREDESC FROM STOREMASTER WHERE STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "'"
                        '    'gconnection.getDataSet(sqlstring, "STOREMASTER")
                        '    'If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                        '    '    txt_FromStorename.Text = Trim(gdataset.Tables("STOREmaster").Rows(0).Item("storeDESC"))
                        '    'End If
                        '    Txt_NItemcode.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode"))
                        '    Txt_NItemName.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemname"))
                        '    Txt_Ncategory.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("CATEGORY") & "")
                        '    txt_NStockUOM.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom") & "")
                        '    GRNDATE = Format(CDate(Date.Now), "dd-MMM-yyyy")
                        '    'lbl_NQty.Text = ClosingQuantity_Date(Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom")), GRNDATE)
                        '    lbl_NQty.Text = ClosingQuantity_bYpROC(Trim("'" + gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode") + "'"), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom")), GRNDATE)
                        '    Cmd_Add.Focus()
                        'Else
                        '    Txt_NItemcode.Text = txt_ItemCode.Text & "(FR)"
                        '    Txt_NItemcode.ReadOnly = True

                        '    Txt_NItemName.Text = txt_ItemName.Text & "(FR)"
                        '    Txt_NItemName.ReadOnly = True
                        '    Txt_Ncategory.Text = TXT_CATEGORY.Text
                        '    txt_NStockUOM.Text = tXT_sTOCKuom.Text
                        '    lbl_NQty.Text = "0"
                        'End If

                        TxtConVQty.Focus()
                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Txt_NItemcode_Validated(sender As Object, e As EventArgs) Handles Txt_NItemcode.Validated
        Dim GRNDATE As Date
        Try
            If txt_ItemCode.Text = Txt_NItemcode.Text Then
                Txt_NItemcode.Text = ""
                Txt_NItemName.Text = ""
                txt_NStockUOM.Text = ""
                Txt_Ncategory.Text = ""
                lbl_NQty.Text = ""
                MessageBox.Show("Select Other Item", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Trim(Txt_NItemcode.Text) <> "" And Mid(Cmd_Add.Text, 1, 1) = "A" Then
                sqlstring = "SELECT * FROM INV_InventoryItemMaster  WHERE itemcode in (select itemcode from inv_InventoryOpenningstock where itemcode='" & Trim(Txt_NItemcode.Text) & "' and storecode = '" & Trim(TXT_FROMSTORECODE.Text) & "') and category='" + TXT_CATEGORY.Text + "' and isnull(void,'N')<>'Y' "
                gconnection.getDataSet(sqlstring, "inventoryitemmaster")
                If gdataset.Tables("inventoryitemmaster").Rows.Count > 0 Then

                    'TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("storecode"))
                    'sqlstring = " SELECT STOREDESC FROM STOREMASTER WHERE STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "'"
                    'gconnection.getDataSet(sqlstring, "STOREMASTER")
                    'If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                    '    txt_FromStorename.Text = Trim(gdataset.Tables("STOREmaster").Rows(0).Item("storeDESC"))
                    'End If
                    Txt_NItemcode.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode"))
                    Txt_NItemName.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemname"))
                    Txt_Ncategory.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("CATEGORY") & "")
                    txt_NStockUOM.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom") & "")
                    GRNDATE = Format(CDate(Date.Now), "dd-MMM-yyyy")
                    'lbl_NQty.Text = ClosingQuantity_Date(Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom")), GRNDATE)
                    'lbl_NQty.Text = ClosingQuantity_bYpROC(Trim("'" + gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode") + "'"), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom")), GRNDATE)

                    gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), Txt_NItemcode.Text, Trim(TXT_FROMSTORECODE.Text), "")

                    '   Dim closingqty, RATE As Double
                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        lbl_NQty.Text = gdataset.Tables("closingstock").Rows(0).Item("closingstock")
                    Else
                        lbl_NQty.Text = "0"
                    End If

                    Cmd_Add.Focus()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub TXT_FROMSTORECODE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_FROMSTORECODE.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmd_fromStorecodeHelp.Enabled = True Then
                search = Trim(TXT_FROMSTORECODE.Text)
                Call cmd_fromStorecodeHelp_Click(cmd_fromStorecodeHelp, e)
            End If
        End If
    End Sub

    Private Sub TXT_FROMSTORECODE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT_FROMSTORECODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_FROMSTORECODE.Text) = "" Then
                Call cmd_fromStorecodeHelp_Click(sender, e)
            Else
                Call TXT_FROMSTORECODE_Validated(TXT_FROMSTORECODE.Text, e)
            End If
        End If
    End Sub

    Private Sub txt_ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_ItemCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Cmd_ItemCode.Enabled = True Then
                search = Trim(txt_ItemCode.Text)
                Call Cmd_ItemCode_Click(Cmd_ItemCode, e)
            End If
        End If
    End Sub

    Private Sub txt_ItemCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ItemCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_ItemCode.Text) = "" Then
                Call Cmd_ItemCode_Click(sender, e)
            Else
                Call txt_ItemCode_Validated(txt_ItemCode.Text, e)
            End If
        End If
    End Sub

    Private Sub Txt_NItemcode_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_NItemcode.KeyDown, Txt_NItemName.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Cmd_NItemcode.Enabled = True Then
                search = Trim(Txt_NItemcode.Text)
                Call Cmd_NItemcode_Click(Cmd_NItemcode, e)
            End If
        End If
    End Sub

    Private Sub Txt_NItemcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_NItemcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_NItemcode.Text) = "" Then
                Call Cmd_NItemcode_Click(sender, e)
            Else
                Call Txt_NItemcode_Validated(Txt_NItemcode.Text, e)
            End If
        End If
    End Sub

    Private Sub TxtConVQty_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtConVQty.Validating
        If Val(TxtConVQty.Text) <> 0 Then
            If Val(TxtConVQty.Text) > Val(lbl_Clstock.Text) Then
                MessageBox.Show("Conversion Qty. can't be Greater than closing stock... ", MyCompanyName, MessageBoxButtons.OK)
                TxtConVQty.Text = lbl_Clstock.Text
            End If
        End If
    End Sub

    Private Sub TxtConVQty_Validated(sender As Object, e As EventArgs) Handles TxtConVQty.Validated
        If Val(TxtConVQty.Text) > Val(lbl_Clstock.Text) Then
            MessageBox.Show("Conversion Qty. can't be Greater than closing stock... ", MyCompanyName, MessageBoxButtons.OK)
            TxtConVQty.Text = lbl_Clstock.Text
        End If
    End Sub

    Private Sub TxtConVQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtConVQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(lbl_Rate.Text) >= 0 Then
                LBL_AMOUNT.Text = Val(lbl_Rate.Text) * Val(TxtConVQty.Text)
            End If
        End If
    End Sub

    Private Sub TxtConVQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtConVQty.KeyPress
        Try
            Call getNumeric(e)

            If Val(lbl_Rate.Text) >= 0 Then
                LBL_AMOUNT.Text = Val(lbl_Rate.Text) * Val(TxtConVQty.Text)
            End If

            If Asc(e.KeyChar) = 13 Then
                If Val(TxtConVQty.Text) > 0 Then
                    SSGRID.Focus()
                Else
                    TxtConVQty.Focus()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : Conversion Qty. " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub FrmProductConversion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmd_Docnohelp.Focus()

        SSGRID.Col = 7
        SSGRID.ColHidden = True

        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
    End Sub

    Private Sub dtp_Docdate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_Docdate.KeyDown

    End Sub

    Private Sub dtp_Docdate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtp_Docdate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txt_ItemCode.Focus()
        End If
    End Sub



    Private Sub FrmProductConversion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Call MGC_P()
    End Sub

    Private Sub FrmProductConversion_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

    End Sub


    Private Sub SSGRID_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID.KeyDownEvent
        Try
            Dim I As Integer
            Dim QTY, TOTQTY, rate As Double
            If e.keyCode = Keys.Enter Then
                With SSGRID
                    .Row = .ActiveRow
                    If .ActiveCol = 1 Then
                        If Trim(.Text) = "" Then
                            BINDITEMCODE()
                            VALIDATEITEMCODE()
                        Else
                            VALIDATEITEMCODE()

                        End If


                        .Col = 1
                        .Row = .ActiveRow
                        If (check_Duplicate(.Text) = True) Then
                            SSGRID.DeleteRows(SSGRID.ActiveRow, 1)
                            Exit Sub
                        End If



                    ElseIf .ActiveCol = 6 Then

                        If .Text <> "" Then
                            If (check_totQty(TxtConVQty.Text) = True) Then

                                SSGRID.SetActiveCell(1, SSGRID.ActiveRow)
                                SSGRID.DeleteRows(SSGRID.ActiveRow, 1)

                                Exit Sub
                            End If

                            .Row = .ActiveRow
                            TOTQTY = 0
                            QTY = 0
                            For I = 1 To .DataRowCnt
                                .Row = I
                                .Col = 6
                                TOTQTY = TOTQTY + Val(.Text)
                            Next

                            For I = 1 To .DataRowCnt
                                .Row = I
                                .Col = 6
                                QTY = .Text
                                .Col = 8
                                .Text = (Val(LBL_AMOUNT.Text - Val(txt_wastagevalue.Text)) * QTY) / TOTQTY
                                rate = (Val(LBL_AMOUNT.Text - Val(txt_wastagevalue.Text)) * QTY) / TOTQTY
                                .Col = 7
                                .Text = rate / QTY
                                If QTY > 0 Then
                                    SSGRID.SetActiveCell(1, I + 1)
                                Else
                                    SSGRID.SetActiveCell(6, I)
                                End If

                            Next




                        End If

                    End If


                End With
            ElseIf e.keyCode = Keys.F3 Or e.keyCode = Keys.Delete Then
                SSGRID.DeleteRows(SSGRID.ActiveRow, 1)
                SSGRID.SetActiveCell(1, SSGRID.ActiveRow)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function check_totQty(ByVal qty As Double) As Boolean
        Dim totqty, conqty As Double

        Dim i As Integer
        With SSGRID
            .Row = .ActiveRow
            TOTQTY = 0
            qty = 0

            



            For i = 1 To .DataRowCnt
                .Row = i

                'totqty = totqty + Val(.Text)


                .Col = 3
                'If .Text <> tXT_sTOCKuom.Text And .Text <> "" Then
                sqlstring = "select convvalue,isnull(precise,0) as precise from INVENTORY_TRANSCONVERSION where baseuom='" & tXT_sTOCKuom.Text & "' and TRANSUOM ='" & .Text & "'"
                gconnection.getDataSet(sqlstring, "uomcon")
                If gdataset.Tables("uomcon").Rows.Count > 0 Then
                    .Col = 6
                    'conqty =
                    totqty = (totqty) + (Val(.Text) / gdataset.Tables("uomcon").Rows(0).Item("convvalue"))
                Else
                    MsgBox("First Provide UOM Convensrion between " & tXT_sTOCKuom.Text & " and " & .Text, MsgBoxStyle.Critical, "Uom Relation Missing")
                    Return True
                End If

                'Else

                'End If


            Next


            If totqty > Val(TxtConVQty.Text) Then
                MsgBox("Provided Total Child item qty Cant be Greater than Parent item qty on uom " & tXT_sTOCKuom.Text, MsgBoxStyle.Critical, "Uom Relation Missing")
                Return True
            ElseIf totqty <= Val(TxtConVQty.Text) Then
                txt_totconqty.Text = Format(totqty, "0.00")
                txt_totconvalue.Text = Format(totqty * Val(lbl_Rate.Text), "0.00")

                If Val(TxtConVQty.Text) - totqty > 0.5 Then
                    txt_wastagesqty.Text = Format(Val(TxtConVQty.Text) - totqty, "0.00")
                    txt_wastagevalue.Text = Format(txt_wastagesqty.Text * Val(lbl_Rate.Text), "0.00")
                Else
                    txt_wastagesqty.Text = 0.0
                    txt_wastagevalue.Text = 0.0
                End If

               
            End If

            Return False
        End With
    End Function

    Private Function check_Duplicate(ByVal Itemcode As String) As Boolean
        Dim i As Integer
        Dim sql As String

        SSGRID.Col = 1
        For i = 1 To SSGRID.DataRowCnt
            SSGRID.Row = i
            If i <> SSGRID.ActiveRow Then
                If Trim(SSGRID.Text) = Trim(Itemcode) Then


                    MsgBox("Item Already exists", MsgBoxStyle.Critical, "Duplicate")
                    Return True

                End If
            End If
        Next
        Return False
    End Function
    Sub BINDITEMCODE()

        If txt_ItemCode.Text <> "" Then


            gSQLString = "SELECT DISTINCT(itemcode),itemname  FROM INV_InventoryItemMaster "
            M_WhereCondition = " where itemcode in (select itemcode from inv_InventoryOpenningstock where storecode ='" & Trim(TXT_FROMSTORECODE.Text) & "' )  and category='" + TXT_CATEGORY.Text + "' and isnull(void,'N')<>'Y' "
            Dim vform As New ListOperattion1
            vform.Field = "ITEMNAME,ITEMCODE"
            vform.vFormatstring = "          ITEM CODE              |                        ITEM DESCRIPTION                                                                                                "
            vform.vCaption = "INVENTORY ITEM MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then

                With SSGRID
                    .Row = .ActiveRow
                    .Col = 1
                    .Text = Trim(vform.keyfield & "")
                End With

            End If
            vform.Close()
            vform = Nothing
        Else
            MessageBox.Show("Select Existing Product first..", MyCompanyName, MessageBoxButtons.OK)
            txt_ItemCode.Focus()
        End If
    End Sub

    Sub VALIDATEITEMCODE()
        Dim GRNDATE As Date, Txt_NItemcode As String
        Try
            SSGRID.Row = SSGRID.ActiveRow
            SSGRID.Col = 1
            Txt_NItemcode = SSGRID.Text
            If txt_ItemCode.Text = Txt_NItemcode Then
                SSGRID.DeleteRows(SSGRID.ActiveRow, 1)
                SSGRID.SetActiveCell(1, SSGRID.ActiveRow)
                MessageBox.Show("Select Other Item", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Trim(Txt_NItemcode) <> "" And Mid(Cmd_Add.Text, 1, 1) = "A" Then
                sqlstring = "SELECT * FROM INV_InventoryItemMaster  WHERE itemcode in (select itemcode from inv_InventoryOpenningstock where itemcode='" & Trim(Txt_NItemcode) & "' and storecode = '" & Trim(TXT_FROMSTORECODE.Text) & "') and category='" + TXT_CATEGORY.Text + "' and isnull(void,'N')<>'Y' "
                gconnection.getDataSet(sqlstring, "inventoryitemmaster")
                If gdataset.Tables("inventoryitemmaster").Rows.Count > 0 Then

                    'TXT_FROMSTORECODE.Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("storecode"))
                    'sqlstring = " SELECT STOREDESC FROM STOREMASTER WHERE STORECODE = '" & Trim(TXT_FROMSTORECODE.Text) & "'"
                    'gconnection.getDataSet(sqlstring, "STOREMASTER")
                    'If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                    '    txt_FromStorename.Text = Trim(gdataset.Tables("STOREmaster").Rows(0).Item("storeDESC"))
                    'End If
                    Txt_NItemcode = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode"))
                    With SSGRID
                        .Row = .ActiveRow
                        .Col = 2
                        .Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemname"))
                        .Col = 3
                        .Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom") & "")
                        .Col = 4
                        .Text = Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("CATEGORY") & "")

                    End With
                     
                    GRNDATE = Format(CDate(Date.Now), "dd-MMM-yyyy")
                    'lbl_NQty.Text = ClosingQuantity_Date(Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode")), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom")), GRNDATE)
                    'lbl_NQty.Text = ClosingQuantity_bYpROC(Trim("'" + gdataset.Tables("inventoryitemmaster").Rows(0).Item("itemcode") + "'"), Trim(TXT_FROMSTORECODE.Text), Trim(gdataset.Tables("inventoryitemmaster").Rows(0).Item("stockuom")), GRNDATE)

                    gconnection.closingStock(Format(dtp_Docdate.Value, "dd/MMM/yyyy"), Txt_NItemcode, Trim(TXT_FROMSTORECODE.Text), "")

                    '   Dim closingqty, RATE As Double
                    If (gdataset.Tables("closingstock").Rows.Count > 0) Then
                        SSGRID.Row = SSGRID.ActiveRow
                        SSGRID.Col = 5
                        SSGRID.Text = gdataset.Tables("closingstock").Rows(0).Item("closingstock")

                    Else
                        SSGRID.Row = SSGRID.ActiveRow
                        SSGRID.Col = 5
                        SSGRID.Text = 0
                    End If

                    SSGRID.SetActiveCell(6, SSGRID.ActiveRow)
                Else
                    SSGRID.DeleteRows(SSGRID.ActiveRow, 1)
                    SSGRID.SetActiveCell(1, SSGRID.ActiveRow)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
End Class
