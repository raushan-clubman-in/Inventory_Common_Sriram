<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DayCloseForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Dtp_FromDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btn_Rectify = New System.Windows.Forms.Button()
        Me.Cmd_MonthClose = New System.Windows.Forms.Button()
        Me.Cmd_Process = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Lbl_Info = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Stencil", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(307, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(273, 32)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "DAY CLOSE PROCESS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(100, 142)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 28)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Date For"
        '
        'Dtp_FromDate
        '
        Me.Dtp_FromDate.CustomFormat = "dd/MMM/yyyy"
        Me.Dtp_FromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp_FromDate.Location = New System.Drawing.Point(201, 142)
        Me.Dtp_FromDate.Margin = New System.Windows.Forms.Padding(4)
        Me.Dtp_FromDate.Name = "Dtp_FromDate"
        Me.Dtp_FromDate.Size = New System.Drawing.Size(171, 30)
        Me.Dtp_FromDate.TabIndex = 23
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Btn_Rectify)
        Me.Panel1.Controls.Add(Me.Cmd_MonthClose)
        Me.Panel1.Controls.Add(Me.Cmd_Process)
        Me.Panel1.Controls.Add(Me.Cmd_Exit)
        Me.Panel1.Location = New System.Drawing.Point(378, 127)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(696, 60)
        Me.Panel1.TabIndex = 24
        '
        'Btn_Rectify
        '
        Me.Btn_Rectify.BackColor = System.Drawing.Color.Blue
        Me.Btn_Rectify.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Rectify.ForeColor = System.Drawing.Color.White
        Me.Btn_Rectify.Image = Global.Inventory.My.Resources.Resources.Check_24x24
        Me.Btn_Rectify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btn_Rectify.Location = New System.Drawing.Point(566, 5)
        Me.Btn_Rectify.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Rectify.Name = "Btn_Rectify"
        Me.Btn_Rectify.Size = New System.Drawing.Size(121, 49)
        Me.Btn_Rectify.TabIndex = 9
        Me.Btn_Rectify.Text = "RECTIFY"
        Me.Btn_Rectify.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btn_Rectify.UseVisualStyleBackColor = False
        '
        'Cmd_MonthClose
        '
        Me.Cmd_MonthClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Cmd_MonthClose.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_MonthClose.ForeColor = System.Drawing.Color.White
        Me.Cmd_MonthClose.Image = Global.Inventory.My.Resources.Resources.excel
        Me.Cmd_MonthClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_MonthClose.Location = New System.Drawing.Point(347, 5)
        Me.Cmd_MonthClose.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmd_MonthClose.Name = "Cmd_MonthClose"
        Me.Cmd_MonthClose.Size = New System.Drawing.Size(221, 49)
        Me.Cmd_MonthClose.TabIndex = 8
        Me.Cmd_MonthClose.Text = "Processed to Close"
        Me.Cmd_MonthClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_MonthClose.UseVisualStyleBackColor = False
        '
        'Cmd_Process
        '
        Me.Cmd_Process.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Cmd_Process.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Process.ForeColor = System.Drawing.Color.White
        Me.Cmd_Process.Image = Global.Inventory.My.Resources.Resources.excel
        Me.Cmd_Process.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Process.Location = New System.Drawing.Point(5, 5)
        Me.Cmd_Process.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmd_Process.Name = "Cmd_Process"
        Me.Cmd_Process.Size = New System.Drawing.Size(208, 49)
        Me.Cmd_Process.TabIndex = 5
        Me.Cmd_Process.Text = "Process to Check"
        Me.Cmd_Process.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Process.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Red
        Me.Cmd_Exit.Font = New System.Drawing.Font("Stencil", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = Global.Inventory.My.Resources.Resources.Delete
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(211, 5)
        Me.Cmd_Exit.Margin = New System.Windows.Forms.Padding(4)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(137, 49)
        Me.Cmd_Exit.TabIndex = 7
        Me.Cmd_Exit.Text = "EXIT"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 249)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1062, 346)
        Me.DataGridView1.TabIndex = 25
        '
        'Lbl_Info
        '
        Me.Lbl_Info.AutoSize = True
        Me.Lbl_Info.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Info.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Info.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Info.Location = New System.Drawing.Point(21, 213)
        Me.Lbl_Info.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Info.Name = "Lbl_Info"
        Me.Lbl_Info.Size = New System.Drawing.Size(50, 28)
        Me.Lbl_Info.TabIndex = 26
        Me.Lbl_Info.Text = "Info"
        '
        'DayCloseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources.NUIScreen
        Me.ClientSize = New System.Drawing.Size(1080, 603)
        Me.Controls.Add(Me.Lbl_Info)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Dtp_FromDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "DayCloseForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MonthCloseForm"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cmd_Process As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Lbl_Info As System.Windows.Forms.Label
    Friend WithEvents Cmd_MonthClose As System.Windows.Forms.Button
    Friend WithEvents Btn_Rectify As Button
End Class
