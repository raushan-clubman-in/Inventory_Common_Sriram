Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class bar_raterevision
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
    Friend WithEvents CHK_EXC As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_History As System.Windows.Forms.CheckBox
    Friend WithEvents chk_CRV As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_profit As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_DETAILED_HISTORY As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_export As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
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
        Me.CHK_EXC = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CHK_DETAILED_HISTORY = New System.Windows.Forms.CheckBox()
        Me.chk_profit = New System.Windows.Forms.CheckBox()
        Me.chk_History = New System.Windows.Forms.CheckBox()
        Me.chk_CRV = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ssg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(266, 109)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(244, 27)
        Me.lbl_Heading.TabIndex = 8
        Me.lbl_Heading.Text = "BAR RATE REVISION"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.Black
        Me.Cmd_View.Image = Global.Inventory.My.Resources.Resources.view
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(4, 110)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(192, 86)
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(1, 307)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(192, 86)
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(4, 15)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(192, 86)
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
        Me.cmd_export.Location = New System.Drawing.Point(1, 215)
        Me.cmd_export.Name = "cmd_export"
        Me.cmd_export.Size = New System.Drawing.Size(192, 86)
        Me.cmd_export.TabIndex = 8
        Me.cmd_export.Text = "Export"
        Me.cmd_export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_export.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.DTP_TODATE)
        Me.GroupBox1.Controls.Add(Me.DTP_FROMDATE)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(376, 198)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(731, 132)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'DTP_TODATE
        '
        Me.DTP_TODATE.CustomFormat = "dd/MMM/yyyy"
        Me.DTP_TODATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_TODATE.Location = New System.Drawing.Point(499, 37)
        Me.DTP_TODATE.Name = "DTP_TODATE"
        Me.DTP_TODATE.Size = New System.Drawing.Size(207, 30)
        Me.DTP_TODATE.TabIndex = 19
        '
        'DTP_FROMDATE
        '
        Me.DTP_FROMDATE.CustomFormat = "dd/MMM/yyyy"
        Me.DTP_FROMDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_FROMDATE.Location = New System.Drawing.Point(157, 34)
        Me.DTP_FROMDATE.Name = "DTP_FROMDATE"
        Me.DTP_FROMDATE.Size = New System.Drawing.Size(227, 30)
        Me.DTP_FROMDATE.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(393, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 21)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "TO DATE:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 21)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "FROM DATE:"
        '
        'ssg
        '
        Me.ssg.DataSource = Nothing
        Me.ssg.Location = New System.Drawing.Point(168, 192)
        Me.ssg.Name = "ssg"
        Me.ssg.Size = New System.Drawing.Size(616, 160)
        Me.ssg.TabIndex = 2
        '
        'chk_excel
        '
        Me.chk_excel.AutoSize = True
        Me.chk_excel.Location = New System.Drawing.Point(900, 952)
        Me.chk_excel.Name = "chk_excel"
        Me.chk_excel.Size = New System.Drawing.Size(149, 29)
        Me.chk_excel.TabIndex = 18
        Me.chk_excel.Text = "CheckBox1"
        Me.chk_excel.UseVisualStyleBackColor = True
        Me.chk_excel.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.CHK_EXC)
        Me.GroupBox3.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox3.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox3.Controls.Add(Me.cmd_export)
        Me.GroupBox3.Controls.Add(Me.Cmd_View)
        Me.GroupBox3.Location = New System.Drawing.Point(1223, 153)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 416)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        '
        'CHK_EXC
        '
        Me.CHK_EXC.AutoSize = True
        Me.CHK_EXC.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_EXC.Location = New System.Drawing.Point(20, 222)
        Me.CHK_EXC.Name = "CHK_EXC"
        Me.CHK_EXC.Size = New System.Drawing.Size(101, 28)
        Me.CHK_EXC.TabIndex = 9
        Me.CHK_EXC.Text = "EXCEL"
        Me.CHK_EXC.UseVisualStyleBackColor = True
        Me.CHK_EXC.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.CHK_DETAILED_HISTORY)
        Me.GroupBox2.Controls.Add(Me.chk_profit)
        Me.GroupBox2.Controls.Add(Me.chk_History)
        Me.GroupBox2.Controls.Add(Me.chk_CRV)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(513, 360)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(374, 209)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "REPORT TYPE"
        '
        'CHK_DETAILED_HISTORY
        '
        Me.CHK_DETAILED_HISTORY.AutoSize = True
        Me.CHK_DETAILED_HISTORY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.CHK_DETAILED_HISTORY.Location = New System.Drawing.Point(31, 155)
        Me.CHK_DETAILED_HISTORY.Name = "CHK_DETAILED_HISTORY"
        Me.CHK_DETAILED_HISTORY.Size = New System.Drawing.Size(210, 25)
        Me.CHK_DETAILED_HISTORY.TabIndex = 3
        Me.CHK_DETAILED_HISTORY.Text = "DETAILED HISTORY"
        Me.CHK_DETAILED_HISTORY.UseVisualStyleBackColor = True
        '
        'chk_profit
        '
        Me.chk_profit.AutoSize = True
        Me.chk_profit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chk_profit.Location = New System.Drawing.Point(31, 113)
        Me.chk_profit.Name = "chk_profit"
        Me.chk_profit.Size = New System.Drawing.Size(166, 25)
        Me.chk_profit.TabIndex = 2
        Me.chk_profit.Text = "PROFIT / LOSS"
        Me.chk_profit.UseVisualStyleBackColor = True
        '
        'chk_History
        '
        Me.chk_History.AutoSize = True
        Me.chk_History.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chk_History.Location = New System.Drawing.Point(31, 71)
        Me.chk_History.Name = "chk_History"
        Me.chk_History.Size = New System.Drawing.Size(116, 25)
        Me.chk_History.TabIndex = 1
        Me.chk_History.Text = "HISTORY"
        Me.chk_History.UseVisualStyleBackColor = True
        '
        'chk_CRV
        '
        Me.chk_CRV.AutoSize = True
        Me.chk_CRV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chk_CRV.Location = New System.Drawing.Point(31, 28)
        Me.chk_CRV.Name = "chk_CRV"
        Me.chk_CRV.Size = New System.Drawing.Size(75, 25)
        Me.chk_CRV.TabIndex = 0
        Me.chk_CRV.Text = "CRV"
        Me.chk_CRV.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(-21, -23)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(142, 35)
        Me.ProgressBar1.TabIndex = 22
        Me.ProgressBar1.Visible = False
        '
        'Timer1
        '
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(14, 21)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(813, 54)
        Me.ProgressBar2.TabIndex = 23
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.ProgressBar2)
        Me.GroupBox4.Location = New System.Drawing.Point(323, 635)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(843, 87)
        Me.GroupBox4.TabIndex = 24
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Visible = False
        '
        'bar_raterevision
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 23)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.NavajoWhite
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1528, 724)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chk_excel)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "bar_raterevision"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "BAR RATE REVISION"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ssg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim STORECODE As String
    Dim gconnection As New GlobalClass
    Dim grnno As Integer
    Dim pagesize, pageno As Integer
    Dim dr As DataRow
    Dim adddate As DateTime
    Dim QTY, QTY1, QTY2, QTY3, VNO, QTY4 As Double
    Dim vrno As Double
    Dim i, J As Integer
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

        '     ssgrid.Width = Convert.ToInt32((Screen.PrimaryScreen.WorkingArea.Width * 60) / 100)

        'txt_GroupCode.Enabled = True
        'txt_GroupCode.ReadOnly = False
        'txt_GroupDesc.ReadOnly = False
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        SubGroupMasterbool = True
        ' getucategory()
        'getuflag()
        fillgrid()
        autogenerate1()
        FILLGRID_STORE()
        DTP_FROMDATE.Value = Format(CDate("26/03/" & gFinancalyearStart), "dd/MMM/yyyy")
        ' DTP_FROMDATE.Value = Format(Now, "dd/MMM/yyyy")
        DTP_TODATE.Value = Format(Now, "dd/MMM/yyyy")

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
        ' Me.Cmd_Add.Enabled = False
        'Me.Cmd_Freeze.Enabled = False
        Me.Cmd_View.Enabled = False
        'Me.cmd_auth.Enabled = False
        ' Me.cmd_rpt.Enabled = False
        Me.cmd_export.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    'Me.Cmd_Add.Enabled = True
                    ' Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    ' Me.cmd_auth.Enabled = True
                    ' Me.cmd_rpt.Enabled = True
                    Me.cmd_export.Enabled = True
                    Exit Sub
                End If
                'If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                '    If Right(x) = "S" Then
                '        Me.Cmd_Add.Enabled = True
                '    End If
                'Else
                '    If Right(x) = "M" Then
                '        Me.Cmd_Add.Enabled = True
                '    End If
                'End If
                If Right(x) = "D" Then
                    'Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                    'Me.cmd_rpt.Enabled = True
                    Me.cmd_export.Enabled = True
                End If
                If Right(x) = "U" Then
                    'Me.cmd_auth.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)

        'Me.Cmd_Freeze.Text = "Freeze[F8]"
        'Cmd_Add.Text = "Add [F7]"
        'Cmd_Freeze.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If

        'DTP_FROMDATE.Value = Date.Now()
        DTP_FROMDATE.Value = Format(CDate("26/03/" & gFinancalyearStart), "dd/MMM/yyyy")
        DTP_TODATE.Value = Date.Now()
        fillgrid()
        autogenerate1()

    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        If chk_CRV.Checked = False Then
            If CHK_DETAILED_HISTORY.Checked = False Then
                If chk_History.Checked = False Then
                    If chk_profit.Checked = False Then
                        MessageBox.Show("Please select any of the report type")
                        Exit Sub
                    End If
                End If
            End If
        End If

        Checkdaterangevalidate(Format(DTP_FROMDATE.Value, "dd/MMM/yyyy"), Format(DTP_TODATE.Value, "dd/MMM/yyyy"))
        If chkdatevalidate = False Then Exit Sub
        gPrint = False
        GroupBox4.Visible = True
        'GroupBox4.Top = 602
        'GroupBox4.Left = 241
        Me.ProgressBar2.Value = 2
        Me.Timer1.Interval = 10
        Me.Timer1.Enabled = True
    End Sub


    '

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub cmdGroupCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_GroupCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'If Asc(e.KeyChar) = 13 Then
        '    If Trim(txt_GroupCode.Text) = "" Then
        '        Call cmdGroupCode_Click(cmdGroupCode, e)
        '    Else
        '        Me.txt_GroupCode_Validated(txt_GroupCode, e)
        '    End If
        'End If
    End Sub

    Private Sub txt_GroupDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'If Asc(e.KeyChar) = 13 Then
        '    ssgrid.Focus()
        '    ssgrid.SetActiveCell(1, 1)
        'End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        ' '''********** Check  Store Code Can't be blank *********************'''
        'If Trim(cmb_rationtype.Text) = "" Then
        '    MessageBox.Show(" Ration Type can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cmb_rationtype.Focus()
        '    Exit Sub
        'End If
        'If Trim(TXT_DAYS.Text) = "" Then
        '    MessageBox.Show(" No. of days can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    TXT_DAYS.Focus()
        '    Exit Sub
        'End If
        'If Trim(TXT_EGGVEG.Text) = "" Then
        '    MessageBox.Show(" No. of person for Egg Veg can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    TXT_DAYS.Focus()
        '    Exit Sub
        'End If
        'If Trim(TXT_NONVEG.Text) = "" Then
        '    MessageBox.Show(" No. of person for Non Veg can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    TXT_DAYS.Focus()
        '    Exit Sub
        'End If
        'If Trim(TXT_PUREVEG.Text) = "" Then
        '    MessageBox.Show(" No. of person for Pure Veg can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    TXT_DAYS.Focus()
        '    Exit Sub
        'End If
        'If Trim(TXT_DOCNO.Text) = "" Then
        '    MessageBox.Show(" Docno can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    TXT_DOCNO.Focus()
        '    Exit Sub
        'End If
        ''' ********** Check SubgroupCode and Subgroupdesc can't be blank ***********'''

        boolchk = True
    End Sub


    Private Sub Sub_Group_Master_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            'If Cmd_Freeze.Enabled = True Then
            '    Call Cmd_Freeze_Click(Cmd_Freeze, e)
            '    Exit Sub
            'End If
        End If
        'If e.KeyCode = Keys.F7 And Cmd_Add.Enabled = True Then
        '    Call Cmd_Add_Click(Cmd_Add, e)
        '    Exit Sub
        'End If
        If e.KeyCode = Keys.F9 And Cmd_View.Enabled = True Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        End If
        'If e.KeyCode = Keys.F10 And cmd_auth.Enabled = True Then
        '    Call cmd_auth_Click(cmd_auth, e)
        '    Exit Sub
        'End If
        If e.KeyCode = Keys.F4 Then
            'Call cmdGroupCode_Click(cmdGroupCode, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub

    Private Sub txt_GroupCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.F4 Then
        '    If cmdGroupCode.Enabled = True Then
        '        search = Trim(txt_GroupCode.Text)
        '        Call cmdGroupCode_Click(cmdGroupCode, e)
        '    End If
        'End If
    End Sub

    Private Sub Sub_Group_Master_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        SubGroupMasterbool = False
    End Sub


    Private Sub ssgrid_KeyDownEvent1(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssg.KeyDownEvent
        If e.keyCode = Keys.F3 Then

        End If
    End Sub

    Private Sub ssgrid_KeyPressEvent1(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyPressEvent) Handles ssg.KeyPressEvent

    End Sub



    Private Sub txt_GroupCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txt_GroupDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ssgrid_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssg.Advance

    End Sub

    Private Sub cmd_export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_export.Click
       

        If chk_History.Checked = True Then
            '******* EXECUTE PROCEDURE 
            gconnection.openConnection()
            gcommand = New SqlCommand("[UPDATE_barRATE]", gconnection.Myconn)
            gcommand.CommandTimeout = 1000000000
            gcommand.CommandType = CommandType.StoredProcedure
            gcommand.ExecuteNonQuery()
            gconnection.closeConnection()

            Dim exp As New exportexcel
            exp.Show()
            'sqlstring = "SELECT * FROM INV_BAR_FINAL_TAB WHERE DOCDATE BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "'"
            sqlstring = "SELECT * FROM INV_BAR_FINAL_TAB "
            sqlstring = sqlstring & " WHERE DOCDATE BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' "
            sqlstring = sqlstring & "order by itemcode, docdate "

            Call exp.export(sqlstring, " RATE REVISION " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")

        ElseIf chk_CRV.Checked = True Then
            '******* EXECUTE PROCEDURE 
            gconnection.openConnection()
            gcommand = New SqlCommand("[UPDATE_barRATE]", gconnection.Myconn)
            gcommand.CommandTimeout = 1000000000
            gcommand.CommandType = CommandType.StoredProcedure
            gcommand.ExecuteNonQuery()
            gconnection.closeConnection()

            Dim exp As New exportexcel
            exp.Show()
            'sqlstring = "SELECT * FROM INV_BAR_FINAL_TAB WHERE DOCDATE BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "'"
            sqlstring = "SELECT * FROM INV_BAR_FINAL_TAB "
            sqlstring = sqlstring & " WHERE DOCDATE BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' AND TYPE='GRN' "
            sqlstring = sqlstring & "order by itemcode, docdate "

            Call exp.export(sqlstring, " RATE REVISION " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")

        ElseIf CHK_DETAILED_HISTORY.Checked = True Then
            '******* EXECUTE PROCEDURE 
            gconnection.openConnection()
            gcommand = New SqlCommand("[UPDATE_barRATE_detailed]", gconnection.Myconn)
            gcommand.CommandTimeout = 1000000000
            gcommand.CommandType = CommandType.StoredProcedure
            gcommand.ExecuteNonQuery()
            gconnection.closeConnection()

            Dim exp As New exportexcel
            exp.Show()
            'sqlstring = "SELECT * FROM INV_BAR_FINAL_TAB WHERE DOCDATE BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "'"
            sqlstring = "SELECT * FROM INV_BAR_FINAL_TAB_DETAILED "
            sqlstring = sqlstring & " WHERE DOCDATE BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' "
            sqlstring = sqlstring & " ORDER BY ITEMCODE,DOCDATE , PRIORITY "

            Call exp.export(sqlstring, " RATE REVISION " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")

        End If

    End Sub

    Private Sub btn_validation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start(AppPath & "/STUDY/SUBGROUPMASTER.XLS")
    End Sub

    Private Sub cmd_rpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gPrint = False

    End Sub

    Private Sub cmd_auth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim SSQLSTR, SSQLSTR2 As String
        Dim USERT As Integer
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 1
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 2
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 3
        End If
        If USERT = 1 Then
            SSQLSTR2 = " SELECT * FROM inventorysubgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM inventorysubgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE inventorysubgroupmaster set  ", "groupcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM inventorysubgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM inventorysubgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE inventorysubgroupmaster set  ", "groupcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM inventorysubgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM inventorysubgroupmaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE inventorysubgroupmaster set  ", "groupcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub



    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent)

    End Sub

    Private Sub fillgrid()

    End Sub

    Private Sub cmb_rationtype_KeyDown(sender As Object, e As KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    If cmb_rationtype.Text = "" Then
        '        cmb_rationtype.Focus()
        '        fillgrid1()
        '    Else
        '        TXT_DAYS.Focus()
        '        fillgrid1()
        '    End If
        'End If
    End Sub

    Private Sub cmb_rationtype_Validated(sender As Object, e As EventArgs)
    End Sub

    Private Sub TXT_DAYS_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            'If TXT_DAYS.Text = "" Then
            '    TXT_DAYS.Focus()
            'Else
            '    TXT_PUREVEG.Focus()
            'End If
        End If
    End Sub
    Private Sub fillgrid1()
        sqlstring = "select itemcode,itemname,Quantity,Totalday,UOM from RationMaster"
        gconnection.getDataSet(sqlstring, "RationMaster")
        If gdataset.Tables("RationMaster").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("RationMaster").Rows.Count - 1

                'TXT_DAYS.Text = gdataset.Tables("RationMaster").Rows(0).Item("totalday")
                'I = I + 1
            Next
        End If
    End Sub

    Private Sub cmdGroupCode_Click_1(sender As Object, e As EventArgs)

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

    Private Sub TXT_PUREVEG_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub TXT_NONVEG_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub TXT_EGGVEG_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            'If TXT_EGGVEG.Text <> "" Then
            '    EGGVEGCALC()
            '    TXT_SERVANT.Enabled = False
            '    '***check pureveg and nonveg
            '    If TXT_PUREVEG.Text = "" Then
            '        MessageBox.Show("Pure Veg can't be blank")
            '        TXT_PUREVEG.Focus()
            '    ElseIf TXT_NONVEG.Text = "" Then
            '        MessageBox.Show("Non Veg can't be blank")
            '        TXT_NONVEG.Focus()
            '    Else
            '        Cmd_Add.Focus()
            '    End If

            '    'If TXT_EGGVEG.Text = "" Then
            '    '    TXT_PUREVEG.Text = ""
            '    '    TXT_NONVEG.Text = ""
            '    '    TXT_SERVANT.Enabled = True
            '    'Else
            '    '    TXT_SERVANT.Enabled = False
            '    'End If
            'Else
            '    TXT_SERVANT.Focus()
            '    EGGVEGCALC()
            'End If

        End If
    End Sub

    Private Sub autogenerate1()
        'Dim sqlstring, financalyear As String

        'Try
        '    financalyear = Mid(gFinancalyearStart, 1, 4) & "-" & Mid(gFinancialyearEnd, 1, 4)
        '    sqlstring = "SELECT MAX(cast(ISNULL(SUBSTRING(VNO,1,6),'0') as numeric)) AS VNO FROM RATIONCALCULATION"
        '    gconnection.getDataSet(sqlstring, "RATIONCALCULATION")
        '    If gdataset.Tables("RATIONCALCULATION").Rows(0).IsNull("VNO") = True Then
        '        TXT_DOCNO.Text = "RC\000001\" & financalyear
        '        VNO = "000001"
        '    Else
        '        If gdataset.Tables("RATIONCALCULATION").Rows.Count > 0 Then
        '            TXT_DOCNO.Text = "RC\" & Format(Val(gdataset.Tables("RATIONCALCULATION").Rows(0).Item("VNO")) + 1, "000000") & "\" & financalyear
        '            VNO = Format(Val(gdataset.Tables("RATIONCALCULATION").Rows(0).Item("VNO")) + 1, "000000")
        '        Else
        '            TXT_DOCNO.Text = "RC\000001\" & financalyear
        '            VNO = "000001"
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End Try
    End Sub

    Private Sub cmdGroupCode_Click_2(sender As Object, e As EventArgs)
        'gSQLString = "SELECT Distinct DOCNO FROM RationCALCULATION "
        'M_WhereCondition = " WHERE freeze='N' "
        'Dim vform As New ListOperattion1
        'vform.Field = "DOCNO"
        'vform.vFormatstring = "   Ration Calculation      "
        'vform.vCaption = "RATION CALCULATION HELP"
        'vform.KeyPos = 0
        ''vform.KeyPos1 = 1
        'vform.ShowDialog(Me)
        'If Trim(vform.keyfield & "") <> "" Then
        '    TXT_DOCNO.Text = Trim(vform.keyfield & "")
        '    'Call txt_GroupCode_Validated(TXT_DOCNO, e)
        'End If
        'vform.Close()
        'vform = Nothing
    End Sub

    Private Sub TXT_SERVANT_KeyDown(sender As Object, e As KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    Cmd_Add.Focus()
        '    SERVANTCALC()
        '    'If TXT_SERVANT.Text <> "0.0" Then
        '    '    TXT_EGGVEG.Text = 0.0
        '    '    TXT_NONVEG.Text = 0.0
        '    '    TXT_PUREVEG.Text = 0.0
        '    '    TXT_EGGVEG.Enabled = False
        '    '    TXT_PUREVEG.Enabled = False
        '    '    TXT_NONVEG.Enabled = False
        '    'End If

        'End If
    End Sub
    '**********CALCULATION OF SERVANT RATION
    Public Sub SERVANTCALC()
        'If Val(TXT_PUREVEG.Text) = 0.0 Then
        '    ssgrid.ClearRange(1, 1, -1, -1, True)
        'End If
        'If Val(TXT_NONVEG.Text) = 0.0 Then
        '    ssgrid.ClearRange(1, 1, -1, -1, True)
        'End If
        'If Val(TXT_EGGVEG.Text) = 0.0 Then
        '    ssgrid.ClearRange(1, 1, -1, -1, True)
        'End If
        sqlstring = "select itemcode,itemname,Quantity,Totalday,UOM,ISNULL(PURCHASERATE,0) AS PURCHASERATE from RationMaster WHERE RATIONTYPE='SERVANT'"
        gconnection.getDataSet(sqlstring, "RationMaster")
        If gdataset.Tables("RationMaster").Rows.Count > 0 Then


        End If
    End Sub
    Public Sub FILLGRID_STORE()

        ''sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE CATEGORY IN (" & USER & ")"
        ''gconnection.getDataSet(sqlstring, "STOREMASTER")
        ''D1 = gdataset.Tables("STOREMASTER")
        ''If D1.Rows.Count > 0 Then
        ''    For i = 0 To (D1.Rows.Count - 1)
        ''        ComboBox1.Items.Add(D1.Rows(i).Item("STORECODE"))
        ''    Next
        ''End If
        'sqlstring = "SELECT STORECODE FROM STOREMASTER WHERE CATEGORY IN (" & USER & ") AND STORESTATUS='M'"
        'gconnection.getDataSet(sqlstring, "STOREMASTER")
        'D1 = gdataset.Tables("STOREMASTER")
        'If D1.Rows.Count > 0 Then
        '    For i = 0 To (D1.Rows.Count - 1)
        '        CMB_STORECODE.Items.Add(D1.Rows(i).Item("STORECODE"))
        '    Next
        'End If
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs)
        'Dim ITR As Integer
        'If CheckBox1.Checked = True Then
        '    For ITR = 0 To (CheckedListBox1.Items.Count - 1)
        '        CheckedListBox1.SetSelected(ITR, True)
        '        CheckedListBox1.SetItemChecked(ITR, True)
        '    Next
        '    'VIEW_REPORT()
        'Else
        '    For ITR = 0 To (CheckedListBox1.Items.Count - 1)
        '        CheckedListBox1.SetItemChecked(ITR, False)
        '    Next
        'End If
    End Sub

    Public Sub VIEW_REPORT()
        'Try
        '    Dim str, MTYPE(), tspilt(), SITEMCODE As String
        '    Dim i As Integer
        '    Dim rViewer As New Viewer
        '    'Dim r As New Rpt_SUMMARYKGA
        '    'Dim r1 As New Rpt_stk_summaryCATH
        '    Dim Heading(0) As String
        '    Dim sqlstring, SSQL As String

        '    Dim Clsquantity, Itemcode(), Itemcode1, Update(0), Storecode As String
        '    Dim Boolupdate As Boolean
        '    Storecode = "" : Clsquantity = "" : i = 0
        '    Dim SLSTRING As String
        '    Dim rate As Double


        '    '---------------------- EXECUTE STORE PROCEDURE --------------------------'
        '    '****RUN SP FOR CREATION OF TABLE*******
        '    gconnection.openConnection()

        '    gcommand = New SqlCommand("monthly_stb_table", gconnection.Myconn)
        '    gcommand.CommandTimeout = 1000000000
        '    gcommand.CommandType = CommandType.StoredProcedure
        '    gcommand.ExecuteNonQuery()
        '    gconnection.closeConnection()
        '    gconnection.openConnection()

        '    gcommand = New SqlCommand("monthly_stb_table1", gconnection.Myconn)
        '    gcommand.CommandTimeout = 1000000000
        '    gcommand.CommandType = CommandType.StoredProcedure
        '    gcommand.ExecuteNonQuery()
        '    gconnection.closeConnection()

        '    '******RUN SP TO FILL STOCKSUMMARY TABLE 
        '    If CheckBox1.Checked = True Then

        '        For i = 0 To (CheckedListBox1.CheckedItems.Count - 1)
        '            Storecode = CheckedListBox1.CheckedItems(i)

        '            '******RUN SP TO FILL STOCKSUMMARY TABLE 
        '            gconnection.openConnection()
        '            gcommand = New SqlCommand("Cp_StockSummary3", gconnection.Myconn)
        '            gcommand.CommandTimeout = 1000000000
        '            gcommand.CommandType = CommandType.StoredProcedure
        '            gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
        '            gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_FROMDATE.Value), "dd/MM/yyyy")
        '            gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_TODATE.Value), "dd/MM/yyyy")
        '            'gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate(gstartingdate), "dd/MM/yyyy")
        '            gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("01/04/" & gFinancalyearStart), "dd/MM/yyyy")
        '            gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(DTP_TODATE.Value), "yyyy/MM/dd")
        '            'gcommand.Parameters.Add(New SqlParameter("@rate", SqlDbType.Float)).Value = rate
        '            gcommand.ExecuteNonQuery()
        '            gconnection.closeConnection()

        '            '******RUN SP TO FILL MONTH_STB TABLE
        '            gconnection.openConnection()
        '            gcommand = New SqlCommand("PROC_MONTH_STB", gconnection.Myconn)
        '            gcommand.CommandTimeout = 1000000000
        '            gcommand.CommandType = CommandType.StoredProcedure
        '            gcommand.Parameters.Add(New SqlParameter("@SCODE2", SqlDbType.VarChar)).Value = Storecode
        '            gcommand.ExecuteNonQuery()
        '            gconnection.closeConnection()

        '            Me.Cursor = Cursors.Default
        '            '--------------------------------------------------------------------------'
        '        Next
        '    End If

        '    '******RUN SP TO DROP COLUMN
        '    gconnection.openConnection()
        '    gcommand = New SqlCommand("MONTH_DROP_COLUMN", gconnection.Myconn)
        '    gcommand.CommandTimeout = 1000000000
        '    gcommand.CommandType = CommandType.StoredProcedure
        '    'gcommand.Parameters.Add(New SqlParameter("@SCODE2", SqlDbType.VarChar)).Value = Storecode
        '    gcommand.ExecuteNonQuery()
        '    gconnection.closeConnection()



        '    '*****EXPORT TO EXCEL
        '    sqlstring = "SELECT * FROM MONTH_STB M, MONTH_STB1 N WHERE M.ITEMDESC=N.ITEMDESC"
        '    gconnection.getDataSet(sqlstring, "MONTH_STB")

        '    Dim exp As New exportexcel
        '    exp.Show()
        '    Call exp.export(sqlstring, "MONTHLY STB OF ITEMS             " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")
        '    'GRID_FILL()
        'Catch ex As Exception
        '    'MsgBox("Please Try Again")
        '    ' Call StkSummary_crystal()
        'End Try
    End Sub

    Public Sub GRID_FILL()
        Dim STORECODE As String
        Dim DT As New DataTable
       
    End Sub

    'm
    Private Sub ViewsummaryKGA()
        'Try
        '    Dim str, MTYPE(), tspilt(), SITEMCODE As String
        '    Dim i As Integer
        '    Dim rViewer As New Viewer
        '    'Dim r As New Rpt_SUMMARYKGA
        '    Dim r1 As New Cry_STOCKREVISION
        '    Dim Heading(0) As String
        '    Dim sqlstring, SSQL As String

        '    Dim Clsquantity, Itemcode1, Update(0), Storecode As String
        '    Dim Boolupdate As Boolean
        '    Storecode = "" : Clsquantity = "" : i = 0
        '    Dim SLSTRING As String
        '    Dim rate As Double
        '    Dim itemtable As DataTable
        '    Dim itemcode As String
        '    'm
        '    'Dim SLSTRING As String
        '    sqlstring = "select DISTINCT itemcode from inventoryitemmaster WHERE storecode='" & CMB_STORECODE.Text & "' and freeze<>'Y'"
        '    gconnection.getDataSet(sqlstring, "inventoryitemmaster")
        '    ITEMTABLE = gdataset.Tables("inventoryitemmaster")
        '    If ITEMTABLE.Rows.Count > 0 Then

        '        For i = 0 To ITEMTABLE.Rows.Count - 1
        '            If Itemcode = "" Then
        '                Itemcode = "'" & ITEMTABLE.Rows(i).Item("itemcode").ToString() & "'"
        '            Else
        '                Itemcode = Itemcode & "," & "'" & ITEMTABLE.Rows(i).Item("itemcode").ToString() & "'"
        '            End If


        '        Next
        '        'SLSTRING = SLSTRING & "'" & Itemcode(i) & "', "
        '    End If
        '    sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & Itemcode & ")  AND CATEGORY IN(" & USER & ")"
        '    gconnection.getDataSet(sqlstring, "ITEMMASTER1")
        '    sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='Y' WHERE ITEMCODE IN(" & Itemcode & ") AND CATEGORY IN(" & USER & ")"
        '    gconnection.getDataSet(sqlstring, "ITEMMASTER")


        '    Storecode = CMB_STORECODE.Text
        '    '---------------------- EXECUTE STORE PROCEDURE --------------------------'
        '    gconnection.openConnection()


        '    gcommand = New SqlCommand("Cp_StockSummary3", gconnection.Myconn)
        '    gcommand.CommandTimeout = 1000000000
        '    gcommand.CommandType = CommandType.StoredProcedure
        '    gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
        '    gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_FROMDATE.Value), "dd/MM/yyyy")
        '    gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_TODATE.Value), "dd/MM/yyyy")
        '    'gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate(gstartingdate), "dd/MM/yyyy")
        '    gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("26/03/" & gFinancalyearStart), "dd/MM/yyyy")
        '    gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(DTP_TODATE.Value), "yyyy/MM/dd")
        '    'gcommand.Parameters.Add(New SqlParameter("@rate", SqlDbType.Float)).Value = rate
        '    gcommand.ExecuteNonQuery()
        '    gconnection.closeConnection()

        '    Me.Cursor = Cursors.Default
        '    '--------------------------------------------------------------------------'
        '    Dim ICODE, INAME, UOM As String
        '    Dim CLSQTY, OLDRATE, NEWRATE As String
        '    Dim Z As Integer
        '    Dim ID As DataTable
        '    Dim Insert(0), grndt1 As String
        '    Dim grndt As Date
        '    sqlstring = "SELECT ITEMCODE, ITEMNAME, UOM, CLSQTY FROM STOCKSUMMARY ORDER BY ITEMCODE"
        '    gconnection.getDataSet(sqlstring, "STOCKSUMMARY")
        '    ID = gdataset.Tables("STOCKSUMMARY")
        '    sqlstring = "DELETE FROM BAR_RATEMASTER"
        '    ReDim Preserve Insert(Insert.Length)
        '    Insert(Insert.Length - 1) = sqlstring
        '    If ID.Rows.Count > 0 Then
        '        For Z = 0 To ID.Rows.Count - 1
        '            ICODE = "'" & ID.Rows(Z).Item("itemcode").ToString() & "'"
        '            INAME = "'" & ID.Rows(Z).Item("itemNAME").ToString() & "'"
        '            UOM = "'" & ID.Rows(Z).Item("UOM").ToString() & "'"
        '            CLSQTY = "'" & ID.Rows(Z).Item("CLSQTY").ToString() & "'"
        '            sqlstring = ""

        '            ' sqlstring = "SELECT ISNULL(RATE,0) AS RATE FROM GRN_DETAILS WHERE Grndate between '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "'  and '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' AND Itemcode=" & ICODE & ""
        '            sqlstring = "SELECT ISNULL(RATE,0) AS RATE FROM GRN_DETAILS WHERE CAST(CONVERT(VARCHAR,grndate,106)AS DATETIME)<= '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "'  AND Itemcode=" & ICODE & ""
        '            gconnection.getDataSet(sqlstring, "GRN_DETAILS")
        '            If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
        '                OLDRATE = gdataset.Tables("GRN_dETAILS").Rows(0).Item("RATE")

        '            Else
        '                '' OLDRATE = "0.00"
        '                sqlstring = "SELECT (isnull(opvalue,0)/isnull(opstock,0)) AS PURCHASERATE FROM INVENTORYITEMMASTER WHERE Itemcode=" & ICODE & " and opstock<>0 and opvalue<>0 "
        '                gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        '                If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
        '                    OLDRATE = gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("PURCHASERATE")
        '                    ' End If
        '                Else
        '                    sqlstring = "SELECT isnull(PURCHASERATE,0) AS PURCHASERATE FROM INVENTORYITEMMASTER WHERE Itemcode=" & ICODE & " and opstock<>0 and opvalue<>0 "
        '                    gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        '                    If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
        '                        OLDRATE = gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("PURCHASERATE")
        '                    End If
        '                End If

        '            End If
        '            '*********select max grndate for new rate***************
        '            sqlstring = "select isnull(MAX(Grndate),'') as GRNDATE  from GRN_DETAILS where Grndate<='" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' and Itemcode=" & ICODE & ""
        '            gconnection.getDataSet(sqlstring, "GRN_dETAILS2")
        '            If gdataset.Tables("GRN_dETAILS2").Rows.Count > 0 Then
        '                grndt1 = Format(gdataset.Tables("GRN_dETAILS2").Rows(0).Item("GRNDATE"), "dd-MMM-yyyy")
        '            End If
        '            sqlstring = "SELECT ISNULL(Rate,0) AS RATE FROM GRN_DETAILS WHERE Grndate = '" & grndt1 & "' AND Itemcode=" & ICODE & ""
        '            gconnection.getDataSet(sqlstring, "GRN_dETAILS1")
        '            If gdataset.Tables("GRN_DETAILS1").Rows.Count > 0 Then
        '                NEWRATE = gdataset.Tables("GRN_DETAILS1").Rows(0).Item("RATE")
        '                If NEWRATE = "0.00" Then
        '                    NEWRATE = OLDRATE
        '                End If
        '            Else
        '                NEWRATE = OLDRATE
        '                'sqlstring = "SELECT PURCHASERATE FROM INVENTORYITEMMASTER WHERE Itemcode=" & ICODE & ""
        '                'gconnection.getDataSet(sqlstring, "INVENTORYITEMMASTER")
        '                'If gdataset.Tables("INVENTORYITEMMASTER").Rows.Count > 0 Then
        '                '    NEWRATE = gdataset.Tables("INVENTORYITEMMASTER").Rows(0).Item("PURCHASERATE")
        '                'Else

        '                '    NEWRATE = "0.00"
        '                'End If
        '            End If


        '            sqlstring = "INSERT INTO BAR_RATEMASTER (ITEMCODE, ITEMNAME, OLDRATE, NEWRATE, CLSTOCK)"
        '            sqlstring = sqlstring & "VALUES(" & ICODE & "," & INAME & "," & OLDRATE & "," & NEWRATE & "," & CLSQTY & ")"
        '            ''' Array.Clear(Insert, 0, Insert.Length)
        '            ReDim Preserve Insert(Insert.Length)
        '            Insert(Insert.Length - 1) = sqlstring
        '            ICODE = ""
        '            INAME = ""
        '            OLDRATE = "0.00"
        '            NEWRATE = "0.00"
        '            CLSQTY = "0.00"
        '            grndt1 = ""
        '        Next
        '        gconnection.MoreTrans1(Insert)
        '    End If

        '    sqlstring = "SELECT * FROM STOCK_REVISION "
        '    gconnection.getDataSet(sqlstring, "STOCK_REVISION")
        '    If gdataset.Tables("STOCK_REVISION").Rows.Count > 0 Then
        '        'If chk_excel.Checked = True Then
        '        'Dim exp As New exportexcel
        '        'exp.Show()
        '        'Call exp.export(sqlstring, "STOCK SUMMARY " & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")
        '        'Else
        '        rViewer.ssql = sqlstring
        '        'If gCATHOLIC = "Y" Then

        '        rViewer.Report = r1
        '        rViewer.TableName = "STOCK_REVISION"
        '        Dim textobj1 As TextObject
        '        textobj1 = r1.ReportDefinition.ReportObjects("Text21")
        '        textobj1.Text = MyCompanyName

        '        'Dim textobj2 As TextObject
        '        'textobj2 = r1.ReportDefinition.ReportObjects("Text8")
        '        'textobj2.Text = Trim(txt_Mainstore.Text)

        '        Dim textobj4 As TextObject
        '        textobj4 = r1.ReportDefinition.ReportObjects("Text15")
        '        textobj4.Text = gUsername


        '        Dim T4 As TextObject
        '        T4 = r1.ReportDefinition.ReportObjects("Text16")
        '        T4.Text = "Wine/IC"
        '        T4 = r1.ReportDefinition.ReportObjects("Text17")
        '        T4.Text = "Wine Member"
        '        T4 = r1.ReportDefinition.ReportObjects("Text18")
        '        T4.Text = "Member 1"
        '        T4 = r1.ReportDefinition.ReportObjects("Text19")
        '        T4.Text = "Member 2"
        '        T4 = r1.ReportDefinition.ReportObjects("Text20")
        '        T4.Text = "Presiding Officer"
        '        T4 = r1.ReportDefinition.ReportObjects("Text3")
        '        T4.Text = Format(DTP_FROMDATE.Value, "dd/MM/yyyy")
        '        T4 = r1.ReportDefinition.ReportObjects("Text26")
        '        T4.Text = Format(DTP_TODATE.Value, "dd/MM/yyyy")
        '        Dim textobj6 As TextObject
        '        textobj6 = r1.ReportDefinition.ReportObjects("Text22")
        '        textobj6.Text = gCompanyAddress(0)

        '        Dim textobj7 As TextObject
        '        textobj7 = r1.ReportDefinition.ReportObjects("Text23")
        '        textobj7.Text = gCompanyAddress(1)

        '        Dim t1 As TextObject
        '        t1 = r1.ReportDefinition.ReportObjects("Text25")
        '        t1.Text = Format(DTP_TODATE.Value, "dd/MMM/yyyy")

        '        '    Dim TXTOBJ3 As TextObject
        '        '    TXTOBJ3 = r.ReportDefinition.ReportObjects("Text17")
        '        '    TXTOBJ3.Text = " From  " & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "  To " & " " & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & ""
        '        rViewer.Show()
        '    Else
        '        MessageBox.Show("NO RECORDS TO DISPLAY")
        '    End If
        '    'End If
        '    'Else
        '    'MsgBox("NO RECORDS TO DISPLAY", MsgBoxStyle.OkOnly)
        '    'End If
        'Catch ex As Exception
        '    'MsgBox("Please Try Again")
        '    Call ViewsummaryKGA()
        'End Try
    End Sub


    '**************** BAR RATE REVISION FUNCTION ***************************
    Private Sub RATEREVISION()
        Dim itemtable As DataTable
        Dim STOCKSUMMARY As DataTable
        Dim itemcode, ITEMNAME, UOM As String
        Dim CLSTOCK, OPRATE, OPVAL, OPQTY, NEWRATE, NEWVAL, CLSTOCK1 As Double
        Dim GRNRATE As Double
        Dim INSERT(0) As String
        Dim GRNDATE As DateTime

        '*************** DELETE IF DATA IS THERE ********************** 
        sqlstring = "DELETE FROM STOCKSUMMARY_RATEREVISION"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring
        sqlstring = "DELETE FROM bar_ratemaster"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring
        gconnection.MoreTrans1(INSERT)
        ''************************
        'STORECODE = "BVI"
        'Call RUN_STOCKSUMMARY()
        ''******************** INSERT DATA ***********************************
        'sqlstring = "INSERT INTO STOCKSUMMARY_RATEREVISION(ITEMCODE, ITEMNAME, UOM, OPQTY, OPRATE, OPVAL, RCVQTY, RCVRATE,RCVVAL, ISSQTY, ISSRATE, ISSVAL,"
        'sqlstring = sqlstring & "CLSQTY, CLSRATE, CLSVAL, STORECODE, GROUPCODE, GROUPNAME, SUBGROUPCODE, SUBGROUPNAME, DISPQTY, OPDISPQTY,ISDISPQTY, CATEGORY, RETQTY, RETVAL) "
        'sqlstring = sqlstring & "(SELECT ITEMCODE, ITEMNAME, UOM, OPQTY, OPRATE, OPVAL, RCVQTY, RCVRATE,RCVVAL, ISSQTY, ISSRATE, ISSVAL,"
        'sqlstring = sqlstring & "CLSQTY, CLSRATE, CLSVAL, STORECODE, GROUPCODE, GROUPNAME, SUBGROUPCODE, SUBGROUPNAME, DISPQTY, OPDISPQTY,ISDISPQTY, CATEGORY, RETQTY, RETVAL FROM STOCKSUMMARY)"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        ''*******************************************************************
        'STORECODE = "BAR"
        'Call RUN_STOCKSUMMARY()
        ''******************** INSERT DATA ***********************************
        'sqlstring = "INSERT INTO STOCKSUMMARY_RATEREVISION(ITEMCODE, ITEMNAME, UOM, OPQTY, OPRATE, OPVAL, RCVQTY, RCVRATE,RCVVAL, ISSQTY, ISSRATE, ISSVAL,"
        'sqlstring = sqlstring & "CLSQTY, CLSRATE, CLSVAL, STORECODE, GROUPCODE, GROUPNAME, SUBGROUPCODE, SUBGROUPNAME, DISPQTY, OPDISPQTY,ISDISPQTY, CATEGORY, RETQTY, RETVAL) "
        'sqlstring = sqlstring & "(SELECT ITEMCODE, ITEMNAME, UOM, OPQTY, OPRATE, OPVAL, RCVQTY, RCVRATE,RCVVAL, ISSQTY, ISSRATE, ISSVAL,"
        'sqlstring = sqlstring & "CLSQTY, CLSRATE, CLSVAL, STORECODE, GROUPCODE, GROUPNAME, SUBGROUPCODE, SUBGROUPNAME, DISPQTY, OPDISPQTY,ISDISPQTY, CATEGORY, RETQTY, RETVAL FROM STOCKSUMMARY)"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        ''*******************************************************************
        Array.Clear(INSERT, 0, INSERT.Length)
        STORECODE = "MNS1"
        Call RUN_STOCKSUMMARY()
        '******************** INSERT DATA ***********************************
        'sqlstring = "INSERT INTO STOCKSUMMARY_RATEREVISION(ITEMCODE, ITEMNAME, UOM, OPQTY, OPRATE, OPVAL, RCVQTY, RCVRATE,RCVVAL, ISSQTY, ISSRATE, ISSVAL,"
        'sqlstring = sqlstring & "CLSQTY, CLSRATE, CLSVAL, STORECODE, GROUPCODE, GROUPNAME, SUBGROUPCODE, SUBGROUPNAME, DISPQTY, OPDISPQTY,ISDISPQTY, CATEGORY, RETQTY, RETVAL) "
        'sqlstring = sqlstring & "(SELECT ITEMCODE, ITEMNAME, UOM, OPQTY, OPRATE, OPVAL, RCVQTY, RCVRATE,RCVVAL, ISSQTY, ISSRATE, ISSVAL,"
        'sqlstring = sqlstring & "CLSQTY, CLSRATE, CLSVAL, STORECODE, GROUPCODE, GROUPNAME, SUBGROUPCODE, SUBGROUPNAME, DISPQTY, OPDISPQTY,ISDISPQTY, CATEGORY, RETQTY, RETVAL FROM STOCKSUMMARY)"
        'ReDim Preserve INSERT(INSERT.Length)
        'INSERT(INSERT.Length - 1) = sqlstring
        '*******************************************************************
        STOCKSUMMARY = gdataset.Tables("STOCKSUMMARY")
        '********
        'For i = 0 To STOCKSUMMARY.Rows.Count - 1
        For i = 0 To gdataset.Tables("STOCKSUMMARY").Rows.Count - 1
            itemcode = STOCKSUMMARY.Rows(i).Item("ITEMCODE")
            OPVAL = STOCKSUMMARY.Rows(i).Item("OPVAL")
            OPQTY = STOCKSUMMARY.Rows(i).Item("OPQTY")
            If OPQTY <> 0 Then
                OPRATE = Math.Round(Val(OPVAL) / Val(OPQTY), 2)

            Else
                OPRATE = 0
            End If

            sqlstring = "SELECT GRNDATE,grnno, ITEMCODE, ITEMNAME, UoM, QTY, RATE, adddate FROM GRN_DETAILS WHERE Itemcode='" & itemcode & "' and grndate between '" & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "' and '" & Format(DTP_TODATE.Value, "dd-MMM-yyyy") & "' ORDER BY grnno, grndate"
            gconnection.getDataSet(sqlstring, "GRN")
            If gdataset.Tables("GRN").Rows.Count > 0 Then
                For J = 0 To gdataset.Tables("GRN").Rows.Count - 1
                    GRNRATE = gdataset.Tables("GRN").Rows(J).Item("RATE")
                    If GRNRATE <> OPRATE Then
                        itemcode = gdataset.Tables("GRN").Rows(J).Item("ITEMCODE")
                        ITEMNAME = gdataset.Tables("GRN").Rows(J).Item("ITEMNAME")
                        NEWRATE = GRNRATE
                        UOM = gdataset.Tables("GRN").Rows(J).Item("UOM")
                        GRNDATE = Format(gdataset.Tables("GRN").Rows(J).Item("GRNDATE"), "dd-MMM-yyyy")
                        adddate = gdataset.Tables("GRN").Rows(J).Item("adddate")

                        grnno = gdataset.Tables("GRN").Rows(J).Item("grnno")
                        'CLSTOCK1 = ClosingQuantity_Date(itemcode, "BAR", UOM, GRNDATE)
                        'CLSTOCK = CLSTOCK1 + CLSTOCK
                        'CLSTOCK1 = ClosingQuantity_Date(itemcode, "BVI", UOM, GRNDATE)
                        'CLSTOCK = CLSTOCK1 + CLSTOCK
                        CLSTOCK = ClosingQuantity_Datetime(itemcode, "MNS1", UOM, adddate, grnno)
                        'CLSTOCK = CLSTOCK1 + CLSTOCK

                        sqlstring = "INSERT INTO bar_ratemaster(itemcode, ITEMNAME, OLDRATE, NEWRATE, CLSTOCK, ADDDATE) VALUES("
                        sqlstring = sqlstring & "'" & itemcode & "','" & ITEMNAME & "','" & Val(OPRATE) & "','" & NEWRATE & "','" & CLSTOCK & "','" & Format(GRNDATE, "dd-MMM-yyyy") & "')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = sqlstring
                        OPRATE = GRNRATE
                        CLSTOCK = 0
                        CLSTOCK1 = 0
                        itemcode = ""
                        ITEMNAME = ""
                        UOM = ""
                    Else
                        'itemcode = gdataset.Tables("GRN").Rows(J).Item("ITEMCODE")
                        'ITEMNAME = gdataset.Tables("GRN").Rows(J).Item("ITEMNAME")
                        'NEWRATE = GRNRATE
                        'UOM = gdataset.Tables("GRN").Rows(J).Item("UOM")
                        'GRNDATE = gdataset.Tables("GRN").Rows(J).Item("GRNDATE")
                        'CLSTOCK = ClosingQuantity_Datetime(itemcode, "MNS1", UOM, GRNDATE)

                        'sqlstring = "INSERT INTO bar_ratemaster(itemcode, ITEMNAME, OLDRATE, NEWRATE, CLSTOCK, ADDDATE) VALUES("
                        'sqlstring = sqlstring & "'" & itemcode & "','" & ITEMNAME & "','" & Val(OPRATE) & "','" & NEWRATE & "','" & CLSTOCK & "','" & Format(GRNDATE, "dd-MMM-yyy") & "')"
                        'ReDim Preserve INSERT(INSERT.Length)
                        'INSERT(INSERT.Length - 1) = sqlstring
                        'OPRATE = GRNRATE
                        'CLSTOCK = 0
                        'CLSTOCK1 = 0
                        'itemcode = ""
                        'ITEMNAME = ""
                        'UOM = ""
                    End If
        Next
                J = J - 1
                '***************insert of actual closing stock**********************
                itemcode = gdataset.Tables("GRN").Rows(J).Item("ITEMCODE")
                ITEMNAME = gdataset.Tables("GRN").Rows(J).Item("ITEMNAME")
                NEWRATE = GRNRATE
                UOM = gdataset.Tables("GRN").Rows(J).Item("UOM")
                GRNDATE = gdataset.Tables("GRN").Rows(J).Item("GRNDATE")
                CLSTOCK = ClosingQuantity_Date(itemcode, "MNS1", UOM, GRNDATE)
                sqlstring = "INSERT INTO bar_ratemaster(itemcode, ITEMNAME, OLDRATE, NEWRATE, CLSTOCK, ADDDATE) VALUES("
                sqlstring = sqlstring & "'" & itemcode & "','" & ITEMNAME & "','" & Val(OPRATE) & "','" & NEWRATE & "','" & CLSTOCK & "','" & Format(GRNDATE, "dd-MMM-yyyy") & "')"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring
                OPRATE = GRNRATE
                CLSTOCK = 0
                CLSTOCK1 = 0
                itemcode = ""
                ITEMNAME = ""
                UOM = ""
            End If

        Next
        gconnection.MoreTrans1(INSERT)

        '************** REPORT GENERATION ******************************
        Dim rViewer As New Viewer
        Dim R1 As New Cry_STOCKREVISION
        sqlstring = "SELECT * FROM STOCK_REVISION order by itemcode, adddate"
        gconnection.getDataSet(sqlstring, "STOCK_REVISION")
        If gdataset.Tables("STOCK_REVISION").Rows.Count > 0 Then
            rViewer.ssql = sqlstring

            rViewer.Report = R1
            rViewer.TableName = "STOCK_REVISION"
            Dim textobj1 As TextObject
            textobj1 = r1.ReportDefinition.ReportObjects("Text21")
            textobj1.Text = MyCompanyName

            Dim textobj4 As TextObject
            textobj4 = r1.ReportDefinition.ReportObjects("Text15")
            textobj4.Text = gUsername


            Dim T4 As TextObject
            T4 = r1.ReportDefinition.ReportObjects("Text16")
            T4.Text = "Wine/IC"
            T4 = r1.ReportDefinition.ReportObjects("Text17")
            T4.Text = "Wine Member"
            T4 = r1.ReportDefinition.ReportObjects("Text18")
            T4.Text = "Member 1"
            T4 = r1.ReportDefinition.ReportObjects("Text19")
            T4.Text = "Member 2"
            T4 = r1.ReportDefinition.ReportObjects("Text20")
            T4.Text = "Presiding Officer"
            T4 = r1.ReportDefinition.ReportObjects("Text3")
            T4.Text = Format(DTP_FROMDATE.Value, "dd/MM/yyyy")
            T4 = r1.ReportDefinition.ReportObjects("Text26")
            T4.Text = Format(DTP_TODATE.Value, "dd/MM/yyyy")
            Dim textobj6 As TextObject
            textobj6 = r1.ReportDefinition.ReportObjects("Text22")
            textobj6.Text = gCompanyAddress(0)

            Dim textobj7 As TextObject
            textobj7 = r1.ReportDefinition.ReportObjects("Text23")
            textobj7.Text = gCompanyAddress(1)

            Dim t1 As TextObject
            t1 = r1.ReportDefinition.ReportObjects("Text25")
            t1.Text = Format(DTP_TODATE.Value, "dd/MMM/yyyy")

            rViewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY")
        End If
    End Sub

    Private Sub RUN_STOCKSUMMARY()
        'Dim ITEMTABLE As DataTable
        'Dim ITEMCODE As String
        'sqlstring = "select DISTINCT itemcode from inventoryitemmaster WHERE storecode='" & CMB_STORECODE.Text & "' and freeze<>'Y'"
        'gconnection.getDataSet(sqlstring, "inventoryitemmaster")
        'ITEMTABLE = gdataset.Tables("inventoryitemmaster")
        'If ITEMTABLE.Rows.Count > 0 Then
        '    For i = 0 To itemtable.Rows.Count - 1
        '        If itemcode = "" Then
        '            itemcode = "'" & itemtable.Rows(i).Item("itemcode").ToString() & "'"
        '        Else
        '            itemcode = itemcode & "," & "'" & itemtable.Rows(i).Item("itemcode").ToString() & "'"
        '        End If
        '    Next
        'End If
        'sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='N' WHERE ITEMCODE NOT IN(" & Itemcode & ")  AND CATEGORY IN(" & USER & ")"
        'gconnection.getDataSet(sqlstring, "ITEMMASTER1")
        'sqlstring = " update INVENTORYITEMMASTER SET SELECTOPT='Y' WHERE ITEMCODE IN(" & Itemcode & ") AND CATEGORY IN(" & USER & ")"
        'gconnection.getDataSet(sqlstring, "ITEMMASTER")

        ''---------------------- EXECUTE STORE PROCEDURE --------------------------'
        'gconnection.openConnection()

        'gcommand = New SqlCommand("Cp_StockSummary3", gconnection.Myconn)
        'gcommand.CommandTimeout = 1000000000
        'gcommand.CommandType = CommandType.StoredProcedure
        'gcommand.Parameters.Add(New SqlParameter("@STORECODE", SqlDbType.VarChar)).Value = Storecode
        'gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_FROMDATE.Value), "dd/MM/yyyy")
        'gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.DateTime)).Value = Format(CDate(DTP_TODATE.Value), "dd/MM/yyyy")
        ''gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate(gstartingdate), "dd/MM/yyyy")
        'gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.DateTime)).Value = Format(CDate("26/03/" & gFinancalyearStart), "dd/MM/yyyy")
        'gcommand.Parameters.Add(New SqlParameter("@TODAT", SqlDbType.DateTime)).Value = Format(CDate(DTP_TODATE.Value), "yyyy/MM/dd")
        ''gcommand.Parameters.Add(New SqlParameter("@rate", SqlDbType.Float)).Value = rate
        'gcommand.ExecuteNonQuery()
        'gconnection.closeConnection()

        'sqlstring = "SELECT * FROM STOCKSUMMARY"
        'gconnection.getDataSet(sqlstring, "STOCKSUMMARY")
    End Sub

    Public Function ClosingQuantity_Datetime(ByVal ITEMCODE As String, ByVal STORECODE As String, ByVal UOM As String, ByVal docdate As DateTime, ByVal grnno As Integer) As Double
        Dim AdjustQty, ClsQty, MainstockQty, TransQty, TransFromQty, TransToQty As Double
        Dim OpQty, GrnQty, PrnQty, IssueQty, ReturnQty, ReturnFromQty, ReturnToQty, IssueToQty, IssueFromQty, ConsumedQty, EXPENDQTY, EXPENDVALUE, DMGQTY, DMGVALUE, SUBSTQTY As Double
        Dim OpValue, GRNVALUE, MainStockValue, PrnValue, IssueValue, IssueTOValue, IssueFROMValue, ADJVALUE, TRFVALUE, TRFFROMVALUE, TRFTOVALUE, TransConsumValue As Double
        Dim dtl As New DataTable

        Dim sqlstring, uomstr, transUOM As String
        '----added by ganesh 09/11/2013-------
        uomstr = "select isnull(UOMCODE,'') as UOMCODE  FROM UoMMaster  WHERE ('" & UOM & "' =UOMCode OR '" & UOM & "'=UOMDesc)"
        dtl = gconnection.GetValues(uomstr)
        If dtl.Rows.Count > 0 Then
            transUOM = dtl.Rows(0).Item(0).ToString
        Else
            MsgBox("UOM not valid please stop the process!", MsgBoxStyle.Critical, gCompanyname)
        End If
        '-----------------------------------------

        '**************Procedure for getting Conv UOM'*********************************
        gconnection.openConnection()
        gcommand = New SqlCommand("InventoryTransUpdate_ITEM", gconnection.Myconn)
        gcommand.CommandTimeout = 1000000000
        gcommand.CommandType = CommandType.StoredProcedure
        gcommand.Parameters.Add(New SqlParameter("@ITEMCODE", SqlDbType.VarChar)).Value = ITEMCODE
        gcommand.Parameters.Add(New SqlParameter("@ITEMUOM", SqlDbType.VarChar)).Value = transUOM
        gcommand.Parameters.Add(New SqlParameter("@Storecode", SqlDbType.VarChar)).Value = STORECODE
        gcommand.ExecuteNonQuery()
        gconnection.closeConnection()
        '***********************************

        Dim i As Integer
        sqlstring = "SELECT ISNULL(INVITMTRANSQTY,0) * ISNULL(CONVVALUE,0) AS OPSTOCK1,ISNULL(INVITMTRANSQTY,0) AS OPSTOCK,ISNULL(INVITMTRANSVALUE,0) AS OPVALUE FROM INVENTORYITEMMASTER WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(FREEZE,'') <> 'Y' AND STORECODE='" & Trim(STORECODE) & "'"
        gconnection.getDataSet(sqlstring, "INVENTORYITEM")
        If gdataset.Tables("INVENTORYITEM").Rows.Count > 0 Then
            OpQty = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPSTOCK")), "0.000")
            OpValue = Format(Val(gdataset.Tables("INVENTORYITEM").Rows(0).Item("OPVALUE")), "0.000")
        Else
            OpQty = 0
            OpValue = 0
        End If
        'docdate.AddMinutes(+1)
        'sqlstring = "SELECT ISNULL(SUM(DBLAMOUNT),0) AS QTY1,ISNULL(SUM(GRNTRANSQTY),0) AS QTY ,ISNULL(SUM(GRNTRANSVALUE),0) AS GRNVALUE  FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(VOIDITEM,'') <>'Y'  AND STORECODE='" & Trim(STORECODE) & "' AND GRNTYPE='GRN'  and  CAST(CONVERT(VARCHAR,adddate,106)AS DATETIME)<='" & Format(CDate(docdate), "dd-MMM-yyyy") & "'"
        sqlstring = "SELECT ISNULL(SUM(DBLAMOUNT),0) AS QTY1,ISNULL(SUM(GRNTRANSQTY),0) AS QTY ,ISNULL(SUM(GRNTRANSVALUE),0) AS GRNVALUE  FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(VOIDITEM,'') <>'Y'  AND STORECODE='" & Trim(STORECODE) & "' AND GRNTYPE='GRN'  and  adddate<='" & Format(docdate, "dd-MMM-yyyy HH:mm") & "' and grnno = '" & grnno & "' "
        gconnection.getDataSet(sqlstring, "GRN_DETAILS")
        If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
            GrnQty = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
            ' GRNVALUE = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("GRNVALUE")), "0.000")
        Else
            GrnQty = 0
            GRNVALUE = 0
        End If
        MainstockQty = GrnQty + OpQty
        MainStockValue = GRNVALUE + OpValue

        sqlstring = "SELECT ISNULL(SUM(DBLAMOUNT),0) AS QTY1,ISNULL(SUM(GRNTRANSQTY),0) AS QTY,ISNULL(SUM(GRNTRANSVALUE),0) AS PRNVALUE  FROM GRN_DETAILS WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND ISNULL(VOIDITEM,'') <>'Y'  AND STORECODE='" & Trim(STORECODE) & "' AND GRNTYPE='PRN' and  CAST(CONVERT(VARCHAR,GRNDATE,106)AS DATETIME)<='" & Format(CDate(docdate), "dd-MMM-yyyy") & "'"
        gconnection.getDataSet(sqlstring, "GRN_DETAILS")
        If gdataset.Tables("GRN_DETAILS").Rows.Count > 0 Then
            PrnQty = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("QTY")), "0.000")
            PrnValue = Format(Val(gdataset.Tables("GRN_DETAILS").Rows(0).Item("PRNVALUE")), "0.000")
        Else
            PrnQty = 0
            PrnValue = 0
        End If

        MainstockQty = GrnQty + OpQty - PrnQty
        MainStockValue = GRNVALUE + OpValue - PrnValue

        sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(ISSTRANSQTY),0) AS QTY,ISNULL(SUM(ISSTRANSVALUE),0) AS ISSFROMVALUE FROM STOCKISSUEDETAIL "
        'sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "' AND ISNULL(VOID,'')<>'Y' and  CAST(CONVERT(VARCHAR,adddatetime,106)AS DATETIME)<='" & Format(CDate(adddate), "dd-MMM-yyyy") & "'"
        sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "' AND ISNULL(VOID,'')<>'Y' and  adddatetime<='" & Format(adddate, "dd-MMM-yyyy HH:mm") & "'"
        gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
        If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
            IssueFromQty = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("QTY")), "0.000")
            IssueFROMValue = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("ISSFROMVALUE")), "0.000")
        Else
            IssueFromQty = 0
            IssueFROMValue = 0
        End If

        'sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(ISSTRANSQTY),0) AS QTY,ISNULL(SUM(ISSTRANSVALUE),0) AS ISSTOVALUE FROM STOCKISSUEDETAIL "
        'sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND OPSTORELOCATIONCODE = '" & Trim(STORECODE) & "' AND ISNULL(VOID,'')<>'Y' and  CAST(CONVERT(VARCHAR,DOCDATE,106)AS DATETIME)<='" & Format(CDate(docdate), "dd-MMM-yyyy") & "'"
        'gconnection.getDataSet(sqlstring, "STOCKISSUEDETAIL")
        'If gdataset.Tables("STOCKISSUEDETAIL").Rows.Count > 0 Then
        '    IssueToQty = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("QTY")), "0.000")
        '    IssueTOValue = Format(Val(gdataset.Tables("STOCKISSUEDETAIL").Rows(0).Item("ISSTOVALUE")), "0.000")
        'Else
        '    IssueToQty = 0
        '    IssueTOValue = 0
        'End If
        'IssueQty = IssueToQty - IssueFromQty
        'IssueValue = IssueTOValue - IssueFROMValue
        ' ''''********************************* FROM STOCKADJUSTMENT ***************************************'''
        'sqlstring = "SELECT ISNULL(SUM(DBLAMOUNT),0) AS QTY1,ISNULL(SUM(ADJTransQty),0) AS QTY ,ISNULL(SUM(ADJTransValue),0) AS ADJTRNSVALUE  FROM STOCKADJUSTDETAILS "
        'sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "' AND ISNULL(VOID,'')<>'Y' and  CAST(CONVERT(VARCHAR,DOCDATE,106)AS DATETIME)<='" & Format(CDate(docdate), "dd-MMM-yyyy") & "'"
        'gconnection.getDataSet(sqlstring, "STOCKADJUSTDETAILS")
        'If gdataset.Tables("STOCKADJUSTDETAILS").Rows.Count > 0 Then
        '    AdjustQty = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("QTY")), "0.000")
        '    ADJVALUE = Format(Val(gdataset.Tables("STOCKADJUSTDETAILS").Rows(0).Item("ADJTRNSVALUE")), "0.000")
        'Else
        '    AdjustQty = 0
        '    ADJVALUE = 0
        'End If

        ' '''********************************* FROM STOCK TRANSFER *****************************************'''

        'sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(TRFTRANSQTY),0) AS QTY,ISNULL(SUM(TRFTRANSVALUE),0) AS TRFFROMVALUE  FROM STOCKTRANSFERDETAIL "
        'sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND FROMSTORECODE = '" & Trim(STORECODE) & "'  AND ISNULL(VOID,'')<>'Y' and  CAST(CONVERT(VARCHAR,DOCDATE,106)AS DATETIME)<='" & Format(CDate(docdate), "dd-MMM-yyyy") & "'"
        'gconnection.getDataSet(sqlstring, "STOCKTRANSDETAILS")
        'If gdataset.Tables("STOCKTRANSDETAILS").Rows.Count > 0 Then
        '    TransFromQty = Format(Val(gdataset.Tables("STOCKTRANSDETAILS").Rows(0).Item("QTY")), "0.000")
        '    TRFFROMVALUE = Format(Val(gdataset.Tables("STOCKTRANSDETAILS").Rows(0).Item("TRFFROMVALUE")), "0.000")
        'Else
        '    TransFromQty = 0
        '    TRFFROMVALUE = 0
        'End If

        'sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(TRFTRANSQTY),0) AS QTY,ISNULL(SUM(TRFTRANSVALUE),0) AS TRFTOVALUE  FROM STOCKTRANSFERDETAIL "
        'sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND TOSTORECODE = '" & Trim(STORECODE) & "'  AND ISNULL(VOID,'')<>'Y' and  CAST(CONVERT(VARCHAR,DOCDATE,106)AS DATETIME)<='" & Format(CDate(docdate), "dd-MMM-yyyy") & "'"
        'gconnection.getDataSet(sqlstring, "STOCKTRANSDETAILS1")
        'If gdataset.Tables("STOCKTRANSDETAILS1").Rows.Count > 0 Then
        '    TransToQty = Format(Val(gdataset.Tables("STOCKTRANSDETAILS1").Rows(0).Item("QTY")), "0.000")
        '    TRFTOVALUE = Format(Val(gdataset.Tables("STOCKTRANSDETAILS1").Rows(0).Item("TRFTOVALUE")), "0.000")
        'Else
        '    TransToQty = 0
        '    TRFTOVALUE = 0
        'End If
        'TransQty = TransToQty - TransFromQty
        'TRFVALUE = TRFTOVALUE - TRFFROMVALUE

        'sqlstring = "SELECT ISNULL(SUM(DBLAMT),0) AS QTY1,ISNULL(SUM(SSCTRANSQTY),0) AS QTY,ISNULL(SUM(SSCTRANSVALUE),0) AS SSCTRANSVALUE FROM SUBSTORECONSUMPTIONDETAIL "
        'sqlstring = sqlstring & " WHERE ITEMCODE='" & Trim(ITEMCODE) & "' AND STORELOCATIONCODE = '" & Trim(STORECODE) & "'  AND ISNULL(VOID,'')<>'Y' and  CAST(CONVERT(VARCHAR,DOCDATE,106)AS DATETIME)<='" & Format(CDate(docdate), "dd-MMM-yyyy") & "'"
        'gconnection.getDataSet(sqlstring, "STORECONSUMPTIONDETAILS")
        'If gdataset.Tables("STORECONSUMPTIONDETAILS").Rows.Count > 0 Then
        '    ConsumedQty = Format(Val(gdataset.Tables("STORECONSUMPTIONDETAILS").Rows(0).Item("QTY")), "0.000")
        '    TransConsumValue = Format(Val(gdataset.Tables("STORECONSUMPTIONDETAILS").Rows(0).Item("SSCTRANSVALUE")), "0.000")
        'Else
        '    ConsumedQty = 0
        '    TransConsumValue = 0
        'End If

        ''*****FOR STOCK EXPENDITURE

        'sqlstring = "SELECT ISNULL(SUM(ADJUSTEDSTOCK),0) AS QTY1, ISNULL(SUM(AMOUNT),0) AS RATE FROM STOCKEXPENDITUREDETAILS "
        'sqlstring = sqlstring & "WHERE Itemcode='" & Trim(ITEMCODE) & "' AND Storelocationcode='" & Trim(STORECODE) & "' AND ISNULL(Void,'')<>'Y' and  CAST(CONVERT(VARCHAR,DOCDATE,106)AS DATETIME)<='" & Format(CDate(docdate), "dd-MMM-yyyy") & "'"
        'gconnection.getDataSet(sqlstring, "STOCKEXPENDITUREDETAILS")
        'If gdataset.Tables("STOCKEXPENDITUREDETAILS").Rows.Count > 0 Then
        '    EXPENDQTY = Format(Val(gdataset.Tables("STOCKEXPENDITUREDETAILS").Rows(0).Item("QTY1")), "0.000")
        '    EXPENDVALUE = Format(Val(gdataset.Tables("STOCKEXPENDITUREDETAILS").Rows(0).Item("RATE")), "0.000")
        'Else
        '    EXPENDQTY = 0
        '    EXPENDVALUE = 0
        'End If

        ''***********FOR STOCK DAMAGE 
        'sqlstring = "SELECT ISNULL(DMGTRANSQTYR,0) AS QTY, ISNULL(AMOUNT,0) AS RATE FROM STOCKDMGDETAIL "
        'sqlstring = sqlstring & "WHERE Itemcode='" & Trim(ITEMCODE) & "' AND Storecode='" & Trim(STORECODE) & "' AND ISNULL(Void,'')<>'Y' and  CAST(CONVERT(VARCHAR,DOCDATE,106)AS DATETIME)<='" & Format(CDate(docdate), "dd-MMM-yyyy") & "'"
        'gconnection.getDataSet(sqlstring, "STOCKDMGDETAIL")
        'If gdataset.Tables("STOCKDMGDETAIL").Rows.Count > 0 Then
        '    DMGQTY = Format(Val(gdataset.Tables("STOCKDMGDETAIL").Rows(0).Item("QTY")), "0.000")
        '    DMGVALUE = Format(Val(gdataset.Tables("STOCKDMGDETAIL").Rows(0).Item("RATE")), "0.000")
        'Else
        '    DMGQTY = 0
        '    DMGVALUE = 0
        'End If

        'ClsQty = (Val(MainstockQty) + Val(AdjustQty)) + Val(IssueQty) + Val(TransQty) - Val(EXPENDQTY) - Val(ConsumedQty) - Val(DMGQTY)
        ClsQty = Val(MainstockQty) - Val(IssueFromQty)
        DateClsValue = (Val(MainStockValue) + Val(ADJVALUE)) + Val(IssueValue) + Val(TRFVALUE) - Val(EXPENDVALUE) - Val(TransConsumValue) - Val(DMGVALUE)
        Return ClsQty
    End Function

    Private Sub NEWRATEREVISION()
        Dim itemtable As DataTable
        Dim STOCKSUMMARY As DataTable
        Dim itemcode, ITEMNAME, UOM As String
        Dim CLSTOCK, OPRATE, OPVAL, OPQTY, NEWRATE, NEWVAL, CLSTOCK1 As Double
        Dim GRNRATE As Double
        Dim INSERT(0) As String
        Dim GRNDATE As DateTime
        Dim SQLS As String

        '*************** DELETE IF DATA IS THERE **********************


        sqlstring = "DELETE FROM bar_ratemaster"
        ReDim Preserve INSERT(INSERT.Length)
        INSERT(INSERT.Length - 1) = sqlstring
        gconnection.MoreTrans1(INSERT)
        Array.Clear(INSERT, 0, INSERT.Length)

        '******* EXECUTE PROCEDURE 
        gconnection.openConnection()
        gcommand = New SqlCommand("BAR_OPQTY_CALC", gconnection.Myconn)
        gcommand.CommandTimeout = 1000000000
        gcommand.CommandType = CommandType.StoredProcedure
        gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.VarChar)).Value = Format(CDate("26/MAR/" & gFinancalyearStart), "dd/MMM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.VarChar)).Value = Format(CDate(DTP_FROMDATE.Value), "dd/MMM/yyyy")
        gcommand.ExecuteNonQuery()
        gconnection.closeConnection()

        '************** DROP VIEW *********************************
        sqlstring = "DROP VIEW STOCKCALFINAL"
        'gconnection.openConnection()
        'gcommand = New SqlCommand("STOCKCALFINAL", gconnection.Myconn)
        'gcommand.CommandText = CommandType.StoredProcedure
        'gcommand.ExecuteNonQuery()
        'gconnection.closeConnection()
        gconnection.ExcuteStoreProcedure(sqlstring)
        '************** CREATE VIEW *********************************
        sqlstring = "CREATE VIEW STOCKCALFINAL "
        sqlstring = sqlstring & " AS "
        sqlstring = sqlstring & " SELECT  'AOPVAL' AS TYPE, '" & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "' AS DOCDATE,  ITEMCODE,ITEMNAME, SUM(QTY) AS QTY, RATE AS RATE,SUM(QTY) AS BALANCE, ADDDATE  FROM STOCKCALC WHERE DOCDATE <'" & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "' GROUP BY ITEMCODE, ITEMNAME, ADDDATE,RATE"
        sqlstring = sqlstring & " UNION ALL"
        sqlstring = sqlstring & " SELECT 'CONSUMP' AS TYPE , DOCDATE, ITEMCODE, ITEMNAME, QTY, RATE, 0 AS BALANCE, ADDDATE FROM STOCKCALC WHERE GRNTYPE='ISSUE' AND CAST(CONVERT(VARCHAR(20),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "' and '" & Format(DTP_TODATE.Value, "dd-MMM-yyyy") & "'"
        sqlstring = sqlstring & " UNION ALL"
        sqlstring = sqlstring & " SELECT 'TRANS' AS TYPE , DOCDATE, ITEMCODE, ITEMNAME, QTY, RATE, 0 AS BALANCE, ADDDATE FROM STOCKCALC WHERE GRNTYPE='GRN' AND CAST(CONVERT(VARCHAR(20),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "' and '" & Format(DTP_TODATE.Value, "dd-MMM-yyyy") & "'"
        gconnection.ExcuteStoreProcedure(sqlstring)


        '---------------------- EXECUTE STORE PROCEDURE --------------------------'
        gconnection.openConnection()

        gcommand = New SqlCommand("GETSTOCKFINAL", gconnection.Myconn)
        gcommand.CommandTimeout = 1000000000
        gcommand.CommandType = CommandType.StoredProcedure
        gcommand.ExecuteNonQuery()
        gconnection.closeConnection()



        '************** REPORT GENERATION ******************************
        Dim rViewer As New Viewer
        Dim R1 As New Cry_STOCKREVISION
        ' sqlstring = "SELECT * FROM STOCK_REVISION order by itemcode, adddate"
        sqlstring = "SELECT * FROM STOCK_REVISION WHERE ITEMCODE IN (SELECT ITEMCODE FROM INVENTORYITEMMASTER WHERE STORECODE='MNS1') order by itemcode, adddate"
        gconnection.getDataSet(sqlstring, "STOCK_REVISION")
        If gdataset.Tables("STOCK_REVISION").Rows.Count > 0 Then
            rViewer.ssql = sqlstring

            rViewer.Report = R1
            rViewer.TableName = "STOCK_REVISION"
            Dim textobj1 As TextObject
            textobj1 = R1.ReportDefinition.ReportObjects("Text21")
            textobj1.Text = MyCompanyName

            Dim textobj4 As TextObject
            textobj4 = R1.ReportDefinition.ReportObjects("Text15")
            textobj4.Text = gUsername


            Dim T4 As TextObject
            T4 = R1.ReportDefinition.ReportObjects("Text16")
            T4.Text = "Wine/IC"
            T4 = R1.ReportDefinition.ReportObjects("Text17")
            T4.Text = "Wine Member"
            T4 = R1.ReportDefinition.ReportObjects("Text18")
            T4.Text = "Member 1"
            T4 = R1.ReportDefinition.ReportObjects("Text19")
            T4.Text = "Member 2"
            T4 = R1.ReportDefinition.ReportObjects("Text20")
            T4.Text = "Presiding Officer"
            T4 = R1.ReportDefinition.ReportObjects("Text3")
            T4.Text = Format(DTP_FROMDATE.Value, "dd/MM/yyyy")
            T4 = R1.ReportDefinition.ReportObjects("Text26")
            T4.Text = Format(DTP_TODATE.Value, "dd/MM/yyyy")
            Dim textobj6 As TextObject
            textobj6 = R1.ReportDefinition.ReportObjects("Text22")
            textobj6.Text = gCompanyAddress(0)

            Dim textobj7 As TextObject
            textobj7 = R1.ReportDefinition.ReportObjects("Text23")
            textobj7.Text = gCompanyAddress(1)

            Dim t1 As TextObject
            t1 = R1.ReportDefinition.ReportObjects("Text25")
            t1.Text = Format(DTP_TODATE.Value, "dd/MMM/yyyy")

            rViewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY")
        End If
    End Sub

    Public Sub bar_rate_revision()
        Try
            sqlstring = "DELETE FROM BAR_RATEMASTER"
            gconnection.ExcuteStoreProcedure(sqlstring)
        '******* EXECUTE PROCEDURE 
        gconnection.openConnection()
        gcommand = New SqlCommand("BAR_OPQTY_CALC", gconnection.Myconn)
        gcommand.CommandTimeout = 1000000000
        gcommand.CommandType = CommandType.StoredProcedure
        gcommand.Parameters.Add(New SqlParameter("@FINYEARSTART", SqlDbType.VarChar)).Value = Format(CDate("26/MAR/" & gFinancalyearStart), "dd/MMM/yyyy")
        gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.VarChar)).Value = Format(CDate(DTP_FROMDATE.Value), "dd/MMM/yyyy")
        gcommand.ExecuteNonQuery()
        gconnection.closeConnection()

        sqlstring = "SELECT Itemcode, Itemname,OPQTY, ISNULL(OPVAL,0) AS RATE, '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy HH:mm:ss ") & "' AS DATE FROM BAR_OPQTY_FINAL "
        sqlstring = sqlstring & " WHERE ITEMCODE IN (SELECT ITEMCODE FROM INVENTORYITEMMASTER "
            sqlstring = sqlstring & " WHERE STORECODE NOT IN ('MNS','DIN'))  ORDER BY ITEMCODE"
        gconnection.getDataSet(sqlstring, "STOCK")

        '****** SELECT THE PURCHASE AND STORE IN A TABLE ************
            sqlstring = "SELECT Itemcode, Itemname,Qty, RATE, GRNDETAILS, GRNDATE FROM GRN_DETAILS  WHERE Grndate BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy HH:mm:ss ") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy HH:mm:ss ") & "' AND STORECODE='MNS1'  ORDER BY GRNDATE"
        gconnection.getDataSet(sqlstring, "PURCHASE")

        '**** RUNNING THE LOOP IN THE PURCHASE TABLE ****
        Dim ITEMCODE1, ITEMNAME1, GRNDETAILS As String
        Dim GRNDATE As DateTime
        Dim OPRATE As Double
        If gdataset.Tables("STOCK").Rows.Count > 0 Then
                If gdataset.Tables("PURCHASE").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("PURCHASE").Rows.Count - 1
                        ITEMCODE1 = gdataset.Tables("PURCHASE").Rows(i).Item("ITEMCODE")
                        'If ITEMCODE1 = "B001" Then
                        '    MessageBox.Show("B001")
                        'End If
                        OPRATE = gdataset.Tables("PURCHASE").Rows(i).Item("RATE")
                        For J = 0 To gdataset.Tables("STOCK").Rows.Count - 1
                            If gdataset.Tables("STOCK").Rows(J).Item("ITEMCODE") = ITEMCODE1 Then
                                If gdataset.Tables("STOCK").Rows(J).Item("RATE") <> OPRATE Then
                                    '*****UPDATION 
                                    GRNDATE = Format(gdataset.Tables("PURCHASE").Rows(i).Item("GRNDATE"), "dd/MMM/yyyy HH:mm:ss ")
                                    GRNDATE = GRNDATE.AddHours(-1)
                                    GRNDETAILS = gdataset.Tables("PURCHASE").Rows(i).Item("GRNDETAILS")
                                    OPRATE = gdataset.Tables("STOCK").Rows(J).Item("RATE")
                                    '******* EXECUTE PROCEDURE 
                                    gconnection.openConnection()
                                    gcommand = New SqlCommand("BAR_CLSQTY_CALC", gconnection.Myconn)
                                    gcommand.CommandTimeout = 1000000000
                                    gcommand.CommandType = CommandType.StoredProcedure
                                    gcommand.Parameters.Add(New SqlParameter("@FROMDATE", SqlDbType.VarChar)).Value = Format(CDate("26/MAR/" & gFinancalyearStart), "dd/MMM/yyyy HH:mm:ss ")
                                    'gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.VarChar)).Value = Format(CDate(GRNDATE), "dd/MMM/yyyy HH:mm:ss ")
                                    gcommand.Parameters.Add(New SqlParameter("@TODATE", SqlDbType.VarChar)).Value = Format(CDate(GRNDATE), "dd/MMM/yyyy")
                                    gcommand.Parameters.Add(New SqlParameter("@ITEMCODE", SqlDbType.VarChar)).Value = ITEMCODE1
                                    gcommand.ExecuteNonQuery()
                                    gconnection.closeConnection()

                                    '***** CURRENT CLOSING STOCK *************

                                    sqlstring = "SELECT ITEMCODE, CLSQTY FROM BAR_CLSQTY_FINAL"
                                    gconnection.getDataSet(sqlstring, "BAR_CLSQTY_FINAL")
                                    '***** INSERT INTO BAR_RATE_MASTER ***********
                                    sqlstring = "INSERT INTO BAR_RATEMASTER (ITEMCODE, ITEMNAME, CLSTOCK, NEWRATE, ADDDATE, GRNDETAILS)"
                                    sqlstring = sqlstring & " SELECT G.ITEMCODE, G.ITEMNAME, B.CLSQTY, RATE, GRNDATE, G.GRNDETAILS FROM GRN_DETAILS G, "
                                    sqlstring = sqlstring & " BAR_CLSQTY_FINAL B WHERE G.GRNDETAILS ='" & GRNDETAILS & "' AND G.ITEMCODE='" & ITEMCODE1 & "'"
                                    gconnection.ExcuteStoreProcedure(sqlstring)

                                    sqlstring = "UPDATE BAR_RATEMASTER SET OPRATE = '" & OPRATE & "' WHERE  ITEMCODE='" & ITEMCODE1 & "' AND GRNDETAILS = '" & GRNDETAILS & "'"
                                    gconnection.ExcuteStoreProcedure(sqlstring)
                                    Dim Z As Integer
                                    For Z = 0 To gdataset.Tables("STOCK").Rows.Count - 1
                                        If gdataset.Tables("STOCK").Rows(Z).Item("ITEMCODE") = gdataset.Tables("PURCHASE").Rows(i).Item("ITEMCODE") Then
                                            Dim PURCH As Double
                                            PURCH = gdataset.Tables("PURCHASE").Rows(i).Item("RATE")
                                            gdataset.Tables("STOCK").Rows(Z).Item("RATE") = PURCH
                                        End If
                                    Next


                                End If
                            End If
                        Next
                    Next
                End If
            End If

            '************** REPORT GENERATION ******************************
            Dim rViewer As New Viewer
            Dim R1 As New Cry_STOCKREVISION
            ' sqlstring = "SELECT * FROM STOCK_REVISION order by itemcode, adddate"
            sqlstring = "SELECT * FROM STOCK_REVISION WHERE ITEMCODE IN (SELECT ITEMCODE FROM INVENTORYITEMMASTER WHERE STORECODE='MNS1') AND ISNULL(OLDRATE,0)<>0  order by itemcode, adddate"
            gconnection.getDataSet(sqlstring, "STOCK_REVISION")
            If gdataset.Tables("STOCK_REVISION").Rows.Count > 0 Then
                If CHK_EXC.Checked = True Then
                    Dim exp As New exportexcel
                    exp.Show()
                    Call exp.export(sqlstring, "BAR RATE REVISION" & Format(DTP_FROMDATE.Value, "dd-MMM-yyyy") & "TO" & Format(DTP_TODATE.Value, "dd-MMM-yyyy"), "")
                Else
                    rViewer.ssql = sqlstring

                    rViewer.Report = R1
                    rViewer.TableName = "STOCK_REVISION"
                    Dim textobj1 As TextObject
                    textobj1 = R1.ReportDefinition.ReportObjects("Text21")
                    textobj1.Text = MyCompanyName

                    Dim textobj4 As TextObject
                    textobj4 = R1.ReportDefinition.ReportObjects("Text15")
                    textobj4.Text = gUsername


                    Dim T4 As TextObject
                    T4 = R1.ReportDefinition.ReportObjects("Text16")
                    T4.Text = "Wine/IC"
                    T4 = R1.ReportDefinition.ReportObjects("Text17")
                    T4.Text = "Wine Member"
                    T4 = R1.ReportDefinition.ReportObjects("Text18")
                    T4.Text = "Member 1"
                    T4 = R1.ReportDefinition.ReportObjects("Text19")
                    T4.Text = "Member 2"
                    T4 = R1.ReportDefinition.ReportObjects("Text20")
                    T4.Text = "Presiding Officer"
                    T4 = R1.ReportDefinition.ReportObjects("Text3")
                    T4.Text = Format(DTP_FROMDATE.Value, "dd/MM/yyyy")
                    T4 = R1.ReportDefinition.ReportObjects("Text26")
                    T4.Text = Format(DTP_TODATE.Value, "dd/MM/yyyy")
                    Dim textobj6 As TextObject
                    textobj6 = R1.ReportDefinition.ReportObjects("Text22")
                    textobj6.Text = gCompanyAddress(0)

                    Dim textobj7 As TextObject
                    textobj7 = R1.ReportDefinition.ReportObjects("Text23")
                    textobj7.Text = gCompanyAddress(1)

                    'Dim t1 As TextObject
                    't1 = R1.ReportDefinition.ReportObjects("Text25")
                    't1.Text = Format(DTP_TODATE.Value, "dd/MMM/yyyy")

                    rViewer.Show()
                End If
            Else
                MessageBox.Show("NO RECORDS TO DISPLAY")
            End If

        Catch ex As Exception
            MsgBox("Please Try Again")
        End Try
    End Sub


    Public Function CALC_BAR_RATE()
        Dim MITEM, SQLS, itemc As String
        Dim z As Integer
        Dim MLASTSTOCK, MLASTRATE, MCLSSTOCK As Double
        Dim itemcode1() As String
        Dim slstring As String
        Try
            sqlstring = "DROP TABLE INV_BAR_TAB2"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SQLS = "SELECT * INTO INV_BAR_TAB2 FROM INV_BAR_VIEW2 WHERE 1<0 AND CATEGORY IN ('RAS')"
            gconnection.ExcuteStoreProcedure(SQLS)

            sqlstring = "ALTER TABLE INV_BAR_TAB2 ADD ROWID INTEGER IDENTITY(1,1)"
            gconnection.ExcuteStoreProcedure(sqlstring)
            SQLS = " INSERT INTO INV_BAR_TAB2 (DOCDETAILS,ITEMCODE, ITEMNAME, DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY) "

            SQLS = SQLS & "SELECT DOCDETAILS,ITEMCODE, ITEMNAME, CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) AS DOCDATE, QTY, RATE, AMOUNT, CLSSTOCK, TYPE, STORECODE, CATEGORY, LASTSTOCK, LASTRATE, PRIORITY FROM INV_BAR_VIEW2 "

            SQLS = SQLS & " WHERE STORECODE NOT IN ('MNS') ORDER BY  ITEMCODE,"

            SQLS = SQLS & " CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) , PRIORITY"

            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "ALTER TABLE INV_BAR_TAB2 ADD WEIGHTED_RATE NUMERIC(18,2)"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "UPDATE INV_BAR_TAB2 SET WEIGHTED_RATE =0"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = " UPDATE INV_BAR_TAB2 SET CLSSTOCK=(SELECT SUM(QTY) FROM INV_BAR_TAB2 A WHERE A.ITEMCODE=INV_BAR_TAB2.ITEMCODE AND A.ROWID<=INV_BAR_TAB2.ROWID )"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE INV_BAR_TAB2 SET LASTSTOCK=(SELECT ISNULL(SUM(QTY),0) FROM INV_BAR_TAB2 A WHERE A.ITEMCODE=INV_BAR_TAB2.ITEMCODE AND A.ROWID<INV_BAR_TAB2.ROWID )"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = " UPDATE INV_BAR_TAB2 SET LASTRATE=(SELECT TOP 1 ISNULL(RATE,0) AS RATE FROM INV_BAR_TAB2 A "
            SQLS = SQLS & " WHERE  A.ITEMCODE=INV_BAR_TAB2.ITEMCODE AND A.ROWID<INV_BAR_TAB2.ROWID AND A.TYPE IN ('OPENING','GRN') ORDER BY A.ROWID DESC) "
            SQLS = SQLS & " WHERE TYPE IN ('OPENING','GRN')"
            gconnection.ExcuteStoreProcedure(SQLS)
            SQLS = " UPDATE  INV_BAR_TAB2 SET LASTRATE=RATE WHERE TYPE IN ('OPENING','GRN') AND ISNULL(LASTRATE,0)=0"
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = " UPDATE INV_BAR_TAB2 SET WEIGHTED_RATE = RATE WHERE TYPE='OPENING'"
            gconnection.ExcuteStoreProcedure(SQLS)

            sqlstring = "SELECT * FROM INV_BAR_TAB2  ORDER BY ROWID"
            Dim SqlConnection As New SqlConnection
            SqlConnection.ConnectionString = gconnection.Getconnection()
            SqlConnection.Open()
            Dim DS As New DataSet
            Dim DA As New SqlDataAdapter(sqlstring, SqlConnection)
            '  DA.Fill(DS)
            Dim DT As New DataTable
            DA.Fill(DT)
            DT.TableName = "INV_BAR_TAB2"
            If DS.Tables.Contains("INV_BAR_TAB2") = True Then
                DS.Tables.Remove("INV_BAR_TAB2")
            End If
            DS.Tables.Add(DT)

            SqlConnection.Close()

            'gconnection.getDataSet(sqlstring, "INV_BAR_TAB2")
            If DS.Tables("INV_BAR_TAB2").Rows.Count > 0 Then
                Dim ITEMCODE As String
                Dim RATE As Double
                Dim QTY As Double
                ITEMCODE = DS.Tables("INV_BAR_TAB2").Rows(0).Item("ITEMCODE")
                For i = 0 To DS.Tables("INV_BAR_TAB2").Rows.Count - 1
                    'If ITEMCODE = "LPDR105" Then
                    '    MessageBox.Show("LPDR105")
                    'End If
                    If ITEMCODE <> DS.Tables("INV_BAR_TAB2").Rows(i).Item("ITEMCODE") Then
                        QTY = 0
                        RATE = 0
                        ITEMCODE = DS.Tables("INV_BAR_TAB2").Rows(i).Item("ITEMCODE")

                        QTY = QTY + DS.Tables("INV_BAR_TAB2").Rows(i).Item("QTY")
                        If DS.Tables("INV_BAR_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                            RATE = DS.Tables("INV_BAR_TAB2").Rows(i).Item("RATE")

                        ElseIf DS.Tables("INV_BAR_TAB2").Rows(i).Item("TYPE") = "GRN" Then
                            If DS.Tables("INV_BAR_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                'RATE = ((DS.Tables("INV_BAR_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_BAR_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_BAR_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_BAR_TAB2").Rows(i).Item("CLSSTOCK"))
                                RATE = DS.Tables("INV_BAR_TAB2").Rows(i).Item("RATE")
                                DS.Tables("INV_BAR_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                            Else
                                RATE = 0
                            End If
                        Else
                            DS.Tables("INV_BAR_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                        End If
                    Else
                        QTY = QTY + DS.Tables("INV_BAR_TAB2").Rows(i).Item("QTY")
                        If DS.Tables("INV_BAR_TAB2").Rows(i).Item("TYPE") = "OPENING" Then
                            RATE = DS.Tables("INV_BAR_TAB2").Rows(i).Item("RATE")

                        ElseIf DS.Tables("INV_BAR_TAB2").Rows(i).Item("TYPE") = "GRN" Then
                            If DS.Tables("INV_BAR_TAB2").Rows(i).Item("CLSSTOCK") <> 0 Then
                                'RATE = ((DS.Tables("INV_BAR_TAB2").Rows(i).Item("LASTSTOCK") * RATE) + (DS.Tables("INV_BAR_TAB2").Rows(i).Item("QTY") * DS.Tables("INV_BAR_TAB2").Rows(i).Item("RATE"))) / (DS.Tables("INV_BAR_TAB2").Rows(i).Item("CLSSTOCK"))
                                RATE = DS.Tables("INV_BAR_TAB2").Rows(i).Item("RATE")
                                DS.Tables("INV_BAR_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE
                            Else
                                RATE = 0
                            End If
                        Else
                            DS.Tables("INV_BAR_TAB2").Rows(i).Item("WEIGHTED_RATE") = RATE

                        End If
                    End If
                    'If i < DS.Tables("INV_BAR_TAB2").Rows.Count - 1 Then
                    '    ITEMCODE = DS.Tables("INV_BAR_TAB2").Rows(i + 1).Item("ITEMCODE")
                    'End If

                Next

            End If

            SQLS = "DROP TABLE INV_WEIGHTED_TAB3 "
            gconnection.ExcuteStoreProcedure(SQLS)

            SQLS = "CREATE TABLE INV_WEIGHTED_TAB3 (ROWID INTEGER, WEIGHTED_RATE NUMERIC(18,2) )"
            gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "ALTER TABLE INV_WEIGHTED_TAB3 ALTER COLUMN ROWID INTEGER"
            'gconnection.ExcuteStoreProcedure(SQLS)
            'SQLS = "ALTER TABLE INV_WEIGHTED_TAB3 ADD ROWID INTEGER"
            'gconnection.ExcuteStoreProcedure(SQLS)
            Dim SQLS1 As String
            Dim J As Integer
            SQLS = ""
            For i = 0 To DS.Tables("INV_BAR_TAB2").Rows.Count - 1
                SQLS = SQLS & "INSERT INTO INV_WEIGHTED_TAB3 (ROWID, WEIGHTED_RATE) VALUES ( "

                For J = 0 To DS.Tables("INV_BAR_TAB2").Columns.Count - 1
                    If ((UCase(DS.Tables("INV_BAR_TAB2").Columns(J).ColumnName) = "ROWID") Or (UCase(DS.Tables("INV_BAR_TAB2").Columns(J).ColumnName) = "WEIGHTED_RATE")) Then
                        SQLS = SQLS & "'" & DS.Tables("INV_BAR_TAB2").Rows(i).Item(J) & "',"
                    End If
                    'SQLS = SQLS & "'" & DS.Tables("INV_BAR_TAB2").Rows(i).Item(J) & "',"
                Next
                SQLS = Mid(SQLS, 1, Len(SQLS) - 2)
                SQLS = SQLS & " ')"

            Next
            If SQLS <> "" Then
                gconnection.ExcuteStoreProcedure(SQLS)
            End If

            SQLS = "UPDATE INV_BAR_TAB2 SET WEIGHTED_RATE=A.WEIGHTED_RATE  FROM  INV_WEIGHTED_TAB3 A WHERE A.ROWID=INV_BAR_TAB2.ROWID"
            gconnection.ExcuteStoreProcedure(SQLS)

            '***INSERT INTO FINAL TABLE **********
            SQLS = "INSERT INTO INV_BAR_FINAL_TAB (DOCDETAILS,ITEMCODE,ITEMNAME,DOCDATE,QTY,RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,"
            SQLS = SQLS & " LASTSTOCK,LASTRATE,WEIGHTED_RATE)  "
            SQLS = SQLS & " SELECT DOCDETAILS,ITEMCODE,ITEMNAME,DOCDATE,QTY,RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,"
            SQLS = SQLS & " LASTSTOCK,LASTRATE,WEIGHTED_RATE FROM INV_BAR_TAB2"
            gconnection.ExcuteStoreProcedure(SQLS)

            ''**********updation of purchase rate in inventory itemmaster **********
            'SQLS = "update inventoryitemmaster set purchaserate=a.weighted_rate, salerate=a.weighted_rate FROM INV_BAR_TAB2 A "
            'SQLS = SQLS & " WHERE  A.ITEMCODE=inventoryitemmaster.Itemcode and TYPE in ('issue','CONSUMPTION','expend')"
            'gconnection.ExcuteStoreProcedure(SQLS)

            ''***** UPDATION OF THE TRANSACTION AFTER CALCULATING WEIGHTED RATE **********************
            'SQLS = "UPDATE STOCKISSUEDETAIL SET Rate=A.WEIGHTED_RATE , AMOUNT= STOCKISSUEDETAIL.QTY*A.WEIGHTED_RATE FROM INV_BAR_TAB2 A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKISSUEDETAIL.Docdetails AND A.ITEMCODE=STOCKISSUEDETAIL.Itemcode AND A.TYPE='ISSUE'"
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "UPDATE STOCKEXPENDITUREDETAILS SET Rate=A.WEIGHTED_RATE , Amount = STOCKEXPENDITUREDETAILS.Adjustedstock * A.WEIGHTED_RATE FROM INV_BAR_TAB2 A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKEXPENDITUREDETAILS.Docdetails AND A.ITEMCODE=STOCKEXPENDITUREDETAILS.Itemcode AND A.TYPE='EXPEND'"
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "UPDATE STOCKCONSUMPTIONDETAILS SET Rate=A.WEIGHTED_RATE, Amount=STOCKCONSUMPTIONDETAILS.Adjustedstock * A.WEIGHTED_RATE FROM INV_BAR_TAB2 A"
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKCONSUMPTIONDETAILS.Docdetails AND A.ITEMCODE=STOCKCONSUMPTIONDETAILS.Itemcode AND A.TYPE='CONSUMPTION'"
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "UPDATE STOCKADJUSTDETAILS SET Rate=A.WEIGHTED_RATE, Amount=STOCKADJUSTDETAILS.Adjustedstock * A.WEIGHTED_RATE FROM INV_BAR_TAB2 A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKADJUSTDETAILS.Docdetails AND A.ITEMCODE=STOCKADJUSTDETAILS.Itemcode AND A.TYPE='ADJUSTMENT'"
            'gconnection.ExcuteStoreProcedure(SQLS)

            'SQLS = "UPDATE STOCKDMGDETAIL SET Rate=A.WEIGHTED_RATE, Amount=STOCKDMGDETAIL.Qty * A.WEIGHTED_RATE FROM INV_BAR_TAB2 A "
            'SQLS = SQLS & " WHERE A.DOCDETAILS=STOCKDMGDETAIL.Docdetails AND A.ITEMCODE=STOCKDMGDETAIL.Itemcode AND A.TYPE='DAMAGE'"
            'gconnection.ExcuteStoreProcedure(SQLS)

            ''SqlConnection.Open()
            ''Dim tablename As String = "INV_WEIGHTED_TAB3"
            ''Dim OBJDS As New DataSet
            ''OBJDS = DS
            ''Dim SB As System.Text.StringBuilder = New System.Text.StringBuilder(1000)
            ' ''    SB=

            ' ''System.Text.StringBuilder sb = new System.Text.StringBuilder( 1000);
            ''Dim SW As System.IO.StringWriter = New System.IO.StringWriter(SB)
            ' ''System.IO.StringWriter sw = new System.IO.StringWriter(sb); 
            ''Dim COL As DataColumn
            ''For Each COL In gdataset.Tables("INV_BAR_TAB2").Columns

            ''    COL.ColumnMapping = System.Data.MappingType.Attribute
            ''Next
            ''OBJDS.WriteXml(SW, System.Data.XmlWriteMode.WriteSchema)

            ''Dim SQLTEXT As String = buildBulkUpdateSql(SB.ToString(), OBJDS.Tables("INV_WEIGHTED_TAB3"))
            ''execSql(SqlConnection, SQLTEXT)










            ''sqlstring = "SELECT * FROM INV_BAR_VIEW2 ORDER BY ITEMCODE,DOCDATE"
            ''gconnection.getDataSet(sqlstring, "INV_BAR_VIEW2")
            ''If gdataset.Tables("INV_BAR_VIEW2").Rows.Count > 0 Then
            ''    For i = 0 To gdataset.Tables("INV_BAR_VIEW2").Rows.Count - 1
            ''        Array.Clear(Insert, 0, Insert.Length)
            ''        MITEM = gdataset.Tables("INV_BAR_VIEW2").Rows(i).Item("ITEMCODE")
            ''        MLASTSTOCK = 0
            ''        MLASTRATE = gdataset.Tables("INV_BAR_VIEW2").Rows(i).Item("RATE")
            ''        If gdataset.Tables("INV_BAR_VIEW2").Rows.Count > 0 And MITEM = gdataset.Tables("INV_BAR_VIEW2").Rows(i).Item("ITEMCODE") Then
            ''            MCLSSTOCK = gdataset.Tables("INV_BAR_VIEW2").Rows(i).Item("QTY") + gdataset.Tables("INV_BAR_VIEW2").Rows(i).Item("LASTSTOCK")
            ''            'UPDATE CLSSTOCK FOR THAT RECORD
            ''            SQLS = "UPDATE INV_BAR_TAB2 SET CLSSTOCK ='" & MCLSSTOCK & "' WHERE ITEMCODE='" & MITEM & "' "
            ''            Insert(0) = SQLS
            ''            'UPDATE LASTSTOCK FOR THAT RECORD WITH MLASTSTOCK
            ''            MLASTSTOCK = gdataset.Tables("INV_BAR_VIEW2").Rows(i).Item("QTY")
            ''            SQLS = "UPDATE INV_BAR_TAB2 SET LASTSTOCK ='" & MCLSSTOCK & "' WHERE ITEMCODE='" & MITEM & "' "
            ''            ReDim Preserve Insert(Insert.Length)
            ''            Insert(Insert.Length - 1) = SQLS
            ''            SQLS = "UPDATE INV_BAR_TAB2 SET LASTRATE='" & MLASTRATE & "' WHERE ITEMCODE='" & MITEM & "'"
            ''            ReDim Preserve Insert(Insert.Length)
            ''            Insert(Insert.Length - 1) = SQLS
            ''            MLASTRATE = gdataset.Tables("INV_BAR_VIEW2").Rows(i).Item("RATE")
            ''            gconnection.getDataSet(sqlstring, "INV_BAR_VIEW2")
            ''        End If
            ''    Next
            ''gconnection.MoreTrans(Insert)
            ''End If

        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CMD_ADD" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function

    Private Sub chk_CRV_CheckedChanged(sender As Object, e As EventArgs) Handles chk_CRV.CheckedChanged
        If chk_CRV.Checked = True Then
            CHK_DETAILED_HISTORY.Checked = False
            chk_History.Checked = False
            chk_profit.Checked = False
        End If
    End Sub

    Private Sub chk_CRV_Click(sender As Object, e As EventArgs) Handles chk_CRV.Click
        'If chk_CRV.Checked = True Then
        '    chk_History.Checked = False
        '    'chk_CRV.Checked = False
        'ElseIf chk_CRV.Checked = False Then
        '    chk_History.Checked = True
        '    'chk_CRV.Checked = True
        'End If
    End Sub

    Private Sub chk_excel_Click(sender As Object, e As EventArgs) Handles chk_excel.Click
        'If chk_excel.Checked = True Then
        '    chk_CRV.Checked = False
        '    chk_excel.Checked = True
        'ElseIf chk_excel.Checked = False Then
        '    chk_CRV.Checked = True
        '    chk_excel.Checked = False
        'End If
    End Sub

    Private Sub chk_History_CheckedChanged(sender As Object, e As EventArgs) Handles chk_History.CheckedChanged
        If chk_History.Checked = True Then
            chk_CRV.Checked = False
            CHK_DETAILED_HISTORY.Checked = False
            chk_profit.Checked = False
        End If
    End Sub

    Private Sub chk_History_Click(sender As Object, e As EventArgs) Handles chk_History.Click
        'If chk_History.Checked = True Then
        '    'chk_History.Checked = False
        '    chk_CRV.Checked = False
        'ElseIf chk_History.Checked = False Then
        '    'chk_History.Checked = True
        '    chk_CRV.Checked = True
        'End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.ProgressBar2.Value > 0 And Me.ProgressBar2.Value < 100 Then
            Me.ProgressBar2.Value += 1
            'Me.lbl_Wait.Text = Me.ProgressBar1.Value & "%"
        Else
            Me.Timer1.Enabled = False
            Me.ProgressBar2.Value = 0
            Me.GroupBox4.Top = 1000
            Call barrate()

        End If
    End Sub

    Public Sub barrate()
        Try
            Dim rViewer As New Viewer
            

            If chk_CRV.Checked = True Then
                '******* EXECUTE PROCEDURE 
                gconnection.openConnection()
                gcommand = New SqlCommand("[UPDATE_barRATE]", gconnection.Myconn)
                gcommand.CommandTimeout = 1000000000
                gcommand.CommandType = CommandType.StoredProcedure
                gcommand.ExecuteNonQuery()
                gconnection.closeConnection()

                sqlstring = "select DOCDETAILS, DOCDATE, ITEMCODE, ITEMNAME, QTY, RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,LASTSTOCK,LASTRATE, WEIGHTED_RATE from INV_BAR_FINAL_TAB "
                sqlstring = sqlstring & " WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' AND TYPE='GRN' "
                sqlstring = sqlstring & " order by itemcode, docdate "
                gconnection.getDataSet(sqlstring, "STOCK_REVISION1")
                If gdataset.Tables("STOCK_REVISION1").Rows.Count > 0 Then

                    'Dim rViewer As New Viewer
                    Dim r As New Crys_weighted_report
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "[INV_BAR_FINAL_TAB]"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text7")
                    textobj1.Text = MyCompanyName

                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text8")
                    textobj6.Text = UCase(gCompanyAddress(0)) & " ," & UCase(gCompanyAddress(1))

                    Dim textobj7 As TextObject
                    textobj7 = r.ReportDefinition.ReportObjects("Text9")
                    textobj7.Text = "BAR RATE REVISION CRV REPORT"

                    Dim textobj2 As TextObject
                    textobj2 = r.ReportDefinition.ReportObjects("Text10")
                    textobj2.Text = "FROM DATE " & Format(DTP_FROMDATE.Value, "dd/MM/yyyy") & " TO DATE " & Format(DTP_TODATE.Value, "dd/MM/yyyy")

                    Dim textobj8 As TextObject
                    textobj8 = r.ReportDefinition.ReportObjects("Text6")
                    textobj8.Text = "NEW P RATE"
                    rViewer.Show()
                Else
                    MessageBox.Show("NO RECORDS TO DISPLAY")
                End If

            ElseIf chk_History.Checked = True Then
                '******* EXECUTE PROCEDURE 
                gconnection.openConnection()
                gcommand = New SqlCommand("[UPDATE_barRATE]", gconnection.Myconn)
                gcommand.CommandTimeout = 1000000000
                gcommand.CommandType = CommandType.StoredProcedure
                gcommand.ExecuteNonQuery()
                gconnection.closeConnection()

                sqlstring = "select DOCDETAILS, DOCDATE, ITEMCODE, ITEMNAME, QTY, RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,LASTSTOCK,LASTRATE, WEIGHTED_RATE from INV_BAR_FINAL_TAB "
                sqlstring = sqlstring & " WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' "
                sqlstring = sqlstring & " order by itemcode, docdate "
                gconnection.getDataSet(sqlstring, "STOCK_REVISION2")
                If gdataset.Tables("STOCK_REVISION2").Rows.Count > 0 Then

                    'Dim rViewer As New Viewer
                    Dim r As New Crys_weighted_report
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "[INV_BAR_FINAL_TAB]"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text7")
                    textobj1.Text = MyCompanyName

                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text8")
                    textobj6.Text = UCase(gCompanyAddress(0)) & " ," & UCase(gCompanyAddress(1))

                    Dim textobj7 As TextObject
                    textobj7 = r.ReportDefinition.ReportObjects("Text9")
                    textobj7.Text = "BAR RATE REVISION HISTORY REPORT"

                    Dim textobj2 As TextObject
                    textobj2 = r.ReportDefinition.ReportObjects("Text10")
                    textobj2.Text = "FROM DATE " & Format(DTP_FROMDATE.Value, "dd/MM/yyyy") & " TO DATE " & Format(DTP_TODATE.Value, "dd/MM/yyyy")

                    Dim textobj8 As TextObject
                    textobj8 = r.ReportDefinition.ReportObjects("Text6")
                    textobj8.Text = "NEW P RATE"
                    Dim textobj9 As TextObject
                    textobj9 = r.ReportDefinition.ReportObjects("Text17")
                    textobj9.Text = "LAST P RATE"
                    rViewer.Show()
                Else
                    MessageBox.Show("NO RECORDS TO DISPLAY")
                End If

            ElseIf chk_profit.Checked = True Then

                '******* EXECUTE PROCEDURE 
                gconnection.openConnection()
                gcommand = New SqlCommand("[UPDATE_barRATE]", gconnection.Myconn)
                gcommand.CommandTimeout = 1000000000
                gcommand.CommandType = CommandType.StoredProcedure
                gcommand.ExecuteNonQuery()
                gconnection.closeConnection()

                '************** REPORT GENERATION ******************************

                Dim R1 As New Cry_STOCKREVISION
                ' sqlstring = "SELECT * FROM STOCK_REVISION order by itemcode, adddate"
                sqlstring = "SELECT * FROM INV_BAR_FINAL_TAB where TYPE='GRN' and RATE<>lastrate and CAST(convert(varchar,docdate,106) as datetime) "
                sqlstring = sqlstring & " between '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' and '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' "
                sqlstring = sqlstring & " order by itemcode, docdetails "
                gconnection.getDataSet(sqlstring, "STOCK_REVISION")
                If gdataset.Tables("STOCK_REVISION").Rows.Count > 0 Then
                    rViewer.ssql = sqlstring

                    rViewer.Report = R1
                    rViewer.TableName = "STOCK_REVISION"
                    Dim textobj1 As TextObject
                    textobj1 = R1.ReportDefinition.ReportObjects("Text21")
                    textobj1.Text = MyCompanyName

                    Dim textobj4 As TextObject
                    textobj4 = R1.ReportDefinition.ReportObjects("Text15")
                    textobj4.Text = gUsername

                    Dim T4 As TextObject
                    T4 = R1.ReportDefinition.ReportObjects("Text16")
                    T4.Text = "Wine/IC"
                    T4 = R1.ReportDefinition.ReportObjects("Text17")
                    T4.Text = "Wine Member"
                    T4 = R1.ReportDefinition.ReportObjects("Text18")
                    T4.Text = "Member 1"
                    T4 = R1.ReportDefinition.ReportObjects("Text19")
                    T4.Text = "Member 2"
                    T4 = R1.ReportDefinition.ReportObjects("Text20")
                    T4.Text = "Presiding Officer"
                    T4 = R1.ReportDefinition.ReportObjects("Text3")
                    T4.Text = Format(DTP_FROMDATE.Value, "dd/MM/yyyy")
                    T4 = R1.ReportDefinition.ReportObjects("Text26")
                    T4.Text = Format(DTP_TODATE.Value, "dd/MM/yyyy")
                    Dim textobj6 As TextObject
                    textobj6 = R1.ReportDefinition.ReportObjects("Text22")
                    textobj6.Text = gCompanyAddress(0)

                    Dim textobj7 As TextObject
                    textobj7 = R1.ReportDefinition.ReportObjects("Text23")
                    textobj7.Text = gCompanyAddress(1)

                    rViewer.Show()

                Else
                    MessageBox.Show("NO RECORDS TO DISPLAY")
                End If
            ElseIf CHK_DETAILED_HISTORY.Checked = True Then
                '******* EXECUTE PROCEDURE 
                gconnection.openConnection()
                gcommand = New SqlCommand("[UPDATE_barRATE_detailed]", gconnection.Myconn)
                gcommand.CommandTimeout = 1000000000
                gcommand.CommandType = CommandType.StoredProcedure
                gcommand.ExecuteNonQuery()
                gconnection.closeConnection()

                sqlstring = "select DOCDETAILS, DOCDATE, ITEMCODE, ITEMNAME, QTY, RATE,AMOUNT,CLSSTOCK,TYPE,STORECODE,CATEGORY,LASTSTOCK,LASTRATE, WEIGHTED_RATE from INV_BAR_FINAL_TAB_DETAILED "
                sqlstring = sqlstring & " WHERE CAST(CONVERT(VARCHAR(11),DOCDATE,106) AS DATETIME) BETWEEN '" & Format(DTP_FROMDATE.Value, "dd/MMM/yyyy") & "' AND '" & Format(DTP_TODATE.Value, "dd/MMM/yyyy") & "' "
                sqlstring = sqlstring & " ORDER BY ITEMCODE,DOCDATE,PRIORITY "
                gconnection.getDataSet(sqlstring, "STOCK_REVISION3")
                If gdataset.Tables("STOCK_REVISION3").Rows.Count > 0 Then

                    'Dim rViewer As New Viewer
                    Dim r As New Crys_DETAILED_weighted_report
                    rViewer.ssql = sqlstring
                    rViewer.Report = r
                    rViewer.TableName = "[INV_BAR_FINAL_TAB_DETAILED]"
                    Dim textobj1 As TextObject
                    textobj1 = r.ReportDefinition.ReportObjects("Text7")
                    textobj1.Text = MyCompanyName

                    Dim textobj6 As TextObject
                    textobj6 = r.ReportDefinition.ReportObjects("Text8")
                    textobj6.Text = UCase(gCompanyAddress(0)) & " ," & UCase(gCompanyAddress(1))

                    Dim textobj7 As TextObject
                    textobj7 = r.ReportDefinition.ReportObjects("Text9")
                    textobj7.Text = "BAR RATE REVISION DETAILED HISTORY REPORT"

                    Dim textobj2 As TextObject
                    textobj2 = r.ReportDefinition.ReportObjects("Text10")
                    textobj2.Text = "FROM DATE " & Format(DTP_FROMDATE.Value, "dd/MM/yyyy") & " TO DATE " & Format(DTP_TODATE.Value, "dd/MM/yyyy")

                    Dim textobj8 As TextObject
                    textobj8 = r.ReportDefinition.ReportObjects("Text6")
                    textobj8.Text = "NEW P RATE"
                    Dim textobj9 As TextObject
                    textobj9 = r.ReportDefinition.ReportObjects("Text17")
                    textobj9.Text = "LAST P RATE"
                    rViewer.Show()
                Else
                    MessageBox.Show("NO RECORDS TO DISPLAY")
                End If


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bar_raterevision_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub chk_profit_CheckedChanged(sender As Object, e As EventArgs) Handles chk_profit.CheckedChanged
        If chk_profit.Checked = True Then
            chk_CRV.Checked = False
            CHK_DETAILED_HISTORY.Checked = False
            chk_History.Checked = False
        End If
    End Sub

    Private Sub CHK_DETAILED_HISTORY_CheckedChanged(sender As Object, e As EventArgs) Handles CHK_DETAILED_HISTORY.CheckedChanged
        If CHK_DETAILED_HISTORY.Checked = True Then

            chk_CRV.Checked = False
            chk_profit.Checked = False
            chk_History.Checked = False

        End If
    End Sub
End Class
