Public Class InputBoxCustom
    Inherits System.Windows.Forms.Form
    Dim gconnection As New GlobalClass
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public COMMENT As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bt_ok As System.Windows.Forms.Button
    Friend WithEvents bt_cancel As System.Windows.Forms.Button
    Friend WithEvents TXT_PASS As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_ok = New System.Windows.Forms.Button()
        Me.bt_cancel = New System.Windows.Forms.Button()
        Me.TXT_PASS = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(406, 34)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ENTER YOUR APPROVE PASSWORD :"
        '
        'bt_ok
        '
        Me.bt_ok.BackColor = System.Drawing.Color.Wheat
        Me.bt_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_ok.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ok.Location = New System.Drawing.Point(54, 134)
        Me.bt_ok.Name = "bt_ok"
        Me.bt_ok.Size = New System.Drawing.Size(120, 60)
        Me.bt_ok.TabIndex = 1
        Me.bt_ok.Text = "OK"
        Me.bt_ok.UseVisualStyleBackColor = False
        '
        'bt_cancel
        '
        Me.bt_cancel.BackColor = System.Drawing.Color.Wheat
        Me.bt_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cancel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cancel.Location = New System.Drawing.Point(195, 129)
        Me.bt_cancel.Name = "bt_cancel"
        Me.bt_cancel.Size = New System.Drawing.Size(120, 69)
        Me.bt_cancel.TabIndex = 2
        Me.bt_cancel.Text = "CANCEL"
        Me.bt_cancel.UseVisualStyleBackColor = False
        '
        'TXT_PASS
        '
        Me.TXT_PASS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_PASS.Location = New System.Drawing.Point(22, 57)
        Me.TXT_PASS.Multiline = True
        Me.TXT_PASS.Name = "TXT_PASS"
        Me.TXT_PASS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXT_PASS.Size = New System.Drawing.Size(293, 50)
        Me.TXT_PASS.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Wheat
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(330, 67)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(41, 34)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = ":-)"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'InputBoxCustom
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.ClientSize = New System.Drawing.Size(456, 211)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TXT_PASS)
        Me.Controls.Add(Me.bt_cancel)
        Me.Controls.Add(Me.bt_ok)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "InputBoxCustom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Input Command Box"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub bt_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_ok.Click
        If Trim(TXT_PASS.Text) <> "" Then
            COMMENT = Trim(TXT_PASS.Text)
            Me.Close()
        Else
            MessageBox.Show("Enter the Password !..")
        End If
    End Sub

    Private Sub bt_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_cancel.Click
        TXT_PASS.Text = ""
        COMMENT = ""
        Me.Close()


    End Sub

    Private Sub password_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TXT_PASS.Text = ""
        COMMENT = ""
    End Sub

    Private Sub TXT_PASS_TextChanged(sender As Object, e As EventArgs) Handles TXT_PASS.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TXT_PASS.PasswordChar = ""
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        TXT_PASS.PasswordChar = "*"
    End Sub

End Class
