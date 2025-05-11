<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PO_DeliveryTerm
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
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ChkLst_Group = New System.Windows.Forms.CheckedListBox()
        Me.Chk_AllGroup = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Maroon
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(697, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 24)
        Me.Label10.TabIndex = 495
        Me.Label10.Text = "F2"
        '
        'ChkLst_Group
        '
        Me.ChkLst_Group.CheckOnClick = True
        Me.ChkLst_Group.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkLst_Group.Location = New System.Drawing.Point(52, 89)
        Me.ChkLst_Group.Name = "ChkLst_Group"
        Me.ChkLst_Group.Size = New System.Drawing.Size(678, 244)
        Me.ChkLst_Group.TabIndex = 492
        '
        'Chk_AllGroup
        '
        Me.Chk_AllGroup.BackColor = System.Drawing.Color.Transparent
        Me.Chk_AllGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_AllGroup.Location = New System.Drawing.Point(53, 41)
        Me.Chk_AllGroup.Name = "Chk_AllGroup"
        Me.Chk_AllGroup.Size = New System.Drawing.Size(136, 24)
        Me.Chk_AllGroup.TabIndex = 493
        Me.Chk_AllGroup.Text = "SELECT ALL "
        Me.Chk_AllGroup.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(53, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(677, 24)
        Me.Label2.TabIndex = 494
        Me.Label2.Text = "Delivery Term Selection :"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(334, 341)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 32)
        Me.btnCancel.TabIndex = 496
        Me.btnCancel.Text = "&Close"
        '
        'PO_DeliveryTerm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(763, 385)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ChkLst_Group)
        Me.Controls.Add(Me.Chk_AllGroup)
        Me.Controls.Add(Me.Label2)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PO_DeliveryTerm"
        Me.Text = "PO_DeliveryTerm"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ChkLst_Group As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_AllGroup As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
