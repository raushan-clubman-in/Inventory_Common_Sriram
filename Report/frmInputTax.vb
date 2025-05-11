Imports System.Data.SqlClient
Public Class InputTax
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtp_Fromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_Todate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents Chk_SelectAllCredit As System.Windows.Forms.CheckBox
    Friend WithEvents chklst_Credit As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Chk_SelectAllDebit As System.Windows.Forms.CheckBox
    Friend WithEvents chklst_Debit As System.Windows.Forms.CheckedListBox
    Friend WithEvents grp_SalebillChecklist As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents txt_Vat As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Vat As System.Windows.Forms.Label
    Friend WithEvents CHK_FIRST As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_SECOND As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InputTax))
        Me.lbl_Heading = New System.Windows.Forms.Label
        Me.Cmd_Print = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.frmbut = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Chk_SelectAllCredit = New System.Windows.Forms.CheckBox
        Me.chklst_Credit = New System.Windows.Forms.CheckedListBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.grp_SalebillChecklist = New System.Windows.Forms.GroupBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lbl_Wait = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtp_Fromdate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtp_Todate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Chk_SelectAllDebit = New System.Windows.Forms.CheckBox
        Me.chklst_Debit = New System.Windows.Forms.CheckedListBox
        Me.txt_Vat = New System.Windows.Forms.TextBox
        Me.lbl_Vat = New System.Windows.Forms.Label
        Me.CHK_FIRST = New System.Windows.Forms.CheckBox
        Me.CHK_SECOND = New System.Windows.Forms.CheckBox
        Me.GroupBox3.SuspendLayout()
        Me.grp_SalebillChecklist.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(352, 16)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(144, 31)
        Me.lbl_Heading.TabIndex = 8
        Me.lbl_Heading.Text = "INPUT TAX"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.White
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
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Maroon
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(344, 24)
        Me.Label4.TabIndex = 423
        Me.Label4.Text = "CREDIT LEDGER:"
        '
        'Chk_SelectAllCredit
        '
        Me.Chk_SelectAllCredit.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Chk_SelectAllCredit.Location = New System.Drawing.Point(16, 48)
        Me.Chk_SelectAllCredit.Name = "Chk_SelectAllCredit"
        Me.Chk_SelectAllCredit.Size = New System.Drawing.Size(136, 24)
        Me.Chk_SelectAllCredit.TabIndex = 422
        Me.Chk_SelectAllCredit.Text = "SELECT ALL "
        '
        'chklst_Credit
        '
        Me.chklst_Credit.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklst_Credit.Location = New System.Drawing.Point(16, 80)
        Me.chklst_Credit.Name = "chklst_Credit"
        Me.chklst_Credit.Size = New System.Drawing.Size(344, 361)
        Me.chklst_Credit.TabIndex = 421
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.grp_SalebillChecklist)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtp_Fromdate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.dtp_Todate)
        Me.GroupBox3.Location = New System.Drawing.Point(56, 512)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(712, 64)
        Me.GroupBox3.TabIndex = 425
        Me.GroupBox3.TabStop = False
        '
        'grp_SalebillChecklist
        '
        Me.grp_SalebillChecklist.BackgroundImage = CType(resources.GetObject("grp_SalebillChecklist.BackgroundImage"), System.Drawing.Image)
        Me.grp_SalebillChecklist.Controls.Add(Me.ProgressBar1)
        Me.grp_SalebillChecklist.Controls.Add(Me.lbl_Wait)
        Me.grp_SalebillChecklist.Controls.Add(Me.Label1)
        Me.grp_SalebillChecklist.Location = New System.Drawing.Point(0, -8)
        Me.grp_SalebillChecklist.Name = "grp_SalebillChecklist"
        Me.grp_SalebillChecklist.Size = New System.Drawing.Size(712, 64)
        Me.grp_SalebillChecklist.TabIndex = 441
        Me.grp_SalebillChecklist.TabStop = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 24)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(696, 32)
        Me.ProgressBar1.TabIndex = 0
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
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(392, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(344, 24)
        Me.Label2.TabIndex = 429
        Me.Label2.Text = "DEBIT LEDGER:"
        '
        'Chk_SelectAllDebit
        '
        Me.Chk_SelectAllDebit.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SelectAllDebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Chk_SelectAllDebit.Location = New System.Drawing.Point(392, 48)
        Me.Chk_SelectAllDebit.Name = "Chk_SelectAllDebit"
        Me.Chk_SelectAllDebit.Size = New System.Drawing.Size(136, 24)
        Me.Chk_SelectAllDebit.TabIndex = 428
        Me.Chk_SelectAllDebit.Text = "SELECT ALL "
        '
        'chklst_Debit
        '
        Me.chklst_Debit.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklst_Debit.Location = New System.Drawing.Point(392, 80)
        Me.chklst_Debit.Name = "chklst_Debit"
        Me.chklst_Debit.Size = New System.Drawing.Size(344, 361)
        Me.chklst_Debit.TabIndex = 427
        '
        'txt_Vat
        '
        Me.txt_Vat.BackColor = System.Drawing.Color.White
        Me.txt_Vat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Vat.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Vat.Location = New System.Drawing.Point(400, 464)
        Me.txt_Vat.MaxLength = 5
        Me.txt_Vat.Name = "txt_Vat"
        Me.txt_Vat.Size = New System.Drawing.Size(80, 21)
        Me.txt_Vat.TabIndex = 430
        Me.txt_Vat.Text = ""
        Me.txt_Vat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_Vat
        '
        Me.lbl_Vat.AutoSize = True
        Me.lbl_Vat.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Vat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Vat.Location = New System.Drawing.Point(272, 464)
        Me.lbl_Vat.Name = "lbl_Vat"
        Me.lbl_Vat.Size = New System.Drawing.Size(106, 17)
        Me.lbl_Vat.TabIndex = 431
        Me.lbl_Vat.Text = "VAT Percenatge :"
        '
        'CHK_FIRST
        '
        Me.CHK_FIRST.BackColor = System.Drawing.Color.Transparent
        Me.CHK_FIRST.BackgroundImage = CType(resources.GetObject("CHK_FIRST.BackgroundImage"), System.Drawing.Image)
        Me.CHK_FIRST.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_FIRST.Location = New System.Drawing.Point(64, 480)
        Me.CHK_FIRST.Name = "CHK_FIRST"
        Me.CHK_FIRST.TabIndex = 453
        Me.CHK_FIRST.Text = "FIRST"
        '
        'CHK_SECOND
        '
        Me.CHK_SECOND.BackColor = System.Drawing.Color.Transparent
        Me.CHK_SECOND.BackgroundImage = CType(resources.GetObject("CHK_SECOND.BackgroundImage"), System.Drawing.Image)
        Me.CHK_SECOND.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_SECOND.Location = New System.Drawing.Point(656, 480)
        Me.CHK_SECOND.Name = "CHK_SECOND"
        Me.CHK_SECOND.TabIndex = 454
        Me.CHK_SECOND.Text = "SECOND"
        '
        'InputTax
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(822, 676)
        Me.Controls.Add(Me.CHK_SECOND)
        Me.Controls.Add(Me.CHK_FIRST)
        Me.Controls.Add(Me.lbl_Vat)
        Me.Controls.Add(Me.txt_Vat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Chk_SelectAllDebit)
        Me.Controls.Add(Me.chklst_Debit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Chk_SelectAllCredit)
        Me.Controls.Add(Me.chklst_Credit)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.frmbut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "InputTax"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORT [ INPUT TAX REPORT]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.grp_SalebillChecklist.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim gconnection As New GlobalClass
    Dim sqlstring As String
    Private Sub inputtax_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
            If chklst_Credit.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If chklst_Debit.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Checkdaterangevalidate(Format(dtp_Fromdate.Value, "dd/MMM/yyyy"), Format(dtp_Todate.Value, "dd/MMM/yyyy"))
            If chkdatevalidate = False Then Exit Sub
            gPrint = False
            grp_SalebillChecklist.Top = 512
            grp_SalebillChecklist.Left = 50
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
            If chklst_Credit.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If chklst_Debit.CheckedItems.Count = 0 Then
                MessageBox.Show("Select the Group Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Checkdaterangevalidate(dtp_Fromdate.Value, dtp_Todate.Value)
            If chkdatevalidate = False Then Exit Sub
            gPrint = True
            grp_SalebillChecklist.Top = 512
            grp_SalebillChecklist.Left = 50
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
            If CHK_FIRST.Checked = True Then
                sqlstring = " SELECT * FROM INV_VIEW_INPUTTAX "
                sqlstring = sqlstring & " WHERE GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                If Trim(txt_Vat.Text) <> "" Then
                    sqlstring = sqlstring & " AND TPER=" & Val(txt_Vat.Text)
                End If
                If chklst_Credit.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & "  AND CRCODE IN ("
                    For i = 0 To chklst_Credit.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Credit.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If


                If chklst_Debit.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & "  AND DRCODE IN ("
                    For i = 0 To chklst_Debit.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Debit.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS"
            Else
                sqlstring = " SELECT * FROM INV_VIEW_INPUTTAX_SECOND "
                sqlstring = sqlstring & " WHERE GRNDATE BETWEEN"
                sqlstring = sqlstring & " '" & Format(dtp_Fromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtp_Todate.Value, "dd-MMM-yyyy") & "'"
                If Trim(txt_Vat.Text) <> "" Then
                    sqlstring = sqlstring & " AND TPER=" & Val(txt_Vat.Text)
                End If
                If chklst_Credit.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & "  AND CRCODE IN ("
                    For i = 0 To chklst_Credit.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Credit.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If


                If chklst_Debit.CheckedItems.Count <> 0 Then
                    sqlstring = sqlstring & "  AND DRCODE IN ("
                    For i = 0 To chklst_Debit.CheckedItems.Count - 1
                        SUPPLIERNAME = Split(chklst_Debit.CheckedItems(i), "-->")
                        sqlstring = sqlstring & " '" & Trim(SUPPLIERNAME(0)) & "', "
                    Next
                    sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
                    sqlstring = sqlstring & ")"
                Else
                    MessageBox.Show("Select the Supplier Name(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
                sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS"
            End If
            Dim heading() As String = {"INPUT TAX REPORT"}
            If CHK_FIRST.Checked = True Then
                Dim ObjStockPurchaseregistersummary As New rptInputtax
                ObjStockPurchaseregistersummary.Reportdetails(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
            Else
                Dim ObjStockPurchaseregistersummary As New rptInputtax
                ObjStockPurchaseregistersummary.Reportdetails_SECOND(sqlstring, heading, dtp_Fromdate.Value, dtp_Todate.Value)
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
                Call Viewsuppliernamewise()
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

    Private Sub inputtax_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call Fillcredit()
            Call FillDEBIT()
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
    Private Sub Fillcredit()
        Try
            Dim i As Integer
            chklst_Credit.Items.Clear()

            sqlstring = "SELECT SLCODE,SLNAME FROM accountssubledgermaster WHERE ISNULL(FREEZEFLAG,'')<>'Y' AND ACCODE = '" & Trim(gCreditors) & "'"
            gconnection.getDataSet(sqlstring, "accountsglaccountmaster")
            If gdataset.Tables("accountsglaccountmaster").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("accountsglaccountmaster").Rows.Count - 1
                    With gdataset.Tables("accountsglaccountmaster").Rows(i)
                        chklst_Credit.Items.Add(Trim(.Item("SLCODE")) & "-->" & Trim(.Item("SLNAME")))
                    End With
                Next i
            End If

            chklst_Credit.Sorted = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillDEBIT()
        Try
            Dim i As Integer
            chklst_Debit.Items.Clear()
            sqlstring = "SELECT accode,acdesc FROM accountsglaccountmaster WHERE ISNULL(FREEZEFLAG,'')<>'Y'"
            gconnection.getDataSet(sqlstring, "accountsglaccountmaster")
            If gdataset.Tables("accountsglaccountmaster").Rows.Count - 1 >= 0 Then
                For i = 0 To gdataset.Tables("accountsglaccountmaster").Rows.Count - 1
                    With gdataset.Tables("accountsglaccountmaster").Rows(i)
                        chklst_Debit.Items.Add(Trim(.Item("ACCODE")) & "-->" & Trim(.Item("ACDESC")))
                    End With
                Next i
            End If
            chklst_Debit.Sorted = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub opt_Purchasedetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Then
                Cmd_View.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub opt_Purchasesummary_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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
            chklst_Credit.Items.Clear()
            chklst_Debit.Items.Clear()
            grp_SalebillChecklist.Top = 1000
            Chk_SelectAllCredit.Checked = False
            Call Fillcredit()
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            dtp_Fromdate.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Chk_SelectAllCredit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllCredit.CheckedChanged
        Try
            Dim i As Integer
            If Chk_SelectAllCredit.Checked = True Then
                For i = 0 To chklst_Credit.Items.Count - 1
                    chklst_Credit.SetItemChecked(i, True)
                Next
            Else
                For i = 0 To chklst_Credit.Items.Count - 1
                    chklst_Credit.SetItemChecked(i, False)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Chk_SelectAllDebit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SelectAllDebit.CheckedChanged
        Try
            Dim i As Integer
            If Chk_SelectAllDebit.Checked = True Then
                For i = 0 To chklst_Debit.Items.Count - 1
                    chklst_Debit.SetItemChecked(i, True)
                Next
            Else
                For i = 0 To chklst_Debit.Items.Count - 1
                    chklst_Debit.SetItemChecked(i, False)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Chk_SelectAllCredit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk_SelectAllCredit.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                chklst_Credit.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Chk_SelectAllDebit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Chk_SelectAllDebit.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                chklst_Debit.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub txt_Vat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Vat.TextChanged

    End Sub
End Class
