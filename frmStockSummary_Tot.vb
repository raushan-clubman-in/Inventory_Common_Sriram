Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmStockSummary
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockSummary))
        Me.lbl_Heading = New System.Windows.Forms.Label
        Me.lbl_GroupList = New System.Windows.Forms.Label
        Me.Chk_SelectAllGroup = New System.Windows.Forms.CheckBox
        Me.Chklist_Groupdesc = New System.Windows.Forms.CheckedListBox
        Me.lbl_Itemlist = New System.Windows.Forms.Label
        Me.Chk_SelectAllItem = New System.Windows.Forms.CheckBox
        Me.Chklist_Itemdetails = New System.Windows.Forms.CheckedListBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtp_Fromdate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp_Todate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Cmd_Print = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.frmbut = New System.Windows.Forms.GroupBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox
        Me.lbl_Wait = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.CHK_ZEROQTY = New System.Windows.Forms.CheckBox
        Me.CHK_VALUE = New System.Windows.Forms.CheckBox
        Me.CHK_ITEMMASTSTK = New System.Windows.Forms.CheckBox
        Me.grp_orderby = New System.Windows.Forms.GroupBox
        Me.rdo_name = New System.Windows.Forms.RadioButton
        Me.rdo_code = New System.Windows.Forms.RadioButton
        Me.cmd_itemto = New System.Windows.Forms.Button
        Me.txt_itemto = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXT_FROM = New System.Windows.Forms.TextBox
        Me.Cmd_ITEMFROM = New System.Windows.Forms.Button
        Me.Lbl_SubledgerCode = New System.Windows.Forms.Label
        Me.txt_Mainstore = New System.Windows.Forms.TextBox
        Me.lbl_Mainstore = New System.Windows.Forms.Label
        Me.cmd_storecode = New System.Windows.Forms.Button
        Me.TXT_MAINSTORECODE = New System.Windows.Forms.TextBox
        Me.GroupBox3.SuspendLayout()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.grp_orderby.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(368, 16)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(233, 31)
        Me.lbl_Heading.TabIndex = 5
        Me.lbl_Heading.Text = "STOCK SUMMARY"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_GroupList
        '
        Me.lbl_GroupList.BackColor = System.Drawing.Color.Maroon
        Me.lbl_GroupList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupList.ForeColor = System.Drawing.Color.White
        Me.lbl_GroupList.Location = New System.Drawing.Point(96, 72)
        Me.lbl_GroupList.Name = "lbl_GroupList"
        Me.lbl_GroupList.Size = New System.Drawing.Size(352, 24)
        Me.lbl_GroupList.TabIndex = 438
        Me.lbl_GroupList.Text = "SELECT GROUPCODE :"
        '
        'Chk_SelectAllGroup
        '
        Me.Chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Chk_SelectAllGroup.Location = New System.Drawing.Point(96, 48)
        Me.Chk_SelectAllGroup.Name = "Chk_SelectAllGroup"
        Me.Chk_SelectAllGroup.Size = New System.Drawing.Size(168, 24)
        Me.Chk_SelectAllGroup.TabIndex = 436
        Me.Chk_SelectAllGroup.Text = "SELECT ALL"
        '
        'Chklist_Groupdesc
        '
        Me.Chklist_Groupdesc.CheckOnClick = True
        Me.Chklist_Groupdesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Chklist_Groupdesc.Location = New System.Drawing.Point(96, 96)
        Me.Chklist_Groupdesc.Name = "Chklist_Groupdesc"
        Me.Chklist_Groupdesc.Size = New System.Drawing.Size(352, 361)
        Me.Chklist_Groupdesc.TabIndex = 437
        '
        'lbl_Itemlist
        '
        Me.lbl_Itemlist.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Itemlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemlist.ForeColor = System.Drawing.Color.White
        Me.lbl_Itemlist.Location = New System.Drawing.Point(528, 72)
        Me.lbl_Itemlist.Name = "lbl_Itemlist"
        Me.lbl_Itemlist.Size = New System.Drawing.Size(344, 24)
        Me.lbl_Itemlist.TabIndex = 435
        Me.lbl_Itemlist.Text = "SELECT ITEMCODE :"
        '
        'Chk_SelectAllItem
        '
        Me.Chk_SelectAllItem.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Chk_SelectAllItem.Location = New System.Drawing.Point(528, 48)
        Me.Chk_SelectAllItem.Name = "Chk_SelectAllItem"
        Me.Chk_SelectAllItem.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllItem.TabIndex = 433
        Me.Chk_SelectAllItem.Text = "SELECT ALL"
        '
        'Chklist_Itemdetails
        '
        Me.Chklist_Itemdetails.CheckOnClick = True
        Me.Chklist_Itemdetails.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Chklist_Itemdetails.Location = New System.Drawing.Point(528, 96)
        Me.Chklist_Itemdetails.Name = "Chklist_Itemdetails"
        Me.Chklist_Itemdetails.Size = New System.Drawing.Size(344, 361)
        Me.Chklist_Itemdetails.TabIndex = 434
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(112, 670)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(759, 21)
        Me.Label5.TabIndex = 447
        Me.Label5.Text = "Press F1 to Advanced Search / Press F2 to Search Group / Press F3 to Search Items" & _
        "/ Press ENTER key to navigate"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_Fromdate)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtp_Todate)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(136, 536)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(712, 64)
        Me.GroupBox3.TabIndex = 446
        Me.GroupBox3.TabStop = False
        '
        'dtp_Fromdate
        '
        Me.dtp_Fromdate.CustomFormat = "dd-MM-yyyy"
        Me.dtp_Fromdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Fromdate.Location = New System.Drawing.Point(152, 24)
        Me.dtp_Fromdate.MaxDate = New Date(2010, 8, 14, 0, 0, 0, 0)
        Me.dtp_Fromdate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.dtp_Fromdate.Name = "dtp_Fromdate"
        Me.dtp_Fromdate.Size = New System.Drawing.Size(144, 26)
        Me.dtp_Fromdate.TabIndex = 0
        Me.dtp_Fromdate.Value = New Date(2006, 9, 14, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(424, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TO DATE :"
        '
        'dtp_Todate
        '
        Me.dtp_Todate.CustomFormat = "dd-MM-yyyy"
        Me.dtp_Todate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_Todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Todate.Location = New System.Drawing.Point(544, 24)
        Me.dtp_Todate.MaxDate = New Date(2010, 8, 14, 0, 0, 0, 0)
        Me.dtp_Todate.MinDate = New Date(2005, 8, 14, 0, 0, 0, 0)
        Me.dtp_Todate.Name = "dtp_Todate"
        Me.dtp_Todate.Size = New System.Drawing.Size(144, 26)
        Me.dtp_Todate.TabIndex = 1
        Me.dtp_Todate.Value = New Date(2006, 8, 14, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "FROM DATE :"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.White
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.Location = New System.Drawing.Point(512, 624)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Print.TabIndex = 445
        Me.Cmd_Print.Text = " Print [F10]"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(368, 624)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 442
        Me.Cmd_View.Text = " View[F9]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(664, 624)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 443
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.Location = New System.Drawing.Point(224, 624)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 441
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Location = New System.Drawing.Point(136, 608)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(712, 56)
        Me.frmbut.TabIndex = 444
        Me.frmbut.TabStop = False
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
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(136, 536)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(712, 64)
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
        Me.lbl_Wait.Size = New System.Drawing.Size(0, 18)
        Me.lbl_Wait.TabIndex = 387
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(288, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 18)
        Me.Label2.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 16)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(696, 32)
        Me.ProgressBar1.TabIndex = 0
        '
        'CHK_ZEROQTY
        '
        Me.CHK_ZEROQTY.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ZEROQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_ZEROQTY.Location = New System.Drawing.Point(856, 632)
        Me.CHK_ZEROQTY.Name = "CHK_ZEROQTY"
        Me.CHK_ZEROQTY.Size = New System.Drawing.Size(120, 32)
        Me.CHK_ZEROQTY.TabIndex = 449
        Me.CHK_ZEROQTY.Text = "WITH ZERO QTY"
        '
        'CHK_VALUE
        '
        Me.CHK_VALUE.BackColor = System.Drawing.Color.Transparent
        Me.CHK_VALUE.Checked = True
        Me.CHK_VALUE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHK_VALUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_VALUE.Location = New System.Drawing.Point(856, 592)
        Me.CHK_VALUE.Name = "CHK_VALUE"
        Me.CHK_VALUE.Size = New System.Drawing.Size(128, 32)
        Me.CHK_VALUE.TabIndex = 450
        Me.CHK_VALUE.Text = "TRANSACTION ONLY"
        '
        'CHK_ITEMMASTSTK
        '
        Me.CHK_ITEMMASTSTK.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ITEMMASTSTK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_ITEMMASTSTK.Location = New System.Drawing.Point(856, 552)
        Me.CHK_ITEMMASTSTK.Name = "CHK_ITEMMASTSTK"
        Me.CHK_ITEMMASTSTK.Size = New System.Drawing.Size(128, 32)
        Me.CHK_ITEMMASTSTK.TabIndex = 452
        Me.CHK_ITEMMASTSTK.Text = "ITEM MASTER STOCK"
        '
        'grp_orderby
        '
        Me.grp_orderby.BackColor = System.Drawing.Color.Transparent
        Me.grp_orderby.Controls.Add(Me.rdo_name)
        Me.grp_orderby.Controls.Add(Me.rdo_code)
        Me.grp_orderby.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_orderby.Location = New System.Drawing.Point(784, 472)
        Me.grp_orderby.Name = "grp_orderby"
        Me.grp_orderby.Size = New System.Drawing.Size(200, 40)
        Me.grp_orderby.TabIndex = 469
        Me.grp_orderby.TabStop = False
        Me.grp_orderby.Text = "Order By"
        '
        'rdo_name
        '
        Me.rdo_name.Location = New System.Drawing.Point(104, 16)
        Me.rdo_name.Name = "rdo_name"
        Me.rdo_name.Size = New System.Drawing.Size(96, 16)
        Me.rdo_name.TabIndex = 1
        Me.rdo_name.Text = "Item Name"
        '
        'rdo_code
        '
        Me.rdo_code.Checked = True
        Me.rdo_code.Location = New System.Drawing.Point(16, 16)
        Me.rdo_code.Name = "rdo_code"
        Me.rdo_code.Size = New System.Drawing.Size(88, 16)
        Me.rdo_code.TabIndex = 0
        Me.rdo_code.TabStop = True
        Me.rdo_code.Text = "Item Code"
        '
        'cmd_itemto
        '
        Me.cmd_itemto.Image = CType(resources.GetObject("cmd_itemto.Image"), System.Drawing.Image)
        Me.cmd_itemto.Location = New System.Drawing.Point(672, 512)
        Me.cmd_itemto.Name = "cmd_itemto"
        Me.cmd_itemto.Size = New System.Drawing.Size(23, 26)
        Me.cmd_itemto.TabIndex = 481
        '
        'txt_itemto
        '
        Me.txt_itemto.BackColor = System.Drawing.Color.Wheat
        Me.txt_itemto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_itemto.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_itemto.Location = New System.Drawing.Point(576, 512)
        Me.txt_itemto.MaxLength = 20
        Me.txt_itemto.Name = "txt_itemto"
        Me.txt_itemto.Size = New System.Drawing.Size(96, 26)
        Me.txt_itemto.TabIndex = 480
        Me.txt_itemto.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(536, 520)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 18)
        Me.Label4.TabIndex = 479
        Me.Label4.Text = "TO:"
        '
        'TXT_FROM
        '
        Me.TXT_FROM.BackColor = System.Drawing.Color.Wheat
        Me.TXT_FROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_FROM.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_FROM.Location = New System.Drawing.Point(248, 512)
        Me.TXT_FROM.MaxLength = 20
        Me.TXT_FROM.Name = "TXT_FROM"
        Me.TXT_FROM.Size = New System.Drawing.Size(96, 26)
        Me.TXT_FROM.TabIndex = 477
        Me.TXT_FROM.Text = ""
        '
        'Cmd_ITEMFROM
        '
        Me.Cmd_ITEMFROM.Image = CType(resources.GetObject("Cmd_ITEMFROM.Image"), System.Drawing.Image)
        Me.Cmd_ITEMFROM.Location = New System.Drawing.Point(344, 512)
        Me.Cmd_ITEMFROM.Name = "Cmd_ITEMFROM"
        Me.Cmd_ITEMFROM.Size = New System.Drawing.Size(23, 26)
        Me.Cmd_ITEMFROM.TabIndex = 478
        '
        'Lbl_SubledgerCode
        '
        Me.Lbl_SubledgerCode.AutoSize = True
        Me.Lbl_SubledgerCode.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubledgerCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubledgerCode.Location = New System.Drawing.Point(144, 520)
        Me.Lbl_SubledgerCode.Name = "Lbl_SubledgerCode"
        Me.Lbl_SubledgerCode.Size = New System.Drawing.Size(90, 18)
        Me.Lbl_SubledgerCode.TabIndex = 476
        Me.Lbl_SubledgerCode.Text = "ITEM  FROM:"
        '
        'txt_Mainstore
        '
        Me.txt_Mainstore.BackColor = System.Drawing.Color.Wheat
        Me.txt_Mainstore.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Mainstore.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Mainstore.Location = New System.Drawing.Point(208, 8)
        Me.txt_Mainstore.MaxLength = 15
        Me.txt_Mainstore.Name = "txt_Mainstore"
        Me.txt_Mainstore.ReadOnly = True
        Me.txt_Mainstore.Size = New System.Drawing.Size(152, 26)
        Me.txt_Mainstore.TabIndex = 493
        Me.txt_Mainstore.Text = ""
        '
        'lbl_Mainstore
        '
        Me.lbl_Mainstore.AutoSize = True
        Me.lbl_Mainstore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Mainstore.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Mainstore.Location = New System.Drawing.Point(8, 8)
        Me.lbl_Mainstore.Name = "lbl_Mainstore"
        Me.lbl_Mainstore.Size = New System.Drawing.Size(104, 18)
        Me.lbl_Mainstore.TabIndex = 492
        Me.lbl_Mainstore.Text = "FROM STORE :"
        '
        'cmd_storecode
        '
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(184, 8)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 495
        '
        'TXT_MAINSTORECODE
        '
        Me.TXT_MAINSTORECODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_MAINSTORECODE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_MAINSTORECODE.Location = New System.Drawing.Point(120, 8)
        Me.TXT_MAINSTORECODE.MaxLength = 15
        Me.TXT_MAINSTORECODE.Name = "TXT_MAINSTORECODE"
        Me.TXT_MAINSTORECODE.Size = New System.Drawing.Size(64, 26)
        Me.TXT_MAINSTORECODE.TabIndex = 496
        Me.TXT_MAINSTORECODE.Text = ""
        '
        'frmStockSummary
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1016, 746)
        Me.ControlBox = False
        Me.Controls.Add(Me.TXT_MAINSTORECODE)
        Me.Controls.Add(Me.txt_Mainstore)
        Me.Controls.Add(Me.lbl_Mainstore)
        Me.Controls.Add(Me.cmd_storecode)
        Me.Controls.Add(Me.cmd_itemto)
        Me.Controls.Add(Me.txt_itemto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXT_FROM)
        Me.Controls.Add(Me.Cmd_ITEMFROM)
        Me.Controls.Add(Me.Lbl_SubledgerCode)
        Me.Controls.Add(Me.grp_orderby)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.CHK_ITEMMASTSTK)
        Me.Controls.Add(Me.CHK_VALUE)
        Me.Controls.Add(Me.CHK_ZEROQTY)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.lbl_GroupList)
        Me.Controls.Add(Me.Chk_SelectAllGroup)
        Me.Controls.Add(Me.Chklist_Groupdesc)
        Me.Controls.Add(Me.lbl_Itemlist)
        Me.Controls.Add(Me.Chk_SelectAllItem)
        Me.Controls.Add(Me.Chklist_Itemdetails)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmStockSummary"
        Me.Text = "REPORTS [STOCK SUMMARY]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.grp_orderby.ResumeLayout(False)
        Me.ResumeLayout(False)

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
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        If TXT_FROM.Text = "" And txt_itemto.Text = "" Then
            If Trim(TXT_FROM.Text) = "" And Trim(txt_itemto.Text) = "" Then
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
        grp_SalebillChecklist.Top = 536
        grp_SalebillChecklist.Left = 136
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
        'If Chklist_Itemdetails.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        gPrint = True
        grp_SalebillChecklist.Top = 552
        grp_SalebillChecklist.Left = 152
        Me.ProgressBar1.Value = 2
        Me.Timer1.Interval = 300
        Me.Timer1.Enabled = True

    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        'Call FillStore()
        dtp_Fromdate.Value = Format(Now, "dd/MM/yyyy")
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
            sqlstring = sqlstring & ssql & ")"
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
            sqlstring = sqlstring & ssql & ") order by itemcode "
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
    Private Sub Chk_SelectAllGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllGroup.CheckedChanged
        Dim i As Integer
        If Chk_SelectAllGroup.Checked = True Then
            For i = 0 To Chklist_Groupdesc.Items.Count - 1
                Chklist_Groupdesc.SetItemChecked(i, True)
            Next
            Chklist_Groupdesc_SelectedIndexChanged(sender, e)
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
    Private Sub frmMainStockPosition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MsgBox("Please Run Weighted Average Under Administrator, if you are already executed then ignore  ...", MsgBoxStyle.OKOnly, "Info.")
        'Call FillStore()
        Chklist_Groupdesc.Items.Clear()
        Chklist_Itemdetails.Items.Clear()
        dtp_Fromdate.Value = Format(Now, "dd/MM/yyyy")
        dtp_Todate.Value = Format(Now, "dd/MM/yyyy")
        grp_SalebillChecklist.Top = 1000
        '        Chklist_Itemdetails.Focus()
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
            search.Text = "Item Search"
            search.ShowDialog(Me)
        ElseIf e.KeyCode = Keys.F2 Then
            Dim search As New frmListSearch
            search.listbox = Chklist_Groupdesc
            search.Text = "Group Search"
            search.ShowDialog(Me)
        ElseIf e.KeyCode = Keys.F1 Then
            Dim lstAdvSearch As New frmSearch_Advanced
            lstAdvSearch.chklistbox = Chklist_Itemdetails
            lstAdvSearch.Text = "Advanced Item Search"
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

            If CHK_ITEMMASTSTK.Checked = True Then
                Call Item_master_stock_crystal()
            ElseIf CHK_VALUE.Checked = True Then
                If MsgBox("Click YES for 'Windows View' or NO for 'TEXT View'", MsgBoxStyle.YesNo, "STOCK SUMMARY") = MsgBoxResult.Yes Then
                    Call StkSummary_crystal()
                Else
                    Call ViewStocksummary()
                End If
            End If
        End If
    End Sub
    Public Sub ViewStocksummary()
        Try
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
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

            sqlstring = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE,ISNULL(S.ITEMNAME,'') AS ITEMDESC,ISNULL(S.UOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
            sqlstring = sqlstring & "SUM(ISNULL(S.OPQTY,0.000)) AS OPQTY,SUM(ISNULL(S.OPVAL,0.000)) AS OPVAL, SUM(ISNULL(S.RCVQTY,0.000)) AS RCVQTY,SUM(ISNULL(S.RCVVAL,0.000)) AS RCVVAL,SUM(ISNULL(S.RCVQTY1,0.000)) AS RCVQTY1,SUM(ISNULL(S.RCVVAL1,0.000)) AS RCVVAL1,SUM(ISNULL(S.RCVQTY2,0.000)) AS RCVQTY2,SUM(ISNULL(S.RCVVAL2,0.000)) AS RCVVAL2,SUM(ISNULL(S.RCVQTY3,0.000)) AS RCVQTY3,SUM(ISNULL(S.RCVVAL3,0.000)) AS RCVVAL3,SUM(ISNULL(S.ISSQTY,0.000)) AS ISSQTY,SUM(ISNULL(S.ISSVAL,0.000)) AS ISSVAL,SUM(ISNULL(S.ISSQTY1,0.000)) AS ISSQTY1,SUM(ISNULL(S.ISSVAL1,0.000)) AS ISSVAL1,SUM(ISNULL(S.ISSQTY2,0.000)) AS ISSQTY2,SUM(ISNULL(S.ISSVAL2,0.000)) AS ISSVAL2,SUM(ISNULL(S.ISSQTY3,0.000)) AS ISSQTY3,SUM(ISNULL(S.ISSVAL3,0.000)) AS ISSVAL3,SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSVAL,0.00)) AS VALUE,SUM(ISNULL(S.DISPQTY,0)) AS DISPQTY FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "
            sqlstring = sqlstring & " WHERE I.ITEMCODE=S.ITEMCODE "
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
                'ObjSTOCKSummary.Reportdetails_Value(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                ObjSTOCKSummary.Reportdetails_Value_withoutGroup(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                'ElseIf CHK_QTY.Checked Then
                '    ObjSTOCKSummary.Reportdetails_Qty(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            Else
                'ObjSTOCKSummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
                ObjSTOCKSummary.Reportdetails_withoutGroup(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            End If
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
                'If CHK_QTY.Checked = True Then
                '    gcommand.Parameters.Add(New SqlParameter("@OPTQTY", SqlDbType.SmallInt)).Value = 1
                'Else
                '    gcommand.Parameters.Add(New SqlParameter("@OPTQTY", SqlDbType.SmallInt)).Value = 0
                'End If
                gcommand.ExecuteNonQuery()
                gconnection.closeConnection()
                '--------------------------------------------------------------------------'
            Else
                MessageBox.Show("Select the Store Loc.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            sqlstring = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE,ISNULL(S.ITEMNAME,'') AS ITEMNAME,ISNULL(S.UOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
            sqlstring = sqlstring & "SUM(ISNULL(S.OPQTY,0.000)) AS OPQTY,SUM(ISNULL(S.OPVAL,0.000)) AS OPVAL, SUM(ISNULL(S.RCVQTY,0.000)) AS RCVQTY,SUM(ISNULL(S.RCVVAL,0.000)) AS RCVVAL,SUM(ISNULL(S.RCVQTY1,0.000)) AS RCVQTY1,SUM(ISNULL(S.RCVVAL1,0.000)) AS RCVVAL1,SUM(ISNULL(S.RCVQTY2,0.000)) AS RCVQTY2,SUM(ISNULL(S.RCVVAL2,0.000)) AS RCVVAL2,SUM(ISNULL(S.RCVQTY3,0.000)) AS RCVQTY3,SUM(ISNULL(S.RCVVAL3,0.000)) AS RCVVAL3,ISNULL(S.RCVRATE,0) AS RCVRATE ,SUM(ISNULL(S.ISSQTY,0.000)) AS ISSQTY,ISNULL(S.ISSRATE,0) AS ISSRATE ,SUM(ISNULL(S.ISSVAL,0.000)) AS ISSVAL,SUM(ISNULL(S.ISSQTY1,0.000)) AS ISSQTY1,SUM(ISNULL(S.ISSVAL1,0.000)) AS ISSVAL1,SUM(ISNULL(S.ISSQTY2,0.000)) AS ISSQTY2,SUM(ISNULL(S.ISSVAL2,0.000)) AS ISSVAL2,SUM(ISNULL(S.ISSQTY3,0.000)) AS ISSQTY3,SUM(ISNULL(S.ISSVAL3,0.000)) AS ISSVAL3,SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSRATE,0.00)) CLSRATE, SUM(ISNULL(S.CLSVAL,0.00)) AS VALUE,SUM(ISNULL(S.DISPQTY,0)) AS DISPQTY,SUM(ISNULL(S.OPDISPQTY,0.000)) AS OPDISPQTY,SUM(ISNULL(S.ISDISPQTY,0.000)) AS ISDISPQTY  FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "
            sqlstring = sqlstring & " WHERE I.ITEMCODE=S.ITEMCODE AND I.STORECODE ='" & Storecode & "'"
            If CHK_ZEROQTY.Checked = False Then
                sqlstring = sqlstring & " And (OPQTY <> 0 OR RCVQTY <> 0 OR ISSQTY <> 0)"
            End If
            sqlstring = sqlstring & " AND OPQTY > 0 GROUP BY ISNULL(S.ITEMCODE,''),ISNULL(S.ITEMNAME,''),ISNULL(S.UOM,''), ISNULL(I.GROUPNAME,'') , ISNULL(S.ISSRATE,0) , ISNULL(S.RCVRATE,0) ORDER BY  "
            If rdo_code.Checked = True Then
                sqlstring = sqlstring & " ITEMCODE   "
            Else
                sqlstring = sqlstring & " ITEMNAME "
            End If
            gconnection.getDataSet(sqlstring, "ISSUEREGISTER")
            If gdataset.Tables("ISSUEREGISTER").Rows.Count > 0 Then
                rViewer.ssql = sqlstring
                rViewer.Report = r
                rViewer.TableName = "STOCKSUMMARY"

                Dim textobj1 As TextObject
                textobj1 = r.ReportDefinition.ReportObjects("Text13")
                textobj1.Text = MyCompanyName

                Dim textobj2 As TextObject
                textobj2 = r.ReportDefinition.ReportObjects("Text8")
                textobj2.Text = Trim(txt_Mainstore.Text)

                Dim TXTOBJ3 As TextObject
                TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
                TXTOBJ3.Text = " From  " & Format(dtp_Fromdate.Value, "dd/MM/yyyy") & "  To " & " " & Format(dtp_Todate.Value, "dd/MM/yyyy") & ""
                rViewer.Show()
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
                'If CHK_QTY.Checked = True Then
                '    gcommand.Parameters.Add(New SqlParameter("@OPTQTY", SqlDbType.SmallInt)).Value = 1
                'Else
                '    gcommand.Parameters.Add(New SqlParameter("@OPTQTY", SqlDbType.SmallInt)).Value = 0
                'End If
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
            sqlstring = sqlstring & "SUM(ISNULL(S.ISSVAL,0.000)) AS ISSVAL,SUM(ISNULL(S.ISSQTY1,0.000)) AS ISSQTY1,SUM(ISNULL(S.ISSVAL1,0.000)) AS ISSVAL1,SUM(ISNULL(S.ISSQTY2,0.000)) AS ISSQTY2,SUM(ISNULL(S.ISSVAL2,0.000)) AS ISSVAL2,SUM(ISNULL(S.ISSQTY3,0.000)) AS ISSQTY3,SUM(ISNULL(S.ISSVAL3,0.000)) AS ISSVAL3,SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSRATE,0.00)) CLSRATE, SUM(ISNULL(S.CLSVAL,0.00)) AS VALUE,SUM(ISNULL(S.DISPQTY,0)) AS DISPQTY FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "

            If Chklist_Itemdetails.CheckedItems.Count = 0 And TXT_FROM.Text <> "" And txt_itemto.Text <> "" Then
                ' sqlstring = sqlstring & " WHERE I.ITEMCODE=s.ITEMCODE "
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
            rViewer.Show()


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
            Dim vform As New List_Operation
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
            Dim vform As New List_Operation
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
        Dim vform As New List_Operation
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
            Call FillGroupdetails()
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

End Class
