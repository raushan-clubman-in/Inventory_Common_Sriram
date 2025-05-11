Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmTaxReport
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
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents opt_Purchasedetails As System.Windows.Forms.RadioButton
    Friend WithEvents opt_Purchasesummary As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grp_SalebillChecklist As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllSupplier As System.Windows.Forms.CheckBox
    Friend WithEvents chklst_Supplier As System.Windows.Forms.CheckedListBox
    Friend WithEvents dtp_Fromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Todate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Chk_AllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents ChkLst_Group As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Chk_AllItem As System.Windows.Forms.CheckBox
    Friend WithEvents ChkLst_Item As System.Windows.Forms.CheckedListBox
    Friend WithEvents cbo_Storelocation As System.Windows.Forms.ComboBox
    Friend WithEvents CHK_ITEM As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_itemto As System.Windows.Forms.Button
    Friend WithEvents txt_itemto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXT_FROM As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_ITEMFROM As System.Windows.Forms.Button
    Friend WithEvents Lbl_SubledgerCode As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Opt_purchase As System.Windows.Forms.RadioButton
    Friend WithEvents Opt_Return As System.Windows.Forms.RadioButton
    Friend WithEvents OptAll As System.Windows.Forms.RadioButton
    Friend WithEvents CBO_SELECTALL As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exprot As System.Windows.Forms.Button
    Friend WithEvents opt_Singlesupplier As System.Windows.Forms.RadioButton
    Friend WithEvents grp_orderby As System.Windows.Forms.GroupBox
    Friend WithEvents RB_ITC As System.Windows.Forms.RadioButton
    Friend WithEvents RB_rev As System.Windows.Forms.RadioButton
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_Mainstore As System.Windows.Forms.Label
    Friend WithEvents txt_Mainstorecode As System.Windows.Forms.TextBox
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_Mainstore As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents Chk_pendingpo As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CKB_venType As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents btn_validation As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTaxReport))
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.btn_validation = New System.Windows.Forms.Button()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.cmd_exprot = New System.Windows.Forms.Button()
        Me.opt_Purchasedetails = New System.Windows.Forms.RadioButton()
        Me.opt_Purchasesummary = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Chk_SelectAllSupplier = New System.Windows.Forms.CheckBox()
        Me.chklst_Supplier = New System.Windows.Forms.CheckedListBox()
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lbl_Wait = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.dtp_Fromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp_Todate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Chk_AllGroup = New System.Windows.Forms.CheckBox()
        Me.ChkLst_Group = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_AllItem = New System.Windows.Forms.CheckBox()
        Me.ChkLst_Item = New System.Windows.Forms.CheckedListBox()
        Me.cbo_Storelocation = New System.Windows.Forms.ComboBox()
        Me.CHK_ITEM = New System.Windows.Forms.CheckBox()
        Me.cmd_itemto = New System.Windows.Forms.Button()
        Me.txt_itemto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXT_FROM = New System.Windows.Forms.TextBox()
        Me.Cmd_ITEMFROM = New System.Windows.Forms.Button()
        Me.Lbl_SubledgerCode = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RB_ITC = New System.Windows.Forms.RadioButton()
        Me.RB_rev = New System.Windows.Forms.RadioButton()
        Me.opt_Singlesupplier = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Chk_pendingpo = New System.Windows.Forms.CheckBox()
        Me.OptAll = New System.Windows.Forms.RadioButton()
        Me.Opt_Return = New System.Windows.Forms.RadioButton()
        Me.Opt_purchase = New System.Windows.Forms.RadioButton()
        Me.CBO_SELECTALL = New System.Windows.Forms.CheckBox()
        Me.grp_orderby = New System.Windows.Forms.GroupBox()
        Me.lbl_Mainstore = New System.Windows.Forms.Label()
        Me.txt_Mainstorecode = New System.Windows.Forms.TextBox()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Mainstore = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CKB_venType = New System.Windows.Forms.CheckedListBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmbut.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Cmd_Print.Location = New System.Drawing.Point(2, 109)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Print.TabIndex = 6
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
        Me.Cmd_View.Location = New System.Drawing.Point(2, 61)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_View.TabIndex = 5
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(2, 157)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Exit.TabIndex = 7
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(2, 13)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Clear.TabIndex = 4
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'btn_validation
        '
        Me.btn_validation.BackColor = System.Drawing.Color.Transparent
        Me.btn_validation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_validation.ForeColor = System.Drawing.Color.Black
        Me.btn_validation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_validation.Location = New System.Drawing.Point(856, 64)
        Me.btn_validation.Name = "btn_validation"
        Me.btn_validation.Size = New System.Drawing.Size(134, 38)
        Me.btn_validation.TabIndex = 464
        Me.btn_validation.Text = "Validation"
        Me.btn_validation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_validation.UseVisualStyleBackColor = False
        Me.btn_validation.Visible = False
        '
        'chk_excel
        '
        Me.chk_excel.BackColor = System.Drawing.Color.Transparent
        Me.chk_excel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_excel.Location = New System.Drawing.Point(2, 209)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(104, 24)
        Me.chk_excel.TabIndex = 463
        Me.chk_excel.Text = "EXCEL"
        Me.chk_excel.UseVisualStyleBackColor = False
        '
        'cmd_exprot
        '
        Me.cmd_exprot.BackColor = System.Drawing.Color.Transparent
        Me.cmd_exprot.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_exprot.ForeColor = System.Drawing.Color.Black
        Me.cmd_exprot.Location = New System.Drawing.Point(392, 680)
        Me.cmd_exprot.Name = "cmd_exprot"
        Me.cmd_exprot.Size = New System.Drawing.Size(104, 32)
        Me.cmd_exprot.TabIndex = 6
        Me.cmd_exprot.Text = "Export"
        Me.cmd_exprot.UseVisualStyleBackColor = False
        Me.cmd_exprot.Visible = False
        '
        'opt_Purchasedetails
        '
        Me.opt_Purchasedetails.BackColor = System.Drawing.Color.Transparent
        Me.opt_Purchasedetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_Purchasedetails.Location = New System.Drawing.Point(2, 48)
        Me.opt_Purchasedetails.Name = "opt_Purchasedetails"
        Me.opt_Purchasedetails.Size = New System.Drawing.Size(96, 25)
        Me.opt_Purchasedetails.TabIndex = 2
        Me.opt_Purchasedetails.Text = "DETAILS"
        Me.opt_Purchasedetails.UseVisualStyleBackColor = False
        '
        'opt_Purchasesummary
        '
        Me.opt_Purchasesummary.BackColor = System.Drawing.Color.Transparent
        Me.opt_Purchasesummary.Checked = True
        Me.opt_Purchasesummary.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_Purchasesummary.Location = New System.Drawing.Point(2, 18)
        Me.opt_Purchasesummary.Name = "opt_Purchasesummary"
        Me.opt_Purchasesummary.Size = New System.Drawing.Size(104, 21)
        Me.opt_Purchasesummary.TabIndex = 3
        Me.opt_Purchasesummary.TabStop = True
        Me.opt_Purchasesummary.Text = "SUMMARY"
        Me.opt_Purchasesummary.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Maroon
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(346, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 24)
        Me.Label4.TabIndex = 423
        Me.Label4.Text = "SUPPLIER SELECTION :"
        '
        'Chk_SelectAllSupplier
        '
        Me.Chk_SelectAllSupplier.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllSupplier.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SelectAllSupplier.Location = New System.Drawing.Point(350, 5)
        Me.Chk_SelectAllSupplier.Name = "Chk_SelectAllSupplier"
        Me.Chk_SelectAllSupplier.Size = New System.Drawing.Size(136, 24)
        Me.Chk_SelectAllSupplier.TabIndex = 422
        Me.Chk_SelectAllSupplier.Text = "SELECT ALL "
        Me.Chk_SelectAllSupplier.UseVisualStyleBackColor = False
        '
        'chklst_Supplier
        '
        Me.chklst_Supplier.CheckOnClick = True
        Me.chklst_Supplier.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklst_Supplier.Location = New System.Drawing.Point(346, 53)
        Me.chklst_Supplier.Name = "chklst_Supplier"
        Me.chklst_Supplier.Size = New System.Drawing.Size(224, 324)
        Me.chklst_Supplier.TabIndex = 421
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.BackColor = System.Drawing.Color.Transparent
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(21, 626)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(657, 50)
        Me.grp_SalebillChecklist.TabIndex = 424
        Me.grp_SalebillChecklist.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(643, 32)
        Me.ProgressBar1.TabIndex = 0
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
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.PictureBox5)
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.dtp_Fromdate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.dtp_Todate)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(78, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(642, 49)
        Me.GroupBox3.TabIndex = 425
        Me.GroupBox3.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Location = New System.Drawing.Point(382, 11)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox5.TabIndex = 491
        Me.PictureBox5.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(142, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox2.TabIndex = 490
        Me.PictureBox2.TabStop = False
        '
        'dtp_Fromdate
        '
        Me.dtp_Fromdate.CustomFormat = "dd-MM-yyyy"
        Me.dtp_Fromdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Fromdate.Location = New System.Drawing.Point(179, 16)
        Me.dtp_Fromdate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.dtp_Fromdate.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
        Me.dtp_Fromdate.Name = "dtp_Fromdate"
        Me.dtp_Fromdate.Size = New System.Drawing.Size(104, 21)
        Me.dtp_Fromdate.TabIndex = 0
        Me.dtp_Fromdate.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(317, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TO DATE :"
        '
        'dtp_Todate
        '
        Me.dtp_Todate.CustomFormat = "dd-MM-yyyy"
        Me.dtp_Todate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Todate.Location = New System.Drawing.Point(421, 17)
        Me.dtp_Todate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.dtp_Todate.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
        Me.dtp_Todate.Name = "dtp_Todate"
        Me.dtp_Todate.Size = New System.Drawing.Size(104, 21)
        Me.dtp_Todate.TabIndex = 1
        Me.dtp_Todate.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
        '
        'Timer1
        '
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(97, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 24)
        Me.Label2.TabIndex = 429
        Me.Label2.Text = "STORE SELECTION :"
        '
        'Chk_AllGroup
        '
        Me.Chk_AllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_AllGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_AllGroup.Location = New System.Drawing.Point(97, 5)
        Me.Chk_AllGroup.Name = "Chk_AllGroup"
        Me.Chk_AllGroup.Size = New System.Drawing.Size(136, 24)
        Me.Chk_AllGroup.TabIndex = 428
        Me.Chk_AllGroup.Text = "SELECT ALL "
        Me.Chk_AllGroup.UseVisualStyleBackColor = False
        '
        'ChkLst_Group
        '
        Me.ChkLst_Group.CheckOnClick = True
        Me.ChkLst_Group.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkLst_Group.Location = New System.Drawing.Point(96, 53)
        Me.ChkLst_Group.Name = "ChkLst_Group"
        Me.ChkLst_Group.Size = New System.Drawing.Size(216, 84)
        Me.ChkLst_Group.TabIndex = 427
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Maroon
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(585, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 24)
        Me.Label3.TabIndex = 432
        Me.Label3.Text = "ITEM SELECTION :"
        Me.Label3.Visible = False
        '
        'Chk_AllItem
        '
        Me.Chk_AllItem.BackColor = System.Drawing.Color.Transparent
        Me.Chk_AllItem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_AllItem.Location = New System.Drawing.Point(585, 5)
        Me.Chk_AllItem.Name = "Chk_AllItem"
        Me.Chk_AllItem.Size = New System.Drawing.Size(128, 24)
        Me.Chk_AllItem.TabIndex = 431
        Me.Chk_AllItem.Text = "SELECT ALL "
        Me.Chk_AllItem.UseVisualStyleBackColor = False
        Me.Chk_AllItem.Visible = False
        '
        'ChkLst_Item
        '
        Me.ChkLst_Item.CheckOnClick = True
        Me.ChkLst_Item.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkLst_Item.Location = New System.Drawing.Point(585, 53)
        Me.ChkLst_Item.Name = "ChkLst_Item"
        Me.ChkLst_Item.Size = New System.Drawing.Size(215, 324)
        Me.ChkLst_Item.TabIndex = 430
        Me.ChkLst_Item.Visible = False
        '
        'cbo_Storelocation
        '
        Me.cbo_Storelocation.BackColor = System.Drawing.Color.Wheat
        Me.cbo_Storelocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Storelocation.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.cbo_Storelocation.ItemHeight = 15
        Me.cbo_Storelocation.Location = New System.Drawing.Point(832, 672)
        Me.cbo_Storelocation.Name = "cbo_Storelocation"
        Me.cbo_Storelocation.Size = New System.Drawing.Size(158, 23)
        Me.cbo_Storelocation.TabIndex = 441
        Me.cbo_Storelocation.Visible = False
        '
        'CHK_ITEM
        '
        Me.CHK_ITEM.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ITEM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_ITEM.Location = New System.Drawing.Point(11, 142)
        Me.CHK_ITEM.Name = "CHK_ITEM"
        Me.CHK_ITEM.Size = New System.Drawing.Size(104, 24)
        Me.CHK_ITEM.TabIndex = 443
        Me.CHK_ITEM.Text = "ITEM WISE"
        Me.CHK_ITEM.UseVisualStyleBackColor = False
        Me.CHK_ITEM.Visible = False
        '
        'cmd_itemto
        '
        Me.cmd_itemto.Location = New System.Drawing.Point(299, 16)
        Me.cmd_itemto.Name = "cmd_itemto"
        Me.cmd_itemto.Size = New System.Drawing.Size(23, 26)
        Me.cmd_itemto.TabIndex = 481
        '
        'txt_itemto
        '
        Me.txt_itemto.BackColor = System.Drawing.Color.Wheat
        Me.txt_itemto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_itemto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_itemto.Location = New System.Drawing.Point(218, 19)
        Me.txt_itemto.MaxLength = 20
        Me.txt_itemto.Name = "txt_itemto"
        Me.txt_itemto.Size = New System.Drawing.Size(80, 21)
        Me.txt_itemto.TabIndex = 480
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(190, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 15)
        Me.Label8.TabIndex = 479
        Me.Label8.Text = "TO:"
        '
        'TXT_FROM
        '
        Me.TXT_FROM.BackColor = System.Drawing.Color.Wheat
        Me.TXT_FROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_FROM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_FROM.Location = New System.Drawing.Point(81, 19)
        Me.TXT_FROM.MaxLength = 20
        Me.TXT_FROM.Name = "TXT_FROM"
        Me.TXT_FROM.Size = New System.Drawing.Size(84, 21)
        Me.TXT_FROM.TabIndex = 477
        '
        'Cmd_ITEMFROM
        '
        Me.Cmd_ITEMFROM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_ITEMFROM.Location = New System.Drawing.Point(166, 16)
        Me.Cmd_ITEMFROM.Name = "Cmd_ITEMFROM"
        Me.Cmd_ITEMFROM.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_ITEMFROM.TabIndex = 478
        '
        'Lbl_SubledgerCode
        '
        Me.Lbl_SubledgerCode.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubledgerCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubledgerCode.Location = New System.Drawing.Point(0, 22)
        Me.Lbl_SubledgerCode.Name = "Lbl_SubledgerCode"
        Me.Lbl_SubledgerCode.Size = New System.Drawing.Size(75, 16)
        Me.Lbl_SubledgerCode.TabIndex = 476
        Me.Lbl_SubledgerCode.Text = "ITEM  FROM:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox1.Location = New System.Drawing.Point(502, 29)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.TabIndex = 487
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox3.Location = New System.Drawing.Point(-44, -6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox3.TabIndex = 488
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox4.Location = New System.Drawing.Point(722, 29)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox4.TabIndex = 489
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Maroon
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(752, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 24)
        Me.Label9.TabIndex = 490
        Me.Label9.Text = "F3"
        Me.Label9.Visible = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Maroon
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(281, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 24)
        Me.Label10.TabIndex = 491
        Me.Label10.Text = "F2"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Maroon
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(534, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 24)
        Me.Label11.TabIndex = 492
        Me.Label11.Text = "F4"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Lbl_SubledgerCode)
        Me.GroupBox1.Controls.Add(Me.TXT_FROM)
        Me.GroupBox1.Controls.Add(Me.Cmd_ITEMFROM)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txt_itemto)
        Me.GroupBox1.Controls.Add(Me.cmd_itemto)
        Me.GroupBox1.Location = New System.Drawing.Point(362, 579)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 56)
        Me.GroupBox1.TabIndex = 493
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.RB_ITC)
        Me.GroupBox4.Controls.Add(Me.RB_rev)
        Me.GroupBox4.Controls.Add(Me.opt_Purchasedetails)
        Me.GroupBox4.Controls.Add(Me.CHK_ITEM)
        Me.GroupBox4.Controls.Add(Me.opt_Purchasesummary)
        Me.GroupBox4.Controls.Add(Me.opt_Singlesupplier)
        Me.GroupBox4.Location = New System.Drawing.Point(810, 363)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(138, 205)
        Me.GroupBox4.TabIndex = 495
        Me.GroupBox4.TabStop = False
        '
        'RB_ITC
        '
        Me.RB_ITC.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_ITC.Location = New System.Drawing.Point(2, 80)
        Me.RB_ITC.Name = "RB_ITC"
        Me.RB_ITC.Size = New System.Drawing.Size(96, 19)
        Me.RB_ITC.TabIndex = 1
        Me.RB_ITC.Text = "ITC"
        '
        'RB_rev
        '
        Me.RB_rev.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_rev.Location = New System.Drawing.Point(2, 99)
        Me.RB_rev.Name = "RB_rev"
        Me.RB_rev.Size = New System.Drawing.Size(132, 40)
        Me.RB_rev.TabIndex = 0
        Me.RB_rev.Text = "REVERSE CHARGE"
        '
        'opt_Singlesupplier
        '
        Me.opt_Singlesupplier.BackColor = System.Drawing.Color.Transparent
        Me.opt_Singlesupplier.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_Singlesupplier.Location = New System.Drawing.Point(11, 172)
        Me.opt_Singlesupplier.Name = "opt_Singlesupplier"
        Me.opt_Singlesupplier.Size = New System.Drawing.Size(144, 24)
        Me.opt_Singlesupplier.TabIndex = 500
        Me.opt_Singlesupplier.Text = "SINGLE SUPPLIER"
        Me.opt_Singlesupplier.UseVisualStyleBackColor = False
        Me.opt_Singlesupplier.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.Chk_pendingpo)
        Me.GroupBox5.Controls.Add(Me.OptAll)
        Me.GroupBox5.Controls.Add(Me.Opt_Return)
        Me.GroupBox5.Controls.Add(Me.Opt_purchase)
        Me.GroupBox5.Location = New System.Drawing.Point(5, 400)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(561, 48)
        Me.GroupBox5.TabIndex = 498
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Visible = False
        '
        'Chk_pendingpo
        '
        Me.Chk_pendingpo.BackColor = System.Drawing.Color.Transparent
        Me.Chk_pendingpo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_pendingpo.Location = New System.Drawing.Point(403, 18)
        Me.Chk_pendingpo.Name = "Chk_pendingpo"
        Me.Chk_pendingpo.Size = New System.Drawing.Size(132, 24)
        Me.Chk_pendingpo.TabIndex = 501
        Me.Chk_pendingpo.Text = "UNCLOSED  PO"
        Me.Chk_pendingpo.UseVisualStyleBackColor = False
        Me.Chk_pendingpo.Visible = False
        '
        'OptAll
        '
        Me.OptAll.Checked = True
        Me.OptAll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptAll.Location = New System.Drawing.Point(328, 16)
        Me.OptAll.Name = "OptAll"
        Me.OptAll.Size = New System.Drawing.Size(96, 24)
        Me.OptAll.TabIndex = 2
        Me.OptAll.TabStop = True
        Me.OptAll.Text = "All"
        '
        'Opt_Return
        '
        Me.Opt_Return.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Return.Location = New System.Drawing.Point(176, 16)
        Me.Opt_Return.Name = "Opt_Return"
        Me.Opt_Return.Size = New System.Drawing.Size(120, 24)
        Me.Opt_Return.TabIndex = 1
        Me.Opt_Return.Text = "NON GST"
        '
        'Opt_purchase
        '
        Me.Opt_purchase.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_purchase.Location = New System.Drawing.Point(16, 16)
        Me.Opt_purchase.Name = "Opt_purchase"
        Me.Opt_purchase.Size = New System.Drawing.Size(128, 24)
        Me.Opt_purchase.TabIndex = 0
        Me.Opt_purchase.Text = "GST"
        '
        'CBO_SELECTALL
        '
        Me.CBO_SELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CBO_SELECTALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBO_SELECTALL.Location = New System.Drawing.Point(232, 76)
        Me.CBO_SELECTALL.Name = "CBO_SELECTALL"
        Me.CBO_SELECTALL.Size = New System.Drawing.Size(128, 16)
        Me.CBO_SELECTALL.TabIndex = 499
        Me.CBO_SELECTALL.Text = "FOR SELECT ALL"
        Me.CBO_SELECTALL.UseVisualStyleBackColor = False
        Me.CBO_SELECTALL.Visible = False
        '
        'grp_orderby
        '
        Me.grp_orderby.BackColor = System.Drawing.Color.Transparent
        Me.grp_orderby.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_orderby.Location = New System.Drawing.Point(672, 656)
        Me.grp_orderby.Name = "grp_orderby"
        Me.grp_orderby.Size = New System.Drawing.Size(142, 74)
        Me.grp_orderby.TabIndex = 500
        Me.grp_orderby.TabStop = False
        '
        'lbl_Mainstore
        '
        Me.lbl_Mainstore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Mainstore.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Mainstore.Location = New System.Drawing.Point(4, 20)
        Me.lbl_Mainstore.Name = "lbl_Mainstore"
        Me.lbl_Mainstore.Size = New System.Drawing.Size(50, 16)
        Me.lbl_Mainstore.TabIndex = 482
        Me.lbl_Mainstore.Text = "STORE :"
        '
        'txt_Mainstorecode
        '
        Me.txt_Mainstorecode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Mainstorecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Mainstorecode.Location = New System.Drawing.Point(60, 16)
        Me.txt_Mainstorecode.Name = "txt_Mainstorecode"
        Me.txt_Mainstorecode.Size = New System.Drawing.Size(64, 21)
        Me.txt_Mainstorecode.TabIndex = 484
        '
        'cmd_storecode
        '
        Me.cmd_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_storecode.Location = New System.Drawing.Point(125, 13)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 485
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(150, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 24)
        Me.Label5.TabIndex = 486
        Me.Label5.Text = "F4"
        Me.Label5.Visible = False
        '
        'txt_Mainstore
        '
        Me.txt_Mainstore.BackColor = System.Drawing.Color.Wheat
        Me.txt_Mainstore.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Mainstore.Enabled = False
        Me.txt_Mainstore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Mainstore.Location = New System.Drawing.Point(185, 18)
        Me.txt_Mainstore.MaxLength = 15
        Me.txt_Mainstore.Name = "txt_Mainstore"
        Me.txt_Mainstore.ReadOnly = True
        Me.txt_Mainstore.Size = New System.Drawing.Size(148, 21)
        Me.txt_Mainstore.TabIndex = 483
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lbl_Mainstore)
        Me.GroupBox2.Controls.Add(Me.txt_Mainstorecode)
        Me.GroupBox2.Controls.Add(Me.cmd_storecode)
        Me.GroupBox2.Controls.Add(Me.txt_Mainstore)
        Me.GroupBox2.Controls.Add(Me.GroupBox7)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 582)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 53)
        Me.GroupBox2.TabIndex = 494
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.PictureBox6)
        Me.GroupBox7.Controls.Add(Me.PictureBox7)
        Me.GroupBox7.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox7.Controls.Add(Me.Label17)
        Me.GroupBox7.Location = New System.Drawing.Point(27, 26)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(642, 49)
        Me.GroupBox7.TabIndex = 425
        Me.GroupBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Location = New System.Drawing.Point(382, 11)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox6.TabIndex = 491
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Location = New System.Drawing.Point(142, 12)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox7.TabIndex = 490
        Me.PictureBox7.TabStop = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd-MM-yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(179, 16)
        Me.DateTimePicker1.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.DateTimePicker1.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(104, 21)
        Me.DateTimePicker1.TabIndex = 0
        Me.DateTimePicker1.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(317, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 15)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "TO DATE :"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd-MM-yyyy"
        Me.DateTimePicker2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(421, 17)
        Me.DateTimePicker2.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.DateTimePicker2.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(104, 21)
        Me.DateTimePicker2.TabIndex = 1
        Me.DateTimePicker2.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(56, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 15)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "FROM DATE :"
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.Cmd_Exit)
        Me.frmbut.Controls.Add(Me.Cmd_Clear)
        Me.frmbut.Controls.Add(Me.Cmd_View)
        Me.frmbut.Controls.Add(Me.chk_excel)
        Me.frmbut.Controls.Add(Me.Cmd_Print)
        Me.frmbut.Location = New System.Drawing.Point(810, 127)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(150, 232)
        Me.frmbut.TabIndex = 13
        Me.frmbut.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox6.Controls.Add(Me.CheckBox2)
        Me.GroupBox6.Controls.Add(Me.GroupBox5)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.CKB_venType)
        Me.GroupBox6.Controls.Add(Me.CheckBox1)
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.PictureBox4)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.PictureBox3)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.PictureBox1)
        Me.GroupBox6.Controls.Add(Me.Chk_SelectAllSupplier)
        Me.GroupBox6.Controls.Add(Me.chklst_Supplier)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.ChkLst_Group)
        Me.GroupBox6.Controls.Add(Me.Chk_AllGroup)
        Me.GroupBox6.Controls.Add(Me.ChkLst_Item)
        Me.GroupBox6.Controls.Add(Me.Chk_AllItem)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 116)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(782, 443)
        Me.GroupBox6.TabIndex = 502
        Me.GroupBox6.TabStop = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Maroon
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(282, 293)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 24)
        Me.Label14.TabIndex = 500
        Me.Label14.Text = "F3"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox1.Location = New System.Drawing.Point(97, 318)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(216, 84)
        Me.CheckedListBox1.TabIndex = 497
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(98, 270)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(136, 20)
        Me.CheckBox2.TabIndex = 498
        Me.CheckBox2.Text = "SELECT ALL "
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Maroon
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(98, 293)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(216, 24)
        Me.Label15.TabIndex = 499
        Me.Label15.Text = "ITEM TYPE :"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Maroon
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(282, 161)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 24)
        Me.Label12.TabIndex = 496
        Me.Label12.Text = "F3"
        '
        'CKB_venType
        '
        Me.CKB_venType.CheckOnClick = True
        Me.CKB_venType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CKB_venType.Location = New System.Drawing.Point(97, 186)
        Me.CKB_venType.Name = "CKB_venType"
        Me.CKB_venType.Size = New System.Drawing.Size(216, 84)
        Me.CKB_venType.TabIndex = 493
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(98, 138)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(136, 24)
        Me.CheckBox1.TabIndex = 494
        Me.CheckBox1.Text = "SELECT ALL "
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Maroon
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(98, 161)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(216, 24)
        Me.Label13.TabIndex = 495
        Me.Label13.Text = "VENDOR TYPE :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(289, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(142, 24)
        Me.Label18.TabIndex = 503
        Me.Label18.Text = "TAX REPORT"
        '
        'FrmTaxReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1014, 692)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.btn_validation)
        Me.Controls.Add(Me.CBO_SELECTALL)
        Me.Controls.Add(Me.grp_orderby)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbo_Storelocation)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.cmd_exprot)
        Me.Controls.Add(Me.GroupBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FrmTaxReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORT [ TAX DETAILS ]"
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.grp_SalebillChecklist.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmbut.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    Dim sqlstring As String

    Private Sub frmPurchaseregister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F9 And Cmd_View.Enabled = True Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F10 And Cmd_Print.Enabled = True Then
            Call Cmd_Print_Click(Cmd_Print, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
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
        ElseIf e.KeyCode = Keys.F4 Then
            Dim search As New frmListSearch
            search.listbox = chklst_Supplier
            search.Text = "Supplier Search"
            search.ShowDialog(Me)
        ElseIf e.KeyCode = Keys.F1 Then
            Dim search As New frmListSearch
            search.listbox = ChkLst_Item
            search.Text = "Items Search"
            search.ShowDialog(Me)
        ElseIf e.KeyCode = Keys.F2 Then
            Dim search As New frmListSearch
            search.listbox = ChkLst_Group
            search.Text = "Group Search"
            search.ShowDialog(Me)
        End If
    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        gPrint = False
        grp_SalebillChecklist.Top = 611
        grp_SalebillChecklist.Left = 194
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 10
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Checkdaterangevalidate(dtp_Fromdate.Value, dtp_Todate.Value)
        If chkdatevalidate = False Then Exit Sub
        gPrint = True
        grp_SalebillChecklist.Top = 611
        grp_SalebillChecklist.Left = 194
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 10
        Me.Timer1.Enabled = True
    End Sub
    Private Sub vIEWTAXSUMMARY_REV_ITC()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New TaxReporTRevChr

            Dim rViewer As New Viewer




            Me.Cursor = Cursors.WaitCursor
            If RB_rev.Checked = True Then

                sqlstring = " SELECT grndetails , Supplierdate AS UPDATETIME,REMARKS, grndate,pono ,Supplierinvno, suppliercode , suppliername , SUM( totalamount) AS totalamount ,SUM( vatamount) AS vatamount ,SUM( surchargeamt ) AS surchargeamt,  "
                sqlstring = sqlstring & "  SUM( billamount) AS billamount,SUM(OVERALLDISCOUNT) AS OVERALLDISCOUNT  ,SUM(AMOUNT) AS AMOUNT,SUM(IGSTAmt) AS IGSTAMT,SUM(SGSTAmt) AS SGSTAMT,SUM(CGSTAmt) AS CGSTAMT,SUM(CESSAmt) AS CESSAMT,SUM(SPLCESS) AS SPLCESS,SUM(VATAMOUNT1) AS VATAMOUNT1,SUM(taxamount) AS TAXAMOUNT,SUM(DISCOUNT+OVERALLDISCOUNT) AS DISCOUNT from VW_INV_GRNBILL_GST  "

                If chklst_Supplier.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                    For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If ChkLst_Group.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND STOREDESC IN ("
                    For i = 0 To ChkLst_Group.CheckedItems.Count - 1
                        sqlstring = sqlstring & " '" & Trim(ChkLst_Group.CheckedItems(i)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the STORE code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND taxtype IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        sqlstring = sqlstring & " '" & Trim(CheckedListBox1.CheckedItems(i)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ",'')"
                Else
                    MessageBox.Show("Select the item type", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " and VENDORTYPE='UNREGISTERED' and taxamount<>0  GROUP BY grndetails ,Supplierdate,REMARKS , grndate,pono ,Supplierinvno, suppliercode , suppliername   ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL_GST")
                If gdataset.Tables("VW_INV_GRNBILL_GST").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else

                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "VW_INV_GRNBILL_GST"

                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        'Dim textobj7 As TextObject
                        'textobj7 = r.ReportDefinition.ReportObjects("Text5")
                        'textobj7.Text = Address1


                        'Dim textobj8 As TextObject
                        'textobj8 = r.ReportDefinition.ReportObjects("Text16")
                        'textobj8.Text = Address2




                        'Dim textobj2 As TextObject
                        'textobj2 = r.ReportDefinition.ReportObjects("Text13")
                        'textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = r.ReportDefinition.ReportObjects("Text21")
                        textobj4.Text = gUsername

                        Dim textobj5 As TextObject
                        textobj5 = r.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(gCompanyAddress(0))

                        Dim textobj6 As TextObject
                        textobj6 = r.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gCompanyAddress(1)) & UCase("GSTIN NO :" & gGSTINNO)

                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                ' Else
                ' Me.Cursor = Cursors.WaitCursor
                ' Dim heading() As String = {"PURCHASE REGISTER "}
                ' Dim ObjStockPurchaseregistersummary As New rptPurchaseregistersummary
                ' ObjStockPurchaseregistersummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                '  Me.Cursor = Cursors.Default
                ' End If

            ElseIf RB_ITC.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                opt_Purchasedetails.Checked = True

                sqlstring = " SELECT grndetails , Supplierdate AS UPDATETIME,REMARKS, grndate,pono ,Supplierinvno, suppliercode , suppliername ,GSTINNO , SUM( totalamount) AS totalamount ,SUM( vatamount) AS vatamount ,SUM( surchargeamt ) AS surchargeamt,  "
                sqlstring = sqlstring & "  SUM( billamount) AS billamount,SUM(OVERALLDISCOUNT) AS OVERALLDISCOUNT  ,SUM(AMOUNT) AS AMOUNT,SUM(IGSTAmt) AS IGSTAMT,SUM(SGSTAmt) AS SGSTAMT,SUM(CGSTAmt) AS CGSTAMT,SUM(CESSAmt) AS CESSAMT,SUM(SPLCESS) AS SPLCESS,SUM(VATAMOUNT1) AS VATAMOUNT1,SUM(taxamount) AS TAXAMOUNT,SUM(DISCOUNT+OVERALLDISCOUNT) AS DISCOUNT from VW_INV_GRNBILL_GST  "

                If chklst_Supplier.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                    For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If ChkLst_Group.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND STOREDESC IN ("
                    For i = 0 To ChkLst_Group.CheckedItems.Count - 1
                        sqlstring = sqlstring & " '" & Trim(ChkLst_Group.CheckedItems(i)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the STORE code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If CheckedListBox1.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND taxtype IN ("
                    For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                        sqlstring = sqlstring & " '" & Trim(CheckedListBox1.CheckedItems(i)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ",'')"
                Else
                    MessageBox.Show("Select the item type", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " and itemcode in (select itemcode from Vw_Inv_TaxRebateItem) and  taxamount<>0 GROUP BY grndetails ,Supplierdate,REMARKS , grndate,pono ,Supplierinvno, suppliercode , suppliername,GSTINNO    ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "


                Dim s As New TaxReporTITC

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL_GST")

                If gdataset.Tables("VW_INV_GRNBILL_GST").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = s
                        rViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = s.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        'Dim textobj2 As TextObject
                        'textobj2 = s.ReportDefinition.ReportObjects("Text16")
                        'textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = s.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = s.ReportDefinition.ReportObjects("Text22")
                        textobj4.Text = gUsername

                        Dim textobj6 As TextObject
                        textobj6 = s.ReportDefinition.ReportObjects("Text15")
                        textobj6.Text = UCase(gCompanyAddress(0))

                        Dim textobj7 As TextObject
                        textobj7 = s.ReportDefinition.ReportObjects("Text16")
                        textobj7.Text = UCase(gCompanyAddress(1)) & UCase("GSTIN NO :" & gGSTINNO)

                        'Dim textobj8 As TextObject
                        'textobj8 = s.ReportDefinition.ReportObjects("Text29")
                        'textobj8.Text = TINNO

                        'Dim textobj9 As TextObject
                        'textobj9 = s.ReportDefinition.ReportObjects("Text30")
                        'textobj9.Text = SERVICETAX


                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If

            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub vIEWTAXSUMMARY()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New TaxReportsummary

            Dim rViewer As New Viewer




            Me.Cursor = Cursors.WaitCursor
            If opt_Purchasesummary.Checked = True Then

                sqlstring = " SELECT grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , SUM( totalamount) AS totalamount ,SUM( vatamount) AS vatamount ,SUM( surchargeamt ) AS surchargeamt,  "
                sqlstring = sqlstring & "  SUM( billamount) AS billamount,SUM(OVERALLDISCOUNT) AS OVERALLDISCOUNT  ,SUM(AMOUNT) AS AMOUNT,SUM(IGSTAmt) AS IGSTAMT,SUM(SGSTAmt) AS SGSTAMT,SUM(CGSTAmt) AS CGSTAMT,SUM(CESSAmt) AS CESSAMT,SUM(SPLCESS) AS SPLCESS,SUM(VATAMOUNT1) AS VATAMOUNT1,SUM(taxamount) AS TAXAMOUNT,SUM(DISCOUNT+OVERALLDISCOUNT) AS DISCOUNT from VW_INV_GRNBILL_GST  "

                If chklst_Supplier.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                    For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If ChkLst_Group.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND STOREDESC IN ("
                    For i = 0 To ChkLst_Group.CheckedItems.Count - 1
                        sqlstring = sqlstring & " '" & Trim(ChkLst_Group.CheckedItems(i)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the STORE code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If gShortname = "HG" Then
                Else
                    If CheckedListBox1.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND taxtype IN ("
                        For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                            sqlstring = sqlstring & " '" & Trim(CheckedListBox1.CheckedItems(i)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ",'')"
                    Else
                        MessageBox.Show("Select the item type", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If


                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & "  GROUP BY grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername   ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL_GST")
                If gdataset.Tables("VW_INV_GRNBILL_GST").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else

                        Dim sqlstring1 = "SELECT TAXPER, GSTPER , SUM(SGSTAMT) AS SGST,SUM(CGSTAMT) CGST,CESSPER,SUM(CESSAMT) AS CESSAMT,SUM(SPLCESS) AS SPLCESS, SUM(IGSTAMT) IGST,VATPER,SUM(VATAMOUNT1) VATAMT FROM VW_INV_GRNBILL_GST  "

                        If chklst_Supplier.CheckedItems.Count <> 0 Then
                            sqlstring1 = sqlstring1 & " WHERE SUPPLIERCODE IN ("
                            For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                                SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                                sqlstring1 = sqlstring1 & " '" & Trim(SUPPLIERNAME(0)) & "', "
                            Next
                            sqlstring1 = Mid(sqlstring1, 1, Len(sqlstring1) - 2)
                            sqlstring1 = sqlstring1 & ")"
                        Else
                            MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If

                        If ChkLst_Group.CheckedItems.Count <> 0 Then
                            sqlstring1 = sqlstring1 & " AND STOREDESC IN ("
                            For i = 0 To ChkLst_Group.CheckedItems.Count - 1
                                sqlstring1 = sqlstring1 & " '" & Trim(ChkLst_Group.CheckedItems(i)) & "', "
                            Next
                            sqlstring1 = Mid(sqlstring1, 1, Len(sqlstring1) - 2)
                            sqlstring1 = sqlstring1 & ")"
                        Else
                            MessageBox.Show("Select the STORE code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                        If gShortname = "HG" Then
                        Else
                            If CheckedListBox1.CheckedItems.Count <> 0 Then
                                sqlstring1 = sqlstring1 & " AND taxtype IN ("
                                For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                                    sqlstring1 = sqlstring1 & " '" & Trim(CheckedListBox1.CheckedItems(i)) & "', "
                                Next
                                sqlstring1 = Mid(sqlstring1, 1, Len(sqlstring1) - 2)
                                sqlstring1 = sqlstring1 & ",'')"
                            Else
                                MessageBox.Show("Select the item type", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        End If



                        sqlstring1 = sqlstring1 & " AND TAXPER<>0 AND GRNDATE BETWEEN"
                        sqlstring1 = sqlstring1 & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'  GROUP BY TAXPER,GSTPER,CESSPER,VATPER"

                        gconnection.getDataSet(sqlstring1, "vW_INV_GSTTAXDET")

                        Call rViewer.GetDetails1New(sqlstring1, "vW_INV_GSTTAXDET", r)


                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "VW_INV_GRNBILL_GST"

                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        'Dim textobj7 As TextObject
                        'textobj7 = r.ReportDefinition.ReportObjects("Text5")
                        'textobj7.Text = Address1


                        'Dim textobj8 As TextObject
                        'textobj8 = r.ReportDefinition.ReportObjects("Text16")
                        'textobj8.Text = Address2




                        'Dim textobj2 As TextObject
                        'textobj2 = r.ReportDefinition.ReportObjects("Text13")
                        'textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = r.ReportDefinition.ReportObjects("Text21")
                        textobj4.Text = gUsername

                        Dim textobj5 As TextObject
                        textobj5 = r.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(gCompanyAddress(0))

                        Dim textobj6 As TextObject
                        textobj6 = r.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gCompanyAddress(1)) & UCase("GSTIN NO :" & gGSTINNO)

                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                ' Else
                ' Me.Cursor = Cursors.WaitCursor
                ' Dim heading() As String = {"PURCHASE REGISTER "}
                ' Dim ObjStockPurchaseregistersummary As New rptPurchaseregistersummary
                ' ObjStockPurchaseregistersummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                '  Me.Cursor = Cursors.Default
                ' End If

            ElseIf opt_Purchasedetails.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                opt_Purchasedetails.Checked = True

                sqlstring = " SELECT * FROM VW_INV_GRNBILL_GST "
                If chklst_Supplier.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                    For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If ChkLst_Group.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " AND STOREDESC IN ("
                    For i = 0 To ChkLst_Group.CheckedItems.Count - 1
                        sqlstring = sqlstring & " '" & Trim(ChkLst_Group.CheckedItems(i)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the STORE code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If gShortname = "HG" Then
                Else
                    If CheckedListBox1.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND taxtype IN ("
                        For i = 0 To CheckedListBox1.CheckedItems.Count - 1
                            sqlstring = sqlstring & " '" & Trim(CheckedListBox1.CheckedItems(i)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ",'')"
                    Else
                        MessageBox.Show("Select the item type", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                If RB_rev.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMCODE  "
                ElseIf RB_ITC.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMNAME  "
                Else
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME   "
                End If

                Dim s As New TaxReportdetails

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "VW_INV_GRNBILL_GST")

                If gdataset.Tables("VW_INV_GRNBILL_GST").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = s
                        rViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = s.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        'Dim textobj2 As TextObject
                        'textobj2 = s.ReportDefinition.ReportObjects("Text16")
                        'textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = s.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = s.ReportDefinition.ReportObjects("Text22")
                        textobj4.Text = gUsername

                        Dim textobj6 As TextObject
                        textobj6 = s.ReportDefinition.ReportObjects("Text15")
                        textobj6.Text = UCase(gCompanyAddress(0))

                        Dim textobj7 As TextObject
                        textobj7 = s.ReportDefinition.ReportObjects("Text16")
                        textobj7.Text = UCase(gCompanyAddress(1)) & UCase("GSTIN NO :" & gGSTINNO)

                        'Dim textobj8 As TextObject
                        'textobj8 = s.ReportDefinition.ReportObjects("Text29")
                        'textobj8.Text = TINNO

                        'Dim textobj9 As TextObject
                        'textobj9 = s.ReportDefinition.ReportObjects("Text30")
                        'textobj9.Text = SERVICETAX


                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub Viewsuppliernamewise()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New Rpt_PurchaseRegister
            Dim r9 As New Rpt_PurchaseRegister_Supplier
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor
            If opt_Purchasesummary.Checked = True Then
                sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , totalamount , vatamount , surchargeamt , discountamount , billamount,OVERALLDISCOUNT  from viewpurchaseregistersummary "
                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where  ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else
                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Item code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        'Dim textobj7 As TextObject
                        'textobj7 = r.ReportDefinition.ReportObjects("Text5")
                        'textobj7.Text = Address1


                        'Dim textobj8 As TextObject
                        'textobj8 = r.ReportDefinition.ReportObjects("Text16")
                        'textobj8.Text = Address2


                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = r.ReportDefinition.ReportObjects("Text21")
                        textobj4.Text = gUsername

                        Dim textobj5 As TextObject
                        textobj5 = r.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(gCompanyAddress(0))

                        Dim textobj6 As TextObject
                        textobj6 = r.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gCompanyAddress(1))

                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                ' Else
                ' Me.Cursor = Cursors.WaitCursor
                ' Dim heading() As String = {"PURCHASE REGISTER "}
                ' Dim ObjStockPurchaseregistersummary As New rptPurchaseregistersummary
                ' ObjStockPurchaseregistersummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                '  Me.Cursor = Cursors.Default
                ' End If
            ElseIf opt_Singlesupplier.Checked = True Then
                sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , totalamount , vatamount , surchargeamt , discountamount , billamount,OVERALLDISCOUNT,GLACCOUNTCODE,GLACCOUNTNAME  from viewpurchaseregistersummary "
                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where  ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else
                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Item code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = r9
                        rViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = r9.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        Dim textobj2 As TextObject
                        textobj2 = r9.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r9.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = r9.ReportDefinition.ReportObjects("Text21")
                        textobj4.Text = gUsername

                        Dim textobj6 As TextObject
                        textobj6 = r9.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gCompanyAddress(0))

                        Dim textobj7 As TextObject
                        textobj7 = r9.ReportDefinition.ReportObjects("Text20")
                        textobj7.Text = UCase(gCompanyAddress(1))


                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If

            ElseIf opt_Purchasedetails.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                opt_Purchasedetails.Checked = True

                sqlstring = " SELECT * FROM VIEWPURCHASEREGISTERSUMMARY "

                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else
                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                If RB_rev.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMCODE  "
                ElseIf RB_ITC.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMNAME  "
                Else
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "
                End If

                Dim s As New Rpt_PurchaseRegister_Det

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")

                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = s
                        rViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = s.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        Dim textobj2 As TextObject
                        textobj2 = s.ReportDefinition.ReportObjects("Text16")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = s.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = s.ReportDefinition.ReportObjects("Text22")
                        textobj4.Text = gUsername

                        Dim textobj6 As TextObject
                        textobj6 = s.ReportDefinition.ReportObjects("Text13")
                        textobj6.Text = UCase(gCompanyAddress(0))

                        Dim textobj7 As TextObject
                        textobj7 = s.ReportDefinition.ReportObjects("Text24")
                        textobj7.Text = UCase(gCompanyAddress(1))

                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                'Else
                '  Me.Cursor = Cursors.WaitCursor
                '  Dim heading() As String = {"PURCHASE REGISTER "}
                '  Dim ObjStockPurchaseregisterReport As New rptStockPurchaseregister
                ' ObjStockPurchaseregisterReport.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                '  Me.Cursor = Cursors.Default
                ' End If
            End If

            If CHK_ITEM.Checked = True Then

                Dim v As New Rpt_PurRegister_Item
                Dim vViewer As New Viewer
                sqlstring = " SELECT ITEMCODE,ITEMNAME,SUM(qty) AS QTY,(SUM(AMOUNT)/SUM(qty)) AS RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT, "
                sqlstring = sqlstring & " SUM(DISCOUNT) AS DISCOUNT , SUM(OTHCHARGE) AS OTHCHARGE FROM VIEWPURCHASEREGISTERSUMMARY "


                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else

                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Items Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " GROUP BY ITEMCODE,ITEMNAME  "
                If RB_rev.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY ITEMCODE, ITEMNAME "
                ElseIf RB_ITC.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY ITEMNAME, ITEMCODE "
                Else
                    sqlstring = sqlstring & " ORDER BY ITEMCODE, ITEMNAME "
                End If

                Me.Cursor = Cursors.Default
                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        vViewer.ssql = sqlstring
                        vViewer.Report = v
                        vViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = v.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        Dim textobj2 As TextObject
                        textobj2 = v.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = v.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = v.ReportDefinition.ReportObjects("Text14")
                        textobj4.Text = gUsername



                        Dim textobj6 As TextObject
                        textobj6 = v.ReportDefinition.ReportObjects("Text19")
                        ' textobj6.Text = UCase(gCompanyAddress(0))
                        textobj6.Text = Address1

                        Dim textobj8 As TextObject
                        textobj8 = v.ReportDefinition.ReportObjects("Text22")
                        'textobj8.Text = UCase(gCompanyAddress(1))
                        textobj8.Text = Address2

                        'Dim textobj7 As TextObject
                        ' textobj7 = r.ReportDefinition.ReportObjects("Text16")
                        ' textobj7.Text = UCase(gCompanyAddress(1))

                        vViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                'End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub ViewReturnRegister()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New Rpt_PurchaseRegister
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor
            If opt_Purchasesummary.Checked = True Then
                sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , totalamount , vatamount , surchargeamt , discountamount , billamount,OVERALLDISCOUNT  from viewpurchaseregistersummary "
                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where  ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else
                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Item code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' AND ISNULL(GRNTYPE,'') = 'PRN' "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim textobj5 As TextObject
                        textobj5 = r.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(gCompanyAddress(0))

                        Dim textobj6 As TextObject
                        textobj6 = r.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gCompanyAddress(1))

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = r.ReportDefinition.ReportObjects("Text21")
                        textobj4.Text = gUsername

                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                'Else
                ' Me.Cursor = Cursors.WaitCursor
                ' Dim heading() As String = {"PURCHASE REGISTER "}
                ' Dim ObjStockPurchaseregistersummary As New rptPurchaseregistersummary
                ' ObjStockPurchaseregistersummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                ' Me.Cursor = Cursors.Default
                ' End If

            ElseIf opt_Purchasedetails.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                opt_Purchasedetails.Checked = True

                sqlstring = " SELECT * FROM VIEWPURCHASEREGISTERSUMMARY "

                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else
                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' AND ISNULL(GRNTYPE,'') = 'PRN' "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMCODE  "
                Dim s As New Rpt_PurchaseRegister_Det

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")

                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = s
                        rViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = s.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        Dim textobj2 As TextObject
                        textobj2 = s.ReportDefinition.ReportObjects("Text16")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = s.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = s.ReportDefinition.ReportObjects("Text22")
                        textobj4.Text = gUsername

                        Dim textobj6 As TextObject
                        textobj6 = s.ReportDefinition.ReportObjects("Text13")
                        textobj6.Text = UCase(gCompanyAddress(0))

                        Dim textobj7 As TextObject
                        textobj7 = s.ReportDefinition.ReportObjects("Text24")
                        textobj7.Text = UCase(gCompanyAddress(1))



                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                ' Else
                '  Me.Cursor = Cursors.WaitCursor
                ' Dim heading() As String = {"PURCHASE REGISTER "}
                ' Dim ObjStockPurchaseregisterReport As New rptStockPurchaseregister
                ' ObjStockPurchaseregisterReport.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                '  Me.Cursor = Cursors.Default
                ' End If
            End If

            If CHK_ITEM.Checked = True Then

                Dim v As New Rpt_PurRegister_Item
                Dim vViewer As New Viewer
                sqlstring = " SELECT ITEMCODE,ITEMNAME,SUM(qty) AS QTY,(SUM(AMOUNT)/SUM(qty)) AS RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT, "
                sqlstring = sqlstring & " SUM(DISCOUNT) AS DISCOUNT , SUM(OTHCHARGE) AS OTHCHARGE FROM VIEWPURCHASEREGISTERSUMMARY "


                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else

                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Items Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' AND ISNULL(GRNTYPE,'') = 'PRN' "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " GROUP BY ITEMCODE,ITEMNAME  "
                sqlstring = sqlstring & " ORDER BY ITEMCODE, ITEMNAME "
                Me.Cursor = Cursors.Default
                ' If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        vViewer.ssql = sqlstring
                        vViewer.Report = v
                        vViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = v.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = v.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = r.ReportDefinition.ReportObjects("Text14")
                        textobj4.Text = gUsername

                        Dim textobj6 As TextObject
                        textobj6 = r.ReportDefinition.ReportObjects("Text15")
                        textobj6.Text = UCase(gCompanyAddress(0))

                        Dim textobj7 As TextObject
                        textobj7 = r.ReportDefinition.ReportObjects("Text16")
                        textobj7.Text = UCase(gCompanyAddress(1))


                        vViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                'End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub ViewPurchaseRegister()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New Rpt_PurchaseRegister
            Dim r9 As New Rpt_PurchaseRegister_Supplier
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor
            If opt_Purchasesummary.Checked = True Then
                sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , totalamount , vatamount , surchargeamt , discountamount , billamount,OVERALLDISCOUNT  from viewpurchaseregistersummary "
                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where  ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else
                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                If RB_rev.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "
                ElseIf RB_ITC.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "
                Else
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "
                End If
                ' If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = r
                        rViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = r.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        Dim textobj5 As TextObject
                        textobj5 = r.ReportDefinition.ReportObjects("Text15")
                        textobj5.Text = UCase(gCompanyAddress(0))
                        Dim textobj6 As TextObject
                        textobj6 = r.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gCompanyAddress(1))
                        'Dim textobj7 As TextObject
                        'textobj7 = r.ReportDefinition.ReportObjects("Text17")
                        'textobj7.Text = UCase(gCompanyAddress(2))



                        Dim textobj2 As TextObject
                        textobj2 = r.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = r.ReportDefinition.ReportObjects("Text21")
                        textobj4.Text = gUsername

                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                ' Else
                '    Me.Cursor = Cursors.WaitCursor
                '    Dim heading() As String = {"PURCHASE REGISTER "}
                '    Dim ObjStockPurchaseregistersummary As New rptPurchaseregistersummary
                '    ObjStockPurchaseregistersummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                '    Me.Cursor = Cursors.Default
                ' End If

            ElseIf opt_Singlesupplier.Checked = True Then
                sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , totalamount , vatamount , surchargeamt , discountamount , billamount,OVERALLDISCOUNT,GLACCOUNTCODE,GLACCOUNTNAME  from viewpurchaseregistersummary "
                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where  ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else
                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Item code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "'  AND ISNULL(GRNTYPE,'') = 'GRN'  "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = r9
                        rViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = r9.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        Dim textobj6 As TextObject
                        textobj6 = r9.ReportDefinition.ReportObjects("Text16")
                        textobj6.Text = UCase(gCompanyAddress(0))

                        Dim textobj7 As TextObject
                        textobj7 = r9.ReportDefinition.ReportObjects("Text20")
                        textobj7.Text = UCase(gCompanyAddress(1))

                        Dim textobj2 As TextObject
                        textobj2 = r9.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = r9.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = r9.ReportDefinition.ReportObjects("Text21")
                        textobj4.Text = gUsername

                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default

                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If

            ElseIf opt_Purchasedetails.Checked = True Then
                Me.Cursor = Cursors.WaitCursor
                opt_Purchasedetails.Checked = True

                sqlstring = " SELECT * FROM VIEWPURCHASEREGISTERSUMMARY "

                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else
                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN'  "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"

                If RB_rev.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMCODE  "
                ElseIf RB_ITC.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMNAME  "
                Else
                    sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMCODE  "
                End If
                Dim s As New Rpt_PurchaseRegister_Det

                'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")

                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        rViewer.ssql = sqlstring
                        rViewer.Report = s
                        rViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = s.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        Dim textobj2 As TextObject
                        textobj2 = s.ReportDefinition.ReportObjects("Text16")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = s.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = s.ReportDefinition.ReportObjects("Text22")
                        textobj4.Text = gUsername

                        Dim textobj6 As TextObject
                        textobj6 = s.ReportDefinition.ReportObjects("Text13")
                        textobj6.Text = UCase(gCompanyAddress(0))

                        Dim textobj7 As TextObject
                        textobj7 = s.ReportDefinition.ReportObjects("Text24")
                        textobj7.Text = UCase(gCompanyAddress(1))
                        'raju

                        'raju

                        rViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                'Else
                'Me.Cursor = Cursors.WaitCursor
                ' Dim heading() As String = {"PURCHASE REGISTER "}
                ' Dim ObjStockPurchaseregisterReport As New rptStockPurchaseregister
                ' ObjStockPurchaseregisterReport.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                ' Me.Cursor = Cursors.Default
                'End If
            End If

            If CHK_ITEM.Checked = True Then

                Dim v As New Rpt_PurRegister_Item
                Dim vViewer As New Viewer
                sqlstring = " SELECT ITEMCODE,ITEMNAME,SUM(qty) AS QTY,(SUM(AMOUNT)/SUM(qty)) AS RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT, "
                sqlstring = sqlstring & " SUM(DISCOUNT) AS DISCOUNT , SUM(OTHCHARGE) AS OTHCHARGE FROM VIEWPURCHASEREGISTERSUMMARY "


                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    sqlstring = sqlstring & " where ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else

                    If chklst_Supplier.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " WHERE SUPPLIERCODE IN ("
                        For i = 0 To chklst_Supplier.CheckedItems.Count - 1
                            SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If ChkLst_Item.CheckedItems.Count <> 0 Then
                        sqlstring = sqlstring & " AND ITEMCODE IN ("
                        For i = 0 To ChkLst_Item.CheckedItems.Count - 1
                            ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
                            sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
                        Next
                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                        sqlstring = sqlstring & ")"
                    Else
                        MessageBox.Show("Select the Items Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " GROUP BY ITEMCODE,ITEMNAME  "
                If RB_rev.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY ITEMCODE, ITEMNAME "
                ElseIf RB_ITC.Checked = True Then
                    sqlstring = sqlstring & " ORDER BY ITEMNAME, ITEMCODE "
                Else
                    sqlstring = sqlstring & " ORDER BY ITEMCODE, ITEMNAME "
                End If
                Me.Cursor = Cursors.Default
                ' If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
                    If chk_excel.Checked = True Then
                        Dim exp As New exportexcel
                        exp.Show()
                        Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
                    Else
                        vViewer.ssql = sqlstring
                        vViewer.Report = v
                        vViewer.TableName = "PURCHASEREGISTER"

                        Dim textobj1 As TextObject
                        textobj1 = v.ReportDefinition.ReportObjects("Text3")
                        textobj1.Text = MyCompanyName

                        Dim textobj2 As TextObject
                        textobj2 = v.ReportDefinition.ReportObjects("Text13")
                        textobj2.Text = Trim(txt_Mainstore.Text)

                        Dim TXTOBJ3 As TextObject
                        TXTOBJ3 = v.ReportDefinition.ReportObjects("Text17")
                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                        Dim textobj4 As TextObject
                        textobj4 = v.ReportDefinition.ReportObjects("Text14")
                        textobj4.Text = gUsername

                        Dim textobj6 As TextObject
                        textobj6 = v.ReportDefinition.ReportObjects("Text19")
                        textobj6.Text = Address1

                        Dim textobj7 As TextObject
                        textobj7 = v.ReportDefinition.ReportObjects("Text22")
                        textobj7.Text = Address2






                        vViewer.Show()
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
                End If
                'End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
            Me.ProgressBar1.Value += 1
            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar1.Value = 0
            Me.grp_SalebillChecklist.Top = 1000
            If Opt_purchase.Checked = True Then
                Call ViewPurchaseRegister()
            ElseIf Opt_Return.Checked = True Then
                Call ViewReturnRegister()
            ElseIf OptAll.Checked = True Then
                If RB_rev.Checked = True Or RB_ITC.Checked = True Then
                    Call vIEWTAXSUMMARY_REV_ITC()
                Else
                    Call vIEWTAXSUMMARY()
                End If

            ElseIf Chk_pendingpo.Checked = True Then
                Call pendingpo()
            Else
                Call Viewsuppliernamewise()
            End If


        End If
    End Sub

    Private Sub dtp_Fromdate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_Fromdate.KeyDown, DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtp_Todate.Focus()
        End If
    End Sub

    Private Sub dtp_Todate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_Todate.KeyDown, DateTimePicker2.KeyDown
        If e.KeyCode = Keys.Enter Then

            If Format(dtp_Todate.Value, "dd/MM/yyyy") > Format((CDate("31-MAR-" & gFinancialyearEnd)), "dd/MM/yyyy") Then
                MessageBox.Show("Date should be within the Financial year", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
            Cmd_View.Focus()
        End If
    End Sub

    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 732
        K = 1016
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
                        If Controls(i_i).Name = "frmbut" Or Controls(i_i).Name = "grp_orderby" Or Controls(i_i).Name = "GroupBox4" Then
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
    Private Sub frmPurchaseregister_Recon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Show()
        ' Resize_Form()
        'Call Fillsuppliername()
        Call FillsupplierTYpe()
        Call FillItemTYpe()
        dtp_Fromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
        dtp_Todate.Value = Format(Now, "dd/MM/yyyy")
        grp_SalebillChecklist.Top = 1000
        Call FillGroupdetails()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Lbl_SubledgerCode.Visible = True
        Label8.Visible = True
        TXT_FROM.Visible = True
        txt_itemto.Visible = True
        Cmd_ITEMFROM.Visible = True
        cmd_itemto.Visible = True
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

    Private Sub FillsupplierTYpe()
        Dim i As Integer
        CKB_venType.Items.Clear()
        sqlstring = " SELECT DISTINCT VENDORTYPE FROM ACCOUNTSSUBLEDGERMASTER WHERE ISNULL(VENDORTYPE,'')<>''"
        gconnection.getDataSet(sqlstring, "SUBLEDGERMASTER")
        If gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1
                With gdataset.Tables("SUBLEDGERMASTER").Rows(i)
                    CKB_venType.Items.Add(Trim(.Item("VENDORTYPE")))
                End With
            Next i
        End If
    End Sub

    Private Sub FillItemTYpe()
        Dim i As Integer
        CheckedListBox1.Items.Clear()
        sqlstring = " SELECT DISTINCT TAXTYPE FROM INV_InventoryItemMaster WHERE ISNULL(TAXTYPE,'')<>''"
        gconnection.getDataSet(sqlstring, "INV_InventoryItemMaster")
        If gdataset.Tables("INV_InventoryItemMaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INV_InventoryItemMaster").Rows.Count - 1
                With gdataset.Tables("INV_InventoryItemMaster").Rows(i)
                    CheckedListBox1.Items.Add(Trim(.Item("TAXTYPE")))
                End With
            Next i
        End If
    End Sub

    Private Sub Fillsuppliername()
        Dim i As Integer
        chklst_Supplier.Items.Clear()
        If gCATHOLIC = "Y" Then
            sqlstring = "SELECT DISTINCT ISNULL(SLCODE,'') AS SLCODE,ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER WHERE ISNULL(ACCODE,'')='" & Trim(gCreditors) & "'  AND ISNULL(FREeZEFLAG,'') <> 'Y' AND SLCODE IN(select distinct suppliercode from grn_header where isnull(void,'')<>'Y') ORDER BY SLCODE"
        Else
            sqlstring = "SELECT DISTINCT ISNULL(SLCODE,'') AS SLCODE,ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE IN (SELECT ACCODE FROM ACCOUNTSGLACCOUNTMASTER WHERE ISNULL(ACCODE,'')='" & Trim(gCreditors) & "')  AND ISNULL(FREeZEFLAG,'') <> 'Y' AND SLCODE IN(select distinct suppliercode from grn_header where isnull(void,'')<>'Y') ORDER BY SLCODE"
        End If
        gconnection.getDataSet(sqlstring, "SUBLEDGERMASTER")
        If gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1
                With gdataset.Tables("SUBLEDGERMASTER").Rows(i)
                    chklst_Supplier.Items.Add(Trim(.Item("SLCODE")) & "-->" & Trim(.Item("SLNAME")))
                End With
            Next i
        End If
    End Sub
    Private Sub FillItemdetails()
        Dim i As Integer
        Dim sqlstring As String
        ChkLst_Item.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER where isnull(freeze,'') <> 'Y' ORDER BY ITEMCODE "
        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                    ChkLst_Item.Items.Add(Trim(CStr(.Item("ITEMCODE"))) & "-->" & Trim(CStr(.Item("ITEMNAME"))))
                End With
            Next
        End If
    End Sub
    Private Sub FillGroupdetails()
        Dim i As Integer
        Dim sqlstring As String
        ChkLst_Group.Items.Clear()
        sqlstring = "SELECT ISNULL(Storecode,'') AS Storecode,ISNULL(Storedesc,'') AS Storedesc FROM StoreMaster  where Storecode in (select storecode from GRN_HEADER) ORDER BY Storecode "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    ChkLst_Group.Items.Add(Trim(CStr(.Item("Storedesc"))))
                End With
            Next
        End If
    End Sub
    Private Sub opt_Purchasedetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles opt_Purchasedetails.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmd_View.Focus()
        End If
    End Sub

    Private Sub opt_Purchasesummary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles opt_Purchasesummary.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmd_View.Focus()
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        grp_SalebillChecklist.Top = 1000
        opt_Purchasesummary.Checked = True
        Chk_SelectAllSupplier.Checked = False
        dtp_Fromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")

        Chk_AllGroup.Checked = False

        Chk_AllItem.Checked = False
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CBO_SELECTALL.Checked = False
        CHK_ITEM.Checked = False
        txt_Mainstore.Text = ""
        txt_Mainstorecode.Text = ""
        TXT_FROM.Text = ""
        txt_itemto.Text = ""
        Lbl_SubledgerCode.Visible = True
        Label8.Visible = True
        TXT_FROM.Visible = True
        txt_itemto.Visible = True
        Cmd_ITEMFROM.Visible = True
        cmd_itemto.Visible = True
        Call FillsupplierTYpe()
        Call FillItemTYpe()
        chklst_Supplier.Items.Clear()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        dtp_Fromdate.Focus()
    End Sub

    Private Sub Chk_SelectAllSupplier_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllSupplier.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllSupplier.Checked = True Then
            For i = 0 To chklst_Supplier.Items.Count - 1
                chklst_Supplier.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklst_Supplier.Items.Count - 1
                chklst_Supplier.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub Chk_SelectAllSupplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk_SelectAllSupplier.KeyDown
        If e.KeyCode = Keys.Enter Then
            chklst_Supplier.Focus()
        End If
    End Sub

    Private Sub chklst_Supplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklst_Supplier.KeyDown
        If e.KeyCode = Keys.Enter Then
            opt_Purchasedetails.Focus()
        End If
    End Sub
    Private Sub ChkLst_Group_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLst_Group.DoubleClick
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' and I.GROUPNAME IN ("

        For J = 0 To ChkLst_Group.CheckedItems.Count - 1
            If J = ChkLst_Group.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & ChkLst_Group.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & ChkLst_Group.CheckedItems(J) & "', "
            End If
        Next
        If ChkLst_Group.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                ChkLst_Item.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        ChkLst_Item.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        End If
    End Sub
    Private Sub ChkLst_Group_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLst_Group.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql As String
        ssql = ""
        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
        sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' and I.GROUPNAME IN ("

        For J = 0 To ChkLst_Group.CheckedItems.Count - 1
            If J = ChkLst_Group.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & ChkLst_Group.CheckedItems(J) & "' "
            Else
                ssql = ssql & " '" & ChkLst_Group.CheckedItems(J) & "', "
            End If
        Next
        If ChkLst_Group.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
                ChkLst_Item.Items.Clear()
                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
                        ChkLst_Item.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                    End With
                Next i
            End If
        Else
            ChkLst_Item.Items.Clear()
        End If
    End Sub
    Private Sub Chk_SelectAllGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_AllGroup.CheckedChanged
        Dim i As Integer
        If Chk_AllGroup.Checked = True Then
            For i = 0 To ChkLst_Group.Items.Count - 1
                ChkLst_Group.SetItemChecked(i, True)
            Next
            Call ChkLst_Group_SelectedIndexChanged(sender, e)
        Else
            For i = 0 To ChkLst_Group.Items.Count - 1
                ChkLst_Group.SetItemChecked(i, False)
            Next
            ChkLst_Item.Items.Clear()
        End If
    End Sub
    Private Sub Chk_SelectAllItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_AllItem.CheckedChanged
        Dim i As Integer
        If Chk_AllItem.Checked = True Then
            For i = 0 To ChkLst_Item.Items.Count - 1
                ChkLst_Item.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To ChkLst_Item.Items.Count - 1
                ChkLst_Item.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub FillStore()
        Dim i As Integer
        sqlstring = "SELECT DISTINCT ISNULL(STOREDESC,'') AS STOREDESC FROM GRN_DETAILS ORDER BY STOREDESC ASC"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        cbo_Storelocation.Items.Clear()
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                cbo_Storelocation.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STOREDESC"))
            Next i
        End If
    End Sub
    Private Sub cbo_Storelocation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_Storelocation.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dtp_Fromdate.Focus()
        End If
    End Sub

    Private Sub CHK_ITEM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_ITEM.CheckedChanged
        If CHK_ITEM.Checked = True Then
            opt_Purchasedetails.Checked = False
            opt_Purchasesummary.Checked = False
            opt_Singlesupplier.Checked = False
        Else
            opt_Purchasesummary.Checked = True
        End If
    End Sub

    Private Sub Cmd_ITEMFROM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ITEMFROM.Click
        Try
            Dim vform As New ListOperattion1
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim I As Integer
            gSQLString = " SELECT  itemcode,itemname  FROM INVENTORYITEMMASTER "
            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'  "
            M_WhereCondition = M_WhereCondition & " AND storecode = '" & Trim(txt_Mainstorecode.Text) & "'"
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
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_Mainstorecode.Text) & "'"

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
            M_WhereCondition = M_WhereCondition & " AND storecode = '" & Trim(txt_Mainstorecode.Text) & "'"

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

    Private Sub txt_itemto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_itemto.Validated
        Try
            Dim sqlstring, itemcode() As String
            Dim i As Integer
            If Trim(txt_itemto.Text) <> "" Then
                sqlstring = "select ITEMCODE, ITEMNAME from inventoryitemmaster where ITEMCODE = '" & Trim(txt_itemto.Text) & "'"
                sqlstring = sqlstring & " AND storecode = '" & Trim(txt_Mainstorecode.Text) & "'"
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
            MessageBox.Show("Plz Check Error : txt_itemto_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_itemto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_itemto.KeyDown
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
            txt_Mainstorecode.Text = Trim(vform.keyfield & "")
            txt_Mainstore.Text = Trim(vform.keyfield1 & "")
            TXT_FROM.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_Mainstorecode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_Mainstorecode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_Mainstorecode.Text) = "" Then
                Call cmd_storecode_Click(cmd_storecode, e)
            Else
                Call txt_Mainstorecode_Validated(sender, e)
                dtp_Fromdate.Focus()
            End If
        End If
    End Sub

    Private Sub txt_Mainstorecode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Mainstorecode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_storecode_Click(cmd_storecode, e)
        End If
    End Sub

    Private Sub txt_Mainstorecode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Mainstorecode.Validated
        Try
            If Trim(txt_Mainstorecode.Text) <> "" Then
                sqlstring = "SELECT * FROM storemaster WHERE storecode='" & Trim(txt_Mainstorecode.Text) & "'"
                gconnection.getDataSet(sqlstring, "storemaster")
                If gdataset.Tables("storemaster").Rows.Count > 0 Then
                    txt_Mainstorecode.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storecode"))
                    txt_Mainstore.Text = Trim(gdataset.Tables("storemaster").Rows(0).Item("storedesc"))
                    TXT_FROM.Focus()
                End If
            End If
        Catch
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub CBO_SELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CBO_SELECTALL.Checked = True Then
            Lbl_SubledgerCode.Visible = True
            Label8.Visible = True
            TXT_FROM.Visible = True
            txt_itemto.Visible = True
            Cmd_ITEMFROM.Visible = True
            cmd_itemto.Visible = True
            '==== for all===='
            Chk_SelectAllSupplier.Visible = False
            Chk_AllGroup.Visible = False
            Chk_AllItem.Visible = False
            ChkLst_Group.Visible = False
            ChkLst_Item.Visible = False
            chklst_Supplier.Visible = False
            Label2.Visible = False
            Label4.Visible = False
            Label3.Visible = False
            Label9.Visible = False
            Label10.Visible = False
            Label11.Visible = False
            PictureBox1.Visible = False
            PictureBox3.Visible = False
            PictureBox4.Visible = False
            '=====end ========'
            TXT_FROM.Focus()
        Else
            Lbl_SubledgerCode.Visible = False
            Label8.Visible = False
            TXT_FROM.Visible = False
            txt_itemto.Visible = False
            Cmd_ITEMFROM.Visible = False
            cmd_itemto.Visible = False
            '==for alll
            Chk_SelectAllSupplier.Visible = True
            Chk_AllGroup.Visible = True
            Chk_AllItem.Visible = True
            ChkLst_Group.Visible = True
            ChkLst_Item.Visible = True
            chklst_Supplier.Visible = True
            Label2.Visible = True
            Label4.Visible = True
            Label3.Visible = True
            Label9.Visible = True
            Label10.Visible = True
            Label11.Visible = True
            PictureBox1.Visible = True
            PictureBox3.Visible = True
            PictureBox4.Visible = True
            'end
        End If
    End Sub

    Private Sub txt_Mainstorecode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Mainstorecode.GotFocus
        Label5.Visible = True
    End Sub

    Private Sub txt_Mainstorecode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_Mainstorecode.LostFocus
        Label5.Visible = False
    End Sub

    Private Sub Cmd_View_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_View.Enter

    End Sub

    Private Sub Cmd_View_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_View.TabIndexChanged

    End Sub

    Private Sub chklst_Supplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklst_Supplier.SelectedIndexChanged

    End Sub

    Private Sub CBO_SELECTALL_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBO_SELECTALL.CheckedChanged

    End Sub

    Private Sub cmd_exprot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_exprot.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "viewpurchaseregistersummary"
        sqlstring = "select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , totalamount , vatamount , surchargeamt , discountamount , billamount,OVERALLDISCOUNT  from viewpurchaseregistersummary "
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub opt_Purchasesummary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_Purchasesummary.CheckedChanged
        If opt_Purchasesummary.Checked = True Then
            CHK_ITEM.Checked = False
            opt_Purchasedetails.Checked = False
            'opt_Purchasesummary.Checked = False
            opt_Singlesupplier.Checked = False
            'Else
            '    opt_Purchasesummary.Checked = True
        End If
    End Sub

    Private Sub opt_Purchasedetails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_Purchasedetails.CheckedChanged
        If opt_Purchasedetails.Checked = True Then
            CHK_ITEM.Checked = False
            'opt_Purchasedetails.Checked = False
            opt_Purchasesummary.Checked = False
            opt_Singlesupplier.Checked = False
            'Else
            '    opt_Purchasesummary.Checked = True
        End If
    End Sub

    Private Sub opt_Singlesupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt_Singlesupplier.CheckedChanged
        If opt_Singlesupplier.Checked = True Then
            CHK_ITEM.Checked = False
            opt_Purchasedetails.Checked = False
            opt_Purchasesummary.Checked = False
            'opt_Singlesupplier.Checked = False
            'Else
            '    opt_Purchasesummary.Checked = True
        End If
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validation.Click
        System.Diagnostics.Process.Start(AppPath & "/STUDY/PURCHASERETURNREGISTER.XLS")
    End Sub
    Private Sub pendingpo()
        ' Try
        Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
        Dim i As Integer
        Dim r As New Rpt_PENDINGPO
        'Dim r9 As New Rpt_PurchaseRegister_Supplier
        Dim rViewer As New Viewer

        Me.Cursor = Cursors.WaitCursor

        sqlstring = " SELECT * FROM  view_Pending_PO "
        'If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
        '    sqlstring = sqlstring & " where  ITEMCODE BETWEEN '"
        '    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
        'Else
        'If chklst_Supplier.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " WHERE Suppliercode IN ("
        '    For i = 0 To chklst_Supplier.CheckedItems.Count - 1
        '        SUPPLIERNAME = Split(chklst_Supplier.CheckedItems(i), "-->")
        '        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'Else
        '    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If ChkLst_Item.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " AND ITEMCODE IN ("
        '    For i = 0 To ChkLst_Item.CheckedItems.Count - 1
        '        ITEMNAME = Split(ChkLst_Item.CheckedItems(i), "-->")
        '        sqlstring = sqlstring & " '" & Trim(ITEMNAME(0)) & "', "
        '    Next
        '    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '    sqlstring = sqlstring & ")"
        'Else
        '    MessageBox.Show("Select the Item code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'End If
        sqlstring = sqlstring & " WHERE podepartment = '" & Trim(txt_Mainstore.Text) & "' "
        sqlstring = sqlstring & " AND PODATE BETWEEN"
        sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
        sqlstring = sqlstring & " ORDER BY AUTOID,ITEMCODE "

        'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Purchase Register") = MsgBoxResult.Yes Then
        Me.Cursor = Cursors.WaitCursor
        gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
        If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
            If chk_excel.Checked = True Then
                Dim exp As New exportexcel
                exp.Show()
                Call exp.export(sqlstring, "PURCHASE REGISTER  " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
            Else
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "PURCHASEREGISTER"

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text3")
                textobj1.Text = MyCompanyName

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text13")
                textobj2.Text = Trim(txt_Mainstore.Text)

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""

                Dim textobj4 As TextObject
                textobj4 = r.ReportDefinition.ReportObjects("Text21")
                textobj4.Text = gUsername

                Dim textobj6 As TextObject
                textobj6 = r.ReportDefinition.ReportObjects("Text11")
                textobj6.Text = UCase(gCompanyAddress(0))

                Dim textobj7 As TextObject
                textobj7 = r.ReportDefinition.ReportObjects("Text15")
                textobj7.Text = UCase(gCompanyAddress(1))
                rViewer.Show()
            End If
            Me.Cursor = Cursors.Default
        Else
            MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim i As Integer
        If CheckBox1.Checked = True Then
            For i = 0 To CKB_venType.Items.Count - 1
                CKB_venType.SetItemChecked(i, True)
            Next
            Call CKB_venType_SelectedIndexChanged(sender, e)
        Else
            For i = 0 To CKB_venType.Items.Count - 1
                CKB_venType.SetItemChecked(i, False)
            Next
            chklst_Supplier.Items.Clear()
        End If
    End Sub

    Private Sub CKB_venType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CKB_venType.SelectedIndexChanged
        Dim i, J As Integer
        Dim sqlstring, ssql, GROUPCODE() As String


        sqlstring = "SELECT DISTINCT ISNULL(SLCODE,'') AS SLCODE,ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE IN (SELECT ACCODE FROM ACCOUNTSGLACCOUNTMASTER WHERE ISNULL(ACCODE,'')='" & Trim(gCreditors) & "')  AND ISNULL(FREeZEFLAG,'') <> 'Y' AND SLCODE IN(select distinct suppliercode from grn_header where isnull(void,'')<>'Y') "

        sqlstring = sqlstring & "  and VENDORTYPE IN ("

        For J = 0 To CKB_venType.CheckedItems.Count - 1
            If J = CKB_venType.CheckedItems.Count - 1 Then
                ssql = ssql & " '" & Trim(CKB_venType.CheckedItems(J)) & "' "
            Else
                ssql = ssql & " '" & Trim(CKB_venType.CheckedItems(J)) & "', "
            End If
        Next

        If CKB_venType.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & ssql & ") ORDER BY SLCODE "
            chklst_Supplier.Items.Clear()

            gconnection.getDataSet(sqlstring, "SUBLEDGERMASTER")
            If gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1 >= 0 Then


                For i = 0 To gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1
                    With gdataset.Tables("SUBLEDGERMASTER").Rows(i)
                        chklst_Supplier.Items.Add(Trim(.Item("SLCODE")) & "-->" & Trim(.Item("SLNAME")))
                    End With
                Next i
            End If
        Else
            chklst_Supplier.Items.Clear()
        End If



    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim i As Integer
        If CheckBox2.Checked = True Then
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, True)
            Next
            ' Call CKB_venType_SelectedIndexChanged(sender, e)
        Else
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, False)
            Next
            ' chklst_Supplier.Items.Clear()
        End If
    End Sub


End Class
