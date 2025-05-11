Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Text
Imports System.IO
Public Class Form1
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Usertype As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_Turnoff As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXT_NEWPASSWORD As System.Windows.Forms.TextBox
    Friend WithEvents CHK_CHANGEPWD As System.Windows.Forms.CheckBox
    Friend WithEvents Cmd_Cancel As System.Windows.Forms.Button
    Friend WithEvents Cmd_Login As System.Windows.Forms.Button
    Friend WithEvents Txt_Password As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_Username As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Cmd_Turnoff = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Cbo_Usertype = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXT_NEWPASSWORD = New System.Windows.Forms.TextBox()
        Me.CHK_CHANGEPWD = New System.Windows.Forms.CheckBox()
        Me.Cmd_Cancel = New System.Windows.Forms.Button()
        Me.Cmd_Login = New System.Windows.Forms.Button()
        Me.Txt_Password = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Username = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Cmd_Turnoff
        '
        Me.Cmd_Turnoff.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Turnoff.Image = CType(resources.GetObject("Cmd_Turnoff.Image"), System.Drawing.Image)
        Me.Cmd_Turnoff.Location = New System.Drawing.Point(10, 25)
        Me.Cmd_Turnoff.Name = "Cmd_Turnoff"
        Me.Cmd_Turnoff.Size = New System.Drawing.Size(38, 35)
        Me.Cmd_Turnoff.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(62, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Turn off Application"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(901, 465)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Invalid User"
        Me.Label5.Visible = False
        '
        'Cbo_Usertype
        '
        Me.Cbo_Usertype.BackColor = System.Drawing.Color.Wheat
        Me.Cbo_Usertype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_Usertype.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cbo_Usertype.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Cbo_Usertype.Items.AddRange(New Object() {"ADMINISTRATOR", "USER"})
        Me.Cbo_Usertype.Location = New System.Drawing.Point(909, 362)
        Me.Cbo_Usertype.Name = "Cbo_Usertype"
        Me.Cbo_Usertype.Size = New System.Drawing.Size(214, 31)
        Me.Cbo_Usertype.TabIndex = 1
        Me.Cbo_Usertype.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(768, 362)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 23)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "LOGIN AS :"
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(1010, 1099)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(640, 28)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Copyrights Reserved 2004-2009  by Clubman Software"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(760, 574)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(207, 25)
        Me.Label9.TabIndex = 601
        Me.Label9.Text = "NEW PASSWORD :"
        Me.Label9.Visible = False
        '
        'TXT_NEWPASSWORD
        '
        Me.TXT_NEWPASSWORD.BackColor = System.Drawing.Color.White
        Me.TXT_NEWPASSWORD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_NEWPASSWORD.Font = New System.Drawing.Font("Wingdings", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.TXT_NEWPASSWORD.ForeColor = System.Drawing.Color.Blue
        Me.TXT_NEWPASSWORD.Location = New System.Drawing.Point(995, 571)
        Me.TXT_NEWPASSWORD.MaxLength = 20
        Me.TXT_NEWPASSWORD.Name = "TXT_NEWPASSWORD"
        Me.TXT_NEWPASSWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(50)
        Me.TXT_NEWPASSWORD.Size = New System.Drawing.Size(215, 29)
        Me.TXT_NEWPASSWORD.TabIndex = 600
        Me.TXT_NEWPASSWORD.Visible = False
        '
        'CHK_CHANGEPWD
        '
        Me.CHK_CHANGEPWD.BackColor = System.Drawing.Color.Transparent
        Me.CHK_CHANGEPWD.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CHK_CHANGEPWD.Location = New System.Drawing.Point(558, 571)
        Me.CHK_CHANGEPWD.Name = "CHK_CHANGEPWD"
        Me.CHK_CHANGEPWD.Size = New System.Drawing.Size(192, 28)
        Me.CHK_CHANGEPWD.TabIndex = 599
        Me.CHK_CHANGEPWD.Text = "Change Password"
        Me.CHK_CHANGEPWD.UseVisualStyleBackColor = False
        '
        'Cmd_Cancel
        '
        Me.Cmd_Cancel.BackColor = System.Drawing.Color.White
        Me.Cmd_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Cancel.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Cancel.Image = CType(resources.GetObject("Cmd_Cancel.Image"), System.Drawing.Image)
        Me.Cmd_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Cancel.Location = New System.Drawing.Point(1066, 500)
        Me.Cmd_Cancel.Name = "Cmd_Cancel"
        Me.Cmd_Cancel.Size = New System.Drawing.Size(136, 35)
        Me.Cmd_Cancel.TabIndex = 3
        Me.Cmd_Cancel.Text = "Cancel"
        Me.Cmd_Cancel.UseVisualStyleBackColor = False
        '
        'Cmd_Login
        '
        Me.Cmd_Login.BackColor = System.Drawing.Color.White
        Me.Cmd_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Login.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Login.Image = CType(resources.GetObject("Cmd_Login.Image"), System.Drawing.Image)
        Me.Cmd_Login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Login.Location = New System.Drawing.Point(1066, 425)
        Me.Cmd_Login.Name = "Cmd_Login"
        Me.Cmd_Login.Size = New System.Drawing.Size(132, 35)
        Me.Cmd_Login.TabIndex = 2
        Me.Cmd_Login.Text = "Login"
        Me.Cmd_Login.UseVisualStyleBackColor = False
        '
        'Txt_Password
        '
        Me.Txt_Password.BackColor = System.Drawing.Color.White
        Me.Txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Password.Font = New System.Drawing.Font("Wingdings", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Txt_Password.ForeColor = System.Drawing.Color.Blue
        Me.Txt_Password.Location = New System.Drawing.Point(789, 500)
        Me.Txt_Password.MaxLength = 10
        Me.Txt_Password.Name = "Txt_Password"
        Me.Txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(50)
        Me.Txt_Password.Size = New System.Drawing.Size(214, 29)
        Me.Txt_Password.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(230, 398)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "PASSWORD :"
        Me.Label3.Visible = False
        '
        'Txt_Username
        '
        Me.Txt_Username.BackColor = System.Drawing.Color.White
        Me.Txt_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Username.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Username.ForeColor = System.Drawing.Color.Blue
        Me.Txt_Username.Location = New System.Drawing.Point(789, 427)
        Me.Txt_Username.MaxLength = 10
        Me.Txt_Username.Name = "Txt_Username"
        Me.Txt_Username.Size = New System.Drawing.Size(214, 30)
        Me.Txt_Username.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(218, 351)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 23)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "USER NAME :"
        Me.Label2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Cmd_Login)
        Me.GroupBox1.Controls.Add(Me.CHK_CHANGEPWD)
        Me.GroupBox1.Controls.Add(Me.Txt_Password)
        Me.GroupBox1.Controls.Add(Me.Cmd_Cancel)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Txt_Username)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TXT_NEWPASSWORD)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(-10, -9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1927, 1136)
        Me.GroupBox1.TabIndex = 602
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Cmd_Turnoff)
        Me.GroupBox2.Location = New System.Drawing.Point(61, 995)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 72)
        Me.GroupBox2.TabIndex = 603
        Me.GroupBox2.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 732)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cbo_Usertype)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clubman Login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim gconnection As New GlobalClass


    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 732
        K = 1016
        Me.ResizeRedraw = True

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        If U = 800 Then
            T = T - 50
        End If
        If U = 1280 Then
            T = T - 50
        End If
        If U = 1360 Then
            T = T - 75
        End If
        If U = 1366 Then
            T = T - 75
        End If
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Width = U
        Me.Height = T


        With Me
            For i_i = 0 To .Controls.Count - 1
                ' MsgBox(Controls(i_i).Name)
                If TypeOf .Controls(i_i) Is Form Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0
                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If
                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                ElseIf TypeOf .Controls(i_i) Is Panel Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is GroupBox Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        If Controls(i_i).Name = "GroupBox2" Then
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            If U = 800 Then
                                L = L + 50
                            End If
                            If U = 1280 Then
                                L = L + 50
                            End If
                            If U = 1360 Then
                                L = L + 75
                            End If
                            If U = 1366 Then
                                L = L + 75
                            End If
                        Else
                            L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))

                            ' L = L - 5
                        End If
                    End If

                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is Label Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - K) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - J) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                End If
            Next i_i
        End With
    End Sub

    Private Sub getdashdata()
        Dim ServerConn As New OleDb.OleDbConnection
        Dim servercmd As New OleDb.OleDbDataAdapter
        Dim getserver As New DataSet
        Dim sql, ssql As String
        sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
        sql = sql & AppPath & "\DBS_KEY.MDB"
        ServerConn.ConnectionString = sql
        'Added on 05 Dec'07 for DBS_KEY Username and Password
        'Mk Kannan
        'Begin
        'End
        Try
            ServerConn.Open()

            ssql = "SELECT  USERNAME, PASSWORD FROM Dashboardvalidation"
            servercmd = New OleDb.OleDbDataAdapter(ssql, ServerConn)
            servercmd.Fill(getserver)
            If getserver.Tables(0).Rows.Count > 0 Then
                '    gserver = abcdMINUS(Trim(getserver.Tables(0).Rows(0).Item(0) & ""))
                Txt_Username.Text = Trim(getserver.Tables(0).Rows(0).Item(0) & "")
                'Added on 05 Dec'07 for DBS_KEY Username and Password
                'Mk Kannan
                'Begin
                Txt_Password.Text = Trim(getserver.Tables(0).Rows(0).Item(1) & "")
                '   SQL_UserName = abcdMINUS(Trim(getserver.Tables(0).Rows(0).Item(1) & ""))
                ' GetMasterConnection()
                ''Cmd_Login_Click(sender, e)
            Else
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to connect to data source")
            MsgBox(ex.Message)
        Finally
            ServerConn.Close()
        End Try


    End Sub

   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cbo_Usertype.SelectedIndex = 0
        gconnection.FileInfo(Application.StartupPath & "\inventory.Exe")
        AppPath = Application.StartupPath
        Dim str As String
        If Dir(AppPath & "\Reports", FileAttribute.Directory) = "" Then
            MkDir(AppPath & "\Reports")
        End If
        Me.DoubleBuffered = True
        Call Resize_Form()

        Call GetPrinter()
        Call GetServer()
        Call GetEXCELPATH()
        'Call GeTPHOTO()
        Me.Txt_Username.Focus()

        'str = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'dashboardvalidation'"
        'gconnection.getDataSet(str, "INFORMATION_SCHEMA")
        'If gdataset.Tables("INFORMATION_SCHEMA").Rows.Count > 0 Then

        '    str = "select * from dashboardvalidation"
        '    gconnection.getDataSet(str, "dashboardvalidation")
        '    If gdataset.Tables("dashboardvalidation").Rows.Count > 0 Then
        '        Txt_Username.Text = gdataset.Tables("dashboardvalidation").Rows(0).Item("username")
        '        Txt_Password.Text = Trim(SetPassword(UCase(gdataset.Tables("dashboardvalidation").Rows(0).Item("password"))))
        '        Cmd_Login_Click(sender, e)
        '    End If

        'End If


        Dim ServerConn As New OleDb.OleDbConnection
        Dim servercmd As New OleDb.OleDbDataAdapter
        Dim getserver1 As New DataSet
        Dim sql, ssql As String
        sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
        sql = sql & AppPath & "\DBS_KEY.MDB"
        ServerConn.ConnectionString = sql
        'Added on 05 Dec'07 for DBS_KEY Username and Password
        'Mk Kannan
        'Begin
        'End
        Try
            ServerConn.Open()

            ssql = "SELECT  USERNAME, PASSWORD FROM Dashboardvalidation"
            servercmd = New OleDb.OleDbDataAdapter(ssql, ServerConn)
            servercmd.Fill(getserver1)
            If getserver1.Tables(0).Rows.Count > 0 Then
                '    gserver = abcdMINUS(Trim(getserver.Tables(0).Rows(0).Item(0) & ""))
                Txt_Username.Text = Trim(getserver1.Tables(0).Rows(0).Item(0) & "")
                'Added on 05 Dec'07 for DBS_KEY Username and Password
                'Mk Kannan
                'Begin
                Txt_Password.Text = Trim(getserver1.Tables(0).Rows(0).Item(1) & "")
                '   SQL_UserName = abcdMINUS(Trim(getserver.Tables(0).Rows(0).Item(1) & ""))
                ' GetMasterConnection()
                Cmd_Login_Click(sender, e)
            Else
            End If
        Catch ex As Exception

            'MessageBox.Show("Failed to connect to data source")
            'MsgBox(ex.Message)
        Finally
            ServerConn.Close()
        End Try



    End Sub


    Private Sub Txt_Username_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Username.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt_Password.Focus()
        End If
    End Sub

    Private Sub Txt_Password_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Password.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Trim(Txt_Password.Text) = "" Then
                Txt_Password.Focus()
            Else
                Cmd_Login.Focus()
            End If
        End If
    End Sub




    Private Sub Cmd_Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Login.Click
        Dim SQLSTRING As String
        If (Trim(Txt_Username.Text) = "") Then
            ErrorProvider1.SetError(Txt_Username, "Please enter User name")
        Else
            ErrorProvider1.SetError(Txt_Username, "")
        End If
        If (Trim(Txt_Password.Text) = "") Then
            ErrorProvider1.SetError(Txt_Password, "Please enter Password")
        Else
            ErrorProvider1.SetError(Txt_Password, "")
        End If
        If (Trim(Cbo_Usertype.Text) = "") Then
            ErrorProvider1.SetError(Cbo_Usertype, "Please Select Login")
        Else
            ErrorProvider1.SetError(Cbo_Usertype, "")
        End If

        Try
            If Me.Cbo_Usertype.Text = "USER" Then
                SQLSTRING = "SELECT * FROM USERADMIN WHERE  USERNAME = '" & Trim(UCase(Txt_Username.Text)) & "' and USERPASSWORD ='" & Trim(GetPassword(UCase(Txt_Password.Text))) & "'"
            Else
                SQLSTRING = "SELECT * FROM USERADMIN WHERE  USERNAME = '" & Trim(UCase(Txt_Username.Text)) & "' and USERPASSWORD ='" & Trim(GetPassword(UCase(Txt_Password.Text))) & "' "
            End If
            gconnection.getCompanyinfo(SQLSTRING, "ClubMaster")
            If gdataset.Tables("ClubMaster").Rows.Count > 0 Then
                gUsername = Trim(Txt_Username.Text)
                gUserCategory = gdataset.Tables("ClubMaster").Rows(0).Item("CATEGORY")
                ' User Change Password
                If CHK_CHANGEPWD.Checked = True And Trim(TXT_NEWPASSWORD.Text) <> "" Then
                    Dim vstr As String
                    vstr = abcdADD(UCase(Trim(TXT_NEWPASSWORD.Text)))
                    SQLSTRING = "UPDATE MASTER..USERADMIN SET USERPASSWORD='" & Trim(vstr) & "' WHERE USERNAME='" & Trim(Txt_Username.Text) & "'"
                    gconnection.getCompanyinfo(SQLSTRING, "USERUPDATE")
                    SQLSTRING = "UPDATE " & Trim(gDatabase) & "..USERADMIN SET USERPASSWORD='" & Trim(vstr) & "' WHERE USERNAME='" & Trim(Txt_Username.Text) & "'"
                    gconnection.getCompanyinfo(SQLSTRING, "USERUPDATE1")
                End If
                Dim Objwelcome As New Welcome
                Me.Hide()
                Objwelcome.Show()
            Else
                MessageBox.Show("Invalid Username Or Password !!! Contact System Admin", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Label5.Visible = True
                Me.Txt_Password.Text = ""
                Me.Txt_Password.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Create Table UserAdmin In Master database", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Cancel.Click
        Txt_Username.Text = ""
        Txt_Password.Text = ""
        Label5.Visible = False
        ErrorProvider1.Dispose()
        Txt_Username.Focus()
    End Sub

    Private Sub Cmd_Turnoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Turnoff.Click
        Me.Close()
    End Sub
    Public Sub GetServer()
        Dim ServerConn As New OleDb.OleDbConnection
        Dim servercmd As New OleDb.OleDbDataAdapter
        Dim getserver As New DataSet
        Dim sql, ssql As String
        Try
            sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
            sql = sql & AppPath & "\DBS_KEY.MDB"
            ServerConn.ConnectionString = sql
            ServerConn.Open()
            ssql = "SELECT SERVER,username,password,database,pdf FROM DBSKEY"
            servercmd = New OleDb.OleDbDataAdapter(ssql, ServerConn)
            servercmd.Fill(getserver)
            If getserver.Tables(0).Rows.Count > 0 Then
                gserver = Trim(getserver.Tables(0).Rows(0).Item(0) & "")
                ggusername = Trim(getserver.Tables(0).Rows(0).Item(1) & "")
                ggpassword = Trim(getserver.Tables(0).Rows(0).Item(2) & "")
                gpdf = (Trim(getserver.Tables(0).Rows(0).Item(4) & ""))
                'ggproductkey = abcdMINUS(Trim(getserver.Tables(0).Rows(0).Item(3) & ""))
                gDatabase = Trim(getserver.Tables(0).Rows(0).Item(3) & "")
                If Trim(gDatabase) <> "" Then
                    ShowCompany = False
                Else
                    ShowCompany = True
                End If
                         End If
        Catch ex As Exception
            MessageBox.Show("Failed To Connect Server", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            ServerConn.Close()
        End Try
    End Sub
    Public Sub GetEXCELPATH()
        Dim ExcelConn As New OleDb.OleDbConnection
        Dim Excelcmd As New OleDb.OleDbDataAdapter
        Dim getexcel As New DataSet
        Dim sql, ssql As String
        Try
            sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
            sql = sql & AppPath & "\DBS_KEY.MDB"
            ExcelConn.ConnectionString = sql
            ExcelConn.Open()
            ssql = "SELECT PATH FROM EXCELPATH"
            Excelcmd = New OleDb.OleDbDataAdapter(ssql, ExcelConn)
            Excelcmd.Fill(getexcel)
            If getexcel.Tables(0).Rows.Count > 0 Then
                '  Photogen = Trim(getexcel.Tables(0).Rows(0).Item(0) & "")
                strexcelpath = Trim(getexcel.Tables(0).Rows(0).Item(0) & "")
            Else
                strexcelpath = Environment.SystemDirectory & "\Excel.exe"
            End If
        Catch ex As Exception
            MessageBox.Show("Failed To Find Microsoft Excel Path", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            ExcelConn.Close()
        End Try
    End Sub
    Public Sub GetPrinter()
        Dim PrinterConn As New OleDb.OleDbConnection
        Dim Printercmd As New OleDb.OleDbDataAdapter
        Dim GetPrinter As New DataSet
        Dim sql, ssql As String
        Try
            sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
            sql = sql & AppPath & "\DBS_KEY.MDB"
            PrinterConn.ConnectionString = sql
            PrinterConn.Open()
            ssql = "SELECT COMPUTERNAME ,PRINTERNAME FROM PrinterSetup"
            Printercmd = New OleDb.OleDbDataAdapter(ssql, PrinterConn)
            Printercmd.Fill(GetPrinter)
            If GetPrinter.Tables(0).Rows.Count > 0 Then
                computername = Trim(GetPrinter.Tables(0).Rows(0).Item(0) & "")
                Printername = Trim(GetPrinter.Tables(0).Rows(0).Item(1) & "")
            Else
                computername = ""
                Printername = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Failed To Connect To Computer Printer", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            PrinterConn.Close()
        End Try
    End Sub

    Private Sub Cbo_Usertype_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cbo_Usertype.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt_Username.Focus()
        End If
    End Sub

    Private Sub CHK_CHANGEPWD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_CHANGEPWD.CheckedChanged
        If CHK_CHANGEPWD.Checked = True Then
            Label9.Visible = True
            TXT_NEWPASSWORD.Visible = True
            TXT_NEWPASSWORD.Focus()
        Else
            Label9.Visible = False
            TXT_NEWPASSWORD.Visible = False
            Txt_Password.Focus()
        End If
    End Sub

    Public Sub GeTPHOTO()
        Dim PhotoConn As New OleDb.OleDbConnection
        Dim Photocmd As New OleDb.OleDbDataAdapter
        Dim getphoto As New DataSet
        Dim sql, ssql As String
        Try
            sql = "Provider=Microsoft.Jet.OLEDB.4.0;Data source="
            sql = sql & AppPath & "\DBS_KEY.MDB"
            PhotoConn.ConnectionString = sql
            PhotoConn.Open()
            ssql = "SELECT PATH1 FROM photo"
            Photocmd = New OleDb.OleDbDataAdapter(ssql, PhotoConn)
            Photocmd.Fill(getphoto)
            If getphoto.Tables(0).Rows.Count > 0 Then
            Else
            End If
        Catch ex As Exception
            MessageBox.Show("Failed To Find Microsoft Excel Path", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            PhotoConn.Close()
        End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
