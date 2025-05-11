<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Salvage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Salvage))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_Fromstore = New System.Windows.Forms.Label()
        Me.lbl_Docdate = New System.Windows.Forms.Label()
        Me.txt_Docno = New System.Windows.Forms.TextBox()
        Me.lbl_Docno = New System.Windows.Forms.Label()
        Me.cmd_Docnohelp = New System.Windows.Forms.Button()
        Me.txt_FromStorename = New System.Windows.Forms.TextBox()
        Me.TXT_FROMSTORECODE = New System.Windows.Forms.TextBox()
        Me.cmd_fromStorecodeHelp = New System.Windows.Forms.Button()
        Me.dtp_Docdate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.AxfpSpread1 = New AxFPSpreadADO.AxfpSpread()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LabelClosingQuantity = New System.Windows.Forms.Label()
        Me.Txttotqty = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.cmd_Print = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lbl_Fromstore)
        Me.GroupBox1.Controls.Add(Me.lbl_Docdate)
        Me.GroupBox1.Controls.Add(Me.txt_Docno)
        Me.GroupBox1.Controls.Add(Me.lbl_Docno)
        Me.GroupBox1.Controls.Add(Me.cmd_Docnohelp)
        Me.GroupBox1.Controls.Add(Me.txt_FromStorename)
        Me.GroupBox1.Controls.Add(Me.TXT_FROMSTORECODE)
        Me.GroupBox1.Controls.Add(Me.cmd_fromStorecodeHelp)
        Me.GroupBox1.Controls.Add(Me.dtp_Docdate)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(635, 128)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'lbl_Fromstore
        '
        Me.lbl_Fromstore.AutoSize = True
        Me.lbl_Fromstore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Fromstore.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Fromstore.Location = New System.Drawing.Point(145, 90)
        Me.lbl_Fromstore.Name = "lbl_Fromstore"
        Me.lbl_Fromstore.Size = New System.Drawing.Size(82, 15)
        Me.lbl_Fromstore.TabIndex = 481
        Me.lbl_Fromstore.Text = "FROM STORE"
        '
        'lbl_Docdate
        '
        Me.lbl_Docdate.AutoSize = True
        Me.lbl_Docdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docdate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Docdate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Docdate.Location = New System.Drawing.Point(145, 58)
        Me.lbl_Docdate.Name = "lbl_Docdate"
        Me.lbl_Docdate.Size = New System.Drawing.Size(64, 15)
        Me.lbl_Docdate.TabIndex = 1
        Me.lbl_Docdate.Text = "DOC DATE"
        '
        'txt_Docno
        '
        Me.txt_Docno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Docno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Docno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Docno.Location = New System.Drawing.Point(299, 19)
        Me.txt_Docno.MaxLength = 15
        Me.txt_Docno.Name = "txt_Docno"
        Me.txt_Docno.Size = New System.Drawing.Size(200, 26)
        Me.txt_Docno.TabIndex = 9
        '
        'lbl_Docno
        '
        Me.lbl_Docno.AutoSize = True
        Me.lbl_Docno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Docno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Docno.Location = New System.Drawing.Point(145, 24)
        Me.lbl_Docno.Name = "lbl_Docno"
        Me.lbl_Docno.Size = New System.Drawing.Size(52, 15)
        Me.lbl_Docno.TabIndex = 0
        Me.lbl_Docno.Text = "DOC NO"
        '
        'cmd_Docnohelp
        '
        Me.cmd_Docnohelp.Image = CType(resources.GetObject("cmd_Docnohelp.Image"), System.Drawing.Image)
        Me.cmd_Docnohelp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmd_Docnohelp.Location = New System.Drawing.Point(500, 19)
        Me.cmd_Docnohelp.Name = "cmd_Docnohelp"
        Me.cmd_Docnohelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_Docnohelp.TabIndex = 10
        '
        'txt_FromStorename
        '
        Me.txt_FromStorename.BackColor = System.Drawing.Color.Wheat
        Me.txt_FromStorename.Enabled = False
        Me.txt_FromStorename.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FromStorename.Location = New System.Drawing.Point(329, 87)
        Me.txt_FromStorename.MaxLength = 50
        Me.txt_FromStorename.Name = "txt_FromStorename"
        Me.txt_FromStorename.Size = New System.Drawing.Size(194, 22)
        Me.txt_FromStorename.TabIndex = 482
        '
        'TXT_FROMSTORECODE
        '
        Me.TXT_FROMSTORECODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_FROMSTORECODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_FROMSTORECODE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_FROMSTORECODE.Location = New System.Drawing.Point(238, 87)
        Me.TXT_FROMSTORECODE.MaxLength = 50
        Me.TXT_FROMSTORECODE.Name = "TXT_FROMSTORECODE"
        Me.TXT_FROMSTORECODE.Size = New System.Drawing.Size(60, 22)
        Me.TXT_FROMSTORECODE.TabIndex = 480
        '
        'cmd_fromStorecodeHelp
        '
        Me.cmd_fromStorecodeHelp.Image = CType(resources.GetObject("cmd_fromStorecodeHelp.Image"), System.Drawing.Image)
        Me.cmd_fromStorecodeHelp.Location = New System.Drawing.Point(300, 84)
        Me.cmd_fromStorecodeHelp.Name = "cmd_fromStorecodeHelp"
        Me.cmd_fromStorecodeHelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_fromStorecodeHelp.TabIndex = 483
        '
        'dtp_Docdate
        '
        Me.dtp_Docdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Docdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.dtp_Docdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Docdate.Location = New System.Drawing.Point(299, 54)
        Me.dtp_Docdate.Name = "dtp_Docdate"
        Me.dtp_Docdate.Size = New System.Drawing.Size(224, 26)
        Me.dtp_Docdate.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.AxfpSpread1)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 252)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(631, 186)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(7, 20)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(640, 150)
        Me.AxfpSpread1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.LabelClosingQuantity)
        Me.GroupBox4.Location = New System.Drawing.Point(209, 463)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(635, 48)
        Me.GroupBox4.TabIndex = 29
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Visible = False
        '
        'LabelClosingQuantity
        '
        Me.LabelClosingQuantity.AutoSize = True
        Me.LabelClosingQuantity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelClosingQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelClosingQuantity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelClosingQuantity.Location = New System.Drawing.Point(363, 18)
        Me.LabelClosingQuantity.Name = "LabelClosingQuantity"
        Me.LabelClosingQuantity.Size = New System.Drawing.Size(0, 16)
        Me.LabelClosingQuantity.TabIndex = 481
        '
        'Txttotqty
        '
        Me.Txttotqty.BackColor = System.Drawing.Color.Wheat
        Me.Txttotqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txttotqty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txttotqty.Location = New System.Drawing.Point(559, 444)
        Me.Txttotqty.MaxLength = 50
        Me.Txttotqty.Name = "Txttotqty"
        Me.Txttotqty.Size = New System.Drawing.Size(92, 22)
        Me.Txttotqty.TabIndex = 484
        Me.Txttotqty.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox3.Controls.Add(Me.Cmd_Add)
        Me.GroupBox3.Controls.Add(Me.Cmd_View)
        Me.GroupBox3.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox3.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox3.Location = New System.Drawing.Point(673, 132)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(137, 262)
        Me.GroupBox3.TabIndex = 485
        Me.GroupBox3.TabStop = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Clear.BackgroundImage = CType(resources.GetObject("Cmd_Clear.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.FlatAppearance.BorderSize = 0
        Me.Cmd_Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(7, 14)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Clear.TabIndex = 23
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Add.BackgroundImage = CType(resources.GetObject("Cmd_Add.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Add.FlatAppearance.BorderSize = 0
        Me.Cmd_Add.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(6, 62)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Add.TabIndex = 24
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_View.BackgroundImage = CType(resources.GetObject("Cmd_View.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_View.FlatAppearance.BorderSize = 0
        Me.Cmd_View.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(6, 110)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_View.TabIndex = 26
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Exit.BackgroundImage = CType(resources.GetObject("Cmd_Exit.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Exit.FlatAppearance.BorderSize = 0
        Me.Cmd_Exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(6, 206)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Exit.TabIndex = 27
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Freeze.BackgroundImage = CType(resources.GetObject("Cmd_Freeze.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Freeze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Freeze.FlatAppearance.BorderSize = 0
        Me.Cmd_Freeze.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(6, 158)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(124, 46)
        Me.Cmd_Freeze.TabIndex = 25
        Me.Cmd_Freeze.Text = "Void[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'cmd_Print
        '
        Me.cmd_Print.BackColor = System.Drawing.Color.Transparent
        Me.cmd_Print.BackgroundImage = Global.Inventory.My.Resources.Resources.print
        Me.cmd_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Print.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Print.Location = New System.Drawing.Point(680, 410)
        Me.cmd_Print.Name = "cmd_Print"
        Me.cmd_Print.Size = New System.Drawing.Size(134, 56)
        Me.cmd_Print.TabIndex = 28
        Me.cmd_Print.Text = "Print[F10]"
        Me.cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Print.UseVisualStyleBackColor = False
        Me.cmd_Print.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Freeze.Location = New System.Drawing.Point(516, 41)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(146, 22)
        Me.lbl_Freeze.TabIndex = 482
        Me.lbl_Freeze.Text = "Record Void  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(205, 14)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(169, 22)
        Me.lbl_Heading.TabIndex = 488
        Me.lbl_Heading.Text = "SALVAGE ENTRY"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Frm_Salvage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(829, 487)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.cmd_Print)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Txttotqty)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Frm_Salvage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frm_stockConsumption"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Docdate As System.Windows.Forms.Label
    Friend WithEvents txt_Docno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Docno As System.Windows.Forms.Label
    Friend WithEvents cmd_Docnohelp As System.Windows.Forms.Button
    Friend WithEvents dtp_Docdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents AxfpSpread1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelClosingQuantity As System.Windows.Forms.Label
    Friend WithEvents TXT_FROMSTORECODE As System.Windows.Forms.TextBox
    Friend WithEvents txt_FromStorename As System.Windows.Forms.TextBox
    Friend WithEvents cmd_fromStorecodeHelp As System.Windows.Forms.Button
    Friend WithEvents lbl_Fromstore As System.Windows.Forms.Label
    Friend WithEvents Txttotqty As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
End Class
