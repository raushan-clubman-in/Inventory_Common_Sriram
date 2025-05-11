<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_SessionMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inv_SessionMaster))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_GroupCode = New System.Windows.Forms.Label()
        Me.cmdSESSIONCode = New System.Windows.Forms.Button()
        Me.lbl_GroupDescription = New System.Windows.Forms.Label()
        Me.txt_SESSIONCode = New System.Windows.Forms.TextBox()
        Me.txt_SESSIONDesc = New System.Windows.Forms.TextBox()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(210, 5)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(187, 22)
        Me.lbl_Heading.TabIndex = 8
        Me.lbl_Heading.Text = "SESSION  MASTER"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(458, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(143, 211)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
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
        Me.Cmd_Freeze.Location = New System.Drawing.Point(9, 107)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(126, 46)
        Me.Cmd_Freeze.TabIndex = 4
        Me.Cmd_Freeze.Text = "Void[F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.AutoEllipsis = True
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(9, 10)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(126, 46)
        Me.Cmd_Clear.TabIndex = 3
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
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
        Me.Cmd_Add.Location = New System.Drawing.Point(9, 58)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(126, 46)
        Me.Cmd_Add.TabIndex = 2
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(9, 155)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(126, 46)
        Me.Cmd_Exit.TabIndex = 6
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lbl_GroupCode)
        Me.GroupBox1.Controls.Add(Me.cmdSESSIONCode)
        Me.GroupBox1.Controls.Add(Me.lbl_GroupDescription)
        Me.GroupBox1.Controls.Add(Me.txt_SESSIONCode)
        Me.GroupBox1.Controls.Add(Me.txt_SESSIONDesc)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(29, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(393, 103)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'lbl_GroupCode
        '
        Me.lbl_GroupCode.AutoSize = True
        Me.lbl_GroupCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_GroupCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupCode.ForeColor = System.Drawing.Color.Black
        Me.lbl_GroupCode.Location = New System.Drawing.Point(10, 20)
        Me.lbl_GroupCode.Name = "lbl_GroupCode"
        Me.lbl_GroupCode.Size = New System.Drawing.Size(93, 15)
        Me.lbl_GroupCode.TabIndex = 9
        Me.lbl_GroupCode.Text = "SESSION CODE"
        '
        'cmdSESSIONCode
        '
        Me.cmdSESSIONCode.BackgroundImage = CType(resources.GetObject("cmdSESSIONCode.BackgroundImage"), System.Drawing.Image)
        Me.cmdSESSIONCode.FlatAppearance.BorderSize = 0
        Me.cmdSESSIONCode.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmdSESSIONCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdSESSIONCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdSESSIONCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSESSIONCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSESSIONCode.Location = New System.Drawing.Point(255, 17)
        Me.cmdSESSIONCode.Name = "cmdSESSIONCode"
        Me.cmdSESSIONCode.Size = New System.Drawing.Size(23, 26)
        Me.cmdSESSIONCode.TabIndex = 10
        '
        'lbl_GroupDescription
        '
        Me.lbl_GroupDescription.AutoSize = True
        Me.lbl_GroupDescription.BackColor = System.Drawing.Color.Transparent
        Me.lbl_GroupDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupDescription.ForeColor = System.Drawing.Color.Black
        Me.lbl_GroupDescription.Location = New System.Drawing.Point(11, 68)
        Me.lbl_GroupDescription.Name = "lbl_GroupDescription"
        Me.lbl_GroupDescription.Size = New System.Drawing.Size(144, 15)
        Me.lbl_GroupDescription.TabIndex = 11
        Me.lbl_GroupDescription.Text = "SESSION  DESCRIPTION "
        '
        'txt_SESSIONCode
        '
        Me.txt_SESSIONCode.BackColor = System.Drawing.Color.Wheat
        Me.txt_SESSIONCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_SESSIONCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SESSIONCode.Location = New System.Drawing.Point(171, 20)
        Me.txt_SESSIONCode.MaxLength = 5
        Me.txt_SESSIONCode.Name = "txt_SESSIONCode"
        Me.txt_SESSIONCode.Size = New System.Drawing.Size(80, 20)
        Me.txt_SESSIONCode.TabIndex = 0
        '
        'txt_SESSIONDesc
        '
        Me.txt_SESSIONDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_SESSIONDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_SESSIONDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SESSIONDesc.Location = New System.Drawing.Point(171, 67)
        Me.txt_SESSIONDesc.MaxLength = 50
        Me.txt_SESSIONDesc.Name = "txt_SESSIONDesc"
        Me.txt_SESSIONDesc.Size = New System.Drawing.Size(213, 20)
        Me.txt_SESSIONDesc.TabIndex = 1
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(72, 266)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(151, 16)
        Me.lbl_Freeze.TabIndex = 13
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Inv_SessionMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(625, 350)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbl_Heading)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Inv_SessionMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inv_SessionMaster"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Heading As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Cmd_Freeze As Button
    Friend WithEvents Cmd_Clear As Button
    Friend WithEvents Cmd_Add As Button
    Friend WithEvents Cmd_Exit As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbl_GroupCode As Label
    Friend WithEvents cmdSESSIONCode As Button
    Friend WithEvents lbl_GroupDescription As Label
    Friend WithEvents txt_SESSIONCode As TextBox
    Friend WithEvents txt_SESSIONDesc As TextBox
    Friend WithEvents lbl_Freeze As Label
End Class
