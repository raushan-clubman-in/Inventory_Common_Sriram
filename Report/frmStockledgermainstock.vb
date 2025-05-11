Imports System.Data.SqlClient
Imports System.io
Public Class frmStockledgermainstock
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
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Itemlist As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllItem As System.Windows.Forms.CheckBox
    Friend WithEvents Chklist_Itemdetails As System.Windows.Forms.CheckedListBox
    Friend WithEvents lbl_GroupList As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents Chklist_Groupdesc As System.Windows.Forms.CheckedListBox
    Friend WithEvents cbo_Storelocation As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Storelocation As System.Windows.Forms.Label
    Friend WithEvents CHK_ZEROQTY As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ssGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cmd_exp As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_todate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn_validation As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockledgermainstock))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.Cmd_exp = New System.Windows.Forms.Button()
        Me.btn_validation = New System.Windows.Forms.Button()
        Me.lbl_Itemlist = New System.Windows.Forms.Label()
        Me.Chk_SelectAllItem = New System.Windows.Forms.CheckBox()
        Me.Chklist_Itemdetails = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtp_todate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fromdate = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_GroupList = New System.Windows.Forms.Label()
        Me.Chk_SelectAllGroup = New System.Windows.Forms.CheckBox()
        Me.Chklist_Groupdesc = New System.Windows.Forms.CheckedListBox()
        Me.cbo_Storelocation = New System.Windows.Forms.ComboBox()
        Me.lbl_Storelocation = New System.Windows.Forms.Label()
        Me.CHK_ZEROQTY = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ssGrid = New AxFPSpreadADO.AxfpSpread()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.frmbut.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(184, 79)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(211, 18)
        Me.lbl_Heading.TabIndex = 96
        Me.lbl_Heading.Text = "MAIN STOCK LEDGER [ALL]"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.BackgroundImage = Global.Inventory.My.Resources.Resources.print
        Me.Cmd_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(6, 146)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_Print.TabIndex = 103
        Me.Cmd_Print.Text = " Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.BackgroundImage = Global.Inventory.My.Resources.Resources.view
        Me.Cmd_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(6, 86)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_View.TabIndex = 100
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.BackgroundImage = Global.Inventory.My.Resources.Resources._Exit
        Me.Cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(6, 270)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_Exit.TabIndex = 101
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.BackgroundImage = Global.Inventory.My.Resources.Resources.Clear
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(6, 27)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_Clear.TabIndex = 99
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.Cmd_View)
        Me.frmbut.Controls.Add(Me.Cmd_Clear)
        Me.frmbut.Controls.Add(Me.Cmd_exp)
        Me.frmbut.Controls.Add(Me.Cmd_Print)
        Me.frmbut.Controls.Add(Me.Cmd_Exit)
        Me.frmbut.Location = New System.Drawing.Point(854, 134)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(149, 352)
        Me.frmbut.TabIndex = 102
        Me.frmbut.TabStop = False
        '
        'Cmd_exp
        '
        Me.Cmd_exp.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_exp.BackgroundImage = Global.Inventory.My.Resources.Resources.excel
        Me.Cmd_exp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_exp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_exp.ForeColor = System.Drawing.Color.Black
        Me.Cmd_exp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_exp.Location = New System.Drawing.Point(6, 208)
        Me.Cmd_exp.Name = "Cmd_exp"
        Me.Cmd_exp.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_exp.TabIndex = 454
        Me.Cmd_exp.Text = "&EXPORT"
        Me.Cmd_exp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_exp.UseVisualStyleBackColor = False
        '
        'btn_validation
        '
        Me.btn_validation.BackColor = System.Drawing.Color.Transparent
        Me.btn_validation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_validation.ForeColor = System.Drawing.Color.Black
        Me.btn_validation.Location = New System.Drawing.Point(900, 683)
        Me.btn_validation.Name = "btn_validation"
        Me.btn_validation.Size = New System.Drawing.Size(104, 32)
        Me.btn_validation.TabIndex = 455
        Me.btn_validation.Text = "Validation"
        Me.btn_validation.UseVisualStyleBackColor = False
        Me.btn_validation.Visible = False
        '
        'lbl_Itemlist
        '
        Me.lbl_Itemlist.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Itemlist.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemlist.ForeColor = System.Drawing.Color.White
        Me.lbl_Itemlist.Location = New System.Drawing.Point(339, 46)
        Me.lbl_Itemlist.Name = "lbl_Itemlist"
        Me.lbl_Itemlist.Size = New System.Drawing.Size(301, 24)
        Me.lbl_Itemlist.TabIndex = 423
        Me.lbl_Itemlist.Text = "SELECT ITEMCODE :"
        '
        'Chk_SelectAllItem
        '
        Me.Chk_SelectAllItem.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllItem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllItem.Location = New System.Drawing.Point(348, 14)
        Me.Chk_SelectAllItem.Name = "Chk_SelectAllItem"
        Me.Chk_SelectAllItem.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllItem.TabIndex = 421
        Me.Chk_SelectAllItem.Text = "SELECT ALL"
        Me.Chk_SelectAllItem.UseVisualStyleBackColor = False
        '
        'Chklist_Itemdetails
        '
        Me.Chklist_Itemdetails.CheckOnClick = True
        Me.Chklist_Itemdetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_Itemdetails.Location = New System.Drawing.Point(339, 70)
        Me.Chklist_Itemdetails.Name = "Chklist_Itemdetails"
        Me.Chklist_Itemdetails.Size = New System.Drawing.Size(301, 372)
        Me.Chklist_Itemdetails.TabIndex = 422
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_todate)
        Me.GroupBox3.Controls.Add(Me.dtp_fromdate)
        Me.GroupBox3.Controls.Add(Me.PictureBox4)
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(187, 598)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(606, 48)
        Me.GroupBox3.TabIndex = 426
        Me.GroupBox3.TabStop = False
        '
        'dtp_todate
        '
        Me.dtp_todate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_todate.Location = New System.Drawing.Point(440, 19)
        Me.dtp_todate.Name = "dtp_todate"
        Me.dtp_todate.Size = New System.Drawing.Size(127, 20)
        Me.dtp_todate.TabIndex = 495
        '
        'dtp_fromdate
        '
        Me.dtp_fromdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fromdate.Location = New System.Drawing.Point(204, 19)
        Me.dtp_fromdate.Name = "dtp_fromdate"
        Me.dtp_fromdate.Size = New System.Drawing.Size(132, 20)
        Me.dtp_fromdate.TabIndex = 494
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(168, 12)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.TabIndex = 493
        Me.PictureBox4.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(403, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 492
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(335, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TO DATE :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(64, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "FROM DATE :"
        '
        'lbl_GroupList
        '
        Me.lbl_GroupList.BackColor = System.Drawing.Color.Maroon
        Me.lbl_GroupList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupList.ForeColor = System.Drawing.Color.White
        Me.lbl_GroupList.Location = New System.Drawing.Point(20, 46)
        Me.lbl_GroupList.Name = "lbl_GroupList"
        Me.lbl_GroupList.Size = New System.Drawing.Size(309, 24)
        Me.lbl_GroupList.TabIndex = 429
        Me.lbl_GroupList.Text = "SELECT GROUPCODE :"
        '
        'Chk_SelectAllGroup
        '
        Me.Chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllGroup.Location = New System.Drawing.Point(32, 12)
        Me.Chk_SelectAllGroup.Name = "Chk_SelectAllGroup"
        Me.Chk_SelectAllGroup.Size = New System.Drawing.Size(128, 27)
        Me.Chk_SelectAllGroup.TabIndex = 427
        Me.Chk_SelectAllGroup.Text = "SELECT ALL"
        Me.Chk_SelectAllGroup.UseVisualStyleBackColor = False
        '
        'Chklist_Groupdesc
        '
        Me.Chklist_Groupdesc.CheckOnClick = True
        Me.Chklist_Groupdesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_Groupdesc.Location = New System.Drawing.Point(20, 70)
        Me.Chklist_Groupdesc.Name = "Chklist_Groupdesc"
        Me.Chklist_Groupdesc.Size = New System.Drawing.Size(309, 372)
        Me.Chklist_Groupdesc.TabIndex = 428
        '
        'cbo_Storelocation
        '
        Me.cbo_Storelocation.BackColor = System.Drawing.Color.Wheat
        Me.cbo_Storelocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Storelocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Storelocation.ItemHeight = 15
        Me.cbo_Storelocation.Location = New System.Drawing.Point(120, 10)
        Me.cbo_Storelocation.Name = "cbo_Storelocation"
        Me.cbo_Storelocation.Size = New System.Drawing.Size(152, 23)
        Me.cbo_Storelocation.TabIndex = 431
        '
        'lbl_Storelocation
        '
        Me.lbl_Storelocation.AutoSize = True
        Me.lbl_Storelocation.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Storelocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Storelocation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Storelocation.Location = New System.Drawing.Point(17, 16)
        Me.lbl_Storelocation.Name = "lbl_Storelocation"
        Me.lbl_Storelocation.Size = New System.Drawing.Size(79, 15)
        Me.lbl_Storelocation.TabIndex = 432
        Me.lbl_Storelocation.Text = "STORE LOC :"
        '
        'CHK_ZEROQTY
        '
        Me.CHK_ZEROQTY.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ZEROQTY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_ZEROQTY.Location = New System.Drawing.Point(584, 688)
        Me.CHK_ZEROQTY.Name = "CHK_ZEROQTY"
        Me.CHK_ZEROQTY.Size = New System.Drawing.Size(144, 24)
        Me.CHK_ZEROQTY.TabIndex = 450
        Me.CHK_ZEROQTY.Text = "WITH ZERO QTY"
        Me.CHK_ZEROQTY.UseVisualStyleBackColor = False
        Me.CHK_ZEROQTY.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(536, 689)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 103
        Me.Button1.Text = " Print [F10]"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.ForestGreen
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(384, 689)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 100
        Me.Button2.Text = " View[F9]"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.ForestGreen
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(232, 689)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 32)
        Me.Button3.TabIndex = 99
        Me.Button3.Text = "Clear[F6]"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.ForestGreen
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(696, 689)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 32)
        Me.Button4.TabIndex = 101
        Me.Button4.Text = "Exit[F11]"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'ssGrid
        '
        Me.ssGrid.DataSource = Nothing
        Me.ssGrid.Location = New System.Drawing.Point(134, 310)
        Me.ssGrid.Name = "ssGrid"
        Me.ssGrid.OcxState = CType(resources.GetObject("ssGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssGrid.Size = New System.Drawing.Size(899, 405)
        Me.ssGrid.TabIndex = 453
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(274, 45)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.TabIndex = 472
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(596, 45)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.TabIndex = 473
        Me.PictureBox3.TabStop = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Maroon
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(298, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 24)
        Me.Label9.TabIndex = 475
        Me.Label9.Text = "F2"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(604, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 24)
        Me.Label2.TabIndex = 476
        Me.Label2.Text = "F3"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lbl_Storelocation)
        Me.GroupBox1.Controls.Add(Me.cbo_Storelocation)
        Me.GroupBox1.Location = New System.Drawing.Point(201, 552)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 40)
        Me.GroupBox1.TabIndex = 477
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.PictureBox3)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.lbl_GroupList)
        Me.GroupBox2.Controls.Add(Me.Chk_SelectAllGroup)
        Me.GroupBox2.Controls.Add(Me.Chklist_Groupdesc)
        Me.GroupBox2.Controls.Add(Me.lbl_Itemlist)
        Me.GroupBox2.Controls.Add(Me.Chk_SelectAllItem)
        Me.GroupBox2.Controls.Add(Me.Chklist_Itemdetails)
        Me.GroupBox2.Location = New System.Drawing.Point(187, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(640, 497)
        Me.GroupBox2.TabIndex = 478
        Me.GroupBox2.TabStop = False
        '
        'frmStockledgermainstock
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.ControlBox = False
        Me.Controls.Add(Me.ssGrid)
        Me.Controls.Add(Me.btn_validation)
        Me.Controls.Add(Me.CHK_ZEROQTY)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.KeyPreview = True
        Me.Name = "frmStockledgermainstock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORT [ STOCK LEDGERMAINSTOCK ]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.frmbut.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Public pagesize As Integer


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
                        If Controls(i_i).Name = "GroupBox3" Then
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

    Private Sub FillStore()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER  WHERE ISNULL(STORESTATUS,'')='M' ORDER BY STOREDESC ASC"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        cbo_Storelocation.Items.Clear()
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                cbo_Storelocation.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STOREDESC"))
            Next i
        End If
    End Sub
    Private Sub FillItemdetails()
        Dim i As Integer
        Dim sqlstring As String
        Chklist_Itemdetails.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER ORDER BY ITEMCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                    Chklist_Itemdetails.Items.Add(Trim(CStr(.Item("ITEMCODE"))) & "-->" & Trim(CStr(.Item("ITEMNAME"))))
                End With
            Next
        End If
    End Sub

    Private Sub FillGroupdetails()
        Dim i As Integer
        Dim sqlstring As String
        Chklist_Groupdesc.Items.Clear()
        sqlstring = "SELECT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPDESC,'') AS GROUPDESC FROM INVENTORYGROUPMASTER ORDER BY GROUPCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    Chklist_Groupdesc.Items.Add(Trim(CStr(.Item("GROUPDESC"))))
                End With
            Next
        End If
    End Sub
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        gPrint = False
        Call PRINTOPERATION()
    End Sub
    Private Sub PRINTOPERATION()
        Dim I As Integer
        Dim sqlstring, sqlstring1, Itemcode() As String
        Dim ZEROQTY As Boolean
        Dim Storecode As String
        Cmd_exp.Enabled = True
        Cmd_Print.Enabled = True
        ''''****************************** $ STOCK LEDGER MAIN STORE $ *************************************'''

        sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE STOREDESC='" & Trim(cbo_Storelocation.Text) & "'"
        gconnection.getDataSet(sqlstring, "STORECODE")
        If gdataset.Tables("STORECODE").Rows.Count > 0 Then
            Storecode = Trim(gdataset.Tables("STORECODE").Rows(0).Item("STORECODE"))
        Else
            Storecode = ""
        End If

        Dim SLSTRING As String
        SLSTRING = ""

        ' ADDED ON -26122009
        If Chklist_Itemdetails.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Item Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                SLSTRING = SLSTRING & "'" & Itemcode(0) & "', "
            Next
            SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)
        End If
        sqlstring = " update INVENTORYITEMMASTER SET selectOPT='N' WHERE ITEMCODE NOT IN(" & SLSTRING & ")"
        gconnection.getDataSet(sqlstring, "ITEMMASTER1")

        sqlstring = " update INVENTORYITEMMASTER SET selectOPT='Y' WHERE ITEMCODE IN(" & SLSTRING & ")"
        gconnection.getDataSet(sqlstring, "ITEMMASTER")

        sqlstring = "Select DISTINCT itemcode, itemname, groupname,  stockuom, storecode,isnull(valuation,'') as valuation  from inventoryitemmaster "
        If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " WHERE isnull(selectOPT,'')='Y' and GROUPname IN ("
            For I = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_Groupdesc.CheckedItems(I) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        Else
            MessageBox.Show("Select the Group Description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        gconnection.getDataSet(" SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(cbo_Storelocation.Text) & "'", "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
        End If
        Me.Cursor = Cursors.WaitCursor
        gconnection.openConnection()
        gcommand = New SqlCommand("CP_STOCKSUMMARY3", gconnection.Myconn)
        gcommand.CommandType = CommandType.StoredProcedure
        gcommand.CommandTimeout = 1000000000
        gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
        gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_fromdate.Value), "dd/MMM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy")
        'gcommand.Parameters.Add(New SqlParameter("@OPTQTY", SqlDbType.SmallInt)).Value = 0
        gcommand.ExecuteNonQuery()
        gconnection.closeConnection()
        Me.Cursor = Cursors.Default
        '--------------------------------------------------------------------------'
        '**************Procedure for getting Conv UOM'*********************************
        gconnection.openConnection()
        gcommand = New SqlCommand("InventoryTransUpdate", gconnection.Myconn)
        gcommand.CommandTimeout = 1000000000
        gcommand.CommandType = CommandType.StoredProcedure
        gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
        gcommand.ExecuteNonQuery()
        gconnection.closeConnection()
        '***********************************

        If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ITEMCODE IN ('TEST', "
            For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                ZEROQTY = True
                If CHK_ZEROQTY.Checked = False Then
                    sqlstring1 = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE, ISNULL(S.OPQTY,0.000) AS OPQTY, ISNULL(S.RCVQTY,0.000) AS RCVQTY, ISNULL(S.ISSQTY,0.000) AS ISSQTY FROM STOCKSUMMARY S WHERE ITEMCODE='" & Itemcode(0) & "'"
                    gconnection.getDataSet(sqlstring1, "STOCKSUMMARY")
                    If gdataset.Tables("STOCKSUMMARY").Rows.Count > 0 Then
                        If (Val(gdataset.Tables("STOCKSUMMARY").Rows(0).Item("OPQTY")) <= 0) And (Val(gdataset.Tables("STOCKSUMMARY").Rows(0).Item("RCVQTY")) <= 0) And (Val(gdataset.Tables("STOCKSUMMARY").Rows(0).Item("ISSQTY")) <= 0) Then
                            ZEROQTY = False
                        End If
                    End If
                End If
                If ZEROQTY = True Then
                    sqlstring = sqlstring & "'" & Itemcode(0) & "', "
                End If
                ZEROQTY = True
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ") AND STORECODE='" & Storecode & "' "
        Else
            MessageBox.Show("Select the Item Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        'If Trim(cbo_Storelocation.Text) = "" Then
        '    MessageBox.Show("Select the Store Location", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'sqlstring = sqlstring & "AND GRNDATE BETWEEN "
        'sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
        'sqlstring = sqlstring & " ORDER BY GROUPDESC,ITEMCODE,GRNdate,grndetails"
        sqlstring = sqlstring & " ORDER BY GROUPname,ITEMCODE"
        '-----
        'U
        Dim PageHeader() As String = {"STOCK LEGDER FOR [" & cbo_Storelocation.Text & "]"}
        'If MsgBox("Click Yes for Windows View or No for Text View", MsgBoxStyle.YesNo) = MsgBoxResult.No Then

        ' Call Stk_Ledger_Crystal()
        '  Me.Cursor = Cursors.WaitCursor
        ' Dim objStockLegermainstock As New rptStockledgermainstock
        ' objStockLegermainstock.ReportsDetails(sqlstring, PageHeader, dtp_Fromdate.Value, dtp_Todate.Value, Trim(cbo_Storelocation.Text & ""))
        ' Me.Cursor = Cursors.Default
        ' Else
        Me.Cursor = Cursors.WaitCursor
        ReportsDetails(sqlstring, PageHeader, dtp_Fromdate.Value, dtp_Todate.Value, Trim(cbo_Storelocation.Text & ""))
        Me.Cursor = Cursors.Default
        ' End If
        '-----
        '===========================================================================
        'sqlstring = sqlstring & " ORDER BY GROUPDESC,ITEMCODE,ADDDATE"
    End Sub
    Private Sub PRINTOPERATION_Direct()
        Dim I As Integer
        Dim sqlstring, sqlstring1, Itemcode() As String
        Dim ZEROQTY As Boolean
        Dim Storecode As String
        ''''****************************** $ STOCK LEDGER MAIN STORE $ *************************************'''
        'sqlstring = " SELECT * FROM VIEWSTOCKLEDGERMAINSTORE ORDER BY GROUPDESC,ITEMCODE,ITEMNAME,GRNDATE "
        'gconnection.getDataSet(sqlstring, "GRIDVIEW")
        'gridviewstatus = "Stockledgermainstore"
        'gIssueregister = True
        'Dim griddesign As New GridDesign
        'griddesign.FormBorderStyle = FormBorderStyle.FixedDialog
        'griddesign.MdiParent = MDIParentobj
        'Me.Close()
        'griddesign.Show()
        '****************************** $ STOCK LEDGER MAIN STORE $ *************************************'''
        'sqlstring = " SELECT * FROM VIEWSTOCKLEDGERMAINSTORE "
        'sqlstring = "SELECT GRNDATE,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,SUPPLIERCODE,SUPPLIERNAME,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC FROM VIEWSTOCKLEDGERMAINSTORE "

        sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE STOREDESC='" & Trim(cbo_Storelocation.Text) & "'"
        gconnection.getDataSet(sqlstring, "STORECODE")
        If gdataset.Tables("STORECODE").Rows.Count > 0 Then
            Storecode = Trim(gdataset.Tables("STORECODE").Rows(0).Item("STORECODE"))
        Else
            Storecode = ""
        End If

        Dim SLSTRING As String
        SLSTRING = ""

        'ADDED BY MANICK -26122009

        If Chklist_Itemdetails.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Item Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                SLSTRING = SLSTRING & "'" & Itemcode(0) & "', "
            Next
            SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)

        End If

        sqlstring = " update INVENTORYITEMMASTER SET selectOPT='N' WHERE ITEMCODE NOT IN(" & SLSTRING & ")"
        gconnection.getDataSet(sqlstring, "ITEMMASTER1")

        sqlstring = " update INVENTORYITEMMASTER SET selectOPT='Y' WHERE ITEMCODE IN(" & SLSTRING & ")"
        gconnection.getDataSet(sqlstring, "ITEMMASTER")

        sqlstring = "Select DISTINCT itemcode, itemname, groupname, isnull(valuation,'') as valuation, stockuom, storecode from inventoryitemmaster "
        If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " WHERE isnull(selectOPT,'')='Y' and GROUPname IN ("
            For I = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_Groupdesc.CheckedItems(I) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        Else
            MessageBox.Show("Select the Group Description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        gconnection.getDataSet(" SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(cbo_Storelocation.Text) & "'", "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
        End If
        Me.Cursor = Cursors.WaitCursor
        gconnection.openConnection()
        gcommand = New SqlCommand("CP_STOCKSUMMARY3", gconnection.Myconn)
        gcommand.CommandType = CommandType.StoredProcedure
        gcommand.CommandTimeout = 1000000000
        gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
        gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_fromdate.Value), "dd/MMM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy ")
        gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy ")
        gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy ")
        'gcommand.Parameters.Add(New SqlParameter("@OPTQTY", SqlDbType.SmallInt)).Value = 0
        gcommand.ExecuteNonQuery()
        gconnection.closeConnection()
        Me.Cursor = Cursors.Default
        '--------------------------------------------------------------------------'

        If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ITEMCODE IN ('TEST', "
            For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                ZEROQTY = True
                If CHK_ZEROQTY.Checked = False Then
                    '    gconnection.getDataSet("Select OPSTOCK from inventoryitemmaster where itemcode='" & Itemcode(0) & "'", "OpeningStock")
                    '    If gdataset.Tables("Openingstock").Rows.Count > 0 Then
                    '        If Val(gdataset.Tables("openingstock").Rows(0).Item("OPSTOCK")) = 0 Then
                    '            ZEROQTY = False
                    '        End If
                    '    End If
                    '    If ZEROQTY = False Then
                    '        gconnection.getDataSet("SELECT * FROM STOCKISSUEDETAIL WHERE itemcode='" & Itemcode(0) & "'", "ISSUE")
                    '        If gdataset.Tables("ISSUE").Rows.Count <= 0 Then
                    '            ZEROQTY = False
                    '        End If
                    '    End If
                    '    If ZEROQTY = False Then
                    '        gconnection.getDataSet("SELECT * FROM STOCKTRANSFERDETAIL WHERE itemcode='" & Itemcode(0) & "'", "TRANSFER")
                    '        If gdataset.Tables("TRANSFER").Rows.Count <= 0 Then
                    '            ZEROQTY = False
                    '        End If
                    '    End If
                    sqlstring1 = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE, ISNULL(S.OPQTY,0.000) AS OPQTY, ISNULL(S.RCVQTY,0.000) AS RCVQTY, ISNULL(S.ISSQTY,0.000) AS ISSQTY FROM STOCKSUMMARY S WHERE ITEMCODE='" & Itemcode(0) & "'"
                    gconnection.getDataSet(sqlstring1, "STOCKSUMMARY")
                    If gdataset.Tables("STOCKSUMMARY").Rows.Count > 0 Then
                        If (Val(gdataset.Tables("STOCKSUMMARY").Rows(0).Item("OPQTY")) <= 0) And (Val(gdataset.Tables("STOCKSUMMARY").Rows(0).Item("RCVQTY")) <= 0) And (Val(gdataset.Tables("STOCKSUMMARY").Rows(0).Item("ISSQTY")) <= 0) Then
                            ZEROQTY = False
                        End If
                    End If
                End If
                If ZEROQTY = True Then
                    sqlstring = sqlstring & "'" & Itemcode(0) & "', "
                End If
                ZEROQTY = True
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ") AND STORECODE='" & Storecode & "' "
        Else
            MessageBox.Show("Select the Item Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        'If Trim(cbo_Storelocation.Text) = "" Then
        '    MessageBox.Show("Select the Store Location", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'sqlstring = sqlstring & "AND GRNDATE BETWEEN "
        'sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
        'sqlstring = sqlstring & " ORDER BY GROUPDESC,ITEMCODE,GRNdate,grndetails"
        sqlstring = sqlstring & " ORDER BY GROUPname,ITEMCODE"
        '-----
        'U
        Dim PageHeader() As String = {"STOCK LEGDER FOR [" & cbo_Storelocation.Text & "]"}
        'If MsgBox("Click Yes for Windows View or No for Text View", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        Me.Cursor = Cursors.WaitCursor
        Dim objStockLegermainstock As New rptStockledgermainstock
        objStockLegermainstock.ReportsDetails(sqlstring, PageHeader, dtp_Fromdate.Value, dtp_Todate.Value, Trim(cbo_Storelocation.Text & ""))
        Me.Cursor = Cursors.Default

        '-----
        '===========================================================================
        'sqlstring = sqlstring & " ORDER BY GROUPDESC,ITEMCODE,ADDDATE"
    End Sub

    Private Sub Stk_Ledger_Crystal()

        Dim sqlstring, sqlstring1, Itemcode() As String
        Dim ZEROQTY As Boolean
        Dim Storecode As String
        Dim i As Integer
        Dim rViewer As New Viewer
        Dim r As New Rpt_stk_summary
        Dim Heading(0) As String
        Dim SSQL As String

        ''''****************************** $ STOCK LEDGER MAIN STORE $ *************************************'''
        'sqlstring = " SELECT * FROM VIEWSTOCKLEDGERMAINSTORE ORDER BY GROUPDESC,ITEMCODE,ITEMNAME,GRNDATE "
        'gconnection.getDataSet(sqlstring, "GRIDVIEW")
        'gridviewstatus = "Stockledgermainstore"
        'gIssueregister = True
        'Dim griddesign As New GridDesign
        'griddesign.FormBorderStyle = FormBorderStyle.FixedDialog
        'griddesign.MdiParent = MDIParentobj
        'Me.Close()
        'griddesign.Show()
        '****************************** $ STOCK LEDGER MAIN STORE $ *************************************'''
        'sqlstring = " SELECT * FROM VIEWSTOCKLEDGERMAINSTORE "
        'sqlstring = "SELECT GRNDATE,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,SUPPLIERCODE,SUPPLIERNAME,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC FROM VIEWSTOCKLEDGERMAINSTORE "

        sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE STOREDESC='" & Trim(cbo_Storelocation.Text) & "'"
        gconnection.getDataSet(sqlstring, "STORECODE")
        If gdataset.Tables("STORECODE").Rows.Count > 0 Then
            Storecode = Trim(gdataset.Tables("STORECODE").Rows(0).Item("STORECODE"))
        Else
            Storecode = ""
        End If

        Dim SLSTRING As String
        SLSTRING = ""
        For i = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
            Itemcode = Split(Chklist_Itemdetails.CheckedItems(i), "-->")
            SLSTRING = SLSTRING & "'" & Itemcode(0) & "', "
        Next
        SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)

        sqlstring = " update INVENTORYITEMMASTER SET selectOPT='N' WHERE ITEMCODE NOT IN(" & SLSTRING & ")"
        gconnection.getDataSet(sqlstring, "ITEMMASTER1")

        sqlstring = " update INVENTORYITEMMASTER SET selectOPT='Y' WHERE ITEMCODE IN(" & SLSTRING & ")"
        gconnection.getDataSet(sqlstring, "ITEMMASTER")

        sqlstring = "Select DISTINCT itemcode, itemname, groupname, isnull(valuation,'') as valuation, stockuom, storecode from inventoryitemmaster "
        If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " WHERE isnull(selectOPT,'')='Y' and GROUPname IN ("
            For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & Chklist_Groupdesc.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        Else
            MessageBox.Show("Select the Group Description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        gconnection.getDataSet(" SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(cbo_Storelocation.Text) & "'", "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
        End If
        gconnection.openConnection()
        gcommand = New SqlCommand("CP_STOCKSUMMARY2", gconnection.Myconn)
        gcommand.CommandType = CommandType.StoredProcedure
        gcommand.CommandTimeout = 1000000000
        gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
        gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_fromdate.Value), "dd/MM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
        'gcommand.Parameters.Add(New SqlParameter("@OPTQTY", SqlDbType.SmallInt)).Value = 0
        gcommand.ExecuteNonQuery()
        gconnection.closeConnection()
        '--------------------------------------------------------------------------'

        If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND ITEMCODE IN ('TEST', "
            For i = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                Itemcode = Split(Chklist_Itemdetails.CheckedItems(i), "-->")
                ZEROQTY = True
                If CHK_ZEROQTY.Checked = False Then
                    sqlstring1 = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE, ISNULL(S.OPQTY,0.000) AS OPQTY, ISNULL(S.RCVQTY,0.000) AS RCVQTY, ISNULL(S.ISSQTY,0.000) AS ISSQTY FROM STOCKSUMMARY S WHERE ITEMCODE='" & Itemcode(0) & "'"
                    gconnection.getDataSet(sqlstring1, "STOCKSUMMARY")
                    If gdataset.Tables("STOCKSUMMARY").Rows.Count > 0 Then
                        If (Val(gdataset.Tables("STOCKSUMMARY").Rows(0).Item("OPQTY")) <= 0) And (Val(gdataset.Tables("STOCKSUMMARY").Rows(0).Item("RCVQTY")) <= 0) And (Val(gdataset.Tables("STOCKSUMMARY").Rows(0).Item("ISSQTY")) <= 0) Then
                            ZEROQTY = False
                        End If
                    End If
                End If
                If ZEROQTY = True Then
                    sqlstring = sqlstring & "'" & Itemcode(0) & "', "
                End If
                ZEROQTY = True
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ") AND STORECODE='" & Storecode & "' "
        Else
            MessageBox.Show("Select the Item Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        sqlstring = sqlstring & " ORDER BY GROUPname,ITEMCODE"
        'Dim objStockLegermainstock As New rptStockledgermainstock
        'Dim PageHeader() As String = {"STOCK LEGDER FOR [" & cbo_Storelocation.Text & "]"}
        'objStockLegermainstock.ReportsDetails(sqlstring, PageHeader, dtp_Fromdate.Value, dtp_Todate.Value, Trim(cbo_Storelocation.Text & ""))


    End Sub
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub dtp_Fromdate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            dtp_Todate.Focus()
        End If
    End Sub

    Private Sub dtp_Todate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            Cmd_View.Focus()
        End If
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        gPrint = True
        Call PRINTOPERATION_Direct()
        ''Dim I As Integer
        ''Dim sqlstring, Itemcode() As String
        ''''''****************************** $ STOCK LEDGER MAIN STORE $ *************************************'''
        '''sqlstring = " SELECT * FROM VIEWSTOCKLEDGERMAINSTORE ORDER BY GROUPDESC,ITEMCODE,ITEMNAME,GRNDATE "
        '''gconnection.getDataSet(sqlstring, "GRIDVIEW")
        '''gridviewstatus = "Stockledgermainstore"
        '''gIssueregister = True
        '''Dim griddesign As New GridDesign
        '''griddesign.FormBorderStyle = FormBorderStyle.FixedDialog
        '''griddesign.MdiParent = MDIParentobj
        '''Me.Close()
        '''griddesign.Show()
        '''****************************** $ STOCK LEDGER MAIN STORE $ *************************************'''
        ''sqlstring = " SELECT * FROM VIEWSTOCKLEDGERMAINSTORE "
        ''If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
        ''    sqlstring = sqlstring & " WHERE GROUPDESC IN ("
        ''    For I = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        ''        sqlstring = sqlstring & " '" & Chklist_Groupdesc.CheckedItems(I) & "', "
        ''    Next
        ''    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        ''    sqlstring = sqlstring & ")"
        ''Else
        ''    MessageBox.Show("Select the location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        ''    Exit Sub
        ''End If
        ''If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
        ''    sqlstring = sqlstring & " AND ITEMCODE IN ("
        ''    For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
        ''        Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
        ''        sqlstring = sqlstring & "'" & Itemcode(0) & "', "
        ''    Next
        ''    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        ''    sqlstring = sqlstring & ")"
        ''Else
        ''    MessageBox.Show("Select the Server(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ''    Exit Sub
        ''End If
        ''sqlstring = sqlstring & "AND GRNDATE BETWEEN "
        ''sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
        ''sqlstring = sqlstring & " ORDER BY GROUPDESC,ITEMCODE,grndate,grndetails"
        ''Dim objStockLegermainstock As New rptStockledgermainstock
        ''Dim PageHeader() As String = {"STOCK LEGDER FOR [MAIN STORE]"}
        ''objStockLegermainstock.ReportsDetails(sqlstring, PageHeader, dtp_Fromdate.Value, dtp_Todate.Value)
        'Dim I As Integer
        'Dim sqlstring, Itemcode() As String
        '''''****************************** $ STOCK LEDGER MAIN STORE $ *************************************'''
        ''sqlstring = " SELECT * FROM VIEWSTOCKLEDGERMAINSTORE ORDER BY GROUPDESC,ITEMCODE,ITEMNAME,GRNDATE "
        ''gconnection.getDataSet(sqlstring, "GRIDVIEW")
        ''gridviewstatus = "Stockledgermainstore"
        ''gIssueregister = True
        ''Dim griddesign As New GridDesign
        ''griddesign.FormBorderStyle = FormBorderStyle.FixedDialog
        ''griddesign.MdiParent = MDIParentobj
        ''Me.Close()
        ''griddesign.Show()
        ''****************************** $ STOCK LEDGER MAIN STORE $ *************************************'''
        ''sqlstring = " SELECT * FROM VIEWSTOCKLEDGERMAINSTORE "
        ''sqlstring = "SELECT GRNDATE,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,SUPPLIERCODE,SUPPLIERNAME,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC FROM VIEWSTOCKLEDGERMAINSTORE "
        'sqlstring = "Select DISTINCT itemcode, itemname, groupname, valuation, stockuom from inventoryitemmaster "
        'If Chklist_Groupdesc.CheckedItems.Count <> 0 Then
        '    'sqlstring = sqlstring & " WHERE GROUPDESC IN ("
        '    sqlstring = sqlstring & " WHERE GROUPname IN ("
        '    For I = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        '        sqlstring = sqlstring & " '" & Chklist_Groupdesc.CheckedItems(I) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'Else
        '    MessageBox.Show("Select the Group Description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End If
        'If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " AND ITEMCODE IN ("
        '    For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
        '        Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
        '        sqlstring = sqlstring & "'" & Itemcode(0) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ") AND STORECODE='MNS'"
        'Else
        '    MessageBox.Show("Select the Item Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        ''If Trim(cbo_Storelocation.Text) = "" Then
        ''    MessageBox.Show("Select the Store Location", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ''    Exit Sub
        ''End If
        ''sqlstring = sqlstring & "AND GRNDATE BETWEEN "
        ''sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
        ''sqlstring = sqlstring & " ORDER BY GROUPDESC,ITEMCODE,GRNdate,grndetails"
        'sqlstring = sqlstring & " ORDER BY GROUPname,ITEMCODE"
        'Dim objStockLegermainstock As New rptStockledgermainstock
        'Dim PageHeader() As String = {"STOCK LEGDER FOR [MAIN STORE]"}
        'Dim STORECODE As String
        'Dim sqlstring1 = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(cbo_Storelocation.Text) & "'"
        'gconnection.getDataSet(sqlstring, "STOREMASTER")
        'If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
        '    STORECODE = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
        'End If
        'objStockLegermainstock.ReportsDetails(sqlstring, PageHeader, dtp_Fromdate.Value, dtp_Todate.Value, STORECODE)

        ''===========================================================================
        ''sqlstring = sqlstring & " ORDER BY GROUPDESC,ITEMCODE,ADDDATE"

    End Sub

    Private Sub frmStockledgermainstock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MsgBox("Please Run Weighted Average Under Administrator, if you are already executed then ignore  ...", MsgBoxStyle.OKOnly, "Info.")
        Resize_Form()
        Call FillStore()
        Chklist_Groupdesc.Items.Clear()
        Chklist_Itemdetails.Items.Clear()
        dtp_fromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        dtp_todate.Value = Format(Now, "dd/MMM/yyyy")
        Call FillGroupdetails()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Chklist_Itemdetails.Focus()
        ssGrid.Visible = False
        Cmd_exp.Enabled = False
        Cmd_Print.Enabled = False
    End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_View.Enabled = False
        Me.Cmd_Print.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_View.Enabled = True
                    Me.Cmd_Print.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.Cmd_Print.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call FillStore()
        dtp_fromdate.Value = Format(Now, "dd/MMM/yyyy")
        dtp_todate.Value = Format(Now, "dd/MMM/yyyy")
        Chklist_Groupdesc.Items.Clear()
        Chklist_Itemdetails.Items.Clear()
        Call FillGroupdetails()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Chklist_Itemdetails.Focus()
        'ssGrid.ClearRange(-1, 6, -1, -1, True)
        'ssGrid.ClearSelection()
        ssGrid.Visible = False
        Cmd_exp.Enabled = False
        Cmd_Print.Enabled = False
    End Sub

    Private Sub Chklist_Groupdesc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chklist_Groupdesc.DoubleClick
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' and I.GROUPNAME IN ("

        For J = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
            If J = Chklist_Groupdesc.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "', "
            End If
        Next
        If Chklist_Groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE"
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                Chklist_Itemdetails.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        Chklist_Itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        End If
    End Sub

    Private Sub Chklist_Groupdesc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chklist_Groupdesc.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' and I.GROUPNAME IN ("

        For J = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
            If J = Chklist_Groupdesc.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & Chklist_Groupdesc.CheckedItems(J) & "', "
            End If
        Next
        If Chklist_Groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE"
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                Chklist_Itemdetails.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        Chklist_Itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        Else
            Chklist_Itemdetails.Items.Clear()
        End If
    End Sub

    Private Sub Chk_SelectAllGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllGroup.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllGroup.Checked = True Then
            For i = 0 To Chklist_Groupdesc.Items.Count - 1
                Chklist_Groupdesc.SetItemChecked(i, True)
            Next
            Call Chklist_Groupdesc_SelectedIndexChanged(sender, e)
        Else
            For i = 0 To Chklist_Groupdesc.Items.Count - 1
                Chklist_Groupdesc.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub Chk_SelectAllItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllItem.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllItem.Checked = True Then
            For i = 0 To Chklist_Itemdetails.Items.Count - 1
                Chklist_Itemdetails.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To Chklist_Itemdetails.Items.Count - 1
                Chklist_Itemdetails.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Function ReportsDetails(ByVal SQLSTRING As String, ByVal pageheading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal STORENAME As String)
        Dim Groupdesc, Itemcode, grndetails, issuedetails, grndate, sqlstring1 As String
        Dim IssueValue, balQty, Opbal, rcvQty, issQty, totreceipt, totissue, opqty, oprate, opvalue, issrate, CLSVAL, opqty1, opvalue1, adjqty As Decimal
        Dim I, J As Integer
        Dim Itembool, calbool As Boolean
        Dim vref As Boolean = False
        Dim STORECODE, storestatus As String
        Dim SQLSTRING11 As String

        ssGrid.Visible = True
        ' Dim OBJstkLedger_Grid As New frmStkLedger_grid
        'OBJstkLedger_Grid.MdiParent = Me
        ssGrid.Show()
        ssGrid.ClearRange(-1, 6, -1, 6, True)
        For I = 6 To ssGrid.DataRowCnt
            For J = 6 To ssGrid.MaxCols
                ssGrid.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignRight
            Next
        Next

        Dim Tot_Value, Tot_Cls, Tot_Iss, Tot_Rec, Grnd_Cls, Grnd_Rec As Double
        Tot_Value = 0 : Tot_Cls = 0 : Tot_Iss = 0 : Tot_Rec = 0 : Grnd_Cls = 0 : Grnd_Rec = 0

        Try
            opqty = 0
            pagesize = 6

            SQLSTRING11 = "SELECT STORECODE,storestatus FROM STOREMASTER WHERE STOREDESC='" & Trim(STORENAME) & "'"
            gconnection.getDataSet(SQLSTRING11, "MAINSTORE")
            If gdataset.Tables("MAINSTORE").Rows.Count > 0 Then
                STORECODE = Trim(gdataset.Tables("MAINSTORE").Rows(0).Item("STORECODE"))
                storestatus = Trim(gdataset.Tables("MAINSTORE").Rows(0).Item("STORESTATUS"))
            Else
                STORECODE = ""
            End If
            gconnection.getDataSet(SQLSTRING, "VIEWSTOCKLEDGERREPORT")
            With ssGrid
                'If STORECODE = "MNS" Then
                .Col = 1
                .Row = 3
                .Text = "FROM  " & Format(mskfromdate, "dd-MM-yyyy") & "  TO  " & Format(msktodate, "dd-MM-yyyy")
                .RowsFrozen = 4
                If storestatus = "M" Then
                    For J = 0 To gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows.Count - 1
                        If Groupdesc <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname"))) Then
                            '.Row = pagesize
                            '.Col = 1
                            '.ForeColor = Color.Blue
                            '.Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname")
                            '.FontBold = True
                            'pagesize = pagesize + 1
                            '.Row = pagesize

                            Groupdesc = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("Groupname")))
                            vref = True
                        End If

                        If Itemcode <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE"))) Then
                            '-------------------------------------------------------------------------------------------
                            opqty = 0 : balQty = 0 : calbool = False : rcvQty = 0 : issQty = 0 : totreceipt = 0 : totissue = 0 : oprate = 0 : opvalue = 0
                            Itemcode = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")))
                            .Row = pagesize
                            .Col = 1
                            .FontBold = True
                            .ForeColor = Color.Maroon
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")

                            .Col = 3
                            .ForeColor = Color.Maroon
                            .FontBold = True
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMNAME")

                            .Col = 4
                            .ForeColor = Color.Maroon
                            .FontBold = True
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("STOCKUOM")

                            .Col = 5
                            .FontBold = True
                            .ForeColor = Color.Maroon
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("VALUATION")
                            pagesize = pagesize + 1
                            .Row = pagesize

                            '********************* Calculation of Opening Stock *****************************************************
                            sqlstring1 = "SELECT ISNULL(INVITMTRANSQTY,0) AS OPSTOCK,ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(INVITMTRANSVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(Itemcode) & "' AND STORECODE='" & STORECODE & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORYITEMMASTER")
                            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                                opqty = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                                oprate = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("PURCHASERATE")), "0.000")
                                opvalue1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPVALUE")), "0.00")
                                opqty1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                            End If
                            'SIVA--------------------------------- CALCULATION OF OPENING STOCK --------------------------------------------
                            sqlstring1 = "SELECT ISNULL(SUM(GRNTRANSQTY),0) AS TOTAL_GRN, ISNULL(SUM(GRNTRANSVALUE),0) AS GRN_VALUE FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOIDITEM,'') <> 'Y' AND GRNDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_OPENING_GRN_QUANTITY")
                            If gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows(0).Item("TOTAL_GRN")), "0.000")
                                opvalue1 = opvalue1 + Format(Val(gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows(0).Item("GRN_VALUE")), "0.00")
                                opqty1 = opqty1 + Format(Val(gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows(0).Item("TOTAL_GRN")), "0.000")
                            End If

                            sqlstring1 = "SELECT ISNULL(SUM(ISSTRANSQTY),0) AS TOTAL_ISSUE, ISNULL(SUM(ISSTRANSVALUE),0) AS ISS_VALUE FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_ISSUE_QUANTITY")
                            If gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty - Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("TOTAL_ISSUE")), "0.000")
                                'opvalue = opvalue - Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("ISS_VALUE")), "0.000")
                            End If

                            'sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_RETURN, ISNULL(SUM(AMOUNT),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND TOSTORECODE LIKE 'M%' "
                            sqlstring1 = "SELECT ISNULL(SUM(TRFTRANSQTY),0) AS TOTAL_RETURN, ISNULL(SUM(TRFTRANSVALUE),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND TOSTORECODE LIKE 'M%'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_RETURN_QUANTITY")
                            If gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("TOTAL_RETURN")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("RET_VAL")), "0.000")
                            End If

                            sqlstring1 = "SELECT ISNULL(SUM(ADJTRANSQTY),0) AS TOTAL_ADJUST, ISNULL(SUM(ADJTRANSVALUE),0) ADJUSTED_VALUE FROM STOCKADJUSTDETAILS WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND STORELOCATIONCODE LIKE 'M%' "
                            gconnection.getDataSet(sqlstring1, "INVENTORY_ADJUSTED_QUANTITY")
                            If gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("TOTAL_ADJUST")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("ADJUSTED_VALUE")), "0.000")
                            End If

                            sqlstring1 = "select ISNULL(OPRATE,0) AS OPRATE from stocksummary where itemcode='" & Trim(Itemcode) & "'"
                            gconnection.getDataSet(sqlstring1, "Rate1")
                            If gdataset.Tables("rate1").Rows.Count > 0 Then
                                oprate = Val(gdataset.Tables("rate1").Rows(0).Item("oprate"))
                            Else
                                sqlstring1 = "select count(*) as count from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                                gconnection.getDataSet(sqlstring1, "Rate")
                                If Val(gdataset.Tables("rate").Rows(0).Item("count")) > 0 Then
                                    sqlstring1 = "select TOP 1 isnull(rate,0) rate from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and isnull(void,'') <> 'y' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' order by docdate desc"
                                    gconnection.getDataSet(sqlstring1, "CurrentRate")
                                    oprate = Val(gdataset.Tables("currentrate").Rows(0).Item("rate"))
                                Else
                                    If opqty1 > 0 Then
                                        oprate = opvalue1 / opqty1
                                    Else
                                        sqlstring1 = "select top 1 isnull(purchaserate,0) rate from inventoryitemmaster where itemcode='" & Trim(Itemcode) & "' AND STORECODE LIKE '" & STORECODE & "'"
                                        gconnection.getDataSet(sqlstring1, "OpeningRate")
                                        If gdataset.Tables("OpeningRate").Rows.Count > 0 Then
                                            oprate = Val(gdataset.Tables("OpeningRate").Rows(0).Item("rate"))
                                        Else
                                            oprate = 0
                                        End If
                                    End If
                                End If
                            End If
                            opvalue = oprate * opqty
                            .Row = pagesize
                            .Col = 1
                            .Text = Format(mskfromdate, "dd/MMM/yyyy")

                            .Col = 2
                            .Text = " ********** OPENING STOCK ********** "
                            .FontBold = True
                            .AllowCellOverflow = True

                            .Col = 6
                            .FontBold = True
                            .Text = Format(Val(oprate), "0.00")
                            .FontBold = True

                            .Col = 7
                            .FontBold = True
                            .Text = Format(Val(opvalue), "0.00")
                            .FontBold = True

                            .Col = 10
                            .FontBold = True
                            .Text = Format(Val(opqty), "0.00")
                            .FontBold = True
                            pagesize = pagesize + 1

                            '********************************************************************************************************
                            '-------------------------------------------------------------------------------------------
                            'sqlstring1 = "SELECT * FROM  VIEWSTOCKLEDGERMAINSTORE WHERE ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"

                            sqlstring1 = "SELECT INDENTNO , GRNDATE,GRNDETAILS AS GRNDETAILS,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,SUPPLIERCODE,SUPPLIERNAME,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC,OPSTORELOCATIONNAME FROM VIEWSTOCKLEDGERMAINSTORE "
                            sqlstring1 = sqlstring1 & " WHERE ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"
                            sqlstring1 = sqlstring1 & " AND GRNDATE BETWEEN "
                            sqlstring1 = sqlstring1 & " '" & Format(mskfromdate, "dd/MMM/yyyy") & "' AND ' " & Format(msktodate, "dd/MMM/yyyy") & "' ORDER BY ITEMCODE,GRNDATE,GRNDETAILS"
                            gconnection.getDataSet(sqlstring1, "VIEWSTOCKLEDGERMAINSTORE1")
                            If gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows.Count > 0 Then
                                For I = 0 To gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows.Count - 1
                                    If Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 1, 1) = "A" Or Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 1, 1) = "C" Or Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 1, 1) = "D" Then
                                        rcvQty = 0 : issQty = 0
                                        .Row = pagesize
                                        .Col = 1
                                        .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")

                                        .Col = 3
                                        .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS1")

                                        .Col = 4
                                        .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("SUPPLIERNAME")

                                        .Col = 6
                                        .Text = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")), "0.00")

                                        .Col = 8
                                        .Text = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.00")
                                        .Row = pagesize

                                        rcvQty = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")
                                        totreceipt = totreceipt + Val(rcvQty)
                                        If calbool = False Then
                                            balQty = opqty + rcvQty - issQty
                                            calbool = True
                                        Else
                                            balQty = balQty + rcvQty - issQty
                                        End If
                                        .Col = 10
                                        .Text = Format(Val(balQty), "0.000")
                                        pagesize = pagesize + 1
                                        grndate = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("Grndate")), "dd/MMM/yyyy")
                                    Else
                                        If Mid(CStr(gdataset.Tables("viewstockledgermainstore1").Rows(I).Item("grndetails1")), 1, 3) <> "adj" Then
                                            rcvQty = 0 : issQty = 0 : adjqty = 0
                                            .Row = pagesize
                                            .Col = 1
                                            .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")

                                            .Col = 2
                                            .Text = "ISSUE"

                                            .Col = 3
                                            .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS1") & Space(10) & gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("INDENTNO")

                                            .Col = 4
                                            .AllowCellOverflow = True
                                            .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("OPSTORELOCATIONNAME")

                                            .Col = 6
                                            .Text = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")), "0.00")

                                            issrate = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE"))
                                            IssueValue = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY"))
                                            .Col = 7
                                            .Text = Format(Val(IssueValue), "0.00")

                                            .Col = 9
                                            .Text = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")

                                            issQty = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")
                                            totissue = totissue + issQty
                                            If calbool = False Then
                                                balQty = opqty + rcvQty - issQty + adjqty
                                                calbool = True
                                            Else
                                                balQty = balQty + rcvQty - issQty + adjqty
                                            End If
                                            .Col = 10
                                            .Text = Format(Val(balQty), "0.000")
                                            pagesize = pagesize + 1
                                            .Row = pagesize
                                            grndate = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")
                                        Else
                                            rcvQty = 0 : issQty = 0 : adjqty = 0
                                            .Row = pagesize
                                            .Col = 1
                                            .Text = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")

                                            .Col = 2
                                            .Text = "ADJUST"

                                            Filewrite.Write("{0,-20}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 4, 20))
                                            .Col = 3
                                            .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")

                                            'issrate = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE"))
                                            'IssueValue = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY"))
                                            adjqty = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")
                                            .Col = 8
                                            .Text = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")

                                            'totissue = totissue + issQty
                                            If calbool = False Then
                                                balQty = opqty + rcvQty - issQty + adjqty
                                                calbool = True
                                            Else
                                                balQty = balQty + rcvQty - issQty + adjqty
                                            End If

                                            .Col = 10
                                            .Text = Format(Val(balQty), "0.000")
                                            pagesize = pagesize + 1
                                            grndate = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")
                                        End If
                                    End If
                                    'If pagesize > 56 Then
                                    '    Filewrite.Write(StrDup(137, "-"))
                                    '    Filewrite.Write(Chr(12))
                                    '    'pageno = pageno + 1
                                    '    pagesize = pagesize + 1
                                    '    Call PrintHeader(pageheading, mskfromdate, msktodate)
                                    'End If
                                Next I
                                IssueValue = Val(issrate) * Val(balQty)
                            End If
                            '-------------------------------------------------------------------------------------------
                            If calbool = False Then
                                balQty = opqty
                                IssueValue = opvalue
                                issrate = oprate
                            End If

                            .Row = pagesize
                            .Col = 1
                            .Text = Format(CDate(msktodate), "dd/MMM/yyyy")

                            .Col = 2
                            .Text = " ********** CLOSING BALANCE ********** "
                            .FontBold = True
                            .AllowCellOverflow = True


                            .Col = 6
                            .FontBold = True
                            .Text = Format(Val(issrate), "0.00")

                            .Col = 7
                            .FontBold = True
                            .Text = Format(Val(IssueValue), "0.00")

                            .Col = 10
                            .FontBold = True
                            .Text = Format(Val(balQty), "0.000")
                            pagesize = pagesize + 1

                            .Row = pagesize
                            .Col = 5
                            .FontBold = True
                            .Text = "RECEIPT:"

                            .Col = 8
                            .FontBold = True
                            .Text = Format(Val(totreceipt), "0.000")

                            pagesize = pagesize + 1
                            .Row = pagesize
                            .Col = 5
                            .FontBold = True
                            .Text = "ISSUES  :"

                            .Col = 9
                            .FontBold = True
                            .Text = Format(Val(totissue), "0.000")
                            pagesize = pagesize + 1


                            .Row = pagesize
                            .Col = 1
                            .Text = "---------------------------------------"
                            .Row = pagesize
                            .Col = 2
                            .Text = "-------------------------------------"

                            .Row = pagesize
                            .Col = 3
                            .Text = "------------------------------------------------------------"

                            .Row = pagesize
                            .Col = 4
                            .Text = "-----------------------------------------"

                            .Row = pagesize
                            .Col = 5
                            .Text = "-------------------------------------------"

                            .Row = pagesize
                            .Col = 6
                            .Text = "---------------------------------------------"

                            .Row = pagesize
                            .Col = 7
                            .Text = "----------------------------------------------"

                            .Row = pagesize
                            .Col = 8
                            .Text = "-----------------------------------------------"

                            .Row = pagesize
                            .Col = 9
                            .Text = "--------------------"

                            .Row = pagesize
                            .Col = 10
                            .Text = "--------------------"

                            pagesize = pagesize + 1

                            Tot_Cls = Tot_Cls + Val(balQty)
                            Tot_Value = Tot_Value + Val(IssueValue)
                            Tot_Rec = Tot_Rec + Val(totreceipt)
                            Tot_Iss = Tot_Iss + Val(totissue)


                            '--------------------------------------------------------------------------------------------
                        End If
                        '    If pagesize > 58 Then
                        '        'Filewrite.Write(StrDup(137, "-"))
                        '        'Filewrite.Write(Chr(12))
                        '        ''pageno = pageno + 1
                        '        'pagesize = pagesize + 1
                        '        '.Row = pagesize
                        '        Call PrintHeader(pageheading, mskfromdate, msktodate)
                        '    End If
                    Next
                Else
                    For J = 0 To gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows.Count - 1
                        'If Groupdesc <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPDESC"))) Then
                        If Groupdesc <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname"))) Then
                            'Filewrite.WriteLine("{0,-30}", Mid("[" & Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPDESC"))) & "]", 1, 30))
                            .Row = pagesize
                            .Col = 1
                            .FontBold = True
                            .ForeColor = Color.Blue
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname")
                            pagesize = pagesize + 1

                            'Filewrite.WriteLine(StrDup(Len(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPDESC")) + 2, "-"))
                            'Groupdesc = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("Groupdesc")))
                            Groupdesc = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("Groupname")))
                            vref = True
                        End If
                        If Itemcode <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE"))) Then
                            '-------------------------------------------------------------------------------------------
                            opqty = 0 : balQty = 0 : calbool = False : rcvQty = 0 : issQty = 0 : totreceipt = 0 : totissue = 0 : oprate = 0 : opvalue = 0
                            Itemcode = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")))
                            .Row = pagesize
                            .Col = 1
                            .FontBold = True
                            .ForeColor = Color.Blue
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")

                            .Col = 3
                            .FontBold = True
                            .ForeColor = Color.Blue
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMNAME")

                            .Col = 4
                            .FontBold = True
                            .ForeColor = Color.Blue
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("STOCKUOM")

                            .Col = 5
                            .FontBold = True
                            .ForeColor = Color.Blue
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("VALUATION")
                            pagesize = pagesize + 1

                            '********************* Calculation of Opening Stock *****************************************************
                            sqlstring1 = "SELECT ISNULL(invitmtransqty,0) AS OPSTOCK,ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(INVITMTRANSVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(Itemcode) & "' AND STORECODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORYITEMMASTER")
                            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                                opqty = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                                oprate = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("PURCHASERATE")), "0.000")
                                opvalue1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPVALUE")), "0.00")
                                opqty1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                            End If
                            'SIVA--------------------------------- CALCULATION OF OPENING STOCK --------------------------------------------

                            sqlstring1 = "SELECT ISNULL(SUM(ISSTRANSQTY),0) AS TOTAL_ISSUE, ISNULL(SUM(ISSTRANSVALUE),0) AS ISS_VALUE FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND OPSTORELOCATIONCODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_ISSUE_QUANTITY")
                            If gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("TOTAL_ISSUE")), "0.000")
                                'opvalue = opvalue - Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("ISS_VALUE")), "0.000")
                            End If
                            sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_RETURN, ISNULL(SUM(AMOUNT),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND FROMSTORECODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_RETURN_QUANTITY")
                            If gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty - Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("TOTAL_RETURN")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("RET_VAL")), "0.000")
                            End If
                            sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_RETURN, ISNULL(SUM(AMOUNT),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND TOSTORECODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_RETURN_QUANTITY1")
                            If gdataset.Tables("INVENTORY_RETURN_QUANTITY1").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY1").Rows(0).Item("TOTAL_RETURN")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("RET_VAL")), "0.000")
                            End If

                            sqlstring1 = "SELECT ISNULL(SUM(ADJTRANSQTY),0) AS TOTAL_ADJUST, ISNULL(SUM(ADJTRANSVALUE),0) ADJUSTED_VALUE FROM STOCKADJUSTDETAILS WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND STORELOCATIONCODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_ADJUSTED_QUANTITY")
                            If gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("TOTAL_ADJUST")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("ADJUSTED_VALUE")), "0.000")
                            End If

                            sqlstring1 = "SELECT ISNULL(SUM(SSCTRANSQTY),0) AS TOTAL_SUB, ISNULL(SUM(SSCTRANSVALUE),0) SUB_VALUE FROM SUBSTORECONSUMPTIONDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND STORELOCATIONCODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "SUBSTORE")
                            If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                opqty = opqty - Format(Val(gdataset.Tables("SUBSTORE").Rows(0).Item("TOTAL_SUB")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("ADJUSTED_VALUE")), "0.000")
                            End If

                            sqlstring1 = "select ISNULL(OPRATE,0) AS OPRATE from stocksummary where itemcode='" & Trim(Itemcode) & "'"
                            gconnection.getDataSet(sqlstring1, "Rate1")
                            If gdataset.Tables("rate1").Rows.Count > 0 Then
                                oprate = Val(gdataset.Tables("rate1").Rows(0).Item("oprate"))
                            Else
                                sqlstring1 = "select count(*) as count from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                                gconnection.getDataSet(sqlstring1, "Rate")
                                If Val(gdataset.Tables("rate").Rows(0).Item("count")) > 0 Then
                                    sqlstring1 = "select TOP 1 isnull(rate,0) rate from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and isnull(void,'') <> 'y' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' order by docdate desc"
                                    gconnection.getDataSet(sqlstring1, "CurrentRate")
                                    oprate = Val(gdataset.Tables("currentrate").Rows(0).Item("rate"))
                                Else
                                    If opqty1 > 0 Then
                                        oprate = opvalue1 / opqty1
                                    Else
                                        sqlstring1 = "select TOP 1 isnull(purchaserate,0) rate from inventoryitemmaster where itemcode='" & Trim(Itemcode) & "' AND STORECODE LIKE '" & STORECODE & "'"
                                        gconnection.getDataSet(sqlstring1, "OpeningRate")
                                        If gdataset.Tables("OpeningRate").Rows.Count > 0 Then
                                            oprate = Val(gdataset.Tables("OpeningRate").Rows(0).Item("rate"))
                                        Else
                                            oprate = 0
                                        End If
                                    End If
                                End If
                            End If
                            opvalue = oprate * opqty
                            '   Filewrite.WriteLine("{0,-18}{1,-40}{2,-17}{3,10}{4,11}{5,26}{6,13}", Format(mskfromdate, "dd/MM/yyyy"), "********* OPENING BALANCE ***********", "", Mid(Format(Val(oprate), "0.00"), 1, 10), Mid(Format(Val(opvalue), "0.00"), 1, 11), "", Mid(Format(Val(opqty), "0.000"), 1, 13))

                            .Row = pagesize
                            .Col = 1
                            .Text = Format(mskfromdate, "dd/MMM/yyyy")

                            .Col = 2
                            .Text = " ********** OPENING STOCK ********** "
                            .FontBold = True
                            .AllowCellOverflow = True

                            .Col = 6
                            .FontBold = True
                            .Text = Format(Val(oprate), "0.00")
                            .FontBold = True

                            .Col = 7
                            .FontBold = True
                            .Text = Format(Val(opvalue), "0.00")
                            .FontBold = True

                            .Col = 10
                            .FontBold = True
                            .Text = Format(Val(opqty), "0.00")
                            .FontBold = True
                            pagesize = pagesize + 1

                            '********************************************************************************************************
                            '-------------------------------------------------------------------------------------------
                            'sqlstring1 = "SELECT * FROM  VIEWSTOCKLEDGERMAINSTORE WHERE ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"
                            'sqlstring1 = "SELECT GRNDATE,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC FROM VIEWSTOCKLEDGERSUBSTORE "
                            sqlstring1 = "SELECT GRNDATE,GRNDETAILS AS GRNDETAILS,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC FROM VIEWSTOCKLEDGERSUBSTORE "
                            sqlstring1 = sqlstring1 & " WHERE STORECODE='" & STORECODE & "' AND ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"
                            sqlstring1 = sqlstring1 & " AND GRNDATE BETWEEN "
                            sqlstring1 = sqlstring1 & " '" & Format(mskfromdate, "dd/MMM/yyyy") & "' AND '" & Format(msktodate, "dd/MMM/yyyy") & "' ORDER BY ITEMCODE,GRNDATE,GRNDETAILS"
                            gconnection.getDataSet(sqlstring1, "SUBSTOREVIEW")
                            If gdataset.Tables("SUBSTOREVIEW").Rows.Count > 0 Then
                                For I = 0 To gdataset.Tables("SUBSTOREVIEW").Rows.Count - 1
                                    If Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS")), 1, 1) = "B" Or Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS")), 1, 1) = "A" Or Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS")), 1, 1) = "D" Then
                                        rcvQty = 0 : issQty = 0 : adjqty = 0
                                        .Row = pagesize
                                        .Col = 1
                                        .Text = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")

                                        .Col = 2
                                        .Text = "RECEIVE"

                                        .Col = 3
                                        .Text = gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS1")

                                        .Col = 6
                                        .Text = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")), "0.00")

                                        issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                        IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))

                                        .Col = 7
                                        .Text = Format(Val(IssueValue), "0.00")

                                        .Col = 8
                                        .Text = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.00")

                                        rcvQty = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000")
                                        totreceipt = totreceipt + Val(rcvQty)
                                        If calbool = False Then
                                            balQty = opqty + rcvQty - issQty + adjqty
                                            calbool = True
                                        Else
                                            balQty = balQty + rcvQty - issQty + adjqty
                                        End If

                                        .Col = 10
                                        .Text = Format(Val(balQty), "0.000")
                                        pagesize = pagesize + 1
                                        grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("Grndate")), "dd/MMM/yyyy")
                                    Else
                                        If Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("grndetails1")), 1, 3) <> "adj" Then
                                            rcvQty = 0 : issQty = 0 : adjqty = 0
                                            .Row = pagesize
                                            .Col = 1
                                            .Text = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")

                                            .Col = 2
                                            .Text = "ISSUE"

                                            .Col = 3
                                            .Text = gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS1")

                                            .Col = 6
                                            .Text = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")), "0.00")

                                            issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                            IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))
                                            .Col = 7
                                            .Text = Format(Val(IssueValue), "0.00")

                                            .Col = 9
                                            .Text = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.00")

                                            issQty = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000")
                                            totissue = totissue + Val(issQty)
                                            If calbool = False Then
                                                balQty = opqty + rcvQty - issQty + adjqty
                                                calbool = True
                                            Else
                                                balQty = balQty + rcvQty - issQty + adjqty
                                            End If
                                            .Col = 10
                                            .Text = Format(Val(balQty), "0.000")
                                            pagesize = pagesize + 1
                                            grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")
                                        Else
                                            rcvQty = 0 : issQty = 0 : adjqty = 0
                                            .Row = pagesize
                                            .Col = 1
                                            .Text = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")

                                            .Col = 2
                                            .Text = "ADJUST"

                                            .Col = 3
                                            .Text = gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS1")

                                            'issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                            'IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))
                                            .Col = 9
                                            .Text = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.00")

                                            adjqty = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000")
                                            totissue = totissue + issQty - adjqty
                                            If calbool = False Then
                                                balQty = opqty + rcvQty - issQty + adjqty
                                                calbool = True
                                            Else
                                                balQty = balQty + rcvQty - issQty + adjqty
                                            End If
                                            .Col = 10
                                            .Text = Format(Val(balQty), "0.000")
                                            pagesize = pagesize + 1
                                            grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")

                                        End If
                                    End If
                                    'If pagesize > 56 Then
                                    'Filewrite.Write(StrDup(137, "-"))
                                    'Filewrite.Write(Chr(12))
                                    ''pageno = pageno + 1
                                    'pagesize = pagesize + 1
                                    'Call PrintHeader(pageheading, mskfromdate, msktodate)
                                    'End If
                                Next I
                                IssueValue = Val(issrate) * Val(balQty)
                                gconnection.getDataSet("SELECT ISNULL(SUM(QTY),0) AS QTY FROM SUBSTORECONSUMPTIONDETAIL WHERE STORELOCATIONCODE='" & STORECODE & "' AND ITEMCODE='" & Itemcode & "' AND ISNULL(VOID,'') <> 'Y'  AND DOCDATE BETWEEN '" & Format(mskfromdate, "dd MMM yyyy") & "' AND '" & Format(msktodate, "dd MMM yyyy") & "'", "SALES")
                                If gdataset.Tables("SALES").Rows.Count > 0 Then
                                    rcvQty = 0 : issQty = 0 : adjqty = 0
                                    .Row = pagesize
                                    .Col = 2
                                    .Text = "SALES"

                                    'issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                    'IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))
                                    .Col = 9
                                    .Text = Format(Val(gdataset.Tables("SALES").Rows(0).Item("QTY")), "0.000")

                                    issQty = Format(Val(gdataset.Tables("SALES").Rows(0).Item("QTY")), "0.000")
                                    totissue = totissue + issQty
                                    If calbool = False Then
                                        balQty = opqty + rcvQty - issQty + adjqty
                                        calbool = True
                                    Else
                                        balQty = balQty + rcvQty - issQty + adjqty
                                    End If
                                    .Col = 10
                                    .Text = Format(Val(balQty), "0.000")
                                    pagesize = pagesize + 1
                                    'grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MM/yyyy")
                                End If
                                '-------------------------------------------------------------------------------------------

                                '--------------------------------------------------------------------------------------------
                            End If
                            If calbool = False Then
                                balQty = opqty
                                IssueValue = opvalue
                                issrate = oprate
                            End If
                            '  Filewrite.WriteLine("{0,-18}{1,-40}{2,-17}{3,10}{4,11}{5,13}{6,13}{7,13}", Format(CDate(msktodate), "dd/MM/yyyy"), "********* CLOSING BALANCE ***********", "", Mid(Format(Val(issrate), "0.00"), 1, 10), Mid(Format(Val(IssueValue), "0.00"), 1, 11), "", Mid(Format(Val(balQty), "0.000"), 1, 13), Mid(Format(Val(balQty) * Val(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("CONVVALUE")), "0"), 1, 13))
                            .Row = pagesize
                            .Col = 1
                            .Text = Format(CDate(msktodate), "dd/MMM/yyyy")

                            .Col = 2
                            .ForeColor = Color.Red
                            .Text = " ********* CLOSING BALANCE ********* "
                            .FontBold = True
                            .AllowCellOverflow = True

                            .Col = 6
                            .ForeColor = Color.Red
                            .FontBold = True
                            .Text = Format(Val(issrate), "0.00")

                            .Col = 7
                            .ForeColor = Color.Red
                            .FontBold = True
                            .Text = Format(Val(IssueValue), "0.00")

                            .Col = 10
                            .ForeColor = Color.Red
                            .FontBold = True
                            .Text = Format(Val(balQty), "0.000")
                            pagesize = pagesize + 1

                            .Row = pagesize
                            .Col = 5
                            .ForeColor = Color.Red
                            .FontBold = True
                            .Text = "RECEIPT:"

                            .Col = 8
                            .ForeColor = Color.Red
                            .FontBold = True
                            .Text = Format(Val(totreceipt), "0.000")

                            pagesize = pagesize + 1
                            .Row = pagesize
                            .Col = 5
                            .ForeColor = Color.Red
                            .FontBold = True
                            .Text = "ISSUES  :"

                            .Col = 9
                            .ForeColor = Color.Red
                            .FontBold = True
                            .Text = Format(Val(totissue), "0.000")
                            pagesize = pagesize + 1


                            


                            Tot_Cls = Tot_Cls + Val(balQty)
                            Tot_Value = Tot_Value + Val(IssueValue)
                            Tot_Rec = Tot_Rec + Val(totreceipt)
                            Tot_Iss = Tot_Iss + Val(totissue)
                        End If
  
                    Next
                End If
                'gconnection.getDataSet("SELECT ISNULL(SUM(ISNULL(CLSVAL,0)),0) AS CLSVAL,ISNULL(SUM(ISNULL(RCVQTY,0)),0) AS RCVQTY,ISNULL(SUM(ISNULL(ISSQTY,0)),0) AS ISSQTY,ISNULL(SUM(ISNULL(CLSQTY,0)),0) AS CLSQTY FROM STOCKSUMMARY ", "SALES")
                pagesize = pagesize + 1
                .Row = pagesize
                .Col = 3
                .AllowCellOverflow = True
                .FontBold = True
                .ForeColor = Color.Red
                .Text = "********* GRAND TOTAL *********"

                .Col = 7
                .FontBold = True
                .ForeColor = Color.Red
                .Text = Format(Val(Tot_Value), "0.00")

                .Col = 8
                .FontBold = True
                .ForeColor = Color.Red
                .Text = Format(Val(Tot_Rec), "0.000")

                .Col = 9
                .FontBold = True
                .ForeColor = Color.Red
                .Text = Format(Val(Tot_Iss), "0.000")

                .Col = 10
                .FontBold = True
                .ForeColor = Color.Red
                .Text = Format(Val(Tot_Cls), "0.000")

                

            End With
            'Filewrite.WriteLine(StrDup(137, "-"))
            'pagesize = pagesize + 1
            'Filewrite.Write(Chr(12))
            'Filewrite.Close()
            'If gPrint = False Then
            '    OpenTextFile(vOutfile)
            'Else
            '    PrintTextFile(VFilePath)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Function
        End Try
    End Function

    Private Function ReportsDetails1234(ByVal SQLSTRING As String, ByVal pageheading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal STORENAME As String)
        Dim Groupdesc, Itemcode, grndetails, issuedetails, grndate, sqlstring1 As String
        Dim IssueValue, balQty, Opbal, rcvQty, issQty, totreceipt, totissue, opqty, oprate, opvalue, issrate, CLSVAL, opqty1, opvalue1, adjqty As Decimal
        Dim I, J As Integer
        Dim Itembool, calbool As Boolean
        Dim vref As Boolean = False
        Dim STORECODE, storestatus As String
        Dim SQLSTRING11 As String

        ssGrid.Visible = True
        ' Dim OBJstkLedger_Grid As New frmStkLedger_grid
        'OBJstkLedger_Grid.MdiParent = Me
        ssGrid.Show()
        ssGrid.ClearRange(-1, 6, -1, 6, True)
        For I = 6 To ssGrid.DataRowCnt
            For J = 6 To ssGrid.MaxCols
                ssGrid.TypeHAlign = FPSpreadADO.TypeHAlignConstants.TypeHAlignRight
            Next
        Next

        Dim Tot_Value, Tot_Cls, Tot_Iss, Tot_Rec As Double
        Tot_Value = 0 : Tot_Cls = 0 : Tot_Iss = 0 : Tot_Rec = 0

        Try
            opqty = 0
            pagesize = 6

            SQLSTRING11 = "SELECT STORECODE,storestatus FROM STOREMASTER WHERE STOREDESC='" & Trim(STORENAME) & "'"
            gconnection.getDataSet(SQLSTRING11, "MAINSTORE")
            If gdataset.Tables("MAINSTORE").Rows.Count > 0 Then
                STORECODE = Trim(gdataset.Tables("MAINSTORE").Rows(0).Item("STORECODE"))
                storestatus = Trim(gdataset.Tables("MAINSTORE").Rows(0).Item("STORESTATUS"))
            Else
                STORECODE = ""
            End If
            gconnection.getDataSet(SQLSTRING, "VIEWSTOCKLEDGERREPORT")
            With ssGrid
                'If STORECODE = "MNS" Then
                .Col = 1
                .Row = 3
                .Text = "FROM  " & Format(mskfromdate, "dd-MM-yyyy") & "  TO  " & Format(msktodate, "dd-MM-yyyy")
                .RowsFrozen = 4
                If storestatus = "M" Then
                    For J = 0 To gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows.Count - 1
                        If Groupdesc <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname"))) Then
                            '.Row = pagesize
                            '.Col = 1
                            '.ForeColor = Color.Blue
                            '.Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname")
                            '.FontBold = True
                            'pagesize = pagesize + 1
                            '.Row = pagesize

                            Groupdesc = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("Groupname")))
                            vref = True
                        End If

                        If Itemcode <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE"))) Then
                            '-------------------------------------------------------------------------------------------
                            opqty = 0 : balQty = 0 : calbool = False : rcvQty = 0 : issQty = 0 : totreceipt = 0 : totissue = 0 : oprate = 0 : opvalue = 0
                            Itemcode = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")))
                            .Row = pagesize
                            .Col = 1
                            .FontBold = True
                            .ForeColor = Color.Maroon
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")

                            .Col = 3
                            .ForeColor = Color.Maroon
                            .FontBold = True
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMNAME")

                            .Col = 4
                            .ForeColor = Color.Maroon
                            .FontBold = True
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("STOCKUOM")

                            .Col = 5
                            .FontBold = True
                            .ForeColor = Color.Maroon
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("VALUATION")
                            pagesize = pagesize + 1
                            .Row = pagesize

                            '********************* Calculation of Opening Stock *****************************************************
                            sqlstring1 = "SELECT ISNULL(INVITMTRANSQTY,0) AS OPSTOCK,ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(INVITMTRANSVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(Itemcode) & "' AND STORECODE='" & STORECODE & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORYITEMMASTER")
                            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                                opqty = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                                oprate = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("PURCHASERATE")), "0.000")
                                opvalue1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPVALUE")), "0.00")
                                opqty1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                            End If
                            'SIVA--------------------------------- CALCULATION OF OPENING STOCK --------------------------------------------
                            sqlstring1 = "SELECT ISNULL(SUM(GRNTRANSQTY),0) AS TOTAL_GRN, ISNULL(SUM(GRNTRANSVALUE),0) AS GRN_VALUE FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOIDITEM,'') <> 'Y' AND GRNDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_OPENING_GRN_QUANTITY")
                            If gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows(0).Item("TOTAL_GRN")), "0.000")
                                opvalue1 = opvalue1 + Format(Val(gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows(0).Item("GRN_VALUE")), "0.00")
                                opqty1 = opqty1 + Format(Val(gdataset.Tables("INVENTORY_OPENING_GRN_QUANTITY").Rows(0).Item("TOTAL_GRN")), "0.000")
                            End If

                            sqlstring1 = "SELECT ISNULL(SUM(ISSTRANSQTY),0) AS TOTAL_ISSUE, ISNULL(SUM(ISSTRANSVALUE),0) AS ISS_VALUE FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_ISSUE_QUANTITY")
                            If gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty - Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("TOTAL_ISSUE")), "0.000")
                                'opvalue = opvalue - Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("ISS_VALUE")), "0.000")
                            End If

                            'sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_RETURN, ISNULL(SUM(AMOUNT),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND TOSTORECODE LIKE 'M%' "
                            sqlstring1 = "SELECT ISNULL(SUM(TRFTRANSQTY),0) AS TOTAL_RETURN, ISNULL(SUM(TRFTRANSVALUE),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM ") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND TOSTORECODE LIKE 'M%'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_RETURN_QUANTITY")
                            If gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("TOTAL_RETURN")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("RET_VAL")), "0.000")
                            End If

                            sqlstring1 = "SELECT ISNULL(SUM(ADJTRANSQTY),0) AS TOTAL_ADJUST, ISNULL(SUM(ADJTRANSVALUE),0) ADJUSTED_VALUE FROM STOCKADJUSTDETAILS WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND STORELOCATIONCODE LIKE 'M%' "
                            gconnection.getDataSet(sqlstring1, "INVENTORY_ADJUSTED_QUANTITY")
                            If gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("TOTAL_ADJUST")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("ADJUSTED_VALUE")), "0.000")
                            End If

                            sqlstring1 = "select ISNULL(OPRATE,0) AS OPRATE from stocksummary where itemcode='" & Trim(Itemcode) & "'"
                            gconnection.getDataSet(sqlstring1, "Rate1")
                            If gdataset.Tables("rate1").Rows.Count > 0 Then
                                oprate = Val(gdataset.Tables("rate1").Rows(0).Item("oprate"))
                            Else
                                sqlstring1 = "select count(*) as count from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                                gconnection.getDataSet(sqlstring1, "Rate")
                                If Val(gdataset.Tables("rate").Rows(0).Item("count")) > 0 Then
                                    sqlstring1 = "select TOP 1 isnull(rate,0) rate from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and isnull(void,'') <> 'y' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' order by docdate desc"
                                    gconnection.getDataSet(sqlstring1, "CurrentRate")
                                    oprate = Val(gdataset.Tables("currentrate").Rows(0).Item("rate"))
                                Else
                                    If opqty1 > 0 Then
                                        oprate = opvalue1 / opqty1
                                    Else
                                        sqlstring1 = "select top 1 isnull(purchaserate,0) rate from inventoryitemmaster where itemcode='" & Trim(Itemcode) & "' AND STORECODE LIKE '" & STORECODE & "'"
                                        gconnection.getDataSet(sqlstring1, "OpeningRate")
                                        If gdataset.Tables("OpeningRate").Rows.Count > 0 Then
                                            oprate = Val(gdataset.Tables("OpeningRate").Rows(0).Item("rate"))
                                        Else
                                            oprate = 0
                                        End If
                                    End If
                                End If
                            End If
                            opvalue = oprate * opqty
                            .Row = pagesize
                            .Col = 1
                            .Text = Format(mskfromdate, "dd/MMM/yyyy")

                            .Col = 2
                            .Text = " ********** OPENING STOCK ********** "
                            .FontBold = True
                            .AllowCellOverflow = True

                            .Col = 6
                            .FontBold = True
                            .Text = Format(Val(oprate), "0.00")
                            .FontBold = True

                            .Col = 7
                            .FontBold = True
                            .Text = Format(Val(opvalue), "0.00")
                            .FontBold = True

                            .Col = 10
                            .FontBold = True
                            .Text = Format(Val(opqty), "0.00")
                            .FontBold = True
                            pagesize = pagesize + 1

                            '********************************************************************************************************
                            '-------------------------------------------------------------------------------------------
                            'sqlstring1 = "SELECT * FROM  VIEWSTOCKLEDGERMAINSTORE WHERE ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"

                            sqlstring1 = "SELECT INDENTNO , GRNDATE,GRNDETAILS AS GRNDETAILS,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,SUPPLIERCODE,SUPPLIERNAME,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC,OPSTORELOCATIONNAME FROM VIEWSTOCKLEDGERMAINSTORE "
                            sqlstring1 = sqlstring1 & " WHERE ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"
                            sqlstring1 = sqlstring1 & " AND GRNDATE BETWEEN "
                            sqlstring1 = sqlstring1 & " '" & Format(mskfromdate, "dd/MMM/yyyy") & "' AND ' " & Format(msktodate, "dd/MMM/yyyy") & "' ORDER BY ITEMCODE,GRNDATE,GRNDETAILS"
                            gconnection.getDataSet(sqlstring1, "VIEWSTOCKLEDGERMAINSTORE1")
                            If gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows.Count > 0 Then
                                For I = 0 To gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows.Count - 1
                                    If Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 1, 1) = "A" Or Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 1, 1) = "C" Or Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 1, 1) = "D" Then
                                        rcvQty = 0 : issQty = 0
                                        .Row = pagesize
                                        .Col = 1
                                        .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")

                                        .Col = 3
                                        .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS1")

                                        .Col = 4
                                        .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("SUPPLIERNAME")

                                        .Col = 6
                                        .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")

                                        .Col = 8
                                        .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")
                                        .Row = pagesize

                                        rcvQty = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")
                                        totreceipt = totreceipt + Val(rcvQty)
                                        If calbool = False Then
                                            balQty = opqty + rcvQty - issQty
                                            calbool = True
                                        Else
                                            balQty = balQty + rcvQty - issQty
                                        End If
                                        .Col = 10
                                        .Text = Format(Val(balQty), "0.000")
                                        pagesize = pagesize + 1
                                        grndate = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("Grndate")), "dd/MMM/yyyy")
                                    Else
                                        If Mid(CStr(gdataset.Tables("viewstockledgermainstore1").Rows(I).Item("grndetails1")), 1, 3) <> "adj" Then
                                            rcvQty = 0 : issQty = 0 : adjqty = 0
                                            .Row = pagesize
                                            .Col = 1
                                            .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")

                                            .Col = 2
                                            .Text = "ISSUE"

                                            .Col = 3
                                            .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS1") & Space(10) & gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("INDENTNO")

                                            .Col = 4
                                            .AllowCellOverflow = True
                                            .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("OPSTORELOCATIONNAME")

                                            .Col = 6
                                            .Text = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")), "0.00")

                                            issrate = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE"))
                                            IssueValue = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY"))
                                            .Col = 7
                                            .Text = Format(Val(IssueValue), "0.00")

                                            .Col = 9
                                            .Text = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")

                                            issQty = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")
                                            totissue = totissue + issQty
                                            If calbool = False Then
                                                balQty = opqty + rcvQty - issQty + adjqty
                                                calbool = True
                                            Else
                                                balQty = balQty + rcvQty - issQty + adjqty
                                            End If
                                            .Col = 10
                                            .Text = Format(Val(balQty), "0.000")
                                            pagesize = pagesize + 1
                                            .Row = pagesize
                                            grndate = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy ")
                                        Else
                                            rcvQty = 0 : issQty = 0 : adjqty = 0
                                            .Row = pagesize
                                            .Col = 1
                                            .Text = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")

                                            .Col = 2
                                            .Text = "ADJUST"

                                            Filewrite.Write("{0,-20}", Mid(CStr(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")), 4, 20))
                                            .Col = 3
                                            .Text = gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDETAILS")

                                            'issrate = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE"))
                                            'IssueValue = Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY"))
                                            adjqty = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")
                                            .Col = 8
                                            .Text = Format(Val(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNQTY")), "0.000")

                                            'totissue = totissue + issQty
                                            If calbool = False Then
                                                balQty = opqty + rcvQty - issQty + adjqty
                                                calbool = True
                                            Else
                                                balQty = balQty + rcvQty - issQty + adjqty
                                            End If

                                            .Col = 10
                                            .Text = Format(Val(balQty), "0.000")
                                            pagesize = pagesize + 1
                                            grndate = Format(CDate(gdataset.Tables("VIEWSTOCKLEDGERMAINSTORE1").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")
                                        End If
                                    End If
                                    'If pagesize > 56 Then
                                    '    Filewrite.Write(StrDup(137, "-"))
                                    '    Filewrite.Write(Chr(12))
                                    '    'pageno = pageno + 1
                                    '    pagesize = pagesize + 1
                                    '    Call PrintHeader(pageheading, mskfromdate, msktodate)
                                    'End If
                                Next I
                                IssueValue = Val(issrate) * Val(balQty)
                            End If
                            '-------------------------------------------------------------------------------------------
                            If calbool = False Then
                                balQty = opqty
                                IssueValue = opvalue
                                issrate = oprate
                            End If

                            .Row = pagesize
                            .Col = 1
                            .Text = Format(CDate(msktodate), "dd/MMM/yyyy")

                            .Col = 2
                            .Text = " ********** CLOSING BALANCE ********** "
                            .FontBold = True
                            .AllowCellOverflow = True


                            .Col = 6
                            .FontBold = True
                            .Text = Format(Val(issrate), "0.00")

                            .Col = 7
                            .FontBold = True
                            .Text = Format(Val(IssueValue), "0.00")

                            .Col = 10
                            .FontBold = True
                            .Text = Format(Val(balQty), "0.000")
                            pagesize = pagesize + 1

                            .Row = pagesize
                            .Col = 5
                            .FontBold = True
                            .Text = "RECEIPT:"

                            .Col = 8
                            .FontBold = True
                            .Text = Format(Val(totreceipt), "0.000")

                            pagesize = pagesize + 1
                            .Row = pagesize
                            .Col = 5
                            .FontBold = True
                            .Text = "ISSUES  :"

                            .Col = 9
                            .FontBold = True
                            .Text = Format(Val(totissue), "0.000")
                            pagesize = pagesize + 1

                            Tot_Cls = Tot_Cls + Val(balQty)
                            Tot_Value = Tot_Value + Val(IssueValue)
                            Tot_Rec = Tot_Rec + Val(totreceipt)
                            Tot_Iss = Tot_Iss + Val(totissue)







                            '--------------------------------------------------------------------------------------------
                        End If
                        '    If pagesize > 58 Then
                        '        'Filewrite.Write(StrDup(137, "-"))
                        '        'Filewrite.Write(Chr(12))
                        '        ''pageno = pageno + 1
                        '        'pagesize = pagesize + 1
                        '        '.Row = pagesize
                        '        Call PrintHeader(pageheading, mskfromdate, msktodate)
                        '    End If
                    Next
                Else
                    For J = 0 To gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows.Count - 1
                        'If Groupdesc <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPDESC"))) Then
                        If Groupdesc <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname"))) Then
                            'Filewrite.WriteLine("{0,-30}", Mid("[" & Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPDESC"))) & "]", 1, 30))
                            .Row = pagesize
                            .Col = 1
                            .FontBold = True
                            .ForeColor = Color.Blue
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPname")
                            pagesize = pagesize + 1

                            'Filewrite.WriteLine(StrDup(Len(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("GROUPDESC")) + 2, "-"))
                            'Groupdesc = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("Groupdesc")))
                            Groupdesc = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("Groupname")))
                            vref = True
                        End If
                        If Itemcode <> Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE"))) Then
                            '-------------------------------------------------------------------------------------------
                            opqty = 0 : balQty = 0 : calbool = False : rcvQty = 0 : issQty = 0 : totreceipt = 0 : totissue = 0 : oprate = 0 : opvalue = 0
                            Itemcode = Trim(CStr(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")))
                            .Row = pagesize
                            .Col = 1
                            .FontBold = True
                            .ForeColor = Color.Blue
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")

                            .Col = 3
                            .FontBold = True
                            .ForeColor = Color.Blue
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMNAME")

                            .Col = 4
                            .FontBold = True
                            .ForeColor = Color.Blue
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("STOCKUOM")

                            .Col = 5
                            .FontBold = True
                            .ForeColor = Color.Blue
                            .Text = gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("VALUATION")
                            pagesize = pagesize + 1

                            '********************* Calculation of Opening Stock *****************************************************
                            sqlstring1 = "SELECT ISNULL(invitmtransqty,0) AS OPSTOCK,ISNULL(PURCHASERATE,0) AS PURCHASERATE,ISNULL(INVITMTRANSVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(Itemcode) & "' AND STORECODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORYITEMMASTER")
                            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                                opqty = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                                oprate = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("PURCHASERATE")), "0.000")
                                opvalue1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPVALUE")), "0.00")
                                opqty1 = Format(Val(gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("OPSTOCK")), "0.000")
                            End If
                            'SIVA--------------------------------- CALCULATION OF OPENING STOCK --------------------------------------------

                            sqlstring1 = "SELECT ISNULL(SUM(ISSTRANSQTY),0) AS TOTAL_ISSUE, ISNULL(SUM(ISSTRANSVALUE),0) AS ISS_VALUE FROM STOCKISSUEDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND OPSTORELOCATIONCODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_ISSUE_QUANTITY")
                            If gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("TOTAL_ISSUE")), "0.000")
                                'opvalue = opvalue - Format(Val(gdataset.Tables("INVENTORY_ISSUE_QUANTITY").Rows(0).Item("ISS_VALUE")), "0.000")
                            End If
                            sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_RETURN, ISNULL(SUM(AMOUNT),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND FROMSTORECODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_RETURN_QUANTITY")
                            If gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty - Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("TOTAL_RETURN")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("RET_VAL")), "0.000")
                            End If
                            sqlstring1 = "SELECT ISNULL(SUM(QTY),0) AS TOTAL_RETURN, ISNULL(SUM(AMOUNT),0) AS RET_VAL FROM STOCKTRANSFERDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND TOSTORECODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_RETURN_QUANTITY1")
                            If gdataset.Tables("INVENTORY_RETURN_QUANTITY1").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY1").Rows(0).Item("TOTAL_RETURN")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_RETURN_QUANTITY").Rows(0).Item("RET_VAL")), "0.000")
                            End If

                            sqlstring1 = "SELECT ISNULL(SUM(ADJTRANSQTY),0) AS TOTAL_ADJUST, ISNULL(SUM(ADJTRANSVALUE),0) ADJUSTED_VALUE FROM STOCKADJUSTDETAILS WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND STORELOCATIONCODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "INVENTORY_ADJUSTED_QUANTITY")
                            If gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows.Count > 0 Then
                                opqty = opqty + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("TOTAL_ADJUST")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("ADJUSTED_VALUE")), "0.000")
                            End If

                            sqlstring1 = "SELECT ISNULL(SUM(SSCTRANSQTY),0) AS TOTAL_SUB, ISNULL(SUM(SSCTRANSVALUE),0) SUB_VALUE FROM SUBSTORECONSUMPTIONDETAIL WHERE ITEMCODE='" & Trim(Itemcode) & "' AND ISNULL(VOID,'') <> 'Y' AND DOCDATE BETWEEN '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' AND STORELOCATIONCODE='" & Trim(STORECODE) & "'"
                            gconnection.getDataSet(sqlstring1, "SUBSTORE")
                            If gdataset.Tables("SUBSTORE").Rows.Count > 0 Then
                                opqty = opqty - Format(Val(gdataset.Tables("SUBSTORE").Rows(0).Item("TOTAL_SUB")), "0.000")
                                'opvalue = opvalue + Format(Val(gdataset.Tables("INVENTORY_ADJUSTED_QUANTITY").Rows(0).Item("ADJUSTED_VALUE")), "0.000")
                            End If

                            sqlstring1 = "select ISNULL(OPRATE,0) AS OPRATE from stocksummary where itemcode='" & Trim(Itemcode) & "'"
                            gconnection.getDataSet(sqlstring1, "Rate1")
                            If gdataset.Tables("rate1").Rows.Count > 0 Then
                                oprate = Val(gdataset.Tables("rate1").Rows(0).Item("oprate"))
                            Else
                                sqlstring1 = "select count(*) as count from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "'"
                                gconnection.getDataSet(sqlstring1, "Rate")
                                If Val(gdataset.Tables("rate").Rows(0).Item("count")) > 0 Then
                                    sqlstring1 = "select TOP 1 isnull(rate,0) rate from stockissuedetail where itemcode='" & Trim(Itemcode) & "' and isnull(void,'') <> 'y' and docdate between '" & Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, -1, CDate(mskfromdate)), "dd MMM yyyy") & "' order by docdate desc"
                                    gconnection.getDataSet(sqlstring1, "CurrentRate")
                                    oprate = Val(gdataset.Tables("currentrate").Rows(0).Item("rate"))
                                Else
                                    If opqty1 > 0 Then
                                        oprate = opvalue1 / opqty1
                                    Else
                                        sqlstring1 = "select TOP 1 isnull(purchaserate,0) rate from inventoryitemmaster where itemcode='" & Trim(Itemcode) & "' AND STORECODE LIKE '" & STORECODE & "'"
                                        gconnection.getDataSet(sqlstring1, "OpeningRate")
                                        If gdataset.Tables("OpeningRate").Rows.Count > 0 Then
                                            oprate = Val(gdataset.Tables("OpeningRate").Rows(0).Item("rate"))
                                        Else
                                            oprate = 0
                                        End If
                                    End If
                                End If
                            End If
                            opvalue = oprate * opqty
                            '   Filewrite.WriteLine("{0,-18}{1,-40}{2,-17}{3,10}{4,11}{5,26}{6,13}", Format(mskfromdate, "dd/MM/yyyy"), "********* OPENING BALANCE ***********", "", Mid(Format(Val(oprate), "0.00"), 1, 10), Mid(Format(Val(opvalue), "0.00"), 1, 11), "", Mid(Format(Val(opqty), "0.000"), 1, 13))

                            .Row = pagesize
                            .Col = 1
                            .Text = Format(mskfromdate, "dd/MMM/yyyy")

                            .Col = 2
                            .Text = " ********** OPENING STOCK ********** "
                            .FontBold = True
                            .AllowCellOverflow = True

                            .Col = 6
                            .FontBold = True
                            .Text = Format(Val(oprate), "0.00")
                            .FontBold = True

                            .Col = 7
                            .FontBold = True
                            .Text = Format(Val(opvalue), "0.00")
                            .FontBold = True

                            .Col = 10
                            .FontBold = True
                            .Text = Format(Val(opqty), "0.00")
                            .FontBold = True
                            pagesize = pagesize + 1

                            '********************************************************************************************************
                            '-------------------------------------------------------------------------------------------
                            'sqlstring1 = "SELECT * FROM  VIEWSTOCKLEDGERMAINSTORE WHERE ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"
                            'sqlstring1 = "SELECT GRNDATE,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC FROM VIEWSTOCKLEDGERSUBSTORE "
                            sqlstring1 = "SELECT GRNDATE,GRNDETAILS AS GRNDETAILS,SUBSTRING(GRNDETAILS,2,LEN(GRNDETAILS)) GRNDETAILS1,GRNRATE,GRNQTY,ITEMCODE,ITEMNAME,STOCKUOM,VALUATION,GROUPDESC FROM VIEWSTOCKLEDGERSUBSTORE "
                            sqlstring1 = sqlstring1 & " WHERE STORECODE='" & STORECODE & "' AND ITEMCODE='" & Trim(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("ITEMCODE")) & "'"
                            sqlstring1 = sqlstring1 & " AND GRNDATE BETWEEN "
                            sqlstring1 = sqlstring1 & " '" & Format(mskfromdate, "dd/MMM/yyyy ") & "' AND '" & Format(msktodate, "dd/MMM/yyyy") & "' ORDER BY ITEMCODE,GRNDATE,GRNDETAILS"
                            gconnection.getDataSet(sqlstring1, "SUBSTOREVIEW")
                            If gdataset.Tables("SUBSTOREVIEW").Rows.Count > 0 Then
                                For I = 0 To gdataset.Tables("SUBSTOREVIEW").Rows.Count - 1
                                    If Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS")), 1, 1) = "B" Or Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS")), 1, 1) = "A" Or Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS")), 1, 1) = "D" Then
                                        rcvQty = 0 : issQty = 0 : adjqty = 0
                                        .Row = pagesize
                                        .Col = 1
                                        .Text = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")

                                        .Col = 2
                                        .Text = "RECEIVE"

                                        .Col = 3
                                        .Text = gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS1")

                                        .Col = 6
                                        .Text = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")), "0.00")

                                        issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                        IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))

                                        .Col = 7
                                        .Text = Format(Val(IssueValue), "0.00")

                                        .Col = 8
                                        .Text = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.00")

                                        rcvQty = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000")
                                        totreceipt = totreceipt + Val(rcvQty)
                                        If calbool = False Then
                                            balQty = opqty + rcvQty - issQty + adjqty
                                            calbool = True
                                        Else
                                            balQty = balQty + rcvQty - issQty + adjqty
                                        End If

                                        .Col = 10
                                        .Text = Format(Val(balQty), "0.000")
                                        pagesize = pagesize + 1
                                        grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("Grndate")), "dd/MMM/yyyy")
                                    Else
                                        If Mid(CStr(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("grndetails1")), 1, 3) <> "adj" Then
                                            rcvQty = 0 : issQty = 0 : adjqty = 0
                                            .Row = pagesize
                                            .Col = 1
                                            .Text = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")

                                            .Col = 2
                                            .Text = "ISSUE"

                                            .Col = 3
                                            .Text = gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS1")

                                            .Col = 6
                                            .Text = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")), "0.00")

                                            issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                            IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))
                                            .Col = 7
                                            .Text = Format(Val(IssueValue), "0.00")

                                            .Col = 9
                                            .Text = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.00")

                                            issQty = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000")
                                            totissue = totissue + Val(issQty)
                                            If calbool = False Then
                                                balQty = opqty + rcvQty - issQty + adjqty
                                                calbool = True
                                            Else
                                                balQty = balQty + rcvQty - issQty + adjqty
                                            End If
                                            .Col = 10
                                            .Text = Format(Val(balQty), "0.000")
                                            pagesize = pagesize + 1
                                            grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")
                                        Else
                                            rcvQty = 0 : issQty = 0 : adjqty = 0
                                            .Row = pagesize
                                            .Col = 1
                                            .Text = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")

                                            .Col = 2
                                            .Text = "ADJUST"

                                            .Col = 3
                                            .Text = gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDETAILS1")

                                            'issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                            'IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))
                                            .Col = 9
                                            .Text = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.00")

                                            adjqty = Format(Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY")), "0.000")
                                            totissue = totissue + issQty - adjqty
                                            If calbool = False Then
                                                balQty = opqty + rcvQty - issQty + adjqty
                                                calbool = True
                                            Else
                                                balQty = balQty + rcvQty - issQty + adjqty
                                            End If
                                            .Col = 10
                                            .Text = Format(Val(balQty), "0.000")
                                            pagesize = pagesize + 1
                                            grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MMM/yyyy")

                                        End If
                                    End If
                                    'If pagesize > 56 Then
                                    'Filewrite.Write(StrDup(137, "-"))
                                    'Filewrite.Write(Chr(12))
                                    ''pageno = pageno + 1
                                    'pagesize = pagesize + 1
                                    'Call PrintHeader(pageheading, mskfromdate, msktodate)
                                    'End If
                                Next I
                                IssueValue = Val(issrate) * Val(balQty)
                                gconnection.getDataSet("SELECT ISNULL(SUM(QTY),0) AS QTY FROM SUBSTORECONSUMPTIONDETAIL WHERE STORELOCATIONCODE='" & STORECODE & "' AND ITEMCODE='" & Itemcode & "' AND ISNULL(VOID,'') <> 'Y'  AND DOCDATE BETWEEN '" & Format(mskfromdate, "dd MMM yyyy") & "' AND '" & Format(msktodate, "dd MMM yyyy") & "'", "SALES")
                                If gdataset.Tables("SALES").Rows.Count > 0 Then
                                    rcvQty = 0 : issQty = 0 : adjqty = 0
                                    .Row = pagesize
                                    .Col = 2
                                    .Text = "SALES"

                                    'issrate = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE"))
                                    'IssueValue = Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNRATE")) * Val(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNQTY"))
                                    .Col = 9
                                    .Text = Format(Val(gdataset.Tables("SALES").Rows(0).Item("QTY")), "0.000")

                                    issQty = Format(Val(gdataset.Tables("SALES").Rows(0).Item("QTY")), "0.000")
                                    totissue = totissue + issQty
                                    If calbool = False Then
                                        balQty = opqty + rcvQty - issQty + adjqty
                                        calbool = True
                                    Else
                                        balQty = balQty + rcvQty - issQty + adjqty
                                    End If
                                    .Col = 10
                                    .Text = Format(Val(balQty), "0.000")
                                    pagesize = pagesize + 1
                                    'grndate = Format(CDate(gdataset.Tables("SUBSTOREVIEW").Rows(I).Item("GRNDATE")), "dd/MM/yyyy")
                                End If
                                '-------------------------------------------------------------------------------------------

                                '--------------------------------------------------------------------------------------------
                            End If
                            If calbool = False Then
                                balQty = opqty
                                IssueValue = opvalue
                                issrate = oprate
                            End If
                            '  Filewrite.WriteLine("{0,-18}{1,-40}{2,-17}{3,10}{4,11}{5,13}{6,13}{7,13}", Format(CDate(msktodate), "dd/MM/yyyy"), "********* CLOSING BALANCE ***********", "", Mid(Format(Val(issrate), "0.00"), 1, 10), Mid(Format(Val(IssueValue), "0.00"), 1, 11), "", Mid(Format(Val(balQty), "0.000"), 1, 13), Mid(Format(Val(balQty) * Val(gdataset.Tables("VIEWSTOCKLEDGERREPORT").Rows(J).Item("CONVVALUE")), "0"), 1, 13))
                            .Row = pagesize
                            .Col = 1
                            .Text = Format(CDate(msktodate), "dd/MMM/yyyy")

                            .Col = 2
                            .Text = " ********* CLOSING BALANCE ********* "
                            .FontBold = True
                            .AllowCellOverflow = True

                            .Col = 6
                            .FontBold = True
                            .Text = Format(Val(issrate), "0.00")

                            .Col = 7
                            .FontBold = True
                            .Text = Format(Val(IssueValue), "0.00")

                            .Col = 10
                            .FontBold = True
                            .Text = Format(Val(balQty), "0.000")
                            pagesize = pagesize + 1

                            .Row = pagesize
                            .Col = 5
                            .FontBold = True
                            .Text = "RECEIPT:"

                            .Col = 8
                            .FontBold = True
                            .Text = Format(Val(totreceipt), "0.000")

                            pagesize = pagesize + 1
                            .Row = pagesize
                            .Col = 5
                            .FontBold = True
                            .Text = "ISSUES  :"

                            .Col = 9
                            .FontBold = True
                            .Text = Format(Val(totissue), "0.000")
                            pagesize = pagesize + 1

                            Tot_Cls = Tot_Cls + Val(balQty)
                            Tot_Value = Tot_Value + Val(IssueValue)
                            Tot_Rec = Tot_Rec + Val(totreceipt)
                            Tot_Iss = Tot_Iss + Val(totissue)
                        End If
                        'If pagesize > 58 Then
                        '    Filewrite.Write(StrDup(137, "-"))
                        '    Filewrite.Write(Chr(12))
                        '    pagesize = pagesize + 1
                        '    'pageno = pageno + 1
                        '    Call PrintHeader(pageheading, mskfromdate, msktodate)
                        'End If

                    Next
                End If
                gconnection.getDataSet("SELECT ISNULL(SUM(ISNULL(CLSVAL,0)),0) AS CLSVAL,ISNULL(SUM(ISNULL(RCVQTY,0)),0) AS RCVQTY,ISNULL(SUM(ISNULL(ISSQTY,0)),0) AS ISSQTY,ISNULL(SUM(ISNULL(CLSQTY,0)),0) AS CLSQTY FROM STOCKSUMMARY ", "SALES")
                .Row = pagesize
                .Col = 3
                .AllowCellOverflow = True
                .FontBold = True
                .ForeColor = Color.Red
                .Text = "********* GRAND TOTAL *********"

                .Col = 7
                .FontBold = True
                .ForeColor = Color.Red
                .Text = Format(Val(gdataset.Tables("SALES").Rows(0).Item("CLSVAL")), "0.00")

                .Col = 8
                .FontBold = True
                .ForeColor = Color.Red
                .Text = Format(Val(gdataset.Tables("SALES").Rows(0).Item("RCVQTY")), "0.000")

                .Col = 9
                .FontBold = True
                .ForeColor = Color.Red
                .Text = Format(Val(gdataset.Tables("SALES").Rows(0).Item("ISSQTY")), "0.000")

                .Col = 10
                .FontBold = True
                .ForeColor = Color.Red
                .Text = Format(Val(gdataset.Tables("SALES").Rows(0).Item("CLSQTY")), "0.000")

            End With
            'Filewrite.WriteLine(StrDup(137, "-"))
            'pagesize = pagesize + 1
            'Filewrite.Write(Chr(12))
            'Filewrite.Close()
            'If gPrint = False Then
            '    OpenTextFile(vOutfile)
            'Else
            '    PrintTextFile(VFilePath)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Function
        End Try
    End Function

    Private Function PrintHeader(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        '        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MMM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,62}{1,-10}", " ", "DETAILS")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE :")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(137, "-"))
            pagesize = pagesize + 1
            Filewrite.Write("{0,-12}{1,-10}{2,-20}{3,-20}{4,-17}{5,10}", "CODE/", "DOC", "ITEM NAME/", "", "", "RATE")
            Filewrite.WriteLine("{0,11}{1,13}{2,13}{3,13}", "VALUE", "RECEIPTS", "ISSUES", "BALANCE")
            pagesize = pagesize + 1
            Filewrite.Write("{0,-12}{1,-10}{2,-20}{3,-20}{4,-17}{5,10}", "DATE", "TYPE", "TYPE DOC NO.", "PARTY NAME", "REMARKS", "")
            Filewrite.WriteLine("{0,11}{1,13}{2,13}{3,13}", "", "QUANTITY", "QUANTITY", "QUANTITY")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(137, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Private Sub frmStockledgermainstock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            Dim search As New frmListSearch
            search.listbox = Chklist_Itemdetails
            search.Text = "Items Search"
            search.ShowDialog(Me)
        ElseIf e.KeyCode = Keys.F2 Then
            Dim search As New frmListSearch
            search.listbox = Chklist_Groupdesc
            search.Text = "Group Search"
            search.ShowDialog(Me)
        ElseIf e.KeyCode = Keys.F1 Then
            Dim Asearch As New frmSearch_Advanced
            Asearch.chklistbox = Chklist_Itemdetails
            Asearch.ShowDialog(Me)
        End If
    End Sub

    Private Sub cbo_Storelocation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_Storelocation.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dtp_Fromdate.Focus()
        End If
    End Sub

    Private Sub Cmd_exp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_exp.Click
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("STK" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".xls"
            ssGrid.ExportToExcel(VFilePath, "STKledger$", AppPath & "\REPORTS\STKLDGR.log")
            Shell(strexcelpath & " " & VFilePath, AppWinStyle.MaximizedFocus)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Export")
        End Try
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validation.Click
        System.Diagnostics.Process.Start(AppPath & "/STUDY/STOCKLEDGER.XLS")
    End Sub
End Class
