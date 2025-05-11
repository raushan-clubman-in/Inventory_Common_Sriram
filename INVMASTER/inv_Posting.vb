Public Class inv_Posting
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
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BTN_REVERSE As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtp_FROMdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_TOdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_KOTdate As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cmd_UPDATE As System.Windows.Forms.Button
    Friend WithEvents Cmb_storecode As System.Windows.Forms.ComboBox
    Friend WithEvents TXT_VALUE As System.Windows.Forms.TextBox
    Friend WithEvents cmd_clear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(inv_Posting))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.BTN_REVERSE = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtp_FROMdate = New System.Windows.Forms.DateTimePicker()
        Me.dtp_TOdate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_KOTdate = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmd_clear = New System.Windows.Forms.Button()
        Me.Cmb_storecode = New System.Windows.Forms.ComboBox()
        Me.Cmd_UPDATE = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.TXT_VALUE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.ssgrid)
        Me.GroupBox1.Location = New System.Drawing.Point(103, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(732, 499)
        Me.GroupBox1.TabIndex = 375
        Me.GroupBox1.TabStop = False
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(10, 12)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(709, 468)
        Me.ssgrid.TabIndex = 370
        '
        'BTN_REVERSE
        '
        Me.BTN_REVERSE.BackColor = System.Drawing.Color.Transparent
        Me.BTN_REVERSE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_REVERSE.ForeColor = System.Drawing.Color.Black
        Me.BTN_REVERSE.Location = New System.Drawing.Point(437, 1)
        Me.BTN_REVERSE.Name = "BTN_REVERSE"
        Me.BTN_REVERSE.Size = New System.Drawing.Size(130, 50)
        Me.BTN_REVERSE.TabIndex = 9
        Me.BTN_REVERSE.Text = "   REVERSE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CONSUMPTION"
        Me.BTN_REVERSE.UseVisualStyleBackColor = False
        Me.BTN_REVERSE.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(216, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(488, 23)
        Me.Label4.TabIndex = 507
        Me.Label4.Text = "INVENTORY CONSUMPTION POSTING "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtp_FROMdate)
        Me.GroupBox3.Controls.Add(Me.dtp_TOdate)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.lbl_KOTdate)
        Me.GroupBox3.Location = New System.Drawing.Point(185, 597)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(572, 46)
        Me.GroupBox3.TabIndex = 506
        Me.GroupBox3.TabStop = False
        '
        'dtp_FROMdate
        '
        Me.dtp_FROMdate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_FROMdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_FROMdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_FROMdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_FROMdate.Location = New System.Drawing.Point(150, 11)
        Me.dtp_FROMdate.Name = "dtp_FROMdate"
        Me.dtp_FROMdate.Size = New System.Drawing.Size(99, 26)
        Me.dtp_FROMdate.TabIndex = 5
        '
        'dtp_TOdate
        '
        Me.dtp_TOdate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_TOdate.CustomFormat = "dd/MM/yyyy"
        Me.dtp_TOdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_TOdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_TOdate.Location = New System.Drawing.Point(426, 11)
        Me.dtp_TOdate.Name = "dtp_TOdate"
        Me.dtp_TOdate.Size = New System.Drawing.Size(99, 26)
        Me.dtp_TOdate.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(306, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 16)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "TO DATE :"
        '
        'lbl_KOTdate
        '
        Me.lbl_KOTdate.AutoSize = True
        Me.lbl_KOTdate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_KOTdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_KOTdate.Location = New System.Drawing.Point(6, 17)
        Me.lbl_KOTdate.Name = "lbl_KOTdate"
        Me.lbl_KOTdate.Size = New System.Drawing.Size(93, 16)
        Me.lbl_KOTdate.TabIndex = 41
        Me.lbl_KOTdate.Text = "FROM DATE :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmd_clear)
        Me.Panel1.Controls.Add(Me.Cmb_storecode)
        Me.Panel1.Controls.Add(Me.BTN_REVERSE)
        Me.Panel1.Controls.Add(Me.Cmd_UPDATE)
        Me.Panel1.Controls.Add(Me.cmd_exit)
        Me.Panel1.Location = New System.Drawing.Point(185, 649)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(572, 56)
        Me.Panel1.TabIndex = 505
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 15)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "STORE"
        '
        'cmd_clear
        '
        Me.cmd_clear.BackColor = System.Drawing.Color.Transparent
        Me.cmd_clear.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_clear.ForeColor = System.Drawing.Color.Black
        Me.cmd_clear.Location = New System.Drawing.Point(227, 10)
        Me.cmd_clear.Name = "cmd_clear"
        Me.cmd_clear.Size = New System.Drawing.Size(91, 32)
        Me.cmd_clear.TabIndex = 11
        Me.cmd_clear.Text = "CLEAR"
        Me.cmd_clear.UseVisualStyleBackColor = False
        '
        'Cmb_storecode
        '
        Me.Cmb_storecode.FormattingEnabled = True
        Me.Cmb_storecode.Location = New System.Drawing.Point(1, 21)
        Me.Cmb_storecode.Name = "Cmb_storecode"
        Me.Cmb_storecode.Size = New System.Drawing.Size(106, 21)
        Me.Cmb_storecode.TabIndex = 10
        '
        'Cmd_UPDATE
        '
        Me.Cmd_UPDATE.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_UPDATE.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_UPDATE.ForeColor = System.Drawing.Color.Black
        Me.Cmd_UPDATE.Location = New System.Drawing.Point(117, 10)
        Me.Cmd_UPDATE.Name = "Cmd_UPDATE"
        Me.Cmd_UPDATE.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_UPDATE.TabIndex = 8
        Me.Cmd_UPDATE.Text = "GET DETAILS"
        Me.Cmd_UPDATE.UseVisualStyleBackColor = False
        '
        'cmd_exit
        '
        Me.cmd_exit.BackColor = System.Drawing.Color.Transparent
        Me.cmd_exit.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_exit.ForeColor = System.Drawing.Color.Black
        Me.cmd_exit.Location = New System.Drawing.Point(327, 10)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(104, 32)
        Me.cmd_exit.TabIndex = 9
        Me.cmd_exit.Text = "EXIT"
        Me.cmd_exit.UseVisualStyleBackColor = False
        '
        'TXT_VALUE
        '
        Me.TXT_VALUE.Enabled = False
        Me.TXT_VALUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_VALUE.Location = New System.Drawing.Point(721, 571)
        Me.TXT_VALUE.Name = "TXT_VALUE"
        Me.TXT_VALUE.Size = New System.Drawing.Size(100, 20)
        Me.TXT_VALUE.TabIndex = 508
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(628, 574)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 509
        Me.Label1.Text = "Total Value"
        '
        'inv_Posting
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.CadetBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1020, 733)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXT_VALUE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "inv_Posting"
        Me.Text = "AccountsTagging"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public tabname As String
    Public CodeField As String
    Public Codedesc As String
    Public Codeorderfield As String
    Public header As String
    Public colname1 As String
    Public colname2 As String
    Dim gconnection As New GlobalClass
    Dim Costcenter As Boolean

    Dim colledger As Integer
    Dim col As Integer
    Dim costCent As Integer

    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 780
        K = 1044
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
                        ElseIf Controls(i_i).Name = "grp_orderby" Then
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
                        ElseIf Controls(i_i).Name = "GroupBox1" Then
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










    Private Sub Cmd_UPDATE_Click(sender As Object, e As EventArgs) Handles Cmd_UPDATE.Click
        Dim sqlstring As String
        Me.Cursor = Cursors.WaitCursor

        If Mid(UCase(gShortname), 1, 3) = "HGA" Then
            If Mid(UCase(Cmd_UPDATE.Text), 1, 1) = "G" Then
                ssgrid.ClearRange(1, 1, -1, -1, True)

                Call NewAccountPostingDATEWISE_CON(Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy"), Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy"))
                sqlstring = "select TRNDATE,'C-'+TRNNO as docdetails,itemcode,isnull(rate,0) as rate,isnull(qty*-1,0) as qty,isnull(openningvalue-closingvalue,0) as amount from CLOSINGQTY where 'C-'+TRNNO in (select voucherno from INV_JV4 ) AND STORECODE='" & Cmb_storecode.Text & "' order by TRNDATE,TRNNO,itemcode"
                gconnection.getDataSet(sqlstring, "INV_JV4")

                ssgrid.MaxRows = gdataset.Tables("INV_JV4").Rows.Count

                If gdataset.Tables("INV_JV4").Rows.Count > 0 Then
                    Dim I As Integer
                    Dim TOT As Double
                    TOT = 0
                    For I = 0 To gdataset.Tables("INV_JV4").Rows.Count - 1
                        With ssgrid
                            .Row = I + 1
                            .Col = 1
                            .Text = Format(CDate(Trim(gdataset.Tables("INV_JV4").Rows(I).Item("TRNDATE"))), "dd/MM/yy").ToString()

                            .Col = 2
                            .Text = gdataset.Tables("INV_JV4").Rows(I).Item("docdetails")

                            .Col = 3
                            .Text = gdataset.Tables("INV_JV4").Rows(I).Item("itemcode")

                            .Col = 4
                            .Text = gdataset.Tables("INV_JV4").Rows(I).Item("rate")

                            .Col = 5
                            .Text = gdataset.Tables("INV_JV4").Rows(I).Item("qty")

                            .Col = 6
                            .Text = gdataset.Tables("INV_JV4").Rows(I).Item("amount")
                            TOT = TOT + .Text
                        End With

                    Next


                    TXT_VALUE.Text = Format(TOT, "0.00")
                    dtp_FROMdate.Enabled = False
                    dtp_TOdate.Enabled = False
                    Cmb_storecode.Enabled = False
                    Cmd_UPDATE.Text = "POST"
                    Me.Cursor = Cursors.Default

                Else
                    sqlstring = "SELECT VoucherNo FROM JOURNALENTRY WHERE ISNULL(VOID,'N')<>'Y' AND VOUCHERNO IN (SELECT 'C-'+TRNNO FROM CLOSINGQTY WHERE TRNDATE BETWEEN '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "' and STORECODE='" & Cmb_storecode.Text & "') "
                    gconnection.getDataSet(sqlstring, "POSTED")
                    If gdataset.Tables("POSTED").Rows.Count > 0 Then
                        MsgBox("Data Already Posted between " & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & " and " & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy"), MsgBoxStyle.Information, gCompanyname)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Else
                        MsgBox("No Any Consumption data,Kindly Do Manual Sub Store Consumption Once", MsgBoxStyle.Information, gCompanyname)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                Exit Sub
            End If


            If Mid(UCase(Cmd_UPDATE.Text), 1, 1) = "P" Then

                sqlstring = " DELETE FROM journalentry WHERE VoucherNO+VoucherType IN ( SELECT VoucherNO+VoucherType FROM INV_JV4 )"
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = "INSERT INTO journalentry (VOUCHERNO,VOUCHERDATE,VOUCHERCATEGORY,vouchertype,CASHBANK,	ACCOUNTCODE,AccountcodeDesc,SLCODE,	SLDESC,COSTCENTERCODE,COSTCENTERDESC,CREDITDEBIT,AMOUNT,VOID,DESCRIPTION,add_user,adduserid,adddatetime,add_date) "
                sqlstring = sqlstring & " SELECT DISTINCT VOUCHERNO,VOUCHERDATE,VOUCHERCATEGORY,vouchertype,CASHBANK,	J.ACCOUNTCODE,ACCOUNTDESC,SLCODE,	SLDESC,J.COSTCENTERCODE,COSTCENTERDESC,CREDITDEBIT,J.AMOUNT,'N',DESCRIPTION,'" + gUsername + "','" + gUsername + "',getDate(),getDate() FROM INV_JV4 J INNER JOIN INV_JV I ON  I.DOCNO=J.VOUCHERNO AND I.STORECODE='" & Cmb_storecode.Text & "' "
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = " DELETE FROM journalentry WHERE vouchertype in ('CONSUMPTION') AND ISNULL(ACCOUNTCODE,'')='' "
                gconnection.ExcuteStoreProcedure(sqlstring)

                MsgBox("Consumption Account Posting Completed....")
                Cmd_UPDATE.Text = "GET DETAILS"
                dtp_FROMdate.Enabled = True
                dtp_TOdate.Enabled = True
                Cmb_storecode.Enabled = True
                Me.Cursor = Cursors.Default
                ssgrid.ClearRange(1, 1, -1, -1, True)
                TXT_VALUE.Text = ""
                Exit Sub

            End If



        ElseIf Mid(UCase(gShortname), 1, 3) = "CCL" Then


            If Mid(UCase(Cmd_UPDATE.Text), 1, 1) = "G" Then
                ssgrid.ClearRange(1, 1, -1, -1, True)
                Call NewAccountPostingDATEWISE_CCL(Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy"), Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy"))
                sqlstring = "select docdate,docdetails,itemcode,isnull(rate,0) as rate,isnull(qty,0) as qty,isnull(amount,0) as amount from SUBSTORECONSUMPTIONDETAIL where Docdetails in (select voucherno from INV_JV4 ) AND Storelocationcode='" & Cmb_storecode.Text & "' order by docdate,Docdetails,itemcode"
                gconnection.getDataSet(sqlstring, "INV_JV4")

                ssgrid.MaxRows = gdataset.Tables("INV_JV4").Rows.Count

                If gdataset.Tables("INV_JV4").Rows.Count > 0 Then
                    Dim I As Integer
                    Dim TOT As Double
                    TOT = 0
                    For I = 0 To gdataset.Tables("INV_JV4").Rows.Count - 1
                        With ssgrid
                            .Row = I + 1
                            .Col = 1
                            .Text = Format(CDate(Trim(gdataset.Tables("INV_JV4").Rows(I).Item("docdate"))), "dd/MM/yy").ToString()

                            .Col = 2
                            .Text = gdataset.Tables("INV_JV4").Rows(I).Item("docdetails")

                            .Col = 3
                            .Text = gdataset.Tables("INV_JV4").Rows(I).Item("itemcode")

                            .Col = 4
                            .Text = gdataset.Tables("INV_JV4").Rows(I).Item("rate")

                            .Col = 5
                            .Text = gdataset.Tables("INV_JV4").Rows(I).Item("qty")

                            .Col = 6
                            .Text = gdataset.Tables("INV_JV4").Rows(I).Item("amount")
                            TOT = TOT + .Text
                        End With

                    Next


                    TXT_VALUE.Text = Format(TOT, "0.00")
                    dtp_FROMdate.Enabled = False
                    dtp_TOdate.Enabled = False
                    Cmb_storecode.Enabled = False
                    Cmd_UPDATE.Text = "POST"
                    Me.Cursor = Cursors.Default

                Else
                    sqlstring = "SELECT VoucherNo FROM JOURNALENTRY WHERE ISNULL(VOID,'N')<>'Y' AND VOUCHERNO IN (SELECT DOCDETAILS FROM SUBSTORECONSUMPTIONDETAIL WHERE DOCDATE BETWEEN '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "' and Storelocationcode='" & Cmb_storecode.Text & "')"
                    gconnection.getDataSet(sqlstring, "POSTED")
                    If gdataset.Tables("POSTED").Rows.Count > 0 Then
                        MsgBox("Data Already Posted between " & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & " and " & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy"), MsgBoxStyle.Information, gCompanyname)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    Else
                        MsgBox("No Any Consumption data,Kindly Do Manual Sub Store Consumption Once", MsgBoxStyle.Information, gCompanyname)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                Exit Sub
            End If


            If Mid(UCase(Cmd_UPDATE.Text), 1, 1) = "P" Then

                sqlstring = " DELETE FROM journalentry WHERE VoucherNO+VoucherType IN ( SELECT VoucherNO+VoucherType FROM INV_JV4 )"
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = "INSERT INTO journalentry (VOUCHERNO,VOUCHERDATE,VOUCHERCATEGORY,vouchertype,CASHBANK,	ACCOUNTCODE,AccountcodeDesc,SLCODE,	SLDESC,COSTCENTERCODE,COSTCENTERDESC,CREDITDEBIT,AMOUNT,VOID,DESCRIPTION,add_user,adduserid,adddatetime,add_date) "
                sqlstring = sqlstring & " SELECT DISTINCT VOUCHERNO,VOUCHERDATE,VOUCHERCATEGORY,vouchertype,CASHBANK,	J.ACCOUNTCODE,ACCOUNTDESC,SLCODE,	SLDESC,J.COSTCENTERCODE,COSTCENTERDESC,CREDITDEBIT,J.AMOUNT,'N',DESCRIPTION,'" + gUsername + "','" + gUsername + "',getDate(),getDate() FROM INV_JV4 J INNER JOIN INV_JV I ON  I.DOCNO=J.VOUCHERNO AND I.STORECODE='" & Cmb_storecode.Text & "'-- AND CREDITDEBIT='DEBIT'"
                gconnection.ExcuteStoreProcedure(sqlstring)

                sqlstring = " DELETE FROM journalentry WHERE vouchertype in ('CONSUMPTION') AND ISNULL(ACCOUNTCODE,'')='' "
                gconnection.ExcuteStoreProcedure(sqlstring)

                MsgBox("Consumption Account Posting Completed....")
                Cmd_UPDATE.Text = "GET DETAILS"
                dtp_FROMdate.Enabled = True
                dtp_TOdate.Enabled = True
                Cmb_storecode.Enabled = True
                Me.Cursor = Cursors.Default
                ssgrid.ClearRange(1, 1, -1, -1, True)
                TXT_VALUE.Text = ""
                Exit Sub

            End If


        End If


       



    End Sub

    Private Sub cmd_exit_Click(sender As Object, e As EventArgs) Handles cmd_exit.Click
        Me.Close()
    End Sub

    Private Sub BTN_REVERSE_Click(sender As Object, e As EventArgs) Handles BTN_REVERSE.Click
        Dim SQLSTRING As String

        If Mid(UCase(gShortname), 1, 3) = "HGA" Then
            SQLSTRING = "SELECT * FROM journalentry WHERE ISNULL(VOID,'N')<>'Y' AND vouchercategory ='CONSUMPTION' AND   VoucherNo in  (select 'C-'+docdetails from SUBSTORECONSUMPTIONDETAIL where cast(docdate as date) BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "' AND Storelocationcode='" & Cmb_storecode.Text & "' ) AND cast(voucherdate as date)  BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "'"
            gconnection.getDataSet(SQLSTRING, "POSTED")
            If gdataset.Tables("POSTED").Rows.Count > 0 Then
                SQLSTRING = "delete from  journalentry WHERE vouchercategory ='CONSUMPTION' AND VoucherNo in "
                SQLSTRING = SQLSTRING & " (select 'C-'+docdetails from SUBSTORECONSUMPTIONDETAIL where cast(docdate as date) BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "' AND Storelocationcode='" & Cmb_storecode.Text & "' ) AND  cast(voucherdate as date)  BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SQLSTRING)

                SQLSTRING = "delete from  journalentry WHERE vouchercategory ='CONSUMPTION' AND VoucherNo in "
                SQLSTRING = SQLSTRING & " (select 'C-'+KOTDETAILS  FROM KOT_DET K INNER JOIN POSITEMSTORELINK L ON K.POSCODE=L.POS AND K.ITEMCODE=L.ITEMCODE   WHERE ISNULL(KOTSTATUS,'N')<>'N' AND ISNULL(DELFLAG,'')='Y' AND L.STORECODE='" & Cmb_storecode.Text & "')"
                gconnection.ExcuteStoreProcedure(SQLSTRING)

                MsgBox("Consumption Posting Revresed in date between" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & " AND " & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy"), MsgBoxStyle.OkOnly, gCompanyname)
                ssgrid.ClearRange(1, 1, -1, -1, True)
            Else
                MsgBox("No Any Data Posted In between selected dates")
                Exit Sub
            End If

        ElseIf Mid(UCase(gShortname), 1, 3) = "CCL" Then
            SQLSTRING = "SELECT * FROM journalentry WHERE ISNULL(VOID,'N')<>'Y' AND vouchercategory ='CONSUMPTION' AND   VoucherNo in  (select docdetails from SUBSTORECONSUMPTIONDETAIL where cast(docdate as date) BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "' ) AND cast(voucherdate as date)  BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "'"
            gconnection.getDataSet(SQLSTRING, "POSTED")
            If gdataset.Tables("POSTED").Rows.Count > 0 Then
                SQLSTRING = "delete from  journalentry WHERE vouchercategory ='CONSUMPTION' AND VoucherNo in "
                SQLSTRING = SQLSTRING & " (select docdetails from SUBSTORECONSUMPTIONDETAIL where cast(docdate as date) BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "' ) AND  cast(voucherdate as date)  BETWEEN  '" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & "' AND '" & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy") & "'"
                gconnection.ExcuteStoreProcedure(SQLSTRING)
                MsgBox("Consumption Posting Revresed in date between" & Format(CDate(dtp_FROMdate.Value), "dd/MMM/yyyy") & " AND " & Format(CDate(dtp_TOdate.Value), "dd/MMM/yyyy"), MsgBoxStyle.OkOnly, gCompanyname)
                ssgrid.ClearRange(1, 1, -1, -1, True)
            Else
                MsgBox("No Any Data Posted In between selected dates")
                Exit Sub
            End If
        End If


     
    End Sub

    Private Sub inv_Posting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call loadstore()
        Cmb_storecode.SelectedIndex = 0
        gSQLString = "update SUBSTORECONSUMPTIONDETAIL set rate=A.rate,AMOUNT= SUBSTORECONSUMPTIONDETAIL.QTY*a.rate from SUBSTORECONSUMPTIONDETAIL , closingqty A"

        gSQLString = gSQLString & "   WHERE    A.Trnno = SUBSTORECONSUMPTIONDETAIL.Docdetails And A.ITEMCODE = SUBSTORECONSUMPTIONDETAIL.Itemcode"
        gconnection.ExcuteStoreProcedure(gSQLString)

        BTN_REVERSE.Visible = True
        ssgrid.ClearRange(1, 1, -1, -1, True)



    End Sub
    Sub loadstore()
        Dim sqlstring As String
        Dim dt As DataTable
        sqlstring = "select distinct Storelocationcode from SUBSTORECONSUMPTIONDETAIL   ORDER BY Storelocationcode"
        dt = gconnection.GetValues(sqlstring)
        Dim Itration
        For Itration = 0 To (dt.Rows.Count - 1)
            Cmb_storecode.Items.Add(dt.Rows(Itration).Item("Storelocationcode"))
        Next

    End Sub

    Private Sub cmd_clear_Click(sender As Object, e As EventArgs) Handles cmd_clear.Click
        Cmd_UPDATE.Text = "GET DETAILS"
        dtp_FROMdate.Enabled = True
        dtp_TOdate.Enabled = True
        Cmb_storecode.Enabled = True
        Me.Cursor = Cursors.Default
        ssgrid.ClearRange(1, 1, -1, -1, True)
        TXT_VALUE.Text = ""
        Cmb_storecode.SelectedIndex = 0
    End Sub
End Class
