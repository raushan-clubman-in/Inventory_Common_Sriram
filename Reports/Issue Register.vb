'Imports CrystalDecisions.CrystalReports.Engine
'Public Class Issue_Register
'    Inherits System.Windows.Forms.Form
'#Region " Windows Form Designer generated code "

'    Public Sub New()
'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()

'        'Add any initialization after the InitializeComponent() call

'    End Sub

'    'Form overrides dispose to clean up the component list.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Required by the Windows Form Designer
'    Private components As System.ComponentModel.IContainer

'    'NOTE: The following procedure is required by the Windows Form Designer
'    'It can be modified using the Windows Form Designer.  
'    'Do not modify it using the code editor.
'    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
'    Friend WithEvents Chkpcsmlwise As System.Windows.Forms.CheckBox
'    Friend WithEvents Label4 As System.Windows.Forms.Label
'    Friend WithEvents grp_SalebillChecklist As System.Windows.Forms.GroupBox
'    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
'    Friend WithEvents Label1 As System.Windows.Forms.Label
'    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
'    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
'    Friend WithEvents dtp_Fromdate As System.Windows.Forms.DateTimePicker
'    Friend WithEvents Label6 As System.Windows.Forms.Label
'    Friend WithEvents dtp_Todate As System.Windows.Forms.DateTimePicker
'    Friend WithEvents Label7 As System.Windows.Forms.Label
'    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
'    Friend WithEvents Chk_SelectAllStore As System.Windows.Forms.CheckBox
'    Friend WithEvents chklst_Store As System.Windows.Forms.CheckedListBox
'    Friend WithEvents Timer1 As System.Windows.Forms.Timer
'    Friend WithEvents lbl_Storelocation As System.Windows.Forms.Label
'    Friend WithEvents cbo_Storelocation As System.Windows.Forms.ComboBox
'    Friend WithEvents chklist_groupdesc As System.Windows.Forms.CheckedListBox
'    Friend WithEvents Label2 As System.Windows.Forms.Label
'    Friend WithEvents chk_SelectAllGroup As System.Windows.Forms.CheckBox
'    Friend WithEvents chklist_itemdetails As System.Windows.Forms.CheckedListBox
'    Friend WithEvents lbl_Itemlist As System.Windows.Forms.Label
'    Friend WithEvents Chk_SelectAllItem As System.Windows.Forms.CheckBox
'    Friend WithEvents cmd_itemto As System.Windows.Forms.Button
'    Friend WithEvents txt_itemto As System.Windows.Forms.TextBox
'    Friend WithEvents Label3 As System.Windows.Forms.Label
'    Friend WithEvents TXT_FROM As System.Windows.Forms.TextBox
'    Friend WithEvents Cmd_ITEMFROM As System.Windows.Forms.Button
'    Friend WithEvents Lbl_SubledgerCode As System.Windows.Forms.Label
'    Friend WithEvents CBO_SELECTALL As System.Windows.Forms.CheckBox
'    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
'    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
'    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
'    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
'    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
'    Friend WithEvents Label8 As System.Windows.Forms.Label
'    Friend WithEvents Label9 As System.Windows.Forms.Label
'    Friend WithEvents Label10 As System.Windows.Forms.Label
'    'Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
'    'Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
'    'Friend WithEvents Cmd_View As System.Windows.Forms.Button
'    'Friend WithEvents Cmd_Print As System.Windows.Forms.Button
'    'Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
'    'Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
'    'Friend WithEvents Cmd_Export As System.Windows.Forms.Button
'    'Friend WithEvents cmd_export1 As System.Windows.Forms.Button
'    'Friend WithEvents grp_orderby As System.Windows.Forms.GroupBox
'    'Friend WithEvents rdo_code As System.Windows.Forms.RadioButton
'    'Friend WithEvents rdo_name As System.Windows.Forms.RadioButton
'    'Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
'    'Friend WithEvents btn_validation As System.Windows.Forms.Button
'    '<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Me.components = New System.ComponentModel.Container
'    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Issue_Register))
'        Me.lbl_Heading = New System.Windows.Forms.Label
'        Me.Chkpcsmlwise = New System.Windows.Forms.CheckBox
'        Me.Label4 = New System.Windows.Forms.Label
'        Me.Chk_SelectAllStore = New System.Windows.Forms.CheckBox
'        Me.chklst_Store = New System.Windows.Forms.CheckedListBox
'        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox
'        Me.lbl_Wait = New System.Windows.Forms.Label
'        Me.Label1 = New System.Windows.Forms.Label
'        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
'        Me.GroupBox3 = New System.Windows.Forms.GroupBox
'        Me.PictureBox2 = New System.Windows.Forms.PictureBox
'        Me.PictureBox9 = New System.Windows.Forms.PictureBox
'        Me.dtp_Fromdate = New System.Windows.Forms.DateTimePicker
'        Me.Label6 = New System.Windows.Forms.Label
'        Me.dtp_Todate = New System.Windows.Forms.DateTimePicker
'        Me.Label7 = New System.Windows.Forms.Label
'        Me.frmbut = New System.Windows.Forms.GroupBox
'        Me.chk_excel = New System.Windows.Forms.CheckBox
'        Me.Cmd_Exit = New System.Windows.Forms.Button
'        Me.Cmd_Print = New System.Windows.Forms.Button
'        Me.Cmd_View = New System.Windows.Forms.Button
'        Me.Cmd_Clear = New System.Windows.Forms.Button
'        Me.cmd_export1 = New System.Windows.Forms.Button
'        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
'        Me.lbl_Storelocation = New System.Windows.Forms.Label
'        Me.cbo_Storelocation = New System.Windows.Forms.ComboBox
'        Me.chklist_groupdesc = New System.Windows.Forms.CheckedListBox
'        Me.Label2 = New System.Windows.Forms.Label
'        Me.chk_SelectAllGroup = New System.Windows.Forms.CheckBox
'        Me.chklist_itemdetails = New System.Windows.Forms.CheckedListBox
'        Me.lbl_Itemlist = New System.Windows.Forms.Label
'        Me.Chk_SelectAllItem = New System.Windows.Forms.CheckBox
'        Me.cmd_itemto = New System.Windows.Forms.Button
'        Me.txt_itemto = New System.Windows.Forms.TextBox
'        Me.Label3 = New System.Windows.Forms.Label
'        Me.TXT_FROM = New System.Windows.Forms.TextBox
'        Me.Cmd_ITEMFROM = New System.Windows.Forms.Button
'        Me.Lbl_SubledgerCode = New System.Windows.Forms.Label
'        Me.CBO_SELECTALL = New System.Windows.Forms.CheckBox
'        Me.GroupBox1 = New System.Windows.Forms.GroupBox
'        Me.GroupBox2 = New System.Windows.Forms.GroupBox
'        Me.GroupBox4 = New System.Windows.Forms.GroupBox
'        Me.PictureBox1 = New System.Windows.Forms.PictureBox
'        Me.PictureBox3 = New System.Windows.Forms.PictureBox
'        Me.PictureBox4 = New System.Windows.Forms.PictureBox
'        Me.Label8 = New System.Windows.Forms.Label
'        Me.Label9 = New System.Windows.Forms.Label
'        Me.Label10 = New System.Windows.Forms.Label
'        Me.Cmd_Export = New System.Windows.Forms.Button
'        Me.grp_orderby = New System.Windows.Forms.GroupBox
'        Me.rdo_name = New System.Windows.Forms.RadioButton
'        Me.rdo_code = New System.Windows.Forms.RadioButton
'        Me.btn_validation = New System.Windows.Forms.Button
'        Me.grp_SalebillChecklist.SuspendLayout()
'        Me.GroupBox3.SuspendLayout()
'        Me.frmbut.SuspendLayout()
'        Me.GroupBox1.SuspendLayout()
'        Me.GroupBox2.SuspendLayout()
'        Me.GroupBox4.SuspendLayout()
'        Me.grp_orderby.SuspendLayout()
'        Me.SuspendLayout()
'    '
'    'lbl_Heading
'    '
'        Me.lbl_Heading.AutoSize = True
'        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
'        Me.lbl_Heading.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
'        Me.lbl_Heading.Location = New System.Drawing.Point(360, 16)
'        Me.lbl_Heading.Name = "lbl_Heading"
'        me.lbl_Heading.Size = New System.Drawing.Size(308, 29)
'        Me.lbl_Heading.TabIndex = 9
'        Me.lbl_Heading.Text = " STOCK ISSUE REGISTER"
'        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'    '
'    'Chkpcsmlwise
'    '
'        Me.Chkpcsmlwise.BackColor = System.Drawing.Color.Transparent
'        Me.Chkpcsmlwise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
'        Me.Chkpcsmlwise.Location = New System.Drawing.Point(16, 56)
'        Me.Chkpcsmlwise.Name = "Chkpcsmlwise"
'        Me.Chkpcsmlwise.Size = New System.Drawing.Size(152, 40)
'        Me.Chkpcsmlwise.TabIndex = 4
'        Me.Chkpcsmlwise.Text = "PCS  / ML WISE"
'        Me.Chkpcsmlwise.Visible = False
'    '
'    'Label4
'    '
'        Me.Label4.BackColor = System.Drawing.Color.Maroon
'        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label4.ForeColor = System.Drawing.Color.White
'        Me.Label4.Location = New System.Drawing.Point(96, 80)
'        Me.Label4.Name = "Label4"
'        Me.Label4.Size = New System.Drawing.Size(288, 24)
'        Me.Label4.TabIndex = 426
'        Me.Label4.Text = "STORE SELECTION :"
'    '
'    'Chk_SelectAllStore
'    '
'        Me.Chk_SelectAllStore.BackColor = System.Drawing.Color.Transparent
'        Me.Chk_SelectAllStore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Chk_SelectAllStore.Location = New System.Drawing.Point(96, 56)
'        Me.Chk_SelectAllStore.Name = "Chk_SelectAllStore"
'        Me.Chk_SelectAllStore.Size = New System.Drawing.Size(136, 24)
'        Me.Chk_SelectAllStore.TabIndex = 425
'        Me.Chk_SelectAllStore.Text = "SELECT ALL "
'    '
'    'chklst_Store
'    '
'        Me.chklst_Store.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.chklst_Store.Location = New System.Drawing.Point(96, 104)
'        Me.chklst_Store.Name = "chklst_Store"
'        Me.chklst_Store.Size = New System.Drawing.Size(288, 361)
'        Me.chklst_Store.TabIndex = 424
'    '
'    'grp_SalebillChecklist
'    '
'        Me.grp_SalebillChecklist.BackColor = System.Drawing.Color.Transparent
'        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
'        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
'        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
'        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(128, 528)
'        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
'        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(704, 64)
'        Me.grp_SalebillChecklist.TabIndex = 432
'        Me.grp_SalebillChecklist.TabStop = False
'    '
'    'lbl_Wait
'    '
'        Me.lbl_Wait.AutoSize = True
'        Me.lbl_Wait.BackColor = System.Drawing.Color.Transparent
'        Me.lbl_Wait.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.lbl_Wait.Location = New System.Drawing.Point(360, 24)
'        Me.lbl_Wait.Name = "lbl_Wait"
'        Me.lbl_Wait.Size = New System.Drawing.Size(0, 18)
'        Me.lbl_Wait.TabIndex = 387
'    '
'    'Label1
'    '
'        Me.Label1.AutoSize = True
'        Me.Label1.BackColor = System.Drawing.Color.Transparent
'        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label1.Location = New System.Drawing.Point(288, 16)
'        Me.Label1.Name = "Label1"
'        Me.Label1.Size = New System.Drawing.Size(0, 18)
'        Me.Label1.TabIndex = 0
'    '
'    'ProgressBar1
'    '
'        Me.ProgressBar1.Location = New System.Drawing.Point(8, 16)
'        Me.ProgressBar1.Name = "ProgressBar1"
'        Me.ProgressBar1.Size = New System.Drawing.Size(688, 40)
'        Me.ProgressBar1.TabIndex = 0
'    '
'    'GroupBox3
'    '
'        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
'        Me.GroupBox3.Controls.Add(Me.PictureBox2)
'        Me.GroupBox3.Controls.Add(Me.PictureBox9)
'        Me.GroupBox3.Controls.Add(Me.dtp_Fromdate)
'        Me.GroupBox3.Controls.Add(Me.Label6)
'        Me.GroupBox3.Controls.Add(Me.dtp_Todate)
'        Me.GroupBox3.Controls.Add(Me.Label7)
'        Me.GroupBox3.Location = New System.Drawing.Point(128, 528)
'        Me.GroupBox3.Name = "GroupBox3"
'        Me.GroupBox3.Size = New System.Drawing.Size(704, 64)
'        Me.GroupBox3.TabIndex = 433
'        Me.GroupBox3.TabStop = False
'    '
'    'PictureBox2
'    '
'        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
'        Me.PictureBox2.Location = New System.Drawing.Point(176, 24)
'        Me.PictureBox2.Name = "PictureBox2"
'        Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
'        Me.PictureBox2.TabIndex = 491
'        Me.PictureBox2.TabStop = False
'    '
'    'PictureBox9
'    '
'        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
'        Me.PictureBox9.Location = New System.Drawing.Point(496, 24)
'        Me.PictureBox9.Name = "PictureBox9"
'        Me.PictureBox9.Size = New System.Drawing.Size(32, 32)
'        Me.PictureBox9.TabIndex = 490
'        Me.PictureBox9.TabStop = False
'    '
'    'dtp_Fromdate
'    '
'        Me.dtp_Fromdate.CustomFormat = "dd-MM-yyyy"
'        Me.dtp_Fromdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.dtp_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
'        Me.dtp_Fromdate.Location = New System.Drawing.Point(208, 24)
'        Me.dtp_Fromdate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
'        Me.dtp_Fromdate.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
'        Me.dtp_Fromdate.Name = "dtp_Fromdate"
'        Me.dtp_Fromdate.Size = New System.Drawing.Size(104, 26)
'        Me.dtp_Fromdate.TabIndex = 0
'        Me.dtp_Fromdate.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
'    '
'    'Label6
'    '
'        Me.Label6.AutoSize = True
'        Me.Label6.BackColor = System.Drawing.Color.Transparent
'        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
'        Me.Label6.Location = New System.Drawing.Point(424, 32)
'        Me.Label6.Name = "Label6"
'        Me.Label6.Size = New System.Drawing.Size(72, 18)
'        Me.Label6.TabIndex = 3
'        Me.Label6.Text = "TO DATE :"
'    '
'    'dtp_Todate
'    '
'        Me.dtp_Todate.CustomFormat = "dd-MM-yyyy"
'        Me.dtp_Todate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.dtp_Todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
'        Me.dtp_Todate.Location = New System.Drawing.Point(528, 24)
'        Me.dtp_Todate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
'        Me.dtp_Todate.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
'        Me.dtp_Todate.Name = "dtp_Todate"
'        Me.dtp_Todate.Size = New System.Drawing.Size(104, 26)
'        Me.dtp_Todate.TabIndex = 1
'        Me.dtp_Todate.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
'    '
'    'Label7
'    '
'        Me.Label7.AutoSize = True
'        Me.Label7.BackColor = System.Drawing.Color.Transparent
'        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
'        Me.Label7.Location = New System.Drawing.Point(80, 32)
'        Me.Label7.Name = "Label7"
'        Me.Label7.Size = New System.Drawing.Size(94, 18)
'        Me.Label7.TabIndex = 2
'        Me.Label7.Text = "FROM DATE :"
'    '
'    'frmbut
'    '
'        Me.frmbut.BackColor = System.Drawing.Color.Transparent
'        Me.frmbut.Controls.Add(Me.btn_validation)
'        Me.frmbut.Controls.Add(Me.chk_excel)
'        Me.frmbut.Controls.Add(Me.Cmd_Exit)
'        Me.frmbut.Controls.Add(Me.Cmd_Print)
'        Me.frmbut.Controls.Add(Me.Cmd_View)
'        Me.frmbut.Controls.Add(Me.Cmd_Clear)
'        Me.frmbut.Location = New System.Drawing.Point(128, 592)
'        Me.frmbut.Name = "frmbut"
'        Me.frmbut.Size = New System.Drawing.Size(704, 56)
'        Me.frmbut.TabIndex = 431
'        Me.frmbut.TabStop = False
'    '
'    'chk_excel
'    '
'        Me.chk_excel.BackColor = System.Drawing.Color.Transparent
'        Me.chk_excel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.chk_excel.Location = New System.Drawing.Point(256, 16)
'        Me.chk_excel.Name = "chk_excel"
'        Me.chk_excel.TabIndex = 464
'        Me.chk_excel.Text = "EXCEL"
'    '
'    'Cmd_Exit
'    '
'        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
'        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
'        Me.Cmd_Exit.Location = New System.Drawing.Point(584, 16)
'        Me.Cmd_Exit.Name = "Cmd_Exit"
'        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
'        Me.Cmd_Exit.TabIndex = 445
'        Me.Cmd_Exit.Text = "Exit[F11]"
'    '
'    'Cmd_Print
'    '
'        Me.Cmd_Print.BackColor = System.Drawing.Color.Transparent
'        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Cmd_Print.ForeColor = System.Drawing.Color.Black
'        Me.Cmd_Print.Location = New System.Drawing.Point(344, 16)
'        Me.Cmd_Print.Name = "Cmd_Print"
'        Me.Cmd_Print.Size = New System.Drawing.Size(104, 32)
'        Me.Cmd_Print.TabIndex = 444
'        Me.Cmd_Print.Text = " Print [F10]"
'    '
'    'Cmd_View
'    '
'        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
'        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
'        Me.Cmd_View.Location = New System.Drawing.Point(136, 16)
'        Me.Cmd_View.Name = "Cmd_View"
'        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
'        Me.Cmd_View.TabIndex = 443
'        Me.Cmd_View.Text = " View[F9]"
'    '
'    'Cmd_Clear
'    '
'        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
'        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
'        Me.Cmd_Clear.Location = New System.Drawing.Point(16, 16)
'        Me.Cmd_Clear.Name = "Cmd_Clear"
'        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
'        Me.Cmd_Clear.TabIndex = 436
'        Me.Cmd_Clear.Text = "Clear[F6]"
'    '
'    'cmd_export1
'    '
'        Me.cmd_export1.BackColor = System.Drawing.Color.Transparent
'        Me.cmd_export1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.cmd_export1.ForeColor = System.Drawing.Color.Black
'        Me.cmd_export1.Location = New System.Drawing.Point(424, 664)
'        Me.cmd_export1.Name = "cmd_export1"
'        Me.cmd_export1.Size = New System.Drawing.Size(104, 32)
'        Me.cmd_export1.TabIndex = 446
'        Me.cmd_export1.Text = "Export"
'        Me.cmd_export1.Visible = False
'    '
'    'Timer1
'    '
'    '
'    'lbl_Storelocation
'    '
'        Me.lbl_Storelocation.AutoSize = True
'        Me.lbl_Storelocation.BackColor = System.Drawing.Color.Transparent
'        Me.lbl_Storelocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.lbl_Storelocation.ImeMode = System.Windows.Forms.ImeMode.NoControl
'        Me.lbl_Storelocation.Location = New System.Drawing.Point(8, 24)
'        Me.lbl_Storelocation.Name = "lbl_Storelocation"
'        Me.lbl_Storelocation.Size = New System.Drawing.Size(130, 18)
'        Me.lbl_Storelocation.TabIndex = 442
'        Me.lbl_Storelocation.Text = "STORE LOCATION :"
'    '
'    'cbo_Storelocation
'    '
'        Me.cbo_Storelocation.BackColor = System.Drawing.Color.Wheat
'        Me.cbo_Storelocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
'        Me.cbo_Storelocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.cbo_Storelocation.ItemHeight = 16
'        Me.cbo_Storelocation.Location = New System.Drawing.Point(152, 16)
'        Me.cbo_Storelocation.Name = "cbo_Storelocation"
'        Me.cbo_Storelocation.Size = New System.Drawing.Size(158, 24)
'        Me.cbo_Storelocation.TabIndex = 441
'    '
'    'chklist_groupdesc
'    '
'        Me.chklist_groupdesc.CheckOnClick = True
'        Me.chklist_groupdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.chklist_groupdesc.Location = New System.Drawing.Point(416, 104)
'        Me.chklist_groupdesc.Name = "chklist_groupdesc"
'        Me.chklist_groupdesc.Size = New System.Drawing.Size(272, 361)
'        Me.chklist_groupdesc.TabIndex = 444
'    '
'    'Label2
'    '
'        Me.Label2.BackColor = System.Drawing.Color.Maroon
'        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label2.ForeColor = System.Drawing.Color.White
'        Me.Label2.Location = New System.Drawing.Point(416, 80)
'        Me.Label2.Name = "Label2"
'        Me.Label2.Size = New System.Drawing.Size(272, 24)
'        Me.Label2.TabIndex = 453
'        Me.Label2.Text = "SELECT GROUP CODE :"
'    '
'    'chk_SelectAllGroup
'    '
'        Me.chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
'        Me.chk_SelectAllGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.chk_SelectAllGroup.Location = New System.Drawing.Point(416, 64)
'        Me.chk_SelectAllGroup.Name = "chk_SelectAllGroup"
'        Me.chk_SelectAllGroup.Size = New System.Drawing.Size(128, 16)
'        Me.chk_SelectAllGroup.TabIndex = 455
'        Me.chk_SelectAllGroup.Text = "SELECT ALL"
'    '
'    'chklist_itemdetails
'    '
'        Me.chklist_itemdetails.CheckOnClick = True
'        Me.chklist_itemdetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.chklist_itemdetails.Location = New System.Drawing.Point(720, 104)
'        Me.chklist_itemdetails.Name = "chklist_itemdetails"
'        Me.chklist_itemdetails.Size = New System.Drawing.Size(256, 361)
'        Me.chklist_itemdetails.TabIndex = 456
'    '
'    'lbl_Itemlist
'    '
'        Me.lbl_Itemlist.BackColor = System.Drawing.Color.Maroon
'        Me.lbl_Itemlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.lbl_Itemlist.ForeColor = System.Drawing.Color.White
'        Me.lbl_Itemlist.Location = New System.Drawing.Point(720, 80)
'        Me.lbl_Itemlist.Name = "lbl_Itemlist"
'        Me.lbl_Itemlist.Size = New System.Drawing.Size(256, 24)
'        Me.lbl_Itemlist.TabIndex = 457
'        Me.lbl_Itemlist.Text = "SELECT  ITEMCODE :"
'    '
'    'Chk_SelectAllItem
'    '
'        Me.Chk_SelectAllItem.BackColor = System.Drawing.Color.Transparent
'        Me.Chk_SelectAllItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Chk_SelectAllItem.Location = New System.Drawing.Point(720, 64)
'        Me.Chk_SelectAllItem.Name = "Chk_SelectAllItem"
'        Me.Chk_SelectAllItem.Size = New System.Drawing.Size(128, 16)
'        Me.Chk_SelectAllItem.TabIndex = 458
'        Me.Chk_SelectAllItem.Text = "SELECT ALL"
'    '
'    'cmd_itemto
'    '
'        Me.cmd_itemto.Image = CType(resources.GetObject("cmd_itemto.Image"), System.Drawing.Image)
'        Me.cmd_itemto.Location = New System.Drawing.Point(480, 16)
'        Me.cmd_itemto.Name = "cmd_itemto"
'        Me.cmd_itemto.Size = New System.Drawing.Size(24, 26)
'        Me.cmd_itemto.TabIndex = 475
'    '
'    'txt_itemto
'    '
'        Me.txt_itemto.BackColor = System.Drawing.Color.Wheat
'        Me.txt_itemto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
'        Me.txt_itemto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txt_itemto.Location = New System.Drawing.Point(384, 16)
'        Me.txt_itemto.MaxLength = 20
'        Me.txt_itemto.Name = "txt_itemto"
'        Me.txt_itemto.Size = New System.Drawing.Size(96, 22)
'        Me.txt_itemto.TabIndex = 474
'        Me.txt_itemto.Text = ""
'    '
'    'Label3
'    '
'        Me.Label3.AutoSize = True
'        Me.Label3.BackColor = System.Drawing.Color.Transparent
'        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label3.Location = New System.Drawing.Point(352, 24)
'        Me.Label3.Name = "Label3"
'        Me.Label3.Size = New System.Drawing.Size(27, 18)
'        Me.Label3.TabIndex = 473
'        Me.Label3.Text = "TO:"
'    '
'    'TXT_FROM
'    '
'        Me.TXT_FROM.BackColor = System.Drawing.Color.Wheat
'        Me.TXT_FROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
'        Me.TXT_FROM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.TXT_FROM.Location = New System.Drawing.Point(176, 16)
'        Me.TXT_FROM.MaxLength = 20
'        Me.TXT_FROM.Name = "TXT_FROM"
'        Me.TXT_FROM.Size = New System.Drawing.Size(96, 22)
'        Me.TXT_FROM.TabIndex = 471
'        Me.TXT_FROM.Text = ""
'    '
'    'Cmd_ITEMFROM
'    '
'        Me.Cmd_ITEMFROM.Image = CType(resources.GetObject("Cmd_ITEMFROM.Image"), System.Drawing.Image)
'        Me.Cmd_ITEMFROM.Location = New System.Drawing.Point(272, 16)
'        Me.Cmd_ITEMFROM.Name = "Cmd_ITEMFROM"
'        Me.Cmd_ITEMFROM.Size = New System.Drawing.Size(23, 26)
'        Me.Cmd_ITEMFROM.TabIndex = 472
'    '
'    'Lbl_SubledgerCode
'    '
'        Me.Lbl_SubledgerCode.AutoSize = True
'        Me.Lbl_SubledgerCode.BackColor = System.Drawing.Color.Transparent
'        Me.Lbl_SubledgerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Lbl_SubledgerCode.Location = New System.Drawing.Point(80, 24)
'        Me.Lbl_SubledgerCode.Name = "Lbl_SubledgerCode"
'        Me.Lbl_SubledgerCode.Size = New System.Drawing.Size(87, 18)
'        Me.Lbl_SubledgerCode.TabIndex = 470
'        Me.Lbl_SubledgerCode.Text = "ITEM  FROM:"
'    '
'    'CBO_SELECTALL
'    '
'        Me.CBO_SELECTALL.BackColor = System.Drawing.Color.Transparent
'        Me.CBO_SELECTALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.CBO_SELECTALL.Location = New System.Drawing.Point(8, 16)
'        Me.CBO_SELECTALL.Name = "CBO_SELECTALL"
'        Me.CBO_SELECTALL.Size = New System.Drawing.Size(152, 32)
'        Me.CBO_SELECTALL.TabIndex = 476
'        Me.CBO_SELECTALL.Text = "FOR SELECT ALL"
'        Me.CBO_SELECTALL.Visible = False
'    '
'    'GroupBox1
'    '
'        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
'        Me.GroupBox1.Controls.Add(Me.lbl_Storelocation)
'        Me.GroupBox1.Controls.Add(Me.cbo_Storelocation)
'        Me.GroupBox1.Location = New System.Drawing.Point(88, 464)
'        Me.GroupBox1.Name = "GroupBox1"
'        Me.GroupBox1.Size = New System.Drawing.Size(328, 56)
'        Me.GroupBox1.TabIndex = 477
'        Me.GroupBox1.TabStop = False
'    '
'    'GroupBox2
'    '
'        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
'        Me.GroupBox2.Controls.Add(Me.Lbl_SubledgerCode)
'        Me.GroupBox2.Controls.Add(Me.TXT_FROM)
'        Me.GroupBox2.Controls.Add(Me.Cmd_ITEMFROM)
'        Me.GroupBox2.Controls.Add(Me.Label3)
'        Me.GroupBox2.Controls.Add(Me.txt_itemto)
'        Me.GroupBox2.Controls.Add(Me.cmd_itemto)
'        Me.GroupBox2.Location = New System.Drawing.Point(424, 464)
'        Me.GroupBox2.Name = "GroupBox2"
'        Me.GroupBox2.Size = New System.Drawing.Size(552, 56)
'        Me.GroupBox2.TabIndex = 478
'        Me.GroupBox2.TabStop = False
'    '
'    'GroupBox4
'    '
'        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
'        Me.GroupBox4.Controls.Add(Me.CBO_SELECTALL)
'        Me.GroupBox4.Controls.Add(Me.Chkpcsmlwise)
'        Me.GroupBox4.Location = New System.Drawing.Point(832, 656)
'        Me.GroupBox4.Name = "GroupBox4"
'        Me.GroupBox4.Size = New System.Drawing.Size(152, 64)
'        Me.GroupBox4.TabIndex = 479
'        Me.GroupBox4.TabStop = False
'        Me.GroupBox4.Visible = False
'    '
'    'PictureBox1
'    '
'        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
'        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
'        Me.PictureBox1.Location = New System.Drawing.Point(328, 80)
'        Me.PictureBox1.Name = "PictureBox1"
'        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
'        Me.PictureBox1.TabIndex = 481
'        Me.PictureBox1.TabStop = False
'    '
'    'PictureBox3
'    '
'        Me.PictureBox3.BackColor = System.Drawing.Color.Maroon
'        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
'        Me.PictureBox3.Location = New System.Drawing.Point(632, 80)
'        Me.PictureBox3.Name = "PictureBox3"
'        Me.PictureBox3.Size = New System.Drawing.Size(24, 24)
'        Me.PictureBox3.TabIndex = 482
'        Me.PictureBox3.TabStop = False
'    '
'    'PictureBox4
'    '
'        Me.PictureBox4.BackColor = System.Drawing.Color.Maroon
'        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
'        Me.PictureBox4.Location = New System.Drawing.Point(920, 80)
'        Me.PictureBox4.Name = "PictureBox4"
'        Me.PictureBox4.Size = New System.Drawing.Size(24, 24)
'        Me.PictureBox4.TabIndex = 483
'        Me.PictureBox4.TabStop = False
'    '
'    'Label8
'    '
'        Me.Label8.BackColor = System.Drawing.Color.Maroon
'        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label8.ForeColor = System.Drawing.Color.White
'        Me.Label8.Location = New System.Drawing.Point(352, 80)
'        Me.Label8.Name = "Label8"
'        Me.Label8.Size = New System.Drawing.Size(32, 24)
'        Me.Label8.TabIndex = 484
'        Me.Label8.Text = "F3"
'    '
'    'Label9
'    '
'        Me.Label9.BackColor = System.Drawing.Color.Maroon
'        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label9.ForeColor = System.Drawing.Color.White
'        Me.Label9.Location = New System.Drawing.Point(656, 80)
'        Me.Label9.Name = "Label9"
'        Me.Label9.Size = New System.Drawing.Size(32, 24)
'        Me.Label9.TabIndex = 485
'        Me.Label9.Text = "F2"
'    '
'    'Label10
'    '
'        Me.Label10.BackColor = System.Drawing.Color.Maroon
'        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label10.ForeColor = System.Drawing.Color.White
'        Me.Label10.Location = New System.Drawing.Point(944, 80)
'        Me.Label10.Name = "Label10"
'        Me.Label10.Size = New System.Drawing.Size(32, 24)
'        Me.Label10.TabIndex = 486
'        Me.Label10.Text = "F1"
'    '
'    'Cmd_Export
'    '
'        Me.Cmd_Export.BackColor = System.Drawing.Color.Transparent
'        Me.Cmd_Export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Cmd_Export.ForeColor = System.Drawing.Color.Black
'        Me.Cmd_Export.Location = New System.Drawing.Point(536, 664)
'        Me.Cmd_Export.Name = "Cmd_Export"
'        Me.Cmd_Export.Size = New System.Drawing.Size(104, 32)
'        Me.Cmd_Export.TabIndex = 488
'        Me.Cmd_Export.Text = "EXPORT [F12]"
'        Me.Cmd_Export.Visible = False
'    '
'    'grp_orderby
'    '
'        Me.grp_orderby.BackColor = System.Drawing.Color.Transparent
'        Me.grp_orderby.Controls.Add(Me.rdo_name)
'        Me.grp_orderby.Controls.Add(Me.rdo_code)
'        Me.grp_orderby.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.grp_orderby.Location = New System.Drawing.Point(848, 528)
'        Me.grp_orderby.Name = "grp_orderby"
'        Me.grp_orderby.Size = New System.Drawing.Size(112, 64)
'        Me.grp_orderby.TabIndex = 496
'        Me.grp_orderby.TabStop = False
'        Me.grp_orderby.Text = "Order By"
'    '
'    'rdo_name
'    '
'        Me.rdo_name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.rdo_name.Location = New System.Drawing.Point(16, 40)
'        Me.rdo_name.Name = "rdo_name"
'        Me.rdo_name.Size = New System.Drawing.Size(96, 16)
'        Me.rdo_name.TabIndex = 1
'        Me.rdo_name.Text = " Name"
'    '
'    'rdo_code
'    '
'        Me.rdo_code.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.rdo_code.Location = New System.Drawing.Point(16, 16)
'        Me.rdo_code.Name = "rdo_code"
'        Me.rdo_code.Size = New System.Drawing.Size(88, 16)
'        Me.rdo_code.TabIndex = 0
'        Me.rdo_code.Text = "Item Code"
'    '
'    'btn_validation
'    '
'        Me.btn_validation.BackColor = System.Drawing.Color.Transparent
'        Me.btn_validation.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.btn_validation.ForeColor = System.Drawing.Color.Black
'        Me.btn_validation.Location = New System.Drawing.Point(464, 16)
'        Me.btn_validation.Name = "btn_validation"
'        Me.btn_validation.Size = New System.Drawing.Size(104, 32)
'        Me.btn_validation.TabIndex = 465
'        Me.btn_validation.Text = "Validation"
'    '
'    'Issue_Register
'    '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
'        Me.BackColor = System.Drawing.Color.Cornsilk
'        Me.ClientSize = New System.Drawing.Size(994, 710)
'        Me.ControlBox = False
'        Me.Controls.Add(Me.grp_orderby)
'        Me.Controls.Add(Me.Cmd_Export)
'        Me.Controls.Add(Me.Label10)
'        Me.Controls.Add(Me.Label9)
'        Me.Controls.Add(Me.Label8)
'        Me.Controls.Add(Me.PictureBox4)
'        Me.Controls.Add(Me.PictureBox3)
'        Me.Controls.Add(Me.PictureBox1)
'        Me.Controls.Add(Me.GroupBox4)
'        Me.Controls.Add(Me.GroupBox2)
'        Me.Controls.Add(Me.GroupBox1)
'        Me.Controls.Add(Me.Chk_SelectAllItem)
'        Me.Controls.Add(Me.lbl_Itemlist)
'        Me.Controls.Add(Me.chklist_itemdetails)
'        Me.Controls.Add(Me.chk_SelectAllGroup)
'        Me.Controls.Add(Me.Label2)
'        Me.Controls.Add(Me.chklist_groupdesc)
'        Me.Controls.Add(Me.frmbut)
'        Me.Controls.Add(Me.Label4)
'        Me.Controls.Add(Me.Chk_SelectAllStore)
'        Me.Controls.Add(Me.chklst_Store)
'        Me.Controls.Add(Me.lbl_Heading)
'        Me.Controls.Add(Me.grp_SalebillChecklist)
'        Me.Controls.Add(Me.GroupBox3)
'        Me.Controls.Add(Me.cmd_export1)
'        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.KeyPreview = True
'        Me.Name = "Issue_Register"
'        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
'        Me.Text = "REPORT [ ISSUE REGISTER ]"
'        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
'        Me.grp_SalebillChecklist.ResumeLayout(False)
'        Me.GroupBox3.ResumeLayout(False)
'        Me.frmbut.ResumeLayout(False)
'        Me.GroupBox1.ResumeLayout(False)
'        Me.GroupBox2.ResumeLayout(False)
'        Me.GroupBox4.ResumeLayout(False)
'        Me.grp_orderby.ResumeLayout(False)
'        Me.ResumeLayout(False)

