Imports System.Data.SqlClient
Public Class FRM_PURCHASE
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllSupplier As System.Windows.Forms.CheckBox
    Friend WithEvents dtp_Fromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Todate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents chklst_Group As System.Windows.Forms.CheckedListBox
    Friend WithEvents chklst_Supplier As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckSupplier As System.Windows.Forms.CheckBox
    Public WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents CHK_SUM As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_ITEM As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FRM_PURCHASE))
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
        Me.chklst_Group = New System.Windows.Forms.CheckedListBox
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox
        Me.lbl_Wait = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.dtp_Fromdate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtp_Todate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chklst_Supplier = New System.Windows.Forms.CheckedListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckSupplier = New System.Windows.Forms.CheckBox
        Me.CHK_SUM = New System.Windows.Forms.CheckBox
        Me.CHK_ITEM = New System.Windows.Forms.CheckBox
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(272, 16)
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
        Me.Cmd_Print.Location = New System.Drawing.Point(416, 600)
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
        Me.Cmd_View.Location = New System.Drawing.Point(272, 600)
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(568, 600)
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(128, 600)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 4
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Location = New System.Drawing.Point(56, 584)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(712, 56)
        Me.frmbut.TabIndex = 13
        Me.frmbut.TabStop = False
        '
        'opt_Purchasedetails
        '
        Me.opt_Purchasedetails.BackColor = System.Drawing.Color.Transparent
        Me.opt_Purchasedetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.opt_Purchasedetails.Location = New System.Drawing.Point(232, 488)
        Me.opt_Purchasedetails.Name = "opt_Purchasedetails"
        Me.opt_Purchasedetails.Size = New System.Drawing.Size(128, 16)
        Me.opt_Purchasedetails.TabIndex = 2
        Me.opt_Purchasedetails.Text = "DETAILS"
        '
        'opt_Purchasesummary
        '
        Me.opt_Purchasesummary.BackColor = System.Drawing.Color.Transparent
        Me.opt_Purchasesummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.opt_Purchasesummary.Location = New System.Drawing.Point(360, 488)
        Me.opt_Purchasesummary.Name = "opt_Purchasesummary"
        Me.opt_Purchasesummary.Size = New System.Drawing.Size(120, 16)
        Me.opt_Purchasesummary.TabIndex = 3
        Me.opt_Purchasesummary.Text = "SUMMARY"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Maroon
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(48, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(344, 24)
        Me.Label4.TabIndex = 423
        Me.Label4.Text = "MODULE SELECTION :"
        '
        'Chk_SelectAllSupplier
        '
        Me.Chk_SelectAllSupplier.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Chk_SelectAllSupplier.Location = New System.Drawing.Point(56, 64)
        Me.Chk_SelectAllSupplier.Name = "Chk_SelectAllSupplier"
        Me.Chk_SelectAllSupplier.Size = New System.Drawing.Size(136, 24)
        Me.Chk_SelectAllSupplier.TabIndex = 422
        Me.Chk_SelectAllSupplier.Text = "SELECT ALL "
        '
        'chklst_Group
        '
        Me.chklst_Group.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklst_Group.Location = New System.Drawing.Point(48, 112)
        Me.chklst_Group.Name = "chklst_Group"
        Me.chklst_Group.Size = New System.Drawing.Size(344, 361)
        Me.chklst_Group.TabIndex = 421
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.BackgroundImage = CType(resources.GetObject("grp_SalebillChecklist.BackgroundImage"), System.Drawing.Image)
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(56, 512)
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
        Me.GroupBox3.Location = New System.Drawing.Point(56, 512)
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(200, 648)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(423, 18)
        Me.Label5.TabIndex = 426
        Me.Label5.Text = "Press F2 to select all / Press ENTER key to navigate"
        '
        'Timer1
        '
        '
        'chklst_Supplier
        '
        Me.chklst_Supplier.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklst_Supplier.Location = New System.Drawing.Point(432, 112)
        Me.chklst_Supplier.Name = "chklst_Supplier"
        Me.chklst_Supplier.Size = New System.Drawing.Size(344, 361)
        Me.chklst_Supplier.TabIndex = 427
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(432, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(344, 24)
        Me.Label2.TabIndex = 429
        Me.Label2.Text = "SUPPLIER SELECTION :"
        '
        'CheckSupplier
        '
        Me.CheckSupplier.BackColor = System.Drawing.Color.Transparent
        Me.CheckSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckSupplier.Location = New System.Drawing.Point(440, 64)
        Me.CheckSupplier.Name = "CheckSupplier"
        Me.CheckSupplier.Size = New System.Drawing.Size(136, 24)
        Me.CheckSupplier.TabIndex = 428
        Me.CheckSupplier.Text = "SELECT ALL "
        '
        'CHK_SUM
        '
        Me.CHK_SUM.BackColor = System.Drawing.Color.Transparent
        Me.CHK_SUM.BackgroundImage = CType(resources.GetObject("CHK_SUM.BackgroundImage"), System.Drawing.Image)
        Me.CHK_SUM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_SUM.Location = New System.Drawing.Point(496, 488)
        Me.CHK_SUM.Name = "CHK_SUM"
        Me.CHK_SUM.TabIndex = 451
        Me.CHK_SUM.Text = "PURC SUM"
        '
        'CHK_ITEM
        '
        Me.CHK_ITEM.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ITEM.BackgroundImage = CType(resources.GetObject("CHK_ITEM.BackgroundImage"), System.Drawing.Image)
        Me.CHK_ITEM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_ITEM.Location = New System.Drawing.Point(632, 488)
        Me.CHK_ITEM.Name = "CHK_ITEM"
        Me.CHK_ITEM.TabIndex = 452
        Me.CHK_ITEM.Text = "PURC ITEM"
        '
        'FRM_PURCHASE
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(822, 676)
        Me.Controls.Add(Me.CHK_ITEM)
        Me.Controls.Add(Me.CHK_SUM)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckSupplier)
        Me.Controls.Add(Me.chklst_Supplier)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.grp_SalebillChecklist)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Chk_SelectAllSupplier)
        Me.Controls.Add(Me.chklst_Group)
        Me.Controls.Add(Me.opt_Purchasesummary)
        Me.Controls.Add(Me.opt_Purchasedetails)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.frmbut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FRM_PURCHASE"
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

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Try
            If chklst_Group.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
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
            Me.Timer1.Interval = 100
            Me.Timer1.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        Try
            If chklst_Group.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
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
            Me.Timer1.Interval = 100
            Me.Timer1.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Viewsuppliernamewise()
        Try
            Dim sqlstring, SUPPLIERNAME() As String
            Dim i As Integer
            If opt_Purchasesummary.Checked = True Then
                sqlstring = " SELECT * FROM VIEWPURCHASEREGISTERSUMMARY "
                If chklst_Group.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE SUBSTRING(GRNDETAILS,5,3) IN (SELECT GROUPPREFIX FROM inventoryMODULEMASTER WHERE GROUPCODE IN ("
                    For i = 0 To chklst_Group.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Group.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & "))"
                Else
                    MessageBox.Show("Select the Group Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If chklst_Supplier.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " And SUPPLIERCODE IN ("
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
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMCODE  "
                Dim heading() As String = {"PURCHASE REGISTER "}
                Dim ObjStockPurchaseregistersummary As New rptPurchaseregistersummary
                ObjStockPurchaseregistersummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            Else
                opt_Purchasedetails.Checked = True
                sqlstring = " SELECT * FROM VIEWPURCHASEREGISTERSUMMARY "
                If chklst_Group.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE SUBSTRING(GRNDETAILS,5,3) IN (SELECT GROUPPREFIX FROM inventoryMODULEMASTER WHERE GROUPCODE IN ("
                    For i = 0 To chklst_Group.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Group.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & "))"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If chklst_Supplier.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " And SUPPLIERCODE IN ("
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
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME,ITEMCODE  "
                Dim heading() As String = {"PURCHASE REGISTER "}
                Dim ObjStockPurchaseregisterReport As New rptStockPurchaseregister
                ObjStockPurchaseregisterReport.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub ViewNIZAM()
        Try
            Dim sqlstring, SUPPLIERNAME() As String
            Dim i As Integer
            If CHK_SUM.Checked = True Then
                sqlstring = " SELECT * FROM INV_VIEW_GRNSUMMARY"
                If chklst_Group.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE SUBSTRING(GRNDETAILS,5,3) IN (SELECT GROUPPREFIX FROM inventoryMODULEMASTER WHERE GROUPCODE IN ("
                    For i = 0 To chklst_Group.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Group.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & "))"
                Else
                    MessageBox.Show("Select the Group Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                If chklst_Supplier.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " And SUPPLIERCODE IN ("
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
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME"
                Dim heading() As String = {"DAILY PURCHASE SUMMARY"}
                Dim ObjStockPurchaseregistersummary As New rptPurchasesummary_NIZAM
                ObjStockPurchaseregistersummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            Else
                opt_Purchasedetails.Checked = True
                sqlstring = " SELECT * FROM INV_VIEW_GRNITEM"
                If chklst_Group.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " WHERE SUBSTRING(GRNDETAILS,5,3) IN (SELECT GROUPPREFIX FROM inventoryMODULEMASTER WHERE GROUPCODE IN ("
                    For i = 0 To chklst_Group.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Group.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & "))"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                If chklst_Supplier.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & " And SUPPLIERCODE IN ("
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
                sqlstring = sqlstring & " AND GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                sqlstring = sqlstring & " ORDER BY ITEMCODE,GRNDATE,GRNDETAILS"
                Dim heading() As String = {"ITEMWISE PURCHASE REPORT "}
                Dim ObjStockPurchaseregisterReport As New rptPurchaseItemwise_NIZAM
                ObjStockPurchaseregisterReport.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If Me.ProgressBar1.Value > 0 And Me.ProgressBar1.Value < 100 Then
                Me.ProgressBar1.Value += 1
                Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
            Else
                Me.Timer1.Enabled = False
                Me.ProgressBar1.Value = 0
                Me.grp_SalebillChecklist.Top = 1000

                If CHK_SUM.Checked = False And CHK_ITEM.Checked = False Then
                    Call Viewsuppliernamewise()
                Else
                    Call ViewNIZAM()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub dtp_Fromdate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_Fromdate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                dtp_Todate.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub dtp_Todate_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtp_Todate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Cmd_View.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub frmPurchaseregister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call Fillsuppliername()
            Call Fillgroup()
            dtp_Fromdate.Value = Format(Now, "dd/MM/yyyy")
            dtp_Todate.Value = Format(Now, "dd/MM/yyyy")
            grp_SalebillChecklist.Top = 1000
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
    Private Sub Fillgroup()
        Try
            Dim i As Integer
            chklst_Group.Items.Clear()
            sqlstring = "SELECT DISTINCT ISNULL(GROUPCODE,'') AS SLCODE,ISNULL(GROUPdesc,'') AS SLNAME FROM inventoryMODULEmaster "
            gconnection.getDataSet(sqlstring, "SUBLEDGERMASTER")
            If gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1
                    With gdataset.Tables("SUBLEDGERMASTER").Rows(i)
                        chklst_Group.Items.Add(Trim(.Item("SLCODE")) & "-->" & Trim(.Item("SLNAME")))
                    End With
                Next i
            End If
            chklst_Group.Sorted = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Fillsuppliername()
        Try
            Dim i As Integer
            chklst_Supplier.Items.Clear()
            sqlstring = "SELECT DISTINCT ISNULL(SLCODE,'') AS SLCODE,ISNULL(SLNAME,'') AS SLNAME FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(gCreditors) & "' AND ISNULL(FREeZEFLAG,'') <> 'Y'"
            gconnection.getDataSet(sqlstring, "SUBLEDGERMASTER")
            If gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("SUBLEDGERMASTER").Rows.Count - 1
                    With gdataset.Tables("SUBLEDGERMASTER").Rows(i)
                        chklst_Supplier.Items.Add(Trim(.Item("SLCODE")) & "-->" & Trim(.Item("SLNAME")))
                    End With
                Next i
            End If
            chklst_Supplier.Sorted = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub opt_Purchasedetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles opt_Purchasedetails.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Cmd_View.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub opt_Purchasesummary_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles opt_Purchasesummary.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Cmd_View.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Try
            chklst_Group.Items.Clear()
            chklst_Supplier.Items.Clear()
            grp_SalebillChecklist.Top = 1000
            opt_Purchasedetails.Checked = True
            Chk_SelectAllSupplier.Checked = False
            CheckSupplier.Checked = False
            Call Fillgroup()
            Call Fillsuppliername()
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            dtp_Fromdate.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Chk_SelectAllSupplier_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chk_SelectAllSupplier.CheckedChanged
        Try
            Dim i As Integer
            If Chk_SelectAllSupplier.Checked = True Then
                For i = 0 To chklst_Group.Items.Count - 1
                    chklst_Group.SetItemChecked(i, True)
                Next
            Else
                For i = 0 To chklst_Group.Items.Count - 1
                    chklst_Group.SetItemChecked(i, False)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Chk_SelectAllSupplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk_SelectAllSupplier.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                chklst_Group.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub CheckSupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckSupplier.CheckedChanged
        Try
            Dim i As Integer
            If CheckSupplier.Checked = True Then
                For i = 0 To chklst_Supplier.Items.Count - 1
                    chklst_Supplier.SetItemChecked(i, True)
                Next
            Else
                For i = 0 To chklst_Supplier.Items.Count - 1
                    chklst_Supplier.SetItemChecked(i, False)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub CheckSupplier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckSupplier.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                opt_Purchasedetails.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class
