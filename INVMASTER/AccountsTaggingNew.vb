Public Class AccountsTaggingNew
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
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmdsave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsTaggingNew))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdsave = New System.Windows.Forms.Button()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(318, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(752, 54)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.cmdexit)
        Me.GroupBox2.Controls.Add(Me.cmdsave)
        Me.GroupBox2.Location = New System.Drawing.Point(1271, 231)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(224, 163)
        Me.GroupBox2.TabIndex = 376
        Me.GroupBox2.TabStop = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdexit.BackgroundImage = CType(resources.GetObject("cmdexit.BackgroundImage"), System.Drawing.Image)
        Me.cmdexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.Location = New System.Drawing.Point(14, 86)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(199, 67)
        Me.cmdexit.TabIndex = 1
        Me.cmdexit.Text = "Exit[F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdsave
        '
        Me.cmdsave.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdsave.BackgroundImage = CType(resources.GetObject("cmdsave.BackgroundImage"), System.Drawing.Image)
        Me.cmdsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdsave.FlatAppearance.BorderSize = 0
        Me.cmdsave.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.cmdsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdsave.Location = New System.Drawing.Point(13, 15)
        Me.cmdsave.Name = "cmdsave"
        Me.cmdsave.Size = New System.Drawing.Size(198, 67)
        Me.cmdsave.TabIndex = 0
        Me.cmdsave.Text = "ADD[F7]"
        Me.cmdsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdsave.UseVisualStyleBackColor = False
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(35, 123)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(1190, 595)
        Me.ssgrid.TabIndex = 370
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1280, 432)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(183, 28)
        Me.Label4.TabIndex = 377
        Me.Label4.Text = "Press F3 For Reset"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1280, 480)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(194, 28)
        Me.Label5.TabIndex = 378
        Me.Label5.Text = "Press F8 For Search"
        '
        'AccountsTaggingNew
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 19)
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1507, 747)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ssgrid)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "AccountsTaggingNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AccountsTagging"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
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

    Private Sub AccountsTaggingNew_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F7) And cmdsave.Visible = True Then
            cmdsave_Click(sender, e)
        End If
        If (e.KeyCode = Keys.F11) Then
            cmdexit_Click(sender, e)
        End If
    End Sub

    Private Sub AccountsTaggingNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.DoubleBuffered = True
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.cmdexit.Visible = True
                'Me.cmd_exit.Visible = True
            End If
        End If
        'Call Resize_Form()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'GroupBox1.Controls.Add(ssgrid)
        'ssgrid.Location = New Point(10, 10)
        'ssgrid.Width = GroupBox1.Width - 10

        Label1.Text = header
        bindssgrid()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Dim sql As String = "Select count(*) as cn from Accountssetup where isnull(costcenter,'')<>'N'"
        gconnection.getDataSet(sql, "Accountssetup")
        If gdataset.Tables("Accountssetup").Rows(0).Item("cn") = 1 Then
            Costcenter = True
            '  lockssgrid()
        Else
            Costcenter = False

        End If

        bindcodefield()
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        GmoduleName = "Accounts Tagging"
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.cmdsave.Enabled = False
        'Me.Cmd_Freeze.Enabled = False
        'Me.Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmdsave.Enabled = True
                    'Me.Cmd_Freeze.Enabled = True
                    'Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.cmdsave.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.cmdsave.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.cmdsave.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    '   Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    '    Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    ' Me.cmd_auth.Enabled = True
                End If
            Next
        End If
    End Sub


    Sub bindssgrid()

        With ssgrid


            ' ----Store-----
            .Row = 0
            .Col = 1
            .Text = "STORE CODE"

            .Row = 0
            .Col = 2
            .Text = "STORE DESCRIPTION"

            .Row = 0
            .Col = 3
            .Text = " GL ACCOUNT CODE FOR STOCK"

            .Row = 0
            .Col = 4
            .Text = "DESCRIPTION"

            .Row = 0
            .Col = 5
            .Text = "SL CODE FOR STOCK"


            .Row = 0
            .Col = 6
            .Text = "DESCRIPTION"

            .Row = 0
            .Col = 7
            .Text = "COST CENTER CODE"


            .Row = 0
            .Col = 8
            .Text = "COST CENTER DESC"

            '------------Consumption-------------------------------
            .Row = 0
            .Col = 9
            .Text = "GL CODE FOR CONSUMPTION"

            .Row = 0
            .Col = 10
            .Text = "DESCRIPTION"

            .Row = 0
            .Col = 11
            .Text = "SL CODE FOR CONSUMPTION"


            .Row = 0
            .Col = 12
            .Text = "DESCRIPTION"


            .Row = 0
            .Col = 13
            .Text = "COST CENTER CODE FOR CONSUMPTION"

            .Row = 0
            .Col = 14
            .Text = "COST CENTER DESCRIPTION"


            '----------------ADJUSTMENT-----------------------
            '.Row = 0
            '.Col = 13
            '.Text = "TAX A/C CODE"

            '.Row = 0
            '.Col = 14
            '.Text = "TAX A/C DESCRIPTION"

            .Row = 0
            .Col = 15
            .Text = "GL CODE FOR ADJUSTMENT"

            .Row = 0
            .Col = 16
            .Text = "DESCRIPTION"


            .Row = 0
            .Col = 17
            .Text = "SL CODE FOR ADJUSTMENT "


            .Row = 0
            .Col = 18
            .Text = "DESCRIPTION"

            .Row = 0
            .Col = 19
            .Text = "COST CENTER CODE FOR ADJUSTMENT"

            .Row = 0
            .Col = 20
            .Text = "COST CENTER DESCRIPTION"


            '-------------------Damage-----------------------
            '.Row = 0
            '.Col = 19
            '.Text = "DAMAGE A/C CODE"

            '.Row = 0
            '.Col = 20
            '.Text = "DAMAGE A/C DESCRIPTION"


            .Row = 0
            .Col = 21
            .Text = "GL CODE FOR DAMAGE"

            .Row = 0
            .Col = 22
            .Text = "DESCRIPTION"


            .Row = 0
            .Col = 23
            .Text = "SL CODE FOR DAMAGE"


            .Row = 0
            .Col = 24
            .Text = "DESCRIPTION"


            .Row = 0
            .Col = 25
            .Text = "COST CENTER CODE FOR DAMAGE"

            .Row = 0
            .Col = 26
            .Text = "COST CENTER DESCRIPTION"


        End With

    End Sub

    ' code for column 3 AND 7 
    Sub bindaccode()







        If col = 3 Then


            If ssgrid.Text = "" Then
                gSQLString = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster"
                If UCase(gShortname) = "RCL" Or UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 3) = "DCL" Or Mid(UCase(Trim(gShortname)), 1, 3) = "BRC" Or Mid(UCase(Trim(gShortname)), 1, 3) = "CCF" Or Mid(UCase(Trim(gShortname)), 1, 3) = "NIZ" Or Mid(UCase(Trim(gShortname)), 1, 3) = "KEA" Or Mid(UCase(Trim(gShortname)), 1, 3) = "HG" Or Mid(UCase(Trim(gShortname)), 1, 3) = "MLA" Or Mid(UCase(Trim(gShortname)), 1, 3) = "BBS" Or Mid(UCase(Trim(gShortname)), 1, 3) = "EPC" Then
                    M_WhereCondition = " where isnull(freezeflag,'') <> 'Y' and category  in ('A','E') "
                Else
                    M_WhereCondition = " where isnull(freezeflag,'') <> 'Y' and category  in ('A','E') "
                End If

                ' M_WhereCondition = " where isnull(freezeflag,'') <> 'Y' and category  in ('A') "
                Dim vform As New ListOperattion1
                vform.Field = "Accode,Acdesc,subledgerflag,category"
                vform.vFormatstring = "ACCOUNT CODE | ACCOUNT DESCRIPTION             |SubLedger | Category  "
                vform.vCaption = "ACCOUNT CODE MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1
                vform.KeyPos2 = 2
                vform.Keypos3 = 3

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then
                    If vform.keyfield3 = "A" Or vform.keyfield3 = "L" Then
                        If MsgBox("You Are Using Asset and Liabilities Account..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname) = MsgBoxResult.No Then
                            'ssgrid.Col = 3

                            'ssgrid.Focus()
                            ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                            Exit Sub

                        Else

                            ssgrid.Col = 3
                            ssgrid.Text = vform.keyfield

                            ssgrid.Col = 4
                            ssgrid.Text = vform.keyfield1
                            If vform.keyfield2 = "Y" Then
                                ssgrid.Col = 5
                                ssgrid.Text = ""
                                ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                            Else
                                ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
                            End If
                        End If
                    ElseIf vform.keyfield3 = "I" Or vform.keyfield3 = "E" Then

                        ssgrid.Col = 3
                        ssgrid.Text = vform.keyfield

                        ssgrid.Col = 4
                        ssgrid.Text = vform.keyfield1


                        If vform.keyfield2 = "Y" Then
                            'ssgrid.Col = 5
                            'ssgrid.Text = ""
                            'ssgrid.Focus()
                            ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                        Else
                            ssgrid.SetActiveCell(7, ssgrid.ActiveRow)

                            ' Else
                            If Costcenter = True Then
                                ssgrid.Col = 7
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                ssgrid.SetActiveCell(7, ssgrid.ActiveRow)

                            Else
                                ssgrid.SetActiveCell(9, ssgrid.ActiveRow)

                                ssgrid.Col = 9
                                ssgrid.Focus()

                            End If
                        End If

                    End If

                End If

                vform.Close()
                vform = Nothing
            Else
                ssgrid.Col = 3
                gSQLString = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster "
                If UCase(gShortname) = "RCL" Or UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or UCase(gShortname) = "DCL" Or Mid(UCase(Trim(gShortname)), 1, 3) = "BRC" Or Mid(UCase(Trim(gShortname)), 1, 3) = "CCF" Or Mid(UCase(Trim(gShortname)), 1, 3) = "NIZ" Or Mid(UCase(Trim(gShortname)), 1, 3) = "KEA" Or Mid(UCase(Trim(gShortname)), 1, 3) = "HG" Or Mid(UCase(Trim(gShortname)), 1, 3) = "MLA" Or Mid(UCase(Trim(gShortname)), 1, 3) = "BBS" Or Mid(UCase(Trim(gShortname)), 1, 3) = "EPC" Then
                    gSQLString = gSQLString & " where Accode='" + ssgrid.Text + "' and isnull(freezeflag,'') <> 'Y' and category  in ('A','E')"
                Else
                    gSQLString = gSQLString & " where Accode='" + ssgrid.Text + "' and isnull(freezeflag,'') <> 'Y' and category  in ('A','E')"
                End If
                gconnection.getDataSet(gSQLString, "Accountsglaccountmaster")
                If (gdataset.Tables("Accountsglaccountmaster").Rows.Count > 0) Then


                    If Trim(gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc") & "") <> "" Then
                        If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "A" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "L" Then
                            If MsgBox("You Are Using Asset and Liabilities Account..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname) = MsgBoxResult.No Then
                                ssgrid.Col = 3

                                ssgrid.Focus()
                                ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                                Exit Sub

                            Else

                                ssgrid.Col = 4
                                ssgrid.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                                If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                                    ssgrid.Col = 5
                                    ssgrid.Text = ""
                                    ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                                Else
                                    ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
                                End If
                            End If
                        ElseIf gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "I" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "E" Then


                            ssgrid.Col = 4
                            ssgrid.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                            If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                                ssgrid.Col = 5
                                ssgrid.Text = ""

                            Else
                                ssgrid.SetActiveCell(7, ssgrid.ActiveRow)


                                If Costcenter = True Then
                                    ssgrid.Col = 7
                                    ssgrid.Text = ""
                                    ssgrid.Focus()
                                    ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
                                Else
                                    ssgrid.SetActiveCell(9, ssgrid.ActiveRow)

                                    ssgrid.Col = 9
                                    ssgrid.Focus()
                                End If

                            End If


                        End If

                    End If
                End If
                '            vform.Close()
                '           vform = Nothing
            End If



        ElseIf col = 9 Then
            If ssgrid.Text = "" Then
                gSQLString = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster"
                M_WhereCondition = " where isnull(freezeflag,'') <> 'Y' and category  in ('I','E')"
                Dim vform As New ListOperattion1
                vform.Field = "Accode,Acdesc,subledgerflag,category"
                vform.vFormatstring = "ACCOUNT CODE | ACCOUNT DESCRIPTION             |SubLedger | Category  "
                vform.vCaption = "ACCOUNT CODE MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1
                vform.KeyPos2 = 2
                vform.Keypos3 = 3

                vform.ShowDialog(Me)

                If Trim(vform.keyfield & "") <> "" Then
                    If vform.keyfield3 = "A" Or vform.keyfield3 = "L" Then
                        If MsgBox("You Are Using Asset and Liabilities Account..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname) = MsgBoxResult.No Then
                            'ssgrid.Col = 3

                            'ssgrid.Focus()
                            ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                            Exit Sub

                        Else

                            ssgrid.Col = 9
                            ssgrid.Text = vform.keyfield

                            ssgrid.Col = 10
                            ssgrid.Text = vform.keyfield1
                            If vform.keyfield2 = "Y" Then
                                ssgrid.Col = 11
                                ssgrid.Text = ""

                            End If
                        End If
                    ElseIf vform.keyfield3 = "I" Or vform.keyfield3 = "E" Then

                        ssgrid.Col = 9
                        ssgrid.Text = vform.keyfield

                        ssgrid.Col = 10
                        ssgrid.Text = vform.keyfield1


                        If vform.keyfield2 = "Y" Then
                            'ssgrid.Col = 5
                            'ssgrid.Text = ""
                            'ssgrid.Focus()
                            ssgrid.SetActiveCell(11, ssgrid.ActiveRow)
                        Else

                            If Costcenter = True Then
                                'ssgrid.Col = 11
                                'ssgrid.Text = ""
                                'ssgrid.Focus()
                                ssgrid.SetActiveCell(13, ssgrid.ActiveRow)


                            Else
                                ssgrid.SetActiveCell(15, ssgrid.ActiveRow)
                            End If
                            'ssgrid.Col = 3
                            'ssgrid.Focus()

                        End If


                    End If

                End If

                vform.Close()
                vform = Nothing
            Else
                ssgrid.Col = 9
                gSQLString = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster where Accode='" + ssgrid.Text + "' and isnull(freezeflag,'') <> 'Y' and category  in ('I','E')"
                gconnection.getDataSet(gSQLString, "Accountsglaccountmaster")
                If (gdataset.Tables("Accountsglaccountmaster").Rows.Count > 0) Then


                    If Trim(gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc") & "") <> "" Then
                        If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "A" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "L" Then
                            If MsgBox("You Are Using Asset and Liabilities Account..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname) = MsgBoxResult.No Then
                                ssgrid.Col = 9

                                ssgrid.Focus()
                                ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                                Exit Sub

                            Else

                                ssgrid.Col = 10
                                ssgrid.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                                If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                                    ssgrid.Col = 11
                                    ssgrid.Text = ""

                                End If
                            End If
                        ElseIf gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "I" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "E" Then


                            ssgrid.Col = 10
                            ssgrid.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                            If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                                ssgrid.Col = 11
                                ssgrid.Text = ""

                            Else
                                If Costcenter = True Then
                                    ssgrid.Col = 13
                                    ssgrid.Text = ""
                                    ssgrid.Focus()
                                    ssgrid.SetActiveCell(13, ssgrid.ActiveRow)
                                End If

                            End If


                        End If

                    End If
                End If
                '            vform.Close()
                '           vform = Nothing
            End If
        ElseIf col = 15 Then
            If ssgrid.Text = "" Then
                gSQLString = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster"
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 3) = "BRC" Or Mid(UCase(Trim(gShortname)), 1, 4) = "CCFC" Or Mid(UCase(Trim(gShortname)), 1, 3) = "NIZ" Or Mid(UCase(Trim(gShortname)), 1, 3) = "KEA" Or Mid(UCase(Trim(gShortname)), 1, 3) = "BBS" Or Mid(UCase(Trim(gShortname)), 1, 3) = "EPC" Then
                    M_WhereCondition = " where isnull(freezeflag,'') <> 'Y' and category  in ('L','E','A')"
                Else
                    M_WhereCondition = " where isnull(freezeflag,'') <> 'Y' and category  in ('L','E','A')"
                End If

                Dim vform As New ListOperattion1
                vform.Field = "Accode,Acdesc,subledgerflag,category"
                vform.vFormatstring = "ACCOUNT CODE | ACCOUNT DESCRIPTION             |SubLedger | Category  "
                vform.vCaption = "ACCOUNT CODE MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1
                vform.KeyPos2 = 2
                vform.Keypos3 = 3

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then
                    If vform.keyfield3 = "A" Or vform.keyfield3 = "L" Then
                        If MsgBox("You Are Using Asset and Liabilities Account..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname) = MsgBoxResult.No Then
                            'ssgrid.Col = 3

                            'ssgrid.Focus()
                            ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                            Exit Sub

                        Else

                            ssgrid.Col = 15
                            ssgrid.Text = vform.keyfield

                            ssgrid.Col = 16
                            ssgrid.Text = vform.keyfield1
                            If vform.keyfield2 = "Y" Then
                                ssgrid.Col = 17
                                'ssgrid.Text = ""

                                ssgrid.SetActiveCell(17, ssgrid.ActiveRow)
                            Else
                                ssgrid.SetActiveCell(19, ssgrid.ActiveRow)
                            End If

                        End If
                    ElseIf vform.keyfield3 = "I" Or vform.keyfield3 = "E" Then

                        ssgrid.Col = 15
                        ssgrid.Text = vform.keyfield

                        ssgrid.Col = 16
                        ssgrid.Text = vform.keyfield1


                        If vform.keyfield2 = "Y" Then
                            'ssgrid.Col = 5
                            'ssgrid.Text = ""
                            'ssgrid.Focus()
                            ssgrid.SetActiveCell(17, ssgrid.ActiveRow)
                        Else

                            'If Costcenter = True Then
                            '    'ssgrid.Col = 11
                            '    'ssgrid.Text = ""
                            '    'ssgrid.Focus()
                            ssgrid.SetActiveCell(21, ssgrid.ActiveRow)


                            'Else
                            '    ssgrid.SetActiveCell(3, ssgrid.ActiveRow + 1)
                            'End If
                            'ssgrid.Col = 3
                            'ssgrid.Focus()

                        End If


                    End If

                End If

                vform.Close()
                vform = Nothing
            Else
                ssgrid.Col = 15
                gSQLString = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster " ' where Accode='" + ssgrid.Text + "' and isnull(freezeflag,'') <> 'Y' and category  in ('L')"
                If UCase(gShortname) = "JIC" Or Mid(UCase(Trim(gCompanyname)), 1, 3) = "JUB" Or Mid(UCase(Trim(gShortname)), 1, 3) = "BRC" Or Mid(UCase(Trim(gShortname)), 1, 4) = "CCFC" Or Mid(UCase(Trim(gShortname)), 1, 3) = "NIZ" Or Mid(UCase(Trim(gShortname)), 1, 3) = "BBS" Or Mid(UCase(Trim(gShortname)), 1, 3) = "EPC" Then
                    gSQLString = gSQLString & " where Accode='" + ssgrid.Text + "' and isnull(freezeflag,'') <> 'Y' and category  in ('L','E','A')"
                Else
                    gSQLString = gSQLString & " where Accode='" + ssgrid.Text + "' and isnull(freezeflag,'') <> 'Y' and category  in ('L','E','A')"
                End If
                gconnection.getDataSet(gSQLString, "Accountsglaccountmaster")
                If (gdataset.Tables("Accountsglaccountmaster").Rows.Count > 0) Then


                    If Trim(gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc") & "") <> "" Then
                        If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "A" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "L" Then
                            If MsgBox("You Are Using Asset and Liabilities Account..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname) = MsgBoxResult.No Then
                                ssgrid.Col = 15

                                ssgrid.Focus()
                                ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                                Exit Sub

                            Else

                                ssgrid.Col = 16
                                ssgrid.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                                If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                                    ssgrid.Col = 17
                                    ssgrid.Text = ""

                                End If
                            End If
                        ElseIf gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "I" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "E" Then


                            ssgrid.Col = 17
                            ssgrid.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                            If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                                ssgrid.Col = 17
                                ssgrid.Text = ""

                            Else
                                'If Costcenter = True Then
                                '    ssgrid.Col = 17
                                '    ssgrid.Text = ""
                                '    ssgrid.Focus()
                                ssgrid.SetActiveCell(19, ssgrid.ActiveRow)
                                'End If

                            End If


                        End If

                    End If
                End If
                '            vform.Close()
                '           vform = Nothing
            End If
        ElseIf col = 21 Then
            If ssgrid.Text = "" Then
                gSQLString = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster"
                M_WhereCondition = " where isnull(freezeflag,'') <> 'Y' and category  in ('I','E')"
                Dim vform As New ListOperattion1
                vform.Field = "Accode,Acdesc,subledgerflag,category"
                vform.vFormatstring = "ACCOUNT CODE | ACCOUNT DESCRIPTION             |SubLedger | Category  "
                vform.vCaption = "ACCOUNT CODE MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1
                vform.KeyPos2 = 2
                vform.Keypos3 = 3

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then
                    If vform.keyfield3 = "A" Or vform.keyfield3 = "L" Then
                        If MsgBox("You Are Using Asset and Liabilities Account..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname) = MsgBoxResult.No Then
                            'ssgrid.Col = 3

                            'ssgrid.Focus()
                            ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                            Exit Sub

                        Else

                            ssgrid.Col = 21
                            ssgrid.Text = vform.keyfield

                            ssgrid.Col = 22
                            ssgrid.Text = vform.keyfield1
                            If vform.keyfield2 = "Y" Then
                                ssgrid.Col = 21
                                ssgrid.Text = ""

                            End If
                        End If
                    ElseIf vform.keyfield3 = "I" Or vform.keyfield3 = "E" Then

                        ssgrid.Col = 21
                        ssgrid.Text = vform.keyfield

                        ssgrid.Col = 22
                        ssgrid.Text = vform.keyfield1


                        If vform.keyfield2 = "Y" Then
                            'ssgrid.Col = 5
                            'ssgrid.Text = ""
                            'ssgrid.Focus()
                            ssgrid.SetActiveCell(23, ssgrid.ActiveRow)
                        Else
                            'ssgrid.SetActiveCell(25, ssgrid.ActiveRow)
                            If Costcenter = True Then
                                '    'ssgrid.Col = 11
                                '    'ssgrid.Text = ""
                                '    'ssgrid.Focus()
                                ssgrid.SetActiveCell(25, ssgrid.ActiveRow)


                            Else
                                ssgrid.SetActiveCell(3, ssgrid.ActiveRow + 1)
                            End If
                            'ssgrid.Col = 3
                            'ssgrid.Focus()

                        End If


                    End If

                End If

                vform.Close()
                vform = Nothing
            Else
                ssgrid.Col = 21
                gSQLString = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster where Accode='" + ssgrid.Text + "' and isnull(freezeflag,'') <> 'Y' and category  in ('I','E')"
                gconnection.getDataSet(gSQLString, "Accountsglaccountmaster")
                If (gdataset.Tables("Accountsglaccountmaster").Rows.Count > 0) Then


                    If Trim(gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc") & "") <> "" Then
                        If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "A" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "L" Then
                            If MsgBox("You Are Using Asset and Liabilities Account..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname) = MsgBoxResult.No Then
                                ssgrid.Col = 21

                                ssgrid.Focus()
                                ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                                Exit Sub

                            Else

                                ssgrid.Col = 22
                                ssgrid.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                                If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                                    ssgrid.Col = 23
                                    ssgrid.Text = ""

                                End If
                            End If
                        ElseIf gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "I" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "E" Then


                            ssgrid.Col = 22
                            ssgrid.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                            If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                                ssgrid.Col = 23
                                ssgrid.Text = ""

                            Else
                                'ssgrid.SetActiveCell(23, ssgrid.ActiveRow)
                                If Costcenter = True Then
                                    ssgrid.Col = 25
                                    ssgrid.Text = ""
                                    ssgrid.Focus()
                                    ssgrid.SetActiveCell(25, ssgrid.ActiveRow)
                                End If

                            End If


                        End If

                    End If
                End If
                '            vform.Close()
                '           vform = Nothing
            End If
        End If

    End Sub

    'bind code field of ssgrid
    Sub bindcodefield()
        Dim sql1 As String
        If gAcPostingWise = "ITEM" Then
            'ADJGLCODE  ADJGLDESC      ADJSLCODE     ADJSLDESC     ADJCCCODE  ADJCCDESC
            sql1 = "Select ITEMCode AS CODE,ITEMNAME AS description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,CONGLCODE,CONGLDESC,CONSLCODE,CONSLDESC,CONCCCODE,CONCCDESC,ADJGLCODE,ADJGLDESC,ADJSLCODE,ADJSLDESC,ADJCCCODE,ADJCCDESC,DAMGLCODE,DAMGLDESC,DAMSLCODE,DAMSLDESC,DAMCCCODE,DAMCCDESC from AccountstaggingForiTEM where tablename='" & tabname & "' UNION "
            sql1 = sql1 & " SELECT distinct " & CodeField & "," & Codedesc & ",'' AS accountcode,'' AS accountdesc,'' AS slcode,'' AS sldesc,'' AS costcentercode,'' AS costcenterdesc, '' AS CONGLCODE,'' AS CONGLDESC,'' AS CONSLCODE,'' AS CONSLDESC,'' AS CONCCCODE,'' AS CONCCDESC,'' AS ADJGLCODE,'' AS ADJGLDESC,'' AS ADJSLCODE,'' AS ADJSLDESC,'' AS ADJCCCODE,'' AS ADJCCDESC,'' AS DAMGLCODE,'' AS DAMGLDESC,'' AS DAMSLCODE,'' AS DAMSLDESC,'' AS DAMCCCODE,'' AS DAMCCDESC FROM " & tabname & " "
            sql1 = sql1 & " WHERE " & CodeField & " NOT IN (Select ITEMCode from AccountstaggingForiTEM where tablename='" & tabname & "') "
            ssgrid.SetText(1, 0, "ITEMCODE")
            ssgrid.SetText(2, 0, "ITEMNAME")

        ElseIf gAcPostingWise = "CATEGORY" Then
            sql1 = "Select CategoryCode AS Code,CategoryDesc AS description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,CONGLCODE,CONGLDESC,CONSLCODE,CONSLDESC,CONCCCODE,CONCCDESC,ADJGLCODE,ADJGLDESC,ADJSLCODE,ADJSLDESC,ADJCCCODE,ADJCCDESC,DAMGLCODE,DAMGLDESC,DAMSLCODE,DAMSLDESC,DAMCCCODE,DAMCCDESC from AccountstaggingForCategory where tablename='" & tabname & "' UNION "
            sql1 = sql1 & " SELECT distinct " & CodeField & "," & Codedesc & ",'' AS accountcode,'' AS accountdesc,'' AS slcode,'' AS sldesc,'' AS costcentercode,'' AS costcenterdesc, '' AS CONGLCODE,'' AS CONGLDESC,'' AS CONSLCODE,'' AS CONSLDESC,'' AS CONCCCODE,'' AS CONCCDESC,'' AS ADJGLCODE,'' AS ADJGLDESC,'' AS ADJSLCODE,'' AS ADJSLDESC,'' AS ADJCCCODE,'' AS ADJCCDESC,'' AS DAMGLCODE,'' AS DAMGLDESC,'' AS DAMSLCODE,'' AS DAMSLDESC,'' AS DAMCCCODE,'' AS DAMCCDESC FROM " & tabname & " "
            sql1 = sql1 & " WHERE " & CodeField & " NOT IN (Select CategoryCode from AccountstaggingForCategory where tablename='" & tabname & "') "
            ssgrid.SetText(1, 0, "CATEGORYCODE")
            ssgrid.SetText(2, 0, "CATEGORYDESC")
        Else
            sql1 = "Select Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,CONGLCODE,CONGLDESC,CONSLCODE,CONSLDESC,CONCCCODE,CONCCDESC,ADJGLCODE AS ADJGLCODE,ADJGLDESC,ADJSLCODE,ADJSLDESC,ADJCCCODE,ADJCCDESC,DAMGLCODE,DAMGLDESC,DAMSLCODE,DAMSLDESC,DAMCCCODE,DAMCCDESC from AccountstaggingNEW where tablename='" & tabname & "' UNION "
            sql1 = sql1 & " SELECT distinct " & CodeField & "," & Codedesc & ",'' AS accountcode,'' AS accountdesc,'' AS slcode,'' AS sldesc,'' AS costcentercode,'' AS costcenterdesc, '' AS CONGLCODE,'' AS CONGLDESC,'' AS CONSLCODE,'' AS CONSLDESC,'' AS CONCCCODE,'' AS CONCCDESC,'' AS ADJGLCODE,'' AS ADJGLDESC,'' AS ADJSLCODE,'' AS ADJSLDESC,'' AS ADJCCCODE,'' AS ADJCCDESC,'' AS DAMGLCODE,'' AS DAMGLDESC,'' AS DAMSLCODE,'' AS DAMSLDESC,'' AS DAMCCCODE,'' AS DAMCCDESC FROM " & tabname & " "
            sql1 = sql1 & " WHERE " & CodeField & " NOT IN (Select Code from AccountstaggingNEW where tablename='" & tabname & "') and isnull(freeze,'N')<>'Y' "

        End If
        'order by " & Codeorderfield
        'If gAcPostingWise <> "STORE" Then
        '    For RW As Integer = 5 To 24
        '        ssgrid.Col = RW
        '        ssgrid.ColHidden = True
        '    Next

        'End If


        gconnection.getDataSet(sql1, "AccountstaggingNEW")
        If gdataset.Tables("AccountstaggingNEW").Rows.Count > 0 Then

            ssgrid.MaxRows = gdataset.Tables("AccountstaggingNEW").Rows.Count
            For i As Integer = 0 To gdataset.Tables("AccountstaggingNEW").Rows.Count - 1
                With ssgrid


                    '================STORE======================================
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("Code")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("description")
                    .Row = i + 1
                    .Col = 3
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("accountcode")
                    .Row = i + 1
                    .Col = 4
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("accountdesc")
                    .Row = i + 1
                    .Col = 5
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("slcode")
                    .Row = i + 1
                    .Col = 6
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("sldesc")
                    .Row = i + 1
                    .Col = 7
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("costcentercode")
                    .Row = i + 1
                    .Col = 8
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("costcenterdesc")


                    '======================CONSUMPTION============================
                    .Row = i + 1
                    .Col = 9
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("CONGLCODE")
                    .Row = i + 1
                    .Col = 10
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("CONGLDESC")

                    .Row = i + 1
                    .Col = 11
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("CONSLCODE")
                    .Row = i + 1
                    .Col = 12
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("CONSLDESC")

                    .Col = 13
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("CONCCCODE")
                    .Row = i + 1
                    .Col = 14
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("CONCCDESC")


                    '======================ADJ           ============================
                    'ADJGLCODE  ADJGLDESC      ADJSLCODE     ADJSLDESC     ADJCCCODE  ADJCCDESC
                    .Col = 15
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("ADJGLCODE")
                    .Col = 16
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("ADJGLDESC")
                    .Col = 17
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("ADJSLCODE")
                    .Col = 18
                    .Text = gdataset.Tables("AccountstaggingnEW").Rows(i).Item("ADJSLDESC")
                    .Col = 19
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("ADJCCCODE")
                    .Col = 20
                    .Text = gdataset.Tables("AccountstaggingnEW").Rows(i).Item("ADJCCDESC")
                    '======================DAMAGE============================
                    .Col = 21
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("DAMGLCODE")
                    .Col = 22
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("DAMGLDESC")
                    .Col = 23
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("DAMSLCODE")
                    .Col = 24
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("DAMSLDESC")
                    .Col = 25
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("DAMCCCODE")
                    .Col = 26
                    .Text = gdataset.Tables("AccountstaggingNEW").Rows(i).Item("DAMCCDESC")

                End With
            Next
        End If

        ssgrid.Row = 1
        ssgrid.Col = 3
        ssgrid.Focus()
    End Sub

    'bind accountcode

    Sub bindsubledger()



        If colledger = 5 Then
            Dim accode As String
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 3
            accode = ssgrid.Text
            ssgrid.Col = 5
            If ssgrid.Text = "" Then

                ssgrid.Col = 3
                gSQLString = "Select slcode,slname from accountssubledgermaster "
                M_WhereCondition = " where accode='" + ssgrid.Text + "' and isnull(freezeflag,'') <> 'Y' "
                Dim vform As New ListOperattion1
                vform.Field = "slcode,slname"
                vform.vFormatstring = "SUBLEDGERCODE | SUBLEDGERNAME              "
                vform.vCaption = "SUBLEDGER MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then

                    ssgrid.Col = 5
                    ssgrid.Text = vform.keyfield

                    ssgrid.Col = 6
                    ssgrid.Text = vform.keyfield1

                    vform.Close()
                    vform = Nothing
                Else

                End If
                ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
            Else
                gSQLString = "Select slcode,slname from accountssubledgermaster where slcode='" & ssgrid.Text & "' and accode='" + accode + "' and  isnull(freezeflag,'') = 'N'"
                gconnection.getDataSet(gSQLString, "accountssubledgermaster")
                If Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname") & "") <> "" Then

                    ssgrid.Col = 6
                    ssgrid.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname")

                End If
            End If
        ElseIf colledger = 11 Then
            Dim accode As String
            ssgrid.Row = ssgrid.ActiveRow

            ssgrid.Col = 9
            accode = ssgrid.Text
            ssgrid.Col = 11
            If ssgrid.Text = "" Then

                ssgrid.Col = 9
                gSQLString = "Select slcode,slname from accountssubledgermaster "
                M_WhereCondition = " where accode='" + ssgrid.Text + "' and isnull(freezeflag,'') = 'N'"
                Dim vform As New ListOperattion1
                vform.Field = "slcode,slname"
                vform.vFormatstring = "SUBLEDGERCODE | SUBLEDGERNAME              "
                vform.vCaption = "SUBLEDGER MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then

                    ssgrid.Col = 11
                    ssgrid.Text = vform.keyfield

                    ssgrid.Col = 12
                    ssgrid.Text = vform.keyfield1

                    vform.Close()
                    vform = Nothing
                Else

                End If
                ssgrid.SetActiveCell(13, ssgrid.ActiveRow)
            Else
                gSQLString = "Select slcode,slname from accountssubledgermaster where slcode='" & ssgrid.Text & "' and accode='" + accode + "' and isnull(freezeflag,'') = 'N'"
                gconnection.getDataSet(gSQLString, "accountssubledgermaster")
                If Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname") & "") <> "" Then

                    ssgrid.Col = 12
                    ssgrid.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname")

                End If
            End If
        ElseIf colledger = 17 Then
            Dim accode As String
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 15
            accode = ssgrid.Text
            ssgrid.Col = 17
            If ssgrid.Text = "" Then

                ssgrid.Col = 15
                gSQLString = "Select slcode,slname from accountssubledgermaster "
                M_WhereCondition = " where accode='" + ssgrid.Text + "' and  isnull(freezeflag,'') = 'N'"
                Dim vform As New ListOperattion1
                vform.Field = "slcode,slname"
                vform.vFormatstring = "SUBLEDGERCODE | SUBLEDGERNAME              "
                vform.vCaption = "SUBLEDGER MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then

                    ssgrid.Col = 17
                    ssgrid.Text = vform.keyfield

                    ssgrid.Col = 18
                    ssgrid.Text = vform.keyfield1

                    vform.Close()
                    vform = Nothing

                Else

                End If
                ssgrid.SetActiveCell(19, ssgrid.ActiveRow)
            Else
                gSQLString = "Select slcode,slname from accountssubledgermaster where slcode='" & ssgrid.Text & "' and accode='" + accode + "' and isnull(freezeflag,'') = 'N'"
                gconnection.getDataSet(gSQLString, "accountssubledgermaster")
                If Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname") & "") <> "" Then

                    ssgrid.Col = 18
                    ssgrid.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname")

                End If
            End If
        ElseIf colledger = 23 Then
            Dim accode As String
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 21
            accode = ssgrid.Text
            ssgrid.Col = 23
            If ssgrid.Text = "" Then

                ssgrid.Col = 21
                gSQLString = "Select slcode,slname from accountssubledgermaster "
                M_WhereCondition = " where accode='" + ssgrid.Text + "' and  isnull(freezeflag,'') = 'N'"
                Dim vform As New ListOperattion1
                vform.Field = "slcode,slname"
                vform.vFormatstring = "SUBLEDGERCODE | SUBLEDGERNAME              "
                vform.vCaption = "SUBLEDGER MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then

                    ssgrid.Col = 23
                    ssgrid.Text = vform.keyfield

                    ssgrid.Col = 24
                    ssgrid.Text = vform.keyfield1

                    vform.Close()
                    vform = Nothing
                Else

                End If
                ssgrid.SetActiveCell(25, ssgrid.ActiveRow)
            Else
                gSQLString = "Select slcode,slname from accountssubledgermaster where slcode='" & ssgrid.Text & "' and accode='" + accode + "' and isnull(freezeflag,'') = 'N'"
                gconnection.getDataSet(gSQLString, "accountssubledgermaster")
                If Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname") & "") <> "" Then

                    ssgrid.Col = 24
                    ssgrid.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname")

                End If
            End If
        End If
    End Sub


    'bindcostcenter
    Sub bindaccountcenter()

        If costCent = 7 Then
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 7
            If ssgrid.Text = "" Then

                gSQLString = "Select costcentercode,costcenterdesc from AccountsCostCenterMaster "
                M_WhereCondition = " where isnull(freezeflag,'')<>'Y' "
                Dim vform As New ListOperattion1
                vform.Field = "costcentercode,costcenterdesc"
                vform.vFormatstring = "COSTCENTER CODE | COSTCENTER DESCRIPTION            |  "
                vform.vCaption = "COSTCENTER MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then

                    ssgrid.Col = 7
                    ssgrid.Text = vform.keyfield

                    ssgrid.Col = 8
                    ssgrid.Text = vform.keyfield1

                    vform.Close()
                    vform = Nothing

                End If
                ssgrid.SetActiveCell(9, ssgrid.ActiveRow)
            Else
                gSQLString = "Select costcentercode,costcenterdesc from AccountsCostCenterMaster where costcentercode='" & ssgrid.Text & "' AND isnull(freezeflag,'')<>'Y'"
                gconnection.getDataSet(gSQLString, "AccountsCostCenterMaster")
                If Trim(gdataset.Tables("AccountsCostCenterMaster").Rows(0).Item("costcenterdesc") & "") <> "" Then

                    ssgrid.Col = 8
                    ssgrid.Text = gdataset.Tables("AccountsCostCenterMaster").Rows(0).Item("costcenterdesc")

                End If

            End If
            ssgrid.SetActiveCell(9, ssgrid.ActiveRow)
        ElseIf costCent = 13 Then
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 13
            If ssgrid.Text = "" Then

                gSQLString = "Select costcentercode,costcenterdesc from AccountsCostCenterMaster "
                M_WhereCondition = " where isnull(freezeflag,'')<>'Y' "
                Dim vform As New ListOperattion1
                vform.Field = "costcentercode,costcenterdesc"
                vform.vFormatstring = "COSTCENTER CODE | COSTCENTER DESCRIPTION            |  "
                vform.vCaption = "COSTCENTER MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then

                    ssgrid.Col = 13
                    ssgrid.Text = vform.keyfield

                    ssgrid.Col = 14
                    ssgrid.Text = vform.keyfield1

                    vform.Close()
                    vform = Nothing

                End If
                ssgrid.SetActiveCell(15, ssgrid.ActiveRow)
            Else
                gSQLString = "Select costcentercode,costcenterdesc from AccountsCostCenterMaster where costcentercode='" & ssgrid.Text & "' AND isnull(freezeflag,'')<>'Y'"
                gconnection.getDataSet(gSQLString, "AccountsCostCenterMaster")
                If Trim(gdataset.Tables("AccountsCostCenterMaster").Rows(0).Item("costcenterdesc") & "") <> "" Then

                    ssgrid.Col = 14
                    ssgrid.Text = gdataset.Tables("AccountsCostCenterMaster").Rows(0).Item("costcenterdesc")

                End If



            End If
            ssgrid.SetActiveCell(15, ssgrid.ActiveRow)
        ElseIf costCent = 19 Then
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 19
            If ssgrid.Text = "" Then

                gSQLString = "Select costcentercode,costcenterdesc from AccountsCostCenterMaster "
                M_WhereCondition = " where isnull(freezeflag,'')<>'Y' "
                Dim vform As New ListOperattion1
                vform.Field = "costcentercode,costcenterdesc"
                vform.vFormatstring = "COSTCENTER CODE | COSTCENTER DESCRIPTION            |  "
                vform.vCaption = "COSTCENTER MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then

                    ssgrid.Col = 19
                    ssgrid.Text = vform.keyfield

                    ssgrid.Col = 20
                    ssgrid.Text = vform.keyfield1

                    vform.Close()
                    vform = Nothing

                End If
                ssgrid.SetActiveCell(21, ssgrid.ActiveRow)
            Else
                gSQLString = "Select costcentercode,costcenterdesc from AccountsCostCenterMaster where costcentercode='" & ssgrid.Text & "' AND isnull(freezeflag,'')<>'Y'"
                gconnection.getDataSet(gSQLString, "AccountsCostCenterMaster")
                If Trim(gdataset.Tables("AccountsCostCenterMaster").Rows(0).Item("costcenterdesc") & "") <> "" Then

                    ssgrid.Col = 20
                    ssgrid.Text = gdataset.Tables("AccountsCostCenterMaster").Rows(0).Item("costcenterdesc")

                End If



            End If
        ElseIf costCent = 25 Then
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 25
            If ssgrid.Text = "" Then

                gSQLString = "Select costcentercode,costcenterdesc from AccountsCostCenterMaster "
                M_WhereCondition = " where isnull(freezeflag,'')<>'Y' "
                Dim vform As New ListOperattion1
                vform.Field = "costcentercode,costcenterdesc"
                vform.vFormatstring = "COSTCENTER CODE | COSTCENTER DESCRIPTION            |  "
                vform.vCaption = "COSTCENTER MASTER HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1

                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then

                    ssgrid.Col = 25
                    ssgrid.Text = vform.keyfield

                    ssgrid.Col = 26
                    ssgrid.Text = vform.keyfield1

                    vform.Close()
                    vform = Nothing

                End If
                ssgrid.SetActiveCell(3, ssgrid.ActiveRow + 1)
            Else
                gSQLString = "Select costcentercode,costcenterdesc from AccountsCostCenterMaster where costcentercode='" & ssgrid.Text & "' AND isnull(freezeflag,'')<>'Y'"
                gconnection.getDataSet(gSQLString, "AccountsCostCenterMaster")
                If Trim(gdataset.Tables("AccountsCostCenterMaster").Rows(0).Item("costcenterdesc") & "") <> "" Then

                    ssgrid.Col = 26
                    ssgrid.Text = gdataset.Tables("AccountsCostCenterMaster").Rows(0).Item("costcenterdesc")

                End If



            End If
            ssgrid.SetActiveCell(3, ssgrid.ActiveRow + 1)
        End If

    End Sub



    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent

        If e.keyCode = Keys.Enter Then

            If ssgrid.ActiveCol = 3 Or ssgrid.ActiveCol = 9 Or ssgrid.ActiveCol = 15 Or ssgrid.ActiveCol = 21 Then
                col = ssgrid.ActiveCol
                ssgrid.Row = ssgrid.ActiveRow
                bindaccode()
            ElseIf ssgrid.ActiveCol = 5 Or ssgrid.ActiveCol = 11 Or ssgrid.ActiveCol = 17 Or ssgrid.ActiveCol = 23 Then
                colledger = ssgrid.ActiveCol
                ssgrid.Row = ssgrid.ActiveRow

                bindsubledger()
            ElseIf ssgrid.ActiveCol = 7 Or ssgrid.ActiveCol = 13 Or ssgrid.ActiveCol = 19 Or ssgrid.ActiveCol = 25 Then
                costCent = ssgrid.ActiveCol
                ssgrid.Row = ssgrid.ActiveRow

                bindaccountcenter()

            End If


        ElseIf e.keyCode = Keys.F8 Then
            Dim search As New frmSearch
            search.farPoint = ssgrid
            search.Text = "Item Search"
            search.ShowDialog(Me)
            Exit Sub
        ElseIf e.keyCode = Keys.F3 Then
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 3
            ssgrid.Text = ""
            ssgrid.Col = 4
            ssgrid.Text = ""

            ssgrid.Col = 5
            ssgrid.Text = ""
            ssgrid.Col = 6
            ssgrid.Text = ""
            ssgrid.Col = 7
            ssgrid.Text = ""
            ssgrid.Col = 8
            ssgrid.Text = ""

            ssgrid.Col = 9
            ssgrid.Text = ""
            ssgrid.Col = 10
            ssgrid.Text = ""
            ssgrid.Col = 11
            ssgrid.Text = ""
            ssgrid.Col = 12
            ssgrid.Text = ""

            ssgrid.Col = 13
            ssgrid.Text = ""
            ssgrid.Col = 14
            ssgrid.Text = ""
            ssgrid.Col = 15
            ssgrid.Text = ""
            ssgrid.Col = 16
            ssgrid.Text = ""

            ssgrid.Col = 17
            ssgrid.Text = ""
            ssgrid.Col = 18
            ssgrid.Text = ""
            ssgrid.Col = 19
            ssgrid.Text = ""
            ssgrid.Col = 20
            ssgrid.Text = ""

            ssgrid.Col = 21
            ssgrid.Text = ""
            ssgrid.Col = 22
            ssgrid.Text = ""
            ssgrid.Col = 23
            ssgrid.Text = ""
            ssgrid.Col = 24
            ssgrid.Text = ""
            ssgrid.Col = 25
            ssgrid.Text = ""
            ssgrid.Col = 26
            ssgrid.Text = ""
            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
        End If
    End Sub
    Function checkvalidate() As Boolean
        Dim flag As Boolean = False
        Dim Accode As String
        For s As Integer = 1 To ssgrid.DataRowCnt - 1
            For I As Integer = 1 To ssgrid.DataColCnt - 1
                ssgrid.Row = s
                ssgrid.Col = I
                If I = 3 Or I = 9 Or I = 15 Or I = 21 Then
                    Accode = ssgrid.Text
                    If Accode <> "" Then
                        Dim sql As String = "select * from Accountsglaccountmaster where Accode='" + ssgrid.Text + "'"
                        gconnection.getDataSet(sql, "Accountsglaccountmaster")
                        If (gdataset.Tables("Accountsglaccountmaster").Rows.Count = 0) Then
                            MsgBox("Accountcode is incorrect..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname)
                            Exit Function
                        ElseIf gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                            If I = 5 Or I = 11 Or I = 17 Or I = 23 Then
                                Accode = ssgrid.Text
                                If Accode <> "" Then
                                    ' Select slcode,slname from accountssubledgermaster
                                    Dim sql1 As String = "select count(*) from accountssubledgermaster where slcode='" + ssgrid.Text + "'"
                                    If (gconnection.getvalue(sql1) = 0) Then
                                        MsgBox("SubLedger Code is Incorrect..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname)
                                        Exit Function
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                If Costcenter = True Then
                    ssgrid.Row = s
                    ssgrid.Col = I
                    If I = 7 Or I = 13 Or I = 19 Or I = 25 Then
                        Accode = ssgrid.Text
                        If Accode <> "" Then
                            Dim sql2 As String = "select count(*) from AccountsCostCenterMaster where costcentercode='" + ssgrid.Text + "'"
                            If (gconnection.getvalue(sql2) = 0) Then
                                MsgBox("CostCenter is incorrect..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname)
                                Exit Function
                            End If
                        End If
                    End If
                End If

            Next
        Next
        flag = True
        Return flag
    End Function
    Private Sub cmdsave_Click(sender As Object, e As EventArgs) Handles cmdsave.Click
        If checkvalidate() = False Then
            Exit Sub
        End If
        Dim Sql As String = ""
        Dim insert(0) As String
        For s As Integer = 0 To ssgrid.DataRowCnt - 1
            ssgrid.Row = s + 1
            ssgrid.Col = 1                                                                                                                                                                  'ADJGLCODE  ADJGLDESC      ADJSLCODE     ADJSLDESC     ADJCCCODE  ADJCCDESC
            If gAcPostingWise = "ITEM" Then
                Dim sst As String = "select count(*) from AccountstaggingForITEM where ITEMcode='" + ssgrid.Text + "' and tablename='" + tabname + "'"
                If gconnection.getvalue(sst) = 0 Then
                    Sql = "Insert into AccountstaggingForITEM(ItemCode,Itemname,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,CONGLCODE,CONGLDESC,CONSLCODE,CONSLDESC,CONCCCODE,CONCCDESC,ADJGLCODE,ADJGLDESC,ADJSLCODE,ADJSLDESC,ADJCCCODE , ADJCCDESC,DAMGLCODE,DAMGLDESC,DAMSLCODE,DAMSLDESC,DAMCCCODE,DAMCCDESC,void,tablename,colname) values( "
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 2
                    Sql = Sql & " '" + ssgrid.Text + "',"

                    ssgrid.Row = s + 1
                    ssgrid.Col = 3
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 4
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 5
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 6
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 7
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 8
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 9
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 10
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 11
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 12
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 13
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 14
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 15
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 16
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 17
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 18
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 19
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 20
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 21
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 22
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 23
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 24
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 25
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 26
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    Sql = Sql & " 'N',"
                    Sql = Sql & " '" + tabname + "',"
                    Sql = Sql & " '" + CodeField + "')"
                Else
                    Sql = "Update AccountstaggingForITEM set "
                    '(Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,void,tablename,colname) values( "
                    ssgrid.Row = s + 1
                    ssgrid.Col = 3

                    Sql = Sql & "accountcode= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 4
                    Sql = Sql & "accountdesc= '" + ssgrid.Text + "',"

                    ssgrid.Row = s + 1
                    ssgrid.Col = 5
                    Sql = Sql & "slcode= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 6
                    Sql = Sql & "sldesc= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 7
                    Sql = Sql & "costcentercode= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 8
                    Sql = Sql & "costcenterdesc= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1

                    ssgrid.Col = 9
                    Sql = Sql & "CONGLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 10
                    Sql = Sql & "CONGLDESC= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 11
                    Sql = Sql & "CONSLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 12
                    Sql = Sql & "CONSLDESC= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 13
                    Sql = Sql & "CONCCCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 14
                    Sql = Sql & "CONCCDESC= '" + ssgrid.Text + "',"

                    'ADJGLCODE  ADJGLDESC      ADJSLCODE     ADJSLDESC     ADJCCCODE  ADJCCDESC

                    ssgrid.Row = s + 1
                    ssgrid.Col = 15
                    Sql = Sql & "ADJGLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 16
                    Sql = Sql & " ADJGLDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 17
                    Sql = Sql & "ADJSLCODE='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 18
                    Sql = Sql & "ADJSLDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 19
                    Sql = Sql & "ADJCCCODE='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 20
                    Sql = Sql & "ADJCCDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 21
                    Sql = Sql & "DAMGLCODE ='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 22
                    Sql = Sql & "DAMGLDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 23
                    Sql = Sql & "DAMSLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 24
                    Sql = Sql & "DAMSLDESC ='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 25
                    Sql = Sql & "DAMCCCODE ='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 26
                    Sql = Sql & "DAMCCDESC= '" + ssgrid.Text + "'"
                    ' Sql = Sql & " 'N'"
                    Sql = Sql & " where tablename= '" + tabname + "'"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 1

                    Sql = Sql & " and ItemCode='" + ssgrid.Text + "'"


                End If
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = Sql
            ElseIf gAcPostingWise = "CATEGORY" Then                                                                                                                                                                                                                    'ADJGLCODE  ADJGLDESC      ADJSLCODE     ADJSLDESC     ADJCCCODE  ADJCCDESC
                Dim sst As String = "select count(*) from AccountstaggingForCategory where CategoryCode='" + ssgrid.Text + "' and tablename='" + tabname + "'"
                If gconnection.getvalue(sst) = 0 Then
                    Sql = "Insert into AccountstaggingForCategory(CategoryCode,CategoryDesc,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,CONGLCODE,CONGLDESC,CONSLCODE,CONSLDESC,CONCCCODE,CONCCDESC,ADJGLCODE,ADJGLDESC,ADJSLCODE,ADJSLDESC,ADJCCCODE , ADJCCDESC,DAMGLCODE,DAMGLDESC,DAMSLCODE,DAMSLDESC,DAMCCCODE,DAMCCDESC,void,tablename,colname) values( "
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 2
                    Sql = Sql & " '" + ssgrid.Text + "',"

                    ssgrid.Row = s + 1
                    ssgrid.Col = 3
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 4
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 5
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 6
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 7
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 8
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 9
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 10
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 11
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 12
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 13
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 14
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 15
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 16
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 17
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 18
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 19
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 20
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 21
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 22
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 23
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 24
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 25
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 26
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    Sql = Sql & " 'N',"
                    Sql = Sql & " '" + tabname + "',"
                    Sql = Sql & " '" + CodeField + "')"
                Else
                    Sql = "Update AccountstaggingForCategory set "
                    '(Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,void,tablename,colname) values( "
                    ssgrid.Row = s + 1
                    ssgrid.Col = 3

                    Sql = Sql & "accountcode= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 4
                    Sql = Sql & "accountdesc= '" + ssgrid.Text + "',"

                    ssgrid.Row = s + 1
                    ssgrid.Col = 5
                    Sql = Sql & "slcode= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 6
                    Sql = Sql & "sldesc= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 7
                    Sql = Sql & "costcentercode= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 8
                    Sql = Sql & "costcenterdesc= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1

                    ssgrid.Col = 9
                    Sql = Sql & "CONGLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 10
                    Sql = Sql & "CONGLDESC= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 11
                    Sql = Sql & "CONSLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 12
                    Sql = Sql & "CONSLDESC= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 13
                    Sql = Sql & "CONCCCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 14
                    Sql = Sql & "CONCCDESC= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 15
                    ssgrid.Row = s + 1
                    ssgrid.Col = 15
                    Sql = Sql & "ADJGLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 16
                    Sql = Sql & " ADJGLDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 17
                    Sql = Sql & "ADJSLCODE='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 18
                    Sql = Sql & "ADJSLDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 19
                    Sql = Sql & "ADJCCCODE='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 20
                    Sql = Sql & "ADJCCDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 21
                    Sql = Sql & "DAMGLCODE ='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 22
                    Sql = Sql & "DAMGLDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 23
                    Sql = Sql & "DAMSLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 24
                    Sql = Sql & "DAMSLDESC ='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 25
                    Sql = Sql & "DAMCCCODE ='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 26
                    Sql = Sql & "DAMCCDESC= '" + ssgrid.Text + "'"
                    ' Sql = Sql & " 'N'"
                    Sql = Sql & " where tablename= '" + tabname + "'"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 1

                    Sql = Sql & " and CategoryCode='" + ssgrid.Text + "'"
                End If
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = Sql
            Else
                Dim sst As String = "select count(*) from AccountstaggingNEW where code='" + ssgrid.Text + "' and tablename='" + tabname + "'"
                If gconnection.getvalue(sst) = 0 Then
                    Sql = "Insert into AccountstaggingNEW(Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,CONGLCODE,CONGLDESC,CONSLCODE,CONSLDESC,CONCCCODE,CONCCDESC,ADJGLCODE,ADJGLDESC,ADJSLCODE,ADJSLDESC,ADJCCCODE , ADJCCDESC,DAMGLCODE,DAMGLDESC,DAMSLCODE,DAMSLDESC,DAMCCCODE,DAMCCDESC,void,tablename,colname) values( "
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 2
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 3
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 4
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 5
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 6
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 7
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 8
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 9
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 10
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 11
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 12
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 13
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 14
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 15
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 16
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 17
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 18
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 19
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 20
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 21
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 22
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 23
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 24
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 25
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 26
                    Sql = Sql & " '" + ssgrid.Text + "',"
                    Sql = Sql & " 'N',"
                    Sql = Sql & " '" + tabname + "',"
                    Sql = Sql & " '" + CodeField + "')"
                Else
                    Sql = "Update AccountstaggingNEW set "
                    '(Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,void,tablename,colname) values( "
                    ssgrid.Row = s + 1
                    ssgrid.Col = 3

                    Sql = Sql & "accountcode= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 4
                    Sql = Sql & "accountdesc= '" + ssgrid.Text + "',"

                    ssgrid.Row = s + 1
                    ssgrid.Col = 5
                    Sql = Sql & "slcode= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 6
                    Sql = Sql & "sldesc= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 7
                    Sql = Sql & "costcentercode= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 8
                    Sql = Sql & "costcenterdesc= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1

                    ssgrid.Col = 9
                    Sql = Sql & "CONGLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 10
                    Sql = Sql & "CONGLDESC= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 11
                    Sql = Sql & "CONSLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 12
                    Sql = Sql & "CONSLDESC= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 13
                    Sql = Sql & "CONCCCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 14
                    Sql = Sql & "CONCCDESC= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 15
                    Sql = Sql & "ADJGLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 16
                    Sql = Sql & " ADJGLDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 17
                    Sql = Sql & "ADJSLCODE='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 18
                    Sql = Sql & "ADJSLDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 19
                    Sql = Sql & "ADJCCCODE='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 20
                    Sql = Sql & "ADJCCDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 21
                    Sql = Sql & "DAMGLCODE ='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 22
                    Sql = Sql & "DAMGLDESC='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 23
                    Sql = Sql & "DAMSLCODE= '" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 24
                    Sql = Sql & "DAMSLDESC ='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 25
                    Sql = Sql & "DAMCCCODE ='" + ssgrid.Text + "',"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 26
                    Sql = Sql & "DAMCCDESC= '" + ssgrid.Text + "'"
                    ' Sql = Sql & " 'N'"
                    Sql = Sql & " where tablename= '" + tabname + "'"
                    ssgrid.Row = s + 1
                    ssgrid.Col = 1

                    Sql = Sql & " and Code='" + ssgrid.Text + "'"


                End If
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = Sql

            End If


        Next
        gconnection.MoreTrans(insert)

    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ssgrid_Advance(sender As Object, e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid.Advance

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class
