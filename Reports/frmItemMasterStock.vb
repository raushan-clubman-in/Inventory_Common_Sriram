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
    Friend WithEvents CHK_VALUE As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_QTY As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStockSummary))
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
        Me.CHK_VALUE = New System.Windows.Forms.CheckBox
        Me.CHK_QTY = New System.Windows.Forms.CheckBox
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
        Me.lbl_GroupList.Text = "SELECT GROUPCODE :"
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
        Me.Label5.Location = New System.Drawing.Point(184, 688)
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
        Me.Timer1.Interval = 10
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
        Me.CHK_ZEROQTY.BackgroundImage = CType(resources.GetObject("CHK_ZEROQTY.BackgroundImage"), System.Drawing.Image)
        Me.CHK_ZEROQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_ZEROQTY.Location = New System.Drawing.Point(584, 512)
        Me.CHK_ZEROQTY.Name = "CHK_ZEROQTY"
        Me.CHK_ZEROQTY.Size = New System.Drawing.Size(144, 24)
        Me.CHK_ZEROQTY.TabIndex = 449
        Me.CHK_ZEROQTY.Text = "WITH ZERO QTY"
        '
        'CHK_VALUE
        '
        Me.CHK_VALUE.BackgroundImage = CType(resources.GetObject("CHK_VALUE.BackgroundImage"), System.Drawing.Image)
        Me.CHK_VALUE.Checked = True
        Me.CHK_VALUE.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHK_VALUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_VALUE.Location = New System.Drawing.Point(736, 512)
        Me.CHK_VALUE.Name = "CHK_VALUE"
        Me.CHK_VALUE.Size = New System.Drawing.Size(80, 24)
        Me.CHK_VALUE.TabIndex = 450
        Me.CHK_VALUE.Text = "VALUE"
        '
        'CHK_QTY
        '
        Me.CHK_QTY.BackgroundImage = CType(resources.GetObject("CHK_QTY.BackgroundImage"), System.Drawing.Image)
        Me.CHK_QTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_QTY.Location = New System.Drawing.Point(832, 512)
        Me.CHK_QTY.Name = "CHK_QTY"
        Me.CHK_QTY.Size = New System.Drawing.Size(80, 24)
        Me.CHK_QTY.TabIndex = 451
        Me.CHK_QTY.Text = "QTY"
        '
        'frmStockSummary
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1016, 709)
        Me.ControlBox = False
        Me.Controls.Add(Me.CHK_QTY)
        Me.Controls.Add(Me.CHK_VALUE)
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
        Me.KeyPreview = True
        Me.Name = "frmStockSummary"
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
        sqlstring = "SELECT ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(GROUPDESC,'') AS GROUPDESC FROM INVENTORYGROUPMASTER ORDER BY GROUPCODE  "
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

    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call FillStore()
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
    End Sub

    Private Sub Chklist_Groupdesc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chklist_Groupdesc.DoubleClick
        'Dim i, J As Integer
        'Dim sqlstring As String
        'For J = 0 To Chklist_Groupdesc.Items.Count - 1
        '    If Chklist_Groupdesc.GetItemChecked(J) = True Then
        '        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
        '        sqlstring = sqlstring & " WHERE I.GROUPNAME IN ("
        '        For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        '            sqlstring = sqlstring & " '" & Chklist_Groupdesc.CheckedItems(i) & "', "
        '        Next
        '        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '        sqlstring = sqlstring & ")"
        '        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        '        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
        '            Chklist_Itemdetails.Items.Clear()
        '            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
        '                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
        '                    Chklist_Itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
        '                End With
        '            Next i
        '        End If
        '        Chklist_Itemdetails.Sorted = True
        '    End If
        'Next

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
        Chklist_Itemdetails.Sorted = True
    End Sub

    Private Sub Chklist_Groupdesc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chklist_Groupdesc.SelectedIndexChanged
        'Dim i, J As Integer
        'Dim sqlstring As String
        'For J = 0 To Chklist_Groupdesc.Items.Count - 1
        '    If Chklist_Groupdesc.GetItemChecked(J) = True Then
        '        sqlstring = "SELECT DISTINCT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME FROM INVENTORYITEMMASTER AS I "
        '        sqlstring = sqlstring & " WHERE I.GROUPNAME IN ("
        '        For i = 0 To Chklist_Groupdesc.CheckedItems.Count - 1
        '            sqlstring = sqlstring & " '" & Chklist_Groupdesc.CheckedItems(i) & "', "
        '        Next
        '        sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
        '        sqlstring = sqlstring & ")"
        '        gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        '        If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
        '            Chklist_Itemdetails.Items.Clear()
        '            For i = 0 To gdataset.Tables("INVENTORYITEMMASTER").Rows.Count - 1
        '                With gdataset.Tables("INVENTORYITEMMASTER").Rows(i)
        '                    Chklist_Itemdetails.Items.Add(Trim(.Item("ITEMCODE") & "-->" & .Item("ITEMNAME")))
        '                End With
        '            Next i
        '        End If
        '        Chklist_Itemdetails.Sorted = True
        '    End If
        'Next

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
        Chklist_Itemdetails.Sorted = True

    End Sub

    Private Sub Chk_SelectAllGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllGroup.CheckedChanged
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
        Call FillStore()
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
    End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
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
            If MsgBox("Click YES for 'Windows View' or NO for 'TEXT View'", MsgBoxStyle.YesNo, "STOCK SUMMARY") = MsgBoxResult.Yes Then
                Call StkSummary_crystal()
            Else
                Call ViewStocksummary()
            End If
        End If
    End Sub
    Public Sub ViewStocksummary()
        Try
            Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
            Dim Boolupdate As Boolean
            Dim I As Integer
            Storecode = "" : Clsquantity = "" : I = 0
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


            sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(cbo_Storelocation.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOREMASTER")
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
                '---------------------- EXECUTE STORE PROCEDURE --------------------------'
                gconnection.openConnection()

                gcommand = New SqlCommand("CP_STOCKSUMMARY2", gconnection.Myconn)
                gcommand.CommandTimeout = 10000000
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

            sqlstring = " SELECT ISNULL(S.ITEMCODE,'') AS ITEMCODE,ISNULL(S.ITEMNAME,'') AS ITEMDESC,ISNULL(S.UOM,'') AS UOM, ISNULL(I.GROUPNAME,'') AS GROUPNAME,"
            sqlstring = sqlstring & "SUM(ISNULL(S.OPQTY,0.000)) AS OPQTY,SUM(ISNULL(S.OPVAL,0.000)) AS OPVAL, SUM(ISNULL(S.RCVQTY,0.000)) AS RCVQTY,SUM(ISNULL(S.RCVVAL,0.000)) AS RCVVAL,SUM(ISNULL(S.RCVQTY1,0.000)) AS RCVQTY1,SUM(ISNULL(S.RCVVAL1,0.000)) AS RCVVAL1,SUM(ISNULL(S.RCVQTY2,0.000)) AS RCVQTY2,SUM(ISNULL(S.RCVVAL2,0.000)) AS RCVVAL2,SUM(ISNULL(S.RCVQTY3,0.000)) AS RCVQTY3,SUM(ISNULL(S.RCVVAL3,0.000)) AS RCVVAL3,SUM(ISNULL(S.ISSQTY,0.000)) AS ISSQTY,SUM(ISNULL(S.ISSVAL,0.000)) AS ISSVAL,SUM(ISNULL(S.ISSQTY1,0.000)) AS ISSQTY1,SUM(ISNULL(S.ISSVAL1,0.000)) AS ISSVAL1,SUM(ISNULL(S.ISSQTY2,0.000)) AS ISSQTY2,SUM(ISNULL(S.ISSVAL2,0.000)) AS ISSVAL2,SUM(ISNULL(S.ISSQTY3,0.000)) AS ISSQTY3,SUM(ISNULL(S.ISSVAL3,0.000)) AS ISSVAL3,SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSVAL,0.00)) AS VALUE,SUM(ISNULL(S.DISPQTY,0)) AS DISPQTY FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "
            If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE I.ITEMCODE=S.ITEMCODE AND S.ITEMCODE IN ("
                For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                    Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                    sqlstring = sqlstring & "'" & Itemcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ") and I.storecode=s.storecode "
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If CHK_ZEROQTY.Checked = False Then
                sqlstring = sqlstring & " And (OPQTY <> 0 OR RCVQTY <> 0 OR ISSQTY <> 0)"
            End If
            sqlstring = sqlstring & " GROUP BY ISNULL(S.ITEMCODE,''),ISNULL(S.ITEMNAME,''),ISNULL(S.UOM,''), ISNULL(I.GROUPNAME,'') ORDER BY I.GROUPNAME,S.ITEMDESC"
            Dim heading() As String = {"STOCK SUMMARY" & "[ " & Trim(cbo_Storelocation.Text) & " ]"}

            Dim ObjSTOCKSummary As New rptStockSummary
            If CHK_VALUE.Checked = True Then
                
                    ObjSTOCKSummary.Reportdetails_Value(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)

            ElseIf CHK_QTY.Checked Then
                ObjSTOCKSummary.Reportdetails_Qty(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            Else
                ObjSTOCKSummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
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


            sqlstring = " SELECT ISNULL(STORECODE,'') AS STORECODE FROM STOREMASTER WHERE STOREDESC = '" & Trim(cbo_Storelocation.Text) & "'"
            gconnection.getDataSet(sqlstring, "STOREMASTER")
            If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
                Storecode = gdataset.Tables("STOREMASTER").Rows(0).Item("STORECODE")
                '---------------------- EXECUTE STORE PROCEDURE --------------------------'
                gconnection.openConnection()

                gcommand = New SqlCommand("CP_STOCKSUMMARY2", gconnection.Myconn)
                gcommand.CommandTimeout = 10000000
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
            sqlstring = sqlstring & "SUM(ISNULL(S.OPQTY,0.000)) AS OPQTY,SUM(ISNULL(S.OPVAL,0.000)) AS OPVAL, SUM(ISNULL(S.RCVQTY,0.000)) AS RCVQTY,SUM(ISNULL(S.RCVVAL,0.000)) AS RCVVAL,SUM(ISNULL(S.RCVQTY1,0.000)) AS RCVQTY1,SUM(ISNULL(S.RCVVAL1,0.000)) AS RCVVAL1,SUM(ISNULL(S.RCVQTY2,0.000)) AS RCVQTY2,SUM(ISNULL(S.RCVVAL2,0.000)) AS RCVVAL2,SUM(ISNULL(S.RCVQTY3,0.000)) AS RCVQTY3,SUM(ISNULL(S.RCVVAL3,0.000)) AS RCVVAL3,SUM(ISNULL(S.ISSQTY,0.000)) AS ISSQTY,SUM(ISNULL(S.ISSVAL,0.000)) AS ISSVAL,SUM(ISNULL(S.ISSQTY1,0.000)) AS ISSQTY1,SUM(ISNULL(S.ISSVAL1,0.000)) AS ISSVAL1,SUM(ISNULL(S.ISSQTY2,0.000)) AS ISSQTY2,SUM(ISNULL(S.ISSVAL2,0.000)) AS ISSVAL2,SUM(ISNULL(S.ISSQTY3,0.000)) AS ISSQTY3,SUM(ISNULL(S.ISSVAL3,0.000)) AS ISSVAL3,SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSRATE,0.00)) CLSRATE, SUM(ISNULL(S.CLSVAL,0.00)) AS VALUE,SUM(ISNULL(S.DISPQTY,0)) AS DISPQTY FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "
            If Chklist_Itemdetails.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE I.ITEMCODE=S.ITEMCODE AND S.ITEMCODE IN ("
                For I = 0 To Chklist_Itemdetails.CheckedItems.Count - 1
                    Itemcode = Split(Chklist_Itemdetails.CheckedItems(I), "-->")
                    sqlstring = sqlstring & "'" & Itemcode(0) & "', "
                Next
                sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                sqlstring = sqlstring & ") and I.storecode=s.storecode "
            Else
                MessageBox.Show("Select the Item Code(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If CHK_ZEROQTY.Checked = False Then
                sqlstring = sqlstring & " And (OPQTY <> 0 OR RCVQTY <> 0 OR ISSQTY <> 0)"
            End If
            sqlstring = sqlstring & " GROUP BY ISNULL(S.ITEMCODE,''),ISNULL(S.ITEMNAME,''),ISNULL(S.UOM,''), ISNULL(I.GROUPNAME,'') ORDER BY I.GROUPNAME,S.ITEMNAME"


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
            rViewer.Show()

        Catch ex As Exception

        End Try
    End Sub

End Class
