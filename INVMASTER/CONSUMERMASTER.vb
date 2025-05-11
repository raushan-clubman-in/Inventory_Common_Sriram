Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Public Class CONSUMERMASTER
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
    Friend WithEvents lbl_Docno As System.Windows.Forms.Label
    Friend WithEvents txt_CONno As System.Windows.Forms.TextBox
    Friend WithEvents cbo_CONTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Storelocation As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXT_CONNAME As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents CMD_RPT As System.Windows.Forms.Button
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmD_CONNOHELP As System.Windows.Forms.Button
    Friend WithEvents cmd_auth As System.Windows.Forms.Button
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents btn_auth As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CONSUMERMASTER))
        Me.lbl_Docno = New System.Windows.Forms.Label()
        Me.txt_CONno = New System.Windows.Forms.TextBox()
        Me.cbo_CONTYPE = New System.Windows.Forms.ComboBox()
        Me.lbl_Storelocation = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXT_CONNAME = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmD_CONNOHELP = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_auth = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.CMD_RPT = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.cmd_auth = New System.Windows.Forms.Button()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.frmbut.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Docno
        '
        Me.lbl_Docno.AutoSize = True
        Me.lbl_Docno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Docno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Docno.Location = New System.Drawing.Point(36, 26)
        Me.lbl_Docno.Name = "lbl_Docno"
        Me.lbl_Docno.Size = New System.Drawing.Size(108, 15)
        Me.lbl_Docno.TabIndex = 10
        Me.lbl_Docno.Text = "CONSUMER CODE"
        '
        'txt_CONno
        '
        Me.txt_CONno.BackColor = System.Drawing.Color.Wheat
        Me.txt_CONno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_CONno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txt_CONno.Location = New System.Drawing.Point(167, 26)
        Me.txt_CONno.MaxLength = 30
        Me.txt_CONno.Name = "txt_CONno"
        Me.txt_CONno.Size = New System.Drawing.Size(104, 26)
        Me.txt_CONno.TabIndex = 13
        '
        'cbo_CONTYPE
        '
        Me.cbo_CONTYPE.BackColor = System.Drawing.Color.Wheat
        Me.cbo_CONTYPE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cbo_CONTYPE.ItemHeight = 19
        Me.cbo_CONTYPE.Items.AddRange(New Object() {"MAN", "MACHINE"})
        Me.cbo_CONTYPE.Location = New System.Drawing.Point(167, 90)
        Me.cbo_CONTYPE.Name = "cbo_CONTYPE"
        Me.cbo_CONTYPE.Size = New System.Drawing.Size(112, 27)
        Me.cbo_CONTYPE.TabIndex = 11
        '
        'lbl_Storelocation
        '
        Me.lbl_Storelocation.AutoSize = True
        Me.lbl_Storelocation.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Storelocation.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Storelocation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Storelocation.Location = New System.Drawing.Point(36, 90)
        Me.lbl_Storelocation.Name = "lbl_Storelocation"
        Me.lbl_Storelocation.Size = New System.Drawing.Size(105, 15)
        Me.lbl_Storelocation.TabIndex = 12
        Me.lbl_Storelocation.Text = "CONSUMER TYPE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(36, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "CONSUMER NAME"
        '
        'TXT_CONNAME
        '
        Me.TXT_CONNAME.BackColor = System.Drawing.Color.Wheat
        Me.TXT_CONNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_CONNAME.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TXT_CONNAME.Location = New System.Drawing.Point(167, 58)
        Me.TXT_CONNAME.MaxLength = 100
        Me.TXT_CONNAME.Name = "TXT_CONNAME"
        Me.TXT_CONNAME.Size = New System.Drawing.Size(200, 26)
        Me.TXT_CONNAME.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.cmD_CONNOHELP)
        Me.GroupBox1.Controls.Add(Me.lbl_Docno)
        Me.GroupBox1.Controls.Add(Me.cbo_CONTYPE)
        Me.GroupBox1.Controls.Add(Me.lbl_Storelocation)
        Me.GroupBox1.Controls.Add(Me.txt_CONno)
        Me.GroupBox1.Controls.Add(Me.TXT_CONNAME)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(46, 143)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 136)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        '
        'cmD_CONNOHELP
        '
        Me.cmD_CONNOHELP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmD_CONNOHELP.Image = CType(resources.GetObject("cmD_CONNOHELP.Image"), System.Drawing.Image)
        Me.cmD_CONNOHELP.Location = New System.Drawing.Point(277, 26)
        Me.cmD_CONNOHELP.Name = "cmD_CONNOHELP"
        Me.cmD_CONNOHELP.Size = New System.Drawing.Size(23, 26)
        Me.cmD_CONNOHELP.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(230, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(224, 23)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "CONSUMER MASTER"
        '
        'btn_auth
        '
        Me.btn_auth.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btn_auth.FlatAppearance.BorderSize = 0
        Me.btn_auth.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btn_auth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_auth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_auth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_auth.ForeColor = System.Drawing.Color.Black
        Me.btn_auth.Image = CType(resources.GetObject("btn_auth.Image"), System.Drawing.Image)
        Me.btn_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_auth.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_auth.Location = New System.Drawing.Point(4, 348)
        Me.btn_auth.Name = "btn_auth"
        Me.btn_auth.Size = New System.Drawing.Size(124, 46)
        Me.btn_auth.TabIndex = 29
        Me.btn_auth.Text = "Authorize"
        Me.btn_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_auth.UseVisualStyleBackColor = False
        Me.btn_auth.Visible = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Clear.FlatAppearance.BorderSize = 0
        Me.Cmd_Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cmd_Clear.Location = New System.Drawing.Point(4, 11)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Clear.TabIndex = 24
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_View.FlatAppearance.BorderSize = 0
        Me.Cmd_View.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cmd_View.Location = New System.Drawing.Point(4, 155)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_View.TabIndex = 27
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Freeze.FlatAppearance.BorderSize = 0
        Me.Cmd_Freeze.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cmd_Freeze.Location = New System.Drawing.Point(4, 107)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Freeze.TabIndex = 26
        Me.Cmd_Freeze.Text = "Void [F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Add.FlatAppearance.BorderSize = 0
        Me.Cmd_Add.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cmd_Add.Location = New System.Drawing.Point(4, 59)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Add.TabIndex = 25
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
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
        Me.Cmd_Exit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Cmd_Exit.Location = New System.Drawing.Point(4, 299)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Exit.TabIndex = 28
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_export.FlatAppearance.BorderSize = 0
        Me.cmd_export.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Image = CType(resources.GetObject("cmd_export.Image"), System.Drawing.Image)
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmd_export.Location = New System.Drawing.Point(4, 251)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(124, 46)
        Me.cmd_export.TabIndex = 23
        Me.cmd_export.Text = "Export"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        '
        'CMD_RPT
        '
        Me.CMD_RPT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CMD_RPT.BackgroundImage = CType(resources.GetObject("CMD_RPT.BackgroundImage"), System.Drawing.Image)
        Me.CMD_RPT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CMD_RPT.FlatAppearance.BorderSize = 0
        Me.CMD_RPT.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.CMD_RPT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.CMD_RPT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.CMD_RPT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMD_RPT.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_RPT.ForeColor = System.Drawing.Color.Black
        Me.CMD_RPT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CMD_RPT.Location = New System.Drawing.Point(4, 203)
        Me.CMD_RPT.Name = "CMD_RPT"
        Me.CMD_RPT.Size = New System.Drawing.Size(124, 46)
        Me.CMD_RPT.TabIndex = 30
        Me.CMD_RPT.Text = "Report"
        Me.CMD_RPT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_RPT.UseVisualStyleBackColor = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(197, 497)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(319, 25)
        Me.lbl_Freeze.TabIndex = 31
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_Freeze.Visible = False
        '
        'cmd_auth
        '
        Me.cmd_auth.BackColor = System.Drawing.Color.Transparent
        Me.cmd_auth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_auth.ForeColor = System.Drawing.Color.Black
        Me.cmd_auth.Image = Global.Inventory.My.Resources.Resources.excel
        Me.cmd_auth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_auth.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmd_auth.Location = New System.Drawing.Point(868, 466)
        Me.cmd_auth.Name = "cmd_auth"
        Me.cmd_auth.Size = New System.Drawing.Size(134, 56)
        Me.cmd_auth.TabIndex = 23
        Me.cmd_auth.Text = "Export"
        Me.cmd_auth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_auth.UseVisualStyleBackColor = False
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.Cmd_Clear)
        Me.frmbut.Controls.Add(Me.Cmd_Exit)
        Me.frmbut.Controls.Add(Me.CMD_RPT)
        Me.frmbut.Controls.Add(Me.cmd_export)
        Me.frmbut.Controls.Add(Me.Cmd_View)
        Me.frmbut.Controls.Add(Me.btn_auth)
        Me.frmbut.Controls.Add(Me.Cmd_Freeze)
        Me.frmbut.Controls.Add(Me.Cmd_Add)
        Me.frmbut.Location = New System.Drawing.Point(482, 143)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(128, 405)
        Me.frmbut.TabIndex = 32
        Me.frmbut.TabStop = False
        '
        'CONSUMERMASTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.LemonChiffon
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(631, 576)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "CONSUMERMASTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONSUMERMASTER"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.frmbut.ResumeLayout(False)
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

    Private Sub CONSUMERMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 And Cmd_Freeze.Visible = True Then
            If Cmd_Freeze.Enabled = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F7 And Cmd_Add.Visible = True Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 And Cmd_View.Visible = True Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        End If
        'If e.KeyCode = Keys.F10 Then
        '    Call cmd_Print_Click(cmd_auth, e)
        '    Exit Sub
        ''End If
        'If e.KeyCode = Keys.F4 Then
        '    Call cmdGroupCode_Click(cmdGroupCode, e)
        '    Exit Sub
        'End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 780
        K = 1044
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
                        If Controls(i_i).Name = "frmbut" Then
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
    Private Sub CONSUMERMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.DoubleBuffered = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        txt_CONno.Enabled = True
        txt_CONno.ReadOnly = False
        TXT_CONNAME.ReadOnly = False

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        StoreMasterbool = True
        txt_CONno.Select()
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.Cmd_Clear.Visible = True
                Me.Cmd_Exit.Visible = True
            End If
        End If

        If gShortname = "HGA" Then
            fillUOM()
        End If
    End Sub
    Private Sub fillUOM()
        Dim I As Integer
        sqlstring = "SELECT DISTINCT ISNULL(CONTYPE,'')AS CONTYPE FROM consumermaster"
        gconnection.getDataSet(sqlstring, "consumermaster")
        If gdataset.Tables("consumermaster").Rows.Count > 0 Then
            cbo_CONTYPE.Items.Clear()
            For I = 0 To gdataset.Tables("consumermaster").Rows.Count - 1
                cbo_CONTYPE.Items.Add(gdataset.Tables("consumermaster").Rows(I).Item("CONTYPE").ToString())
            Next
            cbo_CONTYPE.SelectedIndex = 0
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Consumer Master"
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
        Dim FRM As New ReportDesigner
     
        Gheader = "CONSUMERMASTER DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"CONNO", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CONNAME", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CONID", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CONTYPE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Freeze", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adduser", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"Adddate", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATETIME", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)

    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Void[F8]"
        Cmd_Add.Text = "Add [F7]"
        Cmd_Freeze.Enabled = True
        txt_CONno.Enabled = True
        txt_CONno.ReadOnly = False
        TXT_CONNAME.ReadOnly = False
        txt_CONno.Text = ""
        TXT_CONNAME.Text = ""
        ' TXT_CONID.Text = ""
        cbo_CONTYPE.Text = ""
        'Opt_Substore.Checked = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txt_CONno.Focus()
        If gValidity = False Then
            Me.Cmd_Add.Enabled = False
            Me.cmd_auth.Enabled = False
            Me.Cmd_Freeze.Enabled = False
        End If
        If gShortname = "HGA" Then
            fillUOM()
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(txt_CONno.Text) = "" Then
            MessageBox.Show(" Consumer Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_CONno.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(TXT_CONNAME.Text) = "" Then
            MessageBox.Show(" Consumer Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_CONNAME.Focus()
            Exit Sub
        End If
        If Trim(cbo_CONTYPE.Text) = "" Then
            MessageBox.Show(" Conumer Type  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_CONTYPE.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            strSQL = " INSERT INTO CONSUMERMASTER (CONNO,CONNAME,CONTYPE,Freeze,Adduser,Adddate)"
            strSQL = strSQL & " VALUES ( '" & Trim(txt_CONno.Text) & "','" & Replace(Trim(TXT_CONNAME.Text), "'", "") & "',"
            strSQL = strSQL & " '" & Trim(cbo_CONTYPE.Text) & "',"
            strSQL = strSQL & " 'N','" & Trim(gUsername) & "',getDate())"
            gconnection.dataOperation(1, strSQL, "CONSUMERMASTER")
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            strSQL = "UPDATE  CONSUMERMASTER "
            strSQL = strSQL & " SET CONNAME='" & Replace(Trim(TXT_CONNAME.Text), "'", "") & "',CONTYPE = '" & Trim(cbo_CONTYPE.Text) & "',"
            strSQL = strSQL & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME=getDate(),Freeze='N'"
            strSQL = strSQL & " WHERE CONNO = '" & Trim(txt_CONno.Text) & "'"
            gconnection.dataOperation(2, strSQL, "CONSUMERMASTER")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"

        End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
            sqlstring = "UPDATE  CONSUMERMASTER "
            sqlstring = sqlstring & " SET Freeze= 'Y',voiduser='" & gUsername & " ', voiddate=getDate()"
            sqlstring = sqlstring & " WHERE CONNO = '" & Trim(txt_CONno.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "StoreMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
            'Else
            '    sqlstring = "UPDATE  StoreMaster "
            '    sqlstring = sqlstring & " SET Freeze= 'N',Adduser='" & gUsername & " ', Adddate='" & Format(Now, "dd-MMM-yyyy") & "'"
            '    sqlstring = sqlstring & " WHERE Storecode = '" & Trim(txt_StoreCode.Text) & "'"
            '    gconnection.dataOperation(4, sqlstring, "StoreMaster")
            '    Me.Cmd_Clear_Click(sender, e)
            '    Cmd_Add.Text = "Add [F7]"
        End If
    End Sub


    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "CONSUMERMASTER"
        sqlstring = "select * from CONSUMERMASTER"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub btn_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_auth.Click
        Authocheck("INVENTORY", "CONSUMERMASTER", gUsername, "CONSUMERMASTER", "CONNO", Me)


    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub cmD_CONNOHELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmD_CONNOHELP.Click
        gSQLString = "SELECT ISNULL(CONNO,'') AS CONNO,ISNULL(CONNAME,'') AS CONNAME FROM CONSUMERMASTER"
        M_WhereCondition = "  "
        Dim vform As New ListOperattion1
        vform.Field = "CONNAME,CONNO"
        vform.vFormatstring = "         CONSUMER NO              |                CONSUMER NAME                                                                                                 "
        vform.vCaption = "CONSUMER MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_CONno.Text = Trim(vform.keyfield & "")
            Call txt_CONno_Validated(txt_CONno, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_CONno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_CONno.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmD_CONNOHELP.Enabled = True Then
                search = Trim(txt_CONno.Text)
                Call cmD_CONNOHELP_Click(cmD_CONNOHELP, e)
            End If
        End If
    End Sub

    Private Sub txt_CONno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_CONno.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_CONno.Text) = "" Then
                Call cmD_CONNOHELP_Click(cmD_CONNOHELP, e)
            Else
                txt_CONno_Validated(txt_CONno, e)
            End If
        End If
    End Sub

    Private Sub txt_CONno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_CONno.Validated
        If Trim(txt_CONno.Text) <> "" Then
            sqlstring = "SELECT ISNULL(CONNAME,'') AS CONNAME,ISNULL(CONID,'') AS CONID,ISNULL(CONTYPE,'') AS CONTYPE,ISNULL(FREEZE,'') AS FREEZE,ADDDATE FROM CONSUMERMASTER WHERE CONNO='" & Trim(txt_CONno.Text) & "'"
            gconnection.getDataSet(sqlstring, "CONSUMERMASTER")
            If gdataset.Tables("CONSUMERMASTER").Rows.Count > 0 Then
                TXT_CONNAME.Text = Trim(gdataset.Tables("CONSUMERMASTER").Rows(0).Item("CONNAME"))
                'TXT_CONID.Text = Trim(gdataset.Tables("CONSUMERMASTER").Rows(0).Item("CONID"))
                cbo_CONTYPE.Text = Trim(gdataset.Tables("CONSUMERMASTER").Rows(0).Item("CONTYPE"))
                If gdataset.Tables("CONSUMERMASTER").Rows(0).Item("FREEZE") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("CONSUMERMASTER").Rows(0).Item("adddate")), "dd/MMM/yyyy")
                    ' JH
                    ' Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Void[F8]"
                End If

                Me.Cmd_Add.Text = "Update[F7]"
                txt_CONno.ReadOnly = True
                TXT_CONNAME.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txt_CONno.ReadOnly = False
                TXT_CONNAME.Focus()
            End If
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Else
            txt_CONno.Text = ""
            txt_CONno.Focus()
        End If
    End Sub

    Private Sub CMD_RPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_RPT.Click
        gPrint = False
        'If MsgBox("Click 'YES' to Windows view or 'NO' to Text view", MsgBoxStyle.YesNo, "Store Master") = MsgBoxResult.Yes Then
        Dim rViewer As New Viewer
        Dim sqlstring, SSQL As String
        Dim r As New Rpt_CONSUMERMaster
        sqlstring = "SELECT * FROM CONSUMERMASTER order by CONNO  "
        gconnection.getDataSet(sqlstring, "CONSUMERMASTER")
        If gdataset.Tables("CONSUMERMASTER").Rows.Count > 0 Then
            'If chk_excel.Checked = True Then
            '    Dim exp As New exportexcel
            '    exp.Show()
            '    Call exp.export(sqlstring, "STORE MASTER ", "")
            'Else
            rViewer.ssql = sqlstring
            rViewer.Report = r
            rViewer.TableName = "CONSUMERMASTER"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text13")
            textobj1.Text = MyCompanyName
            Dim textobj2 As TextObject
            textobj2 = r.ReportDefinition.ReportObjects("Text21")
            textobj2.Text = gUsername
            'Dim t1 As TextObject
            't1 = r.ReportDefinition.ReportObjects("Text8")
            't1.Text = gCompanyAddress(0)
            'Dim t2 As TextObject
            't2 = r.ReportDefinition.ReportObjects("Text9")
            't2.Text = gCompanyAddress(1)
            rViewer.Show()
        Else
            MessageBox.Show(" No Records To Display ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation.Information.Information)
        End If
        'Else
        ' PRINTOPERATION()
        ' End If
    End Sub

    Private Sub txt_CONno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TXT_CONNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_CONNAME.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    TXT_CONID.Focus()
        'End If
        'If e.KeyCode = Keys.Tab Then
        '    TXT_CONID.Focus()
        'End If
    End Sub

    Private Sub TXT_CONID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            cbo_CONTYPE.Focus()
        End If
        If e.KeyCode = Keys.Tab Then
            cbo_CONTYPE.Focus()
        End If
    End Sub

    Private Sub cbo_CONTYPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_CONTYPE.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cmd_Add.Focus()
        End If
    End Sub

    Private Sub lbl_Storelocation_Click(sender As Object, e As EventArgs) Handles lbl_Storelocation.Click

    End Sub
End Class
