'Public Class frmStkLedger_grid
'    Inherits System.Windows.Forms.Form

'#Region " Windows Form Designer generated code "

'    Public Sub New()
'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()

'        'Add any initialization after the InitializeComponent() call

'    End Sub

'    'Form overrides dispose to clean up the component list.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Required by the Windows Form Designer
'    Private components As System.ComponentModel.IContainer

'    'NOTE: The following procedure is required by the Windows Form Designer
'    'It can be modified using the Windows Form Designer.  
'    'Do not modify it using the code editor.
'    Friend WithEvents ssGrid As AxFPSpreadADO.AxfpSpread
'    Friend WithEvents Cmd_View As System.Windows.Forms.Button
'    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
'    Friend WithEvents Cmd_Print1 As System.Windows.Forms.Button
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStkLedger_grid))
'        Me.ssGrid = New AxFPSpreadADO.AxfpSpread
'        Me.Cmd_View = New System.Windows.Forms.Button
'        Me.Cmd_Exit = New System.Windows.Forms.Button
'        Me.Cmd_Print1 = New System.Windows.Forms.Button
'        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).BeginInit()
'        Me.SuspendLayout()
'        '
'        'ssGrid
'        '
'        Me.ssGrid.DataSource = Nothing
'        Me.ssGrid.Location = New System.Drawing.Point(0, 0)
'        Me.ssGrid.Name = "ssGrid"
'        Me.ssGrid.OcxState = CType(resources.GetObject("ssGrid.OcxState"), System.Windows.Forms.AxHost.State)
'        Me.ssGrid.Size = New System.Drawing.Size(1016, 656)
'        Me.ssGrid.TabIndex = 452
'        '
'        'Cmd_View
'        '
'        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
'        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
'        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Cmd_View.ForeColor = System.Drawing.Color.White
'        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
'        Me.Cmd_View.Location = New System.Drawing.Point(296, 664)
'        Me.Cmd_View.Name = "Cmd_View"
'        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
'        Me.Cmd_View.TabIndex = 453
'        Me.Cmd_View.Text = "&EXPORT"
'        '
'        'Cmd_Exit
'        '
'        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
'        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
'        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
'        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
'        Me.Cmd_Exit.Location = New System.Drawing.Point(576, 664)
'        Me.Cmd_Exit.Name = "Cmd_Exit"
'        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
'        Me.Cmd_Exit.TabIndex = 454
'        Me.Cmd_Exit.Text = "E&xit[F11]"
'        '
'        'Cmd_Print1
'        '
'        Me.Cmd_Print1.BackColor = System.Drawing.Color.ForestGreen
'        Me.Cmd_Print1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
'        Me.Cmd_Print1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Cmd_Print1.ForeColor = System.Drawing.Color.White
'        Me.Cmd_Print1.Image = CType(resources.GetObject("Cmd_Print1.Image"), System.Drawing.Image)
'        Me.Cmd_Print1.Location = New System.Drawing.Point(432, 664)
'        Me.Cmd_Print1.Name = "Cmd_Print1"
'        Me.Cmd_Print1.Size = New System.Drawing.Size(104, 32)
'        Me.Cmd_Print1.TabIndex = 455
'        Me.Cmd_Print1.Text = " Print [F10]"
'        '
'        'frmStkLedger_grid
'        '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'        Me.ClientSize = New System.Drawing.Size(1016, 709)
'        Me.Controls.Add(Me.Cmd_Print1)
'        Me.Controls.Add(Me.Cmd_View)
'        Me.Controls.Add(Me.Cmd_Exit)
'        Me.Controls.Add(Me.ssGrid)
'        Me.Name = "frmStkLedger_grid"
'        Me.Text = "Stock Ledger"
'        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
'        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).EndInit()
'        Me.ResumeLayout(False)

'    End Sub

'#End Region
'    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
'        Me.Close()
'    End Sub

'    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
'        Try
'            Call Randomize()
'            AppPath = Application.StartupPath
'            vOutfile = Mid("STK" & (Rnd() * 800000), 1, 8)
'            VFilePath = AppPath & "\Reports\" & vOutfile & ".xls"
'            ssGrid.ExportToExcel(VFilePath, "STKledger$", AppPath & "\REPORTS\STKLDGR.log")
'            Shell(strexcelpath & " " & VFilePath, AppWinStyle.MaximizedFocus)
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Critical, "Export")
'        End Try

'    End Sub

'    Private Sub frmStkLedger_grid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

'    End Sub
'End Class
