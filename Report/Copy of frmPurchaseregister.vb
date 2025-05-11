Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmPurchaseregister
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Storelocation As System.Windows.Forms.Label
    Friend WithEvents cbo_Storelocation As System.Windows.Forms.ComboBox
    Friend WithEvents CHK_ITEM As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_itemto As System.Windows.Forms.Button
    Friend WithEvents txt_itemto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXT_FROM As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_ITEMFROM As System.Windows.Forms.Button
    Friend WithEvents Lbl_SubledgerCode As System.Windows.Forms.Label
    Friend WithEvents txt_Mainstorecode As System.Windows.Forms.TextBox
    Friend WithEvents txt_Mainstore As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Mainstore As System.Windows.Forms.Label
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPurchaseregister))
        Me.lbl_Heading = New System.Windows.Forms.Label
        Me.Cmd_Print = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.frmbut = New System.Windows.Forms.GroupBox
        Me.opt_Purchasedetails = New System.Windows.Forms.RadioButton
        Me.opt_Purchasesummary = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Chk_SelectAllSupplier = New System.Windows.Forms.CheckBox
        Me.chklst_Supplier = New System.Windows.Forms.CheckedListBox
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox
        Me.lbl_Wait = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtp_Fromdate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtp_Todate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Chk_AllGroup = New System.Windows.Forms.CheckBox
        Me.ChkLst_Group = New System.Windows.Forms.CheckedListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Chk_AllItem = New System.Windows.Forms.CheckBox
        Me.ChkLst_Item = New System.Windows.Forms.CheckedListBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_Storelocation = New System.Windows.Forms.Label
        Me.cbo_Storelocation = New System.Windows.Forms.ComboBox
        Me.CHK_ITEM = New System.Windows.Forms.CheckBox
        Me.cmd_itemto = New System.Windows.Forms.Button
        Me.txt_itemto = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXT_FROM = New System.Windows.Forms.TextBox
        Me.Cmd_ITEMFROM = New System.Windows.Forms.Button
        Me.Lbl_SubledgerCode = New System.Windows.Forms.Label
        Me.txt_Mainstorecode = New System.Windows.Forms.TextBox
        Me.txt_Mainstore = New System.Windows.Forms.TextBox
        Me.lbl_Mainstore = New System.Windows.Forms.Label
        Me.cmd_storecode = New System.Windows.Forms.Button
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(376, 8)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(278, 31)
        Me.lbl_Heading.TabIndex = 8
        Me.lbl_Heading.Text = "PURCHASE REGISTER"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.White
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.Location = New System.Drawing.Point(516, 600)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Print.TabIndex = 6
        Me.Cmd_Print.Text = " Print [F10]"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(370, 600)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 5
        Me.Cmd_View.Text = " View[F9]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(662, 600)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 7
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.Location = New System.Drawing.Point(224, 600)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 4
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Location = New System.Drawing.Point(152, 584)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(712, 56)
        Me.frmbut.TabIndex = 13
        Me.frmbut.TabStop = False
        '
        'opt_Purchasedetails
        '
        Me.opt_Purchasedetails.BackColor = System.Drawing.Color.Transparent
        Me.opt_Purchasedetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.opt_Purchasedetails.Location = New System.Drawing.Point(880, 552)
        Me.opt_Purchasedetails.Name = "opt_Purchasedetails"
        Me.opt_Purchasedetails.Size = New System.Drawing.Size(96, 16)
        Me.opt_Purchasedetails.TabIndex = 2
        Me.opt_Purchasedetails.Text = "DETAILS"
        '
        'opt_Purchasesummary
        '
        Me.opt_Purchasesummary.BackColor = System.Drawing.Color.Transparent
        Me.opt_Purchasesummary.Checked = True
        Me.opt_Purchasesummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.opt_Purchasesummary.Location = New System.Drawing.Point(880, 520)
        Me.opt_Purchasesummary.Name = "opt_Purchasesummary"
        Me.opt_Purchasesummary.Size = New System.Drawing.Size(104, 16)
        Me.opt_Purchasesummary.TabIndex = 3
        Me.opt_Purchasesummary.TabStop = True
        Me.opt_Purchasesummary.Text = "SUMMARY"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Maroon
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(288, 24)
        Me.Label4.TabIndex = 423
        Me.Label4.Text = "SUPPLIER SELECTION :"
        '
        'Chk_SelectAllSupplier
        '
        Me.Chk_SelectAllSupplier.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Chk_SelectAllSupplier.Location = New System.Drawing.Point(8, 64)
        Me.Chk_SelectAllSupplier.Name = "Chk_SelectAllSupplier"
        Me.Chk_SelectAllSupplier.Size = New System.Drawing.Size(136, 24)
        Me.Chk_SelectAllSupplier.TabIndex = 422
        Me.Chk_SelectAllSupplier.Text = "SELECT ALL "
        '
        'chklst_Supplier
        '
        Me.chklst_Supplier.CheckOnClick = True
        Me.chklst_Supplier.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklst_Supplier.Location = New System.Drawing.Point(8, 112)
        Me.chklst_Supplier.Name = "chklst_Supplier"
        Me.chklst_Supplier.Size = New System.Drawing.Size(288, 361)
        Me.chklst_Supplier.TabIndex = 421
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.BackColor = System.Drawing.Color.Transparent
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(152, 512)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(712, 64)
        Me.grp_SalebillChecklist.TabIndex = 424
        Me.grp_SalebillChecklist.TabStop = False
        '
        'lbl_Wait
        '
        Me.lbl_Wait.AutoSize = True
        Me.lbl_Wait.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Wait.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Wait.Location = New System.Drawing.Point(360, 24)
        Me.lbl_Wait.Name = "lbl_Wait"
        Me.lbl_Wait.Size = New System.Drawing.Size(0, 18)
        Me.lbl_Wait.TabIndex = 387
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(288, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 18)
        Me.Label1.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 16)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(696, 32)
        Me.ProgressBar1.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_Fromdate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.dtp_Todate)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(152, 512)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(712, 64)
        Me.GroupBox3.TabIndex = 425
        Me.GroupBox3.TabStop = False
        '
        'dtp_Fromdate
        '
        Me.dtp_Fromdate.CustomFormat = "dd-MM-yyyy"
        Me.dtp_Fromdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Fromdate.Location = New System.Drawing.Point(184, 24)
        Me.dtp_Fromdate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.dtp_Fromdate.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
        Me.dtp_Fromdate.Name = "dtp_Fromdate"
        Me.dtp_Fromdate.Size = New System.Drawing.Size(144, 26)
        Me.dtp_Fromdate.TabIndex = 0
        Me.dtp_Fromdate.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(400, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 18)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TO DATE :"
        '
        'dtp_Todate
        '
        Me.dtp_Todate.CustomFormat = "dd-MM-yyyy"
        Me.dtp_Todate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Todate.Location = New System.Drawing.Point(504, 24)
        Me.dtp_Todate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.dtp_Todate.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
        Me.dtp_Todate.Name = "dtp_Todate"
        Me.dtp_Todate.Size = New System.Drawing.Size(144, 26)
        Me.dtp_Todate.TabIndex = 1
        Me.dtp_Todate.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(56, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 18)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
        '
        'Timer1
        '
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(304, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(288, 24)
        Me.Label2.TabIndex = 429
        Me.Label2.Text = "GROUP SELECTION :"
        '
        'Chk_AllGroup
        '
        Me.Chk_AllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_AllGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Chk_AllGroup.Location = New System.Drawing.Point(304, 64)
        Me.Chk_AllGroup.Name = "Chk_AllGroup"
        Me.Chk_AllGroup.Size = New System.Drawing.Size(136, 24)
        Me.Chk_AllGroup.TabIndex = 428
        Me.Chk_AllGroup.Text = "SELECT ALL "
        '
        'ChkLst_Group
        '
        Me.ChkLst_Group.CheckOnClick = True
        Me.ChkLst_Group.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ChkLst_Group.Location = New System.Drawing.Point(304, 112)
        Me.ChkLst_Group.Name = "ChkLst_Group"
        Me.ChkLst_Group.Size = New System.Drawing.Size(288, 361)
        Me.ChkLst_Group.TabIndex = 427
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Maroon
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(600, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(384, 24)
        Me.Label3.TabIndex = 432
        Me.Label3.Text = "ITEM SELECTION :"
        '
        'Chk_AllItem
        '
        Me.Chk_AllItem.BackColor = System.Drawing.Color.Transparent
        Me.Chk_AllItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Chk_AllItem.Location = New System.Drawing.Point(600, 64)
        Me.Chk_AllItem.Name = "Chk_AllItem"
        Me.Chk_AllItem.Size = New System.Drawing.Size(136, 24)
        Me.Chk_AllItem.TabIndex = 431
        Me.Chk_AllItem.Text = "SELECT ALL "
        '
        'ChkLst_Item
        '
        Me.ChkLst_Item.CheckOnClick = True
        Me.ChkLst_Item.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ChkLst_Item.Location = New System.Drawing.Point(600, 112)
        Me.ChkLst_Item.Name = "ChkLst_Item"
        Me.ChkLst_Item.Size = New System.Drawing.Size(384, 361)
        Me.ChkLst_Item.TabIndex = 430
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(192, 648)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(654, 21)
        Me.Label5.TabIndex = 433
        Me.Label5.Text = "Press F1 for Advanced Search / F2 for Supplier Search / F3 for Item Search / F4 f" & _
        "or Group Search"
        '
        'lbl_Storelocation
        '
        Me.lbl_Storelocation.AutoSize = True
        Me.lbl_Storelocation.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Storelocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lbl_Storelocation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Storelocation.Location = New System.Drawing.Point(544, 672)
        Me.lbl_Storelocation.Name = "lbl_Storelocation"
        Me.lbl_Storelocation.Size = New System.Drawing.Size(92, 18)
        Me.lbl_Storelocation.TabIndex = 442
        Me.lbl_Storelocation.Text = "STORE LOC :"
        Me.lbl_Storelocation.Visible = False
        '
        'cbo_Storelocation
        '
        Me.cbo_Storelocation.BackColor = System.Drawing.Color.Wheat
        Me.cbo_Storelocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Storelocation.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbo_Storelocation.ItemHeight = 19
        Me.cbo_Storelocation.Location = New System.Drawing.Point(648, 672)
        Me.cbo_Storelocation.Name = "cbo_Storelocation"
        Me.cbo_Storelocation.Size = New System.Drawing.Size(158, 27)
        Me.cbo_Storelocation.TabIndex = 441
        Me.cbo_Storelocation.Visible = False
        '
        'CHK_ITEM
        '
        Me.CHK_ITEM.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ITEM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_ITEM.Location = New System.Drawing.Point(880, 584)
        Me.CHK_ITEM.Name = "CHK_ITEM"
        Me.CHK_ITEM.TabIndex = 443
        Me.CHK_ITEM.Text = "ITEM WISE"
        '
        'cmd_itemto
        '
        Me.cmd_itemto.Image = CType(resources.GetObject("cmd_itemto.Image"), System.Drawing.Image)
        Me.cmd_itemto.Location = New System.Drawing.Point(400, 480)
        Me.cmd_itemto.Name = "cmd_itemto"
        Me.cmd_itemto.Size = New System.Drawing.Size(23, 26)
        Me.cmd_itemto.TabIndex = 481
        '
        'txt_itemto
        '
        Me.txt_itemto.BackColor = System.Drawing.Color.Wheat
        Me.txt_itemto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_itemto.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_itemto.Location = New System.Drawing.Point(304, 480)
        Me.txt_itemto.MaxLength = 20
        Me.txt_itemto.Name = "txt_itemto"
        Me.txt_itemto.Size = New System.Drawing.Size(96, 26)
        Me.txt_itemto.TabIndex = 480
        Me.txt_itemto.Text = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(264, 488)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 18)
        Me.Label8.TabIndex = 479
        Me.Label8.Text = "TO:"
        '
        'TXT_FROM
        '
        Me.TXT_FROM.BackColor = System.Drawing.Color.Wheat
        Me.TXT_FROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_FROM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_FROM.Location = New System.Drawing.Point(128, 480)
        Me.TXT_FROM.MaxLength = 20
        Me.TXT_FROM.Name = "TXT_FROM"
        Me.TXT_FROM.Size = New System.Drawing.Size(96, 26)
        Me.TXT_FROM.TabIndex = 477
        Me.TXT_FROM.Text = ""
        '
        'Cmd_ITEMFROM
        '
        Me.Cmd_ITEMFROM.Image = CType(resources.GetObject("Cmd_ITEMFROM.Image"), System.Drawing.Image)
        Me.Cmd_ITEMFROM.Location = New System.Drawing.Point(224, 480)
        Me.Cmd_ITEMFROM.Name = "Cmd_ITEMFROM"
        Me.Cmd_ITEMFROM.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_ITEMFROM.TabIndex = 478
        '
        'Lbl_SubledgerCode
        '
        Me.Lbl_SubledgerCode.AutoSize = True
        Me.Lbl_SubledgerCode.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubledgerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubledgerCode.Location = New System.Drawing.Point(24, 488)
        Me.Lbl_SubledgerCode.Name = "Lbl_SubledgerCode"
        Me.Lbl_SubledgerCode.Size = New System.Drawing.Size(90, 18)
        Me.Lbl_SubledgerCode.TabIndex = 476
        Me.Lbl_SubledgerCode.Text = "ITEM  FROM:"
        '
        'txt_Mainstorecode
        '
        Me.txt_Mainstorecode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Mainstorecode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Mainstorecode.Location = New System.Drawing.Point(648, 480)
        Me.txt_Mainstorecode.Name = "txt_Mainstorecode"
        Me.txt_Mainstorecode.Size = New System.Drawing.Size(64, 26)
        Me.txt_Mainstorecode.TabIndex = 484
        Me.txt_Mainstorecode.Text = ""
        '
        'txt_Mainstore
        '
        Me.txt_Mainstore.BackColor = System.Drawing.Color.Wheat
        Me.txt_Mainstore.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Mainstore.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Mainstore.Location = New System.Drawing.Point(736, 480)
        Me.txt_Mainstore.MaxLength = 15
        Me.txt_Mainstore.Name = "txt_Mainstore"
        Me.txt_Mainstore.ReadOnly = True
        Me.txt_Mainstore.Size = New System.Drawing.Size(168, 26)
        Me.txt_Mainstore.TabIndex = 483
        Me.txt_Mainstore.Text = ""
        '
        'lbl_Mainstore
        '
        Me.lbl_Mainstore.AutoSize = True
        Me.lbl_Mainstore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Mainstore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Mainstore.Location = New System.Drawing.Point(536, 488)
        Me.lbl_Mainstore.Name = "lbl_Mainstore"
        Me.lbl_Mainstore.Size = New System.Drawing.Size(104, 18)
        Me.lbl_Mainstore.TabIndex = 482
        Me.lbl_Mainstore.Text = "FROM STORE :"
        '
        'cmd_storecode
        '
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(712, 480)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 485
        '
        'frmPurchaseregister
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(992, 708)
        Me.Controls.Add(Me.txt_Mainstorecode)
        Me.Controls.Add(Me.txt_Mainstore)
        Me.Controls.Add(Me.lbl_Mainstore)
        Me.Controls.Add(Me.cmd_storecode)
        Me.Controls.Add(Me.cmd_itemto)
        Me.Controls.Add(Me.txt_itemto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXT_FROM)
        Me.Controls.Add(Me.Cmd_ITEMFROM)
        Me.Controls.Add(Me.Lbl_SubledgerCode)
        Me.Controls.Add(Me.CHK_ITEM)
        Me.Controls.Add(Me.lbl_Storelocation)
        Me.Controls.Add(Me.cbo_Storelocation)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Chk_AllItem)
        Me.Controls.Add(Me.ChkLst_Item)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Chk_AllGroup)
        Me.Controls.Add(Me.ChkLst_Group)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Chk_SelectAllSupplier)
        Me.Controls.Add(Me.chklst_Supplier)
        Me.Controls.Add(Me.opt_Purchasesummary)
        Me.Controls.Add(Me.opt_Purchasedetails)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.frmbut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "frmPurchaseregister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORT [ PURCHASE REGISTER ]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    Dim sqlstring As String

    Private Sub frmPurchaseregister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
        ElseIf e.KeyCode = Keys.F1 Then
            Dim Asearch As New frmSearch_Advanced
            Asearch.chklistbox = ChkLst_Item
            Asearch.ShowDialog(Me)
        ElseIf e.KeyCode = Keys.F2 Then
            Dim search As New frmListSearch
            search.listbox = chklst_Supplier
            search.Text = "Supplier Search"
            search.ShowDialog(Me)
        ElseIf e.KeyCode = Keys.F3 Then
            Dim search As New frmListSearch
            search.listbox = ChkLst_Item
            search.Text = "Items Search"
            search.ShowDialog(Me)
        ElseIf e.KeyCode = Keys.F4 Then
            Dim search As New frmListSearch
            search.listbox = ChkLst_Group
            search.Text = "Group Search"
            search.ShowDialog(Me)
        End If
    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        If chklst_Supplier.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        gPrint = False
        grp_SalebillChecklist.Top = 512
        grp_SalebillChecklist.Left = 152
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 10
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        If chklst_Supplier.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Checkdaterangevalidate(dtp_Fromdate.Value, dtp_Todate.Value)
        If chkdatevalidate = False Then Exit Sub
        gPrint = True
        grp_SalebillChecklist.Top = 512
        grp_SalebillChecklist.Left = 152
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 10
        Me.Timer1.Enabled = True
    End Sub
    Private Sub Viewsuppliernamewise()
        Try
            Dim sqlstring, SUPPLIERNAME(), ITEMNAME() As String
            Dim i As Integer
            Dim r As New Rpt_PurchaseRegister
            Dim rViewer As New Viewer

            Me.Cursor = Cursors.WaitCursor
            If opt_Purchasesummary.Checked = True Then
                '-' sqlstring = " SELECT * FROM VIEWPURCHASEREGISTERSUMMARY "
                'added pono field-26122009-
                sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , totalamount , vatamount , surchargeamt , discountamount , billamount,OVERALLDISCOUNT  from viewpurchaseregistersummary "
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

                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' "

                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    ' sqlstring = sqlstring & " WHERE I.ITEMCODE=s.ITEMCODE "
                    sqlstring = sqlstring & " AND ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else

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
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "
                Me.Cursor = Cursors.Default


                If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Issue Summary") = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor

                    gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                    If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
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

                        rViewer.Show()
                        Me.Cursor = Cursors.Default

                    Else
                        MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OKOnly)
                    End If
                Else
                    Me.Cursor = Cursors.WaitCursor
                    Dim heading() As String = {"PURCHASE REGISTER "}
                    Dim ObjStockPurchaseregistersummary As New rptPurchaseregistersummary
                    ObjStockPurchaseregistersummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                    Me.Cursor = Cursors.Default
                End If

            ElseIf opt_Purchasedetails.Checked = True Then
                    Me.Cursor = Cursors.WaitCursor
                    opt_Purchasedetails.Checked = True
                    sqlstring = " SELECT * FROM VIEWPURCHASEREGISTERSUMMARY "

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
                    sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' "

                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    ' sqlstring = sqlstring & " WHERE I.ITEMCODE=s.ITEMCODE "
                    sqlstring = sqlstring & " AND ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else

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
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMCODE  "
                Dim s As New Rpt_PurchaseRegister_Det

                'ADDED by ON 28122009
                If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Issue Summary") = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                    If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
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
                        rViewer.Show()
                        Me.Cursor = Cursors.Default
                    Else
                        MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OKOnly)
                    End If

                Else
                    Me.Cursor = Cursors.WaitCursor
                    Dim heading() As String = {"PURCHASE REGISTER "}
                    Dim ObjStockPurchaseregisterReport As New rptStockPurchaseregister
                    ObjStockPurchaseregisterReport.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                    Me.Cursor = Cursors.Default
                End If

                'ADDED by ON 28122009
                End If

                If CHK_ITEM.Checked = True Then
                    Dim v As New Rpt_PurRegister_Item
                    Dim vViewer As New Viewer

                    '-' sqlstring = " SELECT * FROM VIEWPURCHASEREGISTERSUMMARY "
                    'added BILLNO field-26122009-
                    sqlstring = " SELECT ITEMCODE,ITEMNAME,SUM(qty) AS QTY,(SUM(AMOUNT)/SUM(qty)) AS RATE,SUM(AMOUNT) AS AMOUNT,SUM(TAXAMOUNT) AS TAXAMOUNT, "
                sqlstring = sqlstring & " SUM(DISCOUNT) AS DISCOUNT , SUM(OTHCHARGE) AS OTHCHARGE FROM VIEWPURCHASEREGISTERSUMMARY "
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

                sqlstring = sqlstring & " AND STOREDESC = '" & Trim(txt_Mainstore.Text) & "' "

                If ChkLst_Item.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                    ' sqlstring = sqlstring & " WHERE I.ITEMCODE=s.ITEMCODE "
                    sqlstring = sqlstring & " AND ITEMCODE BETWEEN '"
                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
                Else

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

                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " GROUP BY ITEMCODE,ITEMNAME  "
                sqlstring = sqlstring & " ORDER BY ITEMCODE, ITEMNAME "
                Me.Cursor = Cursors.Default

                If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Issue Summary") = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor

                    gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
                    If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then
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
                        vViewer.Show()
                        Me.Cursor = Cursors.Default
                    Else
                        MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OKOnly)
                    End If
                End If
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
            Call Viewsuppliernamewise()
        End If
    End Sub

    Private Sub dtp_Fromdate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_Fromdate.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtp_Todate.Focus()
        End If
    End Sub

    Private Sub dtp_Todate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_Todate.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmd_View.Focus()
        End If
    End Sub

    Private Sub frmPurchaseregister_Recon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Fillsuppliername()
        ' Call FillStore()
        dtp_Fromdate.Value = Format(Now, "dd/MM/yyyy")
        dtp_Todate.Value = Format(Now, "dd/MM/yyyy")
        grp_SalebillChecklist.Top = 1000
        Call FillGroupdetails()
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
    Private Sub Fillsuppliername()
        Dim i As Integer
        chklst_Supplier.Items.Clear()
        sqlstring = "SELECT DISTINCT ISNULL(SLCODE,'') AS SLCODE,ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE IN (SELECT ACCODE FROM ACCOUNTSGLACCOUNTMASTER WHERE ISNULL(ACCODE,'')='" & Trim(gCreditors) & "')  AND ISNULL(FREeZEFLAG,'') <> 'Y' ORDER BY SLCODE"
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
        sqlstring = "SELECT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPDESC,'') AS GROUPDESC FROM INVENTORYGROUPMASTER where isnull(freeze,'') <> 'y' ORDER BY GROUPCODE  "
        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                    ChkLst_Group.Items.Add(Trim(CStr(.Item("GROUPDESC"))))
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
        opt_Purchasedetails.Checked = True
        Chk_SelectAllSupplier.Checked = False
        Chk_AllGroup.Checked = False
        Chk_AllGroup.Checked = False
        Chk_AllItem.Checked = False
        CHK_ITEM.Checked = False
        txt_Mainstore.Text = ""
        txt_Mainstorecode.Text = ""
        TXT_FROM.Text = ""
        txt_itemto.Text = ""
        Call Fillsuppliername()
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
        Else
            opt_Purchasesummary.Checked = True
        End If
    End Sub

    Private Sub Cmd_ITEMFROM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ITEMFROM.Click
        Try
            Dim vform As New List_Operation
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim I As Integer
            gSQLString = " SELECT  itemcode,itemname  FROM INVENTORYITEMMASTER "
            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'  "
            M_WhereCondition = M_WhereCondition & " AND storecode = '" & Trim(txt_Mainstorecode.Text) & "'"
            'select ITEMCODE, ITEMNAME from inventoryitemmaster AS INV ,STOREMASTER AS STO  where  INV.STORECODE= STO.STORECODE 
            '  AND STO.storeDESC = 'GODOWN'
            vform.Field = "ITEMCODE,ITEMNAME"
            ' vform.vFormatstring = "  ITEMCODE                             |                          ITEMNAME                                "
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
                ' Call Cmd_ITEMFROM_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : TXT_FROM_Validated " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_itemto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_itemto.Click
        Try
            Dim vform As New List_Operation
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim I As Integer
            gSQLString = " SELECT  itemcode,itemname  FROM INVENTORYITEMMASTER "
            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'  "
            M_WhereCondition = M_WhereCondition & " AND storecode = '" & Trim(txt_Mainstorecode.Text) & "'"

            vform.Field = "ITEMCODE,ITEMNAME"
            ' vform.vFormatstring = "  ITEMCODE                             |                          ITEMNAME                                "
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
        Dim vform As New List_Operation
        vform.Field = "STOREDESC,STORECODE"
        ' vform.vFormatstring = "             STORE CODE                   |                   STORE DESCRIPTION                             "
        vform.vCaption = "INVENTORY STORE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_Mainstorecode.Text = Trim(vform.keyfield & "")
            txt_Mainstore.Text = Trim(vform.keyfield1 & "")
            'cbo_Tostore.Focus()
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
                'cbo_Tostore.Focus()
                TXT_FROM.Focus()
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
                    ' cbo_Tostore.Focus()
                    TXT_FROM.Focus()
                End If
            End If
        Catch
            MessageBox.Show("Check The Error", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

End Class
