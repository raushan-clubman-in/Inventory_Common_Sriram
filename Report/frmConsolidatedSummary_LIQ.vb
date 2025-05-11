Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmConsolidatedLiquorSummary_LIQ
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
    Friend WithEvents cbo_Storelocation As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Storelocation As System.Windows.Forms.Label
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
    Friend WithEvents TXT_MAINSTORECODE As System.Windows.Forms.TextBox
    Friend WithEvents txt_Mainstore As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Mainstore As System.Windows.Forms.Label
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents cmd_itemto As System.Windows.Forms.Button
    Friend WithEvents txt_itemto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXT_FROM As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_ITEMFROM As System.Windows.Forms.Button
    Friend WithEvents Lbl_SubledgerCode As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CBO_SELECTALL As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    Friend WithEvents btn_validation As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsolidatedLiquorSummary_LIQ))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.cbo_Storelocation = New System.Windows.Forms.ComboBox()
        Me.lbl_Storelocation = New System.Windows.Forms.Label()
        Me.lbl_GroupList = New System.Windows.Forms.Label()
        Me.Chk_SelectAllGroup = New System.Windows.Forms.CheckBox()
        Me.Chklist_Groupdesc = New System.Windows.Forms.CheckedListBox()
        Me.lbl_Itemlist = New System.Windows.Forms.Label()
        Me.Chk_SelectAllItem = New System.Windows.Forms.CheckBox()
        Me.Chklist_Itemdetails = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.dtp_Fromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_Todate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.btn_validation = New System.Windows.Forms.Button()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox()
        Me.lbl_Wait = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.CHK_ZEROQTY = New System.Windows.Forms.CheckBox()
        Me.TXT_MAINSTORECODE = New System.Windows.Forms.TextBox()
        Me.txt_Mainstore = New System.Windows.Forms.TextBox()
        Me.lbl_Mainstore = New System.Windows.Forms.Label()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.cmd_itemto = New System.Windows.Forms.Button()
        Me.txt_itemto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXT_FROM = New System.Windows.Forms.TextBox()
        Me.Cmd_ITEMFROM = New System.Windows.Forms.Button()
        Me.Lbl_SubledgerCode = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CBO_SELECTALL = New System.Windows.Forms.CheckBox()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_SalebillChecklist.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(206, 84)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(311, 18)
        Me.lbl_Heading.TabIndex = 5
        Me.lbl_Heading.Text = "LIQUER ITEM CONSOLIDATED SUMMARY"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbo_Storelocation
        '
        Me.cbo_Storelocation.BackColor = System.Drawing.Color.Wheat
        Me.cbo_Storelocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Storelocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Storelocation.ItemHeight = 16
        Me.cbo_Storelocation.Location = New System.Drawing.Point(144, 672)
        Me.cbo_Storelocation.Name = "cbo_Storelocation"
        Me.cbo_Storelocation.Size = New System.Drawing.Size(158, 24)
        Me.cbo_Storelocation.TabIndex = 439
        Me.cbo_Storelocation.Visible = False
        '
        'lbl_Storelocation
        '
        Me.lbl_Storelocation.AutoSize = True
        Me.lbl_Storelocation.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Storelocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Storelocation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Storelocation.Location = New System.Drawing.Point(32, 680)
        Me.lbl_Storelocation.Name = "lbl_Storelocation"
        Me.lbl_Storelocation.Size = New System.Drawing.Size(90, 16)
        Me.lbl_Storelocation.TabIndex = 440
        Me.lbl_Storelocation.Text = "STORE LOC :"
        Me.lbl_Storelocation.Visible = False
        '
        'lbl_GroupList
        '
        Me.lbl_GroupList.BackColor = System.Drawing.Color.Maroon
        Me.lbl_GroupList.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupList.ForeColor = System.Drawing.Color.White
        Me.lbl_GroupList.Location = New System.Drawing.Point(209, 149)
        Me.lbl_GroupList.Name = "lbl_GroupList"
        Me.lbl_GroupList.Size = New System.Drawing.Size(288, 24)
        Me.lbl_GroupList.TabIndex = 438
        Me.lbl_GroupList.Text = "SELECT GROUPCODE :"
        '
        'Chk_SelectAllGroup
        '
        Me.Chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllGroup.Location = New System.Drawing.Point(209, 125)
        Me.Chk_SelectAllGroup.Name = "Chk_SelectAllGroup"
        Me.Chk_SelectAllGroup.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllGroup.TabIndex = 436
        Me.Chk_SelectAllGroup.Text = "SELECT ALL"
        Me.Chk_SelectAllGroup.UseVisualStyleBackColor = False
        '
        'Chklist_Groupdesc
        '
        Me.Chklist_Groupdesc.CheckOnClick = True
        Me.Chklist_Groupdesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_Groupdesc.Location = New System.Drawing.Point(209, 173)
        Me.Chklist_Groupdesc.Name = "Chklist_Groupdesc"
        Me.Chklist_Groupdesc.Size = New System.Drawing.Size(288, 340)
        Me.Chklist_Groupdesc.TabIndex = 437
        '
        'lbl_Itemlist
        '
        Me.lbl_Itemlist.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Itemlist.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemlist.ForeColor = System.Drawing.Color.White
        Me.lbl_Itemlist.Location = New System.Drawing.Point(510, 149)
        Me.lbl_Itemlist.Name = "lbl_Itemlist"
        Me.lbl_Itemlist.Size = New System.Drawing.Size(304, 24)
        Me.lbl_Itemlist.TabIndex = 435
        Me.lbl_Itemlist.Text = "SELECT ITEMCODE :"
        '
        'Chk_SelectAllItem
        '
        Me.Chk_SelectAllItem.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllItem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllItem.Location = New System.Drawing.Point(510, 125)
        Me.Chk_SelectAllItem.Name = "Chk_SelectAllItem"
        Me.Chk_SelectAllItem.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllItem.TabIndex = 433
        Me.Chk_SelectAllItem.Text = "SELECT ALL"
        Me.Chk_SelectAllItem.UseVisualStyleBackColor = False
        '
        'Chklist_Itemdetails
        '
        Me.Chklist_Itemdetails.CheckOnClick = True
        Me.Chklist_Itemdetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chklist_Itemdetails.Location = New System.Drawing.Point(510, 173)
        Me.Chklist_Itemdetails.Name = "Chklist_Itemdetails"
        Me.Chklist_Itemdetails.Size = New System.Drawing.Size(304, 340)
        Me.Chklist_Itemdetails.TabIndex = 434
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.PictureBox4)
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.dtp_Fromdate)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtp_Todate)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(224, 617)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(514, 64)
        Me.GroupBox3.TabIndex = 446
        Me.GroupBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(353, 18)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.TabIndex = 493
        Me.PictureBox4.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(106, 20)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 492
        Me.PictureBox2.TabStop = False
        '
        'dtp_Fromdate
        '
        Me.dtp_Fromdate.CustomFormat = "dd-MM-yyyy"
        Me.dtp_Fromdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Fromdate.Location = New System.Drawing.Point(145, 24)
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
        Me.Label1.Location = New System.Drawing.Point(283, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TO DATE :"
        '
        'dtp_Todate
        '
        Me.dtp_Todate.CustomFormat = "dd-MM-yyyy"
        Me.dtp_Todate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Todate.Location = New System.Drawing.Point(393, 24)
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
        Me.Label3.Location = New System.Drawing.Point(24, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "FROM DATE :"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.BackgroundImage = Global.Inventory.My.Resources.Resources.print
        Me.Cmd_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(861, 346)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_Print.TabIndex = 445
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
        Me.Cmd_View.Location = New System.Drawing.Point(863, 244)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_View.TabIndex = 442
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(860, 423)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_Exit.TabIndex = 443
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(864, 174)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_Clear.TabIndex = 441
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Location = New System.Drawing.Point(852, 157)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(152, 359)
        Me.frmbut.TabIndex = 444
        Me.frmbut.TabStop = False
        '
        'btn_validation
        '
        Me.btn_validation.BackColor = System.Drawing.Color.Transparent
        Me.btn_validation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_validation.ForeColor = System.Drawing.Color.Black
        Me.btn_validation.Location = New System.Drawing.Point(873, 624)
        Me.btn_validation.Name = "btn_validation"
        Me.btn_validation.Size = New System.Drawing.Size(104, 32)
        Me.btn_validation.TabIndex = 465
        Me.btn_validation.Text = "Validation"
        Me.btn_validation.UseVisualStyleBackColor = False
        Me.btn_validation.Visible = False
        '
        'chk_excel
        '
        Me.chk_excel.BackColor = System.Drawing.Color.Transparent
        Me.chk_excel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_excel.Location = New System.Drawing.Point(871, 309)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(104, 24)
        Me.chk_excel.TabIndex = 464
        Me.chk_excel.Text = "EXCEL"
        Me.chk_excel.UseVisualStyleBackColor = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.Transparent
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Location = New System.Drawing.Point(360, 664)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(104, 32)
        Me.cmd_export.TabIndex = 516
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
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(198, 620)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(579, 64)
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
        Me.ProgressBar1.Size = New System.Drawing.Size(560, 32)
        Me.ProgressBar1.TabIndex = 0
        '
        'CHK_ZEROQTY
        '
        Me.CHK_ZEROQTY.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ZEROQTY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_ZEROQTY.Location = New System.Drawing.Point(8, 16)
        Me.CHK_ZEROQTY.Name = "CHK_ZEROQTY"
        Me.CHK_ZEROQTY.Size = New System.Drawing.Size(96, 24)
        Me.CHK_ZEROQTY.TabIndex = 449
        Me.CHK_ZEROQTY.Text = "ZERO QTY"
        Me.CHK_ZEROQTY.UseVisualStyleBackColor = False
        '
        'TXT_MAINSTORECODE
        '
        Me.TXT_MAINSTORECODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_MAINSTORECODE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_MAINSTORECODE.Location = New System.Drawing.Point(66, 15)
        Me.TXT_MAINSTORECODE.MaxLength = 15
        Me.TXT_MAINSTORECODE.Name = "TXT_MAINSTORECODE"
        Me.TXT_MAINSTORECODE.Size = New System.Drawing.Size(64, 21)
        Me.TXT_MAINSTORECODE.TabIndex = 500
        Me.TXT_MAINSTORECODE.Visible = False
        '
        'txt_Mainstore
        '
        Me.txt_Mainstore.BackColor = System.Drawing.Color.Wheat
        Me.txt_Mainstore.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Mainstore.Enabled = False
        Me.txt_Mainstore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Mainstore.Location = New System.Drawing.Point(199, 15)
        Me.txt_Mainstore.MaxLength = 15
        Me.txt_Mainstore.Name = "txt_Mainstore"
        Me.txt_Mainstore.ReadOnly = True
        Me.txt_Mainstore.Size = New System.Drawing.Size(235, 21)
        Me.txt_Mainstore.TabIndex = 498
        Me.txt_Mainstore.Visible = False
        '
        'lbl_Mainstore
        '
        Me.lbl_Mainstore.AutoSize = True
        Me.lbl_Mainstore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Mainstore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Mainstore.Location = New System.Drawing.Point(6, 19)
        Me.lbl_Mainstore.Name = "lbl_Mainstore"
        Me.lbl_Mainstore.Size = New System.Drawing.Size(55, 15)
        Me.lbl_Mainstore.TabIndex = 497
        Me.lbl_Mainstore.Text = " STORE :"
        Me.lbl_Mainstore.Visible = False
        '
        'cmd_storecode
        '
        Me.cmd_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(131, 12)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 499
        Me.cmd_storecode.Visible = False
        '
        'cmd_itemto
        '
        Me.cmd_itemto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_itemto.Image = CType(resources.GetObject("cmd_itemto.Image"), System.Drawing.Image)
        Me.cmd_itemto.Location = New System.Drawing.Point(349, 13)
        Me.cmd_itemto.Name = "cmd_itemto"
        Me.cmd_itemto.Size = New System.Drawing.Size(23, 26)
        Me.cmd_itemto.TabIndex = 506
        '
        'txt_itemto
        '
        Me.txt_itemto.BackColor = System.Drawing.Color.Wheat
        Me.txt_itemto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_itemto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_itemto.Location = New System.Drawing.Point(250, 16)
        Me.txt_itemto.MaxLength = 20
        Me.txt_itemto.Name = "txt_itemto"
        Me.txt_itemto.Size = New System.Drawing.Size(96, 21)
        Me.txt_itemto.TabIndex = 505
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(222, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 15)
        Me.Label5.TabIndex = 504
        Me.Label5.Text = "TO:"
        '
        'TXT_FROM
        '
        Me.TXT_FROM.BackColor = System.Drawing.Color.Wheat
        Me.TXT_FROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_FROM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_FROM.Location = New System.Drawing.Point(90, 17)
        Me.TXT_FROM.MaxLength = 20
        Me.TXT_FROM.Name = "TXT_FROM"
        Me.TXT_FROM.Size = New System.Drawing.Size(96, 21)
        Me.TXT_FROM.TabIndex = 502
        '
        'Cmd_ITEMFROM
        '
        Me.Cmd_ITEMFROM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_ITEMFROM.Image = CType(resources.GetObject("Cmd_ITEMFROM.Image"), System.Drawing.Image)
        Me.Cmd_ITEMFROM.Location = New System.Drawing.Point(191, 13)
        Me.Cmd_ITEMFROM.Name = "Cmd_ITEMFROM"
        Me.Cmd_ITEMFROM.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_ITEMFROM.TabIndex = 503
        '
        'Lbl_SubledgerCode
        '
        Me.Lbl_SubledgerCode.AutoSize = True
        Me.Lbl_SubledgerCode.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubledgerCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubledgerCode.Location = New System.Drawing.Point(9, 19)
        Me.Lbl_SubledgerCode.Name = "Lbl_SubledgerCode"
        Me.Lbl_SubledgerCode.Size = New System.Drawing.Size(76, 15)
        Me.Lbl_SubledgerCode.TabIndex = 501
        Me.Lbl_SubledgerCode.Text = "ITEM  FROM:"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Maroon
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(465, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 24)
        Me.Label9.TabIndex = 508
        Me.Label9.Text = "F2"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Maroon
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(782, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 24)
        Me.Label6.TabIndex = 509
        Me.Label6.Text = "F3"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(433, 149)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.TabIndex = 510
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(750, 149)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.TabIndex = 511
        Me.PictureBox3.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TXT_MAINSTORECODE)
        Me.GroupBox1.Controls.Add(Me.cmd_storecode)
        Me.GroupBox1.Controls.Add(Me.lbl_Mainstore)
        Me.GroupBox1.Controls.Add(Me.txt_Mainstore)
        Me.GroupBox1.Location = New System.Drawing.Point(273, 514)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(456, 50)
        Me.GroupBox1.TabIndex = 512
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(159, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 24)
        Me.Label16.TabIndex = 501
        Me.Label16.Text = "F4"
        Me.Label16.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Lbl_SubledgerCode)
        Me.GroupBox2.Controls.Add(Me.TXT_FROM)
        Me.GroupBox2.Controls.Add(Me.Cmd_ITEMFROM)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txt_itemto)
        Me.GroupBox2.Controls.Add(Me.cmd_itemto)
        Me.GroupBox2.Location = New System.Drawing.Point(312, 566)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(382, 52)
        Me.GroupBox2.TabIndex = 513
        Me.GroupBox2.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CHK_ZEROQTY)
        Me.GroupBox4.Location = New System.Drawing.Point(702, 566)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(112, 54)
        Me.GroupBox4.TabIndex = 514
        Me.GroupBox4.TabStop = False
        '
        'CBO_SELECTALL
        '
        Me.CBO_SELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CBO_SELECTALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBO_SELECTALL.Location = New System.Drawing.Point(456, 664)
        Me.CBO_SELECTALL.Name = "CBO_SELECTALL"
        Me.CBO_SELECTALL.Size = New System.Drawing.Size(104, 32)
        Me.CBO_SELECTALL.TabIndex = 515
        Me.CBO_SELECTALL.Text = "FOR SELECT ALL"
        Me.CBO_SELECTALL.UseVisualStyleBackColor = False
        Me.CBO_SELECTALL.Visible = False
        '
        'frmConsolidatedLiquorSummary_LIQ
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res
        Me.ClientSize = New System.Drawing.Size(1016, 694)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_validation)
        Me.Controls.Add(Me.CBO_SELECTALL)
        Me.Controls.Add(Me.chk_excel)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbl_Storelocation)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.cbo_Storelocation)
        Me.Controls.Add(Me.lbl_GroupList)
        Me.Controls.Add(Me.Chk_SelectAllGroup)
        Me.Controls.Add(Me.Chklist_Groupdesc)
        Me.Controls.Add(Me.lbl_Itemlist)
        Me.Controls.Add(Me.Chk_SelectAllItem)
        Me.Controls.Add(Me.Chklist_Itemdetails)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmd_export)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmConsolidatedLiquorSummary_LIQ"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORT [  CONSOLIDATED SUMMARY ]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.grp_SalebillChecklist.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Public pageno, pagesize As Integer
    Dim dr As DataRow
    Dim zeroval As Double
    Private Sub FillStore()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT ISNULL(STOREDESC,'') AS STOREDESC FROM STOREMASTER ORDER BY STOREDESC ASC"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        cbo_Storelocation.Items.Clear()
        cbo_Storelocation.Sorted = True
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
        sqlstring = "SELECT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPDESC,'') AS GROUPDESC FROM INVENTORYGROUPMASTER  WHERE GROUPCODE IN (SELECT DISTINCT GROUPCODE  FROM INVENTORYITEMMASTER )ORDER BY GROUPCODE  "
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
        If CBO_SELECTALL.Checked = False Then
            If Chklist_Groupdesc.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Chklist_Itemdetails.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Sub Group Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        gPrint = False
        grp_SalebillChecklist.Top = 620
        grp_SalebillChecklist.Left = 198
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 10
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click

        If CBO_SELECTALL.Checked = False Then
            If Chklist_Groupdesc.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Chklist_Itemdetails.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        gPrint = True
        grp_SalebillChecklist.Top = 620
        grp_SalebillChecklist.Left = 198
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 100
        Me.Timer1.Enabled = True

    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        dtp_Fromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
        dtp_Todate.Value = Format(Now, "dd/MM/yyyy")
        grp_SalebillChecklist.Top = 1000
        Chklist_Groupdesc.Items.Clear()
        Chklist_Itemdetails.Items.Clear()
        txt_Mainstore.Text = ""
        TXT_MAINSTORECODE.Text = ""
        TXT_FROM.Text = ""
        txt_itemto.Text = ""
        Call FillGroupdetails()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        TXT_MAINSTORECODE.Focus()
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
        'sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        If Chklist_Groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
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
        'sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        If Chklist_Groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
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
    Private Sub frmConsolidatedLiquorSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Chklist_Groupdesc.Items.Clear()
        Chklist_Itemdetails.Items.Clear()
        dtp_Fromdate.Value = Format(CDate("04/01/" & gFinancalyearStart), "dd/MMM/yyyy")
        dtp_Todate.Value = Format(Now, "dd/MMM/yyyy")
        grp_SalebillChecklist.Top = 1000
        Call FillGroupdetails()
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
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 1
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_SalebillChecklist.Top = 1000
            Call ViewSummary()
        End If
    End Sub
    Public Sub ViewSummary()
        Try
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim Boolupdate As Boolean
            Dim I As Integer
            Storecode = "" : Clsquantity = "" : I = 0
            Dim SLSTRING As String
            Dim rViewer As New Viewer
            Dim r As New Rpt_ConsolidatedSummary_LIQ

            'sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STORECODE = '" & Trim(TXT_MAINSTORECODE.Text) & "'"
            'gconnection.getDataSet(sqlstring, "STOREMASTER")
            'If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            '    Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
            'Else
            '    Storecode = "MNS"
            'End If

            If TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                sqlstring = "Update inventoryitemmaster set selectopt='N'"
                gconnection.dataOperation(6, sqlstring, "ItemMaster")
                sqlstring = "Update inventoryitemmaster set selectopt='Y' WHERE ITEMCODE BETWEEN '" & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "'"
                gconnection.dataOperation(6, sqlstring, "ItemMaster")
            Else

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
            End If

            'sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(txt_Mainstore.Text) & "'"
            'gconnection.getDataSet(sqlstring, "STOREMASTER")
            'If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            '    Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")

            '---------------------- EXECUTE STORE PROCEDURE --------------------------'
            gconnection.openConnection()

            gcommand = New SqlCommand("Cp_StockSummary3_cons", gconnection.Myconn)
            gcommand.CommandTimeout = 1000000000
            gcommand.CommandType = CommandType.StoredProcedure
            'gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
            gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_Fromdate.Value), "dd/MM/yyyy")
            gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_Todate.Value), "dd/MM/yyyy")
            gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
            gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(dtp_Todate.Value), "yyyy/MM/dd")

            gcommand.ExecuteNonQuery()
            gconnection.closeConnection()
            '--------------------------------------------------------------------------'
            'Else
            '    MessageBox.Show("Select the Store Loc.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If

            sqlstring = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE,ISNULL(S.ITEMNAME,'') AS ITEMNAME,"
            sqlstring = sqlstring & " ISNULL(S.UOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,ISNULL(I.GROUPCODE,'') AS GROUPCODE,"
            sqlstring = sqlstring & "SUM(ISNULL(S.OPQTY,0.000)) AS OPQTY,SUM(ISNULL(S.OPVAL,0.000)) AS OPVAL, "
            sqlstring = sqlstring & " SUM(ISNULL(S.RCVQTY,0.000)) AS RCVQTY,SUM(ISNULL(S.RCVVAL,0.000)) AS RCVVAL,"
            sqlstring = sqlstring & "SUM(ISNULL(S.RCVQTY1,0.000)) AS RCVQTY1,SUM(ISNULL(S.RCVVAL1,0.000)) AS RCVVAL1,"
            sqlstring = sqlstring & " SUM(ISNULL(S.RCVQTY2,0.000)) AS RCVQTY2,SUM(ISNULL(S.RCVVAL2,0.000)) AS RCVVAL2,"
            sqlstring = sqlstring & " SUM(ISNULL(S.RCVQTY3,0.000)) AS RCVQTY3,SUM(ISNULL(S.RCVVAL3,0.000)) AS RCVVAL3,"
            sqlstring = sqlstring & "SUM(ISNULL(S.ISSQTY,0.000)) AS ISSQTY,SUM(ISNULL(S.ISSVAL,0.000)) AS ISSVAL,"
            sqlstring = sqlstring & "SUM(ISNULL(S.ISSQTY1,0.000)) AS ISSQTY1,SUM(ISNULL(S.ISSVAL1,0.000)) AS ISSVAL1,"
            sqlstring = sqlstring & "SUM(ISNULL(S.ISSQTY2,0.000)) AS ISSQTY2,SUM(ISNULL(S.ISSVAL2,0.000)) AS ISSVAL2,"
            sqlstring = sqlstring & "SUM(ISNULL(S.ISSQTY3,0.000)) AS ISSQTY3,SUM(ISNULL(S.ISSVAL3,0.000)) AS ISSVAL3,"
            sqlstring = sqlstring & "SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSVAL,0.00)) AS CLSVAL, ISNULL(S.CLSRATE,0.00) AS CLSRATE ,SUM(isnull(S.dmgqty,0.000)) as dmgqty,SUM(ISNULL(S.ADJQTY,0.000)) AS ADJQTY,SUM(ISNULL(S.ALTQTY,0.000)) AS ALTQTY,"
            sqlstring = sqlstring & "SUM(ISNULL(S.DISPQTY,0)) AS DISPQTY FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "

            If Chklist_Itemdetails.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                ' sqlstring = sqlstring & " WHERE I.ITEMCODE=s.ITEMCODE "
                sqlstring = sqlstring & " where  I.ITEMCODE=S.ITEMCODE AND S.ITEMCODE  BETWEEN '"
                sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
            Else

                If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE I.ITEMCODE=S.ITEMCODE AND S.ITEMCODE IN ("
                    For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                        Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                        sqlstring = sqlstring & "'" & Itemcode(0) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    'sqlstring = sqlstring & ") and I.storecode=s.storecode "
                    sqlstring = sqlstring & ") and I.STORECODE='MNS' "
                Else
                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            If CHK_ZEROQTY.Checked = False Then
                sqlstring = sqlstring & " And (OPQTY <> 0 OR RCVQTY <> 0 OR ISSQTY <> 0)"
            End If

            sqlstring = sqlstring & " GROUP BY ISNULL(S.ITEMCODE,''),ISNULL(S.ITEMNAME,''),ISNULL(S.UOM,''), ISNULL(I.GROUPNAME,''),ISNULL(I.GROUPCODE,'') , S.CLSRATE ORDER BY GROUPNAME,ITEMNAME"
            Dim heading() As String = {"CONSOLIDATED SUMMARY" & "[ " & Trim(cbo_Storelocation.Text) & " ]"}


            '   If MsgBox("Click 'YES' for Crystal View or 'NO' for Text View", MsgBoxStyle.YesNo, "Issue Summary") = MsgBoxResult.Yes Then
            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                If chk_excel.Checked = True Then
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "CONSOLIDATE SUMMARY " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                Else
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "CONSOLIDATEDSUMMARY"
                    'rViewer.GetDetails(sqlstring, "STOCKSUMMARY", r)
                    'rViewer.GetDetails(sqlstring, "INVENTORYITEMMASTER", r)




                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text6")
                    textobj1.Text = MyCompanyName

                    'Dim textobj2 As TextObject
                    'textobj2 = r.ReportDefinition.ReportObjects("Text12")
                    'textobj2.Text = Trim(txt_Mainstore.Text)

                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text10")
                    textobj6.Text = UCase(gCompanyAddress(0))

                    Dim textobj7 As TextObject
                    textobj7 = r.ReportDefinition.ReportObjects("Text18")
                    textobj7.Text = UCase(gCompanyAddress(1))

                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                    TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""
                    If MyCompanyName = "THE BENGAL CLUB" Then
                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text20")
                        textobj3.Text = ""
                    End If
                    rViewer.Show()
                End If
            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OKOnly)
            End If
            '  Else
            '   Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            '  End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub StkSummary_crystal()
        Try
            Dim str, MTYPE(), tspilt() As String
            Dim i As Integer
            Dim rViewer As New Viewer
            Dim r As New Rpt_stk_summary
            Dim Heading(0) As String
            Dim sqlstring, SSQL As String

            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim Boolupdate As Boolean
            Storecode = "" : Clsquantity = "" : i = 0
            Dim SLSTRING As String

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
                gcommand = New SqlCommand("CP_STOCKSUMMARY_PURSRATE", gconnection.Myconn)
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
            sqlstring = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE,ISNULL(S.ITEMNAME,'') AS ITEMNAME,ISNULL(S.UOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,ISNULL(I.GROUPCODE,'') AS GROUPCODE,"
            sqlstring = sqlstring & "SUM(ISNULL(S.OPQTY,0.000)) AS OPQTY,SUM(ISNULL(S.OPVAL,0.000)) AS OPVAL, SUM(ISNULL(S.RCVQTY,0.000)) AS RCVQTY,SUM(ISNULL(S.RCVVAL,0.000)) AS RCVVAL,SUM(ISNULL(S.RCVQTY1,0.000)) AS RCVQTY1,SUM(ISNULL(S.RCVVAL1,0.000)) AS RCVVAL1,SUM(ISNULL(S.RCVQTY2,0.000)) AS RCVQTY2,SUM(ISNULL(S.RCVVAL2,0.000)) AS RCVVAL2,SUM(ISNULL(S.RCVQTY3,0.000)) AS RCVQTY3,SUM(ISNULL(S.RCVVAL3,0.000)) AS RCVVAL3,SUM(ISNULL(S.ISSQTY,0.000)) AS ISSQTY,SUM(ISNULL(S.ISSVAL,0.000)) AS ISSVAL,SUM(ISNULL(S.ISSQTY1,0.000)) AS ISSQTY1,SUM(ISNULL(S.ISSVAL1,0.000)) AS ISSVAL1,SUM(ISNULL(S.ISSQTY2,0.000)) AS ISSQTY2,SUM(ISNULL(S.ISSVAL2,0.000)) AS ISSVAL2,SUM(ISNULL(S.ISSQTY3,0.000)) AS ISSQTY3,SUM(ISNULL(S.ISSVAL3,0.000)) AS ISSVAL3,SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSRATE,0.00)) CLSRATE, SUM(ISNULL(S.CLSVAL,0.00)) AS VALUE,SUM(ISNULL(S.DISPQTY,0)) AS DISPQTY FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "

            If Chklist_Itemdetails.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                sqlstring = sqlstring & " where  I.ITEMCODE=S.ITEMCODE AND S.ITEMCODE  BETWEEN '"
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
            sqlstring = sqlstring & " GROUP BY ISNULL(S.ITEMCODE,''),ISNULL(S.ITEMNAME,''),ISNULL(S.UOM,''), ISNULL(I.GROUPNAME,'') ORDER BY I.GROUPNAME,S.ITEMNAME"
            If chk_excel.Checked = True Then
                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "CONSOLIDATE SUMMARY " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
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

    Private Function Reportdetails(ByVal SQLSTRING As String, ByVal PAGEHEAD() As String, ByVal FROMDATE As Date, ByVal TODATE As Date)
        Dim dbldocTotal, dblGroupTotal, dblGrandTotal As Double
        Dim ITEMCODE, DOCDETAILS, GROUPNAME As String
        Dim ITEMBOOL, DOCBOOL As Boolean
        Dim opval, issval, closeval, rcval, groupvalue As Double
        Dim Topval, Tissval, Tcloseval, Trcval, Tgroupvalue As Double
        Dim I As Integer

        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            opval = 0
            rcval = 0
            issval = 0
            closeval = 0
            groupvalue = 0
            Topval = 0
            Trcval = 0
            Tissval = 0
            Tcloseval = 0
            Tgroupvalue = 0
            'Filewrite.Write(Chr(15))
            Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
            gconnection.getDataSet(SQLSTRING, "STOCKSUMMARYREPORT")
            If gdataset.Tables("STOCKSUMMARYREPORT").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                GROUPNAME = Trim(gdataset.Tables("stocksummaryreport").Rows(0).Item("GROUPNAME"))
                Filewrite.WriteLine()
                Filewrite.WriteLine(GROUPNAME)
                Filewrite.WriteLine()
                pagesize = pagesize + 3
                Dim SNO As Integer
                SNO = 1
                For Each dr In gdataset.Tables("STOCKSUMMARYREPORT").Rows
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(83, "-"))
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(PAGEHEAD, FROMDATE, TODATE)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    If GROUPNAME <> Trim(CStr(dr("GROUPNAME"))) Then
                        GROUPNAME = Trim(CStr(dr("GROUPNAME")))
                        '''Filewrite.WriteLine(StrDup(83, "."))
                        'Filewrite.WriteLine("{0,54}{1,12}{2,12}{3,12}{4,12}{5,12}", " TOTAL =======>        ", Format(opval, "0.000"), Format(rcval, "0.000"), Format(issval, "0.000"), Format(closeval, "0.000"), Format(groupvalue, "0.00"))
                        '''Filewrite.WriteLine(Space(37) & "TOTAL =======>" & Space(20 - Len(Format(closeval, "0.000"))) & Format(closeval, "0.000") & Space(12 - Len(Format(groupvalue, "0.00"))) & Format(groupvalue, "0.00"))
                        Topval = Topval + opval
                        Tgroupvalue = Tgroupvalue + groupvalue
                        Trcval = Trcval + rcval
                        Tissval = Tissval + issval
                        Tcloseval = Tcloseval + closeval
                        '''Filewrite.WriteLine(StrDup(83, "."))
                        '''Filewrite.WriteLine()
                        opval = 0
                        rcval = 0
                        issval = 0
                        closeval = 0
                        groupvalue = 0
                        '''Filewrite.WriteLine()
                        '''Filewrite.WriteLine(GROUPNAME)
                        '''Filewrite.WriteLine()
                        pagesize = pagesize + 7
                    End If
                    zeroval = 0
                    Filewrite.Write(SNO & Space(5 - Len(Trim(SNO))))
                    Filewrite.Write("{0,-8}", Mid(Trim(CStr(dr("ITEMCODE"))), 1, 8))
                    Filewrite.Write("{0,-30}", Mid(Trim(CStr(dr("ITEMNAME"))), 1, 30))
                    Filewrite.Write("{0,-1}", "")
                    Filewrite.Write("{0,-10}", Mid(Trim(CStr(dr("UOM"))), 1, 10))
                    If Val(dr("CLSVAL")) <> 0 And Val(dr("CLSQTY")) <> 0 Then
                        Filewrite.Write("{0,12}", Mid(Format(Val(dr("CLSVAL")) / Val(dr("CLSQTY")), "0.00"), 1, 12))
                    Else
                        Filewrite.Write("{0,12}", Mid(Format(zeroval, "0.00"), 1, 12))
                    End If

                    'Filewrite.Write("{0,12}", Mid(Format(Val(dr("OPQTY")), "0.000"), 1, 12))
                    opval = opval + Val(dr("opqty"))
                    'Filewrite.Write("{0,12}", Mid(Format(Val(dr("RCVQTY")), "0.000"), 1, 12))
                    rcval = rcval + Val(dr("rcvqty"))
                    'Filewrite.Write("{0,12}", Mid(Format(Val(dr("ISSQTY")), "0.000"), 1, 12))
                    issval = issval + Val(dr("issqty"))
                    Filewrite.Write("{0,12}", Mid(Format(Val(dr("CLSQTY")), "0.000"), 1, 12))
                    closeval = closeval + Val(dr("clsqty"))
                    Filewrite.WriteLine("{0,12}", Mid(Format(Val(dr("CLSVAL")), "0.00"), 1, 12))
                    groupvalue = groupvalue + Val(dr("CLSVAL"))
                    dblGrandTotal = dblGrandTotal + Format(Val(dr("CLSVAL")), "0.00")
                    pagesize = pagesize + 1
                    SNO = SNO + 1
                Next dr
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(90, "."))
                Filewrite.WriteLine(Space(44) & "TOTAL =======>" & Space(20 - Len(Format(closeval, "0.000"))) & Format(closeval, "0.000") & Space(12 - Len(Format(groupvalue, "0.00"))) & Format(groupvalue, "0.00"))
                Topval = Topval + opval
                Tgroupvalue = Tgroupvalue + groupvalue
                Trcval = Trcval + rcval
                Tissval = Tissval + issval
                Tcloseval = Tcloseval + closeval
                Filewrite.WriteLine(StrDup(90, "."))
                Filewrite.WriteLine(StrDup(90, "="))
                pagesize = pagesize + 1
                'Filewrite.WriteLine("{0,54}{1,12}{2,12}{3,12}{4,12}{5,12}", "GRAND TOTAL =======>        ", Format(Topval, "0.000"), Format(Trcval, "0.000"), Format(Tissval, "0.000"), Format(Tcloseval, "0.000"), Format(Tgroupvalue, "0.00"))
                Filewrite.WriteLine(Space(38) & "GRAND TOTAL =======>" & Space(20 - Len(Format(Tcloseval, "0.000"))) & Format(Tcloseval, "0.000") & Space(12 - Len(Format(Tgroupvalue, "0.00"))) & Format(Tgroupvalue, "0.00"))
                pagesize = pagesize + 2
                Filewrite.WriteLine(StrDup(90, "="))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Function
        End Try
    End Function
    Private Function PrintHeader(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine(Chr(18))
            Filewrite.WriteLine(Space(55) & "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine(Mid(MyCompanyName, 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Mid(Address1, 1, 30) & Space(22) & Mid(Trim(Heading(0)), 1, 40))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Mid(Address2, 1, 30))
            pagesize = pagesize + 1
            'Filewrite.WriteLine("{0,64}{1,-10}", " ", "DETAILS")
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(60) & "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.Write("{0,-30}{1,87}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ")
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(90, "-"))
            pagesize = pagesize + 1
            'Filewrite.WriteLine("ITEM" & Space(10) & "ITEM" & Space(15) & "UOM" & Space(12) & "RATE" & Space(6) & "CLOSING" & Space(6) & "VALUE")
            Filewrite.WriteLine(" SNO ITEM          ITEM                     UOM            RATE      CLOSING      VALUE")
            pagesize = pagesize + 1
            'Filewrite.WriteLine("CODE" & Space(10) & "DESCRIPTION" & Space(10) & Space(25) & "QTY")
            Filewrite.WriteLine("     CODE          DESCRIPTION                                         QTY")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(90, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Private Sub cbo_Storelocation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_Storelocation.KeyPress
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
                ' Call Cmd_ITEMFROM_Click(sender, e)
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
            'cbo_Tostore.Focus()
            TXT_FROM.Focus()
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
                'cbo_Tostore.Focus()
                TXT_FROM.Focus()
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
                    Call FillGroupdetails()
                    ' cbo_Tostore.Focus()
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

    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "stocksummary"
        sqlstring = "select * from stocksummary"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validation.Click
        System.Diagnostics.Process.Start(AppPath & "/STUDY/CONSOLIDATEDSUMMARY.XLS")
    End Sub
End Class
