Public Class Stock_Damage
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_Docdate As System.Windows.Forms.Label
    Friend WithEvents cmd_Docnohelp As System.Windows.Forms.Button
    Friend WithEvents lbl_Docno As System.Windows.Forms.Label
    Friend WithEvents txt_Docno As System.Windows.Forms.TextBox
    Friend WithEvents dtp_Docdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_Totalamount As System.Windows.Forms.Label
    Friend WithEvents txt_Totalamount As System.Windows.Forms.TextBox
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Remarks As System.Windows.Forms.Label
    Friend WithEvents txt_fromstorecode As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Fromstore As System.Windows.Forms.Label
    Friend WithEvents cbo_Fromstore As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stock_Damage))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.lbl_Docdate = New System.Windows.Forms.Label()
        Me.cmd_Docnohelp = New System.Windows.Forms.Button()
        Me.lbl_Docno = New System.Windows.Forms.Label()
        Me.txt_Docno = New System.Windows.Forms.TextBox()
        Me.dtp_Docdate = New System.Windows.Forms.DateTimePicker()
        Me.lbl_Totalamount = New System.Windows.Forms.Label()
        Me.txt_Totalamount = New System.Windows.Forms.TextBox()
        Me.txt_Remarks = New System.Windows.Forms.TextBox()
        Me.lbl_Remarks = New System.Windows.Forms.Label()
        Me.txt_fromstorecode = New System.Windows.Forms.TextBox()
        Me.lbl_Fromstore = New System.Windows.Forms.Label()
        Me.cbo_Fromstore = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lbl_Heading.Size = New System.Drawing.Size(209, 26)
        Me.lbl_Heading.TabIndex = 92
        Me.lbl_Heading.Text = "STOCK DAMAGE"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(88, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(784, 56)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(480, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(392, 96)
        Me.GroupBox2.TabIndex = 115
        Me.GroupBox2.TabStop = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(408, 544)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(146, 22)
        Me.lbl_Freeze.TabIndex = 141
        Me.lbl_Freeze.Text = "Record Void  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Location = New System.Drawing.Point(200, 584)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 136
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Location = New System.Drawing.Point(544, 584)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 139
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Freeze.Location = New System.Drawing.Point(432, 584)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 138
        Me.Cmd_Freeze.Text = "Void[F8]"
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.Location = New System.Drawing.Point(312, 584)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 137
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Location = New System.Drawing.Point(656, 584)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 140
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Location = New System.Drawing.Point(184, 568)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(592, 56)
        Me.frmbut.TabIndex = 142
        Me.frmbut.TabStop = False
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(87, 216)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(790, 256)
        Me.ssgrid.TabIndex = 369
        '
        'lbl_Docdate
        '
        Me.lbl_Docdate.AutoSize = True
        Me.lbl_Docdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docdate.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_Docdate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Docdate.Location = New System.Drawing.Point(496, 114)
        Me.lbl_Docdate.Name = "lbl_Docdate"
        Me.lbl_Docdate.Size = New System.Drawing.Size(96, 17)
        Me.lbl_Docdate.TabIndex = 374
        Me.lbl_Docdate.Text = "DOC DATE :"
        '
        'cmd_Docnohelp
        '
        Me.cmd_Docnohelp.Image = CType(resources.GetObject("cmd_Docnohelp.Image"), System.Drawing.Image)
        Me.cmd_Docnohelp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmd_Docnohelp.Location = New System.Drawing.Point(824, 72)
        Me.cmd_Docnohelp.Name = "cmd_Docnohelp"
        Me.cmd_Docnohelp.Size = New System.Drawing.Size(23, 26)
        Me.cmd_Docnohelp.TabIndex = 373
        '
        'lbl_Docno
        '
        Me.lbl_Docno.AutoSize = True
        Me.lbl_Docno.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Docno.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_Docno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Docno.Location = New System.Drawing.Point(513, 75)
        Me.lbl_Docno.Name = "lbl_Docno"
        Me.lbl_Docno.Size = New System.Drawing.Size(78, 17)
        Me.lbl_Docno.TabIndex = 371
        Me.lbl_Docno.Text = "DOC NO :"
        '
        'txt_Docno
        '
        Me.txt_Docno.BackColor = System.Drawing.Color.Wheat
        Me.txt_Docno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Docno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Docno.Location = New System.Drawing.Point(624, 72)
        Me.txt_Docno.MaxLength = 15
        Me.txt_Docno.Name = "txt_Docno"
        Me.txt_Docno.Size = New System.Drawing.Size(200, 26)
        Me.txt_Docno.TabIndex = 372
        '
        'dtp_Docdate
        '
        Me.dtp_Docdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_Docdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.dtp_Docdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_Docdate.Location = New System.Drawing.Point(624, 112)
        Me.dtp_Docdate.Name = "dtp_Docdate"
        Me.dtp_Docdate.Size = New System.Drawing.Size(224, 26)
        Me.dtp_Docdate.TabIndex = 370
        '
        'lbl_Totalamount
        '
        Me.lbl_Totalamount.AutoSize = True
        Me.lbl_Totalamount.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Totalamount.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_Totalamount.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Totalamount.Location = New System.Drawing.Point(576, 491)
        Me.lbl_Totalamount.Name = "lbl_Totalamount"
        Me.lbl_Totalamount.Size = New System.Drawing.Size(107, 17)
        Me.lbl_Totalamount.TabIndex = 378
        Me.lbl_Totalamount.Text = "TOTAL AMT :"
        '
        'txt_Totalamount
        '
        Me.txt_Totalamount.BackColor = System.Drawing.Color.Wheat
        Me.txt_Totalamount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Totalamount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txt_Totalamount.Location = New System.Drawing.Point(710, 488)
        Me.txt_Totalamount.MaxLength = 15
        Me.txt_Totalamount.Name = "txt_Totalamount"
        Me.txt_Totalamount.Size = New System.Drawing.Size(168, 26)
        Me.txt_Totalamount.TabIndex = 376
        '
        'txt_Remarks
        '
        Me.txt_Remarks.BackColor = System.Drawing.Color.White
        Me.txt_Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Remarks.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.txt_Remarks.Location = New System.Drawing.Point(182, 488)
        Me.txt_Remarks.MaxLength = 15
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(352, 48)
        Me.txt_Remarks.TabIndex = 375
        '
        'lbl_Remarks
        '
        Me.lbl_Remarks.AutoSize = True
        Me.lbl_Remarks.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Remarks.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_Remarks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_Remarks.Location = New System.Drawing.Point(86, 488)
        Me.lbl_Remarks.Name = "lbl_Remarks"
        Me.lbl_Remarks.Size = New System.Drawing.Size(95, 17)
        Me.lbl_Remarks.TabIndex = 377
        Me.lbl_Remarks.Text = "REMARKS :"
        '
        'txt_fromstorecode
        '
        Me.txt_fromstorecode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_fromstorecode.Location = New System.Drawing.Point(624, 168)
        Me.txt_fromstorecode.Name = "txt_fromstorecode"
        Me.txt_fromstorecode.Size = New System.Drawing.Size(200, 26)
        Me.txt_fromstorecode.TabIndex = 381
        '
        'lbl_Fromstore
        '
        Me.lbl_Fromstore.AutoSize = True
        Me.lbl_Fromstore.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Fromstore.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Fromstore.Location = New System.Drawing.Point(112, 170)
        Me.lbl_Fromstore.Name = "lbl_Fromstore"
        Me.lbl_Fromstore.Size = New System.Drawing.Size(119, 17)
        Me.lbl_Fromstore.TabIndex = 380
        Me.lbl_Fromstore.Text = "STORE NAME :"
        '
        'cbo_Fromstore
        '
        Me.cbo_Fromstore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_Fromstore.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_Fromstore.Location = New System.Drawing.Point(248, 168)
        Me.cbo_Fromstore.Name = "cbo_Fromstore"
        Me.cbo_Fromstore.Size = New System.Drawing.Size(176, 27)
        Me.cbo_Fromstore.TabIndex = 379
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(480, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 17)
        Me.Label1.TabIndex = 382
        Me.Label1.Text = "STORE CODE :"
        '
        'Stock_Damage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Cornsilk
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1014, 732)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_fromstorecode)
        Me.Controls.Add(Me.lbl_Fromstore)
        Me.Controls.Add(Me.cbo_Fromstore)
        Me.Controls.Add(Me.lbl_Totalamount)
        Me.Controls.Add(Me.txt_Totalamount)
        Me.Controls.Add(Me.txt_Remarks)
        Me.Controls.Add(Me.lbl_Remarks)
        Me.Controls.Add(Me.lbl_Docdate)
        Me.Controls.Add(Me.cmd_Docnohelp)
        Me.Controls.Add(Me.lbl_Docno)
        Me.Controls.Add(Me.txt_Docno)
        Me.Controls.Add(Me.dtp_Docdate)
        Me.Controls.Add(Me.ssgrid)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Stock_Damage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STOCK DAMAGE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click

    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click

    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click

    End Sub
End Class
