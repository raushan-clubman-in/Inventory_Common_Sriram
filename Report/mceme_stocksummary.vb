Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class mceme_stocksummary
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
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents ssg As AxFPSpreadADO.AxfpSpread
    Friend WithEvents chk_excel As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTP_TODATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_FROMDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mceme_stocksummary))
        Me.lbl_Heading = New System.Windows.Forms.Label()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.cmd_export = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DTP_TODATE = New System.Windows.Forms.DateTimePicker()
        Me.DTP_FROMDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ssg = New AxFPSpreadADO.AxfpSpread()
        Me.chk_excel = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ssg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(186, 71)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(135, 18)
        Me.lbl_Heading.TabIndex = 8
        Me.lbl_Heading.Text = "MONTH STB BAR"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = Global.Inventory.My.Resources.Resources.view
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(3, 109)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_View.TabIndex = 6
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Exit.Image = Global.Inventory.My.Resources.Resources._Exit
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(3, 209)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_Exit.TabIndex = 7
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.Black
        Me.Cmd_Clear.Image = Global.Inventory.My.Resources.Resources.Clear
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(3, 12)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(134, 56)
        Me.Cmd_Clear.TabIndex = 4
        Me.Cmd_Clear.Text = "Clear[F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'cmd_export
        '
        Me.cmd_export.BackColor = System.Drawing.Color.Transparent
        Me.cmd_export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_export.ForeColor = System.Drawing.Color.Black
        Me.cmd_export.Image = Global.Inventory.My.Resources.Resources.excel
        Me.cmd_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_export.Location = New System.Drawing.Point(3, 150)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(134, 56)
        Me.cmd_export.TabIndex = 8
        Me.cmd_export.Text = "Export"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        Me.cmd_export.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.DTP_TODATE)
        Me.GroupBox1.Controls.Add(Me.DTP_FROMDATE)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(263, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(512, 86)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'DTP_TODATE
        '
        Me.DTP_TODATE.CustomFormat = "dd MM yyyy"
        Me.DTP_TODATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_TODATE.Location = New System.Drawing.Point(349, 24)
        Me.DTP_TODATE.Name = "DTP_TODATE"
        Me.DTP_TODATE.Size = New System.Drawing.Size(145, 22)
        Me.DTP_TODATE.TabIndex = 19
        '
        'DTP_FROMDATE
        '
        Me.DTP_FROMDATE.CustomFormat = "dd MM yyyy"
        Me.DTP_FROMDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_FROMDATE.Location = New System.Drawing.Point(110, 22)
        Me.DTP_FROMDATE.Name = "DTP_FROMDATE"
        Me.DTP_FROMDATE.Size = New System.Drawing.Size(145, 22)
        Me.DTP_FROMDATE.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(275, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "TO DATE:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "FROM DATE:"
        '
        'ssg
        '
        Me.ssg.DataSource = Nothing
        Me.ssg.Location = New System.Drawing.Point(168, 192)
        Me.ssg.Name = "ssg"
        Me.ssg.OcxState = CType(resources.GetObject("ssg.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssg.Size = New System.Drawing.Size(616, 160)
        Me.ssg.TabIndex = 2
        '
        'chk_excel
        '
        Me.chk_excel.AutoSize = True
        Me.chk_excel.Location = New System.Drawing.Point(630, 621)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(104, 20)
        Me.chk_excel.TabIndex = 18
        Me.chk_excel.Text = "CheckBox1"
        Me.chk_excel.UseVisualStyleBackColor = True
        Me.chk_excel.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox3.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox3.Controls.Add(Me.cmd_export)
        Me.GroupBox3.Controls.Add(Me.Cmd_View)
        Me.GroupBox3.Location = New System.Drawing.Point(856, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(140, 276)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CheckBox1)
        Me.GroupBox4.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(266, 188)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(508, 144)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(120, 13)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(95, 19)
        Me.CheckBox1.TabIndex = 20
        Me.CheckBox1.Text = "SELECT ALL"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(120, 36)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(169, 84)
        Me.CheckedListBox1.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "STORE CODE:-"
        '
        'mceme_stocksummary
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.NavajoWhite
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1024, 724)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chk_excel)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "mceme_stocksummary"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "STOCK SUMMARY"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ssg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim pagesize, pageno As Integer
    Dim dr As DataRow
    Dim QTY, QTY1, QTY2, QTY3, VNO, QTY4 As Double
    Dim vrno As Double
    Dim i As Integer = 1
    Dim D1 As DataTable
    'Public DR As New DataRow
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 724
        K = 1024
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
                        If Controls(i_i).Name = "GroupBox3" Then
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


    Private Sub Sub_Group_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Resize_Form()
        Me.DoubleBuffered = True

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        SubGroupMasterbool = True
        FILLGRID_STORE()
        DTP_FROMDATE.Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MMM/yyyy")
        DTP_TODATE.Value = Format(Now, "dd/MMM/yyyy")
        ' CheckedListBox1.Enabled = False
    End Sub

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='INVENTORY' AND MODULENAME LIKE '%" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        
        Me.Cmd_View.Enabled = False
       
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                   
                    Me.Cmd_View.Enabled = True
                   
                    Exit Sub
                End If
               
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                    
                End If
                If Right(x) = "U" Then
                    'Me.btn_validation.Enabled = True
                End If
                If Right(x) = "P" Then
                    ' Me.cmd_print.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
      
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        For i = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetSelected(i, False)
            CheckedListBox1.SetItemChecked(i, False)
        Next
        DTP_FROMDATE.Value = Date.Now()
        DTP_TODATE.Value = Date.Now()
        CheckBox1.Checked = False
    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
       
        If CheckBox1.Checked = False Then
            MessageBox.Show("Please select store")
        Else
            NEW_REPORT1()
        End If
    End Sub


    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

   
    Private Sub Sub_Group_Master_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
       
        If e.KeyCode = Keys.F9 And Cmd_View.Enabled = True Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        End If
        
        If e.KeyCode = Keys.F4 Then
            'Call cmdGroupCode_Click(cmdGroupCode, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub


    Private Sub Sub_Group_Master_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        SubGroupMasterbool = False
    End Sub


    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
        NEW_REPORT1()
    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start(AppPath & "/STUDY/SUBGROUPMASTER.XLS")
    End Sub

    Private Sub DTP_FROMDATE_KeyDown(sender As Object, e As KeyEventArgs) Handles DTP_FROMDATE.KeyDown
        If e.KeyCode = Keys.Enter Then
            DTP_TODATE.Focus()
        End If
    End Sub

    Private Sub DTP_TODATE_KeyDown(sender As Object, e As KeyEventArgs) Handles DTP_TODATE.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(DTP_FROMDATE.Text) >= Val(DTP_TODATE.Text) Then
                MessageBox.Show("FROM DATE CANNOT BE GREATER THAN OR EQUAL TO TODATE")
                Exit Sub
            Else
                'TXT_DAYS.Text = Val(DTP_TODATE.Text) - Val(DTP_FROMDATE.Text)
                'TXT_PUREVEG.Focus()
            End If
        End If
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        Dim ITR As Integer
        If CheckBox1.Checked = True Then
            For ITR = 0 To (CheckedListBox1.Items.Count - 1)
                CheckedListBox1.SetSelected(ITR, True)
                CheckedListBox1.SetItemChecked(ITR, True)
            Next
            'VIEW_REPORT()
        Else
            For ITR = 0 To (CheckedListBox1.Items.Count - 1)
                CheckedListBox1.SetItemChecked(ITR, False)
            Next
        End If
    End Sub


    Public Sub NEW_REPORT1()
        Try
            Dim str, MTYPE(), tspilt(), SITEMCODE, INSERT(0) As String
            Dim i As Integer
            Dim rViewer As New Viewer
            Dim ITEMTABLE As DataTable
            Dim sqlstring, SSQL, itemcode As String

            Dim Clsquantity, Itemcode1, Update(0), Storecode As String
            Dim Boolupdate As Boolean
            Storecode = "" : Clsquantity = "" : i = 0
            Dim SLSTRING, storequery As String
            Dim StoreArr(0) As String
            Dim rate As Double
            'm
            sqlstring = "select DISTINCT itemcode from inventoryitemmaster WHERE freeze<>'Y'"
            gconnection.getDataSet(sqlstring, "inventoryitemmaster")
            ITEMTABLE = gdataset.Tables("inventoryitemmaster")
            If ITEMTABLE.Rows.Count > 0 Then

                For i = 0 To ITEMTABLE.Rows.Count - 1
                    If itemcode = "" Then
                        itemcode = "'" & ITEMTABLE.Rows(i).Item("itemcode").ToString() & "'"
                    Else
                        itemcode = itemcode & "," & "'" & ITEMTABLE.Rows(i).Item("itemcode").ToString() & "'"
                    End If
                Next
                'SLSTRING = SLSTRING & "'" & Itemcode(i) & "', "
            End If
            sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & itemcode & ") "
            gconnection.getDataSet(sqlstring, "ITEMMASTER1")
            sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='Y' WHERE ITEMCODE IN(" & itemcode & ") "
            gconnection.getDataSet(sqlstring, "ITEMMASTER")

            '******RUN SP TO FILL STOCKSUMMARY TABLE 

            sqlstring = "DELETE FROM BAR_STOCKSUMMARY_TEMP "
            gconnection.ExcuteStoreProcedure(sqlstring)

            For i = 0 To (CheckedListBox1.CheckedItems.Count - 1)
                Storecode = CheckedListBox1.CheckedItems(i)

                '******RUN SP TO FILL STOCKSUMMARY TABLE 
                gconnection.openConnection()
                gcommand = New SqlCommand("Cp_StockSummary3", gconnection.Myconn)
                gcommand.CommandTimeout = 1000000000
                gcommand.CommandType = CommandType.StoredProcedure
                gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
                gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_FROMDATE.Value), "dd/MM/yyyy")
                gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_TODATE.Value), "dd/MM/yyyy")
                'gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate(gstartingdate), "dd/MM/yyyy")
                gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
                gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(DTP_TODATE.Value), "yyyy/MM/dd")
                'gcommand.Parameters.Add(New SqlParameter("@rate", SqlDbType.Float)).Value = rate
                gcommand.ExecuteNonQuery()
                gconnection.closeConnection()

                Me.Cursor = Cursors.Default
                '--------------------------------------------------------------------------'
                sqlstring = "INSERT INTO BAR_STOCKSUMMARY_TEMP(ITEMCODE, ITEMNAME, UOM, STORECODE, CLSQTY, CLSVALUE,groupcode)"
                sqlstring = sqlstring & "SELECT ITEMCODE, ITEMNAME, UOM,STORECODE, dispqty, CLSVAL,groupcode FROM STOCKSUMMARY"
                gconnection.ExcuteStoreProcedure(sqlstring)
            Next
            ' End If
            sqlstring = "drop table MONTH_STB_temp"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "create table MONTH_STB_temp ( "
            sqlstring = sqlstring & " Itemcode varchar(50) null,"
            sqlstring = sqlstring & " Itemname varchar(200) null,"
            sqlstring = sqlstring & " TOTAL numeric(18,2) null)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            sqlstring = "insert into month_stb_temp (Itemcode,Itemname) select distinct itemcode, itemname from inventoryitemmaster"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SLSTRING = ""

            sqlstring = "select  storecode,sum(qty) from inv_bar_view2 group by storecode having sum(qty) >0"
            gconnection.getDataSet(sqlstring, "store")
            If gdataset.Tables("store").Rows.Count > 0 Then



                'For i = 0 To (CheckedListBox1.Items.Count - 1)
                For i = 0 To gdataset.Tables("store").Rows.Count - 1
                    Storecode = gdataset.Tables("store").Rows(i).Item("storecode")
                    If SLSTRING = "" Then
                        SLSTRING = Storecode
                        storequery = Storecode & " as st" & i + 1
                    Else
                        SLSTRING = SLSTRING & "," & Storecode
                        If Storecode <> "" Then
                            storequery = storequery & "," & Storecode & " as st" & i + 1
                        End If

                    End If

                    ReDim Preserve StoreArr(StoreArr.Length)
                    StoreArr(StoreArr.Length - 1) = Storecode

                    sqlstring = "alter table MONTH_STB_temp add " & Storecode & " numeric(18,2) null"
                    gconnection.ExcuteStoreProcedure(sqlstring)

                    sqlstring = "UPDATE MONTH_STB_temp SET " & Storecode & " = BAR_STOCKSUMMARY_TEMP.CLSQTY FROM BAR_STOCKSUMMARY_TEMP WHERE STORECODE IN ('" & Storecode & "')  "
                    sqlstring = sqlstring & " AND MONTH_STB_temp.ITEMCODE=BAR_STOCKSUMMARY_TEMP.ITEMCODE "
                    gconnection.ExcuteStoreProcedure(sqlstring)



                    sqlstring = "UPDATE MONTH_STB_temp SET TOTAL = isnull(total,0)  + isnull((SELECT isnull(CLSQTY,0) FROM BAR_STOCKSUMMARY_TEMP a"
                    sqlstring = sqlstring & " where a.Itemcode=MONTH_STB_temp.Itemcode and a.storecode='" & Storecode & "'),0)"
                    gconnection.ExcuteStoreProcedure(sqlstring)

                Next
            End If
            sqlstring = "SELECT ITEMCODE, ITEMNAME," & storequery & ", TOTAL"
            sqlstring = sqlstring & " FROM MONTH_STB_temp order by itemcode"
            ' sqlstring = sqlstring & " BOM_DET B WHERE F.ITEMCODE=B.GITEMCODE  AND F.ITEMNAME=B.GITEMNAME GROUP BY  F.ITEMCODE, F.ITEMNAME , B.gqty, MNS1,AMSB, BVI"
            gconnection.getDataSet(sqlstring, "MONTH_STB_temp")
            'gconnection.getDataSet(sqlstring, "STOCKSUMMARY")
            Dim r1 As New Cry_monthstbbar
            If gdataset.Tables("MONTH_STB_temp").Rows.Count > 0 Then

                rViewer.ssql = sqlstring
                rViewer.Report = r1
                rViewer.TableName = "MONTH_STB_temp"
                Dim textobj1 As TextObject
                textobj1 = r1.ReportDefinition.ReportObjects("Text9")
                textobj1.Text = MyCompanyName

                Dim textobj4 As TextObject
                textobj4 = r1.ReportDefinition.ReportObjects("Text14")
                textobj4.Text = gUsername

                Dim textobj6 As TextObject
                textobj6 = r1.ReportDefinition.ReportObjects("Text8")
                textobj6.Text = gCompanyAddress(0)

                Dim textobj7 As TextObject
                textobj7 = r1.ReportDefinition.ReportObjects("Text10")
                textobj7.Text = gCompanyAddress(1)

                Dim t2 As TextObject
                t2 = r1.ReportDefinition.ReportObjects("Text16")
                t2.Text = Format(DTP_FROMDATE.Value, "dd/MM/yyyy")
                Dim t1 As TextObject
                t1 = r1.ReportDefinition.ReportObjects("Text18")
                t1.Text = Format(DTP_TODATE.Value, "dd/MM/yyyy")

                For i = 1 To StoreArr.Length - 1
                    t1 = r1.ReportDefinition.ReportObjects("t" & i)
                    t1.Text = StoreArr(i)
                Next
                rViewer.Show()
                'Dim exp As New exportexcel
                'exp.Show()
                'Call exp.export(sqlstring, "MONTHLY STB OF BAR             " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")
                'Dim exp As New exportexcel
                'exp.Show()
                'Call exp.export(sqlstring, "MONTHLY STB OF ITEMS             " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")
            Else
                MessageBox.Show("NO RECORDS TO DISPLAY")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("PLZ CHECK ERROR :", ex.Message)
        End Try
    End Sub

    Public Sub FILLGRID_STORE()
        sqlstring = "SELECT STORECODE FROM STOREMASTER ORDER BY Storecode "
        gconnection.getDataSet(sqlstring, "STOREMASTER")
        D1 = gdataset.Tables("STOREMASTER")
        If D1.Rows.Count > 0 Then
            For i = 0 To (D1.Rows.Count - 1)
                CheckedListBox1.Items.Add(D1.Rows(i).Item("STORECODE"))
            Next
        End If
    End Sub
End Class
