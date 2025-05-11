Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmCATStockSummary
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
    Friend WithEvents lbl_GroupList As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents Chklist_Groupdesc As System.Windows.Forms.CheckedListBox
    Friend WithEvents lbl_Itemlist As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllItem As System.Windows.Forms.CheckBox
    Friend WithEvents Chklist_Itemdetails As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_Fromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_Todate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents grp_SalebillChecklist As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents CHK_ZEROQTY As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_VALUE As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_ITEMMASTSTK As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents grp_orderby As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_name As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_code As System.Windows.Forms.RadioButton
    Friend WithEvents cmd_itemto As System.Windows.Forms.Button
    Friend WithEvents txt_itemto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXT_FROM As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_ITEMFROM As System.Windows.Forms.Button
    Friend WithEvents Lbl_SubledgerCode As System.Windows.Forms.Label
    Friend WithEvents txt_Mainstore As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Mainstore As System.Windows.Forms.Label
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents TXT_MAINSTORECODE As System.Windows.Forms.TextBox
    Friend WithEvents pur_chk As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CBO_SELECTALL As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_WAR As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_categoryList As System.Windows.Forms.Label
    Friend WithEvents Chklist_Category As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_SelectAllcategory As System.Windows.Forms.CheckBox
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_validation As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCATStockSummary))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.lbl_GroupList = New System.Windows.Forms.Label()
        Me.Chk_SelectAllGroup = New System.Windows.Forms.CheckBox()
        Me.Chklist_Groupdesc = New System.Windows.Forms.CheckedListBox()
        Me.lbl_Itemlist = New System.Windows.Forms.Label()
        Me.Chk_SelectAllItem = New System.Windows.Forms.CheckBox()
        Me.Chklist_Itemdetails = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.dtp_Fromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_Todate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.btn_validation = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox()
        Me.lbl_Wait = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.CHK_ZEROQTY = New System.Windows.Forms.CheckBox()
        Me.CHK_VALUE = New System.Windows.Forms.CheckBox()
        Me.CHK_ITEMMASTSTK = New System.Windows.Forms.CheckBox()
        Me.grp_orderby = New System.Windows.Forms.GroupBox()
        Me.rdo_name = New System.Windows.Forms.RadioButton()
        Me.rdo_code = New System.Windows.Forms.RadioButton()
        Me.cmd_itemto = New System.Windows.Forms.Button()
        Me.txt_itemto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXT_FROM = New System.Windows.Forms.TextBox()
        Me.Cmd_ITEMFROM = New System.Windows.Forms.Button()
        Me.Lbl_SubledgerCode = New System.Windows.Forms.Label()
        Me.txt_Mainstore = New System.Windows.Forms.TextBox()
        Me.lbl_Mainstore = New System.Windows.Forms.Label()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.TXT_MAINSTORECODE = New System.Windows.Forms.TextBox()
        Me.pur_chk = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CBO_SELECTALL = New System.Windows.Forms.CheckBox()
        Me.CHK_WAR = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.lbl_categoryList = New System.Windows.Forms.Label()
        Me.Chk_SelectAllcategory = New System.Windows.Forms.CheckBox()
        Me.Chklist_Category = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmbut.SuspendLayout()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.grp_orderby.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Location = New System.Drawing.Point(184, 22)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(342, 22)
        Me.lbl_Heading.TabIndex = 5
        Me.lbl_Heading.Text = "CATEGORYWISE STOCK SUMMARY"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_GroupList
        '
        Me.lbl_GroupList.BackColor = System.Drawing.Color.Maroon
        Me.lbl_GroupList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupList.ForeColor = System.Drawing.Color.White
        Me.lbl_GroupList.Location = New System.Drawing.Point(212, 35)
        Me.lbl_GroupList.Name = "lbl_GroupList"
        Me.lbl_GroupList.Size = New System.Drawing.Size(197, 24)
        Me.lbl_GroupList.TabIndex = 438
        Me.lbl_GroupList.Text = "SELECT GROUPCODE :"
        '
        'Chk_SelectAllGroup
        '
        Me.Chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllGroup.Location = New System.Drawing.Point(214, 7)
        Me.Chk_SelectAllGroup.Name = "Chk_SelectAllGroup"
        Me.Chk_SelectAllGroup.Size = New System.Drawing.Size(168, 24)
        Me.Chk_SelectAllGroup.TabIndex = 436
        Me.Chk_SelectAllGroup.Text = "SELECT ALL"
        Me.Chk_SelectAllGroup.UseVisualStyleBackColor = False
        '
        'Chklist_Groupdesc
        '
        Me.Chklist_Groupdesc.CheckOnClick = True
        Me.Chklist_Groupdesc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_Groupdesc.Location = New System.Drawing.Point(212, 59)
        Me.Chklist_Groupdesc.Name = "Chklist_Groupdesc"
        Me.Chklist_Groupdesc.Size = New System.Drawing.Size(196, 349)
        Me.Chklist_Groupdesc.TabIndex = 437
        '
        'lbl_Itemlist
        '
        Me.lbl_Itemlist.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Itemlist.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemlist.ForeColor = System.Drawing.Color.White
        Me.lbl_Itemlist.Location = New System.Drawing.Point(408, 34)
        Me.lbl_Itemlist.Name = "lbl_Itemlist"
        Me.lbl_Itemlist.Size = New System.Drawing.Size(227, 24)
        Me.lbl_Itemlist.TabIndex = 435
        Me.lbl_Itemlist.Text = "SELECT ITEMCODE :"
        '
        'Chk_SelectAllItem
        '
        Me.Chk_SelectAllItem.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllItem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllItem.Location = New System.Drawing.Point(411, 10)
        Me.Chk_SelectAllItem.Name = "Chk_SelectAllItem"
        Me.Chk_SelectAllItem.Size = New System.Drawing.Size(161, 24)
        Me.Chk_SelectAllItem.TabIndex = 433
        Me.Chk_SelectAllItem.Text = "SELECT ALL"
        Me.Chk_SelectAllItem.UseVisualStyleBackColor = False
        '
        'Chklist_Itemdetails
        '
        Me.Chklist_Itemdetails.CheckOnClick = True
        Me.Chklist_Itemdetails.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_Itemdetails.Location = New System.Drawing.Point(409, 58)
        Me.Chklist_Itemdetails.Name = "Chklist_Itemdetails"
        Me.Chklist_Itemdetails.Size = New System.Drawing.Size(227, 349)
        Me.Chklist_Itemdetails.TabIndex = 434
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.PictureBox4)
        Me.GroupBox3.Controls.Add(Me.dtp_Fromdate)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtp_Todate)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(19, 623)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(506, 64)
        Me.GroupBox3.TabIndex = 446
        Me.GroupBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(104, 18)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 504
        Me.PictureBox2.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(346, 19)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.TabIndex = 46
        Me.PictureBox4.TabStop = False
        '
        'dtp_Fromdate
        '
        Me.dtp_Fromdate.CustomFormat = "dd-MM-yyyy"
        Me.dtp_Fromdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Fromdate.Location = New System.Drawing.Point(136, 24)
        Me.dtp_Fromdate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.dtp_Fromdate.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
        Me.dtp_Fromdate.Name = "dtp_Fromdate"
        Me.dtp_Fromdate.Size = New System.Drawing.Size(104, 21)
        Me.dtp_Fromdate.TabIndex = 0
        Me.dtp_Fromdate.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(274, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TO DATE :"
        '
        'dtp_Todate
        '
        Me.dtp_Todate.CustomFormat = "dd-MM-yyyy"
        Me.dtp_Todate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Todate.Location = New System.Drawing.Point(378, 24)
        Me.dtp_Todate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.dtp_Todate.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
        Me.dtp_Todate.Name = "dtp_Todate"
        Me.dtp_Todate.Size = New System.Drawing.Size(104, 21)
        Me.dtp_Todate.TabIndex = 1
        Me.dtp_Todate.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "FROM DATE :"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Print.BackgroundImage = CType(resources.GetObject("Cmd_Print.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Print.FlatAppearance.BorderSize = 0
        Me.Cmd_Print.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(9, 150)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Print.TabIndex = 445
        Me.Cmd_Print.Text = " Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = False
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
        Me.Cmd_View.Location = New System.Drawing.Point(9, 73)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_View.TabIndex = 442
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(10, 200)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Exit.TabIndex = 443
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(9, 25)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Clear.TabIndex = 441
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.Cmd_Clear)
        Me.frmbut.Controls.Add(Me.Cmd_View)
        Me.frmbut.Controls.Add(Me.chk_excel)
        Me.frmbut.Controls.Add(Me.Cmd_Print)
        Me.frmbut.Controls.Add(Me.Cmd_Exit)
        Me.frmbut.Location = New System.Drawing.Point(697, 123)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(163, 261)
        Me.frmbut.TabIndex = 444
        Me.frmbut.TabStop = False
        '
        'chk_excel
        '
        Me.chk_excel.BackColor = System.Drawing.Color.Transparent
        Me.chk_excel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_excel.Location = New System.Drawing.Point(9, 125)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(104, 24)
        Me.chk_excel.TabIndex = 464
        Me.chk_excel.Text = "EXCEL"
        Me.chk_excel.UseVisualStyleBackColor = False
        '
        'btn_validation
        '
        Me.btn_validation.BackColor = System.Drawing.Color.Transparent
        Me.btn_validation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_validation.ForeColor = System.Drawing.Color.Black
        Me.btn_validation.Location = New System.Drawing.Point(399, 689)
        Me.btn_validation.Name = "btn_validation"
        Me.btn_validation.Size = New System.Drawing.Size(104, 32)
        Me.btn_validation.TabIndex = 465
        Me.btn_validation.Text = "Validation"
        Me.btn_validation.UseVisualStyleBackColor = False
        Me.btn_validation.Visible = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.Transparent
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Location = New System.Drawing.Point(207, 689)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(104, 32)
        Me.cmd_export.TabIndex = 507
        Me.cmd_export.Text = "Export"
        Me.cmd_export.UseVisualStyleBackColor = False
        Me.cmd_export.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.BackColor = System.Drawing.Color.Transparent
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label2)
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(19, 629)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(592, 64)
        Me.grp_SalebillChecklist.TabIndex = 448
        Me.grp_SalebillChecklist.TabStop = False
        '
        'lbl_Wait
        '
        Me.lbl_Wait.AutoSize = True
        Me.lbl_Wait.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Wait.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Wait.Location = New System.Drawing.Point(360, 24)
        Me.lbl_Wait.Name = "lbl_Wait"
        Me.lbl_Wait.Size = New System.Drawing.Size(0, 15)
        Me.lbl_Wait.TabIndex = 387
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(288, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 15)
        Me.Label2.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 16)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(569, 32)
        Me.ProgressBar1.TabIndex = 0
        '
        'CHK_ZEROQTY
        '
        Me.CHK_ZEROQTY.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ZEROQTY.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_ZEROQTY.Location = New System.Drawing.Point(8, 77)
        Me.CHK_ZEROQTY.Name = "CHK_ZEROQTY"
        Me.CHK_ZEROQTY.Size = New System.Drawing.Size(112, 24)
        Me.CHK_ZEROQTY.TabIndex = 449
        Me.CHK_ZEROQTY.Text = " ZERO QTY"
        Me.CHK_ZEROQTY.UseVisualStyleBackColor = False
        '
        'CHK_VALUE
        '
        Me.CHK_VALUE.BackColor = System.Drawing.Color.Transparent
        Me.CHK_VALUE.Checked = True
        Me.CHK_VALUE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHK_VALUE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_VALUE.Location = New System.Drawing.Point(8, 48)
        Me.CHK_VALUE.Name = "CHK_VALUE"
        Me.CHK_VALUE.Size = New System.Drawing.Size(132, 25)
        Me.CHK_VALUE.TabIndex = 450
        Me.CHK_VALUE.Text = "TRANSACTION ONLY"
        Me.CHK_VALUE.UseVisualStyleBackColor = False
        '
        'CHK_ITEMMASTSTK
        '
        Me.CHK_ITEMMASTSTK.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ITEMMASTSTK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_ITEMMASTSTK.Location = New System.Drawing.Point(717, 623)
        Me.CHK_ITEMMASTSTK.Name = "CHK_ITEMMASTSTK"
        Me.CHK_ITEMMASTSTK.Size = New System.Drawing.Size(128, 25)
        Me.CHK_ITEMMASTSTK.TabIndex = 452
        Me.CHK_ITEMMASTSTK.Text = "ITEM MASTER STOCK"
        Me.CHK_ITEMMASTSTK.UseVisualStyleBackColor = False
        Me.CHK_ITEMMASTSTK.Visible = False
        '
        'grp_orderby
        '
        Me.grp_orderby.BackColor = System.Drawing.Color.Transparent
        Me.grp_orderby.Controls.Add(Me.rdo_name)
        Me.grp_orderby.Controls.Add(Me.rdo_code)
        Me.grp_orderby.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_orderby.Location = New System.Drawing.Point(697, 390)
        Me.grp_orderby.Name = "grp_orderby"
        Me.grp_orderby.Size = New System.Drawing.Size(136, 73)
        Me.grp_orderby.TabIndex = 469
        Me.grp_orderby.TabStop = False
        Me.grp_orderby.Text = "Order By"
        '
        'rdo_name
        '
        Me.rdo_name.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo_name.Location = New System.Drawing.Point(16, 42)
        Me.rdo_name.Name = "rdo_name"
        Me.rdo_name.Size = New System.Drawing.Size(96, 27)
        Me.rdo_name.TabIndex = 1
        Me.rdo_name.Text = " Name"
        '
        'rdo_code
        '
        Me.rdo_code.Checked = True
        Me.rdo_code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo_code.Location = New System.Drawing.Point(14, 16)
        Me.rdo_code.Name = "rdo_code"
        Me.rdo_code.Size = New System.Drawing.Size(88, 20)
        Me.rdo_code.TabIndex = 0
        Me.rdo_code.TabStop = True
        Me.rdo_code.Text = "Item Code"
        '
        'cmd_itemto
        '
        Me.cmd_itemto.FlatAppearance.BorderSize = 0
        Me.cmd_itemto.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_itemto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_itemto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_itemto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_itemto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_itemto.Image = CType(resources.GetObject("cmd_itemto.Image"), System.Drawing.Image)
        Me.cmd_itemto.Location = New System.Drawing.Point(286, 21)
        Me.cmd_itemto.Name = "cmd_itemto"
        Me.cmd_itemto.Size = New System.Drawing.Size(23, 26)
        Me.cmd_itemto.TabIndex = 481
        '
        'txt_itemto
        '
        Me.txt_itemto.BackColor = System.Drawing.Color.Wheat
        Me.txt_itemto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_itemto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_itemto.Location = New System.Drawing.Point(211, 23)
        Me.txt_itemto.MaxLength = 20
        Me.txt_itemto.Name = "txt_itemto"
        Me.txt_itemto.Size = New System.Drawing.Size(72, 21)
        Me.txt_itemto.TabIndex = 480
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(179, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 15)
        Me.Label4.TabIndex = 479
        Me.Label4.Text = "TO:"
        '
        'TXT_FROM
        '
        Me.TXT_FROM.BackColor = System.Drawing.Color.Wheat
        Me.TXT_FROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_FROM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_FROM.Location = New System.Drawing.Point(84, 24)
        Me.TXT_FROM.MaxLength = 20
        Me.TXT_FROM.Name = "TXT_FROM"
        Me.TXT_FROM.Size = New System.Drawing.Size(64, 21)
        Me.TXT_FROM.TabIndex = 477
        '
        'Cmd_ITEMFROM
        '
        Me.Cmd_ITEMFROM.FlatAppearance.BorderSize = 0
        Me.Cmd_ITEMFROM.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_ITEMFROM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_ITEMFROM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_ITEMFROM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_ITEMFROM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_ITEMFROM.Image = CType(resources.GetObject("Cmd_ITEMFROM.Image"), System.Drawing.Image)
        Me.Cmd_ITEMFROM.Location = New System.Drawing.Point(152, 21)
        Me.Cmd_ITEMFROM.Name = "Cmd_ITEMFROM"
        Me.Cmd_ITEMFROM.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_ITEMFROM.TabIndex = 478
        '
        'Lbl_SubledgerCode
        '
        Me.Lbl_SubledgerCode.AutoSize = True
        Me.Lbl_SubledgerCode.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubledgerCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubledgerCode.Location = New System.Drawing.Point(5, 27)
        Me.Lbl_SubledgerCode.Name = "Lbl_SubledgerCode"
        Me.Lbl_SubledgerCode.Size = New System.Drawing.Size(76, 15)
        Me.Lbl_SubledgerCode.TabIndex = 476
        Me.Lbl_SubledgerCode.Text = "ITEM  FROM:"
        '
        'txt_Mainstore
        '
        Me.txt_Mainstore.BackColor = System.Drawing.Color.Wheat
        Me.txt_Mainstore.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Mainstore.Enabled = False
        Me.txt_Mainstore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Mainstore.Location = New System.Drawing.Point(188, 24)
        Me.txt_Mainstore.MaxLength = 15
        Me.txt_Mainstore.Name = "txt_Mainstore"
        Me.txt_Mainstore.ReadOnly = True
        Me.txt_Mainstore.Size = New System.Drawing.Size(168, 21)
        Me.txt_Mainstore.TabIndex = 493
        '
        'lbl_Mainstore
        '
        Me.lbl_Mainstore.AutoSize = True
        Me.lbl_Mainstore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Mainstore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Mainstore.Location = New System.Drawing.Point(6, 25)
        Me.lbl_Mainstore.Name = "lbl_Mainstore"
        Me.lbl_Mainstore.Size = New System.Drawing.Size(52, 15)
        Me.lbl_Mainstore.TabIndex = 492
        Me.lbl_Mainstore.Text = "STORE :"
        '
        'cmd_storecode
        '
        Me.cmd_storecode.FlatAppearance.BorderSize = 0
        Me.cmd_storecode.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_storecode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_storecode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_storecode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmd_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(126, 20)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 495
        '
        'TXT_MAINSTORECODE
        '
        Me.TXT_MAINSTORECODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_MAINSTORECODE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_MAINSTORECODE.Location = New System.Drawing.Point(59, 24)
        Me.TXT_MAINSTORECODE.MaxLength = 15
        Me.TXT_MAINSTORECODE.Name = "TXT_MAINSTORECODE"
        Me.TXT_MAINSTORECODE.Size = New System.Drawing.Size(64, 21)
        Me.TXT_MAINSTORECODE.TabIndex = 496
        '
        'pur_chk
        '
        Me.pur_chk.BackColor = System.Drawing.Color.Transparent
        Me.pur_chk.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pur_chk.Location = New System.Drawing.Point(8, 104)
        Me.pur_chk.Name = "pur_chk"
        Me.pur_chk.Size = New System.Drawing.Size(128, 24)
        Me.pur_chk.TabIndex = 497
        Me.pur_chk.Text = "PURCHASERATE"
        Me.pur_chk.UseVisualStyleBackColor = False
        Me.pur_chk.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(345, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.TabIndex = 499
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(576, 34)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.TabIndex = 500
        Me.PictureBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Maroon
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(600, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 24)
        Me.Label8.TabIndex = 501
        Me.Label8.Text = "F1"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Maroon
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(375, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 24)
        Me.Label6.TabIndex = 502
        Me.Label6.Text = "F2"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TXT_MAINSTORECODE)
        Me.GroupBox1.Controls.Add(Me.lbl_Mainstore)
        Me.GroupBox1.Controls.Add(Me.cmd_storecode)
        Me.GroupBox1.Controls.Add(Me.txt_Mainstore)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 541)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 64)
        Me.GroupBox1.TabIndex = 503
        Me.GroupBox1.TabStop = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(153, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 24)
        Me.Label16.TabIndex = 497
        Me.Label16.Text = "F4"
        Me.Label16.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Lbl_SubledgerCode)
        Me.GroupBox2.Controls.Add(Me.TXT_FROM)
        Me.GroupBox2.Controls.Add(Me.Cmd_ITEMFROM)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txt_itemto)
        Me.GroupBox2.Controls.Add(Me.cmd_itemto)
        Me.GroupBox2.Location = New System.Drawing.Point(387, 541)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 64)
        Me.GroupBox2.TabIndex = 504
        Me.GroupBox2.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CBO_SELECTALL)
        Me.GroupBox4.Controls.Add(Me.CHK_VALUE)
        Me.GroupBox4.Controls.Add(Me.CHK_ZEROQTY)
        Me.GroupBox4.Controls.Add(Me.pur_chk)
        Me.GroupBox4.Location = New System.Drawing.Point(717, 469)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(143, 136)
        Me.GroupBox4.TabIndex = 505
        Me.GroupBox4.TabStop = False
        '
        'CBO_SELECTALL
        '
        Me.CBO_SELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CBO_SELECTALL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBO_SELECTALL.Location = New System.Drawing.Point(8, 16)
        Me.CBO_SELECTALL.Name = "CBO_SELECTALL"
        Me.CBO_SELECTALL.Size = New System.Drawing.Size(128, 26)
        Me.CBO_SELECTALL.TabIndex = 498
        Me.CBO_SELECTALL.Text = "FOR SELECT ALL"
        Me.CBO_SELECTALL.UseVisualStyleBackColor = False
        Me.CBO_SELECTALL.Visible = False
        '
        'CHK_WAR
        '
        Me.CHK_WAR.BackColor = System.Drawing.Color.Transparent
        Me.CHK_WAR.Checked = True
        Me.CHK_WAR.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHK_WAR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_WAR.Location = New System.Drawing.Point(717, 658)
        Me.CHK_WAR.Name = "CHK_WAR"
        Me.CHK_WAR.Size = New System.Drawing.Size(64, 24)
        Me.CHK_WAR.TabIndex = 506
        Me.CHK_WAR.Text = "WAR"
        Me.CHK_WAR.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Maroon
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(174, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 24)
        Me.Label5.TabIndex = 511
        Me.Label5.Text = "F4"
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(138, 35)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox5.TabIndex = 510
        Me.PictureBox5.TabStop = False
        '
        'lbl_categoryList
        '
        Me.lbl_categoryList.BackColor = System.Drawing.Color.Maroon
        Me.lbl_categoryList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_categoryList.ForeColor = System.Drawing.Color.White
        Me.lbl_categoryList.Location = New System.Drawing.Point(13, 35)
        Me.lbl_categoryList.Name = "lbl_categoryList"
        Me.lbl_categoryList.Size = New System.Drawing.Size(197, 24)
        Me.lbl_categoryList.TabIndex = 509
        Me.lbl_categoryList.Text = "SELECT CATEGORY :"
        '
        'Chk_SelectAllcategory
        '
        Me.Chk_SelectAllcategory.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllcategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllcategory.Location = New System.Drawing.Point(15, 7)
        Me.Chk_SelectAllcategory.Name = "Chk_SelectAllcategory"
        Me.Chk_SelectAllcategory.Size = New System.Drawing.Size(168, 24)
        Me.Chk_SelectAllcategory.TabIndex = 512
        Me.Chk_SelectAllcategory.Text = "SELECT ALL"
        Me.Chk_SelectAllcategory.UseVisualStyleBackColor = False
        '
        'Chklist_Category
        '
        Me.Chklist_Category.CheckOnClick = True
        Me.Chklist_Category.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_Category.Location = New System.Drawing.Point(11, 59)
        Me.Chklist_Category.Name = "Chklist_Category"
        Me.Chklist_Category.Size = New System.Drawing.Size(199, 349)
        Me.Chklist_Category.TabIndex = 513
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.Chklist_Category)
        Me.GroupBox5.Controls.Add(Me.Chk_SelectAllcategory)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.PictureBox5)
        Me.GroupBox5.Controls.Add(Me.lbl_categoryList)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.PictureBox3)
        Me.GroupBox5.Controls.Add(Me.PictureBox1)
        Me.GroupBox5.Controls.Add(Me.lbl_GroupList)
        Me.GroupBox5.Controls.Add(Me.Chk_SelectAllGroup)
        Me.GroupBox5.Controls.Add(Me.Chklist_Groupdesc)
        Me.GroupBox5.Controls.Add(Me.lbl_Itemlist)
        Me.GroupBox5.Controls.Add(Me.Chk_SelectAllItem)
        Me.GroupBox5.Controls.Add(Me.Chklist_Itemdetails)
        Me.GroupBox5.Location = New System.Drawing.Point(19, 116)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(645, 419)
        Me.GroupBox5.TabIndex = 514
        Me.GroupBox5.TabStop = False
        '
        'frmCATStockSummary
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(884, 733)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_validation)
        Me.Controls.Add(Me.CHK_WAR)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_orderby)
        Me.Controls.Add(Me.CHK_ITEMMASTSTK)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmd_export)
        Me.Controls.Add(Me.GroupBox5)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmCATStockSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTS [STOCK SUMMARY]"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmbut.ResumeLayout(False)
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.grp_SalebillChecklist.PerformLayout()
        Me.grp_orderby.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
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


    Private Sub FillGroupdetails()
        Dim i As Integer
        Dim sqlstring As String
        Chklist_Groupdesc.Items.Clear()
        sqlstring = "SELECT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPNAME,'') AS GROUPDESC FROM INVENTORYITEMMASTER WHERE STORECODE='" & Trim(TXT_MAINSTORECODE.Text) & "' GROUP BY GROUPCODE,GROUPNAME"
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    Chklist_Groupdesc.Items.Add(Trim(CStr(.Item("GROUPDESC"))))
                End With
            Next
        End If
    End Sub
    Private Sub FillCategorydetails()
        Dim i As Integer
        Dim sqlstring As String
        Chklist_Category.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(CATEGORY,'') AS CATEGORY FROM Inv_INVENTORYITEMMASTER ORDER BY CATEGORY "
        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                    Chklist_Category.Items.Add(Trim(CStr(.Item("CATEGORY"))))
                End With
            Next
        End If
    End Sub
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click

        If TXT_FROM.Text = "" And txt_itemto.Text = "" Then
            If Trim(TXT_FROM.Text) = "" And Trim(txt_itemto.Text) = "" Then
                If Chklist_Category.CheckedItems.Count = 0 Then
                    MessageBox.Show("Select the Category description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If Chklist_Groupdesc.CheckedItems.Count = 0 Then
                    MessageBox.Show("Select the Group description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If Chklist_Itemdetails.CheckedItems.Count = 0 Then
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            End If
        End If
        Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        gPrint = False
        grp_SalebillChecklist.Top = 606
        grp_SalebillChecklist.Left = 217
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 10
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        If Chklist_Groupdesc.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Group description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        gPrint = True
        grp_SalebillChecklist.Top = 606
        grp_SalebillChecklist.Left = 217
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 10
        Me.Timer1.Enabled = True
    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click

        dtp_Fromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
        dtp_Todate.Value = Format(Now, "dd/MM/yyyy")
        grp_SalebillChecklist.Top = 1000
        Chklist_Groupdesc.Items.Clear()
        Chklist_Itemdetails.Items.Clear()
        Chklist_Category.Items.Clear()
        txt_Mainstore.Text = ""
        TXT_MAINSTORECODE.Text = ""
        TXT_FROM.Text = ""
        txt_itemto.Text = ""
        Chk_SelectAllGroup.Checked = False
        Chk_SelectAllItem.Checked = False
        Chk_SelectAllcategory.Checked = False
        CBO_SELECTALL.Checked = False
        Call FillGroupdetails()

        Me.Show()
        TXT_MAINSTORECODE.Focus()

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Chklist_Itemdetails.Focus()
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
            sqlstring = sqlstring & ssql & ")order by itemcode"
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
        Dim sqlstring, ssql, Groupcode() As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' "

        If Chklist_Category.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & "  and I.category IN ("
            For J = 0 To Chklist_Category.CheckedItems.Count - 1
                Groupcode = Split(Chklist_Category.CheckedItems(J), "-->")
                sqlstring = sqlstring & " '" & Groupcode(0) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        If Chklist_Groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & "  and I.GROUPNAME IN ("
            For J = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                Groupcode = Split(Chklist_Groupdesc.CheckedItems(J), "-->")
                sqlstring = sqlstring & " '" & Groupcode(1) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        sqlstring = sqlstring & " order by itemcode "
        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
            Chklist_Itemdetails.Items.Clear()
            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                    Chklist_Itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                End With
            Next i
        End If

        If Chklist_Groupdesc.CheckedItems.Count > 0 Then
        Else
            Chklist_Itemdetails.Items.Clear()
            Chk_SelectAllGroup.Checked = False
            Chk_SelectAllItem.Checked = False
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
            Chklist_Itemdetails.Items.Clear()
            Chk_SelectAllItem.Checked = False

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

    Private Sub dtp_Fromdate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Fromdate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dtp_Todate.Focus()
        End If
    End Sub
    Private Sub dtp_Todate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Todate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cmd_View.Focus()
        End If
    End Sub
    Private Sub frmMainStockPosition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Chklist_Groupdesc.Items.Clear()
        Call FillCategorydetails()

        Chklist_Itemdetails.Items.Clear()
        If UCase(gShortname) = "RSAOI" Then
            dtp_Fromdate.Value = Format(CDate("01/01/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtp_Fromdate.Value = Format(CDate("04/01/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        dtp_Todate.Value = Format(Now, "dd/MMM/yyyy")
        grp_SalebillChecklist.Top = 1000
        Me.Show()
        TXT_MAINSTORECODE.Focus()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
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
    Private Sub frmMainStockPosition_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F9 Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F10 Then
            Call Cmd_Print_Click(Cmd_Print, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            Call Cmd_Exit_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(sender, e)
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.F Then
            Me.dtp_Fromdate.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.T Then
            Me.dtp_Todate.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.F3 Then

        ElseIf e.KeyCode = Keys.F2 Then
            Dim search As New frmListSearch
            search.listbox = Chklist_Groupdesc
            search.Text = "Group Search"
            search.ShowDialog(Me)

        ElseIf e.KeyCode = Keys.F1 Then
            Dim lstAdvSearch As New frmListSearch
            lstAdvSearch.listbox = Chklist_Itemdetails
            lstAdvSearch.Text = "Item Search"
            lstAdvSearch.ShowDialog(Me)

        ElseIf e.KeyCode = Keys.F4 Then
            Dim lstAdvSearch As New frmListSearch
            lstAdvSearch.listbox = Chklist_Category
            lstAdvSearch.Text = "Category Search"
            lstAdvSearch.ShowDialog(Me)


        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 1
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_SalebillChecklist.Top = 1000

            'If CHK_ITEMMASTSTK.Checked = True Then
            '    Call Item_master_stock_crystal()
            'ElseIf CHK_VALUE.Checked = True Then
                'If MsgBox("Click YES for 'Windows View' or NO for 'TEXT View'", MsgBoxStyle.YesNo, "STOCK SUMMARY") = MsgBoxResult.Yes Then
            Call StkSummary_crystal()
                ' Else
                '    Call ViewStocksummary()
                'End If
            'End If
        End If
    End Sub
    Public Sub ViewStocksummary()
        Try
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode, SITEMCODE As String
            Dim Boolupdate As Boolean
            Dim I As Integer
            Storecode = "" : Clsquantity = "" : I = 0

            sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STORECODE = '" & Trim(TXT_MAINSTORECODE.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOREMASTER")
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
            Else
                Storecode = "MNS"
            End If

            If TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                sqlstring = "Update inventoryitemmaster set selectopt='N'"
                gconnection.dataOperation(6, sqlstring, "ItemMaster")
                sqlstring = "Update inventoryitemmaster set selectopt='Y' WHERE ITEMCODE BETWEEN '" & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' AND STORECODE='" & Trim(Storecode) & "'"
                gconnection.dataOperation(6, sqlstring, "ItemMaster")
            Else
                Dim SLSTRING As String
                SLSTRING = ""
                For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                    Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                    SLSTRING = SLSTRING & "'" & Itemcode(0) & "', "
                Next
                SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)

                sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & SLSTRING & ")"
                gconnection.getDataSet(sqlstring, "ITEMMASTER1")

                sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='Y' WHERE ITEMCODE IN(" & SLSTRING & ")"
                gconnection.getDataSet(sqlstring, "ITEMMASTER")


                sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(TXT_MAINSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "STOREMASTER")
            End If
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
                Me.Cursor = Cursors.WaitCursor
                If CHK_WAR.Checked = True Then
                    Dim Avgrate As Double
                    ' Avgrate = CALWAR(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Todate.Value, "dd MMM yyyy"), SITEMCODE, Trim(Storecode), "B")
                Else

                    '---------------------- EXECUTE STORE PROCEDURE --------------------------'
                    gconnection.openConnection()

                    gcommand = New SqlCommand("CP_STOCKSUMMARY2", gconnection.Myconn)
                    gcommand.CommandTimeout = 1000000000
                    gcommand.CommandType = CommandType.StoredProcedure
                    gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
                    gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_Fromdate.Value), "dd/MM/yyyy")
                    gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_Todate.Value), "dd/MM/yyyy")
                    gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
                    gcommand.ExecuteNonQuery()
                    gconnection.closeConnection()
                End If
                Me.Cursor = Cursors.Default
                '--------------------------------------------------------------------------'
            Else
                MessageBox.Show("Select the Store Loc.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            sqlstring = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE,ISNULL(S.ITEMNAME,'') AS ITEMDESC,ISNULL(S.UOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
            sqlstring = sqlstring & "SUM(ISNULL(S.OPQTY,0.000)) AS OPQTY,SUM(ISNULL(S.OPVAL,0.000)) AS OPVAL, SUM(ISNULL(S.RCVQTY,0.000)) AS RCVQTY,SUM(ISNULL(S.RCVVAL,0.000)) AS RCVVAL,SUM(ISNULL(S.RCVQTY1,0.000)) AS RCVQTY1,SUM(ISNULL(S.RCVVAL1,0.000)) AS RCVVAL1,SUM(ISNULL(S.RCVQTY2,0.000)) AS RCVQTY2,SUM(ISNULL(S.RCVVAL2,0.000)) AS RCVVAL2,SUM(ISNULL(S.RCVQTY3,0.000)) AS RCVQTY3,SUM(ISNULL(S.RCVVAL3,0.000)) AS RCVVAL3,SUM(ISNULL(S.ISSQTY,0.000)) AS ISSQTY,SUM(ISNULL(S.ISSVAL,0.000)) AS ISSVAL,SUM(ISNULL(S.ISSQTY1,0.000)) AS ISSQTY1,SUM(ISNULL(S.ISSVAL1,0.000)) AS ISSVAL1,SUM(ISNULL(S.ISSQTY2,0.000)) AS ISSQTY2,SUM(ISNULL(S.ISSVAL2,0.000)) AS ISSVAL2,SUM(ISNULL(S.ISSQTY3,0.000)) AS ISSQTY3,SUM(ISNULL(S.ISSVAL3,0.000)) AS ISSVAL3,SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSVAL,0.00)) AS VALUE,SUM(ISNULL(S.DISPQTY,0)) AS DISPQTY FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "
            sqlstring = sqlstring & " WHERE I.ITEMCODE=S.ITEMCODE AND I.STORECODE=S.STORECODE"
            sqlstring = sqlstring & " AND S.STORECODE='" & Trim(TXT_MAINSTORECODE.Text) & "'"

            If CHK_ZEROQTY.Checked = False Then
                sqlstring = sqlstring & " AND (OPQTY <> 0 OR RCVQTY <> 0 OR ISSQTY <> 0)"
            End If
            sqlstring = sqlstring & " GROUP BY ISNULL(S.ITEMCODE,''),ISNULL(S.ITEMNAME,''),ISNULL(S.UOM,''), ISNULL(I.GROUPNAME,'') ORDER BY GROUPNAME "

            If rdo_code.Checked = True Then
                sqlstring = sqlstring & " ,ITEMCODE   "
            Else
                sqlstring = sqlstring & " ,ITEMNAME "
            End If

            Dim heading() As String = {"STOCK SUMMARY" & "[ " & Trim(TXT_MAINSTORECODE.Text) & " ]"}
            Dim ObjSTOCKSummary As New rptStockSummary
            If CHK_VALUE.Checked = True Then
                ObjSTOCKSummary.Reportdetails_Value_withoutGroup(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)

            Else
                ObjSTOCKSummary.Reportdetails_withoutGroup(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub StkSummary_crystal()
        Try
            Dim str, MTYPE(), tspilt(), SITEMCODE As String
            Dim i As Integer
            Dim rViewer As New Viewer
            Dim r As New Rpt_stk_catsummary
            Dim Heading(0) As String
            Dim sqlstring, SSQL As String

            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim Boolupdate As Boolean
            Storecode = "" : Clsquantity = "" : i = 0
            Dim SLSTRING As String
            Dim rate As Double

            sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STORECODE = '" & Trim(TXT_MAINSTORECODE.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOREMASTER")
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
            Else
                Storecode = "MNS"
            End If

            If Chklist_Itemdetails.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                sqlstring = "Update inventoryitemmaster set selectopt=''"
                gconnection.dataOperation(6, sqlstring, "ItemMaster")
                sqlstring = "Update inventoryitemmaster set selectopt='Y' WHERE ITEMCODE BETWEEN '" & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "'"
                gconnection.dataOperation(6, sqlstring, "ItemMaster")
            Else

                SLSTRING = ""
                For i = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                    Itemcode = Split(Chklist_Itemdetails.CheckedItems(i), "-->")
                    SLSTRING = SLSTRING & "'" & Itemcode(0) & "', "
                Next
                SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)
                sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & SLSTRING & ")"
                gconnection.getDataSet(sqlstring, "ITEMMASTER1")

                sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='Y' WHERE ITEMCODE IN(" & SLSTRING & ")"
                gconnection.getDataSet(sqlstring, "ITEMMASTER")
            End If

            'sqlstring = " select top 1 rate from grn_details where adddate<= '" & Format(CDate(dtp_Todate.Value), "yyyy/MM/dd") & "'  order by adddate desc"
            'gconnection.getDataSet(sqlstring, "rate")
            'If gdataset.Tables("rate").Rows.Count > 0 Then
            '    rate = gdataset.Tables("rate").Rows(0).Item("rate")
            'End If
            sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(txt_Mainstore.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOREMASTER")
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
                Me.Cursor = Cursors.WaitCursor
                If CHK_WAR.Checked = True Then
                    Dim Avgrate As Double
                    'Avgrate = CALWAR(Format(CDate("01/04/" & gFinancalyearStart), "dd MMM yyyy"), Format(dtp_Todate.Value, "dd MMM yyyy"), SITEMCODE, Trim(Storecode), "B")
                    ' Else

                    '---------------------- EXECUTE STORE PROCEDURE --------------------------'
                    gconnection.openConnection()

                    If pur_chk.Checked = True Then
                        gcommand = New SqlCommand("Cp_StockSummary_PURSRATE", gconnection.Myconn)
                    Else
                        gcommand = New SqlCommand("CP_STOCKSUMMARY3", gconnection.Myconn)
                    End If


                    gcommand.CommandTimeout = 1000000000
                    gcommand.CommandType = CommandType.StoredProcedure
                    gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
                    gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_Fromdate.Value), "dd/MM/yyyy")
                    gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_Todate.Value), "dd/MM/yyyy")
                    gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
                    gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(dtp_Todate.Value), "yyyy/MM/dd")
                    'gcommand.Parameters.Add(New SqlParameter("@rate", SqlDbType.Float)).Value = rate
                    gcommand.ExecuteNonQuery()
                    gconnection.closeConnection()
                End If
                Me.Cursor = Cursors.Default
                '--------------------------------------------------------------------------'
            Else
                MessageBox.Show("Select the Store Loc.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            sqlstring = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE,ISNULL(S.ITEMNAME,'') AS ITEMNAME,ISNULL(S.UOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
            sqlstring = sqlstring & "SUM(ISNULL(S.OPQTY,0.000)) AS OPQTY,SUM(ISNULL(S.OPDISPQTY,0.000)) AS OPDISPQTY,SUM(ISNULL(S.OPVAL,0.000)) AS OPVAL, SUM(ISNULL(S.RCVQTY,0.000)) AS RCVQTY,SUM(ISNULL(S.RCVVAL,0.000)) AS RCVVAL,SUM(ISNULL(S.RCVQTY1,0.000)) AS RCVQTY1,SUM(ISNULL(S.RCVVAL1,0.000)) AS RCVVAL1,SUM(ISNULL(S.RCVQTY2,0.000)) AS RCVQTY2,SUM(ISNULL(S.RCVVAL2,0.000)) AS RCVVAL2,SUM(ISNULL(S.RCVQTY3,0.000)) AS RCVQTY3,SUM(ISNULL(S.RCVVAL3,0.000)) AS RCVVAL3,ISNULL(S.RCVRATE,0) AS RCVRATE ,SUM(ISNULL(S.ISSQTY,0.000)) AS ISSQTY,SUM(ISNULL(S.ISDISPQTY,0.000)) AS ISDISPQTY,ISNULL(S.ISSRATE,0) AS ISSRATE ,SUM(ISNULL(S.ISSVAL,0.000)) AS ISSVAL,SUM(ISNULL(S.ISSQTY1,0.000)) AS ISSQTY1,SUM(ISNULL(S.ISSVAL1,0.000)) AS ISSVAL1,SUM(ISNULL(S.ISSQTY2,0.000)) AS ISSQTY2,SUM(ISNULL(S.ISSVAL2,0.000)) AS ISSVAL2,SUM(ISNULL(S.ISSQTY3,0.000)) AS ISSQTY3,SUM(ISNULL(S.ISSVAL3,0.000)) AS ISSVAL3,SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSRATE,0.00)) CLSRATE, SUM(ISNULL(S.CLSVAL,0.00)) AS VALUE,SUM(ISNULL(S.DISPQTY,0)) AS DISPQTY,ISNULL(S.CATEGORY,'')AS CATEGORY  FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "
            sqlstring = sqlstring & " WHERE I.ITEMCODE=S.ITEMCODE AND I.STORECODE=S.STORECODE"
            sqlstring = sqlstring & " AND S.STORECODE='" & Trim(TXT_MAINSTORECODE.Text) & "'"
            If CHK_ZEROQTY.Checked = False Then
                sqlstring = sqlstring & " And (OPQTY <> 0 OR RCVQTY <> 0 OR ISSQTY <> 0)"
            End If
            sqlstring = sqlstring & " GROUP BY ISNULL(S.ITEMCODE,''),I.ITEMCODE,I.ITEMNAME,ISNULL(S.ITEMNAME,''),ISNULL(S.UOM,''), ISNULL(I.GROUPNAME,'') , ISNULL(S.ISSRATE,0) , ISNULL(S.RCVRATE,0),ISNULL(S.CATEGORY,''),I.CATEGORY ORDER BY  "
            If rdo_code.Checked = True Then
                sqlstring = sqlstring & " I.ITEMCODE   "
            Else
                sqlstring = sqlstring & " I.ITEMNAME "
            End If
            gconnection.getDataSet(sqlstring, "ISSUEREGISTER")
            If gdataset.Tables("ISSUEREGISTER").Rows.Count > 0 Then
                If chk_excel.Checked = True Then
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "CATEGORYWISE STOCK SUMMARY " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                Else
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "STOCKSUMMARY"

                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text13")
                    textobj1.Text = MyCompanyName

                    Dim textobj2 As TextObject
                    textobj2 = r.ReportDefinition.ReportObjects("Text8")
                    textobj2.Text = Trim(txt_Mainstore.Text)

                    Dim textobj4 As TextObject
                    textobj4 = r.ReportDefinition.ReportObjects("Text24")
                    textobj4.Text = gUsername

                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text15")
                    textobj6.Text = UCase(gCompanyAddress(0))

                    Dim textobj7 As TextObject
                    textobj7 = r.ReportDefinition.ReportObjects("Text25")
                    textobj7.Text = UCase(gCompanyAddress(1))

                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                    TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""
                    If MyCompanyName = "THE BENGAL CLUB" Then
                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text27")
                        textobj3.Text = ""
                    End If
                    rViewer.Show()
                End If
            Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OKOnly)
                End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Item_master_stock_crystal()
        Try
            Dim str, MTYPE(), tspilt() As String
            Dim i As Integer
            Dim rViewer As New Viewer
            Dim r As New Rpt_Itemmaster_stk
            Dim Heading(0) As String
            Dim sqlstring, SSQL As String

            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim Boolupdate As Boolean
            Storecode = "" : Clsquantity = "" : i = 0
            Dim SLSTRING As String

            Storecode = Trim(TXT_MAINSTORECODE.Text)

            If Chklist_Itemdetails.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                sqlstring = "Update inventoryitemmaster set selectopt=''"
                gconnection.dataOperation(6, sqlstring, "ItemMaster")
                sqlstring = "Update inventoryitemmaster set selectopt='Y' WHERE ITEMCODE BETWEEN '" & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "'"
                gconnection.dataOperation(6, sqlstring, "ItemMaster")
            Else
                SLSTRING = ""
                For i = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                    Itemcode = Split(Chklist_Itemdetails.CheckedItems(i), "-->")
                    SLSTRING = SLSTRING & "'" & Itemcode(0) & "', "
                Next
                SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)

                sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & SLSTRING & ")"
                gconnection.getDataSet(sqlstring, "ITEMMASTER1")

                sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='Y' WHERE ITEMCODE IN(" & SLSTRING & ")"
                gconnection.getDataSet(sqlstring, "ITEMMASTER")
            End If

            sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(txt_Mainstore.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOREMASTER")
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
                '---------------------- EXECUTE STORE PROCEDURE --------------------------'
                gconnection.openConnection()

                gcommand = New SqlCommand("CP_STOCKSUMMARY2", gconnection.Myconn)
                gcommand.CommandTimeout = 1000000000
                gcommand.CommandType = CommandType.StoredProcedure
                gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
                gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_Fromdate.Value), "dd/MM/yyyy")
                gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_Todate.Value), "dd/MM/yyyy")
                gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
                gcommand.ExecuteNonQuery()
                gconnection.closeConnection()
                '--------------------------------------------------------------------------'
            Else
                MessageBox.Show("Select the Store Loc.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            sqlstring = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE,ISNULL(S.ITEMNAME,'') AS ITEMNAME,ISNULL(S.UOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
            sqlstring = sqlstring & "SUM(ISNULL(S.OPQTY,0.000)) AS OPQTY,SUM(ISNULL(S.OPVAL,0.000)) AS OPVAL, SUM(ISNULL(S.RCVQTY,0.000)) AS RCVQTY,SUM(ISNULL(S.RCVVAL,0.000)) AS RCVVAL,"
            sqlstring = sqlstring & "SUM(ISNULL(S.RCVQTY1,0.000)) AS RCVQTY1,SUM(ISNULL(S.RCVVAL1,0.000)) AS RCVVAL1,SUM(ISNULL(S.RCVQTY2,0.000)) AS RCVQTY2,SUM(ISNULL(S.RCVVAL2,0.000)) AS RCVVAL2,"
            sqlstring = sqlstring & "SUM(ISNULL(S.RCVQTY3,0.000)) AS RCVQTY3,SUM(ISNULL(S.RCVVAL3,0.000)) AS RCVVAL3,SUM(ISNULL(S.ISSQTY,0.000)) AS ISSQTY,"
            sqlstring = sqlstring & "SUM(ISNULL(S.ISSVAL,0.000)) AS ISSVAL,SUM(ISNULL(S.ISSQTY1,0.000)) AS ISSQTY1,SUM(ISNULL(S.ISSVAL1,0.000)) AS ISSVAL1,SUM(ISNULL(S.ISSQTY2,0.000)) AS ISSQTY2,SUM(ISNULL(S.ISSVAL2,0.000)) AS ISSVAL2,SUM(ISNULL(S.ISSQTY3,0.000)) AS ISSQTY3,SUM(ISNULL(S.ISSVAL3,0.000)) AS ISSVAL3,SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSRATE,0.00)) CLSRATE, SUM(ISNULL(S.CLSVAL,0.00)) AS VALUE,SUM(ISNULL(S.DISPQTY,0)),ISNULL(S.CATEGORY,'')AS CATEGORY  AS DISPQTY FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "

            If Chklist_Itemdetails.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                sqlstring = sqlstring & " where  I.ITEMCODE=S.ITEMCODE  AND I.STORECODE ='" & Storecode & "' AND S.ITEMCODE  BETWEEN '"
                sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
            Else

                If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE I.ITEMCODE=S.ITEMCODE AND S.ITEMCODE IN ("

                    For i = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                        Itemcode = Split(Chklist_Itemdetails.CheckedItems(i), "-->")
                        sqlstring = sqlstring & "'" & Itemcode(0) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ") and I.storecode=s.storecode "
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            If CHK_ZEROQTY.Checked = False Then
                sqlstring = sqlstring & " And (OPQTY <> 0 OR RCVQTY <> 0 OR ISSQTY <> 0)"
            End If
            sqlstring = sqlstring & " GROUP BY ISNULL(S.ITEMCODE,''),ISNULL(S.ITEMNAME,''),ISNULL(S.UOM,''), ISNULL(I.GROUPNAME,'') ORDER BY  "

            If rdo_code.Checked = True Then
                sqlstring = sqlstring & " ITEMCODE   "
            Else
                sqlstring = sqlstring & " ITEMNAME "
            End If
            If chk_excel.Checked = True Then
                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "CATEGORYWISE STOCK SUMMARY " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
            Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "STOCKSUMMARY"

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName

                Dim TXTOBJ2 As TextObject
                TXTOBJ2 = r.ReportDefinition.ReportObjects("Text16")
                TXTOBJ2.Text = " Prepared By : " & gUsername

                Dim textobj4 As TextObject
                textobj4 = r.ReportDefinition.ReportObjects("Text8")
                textobj4.Text = Trim(txt_Mainstore.Text)

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""
                If MyCompanyName = "THE BENGAL CLUB" Then
                    Dim textobj3 As TextObject
                    textobj3 = r.ReportDefinition.ReportObjects("Text27")
                    textobj3.Text = ""
                End If
                rViewer.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbo_Storelocation_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            dtp_Fromdate.Focus()
        End If
    End Sub

    Private Sub Cmd_ITEMFROM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ITEMFROM.Click
        Try
            Dim vform As New ListOperattion1
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim I As Integer
            gSQLString = " SELECT  itemcode,itemname  FROM INVENTORYITEMMASTER "
            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'  AND storecode = '" & Trim(TXT_MAINSTORECODE.Text) & "'"
            vform.Field = "ITEMCODE,ITEMNAME"
            vform.vFormatstring = "  ITEMCODE                             |                          ITEMNAME                                "
            vform.vCaption = "ITEMMASTER MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXT_FROM.Text = Trim(vform.keyfield & "")
                Me.txt_itemto.Focus()
            Else
                Me.TXT_FROM.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error :Cmd_ITEMFROM_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub TXT_FROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_FROM.KeyPress
        Try
            getAlphanumeric(e)
            If Asc(e.KeyChar) = 13 Then
                If Trim(TXT_FROM.Text) = "" Then
                    Call Cmd_ITEMFROM_Click(Cmd_ITEMFROM, e)
                Else
                    Call TXT_FROM_Validated(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : TXT_FROM_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub TXT_FROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_FROM.Validated
        Try
            Dim sqlstring, itemcode() As String
            Dim i As Integer
            If Trim(TXT_FROM.Text) <> "" Then
                sqlstring = "select ITEMCODE, ITEMNAME from inventoryitemmaster where ITEMCODE = '" & Trim(TXT_FROM.Text) & "'"
                sqlstring = sqlstring & " AND storecode = '" & Trim(TXT_MAINSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "inventoryitemmaster")
                If gdataset.Tables("inventoryitemmaster").Rows.Count > 0 Then
                    TXT_FROM.Text = Trim(UCase(gdataset.Tables("inventoryitemmaster").Rows(0).Item("ITEMCODE")))
                    txt_itemto.Focus()
                Else
                    TXT_FROM.Text = ""
                    TXT_FROM.Focus()
                End If
            Else
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : TXT_FROM_Validated " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_itemto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_itemto.Click
        Try
            Dim vform As New ListOperattion1
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim I As Integer
            gSQLString = " SELECT  itemcode,itemname  FROM INVENTORYITEMMASTER "
            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'  "
            M_WhereCondition = M_WhereCondition & " AND storecode = '" & Trim(TXT_MAINSTORECODE.Text) & "'"

            vform.Field = "ITEMCODE,ITEMNAME"
            vform.vFormatstring = "  ITEMCODE                             |                          ITEMNAME                                "
            vform.vCaption = "ITEMMASTER MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_itemto.Text = Trim(vform.keyfield & "")
                Me.dtp_Fromdate.Focus()
            Else
                Me.txt_itemto.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_itemto_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_itemto_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim sqlstring, itemcode() As String
            Dim i As Integer
            If Trim(txt_itemto.Text) <> "" Then
                sqlstring = "select ITEMCODE, ITEMNAME from inventoryitemmaster where ITEMCODE = '" & Trim(txt_itemto.Text) & "'"
                sqlstring = sqlstring & " AND storecode = '" & Trim(TXT_MAINSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "inventoryitemmaster")
                If gdataset.Tables("inventoryitemmaster").Rows.Count > 0 Then
                    txt_itemto.Text = Trim(UCase(gdataset.Tables("inventoryitemmaster").Rows(0).Item("ITEMCODE")))
                    Cmd_Print.Focus()
                Else
                    txt_itemto.Text = ""
                    txt_itemto.Focus()
                End If
            Else
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_itemto_Validated " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_itemto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.F4 Then
                Call cmd_itemto_Click(sender, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : txt_itemto_KeyDown" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub TXT_FROM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_FROM.KeyDown
        Try
            If e.KeyCode = Keys.F4 Then
                Call Cmd_ITEMFROM_Click(sender, e)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : TXT_FROM_KeyDown" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_storecode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_storecode.Click
        gSQLString = "SELECT DISTINCT(storecode),storedesc FROM storemaster "
        M_WhereCondition = " where freeze <> 'Y' "
        Dim vform As New ListOperattion1
        vform.Field = "STOREDESC,STORECODE"
        vform.vFormatstring = "             STORE CODE                   |                   STORE DESCRIPTION                             "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_MAINSTORECODE.Text = Trim(vform.keyfield & "")
            txt_Mainstore.Text = Trim(vform.keyfield1 & "")
            Call FillCategorydetails()
            Chklist_Category.Focus()
            Call FillGroupdetails()
            Chklist_Groupdesc.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_Mainstorecode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_MAINSTORECODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_MAINSTORECODE.Text) = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
            Else
                Call txt_Mainstorecode_Validated(sender, e)
                Chklist_Category.Focus()
            End If
        End If
    End Sub
    Private Sub txt_Mainstorecode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_MAINSTORECODE.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_storecode_Click(cmd_storecode, e)
        End If
    End Sub
    Private Sub txt_Mainstorecode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_MAINSTORECODE.Validated
        Try
            If Trim(TXT_MAINSTORECODE.Text) <> "" Then
                sqlstring = "SELECT * FROM storemaster WHERE storecode='" & Trim(TXT_MAINSTORECODE.Text) & "'"
                gconnection.getDataSet(sqlstring, "storemaster")
                If gdataset.Tables("storemaster").Rows.Count > 0 Then
                    TXT_MAINSTORECODE.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                    txt_Mainstore.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                    Call FillCategorydetails()
                    '   Call FillGroupdetails()
                    TXT_FROM.Focus()
                End If
            End If
        Catch
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub txt_itemto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_itemto.KeyPress
        Try
            getAlphanumeric(e)
            If Asc(e.KeyChar) = 13 Then
                If Trim(txt_itemto.Text) = "" Then
                    Call cmd_itemto_Click(cmd_itemto, e)
                Else
                    Call txt_itemto_Validated(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : TXT_FROM_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub TXT_MAINSTORECODE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_MAINSTORECODE.GotFocus
        TXT_MAINSTORECODE.BackColor = Color.Gold
        Label16.Visible = True
    End Sub

    Private Sub TXT_MAINSTORECODE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_MAINSTORECODE.LostFocus
        TXT_MAINSTORECODE.BackColor = Color.Wheat
        Label16.Visible = False
    End Sub
    Private Sub CBO_SELECTALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBO_SELECTALL.CheckedChanged
        If CBO_SELECTALL.Checked = True Then
            Lbl_SubledgerCode.Visible = True
            Label3.Visible = True
            TXT_FROM.Visible = True
            txt_itemto.Visible = True
            Cmd_ITEMFROM.Visible = True
            cmd_itemto.Visible = True
            Chklist_Groupdesc.Visible = False
            Chklist_Itemdetails.Visible = False
            Chklist_Category.Visible = False
            lbl_GroupList.Visible = False
            lbl_Itemlist.Visible = False
            Label6.Visible = False
            Label8.Visible = False
            Label4.Visible = True
            PictureBox1.Visible = False
            PictureBox3.Visible = False
            Chk_SelectAllGroup.Visible = False
            Chk_SelectAllItem.Visible = False
            Chk_SelectAllcategory.Visible = False
            TXT_FROM.Focus()
        Else
            Lbl_SubledgerCode.Visible = False
            ' Label3.Visible = False
            Label4.Visible = False
            TXT_FROM.Visible = False
            txt_itemto.Visible = False
            Cmd_ITEMFROM.Visible = False
            cmd_itemto.Visible = False
            Chklist_Groupdesc.Visible = True
            Chklist_Itemdetails.Visible = True
            Chklist_Category.Visible = True
            lbl_GroupList.Visible = True
            lbl_Itemlist.Visible = True
            Label6.Visible = True
            Label8.Visible = True
            PictureBox1.Visible = True
            PictureBox3.Visible = True
            Chk_SelectAllGroup.Visible = True
            Chk_SelectAllItem.Visible = True
            Chk_SelectAllcategory.Visible = True
        End If
    End Sub

    Private Sub TXT_MAINSTORECODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_MAINSTORECODE.TextChanged

    End Sub

    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "stocksummary"
        sqlstring = "select * from stocksummary"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub


    Private Sub Chk_SelectAllcategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllcategory.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllcategory.Checked = True Then
            For i = 0 To Chklist_Category.Items.Count - 1
                Chklist_Category.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To Chklist_Category.Items.Count - 1
                Chklist_Category.SetItemChecked(i, False)
            Next
            Chklist_Groupdesc.Items.Clear()
            Chklist_Itemdetails.Items.Clear()
            Chk_SelectAllGroup.Checked = False
            Chk_SelectAllItem.Checked = False
        End If
        Call Chklist_Category_SelectedIndexChanged(sender, e)

    End Sub

    Private Sub Chklist_Itemdetails_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chklist_Itemdetails.SelectedIndexChanged

    End Sub

    Private Sub Chklist_Category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chklist_Category.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.GROUPNAME,'') AS GROUPNAME FROM Inv_INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(VOID,'N') <> 'Y' "

        If Chklist_Category.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & " and I.CATEGORY IN ("
            For J = 0 To Chklist_Category.CheckedItems.Count - 1
                If J = Chklist_Category.CheckedItems.Count - 1 Then
                    ssql = ssql & " '" & Chklist_Category.CheckedItems(J) & "' "
                Else
                    ssql = ssql & " '" & Chklist_Category.CheckedItems(J) & "', "
                End If
            Next
            sqlstring = sqlstring & ssql & ") order by groupcode"

            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")

            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                Chklist_Groupdesc.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                        Chklist_Groupdesc.Items.Add(Trim(.Item("GROUPCODE") & "-->" & .Item("GROUPNAME")))
                    End With
                Next i
            Else
                Chklist_Groupdesc.Items.Clear()
            End If
        Else
            Chklist_Groupdesc.Items.Clear()
            Chk_SelectAllGroup.Checked = False
            Chk_SelectAllItem.Checked = False
        End If
        Chklist_Itemdetails.Items.Clear()
    End Sub

    Private Sub Chklist_Category_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chklist_Category.DoubleClick
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.GROUPNAME,'') AS GROUPNAME FROM INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' "

        If Chklist_Category.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & " and I.CATEGORY IN ("
            For J = 0 To Chklist_Category.CheckedItems.Count - 1
                If J = Chklist_Category.CheckedItems.Count - 1 Then
                    ssql = ssql & " '" & Chklist_Category.CheckedItems(J) & "' "
                Else
                    ssql = ssql & " '" & Chklist_Category.CheckedItems(J) & "', "
                End If
            Next
            sqlstring = sqlstring & ssql & ") order by groupcode"

            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")

            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                Chklist_Groupdesc.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                        Chklist_Groupdesc.Items.Add(Trim(.Item("GROUPCODE") & "-->" & .Item("GROUPNAME")))
                    End With
                Next i
            Else
                Chklist_Groupdesc.Items.Clear()
            End If
        Else
            Chklist_Groupdesc.Items.Clear()
        End If
        Chklist_Itemdetails.Items.Clear()
    End Sub

    Private Sub lbl_categoryList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_categoryList.Click

    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validation.Click
        System.Diagnostics.Process.Start(AppPath & "/STUDY/CATEGORYWISESTOCKSUMMARY.XLS")
    End Sub

    Private Sub Chklist_Category_KeyDown(sender As Object, e As KeyEventArgs) Handles Chklist_Category.KeyDown

    End Sub
End Class
