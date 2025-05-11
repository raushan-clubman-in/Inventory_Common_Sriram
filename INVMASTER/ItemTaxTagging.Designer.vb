<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemTaxTagging
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemTaxTagging))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.cmd_save = New System.Windows.Forms.Button()
        Me.AxfpSpread1 = New AxFPSpreadADO.AxfpSpread()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(218, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(268, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ITEM TAX GROUP TAGGING"
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox2.Controls.Add(Me.cmd_exit)
        Me.GroupBox2.Controls.Add(Me.cmd_save)
        Me.GroupBox2.Location = New System.Drawing.Point(711, 197)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(136, 132)
        Me.GroupBox2.TabIndex = 378
        Me.GroupBox2.TabStop = False
        '
        'cmd_exit
        '
        Me.cmd_exit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_exit.BackgroundImage = CType(resources.GetObject("cmd_exit.BackgroundImage"), System.Drawing.Image)
        Me.cmd_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_exit.FlatAppearance.BorderSize = 0
        Me.cmd_exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_exit.Location = New System.Drawing.Point(6, 67)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(124, 46)
        Me.cmd_exit.TabIndex = 1
        Me.cmd_exit.Text = "EXIT[F11]"
        Me.cmd_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_exit.UseVisualStyleBackColor = False
        '
        'cmd_save
        '
        Me.cmd_save.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmd_save.BackgroundImage = CType(resources.GetObject("cmd_save.BackgroundImage"), System.Drawing.Image)
        Me.cmd_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_save.FlatAppearance.BorderSize = 0
        Me.cmd_save.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmd_save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmd_save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmd_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_save.Location = New System.Drawing.Point(6, 16)
        Me.cmd_save.Name = "cmd_save"
        Me.cmd_save.Size = New System.Drawing.Size(124, 46)
        Me.cmd_save.TabIndex = 0
        Me.cmd_save.Text = "ADD[F7]"
        Me.cmd_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_save.UseVisualStyleBackColor = False
        '
        'AxfpSpread1
        '
        Me.AxfpSpread1.DataSource = Nothing
        Me.AxfpSpread1.Location = New System.Drawing.Point(18, 150)
        Me.AxfpSpread1.Name = "AxfpSpread1"
        Me.AxfpSpread1.OcxState = CType(resources.GetObject("AxfpSpread1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxfpSpread1.Size = New System.Drawing.Size(647, 449)
        Me.AxfpSpread1.TabIndex = 379
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(12, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 477)
        Me.GroupBox1.TabIndex = 380
        Me.GroupBox1.TabStop = False
        '
        'ItemTaxTagging
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(857, 715)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AxfpSpread1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ItemTaxTagging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Tax Tagging"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.AxfpSpread1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_save As System.Windows.Forms.Button
    Friend WithEvents AxfpSpread1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox1 As GroupBox
End Class
