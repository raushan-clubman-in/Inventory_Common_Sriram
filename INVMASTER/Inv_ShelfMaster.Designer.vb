<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inv_ShelfMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inv_ShelfMaster))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdShelfCode = New System.Windows.Forms.Button()
        Me.Cmd_Location = New System.Windows.Forms.Button()
        Me.txt_Locationdesc = New System.Windows.Forms.TextBox()
        Me.txt_Locationcode = New System.Windows.Forms.TextBox()
        Me.txt_ShelfDesc = New System.Windows.Forms.TextBox()
        Me.txt_ShelfCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_GroupDescription = New System.Windows.Forms.Label()
        Me.lbl_GroupCode = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.cmdShelfCode)
        Me.Panel1.Controls.Add(Me.Cmd_Location)
        Me.Panel1.Controls.Add(Me.txt_Locationdesc)
        Me.Panel1.Controls.Add(Me.txt_Locationcode)
        Me.Panel1.Controls.Add(Me.txt_ShelfDesc)
        Me.Panel1.Controls.Add(Me.txt_ShelfCode)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lbl_GroupDescription)
        Me.Panel1.Controls.Add(Me.lbl_GroupCode)
        Me.Panel1.Location = New System.Drawing.Point(82, 114)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(498, 175)
        Me.Panel1.TabIndex = 1
        '
        'cmdShelfCode
        '
        Me.cmdShelfCode.BackgroundImage = CType(resources.GetObject("cmdShelfCode.BackgroundImage"), System.Drawing.Image)
        Me.cmdShelfCode.FlatAppearance.BorderSize = 0
        Me.cmdShelfCode.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmdShelfCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdShelfCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdShelfCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShelfCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShelfCode.Location = New System.Drawing.Point(273, 13)
        Me.cmdShelfCode.Name = "cmdShelfCode"
        Me.cmdShelfCode.Size = New System.Drawing.Size(23, 26)
        Me.cmdShelfCode.TabIndex = 11
        '
        'Cmd_Location
        '
        Me.Cmd_Location.BackgroundImage = CType(resources.GetObject("Cmd_Location.BackgroundImage"), System.Drawing.Image)
        Me.Cmd_Location.FlatAppearance.BorderSize = 0
        Me.Cmd_Location.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Location.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Location.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_Location.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmd_Location.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Location.Location = New System.Drawing.Point(256, 97)
        Me.Cmd_Location.Name = "Cmd_Location"
        Me.Cmd_Location.Size = New System.Drawing.Size(24, 26)
        Me.Cmd_Location.TabIndex = 479
        '
        'txt_Locationdesc
        '
        Me.txt_Locationdesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_Locationdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Locationdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Locationdesc.Location = New System.Drawing.Point(288, 101)
        Me.txt_Locationdesc.MaxLength = 50
        Me.txt_Locationdesc.Name = "txt_Locationdesc"
        Me.txt_Locationdesc.ReadOnly = True
        Me.txt_Locationdesc.Size = New System.Drawing.Size(196, 20)
        Me.txt_Locationdesc.TabIndex = 478
        '
        'txt_Locationcode
        '
        Me.txt_Locationcode.BackColor = System.Drawing.Color.Wheat
        Me.txt_Locationcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_Locationcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Locationcode.Location = New System.Drawing.Point(189, 101)
        Me.txt_Locationcode.MaxLength = 5
        Me.txt_Locationcode.Name = "txt_Locationcode"
        Me.txt_Locationcode.Size = New System.Drawing.Size(63, 20)
        Me.txt_Locationcode.TabIndex = 477
        '
        'txt_ShelfDesc
        '
        Me.txt_ShelfDesc.BackColor = System.Drawing.Color.Wheat
        Me.txt_ShelfDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_ShelfDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ShelfDesc.Location = New System.Drawing.Point(189, 59)
        Me.txt_ShelfDesc.MaxLength = 50
        Me.txt_ShelfDesc.Name = "txt_ShelfDesc"
        Me.txt_ShelfDesc.ReadOnly = True
        Me.txt_ShelfDesc.Size = New System.Drawing.Size(213, 20)
        Me.txt_ShelfDesc.TabIndex = 475
        '
        'txt_ShelfCode
        '
        Me.txt_ShelfCode.BackColor = System.Drawing.Color.Wheat
        Me.txt_ShelfCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_ShelfCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ShelfCode.Location = New System.Drawing.Point(189, 17)
        Me.txt_ShelfCode.MaxLength = 5
        Me.txt_ShelfCode.Name = "txt_ShelfCode"
        Me.txt_ShelfCode.Size = New System.Drawing.Size(80, 20)
        Me.txt_ShelfCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 474
        Me.Label1.Text = "STORE CODE"
        '
        'lbl_GroupDescription
        '
        Me.lbl_GroupDescription.AutoSize = True
        Me.lbl_GroupDescription.BackColor = System.Drawing.Color.Transparent
        Me.lbl_GroupDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupDescription.ForeColor = System.Drawing.Color.Black
        Me.lbl_GroupDescription.Location = New System.Drawing.Point(21, 61)
        Me.lbl_GroupDescription.Name = "lbl_GroupDescription"
        Me.lbl_GroupDescription.Size = New System.Drawing.Size(126, 15)
        Me.lbl_GroupDescription.TabIndex = 12
        Me.lbl_GroupDescription.Text = "SHELF DESCRIPTION "
        '
        'lbl_GroupCode
        '
        Me.lbl_GroupCode.AutoSize = True
        Me.lbl_GroupCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_GroupCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupCode.ForeColor = System.Drawing.Color.Black
        Me.lbl_GroupCode.Location = New System.Drawing.Point(21, 19)
        Me.lbl_GroupCode.Name = "lbl_GroupCode"
        Me.lbl_GroupCode.Size = New System.Drawing.Size(78, 15)
        Me.lbl_GroupCode.TabIndex = 10
        Me.lbl_GroupCode.Text = "SHELF CODE"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.cmd_export)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(650, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(143, 308)
        Me.GroupBox2.TabIndex = 482
        Me.GroupBox2.TabStop = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Cmd_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_View.FlatAppearance.BorderSize = 0
        Me.Cmd_View.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(9, 154)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(126, 46)
        Me.Cmd_View.TabIndex = 9
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
        Me.Cmd_Freeze.Location = New System.Drawing.Point(9, 106)
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(9, 250)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(126, 46)
        Me.Cmd_Exit.TabIndex = 6
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
        Me.cmd_export.Location = New System.Drawing.Point(9, 202)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(126, 46)
        Me.cmd_export.TabIndex = 8
        Me.cmd_export.Text = "Export[F12]"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(211, 328)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(151, 16)
        Me.lbl_Freeze.TabIndex = 483
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.Color.White
        Me.lbl_Heading.Location = New System.Drawing.Point(150, 7)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(165, 22)
        Me.lbl_Heading.TabIndex = 484
        Me.lbl_Heading.Text = "SHELF  MASTER"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Inv_ShelfMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(809, 418)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Inv_ShelfMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inv_ShelfMaster"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmdShelfCode As Button
    Friend WithEvents Cmd_Location As Button
    Friend WithEvents txt_Locationdesc As TextBox
    Friend WithEvents txt_Locationcode As TextBox
    Friend WithEvents txt_ShelfDesc As TextBox
    Friend WithEvents txt_ShelfCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_GroupDescription As Label
    Friend WithEvents lbl_GroupCode As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Cmd_View As Button
    Friend WithEvents Cmd_Freeze As Button
    Friend WithEvents Cmd_Clear As Button
    Friend WithEvents Cmd_Add As Button
    Friend WithEvents Cmd_Exit As Button
    Friend WithEvents cmd_export As Button
    Friend WithEvents lbl_Freeze As Label
    Friend WithEvents lbl_Heading As Label
End Class
