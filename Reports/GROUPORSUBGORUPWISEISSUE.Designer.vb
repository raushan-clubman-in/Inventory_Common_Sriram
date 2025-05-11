<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GROUPORSUBGORUPWISEISSUE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GROUPORSUBGORUPWISEISSUE))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTP_TODATE = New System.Windows.Forms.DateTimePicker()
        Me.DTP_FROMDATE = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CHK_GROUPDETAILS = New System.Windows.Forms.CheckBox()
        Me.CHKLST_GROUPDETAILS = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CHK_SUBGROUPDETAILS = New System.Windows.Forms.CheckBox()
        Me.CHKLST_SUBGROUPDETAILS = New System.Windows.Forms.CheckedListBox()
        Me.CHK_SUBGROUPWISE = New System.Windows.Forms.CheckBox()
        Me.Btn_Clear = New System.Windows.Forms.Button()
        Me.CHK_GROUPWISE = New System.Windows.Forms.CheckBox()
        Me.Btn_View = New System.Windows.Forms.Button()
        Me.Btn_Exit = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chk_storedetails = New System.Windows.Forms.CheckBox()
        Me.chklist_store = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.DTP_TODATE)
        Me.GroupBox4.Controls.Add(Me.DTP_FROMDATE)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 466)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(509, 60)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(335, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "TO DATE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "FROM DATE"
        '
        'DTP_TODATE
        '
        Me.DTP_TODATE.Location = New System.Drawing.Point(399, 22)
        Me.DTP_TODATE.Name = "DTP_TODATE"
        Me.DTP_TODATE.Size = New System.Drawing.Size(92, 20)
        Me.DTP_TODATE.TabIndex = 4
        '
        'DTP_FROMDATE
        '
        Me.DTP_FROMDATE.Location = New System.Drawing.Point(101, 22)
        Me.DTP_FROMDATE.Name = "DTP_FROMDATE"
        Me.DTP_FROMDATE.Size = New System.Drawing.Size(95, 20)
        Me.DTP_FROMDATE.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.CHK_GROUPDETAILS)
        Me.GroupBox1.Controls.Add(Me.CHKLST_GROUPDETAILS)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(234, 135)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(214, 314)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GROUPS"
        Me.GroupBox1.Visible = False
        '
        'CHK_GROUPDETAILS
        '
        Me.CHK_GROUPDETAILS.AutoSize = True
        Me.CHK_GROUPDETAILS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CHK_GROUPDETAILS.Location = New System.Drawing.Point(27, 26)
        Me.CHK_GROUPDETAILS.Name = "CHK_GROUPDETAILS"
        Me.CHK_GROUPDETAILS.Size = New System.Drawing.Size(80, 17)
        Me.CHK_GROUPDETAILS.TabIndex = 1
        Me.CHK_GROUPDETAILS.Text = "Select All"
        Me.CHK_GROUPDETAILS.UseVisualStyleBackColor = True
        '
        'CHKLST_GROUPDETAILS
        '
        Me.CHKLST_GROUPDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKLST_GROUPDETAILS.FormattingEnabled = True
        Me.CHKLST_GROUPDETAILS.Location = New System.Drawing.Point(27, 45)
        Me.CHKLST_GROUPDETAILS.Name = "CHKLST_GROUPDETAILS"
        Me.CHKLST_GROUPDETAILS.Size = New System.Drawing.Size(163, 244)
        Me.CHKLST_GROUPDETAILS.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(248, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(424, 24)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "GROUP / SUBGROUP WISE ISSUE DETAILS"
        '
        'CHK_SUBGROUPDETAILS
        '
        Me.CHK_SUBGROUPDETAILS.AutoSize = True
        Me.CHK_SUBGROUPDETAILS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.CHK_SUBGROUPDETAILS.Location = New System.Drawing.Point(19, 29)
        Me.CHK_SUBGROUPDETAILS.Name = "CHK_SUBGROUPDETAILS"
        Me.CHK_SUBGROUPDETAILS.Size = New System.Drawing.Size(80, 17)
        Me.CHK_SUBGROUPDETAILS.TabIndex = 2
        Me.CHK_SUBGROUPDETAILS.Text = "Select All"
        Me.CHK_SUBGROUPDETAILS.UseVisualStyleBackColor = True
        '
        'CHKLST_SUBGROUPDETAILS
        '
        Me.CHKLST_SUBGROUPDETAILS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKLST_SUBGROUPDETAILS.FormattingEnabled = True
        Me.CHKLST_SUBGROUPDETAILS.Location = New System.Drawing.Point(14, 49)
        Me.CHKLST_SUBGROUPDETAILS.Name = "CHKLST_SUBGROUPDETAILS"
        Me.CHKLST_SUBGROUPDETAILS.Size = New System.Drawing.Size(172, 244)
        Me.CHKLST_SUBGROUPDETAILS.TabIndex = 1
        '
        'CHK_SUBGROUPWISE
        '
        Me.CHK_SUBGROUPWISE.AutoSize = True
        Me.CHK_SUBGROUPWISE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_SUBGROUPWISE.Location = New System.Drawing.Point(13, 189)
        Me.CHK_SUBGROUPWISE.Name = "CHK_SUBGROUPWISE"
        Me.CHK_SUBGROUPWISE.Size = New System.Drawing.Size(127, 20)
        Me.CHK_SUBGROUPWISE.TabIndex = 15
        Me.CHK_SUBGROUPWISE.Text = "SubGroupwise"
        Me.CHK_SUBGROUPWISE.UseVisualStyleBackColor = True
        '
        'Btn_Clear
        '
        Me.Btn_Clear.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn_Clear.BackgroundImage = CType(resources.GetObject("Btn_Clear.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Btn_Clear.FlatAppearance.BorderSize = 0
        Me.Btn_Clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Btn_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Btn_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Clear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Clear.ForeColor = System.Drawing.Color.Black
        Me.Btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Clear.Location = New System.Drawing.Point(13, 13)
        Me.Btn_Clear.Name = "Btn_Clear"
        Me.Btn_Clear.Size = New System.Drawing.Size(144, 46)
        Me.Btn_Clear.TabIndex = 491
        Me.Btn_Clear.Text = "Clear[F6]"
        Me.Btn_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Clear.UseVisualStyleBackColor = False
        '
        'CHK_GROUPWISE
        '
        Me.CHK_GROUPWISE.AutoSize = True
        Me.CHK_GROUPWISE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CHK_GROUPWISE.Location = New System.Drawing.Point(13, 163)
        Me.CHK_GROUPWISE.Name = "CHK_GROUPWISE"
        Me.CHK_GROUPWISE.Size = New System.Drawing.Size(100, 20)
        Me.CHK_GROUPWISE.TabIndex = 14
        Me.CHK_GROUPWISE.Text = "Groupwise"
        Me.CHK_GROUPWISE.UseVisualStyleBackColor = True
        '
        'Btn_View
        '
        Me.Btn_View.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn_View.BackgroundImage = CType(resources.GetObject("Btn_View.BackgroundImage"), System.Drawing.Image)
        Me.Btn_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Btn_View.FlatAppearance.BorderSize = 0
        Me.Btn_View.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Btn_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Btn_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Btn_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_View.ForeColor = System.Drawing.Color.Black
        Me.Btn_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_View.Location = New System.Drawing.Point(13, 62)
        Me.Btn_View.Name = "Btn_View"
        Me.Btn_View.Size = New System.Drawing.Size(144, 46)
        Me.Btn_View.TabIndex = 492
        Me.Btn_View.Text = " View[F9]"
        Me.Btn_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_View.UseVisualStyleBackColor = False
        '
        'Btn_Exit
        '
        Me.Btn_Exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Btn_Exit.BackgroundImage = CType(resources.GetObject("Btn_Exit.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Btn_Exit.FlatAppearance.BorderSize = 0
        Me.Btn_Exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Btn_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Btn_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Exit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Exit.ForeColor = System.Drawing.Color.Black
        Me.Btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Exit.Location = New System.Drawing.Point(13, 111)
        Me.Btn_Exit.Name = "Btn_Exit"
        Me.Btn_Exit.Size = New System.Drawing.Size(144, 46)
        Me.Btn_Exit.TabIndex = 493
        Me.Btn_Exit.Text = "Exit[F11]"
        Me.Btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Exit.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox3.Controls.Add(Me.CHK_SUBGROUPWISE)
        Me.GroupBox3.Controls.Add(Me.Btn_Clear)
        Me.GroupBox3.Controls.Add(Me.CHK_GROUPWISE)
        Me.GroupBox3.Controls.Add(Me.Btn_View)
        Me.GroupBox3.Controls.Add(Me.Btn_Exit)
        Me.GroupBox3.Location = New System.Drawing.Point(721, 164)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(166, 220)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox2.Controls.Add(Me.CHK_SUBGROUPDETAILS)
        Me.GroupBox2.Controls.Add(Me.CHKLST_SUBGROUPDETAILS)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(454, 135)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(214, 314)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SUBGROUPS "
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.chk_storedetails)
        Me.GroupBox5.Controls.Add(Me.chklist_store)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 135)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(216, 314)
        Me.GroupBox5.TabIndex = 19
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "STORECODE"
        '
        'chk_storedetails
        '
        Me.chk_storedetails.AutoSize = True
        Me.chk_storedetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_storedetails.Location = New System.Drawing.Point(20, 22)
        Me.chk_storedetails.Name = "chk_storedetails"
        Me.chk_storedetails.Size = New System.Drawing.Size(80, 17)
        Me.chk_storedetails.TabIndex = 1
        Me.chk_storedetails.Text = "Select All"
        Me.chk_storedetails.UseVisualStyleBackColor = True
        '
        'chklist_store
        '
        Me.chklist_store.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_store.FormattingEnabled = True
        Me.chklist_store.Location = New System.Drawing.Point(20, 41)
        Me.chklist_store.Name = "chklist_store"
        Me.chklist_store.Size = New System.Drawing.Size(176, 244)
        Me.chklist_store.TabIndex = 0
        '
        'GROUPORSUBGORUPWISEISSUE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1350, 523)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "GROUPORSUBGORUPWISEISSUE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GROUPORSUBGORUPWISEISSUE"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTP_TODATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_FROMDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CHK_GROUPDETAILS As System.Windows.Forms.CheckBox
    Friend WithEvents CHKLST_GROUPDETAILS As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CHK_SUBGROUPDETAILS As System.Windows.Forms.CheckBox
    Friend WithEvents CHKLST_SUBGROUPDETAILS As System.Windows.Forms.CheckedListBox
    Friend WithEvents CHK_SUBGROUPWISE As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Clear As System.Windows.Forms.Button
    Friend WithEvents CHK_GROUPWISE As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_View As System.Windows.Forms.Button
    Friend WithEvents Btn_Exit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chklist_store As System.Windows.Forms.CheckedListBox
    Friend WithEvents chk_storedetails As System.Windows.Forms.CheckBox
End Class
