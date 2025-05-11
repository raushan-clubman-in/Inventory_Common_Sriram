<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvPenIndentIssue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvPenIndentIssue))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkSupplier = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.ChkItemCode = New System.Windows.Forms.CheckBox()
        Me.ChkCategory = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox3 = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txt_mainstore = New System.Windows.Forms.TextBox()
        Me.cmd_storecode = New System.Windows.Forms.Button()
        Me.txt_mainstorecode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtptodate = New System.Windows.Forms.DateTimePicker()
        Me.dtpfromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButExport = New System.Windows.Forms.Button()
        Me.chkdetail = New System.Windows.Forms.CheckBox()
        Me.chksummary = New System.Windows.Forms.CheckBox()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ChkSupplier)
        Me.GroupBox2.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox2.Controls.Add(Me.ChkItemCode)
        Me.GroupBox2.Controls.Add(Me.ChkCategory)
        Me.GroupBox2.Controls.Add(Me.CheckedListBox3)
        Me.GroupBox2.Controls.Add(Me.CheckedListBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(33, 130)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(626, 351)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Maroon
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(177, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 24)
        Me.Label8.TabIndex = 484
        Me.Label8.Text = "F3"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(143, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.TabIndex = 483
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Maroon
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(199, 24)
        Me.Label4.TabIndex = 482
        Me.Label4.Text = "SELECT STORE CODE :  "
        '
        'ChkSupplier
        '
        Me.ChkSupplier.AutoSize = True
        Me.ChkSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkSupplier.Location = New System.Drawing.Point(6, 10)
        Me.ChkSupplier.Name = "ChkSupplier"
        Me.ChkSupplier.Size = New System.Drawing.Size(107, 17)
        Me.ChkSupplier.TabIndex = 3
        Me.ChkSupplier.Text = "STORE NAME"
        Me.ChkSupplier.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(6, 58)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(200, 274)
        Me.CheckedListBox1.TabIndex = 0
        '
        'ChkItemCode
        '
        Me.ChkItemCode.AutoSize = True
        Me.ChkItemCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkItemCode.Location = New System.Drawing.Point(418, 24)
        Me.ChkItemCode.Name = "ChkItemCode"
        Me.ChkItemCode.Size = New System.Drawing.Size(90, 17)
        Me.ChkItemCode.TabIndex = 5
        Me.ChkItemCode.Text = "ITEMCODE"
        Me.ChkItemCode.UseVisualStyleBackColor = True
        Me.ChkItemCode.Visible = False
        '
        'ChkCategory
        '
        Me.ChkCategory.AutoSize = True
        Me.ChkCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCategory.Location = New System.Drawing.Point(212, 24)
        Me.ChkCategory.Name = "ChkCategory"
        Me.ChkCategory.Size = New System.Drawing.Size(93, 17)
        Me.ChkCategory.TabIndex = 4
        Me.ChkCategory.Text = "CATEGORY"
        Me.ChkCategory.UseVisualStyleBackColor = True
        Me.ChkCategory.Visible = False
        '
        'CheckedListBox3
        '
        Me.CheckedListBox3.CheckOnClick = True
        Me.CheckedListBox3.FormattingEnabled = True
        Me.CheckedListBox3.Location = New System.Drawing.Point(418, 47)
        Me.CheckedListBox3.Name = "CheckedListBox3"
        Me.CheckedListBox3.Size = New System.Drawing.Size(200, 289)
        Me.CheckedListBox3.TabIndex = 2
        Me.CheckedListBox3.Visible = False
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Location = New System.Drawing.Point(212, 47)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(200, 289)
        Me.CheckedListBox2.TabIndex = 1
        Me.CheckedListBox2.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txt_mainstore)
        Me.GroupBox3.Controls.Add(Me.cmd_storecode)
        Me.GroupBox3.Controls.Add(Me.txt_mainstorecode)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.dtptodate)
        Me.GroupBox3.Controls.Add(Me.dtpfromdate)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(33, 490)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(626, 69)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        '
        'txt_mainstore
        '
        Me.txt_mainstore.Location = New System.Drawing.Point(229, 14)
        Me.txt_mainstore.Name = "txt_mainstore"
        Me.txt_mainstore.Size = New System.Drawing.Size(130, 20)
        Me.txt_mainstore.TabIndex = 487
        '
        'cmd_storecode
        '
        Me.cmd_storecode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_storecode.Image = CType(resources.GetObject("cmd_storecode.Image"), System.Drawing.Image)
        Me.cmd_storecode.Location = New System.Drawing.Point(204, 11)
        Me.cmd_storecode.Name = "cmd_storecode"
        Me.cmd_storecode.Size = New System.Drawing.Size(24, 26)
        Me.cmd_storecode.TabIndex = 486
        '
        'txt_mainstorecode
        '
        Me.txt_mainstorecode.Location = New System.Drawing.Point(91, 15)
        Me.txt_mainstorecode.Name = "txt_mainstorecode"
        Me.txt_mainstorecode.Size = New System.Drawing.Size(117, 20)
        Me.txt_mainstorecode.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "STORE"
        '
        'dtptodate
        '
        Me.dtptodate.Location = New System.Drawing.Point(358, 43)
        Me.dtptodate.Name = "dtptodate"
        Me.dtptodate.Size = New System.Drawing.Size(200, 20)
        Me.dtptodate.TabIndex = 3
        '
        'dtpfromdate
        '
        Me.dtpfromdate.Location = New System.Drawing.Point(89, 43)
        Me.dtpfromdate.Name = "dtpfromdate"
        Me.dtpfromdate.Size = New System.Drawing.Size(200, 20)
        Me.dtpfromdate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(295, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TODATE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FROM DATE"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.ButExport)
        Me.GroupBox1.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox1.Controls.Add(Me.Cmd_Print)
        Me.GroupBox1.Controls.Add(Me.Cmd_View)
        Me.GroupBox1.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox1.Location = New System.Drawing.Point(687, 130)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(154, 267)
        Me.GroupBox1.TabIndex = 488
        Me.GroupBox1.TabStop = False
        '
        'ButExport
        '
        Me.ButExport.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButExport.BackgroundImage = CType(resources.GetObject("ButExport.BackgroundImage"), System.Drawing.Image)
        Me.ButExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButExport.FlatAppearance.BorderSize = 0
        Me.ButExport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButExport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButExport.ForeColor = System.Drawing.Color.Black
        Me.ButExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButExport.Location = New System.Drawing.Point(7, 158)
        Me.ButExport.Name = "ButExport"
        Me.ButExport.Size = New System.Drawing.Size(144, 46)
        Me.ButExport.TabIndex = 493
        Me.ButExport.Text = " Export[F12]"
        Me.ButExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButExport.UseVisualStyleBackColor = False
        '
        'chkdetail
        '
        Me.chkdetail.AutoSize = True
        Me.chkdetail.Location = New System.Drawing.Point(687, 430)
        Me.chkdetail.Name = "chkdetail"
        Me.chkdetail.Size = New System.Drawing.Size(110, 17)
        Me.chkdetail.TabIndex = 492
        Me.chkdetail.Text = "WITHOUT RATE"
        Me.chkdetail.UseVisualStyleBackColor = True
        Me.chkdetail.Visible = False
        '
        'chksummary
        '
        Me.chksummary.AutoSize = True
        Me.chksummary.Location = New System.Drawing.Point(687, 403)
        Me.chksummary.Name = "chksummary"
        Me.chksummary.Size = New System.Drawing.Size(87, 17)
        Me.chksummary.TabIndex = 491
        Me.chksummary.Text = "WITH RATE"
        Me.chksummary.UseVisualStyleBackColor = True
        Me.chksummary.Visible = False
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
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(7, 208)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Exit.TabIndex = 490
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_Print.BackgroundImage = CType(resources.GetObject("Cmd_Print.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Print.FlatAppearance.BorderSize = 0
        Me.Cmd_Print.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(6, 109)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Print.TabIndex = 489
        Me.Cmd_Print.Text = " Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = False
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
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(6, 60)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_View.TabIndex = 488
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
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
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(6, 11)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 46)
        Me.Cmd_Clear.TabIndex = 487
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(225, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(367, 23)
        Me.Label16.TabIndex = 491
        Me.Label16.Text = "PENDING INDENT ISSUE  DETAIL"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'InvPenIndentIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(854, 592)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.chkdetail)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chksummary)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "InvPenIndentIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InvIssueRegister"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkItemCode As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCategory As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSupplier As System.Windows.Forms.CheckBox
    Friend WithEvents CheckedListBox3 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBox2 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_mainstore As System.Windows.Forms.TextBox
    Friend WithEvents cmd_storecode As System.Windows.Forms.Button
    Friend WithEvents txt_mainstorecode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtptodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkdetail As System.Windows.Forms.CheckBox
    Friend WithEvents chksummary As System.Windows.Forms.CheckBox
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents ButExport As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
