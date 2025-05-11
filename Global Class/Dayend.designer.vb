<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dayend
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dayend))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTGRD = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.IN_DAYEND = New System.Windows.Forms.Button()
        Me.DTPROCESSFINISH = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.chk_accode = New System.Windows.Forms.CheckedListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Dtp_billdate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.cmdrndoff = New System.Windows.Forms.Button()
        CType(Me.DTGRD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTPROCESSFINISH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(222, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(280, 40)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Day End  Inventory"
        '
        'DTGRD
        '
        Me.DTGRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTGRD.Location = New System.Drawing.Point(22, 230)
        Me.DTGRD.Name = "DTGRD"
        Me.DTGRD.Size = New System.Drawing.Size(767, 187)
        Me.DTGRD.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(192, 203)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(614, 33)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "RESOLVE MESSAGES FOR All MODULES"
        '
        'IN_DAYEND
        '
        Me.IN_DAYEND.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IN_DAYEND.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IN_DAYEND.Location = New System.Drawing.Point(58, 634)
        Me.IN_DAYEND.Name = "IN_DAYEND"
        Me.IN_DAYEND.Size = New System.Drawing.Size(202, 65)
        Me.IN_DAYEND.TabIndex = 6
        Me.IN_DAYEND.Text = "INITIATE  DAY END"
        Me.IN_DAYEND.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IN_DAYEND.UseVisualStyleBackColor = True
        '
        'DTPROCESSFINISH
        '
        Me.DTPROCESSFINISH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTPROCESSFINISH.Location = New System.Drawing.Point(3, 193)
        Me.DTPROCESSFINISH.Name = "DTPROCESSFINISH"
        Me.DTPROCESSFINISH.Size = New System.Drawing.Size(859, 435)
        Me.DTPROCESSFINISH.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(598, 634)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 65)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "EXIT"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(285, 634)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(135, 65)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "DETAILS"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'chk_accode
        '
        Me.chk_accode.FormattingEnabled = True
        Me.chk_accode.Location = New System.Drawing.Point(868, 193)
        Me.chk_accode.Name = "chk_accode"
        Me.chk_accode.Size = New System.Drawing.Size(184, 368)
        Me.chk_accode.TabIndex = 10
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(439, 634)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(135, 65)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "CONFIRM"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Dtp_billdate
        '
        Me.Dtp_billdate.CustomFormat = "dd-MMM-yyyy"
        Me.Dtp_billdate.Enabled = False
        Me.Dtp_billdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp_billdate.Location = New System.Drawing.Point(439, 164)
        Me.Dtp_billdate.Name = "Dtp_billdate"
        Me.Dtp_billdate.Size = New System.Drawing.Size(98, 31)
        Me.Dtp_billdate.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(281, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(197, 31)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Day End Till Date"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(1101, 127)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(215, 25)
        Me.CheckBox2.TabIndex = 14
        Me.CheckBox2.Text = "Select All / UnSelect All"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'cmdrndoff
        '
        Me.cmdrndoff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdrndoff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdrndoff.Location = New System.Drawing.Point(868, 581)
        Me.cmdrndoff.Name = "cmdrndoff"
        Me.cmdrndoff.Size = New System.Drawing.Size(213, 65)
        Me.cmdrndoff.TabIndex = 15
        Me.cmdrndoff.Text = "PASS ROUND OFF ENTRY"
        Me.cmdrndoff.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdrndoff.UseVisualStyleBackColor = True
        '
        'Dayend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1307, 700)
        Me.Controls.Add(Me.cmdrndoff)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Dtp_billdate)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.chk_accode)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DTPROCESSFINISH)
        Me.Controls.Add(Me.IN_DAYEND)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DTGRD)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Dayend"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dayend"
        CType(Me.DTGRD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTPROCESSFINISH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTGRD As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents IN_DAYEND As System.Windows.Forms.Button
    Friend WithEvents DTPROCESSFINISH As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents chk_accode As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Dtp_billdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdrndoff As System.Windows.Forms.Button
End Class
