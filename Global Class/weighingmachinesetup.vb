Public Class weighingmachinesetup
    Inherits System.Windows.Forms.Form
    Dim ssql As String
    Dim gconn As New GlobalClass
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
    Friend WithEvents chkweight As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Grp_ADMIN As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(weighingmachinesetup))
        Me.chkweight = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Grp_ADMIN = New System.Windows.Forms.GroupBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Grp_ADMIN.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkweight
        '
        Me.chkweight.BackColor = System.Drawing.Color.Transparent
        Me.chkweight.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkweight.Location = New System.Drawing.Point(48, 192)
        Me.chkweight.Name = "chkweight"
        Me.chkweight.Size = New System.Drawing.Size(272, 24)
        Me.chkweight.TabIndex = 0
        Me.chkweight.Text = "OPEN ENTRY ALLOWED"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(128, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 723
        Me.Label7.Text = "Ctrl>       S            E"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.SystemColors.Control
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(152, 8)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(40, 26)
        Me.Cmd_Add.TabIndex = 721
        Me.Cmd_Add.Text = "S"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.SystemColors.Control
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(192, 8)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(40, 26)
        Me.Cmd_Exit.TabIndex = 722
        Me.Cmd_Exit.Text = "E"
        '
        'Grp_ADMIN
        '
        Me.Grp_ADMIN.Controls.Add(Me.Button6)
        Me.Grp_ADMIN.Controls.Add(Me.Button5)
        Me.Grp_ADMIN.Controls.Add(Me.TextBox1)
        Me.Grp_ADMIN.Controls.Add(Me.Label9)
        Me.Grp_ADMIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Grp_ADMIN.Location = New System.Drawing.Point(32, 8)
        Me.Grp_ADMIN.Name = "Grp_ADMIN"
        Me.Grp_ADMIN.Size = New System.Drawing.Size(304, 224)
        Me.Grp_ADMIN.TabIndex = 724
        Me.Grp_ADMIN.TabStop = False
        Me.Grp_ADMIN.Text = "AdminLogin"
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(192, 144)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(56, 32)
        Me.Button6.TabIndex = 3
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.Location = New System.Drawing.Point(80, 96)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(128, 32)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "Loging"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(120, 48)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(160, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 23)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Password"
        '
        'weighingmachinesetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(360, 277)
        Me.Controls.Add(Me.Grp_ADMIN)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.chkweight)
        Me.Name = "weighingmachinesetup"
        Me.Text = "weighingmachinesetup"
        Me.Grp_ADMIN.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub weighingmachinesetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ssql = "select isnull(allowed,0)as allowed from weighingmachineovveride"
        gconn.getDataSet(ssql, "weigh")
        If gdataset.Tables("weigh").Rows.Count > 0 Then
            If Val(gdataset.Tables("weigh").Rows(0).Item(0)) > 0 Then
                chkweight.Checked = True
            Else
                chkweight.Checked = False
            End If
        End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Try
            ssql = "delete from weighingmachineovveride"
            gconn.ExcuteStoreProcedure(ssql)

            If chkweight.Checked = True Then
                ssql = "insert into weighingmachineovveride values (1)"
                gconn.ExcuteStoreProcedure(ssql)
                ssql = "insert into weighingmachineovveridehistory( allowed ,adduser ,adddatetime)values(1,'" & gUsername & "',getdate())"
                gconn.ExcuteStoreProcedure(ssql)
                MsgBox("Transaction completed successfully")
            Else
                ssql = "insert into weighingmachineovveride values (0)"
                gconn.ExcuteStoreProcedure(ssql)
                ssql = "insert into weighingmachineovveridehistory( allowed ,adduser ,adddatetime)values(0,'" & gUsername & "',getdate())"
                gconn.ExcuteStoreProcedure(ssql)
                MsgBox("Transaction completed successfully")
            End If
        Catch ex As Exception
            MsgBox("error" & ex.ToString())
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim sqlstring As String
        If (TextBox1.Text = "") Then
            MsgBox("Please enter Password")
            Me.TextBox1.Focus()
            Exit Sub
        End If
        sqlstring = "SELECT * FROM BBSRLOGING WHERE   USERPWD ='" & Trim((UCase(TextBox1.Text))) & "'"
        gconn.getDataSet(sqlstring, "BBSRLOGING")
        'If TextBox1.Text <> "" Then
        If gdataset.Tables("BBSRLOGING").Rows.Count > 0 Then
            Me.Grp_ADMIN.Visible = False
        Else
            Me.Grp_ADMIN.Visible = True
            MessageBox.Show("Invalid Username Or Password !!! Contact System Admin", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub
End Class
