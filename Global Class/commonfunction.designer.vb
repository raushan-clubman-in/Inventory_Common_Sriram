<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class commonfunction
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
        Me.PENDINGDETAILS_gridview = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PENDINGDETAILS_gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PENDINGDETAILS_gridview
        '
        Me.PENDINGDETAILS_gridview.AllowUserToAddRows = False
        Me.PENDINGDETAILS_gridview.AllowUserToDeleteRows = False
        Me.PENDINGDETAILS_gridview.AllowUserToResizeColumns = False
        Me.PENDINGDETAILS_gridview.AllowUserToResizeRows = False
        Me.PENDINGDETAILS_gridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.PENDINGDETAILS_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PENDINGDETAILS_gridview.Location = New System.Drawing.Point(244, 63)
        Me.PENDINGDETAILS_gridview.Name = "PENDINGDETAILS_gridview"
        Me.PENDINGDETAILS_gridview.ReadOnly = True
        Me.PENDINGDETAILS_gridview.Size = New System.Drawing.Size(845, 390)
        Me.PENDINGDETAILS_gridview.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(489, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pending Data List Inventory Module"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Font = New System.Drawing.Font("Stencil", 9.0!)
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(572, 468)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 55)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Exit [F11]"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'commonfunction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1189, 535)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PENDINGDETAILS_gridview)
        Me.KeyPreview = True
        Me.Name = "commonfunction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PENDINGDETAILS_gridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PENDINGDETAILS_gridview As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
