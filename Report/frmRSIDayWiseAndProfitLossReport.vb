Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Public Class frmRSIDayWiseAndProfitLossReport
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllStore As System.Windows.Forms.CheckBox
    Friend WithEvents chklst_Store As System.Windows.Forms.CheckedListBox
    Friend WithEvents grp_SalebillChecklist As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents grp_orderby As System.Windows.Forms.GroupBox
    Friend WithEvents rdo_name As System.Windows.Forms.RadioButton
    Friend WithEvents rdo_code As System.Windows.Forms.RadioButton
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_todate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_fromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chklist_groupdesc As System.Windows.Forms.CheckedListBox
    Friend WithEvents chk_SelectAllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllItem As System.Windows.Forms.CheckBox
    Friend WithEvents chklist_itemdetails As System.Windows.Forms.CheckedListBox
    Friend WithEvents lbl_Itemlist As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkDayWiseSummary As System.Windows.Forms.CheckBox
    Friend WithEvents ChkProfitAndLoss As System.Windows.Forms.CheckBox
    Friend WithEvents ChkStoreWiseClosingStockReport As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSalesStatement As System.Windows.Forms.CheckBox
    Friend WithEvents btn_validation As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRSIDayWiseAndProfitLossReport))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllStore = New System.Windows.Forms.CheckBox()
        Me.chklst_Store = New System.Windows.Forms.CheckedListBox()
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox()
        Me.lbl_Wait = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtp_todate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_fromdate = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.btn_validation = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grp_orderby = New System.Windows.Forms.GroupBox()
        Me.rdo_name = New System.Windows.Forms.RadioButton()
        Me.rdo_code = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllItem = New System.Windows.Forms.CheckBox()
        Me.chklist_itemdetails = New System.Windows.Forms.CheckedListBox()
        Me.lbl_Itemlist = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chklist_groupdesc = New System.Windows.Forms.CheckedListBox()
        Me.chk_SelectAllGroup = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChkSalesStatement = New System.Windows.Forms.CheckBox()
        Me.ChkStoreWiseClosingStockReport = New System.Windows.Forms.CheckBox()
        Me.ChkProfitAndLoss = New System.Windows.Forms.CheckBox()
        Me.ChkDayWiseSummary = New System.Windows.Forms.CheckBox()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmbut.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_orderby.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Location = New System.Drawing.Point(247, 20)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(126, 22)
        Me.lbl_Heading.TabIndex = 23
        Me.lbl_Heading.Text = "RSI REPORT"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Maroon
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(209, 24)
        Me.Label4.TabIndex = 447
        Me.Label4.Text = "STORE SELECTION :"
        '
        'Chk_SelectAllStore
        '
        Me.Chk_SelectAllStore.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllStore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllStore.Location = New System.Drawing.Point(10, 22)
        Me.Chk_SelectAllStore.Name = "Chk_SelectAllStore"
        Me.Chk_SelectAllStore.Size = New System.Drawing.Size(202, 24)
        Me.Chk_SelectAllStore.TabIndex = 446
        Me.Chk_SelectAllStore.Text = "SELECT ALL "
        Me.Chk_SelectAllStore.UseVisualStyleBackColor = False
        '
        'chklst_Store
        '
        Me.chklst_Store.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklst_Store.Location = New System.Drawing.Point(8, 68)
        Me.chklst_Store.Name = "chklst_Store"
        Me.chklst_Store.Size = New System.Drawing.Size(208, 308)
        Me.chklst_Store.TabIndex = 445
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.BackColor = System.Drawing.Color.Transparent
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(38, 516)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(667, 54)
        Me.grp_SalebillChecklist.TabIndex = 452
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(288, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 15)
        Me.Label1.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(38, 519)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(644, 32)
        Me.ProgressBar1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_todate)
        Me.GroupBox3.Controls.Add(Me.dtp_fromdate)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(38, 565)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(667, 51)
        Me.GroupBox3.TabIndex = 453
        Me.GroupBox3.TabStop = False
        '
        'dtp_todate
        '
        Me.dtp_todate.CustomFormat = "dd MM yyyy"
        Me.dtp_todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_todate.Location = New System.Drawing.Point(407, 18)
        Me.dtp_todate.Name = "dtp_todate"
        Me.dtp_todate.Size = New System.Drawing.Size(109, 21)
        Me.dtp_todate.TabIndex = 495
        '
        'dtp_fromdate
        '
        Me.dtp_fromdate.CustomFormat = "dd MM yyyy"
        Me.dtp_fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_fromdate.Location = New System.Drawing.Point(145, 17)
        Me.dtp_fromdate.Name = "dtp_fromdate"
        Me.dtp_fromdate.Size = New System.Drawing.Size(116, 21)
        Me.dtp_fromdate.TabIndex = 494
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(107, 12)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox3.TabIndex = 493
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(370, 15)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 492
        Me.PictureBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(296, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TO DATE :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
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
        Me.Cmd_Print.Location = New System.Drawing.Point(6, 114)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Print.TabIndex = 450
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
        Me.Cmd_View.Location = New System.Drawing.Point(6, 64)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_View.TabIndex = 449
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(6, 15)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Clear.TabIndex = 448
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.Cmd_View)
        Me.frmbut.Controls.Add(Me.Cmd_Print)
        Me.frmbut.Controls.Add(Me.chk_excel)
        Me.frmbut.Controls.Add(Me.Cmd_Exit)
        Me.frmbut.Controls.Add(Me.Cmd_Clear)
        Me.frmbut.Location = New System.Drawing.Point(739, 130)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(159, 250)
        Me.frmbut.TabIndex = 451
        Me.frmbut.TabStop = False
        '
        'chk_excel
        '
        Me.chk_excel.BackColor = System.Drawing.Color.Transparent
        Me.chk_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.chk_excel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chk_excel.Location = New System.Drawing.Point(6, 215)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(74, 31)
        Me.chk_excel.TabIndex = 464
        Me.chk_excel.Text = "EXCEL"
        Me.chk_excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_excel.UseVisualStyleBackColor = False
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(6, 163)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Exit.TabIndex = 455
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'btn_validation
        '
        Me.btn_validation.BackColor = System.Drawing.Color.Transparent
        Me.btn_validation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_validation.ForeColor = System.Drawing.Color.Black
        Me.btn_validation.Location = New System.Drawing.Point(737, 615)
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
        Me.cmd_export.Location = New System.Drawing.Point(223, 642)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(104, 32)
        Me.cmd_export.TabIndex = 450
        Me.cmd_export.Text = "Export"
        Me.cmd_export.UseVisualStyleBackColor = False
        Me.cmd_export.Visible = False
        '
        'Timer1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox1.Location = New System.Drawing.Point(161, 43)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.TabIndex = 472
        Me.PictureBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Maroon
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(185, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 24)
        Me.Label8.TabIndex = 473
        Me.Label8.Text = "F3"
        '
        'grp_orderby
        '
        Me.grp_orderby.BackColor = System.Drawing.Color.Transparent
        Me.grp_orderby.Controls.Add(Me.rdo_name)
        Me.grp_orderby.Controls.Add(Me.rdo_code)
        Me.grp_orderby.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_orderby.Location = New System.Drawing.Point(739, 528)
        Me.grp_orderby.Name = "grp_orderby"
        Me.grp_orderby.Size = New System.Drawing.Size(143, 66)
        Me.grp_orderby.TabIndex = 497
        Me.grp_orderby.TabStop = False
        Me.grp_orderby.Text = "Order By"
        '
        'rdo_name
        '
        Me.rdo_name.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo_name.Location = New System.Drawing.Point(14, 38)
        Me.rdo_name.Name = "rdo_name"
        Me.rdo_name.Size = New System.Drawing.Size(96, 23)
        Me.rdo_name.TabIndex = 1
        Me.rdo_name.Text = " Name"
        '
        'rdo_code
        '
        Me.rdo_code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdo_code.Location = New System.Drawing.Point(14, 16)
        Me.rdo_code.Name = "rdo_code"
        Me.rdo_code.Size = New System.Drawing.Size(88, 23)
        Me.rdo_code.TabIndex = 0
        Me.rdo_code.Text = "Item Code"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.PictureBox5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Chk_SelectAllItem)
        Me.GroupBox1.Controls.Add(Me.chklist_itemdetails)
        Me.GroupBox1.Controls.Add(Me.lbl_Itemlist)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.chklist_groupdesc)
        Me.GroupBox1.Controls.Add(Me.chk_SelectAllGroup)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Chk_SelectAllStore)
        Me.GroupBox1.Controls.Add(Me.chklst_Store)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(669, 388)
        Me.GroupBox1.TabIndex = 498
        Me.GroupBox1.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox5.Location = New System.Drawing.Point(611, 41)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox5.TabIndex = 500
        Me.PictureBox5.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Maroon
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(638, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 24)
        Me.Label3.TabIndex = 499
        Me.Label3.Text = "F1"
        '
        'Chk_SelectAllItem
        '
        Me.Chk_SelectAllItem.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllItem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllItem.Location = New System.Drawing.Point(449, 26)
        Me.Chk_SelectAllItem.Name = "Chk_SelectAllItem"
        Me.Chk_SelectAllItem.Size = New System.Drawing.Size(112, 16)
        Me.Chk_SelectAllItem.TabIndex = 498
        Me.Chk_SelectAllItem.Text = "SELECT ALL"
        Me.Chk_SelectAllItem.UseVisualStyleBackColor = False
        '
        'chklist_itemdetails
        '
        Me.chklist_itemdetails.BackColor = System.Drawing.SystemColors.Window
        Me.chklist_itemdetails.CheckOnClick = True
        Me.chklist_itemdetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_itemdetails.Location = New System.Drawing.Point(438, 66)
        Me.chklist_itemdetails.Name = "chklist_itemdetails"
        Me.chklist_itemdetails.Size = New System.Drawing.Size(230, 308)
        Me.chklist_itemdetails.TabIndex = 496
        '
        'lbl_Itemlist
        '
        Me.lbl_Itemlist.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Itemlist.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemlist.ForeColor = System.Drawing.Color.White
        Me.lbl_Itemlist.Location = New System.Drawing.Point(439, 42)
        Me.lbl_Itemlist.Name = "lbl_Itemlist"
        Me.lbl_Itemlist.Size = New System.Drawing.Size(230, 24)
        Me.lbl_Itemlist.TabIndex = 497
        Me.lbl_Itemlist.Text = "SELECT ITEMCODE :"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox4.Location = New System.Drawing.Point(376, 40)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox4.TabIndex = 495
        Me.PictureBox4.TabStop = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Maroon
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(406, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 24)
        Me.Label9.TabIndex = 494
        Me.Label9.Text = "F2"
        '
        'chklist_groupdesc
        '
        Me.chklist_groupdesc.CheckOnClick = True
        Me.chklist_groupdesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_groupdesc.Location = New System.Drawing.Point(218, 67)
        Me.chklist_groupdesc.Name = "chklist_groupdesc"
        Me.chklist_groupdesc.Size = New System.Drawing.Size(218, 308)
        Me.chklist_groupdesc.TabIndex = 491
        '
        'chk_SelectAllGroup
        '
        Me.chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
        Me.chk_SelectAllGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_SelectAllGroup.Location = New System.Drawing.Point(230, 24)
        Me.chk_SelectAllGroup.Name = "chk_SelectAllGroup"
        Me.chk_SelectAllGroup.Size = New System.Drawing.Size(112, 16)
        Me.chk_SelectAllGroup.TabIndex = 493
        Me.chk_SelectAllGroup.Text = "SELECT ALL"
        Me.chk_SelectAllGroup.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(218, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(218, 24)
        Me.Label2.TabIndex = 492
        Me.Label2.Text = "SELECT GROUPCODE :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ChkSalesStatement)
        Me.GroupBox2.Controls.Add(Me.ChkStoreWiseClosingStockReport)
        Me.GroupBox2.Controls.Add(Me.ChkProfitAndLoss)
        Me.GroupBox2.Controls.Add(Me.ChkDayWiseSummary)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(739, 386)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(147, 126)
        Me.GroupBox2.TabIndex = 499
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Report Type"
        '
        'ChkSalesStatement
        '
        Me.ChkSalesStatement.AutoSize = True
        Me.ChkSalesStatement.Location = New System.Drawing.Point(6, 96)
        Me.ChkSalesStatement.Name = "ChkSalesStatement"
        Me.ChkSalesStatement.Size = New System.Drawing.Size(116, 18)
        Me.ChkSalesStatement.TabIndex = 3
        Me.ChkSalesStatement.Text = "Sales Statement"
        Me.ChkSalesStatement.UseVisualStyleBackColor = True
        '
        'ChkStoreWiseClosingStockReport
        '
        Me.ChkStoreWiseClosingStockReport.AutoSize = True
        Me.ChkStoreWiseClosingStockReport.Location = New System.Drawing.Point(6, 71)
        Me.ChkStoreWiseClosingStockReport.Name = "ChkStoreWiseClosingStockReport"
        Me.ChkStoreWiseClosingStockReport.Size = New System.Drawing.Size(131, 18)
        Me.ChkStoreWiseClosingStockReport.TabIndex = 2
        Me.ChkStoreWiseClosingStockReport.Text = "Store Wise Closing"
        Me.ChkStoreWiseClosingStockReport.UseVisualStyleBackColor = True
        '
        'ChkProfitAndLoss
        '
        Me.ChkProfitAndLoss.AutoSize = True
        Me.ChkProfitAndLoss.Location = New System.Drawing.Point(6, 48)
        Me.ChkProfitAndLoss.Name = "ChkProfitAndLoss"
        Me.ChkProfitAndLoss.Size = New System.Drawing.Size(112, 18)
        Me.ChkProfitAndLoss.TabIndex = 1
        Me.ChkProfitAndLoss.Text = "Profit And Loss"
        Me.ChkProfitAndLoss.UseVisualStyleBackColor = True
        '
        'ChkDayWiseSummary
        '
        Me.ChkDayWiseSummary.AutoSize = True
        Me.ChkDayWiseSummary.Location = New System.Drawing.Point(6, 23)
        Me.ChkDayWiseSummary.Name = "ChkDayWiseSummary"
        Me.ChkDayWiseSummary.Size = New System.Drawing.Size(131, 18)
        Me.ChkDayWiseSummary.TabIndex = 0
        Me.ChkDayWiseSummary.Text = "Day Wise Summary"
        Me.ChkDayWiseSummary.UseVisualStyleBackColor = True
        '
        'frmRSIDayWiseAndProfitLossReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(934, 699)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn_validation)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.grp_orderby)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmd_export)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmRSIDayWiseAndProfitLossReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RSI Report"
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.grp_SalebillChecklist.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmbut.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_orderby.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    Dim Sqlstring As String
    Private Sub frmStocktransferreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call FillStorename()
        Call FillGroupdetails()

        If UCase(gShortname) = "RSAOI" Then
            dtp_fromdate.Value = Format(CDate("01/01/" & gFinancalyearStart), "dd/MMM/yyyy")
        Else
            dtp_fromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        End If
        dtp_todate.Value = Format(Now, "dd/MMM/yyyy")
        grp_SalebillChecklist.Top = 1000
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub

    Private Sub FillGroupdetails()
        Dim i As Integer
        Dim sqlstring As String
        chklist_groupdesc.Items.Clear()
        sqlstring = "SELECT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPDESC,'') AS GROUPDESC FROM INVENTORYGROUPMASTER WHERE groupcode in (select groupcode from INV_inventoryitemmaster) ORDER BY GROUPCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    chklist_groupdesc.Items.Add(Trim(CStr(.Item("GROUPDESC"))))
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


    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        'If chklst_Store.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the Store Loc(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        If Chk_SelectAllStore.Checked = False Then
            If chklst_Store.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Store Loc(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        If chk_SelectAllGroup.Checked = False Then
            If chklist_groupdesc.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group Description", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        If Chk_SelectAllItem.Checked = False Then
            If chklist_itemdetails.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Item ", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        Checkdaterangevalidate(Format(dtp_fromdate.Value, "dd/MMM/yyyy"), Format(dtp_todate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        gPrint = False
        grp_SalebillChecklist.Top = 501
        grp_SalebillChecklist.Left = 190
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 100
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        'If chklst_Store.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the Store Loc(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        If Chk_SelectAllStore.Checked = False Then
            If chklst_Store.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Store Loc(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        If chk_SelectAllGroup.Checked = False Then
            If chklist_groupdesc.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group Description", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        If Chk_SelectAllItem.Checked = False Then
            If chklist_itemdetails.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Item ", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        Checkdaterangevalidate(Format(dtp_fromdate.Value, "dd/MMM/yyyy"), Format(dtp_todate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        gPrint = True
        grp_SalebillChecklist.Top = 591
        grp_SalebillChecklist.Left = 198
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 100
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        chklst_Store.Items.Clear()
        grp_SalebillChecklist.Top = 1000
        Chk_SelectAllStore.Checked = False
        chk_SelectAllGroup.Checked = False
        Call FillStorename()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        dtp_Fromdate.Focus()
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 2
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_SalebillChecklist.Top = 800
            If ChkProfitAndLoss.Checked = True Then
                Call ProfitLossReport()
            ElseIf ChkDayWiseSummary.Checked = True Then
                Dim dateDif As Integer
                dateDif = DateDiff(DateInterval.Day, dtp_fromdate.Value, dtp_todate.Value)
                If dateDif > 31 Then
                    MessageBox.Show("Date Interval Between From Date and To Date Cannot Be More Than A Month", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                Else
                    Call DayWiseStockSummary()
                End If
            ElseIf ChkStoreWiseClosingStockReport.Checked = True Then
                Call StoreWiseClosingStockReport()
            ElseIf ChkSalesStatement.Checked = True Then
                Call SalesStatementReport()
            Else
                MessageBox.Show("Please Select Any Of Report Type", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            'Call ViewStocktransferregister()
        End If
    End Sub

    Private Sub ViewStocktransferregister()
        Try
            Dim sqlstring, Itemcode(0) As String
            Dim i As Integer
            Dim rViewer As New Viewer
            Dim r As New Rpt_StockTransfer

            sqlstring = " SELECT * FROM VIEWSTOCKREGISTER"
            If chklst_Store.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE FROMSTOREDESC IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Store Loc.(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " AND ISNULL(DOCTYPE,'') <> 'RET' AND DOCDATE BETWEEN"
            sqlstring = sqlstring & " '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy 00:00:00 ") & "' AND ' " & Format(dtp_todate.Value, "dd/MMM/yyyy 23:59:59 ") & "'"


            If chklist_itemdetails.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " AND ITEMCODE IN ("
                For i = 0 To chklist_itemdetails.CheckedItems.Count - 1
                    Itemcode = Split(chklist_itemdetails.CheckedItems(i), "-->")
                    sqlstring = sqlstring & "'" & Itemcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ") "
            Else
                MessageBox.Show("Select the Item Code(s)", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            If rdo_code.Checked = True Then
                sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE,itemcode   "
            ElseIf rdo_name.Checked = True Then
                sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE,itemname   "
            Else
                sqlstring = sqlstring & " ORDER BY DOCDETAILS,DOCDATE   "
            End If
            'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Issue Details") = MsgBoxResult.Yes Then

            gconnection.getDataSet(sqlstring, "VIEWSTOCKREGISTER")
            If gdataset.Tables("VIEWSTOCKREGISTER").Rows.Count > 0 Then
                If chk_excel.Checked = True Then
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "STOCK TRANSFER REPORT " & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "TO" & Format(dtp_todate.Value, "dd/MMM/yyyy"), "")
                Else
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "VIEWSTOCKREGISTER"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text13")
                    textobj1.Text = gCompanyname

                    Dim textobj2 As TextObject
                    textobj2 = r.ReportDefinition.ReportObjects("Text8")
                    textobj2.Text = gUsername

                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text15")
                    textobj6.Text = UCase(gCompanyAddress(0))

                    Dim textobj7 As TextObject
                    textobj7 = r.ReportDefinition.ReportObjects("Text16")
                    textobj7.Text = UCase(gCompanyAddress(1))

                    Dim TXTOBJ3 As TextObject
                    TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                    TXTOBJ3.Text = " From  " & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "  To " & " " & Format(dtp_todate.Value, "dd/MMM/yyyy") & ""

                    If gCompanyname = "THE BENGAL CLUB" Then
                        Dim textobj3 As TextObject
                        textobj3 = r.ReportDefinition.ReportObjects("Text27")
                        textobj3.Text = ""
                    End If
                    rViewer.Show()
                End If
            Else
                MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
            End If

            'Else
            ' Dim heading() As String = {"STOCK TRANSFER REGISTER"}
            ' Dim ObjStocktransferreport As New rptStockregister
            ' ObjStocktransferreport.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
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

    Private Sub frmStocktransferreport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            search.listbox = chklst_Store
            search.Text = "Store Search"
            search.ShowDialog(Me)
        End If
    End Sub

    '''******************************  To fill POS details from SupplierName  *******************************'''
    Private Sub FillStorename()
        Dim i As Integer
        chklst_Store.Items.Clear()
        Sqlstring = "SELECT DISTINCT ISNULL(Storecode,'') AS STORECODE FROM StoreMaster WHERE ISNULL(Freeze,'')<>'Y' GROUP BY STORECODE"
        gconnection.getDataSet(Sqlstring, "StoreMaster")
        If gdataset.Tables("StoreMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
                With gdataset.Tables("StoreMaster").Rows(i)
                    chklst_Store.Items.Add(Trim(.Item("STORECODE")))
                End With
            Next i
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
    Private Sub Chk_SelectAllStore_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllStore.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllStore.Checked = True Then
            For i = 0 To chklst_Store.Items.Count - 1
                chklst_Store.SetItemChecked(i, True)
            Next
            chklst_Store_SelectedIndexChanged(sender, e)
        Else
            For i = 0 To chklst_Store.Items.Count - 1
                chklst_Store.SetItemChecked(i, False)
            Next
            chklst_Store_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub Chk_SelectAllStore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk_SelectAllStore.KeyDown
        If e.KeyCode = Keys.Enter Then
            chklst_Store.Focus()
        End If
    End Sub

    Private Sub chklst_Store_DoubleClick(sender As Object, e As EventArgs) Handles chklst_Store.DoubleClick
        'Dim i, J As Integer
        'Dim sqlstring, ssql As String
        'chklist_groupdesc.Items.Clear()
        'ssql = ""
        ''sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
        ''sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' and I.GROUPNAME IN ("
        'sqlstring = "SELECT distinct ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPNAME,'') AS GROUPDESC FROM INVENTORYITEMMASTER WHERE STORECODE in ("
        'For J = 0 To chklst_Store.CheckedItems.Count - 1
        '    If J = chklst_Store.CheckedItems.Count - 1 Then
        '        ssql = ssql & " '" & chklst_Store.CheckedItems(J) & "' "
        '    Else
        '        ssql = ssql & " '" & chklst_Store.CheckedItems(J) & "', "
        '    End If
        'Next
        'If chklst_Store.CheckedItems.Count > 0 Then
        '    sqlstring = sqlstring & ssql & ") GROUP BY GROUPCODE,GROUPNAME "
        '    gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
        '    If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
        '        chklist_itemdetails.Items.Clear()
        '        For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
        '            With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
        '                chklist_groupdesc.Items.Add(Trim(.Item("GROUPDESC")))
        '            End With
        '        Next i
        '    End If
        'Else
        '    chklist_groupdesc.Items.Clear()
        'End If
    End Sub

    Private Sub chklst_Store_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklst_Store.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtp_Fromdate.Focus()
        End If
    End Sub

    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VIEWSTOCKREGISTER"
        sqlstring = "select * from VIEWSTOCKREGISTER"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validation.Click
        System.Diagnostics.Process.Start(AppPath & "/STUDY/STOCKTRANSFERREGISTER.XLS")
    End Sub

    Private Sub chk_excel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_excel.CheckedChanged

    End Sub

    Private Sub chklist_groupdesc_DoubleClick(sender As Object, e As EventArgs) Handles chklist_groupdesc.DoubleClick
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I,INVENTORYGROUPMASTER G  "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' AND G.GROUPCODE=I.GROUPCODE and G.GROUPDESC IN ("

        For J = 0 To chklist_groupdesc.CheckedItems.Count - 1
            If J = chklist_groupdesc.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & chklist_groupdesc.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & chklist_groupdesc.CheckedItems(J) & "', "
            End If
        Next
        If chklist_groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                chklist_itemdetails.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        chklist_itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        End If
    End Sub

    Private Sub chklist_groupdesc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklist_groupdesc.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INV_INVENTORYITEMMASTER AS I,INVENTORYGROUPMASTER G "
        sqlstring = sqlstring & " WHERE isnull(VOID,'') <> 'Y' AND G.GROUPCODE=I.GROUPCODE and G.GROUPDESC IN ("

        For J = 0 To chklist_groupdesc.CheckedItems.Count - 1
            If J = chklist_groupdesc.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & chklist_groupdesc.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & chklist_groupdesc.CheckedItems(J) & "', "
            End If
        Next
        If chklist_groupdesc.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                chklist_itemdetails.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        chklist_itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        Else
            chklist_itemdetails.Items.Clear()
        End If
    End Sub

    Private Sub chk_SelectAllGroup_CheckedChanged(sender As Object, e As EventArgs) Handles chk_SelectAllGroup.CheckedChanged
        Dim i As Integer
        If chk_SelectAllGroup.Checked = True Then
            For i = 0 To chklist_groupdesc.Items.Count - 1
                chklist_groupdesc.SetItemChecked(i, True)
            Next
            Call Chklist_Groupdesc_SelectedIndexChanged(sender, e)
        Else
            For i = 0 To chklist_groupdesc.Items.Count - 1
                chklist_groupdesc.SetItemChecked(i, False)
            Next
            chklist_itemdetails.Items.Clear()
        End If
    End Sub

    Private Sub Chk_SelectAllItem_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_SelectAllItem.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllItem.Checked = True Then
            For i = 0 To chklist_itemdetails.Items.Count - 1
                chklist_itemdetails.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_itemdetails.Items.Count - 1
                chklist_itemdetails.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub ChkProfitAndLoss_Click(sender As Object, e As EventArgs) Handles ChkProfitAndLoss.Click
        If ChkProfitAndLoss.Checked = True Then
            ChkDayWiseSummary.Checked = False
        End If
    End Sub

    Private Sub ChkDayWiseSummary_Click(sender As Object, e As EventArgs) Handles ChkDayWiseSummary.Click
        If ChkDayWiseSummary.Checked = True Then
            ChkProfitAndLoss.Checked = False
        End If
    End Sub

    Private Sub DayWiseStockSummary()
        Try
            Dim str, Itemcode(0) As String
            Dim i As Integer
            '*** Alter View For Opening
            str = "SELECT * FROM SYSOBJECTS WHERE name='View_DayWiseOpening' AND XTYPE='V'"
            gconnection.getDataSet(str, "View_DayWiseOpening")
            If gdataset.Tables("View_DayWiseOpening").Rows.Count > 0 Then
                str = " ALTER VIEW [dbo].[View_DayWiseOpening]  "
                str = str & " AS  "
                '--INVENTORY OPENING BALANCE
                str = str & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS OPSTOCK,SUM(ISNULL(OPVALUE,0)) AS OPVALUE,'OPENING' AS TYPE  "
                str = str & " FROM INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' AND STORECODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname "
                str = str & " UNION ALL"
                '--GRN
                str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'OPENING' AS TYPE FROM "
                str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' "
                str = str & " AND STORECODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & "GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--PRN
                str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
                str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' "
                str = str & " AND STORECODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & "GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--ADJUSTMENT
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0)) ) AS ADJUSTEDSTOCK, (SUM(ISNULL(Amount,0)) ) AS AMOUNT,"
                str = str & " 'OPENING' AS TYPE FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--DAMAGE
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
                str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
                str = str & "   '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "')  AND FROMStorecode IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--POS CONSUMPTION
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
                str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND STORELOCATIONCODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK ISSUE(-)
                str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE "
                str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ( "
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK ISSUE(+)
                str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE "
                str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & "  BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Opstorelocationcode IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & "  GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK TRANSFER (-)
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE"
                str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & "  GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK TRANSFER (+)
                str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE"
                str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Tostorecode IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname"
                gconnection.dataOperation(6, str, "item")
            Else
                str = " CREATE VIEW [dbo].[View_DayWiseOpening]  "
                str = str & " AS  "
                '--INVENTORY OPENING BALANCE
                str = str & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS OPSTOCK,SUM(ISNULL(OPVALUE,0)) AS OPVALUE,'OPENING' AS TYPE  "
                str = str & " FROM INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' AND STORECODE IN ('') GROUP BY itemcode, itemname "
                str = str & " UNION ALL"
                '--GRN
                str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'OPENING' AS TYPE FROM "
                str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' "
                str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--PRN
                str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
                str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' "
                str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--ADJUSTMENT
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0)) * -1) AS ADJUSTEDSTOCK, (SUM(ISNULL(Amount,0)) * -1) AS AMOUNT,"
                str = str & " 'OPENING' AS TYPE FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('')"
                str = str & " GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--DAMAGE
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
                str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
                str = str & "   '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "')  AND FROMStorecode IN ('') "
                str = str & " GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--POS CONSUMPTION
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
                str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK ISSUE(-)
                str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE "
                str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('') GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK ISSUE(+)
                str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE "
                str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & "  BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Opstorelocationcode IN ('') GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK TRANSFER (-)
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE"
                str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK TRANSFER (+)
                str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE"
                str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
                gconnection.dataOperation(6, str, "item")
            End If
            '*** RECEIVE VIEW ALTER
            str = "SELECT * FROM SYSOBJECTS WHERE name='View_DayWiseReceive' AND XTYPE='V'"
            gconnection.getDataSet(str, "View_DayWiseReceive")
            If gdataset.Tables("View_DayWiseReceive").Rows.Count > 0 Then

                str = " ALTER VIEW View_DayWiseReceive"
                str = str & " as"
                str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT FROM GRN_DETAILS"
                str = str & " WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
                str = str & " BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND STORECODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY Itemcode, Itemname"
                str = str & " UNION ALL"
                str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT FROM STOCKISSUEDETAIL"
                str = str & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND OPSTORELOCATIONCODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY Itemcode, Itemname"
                str = str & " UNION ALL"
                str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT FROM STOCKTRANSFERDETAIL"
                str = str & " WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND TOSTORECODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY Itemcode, Itemname"
                gconnection.dataOperation1(6, str, "item")
            Else
                str = " CREATE VIEW View_DayWiseReceive"
                str = str & " as"
                str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(Amount,0)) AS AMOUNT FROM GRN_DETAILS"
                str = str & " WHERE ISNULL(Voiditem,'')<>'Y' AND storecode IN ('') AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
                str = str & " BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' GROUP BY Itemcode, Itemname"
                str = str & " UNION ALL"
                str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT FROM STOCKISSUEDETAIL"
                str = str & " WHERE ISNULL(Void,'')<>'Y' AND Opstorelocationcode IN ('') AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' GROUP BY Itemcode, Itemname"
                str = str & " UNION ALL"
                str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT FROM STOCKTRANSFERDETAIL"
                str = str & " WHERE ISNULL(Void,'')<>'Y' AND Tostorecode IN ('') AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' GROUP BY Itemcode, Itemname"
                gconnection.dataOperation(6, str, "item")
            End If
            '*** ISSUE VIEW ALTER
            str = "ALTER VIEW [dbo].[DAY_STOCK_SUM1]        "
            str = str & " AS        "
            str = str & " SELECT  Cast(Convert(varchar(11),docdate,111)as Date) as docdate,Itemcode, Itemname, sum(ISNULL(Qty,0)) AS QTY "
            str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y'  AND Storelocationcode IN ("
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ") group by  Cast(Convert(varchar(11),docdate,111)as Date),Itemcode, Itemname"
            gconnection.dataOperation(6, str, "item")

            
            '**** Drop Table and create new daywise_stock_summary
            Sqlstring = "Drop table daywise_stock_summary "
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = " CREATE TABLE [DAYWISE_STOCK_SUMMARY]("
            Sqlstring = Sqlstring & " [SNO] [int] IDENTITY(1,1) NOT NULL,"
            Sqlstring = Sqlstring & " [ITEMCODE] [varchar](30) NULL,"
            Sqlstring = Sqlstring & " [ITEMNAME] [varchar](50) NULL,"
            Sqlstring = Sqlstring & " [DAYTOTAL] [numeric](18, 3) NULL,"
            Sqlstring = Sqlstring & " [RATE] [numeric](18, 3) NULL,"
            Sqlstring = Sqlstring & " [AMOUNT] [numeric](18, 3) NULL,"
            Sqlstring = Sqlstring & " [OPSTOCK] [numeric](18, 3) NULL,"
            Sqlstring = Sqlstring & " [STOCKPURCHASE] [numeric](18, 3) NULL,"
            Sqlstring = Sqlstring & " [STOCKISSUE] [numeric](18, 3) NULL,"
            Sqlstring = Sqlstring & " [STOCKTFR] [numeric](18, 3) NULL,"
            Sqlstring = Sqlstring & " [STOCKTOTAL] [numeric](18, 3) NULL,"
            Sqlstring = Sqlstring & " [STOCKBAL] [numeric](18, 3) NULL"
            Sqlstring = Sqlstring & " ) "
            gconnection.ExcuteStoreProcedure(Sqlstring)

            Dim dtFrom, datefrom As Date
            Dim dtTo As Date
            Dim dayHead, dayReportHead, dayTotal, dayExcel As String
            dtFrom = Format(dtp_fromdate.Value, "dd/MMM/yyyy")
            dtTo = Format(dtp_todate.Value, "dd/MMM/yyyy")
            Dim diff, dayFrom As Integer
            diff = DateDiff(DateInterval.Day, dtFrom, dtTo)
            For i = 0 To diff
                'datefrom = DateAdd(DateInterval.Day, diff, dtFrom)
                dayFrom = DateAdd(DateInterval.Day, i, dtFrom).Day
                Sqlstring = "Alter table daywise_stock_summary add Day" & dayFrom & " numeric(18,3) null"
                gconnection.ExcuteStoreProcedure(Sqlstring)
                If dayHead = "" Then
                    dayHead = "Day" & dayFrom & " as Day" & i + 1
                    dayTotal = "isnull(Day" & dayFrom & ",0)"
                    dayExcel = "isnull(Day" & dayFrom & ",0) as Day" & i + 1
                Else
                    dayHead = dayHead & ", Day" & dayFrom & " as Day" & i + 1
                    dayTotal = dayTotal & " + isnull(Day" & dayFrom & ",0)"
                    dayExcel = dayExcel & " , isnull(Day" & dayFrom & ",0) as Day" & i + 1
                End If
                If dayReportHead = "" Then
                    dayReportHead = "Day" & dayFrom
                Else
                    dayReportHead = dayReportHead & ", Day" & dayFrom
                End If
            Next

            '****FILL DAYWISE_STOCK_SUMMARY TABLE
            gconnection.openConnection()
            gcommand = New SqlCommand("DAYWISE_STOCK", gconnection.Myconn)
            gcommand.CommandTimeout = 1000000000
            gcommand.CommandType = CommandType.StoredProcedure
            gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_fromdate.Value), "dd/MMM/yyyy")
            gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy")
            gcommand.ExecuteNonQuery()
            gconnection.closeConnection()

            Sqlstring = "DROP TABLE DAY_WISESTOCK_FINAL_TAB"
            gconnection.ExcuteStoreProcedure(Sqlstring)

            Sqlstring = "select ITEMCODE, ITEMNAME,OPSTOCK,stockpurchase,stocktotal,STOCKISSUE,STOCKTFR," & dayReportHead & " ,DAYTOTAL,STOCKBAL INTO DAY_WISESTOCK_FINAL_TAB FROM daywise_stock_summary"
            gconnection.ExcuteStoreProcedure(Sqlstring)

            '**** Update value in  table 
            'Sqlstring = "delete from TempTblDayWiseStock"
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            'str = "insert into TempTblDayWiseStock(itemcode, itemname,opqty,opvalue) (select itemcode,itemname,sum(opstock),sum(opvalue) from View_DayWiseOpening group by itemcode, itemname)"
            str = "update DAY_WISESTOCK_FINAL_TAB set opstock=(select SUM(opstock) from View_DayWiseOpening t where DAY_WISESTOCK_FINAL_TAB.itemcode=t.itemcode)"
            str = str & " WHERE DAY_WISESTOCK_FINAL_TAB.ITEMCODE IN (SELECT ITEMCODE FROM View_DayWiseOpening)"
            gconnection.ExcuteStoreProcedure(str)
            str = "update DAY_WISESTOCK_FINAL_TAB set stockpurchase=(select SUM(qty) from View_DayWiseReceive t where DAY_WISESTOCK_FINAL_TAB.itemcode=t.itemcode)"
            str = str & " WHERE DAY_WISESTOCK_FINAL_TAB.ITEMCODE IN (SELECT ITEMCODE FROM View_DayWiseReceive)"
            gconnection.ExcuteStoreProcedure(str)
            str = "update DAY_WISESTOCK_FINAL_TAB set stocktotal=isnull(opstock,0) + isnull(stockpurchase,0)"
            gconnection.ExcuteStoreProcedure(str)
            str = "update DAY_WISESTOCK_FINAL_TAB set daytotal=" & dayTotal & ""
            gconnection.ExcuteStoreProcedure(str)
            str = "update DAY_WISESTOCK_FINAL_TAB set stockbal=(isnull(opstock,0) + isnull(stockpurchase,0)) - (" & dayTotal & ")"
            gconnection.ExcuteStoreProcedure(str)


            
            'Sqlstring = "SELECT  ITEMCODE, ITEMNAME,OPqty,rcvqty,stockpurchase,stocktotal,STOCKISSUE,STOCKTFR," & dayHead & " ,DAYTOTAL,STOCKBAL,totalstock,balance  FROM DAY_WISESTOCK_FINAL_TAB where itemcode in ("

            Sqlstring = "SELECT  ITEMCODE, ITEMNAME,opstock,stockpurchase,stocktotal,DAYTOTAL,stockbal,STOCKISSUE,STOCKTFR," & dayHead & "   FROM DAY_WISESTOCK_FINAL_TAB where itemcode in ("
            For i = 0 To chklist_itemdetails.CheckedItems.Count - 1
                Itemcode = Split(chklist_itemdetails.CheckedItems(i), "-->")
                Sqlstring = Sqlstring & "'" & Itemcode(0) & "', "
            Next
            Sqlstring = Mid(Sqlstring, 1, Len(Sqlstring) - 2)
            Sqlstring = Sqlstring & ") "
            If rdo_code.Checked = True Then
                Sqlstring = Sqlstring & " order by itemcode"
            ElseIf rdo_name.Checked = True Then
                Sqlstring = Sqlstring & " order by itemname"
            End If
            Dim rViewer As New Viewer
            Dim r As New CrysDayWiseStockSummary
            gconnection.getDataSet(Sqlstring, "DAY_WISESTOCK_FINAL_TAB")
            If gdataset.Tables("DAY_WISESTOCK_FINAL_TAB").Rows.Count > 0 Then
                If chk_excel.Checked = True Then
                    Dim sqls As String
                    sqls = "SELECT  isnull(ITEMCODE,'') as ItemCode, isnull(ITEMNAME,'') as ItemName, isnull(opstock,0) as OpStock, isnull(stockpurchase,0) as Purchase,Isnull(stocktotal,0) as Total," & dayExcel & " , isnull(DAYTOTAL,0) as TotalSale,isnull(stockbal,0) as Balance  FROM DAY_WISESTOCK_FINAL_TAB where itemcode in ("
                    For i = 0 To chklist_itemdetails.CheckedItems.Count - 1
                        Itemcode = Split(chklist_itemdetails.CheckedItems(i), "-->")
                        sqls = sqls & "'" & Itemcode(0) & "', "
                    Next
                    sqls = Mid(sqls, 1, Len(sqls) - 2)
                    sqls = sqls & ") "
                    If rdo_code.Checked = True Then
                        sqls = sqls & " order by itemcode"
                    ElseIf rdo_name.Checked = True Then
                        sqls = sqls & " order by itemname"
                    End If
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqls, "DAY WISE STOCK REPORT " & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "TO" & Format(dtp_todate.Value, "dd/MMM/yyyy"), "")
                Else
                    rViewer.ssql = Sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "DAY_WISESTOCK_FINAL_TAB"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text245")
                    textobj1.Text = gCompanyname
                    textobj1 = r.ReportDefinition.ReportObjects("Text39")
                    textobj1.Text = gCompanyAddress(0) & ", " & gCompanyAddress(1)
                    textobj1 = r.ReportDefinition.ReportObjects("Text41")
                    textobj1.Text = "From " & Format(dtp_fromdate.Value, "dd/MM/yyyy") & " To " & Format(dtp_todate.Value, "dd/MM/yyyy")
                    textobj1 = r.ReportDefinition.ReportObjects("Text44")
                    textobj1.Text = gUsername
                    '******** fill day heading  
                    Dim Text As String
                    Dim k As Integer
                    diff = DateDiff(DateInterval.Day, dtFrom, dtTo)
                    k = 5
                    For i = 0 To diff
                        'datefrom = DateAdd(DateInterval.Day, diff, dtFrom)
                        dayFrom = DateAdd(DateInterval.Day, i, dtFrom).Day
                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text" & k + i)
                        textobj2.Text = "Day" & dayFrom
                    Next
                    '*************************

                    rViewer.Show()
                End If
            Else
                MessageBox.Show("No Records To Display", gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error" + ex.Message, gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ProfitLossReport()
        Try

            Dim i As Integer
            Dim str As String
            '*** Alter View For Opening
            str = "SELECT * FROM SYSOBJECTS WHERE name='View_DayWiseOpening' AND XTYPE='V'"
            gconnection.getDataSet(str, "View_DayWiseOpening")
            If gdataset.Tables("View_DayWiseOpening").Rows.Count > 0 Then
                str = " ALTER VIEW [dbo].[View_DayWiseOpening]  "
                str = str & " AS  "
                '--INVENTORY OPENING BALANCE
                str = str & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS OPSTOCK,SUM(ISNULL(OPVALUE,0)) AS OPVALUE,'OPENING' AS TYPE  "
                str = str & " FROM INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' AND STORECODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname "
                str = str & " UNION ALL"
                '--GRN
                str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS OPSTOCK, SUM(ISNULL(AMOUNT,0)) AS OPVALUE,'OPENING' AS TYPE FROM "
                str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' "
                str = str & " AND STORECODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & "GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--PRN
                str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS OPSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS OPVALUE,'OPENING' AS TYPE "
                str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' "
                str = str & " AND STORECODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & "GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--ADJUSTMENT
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0))) AS OPSTOCK, (SUM(ISNULL(Amount,0))) AS OPVALUE,"
                str = str & " 'OPENING' AS TYPE FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--DAMAGE
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS OPSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS OPVALUE,'OPENING' AS TYPE "
                str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
                str = str & "   '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "')  AND FROMStorecode IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--POS CONSUMPTION
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS OPSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS OPVALUE,'OPENING' AS TYPE "
                str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND STORELOCATIONCODE IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK ISSUE(-)
                str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS OPSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS OPVALUE, 'OPENING' AS TYPE "
                str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ( "
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK ISSUE(+)
                str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0)) AS OPSTOCK, SUM(ISNULL(AMOUNT,0)) AS OPVALUE, 'OPENING' AS TYPE "
                str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & "  BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Opstorelocationcode IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & "  GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK TRANSFER (-)
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS OPSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS OPVALUE, 'OPENING' AS TYPE"
                str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & "  GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK TRANSFER (+)
                str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS OPSTOCK, SUM(ISNULL(AMOUNT,0)) AS OPVALUE, 'OPENING' AS TYPE"
                str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Tostorecode IN ("
                For i = 0 To chklst_Store.CheckedItems.Count - 1
                    str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
                Next
                str = Mid(str, 1, Len(str) - 2)
                str = str & ")"
                str = str & " GROUP BY itemcode, itemname"
                gconnection.dataOperation1(6, str, "item")
            Else
                str = " CREATE VIEW [dbo].[View_DayWiseOpening]  "
                str = str & " AS  "
                '--INVENTORY OPENING BALANCE
                str = str & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS OPSTOCK,SUM(ISNULL(OPVALUE,0)) AS OPVALUE,'OPENING' AS TYPE  "
                str = str & " FROM INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' AND STORECODE IN ('') GROUP BY itemcode, itemname "
                str = str & " UNION ALL"
                '--GRN
                str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'OPENING' AS TYPE FROM "
                str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' "
                str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--PRN
                str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
                str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' "
                str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--ADJUSTMENT
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0)) * -1) AS ADJUSTEDSTOCK, (SUM(ISNULL(Amount,0)) * -1) AS AMOUNT,"
                str = str & " 'OPENING' AS TYPE FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('')"
                str = str & " GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--DAMAGE
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
                str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
                str = str & "   '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "')  AND FROMStorecode IN ('') "
                str = str & " GROUP BY itemcode, itemname "
                str = str & "   UNION ALL"
                '--POS CONSUMPTION
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
                str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK ISSUE(-)
                str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE "
                str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('') GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK ISSUE(+)
                str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE "
                str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & "  BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Opstorelocationcode IN ('') GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK TRANSFER (-)
                str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE"
                str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
                str = str & " UNION ALL"
                '--STOCK TRANSFER (+)
                str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE"
                str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
                str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
                gconnection.dataOperation1(6, str, "item")
            End If

            '*** Delete Data From TblTempProfitandLossReport
            Sqlstring = "TRUNCATE TABLE TblTempProfitandLossReport "
            gconnection.ExcuteStoreProcedure(Sqlstring)

            '*** Insert Opening Details
            Sqlstring = "insert into TblTempProfitandLossReport(ItemCode, ItemName,Opqty, OPvalue)"
            Sqlstring = Sqlstring & " (select ItemCode, ItemName, sum(Opstock), sum(Opvalue) from View_DayWiseOpening group by itemcode, itemname)"
            gconnection.ExcuteStoreProcedure(Sqlstring)

            '*** Insert Receive Details
            Sqlstring = "insert into TblTempProfitandLossReport(ItemCode, ItemName, RcvQty, RcvValue, RcvRate)"
            Sqlstring = Sqlstring & "(select ItemCode, ItemName, Sum(qty), sum(amount),rate from Grn_Details where Isnull(Voiditem,'')<>'Y' "
            Sqlstring = Sqlstring & " and cast(convert(varchar(11),grndate,106) as datetime) between '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' "
            Sqlstring = Sqlstring & " and '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' Group by ItemCode, ItemName,Rate)"
            gconnection.ExcuteStoreProcedure(Sqlstring)

            '*** Insert Issue Details
            Sqlstring = "insert into TblTempProfitandLossReport(ItemCode, ItemName, IssQty, IssValue, IssRate)"
            Sqlstring = Sqlstring & "(select ItemCode, ItemName, Sum(qty), sum(amount),rate from SubStoreConsumptionDetail where Isnull(Void,'')<>'Y' "
            Sqlstring = Sqlstring & " and cast(convert(varchar(11),docdate,106) as datetime) between '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' "
            Sqlstring = Sqlstring & " and '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' Group by ItemCode, ItemName,Rate)"
            gconnection.ExcuteStoreProcedure(Sqlstring)

            '**** call closing stock
            Call ClosingViewAlter()
            '*** Insert Issue Details
            Sqlstring = "insert into TblTempProfitandLossReport(ItemCode, ItemName, ClsQty, ClsValue)"
            Sqlstring = Sqlstring & "(select ItemCode, ItemName, Sum(Clsstock), sum(Clsvalue) from View_DayWiseClosing Group by ItemCode, ItemName)"
            gconnection.ExcuteStoreProcedure(Sqlstring)

            '*** Rate Updation
            'Sqlstring = " drop table stkpurchaserate         "
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            'Sqlstring = " create table stkpurchaserate (grndate datetime,OPdate datetime,itemcode varchar(50),rate numeric(18,2),uom varchar(50),oprate numeric(18,2))         "
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            'Sqlstring = " insert into stkpurchaserate (grndate,itemcode,rate) (select max(grndate) as grndate,itemcode,(sum(amount+taxamount))/sum(qty) as rate from grn_details         "
            'Sqlstring = Sqlstring & " where grndate<='" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' group by itemcode)         "
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            'Sqlstring = " insert into stkpurchaserate (grndate,itemcode,rate,uom) (select getdate(),itemcode,purchaserate,stockuom from inventoryitemmaster where itemcode not in         "
            'Sqlstring = Sqlstring & "(select itemcode from grn_details where grndate<='" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') and storecode in ('mns','mrat','froz'))         "
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            'Sqlstring = " UPDATE stkpurchaserate SET OPdate = (select max(grndate) as OPdate from grn_details where grndate<'" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "'  AND stkpurchaserate.itemcode =grn_details.itemcode  group by itemcode)         "
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            'Sqlstring = " update stkpurchaserate set rate=(select sum(amount+taxamount)/sum(qty) from grn_details b where b.grndate=stkpurchaserate.grndate and b.itemcode=stkpurchaserate.itemcode)         "
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            'Sqlstring = " update stkpurchaserate set oprate = (select (sum(amount+taxamount))/sum(qty) as rate from grn_details b where b.grndate=stkpurchaserate.OPdate and b.itemcode =stkpurchaserate.itemcode)         "
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            ''Sqlstring = "update stkpurchaserate set rate= i.purchaserate, oprate= i.purchaserate from inventoryitemmaster i where  i.itemcode=stkpurchaserate.itemcode and i.itemcode         "
            ''Sqlstring = Sqlstring & "not in (select itemcode from grn_details where grndate<='" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "') and storecode in ('MNS','MRAT','FROZ')        "
            ''gconnection.ExcuteStoreProcedure(Sqlstring)
            'Sqlstring = "update stkpurchaserate set uom = b.GRNStockUom from grn_details b where stkpurchaserate.grndate=b.grndate and stkpurchaserate.itemcode=b.itemcode         "
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            'Sqlstring = "update stkpurchaserate set rate = rate / c.convvalue from inventory_transconversion c,inventoryitemmaster i where c.baseuom =i.stockuom and         "
            'Sqlstring = Sqlstring & "c.transuom =stkpurchaserate.uom and stkpurchaserate.itemcode = i.itemcode and i.STORECODE in ('MNS','MRAT','FROZ')        "
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            'Sqlstring = "update stkpurchaserate set oprate= oprate/c.convvalue from inventory_transconversion c,inventoryitemmaster i where c.baseuom =i.stockuom and         "
            'Sqlstring = Sqlstring & "c.transuom = stkpurchaserate.uom and stkpurchaserate.itemcode = i.itemcode  and i.STORECODE in ('MNS','MRAT','FROZ')        "
            'gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "drop table stkpurchaserate1"
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "drop table   STKOPNRATE1    "
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "SELECT * INTO stkpurchaserate1 FROM OPENING_RATE WHERE Grndate<='" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' ORDER BY Grndate DESC      "
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "SELECT * INTO STKOPNRATE1 FROM   OPENING_RATE WHERE Grndate<='" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' ORDER BY Grndate DESC      "
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "update TblTempProfitandLossReport set Oprate=(SELECT TOP 1 rate from STKOPNRATE b where b.itemcode=TblTempProfitandLossReport.itemcode     "
            Sqlstring = Sqlstring & " and b.type='GRN')"
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "update TblTempProfitandLossReport  set Oprate= (SELECT TOP 1 rate from STKOPNRATE1 b where b.itemcode=TblTempProfitandLossReport.itemcode    "
            Sqlstring = Sqlstring & " and b.type='opening'  )"
            Sqlstring = Sqlstring & " WHERE Itemcode not in (SELECT ITEMCODE from STKOPNRATE1 where TYPE='grn' )      "
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "update TblTempProfitandLossReport set Clsrate=(SELECT TOP 1 rate from stkpurchaserate1 b where b.itemcode=TblTempProfitandLossReport.itemcode     "
            Sqlstring = Sqlstring & " and b.type='GRN')"
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "update TblTempProfitandLossReport  set Clsrate= (SELECT TOP 1 rate from stkpurchaserate1 b where b.itemcode=TblTempProfitandLossReport.itemcode    "
            Sqlstring = Sqlstring & " and b.type='opening'  )     "
            Sqlstring = Sqlstring & " WHERE Itemcode not in (SELECT ITEMCODE from stkpurchaserate1 where TYPE='grn' )      "
            gconnection.ExcuteStoreProcedure(Sqlstring)
            '*** GENERATE REPORT
            Sqlstring = "TRUNCATE TABLE TblProfitandLossReport"
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "insert into TblProfitandLossReport(Itemcode, Itemname, opqty,opvalue,rcvqty,rcvvalue,issqty,issvalue,clsqty,clsvalue)"
            Sqlstring = Sqlstring & " select itemcode, itemname,SUM(isnull(opqty,0)), SUM(isnull(opvalue,0)), SUM(isnull(rcvqty,0)), SUM(isnull(rcvvalue,0)), "
            Sqlstring = Sqlstring & " SUM(isnull(issqty,0)), SUM(isnull(issvalue,0)), SUM(clsqty), SUM(clsvalue) from TblTempProfitandLossReport "
            Sqlstring = Sqlstring & " group by ItemCode, ItemName"
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "Update TblProfitandLossReport set TotOpRcvQty=OpQty + RcvQty"
            gconnection.ExcuteStoreProcedure(Sqlstring)
            Sqlstring = "Update TblProfitandLossReport set TotOpRcvValue=OpValue + RcvValue"
            gconnection.ExcuteStoreProcedure(Sqlstring)
            'Sqlstring = "SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(OPQTY,0)) AS OPQTY, SUM(ISNULL(OPVALUE,0)) AS OPVALUE, ISNULL(OPRATE,0) AS OPRATE,"
            'Sqlstring = Sqlstring & "SUM(ISNULL(RCVQTY,0)) AS RCVQTY, SUM(ISNULL(RCVVALUE,0)) AS RCVVALUE, ISNULL(RCVRATE,0) AS RCVRATE,"
            'Sqlstring = Sqlstring & "SUM(ISNULL(ISSQTY,0)) AS ISSQTY, SUM(ISNULL(ISSVALUE,0)) AS ISSVALUE, ISNULL(ISSRATE,0) AS ISSRATE,"
            'Sqlstring = Sqlstring & "SUM(ISNULL(CLSQTY,0)) AS CLSQTY, SUM(ISNULL(CLSVALUE,0)) AS CLSVALUE, ISNULL(CLSRATE,0) AS CLSRATE"
            'Sqlstring = Sqlstring & " FROM TblTempProfitandLossReport GROUP by itemcode, ItemName,OpRate,RcvRate,IssRate,ClsRate"
            'gconnection.getDataSet(Sqlstring, "TempProfitandLossReport")
            If gdataset.Tables("TempProfitandLossReport").Rows.Count > 0 Then

            End If

        Catch ex As Exception
            MessageBox.Show("Plz Check Error" + ex.Message, gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClosingViewAlter()
        Dim str As String
        Dim i As Integer
        str = "SELECT * FROM SYSOBJECTS WHERE name='View_DayWiseClosing' AND XTYPE='V'"
        gconnection.getDataSet(str, "View_DayWiseClosing")
        If gdataset.Tables("View_DayWiseClosing").Rows.Count > 0 Then
            str = " ALTER VIEW [dbo].[View_DayWiseClosing]  "
            str = str & " AS  "
            '--INVENTORY OPENING BALANCE
            str = str & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS clsSTOCK,SUM(ISNULL(OPVALUE,0)) AS ClsValue,'OPENING' AS TYPE  "
            str = str & " FROM INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' AND STORECODE IN ("
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
            str = str & " GROUP BY itemcode, itemname "
            str = str & " UNION ALL"
            '--GRN
            str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS clsSTOCK, SUM(ISNULL(AMOUNT,0)) AS ClsValue,'OPENING' AS TYPE FROM "
            str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' "
            str = str & " AND STORECODE IN ("
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
            str = str & "GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--PRN
            str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'OPENING' AS TYPE "
            str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' "
            str = str & " AND STORECODE IN ("
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
            str = str & "GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--ADJUSTMENT
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0)) * -1) AS clsSTOCK, (SUM(ISNULL(Amount,0)) * -1) AS ClsValue,"
            str = str & " 'OPENING' AS TYPE FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ("
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
            str = str & " GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--DAMAGE
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'OPENING' AS TYPE "
            str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
            str = str & "   '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "')  AND FROMStorecode IN ("
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
            str = str & " GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--POS CONSUMPTION
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'OPENING' AS TYPE "
            str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND STORELOCATIONCODE IN ("
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
            str = str & " GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK ISSUE(-)
            str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue, 'OPENING' AS TYPE "
            str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ( "
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
            str = str & " GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK ISSUE(+)
            str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0)) AS clsSTOCK, SUM(ISNULL(AMOUNT,0)) AS ClsValue, 'OPENING' AS TYPE "
            str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & "  BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Opstorelocationcode IN ("
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
            str = str & "  GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK TRANSFER (-)
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue, 'OPENING' AS TYPE"
            str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ("
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
            str = str & "  GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK TRANSFER (+)
            str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS clsSTOCK, SUM(ISNULL(AMOUNT,0)) AS ClsValue, 'OPENING' AS TYPE"
            str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ("
            For i = 0 To chklst_Store.CheckedItems.Count - 1
                str = str & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
            Next
            str = Mid(str, 1, Len(str) - 2)
            str = str & ")"
            str = str & " GROUP BY itemcode, itemname"
            gconnection.dataOperation1(6, str, "item")
        Else
            str = " CREATE VIEW [dbo].[View_DayWiseClosing]  "
            str = str & " AS  "
            '--INVENTORY OPENING BALANCE
            str = str & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS OPSTOCK,SUM(ISNULL(OPVALUE,0)) AS OPVALUE,'OPENING' AS TYPE  "
            str = str & " FROM INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' AND STORECODE IN ('') GROUP BY itemcode, itemname "
            str = str & " UNION ALL"
            '--GRN
            str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'OPENING' AS TYPE FROM "
            str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' "
            str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--PRN
            str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
            str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' "
            str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--ADJUSTMENT
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0)) * -1) AS ADJUSTEDSTOCK, (SUM(ISNULL(Amount,0)) * -1) AS AMOUNT,"
            str = str & " 'OPENING' AS TYPE FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('')"
            str = str & " GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--DAMAGE
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
            str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
            str = str & "   '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "')  AND FROMStorecode IN ('') "
            str = str & " GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--POS CONSUMPTION
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
            str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK ISSUE(-)
            str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE "
            str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK ISSUE(+)
            str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE "
            str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & "  BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Opstorelocationcode IN ('') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK TRANSFER (-)
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE"
            str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK TRANSFER (+)
            str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE"
            str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
            gconnection.dataOperation1(6, str, "item")
        End If
    End Sub

    Public Sub StoreWiseClosingStockReport()
        Try
            Dim str, INSERT(0), itemcode1(0) As String
            Dim i As Integer
            Dim rViewer As New Viewer
            Dim ITEMTABLE As DataTable
            Dim sqlstring, SSQL, itemcode As String

            Dim Clsquantity, Update(0), Storecode As String
            Dim Boolupdate As Boolean
            Storecode = "" : Clsquantity = "" : i = 0
            Dim SLSTRING, storequery, StoreAdd, StoreExcel, StoreExcelSum As String
            Dim StoreArr(0) As String
            Dim rate As Double
            'm
            'sqlstring = "select DISTINCT itemcode from inventoryitemmaster WHERE freeze<>'Y'"
            'gconnection.getDataSet(sqlstring, "inventoryitemmaster")
            'ITEMTABLE = gdataset.Tables("inventoryitemmaster")
            'If ITEMTABLE.Rows.Count > 0 Then

            For i = 0 To (chklist_itemdetails.CheckedItems.Count - 1)
                If itemcode = "" Then
                    itemcode = "'" & chklist_itemdetails.CheckedItems(i) & "'"
                Else
                    itemcode = itemcode & "," & "'" & chklist_itemdetails.CheckedItems(i) & "'"
                End If
            Next
            sqlstring = "truncate table BAR_STOCKSUMMARY_TEMP"
            gconnection.ExcuteStoreProcedure(sqlstring)
            'End If
            '******RUN View TO FILL Temp STOCKSUMMARY TABLE 

            For i = 0 To (chklst_Store.CheckedItems.Count - 1)
                Storecode = chklst_Store.CheckedItems(i)

                Call StoreWiseClosingViewAlterN(Storecode)
                '--------------------------------------------------------------------------'
                sqlstring = "INSERT INTO BAR_STOCKSUMMARY_TEMP(ITEMCODE, ITEMNAME,UOM, STORECODE, CLSQTY)"
                sqlstring = sqlstring & "SELECT ITEMCODE, ITEMNAME,UOM, STORECODE, sum(clsstock) FROM View_StoreWiseClosingClosingN group by ITEMCODE, ITEMNAME,UOM, STORECODE"
                gconnection.ExcuteStoreProcedure(sqlstring)
            Next
            ' End If
            sqlstring = "drop table MONTH_STB_temp"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "create table MONTH_STB_temp ( "
            sqlstring = sqlstring & " Itemcode varchar(50) null,"
            sqlstring = sqlstring & " Itemname varchar(200) null,"
            sqlstring = sqlstring & " UOM varchar(20) null,"
            sqlstring = sqlstring & " TOTAL numeric(18,2) null,"
            sqlstring = sqlstring & " StockInBot numeric(18,2) null,"
            sqlstring = sqlstring & " RatePerBot numeric(18,2) null,"
            sqlstring = sqlstring & " TotalAmount numeric(18,2) null,"
            sqlstring = sqlstring & " ConvValue numeric(18,2) null,"
            sqlstring = sqlstring & " MBSTConvValue numeric(18,2) null)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "insert into month_stb_temp (Itemcode,Itemname) select distinct itemcode, itemname from inv_inventoryitemmaster"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SLSTRING = ""

            For i = 0 To (chklst_Store.CheckedItems.Count - 1)

                Storecode = chklst_Store.CheckedItems(i)
                If SLSTRING = "" Then
                    SLSTRING = Storecode
                    storequery = Storecode & " as st" & i + 1
                    StoreAdd = "isnull(" & Storecode & ",0)"
                    StoreExcel = "isnull(" & Storecode & ",0) AS " & Storecode
                    StoreExcelSum = "SUM(isnull(" & Storecode & ",0)) AS " & Storecode
                Else
                    SLSTRING = SLSTRING & "," & Storecode
                    If Storecode <> "" Then
                        storequery = storequery & "," & Storecode & " as st" & i + 1
                        StoreAdd = StoreAdd & " + isnull(" & Storecode & ",0)"
                        StoreExcel = StoreExcel & " , isnull(" & Storecode & ",0) AS " & Storecode
                        StoreExcelSum = StoreExcelSum & ", SUM(isnull(" & Storecode & ",0)) AS " & Storecode
                    End If

                End If

                ReDim Preserve StoreArr(StoreArr.Length)
                StoreArr(StoreArr.Length - 1) = Storecode

                sqlstring = "alter table MONTH_STB_temp add " & Storecode & " numeric(18,2) null"
                gconnection.ExcuteStoreProcedure(sqlstring)

                'sqlstring = "UPDATE MONTH_STB_temp SET " & Storecode & " = BAR_STOCKSUMMARY_TEMP.CLSQTY FROM BAR_STOCKSUMMARY_TEMP WHERE STORECODE IN ('" & Storecode & "')  "
                'sqlstring = sqlstring & " AND MONTH_STB_temp.ITEMCODE=BAR_STOCKSUMMARY_TEMP.ITEMCODE "
                'gconnection.ExcuteStoreProcedure(sqlstring)                
                ''*************************

                sqlstring = "UPDATE MONTH_STB_temp SET " & Storecode & " = (select sum(BAR_STOCKSUMMARY_TEMP.CLSQTY) FROM BAR_STOCKSUMMARY_TEMP WHERE STORECODE IN ('" & Storecode & "')  "
                sqlstring = sqlstring & " AND MONTH_STB_temp.ITEMCODE=BAR_STOCKSUMMARY_TEMP.ITEMCODE )"
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = "UPDATE MONTH_STB_temp SET UOM = (Select Distinct inv_inventoryopenningstock.UOM from inv_inventoryopenningstock WHERE STORECODE IN ('" & Storecode & "')  "
                sqlstring = sqlstring & " AND MONTH_STB_temp.ITEMCODE=inv_inventoryopenningstock.ITEMCODE) "
                gconnection.ExcuteStoreProcedure(sqlstring)

                ''***** Update QTY for MSTB
                'sqlstring = "update MONTH_STB_temp set MBSTconvvalue = (select distinct t.CONVVALUE from INVENTORY_TRANSCONVERSION t, INVENTORYITEMMASTER i"
                'sqlstring = sqlstring & " where t.BASEUOM=MONTH_STB_temp.UOM and t.TRANSUOM=i.stockuom and i.STORECODE in (select STORECODE from StoreMaster where Storestatus = 'M')"
                'sqlstring = sqlstring & " and month_Stb_temp.Itemcode=i.itemcode)"
                'gconnection.ExcuteStoreProcedure(sqlstring)
                'sqlstring = " UPDATE MONTH_STB_temp SET " & Storecode & " = " & Storecode & " / ISNULL(MBSTconvvalue,0) where '" & Storecode & "'='MBST' and ISNULL(MBSTconvvalue,0)>0"
                'gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = " UPDATE MONTH_STB_temp SET " & Storecode & " = 0 where " & Storecode & "< 0"
                gconnection.ExcuteStoreProcedure(sqlstring)
                '***********

            Next
            sqlstring = "Update MONTH_STB_temp set total = " & StoreAdd & ""
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "update MONTH_STB_temp set convvalue = (select distinct t.CONVVALUE from INVENTORY_TRANSCONVERSION t, inv_inventoryopenningstock i"
            sqlstring = sqlstring & " where t.BASEUOM=MONTH_STB_temp.UOM and t.TRANSUOM=i.uom and i.STORECODE in (select STORECODE from StoreMaster where Storestatus = 'M')"
            sqlstring = sqlstring & " and month_Stb_temp.Itemcode=i.itemcode)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = sqlstring & " UPDATE MONTH_STB_temp SET STOCKINBOT = ISNULL(TOTAL,0) * ISNULL(CONVVALUE,0)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            '***********
            'sqlstring = "drop table stkpurchaserate1"
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "SELECT * INTO stkpurchaserate1 FROM OPENING_RATE WHERE Grndate<='" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' ORDER BY Grndate DESC      "
            'gconnection.ExcuteStoreProcedure(sqlstring)

            '''''''''''''''***********************************************************************************************


            'sqlstring = "drop table stkpurchaserate1   "
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "create table stkpurchaserate1 (grndate datetime,OPdate datetime,itemcode varchar(50),rate numeric(18,2),uom varchar(50),oprate numeric(18,2))   "
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "insert into stkpurchaserate1 (grndate,itemcode,rate) (select max(grndate) as grndate,itemcode,rate as rate from grn_details   "
            'sqlstring = sqlstring & " where grndate<='" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' group by itemcode)   "
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "insert into stkpurchaserate1 (grndate,itemcode,rate,uom) (select getdate(),itemcode,purchaserate,stockuom from inventoryitemmaster where itemcode not in   "
            'sqlstring = sqlstring & " (select itemcode from grn_details where grndate<='" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') and storecode='MNS')   "
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "UPDATE stkpurchaserate1 SET OPdate = (select max(grndate) as OPdate from grn_details where grndate<'" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "'  AND stkpurchaserate1.itemcode =grn_details.itemcode  group by itemcode)   "
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "update stkpurchaserate1 set rate=(select rate from grn_details b where b.grndate=stkpurchaserate1.grndate and b.itemcode=stkpurchaserate1.itemcode)   "
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "update stkpurchaserate1 set oprate = (select rate as rate from grn_details b where b.grndate=stkpurchaserate1.OPdate and b.itemcode =stkpurchaserate1.itemcode)   "
            'gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "update stkpurchaserate1 set rate= i.purchaserate, oprate= i.purchaserate from inventoryitemmaster i where  i.itemcode=stkpurchaserate1.itemcode and i.itemcode   "
            'sqlstring = sqlstring & " not in (select itemcode from grn_details where grndate<='" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') and storecode in ('MNS','MRAT','FROZ')  "
            'gconnection.ExcuteStoreProcedure(sqlstring)

            'sqlstring = "Update MONTH_STB_temp set RatePerBot=(Select s.Rate from stkpurchaserate1 s where s.itemcode=MONTH_STB_temp.itemcode)"
            'gconnection.ExcuteStoreProcedure(sqlstring)


            ''''''''''''''''******************************************************************


            sqlstring = "drop table stkpurchaserate          "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "drop table   STKOPNRATE        "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "SELECT * INTO stkpurchaserate FROM OPENING_RATE WHERE Grndate<='" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' ORDER BY Grndate DESC "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "update stkpurchaserate Set Uom = (Select uom From INV_Inventoryopenningstock I Where I.itemcode = stkpurchaserate.ITEMCODE And I.STORECODE='MNS')  "
            sqlstring = sqlstring & " SELECT * INTO STKOPNRATE FROM   OPENING_RATE WHERE Grndate<'" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' ORDER BY Grndate DESC  "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "drop table stkpurchaserate1   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "create table stkpurchaserate1 (grndate datetime,OPdate datetime,itemcode varchar(50),rate numeric(18,2),uom varchar(50),oprate numeric(18,2))   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "insert into stkpurchaserate1 (grndate,itemcode,rate) (select max(grndate) as grndate,itemcode,sum(amount)/Sum(qty) as rate from grn_details   "
            sqlstring = sqlstring & " where grndate<='" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' group by itemcode)   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "insert into stkpurchaserate1 (grndate,itemcode,rate,uom) (select getdate(),itemcode,0,uom from INV_Inventoryopenningstock where itemcode not in   "
            sqlstring = sqlstring & " (select itemcode from grn_details where grndate<='" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') and storecode='MNS')   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "UPDATE stkpurchaserate1 SET OPdate = (select max(grndate) as OPdate from grn_details where grndate<'" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "'  AND stkpurchaserate1.itemcode =grn_details.itemcode  group by itemcode)   "
            gconnection.ExcuteStoreProcedure(sqlstring)
            

            sqlstring = "update stkpurchaserate1 set Oprate=(SELECT TOP 1 rate from STKOPNRATE b where b.itemcode=stkpurchaserate1.itemcode         "
            sqlstring = sqlstring & " and b.type='GRN'  Order By grndate desc)  "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "update stkpurchaserate1  set Oprate= (SELECT TOP 1 rate from STKOPNRATE b where b.itemcode=stkpurchaserate1.itemcode        "
            sqlstring = sqlstring & " and b.type='opening')"
            sqlstring = sqlstring & " WHERE Itemcode not in (SELECT ITEMCODE from STKOPNRATE where TYPE='grn' )      "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "update stkpurchaserate1 set rate=(SELECT TOP 1 rate from stkpurchaserate b where b.itemcode=stkpurchaserate1.itemcode         "
            sqlstring = sqlstring & " and b.type='GRN'  Order By grndate desc)  "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "update stkpurchaserate1  set rate= (SELECT TOP 1 rate from stkpurchaserate b where b.itemcode=stkpurchaserate1.itemcode        "
            sqlstring = sqlstring & " and b.type='opening')  "
            sqlstring = sqlstring & " WHERE Itemcode not in (SELECT ITEMCODE from stkpurchaserate where TYPE='grn' )  "
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "Update MONTH_STB_temp set RatePerBot=(Select s.Rate from stkpurchaserate1 s where s.itemcode=MONTH_STB_temp.itemcode)"
            gconnection.ExcuteStoreProcedure(sqlstring)


            ''''''''''''''''''''''''**************************************************************************
            ''sqlstring = "update MONTH_STB_temp set RatePerBot=(SELECT TOP 1 rate from stkpurchaserate1 b where b.itemcode=MONTH_STB_temp.itemcode     "
            ''sqlstring = sqlstring & " and b.type='GRN')"
            ''gconnection.ExcuteStoreProcedure(sqlstring)
            'sqlstring = "update MONTH_STB_temp  set RatePerBot= (SELECT TOP 1 rate from stkpurchaserate1 b where b.itemcode=MONTH_STB_temp.itemcode    "
            'sqlstring = sqlstring & " and b.type='opening'  )     "
            'sqlstring = sqlstring & " WHERE Itemcode not in (SELECT ITEMCODE from stkpurchaserate1 where TYPE='grn' )      "
            'gconnection.ExcuteStoreProcedure(sqlstring)


            sqlstring = " update MONTH_STB_temp set RatePerBot = RatePerBot / c.convvalue from inventory_transconversion c,INV_Inventoryopenningstock i where c.baseuom =i.uom and   "
            sqlstring = sqlstring & " c.transuom =MONTH_STB_temp.uom and MONTH_STB_temp.itemcode = i.itemcode and i.STORECODE in ('MNS','MRAT','FROZ')  "
            gconnection.ExcuteStoreProcedure(sqlstring)




            'sqlstring = "Update MONTH_STB_temp set TotalAmount = isnull(RatePerBot,0) * isnull(StockInBot,0) "
            'gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update MONTH_STB_temp set TotalAmount = isnull(RatePerBot,0) * isnull(TOTAL,0) "
            gconnection.ExcuteStoreProcedure(sqlstring)


            sqlstring = "Update MONTH_STB_temp set RatePerBot = 0 WHERE ISNULL(TOTAL,0)=0 "
            gconnection.ExcuteStoreProcedure(sqlstring)
            '***********
            SLSTRING = ""
            For i = 0 To chklist_itemdetails.CheckedItems.Count - 1
                itemcode1 = Split(chklist_itemdetails.CheckedItems(i), "-->")
                SLSTRING = SLSTRING & "'" & itemcode1(0) & "', "
            Next
            SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)
            '***********
            'End If
            sqlstring = "SELECT ITEMCODE, ITEMNAME," & storequery & ", TOTAL,"
            sqlstring = sqlstring & "  isnull(UOM,'') as UOM,ISNULL(StockInBot,0) as StockInBot, ISNULL(RatePerBot,0) as RatePerBot, ISNULL(TotalAmount,0) as TotalAmount "
            sqlstring = sqlstring & " FROM MONTH_STB_temp where itemcode in (" & SLSTRING & ") "
            If rdo_code.Checked = True Then
                sqlstring = sqlstring & " order by ItemCode "
            ElseIf rdo_name.Checked = True Then
                sqlstring = sqlstring & " order by ItemName "
            End If

            gconnection.getDataSet(sqlstring, "MONTH_STB_temp")

            Dim r1 As New Cry_monthstbbar
            If gdataset.Tables("MONTH_STB_temp").Rows.Count > 0 Then
                If chk_excel.Checked = True Then
                    Dim sqls, sqlsTot As String
                    sqls = "SELECT ITEMCODE, ITEMNAME,isnull(UOM,'') as UOM," & StoreExcel & ", TOTAL,"
                    sqls = sqls & "  ISNULL(StockInBot,0) as StockInBot, ISNULL(RatePerBot,0) as RatePerBot, ISNULL(TotalAmount,0) as TotalAmount "
                    sqls = sqls & " FROM MONTH_STB_temp where itemcode in (" & SLSTRING & ") "
                    If rdo_code.Checked = True Then
                        sqls = sqls & " order by ItemCode "
                    ElseIf rdo_name.Checked = True Then
                        sqls = sqls & " order by ItemName "
                    End If

                    sqlsTot = "SELECT 'GRAND TOTAL', '',''," & StoreExcelSum & ", SUM(TOTAL),"
                    sqlsTot = sqlsTot & "  SUM(ISNULL(StockInBot,0)) as StockInBot, SUM(ISNULL(RatePerBot,0)) as RatePerBot, SUM(ISNULL(TotalAmount,0)) as TotalAmount "
                    sqlsTot = sqlsTot & " FROM MONTH_STB_temp where itemcode in (" & SLSTRING & ") "
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.exportRSI(sqls, "RAJENDRA SINGHJI INSTITTUTE, BOLARUM", Format(dtp_todate.Value, "dd/MMM/yyyy"), "", sqlsTot)
                Else

                    rViewer.ssql = sqlstring
                    rViewer.Report = r1
                    rViewer.TableName = "MONTH_STB_temp"
                    Dim textobj1 As TextObject
                    textobj1 = r1.ReportDefinition.ReportObjects("Text9")
                    textobj1.Text = gCompanyname

                    Dim textobj4 As TextObject
                    textobj4 = r1.ReportDefinition.ReportObjects("Text14")
                    textobj4.Text = gUsername

                    Dim textobj6 As TextObject
                    textobj6 = r1.ReportDefinition.ReportObjects("Text8")
                    textobj6.Text = gCompanyAddress(0)

                    Dim textobj7 As TextObject
                    textobj7 = r1.ReportDefinition.ReportObjects("Text10")
                    textobj7.Text = gCompanyAddress(1)

                    Dim t2 As TextObject
                    t2 = r1.ReportDefinition.ReportObjects("Text16")
                    t2.Text = Format(dtp_fromdate.Value, "dd/MM/yyyy")
                    Dim t1 As TextObject
                    t1 = r1.ReportDefinition.ReportObjects("Text18")
                    t1.Text = Format(dtp_todate.Value, "dd/MM/yyyy")

                    For i = 1 To StoreArr.Length - 1
                        t1 = r1.ReportDefinition.ReportObjects("t" & i)
                        t1.Text = StoreArr(i)
                    Next


                    '''********************************
                    Dim sqlsTot As String
                    sqlsTot = "SELECT 'GRAND TOTAL', '',''," & StoreExcelSum & ", SUM(TOTAL),"
                    sqlsTot = sqlsTot & "  SUM(ISNULL(StockInBot,0)) as StockInBot, SUM(ISNULL(RatePerBot,0)) as RatePerBot, SUM(ISNULL(TotalAmount,0)) as TotalAmount "
                    sqlsTot = sqlsTot & " FROM MONTH_STB_temp where itemcode in (" & SLSTRING & ") "
                    gconnection.getDataSet(sqlsTot, "Tot")
                    If gdataset.Tables("Tot").Rows.Count > 0 Then
                        Dim tn As TextObject
                        tn = r1.ReportDefinition.ReportObjects("Text25")
                        tn.Text = gdataset.Tables("Tot").Rows(0).Item("TotalAmount")
                    End If
                    ''' ********************************



                    't1 = r1.ReportDefinition.ReportObjects("param1")
                    't1.Text = "200"
                    rViewer.Show()
                End If
                'Dim exp As New exportexcel
                'exp.Show()
                'Call exp.export(sqlstring, "MONTHLY STB OF BAR             " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")
                'Dim exp As New exportexcel
                'exp.Show()
                'Call exp.export(sqlstring, "MONTHLY STB OF ITEMS             " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")
            Else
                MessageBox.Show("NO RECORDS TO DISPLAY")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("PLZ CHECK ERROR :" + ex.Message, gCompanyname, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Function StoreWiseClosingViewAlter(StoreCode)
    '    Dim str As String
    '    Dim i As Integer
    '    str = "SELECT * FROM SYSOBJECTS WHERE name='View_StoreWiseClosingClosing' AND XTYPE='V'"
    '    gconnection.getDataSet(str, "View_StoreWiseClosingClosing")
    '    If gdataset.Tables("View_StoreWiseClosingClosing").Rows.Count > 0 Then
    '        str = " ALTER VIEW [dbo].[View_StoreWiseClosingClosing]  "
    '        str = str & " AS  "
    '        '--INVENTORY OPENING BALANCE
    '        str = str & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS clsSTOCK,SUM(ISNULL(OPVALUE,0)) AS ClsValue,'OPENING' AS TYPE, storecode, stockuom as UOM "
    '        str = str & " FROM INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' AND STORECODE IN ('" & StoreCode & "')"
    '        str = str & " GROUP BY itemcode, itemname, STORECODE, stockuom "
    '        str = str & " UNION ALL"
    '        '--GRN
    '        str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS clsSTOCK, SUM(ISNULL(AMOUNT,0)) AS ClsValue,'OPENING' AS TYPE, storecode as storecode,UOM FROM "
    '        str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
    '        str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' "
    '        str = str & " AND STORECODE IN ('" & StoreCode & "')"
    '        str = str & " GROUP BY itemcode, itemname, STORECODE,UOM "
    '        str = str & "   UNION ALL"
    '        '--PRN
    '        str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'OPENING' AS TYPE , STORECODE as STORECODE,UOM "
    '        str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
    '        str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' "
    '        str = str & " AND STORECODE IN('" & StoreCode & "')"
    '        str = str & " GROUP BY itemcode, itemname, STORECODE,UOM "
    '        str = str & "   UNION ALL"
    '        '--ADJUSTMENT
    '        str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0)) ) AS clsSTOCK, (SUM(ISNULL(Amount,0))) AS ClsValue,'OPENING' AS TYPE, storelocationcode as storecode,UOM "
    '        str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('" & StoreCode & "')"
    '        str = str & " GROUP BY itemcode, itemname, STORELOCATIONCODE,UOM "
    '        str = str & "   UNION ALL"
    '        '--DAMAGE
    '        str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'OPENING' AS TYPE, FromStoreCode as StoreCode,UOM "
    '        str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
    '        str = str & "   '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "')  AND FROMStorecode IN  ('" & StoreCode & "')"
    '        str = str & " GROUP BY itemcode, itemname, FROMSTORECODE,UOM "
    '        str = str & "   UNION ALL"
    '        '--POS CONSUMPTION
    '        str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'OPENING' AS TYPE, StoreLocationcode as storecode,UOM "
    '        str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND STORELOCATIONCODE IN ('" & StoreCode & "')"
    '        str = str & " GROUP BY itemcode, itemname, STORELOCATIONCODE,UOM "
    '        str = str & " UNION ALL"
    '        '--STOCK ISSUE(-)
    '        str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue, 'OPENING' AS TYPE, StoreLocationcode as storecode,UOM "
    '        str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN  ('" & StoreCode & "')"
    '        str = str & " GROUP BY itemcode, itemname, STORELOCATIONCODE,UOM"
    '        str = str & " UNION ALL"
    '        '--STOCK ISSUE(+)
    '        str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0))* "
    '        str = str & " (select distinct t.CONVVALUE from INVENTORY_TRANSCONVERSION t, INVENTORYITEMMASTER i"
    '        str = str & " where t.BASEUOM=STOCKISSUEDETAIL.UOM and t.TRANSUOM=i.stockuom and i.STORECODE in ('MBST')"
    '        str = str & " and STOCKISSUEDETAIL.Itemcode=i.itemcode)"
    '        str = str & " AS clsSTOCK, SUM(ISNULL(AMOUNT,0)) AS ClsValue, 'OPENING' AS TYPE, OpStoreLocationcode as storecode,UOM "
    '        str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & "  BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Opstorelocationcode IN  ('" & StoreCode & "') and Opstorelocationcode='MBST'"
    '        str = str & "  GROUP BY itemcode, itemname, OPSTORELOCATIONCODE, UOM"
    '        str = str & " UNION ALL"







    '        '--STOCK TRANSFER (-)
    '        str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue, 'OPENING' AS TYPE, FromStorecode as storecode,UOM "
    '        str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN  ('" & StoreCode & "')"
    '        str = str & "  GROUP BY itemcode, itemname, FROMSTORECODE,UOM"
    '        str = str & " UNION ALL"
    '        '--STOCK TRANSFER (+)
    '        str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS clsSTOCK, SUM(ISNULL(AMOUNT,0)) AS ClsValue, 'OPENING' AS TYPE, ToStorecode as storecode,UOM "
    '        str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Tostorecode IN  ('" & StoreCode & "')"
    '        str = str & " GROUP BY itemcode, itemname, ToSTORECODE,UOM"
    '        gconnection.dataOperation(6, str, "item")
    '    Else
    '        str = " CREATE VIEW [dbo].[View_StoreWiseClosingClosing]  "
    '        str = str & " AS  "
    '        '--INVENTORY OPENING BALANCE
    '        str = str & " SELECT ITEMCODE, ITEMNAME,SUM(ISNULL(opstock,0)) AS OPSTOCK,SUM(ISNULL(OPVALUE,0)) AS OPVALUE,'OPENING' AS TYPE  "
    '        str = str & " FROM INVENTORYITEMMASTER WHERE ISNULL(Freeze,'')<>'Y' AND STORECODE IN ('') GROUP BY itemcode, itemname "
    '        str = str & " UNION ALL"
    '        '--GRN
    '        str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'OPENING' AS TYPE FROM "
    '        str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
    '        str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' "
    '        str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
    '        str = str & "   UNION ALL"
    '        '--PRN
    '        str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
    '        str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
    '        str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' "
    '        str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
    '        str = str & "   UNION ALL"
    '        '--ADJUSTMENT
    '        str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0)) * -1) AS ADJUSTEDSTOCK, (SUM(ISNULL(Amount,0)) * -1) AS AMOUNT,"
    '        str = str & " 'OPENING' AS TYPE FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('')"
    '        str = str & " GROUP BY itemcode, itemname "
    '        str = str & "   UNION ALL"
    '        '--DAMAGE
    '        str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
    '        str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
    '        str = str & "   '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "')  AND FROMStorecode IN ('') "
    '        str = str & " GROUP BY itemcode, itemname "
    '        str = str & "   UNION ALL"
    '        '--POS CONSUMPTION
    '        str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
    '        str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') GROUP BY itemcode, itemname"
    '        str = str & " UNION ALL"
    '        '--STOCK ISSUE(-)
    '        str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE "
    '        str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('') GROUP BY itemcode, itemname"
    '        str = str & " UNION ALL"
    '        '--STOCK ISSUE(+)
    '        str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE "
    '        str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & "  BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Opstorelocationcode IN ('') GROUP BY itemcode, itemname"
    '        str = str & " UNION ALL"
    '        '--STOCK TRANSFER (-)
    '        str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE"
    '        str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
    '        str = str & " UNION ALL"
    '        '--STOCK TRANSFER (+)
    '        str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE"
    '        str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
    '        str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
    '        gconnection.dataOperation1(6, str, "item")
    '    End If
    'End Function

    Private Sub chklst_Store_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklst_Store.SelectedIndexChanged
        'Dim i, J As Integer
        'Dim sqlstring, ssql As String
        'chklist_groupdesc.Items.Clear()
        'ssql = ""
        ''sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
        ''sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' and I.GROUPNAME IN ("
        'sqlstring = "SELECT distinct ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPNAME,'') AS GROUPDESC FROM INVENTORYITEMMASTER WHERE STORECODE in ("
        'For J = 0 To chklst_Store.CheckedItems.Count - 1
        '    If J = chklst_Store.CheckedItems.Count - 1 Then
        '        ssql = ssql & " '" & chklst_Store.CheckedItems(J) & "' "
        '    Else
        '        ssql = ssql & " '" & chklst_Store.CheckedItems(J) & "', "
        '    End If
        'Next
        'If chklst_Store.CheckedItems.Count > 0 Then
        '    sqlstring = sqlstring & ssql & ") GROUP BY GROUPCODE,GROUPNAME "
        '    gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
        '    If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
        '        chklist_itemdetails.Items.Clear()
        '        For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
        '            With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
        '                chklist_groupdesc.Items.Add(Trim(.Item("GROUPDESC")))
        '            End With
        '        Next i
        '    End If
        'Else
        '    chklist_groupdesc.Items.Clear()
        'End If
    End Sub




    Private Function StoreWiseClosingViewAlterN(StoreCode)
        Dim str As String
        Dim i As Integer
        str = "SELECT * FROM SYSOBJECTS WHERE name='View_StoreWiseClosingClosingN' AND XTYPE='V'"
        gconnection.getDataSet(str, "View_StoreWiseClosingClosingN")
        If gdataset.Tables("View_StoreWiseClosingClosingN").Rows.Count > 0 Then
            str = " ALTER VIEW [dbo].[View_StoreWiseClosingClosingN]  "
            str = str & " AS  "
            '--INVENTORY OPENING BALANCE

            str = str & " SELECT i.ITEMCODE, I.ITEMNAME,SUM(ISNULL(OPENNINGQTY,0)) As clsSTOCK,SUM(ISNULL(OPENNINGVALUE,0)) As ClsValue,'Opening' AS TYPE, storecode, stockuom as UOM  "
            str = str & " From INV_INVENTORYITEMMASTER I, INV_Inventoryopenningstock O Where O.ITEMCODE = i.ITEMCODE And ISNULL(i.VOID,'')<>'Y' AND STORECODE IN ('" & StoreCode & "')"
                str = str & " GROUP BY  I.itemcode, I.itemname, STORECODE, stockuom  "
                str = str & " UNION ALL"
            '--GRN
            str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS clsSTOCK, SUM(ISNULL(AMOUNT,0)) AS ClsValue,'Opening' AS TYPE, storecode as storecode,UOM FROM "
            str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND ISNULL(grntype,'')='GRN' "
            str = str & " AND STORECODE IN ('" & StoreCode & "')"
            str = str & " GROUP BY itemcode, itemname, STORECODE,UOM "
            str = str & "   UNION ALL"
            '--PRN
            str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'Purchase' AS TYPE , STORECODE as STORECODE,UOM "
            str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND ISNULL(grntype,'')='PRN' "
            str = str & " AND STORECODE IN('" & StoreCode & "')"
            str = str & " GROUP BY itemcode, itemname, STORECODE,UOM "
            str = str & "   UNION ALL"
            '--ADJUSTMENT
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0)) ) AS clsSTOCK, (SUM(ISNULL(Amount,0))) AS ClsValue,'Adjustment' AS TYPE, storelocationcode as storecode,UOM "
            str = str & " FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND Storelocationcode IN ('" & StoreCode & "')"
            str = str & " GROUP BY itemcode, itemname, STORELOCATIONCODE,UOM "
            str = str & "   UNION ALL"
            '--DAMAGE
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(dmgqty,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'Damage' AS TYPE, StoreCode as StoreCode,UOM "
            str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
            str = str & "   '" & gstartingdate & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "'  AND StoreCode IN  ('" & StoreCode & "')"
            str = str & " GROUP BY itemcode, itemname, StoreCode,UOM "
                str = str & "   UNION ALL"
            '--POS CONSUMPTION
            'str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'Consumption' AS TYPE, StoreLocationcode as storecode,UOM "
            'str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            'str = str & " BETWEEN '" & gstartingdate & "' and '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND STORELOCATIONCODE IN ('" & StoreCode & "')"
            'str = str & " GROUP BY itemcode, itemname, STORELOCATIONCODE,UOM "
            'str = str & " UNION ALL"
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(qty,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'Consumption' AS TYPE, StoreLocationcode as storecode,UOM "
            str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' and '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND STORELOCATIONCODE IN ('" & StoreCode & "')"
            str = str & " GROUP BY itemcode, itemname, STORELOCATIONCODE,UOM "
            str = str & " UNION ALL"
            '--STOCK ISSUE(-)
            str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue, 'Stock Issue' AS TYPE, StoreLocationcode as storecode,UOM "
            str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' and '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND Storelocationcode IN  ('" & StoreCode & "')"
            str = str & " GROUP BY itemcode, itemname, STORELOCATIONCODE,UOM"
            str = str & " UNION ALL"
            '--STOCK ISSUE(+)
            str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0))* "
            str = str & " (select distinct t.CONVVALUE from INVENTORY_TRANSCONVERSION t, INVENTORYITEMMASTER i"
            str = str & " where t.BASEUOM=STOCKISSUEDETAIL.UOM and t.TRANSUOM=i.stockuom and i.STORECODE in ('MBST')"
            str = str & " and STOCKISSUEDETAIL.Itemcode=i.itemcode)"
            str = str & " AS clsSTOCK, SUM(ISNULL(AMOUNT,0)) AS ClsValue, 'Stock Recv' AS TYPE, OpStoreLocationcode as storecode,UOM "
            str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & "  BETWEEN '" & gstartingdate & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND Opstorelocationcode IN  ('" & StoreCode & "') and Opstorelocationcode='MBST'"
            str = str & "  GROUP BY itemcode, itemname, OPSTORELOCATIONCODE, UOM"
            str = str & " UNION ALL"

            '--STOCK TRANSFER (-)
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue, 'Stock Trf N' AS TYPE, FromStorecode as storecode,UOM "
            str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND Fromstorecode IN  ('" & StoreCode & "')"
            str = str & "  GROUP BY itemcode, itemname, FROMSTORECODE,UOM"
            str = str & " UNION ALL"
            '--STOCK TRANSFER (+)
            str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS clsSTOCK, SUM(ISNULL(AMOUNT,0)) AS ClsValue, 'Stock Trf P' AS TYPE, ToStorecode as storecode,UOM "
            str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' AND Tostorecode IN  ('" & StoreCode & "')"
            str = str & " GROUP BY itemcode, itemname, ToSTORECODE,UOM"
            gconnection.dataOperation(6, str, "item")
        Else
            str = " CREATE VIEW [dbo].[View_StoreWiseClosingClosingN]  "
            str = str & " AS  "
            '--INVENTORY OPENING BALANCE
            str = str & " SELECT i.ITEMCODE, I.ITEMNAME,SUM(ISNULL(OPENNINGQTY,0)) As clsSTOCK,SUM(ISNULL(OPENNINGVALUE,0)) As ClsValue,'Opening' AS TYPE, storecode, stockuom as UOM  "
            str = str & " From INV_INVENTORYITEMMASTER I, INV_Inventoryopenningstock O Where O.ITEMCODE = i.ITEMCODE And ISNULL(i.VOID,'')<>'Y' AND STORECODE IN ('" & StoreCode & "')"
            str = str & " GROUP BY  I.itemcode, I.itemname, STORECODE, stockuom  "
            str = str & " UNION ALL"
            '--GRN
            str = str & " SELECT ITEMCODE, ITEMNAME, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT,'OPENING' AS TYPE FROM "
            str = str & " GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='GRN' "
            str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--PRN
            str = str & " SELECT ITEMCODE, ITEMNAME, (SUM(ISNULL(Qty,0))  * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
            str = str & " FROM GRN_DETAILS WHERE ISNULL(Voiditem,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Grndate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND ISNULL(grntype,'')='PRN' "
            str = str & " AND STORECODE IN ('') GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--ADJUSTMENT
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(ADJUSTEDSTOCK,0)) * -1) AS ADJUSTEDSTOCK, (SUM(ISNULL(Amount,0)) * -1) AS AMOUNT,"
            str = str & " 'OPENING' AS TYPE FROM STOCKADJUSTDETAILS WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('')"
            str = str & " GROUP BY itemcode, itemname "
            str = str & "   UNION ALL"
            '--DAMAGE
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(dmgqty,0)) * -1) AS clsSTOCK, (SUM(ISNULL(AMOUNT,0)) * -1) AS ClsValue,'Damage' AS TYPE, StoreCode as StoreCode,UOM "
            str = str & " FROM STOCKDMGDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) BETWEEN "
            str = str & "   '" & gstartingdate & "' AND '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "'  AND StoreCode IN  ('" & StoreCode & "')"
            str = str & " GROUP BY itemcode, itemname, StoreCode,UOM "
            str = str & "   UNION ALL"
            '--POS CONSUMPTION
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT,'OPENING' AS TYPE "
            str = str & " FROM SUBSTORECONSUMPTIONDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK ISSUE(-)
            str = str & " SELECT Itemcode, Itemname,(SUM(ISNULL(QTY,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE "
            str = str & "  FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & "   BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Storelocationcode IN ('') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK ISSUE(+)
            str = str & " SELECT Itemcode, Itemname,SUM(ISNULL(QTY,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE "
            str = str & " FROM STOCKISSUEDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & "  BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Opstorelocationcode IN ('') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK TRANSFER (-)
            str = str & " SELECT Itemcode, Itemname, (SUM(ISNULL(Qty,0)) * -1) AS QTY, (SUM(ISNULL(AMOUNT,0)) * -1) AS AMOUNT, 'OPENING' AS TYPE"
            str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
            str = str & " UNION ALL"
            '--STOCK TRANSFER (+)
            str = str & " SELECT Itemcode, Itemname, SUM(ISNULL(Qty,0)) AS QTY, SUM(ISNULL(AMOUNT,0)) AS AMOUNT, 'OPENING' AS TYPE"
            str = str & " FROM STOCKTRANSFERDETAIL WHERE ISNULL(Void,'')<>'Y' AND CAST(CONVERT(VARCHAR(11),Docdate,106) AS DATETIME) "
            str = str & " BETWEEN '" & gstartingdate & "' AND DateAdd(Day, -1, '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "') AND Fromstorecode IN ('') GROUP BY itemcode, itemname"
            gconnection.dataOperation1(6, str, "item")
        End If
    End Function

    Private Sub SalesStatementReport()
        Try

            Dim str, MTYPE(), tspilt(), SITEMCODE As String
            Dim i, j As Integer
            Dim rViewer As New Viewer
            'Dim r As New CrysTotalSalesStatement
            Dim r As New CrysTotalSalesStatementNew
            Dim sqlstring, SSQL As String

            Dim Itemcode(), Itemcode1, Storecode As String
            Dim Boolupdate As Boolean
            Storecode = "" : i = 0
            Dim SLSTRING As String
            Dim rate As Double


            sqlstring = "Truncate Table TempSalesStatement"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Truncate Table SalesStatement"
            gconnection.ExcuteStoreProcedure(sqlstring)

            For j = 0 To (chklst_Store.CheckedItems.Count - 1)
                Storecode = chklst_Store.CheckedItems(j)

                sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STORECODE = '" & Storecode & "'"
                gconnection.getDataSet(sqlstring, "STOREMASTER")
                If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                    Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
                Else
                    Storecode = "MNS"
                End If
                If chklist_itemdetails.CheckedItems.Count = 0 Then
                    sqlstring = "Update inventoryitemmaster set selectopt=''"
                    gconnection.dataOperation(6, sqlstring, "ItemMaster")

                Else
                    SLSTRING = ""
                    For i = 0 To chklist_itemdetails.CheckedItems.Count - 1
                        Itemcode = Split(chklist_itemdetails.CheckedItems(i), "-->")
                        SLSTRING = SLSTRING & "'" & Itemcode(0) & "', "
                    Next
                    SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)
                    sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & SLSTRING & ")"
                    gconnection.getDataSet(sqlstring, "ITEMMASTER1")

                    sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='Y' WHERE ITEMCODE IN(" & SLSTRING & ")"
                    gconnection.getDataSet(sqlstring, "ITEMMASTER")
                End If


                Me.Cursor = Cursors.WaitCursor

                '---------------------- EXECUTE STORE PROCEDURE --------------------------'
                gconnection.openConnection()
                gcommand = New SqlCommand("Cp_StockSummary3", gconnection.Myconn)

                gcommand.CommandTimeout = 1000000000
                gcommand.CommandType = CommandType.StoredProcedure
                gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
                gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_fromdate.Value), "dd/MMM/yyyy")
                gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy")
                gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
                gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy")
                gcommand.ExecuteNonQuery()
                gconnection.closeConnection()

                Me.Cursor = Cursors.Default
                '--------------------------------------------------------------------------'

                sqlstring = "Insert Into TempSalesStatement (OpBal,ClsBal)"
                sqlstring = sqlstring & " (Select SUM(isnull(Opval,0)), SUM(isnull(Clsval,0)) from STOCKSUMMARY)"
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = "Insert Into TempSalesStatement (OpBalSoft,ClsBalSoft)"
                sqlstring = sqlstring & " (Select SUM(isnull(Opval,0)), SUM(isnull(Clsval,0)) from STOCKSUMMARY Where SubGroupCode in ('001','09','COCK','11','08','12'))"
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = "Insert Into TempSalesStatement (OpBalLiq,ClsBalLiq)"
                sqlstring = sqlstring & " (Select SUM(isnull(Opval,0)), SUM(isnull(Clsval,0)) from STOCKSUMMARY Where SubGroupCode in ('01','02','03','04','05','06','07'))"
                gconnection.ExcuteStoreProcedure(sqlstring)
            Next

            ' '''---------- RUN STORED PROCEDURE FOR MAIN STORE --------------------------
            'If chklist_itemdetails.CheckedItems.Count = 0 Then
            '    sqlstring = "Update inventoryitemmaster set selectopt=''"
            '    gconnection.dataOperation(6, sqlstring, "ItemMaster")
            'Else
            '    SLSTRING = ""
            '    For i = 0 To chklist_itemdetails.CheckedItems.Count - 1
            '        Itemcode = Split(chklist_itemdetails.CheckedItems(i), "-->")
            '        SLSTRING = SLSTRING & "'" & Itemcode(0) & "', "
            '    Next
            '    SLSTRING = Mid(SLSTRING, 1, Len(SLSTRING) - 2)
            '    sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & SLSTRING & ")"
            '    gconnection.getDataSet(sqlstring, "ITEMMASTER1")

            '    sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='Y' WHERE ITEMCODE IN(" & SLSTRING & ")"
            '    gconnection.getDataSet(sqlstring, "ITEMMASTER")
            'End If
            'Me.Cursor = Cursors.WaitCursor
            'gconnection.openConnection()
            'gcommand = New SqlCommand("Cp_StockSummary3", gconnection.Myconn)

            'gcommand.CommandTimeout = 1000000000
            'gcommand.CommandType = CommandType.StoredProcedure
            'gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = "MNS"
            'gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_fromdate.Value), "dd/MMM/yyyy")
            'gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy")
            'gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
            'gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy")
            'gcommand.ExecuteNonQuery()
            'gconnection.closeConnection()
            'Me.Cursor = Cursors.Default
            '--------------------------------------------------------------------------'

            sqlstring = "Insert Into TempSalesStatement (RcvBal)"
            sqlstring = sqlstring & " (Select SUM(isnull(Amount,0)) from StockIssueDetail where Opstorelocationcode='MBST' and CAST(CONVERT(Varchar(11),Docdate,106) AS Datetime) between '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' And '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' And Isnull(Void,'')<>'Y')"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "Insert Into TempSalesStatement (RcvBalLiq)"
            sqlstring = sqlstring & " (Select SUM(isnull(Amount,0)) from StockIssueDetail where Opstorelocationcode='MBST' and CAST(CONVERT(Varchar(11),Docdate,106) AS Datetime) between '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' And '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' And  Subgroupcode in ('01','02','03','04','05','06','07') And Isnull(Void,'')<>'Y')"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "Insert Into TempSalesStatement (RcvBalSoft)"
            sqlstring = sqlstring & " (Select SUM(isnull(Amount,0)) from StockIssueDetail where Opstorelocationcode='MBST' and CAST(CONVERT(Varchar(11),Docdate,106) AS Datetime) between '" & Format(dtp_fromdate.Value, "dd/MMM/yyyy") & "' And '" & Format(dtp_todate.Value, "dd/MMM/yyyy") & "' And  Subgroupcode in ('001','09','COCK','11','08','12') And Isnull(Void,'')<>'Y')"
            gconnection.ExcuteStoreProcedure(sqlstring)
            ''' ---------------------------------------------------------------------------



            '---------------------- EXECUTE STORE PROCEDURE --------------------------'
            gconnection.openConnection()
            gcommand = New SqlCommand("POS_POSWISE", gconnection.Myconn)

            gcommand.CommandTimeout = 1000000000
            gcommand.CommandType = CommandType.StoredProcedure
            gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_fromdate.Value), "dd/MMM/yyyy")
            gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(dtp_todate.Value), "dd/MMM/yyyy")
            gcommand.ExecuteNonQuery()
            gconnection.closeConnection()

            Me.Cursor = Cursors.Default
            '--------------------------------------------------------------------------'
            sqlstring = "Insert Into TempSalesStatement (CashSale)"
            sqlstring = sqlstring & " (select sum(Amount) from POSWISESALES where Paymentmode='Cash' and category='BAR')"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Insert Into TempSalesStatement (MaintSale)"
            sqlstring = sqlstring & " (select sum(Amount) from POSWISESALES where Paymentmode='MAINTENANCE'  and category='BAR')"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Insert Into TempSalesStatement (CreditSale)"
            sqlstring = sqlstring & " (select sum(Amount) from POSWISESALES where Paymentmode='CREDIT'  and category='BAR')"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Insert Into TempSalesStatement (PartySale)"
            sqlstring = sqlstring & " (select sum(Amount) from POSWISESALES where Paymentmode in ('PARTY','PARTY SALES')  and category='BAR')"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "Insert Into SalesStatement (OpBal,RcvBal,ClsBal,CashSale,MaintSale,CreditSale,PartySale,"
            sqlstring = sqlstring & " OpBalSoft,RcvBalSoft,ClsBalSoft,OpBalLiq,RcvBalLiq,ClsBalLiq)"
            sqlstring = sqlstring & " (Select SUM(isnull(OpBal,0)), SUM(isnull(RcvBal,0)), SUM(isnull(ClsBal,0)), "
            sqlstring = sqlstring & " Sum(isnull(CashSale,0)), Sum(isnull(MaintSale,0)), Sum(isnull(CreditSale,0)), "
            sqlstring = sqlstring & " Sum(isnull(PartySale,0)),SUM(isnull(OpBalSoft,0)), SUM(isnull(RcvBalSoft,0)), "
            sqlstring = sqlstring & " SUM(isnull(ClsBalSoft,0)),SUM(isnull(OpBalLiq,0)), SUM(isnull(RcvBalLiq,0)), "
            sqlstring = sqlstring & " SUM(isnull(ClsBalLiq,0)) from TempSalesStatement)"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "Update SalesStatement Set ActualExp = (OpBal + RcvBal) - ClsBal"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update SalesStatement Set ActualExpSoft = (OpBalSoft + RcvBalSoft) - ClsBalSoft"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update SalesStatement Set ActualExpLiq = (OpBalLiq + RcvBalLiq) - ClsBalLiq"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "Update SalesStatement Set TotalSale = (select sum(Amount) from POSWISESALES where category='BAR')"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update SalesStatement Set TotalSaleSoft = (select sum(Amount) from POSWISESALES where category='BAR' "
            sqlstring = sqlstring & " And  ITEMCODE in (Select ITEMCODE from ItemMaster  where SUBGROUPCODE in "
            sqlstring = sqlstring & " ('SODA','SF','CIG','BJUC','MOCK','COCK')))"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update SalesStatement Set TotalSaleLiq = (select sum(Amount) from POSWISESALES where category='BAR' "
            sqlstring = sqlstring & " And  ITEMCODE in (Select ITEMCODE from ItemMaster  where SUBGROUPCODE in "
            sqlstring = sqlstring & " ('BEER','WINE','RUM','WSKY','BRAN','GIN','VOD')))"
            gconnection.ExcuteStoreProcedure(sqlstring)

            '***********************
            sqlstring = "Update SalesStatement Set TotalStockLiq = OpBalLiq + RcvBalLiq "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update SalesStatement Set TotalStockSoft = OpBalSoft + RcvBalSoft "
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update SalesStatement Set TotalStock = TotalStockLiq + TotalStockSoft "
            gconnection.ExcuteStoreProcedure(sqlstring)
            '***********************

            sqlstring = "Update SalesStatement Set NetProfit = TotalSale - ActualExp"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update SalesStatement Set NetProfitSoft = TotalSaleSoft - ActualExpSoft"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update SalesStatement Set NetProfitLiq = TotalSaleLiq - ActualExpLiq"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "Update SalesStatement Set ProfitPer = ((NetProfit * 100)/ActualExp) WHERE ISNULL(ActualExp,0)>0"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update SalesStatement Set ProfitPerSoft = ((NetProfitSoft * 100)/ActualExpSoft) WHERE ISNULL(ActualExpSoft,0)>0"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "Update SalesStatement Set ProfitPerLiq = ((NetProfitLiq * 100)/ActualExpLiq) WHERE ISNULL(ActualExpLiq,0)>0"
            gconnection.ExcuteStoreProcedure(sqlstring)

            sqlstring = "SELECT * FROM SalesStatement"
            gconnection.getDataSet(sqlstring, "SalesStatement")
            If gdataset.Tables("SalesStatement").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "SalesStatement"

                Dim textobj7 As TextObject
                textobj7 = r.ReportDefinition.ReportObjects("Text27")
                textobj7.Text = "RSI BAR EXPENDITURE / SALES STATEMENT - MONTH OF " & Format(dtp_todate.Value, "MMMMM") & " - " & Format(dtp_todate.Value, "yyyy")
                rViewer.Show()
            End If


        Catch ex As Exception
            MessageBox.Show("Plz Check Error: " + ex.Message)
        End Try
    End Sub
End Class
