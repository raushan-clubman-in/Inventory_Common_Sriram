<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TRANSCONV_CHECK
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
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DTGRDHDR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(81, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(546, 19)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "ITEM DETAILS WHOSE INVENTORY UOM CONVERSION IS NOT GIVEN"
        '
        'CMD_eXIT
        '
        Me.CMD_eXIT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_eXIT.Location = New System.Drawing.Point(280, 444)
        Me.CMD_eXIT.Name = "CMD_eXIT"
        Me.CMD_eXIT.Size = New System.Drawing.Size(97, 31)
        Me.CMD_eXIT.TabIndex = 7
        Me.CMD_eXIT.Text = "EXIT"
        Me.CMD_eXIT.UseVisualStyleBackColor = True
        '
        'DTGRDHDR
        '
        Me.DTGRDHDR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTGRDHDR.Location = New System.Drawing.Point(80, 79)
        Me.DTGRDHDR.Name = "DTGRDHDR"
        Me.DTGRDHDR.Size = New System.Drawing.Size(563, 321)
        Me.DTGRDHDR.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(394, 444)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 31)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TRANSCONV_CHECK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 514)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CMD_eXIT)
        Me.Controls.Add(Me.DTGRDHDR)
        Me.Name = "TRANSCONV_CHECK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TRANSCONV_CHECK"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DTGRDHDR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMD_eXIT As System.Windows.Forms.Button
    Friend WithEvents DTGRDHDR As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
