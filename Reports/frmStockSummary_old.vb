Imports System.IO
Imports System.Data.SqlClient
Public Class frmStockSummary_old
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
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_pegs As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockSummary_old))
        Me.lbl_Heading = New System.Windows.Forms.Label
        Me.cbo_Storelocation = New System.Windows.Forms.ComboBox
        Me.lbl_Storelocation = New System.Windows.Forms.Label
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.chk_pegs = New System.Windows.Forms.CheckBox
        Me.GroupBox3.SuspendLayout()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(360, 16)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(233, 31)
        Me.lbl_Heading.TabIndex = 5
        Me.lbl_Heading.Text = "STOCK SUMMARY"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbo_Storelocation
        '
        Me.cbo_Storelocation.BackColor = System.Drawing.Color.Wheat
        Me.cbo_Storelocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Storelocation.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbo_Storelocation.ItemHeight = 19
        Me.cbo_Storelocation.Location = New System.Drawing.Point(290, 512)
        Me.cbo_Storelocation.Name = "cbo_Storelocation"
        Me.cbo_Storelocation.Size = New System.Drawing.Size(158, 27)
        Me.cbo_Storelocation.TabIndex = 439
        '
        'lbl_Storelocation
        '
        Me.lbl_Storelocation.AutoSize = True
        Me.lbl_Storelocation.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Storelocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lbl_Storelocation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Storelocation.Location = New System.Drawing.Point(162, 517)
        Me.lbl_Storelocation.Name = "lbl_Storelocation"
        Me.lbl_Storelocation.Size = New System.Drawing.Size(92, 18)
        Me.lbl_Storelocation.TabIndex = 440
        Me.lbl_Storelocation.Text = "STORE LOC :"
        '
        'lbl_GroupList
        '
        Me.lbl_GroupList.BackColor = System.Drawing.Color.Maroon
        Me.lbl_GroupList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupList.ForeColor = System.Drawing.Color.White
        Me.lbl_GroupList.Location = New System.Drawing.Point(136, 72)
        Me.lbl_GroupList.Name = "lbl_GroupList"
        Me.lbl_GroupList.Size = New System.Drawing.Size(312, 24)
        Me.lbl_GroupList.TabIndex = 438
        Me.lbl_GroupList.Text = "GROUP SELECTION:"
        '
        'Chk_SelectAllGroup
        '
        Me.Chk_SelectAllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Chk_SelectAllGroup.Location = New System.Drawing.Point(136, 48)
        Me.Chk_SelectAllGroup.Name = "Chk_SelectAllGroup"
        Me.Chk_SelectAllGroup.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllGroup.TabIndex = 436
        Me.Chk_SelectAllGroup.Text = "SELECT ALL"
        '
        'Chklist_Groupdesc
        '
        Me.Chklist_Groupdesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Chklist_Groupdesc.Location = New System.Drawing.Point(136, 96)
        Me.Chklist_Groupdesc.Name = "Chklist_Groupdesc"
        Me.Chklist_Groupdesc.Size = New System.Drawing.Size(312, 403)
        Me.Chklist_Groupdesc.TabIndex = 437
        '
        'lbl_Itemlist
        '
        Me.lbl_Itemlist.BackColor = System.Drawing.Color.Maroon
        Me.lbl_Itemlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Itemlist.ForeColor = System.Drawing.Color.White
        Me.lbl_Itemlist.Location = New System.Drawing.Point(584, 72)
        Me.lbl_Itemlist.Name = "lbl_Itemlist"
        Me.lbl_Itemlist.Size = New System.Drawing.Size(312, 24)
        Me.lbl_Itemlist.TabIndex = 435
        Me.lbl_Itemlist.Text = "SELECT ITEMCODE :"
        '
        'Chk_SelectAllItem
        '
        Me.Chk_SelectAllItem.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Chk_SelectAllItem.Location = New System.Drawing.Point(584, 48)
        Me.Chk_SelectAllItem.Name = "Chk_SelectAllItem"
        Me.Chk_SelectAllItem.Size = New System.Drawing.Size(128, 24)
        Me.Chk_SelectAllItem.TabIndex = 433
        Me.Chk_SelectAllItem.Text = "SELECT ALL"
        '
        'Chklist_Itemdetails
        '
        Me.Chklist_Itemdetails.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Chklist_Itemdetails.Location = New System.Drawing.Point(584, 96)
        Me.Chklist_Itemdetails.Name = "Chklist_Itemdetails"
        Me.Chklist_Itemdetails.Size = New System.Drawing.Size(312, 403)
        Me.Chklist_Itemdetails.TabIndex = 434
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(272, 688)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(423, 18)
        Me.Label5.TabIndex = 447
        Me.Label5.Text = "Press F2 to select all / Press ENTER key to navigate"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_Fromdate)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtp_Todate)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(152, 552)
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
        Me.dtp_Fromdate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.dtp_Fromdate.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
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
        Me.dtp_Todate.MaxDate = New Date(9998, 8, 14, 0, 0, 0, 0)
        Me.dtp_Todate.MinDate = New Date(2000, 8, 14, 0, 0, 0, 0)
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
        Me.Cmd_Print.Location = New System.Drawing.Point(528, 640)
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
        Me.Cmd_View.Location = New System.Drawing.Point(384, 640)
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(680, 640)
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(240, 640)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 441
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Location = New System.Drawing.Point(152, 624)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(712, 56)
        Me.frmbut.TabIndex = 444
        Me.frmbut.TabStop = False
        '
        'Timer1
        '
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.BackgroundImage = CType(resources.GetObject("grp_SalebillChecklist.BackgroundImage"), System.Drawing.Image)
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label2)
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(152, 552)
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
        Me.CHK_ZEROQTY.BackgroundImage = CType(resources.GetObject("CHK_ZEROQTY.BackgroundImage"), System.Drawing.Image)
        Me.CHK_ZEROQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_ZEROQTY.Location = New System.Drawing.Point(648, 504)
        Me.CHK_ZEROQTY.Name = "CHK_ZEROQTY"
        Me.CHK_ZEROQTY.Size = New System.Drawing.Size(144, 24)
        Me.CHK_ZEROQTY.TabIndex = 449
        Me.CHK_ZEROQTY.Text = "WITH ZERO QTY"
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.BackgroundImage = CType(resources.GetObject("CheckBox1.BackgroundImage"), System.Drawing.Image)
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckBox1.Location = New System.Drawing.Point(808, 504)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(80, 24)
        Me.CheckBox1.TabIndex = 450
        Me.CheckBox1.Text = "NEW"
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.BackgroundImage = CType(resources.GetObject("CheckBox2.BackgroundImage"), System.Drawing.Image)
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckBox2.Location = New System.Drawing.Point(528, 504)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(112, 24)
        Me.CheckBox2.TabIndex = 451
        Me.CheckBox2.Text = "Closing Only"
        '
        'chk_pegs
        '
        Me.chk_pegs.BackColor = System.Drawing.Color.Transparent
        Me.chk_pegs.BackgroundImage = CType(resources.GetObject("chk_pegs.BackgroundImage"), System.Drawing.Image)
        Me.chk_pegs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.chk_pegs.Location = New System.Drawing.Point(456, 424)
        Me.chk_pegs.Name = "chk_pegs"
        Me.chk_pegs.Size = New System.Drawing.Size(112, 24)
        Me.chk_pegs.TabIndex = 452
        Me.chk_pegs.Text = "Pegs"
        '
        'frmStockSummary_old
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1016, 709)
        Me.Controls.Add(Me.chk_pegs)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CHK_ZEROQTY)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_Storelocation)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox3)
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
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmStockSummary_old"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORT [ STOCK SUMMARY ]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Private Sub FillStore()
        Try
            Dim i As Integer
            sqlstring = "SELECT DISTINCT ISNULL(I.STORECODE,'') AS STORECODE,ISNULL(S.STOREDESC,'') AS STOREDESC FROM INVENTORYITEMMASTER AS I,STOREMASTER S "
            sqlstring = sqlstring & " WHERE I.STORECODE=S.STORECODE AND ISNULL(S.FREEZE,'')<>'Y' AND isnull(I.freeze,'') <> 'Y' "
            If Chklist_Groupdesc.CheckedItems.Count > 0 Then
                sqlstring = sqlstring & " and I.GROUPNAME IN ("
                For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                    sqlstring = sqlstring & " '" & Chklist_Groupdesc.CheckedItems(i) & "',"
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 1)
                sqlstring = sqlstring & ")"
            End If
            gconnection.getDataSet(sqlstring, "STOREMASTER")
            cbo_Storelocation.Items.Clear()
            cbo_Storelocation.Sorted = True
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("STOREMASTER").Rows.Count - 1
                    cbo_Storelocation.Items.Add(gdataset.Tables("STOREMASTER").Rows(i).Item("STOREDESC"))
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillItemdetails()
        Try
            Dim i As Integer
            Dim sqlstring As String
            Chklist_Itemdetails.Items.Clear()
            sqlstring = "SELECT DISTINCT ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMNAME,'') AS ITEMNAME,isnull(STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER where isnull(freeze,'') <> 'Y' ORDER BY ITEMCODE "
            gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
            If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                        Chklist_Itemdetails.Items.Add(Trim(CStr(.Item("ITEMCODE"))) & "-->" & Trim(CStr(.Item("ITEMNAME"))))
                    End With
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillGroupdetails()
        Try
            Dim i As Integer
            Dim sqlstring As String
            Chklist_Groupdesc.Items.Clear()
            sqlstring = "SELECT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPDESC,'') AS GROUPDESC FROM INVENTORYGROUPMASTER where isnull(freeze,'') <> 'Y' ORDER BY GROUPCODE"
            gconnection.getDataSet(sqlstring, "INVENTORYGROUPMASTER")
            If gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("INVENTORYGROUPMASTER").Rows.Count - 1
                    With gdataset.Tables("INVENTORYGROUPMASTER").Rows(i)
                        Chklist_Groupdesc.Items.Add(Trim(CStr(.Item("GROUPDESC"))))
                    End With
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Try
            If Chklist_Groupdesc.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Chklist_Itemdetails.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
            If chkdatevalidate = False Then Exit Sub
            gPrint = False
            grp_SalebillChecklist.Top = 552
            grp_SalebillChecklist.Left = 152
            Me.ProgressBar1.Value = 2
            Me.Timer1.Interval = 100
            Me.Timer1.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Try
            If Chklist_Groupdesc.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group description(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Chklist_Itemdetails.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
            If chkdatevalidate = False Then Exit Sub
            gPrint = True
            grp_SalebillChecklist.Top = 552
            grp_SalebillChecklist.Left = 152
            Me.ProgressBar1.Value = 2
            Me.Timer1.Interval = 100
            Me.Timer1.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Try
            dtp_Fromdate.Value = Format(Now, "dd/MM/yyyy")
            dtp_Todate.Value = Format(Now, "dd/MM/yyyy")
            grp_SalebillChecklist.Top = 1000
            Chklist_Groupdesc.Items.Clear()
            Chklist_Itemdetails.Items.Clear()
            Call FillGroupdetails()
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            Chklist_Itemdetails.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Chklist_Groupdesc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chklist_Groupdesc.DoubleClick
        Try
            Dim i, J As Integer
            Dim sqlstring As String
            For J = 0 To Chklist_Groupdesc.Items.Count - 1
                If Chklist_Groupdesc.GetItemChecked(J) = True Then
                    sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER AS I "
                    sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' and I.GROUPNAME IN ("
                    For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                        sqlstring = sqlstring & " '" & Chklist_Groupdesc.CheckedItems(i) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                    gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
                    If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                        Chklist_Itemdetails.Items.Clear()
                        For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                            With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                                Chklist_Itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                            End With
                        Next i
                    End If
                    Chklist_Itemdetails.Sorted = True
                End If
            Next
            Call FillStore()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Chklist_Groupdesc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chklist_Groupdesc.SelectedIndexChanged
        Try
            Dim i, J As Integer
            Dim sqlstring As String
            For J = 0 To Chklist_Groupdesc.Items.Count - 1
                If Chklist_Groupdesc.GetItemChecked(J) = True Then
                    sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,isnull(i.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER AS I "
                    sqlstring = sqlstring & " WHERE isnull(freeze,'') <> 'Y' and I.GROUPNAME IN ("
                    For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
                        sqlstring = sqlstring & " '" & Chklist_Groupdesc.CheckedItems(i) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"


                    gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
                    If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
                        Chklist_Itemdetails.Items.Clear()
                        For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
                            With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
                                Chklist_Itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
                            End With
                        Next i
                    End If
                    Chklist_Itemdetails.Sorted = True
                End If
            Next
            Call FillStore()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Chk_SelectAllGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllGroup.CheckedChanged
        Try
            Dim i As Integer
            If Chk_SelectAllGroup.Checked = True Then
                For i = 0 To Chklist_Groupdesc.Items.Count - 1
                    Chklist_Groupdesc.SetItemChecked(i, True)
                Next
            Else
                For i = 0 To Chklist_Groupdesc.Items.Count - 1
                    Chklist_Groupdesc.SetItemChecked(i, False)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Chk_SelectAllItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllItem.CheckedChanged
        Try
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
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub dtp_Fromdate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Fromdate.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                dtp_Todate.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub dtp_Todate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_Todate.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                Cmd_View.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub frmMainStockPosition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Chklist_Groupdesc.Items.Clear()
            Chklist_Itemdetails.Items.Clear()
            dtp_Fromdate.Value = Format(Now, "dd/MM/yyyy")
            dtp_Todate.Value = Format(Now, "dd/MM/yyyy")
            grp_SalebillChecklist.Top = 1000
            Call FillGroupdetails()
            Chklist_Itemdetails.Focus()
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
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
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub frmMainStockPosition_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
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
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
                Me.ProgressBar1.Value += 1
                Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
            Else
                Me.Timer1.Enabled = False
                Me.ProgressBar1.Value = 0
                Me.grp_SalebillChecklist.Top = 1000
                If CheckBox1.Checked = False Then
                    Call ViewStocksummary()
                Else
                    Call ViewStocksummary_New()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub ViewStocksummary()
        Try
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim Boolupdate As Boolean
            Dim I As Integer
            Storecode = "" : Clsquantity = "" : I = 0

            Storecode = "Update inventoryitemmaster set selectopt=''"
            gconnection.dataOperation(6, Storecode, "ItemMaster")
            If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
                For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                    Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                    Storecode = "Update inventoryitemmaster set selectopt='Y' where itemcode='" & Itemcode(0) & "'"
                    gconnection.dataOperation(6, Storecode, "ItemMaster")
                Next
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            Storecode = ""

            sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(cbo_Storelocation.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOREMASTER")
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
                '---------------------- EXECUTE STORE PROCEDURE --------------------------'
                gconnection.openConnection()
                gcommand = New SqlCommand("CP_STOCKSUMMARY3", gconnection.Myconn)
                gcommand.CommandType = CommandType.StoredProcedure
                gcommand.CommandTimeout = 9999
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

            sqlstring = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE,ISNULL(S.ITEMNAME,'') AS ITEMDESC, ISNULL(I.GROUPNAME,'') AS GROUPNAME"

            If chk_pegs.Checked = False Then
                sqlstring = sqlstring & ",ISNULL(S.UOM,'') AS UOM,ISNULL(S.CLSRATE,0) AS RATE, ISNULL(S.OPQTY,0.000) AS OPQTY, ISNULL(S.RCVQTY,0.000) AS RCVQTY, ISNULL(S.ISSQTY,0.000) AS ISSQTY, ISNULL(S.CLSQTY,0.00) AS CLSQTY, ISNULL(S.CLSVAL,0.00) AS VALUE,0 AS ISSVALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "
            Else
                sqlstring = sqlstring & ",ISNULL(S.DISPUOM,'') AS UOM,ISNULL(S.CLSRATE,0) AS RATE, ISNULL(S.OPDISPQTY,0.000) AS OPQTY, ISNULL(S.RCDISPQTY,0.000) AS RCVQTY, ISNULL(S.ISDISPQTY,0.000) AS ISSQTY, ISNULL(S.DISPQTY,0.00) AS CLSQTY, ISNULL(S.CLSVAL,0.00) AS VALUE,ISNULL(S.ISSRATE,0)*ISNULL(S.ISDISPQTY,0.000) AS ISSVALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "
            End If
            If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE I.ITEMCODE=S.ITEMCODE AND I.STORECODE=S.STORECODE AND I.STORECODE='" & Trim(Storecode) & "' AND S.ITEMCODE IN ("
                For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                    Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                    sqlstring = sqlstring & "'" & Itemcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " ORDER BY I.GROUPNAME,S.ITEMcode   "
            Dim heading() As String = {"STOCK SUMMARY" & "[ " & Trim(cbo_Storelocation.Text) & " ]"}
            Dim ObjSTOCKSummary As New rptStockSummary
            If CheckBox2.Checked = True Then
                ObjSTOCKSummary.Reportdetails_closing(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            Else
                ObjSTOCKSummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Public Sub ViewStocksummary_New()
        Try
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim Boolupdate As Boolean
            Dim I As Integer
            Me.Cursor = Cursors.WaitCursor

            Storecode = "" : Clsquantity = "" : I = 0

            Storecode = "Update inventoryitemmaster set selectopt=''"
            gconnection.dataOperation(6, Storecode, "ItemMaster")
            If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
                For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                    Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                    Storecode = "Update inventoryitemmaster set selectopt='Y' where itemcode='" & Itemcode(0) & "'"
                    gconnection.dataOperation(6, Storecode, "ItemMaster")
                Next
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            Storecode = ""

            sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(cbo_Storelocation.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOREMASTER")
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
                '---------------------- EXECUTE STORE PROCEDURE --------------------------'
                'gconnection.openConnection()
                'gcommand = New SqlCommand("CP_StockUpdate", gconnection.Myconn)
                'gcommand.CommandType = CommandType.StoredProcedure
                'gcommand.CommandTimeout = 9999
                'gcommand.ExecuteNonQuery()
                'gconnection.closeConnection()
                '--------------------------------------------------------------------------'
            Else
                MessageBox.Show("Select the Store Loc.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Select Case Month(dtp_Todate.Value)
                Case 4
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0.000) AS OPQTY, ISNULL(I.APRDRQTY,0.000) AS RCVQTY, ISNULL(I.APRCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)-ISNULL(I.APRCRQTY,0) AS CLSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRVAL,0)-ISNULL(I.APRCRVAL,0) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 5
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0.000)+ISNULL(I.APRDRQTY,0)-ISNULL(I.APRCRQTY,0) AS OPQTY, ISNULL(I.MAYDRQTY,0.000) AS RCVQTY, ISNULL(I.MAYCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 6
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)) AS OPQTY, ISNULL(I.JUNDRQTY,0.000) AS RCVQTY, ISNULL(I.JUNCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)+ISNULL(I.JUNDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)+ISNULL(I.JUNCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 7
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)) AS OPQTY, ISNULL(I.JULDRQTY,0.000) AS RCVQTY, ISNULL(I.JULCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)+ISNULL(I.JUNDRVAL,0)+ISNULL(I.JULDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)+ISNULL(I.JUNCRVAL,0)+ISNULL(I.JULCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 8
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)) AS OPQTY, ISNULL(I.AUGDRQTY,0.000) AS RCVQTY, ISNULL(I.AUGCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)+ISNULL(I.JUNDRVAL,0)+ISNULL(I.JULDRVAL,0)+ISNULL(I.AUGDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)+ISNULL(I.JUNCRVAL,0)+ISNULL(I.JULCRVAL,0)+ISNULL(I.AUGCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 9
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)) AS OPQTY, ISNULL(I.SEPDRQTY,0.000) AS RCVQTY, ISNULL(I.SEPCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)+ISNULL(I.JUNDRVAL,0)+ISNULL(I.JULDRVAL,0)+ISNULL(I.AUGDRVAL,0)+ISNULL(I.SEPDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)+ISNULL(I.JUNCRVAL,0)+ISNULL(I.JULCRVAL,0)+ISNULL(I.AUGCRVAL,0)+ISNULL(I.SEPCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 10
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)) AS OPQTY, ISNULL(I.OCTDRQTY,0.000) AS RCVQTY, ISNULL(I.OCTCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)+ISNULL(I.JUNDRVAL,0)+ISNULL(I.JULDRVAL,0)+ISNULL(I.AUGDRVAL,0)+ISNULL(I.SEPDRVAL,0)+ISNULL(I.OCTDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)+ISNULL(I.JUNCRVAL,0)+ISNULL(I.JULCRVAL,0)+ISNULL(I.AUGCRVAL,0)+ISNULL(I.SEPCRVAL,0)+ISNULL(I.OCTCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 11
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)) AS OPQTY, ISNULL(I.NOVDRQTY,0.000) AS RCVQTY, ISNULL(I.NOVCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)+ISNULL(I.NOVDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)+ISNULL(I.NOVCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)+ISNULL(I.JUNDRVAL,0)+ISNULL(I.JULDRVAL,0)+ISNULL(I.AUGDRVAL,0)+ISNULL(I.SEPDRVAL,0)+ISNULL(I.OCTDRVAL,0)+ISNULL(I.NOVDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)+ISNULL(I.JUNCRVAL,0)+ISNULL(I.JULCRVAL,0)+ISNULL(I.AUGCRVAL,0)+ISNULL(I.SEPCRVAL,0)+ISNULL(I.OCTCRVAL,0)+ISNULL(I.NOVCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 12
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)+ISNULL(I.NOVDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)+ISNULL(I.NOVCRQTY,0)) AS OPQTY, ISNULL(I.DECDRQTY,0.000) AS RCVQTY, ISNULL(I.DECCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)+ISNULL(I.NOVDRQTY,0)+ISNULL(I.DECDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)+ISNULL(I.NOVCRQTY,0)+ISNULL(I.DECCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)+ISNULL(I.JUNDRVAL,0)+ISNULL(I.JULDRVAL,0)+ISNULL(I.AUGDRVAL,0)+ISNULL(I.SEPDRVAL,0)+ISNULL(I.OCTDRVAL,0)+ISNULL(I.NOVDRVAL,0)+ISNULL(I.DECDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)+ISNULL(I.JUNCRVAL,0)+ISNULL(I.JULCRVAL,0)+ISNULL(I.AUGCRVAL,0)+ISNULL(I.SEPCRVAL,0)+ISNULL(I.OCTCRVAL,0)+ISNULL(I.NOVCRVAL,0)+ISNULL(I.DECCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 1
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)+ISNULL(I.NOVDRQTY,0)+ISNULL(I.DECDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)+ISNULL(I.NOVCRQTY,0)+ISNULL(I.DECCRQTY,0)) AS OPQTY, ISNULL(I.JANDRQTY,0.000) AS RCVQTY, ISNULL(I.JANCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)+ISNULL(I.NOVDRQTY,0)+ISNULL(I.DECDRQTY,0)+ISNULL(I.JANDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)+ISNULL(I.NOVCRQTY,0)+ISNULL(I.DECCRQTY,0)+ISNULL(I.JANCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)+ISNULL(I.JUNDRVAL,0)+ISNULL(I.JULDRVAL,0)+ISNULL(I.AUGDRVAL,0)+ISNULL(I.SEPDRVAL,0)+ISNULL(I.OCTDRVAL,0)+ISNULL(I.NOVDRVAL,0)+ISNULL(I.DECDRVAL,0)+ISNULL(I.JANDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)+ISNULL(I.JUNCRVAL,0)+ISNULL(I.JULCRVAL,0)+ISNULL(I.AUGCRVAL,0)+ISNULL(I.SEPCRVAL,0)+ISNULL(I.OCTCRVAL,0)+ISNULL(I.NOVCRVAL,0)+ISNULL(I.DECCRVAL,0)+ISNULL(I.JANCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 2
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)+ISNULL(I.NOVDRQTY,0)+ISNULL(I.DECDRQTY,0)+ISNULL(I.JANDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)+ISNULL(I.NOVCRQTY,0)+ISNULL(I.DECCRQTY,0)+ISNULL(I.JANCRQTY,0)) AS OPQTY, ISNULL(I.FEBDRQTY,0.000) AS RCVQTY, ISNULL(I.FEBCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)+ISNULL(I.NOVDRQTY,0)+ISNULL(I.DECDRQTY,0)+ISNULL(I.JANDRQTY,0)+ISNULL(I.FEBDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)+ISNULL(I.NOVCRQTY,0)+ISNULL(I.DECCRQTY,0)+ISNULL(I.JANCRQTY,0)+ISNULL(I.FEBCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)+ISNULL(I.JUNDRVAL,0)+ISNULL(I.JULDRVAL,0)+ISNULL(I.AUGDRVAL,0)+ISNULL(I.SEPDRVAL,0)+ISNULL(I.OCTDRVAL,0)+ISNULL(I.NOVDRVAL,0)+ISNULL(I.DECDRVAL,0)+ISNULL(I.JANDRVAL,0)+ISNULL(I.FEBDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)+ISNULL(I.JUNCRVAL,0)+ISNULL(I.JULCRVAL,0)+ISNULL(I.AUGCRVAL,0)+ISNULL(I.SEPCRVAL,0)+ISNULL(I.OCTCRVAL,0)+ISNULL(I.NOVCRVAL,0)+ISNULL(I.DECCRVAL,0)+ISNULL(I.JANCRVAL,0)+ISNULL(I.FEBCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
                Case 3
                    sqlstring = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMDESC,ISNULL(I.STOCKUOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
                    sqlstring = sqlstring & "ISNULL(I.PURCHASERATE,0) AS RATE, ISNULL(I.OPSTOCK,0)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)+ISNULL(I.NOVDRQTY,0)+ISNULL(I.DECDRQTY,0)+ISNULL(I.JANDRQTY,0)+ISNULL(I.FEBDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)+ISNULL(I.NOVCRQTY,0)+ISNULL(I.DECCRQTY,0)+ISNULL(I.JANCRQTY,0)+ISNULL(I.FEBCRQTY,0)) AS OPQTY, ISNULL(I.MARDRQTY,0.000) AS RCVQTY, ISNULL(I.MARCRQTY,0.000) AS ISSQTY, ISNULL(I.OPSTOCK,0.00)+ISNULL(I.APRDRQTY,0)+ISNULL(I.MAYDRQTY,0)+ISNULL(I.JUNDRQTY,0)+ISNULL(I.JULDRQTY,0)+ISNULL(I.AUGDRQTY,0)+ISNULL(I.SEPDRQTY,0)+ISNULL(I.OCTDRQTY,0)+ISNULL(I.NOVDRQTY,0)+ISNULL(I.DECDRQTY,0)+ISNULL(I.JANDRQTY,0)+ISNULL(I.FEBDRQTY,0)+ISNULL(I.MARDRQTY,0)-(ISNULL(I.APRCRQTY,0)+ISNULL(I.MAYCRQTY,0)+ISNULL(I.JUNCRQTY,0)+ISNULL(I.JULCRQTY,0)+ISNULL(I.AUGCRQTY,0)+ISNULL(I.SEPCRQTY,0)+ISNULL(I.OCTCRQTY,0)+ISNULL(I.NOVCRQTY,0)+ISNULL(I.DECCRQTY,0)+ISNULL(I.JANCRQTY,0)+ISNULL(I.FEBCRQTY,0)+ISNULL(I.MARCRQTY,0)) AS CLSQTY, ISNULL(I.OPVALUE,0.00)+ISNULL(I.APRDRVAL,0)+ISNULL(I.MAYDRVAL,0)+ISNULL(I.JUNDRVAL,0)+ISNULL(I.JULDRVAL,0)+ISNULL(I.AUGDRVAL,0)+ISNULL(I.SEPDRVAL,0)+ISNULL(I.OCTDRVAL,0)+ISNULL(I.NOVDRVAL,0)+ISNULL(I.DECDRVAL,0)+ISNULL(I.JANDRVAL,0)+ISNULL(I.FEBDRVAL,0)+ISNULL(I.MARDRVAL,0)-(ISNULL(I.APRCRVAL,0)+ISNULL(I.MAYCRVAL,0)+ISNULL(I.JUNCRVAL,0)+ISNULL(I.JULCRVAL,0)+ISNULL(I.AUGCRVAL,0)+ISNULL(I.SEPCRVAL,0)+ISNULL(I.OCTCRVAL,0)+ISNULL(I.NOVCRVAL,0)+ISNULL(I.DECCRVAL,0)+ISNULL(I.JANCRVAL,0)+ISNULL(I.FEBCRVAL,0)+ISNULL(I.MARCRVAL,0)) AS VALUE,isnull(I.STARTDATE,'" & Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy") & "') as startdate FROM INVENTORYITEMMASTER I "
            End Select
            If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE I.STORECODE='" & Trim(Storecode) & "' AND I.ITEMCODE IN ("
                For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                    Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                    sqlstring = sqlstring & "'" & Itemcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            sqlstring = sqlstring & " ORDER BY I.GROUPNAME,I.ITEMcode"

            Dim heading() As String = {"STOCK SUMMARY" & "[ " & Trim(cbo_Storelocation.Text) & " ]"}

            Dim ObjSTOCKSummary As New rptStockSummary

            If CheckBox2.Checked = True Then
                ObjSTOCKSummary.Reportdetails_closing(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            Else
                ObjSTOCKSummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
End Class