'    End Sub

'#End Region
'    Dim gconnection As New GlobalClass
'    Dim Sqlstring As String
'    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
'        If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
'            Me.ProgressBar1.Value += 1
'            Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
'        Else
'            Me.Timer1.Enabled = False
'            Me.ProgressBar1.Value = 0
'            Me.grp_SalebillChecklist.Top = 1000
'            'If MsgBox("Click 'YES' for Windows View or 'NO' for Text View", MsgBoxStyle.YesNo, "Issue Register") = MsgBoxResult.Yes Then
'            Call ViewIssueregister_Crystal()
'            ' Else
'            '    Call ViewIssueregister()
'            ' End If
'        End If
'    End Sub

'    Private Sub ViewIssueregister()
'        Try
'            Dim sqlstring, STORENAME() As String
'            Dim i As Integer
'            If Chkpcsmlwise.Checked = True Then
'                '''****************************** $ ISSUE REGISTER [PCS ] $ *************************************'''
'                sqlstring = " SELECT * FROM ISSUEREGISTER"
'                If chklst_Store.CheckedItems.Count <> 0 Then
'                    sqlstring = sqlstring & " WHERE LOCATIONNAME IN ("
'                    For i = 0 To chklst_Store.CheckedItems.Count - 1
'                        sqlstring = sqlstring & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
'                    Next
'                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
'                    sqlstring = sqlstring & ")"
'                Else
'                    MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'                    Exit Sub
'                End If
'                sqlstring = sqlstring & " AND DOCDATE BETWEEN"
'                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
'                sqlstring = sqlstring & " ORDER BY LOCATIONNAME,DOCDETAILS,DOCDATE   "
'                gconnection.getDataSet(sqlstring, "GRIDVIEW")
'                gridviewstatus = "IssueRegisterreport"
'                gIssueregister = False
'                Dim griddesign As New GridDesign
'                griddesign.FormBorderStyle = FormBorderStyle.FixedDialog
'                griddesign.MdiParent = MDIParentobj
'                Me.Close()
'                griddesign.Show()
'                '''****************************** $ ISSUE REGISTER [PCS ] $ *************************************'''
'            Else
'                '''****************************** $ ISSUE REGISTER [ML ] $ *************************************'''
'                sqlstring = " SELECT * FROM ISSUEREGISTER "
'                If chklst_Store.CheckedItems.Count <> 0 Then
'                    sqlstring = sqlstring & " WHERE LOCATIONNAME IN ("
'                    For i = 0 To chklst_Store.CheckedItems.Count - 1
'                        sqlstring = sqlstring & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
'                    Next
'                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
'                    sqlstring = sqlstring & ")"
'                Else
'                    MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'                    Exit Sub
'                End If
'                sqlstring = sqlstring & " AND DOCDATE BETWEEN"
'                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
'                sqlstring = sqlstring & " AND FROMSTORENAME = '" & Trim(Mid(cbo_Storelocation.Text, 5, 12)) & "' "
'                sqlstring = sqlstring & " ORDER BY LOCATIONNAME,DOCDETAILS,DOCDATE   "

'                Dim heading() As String = {"ISSUE REGISTER"}
'                Dim ObjStockIssueregisterReport As New rptStockIssueregister
'                ObjStockIssueregisterReport.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
'                '''****************************** $ ISSUE REGISTER [ML ] $ *************************************'''
'            End If
'        Catch ex As Exception
'            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
'            Exit Sub
'        End Try
'    End Sub

'    Private Sub dtp_Fromdate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Fromdate.KeyPress
'        If Asc(e.KeyChar) = 13 Then
'            dtp_Todate.Focus()
'        End If
'    End Sub

'    Private Sub dtp_Todate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Todate.KeyPress
'        If Asc(e.KeyChar) = 13 Then
'            Cmd_View.Focus()
'        End If
'    End Sub

'    Private Sub Issue_Register_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
'        If e.KeyCode = Keys.F9 Then
'            Call Cmd_View_Click_1(Cmd_View, e)
'            Exit Sub
'        ElseIf e.KeyCode = Keys.F10 Then
'            Call Cmd_Print_Click_1(Cmd_Print, e)
'            Exit Sub
'        ElseIf e.KeyCode = Keys.F11 Then
'            Call Cmd_Exit_Click(sender, e)
'            Exit Sub
'        ElseIf e.KeyCode = Keys.Escape Then
'            Call Cmd_Exit_Click(sender, e)
'            Exit Sub
'        ElseIf e.Alt = True And e.KeyCode = Keys.F Then
'            Me.dtp_Fromdate.Focus()
'            Exit Sub
'        ElseIf e.Alt = True And e.KeyCode = Keys.T Then
'            Me.dtp_Todate.Focus()
'            Exit Sub
'        ElseIf e.KeyCode = Keys.F3 Then
'            Dim search As New frmListSearch
'            search.listbox = chklst_Store
'            search.Text = "Store Search"
'            search.ShowDialog(Me)

'        ElseIf e.KeyCode = Keys.F2 Then
'            Dim search As New frmListSearch
'            search.listbox = chklist_groupdesc
'            search.Text = "Group Search"
'            search.ShowDialog(Me)

'        ElseIf e.KeyCode = Keys.F1 Then
'            Dim Advsearch As New frmListSearch
'            Advsearch.listbox = chklist_itemdetails
'            Advsearch.Text = "Item Search"
'            Advsearch.ShowDialog(Me)
'        End If
'    End Sub

'    Private Sub Chk_SelectAllGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_SelectAllGroup.CheckedChanged
'        Dim i As Integer
'        If chk_SelectAllGroup.Checked = True Then
'            For i = 0 To chklist_groupdesc.Items.Count - 1
'                chklist_groupdesc.SetItemChecked(i, True)
'            Next
'            Call Chklist_Groupdesc_SelectedIndexChanged(sender, e)
'        Else
'            For i = 0 To chklist_groupdesc.Items.Count - 1
'                chklist_groupdesc.SetItemChecked(i, False)
'            Next
'            chklist_itemdetails.Items.Clear()
'        End If
'    End Sub

'    Private Sub Chk_SelectAllItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllItem.CheckedChanged
'        Dim i As Integer
'        If Chk_SelectAllItem.Checked = True Then
'            For i = 0 To chklist_itemdetails.Items.Count - 1
'                chklist_itemdetails.SetItemChecked(i, True)
'            Next
'        Else
'            For i = 0 To chklist_itemdetails.Items.Count - 1
'                chklist_itemdetails.SetItemChecked(i, False)
'            Next
'        End If
'    End Sub
'    'ADDED ON 26122009
'    Private Sub Chklist_Groupdesc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklist_groupdesc.SelectedIndexChanged
'        Dim i, J As Integer
'        Dim sqlstring, ssql As String
'        ssql = ""
'        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
'        sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' and I.GROUPNAME IN ("

'        For J = 0 To chklist_groupdesc.CheckedItems.Count - 1
'            If J = chklist_groupdesc.CheckedItems.Count - 1 Then
'                ssql = ssql & " '" & chklist_groupdesc.CheckedItems(J) & "' "
'            Else
'                ssql = ssql & " '" & chklist_groupdesc.CheckedItems(J) & "', "
'            End If
'        Next
'        If chklist_groupdesc.CheckedItems.Count > 0 Then
'            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
'            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
'            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
'                chklist_itemdetails.Items.Clear()
'                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
'                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
'                        chklist_itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
'                    End With
'                Next i
'            End If
'        Else
'            chklist_itemdetails.Items.Clear()
'        End If
'    End Sub
'    'ADDED ON 26122009

'    Private Sub Chklist_Groupdesc_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklist_groupdesc.DoubleClick
'        Dim i, J As Integer
'        Dim sqlstring, ssql As String
'        ssql = ""
'        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
'        sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' and I.GROUPNAME IN ("

'        For J = 0 To chklist_groupdesc.CheckedItems.Count - 1
'            If J = chklist_groupdesc.CheckedItems.Count - 1 Then
'                ssql = ssql & " '" & chklist_groupdesc.CheckedItems(J) & "' "
'            Else
'                ssql = ssql & " '" & chklist_groupdesc.CheckedItems(J) & "', "
'            End If
'        Next
'        If chklist_groupdesc.CheckedItems.Count > 0 Then
'            sqlstring = sqlstring & ssql & ") ORDER BY ITEMCODE "
'            gconnection.getDataSet(sqlstring, "INVENTORYSUBGROUPMASTER")
'            If gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count > 0 Then
'                chklist_itemdetails.Items.Clear()
'                For i = 0 To gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows.Count - 1
'                    With gdataset.Tables("INVENTORYSUBGROUPMASTER").Rows(i)
'                        chklist_itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
'                    End With
'                Next i
'            End If
'        End If
'    End Sub

'    Private Sub Issue_Register_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Call FillStorename()
'        Call FillStore()
'        chklist_groupdesc.Items.Clear()
'        chklist_itemdetails.Items.Clear()
'        TXT_FROM.Text = ""
'        txt_itemto.Text = ""
'        dtp_Fromdate.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
'        dtp_Todate.Value = Format(Now, "dd/MM/yyyy")
'        grp_SalebillChecklist.Top = 1000
'        Call FillGroupdetails()
'        chklist_itemdetails.Focus()
'        If gUserCategory <> "S" Then
'            Call GetRights()
'        End If
'        Lbl_SubledgerCode.Visible = True
'        Label8.Visible = True
'        Label3.Visible = True
'        TXT_FROM.Visible = True
'        txt_itemto.Visible = True
'        Cmd_ITEMFROM.Visible = True
'        cmd_itemto.Visible = True
'    End Sub
'    Private Sub FillStore()
'        Dim i As Integer
'        Sqlstring = "SELECT DISTINCT ISNULL(STOREcode,'') + '- '+ ISNULL(STOREdesc,'') AS STOREdesc FROM STOREMASTER WHERE isnull(storestatus,'') = 'M' and isnull(freeze,'') <> 'Y' ORDER BY STOREdesc ASC"
'        gconnection.getDataSet(Sqlstring, "STOREMASTER")
'        cbo_Storelocation.Items.Clear()
'        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
'            For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
'                cbo_Storelocation.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STOREdesc"))
'            Next i
'        End If
'    End Sub
'    '''******************************  To fill GROUP DETAILS *******************************'''
'    Private Sub FillGroupdetails()
'        Dim i As Integer
'        Dim sqlstring As String
'        chklist_groupdesc.Items.Clear()
'        sqlstring = "SELECT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPDESC,'') AS GROUPDESC FROM INVENTORYGROUPMASTER  where groupcode in (select groupcode from inventoryitemmaster) ORDER BY GROUPCODE "
'        gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
'        If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
'            For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
'                With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
'                    chklist_groupdesc.Items.Add(Trim(CStr(.Item("GROUPDESC"))))
'                End With
'            Next
'        End If
'    End Sub

'    '''******************************  To fill POS details from SupplierName  *******************************'''
'    Private Sub FillStorename()
'        Dim i As Integer
'        chklst_Store.Items.Clear()
'        Sqlstring = "SELECT DISTINCT ISNULL(OPSTORELOCATIONNAME,'') AS OPSTORELOCATIONNAME  FROM STOCKISSUEHEADER ORDER BY OPSTORELOCATIONNAME"
'        gconnection.getDataSet(Sqlstring, "STOCKISSUEHEADER")
'        If gdataset.Tables("STOCKISSUEHEADER").Rows.Count - 1 >= 0 Then
'            For i = 0 To gdataset.Tables("STOCKISSUEHEADER").Rows.Count - 1
'                With gdataset.Tables("STOCKISSUEHEADER").Rows(i)
'                    chklst_Store.Items.Add(Trim(.Item("OPSTORELOCATIONNAME")))
'                End With
'            Next i
'        End If
'    End Sub

'    Private Sub GetRights()
'        Dim i, j, k, x As Integer
'        Dim vmain, vsmod, vssmod As Long
'        Dim ssql, SQLSTRING As String
'        Dim M1 As New MainMenu
'        Dim chstr As String
'        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
'        gconnection.getDataSet(SQLSTRING, "USER")
'        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
'            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
'                With gdataset.Tables("USER").Rows(i)
'                    chstr = abcdMINUS(.Item("RIGHTS"))
'                End With
'            Next
'        End If
'        Me.Cmd_View.Enabled = False
'        Me.Cmd_Print.Enabled = False
'        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
'        If Len(chstr) > 0 Then
'            Dim Right() As Char
'            Right = chstr.ToCharArray
'            For x = 0 To Right.Length - 1
'                If Right(x) = "A" Then
'                    Me.Cmd_View.Enabled = True
'                    Me.Cmd_Print.Enabled = True
'                    Exit Sub
'                End If
'                If Right(x) = "V" Then
'                    Me.Cmd_View.Enabled = True
'                End If
'                If Right(x) = "P" Then
'                    Me.Cmd_Print.Enabled = True
'                End If
'            Next
'        End If
'    End Sub
'    Private Sub Chk_SelectAllStore_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllStore.CheckedChanged
'        Dim i As Integer
'        If Chk_SelectAllStore.Checked = True Then
'            For i = 0 To chklst_Store.Items.Count - 1
'                chklst_Store.SetItemChecked(i, True)
'            Next
'        Else
'            For i = 0 To chklst_Store.Items.Count - 1
'                chklst_Store.SetItemChecked(i, False)
'            Next
'        End If
'    End Sub

'    Private Sub Chk_SelectAllStore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk_SelectAllStore.KeyDown
'        If e.KeyCode = Keys.Enter Then
'            chklst_Store.Focus()
'        End If
'    End Sub

'    Private Sub chklst_Store_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklst_Store.KeyDown
'        If e.KeyCode = Keys.Enter Then
'            Chkpcsmlwise.Focus()
'        End If
'    End Sub

'    Private Sub Chkpcsmlwise_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chkpcsmlwise.KeyDown
'        If e.KeyCode = Keys.Enter Then
'            dtp_Fromdate.Focus()
'        End If
'    End Sub
'    Private Sub ViewIssueregister_Crystal()
'        Try
'            Dim sqlstring, STORENAME() As String
'            Dim exp As New EXPORT
'            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
'            Dim i As Integer
'            Dim rViewer As New Viewer
'            Dim r As New Rpt_IssueRegister
'            If Chkpcsmlwise.Checked = True Then
'                '''****************************** $ ISSUE REGISTER [PCS ] $ *************************************'''
'                sqlstring = " SELECT * FROM ISSUEREGISTER"
'                If chklst_Store.CheckedItems.Count <> 0 Then
'                    sqlstring = sqlstring & " WHERE LOCATIONNAME IN ("
'                    For i = 0 To chklst_Store.CheckedItems.Count - 1
'                        sqlstring = sqlstring & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
'                    Next
'                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
'                    sqlstring = sqlstring & ")"
'                Else
'                    MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'                    Exit Sub
'                End If

'                If chklist_itemdetails.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
'                    sqlstring = sqlstring & " AND ITEMCODE BETWEEN '"
'                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
'                Else
'                    If chklist_itemdetails.CheckedItems.Count <> 0 Then
'                        sqlstring = sqlstring & " AND ITEMCODE IN ("
'                        For i = 0 To chklist_itemdetails.CheckedItems.Count - 1
'                            Itemcode = Split(chklist_itemdetails.CheckedItems(i), "-->")
'                            sqlstring = sqlstring & "'" & Itemcode(0) & "', "
'                        Next
'                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
'                        sqlstring = sqlstring & ")"
'                    Else
'                        MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'                        Exit Sub
'                    End If
'                End If

'                sqlstring = sqlstring & " AND DOCDATE BETWEEN"
'                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
'                If rdo_code.Checked = True Then
'                    sqlstring = sqlstring & " ORDER BY LOCATIONNAME,DOCDETAILS,DOCDATE, itemcode   "
'                ElseIf rdo_name.Checked = True Then
'                    sqlstring = sqlstring & " ORDER BY LOCATIONNAME,DOCDETAILS,DOCDATE, itemname   "
'                Else
'                    sqlstring = sqlstring & " ORDER BY LOCATIONNAME,DOCDETAILS,DOCDATE   "
'                End If
'                gconnection.getDataSet(sqlstring, "GRIDVIEW")
'                gridviewstatus = "IssueRegisterreport"
'                gIssueregister = False
'                Dim griddesign As New GridDesign
'                griddesign.FormBorderStyle = FormBorderStyle.FixedDialog
'                griddesign.MdiParent = MDIParentobj
'                Me.Close()
'                griddesign.Show()
'                '''****************************** $ ISSUE REGISTER [PCS ] $ *************************************'''
'            Else
'                '''****************************** $ ISSUE REGISTER [ML ] $ *************************************'''
'                sqlstring = " SELECT * FROM ISSUEREGISTER "
'                If chklst_Store.CheckedItems.Count <> 0 Then
'                    sqlstring = sqlstring & " WHERE LOCATIONNAME IN ("
'                    For i = 0 To chklst_Store.CheckedItems.Count - 1
'                        sqlstring = sqlstring & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
'                    Next
'                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
'                    sqlstring = sqlstring & ")"
'                Else
'                    MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'                    Exit Sub
'                End If
'                'ADDED ON 26122009
'                If chklist_itemdetails.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
'                    sqlstring = sqlstring & " AND ITEMCODE BETWEEN '"
'                    sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
'                Else

'                    If chklist_itemdetails.CheckedItems.Count <> 0 Then
'                        sqlstring = sqlstring & " AND ITEMCODE IN ("
'                        For i = 0 To chklist_itemdetails.CheckedItems.Count - 1
'                            Itemcode = Split(chklist_itemdetails.CheckedItems(i), "-->")
'                            sqlstring = sqlstring & "'" & Itemcode(0) & "', "
'                        Next
'                        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
'                        sqlstring = sqlstring & ")"
'                    Else
'                        MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'                        Exit Sub
'                    End If
'                End If
'                'ADDED ON 26122009
'                sqlstring = sqlstring & " AND DOCDATE BETWEEN"
'                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
'                sqlstring = sqlstring & " AND FROMSTORENAME = '" & Trim(Mid(cbo_Storelocation.Text, 5, 12)) & "' "
'                If rdo_code.Checked = True Then
'                    sqlstring = sqlstring & " ORDER BY LOCATIONNAME,DOCDETAILS,DOCDATE, itemcode   "
'                ElseIf rdo_name.Checked = True Then
'                    sqlstring = sqlstring & " ORDER BY LOCATIONNAME,DOCDETAILS,DOCDATE, itemname   "
'                Else
'                    sqlstring = sqlstring & " ORDER BY LOCATIONNAME,DOCDETAILS,DOCDATE   "
'                End If
'                gconnection.getDataSet(sqlstring, "ISSUEREGISTER")
'                If gdataset.Tables("ISSUEREGISTER").Rows.Count > 0 Then
'                    If chk_excel.Checked = True Then
'                        Dim exp9 As New exportexcel
'                        exp9.Show()
'                        Call exp9.export(sqlstring, "STOCK ISSUE REPORT " & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtp_Todate.Value, "dd-MMM-yyyy"), "")
'                    Else
'                        rViewer.ssql = sqlstring
'                        rViewer.Report = r
'                        rViewer.TableName = "ISSUEREGISTER"
'                        Dim textobj1 As TextObject
'                        textobj1 = r.ReportDefinition.ReportObjects("Text3")
'                        textobj1.Text = MyCompanyName
'                        Dim textobj2 As TextObject
'                        textobj2 = r.ReportDefinition.ReportObjects("Text16")
'                        textobj2.Text = Trim(Mid(cbo_Storelocation.Text, 5, 12))
'                        Dim TXTOBJ3 As TextObject
'                        TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
'                        TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""
'                        Dim textobj4 As TextObject
'                        textobj4 = r.ReportDefinition.ReportObjects("Text21")
'                        textobj4.Text = gUsername
'                        rViewer.Show()
'                    End If
'                Else
'                    MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
'                End If

'                '''****************************** $ ISSUE REGISTER [ML ] $ *************************************'''
'            End If
'        Catch ex As Exception
'            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
'            Exit Sub
'        End Try
'    End Sub

'    Private Sub cbo_Storelocation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbo_Storelocation.KeyPress
'        If Asc(e.KeyChar) = 13 Then
'            dtp_Fromdate.Focus()
'        End If
'    End Sub

'    Private Sub Cmd_ITEMFROM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_ITEMFROM.Click
'        Try
'            Dim vform As New ListOperattion1
'            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
'            Dim I As Integer
'            gSQLString = " SELECT  itemcode,itemname  FROM INVENTORYITEMMASTER "
'            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'  "
'            M_WhereCondition = M_WhereCondition & " AND storecode = '" & Trim(Mid(cbo_Storelocation.Text, 1, 3)) & "'"
'            vform.Field = "ITEMCODE,ITEMNAME"
'            vform.vFormatstring = "  ITEMCODE                        |                          ITEMNAME                                                                                                               "
'            vform.vCaption = "ITEMMASTER MASTER HELP"
'            vform.KeyPos = 0
'            vform.KeyPos1 = 1
'            vform.ShowDialog(Me)
'            If Trim(vform.keyfield & "") <> "" Then
'                TXT_FROM.Text = Trim(vform.keyfield & "")
'                Me.txt_itemto.Focus()
'            Else
'                Me.TXT_FROM.Focus()
'            End If
'            vform.Close()
'            vform = Nothing
'        Catch ex As Exception
'            MessageBox.Show("Plz Check Error :Cmd_ITEMFROM_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'            Exit Sub
'        End Try
'    End Sub

'    Private Sub TXT_FROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_FROM.KeyPress
'        Try
'            getAlphanumeric(e)
'            If Asc(e.KeyChar) = 13 Then
'                If Trim(TXT_FROM.Text) = "" Then
'                    Call Cmd_ITEMFROM_Click(Cmd_ITEMFROM, e)
'                Else
'                    Call TXT_FROM_Validated(sender, e)
'                End If
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Plz Check Error : TXT_FROM_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'            Exit Sub
'        End Try
'    End Sub

'    Private Sub TXT_FROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_FROM.Validated
'        Try
'            Dim sqlstring, itemcode() As String
'            Dim i As Integer
'            If Trim(TXT_FROM.Text) <> "" Then
'                sqlstring = "select ITEMCODE, ITEMNAME from inventoryitemmaster where ITEMCODE = '" & Trim(TXT_FROM.Text) & "'"
'                sqlstring = sqlstring & " AND storecode = '" & Trim(Mid(cbo_Storelocation.Text, 1, 3)) & "'"
'                gconnection.getDataSet(sqlstring, "inventoryitemmaster")
'                If gdataset.Tables("inventoryitemmaster").Rows.Count > 0 Then
'                    TXT_FROM.Text = Trim(UCase(gdataset.Tables("inventoryitemmaster").Rows(0).Item("ITEMCODE")))
'                    txt_itemto.Focus()
'                Else
'                    TXT_FROM.Text = ""
'                    TXT_FROM.Focus()
'                End If
'            Else
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Plz Check Error : TXT_FROM_Validated " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'            Exit Sub
'        End Try
'    End Sub
'    Private Sub cmd_itemto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_itemto.Click
'        Try
'            Dim vform As New ListOperattion1
'            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
'            Dim I As Integer
'            gSQLString = " SELECT  itemcode,itemname  FROM INVENTORYITEMMASTER "
'            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'  "
'            M_WhereCondition = M_WhereCondition & " AND storecode = '" & Trim(Mid(cbo_Storelocation.Text, 1, 3)) & "'"
'            vform.Field = "ITEMCODE,ITEMNAME"
'            vform.vFormatstring = "  ITEMCODE                        |                          ITEMNAME                                                                                                               "
'            vform.vCaption = "ITEM MASTER HELP"
'            vform.KeyPos = 0
'            vform.KeyPos1 = 1
'            vform.ShowDialog(Me)
'            If Trim(vform.keyfield & "") <> "" Then
'                txt_itemto.Text = Trim(vform.keyfield & "")
'                Me.dtp_Fromdate.Focus()
'            Else
'                Me.txt_itemto.Focus()
'            End If
'            vform.Close()
'            vform = Nothing
'        Catch ex As Exception
'            MessageBox.Show("Plz Check Error : cmd_itemto_Click " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'            Exit Sub
'        End Try
'    End Sub

'    Private Sub txt_itemto_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_itemto.Validated
'        Try
'            Dim sqlstring, itemcode() As String
'            Dim i As Integer
'            If Trim(txt_itemto.Text) <> "" Then
'                sqlstring = "select ITEMCODE, ITEMNAME from inventoryitemmaster where ITEMCODE = '" & Trim(txt_itemto.Text) & "'"
'                sqlstring = sqlstring & " AND storecode = '" & Trim(Mid(cbo_Storelocation.Text, 1, 3)) & "'"
'                gconnection.getDataSet(sqlstring, "inventoryitemmaster")
'                If gdataset.Tables("inventoryitemmaster").Rows.Count > 0 Then
'                    txt_itemto.Text = Trim(UCase(gdataset.Tables("inventoryitemmaster").Rows(0).Item("ITEMCODE")))
'                    Cmd_Print.Focus()
'                Else
'                    txt_itemto.Text = ""
'                    txt_itemto.Focus()
'                End If
'            Else
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Plz Check Error : txt_itemto_Validated " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'            Exit Sub
'        End Try
'    End Sub

'    Private Sub txt_itemto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_itemto.KeyPress
'        Try
'            getAlphanumeric(e)
'            If Asc(e.KeyChar) = 13 Then
'                If Trim(txt_itemto.Text) = "" Then
'                    Call cmd_itemto_Click(cmd_itemto, e)
'                Else
'                    Call txt_itemto_Validated(sender, e)
'                End If
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Plz Check Error : txt_itemto_KeyPress" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'            Exit Sub
'        End Try
'    End Sub

'    Private Sub txt_itemto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_itemto.KeyDown
'        Try
'            If e.KeyCode = Keys.F4 Then
'                Call cmd_itemto_Click(sender, e)
'                Exit Sub
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Plz Check Error : txt_itemto_KeyDown" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'            Exit Sub
'        End Try
'    End Sub

'    Private Sub TXT_FROM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_FROM.KeyDown
'        Try
'            If e.KeyCode = Keys.F4 Then
'                Call Cmd_ITEMFROM_Click(sender, e)
'                Exit Sub
'            End If
'        Catch ex As Exception
'            MessageBox.Show("Plz Check Error : TXT_FROM_KeyDown" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'            Exit Sub
'        End Try
'    End Sub
'    Private Sub Cmd_Clear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
'        chklst_Store.Items.Clear()
'        grp_SalebillChecklist.Top = 1000
'        Chk_SelectAllStore.Checked = False
'        chk_SelectAllGroup.Checked = False
'        Chk_SelectAllItem.Checked = False
'        Call FillStorename()
'        TXT_FROM.Text = ""
'        txt_itemto.Text = ""
'        chklist_groupdesc.Items.Clear()
'        chklist_itemdetails.Items.Clear()
'        Call FillGroupdetails()
'        If gUserCategory <> "S" Then
'            Call GetRights()
'        End If
'        Lbl_SubledgerCode.Visible = False
'        Label3.Visible = False
'        TXT_FROM.Visible = False
'        txt_itemto.Visible = False
'        Cmd_ITEMFROM.Visible = False
'        cmd_itemto.Visible = False
'        CBO_SELECTALL.Checked = False
'        dtp_Fromdate.Focus()
'    End Sub

'    Private Sub Cmd_View_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click

'        If TXT_FROM.Text = "" And txt_itemto.Text = "" Then
'            If chklist_groupdesc.CheckedItems.Count = 0 Then
'                MessageBox.Show("Select the Group description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
'                Exit Sub
'            End If

'            If chklst_Store.CheckedItems.Count = 0 Then
'                MessageBox.Show("Select the Store Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
'                Exit Sub
'            End If
'        End If
'        If cbo_Storelocation.Text = "" Then
'            MsgBox("Please Choose StoreLocation", MsgBoxStyle.Information)
'            Exit Sub
'            cbo_Storelocation.Focus()
'        End If
'        Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
'        If chkdatevalidate = False Then Exit Sub
'        gPrint = False
'        grp_SalebillChecklist.Top = 527
'        grp_SalebillChecklist.Left = 128
'        Me.ProgressBar1.Value = 2
'        Me.Timer1.Interval = 10
'        Me.Timer1.Enabled = True
'    End Sub

'    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
'        Me.Close()
'    End Sub

'    Private Sub Cmd_Print_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click

'        If TXT_FROM.Text = "" And txt_itemto.Text = "" Then
'            If chklist_groupdesc.CheckedItems.Count = 0 Then
'                MessageBox.Show("Select the Group description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
'                Exit Sub
'            End If

'            If chklst_Store.CheckedItems.Count = 0 Then
'                MessageBox.Show("Select the Store Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
'                Exit Sub
'            End If
'        End If
'        If cbo_Storelocation.Text = "" Then
'            MsgBox("Please Choose StoreLocation", MsgBoxStyle.Information)
'            Exit Sub
'            cbo_Storelocation.Focus()
'        End If
'        Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
'        If chkdatevalidate = False Then Exit Sub
'        gPrint = True
'        grp_SalebillChecklist.Top = 527
'        grp_SalebillChecklist.Left = 86
'        Me.ProgressBar1.Value = 2
'        Me.Timer1.Interval = 10
'        Me.Timer1.Enabled = True
'    End Sub
'    Private Sub CBO_SELECTALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBO_SELECTALL.CheckedChanged

'        If CBO_SELECTALL.Checked = True Then
'            Lbl_SubledgerCode.Visible = True
'            Label8.Visible = True
'            Label3.Visible = True
'            TXT_FROM.Visible = True
'            txt_itemto.Visible = True
'            Cmd_ITEMFROM.Visible = True
'            cmd_itemto.Visible = True
'            '==== for all===='
'            chk_SelectAllGroup.Visible = False
'            Chk_SelectAllItem.Visible = False
'            Chk_SelectAllStore.Visible = False
'            chklist_groupdesc.Visible = False
'            chklist_itemdetails.Visible = False
'            chklst_Store.Visible = False
'            Label2.Visible = False
'            Label4.Visible = False
'            Label9.Visible = False
'            Label10.Visible = False
'            PictureBox1.Visible = False
'            PictureBox3.Visible = False
'            PictureBox4.Visible = False
'            lbl_Itemlist.Visible = False
'            Label8.Visible = False
'            '=====end ========'
'            TXT_FROM.Focus()
'        Else
'            Lbl_SubledgerCode.Visible = False
'            Label8.Visible = False
'            Label3.Visible = False
'            TXT_FROM.Visible = False
'            txt_itemto.Visible = False
'            Cmd_ITEMFROM.Visible = False
'            cmd_itemto.Visible = False
'            '==== for all===='
'            chk_SelectAllGroup.Visible = True
'            Chk_SelectAllItem.Visible = True
'            Chk_SelectAllStore.Visible = True
'            chklist_groupdesc.Visible = True
'            chklist_itemdetails.Visible = True
'            chklst_Store.Visible = True
'            Label2.Visible = True
'            Label4.Visible = True
'            Label9.Visible = True
'            Label10.Visible = True
'            PictureBox1.Visible = True
'            PictureBox3.Visible = True
'            PictureBox4.Visible = True
'            lbl_Itemlist.Visible = True
'            Label8.Visible = True
'            '=====end ========'
'        End If
'    End Sub

'    Private Sub Cmd_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        Dim sqlstring, STORENAME() As String
'        Dim exp As New EXPORT
'        Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
'        Dim i As Integer
'        Dim rViewer As New Viewer
'        Dim r As New Rpt_IssueRegister
'        If Chkpcsmlwise.Checked = True Then
'            '''****************************** $ ISSUE REGISTER [PCS ] $ *************************************'''
'            sqlstring = " SELECT * FROM ISSUEREGISTER"
'            If chklst_Store.CheckedItems.Count <> 0 Then
'                sqlstring = sqlstring & " WHERE LOCATIONNAME IN ("
'                For i = 0 To chklst_Store.CheckedItems.Count - 1
'                    sqlstring = sqlstring & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
'                Next
'                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
'                sqlstring = sqlstring & ")"
'            Else
'                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'                Exit Sub
'            End If

'            If chklist_itemdetails.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
'                sqlstring = sqlstring & " AND ITEMCODE BETWEEN '"
'                sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
'            Else
'                If chklist_itemdetails.CheckedItems.Count <> 0 Then
'                    sqlstring = sqlstring & " AND ITEMCODE IN ("
'                    For i = 0 To chklist_itemdetails.CheckedItems.Count - 1
'                        Itemcode = Split(chklist_itemdetails.CheckedItems(i), "-->")
'                        sqlstring = sqlstring & "'" & Itemcode(0) & "', "
'                    Next
'                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
'                    sqlstring = sqlstring & ")"
'                Else
'                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'                    Exit Sub
'                End If
'            End If

'            sqlstring = sqlstring & " AND DOCDATE BETWEEN"
'            sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
'            sqlstring = sqlstring & " ORDER BY LOCATIONNAME,DOCDETAILS,DOCDATE   "
'            gconnection.getDataSet(sqlstring, "GRIDVIEW")
'            gridviewstatus = "IssueRegisterreport"
'            gIssueregister = False
'            Dim griddesign As New GridDesign
'            griddesign.FormBorderStyle = FormBorderStyle.FixedDialog
'            griddesign.MdiParent = MDIParentobj
'            Me.Close()
'            griddesign.Show()
'            '''****************************** $ ISSUE REGISTER [PCS ] $ *************************************'''
'        Else
'            '''****************************** $ ISSUE REGISTER [ML ] $ *************************************'''
'            sqlstring = " SELECT * FROM ISSUEREGISTER "
'            If chklst_Store.CheckedItems.Count <> 0 Then
'                sqlstring = sqlstring & " WHERE LOCATIONNAME IN ("
'                For i = 0 To chklst_Store.CheckedItems.Count - 1
'                    sqlstring = sqlstring & " '" & Trim(chklst_Store.CheckedItems(i)) & "', "
'                Next
'                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
'                sqlstring = sqlstring & ")"
'            Else
'                MessageBox.Show("Select the Store Loc.(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'                Exit Sub
'            End If
'            'ADDED ON 26122009
'            If chklist_itemdetails.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
'                sqlstring = sqlstring & " AND ITEMCODE BETWEEN '"
'                sqlstring = sqlstring & Trim(TXT_FROM.Text) & "' AND '" & Trim(txt_itemto.Text) & "' "
'            Else

'                If chklist_itemdetails.CheckedItems.Count <> 0 Then
'                    sqlstring = sqlstring & " AND ITEMCODE IN ("
'                    For i = 0 To chklist_itemdetails.CheckedItems.Count - 1
'                        Itemcode = Split(chklist_itemdetails.CheckedItems(i), "-->")
'                        sqlstring = sqlstring & "'" & Itemcode(0) & "', "
'                    Next
'                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
'                    sqlstring = sqlstring & ")"
'                Else
'                    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
'                    Exit Sub
'                End If
'            End If
'            sqlstring = sqlstring & " AND DOCDATE BETWEEN"
'            sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
'            sqlstring = sqlstring & " AND FROMSTORENAME = '" & Trim(Mid(cbo_Storelocation.Text, 5, 12)) & "' "
'            sqlstring = sqlstring & " ORDER BY LOCATIONNAME,DOCDETAILS,DOCDATE   "

'            gconnection.getDataSet(sqlstring, "ISSUEREGISTER")
'            exp.TABLENAME = "ISSUEREGISTER"
'            Call exp.export_excel(sqlstring)
'            exp.Show()
'        End If
'    End Sub
'    Private Sub cmd_export1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export1.Click
'        Dim sqlstring As String
'        Dim _export As New EXPORT
'        _export.TABLENAME = "ISSUEREGISTER"
'        sqlstring = "select * from ISSUEREGISTER"
'        Call _export.export_excel(sqlstring)
'        _export.Show()
'        Exit Sub
'    End Sub

'    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_validation.Click
'        System.Diagnostics.Process.Start(AppPath & "/STUDY/STOCKISSUEREGISTER.XLS")
'    End Sub
'End Class