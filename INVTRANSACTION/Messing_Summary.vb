Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class Messing_Summary
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents cmd_rpt As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTN_OLDSTOCK As System.Windows.Forms.Button
    Friend WithEvents CMB_STORECODE As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_NEWSTOCK As System.Windows.Forms.TextBox
    Friend WithEvents BTN_NEWSTOCK As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_PURCHASE As System.Windows.Forms.TextBox
    Friend WithEvents BTN_PURCHASE As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXT_ISSUE As System.Windows.Forms.TextBox
    Friend WithEvents BTN_ISSUE As System.Windows.Forms.Button
    Friend WithEvents TXT_EXPENDITURE As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_STRENGTH As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BTN_CALCULATION As System.Windows.Forms.Button
    Friend WithEvents TXT_MESSING As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXT_DAMAGE As System.Windows.Forms.TextBox
    Friend WithEvents BTN_DAMAGE As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TXT_DOCNO As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmd_DOCNOhelp As System.Windows.Forms.Button
    Friend WithEvents DTP_MONTH As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TXT_OLDSTOCK As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMD_TDAMOUNT As System.Windows.Forms.Button
    Friend WithEvents CMD_WASTAGEFOOD As System.Windows.Forms.Button
    Friend WithEvents TXT_TDAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXT_WASTAGEFOOD As System.Windows.Forms.TextBox
    Friend WithEvents TXT_TOTAL As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXT_TOTALEXP As System.Windows.Forms.TextBox
    Friend WithEvents BTN_TOTALEXP As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PURCHASE_VIEW As System.Windows.Forms.Button
    Friend WithEvents txt_totalE As System.Windows.Forms.TextBox
    Friend WithEvents cmd_totale As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmd_viewns As System.Windows.Forms.Button
    Friend WithEvents txt_servant_total As System.Windows.Forms.TextBox
    Friend WithEvents servant_total As System.Windows.Forms.Button
    Friend WithEvents cmd_view_collgfunc As System.Windows.Forms.Button
    Friend WithEvents cmd_viewemess As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Messing_Summary))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PURCHASE_VIEW = New System.Windows.Forms.Button()
        Me.TXT_OLDSTOCK = New System.Windows.Forms.TextBox()
        Me.BTN_OLDSTOCK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_PURCHASE = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXT_PURCHASE = New System.Windows.Forms.TextBox()
        Me.DTP_MONTH = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmd_DOCNOhelp = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TXT_DOCNO = New System.Windows.Forms.TextBox()
        Me.CMB_STORECODE = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.cmd_rpt = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmd_viewns = New System.Windows.Forms.Button()
        Me.TXT_NEWSTOCK = New System.Windows.Forms.TextBox()
        Me.BTN_NEWSTOCK = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmd_view_collgfunc = New System.Windows.Forms.Button()
        Me.cmd_viewemess = New System.Windows.Forms.Button()
        Me.txt_servant_total = New System.Windows.Forms.TextBox()
        Me.servant_total = New System.Windows.Forms.Button()
        Me.txt_totalE = New System.Windows.Forms.TextBox()
        Me.cmd_totale = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXT_TOTALEXP = New System.Windows.Forms.TextBox()
        Me.BTN_TOTALEXP = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXT_TOTAL = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMD_TDAMOUNT = New System.Windows.Forms.Button()
        Me.CMD_WASTAGEFOOD = New System.Windows.Forms.Button()
        Me.TXT_TDAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXT_WASTAGEFOOD = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_DAMAGE = New System.Windows.Forms.TextBox()
        Me.BTN_DAMAGE = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXT_EXPENDITURE = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXT_ISSUE = New System.Windows.Forms.TextBox()
        Me.BTN_ISSUE = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.BTN_CALCULATION = New System.Windows.Forms.Button()
        Me.TXT_MESSING = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXT_STRENGTH = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(302, 96)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(240, 27)
        Me.lbl_Heading.TabIndex = 9
        Me.lbl_Heading.Text = "MESSING SUMMARY"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.PURCHASE_VIEW)
        Me.GroupBox1.Controls.Add(Me.TXT_OLDSTOCK)
        Me.GroupBox1.Controls.Add(Me.BTN_OLDSTOCK)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BTN_PURCHASE)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TXT_PURCHASE)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(307, 241)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1034, 100)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'PURCHASE_VIEW
        '
        Me.PURCHASE_VIEW.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PURCHASE_VIEW.Location = New System.Drawing.Point(890, 58)
        Me.PURCHASE_VIEW.Name = "PURCHASE_VIEW"
        Me.PURCHASE_VIEW.Size = New System.Drawing.Size(120, 34)
        Me.PURCHASE_VIEW.TabIndex = 24
        Me.PURCHASE_VIEW.Text = "VIEW"
        Me.PURCHASE_VIEW.UseVisualStyleBackColor = True
        '
        'TXT_OLDSTOCK
        '
        Me.TXT_OLDSTOCK.Location = New System.Drawing.Point(706, 19)
        Me.TXT_OLDSTOCK.Name = "TXT_OLDSTOCK"
        Me.TXT_OLDSTOCK.Size = New System.Drawing.Size(160, 26)
        Me.TXT_OLDSTOCK.TabIndex = 8
        '
        'BTN_OLDSTOCK
        '
        Me.BTN_OLDSTOCK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_OLDSTOCK.Location = New System.Drawing.Point(470, 16)
        Me.BTN_OLDSTOCK.Name = "BTN_OLDSTOCK"
        Me.BTN_OLDSTOCK.Size = New System.Drawing.Size(172, 34)
        Me.BTN_OLDSTOCK.TabIndex = 7
        Me.BTN_OLDSTOCK.Text = "OLD STOCK"
        Me.BTN_OLDSTOCK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LAST MONTH STOCK VALUE (A):-"
        '
        'BTN_PURCHASE
        '
        Me.BTN_PURCHASE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_PURCHASE.Location = New System.Drawing.Point(470, 58)
        Me.BTN_PURCHASE.Name = "BTN_PURCHASE"
        Me.BTN_PURCHASE.Size = New System.Drawing.Size(168, 34)
        Me.BTN_PURCHASE.TabIndex = 1
        Me.BTN_PURCHASE.Text = "PURCHASE"
        Me.BTN_PURCHASE.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(16, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(410, 22)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "PURCHASE DURING CURRENT MONTH (B):-"
        '
        'TXT_PURCHASE
        '
        Me.TXT_PURCHASE.Location = New System.Drawing.Point(709, 61)
        Me.TXT_PURCHASE.Name = "TXT_PURCHASE"
        Me.TXT_PURCHASE.Size = New System.Drawing.Size(160, 26)
        Me.TXT_PURCHASE.TabIndex = 2
        '
        'DTP_MONTH
        '
        Me.DTP_MONTH.CalendarFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_MONTH.CustomFormat = "MMMMM"
        Me.DTP_MONTH.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_MONTH.Location = New System.Drawing.Point(240, 28)
        Me.DTP_MONTH.Name = "DTP_MONTH"
        Me.DTP_MONTH.Size = New System.Drawing.Size(222, 26)
        Me.DTP_MONTH.TabIndex = 27
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(51, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(165, 21)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "SELECT MONTH:-"
        '
        'cmd_DOCNOhelp
        '
        Me.cmd_DOCNOhelp.Image = CType(resources.GetObject("cmd_DOCNOhelp.Image"), System.Drawing.Image)
        Me.cmd_DOCNOhelp.Location = New System.Drawing.Point(851, 20)
        Me.cmd_DOCNOhelp.Name = "cmd_DOCNOhelp"
        Me.cmd_DOCNOhelp.Size = New System.Drawing.Size(37, 38)
        Me.cmd_DOCNOhelp.TabIndex = 25
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(504, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 19)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "DOC NO:-"
        '
        'TXT_DOCNO
        '
        Me.TXT_DOCNO.Enabled = False
        Me.TXT_DOCNO.Location = New System.Drawing.Point(642, 26)
        Me.TXT_DOCNO.Name = "TXT_DOCNO"
        Me.TXT_DOCNO.Size = New System.Drawing.Size(160, 26)
        Me.TXT_DOCNO.TabIndex = 9
        '
        'CMB_STORECODE
        '
        Me.CMB_STORECODE.FormattingEnabled = True
        Me.CMB_STORECODE.Location = New System.Drawing.Point(243, 67)
        Me.CMB_STORECODE.Name = "CMB_STORECODE"
        Me.CMB_STORECODE.Size = New System.Drawing.Size(194, 28)
        Me.CMB_STORECODE.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(45, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 21)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "STORE CODE:-"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(330, 962)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(510, 36)
        Me.lbl_Freeze.TabIndex = 14
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Freeze.Visible = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = Global.Inventory.My.Resources.Resources._Exit
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(8, 399)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(214, 82)
        Me.Cmd_Exit.TabIndex = 8
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_auth.ForeColor = System.Drawing.Color.Black
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.Location = New System.Drawing.Point(10, 399)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(214, 82)
        Me.cmd_auth.TabIndex = 8
        Me.cmd_auth.Text = "Authorize"
        Me.cmd_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_auth.UseVisualStyleBackColor = False
        Me.cmd_auth.Visible = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = Global.Inventory.My.Resources.Resources.view
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(8, 218)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(214, 82)
        Me.Cmd_View.TabIndex = 7
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        Me.Cmd_View.Visible = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Image = Global.Inventory.My.Resources.Resources.Delete
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(8, 196)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(214, 82)
        Me.Cmd_Freeze.TabIndex = 6
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        Me.Cmd_Freeze.Visible = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = Global.Inventory.My.Resources.Resources.save
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(6, 110)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(215, 81)
        Me.Cmd_Add.TabIndex = 4
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = Global.Inventory.My.Resources.Resources.Clear
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(5, 18)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(214, 81)
        Me.Cmd_Clear.TabIndex = 5
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.Transparent
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Image = Global.Inventory.My.Resources.Resources.excel
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(6, 308)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(215, 82)
        Me.cmd_export.TabIndex = 16
        Me.cmd_export.Text = "Export"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        '
        'cmd_rpt
        '
        Me.cmd_rpt.BackColor = System.Drawing.Color.Transparent
        Me.cmd_rpt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_rpt.ForeColor = System.Drawing.Color.Black
        Me.cmd_rpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_rpt.Location = New System.Drawing.Point(11, 208)
        Me.cmd_rpt.Name = "cmd_rpt"
        Me.cmd_rpt.Size = New System.Drawing.Size(215, 81)
        Me.cmd_rpt.TabIndex = 467
        Me.cmd_rpt.Text = "Report"
        Me.cmd_rpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_rpt.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.cmd_rpt)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Controls.Add(Me.cmd_export)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.cmd_auth)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Location = New System.Drawing.Point(1366, 137)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(226, 496)
        Me.GroupBox2.TabIndex = 468
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cmd_viewns)
        Me.GroupBox3.Controls.Add(Me.TXT_NEWSTOCK)
        Me.GroupBox3.Controls.Add(Me.BTN_NEWSTOCK)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(307, 341)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1032, 65)
        Me.GroupBox3.TabIndex = 469
        Me.GroupBox3.TabStop = False
        '
        'cmd_viewns
        '
        Me.cmd_viewns.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_viewns.Location = New System.Drawing.Point(896, 18)
        Me.cmd_viewns.Name = "cmd_viewns"
        Me.cmd_viewns.Size = New System.Drawing.Size(115, 33)
        Me.cmd_viewns.TabIndex = 18
        Me.cmd_viewns.Text = "VIEW"
        Me.cmd_viewns.UseVisualStyleBackColor = True
        Me.cmd_viewns.Visible = False
        '
        'TXT_NEWSTOCK
        '
        Me.TXT_NEWSTOCK.Location = New System.Drawing.Point(707, 22)
        Me.TXT_NEWSTOCK.Name = "TXT_NEWSTOCK"
        Me.TXT_NEWSTOCK.Size = New System.Drawing.Size(160, 26)
        Me.TXT_NEWSTOCK.TabIndex = 17
        '
        'BTN_NEWSTOCK
        '
        Me.BTN_NEWSTOCK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BTN_NEWSTOCK.Location = New System.Drawing.Point(467, 16)
        Me.BTN_NEWSTOCK.Name = "BTN_NEWSTOCK"
        Me.BTN_NEWSTOCK.Size = New System.Drawing.Size(175, 34)
        Me.BTN_NEWSTOCK.TabIndex = 16
        Me.BTN_NEWSTOCK.Text = "CLOSING STOCK"
        Me.BTN_NEWSTOCK.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 9.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(18, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(295, 23)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "CURRENT MONTH STOCK VALUE (C):-"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cmd_view_collgfunc)
        Me.GroupBox4.Controls.Add(Me.cmd_viewemess)
        Me.GroupBox4.Controls.Add(Me.txt_servant_total)
        Me.GroupBox4.Controls.Add(Me.servant_total)
        Me.GroupBox4.Controls.Add(Me.txt_totalE)
        Me.GroupBox4.Controls.Add(Me.cmd_totale)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.TXT_TOTALEXP)
        Me.GroupBox4.Controls.Add(Me.BTN_TOTALEXP)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.TXT_TOTAL)
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.CMD_TDAMOUNT)
        Me.GroupBox4.Controls.Add(Me.CMD_WASTAGEFOOD)
        Me.GroupBox4.Controls.Add(Me.TXT_TDAMOUNT)
        Me.GroupBox4.Controls.Add(Me.TXT_WASTAGEFOOD)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.TXT_DAMAGE)
        Me.GroupBox4.Controls.Add(Me.BTN_DAMAGE)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.TXT_EXPENDITURE)
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.TXT_ISSUE)
        Me.GroupBox4.Controls.Add(Me.BTN_ISSUE)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Location = New System.Drawing.Point(307, 409)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1032, 347)
        Me.GroupBox4.TabIndex = 470
        Me.GroupBox4.TabStop = False
        '
        'cmd_view_collgfunc
        '
        Me.cmd_view_collgfunc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_view_collgfunc.Location = New System.Drawing.Point(896, 105)
        Me.cmd_view_collgfunc.Name = "cmd_view_collgfunc"
        Me.cmd_view_collgfunc.Size = New System.Drawing.Size(115, 34)
        Me.cmd_view_collgfunc.TabIndex = 30
        Me.cmd_view_collgfunc.Text = "VIEW"
        Me.cmd_view_collgfunc.UseVisualStyleBackColor = True
        '
        'cmd_viewemess
        '
        Me.cmd_viewemess.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_viewemess.Location = New System.Drawing.Point(896, 56)
        Me.cmd_viewemess.Name = "cmd_viewemess"
        Me.cmd_viewemess.Size = New System.Drawing.Size(115, 33)
        Me.cmd_viewemess.TabIndex = 29
        Me.cmd_viewemess.Text = "VIEW"
        Me.cmd_viewemess.UseVisualStyleBackColor = True
        '
        'txt_servant_total
        '
        Me.txt_servant_total.Location = New System.Drawing.Point(861, 143)
        Me.txt_servant_total.Name = "txt_servant_total"
        Me.txt_servant_total.Size = New System.Drawing.Size(149, 26)
        Me.txt_servant_total.TabIndex = 28
        '
        'servant_total
        '
        Me.servant_total.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.servant_total.Location = New System.Drawing.Point(662, 142)
        Me.servant_total.Name = "servant_total"
        Me.servant_total.Size = New System.Drawing.Size(172, 33)
        Me.servant_total.TabIndex = 27
        Me.servant_total.Text = "SERVANT RATION"
        Me.servant_total.UseVisualStyleBackColor = True
        '
        'txt_totalE
        '
        Me.txt_totalE.Location = New System.Drawing.Point(670, 267)
        Me.txt_totalE.Name = "txt_totalE"
        Me.txt_totalE.Size = New System.Drawing.Size(160, 26)
        Me.txt_totalE.TabIndex = 26
        '
        'cmd_totale
        '
        Me.cmd_totale.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_totale.Location = New System.Drawing.Point(470, 265)
        Me.cmd_totale.Name = "cmd_totale"
        Me.cmd_totale.Size = New System.Drawing.Size(170, 33)
        Me.cmd_totale.TabIndex = 25
        Me.cmd_totale.Text = "TOTAL E"
        Me.cmd_totale.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 267)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 21)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "TOTAL (E):-"
        '
        'TXT_TOTALEXP
        '
        Me.TXT_TOTALEXP.Location = New System.Drawing.Point(762, 307)
        Me.TXT_TOTALEXP.Name = "TXT_TOTALEXP"
        Me.TXT_TOTALEXP.Size = New System.Drawing.Size(160, 26)
        Me.TXT_TOTALEXP.TabIndex = 23
        '
        'BTN_TOTALEXP
        '
        Me.BTN_TOTALEXP.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_TOTALEXP.Location = New System.Drawing.Point(562, 304)
        Me.BTN_TOTALEXP.Name = "BTN_TOTALEXP"
        Me.BTN_TOTALEXP.Size = New System.Drawing.Size(169, 34)
        Me.BTN_TOTALEXP.TabIndex = 22
        Me.BTN_TOTALEXP.Text = "TOTAL EXP"
        Me.BTN_TOTALEXP.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 310)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(557, 21)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "TOTAL EXPENDITURE OF REGULAR DINING MEMBER(F=D-E):-"
        '
        'TXT_TOTAL
        '
        Me.TXT_TOTAL.Location = New System.Drawing.Point(672, 16)
        Me.TXT_TOTAL.Name = "TXT_TOTAL"
        Me.TXT_TOTAL.Size = New System.Drawing.Size(160, 26)
        Me.TXT_TOTAL.TabIndex = 20
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(472, 18)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(170, 33)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "TOTAL"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(365, 21)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "TOTAL AMOUNT RELEASED D=(A+B)-C:-"
        '
        'CMD_TDAMOUNT
        '
        Me.CMD_TDAMOUNT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_TDAMOUNT.Location = New System.Drawing.Point(472, 227)
        Me.CMD_TDAMOUNT.Name = "CMD_TDAMOUNT"
        Me.CMD_TDAMOUNT.Size = New System.Drawing.Size(166, 33)
        Me.CMD_TDAMOUNT.TabIndex = 17
        Me.CMD_TDAMOUNT.Text = "T D AMOUNT"
        Me.CMD_TDAMOUNT.UseVisualStyleBackColor = True
        '
        'CMD_WASTAGEFOOD
        '
        Me.CMD_WASTAGEFOOD.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_WASTAGEFOOD.Location = New System.Drawing.Point(472, 183)
        Me.CMD_WASTAGEFOOD.Name = "CMD_WASTAGEFOOD"
        Me.CMD_WASTAGEFOOD.Size = New System.Drawing.Size(170, 33)
        Me.CMD_WASTAGEFOOD.TabIndex = 16
        Me.CMD_WASTAGEFOOD.Text = "WASTAGE FOOD"
        Me.CMD_WASTAGEFOOD.UseVisualStyleBackColor = True
        '
        'TXT_TDAMOUNT
        '
        Me.TXT_TDAMOUNT.Location = New System.Drawing.Point(672, 227)
        Me.TXT_TDAMOUNT.Name = "TXT_TDAMOUNT"
        Me.TXT_TDAMOUNT.Size = New System.Drawing.Size(160, 26)
        Me.TXT_TDAMOUNT.TabIndex = 15
        '
        'TXT_WASTAGEFOOD
        '
        Me.TXT_WASTAGEFOOD.Location = New System.Drawing.Point(672, 186)
        Me.TXT_WASTAGEFOOD.Name = "TXT_WASTAGEFOOD"
        Me.TXT_WASTAGEFOOD.Size = New System.Drawing.Size(160, 26)
        Me.TXT_WASTAGEFOOD.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(8, 227)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(366, 22)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "TEMP DUTY AMOUNT RECOVERED IN "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(8, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 22)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "WASTAGE FOOD:-"
        '
        'TXT_DAMAGE
        '
        Me.TXT_DAMAGE.Location = New System.Drawing.Point(672, 102)
        Me.TXT_DAMAGE.Name = "TXT_DAMAGE"
        Me.TXT_DAMAGE.Size = New System.Drawing.Size(160, 26)
        Me.TXT_DAMAGE.TabIndex = 11
        '
        'BTN_DAMAGE
        '
        Me.BTN_DAMAGE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_DAMAGE.Location = New System.Drawing.Point(472, 99)
        Me.BTN_DAMAGE.Name = "BTN_DAMAGE"
        Me.BTN_DAMAGE.Size = New System.Drawing.Size(170, 34)
        Me.BTN_DAMAGE.TabIndex = 10
        Me.BTN_DAMAGE.Text = "CLG. FUNCTION"
        Me.BTN_DAMAGE.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(8, 105)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(233, 22)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "COLLEGE FUNCTIONS:-"
        '
        'TXT_EXPENDITURE
        '
        Me.TXT_EXPENDITURE.Location = New System.Drawing.Point(478, 142)
        Me.TXT_EXPENDITURE.Name = "TXT_EXPENDITURE"
        Me.TXT_EXPENDITURE.Size = New System.Drawing.Size(156, 26)
        Me.TXT_EXPENDITURE.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(342, 139)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 33)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "SERVANT RATION"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(3, 145)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(189, 22)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "SERVANT RATION:-"
        '
        'TXT_ISSUE
        '
        Me.TXT_ISSUE.Location = New System.Drawing.Point(672, 60)
        Me.TXT_ISSUE.Name = "TXT_ISSUE"
        Me.TXT_ISSUE.Size = New System.Drawing.Size(160, 26)
        Me.TXT_ISSUE.TabIndex = 5
        '
        'BTN_ISSUE
        '
        Me.BTN_ISSUE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ISSUE.Location = New System.Drawing.Point(469, 57)
        Me.BTN_ISSUE.Name = "BTN_ISSUE"
        Me.BTN_ISSUE.Size = New System.Drawing.Size(173, 34)
        Me.BTN_ISSUE.TabIndex = 4
        Me.BTN_ISSUE.Text = "EXTR. MESSING"
        Me.BTN_ISSUE.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(8, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(318, 22)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "EXTRA MESSING (incl) PARTIES:-"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.BTN_CALCULATION)
        Me.GroupBox5.Controls.Add(Me.TXT_MESSING)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.TXT_STRENGTH)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Location = New System.Drawing.Point(310, 756)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1029, 131)
        Me.GroupBox5.TabIndex = 471
        Me.GroupBox5.TabStop = False
        '
        'BTN_CALCULATION
        '
        Me.BTN_CALCULATION.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CALCULATION.Location = New System.Drawing.Point(485, 73)
        Me.BTN_CALCULATION.Name = "BTN_CALCULATION"
        Me.BTN_CALCULATION.Size = New System.Drawing.Size(201, 34)
        Me.BTN_CALCULATION.TabIndex = 12
        Me.BTN_CALCULATION.Text = "CALCULATION"
        Me.BTN_CALCULATION.UseVisualStyleBackColor = True
        '
        'TXT_MESSING
        '
        Me.TXT_MESSING.Enabled = False
        Me.TXT_MESSING.Location = New System.Drawing.Point(814, 76)
        Me.TXT_MESSING.Name = "TXT_MESSING"
        Me.TXT_MESSING.Size = New System.Drawing.Size(160, 26)
        Me.TXT_MESSING.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(19, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(277, 22)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "MESSING TO BE CHARGED:-"
        '
        'TXT_STRENGTH
        '
        Me.TXT_STRENGTH.Location = New System.Drawing.Point(814, 34)
        Me.TXT_STRENGTH.Name = "TXT_STRENGTH"
        Me.TXT_STRENGTH.Size = New System.Drawing.Size(160, 26)
        Me.TXT_STRENGTH.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.25!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(19, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(404, 22)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "DINING STRENGTH OF CURRENT MONTH:-"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.DTP_MONTH)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.cmd_DOCNOhelp)
        Me.GroupBox6.Controls.Add(Me.CMB_STORECODE)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.TXT_DOCNO)
        Me.GroupBox6.Location = New System.Drawing.Point(304, 136)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1034, 110)
        Me.GroupBox6.TabIndex = 472
        Me.GroupBox6.TabStop = False
        '
        'Messing_Summary
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1641, 1018)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "Messing_Summary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MESSING SUMMARY"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    'FINAL
    Dim dr As DataRow
    Dim dc As DataColumn
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim VNO As Integer
    Dim fromdate, todate As String
    Dim monthnm, mname, lastmonth As String
    Dim month As Double
    ' Dim lastmonth As Date
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 734
        K = 1034
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
    Private Sub Store_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Resize_Form()
        Me.DoubleBuffered = True
        autogenerate()
        '     getucategory()
        '    getuflag()
        Call FillStore()
        'TXT_USERNAME.Enabled = False
        ' TXT_CATFLAG.ReadOnly = False
        'TXT_USERNAME.ReadOnly = False
        'txt_CATEGORYCode.Enabled = False
        'txt_CATEGORYCode.ReadOnly = False
        'txt_CATEGORYDesc.ReadOnly = False
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        StoreMasterbool = True
        'TXT_USERNAME.Focus()
        Me.Cmd_Clear_Click(sender, e)
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        'Dim strSQL As String
        'If Cmd_Add.Text = "Add [F7]" Then
        '    Call checkValidation() '''--->Check Validation
        '    If boolchk = False Then Exit Sub
        '    strSQL = "INSERT INTO MESSING_SUMMARY(DOCNO,oldstock,NEWSTOCK,PURCHASE,ISSUE,DAMAGE,EXPENDITURE,STRENGTH,ADDDATE,ADDUSER,FREEZE,MESSING,MONTHNM,LASTMONTH,CURRENTMONTH,LASTMONTHF, CURRENTMONTHF)"
        '    strSQL = strSQL & " VALUES ('" & Trim(TXT_DOCNO.Text) & "','" & Trim(TXT_OLDSTOCK.Text) & "','" & Trim(TXT_NEWSTOCK.Text) & "',"
        '    strSQL = strSQL & " '" & Trim(TXT_PURCHASE.Text) & "','" & Trim(TXT_ISSUE.Text) & "','" & Trim(TXT_DAMAGE.Text) & "',"
        '    strSQL = strSQL & " '" & Trim(TXT_EXPENDITURE.Text) & "','" & Trim(TXT_STRENGTH.Text) & "','" & Format(Now, "dd/MMM/yyyy hh:mm:ss") & "',"
        '    strSQL = strSQL & " '" & Trim(gUsername) & "','N','" & Trim(TXT_MESSING.Text) & "','" & DTP_MONTH.Text & "',"
        '    strSQL = strSQL & " '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "','" & Format(DTP_TDATE.Value, "dd/MMM/yyyy") & "',"
        '    strSQL = strSQL & " '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "','" & Format(DTP_FDATE.Value, "dd/MMM/yyyy") & "')"
        '    'strSQL = strSQL & "'" & Format(Now, "dd/MMM/yyyy hh:mm:ss") & "',"
        '    'strSQL = strSQL & "'" & Trim(TXT_USERNAME.Text) & "',"
        '    'If RDO_ADMIN.Checked = True Then
        '    '    strSQL = strSQL & "'" & RDO_ADMIN.Text & "',"
        '    'Else
        '    '    strSQL = strSQL & "'" & RDO_USER.Text & "',"
        '    'End If
        '    'strSQL = strSQL & "'" & Trim(TXT_CATFLAG.Text) & "')"
        '    gconnection.dataOperation(1, strSQL, "MESSING_SUMMARY")
        '    Me.cmd_rpt_Click(sender, e)
        '    Me.Cmd_Clear_Click(sender, e)
        'ElseIf Cmd_Add.Text = "Update[F7]" Then
        '    Call checkValidation() '''--->Check Validation
        '    If boolchk = False Then Exit Sub
        '    If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
        '        If Me.lbl_Freeze.Visible = True Then
        '            MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '            boolchk = False
        '        End If
        '    End If
        '    strSQL = "UPDATE  inventorycategorymaster "
        '    ' strSQL = strSQL & " SET categorydesc='" & Replace(Trim(txt_CATEGORYDesc.Text), "'", "") & "',"
        '    strSQL = strSQL & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(Now, "dd/MMM/yyyy hh:mm:ss") & "',Freeze='N',"
        '    'strSQL = strSQL & " USERNAME='" & Replace(Trim(TXT_USERNAME.Text), "'", "") & "',categoryflag='" & Replace(Trim(TXT_CATFLAG.Text), "'", "") & "'"
        '    ' strSQL = strSQL & " WHERE CATEGORYCODE = '" & Trim(txt_CATEGORYCode.Text) & "'"
        '    gconnection.dataOperation(2, strSQL, "inventorycategorymaster")
        '    Me.Cmd_Clear_Click(sender, e)
        '    Cmd_Add.Text = "Add [F7]"

        'End If
        Dim STRSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            STRSQL = "INSERT INTO messing_summary (DOCNO, monthnm, oldstock, NEWSTOCK, PURCHASE, EMESSING,COLLEGEFUNCTION,"
            STRSQL = STRSQL & " SERVANTRATION,WASTAGEFOOD,TDAMOUNT,STRENGTH,MESSING,ADDDATE,ADDUSER,FREEZE, lastmonthf)"
            STRSQL = STRSQL & "VALUES('" & Trim(TXT_DOCNO.Text) & "','" & DTP_MONTH.Text & "','" & Trim(TXT_OLDSTOCK.Text) & "','" & Trim(TXT_NEWSTOCK.Text) & "',"
            STRSQL = STRSQL & " '" & Trim(TXT_PURCHASE.Text) & "','" & Trim(TXT_ISSUE.Text) & "','" & Trim(TXT_DAMAGE.Text) & "','" & Trim(txt_servant_total.Text) & "',"
            STRSQL = STRSQL & " '" & Trim(TXT_WASTAGEFOOD.Text) & "','" & Trim(TXT_TDAMOUNT.Text) & "','" & Trim(TXT_STRENGTH.Text) & "','" & Trim(TXT_MESSING.Text) & "',"
            STRSQL = STRSQL & " '" & Format(Date.Now, "dd/MMM/yyyy") & "', '" & gUsername & "','N', '" & lastmonth & "')"
            gconnection.dataOperation(1, STRSQL, "MESSING_SUMMARY")
            Me.cmd_rpt_Click(sender, e)
            Me.Cmd_Clear_Click(sender, e)
        End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  MESSING_SUMMARY "
            sqlstring = sqlstring & " SET Freeze= 'Y',voiduser='" & gUsername & " ', voiddate='" & Format(Now, "dd/MMM/yyyy hh:mm:ss") & "'"
            'sqlstring = sqlstring & " WHERE CATEGORYCODE = '" & Trim(txt_CATEGORYCode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "MESSING_SUMMARY")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
            'Else
            '    sqlstring = "UPDATE  StoreMaster "
            '    sqlstring = sqlstring & " SET Freeze= 'N',Adduser='" & gUsername & " ', Adddate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '    sqlstring = sqlstring & " WHERE Storecode = '" & Trim(txt_StoreCode.Text) & "'"
            '    gconnection.dataOperation(4, sqlstring, "StoreMaster")
            '    Me.Cmd_Clear_Click(sender, e)
            '    Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Cmd_Add.Text = "Add [F7]"
        Cmd_Freeze.Enabled = True
        TXT_TOTAL.Text = ""
        txt_totalE.Text = ""
        txt_servant_total.Text = ""
        TXT_OLDSTOCK.Text = ""
        TXT_STRENGTH.Text = ""
        TXT_NEWSTOCK.Text = ""
        TXT_PURCHASE.Text = ""
        TXT_ISSUE.Text = ""
        TXT_EXPENDITURE.Text = ""
        TXT_MESSING.Text = ""
        TXT_EXPENDITURE.Text = ""
        TXT_DAMAGE.Text = ""
        TXT_MESSING.Text = ""
        TXT_WASTAGEFOOD.Text = ""
        TXT_TDAMOUNT.Text = ""
        TXT_TOTALEXP.Text = ""
        'DTP_FDATE.Value = Date.Now
        'DTP_FROMDATE.Value = Date.Now
        'DTP_TDATE.Value = Date.Now
        'DTP_TODATE.Value = Date.Now
        Cmd_Add.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        autogenerate()
        'DTP_FROMDATE.Focus()
        'TXT_USERNAME.Focus()
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
        Me.Cmd_Add.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Me.Cmd_View.Enabled = False
        Me.cmd_auth.Enabled = False
        Me.cmd_rpt.Enabled = False
        Me.cmd_export.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Me.cmd_auth.Enabled = True
                    Me.cmd_rpt.Enabled = True
                    Me.cmd_export.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                    Me.cmd_rpt.Enabled = True
                    Me.cmd_export.Enabled = True
                End If
                If Right(x) = "U" Then
                    Me.cmd_auth.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        'gPrint = False
        ''If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Store Master") = MsgBoxResult.Yes Then
        'Dim rViewer As New Viewer
        'Dim sqlstring, SSQL As String
        'Dim r As New Rpt_StoreMaster
        'sqlstring = "SELECT * FROM storemaster order by Storedesc  "
        'gconnection.getDataSet(sqlstring, "storemaster")
        'If gdataset.Tables("storemaster").Rows.Count > 0 Then
        '    If chk_excel.Checked = True Then
        '        Dim exp As New exportexcel
        '        exp.Show()
        '        Call exp.export(sqlstring, "STORE MASTER ", "")
        '    Else
        '        rViewer.ssql = sqlstring
        '        rViewer.Report = r
        '        rViewer.TableName = "storemaster"
        '        Dim textobj1 As TextObject
        '        textobj1 = r.ReportDefinition.ReportObjects("Text13")
        '        textobj1.Text = MyCompanyName
        '        Dim textobj2 As TextObject
        '        textobj2 = r.ReportDefinition.ReportObjects("Text21")
        '        textobj2.Text = gUsername
        '        rViewer.Show()
        '    End If
        'Else
        '    MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        'End If
        ''Else
        '' PRINTOPERATION()
        '' End If
        Dim FRM As New ReportDesigner
        'If txt_CATEGORYCode.Text.Length > 0 Then
        '    tables = " FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE ='" & txt_CATEGORYCode.Text & "' "
        'Else
        '    tables = "FROM INVENTORYCATEGORYMASTER "
        'End If
        Gheader = "INVENTORYCATEGORYMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"CATEGORYCODE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CATEGORYDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"USERNAME", "30"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CATEGORYFLAG", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UTYPE", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Freeze", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adduser", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adddate", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"VOIDUSER", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"VOIDDATE", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)

    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Store_Master_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 And Cmd_Freeze.Enabled = True Then
            Call Cmd_Freeze_Click(Cmd_Freeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 And Cmd_Add.Enabled = True Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 And Cmd_View.Enabled = True Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F10 Then
            Call cmd_Print_Click(cmd_auth, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F4 Then
            'Call cmdStoreCode_Click(cmdStoreCode, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub

    Private Sub cmdStoreCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gSQLString = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER"
        M_WhereCondition = "  "
        Dim vform As New ListOperattion1
        vform.Field = "CATEGORYDESC,CATEGORYCODE"
        vform.vFormatstring = "         CATEGORY CODE              |                  CATEGORY DESCRIPTION                                                                                                   "
        vform.vCaption = "CATEGORY MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            'txt_CATEGORYCode.Text = Trim(vform.keyfield & "")
            'Call txt_StoreCode_Validated(txt_CATEGORYCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_StoreCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F4 Then
            'If cmdStoreCode.Enabled = True Then
            '    search = Trim(txt_CATEGORYCode.Text)
            '    'Call cmdStoreCode_Click(cmdStoreCode, e)
            'End If
        End If
    End Sub

    Private Sub txt_StoreDesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    Opt_Mainstore.Focus()
        'End If
    End Sub

    Private Sub txt_StoreCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Trim(txt_CATEGORYCode.Text) <> "" Then
        '    sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC,ISNULL(CATEGORYFLAG,'') AS CATEGORYFLAG,ISNULL(FREEZE,'') AS FREEZE,ISNULL(USERNAME,'') AS USERNAME,ADDDATE, isnull(utype,'') as utype FROM INVENTORYCATEGORYMASTER WHERE CATEGORYCODE='" & Trim(txt_CATEGORYCode.Text) & "'"
        '    gconnection.getDataSet(sqlstring, "INVENTORYCATEGORYMASTER")
        '    If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0 Then
        '        txt_CATEGORYCode.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYCODE"))
        '        txt_CATEGORYDesc.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
        '        TXT_CATFLAG.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYFLAG"))

        '        'TXT_USERNAME.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("USERNAME"))
        '        If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("FREEZE") = "Y" Then
        '            Me.lbl_Freeze.Visible = True
        '            Me.lbl_Freeze.Text = ""
        '            Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("VOIDDATE")), "dd/MMM/yyyy")
        '            ' JH
        '            ' Me.Cmd_Freeze.Text = "UnFreeze[F8]"
        '            Me.Cmd_Freeze.Enabled = False
        '        Else
        '            Me.lbl_Freeze.Visible = False
        '            Me.lbl_Freeze.Text = "Record Freezed  On "
        '            Me.Cmd_Freeze.Text = "Freeze[F8]"
        '        End If
        '        'If Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("STORESTATUS")) = "M" Then
        '        '    Opt_Mainstore.Checked = True
        '        'Else
        '        '    Opt_Substore.Checked = True
        '        'End If
        '        ' Me.Cmd_Add.Text = "Update[F7]"
        '        'txt_CATEGORYCode.ReadOnly = True
        '        'txt_CATEGORYDesc.Focus()
        '    Else
        '        Me.lbl_Freeze.Visible = False
        '        Me.lbl_Freeze.Text = "Record Freezed  On "
        '        Me.Cmd_Add.Text = "Add [F7]"
        '        'txt_CATEGORYCode.ReadOnly = False
        '        'txt_CATEGORYDesc.Focus()
        '    End If
        '    If gUserCategory <> "S" Then
        '        Call GetRights()
        '    End If
        'Else
        '    'txt_CATEGORYCode.Text = ""
        '    'txt_CATEGORYDesc.Focus()
        'End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  OLD STOCK Can't be blank *********************'''
        If Trim(TXT_OLDSTOCK.Text) = "" Then
            MessageBox.Show(" Old Stock can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BTN_OLDSTOCK.Focus()
            Exit Sub
        End If
        ' '''********** Check  new STOCK Can't be blank *********************'''
        If Trim(TXT_NEWSTOCK.Text) = "" Then
            MessageBox.Show(" New Stock can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BTN_NEWSTOCK.Focus()
            Exit Sub
        End If
        ' '''********** Check  CATEGORY FLAG Can't be blank *********************'''
        If Trim(TXT_PURCHASE.Text) = "" Then
            MessageBox.Show("Purchase can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BTN_PURCHASE.Focus()
            Exit Sub
        End If
        ' '''********** Check  USERNAME Can't be blank *********************'''
        'If Trim(TXT_ISSUE.Text) = "" Then
        '    MessageBox.Show("Issue can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    BTN_ISSUE.Focus()
        '    Exit Sub
        'End If
        '*****check for double username***************
        'sqlstring = "select categorycode,username from INVENTORYCATEGORYMASTER where categorycode='" & txt_CATEGORYCode.Text & "' and username='" & TXT_USERNAME.Text & "'"
        '**********CHECK FOR CATEGORY CODE AND CATEGORY FLAG**************
        'If Mid(txt_CATEGORYCode.Text, 1, 1) <> Mid(TXT_CATFLAG.Text, 1, 1) Then
        '    MessageBox.Show("Category Flag should be first letter of Category Code")
        '    Exit Sub
        'End If
        'If Trim(TXT_DAMAGE.Text) = "" Then
        '    MessageBox.Show("Damage can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    BTN_DAMAGE.Focus()
        '    Exit Sub
        'End If
        'If Trim(TXT_EXPENDITURE.Text) = "" Then
        '    MessageBox.Show("Expenditure can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Button1.Focus()
        '    Exit Sub
        'End If
        If Trim(TXT_STRENGTH.Text) = "" Then
            MessageBox.Show("Strength can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_STRENGTH.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub Store_Master_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        StoreMasterbool = False
    End Sub

    Private Sub Opt_Mainstore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Cmd_Add.Focus()
        End If
    End Sub

    Private Sub txt_StoreCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            '
        End If
    End Sub

    'Private Sub cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_auth.Click
    '    gPrint = True
    '    Dim rViewer As New Viewer
    '    Dim sqlstring, SSQL As String
    '    Dim r As New Rpt_StoreMaster
    '    sqlstring = "SELECT * FROM storemaster order by Storedesc  "
    '    gconnection.getDataSet(sqlstring, "storemaster")
    '    If gdataset.Tables("storemaster").Rows.Count > 0 Then
    '        rViewer.ssql = sqlstring
    '        rViewer.Report = r
    '        rViewer.TableName = "storemaster"
    '        Dim textobj1 As TextObject
    '        textobj1 = r.ReportDefinition.ReportObjects("Text13")
    '        textobj1.Text = MyCompanyName
    '        Dim textobj2 As TextObject
    '        textobj2 = r.ReportDefinition.ReportObjects("Text21")
    '        textobj2.Text = MyCompanyName
    '        rViewer.Show()
    '    Else
    '        MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
    '    End If
    '    'PRINTOPERATION()
    'End Sub

    Private Sub PRINTOPERATION()
        Dim x, docno, printline As String
        Dim I As Integer
        Dim booldocno As Boolean
        Dim total(10) As Double
        Dim vsubheader() As String = {"DOC NO. : ", "DOC DATE : ", "MAIN STORE CODE : ", "MAIN STORE NAME : ", "TO STORE CODE  : ", "TO STORE NAME :"}
        Dim PAGEHEADING() As String = {"CATEGORY MASTER"}
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            sqlstring = "SELECT CATEGORYCODE,CATEGORYDESC,FREEZE FROM INVENTORYCATEGORYMASTER ORDER BY CATEGORYCODE"
            gconnection.getDataSet(sqlstring, "INVENTORYCATEGORYMASTER")
            Call Print_Headers(PAGEHEADING)
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            For Each dr In gdataset.Tables("INVENTORYCATEGORYMASTER").Rows
                Filewrite.WriteLine("|{0,-15}|{1,-40}|{2,10}|{3,10}|", Mid(dr.Item("CATEGORYCODE"), 1, 15), Mid(dr.Item("CATEGORYDESC"), 1, 40), Mid(dr.Item("FREEZE"), 1, 10))
                pagesize = pagesize + 1
                If pagesize > 58 Then
                    Filewrite.Write(StrDup(80, "-"))
                    Filewrite.Write(Chr(12))
                    pageno = pageno + 1
                    Call Print_Headers(PAGEHEADING)
                    Filewrite.WriteLine()
                    pagesize = pagesize + 1
                End If
            Next dr
            Filewrite.WriteLine(StrDup(80, "-"))
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Sub
        End Try
    End Sub

    Private Function Print_Headers(ByVal pageheading() As String)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.WriteLine(Chr(18))
            Filewrite.WriteLine("{0,40}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MMM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,1}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(pageheading(0)), 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-1}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(pageheading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,70}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(80, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("|{0,-15}|{1,-40}|{2,10}|{3,10}|", "CATEGORYCODE", "CATEGORY DESCRIPTION", "CATEGORYFLAG", "FREEZE")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(80, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VW_MESSING_SUMMARY"
        sqlstring = "select * from VW_MESSING_SUMMARY"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start(AppPath & "/STUDY/STOREMASTER.XLS")
    End Sub

    Private Sub cmd_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_auth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        Dim USERT As Integer
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 1
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 2
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 3
        End If
        If USERT = 1 Then
            SSQLSTR2 = " SELECT * FROM STOREMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM STOREMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE STOREMASTER set  ", "STORECODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM STOREMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM STOREMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE STOREMASTER set  ", "STORECODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM STOREMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM STOREMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE STOREMASTER set  ", "STORECODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmd_rpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_rpt.Click
        gPrint = False
        Dim RVIEWER As New Viewer
        Dim SQLSTRING As String
        Dim R As New Cry_msummary
        SQLSTRING = "SELECT * FROM MESSING_SUMMARY WHERE DOCNO='" & TXT_DOCNO.Text & "'"
        gconnection.getDataSet(SQLSTRING, "MESSING_SUMMARY")

        If gdataset.Tables("MESSING_SUMMARY").Rows.Count > 0 Then
            'If chk_excel.Checked = True Then
            '    Dim exp As New exportexcel
            '    exp.Show()
            '    Call exp.export(sqlstring, "CATEGORY MASTER ", "")
            'Else

            RVIEWER.ssql = SQLSTRING
            RVIEWER.Report = R


            RVIEWER.TableName = "MESSING_SUMMARY"
            'If gdataset.Tables("MESSING_SUMMARY").Rows.Count > 0 Then
            ' R.SetDataSource(DS)
            'RVIEWER.CrystalReportViewer1.ReportSource = R
            '  rViewer.Show()
            'rViewer.ssql = SQLS
            'rViewer.TableName = "STOCKEXPENDITUREHEADER"

            'End If
            RVIEWER.Show()
        End If

        'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Store Master") = MsgBoxResult.Yes Then
        'Dim rViewer As New CRYVIEWER
        'Dim DS As New DataSet7
        'Dim sqlstring, SSQL, SQLS As String
        'Dim r As New Cry_messingsummary
        'sqlstring = "SELECT * FROM VW_MESSING_SUMMARY WHERE DOCNO='" & TXT_DOCNO.Text & "' "
        'SQLS = "SELECT DISTINCT EXPENDITURE, sum(amount) as amount FROM stockexpendituredetails WHERE Docdate BETWEEN '" & fromdate & "' and '" & todate & "' group by  EXPENDITURE, amount"
        'gconnection.getDataSet(sqlstring, "VW_MESSING_SUMMARY")

        'gconnection.getDataSet(SQLS, "stockexpendituredetails")
        'DS.Tables("VW_MESSING_SUMMARY").Merge(gdataset.Tables("VW_MESSING_SUMMARY"), True, MissingSchemaAction.Ignore)
        'DS.Tables("datatable1").Merge(gdataset.Tables("stockexpendituredetails"), True, MissingSchemaAction.Ignore)

        ''DS.Tables("VW_MESSING_SUMMARY").Merge(missingSchemaAction:=True, table:="VW_MESSING_SUMMARY", preserveChanges:=False)
        ''DS.Tables("VW_MESSING_SUMMARY").Merge(MissingSchemaAction:=True, table:= "VW_MESSING_SUMMARY"
        ''gconnection.getDataSet(SQLS, "STOCKEXPENDITUREHEADER")

        'If gdataset.Tables("VW_MESSING_SUMMARY").Rows.Count > 0 Then
        '    'If chk_excel.Checked = True Then
        '    '    Dim exp As New exportexcel
        '    '    exp.Show()
        '    '    Call exp.export(sqlstring, "CATEGORY MASTER ", "")
        '    'Else

        '    'rViewer.ssql = sqlstring
        '    'rViewer.Report = r


        '    'rViewer.TableName = "VW_MESSING_SUMMARY"
        '    'If gdataset.Tables("VW_MESSING_SUMMARY").Rows.Count > 0 Then
        '    r.SetDataSource(DS)
        '    rViewer.CrystalReportViewer1.ReportSource = r
        '    '  rViewer.Show()
        '    'rViewer.ssql = SQLS
        '    'rViewer.TableName = "STOCKEXPENDITUREHEADER"

        '    Dim textobj1 As TextObject
        '    textobj1 = r.ReportDefinition.ReportObjects("Text16")
        '    textobj1.Text = MyCompanyName
        '    Dim textobj2 As TextObject
        '    textobj2 = r.ReportDefinition.ReportObjects("Text15")
        '    textobj2.Text = gUsername
        '    Dim t1 As TextObject
        '    t1 = r.ReportDefinition.ReportObjects("Text17")
        '    t1.Text = gCompanyAddress(0)
        '    Dim t2 As TextObject
        '    t2 = r.ReportDefinition.ReportObjects("Text18")
        '    t2.Text = gCompanyAddress(1)
        '    rViewer.Show()
        '    'End If
        '    'End If
        'Else
        '    MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        'End If
        ''Else
        '' PRINTOPERATION()
        '' End If
    End Sub

    Private Sub txt_StoreDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_StoreCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TXT_USERNAME_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub TXT_USERNAME_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            'If Trim(TXT_USERNAME.Text) = "" Then
            '    Call CMD_USERBAME_Click(CMD_USERBAME, e)
            'Else
            '    TXT_USERNAME_Validated(TXT_USERNAME, e)
            'End If
        End If
    End Sub

    Private Sub TXT_USERNAME_Validated(sender As Object, e As EventArgs)
        'If Trim(txt_CATEGORYCode.Text) <> "" Then
        '    sqlstring = "SELECT ISNULL(CATEGORYCODE,'') AS CATEGORYCODE,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC,ISNULL(CATEGORYFLAG,'') AS CATEGORYFLAG,ISNULL(FREEZE,'') AS FREEZE,ISNULL(USERNAME,'') AS USERNAME,ADDDATE FROM INVENTORYCATEGORYMASTER WHERE USERNAME='" & Trim(TXT_USERNAME.Text) & "'"
        '    gconnection.getDataSet(sqlstring, "INVENTORYCATEGORYMASTER")
        '    If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows.Count > 0 Then
        '        txt_CATEGORYCode.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYCODE"))
        '        txt_CATEGORYDesc.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYDESC"))
        '        TXT_CATFLAG.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("CATEGORYFLAG"))
        '        TXT_USERNAME.Text = Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("USERNAME"))
        '        If gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("FREEZE") = "Y" Then
        '            Me.lbl_Freeze.Visible = True
        '            Me.lbl_Freeze.Text = ""
        '            Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("VOIDDATE")), "dd/MMM/yyyy")
        '            ' JH
        '            ' Me.Cmd_Freeze.Text = "UnFreeze[F8]"
        '            Me.Cmd_Freeze.Enabled = False
        '        Else
        '            Me.lbl_Freeze.Visible = False
        '            Me.lbl_Freeze.Text = "Record Freezed  On "
        '            Me.Cmd_Freeze.Text = "Freeze[F8]"
        '        End If
        '        'If Trim(gdataset.Tables("INVENTORYCATEGORYMASTER").Rows(0).Item("STORESTATUS")) = "M" Then
        '        '    Opt_Mainstore.Checked = True
        '        'Else
        '        '    Opt_Substore.Checked = True
        '        'End If
        '        'Me.Cmd_Add.Text = "Update[F7]"
        '        txt_CATEGORYCode.ReadOnly = True
        '        txt_CATEGORYDesc.Focus()
        '    Else
        '        Me.lbl_Freeze.Visible = False
        '        Me.lbl_Freeze.Text = "Record Freezed  On "
        '        Me.Cmd_Add.Text = "Add [F7]"
        '        'txt_CATEGORYCode.ReadOnly = False
        '        txt_CATEGORYCode.Focus()
        '    End If
        '    If gUserCategory <> "S" Then
        '        Call GetRights()
        '    End If
        'Else
        '    txt_CATEGORYCode.Text = ""
        '    txt_CATEGORYCode.Focus()
        'End If
    End Sub

    Private Sub CMD_USERBAME_Click(sender As Object, e As EventArgs)
        gSQLString = "SELECT ISNULL(adduser,'') AS USERNAME,ISNULL(CATEGORYDESC,'') AS CATEGORYDESC FROM INVENTORYCATEGORYMASTER"
        M_WhereCondition = "  "
        Dim vform As New ListOperattion1
        vform.Field = "USERNAME,CATEGORYDESC"
        vform.vFormatstring = "         USERNAME              |                  CATEGORY DESCRIPTION                                                                                                   "
        vform.vCaption = "CATEGORY MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        'If Trim(vform.keyfield & "") <> "" Then
        '    TXT_USERNAME.Text = Trim(vform.keyfield & "")
        '    Call TXT_USERNAME_Validated(TXT_USERNAME, e)
        'End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub RDO_ADMIN_Click(sender As Object, e As EventArgs)
        'If RDO_ADMIN.Checked = True Then
        '    RDO_USER.Checked = False
        'ElseIf RDO_USER.Checked = True Then
        '    RDO_ADMIN.Checked = False
        'End If
    End Sub

    Private Sub RDO_USER_Click(sender As Object, e As EventArgs)
        'If RDO_USER.Checked = True Then
        '    RDO_ADMIN.Checked = False
        'ElseIf RDO_ADMIN.Checked = True Then
        '    RDO_USER.Checked = False
        'End If
    End Sub
    Private Sub FillStore()
        Try
            Dim i As Integer
            sqlstring = "SELECT distinct(StoreCODE) FROM StoreMaster WHERE STORESTATUS='M' "
            gconnection.getDataSet(sqlstring, "StoreMaster")
            CMB_STORECODE.Items.Clear()
            'CMB_STORECODE1.Items.Clear()
            CMB_STORECODE.Sorted = True
            'CMB_STORECODE1.Sorted = True
            If gdataset.Tables("StoreMaster").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("StoreMaster").Rows.Count - 1
                    CMB_STORECODE.Items.Add(gdataset.Tables("StoreMaster").Rows(i).Item("StoreCODE"))
                    ' CMB_STORECODE1.Items.Add(gdataset.Tables("StoreMaster").Rows(i).Item("StoreCODE"))
                Next i
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : FillStore" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub BTN_OLDSTOCK_Click(sender As Object, e As EventArgs) Handles BTN_OLDSTOCK.Click
        Dim STORECODE As String
        Dim ITEMCODE As String
        Dim ITEMTABLE As DataTable
        Dim CLSQTY, CLSVAL As Double
        If CMB_STORECODE.Text = "" Then
            MessageBox.Show("PLEASE SELECT THE STORE CODE")
            CMB_STORECODE.Focus()
            Exit Sub
        End If
        'monthfold()
        monthf1()
        'Dim SLSTRING As String
        sqlstring = "select DISTINCT itemcode from inv_inventoryopenningstock WHERE storecode='" & CMB_STORECODE.Text & "' and void<>'Y'"
        gconnection.getDataSet(sqlstring, "inventoryitemmaster")
        ITEMTABLE = gdataset.Tables("inventoryitemmaster")
        If ITEMTABLE.Rows.Count > 0 Then

            For I = 0 To ITEMTABLE.Rows.Count - 1
                If ITEMCODE = "" Then
                    ITEMCODE = "'" & ITEMTABLE.Rows(I).Item("itemcode").ToString() & "'"
                Else
                    ITEMCODE = ITEMCODE & "," & "'" & ITEMTABLE.Rows(I).Item("itemcode").ToString() & "'"
                End If


            Next
            'SLSTRING = SLSTRING & "'" & Itemcode(i) & "', "
        End If
        sqlstring = " update inv_INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & ITEMCODE & ")  AND CATEGORY IN(" & USER & ")"
        gconnection.getDataSet(sqlstring, "ITEMMASTER1")
        gconnection.openConnection()
        sqlstring = " update inv_INVENTORYITEMMASTER SET SELECTOPT='Y' WHERE ITEMCODE IN(" & ITEMCODE & ") AND CATEGORY IN(" & USER & ")"
        gconnection.getDataSet(sqlstring, "ITEMMASTER")

        gconnection.openConnection()
        STORECODE = CMB_STORECODE.Text
        'gcommand = New SqlCommand("Cp_StockSummary3", gconnection.Myconn)
        gcommand = New SqlCommand("Cp_StockSummary_RATION", gconnection.Myconn)



        gcommand.CommandTimeout = 1000000000
        gcommand.CommandType = CommandType.StoredProcedure
        gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = STORECODE
        gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = fromdate
        gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = todate
        'gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate(gstartingdate), "dd/MM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("26/03/" & gFinancalyearStart), "dd/MM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = todate
        'gcommand.Parameters.Add(New SqlParameter("@rate", SqlDbType.Float)).Value = rate
        gcommand.ExecuteNonQuery()
        gconnection.closeConnection()
        '*********FILL IN THE OLD STOCK DATA ***************

        'sqlstring = "SELECT SUM(ISNULL(S.CLSQTY,0.00)) AS CLSQTY, SUM(ISNULL(S.CLSRATE,0.00)) CLSRATE, SUM(ISNULL(S.CLSVAL,0.00)) AS VALUE,SUM(ISNULL(S.DISPQTY,0)) AS DISPQTY  FROM STOCKSUMMARY S, INVENTORYITEMMASTER I "
        'sqlstring = sqlstring & " WHERE I.ITEMCODE=S.ITEMCODE AND I.STORECODE=S.STORECODE"
        ' sqlstring = "SELECT ISNULL(round(SUM(VALUE),2),0) AS VALUE FROM TEMPMCEME WHERE CATEGORY IN (" & USER & ") AND STORECODE='" & CMB_STORECODE.Text & "' AND CATEGORY<>''"
        sqlstring = "SELECT SUM(OPVAL) AS VALUE FROM STOCKSUMMARY WHERE CATEGORY IN (" & USER & ") AND STORECODE='" & CMB_STORECODE.Text & "' AND CATEGORY<>''"

        'sqlstring = sqlstring & " WHERE STORECODE='" & Trim(CMB_STORECODE.Text) & "' "

        ' sqlstring = "SELECT SUM(CLSVAL) AS CLSVAL FROM STOCKSUMMARY"
        gconnection.getDataSet(sqlstring, "STOCKSUMMARY1")
        If gdataset.Tables("STOCKSUMMARY1").Rows.Count > 0 Then
            TXT_OLDSTOCK.Text = gdataset.Tables("STOCKSUMMARY1").Rows(0).Item("VALUE")
        End If

    End Sub

    Private Sub BTN_NEWSTOCK_Click(sender As Object, e As EventArgs) Handles BTN_NEWSTOCK.Click
        Dim STORECODE, itemcode As String
        Dim itemtable As DataTable

        'If CMB_STORECODE1.Text = "" Then
        '    MessageBox.Show("PLEASE SELECT THE STORE CODE")
        '    CMB_STORECODE1.Focus()
        '    Exit Sub
        'End If
        'monthf()
        monthf1()

        'm
        sqlstring = "select DISTINCT itemcode from inv_inventoryopenningstock WHERE storecode='" & CMB_STORECODE.Text & "' and void<>'Y'"
        gconnection.getDataSet(sqlstring, "inventoryitemmaster")
        itemtable = gdataset.Tables("inventoryitemmaster")
        If itemtable.Rows.Count > 0 Then

            For I = 0 To itemtable.Rows.Count - 1
                If itemcode = "" Then
                    itemcode = "'" & itemtable.Rows(I).Item("itemcode").ToString() & "'"
                Else
                    itemcode = itemcode & "," & "'" & itemtable.Rows(I).Item("itemcode").ToString() & "'"
                End If


            Next
            'SLSTRING = SLSTRING & "'" & Itemcode(i) & "', "
        End If
        sqlstring = " update INV_INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & itemcode & ")  AND CATEGORY IN(" & USER & ")"
        gconnection.getDataSet(sqlstring, "ITEMMASTER1")
        sqlstring = " update INV_INVENTORYITEMMASTER SET SELECTOPT='Y' WHERE ITEMCODE IN(" & itemcode & ") AND CATEGORY IN(" & USER & ")"
        gconnection.getDataSet(sqlstring, "ITEMMASTER")

        gconnection.openConnection()

        STORECODE = CMB_STORECODE.Text
        gcommand = New SqlCommand("Cp_StockSummary_Ration", gconnection.Myconn)



        gcommand.CommandTimeout = 1000000000
        gcommand.CommandType = CommandType.StoredProcedure
        gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = STORECODE
        gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = fromdate
        gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = todate
        'gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate(gstartingdate), "dd/MM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("26/03/" & gFinancalyearStart), "dd/MM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = todate
        'gcommand.Parameters.Add(New SqlParameter("@rate", SqlDbType.Float)).Value = rate
        gcommand.ExecuteNonQuery()
        gconnection.closeConnection()
        '*********FILL IN THE OLD STOCK DATA ***************
        'sqlstring = "SELECT SUM(CLSVAL) AS CLSVAL FROM STOCKSUMMARY"
        'sqlstring = "SELECT round(SUM(VALUE),2) AS VALUE FROM TEMPMCEME WHERE CATEGORY IN (" & USER & ") AND STORECODE='" & CMB_STORECODE.Text & "' AND CATEGORY<>''"
        sqlstring = "SELECT (ISNULL(SUM(OPVAL),0) + ISNULL(SUM(RCVVAL),0) + ISNULL(SUM(RETVAL),0)) - ISNULL(SUM(ISSVAL),0) AS CLOSINGVAL FROM STOCKSUMMARY WHERE STORECODE='MNS' AND CATEGORY='RAS' AND CATEGORY<>''"
        gconnection.getDataSet(sqlstring, "STOCKSUMMARY")
        If gdataset.Tables("STOCKSUMMARY").Rows.Count > 0 Then
            Dim product As Double
            product = gdataset.Tables("STOCKSUMMARY").Rows(0).Item("CLOSINGVAL")
            product = Math.Round(product, 2, MidpointRounding.AwayFromZero)
            'TXT_NEWSTOCK.Text = gdataset.Tables("STOCKSUMMARY").Rows(0).Item("VALUE")
            TXT_NEWSTOCK.Text = Format(Val(product), "0.00")
        End If
    End Sub

    Private Sub BTN_PURCHASE_Click(sender As Object, e As EventArgs) Handles BTN_PURCHASE.Click
        'sqlstring = "select ISNULL(sum(totalamount),0) as purchase from grn_header where Grndate between "
        monthf1()
        Dim STOREDESC As String
        sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & CMB_STORECODE.Text & "'"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            STOREDESC = gdataset.Tables("STOREMASTER").Rows(0).Item("STOREDESC")
        End If
        sqlstring = "select isnull(SUM(BILLAMOUNT),0) as billamount from [grn_header] where  cast(convert(varchar(11),Grndate,106) as datetime)  between "
        sqlstring = sqlstring & "'" & fromdate & "' AND '" & todate & "' and category='RAS' and grntype='GRN' AND STORECODE='" & CMB_STORECODE.Text & "'"
        gconnection.getDataSet(sqlstring, "grn_header")
        If gdataset.Tables("grn_header").Rows.Count > 0 Then
            TXT_PURCHASE.Text = gdataset.Tables("grn_header").Rows(0).Item("billamount")
        End If

    End Sub

    Private Sub BTN_ISSUE_Click(sender As Object, e As EventArgs) Handles BTN_ISSUE.Click
        Dim AMOUNT, AMOUNT1 As String
        'sqlstring = "select ISNULL(SUM(totalamt),0) as stockissue from stockissueheader where Docdate between "
        'sqlstring = sqlstring & "'" & fromdate & "' AND '" & todate & "' and storelocationcode='" & CMB_STORECODE.Text & "'"
        'sqlstring = "SELECT ISNULL(SUM(AMOUNT),0) AS CR_AMT FROM KOT_DET WHERE PAYMENTMODE ='CREDIT' AND  CATEGORY='EXTRA MESSING' "
        sqlstring = "SELECT ISNULL(SUM(AMOUNT),0) AS CR_AMT FROM KOT_DET WHERE CATEGORY='EXTRA MESSING' "
        sqlstring = sqlstring & " AND ISNULL(DELFLAG,'')<>'Y' AND ISNULL(KOTSTATUS,'') <>'Y' AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) BETWEEN  '" & fromdate & "' AND '" & todate & "'"
        sqlstring = sqlstring & " AND  ISNULL(BILLDETAILS,'')<>'' AND ISNULL(PAYMENTMODE,'') <>'' and POSCODE in (SELECT POSCODE from posmaster) "
        gconnection.getDataSet(sqlstring, "stockissueheader")
        If gdataset.Tables("stockissueheader").Rows.Count > 0 Then
            AMOUNT = gdataset.Tables("stockissueheader").Rows(0).Item("CR_AMT")
        End If
        sqlstring = "select ISNULL(SUM(EXTRAMESSING),0) as EXTRAMESSING from STOCKEXPENDITUREHEADER where ISNULL(VOID,'')<>'Y' AND cast(convert(varchar(11),Docdate,106) as datetime) between "
        sqlstring = sqlstring & "'" & fromdate & "' AND '" & todate & "' and storeLOCATIONcode='" & CMB_STORECODE.Text & "'"
        gconnection.getDataSet(sqlstring, "STOCKDMGHEADER")
        If gdataset.Tables("STOCKDMGHEADER").Rows.Count > 0 Then
            AMOUNT1 = 0
            AMOUNT1 = gdataset.Tables("STOCKDMGHEADER").Rows(0).Item("EXTRAMESSING")
        End If
        TXT_ISSUE.Text = Val(AMOUNT) + Val(AMOUNT1)
    End Sub

    Private Sub BTN_DAMAGE_Click(sender As Object, e As EventArgs) Handles BTN_DAMAGE.Click
        sqlstring = "select ISNULL(SUM(COLLEGEFUNC),0) as COLLEGEFUNC from STOCKEXPENDITUREHEADER where ISNULL(VOID,'')<>'Y' AND cast(convert(varchar(11),Docdate,106) as datetime) between "
        sqlstring = sqlstring & "'" & fromdate & "' AND '" & todate & "' and storeLOCATIONcode='" & CMB_STORECODE.Text & "'"
        gconnection.getDataSet(sqlstring, "STOCKDMGHEADER")
        If gdataset.Tables("STOCKDMGHEADER").Rows.Count > 0 Then
            TXT_DAMAGE.Text = gdataset.Tables("STOCKDMGHEADER").Rows(0).Item("COLLEGEFUNC")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'sqlstring = "select ISNULL(SUM(amount),0) as expenditure from STOCKEXPENDITUREDETAILS where Docdate between "
        'sqlstring = sqlstring & "'" & fromdate & "' AND '" & todate & "'"
        'sqlstring = "select isnull(SUM( isnull(purchaserate,0) * isnull(servant,0)),0) as servant from RationCALCULATION "
        'sqlstring = sqlstring & "where TODATE between '" & fromdate & "' and '" & todate & "' and fromdate between '" & fromdate & "' and '" & todate & "'"
        'gconnection.getDataSet(sqlstring, "STOCKEXPENDITUREDETAILS")
        'If gdataset.Tables("STOCKEXPENDITUREDETAILS").Rows.Count > 0 Then
        '    TXT_EXPENDITURE.Text = gdataset.Tables("STOCKEXPENDITUREDETAILS").Rows(0).Item("servant")
        'End If
    End Sub

    Private Sub BTN_CALCULATION_Click(sender As Object, e As EventArgs) Handles BTN_CALCULATION.Click
        If TXT_STRENGTH.Text = "" Then
            MessageBox.Show("PLEASE FILL THE STRENGTH")
            TXT_STRENGTH.Focus()
            Exit Sub
        End If
        Dim VAL1, TOTAL As Double
        'VAL1 = (Val(TXT_OLDSTOCK.Text)) + (Val(TXT_NEWSTOCK.Text)) + (Val(TXT_ISSUE.Text)) + (Val(TXT_DAMAGE.Text)) + (Val(TXT_EXPENDITURE.Text)) + (Val(TXT_PURCHASE.Text) + Val(TXT_WASTAGEFOOD.Text) + Val(TXT_TDAMOUNT.Text))
        VAL1 = Val(TXT_TOTALEXP.Text)
        TOTAL = VAL1 / Val(TXT_STRENGTH.Text)
        TXT_MESSING.Text = Format(Val(TOTAL), "0.00")
    End Sub
    Private Sub autogenerate1()
        Try
            Dim sqlstring, financalyear As String
            Dim month As String
            Dim CATLEN As Integer

            month = UCase(Format(Now, "MMM"))
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialyearEnd, 3, 2)

            'sqlstring = "SELECT ISNULL(CATEGORY,'') AS CATEGORY FROM INVENTORYITEMMASTER WHERE ISNULL(CATEGORY,'')='" & Trim(CMB_CATEGORY.Text & "") & "' GROUP BY CATEGORY"
            'gconnection.getDataSet(sqlstring, "CATEGORY")
            'If gdataset.Tables("CATEGORY").Rows.Count > 0 Then
            '    CATEGORY = Mid(Trim(gdataset.Tables("CATEGORY").Rows(0).Item("CATEGORY") & ""), 1, 3)
            '    CATLEN = Len(Trim(CATEGORY))
            'Else
            '    CATLEN = 3
            '    CATEGORY = month
            'End If
            sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) FROM MESSING_SUMMARY" '  AND ISNULL(GRNTYPE,'')='GRN'"
            '        sqlstring = "SELECT MAX(Cast(SUBSTRING(GRNNO,1,6) As Numeric)) FROM GRN_HEADER"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    TXT_DOCNO.Text = "MESS/" & "0001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    TXT_DOCNO.Text = "CRV/" & Format(gdreader(0) + 1, "0000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                TXT_DOCNO.Text = "CRV/0001/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : autogenerate" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


    Private Sub cmd_DOCNOhelp_Click(sender As Object, e As EventArgs) Handles cmd_DOCNOhelp.Click
        Try
            Dim cat As String
            'cat = substring(CMB_CATEGORY.Text, 1, 3)

            gSQLString = "SELECT DOCNO, ADDDATE FROM MESSING_SUMMARY"
            M_WhereCondition = " Where ISNULL(FREEZE,'')<>'Y'"
            Dim vform As New List_Operation
            vform.Field = "DOCNO,ADDDATE"
            vform.vFormatstring1 = "       DOC NO             |       DATE          | "
            vform.vCaption = "MESSING SUMMARY DOC NO HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXT_DOCNO.Text = Trim(vform.keyfield & "")
                'ssgrid.ClearRange(1, 1, -1, -1, True)
                Call TXT_DOCNO_Validated(TXT_DOCNO.Text, e)
                'Call Grid_lock()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : cmd_Grnnohelp_Click" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub TXT_DOCNO_Validated(sender As Object, e As EventArgs) Handles TXT_DOCNO.Validated
        Dim I, J, K As Integer
        Dim vString, sqlstring As String
        Dim GRNDATE As Date
        Dim vTypeseqno, Clsquantity As Double
        Dim vGroupseqno As Double
        Dim dt As New DataTable
        If Trim(TXT_DOCNO.Text) <> "" Then
            Try
                sqlstring = "SELECT  ISNULL(DOCNO,'') AS DOCNO,ISNULL(OLDSTOCK,'') AS OLDSTOCK,ISNULL(NEWSTOCK,'') AS NEWSTOCK,ISNULL(PURCHASE,'') AS PURCHASE,ISNULL(ISSUE,'') AS ISSUE,"
                sqlstring = sqlstring & " ISNULL(DAMAGE,'') AS DAMAGE,ISNULL(EXPENDITURE,'') AS EXPENDITURE,ISNULL(STRENGTH,'') AS STRENGTH, ISNULL(MESSING,'') AS MESSING, ISNULL(CURRENTMONTH,'') AS CURRENTMONTH,"
                sqlstring = sqlstring & "ISNULL(CURRENTMONTHF,'') AS CURRENTMONTHF, ISNULL(LASTMONTH,'') AS LASTMONTH,ISNULL(LASTMONTHF,'') AS LASTMONTHF, ISNULL(EMESSING,0) AS EMESSING,ISNULL(COLLEGEFUNCTION ,0) AS COLLEGEFUNCTION ,  "
                sqlstring = sqlstring & " ISNULL(SERVANTRATION ,0) AS SERVANTRATION , ISNULL(WASTAGEFOOD,0) AS WASTAGEFOOD, ISNULL(TDAMOUNT,0) AS TDAMOUNT, ISNULL(MONTHNM,'') AS MONTHNM "
                sqlstring = sqlstring & "  FROM MESSING_SUMMARY"
                sqlstring = sqlstring & " WHERE (DOCNO = '" & Trim(TXT_DOCNO.Text) & "')"
                'sqlstring = sqlstring & " and  rtrim(substring(grndetails,5,2)) = '" & Mid(doctype, 1, 2) & "'  and  isnull(GrnType,'')='GRN'"
                gconnection.getDataSet(sqlstring, "MESSING_SUMMARY")
                '''************************************************* SELECT record from Grn_header *********************************************''''                
                If gdataset.Tables("MESSING_SUMMARY").Rows.Count > 0 Then
                    'Call GridUnLock()
                    'Cmd_Add.Text = "Update[F7]"
                    Cmd_Add.Enabled = False
                    Me.TXT_DOCNO.ReadOnly = True
                    TXT_DOCNO.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("DOCNO"))
                    TXT_OLDSTOCK.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("OLDSTOCK"))
                    'dtp_Grndate.Value = Format(CDate(gdataset.Tables("GRNHEADER").Rows(0).Item("GRNDATE")), "dd/MMM/yyyy")
                    TXT_NEWSTOCK.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("NEWSTOCK"))
                    TXT_PURCHASE.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("PURCHASE"))
                    TXT_ISSUE.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("EMESSING"))
                    TXT_EXPENDITURE.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("SERVANTRATION"))
                    TXT_DAMAGE.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("COLLEGEFUNCTION"))
                    TXT_STRENGTH.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("STRENGTH"))
                    TXT_MESSING.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("MESSING"))
                    TXT_TDAMOUNT.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("TDAMOUNT"))
                    TXT_WASTAGEFOOD.Text = Trim(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("WASTAGEFOOD"))
                    'DTP_MONTH.Value = Trim(Format(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("MONTHNM"), "MMMMM"))
                    'DTP_FROMDATE.Value = Format(CDate(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("LASTMONTHF")), "dd/MMM/yyyy")
                    'DTP_FDATE.Value = Format(CDate(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("CURRENTMONTHF")), "dd/MMM/yyyy")
                    'DTP_TODATE.Value = Format(CDate(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("LASTMONTH")), "dd/MMM/yyyy")
                    'DTP_TDATE.Value = Format(CDate(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("CURRENTMONTH")), "dd/MMM/yyyy")
                    ' '''************************************************* SELECT record from Grn_details *********************************************''''                

                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Enter valid DOC No : TXT_DOCNO_VALIDATED" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End Try
        End If
    End Sub
    '==================================MANISH=======================================
    Private Sub autogenerate()
        Dim sqlstring, financalyear As String
        Try
            'financalyear = Mid(gFinancialyearStarting, 7, 8) & "-" & Mid(gFinancialyearEnding, 7, 8)
            financalyear = Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialyearEnd, 3, 2)
            sqlstring = "SELECT MAX(Cast(SUBSTRING(DOCNO,1,6) As Numeric)) AS DOCNO FROM MESSING_SUMMARY"
            gconnection.getDataSet(sqlstring, "MESSING_SUMMARY")
            If gdataset.Tables("MESSING_SUMMARY").Rows(0).IsNull("DOCNO") = True Then
                'VRNO = "RA\000001\" & financalyear
                TXT_DOCNO.Text = "000001"
            Else
                If gdataset.Tables("MESSING_SUMMARY").Rows.Count > 0 Then
                    'VRNO = "RA\" & Format(Val(gdataset.Tables("JOURNALENTRY").Rows(0).Item("VNO")) + 1, "000000") & "\" & financalyear
                    TXT_DOCNO.Text = Format(Val(gdataset.Tables("MESSING_SUMMARY").Rows(0).Item("DOCNO")) + 1, "000000")
                Else
                    'VRNO = "RA\000001\" & financalyear
                    TXT_DOCNO.Text = "000001"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Public Sub datecalculation()
        If Mid(DTP_MONTH.Value, 4) = 1 Then

        End If
    End Sub
    Private Sub monthf()
        'fromdate = ""
        ' todate = ""
        If Val(Format(DTP_MONTH.Value, "dd/MMM/yyyy")) > 25 Then
            monthnm = Val(Format(DTP_MONTH.Value, "MM/dd/yyyy"))
            If monthnm = 12 Then
                month = 1
            Else
                month = monthnm + 1
            End If
        Else
            month = Val(Format(DTP_MONTH.Value, "MM/dd/yyyy"))
        End If
        If month = 1 Then
            fromdate = "26/Dec/" & gFinancialyearEnd
            todate = "25/Jan/" & gFinancialyearEnd
        ElseIf month = 2 Then
            fromdate = "26/Jan/" & gFinancialyearEnd
            todate = "25/Feb/" & gFinancialyearEnd
        ElseIf month = 3 Then
            fromdate = "26/Feb/" & gFinancialyearEnd
            todate = "25/Mar/" & gFinancalyearStart
        ElseIf month = 4 Then
            fromdate = "26/Mar/" & gFinancalyearStart
            todate = "25/Apr/" & gFinancalyearStart
        ElseIf month = 5 Then
            fromdate = "26/Apr/" & gFinancalyearStart
            todate = "25/May/" & gFinancalyearStart
        ElseIf month = 6 Then
            fromdate = "26/May/" & gFinancalyearStart
            todate = "25/Jun/" & gFinancalyearStart
        ElseIf month = 7 Then
            fromdate = "26/Jun/" & gFinancalyearStart
            todate = "25/Jul/" & gFinancalyearStart
        ElseIf month = 8 Then
            fromdate = "26/Jul/" & gFinancalyearStart
            todate = "25/Aug/" & gFinancalyearStart
        ElseIf month = 9 Then
            fromdate = "26/Aug/" & gFinancalyearStart
            todate = "25/Sep/" & gFinancalyearStart
        ElseIf month = 10 Then
            fromdate = "26/Sep/" & gFinancalyearStart
            todate = "25/Oct/" & gFinancalyearStart
        ElseIf month = 11 Then
            fromdate = "26/Oct/" & gFinancalyearStart
            todate = "25/Nov/" & gFinancalyearStart
        ElseIf month = 12 Then
            fromdate = "26/Nov/" & gFinancalyearStart
            todate = "25/Dec/" & gFinancialyearEnd
        End If
    End Sub
    Private Sub monthfold()
        If Val(Format(DTP_MONTH.Value, "dd/MMM/yyyy")) > 25 Then
            monthnm = Val(Format(DTP_MONTH.Value, "MM/dd/yyyy"))
            If monthnm = 12 Then
                month = 1
            Else
                month = monthnm + 1
            End If
        Else
            month = Val(Format(DTP_MONTH.Value, "MM/dd/yyyy"))
        End If
        If month = 1 Then
            fromdate = "26/Nov/" & gFinancalyearStart
            todate = "25/Dec/" & gFinancialyearEnd
            lastmonth = "25/Dec/" & gFinancialyearEnd
        ElseIf month = 2 Then
            fromdate = "26/Dec/" & gFinancialyearEnd
            todate = "25/Jan/" & gFinancialyearEnd
            lastmonth = "25/Jan/" & gFinancialyearEnd
        ElseIf month = 3 Then
            fromdate = "26/Jan/" & gFinancialyearEnd
            todate = "25/Feb/" & gFinancialyearEnd
            lastmonth = "25/Feb/" & gFinancialyearEnd
        ElseIf month = 4 Then
            fromdate = "26/Feb/" & gFinancalyearStart
            todate = "25/Mar/" & gFinancalyearStart
            lastmonth = "25/Mar/" & gFinancalyearStart
        ElseIf month = 5 Then
            fromdate = "26/Mar/" & gFinancalyearStart
            todate = "25/Apr/" & gFinancalyearStart
            lastmonth = "25/Apr/" & gFinancalyearStart
        ElseIf month = 6 Then
            fromdate = "26/Apr/" & gFinancalyearStart
            todate = "25/May/" & gFinancalyearStart
            lastmonth = "25/May/" & gFinancalyearStart
        ElseIf month = 7 Then
            fromdate = "26/May/" & gFinancalyearStart
            todate = "25/Jun/" & gFinancalyearStart
            lastmonth = "25/Jun/" & gFinancalyearStart
        ElseIf month = 8 Then
            fromdate = "26/Jun/" & gFinancalyearStart
            todate = "25/Jul/" & gFinancalyearStart
        ElseIf month = 9 Then
            fromdate = "26/Jul/" & gFinancalyearStart
            todate = "25/Aug/" & gFinancalyearStart
            lastmonth = "25/Aug/" & gFinancalyearStart
        ElseIf month = 10 Then
            fromdate = "26/Aug/" & gFinancalyearStart
            todate = "25/Sep/" & gFinancalyearStart
            lastmonth = "25/Sep/" & gFinancalyearStart
        ElseIf month = 11 Then
            fromdate = "26/Sep/" & gFinancalyearStart
            todate = "25/Oct/" & gFinancalyearStart
            lastmonth = "25/Oct/" & gFinancalyearStart
        ElseIf month = 12 Then
            fromdate = "26/Oct/" & gFinancalyearStart
            todate = "25/Nov/" & gFinancalyearStart
            lastmonth = "25/Nov/" & gFinancalyearStart
        End If
    End Sub

    Private Sub CMD_TDAMOUNT_Click(sender As Object, e As EventArgs) Handles CMD_TDAMOUNT.Click
        monthf1()
        sqlstring = "SELECT ISNULL(sum(messing),0) AS MESSING FROM td_messing_list WHERE cast(convert(varchar(11),BILLDATE,106) as datetime) BETWEEN "
        sqlstring = sqlstring & " '" & fromdate & "' AND '" & todate & "'"
        gconnection.getDataSet(sqlstring, "td_messing_list")
        If gdataset.Tables("td_messing_list").Rows.Count > 0 Then
            TXT_TDAMOUNT.Text = gdataset.Tables("td_messing_list").Rows(0).Item("Messing")
        Else
            TXT_TDAMOUNT.Text = "0.00"
        End If
    End Sub

    Private Sub CMD_WASTAGEFOOD_Click(sender As Object, e As EventArgs) Handles CMD_WASTAGEFOOD.Click
        sqlstring = "SELECT * FROM WASTAGE_MASTER"
        gconnection.getDataSet(sqlstring, "WASTAGE_MASTER")
        If gdataset.Tables("WASTAGE_MASTER").Rows.Count > 0 Then
            TXT_WASTAGEFOOD.Text = gdataset.Tables("WASTAGE_MASTER").Rows(0).Item("wastageamount")
        Else
            MessageBox.Show("PLEASE ENTER DATA IN THE WASTAGE MASTER")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TXT_TOTAL.Text = (Val(TXT_PURCHASE.Text) + Val(TXT_OLDSTOCK.Text)) - Val(TXT_NEWSTOCK.Text)
    End Sub

    Private Sub BTN_TOTALEXP_Click(sender As Object, e As EventArgs) Handles BTN_TOTALEXP.Click
        'TXT_TOTALEXP.Text = Val(TXT_TOTAL.Text) - (Val(TXT_ISSUE.Text) + Val(TXT_DAMAGE.Text) + Val(TXT_EXPENDITURE.Text) + Val(TXT_TDAMOUNT.Text) + Val(TXT_WASTAGEFOOD.Text))
        If TXT_TOTAL.Text = "" Then
            MessageBox.Show("Total(D) can't be blank")
            Exit Sub
        ElseIf txt_totalE.Text = "" Then
            MessageBox.Show("Total(E) can't be blank")
            Exit Sub
        End If
        TXT_TOTALEXP.Text = Val(TXT_TOTAL.Text) - Val(txt_totalE.Text)
    End Sub

    Private Sub PURCHASE_VIEW_Click(sender As Object, e As EventArgs) Handles PURCHASE_VIEW.Click
        Dim sqlstring, SUPPLIERNAME(), ITEMNAME(), STOREDESC As String
        Dim i As Integer
        Dim r As New Rpt_PurchaseRegister
        Dim rViewer As New Viewer

        Me.Cursor = Cursors.WaitCursor
        monthf1()
        sqlstring = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & CMB_STORECODE.Text & "'"
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        If gdataset.Tables("STOREMASTER").Rows.Count > 0 Then
            STOREDESC = gdataset.Tables("STOREMASTER").Rows(0).Item("STOREDESC")
        End If

        sqlstring = " select distinct  grndetails , grndate,pono ,Supplierinvno, suppliercode , suppliername , totalamount , vatamount , surchargeamt , discountamount , billamount,OVERALLDISCOUNT,STOREDESC  from viewpurchaseregistersummary "
        sqlstring = sqlstring & " where  CATEGORY IN(" & USER & ") "
        'sqlstring = sqlstring & " WHERE  CATEGORY IN(" & USER & ")

        sqlstring = sqlstring & " AND STOREDESC = '" & STOREDESC & "' AND ISNULL(GRNTYPE,'') = 'GRN' "
        'sqlstring = sqlstring & "  AND ISNULL(GRNTYPE,'') = 'GRN' "
        sqlstring = sqlstring & " AND cast(convert(varchar(11),GRNDATE,106) as datetime) BETWEEN"
        sqlstring = sqlstring & " '" & fromdate & "' AND ' " & todate & "'"

        sqlstring = sqlstring & " ORDER BY GRNDATE,GRNDETAILS,SUPPLIERNAME  "

        Me.Cursor = Cursors.WaitCursor
        gconnection.getDataSet(sqlstring, "viewpurchaseregistersummary")
        If gdataset.Tables("viewpurchaseregistersummary").Rows.Count > 0 Then

            rViewer.ssql = sqlstring
            rViewer.Report = r
            rViewer.TableName = "viewpurchaseregistersummary"

            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text3")
            textobj1.Text = MyCompanyName

            Dim textobj5 As TextObject
            textobj5 = r.ReportDefinition.ReportObjects("Text15")
            textobj5.Text = UCase(gCompanyAddress(0))
            Dim textobj6 As TextObject
            textobj6 = r.ReportDefinition.ReportObjects("Text16")
            textobj6.Text = UCase(gCompanyAddress(1))

            Dim textobj4 As TextObject
            textobj4 = r.ReportDefinition.ReportObjects("Text21")
            textobj4.Text = gUsername

            rViewer.Show()

        Else
            MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmd_totale_Click(sender As Object, e As EventArgs) Handles cmd_totale.Click
        If TXT_ISSUE.Text = "" Then

        ElseIf TXT_DAMAGE.Text = "" Then
        ElseIf TXT_EXPENDITURE.Text = "" Then
        ElseIf TXT_WASTAGEFOOD.Text = "" Then
        ElseIf TXT_TDAMOUNT.Text = "" Then
        End If
        txt_totalE.Text = Val(TXT_ISSUE.Text) + Val(TXT_DAMAGE.Text) + Val(txt_servant_total.Text) + Val(TXT_WASTAGEFOOD.Text) + Val(TXT_TDAMOUNT.Text)
    End Sub

    Private Sub cmd_viewns_Click(sender As Object, e As EventArgs) Handles cmd_viewns.Click

    End Sub

    Private Sub servant_total_Click(sender As Object, e As EventArgs) Handles servant_total.Click
        Dim servant As Double
        sqlstring = "select isnull(SUM( isnull(purchaserate,0) * isnull(quantity,0)),0) as servant from Rationmaster where RATIONTYPE='servant'"
        'sqlstring = sqlstring & "where TODATE between '" & fromdate & "' and '" & todate & "' and fromdate between '" & fromdate & "' and '" & todate & "'"
        gconnection.getDataSet(sqlstring, "Rationmaster")
        If gdataset.Tables("Rationmaster").Rows.Count > 0 Then
            'TXT_EXPENDITURE.Text = gdataset.Tables("STOCKEXPENDITUREDETAILS").Rows(0).Item("servant")
            servant = gdataset.Tables("Rationmaster").Rows(0).Item("servant")
        End If
        txt_servant_total.Text = Val(TXT_EXPENDITURE.Text) * Val(servant)
    End Sub

    Private Sub cmd_view_collgfunc_Click(sender As Object, e As EventArgs) Handles cmd_view_collgfunc.Click
        Dim RVIEWER As New Viewer
        Dim R As New Cry_STOCKEXPMESS
        sqlstring = "select isnull(DOCDETAILS,'') as DOCDETAILS, ISNULL(Storelocationdesc,'') AS Storelocationdesc, ISNULL(EXPENDITURE,'') AS EXPENDITURE, ISNULL(collegefunc,0) AS collegefunc  FROM STOCKEXPENDITUREHEADER where ISNULL(VOID,'')<>'Y' AND cast(convert(varchar(11),Docdate,106) as datetime) between "
        sqlstring = sqlstring & "'" & fromdate & "' AND '" & todate & "' and storeLOCATIONcode='" & CMB_STORECODE.Text & "' and collegefunc<>0 ORDER BY DOCDETAILS"
        gconnection.getDataSet(sqlstring, "stock")
        If gdataset.Tables("stock").Rows.Count > 0 Then
            'Dim exp As New exportexcel
            'exp.Show()
            'Call exp.export(sqlstring, "STOCK EXPENDITURE", fromdate)

            'Dim exp As New exportexcel
            'exp.Show()
            'Call exp.export(sqlstring, "STOCK MESSING", fromdate)
            RVIEWER.ssql = sqlstring
            RVIEWER.Report = R
            RVIEWER.TableName = "stock"

            Dim textobj1 As TextObject
            textobj1 = R.ReportDefinition.ReportObjects("Text10")
            textobj1.Text = MyCompanyName

            Dim textobj4 As TextObject
            textobj4 = R.ReportDefinition.ReportObjects("Text13")
            textobj4.Text = gUsername

            RVIEWER.Show()

        Else
            MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub cmd_viewemess_Click(sender As Object, e As EventArgs) Handles cmd_viewemess.Click
        Dim R As New Cr_EMESSING
        Dim rViewer As New Viewer

        Me.Cursor = Cursors.WaitCursor
        sqlstring = "SELECT KOTDETAILS, KOTDATE, ITEMCODE, ITEMDESC, QTY, Rate, AMOUNT FROM KOT_DET WHERE  CATEGORY='EXTRA MESSING'  AND ISNULL(DELFLAG,'')<>'Y' AND ISNULL(KOTSTATUS,'') <>'Y' AND  ISNULL(BILLDETAILS,'')<>'' AND ISNULL(PAYMENTMODE,'') <>'' and POSCODE in (SELECT POSCODE from posmaster) AND CAST(CONVERT(VARCHAR(11),KOTDATE,106) AS DATETIME) BETWEEN  '" & fromdate & "' AND '" & todate & "'"
        gconnection.getDataSet(sqlstring, "stock")
        If gdataset.Tables("stock").Rows.Count > 0 Then
            'Dim exp As New exportexcel
            'exp.Show()
            'Call exp.export(sqlstring, "STOCK MESSING", fromdate)
            rViewer.ssql = sqlstring
            rViewer.Report = r
            rViewer.TableName = "stock"

            Dim textobj1 As TextObject
            textobj1 = R.ReportDefinition.ReportObjects("Text10")
            textobj1.Text = MyCompanyName

            Dim textobj4 As TextObject
            textobj4 = R.ReportDefinition.ReportObjects("Text13")
            textobj4.Text = gUsername
            Me.Cursor = Cursors.WaitCursor
            rViewer.Show()

            
        Else
            MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
        End If
        sqlstring = ""
        sqlstring = "SELECT ISNULL(DOCDETAILS,'') AS DOCDETAILS, ISNULL(DOCDATE,'') AS DOCDATE, ISNULL(STORELOCATIONCODE,'') AS STORELOCATIONCODE, ISNULL(EXPENDITURE,'') AS EXPENDITURE, ISNULL(EXTRAMESSING,0) AS EXTRAMESSING FROM STOCKEXPENDITUREHEADER  WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN  '" & fromdate & "' AND '" & todate & "' AND EXTRAMESSING<>0"
        gconnection.getDataSet(sqlstring, "STOCKEXP")
        If gdataset.Tables("STOCKEXP").Rows.Count > 0 Then
            Dim R1 As New Crys_EXTRMESS
            Dim rViewer1 As New Viewer
            rViewer1.ssql = sqlstring
            rViewer1.Report = R1
            rViewer1.TableName = "stock"

            Dim textobj2 As TextObject
            textobj2 = R1.ReportDefinition.ReportObjects("Text13")
            textobj2.Text = MyCompanyName

            Dim textobj5 As TextObject
            textobj5 = R1.ReportDefinition.ReportObjects("Text21")
            textobj5.Text = gUsername
            'Me.Cursor = Cursors.WaitCursor
            rViewer1.Show()

        End If
    End Sub

    Private Sub monthf1()
        'fromdate = ""
        ' todate = ""
        If Val(Format(DTP_MONTH.Value, "dd/MMM/yyyy")) > 25 Then
            monthnm = Val(Format(DTP_MONTH.Value, "MM/dd/yyyy"))
            If monthnm = 12 Then
                month = 1
            Else
                month = monthnm
            End If
        Else
            month = Val(Format(DTP_MONTH.Value, "MM/dd/yyyy"))
        End If
        If month = 1 Then
            fromdate = "26/Dec/" & gFinancalyearStart
            todate = "25/Jan/" & gFinancialyearEnd
        ElseIf month = 2 Then
            fromdate = "26/Jan/" & gFinancialyearEnd
            todate = "25/Feb/" & gFinancialyearEnd
        ElseIf month = 3 Then
            fromdate = "26/Feb/" & gFinancialyearEnd
            todate = "25/Mar/" & gFinancialyearEnd
        ElseIf month = 4 Then
            fromdate = "26/Mar/" & gFinancalyearStart
            todate = "25/Apr/" & gFinancalyearStart
        ElseIf month = 5 Then
            fromdate = "26/Apr/" & gFinancalyearStart
            todate = "25/May/" & gFinancalyearStart
        ElseIf month = 6 Then
            fromdate = "26/May/" & gFinancalyearStart
            todate = "25/Jun/" & gFinancalyearStart
        ElseIf month = 7 Then
            fromdate = "26/Jun/" & gFinancalyearStart
            todate = "25/Jul/" & gFinancalyearStart
        ElseIf month = 8 Then
            fromdate = "26/Jul/" & gFinancalyearStart
            todate = "25/Aug/" & gFinancalyearStart
        ElseIf month = 9 Then
            fromdate = "26/Aug/" & gFinancalyearStart
            todate = "25/Sep/" & gFinancalyearStart
        ElseIf month = 10 Then
            fromdate = "26/Sep/" & gFinancalyearStart
            todate = "25/Oct/" & gFinancalyearStart
        ElseIf month = 11 Then
            fromdate = "26/Oct/" & gFinancalyearStart
            todate = "25/Nov/" & gFinancalyearStart
        ElseIf month = 12 Then
            fromdate = "26/Nov/" & gFinancalyearStart
            todate = "25/Dec/" & gFinancalyearStart
        End If
    End Sub
End Class
