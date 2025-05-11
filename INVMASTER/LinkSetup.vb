Public Class LinkSetup
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Opt_YES1 As System.Windows.Forms.RadioButton
    Friend WithEvents Opt_NO1 As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents OPT_YES2 As System.Windows.Forms.RadioButton
    Friend WithEvents OPT_N02 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GRNYES As System.Windows.Forms.RadioButton
    Friend WithEvents GRNNO As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OptIndissue1 As System.Windows.Forms.RadioButton
    Friend WithEvents OptIndissue2 As System.Windows.Forms.RadioButton
    Friend WithEvents OptAccpost1 As System.Windows.Forms.RadioButton
    Friend WithEvents OptAccpost2 As System.Windows.Forms.RadioButton
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OPT_TAXYES As System.Windows.Forms.RadioButton
    Friend WithEvents OPT_TAXNO As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDiscAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtOthAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_grn As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents OptSupYes As System.Windows.Forms.RadioButton
    Friend WithEvents OptSupNo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DirIssueY As System.Windows.Forms.RadioButton
    Friend WithEvents DirIssueN As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents CB_AccouctPosingWise As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_ConAllow As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents RBRPYes As System.Windows.Forms.RadioButton
    Friend WithEvents RBRPNo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox19 As GroupBox
    Friend WithEvents OptShelvingN As RadioButton
    Friend WithEvents OptShelvingY As RadioButton
    Friend WithEvents Label19 As Label
    Friend WithEvents GroupBox18 As GroupBox
    Friend WithEvents OptExpiryN As RadioButton
    Friend WithEvents OptExpiryY As RadioButton
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents OptBatchnoN As RadioButton
    Friend WithEvents OptBatchnoY As RadioButton
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox20 As GroupBox
    Friend WithEvents OPT_PO_N As RadioButton
    Friend WithEvents OPT_PO_Y As RadioButton
    Friend WithEvents Label20 As Label
    Friend WithEvents GroupBox21 As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents OPT_INDENT_Y As RadioButton
    Friend WithEvents OPT_INDENT_N As RadioButton
    Friend WithEvents popass As System.Windows.Forms.TextBox
    Friend WithEvents indentpass As System.Windows.Forms.TextBox
    Friend WithEvents btn_view As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LinkSetup))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Opt_NO1 = New System.Windows.Forms.RadioButton()
        Me.Opt_YES1 = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.btn_view = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.OPT_YES2 = New System.Windows.Forms.RadioButton()
        Me.OPT_N02 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GRNYES = New System.Windows.Forms.RadioButton()
        Me.GRNNO = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OptIndissue1 = New System.Windows.Forms.RadioButton()
        Me.OptIndissue2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OptAccpost1 = New System.Windows.Forms.RadioButton()
        Me.OptAccpost2 = New System.Windows.Forms.RadioButton()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OPT_TAXYES = New System.Windows.Forms.RadioButton()
        Me.OPT_TAXNO = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TxtDiscAccountCode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.TxtOthAccountCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Txt_grn = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.OptSupYes = New System.Windows.Forms.RadioButton()
        Me.OptSupNo = New System.Windows.Forms.RadioButton()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DirIssueY = New System.Windows.Forms.RadioButton()
        Me.DirIssueN = New System.Windows.Forms.RadioButton()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.CB_AccouctPosingWise = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.cb_ConAllow = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.RBRPYes = New System.Windows.Forms.RadioButton()
        Me.RBRPNo = New System.Windows.Forms.RadioButton()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.OptShelvingN = New System.Windows.Forms.RadioButton()
        Me.OptShelvingY = New System.Windows.Forms.RadioButton()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.OptExpiryN = New System.Windows.Forms.RadioButton()
        Me.OptExpiryY = New System.Windows.Forms.RadioButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.OptBatchnoN = New System.Windows.Forms.RadioButton()
        Me.OptBatchnoY = New System.Windows.Forms.RadioButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.OPT_PO_N = New System.Windows.Forms.RadioButton()
        Me.OPT_PO_Y = New System.Windows.Forms.RadioButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.OPT_INDENT_Y = New System.Windows.Forms.RadioButton()
        Me.OPT_INDENT_N = New System.Windows.Forms.RadioButton()
        Me.popass = New System.Windows.Forms.TextBox()
        Me.indentpass = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Opt_NO1)
        Me.GroupBox1.Controls.Add(Me.Opt_YES1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(43, 168)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(741, 70)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'Opt_NO1
        '
        Me.Opt_NO1.BackColor = System.Drawing.Color.Transparent
        Me.Opt_NO1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_NO1.Location = New System.Drawing.Point(581, 12)
        Me.Opt_NO1.Name = "Opt_NO1"
        Me.Opt_NO1.Size = New System.Drawing.Size(77, 46)
        Me.Opt_NO1.TabIndex = 16
        Me.Opt_NO1.Text = "NO"
        Me.Opt_NO1.UseVisualStyleBackColor = False
        '
        'Opt_YES1
        '
        Me.Opt_YES1.BackColor = System.Drawing.Color.Transparent
        Me.Opt_YES1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_YES1.Location = New System.Drawing.Point(414, 12)
        Me.Opt_YES1.Name = "Opt_YES1"
        Me.Opt_YES1.Size = New System.Drawing.Size(90, 46)
        Me.Opt_YES1.TabIndex = 15
        Me.Opt_YES1.Text = "YES"
        Me.Opt_YES1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 21)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "PO LINK REQUIRED "
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(298, 25)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(353, 29)
        Me.lbl_Heading.TabIndex = 19
        Me.lbl_Heading.Text = "INVENTORY SETUP  MASTER"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_view
        '
        Me.btn_view.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_view.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_view.FlatAppearance.BorderSize = 0
        Me.btn_view.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btn_view.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_view.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_view.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_view.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_view.ForeColor = System.Drawing.Color.Black
        Me.btn_view.Image = CType(resources.GetObject("btn_view.Image"), System.Drawing.Image)
        Me.btn_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_view.Location = New System.Drawing.Point(14, 89)
        Me.btn_view.Name = "btn_view"
        Me.btn_view.Size = New System.Drawing.Size(199, 67)
        Me.btn_view.TabIndex = 24
        Me.btn_view.Text = "View [F9]"
        Me.btn_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_view.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Exit.FlatAppearance.BorderSize = 0
        Me.Cmd_Exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(14, 161)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(199, 67)
        Me.Cmd_Exit.TabIndex = 23
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Cmd_Add.FlatAppearance.BorderSize = 0
        Me.Cmd_Add.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(14, 18)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(199, 67)
        Me.Cmd_Add.TabIndex = 22
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.FlatAppearance.BorderSize = 0
        Me.Cmd_Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(835, 421)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(199, 67)
        Me.Cmd_Clear.TabIndex = 21
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        Me.Cmd_Clear.Visible = False
        '
        'OPT_YES2
        '
        Me.OPT_YES2.BackColor = System.Drawing.Color.Transparent
        Me.OPT_YES2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPT_YES2.Location = New System.Drawing.Point(294, 35)
        Me.OPT_YES2.Name = "OPT_YES2"
        Me.OPT_YES2.Size = New System.Drawing.Size(103, 47)
        Me.OPT_YES2.TabIndex = 24
        Me.OPT_YES2.Text = "YES"
        Me.OPT_YES2.UseVisualStyleBackColor = False
        '
        'OPT_N02
        '
        Me.OPT_N02.BackColor = System.Drawing.Color.Transparent
        Me.OPT_N02.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPT_N02.Location = New System.Drawing.Point(461, 35)
        Me.OPT_N02.Name = "OPT_N02"
        Me.OPT_N02.Size = New System.Drawing.Size(89, 47)
        Me.OPT_N02.TabIndex = 25
        Me.OPT_N02.Text = "NO"
        Me.OPT_N02.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 21)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "PAYMENT OPTIONS "
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.OPT_YES2)
        Me.GroupBox3.Controls.Add(Me.OPT_N02)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(837, 567)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(208, 76)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.GRNYES)
        Me.GroupBox4.Controls.Add(Me.GRNNO)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(837, 652)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(208, 69)
        Me.GroupBox4.TabIndex = 22
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 21)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "GRNRATE ONLINE"
        '
        'GRNYES
        '
        Me.GRNYES.BackColor = System.Drawing.Color.Transparent
        Me.GRNYES.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRNYES.Location = New System.Drawing.Point(294, 35)
        Me.GRNYES.Name = "GRNYES"
        Me.GRNYES.Size = New System.Drawing.Size(103, 47)
        Me.GRNYES.TabIndex = 24
        Me.GRNYES.Text = "YES"
        Me.GRNYES.UseVisualStyleBackColor = False
        '
        'GRNNO
        '
        Me.GRNNO.BackColor = System.Drawing.Color.Transparent
        Me.GRNNO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRNNO.Location = New System.Drawing.Point(461, 35)
        Me.GRNNO.Name = "GRNNO"
        Me.GRNNO.Size = New System.Drawing.Size(89, 47)
        Me.GRNNO.TabIndex = 25
        Me.GRNNO.Text = "NO"
        Me.GRNNO.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.OptIndissue1)
        Me.GroupBox5.Controls.Add(Me.OptIndissue2)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(43, 228)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(741, 70)
        Me.GroupBox5.TabIndex = 23
        Me.GroupBox5.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(187, 21)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "INDENT WISE ISSUE"
        '
        'OptIndissue1
        '
        Me.OptIndissue1.BackColor = System.Drawing.Color.Transparent
        Me.OptIndissue1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptIndissue1.Location = New System.Drawing.Point(414, 16)
        Me.OptIndissue1.Name = "OptIndissue1"
        Me.OptIndissue1.Size = New System.Drawing.Size(103, 47)
        Me.OptIndissue1.TabIndex = 24
        Me.OptIndissue1.Text = "YES"
        Me.OptIndissue1.UseVisualStyleBackColor = False
        '
        'OptIndissue2
        '
        Me.OptIndissue2.BackColor = System.Drawing.Color.Transparent
        Me.OptIndissue2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptIndissue2.Location = New System.Drawing.Point(581, 16)
        Me.OptIndissue2.Name = "OptIndissue2"
        Me.OptIndissue2.Size = New System.Drawing.Size(89, 47)
        Me.OptIndissue2.TabIndex = 25
        Me.OptIndissue2.Text = "NO"
        Me.OptIndissue2.UseVisualStyleBackColor = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.OptAccpost1)
        Me.GroupBox6.Controls.Add(Me.OptAccpost2)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(43, 403)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(741, 71)
        Me.GroupBox6.TabIndex = 24
        Me.GroupBox6.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(198, 21)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "ACCOUNTS POSTING"
        '
        'OptAccpost1
        '
        Me.OptAccpost1.BackColor = System.Drawing.Color.Transparent
        Me.OptAccpost1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptAccpost1.Location = New System.Drawing.Point(414, 18)
        Me.OptAccpost1.Name = "OptAccpost1"
        Me.OptAccpost1.Size = New System.Drawing.Size(103, 46)
        Me.OptAccpost1.TabIndex = 24
        Me.OptAccpost1.Text = "YES"
        Me.OptAccpost1.UseVisualStyleBackColor = False
        '
        'OptAccpost2
        '
        Me.OptAccpost2.BackColor = System.Drawing.Color.Transparent
        Me.OptAccpost2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptAccpost2.Location = New System.Drawing.Point(581, 18)
        Me.OptAccpost2.Name = "OptAccpost2"
        Me.OptAccpost2.Size = New System.Drawing.Size(89, 46)
        Me.OptAccpost2.TabIndex = 25
        Me.OptAccpost2.Text = "NO"
        Me.OptAccpost2.UseVisualStyleBackColor = False
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_auth.FlatAppearance.BorderSize = 0
        Me.cmd_auth.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_auth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_auth.ForeColor = System.Drawing.Color.Black
        Me.cmd_auth.Image = CType(resources.GetObject("cmd_auth.Image"), System.Drawing.Image)
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.Location = New System.Drawing.Point(835, 494)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(199, 67)
        Me.cmd_auth.TabIndex = 25
        Me.cmd_auth.Text = "Authorize"
        Me.cmd_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_auth.UseVisualStyleBackColor = False
        Me.cmd_auth.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.OPT_TAXYES)
        Me.GroupBox2.Controls.Add(Me.OPT_TAXNO)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(837, 729)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(235, 60)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(222, 21)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "TAX APPLY AT RUNTIME"
        '
        'OPT_TAXYES
        '
        Me.OPT_TAXYES.BackColor = System.Drawing.Color.Transparent
        Me.OPT_TAXYES.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPT_TAXYES.Location = New System.Drawing.Point(294, 35)
        Me.OPT_TAXYES.Name = "OPT_TAXYES"
        Me.OPT_TAXYES.Size = New System.Drawing.Size(103, 47)
        Me.OPT_TAXYES.TabIndex = 24
        Me.OPT_TAXYES.Text = "YES"
        Me.OPT_TAXYES.UseVisualStyleBackColor = False
        '
        'OPT_TAXNO
        '
        Me.OPT_TAXNO.BackColor = System.Drawing.Color.Transparent
        Me.OPT_TAXNO.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPT_TAXNO.Location = New System.Drawing.Point(461, 35)
        Me.OPT_TAXNO.Name = "OPT_TAXNO"
        Me.OPT_TAXNO.Size = New System.Drawing.Size(89, 47)
        Me.OPT_TAXNO.TabIndex = 25
        Me.OPT_TAXNO.Text = "NO"
        Me.OPT_TAXNO.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox7.Controls.Add(Me.btn_view)
        Me.GroupBox7.Controls.Add(Me.Cmd_Add)
        Me.GroupBox7.Location = New System.Drawing.Point(821, 168)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(222, 244)
        Me.GroupBox7.TabIndex = 28
        Me.GroupBox7.TabStop = False
        '
        'TxtDiscAccountCode
        '
        Me.TxtDiscAccountCode.Location = New System.Drawing.Point(382, 67)
        Me.TxtDiscAccountCode.Name = "TxtDiscAccountCode"
        Me.TxtDiscAccountCode.Size = New System.Drawing.Size(271, 26)
        Me.TxtDiscAccountCode.TabIndex = 29
        Me.TxtDiscAccountCode.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(255, 21)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "DISCOUNT ACCOUNT CODE"
        Me.Label7.Visible = False
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.Label7)
        Me.GroupBox9.Controls.Add(Me.TxtOthAccountCode)
        Me.GroupBox9.Controls.Add(Me.TxtDiscAccountCode)
        Me.GroupBox9.Controls.Add(Me.Label8)
        Me.GroupBox9.Location = New System.Drawing.Point(42, 994)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(740, 118)
        Me.GroupBox9.TabIndex = 31
        Me.GroupBox9.TabStop = False
        '
        'TxtOthAccountCode
        '
        Me.TxtOthAccountCode.Location = New System.Drawing.Point(382, 22)
        Me.TxtOthAccountCode.Name = "TxtOthAccountCode"
        Me.TxtOthAccountCode.Size = New System.Drawing.Size(271, 26)
        Me.TxtOthAccountCode.TabIndex = 31
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(257, 21)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "ROUND UP ACCOUNT CODE"
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.Txt_grn)
        Me.GroupBox10.Controls.Add(Me.Label9)
        Me.GroupBox10.Location = New System.Drawing.Point(43, 460)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(743, 66)
        Me.GroupBox10.TabIndex = 32
        Me.GroupBox10.TabStop = False
        '
        'Txt_grn
        '
        Me.Txt_grn.Location = New System.Drawing.Point(382, 22)
        Me.Txt_grn.Name = "Txt_grn"
        Me.Txt_grn.Size = New System.Drawing.Size(271, 26)
        Me.Txt_grn.TabIndex = 31
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 21)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "GRN TYPE"
        '
        'GroupBox11
        '
        Me.GroupBox11.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox11.Controls.Add(Me.Label10)
        Me.GroupBox11.Controls.Add(Me.OptSupYes)
        Me.GroupBox11.Controls.Add(Me.OptSupNo)
        Me.GroupBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.Location = New System.Drawing.Point(43, 285)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(741, 70)
        Me.GroupBox11.TabIndex = 27
        Me.GroupBox11.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(250, 21)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "MULTIPLE SUPPLIER HEAD"
        '
        'OptSupYes
        '
        Me.OptSupYes.BackColor = System.Drawing.Color.Transparent
        Me.OptSupYes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptSupYes.Location = New System.Drawing.Point(414, 16)
        Me.OptSupYes.Name = "OptSupYes"
        Me.OptSupYes.Size = New System.Drawing.Size(103, 47)
        Me.OptSupYes.TabIndex = 24
        Me.OptSupYes.Text = "YES"
        Me.OptSupYes.UseVisualStyleBackColor = False
        '
        'OptSupNo
        '
        Me.OptSupNo.BackColor = System.Drawing.Color.Transparent
        Me.OptSupNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptSupNo.Location = New System.Drawing.Point(581, 16)
        Me.OptSupNo.Name = "OptSupNo"
        Me.OptSupNo.Size = New System.Drawing.Size(89, 47)
        Me.OptSupNo.TabIndex = 25
        Me.OptSupNo.Text = "NO"
        Me.OptSupNo.UseVisualStyleBackColor = False
        '
        'GroupBox12
        '
        Me.GroupBox12.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox12.Controls.Add(Me.Label11)
        Me.GroupBox12.Controls.Add(Me.DirIssueY)
        Me.GroupBox12.Controls.Add(Me.DirIssueN)
        Me.GroupBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.Location = New System.Drawing.Point(43, 345)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(741, 70)
        Me.GroupBox12.TabIndex = 27
        Me.GroupBox12.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(371, 21)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "DIRECT ISSUE OF NONSTOCKABLE ITEM"
        '
        'DirIssueY
        '
        Me.DirIssueY.BackColor = System.Drawing.Color.Transparent
        Me.DirIssueY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DirIssueY.Location = New System.Drawing.Point(414, 19)
        Me.DirIssueY.Name = "DirIssueY"
        Me.DirIssueY.Size = New System.Drawing.Size(103, 47)
        Me.DirIssueY.TabIndex = 24
        Me.DirIssueY.Text = "YES"
        Me.DirIssueY.UseVisualStyleBackColor = False
        '
        'DirIssueN
        '
        Me.DirIssueN.BackColor = System.Drawing.Color.Transparent
        Me.DirIssueN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DirIssueN.Location = New System.Drawing.Point(581, 19)
        Me.DirIssueN.Name = "DirIssueN"
        Me.DirIssueN.Size = New System.Drawing.Size(89, 47)
        Me.DirIssueN.TabIndex = 25
        Me.DirIssueN.Text = "NO"
        Me.DirIssueN.UseVisualStyleBackColor = False
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox13.Controls.Add(Me.CB_AccouctPosingWise)
        Me.GroupBox13.Controls.Add(Me.Label12)
        Me.GroupBox13.Location = New System.Drawing.Point(43, 519)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(741, 70)
        Me.GroupBox13.TabIndex = 33
        Me.GroupBox13.TabStop = False
        '
        'CB_AccouctPosingWise
        '
        Me.CB_AccouctPosingWise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_AccouctPosingWise.FormattingEnabled = True
        Me.CB_AccouctPosingWise.Items.AddRange(New Object() {"ITEM", "CATEGORY", "STORE"})
        Me.CB_AccouctPosingWise.Location = New System.Drawing.Point(382, 26)
        Me.CB_AccouctPosingWise.Name = "CB_AccouctPosingWise"
        Me.CB_AccouctPosingWise.Size = New System.Drawing.Size(271, 28)
        Me.CB_AccouctPosingWise.TabIndex = 33
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(148, 21)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "POSTING FIELD"
        '
        'GroupBox14
        '
        Me.GroupBox14.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox14.Controls.Add(Me.cb_ConAllow)
        Me.GroupBox14.Controls.Add(Me.Label13)
        Me.GroupBox14.Controls.Add(Me.GroupBox15)
        Me.GroupBox14.Controls.Add(Me.GroupBox16)
        Me.GroupBox14.Location = New System.Drawing.Point(43, 579)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(741, 80)
        Me.GroupBox14.TabIndex = 34
        Me.GroupBox14.TabStop = False
        '
        'cb_ConAllow
        '
        Me.cb_ConAllow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_ConAllow.FormattingEnabled = True
        Me.cb_ConAllow.Items.AddRange(New Object() {"MAIN STORE", "SUB STORE", "BOTH"})
        Me.cb_ConAllow.Location = New System.Drawing.Point(382, 26)
        Me.cb_ConAllow.Name = "cb_ConAllow"
        Me.cb_ConAllow.Size = New System.Drawing.Size(271, 28)
        Me.cb_ConAllow.TabIndex = 33
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(215, 21)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "CONSUMPTION ALLOW"
        '
        'GroupBox15
        '
        Me.GroupBox15.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox15.Controls.Add(Me.TextBox1)
        Me.GroupBox15.Controls.Add(Me.Label14)
        Me.GroupBox15.Location = New System.Drawing.Point(45, 155)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(757, 66)
        Me.GroupBox15.TabIndex = 31
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(397, 22)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(238, 26)
        Me.TextBox1.TabIndex = 31
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(30, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(303, 21)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "OTHER CHARGEACCOUNT CODE"
        '
        'GroupBox16
        '
        Me.GroupBox16.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox16.Controls.Add(Me.Label15)
        Me.GroupBox16.Controls.Add(Me.TextBox2)
        Me.GroupBox16.Location = New System.Drawing.Point(43, 86)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(759, 82)
        Me.GroupBox16.TabIndex = 30
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(27, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(255, 21)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "DISCOUNT ACCOUNT CODE"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(395, 20)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(271, 26)
        Me.TextBox2.TabIndex = 29
        '
        'GroupBox17
        '
        Me.GroupBox17.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox17.Controls.Add(Me.Label16)
        Me.GroupBox17.Controls.Add(Me.RBRPYes)
        Me.GroupBox17.Controls.Add(Me.RBRPNo)
        Me.GroupBox17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox17.Location = New System.Drawing.Point(42, 824)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(740, 70)
        Me.GroupBox17.TabIndex = 35
        Me.GroupBox17.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(187, 21)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "ROUNDUP POSTING"
        '
        'RBRPYes
        '
        Me.RBRPYes.BackColor = System.Drawing.Color.Transparent
        Me.RBRPYes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBRPYes.Location = New System.Drawing.Point(414, 18)
        Me.RBRPYes.Name = "RBRPYes"
        Me.RBRPYes.Size = New System.Drawing.Size(103, 46)
        Me.RBRPYes.TabIndex = 24
        Me.RBRPYes.Text = "YES"
        Me.RBRPYes.UseVisualStyleBackColor = False
        '
        'RBRPNo
        '
        Me.RBRPNo.BackColor = System.Drawing.Color.Transparent
        Me.RBRPNo.Checked = True
        Me.RBRPNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBRPNo.Location = New System.Drawing.Point(581, 18)
        Me.RBRPNo.Name = "RBRPNo"
        Me.RBRPNo.Size = New System.Drawing.Size(89, 46)
        Me.RBRPNo.TabIndex = 25
        Me.RBRPNo.TabStop = True
        Me.RBRPNo.Text = "NO"
        Me.RBRPNo.UseVisualStyleBackColor = False
        '
        'GroupBox19
        '
        Me.GroupBox19.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox19.Controls.Add(Me.OptShelvingN)
        Me.GroupBox19.Controls.Add(Me.OptShelvingY)
        Me.GroupBox19.Controls.Add(Me.Label19)
        Me.GroupBox19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox19.Location = New System.Drawing.Point(42, 769)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(740, 58)
        Me.GroupBox19.TabIndex = 39
        Me.GroupBox19.TabStop = False
        '
        'OptShelvingN
        '
        Me.OptShelvingN.AutoSize = True
        Me.OptShelvingN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptShelvingN.Location = New System.Drawing.Point(581, 20)
        Me.OptShelvingN.Name = "OptShelvingN"
        Me.OptShelvingN.Size = New System.Drawing.Size(62, 25)
        Me.OptShelvingN.TabIndex = 24
        Me.OptShelvingN.TabStop = True
        Me.OptShelvingN.Text = "NO"
        Me.OptShelvingN.UseVisualStyleBackColor = True
        '
        'OptShelvingY
        '
        Me.OptShelvingY.AutoSize = True
        Me.OptShelvingY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptShelvingY.Location = New System.Drawing.Point(414, 19)
        Me.OptShelvingY.Name = "OptShelvingY"
        Me.OptShelvingY.Size = New System.Drawing.Size(72, 25)
        Me.OptShelvingY.TabIndex = 23
        Me.OptShelvingY.TabStop = True
        Me.OptShelvingY.Text = "YES"
        Me.OptShelvingY.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(14, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(212, 21)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = " SHELVING REQUIRED "
        '
        'GroupBox18
        '
        Me.GroupBox18.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox18.Controls.Add(Me.OptExpiryN)
        Me.GroupBox18.Controls.Add(Me.OptExpiryY)
        Me.GroupBox18.Controls.Add(Me.Label18)
        Me.GroupBox18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox18.Location = New System.Drawing.Point(42, 713)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(740, 59)
        Me.GroupBox18.TabIndex = 38
        Me.GroupBox18.TabStop = False
        '
        'OptExpiryN
        '
        Me.OptExpiryN.AutoSize = True
        Me.OptExpiryN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptExpiryN.Location = New System.Drawing.Point(581, 20)
        Me.OptExpiryN.Name = "OptExpiryN"
        Me.OptExpiryN.Size = New System.Drawing.Size(62, 25)
        Me.OptExpiryN.TabIndex = 24
        Me.OptExpiryN.TabStop = True
        Me.OptExpiryN.Text = "NO"
        Me.OptExpiryN.UseVisualStyleBackColor = True
        '
        'OptExpiryY
        '
        Me.OptExpiryY.AutoSize = True
        Me.OptExpiryY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptExpiryY.Location = New System.Drawing.Point(414, 19)
        Me.OptExpiryY.Name = "OptExpiryY"
        Me.OptExpiryY.Size = New System.Drawing.Size(72, 25)
        Me.OptExpiryY.TabIndex = 23
        Me.OptExpiryY.TabStop = True
        Me.OptExpiryY.Text = "YES"
        Me.OptExpiryY.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(14, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(234, 21)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "EXPIRY DATE REQUIRED "
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.OptBatchnoN)
        Me.GroupBox8.Controls.Add(Me.OptBatchnoY)
        Me.GroupBox8.Controls.Add(Me.Label17)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(43, 656)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(741, 59)
        Me.GroupBox8.TabIndex = 37
        Me.GroupBox8.TabStop = False
        '
        'OptBatchnoN
        '
        Me.OptBatchnoN.AutoSize = True
        Me.OptBatchnoN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptBatchnoN.Location = New System.Drawing.Point(581, 22)
        Me.OptBatchnoN.Name = "OptBatchnoN"
        Me.OptBatchnoN.Size = New System.Drawing.Size(62, 25)
        Me.OptBatchnoN.TabIndex = 19
        Me.OptBatchnoN.TabStop = True
        Me.OptBatchnoN.Text = "NO"
        Me.OptBatchnoN.UseVisualStyleBackColor = True
        '
        'OptBatchnoY
        '
        Me.OptBatchnoY.AutoSize = True
        Me.OptBatchnoY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptBatchnoY.Location = New System.Drawing.Point(414, 20)
        Me.OptBatchnoY.Name = "OptBatchnoY"
        Me.OptBatchnoY.Size = New System.Drawing.Size(72, 25)
        Me.OptBatchnoY.TabIndex = 18
        Me.OptBatchnoY.TabStop = True
        Me.OptBatchnoY.Text = "YES"
        Me.OptBatchnoY.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(209, 21)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "BATCH NO. REQUIRED"
        '
        'GroupBox20
        '
        Me.GroupBox20.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox20.Controls.Add(Me.OPT_PO_N)
        Me.GroupBox20.Controls.Add(Me.OPT_PO_Y)
        Me.GroupBox20.Controls.Add(Me.Label20)
        Me.GroupBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox20.Location = New System.Drawing.Point(42, 881)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(740, 59)
        Me.GroupBox20.TabIndex = 41
        Me.GroupBox20.TabStop = False
        '
        'OPT_PO_N
        '
        Me.OPT_PO_N.AutoSize = True
        Me.OPT_PO_N.Checked = True
        Me.OPT_PO_N.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPT_PO_N.Location = New System.Drawing.Point(581, 20)
        Me.OPT_PO_N.Name = "OPT_PO_N"
        Me.OPT_PO_N.Size = New System.Drawing.Size(62, 25)
        Me.OPT_PO_N.TabIndex = 24
        Me.OPT_PO_N.TabStop = True
        Me.OPT_PO_N.Text = "NO"
        Me.OPT_PO_N.UseVisualStyleBackColor = True
        '
        'OPT_PO_Y
        '
        Me.OPT_PO_Y.AutoSize = True
        Me.OPT_PO_Y.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPT_PO_Y.Location = New System.Drawing.Point(414, 19)
        Me.OPT_PO_Y.Name = "OPT_PO_Y"
        Me.OPT_PO_Y.Size = New System.Drawing.Size(72, 25)
        Me.OPT_PO_Y.TabIndex = 23
        Me.OPT_PO_Y.Text = "YES"
        Me.OPT_PO_Y.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(14, 23)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(140, 21)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "PO APPROVAL"
        '
        'GroupBox21
        '
        Me.GroupBox21.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox21.Controls.Add(Me.Label21)
        Me.GroupBox21.Controls.Add(Me.OPT_INDENT_Y)
        Me.GroupBox21.Controls.Add(Me.OPT_INDENT_N)
        Me.GroupBox21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox21.Location = New System.Drawing.Point(42, 937)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(740, 70)
        Me.GroupBox21.TabIndex = 40
        Me.GroupBox21.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(13, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(181, 21)
        Me.Label21.TabIndex = 26
        Me.Label21.Text = "INDENT APPROVAL"
        '
        'OPT_INDENT_Y
        '
        Me.OPT_INDENT_Y.BackColor = System.Drawing.Color.Transparent
        Me.OPT_INDENT_Y.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPT_INDENT_Y.Location = New System.Drawing.Point(414, 18)
        Me.OPT_INDENT_Y.Name = "OPT_INDENT_Y"
        Me.OPT_INDENT_Y.Size = New System.Drawing.Size(103, 46)
        Me.OPT_INDENT_Y.TabIndex = 24
        Me.OPT_INDENT_Y.Text = "YES"
        Me.OPT_INDENT_Y.UseVisualStyleBackColor = False
        '
        'OPT_INDENT_N
        '
        Me.OPT_INDENT_N.BackColor = System.Drawing.Color.Transparent
        Me.OPT_INDENT_N.Checked = True
        Me.OPT_INDENT_N.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPT_INDENT_N.Location = New System.Drawing.Point(581, 18)
        Me.OPT_INDENT_N.Name = "OPT_INDENT_N"
        Me.OPT_INDENT_N.Size = New System.Drawing.Size(89, 46)
        Me.OPT_INDENT_N.TabIndex = 25
        Me.OPT_INDENT_N.TabStop = True
        Me.OPT_INDENT_N.Text = "NO"
        Me.OPT_INDENT_N.UseVisualStyleBackColor = False
        '
        'popass
        '
        Me.popass.Location = New System.Drawing.Point(795, 899)
        Me.popass.Name = "popass"
        Me.popass.Size = New System.Drawing.Size(271, 26)
        Me.popass.TabIndex = 32
        '
        'indentpass
        '
        Me.indentpass.Location = New System.Drawing.Point(795, 963)
        Me.indentpass.Name = "indentpass"
        Me.indentpass.Size = New System.Drawing.Size(271, 26)
        Me.indentpass.TabIndex = 42
        '
        'LinkSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1102, 1106)
        Me.Controls.Add(Me.indentpass)
        Me.Controls.Add(Me.popass)
        Me.Controls.Add(Me.GroupBox20)
        Me.Controls.Add(Me.GroupBox21)
        Me.Controls.Add(Me.GroupBox19)
        Me.Controls.Add(Me.GroupBox18)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.cmd_auth)
        Me.Controls.Add(Me.GroupBox17)
        Me.Controls.Add(Me.GroupBox14)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "LinkSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
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
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
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
        J = 706
        K = 1018
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
                        If Controls(i_i).Name = "GroupBox7" Then
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
                        ElseIf Controls(i_i).Name = "GroupBo" Then
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

    Private Sub LinkSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'OPT_N02.Checked = True
        'Opt_NO1.Checked = True
        'Resize_Form()
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If
        ' Me.DoubleBuffered = True
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        sqlstring = "SELECT isnull(POFLAG,'N') as POFLAG,isnull(ACCPOSTFLAG,'N') as ACCPOSTFLAG,isnull(INDENTISSFLAG,'N')as INDENTISSFLAG,grntype,isnull(Adduser,'') as Adduser,Adddatetime,ISNULL(DISCaccountcode,'') AS DISCaccountcode,ISNULL(OTHACCOUNTCODE,'') AS OTHACCOUNTCODE,isnull(Msupplier,'N') as Msupplier,isnull(dirissue,'N') as dirissue,ISNULL(accountpostingWise,'STORE') accountpostingWise,ISNULL(CONSUMPTIONALLOW,'SUB STORE') AS CONSUMPTIONALLOW,ISNULL(ROUNDUPYESNO,'N') AS ROUNDUPYESNO,ISNULL(BatchnoReq,'N') AS BatchnoReq,ISNULL(ExpiryReq,'N') AS ExpiryReq,ISNULL(ShelvingReq,'N') AS ShelvingReq,ISNULL(POAPPROVAL,'N') AS POAPPROVAL,ISNULL(INDENTAPPROVAL,'N') AS INDENTAPPROVAL,isnull(po_password,'')as po_password,isnull(indent_password,'')as indent_password  FROM INV_LINKSETUP"
        gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
        If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("POFLAG")) = "Y" Then
                Opt_YES1.Checked = True
            Else
                Opt_NO1.Checked = True
            End If

            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("ACCPOSTFLAG")) = "Y" Then
                OptAccpost1.Checked = True
            Else
                OptAccpost2.Checked = True
            End If
            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("INDENTISSFLAG")) = "Y" Then
                OptIndissue1.Checked = True
            Else
                OptIndissue2.Checked = True
            End If
            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("MSupplier")) = "Y" Then
                OptSupYes.Checked = True
            Else
                OptSupNo.Checked = True
            End If
            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("dirissue")) = "Y" Then
                DirIssueY.Checked = True
            Else
                DirIssueN.Checked = True
            End If
            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("ROUNDUPYESNO")) = "Y" Then
                RBRPYes.Checked = True
                GroupBox9.Visible = True
            Else
                RBRPNo.Checked = True
                GroupBox9.Visible = False
            End If
            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("BatchnoReq")) = "Y" Then
                OptBatchnoY.Checked = True
            Else
                OptBatchnoN.Checked = True
            End If
            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("ExpiryReq")) = "Y" Then
                OptExpiryY.Checked = True
            Else
                OptExpiryN.Checked = True
            End If
            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("ShelvingReq")) = "Y" Then
                OptShelvingY.Checked = True
            Else
                OptShelvingN.Checked = True
            End If
            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("POAPPROVAL")) = "Y" Then
                OPT_PO_Y.Checked = True
            Else
                OPT_PO_N.Checked = True
            End If
            If Trim(gdataset.Tables("INV_LINKSETUP").Rows(0).Item("INDENTAPPROVAL")) = "Y" Then
                OPT_INDENT_Y.Checked = True
            Else
                OPT_INDENT_N.Checked = True
            End If
            CB_AccouctPosingWise.Text = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("accountpostingWise").ToString()
            cb_ConAllow.Text = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("CONSUMPTIONALLOW").ToString()
            Txt_grn.Text = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("grntype").ToString()
            TxtDiscAccountCode.Text = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("DISCaccountcode").ToString()
            TxtOthAccountCode.Text = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("OTHACCOUNTCODE").ToString()
            popass.Text = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("po_password").ToString()
            indentpass.Text = gdataset.Tables("INV_LINKSETUP").Rows(0).Item("indent_password").ToString()
        End If

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click


        If MsgBox("After Add Application will be closed. do u want continue..", MsgBoxStyle.Question + MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, Me.Text) = MsgBoxResult.Ok Then


            Dim strSQL As String
            Dim INSERT(0) As String
            Dim boolchk As Boolean
            If Cmd_Add.Text = "Add [F7]" Then
                ' Call checkValidation() '''--->Check Validation
                '    If boolchk = False Then Exit Sub


                If GroupBox9.Visible = True And (TxtOthAccountCode.Text = "") Then

                    MessageBox.Show("Please fill  A/C Code ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    If GroupBox9.Visible = True Then
                        'strSQL = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster "
                        'strSQL = strSQL & " where Accode='" + Trim(TxtDiscAccountCode.Text) + "' and isnull(freezeflag,'') <> 'Y' "
                        'gconnection.getDataSet(strSQL, "Accountsglaccountmaster")
                        'If gdataset.Tables("Accountsglaccountmaster").Rows.Count > 0 Then

                        'Else
                        '    MessageBox.Show("Please fill Valied A/C Code for Discount A/C ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        '    Exit Sub
                        'End If

                        strSQL = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster "
                        strSQL = strSQL & " where Accode='" + Trim(TxtOthAccountCode.Text) + "' and isnull(freezeflag,'') <> 'Y' "
                        gconnection.getDataSet(strSQL, "Accountsglaccountmaster")
                        If gdataset.Tables("Accountsglaccountmaster").Rows.Count > 0 Then

                        Else
                            MessageBox.Show("Please fill Valied A/C Code for Other Ch. ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If


                End If


                sqlstring = "SELECT * FROM INV_LINKSETUP"
                gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
                If gdataset.Tables("INV_LINKSETUP").Rows.Count > 0 Then
                    sqlstring = "DELETE FROM INV_LINKSETUP"
                    gconnection.getDataSet(sqlstring, "INV_LINKSETUP")
                End If
                strSQL = " INSERT INTO INV_LINKSETUP (POFLAG,ACCPOSTFLAG,INDENTISSFLAG,grntype,Adduser,Adddatetime,DISCaccountcode,OTHACCOUNTCODE,po_password,indent_password,Msupplier,DirIssue,accountpostingWise,CONSUMPTIONALLOW,ROUNDUPYESNO,BatchnoReq,ExpiryReq,ShelvingReq,POAPPROVAL,INDENTAPPROVAL)"
                strSQL = strSQL & " VALUES ( "
                If Opt_YES1.Checked = True Then
                    strSQL = strSQL & " 'Y', "
                Else
                    strSQL = strSQL & " 'N', "
                End If
                If OptAccpost1.Checked = True Then
                    strSQL = strSQL & " 'Y', "
                Else
                    strSQL = strSQL & " 'N', "
                End If

                If OptIndissue1.Checked = True Then
                    strSQL = strSQL & " 'Y', "
                Else
                    strSQL = strSQL & " 'N', "
                End If
                strSQL = strSQL & " '" & Txt_grn.Text & "',"
                strSQL = strSQL & " '" & Trim(gUsername) & "',getDate(),'" & TxtDiscAccountCode.Text & "','" & TxtOthAccountCode.Text & "','" & popass.Text & "','" & indentpass.Text & "',"

                If OptSupYes.Checked = True Then
                    strSQL = strSQL & " 'Y', "
                Else
                    strSQL = strSQL & " 'N', "
                End If
                If DirIssueY.Checked = True Then
                    strSQL = strSQL & " 'Y' ,"
                Else
                    strSQL = strSQL & " 'N' ,"
                End If
                If CB_AccouctPosingWise.Text = "" Then
                    strSQL = strSQL & " 'STORE',"
                Else
                    strSQL = strSQL & "'" & Trim(CB_AccouctPosingWise.Text) & "',"
                End If
                If cb_ConAllow.Text = "" Then
                    strSQL = strSQL & " 'SUB STORE',"
                Else
                    strSQL = strSQL & "'" & Trim(cb_ConAllow.Text) & "',"
                End If

                If RBRPYes.Checked = True Then
                    strSQL = strSQL & " 'Y', "
                Else
                    strSQL = strSQL & " 'N', "
                End If
                If OptBatchnoY.Checked = True Then
                    strSQL = strSQL & " 'Y' , "
                Else
                    strSQL = strSQL & " 'N' , "
                End If
                If OptExpiryY.Checked = True Then
                    strSQL = strSQL & " 'Y' , "
                Else
                    strSQL = strSQL & " 'N' , "
                End If
                If OptShelvingY.Checked = True Then
                    strSQL = strSQL & " 'Y', "
                Else
                    strSQL = strSQL & " 'N', "
                End If
                If OPT_PO_Y.Checked = True Then
                    strSQL = strSQL & " 'Y' , "
                Else
                    strSQL = strSQL & " 'N' , "
                End If
                If OPT_INDENT_Y.Checked = True Then
                    strSQL = strSQL & " 'Y' "
                Else
                    strSQL = strSQL & " 'N' "
                End If
                strSQL = strSQL & " )"
                'gconnection.dataOperation(1, strSQL, "INV_LINKSETUP")
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL
                'strSQL = "INSERT INTO invsetup (GRNRATEONLINE) VALUES ( "
                'If GRNYES.Checked = True Then
                '    strSQL = strSQL & " 'Y') "
                'ElseIf GRNNO.Checked = False Then
                '    strSQL = strSQL & " 'N') "
                'End If
                'ReDim Preserve INSERT(INSERT.Length)
                'INSERT(INSERT.Length - 1) = strSQL
                gconnection.MoreTrans(INSERT)
                Me.Cmd_Clear_Click(sender, e)

            End If
            Application.Exit()
        End If
        'Dim cmp As New CompanyList1
        'cmp.Show()
    End Sub


    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            Me.cmd_auth.Enabled = False
            'Me.Cmd_Freeze.Enabled = False
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub LinkSetup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 And btn_view.Visible = True Then
            Call btn_view_Click(btn_view, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub



    Private Sub cmd_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_auth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        Dim USERT As Integer
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='INVENTORY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
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
            SSQLSTR2 = " SELECT * FROM INV_LINKSETUP WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM INV_LINKSETUP  WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE INV_LINKSETUP set  ", "posetup", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM INV_LINKSETUP WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM INV_LINKSETUP WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE INV_LINKSETUP set  ", "posetup", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM INV_LINKSETUP WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM INV_LINKSETUP  WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE INV_LINKSETUP  set  ", "posetup", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub


    Private Sub btn_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_view.Click
        Dim FRM As New ReportDesigner
        'If txt_StoreCode.Text.Length > 0 Then
        '    tables = " FROM INV_LINKSETUP WHERE PO ='" & txt_StoreCode.Text & "' "
        'Else
        tables = "FROM INV_LINKSETUP "
        'End If
        Gheader = "LINKSETUP DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"POflag", "8"}

        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ACCPOSTFLAG", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"INDENTISSFLAG", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Discaccountcode", "15"}
        FRM.DataGridView1.Rows.Add(ROW)

        ROW = New String() {"othaccountcode", "15"}
        FRM.DataGridView1.Rows.Add(ROW)

        ROW = New String() {"Adduser", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adddatetime", "11"}



        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UPDATEUSER", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UPDATETIME", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Function txt_StoreCode() As Object
        Throw New NotImplementedException
    End Function

    Private Sub RBRPYes_Validated(sender As Object, e As EventArgs) Handles RBRPYes.Validated
        'If RBRPYes.Checked = True Then
        '    GroupBox9.Visible = True
        'Else
        '    GroupBox9.Visible = False
        'End If
    End Sub

    Private Sub RBRPNo_Validated(sender As Object, e As EventArgs) Handles RBRPNo.Validated
        'If RBRPNo.Checked = True Then
        '    GroupBox9.Visible = False
        'Else
        '    GroupBox9.Visible = True
        'End If
    End Sub

    Private Sub RBRPYes_CheckedChanged(sender As Object, e As EventArgs) Handles RBRPYes.CheckedChanged
        If RBRPYes.Checked = True Then
            GroupBox9.Visible = True
        Else
            GroupBox9.Visible = False
        End If
    End Sub

    Private Sub RBRPNo_CheckedChanged(sender As Object, e As EventArgs) Handles RBRPNo.CheckedChanged
        If RBRPNo.Checked = True Then
            GroupBox9.Visible = False
        Else
            GroupBox9.Visible = True
        End If
    End Sub

    Private Sub Opt_YES1_CheckedChanged(sender As Object, e As EventArgs) Handles Opt_YES1.CheckedChanged

    End Sub
End Class
