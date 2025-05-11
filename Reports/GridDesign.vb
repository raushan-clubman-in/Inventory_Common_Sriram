Public Class GridDesign
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
    Friend WithEvents Lbl_Caption As System.Windows.Forms.Label
    Friend WithEvents Grid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents btn_Exporttoexcel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GridDesign))
        Me.Grid = New AxFPSpreadADO.AxfpSpread
        Me.Lbl_Caption = New System.Windows.Forms.Label
        Me.cmdexit = New System.Windows.Forms.Button
        Me.btn_Exporttoexcel = New System.Windows.Forms.Button
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.DataSource = Nothing
        Me.Grid.Location = New System.Drawing.Point(8, 48)
        Me.Grid.Name = "Grid"
        Me.Grid.OcxState = CType(resources.GetObject("Grid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Grid.Size = New System.Drawing.Size(1008, 632)
        Me.Grid.TabIndex = 0
        '
        'Lbl_Caption
        '
        Me.Lbl_Caption.AutoSize = True
        Me.Lbl_Caption.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Caption.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Caption.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.Lbl_Caption.Location = New System.Drawing.Point(392, 8)
        Me.Lbl_Caption.Name = "Lbl_Caption"
        Me.Lbl_Caption.Size = New System.Drawing.Size(185, 31)
        Me.Lbl_Caption.TabIndex = 1
        Me.Lbl_Caption.Text = "GRID HEADER"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.White
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.Location = New System.Drawing.Point(912, 8)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(104, 32)
        Me.cmdexit.TabIndex = 426
        Me.cmdexit.Text = "Exit[F11]"
        '
        'btn_Exporttoexcel
        '
        Me.btn_Exporttoexcel.BackColor = System.Drawing.Color.ForestGreen
        Me.btn_Exporttoexcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_Exporttoexcel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Exporttoexcel.ForeColor = System.Drawing.Color.White
        Me.btn_Exporttoexcel.Image = CType(resources.GetObject("btn_Exporttoexcel.Image"), System.Drawing.Image)
        Me.btn_Exporttoexcel.Location = New System.Drawing.Point(800, 8)
        Me.btn_Exporttoexcel.Name = "btn_Exporttoexcel"
        Me.btn_Exporttoexcel.Size = New System.Drawing.Size(104, 32)
        Me.btn_Exporttoexcel.TabIndex = 425
        Me.btn_Exporttoexcel.Text = "To Excel"
        '
        'GridDesign
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1028, 702)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.btn_Exporttoexcel)
        Me.Controls.Add(Me.Lbl_Caption)
        Me.Controls.Add(Me.Grid)
        Me.Name = "GridDesign"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INVENTORY [ GRID VIEW ]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim GRIDISSUEREGISTER As New rptIssueRegisterreport
    Dim GRIDISSUEDETAILS As New rptIssuedetailsreport
    Dim GRIDSTOCKMAINSTORE As New rptStockledgermainstockreport
    Dim GRIDPURCHASEREGISTER As New rptPurchaseregisterreport
    Dim GRIDMAINSTOCKPOSITION As New rptMainstockpositionreport
    Dim GRIDSTOCKOFBAR As New rptBarStockposition

    Private Sub GridDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If gridviewstatus = "IssueRegisterreport" Then
            Lbl_Caption.Text = "ISSUE REGISTER REPORT"
            Dim columnname() As String = {"DOC. NO.", "DATE", "POSTED TO", "ORDER NO/BATCH NO", "", "", "", ""}
            Dim columnname1() As String = {"", "", "", "ITEM DESCRIPTION", "UOM", "QUANTITY", "RATE", "AMOUNT"}
            Dim colsize() As Integer = {15, 15, 20, 50, 10, 10, 12, 12}
            GRIDISSUEREGISTER.GridColumnname(Grid, columnname, columnname1, colsize)
            GRIDISSUEREGISTER.BodyOfGrid(Grid)
        ElseIf gridviewstatus = "Issuedetailsreport" Then
            Lbl_Caption.Text = "ITEM WISE ISSUE DETAILS"
            Dim columnname() As String = {"CODE", "ISSUED TO", "UOM", "QUANTITY", "RATE", "AMOUNT"}
            Dim columnname1() As String = {"", "", "", "", "", ""}
            Dim colsize() As Integer = {70, 30, 10, 10, 12, 12}
            GRIDISSUEDETAILS.GridColumnname(Grid, columnname, columnname1, colsize)
            GRIDISSUEDETAILS.BodyOfGrid(Grid)
        ElseIf gridviewstatus = "Mainstockposition" Then
            Lbl_Caption.Text = "MAIN STOCK POSITION"
            Dim columnname() As String = {" ITEM CODE", "ITEM NAME", "UOM", "@", "", "OPENING", "", "", "RECEIPTS", "", "", "ISSUES", "", "", "CLOSING", ""}
            Dim columnname1() As String = {"", "", "", "", "QUANTITY", "  RATE", "VALUE", "QUANTITY", "  RATE", "VALUE", "QUANTITY", "  RATE", "VALUE", "QUANTITY", "  RATE", "VALUE"}
            Dim colsize() As Integer = {10, 30, 10, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}
            GRIDMAINSTOCKPOSITION.GridColumnname(Grid, columnname, columnname1, colsize)
            GRIDMAINSTOCKPOSITION.BodyOfGrid(Grid)
        ElseIf gridviewstatus = "Purchasereisterreport" Then
            Lbl_Caption.Text = "PURCHASE REGISTER CUM O/S POSITION AS ON :"
            Lbl_Caption.Left = 280
            Lbl_Caption.Top = 8
            Dim columnname() As String = {"BILL NO", "BILL DATE", "BILL DETAILS", "UOM", "QUANTITY", "RATE", "AMOUNT", "DISCOUNT"}
            Dim columnname1() As String = {"", "", "", "", "", "", "", ""}
            Dim colsize() As Integer = {20, 15, 50, 10, 10, 10, 10, 10}
            GRIDPURCHASEREGISTER.GridColumnname(Grid, columnname, columnname1, colsize)
            GRIDPURCHASEREGISTER.BodyOfGrid(Grid)
        ElseIf gridviewstatus = "BarStockPosition" Then
            Lbl_Caption.Text = "BAR STOCK POSITION"
            Dim columnname() As String = {"ITEM CODE", "ITEM NAME", "UOM", "OPENING", "OPENING", "RECEIVED", "TRANSFER", "SALES", "SALE", "CLOSING", "CLOSING"}
            Dim columnname1() As String = {"", "", "", "QUANTITY", "VALUE", "QUANTITY", "QUANTITY", "QUANTITY", "VALUE", "QUANITY", "VALUE"}
            Dim colsize() As Integer = {20, 15, 50, 10, 10, 10, 10, 10}
            GRIDSTOCKOFBAR.GridColumnname(Grid, columnname, columnname1, colsize)
            GRIDSTOCKOFBAR.BodyOfGrid(Grid)
        Else : gridviewstatus = "Stockledgermainstore"
            Lbl_Caption.Text = "STOCK LEDGER MAIN STOCK [GROUP WISE ]"
            Lbl_Caption.Left = 280
            Lbl_Caption.Top = 8
            Dim columnname() As String = {"CODE", "ITEM NAME", "", "", "RATE", "VALUE", "RECEIPTS", "ISSUES", "BALANCE"}
            Dim columnname1() As String = {"DATE", "TYP DOC.NO", "PARTY NAME", "REMARKS", "", "", "QUANTITY", "QUANTITY", "QUANTITY"}
            Dim colsize() As Integer = {15, 20, 20, 25, 10, 10, 15, 15, 10}
            GRIDSTOCKMAINSTORE.GridColumnname(Grid, columnname, columnname1, colsize)
            GRIDSTOCKMAINSTORE.BodyOfGrid(Grid)
        End If
    End Sub
    Private Sub Grid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles Grid.KeyDownEvent
        If gridviewstatus = "IssueRegisterreport" Then
            GRIDISSUEREGISTER.KeyDownEvent(Grid, e)
        Else : gridviewstatus = "Issuedetailsreport"
            GRIDISSUEDETAILS.KeyDownEvent(Grid, e)
        End If
    End Sub

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_DblClickEvent) Handles Grid.DblClick
        If gridviewstatus = "IssueRegisterreport" Then
            GRIDISSUEREGISTER.DoubleClick(Grid, e)
        Else : gridviewstatus = "Issuedetailsreport"
            GRIDISSUEDETAILS.DoubleClick(Grid, e)
        End If
    End Sub
    Private Sub Grid_ClickEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_ClickEvent) Handles Grid.ClickEvent
        'If gridviewstatus = "IssueRegisterreport" Then
        '    GRIDISSUEREGISTER.Highlight(Grid)
        'Else : gridviewstatus = "subledger"
        '    GRIDSUBLEDGER.Highlight(Grid)
        'End If
    End Sub

    Private Sub btn_Exporttoexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Exporttoexcel.Click
        Call ExportTo(Grid)
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
End Class