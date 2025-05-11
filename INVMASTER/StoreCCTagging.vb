Public Class StoreCCTagging
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdsave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoreCCTagging))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdsave = New System.Windows.Forms.Button()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(279, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(187, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(796, 457)
        Me.GroupBox1.TabIndex = 375
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmdexit)
        Me.GroupBox2.Controls.Add(Me.cmdsave)
        Me.GroupBox2.Location = New System.Drawing.Point(644, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(146, 124)
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
        Me.cmdexit.Location = New System.Drawing.Point(16, 65)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(124, 46)
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
        Me.cmdsave.Location = New System.Drawing.Point(16, 16)
        Me.cmdsave.Name = "cmdsave"
        Me.cmdsave.Size = New System.Drawing.Size(124, 46)
        Me.cmdsave.TabIndex = 0
        Me.cmdsave.Text = "ADD[F7]"
        Me.cmdsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdsave.UseVisualStyleBackColor = False
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(199, 129)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(568, 427)
        Me.ssgrid.TabIndex = 370
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 411)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 377
        Me.Label2.Text = "Press F3 For Reset"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 433)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 13)
        Me.Label3.TabIndex = 378
        Me.Label3.Text = "Press F8 for Search"
        '
        'StoreCCTagging
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1015, 641)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ssgrid)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "StoreCCTagging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SponsorAccountsTagging"
        Me.GroupBox1.ResumeLayout(False)
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

    Private Sub SponsorAccountsTagging_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.F7) And cmdsave.Visible = True Then
            cmdsave_Click(sender, e)
        End If
        If (e.KeyCode = Keys.F11) Then
            cmdexit_Click(sender, e)
        End If
    End Sub

    Private Sub SponsorAccountsTagging_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.DoubleBuffered = True
        If gcompname = "RTC" Or gcompname = "TMA" Or gcompname = "BTM" Then
            If Licensebool = False Then
                gconnection.FocusSetting(Me)
                Me.cmdexit.Visible = True
                'Me.cmd_exit.Visible = True
            End If
        End If
        'Call Resize_Form()
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        GroupBox1.Controls.Add(ssgrid)
        ssgrid.Location = New Point(10, 10)
        ssgrid.Width = GroupBox1.Width - 20

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
        GmoduleName = "STORECCTAGGING"
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

            .Row = 0
            .Col = 1
            .Text = "STORE CODE"

            .Row = 0
            .Col = 2
            .Text = "STORE DESCRIPTION"

            .Row = 0
            .Col = 3
            .Text = "COST CENTER CODE"

            .Row = 0
            .Col = 4
            .Text = "COST CENTER DESCRIPTION"


        End With


    End Sub

    ' code for column 3
    Sub bindaccode()
        ssgrid.Col = 3
        If ssgrid.Text = "" Then
            gSQLString = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster"
            M_WhereCondition = " where isnull(freezeflag,'') <> 'Y' "
            Dim vform As New ListOperattion1
            vform.Field = "Accode,Acdesc,subledgerflag,category"
            vform.vFormatstring = "ACCOUNT CODE |            ACCOUNT DESCRIPTION             |     SubLedger    | Category  "
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
                        If Costcenter = True Then
                            'ssgrid.Col = 7
                            'ssgrid.Text = ""
                            'ssgrid.Focus()
                            ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
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
            ssgrid.Col = 3
            gSQLString = "Select Accode,Acdesc,subledgerflag,category from Accountsglaccountmaster where Accode='" + ssgrid.Text + "'"
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

                            End If
                        End If
                    ElseIf gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "I" Or gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("category") = "E" Then


                        ssgrid.Col = 4
                        ssgrid.Text = gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("Acdesc")
                        If gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
                            ssgrid.Col = 5
                            ssgrid.Text = ""

                        Else
                            If Costcenter = True Then
                                ssgrid.Col = 7
                                ssgrid.Text = ""
                                ssgrid.Focus()
                                ssgrid.SetActiveCell(7, ssgrid.ActiveRow)
                            End If

                        End If


                    End If

                End If
            End If
            '            vform.Close()
            '           vform = Nothing
        End If



    End Sub

    'bind code field of ssgrid
    Sub bindcodefield()
        Dim sql1 As String = "Select storecode,storedesc,costcentercode,costcenterdesc from SToreCostCentertagging where tablename='" & tabname & "' UNION "
        sql1 = sql1 & " SELECT distinct " & CodeField & "," & Codedesc & ",'' AS costcentercode,'' AS costcenterdesc FROM " & tabname & " "
        sql1 = sql1 & " WHERE " & CodeField & " NOT IN (Select storecode from SToreCostCentertagging where tablename='" & tabname & "') "
        'order by " & Codeorderfield

        gconnection.getDataSet(sql1, "SToreCostCentertagging")
        If gdataset.Tables("SToreCostCentertagging").Rows.Count > 0 Then
            For i As Integer = 0 To gdataset.Tables("SToreCostCentertagging").Rows.Count - 1
                With ssgrid
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("SToreCostCentertagging").Rows(i).Item("storecode")

                    .Row = i + 1
                    .Col = 2
                    .Text = gdataset.Tables("SToreCostCentertagging").Rows(i).Item("storedesc")
                    '.Row = i + 1
                    '.Col = 3
                    '.Text = gdataset.Tables("SponsorAccountsTagging").Rows(i).Item("accountcode")
                    '.Row = i + 1
                    '.Col = 4
                    '.Text = gdataset.Tables("SponsorAccountsTagging").Rows(i).Item("accountdesc")
                    '.Row = i + 1
                    '.Col = 5
                    '.Text = gdataset.Tables("SponsorAccountsTagging").Rows(i).Item("slcode")
                    '.Row = i + 1
                    '.Col = 6
                    '.Text = gdataset.Tables("SponsorAccountstagging").Rows(i).Item("sldesc")
                    .Row = i + 1
                    .Col = 3
                    .Text = gdataset.Tables("SToreCostCentertagging").Rows(i).Item("costcentercode")
                    .Row = i + 1
                    .Col = 4
                    .Text = gdataset.Tables("SToreCostCentertagging").Rows(i).Item("costcenterdesc")


                End With
            Next
        End If

        ssgrid.Row = 1
        ssgrid.Col = 3
        ssgrid.Focus()
    End Sub

    'bind accountcode

    Sub bindsubledger()
        Dim accode As String

        ssgrid.Row = ssgrid.ActiveRow
        ssgrid.Col = 3
        accode = ssgrid.Text
        ssgrid.Col = 5
        If ssgrid.Text = "" Then

            ssgrid.Col = 3
            gSQLString = "Select slcode,slname from accountssubledgermaster "
            M_WhereCondition = " where accode='" + ssgrid.Text + "' "
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

            End If

        Else
            gSQLString = "Select slcode,slname from accountssubledgermaster where slcode='" & ssgrid.Text & "' and accode='" + accode + "'"
            gconnection.getDataSet(gSQLString, "accountssubledgermaster")
            If Trim(gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname") & "") <> "" Then

                ssgrid.Col = 6
                ssgrid.Text = gdataset.Tables("accountssubledgermaster").Rows(0).Item("slname")

            End If
        End If

    End Sub


    'bindcostcenter
    Sub bindaccountcenter()
        ssgrid.Row = ssgrid.ActiveRow
        ssgrid.Col = 3
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

                ssgrid.Col = 3
                ssgrid.Text = vform.keyfield

                ssgrid.Col = 4
                ssgrid.Text = vform.keyfield1

                vform.Close()
                vform = Nothing

            End If
        Else
            gSQLString = "Select costcentercode,costcenterdesc from AccountsCostCenterMaster where costcentercode='" & ssgrid.Text & "'"
            gconnection.getDataSet(gSQLString, "AccountsCostCenterMaster")
            If Trim(gdataset.Tables("AccountsCostCenterMaster").Rows(0).Item("costcenterdesc") & "") <> "" Then

                ssgrid.Col = 4
                ssgrid.Text = gdataset.Tables("AccountsCostCenterMaster").Rows(0).Item("costcenterdesc")

            End If



        End If
        ssgrid.SetActiveCell(3, ssgrid.ActiveRow + 1)
    End Sub


    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        If e.keyCode = Keys.Enter Then


            If ssgrid.ActiveCol = 3 Then
                '    ssgrid.Row = ssgrid.ActiveRow
                '    bindaccode()
                'ElseIf ssgrid.ActiveCol = 5 Then
                '    ssgrid.Row = ssgrid.ActiveRow

                '    bindsubledger()
                'ElseIf ssgrid.ActiveCol = 7 Then
                '    ssgrid.Row = ssgrid.ActiveRow

                bindaccountcenter()

            End If


        ElseIf e.keyCode = Keys.F8 Then
            Dim search As New frmSearch
            search.farPoint = ssgrid
            search.Text = "Store Search"
            search.ShowDialog(Me)
            Exit Sub
        ElseIf e.keyCode = Keys.F3 Then
            ssgrid.Row = ssgrid.ActiveRow
            ssgrid.Col = 3
            ssgrid.Text = ""
            ssgrid.Col = 4
            ssgrid.Text = ""

            'ssgrid.Col = 5
            'ssgrid.Text = ""
            'ssgrid.Col = 6
            'ssgrid.Text = ""
            'ssgrid.Col = 7
            'ssgrid.Text = ""
            'ssgrid.Col = 8
            'ssgrid.Text = ""
            ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
        End If




    End Sub

    Function checkvalidate() As Boolean
        Dim flag As Boolean = False
        Dim Accode As String
        For s As Integer = 1 To ssgrid.DataRowCnt - 1
            'ssgrid.Row = s
            'ssgrid.Col = 3
            'Accode = ssgrid.Text
            'If Accode <> "" Then
            '    Dim sql As String = "select * from Accountsglaccountmaster where Accode='" + ssgrid.Text + "'"
            '    gconnection.getDataSet(sql, "Accountsglaccountmaster")
            '    If (gdataset.Tables("Accountsglaccountmaster").Rows.Count = 0) Then
            '        MsgBox("Accountcode is incorrect..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname)
            '        Exit Function
            '    ElseIf gdataset.Tables("Accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then

            '        ssgrid.Row = s
            '        ssgrid.Col = 5
            '        If Accode <> "" Then
            '            ' Select slcode,slname from accountssubledgermaster
            '            Dim sql1 As String = "select count(*) from accountssubledgermaster where slcode='" + ssgrid.Text + "'"
            '            If (gconnection.getvalue(sql1) = 0) Then
            '                MsgBox("SubLedger Code is Incorrect..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname)
            '                Exit Function
            '            End If
            '        End If
            '    End If
            If Costcenter = True Then
                ssgrid.Row = s
                ssgrid.Col = 7
                Accode = ssgrid.Text
                If Accode <> "" Then
                    Dim sql2 As String = "select count(*) from AccountsCostCenterMaster where costcentercode='" + ssgrid.Text + "'"
                    If (gconnection.getvalue(sql2) = 0) Then
                        MsgBox("CostCenter is incorrect..... ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, gCompanyname)
                        Exit Function
                    End If

                End If

            End If
            ' End If
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
            ssgrid.Col = 1
            Dim sst As String = "select count(*) from SToreCostCentertagging where storeCode='" + ssgrid.Text + "' and tablename='" + tabname + "'"
            If gconnection.getvalue(sst) = 0 Then
                Sql = "Insert into SToreCostCentertagging(storeCode,storedesc,costcentercode,costcenterdesc,void,tablename,colname) values( "
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

                Sql = Sql & " 'N',"
                Sql = Sql & " '" + tabname + "',"
                Sql = Sql & " '" + CodeField + "')"
            Else
                Sql = "Update SToreCostCentertagging set "
                '(Code,description,accountcode,accountdesc,slcode,sldesc,costcentercode,costcenterdesc,void,tablename,colname) values( "
                ssgrid.Row = s + 1
                ssgrid.Col = 3

                Sql = Sql & "costcentercode= '" + ssgrid.Text + "',"
                ssgrid.Row = s + 1
                ssgrid.Col = 4
                Sql = Sql & "costcenterdesc= '" + ssgrid.Text + "' "

                ' Sql = Sql & " 'N'"
                Sql = Sql & " where tablename= '" + tabname + "'"
                ssgrid.Row = s + 1
                ssgrid.Col = 1

                Sql = Sql & " and storecode='" + ssgrid.Text + "'"


            End If
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = Sql

        Next
        gconnection.MoreTrans(insert)

    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StoreCCTagging_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
