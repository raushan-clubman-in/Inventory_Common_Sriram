Public Class CreditDebit
    Inherits System.Windows.Forms.Form
    Dim vconn As New GlobalClass
    Dim intI, intMonthNo, RowCount As Integer
    Dim dblCreditAmt, dblDebitAmt, dblDiffTot As Double
    Dim dblCreditAmtA, dblDebitAmtA, dblDiffTotA As Double
    Dim ICA, IDA, ITA, ACA, ADA, ATA, ICT, IDT, ACT, ADT As Double
    Dim strVType, strVNo, strSql(1), strSqlString As String
    Friend WithEvents Button1 As System.Windows.Forms.Button


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
    Friend WithEvents GrpGrid As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdGetDetails As System.Windows.Forms.Button    
    Friend WithEvents grpSsgridSub As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ssgridSub As AxFPSpreadADO.AxfpSpread
    Friend WithEvents cmdRefreshSub As System.Windows.Forms.Button
    Friend WithEvents cmdExportSub As System.Windows.Forms.Button
    Friend WithEvents cmdExitSub As System.Windows.Forms.Button
    Friend WithEvents grpSsgrid As System.Windows.Forms.GroupBox
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents grpSsgridSubVoucher As System.Windows.Forms.GroupBox
    Friend WithEvents ssgridSubVoucher As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRefreshSubVoucher As System.Windows.Forms.Button
    Friend WithEvents cmdExportSubVoucher As System.Windows.Forms.Button
    Friend WithEvents cmdExitSubVoucher As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreditDebit))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpGrid = New System.Windows.Forms.GroupBox()
        Me.cmdGetDetails = New System.Windows.Forms.Button()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.grpSsgrid = New System.Windows.Forms.GroupBox()
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread()
        Me.grpSsgridSub = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdRefreshSub = New System.Windows.Forms.Button()
        Me.cmdExportSub = New System.Windows.Forms.Button()
        Me.cmdExitSub = New System.Windows.Forms.Button()
        Me.ssgridSub = New AxFPSpreadADO.AxfpSpread()
        Me.grpSsgridSubVoucher = New System.Windows.Forms.GroupBox()
        Me.ssgridSubVoucher = New AxFPSpreadADO.AxfpSpread()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdRefreshSubVoucher = New System.Windows.Forms.Button()
        Me.cmdExportSubVoucher = New System.Windows.Forms.Button()
        Me.cmdExitSubVoucher = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GrpGrid.SuspendLayout()
        Me.grpSsgrid.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSsgridSub.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ssgridSub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSsgridSubVoucher.SuspendLayout()
        CType(Me.ssgridSubVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(370, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(269, 25)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "UNMATCHED VOUCHER TYPES"
        '
        'GrpGrid
        '
        Me.GrpGrid.BackColor = System.Drawing.Color.Transparent
        Me.GrpGrid.Controls.Add(Me.Button1)
        Me.GrpGrid.Controls.Add(Me.cmdGetDetails)
        Me.GrpGrid.Controls.Add(Me.cmdExport)
        Me.GrpGrid.Controls.Add(Me.cmdExit)
        Me.GrpGrid.Location = New System.Drawing.Point(86, 413)
        Me.GrpGrid.Name = "GrpGrid"
        Me.GrpGrid.Size = New System.Drawing.Size(496, 64)
        Me.GrpGrid.TabIndex = 123
        Me.GrpGrid.TabStop = False
        '
        'cmdGetDetails
        '
        Me.cmdGetDetails.BackColor = System.Drawing.Color.Transparent
        Me.cmdGetDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdGetDetails.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdGetDetails.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGetDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGetDetails.Location = New System.Drawing.Point(8, 11)
        Me.cmdGetDetails.Name = "cmdGetDetails"
        Me.cmdGetDetails.Size = New System.Drawing.Size(106, 46)
        Me.cmdGetDetails.TabIndex = 5
        Me.cmdGetDetails.Text = "&Refresh"
        Me.cmdGetDetails.UseVisualStyleBackColor = False
        '
        'cmdExport
        '
        Me.cmdExport.BackColor = System.Drawing.Color.Transparent
        Me.cmdExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdExport.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExport.Location = New System.Drawing.Point(259, 11)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(106, 46)
        Me.cmdExport.TabIndex = 4
        Me.cmdExport.Text = "E&xport[F12]"
        Me.cmdExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExport.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.Transparent
        Me.cmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExit.Location = New System.Drawing.Point(384, 11)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(106, 46)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "&Exit[F11]"
        Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'grpSsgrid
        '
        Me.grpSsgrid.BackColor = System.Drawing.Color.Transparent
        Me.grpSsgrid.Controls.Add(Me.ssgrid)
        Me.grpSsgrid.Controls.Add(Me.GrpGrid)
        Me.grpSsgrid.Location = New System.Drawing.Point(195, 116)
        Me.grpSsgrid.Name = "grpSsgrid"
        Me.grpSsgrid.Size = New System.Drawing.Size(719, 490)
        Me.grpSsgrid.TabIndex = 125
        Me.grpSsgrid.TabStop = False
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(13, 20)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(691, 378)
        Me.ssgrid.TabIndex = 125
        '
        'grpSsgridSub
        '
        Me.grpSsgridSub.BackColor = System.Drawing.Color.Transparent
        Me.grpSsgridSub.Controls.Add(Me.GroupBox2)
        Me.grpSsgridSub.Controls.Add(Me.ssgridSub)
        Me.grpSsgridSub.Location = New System.Drawing.Point(184, 120)
        Me.grpSsgridSub.Name = "grpSsgridSub"
        Me.grpSsgridSub.Size = New System.Drawing.Size(649, 493)
        Me.grpSsgridSub.TabIndex = 126
        Me.grpSsgridSub.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmdRefreshSub)
        Me.GroupBox2.Controls.Add(Me.cmdExportSub)
        Me.GroupBox2.Controls.Add(Me.cmdExitSub)
        Me.GroupBox2.Location = New System.Drawing.Point(111, 408)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(424, 64)
        Me.GroupBox2.TabIndex = 123
        Me.GroupBox2.TabStop = False
        '
        'cmdRefreshSub
        '
        Me.cmdRefreshSub.BackColor = System.Drawing.Color.Transparent
        Me.cmdRefreshSub.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRefreshSub.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefreshSub.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRefreshSub.Location = New System.Drawing.Point(7, 11)
        Me.cmdRefreshSub.Name = "cmdRefreshSub"
        Me.cmdRefreshSub.Size = New System.Drawing.Size(137, 50)
        Me.cmdRefreshSub.TabIndex = 5
        Me.cmdRefreshSub.Text = "Re&fresh"
        Me.cmdRefreshSub.UseVisualStyleBackColor = False
        '
        'cmdExportSub
        '
        Me.cmdExportSub.BackColor = System.Drawing.Color.Transparent
        Me.cmdExportSub.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExportSub.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportSub.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportSub.Location = New System.Drawing.Point(143, 11)
        Me.cmdExportSub.Name = "cmdExportSub"
        Me.cmdExportSub.Size = New System.Drawing.Size(137, 50)
        Me.cmdExportSub.TabIndex = 4
        Me.cmdExportSub.Text = "Ex&port[F12]"
        Me.cmdExportSub.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExportSub.UseVisualStyleBackColor = False
        '
        'cmdExitSub
        '
        Me.cmdExitSub.BackColor = System.Drawing.Color.Transparent
        Me.cmdExitSub.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExitSub.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExitSub.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExitSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExitSub.Location = New System.Drawing.Point(279, 11)
        Me.cmdExitSub.Name = "cmdExitSub"
        Me.cmdExitSub.Size = New System.Drawing.Size(137, 50)
        Me.cmdExitSub.TabIndex = 3
        Me.cmdExitSub.Text = "Exi&t[F11]"
        Me.cmdExitSub.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExitSub.UseVisualStyleBackColor = False
        '
        'ssgridSub
        '
        Me.ssgridSub.DataSource = Nothing
        Me.ssgridSub.Location = New System.Drawing.Point(32, 15)
        Me.ssgridSub.Name = "ssgridSub"
        Me.ssgridSub.OcxState = CType(resources.GetObject("ssgridSub.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgridSub.Size = New System.Drawing.Size(586, 387)
        Me.ssgridSub.TabIndex = 125
        '
        'grpSsgridSubVoucher
        '
        Me.grpSsgridSubVoucher.BackColor = System.Drawing.Color.Transparent
        Me.grpSsgridSubVoucher.Controls.Add(Me.ssgridSubVoucher)
        Me.grpSsgridSubVoucher.Controls.Add(Me.GroupBox3)
        Me.grpSsgridSubVoucher.Location = New System.Drawing.Point(191, 118)
        Me.grpSsgridSubVoucher.Name = "grpSsgridSubVoucher"
        Me.grpSsgridSubVoucher.Size = New System.Drawing.Size(650, 511)
        Me.grpSsgridSubVoucher.TabIndex = 127
        Me.grpSsgridSubVoucher.TabStop = False
        '
        'ssgridSubVoucher
        '
        Me.ssgridSubVoucher.DataSource = Nothing
        Me.ssgridSubVoucher.Location = New System.Drawing.Point(24, 19)
        Me.ssgridSubVoucher.Name = "ssgridSubVoucher"
        Me.ssgridSubVoucher.OcxState = CType(resources.GetObject("ssgridSubVoucher.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgridSubVoucher.Size = New System.Drawing.Size(600, 392)
        Me.ssgridSubVoucher.TabIndex = 125
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cmdDelete)
        Me.GroupBox3.Controls.Add(Me.cmdRefreshSubVoucher)
        Me.GroupBox3.Controls.Add(Me.cmdExportSubVoucher)
        Me.GroupBox3.Controls.Add(Me.cmdExitSubVoucher)
        Me.GroupBox3.Location = New System.Drawing.Point(28, 427)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(578, 64)
        Me.GroupBox3.TabIndex = 123
        Me.GroupBox3.TabStop = False
        '
        'cmdDelete
        '
        Me.cmdDelete.BackColor = System.Drawing.Color.Transparent
        Me.cmdDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdDelete.Location = New System.Drawing.Point(146, 10)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(137, 50)
        Me.cmdDelete.TabIndex = 6
        Me.cmdDelete.Text = "&Delete"
        Me.cmdDelete.UseVisualStyleBackColor = False
        '
        'cmdRefreshSubVoucher
        '
        Me.cmdRefreshSubVoucher.BackColor = System.Drawing.Color.Transparent
        Me.cmdRefreshSubVoucher.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRefreshSubVoucher.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefreshSubVoucher.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRefreshSubVoucher.Location = New System.Drawing.Point(10, 10)
        Me.cmdRefreshSubVoucher.Name = "cmdRefreshSubVoucher"
        Me.cmdRefreshSubVoucher.Size = New System.Drawing.Size(137, 50)
        Me.cmdRefreshSubVoucher.TabIndex = 5
        Me.cmdRefreshSubVoucher.Text = "Refres&h"
        Me.cmdRefreshSubVoucher.UseVisualStyleBackColor = False
        '
        'cmdExportSubVoucher
        '
        Me.cmdExportSubVoucher.BackColor = System.Drawing.Color.Transparent
        Me.cmdExportSubVoucher.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExportSubVoucher.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportSubVoucher.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExportSubVoucher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportSubVoucher.Location = New System.Drawing.Point(283, 10)
        Me.cmdExportSubVoucher.Name = "cmdExportSubVoucher"
        Me.cmdExportSubVoucher.Size = New System.Drawing.Size(137, 50)
        Me.cmdExportSubVoucher.TabIndex = 4
        Me.cmdExportSubVoucher.Text = "Exp&ort[F12]"
        Me.cmdExportSubVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExportSubVoucher.UseVisualStyleBackColor = False
        '
        'cmdExitSubVoucher
        '
        Me.cmdExitSubVoucher.BackColor = System.Drawing.Color.Transparent
        Me.cmdExitSubVoucher.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExitSubVoucher.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExitSubVoucher.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExitSubVoucher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExitSubVoucher.Location = New System.Drawing.Point(421, 10)
        Me.cmdExitSubVoucher.Name = "cmdExitSubVoucher"
        Me.cmdExitSubVoucher.Size = New System.Drawing.Size(137, 50)
        Me.cmdExitSubVoucher.TabIndex = 3
        Me.cmdExitSubVoucher.Text = "Ex&it[F11]"
        Me.cmdExitSubVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExitSubVoucher.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(134, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 45)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "&POST"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CreditDebit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = Global.Inventory.My.Resources.Resources._111in1024res1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1158, 674)
        Me.Controls.Add(Me.grpSsgrid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grpSsgridSub)
        Me.Controls.Add(Me.grpSsgridSubVoucher)
        Me.KeyPreview = True
        Me.Name = "CreditDebit"
        Me.Text = "CreditDebit"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpGrid.ResumeLayout(False)
        Me.grpSsgrid.ResumeLayout(False)
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSsgridSub.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ssgridSub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSsgridSubVoucher.ResumeLayout(False)
        CType(Me.ssgridSubVoucher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub CreditDebit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Then
            Me.cmdExit_Click(sender, e)
        End If
        If e.KeyCode = Keys.F12 Then
            Me.cmdExport_Click(sender, e)
        End If

    End Sub
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S, T, U As Integer
        'If (Screen.PrimaryScreen.Bounds.Height = 768) And (Screen.PrimaryScreen.Bounds.Width = 1366) Then
        '    Exit Sub
        'End If
        J = 768
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
                        ElseIf Controls(i_i).Name = "GroupBox4" Then
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
    Private Sub CreditDebit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load        
        grpSsgrid.Visible = True
        grpSsgridSub.Visible = False
        grpSsgridSubVoucher.Visible = False
        Resize_Form()
        Call getDetails()
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        ExportTo(ssgrid)
    End Sub

    Private Sub UPDATETABEL()

        'drop table INV
        'drop table acc
        'DROP TABLE PENDINGPOSTING
        'select * into inv from ACCOUNTPOSTINVENTORYFROMINVENTORY
        'select * into acc from ACCOUNTPOSTINVENTORYSUMMFROMACCOUNTS
        Dim sqlstring As String

        sqlstring = "if exists(select * from sysobjects where name='INV') begin DROP TABLE INV end"
        vconn.ExcuteStoreProcedure(sqlstring)
        sqlstring = "if exists(select * from sysobjects where name='ACC') begin DROP TABLE ACC end"
        vconn.ExcuteStoreProcedure(sqlstring)
        sqlstring = "if exists(select * from sysobjects where name='PENDINGPOSTING') begin DROP TABLE PENDINGPOSTING end"
        vconn.ExcuteStoreProcedure(sqlstring)

        'If gAcPostingWise = "ITEM" Then

        '    sqlstring = "select * into INV from ACCOUNTPOSTINVENTORYFROMINVENTORYITEMWISE"

        'ElseIf gAcPostingWise = "CATEGORY" Then

        '    sqlstring = "select * into INV from ACCOUNTPOSTINVENTORYFROMINVENTORY"
        'Else
        '    sqlstring = "select * into INV from ACCOUNTPOSTINVENTORYFROMINVENTORY"
        'End If


        sqlstring = "select * into INV from ACCOUNTPOSTINVENTORYFROMINVENTORY"
        vconn.ExcuteStoreProcedure(sqlstring)

        sqlstring = "select * into ACC from ACCOUNTPOSTINVENTORYSUMMFROMACCOUNTS"
        vconn.ExcuteStoreProcedure(sqlstring)
        sqlstring = "SELECT ISNULL(DOCNO,'') AS DOCNO,ISNULL(vouchertype,'') AS vouchertype,ISNULL(	DOCDATE,'') AS DOCDATE,ISNULL(ACCOUNTCODE,'') AS ACCOUNTCODE, ISNULL(ICA,0) AS ICA,ISNULL(IDA,0) AS IDA,ISNULL(	VOUCHERNO,'') AS VOUCHERNO,ISNULL(ACCCODE,'') AS ACCCODE,ISNULL(CREDITDEBIT,'') AS CREDITDEBIT,	ISNULL(ACA,0) AS ACA,ISNULL(ADA,0) AS ADA INTO PENDINGPOSTING FROM POSINGLIST"
        vconn.ExcuteStoreProcedure(sqlstring)
    End Sub




    Private Sub getDetails()

        If gAcPostingWise = "STORE" Then

        End If
        Call UPDATETABEL()


        strSqlString = "Select DISTINCT * FROM PENDINGPOSTING"
        vconn.getDataSet(strSqlString, "CreDeb")
        Call ssgridInitial()
        If gdataset.Tables("CreDeb").Rows.Count > 0 Then
            With ssgrid
                dblDiffTot = 0 : dblDebitAmt = 0 : dblCreditAmt = 0
                dblDiffTotA = 0 : dblDebitAmtA = 0 : dblCreditAmtA = 0
                ICT = 0 : IDT = 0 : ACT = 0 : ADT = 0
                RowCount = 3
                For intI = 0 To gdataset.Tables("CreDeb").Rows.Count - 1
                    .Row = RowCount
                    .Col = 1
                    .Text = gdataset.Tables("CreDeb").Rows(intI).Item("DOCNO")
                    .Col = 2
                    .Text = UCase(gdataset.Tables("CreDeb").Rows(intI).Item("VoucherType"))
                    .Col = 3
                    .Text = gdataset.Tables("CreDeb").Rows(intI).Item("DOCDATE")
                    .Col = 4
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeEdit
                    .Text = gdataset.Tables("CreDeb").Rows(intI).Item("ACCOUNTCODE")
                    ' dblDebitAmt = dblDebitAmt + Val(.Text)
                    .Col = 5
                    .Text = Format(Val(gdataset.Tables("CreDeb").Rows(intI).Item("ICA")), "0.00")
                    dblDebitAmt = dblDebitAmt + Val(.Text)
                    ICA = Val(.Text)
                    .Col = 6
                    .Text = Format(Val(gdataset.Tables("CreDeb").Rows(intI).Item("IDA")), "0.00")
                    dblCreditAmt = dblCreditAmt + Val(.Text)
                    IDA = Val(.Text)
                    .Col = 7
                    .Text = gdataset.Tables("CreDeb").Rows(intI).Item("VOUCHERNO")
                    .Col = 8
                    .Text = gdataset.Tables("CreDeb").Rows(intI).Item("ACCCODE")
                    .Col = 9
                    .Text = Format(Val(gdataset.Tables("CreDeb").Rows(intI).Item("ACA")), "0.00")
                    dblCreditAmtA = dblCreditAmtA + Val(.Text)
                    ACA = Val(.Text)
                    .Col = 10
                    .Text = Format(Val(gdataset.Tables("CreDeb").Rows(intI).Item("ADA")), "0.00")
                    dblDebitAmtA = dblDebitAmtA + Val(.Text)
                    ADA = Val(.Text)
                    .Col = 11
                    .Text = Format((ICA + IDA) - (ACA + ADA), "0.00")
                    ICT = ICA + ICT
                    IDT = IDA + IDT
                    ACT = ACA + ACT
                    ADT = ADA + ADT
                    '.Text = Format(Val(gdataset.Tables("CreDeb").Rows(intI).Item("ICA") - gdataset.Tables("CreDeb").Rows(intI).Item("IDA")), "0.00")
                    dblDiffTot = dblDiffTot + Val(.Text)
                    dblDiffTotA = dblDiffTotA + Val(.Text)
                    RowCount = RowCount + 1
                    .MaxRows = .MaxRows + 1
                Next
                RowCount = RowCount + 1
                .Row = RowCount
                .Col = 1
                .FontBold = True
                .ForeColor = Color.RosyBrown
                .Text = "T O T A L :"
                .Col = 5
                .Text = Format(Val(ICT), "0.00")
                .Col = 6
                .Text = Format(Val(IDT), "0.00")
                .Col = 7
                .Text = Format(Val(ICT) - Val(IDT), "0.00")
                .Col = 9
                .Text = Format(Val(ACT), "0.00")
                .Col = 10
                .Text = Format(Val(ADT), "0.00")
                .Col = 11
                .Text = Format(Val(ACT) - Val(ADT), "0.00")
            End With
        Else
            MsgBox("No Record(s) Found!", MsgBoxStyle.OkOnly, "Info!")
        End If
    End Sub

    Private Sub cmdGetDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetDetails.Click
        Call getDetails()
    End Sub
    Private Sub ssgridInitial()
        With ssgrid
            .ClearRange(1, 1, -1, -1, True)
            .Row = 1
            .Col = 1
            .Text = "DOC.NO"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 2
            .Text = "DOC.TYPE"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 3
            .Text = "DATE"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 4
            .Text = "ACCOUNTCODE"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 5
            .Text = "CREDIT"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 6
            .Text = "DEBIT"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 7
            .Text = "VOUCHER NO"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 8
            .Text = "ACCOUNTCODE"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 9
            .Text = "CREDIT"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 10
            .Text = "DEBIT"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 11
            .Text = "DIFFERENCE"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
        End With
    End Sub
    Private Sub ssgridSubInitial()
        With ssgridSub
            .ClearRange(1, 1, -1, -1, True)
            .Row = 1
            .Col = 1
            .Text = "TYPE"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 2
            .Text = "VOUCHER NO"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 3
            .Text = "DATE"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 4
            .Text = "CREDIT"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 5
            .Text = "DEBIT"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 6
            .Text = "DIFFERENCE"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
        End With
    End Sub
    Private Sub ssgridSubVoucherInitial()
        With ssgridSubVoucher
            .ClearRange(1, 1, -1, -1, True)
            .Row = 1
            .Col = 1
            .Text = "VOUCHER NO"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 2
            .Text = "DATE"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 3
            .Text = "MAIN LEDGER DESCRIPTION"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 4
            .Text = "SUBLEDGER DESCRIPTION"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 5
            .Text = "CREDIT"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
            .Col = 6
            .Text = "DEBIT"
            .FontBold = True
            .ForeColor = Color.SaddleBrown
        End With
    End Sub
    Private Sub ssgrid_DblClick(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_DblClickEvent) Handles ssgrid.DblClick
        '    Call getDetailsSub()
    End Sub

    Private Sub cmdRefreshSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshSub.Click
        Call getDetailsSub()
    End Sub

    Private Sub getDetailsSub()
        With ssgrid
            .Row = .ActiveRow
            .Col = 2
            strVType = Trim(.Text)
            .Col = 3
            intMonthNo = vconn.getMonthNo(UCase(Trim(.Text)))
            Call ssgridSubInitial()
            strSqlString = "Select	Isnull(VoucherNo,'') as VoucherNo, Isnull(VoucherDate,'') as VoucherDate, "
            strSqlString = strSqlString & " Isnull(Sum(Case CreditDebit When  'CREDIT' Then Amount End),0) as CreditAmount, Isnull(Sum(Case CreditDebit When  'DEBIT'  Then Amount End),0) as DebitAmount"
            strSqlString = strSqlString & " From	JournalEntry"
            strSqlString = strSqlString & " Where	Isnull(Void,'') <> 'Y' And VoucherType = '" & strVType & "' And Month(VoucherDate) = " & intMonthNo
            strSqlString = strSqlString & " Group by VoucherNo, VoucherDate"
            strSqlString = strSqlString & " Having 	Isnull(Sum(Case CreditDebit When  'CREDIT' Then Amount End),0) <> Isnull(Sum(Case CreditDebit When  'DEBIT'  Then Amount End),0)"
            strSqlString = strSqlString & " Order by VoucherNo, VoucherDate"
            vconn.getDataSet(strSqlString, "CreDebSub")
            If gdataset.Tables("CreDebSub").Rows.Count > 0 Then
                grpSsgridSubVoucher.Visible = False
                grpSsgrid.Visible = False
                grpSsgridSub.Visible = True                
                With ssgridSub
                    RowCount = 3
                    dblDiffTot = 0 : dblDebitAmt = 0 : dblCreditAmt = 0
                    For intI = 0 To gdataset.Tables("CreDebSub").Rows.Count - 1
                        .Row = RowCount
                        .Col = 1
                        .Text = strVType
                        .Col = 2
                        .Text = gdataset.Tables("CreDebSub").Rows(intI).Item("VoucherNo")
                        .Col = 3
                        .CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                        .Text = gdataset.Tables("CreDebSub").Rows(intI).Item("VoucherDate")                        
                        .Col = 4
                        .Text = Format(Val(gdataset.Tables("CreDebSub").Rows(intI).Item("CreditAmount")), "0.00")
                        dblDebitAmt = dblDebitAmt + Val(.Text)
                        .Col = 5
                        .Text = Format(Val(gdataset.Tables("CreDebSub").Rows(intI).Item("DebitAmount")), "0.00")
                        dblCreditAmt = dblCreditAmt + Val(.Text)
                        .Col = 6
                        .Text = Format(Val(gdataset.Tables("CreDebSub").Rows(intI).Item("CreditAmount") - gdataset.Tables("CreDebSub").Rows(intI).Item("DebitAmount")), "0.00")
                        dblDiffTot = dblDiffTot + Val(.Text)
                        RowCount = RowCount + 1
                        .MaxRows = .MaxRows + 1
                    Next
                    RowCount = RowCount + 1
                    .Row = RowCount
                    .Col = 1
                    .FontBold = True
                    .ForeColor = Color.RosyBrown
                    .Text = "T O T A L :"
                    .Col = 4
                    .Text = Format(Val(dblCreditAmt), "0.00")
                    .Col = 5
                    .Text = Format(Val(dblDebitAmt), "0.00")
                    .Col = 6
                    .Text = Format(Val(dblDiffTot), "0.00")
                End With
            Else
                MsgBox("No Record(s) Found!", MsgBoxStyle.OKOnly, "Info!")
            End If
        End With
    End Sub

    Private Sub getDetailsSubVoucher()
        With ssgridSub
            .Row = .ActiveRow
            .Col = 2
            strVNo = Trim(.Text)
            .Col = 3

            strSqlString = "Select	Isnull(VoucherDate,'') as VoucherDate, Isnull(AccountCode,'') as AccountCode, Isnull(AccountCodeDesc,'') as AccountCodeDesc, "
            strSqlString = strSqlString & " Isnull(SlCode,'') as SlCode, Isnull(SlDesc,'') as SlDesc, Isnull(CreditDebit,'') as CreditDebit, Isnull(Sum(Amount),0) as Amount"
            strSqlString = strSqlString & " From	JournalEntry"
            strSqlString = strSqlString & " Where	Isnull(Void,'') <> 'Y' And VoucherType = '" & strVType & "' And VoucherNo = '" & strVNo & "'"
            strSqlString = strSqlString & " Group by VoucherDate, Accountcode, AccountcodeDesc, SlCode, SlDesc, CreditDebit"
            strSqlString = strSqlString & " Order by VoucherDate, Accountcode, AccountcodeDesc, SlCode, SlDesc, CreditDebit"
            vconn.getDataSet(strSqlString, "CreDebSubVoucher")
            Call ssgridSubVoucherInitial()
            If gdataset.Tables("CreDebSubVoucher").Rows.Count > 0 Then
                grpSsgridSubVoucher.Visible = True
                grpSsgrid.Visible = False
                grpSsgridSub.Visible = False                
                With ssgridSubVoucher
                    RowCount = 3
                    dblDebitAmt = 0 : dblCreditAmt = 0
                    For intI = 0 To gdataset.Tables("CreDebSubVoucher").Rows.Count - 1
                        .Row = RowCount
                        .Col = 1
                        .Text = strVNo
                        .Col = 2
                        .CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                        .Text = gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("VoucherDate")
                        If gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("AccountCode") <> "" Then
                            .Col = 3
                            .Text = gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("AccountCode") & "-" & gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("AccountCodeDesc")
                        End If
                        If gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("SlCode") <> "" Then
                            .Col = 4
                            .Text = gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("SlCode") & "-" & gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("SlDesc")
                        End If
                        .Col = 5
                        If UCase(gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("CreditDebit")) = "CREDIT" Then
                            .Text = Format(Val(gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("Amount")), "0.00")
                            dblCreditAmt = dblCreditAmt + Val(.Text)
                        End If
                        .Col = 6
                        If UCase(gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("CreditDebit")) = "DEBIT" Then
                            .Text = Format(Val(gdataset.Tables("CreDebSubVoucher").Rows(intI).Item("Amount")), "0.00")
                            dblDebitAmt = dblDebitAmt + Val(.Text)
                        End If
                        RowCount = RowCount + 1
                        .MaxRows = .MaxRows + 1
                    Next
                    RowCount = RowCount + 1
                    .Row = RowCount
                    .Col = 1
                    .FontBold = True
                    .ForeColor = Color.RosyBrown
                    .Text = "T O T A L :"
                    .Col = 5
                    .Text = Format(Val(dblCreditAmt), "0.00")
                    .Col = 6
                    .Text = Format(Val(dblDebitAmt), "0.00")
                End With
            Else
                MsgBox("No Record(s) Found!", MsgBoxStyle.OKOnly, "Info!")
            End If
        End With
    End Sub

    Private Sub cmdExportSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportSub.Click
        ExportTo(ssgridSub)
    End Sub

    Private Sub cmdExitSub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExitSub.Click
        grpSsgridSub.Visible = False
        grpSsgridSubVoucher.Visible = False
        grpSsgrid.Visible = True
        Call getDetails()
    End Sub

    Private Sub cmdExitSubVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExitSubVoucher.Click
        grpSsgridSubVoucher.Visible = False
        grpSsgrid.Visible = False
        grpSsgridSub.Visible = True
        Call getDetailsSub()
    End Sub

    Private Sub cmdExportSubVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportSubVoucher.Click
        ExportTo(ssgridSubVoucher)
    End Sub

    Private Sub cmdRefreshSubVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshSubVoucher.Click
        Call getDetailsSubVoucher()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        If MsgBox("Are You Sure to Delete this Voucher?", MsgBoxStyle.YesNo, "Warning!") = MsgBoxResult.Yes Then
            strSql(0) = "Update Journalentry Set Void = 'Y', FreezeUserId = '" & gUsername & "', FreezeDateTime = '" & Format(DateValue(Now.ToString), "dd-MMM-yyyy") & "' Where VoucherNo = '" & strVNo & "' And VoucherType = '" & strVType & "'"
            vconn.MoreTrans(strSql)
            MsgBox("Voucher is Deleted Succuessfully!", MsgBoxStyle.OKOnly, "Info!")
            Call getDetailsSubVoucher()
        End If
    End Sub

    Private Sub ssgridSub_DblClick(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_DblClickEvent) Handles ssgridSub.DblClick
        Call getDetailsSubVoucher()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqlstring As String

        If validateoninsert() = False Then
            'sqlstring = "DELETE FROM  journalentry  where voucherno in(SELECT voucherno FROM ACC WHERE VOUCHERNO NOT IN(SELECT VOUCHERNO FROM INV))"
            'vconn.ExcuteStoreProcedure(sqlstring)
            'sqlstring = " delete from journalentry where voucherno in(SELECT voucherno FROM INV WHERE VOUCHERNO+ACCOUNTCODE+CREDITDEBIT+CAST(CAST(AMOUNT AS NUMERIC(18,2)) AS VARCHAR(20)) NOT IN(SELECT VOUCHERNO+ACCOUNTCODE+CREDITDEBIT+CAST(AMOUNT AS VARCHAR(20)) FROM ACC))"
            'vconn.ExcuteStoreProcedure(sqlstring)
            'sqlstring = " delete from journalentry where voucherno in(SELECT voucherno FROM INV WHERE VOUCHERNO+ACCOUNTCODE+CREDITDEBIT+CAST(CAST(AMOUNT AS NUMERIC(18,2)) AS VARCHAR(20)) NOT IN(SELECT VOUCHERNO+ACCOUNTCODE+CREDITDEBIT+CAST(AMOUNT AS VARCHAR(20)) FROM ACC))"
            'vconn.ExcuteStoreProcedure(sqlstring)
            'sqlstring = " delete from journalentry where voucherno in(SELECT  A.VoucherNo  FROM ACC A INNER JOIN INV I ON A.VoucherNo=I.VOUCHERNO WHERE A.CreditDebit='CREDIT' AND A.VoucherType='GRN' AND I.CreditDebit='CREDIT'  AND A.Amount<>I.AMOUNT)"
            'vconn.ExcuteStoreProcedure(sqlstring)

            sqlstring = "  delete from journalentry where LTRIM(RTRIM(voucherno))+LTRIM(RTRIM(VoucherType)) in(select DISTINCT LTRIM(RTRIM(DOCNO))+LTRIM(RTRIM(VoucherType)) from PENDINGPOSTING)"
            vconn.ExcuteStoreProcedure(sqlstring)

            sqlstring = " delete from journalentry where LTRIM(RTRIM(voucherno))+LTRIM(RTRIM(VoucherType)) in(select DISTINCT LTRIM(RTRIM(voucherno))+LTRIM(RTRIM(VoucherType)) from PENDINGPOSTING)"
            vconn.ExcuteStoreProcedure(sqlstring)

            sqlstring = "insert into journalentry( VOUCHERNO,voucherdate , VOUCHERCATEGORY, vouchertype, CASHBANK,ACCOUNTCODE , ACCOUNTcodeDESC, SLCODE, SLDESC, COSTCENTERCODE, COSTCENTERDESC,CREDITDEBIT,amount,description,void,batchno)"
            sqlstring = sqlstring & " select VOUCHERNO,voucherdate , VOUCHERCATEGORY, vouchertype, CASHBANK,ACCOUNTCODE , ACCOUNTDESC, SLCODE, SLDESC, COSTCENTERCODE, COSTCENTERDESC,CREDITDEBIT,amount,vouchertype+' '+VOUCHERNO+' '+cast(voucherdate as varchar(20)) description,'N'void,0 as batchno "
            sqlstring = sqlstring & " from ACCOUNTPOSTINVENTORYSUMM where voucherno+vouchertype in( SELECT  DOCNO+vouchertype  FROM PENDINGPOSTING)order by VOUCHERNO "
            ''sqlstring = sqlstring & " from ACCOUNTPOSTINVENTORYSUMM where voucherno+vouchertype in( SELECT  voucherno+vouchertype  FROM INV WHERE VOUCHERNO NOT IN(SELECT VOUCHERNO FROM ACC))order by VOUCHERNO "
            vconn.ExcuteStoreProcedure(sqlstring)

            sqlstring = "update journalentry set AccountcodeDesc=acdesc from journalentry, accountsglaccountmaster where AccountCode=accode and VoucherNo+vouchertype in (SELECT  DOCNO+vouchertype  FROM PENDINGPOSTING)"
            vconn.ExcuteStoreProcedure(sqlstring)
            MessageBox.Show("Posting Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Call ssgridInitial()

        End If
    End Sub


    Private Function validateoninsert() As Boolean
        Dim flag As Boolean
        Dim sqlstring, VOUCHERTYPE, COL As String


        strSqlString = "Select * FROM PENDINGPOSTING"
        vconn.getDataSet(strSqlString, "CreDeb")
        'Call ssgridInitial()
        If gdataset.Tables("CreDeb").Rows.Count > 0 Then

        Else
            flag = True
            Return flag
        End If

        If (GACCPOST.ToUpper() = "Y") Then
            If gAcPostingWise = "ITEM" Then


            ElseIf gAcPostingWise = "CATEGORY" Then


            Else
                sqlstring = "SELECT DISTINCT B.storecode AS STORECODE,A.vouchertype AS TYPE FROM ACCOUNTPOSTINVENTORYSUMM A "
                sqlstring = sqlstring & "  INNER JOIN INV_WEIGHTED_VIEW2 B ON A.VOUCHERNO=B.Docdetails WHERE  A.ACCOUNTCODE=''"
                vconn.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    'VOUCHERTYPE = gdataset.Tables("CODE").Rows(0).Item("VOUCHERTYPE")

                    For i As Integer = 0 To gdataset.Tables("code").Rows.Count - 1
                        If UCase(gdataset.Tables("CODE").Rows(i).Item("type")) = "ISSUE" Then
                            COL = "ACCOUNTCODE"
                        ElseIf UCase(gdataset.Tables("CODE").Rows(i).Item("type")) = "GRN" Then
                            COL = "ACCOUNTCODE"
                        ElseIf UCase(gdataset.Tables("CODE").Rows(i).Item("type")) = "ADJUSTMENT" Then
                            COL = "ADJGLCODE"
                        ElseIf UCase(gdataset.Tables("CODE").Rows(i).Item("type")) = "CONSUMPTION" Then
                            COL = "CONGLCODE"
                        ElseIf UCase(gdataset.Tables("CODE").Rows(i).Item("type")) = "DAMAGE" Then
                            COL = "DAMGLCODE"
                        ElseIf UCase(gdataset.Tables("CODE").Rows(i).Item("type")) = "STOCK TRANSFER" Then
                            COL = "ACCOUNTCODE"
                        End If
                        sqlstring = "select * from AccountstaggingNEW where ISNULL(" & COL & ",'') ='' AND CODE='" & gdataset.Tables("CODE").Rows(i).Item("STORECODE") & "'"
                        vconn.getDataSet(sqlstring, "TaxAccountstagging")
                        If (gdataset.Tables("TaxAccountstagging").Rows.Count > 0) Then
                            MessageBox.Show("NO GL FOUND FOR " & gdataset.Tables("CODE").Rows(i).Item("TYPE") & " FOR STORECODE : " & gdataset.Tables("CODE").Rows(i).Item("STORECODE") & "")
                            flag = True
                            Return flag
                        End If
                    Next
                End If
            End If

            If UCase(gShortname) = "CCL" Then
            Else
                sqlstring = "select  distinct tax from invtaxgroupmasterdetail where taxgroupcode in (select distinct taxcode from GRN_DETAILS where isnull(Voiditem,'N')='N') and isnull(void,'N')='N'"

                vconn.getDataSet(sqlstring, "CODE")
                If (gdataset.Tables("CODE").Rows.Count > 0) Then
                    For i As Integer = 0 To gdataset.Tables("code").Rows.Count - 1
                        sqlstring = "select * from TaxAccountstagging where  taxCODE='" & gdataset.Tables("CODE").Rows(i).Item("tax") & "'"
                        vconn.getDataSet(sqlstring, "TaxAccountstagging")
                        If (gdataset.Tables("TaxAccountstagging").Rows.Count > 0) Then

                        Else

                            MessageBox.Show("NO GL FOUND FOR TAX CODE : " & gdataset.Tables("CODE").Rows(i).Item("TAX"))
                            flag = True
                            Return flag
                        End If

                    Next
                End If
            End If
            
        End If
        Return False
    End Function

End Class