<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Month_process
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Month_process))
        Me.lbl_display = New System.Windows.Forms.Label()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        Me.CMD_PROCESS = New System.Windows.Forms.Button()
        Me.cmd_check = New System.Windows.Forms.Button()
        Me.lbl_POSCode = New System.Windows.Forms.Label()
        Me.Dtp_CloseDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lbl_monthproc = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_display
        '
        Me.lbl_display.AutoSize = True
        Me.lbl_display.BackColor = System.Drawing.Color.Transparent
        Me.lbl_display.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_display.ForeColor = System.Drawing.Color.Red
        Me.lbl_display.Location = New System.Drawing.Point(24, 202)
        Me.lbl_display.Name = "lbl_display"
        Me.lbl_display.Size = New System.Drawing.Size(87, 22)
        Me.lbl_display.TabIndex = 22
        Me.lbl_display.Text = "MONTH :"
        Me.lbl_display.Visible = False
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Cancel.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Cancel.ForeColor = System.Drawing.Color.Black
        Me.cmd_Cancel.Image = CType(resources.GetObject("cmd_Cancel.Image"), System.Drawing.Image)
        Me.cmd_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Cancel.Location = New System.Drawing.Point(435, 134)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.Size = New System.Drawing.Size(130, 55)
        Me.cmd_Cancel.TabIndex = 21
        Me.cmd_Cancel.Text = "Close"
        Me.cmd_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Cancel.UseVisualStyleBackColor = False
        '
        'CMD_PROCESS
        '
        Me.CMD_PROCESS.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CMD_PROCESS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMD_PROCESS.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_PROCESS.ForeColor = System.Drawing.Color.Black
        Me.CMD_PROCESS.Image = CType(resources.GetObject("CMD_PROCESS.Image"), System.Drawing.Image)
        Me.CMD_PROCESS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_PROCESS.Location = New System.Drawing.Point(571, 134)
        Me.CMD_PROCESS.Name = "CMD_PROCESS"
        Me.CMD_PROCESS.Size = New System.Drawing.Size(166, 55)
        Me.CMD_PROCESS.TabIndex = 20
        Me.CMD_PROCESS.Text = "Process"
        Me.CMD_PROCESS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_PROCESS.UseVisualStyleBackColor = False
        '
        'cmd_check
        '
        Me.cmd_check.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_check.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_check.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_check.ForeColor = System.Drawing.Color.Black
        Me.cmd_check.Image = CType(resources.GetObject("cmd_check.Image"), System.Drawing.Image)
        Me.cmd_check.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_check.Location = New System.Drawing.Point(252, 134)
        Me.cmd_check.Name = "cmd_check"
        Me.cmd_check.Size = New System.Drawing.Size(177, 55)
        Me.cmd_check.TabIndex = 19
        Me.cmd_check.Text = "CHECK"
        Me.cmd_check.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_check.UseVisualStyleBackColor = False
        '
        'lbl_POSCode
        '
        Me.lbl_POSCode.AutoSize = True
        Me.lbl_POSCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_POSCode.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_POSCode.ForeColor = System.Drawing.Color.Black
        Me.lbl_POSCode.Location = New System.Drawing.Point(16, 154)
        Me.lbl_POSCode.Name = "lbl_POSCode"
        Me.lbl_POSCode.Size = New System.Drawing.Size(87, 22)
        Me.lbl_POSCode.TabIndex = 18
        Me.lbl_POSCode.Text = "MONTH :"
        '
        'Dtp_CloseDate
        '
        Me.Dtp_CloseDate.CustomFormat = "MMMM"
        Me.Dtp_CloseDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_CloseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp_CloseDate.Location = New System.Drawing.Point(117, 154)
        Me.Dtp_CloseDate.Name = "Dtp_CloseDate"
        Me.Dtp_CloseDate.Size = New System.Drawing.Size(112, 26)
        Me.Dtp_CloseDate.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Stencil", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(313, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 25)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "MONTH CLOSE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(28, 230)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(746, 299)
        Me.DataGridView1.TabIndex = 24
        '
        'lbl_monthproc
        '
        Me.lbl_monthproc.AutoSize = True
        Me.lbl_monthproc.BackColor = System.Drawing.Color.Transparent
        Me.lbl_monthproc.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_monthproc.ForeColor = System.Drawing.Color.Red
        Me.lbl_monthproc.Location = New System.Drawing.Point(46, 91)
        Me.lbl_monthproc.Name = "lbl_monthproc"
        Me.lbl_monthproc.Size = New System.Drawing.Size(87, 22)
        Me.lbl_monthproc.TabIndex = 25
        Me.lbl_monthproc.Text = "MONTH :"
        Me.lbl_monthproc.Visible = False
        '
        'Month_process
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(821, 530)
        Me.Controls.Add(Me.lbl_monthproc)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_display)
        Me.Controls.Add(Me.cmd_Cancel)
        Me.Controls.Add(Me.CMD_PROCESS)
        Me.Controls.Add(Me.cmd_check)
        Me.Controls.Add(Me.lbl_POSCode)
        Me.Controls.Add(Me.Dtp_CloseDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Month_process"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Month_process"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_display As System.Windows.Forms.Label
    Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents CMD_PROCESS As System.Windows.Forms.Button
    Friend WithEvents cmd_check As System.Windows.Forms.Button
    Friend WithEvents lbl_POSCode As System.Windows.Forms.Label
    Friend WithEvents Dtp_CloseDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_monthproc As System.Windows.Forms.Label
End Class
