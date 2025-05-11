<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnMatchedVoucherPosting
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
        Me.CMD_eXIT = New System.Windows.Forms.Button()
        Me.DTGRDHDR = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GBAlert = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DGV_UPPOSTED = New System.Windows.Forms.DataGridView()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DTGRDHDR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GBAlert.SuspendLayout()
        CType(Me.DGV_UPPOSTED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(105, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 19)
        Me.Label1.TabIndex = 5
        '
        'CMD_eXIT
        '
        Me.CMD_eXIT.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CMD_eXIT.Location = New System.Drawing.Point(378, 425)
        Me.CMD_eXIT.Name = "CMD_eXIT"
        Me.CMD_eXIT.Size = New System.Drawing.Size(156, 31)
        Me.CMD_eXIT.TabIndex = 4
        Me.CMD_eXIT.Text = "CLOSE [F11]"
        Me.CMD_eXIT.UseVisualStyleBackColor = True
        '
        'DTGRDHDR
        '
        Me.DTGRDHDR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTGRDHDR.Location = New System.Drawing.Point(23, 98)
        Me.DTGRDHDR.Name = "DTGRDHDR"
        Me.DTGRDHDR.ReadOnly = True
        Me.DTGRDHDR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DTGRDHDR.Size = New System.Drawing.Size(846, 321)
        Me.DTGRDHDR.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.GBAlert)
        Me.GroupBox1.Controls.Add(Me.Cmd_View)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DTGRDHDR)
        Me.GroupBox1.Controls.Add(Me.CMD_eXIT)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(888, 471)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 437)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(261, 19)
        Me.Label3.TabIndex = 473
        Me.Label3.Text = "USE DOUBLE CLICK FOR POSTING"
        '
        'GBAlert
        '
        Me.GBAlert.Controls.Add(Me.Button1)
        Me.GBAlert.Controls.Add(Me.DGV_UPPOSTED)
        Me.GBAlert.Location = New System.Drawing.Point(64, 121)
        Me.GBAlert.Name = "GBAlert"
        Me.GBAlert.Size = New System.Drawing.Size(773, 249)
        Me.GBAlert.TabIndex = 472
        Me.GBAlert.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(314, 207)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(156, 31)
        Me.Button1.TabIndex = 472
        Me.Button1.Text = "CLOSE [F10]"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DGV_UPPOSTED
        '
        Me.DGV_UPPOSTED.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_UPPOSTED.Location = New System.Drawing.Point(42, 19)
        Me.DGV_UPPOSTED.Name = "DGV_UPPOSTED"
        Me.DGV_UPPOSTED.Size = New System.Drawing.Size(693, 182)
        Me.DGV_UPPOSTED.TabIndex = 471
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_View.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(607, 46)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(98, 33)
        Me.Cmd_View.TabIndex = 470
        Me.Cmd_View.Text = "VIEW [F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(344, 49)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(222, 23)
        Me.ComboBox1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "SELECT VOUCHER TYPE"
        '
        'UnMatchedVoucherPosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 495)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "UnMatchedVoucherPosting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "CHECK PURCHASE RATE"
        Me.TopMost = True
        CType(Me.DTGRDHDR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GBAlert.ResumeLayout(False)
        CType(Me.DGV_UPPOSTED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMD_eXIT As System.Windows.Forms.Button
    Friend WithEvents DTGRDHDR As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents DGV_UPPOSTED As System.Windows.Forms.DataGridView
    Friend WithEvents GBAlert As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
